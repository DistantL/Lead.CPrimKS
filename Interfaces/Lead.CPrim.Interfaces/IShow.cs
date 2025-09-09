using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.Interfaces
{
	/// <summary>新建显示基元Del</summary>
	public delegate void CreateShowEventHandler(string devTypeName);

	public delegate void ShowClickEventHandle(int type, string devName, Guid guid);
	public delegate void ShowControlChangeName(Guid id, string dstName);

	public delegate void AddShow(string group, string type, string showName, Guid showID);
	public delegate void ChangeShowName(Guid showID, string dstShowName);
	public delegate void RemoveShow(Guid showID);



	/// <summary>显示公共接口</summary>
	public interface IShow
	{
		/// <summary>接口【IShow】显示唯一Id</summary>
		Guid Id { get; set; }
		/// <summary>接口【IShow】显示名称</summary>
		string Name { get; set; }
		/// <summary>接口【IShow】显示类型名称</summary>
		string ShowTypeName { get; set; }
		/// <summary>接口【IShow】显示使能</summary>
		bool Enable { get; set; }
		/// <summary>接口【IShow】显示版本</summary>
		string Version { get; set; }
		/// <summary>接口【IShow】显示ConfigUi</summary>
		Control ConfigUi { get; }
		/// <summary>接口【IShow】显示OutputUi</summary>
		Control OutputUi { get; }

		/// <summary>接口【IShow】显示释放</summary>
		int IShowDispose();
		/// <summary>接口【IShow】Objects to XML</summary>
		XmlNode IShowExportConfigXml();
		/// <summary>接口【IShow】XMLs to object</summary>
		int IShowImportConfigXml(XmlNode xmlNode);
	}



	/// <summary>显示属性公共接口</summary>
	public interface IShowTypeAttributes
	{
		/// <summary>接口【IShowTypeAttributes】显示名称</summary>
		string Name { get; }
		/// <summary>接口【IShowTypeAttributes】显示名称</summary>
		string DisplayName { get; }
		/// <summary>接口【IShowTypeAttributes】显示描述</summary>
		string Description { get; }
		/// <summary>接口【IShowTypeAttributes】显示图标</summary>
		Image Icon { get; }
		/// <summary>接口【IShowTypeAttributes】显示分组</summary>
		string DisplayGroup { get; }
		/// <summary>接口【IShowTypeAttributes】显示分组</summary>
		string Group { get; }
		/// <summary>接口【IShowTypeAttributes】显示主版本</summary>
		byte MajorVersion { get; }
		/// <summary>接口【IShowTypeAttributes】显示小版本</summary>
		byte MinorVersion { get; }
	}



	/// <summary>显示创建公共接口</summary>
	public interface IShowCreator
	{
		/// <summary>显示属性公共接口</summary>
		IShowTypeAttributes ConcreteShowTypeAttributes { get; }
		/// <summary>新建显示</summary>
		IShow Create();
		/// <summary>根据配置文件新建显示</summary>
		IShow Create(XmlNode showConfig);
	}
}
