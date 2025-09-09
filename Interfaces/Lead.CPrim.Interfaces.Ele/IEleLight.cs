// ***********************************************************************
// Assembly         : Lead.CPrim.Interfaces.Ele
// Author           : 17181
// Created          : 03-23-2019
//
// Last Modified By : 17181
// Last Modified On : 04-16-2019
// ***********************************************************************
// <copyright file="IEleLight.cs" company="LeadChina">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Lead.CPrim.Interfaces
{
    /// <summary>
    ///     Enum EleLightState
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public enum EleLightState
    {
        /// <summary>
        ///     The running
        /// </summary>
        Running = 1,

        /// <summary>
        ///     The error
        /// </summary>
        Error = 2,

        /// <summary>
        ///     The fetal
        /// </summary>
        Fatal = 3,

        /// <summary>
        ///     The warn
        /// </summary>
        Warn = 4,

        /// <summary>
        ///     The stopping
        /// </summary>
        Stopping = 5,

        /// <summary>
        ///     All off
        /// </summary>
        AllOff = 6
    }

    /// <summary>
    ///     Enum EleLightType
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public enum EleLightType
    {
        /// <summary>
        ///     The tricolour light
        /// </summary>
        Tricolour_Light = 1,

        /// <summary>
        ///     The button light
        /// </summary>
        Button_Light = 2
    }

    /// <summary>
    ///     Interface IEleLight
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public interface IEleLight
    {
        /// <summary>
        ///     Gets or sets the buzz channel.
        /// </summary>
        /// <value>The buzz channel.</value>
        /// <remarks>Lead.CPrim</remarks>
        double BuzzAddress { set; get; }

        /// <summary>
        ///     Gets or sets a value indicating whether [buzz enable].
        /// </summary>
        /// <value><c>true</c> if [buzz enable]; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool BuzzEnable { set; get; }

        /// <summary>
        ///     Gets or sets the green channel.
        /// </summary>
        /// <value>The green channel.</value>
        /// <remarks>Lead.CPrim</remarks>
        double GreenAddress { set; get; }

        /// <summary>
        ///     Gets or sets a value indicating whether [green enable].
        /// </summary>
        /// <value><c>true</c> if [green enable]; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool GreenEnable { set; get; }

        /// <summary>
        ///     Gets or sets the state of the ele light.
        /// </summary>
        /// <value>The state of the ele light.</value>
        /// <remarks>Lead.CPrim</remarks>
        EleLightState LightState { set; get; }

        /// <summary>
        ///     Gets or sets the type of the ele light.
        /// </summary>
        /// <value>The type of the ele light.</value>
        /// <remarks>Lead.CPrim</remarks>
        EleLightType LightType { set; get; }

        /// <summary>
        ///     Gets or sets the red channel.
        /// </summary>
        /// <value>The red channel.</value>
        /// <remarks>Lead.CPrim</remarks>
        double RedAddress { set; get; }

        /// <summary>
        ///     Gets or sets a value indicating whether [red enable].
        /// </summary>
        /// <value><c>true</c> if [red enable]; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool RedEnable { set; get; }

        /// <summary>
        ///     Gets or sets the yellow channel.
        /// </summary>
        /// <value>The yellow channel.</value>
        /// <remarks>Lead.CPrim</remarks>
        double YellowAddress { set; get; }

        /// <summary>
        ///     Gets or sets a value indicating whether [yellow enable].
        /// </summary>
        /// <value><c>true</c> if [yellow enable]; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool YellowEnable { set; get; }

        /// <summary>
        /// 关闭所有系统灯
        /// </summary>
        /// <returns></returns>
        int AllOff();

        /// <summary>
        ///     Debugs this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Debug();

        /// <summary>
        ///     Errors this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Error();

        /// <summary>
        ///     Fatals this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Fatal();

        /// <summary>
        ///     Informs this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Inform();

        /// <summary>
        ///     Reads the buzz.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int ReadBuzz();

        /// <summary>
        ///     Reads the green.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int ReadGreen();

        /// <summary>
        ///     Reads the red.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int ReadRed();

        /// <summary>
        ///     Reads the yellow.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int ReadYellow();

        /// <summary>
        ///     Runnings this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Running();

        /// <summary>
        ///     Stoppings this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Stopping();

        /// <summary>
        ///     Warns this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Warn();

        /// <summary>
        ///     Writes the buzz.
        /// </summary>
        /// <param name="on_off">if set to <c>true</c> [on off].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int WriteBuzz(bool on_off);

        /// <summary>
        ///     Writes the green.
        /// </summary>
        /// <param name="on_off">if set to <c>true</c> [on off].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int WriteGreen(bool on_off);

        /// <summary>
        ///     Writes the red.
        /// </summary>
        /// <param name="on_off">if set to <c>true</c> [on off].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int WriteRed(bool on_off);

        /// <summary>
        ///     Writes the yellow.
        /// </summary>
        /// <param name="on_off">if set to <c>true</c> [on off].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int WriteYellow(bool on_off);
    }
}