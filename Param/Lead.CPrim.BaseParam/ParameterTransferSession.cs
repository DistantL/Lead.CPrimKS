using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Lead.CPrim.BaseParam
{
    /// <summary>一次全局参数编辑会话；只在 Save 时协调提交两份文件。</summary>
    public sealed class ParameterTransferSession
    {
        private readonly string sourcePath;
        private readonly string targetPath;
        private byte[] sourceBytes;
        private byte[] targetBytes;
        private readonly List<XElement> pending = new List<XElement>();
        public Action ValidateContext { get; set; }
        public Action<XElement, XElement> ValidateDocuments { get; set; }
        public Action<XElement, XElement> RefreshCommitted { get; set; }
        public string Product { get; private set; }
        public bool HasPending { get { return pending.Count != 0; } }
        public string LastBackupPaths { get; private set; }

        public ParameterTransferSession(string source, string target, string product)
        {
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
            get { return Read(targetBytes).Elements().Concat(pending).Select(p => (string)p.Element("Category"))
                .Where(p => !string.IsNullOrWhiteSpace(p)).Distinct().ToArray(); }
        }

        public void CheckCurrent()
        {
            ValidateContext?.Invoke();
            if (!File.ReadAllBytes(sourcePath).SequenceEqual(sourceBytes)
                || !File.ReadAllBytes(targetPath).SequenceEqual(targetBytes))
                throw new InvalidOperationException("参数文件已被其他操作修改，请放弃当前编辑并重新打开。");
        }

        public void CheckName(string name)
        {
            CheckCurrent();
            if (name == "运行模式") throw new InvalidOperationException("运行模式是框架保留参数，不可转移。");
            if (Read(targetBytes).Elements().Any(p => (string)p.Element("Name") == name)
                || pending.Any(p => (string)p.Element("Name") == name))
                throw new InvalidOperationException("当前产品或待转移清单已存在同索引名称：" + name);
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

        public void Save(XElement global)
        {
            CheckCurrent();
            var nextGlobal = new XElement(global);
            var nextProduct = Read(targetBytes);
            foreach (var item in pending)
            {
                string name = (string)item.Element("Name");
                if (nextGlobal.Elements().Any(p => (string)p.Element("Name") == name)
                    || nextProduct.Elements().Any(p => (string)p.Element("Name") == name))
                    throw new InvalidOperationException("待转移参数存在同名冲突：" + name);
                nextProduct.Add(new XElement(item));
            }
            ValidateDocument(nextGlobal);
            ValidateDocument(nextProduct);
            ValidateDocuments?.Invoke(nextGlobal, nextProduct);
            string suffix = ".transfer-" + Guid.NewGuid().ToString("N");
            string sourceTemp = sourcePath + suffix + ".tmp";
            string targetTemp = targetPath + suffix + ".tmp";
            string sourceBackup = sourcePath + suffix + ".bak";
            string targetBackup = targetPath + suffix + ".bak";
            bool sourceReplaced = false, targetReplaced = false;
            bool transfer = HasPending;
            LastBackupPaths = sourceBackup + (transfer ? Environment.NewLine + targetBackup : "");
            try
            {
                nextGlobal.Save(sourceTemp);
                if (transfer) nextProduct.Save(targetTemp);
                File.Copy(sourcePath, sourceBackup);
                if (transfer) File.Copy(targetPath, targetBackup);
                CheckCurrent();
                // 先落目标文件，再移除全局定义；失败时利用备份恢复。
                if (transfer) { File.Replace(targetTemp, targetPath, null); targetReplaced = true; }
                File.Replace(sourceTemp, sourcePath, null);
                sourceReplaced = true;
                RefreshCommitted?.Invoke(new XElement(nextGlobal), new XElement(nextProduct));
                sourceBytes = File.ReadAllBytes(sourcePath);
                targetBytes = File.ReadAllBytes(targetPath);
                pending.Clear();
            }
            catch (Exception error)
            {
                var recovery = new List<string>();
                if (sourceReplaced) TryRecover(() => File.Copy(sourceBackup, sourcePath, true), recovery);
                if (targetReplaced) TryRecover(() => File.Copy(targetBackup, targetPath, true), recovery);
                if (sourceReplaced || targetReplaced)
                    TryRecover(() => RefreshCommitted?.Invoke(Read(sourceBytes), Read(targetBytes)), recovery);
                throw new IOException("参数保存失败，待转移内容保留。" + error.Message
                    + "\n备份位置（若已生成）：\n" + LastBackupPaths
                    + (recovery.Count == 0 ? "" : "\n恢复失败，请勿运行设备：" + string.Join("; ", recovery)), error);
            }
            finally
            {
                // 只清理本次唯一命名的临时文件；备份保留用于人工恢复。
                TryRecover(() => { if (File.Exists(sourceTemp)) File.Delete(sourceTemp); }, new List<string>());
                TryRecover(() => { if (File.Exists(targetTemp)) File.Delete(targetTemp); }, new List<string>());
            }
        }

        private static void TryRecover(Action action, List<string> failures)
        {
            try { action(); } catch (Exception ex) { failures.Add(ex.Message); }
        }
    }
}
