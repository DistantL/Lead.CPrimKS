using System;

namespace Sunny.UI
{
	[AttributeUsage(AttributeTargets.Property)]
	public class ConfigIndexAttribute : Attribute
	{
		public int Index { get; }

		public bool Show { get; }

		public ConfigIndexAttribute(int index, bool show = true)
		{
			Index = index;
			Show = show;
		}
	}
}
