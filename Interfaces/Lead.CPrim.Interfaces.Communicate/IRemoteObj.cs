// ***********************************************************************
// Assembly         : Lead.CPrim.Interfaces.Communicate
// Author           : 17181
// Created          : 03-23-2019
//
// Last Modified By : 17181
// Last Modified On : 04-16-2019
// ***********************************************************************
// <copyright file="IRemoteObj.cs" company="LeadChina">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;

namespace Lead.CPrim.Interfaces
{
    /// <summary>
    ///     Delegate RemoteDelegate
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <returns>RemoteMsgInfo.</returns>
    /// <remarks>Lead.CPrim</remarks>
    public delegate RemoteMsgInfo RemoteDelegate(RemoteMsgInfo msg);

    /// <summary>
    ///     Class RemoteMsgInfo.
    ///     Implements the <see cref="System.MarshalByRefObject" />
    /// </summary>
    /// <seealso cref="System.MarshalByRefObject" />
    /// <remarks>Lead.CPrim</remarks>
    public class RemoteMsgInfo : MarshalByRefObject
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

    /// <summary>
    ///     Class RemotingObject.
    ///     Implements the <see cref="System.MarshalByRefObject" />
    /// </summary>
    /// <seealso cref="System.MarshalByRefObject" />
    /// <remarks>Lead.CPrim</remarks>
    public class RemotingObject : MarshalByRefObject
    {
        /// <summary>
        ///     The clients
        /// </summary>
        public List<string> Clients = new List<string>();

        /// <summary>
        ///     The count
        /// </summary>
        public int Cnt = 0;

        public event RemoteDelegate SubscribeAtClient;

        /// <summary>
        ///     Occurs when [subscribe at server].
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public event RemoteDelegate SubscribeAtServer;

        /// <summary>
        ///     Gets the server event list.
        /// </summary>
        /// <returns>Delegate[].</returns>
        /// <remarks>Lead.CPrim</remarks>
        public Delegate[] GetServerEventList()
        {
            return SubscribeAtClient.GetInvocationList();
        }

        /// <summary>
        ///     获取控制此实例的生存期策略的生存期服务对象。
        /// </summary>
        /// <returns>
        ///     <see cref="T:System.Runtime.Remoting.Lifetime.ILease" /> 类型的对象，用于控制此实例的生存期策略。这是此实例当前的生存期服务对象（如果存在）；否则为初始化为
        ///     <see cref="P:System.Runtime.Remoting.Lifetime.LifetimeServices.LeaseManagerPollTime" /> 属性的值的新生存期服务对象。
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Flags="RemotingConfiguration, Infrastructure" />
        /// </PermissionSet>
        /// <remarks>Lead.CPrim</remarks>
        public override object InitializeLifetimeService()
        {
            return null;
        }

        /// <summary>
        ///     Triggers at client.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <remarks>Lead.CPrim</remarks>
        public void TriggerAtClient(RemoteMsgInfo msg)
        {
            if (SubscribeAtServer != null) SubscribeAtServer(msg);
        }

        /// <summary>
        ///     Triggers at server.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <remarks>Lead.CPrim</remarks>
        public void TriggerAtServer(RemoteMsgInfo msg)
        {
            if (SubscribeAtClient != null) SubscribeAtClient(msg);
        }
    }

    /// <summary>
    ///     Class Swap.
    ///     Implements the <see cref="System.MarshalByRefObject" />
    /// </summary>
    /// <seealso cref="System.MarshalByRefObject" />
    /// <remarks>Lead.CPrim</remarks>
    public class Swap : MarshalByRefObject
    {
        /// <summary>
        ///     Occurs when [swap subscribe at client].
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public event RemoteDelegate SwapSubscribeAtClient;

        /// <summary>
        ///     Gets the string.
        /// </summary>
        /// <returns>System.String.</returns>
        /// <remarks>Lead.CPrim</remarks>
        public string GetString()
        {
            return "Swap";
        }

        /// <summary>
        ///     获取控制此实例的生存期策略的生存期服务对象。
        /// </summary>
        /// <returns>
        ///     <see cref="T:System.Runtime.Remoting.Lifetime.ILease" /> 类型的对象，用于控制此实例的生存期策略。这是此实例当前的生存期服务对象（如果存在）；否则为初始化为
        ///     <see cref="P:System.Runtime.Remoting.Lifetime.LifetimeServices.LeaseManagerPollTime" /> 属性的值的新生存期服务对象。
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Flags="RemotingConfiguration, Infrastructure" />
        /// </PermissionSet>
        /// <remarks>Lead.CPrim</remarks>
        public override object InitializeLifetimeService()
        {
            return null;
        }

        /// <summary>
        ///     Triggers at server swap event.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns>RemoteMsgInfo.</returns>
        /// <remarks>Lead.CPrim</remarks>
        public RemoteMsgInfo TriggerAtServerSwapEvent(RemoteMsgInfo msg)
        {
            if (SwapSubscribeAtClient != null) return SwapSubscribeAtClient(msg);
            return null;
        }
    }
}