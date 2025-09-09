using System;
using System.Xml;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>工具帮助类代理</summary>
    public class XMLHelper
    {
        /// <summary>XML→object（反序列化）</summary>
        /// <param name="node">节点</param>
        /// <param name="objectType">类型</param>
        /// <returns>object</returns>
        public static object XMLToObject(XmlNode node, Type objectType)
        {
            return XmlHelper.XMLHelper.XMLToObject(node, objectType);
        }
        /// <summary> Objects→XML（序列化） </summary>
        /// <param name="config">类型</param>
        /// <returns>节点</returns>
        public static XmlNode ObjectToXML(object config)
        {
            return XmlHelper.XMLHelper.ObjectToXML(config);
        }
    }
}
