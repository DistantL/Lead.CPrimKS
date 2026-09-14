using System;
using System.IO;
using System.Xml.Linq;
using Lead.CPrim.DynamicParam;

// 可独立编译，不启动设备程序、不加载机台参数。
internal static class ProductModeFilesTests
{
    private static int checks;
    private static void Check(bool ok, string message)
    {
        if (!ok) throw new Exception(message);
        checks++;
    }
    private static XElement Param(string name, string value, string type = "INT")
    {
        return new XElement(name, new XElement("Name", name), new XElement("Value", value),
            new XElement("valType", type), new XElement("Visible", true), new XElement("ReadOnly", false));
    }
    private static void Reject(Action action, string message)
    {
        try { action(); }
        catch (Exception ex) when (ex is ArgumentException || ex is InvalidDataException || ex is System.Xml.XmlException)
        { checks++; return; }
        throw new Exception(message);
    }
    public static void Main()
    {
        string dir = Path.Combine(Path.GetTempPath(), "ProductModeTests-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(dir);
        var original = new XElement("Para", Param("Speed", "10"), Param("Delay", "20"));
        var mode = new XElement("Para", Param("Speed", "30"));
        var merged = ProductModeFiles.Apply(original, mode);
        Check((string)merged.Element("Speed").Element("Value") == "30", "同名覆盖");
        Check((string)merged.Element("Delay").Element("Value") == "20", "其他参数保持");
        Check((string)original.Element("Speed").Element("Value") == "10", "输入不被修改");
        Check((bool)merged.Element("Speed").Element("ReadOnly"), "覆盖项只读");
        string pathA = ProductModeFiles.ProductPath(dir, "AudioAirPods");
        merged.Save(pathA);
        var emptyMode = ProductModeFiles.ReadMode(dir, "AudioAirPods", "空运行模式");
        Check(!emptyMode.HasElements, "缺失模式创建空 XML");
        var emptyResult = ProductModeFiles.Apply(XElement.Load(pathA), emptyMode);
        Check((string)emptyResult.Element("Speed").Element("Value") == "30", "空模式不恢复覆盖前数值");
        Check(!(bool)emptyResult.Element("Speed").Element("ReadOnly"), "空模式解除模式只读");
        string pathB = ProductModeFiles.ProductPath(dir, "ProductB");
        original.Save(pathB);
        Check((string)ProductModeFiles.Apply(XElement.Load(pathB), emptyMode).Element("Speed").Element("Value") == "10", "产品隔离");
        Check(Path.GetDirectoryName(ProductModeFiles.ModePath(dir, "AudioAirPods", "正常生产")) == Path.GetDirectoryName(pathA), "产品与模式同目录");
        Reject(() => ProductModeFiles.Apply(original, new XElement("Para", Param("Unknown", "1"))), "拒绝非产品参数");
        Reject(() => ProductModeFiles.Apply(original, new XElement("Para", Param("Speed", "true", "BOOL"))), "拒绝不同类型");
        Reject(() => ProductModeFiles.Apply(original, new XElement("Para", Param("Speed", "1"), Param("Speed", "2"))), "拒绝重复参数");
        Reject(() => ProductModeFiles.ModePath(dir, "../bad", "正常生产"), "拒绝目录穿越");
        string broken = ProductModeFiles.ModePath(dir, "AudioAirPods", "坏文件");
        File.WriteAllText(broken, "<broken>");
        Reject(() => ProductModeFiles.ReadMode(dir, "AudioAirPods", "坏文件"), "损坏模式不静默接受");
        Check((string)XElement.Load(pathA).Element("Speed").Element("Value") == "30", "模式读取失败不改变产品文件");
        Console.WriteLine("PASS " + checks + " checks. Temporary data: " + dir);
    }
}
