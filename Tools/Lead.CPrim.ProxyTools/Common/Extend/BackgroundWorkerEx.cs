using System;
using System.ComponentModel;
using System.Threading;

namespace Lead.CPrim.ProxyTools
{
	public abstract class BackgroundWorkerEx
	{
		private readonly BackgroundWorker _worker;

		public bool RunOnce { get; set; }

		public bool IsStart { get; private set; }

		public uint WorkerDelay { get; set; } = 100u;


		public event EventHandler OnCompleted;

		protected BackgroundWorkerEx()
		{
			_worker = new BackgroundWorker
			{
				WorkerSupportsCancellation = true
			};
			_worker.DoWork += WorkerDoWork;
			_worker.RunWorkerCompleted += RunWorkerCompleted;
		}

		private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			DoCompleted();
			OnCompleted?.Invoke(sender, e);
		}

		protected abstract void DoWorker();

		protected virtual void DoCompleted()
		{
		}

		~BackgroundWorkerEx()
		{
			BeforeStop();
			FinalStop();
		}

		private void WorkerDoWork(object sender, DoWorkEventArgs e)
		{
			if (RunOnce)
			{
				DoOnce();
				return;
			}
			while (IsStart)
			{
				if (_worker.CancellationPending)
				{
					e.Cancel = true;
					break;
				}
				DoWorker();
				Thread.Sleep((int)WorkerDelay);
				Thread.Yield();
			}
		}

		private void DoOnce()
		{
			DoWorker();
			IsStart = false;
			BeforeStop();
			FinalStop();
		}

		protected virtual void InitStart()
		{
		}

		protected virtual void FinalStop()
		{
		}

		protected virtual void BeforeStop()
		{
		}

		public void Start()
		{
			if (!IsStart)
			{
				InitStart();
				IsStart = true;
				_worker.RunWorkerAsync();
			}
		}

		public void Stop()
		{
			if (IsStart)
			{
				BeforeStop();
				IsStart = false;
				_worker.CancelAsync();
				FinalStop();
			}
		}
	}
}
