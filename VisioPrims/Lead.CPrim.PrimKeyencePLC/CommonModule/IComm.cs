using System;
using System.Text;

namespace Lead.CPrim.PrimKeyencePLC.CommonModule
{
	internal interface IComm
	{
		string Name
		{
			get;
			set;
		}

		int DataLength
		{
			get;
		}

		bool IsConnected
		{
			get;
		}

		void Open();

		void Close();

		void Send(string str);

		void Send(byte[] buffer);

		void Send(string str, Encoding encoding);

		byte[] PreviewBuffer(int length = -1);

		byte[] PopBuffer(int length = -1);
	}
}
