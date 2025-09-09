// ***********************************************************************
// Assembly         : Lead.CPrim.Interfaces.Communicate
// Author           : 17181
// Created          : 03-23-2019
//
// Last Modified By : 17181
// Last Modified On : 04-16-2019
// ***********************************************************************
// <copyright file="IRemote.cs" company="LeadChina">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;

namespace Lead.CPrim.Interfaces
{
    /// <summary>
    ///     Delegate RemoteMsgReved
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <remarks>Lead.CPrim</remarks>
    public delegate void RemoteMsgReved(RemoteMsgInfo msg);

    /// <summary>
    ///     Interface IRemoteClient
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public interface IRemoteClient
    {
        /// <summary>
        ///     Gets or sets the client ip.
        /// </summary>
        /// <value>The client ip.</value>
        /// <remarks>Lead.CPrim</remarks>
        string ClientIp { get; set; }

        /// <summary>
        ///     Gets or sets the name of the client.
        /// </summary>
        /// <value>The name of the client.</value>
        /// <remarks>Lead.CPrim</remarks>
        string ClientName { set; get; }

        /// <summary>
        ///     Gets or sets a value indicating whether [debug enable].
        /// </summary>
        /// <value><c>true</c> if [debug enable]; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool DebugEnable { set; get; }

        /// <summary>
        ///     Gets or sets the filter information.
        /// </summary>
        /// <value>The filter information.</value>
        /// <remarks>Lead.CPrim</remarks>
        string FilterInfo { set; get; }

        /// <summary>
        ///     Gets or sets the heart cyc time.
        /// </summary>
        /// <value>The heart cyc time.</value>
        /// <remarks>Lead.CPrim</remarks>
        int HeartCycTime { set; get; }

        /// <summary>
        ///     Gets or sets a value indicating whether [heart enable].
        /// </summary>
        /// <value><c>true</c> if [heart enable]; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool HeartEnable { set; get; }

        /// <summary>
        ///     Gets or sets a value indicating whether [heart flag].
        /// </summary>
        /// <value><c>true</c> if [heart flag]; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool HeartFlag { set; get; }

        /// <summary>
        ///     Gets or sets the heart information.
        /// </summary>
        /// <value>The heart information.</value>
        /// <remarks>Lead.CPrim</remarks>
        string HeartInfo { set; get; }

        /// <summary>
        ///     Gets a value indicating whether [net conneted].
        /// </summary>
        /// <value><c>true</c> if [net conneted]; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool NetConneted { get; }

        /// <summary>
        ///     Gets or sets the notify mode.
        /// </summary>
        /// <value>The notify mode.</value>
        /// <remarks>Lead.CPrim</remarks>
        RemoteNotifyMode NotifyMode { set; get; }

        /// <summary>
        ///     Gets or sets the port.
        /// </summary>
        /// <value>The port.</value>
        /// <remarks>Lead.CPrim</remarks>
        int Port { set; get; }

        /// <summary>
        ///     Gets or sets the reconnect count.
        /// </summary>
        /// <value>The reconnect count.</value>
        /// <remarks>Lead.CPrim</remarks>
        int ReconnectCnt { set; get; }

        /// <summary>
        ///     Gets or sets the remote object.
        /// </summary>
        /// <value>The remote object.</value>
        /// <remarks>Lead.CPrim</remarks>
        string RemoteObj { set; get; }

        /// <summary>
        ///     Gets or sets the rev queue count.
        /// </summary>
        /// <value>The rev queue count.</value>
        /// <remarks>Lead.CPrim</remarks>
        int RevQueueCnt { set; get; }

        /// <summary>
        ///     Gets or sets the send queue count.
        /// </summary>
        /// <value>The send queue count.</value>
        /// <remarks>Lead.CPrim</remarks>
        int SendQueueCnt { set; get; }

        /// <summary>
        ///     Gets or sets the target addr.
        /// </summary>
        /// <value>The target addr.</value>
        /// <remarks>Lead.CPrim</remarks>
        string TargetAddr { set; get; }

        /// <summary>
        ///     Gets or sets the name of the target.
        /// </summary>
        /// <value>The name of the target.</value>
        /// <remarks>Lead.CPrim</remarks>
        string TargetName { set; get; }

        /// <summary>
        ///     Occurs when [on remote MSG reved].
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        event RemoteMsgReved OnRemoteMsgReved;

        /// <summary>
        ///     Gets the remote MSG information form queue.
        /// </summary>
        /// <param name="itmeOut">The itme out.</param>
        /// <returns>RemoteMsgInfo.</returns>
        /// <remarks>Lead.CPrim</remarks>
        RemoteMsgInfo GetRemoteMsgInfoFormQueue(int itmeOut);

        /// <summary>
        ///     Regs the notify information.
        /// </summary>
        /// <param name="regInfo">The reg information.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int RegNotifyInfo(string regInfo);

        /// <summary>
        ///     Sends the information.
        /// </summary>
        /// <param name="rev">The rev.</param>
        /// <param name="context">The context.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SendInfo(string rev, object context);

        /// <summary>
        ///     Sends the remote MSG information.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SendRemoteMsgInfo(RemoteMsgInfo msg);

        /// <summary>
        ///     Sets the name of the client.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetClientName(string name);

        /// <summary>
        ///     Sets the filter information.
        /// </summary>
        /// <param name="filterInfo">The filter information.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetFilterInfo(string filterInfo);

        /// <summary>
        ///     Sets the heart enable.
        /// </summary>
        /// <param name="flag">if set to <c>true</c> [flag].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetHeartEnable(bool flag);

        /// <summary>
        ///     Sets the heart information.
        /// </summary>
        /// <param name="heart">The heart.</param>
        /// <param name="cycleTime">The cycle time.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetHeartInfo(string heart, int cycleTime);

        /// <summary>
        ///     Sets the notify mode.
        /// </summary>
        /// <param name="mode">The mode.</param>
        /// <param name="num">The number.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetNotifyMode(SktNotifyMode mode, int num);

        /// <summary>
        ///     Sets the send queue count.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetSendQueueCnt(int num);
    }

    /// <summary>
    ///     Interface IRemoteServer
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public interface IRemoteServer
    {
        /// <summary>
        ///     Gets or sets a value indicating whether [debug enable].
        /// </summary>
        /// <value><c>true</c> if [debug enable]; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool DebugEnable { set; get; }

        /// <summary>
        ///     Gets or sets the filter information.
        /// </summary>
        /// <value>The filter information.</value>
        /// <remarks>Lead.CPrim</remarks>
        string FilterInfo { set; get; }

        /// <summary>
        ///     Gets or sets the heart cyc time.
        /// </summary>
        /// <value>The heart cyc time.</value>
        /// <remarks>Lead.CPrim</remarks>
        int HeartCycTime { set; get; }

        /// <summary>
        ///     Gets or sets a value indicating whether [heart enable].
        /// </summary>
        /// <value><c>true</c> if [heart enable]; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool HeartEnable { set; get; }

        /// <summary>
        ///     Gets or sets a value indicating whether [heart flag].
        /// </summary>
        /// <value><c>true</c> if [heart flag]; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool HeartFlag { set; get; }

        /// <summary>
        ///     Gets or sets the heart information.
        /// </summary>
        /// <value>The heart information.</value>
        /// <remarks>Lead.CPrim</remarks>
        string HeartInfo { set; get; }

        /// <summary>
        ///     Gets or sets the notify mode.
        /// </summary>
        /// <value>The notify mode.</value>
        /// <remarks>Lead.CPrim</remarks>
        RemoteNotifyMode NotifyMode { set; get; }

        /// <summary>
        ///     Gets or sets the remote object.
        /// </summary>
        /// <value>The remote object.</value>
        /// <remarks>Lead.CPrim</remarks>
        string RemoteObj { set; get; }

        /// <summary>
        ///     Gets or sets the rev queue count.
        /// </summary>
        /// <value>The rev queue count.</value>
        /// <remarks>Lead.CPrim</remarks>
        int RevQueueCnt { set; get; }

        /// <summary>
        ///     Gets or sets the send queue count.
        /// </summary>
        /// <value>The send queue count.</value>
        /// <remarks>Lead.CPrim</remarks>
        int SendQueueCnt { set; get; }

        /// <summary>
        ///     Gets or sets the server addr.
        /// </summary>
        /// <value>The server addr.</value>
        /// <remarks>Lead.CPrim</remarks>
        string ServerAddr { set; get; }

        /// <summary>
        ///     Gets or sets the name of the server.
        /// </summary>
        /// <value>The name of the server.</value>
        /// <remarks>Lead.CPrim</remarks>
        string ServerName { set; get; }

        /// <summary>
        ///     Gets or sets the server port.
        /// </summary>
        /// <value>The server port.</value>
        /// <remarks>Lead.CPrim</remarks>
        int ServerPort { set; get; }

        /// <summary>
        ///     Occurs when [on remote MSG reved].
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        event RemoteMsgReved OnRemoteMsgReved;

        /// <summary>
        ///     Gets the client names.
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        /// <remarks>Lead.CPrim</remarks>
        List<string> GetClientNames();

        /// <summary>
        ///     Gets the remote MSG information form queue.
        /// </summary>
        /// <param name="itmeOut">The itme out.</param>
        /// <returns>RemoteMsgInfo.</returns>
        /// <remarks>Lead.CPrim</remarks>
        RemoteMsgInfo GetRemoteMsgInfoFormQueue(int itmeOut);

        /// <summary>
        ///     Regs the notify information.
        /// </summary>
        /// <param name="regInfo">The reg information.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int RegNotifyInfo(string regInfo);

        /// <summary>
        ///     Sends the name of the information by net.
        /// </summary>
        /// <param name="revNetName">Name of the rev net.</param>
        /// <param name="context">The context.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SendInfoByNetName(string revNetName, object context);

        /// <summary>
        ///     Sends the information by point.
        /// </summary>
        /// <param name="revPoint">The rev point.</param>
        /// <param name="context">The context.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SendInfoByPoint(string revPoint, object context);

        /// <summary>
        ///     Sends the remote MSG information.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SendRemoteMsgInfo(RemoteMsgInfo msg);

        /// <summary>
        ///     Sets the command update client tasks.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetCmdUpdateClientTasks();

        /// <summary>
        ///     Sets the filter information.
        /// </summary>
        /// <param name="filterInfo">The filter information.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetFilterInfo(string filterInfo);

        /// <summary>
        ///     Sets the heart enable.
        /// </summary>
        /// <param name="flag">if set to <c>true</c> [flag].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetHeartEnable(bool flag);

        /// <summary>
        ///     Sets the heart information.
        /// </summary>
        /// <param name="heart">The heart.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetHeartInfo(string heart);

        /// <summary>
        ///     Sets the notify mode.
        /// </summary>
        /// <param name="mode">The mode.</param>
        /// <param name="num">The number.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetNotifyMode(RemoteNotifyMode mode, int num);

        /// <summary>
        ///     Sets the send queue count.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetSendQueueCnt(int num);

        /// <summary>
        ///     Sets the name of the server.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetServerName(string name);
    }
}