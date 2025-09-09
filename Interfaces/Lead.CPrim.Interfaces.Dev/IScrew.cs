// ***********************************************************************
// Assembly         : Lead.CPrim.Interfaces.Dev
// Author           : 17181
// Created          : 03-23-2019
//
// Last Modified By : 17181
// Last Modified On : 04-16-2019
// ***********************************************************************
// <copyright file="IScrew.cs" company="LeadChina">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Lead.CPrim.Interfaces
{
    /// <summary>
    ///     Interface IScrew
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public interface IScrew
    {
        /// <summary>
        ///     Gets or sets the connection mode.
        /// </summary>
        /// <value>The connection mode.</value>
        /// <remarks>Lead.CPrim</remarks>
        ConnectionMode ConnMode { set; get; }

        /// <summary>
        ///     Gets or sets the usb device.
        /// </summary>
        /// <value>The usb device.</value>
        /// <remarks>Lead.CPrim</remarks>
        string UsbDevice { set; get; }

        /// <summary>
        ///     Gets or sets the COM port.
        /// </summary>
        /// <value>The COM port.</value>
        /// <remarks>Lead.CPrim</remarks>
        string ComPort { set; get; }

        /// <summary>
        ///     Gets or sets the boud rate.
        /// </summary>
        /// <value>The boud rate.</value>
        /// <remarks>Lead.CPrim</remarks>
        string BoudRate { set; get; }

        /// <summary>
        ///     Gets or sets the data bits.
        /// </summary>
        /// <value>The data bits.</value>
        /// <remarks>Lead.CPrim</remarks>
        string DataBits { set; get; }

        /// <summary>
        ///     Gets or sets the stop bits.
        /// </summary>
        /// <value>The stop bits.</value>
        /// <remarks>Lead.CPrim</remarks>
        string StopBits { set; get; }

        /// <summary>
        ///     Gets or sets the serial parity.
        /// </summary>
        /// <value>The serial parity.</value>
        /// <remarks>Lead.CPrim</remarks>
        ParityMode SerialParity { set; get; }

        /// <summary>
        ///     Gets or sets the last summary.
        /// </summary>
        /// <value>The last summary.</value>
        /// <remarks>Lead.CPrim</remarks>
        string LastSummary { set; get; }

        /// <summary>
        ///     Gets or sets the control status.
        /// </summary>
        /// <value>The control status.</value>
        /// <remarks>Lead.CPrim</remarks>
        string ControlStatus { set; get; }

        /// <summary>
        ///     Gets or sets the save file path.
        /// </summary>
        /// <value>The save file path.</value>
        /// <remarks>Lead.CPrim</remarks>
        string SaveFilePath { set; get; }

        /// <summary>
        ///     Starts the screw.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int StartScrew();

        /// <summary>
        ///     Starts the screw.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int StartScrew(int timeout);

        /// <summary>
        ///     Resets the tool.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int ResetTool();

        /// <summary>
        ///     Starts the un screw.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int StartUnScrew();

        /// <summary>
        ///     Sends the information.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="reply">The reply.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SendInfo(string info, int timeout, out string reply);

        /// <summary>
        ///     Gets the trace.
        /// </summary>
        /// <param name="saveFile">if set to <c>true</c> [save file].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int GetTrace(bool saveFile);
    }

    /// <summary>
    ///     Enum ConnectionMode
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public enum ConnectionMode
    {
        /// <summary>
        ///     The serial
        /// </summary>
        Serial = 1,

        /// <summary>
        ///     The usb
        /// </summary>
        USB = 2,

        /// <summary>
        ///     The other
        /// </summary>
        Other = 100
    }
}