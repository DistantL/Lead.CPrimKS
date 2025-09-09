namespace Lead.CPrim.Interfaces
{
	/// <summary>DI状态</summary>
	public class DiStatus
	{
		/// <summary>DI名称</summary>
		public string Name { get; set; }
		/// <summary>DI状态</summary>
		public bool Status { get; set; }
	}
	/// <summary>DO状态</summary>
	public class DoStatus
	{
		/// <summary>DO名称</summary>
		public string Name { get; set; }
		/// <summary>DO状态</summary>
		public bool Status { get; set; }
	}
	/// <summary>气缸状态</summary>
	public class CylStatus
	{
		/// <summary>气缸名称</summary>
		public string Name { get; set; }
		/// <summary>气缸伸位DO</summary>
		public bool StretchOut { get; set; }
		/// <summary>气缸原位DO</summary>
		public bool RestractOut { get; set; }
		/// <summary>气缸伸位DI</summary>
		public bool StretchIn { get; set; }
		/// <summary>气缸原位DI</summary>
		public bool RestractIn { get; set; }
	}
	/// <summary>轴组状态</summary>
	public class CartStatus
	{
		/// <summary>轴组名称</summary>
		public string Name { get; set; }
		/// <summary>轴组轴使能状态</summary>
		public bool[] ServoOn { get; set; }
		/// <summary>轴组轴编码器位置</summary>
		public double[] ActualPos { get; set; }
	}
}
