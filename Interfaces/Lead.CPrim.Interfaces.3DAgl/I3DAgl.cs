// ***********************************************************************
// Assembly         : Lead.CPrim.3DAgl
// Author           : 17181
// Created          : 01-23-2019
//
// Last Modified By : 17181
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="I3DAgl.cs" company="LeadChina">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using CommonStruct.Communicate;
using CommonStruct.TypePrim;
using IControllerInterface;
using System.Drawing;
using HalconDotNet;
using CommonStruct.Type3D;
using LogicControl;

namespace Lead.CPrim.Interfaces
{
    /// <summary>
    ///     Interface I3DAgl
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public interface I3DAgl
    {
        string FileName { get; set; }
        string FilePath { get; set; }
        LogicController LogicControl { get; }

        void FillCoordData(int index, CoordData pointCloudData);

        void FillLineData(int index, LineData pointCloudData);

        void FillPlaneData(int index, PlaneData pointCloudData);

        void FillPointCloud(int index, PointCloudData pointCloudData);

        bool LoadTaskFile(string fileName = "", string productName = null);

        OutputPrimData Run();
        bool Run(out OutputPrimData dataOut, int timeOut = 300000);
        List<FaiValue> GetFaisFromTask(bool reLoad = false, string productName = "");
        bool SaveImg(string filePath, int defaultView = 5, int width = 800, int height = 800, double scaleValue = 1.0);
        bool SaveImg(string fileName);
        Bitmap GetPrimBitMap(string primName);
        bool SavePointsClout<T>(T pointsData,Axis2D axis2D,string fileName);
        HObject HImageConvertFromBitmap8(Bitmap bmp);
        object GetPrimData(string primName);
        int ConvertToRangeImageByWidth(List<string> lstPrimName, out Bitmap bmp, double zMax = 0.1, double zMin = -0.1);

        int ReadIndexPointCloud(string fileName, bool isCalUseIntensity, out XDPOINT[,] pXdPoints,
            out List<List<PointFS>> pFsPoints);
    }
}