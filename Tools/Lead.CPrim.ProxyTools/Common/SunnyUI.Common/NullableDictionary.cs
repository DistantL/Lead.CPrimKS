using System.Collections;
using System.Collections.Generic;

namespace Sunny.UI
{
	public class NullableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		public new TValue this[TKey item]
		{
			get
			{
				TValue value;
				return TryGetValue(item, out value) ? value : default(TValue);
			}
			set
			{
				base[item] = value;
			}
		}
	}
}
