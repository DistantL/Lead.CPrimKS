using System;
using Lead.CPrim.Interfaces.Dev;

namespace Lead.CPrim.PrimKeyencePLC.CommonModule
{
	public class PlcSendStruct
	{
		public string sendStr;

		public string plcSoftAddr;

		public int sendTimes;

		public PLCRespons plcRespons;

		public PlcSendStruct()
		{
			this.sendStr = "";
			this.plcSoftAddr = "";
			this.sendTimes = 0;
			this.plcRespons = PLCRespons.None;
		}
	}
}
