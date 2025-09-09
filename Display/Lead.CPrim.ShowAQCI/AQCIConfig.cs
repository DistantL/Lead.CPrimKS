using System;
using System.Collections.Generic;

namespace Lead.CPrim.ShowAQCI
{
    /// <summary>AQCI配置管理器</summary>
    public class AQCIConfig
    {
        #region Ctor
        /// <summary>Ctor无参</summary>
        public AQCIConfig()
        {
            ProColors = new List<string>();
            PerRow1 = 0.24F;
            PerRow2 = 0.46F;
            PerRow3 = 0.30F;
            PerCol1 = 0.3455F;
            PerCol2 = 0.1138F;
            PerCol3 = 0.5414F;
        }
        #endregion



        #region Define
        /// <summary>工站名称</summary>
        public string StationName { get; set; }
        /// <summary>颜色集合</summary>
        public List<string> ProColors { set; get; }
        /// <summary>当前颜色</summary>
        public string CurProColor { set; get; }
        /// <summary>推送实时数据</summary>
        public bool ShowRtData { set; get; }
        /// <summary>图片展示</summary>
        public bool ShowPic { set; get; }
        /// <summary>行1高度</summary>
        public float PerRow1 { set; get; }
        /// <summary>行2高度</summary>
        public float PerRow2 { set; get; }
        /// <summary>行3高度</summary>
        public float PerRow3 { set; get; }
        /// <summary>列1高度</summary>
        public float PerCol1 { set; get; }
        /// <summary>列2高度</summary>
        public float PerCol2 { set; get; }
        /// <summary>列3高度</summary>
        public float PerCol3 { set; get; }
        /// <summary>图片名称</summary>
        public string PicFileName { set; get; }
        /// <summary>图片路径</summary>
        public string PicFilePath { set; get; } 
        #endregion



        #region Override IShow
        public Guid Id { set; get; }
        public string Name { set; get; }
        public string ShowTypeName { set; get; }
        public bool Enable { set; get; }
        public string Version { set; get; }
        #endregion
    }
}