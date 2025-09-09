using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.Interfaces
{
	/// <summary>元件公共接口</summary>
	public interface IEle
	{
		/// <summary>接口【IEle】元件唯一Id</summary>
		Guid Id { get; set; }
		/// <summary>接口【IEle】元件对应基元名称</summary>
		string DevName { get; set; }
		/// <summary>接口【IEle】元件名称</summary>
		string Name { get; set; }
		/// <summary>接口【IEle】元件备注</summary>
		string Info { get; set; }
		/// <summary>接口【IEle】元件被选择</summary>
		bool IsSelected { get; set; }
		/// <summary>接口【IEle】元件ConfigUI</summary>
		Control EleConfigUI { get; }
		/// <summary>接口【IEle】元件DebugUI</summary>
		Control EleDebugUI { get; }
		/// <summary>接口【IEle】元件运行状态</summary>
		EleRunState EleRunStat { get; set; }
		/// <summary>接口【IEle】元件是否启用</summary>
		bool Enable { get; set; }
		/// <summary>接口【IEle】元件隶属类型</summary>
		string EleTypeName { get; set; }
		/// <summary>接口【IEle】元件日志使能</summary>
		bool LogEnable { get; set; }
		/// <summary>接口【IEle】元件报警级别</summary>
		LogLevel EleAlarmLv { get; set; }
		/// <summary>接口【IEle】元件日志显示</summary>
		bool LogDisplay { get; set; }
		/// <summary>接口【IEle】元件手动使能</summary>
		bool ManualEnable { get; set; }
		/// <summary>接口【IEle】元件仿真模式</summary>
		bool IsSimulateMode { get; set; }

		/// <summary>接口【IEle】元件运行状态改变时发生事件</summary>
		event EleStateChangedEventHandle OnEleStateChanged;


		/// <summary>接口【IEle】元件运行状态获取</summary>
		PrimRunState IEleCheckPrimRunState();
		/// <summary>接口【IEle】元件释放</summary>
		int IEleDispose();
		/// <summary>接口【IEle】元件初始化</summary>
		int IEleInit();
		/// <summary>接口【IEle】元件复位</summary>
		int IEleReset();
		/// <summary>接口【IEle】元件停止</summary>
		int IEleStop();
		/// <summary>接口【IEle】元件刷新</summary>
		int IEleUiRefresh();
		/// <summary>接口【IEle】获取csv数据</summary>
		string GetCsvValue();
		/// <summary>接口【IEle】获取csv数据表头</summary>
		string GetCsvHeader();
		/// <summary>接口【IEle】csv转换</summary>
		int CsvToValue(string csvString);
		/// <summary>接口【IEle】元件配置转换为Node</summary>
		XmlNode IEleExportConfigXml();
		/// <summary>接口【IEle】将Node转换为元件配置</summary>
		int IEleImportConfigXml(XmlNode xmlNode);
	}

	/// <summary>元件属性公共接口</summary>
	public interface IEleTypeAttributes
	{
		/// <summary>接口【IEleTypeAttributes】元件名称</summary>
		string Name { get; }
		/// <summary>接口【IEleTypeAttributes】元件显示名称</summary>
		string DisplayName { get; }
		/// <summary>接口【IEleTypeAttributes】元件描述</summary>
		string Description { get; }
		/// <summary>接口【IEleTypeAttributes】元件图标</summary>
		Image Icon { get; }
		/// <summary>接口【IEleTypeAttributes】元件分组</summary>
		string Group { get; }
		/// <summary>接口【IEleTypeAttributes】元件主版本</summary>
		byte MajorVersion { get; }
		/// <summary>接口【IEleTypeAttributes】元件小版本</summary>
		byte MinorVersion { get; }
	}



	/// <summary>元件创建公共接口</summary>
	public interface IEleCreator
	{
		/// <summary>元件属性公共接口</summary>
		IEleTypeAttributes ConcreteEleTypeAttributes { get; }
		/// <summary>新建元件</summary>
		IEle Create();
		/// <summary>根据配置文件新建元件</summary>
		IEle Create(XmlNode primConfig);
	}


	/// <summary>元件运行状态</summary>
	public enum EleRunState
	{
		Idle = 0,
		Running = 1,
		Suspend = 2,
		Stop = 3,
		Err = 4,
		Other = 100
	}

	/// <summary>元件类型</summary>
	public enum EleTypeNameEnum
    {
		Other,
		AD,
		DA,
		Cartesian,
		CylinderLine,
		DI,
		DO,
		Light,
		EleAxisLine,
	}
}
