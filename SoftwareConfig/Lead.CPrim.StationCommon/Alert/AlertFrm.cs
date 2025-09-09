/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: AlertFrm.cs
 * Author: Victor
 * Description: Alert控件
 * CreateTime: 2022-11-18
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.23.0101><Victor><20230212>
 * 1、初版1.0
******************************************************************************/

using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.CustomControl;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lead.CPrim.StationCommon.Alert
{
    /// <summary>任务日志UI</summary>
    public partial class AlertFrm : UIPage
    {
        #region Define_Event

        /// <summary>
        /// 切DT时弹报警窗口发生
        /// </summary>
        public event Action OnBeforeDisplayAlertFrmDialog;


        /// <summary>
        /// 清除报警后发生
        /// </summary>
        public event Action<AlertInfo> OnAfterClrErrorInfo;

        #endregion



        #region Field
        /// <summary>任务日志对象</summary>
        private static AlertFrm _instance = new AlertFrm();

        /// <summary>当前报警信息</summary>
        private AlertInfo _currentAlertInfo = new AlertInfo();

        /// <summary>当前报警信息列表</summary>
        private List<AlertInfo> _currentListAlertInfos = new List<AlertInfo>();

        /// <summary>报警绑定数据源</summary>
        private BindingList<AlertInfo> _listAlertInfos = new BindingList<AlertInfo>();

        /// <summary>Top10</summary>
        AlertFrmChartPie frmPieChart;

        /// <summary>ErrorCode时间统计</summary>
        AlertFrmChartColumn frmBarChart;

        /// <summary>计算</summary>
        private double[] _calculation = new double[] { 0, 5, 10, 15, 20, 25 };

        #endregion



        #region Prop
        /// <summary>日志TabPages集合</summary>
        private readonly ConcurrentDictionary<string, DataGridView> _dgvs = new ConcurrentDictionary<string, DataGridView>();

        /// <summary>任务日志对象</summary>
        public static AlertFrm Instance { get => _instance; set => _instance = value; }
        #endregion



        #region Ctor
        private AlertFrm()
        {
            InitializeComponent();

            frmPieChart = new AlertFrmChartPie();
            frmPieChart.Dock = DockStyle.Fill;
            pnlAlertTop10.Controls.Add(frmPieChart);

            frmBarChart = new AlertFrmChartColumn();
            frmBarChart.Dock = DockStyle.Fill;
            pnlAlertTimeStatic.Controls.Add(frmBarChart);

            tlpAlert.BackColor = Color.FromArgb(236, 236, 236);
            lblStartTime.SetStyle();
            lblEndTime.SetStyle();
            btnQuery.SetStyle(ControlStyle.Light);
            btnSave.SetStyle(ControlStyle.Light);
            //btnQuery.SetStyle(Color.WhiteSmoke, Color.FromArgb(64, 64, 64));
            //btnSave.SetStyle(Color.WhiteSmoke, Color.FromArgb(64, 64, 64));
            pnlTitle.SetStyle();
            pnlAlertTop10.SetStyle(Color.FromArgb(211, 211, 211), default(Color));
            pnlAlertTimeStatic.SetStyle(Color.FromArgb(211, 211, 211), default(Color));
            pnlAlertData.SetStyle(Color.FromArgb(211, 211, 211), default(Color));
            lTitle.LineColor = Color.FromArgb(191, 191, 191);

            dgvAlertData.SetStyle(false, false, false, DataGridViewAutoSizeColumnsMode.None, DataGridViewContentAlignment.MiddleLeft, 9.0f, FontStyle.Regular, Color.FromArgb(211, 211, 211));

            dtpStartTime.Style = UIStyle.Gray;
            dtpEndTime.Style = UIStyle.Gray;

            AlertFrm_Load(null, null);

            AlarmManager.Instance.OnAlarm += ShowAudioAlarm;
            //AlarmManager.Instance.OnEarlyWarning += ShowAudioEarlyWarning;

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region System_Event
        /// <summary>Clsing事件</summary>
        private void AlertFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        /// <summary>Load事件</summary>
        private void AlertFrm_Load(object sender, EventArgs e)
        {
            dgvAlertData.DataSource = _listAlertInfos;
            dgvAlertData.ReadOnly = true;

            DateTime now = DateTime.Now;
            dtpStartTime.Value = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0).AddDays(-1);
            dtpEndTime.Value = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0).AddDays(1).AddSeconds(-1);

            UpdateChart(dtpStartTime.Value, dtpEndTime.Value, false);
        }

        /// <summary>格式化</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAlertData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgvAlertData.Rows)
            {
                if (row.Cells[3].Value.Equals("Ongoing"))
                {
                    row.Cells[2].Style = new DataGridViewCellStyle
                    {
                        Format = "",
                    };
                }
                else
                {
                    row.Cells[2].Style = new DataGridViewCellStyle
                    {
                        Format = "yyyy-MM-dd HH:mm:ss.fff"
                    };
                    row.Cells[1].Style = new DataGridViewCellStyle
                    {
                        Format = "yyyy-MM-dd HH:mm:ss.fff"
                    };
                }
            }
        }
        #endregion



        #region Button_Event
        /// <summary>查询</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            UpdateChart(dtpStartTime.Value, dtpEndTime.Value, true);
        }

        /// <summary>保存</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_listAlertInfos.Count <= 0)
            {
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.csv|*.CSV";
            DialogResult result = saveFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName,false))
                {
                    sw.WriteLine("序号,日期,开始时间,结束时间,持续时间,错误代码,错误信息,错误细节");
                    int i = 0;
                    foreach (var item in _listAlertInfos)
                    {
                        i++;
                        sw.Write(i.ToString());
                        sw.Write(',');
                        sw.Write(item.CreateTime.ToString("yyyy-MM-dd"));
                        sw.Write(',');
                        sw.Write(item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        sw.Write(',');
                        sw.Write(item.EndTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        sw.Write(',');
                        sw.Write(item.TimeInState);
                        sw.Write(',');
                        sw.Write(item.ErrorCode);
                        sw.Write(',');
                        sw.Write(item.ErrorMessage);
                        sw.Write(',');
                        sw.Write(item.ErrorDetail);
                        sw.WriteLine();
                    }
                }
            }
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// 插入报警(Audio)
        /// </summary>
        /// <param name="alarmInfo">报警数据</param>
        public void ShowAudioAlarm(AlarmInfo alarmInfo)
        {
            if (dgvAlertData.InvokeRequired)
            {
                dgvAlertData.BeginInvoke(new Action<AlarmInfo>(ShowAudioAlarm), new object[1] { alarmInfo });
                return;
            }

            try
            {
                _currentListAlertInfos.Clear();
                DateTime now = DateTime.Now;
                AlertInfo alertInfo = new AlertInfo
                {
                    Date = alarmInfo.LastTime,
                    CreateTime = alarmInfo.LastTime,
                    TimeInState = "Ongoing",
                    ErrorCode = alarmInfo.ErrorCode,
                    Severity = alarmInfo.ErrorLevelInEN,
                    ErrorMessage = alarmInfo.ErrorMessage,
                    ErrorDetail = alarmInfo.ErrorDetail,
                };

                _currentListAlertInfos.Add(alertInfo);
                _listAlertInfos.Insert(0, alertInfo);

                ShowAudioAlertDialog(_currentListAlertInfos);
                OnBeforeDisplayAlertFrmDialog?.Invoke();
            }
            catch (Exception ex)
            {
                StationManager.Instance.LogAdd("插入报警失败：" + ex.Message + ex.StackTrace, LogLevel.Warn);
            }
        }

        public void ShowAudioEarlyWarning(string info)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ShowAudioEarlyWarning), info);
                return;
            }
            try
            {
                OnBeforeDisplayAlertFrmDialog?.Invoke();
                //Application.OpenForms[0].Invoke((Action<string>)delegate
                //{
                //    AudioEarlyWarningFrmDialog frm = new AudioEarlyWarningFrmDialog
                //    {
                //        TopMost = true,
                //        ShowInTaskbar = false
                //    };
                //    frm.UpdateUI(info);
                //    frm.ShowDialog();
                //}, info);
                AudioEarlyWarningFrmDialog frm = new AudioEarlyWarningFrmDialog
                {
                    TopMost = true,
                    ShowInTaskbar = false,
                    StartPosition = FormStartPosition.WindowsDefaultLocation
                };
                frm.UpdateUI(info);
                frm.Show();
            }
            catch (Exception ex)
            {
                StationManager.Instance.LogAdd("插入报警失败：" + ex.Message + ex.StackTrace, LogLevel.Warn);
            }
        }

        public void ClearEventOnAfterClrErrorInfo()
        {
            if(OnAfterClrErrorInfo == null)
            {
                return;
            }
            foreach (var d in OnAfterClrErrorInfo.GetInvocationList()) OnAfterClrErrorInfo -= d as Action<AlertInfo>;
        }
        #endregion



        #region Method_Instance
        /// <summary> 
        /// 响应清除报警(Audio)
        /// </summary>
        private async void InstanceClrAudioErrAsync(bool enable, string errCode)
        {
            if (enable)
            {
                if (_currentListAlertInfos.Exists(p => p.ErrorCode == errCode))
                {
                    AlertInfo alertInfo = _currentListAlertInfos.Find(p => p.ErrorCode == errCode);
                    alertInfo.EndTime = DateTime.Now;
                    alertInfo.TimeInState = ((alertInfo.EndTime - alertInfo.CreateTime).TotalMinutes).ToString("f2");
                    _currentListAlertInfos.RemoveAll(p => p.ErrorCode == errCode);

                    await MongodbHelper.InsertOneAsync(alertInfo, UIGlobal.ErrorCodeDb);
                    OnAfterClrErrorInfo?.Invoke(alertInfo);
                }

                DateTime now = DateTime.Now;
                dtpStartTime.Value = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0).AddDays(-1);
                dtpEndTime.Value = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0).AddDays(1).AddSeconds(-1);

                UpdateChart(dtpStartTime.Value, dtpEndTime.Value, false);
            }
            else
            {
                ShowAudioAlertDialog(_currentListAlertInfos);
            }
        }

        #endregion



        #region Method_InternalUsing
        private void UpdateChart(DateTime start, DateTime end, bool isShowTips)
        {
            try
            {
                List<AlertInfo> alertInfos = new List<AlertInfo>();
                _listAlertInfos.Clear();

                List<DowntimeData> datas = new List<DowntimeData>();
                Dictionary<int, int> keyValues = new Dictionary<int, int>();
                frmPieChart.ChartClear();
                frmBarChart.ChartClear();

                for (int i = 0; i < 5; i++)
                {
                    keyValues.Add(i + 1, 0);
                }

                int ret = MongodbHelper.QueryManyByTime(start, end, out alertInfos, UIGlobal.ErrorCodeDb);
                //int ret = MongodbHelper.QueryManyByTime(end, start, out alertInfos, UIGlobal.ErrorCodeDb);
                if (ret != 0)
                {
                    throw new Exception("数据库查询出错");
                }

                if (alertInfos == null || alertInfos.Count <= 0)
                {
                    throw new Exception("当前时间段无数据");
                }

                alertInfos.Sort((a, b) => b.EndTime.CompareTo(a.EndTime));
                alertInfos.ForEach(p => _listAlertInfos.Add(p));
                foreach (var alert in alertInfos)
                {
                    int index = -1;
                    if (!double.TryParse(alert.TimeInState, out double value))
                    {
                        continue;
                    }

                    // 表格及扇形图数据
                    AlertHelper.AlertDataTotal(value, alert, ref datas);

                    // 柱状图数据
                    for (int i = _calculation.Length - 1; i >= 0; i--)
                    {
                        if (value >= _calculation[i])
                        {
                            index = i + 1;
                            break;
                        }
                    }

                    if (index != -1)
                    {
                        if (keyValues.ContainsKey(index))
                        {
                            keyValues[index]++;
                        }
                        else
                        {
                            keyValues.Add(index, 1);
                        }
                    }
                }

                frmPieChart.ChartControl(datas);
                foreach (var item in keyValues)
                {
                    frmBarChart.ChartControl(item.Key, item.Value);
                }
            }
            catch (Exception ex)
            {
                if (isShowTips)
                {
                    Notification.ShowError("查询出错：" + ex.Message);
                }
                else
                {
                    StationManager.Instance.LogAdd("Alert查询：" + ex.Message, LogLevel.Warn);
                }
            }
        }

        /// <summary>
        /// 显示Audio报警弹窗
        /// </summary>
        private void ShowAudioAlertDialog(List<AlertInfo> alertInfos)
        {
            if (alertInfos.Count > 0)
            {
                var frm = new AudioAlertFrmDialog();
                frm.Owner = this;
                frm.OnClrAudioErr += InstanceClrAudioErrAsync;
                frm.UpdateUI(alertInfos);
                frm.Show();
            }
        }
        #endregion

        public void OnLanguageChanged()
        {
            lblStartTime.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_Alert_AlertFrm_StartTime", "开始时间") + ":";
            lblEndTime.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_Alert_AlertFrm_EndTime", "结束时间") + ":";
            btnQuery.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_Alert_AlertFrm_Query", "查询");
            btnSave.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_Alert_AlertFrm_Save", "保存");
            date.HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_Alert_AlertFrm_Date", "日期");
            startTime.HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_Alert_AlertFrm_StartTime", "开始时间");
            endTime.HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_Alert_AlertFrm_EndTime", "结束时间");
            timeInState.HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_Alert_AlertFrm_TimeInState", "持续时间");
            errorCode.HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_Alert_AlertFrm_ErrorCode", "错误代码");
            errorDetail.HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_Alert_AlertFrm_ErrorDetail", "错误细节");
            errorMessage.HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_Alert_AlertFrm_ErrorMessage", "错误信息");
        }
    }
}
