using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.Interfaces
{
	/// <summary>新建基元Del</summary>
	public delegate void CreateDeviceEventHandler(string devTypeName);

	public delegate void PrimClickEventHander(int type, string devName, Guid guid);
	public delegate void PrimDisplayControlChangeName(Guid id, string dstName);

	public delegate void AddPrim(string group, string type, string primName, Guid primID);
	public delegate void ChangePrimName(Guid primID, string dstPrimName);
	public delegate void RemovePrim(Guid primID);



	/// <summary>基元公共接口</summary>
	public interface IPrim
	{
		/// <summary>接口【IPrim】基元Id</summary>
		Guid Id { get; set; }
		/// <summary>接口【IPrim】基元名称</summary>
		string Name { get; set; }
		/// <summary>接口【IPrim】基元使能</summary>
		bool PrimEnable { get; set; }
		/// <summary>接口【IPrim】基元类型</summary>
		PrimType HSType { get; set; }
		/// <summary>接口【IPrim】基元类型名称</summary>
		string PrimTypeName { get; set; }
		/// <summary>接口【IPrim】基元ConfigUI</summary>
		Control PrimConfigUI { get; }
		/// <summary>接口【IPrim】基元DebugUI</summary>
		Control PrimDebugUI { get; }
		/// <summary>接口【IPrim】基元OutputUI</summary>
		Control PrimOutputUI { get; }
		/// <summary>接口【IPrim】基元连接状态</summary>
		PrimConnState PrimConnStat { get; set; }
		/// <summary>接口【IPrim】基元运行状态</summary>
		PrimRunState PrimRunStat { get; set; }
		/// <summary>接口【IPrim】</summary>
		PrimVer Ver { get; set; }
		/// <summary>接口【IPrim】当前图标索引</summary>
		int CurrentImageIndex { get; set; }


        /// <summary>接口【IPrim】基元初始化</summary>
        int IPrimInit();
		/// <summary>接口【IPrim】基元连接</summary>
		int IPrimConnect(ref string result);
		/// <summary>接口【IPrim】基元启动</summary>
		int IPrimStart();
		/// <summary>接口【IPrim】基元停止</summary>
		int IPrimStop();
		/// <summary>接口【IPrim】基元释放</summary>
		int IPrimDispose();
		/// <summary>接口【IPrim】基元任务一键连接</summary>
		int IPrimTaskInit();
		/// <summary>接口【IPrim】基元任务暂停</summary>
		int IPrimTaskPause();
		/// <summary>接口【IPrim】基元任务复位</summary>
		int IPrimTaskReset();
		/// <summary>接口【IPrim】基元任务停止</summary>
		int IPrimTaskStop();
		/// <summary>接口【IPrim】将基元配置转换为Node</summary>
		XmlNode IPrimExportConfigXml();
		/// <summary>接口【IPrim】将Node转换为基元配置</summary>
		int IPrimImportConfigXml(XmlNode xmlNode);
	}


	/// <summary>基元属性公共接口</summary>
	public interface IPrimTypeAttributes
	{
		/// <summary>接口【IPrimTypeAttributes】基元名称</summary>
		string Name { get; }

		/// <summary>接口【IPrimTypeAttributes】基元显示名称</summary>
		string DisplayName { get; }

		/// <summary>接口【IPrimTypeAttributes】基元描述</summary>
		string Description { get; }

		/// <summary>接口【IPrimTypeAttributes】基元图标</summary>
		Image Icon { get;}

		/// <summary>接口【IPrimTypeAttributes】基元图标集合</summary>
		List<Image> ListIcon { get; }

		/// <summary>接口【IPrimTypeAttributes】基元显示分组</summary>
		string DisplayGroup { get; }

		/// <summary>接口【IPrimTypeAttributes】基元分组</summary>
		string Group { get; }

		/// <summary>接口【IPrimTypeAttributes】基元主版本</summary>
		byte MajorVersion { get; }

		/// <summary>接口【IPrimTypeAttributes】基元小版本</summary>
		byte MinorVersion { get; }

		/// <summary>接口【IPrimTypeAttributes】未使用</summary>
		object this[string attrName] { get; }

		/// <summary>接口【IPrimTypeAttributes】未使用</summary>
		IEnumerable<KeyValuePair<string, object>> Attributes { get; }
	}


	/// <summary>基元创建公共接口</summary>
	public interface IPrimCreator
	{
		/// <summary>基元属性公共接口</summary>
		IPrimTypeAttributes ConcretePrimTypeAttributes { get; }
		/// <summary>新建基元</summary>
		/// <returns></returns>
		IPrim Create();
		/// <summary>根据配置文件新建基元</summary>
		/// <returns></returns>
		IPrim Create(XmlNode primConfig);
	}


	/// <summary>基元类型</summary>
	public enum PrimType
	{
		/// <summary>PLC</summary>
		PLC = 0,

		/// <summary>CNC</summary>
		CNC = 1,

		/// <summary>板卡</summary>
		MoionCard = 2,

		/// <summary>机器人</summary>
		Robot = 3,

		/// <summary>视觉</summary>
		Camera = 4,

		/// <summary>CNC</summary>
		XBus = 5,

		PcSw = 6,

		MotionControl = 7,

		PlasticMachine = 8,

		/// <summary>AGV</summary>
		AGV = 9,

		/// <summary>RFID</summary>
		RFID = 10,

		LD = 11,

		/// <summary>协议</summary>
		Protocol = 12,

		Other = 100
	}


	/// <summary>连接状态</summary>
	public enum PrimConnState
	{
		/// <summary>已连接</summary>
		Connected = 0,
		/// <summary>未连接</summary>
		UnConnected = 1,
		/// <summary>Other</summary>
		Other = 100
	}


	/// <summary>运行状态</summary>
	public enum PrimRunState
	{
		/// <summary>空闲</summary>
		Idle = 0,
		/// <summary>运行中</summary>
		Running = 1,
		/// <summary>挂起</summary>
		Suspend = 2,
		/// <summary>停止</summary>
		Stop = 3,
		/// <summary>错误</summary>
		Err = 4,
		/// <summary>Other</summary>
		Other = 100
	}


	public enum PrimVer
	{
		Omron_CJ = 0,
		Omron_NJ = 1,
		Other = 1000
	}


	public enum PrimCmdType
	{
		Default = 0,
		ContxtReturn = 1,
		Contxt2Data = 2,
		Other = 100
	}
}
