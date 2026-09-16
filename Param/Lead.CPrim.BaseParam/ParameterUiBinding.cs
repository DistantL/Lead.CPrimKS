using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Lead.CPrim.BaseParam
{
    /// <summary>合并显式赋值刷新，不读取运行对象；保存/启用编辑前可同步排空。</summary>
    public sealed class ParameterUiBinding
    {
        private readonly Control owner;
        private readonly PropertyGrid grid;
        private readonly ParameterChangeFeed feed;
        private readonly Func<IEnumerable<Property>> properties;
        private readonly Action refreshed;
        private readonly int uiThread = Thread.CurrentThread.ManagedThreadId;
        private long cursor;
        private int queued;
        public ParameterUiBinding(Control owner, PropertyGrid grid, ParameterChangeFeed feed,
            Func<IEnumerable<Property>> properties, Action refreshed = null)
        {
            this.owner = owner; this.grid = grid; this.feed = feed;
            this.properties = properties; this.refreshed = refreshed;
            owner.HandleCreated += (s, e) => Flush();
            grid.Enter += (s, e) => Flush();
            grid.MouseDown += (s, e) => Flush();
        }
        public void AcceptLoaded() { cursor = feed.Version; }
        public void RequestRefresh()
        {
            if (owner.IsDisposed) return;
            if (Thread.CurrentThread.ManagedThreadId == uiThread) { Flush(); return; }
            if (!owner.IsHandleCreated || Interlocked.Exchange(ref queued, 1) != 0) return;
            try
            {
                owner.BeginInvoke(new Action(() => { Interlocked.Exchange(ref queued, 0); if (!owner.IsDisposed) Flush(); }));
            }
            catch (InvalidOperationException) { Interlocked.Exchange(ref queued, 0); }
        }
        public void Flush()
        {
            if (Thread.CurrentThread.ManagedThreadId != uiThread)
                throw new InvalidOperationException("参数界面同步必须在 UI 线程执行。");
            bool changed = false;
            feed.Drain(ref cursor, snapshot =>
            {
                var item = properties().FirstOrDefault(p => p.Name == snapshot.Name);
                if (item == null) return;
                item.Value = snapshot.Value;
                changed = true;
            });
            if (changed) { grid.Refresh(); refreshed?.Invoke(); }
        }
    }
}
