using System.Collections.Generic;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Dev;

namespace Lead.CPrim.PrimKeyencePLC
{
    /// <summary>数据</summary>
    public class PlcDataConfig
    {
        /// <summary>单行数据</summary>
        public PlcDataConfig()
        {
            DtName = "";
            DtType = ProtocolDataType.STRING;
            DtAddress = "0";
            DtPermission = DataPermission.RW;
            DtRdMode = DataReadMode.Cycle;
            DtIsNotify = true;
            DtAddressType = PLCByteSoftType.EM;
            DtCurrentValue = "";
        }


        /// <summary>名称</summary>
        public string DtName { get; set; }
        /// <summary>数据类型</summary>
        public ProtocolDataType DtType { get; set; }
        /// <summary>地址长度</summary>
        public ushort DtLength { get; set; }
        /// <summary>地址</summary>
        public string DtAddress { get; set; }
        /// <summary>地址类型</summary>
        public PLCByteSoftType DtAddressType { get; set; }
        /// <summary>读写权限</summary>
        public DataPermission DtPermission { get; set; }
        /// <summary>当前值</summary>
        public object DtCurrentValue { get; set; }
        /// <summary>数据读取模式</summary>
        public DataReadMode DtRdMode { get; set; }
        /// <summary>是否调用事情</summary>
        public bool DtIsNotify { get; set; }
    }
    /// <summary>数据类</summary>
    public class PlcDataConfigs
    {
        public PlcDataConfigs()
        {
            ListDataConfig = new List<PlcDataConfig>();
        }
        public List<PlcDataConfig> ListDataConfig { set; get; }
    }
}