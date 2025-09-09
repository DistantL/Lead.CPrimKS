// ***********************************************************************
// Assembly         : Lead.CPrim.Interfaces.Dev
// Author           : 17181
// Created          : 03-23-2019
//
// Last Modified By : 17181
// Last Modified On : 04-16-2019
// ***********************************************************************
// <copyright file="IModbus.cs" company="LeadChina">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Lead.CPrim.Interfaces.Dev
{
    /// <summary>
    ///     Delegate ModbusMsgReved
    /// </summary>
    /// <param name="send">The send.</param>
    /// <param name="context">The context.</param>
    /// <remarks>Lead.CPrim</remarks>
    public delegate void ModbusMsgReved(string send, object context);

    /// <summary>
    ///     Delegate ModbusVariableChanged
    /// </summary>
    /// <param name="valName">Name of the value.</param>
    /// <param name="valAddr">The value addr.</param>
    /// <param name="valType">Type of the value.</param>
    /// <param name="valLast">The value last.</param>
    /// <param name="valCur">The value current.</param>
    /// <returns>System.Int32.</returns>
    /// <remarks>Lead.CPrim</remarks>
    public delegate int ModbusVariableChanged(string valName, string valAddr, string valType, object valLast,
        object valCur);

    /// <summary>
    ///     Enum ModbusConnMode
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public enum ModbusConnMode
    {
        /// <summary>
        ///     The modbus TCP
        /// </summary>
        ModbusTcp,

        /// <summary>
        ///     The modbus ASCII
        /// </summary>
        ModbusAscii,

        /// <summary>
        ///     The modbus rtu
        /// </summary>
        ModbusRtu
    }

    /// <summary>
    ///     Enum ReverseMode
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public enum ReverseMode
    {
        /// <summary>
        ///     The abcd
        /// </summary>
        ABCD,

        /// <summary>
        ///     The badc
        /// </summary>
        BADC,

        /// <summary>
        ///     The cdab
        /// </summary>
        CDAB,

        /// <summary>
        ///     The dcba
        /// </summary>
        DCBA
    }

    /// <summary>通知模式</summary>
    public enum SktNotifyMode
    {
        /// <summary>事件</summary>
        DataEvent,
        /// <summary>队列</summary>
        DataQueue,
        /// <summary>其它</summary>
        Other
    }

    /// <summary>
    ///     Interface IModbusTcp
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public interface IModbusTcp
    {
        /// <summary>
        ///     Gets or sets the boud rate.
        /// </summary>
        /// <value>The boud rate.</value>
        /// <remarks>Lead.CPrim</remarks>
        string BoudRate { set; get; }

        /// <summary>
        ///     Gets or sets the COM port.
        /// </summary>
        /// <value>The COM port.</value>
        /// <remarks>Lead.CPrim</remarks>
        string ComPort { set; get; }

        /// <summary>
        ///     Gets or sets the connection mode.
        /// </summary>
        /// <value>The connection mode.</value>
        /// <remarks>Lead.CPrim</remarks>
        ModbusConnMode ConnMode { set; get; }

        /// <summary>
        ///     Gets or sets the data bits.
        /// </summary>
        /// <value>The data bits.</value>
        /// <remarks>Lead.CPrim</remarks>
        string DataBits { set; get; }

        /// <summary>
        ///     Gets or sets a value indicating whether [head from0].
        /// </summary>
        /// <value><c>true</c> if [head from0]; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool HeadFrom0 { set; get; }

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
        SktNotifyMode NotifyMode { set; get; }

        /// <summary>
        ///     Gets or sets the port.
        /// </summary>
        /// <value>The port.</value>
        /// <remarks>Lead.CPrim</remarks>
        string Port { set; get; }

        /// <summary>
        ///     Gets or sets the reconnect count.
        /// </summary>
        /// <value>The reconnect count.</value>
        /// <remarks>Lead.CPrim</remarks>
        int ReconnectCnt { set; get; }

        /// <summary>
        ///     Gets or sets a value indicating whether [reverse string].
        /// </summary>
        /// <value><c>true</c> if [reverse string]; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool ReverseString { set; get; }

        /// <summary>
        ///     Gets or sets the serial parity.
        /// </summary>
        /// <value>The serial parity.</value>
        /// <remarks>Lead.CPrim</remarks>
        ParityMode SerialParity { set; get; }

        /// <summary>
        ///     Gets or sets the server ip.
        /// </summary>
        /// <value>The server ip.</value>
        /// <remarks>Lead.CPrim</remarks>
        string ServerIp { set; get; }

        /// <summary>
        ///     Gets or sets the station no.
        /// </summary>
        /// <value>The station no.</value>
        /// <remarks>Lead.CPrim</remarks>
        string StationNo { set; get; }

        /// <summary>
        ///     Gets or sets the stop bits.
        /// </summary>
        /// <value>The stop bits.</value>
        /// <remarks>Lead.CPrim</remarks>
        string StopBits { set; get; }

        /// <summary>
        ///     Gets or sets the string reverse mode.
        /// </summary>
        /// <value>The string reverse mode.</value>
        /// <remarks>Lead.CPrim</remarks>
        ReverseMode StringReverseMode { set; get; }

        /// <summary>
        ///     Occurs when [on MSG reved].
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        event ModbusMsgReved OnMsgReved;

        /// <summary>
        ///     Occurs when [on variable changed].
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        event ModbusVariableChanged OnVariableChanged;

        /// <summary>
        ///     Clears the reg variable addr.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int ClearRegVariableAddr();

        /// <summary>
        ///     Clears the name of the reg variable.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int ClearRegVariableName();

        /// <summary>
        ///     Reads the variable from addr.
        /// </summary>
        /// <param name="valAddr">The value addr.</param>
        /// <param name="valType">Type of the value.</param>
        /// <returns>System.Object.</returns>
        /// <remarks>Lead.CPrim</remarks>
        object ReadVariableFromAddr(string valAddr, DataType valType);

        /// <summary>
        ///     Reads the name of the variable from.
        /// </summary>
        /// <param name="valName">Name of the value.</param>
        /// <returns>System.Object.</returns>
        /// <remarks>Lead.CPrim</remarks>
        object ReadVariableFromName(string valName);

        /// <summary>
        /// </summary>
        /// <returns>[ERROR: invalid expression ReturnTypeName.FullName].</returns>
        /// <remarks>Lead.CPrim</remarks>
        int RegNotifyInfo(string regInfo);

        /// <summary>
        ///     [ERROR: invalid expression MethodName.Words.FirstAsVerbStartingSentence] this instance.
        /// </summary>
        /// <returns>[ERROR: invalid expression ReturnTypeName.FullName].</returns>
        /// <remarks>Lead.CPrim</remarks>
        int RegVariableAddr(string valAddr);

        /// <summary>
        ///     Regs the name of the variable.
        /// </summary>
        /// <param name="valName">Name of the value.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int RegVariableName(string valName);

        /// <summary>
        ///     Removes the reg variable addr.
        /// </summary>
        /// <param name="valAddr">The value addr.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int RemoveRegVariableAddr(string valAddr);

        /// <summary>
        ///     Removes the name of the reg variable.
        /// </summary>
        /// <param name="valName">Name of the value.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int RemoveRegVariableName(string valName);

        /// <summary>
        ///     [ERROR: invalid expression MethodName.Words.FirstAsVerbStartingSentence] this instance.
        /// </summary>
        /// <returns>[ERROR: invalid expression ReturnTypeName.FullName].</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetDataChangedNotifyMode(DataChangedNotify mode);

        /// <summary>
        ///     Sets the notify mode.
        /// </summary>
        /// <param name="mode">The mode.</param>
        /// <param name="num">The number.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetNotifyMode(SktNotifyMode mode, int num);

        /// <summary>
        ///     Writes the variable from addr.
        /// </summary>
        /// <param name="valAddr">The value addr.</param>
        /// <param name="valType">Type of the value.</param>
        /// <param name="val">The value.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int WriteVariableFromAddr(string valAddr, DataType valType, object val);

        /// <summary>
        ///     Writes the name of the variable from.
        /// </summary>
        /// <param name="valName">Name of the value.</param>
        /// <param name="val">The value.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int WriteVariableFromName(string valName, object val);
    }
}