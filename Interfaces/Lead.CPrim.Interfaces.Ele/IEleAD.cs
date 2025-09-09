namespace Lead.CPrim.Interfaces
{
    /// <summary>模拟量输入模块电压/电流类型</summary>
    public enum EleAnalogType
    {
        /// <summary>电压</summary>
        Voltage = 0,
        /// <summary>电流</summary>
        Electricity = 1
    }


    /// <summary>模拟量输入模块用户接口</summary>
    public interface IEleAD
    {
        /// <summary>接口【IEleAD】实时模拟量</summary>
        float ActFeedBack { set; get; }
        /// <summary>接口【IEleAD】实时数字量</summary>
        float ActValue { set; get; }
        /// <summary>接口【IEleAD】数字量最大值</summary>
        float ActMax { set; get; }
        /// <summary>接口【IEleAD】数字量最小值</summary>
        float ActMin { set; get; }
        /// <summary>接口【IEleAD】模拟量模块地址</summary>
        string Address { set; get; }
        /// <summary>接口【IEleAD】模拟量模块类型</summary>
        EleAnalogType EleType { set; get; }
        /// <summary>接口【IEleAD】模拟量最大值</summary>
        float FeedBackMax { set; get; }
        /// <summary>接口【IEleAD】模拟量最小值</summary>
        float FeedBackMin { set; get; }
        /// <summary>接口【IEleAD】数字量上限</summary>
        float LimitMax { set; get; }
        /// <summary>接口【IEleAD】数字量下限</summary>
        float LimitMin { set; get; }
        /// <summary>接口【IEleAD】读取当前模拟量</summary>
        float Read();

        float GetActValue();
    }


    /// <summary>模拟量输入模块用户接口</summary>
    public interface IEleADPro
    {
        /// <summary>接口【IEleAD】读取当前模拟量</summary>
        float Read();
    }
}