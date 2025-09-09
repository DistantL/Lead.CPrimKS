using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 软件常用颜色
    /// </summary>
    public static class Colors
    {
        ///// <summary>
        ///// 主要边框颜色<br/>
        ///// 180, 180, 180
        ///// </summary>
        //public static Color PrimaryRectColor = PrimaryBackColor180;


        ///// <summary>
        ///// 主要填充颜色深色<br/>
        ///// 211, 211, 211
        ///// </summary>
        //public static Color PrimaryFillColorDark = PrimaryBackColor211;

        ///// <summary>
        ///// 主要填充颜色浅色<br/>
        ///// 236, 236, 236
        ///// </summary>
        //public static Color PrimaryFillColorLight = PrimaryBackColor236;

        ///// <summary>
        ///// 主要背景颜色深色<br/>
        ///// 236, 236, 236
        ///// </summary>
        //public static Color PrimaryBackColorDark = PrimaryBackColor236;

        ///// <summary>
        ///// 主要背景颜色浅色<br/>
        ///// WhiteSmoke
        ///// </summary>
        //public static Color PrimaryBackColorLight = PrimaryBackColor255;

        /// <summary>
        /// 主要边框颜色<br/>
        /// 180, 180, 180
        /// </summary>
        public static Color PrimaryRectColor { get; set; }


        /// <summary>
        /// 主要填充颜色深色<br/>
        /// 211, 211, 211
        /// </summary>
        public static Color PrimaryFillColorDark { get; set; }

        /// <summary>
        /// 主要填充颜色浅色<br/>
        /// 236, 236, 236
        /// </summary>
        public static Color PrimaryFillColorLight { get; set; }

        /// <summary>
        /// 主要背景颜色深色<br/>
        /// 236, 236, 236
        /// </summary>
        public static Color PrimaryBackColorDark { get; set; }

        /// <summary>
        /// 主要背景颜色浅色<br/>
        /// 255, 255, 255
        /// </summary>
        public static Color PrimaryBackColorLight { get; set; }


        /// <summary>
        /// 颜色128<br/>
        /// 128, 128, 128
        /// </summary>
        public static Color PrimaryBackColor128 = Color.FromArgb(128, 128, 128);

        /// <summary>
        /// 颜色180<br/>
        /// 180, 180, 180
        /// </summary>
        public static Color PrimaryBackColor180 = Color.FromArgb(180, 180, 180);

        /// <summary>
        /// 颜色211<br/>
        /// 211, 211, 211
        /// </summary>
        public static Color PrimaryBackColor211 = Color.FromArgb(211, 211, 211);

        /// <summary>
        /// 颜色236<br/>
        /// 236, 236, 236
        /// </summary>
        public static Color PrimaryBackColor236 = Color.FromArgb(236, 236, 236);

        /// <summary>
        /// 颜色255<br/>
        /// 255, 255, 255
        /// </summary>
        public static Color PrimaryBackColor255 = Color.FromArgb(255, 255, 255);





        /// <summary>
        /// 主要字体颜色深色<br/>
        /// 32, 32, 32
        /// </summary>
        public static Color PrimaryForeColorDark = Color.FromArgb(32, 32, 32);

        /// <summary>
        /// 主要字体颜色浅色<br/>
        /// WhiteSmoke
        /// </summary>
        public static Color PrimaryForeColorLight = Color.WhiteSmoke;



        static Colors()
        {
            PrimaryRectColor = PrimaryBackColor180;
            PrimaryFillColorDark = PrimaryBackColor211;
            PrimaryFillColorLight = PrimaryBackColor236;
            PrimaryBackColorDark = PrimaryBackColor236;
            PrimaryBackColorLight = PrimaryBackColor255;
        }
    }
}
