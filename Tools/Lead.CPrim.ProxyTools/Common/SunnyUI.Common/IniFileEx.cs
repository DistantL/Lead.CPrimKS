using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Sunny.UI
{
    public class IniFileEx
	{
		private readonly Dictionary<string, NameValueCollection> data = new Dictionary<string, NameValueCollection>();

		private static readonly Regex regRemoveEmptyLines = new Regex("(\\s*;[\\d\\D]*?\\r?\\n)+|\\r?\\n(\\s*\\r?\\n)*", RegexOptions.Multiline | RegexOptions.Compiled);

		private static readonly Regex regParseIniData = new Regex("\r\n                (?<IsSection>\r\n                    ^\\s*\\[(?<SectionName>[^\\]]+)?\\]\\s*$\r\n                )\r\n                |\r\n                (?<IsKeyValue>\r\n                    ^\\s*(?<Key>[^(\\s*\\=\\s*)]+)?\\s*\\=\\s*(?<Value>[\\d\\D]*)$\r\n                )", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);

		[Description("文件名")]
		public string FileName { get; set; }

		public Encoding Encoding { get; set; }

		public NameValueCollection this[string section]
		{
			get
			{
				section = section.ToLowerInvariant();
				if (!data.ContainsKey(section))
				{
					data.Add(section, new NameValueCollection());
				}
				return data[section];
			}
		}

		public string this[string section, string key]
		{
			get
			{
				return this[section][key];
			}
			set
			{
				this[section][key] = value;
			}
		}

		public object this[string section, string key, Type t]
		{
			get
			{
				if (t == null || t == (Type)Type.Missing)
				{
					return this[section][key];
				}
				return GetValue(section, key, null, t);
			}
			set
			{
				if (t == null || t == (Type)Type.Missing)
				{
					this[section][key] = string.Empty;
				}
				else
				{
					SetValue(section, key, value);
				}
			}
		}

		public IniFileEx(string fileName)
			: this(fileName, Encoding.Default)
		{
		}

		public IniFileEx(string fileName, Encoding encoding)
		{
			FileName = fileName;
			Encoding = encoding;
			using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
			{
				ReadIniData(stream, encoding);
			}
		}

		private void ReadIniData(Stream stream, Encoding encoding)
		{
			string text = string.Empty;
			data.Add(text, new NameValueCollection());
			if (stream == null || encoding == null)
			{
				return;
			}
			using (StreamReader streamReader = new StreamReader(stream, encoding))
			{
				string input = streamReader.ReadToEnd();
				input = regRemoveEmptyLines.Replace(input, "\n");
				string[] array = input.Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
				string[] array2 = array;
				foreach (string input2 in array2)
				{
					Match match = regParseIniData.Match(input2);
					if (!match.Success)
					{
						continue;
					}
					if (match.Groups["IsSection"].Length > 0)
					{
						string text2 = match.Groups["SectionName"].Value.ToLowerInvariant();
						if (text != text2)
						{
							text = text2;
							if (!data.ContainsKey(text2))
							{
								data.Add(text2, new NameValueCollection());
							}
						}
					}
					else if (match.Groups["IsKeyValue"].Length > 0)
					{
						data[text].Add(match.Groups["Key"].Value, match.Groups["Value"].Value);
					}
				}
			}
		}

		public string[] KeyNames(string section)
		{
			return this[section].AllKeys;
		}

		public string[] SectionValues(string section)
		{
			return this[section].GetValues(0);
		}

		private object GetValue(string section, string key, object defaultValue, Type t)
		{
			if (!data.ContainsKey(section))
			{
				return defaultValue;
			}
			string value = data[section][key];
			if (string.IsNullOrEmpty(value))
			{
				return defaultValue;
			}
			TypeConverter converter = TypeDescriptor.GetConverter(t);
			if (!converter.CanConvertFrom(typeof(string)))
			{
				return defaultValue;
			}
			try
			{
				return converter.ConvertFrom(value);
			}
			catch
			{
				return defaultValue;
			}
		}

		private T GetValue<T>(string section, string key, T defaultValue)
		{
			return (T)GetValue(section, key, defaultValue, typeof(T));
		}

		private void SetValue(string section, string key, object value)
		{
			if (value == null)
			{
				this[section][key] = string.Empty;
			}
			else
			{
				TypeConverter converter = TypeDescriptor.GetConverter(value);
				if (!converter.CanConvertTo(typeof(string)))
				{
					this[section][key] = value.ToString();
				}
				else
				{
					this[section][key] = (string)converter.ConvertTo(value, typeof(string));
				}
			}
			UpdateFile();
		}

		public void Write(string section, string key, string value)
		{
			SetValue(section, key, value);
		}

		public string Read(string section, string key, string Default)
		{
			return GetValue(section, key, Default);
		}

		public NameValueCollection GetSectionValues(string section)
		{
			return this[section];
		}

		public void UpdateFile()
		{
			Save();
		}

		public void Save()
		{
			Save(FileName, Encoding);
		}

		public void Save(string fileName, Encoding encoding)
		{
			using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
			{
				Save(stream, encoding);
			}
		}

		private void Save(Stream stream, Encoding encoding)
		{
			using (StreamWriter streamWriter = new StreamWriter(stream, encoding))
			{
				foreach (KeyValuePair<string, NameValueCollection> datum in data)
				{
					if (!string.IsNullOrEmpty(datum.Key))
					{
						streamWriter.WriteLine("[{0}]", datum.Key);
					}
					NameValueCollection value = datum.Value;
					foreach (string key in value.Keys)
					{
						if (!string.IsNullOrEmpty(key))
						{
							string text2 = value[key];
							if (!string.IsNullOrEmpty(text2))
							{
								streamWriter.WriteLine("{0}={1}", key, text2);
							}
						}
					}
				}
				streamWriter.Flush();
			}
		}

		public bool HasSection(string section)
		{
			return data.ContainsKey(section.ToLowerInvariant());
		}

		public bool HasKey(string section, string key)
		{
			return data.ContainsKey(section) && !string.IsNullOrEmpty(data[section][key]);
		}

		public void WriteStruct<T>(string section, string key, T value) where T : struct
		{
			Write(section, key, value.StructToBytes());
		}

		public T ReadStruct<T>(string section, string key, T Default) where T : struct
		{
			int num = Default.Size();
			byte[] array = Read(section, key, "").ToHexBytes();
			return (num > array.Length) ? Default : array.ToStruct<T>();
		}

		public void Write(string section, string key, byte[] value)
		{
			Write(section, key, value.ToHexString());
		}

		public byte[] ReadBytes(string section, string key, byte[] Default)
		{
			return Read(section, key, Default.ToHexString()).ToHexBytes();
		}

		public void Write(string section, string key, char value)
		{
			Write(section, key, value.ToString());
		}

		public char ReadChar(string section, string key, char Default = ' ')
		{
			return Read(section, key, Default.ToString()).ToChar(Default);
		}

		public void Write(string section, string key, decimal value)
		{
			Write(section, key, value.ToString(CultureInfo.InvariantCulture));
		}

		public decimal ReadDecimal(string section, string key, decimal Default = 0m)
		{
			return Read(section, key, Default.ToString(CultureInfo.InvariantCulture)).ToDecimal(Default);
		}

		public void Write(string section, string key, short value)
		{
			Write(section, key, value.ToString());
		}

		public short ReadShort(string section, string key, short Default = 0)
		{
			return Read(section, key, Default.ToString()).ToShort(Default);
		}

		public void Write(string section, string key, ushort value)
		{
			Write(section, key, value.ToString());
		}

		public ushort ReadUShort(string section, string key, ushort Default = 0)
		{
			return Read(section, key, Default.ToString()).ToUShort(Default);
		}

		public void Write(string section, string key, int value)
		{
			Write(section, key, value.ToString());
		}

		public int ReadInt(string section, string key, int Default = 0)
		{
			return Read(section, key, Default.ToString()).ToInt(Default);
		}

		public void Write(string section, string key, uint value)
		{
			Write(section, key, value.ToString());
		}

		public uint ReadUInt(string section, string key, uint Default = 0u)
		{
			return Read(section, key, Default.ToString()).ToUInt(Default);
		}

		public void Write(string section, string key, ulong value)
		{
			Write(section, key, value.ToString());
		}

		public ulong ReadULong(string section, string key, ulong Default = 0uL)
		{
			return Read(section, key, Default.ToString()).ToULong(Default);
		}

		public void Write(string section, string key, long value)
		{
			Write(section, key, value.ToString());
		}

		public long ReadLong(string section, string key, long Default = 0L)
		{
			return Read(section, key, Default.ToString()).ToLong(Default);
		}

		public void Write(string section, string key, bool value)
		{
			Write(section, key, value ? bool.TrueString : bool.FalseString);
		}

		public bool ReadBool(string section, string key, bool Default = false)
		{
			string a = Read(section, key, Default.ToString());
			if (string.Equals(a, bool.TrueString, StringComparison.CurrentCultureIgnoreCase))
			{
				return true;
			}
			if (string.Equals(a, bool.FalseString, StringComparison.CurrentCultureIgnoreCase))
			{
				return false;
			}
			return Default;
		}

		public void Write(string section, string key, double value)
		{
			Write(section, key, value.ToString(CultureInfo.InvariantCulture));
		}

		public double ReadDouble(string section, string key, double Default = 0.0)
		{
			return Read(section, key, Default.ToString(CultureInfo.InvariantCulture)).ToDouble(Default);
		}

		public void Write(string section, string key, float value)
		{
			Write(section, key, value.ToString(CultureInfo.InvariantCulture));
		}

		public float ReadFloat(string section, string key, float Default = 0f)
		{
			return Read(section, key, Default.ToString(CultureInfo.InvariantCulture)).ToFloat(Default);
		}

		public void Write(string section, string key, byte value)
		{
			Write(section, key, value.ToString());
		}

		public byte ReadByte(string section, string key, byte Default = 0)
		{
			return Read(section, key, Default.ToString()).ToByte(Default);
		}

		public void Write(string section, string key, sbyte value)
		{
			Write(section, key, value.ToString());
		}

		public sbyte ReadSByte(string section, string key, sbyte Default = 0)
		{
			return Read(section, key, Default.ToString()).ToSByte(Default);
		}

		public void Write(string section, string key, DateTime value)
		{
			Write(section, key, value.ToString("yyyy-MM-dd HH:mm:ss"));
		}

		public DateTime ReadDateTime(string section, string key, DateTime Default)
		{
			string s = Read(section, key, Default.ToString(CultureInfo.InvariantCulture));
			try
			{
				return s.ToDateTime("yyyy-MM-dd HH:mm:ss");
			}
			catch (Exception)
			{
				return Default;
			}
		}

		public void Write(string section, string key, Point value)
		{
			Write(section, key, ConvertEx.ObjectToString(value, typeof(Point)));
		}

		public Point ReadPoint(string section, string key, Point Default)
		{
			string str = Read(section, key, "");
			return (Point)ConvertEx.StringToObject(str, typeof(Point), Default);
		}

		public void Write(string section, string key, PointF value)
		{
			Write(section, key, ConvertEx.ObjectToString(value, typeof(PointF)));
		}

		public PointF ReadPointF(string section, string key, PointF Default)
		{
			string str = Read(section, key, "");
			return (PointF)ConvertEx.StringToObject(str, typeof(PointF), Default);
		}

		public void Write(string section, string key, Size value)
		{
			Write(section, key, ConvertEx.ObjectToString(value, typeof(Size)));
		}

		public Size ReadSize(string section, string key, Size Default)
		{
			string str = Read(section, key, "");
			return (Size)ConvertEx.StringToObject(str, typeof(Size), Default);
		}

		public void Write(string section, string key, SizeF value)
		{
			Write(section, key, ConvertEx.ObjectToString(value, typeof(SizeF)));
		}

		public SizeF ReadSizeF(string section, string key, SizeF Default)
		{
			string str = Read(section, key, "");
			return (SizeF)ConvertEx.StringToObject(str, typeof(SizeF), Default);
		}

		public void Write(string section, string key, Color value)
		{
			Write(section, key, ConvertEx.ObjectToString(value, typeof(Color)));
		}

		public Color ReadColor(string section, string key, Color Default)
		{
			string str = Read(section, key, "");
			return (Color)ConvertEx.StringToObject(str, typeof(Color), Default);
		}
	}
}
