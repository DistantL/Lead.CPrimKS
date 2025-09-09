using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.LocalizationService;
using Lead.CPrim.LogHelper;
using Lead.CPrim.XmlHelper;
using static System.String;

namespace Lead.CPrim.EleAxisLine
{
    public class EleAxisLine : IEle, IEleAxisLine
    {
        private static object _mutexCycleTask = new object();

        private readonly ConfigUI _eleConfigUI;
        private readonly DebugUI _eleDebugUI;
        private EleAxisLineConfig _config;

        private bool _cycleFlag;
        private bool _isSelected;
        private IMotionCard _motionCard;
        private Thread _taskCycle;
        private ManualResetEvent _trigManualResetEventCycle = new ManualResetEvent(false);

        public EleAxisLine()
        {
            _eleDebugUI = null;
            _isSelected = false;
            DataConfigs.ListAxisDataConfigs = new List<AxisDataConfig>();

            _config = new EleAxisLineConfig();

            if (!IsNullOrEmpty(_config.DataTablePath)) ImportDataTable(_config.DataTablePath);

            EleRunStat = EleRunState.Other;

            _eleConfigUI = new ConfigUI();
            _eleDebugUI = new DebugUI();
            _eleConfigUI.SetEleConfig(this);
            _eleDebugUI.SetEleConfig(this);
        }

        public EleAxisLine(XmlNode xmlNode)
        {
            _eleDebugUI = null;
            _isSelected = false;
            if (xmlNode != null)
                _config = XMLHelper.XMLToObject(xmlNode, typeof(EleAxisLineConfig)) as EleAxisLineConfig;
            else
                return;

            DataConfigs.ListAxisDataConfigs = new List<AxisDataConfig>();

            if (!IsNullOrEmpty(_config.DataTablePath)) ImportDataTable(_config.DataTablePath);

            EleRunStat = EleRunState.Other;

            _eleConfigUI = new ConfigUI();
            _eleDebugUI = new DebugUI();
            _eleConfigUI.SetEleConfig(this);
            _eleDebugUI.SetEleConfig(this);
        }

        public double AxisLead
        {
            get => _config.AxisLead;
            set => _config.AxisLead = value;
        }

        public AxisDataConfigs DataConfigs { get; set; } = new AxisDataConfigs();

        public double PlsPerRoll
        {
            get => _config.PlsPerRoll;
            set => _config.PlsPerRoll = value;
        }

        public event EleOpLog OnEleOpLog;

        public event EleStateChanged OnEleStateChanged;

        public string DevName
        {
            get => _config.DevName;

            set => _config.DevName = value;
        }

        public LogLevel EleAlarmLv { get; set; }

        public Control EleConfigUI => _eleConfigUI;

        public Control EleDebugUI => _eleDebugUI;

        public EleRunState EleRunStat { get; set; }

        public string EleTypeName
        {
            get => _config.EleTypeName;

            set => _config.EleTypeName = value;
        }

        public bool Enable
        {
            get => _config.Enable;

            set => _config.Enable = value;
        }

        public Guid Id
        {
            get => _config.Id;

            set => _config.Id = value;
        }

        public string Info
        {
            get => _config.Info;

            set => _config.Info = value;
        }

        public bool IsSelected
        {
            set
            {
                if (value == _isSelected) return;

                _isSelected = value;
                _eleConfigUI.BackColor = value ? Color.Green : Color.LightGray;
            }
            get => _isSelected;
        }

        public bool IsSimulateMode
        {
            get => _config.IsSimulateMode;

            set
            {
                _config.IsSimulateMode = value;
                _eleConfigUI?.SetSimulateMode(value);
            }
        }

        public bool LogDisplay
        {
            get => _config.LogDisplay;
            set => _config.LogDisplay = value;
        }

        public bool LogEnable
        {
            get => _config.LogEnable;
            set => _config.LogEnable = value;
        }

        public string Name
        {
            get => _config.Name;

            set => _config.Name = value;
        }

        public PrimRunState IEleCheckPrimRunState()
        {
            if (_motionCard == null) return PrimRunState.Other;
            return ((IPrim) _motionCard).PrimRunStat;
        }

        public int IEleDispose()
        {
            try
            {
                IEleStop();
                if (_eleConfigUI != null && !_eleConfigUI.Disposing && !_eleConfigUI.IsDisposed) _eleConfigUI.Dispose();

                if (_eleDebugUI != null && !_eleDebugUI.Disposing && !_eleDebugUI.IsDisposed) _eleDebugUI.Dispose();
                EleRunStat = EleRunState.Other;
                return 0;
            }
            catch (Exception)
            {
                EleRunStat = EleRunState.Other;
                return -1;
            }
        }

        public XmlNode IEleExportConfigXml()
        {
            if (_config == null) return null;

            var node = XMLHelper.ObjectToXML(_config);

            return node;
        }

        public int IEleImportConfigXml(XmlNode xmlNode)
        {
            var iRet = 0;
            if (xmlNode != null)
                _config = XMLHelper.XMLToObject(xmlNode, typeof(EleAxisLineConfig)) as EleAxisLineConfig;
            else
                return -1;

            _eleConfigUI.UpdataEleConfig(_config);
            _eleDebugUI.UpdataEleConfig(_config);

            return iRet;
        }

        public int IEleInit()
        {
            if (!Enable) return 0;

            if (EleRunStat == EleRunState.Running) return 0;

            var prim = PrimsManager.Instance.GetPrimByName(_config.DevName);
            if (prim == null)
            {
                //MessageBox.Show(NLocalizer.GetString("EleAxisLine_EleAxisLine_DeviceWithName", "Device with name: ") + _config.DevName + NLocalizer.GetString("EleAxisLine_EleAxisLine_NotFound", " not found! "));
                EleRunStat = EleRunState.Err;
                _eleConfigUI.SetEleRunState(EleRunStat);
                _eleDebugUI.SetEleRunState(EleRunStat);
                return -1;
            }

            if (_motionCard != prim) _motionCard = (IMotionCard) prim;

            if (_taskCycle == null)
            {
                _cycleFlag = true;
                _taskCycle = new Thread(CycleDo) {IsBackground = true, Priority = ThreadPriority.Normal};
                //_taskCycle.Start();
            }

            if (prim.PrimRunStat == PrimRunState.Running || IsSimulateMode)
            {
                EleRunStat = EleRunState.Running;
                _eleConfigUI.SetEleRunState(EleRunStat);
                _eleDebugUI.SetEleRunState(EleRunStat);

                if (DriveType == AxisType.Step) IsEnable = true;

                if (CheckLimitEnable)
                {
                    //SetElMode(true, true, StopMode.Free, StopMode.Free);
                }

                return 0;
            }

            EleRunStat = EleRunState.Other;
            _eleConfigUI.SetEleRunState(EleRunStat);
            _eleDebugUI.SetEleRunState(EleRunStat);
            return -2;
        }

        public int IEleReset()
        {
            if (EleRunStat != EleRunState.Err) return 0;
            MC_Reset();
            Thread.Sleep(500);
            if (IsAlarm) return -1;

            EleRunStat = EleRunState.Running;
            _eleConfigUI.SetEleRunState(EleRunStat);
            _eleDebugUI.SetEleRunState(EleRunStat);
            return 0;
        }

        /// <exception cref="T:System.Security.SecurityException">调用方没有所要求的权限。</exception>
        public int IEleStop()
        {
            if (_taskCycle != null && _taskCycle.IsAlive)
            {
                _cycleFlag = false;
                Thread.Sleep(20);
                _taskCycle.Abort();
            }

            var st1 = DateTime.Now.Ticks / 10000;
            while (true)
            {
                if (_taskCycle != null && _taskCycle.ThreadState != ThreadState.Aborted &&
                    _taskCycle.ThreadState != ThreadState.Stopped)
                {
                    var end = DateTime.Now.Ticks / 10000;
                    var dt = end - st1;
                    if (dt >= 3000)
                        //MessageBox.Show("Task'init Dispose Timeout !");
                        return -1;
                }
                else
                {
                    break;
                }

                Thread.Sleep(50);
            }

            _taskCycle = null;

            return 0;
        }

        public int IEleUiRefresh()
        {
            try
            {
                var pulse1 = true;
                var pulse2 = true;

                if (CheckLimitEnable && InPel && pulse1)
                {
                    LogAdd(
                        NLocalizer.GetString("EleAxisLine_EleAxisLine_AxisInPositiveLimit", "Axis in positive limit"),
                        LogLevel.Info, 81);
                    pulse1 = false;
                }

                if (!CheckLimitEnable && !InPel) pulse1 = true;
                if (CheckLimitEnable && InMel && pulse2)
                {
                    LogAdd(
                        NLocalizer.GetString("EleAxisLine_EleAxisLine_AxisInNegativeLimit", "Axis in negative limit"),
                        LogLevel.Info, 82);
                    pulse2 = false;
                }

                if (!CheckLimitEnable && !InMel) pulse2 = true;

                _eleConfigUI.UiRefresh1();
                // _eleDebugUI.UiRefresh1();
            }
            catch (Exception ex)
            {
                // ignored
            }

            return 0;
        }

        public AccDecType AccDecType
        {
            get => _config.AccDecType;
            set => _config.AccDecType = value;
        }

        public double ActualPosition => ActualPosPulse / GearRatio;

        public long ActualPosPulse
        {
            get
            {
                if (_motionCard == null) return 0;
                var tempPulse = -1.0;
                _motionCard.GetAxisPosition(_config.AxisNum, ref tempPulse);
                return (long) tempPulse;
            }
            set { }
        }

        public double ActualVelocity => ActualVelPulse / GearRatio;

        public double ActualVelPulse
        {
            get
            {
                if (_motionCard == null) return 0;
                var actualVelPulse = -1.0;
                _motionCard.GetAxisActualVelocity(_config.AxisNum, ref actualVelPulse);
                return actualVelPulse;
            }
        }

        public int AxisNum
        {
            get => _config.AxisNum;
            set => _config.AxisNum = value;
        }

        public int CardNum
        {
            get => _config.CardNum;
            set => _config.CardNum = value;
        }

        public bool CheckLimitEnable
        {
            get => _config.CheckLimitEnable;
            set => _config.CheckLimitEnable = value;
        }

        public double CmdPosition => CmdPosPulse / GearRatio;

        public long CmdPosPulse
        {
            get
            {
                if (_motionCard == null) return 0;
                var cmdPosPulse = -1.0;
                _motionCard.GetAxisCommand(_config.AxisNum, ref cmdPosPulse);
                return (long) cmdPosPulse;
            }
            set { }
        }

        public double CmdVelocity => CmdVelPulse / GearRatio;

        public double CmdVelPulse
        {
            get
            {
                if (_motionCard == null) return 0;
                var cmdVelPulse = -1.0;
                _motionCard.GetAxisCommandVelocity(_config.AxisNum, ref cmdVelPulse);
                return cmdVelPulse;
            }
        }

        public ControlType ControlType
        {
            get => _config.ControlType;
            set => _config.ControlType = value;
        }

        public DefaultParams DefaultParams
        {
            get => _config.DefaultParams;
            set => _config.DefaultParams = value;
        }

        public AxisType DriveType
        {
            get => _config.DriveType;
            set => _config.DriveType = value;
        }

        public FeedBackType EncoderType
        {
            get => _config.EncoderType;
            set => _config.EncoderType = value;
        }

        public int ErrChkRange
        {
            get => _config.ErrChkRange;
            set => _config.ErrChkRange = value;
        }

        public double GearRatio => _config.PlsPerRoll / _config.AxisLead;

        public int HomeMode
        {
            get => _config.HomeMode;
            set => _config.HomeMode = value;
        }

        public double HomeVelocity
        {
            get => _config.HomeVelocity;
            set => _config.HomeVelocity = value;
        }

        public bool InMel => _motionCard != null && _motionCard.AxisInMel(AxisNum);

        public bool InOrigin => _motionCard != null && _motionCard.AxisInOrigin(AxisNum);

        public bool InPel => _motionCard != null && _motionCard.AxisInPel(AxisNum);

        public bool InSMel { get; set; }

        public bool InSPel { get; set; }

        public bool IsAlarm => _motionCard != null && _motionCard.AxisIsAlarm(AxisNum);

        public bool IsEnable
        {
            get
            {
                if (_motionCard == null) return false;
                if (DriveType == AxisType.Step) return !_motionCard.AxisIsEnble(_config.AxisNum);

                return _motionCard.AxisIsEnble(_config.AxisNum);
            }
            set { }
        }

        public bool IsErrChk
        {
            get
            {
                if (ControlType == ControlType.ClosedLoop && IsStop)
                    return ActualPosPulse > CmdPosPulse + _config.ErrChkRange ||
                           ActualPosPulse < CmdPosPulse - _config.ErrChkRange;

                return false;
            }
        }

        public bool IsPause { set; get; }

        public bool IsStop => _motionCard != null && _motionCard.AxisIsStop(AxisNum);

        public double JogDistance
        {
            get => _config.JogDistance;
            set => _config.JogDistance = value;
        }

        public double JogVelocity
        {
            get => _config.JogVelocity;
            set => _config.JogVelocity = value;
        }

        public double LimVelN
        {
            get => _config.LimVelN;
            set => _config.LimVelN = value;
        }

        public double LimVelP
        {
            get => _config.LimVelP;
            set => _config.LimVelP = value;
        }

        public bool SignalEmg => _motionCard != null && _motionCard.AxisSignalEmg(AxisNum);

        public bool SignalEz => _motionCard != null && _motionCard.AxisSignalEz(AxisNum);

        public bool SignalInp => _motionCard != null && _motionCard.AxisSignalInp(AxisNum);

        public double SMel
        {
            get => _config.SwNot;
            set => _config.SwNot = value;
        }

        public double SPel
        {
            get => _config.SwPot;
            set => _config.SwPot = value;
        }

        public int StandByIndex
        {
            get => _config.StandByIndex;
            set => _config.StandByIndex = value;
        }

        public StopMode StopMode
        {
            get => _config.StopMode;
            set => _config.StopMode = value;
        }

        public bool SwLimitEnable
        {
            get => _config.SwLimitEnable;
            set => _config.SwLimitEnable = value;
        }
        public bool ManualEnable { get; set; } = false;
        internal bool CheckManualEnable()
        {
            if (!ManualEnable)
            {
                MessageBox.Show($@"禁止操作！请先切换至手动");
            }
            return ManualEnable;
        }
        public bool InLocation(string PosName)
        {
            AxisDataConfig posData = null;
            foreach (var t in DataConfigs.ListAxisDataConfigs)
                if (string.Equals(t.Name, PosName, StringComparison.CurrentCultureIgnoreCase))
                    posData = t;
            if (Math.Abs(posData.Position - ActualPosition) < 1)
                return true;
            return false;
        }

        public bool InLocation(double pos)
        {
            if (Math.Abs(pos - ActualPosition) < 1)
                return true;
            return false;
        }

        public int MC_ChangeVel(double newVelocity)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (AccDecType == AccDecType.Time)
                return _motionCard.AxisChangeVel(AxisNum, newVelocity * GearRatio);
            return 0;
        }

        public int MC_ChangeVel(double vel, double decTime)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (vel > LimVelP || vel < LimVelN)
            {
                LogAdd(NLocalizer.GetString("EleAxisLine_EleAxisLine_SpeedParameterLimit", "Speed parameter limit."),
                    LogLevel.Error, 211);
                return -211;
            }

            if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisChangeVel(AxisNum, ToPls(vel));
                return 0;
            }

            return 0;
        }

        public int MC_Home()
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            return _motionCard.AxisHomeMove(AxisNum, true);
        }

        public int MC_Home(int homeMode)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            return _motionCard.AxisHomeMove(AxisNum, homeMode, HomeVelocity * GearRatio, HomeVelocity * GearRatio / 5,
                HomeVelocity * GearRatio * 10, 0, true);
        }

        public int MC_Home(int homeMode, float timeOutS)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;
            _motionCard.AxisStopMove(AxisNum);
            Thread.Sleep(100);

            return _motionCard.AxisHomeMove(AxisNum, homeMode, HomeVelocity * GearRatio, HomeVelocity * GearRatio / 5,
                HomeVelocity * GearRatio * 10, 0);
        }

        public int MC_MoveAbsolute(int posIndex)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (DataConfigs?.ListAxisDataConfigs == null || DataConfigs.ListAxisDataConfigs.Count == 0) return -2;

            var posData = DataConfigs.ListAxisDataConfigs[posIndex];

            if (posData == null) return -3;

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetAcc(AxisNum, posData.Acceleration * GearRatio);
                _motionCard.AxisSetDec(AxisNum, posData.Deceleration * GearRatio);
                _motionCard.AxisSetMinVel(AxisNum, posData.MinVelocity * GearRatio);
                _motionCard.AxisSetMaxVel(AxisNum, posData.Velocity * GearRatio);
                _motionCard.AxisSetStopVel(AxisNum, DefaultParams.StopVel * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, posData.MinVelocity * GearRatio, posData.Velocity * GearRatio,
                    posData.AccTime, posData.DecTime, DefaultParams.StopVel * GearRatio);
            }

            return _motionCard.AxisAbsMove(AxisNum, posData.Position * GearRatio, posData.Velocity * GearRatio);
        }

        public int MC_MoveAbsolute(int posIndex, float timeOutS)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (DataConfigs?.ListAxisDataConfigs == null || DataConfigs.ListAxisDataConfigs.Count == 0) return -2;

            var posData = DataConfigs.ListAxisDataConfigs[posIndex];

            if (posData == null) return -3;

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetAcc(AxisNum, posData.Acceleration * GearRatio);
                _motionCard.AxisSetDec(AxisNum, posData.Deceleration * GearRatio);
                _motionCard.AxisSetMinVel(AxisNum, posData.MinVelocity * GearRatio);
                _motionCard.AxisSetMaxVel(AxisNum, posData.Velocity * GearRatio);
                _motionCard.AxisSetStopVel(AxisNum, DefaultParams.StopVel * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, posData.MinVelocity * GearRatio, posData.Velocity * GearRatio,
                    posData.AccTime, posData.DecTime, DefaultParams.StopVel * GearRatio);
            }

            var iRet = _motionCard.AxisAbsMove(AxisNum, posData.Position * GearRatio, posData.Velocity * GearRatio);

            Thread.Sleep(200);
            var err = Format(
                NLocalizer.GetString("EleAxisLine_EleAxisLine_MoveAbsUnsuccess", "{0} MoveAbs unsuccessfully."), Name);
            if (iRet == 0 && MoveWaitDone(false, err, 10, timeOutS) == 0) return 0;
            return -10;
        }

        public int MC_MoveAbsolute(string posName)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (DataConfigs?.ListAxisDataConfigs == null || DataConfigs.ListAxisDataConfigs.Count == 0) return -2;

            AxisDataConfig posData = null;
            foreach (var t in DataConfigs.ListAxisDataConfigs)
                if (string.Equals(t.Name, posName, StringComparison.CurrentCultureIgnoreCase))
                    posData = t;

            if (posData == null) return -3;

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetAcc(AxisNum, posData.Acceleration * GearRatio);
                _motionCard.AxisSetDec(AxisNum, posData.Deceleration * GearRatio);
                _motionCard.AxisSetMinVel(AxisNum, posData.MinVelocity * GearRatio);
                _motionCard.AxisSetMaxVel(AxisNum, posData.Velocity * GearRatio);
                _motionCard.AxisSetStopVel(AxisNum, DefaultParams.StopVel * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, posData.MinVelocity * GearRatio, posData.Velocity * GearRatio,
                    posData.AccTime, posData.DecTime, DefaultParams.StopVel * GearRatio);
            }

            return _motionCard.AxisAbsMove(AxisNum, posData.Position * GearRatio, posData.Velocity * GearRatio);
        }

        public int MC_MoveAbsolute(string posName, float timeOutS)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (DataConfigs?.ListAxisDataConfigs == null || DataConfigs.ListAxisDataConfigs.Count == 0) return -2;

            AxisDataConfig posData = null;
            foreach (var t in DataConfigs.ListAxisDataConfigs)
                if (string.Equals(t.Name, posName, StringComparison.CurrentCultureIgnoreCase))
                    posData = t;

            if (posData == null) return -3;

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetAcc(AxisNum, posData.Acceleration * GearRatio);
                _motionCard.AxisSetDec(AxisNum, posData.Deceleration * GearRatio);
                _motionCard.AxisSetMinVel(AxisNum, posData.MinVelocity * GearRatio);
                _motionCard.AxisSetMaxVel(AxisNum, posData.Velocity * GearRatio);
                _motionCard.AxisSetStopVel(AxisNum, DefaultParams.StopVel * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, posData.MinVelocity * GearRatio, posData.Velocity * GearRatio,
                    posData.AccTime, posData.DecTime, DefaultParams.StopVel * GearRatio);
            }

            var iRet = _motionCard.AxisAbsMove(AxisNum, posData.Position * GearRatio, posData.Velocity * GearRatio);

            Thread.Sleep(200);
            var err = Format(
                NLocalizer.GetString("EleAxisLine_EleAxisLine_MoveAbsUnsuccess", "{0} MoveAbs unsuccessfully."), Name);
            if (iRet == 0 && MoveWaitDone(false, err, 10, timeOutS) == 0) return 0;
            return -10;
        }

        public int MC_MoveAbsolute(double position)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetAcc(AxisNum, DefaultParams.Acceleration * GearRatio);
                _motionCard.AxisSetDec(AxisNum, DefaultParams.Deceleration * GearRatio);
                _motionCard.AxisSetMinVel(AxisNum, DefaultParams.MinVelocity * GearRatio);
                _motionCard.AxisSetMaxVel(AxisNum, DefaultParams.Velocity * GearRatio);
                _motionCard.AxisSetStopVel(AxisNum, DefaultParams.StopVel * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, DefaultParams.MinVelocity * GearRatio,
                    DefaultParams.Velocity * GearRatio,
                    DefaultParams.AccTime, DefaultParams.DecTime, DefaultParams.StopVel * GearRatio);
            }

            return _motionCard.AxisAbsMove(AxisNum, position * GearRatio, DefaultParams.Velocity * GearRatio);
        }

        public int MC_MoveAbsolute(double position, float timeOutS)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetAcc(AxisNum, DefaultParams.Acceleration * GearRatio);
                _motionCard.AxisSetDec(AxisNum, DefaultParams.Deceleration * GearRatio);
                _motionCard.AxisSetMinVel(AxisNum, DefaultParams.MinVelocity * GearRatio);
                _motionCard.AxisSetMaxVel(AxisNum, DefaultParams.Velocity * GearRatio);
                _motionCard.AxisSetStopVel(AxisNum, DefaultParams.StopVel * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, DefaultParams.MinVelocity * GearRatio,
                    DefaultParams.Velocity * GearRatio,
                    DefaultParams.AccTime, DefaultParams.DecTime, DefaultParams.StopVel * GearRatio);
            }

            var iRet = _motionCard.AxisAbsMove(AxisNum, position * GearRatio, DefaultParams.Velocity * GearRatio);

            Thread.Sleep(200);
            var err = Format(
                NLocalizer.GetString("EleAxisLine_EleAxisLine_MoveAbsUnsuccess", "{0} MoveAbs unsuccessfully."), Name);
            if (iRet == 0 && MoveWaitDone(false, err, 10, timeOutS) == 0) return 0;
            return -10;
        }

        public int MC_MoveAbsolute(double position, double velocity)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetAcc(AxisNum, DefaultParams.Acceleration * GearRatio);
                _motionCard.AxisSetDec(AxisNum, DefaultParams.Deceleration * GearRatio);
                _motionCard.AxisSetMinVel(AxisNum, DefaultParams.MinVelocity * GearRatio);
                _motionCard.AxisSetMaxVel(AxisNum, velocity * GearRatio);
                _motionCard.AxisSetStopVel(AxisNum, DefaultParams.StopVel * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, DefaultParams.MinVelocity * GearRatio, velocity * GearRatio,
                    DefaultParams.AccTime, DefaultParams.DecTime, DefaultParams.StopVel * GearRatio);
            }

            return _motionCard.AxisAbsMove(AxisNum, position * GearRatio, velocity * GearRatio);
        }

        public int MC_MoveAbsolute(double position, double velocity, float timeOutS)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetAcc(AxisNum, DefaultParams.Acceleration * GearRatio);
                _motionCard.AxisSetDec(AxisNum, DefaultParams.Deceleration * GearRatio);
                _motionCard.AxisSetMinVel(AxisNum, DefaultParams.MinVelocity * GearRatio);
                _motionCard.AxisSetMaxVel(AxisNum, velocity * GearRatio);
                _motionCard.AxisSetStopVel(AxisNum, DefaultParams.StopVel * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, DefaultParams.MinVelocity * GearRatio, velocity * GearRatio,
                    DefaultParams.AccTime, DefaultParams.DecTime, DefaultParams.StopVel * GearRatio);
            }

            var iRet = _motionCard.AxisAbsMove(AxisNum, position * GearRatio, velocity * GearRatio);

            Thread.Sleep(200);
            var err = Format(
                NLocalizer.GetString("EleAxisLine_EleAxisLine_MoveAbsUnsuccess", "{0} MoveAbs unsuccessfully."), Name);
            if (iRet == 0 && MoveWaitDone(false, err, 10, timeOutS) == 0) return 0;
            return -10;
        }

        public int MC_MoveAbsolute(double position, double velocity, double acceleration, double deceleration)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (velocity > LimVelP || velocity < LimVelN)
            {
                LogAdd(NLocalizer.GetString("EleAxisLine_EleAxisLine_SpeedParameterLimit", "Speed parameter limit."),
                    LogLevel.Error, 211);
                return -211;
            }

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetAcc(AxisNum, acceleration * GearRatio);
                _motionCard.AxisSetDec(AxisNum, deceleration * GearRatio);
                _motionCard.AxisSetMinVel(AxisNum, DefaultParams.MinVelocity * GearRatio);
                _motionCard.AxisSetMaxVel(AxisNum, velocity * GearRatio);
                _motionCard.AxisSetStopVel(AxisNum, DefaultParams.StopVel * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, DefaultParams.MinVelocity * GearRatio, velocity * GearRatio,
                    DefaultParams.AccTime, DefaultParams.DecTime, DefaultParams.StopVel * GearRatio);
            }

            return _motionCard.AxisAbsMove(AxisNum, position * GearRatio, velocity * GearRatio);
        }

        public int MC_MoveAbsolute(double position, double velocity, double acceleration, double deceleration,
            float timeOutS)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (velocity > LimVelP || velocity < LimVelN)
            {
                LogAdd(NLocalizer.GetString("EleAxisLine_EleAxisLine_SpeedParameterLimit", "Speed parameter limit."),
                    LogLevel.Error, 211);
                return -211;
            }

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetAcc(AxisNum, acceleration * GearRatio);
                _motionCard.AxisSetDec(AxisNum, deceleration * GearRatio);
                _motionCard.AxisSetMinVel(AxisNum, DefaultParams.MinVelocity * GearRatio);
                _motionCard.AxisSetMaxVel(AxisNum, velocity * GearRatio);
                _motionCard.AxisSetStopVel(AxisNum, DefaultParams.StopVel * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, DefaultParams.MinVelocity * GearRatio, velocity * GearRatio,
                    DefaultParams.AccTime, DefaultParams.DecTime, DefaultParams.StopVel * GearRatio);
            }

            var iRet = _motionCard.AxisAbsMove(AxisNum, position * GearRatio, velocity * GearRatio);

            Thread.Sleep(200);
            var err = Format(
                NLocalizer.GetString("EleAxisLine_EleAxisLine_MoveAbsUnsuccess", "{0} MoveAbs unsuccessfully."), Name);
            if (iRet == 0 && MoveWaitDone(false, err, 10, timeOutS) == 0) return 0;
            return -10;
        }

        public int MC_MoveAbsolute(double position, double velocity, double minVelocity, double accTime, double decTime)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetAcc(AxisNum, DefaultParams.Acceleration * GearRatio);
                _motionCard.AxisSetDec(AxisNum, DefaultParams.Deceleration * GearRatio);
                _motionCard.AxisSetMinVel(AxisNum, minVelocity * GearRatio);
                _motionCard.AxisSetMaxVel(AxisNum, velocity * GearRatio);
                _motionCard.AxisSetStopVel(AxisNum, DefaultParams.StopVel * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, minVelocity * GearRatio, velocity * GearRatio,
                    accTime, decTime, DefaultParams.StopVel * GearRatio);
            }

            return _motionCard.AxisAbsMove(AxisNum, position * GearRatio, velocity * GearRatio);
        }

        public int MC_MoveAbsolute(double position, double velocity, double minVelocity, double accTime, double decTime,
            float timeOutS)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetAcc(AxisNum, DefaultParams.Acceleration * GearRatio);
                _motionCard.AxisSetDec(AxisNum, DefaultParams.Deceleration * GearRatio);
                _motionCard.AxisSetMinVel(AxisNum, minVelocity * GearRatio);
                _motionCard.AxisSetMaxVel(AxisNum, velocity * GearRatio);
                _motionCard.AxisSetStopVel(AxisNum, DefaultParams.StopVel * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, minVelocity * GearRatio, velocity * GearRatio,
                    accTime, decTime, DefaultParams.StopVel * GearRatio);
            }

            var iRet = _motionCard.AxisAbsMove(AxisNum, position * GearRatio, velocity * GearRatio);

            Thread.Sleep(200);
            var err = Format(
                NLocalizer.GetString("EleAxisLine_EleAxisLine_MoveAbsUnsuccess", "{0} MoveAbs unsuccessfully."), Name);
            if (iRet == 0 && MoveWaitDone(false, err, 10, timeOutS) == 0) return 0;
            return -10;
        }

        public int MC_MoveJog(bool direction)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;
            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetJogAcc(AxisNum, DefaultParams.Acceleration * GearRatio);
                _motionCard.AxisSetJogDec(AxisNum, DefaultParams.Deceleration * GearRatio);
                _motionCard.AxisSetJogMaxVel(AxisNum, JogVelocity * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, DefaultParams.MinVelocity * GearRatio, JogVelocity * GearRatio,
                    DefaultParams.AccTime, DefaultParams.DecTime, DefaultParams.StopVel * GearRatio);
            }

            return _motionCard.AxisJogStart(AxisNum, 1, direction ? 0 : 1);
        }

        public int MC_MoveJog(bool direction, double velocity)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (velocity > LimVelP || velocity < LimVelN)
            {
                LogAdd(NLocalizer.GetString("EleAxisLine_EleAxisLine_SpeedParameterLimit", "Speed parameter limit."),
                    LogLevel.Error, 211);
                return -211;
            }

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetJogAcc(AxisNum, DefaultParams.Acceleration * GearRatio);
                _motionCard.AxisSetJogDec(AxisNum, DefaultParams.Deceleration * GearRatio);
                _motionCard.AxisSetJogMaxVel(AxisNum, velocity * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, DefaultParams.MinVelocity * GearRatio, velocity * GearRatio,
                    DefaultParams.AccTime, DefaultParams.DecTime, DefaultParams.StopVel * GearRatio);
            }

            return _motionCard.AxisJogStart(AxisNum, 1, direction ? 1 : 0);
        }

        public int MC_MoveJog(bool direction, double velocity, int start_on = 0)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (LimVelP != -1 && velocity > LimVelP || LimVelN != -1 && velocity < LimVelN)
            {
                LogAdd(NLocalizer.GetString("EleAxisLine_EleAxisLine_SpeedParameterLimit", "Speed parameter limit."),
                    LogLevel.Error, 211);
                return -211;
            }

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetJogAcc(AxisNum, DefaultParams.Acceleration * GearRatio);
                _motionCard.AxisSetJogDec(AxisNum, DefaultParams.Deceleration * GearRatio);
                _motionCard.AxisSetJogMaxVel(AxisNum, velocity * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, DefaultParams.MinVelocity * GearRatio, velocity * GearRatio,
                    DefaultParams.AccTime, DefaultParams.DecTime, DefaultParams.StopVel * GearRatio);
            }

            return _motionCard.AxisJogStart(AxisNum, start_on, direction ? 0 : 1);
        }

        public int MC_MoveRelative(double distance, double velocity)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (velocity > LimVelP || velocity < LimVelN)
            {
                LogAdd(NLocalizer.GetString("EleAxisLine_EleAxisLine_SpeedParameterLimit", "Speed parameter limit."),
                    LogLevel.Error, 211);
                return -211;
            }

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetAcc(AxisNum, DefaultParams.Acceleration * GearRatio);
                _motionCard.AxisSetDec(AxisNum, DefaultParams.Deceleration * GearRatio);
                _motionCard.AxisSetMinVel(AxisNum, DefaultParams.MinVelocity * GearRatio);
                _motionCard.AxisSetMaxVel(AxisNum, velocity * GearRatio);
                _motionCard.AxisSetStopVel(AxisNum, DefaultParams.StopVel * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, DefaultParams.MinVelocity * GearRatio, velocity * GearRatio,
                    DefaultParams.AccTime, DefaultParams.DecTime, DefaultParams.StopVel * GearRatio);
            }

            return _motionCard.AxisRelMove(AxisNum, Convert.ToInt32(distance * GearRatio), velocity * GearRatio);
        }

        public int MC_MoveRelative(double distance, double velocity, float timeOutS)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (velocity > LimVelP || velocity < LimVelN)
            {
                LogAdd(NLocalizer.GetString("EleAxisLine_EleAxisLine_SpeedParameterLimit", "Speed parameter limit."),
                    LogLevel.Error, 211);
                return -211;
            }

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetAcc(AxisNum, DefaultParams.Acceleration * GearRatio);
                _motionCard.AxisSetDec(AxisNum, DefaultParams.Deceleration * GearRatio);
                _motionCard.AxisSetMinVel(AxisNum, DefaultParams.MinVelocity * GearRatio);
                _motionCard.AxisSetMaxVel(AxisNum, velocity * GearRatio);
                _motionCard.AxisSetStopVel(AxisNum, DefaultParams.StopVel * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, DefaultParams.MinVelocity * GearRatio, velocity * GearRatio,
                    DefaultParams.AccTime, DefaultParams.DecTime, DefaultParams.StopVel * GearRatio);
            }

            var iRet = _motionCard.AxisRelMove(AxisNum, Convert.ToInt32(distance * GearRatio), velocity * GearRatio);

            Thread.Sleep(200);
            var err = Format(
                NLocalizer.GetString("EleAxisLine_EleAxisLine_MoveRelUnsuccess", "{0} MoveRel unsuccessfully."), Name);
            if (iRet == 0 && MoveWaitDone(false, err, 10, timeOutS) == 0) return 0;
            return -10;
        }

        public int MC_MoveRelative(double distance, double velocity, double acceleration, double deceleration)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetAcc(AxisNum, acceleration * GearRatio);
                _motionCard.AxisSetDec(AxisNum, deceleration * GearRatio);
                _motionCard.AxisSetMinVel(AxisNum, DefaultParams.MinVelocity * GearRatio);
                _motionCard.AxisSetMaxVel(AxisNum, velocity * GearRatio);
                _motionCard.AxisSetStopVel(AxisNum, DefaultParams.StopVel * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, DefaultParams.MinVelocity * GearRatio, velocity * GearRatio,
                    DefaultParams.AccTime, DefaultParams.DecTime, DefaultParams.StopVel * GearRatio);
            }

            return _motionCard.AxisRelMove(AxisNum, Convert.ToInt32(distance * GearRatio), velocity * GearRatio);
        }

        public int MC_MoveRelative(double distance, double velocity, double acceleration, double deceleration,
            float timeOutS)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetAcc(AxisNum, acceleration * GearRatio);
                _motionCard.AxisSetDec(AxisNum, deceleration * GearRatio);
                _motionCard.AxisSetMinVel(AxisNum, DefaultParams.MinVelocity * GearRatio);
                _motionCard.AxisSetMaxVel(AxisNum, velocity * GearRatio);
                _motionCard.AxisSetStopVel(AxisNum, DefaultParams.StopVel * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, DefaultParams.MinVelocity * GearRatio, velocity * GearRatio,
                    DefaultParams.AccTime, DefaultParams.DecTime, DefaultParams.StopVel * GearRatio);
            }

            var iRet = _motionCard.AxisRelMove(AxisNum, Convert.ToInt32(distance * GearRatio), velocity * GearRatio);

            Thread.Sleep(200);
            var err = Format(
                NLocalizer.GetString("EleAxisLine_EleAxisLine_MoveRelUnsuccess", "{0} MoveRel unsuccessfully."), Name);
            if (iRet == 0 && MoveWaitDone(false, err, 10, timeOutS) == 0) return 0;
            return -10;
        }

        public int MC_MoveRelative(double distance, double velocity, double minVelocity, double accTime, double decTime)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (velocity > LimVelP || velocity < LimVelN)
            {
                LogAdd(NLocalizer.GetString("EleAxisLine_EleAxisLine_SpeedParameterLimit", "Speed parameter limit."),
                    LogLevel.Error, 211);
                return -211;
            }

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetAcc(AxisNum, DefaultParams.Acceleration * GearRatio);
                _motionCard.AxisSetDec(AxisNum, DefaultParams.Deceleration * GearRatio);
                _motionCard.AxisSetMinVel(AxisNum, minVelocity * GearRatio);
                _motionCard.AxisSetMaxVel(AxisNum, velocity * GearRatio);
                _motionCard.AxisSetStopVel(AxisNum, DefaultParams.StopVel * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, minVelocity * GearRatio, velocity * GearRatio,
                    accTime, decTime, DefaultParams.StopVel * GearRatio);
            }

            return _motionCard.AxisRelMove(AxisNum, Convert.ToInt32(distance * GearRatio), velocity * GearRatio);
        }

        public int MC_MoveRelative(double distance, double velocity, double minVelocity, double accTime, double decTime,
            float timeOutS)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (velocity > LimVelP || velocity < LimVelN)
            {
                LogAdd(NLocalizer.GetString("EleAxisLine_EleAxisLine_SpeedParameterLimit", "Speed parameter limit."),
                    LogLevel.Error, 211);
                return -211;
            }

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetAcc(AxisNum, DefaultParams.Acceleration * GearRatio);
                _motionCard.AxisSetDec(AxisNum, DefaultParams.Deceleration * GearRatio);
                _motionCard.AxisSetMinVel(AxisNum, minVelocity * GearRatio);
                _motionCard.AxisSetMaxVel(AxisNum, velocity * GearRatio);
                _motionCard.AxisSetStopVel(AxisNum, DefaultParams.StopVel * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, minVelocity * GearRatio, velocity * GearRatio,
                    accTime, decTime, DefaultParams.StopVel * GearRatio);
            }

            var iRet = _motionCard.AxisRelMove(AxisNum, Convert.ToInt32(distance * GearRatio), velocity * GearRatio);

            Thread.Sleep(200);
            var err = Format(
                NLocalizer.GetString("EleAxisLine_EleAxisLine_MoveRelUnsuccess", "{0} MoveRel unsuccessfully."), Name);
            if (iRet == 0 && MoveWaitDone(false, err, 10, timeOutS) == 0) return 0;
            return -10;
        }

        public int MC_MoveVelocity(double velocity)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (velocity > LimVelP || velocity < LimVelN)
            {
                LogAdd(NLocalizer.GetString("EleAxisLine_EleAxisLine_SpeedParameterLimit", "Speed parameter limit."),
                    LogLevel.Error, 211);
                return -211;
            }

            return _motionCard.AxisVelMove(AxisNum, GearRatio * velocity);
        }

        public int MC_MoveVelocity(double velocity, double acceleration, double deceleration)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (velocity > LimVelP || velocity < LimVelN)
            {
                LogAdd(NLocalizer.GetString("EleAxisLine_EleAxisLine_SpeedParameterLimit", "Speed parameter limit."),
                    LogLevel.Error, 211);
                return -211;
            }

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetAcc(AxisNum, acceleration * GearRatio);
                _motionCard.AxisSetDec(AxisNum, deceleration * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, DefaultParams.MinVelocity * GearRatio, velocity * GearRatio,
                    DefaultParams.AccTime, DefaultParams.DecTime, DefaultParams.StopVel * GearRatio);
            }

            return _motionCard.AxisVelMove(AxisNum, GearRatio * velocity);
        }

        public int MC_MoveVelocity(bool direction, double velocity, double minVelocity, double accTime, double decTime)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            if (velocity > LimVelP || velocity < LimVelN)
            {
                LogAdd(NLocalizer.GetString("EleAxisLine_EleAxisLine_SpeedParameterLimit", "Speed parameter limit."),
                    LogLevel.Error, 211);
                return -211;
            }

            if (AccDecType == AccDecType.Velocity)
            {
                _motionCard.AxisSetMinVel(AxisNum, minVelocity * GearRatio);
                _motionCard.AxisSetAcc(AxisNum, DefaultParams.Acceleration * GearRatio);
                _motionCard.AxisSetDec(AxisNum, DefaultParams.Deceleration * GearRatio);
            }
            else if (AccDecType == AccDecType.Time)
            {
                _motionCard.AxisSetAccDec(AxisNum, minVelocity * GearRatio, velocity * GearRatio,
                    accTime, decTime, DefaultParams.StopVel * GearRatio);
            }

            return _motionCard.AxisVelMove(AxisNum, GearRatio * velocity);
        }

        public int MC_Power(bool enable)
        {
            if (!Enable || IsSimulateMode) return 0;

            var ret = -1;
            var iret = -1;
            if (IEleInit() == 0)
            {
                ret = 0;
                iret = DriveType == AxisType.Step
                    ? _motionCard.AxisSetEnable(_config.AxisNum, !enable)
                    : _motionCard.AxisSetEnable(_config.AxisNum, enable);

                var tSt = DateTime.Now.Ticks / 10000;
                while (true)
                {
                    var tEd = DateTime.Now.Ticks / 10000;
                    var dt = tEd - tSt;
                    if (iret == 0) break;
                    if (dt > 3000)
                    {
                        LogAdd(NLocalizer.GetString("EleAxisLine_EleAxisLine_AxisEanbleFailed", "Axis enable failed"),
                            LogLevel.Error, 1);
                        //MessageBox.Show("Axis cannot be enabled!");
                        return -2;
                    }
                }
            }
            else
            {
                ret = -1;
            }

            return ret;
        }

        public int MC_Reset()
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            return _motionCard.AxisResetAlarm(AxisNum);
        }

        public int MC_SetPosition(double position)
        {
            if (!Enable) return 0;

            if (IsSimulateMode)
            {
                CmdPosPulse = (long) (position * GearRatio);
                ActualPosPulse = (long) (position * GearRatio);
                return 0;
            }

            if (_motionCard == null) return -1;

            return _motionCard.SetAxisPositionAndFeedbackPulse(AxisNum, Convert.ToInt32(position * GearRatio));
        }

        public int MC_SetPosition(double position, bool relative)
        {
            if (!Enable) return 0;

            if (IsSimulateMode)
            {
                if (relative) position = position + ActualPosition;
                CmdPosPulse = (long) (position * GearRatio);
                ActualPosPulse = (long) (position * GearRatio);
            }

            if (_motionCard == null) return -1;

            if (relative)
                return _motionCard.SetAxisPositionAndFeedbackPulse(AxisNum,
                    (int) ((position + ActualPosition) * GearRatio));

            return _motionCard.SetAxisPositionAndFeedbackPulse(AxisNum, Convert.ToInt32(position * GearRatio));
        }

        public int MC_Stop()
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            return _motionCard.AxisStopMove(AxisNum);
        }

        public int SetElMode(bool pelEnable, bool melEnable, StopMode pelStopMode, StopMode melStopMode)
        {
            if (!Enable || IsSimulateMode) return 0;

            if (_motionCard == null) return -1;

            return _motionCard.AxisSetElMode(_config.AxisNum, pelEnable, melEnable, pelStopMode, melStopMode);
        }

        public double ToMm(int pls)
        {
            return pls / PlsPerRoll * AxisLead;
        }

        public int ToPls(double mm)
        {
            return Convert.ToInt32(mm / AxisLead * PlsPerRoll);
        }

        private void CycleDo()
        {
            var pulse1 = true;
            var pulse2 = true;
            while (_cycleFlag)
            {
                Thread.Sleep(10);
                try
                {
                    if (!Enable || IsSimulateMode) continue;

                    if (CheckLimitEnable && InPel && pulse1)
                    {
                        LogAdd(
                            NLocalizer.GetString("EleAxisLine_EleAxisLine_AxisInPositiveLimit",
                                "Axis in positive limit"), LogLevel.Info, 81);
                        pulse1 = false;
                    }

                    if (!CheckLimitEnable && !InPel) pulse1 = true;
                    if (CheckLimitEnable && InMel && pulse2)
                    {
                        LogAdd(
                            NLocalizer.GetString("EleAxisLine_EleAxisLine_AxisInNegativeLimit",
                                "Axis in negative limit"), LogLevel.Info, 82);
                        pulse2 = false;
                    }

                    if (!CheckLimitEnable && !InMel) pulse2 = true;

                    _eleConfigUI.UiRefresh1();
                    _eleDebugUI.UiRefresh1();
                }
                catch (Exception ex)
                {
                    // ignored
                }

                Thread.Sleep(50);
            }
        }

        private void LogAdd(string log, LogLevel lv, int id)
        {
            if (!LogEnable) return;

            if (LogDisplay)
            {
                //((PrimConfigControl)_primConfigUI).AddText(log);
                //((PrimConfigControl)_primConfigUI).AddText(log);
            }

            switch (lv)
            {
                case LogLevel.Fatal:
                    Log.Fatal(12010000 + id, log, LogClassification.Elements, Name);
                    EleAlarmLv = LogLevel.Fatal;
                    EleRunStat = EleRunState.Err;
                    _eleConfigUI.SetEleRunState(EleRunStat);
                    _eleDebugUI.SetEleRunState(EleRunStat);
                    break;

                case LogLevel.Error:
                    Log.Error(22010000 + id, log, LogClassification.Elements, Name);
                    EleAlarmLv = LogLevel.Error;
                    EleRunStat = EleRunState.Err;
                    _eleConfigUI.SetEleRunState(EleRunStat);
                    _eleDebugUI.SetEleRunState(EleRunStat);
                    break;

                case LogLevel.Warn:
                    Log.Warn(32010000 + id, log, LogClassification.Elements, Name);
                    EleAlarmLv = LogLevel.Warn;
                    EleRunStat = EleRunState.Err;
                    _eleConfigUI.SetEleRunState(EleRunStat);
                    _eleDebugUI.SetEleRunState(EleRunStat);
                    break;

                case LogLevel.Info:
                    Log.Info(42010000 + id, log, LogClassification.Elements, Name);
                    EleAlarmLv = LogLevel.Info;
                    break;

                case LogLevel.Debug:
                    Log.Debug(52010000 + id, log, LogClassification.Elements, Name);
                    EleAlarmLv = LogLevel.Debug;
                    break;

                case LogLevel.Trace:
                    Log.Trace(62010000 + id, log, LogClassification.Elements, Name);
                    EleAlarmLv = LogLevel.Trace;
                    break;
            }
        }

        private int MoveErrorHappen()
        {
            if (ActualPosition - CmdPosition > ErrChkRange) return -100;

            if (CmdPosition - ActualPosition > ErrChkRange) return -200;

            return 0;
        }

        private int MoveWaitDone(bool homeMode, string errMsg, int errMethodId, float timeOutS)
        {
            var iRet = 0;
            var t = 0;
            while (t++ <= (int) (timeOutS * 1000))
            {
                if (IsPause)
                {
                    iRet = -5;
                    break;
                }

                if (!IsEnable || IsAlarm || !homeMode && (InPel || InMel || InSPel || InSMel))
                {
                    MC_Stop();
                    LogAdd(errMsg, LogLevel.Error, 100 + errMethodId);
                    LogAdd(
                        Format(
                            NLocalizer.GetString("EleAxisLine_EleAxisLine_LimitMessage",
                                "{0} is in Limit: PEL-{1}, Mel-{2}, SPEL-{3}, SMel-{4}, or has some other alarm-{5} "),
                            Name, InPel, InMel, InSPel, InSMel, IsAlarm), LogLevel.Error, 200 + errMethodId);
                    iRet = -10;
                    break;
                }

                if (IsStop && SignalInp)
                {
                    if (MoveErrorHappen() != 0)
                    {
                        LogAdd(
                            errMsg + NLocalizer.GetString("EleAxisLine_EleAxisLine_PosErrorHappened",
                                " PosError happened."), LogLevel.Error, 300 + errMethodId);
                        iRet = -20;
                        break;
                    }

                    iRet = 0;
                    break;
                }

                Application.DoEvents();
                Thread.Sleep(1);
            }

            if (t < timeOutS * 1000) return iRet;

            LogAdd(errMsg + NLocalizer.GetString("EleAxisLine_EleAxisLine_TimeOutHappened", " TimeOut happened."),
                LogLevel.Error, 400 + errMethodId);
            iRet = -30;
            return iRet;
        }

        public int ExportDataTable(string filePath)
        {
            var iRet = 0;

            if (DataConfigs == null) return -2;

            if (DataConfigs.ListAxisDataConfigs.Count > 0)
            {
                var bRet = XmlSerializerHelper.WriteXML(DataConfigs, filePath, typeof(AxisDataConfigs));

                if (!bRet) return -1;
            }

            return iRet;
        }

        public double GetPosByName(string posName, out bool result)
        {
            result = false;
            if (DataConfigs?.ListAxisDataConfigs == null || DataConfigs.ListAxisDataConfigs.Count == 0) return 0;
            AxisDataConfig posData = null;
            foreach (var t in DataConfigs.ListAxisDataConfigs)
                if (string.Equals(t.Name, posName, StringComparison.CurrentCultureIgnoreCase))
                    posData = t;
            if (posData != null)
            {
                result = true;
                return posData.Position;
            }

            return -999.99;
        }

        public int ImportDataTable(string filePath)
        {
            var iRet = 0;

            DataConfigs.ListAxisDataConfigs.Clear();

            if (File.Exists(filePath))
                DataConfigs = (AxisDataConfigs) XmlSerializerHelper.ReadXML(filePath, typeof(AxisDataConfigs));

            return iRet;
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
    }
}