using System;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleAnalogInput
{
    /// <summary>模拟量输入模块配置</summary>
    public class EleAnalogInputConfig
    {
        /// <summary>
        /// Ctor无参
        /// </summary>
        public EleAnalogInputConfig()
        {
            DevName = "";
            Id = Guid.NewGuid();
            Info = "";
            IsSimulateMode = false;
            Name = "";
            AnalogType = EleAnalogType.Voltage;
            EleTypeName = "AD";
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
        }

        /// <summary>从模拟量模块实际读到的值</summary>
        public float ActFeedBack { set; get; }
        /// <summary>数字量最大值</summary>
        public float ActMax { set; get; }
        /// <summary>数字量最小值</summary>
        public float ActMin { set; get; }
        /// <summary>模拟量值转换后的数字量值</summary>
        public float ActValue { set; get; }
        /// <summary>模拟量模块地址</summary>
        public string Address { set; get; }
        /// <summary>模拟量模块类型-电压/电流</summary>
        public EleAnalogType AnalogType { set; get; }
        /// <summary>模拟量模块对应基元名称</summary>
        public string DevName { set; get; }
        /// <summary>模拟量模块隶属类型</summary>
        public string EleTypeName { set; get; }
        /// <summary>模拟量模块是否启用</summary>
        public bool Enable { set; get; }
        /// <summary>模拟量最大值</summary>
        public float FeedBackMax { set; get; }
        /// <summary>模拟量最小值</summary>
        public float FeedBackMin { set; get; }
        /// <summary>模拟量模块对应唯一ID</summary>
        public Guid Id { set; get; }
        /// <summary>模拟量模块备注信息</summary>
        public string Info { set; get; }
        /// <summary>模拟量模块是否为仿真模式</summary>
        public bool IsSimulateMode { set; get; }
        /// <summary>数字量上限</summary>
        public float LimitMax { set; get; }
        /// <summary>数字量下限</summary>
        public float LimitMin { set; get; }
        /// <summary>模拟量模块Log显示</summary>
        public bool LogDisplay { set; get; }
        /// <summary>模拟量模块Log是否启用</summary>
        public bool LogEnable { set; get; }
        /// <summary>模拟量模块名称</summary>
        public string Name { set; get; }
    }
}