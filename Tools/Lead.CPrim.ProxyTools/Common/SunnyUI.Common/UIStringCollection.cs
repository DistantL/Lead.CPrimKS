using System;
using System.Collections;

namespace Sunny.UI
{
	[Serializable]
	public class UIStringCollection : IList, ICollection, IEnumerable
	{
		private ArrayList data = new ArrayList();

		public string this[int index]
		{
			get
			{
				return (string)data[index];
			}
			set
			{
				data[index] = value;
			}
		}

		public int Count => data.Count;

		bool IList.IsReadOnly => false;

		bool IList.IsFixedSize => false;

		public bool IsReadOnly => false;

		public bool IsSynchronized => false;

		public object SyncRoot => data.SyncRoot;

		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				this[index] = (string)value;
			}
		}

		public event EventHandler CountChange;

		public int Add(string value)
		{
			int result = data.Add(value);
			this.CountChange?.Invoke(this, new EventArgs());
			return result;
		}

		public void AddRange(string[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			data.AddRange(value);
			this.CountChange?.Invoke(this, new EventArgs());
		}

		public void Clear()
		{
			data.Clear();
			this.CountChange?.Invoke(this, new EventArgs());
		}

		public bool Contains(string value)
		{
			return data.Contains(value);
		}

		public void CopyTo(string[] array, int index)
		{
			data.CopyTo(array, index);
		}

		public UIStringEnumerator GetEnumerator()
		{
			return new UIStringEnumerator(this);
		}

		public int IndexOf(string value)
		{
			return data.IndexOf(value);
		}

		public void Insert(int index, string value)
		{
			data.Insert(index, value);
			this.CountChange?.Invoke(this, new EventArgs());
		}

		public void Remove(string value)
		{
			data.Remove(value);
			this.CountChange?.Invoke(this, new EventArgs());
		}

		public void RemoveAt(int index)
		{
			data.RemoveAt(index);
			this.CountChange?.Invoke(this, new EventArgs());
		}

		int IList.Add(object value)
		{
			int result = Add((string)value);
			this.CountChange?.Invoke(this, new EventArgs());
			return result;
		}

		bool IList.Contains(object value)
		{
			return Contains((string)value);
		}

		int IList.IndexOf(object value)
		{
			return IndexOf((string)value);
		}

		void IList.Insert(int index, object value)
		{
			Insert(index, (string)value);
			this.CountChange?.Invoke(this, new EventArgs());
		}

		void IList.Remove(object value)
		{
			Remove((string)value);
			this.CountChange?.Invoke(this, new EventArgs());
		}

		void ICollection.CopyTo(Array array, int index)
		{
			data.CopyTo(array, index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return data.GetEnumerator();
		}
	}
}
