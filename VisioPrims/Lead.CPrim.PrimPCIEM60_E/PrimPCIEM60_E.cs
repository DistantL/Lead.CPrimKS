using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Newtonsoft.Json.Linq;
using Sunny.UI.Win32;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Lead.CPrim.PrimPCIEM60_E
{
    public class PrimPCIEM60_E : IPrim, IMotionCard, IAxis, IIoModule, IInterpolation, ICmpTrig, IEtherCAT
    {
        #region 全局变量
        private PCIEM60_EConfig _config = null;

        /// <summary>
        /// 连接状态
        /// </summary>
        PrimConnState _primConnStat;

        /// <summary>
        /// 运行状态
        /// </summary>
        PrimRunState _primRunStat;

        private IOInfos _ioInfos = null;
        private Control _primConfigUI = null;
        private Control _primDebugUI = null;
        private Control _primOutputUI = null;

        private bool _cycleCycleReadIOFlag = false;
        private bool _cycleCycleReadMotionFlag = false;
        private Thread _taskCycleReadIO = null;
        private Thread _taskCycleReadMotion = null;

        private object _lockAxisesMove = new object();
        private object _lockAxisesHome = new object();

        //所有需要触发改变事件的DI首地址
        private List<int> DiChangeAdr = new List<int>();
        private List<double> DiFallList = new List<double>();
        private List<double> DiRiseList = new List<double>();

        ecat_motion.CrdBlockData crdBlockData;  //速度前瞻内存区域
        #endregion



        #region Prop
        public EBusConfig EBusConfig { get; set; }

        #endregion



        #region EBusConfig映射

        public ConcurrentDictionary<int, ConcurrentDictionary<int, uint>> DiModules
        {
            get => EBusConfig.DiModules;
            set => EBusConfig.DiModules = value;
        }

        public ConcurrentDictionary<int, ConcurrentDictionary<int, uint>> DoModules
        {
            get => EBusConfig.DoModules;
            set => EBusConfig.DoModules = value;
        }

        public ConcurrentDictionary<int, EAiModule> AiModules
        {
            get => EBusConfig.AiModules;
            set => EBusConfig.AiModules = value;
        }

        public ConcurrentDictionary<int, EAoModule> AoModules
        {
            get => EBusConfig.AoModules;
            set => EBusConfig.AoModules = value;
        }

        public ConcurrentDictionary<int, EAxis> Axises
        {
            get => EBusConfig.Axises;
            set => EBusConfig.Axises = value;
        }

        public int TotalDiModuleNum
        {
            get => EBusConfig.TotalDiModuleNum;
            set => EBusConfig.TotalDiModuleNum = value;
        }

        public int TotalDoModuleNum
        {
            get => EBusConfig.TotalDoModuleNum;
            set => EBusConfig.TotalDoModuleNum = value;
        }

        public int TotalAiModuleNum
        {
            get => EBusConfig.TotalAiModuleNum;
            set => EBusConfig.TotalAiModuleNum = value;
        }

        public int TotalAoModuleNum
        {
            get => EBusConfig.TotalAoModuleNum;
            set => EBusConfig.TotalAoModuleNum = value;
        }

        public int TotalIoNum
        {
            get => EBusConfig.TotalIoNum;
            set => EBusConfig.TotalIoNum = value;
        }

        public int TotalAxisNum
        {
            get => EBusConfig.TotalAxisNum;
            set => EBusConfig.TotalAxisNum = value;
        }

        public int TotalSlaveNum
        {
            get => EBusConfig.TotalSlaveNum;
            set => EBusConfig.TotalSlaveNum = value;
        }
        #endregion


        #region Ctor
        public PrimPCIEM60_E()
        {
            _config = new PCIEM60_EConfig();
            _ioInfos = new IOInfos();
            ImportEBusConfig();

            _primDebugUI = new PrimDebugControl(this);
            _primConfigUI = new PrimConfigControl(this);
            _primOutputUI = new PrimOutputControl();

            PrimConnStat = PrimConnState.Other;
            PrimRunStat = PrimRunState.Other;
        }

        public PrimPCIEM60_E(XmlNode primConfig)
        {
            _config = XMLHelper.XMLToObject(primConfig, typeof(PCIEM60_EConfig)) as PCIEM60_EConfig;
            if (_config == null)
            {
                throw new NullReferenceException("Config Is Null");
            }
            ImportEBusConfig();

            _primDebugUI = new PrimDebugControl(this);
            _primConfigUI = new PrimConfigControl(this);
            _primOutputUI = new PrimOutputControl();

            PrimConnStat = PrimConnState.Other;
            PrimRunStat = PrimRunState.Other;
        }
        #endregion



        #region 实现IPrim接口
        public Guid Id { get => _config.Id; set => _config.Id = value; }
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

        public bool PrimEnable { get => _config.PrimEnable; set => _config.PrimEnable = value; }

        public PrimType HSType { set; get; } = PrimType.MoionCard;

        public string PrimTypeName { get => _config.PrimTypeName; set => _config.PrimTypeName = value; }

        public Control PrimConfigUI => _primConfigUI;

        public Control PrimDebugUI => _primDebugUI;

        public Control PrimOutputUI => _primOutputUI;
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

        public event DIStateChanged OnDIStateChanged;
        public event DOStateChanged OnDOStateChanged;


        public int IPrimInit()
        {
            try
            {
                if ((PrimRunStat == PrimRunState.Running || PrimRunStat == PrimRunState.Stop) && PrimConnStat == PrimConnState.Connected)
                {
                    return 0;
                }

                // 关闭轴卡，上次没有正常关闭轴卡的情况
                short result = ecat_motion.M_Close((short)DevIndex);
                if (result != 0)
                {
                    throw new Exception($"M_Close <= {result}");
                }
                Thread.Sleep(500);

                // 初始化轴卡
                short option = 1;
                result = ecat_motion.M_Open((short)DevIndex, 0); //连接总线（注：连接总线需要一定的时间，所需时间会随着从站数量的增多而变长）
                if (result != 0)
                {
                    throw new Exception($"M_Open <= {result}");
                }
                if (string.IsNullOrWhiteSpace(ConfigFilePath))
                {
                    MessageBox.Show($"请选择轴卡配置文件");
                    return -2;
                }
                result = ecat_motion.M_SetEmgAction(0, (short)DevIndex);
                if (result != 0)
                {
                    throw new Exception($"M_SetEmgAction <= {result}");
                }
                result = ecat_motion.M_SetEmgInv(0, (short)DevIndex); // 设置轴卡的急停极性,急停极性 → 1:常闭  0：常开
                if (result != 0)
                {
                    throw new Exception($"M_SetEmgInv <= {result}");
                }
                Thread.Sleep(500);

                result = ecat_motion.M_ClrEmg((short)DevIndex);
                if (result != 0)
                {
                    throw new Exception($"M_ClrEmg <= {result}");
                }
                result = ecat_motion.M_ResetFpga((short)DevIndex); // 重置FPGA芯片
                if (result != 0)
                {
                    throw new Exception($"M_ResetFpga <= {result}");
                }
                result = ecat_motion.M_LoadEni(ConfigFilePath, (short)DevIndex); //加载eni.xml文件，该文件为驱动器和远程IO的配置文件
                if (result != 0)
                {
                    throw new Exception($"M_LoadEni <= {result}");
                }
                result = ecat_motion.M_ConnectECAT(option, (short)DevIndex);
                if (result != 0)
                {
                    throw new Exception($"M_ConnectECAT <= {result}");
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
                    throw new Exception(NLocalizer.NotConnected);
                }

                UpdateAxisesAndModules();

                _cycleCycleReadIOFlag = true;
                _taskCycleReadIO = new Thread(CycleReadIO)
                {
                    IsBackground = true
                };
                _taskCycleReadIO.Start();

                _cycleCycleReadMotionFlag = true;
                _taskCycleReadMotion = new Thread(CycleReadMotion)
                {
                    IsBackground = true
                };
                _taskCycleReadMotion.Start();

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
                _cycleCycleReadIOFlag = false;
                _cycleCycleReadMotionFlag = false;
                ecat_motion.M_DisconnectECAT((short)DevIndex);
                ecat_motion.M_Close((short)DevIndex);

                state = true;
            }
            catch (Exception ex)
            {
                Thread.Sleep(1000);
                LogAdd($"IPrimStop_Error：{ex.Message}", LogLevel.Warn);
            }
            finally
            {
                Axises.Clear();
                DiModules.Clear();
                DoModules.Clear();

                _taskCycleReadIO = null;
                _taskCycleReadMotion = null;
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
            _config = XMLHelper.XMLToObject(xmlNode, typeof(PCIEM60_EConfig)) as PCIEM60_EConfig;
            EBusConfig = new EBusConfig();
            _ioInfos = new IOInfos();
            return _config != null ? 0 : -1;
        }

        public int ImportIoInfos()
        {
            if (PrimRunStat == PrimRunState.Running)
            {
                return 0;
            }
            if (!string.IsNullOrEmpty(IOInfosFilePath) && File.Exists(IOInfosFilePath))
            {
                _ioInfos = JsonHelper.DeserializeJsonFileToObject<IOInfos>(IOInfosFilePath);
                foreach (var di in _ioInfos.Di)
                {
                    if (di.EnRiseEvent | di.EnFallEvent)
                    {
                        DiChangeAdr.Add((int)Math.Floor(di.Address));
                        if (di.EnRiseEvent)
                        {
                            DiRiseList.Add(di.Address);
                        }
                        if (di.EnFallEvent)
                        {
                            DiFallList.Add(di.Address);
                        }
                    }
                }
            }
            return 0;
        }

        internal int ImportEBusConfig()
        {
            if (!string.IsNullOrEmpty(EBusConfigFilegPath) && File.Exists(EBusConfigFilegPath))
            {
                EBusConfig = JsonHelper.DeserializeJsonFileToObject<EBusConfig>(EBusConfigFilegPath);
            }

            if (EBusConfig == null)
            {
                EBusConfig = new EBusConfig();
            }

            return 0;
        }

        internal int ExportEBusConfig()
        {
            var ret = false;
            if (!string.IsNullOrEmpty(EBusConfigFilegPath) && EBusConfig != null)
            {
                ret = JsonHelper.SerializeObjectToFile(EBusConfig, EBusConfigFilegPath);
            }
            return ret ? 0 : -1;
        }

        /*
        private void SetAxisParam(EAxis axis)
        {
            AxisSetEnable(axis.Id, false);
            ecat_motion.CmdPrm prm = new ecat_motion.CmdPrm();
            prm.acc = axis.DefaultParam.Acc;
            prm.dec = axis.DefaultParam.Dec;
            prm.sTime = (short)axis.DefaultParam.Curve;
            ecat_motion.M_SetMove(axis.Id, ref prm, (short)DevIndex);   //设置绝对运动默认参数

            short homeMode = 6;
            ecat_motion.M_SetHomingMode(axis.Id, homeMode, (short)DevIndex);    //设置回零模式6：驱动器回零 8：板卡回零

            ecat_motion.M_SetHomingPrm(axis.Id, axis.HomeParam.Mode, axis.HomeParam.Offset, axis.HomeParam.Vs, axis.HomeParam.Ve, axis.HomeParam.Acc, 0, (short)DevIndex);  //设置回零参数

            ecat_motion.M_SetAxisBand(axis.Id, axis.SInpEnable ? axis.SInpError : 0, axis.SInpEnable ? axis.SInpTimes : 0, (short)DevIndex);    //设置Inp信号参数

            AxisSetEnable(axis.Id, true);
            Thread.Sleep(100);
        }*/

        private void CycleReadMotion()
        {
            while (_cycleCycleReadMotionFlag)
            {
                Thread.Sleep(1);
                try
                {
                    int[] axisStateMachine = new int[Axises.Count];
                    double[] encPos = new double[Axises.Count];
                    double[] encVel = new double[Axises.Count];
                    double[] cmdPos = new double[Axises.Count];
                    double[] cmdVel = new double[Axises.Count];
                    short[] cmdret = new short[] { -1, -1, -1, -1, -1 };
                    cmdret[0] = ecat_motion.M_GetSts(1, out axisStateMachine[0], (short)Axises.Count, (short)DevIndex);
                    cmdret[1] = ecat_motion.M_GetEncPos(1, out encPos[0], (short)Axises.Count, (short)DevIndex);
                    cmdret[2] = ecat_motion.M_GetEncVel(1, out encVel[0], (short)Axises.Count, (short)DevIndex);
                    cmdret[3] = ecat_motion.M_GetCmd(1, out cmdPos[0], (short)Axises.Count, (short)DevIndex);
                    cmdret[4] = ecat_motion.M_GetCmdVel(1, out cmdVel[0], (short)Axises.Count, (short)DevIndex);
                    if (cmdret.All(p => p == 0))
                    {
                        var index = 0;
                        foreach (var axisK in Axises)
                        {
                            var axis = axisK.Value;
                            axis.MotionIoStatus = axisStateMachine[index];
                            axis.ActualPos = encPos[index];
                            axis.ActualVel = encVel[index];
                            axis.CmdPos = cmdPos[index];
                            axis.CmdVel = cmdVel[index];
                            index++;
                        }
                    }


                }
                catch (Exception)
                {
                }
            }
        }

        private void CycleReadIO()
        {
            // 阻塞等触发
            while (_cycleCycleReadIOFlag)
            {
                Thread.Sleep(1);
                try
                {
                    foreach (var dis in DiModules.Keys)
                    {
                        foreach (var di in DiModules[dis].Keys)
                        {
                            short InValue = 0;
                            ecat_motion.M_Get_Slave_Digital_Chn_Input((short)dis, (short)di, ref InValue, (short)DevIndex);
                            DiModules[dis].TryUpdate(di, (uint)InValue, DiModules[dis][di]);
                        }
                    }

                    foreach (var dis in DoModules.Keys)
                    {
                        foreach (var di in DoModules[dis].Keys)
                        {
                            short OutValue = 0;
                            ecat_motion.M_Get_Slave_Digital_Chn_Output((short)dis, (short)di, ref OutValue, (short)DevIndex);
                            DoModules[dis].TryUpdate(di, (uint)OutValue, DoModules[dis][di]);
                        }
                    }

                    //for (int i = 1; i <= TotalDiModuleNum; i++)
                    //{
                    //    ecat_motion.M_Get_Digital_Chn_Input((short)i, out short InValue, (short)DevIndex);
                    //    //CheckDiChange(DiModules[i], (uint)InValue, 100 + (i / 16));
                    //    DiModules.TryUpdate(i, (uint)InValue, DiModules[i]);
                    //}

                    //for (int i = 1; i <= TotalDoModuleNum; i++)
                    //{
                    //    ecat_motion.M_Get_Digital_Chn_Output((short)i, out short OutValue, (short)DevIndex);
                    //    DoModules.TryUpdate(i, (uint)OutValue, DoModules[i]);
                    //}
                }
                catch (Exception)
                {
                }
            }
        }

        private int CheckDiChange(uint diValue, uint newValue, int addrHead)
        {
            var ret = 0;
            if (!DiChangeAdr.Contains(addrHead))
            {
                return ret;
            }
            if (diValue != newValue)
            {
                var dif = diValue ^ newValue;
                //下降沿
                foreach (var di in DiFallList)
                {
                    if ((int)Math.Floor(di) != addrHead)
                    {
                        continue;
                    }
                    var idx = (int)Math.Round((di - (int)di) * 100);
                    if ((diValue & (1 << idx)) == 0 && (newValue & (1 << idx)) > 0)
                    {
                        Debug.WriteLine(di.ToString("f2") + "Fail");
                        if (OnDIStateChanged == null)
                        {
                            return ret;
                        }
                        foreach (var del in OnDIStateChanged.GetInvocationList())
                        {
                            Action action = () => { del.Method.Invoke(del.Target, new object[] { di, false, 1 }); };
                            action.BeginInvoke(null, null);
                        }
                        ret = 1;
                    }
                }
                //上升沿
                foreach (var di in DiRiseList)
                {
                    if ((int)Math.Floor(di) != addrHead)
                        continue;
                    var idx = (int)Math.Round((di - (int)di) * 100);
                    if ((diValue & (1 << idx)) > 0 && (newValue & (1 << idx)) == 0)
                    {
                        Debug.WriteLine(di.ToString("f2") + "Rise");
                        if (OnDIStateChanged == null)
                            return ret;

                        foreach (var del in OnDIStateChanged.GetInvocationList())
                        {
                            Action action = () => { del.Method.Invoke(del.Target, new object[] { di, true, 0 }); };
                            action.BeginInvoke(null, null);
                        }
                        ret = 1;
                    }
                }
            }
            return ret;
        }
        #endregion



        #region 实现IMotionCard接口
        public string ConfigFilePath { get => _config.ConfigFilePath; set => _config.ConfigFilePath = value; }
        public int DevIndex { get => _config.DevIndex; set => _config.DevIndex = value; }
        public bool DIChangedEnable { get; set; }
        public bool DOChangedEnable { get; set; }
        public IOInfos IoInfos { get => _ioInfos; set => _ioInfos = value; }
        public string IOInfosFilePath { get => _config.IOInfosFilePath; set => _config.IOInfosFilePath = value; }
        public string EBusConfigFilegPath { get => _config.EBusConfigFilePath; set => _config.EBusConfigFilePath = value; }

        public void LoadConfigFile(string filePath)
        {
            return;
        }
        #endregion


        #region 实现IAxis接口
        public bool AxisInMel(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return false;
            }
            return (Axises[axisIdx].MotionIoStatus & (1 << 6)) != 0;
        }

        public bool AxisInOrigin(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return false;
            }
            return (Axises[axisIdx].MotionIoStatus & (1 << 20)) != 0;
        }

        public bool AxisInPel(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return false;
            }
            return (Axises[axisIdx].MotionIoStatus & (1 << 5)) != 0;
        }

        public bool AxisInSMel(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return false;
            }
            return (Axises[axisIdx].MotionIoStatus & (1 << 5)) != 0;
        }

        public bool AxisInSPel(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return false;
            }
            return (Axises[axisIdx].MotionIoStatus & (1 << 6)) != 0;
        }

        public bool AxisIsAlarm(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return false;
            }
            return (Axises[axisIdx].MotionIoStatus & (1 << 1)) != 0;
        }

        public bool AxisIsEnble(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return false;
            }
            return (Axises[axisIdx].MotionIoStatus & (1 << 9)) != 0;
        }

        public bool AxisIsStop(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return false;
            }
            return (Axises[axisIdx].MotionIoStatus & (1 << 10)) == 0;
        }

        public int AxisResetAlarm(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            var cmdRet = ecat_motion.M_ClrSts(Axises[axisIdx].Id, 1, (short)DevIndex);

            if (cmdRet == 0)
            {
                return 0;
            }

            return cmdRet;
        }

        public bool AxisSignalDStp(int axisIdx)
        {
            return false;
        }

        public bool AxisSignalEmg(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return false;
            }

            short cmdRet = 0;
            ecat_motion.M_GetEmg(ref cmdRet, (short)DevIndex);

            if (cmdRet == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool AxisSignalEz(int axisIdx)
        {
            return false;
        }

        public bool AxisSignalInp(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return false;
            }
            return (Axises[axisIdx].MotionIoStatus & (1 << 11)) != 0;
        }

        public bool AxisSignalOp(int axisIdx)
        {
            return false;
        }

        public bool AxisSignalRdy(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return false;
            }
            ushort statusWord = 0;  //获取伺服状态字
            ecat_motion.M_EcatStatusWord(Axises[axisIdx].Id, ref statusWord, (short)DevIndex);
            return (statusWord & 1) != 0;
        }

        public bool AxisSignalScl(int axisIdx)
        {
            return false;
        }

        public int AxisStopMove(int axisIdx)
        {
            //double dSmoothDec = 50000000.0;       //平滑停止加速度
            //double dEmergencyDec = 50000000.0;    //急停停止加速度
            ////ecat_motion.M_GetStopDec(Axises[axisIdx].Id, out dSmoothDec, out dEmergencyDec, (short)DevIndex);   //先使用轴卡默认的加减速度，后续再调整
            //ecat_motion.M_SetStopDec(Axises[axisIdx].Id, dSmoothDec, dEmergencyDec, (short)DevIndex);
            return ecat_motion.M_StopSingleAxis(Axises[axisIdx].Id, 1, (short)DevIndex);   //0为平滑停止，1急停停止
        }

        public int GetAxisActualVelocity(int axisIdx, ref double velocity)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            if (axisIdx <= Axises.Count)
            {
                velocity = Axises[axisIdx].ActualVel;
            }
            else
            {
                velocity = -999.999;
            }

            return 0;
        }

        public int GetAxisCommand(int axisIdx, ref double command)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            if (axisIdx <= Axises.Count)
            {
                command = Axises[axisIdx].CmdPos;
            }
            else
            {
                command = -999.999;
            }

            return 0;
        }

        public int GetAxisCommandVelocity(int axisIdx, ref double velocity)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            if (axisIdx <= Axises.Count)
            {
                velocity = Axises[axisIdx].CmdVel;
            }
            else
            {
                velocity = -999.999;
            }

            return 0;
        }

        public int GetAxisErrPosition(int axisIdx, ref double errPos)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            if (axisIdx <= Axises.Count)
            {
                errPos = Axises[axisIdx].ErrorPos;
            }
            else
            {
                errPos = 0;
            }

            return 0;
        }

        public int GetAxisPosition(int axisIdx, ref double pos)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            if (axisIdx <= Axises.Count)
            {
                pos = Axises[axisIdx].ActualPos;
            }
            else
            {
                pos = 0;
            }

            return 0;
        }

        public int GetAxisTargetPosition(int axisIdx, ref double targetPos)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            if (axisIdx <= Axises.Count)
            {
                targetPos = Axises[axisIdx].TargetPos;
            }
            else
            {
                targetPos = 0;
            }

            return 0;
        }

        public int GetFeedbackPulse(int axisIdx, ref double position)
        {
            return GetAxisPosition(axisIdx, ref position);
        }

        public int SetAxisFeedbackPulseToCommand(int axisIdx)
        {
            if (!AxisIsStop(axisIdx))
            {
                AxisStopMove(axisIdx);
                Thread.Sleep(500);
            }
            double pos = 0;
            ecat_motion.M_GetEncPos(Axises[axisIdx].Id, out pos, 1, (short)DevIndex);
            return ecat_motion.M_SetCurrentPos(Axises[axisIdx].Id, Convert.ToInt32(pos), (short)DevIndex);  //指令位置和编码器反馈位置同时改变
        }

        public int SetAxisPositionAndFeedbackPulse(int axisIdx, int position)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }
            //指令位置和编码器反馈位置同时设置
            var cmdRet1 = ecat_motion.M_SetCurrentPos(Axises[axisIdx].Id, position, (short)DevIndex);
            //var cmdRet2 = ecat_motion.M_SetCurrentPos(Axises[axisIdx].Id, position, (short)DevIndex);
            return 0;
        }

        public int StopAllAxes()
        {
            foreach (var axis in Axises)
            {
                ecat_motion.M_StopSingleAxis(axis.Value.Id, 1, (short)DevIndex);
            }
            return 0;
        }

        public int AxisAbsMove(int axisId, double pos, double maxVel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !AxisIsEnble(axisId))
            {
                return -1;
            }

            lock (_lockAxisesMove)
            {
                Thread.Sleep(1);
                return ecat_motion.M_AbsMove(Axises[axisId].Id, Convert.ToInt32(pos), maxVel, (short)DevIndex);
            }
        }

        public int AxisChangeVel(int axisId, double newVel)
        {
            return 0;
        }

        public int AxisRelMove(int axisId, double dis, double maxVel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !AxisIsEnble(axisId))
            {
                return -1;
            }

            var distance = dis;
            var vel = maxVel;
            if (distance > Int32.MaxValue)
            {
                distance = Int32.MaxValue;
            }
            if (distance < Int32.MinValue)
            {
                distance = Int32.MinValue;
            }

            if (vel > Int32.MaxValue)
            {
                vel = Int32.MaxValue;
            }
            if (vel < Int32.MinValue)
            {
                vel = Int32.MinValue;
            }

            return ecat_motion.M_RelMove(Axises[axisId].Id, Convert.ToInt32(distance), vel, (short)DevIndex);
        }

        public int AxisSetAcc(int axisId, double acc)
        {
            return SetAccDec((ushort)axisId, acc, -1, -1);
        }

        public int AxisSetAccDec(int axisId, double minVel, double maxVel, double tAcc, double tDec, double stopVel)
        {
            return SetAccDec((ushort)axisId, tAcc, tDec, -1);
        }

        public int AxisSetAccDec(int axisId, double minVel, double maxVel, double tAcc, double tDec, double stopVel, double stTime)
        {
            return SetAccDec((ushort)axisId, tAcc, tDec, (short)stTime);
        }

        public int AxisSetDec(int axisId, double dec)
        {
            return SetAccDec((ushort)axisId, -1, dec, -1);
        }

        /// <summary>
        /// 加减速设置<br/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="acc">加速度（默认值-1，代表不进行加速度设置）</param>
        /// <param name="dec">减速度（默认值-1，代表不进行减速度设置）</param>
        /// <param name="st">S段（默认值-1，代表不进行S段设置）</param>
        /// <returns></returns>
        int SetAccDec(ushort id, double acc = -1, double dec = -1, short st = -1)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            // 此处增加如果值一致，不再进行设置
            bool flagAcc = false;
            bool flagDec = false;
            bool flagSt = false;
            ecat_motion.CmdPrm prm = new ecat_motion.CmdPrm();
            var ret = ecat_motion.M_GetMove(Axises[id].Id, out prm, (short)DevIndex);
            if (ret == 0)
            {
                if (acc != -1 && Math.Abs(prm.acc - acc) > 5)
                {
                    LogAdd($"加速度设置：板卡={prm.acc}，目标值={acc}", LogLevel.Debug);
                    prm.acc = acc;
                    flagAcc = true;
                }
                if (dec != -1 && Math.Abs(prm.dec - dec) > 5)
                {
                    LogAdd($"减速度设置：板卡={prm.dec}，目标值={dec}", LogLevel.Debug);
                    prm.dec = dec;
                    flagDec = true;
                }
                if (st != -1 && Math.Abs(prm.sTime - st) > 5)
                {
                    LogAdd($"S段设置：板卡={prm.sTime}，目标值={st}", LogLevel.Debug);
                    prm.sTime = st;
                    flagSt = true;
                }

                if (flagAcc || flagDec || flagSt)
                {
                    return ecat_motion.M_SetMove(Axises[id].Id, ref prm, (short)DevIndex);
                }
            }
            return ret;
        }

        public int AxisSetElMode(int axisId, bool pelEnable, bool melEnable, StopMode pelStopMode, StopMode melStopMode)
        {
            return 0;
        }

        public int AxisSetEmgMode(int axisId, int mode)
        {
            return 0;
        }

        public int AxisSetEnable(int axisId, bool enable)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return enable ? ecat_motion.M_Servo_On(Axises[axisId].Id, (short)DevIndex) : ecat_motion.M_Servo_Off(Axises[axisId].Id, (short)DevIndex);
        }

        public int AxisSetMaxVel(int axisId, double maxVel)
        {
            return 0;
        }

        public int AxisSetMinVel(int axisId, double minVel)
        {
            return 0;
        }

        public int AxisSetSoftLimit(int axisId, bool sPelEnable, bool sMelEnable, double sPelValue, double sMelValue)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }
            int pValue = 0;
            int sValue = 0;
            ecat_motion.M_GetSoftLimit(Axises[axisId].Id, out pValue, out sValue, (short)DevIndex);
            pValue = (int)sPelValue;
            sValue = (int)sMelValue;
            return ecat_motion.M_SetSoftLimit(Axises[axisId].Id, pValue, sValue, (short)DevIndex);
        }
        public int AxisSetStopDec(int id, int pulse)
        {
            //ecat_motion.M_GetCmdVel((short)id, out double speed, 1, (short)DevIndex);
            //double speedMax = Math.Max(speed, 1000);

            double dec = (1000.0 * 1000.0 / 4) * pulse;
            dec = Math.Min(dec, 20000000000);
            short ret = ecat_motion.M_SetStopDec((short)id, dec, dec, (short)DevIndex);

            /*
            if (ret != 0)
            {
                LogAdd($"轴id = {id}，设置返回值 = {ret}", LogLevel.Warn);
            }
            LogAdd($"轴id = {id}, 脉冲当量 = {pulse}， 设置减速度 = {dec}", LogLevel.Warn);
            ret = ecat_motion.M_GetStopDec((short)id, out double dec1, out double dec2, (short)DevIndex);
            LogAdd($"轴id = {id}，获取返回值 = {ret}", LogLevel.Warn);
            LogAdd($"轴id = {id}，减速度1 = {dec1}", LogLevel.Warn);
            LogAdd($"轴id = {id}，减速度2 = {dec2}", LogLevel.Warn);
            */

            return ret;
        }
        public int AxisSetStopVel(int axisId, double stopVel)
        {
            return 0;
        }

        public int AxisVelMove(int axisId, double maxVel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return ecat_motion.M_Jog(Axises[axisId].Id, maxVel, (short)DevIndex);
        }

        public int AxisHomeMove(int axisId)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }
            var iret = ecat_motion.M_SetHomingMode(Axises[axisId].Id, 6, (short)DevIndex);
            if (iret < 0)   //判断设置回零模式是否成功
            {
                return -100;
            }

            short method = 0;
            int offset = 0;
            uint speed1 = 0;
            uint speed2 = 0;
            uint acc = 0;
            ushort probeFunction = 0;
            ecat_motion.M_GetHomingPrm(Axises[axisId].Id, ref method, ref offset, ref speed1, ref speed2, ref acc, ref probeFunction, (short)DevIndex);
            offset = Axises[axisId].HomeParam.Offset;
            speed1 = Axises[axisId].HomeParam.Vs;
            speed2 = Axises[axisId].HomeParam.Ve;
            acc = Axises[axisId].HomeParam.Acc;
            ecat_motion.M_SetHomingPrm(Axises[axisId].Id, method, offset, speed1, speed2, acc, probeFunction, (short)DevIndex);
            return ecat_motion.M_HomingStart(Axises[axisId].Id, (short)DevIndex);
        }

        public int AxisHomeMove(int axisId, bool asyncMode)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }
            var iret = ecat_motion.M_SetHomingMode(Axises[axisId].Id, 6, (short)DevIndex);
            if (iret < 0)   //判断设置回零模式是否成功
            {
                return -100;
            }
            short method = 0;
            int offset = 0;
            uint speed1 = 0;
            uint speed2 = 0;
            uint acc = 0;
            ushort probeFunction = 0;
            ecat_motion.M_GetHomingPrm(Axises[axisId].Id, ref method, ref offset, ref speed1, ref speed2, ref acc, ref probeFunction, (short)DevIndex);
            offset = Axises[axisId].HomeParam.Offset;
            speed1 = Axises[axisId].HomeParam.Vs;
            speed2 = Axises[axisId].HomeParam.Ve;
            acc = Axises[axisId].HomeParam.Acc;
            ecat_motion.M_SetHomingPrm(Axises[axisId].Id, method, offset, speed1, speed2, acc, probeFunction, (short)DevIndex);
            return ecat_motion.M_HomingStart(Axises[axisId].Id, (short)DevIndex);
        }

        public int AxisHomeMove(int axisId, int homeMode, double vm, double vo, double acc, double shift, bool asyncMode = false, int posSource = 1)
        {
            try
            {
                if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
                {
                    throw new Exception("基元未运行");
                }

                lock (_lockAxisesHome)
                {
                    Thread.Sleep(1);
                    short result = ecat_motion.M_SetHomingMode(Axises[axisId].Id, 6, (short)DevIndex);
                    if (result != 0)
                    {
                        throw new Exception($"M_SetHomingMode <= {result}");
                    }

                    Thread.Sleep(100);
                    result = ecat_motion.M_SetHomingPrm(Axises[axisId].Id, (short)homeMode, (int)shift, (uint)vm, (uint)vo, (uint)acc, 0, (short)DevIndex);
                    if (result != 0)
                    {
                        throw new Exception($"M_SetHomingPrm <= {result}");
                    }

                    result = ecat_motion.M_HomingStart(Axises[axisId].Id, (short)DevIndex);
                    if (result != 0)
                    {
                        throw new Exception($"M_HomingStart <= {result}");
                    }
                    Thread.Sleep(100);//请勿删除或注释该延时函数
                    return result;
                }
            }
            catch (Exception ex)
            {
                LogAdd(ex.Message, LogLevel.Warn);
                return -1;
            }
        }

        public int AxisSetHomeMode(int axisId, int homeDir, int velMode, int homeMode, int posSource)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            ecat_motion.M_SetHomingMode(Axises[axisId].Id, 6, (short)DevIndex);
            short method = 0;
            int offset = 0;
            uint speed1 = 0;
            uint speed2 = 0;
            uint acc = 0;
            ushort probeFunction = 0;
            ecat_motion.M_GetHomingPrm(Axises[axisId].Id, ref method, ref offset, ref speed1, ref speed2, ref acc, ref probeFunction, (short)DevIndex);
            method = (short)homeMode;
            return ecat_motion.M_SetHomingPrm(Axises[axisId].Id, method, offset, speed1, speed2, acc, probeFunction, (short)DevIndex);
        }

        public int AxisSetHomeMode(int axisId, int homeMode, int posSource = 1)
        {
            try
            {
                if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
                {
                    throw new Exception("基元未运行");
                }

                short result = 0;
                result = ecat_motion.M_SetHomingMode((short)axisId, 8, (short)DevIndex);
                if (result != 0)
                {
                    throw new Exception($"M_SetHomingMode <= {result}");
                }

                return result;
            }
            catch (Exception ex)
            {
                LogAdd(ex.Message, LogLevel.Warn);
                return -1;
            }
        }

        public int SetAxisBand(int axisIdx, uint band, uint time)
        {
            return ecat_motion.M_SetAxisBand((short)axisIdx, band, time, (short)DevIndex); //设置Inp信号参数
        }
        #endregion


        #region 实现IIomodule接口
        public int ExportIoInfos()
        {
            var ret = false;
            if (!string.IsNullOrEmpty(IOInfosFilePath) && _ioInfos != null)
            {
                ret = JsonHelper.SerializeObjectToFile(_ioInfos, IOInfosFilePath);
            }
            return ret ? 0 : -1;
        }

        public int ReadAiModule(int startAddr, out double[] value)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                value = new double[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                return -1;
            }
            if (!AiModules.ContainsKey(startAddr))
            {
                value = new double[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                return 0;
            }
            value = AiModules[startAddr].Value;
            return 0;
        }

        public int ReadAoModule(int startAddr, out double[] value)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                value = new double[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                return -1;
            }
            if (!AoModules.ContainsKey(startAddr))
            {
                value = new double[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                return 0;
            }
            value = AoModules[startAddr].Value;
            return 0;
        }

        public int ReadDiModule(int startAddr, out uint value)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                value = 0;
                return -1;
            }
            if (!DiModules.ContainsKey(startAddr))
            {
                value = 0;
                return 0;
            }
            value = 0;
            return 0;
        }

        public int ReadDoModule(int startAddr, out uint value)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                value = 0;
                return -1;
            }
            if (!DoModules.ContainsKey(startAddr))
            {
                value = 0;
                return 0;
            }
            value = 0;
            return 0;
        }

        public int ReadDiModule(int IoM, int startAddr, out uint value)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                value = 0;
                return -1;
            }
            if (!DiModules.ContainsKey(IoM))
            {
                value = 0;
                return 0;
            }
            if (!DiModules[IoM].ContainsKey(startAddr))
            {
                value = 0;
                return 0;
            }
            value = DiModules[IoM][startAddr];
            return 0;
        }

        public int ReadDoModule(int IoM, int startAddr, out uint value)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                value = 0;
                return -1;
            }
            if (!DoModules.ContainsKey(IoM))
            {
                value = 0;
                return 0;
            }
            if (!DoModules[IoM].ContainsKey(startAddr))
            {
                value = 0;
                return 0;
            }
            value = DoModules[IoM][startAddr];
            return 0;
        }

        public int ReadSingleAInput(double address, out double val)
        {
            var moduleId = (int)address;
            var index = (int)Math.Round((address - moduleId) * 100);
            if (ReadAiModule(moduleId, out var moduleValue) == 0)
            {
                if (index < moduleValue.Length)
                {
                    val = moduleValue[index];
                    return 0;
                }
                else
                {
                    val = -1;
                    return -2;
                }
            }
            else
            {
                val = -1;
                return -1;
            }
        }

        public int ReadSingleAInput(double address, EleAnalogType type, out double val)
        {
            int moduleId = (int)address / 100;
            int index = ((int)address - moduleId * 100) * 16 + (int)Math.Round((address - (int)address) * 100) + 1;
            short value = 0;
            int ret = ecat_motion.M_Get_Slave_Analog_Input((short)moduleId, (short)index, ref value, 1, (short)DevIndex);
            //val = (ushort)value;
            val = ((ushort)value / 65535.0) * 16 + 4;
            return ret;
        }

        public int ReadSingleAOutput(double address, out double val)
        {
            var moduleId = (int)address;
            var index = (int)Math.Round((address - moduleId) * 100);
            if (ReadAoModule(moduleId, out var moduleValue) == 0)
            {
                if (index < moduleValue.Length)
                {
                    val = moduleValue[index];
                    return 0;
                }
                else
                {
                    val = -1;
                    return -2;
                }
            }
            else
            {
                val = -1;
                return -1;
            }
        }

        public int ReadSingleDInput(double address, out bool val)
        {
            int moduleId = (int)address / 100;
            int index = ((int)address - moduleId * 100) * 16 + (int)Math.Round((address - (int)address) * 100) + 1;
            if (ReadDiModule(moduleId, index, out var moduleValue) == 0)
            {
                val = moduleValue != 0;
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
            int moduleId = (int)address / 100;
            int index = ((int)address - moduleId * 100) * 16 + (int)Math.Round((address - (int)address) * 100) + 1;
            if (ReadDoModule(moduleId, index, out var moduleValue) == 0)
            {
                val = moduleValue != 0;
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
            var ret = 0;
            return ret;
        }

        public int RemoveDIChanged(double address)
        {
            if (DiRiseList.Contains(address)) DiRiseList.Remove(address);

            if (DiFallList.Contains(address)) DiFallList.Remove(address);

            return 0;
        }

        public int RemoveDOChanged(double address)
        {
            return 0;
        }

        public int WriteSingleAOutput(double address, double val)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return 0;
        }

        public int WriteSingleDOutput(double address, bool val)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }
            int moduleId = (int)address / 100;
            int index = ((int)address - moduleId * 100) * 16 + (int)Math.Round((address - (int)address) * 100) + 1;
            int ret = ecat_motion.M_Set_Slave_Digital_Chn_Output((short)moduleId, (short)index, (short)(val ? 1 : 0), (short)DevIndex);
            return ret;
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


        #region 实现IInterpolation接口
        public int GetAxisMotionMulticoorStatus(short crd)
        {
            int space = 0;                          //buff已用控件
            short outSts = 0;                       //buff状态
            short cmdNum = 0;                       //命令数量
            short coordinateNum = (short)(crd + 1); //坐标系号，配置中为0，1需转换
            ecat_motion.M_CrdStatus(coordinateNum, out outSts, out cmdNum, out space, 0, (short)DevIndex);
            return outSts == 0 && cmdNum == 0 ? 1 : 0;
        }

        public int GetInterpolationSta(int crd)
        {
            int space = 0;                          //buff已用控件
            short outSts = 0;                       //buff状态
            short cmdNum = 0;                       //命令数量
            short coordinateNum = (short)(crd + 1); //坐标系号，配置中为0，1需转换
            ecat_motion.M_CrdStatus(coordinateNum, out outSts, out cmdNum, out space, 0, (short)DevIndex);
            return outSts == 0 ? 1 : 0;
        }

        public int InterpolationPause(int crd)
        {
            short coordinateNum = (short)(crd + 1); //坐标系号，配置中为0，1需转换
            return ecat_motion.M_CrdPause(coordinateNum, (short)DevIndex);
        }

        public int InterpolationStart(int crd)
        {
            int index = 0;
            index = index | 1 << crd;
            short coordinateNum = (short)(crd + 1); //坐标系号，配置中为0，1需转换
            return ecat_motion.M_CrdStartSingle((short)index, 0, (short)DevIndex);
        }

        public int InterpolationStart(int crd, bool velPlanOpen = false)
        {
            int index = 0;
            index = index | 1 << crd;
            short coordinateNum = (short)(crd + 1); //坐标系号，配置中为0，1需转换
            if (velPlanOpen)
            {
                var crdDataRet = ecat_motion.M_CrdData(coordinateNum, ref crdBlockData, 0, (short)DevIndex); //将速度前瞻计算数据推送到FIFO中
            }
            return ecat_motion.M_CrdStartSingle((short)index, 0, (short)DevIndex);
        }

        public int InterpolationOpen(int crd, int axisNum, ushort[] axisList)
        {
            ecat_motion.CrdCfg crdCfg = new ecat_motion.CrdCfg();
            crdCfg.axis = new short[8];             //插补轴数组
            crdCfg.orignPos = new int[8];           //插补起始坐标数组
            crdCfg.dimension = (short)axisNum;      //插补维度
            for (int i = 0; i < axisList.Length; i++)
            {
                crdCfg.axis[i] = (short)axisList[i];
                crdCfg.orignPos[i] = 0;
            }
            crdCfg.evenTime = 10;                   //最小匀速时间
            crdCfg.synVelMax = 1000000;             //插补最大速度
            crdCfg.synAccMax = 1000000;              //插补最大加速度
            crdCfg.synDecSmooth = 1000000;          //插补平滑减速度
            crdCfg.synDecAbrupt = 5000000;          //插补急停减速度
            short coordinateNum = (short)(crd + 1); //坐标系号，配置中为0，1需转换
            var ret1 = ecat_motion.M_SetCrd(coordinateNum, ref crdCfg, (short)DevIndex);
            var ret2 = ecat_motion.M_CrdClear(coordinateNum, 1, 0, (short)DevIndex);
            return ret1 == 0 && ret2 == 0 ? 0 : -1;
        }

        public int InterpolationOpen(int crd, int axisNum, ushort[] axisList, bool velPlanOpen = false, short velPlanTValue = 10)
        {
            ecat_motion.CrdCfg crdCfg = new ecat_motion.CrdCfg();
            crdCfg.axis = new short[8];             //插补轴数组
            crdCfg.orignPos = new int[8];           //插补起始坐标数组
            crdCfg.dimension = (short)axisNum;      //插补维度
            for (int i = 0; i < axisList.Length; i++)
            {
                crdCfg.axis[i] = (short)axisList[i];
                crdCfg.orignPos[i] = 0;
            }
            crdCfg.evenTime = 10;                   //最小匀速时间
            crdCfg.synVelMax = 1000000;             //插补最大速度
            crdCfg.synAccMax = 1000000;              //插补最大加速度
            crdCfg.synDecSmooth = 1000000;          //插补平滑减速度
            crdCfg.synDecAbrupt = 5000000;          //插补急停减速度
            short coordinateNum = (short)(crd + 1); //坐标系号，配置中为0，1需转换
            var ret1 = ecat_motion.M_SetCrd(coordinateNum, ref crdCfg, (short)DevIndex);
            var ret2 = ecat_motion.M_CrdClear(coordinateNum, 1, 0, (short)DevIndex);
            #region 速度前瞻
            if (velPlanOpen)
            {
                crdBlockData = new ecat_motion.CrdBlockData();
                //short t = 100;                           //系统拐角时间，一般1-10
                double AccMax = 500000;                //系统允许最大加速度
                short n = 100;                          //速度前瞻点位计算区域
                var velPlanRet = ecat_motion.M_SetVelPlanning(coordinateNum, 0, velPlanTValue, AccMax, n, ref crdBlockData, (short)DevIndex);    //初始化速度前瞻功能
            }
            #endregion
            return ret1 == 0 && ret2 == 0 ? 0 : -1;
        }

        public int InterpolationStop(int crd, int stopMode)
        {
            int index = 0;
            index = index | 1 << (crd);
            return ecat_motion.M_CrdStop((short)index, 0, (short)DevIndex);
        }

        public int InterpolationMove(int crd, int axisNum, ushort[] axisArry, List<TrajPos> trajPos)
        {
            return 0;
        }

        public int AddInterpolationDO_OnStopAhead(ushort Crd, ushort DoAdr, bool On_Off, ushort isTimemode, double delayCount1, double delayConut2)
        {
            return 0;
        }

        public int AddInterpolationDO_OnStopDelay(ushort Crd, ushort DoAdr, bool On_Off, double delayCount1, double delayConut2)
        {
            return 0;
        }

        public int AddInterpolationDO_OnStartDelay(ushort Crd, ushort DoAdr, bool On_Off, ushort isTimemode, double delayCount1, double delayConut2)
        {
            return 0;
        }

        public int AddInterpolationDO(ushort Crd, ushort DoAdr, bool On_Off, double DelayTimeS)
        {
            int val = On_Off ? 1 : 0;
            short coordinateNum = (short)(Crd + 1); //坐标系号，配置中为0，1需转换
            return ecat_motion.M_BufIO(coordinateNum, DoAdr, (ushort)val, 0, (short)DevIndex);
        }

        public int AddInterpolationDelayS(ushort Crd, double DelayTimeS)
        {
            short coordinateNum = (short)(Crd + 1); //坐标系号，配置中为0，1需转换
            return ecat_motion.M_BufDelay(coordinateNum, (uint)DelayTimeS, 0, (short)DevIndex);
        }

        public int AddInterpolationPoint(ushort Crd, ushort AxisNum, ushort[] AxisArry, TrajPos trajPos)
        {
            short[] axisArr = new short[AxisArry.Length];
            int[] posArr = new int[trajPos.Pos.Length];
            for (int j = 0; j < AxisArry.Length; j++)
            {
                axisArr[j] = (short)AxisArry[j];
            }
            for (int i = 0; i < trajPos.Pos.Length; i++)
            {
                posArr[i] = (int)trajPos.Pos[i];
            }
            short coordinateNum = (short)(Crd + 1); //坐标系号，配置中为0，1需转换
            return ecat_motion.M_Line(coordinateNum, (short)AxisNum, ref axisArr[0], ref posArr[0], trajPos.TrajVm, trajPos.Tacc, trajPos.TrajVe, 0, (short)DevIndex);
        }

        public int AddInterpolatioWaitDI(ushort Crd, ushort DiAdr, bool On_Off, double TimeOutS = 0)
        {
            return 0;
        }
        #endregion


        #region 实现ICmpTrig
        public int AddTrigPoint(int trigCh, int value)
        {
            return 0;
        }

        public int GetTriggerCount(int trigCh, ref int count)
        {
            return 0;
        }

        public int ResetTriggerCount(int trigCh)
        {
            return 0;
        }

        public int SetLinearCompareTrig(int trigCh, int trigStart, int freq, int count)
        {
            return 0;
        }

        public int SetManualTrig(int trigCh, int pulseWidth = 200)
        {
            return 0;
        }

        public int SetTrigDir(int trigCh, int dir)
        {
            return 0;
        }

        public int SetTriggerChannelMode(int channel, int mode)
        {
            return 0;
        }

        public int SetTriggerConfig(int trigChannel, int axisId, int trigSource, int trigLogic, double widthTime)
        {
            return 0;
        }

        public int SetTriggerTable(int tCmpCh, double[] arry, int arrSize)
        {
            return 0;
        }

        public int SetTrigOutputLogic(int trigCh, int logic)
        {
            return 0;
        }

        public int SetTrigOutputPulseWidth(int trigCh, double widthTime)
        {
            return 0;
        }
        #endregion


        #region 实现IEtherCAT接口
        public int GetOdData(int slaveNo, int odIndex, int subIndex, int length, ref uint value)
        {
            uint[] returnValue = new uint[1];
            var ret = ecat_motion.M_AxisPDORead((short)slaveNo, (short)odIndex, 0, 32, ref returnValue[0], 1, (short)DevIndex);
            if (ret != 0)
            {
                return -1;
            }
            else
            {
                value = returnValue[0];
            }
            return 0;
        }

        public int SetOdData(int slaveNo, int odIndex, int subIndex, int length, uint value)
        {
            return ecat_motion.M_AxisPDOWrite((short)slaveNo, (short)odIndex, 0, value, 32, (short)DevIndex);
        }
        #endregion


        internal void UpdateAxisesAndModules()
        {
            ecat_motion.SL_RES sl_res = new ecat_motion.SL_RES();
            ecat_motion.M_GetSlaveResource(out sl_res, (short)DevIndex);
            if (sl_res.SlaveNum != TotalSlaveNum)
            {
                throw new Exception($"EntherCAT 节点丢失：扫描={sl_res.SlaveNum}，配置={TotalSlaveNum}");
            }

            if (sl_res.AxisNum != TotalAxisNum)
            {
                throw new Exception($"EntherCAT 轴丢失：扫描={sl_res.AxisNum}，配置={TotalAxisNum}");
            }

            if (sl_res.IoSlaveNum != TotalIoNum)
            {
                throw new Exception($"EntherCAT IO节点丢失：扫描={sl_res.IoSlaveNum}，配置={TotalIoNum}");
            }

            if (sl_res.DiNum != TotalDiModuleNum)
            {
                throw new Exception($"EntherCAT 数字量输入丢失：扫描={sl_res.DiNum}，配置={TotalDiModuleNum}");
            }

            if (sl_res.DoNum != TotalDoModuleNum)
            {
                throw new Exception($"EntherCAT 数字量输出丢失：扫描={sl_res.DoNum}，配置={TotalDoModuleNum}");
            }

            if (sl_res.AiNum != TotalAiModuleNum)
            {
                throw new Exception($"EntherCAT 模拟量输入丢失：扫描={sl_res.AiNum}，配置={TotalAiModuleNum}");
            }

            if (sl_res.AoNum != TotalAoModuleNum)
            {
                throw new Exception($"EntherCAT 模拟量输出丢失：扫描={sl_res.AoNum}，配置={TotalAoModuleNum}");
            }

            Axises = null ?? new ConcurrentDictionary<int, EAxis>();
            DiModules = null ?? new ConcurrentDictionary<int, ConcurrentDictionary<int, uint>>();
            DoModules = null ?? new ConcurrentDictionary<int, ConcurrentDictionary<int, uint>>();
            Axises.Clear();
            DiModules.Clear();
            DoModules.Clear();

            for (int i = 1; i <= TotalIoNum; i++)
            {
                DiModules.TryAdd(i, new ConcurrentDictionary<int, uint>());
                DoModules.TryAdd(i, new ConcurrentDictionary<int, uint>());

                ecat_motion.SL_IO_RES sl_io_res = new ecat_motion.SL_IO_RES();
                ecat_motion.M_GetSlaveIoResource(out sl_io_res, (short)i, (short)DevIndex);
                for (int j = 1; j <= sl_io_res.DiNum; j++)
                {
                    DiModules[i].TryAdd(j, 0);
                }
                for (int j = 1; j <= sl_io_res.DoNum; j++)
                {
                    DoModules[i].TryAdd(j, 0);
                }
            }

            for (short i = 1; i <= TotalAxisNum; i++)
            {
                AxisSetEnable(i, false);
                AxisResetAlarm(i);
                ecat_motion.M_SetAxisStsSync(i, 1, (short)DevIndex);
                //ecat_motion.M_SetAxisBand(i, 200, 10, (short)DevIndex); //设置Inp信号参数
                AxisSetEnable(i, true);
                Axises.TryAdd(i, new EAxis(i));
            }
        }

        public int AxisAbsMove2Pos(int axisId, double midPos, double targetPos, double midVel, double endVel, double acc, double dec)
        {
            return 0;
        }

        public int AxisAbsMove2PosStart(int axisId, double midPos, double targetPos, double midVel, double midStopVel, double delayMs, double maxVel2, double acc, double dec)
        {
            return 0;
        }

        public int AxisHomeCancel(int axisId)
        {
            ecat_motion.M_SetHomingMode((short)axisId, 8, (short)DevIndex);
            return ecat_motion.M_HomeCancelSingleAxis((short)axisId, (short)DevIndex);
        }


        #region 50902 Linker改善IO读取CT验证代码
        public bool GetDIChannelValue(short IoModuleNum, short diChannelNum)
        {
            var iret = false;
            if (PrimConnStat != PrimConnState.Connected || PrimRunStat != PrimRunState.Running)
            {
                return iret;
            }
            try
            {
                short diValue = 1;
                ecat_motion.M_Get_Slave_Digital_Chn_Input(IoModuleNum, diChannelNum, ref diValue, (short)DevIndex);
                iret = diValue == 0 ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                iret = false;
            }
            return iret;
        }
        #endregion



        #region Mehtod_ExternalUsing
        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="msg">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示弹窗；false：不显示弹窗；</param>
        internal void LogAdd(string msg, LogLevel lv, int id = 0, bool isShowDialog = false)
        {
            msg = $"{Name} -> {msg}";
            string tempId = $"{(int)lv}{(int)PrimLogId.PrimPCIEM60_E}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, Name, LogClassification.VisioPrim, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, NLocalizer.Warn, false, UIStyle.Orange, false, true);
            }
        }

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="msg">信息</param>
        /// <param name="lv">日志等级</param>
        internal void LogAddAuthority(string msg, LogLevel lv)
        {
            msg = $"{AuthorityManager.Instance.CurrentUserName} > {Name} > " + msg;

            LogHelper.LogAdd(lv, msg, PrimLogId.PrimPCIEM60_E.ToString(), LogClassification.VisioPrim, 0L);
        }

        #endregion
    }
}
