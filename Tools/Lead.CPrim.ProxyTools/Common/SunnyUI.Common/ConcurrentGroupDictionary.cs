using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Sunny.UI
{
	public class ConcurrentGroupDictionary<TGroup, TKey, TValue>
	{
		private readonly ConcurrentDictionary<TGroup, ConcurrentDictionary<TKey, TValue>> Dictionary = new ConcurrentDictionary<TGroup, ConcurrentDictionary<TKey, TValue>>();

		public ConcurrentDictionary<TKey, TValue> this[TGroup group]
		{
			get
			{
				return ContainsGroup(group) ? Dictionary[group] : new ConcurrentDictionary<TKey, TValue>();
			}
			set
			{
				if (!ContainsGroup(group))
				{
					TryAdd(group);
				}
				Dictionary[group] = value;
			}
		}

		public List<TGroup> Groups => Dictionary.Keys.ToList();

		public List<TGroup> SortedGroups
		{
			get
			{
				List<TGroup> groups = Groups;
				groups.Sort();
				return groups;
			}
		}

		public int AllCount => ((IEnumerable<TGroup>)Groups).Sum((Func<TGroup, int>)GroupItemsCount);

		public int GroupCount => Dictionary.Count;

		public bool ContainsGroup(TGroup group)
		{
			return Dictionary.ContainsKey(group);
		}

		public bool ContainsKey(TKey key)
		{
			return Groups.Any((TGroup group) => ContainsKey(group, key));
		}

		public bool ContainsKey(TGroup group, TKey key)
		{
			return ContainsGroup(group) && Dictionary[group].ContainsKey(key);
		}

		public void TryAdd(TGroup group)
		{
			if (!Dictionary.ContainsKey(group))
			{
				Dictionary.TryAdd(group, new ConcurrentDictionary<TKey, TValue>());
			}
		}

		public void TryAdd(TGroup group, TKey key, TValue value)
		{
			TryAdd(group);
			if (ContainsKey(group, key))
			{
				Dictionary[group][key] = value;
			}
			else
			{
				Dictionary[group].TryAdd(key, value);
			}
		}

		public bool TryUpdate(TGroup group, TKey key, TValue value)
		{
			if (!ContainsGroup(group))
			{
				return false;
			}
			TryAdd(group, key, value);
			return true;
		}

		public void TryRemove(TGroup group, TKey key)
		{
			if (ContainsGroup(group))
			{
				if (ContainsKey(group, key))
				{
					Dictionary[group].TryRemove(key, out var _);
				}
				if (GroupItemsCount(group) == 0)
				{
					Dictionary.TryRemove(group, out var _);
				}
			}
		}

		public void TryRemove(TGroup group)
		{
			ClearGroup(group);
			Dictionary.TryRemove(group, out var _);
		}

		public void Clear()
		{
			foreach (TGroup group in Groups)
			{
				ClearGroup(group);
			}
			Dictionary.Clear();
		}

		public void ClearGroup(TGroup group)
		{
			if (ContainsGroup(group))
			{
				Dictionary[group].Clear();
			}
		}

		public List<TValue> Values(TGroup group)
		{
			return ContainsGroup(group) ? Dictionary[group].Values.ToList() : new List<TValue>();
		}

		public List<TKey> Keys(TGroup group)
		{
			return ContainsGroup(group) ? Dictionary[group].Keys.ToList() : new List<TKey>();
		}

		public List<TKey> SortedKeys(TGroup group)
		{
			List<TKey> list = Keys(group);
			list.Sort();
			return list;
		}

		public List<TValue> SortedValues(TGroup group)
		{
			List<TValue> list = new List<TValue>();
			if (ContainsGroup(group))
			{
				List<TKey> list2 = SortedKeys(group);
				foreach (TKey item in list2)
				{
					list.Add(Dictionary[group][item]);
				}
			}
			return list;
		}

		public TValue GetValue(TGroup group, TKey key)
		{
			return ContainsKey(group, key) ? Dictionary[group][key] : default(TValue);
		}

		public int GroupItemsCount(TGroup group)
		{
			return ContainsGroup(group) ? Dictionary[group].Count : 0;
		}
	}
}
