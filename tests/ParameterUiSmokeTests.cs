using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;
using Lead.CPrim.DynamicParam;
using Lead.CPrim.Global;
using Newtonsoft.Json;

internal static class ParameterUiSmokeTests
{
    private static int checks;
    private static void Check(bool ok, string message)
    {
        if (!ok) throw new Exception(message);
        checks++;
    }
    [STAThread]
    public static void Main(string[] args)
    {
        // 依赖从编译输出和仓库库目录解析；不运行 Lead.CPrim.View.exe。
        string output = AppDomain.CurrentDomain.BaseDirectory;
        string[] libs = Directory.GetFiles(Path.Combine(args[0], "Lead.CPrim", "ExtLibs"), "*.dll", SearchOption.AllDirectories);
        AppDomain.CurrentDomain.AssemblyResolve += (s, e) =>
        {
            string name = new AssemblyName(e.Name).Name + ".dll";
            string path = Path.Combine(output, name);
            if (!File.Exists(path)) path = libs.FirstOrDefault(p => Path.GetFileName(p) == name);
            return path == null ? null : Assembly.LoadFrom(path);
        };
        Run(output);
    }
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void Run(string output)
    {
        string dir = Path.Combine(Path.GetTempPath(), "ParameterUiSmoke-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(dir);
        string previousVersion = Lead.CPrim.ProxyTools.UIGlobal.Version;
        string versionFile = Path.Combine(dir, "Version.ini");
        File.WriteAllText(versionFile, "LEA_1.1.0.0_260914_POR");
        Lead.CPrim.ProxyTools.RuntimeConfigPaths.Configure(versionFile, Path.Combine(dir, "Counts.ini"));
        Check(Lead.CPrim.ProxyTools.UIGlobal.Version == "LEA_1.1.0.0_260914_POR", "启动路径刷新提前缓存的版本");
        // 测试对象仅使用临时目录，构造时清理目录设置为空。
        var old = JsonConvert.DeserializeObject<SwManager>("{\"DynamicParamDirPath\":\"Z:\\\\OldParams\"}");
        Check(old.GlobalParamDirPath == old.DynamicParamDirPath, "旧配置全局目录回退");
        Check(old.ProductParamDirPath == Path.Combine(old.DynamicParamDirPath, "ProductCfg"), "旧配置产品目录回退");
        Check(old.LeadVersionFilePath == @"D:\Config\IniConfig\Lead.ini", "版本文件默认值");
        Check(old.TossingStatisticsFilePath == @"D:\Config\IniConfig\TossingStaticitsInfo.ini", "统计文件默认值");
        old.GlobalParamDirPath = Path.Combine(dir, "Global");
        old.ProductParamDirPath = dir;
        old.LeadVersionFilePath = Path.Combine(dir, "Version.ini");
        old.TossingStatisticsFilePath = Path.Combine(dir, "Counts.ini");
        var restored = JsonConvert.DeserializeObject<SwManager>(JsonConvert.SerializeObject(old));
        Check(restored.GlobalParamDirPath == old.GlobalParamDirPath && restored.ProductParamDirPath == dir,
            "两个目录序列化往返");
        Check(restored.LeadVersionFilePath == old.LeadVersionFilePath && restored.TossingStatisticsFilePath == old.TossingStatisticsFilePath,
            "两个 INI 路径序列化往返");
        var manager = SwManager.Instance;
        manager.Products = new System.Collections.Generic.List<string> { "AudioAirPods" };
        typeof(SwManager).GetField("_currentProduct", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(manager, "AudioAirPods");
        var speed = new XElement("Speed", new XElement("Name", "Speed"), new XElement("DisplayName", "Speed"),
            new XElement("Category", "Test"), new XElement("Value", 10), new XElement("valType", "INT"),
            new XElement("ReadOnly", false), new XElement("Visible", true), new XElement("CombMsg", ""));
        new XElement("Para", speed).Save(Path.Combine(dir, "AudioAirPods.para"));
        speed.SetElementValue("Value", 30);
        new XElement("Para", speed).Save(Path.Combine(dir, "AudioAirPods_正常生产.para"));
        using (var form = new DynamicParamForm())
        {
            Check(form.Init(dir, "正常生产") == 0, "参数界面初始化");
            Check((int)DynamicParam.Instance.Speed == 30, "模式值进入运行实例");
            Check(form.ModeChange("空运行模式") == 0 && (int)DynamicParam.Instance.Speed == 30, "空模式保留已写回值");
            Check(!form.HasUnsavedParameterChanges, "换型页面加载后无未保存值");
            var common = Lead.CPrim.CommonParam.CommonParamForm.Instance;
            string globalDir = Path.Combine(dir, "Global");
            Directory.CreateDirectory(globalDir);
            var transferValue = new XElement(speed);
            transferValue.Name = "TransferValue";
            transferValue.SetElementValue("Name", "TransferValue");
            transferValue.SetElementValue("Value", 55);
            string commonPath = Path.Combine(globalDir, "CommonParam.para");
            new XElement("Para", transferValue).Save(commonPath);
            common.Init(globalDir);
            Check(!common.HasUnsavedParameterChanges, "全局页面加载后无未保存值");
            var commonGrid = (PropertyGrid)typeof(Lead.CPrim.CommonParam.CommonParamForm)
                .GetField("pg", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(common);
            var commonProperties = (Lead.CPrim.BaseParam.PropertyManageCls)commonGrid.SelectedObject;
            commonProperties.Cast<Lead.CPrim.BaseParam.Property>().First(p => p.Name == "TransferValue").Value = 56;
            Check(common.HasUnsavedParameterChanges, "全局未保存值可检测");
            commonProperties.Cast<Lead.CPrim.BaseParam.Property>().First(p => p.Name == "TransferValue").Value = 55;
            byte[] modeBeforeTransfer = File.ReadAllBytes(form.ActiveModePath);
            var transfer = new Lead.CPrim.BaseParam.ParameterTransferSession(commonPath, form.ActiveParameterPath, "AudioAirPods");
            transfer.ValidateDocuments = (g, p) => form.ValidateTransferredParameters(p);
            transfer.RefreshCommitted = (g, p) => { common.RefreshTransferredParameters(g); form.RefreshTransferredParameters(p); };
            var commonDocument = XElement.Load(commonPath);
            transfer.Stage(commonDocument.Element("TransferValue"), "Test");
            commonDocument.Element("TransferValue").Remove();
            transfer.Save(commonDocument);
            Check(!Lead.CPrim.CommonParam.CommonParam.Instance.IsPropertyContain("TransferValue"), "刷新后全局运行实例移除");
            Check((int)DynamicParam.Instance.TransferValue == 55, "刷新后产品运行实例新增");
            Check(!common.HasUnsavedParameterChanges && !form.HasUnsavedParameterChanges, "提交后两侧基线同步");
            Check(File.ReadAllBytes(form.ActiveModePath).SequenceEqual(modeBeforeTransfer), "转移不修改模式文件");
            Check(common.Save(common.GetRunMode()) == 0 && form.Save(null, false) == 0, "主页面再次保存");
            Check(XElement.Load(commonPath).Element("TransferValue") == null
                && XElement.Load(form.ActiveParameterPath).Elements("TransferValue").Count() == 1, "旧缓存不恢复全局或丢失产品变量");
            Check(form.ModeChange("正常生产") == 0 && (int)DynamicParam.Instance.TransferValue == 55, "模式切换保留新产品变量");
            Check(form.Init(dir, "正常生产") == 0 && (int)DynamicParam.Instance.TransferValue == 55, "重新加载保留转移结果");
            int notices = 0;
            manager.OnSoftwareConfigChangeCurrentProduct += (product, products) => notices++;
            manager.ChangeCurrentProduct("ProductB", false);
            Check(notices == 0 && manager.CurrentProduct == "ProductB", "静默换型不递归通知");
            manager.CurrentProduct = "AudioAirPods";
            Check(notices == 1, "换型只通知一次");
            form.Size = new Size(1100, 650);
            form.ShowInTaskbar = false;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(-30000, -30000);
            form.Show();
            Application.DoEvents();
            var products = (ToolStripComboBox)typeof(DynamicParamForm).GetField("tscboProducts", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(form);
            Check((string)products.SelectedItem == "AudioAirPods", "显示的产品与加载产品一致");
            using (var bitmap = new Bitmap(form.Width, form.Height))
            {
                form.DrawToBitmap(bitmap, new Rectangle(Point.Empty, bitmap.Size));
                bitmap.Save(Path.Combine(output, "product-mode-ui.png"));
            }
        }
        Console.WriteLine("PASS " + checks + " UI/compatibility checks. Temporary data: " + dir);
    }
}
