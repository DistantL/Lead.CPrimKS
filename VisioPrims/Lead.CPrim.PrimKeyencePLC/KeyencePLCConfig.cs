
using System;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimKeyencePLC
{
    /// <summary>本地配置管理类</summary>
    public class PrimKeyencePLCConfig
    {
        public PrimKeyencePLCConfig()
        {
            IP = "192.168.250.100";
            Port = "6000";
            CycleTime = 10;
            ReconnectCnt = 2;
            DataTablePath = "";
            LogEnable = true;
        }
        #region Define_Prop
        /// <summary>Ip</summary>
        public string IP { set; get; }
        /// <summary>Port</summary>
        public string Port { set; get; }
        /// <summary>循环时间</summary>
        public int CycleTime { set; get; }
        /// <summary>重连次数</summary>
        public int ReconnectCnt { set; get; }
        /// <summary>数据表地址</summary>
        public string DataTablePath { set; get; }
        /// <summary>日志开启</summary>
        public bool LogEnable { set; get; } = true;
        #endregion



        #region Override IPrim
        public Guid Id { set; get; }
        public string Name { set; get; }
        public bool PrimEnable { set; get; }
        public PrimType HSType { set; get; }
        public string PrimTypeName { set; get; }
        public PrimConnState PrimConnStat { set; get; }
        public PrimRunState PrimRunStat { set; get; }
        public PrimVer Ver { set; get; }
        public int CurrentImageIndex { get; set; }
        #endregion
    }
}