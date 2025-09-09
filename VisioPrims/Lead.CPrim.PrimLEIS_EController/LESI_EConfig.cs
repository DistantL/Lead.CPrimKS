using System;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimLESI_EController
{
    public class LESI_EConfig
    {
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
        public string ConfigFilePath { get; set; }
        public int DevIndex { get; set; }

        /// <summary>基元循环扫描使能</summary>
        public bool CycleScanEnable { get; set; } = true;
        /// <summary>基元循环扫描时间</summary>
        public int CycleScanTime { get; set; } = 5;
        /// <summary>基元减速停止使能</summary>
        public bool DecStopEnable { set; get; }
        /// <summary>基元减速停止时间</summary>
        public double DecStopTime { set; get; } = 0.1;
        /// <summary>基元扫描总线错误</summary>
        public bool CheckEBusError { get; set; } = true;
        /// <summary>基元IP地址</summary>
        public string IpAddress { set; get; } = "192.168.5.11";
        /// <summary>基元辅助编码器使能</summary>
        public bool ExtraEncoderEnable { set; get; } = false;
        /// <summary>基元辅助编码器输入方式</summary>
        public int ExtraEncoderInMode { set; get; } = 1;
        /// <summary>基元辅助编码器计数方式</summary>
        public int ExternEncoderMulti { set; get; } = 1;
        /// <summary>EBus Config Path</summary>
        public string EBusConfigFilePath { get; set; }
        /// <summary>IO Infos Path</summary>
        public string IOInfosFilePath { get; set; }
        /// <summary>支持在线变速</summary>
        public bool OnLineChangeSpeed { get; set; } = false;
    }
}