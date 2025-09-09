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
    /// 图表区域参数
    /// </summary>
    public class ChartArgumentChartArea
    {
        /// <summary>
        /// 图表区域名称<br/>
        /// 默认值：C1<br/>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 背景色<br/>
        /// 默认值：Colors.PrimaryBackColor211<br/>
        /// </summary>
        public Color BackColor { get; set; }

        /// <summary>
        /// 渐变背景色<br/>
        /// 默认值：Color.White<br/>
        /// </summary>
        public Color BackSecondaryColor { get; set; }

        /// <summary>
        /// 渐变方式<br/>
        /// 默认值：GradientStyle.None<br/>
        /// </summary>
        public GradientStyle BackGradientStyle { get; set; }

        /// <summary>
        /// 边框样式<br/>
        /// 默认值：ChartDashStyle.NotSet<br/>
        /// </summary>
        public ChartDashStyle BorderDashStyle { get; set; }

        /// <summary>
        /// 边框宽度<br/>
        /// 默认值：ChartDashStyle.NotSet<br/>
        /// </summary>
        public int BorderWidth { get; set; }

        /// <summary>
        /// 边框颜色<br/>
        /// 默认值：ChartDashStyle.NotSet<br/>
        /// </summary>
        public Color BorderColor { get; set; }

        /// <summary>
        /// 主 x 轴<br/>
        /// </summary>
        public ChartArgumentChartAreaAxis AxisX { get; set; }

        /// <summary>
        /// 主 y 轴<br/>
        /// </summary>
        public ChartArgumentChartAreaAxis AxisY { get; set; }

        /// <summary>
        /// 游标
        /// </summary>
        public ChartArgumentChartAreaCursor Cursor { get; set; }



        public ChartArgumentChartArea()
        {
            Name = "C1";
            BackColor = Colors.PrimaryBackColor211;
            BackSecondaryColor = Color.White;
            BackGradientStyle = GradientStyle.None;

            BorderDashStyle = ChartDashStyle.NotSet;
            BorderWidth = 1;
            BorderColor = Colors.PrimaryBackColor180;

            AxisX = new ChartArgumentChartAreaAxis();
            AxisY = new ChartArgumentChartAreaAxis();
            Cursor = new ChartArgumentChartAreaCursor();
        }
    }
}
