// ***********************************************************************
// Assembly         : Lead.CPrim.2DAgl
// Author           : 17181
// Created          : 03-23-2019
//
// Last Modified By : 17181
// Last Modified On : 04-16-2019
// ***********************************************************************
// <copyright file="IVpDetector.cs" company="LeadChina">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Lead.CPrim.Interfaces
{
    /// <summary>
    ///     Interface IVpDetector
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public interface IVpDetector
    {
        /// <summary>
        ///     Sets the capture.
        /// </summary>
        /// <param name="result">if set to <c>true</c> [result].</param>
        /// <param name="TaryID">The tary identifier.</param>
        /// <param name="DryRun">if set to <c>true</c> [dry run].</param>
        /// <param name="Pic1Resut">if set to <c>true</c> [pic1 resut].</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="r">The r.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <remarks>Lead.CPrim</remarks>
        bool SetCapture(out bool result, string TaryID = "Test", bool DryRun = true, bool Pic1Resut = false,
            double x = 0, double y = 0, double r = 0);
    }
}