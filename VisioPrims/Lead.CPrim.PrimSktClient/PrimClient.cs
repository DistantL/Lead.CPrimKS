/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: PrimClient.cs
 * Author: Victor
 * Description: Socket客户端管理类
 * CreateTime: 2020-01-01
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.1017><Victor><20221029>
 * 1、OnLine掉线事件由连接回调移动至接收回调
 * 
 * <3.3.22.1117><Victor><20221119>
 * 1、启用调试不进行本地保存
 * 
 * <3.3.23.0101><Victor><20230116>
 * 1、支持HEX格式进行发送接收
 * 
 * <3.3.23.0101><Victor><20230308>
 * 1、对心跳进行优化
******************************************************************************/

using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.PrimSktClient
{
    /// <summary>基元管理类</summary>
    public class PrimClient : IPrim, ISktClient
    {
        #region Define_Event
        //public event PrimDataRefresh OnPrimDataRefresh;
        //public event PrimOpLog OnPrimOpLog;
        //public event PrimStateChanged OnPrimStateChanged;
        #endregion



        #region Private Feilds
        /// <summary>客户端配置管理器</summary>
        public ClientConfig _config;
        /// <summary>客户端</summary>
        private TcpClient _tcpClient;
        /// <summary>套接字接口</summary>
        private Socket _socket;
        /// <summary>IP</summary>
        private IPAddress _ip;
        /// <summary>端口</summary>
        private int _port;
        /// <summary>发送队列</summary>
        private Queue<object> _sendQueue;
        /// <summary>接收队列</summary>
        private ConcurrentQueue<object> _revQueue;

        /// <summary>发送任务/接收任务/心跳任务标志</summary>
        private bool _taskFlag;

        /// <summary>发送任务</summary>
        private Task _sendTask;
        /// <summary>发送标志</summary>
        private bool _sendFlag;
        /// <summary>发送队列锁</summary>
        private readonly object _sendQueueMutex = new object();

        /// <summary>接收任务</summary>
        private Task _revTask;
        /// <summary>接收标志</summary>
        private bool _revFlag;

        /// <summary>心跳任务</summary>
        private Task _heartTask = null;
        /// <summary>心跳任务取消标志</summary>
        CancellationTokenSource ctsHeart = new CancellationTokenSource();
        /// <summary>重连次数</summary>
        private int _retries = 0;
        /// <summary>接收缓存 数据</summary>
        private byte[] _revBuffer = new byte[1024 * 1024];
        /// <summary>重试中</summary>
        private bool _trying = false;
        #endregion



        #region Prop
        /// <summary>启用调试</summary>
        public bool PrimDebug { get; set; } = false;
        /// <summary>连接协议</summary>
        public SktConnMode ConnMode { get => _config.ConnMode; set => _config.ConnMode = value; }
        /// <summary>编码类型</summary>
        public EncodingType TransEncodingType { get => _config.TransEncodingType; set => _config.TransEncodingType = value; }
        /// <summary>PrimDebugUI</summary>
        public Control PrimDebugUI { get; }
        /// <summary>日志是否启用</summary>
        public bool LogEnable { get => _config.LogEnable; set => _config.LogEnable = value; }
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public PrimClient()
        {
            _config = new ClientConfig();
            PrimDebugUI = new PrimDebugControl();
            PrimConfigUI = new PrimConfigControl(this);
            PrimOutputUI = new PrimOutputControl();

            SetConn_RunState(PrimConnState.Other, PrimRunState.Other);
        }
        /// <summary>Ctor有1个参数</summary>
        public PrimClient(XmlNode xmlNode)
        {
            if (xmlNode != null)
                _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(ClientConfig)) as ClientConfig;
            else
                return;

            PrimDebugUI = new PrimDebugControl();
            PrimConfigUI = new PrimConfigControl(this);
            PrimOutputUI = new PrimOutputControl();

            SetConn_RunState(PrimConnState.Other, PrimRunState.Other);
        }
        #endregion



        #region Override IPrim
        public Guid Id
        {
            get => _config.Id;

            set => _config.Id = value;
        }
        public string Name
        {
            get
            {
                return _config.Name;
            }
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
                if (PrimRunStat == PrimRunState.Running && PrimConnStat == PrimConnState.Connected) return 0;

                var iRet = 0;

                if (string.IsNullOrEmpty(_config.Ip))
                {
                    return (int)SoftWareAlarm.SktClient_IP地址为空;
                }

                if (!IPAddress.TryParse(_config.Ip, out _ip))
                {
                    return (int)SoftWareAlarm.SktClient_IP地址无效;
                }

                if (string.IsNullOrEmpty(_config.Port) || !int.TryParse(_config.Port, out _port))
                {
                    return (int)SoftWareAlarm.SktClient_端口无效;
                }

                if (_config.NotifyMode == SktNotifyMode.DataQueue && _sendQueue == null)
                {
                    _sendQueue = SendQueueCnt <= 0 ? new Queue<object>() : new Queue<object>(SendQueueCnt);
                }

                if (_config.NotifyMode == SktNotifyMode.DataQueue && _revQueue == null)
                {
                    _revQueue = new ConcurrentQueue<object>();
                }

                if (_config.ConnMode == SktConnMode.TCP)
                {
                    if (!_trying)
                    {
                        _trying = true;
                    }
                    else
                    {
                        return 0;
                    }
                    IsReceivingByte = false;
                    QueueMsg = new ConcurrentQueue<byte[]>();
                    if (_tcpClient == null)
                    {
                        _tcpClient = new TcpClient();
                        _tcpClient.NoDelay = true;
                        _tcpClient.BeginConnect(_ip, _port, RequestCallBack, null);
                        return 0;
                    }
                }
                else if (_config.ConnMode == SktConnMode.UDP)
                {
                    _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                }

                SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Stop);
                LogAdd("客户端IPrimInit成功", LogLevel.Info);
                return iRet;
            }
            catch (Exception ex)
            {
                LogAdd("客户端IPrimInit失败" + ex.Message, LogLevel.Warn);
                SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Stop);
                return (int)SoftWareAlarm.SktClient_客户端初始化失败;
            }
        }
        public int IPrimConnect(ref string result)
        {
            try
            {
                var iRet = 0;

                if (PrimConnStat == PrimConnState.Connected)
                {
                    result = Name + ProxyTools.NLocalizer.GetString("PrimSktClient_PrimClient_Connected", "Connected");
                    return 0;
                }

                if (_config.ConnMode == SktConnMode.UDP)
                {
                    while (true)
                    {
                        var reconnectCnt = 0;
                        try
                        {
                            _socket.Connect(new IPEndPoint(_ip, _port));
                            result = Name + ProxyTools.NLocalizer.GetString("PrimSktClient_PrimClient_ConnectSuccess", "Connect Success");
                            LogAdd(result, LogLevel.Info);
                            break;
                        }
                        catch
                        {
                            SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Err);
                            result = Name + ProxyTools.NLocalizer.GetString("PrimSktClient_PrimClient_ConnectFail", "Connect Fail");
                            LogAdd(result, LogLevel.Error);
                            reconnectCnt++;
                            if (reconnectCnt >= ReconnectCnt)
                                return -1;
                            Thread.Sleep(500);
                        }
                    }

                    SetConnState(PrimConnState.Connected);
                }

                return iRet;
            }
            catch (Exception ex)
            {
                LogAdd("客户端IPrimConnect失败" + ex.Message, LogLevel.Warn);
                SetConnState(PrimConnState.UnConnected);
                return (int)SoftWareAlarm.SktClient_客户端连接失败;
            }
        }
        public int IPrimStart()
        {
            try
            {
                var iRet = 0;

                if (PrimRunStat == PrimRunState.Running && PrimConnStat == PrimConnState.Connected) return 0;

                if (PrimConnStat != PrimConnState.Connected) return -1;

                if (PrimRunStat != PrimRunState.Stop && PrimRunStat != PrimRunState.Err) return -2;

                if (_config.HeartInfoCycleTime <= 10) _config.HeartInfoCycleTime = 1000;

                _taskFlag = true;
                if (_sendTask == null && _config.ConnMode == SktConnMode.UDP)
                {
                    _sendFlag = true;
                    _sendTask = new Task(() => CycleSend());
                    _sendTask.Start();
                }

                if (_revTask == null && _config.ConnMode == SktConnMode.UDP)
                {
                    _revFlag = true;
                    _revTask = new Task(() => CycleRev());
                    _revTask.Start();
                }

                if (_heartTask == null && _config.HeartFlag)
                {
                    ctsHeart = new CancellationTokenSource();
                    _heartTask = new Task(() => CycleHeart(ctsHeart.Token));
                    _heartTask.Start();
                }


                SetRunState(PrimRunState.Running);

                return iRet;
            }
            catch (Exception ex)
            {
                LogAdd("客户端IPrimStart失败" + ex.Message, LogLevel.Warn);
                SetRunState(PrimRunState.Err);
                return (int)SoftWareAlarm.SktClient_客户端运行失败;
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
                int ret = 0;
                var disConnectRet = "";
                ret = IPrimDisConnect(ref disConnectRet);
                if (ret != 0)
                {
                    return ret;
                }

                ret = IPrimStop();
                if (ret != 0)
                {
                    return ret;
                }

                SetConn_RunState(PrimConnState.Other, PrimRunState.Other);
                return ret;
            }
            catch (Exception ex)
            {
                LogAdd("客户端IPrimDispose失败" + ex.Message, LogLevel.Warn, 0);
                SetConn_RunState(PrimConnState.Other, PrimRunState.Err);
                return (int)SoftWareAlarm.SktClient_客户端释放失败;
            }
        }
        public int IPrimTaskInit()
        {
            int ret = 0;
            ClearEventOnMsgReved();

            ret = IPrimInit();
            if (ret != 0)
            {
                return ret;
            }

            var connRet = "";
            ret = IPrimConnect(ref connRet);
            if (ret != 0)
            {
                return ret;
            }

            ret = IPrimStart();
            if (ret != 0)
            {
                return ret;
            }

            return 0;
        }
        public int IPrimTaskPause()
        {
            return 0;
        }
        public int IPrimTaskReset()
        {
            if (IPrimReset() != 0) return -1;

            return 0;
        }
        public int IPrimTaskStop()
        {
            var unConnRet = "";
            if (IPrimDisConnect(ref unConnRet) != 0) return -2;

            if (IPrimStop() != 0) return -1;
            return 0;
        }
        public XmlNode IPrimExportConfigXml()
        {
            if (_config == null) return null;

            var node = ProxyTools.XMLHelper.ObjectToXML(_config);

            return node;
        }
        public int IPrimImportConfigXml(XmlNode xmlNode)
        {
            var iRet = 0;
            if (xmlNode != null)
                _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(ClientConfig)) as ClientConfig;
            else
                return -1;
            return iRet;
        }
        #endregion



        #region Overide ISktClient
        public event SktMsgRevedEventHandle OnMsgReved;
        public event SktMsgRevedByteEventHandle OnMsgRevedByte;
        public event LineEventHandle OnLine;

        public string Ip { get => _config.Ip; set => _config.Ip = value; }
        public string Port { get => _config.Port; set => _config.Port = value; }
        public string HeartInfo { set => _config.HeartInfo = value; get => _config.HeartInfo; }
        public int HeartInfoCycleTime { set => _config.HeartInfoCycleTime = value; get => _config.HeartInfoCycleTime; }
        public bool HeartFlag { set => _config.HeartFlag = value; get => _config.HeartFlag; }
        public int ReconnectCnt { get => _config.ReconnectCnt; set => _config.ReconnectCnt = value; }
        public SktNotifyMode NotifyMode { get => _config.NotifyMode; set => _config.NotifyMode = value; }
        public int SendQueueCnt { set => _config.SendQueueCnt = value; get => _config.SendQueueCnt; }
        //public int RevQueueCnt { set => _config.RevQueueCnt = value; get => _config.RevQueueCnt; }
        public string NetName { set => _config.NetName = value; get => _config.NetName; }
        public ConcurrentQueue<byte[]> QueueMsg { set; get; }
        public bool IsReceivingByte { set; get; }

        public int ClearEventOnMsgReved()
        {
            var iRet = -1;

            if (OnMsgReved != null)
            {
                foreach (var d in OnMsgReved.GetInvocationList())
                    OnMsgReved -= d as SktMsgRevedEventHandle;
            }
            if (OnMsgRevedByte != null)
            {
                foreach (var d in OnMsgRevedByte.GetInvocationList())
                {
                    OnMsgRevedByte -= d as SktMsgRevedByteEventHandle;
                }
            }
            if (OnLine != null)
            {
                foreach (var d in OnLine.GetInvocationList())
                {
                    OnLine -= d as LineEventHandle;
                }
            }

            return iRet;
        }
        public int SendInfo(string rev, object context)
        {
            try
            {
                lock (_sendQueueMutex)
                {
                    if (_config.ConnMode == SktConnMode.UDP)
                    {
                        _sendQueue.Enqueue(context);
                    }
                    else
                    {
                        byte[] msgBytes = GetBytes(context.ToString());

                        _tcpClient.GetStream().BeginWrite(msgBytes, 0, msgBytes.Length, (ar) =>
                        {
                            _tcpClient.GetStream().EndWrite(ar);
                        }, null);
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                LogAdd($"发送数据失败，异常信息 = {ex.Message}", LogLevel.Warn);
                return (int)SoftWareAlarm.SktClient_消息发送失败;
            }
        }
        public int SetHeartInfo(string heart, int cycleTime)
        {
            var iRet = 0;

            HeartInfo = heart;
            HeartInfoCycleTime = cycleTime;

            return iRet;
        }
        public int SetNotifyMode(SktNotifyMode mode)
        {
            var iRet = 0;
            NotifyMode = mode;
            return iRet;
        }
        public int SetSendQueueCnt(int cnt)
        {
            var iRet = 0;

            SendQueueCnt = cnt;

            return iRet;
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>发送</summary>
        private void CycleSend()
        {
            while (_taskFlag)
            {
                if (PrimConnStat == PrimConnState.UnConnected)
                    try
                    {
                        _socket.Connect(new DnsEndPoint(Ip, int.TryParse(Port, out var port) ? port : 1111));
                        break;
                    }
                    catch (Exception)
                    {
                        SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Err);
                        LogAdd(Name + ProxyTools.NLocalizer.GetString("PrimSktClient_PrimClient_CouldnotConnectToServer", " couldn't connect to server."), LogLevel.Error, 21);
                        Thread.Sleep(100);
                        continue;
                    }

                if (!_sendFlag)
                {
                    Thread.Sleep(2);
                    continue;
                }

                if (_sendQueue.Count < 1)
                {
                    Thread.Sleep(2);
                    continue;
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

                var sendStr = (string)sendObj;

                try
                {
                    var buffer = GetBytes(sendStr);
                    _socket.Send(buffer);
                }
                catch (Exception)
                {
                    SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Err);
                    LogAdd(Name + ProxyTools.NLocalizer.GetString("PrimSktClient_PrimClient_CouldnotConnectToServer", " couldn't connect to server."), LogLevel.Error, 21);
                }

                SpinWait.SpinUntil(() => !_sendFlag, 1);
            }
        }
        /// <summary>接收</summary>
        private void CycleRev()
        {
            while (_taskFlag)
            {
                if (!_revFlag)
                {
                    Thread.Sleep(2);
                    continue;
                }

                try
                {
                    var buffer = new byte[4096];

                    var n = _socket.Receive(buffer);

                    var revMsg = GetString(buffer, 0, n);

                    if (PrimDebug)
                    {
                        ((PrimConfigControl)PrimConfigUI).ShowRevMsg(revMsg);
                    }

                    if (NotifyMode == SktNotifyMode.DataEvent && OnMsgReved != null)
                    {
                        OnMsgReved("", revMsg);
                    }

                    if (NotifyMode == SktNotifyMode.DataQueue)
                    {
                        _revQueue.Enqueue(revMsg);
                    }
                }
                catch (Exception ex)
                {
                    SetRunState(PrimRunState.Err);
                    ((PrimConfigControl)PrimConfigUI).ShowRevMsg(ex.Message);
                }

                SpinWait.SpinUntil(() => !_revFlag, 1);
            }
        }
        /// <summary>心跳任务</summary>
        private void CycleHeart(CancellationToken token)
        {
            Stopwatch sw = new Stopwatch();
            while (true)
            {
                sw.Restart();
                if (token.IsCancellationRequested)
                {
                    return;
                }

                if (!_config.HeartFlag || string.IsNullOrEmpty(_config.HeartInfo))
                {
                    Thread.Sleep(100);
                    continue;
                }

                SendInfo("", _config.HeartInfo);

                SpinWait.SpinUntil(() => (sw.ElapsedMilliseconds >= _config.HeartInfoCycleTime) || token.IsCancellationRequested, int.MaxValue);
                sw.Stop();
            }
        }
        /// <summary>连接状态 && 运行状态设置</summary>
        /// <param name="Conn">连接状态</param>
        /// <param name="Run">运行状态</param>
        private void SetConn_RunState(PrimConnState Conn, PrimRunState Run)
        {
            PrimConnStat = Conn;
            PrimRunStat = Run;
            ((PrimConfigControl)PrimConfigUI).SetPrimConnState(Conn);
            ((PrimConfigControl)PrimConfigUI).SetPrimRunState(Run);
        }
        /// <summary>连接状态设置</summary>
        /// <param name="Conn">连接状态</param>
        private void SetConnState(PrimConnState Conn)
        {
            PrimConnStat = Conn;
            ((PrimConfigControl)PrimConfigUI).SetPrimConnState(Conn);
        }
        /// <summary>运行状态设置</summary>
        /// <param name="Run">运行状态</param>
        private void SetRunState(PrimRunState Run)
        {
            PrimRunStat = Run;
            ((PrimConfigControl)PrimConfigUI).SetPrimRunState(Run);
        }
        /// <summary>客户端连接回调</summary>
        /// <param name="ar">状态</param>
        private void RequestCallBack(IAsyncResult ar)
        {
            try
            {
                _tcpClient.EndConnect(ar);
                if (_retries > 0)
                {
                    OnLine?.Invoke(true);
                    LogAdd($"重连{_retries}次成功", LogLevel.Info);
                    _retries = 0;
                }
                _trying = false;
            }
            catch (Exception ex)
            {
                if (_retries > 0)
                {
                    LogAdd($"重连{_retries}次失败：" + ex.Message, LogLevel.Warn);
                }

                _retries++;

                if (_retries > _config.ReconnectCnt)
                {
                    _trying = false;
                    var msg = "";
                    IPrimDisConnect(ref msg);
                    SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Other);
                    return;
                }
                else
                {
                    try
                    {
                        _tcpClient?.Close();
                        _tcpClient = null;

                        Thread.Sleep(1000);
                        if (_tcpClient == null)
                        {
                            _tcpClient = new TcpClient();
                            _tcpClient.NoDelay = true;
                            _tcpClient.BeginConnect(_ip, _port, RequestCallBack, null);
                        }
                        Thread.Sleep(1000);
                    }
                    catch (Exception e)
                    {
                        _trying = false;
                        LogAdd($"重连{_retries}次发生严重报错：" + e.Message, LogLevel.Warn);
                    }

                    return;
                }
            }

            SetConn_RunState(PrimConnState.Connected, PrimRunState.Running);

            if (_heartTask == null && _config.HeartFlag)
            {
                ctsHeart = new CancellationTokenSource();
                _heartTask = new Task(() => CycleHeart(ctsHeart.Token));
                _heartTask.Start();
            }

            _tcpClient.GetStream().BeginRead(_revBuffer, 0, _revBuffer.Length, ReceiveCallBack, _revBuffer);
        }
        /// <summary>客户端接收回调</summary>
        /// <param name="ar">状态</param>
        private void ReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                if (_tcpClient == null || !_tcpClient.Connected)
                {
                    LogAdd($"手动断开连接", LogLevel.Info);
                    return;
                }

                var len = _tcpClient.GetStream().EndRead(ar);
                byte[] temp = new byte[len];
                if (len > 0)
                {
                    var revMsg = GetString(_revBuffer, 0, len);
                    Array.Copy(_revBuffer, temp, len);
                    _revBuffer = new byte[1024 * 1024];
                    if (IsReceivingByte)
                    {
                        if (QueueMsg == null) QueueMsg = new ConcurrentQueue<byte[]>();
                        QueueMsg.Enqueue(temp);
                    }
                    if (NotifyMode == SktNotifyMode.DataEvent)
                    {
                        OnMsgReved?.BeginInvoke("", revMsg, null, null);
                        OnMsgRevedByte?.BeginInvoke(temp, null, null);
                    }
                    else if (NotifyMode == SktNotifyMode.DataQueue)
                    {
                        _revQueue.Enqueue(revMsg);
                    }
                    _tcpClient.GetStream().BeginRead(_revBuffer, 0, _revBuffer.Length, ReceiveCallBack, null);
                    if (PrimDebug)
                    {
                        ((PrimConfigControl)PrimConfigUI).ShowRevMsg(revMsg);
                    }
                }
                else
                {
                    throw new Exception("启动断线重连");
                }
            }
            catch (Exception e)
            {
                OnLine?.Invoke(false);
                LogAdd($"{e.Message}", LogLevel.Warn);
                var msg = "";
                IPrimDisConnect(ref msg);
                IPrimInit();
            }
        }
        /// <summary>string→byte[]（默认UTF8）</summary>
        /// <param name="msg">string</param>
        /// <returns>byte[]</returns>
        private byte[] GetBytes(string msg)
        {
            switch (TransEncodingType)
            {
                case EncodingType.UTF8:
                    return Encoding.UTF8.GetBytes(msg);
                case EncodingType.ASCII:
                    return Encoding.ASCII.GetBytes(msg);
                case EncodingType.Unicode:
                    return Encoding.Unicode.GetBytes(msg);
                case EncodingType.GB2312:
                    return GlobalVariables.EncodingChinese.GetBytes(msg);
                case EncodingType.HEX:
                return msg.ToHexBytes(" ");
                default:
                    return Encoding.UTF8.GetBytes(msg);
            }
        }
        /// <summary>byte[]→string（默认UTF8）</summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns>string</returns>
        private string GetString(byte[] bytes, int index, int count)
        {
            switch (TransEncodingType)
            {
                case EncodingType.UTF8:
                    return Encoding.UTF8.GetString(bytes, index, count);
                case EncodingType.ASCII:
                    return Encoding.ASCII.GetString(bytes, index, count);
                case EncodingType.Unicode:
                    return Encoding.Unicode.GetString(bytes, index, count);
                case EncodingType.GB2312:
                    return GlobalVariables.EncodingChinese.GetString(bytes, index, count);
                case EncodingType.HEX:
                    byte[] temp = new byte[count];
                    Array.Copy(bytes, index, temp, 0, count);
                    return temp.ToHexString(" ");
                default:
                    return Encoding.UTF8.GetString(bytes, index, count);
            }
        }
        /// <summary>基元复位</summary>
        /// <returns>int</returns>
        public int IPrimReset()
        {
            var iRet = 0;

            if (PrimRunStat == PrimRunState.Err)
            {
                iRet = IPrimTaskInit();
            }

            return iRet;
        }
        /// <summary>客户端断开连接</summary>
        /// <param name="result"></param>
        /// <returns>int</returns>
        public int IPrimDisConnect(ref string result)
        {
            try
            {
                _revFlag = false;
                _sendFlag = false;
                _taskFlag = false;
                if (ctsHeart != null)
                {
                    ctsHeart.Cancel();
                }

                if (_sendTask != null)
                    _sendTask = null;

                if (_revTask != null)
                    _revTask = null;

                if (_heartTask != null)
                {
                    try
                    {
                        if (_heartTask.Wait(100))
                        {
                            _heartTask = null;
                            LogAdd($"心跳任务停止成功", LogLevel.Info);
                        }
                        else
                        {
                            LogAdd($"心跳任务未在100ms内停止成功", LogLevel.Warn);
                        }
                    }
                    catch (Exception ex)
                    {
                        LogAdd($"心跳任务停止失败：{ex.Message}", LogLevel.Warn);
                        _heartTask = null;
                    }
                    ctsHeart = null;
                }

                DisConnectTcp();

                if (_socket != null)
                {
                    _socket.Close();
                    Thread.Sleep(200);
                    _socket = null;
                }

                SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Stop);
                return 0;
            }
            catch (Exception ex)
            {
                LogAdd($"客户端IPrimDisConnect失败：{ex.Message}", LogLevel.Warn);
                return (int)SoftWareAlarm.SktClient_客户端断开连接失败;
            }
        }
        /// <summary>客户端断开</summary>
        private void DisConnectTcp()
        {
            _retries = 0;
            if (_tcpClient != null && _tcpClient.Client.Connected)
            {
                _tcpClient.Close();
            }

            _tcpClient = null;
        }
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

            msg = $"{ Name} -> " + msg;
            string tempId = $"{(int)lv}{(int)PrimLogId.PrimSktClient}0000";

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
        #endregion
    }

}