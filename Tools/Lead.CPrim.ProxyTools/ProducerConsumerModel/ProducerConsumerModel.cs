using Lead.CPrim.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 生产者-消费者模型<br/>
    /// 文件写入同步服务<br/>
    /// </summary>
    public class ProducerConsumerModel : ProducerConsumerModelBase
    {
        #region Field
        static ProducerConsumerModel _instance = new ProducerConsumerModel();

        /// <summary>
        /// 取消
        /// </summary>
        CancellationTokenSource _cts;

        /// <summary>
        /// 集合
        /// </summary>
        BlockingCollection<ModelMessage> _messages;

        /// <summary>
        /// 工作线程
        /// </summary>
        Thread _threadWork;

        /// <summary>
        /// 线程锁
        /// </summary>
        static readonly object _objThread = new object();
        #endregion



        #region Prop
        public static ProducerConsumerModel Instance => _instance;

        /// <summary>
        /// 运行中
        /// </summary>
        public bool IsRunning
        {
            get
            {
                return _threadWork != null && _threadWork.ThreadState == ThreadState.Running;
            }
        }
        #endregion



        #region MethodExternalUsing
        /// <summary>
        /// 添加-生产者
        /// </summary>
        /// <param name="message"></param>
        public void Add(ModelMessage message)
        {
            if (!IsRunning)
            {
                Start();
            }

            _messages.Add(message);
        }
        /// <summary>
        /// 数据处理
        /// </summary>
        /// <param name="message"></param>
        /// <param name="token"></param>
        public virtual void Working(ModelMessage message, CancellationToken token)
        {
            if (message == null)
            {
                return;
            }

            List<string> strings = new List<string>();
            FileInfo info = new FileInfo(message.Path);
            if (!info.Exists && !string.IsNullOrEmpty(message.Title))
            {
                strings.Add(message.Title);
            }

            if (message.IsStringBuilder)
            {
                if (message.ContentsStringBuilder.IsNullOrEmpty())
                {
                    return;
                }

                foreach (var builder in message.ContentsStringBuilder)
                {
                    strings.Add(builder.ToString());
                }
            }
            else
            {
                if (message.ContentsString.IsNullOrEmpty())
                {
                    return;
                }

                strings.AddRange(message.ContentsString);
            }

            token.ThrowIfCancellationRequested();

            switch (message.ModelFormat)
            {
                case ModelFormat.CSV:
                    {
                        CsvHelper.WriteListStringToCsv(message.Path, strings, message.IsReadOnly);
                    }
                    break;

                default:
                    break;
            }
        }
        public override void Start()
        {
            lock (_objThread)
            {
                if (IsRunning)
                {
                    return;
                }

                _cts ??= new CancellationTokenSource();
                _messages ??= new BlockingCollection<ModelMessage>();
                if (_threadWork == null)
                {
                    _threadWork = new Thread(() => ThreadJob(_cts.Token));
                    _threadWork.IsBackground = true;
                    _threadWork.Start();
                }
            }
        }
        public override void Stop()
        {
            _cts.Cancel();
            _threadWork.Join();
            _cts.Dispose();
            _cts = null;
            _threadWork = null;
        }
        #endregion



        #region MyRegion
        /// <summary>
        /// 线程-消费者
        /// </summary>
        /// <param name="token"></param>
        void ThreadJob(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (_messages.TryTake(out var message, Timeout.Infinite, token))
                    {
                        Working(message, token);
                    }
                }
                catch (OperationCanceledException)
                {
                    LogHelper.LogAdd(LogLevel.Debug, $"{nameof(ProducerConsumerModel)}被终止", LogClassification.Tools.ToString());
                }
                catch (Exception ex)
                {
                    LogHelper.LogAdd(LogLevel.Debug, $"{nameof(ProducerConsumerModel)}.{nameof(ThreadJob)}：{ex.Message}：{ex.StackTrace}", LogClassification.Tools.ToString());
                }
            }
        }
        #endregion
    }
}
