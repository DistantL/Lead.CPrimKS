/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: PrimVarManager.cs
 * Author: Victor
 * Description: PrimVarManager基元核心类
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 *
 * 3.3.22.0712 -> 
 * <Author>     <Time>
 *  Victor     20220718
 * 1、MongoDB增加数据连接状态判断，解决软件卡死
 * * <Author>     <Time>
 *  Victor     20220725
 * 1、MongoDB连接增加3s连接超时
******************************************************************************/

using Lead.CPrim.Interfaces;
using Lead.CPrim.PrimVarManager.Controls;
using Lead.CPrim.ProxyTools;
using MongoDB.Driver;
using MongoDB.Driver.Core.Clusters;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Messaging;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.PrimVarManager
{
    /// <summary>通讯基元管理器</summary>
    public class VarManager : IPrim, IVarManager
    {
        #region Define_Event
        //public event PrimDataRefresh OnPrimDataRefresh;
        //public event PrimStateChanged OnPrimStateChanged;
        //public event PrimOpLog OnPrimOpLog;
        #endregion



        #region Field
        /// <summary>通讯基元配置管理器</summary>
        private VarManagerConfig _config;
        /// <summary>值读取Task</summary>
        private Task<int> _valsChangedTask;
        /// <summary>CancellationTokenSource</summary>
        private CancellationTokenSource _cancellationTokenSource;
        /// <summary>连接字符串</summary>
        private string _connStr = "mongodb://localhost:27017";
        /// <summary>数据库字符串</summary>
        private string _databaseName = "Lead";
        /// <summary>初始化错误标志</summary>
        private bool _initedError;
        /// <summary>客户端</summary>
        public MongoClient _client;
        /// <summary>数据库</summary>
        public IMongoDatabase _database;
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public VarManager()
        {
            _config = new VarManagerConfig();

            PrimDebugUI = new DebugUiControl();
            PrimConfigUI = new ConfigUiControl(this);
            PrimOutputUI = new OutputUiControl();

            if (Vals == null)
            {
                Vals = new ConcurrentDictionary<string, RemoteVar>();
            }

            SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Other);
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="xmlNode">node</param>
        public VarManager(XmlNode xmlNode)
        {
            if (xmlNode == null)
            {
                return;
            }

            _config = XMLHelper.XMLToObject(xmlNode, typeof(VarManagerConfig)) as VarManagerConfig;

            PrimDebugUI = new DebugUiControl();
            PrimConfigUI = new ConfigUiControl(this);
            PrimOutputUI = new OutputUiControl();

            ImportValsFromFile();
            if (Vals == null)
            {
                Vals = new ConcurrentDictionary<string, RemoteVar>();
            }

            SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Other);
        }
        #endregion



        #region Prop
        /// <summary>信息交换循环扫描集合</summary>
        public ConcurrentDictionary<string, RemoteVar> Vals { get; set; } = new ConcurrentDictionary<string, RemoteVar>();
        /// <summary>信息交换队列集合</summary>
        public ConcurrentDictionary<string, MessageQueue> QueueVars { set; get; } = new ConcurrentDictionary<string, MessageQueue>();
        /// <summary>基元路径</summary>
        public string ValsSavePath
        {
            get => _config.ValsSavePath;
            set => _config.ValsSavePath = value;
        }
        /// <summary>主站PC名称</summary>
        public string ServerPCName
        {
            get => _config.ServerPCName;
            set => _config.ServerPCName = value;
        }
        /// <summary>主站IP地址</summary>
        public string ServerIp
        {
            get => _config.ServerIp;
            set => _config.ServerIp = value;
        }
        /// <summary>主站名称</summary>
        public string ServerName
        {
            get => _config.ServerName;
            set => _config.ServerName = value;
        }
        /// <summary>循环扫描使能</summary>
        public bool CycleEnable
        {
            get => _config.CycleEnable;
            set => _config.CycleEnable = value;
        }
        /// <summary>循环扫描时间</summary>
        public int CycleTime
        {
            get => _config.CycleTime;
            set => _config.CycleTime = value;
        }
        /// <summary>信息交换类型</summary>
        public VarManagerType VarsType
        {
            get => _config.VarsType;
            set => _config.VarsType = value;
        }
        /// <summary>是否开启日志</summary>
        public bool LogEnable
        {
            get => _config.LogEnable;
            set => _config.LogEnable = value;
        }

        public bool PrimDebug
        {
            get => _config.PrimDebug;
            set => _config.PrimDebug = value;
        }

        public LogLevel PrimAlarmLv
        {
            get => _config.PrimAlarmLv;
            set => _config.PrimAlarmLv = value;
        }

        public RunMode PrimRunMode
        {
            get => _config.PrimRunMode;
            set => _config.PrimRunMode = value;
        }

        public Control PrimDebugUI { get; }
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
        public Control PrimConfigUI { get; set; }
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
            try
            {

                var iRet = 0;

                if (PrimRunStat == PrimRunState.Running) return iRet;

                InitDb();
                foreach (var val in Vals)
                {
                    AddVar(val.Value);
                }
                SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Stop);

                return iRet;
            }
            catch (Exception e)
            {
                LogAdd("初始化失败：" + e.Message, LogLevel.Warn);
                return (int)SoftWareAlarm.PrimVarManager_基元初始化失败;
            }
        }
        public int IPrimConnect(ref string result)
        {
            var iRet = 0;
            if (PrimConnStat == PrimConnState.Connected) return iRet;

            SetConnState(PrimConnState.Connected);

            return iRet;
        }
        public int IPrimStart()
        {
            try
            {
                var iRet = 0;
                if (PrimRunStat == PrimRunState.Running) return iRet;

                if (Vals.Count > 0)
                {
                    foreach (var val in Vals)
                    {
                        var obj = Read(val.Key);
                        if (val.Value.ReadMode == DataReadMode.Cycle)
                        {
                            ((ConfigUiControl)PrimConfigUI).UpdateVariableValue(val.Key, obj);
                        }
                        if (val.Value.ReadMode == DataReadMode.Queue)
                        {
                            var count = QueueCount(val.Key);
                            ((ConfigUiControl)PrimConfigUI).UpdateVariableValue(val.Key, count);
                        }
                        val.Value.IsChanged = false;
                    }

                    if (_cancellationTokenSource == null) _cancellationTokenSource = new CancellationTokenSource();
                    if (_valsChangedTask == null)
                    {
                        _valsChangedTask = new Task<int>(() => ReadVars(_cancellationTokenSource.Token),
                            _cancellationTokenSource.Token);
                        _valsChangedTask.Start();
                    }
                }

                SetRunState(PrimRunState.Running);
                return 0;
            }
            catch (Exception ex)
            {
                LogAdd("运行失败：" + ex.Message, LogLevel.Warn);
                return (int)SoftWareAlarm.PrimVarManager_基元运行失败;
            }
        }
        public int IPrimStop()
        {
            if (PrimRunStat == PrimRunState.Running)
            {
                _cancellationTokenSource?.Cancel();
                try
                {
                    _valsChangedTask?.Wait(50);
                }
                catch (Exception ex)
                {
                    _cancellationTokenSource.Dispose();
                    LogAdd("停止失败：" + ex.Message, LogLevel.Warn);
                    return (int)SoftWareAlarm.PrimVarManager_基元停止失败;
                }
            }
            _cancellationTokenSource = null;
            _valsChangedTask = null;
            _client = null;
            SetRunState(PrimRunState.Stop);
            return 0;
        }
        public int IPrimDispose()
        {
            try
            {
                IPrimStop();
                PrimConfigUI?.Dispose();
                PrimDebugUI?.Dispose();
                PrimOutputUI?.Dispose();
                var disResult = "";
                IPrimDisConnect(ref disResult);
                _valsChangedTask = null;
                _cancellationTokenSource = null;
                return 0;
            }
            catch (Exception ex)
            {
                LogAdd("基元释放失败：" + ex.Message, LogLevel.Warn);
                return (int)SoftWareAlarm.PrimVarManager_基元释放失败;
            }
        }
        public int IPrimTaskInit()
        {
            ClearEventOnMsgReved();
            int iRet = IPrimInit();
            if (iRet != 0)
            {
                return iRet;
            }

            var connRet = "";
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
            if (IPrimReset() != 0)
            {
                return -1;
            }

            return 0;
        }
        public int IPrimTaskStop()
        {
            var unConnRet = "";
            int iRet = IPrimDisConnect(ref unConnRet);
            if (iRet != 0)
            {
                return iRet;
            }

            iRet = IPrimStop();
            if (iRet != 0)
            {
                return iRet;
            }

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
            if (xmlNode != null)
            {
                _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(VarManagerConfig)) as VarManagerConfig;
            }
            else
            {
                return -1;
            }

            return iRet;
        }
        #endregion



        #region Override IVarManager
        public event RemoteQueueVariableChanged OnQueueVariableChanged;
        public event RemoteVariableChanged OnVariableChanged;


        public object Read(string varName)
        {
            if (!Vals.ContainsKey(varName))
            {
                return null;
            }

            if (Vals[varName].ReadMode == DataReadMode.Queue)
            {
                return null;
            }

            if (QueryOne<Var>("Name", varName, out var varObj) == 0)
            {
                if (Vals[varName].ReadMode == DataReadMode.Cycle)
                {
                    Vals[varName].LastValue = Vals[varName].CurrentValue;
                    switch (Vals[varName].DataType)
                    {
                        case DataType.BOOL:
                            Vals[varName].CurrentValue = bool.TryParse(varObj.Value, out var boolValue) && boolValue;
                            if (Convert.ToBoolean(Vals[varName].CurrentValue) != Convert.ToBoolean(Vals[varName].LastValue))
                            {
                                Vals[varName].IsChanged = true;
                            }
                            return Vals[varName].CurrentValue;
                        case DataType.DOUBLE:
                            Vals[varName].CurrentValue = double.TryParse(varObj.Value, out var doubleValue) ? doubleValue : 0.0;
                            if (Math.Abs(Convert.ToDouble(Vals[varName].CurrentValue) - Convert.ToDouble(Vals[varName].LastValue)) > 0.0001)
                            {
                                Vals[varName].IsChanged = true;
                            }
                            return Vals[varName].CurrentValue;
                        case DataType.STRING:
                            Vals[varName].CurrentValue = varObj.Value;
                            if (Convert.ToString(Vals[varName].CurrentValue) != Convert.ToString(Vals[varName].LastValue))
                            {
                                Vals[varName].IsChanged = true;
                            }
                            return Vals[varName].CurrentValue;
                        case DataType.INT:
                            Vals[varName].CurrentValue = int.TryParse(varObj.Value, out var intValue) ? intValue : 0;
                            if (Convert.ToInt32(Vals[varName].CurrentValue) != Convert.ToInt32(Vals[varName].LastValue))
                            {
                                Vals[varName].IsChanged = true;
                            }
                            return Vals[varName].CurrentValue;
                        case DataType.CLASS:
                        case DataType.Other:
                            var obj = JsonHelper.DeserializeJsonToObject(varObj.Value);
                            Vals[varName].CurrentValue = obj;
                            return obj;
                        default:
                            return null;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }
        public T ReadMultiVar<T>(string varName) where T : class
        {
            if (!Vals.ContainsKey(varName))
            {
                return null;
            }

            if (!Vals.ContainsKey(varName) || (Vals[varName].DataType != DataType.Other && Vals[varName].DataType != DataType.CLASS))
            {
                return null;
            }

            if (QueryOne<Var>("Name", varName, out var varObj) == 0)
            {
                var obj = JsonHelper.DeserializeJsonToObject<T>(varObj.Value);
                if (Vals[varName].ReadMode == DataReadMode.Cycle)
                {
                    Vals[varName].LastValue = Vals[varName].CurrentValue;
                    Vals[varName].CurrentValue = obj;
                }
                return obj;
            }
            else
            {
                return default;
            }

        }
        public int Write(string varName, object value)
        {
            if (!Vals.ContainsKey(varName))
            {
                return (int)SoftWareAlarm.PrimVarManager_查找键不存在;
            }

            if (Vals[varName].DataType != DataType.Other && Vals[varName].DataType != DataType.CLASS)
            {
                return ReplaceOne("Name", varName, new Var(varName, value != null ? value.ToString() : ""));
            }
            else
            {
                var newValue = JsonHelper.SerializeObject(value);
                return ReplaceOne("Name", varName, new Var(varName, newValue != null ? newValue.ToString() : ""));
            }
        }
        public int Write(string varName, string value)
        {
            if (!Vals.ContainsKey(varName))
            {
                return (int)SoftWareAlarm.PrimVarManager_查找键不存在;
            }

            return ReplaceOne("Name", varName, new Var(varName, value));
        }
        public int Enqueue(string varName, object value)
        {
            if (!Vals.ContainsKey(varName) || Vals[varName].ReadMode != DataReadMode.Queue || !QueueVars.ContainsKey(varName) || value == null)
            {
                return -1;
            }

            if (Vals[varName].DataType != DataType.Other && Vals[varName].DataType != DataType.CLASS)
            {
                QueueMsgSend(QueueVars[varName], value.ToString());
            }
            else
            {
                QueueMsgSend(QueueVars[varName], JsonHelper.SerializeObject(value));
            }
            return 0;
        }
        public int Dequeue(string varName, out object obj)
        {
            if (VarsType != VarManagerType.Server || !Vals.ContainsKey(varName) || Vals[varName].ReadMode != DataReadMode.Queue || !QueueVars.ContainsKey(varName) || Vals[varName].DataType == DataType.Other || Vals[varName].DataType == DataType.CLASS)
            {
                obj = null;
                return -10;
            }

            if (QueueMsgRev(QueueVars[varName], out var revMsg) != 0)
            {
                obj = null;
                return -1;
            }

            switch (Vals[varName].DataType)
            {
                case DataType.BOOL:
                    obj = bool.TryParse(revMsg, out var boolValue) ? boolValue : false;
                    break;
                case DataType.DOUBLE:
                    obj = double.TryParse(revMsg, out var doubleValue) ? doubleValue : 0.0;
                    break;
                case DataType.STRING:
                    obj = revMsg;
                    break;
                case DataType.INT:
                    obj = int.TryParse(revMsg, out var intValue) ? intValue : 0;
                    break;
                case DataType.CLASS:
                case DataType.Other:
                default:
                    obj = null;
                    break;
            }
            return 0;
        }
        public int DequeueMultiVar<T>(string varName, out T obj) where T : class
        {
            if (VarsType != VarManagerType.Server || !Vals.ContainsKey(varName) || Vals[varName].ReadMode != DataReadMode.Queue || !QueueVars.ContainsKey(varName) ||
                (Vals[varName].DataType != DataType.Other && Vals[varName].DataType != DataType.CLASS))
            {
                obj = null;
                return -10;
            }

            if (QueueMsgRev(QueueVars[varName], out var revMsg) != 0)
            {
                obj = null;
                return -1;
            }

            switch (Vals[varName].DataType)
            {
                case DataType.CLASS:
                case DataType.Other:
                    obj = JsonHelper.DeserializeJsonToObject<T>(revMsg);
                    break;
                default:
                    obj = null;
                    break;
            }
            return 0;
        }
        public int Peek(string varName, out object obj)
        {
            if (!Vals.ContainsKey(varName) || Vals[varName].ReadMode != DataReadMode.Queue || !QueueVars.ContainsKey(varName))
            {
                obj = null;
                return -10;
            }

            if (QueueMsgPeek(QueueVars[varName], out var revMsg) != 0)
            {
                obj = null;
                return -1;
            }

            switch (Vals[varName].DataType)
            {
                case DataType.BOOL:
                    obj = bool.TryParse(revMsg, out var boolValue) ? boolValue : false;
                    break;
                case DataType.DOUBLE:
                    obj = double.TryParse(revMsg, out var doubleValue) ? doubleValue : 0.0;
                    break;
                case DataType.STRING:
                    obj = revMsg;
                    break; ;
                case DataType.INT:
                    obj = int.TryParse(revMsg, out var intValue) ? intValue : 0;
                    break;
                case DataType.CLASS:
                case DataType.Other:
                    obj = JsonHelper.DeserializeJsonToObject(revMsg);
                    break;
                default:
                    obj = null;
                    break;
            }
            return 0;
        }
        public int ClearQueue(string varName)
        {
            if (VarsType != VarManagerType.Server || !Vals.ContainsKey(varName) || Vals[varName].ReadMode != DataReadMode.Queue || !QueueVars.ContainsKey(varName))
            {
                return -10;
            }

            if (QueueCount(varName) > 0)
            {
                QueueVars[varName].Purge();
            }

            return 0;
        }
        public int QueueCount(string varName)
        {
            if (!Vals.ContainsKey(varName) || Vals[varName].ReadMode != DataReadMode.Queue || !QueueVars.ContainsKey(varName))
            {
                return -1;
            }
            Vals[varName].LastCount = Vals[varName].CurrentCount;
            if (VarsType == VarManagerType.Server)
            {
                Vals[varName].CurrentCount = QueueVars[varName].GetAllMessages().Length;
            }
            else
            {
                var count = Read(varName);
                Vals[varName].CurrentCount = Convert.ToInt32(count);
            }

            if (Vals[varName].LastCount != Vals[varName].CurrentCount)
            {
                Vals[varName].IsChanged = true;
            }
            return Vals[varName].CurrentCount;
        }
        public int AddVar(RemoteVar newVar)
        {
            if (Vals.ContainsKey(newVar.Name))
            {
                Vals.TryRemove(newVar.Name, out var removed);
            }

            Vals.TryAdd(newVar.Name, newVar);

            if (newVar.ReadMode == DataReadMode.Queue)
            {
                if (QueueVars.ContainsKey(newVar.Name))
                {
                    QueueVars.TryRemove(newVar.Name, out var removed);
                }

                MessageQueue newQueue = null;
                if (VarsType == VarManagerType.Server)
                {
                    InitRevMsgQueue($@".\private$\{newVar.Name}", ref newQueue);
                }
                else
                {
                    InitRevMsgQueue($@"FormatName:Direct=TCP:{ServerIp}\private$\{newVar.Name}", ref newQueue);
                }
                QueueVars.TryAdd(newVar.Name, newQueue);

                if (QueryOne("Name", newVar.Name, out Var queryVar) != 0 || queryVar == null)
                {
                    InsertOne(new Var(newVar.Name, "0"));
                }
                else
                {
                    var count = QueueCount(newVar.Name);
                    Vals[newVar.Name].LastCount = Vals[newVar.Name].CurrentCount;
                    Vals[newVar.Name].CurrentCount = count;
                }
            }
            else
            {
                var newDbVar = new Var(newVar.Name, newVar.CurrentValue == null ? "" : newVar.CurrentValue.ToString());
                switch (newVar.DataType)
                {
                    case DataType.BOOL:
                        newVar.CurrentValue = false;
                        newVar.LastValue = false;
                        break;
                    case DataType.DOUBLE:
                        newVar.CurrentValue = 0.0;
                        newVar.LastValue = 0.0;
                        break;
                    case DataType.STRING:
                        newVar.CurrentValue = "";
                        newVar.LastValue = "";
                        break;
                    case DataType.INT:
                        newVar.CurrentValue = 0;
                        newVar.LastValue = 0;
                        break;
                    case DataType.CLASS:
                    case DataType.Other:
                    default:
                        newVar.CurrentValue = null;
                        newVar.LastValue = null;
                        break;
                }
                if (QueryOne("Name", newVar.Name, out Var queryVar) != 0 || queryVar == null)
                {
                    InsertOne(newDbVar);
                }
                else
                {
                    Read(newVar.Name);
                }
            }

            return 0;
        }
        #endregion



        #region Others
        /// <summary>基元初始化</summary>
        /// <returns>int</returns>
        internal void InitDb()
        {
            _initedError = true;
            if (VarsType == VarManagerType.Client)
            {
                Ping ping = new Ping();
                if (ping.Send(ServerIp, 500).Status != IPStatus.Success)
                {
                    throw new Exception($"IP地址{ServerIp}无响应");
                }
                _connStr = $@"mongodb://{ServerIp}:27017";
            }
            else
            {
                _connStr = $@"mongodb://127.0.0.1:27017/authdb?serverSelectionTimeoutMS=3000&connectTimeoutMS=3000&socketTimeoutMS=3000";
            }

            _client = new MongoClient(_connStr);
            _database = _client.GetDatabase(_databaseName);
            if (!SpinWait.SpinUntil(() => _client.Cluster.Description.State == ClusterState.Connected, 3000))
            {
                throw new Exception("MongoDB数据库连接失败");
            }

            _initedError = false;
        }
        /// <summary>值读取Task</summary>
        /// <param name="token">CancellationToken</param>
        /// <returns>int</returns>
        private int ReadVars(CancellationToken token)
        {
            while (true)
            {
                if (token.IsCancellationRequested) return -1;
                Application.DoEvents();
                Thread.Sleep(CycleTime > 0 ? 10 : CycleTime);

                if (!CycleEnable)
                {
                    Application.DoEvents();
                    Thread.Sleep(500);
                }
                try
                {
                    foreach (var val in Vals)
                    {
                        if (val.Value.ReadMode == DataReadMode.Cycle)
                        {
                            if (val.Value.DataType != DataType.CLASS && val.Value.DataType != DataType.Other && Read(val.Key) != null && val.Value.IsChanged && (val.Value.Permission == DataPermission.R || val.Value.Permission == DataPermission.RW))
                            {
                                ((ConfigUiControl)PrimConfigUI).UpdateVariableValue(val.Key, val.Value.CurrentValue);
                                if (val.Value.IsEventNotify)
                                {
                                    OnVariableChanged?.Invoke(val.Key, val.Value.CurrentValue, val.Value.LastValue);
                                }
                                val.Value.IsChanged = false;
                            }
                        }
                        else if (val.Value.ReadMode == DataReadMode.Queue)
                        {
                            var count = QueueCount(val.Key);
                            if (val.Value.IsChanged)
                            {
                                ((ConfigUiControl)PrimConfigUI).UpdateVariableValue(val.Key, count);
                                if (val.Value.IsEventNotify && Peek(val.Key, out var obj) == 0)
                                {
                                    OnQueueVariableChanged?.Invoke(val.Key, obj);
                                }
                                val.Value.IsChanged = false;
                            }
                        }
                    }
                }
                catch
                {
                }
            }
        }
        /// <summary>断开连接</summary>
        /// <param name="result"></param>
        /// <returns>int</returns>
        public int IPrimDisConnect(ref string result)
        {
            var iRet = 0;
            SetConnState(PrimConnState.UnConnected);
            return iRet;
        }

        public int IPrimReset()
        {
            return 0;
        }

        private void InitRevMsgQueue(string queuePath, ref MessageQueue msgQueue)
        {
            if (VarsType == VarManagerType.Server)
            {
                if (MessageQueue.Exists(queuePath))
                {
                    msgQueue = new MessageQueue(queuePath);
                }
                else
                {
                    msgQueue = MessageQueue.Create(queuePath);
                }
            }
            else
            {
                msgQueue = new MessageQueue(queuePath);
            }
        }

        private void QueueMsgSend(MessageQueue msgQueue, string msg)
        {
            var sendMsg = new System.Messaging.Message();
            sendMsg.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            sendMsg.Body = msg;
            msgQueue.Send(sendMsg);
        }

        private int QueueMsgRev(MessageQueue msgQueue, out string revMsg)
        {
            try
            {
                if (msgQueue.GetAllMessages().Length == 0)
                {
                    revMsg = "";
                    return -1;
                }
                else
                {
                    msgQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                    var rcvStr = msgQueue.Receive();
                    revMsg = (string)rcvStr.Body;
                    return 0;
                }
            }
            catch
            {
                revMsg = "";
                return -10;
            }
        }

        private int QueueMsgPeek(MessageQueue msgQueue, out string peekMsg)
        {
            if (msgQueue.GetAllMessages().Length == 0)
            {
                peekMsg = "";
                return -1;
            }
            else
            {
                var msgStr = msgQueue.Peek();
                msgStr.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                peekMsg = (string)msgStr.Body;
                return 0;
            }
        }

        internal int RemoveVar(string varName)
        {
            if (!Vals.ContainsKey(varName))
            {
                return -1;
            }
            if (QueueVars.ContainsKey(varName))
            {
                QueueVars.TryRemove(varName, out var queueVar);
            }
            if (Vals.TryRemove(varName, out var value))
            {
                return ExportValsToFile();
            }
            return -2;
        }

        private int ClearEventOnMsgReved()
        {
            var iRet = 0;

            if (OnVariableChanged != null)
            {
                foreach (var d in OnVariableChanged.GetInvocationList())
                {
                    OnVariableChanged -= d as RemoteVariableChanged;
                }
            }

            if (OnQueueVariableChanged != null)
            {
                foreach (var d in OnQueueVariableChanged.GetInvocationList())
                {
                    OnQueueVariableChanged -= d as RemoteQueueVariableChanged;
                }
            }

            return iRet;
        }
        /// <summary>JSON文件保存</summary>
        /// <returns>int</returns>
        public int ExportValsToFile()
        {
            return JsonHelper.SerializeObjectToFile(Vals, ValsSavePath) ? 0 : (int)SoftWareAlarm.PrimVarManager_JSON文件保存失败;
        }
        /// <summary>JSON文件加载</summary>
        /// <returns>int</returns>
        public int ImportValsFromFile()
        {
            Vals = JsonHelper.DeserializeJsonFileToObject<ConcurrentDictionary<string, RemoteVar>>(ValsSavePath);

            if (Vals == null)
            {
                Vals = new ConcurrentDictionary<string, RemoteVar>();
                return (int)SoftWareAlarm.PrimVarManager_JSON文件加载失败;
            }

            return 0;
        }
        /// <summary>连接状态_运行状态设置</summary>
        /// <param name="conn">连接状态</param>
        /// <param name="run">运行状态</param>
        public void SetConn_RunState(PrimConnState conn, PrimRunState run)
        {
            PrimConnStat = conn;
            PrimRunStat = run;
            ((ConfigUiControl)PrimConfigUI).SetPrimConnState(conn);
            ((ConfigUiControl)PrimConfigUI).SetPrimRunState(run);
            ((DebugUiControl)PrimDebugUI).SetPrimConnState(conn);
            ((DebugUiControl)PrimDebugUI).SetPrimRunState(run);
            ((OutputUiControl)PrimOutputUI).SetPrimConnState(conn);
            ((OutputUiControl)PrimOutputUI).SetPrimRunState(run);
        }
        /// <summary>连接状态设置</summary>
        /// <param name="conn">连接状态</param>
        public void SetConnState(PrimConnState conn)
        {
            PrimConnStat = conn;
            ((ConfigUiControl)PrimConfigUI).SetPrimConnState(conn);
            ((DebugUiControl)PrimDebugUI).SetPrimConnState(conn);
            ((OutputUiControl)PrimOutputUI).SetPrimConnState(conn);
        }
        /// <summary>运行状态设置</summary>
        /// <param name="run">运行状态</param>
        public void SetRunState(PrimRunState run)
        {
            PrimRunStat = run;
            ((ConfigUiControl)PrimConfigUI).SetPrimRunState(run);
            ((DebugUiControl)PrimDebugUI).SetPrimRunState(run);
            ((OutputUiControl)PrimOutputUI).SetPrimRunState(run);
        }
        /// <summary>日志</summary>
        /// <param name="log">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        public void LogAdd(string log, LogLevel lv, long id = 0)
        {
            if (!LogEnable)
            {
                return;
            }

            string tempId = $"{(int)lv}{(int)PrimLogId.PrimVarManager}0000";

            if (long.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, log, Name, LogClassification.VisioPrim, id);
        }
        #endregion






        #region Mongodb
        /// <summary>插入单条数据</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="entity">要插入的实体对象</param>
        /// <returns>0-成功</returns>
        public int InsertOne<T>(T entity)
        {
            if (_initedError)
            {
                return -10;
            }

            var collection = _database.GetCollection<T>(VarsType == VarManagerType.Server ? Name : ServerName);
            try
            {
                collection.InsertOne(entity);
                return 0;
            }
            catch (Exception e)
            {
                LogAdd("插入失败：" + e.Message, LogLevel.Warn);
                return -2;
            }
        }
        /// <summary>给定单组条件查询单组数据</summary>
        /// <param name="fieldName">查询字段名</param>
        /// <param name="value">查询字段值</param>
        /// <param name="result">查询到的对象，没有或出错则为null</param>
        /// <returns>0-成功</returns>
        public int QueryOne<T>(string fieldName, string value, out T result)
        {
            if (_initedError)
            {
                result = default;
                return -10;
            }

            var collection = _database.GetCollection<T>(VarsType == VarManagerType.Server ? Name : ServerName);
            var filter = Builders<T>.Filter.Eq(fieldName, value);
            var projection = Builders<T>.Projection.Exclude("_id");
            var findOption = new FindOptions
            {
                AllowPartialResults = true,
                Collation = Collation.Simple,
                BatchSize = Int32.MaxValue,
            };

            try
            {
                var document = collection.Find(filter, findOption).Project<T>(projection);
                result = document.First();
                return 0;
            }
            catch (Exception e)
            {
                result = default;
                LogAdd("查询失败：" + e.Message, LogLevel.Warn);
                return -2;
            }
        }

        /// <summary>替换一条数据（如对象未存在，则新建）</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="chosedField">查询数据的字段名</param>
        /// <param name="chosedValue">查询数据的字段值</param>
        /// <param name="entiy">新的对象</param>
        /// <returns>0-成功</returns>
        public int ReplaceOne<T>(string chosedField, string chosedValue, T entiy)
        {
            if (_initedError)
            {
                return -10;
            }

            var collection = _database.GetCollection<T>(VarsType == VarManagerType.Server ? Name : ServerName);
            var filter = Builders<T>.Filter.Eq(chosedField, chosedValue);

            try
            {
                var result = collection.ReplaceOne(filter, entiy);
                if (!result.IsAcknowledged)
                {
                    return -3;
                }
                return 0;
            }
            catch (Exception e)
            {
                LogAdd("替换失败：" + e.Message, LogLevel.Warn);
                return -2;
            }
        }
        #endregion
    }
}