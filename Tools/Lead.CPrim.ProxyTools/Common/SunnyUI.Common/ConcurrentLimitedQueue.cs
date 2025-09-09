using System.Collections.Concurrent;

namespace Sunny.UI
{
	public class ConcurrentLimitedQueue<T> : ConcurrentQueue<T>
	{
		public int Limit { get; set; }

		public ConcurrentLimitedQueue(int limit)
		{
			Limit = limit;
		}

		public new void Enqueue(T item)
		{
			if (base.Count >= Limit)
			{
				TryDequeue(out var _);
			}
			base.Enqueue(item);
		}
	}
}
