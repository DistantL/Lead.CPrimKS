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
    /// 轴的主要网格线
    /// </summary>
    public class ChartArgumentChartAreaAxisMajorGrid
    {
        /// <summary>
        /// true:启用主要或次要网格线的标志;false:不启用;<br/>
        /// 默认值：false<br/>
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 网格的线条颜色<br/>
        /// 默认值：Color.LightGray<br/>
        /// </summary>
        public Color LineColor { get; set; }

        /// <summary>
        /// 网格的线型<br/>
        /// 默认值：ChartDashStyle.Dash<br/>
        /// </summary>
        public ChartDashStyle LineDashStyle { get; set; }

        /// <summary>
        /// 网格的宽度<br/>
        /// 默认值：1<br/>
        /// </summary>
        public int LineWidth { get; set; }

        /// <summary>
        /// 网格的间隔类型<br/>
        /// 默认值：DateTimeIntervalType.Auto<br/>
        /// </summary>
        public DateTimeIntervalType IntervalType { get; set; }

        /// <summary>
        /// 网格的间隔<br/>
        /// 默认值：double.NaN<br/>
        /// </summary>
        public double Interval { get; set; }



        public ChartArgumentChartAreaAxisMajorGrid()
        {
            Enabled = false;
            LineColor = Color.LightGray;
            LineDashStyle = ChartDashStyle.Dash;
            LineWidth = 1;
            IntervalType = DateTimeIntervalType.Auto;
            Interval = double.NaN;
        }
    }
}
