using Lead.CPrim.ProxyTools;
using System;
using System.Drawing;

namespace Sunny.UI
{
    public static class ConvertEx
	{
		public static bool CanConvent(Type type)
		{
			bool result = false;
			switch (Type.GetTypeCode(type))
			{
			case TypeCode.Boolean:
			case TypeCode.Char:
			case TypeCode.SByte:
			case TypeCode.Byte:
			case TypeCode.Int16:
			case TypeCode.UInt16:
			case TypeCode.Int32:
			case TypeCode.UInt32:
			case TypeCode.Int64:
			case TypeCode.UInt64:
			case TypeCode.Single:
			case TypeCode.Double:
			case TypeCode.Decimal:
			case TypeCode.DateTime:
			case TypeCode.String:
				result = true;
				break;
			case TypeCode.Object:
				if (type == typeof(Point) || type == typeof(PointF) || type == typeof(Color) || type == typeof(Size) || type == typeof(SizeF))
				{
					result = true;
				}
				break;
			}
			return result;
		}

		public static object StringToObject(string str, Type type, object defaultobj)
		{
			object result = defaultobj;
			if (type == typeof(string))
			{
				return str;
			}
			if (str.IsNullOrEmpty())
			{
				return defaultobj;
			}
			switch (Type.GetTypeCode(type))
			{
			case TypeCode.Char:
				result = str.ToChar((char)defaultobj);
				break;
			case TypeCode.SByte:
				result = str.ToSByte((sbyte)defaultobj);
				break;
			case TypeCode.Byte:
				result = str.ToByte((byte)defaultobj);
				break;
			case TypeCode.Int16:
				result = str.ToShort((short)defaultobj);
				break;
			case TypeCode.UInt16:
				result = str.ToUShort((ushort)defaultobj);
				break;
			case TypeCode.Int32:
				result = str.ToInt((int)defaultobj);
				break;
			case TypeCode.UInt32:
				result = str.ToUInt((uint)defaultobj);
				break;
			case TypeCode.Int64:
				result = str.ToLong((long)defaultobj);
				break;
			case TypeCode.UInt64:
				result = str.ToULong((ulong)defaultobj);
				break;
			case TypeCode.Single:
				result = str.ToFloat((float)defaultobj);
				break;
			case TypeCode.Double:
				result = str.ToDouble((double)defaultobj);
				break;
			case TypeCode.Decimal:
				result = str.ToDecimal((decimal)defaultobj);
				break;
			case TypeCode.Boolean:
				if (str.ToUpper().Equals(bool.TrueString.ToUpper()))
				{
					result = true;
				}
				if (str.ToUpper().Equals(bool.FalseString.ToUpper()))
				{
					result = false;
				}
				break;
			case TypeCode.DateTime:
				try
				{
					DateTime dateTime = str.ToDateTime("yyyy-MM-dd HH:mm:ss");
					result = dateTime;
				}
				catch (Exception value)
				{
					Console.WriteLine(value);
				}
				break;
			case TypeCode.Object:
				result = StringToObjectEx(str, type, defaultobj);
				break;
			default:
				throw new ApplicationException("不支持此类型: " + type.FullName);
			}
			if (type == typeof(DateTime))
			{
			}
			return result;
		}

		private static object StringToObjectEx(string str, Type type, object defaultobj)
		{
			object result = defaultobj;
			if (type == typeof(Point))
			{
				string[] array = str.ToUpper().Replace("X:", "").Replace("Y:", "")
					.Trim()
					.Split(";");
				if (array.Length == 2 && int.TryParse(array[0], out var result2) && int.TryParse(array[1], out var result3))
				{
					result = new Point(result2, result3);
				}
			}
			else if (type == typeof(PointF))
			{
				string[] array2 = str.ToUpper().Replace("X:", "").Replace("Y:", "")
					.Trim()
					.Split(";");
				if (array2.Length == 2 && float.TryParse(array2[0], out var result4) && float.TryParse(array2[1], out var result5))
				{
					result = new PointF(result4, result5);
				}
			}
			else if (type == typeof(Color))
			{
				string[] array3 = str.ToUpper().Replace("A:", "").Replace("R:", "")
					.Replace("G:", "")
					.Replace("B:", "")
					.Trim()
					.Split(";");
				if (array3.Length == 4 && int.TryParse(array3[0], out var result6) && int.TryParse(array3[1], out var result7) && int.TryParse(array3[2], out var result8) && int.TryParse(array3[3], out var result9) && result6.InRange(0, 255) && result7.InRange(0, 255) && result8.InRange(0, 255) && result9.InRange(0, 255))
				{
					result = Color.FromArgb(result6, result7, result8, result9);
				}
			}
			else if (type == typeof(Size))
			{
				string[] array4 = str.ToUpper().Replace("W:", "").Replace("H:", "")
					.Trim()
					.Split(";");
				if (array4.Length == 2 && int.TryParse(array4[0], out var result10) && int.TryParse(array4[1], out var result11))
				{
					result = new Size(result10, result11);
				}
			}
			else
			{
				if (!(type == typeof(SizeF)))
				{
					throw new ApplicationException("不支持此类型: " + type.FullName);
				}
				string[] array5 = str.ToUpper().Replace("W:", "").Replace("H:", "")
					.Trim()
					.Split(";");
				if (array5.Length == 2 && float.TryParse(array5[0], out var result12) && float.TryParse(array5[1], out var result13))
				{
					result = new SizeF(result12, result13);
				}
			}
			return result;
		}

		public static string ObjectToString(object obj, Type type)
		{
			switch (Type.GetTypeCode(type))
			{
			case TypeCode.String:
				if (obj == null)
				{
					obj = "";
				}
				return obj.ToString();
			case TypeCode.Char:
			case TypeCode.SByte:
			case TypeCode.Byte:
			case TypeCode.Int16:
			case TypeCode.UInt16:
			case TypeCode.Int32:
			case TypeCode.UInt32:
			case TypeCode.Int64:
			case TypeCode.UInt64:
			case TypeCode.Single:
			case TypeCode.Double:
			case TypeCode.Decimal:
				return obj.ToString();
			case TypeCode.Boolean:
				return ((bool)obj) ? bool.TrueString : bool.FalseString;
			case TypeCode.DateTime:
				return ((DateTime)obj).ToString("yyyy-MM-dd HH:mm:ss");
			case TypeCode.Object:
				return ObjectToStringEx(obj, type);
			default:
				throw new ApplicationException("不支持此类型: " + type.FullName);
			}
		}

		private static string ObjectToStringEx(object obj, Type type)
		{
			if (type == typeof(Point))
			{
				Point point = (Point)obj;
				return "X:" + point.X + "; Y:" + point.Y;
			}
			if (type == typeof(PointF))
			{
				PointF pointF = (PointF)obj;
				return "X:" + pointF.X + "; Y:" + pointF.Y;
			}
			if (type == typeof(Color))
			{
				Color color = (Color)obj;
				return "A:" + color.A + "; R:" + color.R + "; G:" + color.G + "; B:" + color.B;
			}
			if (type == typeof(Size))
			{
				Size size = (Size)obj;
				return "W:" + size.Width + "; H:" + size.Height;
			}
			if (type == typeof(SizeF))
			{
				SizeF sizeF = (SizeF)obj;
				return "W:" + sizeF.Width + "; H:" + sizeF.Height;
			}
			throw new ApplicationException("不支持此类型: " + type.FullName);
		}
	}
}
