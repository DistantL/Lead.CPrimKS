/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2022.
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明
 *
 * 1.3.22.0517 -> 增加委托：气缸统计委托
******************************************************************************/

using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Lead.CPrim.Interfaces
{
	public delegate void CellOutputUpdate(Guid cellGuid);
	public delegate int PrimDataRefresh(string devName, object context);
	public delegate int PrimOpLog(string devName, object log);
	public delegate int PrimStateChanged(string devName, object context);


	/// <summary>元件状态改变委托</summary>
	/// <param name="eleRunState">元件运行状态</param>
	public delegate void EleStateChangedEventHandle(EleRunState eleRunState);

	/// <summary>气缸统计委托</summary>
	/// <param name="name"></param>
	public delegate void CylinderActionStatisticEventHandler(string name);


	/// <summary>切换当前产品委托</summary>
	/// <param name="currentProduct">当前产品</param>
	/// <param name="products">产品集合</param>
	public delegate void ChangeCurrentProductEventHandle(string currentProduct, List<string> products);

	public enum Language
	{
		other = -1,
		zh_CN,
		en_US,
		vi_VN,
	}

	/// <summary>登录级别</summary>
	public enum OpLevel
	{
		/// <summary>其它</summary>
		Other = -1,
		/// <summary>作业员</summary>
		NoLogin = 0,
		/// <summary>维护</summary>
		Level1 = 1,
		/// <summary>管理员</summary>
		Level2 = 2,
		/// <summary>开发</summary>
		Level3 = 3,
	}

	/// <summary>权限记录类</summary>
	public class LogIORecord
	{
		public LogIORecord()
		{
			CreateTime = DateTime.Now;
			Name = "系统";
			Level = "Level1";
			Position = "操作员";
		}

		/// <summary>创建时间</summary>
		[BsonDateTimeOptions(Kind = DateTimeKind.Local)]
		public DateTime CreateTime { set; get; }
		/// <summary>登录名称</summary>
		public string Name { get; set; }
		/// <summary>登录级别</summary>
		public string Level { get; set; }
		/// <summary>登录职位</summary>
		public string Position { get; set; }
	}

	public class SoftWareData
	{
		public SoftWareData()
		{
			SoftWareName = string.Empty;
			TaskVersion = string.Empty;
			LimitVersion = "V1.0";
			SoftWareVersion = string.Empty;
			LimitSoftWareVersion = "LEA_1.1.0.0_240614_POR";
			SoftWareHashCode = string.Empty;
			VisionHashCode = string.Empty;
		}

		/// <summary>软件名称</summary>
		public string SoftWareName { get; set; }

		/// <summary>Task版本</summary>
		public string TaskVersion { get; set; }

		/// <summary>初始Task版本</summary>
		public string LimitVersion { get; set; }

		/// <summary>软件版本</summary>
		public string SoftWareVersion { get; set; }

		/// <summary>初始软件版本</summary>
		public string LimitSoftWareVersion { get; set; }

		/// <summary>上位机软件HashCode</summary>
		public string SoftWareHashCode { get; set; }

		/// <summary>视觉软件HashCode</summary>
		public string VisionHashCode { get; set; }
	}

	/// <summary>数据类型</summary>
	public enum DataType
	{
		/// <summary>bool</summary>
		BOOL,
		/// <summary>double</summary>
		DOUBLE,
		/// <summary>string</summary>
		STRING,
		/// <summary>class</summary>
		CLASS,
		/// <summary>int</summary>
		INT,
		/// <summary>other</summary>
		Other
	}

	/// <summary>数据类型</summary>
	public enum ProtocolDataType
	{
		/// <summary>short</summary>
		SHORT,
		/// <summary>int</summary>
		INT,
		/// <summary>long</summary>
		LONG,
		/// <summary>float</summary>
		FLOAT,
		/// <summary>floatArray</summary>
		FLOATARRAY,
		/// <summary>ushort</summary>
		USHORT,
		/// <summary>uint</summary>
		UINT,
		/// <summary>ulong</summary>
		ULONG,
		/// <summary>double</summary>
		DOUBLE,
		/// <summary>bool</summary>
		BOOL,
		/// <summary>string</summary>
		STRING,
		/// <summary>other</summary>
		OTHER
	}


	/// <summary>软件错误代码
	/// <para>0-500状态机</para>
	/// <para>500-1000工站</para>
	/// <para>1000-2000元件</para>
	/// <para>2000-5000基元</para>
	/// <para>5000-7000显示</para>
	/// <para>7000-9000工具</para></summary>
	public enum SoftWareAlarm
	{
		OK = 0,
		方法逻辑错误 = -1,
		参数为空 = -5,
		集合中包含重复的键 = -6,
		集合删除指定键失败 = -7,

		//Main		100-499


		//Proxy		500-999

		//Controls	1000-1499

		//Elements	1500-2499
		#region EleAnalogInput	1500-1549

		#endregion

		#region EleAnalogOutput	1550-1599

		#endregion

		#region EleAxisByType	1600-1649
		EleAxisByType_未启用 = 1600,
		EleAxisByType_轴未使能 = 1601,
		EleAxisByType_轴报警中 = 1602,
		EleAxisByType_MotionCard为空 = 1603,
		EleAxisByType_轴加减速设置出错 = 1604,
		EleAxisByType_轴正负极限_报警_使能检测未通过 = 1605,
		EleAxisByType_轴报警_使能检测未通过 = 1606,
		EleAxisByType_轴偏差检测报错 = 1607,
		EleAxisByType_运动超时 = 1608,
		EleAxisByType_轴使能失败 = 1609,
		EleAxisByType_轴复位报警失败 = 1610,
		EleAxisByType_轴控制基元未找到 = 1611,
		EleAxisByType_轴控制基元类型不匹配 = 1612,
		EleAxisByType_轴速度为0 = 1612,

		EleAxisByType_AxisVelMove方法返回值不等于0 = 1630,
		EleAxisByType_AxisRelMove方法返回值不等于0 = 1631,
		EleAxisByType_AxisAbsMove方法返回值不等于0 = 1632,
		EleAxisByType_AxisSetEnable方法返回值不等于0 = 1633,
		EleAxisByType_AxisResetAlarm方法返回值不等于0 = 1634,
		EleAxisByType_SetAxisFeedbackPulseToCommand方法返回值不等于0 = 1635,
		EleAxisByType_SetAxisPositionAndFeedbackPulse方法返回值不等于0 = 1636,
		EleAxisByType_AxisChangeVel方法返回值不等于0 = 1637,
		EleAxisByType_AxisSetAcc_AxisSetDec返回值不等于0 = 1638,
		EleAxisByType_AxisStopMove返回值不等于0 = 1639,
		EleAxisByType_AxisSetAccDec返回值不等于0 = 1640,
		EleAxisByType_AxisSetMinVel_AxisSetMaxVel_AxisSetStopVel方法返回值不等于0 = 1641,
		EleAxisByType_AxisHomeMove方法返回值不等于0 = 1642,
        EleAxisByType_SetAxisBand方法返回值不等于0 = 1643,
        #endregion

        #region EleCartesian	1650-1699
        EleCartesian_未启用 = 1650,
		EleCartesian_元件不在运行状态 = 1651,
		EleCartesian_轴集合中不包含指定轴Id = 1652,
		EleCartesian_轴_点位_速度数组长度小于等于0 = 1653,
		EleCartesian_轴_点位_速度数组长度不一致 = 1654,
		EleCartesian_轴总数为0 = 1655,
		EleCartesian_轴集合中不包含X轴 = 1656,
		EleCartesian_轴集合中不包含Y轴 = 1657,
		EleCartesian_轴集合中不包含Z轴 = 1658,
		EleCartesian_轴集合中不包含U轴 = 1659,
		EleCartesian_轴集合中不包含V轴 = 1660,
		EleCartesian_轴集合中不包含W轴 = 1661,
		EleCartesian_轴组配置目录为空 = 1662,
		EleCartesian_轴组配置目录不存在 = 1663,
		EleCartesian_轴组点位目录为空 = 1664,
		EleCartesian_轴组点位目录不存在 = 1665,
		#endregion

		#region EleCyldLine	1700-1749
		EleCyldLine_元件未使能 = 1700,
		EleCyldLine_气缸回原位失败 = 1701,
		EleCyldLine_气缸去伸位失败 = 1702,
		EleCyldLine_数字量输出控制失败 = 1703,
		EleCyldLine_数字量输出读取失败 = 1704,
		EleCyldLine_数字量输入读取失败 = 1705,
		EleCyldLine_元件刷新失败 = 1706,
		EleCyldLine_元件获取基元失败 = 1707,
		EleCyldLine_元件原位工作位DO均未启用 = 1708,
		#endregion

		#region EleDI	1750-1799

		#endregion

		#region EleDO	1800-1849

		#endregion

		#region EleLight	1850-1899

		#endregion

		//...1900-2399...

		#region EleCommon	2400-2499

		#endregion



		//Param		2500-3000
		CommonParam,
		DynamicParam,



		//Prim		3000-5999
		#region	MongoDB	3000-3049
		MongoDB_基元未初始化 = 3000,
		MongoDB_客户端为空 = 3001,
		MongoDB_数据库为空 = 3002,
		MongoDB_参数为空 = 3003,
		MongoDB_开始时间大于结束时间 = 3004,
		MongoDB_只能为Gt或者Gte = 3005,
		MongoDB_只能为Lt或者Lte = 3006,
		MongoDB_API函数返回值不等于0 = 3007,
		MongoDB_API函数运行时报错 = 3008,
		MongoDB_插入失败 = 3009,
		MongoDB_更新失败 = 3010,
		MongoDB_查询失败 = 3011,
		MongoDB_删除失败 = 3012,
		MongoDB_条件与值计数不一致 = 3013,
		MongoDB_查询时开始时间大于结束时间 = 3014,
		MongoDB_查询时字符串转换为时间格式失败 = 3015,
		MongoDB_查询时类中不包含Result字段 = 3016,
		#endregion

		#region SktClient	3050-3099
		SktClient_消息发送失败 = 3050,
		SktClient_参数为空 = 3051,
		SktClient_IP地址为空 = 3052,
		SktClient_IP地址无效 = 3053,
		SktClient_端口无效 = 3054,
		SktClient_客户端断开连接失败 = 3055,
		SktClient_客户端释放失败 = 3056,
		SktClient_客户端初始化失败 = 3057,
		SktClient_客户端连接失败 = 3058,
		SktClient_客户端运行失败 = 3059,
		#endregion

		#region PrimVarManager 3100-3149
		PrimVarManager_JSON文件加载失败 = 3100,
		PrimVarManager_基元停止失败 = 3101,
		PrimVarManager_基元初始化失败 = 3102,
		PrimVarManager_基元运行失败 = 3103,
		PrimVarManager_JSON文件保存失败 = 3104,
		PrimVarManager_查找键不存在 = 3105,
		PrimVarManager_基元释放失败 = 3106,
		#endregion

		#region PrimLESI_EController	3150-3249
		PrimLESI_EController_基元不在运行状态 = 3150,
		PrimLESI_EController_smc_set_profile_unit返回值不等于0 = 3151,
		PrimLESI_EController_smc_get_profile_unit返回值不等于0 = 3152,
		PrimLESI_EController_smc_vmove返回值不等于0 = 3153,
		#endregion

		#region PrimFinsNet	3250-3299
		PrimFinsNet_IPrimInit返回值不等于0 = 3250,
		PrimFinsNet_IPrimConnect返回值不等于0 = 3251,
		PrimFinsNet_IPrimStart返回值不等于0 = 3252,
		#endregion


		#region Historgram	5000-5049
		Historgram_FAI不存在 = 5000,
		#endregion


		//Task		6000-6499
		#region DefaultTask	6000-6049
		DefaultTask_ITaskImportConfigXml参数为空 = 6000,
		DefaultTask_ITaskImportConfigXml反序列化失败 = 6001,
		DefaultTask_ITaskDispose超时 = 6002,
		DefaultTask_脚本路径不存在 = 6003,
		DefaultTask_创建任务脚本对象失败 = 6004,
		DefaultTask_脚本初始化出错 = 6005,
		DefaultTask_任务脚本对象不存在 = 6006,
		#endregion

		//Config	6500-6999
		#region FormConfig	6500-6549

		#endregion

		#region SoftwareConfig	6550-6599
		SoftwareConfig_当前产品为空 = 6550,
		SoftwareConfig_软件配置路径为空 = 6551,
		SoftwareConfig_软件配置路径不存在 = 6552,
		SoftwareConfig_软件配置保存失败 = 6553,
		SoftwareConfig_软件配置路径保存失败 = 6554,
		#endregion

		#region StationCommon	6600-6699

		#endregion

		#region FaiHelper	6700-6749

		#endregion



		//Tools		7000-7999
		#region Tools
		Tools_文件不存在 = 7000,
		Tools_文件夹不存在 = 7001,
		Tools_CopyFile失败 = 7002,
		Tools_无法将父目录复制到子目录 = 7003,
		Tools_CopyDirectory失败 = 7004,
		#endregion
	}


	/// <summary>文件类型</summary>
	public enum FilterType
	{
		ALL,
		CSV,
		JSON,
		XML,
		CS,
		DLL,
		XLSX,
		Other,
	}
	/// <summary>文件默认扩展名</summary>
	public enum DefaultExt
	{
		ALL,
		CSV,
		JSON,
		XML,
		CS,
		Dll,
		XLSX,
		Other,
	}
	/// <summary>数据保存</summary>
	public enum DataSaveMode
	{
		/// <summary>默认</summary>
		Other,
		/// <summary>每小时</summary>
		ByEveryHour = 1,
		/// <summary>每天</summary>
		ByEveryDay,
		/// <summary>每周</summary>
		ByEveryWeek,
		/// <summary>每月</summary>
		ByEveryMonth,
		/// <summary>每季度</summary>
		ByEverySeason,
		/// <summary>每年</summary>
		ByEveryYear
	}
}
