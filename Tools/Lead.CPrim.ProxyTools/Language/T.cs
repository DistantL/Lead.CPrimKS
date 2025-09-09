using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public partial class NLocalizer
    {
        public static string TaskInitError { get; set; }
        public static string TaskStationMachineRemoveError { get; set; }
        public static string TaskStationMachineInitError { get; set; }
        public static string TestError { get; set; }
        public static string TestSuccess { get; set; }
        public static string TraceEndPosition { get; set; }
        public static string TraceStartPosition { get; set; }
        public static string TriggerEndPosition { get; set; }
        public static string TriggerError { get; set; }
        public static string TriggerLinearTrigDatasIsEmpty { get; set; }
        public static string TriggerLinearTrigDatasNotExist { get; set; }
        public static string TriggerChannelCountIsZero { get; set; }
        public static string TriggerChannelNotConfig { get; set; }
        public static string TriggerNotContainsCurrentProduct { get; set; }
        public static string TriggerPrimNotExist { get; set; }
        public static string TriggerPortIsEmpty { get; set; }
        public static string TriggerPortNotEnabled { get; set; }
        public static string TriggerPortNotExist { get; set; }
        public static string TriggerStartPosition { get; set; }
        public static string TriggerSuccess { get; set; }
        public static string TriggerTableTrigDatasIsEmpty { get; set; }
        public static string TriggerTableTrigDatasNotExist { get; set; }


        
        public static void InitT()
        {
            TaskInitError = GetString("TaskInitError", "脚本初始化出错：");
            TaskStationMachineRemoveError = GetString("TaskStationMachineRemoveError", "工站状态机移除失败：");
            TaskStationMachineInitError = GetString("TaskStationMachineInitError", "工站状态机初始化失败：");
            TestError = GetString("TestError", "测试出错");
            TestSuccess = GetString("TestSuccess", "测试成功");
            TraceEndPosition = GetString("TraceEndPosition", "轨迹结束位置");
            TraceStartPosition = GetString("TraceStartPosition", "轨迹开始位置");
            TriggerEndPosition = GetString("TriggerEndPosition", "触发结束位置");
            TriggerError = GetString("TriggerError", "触发失败");
            TriggerLinearTrigDatasIsEmpty = GetString("TriggerLinearTrigDatasIsEmpty", "触发线性触发表为空");
            TriggerLinearTrigDatasNotExist = GetString("TriggerLinearTrigDatasNotExist", "触发线性触发表不存在");
            TriggerChannelCountIsZero = GetString("TriggerChannelCountIsZero", "触发通道数量为0");
            TriggerChannelNotConfig = GetString("TriggerChannelNotConfig", "触发通道未配置");
            TriggerNotContainsCurrentProduct = GetString("TriggerNotContainsCurrentProduct", "触发不包含当前产品");
            TriggerPrimNotExist = GetString("TriggerNotExist", "触发基元不存在");
            TriggerPortIsEmpty = GetString("TriggerPortIsEmpty", "触发端口为空");
            TriggerPortNotExist = GetString("TriggerPortNotExist", "触发端口不存在");
            TriggerStartPosition = GetString("TriggerStartPosition", "触发开始位置");
            TriggerSuccess = GetString("TriggerSuccess", "触发成功");
            TriggerTableTrigDatasIsEmpty = GetString("TriggerTableTrigDatasIsEmpty", "触发队列触发表为空");
            TriggerTableTrigDatasNotExist = GetString("TriggerTableTrigDatasNotExist", "触发队列触发表不存在");
        }
    }
}
