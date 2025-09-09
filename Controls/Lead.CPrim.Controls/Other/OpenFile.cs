using Lead.CPrim.Global;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Lead.CPrim.Controls
{
    /// <summary>
    /// 文件操作
    /// </summary>
    public partial class OpenFile : Form
    {
        #region Field
        /// <summary>SFLLogPath</summary>
        private string LogPath = @"D:\CPrimlog";
        /// <summary>SFLLogPath</summary>
        private string SFLLogPath = "";
        /// <summary>PDCALogPath</summary>
        private string PDCALogPath = "";
        /// <summary>MachineLog</summary>
        private string MachineLog = "";
        /// <summary>Data</summary>
        private string DataPath = "";

        /// <summary>
        /// 文件操作对象
        /// </summary>
        private static OpenFile _instance = new OpenFile();
        #endregion



        #region Prop
        /// <summary>
        /// 文件操作对象
        /// </summary>
        public static OpenFile Instance { get => _instance; set => _instance = value; }
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        private OpenFile()
        {
            InitializeComponent();
        }
        #endregion



        #region Button_Event
        /// <summary>数据文件</summary>
        private void btnData_Click(object sender, EventArgs e)
        {
            try
            {
                DataPath = SwManager.Instance.MachineDataPath;

                if (Directory.Exists(DataPath))
                {
                    Process.Start(DataPath);
                }

                base.DialogResult = DialogResult.Yes;
            }
            catch
            {
                base.DialogResult = DialogResult.Yes;
            }
        }
        /// <summary>打开SFL日志</summary>
        private void btnSFLLog_Click(object sender, EventArgs e)
        {
            try
            {
                SFLLogPath = SwManager.Instance.SFLPath;
                string temp = SFLLogPath + "\\" + DateTime.Now.ToString("yyyy-MM-dd");
                if (Directory.Exists(temp))
                {
                    Process.Start(temp);
                    throw new Exception("跳转");
                }

                if (Directory.Exists(SFLLogPath))
                {
                    Process.Start(SFLLogPath);
                    throw new Exception("跳转");
                }

                if (Directory.Exists(LogPath))
                {
                    Process.Start(LogPath);
                }

                base.DialogResult = DialogResult.Yes;
            }
            catch
            {
                base.DialogResult = DialogResult.Yes;
            }
        }
        /// <summary>打开PDCA日志</summary>
        private void btnPDCALog_Click(object sender, EventArgs e)
        {
            try
            {
                PDCALogPath = SwManager.Instance.PDCAPath;
                string temp = PDCALogPath + "\\" + DateTime.Now.ToString("yyyy-MM-dd");
                if (Directory.Exists(temp))
                {
                    Process.Start(temp);
                    throw new Exception("跳转");
                }

                if (Directory.Exists(PDCALogPath))
                {
                    Process.Start(PDCALogPath);
                    throw new Exception("跳转");
                }

                if (Directory.Exists(LogPath))
                {
                    Process.Start(LogPath);
                }

                base.DialogResult = DialogResult.Yes;
            }
            catch
            {
                base.DialogResult = DialogResult.Yes;
            }
        }
        /// <summary>打开机台日志</summary>
        private void btnMachineLog_Click(object sender, EventArgs e)
        {
            try
            {
                MachineLog = SwManager.Instance.MachinePath;
                if (Directory.Exists(MachineLog))
                {
                    Process.Start(MachineLog);
                    throw new Exception("跳转");
                }

                if (Directory.Exists(LogPath))
                {
                    Process.Start(LogPath);
                }

                base.DialogResult = DialogResult.Yes;
            }
            catch
            {
                base.DialogResult = DialogResult.Yes;
            }
        }
        #endregion
    }
}
