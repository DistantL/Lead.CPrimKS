using System;

namespace Sunny.UI
{
	public class NListEventArgs<T> : EventArgs
	{
		public T Item { get; set; }

		public int Index { get; set; }

		public NListEventArgs(T item, int index)
		{
			Item = item;
			Index = index;
		}
	}
}
