using System;
using System.Xml;
using System.Xml.Linq;

namespace Lead.CPrim.BaseParam
{
	public static class Extensions
	{
		public static XElement GetXElement(this XmlNode node)
		{
			XDocument xDoc = new XDocument();
			using (XmlWriter xmlWriter = xDoc.CreateWriter())
			{
				node.WriteTo(xmlWriter);
			}
			return xDoc.Root;
		}

		public static XmlNode GetXmlNode(this XElement element)
		{
			XmlReader xmlReader = element.CreateReader();
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(xmlReader);
			xmlReader.Close();
			return xmlDoc;
		}
	}
}
