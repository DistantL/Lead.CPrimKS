/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: PrimFins.cs
 * Author: Victor
 * Description: 欧姆龙Fins通讯核心类，支持FinsNet及FinsUdp
 * CreateTime: 2022-09-21
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * FinsNet支持逐个读取（SHORT,INT,LONG,FLOAT,USHORT,UINT,ULONG,DOUBLE,BOOL,STRING）、逐个写入（SHORT,INT,LONG,FLOAT,USHORT,UINT,ULONG,DOUBLE,BOOL,STRING）以及批量读取（FLOAT,USHORT,STRING）
 * FinsUdp支持逐个读取（SHORT,INT,LONG,FLOAT,USHORT,UINT,ULONG,DOUBLE,BOOL,STRING）、逐个写入（SHORT,INT,LONG,FLOAT,USHORT,UINT,ULONG,DOUBLE,BOOL,STRING）
 * <3.3.22.0904><Victor><20220921>
 * 1、初版1.0
 * 
 * <3.3.22.1010><Victor><20221016>
 * 1、增加FinsNet批量读取功能，支持FLOAT,USHORT,STRING
 * 
 * <3.3.22.1010><Victor><20221017>
 * 1、FLOAT变量长度由2变更为4
 * 
 * <3.2.23.0315><Victor><20230328>
 * 1、见优化01
******************************************************************************/

using CommunicationBase;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Dev;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.PrimFinsNet
{
    /// <summary>基元管理类</summary>
    public class Prim : IPrim, IPlc
    {
        #region Field
        Config _config;

        /// <summary>连接成功标志</summary>
        bool _netConnetedSuccess;

        /// <summary>读取线程</summary>
        Task taskRead;

        /// <summary>读取线程取消标志</summary>
        CancellationTokenSource cts = new CancellationTokenSource();

        /// <summary>
        /// 时钟
        /// </summary>
        Stopwatch _sw = new Stopwatch();

        /// <summary>
        /// 循环时间
        /// </summary>
        int _cycleTime = 0;

        /// <summary>OmronFinsNet</summary>
        public IOmronFins _omronPlc;

        /// <summary>
        /// 连接状态
        /// </summary>
        PrimConnState _primConnStat;

        /// <summary>
        /// 运行状态
        /// </summary>
        PrimRunState _primRunStat;

        /// <summary>
        /// 测试数据保存
        /// </summary>
        string _pathTest = @"D:\Config\SaveConfig\test.csv";

        /// <summary>
        /// 测试数据
        /// </summary>
        List<int> _testDatas = new List<int>();

        /// <summary>
        /// true：所有参数进行初始化；false：不进行任何操作
        /// </summary>
        bool _variableInit = false;

        /// <summary>
        /// 读写锁
        /// </summary>
        static readonly object _readWrite = new object();
        #endregion



        #region Prop
        /// <summary>IP</summary>
        internal string IP
        {
            get => _config.IP;
            set
            {
                if (_config.IP == value)
                {
                    return;
                }
                LogAddAuthority($"IP > {_config.IP} > {value}", LogLevel.Trace);
                _config.IP = value;
            }
        }

        /// <summary>Port</summary>
        internal string Port
        {
            get => _config.Port;
            set
            {
                if (_config.Port == value)
                {
                    return;
                }
                LogAddAuthority($"Port > {_config.Port} > {value}", LogLevel.Trace);
                _config.Port = value;
            }
        }

        /// <summary>上位机的节点地址，假如你的电脑的Ip地址为192.168.0.13，那么这个值就是13</summary>
        internal string SA1
        {
            get => _config.SA1;
            set
            {
                if (_config.SA1 == value)
                {
                    return;
                }
                LogAddAuthority($"SA1 > {_config.SA1} > {value}", LogLevel.Trace);
                _config.SA1 = value;
            }
        }

        /// <summary>PLC的节点地址，这个值在配置了ip地址之后是默认赋值的，默认为Ip地址的最后一位</summary>
        internal string DA1
        {
            get => _config.DA1;
            set
            {
                if (_config.DA1 == value)
                {
                    return;
                }
                LogAddAuthority($"DA1 > {_config.DA1} > {value}", LogLevel.Trace);
                _config.DA1 = value;
            }
        }

        /// <summary>PLC的单元号地址，通常都为0</summary>
        internal string DA2
        {
            get => _config.DA2;
            set
            {
                if (_config.DA2 == value)
                {
                    return;
                }
                LogAddAuthority($"DA2 > {_config.DA2} > {value}", LogLevel.Trace);
                _config.DA2 = value;
            }
        }

        /// <summary>Fins类型</summary>
        internal FinsType FinsTypeSelect
        {
            get => _config.FinsTypeSelect;
            set
            {
                if (_config.FinsTypeSelect == value)
                {
                    return;
                }
                LogAddAuthority($"FinsTypeSelect > {_config.FinsTypeSelect} > {value}", LogLevel.Trace);
                _config.FinsTypeSelect = value;
            }
        }

        /// <summary>循环时间</summary>
        internal int CycleTime
        {
            get => _config.CycleTime;
            set
            {
                if (_config.CycleTime == value)
                {
                    return;
                }
                LogAddAuthority($"CycleTime > {_config.CycleTime} > {value}", LogLevel.Trace);
                _config.CycleTime = value;
            }
        }

        /// <summary>重连次数</summary>
        internal int ReconnectCnt
        {
            get => _config.ReconnectCnt;
            set
            {
                if (_config.ReconnectCnt == value)
                {
                    return;
                }
                LogAddAuthority($"ReconnectCnt > {_config.ReconnectCnt} > {value}", LogLevel.Trace);
                _config.ReconnectCnt = value;
            }
        }

        /// <summary>通知模式</summary>
        internal SktNotifyMode NotifyMode
        {
            get => _config.NotifyMode;
            set
            {
                if (_config.NotifyMode == value)
                {
                    return;
                }
                LogAddAuthority($"NotifyMode > {_config.NotifyMode} > {value}", LogLevel.Trace);
                _config.NotifyMode = value;
            }
        }

        /// <summary>日志启用</summary>
        internal bool LogEnable
        {
            get => _config.LogEnable;
            set
            {
                if (_config.LogEnable == value)
                {
                    return;
                }
                LogAddAuthority($"LogEnable > {_config.LogEnable} > {value}", LogLevel.Trace);
                _config.LogEnable = value;
            }
        }

        /// <summary>数据表地址</summary>
        internal string DataTablePath
        {
            get => _config.DataTablePath;
            set
            {
                if (_config.DataTablePath == value)
                {
                    return;
                }
                LogAddAuthority($"DataTablePath > {_config.DataTablePath} > {value}", LogLevel.Trace);
                _config.DataTablePath = value;
            }
        }

        /// <summary>读起始地址</summary>
        internal string ReadStartAddress
        {
            get => _config.ReadStartAddress;
            set
            {
                if (_config.ReadStartAddress != value)
                {
                    LogAddAuthority($"ReadStartAddress > {_config.ReadStartAddress} > {value}", LogLevel.Trace);
                    _config.ReadStartAddress = value;
                    ((PrimConfigControl)PrimConfigUI).SetReadStartAddress(value);
                }
            }
        }
        /// <summary>读长度</summary>
        internal ushort ReadLength
        {
            get => _config.ReadLength;
            set
            {
                if (_config.ReadLength != value)
                {
                    LogAddAuthority($"ReadLength > {_config.ReadLength} > {value}", LogLevel.Trace);
                    _config.ReadLength = value;
                    ((PrimConfigControl)PrimConfigUI).SetReadLength(value.ToString());
                }
            }
        }
        /// <summary>写起始地址</summary>
        internal string WriteStartAddress
        {
            get => _config.WriteStartAddress;
            set
            {
                if (_config.WriteStartAddress != value)
                {
                    LogAddAuthority($"WriteStartAddress > {_config.WriteStartAddress} > {value}", LogLevel.Trace);
                    _config.WriteStartAddress = value;
                    ((PrimConfigControl)PrimConfigUI).SetWriteStartAddress(value);
                }
            }
        }
        /// <summary>写长度</summary>
        internal ushort WriteLength
        {
            get => _config.WriteLength;
            set
            {
                if (_config.WriteLength != value)
                {
                    LogAddAuthority($"WriteLength > {_config.WriteLength} > {value}", LogLevel.Trace);
                    _config.WriteLength = value;
                    ((PrimConfigControl)PrimConfigUI).SetWriteLength(value.ToString());
                }
            }
        }

        /// <summary>数据表集合</summary>
        internal FinsDataConfigs DataConfigs { get; set; } = new FinsDataConfigs();

        /// <summary>硬件归属</summary>
        internal PrimManufacture Manu { set; get; } = PrimManufacture.Omron;

        internal LogLevel PrimAlarmLv { get; set; }

        internal RunMode PrimRunMode { get; set; }

        /// <summary>
        /// 测试中
        /// </summary>
        internal bool Testing { get; set; } = false;
        #endregion



        #region Ctor
        public Prim()
        {
            _config = new Config();
            DataConfigs = new FinsDataConfigs();

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
                throw new NullReferenceException();
            }

            DataConfigs = new FinsDataConfigs();
            if (!string.IsNullOrEmpty(_config.DataTablePath) && File.Exists(_config.DataTablePath))
            {
                ImportDataTable(_config.DataTablePath);
            }

            PrimDebugUI = new PrimDebugControl(this);
            PrimConfigUI = new PrimConfigControl(this);
            PrimOutputUI = new PrimOutputControl();

            PrimConnStat = PrimConnState.Other;
            PrimRunStat = PrimRunState.Other;

            ExportDll();
        }
        #endregion



        //*****************************************************************************
        #region Override IPrim
        public Guid Id { set => _config.Id = value; get => _config.Id; }
        public string Name
        {
            get => _config.Name;
            set
            {
                if (_config.Name == value)
                {
                    return;
                }
                LogAddAuthority($"Name > {_config.Name} > {value}", LogLevel.Trace);
                ((PrimConfigControl)PrimConfigUI).SetPrimName(value);
                _config.Name = value;
            }
        }
        public bool PrimEnable { set => _config.PrimEnable = value; get => _config.PrimEnable; }
        public PrimType HSType { set; get; } = PrimType.Protocol;
        public string PrimTypeName { set => _config.PrimTypeName = value; get => _config.PrimTypeName; }
        public Control PrimConfigUI { get; }
        public Control PrimDebugUI { get; }
        public Control PrimOutputUI { get; }
        public PrimConnState PrimConnStat
        {
            set
            {
                if (_primConnStat == value)
                {
                    return;
                }

                _primConnStat = value;
                ((PrimConfigControl)PrimConfigUI).SetPrimConnState(value);
            }
            get => _primConnStat;
        }
        public PrimRunState PrimRunStat
        {
            set
            {
                if (_primRunStat == value)
                {
                    return;
                }

                _primRunStat = value;
                ((PrimConfigControl)PrimConfigUI).SetPrimRunState(value);
            }
            get => _primRunStat;
        }

        public PrimVer Ver { set; get; } = PrimVer.Other;
        public int CurrentImageIndex { get => _config.CurrentImageIndex; set => _config.CurrentImageIndex = value; }


        public int IPrimInit()
        {
            try
            {
                if ((PrimRunStat == PrimRunState.Running || PrimRunStat == PrimRunState.Stop) && PrimConnStat == PrimConnState.Connected)
                {
                    return 0;
                }

                if (!IPAddress.TryParse(IP, out var address))
                {
                    throw new Exception("Ip：" + NLocalizer.GetString("ValueInvalid", "值无效"));
                }
                if (!int.TryParse(Port, out var port))
                {
                    throw new Exception("Port：" + NLocalizer.GetString("ValueInvalid", "值无效"));
                }
                if (!byte.TryParse(SA1, out var sa1))
                {
                    throw new Exception("SA1：" + NLocalizer.GetString("ValueInvalid", "值无效"));
                }
                if (!byte.TryParse(DA1, out var da1))
                {
                    throw new Exception("DA1：" + NLocalizer.GetString("ValueInvalid", "值无效"));
                }
                if (!byte.TryParse(DA2, out var da2))
                {
                    throw new Exception("DA2：" + NLocalizer.GetString("ValueInvalid", "值无效"));
                }

                if (FinsTypeSelect == FinsType.FinsUdp)
                {
                    _omronPlc = new FinsUdp(IP, port, sa1, da1, da2);
                }
                else if (FinsTypeSelect == FinsType.FinsNet)
                {
                    _omronPlc = new FinsNet(IP, port, sa1, da1, da2);
                }

                var reconnectCnt = 0;
                while (true)
                {
                    if (_omronPlc.Connect())
                    {
                        LogAdd($"{NLocalizer.GetString("ConnectSuccess", "连接成功")}", LogLevel.Info);
                        _netConnetedSuccess = true;
                        break;
                    }

                    if (++reconnectCnt > ReconnectCnt)
                    {
                        _netConnetedSuccess = false;
                        throw new Exception($"{NLocalizer.GetString("ConnectError", "连接失败")}");
                    }
                    else
                    {
                        LogAdd($"{NLocalizer.GetString("ConnectError", "连接失败")}", LogLevel.Warn);
                    }

                    Thread.Sleep(2000);
                }

                PrimConnStat = PrimConnState.Connected;
                PrimRunStat = PrimRunState.Stop;

                return 0;
            }
            catch (Exception ex)
            {
                LogAdd($"PrimFins_IPrimInit_Error：{ex.Message}", LogLevel.Warn);
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
                    throw new Exception($"{NLocalizer.GetString("NotConnect", "未连接")}");
                }

                if (taskRead == null && DataConfigs.ListDataConfig.IsValid())
                {
                    cts = new CancellationTokenSource();
                    Task.Factory.StartNew(() => CycleRead(cts.Token), TaskCreationOptions.LongRunning);
                }

                state = true;
            }
            catch (Exception ex)
            {
                LogAdd($"PrimFins_IPrimStart_Error：{ex.Message}", LogLevel.Warn);
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
                cts?.Cancel();
                taskRead?.Wait(600);
                taskRead = null;

                // 断开连接
                _omronPlc?.DisConnect();
                _omronPlc = null;

                state = true;
            }
            catch (Exception ex)
            {
                taskRead = null;
                _omronPlc = null;
                LogAdd($"PrimFins_IPrimStop_Error：{ex.Message}", LogLevel.Warn);
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
                LogAdd($"PrimFins_IPrimDispose_Error：{ex.Message}", LogLevel.Warn);
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
                return ret;
            }

            var connRet = "";
            if ((ret = IPrimConnect(ref connRet)) != 0)
            {
                return ret;
            }

            if ((ret = IPrimStart()) != 0)
            {
                return ret;
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

            if (_config != null && !_config.DataTablePath.IsNullOrEmpty() && File.Exists(_config.DataTablePath))
            {
                ImportDataTable(_config.DataTablePath);
            }

            return _config != null ? 0 : -1;
        }
        #endregion



        //*****************************************************************************
        #region Override IPlc
        public event Del_PlcVariableChanged OnPlcVariableChanged;
        public event Del_PlcVariableChanged OnPlcVariableChanged2;
        public event Del_PlcVariableChanged OnPlcVariableChanged3;

        public bool Conneted => _omronPlc != null && _netConnetedSuccess;

        public void ClearOnPlcVariableChanged()
        {
            if (OnPlcVariableChanged != null)
            {
                foreach (var d in OnPlcVariableChanged.GetInvocationList())
                {
                    OnPlcVariableChanged -= d as Del_PlcVariableChanged;
                }
            }
        }
        public void ClearOnPlcVariableChanged2()
        {
            if (OnPlcVariableChanged2 != null)
            {
                foreach (var d in OnPlcVariableChanged2.GetInvocationList())
                {
                    OnPlcVariableChanged2 -= d as Del_PlcVariableChanged;
                }
            }
        }
        public void ClearOnPlcVariableChanged3()
        {
            if (OnPlcVariableChanged3 != null)
            {
                foreach (var d in OnPlcVariableChanged3.GetInvocationList())
                {
                    OnPlcVariableChanged3 -= d as Del_PlcVariableChanged;
                }
            }
        }
        public void PlcVariableInit()
        {
            _variableInit = true;
        }
        public object ReadVariableFromAddr(string valAddr)
        {
            object obj = null;
            if (DataConfigs?.ListDataConfig == null || DataConfigs.ListDataConfig.Count <= 0)
            {
                return obj;
            }
            FinsDataConfig dataConfig = DataConfigs.ListDataConfig.FirstOrDefault(config => config.DtAddress == valAddr);
            if (dataConfig == null)
            {
                return obj;
            }
            return ReadSingleVariable(dataConfig);
        }
        public object ReadVariableFromAddr(string valAddr, ProtocolDataType valType, ushort length = 0)
        {
            object val = null;
            bool result;
            if (string.IsNullOrEmpty(valAddr))
            {
                return null;
            }

            switch (valType)
            {
                case ProtocolDataType.SHORT:
                    result = ReadResult(_omronPlc.ReadInt16(valAddr), out val);
                    break;

                case ProtocolDataType.INT:
                    result = ReadResult(_omronPlc.ReadInt32(valAddr), out val);
                    break;

                case ProtocolDataType.LONG:
                    result = ReadResult(_omronPlc.ReadInt64(valAddr), out val);
                    break;

                case ProtocolDataType.FLOAT:
                    result = ReadResult(_omronPlc.ReadFloat(valAddr), out val);
                    break;

                case ProtocolDataType.FLOATARRAY:
                    result = ReadResult(_omronPlc.ReadFloat(valAddr, length), out val);
                    break;

                case ProtocolDataType.USHORT:
                    result = ReadResult(_omronPlc.ReadUInt16(valAddr), out val);
                    break;

                case ProtocolDataType.UINT:
                    result = ReadResult(_omronPlc.ReadUInt32(valAddr), out val);
                    break;

                case ProtocolDataType.ULONG:
                    result = ReadResult(_omronPlc.ReadUInt64(valAddr), out val);
                    break;

                case ProtocolDataType.DOUBLE:
                    result = ReadResult(_omronPlc.ReadDouble(valAddr), out val);
                    break;

                case ProtocolDataType.BOOL:
                    result = ReadResult(_omronPlc.ReadBool(valAddr), out val);
                    break;

                case ProtocolDataType.STRING:
                    result = ReadResult(_omronPlc.ReadString(valAddr, length), out val);
                    break;

                default:
                    result = ReadResult(_omronPlc.ReadString(valAddr, length), out val);
                    break;
            }
            return val;
        }
        public object ReadVariableFromName(string valName)
        {
            object obj = null;
            if (DataConfigs?.ListDataConfig == null || DataConfigs.ListDataConfig.Count <= 0)
            {
                return obj;
            }
            FinsDataConfig dataConfig = DataConfigs.ListDataConfig.FirstOrDefault(config => config.DtName == valName);
            if (dataConfig == null)
            {
                return obj;
            }
            return ReadSingleVariable(dataConfig);
        }
        public int Write(string valName, object varValue)
        {
            bool result = false;
            try
            {
                if (valName.IsNullOrWhiteSpace())
                {
                    throw new ArgumentNullException("valName");
                }

                if (varValue == null)
                {
                    throw new ArgumentException("val");
                }

                FinsDataConfig dataConfig = DataConfigs.ListDataConfig.FirstOrDefault(config => config.DtName == valName);
                if (dataConfig == null)
                {
                    throw new Exception($"Name：{valName} {NLocalizer.GetString("NotExist", "不存在")}");
                }

                lock (_readWrite)
                {
                    result = Write(dataConfig, varValue);
                }
            }
            catch (Exception ex)
            {
                LogAdd($"PrimFins_Write_Error：{ex.Message}", LogLevel.Warn);
            }

            return result ? 0 : -1;
        }
        #endregion



        //*****************************************************************************
        #region Method_ExternalUsing
        /// <summary>加载本地Fins文件</summary>
        /// <param name="filePath">路径</param>
        /// <returns></returns>
        internal int ImportDataTable(string filePath)
        {
            var iRet = 0;
            if (DataConfigs == null)
            {
                DataConfigs = new FinsDataConfigs();
            }
            if (DataConfigs.ListDataConfig == null)
            {
                DataConfigs.ListDataConfig = new List<FinsDataConfig>();
            }
            DataConfigs.ListDataConfig.Clear();

            if (File.Exists(filePath))
            {
                DataConfigs = XmlSerializerHelper.ReadXML(filePath, typeof(FinsDataConfigs)) as FinsDataConfigs;
            }

            if (DataConfigs == null)
            {
                DataConfigs = new FinsDataConfigs();
            }
            return iRet;
        }

        /// <summary>保存本地Fins文件</summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        internal int ExportDataTable(string filePath)
        {
            return XmlSerializerHelper.WriteXML(DataConfigs, filePath, typeof(FinsDataConfigs)) ? 0 : -1;
        }

        /// <summary>日志</summary>
        /// <param name="msg">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示弹窗；false：不显示弹窗；</param>
        internal void LogAdd(string msg, LogLevel lv, long id = 0, bool isShowDialog = false)
        {
            if (!LogEnable && lv != LogLevel.Warn && lv != LogLevel.Error && lv != LogLevel.Fatal)
            {
                return;
            }

            msg = $"PrimFinsNet -> { Name} -> " + msg;
            string tempId = $"{(int)lv}{(int)PrimLogId.PrimFinsNet}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, Name, LogClassification.VisioPrim, id);

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

            LogHelper.LogAdd(lv, msg, PrimLogId.PrimFinsNet.ToString(), LogClassification.VisioPrim, 0L);
        }
        #endregion



        //*****************************************************************************
        #region Method_InternalUsing
        /// <summary>循环线程</summary>
        private void CycleRead(CancellationToken token)
        {
            OperateResult<byte[]> readRBuffer;
            OperateResult<byte[]> readWBuffer;
            int start = 0;
            int length = 0;
            object obj = null;
            bool init = false;

            // 阻塞等触发
            while (true)
            {
                try
                {
                    _sw.Restart();

                    if (token.IsCancellationRequested)
                    {
                        LogAdd($"{NLocalizer.GetString("ManualDisconnection", "手动断开连接")}", LogLevel.Info);
                        return;
                    }

                    if (PrimRunStat != PrimRunState.Running)
                    {
                        Thread.Sleep(10);
                        continue;
                    }

                    if (_variableInit && !init)
                    {
                        _variableInit = false;
                        init = true;
                    }
                    else
                    {
                        init = false;
                    }

                    readRBuffer = new OperateResult<byte[]>();
                    readWBuffer = new OperateResult<byte[]>();
                    start = 0;
                    length = 0;
                    obj = null;

                    //优化01
                    //读写
                    if (!ReadStartAddress.IsNullOrWhiteSpace() && !WriteStartAddress.IsNullOrWhiteSpace())
                    {
                        //Omron读写不支持异步，变更为同步
                        lock (_readWrite)
                        {
                            //Task<OperateResult<byte[]>> taskRead = Task.Run(() => _omronPlc.ReadRegister(ReadStartAddress, ReadLength));
                            //Task<OperateResult<byte[]>> taskWrite = Task.Run(() => _omronPlc.ReadRegister(WriteStartAddress, WriteLength));
                            //Task<OperateResult<byte[]>[]> task = Task.WhenAll(taskRead, taskWrite);
                            //readRBuffer = task.Result[0];
                            //readWBuffer = task.Result[1];
                            readRBuffer = _omronPlc.ReadRegister(ReadStartAddress, ReadLength);
                            readWBuffer = _omronPlc.ReadRegister(WriteStartAddress, WriteLength);
                        }
                    }
                    //只写
                    else if (ReadStartAddress.IsNullOrWhiteSpace() && !WriteStartAddress.IsNullOrWhiteSpace())
                    {
                        lock (_readWrite)
                        {
                            readWBuffer = _omronPlc.ReadRegister(WriteStartAddress, WriteLength);
                        }
                    }
                    //只读
                    else if (!ReadStartAddress.IsNullOrWhiteSpace() && WriteStartAddress.IsNullOrWhiteSpace())
                    {
                        lock (_readWrite)
                        {
                            readRBuffer = _omronPlc.ReadRegister(ReadStartAddress, ReadLength);
                        }
                    }
                    else
                    {
                        continue;
                    }

                    foreach (var config in DataConfigs.ListDataConfig)
                    {
                        if (config.DtRdMode != DataReadMode.Cycle)
                        {
                            continue;
                        }

                        if (config.DtPermission != DataPermission.R && config.DtPermission != DataPermission.RW)
                        {
                            continue;
                        }

                        if (config.DtPermission == DataPermission.R)
                        {
                            if (!CalLength(config.DtAddress, ReadStartAddress, ref start))
                            {
                                continue;
                            }
                        }
                        else
                        {
                            if (!CalLength(config.DtAddress, WriteStartAddress, ref start))
                            {
                                continue;
                            }
                        }

                        switch (config.DtType)
                        {
                            case ProtocolDataType.SHORT:
                                break;

                            case ProtocolDataType.INT:
                                break;

                            case ProtocolDataType.LONG:
                                break;

                            case ProtocolDataType.FLOAT:
                                length = 4;
                                break;

                            case ProtocolDataType.FLOATARRAY:
                                length = config.DtLength * 2;
                                break;

                            case ProtocolDataType.USHORT:
                                length = 2;
                                break;

                            case ProtocolDataType.UINT:
                                break;

                            case ProtocolDataType.ULONG:
                                break;

                            case ProtocolDataType.DOUBLE:
                                break;

                            case ProtocolDataType.BOOL:
                                break;

                            case ProtocolDataType.STRING:
                                length = config.DtLength * 2;
                                break;

                            case ProtocolDataType.OTHER:
                            default:
                                continue;
                        }
                        if (config.DtPermission == DataPermission.R)
                        {
                            obj = TransString(readRBuffer.Content, start, length, config.DtType, Encoding.ASCII);
                        }
                        else
                        {
                            obj = TransString(readWBuffer.Content, start, length, config.DtType, Encoding.ASCII);
                        }
                        if (obj == null)
                        {
                            continue;
                        }
                        string result = obj.ToString();
                        if (init || !result.Equals(config.DtCurrentValue))
                        {
                            config.DtLastValue = config.DtCurrentValue;
                            config.DtCurrentValue = result;
                            if (config.DtIsNotify)
                            {
                                OnPlcVariableChanged?.Invoke(config.DtName, config.DtAddress, config.DtType.ToString(), config.DtLastValue, config.DtCurrentValue);
                                OnPlcVariableChanged2?.Invoke(config.DtName, config.DtAddress, config.DtType.ToString(), config.DtLastValue, config.DtCurrentValue);
                                OnPlcVariableChanged3?.Invoke(config.DtName, config.DtAddress, config.DtType.ToString(), config.DtLastValue, config.DtCurrentValue);
                            }
                        }
                    }

                    _sw.Stop();
                    _cycleTime = (int)_sw.ElapsedMilliseconds;
                    if (Testing)
                    {
                        if (_testDatas.Count <= 1000)
                        {
                            _testDatas.Add(_cycleTime);
                        }
                        else
                        {
                            Testing = false;
                            Task.Run(() =>
                            {
                                CsvHelper.WriteStringToCsv(_pathTest, string.Join(",", _testDatas.ToArray()), true);
                                _testDatas.Clear();
                                LogAdd($"{NLocalizer.GetString("End", "结束")}", LogLevel.Trace);
                            });
                        }
                    }
                    if (_cycleTime < _config.CycleTime)
                    {
                        Thread.Sleep(_config.CycleTime - _cycleTime);
                    }
                    ((PrimConfigControl)PrimConfigUI).SetCycleTime(_cycleTime);
                }
                catch (Exception ex)
                {
                    ((PrimConfigControl)PrimConfigUI).SetError(ex.Message);
                }
            }
        }

        /// <summary>数据读取</summary>
        /// <param name="config"></param>
        private object ReadSingleVariable(FinsDataConfig config)
        {
            object obj = null;
            if (string.IsNullOrEmpty(config.DtName) || string.IsNullOrEmpty(config.DtAddress))
            {
                return obj;
            }

            try
            {
                obj = ReadVariableFromAddr(config.DtAddress, config.DtType, config.DtLength);
                if (config.DtType == ProtocolDataType.STRING)
                {
                    int len = obj.ToString().IndexOf('\0') == -1 ? obj.ToString().Length - 1 : obj.ToString().IndexOf('\0');
                    obj = obj.ToString().Substring(0, len);
                }
            }
            catch
            {
                return obj;
            }
            return obj;
        }

        /// <summary>读取结果判断</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="val">读取到的数据</param>
        /// <returns>true：读取成功；false：读取失败；</returns>
        private bool ReadResult<T>(OperateResult<T> result, out object val)
        {
            if (result.IsSuccess)
            {
                val = result.Content;
                return true;
            }
            else
            {
                val = null;
                return false;
            }
        }

        /// <summary>计算地址起始值</summary>
        /// <param name="currentAddress"></param>
        /// <param name="startAddress"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private bool CalLength(string currentAddress, string startAddress, ref int length)
        {
            int start;
            int end;
            if (!currentAddress.ToUpper().Contains("D") || !startAddress.ToUpper().Contains("D"))
            {
                return false;
            }
            if (!int.TryParse(currentAddress.Replace("D", ""), out end))
            {
                return false;
            }
            if (!int.TryParse(startAddress.Replace("D", ""), out start))
            {
                return false;
            }
            length = (end - start) * 2;
            return length >= 0;
        }

        /// <summary>
        /// 将buffer按照指定类型转换为值
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="type"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public string TransString(byte[] buffer, int index, int length, ProtocolDataType type, Encoding encoding = null)
        {
            byte[] array = new byte[length];
            Array.Copy(buffer, index, array, 0, length);
            switch (type)
            {
                case ProtocolDataType.SHORT:
                    return "";

                case ProtocolDataType.INT:
                    return "";

                case ProtocolDataType.LONG:
                    return "";

                case ProtocolDataType.FLOAT:
                    return _omronPlc.ReadFloat("", array).Content.ToString();

                case ProtocolDataType.FLOATARRAY:
                    return string.Join(",", _omronPlc.ReadFloat("", (ushort)(length / 4), array).Content);

                case ProtocolDataType.USHORT:
                    return _omronPlc.ReadUInt16("", array).Content.ToString();

                case ProtocolDataType.UINT:
                    return "";

                case ProtocolDataType.ULONG:
                    return "";

                case ProtocolDataType.DOUBLE:
                    return "";

                case ProtocolDataType.BOOL:
                    return "";

                case ProtocolDataType.STRING:
                default:
                    string ret = _omronPlc.ReadString("", 0, array).Content;
                    return ret.IndexOf('\0') != -1 ? ret.Substring(0, ret.IndexOf('\0')).Trim() : ret.Trim();
            }
        }

        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="config"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        private bool Write(FinsDataConfig config, object val)
        {
            var isSuccess = false;

            switch (config.DtType)
            {
                case ProtocolDataType.SHORT:
                    isSuccess = _omronPlc.WriteInt16(config.DtAddress, Int16.Parse(val.ToString())).IsSuccess;
                    break;

                case ProtocolDataType.INT:
                    isSuccess = _omronPlc.WriteInt32(config.DtAddress, Int32.Parse(val.ToString())).IsSuccess;
                    break;

                case ProtocolDataType.LONG:
                    isSuccess = _omronPlc.WriteInt64(config.DtAddress, Int64.Parse(val.ToString())).IsSuccess;
                    break;

                case ProtocolDataType.USHORT:
                    isSuccess = _omronPlc.WriteUInt16(config.DtAddress, UInt16.Parse(val.ToString())).IsSuccess;
                    break;

                case ProtocolDataType.UINT:
                    isSuccess = _omronPlc.WriteUInt32(config.DtAddress, UInt32.Parse(val.ToString())).IsSuccess;
                    break;

                case ProtocolDataType.ULONG:
                    isSuccess = _omronPlc.WriteUInt64(config.DtAddress, UInt64.Parse(val.ToString())).IsSuccess;
                    break;

                case ProtocolDataType.FLOAT:
                    isSuccess = _omronPlc.WriteFloat(config.DtAddress, float.Parse(val.ToString())).IsSuccess;
                    break;

                case ProtocolDataType.DOUBLE:
                    isSuccess = _omronPlc.WriteDouble(config.DtAddress, double.Parse(val.ToString())).IsSuccess;
                    break;

                case ProtocolDataType.BOOL:
                    isSuccess = _omronPlc.WriteBool(config.DtAddress, bool.Parse(val.ToString())).IsSuccess;
                    break;

                case ProtocolDataType.STRING:
                    string writeValue = val.ToString();
                    if (writeValue.Length > config.DtLength * 2)
                    {
                        writeValue = writeValue.Substring(0, config.DtLength * 2);
                    }
                    else
                    {
                        writeValue = writeValue.PadRight(config.DtLength * 2, '\0');
                    }
                    isSuccess = _omronPlc.WriteString(config.DtAddress, writeValue).IsSuccess;
                    break;
            }

            return isSuccess;
        }

        /// <summary>Test</summary>
        /// 
        private void test()
        {
            //// 读取操作，这里的D100可以替换成C100,A100,W100,H100效果时一样的
            //var D100_7 = _omronPlc.ReadBool("D100.7").Content; // 读取D100.7是否通断，注意D100.0等同于D100
            //var short_D100 = _omronPlc.ReadInt16("D100").Content; // 读取D100组成的字
            //var ushort_D100 = _omronPlc.ReadUInt16("D100").Content; // 读取D100组成的无符号的值
            //var int_D100 = _omronPlc.ReadInt32("D100").Content; // 读取D100-D101组成的有符号的数据
            //var uint_D100 = _omronPlc.ReadUInt32("D100").Content; // 读取D100-D101组成的无符号的值
            //var float_D100 = _omronPlc.ReadFloat("D100").Content; // 读取D100-D101组成的单精度值
            //var long_D100 = _omronPlc.ReadInt64("D100").Content; // 读取D100-D103组成的大数据值
            //var ulong_D100 = _omronPlc.ReadUInt64("D100").Content; // 读取D100-D103组成的无符号大数据
            //var double_D100 = _omronPlc.ReadDouble("D100").Content; // 读取D100-D103组成的双精度值
            //var str_D100 = _omronPlc.ReadString("D100", 5).Content; // 读取D100-D104组成的ASCII字符串数据

            //// 写入操作，这里的D100可以替换成C100,A100,W100,H100效果时一样的
            //_omronPlc.Write("D100", (byte)0x33); // 写单个字节
            //_omronPlc.Write("D100", (short)12345); // 写双字节有符号
            //_omronPlc.Write("D100", (ushort)45678); // 写双字节无符号
            //_omronPlc.Write("D100", 3456789123); // 写双字无符号
            //_omronPlc.Write("D100", 123.456f); // 写单精度
            //_omronPlc.Write("D100", 1234556434534545L); // 写大整数有符号
            //_omronPlc.Write("D100", 523434234234343UL); // 写大整数无符号
            //_omronPlc.Write("D100", 123.456d); // 写双精度
            //_omronPlc.Write("D100", "K123456789"); // 写ASCII字符串

            //var read = _omronPlc.Read("D100", 5);
            //{
            //    if (read.IsSuccess)
            //    {
            //        // 此处需要根据实际的情况来自定义来处理复杂的数据
            //        var D100 = _omronPlc.ByteTransform.TransInt16(read.Content, 0);
            //        var D101 = _omronPlc.ByteTransform.TransInt16(read.Content, 2);
            //        var D102 = _omronPlc.ByteTransform.TransInt16(read.Content, 4);
            //        var D103 = _omronPlc.ByteTransform.TransInt16(read.Content, 6);
            //        var D104 = _omronPlc.ByteTransform.TransInt16(read.Content, 7);
            //    }
            //}
        }

        /// <summary>
        /// 导出DLL
        /// </summary>
        private void ExportDll()
        {
            try
            {
                string dir = UIGlobal.DefinePath.Substring(0, UIGlobal.DefinePath.LastIndexOf("\\"));
                string pathDll = Path.Combine(dir, $"{Name}.dll");
                string pathCode = Path.Combine(dir, $"{Name}.cs");
                if (!File.Exists(pathDll))
                {
                    ((PrimConfigControl)PrimConfigUI).ExportDll(pathDll, pathCode, false);
                }
            }
            catch (Exception ex)
            {
                LogAdd($"ExportDll error：{ex.Message}\n{ex.InnerException}", LogLevel.Trace);
            }
        }
        #endregion
    }
}