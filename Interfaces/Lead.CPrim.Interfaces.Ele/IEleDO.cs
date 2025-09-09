// ***********************************************************************
// Assembly         : Lead.CPrim.Interfaces.Ele
// Author           : 17181
// Created          : 03-23-2019
//
// Last Modified By : 17181
// Last Modified On : 04-16-2019
// ***********************************************************************
// <copyright file="IEleDO.cs" company="LeadChina">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Lead.CPrim.Interfaces
{
    /// <summary>
    ///     Enum EleDOType
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public enum EleDOType
    {
        /// <summary>
        ///     The no
        /// </summary>
        NO = 1,

        /// <summary>
        ///     The nc
        /// </summary>
        NC = 2
    }

    /// <summary>
    ///     Interface IEleDO
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public interface IEleDO
    {
        /// <summary>
        ///     Gets or sets the do channel.
        /// </summary>
        /// <value>The do channel.</value>
        /// <remarks>Lead.CPrim</remarks>
        double DoAddress { set; get; }

        /// <summary>
        ///     Gets or sets a value indicating whether [do enable].
        /// </summary>
        /// <value><c>true</c> if [do enable]; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool DoEnable { set; get; }

        /// <summary>
        ///     Gets or sets the type of the ele do.
        /// </summary>
        /// <value>The type of the ele do.</value>
        /// <remarks>Lead.CPrim</remarks>
        EleDOType DoType { set; get; }

        /// <summary>接口【IEleDI】线号</summary>
        string LineMark { get; set; }

        /// <summary>
        ///     Reads this instance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <remarks>Lead.CPrim</remarks>
        bool Read();

        int Toggle();

        /// <summary>
        ///     Writes the specified value.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Write(bool value);
    }
}