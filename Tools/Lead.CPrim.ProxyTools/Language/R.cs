using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public partial class NLocalizer
    {
        public static string ReturnResultNotZero { get; set; }
        public static string RunError { get; set; }
        public static string Running { get; set; }



        public static void InitR()
        {
            ReturnResultNotZero = GetString("ReturnResultNotZero", "返回值不为0");
            RunError = GetString("Running", "运行失败");
            Running = GetString("Running", "运行中");
        }
    }
}
