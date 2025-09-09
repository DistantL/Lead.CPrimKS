using System;

namespace Sunny.UI
{
	[AttributeUsage(AttributeTargets.Property)]
	public class ConfigSectionAttribute : Attribute
	{
		public string Section { get; }

		public ConfigSectionAttribute(string section)
		{
			Section = section;
		}
	}
}
