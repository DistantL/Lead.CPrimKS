
namespace Lead.CPrim.Interfaces
{
    /// <summary>输入常开/常闭</summary>
    public enum EleDIType
    {
        /// <summary>常开</summary>
        NO = 1,
        /// <summary>常闭</summary>
        NC = 2
    }


    /// <summary>用户接口_数字量输入模块用户接口</summary>
    public interface IEleDI
    {
        /// <summary>接口【IEleDI】输入地址</summary>
        double DiAddress { set; get; }
        /// <summary>接口【IEleDI】输入使能</summary>
        bool DiEnable { set; get; }
        /// <summary>接口【IEleDI】常开/常闭类型</summary>
        EleDIType DiType { set; get; }
        /// <summary>接口【IEleDI】是否下降沿</summary>
        bool EnFallEvent { get; set; }
        /// <summary>接口【IEleDI】是否上升沿</summary>
        bool EnRiseEvent { get; set; }
        /// <summary>接口【IEleDI】线号</summary>
        string LineMark { get; set; }

        /// <summary>接口【IEleDI】DI读取</summary>
        /// <returns>bool</returns>
        bool Read();
    }
}