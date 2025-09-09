using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Lead.CPrim.FaiHelper
{
	public class Core
	{
		public static Dictionary<string, double> DicsToAll(Dictionary<object, object>[] dicsFai)
		{
			Dictionary<string, double> allDicFai = new Dictionary<string, double>();
			foreach (Dictionary<object, object> t in dicsFai)
			{
				foreach (KeyValuePair<object, object> dicFai2 in t.Where((KeyValuePair<object, object> dicFai) => !allDicFai.ContainsKey((string)dicFai.Key)))
				{
					if (double.TryParse(dicFai2.Value.ToString(), out var dValue))
					{
						allDicFai.Add(dicFai2.Key.ToString(), dValue);
					}
					else
					{
						allDicFai.Add(dicFai2.Key.ToString(), 0.0);
					}
				}
			}
			return allDicFai;
		}

		public static Dictionary<string, double> DicsToAll(Dictionary<string, double>[] dicsFai)
		{
			Dictionary<string, double> allDicFai = new Dictionary<string, double>();
			foreach (Dictionary<string, double> t in dicsFai)
			{
				foreach (KeyValuePair<string, double> dicFai2 in t.Where((KeyValuePair<string, double> dicFai) => !allDicFai.ContainsKey(dicFai.Key)))
				{
					allDicFai.Add(dicFai2.Key, dicFai2.Value);
				}
			}
			return allDicFai;
		}

		public static Dictionary<object, object> DicsToAll2(Dictionary<string, double>[] dicsFai)
		{
			Dictionary<object, object> allDicFai = new Dictionary<object, object>();
			foreach (Dictionary<string, double> t in dicsFai)
			{
				foreach (KeyValuePair<string, double> dicFai2 in t.Where((KeyValuePair<string, double> dicFai) => !allDicFai.ContainsKey(dicFai.Key)))
				{
					allDicFai.Add(dicFai2.Key, dicFai2.Value);
				}
			}
			return allDicFai;
		}

		public static Dictionary<object, object> DicsToAll2(Dictionary<object, object>[] dicsFai)
		{
			Dictionary<object, object> allDicFai = new Dictionary<object, object>();
			foreach (Dictionary<object, object> t in dicsFai)
			{
				foreach (KeyValuePair<object, object> dicFai2 in t.Where((KeyValuePair<object, object> dicFai) => !allDicFai.ContainsKey(dicFai.Key)))
				{
					allDicFai.Add(dicFai2.Key, dicFai2.Value);
				}
			}
			return allDicFai;
		}

		/// <summary>
		/// double比较大小
		/// </summary>
		/// <param name="value1"></param>
		/// <param name="value2"></param>
		/// <returns></returns>
		public static bool DoubleEquals(double value1, double value2)
		{
			double DOUBLE_DELTA = 1E-06;
			return value1 == value2 || Math.Abs(value1 - value2) < DOUBLE_DELTA;
		}

		/// <summary>  
		/// 获取枚举描述
		/// </summary>  
		/// <param name="en">枚举</param>  
		/// <returns>返回枚举的描述 </returns>  
		public static string GetDescription(Enum en)
		{
			Type type = en.GetType();
			MemberInfo[] memberInfos = type.GetMember(en.ToString());
			if (memberInfos != null && memberInfos.Length != 0)
			{
				DescriptionAttribute[] attrs = memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute), inherit: false) as DescriptionAttribute[];
				if (attrs != null && attrs.Length != 0)
				{
					return attrs[0].Description;
				}
			}
			return en.ToString();
		}
	}
}
