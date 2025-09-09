using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProductInfoHelper;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Lead.CPrim.StationCommon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lead.CPrim.ShowCapacityOfProduction.Controls
{
    public partial class AnalysisMode : UIPage
    {
        #region Ctor
        public AnalysisMode()
        {
            InitializeComponent();
            CustomChart.InitChartAnalysis(chart1, "FAI解析");
        } 
        #endregion



        #region Button_Event
        /// <summary>查询</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Restart();
                Cursor = Cursors.WaitCursor;
                List<ProductInfo> lP = new List<ProductInfo>();
                Dictionary<DateTime, double> keyValuesFai = new Dictionary<DateTime, double>();
                int ret = -1;
                if(string.IsNullOrEmpty(cbFai.SelectedItem?.ToString()))
                {
                    throw new Exception("未选择FAI项");
                }
                chart1.Titles[0].Text = $"FAI解析_{cbFai.SelectedItem}";
                chart1.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
                ret = MongodbHelper.QueryManyByTime(dpStart.Value, dpEnd.Value, out lP, $"{StationManager.Instance.CurrentStationName}_{SwManager.Instance.CurrentProduct}" );
                if(ret != 0)
                {
                    throw new Exception($"QueryManyByTime返回值 = {ret}");
                }
                foreach (var item in lP)
                {
                    if(item.Fai.ContainsKey(cbFai.SelectedItem.ToString()))
                    {
                        keyValuesFai.Add(item.CreateTime, (double)item.Fai[cbFai.SelectedItem]);
                    }
                }
                chart1.Series[0].Points.Clear();
                foreach (var item in keyValuesFai)
                {
                    if((int)item.Value > 100 || (int)item.Value < -100)
                    {
                        continue;
                    }
                    chart1.Series[0].Points.AddXY(item.Key, item.Value);
                }
                sw.Stop();
                LogAdd($"查询成功，耗时{sw.ElapsedMilliseconds}ms", LogLevel.Info);
            }
            catch (Exception ex)
            {
                LogAdd($"查询失败：{ex.Message}", LogLevel.Warn);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        } 
        #endregion



        #region Method_ExternalUsing
        /// <summary>FAI更新</summary>
        /// <param name="lName"></param>
        public void CbInit(List<string> lName)
        {
            if(lName != null && lName.Count > 1)
            {
                cbFai.Items.Clear();
                lName.ForEach(name => cbFai.Items.Add(name));
                cbFai.Items.Add("");
                cbFai.SelectedIndex = -1;
            }
        }
        /// <summary>时间更新</summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void TimeInit(DateTime start, DateTime end)
        {
            dpStart.Value = start;
            dpEnd.Value = end;
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>日志增加</summary>
        /// <param name="msg">消息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示报警弹窗；false：不显示报警弹窗</param>
        private void LogAdd(string msg, LogLevel lv, int id = 0, bool isShowDialog = false)
        {
            string tempId = $"{(int)lv}{(int)PrimLogId.ShowCapacityOfProduction}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, PrimLogId.ShowCapacityOfProduction.ToString(), LogClassification.Other, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
            }
        }
        #endregion
    }
}
