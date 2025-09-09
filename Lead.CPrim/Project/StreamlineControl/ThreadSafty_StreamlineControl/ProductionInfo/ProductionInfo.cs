using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafty_StreamlineControl
{
    public class ProductionInfo
    {
        /// <summary>
        /// 总结果,true,OK;false:NG;
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 载具SN
        /// </summary>
        public string FixtureID { get; set; }

        /// <summary>
        /// 物料SN
        /// </summary>
        public string Sn { get; set; } = string.Empty;

        /// <summary>
        /// 唯一识别码
        /// </summary>
        public string GuidCode { get; set; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// 流线编号,1;2;
        /// </summary>
        public int StreamLineIndex { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime StartTime { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime EndTime { get; set; }

        public double Output_CT { get; set; }

        public double Unit_CT { get; set; }

        // 料盘SN
        public string LotNoSN { get; set; }

        public List<SlotInfo> SlotInfosList { get; set; } = new List<SlotInfo>();

        public bool? CheckSN_Result_MES { get; set; }

        public bool? UpData_Result_PDCA { get; set; }

        public bool? UpData_Result_MES { get; set; }

        public bool? UpData_Result_HIVE { get; set; }

        public bool Enable_HIVE { get; set; }

        public bool Enable_MES { get; set; }

        public bool Enable_PDCA { get; set; }

        public string NGReason { get; set; }

        public string LogFilePath { get; set; }

        public ProductStatus ProductStatus { get; set; }
        /// <summary>
        /// 工位<br/>
        /// 供应商-抛料信息需要使用<br/>
        /// </summary>
        public int SlotIndex { get; set; }
    }
}
