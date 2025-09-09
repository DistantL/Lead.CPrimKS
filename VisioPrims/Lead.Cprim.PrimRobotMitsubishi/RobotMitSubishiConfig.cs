using Lead.CPrim.Interfaces;
using System;

namespace Lead.CPrim.PrimRobotMitsubishi
{
    public class RobotMitSubishiConfig
    {
        public string Name{ set; get; }
        public Guid Id { set; get; }
        public string PrimTypeName{ set; get; }      
        public Type ChildType{ set; get; }
        public PrimType HSType{ set; get; }
        public PrimManufacture Manu{ set; get; }
        public PrimVer Ver{ set; get; }
        public PrimConnState PrimConnStat{ set; get; }
        public PrimRunState PrimRunStat{ set; get; }
        public bool PrimSimulator{ set; get; }
        public bool PrimDebug{ set; get; }
        public bool PrimEnable{ set; get; }
        public bool LogEnable{ set; get; }
        public int CurrentImageIndex { get; set; }

        #region 机器人
        /// <summary>
        /// 机器人编号
        /// </summary>
        public int RobotId{ set; get; } = 0;
        /// <summary>
        /// 全局变量文件名
        /// </summary>
        public string VRName { set; get; } = "GlobVR";
        /// <summary>
        /// 主函数文件名称
        /// </summary>
        public string MainFunName { set; get; } = "main";
        #endregion
    }
}
