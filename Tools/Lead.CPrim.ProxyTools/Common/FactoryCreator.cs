/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: FactoryCreator.cs
 * Author: Victor
 * Description: 反射管理类
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 *
 * 3.3.22.0728 -> 
 * <Author> (Victor)    <Time> (20220805)
 * 1、将获取属性的值GetModelValue/设置属性的值SetModelValue变更为扩展方法
******************************************************************************/

using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Reflection;

namespace Lead.CPrim.ProxyTools
{
	/// <summary>反射管理类</summary>
	public static class FactoryCreator
	{
		/// <summary>
		/// 反射创建类的对象<br/>
		/// 需要捕捉异常
		/// </summary>
		/// <param name="dllPath">dll全路径</param>
		/// <param name="className">接口名称</param>
		/// <returns>T</returns>
		public static T GetFactoryClass<T>(string dllPath, string className)
		{
			T factory = default(T);
			if (!string.IsNullOrEmpty(dllPath) && !string.IsNullOrEmpty(className))
			{
				try
				{
					Assembly assembly = Assembly.LoadFrom(dllPath);
					Type[] array = assembly.GetExportedTypes();
					foreach (Type type in array)
					{
						if (type.IsClass && null != type.GetInterface(className))
						{
							return (T)Activator.CreateInstance(type);
						}
					}
				}
				catch(Exception ex)
				{
					throw ex;
				}
			}
			return factory;
		}
		/// <summary>判断类中属性是否存在</summary>
		/// <typeparam name="T">类型</typeparam>
		/// <param name="fieldName">属性名</param>
		/// <returns>存在:true;不存在:false;</returns>
		public static bool PropertyExist<T>(string fieldName) where T:class
		{
			try
			{
				Type ts = typeof(T);
				PropertyInfo o = ts.GetProperty(fieldName);
				return o != null;
			}
			catch
			{
				return false;
			}
		}
		/// <summary>获取属性的值</summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="obj">具体类</param>
		/// <param name="fieldName">属性名称</param>
		/// <returns>string</returns>
		public static string GetModelValue<T>(this T obj, string fieldName) where T:class
		{
			try
			{
				Type ts = obj.GetType();
				object o = ts.GetProperty(fieldName)?.GetValue(obj, null);
				string value = Convert.ToString(o);
				return string.IsNullOrEmpty(value) ? "" : value;
			}
			catch
			{
				return null;
			}
		}
		/// <summary>设置属性的值</summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="obj">具体类</param>
		/// <param name="fieldName">属性</param>
		/// <param name="value">值</param>
		/// <returns>存在:成功;不存在:失败;</returns>
		public static bool SetModelValue<T>(this T obj, string fieldName, string value) where T : class
		{
			try
			{
				Type ts = obj.GetType();
				object v = Convert.ChangeType(value, ts.GetProperty(fieldName)?.PropertyType ?? throw new InvalidOperationException());
				ts.GetProperty(fieldName)?.SetValue(obj, v, null);
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
