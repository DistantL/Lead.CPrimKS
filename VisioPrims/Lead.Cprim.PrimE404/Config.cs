using System;
using System.ComponentModel;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimE404
{
    public class Config
    {
        public Config()
        {
            Name = "";
            PrimTypeName = "";
            Id = Guid.NewGuid();
            PrimEnable = true;
            SlaveId = 1;
            OpenOtherName = true;

            TriggerDatas = new BindingList<TriggerData>();
        }
        /// <summary>
        /// 从站号<br>
        /// 从1开始
        /// </summary>
        public int SlaveId { get; set; }

        /// <summary>
        /// 是否开启别名，0-不开启 ，1-开启
        /// </summary>
        public bool OpenOtherName { get; set; }

        /// <summary>
        /// 触发数据源
        /// </summary>
        public BindingList<TriggerData> TriggerDatas { get; set; }


        #region Override IPrim
        public Guid Id { set; get; }
        public string Name { set; get; }
        public bool PrimEnable { set; get; }
        public string PrimTypeName { set; get; }
        public int CurrentImageIndex { get; set; }
        #endregion
    }

    /// <summary>
    /// 触发数据
    /// </summary>
    public class TriggerData
    {
        public TriggerData()
        {
            TriggerId = 0;
            EncoderId = 0;
            LineCompareMask = LineCompareMask.bit0;
            PreCompareMask = PreCompareMask.bit0;
            TrigMode = TrigMode.脉冲;
            OutMode = OutMode.脉冲;
            PulsePolarity = PulsePolarity.不取反;
            EncoderMode = EncoderMode.Four倍频;
            EncoderDir = EncoderDir.正向;
        }

        /// <summary>
        /// 触发通道
        /// </summary>
        public int TriggerId { get; set; }

        /// <summary>
        /// 编码器通道
        /// </summary>
        public int EncoderId { get; set; }

        /// <summary>
        /// 绑定的线性比较器号0-9，每一位对应一个线性比较器，bit0对应比较器0
        /// </summary>
        public LineCompareMask LineCompareMask { get; set; }

        /// <summary>
        /// 绑定的预设定比较器号0-3，每一位对应一个预设定比较器,bit0对应预设比较器0
        /// </summary>
        public PreCompareMask PreCompareMask { get; set; }

        /// <summary>
        /// 触发模式
        /// </summary>
        public TrigMode TrigMode { get; set; }

        /// <summary>
        /// 输出模式
        /// </summary>
        public OutMode OutMode { get; set; }

        /// <summary>
        /// 输出极性 0：不取反 1：取反
        /// </summary>
        public PulsePolarity PulsePolarity { get; set; }

        /// <summary>
        /// 编码器计数方式
        /// </summary>
        public EncoderMode EncoderMode { get; set; }

        /// <summary>
        /// 编码器计数方向
        /// </summary>
        public EncoderDir EncoderDir { get; set; }
    }

    /// <summary>
    /// 绑定的线性比较器号0-9，每一位对应一个线性比较器，bit0对应比较器0
    /// </summary>
    [Flags]
    public enum LineCompareMask
    {
        bit0 = 1,
        bit1 = 2,
        bit2 = 4,
        bit3 = 8,
        bit4 = 16,
        bit5 = 32,
        bit6 = 64,
        bit7 = 128,
        bit8 = 256,
        bit9 = 512,
    }

    /// <summary>
    /// 绑定的预设定比较器号0-3，每一位对应一个预设定比较器,bit0对应预设比较器0
    /// </summary>
    public enum PreCompareMask
    {
        bit0 = 1,
        bit1 = 2,
        bit2 = 4,
        bit3 = 8,
    }

    /// <summary>
    /// 触发模式
    /// </summary>
    public enum TrigMode
    {
        脉冲,
        电平翻转,
    }

    /// <summary>
    /// 输出模式
    /// </summary>
    public enum OutMode
    {
        GPIO = 0,
        脉冲,
        PWM,
    }

    /// <summary>
    /// 输出极性 0：不取反 1：取反
    /// </summary>
    public enum PulsePolarity
    {
        不取反,
        取反,
    }

    /// <summary>
    /// 编码器计数方式
    /// </summary>
    public enum EncoderMode
    {
        One倍频 = 1,
        Two倍频 = 2,
        Four倍频 = 4,
    }

    /// <summary>
    /// 编码器计数方向
    /// </summary>
    public enum EncoderDir
    {
        正向,
        反向,
        双向,
    }
}