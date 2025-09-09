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
    /// 数据序列参数
    /// </summary>
    public class ChartArgumentSeries
    {
        /// <summary>
        /// 名称<br/>
        /// 数据序列的唯一名称。<br/>
        /// 默认值：C1<br/>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 图表区名称<br/>
        /// 默认值：C1<br/>
        /// </summary>
        public string ChartAreaName { get; set; }

        /// <summary>
        /// 图例名称<br/>
        /// 默认值：C1<br/>
        /// </summary>
        public string LegendName { get; set; }

        /// <summary>
        /// 图表类型<br/>
        /// 默认值：SeriesChartType.Spline<br/>
        /// </summary>
        public SeriesChartType ChartType { get; set; }

        /// <summary>
        /// 数据点的颜色<br/>
        /// 默认值：Color.Blue<br/>
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 数据点的边框宽度<br/>
        /// 默认值：1<br/>
        /// </summary>
        public int BorderWidth { get; set; }

        /// <summary>
        /// 提示<br/>
        /// 默认值：当前值：#VALY<br/>
        /// </summary>
        public string ToolTip { get; set; }

        /// <summary>
        /// true:在标签上显示数据点的值;false:不显示;<br/>
        /// 默认值：false<br/>
        /// </summary>
        public bool IsValueShownAsLabel { get; set; }

        /// <summary>
        /// 数据点标签的文本<br/>
        /// 默认值：""<br/>
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 数据点标签的格式<br/>
        /// 默认值：""<br/>
        /// </summary>
        public string LabelFormat { get; set; }

        /// <summary>
        /// 标记颜色<br/>
        /// 默认值：Color.Blue<br/>
        /// </summary>
        public Color MarkerColor { get; set; }

        /// <summary>
        /// 标记大小<br/>
        /// 默认值：1<br/>
        /// </summary>
        public int MarkerSize { get; set; }

        /// <summary>
        /// 标记样式<br/>
        /// 默认值：MarkerStyle.Circle<br/>
        /// </summary>
        public MarkerStyle MarkerStyle { get; set; }

        /// <summary>
        /// 绘制沿 x 轴的值类型<br/>
        /// 默认值：ChartValueType.String<br/>
        /// </summary>
        public ChartValueType XValueType { get; set; }

        /// <summary>
        /// 数据点中的 Y 值数据类型<br/>
        /// 默认值：ChartValueType.Double<br/>
        /// </summary>
        public ChartValueType YValueType { get; set; }

        /// <summary>
        /// x 轴类型<br/>
        /// 默认值：AxisType.Primary<br/>
        /// </summary>
        public AxisType XAxisType { get; set; }

        /// <summary>
        /// y 轴类型<br/>
        /// 默认值：AxisType.Primary<br/>
        /// </summary>
        public AxisType YAxisType { get; set; }



        public ChartArgumentSeries()
        {
            Name = "C1";
            ChartAreaName = "C1";
            LegendName = "C1";
            ChartType = SeriesChartType.Spline;

            Color = Color.Blue;
            BorderWidth = 1;
            ToolTip = "当前值：#VALY";

            IsValueShownAsLabel = false;
            Label = "";
            LabelFormat = "";

            MarkerColor = Color.Blue;
            MarkerSize = 1;
            MarkerStyle = MarkerStyle.Circle;

            XValueType = ChartValueType.String;
            YValueType = ChartValueType.Double;
            XAxisType = AxisType.Primary;
            YAxisType = AxisType.Primary;
        }
    }
}
