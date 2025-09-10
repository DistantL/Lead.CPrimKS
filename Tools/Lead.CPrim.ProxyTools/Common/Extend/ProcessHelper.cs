/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ProcessHelper.cs
 * Author: Victor
 * Description: 进程帮助类
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 *
 * <3.3.33.0617><Victor><20220710>  
 * 1、文件类名变更为ProcessHelper.cs
******************************************************************************/

using Lead.CPrim.Interfaces;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 进程帮助类
    /// </summary>
    public static class ProcessHelper
    {
        /// <summary>
        /// 根据名称结束进程
        /// </summary>
        /// <param name="strProcName"></param>
        public static void KillProc(string strProcName)
        {
            Process[] processesByName = Process.GetProcessesByName(strProcName);
            foreach (Process process in processesByName)
            {
                if (!process.CloseMainWindow())
                {
                    process.Kill();
                }
            }
        }

        /// <summary>进程按名称启动</summary>
		/// <param name="strProcName">名称</param>
		public static bool ProcessStart(string strProcName)
        {
            try
            {
                if (string.IsNullOrEmpty(strProcName) || !File.Exists(strProcName))
                {
                    return false;
                }
                ProcessStartInfo process = new ProcessStartInfo
                {
                    FileName = strProcName,
                };
                Process.Start(process);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 运行批处理字符串
        /// </summary>
        /// <param name="batchString"></param>
        /// <param name="hour"></param>
        public static void RunBatchProcessing(this string batchString, double hour = 0.5)
        {
            if (string.IsNullOrWhiteSpace(batchString))
            {
                return;
            }

            string tempBatchPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.bat");
            try
            {
                File.WriteAllText(tempBatchPath, batchString, Encoding.GetEncoding(936));

                var info = new ProcessStartInfo
                {
                    FileName = tempBatchPath,
                    Verb = "runas",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = true,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(info))
                {
                    // 默认30min
                    if (!process.WaitForExit((int)(hour * 60 * 1000)))
                    {
                        process.Kill();
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Warn($"{nameof(ProcessHelper)}.{nameof(RunBatchProcessing)}", ex);
            }
            finally
            {
                var file = tempBatchPath.GetFileInfo();
                if (file != null)
                {
                    file.Delete();
                }
            }
        }

        /// <summary>
        /// 判断进程是否存在
        /// </summary>
        /// <param name="strProcName"></param>
        /// <returns></returns>
        public static bool SearchProc(string strProcName)
        {
            try
            {
                Process[] processesByName = Process.GetProcessesByName(strProcName);
                if (processesByName.Length != 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 查看图片
        /// </summary>
        /// <param name="path"></param>
        public static void ViewPicture(string path)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo
                {
                    FileName = "explorer.exe",
                    Arguments = path,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Maximized,
                };
                Process.Start(info);
            }
            catch (InvalidOperationException ex)
            {
                string messageDialog = NLocalizer.OperationIsInvalidWhenViewingTheImage;
                LogHelper.LogAdd(LogLevel.Warn, $"{messageDialog}：{ex.Message}：{ex.StackTrace}", LogClassification.Tools.ToString());
            }
            catch (ArgumentNullException ex)
            {
                string messageDialog = NLocalizer.ParameterIsEmptyWhenViewingTheImage;
                LogHelper.LogAdd(LogLevel.Warn, $"{messageDialog}：{ex.Message}：{ex.StackTrace}", LogClassification.Tools.ToString());
            }
            catch (FileNotFoundException ex)
            {
                string messageDialog = NLocalizer.FileNotFoundWhenViewingTheImage;
                LogHelper.LogAdd(LogLevel.Warn, $"{messageDialog}：{ex.Message}：{ex.StackTrace}", LogClassification.Tools.ToString());
            }
        }
    }
}
