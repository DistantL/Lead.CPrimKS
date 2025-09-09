using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public partial class NLocalizer
    {
        public static string ID { get; set; }
        public static string Info { get; set; }
        public static string InitError { get; set; }
        public static string InitDoneConfirmEnterRunningMode { get; set; }
        public static string InValid { get; set; }
        /// <summary>
        /// 导入csv
        /// </summary>
        public static string ImportCSV { get; set; }



        public static void InitI()
        {
            ID = GetString("ID", "编号");
            Info = GetString("Info", "信息");
            InitError = GetString("InitError", "初始化失败");
            InitDoneConfirmEnterRunningMode = GetString("InitDoneConfirmEnterRunningMode", "初始化完成，是否进入运行模式？");
            InValid = GetString("InValid", "无效");
            ImportCSV = GetString("ImportCSV", "导入csv");
        }
    }
}
