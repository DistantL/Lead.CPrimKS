namespace Lead.CPrim.StationCommon.MainOutput
{
	/// <summary>
	/// 主界面界面表格数据
	/// </summary>
	public class PrimOutputConfig
	{
		#region Prop
		/// <summary>名称</summary>
		public string Name { get; set; }
		/// <summary>使能</summary>
		public bool Enable { get; set; }
		/// <summary>行数</summary>
		public int RowNum { get; set; }
		/// <summary>列数</summary>
		public int ColNum { get; set; }
		/// <summary>跨行</summary>
		public int RowSpan { get; set; }
		/// <summary>跨列</summary>
		public int ColSpan { get; set; }
		#endregion


		#region Ctor
		public PrimOutputConfig()
		{
			Name = "";
			Enable = false;
			RowNum = 0;
			RowSpan = 0;
			ColNum = 0;
			ColSpan = 0;
		}
		#endregion


		#region Other
		/// <summary>返回主界面界面表格数据当前行名称</summary>
		/// <returns></returns>
		public override string ToString()
		{
			return Name;
		} 
		#endregion
	}
}
