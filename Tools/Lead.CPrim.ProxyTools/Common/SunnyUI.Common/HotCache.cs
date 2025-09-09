using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Sunny.UI
{
    public class HotCache<TKey, TValue> : BackgroundWorkerEx where TValue : class
	{
		public ConcurrentDictionary<TKey, HotCacheItem<TKey, TValue>> Cache = new ConcurrentDictionary<TKey, HotCacheItem<TKey, TValue>>();

		public int AliveMinutes { get; set; } = 5;


		public DateTime LastAccessTime { get; private set; }

		public IHotCacheItemCreator<TKey, TValue> HotCacheItemCreator { get; set; }

		public event EventHandler OnCacheChanged;

		protected override void DoWorker()
		{
			try
			{
				DateTime now = DateTime.Now;
				IList<TKey> list = new List<TKey>();
				foreach (HotCacheItem<TKey, TValue> value in Cache.Values)
				{
					if ((now - value.LastAccessTime).TotalMinutes > (double)AliveMinutes)
					{
						list.Add(value.Key);
					}
				}
				foreach (TKey item in list)
				{
					Remove(item);
				}
				if (list.Count > 0)
				{
					this.OnCacheChanged?.Invoke(this, EventArgs.Empty);
				}
			}
			catch
			{
			}
		}

		protected override void BeforeStop()
		{
			base.BeforeStop();
			Clear();
		}

		public bool ContainsKey(TKey key)
		{
			return Get(key) != null;
		}

		public void Add(TKey key, TValue value)
		{
			if (key != null)
			{
				if (Cache.ContainsKey(key))
				{
					Cache.TryRemove(key, out var _);
				}
				Cache.TryAdd(key, new HotCacheItem<TKey, TValue>(key, value));
				this.OnCacheChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public void Remove(TKey key)
		{
			if (key != null && Cache.ContainsKey(key))
			{
				Cache.TryRemove(key, out var _);
				this.OnCacheChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public void Clear()
		{
			if (Cache.Count > 0)
			{
				Cache.Clear();
				this.OnCacheChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public TValue Get(TKey key)
		{
			if (key == null)
			{
				return null;
			}
			LastAccessTime = DateTime.Now;
			if (Cache.ContainsKey(key))
			{
				return Cache[key].Value;
			}
			IHotCacheItemCreator<TKey, TValue> hotCacheItemCreator = HotCacheItemCreator;
			TValue val = ((hotCacheItemCreator != null) ? hotCacheItemCreator.Run(key) : null);
			if (val != null)
			{
				Add(key, val);
				return val;
			}
			return null;
		}
	}
}
