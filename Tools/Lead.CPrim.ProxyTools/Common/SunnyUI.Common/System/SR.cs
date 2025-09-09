using System.Globalization;
using System.Resources;
using System.Threading;

namespace System
{
	internal sealed class SR
	{
		internal const string Argument_InvalidNumberStyles = "Argument_InvalidNumberStyles";

		internal const string Argument_InvalidHexStyle = "Argument_InvalidHexStyle";

		internal const string Argument_MustBeBigInt = "Argument_MustBeBigInt";

		internal const string Format_InvalidFormatSpecifier = "Format_InvalidFormatSpecifier";

		internal const string Format_TooLarge = "Format_TooLarge";

		internal const string ArgumentOutOfRange_MustBeNonNeg = "ArgumentOutOfRange_MustBeNonNeg";

		internal const string Overflow_BigIntInfinity = "Overflow_BigIntInfinity";

		internal const string Overflow_NotANumber = "Overflow_NotANumber";

		internal const string Overflow_ParseBigInteger = "Overflow_ParseBigInteger";

		internal const string Overflow_Int32 = "Overflow_Int32";

		internal const string Overflow_Int64 = "Overflow_Int64";

		internal const string Overflow_UInt32 = "Overflow_UInt32";

		internal const string Overflow_UInt64 = "Overflow_UInt64";

		internal const string Overflow_Decimal = "Overflow_Decimal";

		internal const string Arg_ArgumentOutOfRangeException = "Arg_ArgumentOutOfRangeException";

		internal const string Arg_ElementsInSourceIsGreaterThanDestination = "Arg_ElementsInSourceIsGreaterThanDestination";

		internal const string Arg_MultiDimArrayNotSupported = "Arg_MultiDimArrayNotSupported";

		internal const string Arg_RegisterLengthOfRangeException = "Arg_RegisterLengthOfRangeException";

		internal const string Arg_NullArgumentNullRef = "Arg_NullArgumentNullRef";

		private static SR loader;

		private ResourceManager resources;

		private static CultureInfo Culture => null;

		public static ResourceManager Resources => GetLoader().resources;

		internal SR()
		{
			resources = new ResourceManager("System.Numerics", GetType().Assembly);
		}

		private static SR GetLoader()
		{
			if (loader == null)
			{
				SR value = new SR();
				Interlocked.CompareExchange(ref loader, value, null);
			}
			return loader;
		}

		public static string GetString(string name, params object[] args)
		{
			SR sR = GetLoader();
			if (sR == null)
			{
				return null;
			}
			string @string = sR.resources.GetString(name, Culture);
			if (args != null && args.Length != 0)
			{
				for (int i = 0; i < args.Length; i++)
				{
					string text = args[i] as string;
					if (text != null && text.Length > 1024)
					{
						args[i] = text.Substring(0, 1021) + "...";
					}
				}
				return string.Format(CultureInfo.CurrentCulture, @string, args);
			}
			return @string;
		}

		public static string GetString(string name)
		{
			return GetLoader()?.resources.GetString(name, Culture);
		}

		public static string GetString(string name, out bool usedFallback)
		{
			usedFallback = false;
			return GetString(name);
		}

		public static object GetObject(string name)
		{
			return GetLoader()?.resources.GetObject(name, Culture);
		}
	}
}
