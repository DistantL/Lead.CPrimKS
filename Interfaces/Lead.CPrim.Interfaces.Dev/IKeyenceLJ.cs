using System.Collections.Generic;
using CommonStruct.Type3D;

namespace Lead.CPrim.Interfaces
{
    public interface IKeyenceLJ
    {
        int[] BatchPointNum { set; get; }
        int DeviceCount { set; get; }
        bool[] DeviceEnable { set; get; }
        string[] DeviceName { set; get; }
        int[] FlipDirection { set; get; }
        double[] IntervalX { set; get; }
        double[] IntervalY { set; get; }
        string[] IpAddress { set; get; }
        int[] PartNum { set; get; }
        int[] Port { set; get; }
        int[] RowPointNum { set; get; }
        int[] SensorSelect { set; get; }
        byte[] KeyProNO { set; get; }
        bool AllLaserDataTransDone();

        int ClearBatch(int deviceId);

        int ClearMemoryProfileData(int deviceId);

        List<List<PointFS>> Get3dData(int deviceId, int index);

        List<List<PointFS>> Get3dData(int deviceId, int index, bool isSave, bool asyncMode, string saveFilePath);

        KeyPoint[,] GetBatch(int deviceId, int index, double intervalY = 0, double intervalX = 0);

        List<int[]> GetBatchArray(int deviceId);

        int GetBatchCount(int deviceId);

        bool GetPointsCount(int deviceId, int index);

        XDPOINT[,] GetXdPointData(int deviceId, int index);

        void Reset(int deviceId = -1);

        int RestartHighCommunication(bool asyncMode);

        int RestartHighCommunication(int deviceId);

        int SetBatchNum(int deviceId, int batchNum);

        //反转
        void SetFlip(int deviceId, int dir);

        int SetSegParam(int deviceId, int[] segParams);

        int StartMeasure(int deviceId);

        int StartMeasure();

        int StopMeasure(int deviceId);

        int StopMeasure();
    }

    public class KeyPoint
    {
        public int Intensity;
        public int Location;
        public double X;
        public double Y;
        public double Z;
    }
}