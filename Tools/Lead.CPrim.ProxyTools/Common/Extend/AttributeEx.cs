using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Lead.CPrim.ProxyTools
{
	public static class AttributeEx
	{
		public static bool As(this Type type, Type baseType)
		{
			if (type == null)
			{
				return false;
			}
			if (baseType.IsGenericTypeDefinition && type.IsGenericType && !type.IsGenericTypeDefinition)
			{
				type = type.GetGenericTypeDefinition();
			}
			if (type == baseType)
			{
				return true;
			}
			if (baseType.IsAssignableFrom(type))
			{
				return true;
			}
			bool flag = false;
			if (baseType.IsInterface)
			{
				if (type.GetInterface(baseType.FullName) != null)
				{
					flag = true;
				}
				else if (type.GetInterfaces().Any((e) => e.IsGenericType && baseType.IsGenericTypeDefinition ? e.GetGenericTypeDefinition() == baseType : e == baseType))
				{
					flag = true;
				}
			}
			if (!flag && type.Assembly.ReflectionOnly)
			{
				while (!flag && type != typeof(object))
				{
					if (!(type == null))
					{
						if (type.FullName == baseType.FullName && type.AssemblyQualifiedName == baseType.AssemblyQualifiedName)
						{
							flag = true;
						}
						type = type.BaseType;
					}
				}
			}
			return flag;
		}

		public static bool IsList(this Type type)
		{
			return type != null && type.IsGenericType && type.As(typeof(IList<>));
		}

		public static bool IsDictionary(this Type type)
		{
			return type != null && type.IsGenericType && type.As(typeof(IDictionary<,>));
		}

		public static T GetCustomAttribute<T>(this PropertyInfo info)
		{
			return (T)info.GetCustomAttributes(typeof(T), inherit: false).FirstOrDefault();
		}

		public static T GetCustomAttribute<T>(this FieldInfo info)
		{
			return (T)info.GetCustomAttributes(typeof(T), inherit: false).FirstOrDefault();
		}

		public static T GetCustomAttribute<T>(this Type type)
		{
			return (T)type.GetCustomAttributes(typeof(T), inherit: false).FirstOrDefault();
		}

		public static string GetName(this PropertyInfo pi)
		{
			string result = pi.Name;
			XmlElementAttribute customAttribute = pi.GetCustomAttribute<XmlElementAttribute>();
			if (customAttribute != null && !customAttribute.ElementName.IsNullOrEmpty())
			{
				result = customAttribute.ElementName;
			}
			return result;
		}

		public static string DisplayName(this PropertyInfo member)
		{
			DisplayNameAttribute customAttribute = member.GetCustomAttribute<DisplayNameAttribute>();
			if (customAttribute != null && !customAttribute.DisplayName.IsNullOrWhiteSpace())
			{
				return customAttribute.DisplayName;
			}
			return "";
		}

		public static string Description(this PropertyInfo member)
		{
			DescriptionAttribute customAttribute = member.GetCustomAttribute<DescriptionAttribute>();
			if (customAttribute != null && !customAttribute.Description.IsNullOrWhiteSpace())
			{
				return customAttribute.Description;
			}
			return "";
		}

		public static List<PropertyInfo> GetNeedProperties(this Type type)
		{
			PropertyInfo[] properties = type.GetProperties();
			List<PropertyInfo> list = new List<PropertyInfo>();
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				if (propertyInfo.GetCustomAttribute<XmlIgnoreAttribute>() == null && propertyInfo.GetCustomAttribute<ConfigIgnoreAttribute>() == null && propertyInfo.GetCustomAttribute<MapperIgnoreAttribute>() == null && propertyInfo.GetCustomAttribute<IgnoreAttribute>() == null)
				{
					list.Add(propertyInfo);
				}
			}
			return list;
		}
	}
}
