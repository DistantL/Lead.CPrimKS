using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Lead.CPrim.BaseParam
{
    /// <summary>显式保存的文件替换与失败回滚。断电仍需使用同目录备份人工恢复。</summary>
    public static class ParameterFileCommit
    {
        public static void Save(string path, XElement document, string secondPath = null, XElement second = null)
        {
            var paths = secondPath == null ? new[] { path } : new[] { path, secondPath };
            if (paths.Select(Path.GetFullPath).Distinct(StringComparer.OrdinalIgnoreCase).Count() != paths.Length)
                throw new IOException("保存路径不能重复。");
            var docs = secondPath == null ? new[] { document } : new[] { document, second };
            string suffix = ".save-" + Guid.NewGuid().ToString("N");
            var existed = paths.Select(File.Exists).ToArray();
            var bytes = paths.Select(p => File.Exists(p) ? File.ReadAllBytes(p) : null).ToArray();
            int replaced = 0;
            try
            {
                for (int i = 0; i < paths.Length; i++)
                {
                    docs[i].Save(paths[i] + suffix + ".tmp");
                    if (existed[i]) File.Copy(paths[i], paths[i] + suffix + ".bak");
                }
                for (int i = 0; i < paths.Length; i++)
                {
                    if (existed[i] ? !File.Exists(paths[i]) || !File.ReadAllBytes(paths[i]).SequenceEqual(bytes[i]) : File.Exists(paths[i]))
                        throw new IOException("参数文件在保存期间发生变化：" + paths[i]);
                    if (existed[i]) File.Replace(paths[i] + suffix + ".tmp", paths[i], null);
                    else File.Move(paths[i] + suffix + ".tmp", paths[i]);
                    replaced++;
                }
            }
            catch (Exception error)
            {
                var failures = new List<string>();
                for (int i = replaced - 1; i >= 0; i--)
                {
                    try
                    {
                        if (existed[i]) File.Copy(paths[i] + suffix + ".bak", paths[i], true);
                        else File.Delete(paths[i]);
                    }
                    catch (Exception ex) { failures.Add(ex.Message); }
                }
                throw new IOException("参数保存失败。备份后缀：" + suffix + ".bak；" + error.Message
                    + (failures.Count == 0 ? "" : " 恢复失败，请勿运行设备：" + string.Join("; ", failures)), error);
            }
            finally
            {
                foreach (string target in paths)
                    try { if (File.Exists(target + suffix + ".tmp")) File.Delete(target + suffix + ".tmp"); } catch (IOException) { }
            }
        }
    }
}
