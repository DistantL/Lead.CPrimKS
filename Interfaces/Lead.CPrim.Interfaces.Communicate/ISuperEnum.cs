// ***********************************************************************
// Assembly         : Lead.CPrim.Interfaces.Communicate
// Author           : 17181
// Created          : 03-23-2019
//
// Last Modified By : 17181
// Last Modified On : 04-16-2019
// ***********************************************************************
// <copyright file="ISuperEnum.cs" company="LeadChina">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Lead.CPrim.Interfaces
{
    /// <summary>
    ///     Enum StationAlarmLv
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public enum StationAlarmLv
    {
        /// <summary>
        ///     The fatal
        /// </summary>
        Fatal = 1,

        /// <summary>
        ///     The error
        /// </summary>
        Error = 2,

        /// <summary>
        ///     The warn
        /// </summary>
        Warn = 3,

        /// <summary>
        ///     The information
        /// </summary>
        Info = 4,

        /// <summary>
        ///     The debug
        /// </summary>
        Debug = 5,

        /// <summary>
        ///     The trace
        /// </summary>
        Trace = 6,

        /// <summary>
        ///     The other
        /// </summary>
        Other = 100
    }

    /// <summary>
    ///     Enum StationRunMode
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public enum StationRunMode
    {
        /// <summary>
        ///     The single
        /// </summary>
        Single = 1,

        /// <summary>
        ///     The line
        /// </summary>
        Line = 2,

        /// <summary>
        ///     The other
        /// </summary>
        Other = 100
    }

    /// <summary>
    ///     Enum StationRunStatus
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public enum StationRunStatus
    {
        /// <summary>
        ///     The idle
        /// </summary>
        Idle,

        /// <summary>
        ///     The running
        /// </summary>
        Running,

        /// <summary>
        ///     The suspend
        /// </summary>
        Suspend,

        /// <summary>
        ///     The stop
        /// </summary>
        Stop,

        /// <summary>
        ///     The error
        /// </summary>
        Err,

        /// <summary>
        ///     The other
        /// </summary>
        Other = 100
    }

    /// <summary>
    ///     Enum SuperCSType
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public enum SuperCSType
    {
        /// <summary>
        ///     The server
        /// </summary>
        Server = 0,

        /// <summary>
        ///     The client
        /// </summary>
        Client,

        /// <summary>
        ///     The other
        /// </summary>
        Other
    }

    /// <summary>
    ///     Enum SuperNotifyMode
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public enum SuperNotifyMode
    {
        /// <summary>
        ///     The data event
        /// </summary>
        DataEvent,

        /// <summary>
        ///     The data queue
        /// </summary>
        DataQueue,

        /// <summary>
        ///     The other
        /// </summary>
        Other
    }
}