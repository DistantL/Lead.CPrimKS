using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;
using Lead.CPrim.XmlHelper;
using Lead.CPrim.LogHelper;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.Interfaces.Robot;
using System.Net;
using System.Threading;
using System.Drawing;

namespace Lead.CPrim.PrimRobotMitsubishi
{
    public class PrimRobotMitsubishi : IPrim, IIoModule, IRobotMitsubishi, IMotionCard
    {
        #region Field
        public string[] PosArray { get; set; } = new string[6];
        private List<string> programList = new List<string>();
        private string Operationstatus = string.Empty;
        private string s15_0I = string.Empty;
        private string s31_16I = string.Empty;
        private string s15_0Q = string.Empty;
        private string s31_16Q = string.Empty;
        private string strValue = string.Empty;
        private Control _primDebugUI = null;
        private PrimConfigControl _primConfigUI = null;
        private Control _primOutputUI = null;
        public RobotMitSubishiConfig _config = null;
        public Dictionary<string, string> robotkVePairs = null;
        #endregion


        #region Prop
        public int robotID { get; set; } = -1;
        public int Status { get; set; }
        public int ERR { get; set; }
        public string Error { get; set; } = "";
        public double Speed { get; set; }

        public AxMELFARXMLib.AxMelfaRxM AxMelfaRxM
        {
            get => _primConfigUI.AxMelfaRxM;
            set => _primConfigUI.AxMelfaRxM = value;
        } 
        #endregion


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
        public int CurrentImageIndex 
        {
            get => _config.CurrentImageIndex;
            set => _config.CurrentImageIndex = value;
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
        public bool PrimEnable
        {
            set => _config.PrimEnable = value;
            get => _config.PrimEnable;
        }
        public int RobotId
        {
            set => _config.RobotId = value;
            get => _config.RobotId;
        }
        public string MainFunc
        {
            set => _config.MainFunName = value;
            get => _config.MainFunName;
        }

        public string VRName
        {
            set => _config.VRName = value;
            get => _config.VRName;
        }

        public Control PrimDebugUI => _primDebugUI;
        public Control PrimConfigUI => _primConfigUI;
        public Control PrimOutputUI => _primOutputUI;
        #endregion


        #region Override Task's Methods
        public int IPrimInit()
        {
            var iRet = 0;
            string result = "";
            if (PrimConnStat == PrimConnState.Connected)
            {
                return 0;
            }
            
            try
            {
                AxMelfaRxM.MsgRecvEvent -= new EventHandler(this.AxMelfaRxM_MsgRecvEvent);
                AxMelfaRxM.MsgRecvEvent += new EventHandler(this.AxMelfaRxM_MsgRecvEvent);

                robotkVePairs = ServerStart();
                if (robotkVePairs == null || robotkVePairs?.Count == 0)
                {
                    result = "机器人服务启动失败";
                    throw new Exception(result);
                }
                var prglis = ConnectRobot(RobotId);
                if (prglis == null || prglis?.Count == 0)
                {
                    result = $"机器人{RobotId}连接失败，或者程序是空";
                    throw new Exception(result);
                }
                string alarm = "";
                if (GetSysAlarm(out alarm) != 0)
                {
                    ResetErr();
                }
                SetConn_RunState(PrimConnState.Connected, PrimRunState.Stop);
            }
            catch (Exception ex)
            {
                result = $"机械手{Name}连接失败，错误原因 =》 {ex.Message}";
                SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Stop);
                return -1;
            }
            return iRet;
        }
        public int IPrimConnect(ref string result)
        {
            result = "";
            
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
            return 0;
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
            ProgramReset();
            ResetErr();
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
                _config = XMLHelper.XMLToObject(xmlNode, typeof(RobotMitSubishiConfig)) as RobotMitSubishiConfig;
            }
            else { return -1; }
            return iRet;
        }
        #endregion


        #region others
        public PrimRobotMitsubishi()
        {
            _config = new RobotMitSubishiConfig();
            _config.HSType = PrimType.Other;
            _config.Manu = PrimManufacture.Lead;

            _primDebugUI = new PrimDebugControl(this);
            _primConfigUI = new PrimConfigControl(this);
            _primOutputUI = new PrimOutputControl();

            SetConn_RunState(PrimConnState.Other, PrimRunState.Other);
        }
        public PrimRobotMitsubishi(XmlNode xmlNode)
        {
            if (xmlNode != null)
            {
                _config = XMLHelper.XMLToObject(xmlNode, typeof(RobotMitSubishiConfig)) as RobotMitSubishiConfig;
            }

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

            return iRet;
        }

        public int ReadDoModule(int startAddr, out uint value)
        {
            int iRet = 0;
            value = 0;

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

            var di = GetNumDI(startAddr);

            if (di == true)
            {
                val = true;
                return 0;
            }
            else if (di == false)
            {
                val = false;
                return 0;
            }
            else
            {
                val = false;
                return -1;
            }
        }
        public int ReadSingleDOutput(double address, out bool val)
        {
            var startAddr = (int)address;
            var di = GetNumDO(startAddr);

            if (di == true)
            {
                val = true;
                return 0;
            }
            else if (di == false)
            {
                val = false;
                return 0;
            }
            else
            {
                val = false;
                return -1;
            }
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
        /// <summary>
        /// 0-31（0-3系统）
        /// </summary>
        /// <param name="address"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public int WriteSingleDOutput(double address, bool val)
        {
            var startAddr = (int)address;
            SetDO(startAddr, val);
            var bl = GetNumDO(startAddr);
            if (bl == val)
                return 0;
            else
                return -1;
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


        #region Override IRobotMitsubishi
        public int EnableRobot(bool bl)
        {
            var bol = ServoOnOff(bl);
            return bol ? 0 : -1;
        }
        public int PrgStart(int vel)
        {
            string alarm;
            int ret = GetSysAlarm(out alarm);
            if (ret != 0)
            {
                ResetErr();
            }

            Speed = vel;

            return RunProg(MainFunc, vel) ? 0 : -1;
        }
        public int PrgPause()
        {
            return PauseProgram() ? 0 : -1;
        }
        public int PrgContinue()
        {
            if (GetPrgState() == PrgState.Running)
            {
                return 0;
            }
            if (Speed <= 0) return -1;

            return RunProg(MainFunc, (int)Speed) ? 0 : -1;
        }
        public int PrgStop()
        {
            if (GetPrgState() != PrgState.Running)
            {
                return 0;
            }

            return StopProgram() ? 0 : -1;
        }
        public PrgState GetPrgState()
        {

            string stateBin = GetProgramSt(1);
            string state = "";

            if (!string.IsNullOrEmpty(stateBin))
            {
                var ch = stateBin.ToCharArray();//注意顺序
                if (ch[15 - 0] == '1') state += "急停，";
                if (ch[15 - 2] == '1') { state += " Paused，"; }
                else { state += " Running，"; }
                if (ch[15 - 10] == '1') state += "Machine lock on，";
                else state += "Machine lock off，";
                if (ch[15 - 11] == '0') state += "AUTO mode，";
                else state += "TEACH mode，";
                if (ch[15 - 13] == '1') state += "Servo on，";
                else state += "Servo off，";
                if (ch[15 - 14] == '1') state += "operating，";
                else state += "Stopped，";
            }

            return GetNumDO(0) == true ? PrgState.Running : PrgState.Pause;
        }
        public int GetSysAlarm(out string sysAlarm)
        {
            sysAlarm = "";
            bool? err = GetNumDO(2);//Q - 2 总报警指示
            if (err == false)
                return 0;
            else
            {
                sysAlarm = Error;
                return -1;
            }
        }
        public bool ResetErr()
        {
            int status = AxMelfaRxM.RequestServiceM(robotID, 407, 0, null, 0, 0, 0);

            return status == 0 ? false : true;
        }
        public RobotPos GetActualPos()
        {
            RobotPos robotPos = new RobotPos();

            string[] pos = PosArray;
            if (pos != null && pos.Length == 6)
            {
                robotPos.X = double.Parse(pos[0]);
                robotPos.Y = double.Parse(pos[1]);
                robotPos.Z = double.Parse(pos[2]);
                robotPos.A = double.Parse(pos[3]);
                robotPos.B = double.Parse(pos[4]);
                robotPos.C = double.Parse(pos[5]);
                return robotPos;
            }
            else
                return null;
        }
        public int WriteFloatVar(int address, double val)
        {
            SetVariable(VRName, $"M_Float{address}", val);
            double? iVal = GetFloatVariable(1, $"M_Float{address}");
            if (iVal == null) return -1;
            return val == Math.Round((double)iVal, 4) ? 0 : -1;
        }
        public int ReadFloatVar(int slotNum, int address, out double val)
        {
            val = 0;
            double? iVal = GetFloatVariable(slotNum, $"M_Float{address}");
            if (iVal == null)
                return -1;
            else
            {
                val = (double)iVal;
                val = Math.Round((double)val, 4);
                return 0;
            }
        }
        public int ReadIntVar(int slotNum, int address, out int val)
        {
            val = 0;
            double? iVal = GetFloatVariable(slotNum, $"M_Int{address}");
            if (iVal == null)
                return -1;
            else
            {
                val = (int)iVal;
                return 0;
            }
        }
        public int WriteIntVar(int address, int val)
        {
            SetVariable(VRName, $"M_Int{address}", val);
            double? iVal = GetFloatVariable(1, $"M_Int{address}");
            return val == iVal ? 0 : -1;
        }
        #endregion


        #region Override IMotionCard
        public string ConfigFilePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DevIndex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public void LoadConfigFile(string filePath)
        {
            throw new NotImplementedException();
        } 
        #endregion


        /// <summary>使能</summary>   
        /// <param name="onOff">true：使能；false：下使能</param>
        /// <returns></returns>
        private bool ServoOn_Off(bool onOff)
        {
            string sdata;
            int status;

            if (onOff)
                sdata = string.Format("1\n1");
            else
                sdata = string.Format("1\n0");

            status = AxMelfaRxM.RequestServiceM(robotID, 403, sdata.Length, sdata, 0, 0, 0);
            if (status == 0)
            {
                return false;
            }
            return true;
        }
        private bool ServoOnOff(bool onOff)
        {
            ServoOn_Off(onOff);
            Thread.Sleep(1000);////使能之后，休眠等待一会，读取使能标志信号（DO-1）
            var bol = GetNumDO(1);

            return onOff == bol;
        }
        /// <summary>启动服务</summary>
        /// <returns></returns>
        private Dictionary<string, string> ServerStart()
        {
            bool ret = true;
            if (AxMelfaRxM.ServerLive() == false)
            {
                ret = AxMelfaRxM.ServerStart();
            }
            if (!ret) return null;

            var dics = GetRoboComSet();
            return dics;
        }
        /// <summary>关闭服务</summary>
        private bool ServerKill()
        {
            ServoOnOff(false);
            return AxMelfaRxM.ServerKill();
        }
        /// <summary>机器人列表获取</summary>
        /// <returns></returns>
        private Dictionary<string, string> GetRoboComSet()
        {
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            try
            {
                int rcnt = 0;
                string data = "";
                string key = "", value = "";
                System.Threading.Thread.Sleep(2000);    // wait 2sec
                AxMelfaRxM.GetRoboComSetting(ref rcnt, ref data);

                for (int i = 0; i < rcnt; ++i)  // Loop Robots
                {
                    AxMelfaRxM.GetOneDataCPP(i * 2, data, ref key);
                    AxMelfaRxM.GetOneDataCPP(i * 2 + 1, data, ref value);
                    keyValues.Add(key, value);
                }
                this.robotkVePairs = keyValues;
            }
            catch
            {
                return null;
            }
            return keyValues;
        }
        /// <summary>连接机器人，读取子程序,开启速度位置报警服务</summary>
        /// <param name="m_robotID">机器人ID</param>
        /// <returns></returns>
        private List<string> ConnectRobot(int m_robotID)
        {
            programList = new List<string>();
            var bl = InitOpPanel(m_robotID);
            if (!bl) return null;
            var taskRes = Task.Run(() =>
            {
                var vbol = SpinWait.SpinUntil(() => programList?.Count() != 0, 4000);

                SpeedPositionServer(m_robotID);

                WarnMessageServer(m_robotID);

                return programList;

            });
            return taskRes.Result;
        }
        private bool InitOpPanel(int m_robotID)
        {
            if (!AxMelfaRxM.CheckConnectingM(m_robotID))
            {
                MessageBox.Show($"{m_robotID}号机器人，Un-connecting!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Read list of robot programs
            int status = AxMelfaRxM.RequestServiceM(m_robotID, 106, 0, null, 1, 0, 0);
            if (status == 0)
            {
                MessageBox.Show("读取机器人程序列表失败", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                this.robotID = m_robotID;
                return true;
            }
        }
        /// <summary>位置同步服务</summary>
        /// <param name="robotID"></param>
        /// <returns></returns>
        private bool SpeedPositionServer(int robotID)
        {
            string sdata;
            int status;

            // Monitoring the position (interval 500ms)
            sdata = string.Format("1\n1\n1");
            status = AxMelfaRxM.RequestServiceM(robotID, 235, sdata.Length, sdata, 0, 500, 0);

            if (status == 0)
            {
                return false;
            }

            return true;
        }
        /// <summary>报警服务</summary>
        /// <param name="robotID"></param>
        /// <returns></returns>
        private bool WarnMessageServer(int robotID)
        {
            int status = AxMelfaRxM.RequestServiceM(robotID, 203, 0, null, 0, 1000, 0);
            if (status == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>请求</summary>
        /// <param name="MsgID">功能码</param>
        /// <param name="data">数据</param>
        /// <param name="CycleTime">扫描周期</param>
        /// <param name="disp">是否显示进度</param>
        public void RequestService(int MsgID, string data, int CycleTime = 0, bool disp = false)
        {
            if (!AxMelfaRxM.CheckConnectingM(robotID))
            {
                MessageBox.Show("Un-connecting!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int dispInt = disp ? 1 : 0;
                // Check value
                if ((MsgID < 100) || (MsgID > 499))
                {
                    MessageBox.Show("Req ID is 100 - 499.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if ((CycleTime < 0) || (CycleTime > 30000))
                {
                    MessageBox.Show("CycleTime is 0 - 30000.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Send Request
                int status;
                status = AxMelfaRxM.RequestService2NullM(robotID, MsgID, data, dispInt, CycleTime, 0);
                if (status != 1)
                {
                    MessageBox.Show("Request Error!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public bool RequestCancel(int MsgID)
        {
            if (!AxMelfaRxM.CheckConnectingM(robotID))
            {
                MessageBox.Show("Un-connecting!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Send Request Cancel
            int status;
            status = AxMelfaRxM.RequestCancelM(robotID, MsgID);
            if (status != 1)
            {
                MessageBox.Show("Request Cancel Error!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        /// <summary>获取状态指令</summary>
        /// <param name="slot"></param>
        /// <returns></returns>
        private bool GetProgramState(int slot)
        {
            int status;
            string sdata = string.Format($"{slot}");
            status = AxMelfaRxM.RequestServiceM(robotID, 242, sdata.Length, sdata, 0, 0, 0);
            if (status == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>读取程序状态</summary>
        /// <param name="slot">槽号</param>
        /// <returns>16位二进制字符串</returns>
        public string GetProgramSt(int slot)
        {
            Operationstatus = "";

            var bl = GetProgramState(slot);
            if (!bl) return null;

            var taskRes = Task.Run(() =>
            {
                var vbol = SpinWait.SpinUntil(() => Operationstatus.Length == 16, 5000);
                if (vbol == false)
                    return null;
                else
                {
                    return Operationstatus;
                }
            });
            return taskRes.Result;

        }

        #region 程序
        /// <summary>设置速度</summary>      
        /// <param name="speed">速度百分比</param>
        /// <returns></returns>
        private bool SetSpeed(int speed)
        {
            if (speed > 100 || speed < 1)
                return false;

            string sdata = string.Format($"{speed}");
            int status = AxMelfaRxM.RequestServiceM(robotID, 404, sdata.Length, sdata, 0, 0, 0);
            if (status == 0)
            {
                return false;
            }
            return true;
        }
        private bool StartProgram(string prgname)
        {
            string sdata;
            int status;

            sdata = string.Format("1\n{0}\n0", prgname);
            status = AxMelfaRxM.RequestServiceM(robotID, 400, sdata.Length, sdata, 0, 0, 0);
            if (status == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>暂停程序</summary>      
        /// <returns></returns>
        private bool PauseProgram()
        {
            string sdata;
            int status;

            sdata = string.Format("0");
            status = AxMelfaRxM.RequestServiceM(robotID, 401, sdata.Length, sdata, 0, 0, 0);
            if (status == 0)
            {
                return false;

            }
            return true;
        }
        /// <summary>停止程序循环</summary>
        /// <returns></returns>
        private bool StopProgram()
        {
            string sdata;
            int status;

            sdata = string.Format("0");
            status = AxMelfaRxM.RequestServiceM(robotID, 406, sdata.Length, sdata, 0, 0, 0);
            if (status == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>程序复位</summary>      
        /// <returns></returns>
        private bool ProgramReset()
        {
            int status;

            status = AxMelfaRxM.RequestServiceM(robotID, 408, 0, null, 0, 0, 0);
            if (status == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>运行 继续 程序</summary>
        /// <param name="prgname">程序名称</param>
        /// <param name="speed">速度</param>
        /// <returns></returns>
        private bool RunProg(string prgname, int speed)
        {
            var bl1 = ServoOnOff(true);
            var bl2 = SetSpeed(speed);
            var bl3 = StartProgram(prgname);
            Thread.Sleep(2000);
            var bl4 = GetPrgState() == PrgState.Running;

            return bl1 && bl2 && bl3 && bl4;
        }
        #endregion

        #region 变量操作
        /// <summary>获取string</summary>
        /// <param name="slot"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool GetStrVariable(int slot, string name)
        {
            string sdata = string.Format($"{slot}\n1\n{name}\n1");
            int status = AxMelfaRxM.RequestServiceM(robotID, 212, sdata.Length, sdata, 0, 0, 0);
            if (status == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>获取点位信息</summary>
        /// <param name="slot"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool GetPointVariable(int slot, string name)
        {
            string sdata = string.Format($"{slot}\n1\n{name}\n2");
            int status = AxMelfaRxM.RequestServiceM(robotID, 212, sdata.Length, sdata, 0, 0, 0);
            if (status == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>获取float  int变量</summary>
        /// <param name="slot"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool GetFloatIntVariable(int slot, string name)
        {
            string sdata = string.Format($"{slot}\n1\n{name}\n0");
            int status = AxMelfaRxM.RequestServiceM(robotID, 212, sdata.Length, sdata, 0, 0, 0);
            if (status == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>变量写值</summary>       
        /// <param name="program">程序名称</param>
        /// <param name="name">变量名</param>
        /// <param name="val">值</param>
        /// <returns></returns>
        public bool SetVariable(string program, string name, double val)
        {
            string sdata = string.Format($"{program}\n1\n{name}={val}");
            int status = AxMelfaRxM.RequestServiceM(robotID, 213, sdata.Length, sdata, 0, 0, 0);
            if (status == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>获取float数据变量值</summary>
        /// <param name="slot">机架号</param>
        /// <param name="name">变量名称</param>
        /// <returns></returns>
        public float? GetFloatVariable(int slot, string name)
        {
            strValue = "";

            var bl = GetFloatIntVariable(slot, name);
            if (!bl) return null;

            var taskRes = Task.Run<float?>(() =>
            {
                var vbol = SpinWait.SpinUntil(() => strValue != "", 5000);
                if (vbol == false)
                    return null;
                else
                {
                    float intFloatVal;
                    var strs = strValue.Split(new char[] { '=' });
                    if (strs.Length != 2) return null;
                    var re = float.TryParse(strs[1], out intFloatVal);
                    if (re) return intFloatVal;
                    else return null;

                }
            });
            return taskRes.Result;
        }
        /// <summary>获取字符串</summary>
        /// <param name="slot"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetString(int slot, string name)
        {
            strValue = "";
            var bl = GetStrVariable(slot, name);
            if (!bl) return null;

            var taskRes = Task.Run(() =>
            {
                var vbol = SpinWait.SpinUntil(() => strValue != "", 5000);
                if (vbol == false)
                    return "";
                else
                {
                    return strValue.Split(new char[] { '=' })[1];
                }
            });
            return taskRes.Result;
        }
        /// <summary>获取点位值</summary>
        /// <param name="slot">机架号</param>
        /// <param name="name">变量</param>
        /// <returns></returns>
        public string GetPoint(int slot, string name)
        {
            strValue = "";
            var bl = GetPointVariable(slot, name);
            if (!bl) return null;

            var taskRes = Task.Run(() =>
            {
                var vbol = SpinWait.SpinUntil(() => strValue != "", 5000);
                if (vbol == false)
                    return "";
                else
                {

                    var strs = strValue.Split(new char[] { '=' });
                    if (strs.Length == 2)
                    {
                        return strs[1];
                    }

                    else return "";
                }
            });
            return taskRes.Result;
        }
        #endregion

        #region 输入输出:  I / O
        /// <summary>获取I/O状态</summary>
        /// <returns></returns>
        private bool GetDIDO()
        {
            string sdata = string.Format($"2\n0\n1\n2\n0\n1");
            int status = AxMelfaRxM.RequestServiceM(robotID, 214, sdata.Length, sdata, 0, 0, 0);
            return status == 0 ? false : true;
        }
        private bool? Get15_0DI(int num)
        {
            if (num > 15 || num < 0) return null;
            num = 15 - num;

            string s = s15_0I.Substring(num, 1);
            bool bl;

            bl = s == "1";

            return bl;
        }
        private bool? Get31_16DI(int num)
        {
            if (num < 16 || num > 31) return null;
            num = 31 - num;

            string s = s31_16I.Substring(num, 1);
            bool bl = false;
            bl = s == "1";

            return bl;
        }
        private bool? Get15_0DO(int num)
        {
            if (num > 15 || num < 0) return null;
            num = 15 - num;

            string s = s15_0Q.Substring(num, 1);
            bool bl;

            bl = s == "1";

            return bl;
        }
        private bool? Get31_16DO(int num)
        {
            if (num < 16 || num > 31) return null;
            num = 31 - num;

            string s = s31_16Q.Substring(num, 1);
            bool bl = false;
            bl = s == "1";

            return bl;
        }
        private bool SetDO31_16(string val)
        {
            string sdata = string.Format($"16\n{val}");
            int status = AxMelfaRxM.RequestServiceM(robotID, 215, sdata.Length, sdata, 0, 0, 0);
            if (status == 0)
            {
                return false;
            }
            return true;
        }
        private bool SetDO15_0(string val)
        {
            string sdata = string.Format($"0\n{val}");
            int status = AxMelfaRxM.RequestServiceM(robotID, 215, sdata.Length, sdata, 0, 0, 0);
            if (status == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>获取输入信号值</summary>
        /// <param name="num">编号</param>
        /// <returns></returns>
        public bool? GetNumDI(int num)
        {
            s15_0I = "";
            s31_16I = "";
            var res = GetDIDO();
            if (!res)
                return null;
            var taskRes = Task.Run(() =>
            {

                if (num < 16)
                {
                    var vbol = SpinWait.SpinUntil(() => s15_0I?.Count() == 16, 3000);
                    if (vbol == false)
                        return null;
                    else
                        return Get15_0DI(num);
                }
                else
                {
                    var vbol = SpinWait.SpinUntil(() => s31_16I?.Count() == 16, 3000);
                    if (vbol == false)
                        return null;
                    else
                        return Get31_16DI(num);
                }
            });
            return taskRes.Result;
        }
        /// <summary>获取输出信号值</summary>
        /// <param name="num">编号</param>
        /// <returns></returns>
        public bool? GetNumDO(int num)
        {
            s15_0Q = "";
            s31_16Q = "";
            var res = GetDIDO();
            if (!res) return null;

            var taskRes = Task.Run(() =>
            {
                if (num < 16)
                {
                    var vbol = SpinWait.SpinUntil(() => s15_0Q?.Count() == 16, 3000);
                    if (vbol == false)
                        return null;
                    else
                        return Get15_0DO(num);
                }
                else
                {
                    var vbol = SpinWait.SpinUntil(() => s31_16Q?.Count() == 16, 3000);
                    if (vbol == false)
                        return null;
                    else
                        return Get31_16DO(num);
                }
            });
            return taskRes.Result;
        }
        /// <summary>写输出</summary>
        /// <param name="num"></param>
        /// <param name="bol"></param>
        /// <returns></returns>
        public bool SetDO(int num, bool bol)
        {
            s15_0Q = "";
            s31_16Q = "";
            var res = GetDIDO();
            if (!res) return false;
            var taskRes = Task.Run(() =>
            {

                if (num < 16)
                {
                    var vbol = SpinWait.SpinUntil(() => s15_0Q?.Count() == 16, 3000);
                    if (vbol == false)
                        return false;
                    else
                    {
                        char[] chs = s15_0Q.ToCharArray();
                        chs[15 - num] = bol ? '1' : '0';
                        var int15_0 = Convert.ToInt32(string.Join("", chs), 2);
                        return SetDO15_0(Convert.ToString(int15_0, 16));

                    }
                }
                else
                {
                    var vbol = SpinWait.SpinUntil(() => s31_16Q?.Count() == 16, 3000);
                    if (vbol == false)
                        return false;
                    else
                    {
                        char[] chs = s31_16Q.ToCharArray();
                        chs[31 - num] = bol ? '1' : '0';
                        var int31_16 = Convert.ToInt32(string.Join("", chs), 2);
                        return SetDO31_16(Convert.ToString(int31_16, 16));

                    }
                }
            });

            return taskRes.Result;
        }
        #endregion

        // Recveive event processing
        private void AxMelfaRxM_MsgRecvEvent(object sender, EventArgs e)
        {
            int robotID = 0;
            int msgID = 0;
            int Status = 0;
            int Error = 0;
            string data = "";

            int ret = AxMelfaRxM.GetRecvDataM(ref robotID, ref msgID, ref data, ref Status, ref Error);
            if (ret == 1)
            {
                int count = AxMelfaRxM.GetDataCnt(data);
                string sMsg = "";
                for (int i = 0; i < count; ++i)
                {
                    string sOneData = AxMelfaRxM.GetOneData(i, data);
                    sMsg = sMsg + sOneData + "\r\n";
                }
                this.Status = Status;
                this.ERR = Error;
                switch (msgID)
                {
                    case 242://程序状态
                        try
                        {
                            string proNum = AxMelfaRxM.GetOneData(2, data);
                            string strState = AxMelfaRxM.GetOneData(5, data);
                            Operationstatus = Convert.ToString(Convert.ToInt16(strState, 16), 2).PadLeft(16, '0');

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 212://变量
                        try
                        {
                            strValue = AxMelfaRxM.GetOneData(2, data);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 214://IO点位
                        try
                        {
                            string sIData0 = AxMelfaRxM.GetOneData(2, data);
                            s15_0I = Convert.ToString(Convert.ToInt16(sIData0, 16), 2).PadLeft(16, '0');

                            string sIData1 = AxMelfaRxM.GetOneData(4, data);
                            s31_16I = Convert.ToString(Convert.ToInt16(sIData1, 16), 2).PadLeft(16, '0');

                            string sQData0 = AxMelfaRxM.GetOneData(7, data);
                            s15_0Q = Convert.ToString(Convert.ToInt16(sQData0, 16), 2).PadLeft(16, '0');

                            string sQData1 = AxMelfaRxM.GetOneData(9, data);
                            s31_16Q = Convert.ToString(Convert.ToInt16(sQData1, 16), 2).PadLeft(16, '0');

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    // Get the Robot Program list
                    case 106:
                        try
                        {
                            string tmp = "";
                            programList = new List<string>();
                            AxMelfaRxM.GetOneDataCPP(0, data, ref tmp);
                            var count1 = int.Parse(tmp);
                            for (int i = 0; i < count1; ++i)
                            {
                                tmp = "";
                                AxMelfaRxM.GetOneDataCPP(i * 12 + 1, data, ref tmp);
                                string[] tmp2 = tmp.Split('.');
                                programList.Add(tmp2[0]);
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    // Get the Error No
                    case 203:
                        try
                        {
                            string tmp = "";
                            this.Error = "";
                            AxMelfaRxM.GetOneDataCPP(0, data, ref tmp);
                            var count2 = int.Parse(tmp);

                            for (int i = 0; i < count2; ++i)
                            {
                                this.Error += "\r\n";
                                tmp = "";
                                AxMelfaRxM.GetOneDataCPP(i * 8 + 1, data, ref tmp);    // Error No.
                                this.Error += tmp + " : ";
                                AxMelfaRxM.GetOneDataCPP(i * 8 + 2, data, ref tmp);    // Error Message
                                this.Error += tmp + " [ ";
                                AxMelfaRxM.GetOneDataCPP(i * 8 + 3, data, ref tmp);    // Date
                                this.Error += tmp + " / ";
                                AxMelfaRxM.GetOneDataCPP(i * 8 + 4, data, ref tmp);    // Time
                                this.Error += tmp + " ] ";
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    // Get robot current position ,speed
                    case 235:
                        try
                        {
                            string tmp = "";
                            string Pos = "";
                            for (int i = 0; i < 6; ++i)
                            {
                                tmp = "";
                                AxMelfaRxM.GetOneDataCPP(i + 16, data, ref tmp);
                                Pos += (tmp + ",");
                            }
                            Pos = Pos.Trim(',');
                            PosArray = Pos.Split(',');
                            AxMelfaRxM.GetOneDataCPP(13, data, ref tmp);
                            this.Speed = double.Parse(tmp);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("接收机器人书失败，请重启机器人通讯器", "Error");
            }
        }
    }
}
