using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Concurrent;
using System.Net.Sockets;

namespace Sunny.UI
{
    public class UdpSender : BackgroundWorkerEx
	{
		private readonly ConcurrentQueue<byte[]> _queue = new ConcurrentQueue<byte[]>();

		public string IpAddress { get; set; }

		public int Port { get; set; }

		public int Count => _queue.Count;

		protected override void InitStart()
		{
			base.WorkerDelay = 10u;
			Clear();
		}

		protected override void FinalStop()
		{
			Clear();
		}

		protected override void BeforeStop()
		{
		}

		public void Clear()
		{
			while (_queue.Count > 0)
			{
				_queue.TryDequeue(out var _);
			}
		}

		protected override void DoWorker()
		{
			while (_queue.Count > 0)
			{
				if (_queue.TryDequeue(out var result))
				{
					SendData(result);
				}
			}
		}

		protected override void DoCompleted()
		{
		}

		public void SendData(byte[] Data)
		{
			try
			{
				UdpClient udpClient = new UdpClient(IpAddress, Port);
				udpClient.Send(Data, Data.Length);
				udpClient.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void AddData(byte[] datas)
		{
			if (base.IsStart)
			{
				_queue.Enqueue(datas);
			}
		}
	}
}
