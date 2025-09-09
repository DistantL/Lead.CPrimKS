using System;

namespace Sunny.UI
{
	[AttributeUsage(AttributeTargets.Class)]
	public class ConfigFileAttribute : Attribute
	{
		public string FileName { get; }

		public string Description { get; }

		public ConfigFileAttribute()
			: this(string.Empty, string.Empty)
		{
		}

		public ConfigFileAttribute(string fileName, string description = "")
		{
			FileName = fileName;
			Description = description;
		}
	}
}
