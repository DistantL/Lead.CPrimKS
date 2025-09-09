using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Lead.CPrim.ShowErrorCode
{
    /// <summary>ErrorCode配置管理器</summary>
    public class ErrorCodeConfig
    {
        #region Ctor
        /// <summary>Ctor无参</summary>
        public ErrorCodeConfig()
        {
            
        }
        #endregion



        #region Define
        public string StationCode { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleNameEn { get; set; }
        public string ModuleNameCn { get; set; }
        public BindingList<ErrorCodeInput> LErrorCodeInput { get; set; }
        #endregion



        #region Override IShow
        public Guid Id { set; get; }
        public string Name { set; get; }
        public string ShowTypeName { set; get; }
        public bool Enable { set; get; }
        public string Version { set; get; }
        #endregion
    }

    public class ErrorCodeInput
    {
        /// <summary>一级报警代码</summary>
        public string first_level_code { get; set; }
        /// <summary>一级报警英文名称</summary>
        public string first_level_name_en { get; set; }
        /// <summary>一级报警中文名称</summary>
        public string first_level_name_cn { get; set; }

        /// <summary>二级报警代码</summary>
        public string second_level_code { get; set; }
        /// <summary>二级报警英文名称</summary>
        public string second_level_name_en { get; set; }
        /// <summary>二级报警中文名称</summary>
        public string second_level_name_cn { get; set; }
    }
}