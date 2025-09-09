// ***********************************************************************
// Assembly         : Lead.CPrim.2DAgl
// Author           : 17181
// Created          : 03-23-2019
//
// Last Modified By : 17181
// Last Modified On : 04-16-2019
// ***********************************************************************
// <copyright file="VpDefines.cs" company="LeadChina">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace Lead.CPrim.Interfaces
{
    /// <summary>
    ///     Struct MotionInfo
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public struct MotionInfo
    {
        /// <summary>
        ///     The clamp index
        /// </summary>
        public int clampIndex;

        /// <summary>
        ///     The station index
        /// </summary>
        public int stationIndex;

        /// <summary>
        ///     The offset
        /// </summary>
        public VpPoint3D offset;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MotionInfo" /> struct.
        /// </summary>
        /// <param name="clmpIndex">Index of the CLMP.</param>
        /// <param name="stIndex">Index of the st.</param>
        /// <param name="point">The point.</param>
        /// <remarks>Lead.CPrim</remarks>
        public MotionInfo(int clmpIndex, int stIndex, VpPoint3D point)
        {
            clampIndex = clmpIndex;
            stationIndex = stIndex;
            offset = point;
        }
    }

    /// <summary>
    ///     Struct ProcessInfo
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public struct ProcessInfo
    {
        /// <summary>
        ///     The clamp index
        /// </summary>
        public int clampIndex;

        /// <summary>
        ///     The station index
        /// </summary>
        public int stationIndex;

        /// <summary>
        ///     The result
        /// </summary>
        public bool result;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProcessInfo" /> struct.
        /// </summary>
        /// <param name="clmpIndex">Index of the CLMP.</param>
        /// <param name="stIndex">Index of the st.</param>
        /// <param name="flag">if set to <c>true</c> [flag].</param>
        /// <remarks>Lead.CPrim</remarks>
        public ProcessInfo(int clmpIndex, int stIndex, bool flag)
        {
            clampIndex = clmpIndex;
            stationIndex = stIndex;
            result = flag;
        }
    }

    /// <summary>
    ///     Struct VpAlignResult
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public struct VpAlignResult
    {
        /// <summary>
        ///     The clamp index
        /// </summary>
        public int clampIndex;

        /// <summary>
        ///     The result
        /// </summary>
        public VpAlignEnum Result;

        /// <summary>
        ///     The offset
        /// </summary>
        public VpPoint3D Offset;

        /// <summary>
        ///     Initializes a new instance of the <see cref="VpAlignResult" /> struct.
        /// </summary>
        /// <param name="clmpIndex">Index of the CLMP.</param>
        /// <param name="result">The result.</param>
        /// <param name="offset">The offset.</param>
        /// <remarks>Lead.CPrim</remarks>
        public VpAlignResult(int clmpIndex, VpAlignEnum result, VpPoint3D offset)
        {
            clampIndex = clmpIndex;
            Result = result;
            Offset = new VpPoint3D(offset.X, offset.Y, offset.R);
        }
    }

    /// <summary>
    ///     Struct VpPoint3D
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public struct VpPoint3D
    {
        /// <summary>
        ///     The x
        /// </summary>
        public double X;

        /// <summary>
        ///     The y
        /// </summary>
        public double Y;

        /// <summary>
        ///     The r
        /// </summary>
        public double R;

        /// <summary>
        ///     Initializes a new instance of the <see cref="VpPoint3D" /> struct.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="r">The r.</param>
        /// <remarks>Lead.CPrim</remarks>
        public VpPoint3D(double x, double y, double r)
        {
            X = x;
            Y = y;
            R = r;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="VpPoint3D" /> struct.
        /// </summary>
        /// <param name="pt1">The PT1.</param>
        /// <remarks>Lead.CPrim</remarks>
        public VpPoint3D(VpPoint3D pt1)
        {
            X = pt1.X;
            Y = pt1.Y;
            R = pt1.R;
        }

        /// <summary>
        ///     Implements the - operator.
        /// </summary>
        /// <param name="pt1">The PT1.</param>
        /// <param name="pt2">The PT2.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks>Lead.CPrim</remarks>
        public static VpPoint3D operator -(VpPoint3D pt1, VpPoint3D pt2)
        {
            var pt3 = new VpPoint3D(pt1.X - pt2.X, pt1.Y - pt2.Y, pt1.R - pt2.R);
            return pt3;
        }

        /// <summary>
        ///     Implements the + operator.
        /// </summary>
        /// <param name="pt1">The PT1.</param>
        /// <param name="pt2">The PT2.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks>Lead.CPrim</remarks>
        public static VpPoint3D operator +(VpPoint3D pt1, VpPoint3D pt2)
        {
            var pt3 = new VpPoint3D(pt1.X + pt2.X, pt1.Y + pt2.Y, pt1.R + pt2.R);
            return pt3;
        }

        /// <summary>
        ///     Implements the &lt; operator.
        /// </summary>
        /// <param name="pt1">The PT1.</param>
        /// <param name="pt2">The PT2.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks>Lead.CPrim</remarks>
        public static bool operator <(VpPoint3D pt1, VpPoint3D pt2)
        {
            return Math.Abs(pt1.X) < Math.Abs(pt2.X) && Math.Abs(pt1.Y) < Math.Abs(pt2.Y) &&
                   Math.Abs(pt1.R) < Math.Abs(pt2.R);
        }

        /// <summary>
        ///     Implements the &gt; operator.
        /// </summary>
        /// <param name="pt1">The PT1.</param>
        /// <param name="pt2">The PT2.</param>
        /// <returns>The result of the operator.</returns>
        /// <remarks>Lead.CPrim</remarks>
        public static bool operator >(VpPoint3D pt1, VpPoint3D pt2)
        {
            return Math.Abs(pt1.X) > Math.Abs(pt2.X) || Math.Abs(pt1.Y) > Math.Abs(pt2.Y) ||
                   Math.Abs(pt1.R) > Math.Abs(pt2.R);
        }
    }
}