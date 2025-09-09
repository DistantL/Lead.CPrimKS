using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using HslCommunication.BasicFramework;
using HslCommunication.Serial;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Communicate;
using Lead.CPrim.LocalizationService;
using Lead.CPrim.LogHelper;
using Lead.CPrim.XmlHelper;

namespace Lead.CPrim.PrimSerial
{
    public class PrimSerial : IPrim, ISerial
    {
        private static readonly object _mutexCycleWriteTask = new object();
        private readonly ManualResetEvent _trigManualResetEventCycleWrite = new ManualResetEvent(false);
        public SerialConfig _config;

        private object _mutexCycleReadTask = new object();
        private SerialPort _serial; // 串口交互的核心
        private Task _taskCycleRead;
        private Task _taskCycleWrite;
        private ManualResetEvent _trigManualResetEventCycleRead = new ManualResetEvent(false);
        private bool taskSuspend;

        public PrimSerial()
        {
            _config = new SerialConfig();
            PrimDebugUI = new PrimDebugControl(this);
            PrimConfigUI = new PrimConfigControl(this);
            PrimOutputUI = new PrimConfigControl();

            PrimConnStat = PrimConnState.Other;
            PrimRunStat = PrimRunState.Other;

            ((PrimConfigControl) PrimConfigUI).SetPrimConnState(PrimConnStat);
            ((PrimConfigControl) PrimConfigUI).SetPrimRunState(PrimRunStat);
            ((PrimDebugControl) PrimDebugUI).SetPrimConnState(PrimConnStat);
            ((PrimDebugControl) PrimDebugUI).SetPrimRunState(PrimRunStat);
        }

        public PrimSerial(XmlNode xmlNode)
        {
            //xmlNode turn to _config
            if (xmlNode != null)
                _config = XMLHelper.XMLToObject(xmlNode, typeof(SerialConfig)) as SerialConfig;
            else
                return;

            PrimDebugUI = new PrimDebugControl(this);
            PrimConfigUI = new PrimConfigControl(this);

            PrimConnStat = PrimConnState.Other;
            PrimRunStat = PrimRunState.Other;

            ((PrimConfigControl) PrimConfigUI).SetPrimConnState(PrimConnStat);
            ((PrimConfigControl) PrimConfigUI).SetPrimRunState(PrimRunStat);
            ((PrimDebugControl) PrimDebugUI).SetPrimConnState(PrimConnStat);
            ((PrimDebugControl) PrimDebugUI).SetPrimRunState(PrimRunStat);
        }

        public event PrimDataRefresh OnPrimDataRefresh;
        public event PrimStateChanged OnPrimStateChanged;
        public event PrimOpLog OnPrimOpLog;

        #region Override Conifg Property

        public bool LogEnable
        {
            get => _config.LogEnable;
            set => _config.LogEnable = value;
        }

        #endregion

        public event SerialMsgReved OnMsgReved;

        #region Private Feilds

        private Task _sendTask = null;
        private Task _revTask = null;

        private Queue<object> _sendQueue;
        private readonly object _sendQueueMutex = new object();
        private bool _sendFlag = false;
        private Queue<object> _revQueue;
        private readonly object _revQueueMutex = new object();
        private bool _revFlag = false;

        #endregion


        #region Override IPrim Property

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

        public Control PrimConfigUI { get; }

        public PrimConnState PrimConnStat
        {
            get => _config.PrimConnStat;

            set => _config.PrimConnStat = value;
        }

        public bool PrimDebug
        {
            get => _config.PrimDebug;

            set => _config.PrimDebug = value;
        }

        public LogLevel PrimAlarmLv { get; set; }
        public RunMode PrimRunMode { get; set; }
        public Control PrimDebugUI { get; }

        public bool PrimEnable
        {
            get => _config.PrimEnable;

            set => _config.PrimEnable = value;
        }

        public Control PrimOutputUI { get; }
        public int CurrentImageIndex
        {
            get => _config.CurrentImageIndex;

            set => _config.CurrentImageIndex = value;
        }

        public int IPrimTaskInit()
        {
            ClearEventOnMsgReved();
            if (PrimRunStat == PrimRunState.Stop || PrimRunStat == PrimRunState.Err)
                if (IPrimDispose() != 0)
                    return -1;

            if (IPrimInit() != 0) return -2;

            var connRet = "";
            if (IPrimConnect(ref connRet) != 0) return -3;

            if (IPrimStart() != 0) return -4;

            return 0;
        }

        public int IPrimTaskPause()
        {
            return 0;
        }

        public int IPrimTaskStop()
        {
            if (IPrimStop() != 0) return -1;
            return 0;
        }

        public int IPrimTaskReset()
        {
            if (IPrimReset() != 0) return -1;

            return 0;
        }


        public PrimRunState PrimRunStat
        {
            get => _config.PrimRunStat;

            set => _config.PrimRunStat = value;
        }

        public bool PrimSimulator
        {
            get => _config.PrimSimulator;

            set => _config.PrimSimulator = value;
        }

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

        #endregion

        #region Override IPrim Function

        public int IPrimReset()
        {
            var iRet = 0;
            return iRet;
        }

        public int IPrimInit()
        {
            if ((PrimRunStat == PrimRunState.Running || PrimRunStat == PrimRunState.Stop) &&
                PrimConnStat == PrimConnState.Connected) return 0;

            var iRet = 0;
            if (!int.TryParse(BoudRate, out var baudRate))
            {
                LogAdd(NLocalizer.GetString("PrimSerial_PrimDebugControl_BaudRateInputError", "Baud Rate Input Error!"),
                    LogLevel.Debug, 1);
                MessageBox.Show(NLocalizer.GetString("PrimSerial_PrimDebugControl_BaudRateInputError",
                    "Baud Rate Input Error!"));
                return -2;
            }

            if (!int.TryParse(DataBits, out var dataBits))
            {
                LogAdd(NLocalizer.GetString("PrimSerial_PrimDebugControl_DataBitInputError", "Data bit input Error! "),
                    LogLevel.Debug, 2);
                MessageBox.Show(NLocalizer.GetString("PrimSerial_PrimDebugControl_DataBitInputError",
                    "Data bit input Error! "));
                return -3;
            }

            if (!int.TryParse(StopBits, out var stopBits))
            {
                LogAdd(NLocalizer.GetString("PrimSerial_PrimDebugControl_StopBitInputError", "Stop bit input Error! "),
                    LogLevel.Debug, 3);
                MessageBox.Show(NLocalizer.GetString("PrimSerial_PrimDebugControl_StopBitInputError",
                    "Stop bit input Error! "));
                return -4;
            }

            _serial = new SerialPort();
            _serial.PortName = ComPort;
            _serial.BaudRate = baudRate;
            _serial.DataBits = dataBits;
            _serial.StopBits = stopBits == 0
                ? System.IO.Ports.StopBits.None
                : stopBits == 1
                    ? System.IO.Ports.StopBits.One
                    : System.IO.Ports.StopBits.Two;

            if (SerialParity == ParityMode.None)
                _serial.Parity = Parity.None;
            else if (SerialParity == ParityMode.Odd)
                _serial.Parity = Parity.Odd;
            else
                _serial.Parity = Parity.Even;

            _sendQueue = SendQueueCnt <= 0 ? new Queue<object>() : new Queue<object>(SendQueueCnt);

            if (_config.NotifyMode == SerialNotifyMode.DataQueue)
                _revQueue = RevQueueCnt <= 0 ? new Queue<object>() : new Queue<object>(RevQueueCnt);

            LogAdd(
                NLocalizer.GetString("PrimSerial_PrimDebugControl_SerialInitializeSuccessfully",
                    "Serial init successfully. "), LogLevel.Info, 1);

            PrimRunStat = PrimRunState.Stop;
            PrimConnStat = PrimConnState.UnConnected;

            ((PrimDebugControl) PrimDebugUI).SetPrimConnState(PrimConnStat);
            ((PrimDebugControl) PrimDebugUI).SetPrimRunState(PrimRunStat);

            ((PrimConfigControl) PrimConfigUI).SetPrimConnState(PrimConnStat);
            ((PrimConfigControl) PrimConfigUI).SetPrimRunState(PrimRunStat);

            taskSuspend = true;

            if (_taskCycleWrite == null)
            {
                _taskCycleWrite = new Task(CycleSend);
                _taskCycleWrite.Start();
            }

            return iRet;
        }

        public int IPrimConnect(ref string result)
        {
            var iRet = 0;

            if (PrimConnStat == PrimConnState.Connected)
            {
                result = Name + NLocalizer.GetString("PrimSerial_PrimDebugControl_Connected", "Connected");
                return 0;
            }

            try
            {
                _serial.DataReceived -= Serial_ReadDataReceived;
                _serial.DataReceived += Serial_ReadDataReceived;
                _serial.Open();

                LogAdd(
                    NLocalizer.GetString("PrimSerial_PrimDebugControl_SerialConnectSuccessfully",
                        "Serial connect successfully. "), LogLevel.Info, 2);

                PrimRunStat = PrimRunState.Stop;
                PrimConnStat = PrimConnState.Connected;
            }
            catch (Exception ex)
            {
                LogAdd(
                    NLocalizer.GetString("PrimSerial_PrimDebugControl_SerialCouldnotConnected",
                        "Serial could not be connected!(") + ex + ")", LogLevel.Error, 1);
                PrimRunStat = PrimRunState.Err;
                PrimConnStat = PrimConnState.UnConnected;
            }


            ((PrimDebugControl) PrimDebugUI).SetPrimConnState(PrimConnStat);
            ((PrimDebugControl) PrimDebugUI).SetPrimRunState(PrimRunStat);

            ((PrimConfigControl) PrimConfigUI).SetPrimConnState(PrimConnStat);
            ((PrimConfigControl) PrimConfigUI).SetPrimRunState(PrimRunStat);

            return iRet;
        }

        private void Serial_ReadDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
            // 接收数据
            byte[] buffer = null;
            var data = new byte[2048];
            var receiveCount = 0;
            //while (true)
            //{
            //if (PrimRunStat != PrimRunState.Running || PrimConnStat != PrimConnState.Connected)
            //{
            //return;   
            //}
            //Thread.Sleep(20);
            try
            {
                if (_serial.BytesToRead < 1)
                    return;

                int length = _serial.ReadByte();
                _serial.Read(data, 0, length);
                var revMsg = Encoding.ASCII.GetString(data);
                //revMsg = IsBinary ? Encoding.ASCII.GetString(buffer) : SoftBasic.ByteToHexString(buffer, ' ');
                if (PrimDebug)
                {
                    ((PrimConfigControl)PrimConfigUI).ShowRevMsg(revMsg);
                    ((PrimDebugControl)PrimDebugUI).ShowRevMsg(revMsg);
                }

                if (NotifyMode == SerialNotifyMode.DataEvent && OnMsgReved != null) OnMsgReved("", revMsg);

                if (NotifyMode != SerialNotifyMode.DataQueue) return;

                lock (_revQueueMutex)
                {
                    _revQueue.Enqueue(revMsg);
                }
                //break;

                //Thread.Sleep(20);
                //receiveCount += _serial.Read(data, receiveCount, _serial.BytesToRead);
                //buffer = new byte[receiveCount];
                //Array.Copy(data, 0, buffer, 0, receiveCount);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return;
            }
            //}

            //if (receiveCount == 0) return;

            //Action dataRev = () =>
            //{
            //    var revMsg = string.Empty;
            //    revMsg = IsBinary ? Encoding.ASCII.GetString(buffer) : SoftBasic.ByteToHexString(buffer, ' ');
            //    if (PrimDebug)
            //    {
            //        ((PrimConfigControl) PrimConfigUI).ShowRevMsg(revMsg);
            //        ((PrimDebugControl) PrimDebugUI).ShowRevMsg(revMsg);
            //    }

            //    if (NotifyMode == SerialNotifyMode.DataEvent && OnMsgReved != null) OnMsgReved("", revMsg);

            //    if (NotifyMode != SerialNotifyMode.DataQueue) return;

            //    lock (_revQueueMutex)
            //    {
            //        _revQueue.Enqueue(revMsg);
            //    }
            //};
            //dataRev.BeginInvoke(null, null);
        }

        public int IPrimStart()
        {
            var iRet = 0;

            if (PrimConnStat != PrimConnState.Connected) return -1;

            if (PrimRunStat != PrimRunState.Stop) return 0;

            if (_taskCycleWrite != null)
                if (taskSuspend)
                {
                    taskSuspend = false;
                    lock (_mutexCycleWriteTask)
                    {
                        _trigManualResetEventCycleWrite.Set();
                    }
                }

            LogAdd(
                NLocalizer.GetString("PrimSerial_PrimDebugControl_SerialStartedSuccessfully",
                    "Serial started successfully. "), LogLevel.Info, 3);

            PrimRunStat = PrimRunState.Running;

            ((PrimConfigControl) PrimConfigUI).SetPrimConnState(PrimConnStat);
            ((PrimConfigControl) PrimConfigUI).SetPrimRunState(PrimRunStat);
            ((PrimDebugControl) PrimDebugUI).SetPrimConnState(PrimConnStat);
            ((PrimDebugControl) PrimDebugUI).SetPrimRunState(PrimRunStat);

            return iRet;
        }

        private void CycleSend()
        {
            //lock (_mutexCycleWriteTask)
            //{
            //    _trigManualResetEventCycleWrite.WaitOne();
            //}

            while (true)
            {
                Thread.Sleep(50);

                if (taskSuspend) _trigManualResetEventCycleWrite.WaitOne();

                //if (PrimConnStat == PrimConnState.UnConnected)  { Thread.Sleep(2); continue;}

                lock (_sendQueueMutex)
                {
                    if (_sendQueue.Count < 1)
                    {
                        Thread.Sleep(2);
                        continue;
                    }
                }

                object sendObj = null;

                lock (_sendQueueMutex)
                {
                    sendObj = _sendQueue.Dequeue();
                }

                if (sendObj == null)
                {
                    Thread.Sleep(2);
                    continue;
                }

                var sendStr = (byte[]) sendObj;

                try
                {
                    _serial.Write(sendStr, 0, sendStr.Length);
                }
                catch (Exception ex)
                {
                    LogAdd(
                        NLocalizer.GetString("PrimSerial_PrimDebugControl_SerialSendMessageFailed",
                            "Serial send msg failed!(") + ex + ")", LogLevel.Error, 2);
                    PrimRunStat = PrimRunState.Err;
                }

                ((PrimConfigControl) PrimConfigUI).SetPrimRunState(PrimRunStat);
                ((PrimDebugControl) PrimDebugUI).SetPrimRunState(PrimRunStat);
                Thread.Sleep(2);
            }
        }

        private void CycleRev()
        {
            byte[] buffer = null;
            var data = new byte[2048];
            var receiveCount = 0;

            lock (_mutexCycleWriteTask)
            {
                _trigManualResetEventCycleWrite.WaitOne();
            }

            while (true)
            {
                if (taskSuspend)
                    lock (_mutexCycleWriteTask)
                    {
                        _trigManualResetEventCycleWrite.WaitOne();
                    }

                //  if (!_revFlag) { Thread.Sleep(2); continue; }
                try
                {
                    // 接收数据
                    Thread.Sleep(20);
                    if (_serial.BytesToRead < 1)
                    {
                        buffer = new byte[receiveCount];
                        Array.Copy(data, 0, buffer, 0, receiveCount);
                        continue;
                    }

                    receiveCount += _serial.Read(data, receiveCount, _serial.BytesToRead);
                    if (receiveCount == 0) continue;

                    var revMsg = string.Empty;

                    if (PrimDebug)
                    {
                        if (IsBinary)
                            //revMsg = SoftBasic.ByteToHexString(buffer, ' ');
                            revMsg = Encoding.ASCII.GetString(buffer);

                        ((PrimConfigControl) PrimConfigUI).ShowRevMsg(revMsg);
                        ((PrimDebugControl) PrimDebugUI).ShowRevMsg(revMsg);
                    }

                    if (NotifyMode == SerialNotifyMode.DataEvent && OnMsgReved != null) OnMsgReved("", revMsg);

                    if (NotifyMode == SerialNotifyMode.DataQueue)
                        lock (_revQueueMutex)
                        {
                            _revQueue.Enqueue(revMsg);
                        }

                    receiveCount = 0;
                }
                catch (Exception)
                {
                }

                Thread.Sleep(2);
            }
        }

        public int IPrimStop()
        {
            var iRet = 0;

            taskSuspend = true;
            Thread.Sleep(200);

            // 断开连接
            try
            {
                _serial.Close();

                LogAdd(
                    NLocalizer.GetString("PrimSerial_PrimDebugControl_SerialPortHadClosed",
                        "Serial port had be closed!"), LogLevel.Info, 4);

                PrimConnStat = PrimConnState.UnConnected;
                PrimRunStat = PrimRunState.Stop;
            }
            catch (Exception e)
            {
                LogAdd(
                    NLocalizer.GetString("PrimSerial_PrimDebugControl_SerialPortCouldnotDisconnected",
                        "Serial port could not be disconnected!(") + e + ")", LogLevel.Info, 5);
                PrimRunStat = PrimRunState.Running;
                PrimConnStat = PrimConnState.Connected;

                iRet = -1;
            }

            ((PrimDebugControl) PrimDebugUI).SetPrimConnState(PrimConnStat);
            ((PrimDebugControl) PrimDebugUI).SetPrimRunState(PrimRunStat);

            ((PrimConfigControl) PrimConfigUI).SetPrimConnState(PrimConnStat);
            ((PrimConfigControl) PrimConfigUI).SetPrimRunState(PrimRunStat);

            return iRet;
        }

        public int IPrimDisConnect(ref string result)
        {
            return 0;
        }

        public int IPrimSuspend()
        {
            throw new NotImplementedException();
        }

        public int IPrimResume()
        {
            throw new NotImplementedException();
        }

        public int IPrimDispose()
        {
            try
            {
                if (_serial != null)
                {
                    IPrimStop();
                    _serial.Dispose();
                }

                PrimRunStat = PrimRunState.Other;
                PrimConnStat = PrimConnState.Other;
                return 0;
            }
            catch (Exception)
            {
                PrimRunStat = PrimRunState.Err;
                PrimConnStat = PrimConnState.Other;

                ((PrimDebugControl) PrimDebugUI).SetPrimConnState(PrimConnStat);
                ((PrimDebugControl) PrimDebugUI).SetPrimRunState(PrimRunStat);

                ((PrimConfigControl) PrimConfigUI).SetPrimConnState(PrimConnStat);
                ((PrimConfigControl) PrimConfigUI).SetPrimRunState(PrimRunStat);
                return -1;
            }
        }

        public int IPrimImportConfigXml(XmlNode xmlNode)
        {
            var iRet = 0;
            if (xmlNode != null)
                _config = XMLHelper.XMLToObject(xmlNode, typeof(SerialConfig)) as SerialConfig;
            else
                return -1;
            return iRet;
        }

        public XmlNode IPrimExportConfigXml()
        {
            //config turn to xmlNode
            if (_config == null) return null;

            var node = XMLHelper.ObjectToXML(_config);

            return node;
        }

        #endregion

        #region Overide ISerial Property

        public string ComPort
        {
            get => _config.ComPort;
            set => _config.ComPort = value;
        }

        public string BoudRate
        {
            get => _config.BoudRate;
            set => _config.BoudRate = value;
        }

        public string DataBits
        {
            get => _config.DataBits;
            set => _config.DataBits = value;
        }

        public string StopBits
        {
            get => _config.StopBits;
            set => _config.StopBits = value;
        }

        public ParityMode SerialParity
        {
            get => _config.SerialParity;
            set => _config.SerialParity = value;
        }

        public int SendQueueCnt
        {
            set => _config.SendQueueCnt = value;
            get => _config.SendQueueCnt;
        }

        public int RevQueueCnt
        {
            set => _config.RevQueueCnt = value;
            get => _config.RevQueueCnt;
        }

        public string NetName
        {
            set => _config.NetName = value;
            get => _config.NetName;
        }

        public bool IsBinary
        {
            set => _config.IsBinary = value;
            get => _config.IsBinary;
        }

        public string Code1
        {
            get => _config.Code1;
            set => _config.Code1 = value;
        }

        public string Code2
        {
            get => _config.Code2;
            set => _config.Code2 = value;
        }

        public bool CalCheckCode
        {
            get => _config.CalCheckCode;
            set => _config.CalCheckCode = value;
        }

        public SerialNotifyMode NotifyMode
        {
            get => _config.NotifyMode;
            set => _config.NotifyMode = value;
        }

        #endregion

        #region Overide ISerial Function

        public int SetSendQueueCnt(int cnt)
        {
            var iRet = 0;

            SendQueueCnt = cnt;

            return iRet;
        }

        public int SetNotifyMode(SktNotifyMode mode, int num)
        {
            throw new NotImplementedException();
        }

        public int SetNotifyMode(SerialNotifyMode mode, int cnt)
        {
            var iRet = 0;

            NotifyMode = mode;
            RevQueueCnt = cnt;
            return iRet;
        }

        public int RegNotifyInfo(string regInfo)
        {
            throw new NotImplementedException();
        }

        public int SetNetName(string name)
        {
            throw new NotImplementedException();
        }

        public int SetFilterInfo(string filterInfo)
        {
            throw new NotImplementedException();
        }

        public int SendInfo(string rev, object context)
        {
            var iRet = 0;

            // 发送数据
            byte[] send = null;
            var strSend = context.ToString();
            if (_config.IsBinary)
                send = SoftBasic.HexStringToBytes(strSend);
            else
                send = Encoding.ASCII.GetBytes(strSend);

            if (CalCheckCode)
            {
                try
                {
                    send = SoftCRC16.CRC16(send, Convert.ToByte(Code1, 16), Convert.ToByte(Code2, 16));
                }
                catch (Exception ex)
                {
                    LogAdd(
                        NLocalizer.GetString("PrimSerial_PrimDebugControl_CRCCheckCodeInputFailed",
                            "CRC check code input failed!(") + ex + ")", LogLevel.Error, 3);
                    PrimRunStat = PrimRunState.Err;
                    ((PrimConfigControl)PrimConfigUI).SetPrimRunState(PrimRunStat);
                    ((PrimDebugControl)PrimDebugUI).SetPrimRunState(PrimRunStat);
                }
            }

            lock (_sendQueueMutex)
            {
                _sendQueue.Enqueue(send);
            }

            return iRet;
        }

        private void LogAdd(string log, LogLevel lv, int id)
        {
            if (!LogEnable) return;

            switch (lv)
            {
                case LogLevel.Fatal:
                    Log.Fatal(11030000 + id, log, LogClassification.VisioPrim, Name);
                    PrimAlarmLv = LogLevel.Fatal;
                    PrimRunStat = PrimRunState.Err;
                    break;
                case LogLevel.Error:
                    Log.Error(21030000 + id, log, LogClassification.VisioPrim, Name);
                    PrimAlarmLv = LogLevel.Error;
                    PrimRunStat = PrimRunState.Err;
                    break;
                case LogLevel.Warn:
                    Log.Warn(31030000 + id, log, LogClassification.VisioPrim, Name);
                    PrimAlarmLv = LogLevel.Warn;
                    PrimRunStat = PrimRunState.Err;
                    break;
                case LogLevel.Info:
                    Log.Info(41030000 + id, log, LogClassification.VisioPrim, Name);
                    PrimAlarmLv = LogLevel.Info;
                    // PrimRunStat = PrimRunState.Err;
                    break;
                case LogLevel.Debug:
                    Log.Debug(51030000 + id, log, LogClassification.VisioPrim, Name);
                    PrimAlarmLv = LogLevel.Debug;
                    //PrimRunStat = PrimRunState.Err;
                    break;
                case LogLevel.Trace:
                    Log.Trace(61030000 + id, log, LogClassification.VisioPrim, Name);
                    PrimAlarmLv = LogLevel.Trace;
                    //PrimRunStat = PrimRunState.Err;
                    break;
            }
        }

        public int ClearEventOnMsgReved()
        {
            var iRet = 0;

            if (OnMsgReved == null) return iRet;

            foreach (var d in OnMsgReved.GetInvocationList()) OnMsgReved -= d as SerialMsgReved;

            return iRet;
        }

        #endregion
    }
}