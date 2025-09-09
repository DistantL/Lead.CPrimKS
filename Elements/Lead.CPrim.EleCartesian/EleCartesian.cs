using Lead.CPrim.EleCartesian.EleUIs;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces.StateMachine;
using Lead.CPrim.MachineHelper;
using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.EleCartesian
{
    /// <summary>轴组管理器</summary>
    public class EleCartesian : IEle, IEleCartesian
    {
        #region Field
        /// <summary>轴组配置管理器</summary>
        private EleCartesianConfig _config;
        /// <summary>轴组被选择</summary>
        private bool _isSelected;
        /// <summary>轴组手动使能</summary>
        private bool _manualEnable = false;
        /// <summary>轴组轴集合</summary>
        private ConcurrentDictionary<int, IEleAxis> _axises = new ConcurrentDictionary<int, IEleAxis>();
        /// <summary>手动调试UI集合</summary>
        private readonly Dictionary<Guid, Control> _dicManualUis = new Dictionary<Guid, Control>();
        /// <summary>任务</summary>
        private ITask _curTask;
        /// <summary>轴组保存锁</summary>
        public object LockAxises = new object();
        /// <summary>是否为任务模式</summary>
        private bool _isTaskMode;
        /// <summary>元件运行状态</summary>
        private EleRunState _eleRunState;
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public EleCartesian()
        {
            _config = new EleCartesianConfig();

            EleConfigUI = new ConfigUI(this);
            EleDebugUI = new DebugUI(this);
            EleRunStat = EleRunState.Other;
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="xmlNode"></param>
        public EleCartesian(XmlNode xmlNode)
        {
            if (xmlNode == null)
            {
                return;
            }

            _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(EleCartesianConfig)) as EleCartesianConfig;

            if (string.IsNullOrEmpty(Info))
            {
                Info = NLocalizer.GetString(Name, Name);
            }

            ImportAxisesConfigFromPath();

            ImportPointsFromPath();

            EleConfigUI = new ConfigUI(this);
            EleDebugUI = new DebugUI(this);
            EleRunStat = EleRunState.Other;
        }
        #endregion



        //*****************************************************************************
        #region Override IEle
        public Guid Id { get => _config.Id; set => _config.Id = value; }
        public string DevName { get; set; }
        public string Name { get => _config.Name; set => _config.Name = value; }
        public string Info { get => _config.Info; set => _config.Info = value; }
        public bool IsSelected
        {
            set
            {
                if (value == _isSelected) return;

                _isSelected = value;
                EleConfigUI.BackColor = value ? Color.Green : Color.LightGray;
            }
            get => _isSelected;
        }
        public Control EleConfigUI { get; private set; }
        public Control EleDebugUI { get; private set; }
        public EleRunState EleRunStat
        {
            get => _eleRunState;
            set
            {
                if (_eleRunState == value)
                {
                    return;
                }

                _eleRunState = value;
                OnEleStateChanged?.Invoke(value);
                SetRunState(value);
            }
        }
        public bool Enable { get => _config.Enable; set => _config.Enable = value; }
        public string EleTypeName { get => _config.EleTypeName; set => _config.EleTypeName = value; }
        public bool LogEnable { get => _config.LogEnable; set => _config.LogEnable = value; }
        public LogLevel EleAlarmLv { get; set; }
        public bool LogDisplay { get => _config.LogDisplay; set => _config.LogDisplay = value; }
        public bool ManualEnable
        {
            get => _manualEnable;
            set
            {
                if (_manualEnable == value)
                {
                    return;
                }

                _manualEnable = value;
                _axises.Values.ToList().ForEach(p => p.ManualEnable = value);
                ((ConfigUI)EleConfigUI).SetManualEnable(value);
                _dicManualUis.Values.ToList().ForEach(p => ((ManualUI)p)?.SetManualEnable(value));
            }
        }
        public bool IsSimulateMode { get => _config.IsSimulateMode; set => _config.IsSimulateMode = value; }

        public event EleStateChangedEventHandle OnEleStateChanged;

        public PrimRunState IEleCheckPrimRunState()
        {
            return X.CheckPrimRunState();
        }
        public int IEleDispose()
        {
            try
            {
                IEleStop();
                if (EleConfigUI != null && !EleConfigUI.Disposing && !EleConfigUI.IsDisposed) EleConfigUI.Dispose();

                if (EleDebugUI != null && !EleDebugUI.Disposing && !EleDebugUI.IsDisposed) EleDebugUI.Dispose();
                EleRunStat = EleRunState.Other;
                return 0;
            }
            catch (Exception)
            {
                EleRunStat = EleRunState.Other;
                return -1;
            }
        }
        public int IEleInit()
        {
            if (!Enable) return 0;

            if (EleRunStat == EleRunState.Running || IsSimulateMode) return 0;

            if (Axises.Count == 0)
            {
                EleRunStat = EleRunState.Other;
                return -3;
            }

            if (Axises.All(axis => axis.Value.CheckPrimRunState() == PrimRunState.Running))
            {
                EleRunStat = EleRunState.Running;
                return 0;
            }

            EleRunStat = EleRunState.Other;
            return -2;
        }
        public int IEleReset()
        {
            if (EleRunStat != EleRunState.Err) return 0;

            GroupResetAlarm();
            Thread.Sleep(500);
            if (Axises.Any(p => p.Value.IsAlarm)) return -1;
            EleRunStat = EleRunState.Running;
            return 0;
        }
        public int IEleStop()
        {
            return 0;
        }
        public int IEleUiRefresh()
        {
            if (EleConfigUI == null)
            {
                EleConfigUI = new ConfigUI(this);
            }
            if (EleDebugUI == null)
            {
                EleDebugUI = new DebugUI(this);
            }

            if (EleRunStat != EleRunState.Running)
            {
                return 0;
            }

            ((ConfigUI)EleConfigUI).UiRefresh();

            return 0;
        }
        public string GetCsvValue()
        {
            return "";
        }
        public string GetCsvHeader()
        {
            return "";
        }
        public int CsvToValue(string csvString)
        {
            return 0;
        }
        public XmlNode IEleExportConfigXml()
        {
            if (_config == null) return null;

            var node = ProxyTools.XMLHelper.ObjectToXML(_config);

            return node;
        }
        public int IEleImportConfigXml(XmlNode xmlNode)
        {
            var iRet = 0;
            if (xmlNode == null) return -1;

            _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(EleCartesianConfig)) as EleCartesianConfig;

            ImportAxisesConfigFromPath();

            ImportPointsFromPath();

            LoadAxisIndex();

            if (EleConfigUI == null) EleConfigUI = new ConfigUI(this);
            if (EleDebugUI == null) EleDebugUI = new DebugUI(this);

            EleRunStat = EleRunState.Other;
            return iRet;
        }
        #endregion



        #region Override IEleCartesian
        public string AxisesConfigPath { set => _config.AxisesConfigPath = value; get => _config.AxisesConfigPath; }
        public string PointsPath { set => _config.PointsPath = value; get => _config.PointsPath; }
        public ConcurrentDictionary<int, IEleAxis> Axises { set => _axises = value; get => _axises; }
        public int AxisNum { set => _config.AxisNum = value; get => _config.AxisNum; }
        public int[] AxisIndex { get; } = { -1, -1, -1, -1, -1, -1 };
        public int AxisXIndex { get; private set; } = -1;
        public int AxisYIndex { get; private set; } = -1;
        public int AxisZIndex { get; private set; } = -1;
        public int AxisUIndex { get; private set; } = -1;
        public int AxisVIndex { get; private set; } = -1;
        public int AxisWIndex { get; private set; } = -1;
        public CartesianPoints Points { set; get; } = new CartesianPoints();
        public AccDecType VelMode { set => _config.VelMode = value; get => _config.VelMode; }
        public IEleAxis X { set; get; }
        public IEleAxis Y { set; get; }
        public IEleAxis Z { set; get; }
        public IEleAxis U { set; get; }
        public IEleAxis V { set; get; }
        public IEleAxis W { set; get; }
        public double PosLimit { set => _config.PosLimit = value; get => _config.PosLimit; }
        public double TimeOutS { set => _config.TimeOutS = value; get => _config.TimeOutS; }


        #region GroupJumpAbs
        /// <summary></summary>
        /// <param name="axis"></param>
        /// <param name="pos"></param>
        /// <param name="vel"></param>
        /// <param name="jumpPosValue"></param>
        /// <param name="jumpMode"></param>
        /// <param name="ratio"></param>
        /// <param name="timeoutS"></param>
        /// <param name="asyncMode"></param>
        /// <param name="checkLimit"></param>
        /// <param name="task"></param>
        /// <param name="eleLevel"></param>
        /// <returns></returns>
        private int GroupJumpAbs(IEleAxis[] axis, double[] pos, double[] vel, double jumpPosValue,
            bool jumpMode = false, ushort ratio = 100, int timeoutS = -1, bool asyncMode = false,
            bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err)
        {
            if (!Enable)
            {
                return (int)SoftWareAlarm.EleCartesian_未启用;
            }

            if (EleRunStat != EleRunState.Running)
            {
                return (int)SoftWareAlarm.EleCartesian_元件不在运行状态;
            }

            if (!Enable || EleRunStat != EleRunState.Running || axis.Length <= 0 || axis.Length != pos.Length || pos.Length != vel.Length) return -1;

            if (axis.Any(a => a != null && (!a.Enable || a.Enable && (!a.IsServoOn || a.IsAlarm))))
            {
                task?.ThrowException("龙门移动，轴报错 ");
                return -2;
            }

            ((StationTask)task)?.AbortIfCancel(null);
            ((StationTask)task)?.JoinIfPause();

            var err = $"{string.Join(",", axis.Select(a => a == null ? string.Empty : a.Name))} GroupJumpAbs {string.Join(",", pos.Select(p => p.ToString("F2")))} {string.Join(",", vel.Select(p => p.ToString("F2")))}";

            var axisZ = Axises.FirstOrDefault(p => p.Value.Name.ToLower().Contains("_z"));

            var axisZJumpRet = 0;

            if (axisZ.Key != -1 && axisZ.Value != null && axisZ.Value.Id != -1 && axisZ.Value.Enable)
                axisZJumpRet = jumpMode ? SingleMoveRel(axisZ.Key, jumpPosValue, vel[axisZ.Key], ratio, false, false, task, eleLevel) : SingleMoveAbs(axisZ.Key, jumpPosValue, vel[axisZ.Key], ratio, false, false, task, eleLevel);

            if (axisZJumpRet != 0)
            {
                var msg = $"{err} Z轴点位 {pos[axisZ.Key]} 使用 {(jumpMode ? "相对模式" : "绝对模式")} ";
                switch (eleLevel)
                {
                    case EleAlarmLevel.Err:
                        task?.Log(msg, LogLevel.Error);
                        break;
                    case EleAlarmLevel.Warn:
                        task?.Log(msg, LogLevel.Warn);
                        break;
                    default:
                        task?.Log(msg, LogLevel.Info);
                        break;
                }
                task?.ThrowException(msg);
                return axisZJumpRet;
            }

            var axisExceptZ = new List<IEleAxis>();
            var posExceptZ = new List<double>();
            var velExceptZ = new List<double>();

            for (var i = 0; i < axis.Length; i++)
                if (i != axisZ.Key)
                {
                    axisExceptZ.Add(Axises[i]);
                    posExceptZ.Add(pos[i]);
                    velExceptZ.Add(vel[i]);
                }

            var groupMoveAbsRet = 0;
            if (axisZ.Key != -1 && axisZ.Value != null && axisZ.Value.Id != -1)
            {
                groupMoveAbsRet = GroupMoveAbs(axisExceptZ.ToArray(), posExceptZ.ToArray(), velExceptZ.ToArray(), ratio,
                    timeoutS, false, true, task, eleLevel);
                if (groupMoveAbsRet == 0)
                    groupMoveAbsRet = SingleMoveAbs(axisZ.Key, pos[axisZ.Key], vel[axisZ.Key], ratio, false, false,
                        task, eleLevel);
                else
                    return groupMoveAbsRet;
            }
            else
            {
                groupMoveAbsRet = GroupMoveAbs(axis, pos, vel, ratio, timeoutS, asyncMode, checkLimit, task, eleLevel);
            }

            return groupMoveAbsRet;
        }
        public int GroupJumpAbs(int posIndex, double jumpPosValue, bool jumpMode = false, ushort ratio = 100,
            int timeoutS = -1, bool asyncMode = false, bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err)
        {
            if (!Enable || Points.GroupPoints.IsEmpty || !Points.GroupPoints.ContainsKey(posIndex) ||
                AxisNum != Points.GroupPoints[posIndex].Pos.Length) return -1;

            var vel = new double[AxisNum];
            for (var i = 0; i < AxisNum; i++)
            {
                vel[i] = Axises[i].DefaultMaxVel;
            }
            return GroupJumpAbs(Axises.Values.ToArray(), Points.GroupPoints[posIndex].Pos, vel, jumpPosValue, jumpMode,
                ratio, timeoutS, asyncMode, checkLimit, task, eleLevel);
        }
        public int GroupJumpAbs(string posName, double jumpPosValue, bool jumpMode = false, ushort ratio = 100,
            int timeoutS = -1, bool asyncMode = false, bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err)
        {
            if (!Enable || Points.GroupPoints.IsEmpty) return -1;

            var pos = Points.GroupPoints.FirstOrDefault(p => p.Value.Name == posName);
            if (pos.Key == -1 || AxisNum != Points.GroupPoints[pos.Key].Pos.Length) return -2;

            return GroupJumpAbs(pos.Key, jumpPosValue, jumpMode, ratio, timeoutS, asyncMode, checkLimit, task, eleLevel);
        }
        public int GroupJumpAbs(double[] pos, double jumpPosValue, bool jumpMode = false, ushort ratio = 100,
            int timeoutS = -1, bool asyncMode = false, bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err)
        {
            var vel = new double[AxisNum];
            for (var i = 0; i < AxisNum; i++) vel[i] = Axises[i].DefaultMaxVel;

            return GroupJumpAbs(Axises.Values.ToArray(), pos, vel, jumpPosValue, jumpMode, ratio, timeoutS, asyncMode,
                checkLimit, task, eleLevel);
        }
        public int GroupJumpAbs(double[] pos, double[] vel, double jumpPosValue, bool jumpMode = false,
            ushort ratio = 100, int timeoutS = -1, bool asyncMode = false, bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err)
        {
            return GroupJumpAbs(Axises.Values.ToArray(), pos, vel, jumpPosValue, jumpMode, ratio, timeoutS, asyncMode,
                checkLimit, task, eleLevel);
        }
        public int GroupJumpAbs(Pos pos, double jumpPosValue, bool jumpMode = false, ushort ratio = 100,
            int timeoutS = -1, bool asyncMode = false, bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err)
        {
            if (!Enable || EleRunStat != EleRunState.Running || AxisNum <= 0) return -1;

            var axis = new List<IEleAxis>();
            var destPos = new List<double>();
            var vel = new List<double>();

            if (AxisXIndex != -1)
            {
                axis.Add(Axises[AxisXIndex]);
                destPos.Add(pos.X);
                vel.Add(Axises[AxisXIndex].DefaultMaxVel);
            }

            if (AxisYIndex != -1)
            {
                axis.Add(Axises[AxisYIndex]);
                destPos.Add(pos.Y);
                vel.Add(Axises[AxisYIndex].DefaultMaxVel);
            }

            if (AxisZIndex != -1)
            {
                axis.Add(Axises[AxisZIndex]);
                destPos.Add(pos.Z);
                vel.Add(Axises[AxisZIndex].DefaultMaxVel);
            }

            if (AxisUIndex != -1)
            {
                axis.Add(Axises[AxisUIndex]);
                destPos.Add(pos.U);
                vel.Add(Axises[AxisUIndex].DefaultMaxVel);
            }

            if (AxisVIndex != -1)
            {
                axis.Add(Axises[AxisVIndex]);
                destPos.Add(pos.V);
                vel.Add(Axises[AxisVIndex].DefaultMaxVel);
            }

            if (AxisWIndex != -1)
            {
                axis.Add(Axises[AxisWIndex]);
                destPos.Add(pos.W);
                vel.Add(Axises[AxisWIndex].DefaultMaxVel);
            }

            return GroupJumpAbs(axis.ToArray(), destPos.ToArray(), vel.ToArray(), jumpPosValue, jumpMode, ratio,
                timeoutS, asyncMode, checkLimit, task, eleLevel);
        }
        #endregion

        #region GroupMoveAbs
        /// <summary></summary>
        /// <param name="axis"></param>
        /// <param name="pos"></param>
        /// <param name="vel"></param>
        /// <param name="ratio"></param>
        /// <param name="timeoutS"></param>
        /// <param name="asyncMode"></param>
        /// <param name="checkLimit"></param>
        /// <param name="task"></param>
        /// <param name="eleLevel"></param>
        /// <param name="checkPosDelay"></param>
        /// <returns></returns>
        private int GroupMoveAbs(IEleAxis[] axis, double[] pos, double[] vel, ushort ratio = 100, int timeoutS = -1,
            bool asyncMode = false, bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            try
            {
                var err = $"{Info} 的 {string.Join(",", axis.Select(a => a == null ? string.Empty : a.Name))} 绝对移动至 {string.Join(",", pos.Select(p => p.ToString("F3")))} 速度 {string.Join(",", vel.Select(p => p.ToString("F0")))}";

                var ret = EleCartesianSafeCheck(task);
                if (ret != 0)
                {
                    return ret;
                }

                if (axis.Length <= 0 || pos.Length <= 0 || vel.Length <= 0)
                {
                    var msg = $"{err}，轴&点位&速度数组长度小于等于0";
                    task?.Log(msg, LogLevel.Warn);
                    return (int)SoftWareAlarm.EleCartesian_轴_点位_速度数组长度小于等于0;
                }

                if (axis.Length != pos.Length || pos.Length != vel.Length)
                {
                    var msg = $"{err}，轴&点位&速度数组长度不一致";
                    task?.Log(msg, LogLevel.Warn);
                    return (int)SoftWareAlarm.EleCartesian_轴_点位_速度数组长度不一致;
                }

                ((StationTask)task)?.AbortIfCancel(null);
                ((StationTask)task)?.JoinIfPause();

                var iRet = new int[axis.Length];
                for (var i = 0; i < axis.Length; i++)
                {
                    iRet[i] = axis[i].MoveAbs(null, pos[i], vel[i], ratio, -1, true, checkLimit, 1, eleLevel);
                    if (iRet[i] != 0)
                    {
                        GroupStop();
                        var msg = $"{err} 轴 {axis[i].Name} 移动报错，当前位置：{string.Join(",", axis.Select(p => p.ActualPos.ToString()))} ";
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
                        return iRet[i];
                    }
                }

                if (asyncMode)
                {
                    return iRet.All(p => p == 0) ? 0 : -10;
                }

                if (axis.Where((t1, i) => t1.Enable && !t1.InLocation(pos[i])).Any())
                {
                    Thread.Sleep(checkPosDelay);
                }

                //确认到位
                var t = 0;
                timeoutS = timeoutS < 0 ? 100 : timeoutS;
                while (t++ <= timeoutS * 1000)
                {
                    if (axis.Any(a => !a.Enable || a.IsAlarm || !a.IsServoOn || checkLimit && (a.InPel || a.InMel || a.InSPel || a.InSMel)))
                    {
                        Thread.Sleep(200);
                        if (axis.Any(a =>
                            !a.Enable || a.IsAlarm || !a.IsServoOn ||
                            checkLimit && (a.InPel || a.InMel || a.InSPel || a.InSMel)))
                        {
                            axis.ToList().ForEach(a => a.StopMove());
                            var msg = $"{err} 限位: 负限位 {axis.Any(a => a != null && (a.InSMel || a.InMel))} 正限位 {axis.Any(a => a != null && (a.InSPel || a.InPel))} or 轴报警 {axis.Any(a => a != null && (!a.IsServoOn || a.IsAlarm))} 报错，当前位置：{string.Join(",", axis.Select(p => p.ActualPos.ToString()))} ";
                            switch (eleLevel)
                            {
                                case EleAlarmLevel.Err:
                                    task?.Log(msg, LogLevel.Error);
                                    break;
                                case EleAlarmLevel.Warn:
                                    task?.Log(msg, LogLevel.Warn);
                                    break;
                                default:
                                    task?.Log(msg, LogLevel.Info);
                                    break;
                            }
                            task?.ThrowException(msg);
                            return -2;
                        }
                    }

                    if (CheckAxisMoveDone(axis, pos))
                    {
                        for (var i = 0; i < axis.Length; i++)
                            if (axis[i].Enable && axis[i].ErrChkEnable && !axis[i].InLocation(pos[i]))
                            {
                                var msg = $"{err} 移动报错 {string.Join(",", axis.Select(a => a == null ? string.Empty : a.ActualPos.ToString("F2")))}，当前位置：{string.Join(",", axis.Select(p => p.ActualPos.ToString()))} ";
                                switch (eleLevel)
                                {
                                    case EleAlarmLevel.Err:
                                        task?.Log(msg, LogLevel.Error);
                                        break;
                                    case EleAlarmLevel.Warn:
                                        task?.Log(msg, LogLevel.Warn);
                                        break;
                                    default:
                                        task?.Log(msg, LogLevel.Info);
                                        break;
                                }
                                task?.ThrowException(msg);
                                return -3;
                            }

                        task?.Log($"{err} 成功，当前位置：{string.Join(",", axis.Select(p => p.ActualPos.ToString()))}", LogLevel.Trace);
                        return 0;
                    }

                    //check task status
                    if (task != null)
                    {
                        if (((StationTask)task).RunningState != SmStates.Running &&
                            ((StationTask)task).RunningState != SmStates.Resetting)
                        {
                            axis.ToList().ForEach(a => a.StopMove());
                            ((StationTask)task)?.AbortIfCancel(nameof(GroupMoveAbs));
                        }

                        if (((StationTask)task).RunningState == SmStates.Pause ||
                            ((StationTask)task).RunningState == SmStates.WaitClrErr)
                        {
                            axis.ToList().ForEach(a => a.StopMove());
                            ((StationTask)task).JoinIfPause();
                            Thread.Sleep(200);
                            ((StationTask)task)?.AbortIfCancel(nameof(GroupMoveAbs));
                            for (var i = 0; i < axis.Length; i++)
                            {
                                if (!axis[i].Enable)
                                {
                                    iRet[i] = 0;
                                    continue;
                                }

                                iRet[i] = axis[i].MoveAbs(null, pos[i], vel[i], ratio, -1, true, true, 1, eleLevel);
                                if (iRet[i] != 0)
                                {
                                    axis.ToList().ForEach(a => a.StopMove());
                                    var msg = $"{err} 轴 {axis[i].Name} 运动报错，当前位置：{string.Join(",", axis.Select(p => p.ActualPos.ToString()))}";
                                    switch (eleLevel)
                                    {
                                        case EleAlarmLevel.Err:
                                            task?.Log(msg, LogLevel.Error);
                                            break;
                                        case EleAlarmLevel.Warn:
                                            task?.Log(msg, LogLevel.Warn);
                                            break;
                                        default:
                                            task?.Log(msg, LogLevel.Info);
                                            break;
                                    }
                                    task?.ThrowException(msg);
                                    return iRet[i];
                                }
                            }

                            if (axis.Where((t1, i) => t1.Enable && !t1.InLocation(pos[i])).Any())
                            {
                                Thread.Sleep(checkPosDelay);
                            }
                        }
                    }

                    Thread.Sleep(1);
                }

                //home timeout
                task?.Log($"{err} 超时，当前位置：{string.Join(",", axis.Select(p => p.ActualPos.ToString()))}", LogLevel.Error);
                task?.ThrowException($"{err} timeout");
                return -10;
            }
            catch (Exception ex)
            {
                task?.Log("GroupMoveAbs报错 => " + ex.ToString(), LogLevel.Warn);
                return -10;
            }
        }
        public bool CheckAxisMoveDone(IEleAxis[] axis, double[] pos)
        {
            for (int index = 0; index < axis.Length; ++index)
            {
                if (axis[index].Enable && (!axis[index].IsStop || !axis[index].SignalInp || !axis[index].InLocation(pos[index])))
                    return false;
            }
            return true;
        }
        public int GroupMoveAbs(int posIndex, ushort ratio = 100, int timeoutS = -1, bool asyncMode = false,
            bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            if (Points.GroupPoints.IsEmpty || !Points.GroupPoints.ContainsKey(posIndex) ||
                AxisNum != Points.GroupPoints[posIndex].Pos.Length) return -1;

            var pos = new double[AxisNum];
            var vel = new double[AxisNum];
            for (var i = 0; i < AxisNum; i++)
            {
                vel[i] = Axises[i].DefaultMaxVel;
                pos[i] = Points.GroupPoints[posIndex].Pos[i];
            }

            return GroupMoveAbs(Axises.Values.ToArray(), pos, vel, ratio, timeoutS, asyncMode, checkLimit, task, eleLevel, checkPosDelay);
        }
        public int GroupMoveAbs(string posName, ushort ratio = 100, int timeoutS = -1, bool asyncMode = false,
            bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            if (Points.GroupPoints.IsEmpty) return -1;

            var pos = Points.GroupPoints.FirstOrDefault(p => p.Value.Name == posName);
            if (pos.Key == -1 || AxisNum != Points.GroupPoints[pos.Key].Pos.Length) return -2;

            return GroupMoveAbs(pos.Key, ratio, timeoutS, asyncMode, checkLimit, task, eleLevel, checkPosDelay);
        }
        public int GroupMoveAbs(double[] pos, ushort ratio = 100, int timeoutS = -1, bool asyncMode = false,
            bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            var vel = new double[AxisNum];
            for (var i = 0; i < AxisNum; i++)
            {
                vel[i] = Axises[i].DefaultMaxVel;
            }
            return GroupMoveAbs(Axises.Values.ToArray(), pos, vel, ratio, timeoutS, asyncMode, checkLimit, task, eleLevel, checkPosDelay);
        }
        public int GroupMoveAbs(double[] pos, double[] vel, ushort ratio = 100, int timeoutS = -1,
            bool asyncMode = false, bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            return GroupMoveAbs(Axises.Values.ToArray(), pos, vel, ratio, timeoutS, asyncMode, checkLimit, task, eleLevel, checkPosDelay);
        }
        public int GroupMoveAbs(Pos pos, ushort ratio = 100, int timeoutS = -1, bool asyncMode = false, bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            return GroupMoveAbs(pos, null, ratio, timeoutS, asyncMode, checkLimit, task, eleLevel, checkPosDelay);
        }
        public int GroupMoveAbs(Pos pos, Vel vel, ushort ratio = 100, int timeoutS = -1, bool asyncMode = false, bool checkLimit = true, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            var iRet = EleCartesianSafeCheck();
            if (iRet != 0)
            {
                return iRet;
            }

            var axis = new List<IEleAxis>();
            var destPos = new List<double>();
            var listVel = new List<double>();

            if (AxisXIndex != -1)
            {
                if (Axises.ContainsKey(AxisXIndex))
                {
                    axis.Add(Axises[AxisXIndex]);
                    destPos.Add(pos.X);
                    listVel.Add(vel != null ? vel.X : Axises[AxisXIndex].DefaultMaxVel);
                }
                else
                {
                    task?.Log($"轴组 {Name} 不包含X轴", LogLevel.Warn);
                    return (int)SoftWareAlarm.EleCartesian_轴集合中不包含X轴;
                }
            }

            if (AxisYIndex != -1)
            {
                if (Axises.ContainsKey(AxisYIndex))
                {
                    axis.Add(Axises[AxisYIndex]);
                    destPos.Add(pos.Y);
                    listVel.Add(vel != null ? vel.Y : Axises[AxisYIndex].DefaultMaxVel);
                }
                else
                {
                    task?.Log($"轴组 {Name} 不包含Y轴", LogLevel.Warn);
                    return (int)SoftWareAlarm.EleCartesian_轴集合中不包含Y轴;
                }
            }

            if (AxisZIndex != -1)
            {
                if (Axises.ContainsKey(AxisZIndex))
                {
                    axis.Add(Axises[AxisZIndex]);
                    destPos.Add(pos.Z);
                    listVel.Add(vel != null ? vel.Z : Axises[AxisZIndex].DefaultMaxVel);
                }
                else
                {
                    task?.Log($"轴组 {Name} 不包含Z轴", LogLevel.Warn);
                    return (int)SoftWareAlarm.EleCartesian_轴集合中不包含Z轴;
                }
            }

            if (AxisUIndex != -1)
            {
                if (Axises.ContainsKey(AxisUIndex))
                {
                    axis.Add(Axises[AxisUIndex]);
                    destPos.Add(pos.U);
                    listVel.Add(vel != null ? vel.U : Axises[AxisUIndex].DefaultMaxVel);
                }
                else
                {
                    task?.Log($"轴组 {Name} 不包含U轴", LogLevel.Warn);
                    return (int)SoftWareAlarm.EleCartesian_轴集合中不包含U轴;
                }
            }

            if (AxisVIndex != -1)
            {
                if (Axises.ContainsKey(AxisVIndex))
                {
                    axis.Add(Axises[AxisVIndex]);
                    destPos.Add(pos.V);
                    listVel.Add(vel != null ? vel.V : Axises[AxisVIndex].DefaultMaxVel);
                }
                else
                {
                    task?.Log($"轴组 {Name} 不包含V轴", LogLevel.Warn);
                    return (int)SoftWareAlarm.EleCartesian_轴集合中不包含V轴;
                }
            }

            if (AxisWIndex != -1)
            {
                if (Axises.ContainsKey(AxisWIndex))
                {
                    axis.Add(Axises[AxisWIndex]);
                    destPos.Add(pos.W);
                    listVel.Add(vel != null ? vel.W : Axises[AxisWIndex].DefaultMaxVel);
                }
                else
                {
                    task?.Log($"轴组 {Name} 不包含W轴", LogLevel.Warn);
                    return (int)SoftWareAlarm.EleCartesian_轴集合中不包含W轴;
                }
            }

            return GroupMoveAbs(axis.ToArray(), destPos.ToArray(), listVel.ToArray(), ratio, timeoutS, asyncMode, checkLimit, task, eleLevel, checkPosDelay);
        }
        #endregion

        #region Group
        public int GroupHome(int timeoutS = -1, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err)
        {
            if (!Enable || EleRunStat != EleRunState.Running || AxisNum <= 0)
                return -1;

            if (Axises.Any(a => a.Value != null && (!a.Value.Enable || a.Value.Enable && a.Value.IsAlarm)))
            {
                task?.ThrowException($"{Info} 轴组回零，轴报警");
                return -2;
            }

            ((StationTask)task)?.AbortIfCancel(null);
            ((StationTask)task)?.JoinIfPause();

            var err = $"{Info} 轴组回零 ";

            var iRetHome = new int[AxisNum];
            var home = new List<IEleAxis>[AxisNum];

            for (var i = 0; i < home.Length; i++)
            {
                home[i] = new List<IEleAxis>();
                Axises.ToList().ForEach(p =>
                {
                    if (p.Value.HomeIndex == i + 1) home[i].Add(p.Value);
                });
            }

            if (AxisZIndex != -1 && false) //暂时屏蔽
            {
                SingleSetEnable(AxisZIndex, true, task, eleLevel);
                if (SingleMoveAbs(AxisZIndex, -1000, Axises[AxisZIndex].DefaultMaxVel, 30, false, false, task, eleLevel) != 0)
                {
                    var msg = $"{err} Axis {Axises[AxisZIndex].Name} move to Mel error";
                    switch (eleLevel)
                    {
                        case EleAlarmLevel.Err:
                            task?.Log(msg, LogLevel.Error);
                            break;
                        case EleAlarmLevel.Warn:
                            task?.Log(msg, LogLevel.Warn);
                            break;
                        default:
                            task?.Log(msg, LogLevel.Info);
                            break;
                    }
                    task?.ThrowException(msg);
                    return -5;
                }
            }

            var errFlag = false;
            for (var i = 0; i < home.Length; i++)
            {
                //home[i].Any() 如果源序列包含任何元素，则为 true；否则为 false。 
                if (home[i] == null || !home[i].Any())
                    continue;
                //状态.Break()：告知 Parallel 循环应在系统方便的时候尽早停止执行当前迭代之外的迭代。
                //Break 指示应运行在当前迭代后的没有迭代次数。 它有效地取消循环的任何其他迭代。 但是，它不会停止已经开始执行该软件的任何迭代。
                //例如，如果 Break 从循环访问从 0 到 1000 个，所有迭代小于 100 应仍继续运行，但到 1000，尚未启动不是从 101 到迭代执行并行循环的第 100 次迭代调用。

                //状态.Stop()：告知 Parallel 循环应在系统方便的时候尽早停止执行。
                //调用 Stop 方法指示不需要运行尚未开始的任何迭代循环。 它有效地取消循环的任何其他迭代。 但是，它不会停止已经开始执行该软件的任何迭代。
                //调用 Stop 方法使 IsStopped 属性以返回 true 为任何仍在执行该循环的迭代。 这一点特别有用的长时间运行的迭代，可以检查 IsStopped 属性并退出早期如果其值为 true。
                //Stop 在其中一个结果后找到，没有其他迭代需要执行的搜索算法，通常使用。

                Parallel.ForEach(home[i], (item, loopState) =>
                {
                    var axisIndex = Axises.First(p => p.Value.Id == item.Id).Key;
                    if (SingleHome(axisIndex, timeoutS, task, eleLevel) != 0)
                    {
                        errFlag = true;
                        GroupStop();
                        loopState.Stop();
                    }

                    if (loopState.IsStopped || loopState.ShouldExitCurrentIteration)
                    {
                        return;
                    }

                    Thread.Sleep(200);
                    if (SingleMoveAbs(axisIndex, Axises[axisIndex].SafePos, Axises[axisIndex].DefaultMaxVel, 10, true, false, task, eleLevel) != 0)
                    {
                        errFlag = true;
                        GroupStop();
                        loopState.Stop();
                    }
                });
            }

            if (errFlag)
            {
                var msg = $"{err} 回零运动失败。";
                task?.Log(msg, LogLevel.Error);
                task?.ThrowException(msg);
                return -10;
            }

            return 0;
        }
        private int GroupChangeVel(IEleAxis[] axises, double[] veles)
        {
            if (axises.Length != veles.Length) return -1;

            var iRet = new int[axises.Length];
            for (var i = 0; i < axises.Length; i++) iRet[i] = axises[i].ChangeVel(veles[i]);

            return iRet.All(p => p == 0) ? 0 : -10;
        }

        public int GroupChangeVel(double[] newVel)
        {
            if (!Enable || EleRunStat != EleRunState.Running || AxisNum != newVel.Length) return -1;

            var iRet = new int[AxisNum];
            for (var i = 0; i < AxisNum; i++) iRet[i] = Axises[i].ChangeVel(newVel[i]);

            return iRet.All(p => p == 0) ? 0 : -10;
        }

        public int GroupChangeVel(Vel newVel)
        {
            if (!Enable || EleRunStat != EleRunState.Running || AxisNum <= 0) return -1;

            var listAxis = new List<IEleAxis>();
            var listVel = new List<double>();

            if (AxisXIndex != -1)
            {
                listAxis.Add(Axises[AxisXIndex]);
                listVel.Add(newVel.X);
            }

            if (AxisYIndex != -1)
            {
                listAxis.Add(Axises[AxisYIndex]);
                listVel.Add(newVel.Y);
            }

            if (AxisZIndex != -1)
            {
                listAxis.Add(Axises[AxisZIndex]);
                listVel.Add(newVel.Z);
            }

            if (AxisUIndex != -1)
            {
                listAxis.Add(Axises[AxisUIndex]);
                listVel.Add(newVel.U);
            }

            if (AxisVIndex != -1)
            {
                listAxis.Add(Axises[AxisVIndex]);
                listVel.Add(newVel.V);
            }

            if (AxisWIndex != -1)
            {
                listAxis.Add(Axises[AxisWIndex]);
                listVel.Add(newVel.W);
            }

            return GroupChangeVel(listAxis.ToArray(), listVel.ToArray());
        }
        public int GroupResetAlarm()
        {
            var iRet = 0;
            if (AxisNum <= 0) return -1;

            foreach (var axis in Axises)
                if (axis.Value.ResetAlarm() != 0)
                    iRet = -axis.Key;

            return iRet;
        }
        public int GroupSetEnable(bool enable, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err)
        {
            if (!Enable || EleRunStat != EleRunState.Running) return -1;

            return Axises.All(p => p.Value.ServoEnable(task, enable, eleLevel) == 0) ? 0 : -10;
        }
        public int GroupSetFeedbackToPostion()
        {
            if (!Enable || EleRunStat != EleRunState.Running) return -1;

            return Axises.All(p => p.Value.SetFeedbackToPostion() == 0) ? 0 : -10;
        }

        public int GroupSetVelRatio(ushort ratio)
        {
            if (!Enable || EleRunStat != EleRunState.Running) return -1;

            return Axises.All(p => p.Value.SetDefaultVel(ratio) == 0) ? 0 : -10;
        }
        public int GroupStop()
        {
            if (!Enable || EleRunStat != EleRunState.Running || AxisNum <= 0)
                return -1;

            Axises.ToList().ForEach(p => SingleStop(p.Key));

            return 0;
        }
        #endregion

        #region SingleMoveAbs
        public int SingleMoveAbs(int axisIndex, double pos, double vel, ushort ratio = 100, bool checkLimit = true,
            bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            if (!Enable || EleRunStat != EleRunState.Running || !Axises.ContainsKey(axisIndex)) return -1;

            return Axises[axisIndex].MoveAbs(task, pos, vel, ratio, -1, asyncMode, checkLimit, 1, eleLevel, checkPosDelay);
        }

        public int SingleMoveAbs(int axisIndex, int posIndex, ushort ratio = 100, bool checkLimit = true,
            bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            if (Points.SingleAxisPoints == null || !Points.SingleAxisPoints.ContainsKey(axisIndex) ||
                !Points.SingleAxisPoints[axisIndex].Points.ContainsKey(posIndex)) return -1;

            return SingleMoveAbs(axisIndex, Points.SingleAxisPoints[axisIndex].Points[posIndex].Position,
                Points.SingleAxisPoints[axisIndex].Points[posIndex].Velocity, ratio, checkLimit, asyncMode, task, eleLevel, checkPosDelay);
        }

        public int SingleMoveAbs(int axisIndex, string posName, ushort ratio = 100, bool checkLimit = true,
            bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            if (Points.SingleAxisPoints == null) return -1;

            var singlePos = Points.SingleAxisPoints[axisIndex].Points.FirstOrDefault(p => p.Value.Name == posName);
            if (singlePos.Key == -1) return -2;

            return SingleMoveAbs(axisIndex, singlePos.Key, ratio, checkLimit, asyncMode, task, eleLevel, checkPosDelay);
        }

        public int SingleMoveAbs(string axisName, double pos, double vel, ushort ratio = 100, bool checkLimit = true,
            bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            return SingleMoveAbs(FindAxisIndex(axisName), pos, vel, ratio, checkLimit, asyncMode, task, eleLevel, checkPosDelay);
        }

        public int SingleMoveAbs(string axisName, int posIndex, ushort ratio = 100, bool checkLimit = true,
            bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            return SingleMoveAbs(FindAxisIndex(axisName), posIndex, ratio, checkLimit, asyncMode, task, eleLevel, checkPosDelay);
        }

        public int SingleMoveAbs(string axisName, string posName, ushort ratio = 100, bool checkLimit = true,
            bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            if (!Enable || EleRunStat != EleRunState.Running || AxisNum <= 0) return -1;

            var axisIndex = FindAxisIndex(axisName);

            if (axisIndex != -1)
            {
                var singlePos = Points.SingleAxisPoints[axisIndex].Points.FirstOrDefault(p => p.Value.Name == posName);
                if (singlePos.Key == -1 ||
                    !Points.SingleAxisPoints[axisIndex].Points.ContainsKey(singlePos.Key)) return -2;

                return SingleMoveAbs(axisName, singlePos.Key, ratio, checkLimit, asyncMode, task, eleLevel, checkPosDelay);
            }

            return -10;
        }
        #endregion

        #region SingleMoveRel
        public int SingleMoveRel(int axisIndex, double pos, ushort ratio = 100, bool checkLimit = true,
            bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            if (!Enable || EleRunStat != EleRunState.Running || !Axises.ContainsKey(axisIndex)) return -1;

            return Axises[axisIndex].MoveRel(task, pos, ratio, -1, asyncMode, checkLimit, eleLevel, checkPosDelay);
        }

        public int SingleMoveRel(int axisIndex, double pos, double vel, ushort ratio = 100, bool checkLimit = true,
            bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            return Axises[axisIndex].MoveRel(task, pos, vel, ratio, -1, asyncMode, checkLimit, eleLevel, checkPosDelay);
        }

        public int SingleMoveRel(int axisIndex, double pos, double vel, double acc, double dec, ushort ratio = 100,
            bool checkLimit = true, bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            if (!Enable)
            {
                return (int)SoftWareAlarm.EleCartesian_未启用;
            }

            if (EleRunStat != EleRunState.Running)
            {
                return (int)SoftWareAlarm.EleCartesian_元件不在运行状态;
            }

            if (!Axises.ContainsKey(axisIndex))
            {
                return (int)SoftWareAlarm.EleCartesian_轴集合中不包含指定轴Id;
            }

            int ret = Axises[axisIndex].SetVel(0, vel, 0, acc, dec);
            if (ret != 0)
            {
                return ret;
            }

            return Axises[axisIndex].MoveRel(task, pos, vel, ratio, -1, asyncMode, checkLimit, eleLevel, checkPosDelay);
        }

        public int SingleMoveRel(string axisName, double pos, ushort ratio = 100, bool checkLimit = true,
            bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            return SingleMoveRel(FindAxisIndex(axisName), pos, ratio, checkLimit, asyncMode, task, eleLevel, checkPosDelay);
        }

        public int SingleMoveRel(string axisName, double pos, double vel, ushort ratio = 100, bool checkLimit = true,
            bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            return SingleMoveRel(FindAxisIndex(axisName), pos, vel, ratio, checkLimit, asyncMode, task, eleLevel, checkPosDelay);
        }

        public int SingleMoveRel(string axisName, double pos, double vel, double acc, double dec, ushort ratio = 100,
            bool checkLimit = true, bool asyncMode = false, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err, int checkPosDelay = 100)
        {
            return SingleMoveRel(FindAxisIndex(axisName), pos, vel, acc, dec, ratio, checkLimit, asyncMode, task, eleLevel, checkPosDelay);
        }
        #endregion

        #region Single

        public int SingleChangeVel(int axisIndex, double newVel)
        {
            if (!Enable || EleRunStat != EleRunState.Running || !Axises.ContainsKey(axisIndex)) return -1;

            return Axises[axisIndex].ChangeVel(newVel);
        }

        public int SingleChangeVel(string axisName, double newVel)
        {
            return SingleChangeVel(FindAxisIndex(axisName), newVel);
        }

        public int SingleHome(int axisIndex, int timeoutS = -1, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err)
        {
            if (!Enable || EleRunStat != EleRunState.Running || !Axises.ContainsKey(axisIndex)) return -1;

            return Axises[axisIndex].Home(task, timeoutS, eleLevel);
        }

        public int SingleHome(string axisName, int timeoutS = -1, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err)
        {
            return SingleHome(FindAxisIndex(axisName), timeoutS, task, eleLevel);
        }

        public int SingleResetAlarm(int axisIndex)
        {
            if (AxisNum <= 0 || !Axises.ContainsKey(axisIndex)) return -1;

            return Axises[axisIndex].ResetAlarm();
        }

        public int SingleResetAlarm(string axisName)
        {
            if (AxisNum <= 0) return -1;

            var axisIndex = Axises.FirstOrDefault(p => p.Value.Name == axisName);
            if (axisIndex.Key == -1 || !Axises.ContainsKey(axisIndex.Key)) return -2;

            return Axises[axisIndex.Key].ResetAlarm();
        }

        public int SingleSetAccDec(int axisIndex, double acc, double dec)
        {
            if (!Enable || EleRunStat != EleRunState.Running || !Axises.ContainsKey(axisIndex)) return -1;

            return Axises[axisIndex].SetAccDec(acc, dec);
        }

        public int SingleSetDefaultAccDec(int axisIndex, ushort ratio = 100)
        {
            if (!Enable || EleRunStat != EleRunState.Running || !Axises.ContainsKey(axisIndex)) return -1;

            return Axises[axisIndex].SetDefaultAccDec(ratio);
        }

        public int SingleSetDefaultVel(int axisIndex, ushort ratio = 100)
        {
            if (!Enable || EleRunStat != EleRunState.Running || !Axises.ContainsKey(axisIndex)) return -1;

            return Axises[axisIndex].SetDefaultVel(ratio);
        }

        public int SingleSetEnable(int axisIndex, bool enable, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err)
        {
            if (!Enable || EleRunStat != EleRunState.Running || !Axises.ContainsKey(axisIndex)) return -1;

            return Axises[axisIndex].ServoEnable(task, enable, eleLevel);
        }

        public int SingleSetEnable(string axisName, bool enable, ITask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Err)
        {
            return SingleSetEnable(FindAxisIndex(axisName), enable, task, eleLevel);
        }

        public int SingleSetFeedbackToPosition(int axisIndex)
        {
            if (!Enable || EleRunStat != EleRunState.Running || !Axises.ContainsKey(axisIndex)) return -1;

            return Axises[axisIndex].SetFeedbackToPostion();
        }

        public int SingleSetPosition(int axisIndex, double pos)
        {
            if (!Enable || EleRunStat != EleRunState.Running || !Axises.ContainsKey(axisIndex)) return -1;

            return Axises[axisIndex].SetPosition(pos);
        }

        public int SingleSetVel(int axisIndex, double startVel, double maxVel, double endVel, double acc, double dec)
        {
            if (!Enable || EleRunStat != EleRunState.Running || !Axises.ContainsKey(axisIndex)) return -1;

            return Axises[axisIndex].SetVel(startVel * Axises[axisIndex].GearRatio,
                maxVel * Axises[axisIndex].GearRatio, endVel * Axises[axisIndex].GearRatio,
                acc * Axises[axisIndex].GearRatio, dec * Axises[axisIndex].GearRatio);
        }

        public int SingleSetVel(int axisIndex, double startVel, double maxVel, double endVel)
        {
            if (!Enable || EleRunStat != EleRunState.Running || !Axises.ContainsKey(axisIndex)) return -1;

            return Axises[axisIndex].SetVel(startVel, maxVel, endVel);
        }

        public int SingleStop(int axisIndex)
        {
            if (!Enable || EleRunStat != EleRunState.Running || !Axises.ContainsKey(axisIndex) || !Axises[axisIndex].Enable || Axises[axisIndex].IsAlarm)
                return -1;

            return Axises[axisIndex].StopMove();
        }

        public int SingleStop(string axisName)
        {
            if (!Enable || EleRunStat != EleRunState.Running || AxisNum <= 0) return -1;

            var axis = Axises.FirstOrDefault(p => p.Value.Name == axisName);

            return Axises[axis.Key].StopMove();
        }
        #endregion

        #region Other
        public bool IsStop
        {
            get
            {
                return Axises.Values.ToList().All(p => p.IsStop && p.SignalInp);
            }
        }

        public int AxisHasAlarm(bool elEnable = true)
        {
            foreach (var axis in Axises)
                if (axis.Value.IsAlarm || !axis.Value.Enable || elEnable &&
                    (axis.Value.InPel || axis.Value.InMel || axis.Value.InSPel || axis.Value.InSMel))
                    return axis.Key;

            return 0;
        }

        public bool AxisInLocation(int axisIndex, string posName)
        {
            var posIndex = Points.GroupPoints.FirstOrDefault(p => p.Value.Name == posName);
            return AxisInLocation(axisIndex, posIndex.Key);
        }

        public bool AxisInLocation(int axisIndex, int posIndex)
        {
            if (AxisNum <= 0 || !Axises.ContainsKey(axisIndex) || Points.GroupPoints.IsEmpty || posIndex < 0 ||
                AxisNum != Points.GroupPoints[posIndex].Pos.Length) return false;

            return AxisInLocation(axisIndex, Points.GroupPoints[posIndex].Pos[axisIndex]);
        }

        public bool AxisInLocation(int axisIndex, double pos)
        {
            if (!Enable || EleRunStat != EleRunState.Running || AxisNum <= 0 || !Axises.ContainsKey(axisIndex) ||
                !Axises[axisIndex].Enable) return false;

            return Axises[axisIndex].InLocation(pos);
        }

        public bool AxisInLocation(string axisName, string posName)
        {
            var axis = Axises.FirstOrDefault(p => p.Value.Name == axisName);
            if (!Axises.ContainsKey(axis.Key) || !axis.Value.Enable) return false;

            return AxisInLocation(axis.Key, posName);
        }

        public bool AxisInLocation(string axisName, int posIndex)
        {
            var axis = Axises.FirstOrDefault(p => p.Value.Name == axisName);

            return AxisInLocation(axis.Key, posIndex);
        }

        public bool AxisInLocation(string axisName, double pos)
        {
            var axis = Axises.FirstOrDefault(p => p.Value.Name == axisName);

            return AxisInLocation(axis.Key, pos);
        }

        public List<Pos> CartDebugUi_GetPosList(Guid id)
        {
            var manualUi = _dicManualUis.FirstOrDefault(p => p.Key == id);
            return ((ManualUI)manualUi.Value).GetPosList();
        }

        public Pos GetActualPos()
        {
            var pos = new Pos();
            if (AxisXIndex != -1) pos.X = Axises[AxisXIndex].ActualPos;
            if (AxisYIndex != -1) pos.Y = Axises[AxisYIndex].ActualPos;
            if (AxisZIndex != -1) pos.Z = Axises[AxisZIndex].ActualPos;
            if (AxisUIndex != -1) pos.U = Axises[AxisUIndex].ActualPos;
            if (AxisVIndex != -1) pos.V = Axises[AxisVIndex].ActualPos;
            if (AxisWIndex != -1) pos.W = Axises[AxisWIndex].ActualPos;

            return pos;
        }

        public IEleAxis GetAxisByGId(string gid)
        {
            foreach (var axis in Axises)
                if (axis.Value.Gid == gid)
                    return axis.Value;

            return null;
        }

        public IEleAxis GetAxisById(IPrim prim, int id)
        {
            foreach (var axis in Axises)
                if (axis.Value.DevName == prim.Name && axis.Value.Id == id)
                    return axis.Value;

            return null;
        }

        public IEleAxis GetAxisByIndex(int index)
        {
            foreach (var axis in Axises)
                if (axis.Key == index)
                    return axis.Value;

            return null;
        }

        public IEleAxis GetAxisByName(string name)
        {
            foreach (var axis in Axises)
                if (axis.Value.Name == name)
                    return axis.Value;

            return null;
        }

        public int GetPosByIndex(int index, out Pos position)
        {
            var pos = Points.MotionPoints.FirstOrDefault(p => p.Index == index);
            if (pos == default(PosMotion))
            {
                position = new Pos();
                return -1;
            }

            position = new Pos
            {
                Name = pos.Name,
                X = pos.X,
                Y = pos.Y,
                Z = pos.Z,
                U = pos.U,
                V = pos.V,
                W = pos.W
            };

            return 0;
        }

        public int GetPosByName(string name, out Pos position)
        {
            var pos = Points.GroupPoints.FirstOrDefault(p => p.Value.Name == name);
            if (pos.Value == null)
            {
                position = null;
                return -1;
            }

            position = new Pos();
            position.Name = pos.Value.Name;
            if (AxisXIndex != -1 && AxisXIndex < pos.Value.Pos.Length)
            {
                position.X = pos.Value.Pos[AxisXIndex];
            }
            if (AxisYIndex != -1 && AxisYIndex < pos.Value.Pos.Length)
            {
                position.Y = pos.Value.Pos[AxisYIndex];
            }
            if (AxisZIndex != -1 && AxisZIndex < pos.Value.Pos.Length)
            {
                position.Z = pos.Value.Pos[AxisZIndex];
            }
            if (AxisUIndex != -1 && AxisUIndex < pos.Value.Pos.Length)
            {
                position.U = pos.Value.Pos[AxisUIndex];
            }
            if (AxisVIndex != -1 && AxisVIndex < pos.Value.Pos.Length)
            {
                position.V = pos.Value.Pos[AxisVIndex];
            }
            if (AxisWIndex != -1 && AxisWIndex < pos.Value.Pos.Length)
            {
                position.W = pos.Value.Pos[AxisWIndex];
            }
            return 0;
        }

        public int GetPosByName(string name, out double[] position)
        {
            var pos = Points.GroupPoints.FirstOrDefault(p => p.Value.Name == name);
            if (pos.Value == null)
            {
                position = null;
                return -1;
            }
            position = pos.Value.Pos;
            return 0;
        }

        public bool InLocation(string posName)
        {
            if (!Enable || EleRunStat != EleRunState.Running || AxisNum <= 0 || Points.GroupPoints.IsEmpty)
                return false;

            var pos = Points.GroupPoints.FirstOrDefault(p => p.Value.Name == posName);
            if (pos.Key == -1 || AxisNum != Points.GroupPoints[pos.Key].Pos.Length) return false;

            return InLocation(pos.Value.Pos);
        }

        public bool InLocation(int posIndex)
        {
            if (!Enable || EleRunStat != EleRunState.Running || AxisNum <= 0 || Points.GroupPoints.IsEmpty)
                return false;

            if (posIndex < 0 || AxisNum != Points.GroupPoints[posIndex].Pos.Length) return false;

            return InLocation(Points.GroupPoints[posIndex].Pos);
        }

        public bool InLocation(double[] pos)
        {
            if (!Enable || EleRunStat != EleRunState.Running || AxisNum <= 0 || pos.Length != AxisNum) return false;

            for (var i = 0; i < AxisNum; i++)
                if (!Axises[i].InLocation(pos[i]))
                    return false;

            return true;
        }

        public bool InLocation(double[] pos, double[] errChk)
        {
            if (!Enable || EleRunStat != EleRunState.Running || AxisNum <= 0 || pos.Length != AxisNum) return false;

            for (var i = 0; i < AxisNum; i++)
                if (!Axises[i].InLocation(pos[i], errChk[i]))
                    return false;

            return true;
        }

        public bool InLocation(Pos pos, Pos errChkPos)
        {
            if (!Enable || EleRunStat != EleRunState.Running || AxisNum <= 0) return false;

            if (AxisXIndex != -1 && !_axises[AxisXIndex].InLocation(pos.X, errChkPos.X)) return false;

            if (AxisYIndex != -1 && !_axises[AxisYIndex].InLocation(pos.Y, errChkPos.Y)) return false;

            if (AxisZIndex != -1 && !_axises[AxisZIndex].InLocation(pos.Z, errChkPos.Z)) return false;

            if (AxisUIndex != -1 && !_axises[AxisUIndex].InLocation(pos.U, errChkPos.U)) return false;

            if (AxisVIndex != -1 && !_axises[AxisVIndex].InLocation(pos.V, errChkPos.V)) return false;

            if (AxisWIndex != -1 && !_axises[AxisWIndex].InLocation(pos.W, errChkPos.W)) return false;

            return true;
        }

        public bool InLocation(Pos pos)
        {
            if (!Enable || EleRunStat != EleRunState.Running || AxisNum <= 0)
            {
                return false;
            }

            if (AxisXIndex != -1 && !_axises[AxisXIndex].InLocation(pos.X))
            {
                return false;
            }

            if (AxisYIndex != -1 && !_axises[AxisYIndex].InLocation(pos.Y))
            {
                return false;
            }

            if (AxisZIndex != -1 && !_axises[AxisZIndex].InLocation(pos.Z))
            {
                return false;
            }

            if (AxisUIndex != -1 && !_axises[AxisUIndex].InLocation(pos.U))
            {
                return false;
            }

            if (AxisVIndex != -1 && !_axises[AxisVIndex].InLocation(pos.V))
            {
                return false;
            }

            if (AxisWIndex != -1 && !_axises[AxisWIndex].InLocation(pos.W))
            {
                return false;
            }

            return true;
        }

        public bool InLocation(double[] pos, int[] axisIndex)
        {
            if (!Enable || EleRunStat != EleRunState.Running || axisIndex.Length != 6)
            {
                return false;
            }

            for (int i = 0; i < axisIndex.Length; i++)
            {
                if (axisIndex[i] != -1)
                {
                    int index = axisIndex[i];
                    if (!_axises[index].InLocation(pos[i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool InLocation(Pos pos, int multipleValue)
        {
            if (!Enable || EleRunStat != EleRunState.Running || AxisNum <= 0) return false;

            if (AxisXIndex != -1 &&
                !_axises[AxisXIndex].InLocation(pos.X, _axises[AxisXIndex].ErrChkRange * multipleValue)) return false;

            if (AxisYIndex != -1 &&
                !_axises[AxisYIndex].InLocation(pos.Y, _axises[AxisYIndex].ErrChkRange * multipleValue)) return false;

            if (AxisZIndex != -1 &&
                !_axises[AxisZIndex].InLocation(pos.Z, _axises[AxisZIndex].ErrChkRange * multipleValue)) return false;

            if (AxisUIndex != -1 &&
                !_axises[AxisUIndex].InLocation(pos.U, _axises[AxisUIndex].ErrChkRange * multipleValue)) return false;

            if (AxisVIndex != -1 &&
                !_axises[AxisVIndex].InLocation(pos.V, _axises[AxisVIndex].ErrChkRange * multipleValue)) return false;

            if (AxisWIndex != -1 &&
                !_axises[AxisWIndex].InLocation(pos.W, _axises[AxisWIndex].ErrChkRange * multipleValue)) return false;

            return true;
        }

        public Control NewCartDebugUi(Guid id, IEleCartesian ele, List<Pos> poslist, bool timerEnable = false)
        {
            var manualUi = new ManualUI(ele, poslist, timerEnable, ManualEnable);
            _dicManualUis.Add(id, manualUi);
            return manualUi;
        }

        public double[] PosToArray(Pos pos)
        {
            if (AxisNum <= 0) return null;

            var newPos = new double[AxisNum];
            if (AxisXIndex != -1) newPos[AxisXIndex] = pos.X;
            if (AxisYIndex != -1) newPos[AxisYIndex] = pos.Y;
            if (AxisZIndex != -1) newPos[AxisZIndex] = pos.Z;
            if (AxisUIndex != -1) newPos[AxisUIndex] = pos.U;
            if (AxisVIndex != -1) newPos[AxisVIndex] = pos.V;
            if (AxisWIndex != -1) newPos[AxisWIndex] = pos.W;

            return newPos;
        }

        public double[] PosToGearRatioArray(Pos pos)
        {
            if (AxisNum <= 0) return null;

            var newPos = new double[AxisNum];
            if (AxisXIndex != -1) newPos[AxisXIndex] = pos.X * Axises[AxisXIndex].GearRatio;
            if (AxisYIndex != -1) newPos[AxisYIndex] = pos.Y * Axises[AxisYIndex].GearRatio;
            if (AxisZIndex != -1) newPos[AxisZIndex] = pos.Z * Axises[AxisZIndex].GearRatio;
            if (AxisUIndex != -1) newPos[AxisUIndex] = pos.U * Axises[AxisUIndex].GearRatio;
            if (AxisVIndex != -1) newPos[AxisVIndex] = pos.V * Axises[AxisVIndex].GearRatio;
            if (AxisWIndex != -1) newPos[AxisWIndex] = pos.W * Axises[AxisWIndex].GearRatio;

            return newPos;
        }

        public void RefreshDebugUi()
        {
            ((DebugUI)EleDebugUI)?.UiRefresh();
        }

        public int[] ReturnAxisesId()
        {
            if (AxisNum <= 0) return null;

            var newIds = new int[AxisNum];
            if (AxisXIndex != -1) newIds[AxisXIndex] = Axises[AxisXIndex].Id;
            if (AxisYIndex != -1) newIds[AxisYIndex] = Axises[AxisYIndex].Id;
            if (AxisZIndex != -1) newIds[AxisZIndex] = Axises[AxisZIndex].Id;
            if (AxisUIndex != -1) newIds[AxisUIndex] = Axises[AxisUIndex].Id;
            if (AxisVIndex != -1) newIds[AxisVIndex] = Axises[AxisVIndex].Id;
            if (AxisWIndex != -1) newIds[AxisWIndex] = Axises[AxisWIndex].Id;

            return newIds;
        }

        /// <summary>点位更新（点位存在情况下）</summary>
        /// <param name="oldPos">更新点位</param>
        /// <returns></returns>
        public Pos UpdatePos(Pos oldPos)
        {
            if (AxisXIndex != -1) oldPos.X = Axises[AxisXIndex].ActualPos;
            if (AxisYIndex != -1) oldPos.Y = Axises[AxisYIndex].ActualPos;
            if (AxisZIndex != -1) oldPos.Z = Axises[AxisZIndex].ActualPos;
            if (AxisUIndex != -1) oldPos.U = Axises[AxisUIndex].ActualPos;
            if (AxisVIndex != -1) oldPos.V = Axises[AxisVIndex].ActualPos;
            if (AxisWIndex != -1) oldPos.W = Axises[AxisWIndex].ActualPos;

            return oldPos;
        }

        public double SafetyAxisDefaultHeight
        {
            set
            {
                _config.SafetyAxisDefaultHeight = value;
            }
            get
            {
                return _config.SafetyAxisDefaultHeight;
            }
        }
        #endregion

        #region StationTask
        public ITask CurTask { get => _isTaskMode ? _curTask : null; set => _curTask = value; }
        public bool AssertAutoMode(ITask task)
        {
            if (!_isTaskMode)
            {
                task.Log($"{Info} not in Auto Mode", LogLevel.Error, task.Idx + 300);
                return false;
            }

            return true;
        }
        public IEle EnterTask(ITask task = null)
        {
            if (task != null) _curTask = task;

            _isTaskMode = true;
            return this;
        }
        public IEle ExitTask()
        {
            _isTaskMode = false;
            return this;
        }
        #endregion
        #endregion



        #region Method_ExternalUsing
        /// <summary>基元类型切换时发生响应</summary>
        /// <param name="updatedAxis">轴接口</param>
        public void UpdateAxisByType(IEleAxis updatedAxis)
        {
            var updated = _axises.FirstOrDefault(p => p.Value.Gid == updatedAxis.Gid);
            var index = updated.Key;
            _axises.TryRemove(index, out var removedAxis);
            IEleAxis newAxis;
            switch (updatedAxis.DeviceType)
            {
                case ByType.MotionCard:
                case ByType.Robot:
                case ByType.PLC:
                case ByType.Other:
                default:
                    newAxis = new EleAxisByCard.EleAxisByCard(removedAxis.Name, removedAxis.Id, VelMode);
                    break;
            }

            _axises.TryAdd(index, newAxis);
        }
        /// <summary>本地加载轴组轴集合/寻找轴控制基元/更新轴组名称</summary>
        /// <returns></returns>
        public int ImportAxisesConfigFromPath()
        {
            if (string.IsNullOrEmpty(AxisesConfigPath))
            {
                LogAdd($"轴组 {Name} 配置目录为空", LogLevel.Warn);
                return (int)SoftWareAlarm.EleCartesian_轴组配置目录为空;
            }


            if (!File.Exists(AxisesConfigPath))
            {
                LogAdd($"轴组 {Name} 配置目录不存在", LogLevel.Warn);
                return (int)SoftWareAlarm.EleCartesian_轴组配置目录不存在;
            }

            _axises.Clear();
            _axises = JsonHelper.DeserializeJsonFileToObjectByInterface<ConcurrentDictionary<int, IEleAxis>>(AxisesConfigPath, "1.0");

            if (_axises == null || _axises.Count <= 0)
            {
                LogAdd($"轴组 {Name} 轴总数为0", LogLevel.Trace);
                return 0;
            }

            FindPrim();

            //更新轴组名称
            if (_axises.Count > 0)
            {
                _axises.Values.ToList().ForEach(a => a.UpdateCartesianName(Name));
            }
            return 0;
        }
        /// <summary>本地加载点位列表</summary>
        /// <returns></returns>
        public int ImportPointsFromPath()
        {
            if (string.IsNullOrEmpty(PointsPath))
            {
                return (int)SoftWareAlarm.EleCartesian_轴组点位目录为空;
            }

            if (!File.Exists(PointsPath))
            {
                return (int)SoftWareAlarm.EleCartesian_轴组点位目录不存在;
            }

            Points = JsonHelper.DeserializeJsonFileToObject<CartesianPoints>(PointsPath);

            if (Points == null)
            {
                LogAdd($"轴组 {Name} 点位集合为空", LogLevel.Trace);
                return 0;
            }

            GroupToMotion();
            return 0;
        }
        /// <summary>增加轴至DebugUi</summary>
        /// <param name="axis"></param>
        /// <param name="num"></param>
        internal void AddAxisToDebugUi(IEleAxis axis, int num)
        {
            ((DebugUI)EleDebugUI).AddAxis(axis, num);
        }
        /// <summary>移除轴至DebugUi</summary>
        /// <param name="axis"></param>
        /// <param name="num"></param>
        internal void RemoveAxisToDebugUi(IEleAxis axis, int num)
        {
            ((DebugUI)EleDebugUI).RemoveAxis(axis, num);
        }
        internal void RefreshAxisesInDebugUi()
        {
            ((DebugUI)EleDebugUI).RefreshAxises();
        }
        internal void ClearAxisesInDebugUi()
        {
            ((DebugUI)EleDebugUI).ClearAxises();
        }
        /// <summary>日志</summary>
        /// <param name="log">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        public void LogAdd(string log, LogLevel lv, long id = 0)
        {
            if (!LogEnable) return;

            string tempId = $"{(int)lv}{(int)PrimLogId.EleCartesian}0000";

            if (long.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            ProxyTools.LogHelper.LogAdd(lv, log, Name, LogClassification.Elements, id);

            EleAlarmLv = lv;
            //if(lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn)
            //{
            //    EleRunStat = EleRunState.Err;
            //}
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>轴寻找控制基元</summary>
        /// <returns>int</returns>
        private int FindPrim()
        {
            if (Axises.Any(axis => axis.Value.FindPrim() != 0)) return -1;
            return 0;
        }
        public int GroupToMotion()
        {
            if (Points.GroupPoints.IsEmpty || AxisNum <= 0) return -1;

            Points.MotionPoints.Clear();
            try
            {
                foreach (var point in Points.GroupPoints)
                {
                    var newMotionPoint = new PosMotion { Name = point.Value.Name, Index = point.Value.Index };
                    if (AxisXIndex != -1 || AxisXIndex >= point.Value.Pos.Length)
                        newMotionPoint.X = point.Value.Pos[AxisXIndex];
                    else
                        newMotionPoint.X = 0;
                    if (AxisYIndex != -1 || AxisYIndex >= point.Value.Pos.Length)
                        newMotionPoint.Y = point.Value.Pos[AxisYIndex];
                    else
                        newMotionPoint.Y = 0;
                    if (AxisZIndex != -1 || AxisZIndex >= point.Value.Pos.Length)
                        newMotionPoint.Z = point.Value.Pos[AxisZIndex];
                    else
                        newMotionPoint.Z = 0;
                    if (AxisUIndex != -1 || AxisUIndex >= point.Value.Pos.Length)
                        newMotionPoint.U = point.Value.Pos[AxisUIndex];
                    else
                        newMotionPoint.U = 0;
                    if (AxisVIndex != -1 || AxisVIndex >= point.Value.Pos.Length)
                        newMotionPoint.V = point.Value.Pos[AxisVIndex];
                    else
                        newMotionPoint.V = 0;
                    if (AxisWIndex != -1 || AxisWIndex >= point.Value.Pos.Length)
                        newMotionPoint.W = point.Value.Pos[AxisWIndex];
                    else
                        newMotionPoint.W = 0;
                    Points.MotionPoints.Add(newMotionPoint);
                }
            }
            catch
            {
                MessageBox.Show($@"{Info} 轴组成员数量发生变更，原有的点位列表需重新配置，请先清除点位列表，再行配置。");
            }


            return 0;
        }
        private int FindAxisIndex(string axisName)
        {
            var axis = Axises.FirstOrDefault(p => p.Value.Name == axisName);
            if (axis.Value == default(IEleAxis)) return -1;

            return axis.Key;
        }
        private int GroupMoveErrorHappen(IEleAxis[] axis)
        {
            if (axis == null) return -1;

            if (axis.Any(p => p.ActualPos - p.CmdPos > PosLimit)) return -100;

            if (axis.Any(p => p.CmdPos - p.ActualPos > PosLimit)) return -200;

            return 0;
        }
        private int GroupStopMove(IEleAxis[] axis)
        {
            return axis.All(p => p.StopMove() == 0) ? 0 : -1;
        }
        private int SingleMoveErrorHappen(IEleAxis axis)
        {
            if (axis == null) return -1;

            if (axis.ActualPos - axis.CmdPos > PosLimit) return -100;

            if (axis.CmdPos - axis.ActualPos > PosLimit) return -200;

            return 0;
        }
        /// <summary>轴及轴ID加载</summary>
        /// <returns>int</returns>
        public int LoadAxisIndex()
        {
            AxisXIndex = -1;
            AxisYIndex = -1;
            AxisZIndex = -1;
            AxisUIndex = -1;
            AxisVIndex = -1;
            AxisWIndex = -1;

            X = null;
            Y = null;
            Z = null;
            U = null;
            V = null;
            W = null;

            if (AxisNum <= 0)
            {
                return -1;
            }

            foreach (var axis in _axises)
            {
                string axisName = axis.Value.Name.ToLower();
                if (axisName.Contains("_x"))
                {
                    X = axis.Value;
                    AxisXIndex = axis.Key;
                    AxisIndex[0] = axis.Key;
                }
                else if (axisName.Contains("_y"))
                {
                    Y = axis.Value;
                    AxisYIndex = axis.Key;
                    AxisIndex[1] = axis.Key;
                }
                else if (axisName.Contains("_z"))
                {
                    Z = axis.Value;
                    AxisZIndex = axis.Key;
                    AxisIndex[2] = axis.Key;
                }
                else if (axisName.Contains("_u"))
                {
                    U = axis.Value;
                    AxisUIndex = axis.Key;
                    AxisIndex[3] = axis.Key;
                }
                else if (axisName.Contains("_v"))
                {
                    V = axis.Value;
                    AxisVIndex = axis.Key;
                    AxisIndex[4] = axis.Key;
                }
                else if (axisName.Contains("_w"))
                {
                    W = axis.Value;
                    AxisWIndex = axis.Key;
                    AxisIndex[5] = axis.Key;
                }
            }

            return 0;
        }
        public int MotionToGroup()
        {
            if (Points.MotionPoints.Count <= 0 || AxisNum <= 0) return -1;

            Points.GroupPoints.Clear();

            foreach (var point in Points.MotionPoints)
            {
                var newGroupPoint = new PosCartesian
                { Index = point.Index, Name = point.Name, Pos = new double[AxisNum] };
                if (AxisXIndex != -1) newGroupPoint.Pos[AxisXIndex] = point.X;
                if (AxisYIndex != -1) newGroupPoint.Pos[AxisYIndex] = point.Y;
                if (AxisZIndex != -1) newGroupPoint.Pos[AxisZIndex] = point.Z;
                if (AxisUIndex != -1) newGroupPoint.Pos[AxisUIndex] = point.U;
                if (AxisVIndex != -1) newGroupPoint.Pos[AxisVIndex] = point.V;
                if (AxisWIndex != -1) newGroupPoint.Pos[AxisWIndex] = point.W;

                Points.GroupPoints.TryAdd(newGroupPoint.Index, newGroupPoint);
            }

            return 0;
        }
        /// <summary>元件运行状态设置</summary>
        /// <param name="run">元件运行状态</param>
        public void SetRunState(EleRunState run)
        {
            ((ConfigUI)EleConfigUI)?.SetEleRunState(run);
            ((DebugUI)EleDebugUI)?.SetEleRunState(run);
        }
        /// <summary>EleCartesian运行前基本检查</summary>
        /// <param name="task">任务</param>
        /// <returns>0：OK；非0：错误代码</returns>
        private int EleCartesianSafeCheck(ITask task = null)
        {
            if (!Enable)
            {
                task?.Log($"轴组{Name}未启用", LogLevel.Warn);
                return (int)SoftWareAlarm.EleCartesian_未启用;
            }

            if (EleRunStat != EleRunState.Running)
            {
                task?.Log($"轴组{Name}不在运行状态", LogLevel.Warn);
                return (int)SoftWareAlarm.EleCartesian_元件不在运行状态;
            }

            if (AxisNum <= 0)
            {
                task.Log($"轴组{Name}轴总数为0", LogLevel.Warn);
                return (int)SoftWareAlarm.EleCartesian_轴总数为0;
            }

            return 0;
        }
        private bool InLocationExceptZ(string posName)
        {
            if (!Enable || EleRunStat != EleRunState.Running || AxisNum <= 0 || Points.GroupPoints.IsEmpty)
                return false;

            var posIndex = Points.GroupPoints.FirstOrDefault(p => p.Value.Name == posName);
            if (posIndex.Key == -1 || AxisNum != Points.GroupPoints[posIndex.Key].Pos.Length) return false;

            for (var i = 0; i < AxisNum; i++)
            {
                if (i == AxisZIndex) continue;
                if (Axises[i].ActualPos > Points.GroupPoints[posIndex.Key].Pos[i] + Axises[i].ErrChkRange ||
                    Axises[i].ActualPos < Points.GroupPoints[posIndex.Key].Pos[i] - Axises[i].ErrChkRange) return false;
            }

            return true;
        }
        private bool InLocationExceptZ(int posIndex)
        {
            if (!Enable || EleRunStat != EleRunState.Running || AxisNum <= 0 || Points.GroupPoints.IsEmpty)
                return false;

            if (posIndex < 0 || AxisNum != Points.GroupPoints[posIndex].Pos.Length) return false;

            for (var i = 0; i < AxisNum; i++)
            {
                if (i == AxisZIndex) continue;
                if (Axises[i].ActualPos > Points.GroupPoints[posIndex].Pos[i] + Axises[i].ErrChkRange ||
                    Axises[i].ActualPos < Points.GroupPoints[posIndex].Pos[i] - Axises[i].ErrChkRange) return false;
            }

            return true;
        }
        private bool InLocationExceptZ(double[] pos)
        {
            if (!Enable || EleRunStat != EleRunState.Running || AxisNum <= 0 || pos.Length != AxisNum) return false;

            for (var i = 0; i < AxisNum; i++)
            {
                if (i == AxisZIndex) continue;
                if (Axises[i].ActualPos > pos[i] + Axises[i].ErrChkRange ||
                    Axises[i].ActualPos < pos[i] - Axises[i].ErrChkRange) return false;
            }

            return true;
        }
        private bool InLocationExceptZ(Pos pos)
        {
            if (!Enable || EleRunStat != EleRunState.Running || AxisNum <= 0) return false;

            if (AxisXIndex != -1 && (Axises[AxisXIndex].ActualPos > pos.X + Axises[AxisXIndex].ErrChkRange ||
                                     Axises[AxisXIndex].ActualPos < pos.X - Axises[AxisXIndex].ErrChkRange))
                return false;

            if (AxisYIndex != -1 && (Axises[AxisYIndex].ActualPos > pos.Y + Axises[AxisYIndex].ErrChkRange ||
                                     Axises[AxisYIndex].ActualPos < pos.Y - Axises[AxisYIndex].ErrChkRange))
                return false;

            if (AxisUIndex != -1 && (Axises[AxisUIndex].ActualPos > pos.U + Axises[AxisUIndex].ErrChkRange ||
                                     Axises[AxisUIndex].ActualPos < pos.U - Axises[AxisUIndex].ErrChkRange))
                return false;

            if (AxisVIndex != -1 && (Axises[AxisVIndex].ActualPos > pos.V + Axises[AxisVIndex].ErrChkRange ||
                                     Axises[AxisVIndex].ActualPos < pos.V - Axises[AxisVIndex].ErrChkRange))
                return false;

            if (AxisWIndex != -1 && (Axises[AxisWIndex].ActualPos > pos.W + Axises[AxisWIndex].ErrChkRange ||
                                     Axises[AxisWIndex].ActualPos < pos.W - Axises[AxisWIndex].ErrChkRange))
                return false;

            return true;
        }
        public int ExportAxisesConfigToPath(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return -1;

            return JsonHelper.SerializeObjectToFileByInterface(_axises, filePath) ? 0 : -2;
        }
        public int ExportPointsToPath()
        {
            if (string.IsNullOrEmpty(PointsPath)) return -1;

            return JsonHelper.SerializeObjectToFile(Points, PointsPath) ? 0 : -2;
        }

        public int ExportPointsToPath(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return -1;

            return JsonHelper.SerializeObjectToFile(Points, filePath) ? 0 : -2;
        }

        public int ImportPointsFromPath(string filePath)
        {
            Points.GroupPoints.Clear();
            for (var i = 0; i < Points.SingleAxisPoints.Count; i++) Points.SingleAxisPoints.Clear();

            if (File.Exists(filePath))
                Points = JsonHelper.DeserializeJsonFileToObject<CartesianPoints>(filePath);

            if (Points == null) return -1;

            GroupToMotion();
            return 0;
        }
        internal void UpdateConfigPoints()
        {
            ((ConfigUI)EleConfigUI)?.UpdatePoints();
        }
        internal void UpdateDebugPoints()
        {
            ((DebugUI)EleDebugUI)?.UpdatePoints();
        }
        /// <summary>返回是否为手动状态</summary>
        /// <returns>true：手动；false：自动</returns>
        internal bool CheckManualEnable()
        {
            if (!ManualEnable)
            {
                Notification.ShowWarn("禁止操作，请先切换至手动！！！");
            }
            return ManualEnable;
        }
        #endregion Others
    }
}