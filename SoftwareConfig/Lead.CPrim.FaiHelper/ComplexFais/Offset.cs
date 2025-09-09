namespace Lead.CPrim.FaiHelper.ComplexFais
{
	public class Offset
	{
		public int Index { get; set; }

		public double Compensation { get; set; } = 0.0;


		public double CompensationFactor { get; set; } = 1.0;


		public Offset()
		{
			Index = 0;
			Compensation = 0.0;
			CompensationFactor = 0.0;
		}

		public Offset(int index)
		{
			Index = index;
		}
	}
}
