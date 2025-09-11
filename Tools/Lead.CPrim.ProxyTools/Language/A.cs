using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public partial class NLocalizer
    {
        public static string Add { get; set; }
        public static string Apply { get; set; }
        public static string ApplyError { get; set; }
        public static string ApplySuccess { get; set; }
        public static string AxisNotExist { get; set; }
        public static string AxisIsAbsoluteServoConfirmBackToZero { get; set; }



        public static void InitA()
        {
            Add = GetString("Add", "增加");
            Apply = GetString("Apply", "应用");
            ApplyError = GetString("ApplyError", "应用错误");
            ApplySuccess = GetString("ApplySuccess", "应用成功");
            AxisNotExist = GetString("AxisNotExist", "轴不存在");
            AxisIsAbsoluteServoConfirmBackToZero = GetString("AxisIsAbsoluteServoConfirmBackToZero", "轴是绝对式伺服，确定回零吗？");
        }
    }
}
