using Lead.CPrim.Interfaces.Task;
using System;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.Interfaces
{
    /// <summary>日志内容UI归属</summary>
    public enum LogType
    {
        /// <summary>归属tabControl1</summary>
        A,
        /// <summary>归属tabControl2</summary>
        B,
        /// <summary>归属tabControl3</summary>
        C,
        /// <summary>归属tabControl4</summary>
        D,
    }


    /// <summary>任务文件类型</summary>
    public enum TaskFileType
    {
        /// <summary>File</summary>
        File = 0,
        /// <summary>Asm</summary>
        Asm = 1,
        /// <summary>Other</summary>
        Other = 100
    }



    /// <summary>任务接口【ITask】</summary>
    public interface ITask
    {
        /// <summary>接口【ITask】任务名称</summary>
        string Name { get; set; }
        /// <summary>接口【ITask】任务序号</summary>
        int Idx { get; set; }
        /// <summary>接口【ITask】任务信息</summary>
        string Info { get; set; }
        /// <summary>接口【ITask】任务循环时间</summary>
        int TaskRunCycTime { get; set; }
        /// <summary>接口【ITask】任务文件夹</summary>
        string TaskFolderPath { get; set; }
        /// <summary>接口【ITask】任务当前步号</summary>
        int CurStep { get; set; }
        /// <summary>接口【ITask】任务上次步号</summary>
        int LastStep { get; set; }
        /// <summary>接口【ITask】任务使能</summary>
        bool Enable { get; set; }
        /// <summary>接口【ITask】任务Idle状态</summary>
        bool ThreadIdleState { get; set; }
        /// <summary>接口【ITask】任务ID</summary>
        Guid Id { get; set; }
        /// <summary>接口【ITask】任务已选择</summary>
        bool IsSelected { get; set; }
        /// <summary>接口【ITask】任务成员</summary>
        TaskMembers Members { get; set; }
        /// <summary>接口【ITask】配置UI</summary>
        Control TaskConfigUI { get; }
        /// <summary>接口【ITask】任务文件类型</summary>
        TaskFileType Type { get; set; }
        /// <summary>接口【ITask】DebugUI</summary>
        Control TaskDebugUI { get; }
        /// <summary>接口【ITask】未使用</summary>
        Form MembersUI { get; }

        event ProductData OnProductDataUp;
        /// <summary>接口【ITask】任务【ConfigUI】被选择事件</summary>
        event TaskSelected OnTaskSelected;

        /// <summary>接口【ITask】任务初始化</summary>
        /// <returns></returns>
        int ITaskInit();
        /// <summary>接口【ITask】任务终止</summary>
        /// <returns></returns>
        int ITaskDispose();
        /// <summary>接口【ITask】任务当前步号设置</summary>
        /// <param name="StepIndex"></param>
        void SetStep(short StepIndex);
        /// <summary>接口【ITask】任务当前步号设置</summary>
        /// <param name="StepIndex"></param>
        /// <param name="StepInfo"></param>
        void SetStep(short StepIndex, string StepInfo);
        /// <summary>接口【ITask】任务当前步号增加设置</summary>
        /// <param name="StepIndex"></param>
        /// <param name="StepInfo"></param>
        void AddStep(short StepIndex, string StepInfo);
        /// <summary>线程自定义状态设置</summary>
        /// <param name="status"></param>
        void SetDefineStatus(string status);
        /// <summary>接口【ITask】按照【名字】屏蔽元件</summary>
        /// <param name="eleName"></param>
        void DisableAbnormalDi(string eleName);
        /// <summary>接口【ITask】按照【名字】使能元件</summary>
        /// <param name="eleName"></param>
        void EnableAbnormalDi(string eleName);
        /// <summary>接口【ITask】按照【元件】屏蔽元件</summary>
        /// <param name="ele"></param>
        void DisableAbnormalDi(IEle ele);
        /// <summary>接口【ITask】按照【元件】使能元件</summary>
        /// <param name="ele"></param>
        void EnableAbnormalDi(IEle ele);
        /// <summary>接口【ITask】将DefaultTaskConfig序列化为XMLNode类型</summary>
        /// <returns></returns>
        XmlNode IEleExportConfigXml();
        /// <summary>接口【ITask】将XmlNode转化为指定类型DefaultTaskConfig</summary>
        /// <param name="xmlNode"></param>
        /// <returns></returns>
        int ITaskImportConfigXml(XmlNode xmlNode);
        /// <summary>接口【ITask】将JSON转化为指定类型TaskMembers</summary>
        /// <returns></returns>
        int ITaskImportMembersConfig();
        /// <summary>接口【ITask】按任务名称进行日志打印</summary>
        /// <param name="log">日志内容</param>
        /// <param name="lv">等级</param>
        /// <param name="id">id（默认0）</param>
        void Log(string log, LogLevel lv, int id = 0);
        /// <summary>接口【ITask】自定义名称进行日志打印</summary>
        /// <param name="name">自定义名称</param>
        /// <param name="log">日志内容</param>
        /// <param name="lv">等级</param>
        /// <param name="type">日志归属UI</param>
        /// <param name="id">id（默认0）</param>
        void LogType(string name, string log, LogLevel lv, LogType type, int id = 0);
        void Push(string info, bool stateFlag = false);
        /// <summary>接口【ITask】任务终止时抛出异常</summary>
        /// <param name="msg"></param>
        void ThrowException(string msg = null);
        /// <summary>接口【ITask】清除事件OnProductDataUp所有订阅</summary>
        void UpdataClr();
        /// <summary>接口【ITask】事件OnProductDataUp触发</summary>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        void UpdateProductData(int id, object msg);
    }
}
