using System;
using Lead.CPrim.Interfaces.Ele;

namespace Lead.CPrim.CmpTrigHelper
{
	public static class CartesianEx
	{
		public static double[] GetGearRatioArray(this IEleCartesian ele, double[] pos)
		{
			double[] array = new double[pos.Length];
			if (ele.Axises.Count < pos.Length)
			{
				throw new Exception("Function GetGearRatioArry 出错，Pos长度超出轴组轴数");
			}
			for (int i = 0; i < pos.Length; i++)
			{
				array[i] = ele.Axises[i].GearRatio * pos[i];
			}
			return array;
		}
	}
}
