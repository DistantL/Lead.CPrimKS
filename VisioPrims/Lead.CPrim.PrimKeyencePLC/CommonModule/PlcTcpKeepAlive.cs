using System;

namespace Lead.CPrim.PrimKeyencePLC.CommonModule
{
	internal class PlcTcpKeepAlive
	{
		public bool Enable
		{
			get;
			set;
		}

		public int KeepAliveTime
		{
			get;
			set;
		}

		public int KeepAliveInterval
		{
			get;
			set;
		}

		public byte[] KeepAliveValue
		{
			get
			{
				byte[] array = new byte[12];
				BitConverter.GetBytes(this.Enable ? 1 : 0).CopyTo(array, 0);
				BitConverter.GetBytes(this.KeepAliveTime).CopyTo(array, 4);
				BitConverter.GetBytes(this.KeepAliveInterval).CopyTo(array, 8);
				return array;
			}
		}

		public PlcTcpKeepAlive(bool enable = true, int keepAliveTime = 3000, int keepAliveInterval = 1000)
		{
			this.Enable = enable;
			this.KeepAliveTime = keepAliveTime;
			this.KeepAliveInterval = keepAliveInterval;
		}
	}
}
