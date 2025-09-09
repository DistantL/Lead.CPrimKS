using System.Collections.Generic;

namespace Sunny.UI
{
	public class Ident
	{
		public List<string> Values = new List<string>();

		public string Section { get; set; }

		public string Key { get; set; }

		public string Value { get; set; }

		public string Description { get; set; }

		public string Caption { get; set; }

		public string Unit { get; set; }

		public int Index { get; set; }

		public bool Show { get; set; }

		public bool IsList { get; set; }

		public override string ToString()
		{
			return Index + " [" + Section + "] " + Key + " = ?";
		}
	}
}
