/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ShowOutputControl.cs
 * Author: Victor
 * Description: 显示基元输出界面
 * CreateTime: 2023-1-10
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.23.0101><Victor><20230110>
 * 1、初版1.0
******************************************************************************/

using Lead.CPrim.Controls;
using Lead.CPrim.FaiHelper;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lead.CPrim.ShowAudio.Controls
{
    /// <summary>
    /// 输出UI
    /// </summary>
    public partial class ShowOutputControl : UIUserControl
    {
        #region Field
        /// <summary>Audio主界面</summary>
        private readonly ShowAudio _show;

        /// <summary>最近10片CT</summary>
        private List<double> _lCt = new List<double>();

        /// <summary>Fai绑定至数据表</summary>
        private BindingList<FailBindDgv> _failBindDgvs = new BindingList<FailBindDgv>();

        /// <summary>统计界面</summary>
        private ProductInfoStatistics _statistics;

        /// <summary>天开始查询时间</summary>
        private DateTime _dayStart = DateTime.Now;

        /// <summary>天结束查询时间</summary>
        private DateTime _dayEnd = DateTime.Now;

        /// <summary>最长查询天数</summary>
        private int _maxDayQuery = 7;

        /// <summary>Machine State显示天数</summary>
        private int _dayShowCount = 7;

        List<DowntimeData> datas_error = new List<DowntimeData>();
        #endregion



        #region Ctor
        /// <summary>Ctor有1个参数</summary>
        /// <param name="show">AQCI管理器</param>
        public ShowOutputControl(ShowAudio show)
        {
            InitializeComponent();
            SetStyleFlags();
            _show = show;

            {
                dgvFai.SetStyle(false, false, false, DataGridViewAutoSizeColumnsMode.Fill, DataGridViewContentAlignment.MiddleCenter, 10.5f, FontStyle.Regular, Color.FromArgb(211, 211, 211));
                dgvFai.ScrollBarBackColor = Color.FromArgb(211, 211, 211);
                dgvFai.ScrollBarHandleWidth = 4;

                pnlTop10.SetStyle();
                pnlMachine.SetStyle();
                pnlStatistics.SetStyle(Color.FromArgb(211, 211, 211));
                pnlParam.SetStyle(Color.FromArgb(211, 211, 211));
                pnlInfo.SetStyle(Color.FromArgb(211, 211, 211));

                tlpMain.BackColor = Color.FromArgb(236, 236, 236);
                tlpRight.BackColor = Color.FromArgb(236, 236, 236);

                lblParam.SetStyle();
            }

            tlpRight.SetDoubleBuffered();
            tlpMain.SetDoubleBuffered();

            {
                _statistics = ProductInfoStatistics.GetInstance(1);
                _statistics.TopLevel = false;
                _statistics.TopMost = false;
                _statistics.Dock = DockStyle.Fill;
                _statistics.Visible = true;
                _statistics.Show();
                pnlStatistics.Controls.Add(_statistics);
                _statistics.doubleClick += _statistics_DoubleClick;
            }

            {
                var frm = SoftWareInfo.Instance;
                frm.TopMost = false;
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.Show();
                pnlInfo.Controls.Add(frm);
            }

            {
                btnConnect.FillColor = Color.FromArgb(211, 211, 211);
                btnConnect.SymbolColor = Color.Gray;
                btnConnect.RectColor = Color.FromArgb(211, 211, 211);
                lblSensor.SetStyle();
                lblSensor.Visible = false;
                btnConnect.Visible = false;

                pnlSensor.SetStyle(Color.FromArgb(211, 211, 211));
                dtpDayStart.SetStyle(Color.FromArgb(211, 211, 211));
                dtpDayEnd.SetStyle(Color.FromArgb(211, 211, 211));
                hsbDay.Style = UIStyle.Gray;
            }
        }

        private void _statistics_DoubleClick()
        {
            ProxyData.Instance.SkipUI("BtnData");
        }
        #endregion



        #region System_Event
        private void ShowOutputControl_Load(object sender, EventArgs e)
        {
            ChangeFaiByName(_show.CurrentFAIName);
            hsbDay.Maximum = _maxDayQuery - 1;

            tmrMachineState_Tick(null, null);
            tmrMachineState.Start();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
            AuthorityManager.OnUpdateLevel += InstanceUpdateLevel;
            AuthorityManager.OnUpdateLevelOther += InstanceUpdateLevel;
        }

        public void ChangeFaiByName(string faiName)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ChangeFaiByName),
                    new object[1] { faiName });
            }
            else
            {
                _show.CurrentFAIName = faiName;

                if (_failBindDgvs == null)
                {
                    _failBindDgvs = new BindingList<FailBindDgv>();
                }
                _failBindDgvs.Clear();
                if (!string.IsNullOrEmpty(_show.CurrentFAIName) && FaiManager.Instance.Products.ContainsKey(SwManager.Instance.CurrentProduct))
                {
                    foreach (var item in FaiManager.Instance.Products[SwManager.Instance.CurrentProduct].SimpleConfigs.Values.FirstOrDefault(fai => fai.Name == _show.CurrentFAIName).FaiConfigs.Values.OrderBy(config => config.Index))
                    {
                        if (item.Enable)
                        {
                            _failBindDgvs.Add(new FailBindDgv { KeyName = item.Name, Value = string.Empty, LSL = item.TolLow, USL = item.TolUp });
                        }
                    }
                }
                //dgvFai.Columns["KeyName"].Width = 300;
                dgvFai.DataSource = _failBindDgvs;
                dgvFai.ReadOnly = true;
                dgvFai.Refresh();
            }
        }

        /// <summary>DataGridView格式设置</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFai_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dgvFai.Rows == null || dgvFai.Rows.Count == 0 || e.Value == null)
                {
                    return;
                }
                e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;

                switch (dgvFai.Columns[e.ColumnIndex].Name)
                {
                    case "Value":
                        if (string.IsNullOrWhiteSpace(e.Value.ToString()))
                        {
                            return;
                        }
                        double value = double.Parse(e.Value.ToString());
                        double LSL = double.Parse(dgvFai.Rows[e.RowIndex].Cells["LSL"].Value.ToString());
                        double USL = double.Parse(dgvFai.Rows[e.RowIndex].Cells["USL"].Value.ToString());
                        if (LSL > value || USL < value)
                        {
                            e.CellStyle.BackColor = e.CellStyle.SelectionBackColor = Color.FromArgb(236, 93, 87);
                        }
                        break;
                    case "LSL":
                    case "USL":
                        value = double.Parse(e.Value.ToString());
                        if (value > 998 || value < -998)
                        {
                            e.Value = "#";
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>日查询</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hsbDay_ValueChanged(object sender, EventArgs e)
        {
            int value = hsbDay.Maximum - hsbDay.Value + 1;
            dtpDayStart.Value = _dayStart = dtpDayEnd.Value.AddDays(-value).AddMilliseconds(2);

            this.BeginInvoke(new Action<DateTime, DateTime>(ChangeChart), _dayStart, _dayEnd);
        }
        #endregion



        #region Event_Button
        /// <summary>
        /// Sensor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            ProxyData.Instance.ShowSensor();
        }

        private void chartTop10_DoubleClick(object sender, EventArgs e)
        {
            ProxyData.Instance.SkipUI("BtnAlert");
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>添加数据</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listEntiy"></param>
        /// <param name="saveDataBase"></param>
        /// <param name="productName"></param>
        /// <param name="results"></param>
        internal void AddMultiPartInfo<T>(List<T> listEntiy, bool saveDataBase, string productName, Dictionary<string, bool> results = null) where T : class
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<List<T>, bool, string, Dictionary<string, bool>>(AddMultiPartInfo),
                    new object[4] { listEntiy, saveDataBase, productName, results });
            }
            else
            {
                if (listEntiy == null || listEntiy.Count <= 0)
                {
                    return;
                }

                if (_show.StationName != null)
                {
                    if (productName.IsNullOrEmpty())
                    {
                        productName = "parts";
                    }

                    productName = $"{_show.StationName}_{productName}";
                }

                //写入数据库
                if (saveDataBase)
                {
                    if (listEntiy.Count > 1)
                    {
                        _ = MongodbHelper.InsertManyAsync(listEntiy, productName);
                    }
                    else
                    {
                        _ = MongodbHelper.InsertOneAsync(listEntiy[0], productName);
                    }
                }

                var propInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                if (propInfo == null || propInfo.Length <= 0)
                {
                    return;
                }
                var propertyCreateTime = typeof(T).GetProperty("CreateTime");
                var propertyID = typeof(T).GetProperty("Sn");
                var propertyResult = typeof(T).GetProperty("Result");
                var propertyCt = typeof(T).GetProperty("CT");

                var dicColName = DataHelper.GetDataTableColumns(listEntiy, ref propInfo);

                foreach (var item in listEntiy)
                {
                    try
                    {
                        var values = DataHelper.GetDataTableRowValue(item, propInfo, dicColName);
                        string id = propertyID == null ? string.Empty : propertyID.GetValue(item).ToString();
                        _show.NumCount++;
                        if (propertyResult != null)
                        {
                            if (propertyResult.GetValue(item).ToString().ToLower() == "ok" || propertyResult.GetValue(item).ToString() == "1")
                            {
                                _show.NumOk++;
                            }
                            else
                            {
                                _show.NumNg++;
                            }
                        }
                        else
                        {
                            _show.NumOk++;
                        }

                        if (propertyCt != null && double.TryParse(propertyCt.GetValue(item).ToString(), out var retCt))
                        {
                            if (_lCt.Count > 10)
                            {
                                _lCt.RemoveAt(0);
                            }
                            _lCt.Add(retCt);
                        }
                        UpdateFai(dicColName, values);
                    }
                    catch (Exception ex)
                    {
                        _show.LogAdd($"添加数据失败:{ex.Message}", LogLevel.Trace);
                    }
                }
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>响应权限等级改变</summary>
        /// <param name="level"></param>
        private void InstanceUpdateLevel(OpLevel level)
        {
            SetEnable(AuthorityManager.Instance.VerifyLevel1Permission());
        }

        private void SetEnable(bool enable)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetEnable), enable);
                return;
            }

            lblSensor.Visible = enable;
            btnConnect.Visible = enable;
        }

        /// <summary>FAI项进行更新</summary>
        /// <param name="colName"></param>
        /// <param name="value"></param>
        private void UpdateFai(Dictionary<int, string> colName, object[] value)
        {
            if (colName == null || colName.Count <= 0)
            {
                return;
            }

            if (value == null || value.Length <= 0)
            {
                return;
            }

            if (_failBindDgvs == null || _failBindDgvs.Count <= 0)
            {
                return;
            }

            foreach (var bind in _failBindDgvs)
            {
                foreach (var col in colName)
                {
                    if (col.Value.Contains(bind.KeyName))
                    {
                        bind.Value = value[col.Key].ToString();
                        break;
                    }
                }
            }
            dgvFai.Refresh();
        }

        /// <summary>
        /// Machine State刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrMachineState_Tick(object sender, EventArgs e)
        {
            if (!ServiceHelper.MongoDBServiceIsRunning())
            {
                return;
            }

            if (!hsbDay.IsPress)
            {
                hsbDay.Value = 6;
                dtpDayEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(1).AddMilliseconds(-1);
                dtpDayStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(1).AddDays(-hsbDay.Maximum);
                hsbDay_ValueChanged(null, null);
            }

            try
            {
                //所有数据
                List<StateInfo> stateInfos = new List<StateInfo>();
                //7天数据
                List<StateInfo>[] states = new List<StateInfo>[_dayShowCount];
                //7天时间
                DateTime[] times = new DateTime[_dayShowCount];

                //当前时间
                DateTime currentTime = DateTime.Now;

                //最后一天0点
                DateTime endTmp = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 0, 0, 0);

                for (int i = 0; i < _dayShowCount; i++)
                {
                    times[i] = endTmp.AddDays(-_dayShowCount + 1 + i);
                }

                string db = SwManager.Instance.MasterControl == MasterControlEnum.PC.ToString() ? UIGlobal.StateMachinePcDb : UIGlobal.StateMachinePlcDb;
                int ret = MongodbHelper.QueryManyByTime(times[0], currentTime, out stateInfos, db);
                if (ret != 0 || !stateInfos.IsValid())
                {
                    return;
                }

                for (int i = 0; i < states.Length; i++)
                {
                    states[i] = new List<StateInfo>();
                }

                DateTime pStart;
                DateTime pEnd;
                //i：数据集合
                for (int i = stateInfos.Count - 1; i >= 0; i--)
                {
                    //多个数据
                    if (i > 0)
                    {
                        //j:某一个数据位于哪一天
                        for (int j = times.Length - 1; j >= 0; j--)
                        {
                            if (stateInfos[i].CreateTime >= times[j])
                            {
                                pStart = stateInfos[i].CreateTime;
                                //最后一天
                                if (j == times.Length - 1)
                                {
                                    pEnd = stateInfos[i - 1].CreateTime;
                                    StateInfo hive = new StateInfo
                                    {
                                        CreateTime = pStart,
                                        Status = stateInfos[i].ChangeToStatus,
                                        Duration = (pEnd - pStart).TotalMinutes,
                                    };
                                    states[j].Add(hive);
                                    break;
                                }
                                else
                                {
                                    //k：某一个的下一个数据位于哪一天
                                    for (int k = j + 1; k < times.Length; k++)
                                    {
                                        if (stateInfos[i - 1].CreateTime > times[k])
                                        {
                                            pEnd = times[k];
                                            StateInfo hive = new StateInfo
                                            {
                                                CreateTime = pStart,
                                                Status = stateInfos[i].ChangeToStatus,
                                                Duration = (pEnd - pStart).TotalMinutes,
                                            };
                                            states[k - 1].Add(hive);
                                            pStart = pEnd;

                                            if (k == times.Length - 1)
                                            {
                                                pEnd = stateInfos[i - 1].CreateTime;
                                                hive = new StateInfo
                                                {
                                                    CreateTime = pStart,
                                                    Status = stateInfos[i].ChangeToStatus,
                                                    Duration = (pEnd - pStart).TotalMinutes,
                                                };
                                                states[k].Add(hive);
                                            }
                                        }
                                        else
                                        {
                                            pEnd = stateInfos[i - 1].CreateTime;
                                            StateInfo hive = new StateInfo
                                            {
                                                CreateTime = pStart,
                                                Status = stateInfos[i].ChangeToStatus,
                                                Duration = (pEnd - pStart).TotalMinutes,
                                            };
                                            states[k - 1].Add(hive);
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    //一个数据
                    else
                    {
                        //j:某一个数据位于哪一天
                        for (int j = times.Length - 1; j >= 0; j--)
                        {
                            if (stateInfos[0].CreateTime >= times[j])
                            {
                                pStart = stateInfos[0].CreateTime;
                                //最后一天
                                if (j == times.Length - 1)
                                {
                                    pEnd = currentTime;
                                    StateInfo hive = new StateInfo
                                    {
                                        CreateTime = pStart,
                                        Status = stateInfos[0].ChangeToStatus,
                                        Duration = (pEnd - pStart).TotalMinutes,
                                    };
                                    states[j].Add(hive);
                                    break;
                                }
                                else
                                {
                                    //k：某一个的下一个数据位于哪一天
                                    for (int k = j + 1; k < times.Length; k++)
                                    {
                                        if (currentTime > times[k])
                                        {
                                            pEnd = times[k];
                                            StateInfo hive = new StateInfo
                                            {
                                                CreateTime = pStart,
                                                Status = stateInfos[0].ChangeToStatus,
                                                Duration = (pEnd - pStart).TotalMinutes,
                                            };
                                            states[k - 1].Add(hive);
                                            pStart = pEnd;

                                            if (k == times.Length - 1)
                                            {
                                                pEnd = currentTime;
                                                hive = new StateInfo
                                                {
                                                    CreateTime = pStart,
                                                    Status = stateInfos[0].ChangeToStatus,
                                                    Duration = (pEnd - pStart).TotalMinutes,
                                                };
                                                states[k].Add(hive);
                                            }
                                        }
                                        else
                                        {
                                            pEnd = currentTime;
                                            StateInfo hive = new StateInfo
                                            {
                                                CreateTime = pStart,
                                                Status = stateInfos[0].ChangeToStatus,
                                                Duration = (pEnd - pStart).TotalMinutes,
                                            };
                                            states[k - 1].Add(hive);
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

                List<ChartDatas> datas = new List<ChartDatas>()
                {
                    new ChartDatas
                    {
                        Name = HiveStatus.Running.ToString(),
                        ChartColor = ColorTranslator.FromHtml("#D3EB73"),
                        ChartType = SeriesChartType.StackedColumn
                    },
                    new ChartDatas
                    {
                        Name = HiveStatus.Idle.ToString(),
                        ChartColor = ColorTranslator.FromHtml("#EBFFFE"),
                        ChartType = SeriesChartType.StackedColumn
                    },
                    new ChartDatas
                    {
                        Name = HiveStatus.Engineering.ToString(),
                        ChartColor = ColorTranslator.FromHtml("#CCABD8"),
                        ChartType = SeriesChartType.StackedColumn
                    },
                    new ChartDatas
                    {
                        Name = "Planned Downtime",
                        ChartColor = ColorTranslator.FromHtml("#FFD7D4"),
                        ChartType = SeriesChartType.StackedColumn
                    },
                    new ChartDatas
                    {
                        Name = "Downtime",
                        ChartColor = ColorTranslator.FromHtml("#EB7373"),
                        ChartType = SeriesChartType.StackedColumn
                    },
                };
                CustomChart.InitChart(ref chartMachineState, datas, endTmp.AddDays(1), times[0].AddDays(-1), 1, DateTimeIntervalType.Days, "MM/dd", "Machine State Changes (7D)", false, "", "", "P0");

                for (int i = 0; i < states.Length; i++)
                {
                    if (states[i] == null)
                    {
                        continue;
                    }

                    double running = states[i].FindAll(info => info.Status == HiveStatus.Running).ToList().Sum(info => info.Duration) / 1440;
                    double idle = states[i].FindAll(info => info.Status == HiveStatus.Idle).ToList().Sum(info => info.Duration) / 1440;
                    double engineering = states[i].FindAll(info => info.Status == HiveStatus.Engineering).ToList().Sum(info => info.Duration) / 1440;
                    double planDt = states[i].FindAll(info => info.Status == HiveStatus.Plan_DT).ToList().Sum(info => info.Duration) / 1440;
                    double dt = states[i].FindAll(info => info.Status == HiveStatus.DT).ToList().Sum(info => info.Duration) / 1440;

                    chartMachineState.Series[0].Points.AddXY(times[i], running);
                    chartMachineState.Series[1].Points.AddXY(times[i], idle);
                    chartMachineState.Series[2].Points.AddXY(times[i], engineering);
                    chartMachineState.Series[3].Points.AddXY(times[i], planDt);
                    chartMachineState.Series[4].Points.AddXY(times[i], dt);

                    chartMachineState.Series[0].Points.Last().IsValueShownAsLabel = running > 0.05;
                    chartMachineState.Series[1].Points.Last().IsValueShownAsLabel = idle > 0.05;
                    chartMachineState.Series[2].Points.Last().IsValueShownAsLabel = engineering > 0.05;
                    chartMachineState.Series[3].Points.Last().IsValueShownAsLabel = planDt > 0.05;
                    chartMachineState.Series[4].Points.Last().IsValueShownAsLabel = dt > 0.05;

                    chartMachineState.Series.ToList().ForEach(p =>
                    {
                        p.Points[p.Points.Count - 1].ToolTip =
                        $"Time -> {times[i]: yyyy-MM-dd}\n" +
                        $"Dt -> \t\tRate：{dt:P2}\tMinute：{dt * 1440:f2}\n" +
                        $"PlanDt -> \tRate：{planDt:P2}\tMinute：{planDt * 1440:f2}\n" +
                        $"Engineering -> \tRate：{engineering:P2}\tMinute：{engineering * 1440:f2}\n" +
                        $"Idle -> \t\tRate：{idle:P2}\tMinute：{idle * 1440:f2}\n" +
                        $"Running -> \tRate：{running:P2}\tMinute：{running * 1440:f2}";
                    });
                }
            }
            catch (Exception ex)
            {
                _show.LogAdd($"MachineState刷新失败:{ex.Message}", LogLevel.Debug);
            }
        }

        public string ConvertToHHmm(double min)
        {
            if (min < 59)
            {
                return min.ToString("f0") + NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_Minute", "分");
            }
            else
            {
                return Math.Floor(min / 60).ToString("f0")
                    + NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_Hour", "时")
                    + (min % 60).ToString("f0")
                    + NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_Minute", "分");
            }
        }

        private int MaxDays_InDB = 28;

        private void dtpDayStart_OnComfirmOK()
        {
            DateTime maxTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).Subtract(TimeSpan.FromDays(MaxDays_InDB));
            if (dtpDayStart.Value < maxTime)
            {
                string str = NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_SettingStartTimeErrorTipInfo1", "设置的开始时间超过最大追溯时间[{0}]，设置失败！");
                MessageBox.Show(string.Format(str, maxTime));
                dtpDayStart.Value = _dayStart;
            }
            else if (dtpDayStart.Value < _dayEnd)
            {
                _dayStart = dtpDayStart.Value;
                hsbDay.Maximum = (_dayEnd - _dayStart).Days - 1;
                this.BeginInvoke(new Action<DateTime, DateTime>(ChangeChart), _dayStart, _dayEnd);
            }
            else
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_SettingStartTimeErrorTipInfo2", "设置的开始时间大于或等于结束时间，设置失败！"));
                dtpDayStart.Value = _dayStart;
            }
        }

        private void dtpDayStart_DropDownClosed(object sender, EventArgs e)
        {
            dtpDayStart.Value = _dayStart;
        }

        private void dtpDayEnd_OnComfirmOK()
        {
            DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, 0, 0, 0);
            if (dtpDayEnd.Value > time)
            {
                dtpDayEnd.Value = _dayEnd = time;
            }
            else if (dtpDayEnd.Value > _dayStart)
            {
                _dayEnd = dtpDayEnd.Value;
                hsbDay.Maximum = (_dayEnd - _dayStart).Days - 1;
                this.BeginInvoke(new Action<DateTime, DateTime>(ChangeChart), _dayStart, _dayEnd);
            }
            else
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_SettingEndTimeErrorTipInfo", "设置的结束时间小于或等于开始时间，设置失败！"));
                dtpDayEnd.Value = _dayEnd;
            }
        }

        private void dtpDayEnd_DropDownClosed(object sender, EventArgs e)
        {
            dtpDayEnd.Value = _dayEnd;
        }

        private void ChangeChart(DateTime startTime, DateTime endTime)
        {
            try
            {
                List<ChartDatas> series = new List<ChartDatas>();
                List<string> axisX = new List<string>();
                CustomChart.InitChart(ref chartTop10, series, axisX.ToArray(), NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_MachineErrorStatistics", "设备报警统计 (前10)"), false, "", "", "0");

                List<AlertInfo> alertInfos = new List<AlertInfo>();
                int ret = MongodbHelper.QueryManyByTime(startTime, endTime, out alertInfos, UIGlobal.ErrorCodeDb);
                if (ret != 0 || alertInfos == null || alertInfos.Count <= 0)
                {
                    return;
                }

                List<DowntimeData> datas = new List<DowntimeData>();
                foreach (AlertInfo alertInfo in alertInfos)
                {
                    if (!double.TryParse(alertInfo.TimeInState, out double time))
                    {
                        continue;
                    }

                    StationCommon.Alert.AlertHelper.AlertDataTotal(time, alertInfo, ref datas);
                }

                series.Clear();
                series.Add(new ChartDatas
                {
                    Name = "Top10",
                    ChartColor = Color.FromArgb(229, 94, 86),
                    ChartType = SeriesChartType.Bar,
                });

                axisX.Clear();
                Dictionary<string, DowntimeData> dic = new Dictionary<string, DowntimeData>();
                //var datas_error = datas.OrderBy(time => time.CountTotal);
                var datas_error = datas.OrderBy(time => time.TotalTime);
                for (int i = 0; i < 10 - datas_error.Count(); i++)
                {
                    axisX.Add("");
                }

                foreach (var item in datas_error)
                {
                    item.Error = NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_" + item.Error, item.Error);
                    axisX.Add(item.Error);
                    //dic.Add(item.Error, item.CountTotal);
                    dic.Add(item.Error, item);
                }
                CustomChart.InitChart(ref chartTop10, series, axisX.ToArray(), NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_MachineErrorStatistics", "设备报警统计 (前10)"), false, "", "", "0");
                for (int i = 0; i < 10 - datas_error.Count(); i++)
                {
                    chartTop10.Series[0].Points.AddXY("", 0);
                    chartTop10.Series[0].Points.Last().IsEmpty = true;
                }
                foreach (var item in dic)
                {
                    chartTop10.Series[0].Points.AddXY(item.Key, item.Value.TotalTime);

                    string str = "时间:         {0}   \n错误类型:     {1}   \n总时间:       {2} 分\n总次数:       {3}   \n平均时间:     {4} 分\n";
                    str = NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_MachineErrorStatistatics_ToolTip", str).Replace("\\t", "\t");
                    chartTop10.Series[0].Points.Last().ToolTip = string.Format(str, _dayStart.ToString("yyyy-MM-dd")
                        , item.Value.Error
                        , item.Value.TotalTime
                        , item.Value.CountTotal
                        , Math.Round(item.Value.TotalTime / (item.Value.CountTotal != 0 ? item.Value.CountTotal : 1), 2));
                }
                chartTop10.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
                chartTop10.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
                chartTop10.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chartTop10.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            }
            catch (Exception ex)
            {
                _show.LogAdd($"MachineError刷新失败：{ex.Message}", LogLevel.Warn);
            }
        }

        public void OnLanguageChanged()
        {
            lblSensor.Text = NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_SensorConnection", "传感器连接");
            lblParam.Text = NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_CriticalParamDashboard", "关键参数看板");
            dgvFai.Columns["KeyName"].HeaderText = NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_KeyName", "名称");
            dgvFai.Columns["Value"].HeaderText = NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_Value", "值");
            dgvFai.Columns["LSL"].HeaderText = NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_LSL", "下限");
            dgvFai.Columns["USL"].HeaderText = NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_USL", "上限");

            chartTop10.Titles[0].Text = NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_MachineErrorStatistics", "设备报警统计 (前10)");
            chartMachineState.Titles[0].Text = NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_MachineStateStatistics", "设备状态统计 (7天)");
            if (chartTop10.IsHandleCreated)
            {
                chartTop10.BeginInvoke(new Action<DateTime, DateTime>(ChangeChart), _dayStart, _dayEnd);
            }
        }

        private void tsmi_Export_Click(object sender, EventArgs e)
        {
            if (datas_error != null && datas_error.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "*.csv|*.csv";

                DialogResult dialogResult = saveFileDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false))
                    {
                        sw.WriteLine("错误类型,总时间,总次数,平均时间,报警信息");

                        datas_error.Reverse();
                        foreach (var item in datas_error)
                        {
                            sw.Write(item.Error);
                            sw.Write(',');
                            sw.Write(item.TotalTime);
                            sw.Write(',');
                            sw.Write(item.CountTotal);
                            sw.Write(',');
                            sw.Write(Math.Round(item.TotalTime / (item.CountTotal != 0 ? item.CountTotal : 1), 2));
                            sw.Write(',');
                            sw.Write(item.ErrorDetail);
                            sw.WriteLine(',');
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("数据为空，请重新设置时间或右键点击[细节]重新刷新");
            }
        }

        private void tsmi_ErrorStatisticsDetail_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startTime = dtpDayStart.Value;
                DateTime endTime = dtpDayEnd.Value;

                List<ChartDatas> series = new List<ChartDatas>();
                List<string> axisX = new List<string>();
                CustomChart.InitChart(ref chartTop10, series, axisX.ToArray(), NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_MachineErrorStatistics", "设备报警统计 (前10)"), false, "", "", "0");

                List<AlertInfo> alertInfos = new List<AlertInfo>();
                int ret = MongodbHelper.QueryManyByTime(startTime, endTime, out alertInfos, UIGlobal.ErrorCodeDb);
                if (ret != 0 || alertInfos == null || alertInfos.Count <= 0)
                {
                    return;
                }

                StationCommon.Alert.AlertHelper.AlertDataTotalDetail(alertInfos, ref datas_error);

                series.Clear();
                series.Add(new ChartDatas
                {
                    Name = "Top10",
                    ChartColor = Color.FromArgb(229, 94, 86),
                    ChartType = SeriesChartType.Bar,
                });

                axisX.Clear();
                Dictionary<string, DowntimeData> dic = new Dictionary<string, DowntimeData>();
                for (int i = 0; i < 10 - datas_error.Count(); i++)
                {
                    axisX.Add("");
                }

                foreach (var item in datas_error)
                {
                    item.Error = NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_" + item.Error, item.Error);
                    axisX.Add(item.Error);
                    //dic.Add(item.Error, item.CountTotal);
                    dic.Add(item.Error, item);
                }
                CustomChart.InitChart(ref chartTop10, series, axisX.ToArray(), NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_MachineErrorStatistics", "设备报警统计 (前10)"), false, "", "", "0");
                for (int i = 0; i < 10 - datas_error.Count(); i++)
                {
                    chartTop10.Series[0].Points.AddXY("", 0);
                    chartTop10.Series[0].Points.Last().IsEmpty = true;
                }
                foreach (var item in dic)
                {
                    chartTop10.Series[0].Points.AddXY(item.Key, Math.Round(item.Value.TotalTime, 2));

                    string str = "时间:         {0}   \n错误类型:     {1}   \n总时间:       {2} 分\n总次数:       {3}   \n平均时间:     {4} 分\n";
                    str = NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_MachineErrorStatistatics_ToolTip_detail", str).Replace("\\t", "\t");
                    chartTop10.Series[0].Points.Last().ToolTip = string.Format(str, _dayStart.ToString("yyyy-MM-dd")
                        , "(" + item.Value.Error + ") " + item.Value.ErrorDetail
                        , Math.Round(item.Value.TotalTime, 2)
                        , item.Value.CountTotal
                        , Math.Round(item.Value.TotalTime / (item.Value.CountTotal != 0 ? item.Value.CountTotal : 1), 2));
                }
                chartTop10.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
                chartTop10.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
                chartTop10.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chartTop10.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            }
            catch (Exception ex)
            {
                _show.LogAdd($"MachineError刷新失败：{ex.Message}", LogLevel.Warn);
            }
        }
        ///// <summary>
        ///// Machine State刷新
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void tmrMachineState_Tick(object sender, EventArgs e)
        //{
        //    if (!ServiceHelper.MongoDBServiceIsRunning())
        //    {
        //        return;
        //    }

        //    if (!hsbDay.IsPress)
        //    {
        //        hsbDay.Value = 6;
        //        dtpDayEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(1).AddMilliseconds(-1);
        //        dtpDayStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(1).AddDays(-hsbDay.Maximum);
        //        hsbDay_ValueChanged(null, null);
        //    }

        //    try
        //    {
        //        //所有数据
        //        List<StateInfo> stateInfos = new List<StateInfo>();
        //        //7天数据
        //        List<StateInfo>[] states = new List<StateInfo>[_dayShowCount];
        //        //7天时间
        //        DateTime[] times = new DateTime[_dayShowCount];
        //        //结束时间
        //        DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(1);
        //        //结束时间取0点
        //        DateTime endTmp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        //        for (int i = 0; i < _dayShowCount; i++)
        //        {
        //            times[i] = endTmp.AddDays(-_dayShowCount + 1 + i);
        //        }

        //        string db = SwManager.Instance.MasterControl == MasterControlEnum.PC.ToString() ? UIGlobal.StateMachinePcDb : UIGlobal.StateMachinePlcDb;
        //        int ret = MongodbHelper.QueryManyByTime(times[0], end, out stateInfos, db);
        //        if (ret != 0 || stateInfos == null || stateInfos.Count == 0)
        //        {
        //            return;
        //        }

        //        for (int i = 0; i < stateInfos.Count; i++)
        //        {
        //            for (int j = times.Length - 1; j >= 0; j--)
        //            {
        //                if (stateInfos[i].CreateTime >= times[j])
        //                {
        //                    if (states[j] == null)
        //                    {
        //                        states[j] = new List<StateInfo>();
        //                    }

        //                    if ((stateInfos[i].CreateTime - times[j]).TotalMinutes >= stateInfos[i].Duration)
        //                    {
        //                        states[j].Add(stateInfos[i]);
        //                    }
        //                    else
        //                    {
        //                        var item = new StateInfo(stateInfos[i]);
        //                        for (int k = j; k >= 0; k--)
        //                        {
        //                            var duration = item.Duration;

        //                            if (item.Duration > (item.CreateTime - times[k]).TotalMinutes)
        //                            {
        //                                item.Duration = (item.CreateTime - times[k]).TotalMinutes;
        //                            }
        //                            if (states[k] == null)
        //                            {
        //                                states[k] = new List<StateInfo>();
        //                            }
        //                            states[k].Add(item);

        //                            item = new StateInfo(item);
        //                            item.Duration = duration - item.Duration;
        //                            item.CreateTime = times[k];

        //                            if (item.Duration <= 0)
        //                            {
        //                                break;
        //                            }
        //                        }
        //                    }
        //                    break;
        //                }
        //            }
        //        }

        //        List<ChartDatas> datas = new List<ChartDatas>()
        //        {
        //            new ChartDatas
        //            {
        //                Name = "Downtime",
        //                ChartColor = ColorTranslator.FromHtml("#EB7373"),
        //                ChartType = SeriesChartType.StackedColumn
        //            },
        //            new ChartDatas
        //            {
        //                Name = "Planned Downtime",
        //                ChartColor = ColorTranslator.FromHtml("#FFD7D4"),
        //                ChartType = SeriesChartType.StackedColumn
        //            },
        //            new ChartDatas
        //            {
        //                Name = HiveStatus.Engineering.ToString(),
        //                ChartColor = ColorTranslator.FromHtml("#CCABD8"),
        //                ChartType = SeriesChartType.StackedColumn
        //            },
        //            new ChartDatas
        //            {
        //                Name = HiveStatus.Idle.ToString(),
        //                ChartColor = ColorTranslator.FromHtml("#EBFFFE"),
        //                ChartType = SeriesChartType.StackedColumn
        //            },
        //            new ChartDatas
        //            {
        //                Name = HiveStatus.Running.ToString(),
        //                ChartColor = ColorTranslator.FromHtml("#D3EB73"),
        //                ChartType = SeriesChartType.StackedColumn
        //            },
        //        };
        //        CustomChart.InitChart(ref chartMachineState, datas, endTmp.AddHours(12), times[0].AddHours(-12), 1, DateTimeIntervalType.Days, "yyyy/MM/dd", NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_MachineStateStatistics", "设备状态统计 (7天)"), true, "", "", "P1");

        //        for (int i = 0; i < states.Length; i++)
        //        {
        //            if (states[i] == null)
        //            {
        //                chartMachineState.Series[0].Points.AddXY(times[i], 0);
        //                chartMachineState.Series[1].Points.AddXY(times[i], 0);
        //                chartMachineState.Series[2].Points.AddXY(times[i], 0);
        //                chartMachineState.Series[3].Points.AddXY(times[i], 0);
        //                chartMachineState.Series[4].Points.AddXY(times[i], 0);

        //                chartMachineState.Series[0].Points.Last().IsEmpty = true;
        //                chartMachineState.Series[1].Points.Last().IsEmpty = true;
        //                chartMachineState.Series[2].Points.Last().IsEmpty = true;
        //                chartMachineState.Series[3].Points.Last().IsEmpty = true;
        //                chartMachineState.Series[4].Points.Last().IsEmpty = true;
        //                continue;
        //            }

        //            double idle = states[i].FindAll(info => info.Status == HiveStatus.Idle).ToList().Sum(info => info.Duration) / 1440;
        //            double running = states[i].FindAll(info => info.Status == HiveStatus.Running).ToList().Sum(info => info.Duration) / 1440;
        //            double planDt = states[i].FindAll(info => info.Status == HiveStatus.Plan_DT).ToList().Sum(info => info.Duration) / 1440;
        //            double dt = states[i].FindAll(info => info.Status == HiveStatus.DT).ToList().Sum(info => info.Duration) / 1440;
        //            double engineering = states[i].FindAll(info => info.Status == HiveStatus.Engineering).ToList().Sum(info => info.Duration) / 1440;

        //            chartMachineState.Series[4].Points.AddXY(times[i], running);
        //            chartMachineState.Series[3].Points.AddXY(times[i], idle);
        //            chartMachineState.Series[2].Points.AddXY(times[i], engineering);
        //            chartMachineState.Series[1].Points.AddXY(times[i], planDt);
        //            chartMachineState.Series[0].Points.AddXY(times[i], dt);


        //            if (running * 100 < 1)
        //            {
        //                chartMachineState.Series[4].Points.Last().IsEmpty = true;
        //            }
        //            if (idle * 100 < 1)
        //            {
        //                chartMachineState.Series[3].Points.Last().IsEmpty = true;
        //            }
        //            if (engineering * 100 < 1)
        //            {
        //                chartMachineState.Series[2].Points.Last().IsEmpty = true;
        //            }
        //            if (planDt * 100 < 1)
        //            {
        //                chartMachineState.Series[1].Points.Last().IsEmpty = true;
        //            }
        //            if (dt * 100 < 1)
        //            {
        //                chartMachineState.Series[0].Points.Last().IsEmpty = true;
        //            }


        //            chartMachineState.Series.ToList().ForEach(p =>
        //            {
        //                string str = "时间:        \t{0}\r\nRunning:     \t{1}  \t{2}\r\nIdle:        \t{3}  \t{4}\r\nEngineering: \t{5}  \t{6}\r\nPlanned DT:  \t{7}  \t{8}\r\nDownTime:    \t{9}  \t{10}\r\n";
        //                str = NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_MachineStateStatistatics_ToolTip", str).Replace("\\t", "\t");
        //                p.Points[p.Points.ToList().Count - 1].ToolTip = string.Format(str
        //                , times[i].ToString("yyyy-MM-dd")
        //                , running.ToString("p1")
        //                , ConvertToHHmm(running * 1440)
        //                , idle.ToString("p1")
        //                , ConvertToHHmm(idle * 1440)
        //                , engineering.ToString("p1")
        //                , ConvertToHHmm(engineering * 1440)
        //                , planDt.ToString("p1")
        //                , ConvertToHHmm(planDt * 1440)
        //                , dt.ToString("p1")
        //                , ConvertToHHmm(dt * 1440));
        //            });
        //        }

        //        chartMachineState.ChartAreas[0].AxisY.Maximum = 1;
        //        chartMachineState.ChartAreas[0].AxisY.Minimum = 0;
        //        chartMachineState.ChartAreas[0].AxisY.Minimum = 0;
        //        chartMachineState.ChartAreas[0].AxisY.Interval = 0.25;
        //        chartMachineState.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
        //        chartMachineState.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
        //        chartMachineState.ChartAreas[0].AxisY.LabelStyle.Format = "p0";
        //        chartMachineState.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
        //        chartMachineState.ChartAreas[0].AxisX.LabelStyle.Format = "yyMMdd";
        //    }
        //    catch (Exception ex)
        //    {
        //        _show.LogAdd($"MachineState刷新失败:{ex.Message}", LogLevel.Warn);
        //    }
        //}

        #endregion
    }




    /// <summary>FAI绑定项</summary>
    public class FailBindDgv
    {
        /// <summary>FAI名称</summary>
        public string KeyName { get; set; }
        /// <summary>当前值</summary>
        public string Value { get; set; }
        /// <summary>上限</summary>
        public double USL { get; set; }
        /// <summary>下限</summary>
        public double LSL { get; set; }
    }
}