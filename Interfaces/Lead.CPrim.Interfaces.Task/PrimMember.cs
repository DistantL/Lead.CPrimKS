using Newtonsoft.Json;

namespace Lead.CPrim.Interfaces
{
	public enum PrimMemberType
	{
		MotionCard,
		Robot,
		Protocol,
		Vision,
		VpAssemble,
		VpDetector,
		Sql,
		StationClient,
		StationServer,
		SqlInServer,
		Other
	}



	[JsonObject(/*Could not decode attribute arguments.*/)]
	public struct PrimMember
	{
		#region Prop
		/// <summary>基元接口</summary>
		[JsonIgnore]
		public IPrim Prim { get; set; }
		/// <summary>基元名称</summary>
		public string PrimName { get; set; }
		/// <summary>基元类型</summary>
		public PrimMemberType PrimType { get; set; } 
		#endregion


		#region Ctor
		/// <summary>Ctor</summary>
		/// <param name="primName"></param>
		/// <param name="primType"></param>
		/// <param name="prim"></param>
		public PrimMember(string primName, PrimMemberType primType, IPrim prim)
		{
			PrimName = primName;
			PrimType = primType;
			Prim = prim;
		} 
		#endregion
	}
}
