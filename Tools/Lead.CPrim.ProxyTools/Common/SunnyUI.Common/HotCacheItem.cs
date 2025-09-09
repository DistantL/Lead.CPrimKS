using System;

namespace Sunny.UI
{
	public class HotCacheItem<TKey, TValue>
	{
		private TValue _value;

		public TKey Key { get; private set; }

		public TValue Value
		{
			get
			{
				LastAccessTime = DateTime.Now;
				return _value;
			}
		}

		public DateTime LastAccessTime { get; private set; }

		public HotCacheItem(TKey key, TValue value)
		{
			Key = key;
			_value = value;
			LastAccessTime = DateTime.Now;
		}
	}
}
