namespace Lead.CPrim.Interfaces.RFID
{
	/// <summary>RFID接口</summary>
	public interface IRFIDYouShang
	{
		/// <summary>RFID断开</summary>
		void DisConnectRfid();
		/// <summary>RFID上使能</summary>
		/// <param name="rfidIndex">RF1=>0；RF2=>1；RF3=>2；RF4=>3；</param>
		/// <returns>0：成功；非0：失败；</returns>
		int EnableRfid(int rfidIndex);
		/// <summary>RFID下使能</summary>
		/// <returns>0：成功；非0：失败；</returns>
		int DisEnableRfid();
		/// <summary>RFID写入</summary>
		/// <param name="rfidIndex">RF1=>0；RF2=>1；RF3=>2；RF4=>3；</param>
		/// <param name="dataStr">写入字符串</param>
		/// <returns>0：成功；非0：失败；</returns>
		int WriteRifd(int rfidIndex, string dataStr);
		/// <summary>RFID读取</summary>
		/// <param name="rfidIndex">RF1=>0；RF2=>1；RF3=>2；RF4=>3；</param>
		/// <param name="dataLength">读取长度</param>
		/// <returns>0：成功；非0：失败；</returns>
		string ReadRfid(int rfidIndex, ushort dataLength);
		/// <summary>RFID清除</summary>
		/// <param name="rfidIndex">RF1=>0；RF2=>1；RF3=>2；RF4=>3；</param>
		/// <param name="clearDataLength">清除长度</param>
		/// <returns>0：成功；非0：失败；</returns>
		int ClearRfid(int rfidIndex, ushort clearDataLength);
	}
}
