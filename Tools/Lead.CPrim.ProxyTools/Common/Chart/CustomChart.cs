/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: CustomChart.cs
 * Author: Victor
 * Description: Chart图像帮助类
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.33.0617><Victor><20220710>
 * 1、InitChart参数变更legend.BackColor = Color.Transparent（图例背景透明）
 * 2、InitChart内容屏蔽area.AxisY.Interval = 50;（间隔自动生成）
 * 
 * <3.3.22.1125><Victor><20221130>
 * 1、位置压力曲线&时间压力曲线方法进行二次封装
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>工具帮助类代理</summary>
    public class CustomChart
    {
        #region Method_ExternalUsing
        /// <summary>图表初始化</summary>
        /// <param name="chart">图表</param>
        /// <param name="datas">图表数据集合</param>
        /// <param name="title">标题</param>
        public static void InitChart(Chart chart, List<ChartData> datas, string title)
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
                series.ChartType = SeriesChartType.StackedColumn;  //图表类型
                series.Color = item.color;  //线的颜色
                series.BorderWidth = 1; //线的宽度
                series.IsValueShownAsLabel = true;  //显示标签
                series.ToolTip = "时间：#VALX\n当前值：#VALY\n最大值：#MAX\n最小值：#MIN\n平均值：#AVG";

                series.MarkerColor = Color.Green;   //标记的颜色
                series.MarkerSize = 2;  //标记的大小
                series.MarkerStyle = MarkerStyle.Circle; //标记样式

                series.XValueType = ChartValueType.Int32;  //X轴的值类型
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
            area.AxisX.Title = "小时";    //X轴标题
            area.AxisX.TextOrientation = TextOrientation.Horizontal;    //X轴标题方向
            area.AxisX.Minimum = -1; //X轴最小值
            area.AxisX.Maximum = 24;   //X轴最大值
            //area.AxisX.Interval = 5;    //X轴间隔（静态图标要开，动态图片不能开）
            area.AxisX.IsStartedFromZero = false;   //指示在所有数据点值均为正值时是否将轴的最小值自动设置为零。 如果存在负数据点值，则将使用数据点的最小值
            area.AxisX.ScrollBar.Enabled = true;
            area.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            area.AxisX.ScaleView.Scroll(ScrollType.Last);
            area.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            area.AxisX.LabelStyle.Angle = 15;
            area.AxisX.LabelStyle.Font = new Font("微软雅黑", 20f);
            area.AxisX.LabelStyle.Format = "00"; // 设置时间作为X轴
            area.AxisX.LabelStyle.IntervalType = DateTimeIntervalType.NotSet;
            area.AxisX.LabelStyle.Interval = 1;                //坐标值间隔1S
            area.AxisX.LabelStyle.IsEndLabelVisible = false;   //防止X轴坐标跳跃
            area.AxisX.ScaleView.Zoomable = true;
            area.AxisX.ScrollBar.IsPositionedInside = false;

            //area.AxisX.Minimum = DateTime.Now.ToOADate();      //当前时间
            //area.AxisX.Maximum = DateTime.Now.ToOADate();
            //Y轴
            area.AxisY.Title = "数量统计";   //Y轴标题
            area.AxisY.TextOrientation = TextOrientation.Stacked;   //Y轴标题方向
            area.AxisY.Minimum = 0; //Y轴最小值
            //area.AxisY.Maximum = 5;   //Y轴最大值
            //area.AxisY.Interval = 50;    //Y轴间隔
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
            area.AxisX.MajorGrid.Interval = 50;  //网格间隔
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
            legend.BackColor = Color.Transparent;
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

        /// <summary>图表初始化</summary>
        /// <param name="chart">图表</param>
        /// <param name="title">标题</param>
        public static void InitChartOKAndRate(Chart chart, string title)
        {
            //五大集合
            //*********************************************************************************************************
            //第一集合：Series
            //图表类型选择（柱状图/折线图）
            chart.Series.Clear();
            Series seriesOK = GetSeries(new ChartArgumentSeries() { Name = "OK", ChartType = SeriesChartType.Column, Color = Color.FromArgb(90, 150, 192) });
            Series seriesRate = GetSeries(new ChartArgumentSeries() { Name = "Rate", ChartType = SeriesChartType.Line, Color = Color.FromArgb(90, 150, 192) });
            chart.Series.Add(seriesOK);
            chart.Series.Add(seriesRate);

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
            area.AxisX.Title = "小时";    //X轴标题
            area.AxisX.TextOrientation = TextOrientation.Horizontal;    //X轴标题方向
            area.AxisX.Minimum = -1; //X轴最小值
            area.AxisX.Maximum = 24;   //X轴最大值
            area.AxisX.IsStartedFromZero = false;   //指示在所有数据点值均为正值时是否将轴的最小值自动设置为零。 如果存在负数据点值，则将使用数据点的最小值
            area.AxisX.ScrollBar.Enabled = true;
            area.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            area.AxisX.ScaleView.Scroll(ScrollType.Last);
            area.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            area.AxisX.LabelStyle.Angle = 15;
            area.AxisX.LabelStyle.Font = new Font("微软雅黑", 20f);
            area.AxisX.LabelStyle.Format = "00"; // 设置时间作为X轴
            area.AxisX.LabelStyle.IntervalType = DateTimeIntervalType.NotSet;
            area.AxisX.LabelStyle.Interval = 1;                //坐标值间隔1S
            area.AxisX.LabelStyle.IsEndLabelVisible = false;   //防止X轴坐标跳跃
            area.AxisX.ScaleView.Zoomable = true;
            area.AxisX.ScrollBar.IsPositionedInside = false;

            //Y轴
            area.AxisY.Enabled = AxisEnabled.True;
            area.AxisY.Title = "数量统计";   //Y轴标题
            area.AxisY.TextOrientation = TextOrientation.Stacked;   //Y轴标题方向
            area.AxisY.Minimum = 0;
            area.AxisY.IsInterlaced = false; //是否为轴显示交错带状线的标志（交错网格）

            area.AxisY2.Enabled = AxisEnabled.True;
            area.AxisY2.Title = "良率";
            area.AxisY2.TextOrientation = TextOrientation.Stacked;
            area.AxisY2.LabelStyle.Format = "0.00%";
            area.AxisY2.Minimum = 0;
            area.AxisY2.Maximum = 1;

            //游标
            area.CursorX.AutoScroll = true; //游标自动滚动
            area.CursorX.IsUserEnabled = true;  //游标使能
            area.CursorX.IsUserSelectionEnabled = true; //游标使能
            area.CursorX.LineColor = Color.Red; //游标线颜色
            area.CursorX.Interval = 100D;
            area.CursorX.IntervalOffset = 0;
            area.CursorX.IntervalType = DateTimeIntervalType.Minutes;
            area.CursorX.IntervalOffsetType = DateTimeIntervalType.Minutes;

            //网格线
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.MajorGrid.LineColor = Color.Red;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            area.AxisX.MajorGrid.LineWidth = 1;
            area.AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Hours;
            area.AxisY.MajorGrid.Enabled = true;
            area.AxisY.MajorGrid.LineColor = Color.Blue;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            area.AxisY.MajorGrid.LineWidth = 1;
            area.AxisY2.MajorGrid.Enabled = false;

            // 背景样式
            area.BackColor = SystemColors.ControlLight;                       //背景色
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
            Legend legend = new Legend("C1")
            {
                Alignment = StringAlignment.Near,
                Docking = Docking.Top,
                BackColor = Color.Transparent,
            };
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

        /// <param name="chart">图表</param>
        /// <param name="title">标题</param>
        public static void InitChartAnalysis(Chart chart, string title)
        {
            //五大集合
            //*********************************************************************************************************
            //第一集合：Series
            //图表类型选择（柱状图/折线图）
            chart.Series.Clear();
            Series seriesValue = new Series("FAI值")
            {
                ChartArea = "C1",                           //指定【图表区】名称
                Legend = "C1",                              //指定【图例】名称
                ChartType = SeriesChartType.Line,           //图表类型
                Color = Color.Green,                        //线的颜色
                BorderWidth = 1,                            //线的宽度
                IsValueShownAsLabel = false,                 //显示标签
                ToolTip = "时间：#VALX\n当前值：#VALY\n最大值：#MAX\n最小值：#MIN\n平均值：#AVG",

                MarkerColor = Color.Green,                  //标记的颜色
                MarkerSize = 2,                             //标记的大小
                MarkerStyle = MarkerStyle.Circle,           //标记样式

                XValueType = ChartValueType.DateTime,       //X轴的值类型
                YValueType = ChartValueType.Double,         //Y轴的值类型

                XAxisType = AxisType.Primary,
                YAxisType = AxisType.Primary,               //主轴
            };

            chart.Series.Add(seriesValue);

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
            area.AxisX.Title = "小时";    //X轴标题
            area.AxisX.TextOrientation = TextOrientation.Horizontal;    //X轴标题方向
            area.AxisX.IsStartedFromZero = false;   //指示在所有数据点值均为正值时是否将轴的最小值自动设置为零。 如果存在负数据点值，则将使用数据点的最小值
            area.AxisX.ScrollBar.Enabled = true;
            area.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            area.AxisX.ScaleView.Scroll(ScrollType.Last);
            area.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            area.AxisX.LabelStyle.Angle = 15;
            area.AxisX.LabelStyle.Font = new Font("微软雅黑", 20f);
            area.AxisX.LabelStyle.Format = "HH:mm:ss"; // 设置时间作为X轴
            area.AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Hours;
            area.AxisX.LabelStyle.Interval = 1;                //坐标值间隔1S
            area.AxisX.LabelStyle.IsEndLabelVisible = false;   //防止X轴坐标跳跃
            area.AxisX.ScaleView.Zoomable = true;
            area.AxisX.ScrollBar.IsPositionedInside = false;

            //Y轴
            area.AxisY.Enabled = AxisEnabled.True;
            area.AxisY.Title = "测量值";   //Y轴标题
            area.AxisY.TextOrientation = TextOrientation.Stacked;   //Y轴标题方向
            area.AxisY.IsInterlaced = false; //是否为轴显示交错带状线的标志（交错网格）

            //游标
            area.CursorX.AutoScroll = true; //游标自动滚动
            area.CursorX.IsUserEnabled = true;  //游标使能
            area.CursorX.IsUserSelectionEnabled = true; //游标使能
            area.CursorX.LineColor = Color.Red; //游标线颜色
            area.CursorX.Interval = 100D;
            area.CursorX.IntervalOffset = 0;
            area.CursorX.IntervalType = DateTimeIntervalType.Minutes;
            area.CursorX.IntervalOffsetType = DateTimeIntervalType.Minutes;

            //网格线
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.MajorGrid.LineColor = Color.Red;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            area.AxisX.MajorGrid.LineWidth = 1;
            area.AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Hours;
            area.AxisY.MajorGrid.Enabled = true;
            area.AxisY.MajorGrid.LineColor = Color.Blue;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            area.AxisY.MajorGrid.LineWidth = 1;

            // 背景样式
            area.BackColor = SystemColors.ControlLight;                       //背景色
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
            Legend legend = new Legend("C1")
            {
                Alignment = StringAlignment.Near,
                Docking = Docking.Top,
                BackColor = Color.Transparent,
            };
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

        /// <summary>Atlas图表初始化</summary>
        /// <param name="chart"></param>
        /// <param name="yMax">Y轴最大值</param>
        /// <param name="yMin">Y轴最小值</param>
        /// <param name="pressureLimt">压力极限</param>
        /// <param name="xMax">X轴最大值</param>
        /// <param name="xMin">X轴最小值</param>
        public static void InitAtlas(ref Chart chart, double yMax, double yMin, double pressureLimt, double xMax, double xMin)
        {
            // 初始化ChartAreas，新增ChartArea
            chart.ChartAreas.Clear();//'清除所有绘图区
            ChartArea area = new ChartArea("C1");
            chart.ChartAreas.Add(area);

            chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
            chart.ChartAreas[0].AxisX.IntervalOffsetType = DateTimeIntervalType.Auto;
            chart.ChartAreas[0].AxisX.Interval = ((xMax - xMin) / 8) == 0 ? 1 : (xMax - xMin) / 8;
            chart.ChartAreas[0].AxisX.Minimum = xMin;
            chart.ChartAreas[0].AxisX.Maximum = xMax;
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "0.000";
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false; //'网格线
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart.ChartAreas[0].AxisX.Title = "角度";
            chart.ChartAreas[0].AxisX.TextOrientation = TextOrientation.Horizontal;
            chart.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Center;

            chart.ChartAreas[0].AxisY.IntervalType = DateTimeIntervalType.Number;
            chart.ChartAreas[0].AxisY.IntervalOffsetType = DateTimeIntervalType.Number;
            chart.ChartAreas[0].AxisY.Interval = ((yMax - yMin) / 5) == 0 ? 1 : (yMax - yMin) / 5;
            chart.ChartAreas[0].AxisY.Maximum = yMax;
            chart.ChartAreas[0].AxisY.Minimum = yMin;
            chart.ChartAreas[0].AxisY.LabelStyle.Format = "0.000";
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart.ChartAreas[0].AxisY.Title = "扭矩";
            chart.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Stacked;

            chart.ChartAreas[0].AxisX2.MajorGrid.Enabled = false;  //'网格线

            chart.ChartAreas[0].AxisY2.MajorGrid.Enabled = false; //'+++++
            chart.ChartAreas[0].AxisY2.Title = "P";
            chart.ChartAreas[0].AxisY2.TitleAlignment = StringAlignment.Far;
            chart.ChartAreas[0].AxisY2.TextOrientation = TextOrientation.Horizontal;

            //增加limit直线
            //System.Windows.Forms.DataVisualization.Charting.StripLine S1 = new StripLine();
            //System.Windows.Forms.DataVisualization.Charting.StripLine S2 = new StripLine();
            //S1.BorderColor = Color.Tomato;//鲜红色
            //S1.IntervalOffset = pressureLimt; //压力现在线
            //S2.BorderColor = Color.Tomato; //位置终止线
            //S2.IntervalOffset = yMin;
            //chart.ChartAreas[0].AxisY.StripLines.Add(S1);
            //chart.ChartAreas[0].AxisX.StripLines.Add(S2);


            //初始化Series曲线
            chart.Series.Clear();
            Series seriesValue = new Series("值")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 1,
                Color = Color.FromArgb(30, 144, 255),
                XValueType = ChartValueType.Double,
                IsValueShownAsLabel = false,
                ChartArea = "C1",                           //指定【图表区】名称
                XAxisType = AxisType.Primary,
                YAxisType = AxisType.Primary,
                IsVisibleInLegend = false,
            };
            chart.Series.Add(seriesValue);
            chart.Series[0].XAxisType = AxisType.Primary;
            chart.Series[0].YAxisType = AxisType.Primary;
            chart.Series[0].Points.Clear();                   //清空数据集

            //Series Position_line = new Series("Position");//'新增数据集
            //Position_line.ChartType = SeriesChartType.Line; // '直线
            //Position_line.BorderWidth = 2;
            //Position_line.Color = Color.Red;
            //Position_line.XValueType = ChartValueType.Int32;
            //Position_line.IsValueShownAsLabel = false;
            //chart1.Series.Add(Position_line);
        }

        /// <summary>Atlas图表初始化</summary>
        /// <param name="chart"></param>
        /// <param name="yMax">Y轴最大值</param>
        /// <param name="yMin">Y轴最小值</param>
        /// <param name="xMax">X轴最大值</param>
        /// <param name="xMin">X轴最小值</param>
        public static void InitAtlas(ref Chart chart, double yMax, double yMin, double xMax, double xMin)
        {
            // 初始化ChartAreas，新增ChartArea
            chart.ChartAreas.Clear();//'清除所有绘图区
            ChartArea area = new ChartArea("C1");
            chart.ChartAreas.Add(area);

            chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
            chart.ChartAreas[0].AxisX.IntervalOffsetType = DateTimeIntervalType.Auto;
            chart.ChartAreas[0].AxisX.Interval = ((xMax - xMin) / 8) == 0 ? 1 : (xMax - xMin) / 8;
            chart.ChartAreas[0].AxisX.Minimum = xMin;
            chart.ChartAreas[0].AxisX.Maximum = xMax;
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "0.000";
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false; //'网格线
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart.ChartAreas[0].AxisX.Title = "角度";
            chart.ChartAreas[0].AxisX.TextOrientation = TextOrientation.Horizontal;
            chart.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Center;

            chart.ChartAreas[0].AxisY.IntervalType = DateTimeIntervalType.Number;
            chart.ChartAreas[0].AxisY.IntervalOffsetType = DateTimeIntervalType.Number;
            chart.ChartAreas[0].AxisY.Interval = ((yMax - yMin) / 5) == 0 ? 1 : (yMax - yMin) / 5;
            chart.ChartAreas[0].AxisY.Maximum = yMax;
            chart.ChartAreas[0].AxisY.Minimum = yMin;
            chart.ChartAreas[0].AxisY.LabelStyle.Format = "0.000";
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart.ChartAreas[0].AxisY.Title = "扭矩";
            chart.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Stacked;

            chart.ChartAreas[0].AxisX2.MajorGrid.Enabled = false;  //'网格线

            chart.ChartAreas[0].AxisY2.MajorGrid.Enabled = false; //'+++++
            chart.ChartAreas[0].AxisY2.Title = "P";
            chart.ChartAreas[0].AxisY2.TitleAlignment = StringAlignment.Far;
            chart.ChartAreas[0].AxisY2.TextOrientation = TextOrientation.Horizontal;

            //增加limit直线
            //System.Windows.Forms.DataVisualization.Charting.StripLine S1 = new StripLine();
            //System.Windows.Forms.DataVisualization.Charting.StripLine S2 = new StripLine();
            //S1.BorderColor = Color.Tomato;//鲜红色
            //S1.IntervalOffset = pressureLimt; //压力现在线
            //S2.BorderColor = Color.Tomato; //位置终止线
            //S2.IntervalOffset = yMin;
            //chart.ChartAreas[0].AxisY.StripLines.Add(S1);
            //chart.ChartAreas[0].AxisX.StripLines.Add(S2);


            //初始化Series曲线
            chart.Series.Clear();
            Series seriesValue = new Series("值")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 1,
                Color = Color.FromArgb(30, 144, 255),
                XValueType = ChartValueType.Double,
                IsValueShownAsLabel = false,
                ChartArea = "C1",                           //指定【图表区】名称
                XAxisType = AxisType.Primary,
                YAxisType = AxisType.Primary,
                IsVisibleInLegend = false,
            };
            chart.Series.Add(seriesValue);
            chart.Series[0].XAxisType = AxisType.Primary;
            chart.Series[0].YAxisType = AxisType.Primary;
            chart.Series[0].Points.Clear();                   //清空数据集

            seriesValue = new Series("上限")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 1,
                Color = Color.Red,
                XValueType = ChartValueType.Double,
                IsValueShownAsLabel = false,
                ChartArea = "C1",                           //指定【图表区】名称
                XAxisType = AxisType.Primary,
                YAxisType = AxisType.Primary,
                IsVisibleInLegend = false,
            };
            chart.Series.Add(seriesValue);

            seriesValue = new Series("标准值")
            {
                ChartType = SeriesChartType.Line,
                BorderDashStyle = ChartDashStyle.DashDot,
                BorderWidth = 1,
                Color = Color.Green,
                XValueType = ChartValueType.Double,
                IsValueShownAsLabel = false,
                ChartArea = "C1",                           //指定【图表区】名称
                XAxisType = AxisType.Primary,
                YAxisType = AxisType.Primary,
                IsVisibleInLegend = false,
            };
            chart.Series.Add(seriesValue);

            seriesValue = new Series("下限")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 1,
                Color = Color.Red,
                XValueType = ChartValueType.Double,
                IsValueShownAsLabel = false,
                ChartArea = "C1",                           //指定【图表区】名称
                XAxisType = AxisType.Primary,
                YAxisType = AxisType.Primary,
                IsVisibleInLegend = false,
            };
            chart.Series.Add(seriesValue);
        }

        /// <summary>
        /// Atlas图表初始化<br/>
        /// 1、适用于显示基元ShowAtlasCurve中Atlas角度扭矩曲线
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="yMax">Y轴最大值</param>
        /// <param name="yMin">Y轴最小值</param>
        /// <param name="yInterval">Y轴间隔</param>
        /// <param name="pressureLimt">压力极限</param>
        /// <param name="xMax">X轴最大值</param>
        /// <param name="xMin">X轴最小值</param>
        /// <param name="xInterval">X轴间隔</param>
        /// <param name="xName">X轴名称</param>
        /// <param name="yName">Y轴名称</param>
        /// <param name="title">标题</param>
        public static void InitAtlas(
            ref Chart chart,
            double yMax,
            double yMin,
            double yInterval,
            double pressureLimt,
            double xMax,
            double xMin,
            double xInterval,
            string xName = "",
            string yName = "",
            string title = "")
        {
            //Series
            chart.Series.Clear();
            Series seriesValue = GetSeries(new ChartArgumentSeries { ChartType = SeriesChartType.Line, ToolTip = "Angle：#VALX\nTorque：#VALY" });
            chart.Series.Add(seriesValue);

            // ChartAreas
            chart.ChartAreas.Clear();
            double xIntervalTmp = 0;
            double yIntervalTmp = 0;
            if (xInterval > 0)
            {
                xIntervalTmp = xInterval;
            }
            else
            {
                xIntervalTmp = ((xMax - xMin) / 8) == 0 ? 1 : (xMax - xMin) / 8;
            }
            if (yInterval > 0)
            {
                yIntervalTmp = yInterval;
            }
            else
            {
                yIntervalTmp = ((yMax - yMin) / 5) == 0 ? 1 : (yMax - yMin) / 5;
            }
            ChartArea area = GetChartArea(new ChartArgumentChartArea
            {
                BackColor = Color.White,
                AxisX = new ChartArgumentChartAreaAxis
                {
                    Title = xName.IsNullOrEmpty() ? "Angle(°)" : $"Angle_{xName}",
                    LineWidth = 2,
                    Minimum = xMin,
                    Maximum = xMax,
                    Interval = xIntervalTmp,
                    LabelStyle = new ChartArgumentChartAreaAxisLableStyle { Format = "0" },
                },
                AxisY = new ChartArgumentChartAreaAxis
                {
                    Title = yName.IsNullOrEmpty() ? "Torque(Kgf.cm)" : $"Torque_{yName}",
                    LineWidth = 2,
                    Minimum = yMin,
                    Maximum = yMax,
                    Interval = yIntervalTmp,

                    TextOrientation = TextOrientation.Rotated270,
                    MajorGrid = new ChartArgumentChartAreaAxisMajorGrid
                    {
                        Enabled = true,
                    }
                },
            });
            chart.ChartAreas.Add(area);

            if (!title.IsNullOrWhiteSpace())
            {
                SetTitlesStyle2(ref chart, title);
            }

            //增加limit直线
            if (Math.Abs(pressureLimt) >= 0.05)
            {
                StripLine yLimit = new StripLine()
                {
                    BorderColor = Color.Tomato,
                    IntervalOffset = pressureLimt,
                    Text = pressureLimt.ToString(),
                    TextAlignment = StringAlignment.Near
                };
                chart.ChartAreas[0].AxisY.StripLines.Add(yLimit);
            }

            chart.BackColor = Color.White;
        }

        /// <summary>
        /// Atlas图表初始化<br/>
        /// 1、适用于显示基元ShowAtlasCurve中Atlas角度扭矩曲线
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="datas"></param>
        /// <param name="yMax">Y轴最大值</param>
        /// <param name="yMin">Y轴最小值</param>
        /// <param name="yInterval">Y轴间隔</param>
        /// <param name="pressureLimt">压力极限</param>
        /// <param name="xMax">X轴最大值</param>
        /// <param name="xMin">X轴最小值</param>
        /// <param name="xInterval">X轴间隔</param>
        /// <param name="xName">X轴名称</param>
        /// <param name="yName">Y轴名称</param>
        /// <param name="title">标题</param>
        public static void InitAtlas(
            ref Chart chart,
            List<ChartData> datas,
            double yMax,
            double yMin,
            double yInterval,
            double pressureLimt,
            double xMax,
            double xMin,
            double xInterval,
            string xName = "",
            string yName = "",
            string title = "")
        {
            //Series
            chart.Series.Clear();
            foreach (var data in datas)
            {
                Series seriesValue = GetSeries(new ChartArgumentSeries { Name = data.Name, Color = data.color, MarkerColor = data.color, ChartType = SeriesChartType.Line });
                chart.Series.Add(seriesValue);
            }

            // ChartAreas
            chart.ChartAreas.Clear();
            double xIntervalTmp = 0;
            double yIntervalTmp = 0;
            if (xInterval > 0)
            {
                xIntervalTmp = xInterval;
            }
            else
            {
                xIntervalTmp = ((xMax - xMin) / 8) == 0 ? 1 : (xMax - xMin) / 8;
            }
            if (yInterval > 0)
            {
                yIntervalTmp = yInterval;
            }
            else
            {
                yIntervalTmp = ((yMax - yMin) / 5) == 0 ? 1 : (yMax - yMin) / 5;
            }
            ChartArea area = GetChartArea(new ChartArgumentChartArea
            {
                BackColor = Color.White,
                AxisX = new ChartArgumentChartAreaAxis
                {
                    Title = xName.IsNullOrEmpty() ? "Angle(°)" : $"Angle_{xName}",
                    LineWidth = 2,
                    Minimum = xMin,
                    Maximum = xMax,
                    Interval = xIntervalTmp,
                    LabelStyle = new ChartArgumentChartAreaAxisLableStyle { Format = "0" },
                },
                AxisY = new ChartArgumentChartAreaAxis
                {
                    Title = yName.IsNullOrEmpty() ? "Torque(Kgf.cm)" : $"Torque_{yName}",
                    LineWidth = 2,
                    Minimum = yMin,
                    Maximum = yMax,
                    Interval = yIntervalTmp,

                    TextOrientation = TextOrientation.Rotated270,
                    MajorGrid = new ChartArgumentChartAreaAxisMajorGrid
                    {
                        Enabled = true,
                    }
                },
            });
            chart.ChartAreas.Add(area);

            if (!title.IsNullOrWhiteSpace())
            {
                SetTitlesStyle2(ref chart, title);
            }

            {
                chart.Legends.Clear();
                Legend legend = new Legend
                {
                    Name = "C1",
                    Enabled = true,
                    Docking = Docking.Top,
                    Alignment = StringAlignment.Center,
                };
                chart.Legends.Add(legend);
            }

            //增加limit直线
            if (Math.Abs(pressureLimt) >= 0.05)
            {
                StripLine yLimit = new StripLine()
                {
                    BorderColor = Color.Tomato,
                    IntervalOffset = pressureLimt,
                    Text = pressureLimt.ToString(),
                    TextAlignment = StringAlignment.Near
                };
                chart.ChartAreas[0].AxisY.StripLines.Add(yLimit);
            }

            chart.BackColor = Color.White;
        }

        /// <summary>
        /// 位置压力曲线
        /// </summary>
        /// <param name="chart">图表</param>
        /// <param name="yMax">Y轴最大值</param>
        /// <param name="yMin">Y轴最小值</param>
        /// <param name="xMax">X轴最大值</param>
        /// <param name="xMin">X轴最小值</param>
        /// <param name="xIntervalType">X轴间隔类型</param>
        /// <param name="xFormat">X轴格式</param>
        /// <param name="title">标题</param>
        /// <param name="isShowLegend">true：显示图例；false：不显示图例；</param>
        /// <param name="xName">X轴名称</param>
        /// <param name="yName">Y轴名称</param>
        public static void InitChart(
            ref Chart chart,
            double yMax,
            double yMin,
            double xMax,
            double xMin,
            DateTimeIntervalType xIntervalType,
            string xFormat,
            string title,
            bool isShowLegend = true,
            string xName = null,
            string yName = null)
        {
            //五大集合
            //*********************************************************************************************************
            //第一集合：Series
            //图表类型选择（柱状图/折线图）
            chart.Series.Clear();
            Series series = GetSeries(new ChartArgumentSeries { Name = title, ChartType = SeriesChartType.FastLine });
            chart.Series.Add(series);

            //*********************************************************************************************************
            //第二集合：Titles
            chart.Titles.Clear();

            //*********************************************************************************************************
            //第三集合：ChartAreas
            double xmin = xMin;
            double xmax = xMax;
            double xLabelInterval = (xMax - xMin) / 6;
            double interval = xLabelInterval / 5;
            chart.ChartAreas.Clear();
            ChartArea area = GetChartArea("C1", xmin, xmax, interval, xLabelInterval, xIntervalType, xFormat, xName, yMin, yMax, yName);
            chart.ChartAreas.Add(area);

            //*********************************************************************************************************
            //第四集合：Annotations

            //*********************************************************************************************************
            //第五集合：Legends
            chart.Legends.Clear();
            if (isShowLegend)
            {
                Legend legend = GetLegend("C1");
                chart.Legends.Add(legend);
            }

            //*********************************************************************************************************
            SetChartStyle1(ref chart);
        }

        /// <summary>
        /// 时间压力曲线
        /// </summary>
        /// <param name="chart">图表</param>
        /// <param name="yMax">Y轴最大值</param>
        /// <param name="yMin">Y轴最小值</param>
        /// <param name="xMax">X轴最大值</param>
        /// <param name="xMin">X轴最小值</param>
        /// <param name="xIntervalType">X轴间隔类型</param>
        /// <param name="xInterval">X轴间隔</param>
        /// <param name="xFormat">X轴格式</param>
        /// <param name="title">标题</param>
        /// <param name="isShowLegend">true：显示图例；false：不显示图例；</param>
        /// <param name="xName">X轴名称</param>
        /// <param name="yName">Y轴名称</param>
        public static void InitChart(
            ref Chart chart,
            double yMax,
            double yMin,
            DateTime xMax,
            DateTime xMin,
            DateTimeIntervalType xIntervalType,
            double xInterval,
            string xFormat,
            string title,
            bool isShowLegend = true,
            string xName = null,
            string yName = null)
        {
            //五大集合
            //*********************************************************************************************************
            //第一集合：Series
            //图表类型选择（柱状图/折线图）
            chart.Series.Clear();
            Series series = GetSeries(new ChartArgumentSeries { Name = title, ChartType = SeriesChartType.FastLine });
            chart.Series.Add(series);

            //*********************************************************************************************************
            //第二集合：Titles
            chart.Titles.Clear();

            //*********************************************************************************************************
            //第三集合：ChartAreas
            chart.ChartAreas.Clear();
            double xmin = xMin.ToOADate();
            double xmax = xMax.ToOADate();
            //double interval = Math.Ceiling((xMax - xMin).TotalSeconds / 6);
            ChartArea area = GetChartArea("C1", xmin, xmax, xInterval, xInterval, xIntervalType, xFormat, xName, yMin, yMax, yName);
            chart.ChartAreas.Add(area);

            //*********************************************************************************************************
            //第四集合：Annotations

            //*********************************************************************************************************
            //第五集合：Legends
            chart.Legends.Clear();
            if (isShowLegend)
            {
                Legend legend = GetLegend("C1");
                chart.Legends.Add(legend);
            }

            //*********************************************************************************************************
            SetChartStyle1(ref chart);
        }


        /// <summary>
        /// 时间压力曲线<br/>
        /// 1、适用于显示基元ShowPressureCurve
        /// </summary>
        /// <param name="chart">图表</param>
        /// <param name="title">标题</param>
        public static void InitChartTimePressure(Chart chart, string title)
        {
            //五大集合
            //*********************************************************************************************************
            //第一集合：Series
            chart.Series.Clear();
            Series series = new Series()
            {
                Name = title,
                //图表区名称
                ChartArea = "C1",
                //图例名称
                Legend = "C1",
                ChartType = SeriesChartType.Spline,
                //线的颜色
                Color = Color.DarkBlue,
                //线的宽度
                BorderWidth = 1,
                //显示标签
                IsValueShownAsLabel = false,
                ToolTip = "时间：#VALX\n当前值：#VALY\n最大值：#MAX\n最小值：#MIN\n平均值：#AVG",

                //标记的颜色
                MarkerColor = Color.Green,
                //标记的大小
                MarkerSize = 2,
                //标记样式
                MarkerStyle = MarkerStyle.Circle,

                //X轴的值类型
                XValueType = ChartValueType.String,
                //Y轴的值类型
                YValueType = ChartValueType.Double,
            };
            chart.Series.Add(series);

            //*********************************************************************************************************
            //第二集合：Titles
            chart.Titles.Clear();

            //*********************************************************************************************************
            //第三集合：ChartAreas
            chart.ChartAreas.Clear();
            ChartArea area = new ChartArea("C1")
            {

            };
            //X轴
            area.AxisX.Title = "时间";    //X轴标题
            area.AxisX.TextOrientation = TextOrientation.Horizontal;    //X轴标题方向
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
            Legend legend = GetLegend("C1");
            chart.Legends.Add(legend);

            //*********************************************************************************************************
            // 外观（设置边框/背景）
            SetChartStyle2(ref chart);
        }

        /// <summary>
        /// X轴固定，Y轴自动生成
        /// </summary>
        /// <param name="chart">图表</param>
        /// <param name="datas">Series集合，包含Series名称和颜色集合</param>
        /// <param name="axisXCustomLabels"></param>
        /// <param name="title">标题（为空时不显示标题，默认为空）</param>
        /// <param name="isShowLegend">true：显示图例；false：不显示图例；</param>
        /// <param name="xName">X轴名称</param>
        /// <param name="yName">Y轴名称</param>
        /// <param name="axisYFormat">Y轴显示样式</param>
        public static void InitChart(
            ref Chart chart,
            List<ChartDatas> datas,
            string[] axisXCustomLabels,
            string title = null,
            bool isShowLegend = true,
            string xName = null,
            string yName = null,
            string axisYFormat = "")
        {
            //五大集合
            //*********************************************************************************************************
            //第一集合：Series
            //图表类型选择（柱状图/折线图）
            chart.Series.Clear();
            foreach (var data in datas)
            {
                Series series = GetSeries(data.Name, "C1", "C1", data.ChartColor, data.ChartType, data.IsValueShownAsLabel);
                chart.Series.Add(series);
            }

            //*********************************************************************************************************
            //第二集合：Titles
            if (!title.IsNullOrEmpty())
            {
                SetTitlesStyle1(ref chart, title);
            }

            //*********************************************************************************************************
            //第三集合：ChartAreas
            chart.ChartAreas.Clear();
            ChartArea area = GetChartArea("C1", DateTimeIntervalType.Number, xName, yName, axisYFormat);

            if (axisXCustomLabels != null && axisXCustomLabels.Length > 0)
            {
                area.AxisX.CustomLabels.Clear();
                for (int i = 0; i < axisXCustomLabels.Length; i++)
                {
                    CustomLabel customLabel = new CustomLabel();
                    customLabel.ForeColor = Color.Black;
                    customLabel.FromPosition = 0.5D + i;
                    customLabel.Text = axisXCustomLabels[i];
                    customLabel.ToPosition = 1.5D + i;
                    area.AxisX.CustomLabels.Add(customLabel);
                }
                area.AxisX.Minimum = 0.4;
                area.AxisX.Maximum = axisXCustomLabels.Length + 0.6;
            }

            chart.ChartAreas.Add(area);

            //*********************************************************************************************************
            //第四集合：Annotations

            //*********************************************************************************************************
            //第五集合：Legends
            chart.Legends.Clear();
            if (isShowLegend)
            {
                Legend legend = GetLegend("C1");
                chart.Legends.Add(legend);
            }

            //*********************************************************************************************************
            SetChartStyle1(ref chart);
        }

        /// <summary>X轴按最大值，最小值，间隔自动生成，Y轴自动生成曲线<br/>
        /// 应用场景1：Data界面小时查询/日查询</summary>
        /// <param name="chart">图表</param>
        /// <param name="datas">Series集合，包含Series名称和颜色集合</param>
        /// <param name="xMax">X轴最大值（DateTime类型）</param>
        /// <param name="xMin">X轴最小值（DateTime类型）</param>
        /// <param name="xInterval">X轴间隔</param>
        /// <param name="xIntervalType">X轴间隔类型</param>
        /// <param name="xFormat">X轴格式</param>
        /// <param name="title">标题（为空时不显示标题，默认为空）</param>
        /// <param name="isShowLegend">true：显示图例；false：不显示图例；（默认不显示）</param>
        /// <param name="xName">X轴名称</param>
        /// <param name="yName">Y轴名称</param>
        /// <param name="axisYFormat">Y轴显示样式</param>
        public static void InitChart(
            ref Chart chart,
            List<ChartDatas> datas,
            DateTime xMax,
            DateTime xMin,
            double xInterval,
            DateTimeIntervalType xIntervalType,
            string xFormat,
            string title = null,
            bool isShowLegend = false,
            string xName = null,
            string yName = null,
            string axisYFormat = "")
        {
            InitChart(ref chart, datas, xMax.ToOADate(), xMin.ToOADate(), xInterval, xIntervalType, xFormat, title, isShowLegend, xName, yName, axisYFormat);
        }

        /// <summary>
        /// X轴按最大值，最小值，间隔自动生成，Y轴自动生成曲线<br/>
        /// 应用场景1：Data界面小时查询/日查询
        /// </summary>
        /// <param name="chart">图表</param>
        /// <param name="datas">Series集合，包含Series名称和颜色集合</param>
        /// <param name="xMax">X轴最大值（DateTime类型）</param>
        /// <param name="xMin">X轴最小值（DateTime类型）</param>
        /// <param name="xInterval">X轴间隔</param>
        /// <param name="xIntervalType">X轴间隔类型</param>
        /// <param name="xFormat">X轴格式</param>
        /// <param name="title">标题（为空时不显示标题，默认为空）</param>
        /// <param name="isShowLegend">true：显示图例；false：不显示图例；（默认不显示）</param>
        /// <param name="xName">X轴名称</param>
        /// <param name="yName">Y轴名称</param>
        /// <param name="axisYFormat">Y轴显示样式</param>
        public static void InitChart(
            ref Chart chart,
            List<ChartDatas> datas,
            double xMax,
            double xMin,
            double xInterval,
            DateTimeIntervalType xIntervalType,
            string xFormat,
            string title = null,
            bool isShowLegend = false,
            string xName = null,
            string yName = null,
            string axisYFormat = "")
        {
            //五大集合
            //*********************************************************************************************************
            //第一集合：Series
            //图表类型选择（柱状图/折线图）
            chart.Series.Clear();
            foreach (var data in datas)
            {
                Series series = GetSeries(data.Name, "C1", "C1", data.ChartColor, data.ChartType, data.IsValueShownAsLabel);
                chart.Series.Add(series);
            }

            //*********************************************************************************************************
            //第二集合：Titles
            if (!title.IsNullOrEmpty())
            {
                SetTitlesStyle1(ref chart, title);
            }

            //*********************************************************************************************************
            //第三集合：ChartAreas
            chart.ChartAreas.Clear();
            ChartArea area = GetChartArea("C1", xMin, xMax, xInterval, xIntervalType, xFormat, xName, yName, axisYFormat);
            chart.ChartAreas.Add(area);

            //*********************************************************************************************************
            //第四集合：Annotations

            //*********************************************************************************************************
            //第五集合：Legends
            chart.Legends.Clear();
            if (isShowLegend)
            {
                Legend legend = GetLegend("C1");
                chart.Legends.Add(legend);
            }

            //*********************************************************************************************************
            SetChartStyle1(ref chart);
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// 获取Series
        /// </summary>
        /// <param name="series">数据序列参数</param>
        /// <returns></returns>
        public static Series GetSeries(ChartArgumentSeries series)
        {
            return new Series()
            {
                Name = series.Name,
                ChartArea = series.ChartAreaName,
                Legend = series.LegendName,
                ChartType = series.ChartType,
                Color = series.Color,
                BorderWidth = series.BorderWidth,
                ToolTip = series.ToolTip,

                IsValueShownAsLabel = series.IsValueShownAsLabel,
                Label = series.Label,
                LabelFormat = series.LabelFormat,

                MarkerColor = series.MarkerColor,
                MarkerSize = series.MarkerSize,
                MarkerStyle = series.MarkerStyle,

                XValueType = series.XValueType,
                YValueType = series.YValueType,
                XAxisType = series.XAxisType,
                YAxisType = series.YAxisType,
            };
        }

        /// <summary>
        /// 获取ChartArea<br/>
        /// </summary>
        /// <returns></returns>
        public static ChartArea GetChartArea(ChartArgumentChartArea chartArea)
        {
            return new ChartArea(chartArea.Name)
            {
                //背景
                BackColor = chartArea.BackColor,
                BackSecondaryColor = chartArea.BackSecondaryColor,
                BackGradientStyle = chartArea.BackGradientStyle,

                //边框
                BorderDashStyle = chartArea.BorderDashStyle,
                BorderWidth = chartArea.BorderWidth,
                BorderColor = chartArea.BorderColor,

                //X轴
                AxisX = new Axis
                {
                    //标题
                    Title = chartArea.AxisX.Title,
                    TitleFont = chartArea.AxisX.TitleFont,
                    TitleAlignment = chartArea.AxisX.TitleAlignment,

                    LineWidth = chartArea.AxisX.LineWidth,
                    TextOrientation = chartArea.AxisX.TextOrientation,
                    IsStartedFromZero = chartArea.AxisX.IsStartedFromZero,

                    IntervalAutoMode = chartArea.AxisX.IntervalAutoMode,
                    IntervalType = chartArea.AxisX.IntervalType,
                    IntervalOffsetType = chartArea.AxisX.IntervalOffsetType,
                    Minimum = chartArea.AxisX.Minimum,
                    Maximum = chartArea.AxisX.Maximum,
                    Interval = chartArea.AxisX.Interval,
                    IsLabelAutoFit = chartArea.AxisX.IsLabelAutoFit,

                    //轴标签样式
                    LabelStyle = new LabelStyle
                    {
                        Font = chartArea.AxisX.LabelStyle.Font,
                        Format = chartArea.AxisX.LabelStyle.Format,
                        IntervalType = chartArea.AxisX.LabelStyle.IntervalType,
                        Interval = chartArea.AxisX.LabelStyle.Interval,
                        IsEndLabelVisible = chartArea.AxisX.LabelStyle.IsEndLabelVisible,
                    },

                    //轴的主要网格线
                    MajorGrid = new Grid
                    {
                        Enabled = chartArea.AxisX.MajorGrid.Enabled,
                        LineColor = chartArea.AxisX.MajorGrid.LineColor,
                        LineDashStyle = chartArea.AxisX.MajorGrid.LineDashStyle,
                        LineWidth = chartArea.AxisX.MajorGrid.LineWidth,
                        IntervalType = chartArea.AxisX.MajorGrid.IntervalType,
                        Interval = chartArea.AxisX.MajorGrid.Interval,
                    },

                    //轴的缩放视图
                    ScaleView = new AxisScaleView
                    {
                        Zoomable = chartArea.AxisX.ScaleView.Zoomable,
                    },

                    //轴滚动条
                    ScrollBar = new AxisScrollBar
                    {
                        Enabled = chartArea.AxisX.ScrollBar.Enabled,
                        ButtonStyle = chartArea.AxisX.ScrollBar.ButtonStyle,
                        IsPositionedInside = chartArea.AxisX.ScrollBar.IsPositionedInside,
                    },
                },

                //X轴
                AxisY = new Axis
                {
                    //标题
                    Title = chartArea.AxisY.Title,
                    TitleFont = chartArea.AxisY.TitleFont,
                    TitleAlignment = chartArea.AxisY.TitleAlignment,

                    LineWidth = chartArea.AxisY.LineWidth,
                    TextOrientation = chartArea.AxisY.TextOrientation,
                    IsStartedFromZero = chartArea.AxisY.IsStartedFromZero,

                    IntervalAutoMode = chartArea.AxisY.IntervalAutoMode,
                    IntervalType = chartArea.AxisY.IntervalType,
                    IntervalOffsetType = chartArea.AxisY.IntervalOffsetType,
                    Minimum = chartArea.AxisY.Minimum,
                    Maximum = chartArea.AxisY.Maximum,
                    Interval = chartArea.AxisY.Interval,
                    IsLabelAutoFit = chartArea.AxisY.IsLabelAutoFit,

                    //轴标签样式
                    LabelStyle = new LabelStyle
                    {
                        Font = chartArea.AxisY.LabelStyle.Font,
                        Format = chartArea.AxisY.LabelStyle.Format,
                        IntervalType = chartArea.AxisY.LabelStyle.IntervalType,
                        Interval = chartArea.AxisY.LabelStyle.Interval,
                        IsEndLabelVisible = chartArea.AxisY.LabelStyle.IsEndLabelVisible,
                    },

                    //轴的主要网格线
                    MajorGrid = new Grid
                    {
                        Enabled = chartArea.AxisY.MajorGrid.Enabled,
                        LineColor = chartArea.AxisY.MajorGrid.LineColor,
                        LineDashStyle = chartArea.AxisY.MajorGrid.LineDashStyle,
                        LineWidth = chartArea.AxisY.MajorGrid.LineWidth,
                        IntervalType = chartArea.AxisY.MajorGrid.IntervalType,
                        Interval = chartArea.AxisY.MajorGrid.Interval,
                    },

                    //轴的缩放视图
                    ScaleView = new AxisScaleView
                    {
                        Zoomable = chartArea.AxisY.ScaleView.Zoomable,
                    },

                    //轴滚动条
                    ScrollBar = new AxisScrollBar
                    {
                        Enabled = chartArea.AxisY.ScrollBar.Enabled,
                        ButtonStyle = chartArea.AxisY.ScrollBar.ButtonStyle,
                        IsPositionedInside = chartArea.AxisY.ScrollBar.IsPositionedInside,
                    },
                },

                //游标
                CursorX = new Cursor
                {
                    IsUserEnabled = chartArea.Cursor.IsUserEnabled,
                    IsUserSelectionEnabled = chartArea.Cursor.IsUserSelectionEnabled,

                    AutoScroll = chartArea.Cursor.AutoScroll,
                    LineColor = chartArea.Cursor.LineColor,

                    IntervalType = chartArea.Cursor.IntervalType,
                    Interval = chartArea.Cursor.Interval,
                }
            };
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// 获取ChartArea（样式1）<br/>
        /// X轴Y轴按照设定值进行分布
        /// </summary>
        /// <param name="areaName"></param>
        /// <param name="xMin"></param>
        /// <param name="xMax"></param>
        /// <param name="xName"></param>
        /// <param name="xInterval"></param>
        /// <param name="xLabelInterval"></param>
        /// <param name="intervalType"></param>
        /// <param name="format"></param>
        /// <param name="yMin"></param>
        /// <param name="yMax"></param>
        /// <param name="yName"></param>
        /// <returns></returns>
        private static ChartArea GetChartArea(
            string areaName,
            double xMin,
            double xMax,
            double xInterval,
            double xLabelInterval,
            DateTimeIntervalType intervalType,
            string format,
            string xName,
            double yMin,
            double yMax,
            string yName)
        {
            double yinterval = yMax - yMin >= 30 ? (yMax - yMin) / 5 : 1;
            return new ChartArea(areaName)
            {
                // 背景样式
                BackColor = Colors.PrimaryBackColor211,
                //渐变背景色
                //BackSecondaryColor = Color.White,
                //渐变方式
                //BackGradientStyle = GradientStyle.TopBottom,
                //背景阴影
                BackHatchStyle = ChartHatchStyle.None,

                //边框线样式
                BorderDashStyle = ChartDashStyle.NotSet,
                BorderWidth = 1,
                BorderColor = Color.FromArgb(112, 121, 128),

                //X轴
                AxisX = new Axis
                {
                    //标题
                    Title = xName,
                    TitleFont = new Font("微软雅黑", 12f, FontStyle.Bold),
                    TitleAlignment = StringAlignment.Center,

                    //X轴标题方向
                    TextOrientation = TextOrientation.Horizontal,
                    //指示在所有数据点值均为正值时是否将轴的最小值自动设置为零。 如果存在负数据点值，则将使用数据点的最小值
                    IsStartedFromZero = false,
                    IntervalAutoMode = IntervalAutoMode.FixedCount,

                    Interval = xInterval,
                    Minimum = xMin,
                    Maximum = xMax,

                    //滚动条
                    ScrollBar = new AxisScrollBar
                    {
                        Enabled = true,
                        ButtonStyle = ScrollBarButtonStyles.All,
                        IsPositionedInside = false,
                    },

                    //true：LabelStyle自动调整；false：LabelStyle根据设置调整
                    IsLabelAutoFit = false,
                    LabelStyle = new LabelStyle
                    {
                        Angle = 0,
                        Font = new Font("微软雅黑", 10f, FontStyle.Regular),
                        Format = format,
                        IntervalType = intervalType,
                        //X轴标签显示间隔
                        Interval = xLabelInterval,
                        //防止X轴坐标跳跃
                        IsEndLabelVisible = true,
                    },

                    //X轴视图
                    ScaleView = new AxisScaleView
                    {
                        Zoomable = true,
                    },

                    //X轴网格线
                    MajorGrid = new Grid
                    {
                        Enabled = false,
                        LineColor = Color.Red,
                        LineDashStyle = ChartDashStyle.DashDot,
                        LineWidth = 1,
                        IntervalType = intervalType,
                        Interval = 1,  //网格间隔
                    },

                    MajorTickMark = new TickMark
                    {
                        Enabled = true,
                        IntervalType = intervalType,
                        TickMarkStyle = TickMarkStyle.OutsideArea,
                        LineColor = Color.Black,
                    }
                },

                //Y轴
                AxisY = new Axis
                {
                    //Y轴
                    Title = yName,
                    TitleFont = new Font("微软雅黑", 12f, FontStyle.Bold),
                    TitleAlignment = StringAlignment.Center,
                    //Y轴标题方向
                    TextOrientation = TextOrientation.Rotated270,
                    //true：Y轴网格背景颜色交错显示；false：Y轴网格背景颜色单一
                    //IsInterlaced = true; 

                    //Y轴间隔
                    Interval = yinterval,
                    Minimum = yMin,
                    Maximum = yMax,

                    //true：LabelStyle自动调整；false：LabelStyle根据设置调整
                    IsLabelAutoFit = false,
                    LabelStyle = new LabelStyle
                    {
                        Format = "0.0",
                        Font = new Font("微软雅黑", 10f, FontStyle.Regular),
                    },

                    //Y轴网格线
                    MajorGrid = new Grid
                    {
                        Enabled = true,
                        LineColor = Color.FromArgb(112, 121, 128),
                        LineDashStyle = ChartDashStyle.Dash,
                        LineWidth = 1,
                    },
                },

                //游标
                CursorX = new Cursor
                {
                    IsUserEnabled = true,  //游标使能
                    IsUserSelectionEnabled = true, //游标使能

                    AutoScroll = true, //游标自动滚动
                    LineColor = Color.Red, //游标线颜色
                    Interval = 0.01,
                    IntervalOffset = 0,
                    IntervalType = intervalType,
                    IntervalOffsetType = intervalType,
                }
            };
        }

        /// <summary>
        /// 获取ChartArea（样式2）<br/>
        /// X轴按照设定值分布，Y轴自动分布
        /// </summary>
        /// <param name="areaName">ChartArea名称</param>
        /// <param name="xMin">X轴最小值</param>
        /// <param name="xMax">X轴最大值</param>
        /// <param name="xInterval">X轴显示间隔</param>
        /// <param name="intervalType">X轴显示间隔类型</param>
        /// <param name="format">X轴显示格式</param>
        /// <param name="xName">X轴名称（为空时不显示标题，默认为空）</param>
        /// <param name="yName">Y轴名称（为空时不显示标题，默认为空）</param>
        /// <param name="axisYFormat"></param>
        /// <returns></returns>
        private static ChartArea GetChartArea(
            string areaName,
            double xMin,
            double xMax,
            double xInterval,
            DateTimeIntervalType intervalType,
            string format,
            string xName = null,
            string yName = null,
            string axisYFormat = "")
        {
            return new ChartArea(areaName)
            {
                // 背景样式
                BackColor = Color.FromArgb(211, 211, 211),
                //渐变背景色
                //BackSecondaryColor = Color.White,
                //渐变方式
                //BackGradientStyle = GradientStyle.TopBottom,
                //背景阴影
                BackHatchStyle = ChartHatchStyle.None,

                //边框线样式
                BorderDashStyle = ChartDashStyle.NotSet,
                BorderWidth = 1,
                BorderColor = Color.FromArgb(112, 121, 128),

                //X轴
                AxisX = new Axis
                {
                    //标题
                    Title = xName.IsNullOrEmpty() ? "" : xName,
                    TitleFont = new Font("微软雅黑", 12f, FontStyle.Bold),
                    TitleAlignment = StringAlignment.Center,

                    //X轴标题方向
                    TextOrientation = TextOrientation.Horizontal,
                    //指示在所有数据点值均为正值时是否将轴的最小值自动设置为零。 如果存在负数据点值，则将使用数据点的最小值
                    IsStartedFromZero = false,
                    IntervalAutoMode = IntervalAutoMode.FixedCount,

                    //IntervalType = DateTimeIntervalType.Days,
                    Interval = xInterval,
                    Minimum = xMin,
                    Maximum = xMax,

                    //滚动条
                    ScrollBar = new AxisScrollBar
                    {
                        Enabled = true,
                        ButtonStyle = ScrollBarButtonStyles.All,
                        IsPositionedInside = false,
                    },

                    //true：LabelStyle自动调整；false：LabelStyle根据设置调整
                    IsLabelAutoFit = true,
                    LabelStyle = new LabelStyle
                    {
                        Angle = 15,
                        Font = new Font("微软雅黑", 10f, FontStyle.Regular),
                        Format = format,
                        IntervalType = intervalType,
                        //X轴标签显示间隔
                        Interval = xInterval,
                        //防止X轴坐标跳跃
                        IsEndLabelVisible = true,
                        IsStaggered = true,
                    },

                    //X轴视图
                    ScaleView = new AxisScaleView
                    {
                        Zoomable = true,
                    },

                    //X轴网格线
                    MajorGrid = new Grid
                    {
                        Enabled = false,
                        LineColor = Color.Red,
                        LineDashStyle = ChartDashStyle.DashDot,
                        LineWidth = 1,
                        IntervalType = intervalType,
                        Interval = 1,  //网格间隔
                    },
                },

                //Y轴
                AxisY = new Axis
                {
                    IsStartedFromZero = true,
                    //Y轴
                    Title = yName.IsNullOrEmpty() ? "" : yName,
                    TitleFont = new Font("微软雅黑", 12f, FontStyle.Bold),
                    TitleAlignment = StringAlignment.Center,
                    //Y轴标题方向
                    TextOrientation = TextOrientation.Rotated270,
                    //true：Y轴网格背景颜色交错显示；false：Y轴网格背景颜色单一
                    //IsInterlaced = true; 

                    //true：LabelStyle自动调整；false：LabelStyle根据设置调整
                    IsLabelAutoFit = true,
                    LabelStyle = new LabelStyle
                    {

                        Format = axisYFormat.IsNullOrEmpty() ? "0" : axisYFormat,
                        Font = new Font("微软雅黑", 10f, FontStyle.Regular),
                    },

                    //Y轴网格线
                    MajorGrid = new Grid
                    {
                        Enabled = true,
                        LineColor = Color.FromArgb(112, 121, 128),
                        LineDashStyle = ChartDashStyle.Dash,
                        LineWidth = 1,
                    },
                },

                //游标
                CursorX = new Cursor
                {
                    IsUserEnabled = true,  //游标使能
                    IsUserSelectionEnabled = true, //游标使能

                    AutoScroll = true, //游标自动滚动
                    LineColor = Color.Red, //游标线颜色
                    Interval = 0.01,
                    IntervalOffset = 0,
                    IntervalType = intervalType,
                    IntervalOffsetType = intervalType,
                }
            };
        }

        /// <summary>
        /// 获取ChartArea（样式3）<br/>
        /// X轴按照数组进行分布，Y轴自动分布
        /// </summary>
        /// <param name="areaName"></param>
        /// <param name="xName"></param>
        /// <param name="intervalType"></param>
        /// <param name="yName"></param>
        /// <param name="axisYFormat"></param>
        /// <returns></returns>
        private static ChartArea GetChartArea(
            string areaName,
            DateTimeIntervalType intervalType,
            string xName,
            string yName,
            string axisYFormat = "")
        {
            return new ChartArea(areaName)
            {
                // 背景样式
                BackColor = Color.FromArgb(211, 211, 211),
                //渐变背景色
                //BackSecondaryColor = Color.White,
                //渐变方式
                //BackGradientStyle = GradientStyle.TopBottom,
                //背景阴影
                BackHatchStyle = ChartHatchStyle.None,

                //边框线样式
                BorderDashStyle = ChartDashStyle.NotSet,
                BorderWidth = 1,
                BorderColor = Color.FromArgb(112, 121, 128),

                //X轴
                AxisX = new Axis
                {
                    //标题
                    Title = xName.IsNullOrEmpty() ? "" : xName,
                    TitleFont = new Font("微软雅黑", 12f, FontStyle.Bold),
                    TitleAlignment = StringAlignment.Center,

                    //X轴标题方向
                    TextOrientation = TextOrientation.Horizontal,
                    //指示在所有数据点值均为正值时是否将轴的最小值自动设置为零。 如果存在负数据点值，则将使用数据点的最小值
                    IsStartedFromZero = false,
                    IntervalAutoMode = IntervalAutoMode.FixedCount,

                    //滚动条
                    ScrollBar = new AxisScrollBar
                    {
                        Enabled = true,
                        ButtonStyle = ScrollBarButtonStyles.All,
                        IsPositionedInside = false,
                    },

                    //true：LabelStyle自动调整；false：LabelStyle根据设置调整
                    IsLabelAutoFit = true,
                    LabelStyle = new LabelStyle
                    {
                        Angle = 15,
                        Font = new Font("微软雅黑", 10f, FontStyle.Regular),
                        //Format = format,
                        IntervalType = intervalType,
                        //防止X轴坐标跳跃
                        IsEndLabelVisible = true,
                    },

                    //X轴视图
                    ScaleView = new AxisScaleView
                    {
                        Zoomable = true,
                    },

                    //X轴网格线
                    MajorGrid = new Grid
                    {
                        Enabled = false,
                        LineColor = Color.Red,
                        LineDashStyle = ChartDashStyle.DashDot,
                        LineWidth = 1,
                        IntervalType = intervalType,
                        Interval = 1,  //网格间隔
                    },
                },

                //Y轴
                AxisY = new Axis
                {
                    //Y轴
                    Title = yName.IsNullOrEmpty() ? "" : yName,
                    TitleFont = new Font("微软雅黑", 12f, FontStyle.Bold),
                    TitleAlignment = StringAlignment.Center,
                    //Y轴标题方向
                    TextOrientation = TextOrientation.Rotated270,
                    //true：Y轴网格背景颜色交错显示；false：Y轴网格背景颜色单一
                    //IsInterlaced = true; 

                    //true：LabelStyle自动调整；false：LabelStyle根据设置调整
                    IsLabelAutoFit = true,
                    LabelStyle = new LabelStyle
                    {
                        Format = axisYFormat.IsNullOrEmpty() ? "0" : axisYFormat,
                        Font = new Font("微软雅黑", 10f, FontStyle.Regular),
                    },

                    //Y轴网格线
                    MajorGrid = new Grid
                    {
                        Enabled = true,
                        LineColor = Color.FromArgb(112, 121, 128),
                        LineDashStyle = ChartDashStyle.Dash,
                        LineWidth = 1,
                    },
                },

                //游标
                CursorX = new Cursor
                {
                    IsUserEnabled = true,  //游标使能
                    IsUserSelectionEnabled = true, //游标使能

                    AutoScroll = true, //游标自动滚动
                    LineColor = Color.Red, //游标线颜色
                    Interval = 0.01,
                    IntervalOffset = 0,
                    IntervalType = intervalType,
                    IntervalOffsetType = intervalType,
                }
            };
        }

        /// <summary>
        /// 获取Series
        /// </summary>
        /// <param name="seriesName"></param>
        /// <param name="chartAreaName"></param>
        /// <param name="legendName"></param>
        /// <param name="color"></param>
        /// <param name="type">图表类型（默认Spline）</param>
        /// <param name="isValueShownAsLabel">true：显示标签；false：不显示标签；</param>
        /// <returns></returns>
        private static Series GetSeries(
            string seriesName,
            string chartAreaName,
            string legendName,
            Color color,
            SeriesChartType type = SeriesChartType.Spline,
            bool isValueShownAsLabel = true)
        {
            return new Series()
            {
                Name = seriesName,
                ChartArea = chartAreaName,    //指定【图表区】名称
                Legend = legendName,   //指定【图例】名称
                ChartType = type,  //折线图
                Color = color,  //线的颜色
                BorderWidth = 1, //线的宽度
                IsValueShownAsLabel = isValueShownAsLabel,  //显示标签
                ToolTip = "时间：#VALX\n当前值：#VALY\n最大值：#MAX\n最小值：#MIN\n平均值：#AVG",

                Label = type == SeriesChartType.Pie ? "#PERCENT{P2}" : "",
                LabelFormat = type == SeriesChartType.StackedColumn ? "P1" : "",

                MarkerColor = color,   //标记的颜色
                MarkerSize = 1, //标记的大小
                MarkerStyle = MarkerStyle.Circle, //标记样式

                XValueType = ChartValueType.String,  //X轴的值类型
                YValueType = ChartValueType.Int32,  //Y轴的值类型
            };
        }

        /// <summary>
        /// 获取Legend<br/>
        /// 1、Alignment=Near<br/>
        /// 2、Docking=Top<br/>
        /// 3、BackColor=Transparent<br/>
        /// </summary>
        /// <param name="legendName"></param>
        /// <returns></returns>
        private static Legend GetLegend(string legendName)
        {
            return new Legend(legendName)
            {
                Alignment = StringAlignment.Near,
                Docking = Docking.Top,
                BackColor = Color.Transparent,
            };
        }

        /// <summary>
        /// 样式1_纯色填充
        /// </summary>
        /// <param name="chart"></param>
        private static void SetChartStyle1(ref Chart chart)
        {
            //边框线的样式（NotSet不设置线型）
            chart.BorderlineDashStyle = ChartDashStyle.NotSet;
            //边框线的颜色
            chart.BorderlineColor = Color.FromArgb(26, 59, 105);
            //边框线的宽度
            chart.BorderlineWidth = 1;
            //边框外观样式
            chart.BorderSkin.SkinStyle = BorderSkinStyle.None;
            //背景色
            chart.BackColor = Colors.PrimaryBackColor211;
        }

        /// <summary>
        /// 样式2_上下渐变色填充
        /// </summary>
        /// <param name="chart"></param>
        private static void SetChartStyle2(ref Chart chart)
        {
            //边框线的样式
            chart.BorderlineDashStyle = ChartDashStyle.Dash;
            //边框线的颜色
            chart.BorderlineColor = Color.FromArgb(26, 59, 105);
            //边框线的宽度
            chart.BorderlineWidth = 1;
            //边框外观样式
            chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            //背景色
            chart.BackColor = Color.White;

            //图表背景辅助颜色
            chart.BackSecondaryColor = Color.Gray;
            //渐变背景渐变的方向的枚举
            chart.BackGradientStyle = GradientStyle.TopBottom;
        }

        /// <summary>
        /// 设置标题样式1<br/>
        /// 10号加粗字体<br/>
        /// 居左<br/>
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="title">标题</param>
        private static void SetTitlesStyle1(ref Chart chart, string title)
        {
            chart.Titles.Clear();
            chart.Titles.Add("C1");
            chart.Titles[0].Text = title;
            chart.Titles[0].Font = new Font(UIGlobal.FontName, 12f, FontStyle.Bold);
            chart.Titles[0].ForeColor = Color.Black;
            chart.Titles[0].Alignment = ContentAlignment.TopLeft;
        }

        /// <summary>
        /// 设置标题样式1<br/>
        /// 10号加粗字体<br/>
        /// 居左<br/>
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="title">标题</param>
        private static void SetTitlesStyle2(ref Chart chart, string title)
        {
            chart.Titles.Clear();
            chart.Titles.Add("C1");
            chart.Titles[0].Text = title;
            chart.Titles[0].Font = new Font(UIGlobal.FontName, 10.0f, FontStyle.Bold);
            chart.Titles[0].ForeColor = Color.Black;
            chart.Titles[0].Alignment = ContentAlignment.MiddleCenter;
            chart.Titles[0].BackColor = Color.SkyBlue;
        }
        #endregion
    }
}
