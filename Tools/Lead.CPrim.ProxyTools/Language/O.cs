using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public partial class NLocalizer
    {
        public static string OnlyWaitResetStateCanBeSwitched { get; set; }
        public static string OnlyRunningStateCanBeSwitched { get; set; }
        public static string OperationIsInvalidWhenViewingTheImage { get; set; }



        public static void InitO()
        {
            OnlyWaitResetStateCanBeSwitched = GetString("OnlyWaitResetStateCanBeSwitched", "仅待复位状态可以被切换！");
            OnlyRunningStateCanBeSwitched = GetString("OnlyRunningStateCanBeSwitched", "仅运行中状态可以被切换！");
            OperationIsInvalidWhenViewingTheImage = GetString("OperationIsInvalidWhenViewingTheImage", "查看图片时操作无效");
        }
    }
}
