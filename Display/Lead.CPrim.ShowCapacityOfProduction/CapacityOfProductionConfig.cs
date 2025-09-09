using System;
using System.Collections.Generic;

namespace Lead.CPrim.ShowCapacityOfProduction
{
    /// <summary>配置管理器</summary>
    public class CapacityOfProductionConfig
    {
        #region Ctor
        /// <summary>Ctor无参</summary>
        public CapacityOfProductionConfig()
        {
            ProColors = new List<string>();
        }
        #endregion



        #region Define
        /// <summary>工站名称</summary>
        public string StationName { get; set; }
        /// <summary>颜色集合</summary>
        public List<string> ProColors { set; get; }
        /// <summary>当前颜色</summary>
        public string CurProColor { set; get; }
        /// <summary>产能路径</summary>
        public string ProductPath { set; get; }
        /// <summary>当前FAI名称</summary>
        public string CurrentFAIName { set; get; }
        #endregion



        #region Override IShow
        public Guid Id { set; get; }
        public string Name { set; get; }
        public string ShowTypeName { set; get; }
        public bool Enable { set; get; }
        public string Version { set; get; }
        #endregion
    }

    public class Production
    {
        public Production()
        {
            Input = 0;
            Rate = 1;
            OKCount = 0;
            NGCount = 0;
            UPH = 0;
            CT = 0;
        }
        public double Input { get; set; }
        public double Rate { get; set; }
        public double OKCount { get; set; }
        public double NGCount { get; set; }
        public double UPH { get; set; }
        public double CT { get; set; }
    }
}