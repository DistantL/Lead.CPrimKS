using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lead.CPrim.StationCommon
{
    public partial class DataLineChart : UserControl
    {
        #region Field
        /// <summary>OK计数</summary>
        private Dictionary<DateTime, int> _dicCount = new Dictionary<DateTime, int>();
        #endregion



        #region Ctor
        public DataLineChart()
        {
            InitializeComponent();
        }
        #endregion



        #region Method_ExternalUsing
        internal void InitChart(DateTime max, DateTime min) 
        {
            //图表初始化
            List<ChartDatas> datas = new List<ChartDatas>()
            {
                new ChartDatas
                {
                    Name = "Count",
                    ChartColor = Color.FromArgb(105, 157, 194),
                    ChartType = SeriesChartType.Line,
                },
            };
            CustomChart.InitChart(ref chart1, datas, max, min, 1, DateTimeIntervalType.Hours, "MM/dd HH");
            chart1.Series[0].BorderWidth = 2;
        }

        internal void ChartControl(DateTime index, double value) 
        {
            chart1.Series[0].Points.AddXY(index, value);
            chart1.Series[0].LabelFormat = "f2";
        }

        /// <summary>图表刷新数据（建议数据一次性进行更新）</summary>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <param name="day"></param>
        /// <param name="count"></param>
        /// <param name="isAppend">true：数据追加；false：更新数据（默认更新数据）</param>
        internal void ChartControl(DateTime max, DateTime min, DateTime day, int count, bool isAppend = false)
        {
            //图表初始化
            List<ChartDatas> datas = new List<ChartDatas>()
            {
                new ChartDatas
                {
                    Name = "Count",
                    ChartColor = Color.FromArgb(105, 157, 194),
                    ChartType = SeriesChartType.Line,
                },
            };
            CustomChart.InitChart(ref chart1, datas, max, min, 1, DateTimeIntervalType.Hours, "MM/dd HH");

            // 数据进行处理
            if (_dicCount.ContainsKey(day))
            {
                if (isAppend)
                {
                    _dicCount[day] += count;
                }
                else
                {
                    _dicCount[day] = count;
                }
            }
            else
            {
                _dicCount.Add(day, count);
            }

            // 增加数据
            foreach (var item in _dicCount.OrderBy(t => t.Key))
            {
                if (item.Key >= min && item.Key <= max)
                {
                    chart1.Series[0].Points.AddXY(item.Key, item.Value);
                }
            }
        }

        /// <summary>图表刷新数据（建议数据逐条追加）</summary>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <param name="day"></param>
        /// <param name="result"></param>
        /// <param name="isAppend">true：数据追加；false：更新数据（默认更新数据）</param>
        internal void ChartControl(DateTime max, DateTime min, DateTime day, bool result, bool isAppend = true)
        {
            //图表初始化
            List<ChartDatas> datas = new List<ChartDatas>()
            {
                new ChartDatas
                {
                    Name = "Count",
                    ChartColor = Color.FromArgb(105, 157, 194),
                    ChartType = SeriesChartType.Line,
                },
            };
            CustomChart.InitChart(ref chart1, datas, max, min, 1, DateTimeIntervalType.Hours, "MM/dd HH");

            //数据进行处理
            if (_dicCount.ContainsKey(day))
            {
                if (isAppend)
                {
                    _dicCount[day]++;
                }
                else
                {
                    _dicCount[day] = 1;
                }
            }
            else
            {
                _dicCount.Add(day, 1);
            }

            //增加数据
            foreach (var item in _dicCount.OrderBy(t => t.Key))
            {
                if (item.Key >= min && item.Key <= max)
                {
                    chart1.Series[0].Points.AddXY(item.Key, item.Value);
                }
            }
        }

        internal void ChartClear() 
        {
            chart1.Series[0].Points.Clear();
        }
        #endregion
    }
}
