using System;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimVarManager
{
    /// <summary>通讯基元配置管理器</summary>
    public class VarManagerConfig
    {
        #region Ctor
        /// <summary>Ctor无参</summary>
        public VarManagerConfig()
        {
            Name = "";
            PrimTypeName = @"VariableServer";
            Id = Guid.NewGuid();
            HSType = PrimType.Protocol;
            Ver = PrimVer.Other;
            PrimConnStat = PrimConnState.Other;
            PrimRunStat = PrimRunState.Other;
            PrimDebug = false;
            PrimEnable = true;
            LogEnable = true;
            PrimAlarmLv = LogLevel.Error;
            PrimRunMode = RunMode.Other;
            ValsSavePath = "";
            VarsType = VarManagerType.Server;
            ServerName = "VarServer0";
            ServerPCName = "LC50000-1";
            ServerIp = "127.0.0.1";
            CycleEnable = false;
            CycleTime = 50;
        }
        #endregion



        #region Prop
        /// <summary>基元路径</summary>
        public string ValsSavePath { get; set; }
        /// <summary>主站PC名称</summary>
        public string ServerPCName { get; set; }
        /// <summary>主站IP地址</summary>
        public string ServerIp { get; set; }
        /// <summary>主站名称</summary>
        public string ServerName { get; set; }
        /// <summary>循环扫描使能</summary>
        public bool CycleEnable { get; set; }
        /// <summary>循环扫描时间</summary>
        public int CycleTime { get; set; }
        /// <summary>信息交换类型</summary>
        public VarManagerType VarsType { get; set; }
        /// <summary>是否开启日志</summary>
        public bool LogEnable { get; set; }


        #region Override IPrim
        /// <summary>基元Id</summary>
        public Guid Id { set; get; }
        /// <summary>基元名称</summary>
        public string Name { set; get; }
        /// <summary>基元使能</summary>
        public bool PrimEnable { set; get; }
        /// <summary>基元类型</summary>
        public PrimType HSType { set; get; }
        /// <summary>基元类型名称</summary>
        public string PrimTypeName { set; get; }
        /// <summary>基元连接状态</summary>
        public PrimConnState PrimConnStat { set; get; }
        /// <summary>基元运行状态</summary>
        public PrimRunState PrimRunStat { set; get; }
        /// <summary>基元版本</summary>
        public PrimVer Ver { set; get; }
        #endregion


        #region Override IVarManager

        #endregion


        public bool PrimDebug { set; get; }
        public LogLevel PrimAlarmLv { get; set; }
        public RunMode PrimRunMode { get; set; }
        #endregion
    }
}