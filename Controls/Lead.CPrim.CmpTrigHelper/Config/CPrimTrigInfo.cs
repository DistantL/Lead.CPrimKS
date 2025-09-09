using System.Collections.Generic;

namespace Lead.CPrim.CmpTrigHelper.ConfigClass
{
	public class CPrimTrigInfo
	{
		public string Name { get; set; }

		public int trigNum { get; set; } = 0;


		public List<double> trigPointTable { get; set; } = new List<double>();

	}
}
