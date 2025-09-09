using System;
using System.Collections.Generic;
using System.ComponentModel;
using MongoDB.Bson.Serialization.Attributes;

namespace Lead.CPrim.ProductInfoHelper
{
	public class ProductInfo
	{
        [Description("时间")]
		[BsonDateTimeOptions(Kind = DateTimeKind.Local)]
		public DateTime CreateTime { get; set; }

		[Description("时间")]
		[BsonDateTimeOptions(Kind = DateTimeKind.Local)]
		public DateTime EndTime { get; set; }

        [Description("班次：DS白班/NS夜班")]
        public string Shift { get; set; }

        [Description("载具ID")]
        public string FixtureID { get; set; }

        [Description("产品ID")]
		public string Sn { get; set; }

		[Description("产品类型")]
		public string ProductType { get; set; }

		[Description("结果")]
		public string Result { get; set; }

		[Description("CT")]
		public double CT { get; set; }

		[Description("FAI")]
		public Dictionary<object, object> Fai { get; set; }

		[Description("组装完成时辅料数量")]
		public int AccessaryCount { get; set; }

		[Description("抛辅料数量")]
		public int TossingCount { get; set; }

		[Description("抛辅料原因")]
		public string TossingReason { get; set; }

        [Description("当前Hive状态")]
        public int HIVE_State { get; set; }

        [Description("NG原因")]
        public string NGReason { get; set; }

        [Description("工位")]
        public string SlotIndex { get; set; }

        public ProductInfo()
		{
			this.CreateTime = DateTimeOffset.Now.LocalDateTime;
			this.EndTime = DateTimeOffset.Now.LocalDateTime;
			this.Shift = "DS";
			this.FixtureID = this.CreateTime.ToString("yyyyMMddHHmmss") + "-0";
            this.Sn = this.CreateTime.ToString("yyyyMMddHHmmss") + "-1";
			this.ProductType = "AirPods";
			this.Result = "OK";
			this.CT = 11.0;
			this.Fai = new Dictionary<object, object>();
			this.AccessaryCount = 0;
			this.TossingCount = 0;
			this.TossingReason = string.Empty;
			this.HIVE_State = 1;
            this.NGReason = string.Empty;
			this.SlotIndex = string.Empty;
		}
	}
}
