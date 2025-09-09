using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;

namespace Lead.CPrim.Interfaces
{
	/// <summary>日志分类</summary>
	public enum LogClassification
	{
		/// <summary>基元</summary>
		VisioPrim = 0,
		/// <summary>元件</summary>
		Elements = 1,
		/// <summary>任务</summary>
		Task = 2,
		/// <summary>模块</summary>
		Module = 3,
		/// <summary>工站</summary>
		Station = 4,
		/// <summary>参数</summary>
		Parameter = 5,
		/// <summary>工具</summary>
		Tools,
		/// <summary>其它</summary>
		Other = 9
	}
	/// <summary>日志等级</summary>
	public enum LogLevel
	{
		/// <summary>重大错误</summary>
		Fatal = 1,
		/// <summary>一般错误</summary>
		Error = 2,
		/// <summary>警告</summary>
		Warn = 3,
		/// <summary>信息</summary>
		Info = 4,
		/// <summary>调试</summary>
		Debug = 5,
		/// <summary>追溯</summary>
		Trace = 6,
		/// <summary>其它</summary>
		Other = 9
	}

	/// <summary>日志等级</summary>
	public enum HiveLogLevel
	{
		/// <summary>错误</summary>
		Error = 1,
		/// <summary>数据</summary>
		Data = 2,
		/// <summary>状态</summary>
		State = 3,
		/// <summary>其它</summary>
		Other = 9
	}

	/// <summary>基元日志对应ID</summary>
	/// <remarks></remarks>
	public enum PrimLogId
	{
		//Main		100-149
		View = 100,
		AFormatGUI,
		FormMain ,

		//Proxy		150-199

		//Controls	200-299
		LogsHistoryQuery = 200,
		Controls,
		CmpTrigHelper,

		//Elements	300-349
		EleCommon = 300,

		EleAnalogInput = 310,
		EleAnalogOutput,
		EleAxisByType,
		EleCartesian,
		EleCyldLine,
		EleDI,
		EleDO,
		EleLight,

		//Param		350-399
		CommonParam,
		DynamicParam,

		//Prim		400-599
		PrimCommon = 400,
		ShowCommon,

		PrimSktClient = 410,
		PrimSktServer,
		PrimYouShangRFID,
		PrimVarManager,
		PrimLESI_EController,
		PrimADLink_E,
		PrimFinsNet,
		PrimOPC,
        PrimRobotInovancePro,
        PrimPCIEM60_E,
		PrimSSZN,



		ShowHistorgram = 550,
		ShowCapacityOfProduction,
		ShowAtlasCurve,
		ShowPressureCurve,

		//Task		600-649
		Task = 600,
		TaskHelper = 610,
		TaskCommon,
		DefaultTask,
		MachineHelper,

		//Config	650-699
		FormConfig = 650,
		SoftwareConfig,
		StationCommon,
		FaiHelper,

		//Tools
		Tool = 700,
	}
	/// <summary>日志管理类</summary>
	public class LogClass
	{
		/// <summary>_id</summary>
		[BsonId][DisplayName()]
		public ObjectId _id { get; set; }

		/// <summary>等级</summary>
		[DisplayName("等级")]
		public string Level { get; set; }

		/// <summary>属性</summary>
		public LogProperties Properties { get; set; }

		/// <summary>时间</summary>
		[BsonDateTimeOptions(Kind = DateTimeKind.Local)]
		[DisplayName("时间")]
		public DateTime TimeStamp { get; set; }
	}
	/// <summary>日志子类</summary>
	public class LogProperties
	{
		/// <summary>日志分类</summary>
		[DisplayName("分类")]
		public string Classification { get; set; }
		/// <summary>日志位置</summary>
		[DisplayName("来源")]
		public string Location { get; set; }
		/// <summary>日志Id</summary>
		[DisplayName("ID")]
		public long LogId { get; set; }
		/// <summary>日志信息</summary>
		[DisplayName("信息")]
		public string Message { get; set; }
	}
}
