using System;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.IMotionCard;

namespace Lead.CPrim.PrimLEIS
{
    public class LEISConfig
    {
        public int AD_DA_CANNode { set; get; }
        public int[] AInputMode { set; get; }
        public int[] AOutputMode { set; get; }
        public int ByteStream { set; get; }
        public uint CANNode { set; get; }
        public bool InitAdlinkEnable { set; get; }
        public Type ChildType { set; get; }
        public string ConfigFilePath { set; get; }
        public string DataTablePath { set; get; }
        public int DevIndex { set; get; }
        public PrimType HSType { set; get; }
        public Guid Id { set; get; }
        public bool LogEnable { set; get; }
        public PrimManufacture Manu { set; get; }
        public double MaxVel { set; get; }
        public double MinVel { set; get; }
        public string Name { set; get; }
        public bool DecStopEnable { set; get; }
        public double DecStopTime { set; get; } = 0.1;
        public PrimConnState PrimConnStat { set; get; }
        public bool PrimDebug { set; get; }
        public bool PrimEnable { set; get; }
        public PrimRunState PrimRunStat { set; get; }
        public bool PrimSimulator { set; get; }
        public string PrimTypeName { set; get; }
        public StopMode StopMode { set; get; }
        public double StopVel { set; get; }
        public double Tacc { set; get; }
        public double Tdec { set; get; }
        public PrimVer Ver { set; get; }
    }
}