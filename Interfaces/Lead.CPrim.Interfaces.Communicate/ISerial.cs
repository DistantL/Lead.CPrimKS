// ***********************************************************************
// Assembly         : Lead.CPrim.Interfaces.Communicate
// Author           : 17181
// Created          : 03-23-2019
//
// Last Modified By : 17181
// Last Modified On : 04-16-2019
// ***********************************************************************
// <copyright file="ISerial.cs" company="LeadChina">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Lead.CPrim.Interfaces.Communicate
{
    /// <summary>
    ///     Delegate SerialMsgReved
    /// </summary>
    /// <param name="send">The send.</param>
    /// <param name="context">The context.</param>
    /// <remarks>Lead.CPrim</remarks>
    public delegate void SerialMsgReved(string send, object context);

    /// <summary>
    ///     Enum SerialNotifyMode
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public enum SerialNotifyMode
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

    /// <summary>
    ///     Interface ISerial
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public interface ISerial
    {
        /// <summary>
        ///     Gets or sets the boud rate.
        /// </summary>
        /// <value>The boud rate.</value>
        /// <remarks>Lead.CPrim</remarks>
        string BoudRate { set; get; }

        /// <summary>
        ///     Gets or sets a value indicating whether [cal check code].
        /// </summary>
        /// <value><c>true</c> if [cal check code]; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool CalCheckCode { set; get; }

        /// <summary>
        ///     Gets or sets the code1.
        /// </summary>
        /// <value>The code1.</value>
        /// <remarks>Lead.CPrim</remarks>
        string Code1 { set; get; }

        /// <summary>
        ///     Gets or sets the code2.
        /// </summary>
        /// <value>The code2.</value>
        /// <remarks>Lead.CPrim</remarks>
        string Code2 { set; get; }

        /// <summary>
        ///     Gets or sets the COM port.
        /// </summary>
        /// <value>The COM port.</value>
        /// <remarks>Lead.CPrim</remarks>
        string ComPort { set; get; }

        /// <summary>
        ///     Gets or sets the data bits.
        /// </summary>
        /// <value>The data bits.</value>
        /// <remarks>Lead.CPrim</remarks>
        string DataBits { set; get; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is binary.
        /// </summary>
        /// <value><c>true</c> if this instance is binary; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool IsBinary { set; get; }

        /// <summary>
        ///     Gets or sets the name of the net.
        /// </summary>
        /// <value>The name of the net.</value>
        /// <remarks>Lead.CPrim</remarks>
        string NetName { set; get; }

        /// <summary>
        ///     Gets or sets the notify mode.
        /// </summary>
        /// <value>The notify mode.</value>
        /// <remarks>Lead.CPrim</remarks>
        SerialNotifyMode NotifyMode { set; get; }

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
        ///     Gets or sets the serial parity.
        /// </summary>
        /// <value>The serial parity.</value>
        /// <remarks>Lead.CPrim</remarks>
        ParityMode SerialParity { set; get; }

        /// <summary>
        ///     Gets or sets the stop bits.
        /// </summary>
        /// <value>The stop bits.</value>
        /// <remarks>Lead.CPrim</remarks>
        string StopBits { set; get; }

        /// <summary>
        ///     Occurs when [on MSG reved].
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        event SerialMsgReved OnMsgReved;

        /// <summary>
        ///     Clears the event on MSG reved.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int ClearEventOnMsgReved();

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
        ///     Sets the filter information.
        /// </summary>
        /// <param name="filterInfo">The filter information.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetFilterInfo(string filterInfo);

        /// <summary>
        ///     Sets the name of the net.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetNetName(string name);

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
}