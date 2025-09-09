using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public partial class NLocalizer
    {
        public static string SaveError { get; set; }
        public static string SaveSuccess { get; set; }
        public static string SetError { get; set; }
        public static string SetSuccess { get; set; }
        public static string ShowNotExist { get; set; }
        public static string SlaveNameIsNull { get; set; }
        public static string SlaveNameNotContains { get; set; }
        public static string StationNameRepeat { get; set; }



        public static void InitS()
        {
            SaveError = GetString("SaveError", "保存失败");
            SaveSuccess = GetString("SaveSuccess", "保存成功");
            SetError = GetString("SetError", "设置出错");
            SetSuccess = GetString("SetSuccess", "设置成功");
            ShowNotExist = GetString("ShowNotExist", "显示基元不存在");
            SlaveNameIsNull = GetString("SlaveNameIsNull", "从站名称为空");
            SlaveNameNotContains = GetString("SlaveNameNotContains", "从站名称不包含");
            StationNameRepeat = GetString("StationNameRepeat", "工站名称重复");
        }
    }
}
