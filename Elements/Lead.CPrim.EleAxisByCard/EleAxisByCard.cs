/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2022.
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明
 *
 * 3.3.33.0617 -> 
 * 1、SetDefaultAccDec方法使用前增加轴是否处于停止状态判断
 * 2、SetPosition方法使用前增加轴是否处于停止状态判断
******************************************************************************/


using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.Interfaces.StateMachine;
using Lead.CPrim.MachineHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Lead.CPrim.EleAxisByCard
{
    /// <summary>单轴管理器</summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class EleAxisByCard : IEleAxis
    {
        #region Field
        /// <summary>轴UI被选择</summary>
        private bool _isSelected;
        /// <summary>轴手动状态</summary>
        private bool _manualEnable = false;
        /// <summary>
        /// True：急停减速度已写入;<br/>
        /// False：急停减速度未写入；
        /// </summary>
        bool _setStopDec = false;
        #endregion



        #region Prop
        /// <summary>单轴用户接口</summary>
        [JsonIgnore] public IAxis MotionCard { get; set; }
        [JsonIgnore] public bool SInp => MotionCard != null && MotionCard.AxisSignalOp(Id);
        #endregion



        #region Ctor
        public EleAxisByCard()
        {
            Gid = Guid.NewGuid().ToString();
            MotionCard = null;
            Enable = true;
            Simulate = false;
            Name = "AxisX";
            DeviceType = ByType.MotionCard;
            DevName = "";
            Id = 0;
            DriveType = AxisType.Other;
            ControlType = ControlType.Other;
            FeedBackType = FeedBackType.Other;
            VelMode = AccDecType.Velocity;
            Lead = 1.0;
            PlsPerRoll = 1.0;
            HomeIndex = 1;
            SafePos = 0.0;
            WaitIndex = 0;
            LimitVelP = 10000.0;
            LimitVelN = -10000.0;
            LimitPosP = 10000.0;
            LimitPosN = -10000.0;
            DefaultAcc = 1000;
            DefaultDec = 1000;
            DefaultStartVel = 0;
            DefaultMaxVel = 10;
            DefaultStopVel = 0;
            DefaultAccTime = 0.1;
            DefaultDecTime = 0.1;
            HomeMode = 0;
            HomeAcc = 0;
            HomeVel = 10;
            HomeVo = 5;
            ErrChkRange = 0;
            ErrChkEnable = true;
            JogAcc = 100.0;
            JogDec = 100.0;
            JogVel = 1;
            ErrPos = -1;
            InSPel = false;
            InSMel = false;
            IsSelected = false;
            ConfigUi = new SingleAxisConfigControl(this);
            StatusUi = new SingleAxisStatusControl(this);
            ManualUi = new SingleAxisManualControl(this);
        }
        public EleAxisByCard(string name, int id)
        {
            Gid = Guid.NewGuid().ToString();
            MotionCard = null;
            Enable = true;
            Simulate = false;
            Name = name;
            DeviceType = ByType.MotionCard;
            DevName = "";
            Id = id;
            DriveType = AxisType.Servo;
            ControlType = ControlType.OpendLoop;
            FeedBackType = FeedBackType.Incremental;
            VelMode = AccDecType.Velocity;
            Lead = 1.0;
            PlsPerRoll = 1.0;
            HomeIndex = 1;
            SafePos = 0.0;
            WaitIndex = 0;
            LimitVelP = 10000.0;
            LimitVelN = -10000.0;
            LimitPosP = 10000.0;
            LimitPosN = -10000.0;
            DefaultAcc = 1000;
            DefaultDec = 1000;
            DefaultStartVel = 0;
            DefaultMaxVel = 10;
            DefaultStopVel = 0;
            DefaultAccTime = 0.1;
            DefaultDecTime = 0.1;
            HomeMode = 0;
            HomeAcc = 0;
            HomeVel = 10;
            HomeVo = 5;
            ErrChkEnable = true;
            ErrChkRange = 0;
            JogAcc = 100.0;
            JogDec = 100.0;
            JogVel = 1;
            ErrPos = -1;
            InSPel = false;
            InSMel = false;
            IsSelected = false;
            ConfigUi = new SingleAxisConfigControl(this);
            StatusUi = new SingleAxisStatusControl(this);
            ManualUi = new SingleAxisManualControl(this);
        }
        public EleAxisByCard(string name, int id, AccDecType velMode)
        {
            Gid = Guid.NewGuid().ToString();
            MotionCard = null;
            Enable = true;
            Simulate = false;
            Name = name;
            DeviceType = ByType.MotionCard;
            DevName = "";
            Id = id;
            DriveType = AxisType.Servo;
            ControlType = ControlType.OpendLoop;
            FeedBackType = FeedBackType.Incremental;
            VelMode = velMode;
            Lead = 1.0;
            PlsPerRoll = 1.0;
            HomeIndex = 1;
            SafePos = 0.0;
            WaitIndex = 0;
            LimitVelP = 10000.0;
            LimitVelN = -10000.0;
            LimitPosP = 10000.0;
            LimitPosN = -10000.0;
            DefaultAcc = 500;
            DefaultDec = 500;
            DefaultStartVel = 0;
            DefaultMaxVel = 10;
            DefaultStopVel = 0;
            DefaultAccTime = 0.2;
            DefaultDecTime = 0.2;
            HomeMode = 0;

            HomeVel = 10;
            HomeVo = 5;
            ErrChkEnable = true;
            ErrChkRange = 0;

            JogVel = 5;
            ErrPos = 10;
            if (velMode == AccDecType.Time)
            {
                HomeAcc = 0.1;
                JogAcc = 0.2;
                JogDec = 0.2;
            }
            else
            {
                HomeAcc = 1000;
                JogAcc = 100.0;
                JogDec = 100.0;
            }
            InSPel = false;
            InSMel = false;
            IsSelected = false;
            ConfigUi = new SingleAxisConfigControl(this);
            StatusUi = new SingleAxisStatusControl(this);
            ManualUi = new SingleAxisManualControl(this);
        }
        #endregion



        #region Override IEleAxis
        public string Gid { get; set; }
        public string CartesianName { get; set; }
        public bool ManualEnable
        {
            get
            {
                return _manualEnable;
            }
            set
            {
                if (_manualEnable == value)
                {
                    return;
                }
                _manualEnable = value;
                ((SingleAxisStatusControl)StatusUi)?.SetManualEnable(value);
                ((SingleAxisConfigControl)ConfigUi)?.SetManualEnable(value);
                ((SingleAxisManualControl)ManualUi)?.SetManualEnable(value);
            }
        }
        [JsonIgnore] public Control ConfigUi { get; set; }
        [JsonIgnore] public Control StatusUi { get; set; }
        [JsonIgnore] public Control ManualUi { set; get; }
        [JsonIgnore]
        public bool IsSelected
        {
            set
            {
                if (value == _isSelected)
                {
                    return;
                }

                _isSelected = value;
                ((SingleAxisConfigControl)ConfigUi)?.Selected();
                ((SingleAxisStatusControl)StatusUi)?.Selected();
            }
            get => _isSelected;
        }
        [JsonIgnore]
        public double TargetPos
        {
            get
            {
                if (MotionCard == null)
                {
                    return 0;
                }
                var targetPosPulse = -1.0;
                MotionCard.GetAxisTargetPosition(Id, ref targetPosPulse);
                return targetPosPulse / GearRatio;
            }
        }
        [JsonIgnore] public double ErrPos { set; get; }
        [JsonIgnore] public double GearRatio => PlsPerRoll / Lead;

        public event DelUpdateAxisByType OnAxisByTypeUpdated;

        public double DefaultStartVel { set; get; }
        public double DefaultMaxVel { set; get; }
        public double DefaultStopVel { set; get; }
        public double DefaultAccTime { set; get; }
        public double DefaultDecTime { set; get; }
        public double DefaultAcc { set; get; }
        public double DefaultDec { set; get; }
        public bool ErrChkEnable { set; get; }
        public double ErrChkRange { set; get; }
        public int HomeMode { set; get; }
        public double HomeAcc { set; get; }
        public double HomeVel { set; get; }
        public double HomeVo { set; get; }
        public int HomeIndex { set; get; }
        public double SafePos { set; get; }
        public int WaitIndex { set; get; }
        public bool Enable { set; get; }
        public bool Simulate { set; get; }

        public string Name { set; get; }
        [JsonConverter(typeof(StringEnumConverter))] public ByType DeviceType { set; get; }
        public string DevName { set; get; }
        public int Id { set; get; }
        [JsonConverter(typeof(StringEnumConverter))] public AccDecType VelMode { set; get; }
        [JsonConverter(typeof(StringEnumConverter))] public AxisType DriveType { set; get; }
        [JsonConverter(typeof(StringEnumConverter))] public ControlType ControlType { set; get; }
        [JsonConverter(typeof(StringEnumConverter))] public FeedBackType FeedBackType { set; get; }
        public double Lead { set; get; }
        public double PlsPerRoll { set; get; }
        public double LimitVelP { set; get; }
        public double LimitVelN { set; get; }
        public double LimitPosP { set; get; }
        public double LimitPosN { set; get; }
        public double JogAcc { set; get; }
        public double JogDec { set; get; }
        public double JogVel { set; get; }
        [JsonIgnore]
        public double CmdPos
        {
            get
            {
                if (MotionCard == null || ((IPrim)MotionCard).PrimRunStat != PrimRunState.Running)
                {
                    return 0;
                }

                var cmdPosPulse = -1.0;
                MotionCard.GetAxisCommand(Id, ref cmdPosPulse);
                return Math.Round(cmdPosPulse / GearRatio, 3);
            }
        }
        [JsonIgnore]
        public double CmdVel
        {
            get
            {
                if (MotionCard == null || ((IPrim)MotionCard).PrimRunStat != PrimRunState.Running)
                {
                    return 0;
                }

                var cmdVelPulse = -1.0;
                MotionCard.GetAxisCommandVelocity(Id, ref cmdVelPulse);
                return Math.Round(cmdVelPulse / GearRatio, 3);
            }
        }
        [JsonIgnore]
        public double ActualPos
        {
            get
            {
                if (MotionCard == null || ((IPrim)MotionCard).PrimRunStat != PrimRunState.Running)
                {
                    return 0;
                }

                var tempPulse = -1.0;
                if (DriveType == AxisType.Step)
                {
                    MotionCard.GetAxisCommand(Id, ref tempPulse);
                }
                else
                {
                    MotionCard.GetAxisPosition(Id, ref tempPulse);
                }

                return Math.Round(tempPulse / GearRatio, 3);
            }
        }
        [JsonIgnore]
        public double ActualVel
        {
            get
            {
                if (MotionCard == null || ((IPrim)MotionCard).PrimRunStat != PrimRunState.Running)
                {
                    return 0;
                }

                var actualVelPulse = -1.0;
                if (DriveType == AxisType.Step)
                {
                    MotionCard.GetAxisCommandVelocity(Id, ref actualVelPulse);
                }
                else
                {
                    MotionCard.GetAxisActualVelocity(Id, ref actualVelPulse);
                }

                return Math.Round(actualVelPulse / GearRatio, 3);
            }
        }
        [JsonIgnore]
        public bool IsServoOn
        {
            get
            {
                if (MotionCard == null)
                {
                    return false;
                }

                switch (DriveType)
                {
                    case AxisType.Servo:
                        return MotionCard.AxisIsEnble(Id);
                    case AxisType.Step:
                        return !MotionCard.AxisIsEnble(Id);
                    case AxisType.Other:
                    default:
                        return false;
                }
            }
        }
        [JsonIgnore] public bool IsAlarm => MotionCard != null && MotionCard.AxisIsAlarm(Id);
        [JsonIgnore] public bool SignalInp => MotionCard != null && MotionCard.AxisSignalInp(Id);
        [JsonIgnore] public bool IsStop => MotionCard != null && MotionCard.AxisIsStop(Id);
        [JsonIgnore] public bool SignalEmg => MotionCard != null && MotionCard.AxisSignalEmg(Id);
        [JsonIgnore] public bool InMel => MotionCard != null && MotionCard.AxisInMel(Id);
        [JsonIgnore] public bool InSMel { set; get; }
        [JsonIgnore] public bool InOrigin => MotionCard != null && MotionCard.AxisInOrigin(Id);
        [JsonIgnore] public bool InSPel { set; get; }
        [JsonIgnore] public bool InPel => MotionCard != null && MotionCard.AxisInPel(Id);

        public int Home(ITask task, int timeoutS = -1, EleAlarmLevel eleLevel = EleAlarmLevel.Err)
        {
            int ret = EleAxisByCardSafeCheck(task, true, true, true, true);
            if (ret != 0)
            {
                return ret;
            }

            ret = SetStopDec();
            if (ret != 0)
            {
                return ret;
            }

            ((StationTask)task)?.AbortIfCancel(null);
            ((StationTask)task)?.JoinIfPause();

            if (!IsStop)
            {
                StopMove();
                Thread.Sleep(100);
            }

            string msg = string.Empty;
            string err = $"{CartesianName} 的轴 {Name} 回零 ";
            SoftWareAlarm softWareAlarm = SoftWareAlarm.OK;
            ret = MotionCard.AxisHomeMove(Id,
                HomeMode,
                HomeVel * GearRatio,
                HomeVo * GearRatio,
                VelMode == AccDecType.Time ? HomeAcc : HomeAcc * GearRatio,
                SafePos * GearRatio,
                true);
            if (ret != 0)
            {
                msg += $"{err}：板卡控制报错：{ret}；";
                softWareAlarm = SoftWareAlarm.EleAxisByType_AxisHomeMove方法返回值不等于0;
            }
            else
            {
                int t = 0;
                timeoutS = timeoutS <= 0 ? 100 : timeoutS;
                while (t++ <= timeoutS * 1000)
                {
                    if (IsAlarm || !IsServoOn)
                    {
                        Thread.Sleep(10);
                        if (IsAlarm || !IsServoOn)
                        {
                            StopMove();
                            msg += $"{err}，轴报警: {IsAlarm} or 掉使能：{!IsServoOn} 报错；";
                            softWareAlarm = SoftWareAlarm.EleAxisByType_轴报警_使能检测未通过;
                            break;
                        }
                    }

                    if (IsStop && SignalInp)
                    {
                        Thread.Sleep(1000);
                        SetPosition(0);
                        break;
                    }

                    //task
                    if (task != null)
                    {
                        if (((StationTask)task).RunningState != SmStates.Running &&
                            ((StationTask)task).RunningState != SmStates.Resetting)
                        {
                            StopMove();
                            Thread.Sleep(50);
                            ((StationTask)task).AbortIfCancel(nameof(Home));
                        }

                        if (((StationTask)task).RunningState == SmStates.Pause ||
                            ((StationTask)task).RunningState == SmStates.WaitClrErr)
                        {
                            StopMove();
                            Thread.Sleep(50);
                            ((StationTask)task).JoinIfPause();
                            Thread.Sleep(200);
                            ((StationTask)task).AbortIfCancel(nameof(Home));
                            MotionCard.AxisHomeMove(Id,
                                HomeMode,
                                HomeVel * GearRatio,
                                HomeVo * GearRatio,
                                VelMode == AccDecType.Time ? HomeAcc : HomeAcc * GearRatio,
                                SafePos * GearRatio,
                                true);
                        }
                    }

                    Thread.Sleep(1);
                }

                //超时
                if (t > timeoutS * 1000)
                {
                    msg += $"{err} 超时；";
                    softWareAlarm = SoftWareAlarm.EleAxisByType_运动超时;
                }
            }

            {
                ret = MotionCard.AxisSetHomeMode(Id, HomeMode);
                if (ret != 0)
                {
                    msg += $"{err}后设置驱动器模式失败：{ret}；";
                    softWareAlarm = softWareAlarm == SoftWareAlarm.OK ? SoftWareAlarm.EleAxisByType_AxisHomeMove方法返回值不等于0 : softWareAlarm;
                }

                if (softWareAlarm != SoftWareAlarm.OK)
                {
                    switch (eleLevel)
                    {
                        case EleAlarmLevel.Err:
                            task?.Log(msg, LogLevel.Error);
                            task?.ThrowException(msg);
                            break;
                        case EleAlarmLevel.Warn:
                            task?.Log(msg, LogLevel.Warn);
                            break;
                        default:
                            task?.Log(msg, LogLevel.Info);
                            break;
                    }
                }
                else
                {
                    task?.Log($"{err} 成功。 ", LogLevel.Trace);
                }
            }

            return (int)softWareAlarm;
        }

        public int MoveAbs(ITask task, double pos, double vel, ushort ratio = 100, int timeoutS = -1, bool asyncMode = false, bool checkLimit = true, int flag = 1, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            int ret = EleAxisByCardSafeCheck(task, true, true, true, true);
            if (ret != 0)
            {
                return ret;
            }

            if (!IsStop)
            {
                StopMove();
            }

            ret = SetStopDec();
            if (ret != 0)
            {
                return ret;
            }

            ((StationTask)task)?.AbortIfCancel(null);
            ((StationTask)task)?.JoinIfPause();

            bool isCheckPel = false;
            bool isCheckMel = false;
            var err = $"{CartesianName} 的轴 {Name} 绝对移动至 {pos:F2} ";

            isCheckPel = pos > ActualPos ? true : false;
            isCheckMel = pos > ActualPos ? false : true;

            if (IsAlarm || !IsServoOn || (checkLimit && (((InPel || InSPel) && isCheckPel) || ((InMel || InSMel) && isCheckMel))))
            {
                StopMove();
                var msg = $"{err}，负限位：{(InMel || InSMel) && isCheckMel} or 正限位：{(InPel || InSPel) && isCheckPel} or 轴报警: {IsAlarm} or 掉使能：{!IsServoOn} 报错";
                switch (eleLevel)
                {
                    case EleAlarmLevel.Err:
                        task?.Log(msg, LogLevel.Error);
                        task?.ThrowException(msg);
                        break;
                    case EleAlarmLevel.Warn:
                        task?.Log(msg, LogLevel.Warn);
                        break;
                    default:
                        task?.Log(msg, LogLevel.Info);
                        break;
                }
                if (task == null)
                {
                    LogAdd(msg, LogLevel.Warn);
                }
                return (int)SoftWareAlarm.EleAxisByType_轴正负极限_报警_使能检测未通过;
            }

            ret = SetDefaultAccDec(ratio);
            if (ret != 0)
            {
                var msg = $"轴加减速设置出错：{ret}";
                task?.Log(msg, LogLevel.Warn, task == null ? 0 : task.Idx);
                if (task == null)
                {
                    LogAdd(msg, LogLevel.Warn);
                }
                return ret;
            }

            ret = MotionCard.AxisAbsMove(Id, pos * GearRatio, vel * GearRatio * ratio / 100);
            if (ret != 0)
            {
                var msg = $"{err}：板卡控制报错： {ret}";
                switch (eleLevel)
                {
                    case EleAlarmLevel.Err:
                        task?.Log(msg, LogLevel.Error);
                        task?.ThrowException(msg);
                        break;
                    case EleAlarmLevel.Warn:
                        task?.Log(msg, LogLevel.Warn);
                        break;
                    default:
                        task?.Log(msg, LogLevel.Info);
                        break;
                }
                if (task == null)
                {
                    LogAdd(msg, LogLevel.Warn);
                }
                return (int)SoftWareAlarm.EleAxisByType_AxisAbsMove方法返回值不等于0;
            }

            if (asyncMode)
            {
                var msg = $"{err} 异步模式运动成功。";
                task?.Log(msg, LogLevel.Trace);
                if (task == null)
                {
                    LogAdd(msg, LogLevel.Trace);
                }
                return 0;
            }

            Thread.Sleep(checkPosDelay);
            var t = 0;
            timeoutS = timeoutS <= 0 ? 100 : timeoutS;
            while (t++ <= timeoutS * 1000)
            {
                if (IsAlarm || !IsServoOn || (checkLimit && (((InPel || InSPel) && isCheckPel) || ((InMel || InSMel) && isCheckMel))))
                {
                    Thread.Sleep(10);
                    if (IsAlarm || !IsServoOn || (checkLimit && (((InPel || InSPel) && isCheckPel) || ((InMel || InSMel) && isCheckMel))))
                    {
                        StopMove();
                        var msg = $"{err}，负限位：{(InMel || InSMel) && isCheckMel} or 正限位：{(InPel || InSPel) && isCheckPel} or 轴报警: {IsAlarm} or 掉使能：{!IsServoOn} 报错";
                        switch (eleLevel)
                        {
                            case EleAlarmLevel.Err:
                                task?.Log(msg, LogLevel.Error);
                                task?.ThrowException(msg);
                                break;
                            case EleAlarmLevel.Warn:
                                task?.Log(msg, LogLevel.Warn);
                                break;
                            default:
                                task?.Log(msg, LogLevel.Info);
                                break;
                        }
                        if (task == null)
                        {
                            LogAdd(msg, LogLevel.Warn);
                        }
                        return (int)SoftWareAlarm.EleAxisByType_轴正负极限_报警_使能检测未通过;
                    }
                }

                if (IsStop && InLocation(pos))
                {
                    if (ErrChkEnable && !SpinWait.SpinUntil(() => InLocation(pos), 500))
                    {
                        var moveAgainRet = 0;
                        if (flag == 1)
                        {
                            moveAgainRet = MoveAbs(task, pos, vel, (ushort)(ratio / 2), timeoutS, asyncMode, checkLimit, 2, eleLevel, checkPosDelay);
                        }

                        if ((flag == 1 && moveAgainRet != 0) || flag == 2)
                        {
                            var msg = $"{err} 轴偏差检测报错，偏差值{(ErrChkRange / 100):F2}mm";
                            switch (eleLevel)
                            {
                                case EleAlarmLevel.Err:
                                    task?.Log(msg, LogLevel.Error);
                                    task?.ThrowException(msg);
                                    break;
                                case EleAlarmLevel.Warn:
                                    task?.Log(msg, LogLevel.Warn);
                                    break;
                                default:
                                    task?.Log(msg, LogLevel.Info);
                                    break;
                            }
                            LogAdd(msg, LogLevel.Warn);
                            return (int)SoftWareAlarm.EleAxisByType_轴偏差检测报错;
                        }

                        task?.Log($"{err} 重试成功，实时位置：{ActualPos}，目标位置：{pos}", LogLevel.Trace);
                        LogAdd($"{err} 重试成功，实时位置：{ActualPos}，目标位置：{pos}", LogLevel.Trace);
                        return 0;
                    }

                    task?.Log($"{err} 成功，实时位置：{ActualPos}，目标位置：{pos}", LogLevel.Trace);
                    LogAdd($"{err} 成功，实时位置：{ActualPos}，目标位置：{pos}", LogLevel.Trace);
                    return 0;
                }

                //task
                if (task != null)
                {
                    if (((StationTask)task).RunningState != SmStates.Running && ((StationTask)task).RunningState != SmStates.Resetting)
                    {
                        StopMove();
                        ((StationTask)task).AbortIfCancel(nameof(MoveAbs));
                    }

                    if (((StationTask)task).RunningState == SmStates.Pause || ((StationTask)task).RunningState == SmStates.WaitClrErr)
                    {
                        StopMove();
                        ((StationTask)task).JoinIfPause();
                        Thread.Sleep(200);
                        ((StationTask)task).AbortIfCancel(nameof(MoveAbs));
                        MotionCard.AxisAbsMove(Id, pos * GearRatio, vel * GearRatio * ratio / 100);
                    }
                }

                Thread.Sleep(1);
            }

            //超时
            {
                var msg = $"{err} 超时";
                switch (eleLevel)
                {
                    case EleAlarmLevel.Err:
                        task?.Log(msg, LogLevel.Error);
                        task?.ThrowException(msg);
                        break;
                    case EleAlarmLevel.Warn:
                        task?.Log(msg, LogLevel.Warn);
                        break;
                    default:
                        task?.Log(msg, LogLevel.Info);
                        break;
                }
                if (task == null)
                {
                    LogAdd(msg, LogLevel.Warn);
                }
            }
            return (int)SoftWareAlarm.EleAxisByType_运动超时;
        }
        public int MoveAbs(ITask task, double pos, ushort ratio = 100, int timeoutS = -1, bool asyncMode = false, bool checkLimit = true, int flag = 1, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            return MoveAbs(task, pos, DefaultMaxVel, ratio, timeoutS, asyncMode, checkLimit, flag, eleLevel, checkPosDelay);
        }
        public int MoveRel(ITask task, double step, double vel, ushort ratio = 100, int timeoutS = -1, bool asyncMode = false, bool checkLimit = true, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            int ret = EleAxisByCardSafeCheck(task, true, true, true, true);
            if (ret != 0)
            {
                return ret;
            }

            if (!IsStop)
            {
                StopMove();
            }
            Thread.Sleep(200);

            ret = SetStopDec();
            if (ret != 0)
            {
                return ret;
            }

            ((StationTask)task)?.AbortIfCancel(null);
            ((StationTask)task)?.JoinIfPause();

            var startPos = -1.0;
            var destPos = -1.0;
            bool isCheckPel = false;
            bool isCheckMel = false;

            var stepFlag = "";
            if (step > 0)
            {
                stepFlag = "+";
            }
            isCheckPel = step > 0 ? true : false;
            isCheckMel = step > 0 ? false : false;
            var err = $"{CartesianName} 的轴 {Name} 相对移动: {stepFlag}{step}";

            if (IsAlarm || !IsServoOn || (checkLimit && (((InPel || InSPel) && isCheckPel) || ((InMel || InSMel) && isCheckMel))))
            {
                StopMove();
                var msg = $"{err}，负限位：{(InMel || InSMel) && isCheckMel} or 正限位：{(InPel || InSPel) && isCheckPel} or 轴报警: {IsAlarm} or 掉使能：{!IsServoOn} 报错，实时位置：{ActualPos}，目标位置：{destPos}";
                switch (eleLevel)
                {
                    case EleAlarmLevel.Err:
                        task?.Log(msg, LogLevel.Error);
                        task?.ThrowException(msg);
                        break;
                    case EleAlarmLevel.Warn:
                        task?.Log(msg, LogLevel.Warn);
                        break;
                    default:
                        task?.Log(msg, LogLevel.Info);
                        break;
                }
                LogAdd(msg, LogLevel.Warn);
                return (int)SoftWareAlarm.EleAxisByType_轴正负极限_报警_使能检测未通过;
            }

            ret = SetDefaultAccDec(ratio);
            if (ret != 0)
            {
                var msg = $"{err}：轴加减速设置出错：{ret}";
                task?.Log(msg, LogLevel.Warn, task == null ? 0 : task.Idx);
                LogAdd(msg, LogLevel.Warn);
                return ret;
            }

            startPos = ActualPos;
            destPos = ActualPos + step;
            ret = MotionCard.AxisRelMove(Id, step * GearRatio, vel * GearRatio * ratio / 100);
            if (ret != 0)
            {
                var msg = $"{err}：板卡控制报错： {ret}，实时位置：{ActualPos}，目标位置：{destPos}";
                switch (eleLevel)
                {
                    case EleAlarmLevel.Err:
                        task?.Log(msg, LogLevel.Error);
                        task?.ThrowException(msg);
                        break;
                    case EleAlarmLevel.Warn:
                        task?.Log(msg, LogLevel.Warn);
                        break;
                    default:
                        task?.Log(msg, LogLevel.Info);
                        break;
                }
                LogAdd(msg, LogLevel.Warn);
                return (int)SoftWareAlarm.EleAxisByType_AxisRelMove方法返回值不等于0;
            }

            if (asyncMode)
            {
                var msg = $"{err} 异步模式运动成功。 ";
                task?.Log(msg, LogLevel.Trace);
                LogAdd(msg, LogLevel.Trace);
                return 0;
            }

            Thread.Sleep(checkPosDelay);
            var t = 0;
            timeoutS = timeoutS <= 0 ? 100 : timeoutS;

            while (t++ <= timeoutS * 1000)
            {
                //报警/使能/限位
                if (IsAlarm || !IsServoOn || (checkLimit && (((InPel || InSPel) && isCheckPel) || ((InMel || InSMel) && isCheckMel))))
                {
                    Thread.Sleep(10);
                    if (IsAlarm || !IsServoOn || (checkLimit && (((InPel || InSPel) && isCheckPel) || ((InMel || InSMel) && isCheckMel))))
                    {
                        StopMove();
                        var msg = $"{err}，负限位：{(InMel || InSMel) && isCheckMel} or 正限位：{(InPel || InSPel) && isCheckPel} or 轴报警: {IsAlarm} or 掉使能：{!IsServoOn} 报错，实时位置：{ActualPos}，目标位置：{destPos}";
                        switch (eleLevel)
                        {
                            case EleAlarmLevel.Err:
                                task?.Log(msg, LogLevel.Error);
                                task?.ThrowException(msg);
                                break;
                            case EleAlarmLevel.Warn:
                                task?.Log(msg, LogLevel.Warn);
                                break;
                            default:
                                task?.Log(msg, LogLevel.Info);
                                break;
                        }
                        LogAdd(msg, LogLevel.Warn);
                        return (int)SoftWareAlarm.EleAxisByType_轴正负极限_报警_使能检测未通过;
                    }
                }

                //到位
                if (IsStop && InLocation(destPos))
                {
                    if (ErrChkEnable && !SpinWait.SpinUntil(() => InLocation(destPos), 500))
                    {
                        var msg = $"{err} 轴偏差检测报错，实时位置：{ActualPos}，目标位置：{destPos}，偏差值{ErrChkRange / 100}mm";
                        switch (eleLevel)
                        {
                            case EleAlarmLevel.Err:
                                task?.Log(msg, LogLevel.Error);
                                task?.ThrowException(msg);
                                break;
                            case EleAlarmLevel.Warn:
                                task?.Log(msg, LogLevel.Warn);
                                break;
                            default:
                                task?.Log(msg, LogLevel.Info);
                                break;
                        }
                        LogAdd(msg, LogLevel.Warn);
                        return (int)SoftWareAlarm.EleAxisByType_轴偏差检测报错;
                    }

                    task?.Log($"{err} 成功，实时位置：{ActualPos}，目标位置：{destPos}", LogLevel.Trace);
                    return 0;
                }

                //任务
                if (task != null)
                {
                    if (((StationTask)task).RunningState != SmStates.Running &&
                        ((StationTask)task).RunningState != SmStates.Resetting)
                    {
                        StopMove();
                        ((StationTask)task).AbortIfCancel(nameof(MoveRel));
                    }

                    if (((StationTask)task).RunningState == SmStates.Pause ||
                        ((StationTask)task).RunningState == SmStates.WaitClrErr)
                    {
                        StopMove();
                        var pausePos = ActualPos;
                        ((StationTask)task).JoinIfPause();
                        Thread.Sleep(200);
                        ((StationTask)task).AbortIfCancel(nameof(MoveRel));
                        step = step - (pausePos - startPos);
                        startPos = ActualPos;
                        destPos = startPos + step;
                        MotionCard.AxisRelMove(Id, step * GearRatio, vel * GearRatio * ratio / 100);
                    }
                }

                Thread.Sleep(1);
            }

            //超时
            {
                var msg = $"{err} 超时，实时位置：{ActualPos}，目标位置：{destPos}";
                switch (eleLevel)
                {
                    case EleAlarmLevel.Err:
                        task?.Log(msg, LogLevel.Error);
                        task?.ThrowException(msg);
                        break;
                    case EleAlarmLevel.Warn:
                        task?.Log(msg, LogLevel.Warn);
                        break;
                    default:
                        task?.Log(msg, LogLevel.Info);
                        break;
                }
                LogAdd(msg, LogLevel.Warn);
            }
            return (int)SoftWareAlarm.EleAxisByType_运动超时;
        }
        public int MoveRel(ITask task, double step, ushort ratio = 100, int timeoutS = -1, bool asyncMode = false, bool checkLimit = true, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            return MoveRel(task, step, DefaultMaxVel, ratio, timeoutS, asyncMode, checkLimit, eleLevel, checkPosDelay);
        }
        public int MoveVel(ITask task, double vel, ushort ratio = 100, EleAlarmLevel eleLevel = EleAlarmLevel.Err)
        {
            int ret = EleAxisByCardSafeCheck(task, true, true, true, true);
            if (ret != 0)
            {
                return ret;
            }

            ret = SetStopDec();
            if (ret != 0)
            {
                return ret;
            }

            ((StationTask)task)?.AbortIfCancel(null);
            ((StationTask)task)?.JoinIfPause();

            bool isCheckPel = false;
            bool isCheckMel = false;
            var err = $"{CartesianName} 的轴 {Name} 速度运动: 速度 = {vel} ";
            if (vel == 0)
            {
                task?.Log(err, LogLevel.Warn);
                LogAdd(err, LogLevel.Warn);
                return (int)SoftWareAlarm.EleAxisByType_轴速度为0;
            }

            isCheckPel = vel > 0 ? true : false;
            isCheckMel = vel > 0 ? false : true;

            if (IsAlarm || !IsServoOn || ((InPel || InSPel) && isCheckPel) || ((InMel || InSMel) && isCheckMel))
            {
                StopMove();
                var msg = $"{err}，负限位：{(InMel || InSMel) && isCheckMel} or 正限位：{(InPel || InSPel) && isCheckPel} or 轴报警: {IsAlarm} or 掉使能：{!IsServoOn} 报错";
                switch (eleLevel)
                {
                    case EleAlarmLevel.Err:
                        task?.Log(msg, LogLevel.Error);
                        task?.ThrowException($"{msg}，实时位置：{ActualPos} 。");
                        break;
                    case EleAlarmLevel.Warn:
                        task?.Log(msg, LogLevel.Warn);
                        break;
                    default:
                        task?.Log(msg, LogLevel.Info);
                        break;
                }
                LogAdd(msg, LogLevel.Warn);
                return (int)SoftWareAlarm.EleAxisByType_轴正负极限_报警_使能检测未通过;
            }

            //运动前增加防呆
            if (!IsStop)
            {
                ChangeVel(Math.Abs(vel * GearRatio * ratio / 100));
                return 0;
            }

            ret = SetDefaultAccDec(ratio);
            if (ret != 0)
            {
                task?.Log($"{err}，轴加减速设置出错：{ret}", LogLevel.Warn, task == null ? 0 : task.Idx);
                LogAdd($"{err}，轴加减速设置出错：{ret}", LogLevel.Warn);
                return ret;
            }

            ret = MotionCard.AxisVelMove(Id, vel * GearRatio * ratio / 100);
            if (ret != 0)
            {
                var msg = $"{err} : 板卡控制报错：{ret} ";
                switch (eleLevel)
                {
                    case EleAlarmLevel.Err:
                        task?.Log(msg, LogLevel.Error);
                        task?.ThrowException($"{msg} 报错，实时位置：{ActualPos} 。");
                        break;
                    case EleAlarmLevel.Warn:
                        task?.Log(msg, LogLevel.Warn);
                        break;
                    default:
                        task?.Log(msg, LogLevel.Info);
                        break;
                }
                LogAdd(msg, LogLevel.Warn);
                return (int)SoftWareAlarm.EleAxisByType_AxisVelMove方法返回值不等于0;
            }

            LogAdd($"{err} 成功", LogLevel.Trace);
            task?.Log($"{err} 成功", LogLevel.Trace);
            return ret;
        }
        public int MoveVel(ITask task, ushort ratio = 100, EleAlarmLevel eleLevel = EleAlarmLevel.Err)
        {
            return MoveVel(task, DefaultMaxVel, ratio, eleLevel);
        }
        public int StopMove()
        {
            var iRet = EleAxisByCardSafeCheck(null, true, true, false, false);
            if (iRet != 0)
            {
                return iRet;
            }

            var err = $"{CartesianName} 的轴 {Name} 停止运动";
            iRet = MotionCard.AxisStopMove(Id);
            if (iRet != 0)
            {
                var msg = $"{err} : 板卡控制报错：{iRet} ";
                LogAdd(msg, LogLevel.Warn);
                return (int)SoftWareAlarm.EleAxisByType_AxisStopMove返回值不等于0;
            }

            LogAdd($"{err} 成功", LogLevel.Trace);
            return 0;
        }
        public int SetAccDec(double acc, double dec)
        {
            var err = $"{CartesianName} 的轴 {Name} 设置指定加减速，加速时间|加速度：{acc}，减速时间|减速度：{dec}";

            if (!IsStop)
            {
                LogAdd("轴运行中_不能进行加减速设置", LogLevel.Trace);
                return 0;
            }

            var iRet = new int[2];
            if (VelMode == AccDecType.Time)
            {
                iRet[0] = MotionCard.AxisSetAcc(Id, acc);
                iRet[1] = MotionCard.AxisSetDec(Id, dec);
            }
            else
            {
                iRet[0] = MotionCard.AxisSetAcc(Id, acc * GearRatio);
                iRet[1] = MotionCard.AxisSetDec(Id, dec * GearRatio);
            }

            bool result = iRet.All(p => p == 0);
            if (!result)
            {
                var msg = $"{err} : 板卡控制报错：{iRet[0]}-{iRet[1]} ";
                LogAdd(msg, LogLevel.Warn);
                return (int)SoftWareAlarm.EleAxisByType_AxisSetAcc_AxisSetDec返回值不等于0;
            }

            LogAdd($"{err} 成功", LogLevel.Trace);
            return 0;
        }
        //MoveAbs/MoveRel/MoveVel/SingleSetDefaultAccDec
        public int SetDefaultAccDec(ushort ratio = 100)
        {
            var err = $"{CartesianName} 的轴 {Name} 设置默认加减速，使用速率： {ratio}";

            if (!IsStop)
            {
                LogAdd("轴运行中_不能进行加减速设置", LogLevel.Trace);
                return 0;
            }

            var iRet = new int[2];
            if (VelMode == AccDecType.Time)
            {
                iRet[0] = MotionCard.AxisSetAcc(Id, DefaultAccTime);
                iRet[1] = MotionCard.AxisSetDec(Id, DefaultDecTime);
            }
            else
            {
                iRet[0] = MotionCard.AxisSetAcc(Id, DefaultAcc * GearRatio * ratio / 100);
                iRet[1] = MotionCard.AxisSetDec(Id, DefaultDec * GearRatio * ratio / 100);
            }

            bool result = iRet.All(p => p == 0);
            if (!result)
            {
                var msg = $"{err} : 板卡控制报错：{iRet[0]}-{iRet[1]} ";
                LogAdd(msg, LogLevel.Warn);
                return (int)SoftWareAlarm.EleAxisByType_AxisSetAcc_AxisSetDec返回值不等于0;
            }

            LogAdd($"{err} 成功", LogLevel.Trace);
            return 0;
        }
        public int SetDefaultVel(ushort ratio = 100)
        {
            var iRet = EleAxisByCardSafeCheck(null, true, true, true, true);
            if (iRet != 0)
            {
                return iRet;
            }

            var err = $"{CartesianName} 的轴 {Name} 设置系统速度及加减速";

            iRet = MotionCard.AxisSetAccDec(Id,
                    DefaultStartVel * GearRatio * ratio / 100,
                    DefaultMaxVel * GearRatio * ratio / 100,
                    VelMode == AccDecType.Time ? DefaultAccTime : DefaultAcc * GearRatio * ratio / 100,
                    VelMode == AccDecType.Time ? DefaultDecTime : DefaultDec * GearRatio * ratio / 100,
                    DefaultStopVel * GearRatio * ratio / 100);

            if (iRet != 0)
            {
                var msg = $"{err} : 板卡控制报错：{iRet} ";
                LogAdd(msg, LogLevel.Warn);
                return (int)SoftWareAlarm.EleAxisByType_AxisSetAccDec返回值不等于0;
            }

            LogAdd($"{err} 成功", LogLevel.Trace);
            return iRet;
        }
        //SingleMoveRel/SingleSetVel
        public int SetVel(double startVel, double maxVel, double endVel, double acc, double dec)
        {
            var iRet = EleAxisByCardSafeCheck(null, true, true, true, true);
            if (iRet != 0)
            {
                return iRet;
            }

            var err = $"{CartesianName} 的轴 {Name} 设置指定义速度及加减速，起始速度：{startVel}，最大速度：{maxVel}，停止速度：{endVel}，加速时间|加速度：{acc}，减速时间|减速度：{dec}";

            iRet = MotionCard.AxisSetAccDec(Id,
                startVel * GearRatio,
                maxVel * GearRatio,
                VelMode == AccDecType.Time ? acc : acc * GearRatio,
                VelMode == AccDecType.Time ? dec : dec * GearRatio,
                endVel * GearRatio);

            if (iRet != 0)
            {
                var msg = $"{err} : 板卡控制报错：{iRet} ";
                LogAdd(msg, LogLevel.Warn);
                return (int)SoftWareAlarm.EleAxisByType_AxisSetAccDec返回值不等于0;
            }

            LogAdd($"{err} 成功", LogLevel.Trace);
            return iRet;
        }
        public int SetVel(double startVel, double maxVel, double endVel)
        {
            var ret = EleAxisByCardSafeCheck(null, true, true, true, true);
            if (ret != 0)
            {
                return ret;
            }

            var err = $"{CartesianName} 的轴 {Name} 设置指定义速度及加减速，起始速度：{startVel}，最大速度：{maxVel}，停止速度：{endVel}";

            var iRet = new int[3];
            iRet[0] = MotionCard.AxisSetMinVel(Id, startVel * GearRatio);
            iRet[1] = MotionCard.AxisSetMaxVel(Id, maxVel * GearRatio);
            iRet[2] = MotionCard.AxisSetStopVel(Id, endVel * GearRatio);

            var result = iRet.All(p => p == 0);
            if (!result)
            {
                var msg = $"{err} : 板卡控制报错：{iRet[0] - iRet[1] - iRet[2]} ";
                LogAdd(msg, LogLevel.Warn);
                return (int)SoftWareAlarm.EleAxisByType_AxisSetMinVel_AxisSetMaxVel_AxisSetStopVel方法返回值不等于0;
            }

            LogAdd($"{err} 成功", LogLevel.Trace);
            return 0;
        }
        public void UpdateJogVel()
        {

        }
        public int ChangeVel(double newVel)
        {
            var iRet = EleAxisByCardSafeCheck(null, true, true, true, true);
            if (iRet != 0)
            {
                return iRet;
            }

            var err = $"{CartesianName} 的轴 {Name} 变更速度至 {newVel}";

            iRet = MotionCard.AxisChangeVel(Id, newVel * GearRatio);
            if (iRet != 0)
            {
                var msg = $"{err} : 板卡控制报错：{iRet} ";
                LogAdd(msg, LogLevel.Warn);
                return (int)SoftWareAlarm.EleAxisByType_AxisChangeVel方法返回值不等于0;
            }

            LogAdd($"{err} 成功", LogLevel.Trace);
            return iRet;
        }
        public bool InLocation(double pos)
        {
            return InLocation(pos, ErrChkRange);
        }
        public bool InLocation(double pos, double errChk)
        {
            if (errChk <= 0 || !ErrChkEnable)
            {
                errChk = 10;
            }
            errChk = Math.Max(errChk, 2);

            var up = pos + errChk / 100.0;
            var down = pos - errChk / 100.0;

            if (ActualPos > up || ActualPos < down)
            {
                return false;
            }

            return true;
        }
        public int SetPosition(double pos)
        {
            var iRet = EleAxisByCardSafeCheck(null, true, true, false, false);
            if (iRet != 0)
            {
                return iRet;
            }

            if (!IsStop)
            {
                LogAdd("轴运行中_不能进行位置设置", LogLevel.Trace);
                return 0;
            }

            var err = $"{CartesianName} 的轴 {Name} 指令位置_编码器位置设置";

            iRet = MotionCard.SetAxisPositionAndFeedbackPulse(Id, (int)(pos * GearRatio));
            if (iRet != 0)
            {
                var msg = $"{err} : 板卡控制报错：{iRet} ";
                LogAdd(msg, LogLevel.Warn);
                return (int)SoftWareAlarm.EleAxisByType_SetAxisPositionAndFeedbackPulse方法返回值不等于0;
            }

            LogAdd($"{err} 成功", LogLevel.Trace);
            return iRet;
        }
        public int SetFeedbackToPostion()
        {
            var iRet = EleAxisByCardSafeCheck(null, true, true, false, false);
            if (iRet != 0)
            {
                return iRet;
            }

            var err = $"{CartesianName} 的轴 {Name} 编码器位置设置为指令位置";

            iRet = MotionCard.SetAxisFeedbackPulseToCommand(Id);
            if (iRet != 0)
            {
                var msg = $"{err} : 板卡控制报错：{iRet} ";
                LogAdd(msg, LogLevel.Warn);
                return (int)SoftWareAlarm.EleAxisByType_SetAxisFeedbackPulseToCommand方法返回值不等于0;
            }

            LogAdd($"{err} 成功", LogLevel.Trace);
            return iRet;
        }
        public int ResetAlarm()
        {
            var iRet = EleAxisByCardSafeCheck(null, true, true, false, false);
            if (iRet != 0)
            {
                return iRet;
            }

            var err = $"{CartesianName} 的轴 {Name} 复位报警";

            iRet = MotionCard.AxisResetAlarm(Id);
            if (iRet != 0)
            {
                var msg = $"{err} : 板卡控制报错：{iRet} ";
                LogAdd(msg, LogLevel.Warn);
                return (int)SoftWareAlarm.EleAxisByType_AxisResetAlarm方法返回值不等于0;
            }

            LogAdd($"{err} 成功", LogLevel.Trace);
            return iRet;
        }
        public int ServoEnable(ITask task, bool status, EleAlarmLevel eleLevel = EleAlarmLevel.Err)
        {
            var iRet = EleAxisByCardSafeCheck(task, true, true, false, true);
            if (iRet != 0)
            {
                return iRet;
            }

            ((StationTask)task)?.AbortIfCancel(null);
            ((StationTask)task)?.JoinIfPause();

            var err = $"{CartesianName} 的轴 {Name} 使能信号 {status}";

            iRet = MotionCard.SetAxisBand(Id, (uint)(0.1 * GearRatio), 50);
            if (iRet != 0)
            {
                var msg = $"{err} : 板卡控制报错：{iRet} ";
                switch (eleLevel)
                {
                    case EleAlarmLevel.Err:
                        task?.Log(msg, LogLevel.Error);
                        task?.ThrowException(msg);
                        break;
                    case EleAlarmLevel.Warn:
                        task?.Log(msg, LogLevel.Warn);
                        break;
                    default:
                        task?.Log(msg, LogLevel.Info);
                        break;
                }
                LogAdd(msg, LogLevel.Warn);
                return (int)SoftWareAlarm.EleAxisByType_SetAxisBand方法返回值不等于0;
            }

            //start servo
            iRet = DriveType == AxisType.Step ? MotionCard.AxisSetEnable(Id, !status) : MotionCard.AxisSetEnable(Id, status);
            if (iRet != 0)
            {
                var msg = $"{err} : 板卡控制报错：{iRet} ";
                switch (eleLevel)
                {
                    case EleAlarmLevel.Err:
                        task?.Log(msg, LogLevel.Error);
                        task?.ThrowException(msg);
                        break;
                    case EleAlarmLevel.Warn:
                        task?.Log(msg, LogLevel.Warn);
                        break;
                    default:
                        task?.Log(msg, LogLevel.Info);
                        break;
                }
                LogAdd(msg, LogLevel.Warn);
                return (int)SoftWareAlarm.EleAxisByType_AxisSetEnable方法返回值不等于0;
            }

            //wait servo
            Thread.Sleep(500);
            var result = status == IsServoOn && !IsAlarm;
            if (!result)
            {
                var msg = $"{err} : 当前使能状态：{IsServoOn} or 轴报警状态：{IsAlarm} ";
                switch (eleLevel)
                {
                    case EleAlarmLevel.Err:
                        task?.Log(msg, LogLevel.Error);
                        task?.ThrowException(msg);
                        break;
                    case EleAlarmLevel.Warn:
                        task?.Log(msg, LogLevel.Warn);
                        break;
                    default:
                        task?.Log(msg, LogLevel.Info);
                        break;
                }
                LogAdd(msg, LogLevel.Warn);
                return (int)SoftWareAlarm.EleAxisByType_轴使能失败;
            }

            LogAdd($"{err} 成功。", LogLevel.Trace);
            task?.Log($"{err} 成功。", LogLevel.Trace);
            return 0;
        }
        public void UpdateAxisByType(ByType newType)
        {
            DeviceType = newType;
            OnAxisByTypeUpdated?.Invoke(this);
        }
        public void UpdateAxisName(string newName)
        {
            Name = newName;
            ((SingleAxisStatusControl)StatusUi)?.UpdateAxisName();
            ((SingleAxisManualControl)ManualUi)?.UpdateAxisName();
        }
        public void UpdateCartesianName(string name)
        {
            CartesianName = name;
        }
        public int FindPrim()
        {
            var err = $"寻找基元 {DevName}";

            var prim = PrimsManagerTransfer.GetPrimByName(DevName);
            if (prim == null)
            {
                var msg = $"{err} : 未找到";
                LogAdd(msg, LogLevel.Warn);
                return (int)SoftWareAlarm.EleAxisByType_轴控制基元未找到;
            }

            if (DeviceType == ByType.MotionCard)
            {
                MotionCard = (IAxis)prim;
                LogAdd($"{err}成功", LogLevel.Trace);
                return 0;
            }
            else
            {
                var msg = $"{err} : 不匹配";
                LogAdd(msg, LogLevel.Warn);
                return (int)SoftWareAlarm.EleAxisByType_轴控制基元类型不匹配;
            }
        }
        public bool CheckManualEnable()
        {
            if (!ManualEnable)
            {
                LogAdd("禁止操作，请先切换至手动！", LogLevel.Warn);
                ProxyTools.Notification.ShowWarn("禁止操作，请先切换至手动！！！");
            }
            return ManualEnable;
        }
        public PrimRunState CheckPrimRunState()
        {
            if (MotionCard == null && FindPrim() != 0)
            {
                return PrimRunState.Other;
            }

            return ((IPrim)MotionCard).PrimRunStat;
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>检查运动到位</summary>
        /// <param name="pos">指定位置</param>
        /// <returns>bool</returns>
        private bool CheckAxisMoveDone(double pos)
        {
            if (!IsStop || !SignalInp || !InLocation(pos))
            {
                return false;
            }

            return true;
        }

        private bool CheckHomeDone()
        {
            if (!IsStop || !SignalInp)
            {
                return false;
            }

            return true;
        }
        /// <summary>检查是否在指定误差内</summary>
        /// <param name="value1">值1</param>
        /// <param name="value2">值2</param>
        /// <returns>bool</returns>
        private bool DoubleEquals(double value1, double value2)
        {
            //双精度误差
            var DOUBLE_DELTA = 1E-6;
            return value1 == value2 || Math.Abs(value1 - value2) <= DOUBLE_DELTA;
        }
        /// <summary>日志</summary>
        /// <param name="log">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        public void LogAdd(string log, LogLevel lv, long id = 0)
        {
            string tempId = $"{(int)lv}{(int)PrimLogId.EleAxisByType}0000";

            if (long.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            ProxyTools.LogHelper.LogAdd(lv, log, Name, LogClassification.Elements, id);
        }
        /// <summary>EleAxisByCard运行前基本检查</summary>
        /// <param name="task">task</param>
        /// <param name="enable">true：轴启用检查；false：轴启用不进行检查</param>
        /// <param name="motionCard">true：MotionCard为空检查；false：MotionCard为空不进行检查</param>
        /// <param name="isServoOn">true：轴使能检查；false：轴使能不进行检查</param>
        /// <param name="isAlarm">true：轴报警检查；false：轴报警不进行检查</param>
        /// <returns>int</returns>
        private int EleAxisByCardSafeCheck(ITask task, bool enable = true, bool motionCard = true, bool isServoOn = true, bool isAlarm = true)
        {
            string err = $"{CartesianName} 的轴 {Name}";
            if (enable)
            {
                if (!Enable)
                {
                    LogAdd(err + "未启用", LogLevel.Warn);
                    task?.Log(err + "未启用", LogLevel.Warn, task == null ? 0 : task.Idx);
                    return (int)SoftWareAlarm.EleAxisByType_未启用;
                }
            }

            if (motionCard)
            {
                if (MotionCard == null)
                {
                    LogAdd($"基元{DevName}为空", LogLevel.Warn);
                    task?.Log($"基元{DevName}为空", LogLevel.Warn, task == null ? 0 : task.Idx);
                    return (int)SoftWareAlarm.EleAxisByType_MotionCard为空;
                }
            }

            if (isServoOn)
            {
                if (!IsServoOn)
                {
                    LogAdd(err + "未使能", LogLevel.Warn);
                    task?.Log(err + "未使能", LogLevel.Warn, task == null ? 0 : task.Idx);
                    return (int)SoftWareAlarm.EleAxisByType_轴未使能;
                }
            }

            if (isAlarm)
            {
                if (IsAlarm)
                {
                    LogAdd(err + "报警中", LogLevel.Warn);
                    task?.Log(err + "报警中", LogLevel.Warn, task == null ? 0 : task.Idx);
                    return (int)SoftWareAlarm.EleAxisByType_轴报警中;
                }
            }

            return 0;
        }
        /// <summary>
        /// 设置轴急停减速度
        /// </summary>
        /// <returns></returns>
        int SetStopDec()
        {
            int ret = 0;
            if (!_setStopDec)
            {
                ret = MotionCard.AxisSetStopDec(Id, (int)GearRatio);
                if (ret != 0)
                {
                    LogAdd($"轴Id = {Id}，轴停止减速度设置失败 = {ret}", LogLevel.Warn);
                }
                else
                {
                    _setStopDec = true;
                }
            }
            return ret;
        }
        #endregion
    }
}