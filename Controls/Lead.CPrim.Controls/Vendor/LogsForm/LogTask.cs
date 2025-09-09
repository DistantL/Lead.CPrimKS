/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: LogTask.cs
 * Author: Victor
 * Description: 任务日志
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
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.Controls
{
    /// <summary>任务日志</summary>
    public partial class LogTask : UIPage
    {
        #region Field
        /// <summary>TabControl控件1</summary>
        private TabControl tabControl1 = new TabControl();

        /// <summary>TabControl控件2</summary>
        private TabControl tabControl2 = new TabControl();

        /// <summary>TabControl控件3</summary>
        private TabControl tabControl3 = new TabControl();

        /// <summary>TabControl控件4</summary>
        private TabControl tabControl4 = new TabControl();

        /// <summary>日志增加锁</summary>
        private static readonly object obj = new object();

        /// <summary>日志标题</summary>
        private string[] _title = { "时间", "等级", "信息" };

        /// <summary>任务日志对象</summary>
        private static LogTask _instance = new LogTask();

        ///// <summary>日志TabPages集合</summary>
        //private readonly ConcurrentDictionary<string, DataGridView> _dgvs = new ConcurrentDictionary<string, DataGridView>();

        /// <summary>日志TabPages集合</summary>
        private readonly ConcurrentDictionary<string, UIDataGridView> _dgvs = new ConcurrentDictionary<string, UIDataGridView>();
        #endregion



        #region Prop
        /// <summary>任务日志对象</summary>
        public static LogTask Instance { get => _instance; set => _instance = value; }
        #endregion



        #region Ctor
        public LogTask()
        {
            InitializeComponent();

            tlpMain.SetDoubleBuffered();

            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region System_Event
        private void DevLogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void DevLogForm_Load(object sender, EventArgs e)
        {
            
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>更新日志</summary>
        /// <param name="tab">tab名称</param>
        /// <param name="msg">日志内容</param>
        /// <param name="level">日志等级</param>
        public void UpdateLog(string tab, string msg, LogLevel level)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string, string, LogLevel>(UpdateLog), new object[3] { tab, msg, level });
                return;
            }

            try
            {
                if (tabControl1.TabPages[tab] == null)
                {
                    AddDgv(tabControl1, tab);
                }

                DgvLogAdd(_dgvs[tab], tab, msg, level);
            }
            catch (Exception ex)
            {
                ProxyTools.LogHelper.LogAdd(LogLevel.Warn, $"任务日志 UpdateLog 增加日志异常：{ex.Message}", PrimLogId.Tool.ToString());
            }
        }

        /// <summary>分类更新日志</summary>
        /// <param name="tab">tab名称</param>
        /// <param name="msg">日志内容</param>
        /// <param name="type">日志UI归属</param>
        /// <param name="level">日志等级</param>
        public void UpdateLogType(string tab, string msg, LogType type, LogLevel level)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string, string, LogType, LogLevel>(UpdateLogType), new object[4] { tab, msg, type, level });
                return;
            }

            try
            {
                TabControl tabControl = new TabControl();
                switch (type)
                {
                    case LogType.A:
                        tabControl = tabControl1;
                        break;
                    case LogType.B:
                        tabControl = tabControl2;
                        break;
                    case LogType.C:
                        tabControl = tabControl3;
                        break;
                    case LogType.D:
                        tabControl = tabControl4;
                        break;
                    default:
                        return;
                }

                if (tabControl.TabPages[tab] == null)
                {
                    AddDgv(tabControl, tab);
                }

                DgvLogAdd(_dgvs[tab], tab, msg, level);
            }
            catch (Exception ex)
            {
                ProxyTools.LogHelper.LogAdd(LogLevel.Warn, $"任务日志 UpdateLogType 增加日志异常：{ex.Message}", PrimLogId.Tool.ToString());
            }
        }

        /// <summary>更新UI数量</summary>
        /// <param name="no">数量</param>
        public void UpdateLogUINo(int no)
        {
            try
            {
                if (no != 1 && no != 2 && no != 4) no = 1;
                tlpMain.Controls.Clear();
                switch (no)
                {
                    case 1:
                        tlpMain.RowCount = 1;
                        tlpMain.ColumnCount = 1;
                        tabControl1 = new TabControl()
                        {
                            Dock = DockStyle.Fill,
                            Font = new Font("微软雅黑", 12, FontStyle.Regular),
                        };
                        tlpMain.Controls.Add(tabControl1, 0, 0);
                        break;
                    case 2:
                        tlpMain.RowCount = 1;
                        tlpMain.ColumnCount = 2;
                        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                        tabControl1 = new TabControl()
                        {
                            Dock = DockStyle.Fill,
                            Font = new Font("微软雅黑", 12, FontStyle.Regular),
                        };
                        tabControl2 = new TabControl()
                        {
                            Dock = DockStyle.Fill,
                            Font = new Font("微软雅黑", 12, FontStyle.Regular),
                        };
                        tlpMain.Controls.Add(tabControl1, 0, 0);
                        tlpMain.Controls.Add(tabControl2, 1, 0);
                        break;
                    case 4:
                        tlpMain.RowCount = 2;
                        tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                        tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                        tlpMain.ColumnCount = 2;
                        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                        tabControl1 = new TabControl()
                        {
                            Dock = DockStyle.Fill,
                            Font = new Font("微软雅黑", 12, FontStyle.Regular),
                        };
                        tabControl2 = new TabControl()
                        {
                            Dock = DockStyle.Fill,
                            Font = new Font("微软雅黑", 12, FontStyle.Regular),
                        };
                        tabControl3 = new TabControl()
                        {
                            Dock = DockStyle.Fill,
                            Font = new Font("微软雅黑", 12, FontStyle.Regular),
                        };
                        tabControl4 = new TabControl()
                        {
                            Dock = DockStyle.Fill,
                            Font = new Font("微软雅黑", 12, FontStyle.Regular),
                        };
                        tlpMain.Controls.Add(tabControl1, 0, 0);
                        tlpMain.Controls.Add(tabControl2, 1, 0);
                        tlpMain.Controls.Add(tabControl3, 0, 1);
                        tlpMain.Controls.Add(tabControl4, 1, 1);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogAdd(LogLevel.Warn, $"更新UI数量异常：{ex.Message}", PrimLogId.Tool.ToString());
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>DataGridView增加日志</summary>
        /// <param name="dgv"></param>
        /// <param name="tab"></param>
        /// <param name="msg"></param>
        /// <param name="level"></param>
        private void DgvLogAdd(DataGridView dgv, string tab, string msg, LogLevel level)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<DataGridView, string, string, LogLevel>(DgvLogAdd), dgv, tab, msg, level);
                return;
            }

            lock (obj)
            {
                dgv.SuspendLayout();
                dgv.Rows.Insert(0, DateTime.Now.ToString("yyyyMMdd HH:mm:ss.fff"), level.ToString(), msg);

                if (level == LogLevel.Fatal || level == LogLevel.Error)
                {
                    dgv.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                }
                else if (level == LogLevel.Warn)
                {
                    dgv.Rows[0].DefaultCellStyle.ForeColor = Color.LightCoral;
                }
                else if (level == LogLevel.Debug || level == LogLevel.Trace)
                {
                    dgv.Rows[0].DefaultCellStyle.ForeColor = Color.Gray;
                }

                if (dgv.Rows.Count >= 150)
                {
                    dgv.Rows.RemoveAt(dgv.Rows.Count - 1);
                }
                dgv.ResumeLayout();
            }
        }

        /// <summary>增加DataGridView</summary>
        /// <param name="tab">TabPage</param>
        private void AddDgv(TabControl control, string tab)
        {
            control.TabPages.Add(tab, tab);

            UIDataGridView dgv = new UIDataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.SetStyle(true);
            _dgvs.TryAdd(tab, dgv);

            foreach (var item in _title)
            {
                _dgvs[tab].Columns.Add(item, item);
            }
            _dgvs[tab].Columns[0].Width = 200;
            _dgvs[tab].Columns[1].Width = 100;
            _dgvs[tab].Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            _dgvs[tab].SetDoubleBuffered();
            control.TabPages[tab].Controls.Add(_dgvs[tab]);
            OnLanguageChanged();
        }
        #endregion

        public void OnLanguageChanged()
        {
            foreach (var item in _dgvs)
            {
                foreach (DataGridViewColumn element in item.Value.Columns)
                {
                    switch (element.Name)
                    {
                        case "时间":
                            element.HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_LogTask_Time", "时间");
                            break;
                        case "等级":
                            element.HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_LogTask_Level", "等级");
                            break;
                        case "信息":
                            element.HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_LogTask_Information", "信息");
                            break;
                    }
                }

            }
        }
    }
}
