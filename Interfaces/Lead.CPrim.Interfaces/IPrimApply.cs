namespace Lead.CPrim.Interfaces
{
	//串口通讯
    /// <summary>校验位</summary>
    public enum ParityMode
	{
		None,
		/// <summary>奇</summary>
		Odd,
		/// <summary>偶</summary>
		Even
	}


	//PrimVarManager
	/// <summary>读写权限</summary>
	public enum DataPermission
	{
		/// <summary>只读</summary>
		R,
		/// <summary>只写</summary>
		W,
		/// <summary>读写</summary>
		RW,
		/// <summary>Other</summary>
		Other
	}
	/// <summary>数据读取模式</summary>
	public enum DataReadMode
	{
		/// <summary>循环</summary>
		Cycle,
		/// <summary>不循环</summary>
		NonCycle,
		/// <summary>队列</summary>
		Queue,
		/// <summary>Other</summary>
		Other
	}


	//MongodbHelper
	/// <summary>数据排序</summary>
	public enum DataSort
	{
		/// <summary>升序</summary>
		Ascending,
		/// <summary>降序</summary>
		Descending,
		/// <summary>Other</summary>
		Other,
	}
	/// <summary>时间排序</summary>
	public enum TimeOrder
	{
		/// <summary>大于</summary>
		Gt,
		/// <summary>大于等于</summary>
		Gte,
		/// <summary>等于</summary>
		Eq,
		/// <summary>小于</summary>
		Lt,
		/// <summary>小于等于</summary>
		Lte,
		/// <summary>不等于</summary>
		Ne,
		/// <summary>其它</summary>
		Other,
	}




	public enum DataNotifyMode
	{
		EventNotify,
		ReadNotify,
		Other
	}
	public enum DataKeep
	{
		Enable = 0,
		UnEnable = 1,
		Other = 100
	}
	public enum DataChangedNotify
	{
		Registered,
		Any,
		Other
	}
	public enum DataRWProp
	{
		ReadWrite = 0,
		ReadOnly = 1,
		WriteOnly = 2,
		Other = 100
	}
	public enum DataUse
	{
		Enable = 0,
		UnEnable = 1,
		Other = 100
	}
	/// <summary>硬件归属</summary>
	public enum PrimManufacture
	{
		Delta = 0,
		Mitsubish = 1,
		Omron = 2,
		Ifm = 3,
		Epson = 4,
		Basler = 5,
		Beckhoff = 6,
		Codesys = 7,
		EH = 8,
		Hikon = 9,
		Lead = 10,
		Keyence = 11,
        Inovance,

        Other = 1000
	}
	public enum RunMode
	{
		ManualRun = 1,
		AutoRun = 2,
		Other = 100
	}
	public enum TCType
	{
		Trigger = 0,
		Cycle = 1,
		Other = 100
	}
}
