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
        try { Run(output); }
        catch (Exception ex) { Console.WriteLine(ex.GetType().Name + ": " + ex.Message + "\n" + ex.StackTrace); Environment.ExitCode = 1; }
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
            byte[] modeBeforeTransfer = File.Exists(form.ActiveModePath) ? File.ReadAllBytes(form.ActiveModePath) : null;
            var transfer = new Lead.CPrim.BaseParam.ParameterTransferSession(commonPath, form.ActiveParameterPath, "AudioAirPods");
            transfer.ValidateDocuments = (g, p) => form.ValidateTransferredParameters(p);
            transfer.RefreshCommitted = (g, p) => { common.RefreshTransferredParameters(g); form.RefreshTransferredParameters(p); };
            var commonDocument = XElement.Load(commonPath);
            var stagedValue = new XElement(commonDocument.Element("TransferValue"));
            stagedValue.SetElementValue("DisplayName", "转入换型时修改的名称");
            transfer.Stage(stagedValue, "Test");
            Check((string)XElement.Load(commonPath).Element("TransferValue").Element("DisplayName") != "转入换型时修改的名称", "暂存修改显示名称不修改源文件");
            commonDocument.Element("TransferValue").Remove();
            transfer.Save(commonDocument);
            Check(!Lead.CPrim.CommonParam.CommonParam.Instance.IsPropertyContain("TransferValue"), "刷新后全局运行实例移除");
            Check((int)DynamicParam.Instance.TransferValue == 55, "刷新后产品运行实例新增");
            Check((string)form.ParameterSnapshot.Element("TransferValue").Element("DisplayName") == "转入换型时修改的名称", "转入换型保留修改后的显示名称");
            Check(!common.HasUnsavedParameterChanges && !form.HasUnsavedParameterChanges, "提交后两侧基线同步");
            Check(modeBeforeTransfer == null ? !File.Exists(form.ActiveModePath)
                : File.ReadAllBytes(form.ActiveModePath).SequenceEqual(modeBeforeTransfer), "转移不修改模式文件");
            Check(common.Save() == 0 && form.Save(null, false) == 0, "主页面再次保存");
            Check(XElement.Load(commonPath).Element("TransferValue") == null
                && XElement.Load(form.ActiveParameterPath).Elements("TransferValue").Count() == 1, "旧缓存不恢复全局或丢失产品变量");
            Check(form.ModeChange("正常生产") == 0 && (int)DynamicParam.Instance.TransferValue == 55, "模式切换保留新产品变量");
            Check(form.Init(dir, "正常生产") == 0 && (int)DynamicParam.Instance.TransferValue == 55, "重新加载保留转移结果");
            Check(form.ModeChange("空运行模式") == 0, "切换到未引用 Speed 的模式");
            bool modeBlocked = false;
            try { form.ValidateTransferOutName("Speed"); } catch (InvalidOperationException) { modeBlocked = true; }
            Check(modeBlocked, "非当前模式仍引用的变量也不可转移到全局");
            form.ValidateTransferOutName("TransferValue");
            var reverse = new Lead.CPrim.BaseParam.ParameterTransferSession(form.ActiveParameterPath, commonPath, "AudioAirPods", true);
            reverse.ValidateTransferName = form.ValidateTransferOutName;
            reverse.ValidateDocuments = (p, g) => form.ValidateTransferredParameters(p);
            reverse.RefreshCommitted = (p, g) => { common.RefreshTransferredParameters(g); form.RefreshTransferredParameters(p); };
            var productDocument = XElement.Load(form.ActiveParameterPath);
            var reverseValue = new XElement(productDocument.Element("TransferValue"));
            reverseValue.SetElementValue("DisplayName", "转入全局时修改的名称");
            reverse.Stage(reverseValue, "New global group");
            productDocument.Element("TransferValue").Remove();
            Check(!Lead.CPrim.CommonParam.CommonParam.Instance.IsPropertyContain("TransferValue"), "反向确定仅暂存");
            reverse.Save(productDocument);
            Check((int)Lead.CPrim.CommonParam.CommonParam.Instance.TransferValue == 55, "反向刷新全局值");
            Check((string)common.ParameterSnapshot.Element("TransferValue").Element("DisplayName") == "转入全局时修改的名称", "转入全局保留修改后的显示名称");
            Check(((DynamicParam)DynamicParam.Instance).Node.Element("TransferValue") == null, "反向刷新移除产品值");
            Check(common.Save() == 0 && form.Save(null, false) == 0, "反向转移后主页面保存");
            Check(XElement.Load(commonPath).Elements("TransferValue").Count() == 1
                && XElement.Load(form.ActiveParameterPath).Element("TransferValue") == null, "反向保存不恢复旧产品参数");
            Check(form.ModeChange("正常生产") == 0 && form.Init(dir, "正常生产") == 0
                && ((DynamicParam)DynamicParam.Instance).Node.Element("TransferValue") == null, "反向转移后切模式及重载");
            // 使用已有多语言资源键复现：索引不变，用户只修改显示名称。
            Check(Lead.CPrim.ProxyTools.NLocalizer.GetString("启用MES上传", "__missing__") != "__missing__", "回归参数具有旧翻译资源");
            var labelParameter = new XElement(speed);
            labelParameter.Name = "启用MES上传";
            labelParameter.SetElementValue("Name", "启用MES上传");
            labelParameter.SetElementValue("DisplayName", "自定义全局名称");
            var globalLabels = common.ParameterSnapshot;
            globalLabels.Add(labelParameter);
            common.RefreshTransferredParameters(globalLabels);
            common.OnLanguageChanged();
            Check((string)common.ParameterSnapshot.Element("启用MES上传").Element("DisplayName") == "自定义全局名称", "全局刷新不覆盖自定义显示名称");
            Check(common.Save() == 0, "全局新名称保存");
            common.Init(globalDir);
            Check((string)common.ParameterSnapshot.Element("启用MES上传").Element("DisplayName") == "自定义全局名称", "全局新名称重新加载后保留");
            labelParameter.SetElementValue("DisplayName", "自定义换型名称");
            var productLabels = form.ParameterSnapshot;
            productLabels.Add(new XElement(labelParameter));
            form.RefreshTransferredParameters(productLabels);
            form.OnLanguageChanged();
            Check((string)form.ParameterSnapshot.Element("启用MES上传").Element("DisplayName") == "自定义换型名称", "换型刷新不覆盖自定义显示名称");
            Check(form.Save(null, false) == 0 && form.Init(dir, "正常生产") == 0, "换型新名称保存并重载");
            Check((string)form.ParameterSnapshot.Element("启用MES上传").Element("DisplayName") == "自定义换型名称", "换型新名称重新加载后保留");
            Check(!common.ParameterSnapshot.Elements().Any(p => (string)p.Element("Name") == "运行模式"), "全局页面不再生成运行模式");
            Check((string)form.ParameterSnapshot.Element("运行模式").Element("Value") == "正常生产", "产品缺少运行模式时自动补齐");
            Check((bool)form.ParameterSnapshot.Element("运行模式").Element("ReadOnly"), "产品运行模式只读");
            var oldGlobal = XElement.Load(commonPath);
            var legacyMode = new XElement(form.ParameterSnapshot.Element("运行模式"));
            legacyMode.SetElementValue("Value", "点检模式");
            oldGlobal.Add(legacyMode);
            oldGlobal.Save(commonPath);
            byte[] legacyBytes = File.ReadAllBytes(commonPath);
            common.Init(globalDir);
            Check(!Lead.CPrim.CommonParam.CommonParam.Instance.IsPropertyContain("运行模式"), "旧全局运行模式不进入运行集合");
            Check(File.ReadAllBytes(commonPath).SequenceEqual(legacyBytes), "旧全局配置加载不自动写盘");
            Check(common.Save() == 0 && XElement.Load(commonPath).Element("运行模式") == null, "手动保存移除旧全局模式");
            byte[] beforeMode = File.ReadAllBytes(form.ActiveParameterPath);
            int modeNotices = 0;
            Action<string> observeMode = mode =>
            {
                Check((string)DynamicParam.Instance.运行模式 == mode && form.GetRunMode() == mode, "通知时产品运行模式已同步");
                modeNotices++;
            };
            DynamicParam.OnModeSwitch += observeMode;
            try { Check(form.ModeChange("点检模式") == 0, "产品拥有模式切换"); }
            finally { DynamicParam.OnModeSwitch -= observeMode; }
            Check(modeNotices == 1, "成功切换发出一次工站通知");
            Check(File.ReadAllBytes(form.ActiveParameterPath).SequenceEqual(beforeMode), "模式切换不自动写盘");
            Check(form.Save(null, false) == 0 && (string)XElement.Load(form.ActiveParameterPath).Element("运行模式").Element("Value") == "点检模式", "模式状态随产品主文件保存");
            var illegalMode = new XElement("Para", form.ParameterSnapshot.Element("运行模式"));
            bool forbiddenMode = false;
            try { ProductModeFiles.Apply(form.ParameterSnapshot, illegalMode); }
            catch (InvalidDataException) { forbiddenMode = true; }
            Check(forbiddenMode, "运行模式不能被模式表覆盖");
            var clearedEditor = form.PrepareParameterDocument(new XElement("Para"));
            Check((string)clearedEditor.Element("运行模式").Element("Value") == "点检模式", "编辑器清空不能移除框架模式状态");
            Check(form.Init(dir, "正常生产") == 0 && (string)DynamicParam.Instance.运行模式 == "正常生产", "重启初始化不沿用文件中的旧运行状态");
            manager.Products.Add("ProductB");
            var productBPath = Path.Combine(dir, "ProductB.para");
            var productB = new XElement(form.ParameterSnapshot);
            productB.Element("运行模式").SetElementValue("Value", "标定模式");
            productB.Save(productBPath);
            byte[] productBBytes = File.ReadAllBytes(productBPath);
            manager.ChangeCurrentProduct("ProductB", false);
            Check(form.Init(dir, form.GetRunMode()) == 0 && (string)DynamicParam.Instance.运行模式 == "正常生产", "换产品保留当前模式不采用产品文件旧状态");
            Check(File.ReadAllBytes(productBPath).SequenceEqual(productBBytes), "换产品不自动保存");
            manager.ChangeCurrentProduct("AudioAirPods", false);
            Check(form.Init(dir, form.GetRunMode()) == 0, "切回原产品");
            var badModePath = ProductModeFiles.ModePath(dir, "AudioAirPods", "无效测试模式");
            illegalMode.Save(badModePath);
            var beforeFailure = form.ParameterSnapshot.ToString();
            long versionBeforeFailure = form.ParameterVersion;
            bool rejectedLoad = false;
            try
            {
                typeof(DynamicParamForm).GetMethod("LoadProductMode", BindingFlags.NonPublic | BindingFlags.Instance)
                    .Invoke(form, new object[] { "AudioAirPods", "无效测试模式", true });
            }
            catch (TargetInvocationException ex) { rejectedLoad = ex.InnerException is InvalidDataException; }
            Check(rejectedLoad && form.ParameterVersion == versionBeforeFailure
                && form.ParameterSnapshot.ToString() == beforeFailure && form.GetRunMode() == "正常生产", "错误模式文件不改变产品值或模式状态");
            // 工位开关保护按索引而非显示名称识别，并服从模式覆盖和页面禁用。
            var protectedDoc = form.ParameterSnapshot;
            for (int station = 1; station <= 4; station++)
            {
                var flag = new XElement(speed);
                flag.Name = "启用工位" + station;
                flag.SetElementValue("Name", flag.Name.LocalName);
                flag.SetElementValue("DisplayName", "任意修改显示名称" + station);
                flag.SetElementValue("valType", "BOOL");
                flag.SetElementValue("Value", "true");
                protectedDoc.Add(flag);
            }
            form.RefreshTransferredParameters(protectedDoc);
            var protection = typeof(DynamicParamForm).GetMethod("ApplyStationSwitchReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            protection.Invoke(form, new object[] { false });
            Check(form.ParameterSnapshot.Elements().Where(p => ((string)p.Element("Name")).StartsWith("启用工位")).All(p => (bool)p.Element("ReadOnly")), "非 DT 所有工位开关只读");
            protection.Invoke(form, new object[] { true });
            Check(form.ParameterSnapshot.Elements().Where(p => ((string)p.Element("Name")).StartsWith("启用工位")).All(p => !(bool)p.Element("ReadOnly")), "DT 可编辑且不依赖显示名称");
            var modes = (Lead.CPrim.BaseParam.PropertyManageCls)typeof(DynamicParamForm)
                .GetField("_modeProperties", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(form);
            modes.Add((Lead.CPrim.BaseParam.Property)new XElement(form.ParameterSnapshot.Element("启用工位1")));
            protection.Invoke(form, new object[] { true });
            Check((bool)form.ParameterSnapshot.Element("启用工位1").Element("ReadOnly")
                && !modes.Cast<Lead.CPrim.BaseParam.Property>().First(p => p.Name == "启用工位1").ReadOnly, "DT 不解锁已被模式覆盖的主参数");
            protection.Invoke(form, new object[] { false });
            Check(modes.Cast<Lead.CPrim.BaseParam.Property>().First(p => p.Name == "启用工位1").ReadOnly, "模式开关非 DT 也只读");
            form.UIShow(false);
            protection.Invoke(form, new object[] { true });
            var stationGrid = (PropertyGrid)typeof(DynamicParamForm).GetField("pg", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(form);
            Check(!stationGrid.Enabled && form.Save(null, false) == -1, "DT 不绕过运行禁用");
            form.UIShow(true);
            form.CanSaveParameters = () => false;
            Check(form.Save(null, false) == -1, "DT 不绕过保存权限上下文");
            form.CanSaveParameters = null;
            Check(form.Init(dir, form.GetRunMode()) == 0, "工位保护测试后重新加载");
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
