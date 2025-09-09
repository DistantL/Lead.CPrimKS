// ***********************************************************************
// Assembly         : Lead.CPrim.Interfaces.Dev
// Author           : 17181
// Created          : 03-23-2019
//
// Last Modified By : 17181
// Last Modified On : 04-16-2019
// ***********************************************************************
// <copyright file="ICamera.cs" company="LeadChina">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Drawing;

namespace Lead.CPrim.Interfaces
{
    /// <summary>
    ///     Delegate ImgArrived
    /// </summary>
    /// <param name="img">The img.</param>
    /// <remarks>Lead.CPrim</remarks>
    public delegate void ImgArrived(object img);

    /// <summary>
    ///     Interface ICamera
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public interface ICamera
    {
        /// <summary>
        ///     Gets or sets the img bit depth.
        /// </summary>
        /// <value>The img bit depth.</value>
        /// <remarks>Lead.CPrim</remarks>
        int ImgBitDepth { set; get; }

        /// <summary>
        ///     Gets or sets the height of the img.
        /// </summary>
        /// <value>The height of the img.</value>
        /// <remarks>Lead.CPrim</remarks>
        int ImgHeight { set; get; }

        /// <summary>
        ///     Gets or sets the width of the img.
        /// </summary>
        /// <value>The width of the img.</value>
        /// <remarks>Lead.CPrim</remarks>
        int ImgWidth { set; get; }

        /// <summary>
        ///     Occurs when [on img arrived].
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        event ImgArrived OnImgArrived;

        /// <summary>
        ///     Gets the one frame by soft command.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns>System.Object.</returns>
        /// <remarks>Lead.CPrim</remarks>
        object GetOneFrameBySoftCmd(int timeout);

        /// <summary>
        ///     Sets the ei mode.
        /// </summary>
        /// <param name="EIMode">The ei mode.</param>
        /// <remarks>Lead.CPrim</remarks>
        void SetEIMode(int EIMode);

        /// <summary>
        ///     Sets the frame.
        /// </summary>
        /// <param name="fCnt">The f count.</param>
        /// <remarks>Lead.CPrim</remarks>
        void SetFrame(int fCnt);

        /// <summary>
        ///     Sets the img exposure time.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <remarks>Lead.CPrim</remarks>
        void SetImgExposureTime(int time);

        /// <summary>
        ///     Sets the img parameter.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="bitDepth">The bit depth.</param>
        /// <remarks>Lead.CPrim</remarks>
        void SetImgParam(int width, int height, int bitDepth);

        /// <summary>
        ///     Sets the notify enable.
        /// </summary>
        /// <param name="falg">if set to <c>true</c> [falg].</param>
        /// <remarks>Lead.CPrim</remarks>
        void SetNotifyEnable(bool falg);

        /// <summary>
        ///     Setqs the queue count.
        /// </summary>
        /// <param name="mode">The mode.</param>
        /// <param name="qCnt">The q count.</param>
        /// <remarks>Lead.CPrim</remarks>
        void SetqQueueCnt(int mode, int qCnt);

        /// <summary>
        ///     Sets the sh mode.
        /// </summary>
        /// <param name="SHMode">The sh mode.</param>
        /// <remarks>Lead.CPrim</remarks>
        void SetSHMode(int SHMode);

        /// <summary>
        ///     Snaps the grab abort.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SnapGrabAbort();

        /// <summary>
        ///     Starts the grab.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int StartGrab();

        /// <summary>
        ///     Starts the snap.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int StartSnap();
    }

    /// <summary>
    ///     Class ImgBitmapInfo.
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public class ImgBitmapInfo
    {
        /// <summary>
        ///     The bitmap
        /// </summary>
        public Bitmap _bitmap = null;

        /// <summary>
        ///     The frame index
        /// </summary>
        public int _frameIdx = -1;

        /// <summary>
        ///     The img bit depth
        /// </summary>
        public int _imgBitDepth = -1;

        /// <summary>
        ///     The img height
        /// </summary>
        public int _imgHeight = -1;

        /// <summary>
        ///     The img ticks
        /// </summary>
        public long _imgTicks = 0;

        /// <summary>
        ///     The img width
        /// </summary>
        public int _imgWidth = -1;
    }

    /// <summary>
    ///     Class ImgBytesInfo.
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public class ImgBytesInfo
    {
        /// <summary>
        ///     The frame index
        /// </summary>
        public int _frameIdx = -1;

        /// <summary>
        ///     The img bit depth
        /// </summary>
        public int _imgBitDepth = -1;

        /// <summary>
        ///     The img bytes
        /// </summary>
        public byte[] _imgBytes = null;

        /// <summary>
        ///     The img height
        /// </summary>
        public int _imgHeight = -1;

        /// <summary>
        ///     The img source PTR
        /// </summary>
        public IntPtr _imgSrcPtr;

        /// <summary>
        ///     The img ticks
        /// </summary>
        public long _imgTicks = 0;

        /// <summary>
        ///     The img width
        /// </summary>
        public int _imgWidth = -1;
    }
}