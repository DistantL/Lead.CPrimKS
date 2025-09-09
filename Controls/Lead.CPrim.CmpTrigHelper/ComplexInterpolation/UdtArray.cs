namespace Lead.CPrim.CmpTrigHelper.ComplexInterpolation
{
	public class UdtArray
	{
		public double[] PosArray { get; set; }

		public int AxisCnt { get; set; }

		public int ArrayLength { get; set; }

		public string Name { get; set; }

		public UdtArray(int axisCnt)
		{
			PosArray = new double[AxisCnt];
		}
	}
}
