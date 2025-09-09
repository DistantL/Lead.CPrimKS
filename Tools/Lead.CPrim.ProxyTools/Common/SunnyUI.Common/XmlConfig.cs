using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Sunny.UI
{
    public class XmlConfig<TConfig> : BaseConfig<TConfig> where TConfig : XmlConfig<TConfig>, new()
	{
		private static string CurrentDir()
		{
			return Environment.CurrentDirectory.DealPath();
		}

		public override bool Load(string filename)
		{
			if (filename.IsNullOrWhiteSpace())
			{
				filename = CurrentDir() + BaseConfig<TConfig>.ConfigFile;
			}
			if (filename.IsNullOrWhiteSpace())
			{
				throw new ApplicationException("未指定" + typeof(TConfig).Name + "的配置文件路径！");
			}
			if (!File.Exists(filename))
			{
				return false;
			}
			try
			{
				ConcurrentDictionary<string, Ident> concurrentDictionary = ConfigHelper.InitIdents(BaseConfig<TConfig>.current);
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(filename);
				XmlElement documentElement = xmlDocument.DocumentElement;
				foreach (Ident value in concurrentDictionary.Values)
				{
					if (documentElement == null)
					{
						continue;
					}
					XmlNodeList elementsByTagName = documentElement.GetElementsByTagName(value.Key);
					if (elementsByTagName.Count != 1)
					{
						continue;
					}
					if (value.IsList)
					{
						value.Values.Clear();
						foreach (XmlNode childNode in elementsByTagName[0].ChildNodes)
						{
							value.Values.Add(childNode.InnerText);
						}
					}
					else
					{
						value.Value = elementsByTagName[0].InnerText;
					}
				}
				ConfigHelper.LoadConfigValue(BaseConfig<TConfig>.current, concurrentDictionary);
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
		}

		public override void Save(string filename)
		{
			if (filename.IsNullOrWhiteSpace())
			{
				filename = CurrentDir() + BaseConfig<TConfig>.ConfigFile;
			}
			if (filename.IsNullOrWhiteSpace())
			{
				throw new ApplicationException("未指定" + typeof(TConfig).Name + "的配置文件路径！");
			}
			ConcurrentDictionary<string, Ident> concurrentDictionary = ConfigHelper.InitIdents(BaseConfig<TConfig>.current);
			ConfigHelper.SaveConfigValue(BaseConfig<TConfig>.Current, concurrentDictionary);
			List<string> list = new List<string>
			{
				"<?xml version=\"1.0\" encoding=\"utf-8\"?> ",
				"<!--" + BaseConfig<TConfig>.Description + "--> "
			};
			list.Add("<" + GetType().Name + ">");
			SortedList<int, Ident> sortedList = new SortedList<int, Ident>();
			foreach (Ident value in concurrentDictionary.Values)
			{
				sortedList.Add(value.Index, value);
			}
			foreach (Ident value2 in sortedList.Values)
			{
				if (!value2.Description.IsNullOrEmpty())
				{
					list.Add("    <!--" + value2.Description + "-->");
				}
				if (!value2.IsList)
				{
					list.Add("    <" + value2.Key + ">" + value2.Value + "</" + value2.Key + ">");
					continue;
				}
				list.Add("    <" + value2.Key + ">");
				foreach (string value3 in value2.Values)
				{
					list.Add("        <Value>" + value3 + "</Value>");
				}
				list.Add("    </" + value2.Key + ">");
			}
			list.Add("</" + GetType().Name + ">");
			File.WriteAllLines(filename, list.ToArray(), Encoding.UTF8);
		}
	}
}
