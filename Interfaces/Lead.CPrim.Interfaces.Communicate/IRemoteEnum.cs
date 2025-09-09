// ***********************************************************************
// Assembly         : Lead.CPrim.Interfaces.Communicate
// Author           : 17181
// Created          : 03-23-2019
//
// Last Modified By : 17181
// Last Modified On : 04-16-2019
// ***********************************************************************
// <copyright file="IRemoteEnum.cs" company="LeadChina">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Lead.CPrim.Interfaces
{
    /// <summary>
    ///     Enum RemoteCSType
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public enum RemoteCSType
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
    ///     Enum RemoteNotifyMode
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public enum RemoteNotifyMode
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