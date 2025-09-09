using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Sunny.UI
{
	public class ConcurrentDoubleKeyDictionary<TKey1, TKey2>
	{
		private readonly ConcurrentDictionary<TKey1, TKey2> Key1 = new ConcurrentDictionary<TKey1, TKey2>();

		private readonly ConcurrentDictionary<TKey2, TKey1> Key2 = new ConcurrentDictionary<TKey2, TKey1>();

		public TKey2 this[TKey1 key1]
		{
			get
			{
				return GetKey2(key1);
			}
			set
			{
				TryAdd(key1, value);
			}
		}

		public int Count => Key1.Count;

		public void TryAdd(TKey1 key1, TKey2 key2)
		{
			Key1.TryAddOrUpdate(key1, key2);
			Key2.TryAddOrUpdate(key2, key1);
		}

		public void RemoveByKey1(TKey1 key1)
		{
			if (ContainsKey1(key1))
			{
				TKey2 key2 = GetKey2(key1);
				Key1.TryRemove(key1, out var _);
				if (ContainsKey2(key2))
				{
					Key2.TryRemove(key2, out var _);
				}
			}
		}

		public void RemoveByKey2(TKey2 key2)
		{
			if (ContainsKey2(key2))
			{
				TKey1 key3 = GetKey1(key2);
				Key2.TryRemove(key2, out var _);
				if (ContainsKey1(key3))
				{
					Key1.TryRemove(key3, out var _);
				}
			}
		}

		public TKey2 GetKey2(TKey1 key1)
		{
			return Key1.ContainsKey(key1) ? Key1[key1] : default(TKey2);
		}

		public TKey1 GetKey1(TKey2 key2)
		{
			return Key2.ContainsKey(key2) ? Key2[key2] : default(TKey1);
		}

		public bool ContainsKey1(TKey1 key1)
		{
			return Key1.ContainsKey(key1);
		}

		public bool ContainsKey2(TKey2 key2)
		{
			return Key2.ContainsKey(key2);
		}

		public IList<TKey1> Key1List()
		{
			return Key1.Keys.ToList();
		}

		public IList<TKey2> Key2List()
		{
			return Key2.Keys.ToList();
		}

		public void Clear()
		{
			Key1.Clear();
			Key2.Clear();
		}
	}
}
