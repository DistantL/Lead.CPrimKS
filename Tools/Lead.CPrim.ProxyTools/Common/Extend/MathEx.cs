/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: MathEx.cs
 * Author: Victor
 * Description: Math扩展类
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.1010><Victor><20221010>
 * 1、int、long扩展方法整理
 * 
 * <3.3.23.0101><Victor><20230109>
 * 命名空间由Lead.CPrim.ProxyTools.Common变更为Lead.CPrim.ProxyTools
******************************************************************************/


using Lead.CPrim.ProxyTools;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lead.CPrim.ProxyTools
{
    public static class MathEx
    {
        public enum Characters
        {
            [DisplayText("01")]
            BINARY,
            [DisplayText("0123")]
            QUATERNARY,
            [DisplayText("012345")]
            SEPTENARY,
            [DisplayText("01234567")]
            OCTAL,
            [DisplayText("0123456789")]
            DECIMAL,
            [DisplayText("0123456789MN")]
            DUODECIMAL,
            [DisplayText("0123456789ABCDEF")]
            HEX,
            [DisplayText("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
            Custom
        }

        public const string CHARS_BINARY = "01";

        public const string CHARS_QUATERNARY = "0123";

        public const string CHARS_SEPTENARY = "012345";

        public const string CHARS_OCTAL = "01234567";

        public const string CHARS_DECIMAL = "0123456789";

        public const string CHARS_DUODECIMAL = "0123456789MN";

        public const string CHARS_HEX = "0123456789ABCDEF";

        public const string CHARS_PUREUPPERCHAR = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public const string CHARS_PURECHAR = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public const string CHARS_36 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public const string CHARS_62 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";

        public static int BinarySearchNearIndex<T>(this IList<T> list, T target) where T : IComparable
        {
            if (list.Count == 0)
            {
                return -1;
            }

            int num = 0;
            int num2 = list.Count - 1;
            if (target.CompareTo(list[0]) == -1)
            {
                return 0;
            }

            if (target.CompareTo(list[num2]) == 1)
            {
                return list.Count - 1;
            }

            while (num <= num2)
            {
                int num3 = (num + num2) / 2;
                if (target.CompareTo(list[num3]) == 1)
                {
                    num = num3 + 1;
                }

                if (target.CompareTo(list[num3]) == -1)
                {
                    num2 = num3 - 1;
                }

                if (target.CompareTo(list[num3]) == 0)
                {
                    return num3;
                }
            }

            if (num - 1 < 0)
            {
                return num;
            }

            switch (Type.GetTypeCode(target.GetType()))
            {
                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    return target.ToString().ToLong(0L) - list[num - 1].ToString().ToLong(0L) > list[num].ToString().ToLong(0L) - target.ToString().ToLong(0L) ? num : num - 1;
                case TypeCode.Byte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return target.ToString().ToULong(0uL) - list[num - 1].ToString().ToULong(0uL) > list[num].ToString().ToULong(0uL) - target.ToString().ToULong(0uL) ? num : num - 1;
                case TypeCode.Single:
                case TypeCode.Double:
                    return target.ToString().ToDouble() - list[num - 1].ToString().ToDouble() > list[num].ToString().ToDouble() - target.ToString().ToDouble() ? num : num - 1;
                case TypeCode.Decimal:
                    return target.ToString().ToDecimal() - list[num - 1].ToString().ToDecimal() > list[num].ToString().ToDecimal() - target.ToString().ToDecimal() ? num : num - 1;
                case TypeCode.DateTime:
                    return target.ToString().ToDateTime() - list[num - 1].ToString().ToDateTime() > list[num].ToString().ToDateTime() - target.ToString().ToDateTime() ? num : num - 1;
                default:
                    return num - 1;
            }
        }

        public static int BinarySearchNearIndex<T>(this T[] list, T target) where T : IComparable
        {
            return list.ToList().BinarySearchNearIndex(target);
        }

        public static int BinarySearchNearIndex<T>(this IList<T> list, T target, int count) where T : IComparable
        {
            if (list.Count == 0)
            {
                return -1;
            }

            if (count == 0)
            {
                return -1;
            }

            if (count > list.Count)
            {
                count = list.Count;
            }

            int num = 0;
            int num2 = count - 1;
            if (target.CompareTo(list[0]) == -1)
            {
                return 0;
            }

            if (target.CompareTo(list[num2]) == 1)
            {
                return count - 1;
            }

            while (num <= num2)
            {
                int num3 = (num + num2) / 2;
                if (target.CompareTo(list[num3]) == 1)
                {
                    num = num3 + 1;
                }

                if (target.CompareTo(list[num3]) == -1)
                {
                    num2 = num3 - 1;
                }

                if (target.CompareTo(list[num3]) == 0)
                {
                    return num3;
                }
            }

            if (num - 1 < 0)
            {
                return num;
            }

            switch (Type.GetTypeCode(target.GetType()))
            {
                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    return target.ToString().ToLong(0L) - list[num - 1].ToString().ToLong(0L) > list[num].ToString().ToLong(0L) - target.ToString().ToLong(0L) ? num : num - 1;
                case TypeCode.Byte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return target.ToString().ToULong(0uL) - list[num - 1].ToString().ToULong(0uL) > list[num].ToString().ToULong(0uL) - target.ToString().ToULong(0uL) ? num : num - 1;
                case TypeCode.Single:
                case TypeCode.Double:
                    return target.ToString().ToDouble() - list[num - 1].ToString().ToDouble() > list[num].ToString().ToDouble() - target.ToString().ToDouble() ? num : num - 1;
                case TypeCode.Decimal:
                    return target.ToString().ToDecimal() - list[num - 1].ToString().ToDecimal() > list[num].ToString().ToDecimal() - target.ToString().ToDecimal() ? num : num - 1;
                case TypeCode.DateTime:
                    return target.ToString().ToDateTime() - list[num - 1].ToString().ToDateTime() > list[num].ToString().ToDateTime() - target.ToString().ToDateTime() ? num : num - 1;
                default:
                    return num - 1;
            }
        }

        public static int BinarySearchNearIndex<T>(this T[] list, T target, int count) where T : IComparable
        {
            return list.ToList().BinarySearchNearIndex(target, count);
        }

        public static int HexToInt(this string str)
        {
            return Convert.ToInt32(str, 16);
        }

        public static int BinToInt(this string str)
        {
            return Convert.ToInt32(str, 2);
        }

        public static int RoundEx(this double value)
        {
            return (int)(value + 0.5);
        }

        public static int RoundEx(this float value)
        {
            return (int)(value + 0.5f);
        }

        public static bool EqualsFloat(this float valueA, float valueB, float eps = 1E-08f)
        {
            return Math.Abs(valueA - valueB) < eps;
        }

        public static bool EqualsDouble(this double valueA, double valueB, float eps = 1E-08f)
        {
            return Math.Abs(valueA - valueB) < eps;
        }

        public static double Rad(this double d)
        {
            return d * Math.PI / 180.0;
        }

        public static double Deg(this double rad)
        {
            return rad * 180.0 / Math.PI;
        }

        public static double Rad(this float d)
        {
            return d * Math.PI / 180.0;
        }

        public static double Deg(this float rad)
        {
            return rad * 180.0 / Math.PI;
        }

        public static bool IsZero(this double value)
        {
            return value >= -4.94065645841247E-324 && value <= double.Epsilon;
        }

        public static bool IsZero(this float value)
        {
            return value >= -1.401298E-45f && value <= float.Epsilon;
        }

        public static bool InRange<T>(this T value, T minValue, T maxValue) where T : IComparable
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (minValue.CompareTo(maxValue) == 1)
            {
                T val = minValue;
                minValue = maxValue;
                maxValue = val;
            }

            return value.CompareTo(minValue) >= 0 && value.CompareTo(maxValue) <= 0;
        }

        public static bool IsBetween<T>(this T t, T lowerBound, T upperBound, bool includeLowerBound = false, bool includeUpperBound = false) where T : IComparable<T>
        {
            if (t == null)
            {
                throw new ArgumentNullException("t");
            }

            int num = t.CompareTo(lowerBound);
            int num2 = t.CompareTo(upperBound);
            return includeLowerBound && num == 0 || includeUpperBound && num2 == 0 || num > 0 && num2 < 0;
        }

        public static bool In<T>(this T t, params T[] c)
        {
            return c.Any((i) => i.Equals(t));
        }

        public static T InRange<T>(this T value, T minValue, T maxValue, T defaultValue) where T : IComparable
        {
            return value.InRange(minValue, maxValue) ? value : defaultValue;
        }

        public static T CheckInRange<T>(this T value, T lowerLimit, T upperLimit) where T : IComparable
        {
            if (lowerLimit.CompareTo(upperLimit) == 1)
            {
                T val = lowerLimit;
                lowerLimit = upperLimit;
                upperLimit = val;
            }

            if (value.CompareTo(lowerLimit) == -1)
            {
                value = lowerLimit;
            }

            if (value.CompareTo(upperLimit) == 1)
            {
                value = upperLimit;
            }

            return value;
        }

        public static T CheckLowerLimit<T>(this T value, T lowerLimit) where T : IComparable
        {
            return value.CompareTo(lowerLimit) == -1 ? lowerLimit : value;
        }

        public static T CheckUpperLimit<T>(this T value, T upperLimit) where T : IComparable
        {
            return value.CompareTo(upperLimit) == 1 ? upperLimit : value;
        }



        //*****************************************************************************
        #region int扩展方法
        /// <summary>除法</summary>
        /// <param name="value">被除数</param>
        /// <param name="divParam">除数</param>
        /// <returns>商（int）</returns>
        public static int Div(this int value, int divParam)
        {
            return value / divParam;
        }
        /// <summary>求余</summary>
        /// <param name="value">int</param>
        /// <param name="divParam"></param>
        /// <returns>余数</returns>
        public static int Mod(this int value, int divParam)
        {
            return value % divParam;
        }
        /// <summary>偶数判断</summary>
        /// <param name="value">int</param>
        /// <returns>true：偶数；false：不是偶数</returns>
        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }
        /// <summary>奇数判断</summary>
        /// <param name="value">int</param>
        /// <returns>true：奇数；false：不是奇数</returns>
        public static bool IsOdd(this int value)
        {
            return value % 2 != 0;
        }
        /// <summary>转化为bool</summary>
        /// <param name="value">int</param>
        /// <param name="Default">默认值（false）</param>
        /// <returns>bool</returns>
        public static bool ToBool(this int value, bool Default = false)
        {
            switch (value)
            {
                case 1:
                    return true;
                case 0:
                    return false;
                default:
                    return Default;
            }
        }
        /// <summary>转化为十六进制</summary>
        /// <param name="value">int</param>
        /// <param name="length">显示长度（如果显示长度小于实际长度，以实际长度显示）</param>
        /// <returns>十六进制</returns>
        public static string ToHex(this int value, int length = 0)
        {
            string text = Convert.ToString(value, 16).ToUpper();
            text = text.Length.Mod(2) == 0 ? text : "0" + text;
            if (length == 0)
            {
                return text;
            }

            if (text.Length >= length)
            {
                return text;
            }

            return text.PadLeft(length, '0');
        }
        /// <summary>转化为二进制字符串</summary>
        /// <param name="value">int</param>
        /// <param name="length">显示长度（如果显示长度小于实际长度，以实际长度显示）</param>
        /// <returns>二进制</returns>
        public static string ToBin(this int value, int length = 0)
        {
            string text = Convert.ToString(value, 2);
            if (length <= 0)
            {
                return text;
            }

            if (text.Length >= length)
            {
                return text;
            }

            return text.PadLeft(length, '0');
        }
        #endregion



        //*****************************************************************************
        #region long扩展方法
        /// <summary>偶数判断</summary>
        /// <param name="value">int</param>
        /// <returns>true：偶数；false：不是偶数</returns>
        public static bool IsEven(this long value)
        {
            return value % 2 == 0;
        }
        /// <summary>奇数判断</summary>
        /// <param name="value">int</param>
        /// <returns>true：奇数；false：不是奇数</returns>
        public static bool IsOdd(this long value)
        {
            return value % 2 != 0;
        }
        #endregion



        public static string ToYesNoString(this bool boolean)
        {
            return boolean ? "Yes" : "No";
        }

        public static string ToTrueFalseString(this bool boolean)
        {
            return boolean ? "True" : "False";
        }

        public static int ToInt(this bool boolean)
        {
            return boolean ? 1 : 0;
        }

        public static byte ToByte(this bool boolean)
        {
            return (byte)boolean.ToInt();
        }

        public static bool ToBool(this byte value, bool Default = false)
        {
            switch (value)
            {
                case 1:
                    return true;
                case 0:
                    return false;
                default:
                    return Default;
            }
        }

        public static string Base10ToBase26(string s)
        {
            char[] array = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            decimal num = Convert.ToDecimal(s);
            int num2 = 0;
            char[] array2 = new char[s.ToString().Length + 1];
            int num3 = 0;
            while (num >= 26m)
            {
                num2 = Convert.ToInt32(num % 26m);
                array2[num3] = array[num2];
                num = (num - num2) / 26m;
                num3++;
            }

            array2[num3] = array[Convert.ToInt32(num)];
            string text = "";
            for (int num4 = num3; num4 >= 0; num4--)
            {
                text += array2[num4];
            }

            return text;
        }

        //public static string Base26ToBase10(string s)
        //{
        //    string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        //    BigInteger bigInteger = default(BigInteger);
        //    for (int i = 0; i <= s.Length - 1; i++)
        //    {
        //        BigInteger right = powof(26, s.Length - i - 1);
        //        bigInteger += text.IndexOf(s.Substring(i, 1)) * right;
        //    }

        //    return bigInteger.ToString();
        //}

        //private static BigInteger powof(int x, int y)
        //{
        //    BigInteger result = 1;
        //    switch (y)
        //    {
        //        case 0:
        //            return 1;
        //        case 1:
        //            return x;
        //        default:
        //            {
        //                for (int i = 0; i <= y - 1; i++)
        //                {
        //                    result *= (BigInteger)x;
        //                }

        //                return result;
        //            }
        //    }
        //}

        public static string ToNumberString(this ulong number, Characters characters = Characters.DECIMAL, string customCharacter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
        {
            string text = characters.DisplayText();
            if (characters == Characters.Custom && !customCharacter.IsNullOrEmpty())
            {
                text = customCharacter;
            }

            List<string> list = new List<string>();
            ulong num = number;
            if (num == 0)
            {
                return text[0].ToString();
            }

            while (num != 0)
            {
                ulong value = num % (ulong)text.Length;
                num /= (ulong)text.Length;
                string item = text[Convert.ToInt32(value)].ToString();
                list.Insert(0, item);
            }

            return string.Join("", list.ToArray());
        }

        public static string ToNumberString(this uint number, Characters characters = Characters.DECIMAL, string customCharacter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
        {
            return ((ulong)number).ToNumberString(characters, customCharacter);
        }

        public static string ToNumberString(this ushort number, Characters characters = Characters.DECIMAL, string customCharacter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
        {
            return ((ulong)number).ToNumberString(characters, customCharacter);
        }

        public static string ToNumberString(this byte number, Characters characters = Characters.DECIMAL, string customCharacter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
        {
            return ((ulong)number).ToNumberString(characters, customCharacter);
        }

        public static long ToNumberLong(this string str, Characters characters = Characters.DECIMAL, string customCharacter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
        {
            string text = characters.DisplayText();
            if (characters == Characters.Custom && !customCharacter.IsNullOrEmpty())
            {
                text = customCharacter;
            }

            long num = 0L;
            int num2 = 0;
            string text2 = new string(str.ToCharArray().Reverse().ToArray());
            foreach (char value in text2)
            {
                if (text.Contains(value))
                {
                    num += text.IndexOf(value) * (long)Math.Pow(text.Length, num2);
                    num2++;
                }
            }

            return num;
        }

        public static string ToRMBString(this decimal num)
        {
            string text = "万仟佰拾亿仟佰拾万仟佰拾元角分";
            string text2 = "";
            string str = "";
            int num2 = 0;
            num = Math.Round(Math.Abs(num), 2);
            string text3 = ((long)(num * 100m)).ToString();
            int length = text3.Length;
            if (length > 15)
            {
                return "溢出";
            }

            text = text.Substring(15 - length);
            for (int i = 0; i < length; i++)
            {
                string text4 = text3.Substring(i, 1);
                int startIndex = Convert.ToInt32(text4);
                string str2;
                if (i != length - 3 && i != length - 7 && i != length - 11 && i != length - 15)
                {
                    if (text4 == "0")
                    {
                        str2 = "";
                        str = "";
                        num2++;
                    }
                    else if (text4 != "0" && num2 != 0)
                    {
                        str2 = "零" + "零壹贰叁肆伍陆柒捌玖".Substring(startIndex, 1);
                        str = text.Substring(i, 1);
                        num2 = 0;
                    }
                    else
                    {
                        str2 = "零壹贰叁肆伍陆柒捌玖".Substring(startIndex, 1);
                        str = text.Substring(i, 1);
                        num2 = 0;
                    }
                }
                else if (text4 != "0" && num2 != 0)
                {
                    str2 = "零" + "零壹贰叁肆伍陆柒捌玖".Substring(startIndex, 1);
                    str = text.Substring(i, 1);
                    num2 = 0;
                }
                else if (text4 != "0" && num2 == 0)
                {
                    str2 = "零壹贰叁肆伍陆柒捌玖".Substring(startIndex, 1);
                    str = text.Substring(i, 1);
                    num2 = 0;
                }
                else if (text4 == "0" && num2 >= 3)
                {
                    str2 = "";
                    str = "";
                    num2++;
                }
                else if (length >= 11)
                {
                    str2 = "";
                    num2++;
                }
                else
                {
                    str2 = "";
                    str = text.Substring(i, 1);
                    num2++;
                }

                if (i == length - 11 || i == length - 3)
                {
                    str = text.Substring(i, 1);
                }

                text2 = text2 + str2 + str;
                if (i == length - 1 && text4 == "0")
                {
                    text2 += "整";
                }
            }

            if (num == 0m)
            {
                text2 = "零元整";
            }

            return text2;
        }

        public static bool GetBit(this byte b, int index)
        {
            return (b & 1 << index) > 0;
        }

        public static byte SetBit(this byte b, int index)
        {
            b = (byte)(b | (byte)(1 << index));
            return b;
        }

        public static byte ClearBit(this byte b, int index)
        {
            b = (byte)(b & (byte)(255 - (1 << index)));
            return b;
        }

        public static byte ReverseBit(this byte b, int index)
        {
            b = (byte)(b ^ (byte)(1 << index));
            return b;
        }
    }
}
