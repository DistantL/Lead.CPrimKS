using System.Collections.Generic;

namespace Sunny.UI
{
	public class LimitedQueue<T> : Queue<T>
	{
		public int Limit { get; set; }

		public LimitedQueue(int limit)
			: base(limit)
		{
			Limit = limit;
		}

		public new void Enqueue(T item)
		{
			if (base.Count >= Limit)
			{
				Dequeue();
			}
			base.Enqueue(item);
		}
	}
}
