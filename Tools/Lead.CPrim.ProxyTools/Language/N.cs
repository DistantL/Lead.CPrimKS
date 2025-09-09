using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public partial class NLocalizer
    {
        public static string No { get; set; }
        public static string NotConnected { get; set; }
        public static string NotSupport { get; set; }



        public static void InitN()
        {
            No = GetString("No", "否");
            NotConnected = GetString("NotConnected", "未连接！");
            NotSupport = GetString("NotSupport", "不支持");
        }
    }
}
