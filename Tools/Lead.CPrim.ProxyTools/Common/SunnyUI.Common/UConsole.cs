using Lead.CPrim.ProxyTools;
using System;

namespace Sunny.UI
{
    public static class UConsole
	{
		public static void WriteConsole(this uint value, string prefix = "")
		{
			Console.WriteLine((prefix.IsValid() ? (prefix + ": ") : "") + value);
		}

		public static void WriteConsole(this int value, string prefix = "")
		{
			Console.WriteLine((prefix.IsValid() ? (prefix + ": ") : "") + value);
		}

		public static void WriteConsole(this float value, string prefix = "")
		{
			Console.WriteLine((prefix.IsValid() ? (prefix + ": ") : "") + value);
		}

		public static void WriteConsole(this char value, string prefix = "")
		{
			Console.WriteLine((prefix.IsValid() ? (prefix + ": ") : "") + value);
		}

		public static void WriteConsole(this decimal value, string prefix = "")
		{
			Console.WriteLine((prefix.IsValid() ? (prefix + ": ") : "") + value);
		}

		public static void WriteConsole(this long value, string prefix = "")
		{
			Console.WriteLine((prefix.IsValid() ? (prefix + ": ") : "") + value);
		}

		public static void WriteConsole(this char[] buffer, int index, int count)
		{
			Console.WriteLine(buffer, index, count);
		}

		public static void WriteConsole(this double value, string prefix = "")
		{
			Console.WriteLine((prefix.IsValid() ? (prefix + ": ") : "") + value);
		}

		public static void WriteConsole(this string format, object arg0, object arg1, object arg2, object arg3)
		{
			Console.WriteLine(format, arg0, arg1, arg2, arg3);
		}

		public static void WriteConsole(this string value, string prefix = "")
		{
			Console.WriteLine((prefix.IsValid() ? (prefix + ": ") : "") + value);
		}

		public static void WriteConsole(this string format, object arg0)
		{
			Console.WriteLine(format, arg0);
		}

		public static void WriteConsole(this string format, object arg0, object arg1)
		{
			Console.WriteLine(format, arg0, arg1);
		}

		public static void WriteConsole(this string format, object arg0, object arg1, object arg2)
		{
			Console.WriteLine(format, arg0, arg1, arg2);
		}

		public static void WriteConsole(this string format, params object[] arg)
		{
			Console.WriteLine(format, arg);
		}

		public static void WriteConsole(this bool value, string prefix = "")
		{
			Console.WriteLine((prefix.IsValid() ? (prefix + ": ") : "") + value);
		}

		public static void WriteConsole(this object value, string prefix = "")
		{
			Console.WriteLine((prefix.IsValid() ? (prefix + ": ") : "") + value);
		}

		public static void WriteConsole(this char[] buffer, string prefix = "")
		{
			Console.WriteLine((prefix.IsValid() ? (prefix + ": ") : "") + buffer);
		}

		public static void WriteConsole(this Exception exception, string prefix = "")
		{
			Console.WriteLine((prefix.IsValid() ? (prefix + ": ") : "") + exception.Message);
		}
	}
}
