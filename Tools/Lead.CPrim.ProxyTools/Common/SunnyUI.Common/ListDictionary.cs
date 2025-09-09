using System;
using System.Collections.Generic;
using System.Linq;

namespace Sunny.UI
{
	public class ListDictionary<K, V> where K : IComparable<K>
	{
		private List<KeyValuePair<K, V>> m_list = new List<KeyValuePair<K, V>>();

		private Dictionary<K, V> m_dict = new Dictionary<K, V>();

		public List<KeyValuePair<K, V>> Entries => m_list;

		public IEnumerable<K> Keys => m_list.Select((KeyValuePair<K, V> kvp) => kvp.Key);

		public IEnumerable<V> Values => m_list.Select((KeyValuePair<K, V> kvp) => kvp.Value);

		public V this[K key]
		{
			get
			{
				return m_dict[key];
			}
			set
			{
				Set(key, value);
			}
		}

		public int Count => m_list.Count;

		public K FirstKey => m_list[0].Key;

		public bool ContainsKey(K key)
		{
			return m_dict.ContainsKey(key);
		}

		public void Set(K key, V val)
		{
			bool flag = false;
			if (m_dict.ContainsKey(key))
			{
				for (int i = 0; i < m_list.Count; i++)
				{
					if (m_list[i].Key.CompareTo(key) == 0)
					{
						m_list[i] = new KeyValuePair<K, V>(key, val);
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				m_list.Add(new KeyValuePair<K, V>(key, val));
			}
			m_dict[key] = val;
		}
	}
}
