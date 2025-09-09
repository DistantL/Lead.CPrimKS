using System;
using System.Collections.Generic;

namespace Lead.CPrim.ShowAudio
{
    /// <summary>配置管理器</summary>
    public class AudioConfig
    {
        #region Ctor
        /// <summary>Ctor无参</summary>
        public AudioConfig()
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
}