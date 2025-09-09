using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public static class GlobalVariables
    {
        /// <summary>
        /// 当前工站名称
        /// </summary>
        public static string CurrentStationName { get; set; }

        /// <summary>
        /// 中文编码
        /// </summary>
        public static readonly Encoding EncodingChinese = Encoding.GetEncoding("GB2312");
    }
}
