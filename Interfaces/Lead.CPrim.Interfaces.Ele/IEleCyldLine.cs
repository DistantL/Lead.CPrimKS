using Lead.CPrim.Interfaces.StateMachine;
using Lead.CPrim.MachineHelper;

namespace Lead.CPrim.Interfaces
{
    /// <summary>吹气后委托</summary>
    public delegate void BlowAfterTimeEventHandler();
    /// <summary>报警委托</summary>
    /// <param name="send">报警附属日志</param>
    /// <param name="context">The context.</param>
    public delegate void AlarmMsgRevedEventHandler(string send, object context);

    /// <summary>气缸状态</summary>
    public enum EleCyldState
    {
        /// <summary>伸位</summary>
        Stretch = 1,
        /// <summary>原位</summary>
        Restretch = 2,
        /// <summary>Other</summary>
        Other = 100
    }

    /// <summary>气缸_真空元件类型</summary>
    public enum EleCyldType
    {
        /// <summary>气缸</summary>
        Cylinder = 1,
        /// <summary>真空</summary>
        Vacuum = 2,
        /// <summary>Other</summary>
        Other = 100
    }

    /// <summary>气缸_真空元件用户接口</summary>
    public interface IEleCyldLine
    {
        /// <summary>true：动作结束；false：动作中</summary>
        bool ActionComplete { set; get; }
        /// <summary>
        ///     Gets or sets a value indicating whether [automatic motion].
        /// </summary>
        /// <value><c>true</c> if [automatic motion]; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool AutoMotion { set; get; }
        /// <summary>吹气时间</summary>
        int BlowTime { set; get; }
        /// <summary>气缸_真空元件类型</summary>
        EleCyldType CyldType { set; get; }
        /// <summary>气缸状态</summary>
        /// <value>伸位/原位/Other</value>
        EleCyldState EleCyldState { set; get; }
        /// <summary>原位DI值</summary>
        bool RestractDi_On { set; get; }
        /// <summary>原位DI地址</summary>
        double RestractDiAddress { set; get; }
        /// <summary>原位DI是否启用</summary>
        bool RestractDiEnable { set; get; }
        /// <summary>原位DO值</summary>
        bool RestractDo_On { set; get; }
        /// <summary>原位DO地址</summary>
        double RestractDoAddress { set; get; }
        /// <summary>原位DO是否启用</summary>
        bool RestractDoEnable { set; get; }
        /// <summary>原位到位延时</summary>
        int RestractTimeOut { set; get; }
        /// <summary>伸位DI值</summary>
        bool StretchDi_On { set; get; }
        /// <summary>伸位DI地址</summary>
        double StretchDiAddress { set; get; }
        /// <summary>伸位DI是否启用</summary>
        bool StretchDiEnable { set; get; }
        /// <summary>伸位DO值</summary>
        bool StretchDo_On { set; get; }
        /// <summary>伸位DO地址</summary>
        double StretchDoAddress { set; get; }
        /// <summary>伸位DO是否启用</summary>
        bool StretchDoEnable { set; get; }
        /// <summary>伸位到位延时</summary>
        int StretchTimeOut { set; get; }
        string LineMark { get; set; }

        /// <summary>检测气缸或真空状态</summary>
        /// <param name="stretchDiOn">伸位Di状态</param>
        /// <param name="restractDiOn">缩位Di状态</param>
        /// <param name="stretchDoOn">伸动作Do状态</param>
        /// <param name="restractDoOn">缩动作Do状态</param>
        /// <returns>0-原位，1-伸位，2-未知状态</returns>
        int CheckCylState(out bool stretchDiOn, out bool restractDiOn, out bool stretchDoOn, out bool restractDoOn);
        /// <summary>检测气缸或真空状态</summary>
        /// <returns>0-原位，1-伸位，2-原位报错，3-伸位报错，4-未知未知</returns>
        int CheckCylState();
        /// <summary>检测气缸或真空状态（功能 = CheckCylState）</summary>
        /// <returns></returns>
        int CheckStatus();
        /// <summary>气缸原位手动操作（默认检查限位）</summary>
        /// <returns>0：成功；非0：失败</returns>
        int CyldRetract();
        /// <summary>气缸原位手动操作</summary>
        /// <param name="isCheck">true：检查限位；false：不检查限位</param>
        /// <returns>0：成功；非0：失败</returns>
        int CyldRetract(bool isCheck);
        /// <summary>气缸原位自动操作（ITask）</summary>
        /// <param name="isCheck">true：检查限位；false：不检查限位</param>
        /// <param name="asyncMode">true：异步；false：同步</param>
        /// <param name="task">ITask</param>
        /// <param name="eleAlarmLevel">报警等级</param>
        /// <param name="cyldLog">报警附属日志</param>
        /// <returns>0：成功；非0：失败</returns>
        int CyldRetract(bool isCheck, bool asyncMode, ITask task = null, EleAlarmLevel eleAlarmLevel = EleAlarmLevel.Warn, string cyldLog = "");
        /// <summary>气缸原位自动操作（StationTask）</summary>
        /// <param name="isCheck">true：检查限位；false：不检查限位</param>
        /// <param name="asyncMode">true：异步；false：同步</param>
        /// <param name="task">StationTask</param>
        /// <param name="eleAlarmLevel">报警等级</param>
        /// <param name="cyldLog">报警附属日志</param>
        /// <returns>0：成功；非0：失败</returns>
        int CyldRetract(bool isCheck, bool asyncMode, StationTask task, EleAlarmLevel eleAlarmLevel = EleAlarmLevel.Warn, string cyldLog = "");
        /// <summary>气缸伸位手动操作（默认检查限位）</summary>
        /// <returns>0：成功；非0：失败</returns>
        int CyldStretch();
        /// <summary>气缸伸位手动操作</summary>
        /// <param name="isCheck">true：检查限位；false：不检查限位</param>
        /// <returns>0：成功；非0：失败</returns>
        int CyldStretch(bool isCheck);
        /// <summary></summary>
        /// <param name="isCheck">true：检查限位；false：不检查限位</param>
        /// <param name="asyncMode">true：异步；false：同步</param>
        /// <param name="task">ITask</param>
        /// <param name="eleAlarmLevel">报警等级</param>
        /// <param name="cyldLog">报警附属日志</param>
        /// <returns>0：成功；非0：失败</returns>
        int CyldStretch(bool isCheck, bool asyncMode, ITask task = null, EleAlarmLevel eleAlarmLevel = EleAlarmLevel.Warn, string cyldLog = "");
        /// <summary></summary>
        /// <param name="isCheck">true：检查限位；false：不检查限位</param>
        /// <param name="asyncMode">true：异步；false：同步</param>
        /// <param name="task">StationTask</param>
        /// <param name="eleAlarmLevel">报警等级</param>
        /// <param name="cyldLog">报警附属日志</param>
        /// <returns>0：成功；非0：失败</returns>
        int CyldStretch(bool isCheck, bool asyncMode, StationTask task, EleAlarmLevel eleAlarmLevel = EleAlarmLevel.Warn, string cyldLog = "");
        /// <summary>原位DI读取</summary>
        /// <returns>0：成功；非0：失败</returns>
        int ReadRestractDI();
        /// <summary>原位DO读取</summary>
        /// <returns>0：成功；非0：失败</returns>
        int ReadRestractDO();
        /// <summary>伸位DI读取</summary>
        /// <returns>0：成功；非0：失败</returns>
        int ReadStretchDI();
        /// <summary>伸位DO读取</summary>
        /// <returns>0：成功；非0：失败</returns>
        int ReadStretchDO();
        /// <summary>气缸手动操作</summary>
        /// <returns>0：成功；非0：失败</returns>
        int Toggle();
        /// <summary>原位DO控制</summary>
        /// <returns>0：成功；非0：失败</returns>
        int WriteRestractDO(bool on_off);
        /// <summary>伸位DO控制</summary>
        /// <returns>0：成功；非0：失败</returns>
        int WriteStretchDO(bool on_off);
    }
}