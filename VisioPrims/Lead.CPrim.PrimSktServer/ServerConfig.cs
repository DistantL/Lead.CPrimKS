using System;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimSktServer
{
    /// <summary>服务器配置管理器</summary>
    public class ServerConfig
    {
        #region Override IPrim's Property
        /// <summary>基元名字</summary>
        public string Name { set; get; }

        public string PrimTypeName { set; get; }

        public Guid Id { set; get; }

        //Prim 子类的类型
        public Type ChildType { set; get; }

        /// <summary>基元类型</summary>
        public PrimType HSType { set; get; }

        public PrimManufacture Manu { set; get; }

        public PrimVer Ver { set; get; }
        /// <summary>连接状态</summary>
        public PrimConnState PrimConnStat { set; get; }
        /// <summary>运行状态</summary>
        public PrimRunState PrimRunStat { set; get; }

        public bool PrimSimulator { set; get; }
        /// <summary>测试模式</summary>
        public bool PrimDebug { set; get; }

        public bool PrimEnable { set; get; }

        public bool LogEnable { set; get; }
        #endregion


        #region Override ISktServer Property
        /// <summary>IP</summary>
        public string BindIp { set; get; }
        /// <summary>端口</summary>
        public string Port { set; get; }
        /// <summary>通知模式</summary>
        public SktNotifyMode NotifyMode { set; get; }
        /// <summary>心跳信息</summary>
        public string HeartInfo { set; get; }
        /// <summary>心跳标志</summary>
        public bool HeartFlag { set; get; }
        /// <summary>发送队列数量</summary>
        public int SendQueueCnt { set; get; }
        /// <summary>接收队列数量</summary>
        public int RevQueueCnt { set; get; }
        /// <summary>基元名称</summary>
        public string NetName { set; get; }
        #endregion
    }

    public class ServerMsgInfo
    {
        public object Context = null;
        public string NetName = "";
        public string Point = "";
    }
}