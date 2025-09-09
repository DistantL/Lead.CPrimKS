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
		public DateTime EndTime { get; set; }

		[Description("产品类型")]
		public string ProductType { get; set; }

		[Description("产品ID")]
		public string ID { get; set; }

		[Description("线体名称")]
		public string LineName { get; set; }

		[Description("结果")]
		public string Result { get; set; }

		[Description("CT")]
		public double CT { get; set; }

		[Description("2D FAI")]
		public Dictionary<object, object> Fai2d { get; set; }

		[Description("3D FAI")]
		public Dictionary<object, object> Fai3d { get; set; }

		[Description("FAI")]
		public Dictionary<object, object> Fai { get; set; }

		[Description("扫码结果")]
		public string CodeResult { get; set; }

		[Description("组装结果")]
		public string AsmResult { get; set; }

		[Description("复检结果")]
		public string ReCheckResult { get; set; }

		[Description("Mes查询结果")]
		public string MesQueryResult { get; set; }

		[Description("Mes过站结果")]
		public string MesAddResult { get; set; }

		[Description("PDCA结果")]
		public string PDCAResult { get; set; }

		public ProductInfo(string id, string result)
		{
			CreateTime = DateTimeOffset.Now.LocalDateTime;
			EndTime = DateTimeOffset.Now.LocalDateTime;
			ID = id;
			Result = result;
			ProductType = "";
			CT = 2.35;
		}

		public ProductInfo(int holeNum, string productType = "")
		{
			CreateTime = DateTimeOffset.Now.LocalDateTime;
			EndTime = DateTimeOffset.Now.LocalDateTime;
			ID = CreateTime.ToString("yyyyMMddHHmmss") + $"-{holeNum}";
			ProductType = productType;
			Result = "";
			CT = 2.35;
		}

		public ProductInfo()
		{
			CreateTime = DateTimeOffset.Now.LocalDateTime;
			EndTime = DateTimeOffset.Now.LocalDateTime;
			ID = CreateTime.ToString("yyyyMMddHHmmss") + "-0";
			ProductType = "";
			Result = "";
			CT = 4.0;
			Result = "";
			Fai = new Dictionary<object, object>();
			Fai2d = new Dictionary<object, object>();
			Fai3d = new Dictionary<object, object>();
		}
	}
}
