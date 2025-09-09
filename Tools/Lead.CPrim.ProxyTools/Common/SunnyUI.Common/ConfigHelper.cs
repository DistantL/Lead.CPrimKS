using Lead.CPrim.ProxyTools;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;

namespace Sunny.UI
{
    public static class ConfigHelper
	{
		public static Tuple<string, string> GetConfigFile<TConfig>()
		{
			string item = "配置文件";
			ConfigFileAttribute customAttribute = typeof(TConfig).GetCustomAttribute<ConfigFileAttribute>();
			string item2;
			if (customAttribute?.FileName.IsNullOrWhiteSpace() ?? true)
			{
				item2 = typeof(TConfig).Name + ".cfg";
			}
			else
			{
				item2 = customAttribute.FileName;
				if (!customAttribute.Description.IsNullOrEmpty())
				{
					item = customAttribute.Description;
				}
			}
			return new Tuple<string, string>(item2, item);
		}

		public static ConcurrentDictionary<string, Ident> InitIdents<TConfig>(TConfig config)
		{
			ConcurrentDictionary<string, Ident> concurrentDictionary = new ConcurrentDictionary<string, Ident>();
			List<PropertyInfo> needProperties = config.GetType().GetNeedProperties();
			foreach (PropertyInfo item in needProperties)
			{
				Ident ident = new Ident
				{
					Key = item.Name,
					Show = true,
					Description = item.Description(),
					IsList = item.PropertyType.IsList()
				};
				ConfigSectionAttribute customAttribute = item.GetCustomAttribute<ConfigSectionAttribute>();
				ident.Section = ((customAttribute != null) ? customAttribute.Section : "");
				ConfigPropertyAttribute customAttribute2 = item.GetCustomAttribute<ConfigPropertyAttribute>();
				ident.Caption = ((customAttribute2 != null) ? customAttribute2.Caption : "");
				ident.Unit = ((customAttribute2 != null) ? customAttribute2.Unit : "");
				ident.Description = ((customAttribute2 != null) ? customAttribute2.Description : "");
				ConfigIndexAttribute customAttribute3 = item.GetCustomAttribute<ConfigIndexAttribute>();
				ident.Index = customAttribute3?.Index ?? (32767 - concurrentDictionary.Count);
				ident.Show = customAttribute3?.Show ?? true;
				if (ident.Description.IsNullOrEmpty())
				{
					ident.Description = item.DisplayName() ?? item.Description();
				}
				if (ident.Description.IsNullOrEmpty())
				{
					ident.Description = "";
				}
				if (!concurrentDictionary.ContainsKey(ident.Key))
				{
					concurrentDictionary.TryAdd(ident.Key, ident);
				}
			}
			return concurrentDictionary;
		}

		public static object DefaultValue(Type targetType)
		{
			return targetType.IsValueType ? Activator.CreateInstance(targetType) : null;
		}

		public static void LoadConfigValue<TConfig>(TConfig config, ConcurrentDictionary<string, Ident> idents)
		{
			List<PropertyInfo> needProperties = config.GetType().GetNeedProperties();
			foreach (PropertyInfo item in needProperties)
			{
				object value = item.GetValue(config, null);
				Type propertyType = item.PropertyType;
				if (propertyType == typeof(string))
				{
					object value2 = idents[item.Name].Value;
					item.SetValue(config, Convert.ChangeType((value2 == null) ? value : value2, propertyType), null);
					continue;
				}
				if (ConvertEx.CanConvent(propertyType))
				{
					object value3 = ConvertEx.StringToObject(idents[item.Name].Value, propertyType, value);
					item.SetValue(config, Convert.ChangeType(value3, propertyType), null);
					continue;
				}
				if (propertyType.IsList())
				{
					Type[] genericArguments = propertyType.GetGenericArguments();
					if (genericArguments.Length != 1)
					{
						throw new ApplicationException("转换出错: " + propertyType.FullName);
					}
					Type type = genericArguments[0];
					Type type2 = typeof(List<>).MakeGenericType(type);
					MethodInfo method = type2.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);
					if (method == null)
					{
						continue;
					}
					object obj = type2.InvokeMember(null, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance, null, null, new object[0]);
					foreach (string value4 in idents[item.Name].Values)
					{
						if (type == typeof(string))
						{
							object obj2 = value4;
							method.Invoke(obj, new object[1] { obj2 });
						}
						else if (ConvertEx.CanConvent(type))
						{
							object obj3 = ConvertEx.StringToObject(value4, type, DefaultValue(type));
							method.Invoke(obj, new object[1] { obj3 });
						}
					}
					item.SetValue(config, obj, null);
					continue;
				}
				throw new ApplicationException("不支持此类型: " + propertyType.FullName);
			}
		}

		public static void SaveConfigValue<TConfig>(TConfig config, ConcurrentDictionary<string, Ident> idents)
		{
			List<PropertyInfo> needProperties = config.GetType().GetNeedProperties();
			foreach (PropertyInfo item in needProperties)
			{
				object value = item.GetValue(config, null);
				Type propertyType = item.PropertyType;
				if (ConvertEx.CanConvent(propertyType))
				{
					string value2 = ConvertEx.ObjectToString(value, propertyType);
					idents[item.Name].Value = value2;
					continue;
				}
				if (propertyType.IsList())
				{
					Type[] genericArguments = propertyType.GetGenericArguments();
					if (genericArguments.Length != 1)
					{
						throw new ApplicationException("转换出错: " + propertyType.FullName);
					}
					Type type = genericArguments[0];
					IEnumerable enumerable = value as IEnumerable;
					if (enumerable == null)
					{
						throw new ApplicationException("转换出错: " + propertyType.FullName);
					}
					idents[item.Name].Values.Clear();
					foreach (object item2 in enumerable)
					{
						if (ConvertEx.CanConvent(type))
						{
							idents[item.Name].Values.Add(ConvertEx.ObjectToString(item2, type));
							continue;
						}
						throw new ApplicationException("不支持此类型: " + propertyType.FullName);
					}
					continue;
				}
				throw new ApplicationException("不支持此类型: " + propertyType.FullName);
			}
		}
	}
}
