using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.RFID;
using SGModbus;
using static SGModbus.Modbus;
using static SGModbus.ReaderInit;

namespace Lead.CPrim.PrimYouShangRFID
{
    public class PrimRFID : IPrim, IRFIDYouShang
    {
        #region Field
        public RFIDConfig _config;

        private Modbus rfid = new Modbus();
        /// <summary>RFIDIndex</summary>
        private RFNum_enum rfidIndex = 0x00;
        /// <summary>RFID读写锁</summary>
        private static readonly object locker = new object();
        #endregion


        #region Prop
        public string Ip { get => _config.Ip; set => _config.Ip = value; }

        public int Port { get => _config.Port; set => _config.Port = value; }

        public int ReTries { get => _config.ReTries; set => _config.ReTries = value; }

        public bool LogEnable { get => _config.LogEnable; set => _config.LogEnable = value; }

        public bool PrimDebug { get => _config.PrimDebug; set => _config.PrimDebug = value; }

        public Control PrimDebugUI { get; }
        #endregion


        #region Ctor
        public PrimRFID()
        {
            _config = new RFIDConfig();
            PrimDebugUI = new PrimDebugControl();
            PrimConfigUI = new PrimConfigControl(this);
            PrimOutputUI = new PrimOutputControl();
            SetConn_RunState((PrimConnState)100, (PrimRunState)100);
        }
        public PrimRFID(XmlNode xmlNode)
        {
            if (xmlNode != null)
            {
                _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(RFIDConfig)) as RFIDConfig;
            }
            PrimDebugUI = new PrimDebugControl();
            PrimConfigUI = new PrimConfigControl(this);
            PrimOutputUI = new PrimOutputControl();
            SetConn_RunState((PrimConnState)100, (PrimRunState)100);
        }
        #endregion


        #region Override IPrim
        public Guid Id { get => _config.Id; set => _config.Id = value; }
        public string Name
        {
            get => _config.Name;
            set
            {
                ((PrimConfigControl)PrimConfigUI).SetPrimName(value);
                _config.Name = value;
            }
        }
        public bool PrimEnable { get => _config.PrimEnable; set => _config.PrimEnable = value; }
        public PrimType HSType { get => _config.HSType; set => _config.HSType = value; }
        public string PrimTypeName { get => _config.PrimTypeName; set => _config.PrimTypeName = value; }
        public Control PrimConfigUI { get; }
        public Control PrimOutputUI { get; }
        public PrimConnState PrimConnStat { get => _config.PrimConnStat; set => _config.PrimConnStat = value; }
        public PrimRunState PrimRunStat { get => _config.PrimRunStat; set => _config.PrimRunStat = value; }
        public PrimVer Ver { get => _config.Ver; set => _config.Ver = value; }
        public int CurrentImageIndex { get => _config.CurrentImageIndex; set => _config.CurrentImageIndex = value; }
        public int IPrimInit()
        {
            try
            {
                int iRet = 0;
                if ((int)PrimConnStat == 0)
                {
                    return iRet;
                }
                iRet = ((!rfid.Connect(Ip, Port)) ? (-1) : 0);
                if (iRet == 0)
                {
                    SetConn_RunState((PrimConnState)0, (PrimRunState)3);
                    LogAdd("客户端初始化成功", (LogLevel)4, 0L);
                    return iRet;
                }
                throw new Exception("Connect方法返回失败");
            }
            catch (Exception ex)
            {
                LogAdd("客户端初始化失败" + ex.Message, (LogLevel)3, 0L);
                SetConn_RunState((PrimConnState)1, (PrimRunState)3);
                return -1;
            }
        }
        public int IPrimConnect(ref string result)
        {
            try
            {
                return 0;
            }
            catch (Exception ex)
            {
                LogAdd("客户端连接失败" + ex.Message, (LogLevel)3, 0L);
                SetConn_RunState((PrimConnState)1, (PrimRunState)3);
                return -1;
            }
        }
        public int IPrimStart()
        {
            try
            {
                int iRet = 0;
                SetRunState((PrimRunState)1);
                return iRet;
            }
            catch (Exception ex)
            {
                LogAdd("客户端运行失败" + ex.Message, (LogLevel)3, 0L);
                SetRunState((PrimRunState)4);
                return 29;
            }
        }
        public int IPrimStop()
        {
            return 0;
        }
        public int IPrimDispose()
        {
            try
            {
                int iRet = 0;
                SetConn_RunState((PrimConnState)100, (PrimRunState)100);
                return iRet;
            }
            catch (Exception ex)
            {
                LogAdd("客户端释放失败" + ex.Message, (LogLevel)3, 0L);
                SetConn_RunState((PrimConnState)100, (PrimRunState)4);
                return 26;
            }
        }
        public int IPrimTaskInit()
        {
            int iRet = IPrimInit();
            if (iRet != 0)
            {
                return iRet;
            }
            string connRet = "";
            iRet = IPrimConnect(ref connRet);
            if (iRet != 0)
            {
                return iRet;
            }
            iRet = IPrimStart();
            if (iRet != 0)
            {
                return iRet;
            }
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
            return (IPrimStop() != 0) ? (-1) : 0;
        }
        public XmlNode IPrimExportConfigXml()
        {
            if (_config == null)
            {
                return null;
            }
            return ProxyTools.XMLHelper.ObjectToXML((object)_config);
        }
        public int IPrimImportConfigXml(XmlNode xmlNode)
        {
            int iRet = 0;
            if (xmlNode != null)
            {
                _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(RFIDConfig)) as RFIDConfig;
                return iRet;
            }
            return -1;
        }
        #endregion



        #region Override IRFIDYouShang
        public void DisConnectRfid()
        {
            rfid.DisConnect();
        }
        public int EnableRfid(int Index)
        {
            try
            {
                byte[] data = new byte[10];
                Status_enum Status;
                rfidIndex = (RFNum_enum)((byte)rfidIndex | (1 << Index));

                lock (locker)
                {
                    ReaderInit rf = new ReaderInit(rfidIndex, (ushort)0, (ushort)0, data);
                    Status = rfid.EnableRF(rf);
                }

                if ((int)Status == 15)
                {
                    LogAdd($"RFID => {Index} 上使能成功", LogLevel.Trace, 0);
                    return 0;
                }

                LogAdd($"RFID => { Index} 上使能失败，错误代码 => {Status}", LogLevel.Trace, 0);
            }
            catch (Exception ex)
            {
                LogAdd($"RFID => { Index} 上使能失败，错误代码 => {ex.Message}", LogLevel.Trace, 0);
            }

            return -1;
        }
        public int DisEnableRfid()
        {
            try
            {
                ReaderInit rf = new ReaderInit();
                Status_enum Status = rfid.CloseRF(rf);
                if ((int)Status == 15)
                {
                    LogAdd($"RFID下使能成功", LogLevel.Trace, 0);
                    return 0;
                }

                LogAdd($"RFID下使能失败，错误代码 => {Status}", LogLevel.Trace, 0);
            }
            catch (Exception ex)
            {
                LogAdd($"RFID下使能失败，错误代码 => {ex.Message}", LogLevel.Trace, 0);
            }

            return -1;
        }
        public int WriteRifd(int Index, string dataStr)
        {
            try
            {
                ushort Addr = 0;
                byte[] data = Encoding.Default.GetBytes(dataStr);
                Status_enum Status;
                RFNum_enum rfidIndex = (RFNum_enum)(1 << Index);

                lock (locker)
                {
                    ReaderInit rf = new ReaderInit(rfidIndex, Addr, (ushort)data.Length, data);
                    Status = rfid.WriteTagByte(rf);
                }

                if ((int)Status == 15)
                {
                    return 0;
                }

                LogAdd($"RFID写入失败，错误代码 => {Status}", LogLevel.Trace, 0);
            }
            catch (Exception ex)
            {
                LogAdd($"RFID写入失败，错误代码 => {ex.Message}", LogLevel.Trace, 0);
            }

            return -1;
        }
        public string ReadRfid(int Index, ushort dataLength)
        {
            try
            {
                ushort datalen = dataLength;
                ushort Addr = 0;
                Status_enum Status;
                RFNum_enum rfidIndex = (RFNum_enum)(1 << Index);
                lock (locker)
                {
                    ReaderInit rf = new ReaderInit(rfidIndex, Addr, datalen);
                    DateTime start = DateTime.Now;
                    Status = rfid.ReadTagByte(ref rf);
                    if ((int)Status == 15)
                    {
                        List<byte> dataList = new List<byte>();
                        for (int i = 0; i < datalen; i++)
                        {
                            dataList.Add(rf.TagData[Index, i]);
                        }
                        string str = Encoding.Default.GetString(dataList.ToArray());
                        str = str.Replace("\0", "");
                        if (str == "")
                        {
                            return string.Empty;
                        }
                        return str;
                    }

                    LogAdd($"RFID读取失败，错误代码 => {Status}", LogLevel.Trace, 0);
                }
            }
            catch (Exception ex)
            {
                LogAdd($"RFID读取失败，错误代码 => {ex.Message}", LogLevel.Trace, 0);
            }
            return string.Empty;
        }
        public int ClearRfid(int Index, ushort clearDataLength)
        {
            try
            {
                ushort cleardatalen = clearDataLength;
                ushort clearAddr = 0;
                byte cleardata = 0;
                Status_enum Status;
                RFNum_enum rfidIndex = (RFNum_enum)(1 << Index);

                lock (locker)
                {
                    ReaderInit rf = new ReaderInit(rfidIndex, clearAddr, cleardatalen, cleardata);
                    Status = rfid.ClearTagByte(rf);
                }

                if ((int)Status == 15)
                {
                    return 0;
                }

                LogAdd($"RFID清除失败，错误代码 => {Status}", LogLevel.Trace, 0);
            }
            catch (Exception ex)
            {
                LogAdd($"RFID清除失败，错误代码 => {ex.Message}", LogLevel.Trace, 0);
            }

            return -1;
        }
        #endregion



        #region Other
        private void SetConn_RunState(PrimConnState Conn, PrimRunState Run)
        {
            PrimConnStat = Conn;
            PrimRunStat = Run;
            ((PrimConfigControl)PrimConfigUI).SetPrimConnState(Conn);
            ((PrimConfigControl)PrimConfigUI).SetPrimRunState(Run);
        }
        private void SetConnState(PrimConnState Conn)
        {
            PrimConnStat = Conn;
            ((PrimConfigControl)PrimConfigUI).SetPrimConnState(Conn);
        }
        private void SetRunState(PrimRunState Run)
        {
            PrimRunStat = Run;
            ((PrimConfigControl)PrimConfigUI).SetPrimRunState(Run);
        }
        private void LogAdd(string log, LogLevel lv, long id)
        {
            if (LogEnable)
            {
                string tempId = $"{(int)lv}{155}0000";
                if (long.TryParse(tempId, out var intId))
                {
                    id += intId;
                }
                ProxyTools.LogHelper.LogAdd(lv, log, Name, (LogClassification)0, id);
            }
        }
        #endregion
    }
}
