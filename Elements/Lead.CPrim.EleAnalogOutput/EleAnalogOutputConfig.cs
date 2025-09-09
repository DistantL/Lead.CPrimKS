using System;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleAnalogOutput
{
    public class EleAnalogOutputConfig
    {
        public EleAnalogOutputConfig()
        {
            DevName = "";
            Id = Guid.NewGuid();
            Info = "";
            IsSimulateMode = false;
            Name = "";
            AnalogType = EleAnalogType.Voltage;
            EleTypeName = "DA";
            Enable = false;
            LogEnable = true;
            LogDisplay = false;
            Address = "";
            ActMin = 0;
            ActMax = 0;
            LimitMin = 0;
            LimitMax = 0;
            FeedBackMin = 0;
            FeedBackMax = 0;
            SetValue = 0;
        }

        /// <summary>
        ///     模拟量模块名称
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public string Name { set; get; }

        /// <summary>
        ///     模拟量模块备注信息
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public string Info { set; get; }

        /// <summary>
        ///     模拟量模块隶属类型
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public string EleTypeName { set; get; }

        /// <summary>
        ///     模拟量模块类型-电压/电流
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public EleAnalogType AnalogType { set; get; }

        /// <summary>
        ///     模拟量模块对应唯一ID
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public Guid Id { set; get; }

        /// <summary>
        ///     模拟量模块是否启用
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public bool Enable { set; get; }

        /// <summary>
        ///     模拟量模块是否为仿真模式
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public bool IsSimulateMode { set; get; }

        /// <summary>
        ///     模拟量模块对应基元名称
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public string DevName { set; get; }

        /// <summary>
        ///     模拟量模块Log是否启用
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public bool LogEnable { set; get; }

        /// <summary>
        ///     模拟量模块Log显示
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public bool LogDisplay { set; get; }

        /// <summary>
        ///     模拟量模块地址
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public string Address { set; get; }

        /// <summary>
        ///     数字量最小值
        /// </summary>
        /// <value></value>
        /// <remarks>Lead.CPrim</remarks>
        public float ActMin { set; get; }

        /// <summary>
        ///     数字量最大值
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public float ActMax { set; get; }

        /// <summary>
        ///     设置的数字量最低下限
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public float LimitMin { set; get; }

        /// <summary>
        ///     设置的数字量最大上限
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public float LimitMax { set; get; }

        /// <summary>
        ///     电压/电流的最小值
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public float FeedBackMin { set; get; }

        /// <summary>
        ///     电压/电流的最大值
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public float FeedBackMax { set; get; }

        /// <summary>
        ///     模拟量值转换后的数字量值
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public float SetValue { set; get; }
    }
}