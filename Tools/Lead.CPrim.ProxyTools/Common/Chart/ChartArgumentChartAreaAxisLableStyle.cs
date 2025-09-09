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
    /// 轴标签样式
    /// </summary>
    public class ChartArgumentChartAreaAxisLableStyle
    {
        /// <summary>
        /// 标签文本字体<br/>
        /// 默认值：微软雅黑10号常规字体<br/>
        /// </summary>
        public Font Font { get; set; }

        /// <summary>
        /// 标签文本的格式化字符串<br/>
        /// 默认值：0.00<br/>
        /// </summary>
        public string Format { get; set; }

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

        /// <summary>
        /// True 如果标签显示在轴的末尾。否则为 False。<br/>
        /// 默认值：true<br/>
        /// 建议值：true，防止轴坐标跳跃<br/>
        /// </summary>
        public bool IsEndLabelVisible { get; set; }



        public ChartArgumentChartAreaAxisLableStyle()
        {
            Font = new Font(UIGlobal.FontName, 10.0f, FontStyle.Regular);
            Format = "0.00";
            IntervalType = DateTimeIntervalType.Auto;
            Interval = double.NaN;
            IsEndLabelVisible = true;
        }
    }
}
