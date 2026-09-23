using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Lead.CPrim.BaseParam;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.DynamicParam;
using Lead.CPrim.CommonParam;
using Lead.CPrim.Global;

internal static class ParameterAssignmentTests
{
    private static int checks;
    private static void Check(bool ok, string message) { if (!ok) throw new Exception(message); checks++; }
    private static void Reject(Action action, string message)
    {
        bool failed = false;
        try { action(); } catch { failed = true; }
        Check(failed, message);
    }
    private static XElement P(string name, object value, DataType type)
    {
        return new Property { Name = name, DisplayName = name, Category = "Test", Value = value,
            valType = type, Visible = true, Cartesian = type == DataType.Point ? "XYZ" : "", CombMsg = "A,B" }.PropToXElment();
    }
    private static List<Pos> Points(double x) { return new List<Pos> { new Pos("P1", x, 2, 3, 4, 5, 6) }; }
    private static XElement Document()
    {
        var config = new List<Property> { (Property)P("Enabled", true, DataType.BOOL), (Property)P("NestedPoints", Points(1), DataType.Point) };
        return new XElement("Para", P("Flag", true, DataType.BOOL), P("Count", 10, DataType.INT),
            P("Points", Points(1), DataType.Point), P("Config", config, DataType.UserDefine));
    }
    private static Property Ui(object form, string name)
    {
        var field = form.GetType().GetField("Pmcls", BindingFlags.NonPublic | BindingFlags.Instance);
        return ((PropertyManageCls)field.GetValue(form)).Cast<Property>().First(p => p.Name == name);
    }
    [STAThread]
    public static void Main(string[] args)
    {
        string output = AppDomain.CurrentDomain.BaseDirectory;
        string[] libs = Directory.GetFiles(Path.Combine(args[0], "Lead.CPrim", "ExtLibs"), "*.dll", SearchOption.AllDirectories);
        AppDomain.CurrentDomain.AssemblyResolve += (s, e) =>
        {
            string name = new AssemblyName(e.Name).Name + ".dll";
            string path = Path.Combine(output, name);
            if (!File.Exists(path)) path = libs.FirstOrDefault(p => Path.GetFileName(p) == name);
            return path == null ? null : Assembly.LoadFrom(path);
        };
        try { Run(); }
        catch (Exception ex) { Console.WriteLine(ex.GetType().Name + ": " + ex.Message + "\n" + ex.StackTrace); Environment.ExitCode = 1; }
    }
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void Run()
    {
        string dir = Path.Combine(Path.GetTempPath(), "AssignmentTests-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(dir);
        string globalPath = Path.Combine(dir, "CommonParam.para");
        string productPath = Path.Combine(dir, "AudioAirPods.para");
        string modePath = Path.Combine(dir, "AudioAirPods_正常生产.para");
        Document().Save(globalPath); Document().Save(productPath);
        new XElement("Para", P("Flag", true, DataType.BOOL), P("Count", 20, DataType.INT)).Save(modePath);
        var globalBefore = File.ReadAllBytes(globalPath);
        var productBefore = File.ReadAllBytes(productPath);
        var modeBefore = File.ReadAllBytes(modePath);
        var sw = SwManager.Instance;
        sw.Products = new List<string> { "AudioAirPods" };
        typeof(SwManager).GetField("_currentProduct", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(sw, "AudioAirPods");
        var common = CommonParamForm.Instance;
        common.Init(dir);
        using (var product = new DynamicParamForm())
        {
            Check(product.Init(dir, "正常生产") == 0, "初始化成功");
            Check(globalBefore.SequenceEqual(File.ReadAllBytes(globalPath)) && productBefore.SequenceEqual(File.ReadAllBytes(productPath))
                && modeBefore.SequenceEqual(File.ReadAllBytes(modePath)), "启动应用模式不写文件");
            Check((int)DynamicParam.Instance.Count == 20, "启动模式进入运行缓存");
            var unusedHandles = new[] { common.Handle, product.Handle };
            common.UIShow(false); product.UIShow(false);
            Task.Run(() => { CommonParam.Instance.Flag = false; DynamicParam.Instance.Flag = false; }).GetAwaiter().GetResult();
            Check(common.Save() == -1 && product.Save(null, false) == -1, "运行禁用时不能保存");
            common.UIShow(true); product.UIShow(true);
            Check(!(bool)Ui(common, "Flag").Value && !(bool)Ui(product, "Flag").Value, "暂停前排空脚本通知");
            Ui(common, "Flag").Value = true;
            Application.DoEvents();
            Check((bool)Ui(common, "Flag").Value, "旧异步刷新不覆盖暂停后人工修改");
            CommonParam.Instance.Flag = false;
            Check(!(bool)Ui(common, "Flag").Value, "UI线程显式赋值立即同步");
            Check(globalBefore.SequenceEqual(File.ReadAllBytes(globalPath)) && productBefore.SequenceEqual(File.ReadAllBytes(productPath)), "脚本赋值不写文件");
            var modeProps = (PropertyManageCls)typeof(DynamicParamForm).GetField("_modeProperties", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(product);
            Check((bool)modeProps.Cast<Property>().First(p => p.Name == "Flag").Value, "脚本不修改模式表");
            Check(common.Save() == 0 && product.Save(null, false) == 0, "暂停手动保存");
            Check(!(bool)XElement.Load(productPath).Element("Flag").Element("Value"), "普通保存不应用未改模式值");
            Check(modeBefore.SequenceEqual(File.ReadAllBytes(modePath)), "未改模式文件保持原字节");
            modeProps.Cast<Property>().First(p => p.Name == "Flag").DisplayName = "Localized flag";
            Check(product.Save(null, false) == 0 && modeBefore.SequenceEqual(File.ReadAllBytes(modePath)), "显示名称变化不视为人工模式值修改");

            foreach (bool isGlobal in new[] { true, false })
            {
                dynamic manager = isGlobal ? CommonParam.Instance : DynamicParam.Instance;
                object form = isGlobal ? (object)common : product;
                List<Pos> points = manager.Points;
                points[0].X = 100;
                Check(((List<Pos>)Ui(form, "Points").Value)[0].X == 1, "原地坐标不进UI");
                manager.Points = points;
                Check(((List<Pos>)Ui(form, "Points").Value)[0].X == 100, "重新赋值同步坐标");
                points[0].X = 200;
                Check(((List<Pos>)Ui(form, "Points").Value)[0].X == 100, "快照不共享列表");
                manager.Config.Enabled = false;
                Check(!(bool)((List<Property>)Ui(form, "Config").Value).First(p => p.Name == "Enabled").Value, "自定义子属性同步");
                dynamic cfg = manager.Config;
                List<Pos> nested = cfg.NestedPoints;
                nested[0].X = 222;
                cfg.Enabled = true;
                Check(((List<Pos>)((List<Property>)Ui(form, "Config").Value).First(p => p.Name == "NestedPoints").Value)[0].X == 1,
                    "子属性通知不夹带同级原地修改");
                cfg.NestedPoints = nested;
                Check(((List<Pos>)((List<Property>)Ui(form, "Config").Value).First(p => p.Name == "NestedPoints").Value)[0].X == 222,
                    "嵌套点位显式赋值同步");
                if (isGlobal) common.Save(); else product.Save(null, false);
                var saved = (Property)XElement.Load(isGlobal ? globalPath : productPath).Element("Points");
                Check(((List<Pos>)saved.Value)[0].X == 100, "保存不夹带未赋值坐标200");
            }

            DynamicParam.Instance.Flag = false;
            modeProps.Cast<Property>().First(p => p.Name == "Count").Value = 88;
            Check(product.Save(null, false) == 0, "人工模式编辑保存");
            Check((int)DynamicParam.Instance.Count == 88 && !(bool)DynamicParam.Instance.Flag, "只应用人工改动模式项");
            Check((bool)XElement.Load(modePath).Element("Flag").Element("Value"), "模式旧Flag仍为true");
            var savedProduct = File.ReadAllBytes(productPath);
            DynamicParam.Instance.Count = 77;
            Check(product.ModeChange("空运行模式") == 0 && (int)DynamicParam.Instance.Count == 77, "空模式保留显式缓存值");
            Check(!File.Exists(product.ActiveModePath) && savedProduct.SequenceEqual(File.ReadAllBytes(productPath)), "切模式不写/生成参数文件");
            Check(product.ModeChange("正常生产") == 0 && (int)DynamicParam.Instance.Count == 88, "切回模式应用一次");
            DynamicParam.Instance.Count = 99;
            Check(product.Save(null, false) == 0 && (int)DynamicParam.Instance.Count == 99, "之后普通保存不重复覆盖模式值");

            Task.Run(() => DynamicParam.Instance.Count = 123).GetAwaiter().GetResult();
            Check(product.Init(dir, "正常生产") == 0, "重新加载重建上下文");
            Application.DoEvents();
            Check((int)Ui(product, "Count").Value == 88, "旧通知不覆盖新加载模式");
            long version = product.ParameterVersion;
            DynamicParam.Instance.Count = 999;
            Reject(() => typeof(DynamicParamForm).GetMethod("ValidateEditorVersion", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(product, new object[] { version }), "旧编辑器版本拒绝保存");

            Task.Run(() => { for (int i = 0; i < 100; i++) CommonParam.Instance.Count = i; }).GetAwaiter().GetResult();
            Check(common.Save() == 0 && (int)XElement.Load(globalPath).Element("Count").Element("Value") == 99,
                "不等待异步队列也保存最后一次赋值");

            var originalGlobal = File.ReadAllBytes(globalPath);
            CommonParam.Instance.Count = 1234;
            using (var locked = new FileStream(globalPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                Reject(() => common.Save(), "保存失败可报告");
            Check(originalGlobal.SequenceEqual(File.ReadAllBytes(globalPath)) && (int)CommonParam.Instance.Count == 1234, "失败不丢运行新值");
        }
        // 所有文件先校验，直接覆盖的第二份失败时第一份不回滚。
        var directFirst = Path.Combine(dir, "direct-first.para");
        var directSecond = Path.Combine(dir, "direct-second.para");
        var original = new XElement("Para", P("Value", 1, DataType.INT));
        var changed = new XElement("Para", P("Value", 2, DataType.INT));
        original.Save(directFirst);
        original.Save(directSecond);
        using (var locked = new FileStream(directSecond, FileMode.Open, FileAccess.Read, FileShare.Read))
            Reject(() => ParameterFileCommit.Save(directFirst, changed, directSecond, changed), "直接覆盖第二份失败");
        Check((int)XElement.Load(directFirst).Element("Value").Element("Value") == 2
            && (int)XElement.Load(directSecond).Element("Value").Element("Value") == 1, "直接覆盖不回滚第一份");
        var invalid = new XElement("Para", P("Value", 2, DataType.INT), P("Value", 3, DataType.INT));
        Reject(() => ParameterFileCommit.Save(directFirst, original, directSecond, invalid), "第二份无效内容在写入前拒绝");
        Check((int)XElement.Load(directFirst).Element("Value").Element("Value") == 2, "校验失败不写第一份");
        Check(!Directory.GetFiles(dir, "*.bak", SearchOption.AllDirectories).Any()
            && !Directory.GetFiles(dir, "*.tmp", SearchOption.AllDirectories).Any(), "普通保存不生成备份或临时文件");
        // 基础类型共用入口，分别验证快照的序列化往返。
        var types = new[] { DataType.BOOL, DataType.INT, DataType.BYTE, DataType.DOUBLE, DataType.STRING, DataType.Comb, DataType.PathString, DataType.DirPath };
        object[] values = { false, 7, (byte)3, 1.25, "new", "B", @"C:\test.txt", @"C:\test" };
        object[] initial = { true, 0, (byte)0, 0.0, "old", "A", @"C:\old.txt", @"C:\old" };
        for (int i = 0; i < types.Length; i++)
        {
            var doc = new XElement("Para", P("Value", initial[i], types[i]));
            common.RefreshTransferredParameters(doc);
            Check(((CommonParam)CommonParam.Instance).SetMember("Value", values[i]), "支持类型 " + types[i]);
            Check(object.Equals(Ui(common, "Value").Value, values[i]), "类型 UI快照 " + types[i]);
        }
        Console.WriteLine("PASS " + checks + " assignment checks. Temporary data: " + dir);
    }
}
