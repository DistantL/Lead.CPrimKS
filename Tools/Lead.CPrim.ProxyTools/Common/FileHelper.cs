using Lead.CPrim.Interfaces;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>File帮助类</summary>
    public class FileHelper
    {
        /// <summary>提示用户打开文件（默认所有格式文件）</summary>
        /// <param name="filePath">返回文件目录</param>
        /// <returns>bool</returns>
        public static bool OpenFileDialogMethod(ref string filePath)
        {
            return OpenFileDialogMethod("", FilterType.ALL, false, ref filePath);
        }

        /// <summary>提示用户打开文件</summary>
        /// <param name="title">标题</param>
        /// <param name="filter">文件类型</param>
        /// <param name="multiselect">是否可以多选</param>
        /// <param name="filePath">返回文件目录</param>
        /// <returns>bool</returns>
        public static bool OpenFileDialogMethod(string title, FilterType filter, bool multiselect, ref string filePath)
        {
            bool ret = false;
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Title = string.IsNullOrEmpty(title) ? "打开文件" : title,
                    Filter = filter == FilterType.CSV ? "CSV 文件 (*.csv)|*.csv" :
                    (filter == FilterType.JSON ? "JSON 文件 (*.json) | *.json" :
                    (filter == FilterType.XML ? "XML 文件 (*.xml) | *.xml" :
                    "所有文件 (*.*)|*.*")),
                    Multiselect = multiselect,
                    RestoreDirectory = true,
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    ret = true;
                }
            }
            catch { }

            return ret;
        }

        /// <summary>提示用户保存文件</summary>
        /// <param name="title">标题</param>
        /// <param name="filter">文件类型</param>
        /// <param name="defaultExt">默认扩展名</param>
        /// <param name="restoreDirectory">是否将目录还原为之前的目录</param>
        /// <param name="createPrompt">提示用户创建文件</param>
        /// <param name="addExtension">是否自动增加扩展名</param>
        /// <param name="filePath">返回文件目录</param>
        /// <returns>bool</returns>
        public static bool SaveFileDialogMethod(string title, FilterType filter, DefaultExt defaultExt, bool restoreDirectory, bool createPrompt, bool addExtension, ref string filePath)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = string.IsNullOrEmpty(title) ? "保存文件" : title,
                RestoreDirectory = restoreDirectory,
                CreatePrompt = createPrompt,
                AddExtension = addExtension,
            };

            switch (filter)
            {
                case FilterType.CSV:
                    sfd.Filter = "CSV 文件 (*.csv)|*.csv";
                    break;

                case FilterType.JSON:
                    sfd.Filter = "JSON 文件 (*.json) | *.json";
                    break;

                case FilterType.XML:
                    sfd.Filter = "XML 文件 (*.xml) | *.xml";
                    break;

                case FilterType.CS:
                    sfd.Filter = "CS 文件 (*.cs) | *.cs";
                    break;

                case FilterType.DLL:
                    sfd.Filter = "DLL 文件 (*.dll) | *.dll";
                    break;

                case FilterType.XLSX:
                    sfd.Filter = "XLSX 文件 (*.xlsx) | *.xlsx";
                    break;

                case FilterType.ALL:
                case FilterType.Other:
                default:
                    sfd.Filter = "所有文件 (*.*)|*.*";
                    break;
            }
            switch (defaultExt)
            {
                case DefaultExt.CSV:
                    sfd.DefaultExt = ".csv";
                    break;

                case DefaultExt.JSON:
                    sfd.DefaultExt = ".json";
                    break;

                case DefaultExt.XML:
                    sfd.DefaultExt = ".xml";
                    break;

                case DefaultExt.CS:
                    sfd.DefaultExt = ".cs";
                    break;

                case DefaultExt.Dll:
                    sfd.DefaultExt = ".dll";
                    break;

                case DefaultExt.XLSX:
                    sfd.DefaultExt = ".xlsx";
                    break;

                case DefaultExt.ALL:
                case DefaultExt.Other:
                default:
                    sfd.DefaultExt = "";
                    break;
            }

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filePath = sfd.FileName;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>提示用户选择文件夹</summary>
        /// <param name="folderPath">返回文件夹目录</param>
        public static bool OpenFolderDialogMethod(ref string folderPath)
        {
            bool ret = false;
            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
                {
                    Description = "请选择文件夹",
                    ShowNewFolderButton = true,
                };

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    folderPath = folderBrowserDialog.SelectedPath;
                    ret = true;
                }
            }
            catch { }

            return ret;
        }

        /// <summary>源文件夹复制至目标文件夹</summary>
        /// <param name="sourceDirectory">源文件夹</param>
        /// <param name="destinationDirectory">目标文件夹</param>
        /// <param name="isIncludeSourceDirectory">true：包含源文件夹一起复制；false：只复制源文件夹内的文件以及文件夹</param>
        public static int CopyDirectory(string sourceDirectory, string destinationDirectory, bool isIncludeSourceDirectory)
        {
            try
            {
                if (isIncludeSourceDirectory)
                {
                    if (sourceDirectory.EndsWith("\\"))
                    {
                        sourceDirectory = sourceDirectory.TrimEnd('\\');
                    }
                    string file = sourceDirectory.Substring(sourceDirectory.LastIndexOf("\\") + 1);
                    destinationDirectory = Path.Combine(destinationDirectory, file);
                }
                DirectoryInfo directorysrc = new DirectoryInfo(sourceDirectory);
                DirectoryInfo directorydest = new DirectoryInfo(destinationDirectory);
                if (directorydest.FullName.StartsWith(directorysrc.FullName, StringComparison.CurrentCultureIgnoreCase))
                {
                    LogHelper.LogAdd(LogLevel.Warn, $"无法将父目录复制到子目录", PrimLogId.Tool.ToString());
                    return (int)SoftWareAlarm.Tools_无法将父目录复制到子目录;
                }

                if (directorysrc.Exists)
                {
                    if (!directorydest.Exists)
                    {
                        directorydest.Create();
                    }

                    //文件复制
                    FileInfo[] files = directorysrc.GetFiles();
                    for (int i = 0; i < files.Length; i++)
                    {
                        CopyFile(files[i].FullName, directorydest.FullName);
                    }

                    //文件夹复制
                    DirectoryInfo[] directories = directorysrc.GetDirectories();
                    for (int j = 0; j < directories.Length; j++)
                    {
                        CopyDirectory(directories[j].FullName, directorydest.FullName + "\\" + directories[j].Name, false);
                    }

                    return 0;
                }
                else
                {
                    return (int)SoftWareAlarm.Tools_文件夹不存在;
                }
            }
            catch(Exception ex)
            {
                LogHelper.LogAdd(LogLevel.Warn, $"CopyDirectory失败：{ex.Message}", PrimLogId.Tool.ToString());
                return (int)SoftWareAlarm.Tools_CopyDirectory失败;
            }
        }

        /// <summary>源文件复制至目标文件夹（直接覆盖）</summary>
        /// <param name="sourceFile">源文件</param>
        /// <param name="destinationDirectory">目标文件夹</param>
        /// <returns>0：成功；非0：失败；</returns>
        public static int CopyFile(string sourceFile, string destinationDirectory)
        {
            try
            {
                if (!File.Exists(sourceFile))
                {
                    return (int)SoftWareAlarm.Tools_文件不存在;
                }
                DirectoryInfo directoryInfo = new DirectoryInfo(destinationDirectory);
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }

                string fileName = Path.GetFileName(sourceFile);
                File.Copy(sourceFile, directoryInfo.FullName + "\\" + fileName, overwrite: true);
                return 0;
            }
            catch (Exception ex)
            {
                LogHelper.LogAdd(LogLevel.Warn, $"CopyFile失败：{ex.Message}", PrimLogId.Tool.ToString());
                return (int)SoftWareAlarm.Tools_CopyFile失败;
            }
        }

        /// <summary>创建文件夹</summary>
        /// <param name="path">文件路径</param>
        /// <returns>true：创建成功；false：创建失败；</returns>
        public static bool CreateNewFolder(string path)
        {
            try
            {
                string[] partPath = path.Split('\\') ;
                string allPath = partPath[0];
                for (int i = 0; i < partPath.Length; i++)
                {
                    allPath += $"\\{partPath[i + 1]}";
                    if(!Directory.Exists(allPath) && partPath[i + 1].IndexOf(".") == -1)
                    {
                        Directory.CreateDirectory(allPath);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }



        private static readonly IntPtr HFILE_ERROR = new IntPtr(-1);
        [DllImport("kernel32.dll")]
        private static extern IntPtr _lopen(string lpPathName, int iReadWrite);

        [DllImport("kernel32.dll")]
        private static extern bool CloseHandle(IntPtr hObject);

        public static bool FileIsIdle(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }
            IntPtr intPtr = _lopen(filePath, 66);
            if (intPtr == HFILE_ERROR)
            {
                return false;
            }
            CloseHandle(intPtr);
            return true;
        }

        public static bool ConnectRemoteDir(string path, string userName, string passWord)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.StandardInput.WriteLine("net use * /del /y");
                Thread.Sleep(500);
                string value = "net use " + path + " /User:" + userName + " " + passWord + " /PERSISTENT:YES";
                process.StandardInput.WriteLine(value);
                process.StandardInput.WriteLine("exit");
                while (!process.HasExited)
                {
                    process.WaitForExit(1000);
                }
                string text = process.StandardError.ReadToEnd();
                process.StandardError.Close();
                if (!string.IsNullOrEmpty(text))
                {
                    throw new Exception(text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                process.Close();
                process.Dispose();
            }
            return true;
        }

        public static void TransportFromOrToRemote(string src, string dst, string fileName)
        {
            FileStream fileStream = new FileStream(src, FileMode.Open);
            if (!Directory.Exists(dst))
            {
                Directory.CreateDirectory(dst);
            }
            dst += fileName;
            FileStream fileStream2 = new FileStream(dst, FileMode.OpenOrCreate);
            byte[] array = new byte[fileStream.Length];
            int count;
            while ((count = fileStream.Read(array, 0, array.Length)) > 0)
            {
                fileStream2.Write(array, 0, count);
            }
            fileStream.Flush();
            fileStream.Close();
            fileStream2.Flush();
            fileStream2.Close();
        }
    }
}
