using Lead.CPrim.ProxyTools;
using System;
using System.Reflection;

namespace Sunny.UI
{
    public static class EnumEx
	{
		public static string DisplayText(this Enum value)
		{
			FieldInfo field = value.GetType().GetField(value.ToString());
			DisplayTextAttribute customAttribute = field.GetCustomAttribute<DisplayTextAttribute>();
			return (customAttribute != null) ? customAttribute.DisplayText : value.ToString();
		}

		public static TEnum ToEnum<TEnum>(this string dataToMatch, bool ignoreCase = true) where TEnum : struct
		{
			return dataToMatch.InEnum<TEnum>()() ? default(TEnum) : ((TEnum)Enum.Parse(typeof(TEnum), dataToMatch, ignoreCase));
		}

		public static Func<bool> InEnum<TEnum>(this string dataToCheck) where TEnum : struct
		{
			return () => string.IsNullOrEmpty(dataToCheck) || !Enum.IsDefined(typeof(TEnum), dataToCheck);
		}
	}
}
