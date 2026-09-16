using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Lead.CPrim.DynamicParam
{
    /// <summary>仅处理产品及产品模式文件，不访问 CommonParam。</summary>
    public static class ProductModeFiles
    {
        private static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0
                || name == "." || name == "..")
                throw new ArgumentException("产品名或模式名不是有效的文件名：" + name);
        }

        public static string ProductPath(string directory, string product)
        {
            ValidateName(product);
            return Path.Combine(directory, product + ".para");
        }

        public static string ModePath(string directory, string product, string mode)
        {
            ValidateName(product);
            ValidateName(mode);
            return Path.Combine(directory, product + "_" + mode + ".para");
        }

        public static XElement ReadMode(string directory, string product, string mode)
        {
            string path = ModePath(directory, product, mode);
            if (!File.Exists(path))
                return new XElement("Para");
            return XElement.Load(path);
        }

        /// <summary>与旧模式逻辑一致：同名值覆盖；空模式保留当前产品文件的值。</summary>
        public static XElement Apply(XElement product, XElement mode)
        {
            var result = new XElement(product);
            var values = result.Elements().ToDictionary(p => p.Name);
            foreach (var item in result.Elements())
                item.SetElementValue("ReadOnly", !((bool?)item.Element("Visible") ?? true));
            var seen = new System.Collections.Generic.HashSet<XName>();
            foreach (var item in mode.Elements())
            {
                XElement target;
                if (!seen.Add(item.Name) || !values.TryGetValue(item.Name, out target))
                    throw new InvalidDataException("模式参数重复或不属于当前产品：" + item.Name);
                if ((string)target.Element("valType") != (string)item.Element("valType") || item.Element("Value") == null)
                    throw new InvalidDataException("模式参数类型或值无效：" + item.Name);
                if (target.Element("Value") == null)
                    throw new InvalidDataException("产品参数缺少值：" + item.Name);
                target.Element("Value").ReplaceWith(new XElement(item.Element("Value")));
                target.SetElementValue("ReadOnly", true);
            }
            return result;
        }

        /// <summary>保存时仅应用人工新增/改值的模式项；未修改的模式项只保持只读标记。</summary>
        public static XElement ApplyEdited(XElement product, XElement mode, XElement baseline)
        {
            var validated = Apply(product, mode);
            foreach (var item in product.Elements())
                validated.Element(item.Name).Element("Value").ReplaceWith(new XElement(item.Element("Value")));
            foreach (var item in mode.Elements())
            {
                var previous = baseline.Element(item.Name);
                if (previous == null || !XNode.DeepEquals(previous.Element("Value"), item.Element("Value")))
                    validated.Element(item.Name).Element("Value").ReplaceWith(new XElement(item.Element("Value")));
            }
            return validated;
        }
    }
}
