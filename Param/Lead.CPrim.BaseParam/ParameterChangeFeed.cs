using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Lead.CPrim.BaseParam
{
    /// <summary>只记录显式赋值。原地修改运行列表不会进入此快照队列。</summary>
    public sealed class ParameterChangeFeed
    {
        public object SyncRoot { get; private set; }
        private long version;
        private readonly Dictionary<string, Tuple<long, XElement>> latest = new Dictionary<string, Tuple<long, XElement>>();
        public ParameterChangeFeed(object syncRoot) { SyncRoot = syncRoot; }
        public long Version { get { lock (SyncRoot) return version; } }
        public void Reset() { lock (SyncRoot) { version++; latest.Clear(); } }
        public void Publish(Property property)
        {
            lock (SyncRoot)
                latest[property.Name] = Tuple.Create(++version, new XElement(property.PropToXElment()));
        }
        public void Drain(ref long cursor, Action<Property> apply)
        {
            lock (SyncRoot)
            {
                long previous = cursor;
                foreach (var item in latest.Values.Where(p => p.Item1 > previous).OrderBy(p => p.Item1).ToArray())
                    apply((Property)new XElement(item.Item2));
                cursor = version;
            }
        }
        public static Property Clone(Property property) { return (Property)new XElement(property.PropToXElment()); }
        public static Property Assign(Property runtime, XElement snapshot, string[] path, object value)
        {
            var leaf = runtime;
            var node = snapshot;
            foreach (string name in path)
            {
                leaf = ((List<Property>)leaf.Value).First(p => p.Name == name);
                node = node.Element("Value").Elements().First(p => (string)p.Element("Name") == name);
            }
            var candidate = (Property)new XElement(node);
            if (candidate.valType == DataType.Other)
                throw new NotSupportedException("Other 参数没有定义可同步的值类型。");
            candidate.Value = value is MyPropList proxy ? proxy.PropertyList : value;
            var serialized = candidate.PropToXElment();
            var validated = (Property)serialized;
            leaf.Value = candidate.Value;
            node.Element("Value").ReplaceWith(new XElement(serialized.Element("Value")));
            return (Property)new XElement(snapshot);
        }

        /// <summary>显式子属性赋值使用路径代理，不将整棵运行对象的原地变化误当成赋值。</summary>
        public static MyPropList Proxy(List<Property> properties, Action<string[], object> assign, string[] path = null)
        {
            return new MyPropList
            {
                PropertyList = properties,
                ExplicitSetter = (name, value) => assign((path ?? new string[0]).Concat(new[] { name }).ToArray(), value),
                NestedGetter = (name, children) => Proxy(children, assign, (path ?? new string[0]).Concat(new[] { name }).ToArray())
            };
        }
    }
}
