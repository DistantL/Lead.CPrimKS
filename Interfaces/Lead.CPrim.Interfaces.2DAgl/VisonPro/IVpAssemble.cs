// ***********************************************************************
// Assembly         : Lead.CPrim.2DAgl
// Author           : 17181
// Created          : 03-23-2019
//
// Last Modified By : 17181
// Last Modified On : 04-16-2019
// ***********************************************************************
// <copyright file="IVpAssemble.cs" company="LeadChina">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Lead.CPrim.Interfaces
{
    /// <summary>
    ///     Delegate MotionDelegate
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    /// <remarks>Lead.CPrim</remarks>
    public delegate bool MotionDelegate(object sender);

    /// <summary>
    ///     Delegate UpdateDelegate
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <remarks>Lead.CPrim</remarks>
    public delegate void UpdateDelegate(object sender);

    /// <summary>
    ///     Interface IVpAssemble
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public interface IVpAssemble
    {
        /// <summary>
        ///     Occurs when [on align result recieved].
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        event UpdateDelegate OnAlignResultRecieved;

        /// <summary>
        ///     Occurs when [on motion move].
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        event MotionDelegate OnMotionMove;

        /// <summary>
        ///     Occurs when [on process finished].
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        event UpdateDelegate OnProcessFinished;

        /// <summary>
        ///     Occurs when [on repeat result recieved].
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        event UpdateDelegate OnRepeatResultRecieved;

        /// <summary>
        ///     Occurs when [on station offset recieved].
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        event UpdateDelegate OnStationOffsetRecieved;

        /// <summary>
        ///     Sets the capture.
        /// </summary>
        /// <param name="clampIndex">Index of the clamp.</param>
        /// <param name="targetIndex">Index of the target.</param>
        /// <param name="stationIndex">Index of the station.</param>
        /// <param name="TrayID">The tray identifier.</param>
        /// <param name="Dry_run">if set to <c>true</c> [dry run].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <remarks>Lead.CPrim</remarks>
        bool SetCapture(int clampIndex = 0, int targetIndex = 0, int stationIndex = 0, string TrayID = "Test",
            bool Dry_run = true);
    }
}