using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lead.CPrim.StationCommon.Alert
{
    public partial class AlertFrmChartColumn : UIUserControl
    {
        #region Field
        /// <summary>X轴名称</summary>
        private string[] _axisXLable = new string[] { "0--5", "5--10", "10--15", "15--20", "20--25", "25+" };
        #endregion



        #region Ctor
        public AlertFrmChartColumn()
        {
            InitializeComponent();
            List<ChartDatas> datas = new List<ChartDatas>
            {
                new ChartDatas
                {
                    Name = "Alarm Durations",
                    ChartColor = Color.FromArgb(237, 129, 127),
                    ChartType = SeriesChartType.Column,
                },
            };
            CustomChart.InitChart(ref chart1, datas, _axisXLable, "", false, "Alarm Durations");
            chart1.ChartAreas[0].AxisX.IntervalOffset = 0.6;
            chart1.Series[0].ToolTip = "";

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>图表刷新数据</summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        internal void ChartControl(int index, int count)
        {
            chart1.Series[0].Points.AddXY(index, count);
            foreach (var item in chart1.Series[0].Points)
            {
                if (item.YValues[0] == 0)
                {
                    item.IsEmpty = true;
                }
            }
        }

        internal void ChartClear() 
        {
            chart1.Series[0].Points.Clear();
        }
        #endregion



        #region Event_System
        private void FrmBarChart_Load(object sender, EventArgs e)
        {

        }
        #endregion

        public void OnLanguageChanged()
        {
            chart1.ChartAreas[0].AxisX.Title = NLocalizer.GetString("Lead_CPrim_StationCommon_Alert_AlertFrmChartColumn_Title", "报警持续时间");
        }
    }
}
