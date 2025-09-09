using Newtonsoft.Json;

namespace Lead.CPrim.Interfaces
{
	public enum EleMemberType
	{
		AxisLine = 0,
		Cartesian = 1,
		CyldLine = 2,
		Led = 4,
		DI = 5,
		DO = 6,
		SysLight = 7,
		Vacuum = 8,
		AbnormalDI = 9,
		START = 10,
		PAUSE = 11,
		STOP = 12,
		RESET = 13,
		AUTO = 14,
		LOCK = 0xF,
		EMG = 17,
		Other = 100
	}



	[JsonObject(/*Could not decode attribute arguments.*/)]
	public struct EleMember
	{
		[JsonIgnore]
		public IEle Ele { get; set; }

		public string EleName { get; set; }

		public EleMemberType EleType { get; set; }

		public EleMember(string eleName, EleMemberType eleType, IEle ele)
		{
			EleName = eleName;
			EleType = eleType;
			Ele = ele;
		}
	}
}
