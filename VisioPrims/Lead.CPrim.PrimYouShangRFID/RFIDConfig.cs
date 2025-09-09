using System;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimYouShangRFID
{
	public class RFIDConfig
	{
		public bool PrimDebug { get; set; }

		public EncodingType TransEncodingType { get; set; } = EncodingType.UTF8;


		public bool LogEnable { get; set; }

		public Guid Id { get; set; }

		public string Name { get; set; }

		public bool PrimEnable { get; set; }

		public PrimType HSType { get; set; }

		public string PrimTypeName { get; set; }

		public PrimConnState PrimConnStat { get; set; }

		public PrimRunState PrimRunStat { get; set; }

		public PrimVer Ver { get; set; }

		public int CurrentImageIndex { get; set; } = -1;


		public string Ip { get; set; }

		public int Port { get; set; }

		public int ReTries { get; set; }
	}
}
