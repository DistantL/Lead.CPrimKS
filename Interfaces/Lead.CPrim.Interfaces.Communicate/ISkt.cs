using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;

namespace Lead.CPrim.Interfaces
{
    /// <summary>接收事件委托</summary>
    /// <param name="send"></param>
    /// <param name="context"></param>
    public delegate void SktMsgRevedEventHandle(string send, object context);
    /// <summary>接收事件委托</summary>
    /// <param name="buffer"></param>
    public delegate void SktMsgRevedByteEventHandle(byte[] buffer);
    /// <summary>上线/掉线通知委托</summary>
    /// <param name="onLine">true：在线；false：离线；</param>
    public delegate void LineEventHandle(bool onLine);



    /// <summary>连接协议</summary>
    public enum SktConnMode
    {
        /// <summary>TCP</summary>
        TCP,
        /// <summary>UDP</summary>
        UDP
    }



    /// <summary>通知模式</summary>
    public enum SktNotifyMode
    {
        /// <summary>事件</summary>
        DataEvent,
        /// <summary>队列</summary>
        DataQueue,
        /// <summary>Other</summary>
        Other
    }



    /// <summary>客户端（用户接口）</summary>
    public interface ISktClient
    {
        /// <summary>接收消息时发生</summary>
        event SktMsgRevedEventHandle OnMsgReved;
        /// <summary>接收消息时发生</summary>
        event SktMsgRevedByteEventHandle OnMsgRevedByte;
        /// <summary>上线/掉线通知事件</summary>
        event LineEventHandle OnLine;


        /// <summary>IP</summary>
        string Ip { set; get; }
        /// <summary>端口</summary>
        string Port { set; get; }
        /// <summary>心跳信息</summary>
        string HeartInfo { set; get; }
        /// <summary>心跳循环时间</summary>
        int HeartInfoCycleTime { set; get; }
        /// <summary>心跳是否开启</summary>
        bool HeartFlag { set; get; }
        /// <summary>重连次数</summary>
        int ReconnectCnt { set; get; }
        /// <summary>通知模式</summary>
        SktNotifyMode NotifyMode { set; get; }
        /// <summary>发送队列数量</summary>
        int SendQueueCnt { set; get; }
        /// <summary>网络名称</summary>
        string NetName { set; get; }
        /// <summary>接收队列（TCP模式下使用）</summary>
        ConcurrentQueue<byte[]> QueueMsg { set; get; }
        /// <summary>true：接收byte[]；false：不接收byte[]</summary>
        bool IsReceivingByte { set; get; }

        /// <summary>清除所有接收事件</summary>
        /// <returns>int</returns>
        int ClearEventOnMsgReved();
        /// <summary>发送消息</summary>
        /// <param name="rev">备用参数（默认为空）</param>
        /// <param name="context">发送消息内容</param>
        /// <returns>int</returns>
        int SendInfo(string rev, object context);
        /// <summary>心跳信息 && 心跳循环时间设置</summary>
        /// <param name="heart">心跳信息</param>
        /// <param name="cycleTime">心跳循环时间</param>
        /// <returns>int</returns>
        int SetHeartInfo(string heart, int cycleTime);
        /// <summary>通知模式设置</summary>
        /// <param name="mode">通知模式</param>
        /// <returns>int</returns>
        int SetNotifyMode(SktNotifyMode mode);
        /// <summary>发送队列数量设置</summary>
        /// <param name="num">发送队列数量</param>
        /// <returns>int</returns>
        int SetSendQueueCnt(int num);
    }

    /// <summary>服务器（用户接口）</summary>
    public interface ISktServer
    {
        /// <summary>接收消息时发生</summary>
        event SktMsgRevedEventHandle OnMsgReved;


        /// <summary>IP</summary>
        string BindIp { set; get; }
        /// <summary>端口</summary>
        string Port { set; get; }
        /// <summary>心跳信息</summary>
        string HeartInfo { set; get; }
        /// <summary>心跳是否开启</summary>
        bool HeartFlag { set; get; }
        /// <summary>通知模式</summary>
        SktNotifyMode NotifyMode { set; get; }
        /// <summary>连接协议</summary>
        SktConnMode ConnMode { set; get; }
        /// <summary>发送队列数量</summary>
        int SendQueueCnt { set; get; }
        /// <summary>接收队列数量</summary>
        int RevQueueCnt { set; get; }
        /// <summary>网络名称</summary>
        string NetName { set; get; }
        /// <summary>
        /// True：有客户端连接；False：无客户端连接；
        /// </summary>
        bool HasClients { get; }

        /// <summary>清除所有接收事件</summary>
        /// <returns>int</returns>
        int ClearEventOnMsgReved();
        /// <summary></summary>
        /// <param name="regInfo"></param>
        /// <returns></returns>
        int RegNotifyInfo(string regInfo);
        /// <summary>通过网络名称发送消息</summary>
        /// <param name="revNetName">网络名称</param>
        /// <param name="context">消息</param>
        /// <returns>int</returns>
        int SendInfoByNetName(string revNetName, object context);
        /// <summary>通过客户端列表发送消息</summary>
        /// <param name="revPoint">连接客户端</param>
        /// <param name="context">消息</param>
        /// <returns>int</returns>
        int SendInfoByPoint(string revPoint, object context);
        /// <summary></summary>
        /// <param name="filterInfo"></param>
        /// <returns></returns>
        int SetFilterInfo(string filterInfo);
        /// <summary>心跳信息设置</summary>
        /// <param name="heart">心跳信息</param>
        /// <returns>int</returns>
        int SetHeartInfo(string heart);
        /// <summary>网络名称设置</summary>
        /// <param name="name">网络名称</param>
        /// <returns>int</returns>
        int SetNetName(string name);
        /// <summary>通知模式 && 接收队列数量设置</summary>
        /// <param name="mode">通知模式</param>
        /// <param name="num">接收队列数量</param>
        /// <returns>int</returns>
        int SetNotifyMode(SktNotifyMode mode, int num);
        /// <summary>发送队列数量设置</summary>
        /// <param name="num">发送队列数量</param>
        /// <returns>int</returns>
        int SetSendQueueCnt(int num);

        /// <summary>
        /// 获取已连接客户端信息
        /// </summary>
        /// <returns></returns>
        List<string> GetClientsInfo();
    }
}