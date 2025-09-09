using System;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimOPC
{
    public class OPCConfig
    {
        public string Name { set; get; }

        public string PrimTypeName { set; get; }

        public Guid Id { set; get; }

        public Type ChildType { set; get; }

        public PrimType HSType { set; get; }

        public PrimManufacture Manu { set; get; }

        public PrimVer Ver { set; get; }
        public int CurrentImageIndex { get; set; }

        public PrimConnState PrimConnStat { set; get; }

        public PrimRunState PrimRunStat { set; get; }

        public bool PrimSimulator { set; get; }

        public bool PrimDebug { set; get; }

        public bool PrimEnable { set; get; }

        #region Login Config

        public int LoginMethod { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string CertificateFilePath { set; get; }
        public string SecretKey { set; get; }
        public string ServerAddress { set; get; }

        #endregion

        public string NodeConfigPath { get; set; }
    }
}