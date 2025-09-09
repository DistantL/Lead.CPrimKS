using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lead.CPrim.PressureCurve.Controls
{
    /// <summary>图表管理类</summary>
    public class DynamicChart
    {
        /// <summary>图表初始化</summary>
        /// <param name="chart">图表</param>
        /// <param name="datas">图表数据集合</param>
        /// <param name="title">标题</param>
        public void InitChart(Chart chart, List<ChartData> datas, string title)
        {
            //五大集合
            //*********************************************************************************************************
            //第一集合：Series
            //图表类型选择（柱状图/折线图）
            chart.Series.Clear();
            foreach (var item in datas)
            {
                Series series = new Series(item.Name);
                series.ChartArea = "C1";    //指定【图表区】名称
                series.Legend = "C1";   //指定【图例】名称
                series.Points.Clear();  //清除图标数据
                series.ChartType = SeriesChartType.Spline;  //折线图
                series.Color = item.color;  //线的颜色
                series.BorderWidth = 1; //线的宽度
                series.IsValueShownAsLabel = false;  //显示标签
                series.ToolTip = "时间：#VALX\n当前值：#VALY\n最大值：#MAX\n最小值：#MIN\n平均值：#AVG";

                series.MarkerColor = Color.Green;   //标记的颜色
                series.MarkerSize = 2;  //标记的大小
                series.MarkerStyle = MarkerStyle.Circle; //标记样式

                series.XValueType = ChartValueType.String;  //X轴的值类型
                series.YValueType = ChartValueType.Double;  //Y轴的值类型

                chart.Series.Add(series);
            }

            //*********************************************************************************************************
            //第二集合：Titles
            chart.Titles.Clear();
            chart.Titles.Add("C1");
            chart.Titles[0].Text = title;   //标题名称
            chart.Titles[0].Font = new Font("微软雅黑", 20, FontStyle.Bold);    //标题字体
            chart.Titles[0].ForeColor = Color.Black;    //标题颜色

            //*********************************************************************************************************
            //第三集合：ChartAreas
            chart.ChartAreas.Clear();
            ChartArea area = new ChartArea("C1");
            //X轴
            area.AxisX.Title = "时间";    //X轴标题
            area.AxisX.TextOrientation = TextOrientation.Horizontal;    //X轴标题方向
            area.AxisX.Minimum = 0; //X轴最小值
            area.AxisX.Maximum = 100;   //X轴最大值
            //area.AxisX.Interval = 5;    //X轴间隔（静态图标要开，动态图片不能开）
            area.AxisX.IsStartedFromZero = false;   //指示在所有数据点值均为正值时是否将轴的最小值自动设置为零。 如果存在负数据点值，则将使用数据点的最小值
            area.AxisX.ScrollBar.Enabled = true;
            area.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            area.AxisX.ScaleView.Scroll(ScrollType.Last);
            area.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            area.AxisX.LabelStyle.Angle = 15;
            area.AxisX.LabelStyle.Font = new Font("微软雅黑", 20f);
            area.AxisX.LabelStyle.Format = "HH:mm:ss"; // 设置时间作为X轴
            area.AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Seconds;
            area.AxisX.LabelStyle.Interval = 1;                //坐标值间隔1S
            area.AxisX.LabelStyle.IsEndLabelVisible = false;   //防止X轴坐标跳跃
            area.AxisX.ScaleView.Zoomable = true;
            area.AxisX.ScrollBar.IsPositionedInside = false;

            area.AxisX.Minimum = DateTime.Now.ToOADate();      //当前时间
            area.AxisX.Maximum = DateTime.Now.ToOADate();
            //Y轴
            area.AxisY.Title = "压力值";   //Y轴标题
            area.AxisY.TextOrientation = TextOrientation.Stacked;   //Y轴标题方向
            area.AxisY.Minimum = -1; //Y轴最小值
            area.AxisY.Maximum = 5;   //Y轴最大值
            area.AxisY.Interval = 1;    //Y轴间隔
            area.AxisY.IsInterlaced = true; //是否为轴显示交错带状线的标志（交错网格）

            //游标
            area.CursorX.AutoScroll = true; //游标自动滚动
            area.CursorX.IsUserEnabled = true;  //游标使能
            area.CursorX.IsUserSelectionEnabled = true; //游标使能
            area.CursorX.LineColor = Color.Red; //游标线颜色
            area.CursorX.Interval = 100D;
            area.CursorX.IntervalOffset = 0;
            area.CursorX.IntervalType = DateTimeIntervalType.Milliseconds;
            area.CursorX.IntervalOffsetType = DateTimeIntervalType.Milliseconds;

            //网格线
            area.AxisX.MajorGrid.Enabled = true;
            area.AxisX.MajorGrid.LineColor = Color.Red;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            area.AxisX.MajorGrid.LineWidth = 1;
            area.AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Seconds;
            area.AxisX.MajorGrid.Interval = 1;  //网格间隔
            area.AxisY.MajorGrid.LineColor = Color.Red;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            area.AxisY.MajorGrid.LineWidth = 1;

            // 背景样式
            area.BackColor = Color.White;                       //背景色
            area.BackSecondaryColor = Color.White;              //渐变背景色
            area.BackGradientStyle = GradientStyle.TopBottom;   //渐变方式
            area.BackHatchStyle = ChartHatchStyle.None;         //背景阴影
            area.BorderDashStyle = ChartDashStyle.NotSet;       //边框线样式
            area.BorderWidth = 1;                               //边框宽度
            area.BorderColor = Color.Black;

            chart.ChartAreas.Add(area);

            //*********************************************************************************************************
            //第四集合：Annotations

            //*********************************************************************************************************
            //第五集合：Legends
            chart.Legends.Clear();
            Legend legend = new Legend("C1");
            legend.Alignment = StringAlignment.Near;
            legend.Docking = Docking.Top;
            chart.Legends.Add(legend);


            //*********************************************************************************************************
            // 外观（设置边框/背景）
            chart.BorderlineDashStyle = ChartDashStyle.Dash; //边框线的样式（NotSet不设置线型）
            chart.BorderlineColor = Color.FromArgb(26, 59, 105);  //边框线的颜色
            chart.BorderlineWidth = 1;    //边框线的宽度
            chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;  //边框外观样式

            chart.BackColor = Color.White;    //背景色
            chart.BackSecondaryColor = Color.Gray;    //图表背景辅助颜色
            chart.BackGradientStyle = GradientStyle.TopBottom;    //渐变背景渐变的方向的枚举
        }
    }


    /// <summary>图表数据类</summary>
    public class ChartData
    {
        /// <summary>曲线名称</summary>
        public string Name { get; set; }
        /// <summary>曲线颜色</summary>
        public Color color { get; set; }
    }
}
