using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 生产者-消费者模型基类<br/>
    /// </summary>
    public abstract class ProducerConsumerModelBase
    {
        /// <summary>
        /// 启动
        /// </summary>
        public abstract void Start();
        /// <summary>
        /// 停止
        /// </summary>
        public abstract void Stop();
    }
}
