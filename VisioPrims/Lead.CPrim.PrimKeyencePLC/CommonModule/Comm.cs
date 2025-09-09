using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO.Ports;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Lead.CPrim.PrimKeyencePLC.CommonModule
{
	public class Comm
	{
		private static int m_commId = -1;

		private static ConcurrentDictionary<int, IComm> m_dic = new ConcurrentDictionary<int, IComm>();

		private static object m_lockObj = new object();

		private Comm()
		{
		}

		public static int OpenTcpClient(string ip, int port)
		{
			object lockObj = Comm.m_lockObj;
			int commId;
			lock (lockObj)
			{
				try
				{
					string name = string.Format("{0}:{1}", ip, port);
					PlcTcpClient gtkTcpClient = new PlcTcpClient();
					gtkTcpClient.Hostname = ip;
					gtkTcpClient.Port = port;
					gtkTcpClient.Name = name;
					gtkTcpClient.Open();
					Comm.m_dic.GetOrAdd(++Comm.m_commId, gtkTcpClient);
					commId = Comm.m_commId;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			return commId;
		}

		public static void Close(int commId)
		{
			object lockObj = Comm.m_lockObj;
			lock (lockObj)
			{
				try
				{
					IComm iComm = Comm.GetIComm(commId);
					iComm.Close();
					IComm comm = null;
					Comm.m_dic.TryRemove(commId, out comm);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		public static bool IsConnected(int commId)
		{
			bool isConnected;
			try
			{
				IComm iComm = Comm.GetIComm(commId);
				isConnected = iComm.IsConnected;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return isConnected;
		}

		public static EndPoint ReadLocPoint(int commId)
		{
			EndPoint result;
			try
			{
				IComm iComm = Comm.GetIComm(commId);
				bool flag = iComm.GetType() == typeof(PlcTcpClient);
				if (flag)
				{
					PlcTcpClient gtkTcpClient = (PlcTcpClient)iComm;
					result = gtkTcpClient.LocPoint;
				}
				else
				{
					result = null;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}

		public static void Send(int commId, byte[] buffer)
		{
			try
			{
				IComm iComm = Comm.GetIComm(commId);
				iComm.Send(buffer);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static void Send(int commId, string str)
		{
			try
			{
				IComm iComm = Comm.GetIComm(commId);
				iComm.Send(str);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static void Send(int commId, string str, Encoding encoding)
		{
			try
			{
				IComm iComm = Comm.GetIComm(commId);
				iComm.Send(str, encoding);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static int GetDataLength(int commId)
		{
			int dataLength;
			try
			{
				IComm iComm = Comm.GetIComm(commId);
				dataLength = iComm.DataLength;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return dataLength;
		}

		public static byte[] PreviewBuffer(int commId, int length = -1)
		{
			byte[] result;
			try
			{
				IComm iComm = Comm.GetIComm(commId);
				result = iComm.PreviewBuffer(length);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}

		public static byte[] PopBuffer(int commId, int length = -1)
		{
			byte[] result;
			try
			{
				IComm iComm = Comm.GetIComm(commId);
				result = iComm.PopBuffer(length);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}

		private static IComm GetIComm(int commId)
		{
			IComm result = null;
			bool flag = Comm.m_dic.ContainsKey(commId);
			if (flag)
			{
				while (!Comm.m_dic.TryGetValue(commId, out result))
				{
					Thread.Sleep(1);
				}
				return result;
			}
			throw new ArgumentOutOfRangeException("commId");
		}

		private static void AddIComm(int index, IComm comm)
		{
			while (!Comm.m_dic.TryAdd(index, comm))
			{
				Thread.Sleep(1);
			}
			Console.WriteLine("===========" + index);
		}
	}
}
