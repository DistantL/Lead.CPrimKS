using Lead.CPrim.Interfaces;
using System;

namespace Lead.Cprim.PrimRobotInovance
{
    public class RobotInovanceConfig
    {
        public string Name
        { set; get; }

        public string PrimTypeName
        { set; get; }

        public Guid Id
        { set; get; }

        public Type ChildType
        { set; get; }

        public PrimType HSType
        { set; get; }

        public PrimManufacture Manu
        { set; get; }

        public PrimVer Ver
        { set; get; }

        public PrimConnState PrimConnStat
        { set; get; }

        public PrimRunState PrimRunStat
        { set; get; }

        public bool PrimSimulator
        { set; get; }

        public bool PrimDebug
        { set; get; }

        public bool PrimEnable
        { set; get; }
        public bool LogEnable
        { set; get; }
        public string RobotIp
        { set; get; }
        public int Port
        { set; get; } = 2222;
        public string Password
        { set; get; } = "000000";
        public int RobotId
        { set; get; } = 0;

    }
}
