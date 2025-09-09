using System;

namespace Sunny.UI
{
	[AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
	public class DisplayTextAttribute : Attribute
	{
		public static readonly DisplayTextAttribute Default = new DisplayTextAttribute();

		public string DisplayText { get; }

		public DisplayTextAttribute()
			: this(string.Empty)
		{
		}

		public DisplayTextAttribute(string text)
		{
			DisplayText = text;
		}

		public override bool Equals(object obj)
		{
			DisplayTextAttribute displayTextAttribute = obj as DisplayTextAttribute;
			return displayTextAttribute != null && DisplayText.Equals(displayTextAttribute.DisplayText);
		}

		public override int GetHashCode()
		{
			return DisplayText.GetHashCode();
		}

		public override bool IsDefaultAttribute()
		{
			return Equals(Default);
		}
	}
}
