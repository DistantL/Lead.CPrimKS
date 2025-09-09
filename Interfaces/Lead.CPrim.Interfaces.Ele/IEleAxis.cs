using System.Windows.Forms;
using Lead.CPrim.Interfaces.StateMachine;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lead.CPrim.Interfaces.Ele
{
    #region Define_Del
    /// <summary>基元类型切换委托</summary>
    /// <param name="updatedAxis">轴接口【IEleAxis】对接用户</param>
    public delegate void DelUpdateAxisByType(IEleAxis updatedAxis); 
    #endregion


    /// <summary>轴接口【IEleAxis】对接用户</summary>
    [JsonObject(MemberSerialization.OptOut)]
    public interface IEleAxis
    {
        /// <summary>接口【IEleAxis】轴Id</summary>
        string Gid { set; get; }
        /// <summary>接口【IEleAxis】轴组名称</summary>
        [JsonIgnore] string CartesianName { set; get; }
        /// <summary>接口【IEleAxis】轴手动状态</summary>
        bool ManualEnable { set; get; }
        /// <summary>接口【IEleAxis】轴元件配置_轴组_配置UI</summary>
        [JsonIgnore] Control ConfigUi { set; get; }
        /// <summary>接口【IEleAxis】轴元件配置_轴组_状态UI</summary>
        [JsonIgnore] Control StatusUi { set; get; }
        /// <summary>接口【IEleAxis】轴元件调试_轴组_手动调试UI</summary>
        [JsonIgnore] Control ManualUi { set; get; }
        /// <summary>接口【IEleAxis】轴UI被选择</summary>
        [JsonIgnore] bool IsSelected { set; get; }
        /// <summary>接口【IEleAxis】轴目标位置</summary>
        [JsonIgnore] double TargetPos { get; }
        /// <summary>接口【IEleAxis】轴错误位置</summary>
        [JsonIgnore] double ErrPos { set; get; }
        /// <summary>接口【IEleAxis】轴Unit/mm</summary>
        [JsonIgnore] double GearRatio { get; }



        #region 元件配置_轴组_配置UI
        /// <summary>接口【IEleAxis】基元类型切换时发生</summary>
        event DelUpdateAxisByType OnAxisByTypeUpdated;

        /// <summary>接口【IEleAxis】轴起始速度</summary>
        double DefaultStartVel { set; get; }
        /// <summary>接口【IEleAxis】轴最大速度</summary>
        double DefaultMaxVel { set; get; }
        /// <summary>接口【IEleAxis】轴停止速度</summary>
        double DefaultStopVel { set; get; }
        /// <summary>接口【IEleAxis】轴加速时间</summary>
        double DefaultAccTime { set; get; }
        /// <summary>接口【IEleAxis】轴减速时间</summary>
        double DefaultDecTime { set; get; }
        /// <summary>接口【IEleAxis】轴加速度</summary>
        double DefaultAcc { set; get; }
        /// <summary>接口【IEleAxis】轴减速度</summary>
        double DefaultDec { set; get; }
        /// <summary>接口【IEleAxis】轴偏差检测使能</summary>
        bool ErrChkEnable { set; get; }
        /// <summary>接口【IEleAxis】轴偏差检测值</summary>
        double ErrChkRange { set; get; }
        /// <summary>接口【IEleAxis】轴回零模式</summary>
        int HomeMode { set; get; }
        /// <summary>接口【IEleAxis】轴回零加减速</summary>
        double HomeAcc { set; get; }
        /// <summary>接口【IEleAxis】轴回零高速</summary>
        double HomeVel { set; get; }
        /// <summary>接口【IEleAxis】轴回零低速</summary>
        double HomeVo { set; get; }
        /// <summary>接口【IEleAxis】轴回零顺序</summary>
        int HomeIndex { set; get; }
        /// <summary>接口【IEleAxis】轴回零后安全位</summary>
        double SafePos { set; get; }
        /// <summary>接口【IEleAxis】轴回安全位顺序</summary>
        int WaitIndex { set; get; }
        /// <summary>接口【IEleAxis】轴是否启用</summary>
        bool Enable { set; get; }
        /// <summary>接口【IEleAxis】轴模拟</summary>
        bool Simulate { set; get; }



        /// <summary>接口【IEleAxis】轴名称</summary>
        string Name { set; get; }
        /// <summary>接口【IEleAxis】轴控制类型（控制卡/机械手/PLC）</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        ByType DeviceType { set; get; }
        /// <summary>接口【IEleAxis】轴对应基元名称</summary>
        string DevName { set; get; }
        /// <summary>接口【IEleAxis】轴Id</summary>
        int Id { set; get; }
        /// <summary>接口【IEleAxis】轴速度模式/时间模式</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        AccDecType VelMode { set; get; }
        /// <summary>接口【IEleAxis】轴驱动类型（伺服/步进）</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        AxisType DriveType { set; get; }
        /// <summary>接口【IEleAxis】轴控制模式（开环模式/闭环模式）</summary>

        [JsonConverter(typeof(StringEnumConverter))]
        ControlType ControlType { set; get; }
        /// <summary>接口【IEleAxis】轴反馈类型（增量式/绝对式）</summary>

        [JsonConverter(typeof(StringEnumConverter))]
        FeedBackType FeedBackType { set; get; }
        /// <summary>接口【IEleAxis】轴导程</summary>
        double Lead { set; get; }
        /// <summary>接口【IEleAxis】轴每转脉冲数</summary>
        double PlsPerRoll { set; get; }
        /// <summary>接口【IEleAxis】轴正向速度限定</summary>
        double LimitVelP { set; get; }
        /// <summary>接口【IEleAxis】轴负向速度限定</summary>
        double LimitVelN { set; get; }
        /// <summary>接口【IEleAxis】轴正向位置限定</summary>
        double LimitPosP { set; get; }
        /// <summary>接口【IEleAxis】轴负向位置限定</summary>
        double LimitPosN { set; get; }
        #endregion



        #region 元件配置_轴组_状态
        /// <summary>接口【IEleAxis】轴加速</summary>
        double JogAcc { set; get; }
        /// <summary>接口【IEleAxis】轴减速</summary>
        double JogDec { set; get; }
        /// <summary>接口【IEleAxis】轴速度</summary>
        double JogVel { set; get; }
        /// <summary>接口【IEleAxis】轴指令位置</summary>
        [JsonIgnore] 
        double CmdPos { get; }
        /// <summary>接口【IEleAxis】轴指令速度</summary>
        [JsonIgnore] 
        double CmdVel { get; }
        /// <summary>接口【IEleAxis】轴编码器位置</summary>
        [JsonIgnore] 
        double ActualPos { get; }
        /// <summary>接口【IEleAxis】轴编码器速度</summary>
        [JsonIgnore] 
        double ActualVel { get; }
        /// <summary>接口【IEleAxis】轴使能状态判断</summary>
        [JsonIgnore] bool IsServoOn { get; }
        /// <summary>接口【IEleAxis】轴报警状态判断</summary>
        [JsonIgnore] bool IsAlarm { get; }
        /// <summary>接口【IEleAxis】轴INP信号判断</summary>
        [JsonIgnore] bool SignalInp { get; }
        /// <summary>接口【IEleAxis】轴停止状态判断</summary>
        [JsonIgnore] bool IsStop { get; }
        /// <summary>接口【IEleAxis】轴急停信号判断</summary>
        [JsonIgnore] bool SignalEmg { get; }
        /// <summary>接口【IEleAxis】轴负硬限位判断</summary>
        [JsonIgnore] bool InMel { get; }
        /// <summary>接口【IEleAxis】轴负软限位判断</summary>
        [JsonIgnore] bool InSMel { set; get; }
        /// <summary>接口【IEleAxis】轴原点信号判断</summary>
        [JsonIgnore] bool InOrigin { get; }
        /// <summary>接口【IEleAxis】轴正软限位判断</summary>
        [JsonIgnore] bool InSPel { set; get; }
        /// <summary>接口【IEleAxis】轴正硬限位判断</summary>
        [JsonIgnore] bool InPel { get; }
        [JsonIgnore] bool SInp { get; }
        #endregion



        #region 回原点相关
        /// <summary>接口【IEleAxis】轴回原点</summary>
        /// <param name="task">任务</param>
        /// <param name="timeoutS">超时时间</param>
        /// <param name="eleLevel">报警级别（默认Err）</param>
        /// <returns>int</returns>
        int Home(ITask task, int timeoutS = -1, EleAlarmLevel eleLevel = EleAlarmLevel.Err);
        #endregion



        #region 运动相关
        /// <summary>接口【IEleAxis】轴绝对移动（指定速度）</summary>
        /// <param name="task">任务</param>
        /// <param name="pos">位置</param>
        /// <param name="vel">速度</param>
        /// <param name="ratio">速率</param>
        /// <param name="timeoutS">超时时间</param>
        /// <param name="asyncMode">true：异步；false：同步</param>
        /// <param name="checkLimit">true：检查极限；false：不检查极限</param>
        /// <param name="flag">标志位（默认1）（1：如果没到到位，可以以1/2速率再走一次；2：如果没到位，直接报错）</param>
        /// <param name="eleLevel">报警等级（默认Err）</param>
        /// <param name="checkPosDelay">运动指令后延迟</param>
        /// <returns>0：OK；非0：报错代码</returns>
        int MoveAbs(ITask task, double pos, double vel, ushort ratio = 100, int timeoutS = -1, bool asyncMode = false, bool checkLimit = true, int flag = 1, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        /// <summary>接口【IEleAxis】轴绝对移动（轴最大速度）</summary>
        /// <param name="task">任务</param>
        /// <param name="pos">位置</param>
        /// <param name="ratio">速率</param>
        /// <param name="timeoutS">超时时间</param>
        /// <param name="asyncMode">true：异步；false：同步</param>
        /// <param name="checkLimit">true：检查极限；false：不检查极限</param>
        /// <param name="flag">标志位（默认1）（1：如果没到到位，可以以1/2速率再走一次；2：如果没到位，直接报错）</param>
        /// <param name="eleLevel">报警等级（默认Err）</param>
        /// <param name="checkPosDelay">运动指令后延迟</param>
        /// <returns>0：OK；非0：报错代码</returns>
        int MoveAbs(ITask task, double pos, ushort ratio = 100, int timeoutS = -1, bool asyncMode = false, bool checkLimit = true, int flag = 1, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        /// <summary>接口【IEleAxis】轴相对移动（指定速度）</summary>
        /// <param name="task">任务</param>
        /// <param name="step">距离</param>
        /// <param name="vel">速度</param>
        /// <param name="ratio">速率</param>
        /// <param name="timeoutS">超时时间</param>
        /// <param name="asyncMode">true：异步；false：同步</param>
        /// <param name="checkLimit">true：检查极限；false：不检查极限</param>
        /// <param name="eleLevel">报错等级（默认Err）</param>
        /// <param name="checkPosDelay">运动指令后延迟</param>
        /// <returns>0：OK；非0：报错代码</returns>
        int MoveRel(ITask task, double step, double vel, ushort ratio = 100, int timeoutS = -1, bool asyncMode = false, bool checkLimit = true, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        /// <summary>接口【IEleAxis】轴相对移动（轴最大速度）</summary>
        /// <param name="task">任务</param>
        /// <param name="step">距离</param>
        /// <param name="ratio">速率</param>
        /// <param name="timeoutS">超时时间</param>
        /// <param name="asyncMode">true：异步；false：同步</param>
        /// <param name="checkLimit">true：检查极限；false：不检查极限</param>
        /// <param name="eleLevel">报错等级（默认Err）</param>
        /// <param name="checkPosDelay">运动指令后延迟</param>
        /// <returns>0：OK；非0：报错代码</returns>
        int MoveRel(ITask task, double step, ushort ratio = 100, int timeoutS = -1, bool asyncMode = false, bool checkLimit = true, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100);
        /// <summary>接口【IEleAxis】轴速度模式（指定速度）</summary>
        /// <param name="task">任务</param>
        /// <param name="vel">速度</param>
        /// <param name="ratio">速率</param>
        /// <param name="eleLevel">报错等级（默认Err）</param>
        /// <returns>0：OK；非0：报错代码</returns>
        int MoveVel(ITask task, double vel, ushort ratio = 100, EleAlarmLevel eleLevel = EleAlarmLevel.Err);
        /// <summary>接口【IEleAxis】轴速度模式（轴最大速度）</summary>
        /// <param name="task">任务</param>
        /// <param name="ratio">速率</param>
        /// <param name="eleLevel">报错等级（默认Err）</param>
        /// <returns>0：OK；非0：报错代码</returns>
        int MoveVel(ITask task, ushort ratio = 100, EleAlarmLevel eleLevel = EleAlarmLevel.Err);
        /// <summary>接口【IEleAxis】轴停止运动</summary>
        /// <returns>int</returns>
        int StopMove();
        #endregion



        #region 参数相关
        /// <summary>接口【IEleAxis】加减速设置（自定义加减速）</summary>
        /// <param name="acc">加速时间</param>
        /// <param name="dec">减速时间</param>
        /// <returns>int</returns>
        int SetAccDec(double acc, double dec);
        /// <summary>接口【IEleAxis】加减速设置（系统设置加减速，时间模式不乘以速率；加减速模式乘以速率）</summary>
        /// <param name="ratio">速率</param>
        /// <returns>int</returns>
        int SetDefaultAccDec(ushort ratio = 100);
        /// <summary>接口【IEleAxis】轴设置起始速度/最大速度/停止速度/加速时间/减速时间（系统配置/自定义速率）</summary>
        /// <param name="ratio">速率</param>
        /// <returns>int</returns>
        int SetDefaultVel(ushort ratio = 100);
        /// <summary>接口【IEleAxis】轴设置起始速度/最大速度/停止速度/加速时间/减速时间（自定义配置）</summary>
        /// <param name="startVel">起始速度</param>
        /// <param name="maxVel">最大速度</param>
        /// <param name="endVel">停止速度</param>
        /// <param name="acc">加速时间</param>
        /// <param name="dec">减速时间</param>
        /// <returns>int</returns>
        int SetVel(double startVel, double maxVel, double endVel, double acc, double dec);
        /// <summary>接口【IEleAxis】轴设置起始速度/最大速度/停止速度</summary>
        /// <param name="startVel">起始速度</param>
        /// <param name="maxVel">最大速度</param>
        /// <param name="endVel">停止速度</param>
        /// <returns>int</returns>
        int SetVel(double startVel, double maxVel, double endVel);
        /// <summary>接口【IEleAxis】轴手动速度由状态UI更新至手动调试UI</summary>
        void UpdateJogVel();
        /// <summary>接口【IEleAxis】轴当前运动速度在线更新</summary>
        /// <param name="newVel">速度</param>
        /// <returns>int</returns>
        int ChangeVel(double newVel);
        #endregion



        #region 位置相关
        /// <summary>接口【IEleAxis】轴位置判定（使用系统设定偏差检测）</summary>
        /// <param name="pos">位置</param>
        /// <returns>bool</returns>
        bool InLocation(double pos);
        /// <summary>接口【IEleAxis】轴位置判定（指定误差）</summary>
        /// <param name="pos">位置</param>
        /// <param name="errChk">误差</param>
        /// <returns>bool</returns>
        bool InLocation(double pos, double errChk);
        /// <summary>接口【IEleAxis】 轴指令位置设置为编码器位置</summary>
        /// <returns>int</returns>
        int SetFeedbackToPostion();
        /// <summary>接口【IEleAxis】 轴指令位置/编码器位置设置</summary>
        /// <param name="pos">位置</param>
        /// <returns>int</returns>
        int SetPosition(double pos);
        #endregion



        #region Others
        /// <summary>接口【IEleAxis】轴报警清除</summary>
        /// <returns>int</returns>
        int ResetAlarm();
        /// <summary>接口【IEleAxis】轴使能设置</summary>
        /// <param name="task">任务</param>
        /// <param name="status">使能</param>
        /// <param name="eleLevel">报警等级（默认Err）</param>
        /// <returns>int</returns>
        int ServoEnable(ITask task, bool status, EleAlarmLevel eleLevel = EleAlarmLevel.Err);
        /// <summary>接口【IEleAxis】基元类型切换</summary>
        /// <param name="newType">基元类型</param>
        void UpdateAxisByType(ByType newType);
        /// <summary>接口【IEleAxis】轴名称更新</summary>
        /// <param name="newName">名称</param>
        void UpdateAxisName(string newName);
        /// <summary>接口【IEleAxis】轴组名称更新</summary>
        /// <param name="name">名称</param>
        void UpdateCartesianName(string name);
        /// <summary>接口【IEleAxis】轴控制基元寻找</summary>
        /// <returns>int</returns>
        int FindPrim();
        /// <summary>接口【IEleAxis】轴手动状态检查</summary>
        /// <returns></returns>
        bool CheckManualEnable();
        //// <summary>接口【IEleAxis】轴运行状态获取</summary>
        /// <returns></returns>
        PrimRunState CheckPrimRunState(); 
        #endregion
    }
}