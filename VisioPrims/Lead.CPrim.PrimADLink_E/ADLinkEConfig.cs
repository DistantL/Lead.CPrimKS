using System;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.IMotionCard;

namespace Lead.CPrim.PrimADLink_E
{
    public class ADLinkEConfig
    {
        #region Override IPrim's property

        public Type ChildType { get; set; }
        public PrimType HSType { get; set; }
        public Guid Id { get; set; }
        public bool LogEnable { get; set; } = true;
        public PrimManufacture Manu { get; set; }
        public string Name { get; set; }
        public bool PrimDebug { get; set; }
        public bool PrimEnable { get; set; }
        public string PrimTypeName { get; set; }
        public PrimVer Ver { get; set; }
        public int CurrentImageIndex { get; set; }

        #endregion Override IPrim's property

        #region Override IMotionCard's property

        public string ConfigFilePath { get; set; }

        public int DevIndex { get; set; }
        public string IOInfosFilePath { get; set; }
        public StopMode StopMode { get; set; }

        #endregion Override IMotionCard's property

        #region Others

        public bool CycleScanEnable { get; set; }
        public int CycleScanTime { get; set; }
        public string EBusConfigFilePath { get; set; }

        #endregion Others
    }
}