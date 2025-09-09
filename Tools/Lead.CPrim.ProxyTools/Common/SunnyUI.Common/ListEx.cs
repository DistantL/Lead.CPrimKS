using System.Collections.Generic;

namespace Sunny.UI
{
	public class ListEx<T> : List<T>
	{
		public delegate void OnListChange(object sender, T item, int index);

		public event OnListChange OnDelete;

		public event OnListChange OnAppend;

		public new void Add(T item)
		{
			base.Add(item);
			this.OnAppend?.Invoke(this, item, base.Count);
		}

		public new void Insert(int index, T item)
		{
			base.Insert(index, item);
			this.OnAppend?.Invoke(this, item, index);
		}

		public new void Remove(T item)
		{
			int index = IndexOf(item);
			base.Remove(item);
			this.OnDelete?.Invoke(this, item, index);
		}

		public new void RemoveAt(int index)
		{
			T item = base[index];
			base.RemoveAt(index);
			this.OnDelete?.Invoke(this, item, index);
		}

		public new void RemoveRange(int index, int count)
		{
			for (int i = index; i < index + count; i++)
			{
				RemoveAt(i);
			}
		}

		public new void AddRange(IEnumerable<T> collection)
		{
			int num = base.Count;
			base.AddRange(collection);
			foreach (T item in collection)
			{
				this.OnAppend?.Invoke(this, item, num);
				num++;
			}
		}

		public new void InsertRange(int index, IEnumerable<T> collection)
		{
			base.InsertRange(index, collection);
			foreach (T item in collection)
			{
				this.OnAppend?.Invoke(this, item, index);
				index++;
			}
		}
	}
}
