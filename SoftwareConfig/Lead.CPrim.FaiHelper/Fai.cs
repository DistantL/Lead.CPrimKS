namespace Lead.CPrim.FaiHelper
{
	/// <summary>
	/// 基础FAI配置
	/// </summary>
	public class Fai
	{
		public int Index { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 标称值
		/// </summary>
		public double Norminal { get; set; }

		/// <summary>
		/// 上公差
		/// </summary>
		public double TolUp { get; set; }

		/// <summary>
		/// 下公差
		/// </summary>
		public double TolLow { get; set; }

		/// <summary>
		/// 补偿后的值
		/// </summary>
		public double Value { get; set; }

		public Fai(string name, double faiValue, double normal, double tolUp, double tolLow, int index)
		{
			Name = name;
			Value = faiValue;
			Norminal = normal;
			TolUp = tolUp;
			TolLow = tolLow;
			Index = index;
		}
	}
}
