namespace Lead.CPrim.PrimLESI_EController.Controls
{
    public class ControlEnum
    {
        /// <summary>IO类型</summary>
        public enum IOType
        {
            /// <summary>数字量输入</summary>
            DI = 1,
            /// <summary>数字量输出</summary>
            DO = 2,
            /// <summary>模拟量输入</summary>
            AI = 3,
            /// <summary>模拟量输出</summary>
            AO = 4,
            /// <summary>其它</summary>
            Other = 100,
        }
    }
}