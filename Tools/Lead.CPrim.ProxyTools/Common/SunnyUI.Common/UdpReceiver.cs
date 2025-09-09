using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Sunny.UI
{
    public class UdpReceiver : BackgroundWorkerEx
	{
		private UdpClient _socket;

		private IPEndPoint remoteHost;

		public byte[] LastBytes;

		public ConcurrentQueue<byte[]> Datas = new ConcurrentQueue<byte[]>();

		public int Port { get; set; }

		public int DataLength { get; set; }

		public bool Connected { get; set; }

		public int Count => Datas.Count;

		protected override void InitStart()
		{
			try
			{
				_socket = new UdpClient(Port)
				{
					Client = 
					{
						ReceiveBufferSize = 1048576
					}
				};
				remoteHost = new IPEndPoint(IPAddress.Any, 0);
				Connected = true;
			}
			catch
			{
				_socket = null;
				Connected = false;
			}
			base.WorkerDelay = 0u;
		}

		protected override void BeforeStop()
		{
			if (Connected)
			{
				Connected = false;
				Thread.Sleep(100);
				_socket.Close();
				_socket = null;
			}
			Clear();
		}

		protected override void FinalStop()
		{
		}

		protected override void DoCompleted()
		{
		}

		protected override void DoWorker()
		{
			try
			{
				if (Connected && _socket != null && _socket.Available > 0 && _socket.Client != null)
				{
					byte[] array = _socket.Receive(ref remoteHost);
					if (DataLength == 0 || array.Length == DataLength)
					{
						Datas.Enqueue(array);
					}
					LastBytes = (byte[])array.Clone();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void Clear()
		{
			while (Datas.Count > 0)
			{
				Datas.TryDequeue(out var _);
			}
		}
	}
}
