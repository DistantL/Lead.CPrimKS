using Lead.CPrim.ProxyTools;
using System;

namespace Sunny.UI
{
    public class IncreaseData<T>
	{
		private int level;

		private readonly int LevelBaseValue;

		private int Interval;

		public int Level
		{
			get
			{
				return level;
			}
			private set
			{
				level = value;
				Interval = (int)Math.Pow(LevelBaseValue, level);
			}
		}

		public T[] Value { get; private set; }

		public int Count { get; private set; }

		private int Index { get; set; }

		public T this[int index]
		{
			get
			{
				return index.InRange(0, Count - 1) ? Value[index] : default(T);
			}
			set
			{
				if (index.InRange(0, Count - 1))
				{
					Value[index] = value;
				}
			}
		}

		public IncreaseData(int level = 0, int baseValue = 4)
		{
			LevelBaseValue = baseValue;
			Level = level;
			Clear();
		}

		public void Clear()
		{
			Value = new T[16];
			Count = 0;
			Index = 0;
		}

		public bool Add(T value)
		{
			bool result = false;
			if (Interval == 1 || Index.Mod(Interval) == 0)
			{
				if (Count == Value.Length)
				{
					T[] array = new T[Value.Length * 2];
					Array.Copy(Value, array, Value.Length);
					Value = array;
				}
				Value[Count] = value;
				Count++;
				result = true;
			}
			Index++;
			return result;
		}

		public void Set(int dataLevel, T[] value)
		{
			Level = dataLevel;
			Count = value.Length;
			Index = 0;
			double num = Math.Log(Count, 2.0);
			int num2 = (int)Math.Pow(2.0, (int)num + 1);
			Value = new T[num2];
			Array.Copy(value, 0, Value, 0, Count);
		}
	}
}
