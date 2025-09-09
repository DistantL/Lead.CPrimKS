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
    public partial class DataBarChart : UserControl
    {
        #region Field
        /// <summary>OK计数</summary>
        private Dictionary<DateTime, int> _dicOk = new Dictionary<DateTime, int>();
        /// <summary>NG计数</summary>
        private Dictionary<DateTime, int> _dicNg = new Dictionary<DateTime, int>();
        #endregion



        #region Ctor
        public DataBarChart()
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
                    Name = "Day_Pass",
                    ChartColor = Color.FromArgb(90, 150, 192),
                    ChartType = SeriesChartType.Column,
                },
                new ChartDatas
                {
                    Name = "Day_Fail",
                    ChartColor = ColorTranslator.FromHtml("#FFD7D4"),
                    ChartType = SeriesChartType.Column,
                },
                new ChartDatas
                {
                    Name = "Night_Pass",
                    ChartColor = Color.FromArgb(112, 121, 128),
                    ChartType = SeriesChartType.Column,
                },
                new ChartDatas
                {
                    Name = "Night_Fail",
                    ChartColor = ColorTranslator.FromHtml("#EB7373"),
                    ChartType = SeriesChartType.Column,
                }
            };
            CustomChart.InitChart(ref chart1, datas, max, min.AddDays(-1), 1, DateTimeIntervalType.Days, "yyyy/MM/dd", null, true);

            chart1.ChartAreas[0].AxisX.IntervalOffset = 0.5;
            chart1.ChartAreas[0].AxisX.LabelStyle.IntervalOffset = 0.3;
            chart1.ChartAreas[0].AxisX.LabelStyle.IntervalOffsetType = DateTimeIntervalType.Days;
            chart1.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Days;
        }

        internal void ChartControl(int index, DateTime key, int value)
        {
            chart1.Series[index].Points.AddXY(key, value);
        }

        /// <summary>图表刷新数据（建议数据一次性进行更新）</summary>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <param name="day"></param>
        /// <param name="okCount"></param>
        /// <param name="ngCount"></param>
        /// <param name="isAppend">true：数据追加；false：更新数据（默认更新数据）</param>
        public void ChartControl(DateTime max, DateTime min, DateTime day, int okCount, int ngCount, bool isAppend = false)
        {
            //图表初始化
            List<ChartDatas> datas = new List<ChartDatas>()
            {
                new ChartDatas
                {
                    Name = "OK",
                    ChartColor = Color.FromArgb(90, 150, 192),
                    ChartType = SeriesChartType.Column,
                },
                new ChartDatas
                {
                    Name = "NG",
                    ChartColor = Color.FromArgb(112, 121, 128),
                    ChartType = SeriesChartType.Column,
                }
            };
            CustomChart.InitChart(ref chart1, datas, max, min.AddDays(-1), 1, DateTimeIntervalType.Days, "yyyy/MM/dd", null, true);

            //数据进行处理
            if (_dicOk.ContainsKey(day))
            {
                if (isAppend)
                {
                    _dicOk[day] += okCount;
                }
                else
                {
                    _dicOk[day] = okCount;
                }
            }
            else
            {
                _dicOk.Add(day, okCount);
            }

            if (_dicNg.ContainsKey(day))
            {
                if (isAppend)
                {
                    _dicNg[day] += ngCount;
                }
                else
                {
                    _dicNg[day] = ngCount;
                }
            }
            else
            {
                _dicNg.Add(day, ngCount);
            }

            //增加数据
            foreach (var item in _dicOk.OrderBy(t => t.Key))
            {
                if (item.Key >= min && item.Key <= max)
                {
                    chart1.Series[0].Points.AddXY(item.Key, item.Value);
                }
            }
            foreach (var item in _dicNg.OrderBy(t => t.Key))
            {
                if (item.Key >= min && item.Key <= max)
                {
                    chart1.Series[1].Points.AddXY(item.Key, item.Value);
                }
            }
        }

        /// <summary>图表刷新数据（建议数据逐条追加）</summary>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <param name="day"></param>
        /// <param name="result"></param>
        /// <param name="isAppend">true：数据追加；false：更新数据（默认更新数据）</param>
        public void ChartControl(DateTime max, DateTime min, DateTime day, bool result, bool isAppend = true)
        {
            //图表初始化
            List<ChartDatas> datas = new List<ChartDatas>()
            {
                new ChartDatas
                {
                    Name = "OK",
                    ChartColor = Color.FromArgb(90, 150, 192),
                    ChartType = SeriesChartType.Column,
                },
                new ChartDatas
                {
                    Name = "NG",
                    ChartColor = Color.FromArgb(112, 121, 128),
                    ChartType = SeriesChartType.Column,
                }
            };
            CustomChart.InitChart(ref chart1, datas, max, min.AddDays(-1), 1, DateTimeIntervalType.Days, "yyyy/MM/dd");

            //数据进行处理
            if (_dicOk.ContainsKey(day))
            {
                if (isAppend)
                {
                    _dicOk[day]++;
                }
                else
                {
                    _dicOk[day] = 1;
                }
            }
            else
            {
                _dicOk.Add(day, 1);
            }

            if (_dicNg.ContainsKey(day))
            {
                if (isAppend)
                {
                    _dicNg[day]++;
                }
                else
                {
                    _dicNg[day] = 1;
                }
            }
            else
            {
                _dicNg.Add(day, 1);
            }

            //增加数据
            foreach (var item in _dicOk.OrderBy(t => t.Key))
            {
                if (item.Key >= min && item.Key <= max)
                {
                    chart1.Series[0].Points.AddXY(item.Key, item.Value);
                }
            }
            foreach (var item in _dicNg.OrderBy(t => t.Key))
            {
                if (item.Key >= min && item.Key <= max)
                {
                    chart1.Series[0].Points.AddXY(item.Key, item.Value);
                }
            }
        }
        #endregion
    }

    public class IO_Summary_Data
    {
        public string SN { get; set; }
        public bool OKNG { get; set; }
        public int Input { get; set; }
        public int Output { get; set; }
        public double Yield { get; set; }

        public int Pass { get; set; }
        public int Fail { get; set; }
        public int UPH { get; set; }
        public double CT { get; set; }
    }
}
