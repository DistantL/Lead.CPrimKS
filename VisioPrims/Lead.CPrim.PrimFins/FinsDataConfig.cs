/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: FinsDataConfig.cs
 * Author: Victor
 * Description: 欧姆龙Fins通讯配置表数据类
 * CreateTime: 2022-09-21
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 3.3.22.0904 -> 
 * <Author> (Victor)    <Time> (20220921)
 * 1、初版1.0
******************************************************************************/

using System.Collections.Generic;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimFinsNet
{
    /// <summary>数据</summary>
    public class FinsDataConfig
    {
        /// <summary>单行数据</summary>
        public FinsDataConfig()
        {
            DtName = "";
            DtType = ProtocolDataType.STRING;
            DtAddress = "D0";
            DtPermission = DataPermission.RW;
            DtRdMode = DataReadMode.Cycle;
            DtIsNotify = true;
            DtModifyValue = "";
            DtCurrentValue = "";
            DtLastValue = "";
        }


        /// <summary>名称</summary>
        public string DtName { get; set; }
        /// <summary>数据类型</summary>
        public ProtocolDataType DtType { get; set; }
        /// <summary>数据长度</summary>
        public ushort DtLength { get; set; }
        /// <summary>地址</summary>
        public string DtAddress { get; set; }
        /// <summary>读写权限</summary>
        public DataPermission DtPermission { get; set; }
        /// <summary>修改值</summary>
        public object DtModifyValue { get; set; }
        /// <summary>上次值</summary>
        public object DtLastValue { get; set; }
        /// <summary>当前值</summary>
        public object DtCurrentValue { get; set; }
        /// <summary>数据读取模式</summary>
        public DataReadMode DtRdMode { get; set; }
        /// <summary>事件通知</summary>
        public bool DtIsNotify { get; set; }
    }
    /// <summary>数据类</summary>
    public class FinsDataConfigs
    {
        public FinsDataConfigs()
        {
            ListDataConfig = new List<FinsDataConfig>();
        }
        public List<FinsDataConfig> ListDataConfig { set; get; }
    }
}