using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public partial class NLocalizer
    {
        public static string ParameterIsEmptyWhenViewingTheImage { get; set; }
        public static string PathIsEmptyWhenViewingTheImage { get; set; }
        public static string PleaseInputProductName { get; set; }
        public static string PleaseSwitchAutoMode { get; set; }
        public static string PleaseWait { get; set; }
        public static string PrimNotExist { get; set; }
        public static string PrimIsRuning { get; set; }
        public static string PrimRunFail { get; set; }
        public static string ProductNameRepeat { get; set; }
        public static string Property { get; set; }



        public static void InitP()
        {
            ParameterIsEmptyWhenViewingTheImage = GetString("ParameterIsEmptyWhenViewingTheImage", "查看图片时参数为空");
            PathIsEmptyWhenViewingTheImage = GetString("PathIsEmptyWhenViewingTheImage", "查看图片时路径为空");
            PleaseInputProductName = GetString("PleaseInputProductName", "请输入产品名称！");
            PleaseSwitchAutoMode = GetString("PleaseSwitchAutoMode", "请切换自动模式！");
            PleaseWait = GetString("PleaseWait", "请稍后！");
            PrimNotExist = GetString("PrimNotExist", "基元不存在");
            PrimIsRuning = GetString("PrimIsRuning", "基元运行中！");
            PrimRunFail = GetString("PrimRunFail", "基元运行失败");
            ProductNameRepeat = GetString("ProductNameRepeat", "产品名称重复");
            Property = GetString("Property", "属性");
        }
    }
}
