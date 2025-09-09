using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public partial class NLocalizer
    {
        public static string EleNotExist { get; set; }
        public static string Enable { get; set; }
        public static string EnterRunningMode { get; set; }
        public static string Error { get; set; }



        public static void InitE()
        {
            EleNotExist = GetString("EleNotExist", "元件不存在");
            Enable = GetString("Enable", "启用");
            EnterRunningMode = GetString("EnterRunningMode", "进入运行模式？");
            Error = GetString("Error", "错误");
        }
    }
}
