using System;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.IMotionCard;

namespace Lead.CPrim.PrimLEIS_E
{
    public class LEIS_EConfig
    {
        public Type ChildType { set; get; }
        public string ConfigFilePath { set; get; }
        public string DataTablePath { set; get; }
        public int DevIndex { set; get; }
        public PrimType HSType { set; get; }
        public Guid Id { set; get; }
        public bool LogEnable { set; get; }
        public PrimManufacture Manu { set; get; }
        public string Name { set; get; }
        public bool PrimDebug { set; get; }
        public PrimConnState PrimConnStat { set; get; }
        public bool PrimEnable { set; get; }
        public PrimRunState PrimRunStat { set; get; }
        public bool PrimSimulator { set; get; }
        public string PrimTypeName { set; get; }
        public StopMode StopMode { set; get; }
        public PrimVer Ver { set; get; }
        public int DiCount { set; get; }
        public int DoCount { set; get; }
        public int AiCount { set; get; }
        public int AoCount { set; get; }
        public int AxisCount { get; set; }
    }
}