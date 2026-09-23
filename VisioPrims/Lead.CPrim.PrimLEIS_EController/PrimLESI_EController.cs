using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.PrimLESI_EController
{
    /// <summary>雷赛控制器管理器</summary>
    public class PrimLESI_EController : IPrim, IMotionCard, IAxis, IIoModule, IInterpolation, ICmpTrig, IEtherCAT
    {
        #region Field
        /// <summary>EBusConfig管理器</summary>
        private EBusConfig _eBusConfig = null;


        /// <summary>轴使能状态数组</summary>
        bool[] _lastAxisIsEnable = new bool[128];
        /// <summary>辅助编码器计数值，单位：unit</summary>
        double _lastExtraPos = 0.0;
        /// <summary>编码器位置数组</summary>
        double[] _lastAxisPosition = new double[128];
        /// <summary>轴指令位置数组</summary>
        double[] _lastAxisCmdPos = new double[128];
        /// <summary>轴指令速度数组</summary>
        double[] _lastAxisCmdVel = new double[128];
        /// <summary>轴目标位置数组</summary>
        double[] _lastAxisTargetPosition = new double[128];


        /// <summary>扫描时间集合</summary>
        private List<double> _listScanTime = new List<double>();


        /// <summary>上升沿/下降沿地址集合</summary>
        private List<int> DiChangeAdr = new List<int>();
        /// <summary>下降沿地址集合</summary>
        private List<double> DiFallList = new List<double>();
        /// <summary>上升沿地址集合</summary>
        private List<double> DiRiseList = new List<double>();

        /// <summary>试错次数</summary>
        private int errCount = 3;


        private LESI_EConfig _config = null;
        private bool _cycleCycleReadIOFlag = false;
        private IOInfos _ioInfos = null;
        private Control _primConfigUI = null;
        private Control _primDebugUI = null;
        private Control _primOutputUI = null;

        private bool[] _servoHoming = new bool[64];
        private Task _taskCycleReadIO = null;

        private int[] _axisCheckStopCount = new int[64];
        private double[] _axisLastActualPosition = new double[64];
        private readonly object obj = new object();
        #endregion


        #region Ctor
        /// <summary>
        /// Ctor无参
        /// </summary>
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
        /// <summary>
        /// Ctor有一个参数
        /// </summary>
        /// <param name="xmlNode"></param>
        public PrimLESI_EController(XmlNode xmlNode)
        {
            if (IPrimImportConfigXml(xmlNode) != 0)
                return;

            _primDebugUI = new PrimDebugControl(this);
            _primConfigUI = new PrimConfigControl(this);
            _primOutputUI = new PrimOutputControl(this);

            SetConn_RunState(PrimConnState.Other, PrimRunState.Other);
        }
        #endregion


        #region Other
        /// <summary>IO数量更新</summary>
        internal void UpdateNodePortLength()
        {
            var nodesBCId = (from t in Nodes where t.NodeType == EcatNodeType.Coupler_B || t.NodeType == EcatNodeType.Coupler_C select t.NodeID).ToList();
            for (var i = 0; i < Nodes.Count; i++)
            {
                var node = Nodes[i];
                if (!nodesBCId.Contains(node.NodeID))
                {
                    if (node.NodeType == EcatNodeType.DI)
                    {
                        node.InputPort = new uint[node.InputCount / 32 + (node.InputCount % 32 > 0 ? 1 : 0)];
                        node.OutputPort = new uint[0];
                    }

                    if (node.NodeType == EcatNodeType.DO)
                    {
                        node.OutputPort = new uint[node.OutputCount / 32 + (node.OutputCount % 32 > 0 ? 1 : 0)];
                        node.InputPort = new uint[0];
                    }
                }
                else
                {
                    if (node.NodeType == EcatNodeType.Coupler_A || node.NodeType == EcatNodeType.Coupler_B || node.NodeType == EcatNodeType.Coupler_C)
                        continue;

                    var nodes = Nodes.Where(t => node.NodeID == t.NodeID).ToList();

                    var diCount = 0;
                    var doCount = 0;
                    for (var j = 0; j < nodes.Count; j++)
                    {
                        if (nodes[j].NodeType == EcatNodeType.DI)
                            diCount += nodes[j].InputCount;
                        if (nodes[j].NodeType == EcatNodeType.DO)
                            doCount += nodes[j].OutputCount;
                    }
                    node.InputPort = new uint[diCount / 32 + (diCount % 32 > 0 ? 1 : 0)];
                    node.OutputPort = new uint[doCount / 32 + (doCount % 32 > 0 ? 1 : 0)];
                }
            }
        }
        private void CycleReadIO()
        {
            UpdateNodePortLength();
            var dicDiModulePortNumInSlave = new Dictionary<int, int>();
            var dicDiModuleInSlave = new Dictionary<int, List<EDiModule>>();
            for (var i = 0; i < TotalSlaveNum; i++)
            {
                dicDiModulePortNumInSlave[i] = 0;
                var listDiModules = new List<EDiModule>();
                dicDiModuleInSlave[i + 1001] = listDiModules;

                if (DiModules.Count == 0)
                    continue;

                foreach (var diModule in DiModules.Values)
                {
                    if (diModule.SlaveNo != i + 1001) continue;
                    listDiModules.Add(diModule);
                }

                if (listDiModules.Count == 0)
                    continue;

                //将当前从站下的所有DI模块排序
                listDiModules.Sort((a, b) => a.Id.CompareTo(b.Id));

                var diChannels = 0; //Di通道总数
                listDiModules.ForEach(p => diChannels += p.Num);

                var portNum = diChannels / 32 + ((diChannels % 32) > 0 ? 1 : 0);    //读取的端口总数

                dicDiModulePortNumInSlave[i] = portNum;
            }

            var dicDoModuleInSlave = new Dictionary<int, List<EDoModule>>();
            for (var i = 0; i < TotalSlaveNum; i++)
            {
                var listDoModules = new List<EDoModule>();
                dicDoModuleInSlave[i + 1001] = listDoModules;

                if (DoModules.Count == 0)
                    continue;

                foreach (var DoModule in DoModules.Values)
                {
                    if (DoModule.SlaveNo != i + 1001)
                        continue;
                    listDoModules.Add(DoModule);
                }

                if (listDoModules.Count == 0)
                    continue;

                //将当前从站下的所有DI模块排序
                listDoModules.Sort((a, b) => a.Id.CompareTo(b.Id));

                var doChannels = 0; //Do通道总数
                listDoModules.ForEach(p => doChannels += p.Num);

                var portNum = doChannels / 32 + ((doChannels % 32) > 0 ? 1 : 0);    //读取的端口总数
            }

            var cycleCount = 0;
            var sw = new Stopwatch();
            while (_cycleCycleReadIOFlag)
            {
                try
                {
                    sw.Restart();
                    #region 总线状态监控
                    if (CheckEBusError)
                    {
                        ushort state = 0;
                        var iRet = LTSMC.nmcs_get_errcode(ConnectNo, 2, ref state);
                        if (iRet != 0 || state != 0)
                        {
                            Thread.Sleep(200);
                            if (CheckRunStat())
                            {
                                break;
                            }

                            WriteEtherCATStateInfo(iRet, GetLineNum(), $"nmcs_get_errcode，读取总线状态：{state}");
                            iRet = LTSMC.nmcs_clear_errcode(ConnectNo, 2);
                            if (iRet != 0)
                            {
                                WriteEtherCATStateInfo(iRet, GetLineNum(), $"nmcs_clear_errcode，清除总线错误");
                                IPrimTaskStop();
                                Thread.Sleep(500);
                                IPrimTaskInit();
                            }
                        }
                    }
                    #endregion 总线状态监控


                    #region IO相关参数获取
                    if (CycleScanEnable)
                    {
                        #region 读取板卡自带输入输出
                        DiModules[0].Value = LTSMC.smc_read_inport(ConnectNo, 0);
                        DoModules[0].Value = LTSMC.smc_read_outport(ConnectNo, 0);
                        #endregion


                        #region 按节点读取端口值
                        for (ushort i = 0; i < Nodes.Count; i++)
                        {
                            if (!Nodes[i].ScanEnable)
                                continue;

                            for (ushort j = 0; j < Nodes[i].InputPort.Length; j++)
                            {
                                uint ioValue = 0;
                                var cmdRet = LTSMC.nmcs_read_inport(ConnectNo, 2, Nodes[i].NodeID, j, ref ioValue);
                                if (cmdRet == 0)
                                    Nodes[i].InputPort[j] = ioValue;
                                else
                                    WriteErrInfo(cmdRet, GetLineNum(), "nmcs_read_inport-" + Nodes[i].NodeID);
                            }
                            for (ushort j = 0; j < Nodes[i].OutputPort.Length; j++)
                            {
                                uint ioValue = 0;
                                var cmdRet = LTSMC.nmcs_read_outport(ConnectNo, 2, Nodes[i].NodeID, j, ref ioValue);
                                if (cmdRet == 0)
                                    Nodes[i].OutputPort[j] = ioValue;
                                else
                                    WriteErrInfo(cmdRet, GetLineNum(), "nmcs_read_outport-" + Nodes[i].NodeID);
                            }
                        }
                        #endregion


                        #region 模块赋值
                        //DI模块赋值
                        for (ushort slaveNum = 0; slaveNum < TotalSlaveNum; slaveNum++)
                        {
                            var curNodeId = slaveNum + 1001;

                            if (dicDiModuleInSlave[curNodeId].Count == 0)
                            {
                                continue;
                            }

                            uint[] inPortValues = new uint[5];
                            for (ushort i = 0; i < Nodes.Count; i++)
                            {
                                if (Nodes[i].NodeID == curNodeId && Nodes[i].InputPort.Length > 0)
                                {
                                    inPortValues = Nodes[i].InputPort;
                                    break;
                                }
                            }

                            var curDiChannelNum = 0;
                            var curPortNum = 0;
                            foreach (var diModule in dicDiModuleInSlave[curNodeId])
                            {
                                uint curDiModuleValue = 0;

                                var curPortValue = inPortValues[curPortNum];
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
                                            var curDimoduleValue2 = inPortValues[curPortNum] & ((uint)Math.Pow(2, num3) - 1);
                                            curDiModuleValue = (curDimoduleValue2 << num2) | curDimoduleValue1;
                                        }
                                        else
                                        {
                                            curPortNum += 1;
                                            var curDimoduleValue2 = inPortValues[curPortNum] & ((uint)Math.Pow(2, 32) - 1);
                                            curPortNum += 1;
                                            var curDimoduleValue3 = inPortValues[curPortNum] & ((uint)Math.Pow(2, num3 - 32) - 1);
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
                                        var curDiModuleValue1 = curPortValue | (inPortValues[curPortNum] << (diModule.Num - 32));
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
                        //DO模块赋值
                        for (ushort slaveNum = 0; slaveNum < TotalSlaveNum; slaveNum++)
                        {
                            var curNodeId = slaveNum + 1001;

                            if (dicDoModuleInSlave[curNodeId].Count == 0)
                            {
                                continue;
                            }

                            uint[] outPortValues = new uint[5];
                            for (ushort i = 0; i < Nodes.Count; i++)
                            {
                                if (Nodes[i].NodeID == curNodeId && Nodes[i].OutputPort.Length > 0)
                                {
                                    outPortValues = Nodes[i].OutputPort;
                                    break;
                                }
                            }

                            var curDoChannelNum = 0;
                            var curPortNum = 0;
                            foreach (var doModule in dicDoModuleInSlave[curNodeId])
                            {
                                uint curDoModuleValue = 0;

                                var curPortValue = outPortValues[curPortNum];
                                var num1 = curDoChannelNum % 32;    //从0到上一个模块的通道总数，看其是否是32的倍数，如不是，则与当前模块共用一个32位的端口，例如16
                                if (num1 > 0)  //余16、8、24，且已读取过
                                {
                                    var num2 = 32 - num1;       //针对当前模块，读取当前端口获取的值能够分配的位数
                                    if (doModule.Num <= num2)   //当前模块的通道数不大于剩余未分配的通道值
                                    {
                                        curDoModuleValue = (curPortValue >> num1) & ((uint)Math.Pow(2, doModule.Num) - 1);
                                        if (doModule.Num == num2)
                                        {
                                            curPortNum += 1;
                                        }
                                    }
                                    else                        //当前模块的通道数大于剩余未分配的通道值
                                    {
                                        var num3 = doModule.Num - num2; //下一个端口中需要读取的通道数目
                                        var curDomoduleValue1 = (curPortValue >> num1) & ((uint)Math.Pow(2, num2) - 1);
                                        if (num3 <= 32)
                                        {
                                            curPortNum += 1;
                                            var curDomoduleValue2 = outPortValues[curPortNum] & ((uint)Math.Pow(2, num3) - 1);
                                            curDoModuleValue = (curDomoduleValue2 << num2) | curDomoduleValue1;
                                        }
                                        else
                                        {
                                            curPortNum += 1;
                                            var curDomoduleValue2 = outPortValues[curPortNum] & ((uint)Math.Pow(2, 32) - 1);
                                            curPortNum += 1;
                                            var curDomoduleValue3 = outPortValues[curPortNum] & ((uint)Math.Pow(2, num3 - 32) - 1);
                                            curDoModuleValue = (curDomoduleValue3 << (num3 - 32)) | (curDomoduleValue2 << 32) | curDomoduleValue1;
                                        }

                                    }
                                }
                                else            //余数为0，之前的模块与通道数正好可以整取
                                {
                                    if (doModule.Num <= 32)
                                    {
                                        curDoModuleValue = curPortValue & ((uint)Math.Pow(2, doModule.Num) - 1);
                                        if (doModule.Num == 32)
                                        {
                                            curPortNum += 1;
                                        }
                                    }
                                    else
                                    {
                                        curPortNum += 1;
                                        var curDoModuleValue1 = curPortValue | (outPortValues[curPortNum] << (doModule.Num - 32));
                                        if (doModule.Num == 64)
                                        {
                                            curPortNum += 1;
                                        }
                                    }
                                }
                                //CheckDiChange(doModule.Value, curDoModuleValue, DoModules.FirstOrDefault(p => p.Value == doModule).Key);
                                doModule.Value = curDoModuleValue;
                                curDoChannelNum += doModule.Num;
                            }
                        }
                        #endregion
                    }
                    #endregion IO相关参数获取


                    #region 轴参数获取
                    foreach (var axisK in Axises)
                    {
                        double value = -1;
                        var axis = axisK.Value;

                        var node = Nodes.FirstOrDefault(p => p.AxisId == axis.Id && p.NodeType == EcatNodeType.Axis);
                        if (node == null || !node.ScanEnable)
                        {
                            continue;
                        }

                        if (CycleScanEnable)
                        {
                            #region 轴Id=5000测试
                            if (axis.Id == 5000)
                            {
                                if (ExtraEncoderEnable)
                                {
                                    var encoderPos = 0;
                                    LTSMC.smc_get_extra_encoder(ConnectNo, 0, ref encoderPos);
                                    axis.ActualPos = encoderPos;
                                    axis.CmdPos = encoderPos;
                                    axis.ServoOn = true;
                                    //axis.CheckDone = true;
                                    axis.MotionIoStatus = 0;
                                }
                                continue;
                            }
                            #endregion


                            ushort axisStatemachine = 0;
                            var cmdRet = LTSMC.nmcs_get_axis_state_machine(ConnectNo, axis.Id, ref axisStatemachine);
                            if (cmdRet == 0)
                            {
                                axis.ServoOn = (axisStatemachine == 4);
                            }
                            else
                            {
                                WriteErrInfo(cmdRet, GetLineNum(), $"函数=【nmcs_get_axis_state_machine】，ConnectNo=【{ConnectNo}】，轴号=【{axis.Id}】");
                            }

                            cmdRet = LTSMC.smc_get_position_unit(ConnectNo, axis.Id, ref value);
                            if (cmdRet == 0)
                            {
                                axis.CmdPos = value;
                            }
                            else
                            {
                                WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_get_position_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axis.Id}】");
                            }

                            cmdRet = LTSMC.smc_get_encoder_unit(ConnectNo, axis.Id, ref value);
                            if (cmdRet == 0)
                            {
                                axis.ActualPos = value;
                            }
                            else
                            {
                                WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_get_encoder_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axis.Id}】");
                            }

                            cmdRet = LTSMC.smc_read_current_speed_unit(ConnectNo, axis.Id, ref value);
                            if (cmdRet == 0)
                            {
                                axis.CmdVel = value;
                                axis.ActualVel = value;
                            }
                            else
                            {
                                WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_read_current_speed_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axis.Id}】");
                            }

                            cmdRet = LTSMC.smc_get_target_position_unit(ConnectNo, axis.Id, ref value);
                            if (cmdRet == 0)
                            {
                                axis.TargetPos = value;
                            }
                            else
                            {
                                WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_get_target_position_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axis.Id}】");
                            }
                        }

                        axis.MotionIoStatus = LTSMC.smc_axis_io_status(ConnectNo, axis.Id);
                    }
                    #endregion


                    sw.Stop();
                    if (cycleCount++ < 10000)
                    {
                        _listScanTime.Add(sw.ElapsedMilliseconds);
                    }
                }
                catch (Exception ex)
                {
                    LogAdd($"CycleReadIO报错：{ex.Message}", LogLevel.Trace, 0);
                }

                if (CycleScanTime > 0)
                {
                    SpinWait.SpinUntil(() => false, CycleScanTime);
                }
                else
                {
                    SpinWait.SpinUntil(() => false, 5);
                }
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
        //判断某个位是不是 1
        private bool IsNBitOne(uint Num, int n)
        {
            var Result = false;
            //uint str = Convert.ToString(Num,2);
            var bit = (Num >> (n - 1)) & 1;
            Result = bit == 1;

            return Result;
        }
        #endregion



        #region Define_Event
        //public event PrimDataRefresh OnPrimDataRefresh;

        //public event PrimOpLog OnPrimOpLog;

        //public event PrimStateChanged OnPrimStateChanged;
        #endregion



        #region Prop
        /// <summary>指定链接号：0-254,默认值 0</summary>
        internal ushort ConnectNo { get => (ushort)DevIndex; }
        /// <summary>基元循环扫描使能</summary>
        public bool CycleScanEnable { get => _config.CycleScanEnable; set => _config.CycleScanEnable = value; }
        /// <summary>基元循环扫描时间</summary>
        public int CycleScanTime { get => _config.CycleScanTime; set => _config.CycleScanTime = value; }
        /// <summary>基元减速停止使能</summary>
        public bool DecStopEnable { set => _config.DecStopEnable = value; get => _config.DecStopEnable; }
        /// <summary>基元减速停止时间</summary>
        public double DecStopTime { set => _config.DecStopTime = value; get => _config.DecStopTime; }
        /// <summary>基元扫描总线错误</summary>
        public bool CheckEBusError { get => _config.CheckEBusError; set => _config.CheckEBusError = value; }
        /// <summary>基元IP地址</summary>
        internal string IpAddress { get => _config.IpAddress; set => _config.IpAddress = value; }
        /// <summary>基元辅助编码器使能</summary>
        public bool ExtraEncoderEnable { set => _config.ExtraEncoderEnable = value; get => _config.ExtraEncoderEnable; }
        /// <summary>基元辅助编码器输入方式</summary>
        public int ExtraEncoderInMode { set => _config.ExtraEncoderInMode = value; get => _config.ExtraEncoderInMode; }
        /// <summary>基元辅助编码器计数方式</summary>
        public int ExternEncoderMulti { set => _config.ExternEncoderMulti = value; get => _config.ExternEncoderMulti; }
        /// <summary>EBus Config Path</summary>
        public string EBusConfigFilePath { get => _config.EBusConfigFilePath; set => _config.EBusConfigFilePath = value; }
        /// <summary>支持在线变速</summary>
        public bool OnLineChangeSpeed { get => _config.OnLineChangeSpeed; set => _config.OnLineChangeSpeed = value; }


        public LogLevel PrimAlarmLv { get; set; }
        /// <summary>本地日志写入使能</summary>
        public bool LogEnable { get => _config.LogEnable; set => _config.LogEnable = value; }
        #endregion



        //****************************************************************************************************
        #region Override IPrim
        #region Prop
        public Guid Id { get => _config.Id; set => _config.Id = value; }
        public string Name
        {
            get
            {
                return _config.Name;
            }
            set
            {
                _config.Name = value;
            }
        }
        public bool PrimEnable { get => _config.PrimEnable; set => _config.PrimEnable = value; }
        public PrimType HSType { get => _config.HSType; set => _config.HSType = value; }
        public string PrimTypeName { get => _config.PrimTypeName; set => _config.PrimTypeName = value; }
        public Control PrimConfigUI { get => _primConfigUI; }
        public Control PrimOutputUI { get => _primOutputUI; }
        public PrimConnState PrimConnStat { get; set; }
        public PrimRunState PrimRunStat { get; set; }
        public PrimVer Ver { get => _config.Ver; set => _config.Ver = value; }
        public int CurrentImageIndex { get; set; }
        #endregion


        #region Method
        public int IPrimInit()
        {
            if (PrimConnStat == PrimConnState.Connected && PrimRunStat == PrimRunState.Running)
            {
                return 0;
            }

            ushort maxSlaveNum = 0;
            uint maxAxisesNum = 0;
            ushort state = 0;

            var iRet = LTSMC.smc_board_init(ConnectNo, 2, IpAddress, 0);
            if (iRet != 0)
            {
                LogAdd($"初始化运动控制器出错，出错代码：{iRet}", LogLevel.Warn);
                LTSMC.smc_board_close(ConnectNo);
                return iRet;
            }

            iRet = LTSMC.nmcs_get_errcode(ConnectNo, 2, ref state);
            if (iRet != 0 || state != 0)
            {
                LogAdd($"总线状态出错，出错代码：{iRet}，状态值：{state}", LogLevel.Warn);
                LTSMC.smc_board_close(ConnectNo);
                return iRet;
            }

            LTSMC.nmcs_get_total_slaves(ConnectNo, 2, ref maxSlaveNum);
            LTSMC.nmcs_get_total_axes(ConnectNo, ref maxAxisesNum);

            SetConn_RunState(PrimConnState.Connected, PrimRunState.Stop);
            return 0;
        }
        public int IPrimConnect(ref string result)
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

            UpdateAxisesAndModules();

            LTSMC.nmcs_set_slave_output_retain(ConnectNo, 2);

            foreach (var axis in Axises)
            {
                if (axis.Key != 5000)
                {
                    SetAxisParam(axis.Value);
                }
            }

            _cycleCycleReadIOFlag = true;
            if (_taskCycleReadIO == null  || _taskCycleReadIO.IsCanceled || _taskCycleReadIO.IsCompleted)
            {
                _taskCycleReadIO = new Task(CycleReadIO);
                _taskCycleReadIO.Start();
            }

            return 0;
        }
        public int IPrimStop()
        {
            if (PrimConnStat != PrimConnState.Connected)
            {
                LogAdd("停止时基元不处于连接状态", LogLevel.Trace, 0);
                return -1;
            }

            SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Other);

            var ret = LTSMC.smc_board_close(ConnectNo);
            if (ret < 0)
            {
                MessageBox.Show($@"关闭板卡失败，报错代码：{ret}");
                return -1;
            }

            var scanTimeFilePath = @"D:\CPrimlog\LEISI_EC\" + "扫描时间_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            if (_listScanTime.Count > 0)
            {
                using (StreamWriter sw = new StreamWriter(scanTimeFilePath, true, GlobalVariables.EncodingChinese))
                {
                    foreach (var scan in _listScanTime)
                    {
                        sw.WriteLine(scan);
                    }
                }
            }
            return 0;
        }
        public int IPrimDispose()
        {
            _cycleCycleReadIOFlag = false;
            if (_taskCycleReadIO != null)
            {
                try
                {
                    _taskCycleReadIO.Wait(5000);
                    Thread.Sleep(200);
                    _taskCycleReadIO?.Dispose();
                }
                catch
                {
                }
                finally
                {
                    _taskCycleReadIO = null;
                }
            }

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
                _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(LESI_EConfig)) as LESI_EConfig;
                ImportEBusConfig();
                ImportIoInfos();
            }
            else { return -1; }
            return iRet;
        }
        #endregion
        #endregion


        #region IPrim_Son
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
            LTSMC.nmcs_clear_errcode(ConnectNo, 2);

            SetRunState(PrimRunState.Running);

            return 0;
        }
        #endregion



        //****************************************************************************************************
        #region Override IMotionCard
        #region Prop
        public string ConfigFilePath { get => _config.ConfigFilePath; set => _config.ConfigFilePath = value; }
        public int DevIndex { get => _config.DevIndex; set => _config.DevIndex = value; }
        #endregion


        #region Method
        public void LoadConfigFile(string filePath)
        {
            return;
        }
        #endregion
        #endregion



        //****************************************************************************************************
        #region Override 接口【IAxis】
        #region Define_Method
        /// <summary>检查控制器运行状态</summary>
        /// <returns>true：非运行状态；false：运行状态</returns>
        private bool CheckRunStat()
        {
            return PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other;
        }
        /// <summary>编码器位置设置</summary>
        /// <param name="axisIdx">轴号</param>
        /// <param name="pos">位置</param>
        /// <returns>int</returns>
        private int SetAxisPosition(int axisIdx, double position)
        {
            var cmdRet = LTSMC.smc_set_encoder_unit(ConnectNo, (ushort)axisIdx, position);
            if (cmdRet != 0)
            {
                WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_set_encoder_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axisIdx}】");
            }
            return cmdRet;
        }
        /// <summary>指令位置设置</summary>
        /// <param name="axisIdx"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        private int SetAxisCommand(int axisIdx, double position)
        {
            var cmdRet = LTSMC.smc_set_position_unit(ConnectNo, (ushort)axisIdx, position);
            if (cmdRet != 0)
            {
                WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_set_position_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axisIdx}】");
            }
            return cmdRet;
        }
        #endregion


        #region State
        public bool AxisIsAlarm(int axisIdx)
        {
            if (CheckRunStat())
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 0)) != 0;
        }
        public bool AxisInPel(int axisIdx)
        {
            if (CheckRunStat())
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 1)) != 0;
        }
        public bool AxisInMel(int axisIdx)
        {
            if (CheckRunStat())
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 2)) != 0;
        }
        public bool AxisSignalEmg(int axisIdx)
        {
            if (CheckRunStat())
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 3)) != 0;
        }
        public bool AxisInOrigin(int axisIdx)
        {
            if (CheckRunStat())
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 4)) != 0;
        }
        public bool AxisInSPel(int axisIdx)
        {
            if (CheckRunStat())
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 6)) != 0;
        }
        public bool AxisInSMel(int axisIdx)
        {
            if (CheckRunStat())
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 7)) != 0;
        }
        public bool AxisSignalInp(int axisIdx)
        {
            if (CheckRunStat())
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 8)) != 0;
        }
        public bool AxisSignalEz(int axisIdx)
        {
            if (CheckRunStat())
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 9)) != 0;
        }
        public bool AxisSignalRdy(int axisIdx)
        {
            if (CheckRunStat())
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 10)) != 0;
        }
        public bool AxisSignalDStp(int axisIdx)
        {
            if (CheckRunStat())
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 11)) != 0;
        }
        public bool AxisSignalScl(int axisIdx)
        {
            if (CheckRunStat())
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 10)) != 0;
        }
        public bool AxisSignalOp(int axisIdx)
        {
            if (CheckRunStat())
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return (Axises[axisIdx].MotionIoStatus & (1 << 12)) != 0;
        }
        public bool AxisIsEnble(int axisIdx)
        {
            if (CheckRunStat())
            {
                return false;
            }

            if (axisIdx >= 5000)
                return true;

            //if (CycleScanEnable)
            //    return Axises[axisIdx].ServoOn;

            ushort axisStatemachine = 0;
            var cmdRet = LTSMC.nmcs_get_axis_state_machine(ConnectNo, (ushort)axisIdx, ref axisStatemachine);
            if (cmdRet == 0)
            {
                _lastAxisIsEnable[axisIdx] = (axisStatemachine == 4);
                return _lastAxisIsEnable[axisIdx];
            }

            WriteErrInfo(cmdRet, GetLineNum(), $"函数=【nmcs_get_axis_state_machine】，ConnectNo=【{ConnectNo}】，轴号=【{axisIdx}】");
            return _lastAxisIsEnable[axisIdx];
        }
        public bool AxisIsStop(int axisIdx)
        {
            if (CheckRunStat())
            {
                return false;
            }

            if (axisIdx >= 5000)
            {
                return false;
            }

            return LTSMC.smc_check_done(ConnectNo, (ushort)axisIdx) == 1;
        }
        public int AxisResetAlarm(int axisIdx)
        {
            if (CheckRunStat())
            {
                return -1;
            }

            LTSMC.nmcs_clear_errcode(ConnectNo, 2);
            var cmdRet = LTSMC.nmcs_clear_axis_errcode(ConnectNo, (ushort)axisIdx);
            if (cmdRet != 0)
            {
                LogAdd($"nmcs_clear_axis_errcode返回值 => {cmdRet}", LogLevel.Warn, 0);
                WriteErrInfo(cmdRet, GetLineNum(), $"函数=【nmcs_clear_axis_errcode】，ConnectNo=【{ConnectNo}】，轴号=【{axisIdx}】");
            }

            return cmdRet;
        }
        public int AxisStopMove(int axisIdx)
        {
            var cmdRet = -1;
            if (CheckRunStat())
            {
                return -1;
            }

            if (DecStopEnable)
            {
                cmdRet = LTSMC.smc_set_dec_stop_time(ConnectNo, (ushort)axisIdx, DecStopTime <= 0 ? 0.1 : DecStopTime);
                if (cmdRet != 0)
                {
                    cmdRet = LTSMC.smc_stop(ConnectNo, (ushort)axisIdx, DecStopEnable ? (ushort)0 : (ushort)1);
                    WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_set_dec_stop_time】，ConnectNo=【{ConnectNo}】，轴号=【{axisIdx}】");
                    return cmdRet;
                }
            }

            cmdRet = LTSMC.smc_stop(ConnectNo, (ushort)axisIdx, DecStopEnable ? (ushort)0 : (ushort)1);
            if (cmdRet == 0)
            {
                return 0;
            }

            WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_stop】，ConnectNo=【{ConnectNo}】，轴号=【{axisIdx}】");

            return cmdRet;
        }
        public int StopAllAxes()
        {
            var cmdRet = LTSMC.smc_emg_stop(ConnectNo);
            if (cmdRet == 0)
            {
                return 0;
            }

            WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_emg_stop】，ConnectNo=【{ConnectNo}】");

            return cmdRet;
        }
        public int GetAxisPosition(int axisIdx, ref double pos)
        {
            try
            {
                if (CheckRunStat())
                {
                    return -1;
                }

                var cmdRet = 0;
                if (axisIdx >= 5000)
                {
                    if (ExtraEncoderEnable)
                    {
                        var encoderPos = 0;
                        cmdRet = LTSMC.smc_get_extra_encoder(ConnectNo, 0, ref encoderPos);
                        if (cmdRet == 0)
                        {
                            _lastExtraPos = encoderPos;
                        }
                        else
                        {
                            WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_get_extra_encoder】，ConnectNo=【{ConnectNo}】，轴号=【{axisIdx}】");
                        }
                        pos = _lastExtraPos;
                        return 0;
                    }
                    pos = 0.0;
                    return 0;
                }

                if (CycleScanEnable)
                {
                    pos = Axises[axisIdx].ActualPos;
                    return 0;
                }

                double value = 0.0;
                lock (obj)
                {
                    cmdRet = LTSMC.smc_get_encoder_unit(ConnectNo, (ushort)axisIdx, ref value);
                }
                if (cmdRet == 0)
                {
                    _lastAxisPosition[axisIdx] = value;
                }
                else
                {
                    WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_get_encoder_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axisIdx}】");
                }
                pos = _lastAxisPosition[axisIdx];

                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int GetAxisActualVelocity(int axisIdx, ref double velocity)
        {
            if (CheckRunStat())
            {
                return -1;
            }

            if (axisIdx >= 5000)
            {
                velocity = 0;
                return 0;
            }

            if (CycleScanEnable)
            {
                velocity = Axises[axisIdx].CmdVel;
                return 0;
            }

            double value = 0.0;
            var cmdRet = LTSMC.smc_read_current_speed_unit(ConnectNo, (ushort)axisIdx, ref value);
            if (cmdRet == 0)
            {
                velocity = value;
            }
            else
            {
                WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_read_current_speed_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axisIdx}】");
            }
            return 0;
        }
        public int GetAxisCommand(int axisIdx, ref double command)
        {
            if (CheckRunStat())
            {
                return -1;
            }

            var cmdRet = 0;
            if (axisIdx == 5000)
            {
                if (ExtraEncoderEnable)
                {
                    var encoderPos = 0;
                    cmdRet = LTSMC.smc_get_extra_encoder(ConnectNo, 0, ref encoderPos);
                    if (cmdRet == 0)
                    {
                        _lastExtraPos = encoderPos;
                    }
                    else
                    {
                        WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_get_extra_encoder】，ConnectNo=【{ConnectNo}】，轴号=【{axisIdx}】");
                    }
                    command = _lastExtraPos;
                    return 0;
                }
                command = 0.0;
                return 0;
            }

            if (CycleScanEnable)
            {
                command = Axises[axisIdx].CmdPos;
                return 0;
            }

            double value = 0.0;
            cmdRet = LTSMC.smc_get_position_unit(ConnectNo, (ushort)axisIdx, ref value);
            if (cmdRet == 0)
            {
                _lastAxisCmdPos[axisIdx] = value;
            }
            else
            {
                WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_get_position_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axisIdx}】");
            }
            command = _lastAxisCmdPos[axisIdx];
            return 0;
        }
        public int GetAxisCommandVelocity(int axisIdx, ref double velocity)
        {
            if (CheckRunStat())
            {
                return -1;
            }

            if (axisIdx >= 5000)
            {
                velocity = 0;
                return 0;
            }

            if (CycleScanEnable)
            {
                velocity = Axises[axisIdx].CmdVel;
                return 0;
            }

            double value = 0.0;
            var cmdRet = LTSMC.smc_read_current_speed_unit(ConnectNo, (ushort)axisIdx, ref value);
            if (cmdRet == 0)
            {
                _lastAxisCmdVel[axisIdx] = value;
            }
            else
            {
                WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_read_current_speed_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axisIdx}】");
            }
            velocity = _lastAxisCmdVel[axisIdx];
            return 0;
        }
        public int GetAxisErrPosition(int axisIdx, ref double errPos)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
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
        public int GetAxisTargetPosition(int axisIdx, ref double targetPos)
        {
            if (CheckRunStat())
            {
                return -1;
            }

            if (axisIdx >= 5000)
            {
                targetPos = 0;
                return 0;
            }

            if (CycleScanEnable)
            {
                targetPos = Axises[axisIdx].TargetPos;
                return 0;
            }

            double value = 0.0;
            var cmdRet = LTSMC.smc_get_target_position_unit(ConnectNo, (ushort)axisIdx, ref value);
            if (cmdRet == 0)
            {
                _lastAxisTargetPosition[axisIdx] = value;
            }
            else
            {
                WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_get_target_position_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axisIdx}】");
            }
            targetPos = _lastAxisTargetPosition[axisIdx];
            return 0;
        }
        public int GetFeedbackPulse(int axisIdx, ref double position)
        {
            return GetAxisPosition(axisIdx, ref position);
        }
        public int SetAxisFeedbackPulseToCommand(int axisIdx)
        {
            if (CheckRunStat())
            {
                return -1;
            }

            if (!AxisIsStop(axisIdx))
            {
                AxisStopMove(axisIdx);
                Thread.Sleep(500);
            }

            double pos = 0;
            GetAxisPosition(axisIdx, ref pos);
            return SetAxisCommand(axisIdx, pos);
        }
        public int SetAxisPositionAndFeedbackPulse(int axisIdx, int position)
        {
            if (CheckRunStat())
            {
                return -1;
            }

            if (axisIdx >= 5000)
            {
                LTSMC.smc_set_extra_encoder(ConnectNo, 0, position);
                return 0;
            }

            SetAxisPosition(axisIdx, position);
            SetAxisCommand(axisIdx, position);

            return 0;
        }
        #endregion


        #region Move
        public int AxisAbsMove(int axisId, double dis, double maxVel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !AxisIsEnble(axisId))
            {
                return -1;
            }

            var distance = dis;
            var vel = maxVel;
            if (distance > int.MaxValue)
            {
                distance = int.MaxValue;
            }
            if (distance < int.MinValue)
            {
                distance = int.MinValue;
            }

            if (vel > int.MaxValue)
            {
                vel = int.MaxValue;
            }
            if (vel < int.MinValue)
            {
                vel = int.MinValue;
            }

            AxisSetMaxVel(axisId, vel);

            if(Axises[axisId].SInpEnable)
            {
                var setSInp = LTSMC.smc_set_sinp_param_unit(ConnectNo, (ushort)axisId, Axises[axisId].SInpEnable ? (ushort)1 : (ushort)0, Axises[axisId].SInpError, Axises[axisId].SInpTimes);
            }

            var cmdRet = 0;
            for (int i = 0; i < errCount; i++)
            {
                cmdRet = LTSMC.smc_pmove_unit(ConnectNo, (ushort)axisId, distance, 1);
                if (cmdRet == 4)
                {
                    WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_pmove_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axisId}】");
                    cmdRet = LTSMC.smc_update_target_position_unit(ConnectNo, (ushort)axisId, distance);
                    if (cmdRet != 0)
                    {
                        WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_update_target_position_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axisId}】");
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (cmdRet != 0)
                {
                    WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_pmove_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axisId}】");
                }
                else
                {
                    return 0;
                }
                Thread.Sleep(10);
            }

            return cmdRet;
        }
        public int AxisChangeVel(int axisId, double newVel)
        {
            return OnLineChangeSpeed ? LTSMC.smc_change_speed_unit(ConnectNo, (ushort)axisId, newVel, 0.3) : 0;
        }
        public int AxisRelMove(int axisId, double dis, double maxVel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !AxisIsEnble(axisId))
            {
                return -1;
            }

            var distance = dis;
            var vel = maxVel;

            if (distance > int.MaxValue)
            {
                distance = int.MaxValue;
            }
            if (distance < int.MinValue)
            {
                distance = int.MinValue;
            }

            if (vel > int.MaxValue)
            {
                vel = int.MaxValue;
            }
            if (vel < int.MinValue)
            {
                vel = int.MinValue;
            }

            AxisSetMaxVel(axisId, vel);

            var cmdRet = 0;
            for (int i = 0; i < errCount; i++)
            {
                cmdRet = LTSMC.smc_pmove_unit(ConnectNo, (ushort)axisId, distance, 0);
                if (cmdRet != 0)
                {
                    WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_pmove_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axisId}】");
                }
                else
                {
                    return 0;
                }
                Thread.Sleep(50);
            }

            return cmdRet;
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

            var cmdRet = LTSMC.smc_get_profile_unit(ConnectNo, (ushort)axisId, ref minVel, ref maxVel, ref oldTAcc, ref tDec, ref stopVel);
            if (cmdRet != 0)
            {
                WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_get_profile_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axisId}】");
                return (int)SoftWareAlarm.PrimLESI_EController_smc_get_profile_unit返回值不等于0;
            }

            cmdRet = LTSMC.smc_set_profile_unit(ConnectNo, (ushort)axisId, minVel, maxVel, acc, tDec, stopVel);
            if (cmdRet != 0)
            {
                WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_set_profile_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axisId}】");
                return (int)SoftWareAlarm.PrimLESI_EController_smc_set_profile_unit返回值不等于0;
            }

            return 0;
        }
        public int AxisSetAccDec(int axisId, double minVel, double maxVel, double tAcc, double tDec, double stopVel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            var cmdRet = LTSMC.smc_set_profile_unit(ConnectNo, (ushort)axisId, minVel, maxVel, tAcc,
                tDec, stopVel);
            if (cmdRet != 0)
            {
                WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_set_profile_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axisId}】");
                return (int)SoftWareAlarm.PrimLESI_EController_smc_set_profile_unit返回值不等于0;
            }

            return 0;
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

            var cmdRet = LTSMC.smc_set_s_profile(ConnectNo, (ushort)axisId, 0, stTime);
            if (cmdRet == 0)
            {
                return 0;
            }

            WriteErrInfo(cmdRet, GetLineNum(), "smc_set_s_profile");

            return cmdRet;
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

            var cmdRet = LTSMC.smc_get_profile_unit(ConnectNo, (ushort)axisId, ref minVel, ref maxVel, ref tAcc, ref oldTDec, ref stopVel);
            if (cmdRet != 0)
            {
                WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_get_profile_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axisId}】");
                return cmdRet;
            }

            cmdRet = LTSMC.smc_set_profile_unit(ConnectNo, (ushort)axisId, minVel, maxVel, tAcc, dec, stopVel);
            if (cmdRet != 0)
            {
                WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_set_profile_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axisId}】");
                return cmdRet;
            }

            return 0;
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
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other) return -1;

            var ret = 0;
            ushort errcode = 0;
            ret = LTSMC.nmcs_get_errcode(ConnectNo, 2, ref errcode);
            if (ret == 0 && errcode == 0)
            {
                ushort axis_statemachine = 0;
                var timeOutCount = 0;
                if (enable && !AxisIsEnble(axisId))
                {

                    LTSMC.nmcs_set_axis_enable(ConnectNo, (ushort)axisId);
                    Thread.Sleep(10);
                    LTSMC.nmcs_get_axis_state_machine(ConnectNo, (ushort)axisId, ref axis_statemachine);
                    while (axis_statemachine != 4)
                    {
                        LTSMC.nmcs_set_axis_enable(ConnectNo, (ushort)axisId);
                        if (timeOutCount++ > 5)
                            return -10;
                        Thread.Sleep(100 * timeOutCount);
                        LTSMC.nmcs_get_axis_state_machine(ConnectNo, (ushort)axisId, ref axis_statemachine);
                    }
                }
                else if (!enable && AxisIsEnble(axisId))
                {

                    LTSMC.nmcs_set_axis_disable(ConnectNo, (ushort)axisId);
                    Thread.Sleep(10);
                    LTSMC.nmcs_get_axis_state_machine(ConnectNo, (ushort)axisId, ref axis_statemachine);
                    while (axis_statemachine == 4)
                    {
                        LTSMC.nmcs_set_axis_disable(ConnectNo, (ushort)axisId);
                        if (timeOutCount++ > 5)
                            return -10;
                        Thread.Sleep(100 * timeOutCount);
                        LTSMC.nmcs_get_axis_state_machine(ConnectNo, (ushort)axisId, ref axis_statemachine);
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

            var cmdRet = LTSMC.smc_get_profile_unit(ConnectNo, (ushort)axisId, ref minVel, ref oldMaxVel, ref tAcc, ref tDec, ref stopVel);
            if (cmdRet != 0)
            {
                WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_get_profile_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axisId}】");
                return cmdRet;
            }

            cmdRet = LTSMC.smc_set_profile_unit(ConnectNo, (ushort)axisId, minVel, maxVel, tAcc, tDec, stopVel);
            if (cmdRet != 0)
            {
                WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_set_profile_unit】，ConnectNo=【{ConnectNo}】，轴号=【{axisId}】");
                return cmdRet;
            }

            return cmdRet;
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

            var cmdRet = LTSMC.smc_set_profile_unit(ConnectNo, (ushort)axisId, minVel, maxVel,
                tAcc, tDec, stopVel);
            if (cmdRet == 0)
            {
                return 0;
            }

            WriteErrInfo(cmdRet, GetLineNum(), "smc_set_profile_unit");

            return cmdRet;
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
                sPelEnable || sMelEnable ? (ushort)1 : (ushort)0, elSource, elAction, sMelValue, sPelValue);
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

            var minVel = 0.0;
            var maxVel = 0.0;
            var tAcc = 0.0;
            var tDec = 0.0;
            var oldStopVel = 0.0;
            LTSMC.smc_get_profile_unit(ConnectNo, (ushort)axisId, ref minVel, ref maxVel,
                ref tAcc, ref tDec, ref oldStopVel);

            var cmdRet = LTSMC.smc_set_profile_unit(ConnectNo, (ushort)axisId, minVel, maxVel,
                tAcc, tDec, stopVel);
            if (cmdRet == 0)
            {
                return 0;
            }

            WriteErrInfo(cmdRet, GetLineNum(), "smc_set_profile_unit");

            return cmdRet;
        }
        public int AxisVelMove(int axisId, double maxVel)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !AxisIsEnble(axisId))
            {
                return -1;
            }

            AxisSetMaxVel(axisId, Math.Abs(maxVel));

            var cmdRet = LTSMC.smc_vmove(ConnectNo, (ushort)axisId, maxVel >= 0 ? (ushort)1 : (ushort)0);
            if (cmdRet != 0)
            {
                WriteErrInfo(cmdRet, GetLineNum(), $"函数=【smc_vmove】，ConnectNo=【{ConnectNo}】，轴号=【{axisId}】");
                return (int)SoftWareAlarm.PrimLESI_EController_smc_vmove返回值不等于0;
            }

            return 0;
        }
        #endregion


        #region Home
        public int AxisHomeMove(int axisId)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || axisId < 0)
            {
                return -1;
            }
            var axis = Axises.FirstOrDefault(p => p.Value.Id == axisId);

            return AxisHomeMove(axisId, axis.Value.HomeParam.Mode, axis.Value.HomeParam.Vm, axis.Value.HomeParam.Vo,
                axis.Value.HomeParam.Acc, axis.Value.HomeParam.Shift, true);
        }
        public int AxisHomeMove(int axisId, bool asyncMode)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || axisId < 0)
            {
                return -1;
            }
            var axis = Axises.FirstOrDefault(p => p.Value.Id == axisId);

            return AxisHomeMove(axisId, axis.Value.HomeParam.Mode, axis.Value.HomeParam.Vm, axis.Value.HomeParam.Vo,
                axis.Value.HomeParam.Acc, axis.Value.HomeParam.Shift, asyncMode);
        }
        public int AxisHomeMove(int axisId, int homeMode, double vm, double vo, double acc, double shift, bool asyncMode, int posSource = 1)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || axisId == -1)
            {
                return -1;
            }

            var axis = Axises.FirstOrDefault(p => p.Value.Id == axisId);

            return Servo_home_move(axis.Value, homeMode, vm, vo, acc, shift, asyncMode, posSource);
        }
        public int AxisSetHomeMode(int axisId, int homeDir, int velMode, int homeMode, int posSource)
        {
            //VelMode:0-低速回零，1-高速回零
            return LTSMC.smc_set_homemode(ConnectNo, Convert.ToUInt16(axisId), Convert.ToUInt16(homeDir), velMode, Convert.ToUInt16(homeMode), (ushort)posSource);
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
        #endregion
        #endregion


        #region IAxis_Son
        /// <summary>轴回原点（仅回零，不判断到位）</summary>
        /// <param name="axis">轴配置</param>
        /// <param name="homeMode">回零模式</param>
        /// <param name="vm">回零高速</param>
        /// <param name="vo">回零低速</param>
        /// <param name="acc">回零加减速</param>
        /// <param name="shift">回零偏移</param>
        /// <param name="asyncMode">是否异步</param>
        /// <param name="posSource">pos_source（默认为1）</param>
        /// <returns></returns>
        private int Servo_home_move(EAxis axis, int homeMode, double vm, double vo, double acc, double shift, bool asyncMode, int posSource = 1)
        {
            _servoHoming[axis.Id] = true;

            LTSMC.smc_set_homemode(ConnectNo, axis.Id, 0, 0, (ushort)homeMode, (ushort)posSource);

            LTSMC.smc_set_home_profile_unit(ConnectNo, axis.Id, vo, vm, acc, 0);

            //ret = LTSMC.nmcs_set_home_profile(ConnectNo, 2, axis.Id, (ushort)homeMode, vm, vo, acc, acc, shift);

            //轴使能
            ushort errcode = 0;
            ushort axis_statemachine = 0;
            LTSMC.nmcs_get_errcode(ConnectNo, 2, ref errcode);
            if (errcode == 0)
            {
                LTSMC.nmcs_get_axis_state_machine(ConnectNo, axis.Id, ref axis_statemachine);
                for (int i = 0; i < errCount; i++)
                {
                    if (axis_statemachine != 4)
                    {
                        LTSMC.nmcs_set_axis_enable(ConnectNo, axis.Id);
                    }
                    else
                    {
                        break;
                    }
                    Thread.Sleep(200);
                    LTSMC.nmcs_get_axis_state_machine(ConnectNo, axis.Id, ref axis_statemachine);
                }
            }

            //开始回零
            var homeRet = LTSMC.smc_home_move(ConnectNo, axis.Id);

            Func<EAxis, int> a = WaitServoDone;
            //if (asyncMode)
            //{
            //    a.BeginInvoke(axis, null, null);
            //    return 0;
            //}
            //return a.Invoke(axis);

            return homeRet;
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



        //****************************************************************************************************
        #region Override IIoModule
        #region Event
        public event DIStateChanged OnDIStateChanged;
        public event DOStateChanged OnDOStateChanged;
        #endregion


        #region Prop
        public bool DIChangedEnable { get; set; }
        public bool DOChangedEnable { get; set; }
        /// <summary>IO管理器</summary>
        public IOInfos IoInfos { get => _ioInfos; set => _ioInfos = value; }
        /// <summary>IO Infos Path</summary>
        public string IOInfosFilePath { get => _config.IOInfosFilePath; set => _config.IOInfosFilePath = value; }
        #endregion


        #region Method
        public int ExportIoInfos()
        {
            var ret = false;
            if (!string.IsNullOrEmpty(IOInfosFilePath) && _ioInfos != null)
            {
                ret = JsonHelper.SerializeObjectToFile(_ioInfos, IOInfosFilePath);
            }
            return ret ? 0 : -1;
        }
        #endregion


        #region 数字量&&模拟量模块接口
        public int ReadAiModule(int startAddr, out double[] value)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                value = new double[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                return -1;
            }

            if (!CycleScanEnable)
            {
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
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                value = new double[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                return -1;
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

            if (!CycleScanEnable)
            {
                if (startAddr == 0)
                {
                    value = LTSMC.smc_read_inport(ConnectNo, 0);
                }
                else
                {
                    value = 0;
                }

                return 0;
            }
            if (!DiModules.ContainsKey(startAddr))
            {
                value = 0;
                return 0;
            }
            value = DiModules[startAddr].Value;
            return 0;
        }
        public int ReadDoModule(int startAddr, out uint value)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                value = 0;
                return -1;
            }
            if (!CycleScanEnable)
            {
                if (startAddr == 0)
                {
                    value = LTSMC.smc_read_outport(ConnectNo, 0);
                }
                else
                {
                    value = 0;
                }

                return 0;
                //Class_8338.SelfDefine_Get_8_Channel_Value(DevIndex, DoModules[startAddr].SlaveNo, (DoModules[startAddr].Id - (DoModules[startAddr].SlaveNo + 1) * 100) * 8, out var doModulesValue);
                //value = (int)doModulesValue;
            }
            if (!DoModules.ContainsKey(startAddr))
            {
                value = 0;
                return 0;
            }
            value = DoModules[startAddr].Value;
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
            var moduleId = (int)address;
            var index = (int)address % 100 + 1;
            if (!AiModules.Keys.Contains(moduleId))
            {
                val = -1;
                return -1;
            }

            var mode = type == EleAnalogType.Voltage ? 0 : 2;
            SetOdData((ushort)AiModules[moduleId].SlaveNo, 0x3008, (ushort)index, 8, (uint)mode);

            uint value1 = 0;
            float date = 0;
            int subindex = index == 1 ? 0x3002 : (index == 2 ? 0x3003 : (index == 3 ? 0x3004 : (index == 4 ? 0x3005 : 0)));

            if(GetOdData((ushort)AiModules[moduleId].SlaveNo, (ushort)subindex, 2, 32, ref value1) == 0)
            {
                //LTSMC.nmcs_get_node_od(ConnectNo, 2, (ushort)AiModules[moduleId].SlaveNo, (ushort)subindex, 2, 32, ref value1);
                byte[] a = BitConverter.GetBytes(value1); //数据类型转换
                date = BitConverter.ToSingle(a, 0);
                val = date;
                return 0;
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
        ConcurrentDictionary<double, bool> _dicDiValue = new ConcurrentDictionary<double, bool>();
        public int ReadSingleDInput(double address, out bool val)
        {
            var moduleId = (int)address;
            ushort index;
            if (moduleId != 0)
            {
                index = (ushort)Math.Round((address - moduleId) * 100);
            }
            else
            {
                index = (ushort)(address * 100);

            }

            if (CycleScanEnable)
            {
                if (ReadDiModule(moduleId, out var moduleValue) == 0)
                {
                    val = (moduleValue & (1 << index)) == 0;
                    return 0;
                }
                else
                {
                    val = false;
                    return -1;
                }
            }
            else
            {
                if (moduleId == 0)
                {
                    var inValue = LTSMC.smc_read_inbit(ConnectNo, index);
                    val = inValue == 0;
                    return 0;
                }

                if (!DiModules.ContainsKey(moduleId))
                {
                    val = false;
                    return -106;
                }

                //SMC读取方式
                //index += DiModules[moduleId].StartBitNum;
                //var inValue = LTSMC.smc_read_inbit(ConnectNo, index);
                //val = inValue == 0;
                //return 0;
                index += DiModules[moduleId].StartNodeBitNum;
                ushort ioValue = 0;
                var cmdRet = LTSMC.nmcs_read_inbit(ConnectNo, 2, DiModules[moduleId].SlaveNo, index, ref ioValue);
                if (cmdRet != 0)
                {
                    //return 0;
                    WriteErrInfo(cmdRet, GetLineNum(), "nmcs_read_inbit");
                }
                else
                {
                    _dicDiValue[address] = ioValue == 0;
                }
                //var writeCount = 0;
                //while (writeCount++ < 5)
                //{
                //    var cmdRet = LTSMC.nmcs_read_inbit(ConnectNo, 2, DiModules[moduleId].SlaveNo, index, ref ioValue);
                //    if (cmdRet != 0)
                //    {
                //        //return 0;
                //        WriteErrInfo(cmdRet, GetLineNum(), "nmcs_read_inbit");
                //    }
                //    else
                //    {
                //        _dicDiValue[address] = ioValue == 0;
                //    }
                //}
                val = _dicDiValue[address];
                return 0;
            }
        }
        ConcurrentDictionary<double, bool> _dicDoValue = new ConcurrentDictionary<double, bool>();
        public int ReadSingleDOutput(double address, out bool val)
        {
            var moduleId = (int)address;
            ushort index;
            if (moduleId != 0)
            {
                index = (ushort)Math.Round((address - moduleId) * 100);
            }
            else
            {
                index = (ushort)(address * 100);

            }
            if (CycleScanEnable)
            {
                if (ReadDoModule(moduleId, out var moduleValue) == 0)
                {
                    val = (moduleValue & (1 << index)) == 0;
                    return 0;
                }
                else
                {
                    val = false;
                    return -1;
                }
            }
            else
            {
                if (!DoModules.ContainsKey(moduleId))
                {
                    val = false;
                    return -106;
                }

                //SMC读取方式
                //index += DoModules[moduleId].StartBitNum;
                //var inValue = LTSMC.smc_read_outbit(ConnectNo, index);
                //val = inValue == 0;
                //return 0;
                if (moduleId == 0)
                {
                    var outValue = LTSMC.smc_read_outbit(ConnectNo, index);
                    val = outValue == 0;
                    return 0;
                }
                index += DoModules[moduleId].StartNodeBitNum;
                ushort ioValue = 0;
                var cmdRet = LTSMC.nmcs_read_outbit(ConnectNo, 2, DoModules[moduleId].SlaveNo, index, ref ioValue);
                if (cmdRet != 0)
                {
                    //return 0;
                    WriteErrInfo(cmdRet, GetLineNum(), "nmcs_read_outbit");
                }
                else
                {
                    _dicDoValue[address] = ioValue == 0;
                }
                //var writeCount = 0;
                //while (writeCount++ < 5)
                //{
                //    var cmdRet = LTSMC.nmcs_read_outbit(ConnectNo, 2, DoModules[moduleId].SlaveNo, index, ref ioValue);
                //    if (cmdRet != 0)
                //    {
                //        //return 0;
                //        WriteErrInfo(cmdRet, GetLineNum(), "nmcs_read_outbit");
                //    }
                //    else
                //    {
                //        _dicDoValue[address] = ioValue == 0;
                //    }
                //}
                val = _dicDoValue[address];
                return 0;
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

            var moduleId = (int)address;
            if (!DoModules.ContainsKey(moduleId))
            {
                return -106;
            }
            var doModule = DoModules[moduleId];
            int index;
            if (moduleId != 0)
            {
                index = (int)Math.Round((address - moduleId) * 100);

                var writeCount = 0;
                while (writeCount++ < 5)
                {
                    var cmdRet = LTSMC.nmcs_write_outbit(ConnectNo, 2, (ushort)doModule.SlaveNo, (ushort)(doModule.StartNodeBitNum + index), val ? (ushort)0 : (ushort)1);
                    
                    if (cmdRet != 0)
                    {
                        WriteErrInfo(cmdRet, GetLineNum(), "nmcs_write_outbit");
                    }

                    ushort outValue = 0;
                    LTSMC.nmcs_read_outbit(ConnectNo, 2, (ushort)doModule.SlaveNo, (ushort)(doModule.StartNodeBitNum + index), ref outValue);
                    if ((val && outValue == 0) || (!val && outValue == 1))  //写入成功
                    {
                        return 0;
                    }
                }
                return -20;
            }
            else
            {
                index = (int)(address * 100);
                return LTSMC.smc_write_outbit(ConnectNo, (ushort)index, val ? (ushort)0 : (ushort)1);
            }
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
        #endregion


        //****************************************************************************************************
        //****************************************************************************************************
        //****************************************************************************************************
        #region Override IInterpolation
        #region Method
        public int GetAxisMotionMulticoorStatus(short crd)
        {
            return LTSMC.smc_check_done_multicoor(ConnectNo, (ushort)crd);
        }
        public int GetInterpolationSta(int crd)
        {
            //0： 运动中， 1： 暂停中， 2： 正常停止， 3： 未启动， 4： 空闲， 5： 异常停止
            return LTSMC.smc_conti_get_run_state(ConnectNo, (ushort)crd);
        }
        public int InterpolationPause(int crd)
        {
            return LTSMC.smc_conti_pause_list(ConnectNo, (ushort)crd);
        }
        public int InterpolationStart(int crd)
        {
            return LTSMC.smc_conti_start_list(ConnectNo, (ushort)crd);
        }
        public int InterpolationOpen(int crd, int axisNum, ushort[] axisList)
        {
            LTSMC.smc_conti_open_list(ConnectNo, (ushort)crd, (ushort)axisNum, axisList);
            return 0;
        }
        public int InterpolationStop(int crd, int stopMode)
        {
            return LTSMC.smc_conti_stop_list(ConnectNo, (ushort)crd, (ushort)stopMode);
        }
        public int InterpolationMove(int crd, int axisNum, ushort[] axisArry, List<TrajPos> trajPos)
        {
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other)
            {
                return -1;
            }

            LTSMC.smc_conti_open_list(ConnectNo, (ushort)crd, (ushort)axisNum, axisArry);   //打开连续插补缓存区
            foreach (var item in trajPos)
            {
                if (!item.TrajEnable) continue;

                LTSMC.smc_set_vector_profile_unit(ConnectNo, (ushort)crd, 0, item.TrajVm, item.Tacc, item.Tdec, 0);
                LTSMC.smc_conti_line_unit(ConnectNo, (ushort)crd, (ushort)axisNum, axisArry, item.Pos, 1, 0);
            }
            LTSMC.smc_conti_start_list(ConnectNo, (ushort)crd);
            LTSMC.smc_conti_close_list(ConnectNo, (ushort)crd);
            return 0;
        }
        public int AddInterpolationDO_OnStopAhead(ushort Crd, ushort DoAdr, bool On_Off, ushort isTimemode, double delayCount1,
            double delayConut2)
        {
            int val = On_Off ? 0 : 1;
            return LTSMC.smc_conti_ahead_outbit_to_stop(ConnectNo, Crd, DoAdr, (ushort)val, delayCount1, isTimemode, delayConut2);
        }
        public int AddInterpolationDO_OnStopDelay(ushort Crd, ushort DoAdr, bool On_Off, double delayCount1, double delayConut2)
        {
            int val = On_Off ? 0 : 1;
            return LTSMC.smc_conti_delay_outbit_to_stop(ConnectNo, Crd, DoAdr, (ushort)val, delayCount1, delayConut2);
        }
        public int AddInterpolationDO_OnStartDelay(ushort Crd, ushort DoAdr, bool On_Off, ushort isTimemode, double delayCount1,
            double delayConut2)
        {
            int val = On_Off ? 0 : 1;
            return LTSMC.smc_conti_delay_outbit_to_start(ConnectNo, Crd, DoAdr, (ushort)val, delayCount1, isTimemode, delayConut2);
        }
        public int AddInterpolationDO(ushort Crd, ushort DoAdr, bool On_Off, double DelayTimeS)
        {
            int val = On_Off ? 0 : 1;
            return LTSMC.smc_conti_write_outbit(ConnectNo, Crd, DoAdr, (ushort)val, DelayTimeS);
        }
        public int AddInterpolationDelayS(ushort Crd, double DelayTimeS)
        {
            return LTSMC.smc_conti_delay(ConnectNo, Crd, DelayTimeS, 0);
        }
        public int AddInterpolationPoint(ushort Crd, ushort AxisNum, ushort[] AxisArry, TrajPos trajPos)
        {
            LTSMC.smc_set_vector_profile_unit(ConnectNo, Crd, 0, trajPos.TrajVm, trajPos.Tacc, trajPos.Tdec, 0);
            return LTSMC.smc_conti_line_unit(ConnectNo, Crd, AxisNum, AxisArry, trajPos.Pos, 1, 0);
        }
        public int AddInterpolatioWaitDI(ushort Crd, ushort DiAdr, bool On_Off, double TimeOutS = 0)
        {
            int val = On_Off ? 0 : 1;
            return LTSMC.smc_conti_wait_input(ConnectNo, Crd, DiAdr, (ushort)val, TimeOutS, 0);
        }
        #endregion
        #endregion


        //****************************************************************************************************
        //****************************************************************************************************
        //****************************************************************************************************
        #region Override ICmpTrig
        #region Method
        public int AddTrigPoint(int trigCh, int value)
        {
            return LTSMC.smc_hcmp_add_point_unit(ConnectNo, (ushort)trigCh, value);
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
        public int SetTriggerChannelMode(int channel, int mode)
        {
            if (channel < 0 || channel > 3 || mode < 0 || mode > 5) return -10;

            //cmp_mode: 0-禁止，1-等于，2-小于，3-大于，4-队列，5-线性
            //if (_cardTypes[DevIndex] == 0x5800 || _cardTypes[DevIndex] == 0x5600 || _cardTypes[DevIndex] == 0x5400 || _cardTypes[DevIndex] == 0x5C00)
            //    LTDMC.dmc_hcmp_fifo_set_mode((ushort)DevIndex, (ushort)channel, 1);

            return LTSMC.smc_hcmp_set_mode(ConnectNo, (ushort)channel, (ushort)mode);
        }
        public int SetTriggerConfig(int trigChannel, int axisId, int trigSource, int trigLogic, double widthTime)
        {
            if (axisId == 5000)
            {
                axisId = 0;
            }
            return LTSMC.smc_hcmp_set_config(ConnectNo, (ushort)trigChannel, (ushort)axisId,
                (ushort)trigSource, (ushort)trigLogic, (int)widthTime);
        }
        public int SetTriggerTable(int tCmpCh, double[] dataArr, int arrSize)
        {
            //if (_cardTypes[DevIndex] == 0x5800 || _cardTypes[DevIndex] == 0x5600 || _cardTypes[DevIndex] == 0x5400 || _cardTypes[DevIndex] == 0x5C00)
            //    return LTDMC.dmc_hcmp_fifo_add_table((ushort)DevIndex, (ushort)tCmpCh, (ushort)arrSize, dataArr);

            for (var i = 0; i < dataArr.Length; i++) AddTrigPoint(tCmpCh, (int)dataArr[i]);

            return 0;
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
        #endregion
        #endregion


        //****************************************************************************************************
        //****************************************************************************************************
        //****************************************************************************************************
        #region Override IEtherCAT
        /// <summary>获取从站对象字典参数值</summary>
        /// <param name="slaveNo">从站 EtherCAT 地址，第 i 个 EtherCAT 从站地址为 1000+i</param>
        /// <param name="odIndex">对象字典索引</param>
        /// <param name="subIndex">对象字典索引</param>
        /// <param name="length">对象字典索引长度(单位： bit)（该参数只有三个值： 8、 16 和 32）</param>
        /// <param name="value">对象字典索引参数值</param>
        /// <returns>0：OK；非0：错误代码</returns>
        public int GetOdData(int slaveNo, int odIndex, int subIndex, int length, ref uint value)
        {
            return LTSMC.nmcs_get_node_od(ConnectNo, 2, (ushort)slaveNo, (ushort)odIndex, (ushort)subIndex, (ushort)length, ref value);
        }
        /// <summary>设置从站对象字典参数值</summary>
        /// <param name="slaveNo">从站 EtherCAT 地址，第 i 个 EtherCAT 从站地址为 1000+i</param>
        /// <param name="odIndex">对象字典索引</param>
        /// <param name="subIndex">对象字典子索引</param>
        /// <param name="length">对象字典索引长度(单位： bit)（该参数只有三个值： 8、 16 和 32）</param>
        /// <param name="value">对象字典索引参数值</param>
        /// <returns>0：OK；非0：错误代码</returns>
        public int SetOdData(int slaveNo, int odIndex, int subIndex, int length, uint value)
        {
            return LTSMC.nmcs_set_node_od(ConnectNo, 2, (ushort)slaveNo, (ushort)odIndex, (ushort)subIndex, (ushort)length, value);
        }
        #endregion


        //****************************************************************************************************
        //****************************************************************************************************
        //****************************************************************************************************
        #region Override EBusConfig
        /// <summary>配置表数据集合</summary>
        public List<EcatNode> Nodes { get => _eBusConfig.Nodes; set => _eBusConfig.Nodes = value; }
        /// <summary>轴集合</summary>
        public ConcurrentDictionary<int, EAxis> Axises { get => _eBusConfig.Axises; set => _eBusConfig.Axises = value; }
        /// <summary>Ai模块集合</summary>
        public ConcurrentDictionary<int, EAiModule> AiModules { get; set; } = new ConcurrentDictionary<int, EAiModule>();
        /// <summary>Ao模块集合</summary>
        public ConcurrentDictionary<int, EAoModule> AoModules { get; set; } = new ConcurrentDictionary<int, EAoModule>();
        /// <summary>Di模块集合</summary>
        public ConcurrentDictionary<int, EDiModule> DiModules { get; set; } = new ConcurrentDictionary<int, EDiModule>();
        /// <summary>Do模块集合</summary>
        public ConcurrentDictionary<int, EDoModule> DoModules { get; set; } = new ConcurrentDictionary<int, EDoModule>();
        /// <summary>AI模块数量</summary>
        public int TotalAiModuleNum { get; set; }
        /// <summary>AO模块数量</summary>
        public int TotalAoModuleNum { get; set; }
        /// <summary>轴数</summary>
        public int TotalAxisNum { get => _eBusConfig.TotalAxisNum; set => _eBusConfig.TotalAxisNum = value; }
        /// <summary>DI模块数量</summary>
        public int TotalDiModuleNum { get; set; }
        /// <summary>DO模块数量</summary>
        public int TotalDoModuleNum { get; set; }
        /// <summary>从站数量</summary>
        public int TotalSlaveNum { get => _eBusConfig.TotalSlaveNum; set => _eBusConfig.TotalSlaveNum = value; }
        #endregion


        //****************************************************************************************************
        //****************************************************************************************************
        //****************************************************************************************************
        #region 文件存储与解析
        /// <summary>EBusConfig加载至内存</summary>
        public int ImportEBusConfig()
        {
            if (PrimRunStat == PrimRunState.Running)
                return 0;

            if (!string.IsNullOrEmpty(EBusConfigFilePath) && File.Exists(EBusConfigFilePath))
                _eBusConfig = JsonHelper.DeserializeJsonFileToObject<EBusConfig>(EBusConfigFilePath);

            if (_eBusConfig == null)
            {
                _eBusConfig = new EBusConfig();
                return -1;
            }
            return 0;
        }
        /// <summary>IoInfos加载至内存</summary>
        public int ImportIoInfos()
        {
            if (PrimRunStat == PrimRunState.Running)
                return 0;

            if (!string.IsNullOrEmpty(IOInfosFilePath) && File.Exists(IOInfosFilePath))
            {
                _ioInfos = JsonHelper.DeserializeJsonFileToObject<IOInfos>(IOInfosFilePath);
                if (_ioInfos == null) return -1;

                foreach (var di in _ioInfos.Di)
                {
                    if (di.EnRiseEvent | di.EnFallEvent)
                    {
                        //Floor:返回小于或等于指定双精度浮点数的最大整数
                        DiChangeAdr.Add((int)Math.Floor(di.Address));
                        if (di.EnRiseEvent)
                            DiRiseList.Add(di.Address);
                        if (di.EnFallEvent)
                            DiFallList.Add(di.Address);
                    }
                }
            }
            return _ioInfos != null ? 0 : -1;
        }
        #endregion


        //****************************************************************************************************
        //****************************************************************************************************
        //****************************************************************************************************
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

        public int AxisJogStart(int axisId, int statOn, int jogDir)
        {
            var ret = 0;
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Other || !AxisIsEnble(axisId)) return -1;

            try
            {
                if (statOn == 1)
                {
                    var cmdRet = LTSMC.smc_vmove(ConnectNo, (ushort)axisId, (ushort)jogDir);
                    if (cmdRet == 0)
                    {
                        return 0;
                    }

                    WriteErrInfo(cmdRet, GetLineNum(), "smc_vmove");

                    return cmdRet;
                }
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


        //****************************************************************************************************
        //****************************************************************************************************
        //****************************************************************************************************
        #region ConfigUI调用
        /// <summary>初始化连接（确定总轴数/总节点号/Nodes赋值）</summary>
        internal int FirstScanField()
        {
            LTSMC.smc_board_close(ConnectNo);
            Thread.Sleep(200);
            var ret = 0;
            ret = LTSMC.smc_board_init(ConnectNo, 2, IpAddress, 0);
            if (ret < 0)
            {
                MessageBox.Show($"初始化板卡出错，出错代码：{ret}");
                LTSMC.smc_board_close(ConnectNo);
                return -1;
            }

            ushort totalSlaveNum = 0;
            uint totalAxisesNum = 0;
            var listAxisesNodeId = new List<ushort>();
            ret = LTSMC.nmcs_get_total_slaves(ConnectNo, 2, ref totalSlaveNum);
            ret = LTSMC.nmcs_get_total_axes(ConnectNo, ref totalAxisesNum);
            if (ret == 0)
            {
                if (MessageBox.Show($"板卡初始化扫描成功，从站总数目：{TotalSlaveNum}，轴总个数：{TotalAxisNum}；\n选择“是”将会清除现有配置，选择“否”保留现有配置", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    LTSMC.smc_board_close(ConnectNo);
                    return -5;
                }

                TotalSlaveNum = totalSlaveNum;
                TotalAxisNum = (int)totalAxisesNum;

                if (Axises == null) Axises = new ConcurrentDictionary<int, EAxis>();
                Axises.Clear();
                ushort slaveAddr = 0;
                ushort subSlaveAddr = 0;

                for (ushort i = 0; i < totalAxisesNum; i++)
                {
                    LTSMC.nmcs_get_axis_node_address(ConnectNo, i, ref slaveAddr, ref subSlaveAddr);
                    Axises.TryAdd(i, new EAxis(slaveAddr, i));
                    listAxisesNodeId.Add(slaveAddr);
                }

                //清除模块配置
                Nodes.Clear();
                DiModules.Clear();
                DoModules.Clear();
                AiModules.Clear();
                AoModules.Clear();

                var startAxisId = 0;
                for (ushort i = 0; i < TotalSlaveNum; i++)
                {
                    var nodeId = (ushort)(i + 1001);
                    Nodes.Add(listAxisesNodeId.Contains(nodeId) ? new EcatNode(nodeId, EcatNodeType.Axis, Axises[startAxisId++].Id) : new EcatNode(nodeId, EcatNodeType.Other));
                }
            }
            else
            {
                MessageBox.Show($"初始化板卡出错，出错代码：{ret}");
                LTSMC.smc_board_close(ConnectNo);
                return -1;
            }
            return 0;
        }
        /// <summary>【DiModules\DoModules\AiModules\AoModules\Axises】集合更新</summary>
        internal void UpdateAxisesAndModules()
        {
            DiModules.Clear();
            DoModules.Clear();
            AiModules.Clear();
            AoModules.Clear();

            //节点总数计算
            var dicNodes = new Dictionary<ushort, int>();
            //要保存的轴
            var listAxises = new List<int>();

            if (Nodes.Count > 0)
            {
                //排序进行屏蔽
                //Nodes.Sort((a, b) => a.NodeID.CompareTo(b.NodeID));
                foreach (var node in Nodes)
                {
                    dicNodes[node.NodeID] = 1;

                    if (node.NodeType == EcatNodeType.Axis)
                    {
                        listAxises.Add(node.AxisId);
                        if (!Axises.ContainsKey(node.AxisId))
                        {
                            Axises.TryAdd(node.AxisId, new EAxis(node.NodeID, node.AxisId, node.AxisType));
                        }
                        else
                        {
                            Axises[node.AxisId].Id = node.AxisId;
                            Axises[node.AxisId].SlaveNo = node.NodeID;
                            Axises[node.AxisId].Type = node.AxisType;
                        }
                    }

                    if (node.NodeType == EcatNodeType.DI && node.InputCount > 0)
                        DiModules.TryAdd(node.InAddress, new EDiModule(node.NodeID, node.InAddress, node.InputCount, 0));

                    if (node.NodeType == EcatNodeType.DO && node.OutputCount > 0)
                        DoModules.TryAdd(node.OutAddress, new EDoModule(node.NodeID, node.OutAddress, node.OutputCount, 0));

                    if (node.NodeType == EcatNodeType.AI && node.InputCount > 0)
                        AiModules.TryAdd(node.InAddress, new EAiModule(node.NodeID, node.InAddress, "", node.InputCount, new double[node.InputCount]));

                    if (node.NodeType == EcatNodeType.AO && node.OutputCount > 0)
                        AoModules.TryAdd(node.OutAddress, new EAoModule(node.NodeID, node.OutAddress, "", node.OutputCount, new double[node.OutputCount]));
                }
            }

            if (Axises.Count > 0)
            {
                foreach (var axis in Axises.Keys.ToList())
                    if (!listAxises.Contains(axis)) Axises.TryRemove(axis, out var removed);
            }
            else
            {
                Axises.Clear();
            }

            TotalSlaveNum = dicNodes.Count;
            TotalAxisNum = Axises.Count;
            TotalDiModuleNum = DiModules.Count;
            TotalDoModuleNum = DoModules.Count;
            TotalAiModuleNum = AiModules.Count;
            TotalAoModuleNum = AoModules.Count;

            if (!Axises.ContainsKey(5000)) Axises.TryAdd(5000, new EAxis(0, 5000));

            DiModules.TryAdd(0, new EDiModule(0, 0, 12, 0));
            DoModules.TryAdd(0, new EDoModule(0, 0, 12, 0));

            //<节点号，起始地址>
            var dicDiModules = new Dictionary<ushort, ushort>();
            var listDiModules = DiModules.Values.ToList();
            listDiModules.Sort((a, b) => a.Id.CompareTo(b.Id));
            ushort startBitNum = 0;
            foreach (var diModule in listDiModules)
            {
                var nodeId = diModule.SlaveNo;
                diModule.StartBitNum = startBitNum;

                if (!dicDiModules.ContainsKey(nodeId)) dicDiModules[nodeId] = 0;
                diModule.StartNodeBitNum = dicDiModules[nodeId];
                dicDiModules[nodeId] += diModule.Num;

                startBitNum += diModule.Num;
            }

            var dicDoModules = new Dictionary<ushort, ushort>(); //<节点号，起始地址>
            var listDoModules = DoModules.Values.ToList();
            listDoModules.Sort((a, b) => a.Id.CompareTo(b.Id));
            startBitNum = 0;
            foreach (var doModule in listDoModules)
            {
                var nodeId = doModule.SlaveNo;
                doModule.StartBitNum = startBitNum;

                if (!dicDoModules.ContainsKey(nodeId)) dicDoModules[nodeId] = 0;
                doModule.StartNodeBitNum = dicDoModules[nodeId];
                dicDoModules[nodeId] += doModule.Num;

                startBitNum += doModule.Num;
            }

        }
        #endregion



        //****************************************************************************************************
        //****************************************************************************************************
        //****************************************************************************************************
        #region Others
        /// <summary>轴参数设置</summary>
        /// <param name="axis">周配置</param>
        /// <returns>int</returns>
        public int SetAxisParam(EAxis axis)
        {
            ushort axisId = axis.Id;

            LTSMC.smc_set_profile_unit(ConnectNo, axisId, axis.DefaultParam.Vs, axis.DefaultParam.Vm, axis.DefaultParam.Acc, axis.DefaultParam.Dec, axis.DefaultParam.Ve);

            LTSMC.smc_set_s_profile(ConnectNo, axisId, 0, axis.DefaultParam.Curve);

            LTSMC.smc_set_home_profile_unit(ConnectNo, axisId, axis.HomeParam.Vs, axis.HomeParam.Vm, axis.HomeParam.Acc, axis.HomeParam.Acc);

            LTSMC.smc_set_homemode(ConnectNo, axisId, (ushort)axis.HomeParam.Dir, axis.HomeParam.Vm, (ushort)axis.HomeParam.Mode, 1);

            LTSMC.smc_set_ezlatch_mode(ConnectNo, axisId, axis.HomeParam.Eza ? (ushort)1 : (ushort)0, 0, 1);

            LTSMC.smc_set_inp_mode(ConnectNo, axisId, axis.SInpEnable ? (ushort)0 : (ushort)1, 0);

            if (axis.SInpEnable)
            {
                var setSInp = LTSMC.smc_set_sinp_param_unit(ConnectNo, axisId, axis.SInpEnable ? (ushort)1 : (ushort)0, axis.SInpError, axis.SInpTimes);
            }
            //设定回零偏置
            var setOffset = LTSMC.nmcs_set_offset_pos(ConnectNo, axisId, 0);
            return 0;
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

        public int LoadAxisParam(int axisId, ref EAxis axis)
        {
            var axisParam = axis.DefaultParam;
            var homeParam = axis.HomeParam;

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
            LTSMC.smc_get_ezlatch_mode(ConnectNo, (ushort)axisId, ref ezEnable, ref ezLogic, ref ezSource);
            homeParam.Eza = ezEnable != 0;
            homeParam.Ez_Dir = ezLogic;

            ushort sInpEnable = 0;
            double sInpError = 0;
            double sInpTime = 0;
            LTSMC.smc_get_sinp_param_unit(ConnectNo, (ushort)axisId, ref sInpEnable, ref sInpError, ref sInpTime);
            axis.SInpEnable = sInpEnable == 1;
            axis.SInpError = sInpError;
            axis.SInpTimes = sInpTime;

            return 0;
        }

        public int GetLineNum()
        {
            StackTrace st = new StackTrace(1, true);
            return st.GetFrame(0).GetFileLineNumber();
        }
        /// <summary>连接状态&&运行状态设置</summary>
        /// <param name="conn">连接状态</param>
        /// <param name="run">运行状态</param>
        public void SetConn_RunState(PrimConnState conn, PrimRunState run)
        {
            SetConnState(conn);
            SetRunState(run);
        }
        /// <summary>连接状态设置</summary>
        /// <param name="conn">连接状态</param>
        public void SetConnState(PrimConnState conn)
        {
            PrimConnStat = conn;
            ((PrimConfigControl)_primConfigUI).SetPrimConnState(conn);
            ((PrimDebugControl)_primDebugUI).SetPrimConnState(conn);
            ((PrimOutputControl)_primOutputUI).SetPrimConnState(conn);
        }
        /// <summary>运行状态设置</summary>
        /// <param name="run">运行状态</param>
        public void SetRunState(PrimRunState run)
        {
            PrimRunStat = run;
            ((PrimConfigControl)_primConfigUI).SetPrimRunState(run);
            ((PrimDebugControl)_primDebugUI).SetPrimRunState(run);
            ((PrimOutputControl)_primOutputUI).SetPrimRunState(run);
        }
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

            string tempId = $"{(int)lv}{(int)PrimLogId.PrimLESI_EController}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            ProxyTools.LogHelper.LogAdd(lv, log, Name, LogClassification.VisioPrim, id);
        }
        /// <summary>【写入报错】添加错误信息</summary>
        /// <param name="cmdRet"></param>
        /// <param name="lineNum"></param>
        /// <param name="methodName"></param>
        private void WriteErrInfo(int cmdRet, int lineNum, string methodName)
        {
            try
            {
                string temp = $"{cmdRet};{lineNum};{methodName};{DateTime.Now.ToString("HH:mm:ss.fff")}";

                var errInfoFilePath = @"D:\CPrimlog\LEISI_EC\" + "写入报错_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

                var dirPath = Path.GetDirectoryName(errInfoFilePath);
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                using (StreamWriter sw = new StreamWriter(errInfoFilePath, true, GlobalVariables.EncodingChinese))
                {
                    sw.WriteLine(temp);
                }
            }
            catch (Exception ex)
            {
                LogAdd("WriteErrInfo出错：" + ex.Message, LogLevel.Trace, 0);
            }
        }
        /// <summary>【写入报错】添加错误信息</summary>
        /// <param name="cmdRet"></param>
        /// <param name="lineNum"></param>
        /// <param name="methodName"></param>
        private void WriteEtherCATStateInfo(int cmdRet, int lineNum, string methodName)
        {
            try
            {
                string temp = $"{cmdRet};{lineNum};{methodName};{DateTime.Now.ToString("HH:mm:ss.fff")}";

                var errStateFilePath = @"D:\CPrimlog\LEISI_EC\" + "总线状态报错_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

                var dirPath = Path.GetDirectoryName(errStateFilePath);
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                using (StreamWriter sw = new StreamWriter(errStateFilePath, true, GlobalVariables.EncodingChinese))
                {
                    sw.WriteLine(temp);
                }
            }
            catch (Exception ex)
            {
                LogAdd("WriteEtherCATStateInfo出错：" + ex.Message, LogLevel.Trace, 0);
            }
        }
        #endregion Others



        //****************************************************************************************************
        //****************************************************************************************************
        //****************************************************************************************************
        #region Other_NoUsing
        public Type ChildType { get => _config.ChildType; set => _config.ChildType = value; }
        public PrimManufacture Manu { get => _config.Manu; set => _config.Manu = value; }
        public bool PrimDebug { get => _config.PrimDebug; set => _config.PrimDebug = value; }
        public Control PrimDebugUI { get => _primDebugUI; }
        public RunMode PrimRunMode { get; set; }
        public bool PrimSimulator { get; set; }

        public int StartInterPolation(ushort Crd)
        {
            LTSMC.smc_conti_start_list(ConnectNo, Crd);
            return LTSMC.smc_conti_close_list(ConnectNo, Crd);
        }
        public bool DoubleEquals(double value1, double value2)
        {
            //双精度误差
            var DOUBLE_DELTA = 1E-6;
            return value1 == value2 || Math.Abs(value1 - value2) < DOUBLE_DELTA;
        }

        public int SetAxisBand(int axisIdx, uint band, uint time)
        {
            return 0;
        }

        /// <summary>当前驱动未实现轴 PT 运动，不能返回虚假的 FIFO 剩余空间。</summary>
        public short GetPTSpace(int axisId, short fifo = 0, short card = 0)
        {
            throw new NotSupportedException("Lead.CPrim.PrimLEIS_EController 尚未实现轴 PT 运动及 FIFO 空间查询。");
        }

        public int AxisPTMove(int axisId, List<PtData> ptdatas, short fifo = 0, short card = 0)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
