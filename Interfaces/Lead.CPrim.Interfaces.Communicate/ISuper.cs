// ***********************************************************************
// Assembly         : Lead.CPrim.Interfaces.Communicate
// Author           : 17181
// Created          : 03-23-2019
//
// Last Modified By : 17181
// Last Modified On : 04-16-2019
// ***********************************************************************
// <copyright file="ISuper.cs" company="LeadChina">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;

namespace Lead.CPrim.Interfaces
{
    /// <summary>
    ///     Delegate SuperMsgReved
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <remarks>Lead.CPrim</remarks>
    public delegate void SuperMsgReved(SuperMsgInfo msg);

    /// <summary>
    ///     Interface ISuperClient
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public interface ISuperClient
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
        ///     Gets or sets a value indicating whether [log display].
        /// </summary>
        /// <value><c>true</c> if [log display]; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool LogDisplay { set; get; }

        /// <summary>
        ///     Gets or sets a value indicating whether [log enable].
        /// </summary>
        /// <value><c>true</c> if [log enable]; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool LogEnable { set; get; }

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
        SuperNotifyMode NotifyMode { set; get; }

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
        ///     Gets or sets the super object.
        /// </summary>
        /// <value>The super object.</value>
        /// <remarks>Lead.CPrim</remarks>
        string SuperObj { set; get; }

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
        ///     Occurs when [on super MSG reved].
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        event SuperMsgReved OnSuperMsgReved;

        /// <summary>
        ///     Gets the super MSG information form queue.
        /// </summary>
        /// <param name="itmeOut">The itme out.</param>
        /// <returns>SuperMsgInfo.</returns>
        /// <remarks>Lead.CPrim</remarks>
        SuperMsgInfo GetSuperMsgInfoFormQueue(int itmeOut);

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
        /// <param name="context">The context.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SendInfo(object context);

        int SendInfo<T>(T obj);

        /// <summary>
        ///     Sends the result information.
        /// </summary>
        /// <param name="resultInfo">The result information.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SendResultInfo(string resultInfo);

        /// <summary>
        ///     Sends the station information.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SendStationInfo(string info);

        /// <summary>
        ///     Sends the state of the station.
        /// </summary>
        /// <param name="stateInfo">The state information.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SendStationState(string stateInfo);

        /// <summary>
        ///     Sends the station time.
        /// </summary>
        /// <param name="stationTime">The station time.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SendStationTime(string stationTime);

        /// <summary>
        ///     Sends the super MSG information.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SendSuperMsgInfo(SuperMsgInfo msg);

        /// <summary>
        ///     Sends the task information.
        /// </summary>
        /// <param name="taskInfo">The task information.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SendTaskInfo(string taskInfo);

        /// <summary>
        ///     Sets the name of the client.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetClientName(string name);

        /// <summary>
        ///     Sets the heart enable.
        /// </summary>
        /// <param name="flag">if set to <c>true</c> [flag].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetHeartEnable(bool flag);

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

        /// <summary>
        ///     Sets the station alarm lv.
        /// </summary>
        /// <param name="alarmLv">The alarm lv.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetStationAlarmLv(StationAlarmLv alarmLv);

        /// <summary>
        ///     Sets the station run mode.
        /// </summary>
        /// <param name="runMode">The run mode.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetStationRunMode(StationRunMode runMode);

        /// <summary>
        ///     Sets the station runstatus.
        /// </summary>
        /// <param name="runStatus">The run status.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetStationRunstatus(StationRunStatus runStatus);
        int SendStationRecipe(string msg);
    }

    /// <summary>
    ///     Interface ISuperServer
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public interface ISuperServer
    {
        /// <summary>
        ///     Gets or sets the heart cyc time.
        /// </summary>
        /// <value>The heart cyc time.</value>
        /// <remarks>Lead.CPrim</remarks>
        int HeartCycTime { set; get; }

        /// <summary>
        ///     Gets or sets a value indicating whether [log display].
        /// </summary>
        /// <value><c>true</c> if [log display]; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool LogDisplay { set; get; }

        /// <summary>
        ///     Gets or sets a value indicating whether [log enable].
        /// </summary>
        /// <value><c>true</c> if [log enable]; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool LogEnable { set; get; }

        /// <summary>
        ///     Gets or sets the notify mode.
        /// </summary>
        /// <value>The notify mode.</value>
        /// <remarks>Lead.CPrim</remarks>
        SuperNotifyMode NotifyMode { set; get; }

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
        ///     Occurs when [on super MSG reved].
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        event SuperMsgReved OnSuperMsgReved;

        /// <summary>
        ///     Gets the client names.
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        /// <remarks>Lead.CPrim</remarks>
        List<string> GetClientNames();

        /// <summary>
        ///     Gets the super MSG information form queue.
        /// </summary>
        /// <param name="itmeOut">The itme out.</param>
        /// <returns>SuperMsgInfo.</returns>
        /// <remarks>Lead.CPrim</remarks>
        SuperMsgInfo GetSuperMsgInfoFormQueue(int itmeOut);

        /// <summary>
        ///     Pushes the MSG information.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int PushMsgInfo(string msg);

        /// <summary>
        ///     Pushes the MSG information.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int PushMsgInfo(SuperMsgInfo msg);

        /// <summary>
        ///     Regs the notify information.
        /// </summary>
        /// <param name="regInfo">The reg information.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int RegNotifyInfo(string regInfo);

        /// <summary>
        ///     Sends the CMD2 client.
        /// </summary>
        /// <param name="targetName">Name of the target.</param>
        /// <param name="cmd">The command.</param>
        /// <remarks>Lead.CPrim</remarks>
        void SendCmd2Client(string targetName, string cmd);

        /// <summary>
        ///     Sends the name of the information by net.
        /// </summary>
        /// <param name="revNetName">Name of the rev net.</param>
        /// <param name="context">The context.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SendInfoByNetName(string revNetName, object context);

        /// <summary>
        ///     Sends the super MSG information.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SendSuperMsgInfo(SuperMsgInfo msg);

        /// <summary>
        ///     Sets the command update client tasks.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetCmdUpdateClientTasks();

        /// <summary>
        ///     Sets the notify mode.
        /// </summary>
        /// <param name="mode">The mode.</param>
        /// <param name="num">The number.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetNotifyMode(SuperNotifyMode mode, int num);

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

    /// <summary>
    ///     Class SuperMsgInfo.
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public class SuperMsgInfo
    {
        /// <summary>
        ///     The command
        /// </summary>
        public string Cmd;

        /// <summary>
        ///     The MSG
        /// </summary>
        public string Msg;

        /// <summary>
        ///     The object
        /// </summary>
        public object Obj;

        /// <summary>
        ///     The source name
        /// </summary>
        public string SrcName;

        /// <summary>
        ///     The target name
        /// </summary>
        public string TargetName;
    }
}