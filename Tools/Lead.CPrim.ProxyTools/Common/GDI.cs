/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: GDI.cs
 * Author: Victor
 * Description: GDI扩展类
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 2020-01-01: V2.2.0 增加文件说明
 * 2021-08-19: V3.0.6 修复CreateRoundedRectanglePath参数radius=0时的错误 
 * 2021-08-20: V3.0.6 整理了一些GDI绘图的常用方法扩展 
 *
 * <3.3.22.0728><Victor><20220805>
 * 1、修改备注
 * 
 * <3.3.22.1010><Victor><20221010>
 * 1、Drawing.cs将逐步移入到该类
 * 
 * <3.3.23.0101><Victor><20230109>
 * 命名空间由Lead.CPrim.ProxyTools.Common变更为Lead.CPrim.ProxyTools
******************************************************************************/

using Sunny.UI;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>GDI帮助类</summary>
    public static class GDI
    {
        /// <summary>Graphics</summary>
        private static Graphics TempGraphics;



        #region Point扩展方法
        /// <summary>point是否在Region内</summary>
        /// <param name="point">Point</param>
        /// <param name="region">Region</param>
        /// <returns>true：在Region内；false：不在Region内</returns>
        public static bool InRegion(this Point point, Region region)
        {
            return region.IsVisible(point);
        }
        /// <summary>PointF是否在Region内</summary>
        /// <param name="point">PointF</param>
        /// <param name="region">Region</param>
        /// <returns>true：在Region内；false：不在Region内</returns>
        public static bool InRegion(this PointF point, Region region)
        {
            return region.IsVisible(point);
        }
        /// <summary>Point是否在Point[]内</summary>
        /// <param name="point">Point</param>
        /// <param name="points">Point[]</param>
        /// <returns>true：在Point[]内；false：不在Point[]内</returns>
        public static bool InRegion(this Point point, Point[] points)
        {
            using (GraphicsPath path = points.Path())
            using (Region region = path.Region())
            {
                return point.InRegion(region);
            }
        }
        /// <summary>PointF是否在PointF[]内</summary>
        /// <param name="point">PointF</param>
        /// <param name="points">PointF[]</param>
        /// <returns>true：在PointF[]内；false：不在PointF[]内</returns>
        public static bool InRegion(this PointF point, PointF[] points)
        {
            using (GraphicsPath path = points.Path())
            using (Region region = path.Region())
            {
                return point.InRegion(region);
            }
        }
        /// <summary>Point[]创建GraphicsPath</summary>
        /// <param name="points">Point[]</param>
        /// <returns>GraphicsPath</returns>
        public static GraphicsPath Path(this Point[] points)
        {
            GraphicsPath path = new GraphicsPath();
            path.Reset();
            path.AddPolygon(points);
            return path;
        }
        /// <summary>PointF[]创建GraphicsPath</summary>
        /// <param name="points">PointF[]</param>
        /// <returns>GraphicsPath</returns>
        public static GraphicsPath Path(this PointF[] points)
        {
            GraphicsPath path = new GraphicsPath();
            path.Reset();
            path.AddPolygon(points);
            return path;
        }
        /// <summary>PointF转化为Point</summary>
        /// <param name="point">PointF</param>
        /// <returns>Point</returns>
        public static Point Point(this PointF point)
        {
            return new Point(point.X.RoundEx(), point.Y.RoundEx());
        }
        /// <summary>创建区域</summary>
        /// <param name="path">路径</param>
        /// <returns>区域</returns>
        public static Region Region(this GraphicsPath path)
        {
            Region region = new Region();
            region.MakeEmpty();
            region.Union(path);
            return region;
        }
        /// <summary>Rectangle转化为GraphicsPath</summary>
        /// <param name="rect">Rectangle</param>
        /// <returns>GraphicsPath</returns>
        public static GraphicsPath GraphicsPath(this Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();
            path.Reset();
            path.AddRectangle(rect);
            return path;
        }
        #endregion


        #region 判断字体适合Black还是White
        /// <summary>根据背景色判断前景色</summary>
        /// <param name="backColor">背景色</param>
        /// <returns>前景色</returns>
        public static Color ForeColor(Color backColor)
        {
            double gray = (0.299 * backColor.R + 0.587 * backColor.G + 0.114 * backColor.B) / 255;
            return gray > 0.5 ? Color.Black : Color.White;
        }
        #endregion


        #region Size扩展方法
        /// <summary>SizeF转化为Size</summary>
        /// <param name="size">SizeF</param>
        /// <returns>Size</returns>
        public static Size SizeF(this SizeF size)
        {
            return new Size(size.Width.RoundEx(), size.Height.RoundEx());
        }
        /// <summary>Size变化</summary>
        /// <param name="size">Size</param>
        /// <param name="width">Size变化的宽度</param>
        /// <param name="height">Size变化的高度</param>
        /// <returns>变化后Size</returns>
        public static Size Add(this Size size, int width, int height)
        {
            return new Size(size.Width + width, size.Height + height);
        }
        /// <summary>SizeF变化</summary>
        /// <param name="size">SizeF</param>
        /// <param name="width">SizeF变化的宽度</param>
        /// <param name="height">SizeF变化的高度</param>
        /// <returns>变化后SizeF</returns>
        public static SizeF Add(this SizeF size, float width, float height)
        {
            return new SizeF(size.Width + width, size.Height + height);
        }
        #endregion



        #region 计算文字大小
        /// <summary>提供一个Graphics，常用于需要计算文字大小时</summary>
        /// <returns>Graphics</returns>
        public static Graphics Graphics()
        {
            if (TempGraphics == null)
            {
                Bitmap bmp = new Bitmap(1, 1);
                TempGraphics = bmp.Graphics();
            }

            return TempGraphics;
        }
        /// <summary>计算文字大小</summary>
        /// <param name="text">文字</param>
        /// <param name="font">字体</param>
        /// <returns>大小</returns>
        public static SizeF MeasureString(this string text, Font font)
        {
            return Graphics().MeasureString(text, font);
        }
        #endregion


        #region 绘图质量设置
        /// <summary>设置GDI呈现质量</summary>
        /// <param name="g"></param>
        /// <param name="smooth">true：高质量；false：默认值；</param>
        /// <returns></returns>
        public static Graphics Smooth(this Graphics g, bool smooth = true)
        {
            if (smooth)
            {
                g.SetHighQuality();
            }
            else
            {
                g.SetDefaultQuality();
            }

            return g;
        }
        /// <summary>设置GDI高质量模式抗锯齿</summary>
        /// <param name="g"></param>
        public static Graphics SetHighQuality(this Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;  //使绘图质量最高，即消除锯齿
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
            return g;
        }
        /// <summary>设置GDI默认值</summary>
        /// <param name="g"></param>
        public static Graphics SetDefaultQuality(this Graphics g)
        {
            g.SmoothingMode = SmoothingMode.Default;
            g.InterpolationMode = InterpolationMode.Default;
            g.CompositingQuality = CompositingQuality.Default;
            return g;
        }
        #endregion



        #region 创建扇形区域
        /// <summary>创建扇形区域</summary>
        /// <param name="g">Graphics</param>
        /// <param name="center">扇形中心区域（Point）</param>
        /// <param name="d1">扇形内圆半径</param>
        /// <param name="d2">扇形外圆半径</param>
        /// <param name="startAngle">扇形开始角度</param>
        /// <param name="sweepAngle">扇形角度</param>
        /// <returns>GraphicsPath</returns>
        public static GraphicsPath CreateFanPath(this Graphics g, Point center, float d1, float d2, float startAngle, float sweepAngle)
        {
            return center.CreateFanPath(d1, d2, startAngle, sweepAngle);
        }
        /// <summary>创建扇形区域</summary>
        /// <param name="g">Graphics</param>
        /// <param name="center">扇形中心区域（PointF）</param>
        /// <param name="d1">扇形内圆半径</param>
        /// <param name="d2">扇形外圆半径</param>
        /// <param name="startAngle">扇形开始角度</param>
        /// <param name="sweepAngle">扇形角度</param>
        /// <returns>GraphicsPath</returns>
        public static GraphicsPath CreateFanPath(this Graphics g, PointF center, float d1, float d2, float startAngle, float sweepAngle)
        {
            return center.CreateFanPath(d1, d2, startAngle, sweepAngle);
        }
        /// <summary>创建扇形区域</summary>
        /// <param name="center">扇形中心区域（Point）</param>
        /// <param name="d1">扇形内圆半径</param>
        /// <param name="d2">扇形外圆半径</param>
        /// <param name="startAngle">扇形开始角度</param>
        /// <param name="sweepAngle">扇形角度</param>
        /// <returns>GraphicsPath</returns>
        public static GraphicsPath CreateFanPath(this Point center, float d1, float d2, float startAngle, float sweepAngle)
        {
            return new PointF(center.X, center.Y).CreateFanPath(d1, d2, startAngle, sweepAngle);
        }
        /// <summary>创建扇形区域</summary>
        /// <param name="center">扇形中心区域（PointF）</param>
        /// <param name="d1">扇形内圆半径</param>
        /// <param name="d2">扇形外圆半径</param>
        /// <param name="startAngle">扇形开始角度</param>
        /// <param name="sweepAngle">扇形角度</param>
        /// <returns>GraphicsPath</returns>
        public static GraphicsPath CreateFanPath(this PointF center, float d1, float d2, float startAngle, float sweepAngle)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(center.X - d1, center.Y - d1, d1 * 2, d1 * 2, startAngle, sweepAngle);
            path.AddArc(center.X - d2, center.Y - d2, d2 * 2, d2 * 2, startAngle + sweepAngle, -sweepAngle);
            path.AddArc(center.X - d1, center.Y - d1, d1 * 2, d1 * 2, startAngle, 0.1f);
            return path;
        }
        #endregion


        #region 矩形圆角
        /// <summary>矩形圆角</summary>
        /// <param name="g">Graphics</param>
        /// <param name="rect">Rectangle</param>
        /// <param name="radius">圆角（圆形直径）</param>
        /// <param name="radiusSides">所有圆角</param>
        /// <returns>GraphicsPath</returns>
        public static GraphicsPath CreateRoundedRectanglePath(this Graphics g, Rectangle rect, int radius, UICornerRadiusSides radiusSides)
        {
            return rect.CreateRoundedRectanglePath(radius, radiusSides);
        }
        /// <summary>矩形圆角</summary>
        /// <param name="rect">Rectangle</param>
        /// <param name="radius">圆角（圆形直径）</param>
        /// <param name="radiusSides">所有圆角</param>
        /// <param name="lineSize">圆角倍数（直接与圆角相乘）</param>
        /// <returns>GraphicsPath</returns>
        public static GraphicsPath CreateRoundedRectanglePath(this Rectangle rect, int radius, UICornerRadiusSides radiusSides, int lineSize = 1)
        {
            GraphicsPath path;

            if (radiusSides == UICornerRadiusSides.None || radius == 0)
            {
                path = rect.GraphicsPath();
            }
            else
            {
                //IsRadius为True时，显示左上圆角
                bool RadiusLeftTop = radiusSides.GetValue(UICornerRadiusSides.LeftTop);
                //IsRadius为True时，显示左下圆角
                bool RadiusLeftBottom = radiusSides.GetValue(UICornerRadiusSides.LeftBottom);
                //IsRadius为True时，显示右上圆角
                bool RadiusRightTop = radiusSides.GetValue(UICornerRadiusSides.RightTop);
                //IsRadius为True时，显示右下圆角
                bool RadiusRightBottom = radiusSides.GetValue(UICornerRadiusSides.RightBottom);
                path = rect.CreateRoundedRectanglePath(radius, RadiusLeftTop, RadiusRightTop, RadiusRightBottom, RadiusLeftBottom, lineSize);
            }

            return path;
        }
        /// <summary>矩形圆角</summary>
        /// <param name="g">Graphics</param>
        /// <param name="rect">Rectangle</param>
        /// <param name="radius">圆角（圆形直径）</param>
        /// <param name="cornerLeftTop">true：左上角圆角；false：左上角直角</param>
        /// <param name="cornerRightTop">true：右上角圆角；false：右上角直角</param>
        /// <param name="cornerRightBottom">true：右下角圆角；false：右下角直角</param>
        /// <param name="cornerLeftBottom">true：左下角圆角；false：左下角直角</param>
        /// <returns>GraphicsPath</returns>
        public static GraphicsPath CreateRoundedRectanglePath(this Graphics g, Rectangle rect, int radius, bool cornerLeftTop = true, bool cornerRightTop = true, bool cornerRightBottom = true, bool cornerLeftBottom = true)
        {
            return rect.CreateRoundedRectanglePath(radius, cornerLeftTop, cornerRightTop, cornerRightBottom, cornerLeftBottom);
        }
        /// <summary>矩形圆角</summary>
        /// <param name="rect">Rectangle</param>
        /// <param name="radius">圆角（圆形直径）</param>
        /// <param name="cornerLeftTop">true：左上角圆角；false：左上角直角</param>
        /// <param name="cornerRightTop">true：右上角圆角；false：右上角直角</param>
        /// <param name="cornerRightBottom">true：右下角圆角；false：右下角直角</param>
        /// <param name="cornerLeftBottom">true：左下角圆角；false：左下角直角</param>
        /// <param name="lineSize">圆角倍数（直接与圆角相乘）</param>
        /// <returns>GraphicsPath</returns>
        public static GraphicsPath CreateRoundedRectanglePath(this Rectangle rect, int radius, bool cornerLeftTop = true, bool cornerRightTop = true, bool cornerRightBottom = true, bool cornerLeftBottom = true, int lineSize = 1)
        {
            GraphicsPath path = new GraphicsPath();
            if (!cornerLeftTop && !cornerRightTop && !cornerRightBottom && !cornerLeftBottom || radius <= 0)
            {
                path = rect.GraphicsPath();
            }
            else
            {
                radius *= lineSize;
                //左上
                if (cornerLeftTop)
                {
                    path.AddArc(rect.Left, rect.Top, radius, radius, 180, 90);
                }
                else
                {
                    path.AddLine(new Point(rect.Left, rect.Top + 1), new Point(rect.Left, rect.Top));
                }

                //右上
                if (cornerRightTop)
                {
                    path.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90);
                }
                else
                {
                    path.AddLine(new Point(rect.Right - 1, rect.Top), new Point(rect.Right, rect.Top));
                }

                //右下
                if (cornerRightBottom)
                {
                    path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                }
                else
                {
                    path.AddLine(new Point(rect.Right, rect.Bottom - 1), new Point(rect.Right, rect.Bottom));
                }

                //左下
                if (cornerLeftBottom)
                {
                    path.AddArc(rect.Left, rect.Bottom - radius, radius, radius, 90, 90);
                }
                else
                {
                    path.AddLine(new Point(rect.Left + 1, rect.Bottom), new Point(rect.Left, rect.Bottom));
                }

                //闭合
                path.CloseFigure();
            }
            return path;
        }
        #endregion


        #region Color扩展方法
        /// <summary>Color增加透明度</summary>
        /// <param name="color">Color</param>
        /// <param name="alpha">透明度</param>
        /// <returns>Color</returns>
        public static Color Alpha(this Color color, int alpha)
        {
            alpha = Math.Max(0, alpha);
            alpha = Math.Min(255, alpha);
            return Color.FromArgb(alpha, color);
        }
        /// <summary>Color转化为HTML颜色</summary>
        /// <param name="color">Color</param>
        /// <returns>HTML颜色</returns>
        public static string ToHTML(this Color color)
        {
            return ColorTranslator.ToHtml(color);
        }
        /// <summary>判断Color是否为空或透明</summary>
        /// <param name="color">Color</param>
        /// <returns>true：Color为空或者透明；false：非空同时非透明</returns>
        public static bool IsNullOrEmpty(this Color color)
        {
            return color == Color.Empty || color == Color.Transparent;
        }
        /// <summary>Color转化为SolidBrush</summary>
        /// <param name="color">Color</param>
        /// <returns>SolidBrush</returns>
        public static SolidBrush Brush(this Color color)
        {
            return new SolidBrush(color);
        }
        /// <summary>根据Color及Size创建Pen</summary>
        /// <param name="color">Color</param>
        /// <param name="size">线宽</param>
        /// <returns>Pen</returns>
        public static Pen Pen(this Color color, float size = 1)
        {
            return new Pen(color, size);
        }
        /// <summary>Color是否有效</summary>
        /// <param name="color">Color</param>
        /// <returns>true：有效；false：无效</returns>
        public static bool IsValid(this Color color)
        {
            return !color.IsNullOrEmpty();
        }
        #endregion


        #region HTML颜色扩展方法
        /********
         * #FFFFFF
         * 颜色由一个十六进制符号来定义，这个符号由红色、绿色和蓝色的值组成（RGB）。
         * 每种颜色的最小值是 0（十六进制：#00）。最大值是 255（十六进制：#FF）。
        ********/
        /// <summary>根据HTML颜色及透明度创建Color</summary>
        /// <param name="htmlColor">HTML颜色</param>
        /// <param name="alpha">透明度</param>
        /// <returns>Color</returns>
        public static Color ToColor(this string htmlColor, int alpha = 255)
        {
            return Color.FromArgb(alpha > 255 ? 255 : alpha, ColorTranslator.FromHtml(htmlColor));
        }
        /// <summary>根据HTML颜色及透明度创建SolidBrush</summary>
        /// <param name="htmlColor">HTML颜色</param>
        /// <param name="alpha">透明度</param>
        /// <returns>SolidBrush</returns>
        public static SolidBrush Brush(this string htmlColor, int alpha = 255)
        {
            return htmlColor.ToColor(alpha).Brush();
        }
        /// <summary>根据HTML颜色、透明度、线宽及线帽样式创建Pen</summary>
        /// <param name="htmlColor">HTML颜色</param>
        /// <param name="alpha">透明度</param>
        /// <param name="size">线宽</param>
        /// <param name="startCap">开始线帽样式</param>
        /// <param name="endCap">结束线帽样式</param>
        /// <returns>Pen</returns>
        public static Pen Pen(this string htmlColor, int alpha = 255, float size = 1, LineCap startCap = LineCap.Custom, LineCap endCap = LineCap.Custom)
        {
            return new Pen(htmlColor.ToColor(alpha), size)
            {
                StartCap = startCap,
                EndCap = endCap
            };
        }
        #endregion


        #region 字体类
        /// <summary></summary>
        /// <param name="fontName"></param>
        /// <param name="size"></param>
        /// <param name="fontStyle"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static Font ToFont(this string fontName, float size, FontStyle fontStyle = FontStyle.Regular, GraphicsUnit unit = GraphicsUnit.Pixel)
        {
            return new Font(fontName, size, fontStyle, unit);
        }
        #endregion


        #region 渐变刷子
        /// <summary>渐变色</summary>
        /// <param name="startColor">开始颜色</param>
        /// <param name="endColor">结束颜色</param>
        /// <param name="count">颜色个数</param>
        /// <returns>Colorp[]</returns>
        public static Color[] GradientColors(this Color startColor, Color endColor, int count)
        {
            count = Math.Max(count, 2);
            Bitmap image = new Bitmap(1024, 3);
            Graphics g = image.Graphics();
            Brush br = new LinearGradientBrush(image.Bounds(), startColor, endColor, 0.0F);
            g.FillRectangle(br, image.Bounds());
            br.Dispose();
            g.Dispose();

            Color[] colors = new Color[count];
            colors[0] = startColor;
            colors[count - 1] = endColor;

            if (count > 2)
            {
                FastBitmap fb = new FastBitmap(image);
                fb.Lock();
                for (int i = 1; i < count - 1; i++)
                {
                    colors[i] = fb.GetPixel(image.Width * i / (count - 1), 1);
                }

                fb.Unlock();
                fb.Dispose();
            }

            image.Dispose();
            return colors;
        }
        /// <summary>渐变刷子</summary>
        /// <param name="centerColor">中心颜色</param>
        /// <param name="surroundColor">周围颜色</param>
        /// <param name="point">X等于0，Y不等于0：X轴对称渐变；X不等于0，Y等于0：Y轴对称渐变；XY均不等于0：中心颜色纯色填充</param>
        /// <param name="gp">表示一系列连接的直线和曲线（区域）</param>
        /// <param name="wrapMode">指定当纹理或渐变小于所填充的区域时平铺纹理或渐变的方式</param>
        /// <returns>渐变刷子</returns>
        public static Brush GlowBrush(Color centerColor, Color[] surroundColor, PointF point, GraphicsPath gp, WrapMode wrapMode = WrapMode.Clamp)
        {
            return new PathGradientBrush(gp)
            {
                CenterColor = centerColor,
                SurroundColors = surroundColor,
                FocusScales = point,
                WrapMode = wrapMode
            };
        }
        /// <summary>渐变刷子（待验证）</summary>
        /// <param name="centerColor"></param>
        /// <param name="surroundColor"></param>
        /// <param name="point"></param>
        /// <param name="wrapMode"></param>
        /// <returns></returns>
        public static Brush GlowBrush(Color centerColor, Color[] surroundColor, PointF[] point, WrapMode wrapMode = WrapMode.Clamp)
        {
            return new PathGradientBrush(point)
            {
                CenterColor = centerColor,
                SurroundColors = surroundColor,
                WrapMode = wrapMode
            };
        }
        #endregion


        #region 对齐方式
        /// <summary>对齐方式设置</summary>
        /// <param name="horizontalAlignment">水平对齐方式</param>
        /// <param name="verticalAlignment">垂直对齐方式</param>
        /// <returns>StringFormat</returns>
        public static StringFormat SetAlignment(StringAlignment horizontalAlignment = StringAlignment.Center, StringAlignment verticalAlignment = StringAlignment.Center)
        {
            return new StringFormat
            {
                Alignment = horizontalAlignment,
                LineAlignment = verticalAlignment
            };
        }
        #endregion


        /// <summary>圆形四周填充</summary>
        /// <param name="graphics"></param>
        /// <param name="rec"></param>
        private static void DrawFillEllipseAround(Graphics graphics, Rectangle rec)
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(rec);
            PathGradientBrush pb = new PathGradientBrush(gp)
            {
                CenterColor = Color.White,
                SurroundColors = new Color[] { Color.LimeGreen }
            };
            graphics.FillPath(pb, gp);
        }
    }
}