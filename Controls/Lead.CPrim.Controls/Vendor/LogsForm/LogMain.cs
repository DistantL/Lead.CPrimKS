/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: LogMain.cs
 * Author: Victor
 * Description: 主页日志
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
using Lead.CPrim.StationCommon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.Controls
{
    /// <summary>主页日志</summary>
    public partial class LogMain : UIPage
    {
        #region Field
        /// <summary>日志增加锁</summary>
        private static readonly object obj = new object();

        /// <summary>任务日志对象</summary>
        private static LogMain _instance = new LogMain();

        private static TipForm tipForm = null;
        #endregion



        #region Prop
        public static LogMain Instance { get => _instance; set => _instance = value; }
        #endregion



        #region Ctor
        public LogMain()
        {
            InitializeComponent();

            switchSelect.Active = true;
            SelectAll(true);

            dgvInfo.SetStyle(false);
            if (dgvInfo.Rows.Count == 0)
            {
                dgvInfo.Rows.Add(DateTime.Now.ToString("yy/MM/dd-HH:mm:ss:fff"), LogLevel.Info, LogClassification.Other, "界面加载完成");
            }
            tlpLog.SetDoubleBuffered();

            OnLanguageChanged();
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
            SelectDefault();
        }

        /// <summary>每当Check属性更改时发生</summary>
        private void CheckedChanged(object sender, EventArgs e)
        {
            if (!IsHandleCreated || !Created)
            {
                return;
            }

            Action<bool, string> ac = (isShow, text) =>
            {
                for (int i = 0; i < dgvInfo.Rows.Count; i++)
                {
                    if (dgvInfo.Rows[i].Cells[1].Value.ToString() == text)
                    {
                        dgvInfo.Rows[i].Visible = isShow;
                    }
                }
            };
            this.BeginInvoke(ac, ((CheckBox)sender).Checked, ((CheckBox)sender).Text);
        }

        /// <summary>选择</summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void switchSelect_ValueChanged(object sender, bool value)
        {
            SelectAll(switchSelect.Active);
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>日志增加</summary>
        /// <param name="level"></param>
        /// <param name="time"></param>
        /// <param name="id"></param>
        /// <param name="mes"></param>
        public void LogAdd(LogLevel level, string time, string logClassification, string mes)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new Action<LogLevel, string, string, string>(LogAdd), level, time, logClassification, mes);
                    return;
                }

                lock (obj)
                {
                    dgvInfo.SuspendLayout();
                    switch (level)
                    {
                        case LogLevel.Fatal:
                            if (cbFatal.Checked)
                            {
                                dgvInfo.Rows.Insert(0, time, level.ToString(), logClassification, mes);
                                dgvInfo.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                            }
                            if (Flag_MonitorAlterInfo)
                            {
                                if (tipForm == null)
                                {
                                    tipForm = new TipForm();
                                    tipForm.SetTips(new List<TipSelectItem>() { new TipSelectItem() { TipName = "错误类别：" + logClassification, TipSelectItems_Level2 = null, TipShowInfo = mes } });
                                    tipForm.Show();
                                    tipForm.FormClosed += (x, y) => { tipForm = null; };
                                }
                            }
                            break;
                        case LogLevel.Error:
                            if (cbError.Checked)
                            {
                                dgvInfo.Rows.Insert(0, time, level.ToString(), logClassification, mes);
                                dgvInfo.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                            }
                            if (Flag_MonitorAlterInfo)
                            {
                                if (tipForm == null)
                                {
                                    tipForm = new TipForm();
                                    tipForm.SetTips(new List<TipSelectItem>() { new TipSelectItem() { TipName = "错误类别：" + logClassification, TipSelectItems_Level2 = null, TipShowInfo = mes } });
                                    tipForm.Show();
                                    tipForm.FormClosed += (x, y) => { tipForm = null; };
                                }
                            }
                            break;
                        case LogLevel.Warn:
                            if (cbWarn.Checked)
                            {
                                dgvInfo.Rows.Insert(0, time, level.ToString(), logClassification, mes);
                                dgvInfo.Rows[0].DefaultCellStyle.ForeColor = Color.DarkOrange;
                            }
                            if (Flag_MonitorAlterInfo)
                            {
                                if (tipForm == null)
                                {
                                    tipForm = new TipForm();
                                    tipForm.SetTips(new List<TipSelectItem>() { new TipSelectItem() { TipName = "错误类别：" + logClassification, TipSelectItems_Level2 = null, TipShowInfo = mes } });
                                    tipForm.Show();
                                    tipForm.FormClosed += (x, y) => { tipForm = null; };
                                }
                            }
                            break;
                        case LogLevel.Info:
                            if (cbInfo.Checked)
                            {
                                dgvInfo.Rows.Insert(0, time, level.ToString(), logClassification, mes);
                            }
                            break;
                        case LogLevel.Debug:
                            if (cbDebug.Checked)
                            {
                                dgvInfo.Rows.Insert(0, time, level.ToString(), logClassification, mes);
                            }
                            break;
                        case LogLevel.Trace:
                            if (cbTrace.Checked)
                            {
                                dgvInfo.Rows.Insert(0, time, level.ToString(), logClassification, mes);
                            }
                            break;
                        default:
                            if (cbOther.Checked)
                            {
                                dgvInfo.Rows.Insert(0, time, level.ToString(), logClassification, mes);
                            }
                            break;
                    }

                    if (dgvInfo.Rows.Count >= 200)
                    {
                        dgvInfo.Rows.RemoveAt(dgvInfo.Rows.Count - 1);
                    }
                    dgvInfo.ResumeLayout();
                }
            }
            catch (Exception ex)
            {
                ProxyTools.LogHelper.LogAdd(LogLevel.Warn, $"日志主页增加日志异常：{ex.Message}", PrimLogId.Tool.ToString());
            }
        }

        public bool Flag_MonitorAlterInfo { get; set; }
        #endregion



        #region Method_InternalUsing
        /// <summary>日志等级选择</summary>
        /// <param name="value">true：选择；false：不选择</param>
        private void SelectAll(bool value)
        {
            foreach (var item in tlpTitle.Controls)
            {
                if (item as CheckBox != null)
                {
                    ((CheckBox)item).Checked = value;
                }
            }
        }

        /// <summary>
        /// 默认值
        /// </summary>
        void SelectDefault()
        {
            cbFatal.Checked = true;
            cbError.Checked = true;
            cbWarn.Checked = true;
            cbInfo.Checked = false;
            cbDebug.Checked = false;
            cbTrace.Checked = false;
            cbOther.Checked = false;
        }
        #endregion

        public void OnLanguageChanged()
        {
            cbFatal.Text = NLocalizer.GetString("Lead_CPrim_Controls_LogMain_Fatal", "异常");
            cbError.Text = NLocalizer.GetString("Lead_CPrim_Controls_LogMain_Error", "错误");
            cbWarn.Text = NLocalizer.GetString("Lead_CPrim_Controls_LogMain_Warn", "警告");
            cbInfo.Text = NLocalizer.GetString("Lead_CPrim_Controls_LogMain_Info", "信息");
            cbDebug.Text = NLocalizer.GetString("Lead_CPrim_Controls_LogMain_Debug", "调试");
            cbTrace.Text = NLocalizer.GetString("Lead_CPrim_Controls_LogMain_Trace", "追踪");
            cbOther.Text = NLocalizer.GetString("Lead_CPrim_Controls_LogMain_Other", "其它");
            columnsTime.HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_LogMain_ColumnsTime", "时间");
            columnsLevel.HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_LogMain_ColumnsLevel", "级别");
            columnsLogClassification.HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_LogMain_ColumnsLogClassification", "分类");
            columnsMessage.HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_LogMain_ColumnsMessage", "信息");
        }
    }
}
