// ***********************************************************************
// Assembly         : Lead.CPrim.Interfaces.Dev
// Author           : 17181
// Created          : 03-23-2019
//
// Last Modified By : 17181
// Last Modified On : 04-16-2019
// ***********************************************************************
// <copyright file="ILight.cs" company="LeadChina">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Lead.CPrim.Interfaces
{
    /// <summary>
    ///     Interface ILight
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public interface ILight
    {
        /// <summary>
        ///     Sets the channel off.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <remarks>Lead.CPrim</remarks>
        bool SetChannelOff(int channel);

        /// <summary>
        ///     Sets the channel on.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <remarks>Lead.CPrim</remarks>
        bool SetChannelOn(int channel);

        /// <summary>
        ///     Sets the intensity.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="intensity">The intensity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <remarks>Lead.CPrim</remarks>
        bool SetIntensity(int channel, int intensity);
    }

    /// <summary>
    ///     Class Communication.
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public class Communication
    {
        /// <summary>
        ///     The COM name
        /// </summary>
        public string ComName;

        /// <summary>
        ///     The sn
        /// </summary>
        public string SN;
    }

    /// <summary>
    ///     Class Controller.
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public class Controller
    {
        /// <summary>
        ///     The channel index
        /// </summary>
        public int ChannelIndex;

        /// <summary>
        ///     The intensity
        /// </summary>
        public int Intensity;
    }
}