using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Lead.CPrim.XmlHelper
{
    /// <summary>XML帮助类</summary>
    public class XMLHelper
    {
        /// <summary>XML→object（反序列化）</summary>
        /// <param name="node">节点</param>
        /// <param name="type">类型</param>
        /// <returns>object</returns>
        public static object XMLToObject(XmlNode node, Type type)
        {
            object obj = null;
            if (node == null) return null;
            try
            {
                using (StringReader reader = new StringReader(node.OuterXml))
                {
                    XmlSerializer ser = new XmlSerializer(type);
                    obj = ser.Deserialize(reader);
                }
            }
            catch
            {
                obj = null;
            }
            return obj;
        }
        /// <summary> Objects→XML（序列化） </summary>
        /// <param name="config">类型</param>
        /// <returns>节点</returns>
        public static XmlNode ObjectToXML(object config)
        {
            XmlNode node = null;
            try
            {
                XmlDocument xnd = new XmlDocument();
                if (config != null)
                {
                    using (StringWriter writer = new StringWriter(CultureInfo.InvariantCulture))
                    {
                        Type t = config.GetType();
                        XmlSerializer ser = new XmlSerializer(t);
                        ser.Serialize(writer, config);
                        xnd.LoadXml(writer.ToString());
                        node = xnd.DocumentElement;
                    }
                }
            }
            catch( Exception ex)
            {
                Debug.WriteLine(ex.Message);
                node = null;
            }
            return node;
        }






        /// <summary> Creates the specified node name. </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <returns>XmlNode.</returns>
        public static XmlNode Create(string nodeName)
        {
            XmlDocument doc = new XmlDocument();
            return doc.CreateElement(nodeName);
        }
        /// <summary> Creates the attribute. </summary>
        /// <param name="node">The node.</param>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <param name="value">The value.</param>
        /// <returns>XmlAttribute.</returns>
        public static XmlAttribute CreateAttribute(XmlNode node, string attributeName, string value)
        {
            try
            {
                XmlDocument doc = node.OwnerDocument;
                XmlAttribute attr = doc.CreateAttribute(attributeName);
                attr.Value = value;
                node.Attributes.SetNamedItem(attr);
                return attr;
            }
            catch (Exception err)
            {
                string desc = err.Message;
                return null;
            }
        }
    }
}
