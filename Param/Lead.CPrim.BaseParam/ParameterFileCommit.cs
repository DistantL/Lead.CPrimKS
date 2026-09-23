using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Lead.CPrim.BaseParam
{
    /// <summary>校验并直接覆盖文件；不生成备份或临时文件，不提供失败回滚。</summary>
    public static class ParameterFileCommit
    {
        public static void Save(string path, XElement document, string secondPath = null, XElement second = null)
        {
            var paths = (secondPath == null ? new[] { path } : new[] { path, secondPath }).Select(Path.GetFullPath).ToArray();
            if (paths.Distinct(StringComparer.OrdinalIgnoreCase).Count() != paths.Length)
                throw new IOException("保存路径不能重复。");
            var docs = secondPath == null ? new[] { document } : new[] { document, second };
            var bytes = paths.Select(p => File.Exists(p) ? File.ReadAllBytes(p) : null).ToArray();
            // 所有文档先在内存中校验并序列化，不能写完第一份才发现第二份内容无效。
            var next = docs.Select(doc =>
            {
                ParameterTransferSession.ValidateDocument(doc);
                using (var stream = new MemoryStream())
                {
                    doc.Save(stream);
                    return stream.ToArray();
                }
            }).ToArray();
            for (int i = 0; i < paths.Length; i++)
                if (bytes[i] == null ? File.Exists(paths[i]) : !File.Exists(paths[i]) || !File.ReadAllBytes(paths[i]).SequenceEqual(bytes[i]))
                    throw new IOException("参数文件在保存期间发生变化：" + paths[i]);
            var completed = new List<string>();
            string writing = null;
            try
            {
                for (int i = 0; i < paths.Length; i++)
                {
                    writing = paths[i];
                    File.WriteAllBytes(writing, next[i]);
                    completed.Add(writing);
                }
            }
            catch (Exception error)
            {
                throw new IOException("参数直接保存失败，无备份且未回滚。请勿运行设备，检查文件后重新加载。"
                    + "\n本次写入失败、可能损坏的文件：" + writing
                    + "\n已完成写入的文件：" + (completed.Count == 0 ? "无" : string.Join("; ", completed))
                    + "\n" + error.Message, error);
            }
        }
    }
}
