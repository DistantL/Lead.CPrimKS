using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.PrimOPC
{
    public class NodeConfig
    {
        /// <summary>
        /// 节点序号
        /// </summary>
        public int NodeNum { get; set; }
        /// <summary>
        /// 节点的Key
        /// </summary>
        public string NodeKey { get; set; }
        /// <summary>
        /// 节点的Value
        /// </summary>
        public string NodeName { get; set; }
    }
}
