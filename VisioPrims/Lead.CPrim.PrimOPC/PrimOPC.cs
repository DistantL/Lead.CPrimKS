using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.OPC;
using Lead.CPrim.ProxyTools;
using Opc.Ua;
using Opc.Ua.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.PrimOPC
{
    public class PrimOPC : IPrim, IOPC
    {
        private OPCConfig _config;
        private OpcHelper _opc;
        private Dictionary<string, List<string>> _dicSubscription = new Dictionary<string, List<string>>();
        //private List<NodeConfig> _listNodeConfig = new List<NodeConfig>();  //OPC节点配置
        public PrimOPC()
        {
            _config = new OPCConfig();
            PrimDebugUI = new PrimDebugControl();
            PrimConfigUI = new PrimConfigControl(this);
            PrimOutputUI = new PrimOutputControl();
            this.PrimConnStat = PrimConnState.UnConnected;
        }

        public PrimOPC(XmlNode xmlNode)
        {
            if (xmlNode != null)
                _config = XMLHelper.XMLToObject(xmlNode, typeof(OPCConfig)) as OPCConfig;
            else
                return;
            if (!String.IsNullOrEmpty(NodeConfigPath))
            {
                ListNodeConfig = JsonHelper.DeserializeJsonFileToObject<List<NodeConfig>>(NodeConfigPath);
            }
            else
            {
                ListNodeConfig = new List<NodeConfig>();
            }
            PrimDebugUI = new PrimDebugControl();
            PrimConfigUI = new PrimConfigControl(this);
            PrimOutputUI = new PrimOutputControl();
            this.PrimConnStat = PrimConnState.UnConnected;
        }

        public string Name
        {
            set => _config.Name = value;
            get => _config.Name;
        }

        public string PrimTypeName
        {
            set => _config.PrimTypeName = value;
            get => _config.PrimTypeName;
        }

        public Guid Id
        {
            set => _config.Id = value;
            get => _config.Id;
        }

        public Type ChildType
        {
            set => _config.ChildType = value;
            get => _config.ChildType;
        }

        public PrimType HSType
        {
            set => _config.HSType = value;
            get => _config.HSType;
        }

        public PrimManufacture Manu
        {
            set => _config.Manu = value;
            get => _config.Manu;
        }

        public PrimVer Ver
        {
            set => _config.Ver = value;
            get => _config.Ver;
        }

        public int CurrentImageIndex { get => _config.CurrentImageIndex; set => _config.CurrentImageIndex = value; }

        public PrimConnState PrimConnStat
        {
            set ;
            get ;
        }

        public PrimRunState PrimRunStat
        {
            set ;
            get ;
        }

        public bool PrimSimulator
        {
            set => _config.PrimSimulator = value;
            get => _config.PrimSimulator;
        }

        public bool PrimDebug
        {
            set => _config.PrimDebug = value;
            get => _config.PrimDebug;
        }

        public bool PrimEnable
        {
            set => _config.PrimEnable = value;
            get => _config.PrimEnable;
        }

        public string NodeConfigPath { get => _config.NodeConfigPath; set => _config.NodeConfigPath = value; }              //OPC节点配置路径

        public List<NodeConfig> ListNodeConfig { get; set; }    //OPC节点配置
        public Session OPCSession { get => _opc.OPCSession; }
        public Control PrimDebugUI { get; }

        public Control PrimConfigUI { get; }

        public Control PrimOutputUI { get; }
        #region Login Config
        /// <summary>
        /// 登陆OPC服务器的方式 0：匿名登录 1：账号登陆 2：证书登陆
        /// </summary>
        public int LoginMethod
        {
            set => _config.LoginMethod = value;
            get => _config.LoginMethod;
        }
        public string UserName
        {
            set => _config.UserName = value;
            get => _config.UserName;
        }
        public string Password
        {
            set => _config.Password = value;
            get => _config.Password;
        }
        public string CertificateFilePath
        {
            set => _config.CertificateFilePath = value;
            get => _config.CertificateFilePath;
        }
        public string SecretKey
        {
            set => _config.SecretKey = value;
            get => _config.SecretKey;
        }
        public string ServerAddress
        {
            set => _config.ServerAddress = value;
            get => _config.ServerAddress;
        }

        #endregion
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

        public int IPrimTaskStop()
        {
            if (IPrimStop() != 0)
            {
                return -1;
            }
            return 0;
        }

        public int IPrimTaskReset()
        {
            return 0;
        }

        public bool LogEnable
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public int IPrimInit()
        {
            if (PrimRunStat == PrimRunState.Running && PrimConnStat == PrimConnState.Connected) return 0;

            var iRet = 0;

            _opc = new OpcHelper();
            SetConn_RunState(PrimConnState.Connected, PrimRunState.Stop);
            return iRet;
        }

        public int IPrimConnect(ref string result)
        {
            if (PrimConnStat != PrimConnState.Connected)
            {
                result = Name + "UnConnected";
                return -1;
            }
            if (PrimRunStat == PrimRunState.Running)
            {
                return 0;
            }
            switch (LoginMethod)
            {
                case 1:
                    _opc.OpenConnectOfAccount(ServerAddress, UserName, Password);
                    break;
                case 2:
                    _opc.OpenConnectOfCertificate(ServerAddress, CertificateFilePath, SecretKey);
                    break;
                default:
                    _opc.OpenConnectOfAnonymous(ServerAddress);
                    break;
            }
            Thread.Sleep(3000);
            SetConn_RunState(_opc.ConnectStatus ? PrimConnState.Connected : PrimConnState.UnConnected, _opc.ConnectStatus ? PrimRunState.Running : PrimRunState.Stop);
            return 0;
        }

        public int IPrimStart()
        {
            var iRet = 0;
            return iRet;
        }

        public int IPrimStop()
        {
            var iRet = 0;
            return iRet;
        }

        public int IPrimDisConnect(ref string result)
        {
            var iRet = 0;
            _opc.CancelSingleNodeIdDatasSubscription("A");
            _opc.CancelAllNodeIdDatasSubscription();
            _opc.CloseConnect();
            Thread.Sleep(500);
            if (_opc.ConnectStatus)
            {
                SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Err);
            }
            else
            {
                SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Stop);
            }

            return iRet;
        }

        public int IPrimSuspend()
        {
            var iRet = 0;
            return iRet;
        }

        public int IPrimResume()
        {
            var iRet = 0;
            return iRet;
        }

        public int IPrimDispose()
        {
            try
            {
                var disConnectRet = "";
                IPrimDisConnect(ref disConnectRet);
                IPrimStop();
                SetConn_RunState(PrimConnState.Other, PrimRunState.Other);
                return 0;
            }
            catch (Exception)
            {
                SetConn_RunState(PrimConnState.Other, PrimRunState.Err);
                return -1;
            }
        }

        public int IPrimImportConfigXml(XmlNode xmlNode)
        {
            var iRet = 0;
            if (xmlNode != null)
                _config = XMLHelper.XMLToObject(xmlNode, typeof(OPCConfig)) as OPCConfig;
            else
                return -1;
            return iRet;
        }

        public XmlNode IPrimExportConfigXml()
        {
            if (_config == null) return null;

            var node = XMLHelper.ObjectToXML(_config);

            return node;
        }

        public int IPrimReset()
        {
            var iRet = 0;
            return iRet;
        }
        /// <summary>
        /// 单个读取订阅事件
        /// </summary>
        public event DelSingleSubscription OnSingleSubscription;
        /// <summary>
        /// 批量读取订阅事件
        /// </summary>
        public event DelBatchSubscription OnBatchSubscription;
        /// <summary>
        /// 读单个节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public T Read<T>(string nodeId)
        {
            
            return _opc.GetCurrentNodeValue<T>(nodeId);
           
        }
        
        /// <summary>
        /// 批量读取
        /// </summary>
        /// <param name="nodeIdlist">节点IDlist</param>
        /// <returns></returns>
        public Dictionary<string,object> BatchRead(List<string> nodeIdlist)
        {
            Dictionary<string,object> dic = new Dictionary<string, object>();
            Dictionary<string, DataValue> dic1 = new Dictionary<string, DataValue>();
            List<NodeId> nodeId = new List<NodeId>();
            foreach (var item in nodeIdlist)
            {
                nodeId.Add(new NodeId(item));
            }
            dic1=_opc.GetBatchNodeDatasOfSync(nodeId);
           // List<object> list = new List<object>();
            foreach (var item in dic1)
            {
                var s= (object)item.Value.WrappedValue.Value;
                dic.Add(item.Key, s);
            }
            return dic;
        }
        
        /// <summary>
        /// 批量写入节点
        /// </summary>
        /// <param name="NodeIdArray">节点ID数组</param>
        /// <param name="NodeidvalueArray">节点ID变量</param>
        /// <returns></returns>
        public int BatchWrite(string[] NodeIdArray,Object[] NodeidvalueArray)
        {
            int Res = 0;
            if (!_opc.BatchWriteNodeIds(NodeIdArray, NodeidvalueArray))
            {
                return -1;
            }
            return Res;
        }
        /// <summary>
        /// 读单个节点
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public DataValue Read(NodeId nodeId)
        {
            return _opc.GetCurrentNodeValue(nodeId);
        }
        /// <summary>
        /// 写单个节点
        /// </summary>
        /// <typeparam name="T">数据格式要与待写入相同</typeparam>
        /// <param name="nodeId">节点ID</param>
        /// <param name="updateValue">更新内容</param>
        /// <returns></returns>
        public bool Write<T>(string nodeId, T updateValue)
        {
            return _opc.WriteSingleNodeIdOfSync(nodeId, updateValue);
        }
        /// <summary>
        /// 批量订阅
        /// </summary>
        /// <param name="key">绑定订阅节点</param>
        /// <param name="nodes">节点数组</param>
        public void BatchSubscription(string key, string[] nodes)
        {
            if (_dicSubscription.ContainsKey(key))
            {
                _opc.CancelSingleNodeIdDatasSubscription(key);
            }
            _dicSubscription[key] = nodes.ToList();
            _opc.BatchNodeIdDatasSubscription(key, nodes, SubAction);
        }
        /// <summary>
        /// 单个订阅
        /// </summary>
        /// <param name="key">绑定订阅节点</param>
        /// <param name="nodeId">节点名</param>
        public void SingleSubscription(string key, string nodeId)
        {
            if (_dicSubscription.ContainsKey(key))
            {
                _opc.CancelSingleNodeIdDatasSubscription(key);
            }

            _dicSubscription[key] = new List<string> { nodeId };
            _opc.SingleNodeIdDatasSubscription(key, nodeId, SubAction);
        }
        /// <summary>
        /// 取消单节点订阅
        /// </summary>
        /// <param name="key">订阅时绑定的key</param>
        public void CancelSingleSubscription(string key)
        {
            _opc.CancelSingleNodeIdDatasSubscription(key);
            _dicSubscription.Remove(key);
        }
        /// <summary>
        /// 取消所有节点订阅
        /// </summary>
        public void CancelAllSubscription()
        {
            _opc.CancelAllNodeIdDatasSubscription();
            _dicSubscription.Clear();
        }
        /// <summary>
        /// 取消订阅事件绑定
        /// </summary>
        /// <returns></returns>
        public int ClearEventOnMsgReved()
        {
            if (OnSingleSubscription != null)
            {
                foreach (var d in OnSingleSubscription.GetInvocationList()) OnSingleSubscription -= d as DelSingleSubscription;
            }

            if (OnBatchSubscription != null)
            {
                foreach (var d in OnBatchSubscription.GetInvocationList()) OnBatchSubscription -= d as DelBatchSubscription;
            }

            return 0;
        }
        private void SubAction(string key, MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs args)
        {
            if (_dicSubscription.ContainsKey(key))
            {
                if (_dicSubscription[key].Count == 1)
                {
                    if (args.NotificationValue is MonitoredItemNotification notification)
                    {
                        var nodeId = monitoredItem.StartNodeId.ToString();
                        var wrappedValue = notification.Value.WrappedValue.Value;
                        Debug.WriteLine(nodeId + " 节点订阅的值为：" + wrappedValue);
                        OnSingleSubscription?.Invoke(nodeId, wrappedValue);
                    }
                }
                else
                {
                    var notification = args.NotificationValue as MonitoredItemNotification;
                    var batchSubscriptsionDataNodeId = _dicSubscription[key].ToArray();
                    var dicNotify = new Dictionary<string, object>();
                    var tmp = "";
                    if (batchSubscriptsionDataNodeId.Length > 0)
                    {
                        var len = batchSubscriptsionDataNodeId.Length;

                        for (var i = 0; i < len; i++)
                        {
                            if (monitoredItem.StartNodeId.ToString() == batchSubscriptsionDataNodeId[i])
                            {
                                tmp += batchSubscriptsionDataNodeId[i] + " 节点订阅的值为：" + notification.Value.WrappedValue.Value.ToString() + "\r\n";
                                dicNotify[batchSubscriptsionDataNodeId[i]] = notification.Value.WrappedValue;
                            }
                        }
                        Debug.WriteLine(tmp);
                        OnBatchSubscription?.Invoke(key, dicNotify);
                    }
                }
            }
        }

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
        /// <summary>
        /// 读取单个节点节点名称读取
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public object ReadByNodeName(string nodeName)
        {
            object iret = null;
            foreach (var node in ListNodeConfig)
            {
                if (node.NodeKey == nodeName)
                {
                    iret = Read(node.NodeName);
                }
            }
            return iret;
        }
    }
}