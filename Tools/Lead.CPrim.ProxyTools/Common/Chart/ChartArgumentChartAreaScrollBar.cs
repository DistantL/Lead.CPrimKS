using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 轴滚动条
    /// </summary>
    public class ChartArgumentChartAreaScrollBar
    {
        /// <summary>
        /// True 如果启用轴滚动条 false 如果未启用滚动条。<br/>
        /// 默认值：true<br/>
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// True 如果启用轴滚动条 false 如果未启用滚动条。<br/>
        /// 默认值：ScrollBarButtonStyles.All<br/>
        /// </summary>
        public ScrollBarButtonStyles ButtonStyle { get; set; }

        /// <summary>
        /// True 如果滚动条位于内部或外部的图表区;否则为 False。<br/>
        /// 默认值：true<br/>
        /// </summary>
        public bool IsPositionedInside { get; set; }



        public ChartArgumentChartAreaScrollBar()
        {
            Enabled = true;
            ButtonStyle = ScrollBarButtonStyles.All;
            IsPositionedInside = true;
        }
    }
}
