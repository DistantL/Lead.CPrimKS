using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using csLTDMC;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.LogHelper;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.PrimLEIS
{
    public enum ErrInfo
    {
        ERR_NOERR = 0,
        ERR_UNKNOWN = 1,
        ERR_PARAERR = 2,
        ERR_TIMEOUT = 3,
        ERR_CONTROLLERBUSY = 4,
        ERR_CONTILINE = 6,
        ERR_CANNOT_CONNECTETH = 8,
        MOTION_ERR_HANDLEERR = 9,
        ERR_SENDERR = 10,
        ERR_FIRMWAREERR = 12,
        ERR_FIRMWAR_MISMATCH = 14,
        ERR_FIRMWARE_INVALID_PARA_ERR = 20,
        ERR_FIRMWARE_STATE_ERR = 22,
        ERR_FIRMWARE_CARD_NOT_SUPPORT = 24
    }

    public class PrimLESI : IPrim, IMotionCard, IAxis, IIoModule, IInterpolation, ICmpTrig,IPVT
    {
        private readonly double[] _actualPos = new double[64];
        private readonly double[] _actualVel = new double[64];

        private readonly int[,] _axisIO = new int[64, 20];

        private readonly double[] _cmdPos = new double[64];
        private readonly double[] _cmdVel = new double[64];

        //默认10组DI输入，每组32路输入
        private readonly uint[] _diModule = new uint[10];
        private readonly uint[] _doModule = new uint[10];
        private readonly long[] _errPos = new long[64];

        private readonly long[] _targetPos = new long[64];

        //Key InterruptId; Value IOInfo
        private readonly List<int> DiChangeAdr = new List<int>(); //所有需要触发改变事件的DI首地址
        private readonly List<double> DiFallList = new List<double>();
        private readonly List<double> DiRiseList = new List<double>();

        private LEISConfig _config;
        private bool _cycleCycleReadIOFlag;
        private bool _cycleReadPosFlag;

        private bool _isInitialed;

        private Task _taskCycleReadIO;
        private Task _taskCycleReadPos;

        private uint _totalAxis;

        private ushort _cardNum;

        #region Public Property
        public ushort CardNum => _cardNum;

        public ushort[] CardIds { get; } = new ushort[8];

        public uint[] CardTypes { get; } = new uint[8];

        public LESIDateConfigs DataConfigs { get; private set; } = new LESIDateConfigs();

        public string DataTablePath
        {
            set => _config.DataTablePath = value;
            get => _config.DataTablePath;
        }

        public uint CANNode
        {
            set => _config.CANNode = value;
            get => _config.CANNode;
        }

        public int AD_DA_CANNode
        {
            set => _config.AD_DA_CANNode = value;
            get => _config.AD_DA_CANNode;
        }

        public int ByteStream
        {
            set => _config.ByteStream = value;
            get => _config.ByteStream;
        }

        public double MinVel
        {
            set => _config.MinVel = value;
            get => _config.MinVel;
        }

        public double MaxVel
        {
            set => _config.MaxVel = value;
            get => _config.MaxVel;
        }

        public double Tacc
        {
            set => _config.Tacc = value;
            get => _config.Tacc;
        }

        public double Tdec
        {
            set => _config.Tdec = value;
            get => _config.Tdec;
        }

        public double StopVel
        {
            set => _config.StopVel = value;
            get => _config.StopVel;
        }

        public int[] AInput
        {
            get => _config.AInputMode;
            set => _config.AInputMode = value;
        }

        public int[] AOutput
        {
            get => _config.AOutputMode;
            set => _config.AOutputMode = value;
        }
        public bool InitBoardEnable
        {
            set => _config.InitAdlinkEnable = value;
            get => _config.InitAdlinkEnable;
        }

        public bool DecStopEnable
        {
            set => _config.DecStopEnable = value;
            get => _config.DecStopEnable;
        }
        public double DecStopTime
        {
            set => _config.DecStopTime = value;
            get => _config.DecStopTime;
        }
        #endregion

        #region 构造函数

        public PrimLESI()
        {
            _config = new LEISConfig();

            DataConfigs.ListDataConfig = new List<LESIDateConfig>();
            if (!string.IsNullOrEmpty(_config.DataTablePath)) ImportDataTable(_config.DataTablePath);

            PrimDebugUI = new PrimDebugControl(this);
            PrimConfigUI = new PrimConfigControl(this);
            PrimOutputUI = new PrimOutputControl();

            SetConn_RunState(PrimConnState.Other, PrimRunState.Other);
        }

        public PrimLESI(XmlNode xmlNode)
        {
            if (xmlNode != null)
                _config = XMLHelper.XMLToObject(xmlNode, typeof(LEISConfig)) as LEISConfig;
            else
                return;
            DataConfigs.ListDataConfig = new List<LESIDateConfig>();
            if (_config != null && !string.IsNullOrEmpty(_config.DataTablePath)) ImportDataTable(_config.DataTablePath);
            PrimDebugUI = new PrimDebugControl(this);
            PrimConfigUI = new PrimConfigControl(this);
            PrimOutputUI = new PrimOutputControl();

            SetConn_RunState(PrimConnState.Other, PrimRunState.Other);
        }

        #endregion

        #region Thread method

        private void CycleReadIO()
        {
            // 阻塞等触发
            while (_cycleCycleReadIOFlag)
            {
                try
                {
                    //读取板卡自带输入
                    var cardIn = LTDMC.dmc_read_inport((ushort) DevIndex, 0);
                    cardIn = cardIn & 65535;
                    CheckDiChange(_diModule[0], cardIn, 100);
                    _diModule[0] = cardIn;
                    _doModule[0] = LTDMC.dmc_read_outport((ushort) DevIndex, 0);

                    if (CANNode > 0)
                        for (var i = 0; i < CANNode; i++)
                        {
                            var canIn = 0;

                            LTDMC.nmc_read_inport((ushort) DevIndex, (ushort) (i + 1), 0, ref canIn);
                            canIn = canIn & 65535;
                            CheckDiChange(_diModule[i + 1], (uint) canIn, 100 + i);
                            _diModule[i + 1] = (uint) canIn;

                            var canOut = -1;
                            LTDMC.nmc_read_outport((ushort) DevIndex, (ushort) (i + 1), 0, ref canOut);
                            _doModule[i + 1] = (uint) canOut;
                        }
                }
                catch (Exception)
                {
                }

                Thread.Sleep(1);
            }
        }

        private int CheckDiChange(uint diValue, uint newValue, int addrHead)
        {
            var ret = 0;
            if (!DiChangeAdr.Contains(addrHead))
                return ret;
            if (diValue != newValue)
            {
                var dif = diValue ^ newValue;
                //下降沿
                foreach (var di in DiFallList)
                {
                    if ((int) Math.Floor(di) != addrHead)
                        continue;
                    var idx = (int) Math.Round((di - (int) di) * 100);
                    if ((diValue & (1 << idx)) == 0 && (newValue & (1 << idx)) > 0)
                    {
                        if (OnDIStateChanged == null)
                            return ret;

                        foreach (var del in OnDIStateChanged.GetInvocationList())
                        {
                            Action action = () => { del.Method.Invoke(del.Target, new object[] {di, false, 1}); };
                            action.BeginInvoke(null, null);
                        }

                        Debug.WriteLine(di.ToString("f2") + "Fall");
                        ret = 1;
                    }
                }

                //上升沿
                foreach (var di in DiRiseList)
                {
                    if ((int) Math.Floor(di) != addrHead)
                        continue;
                    var idx = (int) Math.Round((di - (int) di) * 100);
                    if ((diValue & (1 << idx)) > 0 && (newValue & (1 << idx)) == 0)
                    {
                        if (OnDIStateChanged == null)
                            return ret;

                        foreach (var del in OnDIStateChanged.GetInvocationList())
                        {
                            Action action = () => { del.Method.Invoke(del.Target, new object[] {di, true, 0}); };
                            action.BeginInvoke(null, null);
                        }

                        Debug.WriteLine(di.ToString("f2") + "Rise");
                        ret = 1;
                    }
                }
            }

            return ret;
        }

        private void CycleReadPos()
        {
            if (PrimConnStat == PrimConnState.Connected) LTDMC.dmc_get_total_axes((ushort) DevIndex, ref _totalAxis);
            // 阻塞等触发
            while (_cycleReadPosFlag)
            {
                try
                {
                    for (var i = 0; i < _totalAxis; i++)
                    {
                        var motion = (int) LTDMC.dmc_axis_io_status((ushort) DevIndex, (ushort) i);
                        for (var j = 0; j < 16; j++) _axisIO[i, j] = (motion & (1 << j)) > 0 ? 1 : 0;
                        _axisIO[i, 16] = LTDMC.dmc_read_sevon_pin((ushort) DevIndex, (ushort) i) == 0 ? 1 : 0;
                        //_axisIO[i, 17] = LTDMC.dmc_check_done((ushort)DevIndex, (ushort)i) == 1 ? 1 : 0;

                        LTDMC.dmc_get_position_unit((ushort)DevIndex, (ushort)i, ref _cmdPos[i]);

                        LTDMC.dmc_get_encoder_unit((ushort)DevIndex, (ushort)i, ref _actualPos[i]);

                        _targetPos[i] = LTDMC.dmc_get_target_position((ushort) DevIndex, (ushort) i);

                        _errPos[i] = -1;

                        LTDMC.dmc_read_current_speed_unit((ushort)DevIndex, (ushort)i, ref _cmdVel[i]);

                        _actualVel[i] = _cmdVel[i];
                    }
                }
                catch (Exception)
                {
                }

                Thread.Sleep(1);
            }
        }

        #endregion

        #region Override IPrim's Property

        public string Name
        {
            set
            {
                _config.Name = value;
                ((PrimConfigControl) PrimConfigUI).LESIName = value;
                LogParameter(nameof(Name), Name);
            }
            get => _config.Name;
        }

        public string PrimTypeName
        {
            set => _config.PrimTypeName = value;
            get => _config.PrimTypeName;
        }

        public Guid Id
        {
            set => _config.Id = value;
            get => _config.Id;
        }

        public Type ChildType
        {
            set => _config.ChildType = value;
            get => _config.ChildType;
        }

        public PrimType HSType
        {
            set => _config.HSType = value;
            get => _config.HSType;
        }

        public PrimManufacture Manu
        {
            set => _config.Manu = value;
            get => _config.Manu;
        }

        public PrimVer Ver
        {
            set => _config.Ver = value;
            get => _config.Ver;
        }

        public PrimConnState PrimConnStat
        {
            set => _config.PrimConnStat = value;
            get => _config.PrimConnStat;
        }

        public PrimRunState PrimRunStat
        {
            set => _config.PrimRunStat = value;
            get => _config.PrimRunStat;
        }

        public bool PrimSimulator
        {
            set => _config.PrimSimulator = value;
            get => _config.PrimSimulator;
        }

        public bool PrimDebug
        {
            set => _config.PrimDebug = value;
            get => _config.PrimDebug;
        }

        public bool PrimEnable
        {
            set => _config.PrimEnable = value;
            get => _config.PrimEnable;
        }

        public bool LogEnable
        {
            set => _config.LogEnable = value;
            get => _config.LogEnable;
        }

        public LogLevel PrimAlarmLv { get; set; }
        public RunMode PrimRunMode { get; set; }

        public Control PrimDebugUI { get; }

        public Control PrimConfigUI { get; }

        public Control PrimOutputUI { get; }

        #endregion

        #region Override IPrim's Event

        public event PrimDataRefresh OnPrimDataRefresh;
        public event PrimStateChanged OnPrimStateChanged;
        public event PrimOpLog OnPrimOpLog;

        #endregion

        #region Override IPrim's Method

        #region Run and stop

        public int IPrimInit()
        {
            var iRet = 0;

            if (_isInitialed) return 0;

            if (string.IsNullOrEmpty(ConfigFilePath))
            {
                Log.Warn(3101002,
                    Name + NLocalizer.GetString("PrimLEIS_PrimLESI_NoFilePathFound", " No File Path Found!"),
                    LogClassification.VisioPrim, Name);
                return -1;
            }

            if (InitBoardEnable)
            {
                var ret = LTDMC.dmc_board_init();
                if (ret <= 0 || ret > 8)
                {
                    MessageBox.Show(Name + NLocalizer.GetString("PrimLEIS_PrimLESI_CannotBeInited", " can't be inited! "));
                    Log.Error(2101001,
                        Name + NLocalizer.GetString("PrimLEIS_PrimLESI_CannotBeInited", " can't be inited! "),
                        LogClassification.VisioPrim, Name);

                    SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Err);
                    return -1;
                }
            }
            var cardIds = new ushort[8];

            if (LTDMC.dmc_get_CardInfList(ref _cardNum, CardTypes, cardIds) != 0) //获取读取到的控制卡数量， 卡的型号， 卡的ID号
                return -1;

            StopAllAxes();

            for (var i = 0; i < _diModule.Length; i++) _diModule[i] = 0;

            for (var i = 0; i < _doModule.Length; i++) _doModule[i] = 0;

            _isInitialed = true;
            for (var i = 0; i < 15; i++) LTDMC.dmc_reverse_outbit(_cardNum, (ushort) i, 0);

            SetConn_RunState(PrimConnStat, PrimRunStat);
            ((PrimConfigControl) PrimConfigUI).UIInit();

            return iRet;
        }

        public int IPrimConnect(ref string result)
        {
            var iRet = 0;
            var canNum = 0;
            var canStatus = 0;

            if (!_isInitialed) return -1;

            if (PrimConnStat == PrimConnState.Connected) return 0;

            LoadConfigFile(ConfigFilePath);
            if (CANNode > 0)
            {
                SetConnectToCanState((int) CANNode, 1, ByteStream);
                GetConnectToCanState(ref canNum, ref canStatus);

                if (canStatus != 1) //0-断开，1-连接，2-异常
                {
                    Log.Error(2101011,
                        Name + NLocalizer.GetString("PrimLEIS_PrimLESI_CannotConnectToCANModule",
                            " couldn't connect to CAN module. "), LogClassification.VisioPrim, Name);

                    SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Err);
                    return -1;
                }
            }

            Log.Info(4101001, Name + NLocalizer.GetString("PrimLEIS_PrimLESI_HadBeConnected", " had be connected! "),
                LogClassification.VisioPrim, Name);

            SetConn_RunState(PrimConnState.Connected, PrimRunState.Stop);
            return iRet;
        }

        public int IPrimStart()
        {
            var iRet = 0;

            if (PrimRunStat == PrimRunState.Running) return 0;

            if (PrimConnStat != PrimConnState.Connected && PrimRunStat != PrimRunState.Stop) return -1;

            if (_taskCycleReadIO == null || _taskCycleReadIO != null &&
                (_taskCycleReadIO.IsCanceled || _taskCycleReadIO.IsCompleted))
            {
                _taskCycleReadIO = new Task(CycleReadIO);
                _taskCycleReadIO.Start();
            }

            _cycleCycleReadIOFlag = true;

            if (_taskCycleReadPos == null || _taskCycleReadPos != null &&
                (_taskCycleReadPos.IsCanceled || _taskCycleReadPos.IsCompleted))
            {
                _taskCycleReadPos = new Task(CycleReadPos);
                _taskCycleReadPos.Start();
            }

            _cycleReadPosFlag = true;

            Log.Info(4101001, Name + NLocalizer.GetString("PrimLEIS_PrimLESI_HadBeStarted", " had be started! "),
                LogClassification.VisioPrim, Name);

            SetConn_RunState(PrimConnState.Connected, PrimRunState.Running);
            return iRet;
        }

        public int IPrimStop()
        {
            var iRet = 0;

            if (PrimConnStat != PrimConnState.Connected && PrimRunStat != PrimRunState.Running) return -1;

            _cycleCycleReadIOFlag = false;
            _cycleReadPosFlag = false;

            if (_taskCycleReadIO != null)
            {
                _taskCycleReadIO.Wait();
                Thread.Sleep(200);
                _taskCycleReadIO.Dispose();
            }

            if (_taskCycleReadPos != null)
            {
                _taskCycleReadPos.Wait();
                Thread.Sleep(200);
                _taskCycleReadPos.Dispose();
            }

            SetConnectToCanState((int) CANNode, 0, ByteStream);

            iRet = LTDMC.dmc_board_close();
            if (iRet != 0)
                LogAdd(
                    Name + NLocalizer.GetString("PrimLEIS_PrimLESI_Error", " error: ") +
                    $"{((ErrInfo) iRet).ToString()} .", LogLevel.Error, 201);

            _isInitialed = false;

            SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Stop);
            return iRet;
        }

        public int IPrimReset()
        {
            var iRet = 0;
            return iRet;
        }

        public int IPrimDisConnect(ref string result)
        {
            var iRet = 0;
            return iRet;
        }

        public int IPrimSuspend()
        {
            var iRet = 0;
            return iRet;
        }

        public int IPrimResume()
        {
            var iRet = 0;
            return iRet;
        }

        public int IPrimDispose()
        {
            try
            {
                var disConnectRet = "";
                IPrimDisConnect(ref disConnectRet);
                IPrimStop();
                ((PrimDebugControl) PrimDebugUI).Dispose();
                ((PrimOutputControl) PrimOutputUI).Dispose();
                ((PrimConfigControl) PrimConfigUI).Dispose();

                PrimRunStat = PrimRunState.Other;
                PrimConnStat = PrimConnState.Other;
                return 0;
            }
            catch (Exception)
            {
                PrimRunStat = PrimRunState.Err;
                PrimConnStat = PrimConnState.Other;
                return -1;
            }
        }

        #endregion

        #region For Task

        public int IPrimTaskInit()
        {
            ClearEventOnDIStateChanged();
            ClearEventOnDOStateChanged();

            if (IPrimInit() != 0) return -1;

            var connRet = "";
            if (IPrimConnect(ref connRet) != 0) return -2;

            if (IPrimStart() != 0) return -3;

            return 0;
        }

        public int IPrimTaskPause()
        {
            return 0;
        }

        public int IPrimTaskStop()
        {
            if (IPrimStop() != 0) return -1;

            return 0;
        }

        public int IPrimTaskReset()
        {
            if (IPrimReset() != 0) return -1;

            return 0;
        }

        #endregion

        #region Others

        public int IPrimImportConfigXml(XmlNode xmlNode)
        {
            var iRet = 0;
            if (xmlNode != null)
                _config = XMLHelper.XMLToObject(xmlNode, typeof(LEISConfig)) as LEISConfig;
            else
                return -1;
            return iRet;
        }

        public XmlNode IPrimExportConfigXml()
        {
            if (_config == null) return null;

            var node = XMLHelper.ObjectToXML(_config);

            return node;
        }

        public void LoadConfigFile(string file)
        {
            StopAllAxes();
            var ret = LTDMC.dmc_download_configfile((ushort) DevIndex, file);
            for (var i = 0; i < 8; i++) LTDMC.dmc_set_home_el_return((ushort) DevIndex, (ushort) i, 1);
            if (ret != 0)
                return;
            // throw new Exception("load config file fail");
        }

        #endregion

        #endregion

        #region Override IMotionCard's Property

        public string ConfigFilePath
        {
            set => _config.ConfigFilePath = value;
            get => _config.ConfigFilePath;
        }

        public int DevIndex
        {
            set => _config.DevIndex = value;
            get => _config.DevIndex;
        }

        public bool DIChangedEnable { set; get; }
        public bool DOChangedEnable { set; get; }

        public StopMode StopMode
        {
            get => _config.StopMode;
            set => _config.StopMode = value;
        }

        public string IOInfosFilePath { get; set; }
        public IOInfos IoInfos { get; set; }
        public int CurrentImageIndex { get; set; }

        #endregion

        #region Override IMotionCard's Event

        public event DIStateChanged OnDIStateChanged;
        public event DOStateChanged OnDOStateChanged;

        #endregion

        #region Override IMotionCard's Method

        #region Motion IO Status

        public bool AxisIsAlarm(int axisIdx)
        {
            return axisIdx >= 0 && _axisIO[axisIdx, 0] == 1;
        }

        public bool AxisInPel(int axisIdx)
        {
            return axisIdx >= 0 && _axisIO[axisIdx, 1] == 1;
        }

        public bool AxisInMel(int axisIdx)
        {
            return axisIdx >= 0 && _axisIO[axisIdx, 2] == 1;
        }

        public bool AxisSignalEmg(int axisIdx)
        {
            return axisIdx >= 0 && _axisIO[axisIdx, 3] == 1;
        }

        public bool AxisInOrigin(int axisIdx)
        {
            return axisIdx >= 0 && _axisIO[axisIdx, 4] == 1;
        }

        public bool AxisInSPel(int axisIdx)
        {
            return axisIdx >= 0 && _axisIO[axisIdx, 6] == 1;
        }

        public bool AxisInSMel(int axisIdx)
        {
            return axisIdx >= 0 && _axisIO[axisIdx, 7] == 1;
        }

        public bool AxisSignalInp(int axisIdx)
        {
            ushort inpEnable = 0;
            ushort inpLogic = 0;
            LTDMC.dmc_get_inp_mode((ushort) DevIndex, (ushort) axisIdx, ref inpEnable, ref inpLogic);
            if (inpEnable == 1)
            {
                var motion = (int) LTDMC.dmc_axis_io_status((ushort) DevIndex, (ushort) axisIdx);
                return (motion & (1 << 8)) > 0;
            }

            return true;
        }

        public bool AxisSignalEz(int axisIdx)
        {
            return axisIdx >= 0 && _axisIO[axisIdx, 9] == 1;
        }

        public bool AxisSignalRdy(int axisIdx)
        {
            return axisIdx >= 0 && _axisIO[axisIdx, 10] == 1;
        }

        public bool AxisSignalDStp(int axisIdx)
        {
            return axisIdx >= 0 && _axisIO[axisIdx, 11] == 1;
        }

        public bool AxisIsEnble(int axisIdx)
        {
            if (CardTypes[DevIndex] == 0x5C00 && axisIdx > 7)
                return false;
            return axisIdx >= 0 && (_axisIO[axisIdx, 16] == 1 ? true : false);
        }

        public bool AxisIsStop(int axisIdx)
        {
            return LTDMC.dmc_check_done((ushort) DevIndex, (ushort) axisIdx) == 1;
        }

        public int GetFeedbackPulse(int axisIdx, ref double position)
        {
            if (axisIdx < 0)
            {
                position = -1;
                return -10;
            }

            position = _actualPos[axisIdx];
            return 0;
        }

        public int GetAxisPosition(int axisIdx, ref double d)
        {
            if (axisIdx < 0)
            {
                d = -1;
                return -10;
            }

            d = _actualPos[axisIdx];
            return 0;
        }

        public int GetAxisCommand(int axisIdx, ref double d)
        {
            if (axisIdx < 0)
            {
                d = -1;
                return -10;
            }

            d = _cmdPos[axisIdx];
            return 0;
        }

        public bool AxisSignalScl(int axisIdx)
        {
            return false;
        }

        public bool AxisSignalOp(int axisIdx)
        {
            return false;
        }

        #endregion

        #region Motion Pos and Vel

        public int GetAxisTargetPosition(int axisIdx, ref double targetPos)
        {
            if (axisIdx < 0)
            {
                targetPos = -1;
                return -10;
            }

            targetPos = _targetPos[axisIdx];
            return 0;
        }

        public int GetAxisErrPosition(int axisIdx, ref double errPos)
        {
            if (axisIdx < 0)
            {
                errPos = -1;
                return -10;
            }

            errPos = _errPos[axisIdx];
            return 0;
        }

        public int GetAxisCommandVelocity(int axisIdx, ref double velocity)
        {
            if (axisIdx < 0)
            {
                velocity = -1;
                return -10;
            }

            velocity = _cmdVel[axisIdx];
            return 0;
        }

        public int GetAxisActualVelocity(int axisIdx, ref double velocity)
        {
            if (axisIdx < 0)
            {
                velocity = -1;
                return -10;
            }

            velocity = _actualVel[axisIdx];
            return 0;
        }

        #endregion

        #region Motion Parameter

        public int AxisSetAccDec(int Axis, double minVel, double maxVel, double tAcc, double tDec, double stopVel)
        {
            return LTDMC.dmc_set_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(Axis), minVel, maxVel, tAcc,
                tDec, stopVel);
        }

        public int AxisSetAccDec(int Axis, double minVel, double maxVel, double tAcc, double tDec, double stopVel,
            double stTime)
        {
            int ret1 = LTDMC.dmc_set_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(Axis), minVel, maxVel,
                tAcc, tDec, stopVel);
            int ret2 = LTDMC.dmc_set_s_profile(Convert.ToUInt16(DevIndex), Convert.ToUInt16(Axis), 0, stTime);
            if (ret1 != 0) return ret1;
            if (ret2 != 0) return ret2;
            return 0;
        }

        public int AxisSetAcc(int axis, double acc)
        {
            var minVel = 0.0;
            var maxVel = 0.0;
            var oldTAcc = 0.0;
            var tDec = 0.0;
            var stopVel = 0.0;
            LTDMC.dmc_get_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axis), ref minVel, ref maxVel,
                ref oldTAcc, ref tDec, ref stopVel);
            return LTDMC.dmc_set_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axis), minVel, maxVel, acc,
                tDec, stopVel);
        }

        public int AxisSetDec(int axis, double dec)
        {
            var minVel = 0.0;
            var maxVel = 0.0;
            var tAcc = 0.0;
            var oldTDec = 0.0;
            var stopVel = 0.0;
            LTDMC.dmc_get_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axis), ref minVel, ref maxVel,
                ref tAcc, ref oldTDec, ref stopVel);
            return LTDMC.dmc_set_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axis), minVel, maxVel, tAcc,
                dec, stopVel);
        }

        public int AxisSetMinVel(int axisId, double minVel)
        {
            var oldMinVel = 0.0;
            var maxVel = 0.0;
            var tAcc = 0.0;
            var tDec = 0.0;
            var stopVel = 0.0;
            LTDMC.dmc_get_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), ref oldMinVel, ref maxVel,
                ref tAcc, ref tDec, ref stopVel);
            return LTDMC.dmc_set_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), minVel, maxVel,
                tAcc, tDec, stopVel);
        }

        public int AxisSetMaxVel(int axisId, double maxVel)
        {
            var minVel = 0.0;
            var oldMaxVel = 0.0;
            var tAcc = 0.0;
            var tDec = 0.0;
            var stopVel = 0.0;
            LTDMC.dmc_get_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), ref minVel, ref oldMaxVel,
                ref tAcc, ref tDec, ref stopVel);
            return LTDMC.dmc_set_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), minVel, maxVel,
                tAcc, tDec, stopVel);
        }
        public int AxisSetStopDec(int id, int pulse)
        {
            return 0;
        }
        public int AxisSetStopVel(int axisId, double stopVel)
        {
            var minVel = 0.0;
            var maxVel = 0.0;
            var tAcc = 0.0;
            var tDec = 0.0;
            var oldStopVel = 0.0;
            LTDMC.dmc_get_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), ref minVel, ref maxVel,
                ref tAcc, ref tDec, ref oldStopVel);
            return LTDMC.dmc_set_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), minVel, maxVel,
                tAcc, tDec, stopVel);
        }

        #endregion

        #region Motion Home

        public int AxisSetHomeMode(int axisId, int homeDir, int velMode, int homeMode, int posSource)
        {
            posSource = 0;
            LTDMC.dmc_set_home_el_return(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), 1);
            //VelMode:0-低速回零，1-高速回零
            return LTDMC.dmc_set_homemode(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId),
                Convert.ToUInt16(homeDir), velMode, Convert.ToUInt16(homeMode), (ushort)posSource);
        }

        public int AxisSetHomeMode(int axisId, int homeMode, int posSource)
        {
            double velMode = 0;
            ushort oldHomeMode = 0;
            ushort homeDir = 0;
            ushort ezCount = 0;
            LTDMC.dmc_set_home_el_return(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), 1);

            LTDMC.dmc_get_homemode(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), ref homeDir, ref velMode,
                ref oldHomeMode, ref ezCount);
            if (homeMode < 100)
                return LTDMC.dmc_set_homemode(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), homeDir,
                    velMode, (ushort) homeMode, (ushort)posSource);

            ushort oldElEnable = 0;
            ushort elLogic = 0;
            ushort elMode = 0;
            LTDMC.dmc_get_el_mode(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), ref oldElEnable, ref elLogic,
                ref elMode);

            //100-199，正限位禁止、负限位允许（原点与正限位一起）；200-300，正限位允许、负限位禁止（原点与负限位一起）；300-，正负限位禁止；
            if (homeMode >= 100 && homeMode < 200) //正负限位禁止
            {
                LTDMC.dmc_set_el_mode(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), 2, elLogic, elMode);
                return LTDMC.dmc_set_homemode(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), homeDir,
                    velMode, (ushort) (homeMode - 100), 0);
            }

            if (homeMode >= 200 && homeMode < 300)
            {
                LTDMC.dmc_set_el_mode(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), 3, elLogic, elMode);
                return LTDMC.dmc_set_homemode(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), homeDir,
                    velMode, (ushort) (homeMode - 200), 0);
            }

            LTDMC.dmc_set_el_mode(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), 0, elLogic, elMode);
            return LTDMC.dmc_set_homemode(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), homeDir,
                velMode, (ushort) (homeMode - 300), 0);
        }

        public int AxisSetHomeDir(int axisId, int homeDir)
        {
            double velMode = 0;
            ushort homeMode = 0;
            ushort oldHomeDir = 0;
            ushort ezCount = 0;
            LTDMC.dmc_get_homemode(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), ref oldHomeDir, ref velMode,
                ref homeMode, ref ezCount);
            return LTDMC.dmc_set_homemode(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), (ushort) homeDir,
                velMode, homeMode, ezCount);
        }

        public int AxisSetHomeCurve(int axisId, double curve)
        {
            return LTDMC.dmc_set_s_profile(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), 0, curve);
        }

        public int AxisSetHomeAcc(int axisId, double acc)
        {
            var minVel = 0.0;
            var maxVel = 0.0;
            var oldTAcc = 0.0;
            var oldTDec = 0.0;
            var stopVel = 0.0;
            LTDMC.dmc_get_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), ref minVel, ref maxVel,
                ref oldTAcc, ref oldTDec, ref stopVel);
            return LTDMC.dmc_set_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), minVel, maxVel, acc,
                acc, stopVel);
        }

        public int AxisSetHomeVel(int axis, double vel)
        {
            var minVel = 0d;
            var maxVel = 0d;
            var tAcc = 0d;
            var tDec = 0d;
            var stopVel = 0d;
            LTDMC.dmc_get_profile((ushort) DevIndex, (ushort) axis, ref minVel, ref maxVel, ref tAcc, ref tDec,
                ref stopVel);
            return LTDMC.dmc_set_profile((ushort) DevIndex, (ushort) axis, vel / 3d, vel, tAcc, tDec, stopVel);
        }

        public int AxisSetHomeMaxVel(int axisId, double maxVel)
        {
            var minVel = 0.0;
            var oldMaxVel = 0.0;
            var tAcc = 0.0;
            var tDec = 0.0;
            var stopVel = 0.0;
            LTDMC.dmc_get_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), ref minVel, ref oldMaxVel,
                ref tAcc, ref tDec, ref stopVel);
            return LTDMC.dmc_set_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), minVel, maxVel,
                tAcc, tDec, stopVel);
        }

        public int AxisSetHomeVO(int axisId, double vo)
        {
            var oldMinVel = 0.0;
            var maxVel = 0.0;
            var tAcc = 0.0;
            var tDec = 0.0;
            var stopVel = 0.0;
            LTDMC.dmc_get_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), ref oldMinVel, ref maxVel,
                ref tAcc, ref tDec, ref stopVel);
            return LTDMC.dmc_set_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), vo, maxVel, tAcc,
                tDec, stopVel);
        }

        public int AxisSetHomeEZA(int axisId, double eza)
        {
            return 0;
        }

        public int AxisSetHomeShift(int axisId, double shift)
        {
            return 0;
        }

        public int AxisSetHomePos(int axisId, double pos)
        {
            return 0;
        }

        public int AxisHomeMove(int axis)
        {
            return LTDMC.dmc_home_move((ushort) DevIndex, (ushort) axis);
        }

        public int AxisHomeMove(int axisId, bool asyncMode)
        {
            if (asyncMode) return LTDMC.dmc_home_move((ushort) DevIndex, (ushort) axisId);
            LTDMC.dmc_home_move((ushort) DevIndex, (ushort) axisId);
            Thread.Sleep(100);
            while (LTDMC.dmc_check_done((ushort) DevIndex, (ushort) axisId) == 0)
            {
                Thread.Sleep(1);
                Application.DoEvents();
            }

            if (!AxisIsAlarm(axisId) && !AxisSignalEmg(axisId) && AxisIsEnble(axisId))
            {
                SetAxisPositionAndFeedbackPulse(axisId, 0);
                return 0;
            }

            return -10;
        }

        public int AxisHomeMove(int axisId, int homeMode, double vm, double vo, double acc, double shift,
            bool asyncMode = false, int posSource = 1)
        {
            posSource = 0;
            AxisSetHomeMode(axisId, homeMode, posSource);
            LTDMC.dmc_set_home_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), vo, vm, acc, acc);
            var retHome = AxisHomeMove(axisId, asyncMode);
            if (homeMode > 100) AxisSetElMode(axisId, true, true, StopMode.Immediate, StopMode.Immediate);
            return retHome;
        }

        #endregion

        #region Motion Single Move

        public int AxisSetEnable(int axis, bool enable)
        {
            LTDMC.dmc_write_erc_pin((ushort) DevIndex, (ushort) axis, 1);
            Thread.Sleep(50);
            LTDMC.dmc_write_erc_pin((ushort) DevIndex, (ushort) axis, 0);
            Thread.Sleep(50);
            LTDMC.dmc_write_erc_pin((ushort) DevIndex, (ushort) axis, 1);
            Thread.Sleep(50);
            return LTDMC.dmc_write_sevon_pin((ushort) DevIndex, (ushort) axis, (ushort) (enable ? 0 : 1));
        }

        public int AxisAbsMove(int axis, double pos, double vel)
        {
            var minVel = 0d;
            var maxVel = 0d;
            var tAcc = 0d;
            var tDec = 0d;
            var stopVel = 0d;
            LTDMC.dmc_get_profile_unit((ushort)DevIndex, (ushort)axis, ref minVel, ref maxVel, ref tAcc, ref tDec,
                ref stopVel);
            LTDMC.dmc_set_profile_unit((ushort)DevIndex, (ushort)axis, minVel, vel, tAcc, tDec, stopVel);
            return LTDMC.dmc_pmove_unit((ushort)DevIndex, (ushort)axis, (int)pos, 1);
        }

        public int AxisRelMove(int axis, double step, double vel)
        {
            var minVel = 0d;
            var maxVel = 0d;
            var tAcc = 0d;
            var tDec = 0d;
            var stopVel = 0d;
            LTDMC.dmc_get_profile_unit((ushort)DevIndex, (ushort)axis, ref minVel, ref maxVel, ref tAcc, ref tDec,
                ref stopVel);
            LTDMC.dmc_set_profile_unit((ushort)DevIndex, (ushort)axis, minVel, vel, tAcc, tDec, stopVel);
            return LTDMC.dmc_pmove_unit((ushort)DevIndex, (ushort)axis, (int)step, 0);
        }

        public int AxisVelMove(int axisId, double maxVel)
        {
            var velDir = maxVel >= 0 ? true : false;
            var minVel = 0.0;
            var oldMaxVel = 0.0;
            var tAcc = 0.0;
            var tDec = 0.0;
            var stopVel = 0.0;
            LTDMC.dmc_get_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), ref minVel, ref oldMaxVel,
                ref tAcc, ref tDec, ref stopVel);
            LTDMC.dmc_set_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), minVel, Math.Abs(maxVel),
                tAcc, tDec, stopVel);

            return LTDMC.dmc_vmove((ushort) DevIndex, Convert.ToUInt16(axisId), Convert.ToUInt16(velDir));
        }

        public int AxisChangeVel(int axisNum, double newVel)
        {
            return LTDMC.dmc_change_speed_unit((ushort) DevIndex, (ushort) axisNum, newVel, 0);
        }

        public void RelGoXYR(double x, double y, double r)
        {
            MoveRel(new[] {x, y, r}, 7000);
        }

        private bool MoveRel(double[] step, int timeout = -1)
        {
            //start move
            var axisid = new[] {2, 3, 5};
            var ratio = new[] {1250, 1000.0, 138.8888888888889};
            AxisSetEnable(2, true);
            AxisSetEnable(3, true);
            AxisSetEnable(5, false);

            for (var i = 0; i < 3; i++) AxisRelMove(axisid[i], (int) (step[i] * ratio[i]), 10 * 1000);

            //wait done        
            timeout = timeout < 0 ? int.MaxValue : timeout;
            var t = 0;
            while (t++ <= timeout)
            {
                //check alarm
                if (AxisIsStop(2) && AxisIsStop(3) && AxisIsStop(5)) return true;
                //check axis status
                Application.DoEvents();
                Thread.Sleep(1);
            }

            //MoveRel timeout
            return false;
        }

        public int AxisStopMove(int axis)
        {
            if (DecStopEnable)
            {
                LTDMC.dmc_set_dec_stop_time((ushort)DevIndex, (ushort)axis, DecStopTime <= 0 ? 0.1 : DecStopTime);
            }
            return LTDMC.dmc_stop((ushort) DevIndex, (ushort) axis, 0);
        }

        public int StopAllAxes()
        {
            return LTDMC.dmc_emg_stop((ushort) DevIndex);
        }

        public int AxisSetElMode(int axisId, bool pelEnable, bool melEnable, StopMode pelStopMode = StopMode.Other,
            StopMode melStopMode = StopMode.Other)
        {
            var en = pelEnable ? melEnable ? 1 : 3 : melEnable ? 2 : 0;
            var mode = pelStopMode == StopMode.Immediate ? melStopMode == StopMode.Immediate ? 0 :
                2 :
                melStopMode == StopMode.Immediate ? 3 : 1;
            return LTDMC.dmc_set_el_mode((ushort) DevIndex, (ushort) axisId, (ushort) en, 1, (ushort) mode);
        }

        public int AxisSetSoftLimit(int axisId, bool sPelEnable, bool sMelEnable, double sPelValue, double sMelValue)
        {
            ushort oldElEnable = 0;
            ushort elSource = 0;
            ushort elAction = 0;
            var oldSPelValue = 0;
            var oldSMelValue = 0;
            LTDMC.dmc_get_softlimit((ushort) DevIndex, (ushort) axisId, ref oldElEnable, ref elSource, ref elAction,
                ref oldSPelValue, ref oldSMelValue);
            return LTDMC.dmc_set_softlimit((ushort) DevIndex, (ushort) axisId,
                sPelEnable || sMelEnable ? (ushort) 1 : (ushort) 0, elSource, elAction, (int) sMelValue,
                (int) sPelValue);
        }

        public int AxisSetEmgMode(int axisId, int mode)
        {
            ushort oldEnable = 0;
            ushort emgLogic = 0;
            LTDMC.dmc_get_emg_mode((ushort) DevIndex, (ushort) axisId, ref oldEnable, ref emgLogic);
            return LTDMC.dmc_set_emg_mode((ushort) DevIndex, (ushort) axisId, oldEnable, emgLogic);
        }

        #region Jog

        public int AxisSetJogMode(int axisId, int jogMode)
        {
            return 0;
        }

        public int AxisSetJogDir(int axisId, int jogDir)
        {
            return 0;
        }

        public int AxisSetJogAcc(int axisId, double jogAcc)
        {
            var minVel = 0.0;
            var maxVel = 0.0;
            var oldTAcc = 0.0;
            var tDec = 0.0;
            var stopVel = 0.0;
            LTDMC.dmc_get_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), ref minVel, ref maxVel,
                ref oldTAcc, ref tDec, ref stopVel);
            return LTDMC.dmc_set_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), minVel, maxVel,
                jogAcc, tDec, stopVel);
        }

        public int AxisSetJogDec(int axisId, double jogDec)
        {
            var minVel = 0.0;
            var maxVel = 0.0;
            var tAcc = 0.0;
            var oldTDec = 0.0;
            var stopVel = 0.0;
            LTDMC.dmc_get_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), ref minVel, ref maxVel,
                ref tAcc, ref oldTDec, ref stopVel);
            return LTDMC.dmc_set_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), minVel, maxVel,
                tAcc, jogDec, stopVel);
        }

        public int AxisSetJogMaxVel(int axisId, double jogMaxVel)
        {
            var minVel = 0.0;
            var oldMaxVel = 0.0;
            var tAcc = 0.0;
            var tDec = 0.0;
            var stopVel = 0.0;
            LTDMC.dmc_get_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), ref minVel, ref oldMaxVel,
                ref tAcc, ref tDec, ref stopVel);
            return LTDMC.dmc_set_profile_unit(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), minVel, jogMaxVel,
                tAcc, tDec, stopVel);
        }

        public int AxisJogStart(int axisId, int statOn, int jogDir)
        {
            var ret = -1;

            try
            {
                if (statOn == 1)
                    LTDMC.dmc_vmove(Convert.ToUInt16(DevIndex), Convert.ToUInt16(axisId), Convert.ToUInt16(jogDir));
                else
                    AxisStopMove(axisId);
                ret = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return ret;
        }

        #endregion

        #region Others

        public int AxisResetAlarm(int axisIdx)
        {
            //ushort oldEnable = 0;
            //ushort oldLogic = 0;
            //ushort oldOffTime = 0;
            //ushort oldWidth = 0;
            //LTDMC.dmc_get_erc_mode((ushort) DevIndex, (ushort) axisIdx, ref oldEnable, ref oldLogic, ref oldWidth,
            //    ref oldOffTime);
            //LTDMC.dmc_set_erc_mode((ushort) DevIndex, (ushort) axisIdx, 1, 0, 500, 500);
            //LTDMC.nmc_driver_reset((ushort) DevIndex, (ushort) axisIdx);
            LTDMC.dmc_write_erc_pin((ushort) DevIndex, (ushort) axisIdx, 0);
            Action action = () =>
            {
                Thread.Sleep(300);
                LTDMC.dmc_write_erc_pin((ushort) DevIndex, (ushort) axisIdx, 1);
            };
            action.BeginInvoke(null, null);
            return 0;
        }

        public int SetAxisPositionAndFeedbackPulse(int axis, int pos)
        {
            LTDMC.dmc_set_encoder_unit((ushort)DevIndex, (ushort)axis, pos);
            return LTDMC.dmc_set_position_unit((ushort)DevIndex, (ushort)axis, pos);
        }

        public int SetAxisFeedbackPulseToCommand(int axisIdx)
        {
            if (!AxisIsStop(axisIdx))
            {
                AxisStopMove(axisIdx);
                Thread.Sleep(500);
            }
            double pos = 0;
            LTDMC.dmc_get_encoder_unit((ushort)DevIndex, (ushort)axisIdx, ref pos);
            return LTDMC.dmc_set_position_unit((ushort)DevIndex, (ushort)axisIdx, pos);
        }

        #endregion

        #endregion

        #region Digital IO

        public int ReadSingleDOutput(double address, out bool val)
        {
            var ret = 0;
            var canNum = (int) (address - 100);
            var idx = (int) Math.Round((address - (int) address) * 100);
            if (canNum == 0)
            {
                if (_doModule[0] == 0) val = false;
                val = ((_doModule[0] >> idx) & 1) != 1;
            }
            else
            {
                if (_doModule[canNum] == 0) val = false;
                val = ((_doModule[canNum] >> idx) & 1) != 1;
            }

            return ret;
        }

        public int ReadSingleDInput(double address, out bool val)
        {
            var ret = 0;
            var canNum = (int) (address - 100);
            var idx = (int) Math.Round((address - (int) address) * 100);
            if (canNum == 0)
            {
                if (_diModule[0] == 0) val = false;
                val = (_diModule[0] & (1 << idx)) <= 0;
            }
            else if (canNum > 0)
            {
                if (_diModule[canNum] == 0) val = false;
                val = (_diModule[canNum] & (1 << idx)) <= 0;
            }
            else
            {
                val = false;
            }

            return ret;
        }

        public int ReadDiModule(int startAddr, out uint value)
        {
            if (startAddr == 100)
            {
                value = _diModule[0];
                return 0;
            }

            var canIndex = startAddr - 100;
            if (canIndex < _diModule.Length && canIndex > 0)
                value = _diModule[canIndex];
            else
                value = 0;
            return 0;
        }

        public int ReadDoModule(int startAddr, out uint value)
        {
            if (startAddr == 100)
            {
                value = _doModule[0];
                return 0;
            }

            var canIndex = startAddr - 100;
            if (canIndex < _doModule.Length && canIndex > 0)
                value = _doModule[canIndex];
            else
                value = 0;
            return 0;
        }

        #endregion

        #region Analog IO

        public int WriteSingleDOutput(double address, bool val)
        {
            var ret = 0;
            var canNum = (int) (address - 100);
            var idx = (int) Math.Round((address - (int) address) * 100);
            try
            {
                if (canNum == 0)
                {
                    if (idx >= 12 && idx <= 15) LTDMC.dmc_hcmp_set_mode((ushort)DevIndex, (ushort)(idx - 12), 0);
                    ret = LTDMC.dmc_write_outbit((ushort)DevIndex, Convert.ToUInt16(idx), !val ? (ushort)1 : (ushort)0);
                }
                else
                {
                    ret = LTDMC.nmc_write_outbit((ushort)DevIndex, Convert.ToUInt16(canNum), Convert.ToUInt16(idx),
                        !val ? (ushort)1 : (ushort)0);
                }
            }
            catch (Exception ex)
            {
                LogAdd(Name + "输出写入失败：" + ex.Message, LogLevel.Info, 456789);
            }
            

            return ret;
        }

        public int ReadSingleAInput(double address, out double val)
        {
            var iRet = 0;
            val = 0;
            var canNum = (int) (address - 100); //CAN节点号
            var channel = (int) Math.Round((address - (int) address) * 100); //输入端口号
            iRet = LTDMC.nmc_get_ad_input((ushort) DevIndex, Convert.ToUInt16(canNum), (ushort) channel, ref val);
            return iRet;
        }

        public int ReadSingleAOutput(double address, out double val)
        {
            var iRet = 0;
            val = 0;
            var canNum = (int) (address - 100); //CAN节点号
            var channel = (int) Math.Round((address - (int) address) * 100); //输入端口号
            iRet = LTDMC.nmc_get_da_output((ushort) DevIndex, Convert.ToUInt16(canNum), (ushort) channel, ref val);
            return iRet;
        }

        public int WriteSingleAOutput(double address, double val)
        {
            var iRet = 0;
            var canNum = (int) (address - 100); //CAN节点号
            var channel = (int) Math.Round((address - (int) address) * 100); //输出端口号
            iRet = LTDMC.nmc_set_da_output((ushort) DevIndex, Convert.ToUInt16(canNum), (ushort) channel, val);
            return iRet;
        }

        #endregion

        #region 触发相关

        //读取高速比较参数
        public short dmc_hcmp_get_current_state(ushort CardNo, ushort hcmp, ref int remained_points,
            ref int current_point, ref int runned_points)
        {
            return LTDMC.dmc_hcmp_get_current_state(CardNo, hcmp, ref remained_points, ref current_point,
                ref runned_points);
        }

        //清除已添加的所有高速位置比较点
        public short dmc_hcmp_clear_points(ushort CardNo, ushort hcmp)
        {
            return LTDMC.dmc_hcmp_clear_points(CardNo, hcmp);
        }

        //回读25000点的剩余空间
        public short dmc_hcmp_fifo_get_state(ushort ConnectNo, ushort hcmp, ref long remained_points)
        {
            return LTDMC.dmc_hcmp_fifo_get_state(ConnectNo, hcmp, ref remained_points);
        }

        //25000点的清除比较点
        public short dmc_hcmp_fifo_clear_points(ushort ConnectNo, ushort hcmp)
        {
            return LTDMC.dmc_hcmp_fifo_clear_points(ConnectNo, hcmp);
        }

        public int ResetTriggerCount(int trigCh)
        {
            if (DevIndex < 0 || CardTypes.Length <= DevIndex)
            {
                return -9;
            }
            if (CardTypes[DevIndex] == 0x5800 || CardTypes[DevIndex] == 0x5600 || CardTypes[DevIndex] == 0x5400 || CardTypes[DevIndex] == 0x5C00)
                return LTDMC.dmc_hcmp_fifo_clear_points((ushort) DevIndex, (ushort) trigCh);
            return LTDMC.dmc_hcmp_clear_points((ushort) DevIndex, (ushort) trigCh);
        }

        public int SetTriggerChannelEnable(string enableStr)
        {
            throw new NotImplementedException();
        }

        public int SetTriggerChannelMode(int channel, int mode)
        {
            if (DevIndex < 0 || CardTypes.Length <= DevIndex)
            {
                return -9;
            }
            if (channel < 0 || channel > 3 || mode < 0 || mode > 5) return -10;

            //cmp_mode: 0-禁止，1-等于，2-小于，3-大于，4-队列，5-线性
            if (CardTypes[DevIndex] == 0x5800 || CardTypes[DevIndex] == 0x5600 || CardTypes[DevIndex] == 0x5400 || CardTypes[DevIndex] == 0x5C00)
                LTDMC.dmc_hcmp_fifo_set_mode((ushort) DevIndex, (ushort) channel, 1);

            return LTDMC.dmc_hcmp_set_mode((ushort) DevIndex, (ushort) channel, (ushort) mode);
        }

        public int SetTriggerSourceEnable(int trigCh, string enableStr)
        {
            throw new NotImplementedException();
        }

        public int SetTriggerSouceAndInputSource(int trigSrc, int inputSrc)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     比较触发设置
        /// </summary>
        /// <param name="trigChannel">触发通道</param>
        /// <param name="axisId">关联轴</param>
        /// <param name="trigSource">比较位置来源：0-指令位置，1-编码器</param>
        /// <param name="trigLogic">有效电平：0-低电平，1-高电平</param>
        /// <param name="widthTime">脉冲宽度（ms）</param>
        /// <returns>方法执行结果</returns>
        public int SetTriggerConfig(int trigChannel, int axisId, int trigSource, int trigLogic, double widthTime)
        {
            if (trigChannel < 0 || trigChannel > 3 || axisId < 0 || axisId > 7) return -10;

            return LTDMC.dmc_hcmp_set_config((ushort) DevIndex, (ushort) trigChannel, (ushort) axisId,
                (ushort) trigSource, (ushort) trigLogic, (int) widthTime);
        }

        public int SetTrigOutputPulseWidth(int trigCh, double widthTime)
        {
            ushort axis = 0;
            ushort cmpSource = 0;
            ushort cmpLogic = 0;
            var oldTime = 0;
            LTDMC.dmc_hcmp_get_config((ushort) DevIndex, (ushort) trigCh, ref axis, ref cmpSource, ref cmpLogic,
                ref oldTime);
            return LTDMC.dmc_hcmp_set_config((ushort) DevIndex, (ushort) trigCh, axis, cmpSource, cmpLogic,
                (int) widthTime);
        }

        public int SetTrigOutputLogic(int trigCh, int logic)
        {
            //0-低电平，1-高电平
            ushort axis = 0;
            ushort cmpSource = 0;
            ushort oldLogic = 0;
            var time = 0;
            LTDMC.dmc_hcmp_get_config((ushort) DevIndex, (ushort) trigCh, ref axis, ref cmpSource, ref oldLogic,
                ref time);
            return LTDMC.dmc_hcmp_set_config((ushort) DevIndex, (ushort) trigCh, axis, cmpSource, (ushort) logic, time);
        }

        public int SetTrigDir(int trigCh, int dir)
        {
            return 0;
        }

        public int AddTrigPoint(int trigCh, int value)
        {
            return LTDMC.dmc_hcmp_add_point((ushort) DevIndex, (ushort) trigCh, value);
        }

        public int SetLinearCompareTrig(int trigCh, int trigStart, int freq, int count)
        {
            var iRet = new int[2];
            iRet[0] = LTDMC.dmc_hcmp_set_liner((ushort) DevIndex, (ushort) trigCh, freq, count);
            iRet[1] = LTDMC.dmc_hcmp_add_point((ushort) DevIndex, (ushort) trigCh, trigStart);

            if (iRet.All(i => i == 0)) return 0;

            return -10;
        }

        public int GetTriggerCount(int trigCh, ref int count)
        {
            var remainedPoints = 0;
            var currentPoint = 0;

            return LTDMC.dmc_hcmp_get_current_state((ushort) DevIndex, (ushort) trigCh, ref remainedPoints,
                ref currentPoint, ref count);
        }

        public int SetTriggerTable(int tCmpCh, double[] dataArr, int arrSize)
        {
            if (DevIndex < 0 || CardTypes.Length <= DevIndex)
            {
                return -9;
            }
            if (CardTypes[DevIndex] == 0x5800 || CardTypes[DevIndex] == 0x5600 || CardTypes[DevIndex] == 0x5400 || CardTypes[DevIndex] == 0x5C00)
                return LTDMC.dmc_hcmp_fifo_add_table((ushort) DevIndex, (ushort) tCmpCh, (ushort) arrSize, dataArr);

            for (var i = 0; i < dataArr.Length; i++) AddTrigPoint(tCmpCh, (int) dataArr[i]);

            return 0;
        }

        /// <summary>
        ///     手动给一个触发信号
        /// </summary>
        /// <param name="trigCh">触发通道</param>
        /// <returns>方法执行结果</returns>
        public int SetManualTrig(int trigCh, int pulseWidth = 1000)
        {
            if (trigCh < 0 || trigCh > 3) return -10;

            ushort oldCmpMode = 0;
            LTDMC.dmc_hcmp_get_mode((ushort) DevIndex, (ushort) trigCh, ref oldCmpMode);
            //先禁止CMP功能
            LTDMC.dmc_hcmp_set_mode((ushort) DevIndex, (ushort) trigCh, 0);

            //0-低电平，1-高电平
            ushort axis = 0;
            ushort cmpSource = 0;
            ushort logic = 0;
            var oldWidth = 0;
            LTDMC.dmc_hcmp_get_config((ushort) DevIndex, (ushort) trigCh, ref axis, ref cmpSource, ref logic,
                ref oldWidth);
            LTDMC.dmc_hcmp_set_config((ushort) DevIndex, (ushort) trigCh, axis, cmpSource, logic, pulseWidth);

            LTDMC.dmc_write_cmp_pin((ushort) DevIndex, (ushort) trigCh, logic == 0 ? (ushort) 1 : (ushort) 0);
            Thread.Sleep(200);
            var pinValue1 = LTDMC.dmc_read_cmp_pin((ushort) DevIndex, (ushort) trigCh);
            if (logic == 0 && pinValue1 == 1 || logic == 1 && pinValue1 == 0)
            {
                LTDMC.dmc_write_cmp_pin((ushort) DevIndex, (ushort) trigCh, logic == 0 ? (ushort) 0 : (ushort) 1);
                Thread.Sleep(200);
                var pinValue2 = LTDMC.dmc_read_cmp_pin((ushort) DevIndex, (ushort) trigCh);
                if (logic == 0 && pinValue2 == 0 || logic == 1 && pinValue2 == 1)
                {
                    LTDMC.dmc_hcmp_set_config((ushort) DevIndex, (ushort) trigCh, axis, cmpSource, logic, oldWidth);
                    LTDMC.dmc_hcmp_set_mode((ushort) DevIndex, (ushort) trigCh, oldCmpMode);
                    return 0;
                }

                LTDMC.dmc_hcmp_set_config((ushort) DevIndex, (ushort) trigCh, axis, cmpSource, logic, oldWidth);
                LTDMC.dmc_hcmp_set_mode((ushort) DevIndex, (ushort) trigCh, oldCmpMode);
                return -2;
            }

            LTDMC.dmc_hcmp_set_config((ushort) DevIndex, (ushort) trigCh, axis, cmpSource, logic, oldWidth);
            LTDMC.dmc_hcmp_set_mode((ushort) DevIndex, (ushort) trigCh, oldCmpMode);
            return -1;
        }

        #endregion

        #region PT运动

        public int PTDisable(int pTbId)
        {
            throw new NotImplementedException();
        }

        public int PTEnable(int pTbId, int dimension, int[] axisArray)
        {
            throw new NotImplementedException();
        }

        public int PTSetAbsolute(int pTbId)
        {
            throw new NotImplementedException();
        }

        public int PTSetTransBuffered(int pTbId)
        {
            throw new NotImplementedException();
        }

        public int PTSetAcc(int pTbId, double acc)
        {
            throw new NotImplementedException();
        }

        public int PTSetDec(int pTbId, double dec)
        {
            throw new NotImplementedException();
        }

        public int PTSetVm(int pTbId, double vm)
        {
            throw new NotImplementedException();
        }

        public int PTSetVe(int pTbId, double ve)
        {
            throw new NotImplementedException();
        }

        public int PTStop(int pTbId)
        {
            throw new NotImplementedException();
        }

        public int PTStart(int pTbId)
        {
            throw new NotImplementedException();
        }

        public int PTGetStatus(int pTbId, ref PTStatus status)
        {
            throw new NotImplementedException();
        }

        public int PTLineSetPos(int pTbId, double[] pos)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 插补相关

        public int GetAxisMotionMulticoorStatus(short crd)
        {
            return LTDMC.dmc_check_done_multicoor((ushort) DevIndex, (ushort) crd);
        }

        //设置直线插补参数
        public int GetCardType()
        {
            var Ret = -1;
            if (CardTypes[DevIndex] == 0x5400 || CardTypes[DevIndex] == 0x5600 || CardTypes[DevIndex] == 0x5800 || CardTypes[DevIndex] == 0x5C00)
                Ret = 1;
            else
                Ret = 0;
            return Ret;
        }

        public int Set_Equive(int axis_Id, double equive)
        {
            if (axis_Id != -1) LTDMC.dmc_set_equiv((ushort) DevIndex, (ushort) axis_Id, equive);
            return 0;
        }

        public int Set_Interpolation(int crd, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double Stop_Vel)
        {
            // ushort[] axisList = new ushort[2];
            // axisList[0] =2;
            //  axisList[1] = 3;
            // LTDMC.dmc_conti_open_list((ushort)boardId, (ushort)crd, 2, axisList);
            //设置脉冲当量
            if (GetCardType() == 1)
                //设置插补速度曲线
                return LTDMC.dmc_set_vector_profile_unit((ushort) DevIndex, (ushort) crd, Min_Vel, Max_Vel, Tacc, Tdec,
                    Stop_Vel);
            return LTDMC.dmc_set_vector_profile_multicoor((ushort) DevIndex, (ushort) crd, Min_Vel, Max_Vel, Tacc, Tdec,
                Stop_Vel);
        }

        //直线插补
        public int Line_Interpolation(int crd, int axisX_Id, int axisY_Id, int axisZ_Id, int axisR_Id,
            ushort[] AxisList, double[] StartPos, double[] TargetPos, ushort Mode)
        {
            ushort AxisNum = 0;
            int[] axis_Id = {axisX_Id, axisY_Id, axisZ_Id, axisR_Id};
            foreach (var Id in axis_Id)
                if (Id != -1)
                    AxisNum++;
            /*
             //设置起始位置
             LTDMC.dmc_set_position_unit((ushort)boardId, (ushort)axisX_Id, StartPos[0]);
             LTDMC.dmc_set_position_unit((ushort)boardId, (ushort)axisY_Id, StartPos[1]);
             LTDMC.dmc_set_position_unit((ushort)boardId, (ushort)axisZ_Id, StartPos[2]);
             LTDMC.dmc_set_position_unit((ushort)boardId, (ushort)axisR_Id, StartPos[3]);
             */
            if (GetCardType() == 0)
                return LTDMC.dmc_line_unit((ushort) DevIndex, (ushort) crd, AxisNum, AxisList, TargetPos, Mode);

            var Dislist = new int[TargetPos.Length];
            for (var i = 0; i < TargetPos.Length; i++) Dislist[i] = (int) TargetPos[i];
            return LTDMC.dmc_line_multicoor((ushort) DevIndex, (ushort) crd, AxisNum, AxisList, Dislist, Mode);
        }

        //两轴圆弧插补-基于半径
        public int Radius_Interpolation(int crd, int axisX_Id, int axisY_Id,
            ushort[] AxisList, double[] StartPos, double[] TargetPos, double radius, ushort Mode)
        {
            ushort AxisNum = 2; //插补轴数
            //ushort Radius; //插补半径

            //设置起始位置
            // LTDMC.dmc_set_position_unit((ushort)boardId, (ushort)axisX_Id, StartPos[0]);
            // LTDMC.dmc_set_position_unit((ushort)boardId, (ushort)axisY_Id, StartPos[1]);
            //  LTDMC.dmc_set_position_unit((ushort)boardId, (ushort)axisZ_Id, StartPos[2]);

            //Radius = 1500;
            return LTDMC.dmc_arc_move_radius_unit((ushort) DevIndex, (ushort) crd, AxisNum, AxisList, TargetPos, radius,
                1, 0, Mode); //
        }

        //两轴圆弧插补-基于圆心圆弧
        public int Center_Interpolation(int crd, int axisX_Id, int axisY_Id,
            ushort[] AxisList, double[] StartPos, double[] TargetPos, double[] CenterPos, double radius, ushort Mode)
        {
            ushort AxisNum = 2; //插补轴数
            return LTDMC.dmc_arc_move_center_unit((ushort) DevIndex, (ushort) crd, AxisNum, AxisList, TargetPos,
                CenterPos, 1, 0, Mode);
            //设置起始位置
            //LTDMC.dmc_set_position_unit((ushort)boardId, (ushort)axisX_Id, StartPos[0]);
            //LTDMC.dmc_set_position_unit((ushort)boardId, (ushort)axisY_Id, StartPos[1]);
            // LTDMC.dmc_set_position_unit((ushort)boardId, (ushort)axisZ_Id, StartPos[2]);
        }

        //设置小线段前瞻参数
        public int Set_Lookahead(int crd, int enable, int lookaheadSegments, double pathError, double lookaheadAcc)
        {
            return LTDMC.dmc_conti_set_lookahead_mode((ushort) DevIndex, (ushort) crd, (ushort) enable,
                lookaheadSegments, pathError, lookaheadAcc);
        }

        //设置插补运动速度曲线的平滑时间
        public int Set_Vector_s(int crd, double sTime)
        {
            return LTDMC.dmc_set_vector_s_profile((ushort) DevIndex, (ushort) crd, 0, sTime);
        }

        //两轴连续插补
        public int Continue_Interpolation(int crd, ushort[] axisList, double[] targetPos, ushort Mode, int mark)
        {
            /*
            LTDMC.dmc_conti_open_list((ushort)boardId, (ushort)crd, 2, AxisList);
            ushort AxisNum = 2;
            double[] listTarget = new double[2];
            for (int i = 0; i < targetPos.Length/2; i++)
            {
                listTarget[0] = targetPos[i,0];
                listTarget[1] = targetPos[i,1];
                LTDMC.dmc_conti_line_unit((ushort)boardId, (ushort)crd,AxisNum, AxisList, listTarget,Mode,mark);
            }
            LTDMC.dmc_conti_start_list((ushort)boardId, (ushort)crd);
            LTDMC.dmc_conti_close_list((ushort)boardId, (ushort)crd);  
       */
            LTDMC.dmc_conti_line_unit((ushort) DevIndex, (ushort) crd, (ushort)axisList.Length, axisList, targetPos, Mode, mark);
            return 0;
        }

        public int InterpolationOpen(int crd, int axisNum, ushort[] axisList)
        {
            LTDMC.dmc_conti_open_list((ushort) DevIndex, (ushort) crd, (ushort)axisNum, axisList);
            return 0;
        }

        public int ContiCloseList(int crd)
        {
            LTDMC.dmc_conti_close_list((ushort) DevIndex, (ushort) crd);
            return 0;
        }

        public int InterpolationPause(int crd)
        {
            LTDMC.dmc_conti_pause_list((ushort) DevIndex, (ushort) crd);
            return 0;
        }

        public int InterpolationStop(int crd, int stopMode)
        {
            LTDMC.dmc_conti_stop_list((ushort) DevIndex, (ushort) crd, (ushort) stopMode);
            return 0;
        }

        //public int InterpolationStart(int crd)
        //{
        //    LTDMC.dmc_conti_start_list((ushort) DevIndex, (ushort) crd);
        //    return 0;
        //}

        public int ContinueRemainSpace(int crd)
        {
            return LTDMC.dmc_conti_remain_space((ushort) DevIndex, (ushort) crd);
        }

        public int ContinueCurrentMark(int crd)
        {
            return LTDMC.dmc_conti_read_current_mark((ushort) DevIndex, (ushort) crd);
        }

        #endregion

        #region Others

        public int ClearEventOnDIStateChanged()
        {
            if (OnDIStateChanged == null) return 1;

            foreach (var d in OnDIStateChanged.GetInvocationList()) OnDIStateChanged -= d as DIStateChanged;

            return 0;
        }

        public int ClearEventOnDOStateChanged()
        {
            if (OnDOStateChanged == null) return 1;

            foreach (var d in OnDOStateChanged.GetInvocationList()) OnDOStateChanged -= d as DOStateChanged;

            return 0;
        }

        #endregion

        #region Other empty method

        public int ReadAiModule(int startAddr, out double[] value)
        {
            throw new NotImplementedException();
        }

        public int ReadAoModule(int startAddr, out double[] value)
        {
            throw new NotImplementedException();
        }

        public int RegisterDIChanged(double address, int mode, int type = 2)
        {
            var ret = 0;

            var addressHead = (int) Math.Floor(address);
            if (!DiChangeAdr.Contains(addressHead)) DiChangeAdr.Add(addressHead);

            if (DiRiseList.Contains(address) || DiFallList.Contains(address)) return ret;

            switch (mode)
            {
                case 1:
                    DiRiseList.Add(address);
                    break;
                case 2:
                    DiFallList.Add(address);
                    break;
                case 3:
                    DiRiseList.Add(address);
                    DiFallList.Add(address);
                    break;
            }

            return ret;
        }

        public int RegisterDOChanged(double address, int mode)
        {
            return 0;
        }

        public int RemoveDIChanged(double address)
        {
            if (DiRiseList.Contains(address)) DiRiseList.Remove(address);

            if (DiFallList.Contains(address)) DiFallList.Contains(address);

            return 0;
        }

        public int RemoveDOChanged(double address)
        {
            return 0;
        }

        public int ExportIoInfos()
        {
            return 0;
        }

        #endregion

        #endregion

        #region Others

        #region LEISI

        public int SetConnectToCanState(int canNum, int state, int baud)
        {
            return LTDMC.nmc_set_connect_state((ushort) DevIndex, (ushort) canNum, (ushort) state, (ushort) baud);
        }

        public int GetConnectToCanState(ref int canNum, ref int state)
        {
            //0-断开,1-连接，2-异常
            ushort num = 0;
            ushort canState = 0;
            LTDMC.nmc_get_connect_state((ushort) DevIndex, ref num, ref canState);
            canNum = num;
            state = canState;
            if (state != 1)
            {
                Log.Error(2101001,
                    Name + NLocalizer.GetString("PrimLEIS_PrimLESI_CANConnectFail", " CAN connect fail "),
                    LogClassification.VisioPrim, Name);
                return -1;
            }

            return 0;
        }

        public bool AxisHomeDone(int axis)
        {
            ushort state = 0;
            var ret = LTDMC.dmc_get_home_result((ushort) DevIndex, (ushort) axis, ref state);
            return state != 1;
        }

        //设置单轴速度曲线S段参数值, 如果s_para时间设为0 ，运行的是T型速度曲线
        public short dmc_set_s_profile(ushort axis, ushort s_mode, double s_para)
        {
            return LTDMC.dmc_set_s_profile((ushort) DevIndex, axis, s_mode, s_para);
        }

        /// <summary>
        ///     设置DA输出使能
        /// </summary>
        /// <param name="cardNo">控制卡卡号</param>
        /// <param name="enable">DA使能状态：0-禁止，1-使能</param>
        /// <returns></returns>
        public int SetDA_Enable(int cardNo, int enable)
        {
            var iRet = 0;
            iRet = LTDMC.dmc_set_da_enable((ushort) cardNo, (ushort) enable);
            return iRet;
        }

        /// <summary>
        ///     读取DA输出使能
        /// </summary>
        /// <param name="cardNo">控制卡卡号</param>
        /// <param name="enable">DA使能状态：0-禁止，1-使能</param>
        /// <returns></returns>
        public int GetDA_Enable(int cardNo, ref int enable)
        {
            var iRet = 0;
            ushort state = 0;
            iRet = LTDMC.dmc_get_da_enable((ushort) cardNo, ref state);
            enable = state;
            return iRet;
        }

        /// <summary>
        ///     设置指定模块的某个输出端口的电平
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="value">输出电平，单位mV/mA</param>
        /// <returns></returns>
        public int SetDA_Output(double address, double value)
        {
            var iRet = 0;
            var canNum = (int) (address - 100); //CAN节点号
            var channel = (int) Math.Round((address - (int) address) * 100); //输出端口号
            iRet = LTDMC.nmc_set_da_output((ushort) DevIndex, Convert.ToUInt16(canNum), (ushort) channel, value);
            return iRet;
        }

        /// <summary>
        ///     读取指定模块的某个输出端口的电平
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="Value">输出电平，单位mV/mA</param>
        /// <returns></returns>
        public int GetDA_Output(double address, ref double Value)
        {
            var iRet = 0;
            var canNum = (int) (address - 100); //CAN节点号
            var channel = (int) Math.Round((address - (int) address) * 100); //输出端口号
            iRet = LTDMC.nmc_get_da_output((ushort) DevIndex, Convert.ToUInt16(canNum), (ushort) channel, ref Value);
            return iRet;
        }

        /// <summary>
        ///     读取指定模块某个输入端口的电平
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="Value">输入电平，单位mV/mA</param>
        /// <returns></returns>
        public int GetAD_Input(double address, ref double Value)
        {
            var iRet = 0;

            var canNum = (int) (address - 100); //CAN节点号
            var channel = (int) Math.Round((address - (int) address) * 100); //输入端口号
            iRet = LTDMC.nmc_get_ad_input((ushort) DevIndex, Convert.ToUInt16(canNum), (ushort) channel, ref Value);
            return iRet;
        }

        /// <summary>
        ///     设置指定模块某个输入端口的模式
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="mode">输入模式，0：电压模式，1：电流模式</param>
        /// <returns></returns>
        public int SetAD_Mode(double address, int mode)
        {
            var iRet = 0;

            var canNum = (int) (address - 100); //CAN节点号
            var channel = (int) Math.Round((address - (int) address) * 100); //输入端口号
            iRet = LTDMC.nmc_set_ad_mode((ushort) DevIndex, Convert.ToUInt16(canNum), (ushort) channel, (ushort) mode,
                0);
            return iRet;
        }

        /// <summary>
        ///     读取指定模块某个输入端口的模式
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="mode">输出模式，0：电压模式，1：电流模式</param>
        /// <returns></returns>
        public int GetAD_Mode(double address, ref int mode)
        {
            var iRet = 0;
            ushort state = 0;
            var canNum = (int) (address - 100); //CAN节点号
            var channel = (int) Math.Round((address - (int) address) * 100); //输入端口号
            uint buffer_nums = 0;
            iRet = LTDMC.nmc_get_ad_mode((ushort) DevIndex, Convert.ToUInt16(canNum), (ushort) channel, ref state,
                buffer_nums);
            mode = state;
            return iRet;
        }

        /// <summary>
        ///     设置指定模块某个输出端口的模式
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="mode">输出模式，0：电压模式，1：电流模式</param>
        /// <returns></returns>
        public int SetDA_Mode(double address, int mode)
        {
            var iRet = 0;

            var canNum = (int) (address - 100); //CAN节点号
            var channel = (int) Math.Round((address - (int) address) * 100); //输出端口号
            iRet = LTDMC.nmc_set_da_mode((ushort) DevIndex, Convert.ToUInt16(canNum), (ushort) channel, (ushort) mode,
                0);
            return iRet;
        }

        /// <summary>
        ///     读取指定模块某个输出端口的模式
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="mode">输出模式，0：电压模式，1：电流模式</param>
        /// <returns></returns>
        public int GetDA_Mode(double address, ref int mode)
        {
            var iRet = 0;
            ushort state = 0;

            var canNum = (int) (address - 100); //CAN节点号
            var channel = (int) Math.Round((address - (int) address) * 100); //输出端口号
            uint buffer_nums = 0;
            iRet = LTDMC.nmc_get_da_mode((ushort) DevIndex, Convert.ToUInt16(canNum), (ushort) channel, ref state,
                buffer_nums);
            mode = state;
            return iRet;
        }

        /// <summary>
        ///     保存模式设置到模块Flash
        /// </summary>
        /// <param name="address">地址</param>
        /// <returns>
        ///     错误代码
        /// </returns>
        public int WriteToFlash(double address)
        {
            var iRet = 0;

            var canNum = (int) (address - 100);
            iRet = LTDMC.nmc_write_to_flash((ushort) DevIndex, 0, (ushort) canNum);
            return iRet;
        }

        #endregion

        public int ImportDataTable(string filePath)
        {
            var iRet = 0;

            DataConfigs.ListDataConfig.Clear();

            if (File.Exists(filePath))
                DataConfigs = (LESIDateConfigs) XmlSerializerHelper.ReadXML(filePath, typeof(LESIDateConfigs));

            return iRet;
        }

        public int ExportDataTable(string filePath)
        {
            var iRet = 0;

            if (DataConfigs.ListDataConfig.Count > 0)
            {
                var bRet = XmlSerializerHelper.WriteXML(DataConfigs, filePath, typeof(LESIDateConfigs));

                if (!bRet) return -1;
            }

            return iRet;
        }

        public void SetConn_RunState(PrimConnState Conn, PrimRunState Run)
        {
            PrimConnStat = Conn;
            PrimRunStat = Run;
            ((PrimConfigControl) PrimConfigUI).SetPrimConnState(Conn);
            ((PrimConfigControl) PrimConfigUI).SetPrimRunState(Run);
            ((PrimDebugControl) PrimDebugUI).SetPrimConnState(Conn);
            ((PrimDebugControl) PrimDebugUI).SetPrimRunState(Run);
            ((PrimOutputControl) PrimOutputUI).SetPrimConnState(Conn);
            ((PrimOutputControl) PrimOutputUI).SetPrimRunState(Run);
        }

        public void SetConnState(PrimConnState Conn)
        {
            PrimConnStat = Conn;
            ((PrimConfigControl) PrimConfigUI).SetPrimConnState(Conn);
            ((PrimDebugControl) PrimDebugUI).SetPrimConnState(Conn);
            ((PrimOutputControl) PrimOutputUI).SetPrimConnState(Conn);
        }

        public void SetRunState(PrimRunState Run)
        {
            PrimRunStat = Run;
            ((PrimConfigControl) PrimConfigUI).SetPrimRunState(Run);
            ((PrimDebugControl) PrimDebugUI).SetPrimRunState(Run);
            ((PrimOutputControl) PrimOutputUI).SetPrimRunState(Run);
        }

        private void LogParameter(string parameterName, object paratmeterValue)
        {
            if (!LogEnable) return;

            Log.Info(8888,
                $" '{parameterName}' " +
                NLocalizer.GetString("PrimLEIS_PrimLESI_HasBeenChangedTo", "has been changed to") +
                $" '{paratmeterValue}'", LogClassification.Parameter, Name);
        }

        private void LogAdd(string log, LogLevel lv, int id)
        {
            if (!LogEnable) return;
            switch (lv)
            {
                case LogLevel.Fatal:
                    Log.Fatal(11210000 + id, log, LogClassification.VisioPrim, Name);
                    PrimAlarmLv = LogLevel.Fatal;
                    PrimRunStat = PrimRunState.Err;
                    break;
                case LogLevel.Error:
                    Log.Error(21210000 + id, log, LogClassification.VisioPrim, Name);
                    PrimAlarmLv = LogLevel.Error;
                    PrimRunStat = PrimRunState.Err;
                    break;
                case LogLevel.Warn:
                    Log.Warn(31210000 + id, log, LogClassification.VisioPrim, Name);
                    PrimAlarmLv = LogLevel.Warn;
                    PrimRunStat = PrimRunState.Err;
                    break;
                case LogLevel.Info:
                    Log.Info(41210000 + id, log, LogClassification.VisioPrim, Name);
                    PrimAlarmLv = LogLevel.Info;
                    // PrimRunStat = PrimRunState.Err;
                    break;
                case LogLevel.Debug:
                    Log.Debug(51210000 + id, log, LogClassification.VisioPrim, Name);
                    PrimAlarmLv = LogLevel.Debug;
                    //PrimRunStat = PrimRunState.Err;
                    break;
                case LogLevel.Trace:
                    Log.Trace(61210000 + id, log, LogClassification.VisioPrim, Name);
                    PrimAlarmLv = LogLevel.Trace;
                    //PrimRunStat = PrimRunState.Err;
                    break;
            }
        }

        public int InterpolationMove(int crd, int axisNum, ushort[] axisArry, List<TrajPos> trajPos)
        {
            List<TrajPos> CirclePos = new List<TrajPos>();
            LTDMC.dmc_conti_open_list((ushort) DevIndex, (ushort)crd, (ushort)axisNum, axisArry); //打开连续插补缓存区;
            foreach (var item in trajPos)
            {
                if (!item.TrajEnable) continue;
                LTDMC.dmc_set_vector_profile_unit((ushort)DevIndex, (ushort)crd, 0, item.TrajVm, item.Tacc, item.Tdec, 0);
                switch (item.IterpolationType)
                {
                    case 0://0直线插补
                        LTDMC.dmc_conti_line_unit((ushort)DevIndex, (ushort)crd, (ushort)axisNum, axisArry, item.Pos, 1, 0);
                        break;
                    case 1: //2两轴圆弧圆心插补
                        LTDMC.dmc_conti_arc_move_center_unit((ushort)DevIndex, (ushort)crd, 2, axisArry.Take(2).ToArray(),item.Pos.Take(2).ToArray(),item.Pos.Skip(2).Take(2).ToArray(),(ushort)item.ArcDir,item.Circle,(ushort)item.PosiMode,0);
                        break;
                    case 2://2两轴圆心半径插补
                        LTDMC.dmc_conti_arc_move_radius_unit((ushort)DevIndex, (ushort)crd, 2, axisArry.Take(2).ToArray(), item.Pos.Take(2).ToArray(), item.Pos[3], (ushort)item.ArcDir, item.Circle, (ushort)item.PosiMode, 0);
                        break;
                    case 3://3三轴圆弧圆心螺旋插补
                        LTDMC.dmc_conti_arc_move_center_unit((ushort)DevIndex, (ushort)crd, 3, axisArry.Take(3).ToArray(), item.Pos.Take(3).ToArray(), item.Pos.Skip(3).Take(3).ToArray(), (ushort)item.ArcDir, item.Circle, (ushort)item.PosiMode, 0);
                        break;
                    case 4://4三轴圆心半径螺旋插补
                        LTDMC.dmc_conti_arc_move_radius_unit((ushort)DevIndex, (ushort)crd, 3, axisArry.Take(3).ToArray(), item.Pos.Take(3).ToArray(), item.Pos[4], (ushort)item.ArcDir, item.Circle, (ushort)item.PosiMode, 0);
                        break;
                    default:
                        break;
                }

                switch (item.TrajType)
                {
                    case "直线":
                        LTDMC.dmc_conti_line_unit((ushort)DevIndex, (ushort)crd, (ushort)axisNum, axisArry, item.Pos, 1, 0);
                        break;
                    case "圆弧":
                        CirclePos.Add(item);
                        double count = Math.IEEERemainder(CirclePos.Count, 3);
                        switch (count)
                        {
                            case 0:
                                LTDMC.dmc_conti_arc_move_3points_unit((ushort)DevIndex, (ushort)crd, (ushort)axisNum, axisArry, CirclePos[CirclePos.Count - 1].Pos, CirclePos[CirclePos.Count - 2].Pos, CirclePos[CirclePos.Count - 3].Circlenum, 1, 0);
                                break;
                            case 1:
                                LTDMC.dmc_conti_line_unit((ushort)DevIndex, (ushort)crd, (ushort)axisNum, axisArry, CirclePos[CirclePos.Count - 1].Pos, 1, 0);//先移动到圆弧起点
                                break;
                        }
                        break;
                    case "点":
                        LTDMC.dmc_conti_line_unit((ushort)DevIndex, (ushort)crd, (ushort)axisNum, axisArry, item.Pos, 1, 0);
                        LTDMC.dmc_conti_write_outbit((ushort)DevIndex, (ushort)crd, (ushort)item.Bitno, 0, item.DisOpentime);
                        if (item.DisOpentime != 0)
                        {
                            LTDMC.dmc_conti_delay((ushort)DevIndex, (ushort)crd, item.DisOpentime, 0);
                        }
                        break;
                    case "开胶":
                        if (item.TypeOpen == "提前")
                        {
                            LTDMC.dmc_conti_ahead_outbit_to_stop((ushort)DevIndex, (ushort)crd, (ushort)item.Bitno, 0, item.LengthOpen, 0, 0);
                        }
                        else//滞后
                        {
                            LTDMC.dmc_conti_delay_outbit_to_start((ushort)DevIndex, (ushort)crd, (ushort)item.Bitno, 0, item.LengthOpen, 0, 0);
                        }
                        break;
                    case "关胶":
                        LTDMC.dmc_conti_ahead_outbit_to_stop((ushort)DevIndex, (ushort)crd, (ushort)item.Bitno, 1, item.LengthClose, 0, 0);
                        if (item.LengthClose == 0)
                        {
                            LTDMC.dmc_conti_write_outbit((ushort)DevIndex, (ushort)crd, (ushort)item.Bitno, 1, 0);
                        }
                        break;
                    default:
                        break;
                }

            }
            LTDMC.dmc_conti_start_list((ushort) DevIndex, (ushort)crd);
            LTDMC.dmc_conti_close_list((ushort) DevIndex, (ushort)crd);
            return 0;
        }
        public int CircleInterpolationMove(int crd,int axisNum,ushort[] axisArry, int type, List<TrajPos> trajPos)
        {
            LTDMC.dmc_conti_open_list((ushort)DevIndex, (ushort)crd, (ushort)axisNum, axisArry); //打开连续插补缓存区;
            foreach (var item in trajPos)
            {
                if (!item.TrajEnable) continue;
                switch(type)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                LTDMC.dmc_set_vector_profile_unit((ushort)DevIndex, (ushort)crd, 0, item.TrajVm, item.Tacc, item.Tdec, 0);
                LTDMC.dmc_conti_line_unit((ushort)DevIndex, (ushort)crd, (ushort)axisNum, axisArry, item.Pos, 1, 0);
            }
            LTDMC.dmc_conti_start_list((ushort)DevIndex, (ushort)crd);
            LTDMC.dmc_conti_close_list((ushort)DevIndex, (ushort)crd);
            return 0;
        }
        public int AddInterpolationPoint(ushort Crd, ushort AxisNum, ushort[] AxisArry, TrajPos trajPos)
        {
            LTDMC.dmc_set_vector_profile_unit((ushort)DevIndex, Crd, 0, trajPos.TrajVm, trajPos.Tacc, trajPos.Tdec, 0);
            LTDMC.dmc_conti_line_unit((ushort)DevIndex, Crd, AxisNum, AxisArry, trajPos.Pos, 1, 0);
            return 0;
        }
        public int AddInterpolationDO_OnStartDelay(ushort Crd,ushort DoAdr,bool On_Off,ushort isTimemode,double delayCount1,double delayConut2)
        {
            int val = On_Off ? 0 : 1;
            LTDMC.dmc_conti_delay_outbit_to_start((ushort)DevIndex,Crd,DoAdr,(ushort)val,delayCount1,isTimemode,delayConut2);
            return 0;
        }
        public int AddInterpolationDO_OnStopDelay(ushort Crd, ushort DoAdr, bool On_Off, double delayCount1, double delayConut2)
        {
            int val = On_Off ? 0 : 1;
            LTDMC.dmc_conti_delay_outbit_to_stop((ushort)DevIndex, Crd, DoAdr, (ushort)val, delayCount1, delayConut2);
            return 0;
        }
        public int AddInterpolationDO_OnStopAhead(ushort Crd, ushort DoAdr, bool On_Off, ushort isTimemode, double delayCount1, double delayConut2)
        {
            int val = On_Off ? 0 : 1;
            LTDMC.dmc_conti_ahead_outbit_to_stop((ushort)DevIndex, Crd, DoAdr, (ushort)val, delayCount1,isTimemode, delayConut2);
            return 0;
        }
        public int InterpolationStart(int Crd)
        {
            LTDMC.dmc_conti_start_list((ushort)DevIndex, (ushort)Crd);
            LTDMC.dmc_conti_close_list((ushort)DevIndex, (ushort)Crd);
            return 0;
        }
        public int GetInterpolationSta(int crd)
        {
            //0： 运动中， 1： 暂停中， 2： 正常停止， 3： 未启动， 4： 空闲， 5： 异常停止
            return LTDMC.dmc_conti_get_run_state((ushort) DevIndex, (ushort) crd);
        }

        public int AddInterpolationDO(ushort Crd, ushort DoAdr, bool On_Off, double DelayTimeS)
        {
            int val = On_Off ? 0 : 1;
            LTDMC.dmc_conti_write_outbit((ushort)DevIndex,Crd,DoAdr,(ushort)val,DelayTimeS);
            return 0;
        }
        public int AddInterpolationDelayS(ushort Crd,double DelayTimeS)
        {
            LTDMC.dmc_conti_delay((ushort)DevIndex,Crd,DelayTimeS,0);
            return 0;
        }

        public int SetInterPolationBlend(ushort Crd,bool Enable)
        {
            var enable = Enable ? 1 : 0;
            LTDMC.dmc_conti_set_blend((ushort)DevIndex,Crd,(ushort)enable);
            return 0;
        }
        public int AddInterpolatioWaitDI(ushort Crd,ushort DiAdr,bool On_Off,double TimeOutS=0)
        {
            int val = On_Off ? 0 : 1;
            LTDMC.dmc_conti_wait_input((ushort)DevIndex,Crd,DiAdr,(ushort)val,TimeOutS,0);
            return 0;
        }
        #endregion
        #region PVT相关
        public int PvtMove(ushort[] myAxis)
        {
            return (int)LTDMC.dmc_PvtMove((ushort)DevIndex, (ushort)myAxis.Length, myAxis);
        }
        /// <summary>
        ///设置 PTT表格,所有数组的第一个参数必须为0
        /// </summary>
        /// <param name="myAxis">轴号</param>
        /// <param name="myPtTime">PTT时间数组，单位s</param>
        /// <param name="myPPos">PTT位置数组，单位unit</param>
        /// <returns></returns>
        public int PttTableSet(ushort myAxis, double[] myPtTime, int[] myPPos)
        {
            return (int)LTDMC.dmc_PttTable((ushort)DevIndex, myAxis, (uint)myPPos.Length, myPtTime, myPPos);
        }
        public int PttTableSetAndMove(ushort myAxis, double[] myPtTime, int[] myPPos)
        {
            ushort[] My_AxisList = new ushort[1];
            My_AxisList[0] = myAxis;
            PttTableSet(myAxis, myPtTime, myPPos);
            return PvtMove(My_AxisList);
        }
        /// <summary>
        /// 设置PTS表格,所有数组的第一个参数必须为0
        /// </summary>
        /// <param name="myAxis">轴号</param>
        /// <param name="myPtTime">PTS时间数组，单位s</param>
        /// <param name="myPPos">PTS位置数组，单位unit</param>
        /// <param name="myPPer">PTS百分比数组，即加速时间占运动时间的百分比</param>
        /// <returns></returns>
        public int PtsTableSet(ushort myAxis, double[] myPtTime, int[] myPPos, double[] myPPer)
        {
            return (int)LTDMC.dmc_PtsTable((ushort)DevIndex, myAxis, (uint)myPPos.Length, myPtTime, myPPos, myPPer);
        }
        public int PtsTableSetAndMove(ushort myAxis, double[] myPtTime, int[] myPPos, double[] myPPer)
        {
            ushort[] My_AxisList = new ushort[1];
            My_AxisList[0] = myAxis;
            PtsTableSet(myAxis, myPtTime, myPPos, myPPer);
            return PvtMove(My_AxisList);
        }
        /// <summary>
        /// 多轴的PVT运动，时间 位置 速度
        /// </summary>
        /// <param name="axisList">轴组的ID数组</param>
        /// <param name="count">点位数量/param>
        /// <param name="ptTime">时间的数量，单位s</param>
        /// <param name="ptPos">点位位置数组，单位unit</param>
        /// <param name="ptVel">点位速度数组，单位unit/s</param>
        /// <returns></returns>
        public int PvtTableSet(ushort[] axisList, List<double[]> ptTime, List<int[]> ptPos, List<double[]> ptVel)
        {
            for (int i = 0; i < axisList.Length; i++)
                LTDMC.dmc_PvtTable((ushort)DevIndex, axisList[i], (ushort)ptTime[i].Length, ptTime[i], ptPos[i], ptVel[i]);
            return 0;
        }
        public int PvtTableSetAndMove(ushort[] axisList, List<double[]> ptTime, List<int[]> ptPos, List<double[]> ptVel)
        {
            PvtTableSet(axisList, ptTime, ptPos, ptVel);
            return PvtMove(axisList);
        }
        /// <summary>
        /// 多轴的PVTS运动，位置 时间
        /// </summary>
        /// <param name="axisList">轴组的ID数组</param>
        /// <param name="count">点位数量</param>
        /// <param name="ptTime">点位时间数组，单位s</param>
        /// <param name="ptPos">点位位置数组，单位unit</param>
        /// <param name="pVelBegin">轴起始速度数组</param>
        /// <param name="pVelEnd">轴停止速度数组</param>
        /// <returns></returns>
        public int PvtsTableSet(ushort[] axisList, List<double[]> ptTime, List<int[]> ptPos, double[] pVelBegin, double[] pVelEnd)
        {
            if (pVelBegin == null)
                pVelBegin = new double[ptTime.Count];
            if (pVelEnd == null)
                pVelEnd = new double[ptTime.Count];
            for (int i = 0; i < axisList.Length; i++)
                LTDMC.dmc_PvtsTable((ushort)DevIndex, axisList[i], (ushort)ptTime[i].Length, ptTime[i], ptPos[i], pVelBegin[i], pVelEnd[i]);
            return 0;
        }
        public int PvtsTableSetAndMove(ushort[] axisList, List<double[]> ptTime, List<int[]> ptPos, double[] pVelBegin, double[] pVelEnd)
        {
            if (pVelBegin == null)
                pVelBegin = new double[ptTime.Count];
            if (pVelEnd == null)
                pVelEnd = new double[ptTime.Count];
            PvtsTableSet(axisList, ptTime, ptPos, pVelBegin, pVelEnd);
            return PvtMove(axisList);
        }

        public int ReadSingleAInput(double address, EleAnalogType type, out double val)
        {
            throw new NotImplementedException();
        }

        public int SetAxisBand(int axisIdx, uint band, uint time)
        {
            return 0;
        }
        #endregion
    }
}