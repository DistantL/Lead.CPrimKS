/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ShowAtlasCurveConfig.cs
 * Author: Victor
 * Description: PLC曲线配置管理类
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

namespace Lead.CPrim.ShowPlcCurve
{
    /// <summary>压力曲线配置</summary>
    public class Config
    {
        #region Ctor无参
        public Config()
        {
            
        } 
        #endregion



        #region Define
        /// <summary>
        /// 曲线数量
        /// </summary>
        public int ChartNum { get; set; }

        /// <summary>
        /// X轴间隔
        /// </summary>
        public double XInterval { get; set; }

        /// <summary>
        /// X轴格式
        /// </summary>
        public string XFormat { get; set; }

        /// <summary>
        /// 曲线保存位置1
        /// </summary>
        public string  PlcPath { get; set; }

        /// <summary>
        /// 曲线保存位置2
        /// </summary>
        public string PlcPath2 { get; set; }

        /// <summary>
        /// X最小值启用
        /// </summary>
        public bool XMinEnable { get; set; }
        /// <summary>
        /// X最大值启用
        /// </summary>
        public bool XMaxEnable { get; set; }
        /// <summary>
        /// Y最小值启用
        /// </summary>
        public bool YMinEnable { get; set; }
        /// <summary>
        /// Y最大值启用
        /// </summary>
        public bool YMaxEnable { get; set; }
        /// <summary>
        /// X最小值
        /// </summary>
        public double XMin { get; set; }
        /// <summary>
        /// X最大值
        /// </summary>
        public double XMax { get; set; }
        /// <summary>
        /// Y最小值
        /// </summary>
        public double YMin { get; set; }
        /// <summary>
        /// Y最大值
        /// </summary>
        public double YMax { get; set; }

        /// <summary>
        /// 源数据保存启用
        /// </summary>
        public bool SourceDataSaveEnable { get; set; }

        /// <summary>
        /// 源数据保存位置
        /// </summary>
        public string SourceDataSave { get; set; }

        /// <summary>
        /// true：保存目录增时间目录（/年/月日/）；false：保存目录不增加时间，按照设定目录存储；
        /// </summary>
        public bool PathAddDate { get; set; }
        #endregion



        #region Override IPrim
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShowTypeName { get; set; }
        public bool Enable { get; set; }
        #endregion
    }
}
