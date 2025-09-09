using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonStruct.Type3D;

namespace Lead.CPrim.Interfaces
{
    public delegate void FocalSpecBatchArrived(List<List<FSPoint>> batch, int count);
    [Serializable]
    public class FSPoint
    {
        public uint index;
        public int Location;
        public int Intensity;
        public double X;
        public double Y;
        public double Z;
    }
    public class FocalParam
    {
        [Category("1.基本参数"),Description("产品名称")]
        public string ProductName { get; set; }
        [Category("1.Peak Detection"), Description("Length of the Finite Impulse Response(FIR)filter,可改变相机对于多层数据的敏感度")]
        public int FirLength { get; set; }
        [Category("1.Peak Detection"), Description("相机光强敏感度")]
        public int SignalDetectionFilterLength { get; set; }
        [Category("1.Peak Detection"), Description("相机光强敏感度")]
        public int PeakAverageIntensityFilterLength { get; set; }
        [Category("滤波参数"), Description("可去除单独存在的噪点")]
        public int NoiseRemoval { get; set; }
        [Category("滤波参数"), Description("多层设置")]
        public ExportLayer Mode { get; set; }
        [Category("滤波参数"), Description("可去除单独存在的噪点")]
        public double ProfileScale { get; set; } = 1.0 / 1000.0;
        public bool IsXAxisTrige { get; set; }
        public string ZCalibrationFile { get; set; } = "sensor_calibration_file";
        public string XCalibrationFile { get; set; } = "sensor_x_calibration_file";

        public bool AutoHeightZeroPosition { set; get; }
        public float TrigInterval { get; set; }
        public bool IsExternalPulsingEnabled { get; set; }         //是否启用外部触发
        public int Freq { get; set; }
        public int LedPulseWidth { get; set; }
        public int PeakThreshold { get; set; }
        public int PeakFirLength { get; set; }
        public int AverFirLength { get; set; }
        public int RegPulseDivider { get; set; }
        public double Gain { get; set; }
        public int ImageHeightZeroPosition { set; get; }
        public float FlipXX0 { get; set; }
        public int FlipXEnabled { get; set; }
        public int Reordering { get; set; }
        public float DetectMissingFirstLayer { get; set; }
        public float FillGapXMax { get; set; }
        public double AverageZFilterSize { get; set; }
        public double AverageIntensityFilterSize { get; set; }
        public Int32 MedianZFilterSize { get; set; }
        public Int32 MedianIntensityFilterSize { get; set; }
        public float ResampleLineXResolution { get; set; } //No Param
        public int PeakXFilter { get; set; } //No Param
    }
    public enum ExportLayer
    {
        All,
        Top,
        Bottom,
        Brightest
    }
    public interface ISensorFocalSpec
    {
        void Start();
        void Terminate();
        int SetParam(FocalParam focalParam);
        float XStartPos { get; set; }
        float YStartPos { get; set; }
        float ZStartPos { get; set; }
        List<List<FSPoint>> GetScanResult();
        void ClearScanResult();
        int ChangeProduct(string productName);
    }
}
