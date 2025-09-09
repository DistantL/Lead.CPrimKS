using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Lead.CPrim.View
{
    internal static class Program
    {
        /// <summary>应用程序的主入口点。</summary>
        [STAThread]
        private static void Main()
        {
            //使用 ThreadException 事件来处理 UI 线程异常
            Application.ThreadException += ApplicationOnThreadException;

            //使用 UnhandledException 事件来处理非 UI 线程异常
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

            var openMoreEnable = Properties.Settings.Default.允许多开;
            var fi = new FileInfo(Application.ExecutablePath);
            var ps = Process.GetProcessesByName(fi.Name.Replace(fi.Extension, ""));
            if (!openMoreEnable && ps.Length >= 2)
            {
                MessageBox.Show(string.Format(ProxyTools.NLocalizer.GetString("View_Program_SoftwareHasBeenStarted", "{0} SoftWare has been started！"), fi.Name));
            }
            else
            {
                string pathTest = Application.StartupPath + @"\ExtLibs\Third\GlobalVariable\GlobalVariable.dll";
                string path = Application.StartupPath + @"\ExtLibs\Third\GlobalVariable.dll";
                if(File.Exists(pathTest))
                {
                    File.Delete(path);
                    File.Move(pathTest, path);
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }


        /// <summary>使用 ThreadException 事件来处理 UI 线程异常</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                WriteMessageToFile( Application.StartupPath + "\\CPrimException\\" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-UIException.txt", e.Exception.Message + Environment.NewLine + e.Exception.StackTrace);
            }
            catch
            {
                //不可恢复的Windows窗体异常，应用程序将退出！
            }
        }
        /// <summary>使用 UnhandledException 事件来处理非 UI 线程异常</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                var ex = (Exception)e.ExceptionObject;
                WriteMessageToFile( Application.StartupPath + "\\CPrimException\\" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-OtherException.txt", ex.Message + Environment.NewLine + ex.StackTrace);
            }
            catch
            {
                //不可恢复的非Windows窗体线程异常，应用程序将退出！
            }
        }

        private static void WriteMessageToFile(string fileName, string msg)
        {
            var dirPath = Path.GetDirectoryName(fileName);
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath ?? string.Empty);
            }
            using (var fs = new FileStream(fileName, FileMode.CreateNew, FileAccess.ReadWrite))
            {
                var sw = new StreamWriter(fs, GlobalVariables.EncodingChinese);
                try
                {
                    sw.Write(msg);
                    sw.Flush();
                }
                finally
                {
                    sw.Close();
                    fs.Close();
                }
            }
        }
    }
}