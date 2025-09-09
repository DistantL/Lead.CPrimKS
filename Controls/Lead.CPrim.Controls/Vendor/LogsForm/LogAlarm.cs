/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: LogAlarm.cs
 * Author: Victor
 * Description: 报警UI
 * CreateTime: 2022-11-18
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.1124><Victor><20221124>
 * 1、初版1.0
******************************************************************************/

using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.Controls
{
    /// <summary>报警UI</summary>
    public partial class LogAlarm : UIPage
    {
        #region Define_Event
        /// <summary>清除报警时发生</summary>
        public event Action OnClrErr;
        #endregion



        #region Field
        /// <summary>任务日志对象</summary>
        private static LogAlarm _instance = new LogAlarm();
        #endregion



        #region Prop
        /// <summary>日志TabPages集合</summary>
        private readonly ConcurrentDictionary<string, DataGridView> _dgvs = new ConcurrentDictionary<string, DataGridView>();
        /// <summary>任务日志对象</summary>
        public static LogAlarm Instance { get => _instance; set => _instance = value; }
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public LogAlarm()
        {
            InitializeComponent();
        }
        #endregion



        #region System_Event
        /// <summary>Clsing事件</summary>
        private void DevLogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
        /// <summary>Load事件</summary>
        private void DevLogForm_Load(object sender, EventArgs e)
        {
            
        }
        #endregion



        #region Button_Event
        /// <summary>报警确认</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmAlarm_Click(object sender, EventArgs e)
        {
            rtbAlarm.SelectAll();
            rtbAlarm.SelectionBackColor = Color.Gray;
        }
        /// <summary>清除报警</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearAlarm_Click(object sender, EventArgs e)
        {
            OnClrErr?.Invoke();
            rtbAlarm.Text = "";
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>插入报警日志</summary>
        /// <param name="msg">报警内容</param>
        /// <param name="level">报警等级</param>
        public void ShowAlarm(string msg, LogLevel level)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string, LogLevel>(ShowAlarm), new object[2] { msg, level });
                return;
            }
            try
            {
                switch (level)
                {
                    case LogLevel.Info:
                        rtbAlarm.SelectionColor = Color.YellowGreen;
                        break;
                    case LogLevel.Warn:
                        rtbAlarm.SelectionColor = Color.LightCoral;
                        break;
                    case LogLevel.Fatal:
                    case LogLevel.Error:
                        rtbAlarm.SelectionColor = Color.Red;
                        break;
                    default:
                        rtbAlarm.SelectionColor = Color.LightCoral;
                        return;
                }
                rtbAlarm.AppendText($"{DateTime.Now:yyyyMMdd-HH:mm:ss.fff} - {level} - {msg}\r\n");
                rtbAlarm.ScrollToCaret();
            }
            catch
            {
            }
        }
        #endregion
    }
}
