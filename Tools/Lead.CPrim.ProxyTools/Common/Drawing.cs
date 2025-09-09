/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: Drawing.cs
 * Author: Victor
 * Description: 
 * CreateTime: 2022-10-10
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.1010><Victor><20221010>
 * 1、命名空间由Sunny.UI变更为Lead.CPrim.ProxyTools.Common
 * 
 * <3.3.23.0101><Victor><20230109>
 * 命名空间由Lead.CPrim.ProxyTools.Common变更为Lead.CPrim.ProxyTools
******************************************************************************/

using System;
using System.Drawing;

namespace Lead.CPrim.ProxyTools
{
    public static class Drawing
    {
        public static PointF CalcAzRangePoint(this PointF center, float range, float az, float xOffset = 0f, float yOffset = 0f)
        {
            float num = (float)(range * 1f * Math.Sin(az * Math.PI / 180.0));
            float num2 = (float)(range * 1f * Math.Cos(az * Math.PI / 180.0));
            return new PointF(center.X + xOffset + num, center.Y + yOffset - num2);
        }

        public static PointF CalcAzRangePoint(this Point center, float range, float az, float xOffset = 0f, float yOffset = 0f)
        {
            float num = (float)(range * 1f * Math.Sin(az * Math.PI / 180.0));
            float num2 = (float)(range * 1f * Math.Cos(az * Math.PI / 180.0));
            return new PointF(center.X + xOffset + num, center.Y + yOffset - num2);
        }

        public static double CalcDistance(this PointF pt1, PointF pt2)
        {
            float num = pt1.X - pt2.X;
            float num2 = pt1.Y - pt2.Y;
            return Math.Sqrt(num * num + num2 * num2);
        }

        public static double CalcDistance(this Point pt1, Point pt2)
        {
            int num = pt1.X - pt2.X;
            int num2 = pt1.Y - pt2.Y;
            return Math.Sqrt(num * num + num2 * num2);
        }

        public static double CalcAngle(this Point thisPoint, Point toPoint)
        {
            double num = Math.Atan2(thisPoint.Y - toPoint.Y, thisPoint.X - toPoint.X) * 180.0 / Math.PI;
            return (num - 270.0 + 720.0) % 360.0;
        }

        public static double CalcAngle(this PointF thisPoint, PointF toPoint)
        {
            double num = Math.Atan2(thisPoint.Y - toPoint.Y, thisPoint.X - toPoint.X) * 180.0 / Math.PI;
            return (num - 270.0 + 720.0) % 360.0;
        }

        public static PointF Center(this Rectangle rect)
        {
            return new PointF(rect.Left + rect.Width / 2f, rect.Top + rect.Height / 2f);
        }

        public static PointF Center(this RectangleF rect)
        {
            return new PointF(rect.Left + rect.Width / 2f, rect.Top + rect.Height / 2f);
        }

        public static Color Alpha(this Color color, int alpha)
        {
            alpha = Math.Max(0, alpha);
            alpha = Math.Min(255, alpha);
            return Color.FromArgb(alpha, color);
        }

        public static bool InRect(this Point point, Rectangle rect)
        {
            return point.X >= rect.Left && point.X <= rect.Right && point.Y >= rect.Top && point.Y <= rect.Bottom;
        }

        public static bool InRect(this Point point, RectangleF rect)
        {
            return point.X >= rect.Left && point.X <= rect.Right && point.Y >= rect.Top && point.Y <= rect.Bottom;
        }

        public static bool InRect(this PointF point, Rectangle rect)
        {
            return point.X >= rect.Left && point.X <= rect.Right && point.Y >= rect.Top && point.Y <= rect.Bottom;
        }

        public static bool InRect(this PointF point, RectangleF rect)
        {
            return point.X >= rect.Left && point.X <= rect.Right && point.Y >= rect.Top && point.Y <= rect.Bottom;
        }

        public static bool IsOverlap(this Rectangle rc1, Rectangle rc2)
        {
            return rc1.X + rc1.Width > rc2.X && rc2.X + rc2.Width > rc1.X && rc1.Y + rc1.Height > rc2.Y && rc2.Y + rc2.Height > rc1.Y;
        }

        public static bool IsOverlap(this RectangleF rc1, RectangleF rc2)
        {
            return rc1.X + rc1.Width > rc2.X && rc2.X + rc2.Width > rc1.X && rc1.Y + rc1.Height > rc2.Y && rc2.Y + rc2.Height > rc1.Y;
        }

        public static RectangleF CreateRectangleF(this PointF pf1, PointF pf2)
        {
            return new RectangleF(Math.Min(pf1.X, pf2.X), Math.Min(pf1.Y, pf2.Y), Math.Abs(pf1.X - pf2.X), Math.Abs(pf1.Y - pf2.Y));
        }

        public static Rectangle CreateRectangle(this Point pf1, Point pf2)
        {
            return new Rectangle(Math.Min(pf1.X, pf2.X), Math.Min(pf1.Y, pf2.Y), Math.Abs(pf1.X - pf2.X), Math.Abs(pf1.Y - pf2.Y));
        }

        public static double CalcY(this PointF pf1, PointF pf2, double x)
        {
            if (pf1.Y.Equals(pf2.Y))
            {
                return pf1.Y;
            }
            if (pf1.X.Equals(pf2.X))
            {
                return double.NaN;
            }
            double num = (pf2.Y - pf1.Y) * 1.0 / (pf2.X - pf1.X);
            double num2 = pf1.Y - num * pf1.X;
            return num * x + num2;
        }

        public static double CalcX(this PointF pf1, PointF pf2, double y)
        {
            if (pf1.X.Equals(pf2.X))
            {
                return pf1.X;
            }
            if (pf1.Y.Equals(pf2.Y))
            {
                return double.NaN;
            }
            double num = (pf2.Y - pf1.Y) * 1.0 / (pf2.X - pf1.X);
            double num2 = pf1.Y - num * pf1.X;
            return (y - num2) * 1.0 / num;
        }

        public static double CalcY(this Point pf1, Point pf2, double x)
        {
            if (pf1.Y == pf2.Y)
            {
                return pf1.Y;
            }
            if (pf1.X == pf2.X)
            {
                return double.NaN;
            }
            double num = (pf2.Y - pf1.Y) * 1.0 / (pf2.X - pf1.X);
            double num2 = pf1.Y - num * pf1.X;
            return num * x + num2;
        }

        public static double CalcX(this Point pf1, Point pf2, double y)
        {
            if (pf1.Y == pf2.Y)
            {
                return pf1.X;
            }
            if (pf1.X == pf2.X)
            {
                return double.NaN;
            }
            double num = (pf2.Y - pf1.Y) * 1.0 / (pf2.X - pf1.X);
            double num2 = pf1.Y - num * pf1.X;
            return (y - num2) * 1.0 / num;
        }

        public static Color StepColor(this Color color, int alpha)
        {
            if (alpha == 100)
            {
                return color;
            }
            byte a = color.A;
            byte r = color.R;
            byte g = color.G;
            byte b = color.B;
            int num = Math.Max(alpha, 0);
            double num2 = (num - 100.0) / 100.0;
            float num3;
            if (num2 > 100.0)
            {
                num3 = 255f;
                num2 = 1.0 - num2;
            }
            else
            {
                num3 = 0f;
                num2 = 1.0 + num2;
            }
            r = (byte)BlendColor(r, num3, num2);
            g = (byte)BlendColor(g, num3, num2);
            b = (byte)BlendColor(b, num3, num2);
            return Color.FromArgb(a, r, g, b);
        }

        private static double BlendColor(double fg, double bg, double alpha)
        {
            double num = bg + alpha * (fg - bg);
            if (num < 0.0)
            {
                num = 0.0;
            }
            if (num > 255.0)
            {
                num = 255.0;
            }
            return num;
        }

        public static Point Offset(this Point point, Size size)
        {
            point.Offset(size.Width, size.Height);
            return point;
        }

        public static Size MultiplyWidth(this Size size, int multiple)
        {
            return new Size(size.Width * multiple, size.Height);
        }

        public static Size MultiplyHeight(this Size size, int multiple)
        {
            return new Size(size.Width, size.Height * multiple);
        }

        public static Size MultiplyAll(this Size size, int multiple)
        {
            return new Size(size.Width * multiple, size.Height * multiple);
        }

        public static Size MultiplyWidth(this Size size, double multiple)
        {
            return new Size((int)(size.Width * multiple), size.Height);
        }

        public static Size MultiplyHeight(this Size size, double multiple)
        {
            return new Size(size.Width, (int)(size.Height * multiple));
        }

        public static Size MultiplyAll(this Size size, double multiple)
        {
            return new Size((int)(size.Width * multiple), (int)(size.Height * multiple));
        }

        public static bool IsVisible(this Rectangle rect)
        {
            return rect.Width > 0 && rect.Height > 0;
        }

        public static Color RandomColor()
        {
            Random random = new Random();
            return Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        }

        public static Color MixColors(this Color[] colors)
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            for (int i = 0; i < colors.Length; i++)
            {
                Color color = colors[i];
                num += color.R;
                num2 += color.B;
                num3 += color.B;
            }
            return Color.FromArgb(num / colors.Length, num2 / colors.Length, num3 / colors.Length);
        }
    }
}
