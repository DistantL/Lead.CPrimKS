using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProductInfoHelper;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lead.CPrim.StationCommon
{
    public partial class DataForm : UIPage
    {
        #region Field

        private DateTime _startTime_Chart1;
        private DateTime _endTime_Chart1;
        private DateTime _startTime_Chart2;
        private DateTime _endTime_Chart2;

        private Chart _chart1;
        private Chart _chart2;
        private DataPoint item;

        /// <summary>工站</summary>
        private StationConfig _station;

        /// <summary>列表模式</summary>
        private ProductInfos _list_ProductionInfos = new ProductInfos();

        /// <summary>
        /// 天 统计时 一天开始时刻的小时值。默认8小时;
        /// </summary>
        private int startTime_hourInDay = 8;

        /// <summary>
        /// 天 统计时 默认前几天。默认7天;
        /// </summary>
        private int defaultTime_MaxDays = 7;

        /// <summary>
        /// 小时 统计时 一小时开始时刻的分钟值。默认0分;
        /// </summary>
        private int startTime_MinutesInHour = 0;

        /// <summary>
        /// 小时 统计时 默认前几小时。默认24小时;
        /// </summary>
        private int defaultTime_MaxHours = 24;

        /// <summary>
        /// 最大查询天数。默认28天;
        /// </summary>
        private int MaxDays_InDB = 28;

        private Dictionary<string, int> dicReasonTossing = new Dictionary<string, int>();
        /// <summary>统计UI1</summary>
        ProductInfoStatistics _statistics1;

        /// <summary>统计UI1</summary>
        ProductInfoStatistics _statistics2;

        TossingInfoStatistics _statistics3;

        /// <summary>
        /// 原子锁<br/>
        /// 0：可操作；其他：不可操作；<br/>
        /// </summary>
        int _location = 0;
        /// <summary>UI按钮</summary>
        UIButton[] btns = new UIButton[] { };
        #endregion



        #region Ctor
        public DataForm(StationConfig station)
        {
            InitializeComponent();
            _station = station;

            btns = new UIButton[] { btnExport };
            SetStyle();

            _list_ProductionInfos = new ProductInfos();
            _list_ProductionInfos.TopLevel = false;
            _list_ProductionInfos.TopMost = false;
            _list_ProductionInfos.Dock = DockStyle.Fill;
            _list_ProductionInfos.Show();
            tlpLeft.Controls.Add(_list_ProductionInfos, 0, 4);

            _chart1 = new Chart();
            _chart1.Dock = DockStyle.Fill;
            _chart1.BackColor = pnl_Chart1.BackColor;
            pnl_Chart1.Controls.Add(_chart1);

            _chart2 = new Chart();
            _chart2.Dock = DockStyle.Fill;
            _chart2.BackColor = pnl_Chart2.BackColor;
            pnl_Chart2.Controls.Add(_chart2);


            _statistics3 = TossingInfoStatistics.GetInstance(SwManager.Instance.TossingReasons);
            _statistics3.TopMost = false;
            _statistics3.TopLevel = false;
            _statistics3.Dock = DockStyle.Fill;
            _statistics3.Show();
            pnlStatistics.Controls.Add(_statistics3);

            _statistics1 = ProductInfoStatistics.GetInstance(0);
            _statistics2 = ProductInfoStatistics.GetInstance(1);
            _statistics1.TopMost = false;
            _statistics1.TopLevel = false;
            _statistics1.Dock = DockStyle.Top;
            _statistics1.Show();
            _statistics2.TopMost = false;
            _statistics2.TopLevel = false;
            _statistics2.Dock = DockStyle.Top;
            _statistics2.Visible = false;
            _statistics2.Show();
            pnlStatistics.Controls.Add(_statistics1);

            dtp_Chart1_StartTime.SetStyle(Color.FromArgb(211, 211, 211));
            dtp_Chart1_EndTime.SetStyle(Color.FromArgb(211, 211, 211));
            dtp_Chart2_StartTime.SetStyle(Color.FromArgb(211, 211, 211));
            dtp_Chart2_EndTime.SetStyle(Color.FromArgb(211, 211, 211));
            hsb_Chart1.Style = UIStyle.Gray;
            hsb_Chart2.Style = UIStyle.Gray;

            if (!SwManager.Instance.HasAccessary)
            {
                //无辅料
                _statistics3.Visible = false;
                _list_ProductionInfos.SetHasAccessary(false);
                SWBn_IO_Tossing_Yield.SetSelectText("IO", "Yield", null);
            }
            else
            {
                //有辅料,SWBn_IO_Tossing_Yield 反馈0：IO；1，Tossing;2,yield；
                SWBn_IO_Tossing_Yield.SetSelectText("IO", "Tossing", "Yield");
            }
            SWBn_IO_Tossing_Yield.Click += SWBn_IO_Tossing_Yield_CheckedChanged;


            //station统计下一次更新节点
            if (DateTime.Now.Hour < startTime_hourInDay)//当前时间小于8点 
            {
                DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startTime_hourInDay, 0, 0);
                time_Updata_StationStatistic.Interval = (int)time.Subtract(DateTime.Now).TotalMilliseconds + 100;
            }
            else if (DateTime.Now.Hour >= startTime_hourInDay && (DateTime.Now.Hour < (startTime_hourInDay + 12)))  //当前时间大于等于8点 且小于20点
            {
                DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startTime_hourInDay, 0, 0).AddHours(12);
                time_Updata_StationStatistic.Interval = (int)time.Subtract(DateTime.Now).TotalMilliseconds + 100;
            }
            else //当前时间大于等于20点
            {
                DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startTime_hourInDay, 0, 0).AddHours(24);
                time_Updata_StationStatistic.Interval = (int)time.Subtract(DateTime.Now).TotalMilliseconds + 100;
            }

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region Event_System
        /// <summary>Load事件</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataForm_Load(object sender, EventArgs e)
        {
            //TimeInit();
            //ChangeChart(_startTime_Chart1, _endTime_Chart1, _startTime_Chart2, _endTime_Chart2);
            SWBn_Day_Hour.CheckedChanged += SWBn_Day_Hour_CheckedChanged;
        }
        #endregion



        #region Event_Button
        private void btnExport_Click(object sender, EventArgs e)
        {
            _list_ProductionInfos.ExportData();
        }

        /// <summary>
        /// 按天/按小时切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SWBn_Day_Hour_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                TimeInit();
                await ChangeChart(_startTime_Chart1, _endTime_Chart1, _startTime_Chart2, _endTime_Chart2);
            }
            catch (Exception ex)
            {
                LogHelper.LogAdd(LogLevel.Debug, $"DataForm.SWBn_Day_Hour_CheckedChanged：{ex.Message}：{ex.StackTrace}", LogClassification.Station.ToString());
            }
        }

        /// <summary>
        /// 产能、抛料率切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SWBn_IO_Tossing_Yield_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                switch (SWBn_IO_Tossing_Yield.SelectTextIndex)
                {
                    case 0:
                    case 1:
                    default:
                        {
                            SWBn_Day_Hour.Visible = true;
                            dtp_Chart1_StartTime.Enabled = true;
                            dtp_Chart2_StartTime.Enabled = true;
                            dtp_Chart1_EndTime.Enabled = true;
                            dtp_Chart2_EndTime.Enabled = true;
                        }
                        break;
                    case 2:
                        {
                            SWBn_Day_Hour.Visible = false;
                            dtp_Chart1_StartTime.Enabled = false;
                            dtp_Chart2_StartTime.Enabled = false;
                            dtp_Chart1_EndTime.Enabled = false;
                            dtp_Chart2_EndTime.Enabled = false;
                        }
                        break;
                }
                TimeInit();
                await ChangeChart(_startTime_Chart1, _endTime_Chart1, _startTime_Chart2, _endTime_Chart2);
            }
            catch (Exception ex)
            {
                LogHelper.LogAdd(LogLevel.Debug, $"DataForm.SWBn_Day_Hour_CheckedChanged：{ex.Message}：{ex.StackTrace}", LogClassification.Station.ToString());
            }
        }

        /// <summary>
        /// 上图表开始时间
        /// </summary>
        private async void dtp_Chart1_StartTime_OnComfirmOK()
        {
            DateTime maxTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).Subtract(TimeSpan.FromDays(MaxDays_InDB));
            if (dtp_Chart1_StartTime.Value < maxTime)
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_SetStartTimeError", string.Format("设置的开始时间超过最大追溯时间[{0}]，设置失败！", maxTime)));
                dtp_Chart1_StartTime.Value = _startTime_Chart1;
            }
            else if (dtp_Chart1_StartTime.Value < _endTime_Chart1)
            {
                _startTime_Chart1 = dtp_Chart1_StartTime.Value;
                //this.BeginInvoke(new Action<DateTime, DateTime, DateTime, DateTime>(ChangeChart), _startTime_Chart1, _endTime_Chart1, _startTime_Chart1, _endTime_Chart1);
                await ChangeChart(_startTime_Chart1, _endTime_Chart1, _startTime_Chart1, _endTime_Chart1);
            }
            else
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_SetStartTimeFail", "设置的开始时间大于或等于结束时间，设置失败！"));
                dtp_Chart1_StartTime.Value = _startTime_Chart1;
            }
        }

        /// <summary>
        /// 上图表开始时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtp_Chart1_StartTime_DropDownClosed(object sender, EventArgs e)
        {
            dtp_Chart1_StartTime.Value = _startTime_Chart1;
        }

        /// <summary>
        /// 上图表结束时间
        /// </summary>
        private async void dtp_Chart1_EndTime_OnComfirmOK()
        {
            DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(1);
            if (dtp_Chart1_EndTime.Value > time)
            {
                dtp_Chart1_EndTime.Value = _endTime_Chart1 = time;
            }
            else if (dtp_Chart1_EndTime.Value > _startTime_Chart1)
            {
                _endTime_Chart1 = dtp_Chart1_EndTime.Value;
                //this.BeginInvoke(new Action<DateTime, DateTime, DateTime, DateTime>(ChangeChart), _startTime_Chart1, _endTime_Chart1, _startTime_Chart1, _endTime_Chart1);
                await ChangeChart(_startTime_Chart1, _endTime_Chart1, _startTime_Chart1, _endTime_Chart1);
            }
            else
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_SetEndTimeFail", "设置的结束时间小于或等于开始时间，设置失败！"));
                dtp_Chart1_EndTime.Value = _endTime_Chart1;
            }
        }

        /// <summary>
        /// 上图表结束时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtp_Chart1_EndTime_DropDownClosed(object sender, EventArgs e)
        {
            dtp_Chart1_EndTime.Value = _endTime_Chart1;
        }

        /// <summary>
        /// 中图表开始时间
        /// </summary>
        private async void dtp_Chart2_StartTime_OnComfirmOK()
        {
            DateTime maxTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).Subtract(TimeSpan.FromDays(MaxDays_InDB));
            if (dtp_Chart2_StartTime.Value < maxTime)
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_SetStartTimeError", string.Format("设置的开始时间超过最大追溯时间[{0}]，设置失败！", maxTime)));
                dtp_Chart2_StartTime.Value = _startTime_Chart2;
            }
            else if (dtp_Chart2_StartTime.Value < _endTime_Chart2)
            {
                _startTime_Chart2 = dtp_Chart2_StartTime.Value;
                //this.BeginInvoke(new Action<DateTime, DateTime, DateTime, DateTime>(ChangeChart), _startTime_Chart2, _endTime_Chart2, _startTime_Chart2, _endTime_Chart2);
                await ChangeChart(_startTime_Chart2, _endTime_Chart2, _startTime_Chart2, _endTime_Chart2);
            }
            else
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_SetStartTimeFail", "设置的开始时间大于或等于结束时间，设置失败！"));
                dtp_Chart2_StartTime.Value = _startTime_Chart2;
            }
        }

        /// <summary>
        /// 中图表开始时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtp_Chart2_StartTime_DropDownClosed(object sender, EventArgs e)
        {
            dtp_Chart2_StartTime.Value = _startTime_Chart2;
        }

        /// <summary>
        /// 中图表结束时间
        /// </summary>
        private async void dtp_Chart2_EndTime_OnComfirmOK()
        {
            DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(1);
            if (dtp_Chart2_EndTime.Value > time)
            {
                dtp_Chart2_EndTime.Value = _endTime_Chart2 = time;
            }
            else if (dtp_Chart2_EndTime.Value > _startTime_Chart2)
            {
                _endTime_Chart2 = dtp_Chart2_EndTime.Value;
                //this.BeginInvoke(new Action<DateTime, DateTime, DateTime, DateTime>(ChangeChart), _startTime_Chart2, _endTime_Chart2, _startTime_Chart2, _endTime_Chart2);
                await ChangeChart(_startTime_Chart2, _endTime_Chart2, _startTime_Chart2, _endTime_Chart2);
            }
            else
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_SetEndTimeFail", "设置的结束时间小于或等于开始时间，设置失败！"));
                dtp_Chart2_EndTime.Value = _endTime_Chart2;
            }
        }

        /// <summary>
        /// 中图表结束时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtp_Chart2_EndTime_DropDownClosed(object sender, EventArgs e)
        {
            dtp_Chart2_EndTime.Value = _endTime_Chart2;
        }
        #endregion



        #region Method_ExternalUsing

        public override void Init()
        {
            base.Init();
            //SWBn_Day_Hour.Checked = false;

            TimeInit();
            _ = ChangeChart(_startTime_Chart1, _endTime_Chart1, _startTime_Chart2, _endTime_Chart2);
        }

        /// <summary>插入数据</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listEntiy"></param>
        /// <param name="saveDataBase"></param>
        /// <param name="stationName"></param>
        /// <param name="productName"></param>
        /// <param name="faiResults"></param>
        public void AddMultiPartInfo<T>(List<T> listEntiy, bool saveDataBase = false, string stationName = null, string productName = null, List<Dictionary<string, bool>> faiResults = null) where T : class
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<List<T>, bool, string, string, List<Dictionary<string, bool>>>(AddMultiPartInfo), listEntiy, saveDataBase, stationName, productName, faiResults);
            }
            else
            {
                try
                {
                    if (listEntiy == null || listEntiy.Count == 0)
                    {
                        return;
                    }

                    if (!stationName.IsNullOrEmpty())
                    {
                        if (productName.IsNullOrEmpty())
                        {
                            productName = "parts";
                        }
                        productName = stationName + "_" + productName;
                    }

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

                    PropertyInfo[] propInfo = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
                    if (propInfo == null || propInfo.Length <= 0)
                    {
                        return;
                    }

                    var propertyResult = typeof(T).GetProperty("Result");
                    var propertyCt = typeof(T).GetProperty("CT");
                    var propertyID = typeof(T).GetProperty("Sn");
                    var propertyTossingCount = typeof(T).GetProperty("TossingCount");
                    var propertyTossingReason = typeof(T).GetProperty("TossingReason");

                    Dictionary<int, string> dicColName = DataHelper.GetDataTableColumns(listEntiy, ref propInfo);

                    lock (locker_Updata_StationStatistic)
                    {
                        int partIndex = 0;
                        double retCt = 0;
                        int tossingCount = 0;
                        foreach (var item in listEntiy)
                        {
                            object[] values = DataHelper.GetDataTableRowValue(item, propInfo, dicColName);
                            if (item is ProductInfo)
                            {
                                _list_ProductionInfos.InsertData(item as ProductInfo);
                            }

                            _station.TotalCount++;
                            if (propertyResult != null)
                            {
                                string id = propertyID == null ? "" : propertyID.GetValue(item).ToString();
                                if (propertyResult.GetValue(item).ToString().ToLower()
                                    .Contains("ok") || propertyResult.GetValue(item).ToString() == "1"
                                    || propertyResult.GetValue(item).ToString().Contains("True"))
                                {
                                    _station.TotalOk++;
                                    UpdateProductResult(1, id);
                                }
                                else if (propertyResult.GetValue(item).ToString().ToLower()
                                    .Contains("ng") || propertyResult.GetValue(item).ToString() == "-1"
                                    || propertyResult.GetValue(item).ToString().Contains("False"))
                                {
                                    _station.TotalNg++;
                                    UpdateProductResult(0, id);
                                }
                                else
                                {
                                    _station.TotalInvalid++;
                                    UpdateProductResult(0, id);
                                }
                            }
                            if (propertyCt != null && double.TryParse(propertyCt.GetValue(item).ToString(), out retCt))
                            {
                            }

                            if (propertyTossingCount != null && int.TryParse(propertyTossingCount.GetValue(item).ToString(), out tossingCount))
                            {
                            }

                            if (propertyTossingReason != null
                                && propertyTossingReason.GetValue(item) != null
                                && !string.IsNullOrWhiteSpace(propertyTossingReason.GetValue(item).ToString()))
                            {
                                string[] strs = propertyTossingReason.GetValue(item).ToString().Split(';');
                                foreach (var str in strs)
                                {
                                    if (string.IsNullOrWhiteSpace(str))
                                    {
                                        continue;
                                    }
                                    if (!dicReasonTossing.ContainsKey(str))
                                    {
                                        dicReasonTossing.Add(str, 1);
                                    }
                                    else
                                    {
                                        dicReasonTossing[str]++;
                                    }
                                }
                            }
                            partIndex++;

                            if (item is ProductInfo)
                            {
                                UpdateOneToChart(item as ProductInfo);
                            }
                        }

                        UpdateNumCount($"{_station.TotalCount}/{_station.TotalOk}");
                        UpdateCt(retCt);
                        UpdateNum($"{_station.TotalOk}/{_station.TotalNg}");
                        if (_station.TotalCount != 0)
                        {
                            UpdatePassRate(_station.TotalOk * 1.0 / _station.TotalCount);
                        }
                        else
                        {
                            UpdatePassRate(0);
                        }

                        UpdateNumber(dicReasonTossing);
                        UpdateUPH(_list_ProductionInfos.UPH_Count());
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void UpdateOneToChart(ProductInfo data)
        {
            DateTime time;
            switch (SWBn_IO_Tossing_Yield.SelectTextIndex)
            {
                case 0:
                case 1:
                default:
                    {
                        if (SWBn_Day_Hour.Checked)
                        {
                            //小时统计
                            if (data.CreateTime.Minute < startTime_MinutesInHour)
                            {
                                time = new DateTime(data.CreateTime.Year, data.CreateTime.Month, data.CreateTime.Day, data.CreateTime.Hour, 0, 0);
                                time = time.AddHours(-1);
                            }
                            else
                            {
                                time = new DateTime(data.CreateTime.Year, data.CreateTime.Month, data.CreateTime.Day, data.CreateTime.Hour, 0, 0);
                            }
                        }
                        else
                        {
                            //天统计
                            if (data.CreateTime.Hour < startTime_hourInDay)
                            {
                                time = new DateTime(data.CreateTime.Year, data.CreateTime.Month, data.CreateTime.Day, 0, 0, 0);
                                time = time.AddDays(-1);
                            }
                            else
                            {
                                time = new DateTime(data.CreateTime.Year, data.CreateTime.Month, data.CreateTime.Day, 0, 0, 0);
                            }
                        }
                    }
                    break;
                case 2:
                    {
                        //小时统计
                        if (data.CreateTime.Minute < startTime_MinutesInHour)
                        {
                            time = new DateTime(data.CreateTime.Year, data.CreateTime.Month, data.CreateTime.Day, data.CreateTime.Hour, 0, 0);
                            time = time.AddHours(-1);
                        }
                        else
                        {
                            time = new DateTime(data.CreateTime.Year, data.CreateTime.Month, data.CreateTime.Day, data.CreateTime.Hour, 0, 0);
                        }
                    }
                    break;
            }

            #region 计算
            int index = _list_TimePointInfo.FindIndex(x => x.Time == time);
            if (index != -1)
            {
                #region 包含时间
                if (data.CreateTime.Hour >= startTime_hourInDay && data.CreateTime.Hour < startTime_hourInDay + 12)
                {
                    #region 白班
                    if (data.Result == "OK" || data.Result == "True")
                    {
                        _list_TimePointInfo[index].DS_OK_Count++;
                    }
                    else
                    {
                        _list_TimePointInfo[index].DS_NG_Count++;
                    }

                    _list_TimePointInfo[index].DS_Tossing_Count += data.TossingCount;
                    _list_TimePointInfo[index].DS_Accessary_Count += data.AccessaryCount;
                    _list_TimePointInfo[index].DS_CT_Sum += data.CT;

                    var items = _chart2.Series[0].Points.Where(p => p.XValue == time.ToOADate());
                    if (items != null && items.Count() != 0)
                    {

                        switch (SWBn_IO_Tossing_Yield.SelectTextIndex)
                        {
                            case 0:
                            default:
                                {
                                    int chartIndex = _chart2.Series[0].Points.IndexOf(items.First());

                                    double sum = _list_TimePointInfo[index].DS_OK_Count + _list_TimePointInfo[index].DS_NG_Count;
                                    double CT = 0;
                                    if (sum != 0)
                                    {
                                        CT = Math.Round(_list_TimePointInfo[index].DS_CT_Sum / sum, 2);
                                    }

                                    _chart1.Series[0].Points[chartIndex].YValues[0] = CT;
                                    _chart2.Series[0].Points[chartIndex].YValues[0] = _list_TimePointInfo[index].DS_OK_Count;
                                }
                                break;
                            case 1:
                                {
                                    int chartIndex = _chart2.Series[0].Points.IndexOf(items.First());

                                    double sum = _list_TimePointInfo[index].DS_Accessary_Count + _list_TimePointInfo[index].DS_Tossing_Count;
                                    if (sum == 0)
                                    {
                                        sum = 1;
                                    }
                                    _chart1.Series[0].Points[chartIndex].YValues[0] = _list_TimePointInfo[index].DS_Tossing_Count;
                                    _chart2.Series[0].Points[chartIndex].YValues[0] = Math.Round(_list_TimePointInfo[index].DS_Tossing_Count / sum, 2);
                                }
                                break;
                            case 2:
                                {
                                    #region 图1用 day
                                    DateTime time_day;
                                    //天统计
                                    if (data.CreateTime.Hour < startTime_hourInDay)
                                    {
                                        time_day = new DateTime(data.CreateTime.Year, data.CreateTime.Month, data.CreateTime.Day, 0, 0, 0);
                                        time_day = time.AddDays(-1);
                                    }
                                    else
                                    {
                                        time_day = new DateTime(data.CreateTime.Year, data.CreateTime.Month, data.CreateTime.Day, 0, 0, 0);
                                    }

                                    var items_day = _chart1.Series[0].Points.Where(p => p.XValue == time_day.ToOADate());
                                    if (items_day != null && items_day.Count() != 0)
                                    {
                                        int chartIndex_chart1 = _chart1.Series[0].Points.IndexOf(items_day.First());

                                        int index_day = _list_TimePointInfo_yield_chart1.FindIndex(x => x.Time == time_day);

                                        if (index_day != -1)
                                        {
                                            if (data.Result == "OK" || data.Result == "True")
                                            {
                                                _list_TimePointInfo_yield_chart1[index_day].DS_OK_Count++;
                                            }
                                            else
                                            {
                                                _list_TimePointInfo_yield_chart1[index_day].DS_NG_Count++;
                                            }

                                            double sum_day = _list_TimePointInfo_yield_chart1[index_day].DS_OK_Count + _list_TimePointInfo_yield_chart1[index_day].DS_NG_Count;
                                            double yield_day = 0;
                                            if (sum_day != 0)
                                            {
                                                yield_day = Math.Round(_list_TimePointInfo[index_day].DS_OK_Count / sum_day, 4);
                                            }

                                            _chart1.Series[0].Points[chartIndex_chart1].YValues[0] = yield_day * 100;
                                        }
                                    }
                                    #endregion

                                    #region 图2用 hour
                                    int chartIndex_chart2 = _chart2.Series[0].Points.IndexOf(items.First());

                                    double sum_hour = _list_TimePointInfo[index].DS_OK_Count + _list_TimePointInfo[index].DS_NG_Count;
                                    double yield_hour = 0;
                                    if (sum_hour != 0)
                                    {
                                        yield_hour = Math.Round(_list_TimePointInfo[index].DS_OK_Count / sum_hour, 4);
                                    }

                                    _chart2.Series[0].Points[chartIndex_chart2].YValues[0] = yield_hour * 100;

                                    #endregion
                                }
                                break;
                        }
                    }
                    #endregion
                }
                else
                {
                    #region 夜班
                    if (data.Result == "OK" || data.Result == "True")
                    {
                        _list_TimePointInfo[index].NS_OK_Count++;
                    }
                    else
                    {
                        _list_TimePointInfo[index].NS_NG_Count++;
                    }

                    _list_TimePointInfo[index].NS_Tossing_Count += data.TossingCount;
                    _list_TimePointInfo[index].NS_Accessary_Count += data.AccessaryCount;
                    _list_TimePointInfo[index].NS_CT_Sum += data.CT;

                    var items = _chart2.Series[1].Points.Where(p => p.XValue == time.ToOADate());
                    if (items != null && items.Count() != 0)
                    {
                        switch (SWBn_IO_Tossing_Yield.SelectTextIndex)
                        {
                            case 0:
                            default:
                                {
                                    int chartIndex = _chart2.Series[1].Points.IndexOf(items.First());

                                    double sum = _list_TimePointInfo[index].NS_OK_Count + _list_TimePointInfo[index].NS_NG_Count;
                                    double CT = 0;
                                    if (sum != 0)
                                    {
                                        CT = Math.Round(_list_TimePointInfo[index].NS_CT_Sum / sum, 2);
                                    }

                                    _chart1.Series[1].Points[chartIndex].YValues[0] = CT;
                                    _chart2.Series[1].Points[chartIndex].YValues[0] = _list_TimePointInfo[index].NS_OK_Count;
                                }
                                break;
                            case 1:
                                {
                                    int chartIndex = _chart2.Series[1].Points.IndexOf(items.First());

                                    double sum = _list_TimePointInfo[index].NS_Accessary_Count + _list_TimePointInfo[index].NS_Tossing_Count;
                                    if (sum == 0)
                                    {
                                        sum = 1;
                                    }
                                    _chart1.Series[1].Points[chartIndex].YValues[0] = _list_TimePointInfo[index].NS_Tossing_Count;
                                    _chart2.Series[1].Points[chartIndex].YValues[0] = Math.Round(_list_TimePointInfo[index].NS_Tossing_Count / sum, 2);
                                }
                                break;
                            case 2:
                                {
                                    #region 图1用 day
                                    DateTime time_day;
                                    //天统计
                                    if (data.CreateTime.Hour < startTime_hourInDay)
                                    {
                                        time_day = new DateTime(data.CreateTime.Year, data.CreateTime.Month, data.CreateTime.Day, 0, 0, 0);
                                        time_day = time.AddDays(-1);
                                    }
                                    else
                                    {
                                        time_day = new DateTime(data.CreateTime.Year, data.CreateTime.Month, data.CreateTime.Day, 0, 0, 0);
                                    }

                                    var items_day = _chart1.Series[1].Points.Where(p => p.XValue == time_day.ToOADate());
                                    if (items_day != null && items_day.Count() != 0)
                                    {
                                        int chartIndex_chart1 = _chart1.Series[1].Points.IndexOf(items_day.First());

                                        int index_day = _list_TimePointInfo_yield_chart1.FindIndex(x => x.Time == time_day);

                                        if (index_day != -1)
                                        {
                                            if (data.Result == "OK" || data.Result == "True")
                                            {
                                                _list_TimePointInfo_yield_chart1[index_day].NS_OK_Count++;
                                            }
                                            else
                                            {
                                                _list_TimePointInfo_yield_chart1[index_day].NS_NG_Count++;
                                            }
                                            double sum_day = _list_TimePointInfo_yield_chart1[index_day].NS_OK_Count + _list_TimePointInfo_yield_chart1[index_day].NS_NG_Count;
                                            double yield_day = 0;
                                            if (sum_day != 0)
                                            {
                                                yield_day = Math.Round(_list_TimePointInfo[index_day].NS_OK_Count / sum_day, 4);
                                            }

                                            _chart1.Series[1].Points[chartIndex_chart1].YValues[0] = yield_day * 100;
                                        }
                                    }
                                    #endregion

                                    #region 图2用 hour
                                    int chartIndex_chart2 = _chart2.Series[1].Points.IndexOf(items.First());

                                    double sum_hour = _list_TimePointInfo[index].NS_OK_Count + _list_TimePointInfo[index].NS_NG_Count;
                                    double yield_hour = 0;
                                    if (sum_hour != 0)
                                    {
                                        yield_hour = Math.Round(_list_TimePointInfo[index].NS_OK_Count / sum_hour, 4);
                                    }

                                    _chart2.Series[1].Points[chartIndex_chart2].YValues[0] = yield_hour * 100;

                                    #endregion
                                }
                                break;
                        }
                    }
                    #endregion
                }
                #endregion
            }
            else
            {
                TimeInit();
                _ = ChangeChart(_startTime_Chart1, _endTime_Chart1, _startTime_Chart2, _endTime_Chart2);
            }

            #endregion

            _chart1.ChartAreas[0].RecalculateAxesScale();
            _chart2.ChartAreas[0].RecalculateAxesScale();
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>设置样式</summary>
        private void SetStyle()
        {
            //UIForm
            this.BackColor = Color.FromArgb(236, 236, 236);
            tlpMain.BackColor = Color.Transparent;
            tlpLeft.BackColor = Color.FromArgb(211, 211, 211);
            tlpLeft.Margin = new Padding(0, 0, 3, 0);

            pnlStatistics.FillColor = Color.FromArgb(211, 211, 211);
            pnlStatistics.RectColor = Color.FromArgb(211, 211, 211);
            pnlStatistics.Margin = new Padding(3, 0, 0, 0);

            //UIButton
            foreach (var btn in btns)
            {
                btn.Style = UIStyle.Gray;
                btn.FillColor = Color.FromArgb(168, 168, 168);
                btn.ForeColor = Color.FromArgb(255, 255, 255);
                btn.BackColor = BackColor;
                btn.Radius = 10;
                btn.ForeHoverColor = BackColor;
                btn.FillHoverColor = Color.FromArgb(26, 137, 255);
                btn.FillPressColor = Color.FromArgb(26, 137, 255);
                btn.FillSelectedColor = Color.FromArgb(26, 137, 255);
                btn.Font = new Font("微软雅黑", 12.0f, FontStyle.Bold);
            }
        }

        /// <summary>数据初始化</summary>
        public void DataInit()
        {
            DateTime start;
            DateTime end;
            if (DateTime.Now.Hour < startTime_hourInDay)//当前时间小于8点 
            {
                start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startTime_hourInDay, 0, 0).AddHours(-12);
                end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startTime_hourInDay, 0, 0);
            }
            else if (DateTime.Now.Hour >= startTime_hourInDay && (DateTime.Now.Hour < (startTime_hourInDay + 12)))  //当前时间大于等于8点 且小于20点
            {
                start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startTime_hourInDay, 0, 0);
                end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startTime_hourInDay, 0, 0).AddHours(12);
            }
            else //当前时间大于等于20点
            {
                start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startTime_hourInDay, 0, 0).AddHours(12);
                end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startTime_hourInDay, 0, 0).AddHours(24);
            }
            double retCt = 0;

            string product = string.IsNullOrWhiteSpace(SwManager.Instance.CurrentProduct) ? @"parts" : SwManager.Instance.CurrentProduct;
            string db = $"{StationManager.Instance.CurrentStationName}_{product}";
            MongodbHelper.QueryManyByTime(start, end, out List<ProductInfo> productInfos, db);

            if (productInfos == null)
            {
                productInfos = new List<ProductInfo>();
            }

            if (productInfos.Count > 0)
            {
                _list_ProductionInfos.InsertData(productInfos);
            }

            #region 测试数据
            var p = new ProductInfo()
            {
                CreateTime = DateTime.Now.Subtract(TimeSpan.FromSeconds(12)),
                EndTime = DateTime.Now,
                CT = 12,
                Result = "OK",
                TossingReason = "侧相机检查NG",
                FixtureID = "sdhosdfhosf",
                HIVE_State = 2,
                Shift = "DS"
            };
            //productInfos.Add(p);
            //_list_ProductionInfos.InsertData(p);
            #endregion

            foreach (var item in productInfos)
            {
                if (item.TossingReason != null)
                {
                    string[] strs = item.TossingReason.Split(';');
                    foreach (var str in strs)
                    {
                        if (!dicReasonTossing.ContainsKey(str))
                        {
                            dicReasonTossing.Add(str, 1);
                        }
                        else
                        {
                            dicReasonTossing[str]++;
                        }
                    }
                }
                if (item.Result == "OK" || item.Result == "True")
                {
                    _station.TotalOk++;
                }
                else
                {
                    _station.TotalNg++;
                }
            }
            _station.TotalCount = _station.TotalOk + _station.TotalNg;

            UpdateProductResult(-1);
            UpdateNumCount($"{_station.TotalCount}/{_station.TotalOk}");
            UpdateCt(retCt);
            UpdateNum($"{_station.TotalOk}/{_station.TotalNg}");
            if (_station.TotalCount != 0)
            {
                UpdatePassRate(_station.TotalOk * 1.0 / _station.TotalCount);
            }
            else
            {
                UpdatePassRate(0);
            }

            UpdateNumber(dicReasonTossing);
            //当前时刻 （0分到59分间）生产数量为UPH
            DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0);
            UpdateUPH(productInfos.Where(x => x.CreateTime.CompareTo(startTime) > 0).Count());
        }

        /// <summary>更新产品结果</summary>
        /// <param name="result">1：OK；0：NG；other：不显示</param>
        /// <param name="id"></param>
        private void UpdateProductResult(int result, string id = "")
        {
            _statistics1.UpdateProductResult(result, id);
            _statistics2.UpdateProductResult(result, id);
        }

        /// <summary>更新总数量</summary>
        /// <param name="value">数量</param>
        private void UpdateNumCount(string value)
        {
            _statistics1.UpdateNumCount(value);
            _statistics2.UpdateNumCount(value);
        }

        /// <summary>更新良率</summary>
        /// <param name="value">良率</param>
        private void UpdatePassRate(double value)
        {
            _statistics1.UpdatePassRate(value);
            _statistics2.UpdatePassRate(value);
        }

        /// <summary>pass/fail统计</summary>
        /// <param name="value">pass/fail</param>
        private void UpdateNum(string value)
        {
            _statistics1.UpdateNum(value);
            _statistics2.UpdateNum(value);
        }

        /// <summary>更新CT</summary>
        /// <param name="value">CT</param>
        private void UpdateCt(double value)
        {
            _statistics1.UpdateCt(value);
            _statistics2.UpdateCt(value);
        }

        private void UpdateUPH(int value)
        {
            _statistics1.UpdateUPH(value);
            _statistics2.UpdateUPH(value);
        }

        private void UpdateNumber(Dictionary<string, int> value)
        {
            _statistics3.UpdateNumber(value);
        }

        /// <summary>
        /// 时间初始化
        /// </summary>
        private void TimeInit()
        {
            switch (SWBn_IO_Tossing_Yield.SelectTextIndex)
            {
                case 0:
                case 1:
                default:
                    {
                        if (!SWBn_Day_Hour.Checked)
                        {
                            //天统计
                            if (DateTime.Now.Hour < startTime_hourInDay)//当前时间小于8点 
                            {
                                //当前班次为前天夜班
                                var time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startTime_hourInDay, 0, 0);
                                _endTime_Chart1 = _endTime_Chart2 = time.AddSeconds(-0.1);
                                _startTime_Chart1 = time.Subtract(TimeSpan.FromDays(defaultTime_MaxDays - 1));
                            }
                            else//当前时间大于等于8点
                            {
                                //当前班次为当天白班或夜班
                                var time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startTime_hourInDay, 0, 0);
                                _endTime_Chart1 = _endTime_Chart2 = time.AddDays(1).AddSeconds(-0.1);
                                _startTime_Chart1 = time.Subtract(TimeSpan.FromDays(defaultTime_MaxDays - 1));
                            }
                        }
                        else
                        {
                            //小时统计
                            if (DateTime.Now.Minute < startTime_MinutesInHour)
                            {
                                var time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, startTime_MinutesInHour, 0);
                                _endTime_Chart1 = _endTime_Chart2 = time.AddSeconds(-0.1);
                                _startTime_Chart1 = time.Subtract(TimeSpan.FromHours(defaultTime_MaxHours - 1));
                            }
                            else
                            {
                                var time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, startTime_MinutesInHour, 0);
                                _endTime_Chart1 = _endTime_Chart2 = time.AddHours(1).AddSeconds(-0.1);
                                _startTime_Chart1 = time.Subtract(TimeSpan.FromHours(defaultTime_MaxHours - 1));
                            }
                        }

                        _startTime_Chart2 = _startTime_Chart1;
                        _endTime_Chart2 = _endTime_Chart1;

                        dtp_Chart1_StartTime.Value = _startTime_Chart1;
                        dtp_Chart1_EndTime.Value = _endTime_Chart1;
                        dtp_Chart2_StartTime.Value = _startTime_Chart2;
                        dtp_Chart2_EndTime.Value = _endTime_Chart2;
                    }
                    break;
                case 2:
                    {
                        //天统计
                        if (DateTime.Now.Hour < startTime_hourInDay)//当前时间小于8点 
                        {
                            //当前班次为前天夜班
                            var time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startTime_hourInDay, 0, 0);
                            _endTime_Chart1 = time.AddSeconds(-0.1);
                            _startTime_Chart1 = time.Subtract(TimeSpan.FromDays(defaultTime_MaxDays - 1));
                        }
                        else//当前时间大于等于8点
                        {
                            //当前班次为当天白班或夜班
                            var time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startTime_hourInDay, 0, 0);
                            _endTime_Chart1 = time.AddDays(1).AddSeconds(-0.1);
                            _startTime_Chart1 = time.Subtract(TimeSpan.FromDays(defaultTime_MaxDays - 1));
                        }



                        //小时统计
                        if (DateTime.Now.Minute < startTime_MinutesInHour)
                        {
                            var time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, startTime_MinutesInHour, 0);
                            _endTime_Chart2 = time.AddSeconds(-0.1);
                            _startTime_Chart2 = time.Subtract(TimeSpan.FromHours(defaultTime_MaxHours - 1));
                        }
                        else
                        {
                            var time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, startTime_MinutesInHour, 0);
                            _endTime_Chart2 = time.AddHours(1).AddSeconds(-0.1);
                            _startTime_Chart2 = time.Subtract(TimeSpan.FromHours(defaultTime_MaxHours - 1));
                        }

                        dtp_Chart1_StartTime.Value = _startTime_Chart1;
                        dtp_Chart1_EndTime.Value = _endTime_Chart1;
                        dtp_Chart2_StartTime.Value = _startTime_Chart2;
                        dtp_Chart2_EndTime.Value = _endTime_Chart2;
                    }
                    break;
            }
        }

        private async Task ChangeChart(DateTime startTime_chart1, DateTime endTime_chart1, DateTime startTime_chart2, DateTime endTime_chart2)
        {
            if (Interlocked.CompareExchange(ref _location, 1, 0) == 0)
            {
                try
                {
                    switch (SWBn_IO_Tossing_Yield.SelectTextIndex)
                    {
                        case 0:
                        case 1:
                        default:
                            {
                                if (SWBn_Day_Hour.Checked)
                                {
                                    SetAxisByHour(startTime_chart1, endTime_chart1);
                                }
                                else
                                {
                                    SetAxisByDay(startTime_chart1, endTime_chart1);
                                }

                                var list = await GetDataFromDb(startTime_chart2, endTime_chart2, _list_TimePointInfo);
                                if (list != null)
                                {
                                    _list_TimePointInfo = list;
                                }
                            }
                            break;
                        case 2:
                            {
                                SetAxisByDayByHour(startTime_chart1, endTime_chart1, startTime_chart2, endTime_chart2);
                                {
                                    var list = await GetDataFromDb(startTime_chart1, endTime_chart1, _list_TimePointInfo_yield_chart1);
                                    if (list != null)
                                    {
                                        _list_TimePointInfo_yield_chart1 = list;
                                    }
                                }

                                {
                                    var list = await GetDataFromDb(startTime_chart2, endTime_chart2, _list_TimePointInfo);
                                    if (list != null)
                                    {
                                        _list_TimePointInfo = list;
                                    }
                                }
                            }
                            break;
                    }

                    switch (SWBn_IO_Tossing_Yield.SelectTextIndex)
                    {
                        case 0:
                        default:
                            {
                                if (SWBn_Day_Hour.Checked)
                                {
                                    InitMode3();
                                    SetAxisLimitByHour(_list_TimePointInfo[hsb_Chart1.Value].Time, _list_TimePointInfo[hsb_Chart1.Value + 11].Time);
                                }
                                else
                                {
                                    InitMode4();
                                    SetAxisLimitByDay(_list_TimePointInfo[hsb_Chart1.Value].Time, _list_TimePointInfo[hsb_Chart1.Value + 6].Time);
                                }
                            }
                            break;
                        case 1:
                            {
                                if (SWBn_Day_Hour.Checked)
                                {
                                    InitMode1();
                                    SetAxisLimitByHour(_list_TimePointInfo[hsb_Chart1.Value].Time, _list_TimePointInfo[hsb_Chart1.Value + 11].Time);
                                }
                                else
                                {
                                    InitMode2();
                                    SetAxisLimitByDay(_list_TimePointInfo[hsb_Chart1.Value].Time, _list_TimePointInfo[hsb_Chart1.Value + 6].Time);
                                }
                            }
                            break;
                        case 2:
                            {
                                InitMode5();
                                SetAxisLimitByDayByHour(_list_TimePointInfo_yield_chart1[hsb_Chart1.Value].Time, _list_TimePointInfo_yield_chart1[hsb_Chart1.Value + 6].Time, _list_TimePointInfo[hsb_Chart1.Value].Time, _list_TimePointInfo[hsb_Chart1.Value + 11].Time);
                            }
                            break;
                    }

                    UpDataToChart();
                }
                catch(Exception ex)
                {
                    LogHelper.LogAdd(LogLevel.Debug, $"DataForm.ChangeChart1：{ex.Message}：{ex.StackTrace}", LogClassification.Station.ToString());
                }
                finally
                {
                    _location = 0;
                    try
                    {
                        _chart1.ChartAreas[0].RecalculateAxesScale();
                        _chart2.ChartAreas[0].RecalculateAxesScale();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.LogAdd(LogLevel.Debug, $"DataForm.ChangeChart2：{ex.Message}：{ex.StackTrace}", LogClassification.Station.ToString());
                    }
                }
            }
        }

        private async Task<List<TimePointInfo>> GetDataFromDb(DateTime startTime, DateTime endTime, List<TimePointInfo> _list_TimePointInfo)
        {
            if (_list_TimePointInfo.IsNullOrEmpty())
            {
                return null;
            }

            List<TimePointInfo> list_TimePointInfo = new List<TimePointInfo>();
            foreach (var item in _list_TimePointInfo)
            {
                list_TimePointInfo.Add(new TimePointInfo()
                {
                    Shift = item.Shift,
                    Time = item.Time,
                    DS_OK_Count = item.DS_OK_Count,
                    DS_NG_Count = item.DS_NG_Count,
                    NS_OK_Count = item.NS_OK_Count,
                    NS_NG_Count = item.NS_NG_Count,
                    DS_Tossing_Count = item.DS_Tossing_Count,
                    DS_Accessary_Count = item.DS_Accessary_Count,
                    NS_Tossing_Count = item.NS_Tossing_Count,
                    NS_Accessary_Count = item.NS_Accessary_Count,

                    DS_CT_Sum = item.DS_CT_Sum,
                    NS_CT_Sum = item.NS_CT_Sum
                });
            }

            List<Task> tasks = new List<Task>();
            foreach (var timePointInfo in list_TimePointInfo)
            {
                tasks.Add(Task.Run(() =>
                {
                    //查询数据库
                    string product = string.IsNullOrWhiteSpace(SwManager.Instance.CurrentProduct) ? @"parts" : SwManager.Instance.CurrentProduct;
                    int ret;
                    List<ProductInfo> productInfos;
                    string db = $"{StationManager.Instance.CurrentStationName}_{product}";
                    if (SWBn_Day_Hour.Checked)
                    {
                        ret = MongodbHelper.QueryManyByTime(timePointInfo.Time.AddMinutes(startTime_MinutesInHour), timePointInfo.Time.AddHours(1).AddMinutes(startTime_MinutesInHour), out productInfos, db);
                    }
                    else
                    {
                        ret = MongodbHelper.QueryManyByTime(timePointInfo.Time.AddHours(startTime_hourInDay), timePointInfo.Time.AddHours(startTime_hourInDay + 24), out productInfos, db);
                    }
                    if (ret != 0 || productInfos == null || productInfos.Count <= 0)
                    {
                        productInfos = new List<ProductInfo>();
                    }

                    Dictionary<string, ProductInfo> keyValuePairsSn = new Dictionary<string, ProductInfo>();
                    int keyValuePairs_DS_OK = 0;
                    int keyValuePairs_DS_NG = 0;
                    int keyValuePairs_DS_TossingCount = 0;
                    int keyValuePairs_DS_AccessaryCount = 0;

                    int keyValuePairs_NS_OK = 0;
                    int keyValuePairs_NS_NG = 0;
                    int keyValuePairs_NS_TossingCount = 0;
                    int keyValuePairs_NS_AccessaryCount = 0;

                    double keyValuePairs_DS_CT = 0;
                    double keyValuePairs_NS_CT = 0;

                    productInfos.ForEach(p =>
                    {
                        if (keyValuePairsSn.ContainsKey(p.Sn))
                        {
                            return;
                        }
                        else
                        {
                            keyValuePairsSn.Add(p.Sn, p);
                        }

                        if (p.CreateTime.Hour >= startTime_hourInDay && p.CreateTime.Hour < (startTime_hourInDay + 12))
                        {
                            p.Shift = "DS";
                            if (p.Result == "OK" || p.Result == "Ture")
                            {
                                keyValuePairs_DS_OK++;
                            }
                            else
                            {
                                keyValuePairs_DS_NG++;
                            }
                            keyValuePairs_DS_TossingCount += p.TossingCount;
                            keyValuePairs_DS_AccessaryCount += p.AccessaryCount;
                            keyValuePairs_DS_CT += p.CT;
                        }
                        else
                        {
                            p.Shift = "NS";
                            if (p.Result == "OK" || p.Result == "Ture")
                            {
                                keyValuePairs_NS_OK++;
                            }
                            else
                            {
                                keyValuePairs_NS_NG++;
                            }
                            keyValuePairs_NS_TossingCount += p.TossingCount;
                            keyValuePairs_NS_AccessaryCount += p.AccessaryCount;
                            keyValuePairs_NS_CT += p.CT;
                        }
                    });

                    timePointInfo.DS_OK_Count = keyValuePairs_DS_OK;
                    timePointInfo.DS_NG_Count = keyValuePairs_DS_NG;
                    timePointInfo.DS_Accessary_Count = keyValuePairs_DS_AccessaryCount;
                    timePointInfo.DS_Tossing_Count = keyValuePairs_DS_TossingCount;

                    timePointInfo.NS_OK_Count = keyValuePairs_NS_OK;
                    timePointInfo.NS_NG_Count = keyValuePairs_NS_NG;
                    timePointInfo.NS_Accessary_Count = keyValuePairs_NS_AccessaryCount;
                    timePointInfo.NS_Tossing_Count = keyValuePairs_NS_TossingCount;

                    timePointInfo.DS_CT_Sum = keyValuePairs_DS_CT;
                    timePointInfo.NS_CT_Sum = keyValuePairs_NS_CT;
                }));
            }

            await Task.WhenAll(tasks);
            return list_TimePointInfo;
        }

        void SetAxisByHour(DateTime startTime, DateTime endTime)
        {
            int defaultShowNumber = 12;

            var start = new DateTime(startTime.Year, startTime.Month, startTime.Day, startTime.Hour, 0, 0);
            var end = new DateTime(endTime.Year, endTime.Month, endTime.Day, endTime.Hour, 0, 0);

            int count = (int)(end - start).TotalHours + 1;
            start = end.Subtract(TimeSpan.FromHours(defaultShowNumber - 1));
            if (count < defaultShowNumber)
            {
                count = defaultShowNumber;
            }

            _list_TimePointInfo.Clear();
            for (int i = 0; i < count; i++)
            {
                _list_TimePointInfo.Add(
                    new TimePointInfo
                    {
                        Time = end.Subtract(TimeSpan.FromHours(count - i - 1))
                    });
            }

            hsb_Chart1.Value = hsb_Chart1.Maximum = count - defaultShowNumber;
            hsb_Chart2.Value = hsb_Chart2.Maximum = count - defaultShowNumber;
        }

        void SetAxisByDay(DateTime startTime, DateTime endTime)
        {
            int defaultShowNumber = 7;

            var _startTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 0, 0, 0);
            DateTime _endTime;
            if (endTime.Hour <= startTime_hourInDay)
            {
                _endTime = new DateTime(endTime.Year, endTime.Month, endTime.Day, 0, 0, 0).AddDays(-1);
            }
            else
            {
                _endTime = new DateTime(endTime.Year, endTime.Month, endTime.Day, 0, 0, 0);
            }

            int count = (int)(_endTime - _startTime).TotalDays + 1;
            _startTime = _endTime.Subtract(TimeSpan.FromDays(defaultShowNumber - 1));

            if (count < defaultShowNumber)
            {
                count = defaultShowNumber;
            }

            _list_TimePointInfo.Clear();
            for (int i = 0; i < count; i++)
            {
                _list_TimePointInfo.Add(new TimePointInfo { Time = _endTime.Subtract(TimeSpan.FromDays(count - i - 1)) });
            }

            hsb_Chart1.Value = hsb_Chart1.Maximum = count - defaultShowNumber;
            hsb_Chart2.Value = hsb_Chart2.Maximum = count - defaultShowNumber;
        }

        void SetAxisByDayByHour(DateTime startTime_day, DateTime endTime_day, DateTime startTime_hour, DateTime endTime_hour)
        {
            #region 图一用 Day

            int defaultShowNumber_day = 7;

            var _startTime_day = new DateTime(startTime_day.Year, startTime_day.Month, startTime_day.Day, 0, 0, 0);
            DateTime _endTime_day;
            if (endTime_day.Hour <= startTime_hourInDay)
            {
                _endTime_day = new DateTime(endTime_day.Year, endTime_day.Month, endTime_day.Day, 0, 0, 0).AddDays(-1);
            }
            else
            {
                _endTime_day = new DateTime(endTime_day.Year, endTime_day.Month, endTime_day.Day, 0, 0, 0);
            }

            int count_day = (int)(_endTime_day - _startTime_day).TotalDays + 1;
            _startTime_day = _endTime_day.Subtract(TimeSpan.FromDays(defaultShowNumber_day - 1));

            if (count_day < defaultShowNumber_day)
            {
                count_day = defaultShowNumber_day;
            }

            _list_TimePointInfo_yield_chart1.Clear();
            for (int i = 0; i < count_day; i++)
            {
                _list_TimePointInfo_yield_chart1.Add(new TimePointInfo { Time = _endTime_day.Subtract(TimeSpan.FromDays(count_day - i - 1)) });
            }

            hsb_Chart1.Value = hsb_Chart1.Maximum = count_day - defaultShowNumber_day;

            #endregion

            #region 图二用 Hour

            int defaultShowNumber_hour = 12;

            var _startTime_hour = new DateTime(startTime_hour.Year, startTime_hour.Month, startTime_hour.Day, startTime_hour.Hour, 0, 0);
            var _endTime_hour = new DateTime(endTime_hour.Year, endTime_hour.Month, endTime_hour.Day, endTime_hour.Hour, 0, 0);

            int count_hour = (int)(_endTime_hour - _startTime_hour).TotalHours + 1;
            _startTime_hour = _endTime_hour.Subtract(TimeSpan.FromHours(defaultShowNumber_hour - 1));
            if (count_hour < defaultShowNumber_hour)
            {
                count_hour = defaultShowNumber_hour;
            }

            _list_TimePointInfo.Clear();
            for (int i = 0; i < count_hour; i++)
            {
                _list_TimePointInfo.Add(new TimePointInfo { Time = _endTime_hour.Subtract(TimeSpan.FromHours(count_hour - i - 1)) });
            }

            hsb_Chart2.Value = hsb_Chart2.Maximum = count_hour - defaultShowNumber_hour;

            #endregion
        }
        #endregion




        private List<TimePointInfo> _list_TimePointInfo = new List<TimePointInfo>();
        private List<TimePointInfo> _list_TimePointInfo_yield_chart1 = new List<TimePointInfo>();

        private void SetAxisLimitByDay(DateTime startTime, DateTime endTime)
        {
            _chart1.ChartAreas[0].AxisX.Minimum = _chart2.ChartAreas[0].AxisX.Minimum = startTime.Subtract(TimeSpan.FromDays(0.5)).ToOADate();
            _chart1.ChartAreas[0].AxisX.Maximum = _chart2.ChartAreas[0].AxisX.Maximum = endTime.Add(TimeSpan.FromDays(0.5)).ToOADate();
        }

        private void SetAxisLimitByHour(DateTime startTime, DateTime endTime)
        {
            _chart1.ChartAreas[0].AxisX.Minimum = _chart2.ChartAreas[0].AxisX.Minimum = startTime.Subtract(TimeSpan.FromHours(0.5)).ToOADate();
            _chart1.ChartAreas[0].AxisX.Maximum = _chart2.ChartAreas[0].AxisX.Maximum = endTime.Add(TimeSpan.FromHours(0.5)).ToOADate();
        }

        private void SetAxisLimitByDayByHour(DateTime startTime_day, DateTime endTime_day, DateTime startTime_hour, DateTime endTime_hour)
        {
            _chart1.ChartAreas[0].AxisX.Minimum = startTime_day.Subtract(TimeSpan.FromHours(0.5)).ToOADate();
            _chart1.ChartAreas[0].AxisX.Maximum = endTime_day.Add(TimeSpan.FromHours(0.5)).ToOADate();

            _chart2.ChartAreas[0].AxisX.Minimum = startTime_hour.Subtract(TimeSpan.FromDays(0.5)).ToOADate();
            _chart2.ChartAreas[0].AxisX.Maximum = endTime_hour.Add(TimeSpan.FromDays(0.5)).ToOADate();
        }

        private void SetAxisLimitByDay(int i, DateTime startTime, DateTime endTime)
        {
            if (i == 0)
            {
                _chart1.ChartAreas[0].AxisX.Minimum = startTime.Subtract(TimeSpan.FromDays(0.5)).ToOADate();
                _chart1.ChartAreas[0].AxisX.Maximum = endTime.Add(TimeSpan.FromDays(0.5)).ToOADate();
            }
            else
            {
                _chart2.ChartAreas[0].AxisX.Minimum = startTime.Subtract(TimeSpan.FromDays(0.5)).ToOADate();
                _chart2.ChartAreas[0].AxisX.Maximum = endTime.Add(TimeSpan.FromDays(0.5)).ToOADate();
            }

        }

        private void SetAxisLimitByHour(int i, DateTime startTime, DateTime endTime)
        {
            if (i == 0)
            {
                _chart1.ChartAreas[0].AxisX.Minimum = startTime.Subtract(TimeSpan.FromHours(0.5)).ToOADate();
                _chart1.ChartAreas[0].AxisX.Maximum = endTime.Add(TimeSpan.FromHours(0.5)).ToOADate();
            }
            else
            {
                _chart2.ChartAreas[0].AxisX.Minimum = startTime.Subtract(TimeSpan.FromHours(0.5)).ToOADate();
                _chart2.ChartAreas[0].AxisX.Maximum = endTime.Add(TimeSpan.FromHours(0.5)).ToOADate();
            }
        }

        private void UpDataToChart()
        {
            _chart1.Series[0].Points.Clear();
            _chart2.Series[0].Points.Clear();
            int lastindex = 0;

            switch (SWBn_IO_Tossing_Yield.SelectTextIndex)
            {
                case 0:
                default:
                    {
                        //计算Output
                        _chart2.Series[1].Points.Clear();
                        for (int index = 0; index < _list_TimePointInfo.Count; index++)
                        {
                            if (SWBn_Day_Hour.Checked)
                            {
                                string axisLabel = _list_TimePointInfo[index].Time.ToString("HH:00")
                                                    + "-"
                                                    + _list_TimePointInfo[index].Time.AddHours(1).ToString("HH:00")
                                                    + "\n"
                                                    + _list_TimePointInfo[index].Time.ToString("yyyy/MM/dd");
                                if (_list_TimePointInfo[index].Time.Hour >= startTime_hourInDay && _list_TimePointInfo[index].Time.Hour < startTime_hourInDay + 12)
                                {
                                    double sum = _list_TimePointInfo[index].DS_OK_Count + _list_TimePointInfo[index].DS_NG_Count;
                                    double CT = 0;
                                    if (sum != 0)
                                    {
                                        CT = Math.Round(_list_TimePointInfo[index].DS_CT_Sum / sum, 2);
                                    }

                                    lastindex = _chart1.Series[0].Points.AddXY(_list_TimePointInfo[index].Time, CT);
                                    item = _chart1.Series[0].Points[lastindex];
                                    item.Name = item.AxisLabel = axisLabel;

                                    lastindex = _chart2.Series[0].Points.AddXY(_list_TimePointInfo[index].Time, _list_TimePointInfo[index].DS_OK_Count);
                                    item = _chart2.Series[0].Points[lastindex];
                                    item.Name = item.AxisLabel = axisLabel;

                                    lastindex = _chart1.Series[1].Points.AddXY(_list_TimePointInfo[index].Time, 0);
                                    item = _chart1.Series[1].Points[lastindex];
                                    item.IsEmpty = true;

                                    lastindex = _chart2.Series[1].Points.AddXY(_list_TimePointInfo[index].Time, 0);
                                    item = _chart2.Series[1].Points[lastindex];
                                    item.IsEmpty = true;
                                }
                                else
                                {
                                    double sum = _list_TimePointInfo[index].NS_OK_Count + _list_TimePointInfo[index].NS_NG_Count;
                                    double CT = 0;
                                    if (sum != 0)
                                    {
                                        CT = Math.Round(_list_TimePointInfo[index].NS_CT_Sum / sum, 2);
                                    }
                                    lastindex = _chart1.Series[1].Points.AddXY(_list_TimePointInfo[index].Time, CT);
                                    item = _chart1.Series[1].Points[lastindex];
                                    item.Name = item.AxisLabel = axisLabel;

                                    lastindex = _chart2.Series[1].Points.AddXY(_list_TimePointInfo[index].Time, _list_TimePointInfo[index].NS_OK_Count);
                                    item = _chart2.Series[1].Points[lastindex];
                                    item.Name = item.AxisLabel = axisLabel;

                                    lastindex = _chart1.Series[0].Points.AddXY(_list_TimePointInfo[index].Time, 0);
                                    item = _chart1.Series[0].Points[lastindex];
                                    item.IsEmpty = true;

                                    lastindex = _chart2.Series[0].Points.AddXY(_list_TimePointInfo[index].Time, 0);
                                    item = _chart2.Series[0].Points[lastindex];
                                    item.IsEmpty = true;
                                }
                            }
                            else
                            {
                                double sum = _list_TimePointInfo[index].DS_OK_Count + _list_TimePointInfo[index].DS_NG_Count;
                                double CT = 0;
                                if (sum != 0)
                                {
                                    CT = Math.Round(_list_TimePointInfo[index].DS_CT_Sum / sum, 2);
                                }
                                _chart1.Series[0].Points.AddXY(_list_TimePointInfo[index].Time, CT);
                                _chart2.Series[0].Points.AddXY(_list_TimePointInfo[index].Time, _list_TimePointInfo[index].DS_OK_Count);

                                sum = _list_TimePointInfo[index].NS_OK_Count + _list_TimePointInfo[index].NS_NG_Count;
                                CT = 0;
                                if (sum != 0)
                                {
                                    CT = Math.Round(_list_TimePointInfo[index].NS_CT_Sum / sum, 2);
                                }
                                _chart1.Series[1].Points.AddXY(_list_TimePointInfo[index].Time, CT);
                                _chart2.Series[1].Points.AddXY(_list_TimePointInfo[index].Time, _list_TimePointInfo[index].NS_OK_Count);
                            }
                        }
                    }
                    break;
                case 1:
                    {
                        //计算抛料
                        for (int index = 0; index < _list_TimePointInfo.Count; index++)
                        {
                            if (SWBn_Day_Hour.Checked)
                            {
                                string axisLabel = _list_TimePointInfo[index].Time.ToString("HH:00")
                                                    + "-"
                                                    + _list_TimePointInfo[index].Time.AddHours(1).ToString("HH:00")
                                                    + "\n"
                                                    + _list_TimePointInfo[index].Time.ToString("yyyy/MM/dd");
                                if (_list_TimePointInfo[index].Time.Hour >= startTime_hourInDay && _list_TimePointInfo[index].Time.Hour < startTime_hourInDay + 12)
                                {
                                    double sum = _list_TimePointInfo[index].DS_Accessary_Count + _list_TimePointInfo[index].DS_Tossing_Count;
                                    if (sum == 0)
                                    {
                                        sum = 1;
                                    }
                                    lastindex = _chart1.Series[0].Points.AddXY(_list_TimePointInfo[index].Time, _list_TimePointInfo[index].DS_Tossing_Count);
                                    item = _chart1.Series[0].Points[lastindex];
                                    item.Name = item.AxisLabel = axisLabel;

                                    lastindex = _chart2.Series[0].Points.AddXY(_list_TimePointInfo[index].Time, _list_TimePointInfo[index].DS_Tossing_Count / sum);
                                    item = _chart2.Series[0].Points[lastindex];
                                    item.Name = item.AxisLabel = axisLabel;

                                    lastindex = _chart1.Series[1].Points.AddXY(_list_TimePointInfo[index].Time, 0);
                                    item = _chart1.Series[1].Points[lastindex];
                                    item.IsEmpty = true;

                                    lastindex = _chart2.Series[1].Points.AddXY(_list_TimePointInfo[index].Time, 0);
                                    item = _chart2.Series[1].Points[lastindex];
                                    item.IsEmpty = true;
                                }
                                else
                                {
                                    double sum = _list_TimePointInfo[index].NS_Accessary_Count + _list_TimePointInfo[index].NS_Tossing_Count;
                                    if (sum == 0)
                                    {
                                        sum = 1;
                                    }
                                    lastindex = _chart1.Series[1].Points.AddXY(_list_TimePointInfo[index].Time, _list_TimePointInfo[index].NS_Tossing_Count);
                                    item = _chart1.Series[1].Points[lastindex];
                                    item.Name = item.AxisLabel = axisLabel;

                                    lastindex = _chart2.Series[1].Points.AddXY(_list_TimePointInfo[index].Time, _list_TimePointInfo[index].NS_Tossing_Count / sum);
                                    item = _chart2.Series[1].Points[lastindex];
                                    item.Name = item.AxisLabel = axisLabel;

                                    lastindex = _chart1.Series[0].Points.AddXY(_list_TimePointInfo[index].Time, 0);
                                    item = _chart1.Series[0].Points[lastindex];
                                    item.IsEmpty = true;

                                    lastindex = _chart2.Series[0].Points.AddXY(_list_TimePointInfo[index].Time, 0);
                                    item = _chart2.Series[0].Points[lastindex];
                                    item.IsEmpty = true;
                                }
                            }
                            else
                            {
                                double sum = _list_TimePointInfo[index].DS_Accessary_Count + _list_TimePointInfo[index].DS_Tossing_Count;
                                if (sum == 0)
                                {
                                    sum = 1;
                                }
                                _chart1.Series[0].Points.AddXY(_list_TimePointInfo[index].Time, _list_TimePointInfo[index].DS_Tossing_Count);
                                _chart2.Series[0].Points.AddXY(_list_TimePointInfo[index].Time, _list_TimePointInfo[index].DS_Tossing_Count / sum);
                                sum = _list_TimePointInfo[index].NS_Accessary_Count + _list_TimePointInfo[index].NS_Tossing_Count;
                                if (sum == 0)
                                {
                                    sum = 1;
                                }
                                _chart1.Series[1].Points.AddXY(_list_TimePointInfo[index].Time, _list_TimePointInfo[index].NS_Tossing_Count);
                                _chart2.Series[1].Points.AddXY(_list_TimePointInfo[index].Time, _list_TimePointInfo[index].NS_Tossing_Count / sum);
                            }
                        }
                    }
                    break;
                case 2:
                    {
                        //计算Yield
                        _chart1.Series[1].Points.Clear();
                        _chart2.Series[1].Points.Clear();

                        double sum = 0;
                        double yield = 0;

                        for (int index = 0; index < _list_TimePointInfo_yield_chart1.Count; index++)
                        {
                            #region 图1用 Day

                            sum = _list_TimePointInfo_yield_chart1[index].DS_OK_Count + _list_TimePointInfo_yield_chart1[index].DS_NG_Count;
                            yield = 0;
                            if (sum != 0)
                            {
                                yield = Math.Round(_list_TimePointInfo_yield_chart1[index].DS_OK_Count / sum, 4);
                            }
                            _chart1.Series[0].Points.AddXY(_list_TimePointInfo_yield_chart1[index].Time, yield * 100);

                            sum = _list_TimePointInfo_yield_chart1[index].NS_OK_Count + _list_TimePointInfo_yield_chart1[index].NS_NG_Count;
                            yield = 0;
                            if (sum != 0)
                            {
                                yield = Math.Round(_list_TimePointInfo_yield_chart1[index].NS_OK_Count / sum, 4);
                            }
                            _chart1.Series[1].Points.AddXY(_list_TimePointInfo_yield_chart1[index].Time, yield * 100);

                            #endregion
                        }

                        sum = 0;
                        yield = 0;

                        for (int index = 0; index < _list_TimePointInfo.Count; index++)
                        {
                            #region 图2用 Hour

                            string axisLabel = _list_TimePointInfo[index].Time.ToString("HH:00")
                                                + "-"
                                                + _list_TimePointInfo[index].Time.AddHours(1).ToString("HH:00")
                                                + "\n"
                                                + _list_TimePointInfo[index].Time.ToString("yyyy/MM/dd");
                            if (_list_TimePointInfo[index].Time.Hour >= startTime_hourInDay && _list_TimePointInfo[index].Time.Hour < startTime_hourInDay + 12)
                            {
                                sum = _list_TimePointInfo[index].DS_OK_Count + _list_TimePointInfo[index].DS_NG_Count;
                                yield = 0;
                                if (sum != 0)
                                {
                                    yield = Math.Round(_list_TimePointInfo[index].DS_OK_Count / sum, 4);
                                }

                                lastindex = _chart2.Series[0].Points.AddXY(_list_TimePointInfo[index].Time, yield * 100);
                                item = _chart2.Series[0].Points[lastindex];
                                item.Name = item.AxisLabel = axisLabel;

                                lastindex = _chart2.Series[1].Points.AddXY(_list_TimePointInfo[index].Time, 0);
                                item = _chart2.Series[1].Points[lastindex];
                                item.IsEmpty = true;
                            }
                            else
                            {
                                sum = _list_TimePointInfo[index].NS_OK_Count + _list_TimePointInfo[index].NS_NG_Count;
                                yield = 0;
                                if (sum != 0)
                                {
                                    yield = Math.Round(_list_TimePointInfo[index].NS_OK_Count / sum, 4);
                                }

                                lastindex = _chart2.Series[1].Points.AddXY(_list_TimePointInfo[index].Time, yield * 100);
                                item = _chart2.Series[1].Points[lastindex];
                                item.Name = item.AxisLabel = axisLabel;

                                lastindex = _chart2.Series[0].Points.AddXY(_list_TimePointInfo[index].Time, 0);
                                item = _chart2.Series[0].Points[lastindex];
                                item.IsEmpty = true;
                            }

                            #endregion
                        }
                    }
                    break;
            }
        }

        //小时 抛料
        private void InitMode1()
        {
            var font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));

            _chart1.ChartAreas.Clear();
            _chart1.ChartAreas.Add(new ChartArea());
            var area = _chart1.ChartAreas[0];
            area.BackColor = pnl_Chart2.BackColor;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisY.MajorGrid.LineWidth = 1;
            area.AxisY.MajorGrid.LineColor = Color.DimGray;
            area.AxisY.MajorTickMark.Enabled = false;
            area.AxisX.LabelStyle.Format = "(HH:mm)\n\ryyyy/MM/dd";

            _chart1.Legends.Clear();
            _chart1.Legends.Add(new Legend());
            var legend = _chart1.Legends[0];
            legend.Docking = Docking.Top;
            legend.TitleAlignment = StringAlignment.Far;
            legend.BackColor = _chart1.BackColor;

            _chart1.Series.Clear();
            _chart1.Series.Add(new Series());
            var series = _chart1.Series[0];
            series.ChartArea = area.Name;
            series.Legend = legend.Name;
            series.Tag = "DS_Tossing";
            series.ToolTip = "时间：#VALX\n当前值：#VALY";
            series.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + series.Tag, "DS Tossing");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.BorderWidth = 2;
            series.CustomProperties = "LabelStyle=Top, MaxPixelPointWidth=70";
            series.Font = font;
            series.LabelForeColor = Color.FromArgb(84, 151, 193);
            series.Color = Color.FromArgb(84, 151, 193);

            _chart1.Series.Add(new Series());
            series = _chart1.Series[1];
            series.ChartArea = area.Name;
            series.Legend = legend.Name;
            series.Tag = "NS_Tossing";
            series.ToolTip = "时间：#VALX\n当前值：#VALY";
            series.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + series.Tag, "NS Tossing");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.BorderWidth = 2;
            series.CustomProperties = "LabelStyle=Top, MaxPixelPointWidth=70";
            series.Font = font;
            series.LabelForeColor = Color.FromArgb(111, 121, 128);
            series.Color = Color.FromArgb(111, 121, 128);

            _chart2.ChartAreas.Clear();
            _chart2.ChartAreas.Add(new ChartArea());
            area = _chart2.ChartAreas[0];
            area.BackColor = pnl_Chart2.BackColor;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisY.MajorGrid.LineWidth = 1;
            area.AxisY.MajorGrid.LineColor = Color.DimGray;
            area.AxisY.MajorTickMark.Enabled = false;
            area.AxisY.LabelStyle.Format = "P0";
            area.AxisX.LabelStyle.Format = "(HH:mm)\n\ryyyy/MM/dd";

            _chart2.Legends.Clear();
            _chart2.Legends.Add(new Legend());
            legend = _chart2.Legends[0];
            legend.Docking = Docking.Top;
            legend.TitleAlignment = StringAlignment.Far;
            legend.BackColor = _chart1.BackColor;

            _chart2.Series.Clear();
            _chart2.Series.Add(new Series());
            series = _chart2.Series[0];
            series.ChartArea = area.Name;
            series.Legend = legend.Name;
            series.Tag = "DS_Tossing_Rate";
            series.ToolTip = "时间：#VALX\n当前值：#VALY";
            series.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + series.Tag, "DS Tossing Rate%");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.BorderWidth = 2;
            series.CustomProperties = "LabelStyle=Top, MaxPixelPointWidth=70";
            series.Font = font;
            series.LabelFormat = "P0";
            //series.LabelForeColor = Color.FromArgb(84, 151, 193);
            series.LabelForeColor = Color.Black;
            series.Color = Color.FromArgb(84, 151, 193);

            _chart2.Series.Add(new Series());
            series = _chart2.Series[1];
            series.ChartArea = area.Name;
            series.Legend = legend.Name;
            series.Tag = "NS_Tossing_Rate";
            series.ToolTip = "时间：#VALX\n当前值：#VALY";
            series.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + series.Tag, "NS Tossing Rate%");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.BorderWidth = 2;
            series.CustomProperties = "LabelStyle=Top, MaxPixelPointWidth=70";
            series.Font = font;
            series.LabelFormat = "P0";
            //series.LabelForeColor = Color.FromArgb(111, 121, 128);
            series.LabelForeColor = Color.Black;
            series.Color = Color.FromArgb(111, 121, 128);
        }

        //天 抛料
        private void InitMode2()
        {
            var font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));

            _chart1.ChartAreas.Clear();
            _chart1.ChartAreas.Add(new ChartArea());
            var area = _chart1.ChartAreas[0];
            area.BackColor = pnl_Chart2.BackColor;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisY.MajorGrid.LineWidth = 1;
            area.AxisY.MajorGrid.LineColor = Color.DimGray;
            area.AxisY.MajorTickMark.Enabled = false;

            _chart1.Legends.Clear();
            _chart1.Legends.Add(new Legend());
            var legend = _chart1.Legends[0];
            legend.Docking = Docking.Top;
            legend.TitleAlignment = StringAlignment.Far;
            legend.BackColor = _chart1.BackColor;


            _chart1.Series.Clear();
            _chart1.Series.Add(new Series());
            var series = _chart1.Series[0];
            series.ChartArea = area.Name;
            series.Legend = legend.Name;
            series.Tag = "DS_Tossing";
            series.ToolTip = "时间：#VALX\n当前值：#VALY";
            series.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + series.Tag, "DS Tossing");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.BorderWidth = 2;
            series.CustomProperties = "LabelStyle=Top, MaxPixelPointWidth=70";
            series.Font = font;
            series.LabelForeColor = Color.FromArgb(84, 151, 193);
            series.Color = Color.FromArgb(84, 151, 193);

            _chart1.Series.Add(new Series());
            series = _chart1.Series[1];
            series.ChartArea = area.Name;
            series.Legend = legend.Name;
            series.Tag = "NS_Tossing";
            series.ToolTip = "时间：#VALX\n当前值：#VALY";
            series.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + series.Tag, "NS Tossing");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.BorderWidth = 2;
            series.CustomProperties = "LabelStyle=Top, MaxPixelPointWidth=70";
            series.Font = font;
            series.LabelForeColor = Color.FromArgb(111, 121, 128);
            series.Color = Color.FromArgb(111, 121, 128);


            _chart2.ChartAreas.Clear();
            _chart2.ChartAreas.Add(new ChartArea());
            area = _chart2.ChartAreas[0];
            area.BackColor = pnl_Chart2.BackColor;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisY.MajorGrid.LineWidth = 1;
            area.AxisY.MajorGrid.LineColor = Color.DimGray;
            area.AxisY.MajorTickMark.Enabled = false;
            area.AxisY.LabelStyle.Format = "P0";

            _chart2.Legends.Clear();
            _chart2.Legends.Add(new Legend());
            legend = _chart2.Legends[0];
            legend.Docking = Docking.Top;
            legend.TitleAlignment = StringAlignment.Far;
            legend.BackColor = _chart1.BackColor;

            _chart2.Series.Clear();
            _chart2.Series.Add(new Series());
            series = _chart2.Series[0];
            series.ChartArea = area.Name;
            series.Legend = legend.Name;
            series.Tag = "DS_Tossing_Rate";
            series.ToolTip = "时间：#VALX\n当前值：#VALY";
            series.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + series.Tag, "DS Tossing Rate%");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.BorderWidth = 2;
            series.CustomProperties = "LabelStyle=Top, MaxPixelPointWidth=70";
            series.Font = font;
            series.LabelFormat = "P0";
            //series.LabelForeColor = Color.FromArgb(84, 151, 193);
            series.LabelForeColor = Color.Black;
            series.Color = Color.FromArgb(84, 151, 193);

            _chart2.Series.Add(new Series());
            series = _chart2.Series[1];
            series.ChartArea = area.Name;
            series.Legend = legend.Name;
            series.Tag = "NS_Tossing_Rate";
            series.ToolTip = "时间：#VALX\n当前值：#VALY";
            series.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + series.Tag, "NS Tossing Rate%");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.BorderWidth = 2;
            series.CustomProperties = "LabelStyle=Top, MaxPixelPointWidth=70";
            series.Font = font;
            series.LabelFormat = "P0";
            //series.LabelForeColor = Color.FromArgb(111, 121, 128);
            series.LabelForeColor = Color.Black;
            series.Color = Color.FromArgb(111, 121, 128);
        }

        //小时 CT
        private void InitMode3()
        {
            var font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));

            _chart1.ChartAreas.Clear();
            _chart1.ChartAreas.Add(new ChartArea());
            var area = _chart1.ChartAreas[0];
            area.BackColor = pnl_Chart2.BackColor;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisY.MajorGrid.LineWidth = 1;
            area.AxisY.MajorGrid.LineColor = Color.DimGray;
            area.AxisY.MajorTickMark.Enabled = false;
            area.AxisX.LabelStyle.Format = "(HH:mm)\n\ryyyy/MM/dd";

            _chart1.Legends.Clear();
            _chart1.Legends.Add(new Legend());
            var legend = _chart1.Legends[0];
            legend.Docking = Docking.Top;
            legend.TitleAlignment = StringAlignment.Far;
            legend.BackColor = _chart1.BackColor;

            _chart1.Series.Clear();
            _chart1.Series.Add(new Series());
            var series = _chart1.Series[0];
            series.ChartArea = area.Name;
            series.Legend = legend.Name;
            series.Tag = "DS_Output_CT";
            series.ToolTip = "DS Output_CT";
            series.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + series.Tag, series.ToolTip);
            series.ChartType = SeriesChartType.Line;
            series.IsValueShownAsLabel = true;
            series.BorderWidth = 2;
            series.MarkerStyle = MarkerStyle.Circle;
            series.Font = font;
            series.LabelForeColor = Color.FromArgb(84, 151, 193);
            series.Color = Color.FromArgb(84, 151, 193);

            _chart1.Series.Add(new Series());
            series = _chart1.Series[1];
            series.ChartArea = area.Name;
            series.Legend = legend.Name;
            series.Tag = "NS_Output_CT";
            series.ToolTip = "NS Output_CT";
            series.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + series.Tag, series.ToolTip);
            series.ChartType = SeriesChartType.Line;
            series.IsValueShownAsLabel = true;
            series.BorderWidth = 2;
            series.MarkerStyle = MarkerStyle.Circle;
            series.Font = font;
            series.LabelForeColor = Color.FromArgb(111, 121, 128);
            series.Color = Color.FromArgb(111, 121, 128);

            _chart2.ChartAreas.Clear();
            _chart2.ChartAreas.Add(new ChartArea());
            area = _chart2.ChartAreas[0];
            area.BackColor = pnl_Chart2.BackColor;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisY.MajorGrid.LineWidth = 1;
            area.AxisY.MajorGrid.LineColor = Color.DimGray;
            area.AxisY.MajorTickMark.Enabled = false;
            area.AxisX.LabelStyle.Format = "(HH:mm)\n\ryyyy/MM/dd";

            _chart2.Legends.Clear();
            _chart2.Legends.Add(new Legend());
            legend = _chart2.Legends[0];
            legend.Docking = Docking.Top;
            legend.TitleAlignment = StringAlignment.Far;
            legend.BackColor = _chart1.BackColor;

            _chart2.Series.Clear();
            _chart2.Series.Add(new Series());
            series = _chart2.Series[0];
            series.ChartArea = area.Name;
            series.Legend = legend.Name;
            series.Tag = "DS_Output";
            series.ToolTip = "DS Output";
            series.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + series.Tag, series.ToolTip);
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.BorderWidth = 2;
            series.CustomProperties = "LabelStyle=Top, MaxPixelPointWidth=70";
            series.Font = font;
            //series.LabelForeColor = Color.FromArgb(84, 151, 193);
            series.LabelForeColor = Color.Black;
            series.Color = Color.FromArgb(84, 151, 193);

            _chart2.Series.Add(new Series());
            series = _chart2.Series[1];
            series.ChartArea = area.Name;
            series.Legend = legend.Name;
            series.Tag = "NS_Output";
            series.ToolTip = "NS Output";
            series.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + series.Tag, series.ToolTip);
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.BorderWidth = 2;
            series.CustomProperties = "LabelStyle=Top, MaxPixelPointWidth=70";
            series.Font = font;
            //series.LabelForeColor = Color.FromArgb(111, 121, 128);
            series.LabelForeColor = Color.Black;
            series.Color = Color.FromArgb(111, 121, 128);
        }

        //天 CT
        private void InitMode4()
        {
            var font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));

            _chart1.ChartAreas.Clear();
            _chart1.ChartAreas.Add(new ChartArea());
            var area = _chart1.ChartAreas[0];
            area.BackColor = pnl_Chart2.BackColor;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisY.MajorGrid.LineWidth = 1;
            area.AxisY.MajorGrid.LineColor = Color.DimGray;
            area.AxisY.MajorTickMark.Enabled = false;

            _chart1.Legends.Clear();
            _chart1.Legends.Add(new Legend());
            var legend = _chart1.Legends[0];
            legend.Docking = Docking.Top;
            legend.TitleAlignment = StringAlignment.Far;
            legend.BackColor = _chart1.BackColor;


            _chart1.Series.Clear();
            _chart1.Series.Add(new Series());
            var series = _chart1.Series[0];
            series.ChartArea = area.Name;
            series.Legend = legend.Name;
            series.Tag = "DS_Output_CT";
            series.ToolTip = "DS Output_CT";
            series.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + series.Tag, series.ToolTip);
            series.ChartType = SeriesChartType.Line;
            series.IsValueShownAsLabel = true;
            series.BorderWidth = 2;
            series.MarkerStyle = MarkerStyle.Circle;
            series.Font = font;
            series.LabelForeColor = Color.FromArgb(84, 151, 193);
            series.Color = Color.FromArgb(84, 151, 193);


            _chart1.Series.Add(new Series());
            series = _chart1.Series[1];
            series.ChartArea = area.Name;
            series.Legend = legend.Name;
            series.Tag = "NS_Output_CT";
            series.ToolTip = "NS Output_CT";
            series.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + series.Tag, series.ToolTip);
            series.ChartType = SeriesChartType.Line;
            series.IsValueShownAsLabel = true;
            series.BorderWidth = 2;
            series.MarkerStyle = MarkerStyle.Circle;
            series.Font = font;
            series.LabelForeColor = Color.FromArgb(111, 121, 128);
            series.Color = Color.FromArgb(111, 121, 128);

            _chart2.ChartAreas.Clear();
            _chart2.ChartAreas.Add(new ChartArea());
            area = _chart2.ChartAreas[0];
            area.BackColor = pnl_Chart2.BackColor;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisY.MajorGrid.LineWidth = 1;
            area.AxisY.MajorGrid.LineColor = Color.DimGray;
            area.AxisY.MajorTickMark.Enabled = false;

            _chart2.Legends.Clear();
            _chart2.Legends.Add(new Legend());
            legend = _chart2.Legends[0];
            legend.Docking = Docking.Top;
            legend.TitleAlignment = StringAlignment.Far;
            legend.BackColor = _chart1.BackColor;

            _chart2.Series.Clear();
            _chart2.Series.Add(new Series());
            series = _chart2.Series[0];
            series.ChartArea = area.Name;
            series.Legend = legend.Name;
            series.Tag = "DS_Output";
            series.ToolTip = "DS Output";
            series.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + series.Tag, series.ToolTip);
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.BorderWidth = 2;
            series.CustomProperties = "LabelStyle=Top, MaxPixelPointWidth=70";
            series.Font = font;
            //series.LabelForeColor = Color.FromArgb(84, 151, 193);
            series.LabelForeColor = Color.Black;
            series.Color = Color.FromArgb(84, 151, 193);

            _chart2.Series.Add(new Series());
            series = _chart2.Series[1];
            series.ChartArea = area.Name;
            series.Legend = legend.Name;
            series.Tag = "NS_Output";
            series.ToolTip = "NS Output";
            series.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + series.Tag, series.ToolTip);
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.BorderWidth = 2;
            series.CustomProperties = "LabelStyle=Top, MaxPixelPointWidth=70";
            series.Font = font;
            //series.LabelForeColor = Color.FromArgb(111, 121, 128);
            series.LabelForeColor = Color.Black;
            series.Color = Color.FromArgb(111, 121, 128);
        }

        //天 小时 Yield
        private void InitMode5()
        {
            var font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));

            _chart1.ChartAreas.Clear();
            _chart1.ChartAreas.Add(new ChartArea());
            var area = _chart1.ChartAreas[0];
            area.BackColor = pnl_Chart2.BackColor;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisY.MajorGrid.LineWidth = 1;
            area.AxisY.MajorGrid.LineColor = Color.DimGray;
            area.AxisY.MajorTickMark.Enabled = false;
            area.AxisY.Maximum = 100;

            _chart1.Legends.Clear();
            _chart1.Legends.Add(new Legend());
            var legend = _chart1.Legends[0];
            legend.Docking = Docking.Top;
            legend.TitleAlignment = StringAlignment.Far;
            legend.BackColor = _chart1.BackColor;


            _chart1.Series.Clear();
            _chart1.Series.Add(new Series());
            var series = _chart1.Series[0];
            series.ChartArea = area.Name;
            series.Legend = legend.Name;
            series.Tag = "DS_Yield_Daily";
            series.ToolTip = "DS Yield %(Daily)";
            series.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + series.Tag, series.ToolTip);
            series.ChartType = SeriesChartType.Line;
            series.IsValueShownAsLabel = true;
            series.BorderWidth = 2;
            series.MarkerStyle = MarkerStyle.Circle;
            series.Font = font;
            series.LabelFormat = "f2";
            series.LabelForeColor = Color.FromArgb(84, 151, 193);
            series.Color = Color.FromArgb(84, 151, 193);


            _chart1.Series.Add(new Series());
            series = _chart1.Series[1];
            series.ChartArea = area.Name;
            series.Legend = legend.Name;
            series.Tag = "NS_Yield_Daily";
            series.ToolTip = "NS Yield %(Daily)";
            series.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + series.Tag, series.ToolTip);
            series.ChartType = SeriesChartType.Line;
            series.IsValueShownAsLabel = true;
            series.BorderWidth = 2;
            series.MarkerStyle = MarkerStyle.Circle;
            series.Font = font;
            series.LabelFormat = "f2";
            series.LabelForeColor = Color.FromArgb(111, 121, 128);
            series.Color = Color.FromArgb(111, 121, 128);

            _chart2.ChartAreas.Clear();
            _chart2.ChartAreas.Add(new ChartArea());
            area = _chart2.ChartAreas[0];
            area.BackColor = pnl_Chart2.BackColor;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisY.MajorGrid.LineWidth = 1;
            area.AxisY.MajorGrid.LineColor = Color.DimGray;
            area.AxisY.MajorTickMark.Enabled = false;
            area.AxisY.Maximum = 100;

            _chart2.Legends.Clear();
            _chart2.Legends.Add(new Legend());
            legend = _chart2.Legends[0];
            legend.Docking = Docking.Top;
            legend.TitleAlignment = StringAlignment.Far;
            legend.BackColor = _chart1.BackColor;

            _chart2.Series.Clear();
            _chart2.Series.Add(new Series());
            series = _chart2.Series[0];
            series.ChartArea = area.Name;
            series.Legend = legend.Name;
            series.Tag = "DS_Yield_Hourly";
            series.ToolTip = "DS Yield %(Hourly)";
            series.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + series.Tag, series.ToolTip);
            series.ChartType = SeriesChartType.Line;
            series.IsValueShownAsLabel = true;
            series.BorderWidth = 2;
            series.CustomProperties = "LabelStyle=Top, MaxPixelPointWidth=70";
            series.Font = font;
            series.LabelFormat = "f2";
            //series.LabelForeColor = Color.FromArgb(84, 151, 193);
            series.LabelForeColor = Color.Black;
            series.Color = Color.FromArgb(84, 151, 193);

            _chart2.Series.Add(new Series());
            series = _chart2.Series[1];
            series.ChartArea = area.Name;
            series.Legend = legend.Name;
            series.Tag = "NS_Yield_Hourly";
            series.ToolTip = "NS Yield %(Hourly)";
            series.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + series.Tag, series.ToolTip);
            series.ChartType = SeriesChartType.Line;
            series.IsValueShownAsLabel = true;
            series.BorderWidth = 2;
            series.CustomProperties = "LabelStyle=Top, MaxPixelPointWidth=70";
            series.Font = font;
            series.LabelFormat = "f2";
            //series.LabelForeColor = Color.FromArgb(111, 121, 128);
            series.LabelForeColor = Color.Black;
            series.Color = Color.FromArgb(111, 121, 128);
        }

        private void hsb_Chart1_ValueChanged(object sender, EventArgs e)
        {
            if (hsb_Chart1.Maximum == 1)
            {
                return;
            }

            switch (SWBn_IO_Tossing_Yield.SelectTextIndex)
            {
                case 0:
                case 1:
                default:
                    if (!SWBn_Day_Hour.Checked)
                    {
                        SetAxisLimitByDay(0, _list_TimePointInfo[hsb_Chart1.Value].Time, _list_TimePointInfo[hsb_Chart1.Value + 6].Time);
                    }
                    else
                    {
                        SetAxisLimitByHour(0, _list_TimePointInfo[hsb_Chart1.Value].Time, _list_TimePointInfo[hsb_Chart1.Value + 11].Time);
                    }
                    break;
                case 2:
                    {
                        SetAxisLimitByDay(0, _list_TimePointInfo[hsb_Chart1.Value].Time, _list_TimePointInfo[hsb_Chart1.Value + 6].Time);
                    }
                    break;
            }
        }

        private void hsb_Chart2_ValueChanged(object sender, EventArgs e)
        {
            if (hsb_Chart2.Maximum == 1)
            {
                return;
            }

            switch (SWBn_IO_Tossing_Yield.SelectTextIndex)
            {
                case 0:
                case 1:
                default:
                    if (!SWBn_Day_Hour.Checked)
                    {
                        SetAxisLimitByDay(1, _list_TimePointInfo[hsb_Chart2.Value].Time, _list_TimePointInfo[hsb_Chart2.Value + 6].Time);
                    }
                    else
                    {
                        SetAxisLimitByHour(1, _list_TimePointInfo[hsb_Chart2.Value].Time, _list_TimePointInfo[hsb_Chart2.Value + 11].Time);
                    }
                    break;
                case 2:
                    {
                        SetAxisLimitByHour(1, _list_TimePointInfo[hsb_Chart2.Value].Time, _list_TimePointInfo[hsb_Chart2.Value + 11].Time);
                    }
                    break;
            }
        }

        public void OnLanguageChanged()
        {
            //SWBn_IO_Tossing_Yield.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_Tossing", "抛料");
            btnExport.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_Export", "导出");
            SWBn_Day_Hour.UnCheckedText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_Day", "天");
            SWBn_Day_Hour.CheckedText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_Hour", "小时");

            foreach (var item in _chart1.Series)
            {
                item.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + item.Tag.ToString(), item.ToolTip);
            }
            foreach (var item in _chart2.Series)
            {
                item.LegendText = NLocalizer.GetString("Lead_CPrim_StationCommon_DataForm_" + item.Tag.ToString(), item.ToolTip);
            }
        }

        private void time_Updata_StationStatistic_Tick(object sender, EventArgs e)
        {
            //station统计下一次更新节点
            if (DateTime.Now.Hour < startTime_hourInDay)
            {
                //当前时间小于8点 
                DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startTime_hourInDay, 0, 0);
                time_Updata_StationStatistic.Interval = (int)time.Subtract(DateTime.Now).TotalMilliseconds + 100;
            }
            else if (DateTime.Now.Hour >= startTime_hourInDay && (DateTime.Now.Hour < (startTime_hourInDay + 12)))
            {
                //当前时间大于等于8点 且小于20点
                DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startTime_hourInDay, 0, 0).AddHours(12);
                time_Updata_StationStatistic.Interval = (int)time.Subtract(DateTime.Now).TotalMilliseconds + 100;
            }
            else
            {
                //当前时间大于等于20点
                DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startTime_hourInDay, 0, 0).AddHours(24);
                time_Updata_StationStatistic.Interval = (int)time.Subtract(DateTime.Now).TotalMilliseconds + 100;
            }

            lock (locker_Updata_StationStatistic)
            {
                _station.TotalOk = 0;
                _station.TotalNg = 0;
                _station.TotalInvalid = 0;
                _station.TotalCount = 0;

                UpdateNumCount($"{_station.TotalCount}/{_station.TotalOk}");
                UpdateNum($"{_station.TotalOk}/{_station.TotalNg}");
                UpdatePassRate(0);

                dicReasonTossing.Clear();
                UpdateNumber(dicReasonTossing);
            }
        }

        private static object locker_Updata_StationStatistic = new object();
    }



    public class TimePointInfo
    {
        /// <summary>
        /// 班次<br/>
        /// true,白班；false,夜班；
        /// </summary>
        public bool Shift { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Time { get; set; }

        public int DS_OK_Count { get; set; }
        public int DS_NG_Count { get; set; }
        public int NS_OK_Count { get; set; }
        public int NS_NG_Count { get; set; }

        public int DS_Tossing_Count { get; set; }
        public int DS_Accessary_Count { get; set; }
        public int NS_Tossing_Count { get; set; }
        public int NS_Accessary_Count { get; set; }

        public double DS_CT_Sum { get; set; }
        public double NS_CT_Sum { get; set; }
    }
}