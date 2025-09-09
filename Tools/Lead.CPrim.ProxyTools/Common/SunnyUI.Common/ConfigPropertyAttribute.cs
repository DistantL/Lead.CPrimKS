using System;

namespace Sunny.UI
{
	[AttributeUsage(AttributeTargets.Property)]
	public class ConfigPropertyAttribute : Attribute
	{
		public string Caption { get; }

		public string Unit { get; }

		public string Description { get; }

		public ConfigPropertyAttribute(string caption, string description = "", string unit = "")
		{
			Caption = caption;
			Unit = unit;
			Description = description;
		}
	}
}
