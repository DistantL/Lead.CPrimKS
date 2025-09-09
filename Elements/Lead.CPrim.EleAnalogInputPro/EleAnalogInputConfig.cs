using System;
using System.ComponentModel;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleAnalogInputPro
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
            AnalogCalculates = new BindingList<AnalogCalculate>();
        }

        /// <summary>模拟量模块对应唯一ID</summary>
        public Guid Id { set; get; }
        /// <summary>模拟量模块名称</summary>
        public string Name { set; get; }
        /// <summary>模拟量模块备注信息</summary>
        public string Info { set; get; }
        /// <summary>模拟量模块类型-电压/电流</summary>
        public EleAnalogType AnalogType { set; get; }
        /// <summary>模拟量模块隶属类型</summary>
        public string EleTypeName { set; get; }
        /// <summary>模拟量模块对应基元名称</summary>
        public string DevName { set; get; }
        /// <summary>模拟量模块地址</summary>
        public string Address { set; get; }
        /// <summary>模拟量模块是否启用</summary>
        public bool Enable { set; get; }
        /// <summary>模拟量模块是否为仿真模式</summary>
        public bool IsSimulateMode { set; get; }
        /// <summary>模拟量模块Log显示</summary>
        public bool LogDisplay { set; get; }
        /// <summary>模拟量模块Log是否启用</summary>
        public bool LogEnable { set; get; }


        /// <summary>实时模拟量</summary>
        public float RealTimeAnalog { set; get; }

        /// <summary>实时数字量</summary>
        public float RealTimeDigital { set; get; }

        /// <summary>
        /// 标定数据
        /// </summary>
        public BindingList<AnalogCalculate> AnalogCalculates { get; set; }
    }

    /// <summary>
    /// 模拟量
    /// </summary>
    public class AnalogCalculate
    {
        /// <summary>
        /// 实时模拟量
        /// </summary>
        public double RealTimeAnalog { get; set; }

        /// <summary>
        /// 实时数字量
        /// </summary>
        public double RealTimeDigital { get; set; }
    }
}