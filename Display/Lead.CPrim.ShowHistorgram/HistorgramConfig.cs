/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: HistorgramConfig.cs
 * Author: Victor
 * Description: 直方图配置类
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 *
 * 3.3.33.0617 -> 
 * <Author>     <Time>
 *  Victor     20220709
 * 1、代码风格重新布局以及增加备注
 * 2、增加日志使能属性
******************************************************************************/

using System;

namespace Lead.CPrim.ShowHistorgram
{
    public class HistorgramConfig
    {
        public HistorgramConfig()
        {
            NormalParts = 20;
            LowerParts = 5;
            UperParts = 5;
            PicSavePath = @"E:\FaiPictures\";
            EnableBarcode = false;
            LogEnable = false;
        }


        /// <summary>正常区域分组数</summary>
        public int NormalParts { get; set; }
        /// <summary>超下限分组数</summary>
        public int LowerParts { get; set; }
        /// <summary>超上限分组数</summary>
        public int UperParts { get; set; }
        /// <summary>图片保存文件夹</summary>
        public string PicSavePath { get; set; }
        /// <summary>良率显示使能</summary>
        public bool EnableBarcode { get; set; }
        /// <summary>true：显示日志；false：不显示日志</summary>
        public bool LogEnable { get; set; }


        #region Override IShow
        public Guid Id { set; get; }
        public string Name { set; get; }
        public string ShowTypeName { set; get; }
        public bool Enable { set; get; }
        public string Version { set; get; }
        #endregion
    }
}