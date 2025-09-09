using System;
using System.Drawing;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimSktClient
{
    /// <summary>编码类型</summary>
    public enum EncodingType
    {
        UTF8 = 0,
        ASCII = 1,
        Unicode = 2,
        GB2312 = 3,
        HEX = 4,
    }



    /// <summary>客户端配置管理器</summary>
    public class ClientConfig
    {
        /// <summary>编码类型</summary>
        public EncodingType TransEncodingType { set; get; } = EncodingType.UTF8;

        public bool LogEnable { set; get; } = true;



        #region Override IPrim
        /// <summary>【ClientConfig】基元Id</summary>
        public Guid Id { set; get; }
        /// <summary>【ClientConfig】基元名称</summary>
        public string Name { set; get; }
        /// <summary>【ClientConfig】基元使能</summary>
        public bool PrimEnable { set; get; }
        /// <summary>【ClientConfig】基元类型</summary>
        public PrimType HSType { set; get; }
        /// <summary>【ClientConfig】基元类型名称</summary>
        public string PrimTypeName { set; get; }
        /// <summary>【ClientConfig】基元连接状态</summary>
        public PrimConnState PrimConnStat { set; get; }
        /// <summary>【ClientConfig】基元运行状态</summary>
        public PrimRunState PrimRunStat { set; get; }
        /// <summary>【ClientConfig】基元版本</summary>
        public PrimVer Ver { set; get; }
        /// <summary>【ClientConfig】基元当前图标索引</summary>
        public int CurrentImageIndex { get; set; } = -1;
        #endregion



        #region Override ISkt
        /// <summary>IP</summary>
        public string Ip { set; get; }
        /// <summary>端口</summary>
        public string Port { set; get; }
        /// <summary>心跳信息</summary>
        public string HeartInfo { set; get; }
        /// <summary>心跳循环时间</summary>
        public int HeartInfoCycleTime { set; get; }
        /// <summary>心跳是否开启</summary>
        public bool HeartFlag { set; get; }
        /// <summary>重连次数</summary>
        public int ReconnectCnt { set; get; }
        /// <summary>模式</summary>
        public SktConnMode ConnMode { set; get; }
        /// <summary>通知模式</summary>
        public SktNotifyMode NotifyMode { set; get; }
        /// <summary>发送队列数量</summary>
        public int SendQueueCnt { set; get; }
        /// <summary>接收队列数量</summary>
        public int RevQueueCnt { set; get; }
        /// <summary>网络名称</summary>
        public string NetName { set; get; }
        #endregion
    }
}