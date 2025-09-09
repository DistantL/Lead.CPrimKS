using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 图表数据类
    /// </summary>
    public class ChartDatas
    {
        public ChartDatas()
        {
            Name = "";
            ChartColor = default;
            ChartType = SeriesChartType.Line;
            IsValueShownAsLabel = true;
        }

        /// <summary>
        /// 曲线名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 曲线颜色
        /// </summary>
        public Color ChartColor { get; set; }

        /// <summary>
        /// 曲线颜色
        /// </summary>
        public SeriesChartType ChartType { get; set; }

        /// <summary>
        /// true：显示标签；false：不显示标签
        /// </summary>
        public bool IsValueShownAsLabel { get; set; }
    }
}
