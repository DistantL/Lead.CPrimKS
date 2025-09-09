using System.Collections.Generic;
using System.Xml;

namespace Lead.CPrim.Interfaces
{
	/// <summary>基元配置</summary>
	public class SinglePrimConfig
	{
		/// <summary>基元类型名称</summary>
		public string VisioPrimType { get; set; }
		/// <summary>配置信息</summary>
		public XmlNode PrimXmlNode { get; set; }
	}
	/// <summary>基元配置管理器</summary>
	public class PrimConfigs
	{
		/// <summary>基元配置集合</summary>
		public List<SinglePrimConfig> PrimConfigList = new List<SinglePrimConfig>();
	}
}
