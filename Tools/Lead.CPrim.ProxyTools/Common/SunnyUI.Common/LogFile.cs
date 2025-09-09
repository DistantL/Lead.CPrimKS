using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace Sunny.UI
{
    public class LogFile : IDisposable
	{
		private class LogInfo
		{
			public SunnyLogLevel Level { get; set; }

			public DateTime Time { get; set; }

			public string Message { get; set; }

			public string DebugInfo { get; set; }
		}

		private readonly StringBuilder sb = new StringBuilder();

		private BackgroundWorker saver;

		private readonly ConcurrentQueue<LogInfo> Queue = new ConcurrentQueue<LogInfo>();

		private LogInfo NoWriteLog;

		private bool needLog = true;

		public SunnyLogLevel Level { get; set; }

		public bool LogDebugInfo { get; set; }

		public bool UseThread { get; set; }

		public string DateTimeFormat { get; set; }

		public string FileNamePrefix { get; set; }

		public string FilePath { get; set; }

		public int MaxFileSize { get; set; }

		public LogFile()
			: this("Log", string.Empty)
		{
		}

		public LogFile(string name)
			: this(name, string.Empty)
		{
		}

		public LogFile(string name, string direct)
		{
			Level = SunnyLogLevel.ALL;
			DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
			MaxFileSize = 1048576;
			FileNamePrefix = name;
			FilePath = CurrentDir() + "Logs\\";
			if (!direct.IsNullOrEmpty())
			{
				FilePath = FilePath + direct + "\\";
			}
		}

		public void StartThread()
		{
			if (saver == null)
			{
				saver = new BackgroundWorker();
				saver.DoWork += Saver_DoWork;
			}
			saver.WorkerSupportsCancellation = true;
			UseThread = true;
			if (!saver.IsBusy)
			{
				saver.RunWorkerAsync();
			}
		}

		public void StopThread()
		{
			needLog = false;
		}

		private static string CurrentDir()
		{
			return DealPath(AppDomain.CurrentDomain.BaseDirectory);
		}

		private static string DealPath(string path)
		{
			return (path.Right(1) == "\\") ? path : (path + "\\");
		}

		private void Dispose(bool disposing)
		{
			ReleaseUnmanagedResources();
			if (disposing)
			{
				StopThread();
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		private static string StackFrameLocationInfo()
		{
			StackTrace stackTrace = new StackTrace(1, fNeedFileInfo: true);
			StackFrame frame = stackTrace.GetFrame(2);
			if (frame == null)
			{
				return "UnknownClass";
			}
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(frame.GetFileName());
			return $"{fileNameWithoutExtension},{frame.GetMethod()?.Name},L{frame.GetFileLineNumber()}";
		}

		private static string YearMonthFolder(DateTime dt, string path, bool createIfNotExist = false)
		{
			if (path.IsNullOrEmpty())
			{
				return path;
			}
			string text = DealPath(path) + dt.Year.ToString("D4") + dt.Month.ToString("D2") + "\\";
			if (createIfNotExist)
			{
				CreateDir(text);
			}
			return text;
		}

		private static void CreateDir(string directoryPath)
		{
			if (!Directory.Exists(directoryPath))
			{
				try
				{
					Directory.CreateDirectory(directoryPath);
				}
				catch (Exception value)
				{
					Console.WriteLine(value);
				}
			}
		}

		private string GetLogFileName(LogInfo log)
		{
			string text = YearMonthFolder(log.Time, FilePath, createIfNotExist: true);
			int num = 1;
			string text2 = text + log.Time.ToString("yyyyMMdd") + "." + num + "." + FileNamePrefix + ".txt";
			FileInfo fileInfo = new FileInfo(text2);
			while (fileInfo.Exists && fileInfo.Length >= MaxFileSize)
			{
				num++;
				text2 = text + log.Time.ToString("yyyyMMdd") + "." + num + "." + FileNamePrefix + ".txt";
				fileInfo = new FileInfo(text2);
			}
			return text2;
		}

		private void ReleaseUnmanagedResources()
		{
			saver.CancelAsync();
		}

		private void Saver_DoWork(object sender, DoWorkEventArgs e)
		{
			while (needLog && !saver.CancellationPending)
			{
				WriteLog();
				Thread.Sleep(100);
			}
			e.Cancel = true;
		}

		public void Debug(params string[] message)
		{
			AddLog(SunnyLogLevel.DEBUG, message);
		}

		public void Info(params string[] message)
		{
			AddLog(SunnyLogLevel.INFO, message);
		}

		public void Warn(params string[] message)
		{
			AddLog(SunnyLogLevel.WARN, message);
		}

		public void Error(params string[] message)
		{
			AddLog(SunnyLogLevel.ERROR, message);
		}

		public void Fatal(params string[] message)
		{
			AddLog(SunnyLogLevel.FATAL, message);
		}

		public void WarnException(Exception e)
		{
			AddLog(SunnyLogLevel.WARN, e.Message.Trim(), e.StackTrace?.Trim());
		}

		public void ErrorException(Exception e)
		{
			AddLog(SunnyLogLevel.ERROR, e.Message.Trim(), e.StackTrace?.Trim());
		}

		public void FatalException(Exception e)
		{
			AddLog(SunnyLogLevel.FATAL, e.Message.Trim(), e.StackTrace?.Trim());
		}

		private void AddLog(SunnyLogLevel level, params string[] message)
		{
			if (level >= Level)
			{
				LogInfo logInfo = new LogInfo();
				if (LogDebugInfo || level >= SunnyLogLevel.WARN)
				{
					logInfo.DebugInfo = StackFrameLocationInfo();
				}
				logInfo.Level = level;
				logInfo.Time = DateTime.Now;
				logInfo.Message = string.Join(",", message);
				if (UseThread)
				{
					Queue.Enqueue(logInfo);
				}
				else
				{
					WriteAtOnce(logInfo);
				}
			}
		}

		private void WriteAtOnce(LogInfo log)
		{
			sb.Clear();
			AddLog(log);
			bool flag = false;
			while (!flag)
			{
				try
				{
					string logFileName = GetLogFileName(log);
					StreamWriter streamWriter = File.AppendText(logFileName);
					streamWriter.WriteLine(sb.ToString());
					streamWriter.Flush();
					streamWriter.Close();
					streamWriter.Dispose();
					flag = true;
				}
				catch (Exception)
				{
				}
			}
		}

		private void AddLog(LogInfo log)
		{
			sb.Append(log.Time.ToString(DateTimeFormat));
			sb.Append(',');
			sb.Append(log.Level.DisplayText());
			sb.Append(',');
			sb.Append(log.Message);
			if (log.DebugInfo.IsValid())
			{
				sb.Append(',');
				sb.Append(log.DebugInfo);
			}
		}

		private void WriteLog()
		{
			if (NoWriteLog == null && Queue.Count == 0)
			{
				return;
			}
			sb.Clear();
			LogInfo result = null;
			if (NoWriteLog == null)
			{
				while (result == null)
				{
					Queue.TryDequeue(out result);
				}
			}
			else
			{
				result = NoWriteLog;
				NoWriteLog = null;
			}
			try
			{
				DateTime time = result.Time;
				string logFileName = GetLogFileName(result);
				AddLog(result);
				while (Queue.Count > 0)
				{
					if (Queue.TryDequeue(out result))
					{
						if (!(result.Time.Date == time.Date))
						{
							NoWriteLog = result;
							break;
						}
						sb.Append('\r');
						sb.Append('\n');
						AddLog(result);
					}
				}
				StreamWriter streamWriter = File.AppendText(logFileName);
				streamWriter.WriteLine(sb.ToString());
				streamWriter.Flush();
				streamWriter.Close();
				streamWriter.Dispose();
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
			}
		}
	}
}
