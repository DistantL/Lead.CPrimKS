using Newtonsoft.Json;
using System.ComponentModel;

namespace Lead.CPrim.PrimLESI_EController
{
    /// <summary>
    /// 配置表
    /// </summary>
    public class EcatNode
    {
        /// <summary>节点号</summary>
        public ushort NodeID { set; get; }
        /// <summary>节点类型（Coupler_A/Coupler_B/Coupler_C/Axis/Di/Do/Ai/Ao/Other）</summary>
        public EcatNodeType NodeType { set; get; }
        /// <summary>输入个数</summary>
        public ushort InputCount { set; get; } = 16;
        /// <summary>输入地址</summary>
        public ushort InAddress { set; get; }
        /// <summary>输出个数</summary>
        public ushort OutputCount { set; get; } = 16;
        /// <summary>输出地址</summary>
        public ushort OutAddress { set; get; }
        /// <summary>轴Id</summary>
        public ushort AxisId { set; get; } = 0;
        /// <summary>轴类型（Servo/Encoder/Other）</summary>
        public EcatAxisType AxisType { set; get; }
        /// <summary>扫描使能</summary>
        public bool ScanEnable { set; get; }
        /// <summary>输入端口值</summary>
        [JsonIgnore] public uint[] InputPort { set; get; } = new uint[0];
        /// <summary>输出端口值</summary>
        [JsonIgnore] public uint[] OutputPort { set; get; } = new uint[0];


        #region Ctor
        /// <summary>Ctor有2个参数</summary>
        /// <param name="nodeId">节点号</param>
        /// <param name="nodeType">节点类型</param>
        public EcatNode(ushort nodeId, EcatNodeType nodeType)
        {
            NodeID = nodeId;
            NodeType = nodeType;
            switch (nodeType)
            {
                case EcatNodeType.Coupler_A:
                    InputCount = 0;
                    OutputCount = 0;
                    AxisType = EcatAxisType.Other;
                    break;
                case EcatNodeType.Coupler_B:
                    InputCount = 0;
                    OutputCount = 0;
                    AxisType = EcatAxisType.Other;
                    break;
                case EcatNodeType.Coupler_C:
                    InputCount = 0;
                    OutputCount = 0;
                    AxisType = EcatAxisType.Other;
                    break;
                case EcatNodeType.Axis:
                    InputCount = 0;
                    OutputCount = 0;
                    AxisType = EcatAxisType.Servo;
                    break;
                case EcatNodeType.DI:
                    InputCount = 16;
                    OutputCount = 0;
                    AxisType = EcatAxisType.Other;
                    break;
                case EcatNodeType.DO:
                    InputCount = 0;
                    OutputCount = 16;
                    AxisType = EcatAxisType.Other;
                    break;
                case EcatNodeType.AI:
                    InputCount = 4;
                    OutputCount = 0;
                    AxisType = EcatAxisType.Other;
                    break;
                case EcatNodeType.AO:
                    InputCount = 0;
                    OutputCount = 4;
                    AxisType = EcatAxisType.Other;
                    break;
                case EcatNodeType.Other:
                    InputCount = 0;
                    OutputCount = 0;
                    AxisType = EcatAxisType.Other;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Ctor有8个参数
        /// </summary>
        /// <param name="nodeId">节点号</param>
        /// <param name="nodeType">节点类型</param>
        /// <param name="inputCount">输入个数</param>
        /// <param name="outputCount">输出个数</param>
        /// <param name="inAddress">输入地址</param>
        /// <param name="outAddress">输出地址</param>
        /// <param name="axisId">轴Id</param>
        /// <param name="axisType">轴类型</param>
        public EcatNode(ushort nodeId, EcatNodeType nodeType, ushort inputCount, ushort outputCount, ushort inAddress, ushort outAddress, ushort axisId,
            EcatAxisType axisType) : this(nodeId, nodeType)
        {
            InputCount = inputCount;
            OutputCount = outputCount;
            InAddress = inAddress;
            OutAddress = outAddress;
            AxisId = axisId;
            AxisType = axisType;
            ScanEnable = true;
        }
        /// <summary>
        /// Ctor有三个参数
        /// </summary>
        /// <param name="nodeId">节点号</param>
        /// <param name="nodeType">节点类型</param>
        /// <param name="axisId">轴Id</param>
        public EcatNode(ushort nodeId, EcatNodeType nodeType, ushort axisId) : this(nodeId, nodeType)
        {
            if (nodeType == EcatNodeType.Axis)
            {
                AxisId = axisId;
                AxisType = EcatAxisType.Servo;
            }
            ScanEnable = true;
        }
        /// <summary>
        /// Ctor无参
        /// </summary>
        public EcatNode()
        {

        } 
        #endregion
    }


    public enum EcatNodeType
    {
        [Description("耦合器A")]
        Coupler_A = 10,
        [Description("耦合器B")]
        Coupler_B = 11,
        [Description("耦合器C")]
        Coupler_C = 12,
        [Description("轴")]
        Axis = 20,
        [Description("DI")]
        DI = 30,
        [Description("DO")]
        DO = 40,
        [Description("AI")]
        AI = 60,
        [Description("AO")]
        AO = 70,
        [Description("其他")]
        Other = 0,

    }


    public enum EcatAxisType
    {
        [Description("伺服")]
        Servo = 10,
        [Description("编码器")]
        Encoder = 20,
        [Description("其他")]
        Other = 0,
    }
}
