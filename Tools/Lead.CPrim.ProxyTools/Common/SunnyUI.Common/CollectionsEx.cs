using Lead.CPrim.ProxyTools;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Sunny.UI
{
    public static class CollectionsEx
	{
		public static List<T> ToList<T>(this ArrayList arrayList)
		{
			return arrayList.OfType<T>().ToList();
		}

		public static DataTable ToDataTable<TSource>(this IList<TSource> data)
		{
			DataTable dataTable = new DataTable(typeof(TSource).Name);
			PropertyInfo[] properties = typeof(TSource).GetProperties(BindingFlags.Instance | BindingFlags.Public);
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				dataTable.Columns.Add(propertyInfo.Name, Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType);
			}
			foreach (TSource datum in data)
			{
				object[] array2 = new object[properties.Length];
				for (int j = 0; j < properties.Length; j++)
				{
					array2[j] = properties[j].GetValue(datum, null);
				}
				dataTable.Rows.Add(array2);
			}
			return dataTable;
		}

		public static List<Key> SortedKeys<Key, Value>(this ConcurrentDictionary<Key, Value> dictionary)
		{
			if (dictionary == null)
			{
				return null;
			}
			List<Key> list = dictionary.Keys.ToList();
			list.Sort();
			return list;
		}

		public static Dictionary<Key, Value> OrderByValueDesc<Key, Value>(this Dictionary<Key, Value> dictionary)
		{
			if (dictionary == null)
			{
				return null;
			}
			IOrderedEnumerable<KeyValuePair<Key, Value>> orderedEnumerable = dictionary.OrderByDescending(delegate(KeyValuePair<Key, Value> pair)
			{
				KeyValuePair<Key, Value> keyValuePair = pair;
				return keyValuePair.Value;
			});
			return (Dictionary<Key, Value>)orderedEnumerable;
		}

		public static Dictionary<Key, Value> OrderByValue<Key, Value>(this Dictionary<Key, Value> dictionary)
		{
			if (dictionary == null)
			{
				return null;
			}
			IOrderedEnumerable<KeyValuePair<Key, Value>> orderedEnumerable = dictionary.OrderBy(delegate(KeyValuePair<Key, Value> pair)
			{
				KeyValuePair<Key, Value> keyValuePair = pair;
				return keyValuePair.Value;
			});
			return (Dictionary<Key, Value>)orderedEnumerable;
		}

		public static Dictionary<Key, Value> OrderByKeyDesc<Key, Value>(this Dictionary<Key, Value> dictionary)
		{
			if (dictionary == null)
			{
				return null;
			}
			IOrderedEnumerable<KeyValuePair<Key, Value>> orderedEnumerable = dictionary.OrderByDescending(delegate(KeyValuePair<Key, Value> pair)
			{
				KeyValuePair<Key, Value> keyValuePair = pair;
				return keyValuePair.Key;
			});
			return (Dictionary<Key, Value>)orderedEnumerable;
		}

		public static Dictionary<Key, Value> OrderByKey<Key, Value>(this Dictionary<Key, Value> dictionary)
		{
			if (dictionary == null)
			{
				return null;
			}
			IOrderedEnumerable<KeyValuePair<Key, Value>> orderedEnumerable = dictionary.OrderBy(delegate(KeyValuePair<Key, Value> pair)
			{
				KeyValuePair<Key, Value> keyValuePair = pair;
				return keyValuePair.Key;
			});
			return (Dictionary<Key, Value>)orderedEnumerable;
		}

		public static ConcurrentDictionary<Key, Value> OrderByValueDesc<Key, Value>(this ConcurrentDictionary<Key, Value> dictionary)
		{
			if (dictionary == null)
			{
				return null;
			}
			IOrderedEnumerable<KeyValuePair<Key, Value>> orderedEnumerable = dictionary.OrderByDescending(delegate(KeyValuePair<Key, Value> pair)
			{
				KeyValuePair<Key, Value> keyValuePair = pair;
				return keyValuePair.Value;
			});
			return (ConcurrentDictionary<Key, Value>)orderedEnumerable;
		}

		public static ConcurrentDictionary<Key, Value> OrderByValue<Key, Value>(this ConcurrentDictionary<Key, Value> dictionary)
		{
			if (dictionary == null)
			{
				return null;
			}
			IOrderedEnumerable<KeyValuePair<Key, Value>> orderedEnumerable = dictionary.OrderBy(delegate(KeyValuePair<Key, Value> pair)
			{
				KeyValuePair<Key, Value> keyValuePair = pair;
				return keyValuePair.Value;
			});
			return (ConcurrentDictionary<Key, Value>)orderedEnumerable;
		}

		public static ConcurrentDictionary<Key, Value> OrderByKeyDesc<Key, Value>(this ConcurrentDictionary<Key, Value> dictionary)
		{
			if (dictionary == null)
			{
				return null;
			}
			IOrderedEnumerable<KeyValuePair<Key, Value>> orderedEnumerable = dictionary.OrderByDescending(delegate(KeyValuePair<Key, Value> pair)
			{
				KeyValuePair<Key, Value> keyValuePair = pair;
				return keyValuePair.Key;
			});
			return (ConcurrentDictionary<Key, Value>)orderedEnumerable;
		}

		public static ConcurrentDictionary<Key, Value> OrderByKey<Key, Value>(this ConcurrentDictionary<Key, Value> dictionary)
		{
			if (dictionary == null)
			{
				return null;
			}
			IOrderedEnumerable<KeyValuePair<Key, Value>> orderedEnumerable = dictionary.OrderBy(delegate(KeyValuePair<Key, Value> pair)
			{
				KeyValuePair<Key, Value> keyValuePair = pair;
				return keyValuePair.Key;
			});
			return (ConcurrentDictionary<Key, Value>)orderedEnumerable;
		}

		public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
		{
			Random random = new Random();
			List<T> list = source.ToList();
			for (int i = 0; i < list.Count; i++)
			{
				Swap(list, i, random.Next(list.Count));
			}
			return list;
		}

		public static IEnumerable<T> RandomizeEx<T>(this IEnumerable<T> source)
		{
			Random r = new Random();
			return from x in source
				select new
				{
					Key = r.Next(),
					Value = x
				} into x
				orderby x.Key
				select x.Value;
		}

		public static void Swap<T>(List<T> list, int i, int j)
		{
			T value = list[i];
			list[i] = list[j];
			list[j] = value;
		}

		public static void ForEach<T>(this IEnumerable<T> list, Action<T> function)
		{
			foreach (T item in list)
			{
				function(item);
			}
		}

		public static List<Key> SortedKeys<Key, Value>(this Dictionary<Key, Value> dictionary)
		{
			if (dictionary == null)
			{
				return null;
			}
			List<Key> list = dictionary.Keys.ToList();
			list.Sort();
			return list;
		}

		public static List<Value> SortedValues<Key, Value>(this ConcurrentDictionary<Key, Value> dictionary)
		{
			if (dictionary == null)
			{
				return null;
			}
			List<Key> list = dictionary.SortedKeys();
			List<Value> list2 = new List<Value>();
			foreach (Key item in list)
			{
				list2.Add(dictionary[item]);
			}
			return list2;
		}

		public static List<Value> SortedValues<Key, Value>(this Dictionary<Key, Value> dictionary)
		{
			if (dictionary == null)
			{
				return null;
			}
			List<Key> list = dictionary.SortedKeys();
			List<Value> list2 = new List<Value>();
			foreach (Key item in list)
			{
				list2.Add(dictionary[item]);
			}
			return list2;
		}

		public static void Clear<T>(this ConcurrentQueue<T> queue)
		{
			while (queue.Count > 0)
			{
				queue.TryDequeue(out var _);
			}
		}

		public static bool NotContainsKey<Key, Value>(this ConcurrentDictionary<Key, Value> dictionary, Key key)
		{
			return !dictionary.ContainsKey(key);
		}

		public static bool NotContainsKey<Key, Value>(this Dictionary<Key, Value> dictionary, Key key)
		{
			return !dictionary.ContainsKey(key);
		}

		public static bool ContainsIndex(this IList list, int index)
		{
			if (list.IsNullOrEmpty())
			{
				return false;
			}
			return index >= 0 && index < list.Count;
		}

		public static bool NotContainsIndex(this IList list, int index)
		{
			return !list.ContainsIndex(index);
		}

		public static T First<T>(this IList<T> list)
		{
			if (list == null || list.Count == 0)
			{
				return default(T);
			}
			return list[0];
		}

		public static T Last<T>(this IList<T> list)
		{
			if (list == null || list.Count == 0)
			{
				return default(T);
			}
			return list[list.Count - 1];
		}

		public static IDictionary<Key, Value> TryAddOrUpdate<Key, Value>(this IDictionary<Key, Value> dictionary, Key key, Value value)
		{
			if (dictionary.ContainsKey(key))
			{
				dictionary[key] = value;
			}
			else
			{
				dictionary.Add(key, value);
			}
			return dictionary;
		}

		public static TKey FindFirstKeyByValue<TKey, TValue>(this IDictionary<TKey, TValue> dic, TValue value) where TKey : class where TValue : IEquatable<TValue>
		{
			foreach (KeyValuePair<TKey, TValue> item in dic)
			{
				if (item.Value.Equals(value))
				{
					return item.Key;
				}
			}
			return null;
		}

		public static void RemoveFirstValue<TKey, TValue>(this IDictionary<TKey, TValue> dic, TValue value) where TKey : class where TValue : IEquatable<TValue>
		{
			TKey key = dic.FindFirstKeyByValue(value);
			if (dic.ContainsKey(key))
			{
				dic.Remove(key);
			}
		}

		public static int Search<T>(IList<T> list, T value) where T : IComparable
		{
			int num = 0;
			int num2 = list.Count;
			while (num2 >= num)
			{
				int num3 = (num + num2) / 2;
				if (list[num3].CompareTo(value) == 0)
				{
					return num3;
				}
				if (list[num3].CompareTo(value) > 0)
				{
					num2 = num3 - 1;
				}
				else
				{
					num = num3 + 1;
				}
			}
			return -1;
		}

		public static T Get<T>(this List<T> list, int index)
		{
			return list.Exist(index) ? list[index] : default(T);
		}

		public static void Update<T>(this List<T> list, int index, T value)
		{
			if (list.Exist(index))
			{
				list[index] = value;
			}
		}

		public static bool Exist<T>(this List<T> list, int index)
		{
			return index >= 0 && index < list.Count;
		}

		public static bool IsEmpty<T>(this List<T> list)
		{
			return list.Count == 0;
		}

		public static T First<T>(this List<T> list)
		{
			return list.Get(0);
		}

		public static T Last<T>(this List<T> list)
		{
			return list.Get(list.Count - 1);
		}

		public static TValue GetValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue defaultValue = default(TValue))
		{
			return dict.ContainsKey(key) ? dict[key] : defaultValue;
		}
	}
}
