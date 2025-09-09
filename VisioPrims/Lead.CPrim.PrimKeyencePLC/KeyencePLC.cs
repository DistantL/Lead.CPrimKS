using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
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
using Lead.CPrim.PrimKeyencePLC.CommonModule;
using Lead.CPrim.Interfaces.Dev;

namespace Lead.CPrim.PrimKeyencePLC
{
    /// <summary>基元管理类</summary>
    public class PrimKeyencePLC : IPrim, IKeyencePlc
    {
        #region Field
        /// <summary>KeyencePLC配置管理器</summary>
        public PrimKeyencePLCConfig _config;
        /// <summary>连接成功标志</summary>
        private bool _netConnetedSuccess;
        /// <summary>KeyenceProt</summary>
        public KeyenceProt m_KeyenceProt;
        /// <summary>数据表集合</summary>
        public PlcDataConfigs DataConfigs = new PlcDataConfigs();
        /// <summary>读取线程</summary>
        Task taskRead;
        /// <summary>读取线程取消标志</summary>
        CancellationTokenSource cts = new CancellationTokenSource();

        /// <summary>
        /// 时钟
        /// </summary>
        private Stopwatch _sw = new Stopwatch();

        /// <summary>
        /// 循环时间
        /// </summary>
        private int _cycleTime = 0;
        #endregion

        #region Ctor
        public PrimKeyencePLC()
        {
            _config = new PrimKeyencePLCConfig();

            HSType = PrimType.Protocol;
            DataConfigs = new PlcDataConfigs();

            PrimDebugUI = new PrimDebugControl();
            PrimConfigUI = new PrimConfigControl(this);
            PrimOutputUI = new PrimOutputControl();

            PrimConnStat = PrimConnState.Other;
            PrimRunStat = PrimRunState.Other;

            ((PrimConfigControl)PrimConfigUI).SetPrimConnState(PrimConnStat);
            ((PrimConfigControl)PrimConfigUI).SetPrimRunState(PrimRunStat);
        }
        public PrimKeyencePLC(XmlNode xmlNode)
        {
            if (xmlNode != null)
                _config = XMLHelper.XMLToObject(xmlNode, typeof(PrimKeyencePLCConfig)) as PrimKeyencePLCConfig;
            else
                return;

            HSType = PrimType.Protocol;
            DataConfigs = new PlcDataConfigs();

            if (!string.IsNullOrEmpty(_config.DataTablePath) && File.Exists(_config.DataTablePath))
            {
                ImportDataTable(_config.DataTablePath);
            }

            PrimConfigUI = new PrimConfigControl(this);
            PrimOutputUI = new PrimOutputControl();

            PrimConnStat = PrimConnState.Other;
            PrimRunStat = PrimRunState.Other;

            ((PrimConfigControl)PrimConfigUI).SetPrimConnState(PrimConnStat);
            ((PrimConfigControl)PrimConfigUI).SetPrimRunState(PrimRunStat);
        }
        #endregion

        #region Prop
        /// <summary>IP</summary>
        public string IP { get => _config.IP; set => _config.IP = value; }
        /// <summary>Port</summary>
        public string Port { get => _config.Port; set => _config.Port = value; }
        /// <summary>循环时间</summary>
        public int CycleTime { set => _config.CycleTime = value; get => _config.CycleTime; }
        /// <summary>重连次数</summary>
        public int ReconnectCnt { get => _config.ReconnectCnt; set => _config.ReconnectCnt = value; }
        /// <summary>数据表地址</summary>
        public string DataTablePath { set => _config.DataTablePath = value; get => _config.DataTablePath; }
        /// <summary>日志启用</summary>
        public bool LogEnable { get => _config.LogEnable; set => _config.LogEnable = value; }
        public LogLevel PrimAlarmLv { get; set; }
        public RunMode PrimRunMode { get; set; }
        #endregion

        //*****************************************************************************
        #region Override IPrim
        public Guid Id { set => _config.Id = value; get => _config.Id; }
        public string Name { set => _config.Name = value; get => _config.Name; }
        public bool PrimEnable { set => _config.PrimEnable = value; get => _config.PrimEnable; }
        public PrimType HSType { set => _config.HSType = value; get => _config.HSType; }
        public string PrimTypeName { set => _config.PrimTypeName = value; get => _config.PrimTypeName; }
        public Control PrimConfigUI { get; }
        public Control PrimDebugUI { get; }
        public Control PrimOutputUI { get; }
        public PrimConnState PrimConnStat
        {
            set
            {
                if (_config.PrimConnStat == value)
                {
                    return;
                }
                _config.PrimConnStat = value;
                ((PrimConfigControl)PrimConfigUI).SetPrimConnState(value);
            }
            get => _config.PrimConnStat;
        }
        public PrimRunState PrimRunStat
        {
            set
            {
                if (_config.PrimRunStat == value)
                {
                    return;
                }
                _config.PrimRunStat = value;
                ((PrimConfigControl)PrimConfigUI).SetPrimRunState(value);
            }
            get => _config.PrimRunStat;
        }
        public PrimVer Ver { set => _config.Ver = value; get => _config.Ver; }
        public int CurrentImageIndex { get => _config.CurrentImageIndex; set => _config.CurrentImageIndex = value; }
        public int IPrimInit()
        {
            try
            {
                var iRet = 0;
                if (PrimConnStat == PrimConnState.Connected)
                {
                    LogAdd("已经连接成功_无需进行二次连接", LogLevel.Info);
                    return 0;
                }

                if (!IPAddress.TryParse(IP, out var address))
                {
                    throw new Exception("IP格式有误");
                }
                if (!int.TryParse(Port, out var port))
                {
                    throw new Exception("端口格式有误");
                }
                m_KeyenceProt = new KeyenceProt(IP, port);
                var reconnectCnt = 0;
                while (true)
                {
                    if (m_KeyenceProt.IsConnected())
                    {
                        LogAdd("连接成功", LogLevel.Info);
                        _netConnetedSuccess = true;
                        break;
                    }

                    if (++reconnectCnt >= ReconnectCnt)
                    {
                        _netConnetedSuccess = false;
                        throw new Exception($"连续{ReconnectCnt}次连接失败");
                    }

                    Thread.Sleep(500);
                }


                PrimConnStat = PrimConnState.Connected;

                return iRet;
            }
            catch (Exception ex)
            {
                PrimConnStat = PrimConnState.UnConnected;
                LogAdd($"IPrimInit失败：{ex.Message}", LogLevel.Warn);
                return (int)SoftWareAlarm.PrimFinsNet_IPrimInit返回值不等于0;
            }
        }
        public int IPrimConnect(ref string result)
        {
            var iRet = 0;

            return iRet;
        }
        public int IPrimStart()
        {
            var iRet = 0;
            try
            {
                if (PrimConnStat != PrimConnState.Connected)
                {
                    throw new Exception("未连接_不能进行启动");
                }

                if (PrimRunStat == PrimRunState.Running)
                {
                    LogAdd("已经运行成功_无需进行二次运行", LogLevel.Info);
                    return 0;
                }

                cts = new CancellationTokenSource();
                taskRead = Task.Run(() => CycleRead(cts.Token));
                PrimRunStat = PrimRunState.Running;
                LogAdd("运行成功", LogLevel.Info);
            }
            catch (Exception ex)
            {
                PrimRunStat = PrimRunState.Stop;
                LogAdd($"IPrimStart失败：{ex.Message}", LogLevel.Warn);
                return (int)SoftWareAlarm.PrimFinsNet_IPrimStart返回值不等于0;
            }

            return iRet;
        }
        public int IPrimStop()
        {
            var iRet = 0;

            try
            {
                if (cts != null)
                {
                    cts.Cancel();
                }
                taskRead.Wait(500);
                taskRead = null;
            }
            catch (Exception ex)
            {
                LogAdd($"停止失败：{ex.Message}", LogLevel.Warn);
                taskRead = null;
            }
            // 断开连接
            m_KeyenceProt?.Close();
            m_KeyenceProt = null;

            PrimConnStat = PrimConnState.UnConnected;
            PrimRunStat = PrimRunState.Stop;
            return iRet;
        }
        public int IPrimDispose()
        {
            try
            {
                ((PrimDebugControl)PrimDebugUI).Dispose();
                ((PrimOutputControl)PrimOutputUI).Dispose();
                ((PrimConfigControl)PrimConfigUI).Dispose();

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
        public int IPrimTaskInit()
        {
            ClearOnPlcVariableChanged();
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
        public int IPrimTaskReset()
        {
            return 0;
        }
        public int IPrimTaskStop()
        {
            if (IPrimStop() != 0) return -1;
            return 0;
        }
        public XmlNode IPrimExportConfigXml()
        {
            if (_config == null) return null;

            var node = XMLHelper.ObjectToXML(_config);

            return node;
        }
        public int IPrimImportConfigXml(XmlNode xmlNode)
        {
            var iRet = 0;

            if (xmlNode == null)
            {
                return -1;
            }
            _config = XMLHelper.XMLToObject(xmlNode, typeof(PrimKeyencePLCConfig)) as PrimKeyencePLCConfig;

            if (!string.IsNullOrEmpty(_config.DataTablePath) && File.Exists(_config.DataTablePath))
            {
                ImportDataTable(_config.DataTablePath);
            }
            return iRet;
        }
        #endregion

        //*****************************************************************************
        #region Override IkeyencePlc
        public event Del_PlcVariableChanged OnPlcVariableChanged;

        public int ClearOnPlcVariableChanged()
        {
            if (OnPlcVariableChanged == null)
            {
                return 0;
            }

            foreach (var d in OnPlcVariableChanged.GetInvocationList())
            {
                OnPlcVariableChanged -= d as Del_PlcVariableChanged;
            }

            return 0;
        }
        public bool IsConnect => m_KeyenceProt != null && _netConnetedSuccess;

        public void Close()
        {
            m_KeyenceProt?.Close();
        }
        /// <summary>
        /// 从字中得到位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadBit(PLCBitSoftType type, uint Address, out bool data)
        {
            return m_KeyenceProt.ReadBit(type, Address, out data);
        }

        /// <summary>
        /// 从字中得到位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadBit(PLCBitSoftType type, uint Address, uint length, out bool[] data)
        {
            return m_KeyenceProt.ReadBit(type, Address, length, out data);
        }

        /// <summary>
        /// 获取Bool值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">Uint16值</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadBoolWord(PLCByteSoftType type, uint Address, out bool data)
        {
            PLCRespons result = m_KeyenceProt.ReadUInt16Word(type, Address, out var data1);
            data = (data1 & 1) == 1;
            return result;
        }
        /// <summary>
        /// 获取无符号16位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">Uint16值</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadUInt16Word(PLCByteSoftType type, uint Address, out UInt16 data)
        {
            return m_KeyenceProt.ReadUInt16Word(type, Address, out data);
        }

        /// <summary>
        /// 获取无符号16位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="length">值长度，也是地址长度</param>
        /// <param name="data">Uint16值</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadUInt16Word(PLCByteSoftType type, uint Address, uint length, out UInt16[] data)
        {
            return m_KeyenceProt.ReadUInt16Word(type, Address, length, out data);
        }

        /// <summary>
        /// 获取有符号16位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">int16值</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadInt16Word(PLCByteSoftType type, uint Address, out Int16 data)
        {
            return m_KeyenceProt.ReadInt16Word(type, Address, out data);
        }


        /// <summary>
        /// 获取有符号16位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="length">值长度，也是地址长度</param>
        /// <param name="data">int16值</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadInt16Word(PLCByteSoftType type, uint Address, uint length, out Int16[] data)
        {
            ushort[] uints;
            var result = m_KeyenceProt.ReadUInt16Word(type, Address, length, out uints);
            data = new Int16[uints.Length];
            Buffer.BlockCopy(uints, 0, data, 0, uints.Length * 2);
            return result;
        }


        /// <summary>
        /// 获取无符号32位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">Uint32值</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadUInt32Word(PLCByteSoftType type, uint Address, out UInt32 data)
        {
            return m_KeyenceProt.ReadUInt32Word(type, Address, out data);
        }


        /// <summary>
        /// 获取无符号32位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="length">值长度，不是地址长度</param>
        /// <param name="data">Uint32值</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadUInt32Word(PLCByteSoftType type, uint Address, uint length, out UInt32[] data)
        {
            return m_KeyenceProt.ReadUInt32Word(type, Address, length, out data);
        }


        /// <summary>
        /// 获取有符号32位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">int32值</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadInt32Word(PLCByteSoftType type, uint Address, out Int32 data)
        {
            return m_KeyenceProt.ReadInt32Word(type, Address, out data);
        }

        /// <summary>
        /// 获取有符号32位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="length">值长度，不是地址长度</param>
        /// <param name="data">int32值</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadInt32Word(PLCByteSoftType type, uint Address, uint length, out Int32[] data)
        {
            UInt32[] uints;
            var result = m_KeyenceProt.ReadUInt32Word(type, Address, length, out uints);
            data = new int[uints.Length];
            Buffer.BlockCopy(uints, 0, data, 0, uints.Length * 4);
            return result;
        }
        /// <summary>
        /// 获取无符号64位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">Uint32值</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadUInt64Word(PLCByteSoftType type, uint Address, out UInt64 data)
        {
            return m_KeyenceProt.ReadUInt64Word(type, Address, out data);
        }
        /// <summary>
        /// 获取无符号64位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="length">值长度，不是地址长度</param>
        /// <param name="data">Uint32值</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadUInt64Word(PLCByteSoftType type, uint Address, uint length, out UInt64[] data)
        {
            return m_KeyenceProt.ReadUInt64Word(type, Address, length, out data);
        }
        /// <summary>
        /// 获取有符号64位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">int32值</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadInt64Word(PLCByteSoftType type, uint Address, out Int64 data)
        {
            return m_KeyenceProt.ReadInt64Word(type, Address, out data);
        }
        /// <summary>
        /// 获取有符号64位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="length">值长度，不是地址长度</param>
        /// <param name="data">int32值</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadInt64Word(PLCByteSoftType type, uint Address, uint length, out Int64[] data)
        {
            return m_KeyenceProt.ReadInt64Word(type, Address, length, out data);
        }

        /// <summary>
        /// 获取float的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">Float值</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadFloatWord(PLCByteSoftType type, uint Address, out float data)
        {
            return m_KeyenceProt.ReadFloatWord(type, Address, out data);
        }

        /// <summary>
        /// 获取float的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="length">值长度，不是地址长度</param>
        /// <param name="data">Float值</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadFloatWord(PLCByteSoftType type, uint Address, uint length, out float[] data)
        {
            return m_KeyenceProt.ReadFloatWord(type, Address, length, out data);
        }
        /// <summary>
        /// 获取Double的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">Float值</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadDoubleWord(PLCByteSoftType type, uint Address, out Double data)
        {
            return m_KeyenceProt.ReadDoubleWord(type, Address, out data);
        }

        /// <summary>
        /// 获取Double的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="length">值长度，不是地址长度</param>
        /// <param name="data">Float值</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadDoubleWord(PLCByteSoftType type, uint Address, uint length, out Double[] data)
        {
            return m_KeyenceProt.ReadDoubleWord(type, Address, length, out data);
        }

        /// <summary>
        /// 获取string的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">Float值</param>
        /// <param name="length">字符串长度，不是地址长度</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadString(PLCByteSoftType type, uint Address, out string data, uint length = 2)
        {
            return m_KeyenceProt.ReadString(type, Address, out data, length);
        }
        /// <summary>
        /// 获取string的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="length">地址长度，不是字符串长度</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadAddrLengthString(PLCByteSoftType type, uint Address, out string data, uint length = 2)
        {
            return m_KeyenceProt.ReadAddrLengthString(type, Address, out data, length);
        }
        /// <summary>
        /// 获取中文字符的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">Float值</param>
        /// <param name="length">字符串长度，不是地址长度</param>
        /// <returns>响应码</returns>
        public PLCRespons ReadChineseString(PLCByteSoftType type, uint Address, out string data, uint length = 2)
        {
            return m_KeyenceProt.ReadString(type, Address, out data, length);
        }
        /// <summary>
        /// 写位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        public PLCRespons WriteBit(PLCBitSoftType type, uint Address, bool data)
        {
            return m_KeyenceProt.WriteBit(type, Address, data);
        }

        /// <summary>
        /// 写位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        public PLCRespons WriteBit(PLCBitSoftType type, uint Address, bool[] data)
        {
            return m_KeyenceProt.WriteBit(type, Address, data);
        }
        /// <summary>
        /// 写bool值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        public PLCRespons WritBoolWord(PLCByteSoftType type, uint Address, bool data)
        {
            ushort value = data ? (ushort)1 : (ushort)0;
            return m_KeyenceProt.WriteUInt16Word(type, Address, value);
        }

        /// <summary>
        /// 写无符号16位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        public PLCRespons WriteUInt16Word(PLCByteSoftType type, uint Address, UInt16 data)
        {
            return m_KeyenceProt.WriteUInt16Word(type, Address, data);
        }

        /// <summary>
        /// 写无符号16位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        public PLCRespons WriteUInt16Word(PLCByteSoftType type, uint Address, UInt16[] data)
        {
            return m_KeyenceProt.WriteUInt16Word(type, Address, data);
        }

        /// <summary>
        /// 写有符号16位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        public PLCRespons WriteInt16Word(PLCByteSoftType type, uint Address, Int16 data)
        {
            return m_KeyenceProt.WriteInt16Word(type, Address, data);
        }

        /// <summary>
        /// 写有符号16位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        public PLCRespons WriteInt16Word(PLCByteSoftType type, uint Address, Int16[] data)
        {
            return m_KeyenceProt.WriteInt16Word(type, Address, data);
        }

        /// <summary>
        /// 写无符号32位的值
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        public PLCRespons WriteUInt32Word(PLCByteSoftType type, uint Address, UInt32 data)
        {
            return m_KeyenceProt.WriteUInt32Word(type, Address, data);
        }

        /// <summary>
        /// 写无符号32位的值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        public PLCRespons WriteUInt32Word(PLCByteSoftType type, uint Address, UInt32[] data)
        {
            return m_KeyenceProt.WriteUInt32Word(type, Address, data);
        }

        /// <summary>
        /// 写有符号32位的值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        public PLCRespons WriteInt32Word(PLCByteSoftType type, uint Address, Int32 data)
        {
            return m_KeyenceProt.WriteInt32Word(type, Address, data);
        }

        /// <summary>
        /// 写有符号32位的值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        public PLCRespons WriteInt32Word(PLCByteSoftType type, uint Address, Int32[] data)
        {
            return m_KeyenceProt.WriteInt32Word(type, Address, data);
        }

        /// <summary>
        /// 写无符号64位的值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        public PLCRespons WriteUInt64Word(PLCByteSoftType type, uint Address, UInt64 data)
        {
            return m_KeyenceProt.WriteUInt64Word(type, Address, data);
        }

        /// <summary>
        /// 写无符号64位的值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        public PLCRespons WriteUInt64Word(PLCByteSoftType type, uint Address, UInt64[] data)
        {
            return m_KeyenceProt.WriteUInt64Word(type, Address, data);
        }
        /// <summary>
        /// 写有符号64位的值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        public PLCRespons WriteInt64Word(PLCByteSoftType type, uint Address, Int64 data)
        {
            return m_KeyenceProt.WriteInt64Word(type, Address, data);
        }

        /// <summary>
        /// 写有符号64位的值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        public PLCRespons WriteInt64Word(PLCByteSoftType type, uint Address, Int64[] data)
        {
            return m_KeyenceProt.WriteInt64Word(type, Address, data);
        }

        /// <summary>
        /// 写字符串的值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>字符串</returns>
        public PLCRespons WriteString(PLCByteSoftType type, uint Address, string data)
        {
            return m_KeyenceProt.WriteString(type, Address, data);
        }

        /// <summary>
        /// 写字符串的值-指定地址长度
        /// </summary>
        /// <param name="type"></param>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <param name="length">地址长度，不是字符串长度</param>
        /// <returns>字符串</returns>
        public PLCRespons WriteAddrLengthString(PLCByteSoftType type, uint Address, string data, uint length)
        {
            return m_KeyenceProt.WriteAddrLengthString(type, Address, data, length);
        }

        /// <summary>
        /// 写Float的值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        public PLCRespons WriteFloatWord(PLCByteSoftType type, uint Address, float data)
        {
            return m_KeyenceProt.WriteFloatWord(type, Address, data);
        }

        /// <summary>
        /// 写Float的值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        public PLCRespons WriteFloatWord(PLCByteSoftType type, uint Address, float[] data)
        {
            return m_KeyenceProt.WriteFloatWord(type, Address, data);
        }
        /// <summary>
        /// 写Double的值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        public PLCRespons WriteDoubleWord(PLCByteSoftType type, uint Address, Double data)
        {
            return m_KeyenceProt.WriteDoubleWord(type, Address, data);
        }

        /// <summary>
        /// 写Double的值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="Address">地址</param>
        /// <param name="data">值</param>
        /// <returns>响应码</returns>
        public PLCRespons WriteDoubleWord(PLCByteSoftType type, uint Address, Double[] data)
        {
            return m_KeyenceProt.WriteDoubleWord(type, Address, data);
        }
        public PLCRespons WriteChineseString(PLCByteSoftType type, uint Address, string data, bool IsReverseAlarm = false)
        {

            try
            {
                var writeUshort = ChineseToUshort.GetUshorts(data, 200, IsReverseAlarm);

                UInt16[] testsdata = new UInt16[100];
                Buffer.BlockCopy(writeUshort, 0, testsdata, 0, 200);
                PLCRespons respons = m_KeyenceProt.WriteUInt16Word(type, Address, testsdata);
                if (respons != PLCRespons.OK)
                {
                    return respons;
                }

                Buffer.BlockCopy(writeUshort, 100, testsdata, 0, 200);
                respons = m_KeyenceProt.WriteUInt16Word(type, Address + 100, testsdata);
                if (respons != PLCRespons.OK)
                {
                    return respons;
                }
                return PLCRespons.OK;
            }
            catch (Exception ex)
            {
                return PLCRespons.ERROR;
            }
        }

        public object ReadVariableFromName(string valName)
        {
            object obj = null;
            if (DataConfigs?.ListDataConfig == null || DataConfigs.ListDataConfig.Count <= 0)
            {
                return obj;
            }
            PlcDataConfig dataConfig = DataConfigs.ListDataConfig.FirstOrDefault(config => config.DtName == valName);
            if (dataConfig == null)
            {
                return obj;
            }
            return ReadSingleVariable(dataConfig);
        }
        public int WriteVariableFromName(string valName, object val)
        {
            var ret = -1;

            if (string.IsNullOrEmpty(valName))
            {
                LogAdd("名称为空", LogLevel.Warn);
                return -1;
            }

            PlcDataConfig dataConfig = DataConfigs.ListDataConfig.FirstOrDefault(config => config.DtName == valName);
            if (dataConfig == null)
            {
                return -2;
            }

            ret = WriteSingleVariable(dataConfig, val);
            return ret;
        }

        #endregion

        //*****************************************************************************
        #region Method_ExternalUsing
        /// <summary>加载本地KeyencePLC文件</summary>
        /// <param name="filePath">路径</param>
        /// <returns></returns>
        public int ImportDataTable(string filePath)
        {
            var iRet = 0;
            if (DataConfigs == null)
            {
                DataConfigs = new PlcDataConfigs();
            }
            if (DataConfigs.ListDataConfig == null)
            {
                DataConfigs.ListDataConfig = new List<PlcDataConfig>();
            }
            DataConfigs.ListDataConfig.Clear();

            if (File.Exists(filePath))
            {
                DataConfigs = XmlSerializerHelper.ReadXML(filePath, typeof(PlcDataConfigs)) as PlcDataConfigs;
            }

            if (DataConfigs == null)
            {
                DataConfigs = new PlcDataConfigs();
            }
            return iRet;
        }
        /// <summary>保存本地KeyencePLC文件</summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public int ExportDataTable(string filePath)
        {
            return XmlSerializerHelper.WriteXML(DataConfigs, filePath, typeof(PlcDataConfigs)) ? 0 : -1;
        }
        #endregion

        //*****************************************************************************
        #region Method_InternalUsing

        /// <summary>日志</summary>
        /// <param name="msg">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示弹窗；false：不显示弹窗；</param>
        public void LogAdd(string msg, LogLevel lv, long id = 0, bool isShowDialog = false)
        {
            if (!LogEnable && lv != LogLevel.Warn && lv != LogLevel.Error && lv != LogLevel.Fatal)
            {
                return;
            }

            msg = $"PrimKeyencePLC -> { Name} -> " + msg;
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
        /// <summary>循环线程</summary>
        private void CycleRead(CancellationToken token)
        {
            // 阻塞等触发
            while (true)
            {
                _sw.Restart();
                if (PrimRunStat != PrimRunState.Running)
                {
                    if (token.IsCancellationRequested)
                    {
                        LogAdd("手动停止", LogLevel.Info);
                        return;
                    }

                    Thread.Sleep(10);
                    continue;
                }

                if (DataConfigs?.ListDataConfig == null || DataConfigs.ListDataConfig.Count <= 0)
                {

                    if (token.IsCancellationRequested)
                    {
                        LogAdd("手动停止", LogLevel.Info);
                        return;
                    }

                    Thread.Sleep(10);
                    continue;
                }

                int start = 0;
                int length = 0;
                object obj = null;
                object LastValue = null;
                foreach (var config in DataConfigs.ListDataConfig)
                {
                    if (token.IsCancellationRequested)
                    {
                        LogAdd("手动停止", LogLevel.Info);
                        return;
                    }

                    if (!(config.DtRdMode == DataReadMode.Cycle))
                    {
                        continue;
                    }

                    if (!(config.DtPermission == DataPermission.R || config.DtPermission == DataPermission.RW))
                    {
                        continue;
                    }
                    obj = ReadSingleVariable(config);
                    if (obj == null)
                    {
                        continue;
                    }
                    if (!obj.Equals(config.DtCurrentValue))
                    {
                        LastValue = config.DtCurrentValue;
                        config.DtCurrentValue = obj;
                        if (config.DtIsNotify)
                        {
                            OnPlcVariableChanged?.BeginInvoke(config.DtName, config.DtAddress, config.DtType.ToString(), LastValue, config.DtCurrentValue, null, null);
                        }
                    }
                }

                _cycleTime = (int)_sw.ElapsedMilliseconds;
                if (_cycleTime < _config.CycleTime)
                {
                    Thread.Sleep(_config.CycleTime - _cycleTime);
                    ((PrimConfigControl)PrimConfigUI).SetCycleTime(_config.CycleTime);
                }
                else
                {
                    ((PrimConfigControl)PrimConfigUI).SetCycleTime(_cycleTime);
                }
            }
        }
        private int WriteSingleVariable(PlcDataConfig dataConfig, object val)
        {
            var ret = -1;
            var isSuccess = false;
            if (string.IsNullOrEmpty(dataConfig.DtAddress)) return -1;
            PLCRespons pLCRespons;
            try
            {
                switch (dataConfig.DtType)
                {
                    case ProtocolDataType.SHORT:
                        pLCRespons = m_KeyenceProt.WriteInt16Word(dataConfig.DtAddressType, UInt16.Parse(dataConfig.DtAddress), Int16.Parse(val.ToString()));
                        isSuccess = pLCRespons == PLCRespons.OK;
                        break;

                    case ProtocolDataType.INT:
                        pLCRespons = m_KeyenceProt.WriteInt32Word(dataConfig.DtAddressType, UInt16.Parse(dataConfig.DtAddress), Int32.Parse(val.ToString()));
                        isSuccess = pLCRespons == PLCRespons.OK;
                        break;

                    case ProtocolDataType.LONG:
                        pLCRespons = m_KeyenceProt.WriteInt64Word(dataConfig.DtAddressType, UInt16.Parse(dataConfig.DtAddress), Int64.Parse(val.ToString()));
                        isSuccess = pLCRespons == PLCRespons.OK;
                        break;

                    case ProtocolDataType.USHORT:
                        pLCRespons = m_KeyenceProt.WriteUInt16Word(dataConfig.DtAddressType, UInt16.Parse(dataConfig.DtAddress), UInt16.Parse(val.ToString()));
                        isSuccess = pLCRespons == PLCRespons.OK;
                        break;

                    case ProtocolDataType.UINT:
                        pLCRespons = m_KeyenceProt.WriteUInt32Word(dataConfig.DtAddressType, UInt16.Parse(dataConfig.DtAddress), UInt32.Parse(val.ToString()));
                        isSuccess = pLCRespons == PLCRespons.OK;
                        break;

                    case ProtocolDataType.ULONG:
                        pLCRespons = m_KeyenceProt.WriteUInt64Word(dataConfig.DtAddressType, UInt16.Parse(dataConfig.DtAddress), UInt64.Parse(val.ToString()));
                        isSuccess = pLCRespons == PLCRespons.OK;
                        break;

                    case ProtocolDataType.FLOAT:
                        pLCRespons = m_KeyenceProt.WriteFloatWord(dataConfig.DtAddressType, UInt16.Parse(dataConfig.DtAddress), float.Parse(val.ToString()));
                        isSuccess = pLCRespons == PLCRespons.OK;
                        break;

                    case ProtocolDataType.DOUBLE:
                        pLCRespons = m_KeyenceProt.WriteDoubleWord(dataConfig.DtAddressType, UInt16.Parse(dataConfig.DtAddress), Double.Parse(val.ToString()));
                        isSuccess = pLCRespons == PLCRespons.OK;
                        break;

                    case ProtocolDataType.BOOL:
                        pLCRespons = WritBoolWord(dataConfig.DtAddressType, UInt16.Parse(dataConfig.DtAddress), bool.Parse(val.ToString()));
                        isSuccess = pLCRespons == PLCRespons.OK;
                        break;

                    case ProtocolDataType.STRING:
                        pLCRespons = m_KeyenceProt.WriteAddrLengthString(dataConfig.DtAddressType, UInt16.Parse(dataConfig.DtAddress), val.ToString(), (uint)dataConfig.DtLength);
                        isSuccess = pLCRespons == PLCRespons.OK;
                        break;
                }
            }
            catch { }
            if (isSuccess) ret = 0;
            return ret;
        }

        private object ReadSingleVariable(PlcDataConfig dataConfig)
        {
            object val = null;
            if (string.IsNullOrEmpty(dataConfig.DtAddress))
            {
                return null;
            }
            PLCRespons pLCRespons;
            try
            {
                switch (dataConfig.DtType)
                {
                    case ProtocolDataType.SHORT:
                        {
                            pLCRespons = m_KeyenceProt.ReadInt16Word(dataConfig.DtAddressType, UInt16.Parse(dataConfig.DtAddress), out var valTemp);
                            val = valTemp;
                            break;
                        }
                    case ProtocolDataType.INT:
                        {
                            pLCRespons = m_KeyenceProt.ReadInt32Word(dataConfig.DtAddressType, UInt16.Parse(dataConfig.DtAddress), out var valTemp);
                            val = valTemp;
                            break;
                        }
                    case ProtocolDataType.LONG:
                        {
                            pLCRespons = m_KeyenceProt.ReadInt64Word(dataConfig.DtAddressType, UInt16.Parse(dataConfig.DtAddress), out var valTemp);
                            val = valTemp;
                            break;
                        }
                    case ProtocolDataType.USHORT:
                        {
                            pLCRespons = m_KeyenceProt.ReadUInt16Word(dataConfig.DtAddressType, UInt16.Parse(dataConfig.DtAddress), out var valTemp);
                            val = valTemp;
                            break;
                        }
                    case ProtocolDataType.UINT:
                        {
                            pLCRespons = m_KeyenceProt.ReadUInt32Word(dataConfig.DtAddressType, UInt16.Parse(dataConfig.DtAddress), out var valTemp);
                            val = valTemp;
                            break;
                        }
                    case ProtocolDataType.ULONG:
                        {
                            pLCRespons = m_KeyenceProt.ReadUInt64Word(dataConfig.DtAddressType, UInt16.Parse(dataConfig.DtAddress), out var valTemp);
                            val = valTemp;
                            break;
                        }
                    case ProtocolDataType.FLOAT:
                        {
                            pLCRespons = m_KeyenceProt.ReadFloatWord(dataConfig.DtAddressType, UInt16.Parse(dataConfig.DtAddress), out var valTemp);
                            val = valTemp;
                            break;
                        }
                    case ProtocolDataType.DOUBLE:
                        {
                            pLCRespons = m_KeyenceProt.ReadDoubleWord(dataConfig.DtAddressType, UInt16.Parse(dataConfig.DtAddress), out var valTemp);
                            val = valTemp;
                            break;
                        }
                    case ProtocolDataType.BOOL:
                        {
                            pLCRespons = ReadBoolWord(dataConfig.DtAddressType, UInt16.Parse(dataConfig.DtAddress), out var valTemp);
                            val = valTemp;
                            break;
                        }

                    case ProtocolDataType.STRING:
                        {
                            pLCRespons = m_KeyenceProt.ReadAddrLengthString(dataConfig.DtAddressType, UInt16.Parse(dataConfig.DtAddress), out var valTemp, (uint)dataConfig.DtLength);
                            int len = valTemp.ToString().IndexOf('\0') == -1 ? valTemp.ToString().Length - 1 : valTemp.ToString().IndexOf('\0');
                            valTemp = valTemp.ToString().Substring(0, len);
                            val = valTemp;
                            break;
                        }
                }
            }
            catch { }

            return val;
        }
        #endregion
    }

}
