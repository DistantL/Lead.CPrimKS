using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public partial class NLocalizer
    {
        public static string CycleTime { get; set; }
        public static string ChangeCurrentProductError { get; set; }
        public static string ChangesWillTakeEffectWhenYouRestartTheApplication { get; set; }
        public static string ConfigIsNullPleaseCheckPrimsConfigsXMLFile { get; set; }
        public static string ConfirmDeleteProduct { get; set; }
        public static string ConvertAbnormal { get; set; }
        public static string CurrentProductIsEmpty { get; set; }
        public static string CommonParamInitError { get; set; }



        public static void InitC()
        {
            CycleTime = GetString("CycleTime", "循环时间");
            ChangeCurrentProductError = GetString("ChangeCurrentProductError", "改变当前产品出错");
            ChangesWillTakeEffectWhenYouRestartTheApplication = GetString("ChangesWillTakeEffectWhenYouRestartTheApplication", "重启电脑后生效");
            ConfigIsNullPleaseCheckPrimsConfigsXMLFile = GetString("ConfigIsNullPleaseCheckPrimsConfigsXMLFile", "配置文件为空，请检查PrimsConfigs.xml文件");
            ConfirmDeleteProduct = GetString("ConfirmDeleteProduct", "确认删除产品？");
            ConvertAbnormal = GetString("ConvertAbnormal", "转换异常");
            CurrentProductIsEmpty = GetString("CurrentProductIsEmpty", "当前产品为空");
            CommonParamInitError = GetString("CommonParamInitError", "全局参数初始化出错");
        }
    }
}
