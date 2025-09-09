/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: DrawHistorgram.cs
 * Author: Victor
 * Description: 用来绘制直方图
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 *
 * 3.3.33.0617 -> 
 * <Author>     <Time>
 *  Victor     20220709
 * 1、代码风格重新布局以及增加备注
 * 2、组装图标题重新布局（标题居中，良率、Cpk及数量居左）
 ******************************************************************************
 * 问题1：画图出现锯齿、杂色以及效果较差
 * 解决1：theGraphics.SmoothingMode = SmoothingMode.AntiAlias;
******************************************************************************/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Lead.CPrim.ShowHistorgram.FaiAnaylise
{
    /// <summary>绘图帮助类</summary>
    internal class DrawHistorgram
    {
        #region Field
        /// <summary>所绘图形在的左上角的坐标</summary>
        private readonly int MapX;
        /// <summary>所绘图形在的左上角的坐标</summary>
        private readonly int MapY;
        /// <summary>所绘图形宽度</summary>
        private readonly int MapWidth;
        /// <summary>所绘图形高度</summary>
        private readonly int MapHeight;
        /// <summary>所绘图形标题</summary>
        private readonly string Title;

        /// <summary>超下限分组数</summary>
        private readonly int _floorNum = 2;
        /// <summary>正常区域分组数</summary>
        private readonly int _normalNum = 7;

        /// <summary>Y轴值</summary>
        private readonly int[] Value;
        /// <summary>X轴标签</summary>
        private readonly double[] Xlable;
        /// <summary>Y轴标签</summary>
        private readonly string[] Ylable;

        /// <summary>Cpk</summary>
        private double _cpk;
        /// <summary>Cp</summary>
        private double _cp;
        /// <summary>Ca</summary>
        private double _ca;

        /// <summary>OK数量</summary>
        private int _ok;
        /// <summary>NG数量</summary>
        private int _ng;
        /// <summary>总数量</summary>
        private int _total;

        //四个方向上的边距
        /// <summary>左边距</summary>
        private readonly int MarginLeft = 40;
        /// <summary>右边距</summary>
        private readonly int MarginRight = 10;
        /// <summary>上边距</summary>
        private readonly int MarginTop = 40;
        /// <summary>下边距</summary>
        private int MarginBottom = 5;

        /// <summary>Y轴最大值</summary>
        private readonly double MaxY;
        /// <summary>Y轴像素（高度/每值）</summary>
        private readonly double PerY;
        /// <summary>X轴间距</summary>
        private readonly int SpaceX;
        /// <summary>Y轴间距</summary>
        private readonly int SpaceY;

        /// <summary>良率</summary>
        private string _field;
        /// <summary>FAI名称</summary>
        private string _faiName;
        #endregion



        #region Ctor
        /// <summary>构造函数</summary>
        /// <param name="theMapX">所绘图形在的左上角的坐标</param>
        /// <param name="theMapY">所绘图形在的左上角的坐标</param>
        /// <param name="theMapWidth">所绘图形宽度</param>
        /// <param name="theMapHeight">所绘图形高度</param>
        /// <param name="theTitle">所绘图形标题</param>
        /// <param name="floorParts">超下限分组数</param>
        /// <param name="normalParts">正常区域分组数</param>
        /// <param name="theXlable">X轴标签</param>
        /// <param name="theYValue">Y轴值</param>
        /// <param name="cpk">Cpk</param>
        /// <param name="cp">Cp</param>
        /// <param name="ca">Ca</param>
        /// <param name="ok">OK数量</param>
        /// <param name="total">总数量</param>
        public DrawHistorgram(int theMapX, int theMapY, int theMapWidth, int theMapHeight, string theTitle,
            int floorParts, int normalParts, double[] theXlable, int[] theYValue, double cpk, double cp, double ca, int ok, int total)
        {
            MapX = theMapX;
            MapY = theMapY;
            MapWidth = theMapWidth;
            MapHeight = theMapHeight;
            Title = theTitle;

            _floorNum = floorParts;
            _normalNum = normalParts;

            Xlable = theXlable;
            Value = theYValue;

            _cpk = cpk;
            _cp = cp;
            _ca = ca;

            _ok = ok;
            _total = total;
            _ng = _total - ok;

            MaxY = theYValue.Max();
            Ylable = new string[11];
            var EachSpaceValue = GetAxisYSpaceValue(MaxY);
            if (EachSpaceValue == 0)
            {
                EachSpaceValue = 1;
            }
            for (var i = 0; i < Ylable.Length; i++)
            {
                Ylable[i] = Convert.ToString(EachSpaceValue * i);
            }

            SpaceX = (MapWidth - MarginLeft - MarginRight) / Value.Length;
            SpaceY = (MapHeight - MarginTop - MarginBottom) / Ylable.Length;
            PerY = SpaceY / EachSpaceValue;

            string[] temp = theTitle.Split('#');
            _faiName = temp[0];
            _field = temp[1];
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>绘大图</summary>
        /// <param name="theGraphics"></param>
        public void StartDrawingAll(Graphics theGraphics)
        {
            try
            {
                theGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                MarginBottom = 20;
                int x1 = MapX + MarginLeft;
                int x2 = MapX + MapWidth - MarginRight;
                int y1 = MapY + MarginTop;
                int y2 = MapY + MapHeight - MarginBottom;

                //确定背景颜色
                theGraphics.FillRectangle(Brushes.WhiteSmoke, MapX, MapY, MapWidth, MapHeight);

                //标题字体
                Font fontLable = new Font("Arial", 8, FontStyle.Regular);
                Font fontTitle = new Font("微软雅黑", 10.5f, FontStyle.Regular);
                Font fontTitleMiddle = new Font("微软雅黑", 14f, FontStyle.Bold);
                Brush titleBrush = new SolidBrush(Color.Black);
                float widthMiddle = (MapX + MapWidth - GetStringWidth(theGraphics, _faiName, fontTitle)) / 2;

                Point titlePoint = new Point((int)widthMiddle, MapY + 5);
                Point fieldPoint = new Point(x1 + 20, MapY + 20);
                Point cpkPoint = new Point(x1 + 20, MapY + 50);
                Point numPoint = new Point(x1 + 20, MapY + 80);

                //画标题
                theGraphics.DrawString(_faiName, fontTitleMiddle, titleBrush, titlePoint);
                //画良率
                theGraphics.DrawString($"Field={_field}", fontTitle, titleBrush, fieldPoint);
                //画CPK
                theGraphics.DrawString($"CPK/CP={_cpk.ToString("f3")}/{_cp.ToString("f3")}", fontTitle, titleBrush, cpkPoint);
                //画OK/NG数量
                theGraphics.DrawString($"OK/NG={_ok}/{_ng}", fontTitle, titleBrush, numPoint);

                //画边框线
                theGraphics.DrawRectangle(new Pen(Color.Blue), MapX, MapY, MapWidth - 1, MapHeight - 1);

                #region //绘制Y轴标签&横向线
                int y = y2 - SpaceY;
                for (var i = 0; i < Ylable.Length - 1; i++)
                {
                    //Y轴横向线
                    theGraphics.DrawLine(new Pen(Color.LightCoral, 1) { DashStyle = DashStyle.Dot }, x1, y, x2, y);
                    //Y轴标签
                    theGraphics.DrawString(Ylable[i + 1], fontLable, Brushes.Red, x1 - 25, y - 5);
                    y -= SpaceY;
                }
                #endregion

                //X轴
                theGraphics.DrawLine(new Pen(Color.Blue, 2), x1, y2, x2, y2);
                //Y轴
                theGraphics.DrawLine(new Pen(Color.Blue, 2), x1, y1, x1, y2);

                //画直方图，并标志x坐标的序号
                int x = x1;
                SolidBrush VerBrushPositive = new SolidBrush(Color.Blue);
                SolidBrush backColor = new SolidBrush(Color.Black);
                SolidBrush VerBrushDisPositive = new SolidBrush(Color.Red); //正数用蓝色，负数用红色

                for (var i = 0; i < Value.Length; i++)
                {
                    Color darkGreen = Color.FromArgb(0, 100, 0);
                    Color lightGreen = Color.FromArgb(100, 255, 100);
                    Color darkRed = Color.FromArgb(123, 14, 14);
                    Color lightRed = Color.FromArgb(248, 114, 114);
                    Color darkYellow = Color.FromArgb(123, 123, 14);
                    Color lightYellow = Color.FromArgb(248, 248, 114);
                    Color dark = (i == 0 || i == Value.Length - 1) ? darkYellow :
                        ((i >= _floorNum && i < _floorNum + _normalNum) ? darkGreen : darkRed);
                    Color light = (i == 0 || i == Value.Length - 1) ? lightYellow :
                        ((i >= _floorNum && i < _floorNum + _normalNum) ? lightGreen : lightRed);

                    if (Value[i] != 0)
                    {
                        double height = PerY * Value[i];
                        Rectangle rec = new Rectangle(x, (int)(y2 - height), SpaceX, (int)height);
                        theGraphics.FillRectangle(new SolidBrush(light), rec);

                        Rectangle recLeft = new Rectangle(x - 1, (int)(y2 - height - 1), SpaceX / 2 + 2, (int)height + 2);
                        Rectangle recRight = new Rectangle(x + SpaceX / 2 - 1, (int)(y2 - height - 1), SpaceX / 2 + 2, (int)height + 2);
                        LinearGradientBrush lineLeft = new LinearGradientBrush(recLeft, dark, light, 0, true);
                        LinearGradientBrush lineRight = new LinearGradientBrush(recRight, light, dark, 0, true);

                        theGraphics.FillRectangle(lineLeft, x, (float)(y2 - height), SpaceX / 2, (float)(height));
                        theGraphics.FillRectangle(lineRight, x + SpaceX / 2, (float)(y2 - height), SpaceX / 2, (float)height);
                        //画数量
                        int numSizeX = x + SpaceX / 2 - (int)(GetStringWidth(theGraphics, Value[i].ToString(), fontLable) / 2);
                        theGraphics.DrawString(Value[i].ToString(), fontLable, Brushes.Black, numSizeX, (float)(y2 - PerY * Value[i] - 14));
                        //画百分比
                        string percent = ((double)Value[i] / _total).ToString("p2");
                        int percentSizeX = x + SpaceX / 2 - (int)(GetStringWidth(theGraphics, percent, fontLable) / 2);
                        theGraphics.DrawString(percent, fontLable, Brushes.Black, percentSizeX, (float)(y2 - PerY * Value[i] - 25));
                    }
                    //画X坐标值
                    string xLableName = Xlable[i].ToString("f3");
                    int axisSizeX = x - (int)(GetStringWidth(theGraphics, xLableName, fontLable) / 2);
                    if (x != x1)
                    {
                        theGraphics.DrawString(xLableName, fontLable, Brushes.Black, axisSizeX, y2);
                    }
                    x += SpaceX;
                    if (i == _floorNum - 1)
                    {
                        theGraphics.DrawLine(new Pen(Color.Blue), x, y1 + 25, x, y2);
                    }
                    if (i == _floorNum + _normalNum - 1)
                    {
                        theGraphics.DrawLine(new Pen(Color.Red), x, y1 + 25, x, y2);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>绘小图</summary>
        /// <param name="theGraphics"></param>
        public void StartDrawingPic(Graphics theGraphics)
        {
            try
            {
                theGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                MarginBottom = 5;
                int x1 = MapX + MarginLeft;
                int x2 = MapX + MapWidth - MarginRight;
                int y1 = MapY + MarginTop;
                int y2 = MapY + MapHeight - MarginBottom;

                //确定背景颜色
                theGraphics.FillRectangle(Brushes.WhiteSmoke, MapX, MapY, MapWidth, MapHeight);

                //标题字体
                Font fontLable = new Font("Arial", 8, FontStyle.Regular);
                Font fontTitle = new Font("微软雅黑", 9f, FontStyle.Regular);
                Font fontTitleMiddle = new Font("微软雅黑", 14f, FontStyle.Bold);
                Brush titleBrush = new SolidBrush(Color.Black);
                float widthMiddle = (MapX + MapWidth - GetStringWidth(theGraphics, _faiName, fontTitle)) / 2;

                Point titlePoint = new Point((int)widthMiddle, MapY + 1);
                Point fieldPoint = new Point(x1 + 5, MapY + 10);
                Point cpkPoint = new Point(x1 + 5, MapY + 30);
                Point numPoint = new Point(x1 + 5, MapY + 50);

                //画标题
                theGraphics.DrawString(_faiName, fontTitleMiddle, titleBrush, titlePoint);
                //画良率
                theGraphics.DrawString($"Field={_field}", fontTitle, titleBrush, fieldPoint);
                //画CPK
                theGraphics.DrawString($"CPK/CP={_cpk.ToString("f3")}/{_cp.ToString("f3")}", fontTitle, titleBrush, cpkPoint);
                //画OK/NG数量
                theGraphics.DrawString($"OK/NG={_ok}/{_ng}", fontTitle, titleBrush, numPoint);

                //画边框线
                theGraphics.DrawRectangle(new Pen(Color.Blue), MapX, MapY, MapWidth - 1, MapHeight - 1);

                #region //绘制Y轴标签
                var y = y2 - SpaceY;
                for (var i = 0; i < Ylable.Length - 1; i++)
                {
                    //Y轴标签
                    theGraphics.DrawString(Ylable[i + 1], fontLable, Brushes.Red, MapX + MarginLeft - 25, y - 5);
                    y -= SpaceY;
                }
                #endregion

                //X轴
                theGraphics.DrawLine(new Pen(Color.Blue, 2), x1, y2, x2, y2);
                //Y轴
                theGraphics.DrawLine(new Pen(Color.Blue, 2), x1, y1, x1, y2);

                //画直方图，并标志x坐标的序号
                var x = x1;
                SolidBrush VerBrushPositive = new SolidBrush(Color.Blue);
                SolidBrush backColor = new SolidBrush(Color.Black);
                SolidBrush VerBrushDisPositive = new SolidBrush(Color.Red);
                //画直方图，并标志x坐标的序号
                for (var i = 0; i < Value.Length; i++)
                {
                    Color darkGreen = Color.FromArgb(0, 100, 0);
                    Color lightGreen = Color.FromArgb(150, 255, 150);
                    Color darkRed = Color.FromArgb(123, 14, 14);
                    Color lightRed = Color.FromArgb(248, 114, 114);
                    Color darkYellow = Color.FromArgb(123, 123, 14);
                    Color lightYellow = Color.FromArgb(248, 248, 114);
                    Color dark = (i == 0 || i == Value.Length - 1) ? darkYellow :
                        ((i >= _floorNum && i < _floorNum + _normalNum) ? darkGreen : darkRed);
                    Color light = (i == 0 || i == Value.Length - 1) ? lightYellow :
                        ((i >= _floorNum && i < _floorNum + _normalNum) ? lightGreen : lightRed);

                    if (Value[i] != 0)
                    {
                        //Rectangle recLeft = new Rectangle(x, (int)Math.Round(y2 - PerY * Value[i], 0), SpaceX / 2, (int)Math.Round(PerY * Value[i], 0));
                        //Rectangle recRight = new Rectangle(x + SpaceX / 2, (int)Math.Round(y2 - PerY * Value[i], 0), SpaceX / 2, (int)Math.Round(PerY * Value[i], 0));

                        //LinearGradientBrush lineLeft = new LinearGradientBrush(recLeft, dark, light, 0, true);
                        //LinearGradientBrush lineRight = new LinearGradientBrush(recRight, light, dark, 0, true);
                        //theGraphics.FillRectangle(lineLeft, recLeft);
                        //theGraphics.FillRectangle(lineRight, recRight);

                        double height = PerY * Value[i];
                        Rectangle rec = new Rectangle(x, (int)(y2 - height), SpaceX, (int)height);
                        theGraphics.FillRectangle(new SolidBrush(light), rec);

                        Rectangle recLeft = new Rectangle(x - 1, (int)(y2 - height - 1), SpaceX / 2 + 2, (int)height + 2);
                        Rectangle recRight = new Rectangle(x + SpaceX / 2 - 1, (int)(y2 - height - 1), SpaceX / 2 + 2, (int)height + 2);
                        LinearGradientBrush lineLeft = new LinearGradientBrush(recLeft, dark, light, 0, true);
                        LinearGradientBrush lineRight = new LinearGradientBrush(recRight, light, dark, 0, true);

                        theGraphics.FillRectangle(lineLeft, x, (float)(y2 - height), SpaceX / 2, (float)(height));
                        theGraphics.FillRectangle(lineRight, x + SpaceX / 2, (float)(y2 - height), SpaceX / 2, (float)height);
                    }
                    x += SpaceX;
                    if (i == _floorNum - 1)
                    {
                        theGraphics.DrawLine(new Pen(Color.Blue), x, y1 + 10, x, y2);
                    }
                    if (i == _floorNum + _normalNum - 1)
                    {
                        theGraphics.DrawLine(new Pen(Color.Red), x, y1 + 10, x, y2);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>获取Y轴间隔</summary>
        /// <param name="max">最大值</param>
        /// <returns></returns>
        private double GetAxisYSpaceValue(double max)
        {
            var TenTimes = Math.Floor(Math.Log10(max));
            var MaxYInTen = max / Math.Pow(10, TenTimes);
            var IntMaxYInTen = Math.Floor(MaxYInTen * 5) + 1;
            return (int)Math.Ceiling(IntMaxYInTen / 5 * Math.Pow(10, TenTimes) / 10);
        }
        /// <summary>获取字符串宽度</summary>
        /// <param name="graphics">绘图</param>
        /// <param name="text">字符串</param>
        /// <param name="font">字体</param>
        /// <returns>宽度</returns>
        private float GetStringWidth(Graphics graphics, string text, Font font)
        {
            return graphics.MeasureString(text, font).Width;
        }
        #endregion
    }
}