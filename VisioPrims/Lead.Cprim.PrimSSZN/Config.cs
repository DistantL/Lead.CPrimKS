using System;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimSSZN
{
    public class Config
    {
        public Config()
        {
            Name = "";
            PrimTypeName = @"SSZN";
            Id = Guid.NewGuid();
            PrimEnable = true;

            DeviceCount = 1;
            DeviceName = new string[6];
            IpAddress = new string[6];
            DeviceEnable = new bool[6];
            BatchPointNum = new int[6];
            IntervalX = new double[6];
            IntervalY = new double[6];
            RowPointNum = new int[6];
            KeyProNO = new byte[6];
        }

        public int[] BatchPointNum { set; get; }
        public int DeviceCount { set; get; }
        public bool[] DeviceEnable { set; get; }
        public string[] DeviceName { set; get; }
        public double[] IntervalX { set; get; }
        public double[] IntervalY { set; get; }
        public string[] IpAddress { set; get; }
        public byte[] KeyProNO { set; get; }
        public int[] RowPointNum { get; set; }
        public int CallbackLineCount { set; get; } = 20;
        public CallBackMethod CallBackMethod { set; get; }


        #region Override IPrim
        public Guid Id { set; get; }
        public string Name { set; get; }
        public bool PrimEnable { set; get; }
        public string PrimTypeName { set; get; }
        public int CurrentImageIndex { get; set; }
        #endregion
    }

    /// <summary>
    /// 点云获取回调方式
    /// </summary>
    public enum CallBackMethod
    {
        一次回调,
        高速回调,
    }
}