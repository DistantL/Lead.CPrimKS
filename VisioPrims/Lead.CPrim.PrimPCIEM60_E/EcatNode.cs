using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.PrimPCIEM60_E
{
    public class EcatNode
    {
        public ushort NodeID { get; set; }

        public EcatNodeType NodeType { get; set; }

        public ushort InputCount { get; set; } = 16;

        public ushort InAddress { get; set; }

        public ushort OutputCount { get; set; } = 16;

        public ushort OutAddress { get; set; }

        public ushort AxisID { get; set; }

        public bool ScanEnable { set; get; } = true;

        [JsonIgnore]
        public uint[] InputPort { get; set; } = new uint[0];

        [JsonIgnore]
        public uint[] OutputPort { get; set; } = new uint[0];

        public EcatNode()
        {

        }

        public EcatNode(ushort nodeId, EcatNodeType nodeType, ushort axisId) : this(nodeId, nodeType)
        {
            //if (nodeType == EcatNodeType.Axis)
            //{
                AxisID = axisId;
            //}
            ScanEnable = true;
        }

        public EcatNode(ushort nodeId,EcatNodeType nodeType)
        {
            NodeID = nodeId;
            NodeType = nodeType;
            switch (nodeType)
            {
                case EcatNodeType.Coupler:
                    InputCount = 0;
                    OutputCount = 0;
                    break;
                case EcatNodeType.Axis:
                    InputCount = 0;
                    OutputCount = 0;
                    break;
                case EcatNodeType.Other:
                    InputCount = 0;
                    OutputCount = 0;
                    break;
                default:
                    break;
            }
        }
    }

    public enum EcatNodeType
    {
        Coupler = 1,
        Axis = 2,
        DI = 3,
        DO = 4,
        AI = 5,
        AO = 6,
        Other = 100
    }
}
