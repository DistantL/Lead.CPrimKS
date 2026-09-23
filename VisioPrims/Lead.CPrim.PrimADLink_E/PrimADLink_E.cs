using APS_Define_W32;
using APS168_W64;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.ProxyTools;
using PCIe_8338;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.PrimADLink_E
{
    //public delegate void OnDiChange(double addr,int type);
    public class PrimADLink_E : IPrim, IMotionCard, IAxis, IIoModule, IInterpolation, ICmpTrig, IEtherCAT
    {
        private Dictionary<int, double> _axisEquiv = new Dictionary<int, double>();
        private ADLinkEConfig _config = null;
        private bool _cycleCycleReadIOFlag = false;
        private bool _cycleCycleReadMotionFlag = false;
        private EBusConfig _eBusConfig = null;
        private bool _firstFlag = true;
        private IOInfos _ioInfos = null;
        private Control _primConfigUI = null;
        private Control _primDebugUI = null;
        private Control _primOutputUI = null;

        /// <summary>伺服回零中标志</summary>
        private bool[] _servoHoming = new bool[64];
        private Task _taskCycleReadIO = null;
        private Task _taskCycleReadMotion = null;
        private List<int> DiChangeAdr = new List<int>();

        private List<double> DiFallList = new List<double>();

        //所有需要触发改变事件的DI首地址
        private List<double> DiRiseList = new List<double>();

        private int[] _miniCmpEncoders = new int[16];
        public PrimADLink_E()
        {
            _config = new ADLinkEConfig();
            _eBusConfig = new EBusConfig();
            _ioInfos = new IOInfos();
            _primDebugUI = new PrimDebugControl(this);
            _primConfigUI = new PrimConfigControl(this);
            _primOutputUI = new PrimOutputControl(this);

            SetConn_RunState(PrimConnState.Other, PrimRunState.Other);
        }

        public PrimADLink_E(XmlNode xmlNode)
        {
            if (IPrimImportConfigXml(xmlNode) != 0)
            {
                return;
            }

            _primDebugUI = new PrimDebugControl(this);
            _primConfigUI = new PrimConfigControl(this);
            _primOutputUI = new PrimOutputControl(this);

            SetConn_RunState(PrimConnState.Other, PrimRunState.Other);
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
                    if ((int)Math.Floor(di) != addrHead)
                        continue;
                    var idx = (int)Math.Round((di - (int)di) * 100);
                    if ((diValue & (1 << idx)) == 0 && (newValue & (1 << idx)) > 0)
                    {
                        Debug.WriteLine(di.ToString("f2") + "Fall");
                        if (OnDIStateChanged == null)
                            return ret;

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

        private void CycleReadIO()
        {
            var di8ModulesInSlave = new int[TotalSlaveNum];
            var dicDi8Modules = new Dictionary<int, List<int>>();
            for (var i = 0; i < TotalSlaveNum; i++)
            {
                di8ModulesInSlave[i] = DiModules.Count(s => s.Value.SlaveNo == i && s.Value.TypeName.Contains("14"));
                if (di8ModulesInSlave[i] <= 0) continue;
                var listDisInSlave = new List<int>();
                foreach (var diModule in DiModules)
                {
                    if (diModule.Value.SlaveNo == i)
                    {
                        listDisInSlave.Add(diModule.Key);
                    }
                }
                listDisInSlave.Sort((a, b) => a.CompareTo(b));
                dicDi8Modules.Add(i, listDisInSlave);
            }

            var di32ModuleInSlave = new int[TotalSlaveNum];
            var do32ModuleInSlave = new int[TotalSlaveNum];
            for (var i = 0; i < TotalSlaveNum; i++)
            {
                di32ModuleInSlave[i] = DiModules.Count(s => s.Value.SlaveNo == i && s.Value.TypeName.Contains("MINI"));
                do32ModuleInSlave[i] = DoModules.Count(s => s.Value.SlaveNo == i && s.Value.TypeName.Contains("MINI"));
            }

            var cycleCount = 0;
            while (_cycleCycleReadIOFlag)
            {
                try
                {
                    //var sw = new Stopwatch();
                    //sw.Start();
                    var flagChange = 0;
                    //读取板卡自带输入

                    //DI模块赋值

                    for (var i = 0; i < di8ModulesInSlave.Length; i++)
                    {
                        if (di8ModulesInSlave[i] <= 0 || di8ModulesInSlave[i] >= 16)
                        {
                            continue;
                        }

                        var values = new uint[4];
                        if (di8ModulesInSlave[i] >= 12 && di8ModulesInSlave[i] <= 15)
                        {
                            Class_8338.GetLct4DiModule(DevIndex, i, 3, ref values);
                            if (DiModules.ContainsKey(100 * (i + 1) + 12))
                            {
                                DiModules[100 * (i + 1) + 12].Value = values[0];
                            }

                            if (DiModules.ContainsKey(100 * (i + 1) + 13))
                            {
                                DiModules[100 * (i + 1) + 13].Value = values[1];
                            }

                            if (DiModules.ContainsKey(100 * (i + 1) + 14))
                            {
                                DiModules[100 * (i + 1) + 14].Value = values[2];
                            }

                            if (DiModules.ContainsKey(100 * (i + 1) + 15))
                            {
                                DiModules[100 * (i + 1) + 15].Value = values[3];
                            }
                        }

                        if (di8ModulesInSlave[i] >= 8)
                        {
                            Class_8338.GetLct4DiModule(DevIndex, i, 2, ref values);
                            if (DiModules.ContainsKey(100 * (i + 1) + 8))
                            {
                                CheckDiChange(DiModules[100 * (i + 1) + 8].Value, values[0], 100 * (i + 1) + 8);
                                DiModules[100 * (i + 1) + 8].Value = values[0];
                            }

                            if (DiModules.ContainsKey(100 * (i + 1) + 9))
                            {
                                CheckDiChange(DiModules[100 * (i + 1) + 9].Value, values[1], 100 * (i + 1) + 9);
                                DiModules[100 * (i + 1) + 9].Value = values[1];
                            }

                            if (DiModules.ContainsKey(100 * (i + 1) + 10))
                            {
                                CheckDiChange(DiModules[100 * (i + 1) + 10].Value, values[2], 100 * (i + 1) + 10);
                                DiModules[100 * (i + 1) + 10].Value = values[2];
                            }

                            if (DiModules.ContainsKey(100 * (i + 1) + 11))
                            {
                                CheckDiChange(DiModules[100 * (i + 1) + 11].Value, values[3], 100 * (i + 1) + 11);
                                DiModules[100 * (i + 1) + 11].Value = values[3];
                            }
                        }

                        if (di8ModulesInSlave[i] >= 4)
                        {
                            Class_8338.GetLct4DiModule(DevIndex, i, 1, ref values);
                            if (DiModules.ContainsKey(100 * (i + 1) + 4))
                            {
                                CheckDiChange(DiModules[100 * (i + 1) + 4].Value, values[0], 100 * (i + 1) + 4);
                                DiModules[100 * (i + 1) + 4].Value = values[0];
                            }

                            if (DiModules.ContainsKey(100 * (i + 1) + 5))
                            {
                                CheckDiChange(DiModules[100 * (i + 1) + 5].Value, values[1], 100 * (i + 1) + 5);
                                DiModules[100 * (i + 1) + 5].Value = values[1];
                            }

                            if (DiModules.ContainsKey(100 * (i + 1) + 6))
                            {
                                CheckDiChange(DiModules[100 * (i + 1) + 6].Value, values[2], 100 * (i + 1) + 6);
                                DiModules[100 * (i + 1) + 6].Value = values[2];
                            }

                            if (DiModules.ContainsKey(100 * (i + 1) + 7))
                            {
                                CheckDiChange(DiModules[100 * (i + 1) + 7].Value, values[3], 100 * (i + 1) + 7);
                                DiModules[100 * (i + 1) + 7].Value = values[3];
                            }
                        }

                        Class_8338.GetLct4DiModule(DevIndex, i, 0, ref values);
                        if (DiModules.ContainsKey(100 * (i + 1)))
                        {
                            flagChange = CheckDiChange(DiModules[100 * (i + 1)].Value, values[0], 100 * (i + 1));
                            DiModules[100 * (i + 1)].Value = values[0];
                        }

                        if (DiModules.ContainsKey(100 * (i + 1) + 1))
                        {
                            CheckDiChange(DiModules[100 * (i + 1) + 1].Value, values[1], 100 * (i + 1) + 1);
                            DiModules[100 * (i + 1) + 1].Value = values[1];
                        }

                        if (DiModules.ContainsKey(100 * (i + 1) + 2))
                        {
                            CheckDiChange(DiModules[100 * (i + 1) + 2].Value, values[2], 100 * (i + 1) + 2);
                            DiModules[100 * (i + 1) + 2].Value = values[2];
                        }

                        if (DiModules.ContainsKey(100 * (i + 1) + 3))
                        {
                            CheckDiChange(DiModules[100 * (i + 1) + 3].Value, values[3], 100 * (i + 1) + 3);
                            DiModules[100 * (i + 1) + 3].Value = values[3];
                        }
                    }

                    for (var i = 0; i < di32ModuleInSlave.Length; i++)
                    {
                        if (di32ModuleInSlave[i] <= 0)
                        {
                            continue;
                        }

                        uint newValue = 0;
                        Class_8338.GetLctMiniDiModule(DevIndex, i, ref newValue);
                        CheckDiChange(DiModules[100 * (i + 1)].Value, newValue, 100 * (i + 1));
                        DiModules[100 * (i + 1)].Value = newValue;
                    }
                    /*
                    foreach (var diModule in DiModules)
                    {
                        uint value = 0;
                        Class_8338.GetInputStatus(DevIndex, diModule.Value.SlaveNo, diModule.Value.Id - 100 * (diModule.Value.SlaveNo + 1) + 1, 0, ref value);
                        CheckDiChange(diModule.Value.Value, value, diModule.Value.Id);
                        diModule.Value.Value = value;
                    }
                    */
                    //AI模块赋值
                    foreach (var aiModule in AiModules)
                    {
                        uint value = 0;
                        for (var j = 0; j < aiModule.Value.Num; j++)
                        {
                            Class_8338.GetInputStatus(DevIndex, aiModule.Value.SlaveNo, aiModule.Value.Id - (aiModule.Value.SlaveNo + 1) * 100, j, ref value);
                            aiModule.Value.Value[j] = value;
                        }
                    }

                    //DO模块赋值
                    if (cycleCount++ < 50)
                    {
                        cycleCount = 0;
                        foreach (var doModule in DoModules)
                        {
                            //Class_8338.SelfDefine_Get_8_Channel_Value(DevIndex, doModule.Value.SlaveNo, (doModule.Value.Id - (doModule.Value.SlaveNo + 1) * 100) * 8, out var value);
                            uint value = 0;
                            //Class_8338.GetPortOutput(DevIndex, doModule.Value.SlaveNo, doModule.Value.Id - 100 * (doModule.Value.SlaveNo + 1) + 1, ref value);
                            Class_8338.GetLct4DOModule(DevIndex, doModule.Value.SlaveNo, doModule.Value.Id - 100 * (doModule.Value.SlaveNo + 1), ref value);
                            doModule.Value.Value = value;
                        }
                        for (var i = 0; i < do32ModuleInSlave.Length; i++)
                        {
                            if (do32ModuleInSlave[i] <= 0)
                            {
                                continue;
                            }

                            uint newValue = 0;
                            Class_8338.GetLctMiniDoModule(DevIndex, i, ref newValue);
                            DoModules[100 * (i + 1)].Value = newValue;
                        }
                    }

                    //运动状态
                    foreach (var axisK in Axises)
                    {
                        double value = -1;
                        var axis = axisK.Value;
                        axis.MotionIoStatus = APS168.APS_motion_io_status(axis.Id);
                        axis.MotionStatus = APS168.APS_motion_status(axis.Id);

                        APS168.APS_get_command_f(axis.Id, ref value);
                        axis.CmdPos = value / _axisEquiv[axis.Id];

                        APS168.APS_get_position_f(axis.Id, ref value);
                        axis.ActualPos = value / _axisEquiv[axis.Id];

                        APS168.APS_get_command_velocity_f(axis.Id, ref value);
                        axis.CmdVel = value / _axisEquiv[axis.Id];

                        APS168.APS_get_feedback_velocity_f(axis.Id, ref value);
                        axis.ActualVel = value / _axisEquiv[axis.Id];

                        //APS168.APS_get_target_position_f(axis.Id, ref value);
                        //axis.TargetPos = value / _axisEquiv[axis.Id];

                        //APS168.APS_get_error_position_f(axis.Id, ref value);
                        //axis.ErrPos = value / _axisEquiv[axis.Id];
                    }

                    for (var i = 0; i < MiniCmpModules.Length; i++)
                    {
                        if (MiniCmpModules[i].SlaveNo != -1)
                        {
                            for (var j = 0; j < 4; j++)
                            {
                                lct_mini.Mini_Cmp_Lib.Encoder_GetEncoderData(DevIndex, MiniCmpModules[i].SlaveNo, j, ref _miniCmpEncoders[i + j]);
                            }
                        }
                    }
                   
                    //sw.Stop();
                    //Debug.WriteLine(sw.ElapsedMilliseconds.ToString());
                    //if (flagChange == 1)
                        //Debug.WriteLine($"Prim: {sw.ElapsedMilliseconds}");
                }
                catch (Exception)
                {
                }

                if (CycleScanTime > 0)
                {
                    Thread.SpinWait(CycleScanTime);
                }
            }
        }

        private void CycleReadMotion()
        {
            // 阻塞等触发
            while (_cycleCycleReadMotionFlag)
            {
                try
                {
                    var sw = new Stopwatch();
                    sw.Start();
                    foreach (var axisK in Axises)
                    {
                        double value = -1;
                        var axis = axisK.Value;
                        axis.MotionIoStatus = APS168.APS_motion_io_status(axis.Id);
                        axis.MotionStatus = APS168.APS_motion_status(axis.Id);

                        APS168.APS_get_command_f(axis.Id, ref value);
                        axis.CmdPos = value / _axisEquiv[axis.Id];

                        APS168.APS_get_position_f(axis.Id, ref value);
                        axis.ActualPos = value / _axisEquiv[axis.Id];

                        APS168.APS_get_command_velocity_f(axis.Id, ref value);
                        axis.CmdVel = value / _axisEquiv[axis.Id];

                        APS168.APS_get_feedback_velocity_f(axis.Id, ref value);
                        axis.ActualVel = value / _axisEquiv[axis.Id];

                        //APS168.APS_get_target_position_f(axis.Id, ref value);
                        //axis.TargetPos = value / _axisEquiv[axis.Id];

                        //APS168.APS_get_error_position_f(axis.Id, ref value);
                        //axis.ErrPos = value / _axisEquiv[axis.Id];
                    }
                    sw.Stop();
                    //Debug.WriteLine($@"MotionCycleTime:{sw.ElapsedMilliseconds}");
                }
                catch (Exception)
                {
                }

                Thread.SpinWait(0);
            }
        }

        //判断某个位是不是 1
        private bool IsNBitOne(uint Num, int n)
        {
            var Result = false;
            //uint str = Convert.ToString(Num,2);
            var bit = (Num >> (n - 1)) & 1;
            Result = bit == 1;

            return Result;
        }

        #region Override IPrim's property

        //public event PrimDataRefresh OnPrimDataRefresh;

        //public event PrimOpLog OnPrimOpLog;

        //public event PrimStateChanged OnPrimStateChanged;

        public Type ChildType
        {
            get => _config.ChildType;
            set => _config.ChildType = value;
        }

        public PrimType HSType
        {
            get => _config.HSType;
            set => _config.HSType = value;
        }

        public Guid Id
        {
            get => _config.Id;
            set => _config.Id = value;
        }

        public bool LogEnable { get => _config.LogEnable; set => _config.LogEnable = value; }

        public PrimManufacture Manu
        {
            get => _config.Manu;
            set => _config.Manu = value;
        }

        public string Name
        {
            get => _config.Name;
            set => _config.Name = value;
        }

        public LogLevel PrimAlarmLv { get; set; }

        public Control PrimConfigUI { get => _primConfigUI; }

        public PrimConnState PrimConnStat { get; set; }

        public bool PrimDebug
        {
            get => _config.PrimDebug;
            set => _config.PrimDebug = value;
        }

        public Control PrimDebugUI { get => _primDebugUI; }

        public bool PrimEnable
        {
            get => _config.PrimEnable;
            set => _config.PrimEnable = value;
        }

        public Control PrimOutputUI { get => _primOutputUI; }

        public RunMode PrimRunMode { get; set; }

        public PrimRunState PrimRunStat { get; set; }

        public bool PrimSimulator { get; set; }

        public string PrimTypeName
        {
            get => _config.PrimTypeName;
            set => _config.PrimTypeName = value;
        }

        public PrimVer Ver
        {
            get => _config.Ver;
            set => _config.Ver = value;
        }
        public int CurrentImageIndex { get => _config.CurrentImageIndex; set => _config.CurrentImageIndex = value; }

        #endregion Override IPrim's property

        #region Override IPrim's method

        #region Task Methods

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

        public int IPrimTaskStop()
        {
            if (IPrimStop() != 0)
            {
                return -1;
            }

            return 0;
        }

        #endregion Task Methods

        public int IPrimConnect(ref string result)
        {
            return 0;
        }

        public int IPrimDisConnect(ref string result)
        {
            return 0;
        }

        public int IPrimDispose()
        {
            Class_8338.Close();
            SetConn_RunState(PrimConnState.Other, PrimRunState.Other);
            return 0;
        }

        public XmlNode IPrimExportConfigXml()
        {
            if (_config == null) { return null; }

            var node = ProxyTools.XMLHelper.ObjectToXML(_config);
            ExportEBusConfig();
            ExportIoInfos();
            return node;
        }

        public int IPrimImportConfigXml(XmlNode xmlNode)
        {
            var iRet = 0;
            if (xmlNode != null)
            {
                _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(ADLinkEConfig)) as ADLinkEConfig;
                ImportEBusConfig();
                ImportIoInfos();
            }
            else { return -1; }
            return iRet;
        }

        public int IPrimInit()
        {
            if (PrimConnStat == PrimConnState.Connected && PrimRunStat == PrimRunState.Running)
            {
                return 0;
            }

            var startAxisId = -1;
            var maxSlaveNum = -1;

            var ret = 0;
            if (_firstFlag)
            {
                _firstFlag = false;
                ret = Class_8338.Initial(DevIndex, ref startAxisId, ref maxSlaveNum);//初始化
            }

            if (ret < 0)
            {
                _firstFlag = true;
                if (ret == -1)
                {
                    MessageBox.Show(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimADLinkE_CardTypeIncorrect", "Card is not PCIe-8334 or PCIe-8338!"));
                    Class_8338.Close();//如果不是 8334 或者 8338 卡片，先关闭卡片
                }
                else
                {
                    MessageBox.Show(string.Format(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimADLinkE_InitializationFailed", "Initialization failed, please check if the driver is installed or MotionCreatorPro2 is enabled, error code: {0}"), ret));
                }

                return -1;
            }
            else
            {
                //if (startAxisId != StartAxisId)
                //{
                //    MessageBox.Show($"起始轴的位置不对：设定值：{StartAxisId}，实际值：{startAxisId}");
                //    return -2;
                //}

                //if (Class_8338.ScanFieldBUS(DevIndex) != TotalSlaveNum)
                //{
                //    MessageBox.Show($"从站数目不符：设定值：{TotalSlaveNum}，实际值：{totalSlaveNum}");
                //    return -3;
                //}

                if (LoadParam() != 0)
                {
                    return -4;
                }
                foreach (var axis in Axises)
                {
                    SetAxisParam(axis.Value);
                }
                AxisEquivToDic(Axises);
            }

            SetConn_RunState(PrimConnState.Connected, PrimRunState.Stop);
            return 0;
        }

        public int IPrimReset()
        {
            if (PrimRunStat != PrimRunState.Err)
            {
                return 0;
            }

            foreach (var axis in Axises)
            {
                Class_8338.ResetFieldBusAlarm(axis.Value.Id);
            }
            SetRunState(PrimRunState.Running);

            return 0;
        }

        public int IPrimResume()
        {
            return 0;
        }

        public int IPrimStart()
        {
            if (PrimConnStat != PrimConnState.Connected)
            {
                MessageBox.Show(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimADLinkE_InitializePrimFirstly", "Please initialize the prim firstly."));
                return -1;
            }

            if (PrimRunStat == PrimRunState.Running)
            {
                return 0;
            }

            var startAxisID = -1;

            var ret = Class_8338.StartFieldBUS(DevIndex, ref startAxisID);//连接
            if (ret >= 0)//连接成功
            {
            }
            else if (ret == -1)
            {
                MessageBox.Show(string.Format(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimADLinkE_StartFieldBusError", "Start Field BUS Field, Error Code is {0}"), ret));
                return -1;
            }

            SetConn_RunState(PrimConnState.Connected, PrimRunState.Running);

            _cycleCycleReadIOFlag = true;
            if (CycleScanEnable && (_taskCycleReadIO == null || _taskCycleReadIO != null && (_taskCycleReadIO.IsCanceled || _taskCycleReadIO.IsCompleted)))
            {
                _taskCycleReadIO = new Task(CycleReadIO);
                _taskCycleReadIO.Start();
            }

            _cycleCycleReadMotionFlag = true;
            if (_taskCycleReadMotion == null || _taskCycleReadMotion != null && (_taskCycleReadMotion.IsCanceled || _taskCycleReadMotion.IsCompleted))
            {
                _taskCycleReadMotion = new Task(CycleReadMotion);
                _taskCycleReadMotion.Start();
            }
            return 0;
        }

        public int IPrimStop()
        {
            if (PrimConnStat != PrimConnState.Connected)
            {
                return -1;
            }

            _cycleCycleReadIOFlag = false;
            if (_taskCycleReadIO != null)
            {
                _taskCycleReadIO.Wait();
                Thread.Sleep(200);
                _taskCycleReadIO.Dispose();
            }

            _cycleCycleReadMotionFlag = false;
            if (_taskCycleReadMotion != null)
            {
                _taskCycleReadMotion.Wait();
                Thread.Sleep(200);
                _taskCycleReadMotion.Dispose();
            }

            var ret = Class_8338.StopFieldBUS(DevIndex);
            if (ret < 0)
            {
                MessageBox.Show(string.Format(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimADLinkE_FailedCloseBusConnection", "Failed to close the bus connection, error code: {0} "), ret));
                return -1;
            }

            SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Other);
            return 0;
        }

        public int IPrimSuspend()
        {
            return 0;
        }

        #endregion Override IPrim's method

        #region Override IMotionCard's property

        public event DIStateChanged OnDIStateChanged;

        public event DOStateChanged OnDOStateChanged;

        public string ConfigFilePath
        {
            get => _config.ConfigFilePath;
            set => _config.ConfigFilePath = value;
        }

        public bool CycleScanEnable
        {
            get => _config.CycleScanEnable;
            set => _config.CycleScanEnable = value;
        }

        public int CycleScanTime
        {
            get => _config.CycleScanTime;
            set => _config.CycleScanTime = value;
        }

        public int DevIndex
        {
            get => _config.DevIndex;
            set => _config.DevIndex = value;
        }

        public bool DIChangedEnable { get; set; }

        public bool DOChangedEnable { get; set; }

        public string EBusConfigFilePath
        {
            get => _config.EBusConfigFilePath;
            set => _config.EBusConfigFilePath = value;
        }

        public string IOInfosFilePath
        {
            get => _config.IOInfosFilePath;
            set => _config.IOInfosFilePath = value;
        }

        public StopMode StopMode
        {
            get => _config.StopMode;
            set => _config.StopMode = value;
        }

        #endregion Override IMotionCard's property

        #region Override IMotionCard's method

        private int MoveErrorHappen(int axisId)
        {
            var axis = Axises.FirstOrDefault(p => p.Value.Id == axisId);

            if (axis.Value.ActualPos - axis.Value.CmdPos > 100)
            {
                return -100;
            }

            if (axis.Value.CmdPos - axis.Value.ActualPos > 100)
            {
                return -200;
            }

            return 0;
        }
        /// <summary>驱动器回零_触发回零</summary>
        /// <param name="axis"></param>
        /// <param name="homeMode"></param>
        /// <param name="vm"></param>
        /// <param name="vo"></param>
        /// <param name="acc"></param>
        /// <param name="shift"></param>
        /// <param name="asyncMode"></param>
        /// <returns></returns>
        private int Servo_home_move(EAxis axis, int homeMode, double vm, double vo, double acc, double shift, bool asyncMode)
        {
            _servoHoming[axis.Id] = true;

            LogAdd("伺服回零_参数写入", LogLevel.Trace);
            //设置回零参数
            var pramHomeMode = Convert.ToInt16(homeMode);
            var pramVm = Convert.ToInt32(vm * _axisEquiv[axis.Id]);
            var pramVo = Convert.ToInt32(vo * _axisEquiv[axis.Id]);
            var pramAcc = Convert.ToInt32(acc * _axisEquiv[axis.Id]);
            var pramShift = Convert.ToInt32(shift * _axisEquiv[axis.Id]);

            //回零模式6098
            var index = ushort.Parse("6098", System.Globalization.NumberStyles.AllowHexSpecifier);
            var ret = Class_8338.SetFieldBusSDOData(DevIndex, axis.SlaveNo, index, 0, homeMode, 8);

            //回零速度6099-1，爬行速度6099-2
            index = ushort.Parse("6099", System.Globalization.NumberStyles.AllowHexSpecifier);
            ret = Class_8338.SetFieldBusSDOData(DevIndex, axis.SlaveNo, index, 1, pramVm, 32);
            ret = Class_8338.SetFieldBusSDOData(DevIndex, axis.SlaveNo, index, 2, pramVo, 32);

            //回零加速度609A
            index = ushort.Parse("609A", System.Globalization.NumberStyles.AllowHexSpecifier);
            ret = Class_8338.SetFieldBusSDOData(DevIndex, axis.SlaveNo, index, 0, pramAcc, 32);

            //快速停机方式605A
            index = ushort.Parse("605A", System.Globalization.NumberStyles.AllowHexSpecifier);
            ret = Class_8338.SetFieldBusSDOData(DevIndex, axis.SlaveNo, index, 0, 1, 16);

            //当前位置计算方式，增量式系统中，0-绝对回零，1-相对回零
            index = ushort.Parse("60E6", System.Globalization.NumberStyles.AllowHexSpecifier);
            ret = Class_8338.SetFieldBusSDOData(DevIndex, axis.SlaveNo, index, 0, 0, 8);

            //原点偏置607C
            index = ushort.Parse("607C", System.Globalization.NumberStyles.AllowHexSpecifier);
            ret = Class_8338.SetFieldBusSDOData(DevIndex, axis.SlaveNo, index, 0, pramShift, 32);

            //使能
            AxisSetEnable(axis.Id, true);

            //Modes of operation    6060    写入6
            LogAdd("Modes of operation => 6", LogLevel.Trace);
            var count = 0;
            uint tempOperationMode = 0;
            if (axis.Type == AxisType.IS620N)
            {
                Class_8338.SetODData(DevIndex, axis.SlaveNo, 0, 6, uint.MaxValue);
                Class_8338.SetODData(DevIndex, axis.SlaveNo, 0, 4, 6);
            }
            else if (axis.Type == AxisType.A6BF)
            {
                //设置最大速度
                Class_8338.SetODData(DevIndex, axis.SlaveNo, 0, 2, uint.MaxValue);
                //modes of operation    6060    写入6
                Class_8338.SetODData(DevIndex, axis.SlaveNo, 0, 4, 6);
            }
            else if (axis.Type == AxisType.CDHD || axis.Type == AxisType.SS || axis.Type == AxisType.STF || axis.Type == AxisType.HCX3E)
            {
                Class_8338.SetODData(DevIndex, axis.SlaveNo, 0, 1, 6);
            }
            else if (axis.Type == AxisType.D1)
            {
                Class_8338.SetODData(DevIndex, axis.SlaveNo, 0, 2, 6);
            }

            do
            {
                if (axis.Type == AxisType.IS620N)
                {
                    Class_8338.GetODData(DevIndex, axis.SlaveNo, 0, 4, ref tempOperationMode);
                }
                else if (axis.Type == AxisType.CDHD)
                {
                    Class_8338.GetODData(DevIndex, axis.SlaveNo, 0, 1, ref tempOperationMode);
                }
                else if (axis.Type == AxisType.SS || axis.Type == AxisType.STF || axis.Type == AxisType.D1)
                {
                    Class_8338.GetODData(DevIndex, axis.SlaveNo, 0, 2, ref tempOperationMode);
                }
                else if (axis.Type == AxisType.A6BF)
                {
                    //Modes of operation display    6061     读取6
                    Class_8338.GetODData(DevIndex, axis.SlaveNo, 0, 4, ref tempOperationMode);
                }
                else if (axis.Type == AxisType.HCX3E)
                {
                    Class_8338.GetODData(DevIndex, axis.SlaveNo, 0, 3, ref tempOperationMode);
                }

                Thread.Sleep(10);
                count++;
            } while (!((int)tempOperationMode == 6 || count > 1000));
            if (count > 1000)
            {
                string errText = $"{Name} => Axis{axis.Id} homing timeout!";
                LogAdd(errText, LogLevel.Warn);
                SetCspMode(axis);
                return -20;
            }
            //Modes of operation display    6061     读取6
            LogAdd("Modes of operation display <= 6", LogLevel.Trace);

            //Controlword    6040    写入15
            LogAdd("Controlword => 15", LogLevel.Trace);
            uint tempStatusWord = 0;
            count = 0;
            Class_8338.SetODData(DevIndex, axis.SlaveNo, 0, 0, 15);

            do
            {
                if (axis.Type == AxisType.IS620N || axis.Type == AxisType.SS || axis.Type == AxisType.STF || axis.Type == AxisType.HCX3E)
                {
                    Class_8338.GetODData(DevIndex, axis.SlaveNo, 0, 1, ref tempStatusWord);
                }
                else if (axis.Type == AxisType.CDHD || axis.Type == AxisType.D1 || axis.Type == AxisType.A6BF)
                {
                    //Statusword    6041    读取55（ready）
                    Class_8338.GetODData(DevIndex, axis.SlaveNo, 0, 0, ref tempStatusWord);
                }

                Thread.Sleep(10);
                count++;
            } while (!(((int)tempStatusWord & 55) == 55 || count > 1000));
            if (count > 1000)
            {
                string errText = $"{Name} => Axis{axis.Id} homing timeout!";
                LogAdd(errText, LogLevel.Warn);
                SetCspMode(axis);
                return -23;
            }
            //Statusword    6041    读取55（ready）
            LogAdd("Statusword <= 55（ready）", LogLevel.Trace);

            //Controlword    6040    写入31
            LogAdd("Controlword => 31（开始回零）", LogLevel.Trace);
            Class_8338.SetODData(DevIndex, axis.SlaveNo, 0, 0, 31);

            Func<EAxis, int> a = WaitServoDone;
            //if (asyncMode)
            //{
            //    a.BeginInvoke(axis, null, null);
            //    return 0;
            //}

            return a.Invoke(axis);
        }
        /// <summary>驱动器回零_等待完成</summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        private int WaitServoDone(EAxis axis)
        {
            var homeErr = false;
            uint tempStatusWord = 0;

            while (true)
            {
                tempStatusWord = 0;
                if (axis.Type == AxisType.IS620N || axis.Type == AxisType.SS || axis.Type == AxisType.STF || axis.Type == AxisType.HCX3E)
                {
                    Class_8338.GetODData(DevIndex, axis.SlaveNo, 0, 1, ref tempStatusWord);
                }
                else if (axis.Type == AxisType.CDHD || axis.Type == AxisType.D1 || axis.Type == AxisType.A6BF)
                {
                    Class_8338.GetODData(DevIndex, axis.SlaveNo, 0, 0, ref tempStatusWord);
                }

                if (((int)tempStatusWord & 8192) == 8192 || AxisIsAlarm(axis.Id) || !AxisIsEnble(axis.Id))
                {
                    //Statusword    6041    读取8192（回零完成）
                    LogAdd("Statusword <= 8192（ready）", LogLevel.Trace);
                    homeErr = true;
                    break;
                }
                if (((int)tempStatusWord & 5120) == 5120 && AxisIsStop(axis.Id))
                {
                    //Statusword    6041    读取5120（回零完成）
                    LogAdd("Statusword <= 5120（ready）", LogLevel.Trace);
                    break;
                }

                Application.DoEvents();
                Thread.Sleep(100);
            }

            Thread.Sleep(50);
            AxisResetAlarm(axis.Id);
            Thread.Sleep(50);

            if (!homeErr)
            {
                do
                {
                    Thread.Sleep(100);
                    Application.DoEvents();
                } while (!AxisIsStop(axis.Id));

                var pulse = 0.0;
                GetFeedbackPulse(axis.Id, ref pulse);
                SetAxisPositionAndFeedbackPulse(axis.Id, (int)pulse);
                APS168.APS_set_command_f(axis.Id, pulse);
                APS168.APS_reset_command_counter(axis.Id);
                Thread.Sleep(200);
            }

            
            AxisSetEnable(axis.Id, true);
            SetCspMode(axis);

            Thread.Sleep(200);
            AxisSetEnable(axis.Id, true);

            _servoHoming[axis.Id] = false;
            LogAdd($@"{Name} => Axis{axis.Id} home finished.", LogLevel.Trace);
            return 0;
        }
        /// <summary>CSP模式</summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        private int SetCspMode(EAxis axis)
        {
            //Modes of operation    6060    写入8
            LogAdd("Modes of operation => 8", LogLevel.Trace);
            uint tempOperationMode = 0;
            var count = 0;
            if (axis.Type == AxisType.IS620N)
            {
                Class_8338.SetODData(DevIndex, axis.SlaveNo, 0, 4, 8);
            }
            else if (axis.Type == AxisType.SS || axis.Type == AxisType.STF || axis.Type == AxisType.CDHD || axis.Type == AxisType.HCX3E)
            {
                Class_8338.SetODData(DevIndex, axis.SlaveNo, 0, 1, 8);
            }
            else if (axis.Type == AxisType.D1)
            {
                Class_8338.SetODData(DevIndex, axis.SlaveNo, 0, 2, 8);
            }
            else if ( axis.Type == AxisType.A6BF)
            {
                Class_8338.SetODData(DevIndex, axis.SlaveNo, 0, 4, 8);
            }

            do
            {
                if (axis.Type == AxisType.IS620N || axis.Type == AxisType.A6BF)
                {
                    Class_8338.GetODData(DevIndex, axis.SlaveNo, 0, 4, ref tempOperationMode);
                }
                else if (axis.Type == AxisType.CDHD)
                {
                    Class_8338.GetODData(DevIndex, axis.SlaveNo, 0, 1, ref tempOperationMode);
                }
                else if (axis.Type == AxisType.SS || axis.Type == AxisType.STF || axis.Type == AxisType.D1)
                {
                    Class_8338.GetODData(DevIndex, axis.SlaveNo, 0, 2, ref tempOperationMode);
                }
                else if (axis.Type == AxisType.HCX3E)
                {
                    Class_8338.GetODData(DevIndex, axis.SlaveNo, 0, 3, ref tempOperationMode);
                }

                Thread.Sleep(10);
                count++;
            } while (!(((int)tempOperationMode) == 8 || count > 1000));
            if (count > 1000)
            {

                string errText = $"{Name} => Axis{axis.Id} SetCspMode timeout!";
                LogAdd(errText, LogLevel.Warn);
                return -10;
            }
            //Modes of operation display    6061     读取8
            LogAdd("Modes of operation display <= 8", LogLevel.Trace);

            Thread.Sleep(20);
            return 0;
        }

        private int WaitMoveDone(int axisId, bool ignoreLimit, bool homeMode)
        {
            var iRet = 0;
            var t = 0;
            var timeOutS = 50;
            
            while (t++ <= timeOutS * 1000)
            {
                if (AxisIsAlarm(axisId) || (!ignoreLimit && (AxisInMel(axisId) || AxisInPel(axisId) || AxisInSMel(axisId) || AxisInSPel(axisId))))
                {
                    Thread.Sleep(1000);
                    if (AxisIsAlarm(axisId) || (!ignoreLimit && (AxisInMel(axisId) || AxisInPel(axisId) || AxisInSMel(axisId) || AxisInSPel(axisId))))
                    {
                        AxisStopMove(axisId);
                        //LogAdd(errMsg, AlarmLv.Error, 100 + errMethodId);
                        //LogAdd(string.Format(ProxyTools.ProxyTools.GetString("EleCartesian_EleCartesian_LimitMessage", "{0}'s {1} is in Limit: PEL-{2}, Mel-{3},SPEL-{4}, SMel-{5}, or has some alarm-{6} "), Name, Axises[axisIndex].Name, Axises[axisIndex].InPel, Axises[axisIndex].InMel, Axises[axisIndex].InSPel, Axises[axisIndex].InSMel, Axises[axisIndex].IsAlarm), AlarmLv.Error, 200 + errMethodId);
                        SetRunState(PrimRunState.Err);
                        iRet = -10;
                        break;
                    }
                }

                if (homeMode && AxisSignalInp(axisId) && !AxisIsHmv(axisId))
                {
                    break;
                }

                if (!homeMode && AxisSignalInp(axisId) && AxisIsStop(axisId))
                {
                    if (MoveErrorHappen(axisId) != 0)
                    {
                        SetRunState(PrimRunState.Err);
                        iRet = -20;
                        break;
                    }
                }
                
                Application.DoEvents();
                Thread.Sleep(1);
            }

            if (t < timeOutS * 1000)
            {
                if (homeMode)
                {
                    Thread.Sleep(100);
                    //SetAxisPositionAndFeedbackPulse(axisId, 0);
                }

                return 0;
            }

            //LogAdd(errMsg + ProxyTools.ProxyTools.GetString("EleCartesian_EleCartesian_TimeOutHappened", " TimeOut happened."), AlarmLv.Error, 400 + errMethodId);
            iRet = -30;
            SetRunState(PrimRunState.Err);

            return iRet;
        }
        

        public int AxisAbsMove(int axisId, double dis, double maxVel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag || !AxisIsEnble(axisId))
            {
                return -1;
            }

            var distance = dis * _axisEquiv[axisId];
            var vel = maxVel * _axisEquiv[axisId];
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

            return APS168.APS_absolute_move(axisId, (int)distance, (int)vel);
        }

        public int AxisChangeVel(int axisId, double newVel)
        {
            return 0;
        }

        public int AxisHomeMove(int axisId)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag || axisId < 0)
            {
                return -1;
            }
            var axis = Axises.FirstOrDefault(p => p.Value.Id == axisId);

            return AxisHomeMove(axisId, axis.Value.HomeParam.Mode, axis.Value.HomeParam.Vm, axis.Value.HomeParam.Vo,
                axis.Value.HomeParam.Acc, axis.Value.HomeParam.Shift, true);
        }

        public int AxisHomeMove(int axisId, bool asyncMode)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag || axisId < 0)
            {
                return -1;
            }
            var axis = Axises.FirstOrDefault(p => p.Value.Id == axisId);

            return AxisHomeMove(axisId, axis.Value.HomeParam.Mode, axis.Value.HomeParam.Vm, axis.Value.HomeParam.Vo,
                axis.Value.HomeParam.Acc, axis.Value.HomeParam.Shift, asyncMode);
        }

        public int AxisHomeMove(int axisId, int homeMode, double vm, double vo, double acc, double shift, bool asyncMode, int posSource = 1)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag || axisId == -1)
            {
                return -1;
            }

            var axis = Axises.FirstOrDefault(p => p.Value.Id == axisId);

            //板卡回零
            if (axis.Value.HomeParam.HomeBy == 1)
            {
                AxisSetHomeMode(axisId, homeMode);
                AxisSetHomeAcc(axisId, acc);
                AxisSetHomeMaxVel(axisId, vm);
                AxisSetHomeVO(axisId, vo);
                AxisSetHomeShift(axisId, shift);
                AxisSetEnable(axisId, true);
                APS168.APS_home_move(axisId);

                Func<int, bool, bool, int> a = WaitMoveDone;
                if (asyncMode)
                {
                    a.BeginInvoke(axisId, true, true, null, null);
                    return 0;
                }
                else
                {
                    return a.Invoke(axisId, true, true);
                }
            }

            //伺服回零
            return Servo_home_move(axis.Value, homeMode, vm, vo, acc, shift, asyncMode);
        }

        public bool AxisInMel(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }
            return (Axises[axisIdx].MotionIoStatus & (1 << 2)) != 0;
        }

        public bool AxisInOrigin(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 3)) != 0;
        }

        public bool AxisInPel(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 1)) != 0;
        }

        public bool AxisInSMel(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 12)) != 0;
        }

        public bool AxisInSPel(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 11)) != 0;
        }

        public bool AxisIsAlarm(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 0)) != 0;
            //return (Axises[axisIdx].MotionIoStatus & (1 << 0)) != 0 || (Axises[axisIdx].MotionStatus & (1 << 16)) != 0;
        }

        public bool AxisIsEnble(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 7)) != 0;
        }

        public bool AxisIsStop(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionStatus & (1 << 0)) != 0 && (Axises[axisIdx].MotionStatus & (1 << 5)) != 0;
        }
        public bool AxisIsHmv(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionStatus & (1 << 6)) != 0;
        }

        public int AxisJogStart(int axisId, int statOn, int jogDir)
        {
            var ret = 0;
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag || !AxisIsEnble(axisId)) return -1;
            ret = APS168.APS_set_axis_param(axisId, (int)APS_Define.PRA_JG_DIR, jogDir);
            if (statOn == 1)
            {
                ret = APS168.APS_jog_start(axisId, 0);
                Thread.Sleep(1);
                ret = APS168.APS_jog_start(axisId, 1);
            }
            else
            {
                ret = APS168.APS_jog_start(axisId, 1);
                Thread.Sleep(1);
                ret = APS168.APS_jog_start(axisId, 0);
            }
            return ret;
        }

        public int AxisRelMove(int axisId, double dis, double maxVel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag || !AxisIsEnble(axisId))
            {
                return -1;
            }
            var distance = dis * _axisEquiv[axisId];
            var vel = maxVel * _axisEquiv[axisId];
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
            return APS168.APS_relative_move(axisId, (int)distance, (int)vel);
        }

        public int AxisResetAlarm(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return -1;
            }

            return APS168.APS_reset_field_bus_alarm(axisIdx);
        }

        public int AxisSetAcc(int axisId, double acc)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_ACC, acc * _axisEquiv[axisId]);
        }

        public int AxisSetAccDec(int axisId, double minVel, double maxVel, double tAcc, double tDec, double stopVel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_VS, minVel * _axisEquiv[axisId]);
            APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_VM, maxVel * _axisEquiv[axisId]);
            APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_ACC, tAcc * _axisEquiv[axisId]);
            APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_DEC, tDec * _axisEquiv[axisId]);
            APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_VE, stopVel * _axisEquiv[axisId]);

            return 0;
        }

        public int AxisSetAccDec(int axisId, double minVel, double maxVel, double tAcc, double tDec, double stopVel,
            double stTime)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_VS, minVel * _axisEquiv[axisId]);
            APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_VM, maxVel * _axisEquiv[axisId]);
            APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_ACC, tAcc);
            APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_DEC, tDec);
            APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_VE, stopVel * _axisEquiv[axisId]);
            APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_SF, stTime);

            return 0;
        }

        public int AxisSetDec(int axisId, double dec)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_DEC, dec * _axisEquiv[axisId]);
        }

        public int AxisSetElMode(int axisId, bool pelEnable, bool melEnable, StopMode pelStopMode, StopMode melStopMode)
        {
            //凌华板卡仅能设定限位停止的模式，0-减速停止，1-立即停止
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_set_axis_param_f(axisId, (int)APS_Define.PRA_EL_MODE, pelStopMode == StopMode.Free ? 0 : 1);
        }

        public int AxisSetEmgMode(int axisId, int mode)
        {
            //mode:0-Servo off directly，1-Emergency stop without servo off
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_set_axis_param(axisId, (int)APS_Define.PRB_EMG_MODE, mode);
        }

        public int AxisSetEnable(int axisId, bool enable)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return -1;
            }

            var ret = 0;
            if (enable && !AxisIsEnble(axisId))
            {
                ret = APS168.APS_set_servo_on(axisId, 1);
            }
            else if (!enable && AxisIsEnble(axisId))
            {
                ret = APS168.APS_set_servo_on(axisId, 0);
            }
            else
            {
                ret = 0;
            }
            if (ret < 0)
            {
                MessageBox.Show(string.Format(string.Format(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimADLinkE_ServoAxisError", "Servo axis {0} Error"), axisId)));
                return -2;
            }

            return ret;
        }

        public int AxisSetHomeAcc(int axisId, double acc)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            var axis = Axises.FirstOrDefault(p => p.Value.Id == axisId);
            if (axis.Value.HomeParam.HomeBy == 1)
            {
                return APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_HOME_ACC, acc * _axisEquiv[axisId]);
            }

            //回零加速度609A
            var index = ushort.Parse("609A", System.Globalization.NumberStyles.AllowHexSpecifier);
            return Class_8338.SetFieldBusSDOData(DevIndex, axis.Value.SlaveNo, index, 0,
                (int)(acc * _axisEquiv[axisId]), 32);
        }

        public int AxisSetHomeCurve(int axisId, double curve)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_HOME_CURVE, curve);
        }

        public int AxisSetHomeDir(int axisId, int homeDir)
        {
            //homeDir: 0-positive 1-negative
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_set_axis_param(axisId, (Int32)APS_Define.PRA_HOME_DIR, homeDir);
        }

        public int AxisSetHomeEZA(int axisId, double eza)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_HOME_EZA, eza);
        }

        public int AxisSetHomeMaxVel(int axisId, double maxVel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            var axis = Axises.FirstOrDefault(p => p.Value.Id == axisId);
            if (axis.Value.HomeParam.HomeBy == 1)
            {
                return APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_HOME_VM, maxVel * _axisEquiv[axisId]);
            }

            //回零速度6099-1
            var index = ushort.Parse("6099", System.Globalization.NumberStyles.AllowHexSpecifier);
            return Class_8338.SetFieldBusSDOData(DevIndex, axis.Value.SlaveNo, index, 1, (int)(maxVel * _axisEquiv[axisId]), 32);
        }

        public int AxisSetHomeMode(int axisId, int homeDir, int velMode, int homeMode, int posSource = 1)
        {
            //homeDir: 0-positive 1-negative
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            var ret = APS168.APS_set_axis_param(axisId, (Int32)APS_Define.PRA_HOME_DIR, homeDir);
            ret = APS168.APS_set_axis_param(axisId, (Int32)APS_Define.PRA_HOME_MODE, homeMode);
            return ret;
        }

        public int AxisSetHomeMode(int axisId, int homeMode, int posSource = 1)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            var axis = Axises.FirstOrDefault(p => p.Value.Id == axisId);
            if (axis.Value.HomeParam.HomeBy == 1)
            {
                APS168.APS_set_axis_param(axisId, (Int32)APS_Define.PRA_HOME_DIR, 1);
                return APS168.APS_set_axis_param(axisId, (Int32)APS_Define.PRA_HOME_MODE, homeMode);
            }

            //回零模式6098
            var index = ushort.Parse("6098", System.Globalization.NumberStyles.AllowHexSpecifier);
            return Class_8338.SetFieldBusSDOData(DevIndex, axis.Value.SlaveNo, index, 0, homeMode, 8);
        }

        public int AxisSetHomePos(int axisId, double pos)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_HOME_POS, pos * _axisEquiv[axisId]);
        }

        public int AxisSetHomeShift(int axisId, double shift)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            var axis = Axises.FirstOrDefault(p => p.Value.Id == axisId);
            if (axis.Value.HomeParam.HomeBy == 1)
            {
                return APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_HOME_SHIFT, shift * _axisEquiv[axisId]);
            }

            //原点偏置607C
            var index = ushort.Parse("607C", System.Globalization.NumberStyles.AllowHexSpecifier);
            return Class_8338.SetFieldBusSDOData(DevIndex, axis.Value.SlaveNo, index, 0, (int)(shift * _axisEquiv[axisId]), 32);
        }

        public int AxisSetHomeVel(int axisId, double vel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            var axis = Axises.FirstOrDefault(p => p.Value.Id == axisId);
            if (axis.Value.HomeParam.HomeBy == 1)
            {
                return APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_HOME_VM, vel * _axisEquiv[axisId]);
            }

            //回零速度6099-1
            var index = ushort.Parse("6099", System.Globalization.NumberStyles.AllowHexSpecifier);
            return Class_8338.SetFieldBusSDOData(DevIndex, axis.Value.SlaveNo, index, 1, (int)(vel * _axisEquiv[axisId]), 32);
        }

        public int AxisSetHomeVO(int axisId, double vo)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            var axis = Axises.FirstOrDefault(p => p.Value.Id == axisId);
            if (axis.Value.HomeParam.HomeBy == 1)
            {
                return APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_HOME_VO, vo * _axisEquiv[axisId]);
            }

            //爬行速度6099-2
            var index = ushort.Parse("6099", System.Globalization.NumberStyles.AllowHexSpecifier);
            return Class_8338.SetFieldBusSDOData(DevIndex, axis.Value.SlaveNo, index, 2, (int)(vo * _axisEquiv[axisId]), 32);
        }

        public int AxisSetJogAcc(int axisId, double jogAcc)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_set_axis_param_f(axisId, (int)APS_Define.PRA_JG_ACC, jogAcc * _axisEquiv[axisId]);
        }

        public int AxisSetJogDec(int axisId, double jogDec)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_set_axis_param_f(axisId, (int)APS_Define.PRA_JG_DEC, jogDec * _axisEquiv[axisId]);
        }

        public int AxisSetJogDir(int axisId, int jogDir)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_set_axis_param(axisId, (int)APS_Define.PRA_JG_DIR, jogDir);
        }

        public int AxisSetJogMaxVel(int axisId, double jogMaxVel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_set_axis_param_f(axisId, (int)APS_Define.PRA_JG_VM, jogMaxVel * _axisEquiv[axisId]);
        }

        public int AxisSetJogMode(int axisId, int jogMode)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_set_axis_param(axisId, (int)APS_Define.PRA_JG_MODE, jogMode);
        }

        public int AxisSetMaxVel(int axisId, double maxVel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_VM, maxVel * _axisEquiv[axisId]);
        }

        public int AxisSetMinVel(int axisId, double minVel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_VS, minVel * _axisEquiv[axisId]);
        }

        public int AxisSetSoftLimit(int axisId, bool sPelEnable, bool sMelEnable, double sPelValue, double sMelValue)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            var ret = APS168.APS_set_axis_param(axisId, (int)APS_Define.PRA_SPEL_EN, sPelEnable ? 2 : 0);
            ret = APS168.APS_set_axis_param(axisId, (int)APS_Define.PRA_SMEL_EN, sMelEnable ? 2 : 0);
            ret = APS168.APS_set_axis_param_f(axisId, (int)APS_Define.PRA_SPEL_POS, sPelValue * _axisEquiv[axisId]);
            ret = APS168.APS_set_axis_param_f(axisId, (int)APS_Define.PRA_SMEL_POS, sMelValue * _axisEquiv[axisId]);
            return ret;
        }
        public int AxisSetStopDec(int id, int pulse)
        {
            return 0;
        }
        public int AxisSetStopVel(int axisId, double stopVel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_set_axis_param_f(axisId, (Int32)APS_Define.PRA_VE, stopVel * _axisEquiv[axisId]);
        }

        public bool AxisSignalDStp(int axisIdx)
        {
            return false;
        }

        public bool AxisSignalEmg(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 4)) != 0;
        }

        public bool AxisSignalEz(int axisIdx)
        {
            return false;
        }

        public bool AxisSignalInp(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 6)) != 0;
        }

        public bool AxisSignalOp(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 13)) != 0;
        }

        public bool AxisSignalRdy(int axisIdx)
        {
            return false;
        }

        public bool AxisSignalScl(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 10)) != 0;
        }

        public int AxisStopMove(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return -1;
            }

            //if (_servoHoming[axisIdx])
            //{
            //    var axis = Axises.FirstOrDefault(p => p.Value.Id == axisIdx);
            //    return Class_8338.SetODData(0, axis.Value.SlaveNo, 0, 0, 256);
            //}
            var axis = Axises.FirstOrDefault(p => p.Value.Id == axisIdx).Value;
            if (axis.Type == AxisType.D1)
            {
                uint tempOperationMode = 0;
                Class_8338.GetODData(DevIndex, axis.SlaveNo, 0, 2, ref tempOperationMode);  //回零模式
                if (tempOperationMode == 6 && AxisIsEnble(axisIdx))
                {
                    AxisSetEnable(axisIdx, false);
                    Thread.Sleep(500);
                    AxisSetEnable(axisIdx, true);
                }
            }
            switch (StopMode)
            {
                case StopMode.Immediate:
                    return APS168.APS_emg_stop(axisIdx);
                case StopMode.Other:
                    return Class_8338.SetODData(0, axis.SlaveNo, 0, 0, 256);
                case StopMode.Free:
                default:
                    return APS168.APS_stop_move(axisIdx);
            }
        }

        public int AxisVelMove(int axisId, double maxVel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag || !AxisIsEnble(axisId))
            {
                return -1;
            }

            return APS168.APS_velocity_move(axisId, (int)(maxVel * _axisEquiv[axisId]));
        }

        public int Center_Interpolation(int crd, int axisX_Id, int axisY_Id, ushort[] AxisList, double[] startPos,
            double[] targetPos, double[] centerPos, double radius, ushort mode)
        {
            throw new NotImplementedException();
        }

        public int ContiCloseList(int crd)
        {
            throw new NotImplementedException();
        }

        public int Continue_Interpolation(int crd, ushort[] axisList, double[] targetPos, ushort Mode, int mark)
        {
            throw new NotImplementedException();
        }

        public int ContinueCurrentMark(int crd)
        {
            throw new NotImplementedException();
        }

        public int ContinueRemainSpace(int crd)
        {
            throw new NotImplementedException();
        }

        public int InterpolationOpen(int crd, int axisNum, ushort[] axisList)
        {
            return 0;
        }

        public int GetAxisActualVelocity(int axisIdx, ref double velocity)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return -1;
            }

            if (axisIdx < 5000)
            {
                velocity = Axises[axisIdx].ActualVel;
            }
            else
            {
                velocity = 0;
            }
            
            return 0;
        }

        public int GetAxisCommand(int axisIdx, ref double command)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return -1;
            }
            if (axisIdx < 5000)
            {
                command = Axises[axisIdx].CmdPos;
            }
            else
            {
                command = _miniCmpEncoders[axisIdx - 5000]; ;
            }
            
            return 0;
        }

        public int GetAxisCommandVelocity(int axisIdx, ref double velocity)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return -1;
            }
            if (axisIdx < 5000)
            {
                velocity = Axises[axisIdx].CmdVel;
            }
            else
            {
                velocity = 0;
            }
            
            return 0;
        }

        public int GetAxisErrPosition(int axisIdx, ref double errPos)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return -1;
            }
            if (axisIdx < 5000)
            {
                errPos = Axises[axisIdx].ErrPos;
            }
            else
            {
                errPos = 0;
            }
            return 0;
        }
        public int GetAxisPosition(int axisIdx, ref double pos)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return -1;
            }
            if (axisIdx < 5000)
            {
                pos = Axises[axisIdx].ActualPos;
            }
            else
            {
                pos = _miniCmpEncoders[axisIdx - 5000];
            }
            return 0;
        }

        public int GetAxisTargetPosition(int axisIdx, ref double targetPos)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return -1;
            }

            if (axisIdx < 5000)
            {
                targetPos = Axises[axisIdx].TargetPos;
            }
            else
            {
                targetPos = _miniCmpEncoders[axisIdx - 5000];
            }

            return 0;
        }

        public int GetFeedbackPulse(int axisIdx, ref double position)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            var enc = -1;
            var iRet = APS168.APS_get_encoder(axisIdx, ref enc);
            position = enc;
            return iRet;
        }
        public int GetAxisMotionMulticoorStatus(short crd)
        {
            return GetInterpolationSta(crd) == 2 || GetInterpolationSta(crd) == 1 ? 1 : -1;
        }

        public int InterpolationPause(int crd)
        {
            return PTStop(crd);
        }

        public int InterpolationStart(int crd)
        {
            return PTStart(crd);
        }

        public int InterpolationStop(int crd, int stopMode)
        {
            return PTStop(crd);
        }

        public int Line_Interpolation(int crd, int axisX_Id, int axisY_Id, int axisZ_ID, int axisR_ID, ushort[] axisList,
            double[] startPos, double[] targetPos, ushort mode)
        {
            throw new NotImplementedException();
        }

        public void LoadConfigFile(string filePath)
        {
            return;
        }

        public int PTDisable(int pTbId)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_pt_disable(DevIndex, pTbId);
        }

        public int PTEnable(int pTbId, int dimension, int[] axisArray)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_pt_enable(DevIndex, pTbId, dimension, axisArray);
        }

        public int PTGetStatus(int pTbId, ref PTStatus status)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            var Status = new PTSTS();
            var iRet = APS168.APS_get_pt_status(DevIndex, pTbId, ref Status);
            status.BitSts = Status.BitSts;
            status.PntBufFreeSpace = Status.PntBufFreeSpace;
            status.PntBufUsageSpace = Status.PntBufUsageSpace;
            status.RunningCnt = Status.RunningCnt;

            return iRet;
        }

        public int PTLineSetPos(int pTbId, double[] pos)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            var cnt = pos.Length;

            var status = new PTSTS();
            var line = new PTLINE();
            line.Dim = cnt;
            line.Pos = new double[] { 0, 0, 0, 0, 0, 0 };

            for (var i = 0; i < cnt; i++)
            {
                line.Pos[i] = pos[i];
            }
            return APS168.APS_pt_line(DevIndex, pTbId, ref line, ref status);
        }

        public int PTSetAbsolute(int pTbId)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_pt_set_absolute(DevIndex, pTbId);
        }

        public int PTSetAcc(int pTbId, double acc)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_pt_set_acc(DevIndex, pTbId, acc);
        }

        public int PTSetDec(int pTbId, double dec)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_pt_set_dec(DevIndex, pTbId, dec);
        }

        public int PTSetTransBuffered(int pTbId)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_pt_set_trans_buffered(DevIndex, pTbId);
        }

        public int PTSetVe(int pTbId, double ve)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_pt_set_ve(DevIndex, pTbId, ve);
        }

        public int PTSetVm(int pTbId, double vm)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_pt_set_vm(DevIndex, pTbId, vm);
        }

        public int PTStart(int pTbId)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_pt_start(DevIndex, pTbId);
        }

        public int PTStop(int pTbId)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_pt_stop(DevIndex, pTbId);
        }

        public int Radius_Interpolation(int crd, int axisX_Id, int axisY_Id, ushort[] AxisList, double[] StartPos,
            double[] TargetPos, double radius, ushort Mode)
        {
            throw new NotImplementedException();
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

        public void RelGoXYR(double x, double y, double r)
        {
            return;
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

        public int Set_Equive(int axis_Id, double equive)
        {
            var axis = Axises.FirstOrDefault(p => p.Key == axis_Id);
            Axises[axis_Id].DefaultParam.Equiv = equive;
            if (_axisEquiv.ContainsKey(axis_Id))
            {
                _axisEquiv[axis_Id] = equive;
            }
            else
            {
                _axisEquiv.Add(axis_Id, equive);
            }
            return 0;
        }

        public int Set_Interpolation(int crd, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double Stop_Vel)
        {
            //凌华插补运动中无坐标系概念，crd参数无效
            //凌华插补运动中，速度参数以第一个轴的速度为设置值计算，而不是直接设定合成速度参数
            return 0;
        }

        public int Set_Lookahead(int crd, int enable, int lookaheadSegments, double pathError, double lookaheadAcc)
        {
            throw new NotImplementedException();
        }

        public int Set_Vector_s(int crd, double sTime)
        {
            throw new NotImplementedException();
        }

        public int StartInterPolation(ushort Crd)
        {
            return 0;
        }

        public int AddInterpolationDO_OnStopAhead(ushort Crd, ushort DoAdr, bool On_Off, ushort isTimemode, double delayCount1,
            double delayConut2)
        {
            throw new NotImplementedException();
        }

        public int AddInterpolationDO_OnStopDelay(ushort Crd, ushort DoAdr, bool On_Off, double delayCount1, double delayConut2)
        {
            throw new NotImplementedException();
        }

        public int AddInterpolationDO_OnStartDelay(ushort Crd, ushort DoAdr, bool On_Off, ushort isTimemode, double delayCount1,
            double delayConut2)
        {
            throw new NotImplementedException();
        }

        public int AddInterpolationDO(ushort Crd, ushort DoAdr, bool On_Off, double DelayTimeS)
        {
            throw new NotImplementedException();
        }

        public int AddInterpolationDelayS(ushort Crd, double DelayTimeS)
        {
            throw new NotImplementedException();
        }

        public int AddInterpolationPoint(ushort Crd, ushort AxisNum, ushort[] AxisArry, TrajPos trajPos)
        {
            throw new NotImplementedException();
        }

        public int AddInterpolatioWaitDI(ushort Crd, ushort DiAdr, bool On_Off, double TimeOutS = 0)
        {
            throw new NotImplementedException();
        }

        public int SetAxisFeedbackPulseToCommand(int axisIdx)
        {
            var iRet = 0;
            double pos = 0.0;
            var position = GetFeedbackPulse(axisIdx, ref pos);
            iRet = APS168.APS_set_command_f(axisIdx, position);
            return iRet;
        }

        public int SetAxisPositionAndFeedbackPulse(int axisIdx, int position)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            if (axisIdx < 5000)
            {
                APS168.APS_set_position(axisIdx, position);
            }
            else
            {
                var chNo = axisIdx - 5000;
                var cmpModuleNo = chNo / 4;
                var encoderNo = chNo % 4;
                if (cmpModuleNo < 4)
                {
                    var slaveNo = MiniCmpModules[cmpModuleNo].SlaveNo;
                    lct_mini.Mini_Cmp_Lib.Encoder_SetCurrentData(DevIndex, slaveNo, encoderNo, position);
                }
                
            }
            return 0;
        }

        public int SetLinearCompareTrig(int trigCh, int trigStart, int freq, int count)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return APS168.APS_set_trigger_linear(DevIndex, trigCh, trigStart, freq, count);
        }

        public int SetTrigDir(int trigCh, int dir)
        {
            var iRet = GetTrigChInfo(trigCh, out var slaveNo, out var newTrigCh);

            if (iRet == 0)
            {
                iRet = lct_mini.Mini_Cmp_Lib.PreCmp_SetTrigDir(DevIndex, slaveNo, newTrigCh, dir);
            }

            return iRet;
        }

        public int SetTriggerChannelEnable(string enableStr)
        {
            var iRet = 0;

            return iRet;
        }

        public int SetTriggerConfig(int trigCh, int axisId, int trigSource, int trigLogic, double widthTime)
        {
            //为保证兼容性，trigLogic输出极性参数无效，默认不取反
            //minCmp模块触发来源仅支持编码器方式
            var iRet = GetTrigChInfo(trigCh, out var slaveNo, out var newTrigCh);
            var chNo = axisId - 5000;
            var cmpModuleNo = chNo / 4;
            var encoderNo = chNo % 4;
            if (iRet == 0)
            {
                iRet = lct_mini.Mini_Cmp_Lib.PreCmp_BindingEncoder(DevIndex, slaveNo, encoderNo, newTrigCh);
                iRet = lct_mini.Mini_Cmp_Lib.LineCmp_BingdingEncoder(DevIndex, slaveNo, encoderNo, newTrigCh);

                iRet = lct_mini.Mini_Cmp_Lib.TriggerOut_SetPulseWidth(DevIndex, slaveNo, newTrigCh, (int)(widthTime * 100));
            }

            return iRet;
        }

        public int SetTriggerSouceAndInputSource(int trigSrc, int inputSrc)
        {
            var iRet = 0;
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            switch (trigSrc)
            {
                case 0:
                    break;

                case 1:
                    APS168.APS_set_trigger_param(DevIndex, (short)APS_Define.TGR_LCMP0_SRC, inputSrc);
                    break;

                case 2:
                    APS168.APS_set_trigger_param(DevIndex, (short)APS_Define.TGR_LCMP1_SRC, inputSrc);
                    break;

                case 3:
                    APS168.APS_set_trigger_param(DevIndex, (short)APS_Define.TGR_TCMP0_SRC, inputSrc);
                    break;

                case 4:
                    APS168.APS_set_trigger_param(DevIndex, (short)APS_Define.TGR_TCMP1_SRC, inputSrc);
                    break;
            }

            return iRet;
        }
        public int GetTriggerCount(int trigCh, ref int count)
        {
            var iRet = GetTrigChInfo(trigCh, out var slaveNo, out var newTrigCh);

            if (iRet == 0)
            {
                uint c = 0;
                iRet = lct_mini.Mini_Cmp_Lib.TriggerOut_GetCounter(DevIndex, slaveNo, trigCh, ref c);
                count = (int)c;
            }

            return iRet;
        }
        public int ResetTriggerCount(int trigCh)
        {
            var iRet = GetTrigChInfo(trigCh, out var slaveNo, out var newTrigCh);

            if (iRet == 0)
            {
                iRet = lct_mini.Mini_Cmp_Lib.TriggerOut_ResetCounter(DevIndex, slaveNo, (uint)trigCh);
            }

            return iRet;
        }
        public int SetTriggerSourceEnable(int trigCh, string enableStr)
        {
            var iRet = 0;

            return iRet;
        }

        public int SetTrigOutputLogic(int trigCh, int logic)
        {
            var iRet = 0;

            return iRet;
        }

        public int SetTrigOutputPulseWidth(int trigCh, double widthTime)
        {
            var iRet = GetTrigChInfo(trigCh, out var slaveNo, out var newTrigCh);
            SetTrigToggleMode(trigCh,true);
            if (iRet == 0)
            {
                iRet = lct_mini.Mini_Cmp_Lib.TriggerOut_SetPulseWidth(DevIndex, slaveNo, newTrigCh, (int)(widthTime * 100));
            }

            return iRet;
        }
        public int SetTriggerChannelMode(int trigCh, int mode)
        {
            //cmp_mode: 0-禁止，1-等于，2-小于，3-大于，4-队列，5-线性
            //凌华支持:0-禁止，4-队列，5-线性，1-手动
            var iRet = GetTrigChInfo(trigCh, out var slaveNo, out var newTrigCh);
            SetTrigToggleMode(trigCh, true);
            if (iRet == 0)
            {
                if (mode == 0)
                {
                    return lct_mini.Mini_Cmp_Lib.TriggerOut_SetOutMode(DevIndex, slaveNo, 0); 
                }
                iRet = lct_mini.Mini_Cmp_Lib.TriggerOut_SetOutMode(DevIndex, slaveNo, 1);
                if (mode == 4)
                {
                    return lct_mini.Mini_Cmp_Lib.PreCmp_SetEnable(DevIndex, slaveNo, newTrigCh , 1);
                }
                if (mode == 5)
                {
                    return lct_mini.Mini_Cmp_Lib.LineCmp_SetEnable(DevIndex, slaveNo, newTrigCh, 1);
                }
            }

            return iRet;
        }

        public int SetTriggerTable(int trigCh, double[] arry, int arrSize)
        {
            var iRet = GetTrigChInfo(trigCh, out var slaveNo, out var newTrigCh);

            if (iRet == 0)
            {
                var iArray = new int[arry.Length];
                for (var i = 0; i < arry.Length; i++)
                {
                    iArray[i] = Convert.ToInt32(arry[i]);
                }
                iRet = lct_mini.Mini_Cmp_Lib.PreCmp_SetTrigData(DevIndex, slaveNo, newTrigCh, iArray);
            }

            return iRet;

           
        }
        public int SetManualTrig(int trigCh, int pulseWidth = 200)
        {
            var iRet = 0;
            iRet = GetTrigChInfo(trigCh, out var slaveNo, out var newTrigCh);

            return lct_mini.Mini_Cmp_Lib.TriggerOut_SetManualOutput(DevIndex, slaveNo, newTrigCh);
        }
        public int SetTrigToggleMode(int trigCh, bool enable = true)
        {
            var iRet = 0;
            iRet = GetTrigChInfo(trigCh, out var slaveNo, out var newTrigCh);
            uint Line_mask = 0;
            uint Pre_mask = 0;
            switch (trigCh)
            {
                case 0:
                    Pre_mask = Convert.ToUInt32(1) | Convert.ToUInt32(0) * 2 | Convert.ToUInt32(0) * 4 | Convert.ToUInt32(0) * 8;
                    iRet=lct_mini.Mini_Cmp_Lib.TriggerOut_SetParam(DevIndex, slaveNo, 0, Line_mask, Pre_mask, 0);
                    //iRet = APS168.APS_set_trigger_param(DevIndex, (short)APS_Define.TGR_TRG0_TGL, enable ? 1 : 0);
                    break;
                case 1:
                    Pre_mask = Convert.ToUInt32(0) | Convert.ToUInt32(1) * 2 | Convert.ToUInt32(0) * 4 | Convert.ToUInt32(0) * 8;
                    iRet = lct_mini.Mini_Cmp_Lib.TriggerOut_SetParam(DevIndex, slaveNo, 0, Line_mask, Pre_mask, 0);
                    //iRet = APS168.APS_set_trigger_param(DevIndex, (short)APS_Define.TGR_TRG1_TGL, enable ? 1 : 0);
                    break;
                case 2:
                    Pre_mask = Convert.ToUInt32(0) | Convert.ToUInt32(0) * 2 | Convert.ToUInt32(1) * 4 | Convert.ToUInt32(0) * 8;
                    iRet = lct_mini.Mini_Cmp_Lib.TriggerOut_SetParam(DevIndex, slaveNo, 0, Line_mask, Pre_mask, 0);
                    //iRet = APS168.APS_set_trigger_param(DevIndex, (short)APS_Define.TGR_TRG2_TGL, enable ? 1 : 0);
                    break;
                case 3:
                    Pre_mask = Convert.ToUInt32(0) | Convert.ToUInt32(0) * 2 | Convert.ToUInt32(0) * 4 | Convert.ToUInt32(1) * 8;
                    iRet = lct_mini.Mini_Cmp_Lib.TriggerOut_SetParam(DevIndex, slaveNo, 0, Line_mask, Pre_mask, 0);
                    //iRet = APS168.APS_set_trigger_param(DevIndex, (short)APS_Define.TGR_TRG3_TGL, enable ? 1 : 0);
                    break;
            }

           

            return iRet;
        }
        public int AddTrigPoint(int trigCh, int value)
        {
            return 0;
        }
        private int GetTrigChInfo(int trigCh, out int slaveNo, out int realTrigCh)
        {
            slaveNo = 0;
            realTrigCh = 0;
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }
            
            var moduleNo = trigCh / 4;
            if (moduleNo >= MiniCmpModules.Length)
            {
                return -2;
            }

            slaveNo = MiniCmpModules[moduleNo].SlaveNo;
            realTrigCh = trigCh % 4;
            return 0;
        }
        public int StopAllAxes()
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return -1;
            }

            foreach (var axis in Axises)
            {
                APS168.APS_stop_move(axis.Value.Id);
            }
            return 0;
        }

        public int WriteSingleAOutput(double address, double val)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return -1;
            }

            return 0;
        }

        public int WriteSingleDOutput(double address, bool val)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return -1;
            }

            var moduleId = (int)address;
            var doModule = DoModules[moduleId];
            var index = (int)Math.Round((address - moduleId) * 100);
            //var curVal = false;
            return APS168.APS_set_field_bus_d_channel_output(DevIndex, 0, doModule.SlaveNo, (doModule.Id - (doModule.SlaveNo + 1) * 100) * 8 + index, val ? 1 : 0);
            //if (CycleScanEnable)
            //{
            //    ReadSingleDOutput(address, out curVal);
            //}

            //return (val != curVal || !CycleScanEnable) ? APS168.APS_set_field_bus_d_channel_output(DevIndex, 0, doModule.SlaveNo, (doModule.Id - (doModule.SlaveNo + 1) * 100) * 8 + index, val ? 1 : 0) : 0;
        }

        #region Others

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

        #endregion Others

        #endregion Override IMotionCard's method

        #region Override EBusConfig's Property

        public ConcurrentDictionary<int, EAiModule> AiModules
        {
            get => _eBusConfig.AiModules;
            set => _eBusConfig.AiModules = value;
        }

        public ConcurrentDictionary<int, EAoModule> AoModules
        {
            get => _eBusConfig.AoModules;
            set => _eBusConfig.AoModules = value;
        }

        public ConcurrentDictionary<int, EAxis> Axises
        {
            get => _eBusConfig.Axises;
            set => _eBusConfig.Axises = value;
        }

        public ConcurrentDictionary<int, EDiModule> DiModules
        {
            get => _eBusConfig.DiModules;
            set => _eBusConfig.DiModules = value;
        }

        public ConcurrentDictionary<int, EDoModule> DoModules
        {
            get => _eBusConfig.DoModules;
            set => _eBusConfig.DoModules = value;
        }

        public IOInfos IoInfos
        {
            get => _ioInfos;
            set => _ioInfos = value;
        }

        public int StartAxisId
        {
            get => _eBusConfig.StartAxisId;
            set => _eBusConfig.StartAxisId = value;
        }

        public int TotalAiModuleNum
        {
            get => _eBusConfig.TotalAiModuleNum;
            set => _eBusConfig.TotalAiModuleNum = value;
        }

        public int TotalAoModuleNum
        {
            get => _eBusConfig.TotalAoModuleNum;
            set => _eBusConfig.TotalAoModuleNum = value;
        }

        public int TotalAxisNum
        {
            get => _eBusConfig.TotalAxisNum;
            set => _eBusConfig.TotalAxisNum = value;
        }

        public int TotalDiModuleNum
        {
            get => _eBusConfig.TotalDiModuleNum;
            set => _eBusConfig.TotalDiModuleNum = value;
        }

        public int TotalDoModuleNum
        {
            get => _eBusConfig.TotalDoModuleNum;
            set => _eBusConfig.TotalDoModuleNum = value;
        }

        public int TotalSlaveNum
        {
            get => _eBusConfig.TotalSlaveNum;
            set => _eBusConfig.TotalSlaveNum = value;
        }

        public MiniCmp[] MiniCmpModules
        {
            get => _eBusConfig.MiniCmpModules;
            set => _eBusConfig.MiniCmpModules = value;
        }
        #endregion Override EBusConfig's Property



        #region Method_ExternalUsing
        /// <summary>日志</summary>
        /// <param name="log">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        public void LogAdd(string log, LogLevel lv, int id = 0)
        {
            if (!LogEnable)
            {
                return;
            }

            string tempId = $"{(int)lv}{(int)PrimLogId.PrimADLink_E}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            ProxyTools.LogHelper.LogAdd(lv, log, Name, LogClassification.VisioPrim, id);

            //PrimAlarmLv = lv;
            //if (lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn)
            //{
            //    SetRunState(PrimRunState.Err);
            //}
        }
        #endregion



        #region Method_InternalUsing

        private void AxisEquivToDic(ConcurrentDictionary<int, EAxis> axises)
        {
            _axisEquiv.Clear();
            foreach (var axis in axises)
            {
                if (axis.Key != -1)
                {
                    _axisEquiv.Add(axis.Key, axis.Value.DefaultParam.Equiv);
                }
            }
        }


        public int ExportEBusConfig()
        {
            var ret = false;
            if (!string.IsNullOrEmpty(EBusConfigFilePath) && _eBusConfig != null)
            {
                ret = JsonHelper.SerializeObjectToFile(_eBusConfig, EBusConfigFilePath);
            }
            return ret ? 0 : -1;
        }

        public int ExportIoInfos()
        {
            var ret = false;
            if (!string.IsNullOrEmpty(IOInfosFilePath) && _ioInfos != null)
            {
                ret = JsonHelper.SerializeObjectToFile(_ioInfos, IOInfosFilePath);
            }
            return ret ? 0 : -1;
        }

        public int FirstScanField()
        {
            var startAxisId = -1;
            var maxSlaveNum = -1;

            Class_8338.StopFieldBUS(DevIndex);
            var ret = 0;
            ret = Class_8338.Initial(DevIndex, ref startAxisId, ref maxSlaveNum);//初始化
            if (ret < 0)
            {
                if (ret == -1)
                {
                    MessageBox.Show($@"当前卡号下的卡不是833x总线板卡");
                    Class_8338.Close();//如果不是 8334 或者 8338 卡片，先关闭卡片
                }
                else
                {
                    MessageBox.Show(string.Format(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimADLinkE_InitializationFailed", "Initialization failed, please check if the driver is installed or MotionCreatorPro2 is enabled, error code: {0}"), ret));
                }

                return -1;
            }

            ret = Class_8338.ScanFieldBUS(DevIndex);//在硬件不改动（增加或者删除一个轴或IO模块）的情况下
            //只需要扫描一次，不需要每次打开程序都扫描
            if (ret >= 0)//连接成功
            {
                ret = Class_8338.StartFieldBUS(DevIndex, ref startAxisId);//连接
                if (ret >= 0)
                {
                    var totalSlaveNum = Class_8338.GetFieldBUSInfo(DevIndex);
                    if (totalSlaveNum != TotalSlaveNum)
                    {
                        var ret1 = MessageBox.Show(string.Format(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimADLinkE_SlavesNumberInconsistent", "The number of slaves setting - {0} is inconsistent with scanned - {1}. Do you want to continue?"), TotalSlaveNum, totalSlaveNum), ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimADLinkE_Warning", "Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (ret1 != DialogResult.Yes)
                        {
                            return -5;
                        }
                    }
                    TotalSlaveNum = totalSlaveNum;
                    StartAxisId = startAxisId;
                    var venderId = -1;
                    var totalAxisNum = 0;
                    var slaveAxisnum = 0;
                    var axisId = 0;
                    var diModuleNum = 0;
                    var doModuleNum = 0;
                    Axises.Clear();
                    for (var i = 0; i < TotalSlaveNum; i++)
                    {
                        Class_8338.GetSlaveInformation(DevIndex, i, ref venderId, ref slaveAxisnum, ref axisId, ref diModuleNum, ref doModuleNum);
                        if (slaveAxisnum == 1)
                        {
                            Axises.TryAdd(axisId, new EAxis(i, axisId));
                            totalAxisNum++;//获取已连接上所有的轴数
                        }
                    }
                    if (totalAxisNum != TotalAxisNum)
                    {
                        var ret1 = MessageBox.Show(string.Format(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimADLinkE_AxesNumberInconsistent", "The number of axes setting - {0} is inconsistent with scanned - {1}. Do you want to continue?"), TotalAxisNum, totalAxisNum), ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimADLinkE_Warning", "Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (ret1 != DialogResult.Yes)
                        {
                            return -5;
                        }
                    }
                    TotalAxisNum = totalAxisNum;
                }
                else
                {
                    MessageBox.Show(string.Format(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimADLinkE_StartFieldBusFieldError", "Start Field BUS Field, Error Code is {0}"), ret));
                    return -1;
                }
            }
            else
            {
                MessageBox.Show(string.Format(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimADLinkE_ScanFieldBusError", "Scan Field BUS Field, Error Code is {0}"), ret));
                return -1;
            }
            MessageBox.Show(string.Format(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimADLinkE_InitializationScanSucceeded", "Initialization scan succeeded: number of slaves: {0}, number of axes: {1}, please confirm whether it is consistent with the actual."), TotalSlaveNum, TotalAxisNum));
            return 0;
        }

        public int GetInterpolationSta(int crd)
        {
            //0： 运动中， 1： 暂停中， 2： 正常停止， 3： 未启动， 4： 空闲， 5： 异常停止
            var status = new PTStatus();
            if (PTGetStatus(crd, ref status) == 0)
            {
                if ((status.BitSts & 1) == 0)       //b1: Is PT work? [1:working, 0:Stopped]，b2: Is point buffer empty? [1:empty, 0:not empty]
                {
                    if (status.PntBufFreeSpace != 50)   //
                    {
                        return 1;
                    }

                    return 2;
                }
                return 0;
            }

            return 5;
        }

        public int ImportEBusConfig()
        {
            if (!string.IsNullOrEmpty(EBusConfigFilePath) && File.Exists(EBusConfigFilePath))
            {
                _eBusConfig = JsonHelper.DeserializeJsonFileToObject<EBusConfig>(EBusConfigFilePath);
            }

            if (_eBusConfig == null)
            {
                _eBusConfig = new EBusConfig();
                return -1;
            }
            AxisEquivToDic(_eBusConfig.Axises);
            return 0;
        }

        public int ImportIoInfos()
        {
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
            return _ioInfos != null ? 0 : -1;
        }

        public int InterpolationMove(int crd, int axisNum, ushort[] axisArry, List<TrajPos> trajPos)
        {
            APS168.APS_pt_disable(DevIndex, crd);
            var arryAxis = new int[axisArry.Length];
            for (var i = 0; i < axisArry.Length; i++)
            {
                arryAxis[i] = (int)axisArry[i];
            }
            APS168.APS_pt_enable(DevIndex, crd, axisNum, arryAxis);
            var acc = trajPos[0].TrajVm / trajPos[0].Tacc;
            var dec = trajPos[0].TrajVm / trajPos[0].Tdec;
            APS168.APS_pt_set_acc(DevIndex, crd, acc);
            APS168.APS_pt_set_dec(DevIndex, crd, dec);
            APS168.APS_pt_set_absolute(DevIndex, crd); //Set to absolute mode
            APS168.APS_pt_set_trans_buffered(DevIndex, crd); //Set to buffer mode

            var status = new PTStatus();
            PTGetStatus(crd, ref status);
            while (true)
            {
                if ((status.BitSts & 0x02) == 0) break; //Buffer is not Full  break;
                Thread.Sleep(20);
            }
            if ((status.BitSts & 0x02) == 0) //Buffer is not Full
            {
                for (var i = 0; i < trajPos.Count; i++)
                {
                    APS168.APS_pt_set_vm(DevIndex, crd, trajPos[i].TrajVm);
                    APS168.APS_pt_set_ve(DevIndex, crd, trajPos[i].TrajVe);
                    var status1 = new PTSTS();
                    var line = new PTLINE { Dim = trajPos[i].Pos.Length, Pos = new double[6] };
                    for (var j = 0; j < trajPos[i].Pos.Length; j++)
                    {
                        line.Pos[j] = trajPos[i].Pos[j];
                    }
                    APS168.APS_pt_line(DevIndex, crd, ref line, ref status1);
                }
                APS168.APS_pt_start(DevIndex, crd);
            }

            return 0;
        }

        public int LoadAxisParam(int axisId, ref DefaultParameter axisParam, ref HomeParameter homeParam, ref JogParameter jogParam)
        {
            var ret = -1.0;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_CURVE, ref ret);
            axisParam.Curve = ret;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_ACC, ref ret);
            axisParam.Acc = ret;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_DEC, ref ret);
            axisParam.Dec = ret;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_VS, ref ret);
            axisParam.Vs = ret;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_VM, ref ret);
            axisParam.Vm = ret;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_VE, ref ret);
            axisParam.Ve = ret;

            double mode = -1;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_HOME_MODE, ref mode);
            homeParam.Mode = (int)mode;

            double dir = -1;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_HOME_DIR, ref dir);
            homeParam.Dir = dir == 0 ? 0 : 1;

            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_HOME_CURVE, ref ret);
            homeParam.Curve = ret;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_HOME_ACC, ref ret);
            homeParam.Acc = ret;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_HOME_VS, ref ret);
            homeParam.Vs = ret;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_HOME_VM, ref ret);
            homeParam.Vm = ret;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_HOME_SHIFT, ref ret);
            homeParam.Shift = ret;

            var eza = -1.0;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_HOME_EZA, ref eza);
            homeParam.Eza = eza == 0 ? false : true;

            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_HOME_VO, ref ret);
            homeParam.Vo = ret;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_HOME_POS, ref ret);
            homeParam.Pos = ret;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_HOME_CURVE, ref ret);
            homeParam.Curve = ret;
            double ez_dir = -1;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_HOME_Search_Target, ref ez_dir);
            homeParam.Ez_Dir = ez_dir == 0 ? 0 : 1;

            double jogMode = -1;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_JG_MODE, ref jogMode);
            jogParam.Mode = jogMode == 0 ? 0 : 1;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_JG_SF, ref ret);
            jogParam.Sf = ret;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_JG_ACC, ref ret);
            jogParam.Acc = ret;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_JG_DEC, ref ret);
            jogParam.Dec = ret;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_JG_VM, ref ret);
            jogParam.Vm = ret;
            APS168.APS_get_axis_param_f(axisId, (int)APS_Define.PRA_JG_OFFSET, ref ret);
            jogParam.Offset = ret;
            var ret1 = 0;
            APS168.APS_get_axis_param(axisId, (int)APS_Define.PRA_JG_DELAY, ref ret1);
            jogParam.Delay = ret1;
            return 0;
        }

        public int LoadParam()
        {
            var ret = 0;
            ret = Class_8338.LoadParameter(DevIndex);
            if (ret == 0)
            {
                return 0;
            }
            else
            {
                MessageBox.Show(string.Format(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimADLinkE_LoadConfigFileFailed", "Load Config File Failed, Error Code is : {0}"), ret));
                return -1;
            }
        }

        public int ReadAiModule(int startAddr, out double[] value)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadIOFlag)
            {
                value = new double[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                return -1;
            }

            if (!CycleScanEnable)
            {
                uint aiValue = 0;
                Class_8338.GetInputStatus(DevIndex, AiModules[startAddr].SlaveNo, AiModules[startAddr].Id - (AiModules[startAddr].SlaveNo + 1) * 100, 0, ref aiValue);
                //AiModules[startAddr].Value[0] = laserValue * 0.0153 - 299.52;
                value = AiModules[startAddr].Value;
            }
            else
            {
                value = AiModules[startAddr].Value;
            }
            return 0;
        }

        public int ReadAoModule(int startAddr, out double[] value)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadIOFlag)
            {
                value = new double[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                return -1;
            }
            value = AoModules[startAddr].Value;
            return 0;
        }

        public int ReadDiModule(int startAddr, out uint value)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadIOFlag)
            {
                value = 0;
                return -1;
            }

            if (!CycleScanEnable)
            {
                uint readValue = 0;
                Class_8338.GetInputStatus(DevIndex, DiModules[startAddr].SlaveNo,
                    DiModules[startAddr].Id - 100 * (DiModules[startAddr].SlaveNo + 1) + 1, 0, ref readValue);
                value = readValue;
            }
            else
            {
                value = DiModules[startAddr].Value;
            }
            return 0;
        }

        public int ReadDoModule(int startAddr, out uint value)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadIOFlag)
            {
                value = 0;
                return -1;
            }

            if (!CycleScanEnable)
            {
                Class_8338.SelfDefine_Get_8_Channel_Value(DevIndex, DoModules[startAddr].SlaveNo, (DoModules[startAddr].Id - (DoModules[startAddr].SlaveNo + 1) * 100) * 8, out var doModulesValue);
                value = doModulesValue;
            }
            else
            {
                value = DoModules[startAddr].Value;
            }
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
            var moduleId = (int)address;
            var index = (int)Math.Round((address - moduleId) * 100);
            if (ReadDiModule(moduleId, out var moduleValue) == 0)
            {
                val = (moduleValue & (1 << index)) != 0;
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
            var moduleId = (int)address;
            var index = (int)Math.Round((address - moduleId) * 100);
            if (ReadDoModule(moduleId, out var moduleValue) == 0)
            {
                val = (moduleValue & (1 << index)) != 0;
                return 0;
            }
            else
            {
                val = false;
                return -1;
            }
        }

        public int SaveParamToFlash()
        {
            if (PrimConnStat == PrimConnState.Connected)
            {
                var ret = APS168.APS_save_parameter_to_flash(DevIndex);
                if (ret != 0)
                {
                    MessageBox.Show(string.Format(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimADLinkE_ParameterDownloadToFlashFailed", "Parameter download to flash failed, error code: {0}."), ret));
                    return -1;
                }
            }
            return 0;
        }

        public int SetAxisJogParam(EAxis axis)
        {
            AxisEquivToDic(Axises);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_JG_MODE, axis.JogParam.Mode);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_JG_SF, axis.JogParam.Sf);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_JG_ACC, axis.JogParam.Acc);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_JG_DEC, axis.JogParam.Dec);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_JG_VM, axis.JogParam.Vm);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_JG_OFFSET, axis.JogParam.Offset);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_JG_DELAY, axis.JogParam.Delay);
            return 0;
        }

        public int SetAxisParam(EAxis axis)
        {
            AxisEquivToDic(Axises);

            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_CURVE, axis.DefaultParam.Curve);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_ACC, axis.DefaultParam.Acc);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_DEC, axis.DefaultParam.Dec);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_VS, axis.DefaultParam.Vs);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_VM, axis.DefaultParam.Vm);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_VE, axis.DefaultParam.Ve);

            APS168.APS_set_axis_param(axis.Id, (int)APS_Define.PRA_HOME_MODE, axis.HomeParam.Mode);
            APS168.APS_set_axis_param(axis.Id, (int)APS_Define.PRA_HOME_DIR, axis.HomeParam.Dir);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_HOME_CURVE, axis.HomeParam.Curve);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_HOME_ACC, axis.HomeParam.Acc);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_HOME_VS, axis.HomeParam.Vs);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_HOME_VM, axis.HomeParam.Vm);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_HOME_SHIFT, axis.HomeParam.Shift);
            APS168.APS_set_axis_param(axis.Id, (int)APS_Define.PRA_HOME_EZA, axis.HomeParam.Eza ? 1 : 0);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_HOME_VO, axis.HomeParam.Vo);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_HOME_POS, axis.HomeParam.Pos);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_HOME_CURVE, axis.HomeParam.Curve);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_HOME_VO, axis.HomeParam.Vo);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_HOME_POS, axis.HomeParam.Pos);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_HOME_CURVE, axis.HomeParam.Curve);
            APS168.APS_set_axis_param(axis.Id, (int)APS_Define.PRA_HOME_Search_Target, axis.HomeParam.Ez_Dir);

            APS168.APS_set_axis_param(axis.Id, (int)APS_Define.PRA_JG_MODE, axis.JogParam.Mode);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_JG_SF, axis.JogParam.Sf);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_JG_ACC, axis.JogParam.Acc);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_JG_DEC, axis.JogParam.Dec);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_JG_VM, axis.JogParam.Vm);
            APS168.APS_set_axis_param_f(axis.Id, (int)APS_Define.PRA_JG_OFFSET, axis.JogParam.Offset);
            APS168.APS_set_axis_param(axis.Id, (int)APS_Define.PRA_JG_DELAY, axis.JogParam.Delay);

            return 0;
        }

        public void SetConn_RunState(PrimConnState Conn, PrimRunState Run)
        {
            PrimConnStat = Conn;
            PrimRunStat = Run;
            ((PrimConfigControl)_primConfigUI).SetPrimConnState(Conn);
            ((PrimConfigControl)_primConfigUI).SetPrimRunState(Run);
            ((PrimDebugControl)_primDebugUI).SetPrimConnState(Conn);
            ((PrimDebugControl)_primDebugUI).SetPrimRunState(Run);
            ((PrimOutputControl)_primOutputUI).SetPrimConnState(Conn);
            ((PrimOutputControl)_primOutputUI).SetPrimRunState(Run);
        }

        public void SetConnState(PrimConnState Conn)
        {
            PrimConnStat = Conn;
            ((PrimConfigControl)_primConfigUI).SetPrimConnState(Conn);
            ((PrimDebugControl)_primDebugUI).SetPrimConnState(Conn);
            ((PrimOutputControl)_primOutputUI).SetPrimConnState(Conn);
        }
        public void SetRunState(PrimRunState Run)
        {
            PrimRunStat = Run;
            ((PrimConfigControl)_primConfigUI).SetPrimRunState(Run);
            ((PrimDebugControl)_primDebugUI).SetPrimRunState(Run);
            ((PrimOutputControl)_primOutputUI).SetPrimRunState(Run);
        }

        #endregion Others

        public int GetOdData(int slaveNo, int odIndex, ref uint value)
        {
            return APS168.APS_get_field_bus_od_data(DevIndex, 0, slaveNo, 0, odIndex, ref value);
        }

        public int SetOdData(int slaveNo, int odIndex, uint value)
        {
            return APS168.APS_set_field_bus_od_data(DevIndex, 0, slaveNo, 0, odIndex, value);
        }

        public int ReadSingleAInput(double address, EleAnalogType type, out double val)
        {
            throw new NotImplementedException();
        }

        public int GetOdData(int slaveNo, int odIndex, int subIndex, int length, ref uint value)
        {
            throw new NotImplementedException();
        }

        public int SetOdData(int slaveNo, int odIndex, int subIndex, int length, uint value)
        {
            throw new NotImplementedException();
        }

        public int SetAxisBand(int axisIdx, uint band, uint time)
        {
            return 0;
        }

        /// <summary>当前驱动未实现轴 PT 运动，不能返回虚假的 FIFO 剩余空间。</summary>
        public short GetPTSpace(int axisId, short fifo = 0, short card = 0)
        {
            throw new NotSupportedException("Lead.CPrim.PrimADLink_E 尚未实现轴 PT 运动及 FIFO 空间查询。");
        }

        public int AxisPTMove(int axisId, List<PtData> ptdatas, short fifo = 0, short card = 0)
        {
            throw new NotImplementedException();
        }

        #region LCT's MINICMP

        #endregion
    }
}
