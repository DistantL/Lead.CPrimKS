using System;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Communicate;

namespace Lead.CPrim.PrimSerial
{
    public class SerialConfig
    {
        public bool ShowTime { set; get; }

        public bool LogEnable { set; get; }
        public int CurrentImageIndex { set; get; }

        #region Override IPrim's Property

        public string Name { set; get; }

        public string PrimTypeName { set; get; }

        public Guid Id { set; get; }

        //Prim 子类的类型
        public Type ChildType { set; get; }

        //Prim的硬件、软件类型
        public PrimType HSType { set; get; }

        public PrimManufacture Manu { set; get; }

        public PrimVer Ver { set; get; }

        public PrimConnState PrimConnStat { set; get; }

        public PrimRunState PrimRunStat { set; get; }

        public bool PrimSimulator { set; get; }

        public bool PrimDebug { set; get; }

        public bool PrimEnable { set; get; }

        #endregion

        #region Override ISerial Property

        public string ComPort { set; get; }
        public string BoudRate { set; get; }
        public string DataBits { set; get; }
        public string StopBits { set; get; }
        public ParityMode SerialParity { set; get; }

        public int SendQueueCnt { set; get; }

        public int RevQueueCnt { set; get; }

        public string NetName { set; get; }

        public SerialNotifyMode NotifyMode { set; get; }

        public bool IsBinary { set; get; }

        public string Code1 { set; get; }
        public string Code2 { set; get; }
        public bool CalCheckCode { set; get; }

        #endregion
    }
}