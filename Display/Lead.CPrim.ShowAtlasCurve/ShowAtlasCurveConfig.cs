/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ShowAtlasCurveConfig.cs
 * Author: Victor
 * Description: Atlas 配置管理类
 * CreateTime: 2022-09-13
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.0904><Victor><20220913>
 * 1、初版1.0
******************************************************************************/

using System;

namespace Lead.CPrim.ShowAtlasCurve
{
    /// <summary>压力曲线配置</summary>
    public class ShowAtlasCurveConfig
    {
        #region Ctor无参
        public ShowAtlasCurveConfig()
        {
            Atlas1Name = "Atlas1";
            Atlas2Name = "Atlas2";
            Atlas3Name = "Atlas3";
            Atlas4Name = "Atlas4";
        }
        #endregion



        #region Define
        public string Atlas1Name { get; set; }
        public string Atlas2Name { get; set; }
        public string Atlas3Name { get; set; }
        public string Atlas4Name { get; set; }

        public int AtlasNum { get; set; }
        public int ChartNum { get; set; }
        public string AtlasPath { get; set; }
        public string AtlasPath2 { get; set; }
        /// <summary>启用曲线Y限位</summary>
        public bool EnableChartYMax { get; set; }
        /// <summary>曲线Y限位</summary>
        public double ChartYMax { get; set; }
        #endregion



        #region Override IPrim
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShowTypeName { get; set; }
        public bool Enable { get; set; }
        public string Version { get; set; }
        #endregion
    }
}
