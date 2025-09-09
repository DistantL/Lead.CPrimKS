/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: StringEx.cs
 * Author: Victor
 * Description: string扩展方法
 * CreateTime: 2022-12-13
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.1207><Victor><20221213>
 * 1、初版
******************************************************************************/

using Lead.CPrim.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Lead.CPrim.ProxyTools
{
    public static class StringEx
    {
        #region Field
        /// <summary>密钥</summary>
        public const string DefaultCryptString = "!@#$%^&*";
        public const string StructLayoutString = "[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]";
        #endregion



        #region Method_ExternalUsing
        /// <summary>末尾自动添加Path.DirectorySeparatorChar<br/>
        /// Path.DirectorySeparatorChar 提供平台特定的字符，该字符用于在反映分层文件系统组织的路径字符串中分隔目录级别。</summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static string DealPath(this string dir)
        {
            return dir.IsNullOrEmpty() ? dir : dir[dir.Length - 1] == Path.DirectorySeparatorChar ? dir : dir + Path.DirectorySeparatorChar;
        }
        /// <summary>3 -> 0.0000</summary>
        /// <param name="decimalcount"></param>
        /// <returns></returns>
        public static string FormatString(this int decimalcount)
        {
            if (decimalcount <= 0)
            {
                return "0";
            }
            return "0." + "0".Repet(decimalcount);
        }
        /// <summary>重复count次</summary>
        /// <param name="str"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string Repet(this string str, int count)
        {
            if (count <= 0)
            {
                return string.Empty;
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("");
            for (int i = 0; i < count; i++)
            {
                stringBuilder.Append(str);
            }
            return stringBuilder.ToString();
        }
        /// <summary>字符串在字符串数组中是否有相等的值（忽略大小写）</summary>
        /// <param name="value"></param>
        /// <param name="strs"></param>
        /// <returns>true：字符串在字符串数组中匹配成功；false：字符串在字符串数组中匹配失败；</returns>
        public static bool EqualsIgnoreCase(this string value, params string[] strs)
        {
            foreach (string b in strs)
            {
                if (string.Equals(value, b, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>两个字符串是否是否相等（忽略大小写）</summary>
        /// <param name="value"></param>
        /// <param name="comparestring"></param>
        /// <returns>true：两个字符串相等；false：两个字符串不相等；</returns>
        public static bool EqualsIgnoreCase(this string value, string comparestring)
        {
            return string.Equals(value, comparestring, StringComparison.OrdinalIgnoreCase);
        }
        /// <summary>string转化为bool</summary>
        /// <param name="s"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static bool ToBoolean(this string s, bool def = false)
        {
            return bool.TryParse(s, out var result) ? result : def;
        }
        /// <summary>string转化为char</summary>
        /// <param name="s"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static char ToChar(this string s, char def = '\0')
        {
            return char.TryParse(s, out var result) ? result : def;
        }
        /// <summary>string转化为decimal</summary>
        /// <param name="s"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string s, decimal def = 0m)
        {
            return decimal.TryParse(s, out var result) ? result : def;
        }
        /// <summary>string转化为double</summary>
        /// <param name="s"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static double ToDouble(this string s, double def = 0.0)
        {
            return double.TryParse(s, out var result) ? result : def;
        }
        /// <summary>string转化为float</summary>
        /// <param name="s"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static float ToFloat(this string s, float def = 0f)
        {
            return float.TryParse(s, out var result) ? result : def;
        }
        /// <summary>string转化为byte</summary>
        /// <param name="s"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static byte ToByte(this string s, byte def = 0)
        {
            return byte.TryParse(s, out var result) ? result : def;
        }
        /// <summary>string转化为sbyte</summary>
        /// <param name="s"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static sbyte ToSByte(this string s, sbyte def = 0)
        {
            return sbyte.TryParse(s, out var result) ? result : def;
        }
        /// <summary>string转化为short</summary>
        /// <param name="s"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static short ToShort(this string s, short def = 0)
        {
            return short.TryParse(s, out var result) ? result : def;
        }
        /// <summary>string转化为ushort</summary>
        /// <param name="s"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static ushort ToUShort(this string s, ushort def = 0)
        {
            return ushort.TryParse(s, out var result) ? result : def;
        }
        /// <summary>string转化为int</summary>
        /// <param name="s"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static int ToInt(this string s, int def = 0)
        {
            return int.TryParse(s, out var result) ? result : def;
        }
        /// <summary>string转化为uint</summary>
        /// <param name="s"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static uint ToUInt(this string s, uint def = 0u)
        {
            return uint.TryParse(s, out var result) ? result : def;
        }
        /// <summary>string转化为long</summary>
        /// <param name="s"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static long ToLong(this string s, long def = 0L)
        {
            return long.TryParse(s, out var result) ? result : def;
        }
        /// <summary>string转化为ulong</summary>
        /// <param name="s"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static ulong ToULong(this string s, ulong def = 0uL)
        {
            return ulong.TryParse(s, out var result) ? result : def;
        }
        /// <summary>string转化为DateTime</summary>
        /// <param name="s"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string s, DateTime def = default)
        {
            return DateTime.TryParse(s, out var result) ? result : def;
        }
        /// <summary>string转化为相同格式的DateTime</summary>
        /// <param name="s"></param>
        /// <param name="formatString"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string s, string formatString)
        {
            return DateTime.ParseExact(s, formatString, CultureInfo.InvariantCulture);
        }
        /// <summary>string转化为DateTime</summary>
        /// <param name="s"></param>
        /// <param name="formatString"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static DateTime ToDateTimeEx(this string s, string formatString, DateTime def = default)
        {
            int year = def.Year;
            int month = def.Month;
            int day = def.Day;
            int hour = def.Hour;
            int minute = def.Minute;
            int second = def.Second;
            int millisecond = def.Millisecond;
            if (formatString.Contains("yyyy"))
            {
                year = s.Substring(formatString.IndexOf("yyyy", StringComparison.CurrentCulture), 4).ToInt();
            }
            else if (formatString.Contains("yy"))
            {
                year = 2000 + s.Substring(formatString.IndexOf("yy", StringComparison.CurrentCulture), 2).ToInt();
            }
            if (formatString.Contains("MM"))
            {
                month = s.Substring(formatString.IndexOf("MM", StringComparison.CurrentCulture), 2).ToInt();
            }
            if (formatString.Contains("dd"))
            {
                day = s.Substring(formatString.IndexOf("dd", StringComparison.CurrentCulture), 2).ToInt();
            }
            if (formatString.Contains("HH"))
            {
                hour = s.Substring(formatString.IndexOf("HH", StringComparison.CurrentCulture), 2).ToInt();
            }
            if (formatString.Contains("mm"))
            {
                minute = s.Substring(formatString.IndexOf("mm", StringComparison.CurrentCulture), 2).ToInt();
            }
            if (formatString.Contains("ss"))
            {
                second = s.Substring(formatString.IndexOf("ss", StringComparison.CurrentCulture), 2).ToInt();
            }
            if (formatString.Contains("fff"))
            {
                millisecond = s.Substring(formatString.IndexOf("fff", StringComparison.CurrentCulture), 3).ToInt();
            }
            try
            {
                return new DateTime(year, month, day, hour, minute, second, millisecond);
            }
            catch
            {
                return def;
            }
        }
        /// <summary>string转化为Guid</summary>
        /// <param name="s"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static Guid ToGuid(this string s, Guid def = default)
        {
            return Guid.TryParse(s, out var result) ? result : def;
        }

        /// <summary>string是否可以转化为bool</summary>
        /// <param name="s"></param>
        /// <returns>true：可与转化；false：不饿能进行转化</returns>
        public static bool IsBoolean(this string s)
        {
            return bool.TryParse(s, out var result);
        }
        /// <summary>string是否可以转化为char</summary>
        /// <param name="s"></param>
        /// <returns>true：可与转化；false：不饿能进行转化</returns>
        public static bool IsChar(this string s)
        {
            return char.TryParse(s, out var result);
        }
        /// <summary>string是否可以转化为decimal</summary>
        /// <param name="s"></param>
        /// <returns>true：可与转化；false：不饿能进行转化</returns>
        public static bool IsDecimal(this string s)
        {
            return decimal.TryParse(s, out var result);
        }
        /// <summary>string是否可以转化为double</summary>
        /// <param name="s"></param>
        /// <returns>true：可与转化；false：不饿能进行转化</returns>
        public static bool IsDouble(this string s)
        {
            return double.TryParse(s, out var result);
        }
        /// <summary>string是否可以转化为float</summary>
        /// <param name="s"></param>
        /// <returns>true：可与转化；false：不饿能进行转化</returns>
        public static bool IsFloat(this string s)
        {
            return float.TryParse(s, out var result);
        }
        /// <summary>string是否可以转化为byte</summary>
        /// <param name="s"></param>
        /// <returns>true：可与转化；false：不饿能进行转化</returns>
        public static bool IsByte(this string s)
        {
            return byte.TryParse(s, out var result);
        }
        /// <summary>string是否可以转化为sbyte</summary>
        /// <param name="s"></param>
        /// <returns>true：可与转化；false：不饿能进行转化</returns>
        public static bool IsSByte(this string s)
        {
            return sbyte.TryParse(s, out var result);
        }
        /// <summary>string是否可以转化为short</summary>
        /// <param name="s"></param>
        /// <returns>true：可与转化；false：不饿能进行转化</returns>
        public static bool IsShort(this string s)
        {
            return short.TryParse(s, out var result);
        }
        /// <summary>string是否可以转化为ushort</summary>
        /// <param name="s"></param>
        /// <returns>true：可与转化；false：不饿能进行转化</returns>
        public static bool IsUShort(this string s)
        {
            return ushort.TryParse(s, out var result);
        }
        /// <summary>string是否可以转化为int</summary>
        /// <param name="s"></param>
        /// <returns>true：可与转化；false：不饿能进行转化</returns>
        public static bool IsInt(this string s)
        {
            return int.TryParse(s, out var result);
        }
        /// <summary>string是否可以转化为uint</summary>
        /// <param name="s"></param>
        /// <returns>true：可与转化；false：不饿能进行转化</returns>
        public static bool IsUInt(this string s)
        {
            return uint.TryParse(s, out var result);
        }
        /// <summary>string是否可以转化为long</summary>
        /// <param name="s"></param>
        /// <returns>true：可与转化；false：不饿能进行转化</returns>
        public static bool IsLong(this string s)
        {
            return long.TryParse(s, out var result);
        }
        /// <summary>string是否可以转化为ulong</summary>
        /// <param name="s"></param>
        /// <returns>true：可与转化；false：不饿能进行转化</returns>
        public static bool IsULong(this string s)
        {
            return ulong.TryParse(s, out var result);
        }
        /// <summary>string是否可以转化为DateTime</summary>
        /// <param name="s"></param>
        /// <returns>true：可与转化；false：不饿能进行转化</returns>
        public static bool IsDateTime(this string s)
        {
            return DateTime.TryParse(s, out var result);
        }
        /// <summary>string是否可以转化为Guid</summary>
        /// <param name="s"></param>
        /// <returns>true：可与转化；false：不饿能进行转化</returns>
        public static bool IsGuid(this string s)
        {
            return Guid.TryParse(s, out var result);
        }
        /// <summary>string null or "" 判断</summary>
        /// <param name="s"></param>
        /// <returns>true：null or ""；false：非null and 非""</returns>
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }
        /// <summary>string null or "" or " " 判断</summary>
        /// <param name="s"></param>
        /// <returns>true：null or "" or " "；false：非null and 非"" and 非" "</returns>
        public static bool IsNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }
        /// <summary>string有效性判断</summary>
        /// <param name="s"></param>
        /// <returns>true：非null and 非""；false：true：null or ""；</returns>
        public static bool IsValid(this string s)
        {
            return !string.IsNullOrEmpty(s);
        }
        /// <summary>string左边取length位</summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Left(this string s, int length)
        {
            return s.IsNullOrEmpty() ? s : (length <= s.Length ? s.Substring(0, length) : s);
        }
        /// <summary>string左边取maxLength位</summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string TrimToMaxLength(this string value, int maxLength)
        {
            return (value == null || value.Length <= maxLength) ? value : value.Substring(0, maxLength);
        }
        /// <summary>string从start开始取length位</summary>
        /// <param name="s"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Middle(this string s, int start, int length)
        {
            if (s.IsNullOrEmpty())
            {
                return s;
            }
            if (s.Length < start)
            {
                return s;
            }
            return length <= s.Length - start ? s.Substring(start, length) : s.Substring(start, s.Length - start);
        }
        /// <summary>string右边取length位</summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Right(this string s, int length)
        {
            if (s.IsNullOrEmpty())
            {
                return s;
            }
            return length >= s.Length ? s : s.Substring(s.Length - length, length);
        }
        /// <summary>如果null or ""就用默认值，否则就用本身</summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string IfEmpty(this string value, string defaultValue)
        {
            return value.IsNullOrEmpty() ? defaultValue : value;
        }
        /// <summary>是否为数字</summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNumber(this string s)
        {
            Regex regex = new Regex("^[0-9]+$");
            return regex.Match(s).Success;
        }
        /// <summary>是否为带+-号数字</summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNumberWithSign(this string s)
        {
            Regex regex = new Regex("^[+-]?[0-9]+$");
            return regex.Match(s).Success;
        }

        /// <summary>是否为大写</summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsEngLishUpper(this string s)
        {
            Regex regex = new Regex("^[A-Z]+$");
            return regex.Match(s).Success;
        }

        public static bool IsNumberOrEngLishUpper(this string s)
        {
            Regex regex = new Regex("^[A-Z0-9]+$");
            return regex.Match(s).Success;
        }

        /// <summary>是否为小写</summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsEngLishLower(this string s)
        {
            Regex regex = new Regex("^[a-z]+$");
            return regex.Match(s).Success;
        }

        public static bool IsEnglishChar(string str)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");
            return regex.IsMatch(str);
        }

        public static bool IsNumberOrEnglishChar(this string s)
        {
            Regex regex = new Regex("^[0-9a-zA-Z]+$");
            return regex.Match(s).Success;
        }

        public static bool IsBarCode(this string s)
        {
            Regex regex = new Regex("^[0-9a-zA-Z+-]+[*]?[0-9a-zA-Z+-]+$");
            return regex.Match(s).Success;
        }

        public static bool IsNameSpace(string str)
        {
            Regex regex = new Regex("^[a-zA-Z.]+$");
            return regex.IsMatch(str) && !str.StartsWith(".") && !str.EndsWith(".") && str.SplitSeparatorCount(".") <= 3 && !str.Contains("..") && !str.Contains("...");
        }

        /// <summary>MD5</summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Md5String(this string s)
        {
            return s.Md5String(Encoding.UTF8).ToUpper();
        }
        /// <summary>SHA1</summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Sha1String(this string s)
        {
            return s.Sha1String(Encoding.UTF8).ToUpper();
        }
        /// <summary>SHA256</summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Sha256String(this string s)
        {
            return s.Sha256String(Encoding.UTF8).ToUpper();
        }
        /// <summary>SHA384</summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Sha384String(this string s)
        {
            return s.Sha384String(Encoding.UTF8).ToUpper();
        }
        /// <summary>SHA512</summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Sha512String(this string s)
        {
            return s.Sha512String(Encoding.UTF8).ToUpper();
        }
        /// <summary>是否为IP4</summary>
        /// <param name="s"></param>
        /// <returns>true：是IP4；false：不是IP4；</returns>
        public static bool IsIP4(this string s)
        {
            string[] array = s.Split(".");
            if (array.Length != 4)
            {
                return false;
            }
            foreach (string text in array)
            {
                if (!text.Trim().IsNumber())
                {
                    return false;
                }
                if (text.Trim().ToInt() < 0)
                {
                    return false;
                }
                if (text.Trim().ToInt() > 255)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>string分割为string[]</summary>
        /// <param name="s"></param>
        /// <param name="separator">分隔符</param>
        /// <param name="ignoreEmpty">true：忽视空元素；false：不忽视空元素；</param>
        /// <returns></returns>
        public static string[] Split(this string s, string separator, bool ignoreEmpty = false)
        {
            if (s.IsNullOrEmpty() || separator.IsNullOrEmpty())
            {
                throw new ArgumentException("参数为空");
            }
            if (!s.Contains(separator))
            {
                throw new ArgumentException($"字符串中不包含分隔符 {separator}");
            }
            return s.Split(new string[] { separator }, ignoreEmpty ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
        }
        /// <summary>获取指定分隔符的个数</summary>
        /// <param name="s"></param>
        /// <param name="separator">分隔符</param>
        /// <returns></returns>
        public static int SplitSeparatorCount(this string s, string separator)
        {
            if (s.IsNullOrEmpty() || separator.IsNullOrEmpty() || !s.Contains(separator))
            {
                return 0;
            }
            string text = s.Replace(separator, "");
            return (s.Length - text.Length) / separator.Length;
        }
        /// <summary>获取分隔后最后一个字符串</summary>
        /// <param name="s"></param>
        /// <param name="separator"></param>
        /// <param name="ignoreEmpty"></param>
        /// <returns></returns>
        public static string SplitLast(this string s, string separator, bool ignoreEmpty = false)
        {
            string[] array = s.Split(separator, ignoreEmpty);
            if (array.Length <= 0)
            {
                throw new Exception("数组为空");
            }
            return array[array.Length - 1];
        }
        /// <summary>获取分隔后第一个字符串</summary>
        /// <param name="s"></param>
        /// <param name="separator"></param>
        /// <param name="ignoreEmpty"></param>
        /// <returns></returns>
        public static string SplitFirst(this string s, string separator, bool ignoreEmpty = false)
        {
            return s.SplitIndex(separator, 0, ignoreEmpty);
        }
        /// <summary>获取分隔后第index字符串</summary>
        /// <param name="s"></param>
        /// <param name="separator"></param>
        /// <param name="index"></param>
        /// <param name="ignoreEmpty"></param>
        /// <returns></returns>
        public static string SplitIndex(this string s, string separator, int index, bool ignoreEmpty = false)
        {
            string[] array = s.Split(separator, ignoreEmpty);
            if (array.Length <= 0)
            {
                throw new Exception("数组为空");
            }
            if (index > array.Length - 1)
            {
                throw new IndexOutOfRangeException("参数index超出数组长度");
            }
            return array[index];
        }
        /// <summary>获取最后一个分隔符之前的数据</summary>
        /// <param name="s"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string SplitBeforeLast(this string s, string separator)
        {
            int num = s.LastIndexOf(separator, StringComparison.Ordinal);
            return num > 0 ? s.Substring(0, num) : s;
        }

        public static string Before(this string value, string x)
        {
            int num = value.IndexOf(x, StringComparison.Ordinal);
            return num == -1 ? string.Empty : value.Substring(0, num);
        }

        public static string Between(this string value, string x, string y)
        {
            int num = value.IndexOf(x, StringComparison.Ordinal);
            int num2 = value.LastIndexOf(y, StringComparison.Ordinal);
            if (num == -1 || num == -1)
            {
                return string.Empty;
            }
            int num3 = num + x.Length;
            return num3 >= num2 ? string.Empty : value.Substring(num3, num2 - num3).Trim();
        }

        public static string After(this string value, string x)
        {
            int num = value.LastIndexOf(x, StringComparison.Ordinal);
            if (num == -1)
            {
                return string.Empty;
            }
            int num2 = num + x.Length;
            return num2 >= value.Length ? string.Empty : value.Substring(num2).Trim();
        }

        /// <summary>创建Hash码</summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string CreateHash(this string content)
        {
            var computedContent = string.Format("blob {0}\0{1}", content.Length, content);
            var hashBytes = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(computedContent));
            var sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>MD5</summary>
        /// <param name="s"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        private static string Md5String(this string s, Encoding encode)
        {
            try
            {
                using (MD5 mD = MD5.Create())
                {
                    byte[] array = mD.ComputeHash(encode.GetBytes(s));
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (byte b in array)
                    {
                        stringBuilder.Append(b.ToString("x2"));
                    }
                    return stringBuilder.ToString();
                }
            }
            catch
            {
                return s;
            }
        }
        /// <summary>SHA1</summary>
        /// <param name="s"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        private static string Sha1String(this string s, Encoding encode)
        {
            try
            {
                using (SHA1 mD = SHA1.Create())
                {
                    byte[] array = mD.ComputeHash(encode.GetBytes(s));
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (byte b in array)
                    {
                        stringBuilder.Append(b.ToString("x2"));
                    }
                    return stringBuilder.ToString();
                }
            }
            catch
            {
                return s;
            }
        }
        /// <summary>SHA256</summary>
        /// <param name="s"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        private static string Sha256String(this string s, Encoding encode)
        {
            try
            {
                using (SHA256 mD = SHA256.Create())
                {
                    byte[] array = mD.ComputeHash(encode.GetBytes(s));
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (byte b in array)
                    {
                        stringBuilder.Append(b.ToString("x2"));
                    }
                    return stringBuilder.ToString();
                }
            }
            catch
            {
                return s;
            }
        }
        /// <summary>SHA384</summary>
        /// <param name="s"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        private static string Sha384String(this string s, Encoding encode)
        {
            try
            {
                using (SHA384 mD = SHA384.Create())
                {
                    byte[] array = mD.ComputeHash(encode.GetBytes(s));
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (byte b in array)
                    {
                        stringBuilder.Append(b.ToString("x2"));
                    }
                    return stringBuilder.ToString();
                }
            }
            catch
            {
                return s;
            }
        }
        /// <summary>SHA512</summary>
        /// <param name="s"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        private static string Sha512String(this string s, Encoding encode)
        {
            try
            {
                using (SHA512 mD = SHA512.Create())
                {
                    byte[] array = mD.ComputeHash(encode.GetBytes(s));
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (byte b in array)
                    {
                        stringBuilder.Append(b.ToString("x2"));
                    }
                    return stringBuilder.ToString();
                }
            }
            catch
            {
                return s;
            }
        }
        
        /// <summary>
         /// 字符串格式化<br/>
         /// 目前参数适用于数组或者字符串<br/>
         /// </summary>
         /// <param name="format">字符串</param>
         /// <param name="arg"></param>
         /// <returns></returns>
        public static string Format(this string format, object arg)
        {
            try
            {
                if (string.IsNullOrEmpty(format))
                {
                    return format;
                }

                return string.Format(format, arg);
            }
            catch (FormatException)
            {
                if (arg is string[])
                {
                    var args = (string[])arg;
                    LogHelper.LogAdd(LogLevel.Debug, $"StringEx.Format：Format string = {format}，Object to format = {string.Join(",", args)}", LogClassification.Tools.ToString());
                }
                else if (arg is string)
                {
                    LogHelper.LogAdd(LogLevel.Debug, $"StringEx.Format：Format string = {format}，Object to format = {arg}", LogClassification.Tools.ToString());
                }
            }
            catch (ArgumentNullException)
            {
                if (arg == null)
                {
                    LogHelper.LogAdd(LogLevel.Debug, $"StringEx.Format：Object to format = null", LogClassification.Tools.ToString());
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogAdd(LogLevel.Debug, $"StringEx.Format：{ex.Message}：{ex.StackTrace}", LogClassification.Tools.ToString());
            }

            return format;
        }
        #endregion











        public static bool IsMail(this string s)
        {
            string text = s.Trim();
            if (text == "" || text.Length == 0)
            {
                return false;
            }
            if (s.SplitSeparatorCount("@") != 1)
            {
                return false;
            }
            string[] array = text.Split('@');
            if (array.Length != 2)
            {
                return false;
            }
            if (array[0] == "" || array[1] == "")
            {
                return false;
            }
            string[] array2 = array;
            foreach (string text2 in array2)
            {
                for (int j = 0; j < text2.Length; j++)
                {
                    string separator = text2.Substring(j, 1).ToLower();
                    if ("abcdefghijklmnopqrstuvwxyz_-.0123456789".SplitSeparatorCount(separator) == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static byte[] ToEnBytes(this string s, int len)
        {
            byte[] array = s.ToEncodeBytes(Encoding.ASCII);
            byte[] array2 = new byte[len];
            Array.Copy(array, 0, array2, 0, Math.Min(array.Length, len));
            return array2;
        }

        public static string ToEnString(this byte[] s)
        {
            return s.ToEncodeString(Encoding.ASCII).Trim(default(char)).Trim();
        }

        public static byte[] ToEncodeBytes(this string dealString, Encoding encode)
        {
            return encode.GetBytes(dealString);
        }

        public static string ToEncodeString(this byte[] dealBytes, Encoding encode)
        {
            return encode.GetString(dealBytes);
        }

        public static string Base64Encode(this string value)
        {
            return value.Base64Encode(null);
        }

        public static string Base64Encode(this string value, Encoding encoding)
        {
            encoding = encoding ?? Encoding.UTF8;
            byte[] bytes = encoding.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }

        public static string Base64Decode(this string encodedValue)
        {
            return encodedValue.Base64Decode(null);
        }

        public static string Base64Decode(this string encodedValue, Encoding encoding)
        {
            encoding = encoding ?? Encoding.UTF8;
            byte[] bytes = Convert.FromBase64String(encodedValue);
            return encoding.GetString(bytes);
        }

        public static string SHA1Hash(this string stringToHash)
        {
            if (stringToHash.IsNullOrEmpty())
            {
                return null;
            }
            byte[] bytes = Encoding.UTF8.GetBytes(stringToHash);
            byte[] inArray = new SHA1CryptoServiceProvider().ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }

        public static string RemoveLeft(this string str, int number_of_characters)
        {
            if (str.Length <= number_of_characters)
            {
                return "";
            }
            return str.Substring(number_of_characters);
        }

        public static string RemoveRight(this string str, int number_of_characters)
        {
            if (str.Length <= number_of_characters)
            {
                return "";
            }
            return str.Substring(0, str.Length - number_of_characters);
        }

        public static SecureString ToSecureString(this string u, bool makeReadOnly = true)
        {
            if (u.IsNullOrEmpty())
            {
                return null;
            }
            SecureString secureString = new SecureString();
            foreach (char c in u)
            {
                secureString.AppendChar(c);
            }
            if (makeReadOnly)
            {
                secureString.MakeReadOnly();
            }
            return secureString;
        }

        public static string ToUnSecureString(this SecureString s)
        {
            if (s == null)
            {
                return null;
            }
            IntPtr intPtr = IntPtr.Zero;
            try
            {
                intPtr = Marshal.SecureStringToGlobalAllocUnicode(s);
                return Marshal.PtrToStringUni(intPtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(intPtr);
            }
        }

        public static string GZipCompress(this string input)
        {
            return input.IsNullOrEmpty() ? input : Convert.ToBase64String(Encoding.Default.GetBytes(input).GZipCompress());
        }

        public static string GZipDecompress(this string input)
        {
            return input.IsNullOrEmpty() ? input : Encoding.Default.GetString(Convert.FromBase64String(input).GZipDecompress());
        }

        public static string Reverse(this string text)
        {
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        public static string ToSBC(this string input)
        {
            char[] array = input.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == ' ')
                {
                    array[i] = '\u3000';
                }
                else if (array[i] < '\u007f')
                {
                    array[i] = (char)(array[i] + 65248);
                }
            }
            return new string(array);
        }

        public static string ToDBC(this string input)
        {
            char[] array = input.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '\u3000')
                {
                    array[i] = ' ';
                }
                else if (array[i] > '\uff00' && array[i] < '｟')
                {
                    array[i] = (char)(array[i] - 65248);
                }
            }
            return new string(array);
        }




        #region Method_BackUp

        public static bool HasCnChar(this string s)
        {
            Regex regex = new Regex("[一-龥]");
            return regex.Match(s).Success;
        }

        public static string DesEncrypt(this string s, string key = "")
        {
            try
            {
                string text = key + "!@#$%^&*";
                byte[] bytes = Encoding.UTF8.GetBytes(text.Substring(0, 8));
                byte[] rgbIV = bytes;
                byte[] bytes2 = Encoding.UTF8.GetBytes(s);
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, rgbIV), CryptoStreamMode.Write);
                cryptoStream.Write(bytes2, 0, bytes2.Length);
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(memoryStream.ToArray());
            }
            catch
            {
                return "";
            }
        }

        public static string DesDecrypt(this string s, string key = "")
        {
            try
            {
                string text = key + "!@#$%^&*";
                byte[] bytes = Encoding.UTF8.GetBytes(text.Substring(0, 8));
                byte[] rgbIV = bytes;
                byte[] array = Convert.FromBase64String(s);
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(bytes, rgbIV), CryptoStreamMode.Write);
                cryptoStream.Write(array, 0, array.Length);
                cryptoStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            catch
            {
                return "";
            }
        }

        public static string MyEncrypt(this string s, string key = "")
        {
            try
            {
                string text = key + "!@#$%^&*";
                byte[] bytes = Encoding.UTF8.GetBytes(text.Substring(0, 8));
                byte[] rgbIV = bytes;
                byte[] bytes2 = Encoding.UTF8.GetBytes(s);
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, rgbIV), CryptoStreamMode.Write);
                cryptoStream.Write(bytes2, 0, bytes2.Length);
                cryptoStream.FlushFinalBlock();
                string text2 = Convert.ToBase64String(memoryStream.ToArray());
                int num = 0;
                int num2 = text2.Length - 1;
                while (num2 >= 0 && text2[num2] == '=')
                {
                    num++;
                    num2--;
                }
                return text2.Left(text2.Length - num) + num;
            }
            catch
            {
                return "";
            }
        }

        public static string MyDecrypt(this string s, string key = "")
        {
            try
            {
                string text = key + "!@#$%^&*";
                byte[] bytes = Encoding.UTF8.GetBytes(text.Substring(0, 8));
                byte[] rgbIV = bytes;
                int num = s.Right(1).ToInt();
                s = s.Left(s.Length - 1);
                for (int i = 0; i < num; i++)
                {
                    s += "=";
                }
                byte[] array = Convert.FromBase64String(s);
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(bytes, rgbIV), CryptoStreamMode.Write);
                cryptoStream.Write(array, 0, array.Length);
                cryptoStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            catch
            {
                return "";
            }
        }
        #endregion
    }
}
