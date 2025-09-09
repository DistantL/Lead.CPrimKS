using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>工具帮助类代理</summary>
    public partial class XmlSerializerHelper
	{
		/// <summary>object→XML并保存</summary>
		/// <param name="myDs">object</param>
		/// <param name="XmlFilePath">地址</param>
		/// <param name="type">类型</param>
		/// <returns>bool</returns>
		public static bool WriteXML(object myDs, string XmlFilePath, Type type)
		{
			return XmlHelper.XmlSerializerHelper.WriteXML(myDs, XmlFilePath, type);
		}
		/// <summary>XML→object</summary>
		/// <param name="XmlFilePath">地址</param>
		/// <param name="type">类型</param>
		/// <returns>object</returns>
		public static object ReadXML(string XmlFilePath, Type type)
		{
			return XmlHelper.XmlSerializerHelper.ReadXML(XmlFilePath, type);
		}
        /// <summary>XML→object（原名：XmlDeserializeFromFile）</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="path">地址</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>object</returns>
        public static T ReadXML<T>(string path, Encoding encoding)
        {
			return XmlHelper.XmlSerializerHelper.ReadXML<T>(path, encoding);
        }
    }
}
