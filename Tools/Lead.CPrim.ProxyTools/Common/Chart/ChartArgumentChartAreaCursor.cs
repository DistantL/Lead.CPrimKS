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
    /// 游标
    /// </summary>
    public class ChartArgumentChartAreaCursor
    {
        /// <summary>
        /// true 如果启用光标用户界面;否则为 false。<br/>
        /// 默认值：false<br/>
        /// </summary>
        public bool IsUserEnabled { get; set; }

        /// <summary>
        /// true 如果启用范围选择用户界面;否则为 false。<br/>
        /// 默认值：false<br/>
        /// </summary>
        public bool IsUserSelectionEnabled { get; set; }

        /// <summary>
        /// true 如果可以自动保存功能。 滚动数据视图否则为 false。<br/>
        /// 默认值：true<br/>
        /// </summary>
        public bool AutoScroll { get; set; }

        /// <summary>
        /// 光标线条颜色<br/>
        /// 默认值：Color.Green<br/>
        /// </summary>
        public Color LineColor { get; set; }

        /// <summary>
        /// 间隔类型<br/>
        /// 默认值：DateTimeIntervalType.Auto<br/>
        /// </summary>
        public DateTimeIntervalType IntervalType { get; set; }

        /// <summary>
        /// 间隔
        /// 默认值：0.01<br/>
        /// </summary>
        public double Interval { get; set; }



        public ChartArgumentChartAreaCursor()
        {
            IsUserEnabled = false;
            IsUserSelectionEnabled = false;

            AutoScroll = true;
            LineColor = Color.Green;

            IntervalType = DateTimeIntervalType.Auto;
            Interval = 0.01;
        }
    }
}
