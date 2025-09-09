using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lead.CPrim.Interfaces
{
	/// <summary>显示配置</summary>
	public class SingleShowConfig
	{
		/// <summary>显示类型</summary>
		public string ShowType { get; set; }
		/// <summary>显示配置数据</summary>
		public XmlNode ShowXmlNode { get; set; }
	}
	/// <summary>显示配置管理器</summary>
	public class ShowConfigs
	{
		/// <summary>显示配置集合</summary>
		public List<SingleShowConfig> ListShowConfigs = new List<SingleShowConfig>();
	}
}
