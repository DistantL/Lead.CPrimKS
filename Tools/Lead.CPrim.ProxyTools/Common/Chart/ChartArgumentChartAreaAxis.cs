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
    public class ChartArgumentChartAreaAxis
    {
        /// <summary>
        /// 轴标题<br/>
        /// 默认值：""<br/>
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 轴标题字体<br/>
        /// 默认值：微软雅黑10号常规字体<br/>
        /// </summary>
        public Font TitleFont { get; set; }

        /// <summary>
        /// 轴标题对齐方式<br/>
        /// 默认值：StringAlignment.Far<br/>
        /// </summary>
        public StringAlignment TitleAlignment { get; set; }

        /// <summary>
        /// 轴的线条宽度，以像素为单位<br/>
        /// 默认值：1<br/>
        /// </summary>
        public int LineWidth { get; set; }

        /// <summary>
        /// 轴标题文本的方向<br/>
        /// 默认值：TextOrientation.Horizontal<br/>
        /// </summary>
        public TextOrientation TextOrientation { get; set; }

        /// <summary>
        /// True 如果轴的最小值自动设置为零的所有数据点值均为正值。否则为 false。<br/>
        /// 默认值：false<br/>
        /// </summary>
        public bool IsStartedFromZero { get; set; }

        /// <summary>
        /// 间隔模式<br/>
        /// 默认值：IntervalAutoMode.FixedCount<br/>
        /// </summary>
        public IntervalAutoMode IntervalAutoMode { get; set; }

        /// <summary>
        /// 轴的间隔类型<br/>
        /// 默认值：DateTimeIntervalType.Auto<br/>
        /// </summary>
        public DateTimeIntervalType IntervalType { get; set; }

        /// <summary>
        /// 轴的间隔偏移量的类型<br/>
        /// 默认值：DateTimeIntervalType.Auto<br/>
        /// </summary>
        public DateTimeIntervalType IntervalOffsetType { get; set; }

        /// <summary>
        /// 轴的最小值<br/>
        /// 默认值：double.NaN<br/>
        /// </summary>
        public double Minimum { get; set; }

        /// <summary>
        /// 轴的最大值<br/>
        /// 默认值：double.NaN<br/>
        /// </summary>
        public double Maximum { get; set; }

        /// <summary>
        /// 轴的间隔<br/>
        /// 默认值：double.NaN<br/>
        /// </summary>
        public double Interval { get; set; }

        /// <summary>
        /// True 如果自动调整轴标签;否则为 False。<br/>
        /// 默认值：true<br/>
        /// </summary>
        public bool IsLabelAutoFit { get; set; }

        /// <summary>
        /// 轴标签样式
        /// </summary>
        public ChartArgumentChartAreaAxisLableStyle LabelStyle { get; set; }

        /// <summary>
        /// 轴的主要网格线
        /// </summary>
        public ChartArgumentChartAreaAxisMajorGrid MajorGrid { get; set; }

        /// <summary>
        /// 轴的缩放视图<br/>
        /// </summary>
        public ChartArgumentChartAreaScaleView ScaleView { get; set; }

        /// <summary>
        /// 轴滚动条
        /// </summary>
        public ChartArgumentChartAreaScrollBar ScrollBar { get; set; }



        public ChartArgumentChartAreaAxis()
        {
            Title = "";
            TitleFont = new Font(UIGlobal.FontName, 10.0f, FontStyle.Regular);
            TitleAlignment = StringAlignment.Far;

            LineWidth = 1;
            TextOrientation = TextOrientation.Horizontal;
            IsStartedFromZero = false;
            
            IntervalAutoMode = IntervalAutoMode.FixedCount;
            IntervalType = DateTimeIntervalType.Auto;
            IntervalOffsetType = DateTimeIntervalType.Auto;
            Minimum = double.NaN; 
            Maximum = double.NaN;
            Interval = double.NaN;
            IsLabelAutoFit = true;

            LabelStyle = new ChartArgumentChartAreaAxisLableStyle();
            MajorGrid = new ChartArgumentChartAreaAxisMajorGrid();
            ScaleView = new ChartArgumentChartAreaScaleView();
            ScrollBar = new ChartArgumentChartAreaScrollBar();
        }
    }
}
