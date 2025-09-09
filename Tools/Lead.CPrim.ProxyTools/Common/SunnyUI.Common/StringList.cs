using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sunny.UI
{
	public class StringList
	{
		private readonly List<string> _strings = new List<string>();

		public int Count => _strings.Count;

		public string Text => ToString();

		public string this[int index]
		{
			get
			{
				if (index < 0 || index >= Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				return _strings[index];
			}
			set
			{
				if (index < 0 || index >= Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				_strings[index] = value;
			}
		}

		public string[] Strings => _strings.ToArray();

		public int Add(string value)
		{
			_strings.Add(value);
			return Count;
		}

		public void Insert(int index, string value)
		{
			if (index < 0)
			{
				index = 0;
			}
			_strings.Insert(index, value);
		}

		public int IndexOf(string value)
		{
			return _strings.IndexOf(value);
		}

		public void Delete(int index)
		{
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			_strings.RemoveAt(index);
		}

		public override string ToString()
		{
			return string.Join(Environment.NewLine, _strings.ToArray());
		}

		public string ToString(int startIndex, int count)
		{
			if (startIndex < 0)
			{
				startIndex = 0;
			}
			else if (startIndex >= Count)
			{
				return "";
			}
			if (count <= 0)
			{
				return "";
			}
			if (count + startIndex > Count)
			{
				count = Count - startIndex;
			}
			StringBuilder stringBuilder = new StringBuilder(Count);
			for (int i = startIndex; i < count; i++)
			{
				stringBuilder.Append(_strings[i] + Environment.NewLine);
			}
			return stringBuilder.ToString();
		}

		public void Clear()
		{
			_strings.Clear();
		}

		public void SaveToFile(string fileName, Encoding encoding)
		{
			File.WriteAllLines(fileName, _strings.ToArray(), encoding);
		}

		public void SaveToFile(string fileName)
		{
			SaveToFile(fileName, Encoding.UTF8);
		}

		public void LoadFromFile(string fileName)
		{
			LoadFromFile(fileName, Encoding.UTF8);
		}

		public void LoadFromFile(string fileName, Encoding encoding)
		{
			Clear();
			_strings.AddRange(File.ReadAllLines(fileName, encoding));
		}
	}
}
