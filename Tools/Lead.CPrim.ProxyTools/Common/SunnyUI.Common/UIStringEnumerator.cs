using System.Collections;

namespace Sunny.UI
{
	public class UIStringEnumerator
	{
		private readonly IEnumerator baseEnumerator;

		private readonly IEnumerable temp;

		public string Current => (string)baseEnumerator.Current;

		internal UIStringEnumerator(UIStringCollection mappings)
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
