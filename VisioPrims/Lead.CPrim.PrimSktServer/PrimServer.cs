///************************************************************************
///************************************************************************
///************************************************************************
///基元已测试项目：
///1、与调试助手进行通讯测试
///2、与视觉平台进行通讯测试
///************************************************************************
///************************************************************************
///************************************************************************


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.PrimSktServer
{
    public class PrimServer : IPrim, ISktServer
    {
        #region Define_DEL
        public delegate void UpdateUIDel();
        #endregion



        #region Define_Event
        public event UpdateUIDel UpdateUIEvent;
        //public event PrimDataRefresh OnPrimDataRefresh;
        //public event PrimOpLog OnPrimOpLog;
        //public event PrimStateChanged OnPrimStateChanged; 
        public event SktMsgRevedEventHandle OnMsgReved;
        #endregion



        #region Private Feilds
        /// <summary>服务器配置管理器</summary>
        public ServerConfig _config;

        //Socket相关
        /// <summary>客户端</summary>
        private Socket _socketListen;
        /// <summary>ip</summary>
        private IPAddress _ip;
        /// <summary>端号</summary>
        private IPEndPoint _port;

        //线程
        private Thread _sendThread;
        private Thread _listenThread;

        //辅助变量
        /// <summary>发送队列</summary>
        private Queue<ServerMsgInfo> _sendQueue;
        /// <summary>发送锁</summary>
        private readonly object _sendQueueMutex = new object();
        private bool _sendFlag;
        /// <summary>接收队列</summary>
        private Queue<ServerMsgInfo> _revQueue;
        /// <summary>接收锁/summary>
        private readonly object _revQueueMutex = new object();
        /// <summary>接入Socket管理/summary>
        private readonly Dictionary<string, Socket> _dicPointSocket = new Dictionary<string, Socket>();
        /// <summary>接入Socket更新UI/summary>
        public List<string> _listName = new List<string>();
        /// <summary>接入Socket接收线程管理</summary>
        private readonly Dictionary<string, Thread> _dicPointThread = new Dictionary<string, Thread>();
        private readonly List<Thread> _listRevThread = new List<Thread>();
        /// <summary>连接标志</summary>
        private bool isConnected = false;
        /// <summary>心跳</summary>
        public System.Threading.Timer timeHeart;
        #endregion



        #region Prop
        /// <summary>测试模式</summary>
        public bool PrimDebug
        {
            get => _config.PrimDebug;

            set => _config.PrimDebug = value;
        }

        public LogLevel PrimAlarmLv { get; set; }

        public RunMode PrimRunMode { get; set; }

        public Control PrimDebugUI { get; }

        public bool LogEnable
        {
            get => _config.LogEnable;

            set => _config.LogEnable = value;
        }
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public PrimServer()
        {
            _config = new ServerConfig();
            PrimDebugUI = new PrimDebugControl();
            PrimConfigUI = new PrimConfigControl(this);
            PrimOutputUI = new PrimOutputControl();

            PrimConnStat = PrimConnState.Other;
            PrimRunStat = PrimRunState.Other;

            if (((PrimConfigControl)PrimConfigUI).Created && ((PrimConfigControl)PrimConfigUI).IsHandleCreated)
            {
                ((PrimConfigControl)PrimConfigUI).SetPrimConnState(PrimConnStat);
                ((PrimConfigControl)PrimConfigUI).SetPrimRunState(PrimRunStat);
            }
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="xmlNode">node</param>
        public PrimServer(XmlNode xmlNode)
        {
            if (xmlNode != null)
                _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(ServerConfig)) as ServerConfig;
            else
                return;

            PrimDebugUI = new PrimDebugControl();
            PrimConfigUI = new PrimConfigControl(this);
            PrimOutputUI = new PrimOutputControl();

            PrimConnStat = PrimConnState.Other;
            PrimRunStat = PrimRunState.Other;
            if (((PrimConfigControl)PrimConfigUI).Created && ((PrimConfigControl)PrimConfigUI).IsHandleCreated)
            {
                ((PrimConfigControl)PrimConfigUI).SetPrimConnState(PrimConnStat);
                ((PrimConfigControl)PrimConfigUI).SetPrimRunState(PrimRunStat);
            }
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
            get => _config.Name;

            set => _config.Name = value;
        }
        public bool PrimEnable
        {
            get => _config.PrimEnable;

            set => _config.PrimEnable = value;
        }
        public PrimType HSType
        {
            get => _config.HSType;

            set => _config.HSType = value;
        }
        public string PrimTypeName
        {
            get => _config.PrimTypeName;

            set => _config.PrimTypeName = value;
        }
        public Control PrimConfigUI { get; }
        public Control PrimOutputUI { get; }
        public PrimConnState PrimConnStat
        {
            get => _config.PrimConnStat;

            set => _config.PrimConnStat = value;
        }
        public PrimRunState PrimRunStat
        {
            get => _config.PrimRunStat;

            set => _config.PrimRunStat = value;
        }
        public PrimVer Ver
        {
            get => _config.Ver;

            set => _config.Ver = value;
        }
        public int CurrentImageIndex { get; set; }


        public int IPrimInit()
        {
            var iRet = -1;
            try
            {
                if (PrimRunStat == PrimRunState.Running || PrimConnStat == PrimConnState.Connected) return 0;

                if (string.IsNullOrEmpty(_config.BindIp)) return -1;

                _ip = IPAddress.Parse(_config.BindIp);

                if (string.IsNullOrEmpty(_config.Port)) return -1;
                _port = new IPEndPoint(_ip, int.Parse(_config.Port));

                if (SendQueueCnt <= 0)
                    _sendQueue = new Queue<ServerMsgInfo>();
                else
                    _sendQueue = new Queue<ServerMsgInfo>(SendQueueCnt);


                if (_config.NotifyMode == SktNotifyMode.DataQueue)
                {
                    if (RevQueueCnt <= 0)
                        _revQueue = new Queue<ServerMsgInfo>();
                    else
                        _revQueue = new Queue<ServerMsgInfo>(RevQueueCnt);
                }

                if (_socketListen == null)
                    _socketListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                timeHeart = new System.Threading.Timer(Heart, null, Timeout.Infinite, Timeout.Infinite);
                PrimRunStat = PrimRunState.Stop;
                PrimConnStat = PrimConnState.UnConnected;

                if (((PrimConfigControl)PrimConfigUI).Created && ((PrimConfigControl)PrimConfigUI).IsHandleCreated)
                {
                    ((PrimConfigControl)PrimConfigUI).SetPrimConnState(PrimConnStat);
                    ((PrimConfigControl)PrimConfigUI).SetPrimRunState(PrimRunStat);
                }
                iRet = 0;
            }
            catch
            {
            }
            return iRet;
        }
        public int IPrimConnect(ref string result)
        {
            var iRet = 0;
            if (PrimConnStat == PrimConnState.Connected)
            {
                result = Name + ProxyTools.NLocalizer.GetString("PrimSktServer_PrimServer_Connect", "Connected");
                return 0;
            }

            //socket监听哪个端口
            _socketListen.Bind(_port);

            //同一个时间点过来10个客户端，排队
            _socketListen.Listen(10);

            PrimConnStat = PrimConnState.Connected;
            if (((PrimConfigControl)PrimConfigUI).Created && ((PrimConfigControl)PrimConfigUI).IsHandleCreated)
            {
                ((PrimConfigControl)PrimConfigUI).ShowRevMsg(ProxyTools.NLocalizer.GetString("PrimSktServer_PrimServer_ServerStartListening", "Server starts listening."));
                ((PrimConfigControl)PrimConfigUI).SetPrimConnState(PrimConnStat);
                ((PrimConfigControl)PrimConfigUI).SetPrimRunState(PrimRunStat);
            }
            return iRet;
        }
        public int IPrimStart()
        {
            var iRet = 0;

            if (PrimRunStat == PrimRunState.Running && PrimConnStat == PrimConnState.Connected) return 0;

            if (PrimConnStat != PrimConnState.Connected) return -1;

            isConnected = true;
            _sendFlag = true;

            _sendThread = new Thread(() => CycleSend());
            _sendThread.IsBackground = false;
            _sendThread.Start();

            _listenThread = new Thread(() => CycleListen());
            _listenThread.IsBackground = false;
            _listenThread.Start();

            //if (_sendTask == null || _sendTask.IsCompleted)
            //{
            //    _sendTask = new Task(() => CycleSend());
            //    _sendFlag = true;
            //    _sendTask.Start();
            //}

            //if (_listenTask == null || _listenTask.IsCompleted)
            //{
            //    _listenTask = new Task(() => CycleListen());
            //    _listenTask.Start();
            //}

            PrimConnStat = PrimConnState.Connected;
            PrimRunStat = PrimRunState.Running;
            if (((PrimConfigControl)PrimConfigUI).Created && ((PrimConfigControl)PrimConfigUI).IsHandleCreated)
            {
                ((PrimConfigControl)PrimConfigUI).SetPrimConnState(PrimConnStat);
                ((PrimConfigControl)PrimConfigUI).SetPrimRunState(PrimRunStat);
            }
            Thread.Sleep(5);
            Heart();
            return iRet;
        }
        public int IPrimStop()
        {
            int ret = -1;
            try
            {
                isConnected = false;
                if (timeHeart != null)
                {
                    timeHeart.Change(Timeout.Infinite, Timeout.Infinite);
                }

                if (_socketListen != null)
                {
                    _socketListen.Close();
                    _socketListen.Dispose();
                    _socketListen = null;
                }
                foreach (var item in _dicPointThread)
                {
                    if (item.Value != null)
                    {
                        item.Value.Abort();
                    }
                }
                _dicPointThread.Clear();
                foreach (var item in _dicPointSocket)
                {
                    if (item.Value != null)
                    {
                        item.Value.Close();
                        item.Value.Dispose();
                    }
                }
                _dicPointSocket.Clear();
                PrimConnStat = PrimConnState.UnConnected;
                PrimRunStat = PrimRunState.Other;
                _listName.Clear();
                if (((PrimConfigControl)PrimConfigUI).Created && ((PrimConfigControl)PrimConfigUI).IsHandleCreated)
                {
                    ((PrimConfigControl)PrimConfigUI).SetPrimConnState(PrimConnStat);
                    ((PrimConfigControl)PrimConfigUI).SetPrimRunState(PrimRunStat);
                    UpdateUIEvent?.Invoke();
                }
                ret = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return ret;
        }
        public int IPrimDispose()
        {
            return 0;
        }
        public int IPrimTaskInit()
        {
            if (PrimRunStat == PrimRunState.Running)
            {
                return 0;
            }
            else
            {
                if (IPrimInit() != 0) return -1;
                var connRet = "";
                if (IPrimConnect(ref connRet) != 0) return -2;

                if (IPrimStart() != 0) return -3;
                return 0;
            }
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
            if (IPrimStop() != 0) return -1;
            return 0;
        }
        public XmlNode IPrimExportConfigXml()
        {
            //config turn to xmlNode
            if (_config == null) return null;

            var node = ProxyTools.XMLHelper.ObjectToXML(_config);

            return node;
        }
        public int IPrimImportConfigXml(XmlNode xmlNode)
        {
            var iRet = 0;
            if (xmlNode != null)
                _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(ServerConfig)) as ServerConfig;
            else
                return -1;
            return iRet;
        }
        #endregion



        #region Overide ISkt Property
        public string BindIp
        {
            get => _config.BindIp;

            set => _config.BindIp = value;
        }
        public string Port
        {
            get => _config.Port;

            set => _config.Port = value;
        }
        public string HeartInfo
        {
            set => _config.HeartInfo = value;
            get => _config.HeartInfo;
        }
        public bool HeartFlag
        {
            set => _config.HeartFlag = value;
            get => _config.HeartFlag;
        }
        public SktNotifyMode NotifyMode
        {
            get => _config.NotifyMode;
            set => _config.NotifyMode = value;
        }
        public SktConnMode ConnMode
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
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
        public bool HasClients => _listName.IsValid();


        public int ClearEventOnMsgReved()
        {
            if (OnMsgReved == null) return 1;
            foreach (var d in OnMsgReved.GetInvocationList()) OnMsgReved -= d as SktMsgRevedEventHandle;
            return 0;
        }
        public int RegNotifyInfo(string regInfo)
        {
            throw new NotImplementedException();
        }
        public int SendInfoByNetName(string revNetName, object context)
        {
            var iRet = 0;
            lock (_sendQueueMutex)
            {
                var msg = new ServerMsgInfo();
                msg.NetName = revNetName;
                msg.Context = context;
                _sendQueue.Enqueue(msg);
            }
            return iRet;
        }
        public int SendInfoByPoint(string revPoint, object context)
        {
            var iRet = 0;
            lock (_sendQueueMutex)
            {
                var msg = new ServerMsgInfo();
                msg.Point = revPoint;
                msg.Context = context;
                _sendQueue.Enqueue(msg);
            }
            return iRet;
        }
        public int SetFilterInfo(string filterInfo)
        {
            throw new NotImplementedException();
        }
        public int SetHeartInfo(string heart)
        {
            var iRet = 0;
            HeartInfo = heart;
            return iRet;
        }
        public int SetNetName(string name)
        {
            var iRet = 0;
            NetName = name;
            return iRet;
        }
        public int SetNotifyMode(SktNotifyMode mode, int cnt)
        {
            var iRet = 0;
            NotifyMode = mode;
            RevQueueCnt = cnt;
            return iRet;
        }
        public int SetSendQueueCnt(int cnt)
        {
            var iRet = 0;
            SendQueueCnt = cnt;
            return iRet;
        }
        public List<string> GetClientsInfo()
        {
            return _listName.Where(x => !x.IsNullOrEmpty()).ToList();
        }
        #endregion



        #region Others
        /// <summary>消息发送</summary>
        private void CycleSend()
        {
            while (isConnected)
            {
                if (PrimConnStat == PrimConnState.UnConnected)
                {
                    Thread.Sleep(10);
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

                ServerMsgInfo sendMsgInfo = null;

                lock (_sendQueueMutex)
                {
                    sendMsgInfo = _sendQueue.Dequeue();
                }

                if (sendMsgInfo == null)
                {
                    Thread.Sleep(2);
                    continue;
                }

                try
                {
                    if (_dicPointSocket.ContainsKey(sendMsgInfo.Point))
                    {
                        var sendSocket = _dicPointSocket[sendMsgInfo.Point];
                        var buffer = Encoding.UTF8.GetBytes((string)sendMsgInfo.Context);
                        sendSocket.Send(buffer);
                    }
                    else if (sendMsgInfo.Point == "")
                    {
                        foreach (var item in _dicPointSocket)
                        {
                            var sendSocket = item.Value;
                            var buffer = Encoding.UTF8.GetBytes((string)sendMsgInfo.Context);
                            sendSocket.Send(buffer);
                        }
                    }
                }
                catch (Exception)
                {
                    PrimConnStat = PrimConnState.UnConnected;
                }
                Application.DoEvents();
                Thread.Sleep(2);
            }
        }
        /// <summary>接收函数</summary>
        /// <param name="socket"></param>
        private void CycleRev(object socket)
        {
            while (isConnected)
            {
                var revSocket = socket as Socket;
                var point = revSocket.RemoteEndPoint.ToString();
                try
                {
                    //定义byte数组存放从客户端接收过来的数据
                    var buffer = new byte[2048];
                    //将接收过来的数据放到buffer中，并返回实际接受数据的长度
                    var n = revSocket.Receive(buffer);
                    //将字节转换成字符串
                    var words = Encoding.UTF8.GetString(buffer, 0, n);
                    if (n == 0)
                    {
                        if (_dicPointSocket.ContainsKey(point))
                        {
                            _dicPointSocket.Remove(point);
                        }
                        if (_dicPointThread.ContainsKey(point))
                        {
                            _dicPointThread.Remove(point);
                        }
                        if (_listName.Contains(point))
                        {
                            _listName.Remove(point);
                            if (((PrimConfigControl)PrimConfigUI).Created && ((PrimConfigControl)PrimConfigUI).IsHandleCreated)
                            {
                                UpdateUIEvent?.Invoke();
                            }
                        }
                        revSocket?.Disconnect(false);
                        revSocket?.Dispose();
                        revSocket = null;
                        break;
                    }
                    ServerMsgInfo msg = null;
                    if (_dicPointSocket.ContainsKey(point))
                    {
                        msg = new ServerMsgInfo();
                        msg.Point = point;
                        msg.Context = words;
                    }
                    if (msg == null) continue;
                    if (PrimDebug)
                    {
                        if (((PrimConfigControl)PrimConfigUI).Created && ((PrimConfigControl)PrimConfigUI).IsHandleCreated)
                        {
                            ((PrimConfigControl)PrimConfigUI).ShowRevMsg(msg.Point + " - " + msg.NetName + ":" + msg.Context);
                        }
                    }
                    if (NotifyMode == SktNotifyMode.DataEvent && OnMsgReved != null) OnMsgReved(msg.Point, msg.Context);
                    if (NotifyMode == SktNotifyMode.DataQueue)
                    {
                        lock (_revQueueMutex)
                        {
                            _revQueue.Enqueue(msg);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    if (_dicPointSocket.ContainsKey(point))
                    {
                        _dicPointSocket.Remove(point);
                    }
                    if (_dicPointThread.ContainsKey(point))
                    {
                        _dicPointThread.Remove(point);
                    }
                    if (_listName.Contains(point))
                    {
                        _listName.Remove(point);
                        if (((PrimConfigControl)PrimConfigUI).Created && ((PrimConfigControl)PrimConfigUI).IsHandleCreated)
                        {
                            UpdateUIEvent?.Invoke();
                        }
                    }
                    if (revSocket != null)
                    {
                        if(revSocket.Connected == false )
                        {
                            revSocket = null;
                        }
                        else
                        {
                            revSocket?.Disconnect(false);
                            revSocket?.Dispose();
                        }
                    }
                    break;
                }
                Thread.Sleep(2);
            }
        }
        /// <summary>监听线程</summary>
        private void CycleListen()
        {
            while (isConnected)
            {
                try
                {
                    //创建通信用的Socket
                    var tSocket = _socketListen.Accept();
                    var point = tSocket.RemoteEndPoint.ToString();
                    if (_dicPointSocket.ContainsKey(point))
                    {
                        _dicPointSocket.Remove(point);
                    }
                    if (_dicPointThread.ContainsKey(point))
                    {
                        _dicPointThread.Remove(point);
                    }

                    var revThreas = new Thread(CycleRev);
                    revThreas.IsBackground = false;
                    revThreas.Start(tSocket);

                    _dicPointSocket.Add(point, tSocket);
                    _dicPointThread.Add(point, revThreas);
                    _listName.Add(point);

                    if (((PrimConfigControl)PrimConfigUI).Created && ((PrimConfigControl)PrimConfigUI).IsHandleCreated)
                    {
                        UpdateUIEvent?.Invoke();
                    }
                }
                catch
                {
                    
                }
            }
        }
        /// <summary>心跳函数</summary>
        /// <param name="value"></param>
        private void Heart(object value)
        {
            if (HeartFlag)
            {
                lock (_sendQueueMutex)
                {
                    SendInfoByPoint("", _config.HeartInfo);
                }
            }
        }
        public void Heart()
        {
            if (PrimRunStat != PrimRunState.Running)
            {
                return;
            }
            if (HeartFlag)
            {
                timeHeart.Change(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
            }
            else
            {
                timeHeart.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }

        public int IPrimReset()
        {
            var iRet = 0;
            return iRet;
        }
        public int IPrimDisConnect(ref string result)
        {
            result = "";
            return 0;
        }

        public int IPrimResume()
        {
            return 0;
        }

        public XmlNode IPrimExportDataConfigXml()
        {
            return null;
        }

        public int IPrimSuspend()
        {
            throw new NotImplementedException();
        }
        /// <summary>日志</summary>
        /// <param name="log">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        private void LogAdd(string log, LogLevel lv, long id)
        {
            if (!LogEnable) return;

            string tempId = $"{(int)lv}{(int)PrimLogId.PrimSktServer}0000";

            if (long.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            ProxyTools.LogHelper.LogAdd(lv, log, Name, LogClassification.VisioPrim, id);
        }
        #endregion
    }
}