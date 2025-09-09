using System;
using System.Collections;

namespace Sunny.UI
{
	[Serializable]
	public class UIObjectCollection : IList, ICollection, IEnumerable
	{
		private ArrayList data = new ArrayList();

		public object this[int index]
		{
			get
			{
				return data[index];
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
				this[index] = value;
			}
		}

		public event EventHandler CountChange;

		public int Add(object value)
		{
			int result = data.Add(value);
			this.CountChange?.Invoke(this, new EventArgs());
			return result;
		}

		public void AddRange(object[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value is null");
			}
			data.AddRange(value);
			this.CountChange?.Invoke(this, new EventArgs());
		}

		public void Clear()
		{
			data.Clear();
			this.CountChange?.Invoke(this, new EventArgs());
		}

		public bool Contains(object value)
		{
			return data.Contains(value);
		}

		public void CopyTo(object[] array, int index)
		{
			data.CopyTo(array, index);
		}

		public UIObjectEnumerator GetEnumerator()
		{
			return new UIObjectEnumerator(this);
		}

		public int IndexOf(object value)
		{
			return data.IndexOf(value);
		}

		public void Insert(int index, object value)
		{
			data.Insert(index, value);
			this.CountChange?.Invoke(this, new EventArgs());
		}

		public void Remove(object value)
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
			int result = Add(value);
			this.CountChange?.Invoke(this, new EventArgs());
			return result;
		}

		bool IList.Contains(object value)
		{
			return Contains(value);
		}

		int IList.IndexOf(object value)
		{
			return IndexOf(value);
		}

		void IList.Insert(int index, object value)
		{
			Insert(index, value);
			this.CountChange?.Invoke(this, new EventArgs());
		}

		void IList.Remove(object value)
		{
			Remove(value);
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
