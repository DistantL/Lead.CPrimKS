using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Lead.CPrim.BaseParam
{
    /// <summary>双向参数转移会话；回调参数始终按源文件、目标文件顺序传递。</summary>
    public sealed class ParameterTransferSession
    {
        private readonly string sourcePath;
        private readonly string targetPath;
        private byte[] sourceBytes;
        private byte[] targetBytes;
        private XElement sourceView;
        private XElement targetView;
        public void SetViewSnapshots(XElement source, XElement target)
        {
            if (HasPending) throw new InvalidOperationException("不能替换已有待转移会话的数据。");
            ValidateDocument(source); ValidateDocument(target);
            sourceView = new XElement(source); targetView = new XElement(target);
        }
        private readonly List<XElement> pending = new List<XElement>();
        public Action ValidateContext { get; set; }
        public Action<Action> CommitGuard { get; set; }
        public Action<string> ValidateTransferName { get; set; }
        public Action<XElement, XElement> ValidateDocuments { get; set; }
        public Action<XElement, XElement> RefreshCommitted { get; set; }
        public string Product { get; private set; }
        public bool ToGlobal { get; private set; }
        public bool HasPending { get { return pending.Count != 0; } }
        public bool IsFaulted { get; private set; }

        public ParameterTransferSession(string source, string target, string product)
            : this(source, target, product, false)
        {
        }

        public ParameterTransferSession(string source, string target, string product, bool toGlobal)
        {
            ToGlobal = toGlobal;
            sourcePath = Path.GetFullPath(source);
            targetPath = Path.GetFullPath(target);
            if (string.Equals(sourcePath, targetPath, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("全局参数与换型参数不能指向同一文件。");
            sourceBytes = File.ReadAllBytes(sourcePath);
            targetBytes = File.ReadAllBytes(targetPath);
            Product = product;
            ValidateDocument(Read(sourceBytes));
            ValidateDocument(Read(targetBytes));
        }

        private static XElement Read(byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes)) return XElement.Load(stream);
        }

        public string[] Groups
        {
            get { return (targetView ?? Read(targetBytes)).Elements().Concat(pending).Select(p => (string)p.Element("Category"))
                .Where(p => !string.IsNullOrWhiteSpace(p)).Distinct().ToArray(); }
        }

        public void CheckCurrent()
        {
            if (IsFaulted) throw new InvalidOperationException("此前直接保存或刷新失败，请检查文件并关闭当前窗口后重新加载，不可直接重试。");
            ValidateContext?.Invoke();
            if (!File.ReadAllBytes(sourcePath).SequenceEqual(sourceBytes)
                || !File.ReadAllBytes(targetPath).SequenceEqual(targetBytes))
                throw new InvalidOperationException("参数文件已被其他操作修改，请放弃当前编辑并重新打开。");
        }

        public void CheckName(string name)
        {
            CheckCurrent();
            if (name == "运行模式") throw new InvalidOperationException("运行模式是框架保留参数，不可转移。");
            if ((targetView ?? Read(targetBytes)).Elements().Any(p => (string)p.Element("Name") == name)
                || pending.Any(p => (string)p.Element("Name") == name))
                throw new InvalidOperationException("目标参数或待转移清单已存在同索引名称：" + name);
            ValidateTransferName?.Invoke(name);
        }

        public void Stage(XElement property, string group)
        {
            string name = (string)property.Element("Name");
            CheckName(name);
            if (string.IsNullOrWhiteSpace(group)) throw new InvalidOperationException("请选择已有分组或输入新分组名。");
            group = group.Trim();
            var copy = new XElement(property);
            copy.SetElementValue("Category", group);
            ValidateDocument(new XElement("Para", copy));
            pending.Add(copy);
        }

        public static void ValidateDocument(XElement document)
        {
            var names = new HashSet<string>(StringComparer.Ordinal);
            foreach (var node in document.Elements())
            {
                var property = (Property)node;
                if (string.IsNullOrWhiteSpace(property.Name) || node.Name.LocalName != property.Name || !names.Add(property.Name))
                    throw new InvalidDataException("参数索引名称无效或重复：" + property.Name);
            }
        }

        // 主页面只允许编辑值；忽略本地化显示、分组排序及运行态 ReadOnly 差异。
        public static string ValueSnapshot(IEnumerable<Property> properties)
        {
            return new XElement("Values", properties.OrderBy(p => p.Name, StringComparer.Ordinal)
                .Select(p => new XElement("Property", new XAttribute("Name", p.Name),
                    new XAttribute("Type", p.valType), p.PropToXElment().Element("Value"))))
                .ToString(SaveOptions.DisableFormatting);
        }

        public void Save(XElement source)
        {
            if (CommitGuard == null) SaveCore(source);
            else CommitGuard(() => SaveCore(source));
        }

        private void SaveCore(XElement source)
        {
            CheckCurrent();
            var nextSource = new XElement(source);
            var nextTarget = new XElement(targetView ?? Read(targetBytes));
            foreach (var item in pending)
            {
                string name = (string)item.Element("Name");
                ValidateTransferName?.Invoke(name);
                if (nextSource.Elements().Any(p => (string)p.Element("Name") == name)
                    || nextTarget.Elements().Any(p => (string)p.Element("Name") == name))
                    throw new InvalidOperationException("待转移参数存在同名冲突：" + name);
                nextTarget.Add(new XElement(item));
            }
            ValidateDocument(nextSource);
            ValidateDocument(nextTarget);
            ValidateDocuments?.Invoke(nextSource, nextTarget);
            bool transfer = HasPending;
            CheckCurrent();
            try
            {
                // 先写目标再写源；直接覆盖无回滚，中途失败可能留下重复定义或损坏文件。
                if (transfer) ParameterFileCommit.Save(targetPath, nextTarget, sourcePath, nextSource);
                else ParameterFileCommit.Save(sourcePath, nextSource);
                RefreshCommitted?.Invoke(new XElement(nextSource), new XElement(nextTarget));
                sourceBytes = File.ReadAllBytes(sourcePath);
                targetBytes = File.ReadAllBytes(targetPath);
                sourceView = new XElement(nextSource);
                targetView = new XElement(nextTarget);
                pending.Clear();
            }
            catch (Exception error)
            {
                IsFaulted = true;
                throw new IOException("参数保存或刷新失败，待转移内容保留但当前会话已锁定。"
                    + "\n未生成备份、未回滚。以下文件可能已部分或全部更新，请勿运行设备，检查后关闭窗口并重新加载："
                    + "\n" + sourcePath + (transfer ? "\n" + targetPath : "")
                    + "\n" + error.Message, error);
            }
        }
    }
}
