using System.Collections.Generic;
using System.Linq;

namespace Sunny.UI
{
	public class KeyScopes
	{
		private readonly SortedSet<int> array = new SortedSet<int>();

		public int Min => array.Min;

		public int Max => array.Max;

		public void Add(int value)
		{
			if (!array.Contains(value))
			{
				array.Add(value);
			}
		}

		public void Add(KeyScope value)
		{
			for (int i = value.Min; i <= value.Max; i++)
			{
				Add(i);
			}
		}

		public void Add(string value)
		{
			KeyScope value2 = new KeyScope(value);
			Add(value2);
		}

		public bool Contains(int value)
		{
			return array.Contains(value);
		}

		public override string ToString()
		{
			if (array.Count == 0)
			{
				return string.Empty;
			}
			List<int> list = array.ToList();
			if (array.Count == 1)
			{
				return list[0].ToString();
			}
			if (array.Count == 2)
			{
				return list[0].ToString() + list[1];
			}
			int num = 0;
			int num2 = Min;
			List<string> list2 = new List<string>();
			while (num < list.Count - 1)
			{
				num++;
				if (list[num] - list[num - 1] > 1)
				{
					if (num2 == list[num - 1])
					{
						list2.Add(num2.ToString());
					}
					else
					{
						list2.Add(num2 + ".." + list[num - 1]);
					}
					num2 = list[num];
				}
			}
			if (num2 == list[num])
			{
				list2.Add(num2.ToString());
			}
			else
			{
				list2.Add(num2 + ".." + list[num]);
			}
			return string.Join(", ", list2.ToArray());
		}
	}
}
