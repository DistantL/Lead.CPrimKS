using System;
using Lead.CPrim.Interfaces.Ele;

namespace Lead.CPrim.EleCartesian
{
    /// <summary>轴组配置管理器</summary>
    public class EleCartesianConfig
    {
        /// <summary>Ctor无参</summary>
        public EleCartesianConfig()
        {
            Name = "Cartesian01";
            Info = "";
            EleTypeName = "EleCartesian";
            Id = Guid.NewGuid();
            Enable = true;
            IsSimulateMode = false;
            LogEnable = true;
            LogDisplay = true;
            VelMode = AccDecType.Other;
            AxisNum = 0;
            TimeOutS = 100;
            PosLimit = 100;
            AxisesConfigPath = "";
            PointsPath = "";
            SafetyAxisDefaultHeight = 1;
        }


        #region Override IEle
        /// <summary>【EleCartesianConfig】轴组Id</summary>
        public Guid Id { get; set; }
        /// <summary>【EleCartesianConfig】轴组名称</summary>
        public string Name { get; set; }
        /// <summary>【EleCartesianConfig】轴组信息</summary>
        public string Info { get; set; }
        /// <summary>【EleCartesianConfig】轴组使能</summary>
        public bool Enable { get; set; }
        /// <summary>【EleCartesianConfig】轴组类型</summary>
        public string EleTypeName { get; set; }
        /// <summary>【EleCartesianConfig】轴组日志使能</summary>
        public bool LogEnable { get; set; }
        /// <summary>【EleCartesianConfig】轴组日志显示</summary>
        public bool LogDisplay { get; set; }
        /// <summary>【EleCartesianConfig】轴组仿真模式</summary>
        public bool IsSimulateMode { get; set; }
        #endregion


        #region Override IEleCartesian
        /// <summary>【EleCartesianConfig】轴组配置目录</summary>
        public string AxisesConfigPath { set; get; }
        /// <summary>【EleCartesianConfig】轴组点位目录</summary>
        public string PointsPath { set; get; }
        /// <summary>【EleCartesianConfig】轴组轴个数</summary>
        public int AxisNum { set; get; }
        /// <summary>【EleCartesianConfig】速度模式/时间模式</summary>
        public AccDecType VelMode { set; get; }
        /// <summary>【EleCartesianConfig】指令位置与编码器位置差值极限</summary>
        public double PosLimit { set; get; }
        /// <summary>【EleCartesianConfig】运动超时设定</summary>
        public double TimeOutS { set; get; }
        #endregion

        #region JumpSafetyAxis
        
        /// <summary> 门型移动时安全高度 </summary>
        public double SafetyAxisDefaultHeight { set; get; }

        #endregion
    }
}