namespace Sunny.UI
{
	public interface IHotCacheItemCreator<TKey, TValue>
	{
		TValue Run(TKey key);
	}
}
