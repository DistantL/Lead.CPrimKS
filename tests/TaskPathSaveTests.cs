// Compile with the production TasksManager.cs; external UI/permission services are stubbed below.
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.TaskCommon;
using Lead.CPrim.ProxyTools;

internal static class TaskPathSaveTests
{
    private static int checks;
    private static void Check(bool condition, string message)
    {
        if (!condition) throw new Exception(message);
        checks++;
    }
    private static void Set(object target, string field, object value)
    {
        target.GetType().GetField(field, BindingFlags.NonPublic | BindingFlags.Instance).SetValue(target, value);
    }
    public static void Main()
    {
        string root = Path.Combine(Path.GetTempPath(), "TaskPathSaveTests-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            string oldRoot = Path.Combine(root, "Old"), newRoot = Path.Combine(root, "New");
            Directory.CreateDirectory(Path.Combine(oldRoot, "TaskA"));
            Directory.CreateDirectory(Path.Combine(newRoot, "TaskA"));
            File.WriteAllText(Path.Combine(newRoot, "TaskA", "Run.cs"), "// existing script");
            var manager = new TasksManager { TaskSpacePath = oldRoot };
            var task = new ITask { Name = "TaskA", Idx = 1, Id = Guid.NewGuid(),
                TaskFolderPath = Path.Combine(oldRoot, "TaskA"), Members = new object() };
            manager.ListTask.Add(task);
            var form = new TaskConfigForm { PendingTaskSpacePath = newRoot, CurTask = task };
            Set(manager, "_tasksConfigForm", form);
            string config = Path.Combine(root, "Tasks.xml");
            Set(manager, "_taskConfigPath", config);
            Check(manager.TaskSpacePath == oldRoot && task.TaskFolderPath.StartsWith(oldRoot), "Editing must not apply paths");
            Check(manager.Save() == 0, "Save should succeed");
            Check(manager.TaskSpacePath == newRoot && task.TaskFolderPath == Path.Combine(newRoot, "TaskA"), "Both paths must update");
            Check(File.Exists(Path.Combine(task.TaskFolderPath, "Run.cs")), "Editor path must find migrated script");
            Check(File.Exists(Path.Combine(task.TaskFolderPath, "TaskA.json")), "Members must save in new directory");
            var saved = (TaskConfigSave)XmlSerializerHelper.ReadXML(config, typeof(TaskConfigSave));
            Check(saved.TaskSpacePath == newRoot && saved.ListTaskInfo[0].InnerText == task.TaskFolderPath, "Reload must retain root and per-task paths");
            string savedXml = File.ReadAllText(config);
            form.PendingTaskSpacePath = Path.Combine(root, "Missing");
            Check(manager.Save() != 0 && manager.TaskSpacePath == newRoot, "Missing root must fail without changing state");
            form.PendingTaskSpacePath = root;
            Check(manager.Save() != 0 && task.TaskFolderPath == Path.Combine(newRoot, "TaskA"), "Missing child must fail without changing state");
            Check(File.ReadAllText(config) == savedXml, "Invalid path must not modify persisted configuration");
            form.PendingTaskSpacePath = oldRoot;
            XmlSerializerHelper.FailWrite = true;
            Check(manager.Save() != 0 && manager.TaskSpacePath == newRoot && task.TaskFolderPath == Path.Combine(newRoot, "TaskA"), "XML failure must roll back in-memory paths");
            XmlSerializerHelper.FailWrite = false;
            JsonHelper.FailWrite = true;
            Check(manager.Save() != 0 && manager.TaskSpacePath == newRoot && task.TaskFolderPath == Path.Combine(newRoot, "TaskA"), "Member write failure must roll back in-memory paths");
            JsonHelper.FailWrite = false;
            form.PendingTaskSpacePath = "relative";
            Check(manager.Save() != 0, "Relative root must be rejected");
            form.PendingTaskSpacePath = newRoot;
            task.Name = "..";
            Check(manager.Save() != 0, "Invalid task name must be rejected");
            Console.WriteLine("PASS: " + checks + " checks");
        }
        finally { Directory.Delete(root, true); }
    }
}

// Minimal dependencies: the production save implementation is compiled unchanged.
namespace Lead.CPrim.Interfaces
{
    public class ITask
    {
        public Guid Id; public string Name; public int Idx; public string TaskFolderPath; public object Members;
        public XmlNode IEleExportConfigXml() { var doc = new XmlDocument(); var node = doc.CreateElement("TaskFolderPath"); node.InnerText = TaskFolderPath; return node; }
        public void ITaskImportConfigXml(XmlNode node) { }
        public void ITaskImportMembersConfig() { }
    }
}
namespace Lead.CPrim.TaskCommon
{
    public class TaskConfigForm { public string PendingTaskSpacePath; public ITask CurTask; public void SetEnable(bool value) { } }
}
namespace Lead.CPrim.ProxyTools.Authority
{
    public enum OpLevel { None }
    public class AuthorityManager
    {
        public static event Action<OpLevel> OnUpdateLevel;
        public static AuthorityManager Instance = new AuthorityManager();
        public bool VerifyLevel3Permission(bool show = false) { return true; }
    }
}
namespace Lead.CPrim.ProxyTools.SunnyUI.Style { public enum UIStyle { Orange } }
namespace Lead.CPrim.ProxyTools
{
    public enum LogLevel { Trace, Warn, Error, Fatal }
    public enum PrimLogId { TaskCommon }
    public enum LogClassification { Module }
    public static class LogHelper { public static void LogAdd(LogLevel level, string msg, string source, LogClassification category, long id) { } }
    public static class ULocalize { public static string WarningTitle = "Warning"; }
    public static class UIMessageDialog { public static void ShowMessageDialog(string msg, string title, bool a, SunnyUI.Style.UIStyle style, bool b, bool c) { } }
    public static class NLocalizer { public static string GetString(string key, string fallback) { return fallback; } }
    public static class Extensions { public static bool IsValid<T>(this List<T> list) { return list != null && list.Count > 0; } }
    public static class FactoryCreator { public static T GetFactoryClass<T>(string path, string name) { return default(T); } }
    public static class JsonHelper
    {
        public static bool FailWrite;
        public static bool SerializeObjectToFile(object value, string path, object encoding) { if (FailWrite) return false; File.WriteAllText(path, "{}"); return true; }
    }
    public static class XmlSerializerHelper
    {
        public static bool FailWrite;
        public static bool WriteXML(object value, string path, Type type) { if (FailWrite) return false; using (var writer = File.CreateText(path)) new XmlSerializer(type).Serialize(writer, value); return true; }
        public static object ReadXML(string path, Type type) { using (var reader = File.OpenText(path)) return new XmlSerializer(type).Deserialize(reader); }
    }
}
