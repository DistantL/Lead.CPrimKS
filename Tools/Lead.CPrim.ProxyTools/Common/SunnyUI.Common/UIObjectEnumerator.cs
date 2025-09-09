using System.Collections;

namespace Sunny.UI
{
	public class UIObjectEnumerator
	{
		private readonly IEnumerator baseEnumerator;

		private readonly IEnumerable temp;

		public object Current => baseEnumerator.Current;

		internal UIObjectEnumerator(UIObjectCollection mappings)
		{
			temp = mappings;
			baseEnumerator = temp.GetEnumerator();
		}

		public bool MoveNext()
		{
			return baseEnumerator.MoveNext();
		}

		public void Reset()
		{
			baseEnumerator.Reset();
		}
	}
}
