/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: Prim.cs
 * Author: Victor
 * Description: Socket客户端
 * CreateTime: 2020-1-1
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.23.1230><Victor><20231229V1.0>
 * 1、用于嘉善Snap汇川机械手
 * 
 * <3.3.23.1230><Victor><20240109V1.1>
 * 1、增加断线重连，点击停止按钮即可断开
******************************************************************************/

using IMC100APIDLL;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.Interfaces.Robot;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.PrimRobotInovancePro
{
    /// <summary>
    /// 机器人真实电机使能读取结果。
    /// </summary>
    internal enum MotorEnableStatus
    {
        Unknown,
        Disabled,
        Enabled
    }

    public class Prim : IPrim, IIoModule, IRobotInovance, IMotionCard
    {
        #region Field
        public Config _config = null;

        /// <summary>
        /// 连接状态
        /// </summary>
        PrimConnState _primConnStat;

        /// <summary>
        /// 运行状态
        /// </summary>
        PrimRunState _primRunStat;

        /// <summary>
        /// 重连线程
        /// </summary>
        Task _taskReConnect = null;

        /// <summary>
        /// 重连线程取消
        /// </summary>
        CancellationTokenSource _cts;

        /// <summary>
        /// 连接中标志
        /// </summary>
        bool _isConnecting = false;

        /// <summary>
        /// 电机使能状态访问锁，后续读写真实使能状态时共用。
        /// </summary>
        readonly object _motorEnableStatusLock = new object();
        #endregion



        #region Prop
        /// <summary>
        /// IP
        /// </summary>
        internal string RobotIp
        {
            get => _config.RobotIp;
            set
            {
                if (_config.RobotIp != value)
                {
                    LogAddAuthority($"RobotIp > {_config.RobotIp} > {value}", LogLevel.Trace);
                    _config.RobotIp = value;
                }
            }
        }
        /// <summary>
        /// 端口
        /// </summary>
        internal int Port
        {
            get => _config.Port;
            set
            {
                if (_config.Port != value)
                {
                    LogAddAuthority($"Port > {_config.Port} > {value}", LogLevel.Trace);
                    _config.Port = value;
                }
            }
        }
        /// <summary>
        /// ID
        /// </summary>
        internal int RobotId
        {
            get => _config.RobotId;
            set
            {
                if (_config.RobotId != value)
                {
                    LogAddAuthority($"RobotId > {_config.RobotId} > {value}", LogLevel.Trace);
                    _config.RobotId = value;
                }
            }
        }
        /// <summary>
        /// 密码
        /// </summary>
        internal string Password
        {
            get => _config.Password;
            set
            {
                if (_config.Password != value)
                {
                    LogAddAuthority($"Password > {_config.Password} > {value}", LogLevel.Trace);
                    _config.Password = value;
                }
            }
        }
        /// <summary>
        /// 程序路径
        /// </summary>
        internal string Path
        {
            get => _config.Path;
            set
            {
                if (_config.Path != value)
                {
                    LogAddAuthority($"Path > {_config.Path} > {value}", LogLevel.Trace);
                    _config.Path = value;
                }
            }
        }
        /// <summary>
        /// 机器人版本
        /// </summary>
        internal RobotVer RobotVer
        {
            get => _config.RobotVer;
            set
            {
                if (_config.RobotVer != value)
                {
                    LogAddAuthority($"RobotVer > {_config.RobotVer} > {value}", LogLevel.Trace);
                    _config.RobotVer = value;
                }
            }
        }
        /// <summary>
        /// 速度
        /// </summary>
        internal int Vel { get; set; }

        /// <summary>
        /// 连接中标志
        /// </summary>
        internal bool IsConnecting
        {
            get => _isConnecting;
            set
            {
                if (_isConnecting != value)
                {
                    ((PrimConfigControl)PrimConfigUI).SetInitEnable(value);
                    _isConnecting = value;
                }
            }
        }

        internal PrimManufacture Manu { set; get; } = PrimManufacture.Inovance;

        public LogLevel PrimAlarmLv { get; set; }

        public RunMode PrimRunMode { get; set; }
        #endregion



        #region Ctor
        public Prim()
        {
            _config = new Config();

            PrimDebugUI = new PrimDebugControl(this);
            PrimConfigUI = new PrimConfigControl(this);
            PrimOutputUI = new PrimOutputControl();

            PrimConnStat = PrimConnState.Other;
            PrimRunStat = PrimRunState.Other;
        }
        public Prim(XmlNode xmlNode)
        {
            _config = XMLHelper.XMLToObject(xmlNode, typeof(Config)) as Config;
            if (_config == null)
            {
                throw new NullReferenceException("Config Is Null");
            }

            PrimDebugUI = new PrimDebugControl(this);
            PrimConfigUI = new PrimConfigControl(this);
            PrimOutputUI = new PrimOutputControl();

            PrimConnStat = PrimConnState.Other;
            PrimRunStat = PrimRunState.Other;
        }
        #endregion



        #region Override IPrim
        public Guid Id
        {
            set => _config.Id = value;
            get => _config.Id;
        }
        public string Name
        {
            get => _config.Name;
            set
            {
                if (_config.Name != value)
                {
                    LogAddAuthority($"Name > {_config.Name} > {value}", LogLevel.Trace);
                    ((PrimConfigControl)PrimConfigUI).SetPrimName(value);
                    _config.Name = value;
                }
            }
        }
        public bool PrimEnable
        {
            set => _config.PrimEnable = value;
            get => _config.PrimEnable;
        }
        public PrimType HSType { set; get; } = PrimType.Robot;
        public string PrimTypeName
        {
            set => _config.PrimTypeName = value;
            get => _config.PrimTypeName;
        }
        public Control PrimConfigUI { get; }
        public Control PrimDebugUI { get; }
        public Control PrimOutputUI { get; }
        public PrimConnState PrimConnStat
        {
            set
            {
                if (_primConnStat != value)
                {
                    _primConnStat = value;
                    ((PrimConfigControl)PrimConfigUI).SetPrimConnState(value);
                }
            }
            get => _primConnStat;
        }
        public PrimRunState PrimRunStat
        {
            set
            {
                if (_primRunStat != value)
                {
                    _primRunStat = value;
                    ((PrimConfigControl)PrimConfigUI).SetPrimRunState(value);
                }
            }
            get => _primRunStat;
        }
        public PrimVer Ver { get; set; } = PrimVer.Other;
        public int CurrentImageIndex { get => _config.CurrentImageIndex; set => _config.CurrentImageIndex = value; }

        public int IPrimInit()
        {
            try
            {
                if ((PrimRunStat == PrimRunState.Running || PrimRunStat == PrimRunState.Stop) && PrimConnStat == PrimConnState.Connected)
                {
                    return 0;
                }

                int ret;

                byte[] bytes = IPAddress.Parse(RobotIp).GetAddressBytes();
                Array.Reverse(bytes);
                uint IpAddr = BitConverter.ToUInt32(bytes, 0);

                Byte[] password = new Byte[8];
                password = Encoding.Default.GetBytes(Password);

                switch (RobotVer)
                {
                    case RobotVer.S0321R20:
                        {
                            if ((ret = IMC100API_S0321R20.IMC100_Exit_ETH(RobotId)) != 0)//1.关闭机器人网络
                            {
                                throw new Exception($"IMC100_Exit_ETH -> {ret}");
                            }
                            Thread.Sleep(100);

                            if ((ret = IMC100API_S0321R20.IMC100_Init_ETH(IpAddr, (ushort)Port, 5, RobotId)) != 0)//建立机器人连接
                            {
                                throw new Exception($"IMC100_Init_ETH -> {ret}");
                            }

                            if ((ret = IMC100API_S0321R20.IMC100_AcqPermit(1, RobotId)) != 0)//当前API网络客户端设备请求获取控制权许可
                            {
                                throw new Exception($"IMC100_AcqPermit -> {ret}");
                            }

                            if ((ret = IMC100API_S0321R20.IMC100_UserLogin(2, password, RobotId)) != 0)//当前API网络客户端设备登陆对应的用户模式
                            {
                                throw new Exception($"IMC100_UserLogin -> {ret}");
                            }
                            int iValue = 0;
                            if ((ret = IMC100API_S0321R20.IMC100_CurCtrlDev(ref iValue, RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_CurCtrlDev -> {ret}");
                            }
                            if (iValue != 2)
                            {
                                throw new Exception($"IMC100_CurCtrlDev权限权所在 -> {iValue}");
                            }
                        }
                        break;

                    case RobotVer.V4R24:
                        {
                            if ((ret = IMC100API_V4R24.IMC100_Exit_ETH(RobotId)) != 0)//1.关闭机器人网络
                            {
                                throw new Exception($"IMC100_Exit_ETH -> {ret}");
                            }
                            Thread.Sleep(100);

                            if ((ret = IMC100API_V4R24.IMC100_Init_ETH(IpAddr, (ushort)Port, 5, RobotId)) != 0)//建立机器人连接
                            {
                                throw new Exception($"IMC100_Init_ETH -> {ret}");
                            }

                            if ((ret = IMC100API_V4R24.IMC100_AcqPermit(1, RobotId)) != 0)//当前API网络客户端设备请求获取控制权许可
                            {
                                throw new Exception($"IMC100_AcqPermit -> {ret}");
                            }

                            if ((ret = IMC100API_V4R24.IMC100_UserLogin(2, password, RobotId)) != 0)//当前API网络客户端设备登陆对应的用户模式
                            {
                                throw new Exception($"IMC100_UserLogin -> {ret}");
                            }
                            int iValue = 0;
                            if ((ret = IMC100API_V4R24.IMC100_CurCtrlDev(ref iValue, RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_CurCtrlDev -> {ret}");
                            }
                            if (iValue != 2)
                            {
                                throw new Exception($"IMC100_CurCtrlDev权限权所在 -> {iValue}");
                            }
                        }
                        break;

                    default:
                        throw new Exception(nameof(RobotVer));
                }

                PrimConnStat = PrimConnState.Connected;
                PrimRunStat = PrimRunState.Stop;

                return 0;
            }
            catch (Exception ex)
            {
                LogAdd($"IPrimInit_Error：{ex.Message}", LogLevel.Warn);
                return -1;
            }
        }
        public int IPrimConnect(ref string result)
        {
            return 0;
        }
        public int IPrimStart()
        {
            bool state = false;
            try
            {
                if (PrimRunStat == PrimRunState.Running)
                {
                    return 0;
                }

                if (PrimConnStat != PrimConnState.Connected || PrimRunStat != PrimRunState.Stop)
                {
                    throw new Exception($"未连接");
                }

                int ret = PrgStart(Vel);
                if (ret != 0)
                {
                    throw new Exception($"PrgStart -> {ret}");
                }

                if (_taskReConnect == null && !IsConnecting)
                {
                    _cts = new CancellationTokenSource();
                    _taskReConnect = Task.Run(() => ReConnect(_cts.Token));
                }

                int vel = 0;
                if (GetVel(ref vel) == 0)
                {
                    Vel = vel;
                    ((PrimConfigControl)PrimConfigUI).SetSpeed(vel);
                }

                state = true;
            }
            catch (Exception ex)
            {
                LogAdd($"IPrimStart_Error：{ex.Message}", LogLevel.Warn);
            }

            PrimConnStat = state ? PrimConnState.Connected : PrimConnState.UnConnected;
            PrimRunStat = state ? PrimRunState.Running : PrimRunState.Other;

            return state ? 0 : -1;
        }
        public int IPrimStop()
        {
            bool state = false;

            try
            {
                int ret;
                if (_cts != null)
                {
                    _cts.Cancel();
                }

                switch (RobotVer)
                {
                    case RobotVer.S0321R20:
                        {
                            if ((ret = IMC100API_S0321R20.IMC100_Set_Mode(1, RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_Set_Mode -> {ret}");
                            }
                            Thread.Sleep(500);
                            if ((ret = IMC100API_S0321R20.IMC100_Exit_ETH(RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_Exit_ETH -> {ret}");
                            }
                        }
                        break;

                    case RobotVer.V4R24:
                        {
                            if ((ret = IMC100API_V4R24.IMC100_Set_Mode(1, RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_Set_Mode -> {ret}");
                            }
                            Thread.Sleep(500);
                            if ((ret = IMC100API_V4R24.IMC100_Exit_ETH(RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_Exit_ETH -> {ret}");
                            }
                        }
                        break;

                    default:
                        throw new Exception(nameof(RobotVer));
                }

                state = true;
            }
            catch (Exception ex)
            {
                Thread.Sleep(1000);
                LogAdd($"IPrimStop_Error：{ex.Message}", LogLevel.Warn);
            }
            finally
            {
                try
                {
                    if (_taskReConnect != null)
                    {
                        _taskReConnect.Wait(500);
                        _taskReConnect = null;
                    }
                }
                catch
                {
                    _taskReConnect = null;
                }
                _cts = null;
                IsConnecting = false;
            }

            PrimConnStat = PrimConnState.UnConnected;
            PrimRunStat = !state ? PrimRunState.Err : PrimRunState.Other;
            return state ? 0 : -1;
        }
        public int IPrimDispose()
        {
            bool state = false;
            try
            {

                state = true;
            }
            catch (Exception ex)
            {
                LogAdd($"IPrimDispose_Error：{ex.Message}", LogLevel.Warn);
            }

            PrimConnStat = PrimConnState.Other;
            PrimRunStat = !state ? PrimRunState.Err : PrimRunState.Other;
            return state ? 0 : -1;
        }
        public int IPrimTaskInit()
        {
            int ret = -1;

            if ((ret = IPrimInit()) != 0)
            {
                return -1;
            }

            var connRet = "";
            if ((ret = IPrimConnect(ref connRet)) != 0)
            {
                return -2;
            }

            if ((ret = IPrimStart()) != 0)
            {
                return -3;
            }

            return ret;
        }
        public int IPrimTaskPause()
        {
            return 0;
        }
        public int IPrimTaskReset()
        {
            return 0;
        }
        public int IPrimTaskStop()
        {
            int ret = -1;

            if ((ret = IPrimStop()) != 0)
            {
                return ret;
            }

            if ((ret = IPrimDispose()) != 0)
            {
                return ret;
            }

            return 0;
        }
        public XmlNode IPrimExportConfigXml()
        {
            return XMLHelper.ObjectToXML(_config);
        }
        public int IPrimImportConfigXml(XmlNode xmlNode)
        {
            _config = XMLHelper.XMLToObject(xmlNode, typeof(Config)) as Config;
            return _config != null ? 0 : -1;
        }
        #endregion



        #region Override's IIoModules
        public event DIStateChanged OnDIStateChanged;
        public event DOStateChanged OnDOStateChanged;
        public bool DIChangedEnable { get; set; }
        public bool DOChangedEnable { get; set; }
        public IOInfos IoInfos { get; set; }
        public string IOInfosFilePath { get; set; }

        private List<double> DiFallList = new List<double>();
        private List<double> DiRiseList = new List<double>();
        private List<int> DiChangeAdr = new List<int>();
        public int ExportIoInfos()
        {
            return 0;
        }
        public int ReadAiModule(int startAddr, out double[] value)
        {
            value = new double[] { };
            return 0;
        }
        public int ReadAoModule(int startAddr, out double[] value)
        {
            value = new double[] { };
            return 0;
        }
        public int ReadDiModule(int startAddr, out uint value)
        {
            int iRet = 0;
            value = 0;
            int valueTemp = 0;

            switch (RobotVer)
            {
                case RobotVer.S0321R20:
                    {
                        iRet = IMC100API_S0321R20.IMC100_Get_DI(startAddr, ref valueTemp, RobotId);
                        value = (uint)valueTemp;
                    }
                    break;

                case RobotVer.V4R24:
                    {
                        iRet = IMC100API_V4R24.IMC100_Get_DI(startAddr, ref valueTemp, RobotId);
                        value = (uint)valueTemp;
                    }
                    break;

                default:
                    throw new Exception(nameof(RobotVer));
            }

            return iRet;
        }
        public int ReadDoModule(int startAddr, out uint value)
        {
            int iRet = 0;
            value = 0;
            int valueTemp = 0;

            switch (RobotVer)
            {
                case RobotVer.S0321R20:
                    {
                        iRet = IMC100API_S0321R20.IMC100_Get_DO(startAddr, ref valueTemp, RobotId);
                        value = (uint)valueTemp;
                    }
                    break;

                case RobotVer.V4R24:
                    {
                        iRet = IMC100API_V4R24.IMC100_Get_DO(startAddr, ref valueTemp, RobotId);
                        value = (uint)valueTemp;
                    }
                    break;

                default:
                    throw new Exception(nameof(RobotVer));
            }

            return iRet;
        }
        public int ReadSingleAInput(double address, out double val)
        {
            val = 0;
            return 0;
        }
        public int ReadSingleAInput(double address, EleAnalogType type, out double val)
        {
            val = 0;
            return 0;
        }
        public int ReadSingleAOutput(double address, out double val)
        {
            val = 0;
            return 0;
        }
        public int ReadSingleDInput(double address, out bool val)
        {
            int value = 0;
            int ret;
            val = false;

            switch (RobotVer)
            {
                case RobotVer.S0321R20:
                    {
                        if ((ret = IMC100API_S0321R20.IMC100_Get_DI((int)address, ref value, RobotId)) != 0)
                        {
                            LogAdd($"IMC100_Get_DI -> {ret}", LogLevel.Warn);
                        }
                        else
                        {
                            val = value == 1;
                        }
                    }
                    break;

                case RobotVer.V4R24:
                    {
                        if ((ret = IMC100API_V4R24.IMC100_Get_DI((int)address, ref value, RobotId)) != 0)
                        {
                            LogAdd($"IMC100_Get_DI -> {ret}", LogLevel.Warn);
                        }
                        else
                        {
                            val = value == 1;
                        }
                    }
                    break;

                default:
                    throw new Exception(nameof(RobotVer));
            }
            return ret;
        }
        public int ReadSingleDOutput(double address, out bool val)
        {
            int value = 0;
            int ret;
            val = false;

            switch (RobotVer)
            {
                case RobotVer.S0321R20:
                    {
                        if ((ret = IMC100API_S0321R20.IMC100_Get_DO((int)address, ref value, RobotId)) != 0)
                        {
                            LogAdd($"IMC100_Get_DO -> {ret}", LogLevel.Warn);
                        }
                        else
                        {
                            val = value == 1;
                        }
                    }
                    break;

                case RobotVer.V4R24:
                    {
                        if ((ret = IMC100API_V4R24.IMC100_Get_DO((int)address, ref value, RobotId)) != 0)
                        {
                            LogAdd($"IMC100_Get_DO -> {ret}", LogLevel.Warn);
                        }
                        else
                        {
                            val = value == 1;
                        }
                    }
                    break;

                default:
                    throw new Exception(nameof(RobotVer));
            }
            return ret;
        }
        public int RegisterDIChanged(double address, int mode, int type = 2)
        {
            var ret = 0;

            var addressHead = (int)Math.Floor(address);
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
            if (DiRiseList.Contains(address))
                DiRiseList.Remove(address);
            if (DiFallList.Contains(address))
                DiFallList.Remove(address);
            return 0;
        }
        public int RemoveDOChanged(double address)
        {
            return 0;
        }
        public int WriteSingleAOutput(double address, double val)
        {
            return 0;
        }
        public int WriteSingleDOutput(double address, bool val)
        {
            int ret = 0;
            switch (RobotVer)
            {
                case RobotVer.S0321R20:
                    {
                        if ((ret = IMC100API_S0321R20.IMC100_Set_DO((int)address, val ? 1 : 0, RobotId)) != 0)
                        {
                            LogAdd($"IMC100_Set_DO -> {ret}", LogLevel.Warn);
                        }
                    }
                    break;

                case RobotVer.V4R24:
                    {
                        if ((ret = IMC100API_V4R24.IMC100_Set_DO((int)address, val ? 1 : 0, RobotId)) != 0)
                        {
                            LogAdd($"IMC100_Set_DO -> {ret}", LogLevel.Warn);
                        }
                    }
                    break;

                default:
                    throw new Exception(nameof(RobotVer));
            }
            return ret;
        }
        public int ClearEventOnDIStateChanged()
        {
            if (OnDIStateChanged != null)
            {
                foreach (var d in OnDIStateChanged.GetInvocationList())
                {
                    OnDIStateChanged -= d as DIStateChanged;
                }
            }

            return 0;
        }
        public int ClearEventOnDOStateChanged()
        {
            if (OnDOStateChanged != null)
            {
                foreach (var d in OnDOStateChanged.GetInvocationList())
                {
                    OnDOStateChanged -= d as DOStateChanged;
                }
            }

            return 0;
        }
        #endregion



        #region Override IRobotInovance
        /// <summary>
        /// 读取机器人真实电机使能状态。
        /// </summary>
        /// <remarks>
        /// 仅供配置界面状态展示使用，不写入基元配置，也不记录轮询日志。
        /// </remarks>
        internal MotorEnableStatus GetActualMotorEnableStatus()
        {
            try
            {
                lock (_motorEnableStatusLock)
                {
                    if (PrimRunStat != PrimRunState.Running ||
                        PrimConnStat != PrimConnState.Connected ||
                        IsConnecting)
                    {
                        return MotorEnableStatus.Unknown;
                    }

                    int enable = -1;
                    int ret;
                    RobotVer robotVer = this.RobotVer;
                    int robotId = RobotId;
                    switch (robotVer)
                    {
                        case RobotVer.S0321R20:
                            ret = IMC100API_S0321R20.IMC100_Get_MotorSts(ref enable, robotId);
                            break;

                        case RobotVer.V4R24:
                            ret = IMC100API_V4R24.IMC100_Get_MotorSts(ref enable, robotId);
                            break;

                        default:
                            return MotorEnableStatus.Unknown;
                    }

                    if (ret != 0)
                    {
                        return MotorEnableStatus.Unknown;
                    }

                    if (enable == 1)
                    {
                        return MotorEnableStatus.Enabled;
                    }

                    if (enable == 0)
                    {
                        return MotorEnableStatus.Disabled;
                    }

                    return MotorEnableStatus.Unknown;
                }
            }
            catch
            {
                return MotorEnableStatus.Unknown;
            }
        }

        // TODO: 厂家确认 cmd 的双向定义后，在此处增加真实使能设置方法，
        // 并按 RobotVer 调用 IMC100_MotorEnable(cmd, RobotId)，且复用 _motorEnableStatusLock。

        int IRobotInovance.RobotId { get => _config.RobotId; set => _config.RobotId = value; }
        public PrgState ProgramState => GetPrgState();
        public int PrgStart(int vel)
        {
            int ret = 0;
            try
            {
                string alarm = "";
                ret = GetSysAlarm(out alarm);
                if (ret != 0 || !alarm.IsNullOrEmpty())
                {
                    ResetErr();
                }

                switch (RobotVer)
                {
                    case RobotVer.S0321R20:
                        {
                            Thread.Sleep(500);
                            ret = IMC100API_S0321R20.IMC100_Set_Mode(2, RobotId);
                            if (ret != 0)
                            {
                                throw new Exception($"IMC100_Set_Mode -> {ret}");
                            }

                            Thread.Sleep(1200);
                            int enable = 0;
                            ret = IMC100API_S0321R20.IMC100_Get_MotorSts(ref enable, RobotId);
                            if (ret != 0 || enable != 1)
                            {
                                throw new Exception("上使能失败");
                            }

                            Thread.Sleep(300);
                            ret = PrgStop();
                            if (ret != 0)
                            {
                                throw new Exception("停止失败");
                            }

                            Thread.Sleep(2000);
                            ret = IMC100API_S0321R20.IMC100_BackStartLine(RobotId);
                            if (ret != 0)
                            {
                                throw new Exception($"IMC100_BackStartLine -> {ret}");
                            }

                            Thread.Sleep(2000);
                        }
                        break;

                    case RobotVer.V4R24:
                        {
                            Thread.Sleep(500);
                            ret = IMC100API_V4R24.IMC100_Set_Mode(2, RobotId);
                            if (ret != 0)
                            {
                                throw new Exception($"IMC100_Set_Mode -> {ret}");
                            }

                            Thread.Sleep(1200);
                            int enable = 0;
                            ret = IMC100API_V4R24.IMC100_Get_MotorSts(ref enable, RobotId);
                            if (ret != 0 || enable != 1)
                            {
                                throw new Exception("上使能失败");
                            }

                            Thread.Sleep(300);
                            ret = PrgStop();
                            if (ret != 0)
                            {
                                throw new Exception("停止失败");
                            }

                            Thread.Sleep(2000);
                            ret = IMC100API_V4R24.IMC100_BackStartLine(RobotId);
                            if (ret != 0)
                            {
                                throw new Exception($"IMC100_BackStartLine -> {ret}");
                            }

                            Thread.Sleep(2000);
                        }
                        break;

                    default:
                        throw new Exception(nameof(RobotVer));
                }

                ret = PrgContinue();
            }
            catch (Exception ex)
            {
                LogAdd($"PrgStart：{ex.Message}", LogLevel.Warn);
            }
            return ret;
        }
        /// <summary>
        /// 设置速度
        /// </summary>
        /// <param name="vel"></param>
        /// <returns></returns>
        public int SetVel(int vel)
        {
            int ret = -1;
            try
            {
                vel = Math.Max(1, vel);
                vel = Math.Min(100, vel);

                switch (RobotVer)
                {
                    case RobotVer.S0321R20:
                        {
                            if ((ret = IMC100API_S0321R20.IMC100_Set_Vel(vel, RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_Set_Vel -> {ret}");
                            }
                        }
                        break;

                    case RobotVer.V4R24:
                        {
                            if ((ret = IMC100API_V4R24.IMC100_Set_Vel(vel, RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_Set_Vel -> {ret}");
                            }
                        }
                        break;

                    default:
                        throw new Exception(nameof(RobotVer));
                }
            }
            catch (Exception ex)
            {
                LogAdd($"SetVel：{ex.Message}", LogLevel.Warn);
            }
            return ret;
        }
        /// <summary>
        /// 获取速度
        /// </summary>
        /// <param name="vel"></param>
        /// <returns></returns>
        public int GetVel(ref int vel)
        {
            int ret = -1;
            try
            {
                switch (RobotVer)
                {
                    case RobotVer.S0321R20:
                        {
                            if ((ret = IMC100API_S0321R20.IMC100_Get_Vel(ref vel, RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_Get_Vel -> {ret}");
                            }
                        }
                        break;

                    case RobotVer.V4R24:
                        {
                            if ((ret = IMC100API_V4R24.IMC100_Get_Vel(ref vel, RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_Get_Vel -> {ret}");
                            }
                        }
                        break;

                    default:
                        throw new Exception(nameof(RobotVer));
                }
            }
            catch (Exception ex)
            {
                LogAdd($"GetVel：{ex.Message}", LogLevel.Warn);
            }
            return ret;
        }
        public int PrgPause()
        {
            int ret = -1;
            try
            {
                switch (RobotVer)
                {
                    case RobotVer.S0321R20:
                        {
                            if ((ret = IMC100API_S0321R20.IMC100_PrgCtrl(0, RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_PrgCtrl -> {ret}");
                            }
                        }
                        break;

                    case RobotVer.V4R24:
                        {
                            if ((ret = IMC100API_V4R24.IMC100_PrgCtrl(0, RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_PrgCtrl -> {ret}");
                            }
                        }
                        break;

                    default:
                        throw new Exception(nameof(RobotVer));
                }
            }
            catch (Exception ex)
            {
                LogAdd($"PrgPause：{ex.Message}", LogLevel.Warn);
            }
            return ret;
        }
        public int PrgContinue()
        {
            int ret = -1;
            try
            {
                switch (RobotVer)
                {
                    case RobotVer.S0321R20:
                        {
                            if ((ret = IMC100API_S0321R20.IMC100_PrgCtrl(1, RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_PrgCtrl -> {ret}");
                            }
                        }
                        break;

                    case RobotVer.V4R24:
                        {
                            if ((ret = IMC100API_V4R24.IMC100_PrgCtrl(1, RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_PrgCtrl -> {ret}");
                            }
                        }
                        break;

                    default:
                        throw new Exception(nameof(RobotVer));
                }
            }
            catch (Exception ex)
            {
                LogAdd($"PrgContinue：{ex.Message}", LogLevel.Warn);
            }
            return ret;
        }
        public int PrgStop()
        {
            int ret = -1;
            try
            {
                switch (RobotVer)
                {
                    case RobotVer.S0321R20:
                        {
                            if ((ret = IMC100API_S0321R20.IMC100_PrgCtrl(0, RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_PrgCtrl -> {ret}");
                            }
                        }
                        break;

                    case RobotVer.V4R24:
                        {
                            if ((ret = IMC100API_V4R24.IMC100_PrgCtrl(0, RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_PrgCtrl -> {ret}");
                            }
                        }
                        break;

                    default:
                        throw new Exception(nameof(RobotVer));
                }
            }
            catch (Exception ex)
            {
                LogAdd($"PrgStop：{ex.Message}", LogLevel.Warn);
            }
            return ret;
        }
        public PrgState GetPrgState()
        {
            int ret;
            int state = 0;
            PrgState prgState = PrgState.未知状态;
            try
            {
                switch (RobotVer)
                {
                    case RobotVer.S0321R20:
                        {
                            if ((ret = IMC100API_S0321R20.IMC100_Get_MotionSts(ref state, RobotId)) == 0)
                            {
                                switch (state)
                                {
                                    case 0:
                                        prgState = PrgState.停止_运动完成;
                                        break;

                                    case 1:
                                        prgState = PrgState.运动中;
                                        break;

                                    case 2:
                                        prgState = PrgState.运动中断;
                                        break;

                                    default:
                                        prgState = PrgState.未知状态;
                                        break;
                                }
                            }
                            else
                            {
                                throw new Exception($"IMC100_Get_PrgSts <= {ret}");
                            }
                        }
                        break;

                    case RobotVer.V4R24:
                        {
                            if ((ret = IMC100API_V4R24.IMC100_Get_MotionSts(ref state, RobotId)) == 0)
                            {
                                switch (state)
                                {
                                    case 0:
                                        prgState = PrgState.停止_运动完成;
                                        break;

                                    case 1:
                                        prgState = PrgState.运动中;
                                        break;

                                    case 2:
                                        prgState = PrgState.运动中断;
                                        break;

                                    default:
                                        prgState = PrgState.未知状态;
                                        break;
                                }
                            }
                            else
                            {
                                throw new Exception($"IMC100_Get_PrgSts <= {ret}");
                            }
                        }
                        break;

                    default:
                        throw new Exception(nameof(RobotVer));
                }
            }
            catch (Exception ex)
            {
                LogAdd($"GetPrgState：{ex.Message}", LogLevel.Warn);
            }
            return prgState;
        }
        public int GetMotionState()
        {
            int ret = -1;
            int state = -1;
            try
            {
                switch (RobotVer)
                {
                    case RobotVer.S0321R20:
                        {
                            if ((ret = IMC100API_S0321R20.IMC100_Get_MotionSts(ref state, RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_Get_MotionSts -> {ret}");
                            }
                            else
                            {
                                ret = state;
                            }
                        }
                        break;

                    case RobotVer.V4R24:
                        {
                            if ((ret = IMC100API_V4R24.IMC100_Get_MotionSts(ref state, RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_Get_MotionSts -> {ret}");
                            }
                            else
                            {
                                ret = state;
                            }
                        }
                        break;

                    default:
                        throw new Exception(nameof(RobotVer));
                }
            }
            catch (Exception ex)
            {
                LogAdd($"GetMotionState：{ex.Message}", LogLevel.Warn);
            }
            return ret;
        }
        public int GetSysAlarm(out string sysAlarm)
        {
            int ret = -1;
            try
            {
                int iStop = 0;
                int iErr = 0;
                sysAlarm = "";
                switch (RobotVer)
                {
                    case RobotVer.S0321R20:
                        {

                            if ((ret = IMC100API_S0321R20.IMC100_Get_EStopSts(ref iStop, RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_Get_EStopSts -> {ret}");
                            }
                            else
                            {
                                if (iStop == 1)
                                {
                                    if (IMC100API_S0321R20.IMC100_EmergStop(0, RobotId) != 0)
                                    {
                                        throw new Exception("Robot Emergency Stop Pressed");
                                    }
                                }
                            }

                            if ((ret = IMC100API_S0321R20.IMC100_Get_SysErr(ref iErr, RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_Get_SysErr -> {ret}");
                            }
                            else
                            {
                                if (iErr != 0)
                                {
                                    sysAlarm = $"当前系统故障码：0x{iErr:X4}";
                                    LogAdd(sysAlarm, LogLevel.Trace);
                                }
                            }
                        }
                        break;

                    case RobotVer.V4R24:
                        {

                            if ((ret = IMC100API_V4R24.IMC100_Get_EStopSts(ref iStop, RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_Get_EStopSts -> {ret}");
                            }
                            else
                            {
                                if (iStop == 1)
                                {
                                    if (IMC100API_V4R24.IMC100_EmergStop(0, RobotId) != 0)
                                    {
                                        throw new Exception("Robot Emergency Stop Pressed");
                                    }
                                }
                            }

                            if ((ret = IMC100API_V4R24.IMC100_Get_SysErr(ref iErr, RobotId)) != 0)
                            {
                                throw new Exception($"IMC100_Get_SysErr -> {ret}");
                            }
                            else
                            {
                                if (iErr != 0)
                                {
                                    sysAlarm = $"当前系统故障码：0x{iErr:X4}";
                                    LogAdd(sysAlarm, LogLevel.Trace);
                                }
                            }
                        }
                        break;

                    default:
                        throw new Exception(nameof(RobotVer));
                }
            }
            catch (Exception ex)
            {
                sysAlarm = ex.Message;
                LogAdd($"GetSysAlarm：{ex.Message}", LogLevel.Warn);
                throw ex;
            }
            return ret;
        }
        public int ResetErr()
        {
            int ret;
            switch (RobotVer)
            {
                case RobotVer.S0321R20:
                    {
                        if ((ret = IMC100API_S0321R20.IMC100_ResetErr(RobotId)) != 0)
                        {
                            throw new Exception($"IMC100_ResetErr -> {ret}");
                        }
                    }
                    break;

                case RobotVer.V4R24:
                    {
                        if ((ret = IMC100API_V4R24.IMC100_ResetErr(RobotId)) != 0)
                        {
                            throw new Exception($"IMC100_ResetErr -> {ret}");
                        }
                    }
                    break;

                default:
                    throw new Exception(nameof(RobotVer));
            }
            return ret;
        }
        public RobotPos GetActualPos()
        {
            switch (RobotVer)
            {
                case RobotVer.S0321R20:
                    {
                        ROBOT_POS_S0321R20 robot_Pos = new ROBOT_POS_S0321R20();
                        int ret = IMC100API_S0321R20.IMC100_Get_PosHereC(ref robot_Pos, RobotId);
                        if (ret == 0)
                        {
                            return new RobotPos
                            {
                                X = robot_Pos.pos[0],
                                Y = robot_Pos.pos[1],
                                Z = robot_Pos.pos[2],
                                A = robot_Pos.pos[3],
                                B = robot_Pos.pos[4],
                                C = robot_Pos.pos[5],
                            };
                        }
                        else
                        {
                            LogAdd($"IMC100_Get_PosHereC -> {ret}", LogLevel.Warn);
                            return null;
                        }
                    }

                case RobotVer.V4R24:
                    {
                        ROB_POS_V4R24 robot_Pos = new ROB_POS_V4R24();
                        int ret = IMC100API_V4R24.IMC100_Get_RobPosHere(ref robot_Pos, RobotId);
                        if (ret == 0)
                        {
                            return new RobotPos
                            {
                                X = robot_Pos.RPosData[0],
                                Y = robot_Pos.RPosData[1],
                                Z = robot_Pos.RPosData[2],
                                A = robot_Pos.RPosData[3],
                                B = robot_Pos.RPosData[4],
                                C = robot_Pos.RPosData[5],
                            };
                        }
                        else
                        {
                            LogAdd($"IMC100_Get_PosHereC -> {ret}", LogLevel.Warn);
                            return null;
                        }
                    }

                default:
                    return null;
            }
        }
        public RobotPos GetActualPos(int toolNum, int wobjNum, int loadNum)
        {
            switch (RobotVer)
            {
                case RobotVer.S0321R20:
                    {
                        LogAdd($"未开发", LogLevel.Warn);
                        return null;
                    }

                case RobotVer.V4R24:
                    {
                        ROB_JPOS_V4R24 robot_Pos_Src = new ROB_JPOS_V4R24();
                        ROB_POS_V4R24 robot_Pos_Des = new ROB_POS_V4R24();
                        int ret = IMC100API_V4R24.IMC100_Get_RobJPosHere(ref robot_Pos_Src, RobotId);
                        if (ret != 0)
                        {
                            LogAdd($"IMC100_Get_RobJPosHere -> {ret}", LogLevel.Warn);
                            return null;
                        }

                        IMC100API_V4R24.IMC100_Get_RobJToRobP(ref robot_Pos_Src, toolNum, wobjNum, loadNum, ref robot_Pos_Des, RobotId);
                        if (ret == 0)
                        {
                            return new RobotPos
                            {
                                X = robot_Pos_Des.RPosData[0],
                                Y = robot_Pos_Des.RPosData[1],
                                Z = robot_Pos_Des.RPosData[2],
                                A = robot_Pos_Des.RPosData[3],
                                B = robot_Pos_Des.RPosData[4],
                                C = robot_Pos_Des.RPosData[5],
                            };
                        }
                        else
                        {
                            LogAdd($"IMC100_Get_RobJToRobP -> {ret}", LogLevel.Warn);
                            return null;
                        }
                    }

                default:
                    return null;
            }
        }
        public int WriteBVar(int address, int val)
        {
            int ret;
            switch (RobotVer)
            {
                case RobotVer.S0321R20:
                    {
                        if ((ret = IMC100API_S0321R20.IMC100_Set_B(address, val, RobotId)) != 0)
                        {
                            LogAdd($"IMC100_Set_B -> {ret}", LogLevel.Warn);
                        }
                    }
                    break;

                case RobotVer.V4R24:
                    {
                        if ((ret = IMC100API_V4R24.IMC100_Set_B(address, val, RobotId)) != 0)
                        {
                            LogAdd($"IMC100_Set_B -> {ret}", LogLevel.Warn);
                        }
                    }
                    break;

                default:
                    throw new Exception(nameof(RobotVer));
            }
            return ret;
        }
        public int ReadBVar(int address, out int val)
        {
            int ret;
            int value = 0;
            val = 0;
            switch (RobotVer)
            {
                case RobotVer.S0321R20:
                    {
                        if ((ret = IMC100API_S0321R20.IMC100_Get_B(address, ref value, RobotId)) != 0)
                        {
                            LogAdd($"IMC100_Get_B -> {ret}", LogLevel.Warn);
                        }
                        else
                        {
                            val = value;
                        }
                    }
                    break;

                case RobotVer.V4R24:
                    {
                        if ((ret = IMC100API_V4R24.IMC100_Get_B(address, ref value, RobotId)) != 0)
                        {
                            LogAdd($"IMC100_Get_B -> {ret}", LogLevel.Warn);
                        }
                        else
                        {
                            val = value;
                        }
                    }
                    break;

                default:
                    throw new Exception(nameof(RobotVer));
            }
            return ret;
        }
        public int WriteRVar(int address, int val)
        {
            int ret;
            switch (RobotVer)
            {
                case RobotVer.S0321R20:
                    {
                        if ((ret = IMC100API_S0321R20.IMC100_Set_R(address, val, RobotId)) != 0)
                        {
                            LogAdd($"IMC100_Set_R -> {ret}", LogLevel.Warn);
                        }
                    }
                    break;

                case RobotVer.V4R24:
                    {
                        if ((ret = IMC100API_V4R24.IMC100_Set_R(address, val, RobotId)) != 0)
                        {
                            LogAdd($"IMC100_Set_R -> {ret}", LogLevel.Warn);
                        }
                    }
                    break;

                default:
                    throw new Exception(nameof(RobotVer));
            }
            return ret;
        }
        public int ReadRVar(int address, out int val)
        {
            int ret;
            int value = 0;
            val = 0;
            switch (RobotVer)
            {
                case RobotVer.S0321R20:
                    {
                        if ((ret = IMC100API_S0321R20.IMC100_Get_R(address, ref value, RobotId)) != 0)
                        {
                            LogAdd($"IMC100_Get_R -> {ret}", LogLevel.Warn);
                        }
                        else
                        {
                            val = value;
                        }
                    }
                    break;

                case RobotVer.V4R24:
                    {
                        if ((ret = IMC100API_V4R24.IMC100_Get_R(address, ref value, RobotId)) != 0)
                        {
                            LogAdd($"IMC100_Get_R -> {ret}", LogLevel.Warn);
                        }
                        else
                        {
                            val = value;
                        }
                    }
                    break;

                default:
                    throw new Exception(nameof(RobotVer));
            }
            return ret;
        }
        public int WriteDVar(int address, double val)
        {
            int ret;
            switch (RobotVer)
            {
                case RobotVer.S0321R20:
                    {
                        if ((ret = IMC100API_S0321R20.IMC100_Set_D(address, val, RobotId)) != 0)
                        {
                            LogAdd($"IMC100_Set_D -> {ret}", LogLevel.Warn);
                        }
                    }
                    break;

                case RobotVer.V4R24:
                    {
                        if ((ret = IMC100API_V4R24.IMC100_Set_D(address, val, RobotId)) != 0)
                        {
                            LogAdd($"IMC100_Set_D -> {ret}", LogLevel.Warn);
                        }
                    }
                    break;

                default:
                    throw new Exception(nameof(RobotVer));
            }
            return ret;
        }
        public int ReadDVar(int address, out double val)
        {
            int ret;
            double value = 0;
            val = 0;
            switch (RobotVer)
            {
                case RobotVer.S0321R20:
                    {
                        if ((ret = IMC100API_S0321R20.IMC100_Get_D(address, ref value, RobotId)) != 0)
                        {
                            LogAdd($"IMC100_Get_D -> {ret}", LogLevel.Warn);
                        }
                        else
                        {
                            val = value;
                        }
                    }
                    break;

                case RobotVer.V4R24:
                    {
                        if ((ret = IMC100API_V4R24.IMC100_Get_D(address, ref value, RobotId)) != 0)
                        {
                            LogAdd($"IMC100_Get_D -> {ret}", LogLevel.Warn);
                        }
                        else
                        {
                            val = value;
                        }
                    }
                    break;

                default:
                    throw new Exception(nameof(RobotVer));
            }
            return ret;
        }
        #endregion



        #region IMotionCard
        public string ConfigFilePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DevIndex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void LoadConfigFile(string filePath)
        {
            throw new NotImplementedException();
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="msg">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示弹窗；false：不显示弹窗；</param>
        public void LogAdd(string msg, LogLevel lv, int id = 0, bool isShowDialog = false)
        {
            msg = $"{Name} -> " + msg;
            string tempId = $"{(int)lv}{(int)PrimLogId.PrimRobotInovancePro}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, PrimLogId.PrimRobotInovancePro.ToString(), LogClassification.VisioPrim, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
            }
        }

        /// <summary>日志</summary>
        /// <param name="msg">信息</param>
        /// <param name="lv">日志等级</param>
        internal void LogAddAuthority(string msg, LogLevel lv)
        {
            msg = $"{AuthorityManager.Instance.CurrentUserName} > {Name} > " + msg;

            LogHelper.LogAdd(lv, msg, PrimLogId.PrimRobotInovancePro.ToString(), LogClassification.VisioPrim, 0L);
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// 重连
        /// </summary>
        /// <param name="token"></param>
        private void ReConnect(CancellationToken token)
        {
            while (true)
            {
                for (int i = 0; i < 500; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }

                    Thread.Sleep(10);
                }

                int val = -1;
                switch (RobotVer)
                {
                    case RobotVer.S0321R20:
                        {
                            if (IMC100API_S0321R20.IMC100_CurCtrlDev(ref val, RobotId) != 0 || val != 2)
                            {
                                if (PrimRunStat == PrimRunState.Running)
                                {
                                    IsConnecting = true;
                                    IPrimTaskStop();
                                }

                                for (int i = 0; i < 200; i++)
                                {
                                    if (token.IsCancellationRequested)
                                    {
                                        return;
                                    }

                                    Thread.Sleep(10);
                                }
                            }
                        }
                        break;

                    case RobotVer.V4R24:
                        {
                            if (IMC100API_V4R24.IMC100_CurCtrlDev(ref val, RobotId) != 0 || val != 2)
                            {
                                if (PrimRunStat == PrimRunState.Running)
                                {
                                    IsConnecting = true;
                                    IPrimTaskStop();
                                }

                                for (int i = 0; i < 200; i++)
                                {
                                    if (token.IsCancellationRequested)
                                    {
                                        return;
                                    }

                                    Thread.Sleep(10);
                                }
                            }
                        }
                        break;

                    default:
                        throw new Exception(nameof(RobotVer));
                }

                if (!IsConnecting && PrimRunStat != PrimRunState.Running)
                {
                    IPrimTaskInit();
                }
            }
        }
        #endregion
    }
}
