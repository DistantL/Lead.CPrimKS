using IMC100APIDLL;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.Interfaces.Robot;
using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace Lead.Cprim.PrimRobotInovance
{
    public class PrimRobotInovance : IPrim, IIoModule, IRobotInovance, IMotionCard
    {
        private Control _primDebugUI = null;
        private Control _primConfigUI = null;
        private Control _primOutputUI = null;
        public RobotInovanceConfig _config = null;

        #region Override IPrim's Property
        public string Name
        {
            set => _config.Name = value;
            get => _config.Name;
        }
        public Guid Id
        {
            set => _config.Id = value;
            get => _config.Id;
        }
        public string PrimTypeName
        {
            set => _config.PrimTypeName = value;
            get => _config.PrimTypeName;
        }
        public PrimType HSType
        {
            set => _config.HSType = value;
            get => _config.HSType;
        }
        public PrimVer Ver
        {
            set => _config.Ver = value;
            get => _config.Ver;
        }
        public int CurrentImageIndex { get; set; }
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
        public bool PrimEnable
        {
            set => _config.PrimEnable = value;
            get => _config.PrimEnable;
        }
        public string RobotIp
        {
            set => _config.RobotIp = value;
            get => _config.RobotIp;
        }
        public int Port
        {
            set => _config.Port = value;
            get => _config.Port;
        }
        public string Password
        {
            set => _config.Password = value;
            get => _config.Password;
        }
        public int RobotId
        {
            set => _config.RobotId = value;
            get => _config.RobotId;
        }
        public LogLevel PrimAlarmLv { get; set; }
        public RunMode PrimRunMode { get; set; }
        public Control PrimDebugUI => _primDebugUI;
        public Control PrimConfigUI => _primConfigUI;
        public Control PrimOutputUI => _primOutputUI;
        #endregion

        #region Override Task's Methods
        public int IPrimInit()
        {
            var iRet = 0;
            if (PrimRunStat == PrimRunState.Running)
            {
                return 0;
            }
            int ComId = RobotId;
            int ret = IMC100API.IMC100_Exit_ETH(ComId);
            SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Stop);
            return iRet;
        }
        public int IPrimConnect(ref string result)
        {
            result = "";
            if (PrimConnStat == PrimConnState.Connected)
            {
                return 0;
            }
            try
            {
                byte[] bytes = IPAddress.Parse(RobotIp).GetAddressBytes();
                Array.Reverse(bytes);
                UInt32 IpAddr = BitConverter.ToUInt32(bytes, 0);
                UInt16 IpPort = (UInt16)Port;
                int ComId = RobotId;
                Int32 type = 2;//管理模式
                Byte[] password = new Byte[8];
                password = System.Text.Encoding.Default.GetBytes(Password);

                if (IMC100API.IMC100_Init_ETH(IpAddr, IpPort, 5, ComId) != 0)
                {
                    return -1;
                }
                if (IMC100API.IMC100_AcqPermit(1, RobotId) < 0)
                {
                    return -2;
                }
                if (IMC100API.IMC100_UserLogin(type, password, RobotId) < 0)
                {
                    return -3;
                }

                for (int i = 0; i < 100; i++)
                {
                    int iValue = 0;
                    GetCurCtrlDev(ref iValue);
                    if (iValue == 2)
                    {
                        // LogAdd($"{Name} 机器人初始化连接成功", LogLevel.Info, 0);
                        break;
                    }
                    else if (i > 10)
                    {
                        //超时未获得管理权
                        //LogAdd($"{Name} 机器人,初始化连接后未获得管理权", LogLevel.Info, 0);
                        return -4;
                    }
                    Thread.Sleep(500);
                }
                string alarm = "";
                switch (GetSysAlarm(out alarm))
                {
                    case 0:
                        break;
                    case 1:
                        ResetErr();
                        break;
                    case 2:
                        return -4;
                    default:
                        return -5;
                }
                SetConnState(PrimConnState.Connected);
            }
            catch (Exception)
            {
                result = Name + "连接机械手失败！";
                PrimConnStat = PrimConnState.UnConnected;
            }
            return 0;
        }
        public int IPrimStart()
        {
            var iRet = 0;

            if (PrimConnStat != PrimConnState.Connected)
            {
                return -1;
            }
            if (PrimRunStat == PrimRunState.Running)
            {
                return 0;
            }
            SetRunState(PrimRunState.Running);
            return iRet;
        }
        public int IPrimStop()
        {
            var iRet = 0;
            int mode = 1;//示教模式
            IMC100API.IMC100_Set_Mode(mode, RobotId);
            iRet = IMC100API.IMC100_Exit_ETH(RobotId);
            SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Stop);

            return iRet;
        }
        public int IPrimDispose()
        {
            SetConn_RunState(PrimConnState.Other, PrimRunState.Other);
            return 0;
        }
        public int IPrimTaskInit()
        {
            if (IPrimInit() != 0)
            {
                return -1;
            }
            var connRet = "";
            if (IPrimConnect(ref connRet) != 0)
            {
                return -2;
            }
            if (IPrimStart() != 0)
            {
                return -3;
            }
            return 0;
        }

        public int IPrimTaskPause()
        {
            return IMC100API.IMC100_PrgCtrl(0, RobotId);
        }

        public int IPrimTaskReset()
        {
            if (IPrimReset() != 0)
            {
                return -1;
            }
            return 0;
        }
        public int IPrimReset()
        {
            var iRet = 0;
            return iRet;
        }

        public int IPrimTaskStop()
        {
            if (IPrimStop() != 0)
            {
                return -1;
            }
            return 0;
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
        public XmlNode IPrimExportConfigXml()
        {
            if (_config == null) { return null; }
            var node = XMLHelper.ObjectToXML(_config);
            return node;
        }

        public int IPrimImportConfigXml(XmlNode xmlNode)
        {
            var iRet = 0;
            if (xmlNode != null)
            {
                _config = XMLHelper.XMLToObject(xmlNode, typeof(RobotInovanceConfig)) as RobotInovanceConfig;
            }
            else { return -1; }
            return iRet;
        }
        #endregion

        #region others
        public PrimRobotInovance()
        {
            _config = new RobotInovanceConfig();

            _config.HSType = PrimType.Other;
            _config.Manu = PrimManufacture.Lead;

            _primDebugUI = new PrimDebugControl(this);
            _primConfigUI = new PrimConfigControl(this);
            _primOutputUI = new PrimOutputControl();

            SetConn_RunState(PrimConnState.Other, PrimRunState.Other);
        }

        public PrimRobotInovance(XmlNode xmlNode)
        {
            if (xmlNode != null)
            {
                _config = XMLHelper.XMLToObject(xmlNode, typeof(RobotInovanceConfig)) as RobotInovanceConfig;
            }
            else { return; }

            _config.HSType = PrimType.Other;
            _config.Manu = PrimManufacture.Lead;

            _primDebugUI = new PrimDebugControl(this);
            _primConfigUI = new PrimConfigControl(this);
            _primOutputUI = new PrimOutputControl();

            SetConn_RunState(PrimConnState.Other, PrimRunState.Other);
        }
        public void SetConn_RunState(PrimConnState conn, PrimRunState run)
        {
            PrimConnStat = conn;
            PrimRunStat = run;
            ((PrimConfigControl)_primConfigUI).SetPrimConnState(conn);
            ((PrimConfigControl)_primConfigUI).SetPrimRunState(run);
        }

        public void SetConnState(PrimConnState conn)
        {
            PrimConnStat = conn;
            ((PrimConfigControl)_primConfigUI).SetPrimConnState(conn);
        }
        public void SetRunState(PrimRunState run)
        {
            PrimRunStat = run;
            ((PrimConfigControl)_primConfigUI).SetPrimRunState(run);
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

            iRet = IMC100API.IMC100_Get_DI(startAddr, ref valueTemp, RobotId);
            value = (uint)valueTemp;

            return iRet;
        }

        public int ReadDoModule(int startAddr, out uint value)
        {
            int iRet = 0;
            value = 0;
            int valueTemp = 0;

            iRet = IMC100API.IMC100_Get_DO(startAddr, ref valueTemp, RobotId);
            value = (uint)valueTemp;

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
            var startAddr = (int)address;
            int value = 0;
            if (IMC100API.IMC100_Get_DI(startAddr, ref value, RobotId) == 0)
            {
                val = value == 1;
                return 0;
            }
            val = false;
            return -1;
        }
        public int ReadSingleDOutput(double address, out bool val)
        {
            var startAddr = (int)address;
            int value = 0;
            if (IMC100API.IMC100_Get_DO(startAddr, ref value, RobotId) == 0)
            {
                val = value == 1;
                return 0;
            }
            val = false;
            return -1;
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
            var startAddr = (int)address;
            int value = 0;
            int iRet = IMC100API.IMC100_Get_DO(startAddr, ref value, RobotId);
            if (iRet == 0)
            {
                if (val)
                {
                    return IMC100API.IMC100_Set_DO(startAddr, 1, RobotId);
                }
                else
                {
                    return IMC100API.IMC100_Set_DO(startAddr, 0, RobotId);
                }

            }
            return iRet;
        }

        public int ClearEventOnDIStateChanged()
        {
            if (OnDIStateChanged == null) { return 1; }

            foreach (var d in OnDIStateChanged.GetInvocationList())
            {
                OnDIStateChanged -= d as DIStateChanged;
            }

            return 0;
        }

        public int ClearEventOnDOStateChanged()
        {
            if (OnDOStateChanged == null) { return 1; }

            foreach (var d in OnDOStateChanged.GetInvocationList())
            {
                OnDOStateChanged -= d as DOStateChanged;
            }

            return 0;
        }
        #endregion

        #region Override IRobotInovance

        //public int PrgStart(string path, int vel)
        //{
        //    int iRet = 0;
        //    String _path = path;
        //    Byte[] prgPath = new Byte[128];
        //    prgPath = System.Text.Encoding.Default.GetBytes(_path);
        //    PrgStop();
        //    string alarm = "";
        //    iRet = GetSysAlarm(out alarm);
        //    if (iRet == 1)
        //    {
        //        ResetErr();
        //    }
        //    iRet = IMC100API.IMC100_Set_CurPrgPath(prgPath, RobotId);
        //    if (iRet < 0)
        //    {
        //        return iRet;
        //    }
        //    iRet = IMC100API.IMC100_Set_Vel(Setvel(vel), RobotId);
        //    if (iRet < 0)
        //    {
        //        return iRet;
        //    }
        //    iRet = IMC100API.IMC100_Set_Mode(2, RobotId);
        //    if (iRet < 0)
        //    {
        //        return iRet;
        //    }
        //    Thread.Sleep(1200);
        //    int enableSts = 0;
        //    for (int i = 0; i < 5; i++)
        //    {
        //        iRet = IMC100API.IMC100_Get_MotorSts(ref enableSts, RobotId);
        //        if (enableSts == 0)
        //        {
        //            Thread.Sleep(500);
        //            if (i == 4)
        //            {
        //                return -50;
        //            }
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //    return PrgContinue();
        //}

        public int PrgStart(int vel)
        {
            int iRet = 0;
            iRet = GetSysAlarm(out string alarm);
            if (iRet == 1)
            {
                ResetErr();
            }

            iRet = IMC100API.IMC100_MotorEnable(1, RobotId);
            if (iRet < 0)
            {
                return iRet;
            }

            int enableSts = 0;
            for (int i = 0; i < 5; i++)
            {
                IMC100API.IMC100_Get_MotorSts(ref enableSts, RobotId);
                if (enableSts == 0)
                {
                    Thread.Sleep(500);
                    if (i == 4)
                    {
                        return -50;
                    }
                }
                else
                {
                    break;
                }
            }

            iRet = IMC100API.IMC100_Set_Mode(2, RobotId);
            if (iRet < 0)
            {
                return iRet;
            }

            PrgStop();

            IMC100API.IMC100_BackStartLine(RobotId);

            iRet = IMC100API.IMC100_Set_Vel(Setvel(vel), RobotId);
            if (iRet < 0)
            {
                return iRet;
            }

            return PrgContinue();
        }

        private int Setvel(int vel)
        {
            if (vel > 100)
            {
                return 100;
            }
            else if (vel < 0)
            {
                return 0;
            }
            else
            {
                return vel;
            }
        }

        public int PrgPause()
        {
            return IMC100API.IMC100_PrgCtrl(0, RobotId);
        }

        public int PrgContinue()
        {
            return IMC100API.IMC100_PrgCtrl(1, RobotId);
        }

        public int PrgStop()
        {
            return IMC100API.IMC100_PrgCtrl(0, RobotId);
        }
        public PrgState ProgramState
        {
            get
            {
                try
                {
                    return GetPrgState();
                }
                catch (Exception)
                {

                }
                return PrgState.运动中断;
            }
        }

        public PrgState GetPrgState()
        {
            int sts = 0;
            if (IMC100API.IMC100_Get_MotionSts(ref sts, RobotId) >= 0)
            {
                switch (sts)
                {
                    case 0:
                        return PrgState.停止_运动完成;

                    case 1:
                        return PrgState.运动中;

                    case 2:
                        return PrgState.运动中断;

                    default:
                        return PrgState.未知状态;
                }
            }
            else
            {
                throw new Exception("获取机器人程序运行状态异常!");
            }
        }

        public int GetMotionState()
        {
            int iSts = 0;
            int iRet = IMC100API.IMC100_Get_MotionSts(ref iSts, RobotId);
            if (iRet < 0)
            {
                return iRet;
            }
            return iSts;
        }

        /// <summary>
        ///获取当前控制权所在  0-示教器，1-InoRobShop平台，2-远程以太网设备，3-远端IO，4-远端modbus
        /// </summary>
        /// <param name="dev"></param>
        /// <returns></returns>
        public int GetCurCtrlDev(ref int dev)
        {
            return IMC100API.IMC100_CurCtrlDev(ref dev, RobotId);
        }
        /// <summary>
        /// 获取当前用户类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetCurUserType(ref int type)
        {
            return IMC100API.IMC100_CurUserType(ref type, RobotId);
        }
        /// <summary>
        /// 使能机器人
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int ServoEnable(bool value)
        {
            int command = value ? 1 : 0;
            return IMC100API.IMC100_MotorEnable(command, RobotId);
        }

        public int GetSysAlarm(out string sysAlarm)
        {
            int iErr = 0;
            int iStop = 0;
            int iRet = IMC100API.IMC100_Get_SysErr(ref iErr, RobotId);  //显示机器人故障
            int iRet1 = IMC100API.IMC100_Get_EStopSts(ref iStop, RobotId);
            if (iRet >= 0)
            {
                if (iStop == 1)
                {
                    sysAlarm = "机器人急停被按下！";
                    return 2;
                }
                if (iErr == 0)
                {
                    sysAlarm = "0";
                    return 0;
                }
                else
                {
                    sysAlarm = iErr.ToString();
                    return 1;
                }
            }
            else if (iRet == -255)
            {
                throw new Exception("机器人网络通讯异常！");
            }
            sysAlarm = iRet.ToString();
            return -1;
        }
        public int ResetErr()
        {
            return IMC100API.IMC100_ResetErr(RobotId);
        }

        public RobotPos GetActualPos()
        {
            RobotPos robotPos = new RobotPos();
            ROBOT_POS robot_Pos = new ROBOT_POS();
            int iRet = IMC100API.IMC100_Get_PosHereC(ref robot_Pos, RobotId);
            if (iRet >= 0)
            {
                robotPos.X = robot_Pos.pos[0];
                robotPos.Y = robot_Pos.pos[1];
                robotPos.Z = robot_Pos.pos[2];
                robotPos.A = robot_Pos.pos[3];
                robotPos.B = robot_Pos.pos[4];
                robotPos.C = robot_Pos.pos[5];

                return robotPos;
            }
            return null;
        }

        public RobotPos GetActualPos(int toolNum, int wobjNum, int loadNum)
        {
            throw new NotImplementedException();
        }

        public int WriteBVar(int address, int val)
        {
            return IMC100API.IMC100_Set_B(address, val, RobotId);
        }

        public int ReadBVar(int address, out int val)
        {
            int iVal = 0;
            int iRet = IMC100API.IMC100_Get_B(address, ref iVal, RobotId);
            val = iVal;
            return iRet;
        }

        public int WriteRVar(int address, int val)
        {
            return IMC100API.IMC100_Set_R(address, val, RobotId);
        }

        public int ReadRVar(int address, out int val)
        {
            int iVal = 0;
            int iRet = IMC100API.IMC100_Get_R(address, ref iVal, RobotId);
            val = iVal;
            return iRet;
        }

        public int WriteDVar(int address, double val)
        {
            return IMC100API.IMC100_Set_D(address, val, RobotId);
        }

        public int ReadDVar(int address, out double val)
        {
            double iVal = 0;
            int iRet = IMC100API.IMC100_Get_D(address, ref iVal, RobotId);
            val = iVal;
            return iRet;
        }
        #endregion

        public string ConfigFilePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DevIndex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public void LoadConfigFile(string filePath)
        {
            throw new NotImplementedException();
        }

        public int SetVel(int vel)
        {
           var iRet = IMC100API.IMC100_Set_Vel(Setvel(vel), RobotId);
            if (iRet < 0)
            {
                return iRet;
            }
            return 0;
        }
    }
}
