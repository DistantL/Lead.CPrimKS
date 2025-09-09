using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Lead.CPrim.PrimKeyencePLC.CommonModule
{
	internal class PlcTcpClient : IComm
	{
		private Queue<byte> m_buffer = new Queue<byte>();

		private object m_bufferLock = new object();

		private TcpClient m_sysClient = null;

		private string m_hostname = "127.0.0.1";

		private int m_port = 6800;

		private string m_name = "TcpClient";

		private AutoResetEvent TimeoutObject = new AutoResetEvent(false);

		private EndPoint m_locPoint;

		private bool m_isConnected = false;

		private PlcTcpKeepAlive m_keepAlive = new PlcTcpKeepAlive(false, 3000, 1000);
               
		public string Hostname
		{
			get
			{
				return this.m_hostname;
			}
			set
			{
				this.m_hostname = value;
			}
		}

		public int Port
		{
			get
			{
				return this.m_port;
			}
			set
			{
				this.m_port = value;
			}
		}

		public string Name
		{
			get
			{
				return this.m_name;
			}
			set
			{
				this.m_name = value;
			}
		}

		public EndPoint LocPoint
		{
			get
			{
				return this.m_locPoint;
			}
			set
			{
				this.m_locPoint = value;
			}
		}

		public bool IsConnected
		{
			get
			{
				return this.m_isConnected;
			}
		}

		public PlcTcpKeepAlive KeepAlive
		{
			get
			{
				return this.m_keepAlive;
			}
			set
			{
				this.m_keepAlive = value;
			}
		}

		public int DataLength
		{
			get
			{
				return this.m_buffer.Count;
			}
		}

		private void threadFunc_Read()
		{
			while (true)
			{
				try
				{
					bool flag = this.m_sysClient != null && this.m_sysClient.Connected;
					if (flag)
					{
						NetworkStream stream = this.m_sysClient.GetStream();
						byte[] array = new byte[1024];
						int num = stream.Read(array, 0, array.Length);
						bool flag2 = num <= 0;
						if (flag2)
						{
							this.m_isConnected = false;
							this.Close();
							break;
						}
						object bufferLock = this.m_bufferLock;
						lock (bufferLock)
						{
							for (int i = 0; i < num; i++)
							{
								this.m_buffer.Enqueue(array[i]);
							}
						}
					}
					Thread.Sleep(1);
				}
				catch
				{
					this.m_isConnected = false;
					this.Close();
					break;
				}
			}
		}

		public void Open()
		{
			try
			{
				this.Close();
				new Thread(new ThreadStart(this.threadFunc_Read))
				{
					Name = "GtkTcpClient receive thread.",
					IsBackground = true
				}.Start();
				this.m_sysClient = new TcpClient();
				this.m_sysClient.BeginConnect(this.m_hostname, this.m_port, new AsyncCallback(this.CallBackMethod), this.m_sysClient);
				bool flag = !this.TimeoutObject.WaitOne(2000, false) || !this.m_isConnected;
				if (flag)
				{
					this.m_sysClient.Close();
					this.m_isConnected = false;
                    return;
				}
				this.m_sysClient.Client.IOControl((IOControlCode)(-1744830460L), this.m_keepAlive.KeepAliveValue, null);
				this.m_locPoint = this.m_sysClient?.Client?.LocalEndPoint;
				this.m_isConnected = true;
			}
			catch (Exception ex)
			{
				this.m_isConnected = false;
				throw ex;
			}
		}

		private void CallBackMethod(IAsyncResult asyncresult)
		{
			try
			{
				this.m_isConnected = false;
				TcpClient tcpClient = asyncresult.AsyncState as TcpClient;
				bool flag = tcpClient.Client != null;
				if (flag)
				{
					tcpClient.EndConnect(asyncresult);
					this.m_isConnected = true;
				}
			}
			catch (Exception ex)
			{
				ex.ToString();
				this.m_isConnected = false;
			}
			finally
			{
				this.TimeoutObject.Set();
			}
		}

		public void Close()
		{
			try
			{
				bool flag = this.m_sysClient != null;
				if (flag)
				{
					NetworkStream stream = this.m_sysClient.GetStream();
					bool flag2 = stream != null;
					if (flag2)
					{
						stream.Close();
					}
					this.m_sysClient.Close();
				}
			}
			catch
			{
			}
			this.m_isConnected = false;
		}

		public void Send(byte[] buffer)
		{
			try
			{
				bool flag = this.m_sysClient != null;
				if (flag)
				{
					NetworkStream stream = this.m_sysClient.GetStream();
					bool flag2 = stream != null;
					if (flag2)
					{
						stream.Write(buffer, 0, buffer.Length);
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void Send(string cmd, Encoding encoding)
		{
			byte[] array = null;
			try
			{
				array = encoding.GetBytes(cmd);
				this.Send(array);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void Send(string cmd)
		{
			this.Send(cmd, Encoding.Default);
		}

		public byte[] PreviewBuffer(int length = -1)
		{
			bool flag = length == 0;
			byte[] result;
			if (flag)
			{
				result = new byte[0];
			}
			else
			{
				byte[] array = null;
				object bufferLock = this.m_bufferLock;
				lock (bufferLock)
				{
					array = this.m_buffer.ToArray();
				}
				bool flag3 = length < 0;
				if (flag3)
				{
					result = array;
				}
				else
				{
					int num = Math.Min(length, array.Length);
					byte[] array2 = new byte[num];
					for (int i = 0; i < num; i++)
					{
						array2[i] = array[i];
					}
					result = array2;
				}
			}
			return result;
		}

		public byte[] PopBuffer(int length = -1)
		{
			bool flag = length == 0;
			byte[] result;
			if (flag)
			{
				result = new byte[0];
			}
			else
			{
				byte[] array = this.PreviewBuffer(length);
				object bufferLock = this.m_bufferLock;
				lock (bufferLock)
				{
					for (int i = 0; i < array.Length; i++)
					{
						this.m_buffer.Dequeue();
					}
				}
				result = array;
			}
			return result;
		}
	}
}
