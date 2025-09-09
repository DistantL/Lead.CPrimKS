using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Lead.CPrim.Interfaces;
using Lead.CPrim.LocalizationService;
using Lead.CPrim.LogHelper;
using Lead.CPrim.XmlHelper;

namespace Lead.CPrim.PrimLESI_EController
{
    public class PrimLESI_EController : IPrim, IMotionCard, IEtherCAT
    {
        private Dictionary<int, double> _axisEquiv = new Dictionary<int, double>();
        private LESI_EConfig _config = null;
        private bool _cycleCycleReadIOFlag = false;
        private bool _cycleCycleReadMotionFlag = false;
        private EBusConfig _eBusConfig = null;
        private bool _firstFlag = true;
        private IOInfos _ioInfos = null;
        private Control _primConfigUI = null;
        private Control _primDebugUI = null;
        private Control _primOutputUI = null;

        private bool[] _servoHoming = new bool[64];
        private Task _taskCycleReadIO = null;
        private Task _taskCycleReadMotion = null;
        private List<int> DiChangeAdr = new List<int>();

        private List<double> DiFallList = new List<double>();

        //所有需要触发改变事件的DI首地址
        private List<double> DiRiseList = new List<double>();

        private int[] _miniCmpEncoders = new int[16];
        public PrimLESI_EController()
        {
            _config = new LESI_EConfig();
            _eBusConfig = new EBusConfig();
            _ioInfos = new IOInfos();
            _primDebugUI = new PrimDebugControl(this);
            _primConfigUI = new PrimConfigControl(this);
            _primOutputUI = new PrimOutputControl(this);

            SetConn_RunState(PrimConnState.Other, PrimRunState.Other);
        }

        public PrimLESI_EController(XmlNode xmlNode)
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
            var dicDiModulePortNumInSlave = new Dictionary<int, int>();
            var dicDiModuleInSlave = new Dictionary<int, List<EDiModule>>();
            for (var i = 0; i < TotalSlaveNum; i++)
            {
                dicDiModulePortNumInSlave[i] = 0;
                var listDiModules = new List<EDiModule>();
                dicDiModuleInSlave[i] = listDiModules;

                if (DiModules.Count == 0)
                {
                    continue;
                }
                foreach (var diModule in DiModules.Values)
                {
                    if (diModule.SlaveNo != i)
                    {
                        continue;
                    }
                    listDiModules.Add(diModule);
                }

                if (listDiModules.Count == 0)
                {
                    continue;
                }
                //将当前从站下的所有DI模块排序
                listDiModules.Sort((a, b) => a.Id.CompareTo(b.Id));

                var diChannels = 0; //Di通道总数
                listDiModules.ForEach(p => diChannels += p.Num);

                var portNum = diChannels / 32 + ((diChannels % 32) > 0 ? 1 : 0);    //读取的端口总数

                dicDiModulePortNumInSlave[i] = portNum;
            }

            var di32MiniModule = new int[TotalSlaveNum];
            var do32MiniModule = new int[TotalSlaveNum];
            for (var i = 0; i < TotalSlaveNum; i++)
            {
                //di32MiniModule[i] = DiModules.Count(s => s.Value.SlaveNo == i && s.Value.TypeName.Contains("MINI"));
                //do32MiniModule[i] = DoModules.Count(s => s.Value.SlaveNo == i && s.Value.TypeName.Contains("MINI"));
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
                    for (ushort slaveNum = 0; slaveNum < TotalSlaveNum; slaveNum++)
                    {
                        if (dicDiModuleInSlave[slaveNum].Count == 0)
                        {
                            continue;
                        }

                        var inportValues = new uint[10];
                        for (ushort portNo = 0; portNo < dicDiModulePortNumInSlave[slaveNum]; portNo++)
                        {
                            //
                        }
                        inportValues[0] = 3420396283;
                        inportValues[1] = 3420396283;

                        var curDiChannelNum = 0;
                        var curPortNum = 0;
                        foreach (var diModule in dicDiModuleInSlave[slaveNum])
                        {
                            uint curDiModuleValue = 0;

                            var curPortValue = (uint)inportValues[curPortNum];
                            var num1 = curDiChannelNum % 32;    //从0到上一个模块的通道总数，看其是否是32的倍数，如不是，则与当前模块共用一个32位的端口，例如16
                            if (num1 > 0)  //余16、8、24，且已读取过
                            {
                                var num2 = 32 - num1;       //针对当前模块，读取当前端口获取的值能够分配的位数
                                if (diModule.Num <= num2)   //当前模块的通道数不大于剩余未分配的通道值
                                {
                                    curDiModuleValue = (curPortValue >> num1) & ((uint)Math.Pow(2, diModule.Num) - 1);
                                    if (diModule.Num == num2)
                                    {
                                        curPortNum += 1;
                                    }
                                }
                                else                        //当前模块的通道数大于剩余未分配的通道值
                                {
                                    var num3 = diModule.Num - num2; //下一个端口中需要读取的通道数目
                                    var curDimoduleValue1 = (curPortValue >> num1) & ((uint)Math.Pow(2, num2) - 1);
                                    if (num3 <= 32)
                                    {
                                        curPortNum += 1;
                                        var curDimoduleValue2 = (uint)inportValues[curPortNum] & ((uint)Math.Pow(2, num3) - 1);
                                        curDiModuleValue = (curDimoduleValue2 << num2) | curDimoduleValue1;
                                    }
                                    else
                                    {
                                        curPortNum += 1;
                                        var curDimoduleValue2 = (uint)inportValues[curPortNum] & ((uint)Math.Pow(2, 32) - 1);
                                        curPortNum += 1;
                                        var curDimoduleValue3 = (uint)inportValues[curPortNum] & ((uint)Math.Pow(2, num3 - 32) - 1);
                                        curDiModuleValue = (curDimoduleValue3 << (num3 - 32)) | (curDimoduleValue2 << 32) | curDimoduleValue1;
                                    }

                                }
                            }
                            else            //余数为0，之前的模块与通道数正好可以整取
                            {
                                if (diModule.Num <= 32)
                                {
                                    curDiModuleValue = curPortValue & ((uint)Math.Pow(2, diModule.Num) - 1);
                                    if (diModule.Num == 32)
                                    {
                                        curPortNum += 1;
                                    }
                                }
                                else
                                {
                                    curPortNum += 1;
                                    var curDiModuleValue1 = curPortValue | ((uint)inportValues[curPortNum] << (diModule.Num - 32));
                                    if (diModule.Num == 64)
                                    {
                                        curPortNum += 1;
                                    }
                                }
                            }
                            CheckDiChange(diModule.Value, curDiModuleValue, DiModules.FirstOrDefault(p => p.Value == diModule).Key);
                            diModule.Value = curDiModuleValue;
                            curDiChannelNum += diModule.Num;
                        }
                    }
                    //AI模块赋值
                    //foreach (var aiModule in AiModules)
                    //{
                    //    uint value = 0;
                    //    for (var j = 0; j < aiModule.Value.Num; j++)
                    //    {
                    //        Class_8338.GetInputStatus(DevIndex, aiModule.Value.SlaveNo, aiModule.Value.Id - (aiModule.Value.SlaveNo + 1) * 100, j, ref value);
                    //        aiModule.Value.Value[j] = value;
                    //    }
                    //}

                    //DO模块赋值
                    if (cycleCount++ < 50)
                    {
                        cycleCount = 0;
                        //
                    }

                    //运动状态
                    foreach (var axisK in Axises)
                    {
                        double value = -1;
                        var axis = axisK.Value;
                        axis.MotionIoStatus = LTSMC.smc_axis_io_status(ConnectNo, axis.Id);
                        axis.CheckDone = LTSMC.smc_check_done(ConnectNo, axis.Id) == 1;

                        ushort axis_statemachine = 0;
                        LTSMC.nmcs_get_axis_state_machine(ConnectNo, axis.Id, ref axis_statemachine);
                        axis.ServoOn = axis_statemachine == 4;

                        LTSMC.smc_get_position_unit(ConnectNo, axis.Id, ref value);
                        axis.CmdPos = value / _axisEquiv[axis.Id];

                        LTSMC.smc_get_encoder_unit(ConnectNo, axis.Id, ref value);
                        axis.ActualPos = value / _axisEquiv[axis.Id];

                        LTSMC.smc_read_current_speed_unit(ConnectNo, axis.Id, ref value);
                        axis.CmdVel = value / _axisEquiv[axis.Id];
                        axis.ActualVel = value / _axisEquiv[axis.Id];

                        LTSMC.smc_get_target_position_unit(ConnectNo, axis.Id, ref value);
                        axis.TargetPos = value / _axisEquiv[axis.Id];

                        //APS168.APS_get_error_position_f(axis.Id, ref value);
                        //axis.ErrPos = value / _axisEquiv[axis.Id];
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
                    //运动状态
                    foreach (var axisK in Axises)
                    {
                        double value = -1;
                        var axis = axisK.Value;
                        axis.MotionIoStatus = LTSMC.smc_axis_io_status(ConnectNo, axis.Id);
                        axis.CheckDone = LTSMC.smc_check_done(ConnectNo, axis.Id) == 1;
                        LTSMC.smc_get_position_unit(ConnectNo, axis.Id, ref value);
                        axis.CmdPos = value / _axisEquiv[axis.Id];

                        LTSMC.smc_get_encoder_unit(ConnectNo, axis.Id, ref value);
                        axis.ActualPos = value / _axisEquiv[axis.Id];

                        LTSMC.smc_read_current_speed_unit(ConnectNo, axis.Id, ref value);
                        axis.CmdVel = value / _axisEquiv[axis.Id];
                        axis.ActualVel = value / _axisEquiv[axis.Id];

                        LTSMC.smc_get_target_position_unit(ConnectNo, axis.Id, ref value);
                        axis.TargetPos = value / _axisEquiv[axis.Id];

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

        public event PrimDataRefresh OnPrimDataRefresh;

        public event PrimOpLog OnPrimOpLog;

        public event PrimStateChanged OnPrimStateChanged;

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

        public bool LogEnable
        {
            get => _config.LogEnable;
            set => _config.LogEnable = value;
        }

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
        internal ushort ConnectNo
        {
            get => (ushort)DevIndex;
        }
        internal string IpAddress
        {
            get => _config.IpAddress;
            set => _config.IpAddress = value;
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
            LTSMC.smc_board_close((ushort)DevIndex);
            SetConn_RunState(PrimConnState.Other, PrimRunState.Other);
            return 0;
        }

        public XmlNode IPrimExportConfigXml()
        {
            if (_config == null) { return null; }

            var node = XMLHelper.ObjectToXML(_config);
            ExportEBusConfig();
            ExportIoInfos();
            return node;
        }

        public int IPrimImportConfigXml(XmlNode xmlNode)
        {
            var iRet = 0;
            if (xmlNode != null)
            {
                _config = XMLHelper.XMLToObject(xmlNode, typeof(LESI_EConfig)) as LESI_EConfig;
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

            ushort startAxisId = 0;
            ushort maxSlaveNum = 0;
            uint maxAxisesNum = 0;

            var ret = 0;
            if (_firstFlag)
            {
                _firstFlag = false;
                ret = LTSMC.smc_board_init(ConnectNo, 2, IpAddress, 0);
                if (ret == 0)
                {
                    ret = LTSMC.nmcs_get_total_slaves(ConnectNo, 2, ref maxSlaveNum);
                    ret = LTSMC.nmcs_get_total_axes(ConnectNo, ref maxAxisesNum);
                }
            }

            if (ret < 0)
            {
                _firstFlag = true;
                MessageBox.Show($@"初始化板卡出错，出错代码：{ret}");
                LTSMC.smc_board_close(ConnectNo);

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

                foreach (var axis in Axises)
                {
                    SetAxisParam(axis.Value);
                }
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
                LTSMC.nmcs_driver_reset(ConnectNo, axis.Value.Id);
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
                MessageBox.Show($@"请先初始化控制器基元！");
                return -1;
            }

            if (PrimRunStat == PrimRunState.Running)
            {
                return 0;
            }

            SetConn_RunState(PrimConnState.Connected, PrimRunState.Running);

            if (CycleScanEnable && (_taskCycleReadIO == null || _taskCycleReadIO != null && (_taskCycleReadIO.IsCanceled || _taskCycleReadIO.IsCompleted)))
            {
                _taskCycleReadIO = new Task(CycleReadIO);
                _taskCycleReadIO.Start();
            }
            _cycleCycleReadIOFlag = true;

            if (_taskCycleReadMotion == null || _taskCycleReadMotion != null && (_taskCycleReadMotion.IsCanceled || _taskCycleReadMotion.IsCompleted))
            {
                _taskCycleReadMotion = new Task(CycleReadMotion);
                //_taskCycleReadMotion.Start();
            }
            _cycleCycleReadMotionFlag = true;
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

            var ret = LTSMC.smc_board_close(ConnectNo);
            if (ret < 0)
            {
                MessageBox.Show($@"关闭板卡失败，报错代码：{ret}");
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
            get;
            set;
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

            var minVel = 0d;
            var perVel = 0d;
            var tAcc = 0d;
            var tDec = 0d;
            var stopVel = 0d;
            LTSMC.smc_get_profile_unit(ConnectNo, (ushort)axisId, ref minVel, ref perVel, ref tAcc, ref tDec,
                ref stopVel);
            LTSMC.smc_set_profile_unit((ushort)DevIndex, (ushort)axisId, minVel, vel, tAcc, tDec, stopVel);
            return LTSMC.smc_pmove_unit(ConnectNo, (ushort)axisId, distance, 0);
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

            var minVel = 0d;
            var perVel = 0d;
            var tAcc = 0d;
            var tDec = 0d;
            var stopVel = 0d;
            LTSMC.smc_get_profile_unit(ConnectNo, (ushort)axisId, ref minVel, ref perVel, ref tAcc, ref tDec,
                ref stopVel);
            LTSMC.smc_set_profile_unit((ushort)DevIndex, (ushort)axisId, minVel, vel, tAcc, tDec, stopVel);
            return LTSMC.smc_pmove_unit(ConnectNo, (ushort)axisId, distance, 1);
        }

        public int AxisChangeVel(int axisId, double newVel)
        {
            return LTSMC.smc_change_speed_unit(ConnectNo, (ushort)axisId, newVel, 0);
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

            return (Axises[axisIdx].MotionIoStatus & (1 << 4)) != 0;
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

            return (Axises[axisIdx].MotionIoStatus & (1 << 7)) != 0;
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

            return (Axises[axisIdx].MotionIoStatus & (1 << 6)) != 0;
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
        public bool AxisSignalDStp(int axisIdx)
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

            return (Axises[axisIdx].MotionIoStatus & (1 << 3)) != 0;
        }

        public bool AxisSignalEz(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 9)) != 0;
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

            return (Axises[axisIdx].MotionIoStatus & (1 << 8)) != 0;
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
            
            return Axises[axisIdx].ServoOn;
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

            return Axises[axisIdx].CheckDone;
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

            position = Axises[axisIdx].ActualPos;
            return 0;
        }
        public int SetAxisFeedbackPulseToCommand(int axisIdx)
        {
            if (!AxisIsStop(axisIdx))
            {
                AxisStopMove(axisIdx);
                Thread.Sleep(500);
            }
            double pos = 0;
            LTSMC.smc_get_encoder_unit((ushort)DevIndex, (ushort)axisIdx, ref pos);
            return LTSMC.smc_set_position_unit((ushort)DevIndex, (ushort)axisIdx, pos);
        }

        public int SetAxisPositionAndFeedbackPulse(int axisIdx, int position)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            if (axisIdx < 5000)
            {
                LTSMC.smc_set_position_unit(ConnectNo, (ushort)axisIdx, position);
                LTSMC.smc_set_encoder_unit(ConnectNo, (ushort)axisIdx, position);
            }
            else
            {
                var chNo = axisIdx - 5000;
                var cmpModuleNo = chNo / 4;
                var encoderNo = chNo % 4;
                if (cmpModuleNo < 4)
                {
                    //var slaveNo = MiniCmpModules[cmpModuleNo].SlaveNo;
                    //lct_mini.Mini_Cmp_Lib.Encoder_SetCurrentData(DevIndex, slaveNo, encoderNo, position);
                }
            }
            return 0;
        }

        public int AxisJogStart(int axisId, int statOn, int jogDir)
        {
            var ret = 0;
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag || !AxisIsEnble(axisId)) return -1;

            try
            {
                if (statOn == 1)
                    LTSMC.smc_vmove(ConnectNo, (ushort)axisId, (ushort)jogDir);
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
        
        public int AxisResetAlarm(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return -1;
            }

            return LTSMC.nmcs_driver_reset(ConnectNo, (ushort)axisIdx);
        }

        public int AxisSetAcc(int axisId, double acc)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            var minVel = 0.0;
            var maxVel = 0.0;
            var oldTAcc = 0.0;
            var tDec = 0.0;
            var stopVel = 0.0;
            LTSMC.smc_get_profile_unit(ConnectNo, (ushort)axisId, ref minVel, ref maxVel, ref oldTAcc, ref tDec, ref stopVel);
            return LTSMC.smc_set_profile_unit(ConnectNo, (ushort)axisId, minVel, maxVel, acc,
                tDec, stopVel);
        }

        public int AxisSetAccDec(int axisId, double minVel, double maxVel, double tAcc, double tDec, double stopVel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            return LTSMC.smc_set_profile_unit(ConnectNo, (ushort)axisId, minVel, maxVel, tAcc,
                tDec, stopVel);
        }

        public int AxisSetAccDec(int axisId, double minVel, double maxVel, double tAcc, double tDec, double stopVel,
            double stTime)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }
            LTSMC.smc_set_profile_unit(ConnectNo, (ushort)axisId, minVel, maxVel, tAcc,
                            tDec, stopVel);
            return LTSMC.smc_set_s_profile(ConnectNo, (ushort)axisId, 0, stTime);
        }

        public int AxisSetDec(int axisId, double dec)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            var minVel = 0.0;
            var maxVel = 0.0;
            var tAcc = 0.0;
            var oldTDec = 0.0;
            var stopVel = 0.0;
            LTSMC.smc_get_profile_unit(ConnectNo, (ushort)axisId, ref minVel, ref maxVel, ref tAcc, ref oldTDec, ref stopVel);
            return LTSMC.smc_set_profile_unit(ConnectNo, (ushort)axisId, minVel, maxVel, tAcc,
                dec, stopVel);
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
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return -1;
            }

            var ret = 0;
            ushort errcode = 0;
            ushort axis_statemachine = 0;
            var timeOutCount = 0;
            LTSMC.nmcs_get_errcode(ConnectNo, 2, ref errcode);
            if (errcode == 0)       //总线正常才允许操作
            {
                if (enable && !AxisIsEnble(axisId))
                {

                    LTSMC.nmcs_set_axis_enable(ConnectNo, (ushort)axisId);
                    LTSMC.nmcs_get_axis_state_machine(ConnectNo, (ushort)axisId, ref axis_statemachine);
                    while (axis_statemachine != 4)
                    {
                        LTSMC.nmcs_set_axis_enable(ConnectNo, (ushort)axisId);
                        LTSMC.nmcs_get_axis_state_machine(ConnectNo, (ushort)axisId, ref axis_statemachine);
                        if (timeOutCount++ > 20)
                        {
                            return -10;
                        }
                    }
                }
                else if (!enable && AxisIsEnble(axisId))
                {

                    LTSMC.nmcs_set_axis_disable(ConnectNo, (ushort)axisId);
                    LTSMC.nmcs_get_axis_state_machine(ConnectNo, (ushort)axisId, ref axis_statemachine);
                    while (axis_statemachine != 4)
                    {
                        LTSMC.nmcs_set_axis_disable(ConnectNo, (ushort)axisId);
                        LTSMC.nmcs_get_axis_state_machine(ConnectNo, (ushort)axisId, ref axis_statemachine);
                        if (timeOutCount++ > 20)
                        {
                            return -10;
                        }
                    }
                }
                else
                {
                    ret = 0;
                }
            }
            else
            {
                return -1;
            }


            return ret;
        }
        
        public int AxisSetMaxVel(int axisId, double maxVel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            var minVel = 0.0;
            var oldMaxVel = 0.0;
            var tAcc = 0.0;
            var tDec = 0.0;
            var stopVel = 0.0;
            LTSMC.smc_get_profile_unit(ConnectNo, (ushort)axisId, ref minVel, ref oldMaxVel,
                ref tAcc, ref tDec, ref stopVel);
            return LTSMC.smc_set_profile_unit(ConnectNo, (ushort)axisId, minVel, maxVel,
                tAcc, tDec, stopVel);
        }

        public int AxisSetMinVel(int axisId, double minVel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            var oldMinVel = 0.0;
            var maxVel = 0.0;
            var tAcc = 0.0;
            var tDec = 0.0;
            var stopVel = 0.0;
            LTSMC.smc_get_profile_unit(ConnectNo, (ushort)axisId, ref oldMinVel, ref maxVel,
                ref tAcc, ref tDec, ref stopVel);
            return LTSMC.smc_set_profile_unit(ConnectNo, (ushort)axisId, minVel, maxVel,
                tAcc, tDec, stopVel);
        }

        public int AxisSetSoftLimit(int axisId, bool sPelEnable, bool sMelEnable, double sPelValue, double sMelValue)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            ushort oldElEnable = 0;
            ushort elSource = 0;
            ushort elAction = 0;
            double oldSPelValue = 0;
            double oldSMelValue = 0;
            LTSMC.smc_get_softlimit_unit(ConnectNo, (ushort)axisId, ref oldElEnable, ref elSource, ref elAction,
                ref oldSPelValue, ref oldSMelValue);
            return LTSMC.smc_set_softlimit_unit(ConnectNo, (ushort)axisId,
                sPelEnable || sMelEnable ? (ushort)1 : (ushort)0, elSource, elAction, sMelValue,sPelValue);
        }

        public int AxisSetStopVel(int axisId, double stopVel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            var minVel = 0.0;
            var maxVel = 0.0;
            var tAcc = 0.0;
            var tDec = 0.0;
            var oldStopVel = 0.0;
            LTSMC.smc_get_profile_unit(ConnectNo, (ushort)axisId, ref minVel, ref maxVel,
                ref tAcc, ref tDec, ref oldStopVel);
            return LTSMC.smc_set_profile_unit(ConnectNo, (ushort)axisId, minVel, maxVel,
                tAcc, tDec, stopVel);
        }

        public int AxisStopMove(int axisIdx)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return -1;
            }
            if (DecStopEnable)
            {
                LTSMC.smc_set_dec_stop_time(ConnectNo, (ushort)axisIdx, DecStopTime <= 0 ? 0.1 : DecStopTime);
            }
            return LTSMC.smc_stop(ConnectNo, (ushort)axisIdx, DecStopEnable ? (ushort)0 : (ushort)1);
        }
        public int StopAllAxes()
        {
            return LTSMC.smc_emg_stop(ConnectNo);
        }
        public int AxisVelMove(int axisId, double maxVel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag || !AxisIsEnble(axisId))
            {
                return -1;
            }

            ushort velDir = maxVel >= 0 ? (ushort)1 : (ushort)0;
            var minVel = 0.0;
            var oldMaxVel = 0.0;
            var tAcc = 0.0;
            var tDec = 0.0;
            var stopVel = 0.0;
            LTSMC.smc_get_profile_unit(ConnectNo, (ushort)axisId, ref minVel, ref oldMaxVel,
                ref tAcc, ref tDec, ref stopVel);
            LTSMC.smc_set_profile_unit(ConnectNo, (ushort)axisId, minVel, Math.Abs(maxVel),
                tAcc, tDec, stopVel);

            return LTSMC.smc_vmove(ConnectNo, (ushort)axisId, velDir);
        }
        #region 回原点运动

        public int AxisSetHomeMode(int axisId, int homeDir, int velMode, int homeMode, int posSource)
        {
            //VelMode:0-低速回零，1-高速回零
            return LTSMC.smc_set_homemode(ConnectNo, Convert.ToUInt16(axisId),
                Convert.ToUInt16(homeDir), velMode, Convert.ToUInt16(homeMode), (ushort)posSource);
        }

        public int AxisSetHomeMode(int axisId, int homeMode, int posSource)
        {
            double velMode = 0;
            ushort oldHomeMode = 0;
            ushort homeDir = 0;
            ushort ezCount = 0;
            LTSMC.smc_get_homemode(ConnectNo, Convert.ToUInt16(axisId), ref homeDir, ref velMode,
                ref oldHomeMode, ref ezCount); 
            return LTSMC.smc_set_homemode(ConnectNo, Convert.ToUInt16(axisId), homeDir,
                    velMode, (ushort)homeMode, (ushort)posSource);
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

            return Servo_home_move(axis.Value, homeMode, vm, vo, acc, shift, asyncMode, posSource);
        }
        private int Servo_home_move(EAxis axis, int homeMode, double vm, double vo, double acc, double shift, bool asyncMode, int posSource = 1)
        {
            _servoHoming[axis.Id] = true;

            //设置回零参数
            var pramHomeMode = Convert.ToUInt16(homeMode);
            var pramVm = Convert.ToInt32(vm * _axisEquiv[axis.Id]);
            var pramVo = Convert.ToInt32(vo * _axisEquiv[axis.Id]);
            var pramAcc = Convert.ToInt32(acc * _axisEquiv[axis.Id]);
            var pramShift = Convert.ToInt32(shift * _axisEquiv[axis.Id]);

            LTSMC.smc_set_homemode(ConnectNo, axis.Id, 0, 0, pramHomeMode, (ushort)posSource);
            LTSMC.smc_set_home_profile_unit(ConnectNo, axis.Id, pramVm, pramVo, pramVm / pramAcc, pramVm / pramAcc);
            //LTSMC.nmcs_set_home_profile(ConnectNo, axis.Id, pramHomeMode, pramVm, pramVo, pramVm / pramAcc, pramVm / pramAcc, pramShift);
            //轴使能
            ushort errcode = 0;
            ushort axis_statemachine = 0;
            LTSMC.nmcs_get_errcode(ConnectNo, 2, ref errcode);
            if (errcode == 0)
            {
                LTSMC.nmcs_set_axis_enable(ConnectNo, axis.Id);
                LTSMC.nmcs_get_axis_state_machine(ConnectNo, axis.Id, ref axis_statemachine);
                while (axis_statemachine != 4)
                {
                    LTSMC.nmcs_set_axis_enable(ConnectNo, axis.Id);
                    LTSMC.nmcs_get_axis_state_machine(ConnectNo, axis.Id, ref axis_statemachine);
                }
            }

            //开始回零
            LTSMC.nmcs_home_move(ConnectNo, axis.Id);

            Func<EAxis, int> a = WaitServoDone;
            //if (asyncMode)
            //{
            //    a.BeginInvoke(axis, null, null);
            //    return 0;
            //}

            return a.Invoke(axis);
        }

        private int SetCspMode(EAxis axis)
        {

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
                        //LogAdd(string.Format(NLocalizer.GetString("EleCartesian_EleCartesian_LimitMessage", "{0}'s {1} is in Limit: PEL-{2}, Mel-{3},SPEL-{4}, SMel-{5}, or has some alarm-{6} "), Name, Axises[axisIndex].Name, Axises[axisIndex].InPel, Axises[axisIndex].InMel, Axises[axisIndex].InSPel, Axises[axisIndex].InSMel, Axises[axisIndex].IsAlarm), AlarmLv.Error, 200 + errMethodId);
                        SetRunState(PrimRunState.Err);
                        iRet = -10;
                        break;
                    }
                }

                if (homeMode && AxisSignalInp(axisId))
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

            //LogAdd(errMsg + NLocalizer.GetString("EleCartesian_EleCartesian_TimeOutHappened", " TimeOut happened."), AlarmLv.Error, 400 + errMethodId);
            iRet = -30;
            SetRunState(PrimRunState.Err);

            return iRet;
        }

        private int WaitServoDone(EAxis axis)
        {
            ushort homeDone = 0;
            do
            {
                Thread.Sleep(100);
                Application.DoEvents();
            } while (!AxisIsStop(axis.Id));
            LTSMC.smc_get_home_result(ConnectNo, axis.Id, ref homeDone);
            if (homeDone == 1)
            {
                LTSMC.smc_set_position_unit(ConnectNo, axis.Id, 0);
                var pulse = 0.0;
                GetFeedbackPulse(axis.Id, ref pulse);
                SetAxisPositionAndFeedbackPulse(axis.Id, (int)pulse);
                Thread.Sleep(200);
            }

            _servoHoming[axis.Id] = false;

            LogAdd($@"{Name} 's Axis{axis.Id} home finished.", LogLevel.Info, 100 + axis.Id);
            return 0;
        }
        #endregion
        #region 插补相关

        public int GetAxisMotionMulticoorStatus(short crd)
        {
            return LTSMC.smc_check_done_multicoor(ConnectNo, (ushort)crd);
        }

        public int Interpolation_Pause(int crd)
        {
            return LTSMC.smc_conti_pause_list(ConnectNo, (ushort)crd);
        }

        public int Interpolation_Start(int crd)
        {
            return LTSMC.smc_conti_start_list(ConnectNo, (ushort)crd);
        }

        public int Interpolation_Stop(int crd, int stopMode)
        {
            return LTSMC.smc_conti_stop_list(ConnectNo, (ushort)crd, (ushort)stopMode);
        }

        public int InterpolationMove(ushort Crd, ushort AxisNum, ushort[] AxisArry, List<TrajPos> trajPos)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadMotionFlag)
            {
                return -1;
            }

            LTSMC.smc_conti_open_list(ConnectNo, Crd, AxisNum, AxisArry);   //打开连续插补缓存区
            foreach (var item in trajPos)
            {
                if (!item.TrajEnable) continue;

                LTSMC.smc_set_vector_profile_unit(ConnectNo, Crd, 0, item.TrajVm, item.Tacc, item.Tdec, 0);
                LTSMC.smc_conti_line_unit(ConnectNo, Crd, AxisNum, AxisArry, item.Pos, 1, 0);
            }
            LTSMC.smc_conti_start_list(ConnectNo, Crd);
            LTSMC.smc_conti_close_list(ConnectNo, Crd);
            return 0;
        }

        public int GetInterpolationSta(int crd)
        {
            //0： 运动中， 1： 暂停中， 2： 正常停止， 3： 未启动， 4： 空闲， 5： 异常停止
            return LTSMC.smc_conti_get_run_state(ConnectNo, (ushort)crd);
        }
        public int StartInterPolation(ushort Crd)
        {
            LTSMC.smc_conti_start_list(ConnectNo, Crd);
            return LTSMC.smc_conti_close_list(ConnectNo, Crd);
        }

        public int AddInterPolationDO_OnStopAhead(ushort Crd, ushort DoAdr, bool On_Off, ushort isTimemode, double delayCount1,
            double delayConut2)
        {
            int val = On_Off ? 0 : 1;
            return LTSMC.smc_conti_ahead_outbit_to_stop(ConnectNo, Crd, DoAdr, (ushort)val, delayCount1, isTimemode, delayConut2);
        }

        public int AddInterPolationDO_OnStopDelay(ushort Crd, ushort DoAdr, bool On_Off, double delayCount1, double delayConut2)
        {
            int val = On_Off ? 0 : 1;
            return LTSMC.smc_conti_delay_outbit_to_stop(ConnectNo, Crd, DoAdr, (ushort)val, delayCount1, delayConut2);
        }

        public int AddInterPolationDO_OnStartDelay(ushort Crd, ushort DoAdr, bool On_Off, ushort isTimemode, double delayCount1,
            double delayConut2)
        {
            int val = On_Off ? 0 : 1;
            return LTSMC.smc_conti_delay_outbit_to_start(ConnectNo, Crd, DoAdr, (ushort)val, delayCount1, isTimemode, delayConut2);
        }

        public int AddInterPolationDO(ushort Crd, ushort DoAdr, bool On_Off, double DelayTimeS)
        {
            int val = On_Off ? 0 : 1;
            return LTSMC.smc_conti_write_outbit(ConnectNo, Crd, DoAdr, (ushort)val, DelayTimeS);
        }

        public int AddInterPolationDelayS(ushort Crd, double DelayTimeS)
        {
            return LTSMC.smc_conti_delay(ConnectNo, Crd, DelayTimeS, 0);
        }

        public int AddInterPolationPoint(ushort Crd, ushort AxisNum, ushort[] AxisArry, TrajPos trajPos)
        {
            LTSMC.smc_set_vector_profile_unit(ConnectNo, Crd, 0, trajPos.TrajVm, trajPos.Tacc, trajPos.Tdec, 0);
            return LTSMC.smc_conti_line_unit(ConnectNo, Crd, AxisNum, AxisArry, trajPos.Pos, 1, 0);
        }

        public int WaitDI(ushort Crd, ushort DiAdr, bool On_Off, double TimeOutS = 0)
        {
            int val = On_Off ? 0 : 1;
            return LTSMC.smc_conti_wait_input(ConnectNo, Crd, DiAdr, (ushort)val, TimeOutS, 0);
        }

        #endregion
        #region 高速触发相关
        public int SetLinearCompareTrig(int trigCh, int trigStart, int freq, int count)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            var iRet = new int[2];
            iRet[0] = LTSMC.smc_hcmp_set_liner_unit(ConnectNo, (ushort)trigCh, freq, count);
            iRet[1] = LTSMC.smc_hcmp_add_point_unit(ConnectNo, (ushort)trigCh, trigStart);

            if (iRet.All(i => i == 0)) return 0;

            return -10;
        }

        public int SetTrigDir(int trigCh, int dir)
        {
            return 0;
        }

        public int SetTriggerConfig(int trigChannel, int axisId, int trigSource, int trigLogic, double widthTime)
        {
            return LTSMC.smc_hcmp_set_config(ConnectNo, (ushort)trigChannel, (ushort)axisId,
                (ushort)trigSource, (ushort)trigLogic, (int)widthTime);
        }

        public int GetTriggerCount(int trigCh, ref int count)
        {
            var remainedPoints = 0;
            var currentPoint = 0.0;

            return LTSMC.smc_hcmp_get_current_state_unit(ConnectNo, (ushort)trigCh, ref remainedPoints,
                ref currentPoint, ref count);
        }
        public int ResetTriggerCount(int trigCh)
        {
            //if (_cardTypes[DevIndex] == 0x5800 || _cardTypes[DevIndex] == 0x5600 || _cardTypes[DevIndex] == 0x5400 || _cardTypes[DevIndex] == 0x5C00)
            //    return LTDMC.dmc_hcmp_fifo_clear_points((ushort)DevIndex, (ushort)trigCh);
            return LTSMC.smc_hcmp_clear_points(ConnectNo, (ushort)trigCh);
        }

        public int SetTrigOutputLogic(int trigCh, int logic)
        {
            //0-低电平，1-高电平
            ushort axis = 0;
            ushort cmpSource = 0;
            ushort oldLogic = 0;
            var time = 0;
            LTSMC.smc_hcmp_get_config(ConnectNo, (ushort)trigCh, ref axis, ref cmpSource, ref oldLogic,
                ref time);
            return LTSMC.smc_hcmp_set_config(ConnectNo, (ushort)trigCh, axis, cmpSource, (ushort)logic, time);
        }

        public int SetTrigOutputPulseWidth(int trigCh, double widthTime)
        {
            ushort axis = 0;
            ushort cmpSource = 0;
            ushort cmpLogic = 0;
            var oldTime = 0;
            LTSMC.smc_hcmp_get_config(ConnectNo, (ushort)trigCh, ref axis, ref cmpSource, ref cmpLogic,
                ref oldTime);
            return LTSMC.smc_hcmp_set_config(ConnectNo, (ushort)trigCh, axis, cmpSource, cmpLogic,
                (int)widthTime);
        }
        public int SetTriggerChannelMode(int channel, int mode)
        {
            if (channel < 0 || channel > 3 || mode < 0 || mode > 5) return -10;

            //cmp_mode: 0-禁止，1-等于，2-小于，3-大于，4-队列，5-线性
            //if (_cardTypes[DevIndex] == 0x5800 || _cardTypes[DevIndex] == 0x5600 || _cardTypes[DevIndex] == 0x5400 || _cardTypes[DevIndex] == 0x5C00)
            //    LTDMC.dmc_hcmp_fifo_set_mode((ushort)DevIndex, (ushort)channel, 1);

            return LTSMC.smc_hcmp_set_mode(ConnectNo, (ushort)channel, (ushort)mode);
        }

        public int SetTriggerTable(int tCmpCh, double[] dataArr, int arrSize)
        {
            //if (_cardTypes[DevIndex] == 0x5800 || _cardTypes[DevIndex] == 0x5600 || _cardTypes[DevIndex] == 0x5400 || _cardTypes[DevIndex] == 0x5C00)
            //    return LTDMC.dmc_hcmp_fifo_add_table((ushort)DevIndex, (ushort)tCmpCh, (ushort)arrSize, dataArr);

            for (var i = 0; i < dataArr.Length; i++) AddTrigPoint(tCmpCh, (int)dataArr[i]);

            return 0;
        }
        public int SetManualTrig(int trigCh, int pulseWidth = 200)
        {
            if (trigCh < 0 || trigCh > 3) return -10;

            ushort oldCmpMode = 0;
            LTSMC.smc_hcmp_get_mode(ConnectNo, (ushort)trigCh, ref oldCmpMode);
            //先禁止CMP功能
            LTSMC.smc_hcmp_set_mode(ConnectNo, (ushort)trigCh, 0);

            //0-低电平，1-高电平
            ushort axis = 0;
            ushort cmpSource = 0;
            ushort logic = 0;
            var oldWidth = 0;
            LTSMC.smc_hcmp_get_config(ConnectNo, (ushort)trigCh, ref axis, ref cmpSource, ref logic,
                ref oldWidth);
            LTSMC.smc_hcmp_set_config(ConnectNo, (ushort)trigCh, axis, cmpSource, logic, pulseWidth);

            LTSMC.smc_write_cmp_pin(ConnectNo, (ushort)trigCh, logic == 0 ? (ushort)1 : (ushort)0);
            Thread.Sleep(200);
            var pinValue1 = LTSMC.smc_read_cmp_pin(ConnectNo, (ushort)trigCh);
            if (logic == 0 && pinValue1 == 1 || logic == 1 && pinValue1 == 0)
            {
                LTSMC.smc_write_cmp_pin(ConnectNo, (ushort)trigCh, logic == 0 ? (ushort)0 : (ushort)1);
                Thread.Sleep(200);
                var pinValue2 = LTSMC.smc_read_cmp_pin(ConnectNo, (ushort)trigCh);
                if (logic == 0 && pinValue2 == 0 || logic == 1 && pinValue2 == 1)
                {
                    LTSMC.smc_hcmp_set_config(ConnectNo, (ushort)trigCh, axis, cmpSource, logic, oldWidth);
                    LTSMC.smc_hcmp_set_mode(ConnectNo, (ushort)trigCh, oldCmpMode);
                    return 0;
                }

                LTSMC.smc_hcmp_set_config(ConnectNo, (ushort)trigCh, axis, cmpSource, logic, oldWidth);
                LTSMC.smc_hcmp_set_mode(ConnectNo, (ushort)trigCh, oldCmpMode);
                return -2;
            }

            LTSMC.smc_hcmp_set_config(ConnectNo, (ushort)trigCh, axis, cmpSource, logic, oldWidth);
            LTSMC.smc_hcmp_set_mode(ConnectNo, (ushort)trigCh, oldCmpMode);
            return -1;
        }
        public int AddTrigPoint(int trigCh, int value)
        {
            return LTSMC.smc_hcmp_add_point_unit(ConnectNo, (ushort)trigCh, value);
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
            //if (moduleNo >= MiniCmpModules.Length)
            {
                return -2;
            }

            //slaveNo = MiniCmpModules[moduleNo].SlaveNo;
            realTrigCh = trigCh % 4;
            return 0;
        }
        #endregion
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

        public List<EcatNode> Nodes
        {
            get => _eBusConfig.Nodes;
            set => _eBusConfig.Nodes = value;
        }

        public ConcurrentDictionary<int, EAiModule> AiModules
        {
            get;
            set;
        } = new ConcurrentDictionary<int, EAiModule>();

        public ConcurrentDictionary<int, EAoModule> AoModules
        {
            get;
            set;
        } = new ConcurrentDictionary<int, EAoModule>();

        public ConcurrentDictionary<int, EAxis> Axises
        {
            get;
            set;
        } = new ConcurrentDictionary<int, EAxis>();

        public ConcurrentDictionary<int, EDiModule> DiModules
        {
            get;
            set;
        } = new ConcurrentDictionary<int, EDiModule>();

        public ConcurrentDictionary<int, EDoModule> DoModules
        {
            get;
            set;
        } = new ConcurrentDictionary<int, EDoModule>();

        public IOInfos IoInfos
        {
            get => _ioInfos;
            set => _ioInfos = value;
        }

        public int TotalAiModuleNum
        {
            get;
            set;
        }

        public int TotalAoModuleNum
        {
            get;
            set;
        }

        public int TotalAxisNum
        {
            get => _eBusConfig.TotalAxisNum;
            set => _eBusConfig.TotalAxisNum = value;
        }

        public int TotalDiModuleNum
        {
            get;
            set;
        }

        public int TotalDoModuleNum
        {
            get;
            set;
        }

        public int TotalSlaveNum
        {
            get => _eBusConfig.TotalSlaveNum;
            set => _eBusConfig.TotalSlaveNum = value;
        }
        #endregion Override EBusConfig's Property

        #region Others

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

        private void LogAdd(string log, LogLevel lv, int id)
        {
            if (!LogEnable)
            {
                return;
            }

            switch (lv)
            {
                case LogLevel.Fatal:
                    Log.Fatal(12530000 + id, log, LogClassification.VisioPrim, Name);
                    PrimAlarmLv = LogLevel.Fatal;
                    SetRunState(PrimRunState.Err);
                    break;

                case LogLevel.Error:
                    Log.Error(22530000 + id, log, LogClassification.VisioPrim, Name);
                    PrimAlarmLv = LogLevel.Error;
                    SetRunState(PrimRunState.Err);
                    break;

                case LogLevel.Warn:
                    Log.Warn(32530000 + id, log, LogClassification.VisioPrim, Name);
                    PrimAlarmLv = LogLevel.Warn;
                    SetRunState(PrimRunState.Err);
                    break;

                case LogLevel.Info:
                    Log.Info(42530000 + id, log, LogClassification.VisioPrim, Name);
                    PrimAlarmLv = LogLevel.Info;
                    break;

                case LogLevel.Debug:
                    Log.Debug(52530000 + id, log, LogClassification.VisioPrim, Name);
                    PrimAlarmLv = LogLevel.Debug;
                    break;

                case LogLevel.Trace:
                    Log.Trace(62530000 + id, log, LogClassification.VisioPrim, Name);
                    PrimAlarmLv = LogLevel.Trace;
                    break;

                default:
                    break;
            }
        }

        public int ExportEBusConfig()
        {
            var ret = false;
            if (!string.IsNullOrEmpty(EBusConfigFilePath) && _eBusConfig != null)
            {
                ret = JsonHelper.JsonHelper.SerializeObjectToFile(_eBusConfig, EBusConfigFilePath);
            }
            return ret ? 0 : -1;
        }

        public int ExportIoInfos()
        {
            var ret = false;
            if (!string.IsNullOrEmpty(IOInfosFilePath) && _ioInfos != null)
            {
                ret = JsonHelper.JsonHelper.SerializeObjectToFile(_ioInfos, IOInfosFilePath);
            }
            return ret ? 0 : -1;
        }

        internal int FirstScanField()
        {
            uint totalAxisesNum = 0;
            ushort totalSlaveNum = 0;

            LTSMC.smc_board_close(ConnectNo);
            var ret = 0;
            ret = LTSMC.smc_board_init(ConnectNo, 2, IpAddress, 0);
            if (ret < 0)
            {
                MessageBox.Show($@"初始化板卡出错，出错代码：{ret}");
                LTSMC.smc_board_close(ConnectNo);

                return -1;
            }

            ret = LTSMC.nmcs_get_total_slaves(ConnectNo, 2, ref totalSlaveNum);//获取从站数目
            ret = LTSMC.nmcs_get_total_axes(ConnectNo, ref totalAxisesNum);//获取轴数目
            var listAxisesNodeId = new List<ushort>();
            if (ret == 0)
            {
                if (totalSlaveNum != (ushort)TotalSlaveNum)
                {
                    var ret1 = MessageBox.Show($@"已有配置中的从站数目-{TotalSlaveNum}和扫描获取到的从站数目-{totalSlaveNum}不一致。", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (ret1 != DialogResult.Yes)
                    {
                        LTSMC.smc_board_close(ConnectNo);
                        return -5;
                    }

                    TotalSlaveNum = totalSlaveNum;

                    //if (totalAxisesNum != (ushort)TotalAxisNum)
                    {
                        //ret1 = MessageBox.Show($@"已有配置中的轴数目-{TotalAxisNum}和扫描获取到的轴数目-{totalAxisesNum}不一致。", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        //if (ret1 != DialogResult.Yes)
                        //{
                        //    LTSMC.smc_board_close(ConnectNo);
                        //    return -5;
                       //}

                        Axises.Clear();
                        ushort slaveAddr = 0;
                        ushort subSlaveAddr = 0;
                        
                        for (ushort i = 0; i < totalAxisesNum; i++)
                        {
                            LTSMC.nmcs_get_axis_node_address(ConnectNo, i, ref slaveAddr, ref subSlaveAddr);
                            Axises.TryAdd(i, new EAxis(slaveAddr, i));
                            listAxisesNodeId.Add(slaveAddr);
                        }
                        TotalAxisNum = (int)totalAxisesNum;
                    }
                    //else
                    //{
                    //    MessageBox.Show($@"已有配置中的轴数目-{TotalAxisNum}和扫描获取到的轴数目-{totalAxisesNum}一致，轴配置无需修改", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    //    LTSMC.smc_board_close(ConnectNo);
                    //}
                    
                    //清除模块配置
                    Nodes.Clear();
                    DiModules.Clear();
                    DoModules.Clear();
                    AiModules.Clear();
                    AoModules.Clear();

                    var startAxisId = 0;
                    for (ushort i = 0; i < TotalSlaveNum; i++)  //汇总所有从站信息
                    {
                        ushort nodeId = (ushort)(i + 1001);
                        Nodes.Add(listAxisesNodeId.Contains(nodeId)
                                ? new EcatNode(nodeId, EcatNodeType.Axis, Axises[startAxisId++].Id)
                                : new EcatNode(nodeId, EcatNodeType.Other));
                    }
                }
                else
                {
                    MessageBox.Show($@"已有配置中的从站数目-{TotalSlaveNum}和扫描获取到的从站数目-{totalSlaveNum}一致，配置无需修改", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    LTSMC.smc_board_close(ConnectNo);
                    return 0;
                }
                
            }
            else
            {
                MessageBox.Show($@"控制器初始化扫描失败，报错代码：{ret}");
                LTSMC.smc_board_close(ConnectNo);
                return -1;
            }

            MessageBox.Show($@"板卡初始化扫描成功，总计从站数目：{TotalSlaveNum}，总计轴个数：{TotalAxisNum}");
            return 0;
        }
        public void UpdateModules()
        {
            var totalDiModuleNum = 0;
            var totalDoModuleNum = 0;
            var totalAiModuleNum = 0;
            var totalAoModuleNum = 0;
            DiModules.Clear();
            DoModules.Clear();
            AiModules.Clear();
            AoModules.Clear();
            if (Nodes.Count > 0)
            {
                Nodes.Sort((a, b) => a.NodeID.CompareTo(b.NodeID));
                foreach (var node in Nodes)
                {
                    if (node.NodeType == EcatNodeType.DI)
                    {
                        if (node.InputCount > 0)
                        {
                            DiModules.TryAdd(node.InAddress, new EDiModule(node.NodeID, node.InAddress, node.InputCount, 0));
                        }
                    }
                    if (node.NodeType == EcatNodeType.DO)
                    {
                        if (node.OutputCount > 0)
                        {
                            DoModules.TryAdd(node.OutAddress, new EDoModule(node.NodeID, node.OutAddress, node.InputCount, 0));
                        }
                    }
                    if (node.NodeType == EcatNodeType.AI)
                    {
                        if (node.InputCount > 0)
                        {
                            AiModules.TryAdd(node.InAddress, new EAiModule(node.NodeID, node.InAddress,"", node.InputCount, new double[node.InputCount]));
                        }
                    }
                    if (node.NodeType == EcatNodeType.AO)
                    {
                        if (node.OutputCount > 0)
                        {
                            AoModules.TryAdd(node.OutAddress, new EAoModule(node.NodeID, node.OutAddress, "", node.OutputCount, new double[node.OutputCount]));
                        }
                    }
                }
            }

            TotalDiModuleNum = DiModules.Count;
            TotalDoModuleNum = DoModules.Count;
            TotalAiModuleNum = AiModules.Count;
            TotalAoModuleNum = AoModules.Count;
        }
        public void LoadConfigFile(string filePath)
        {
            return;
        }

        public int ImportEBusConfig()
        {
            if (!string.IsNullOrEmpty(EBusConfigFilePath) && File.Exists(EBusConfigFilePath))
            {
                _eBusConfig = JsonHelper.JsonHelper.DeserializeJsonFileToObject<EBusConfig>(EBusConfigFilePath);
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
                _ioInfos = JsonHelper.JsonHelper.DeserializeJsonFileToObject<IOInfos>(IOInfosFilePath);
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

        public int LoadAxisParam(int axisId, ref DefaultParameter axisParam, ref HomeParameter homeParam, ref JogParameter jogParam)
        {
            var ret = -1.0;
            double minVel = 0;
            double maxVel = 0;
            double tAcc = 0;
            double tDec = 0;
            double stopVel = 0;
            double sPara = 0;
            LTSMC.smc_get_profile_unit(ConnectNo, (ushort)axisId, ref minVel, ref maxVel, ref tAcc, ref tDec, ref stopVel);
            LTSMC.smc_get_s_profile(ConnectNo, (ushort)axisId, 0, ref sPara);

            axisParam.Curve = sPara;
            axisParam.Acc = tAcc;
            axisParam.Dec = tDec;
            axisParam.Vs = minVel;
            axisParam.Vm = maxVel;
            axisParam.Ve = stopVel;

            double lowVel = 0;
            double highVel = 0;
            ushort homeDir = 0;
            double velMode = 0;
            ushort homeMode = 0;
            ushort posSource = 0;
            LTSMC.smc_get_home_profile_unit(ConnectNo, (ushort)axisId, ref lowVel, ref highVel, ref tAcc, ref tDec);
            LTSMC.smc_get_homemode(ConnectNo, (ushort)axisId, ref homeDir, ref velMode, ref homeMode, ref posSource);
            
            homeParam.Mode = homeMode;
            homeParam.Dir = homeDir;
            homeParam.Curve = 0;
            homeParam.Acc = tAcc;
            homeParam.Vs = lowVel;
            homeParam.Vm = highVel;
            homeParam.Shift = 0;

            ushort ezEnable = 0;
            ushort ezLogic = 0;
            ushort ezSource = 0;
            LTSMC.smc_get_ezlatch_mode(ConnectNo, (ushort) axisId, ref ezEnable, ref ezLogic, ref ezSource);
            homeParam.Eza = ezEnable != 0;
            homeParam.Ez_Dir = ezLogic;
            
            return 0;
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
                //
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

        public int ReadDiModule(int startAddr, out int value)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadIOFlag)
            {
                value = 0;
                return -1;
            }

            if (!CycleScanEnable)
            {
                uint readValue = 0;
                //LTSMC.nmcs_read_inport(ConnectNo, 2, DiModules[startAddr].Id)
               
                value = (int)readValue;
            }
            else
            {
                value = (int)DiModules[startAddr].Value;
            }
            return 0;
        }

        public int ReadDoModule(int startAddr, out int value)
        {
            value = 0;
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !_cycleCycleReadIOFlag)
            {   
                return -1;
            }

            if (!CycleScanEnable)
            {
                //Class_8338.SelfDefine_Get_8_Channel_Value(DevIndex, DoModules[startAddr].SlaveNo, (DoModules[startAddr].Id - (DoModules[startAddr].SlaveNo + 1) * 100) * 8, out var doModulesValue);
                //value = (int)doModulesValue;
            }
            else
            {
                value = (int)DoModules[startAddr].Value;
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
            var curVal = false;
            return 0;
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

            if (DiFallList.Contains(address)) DiFallList.Contains(address);

            return 0;
        }

        public int RemoveDOChanged(double address)
        {
            return 0;
        }

        public int SetAxisJogParam(EAxis axis)
        {
            AxisEquivToDic(Axises);
            //
            return 0;
        }

        public int SetAxisParam(EAxis axis)
        {
            AxisEquivToDic(Axises);
            ushort axisId = axis.Id;

            LTSMC.smc_set_profile_unit(ConnectNo, axisId, axis.DefaultParam.Vs, axis.DefaultParam.Vm, axis.DefaultParam.Acc, axis.DefaultParam.Dec, axis.DefaultParam.Ve);
            LTSMC.smc_set_s_profile(ConnectNo, axisId, 0, axis.DefaultParam.Curve);

            double lowVel = 0;
            double highVel = 0;
            ushort homeDir = 0;
            double velMode = 0;
            ushort homeMode = 0;
            ushort posSource = 0;
            LTSMC.smc_set_home_profile_unit(ConnectNo, axisId, axis.HomeParam.Vs, axis.HomeParam.Vm, axis.HomeParam.Acc, axis.HomeParam.Acc);
            LTSMC.smc_set_homemode(ConnectNo, axisId, (ushort)axis.HomeParam.Dir, axis.HomeParam.Vm, (ushort)axis.HomeParam.Mode, 1);

            ushort ezEnable = 0;
            ushort ezLogic = 0;
            ushort ezSource = 0;
            LTSMC.smc_set_ezlatch_mode(ConnectNo, axisId, axis.HomeParam.Eza ? (ushort)1 : (ushort)0, 0, 1);

            return 0;
        }

        public void SetConn_RunState(PrimConnState conn, PrimRunState run)
        {
            PrimConnStat = conn;
            PrimRunStat = run;
            ((PrimConfigControl)_primConfigUI).SetPrimConnState(conn);
            ((PrimConfigControl)_primConfigUI).SetPrimRunState(run);
            ((PrimDebugControl)_primDebugUI).SetPrimConnState(conn);
            ((PrimDebugControl)_primDebugUI).SetPrimRunState(run);
            ((PrimOutputControl)_primOutputUI).SetPrimConnState(conn);
            ((PrimOutputControl)_primOutputUI).SetPrimRunState(run);
        }

        public void SetConnState(PrimConnState conn)
        {
            PrimConnStat = conn;
            ((PrimConfigControl)_primConfigUI).SetPrimConnState(conn);
            ((PrimDebugControl)_primDebugUI).SetPrimConnState(conn);
            ((PrimOutputControl)_primOutputUI).SetPrimConnState(conn);
        }
        public void SetRunState(PrimRunState run)
        {
            PrimRunStat = run;
            ((PrimConfigControl)_primConfigUI).SetPrimRunState(run);
            ((PrimDebugControl)_primDebugUI).SetPrimRunState(run);
            ((PrimOutputControl)_primOutputUI).SetPrimRunState(run);
        }

        #endregion Others

        public int GetOdData(int slaveNo, int odIndex, ref uint value)
        {
            return LTSMC.nmcs_get_node_od(ConnectNo, 2, (ushort)slaveNo, (ushort)odIndex, 0, 32, ref value);
        }
        public int GetOdData(int slaveNo, int odIndex, int subIndex, int length, ref uint value)
        {
            return LTSMC.nmcs_get_node_od(ConnectNo, 2, (ushort)slaveNo, (ushort)odIndex, (ushort)subIndex, (ushort)length, ref value);
        }

        public int SetOdData(int slaveNo, int odIndex, uint value)
        {
            return LTSMC.nmcs_set_node_od(ConnectNo, 2, (ushort)slaveNo, (ushort)odIndex, 0, 32, value);
        }
        public int SetOdData(int slaveNo, int odIndex, int subIndex, int length, uint value)
        {
            return LTSMC.nmcs_set_node_od(ConnectNo, 2, (ushort)slaveNo, (ushort)odIndex, (ushort)subIndex, (ushort)length, value);
        }
       
        #region LCT's MINICMP

        #endregion
    }
}