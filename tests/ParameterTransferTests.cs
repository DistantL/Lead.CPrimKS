using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;
using Lead.CPrim.BaseParam;

internal static class ParameterTransferTests
{
    private static int checks;
    private static string root;
    private static void Check(bool value, string message)
    {
        if (!value) throw new Exception(message);
        checks++;
    }
    private static void Reject(Action action, string message)
    {
        bool rejected = false;
        try { action(); } catch (Exception) { rejected = true; }
        Check(rejected, message);
    }
    private static XElement P(string name, string type = "INT", string value = "42")
    {
        return new XElement(name, new XElement("Name", name), new XElement("DisplayName", "显示 " + name),
            new XElement("Category", "Global"), new XElement("ReadOnly", false), new XElement("Visible", true),
            new XElement("Value", value), new XElement("valType", type), new XElement("CombMsg", "A,B"),
            new XElement("CustomMetadata", "keep"));
    }
    private sealed class Pair
    {
        public string Source, Target;
        public XElement Global;
        public ParameterTransferSession Session;
        public Pair()
        {
            string dir = Path.Combine(root, Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(dir);
            Source = Path.Combine(dir, "CommonParam.para");
            Target = Path.Combine(dir, "AudioAirPods.para");
            Global = new XElement("Para", P("Speed"), P("Flag", "BOOL", "true"), P("运行模式", "STRING", "正常生产"));
            Global.Save(Source);
            var group = P("Existing");
            group.SetElementValue("Category", "Product group");
            new XElement("Para", group).Save(Target);
            Session = new ParameterTransferSession(Source, Target, "AudioAirPods");
        }
        public void Stage(string name)
        {
            Session.Stage(Global.Element(name), "Product group");
            Global.Element(name).Remove();
        }
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
        try { Run(output); }
        catch (Exception ex) { Console.WriteLine(ex.GetType().Name + ": " + ex.Message + "\n" + ex.StackTrace); Environment.ExitCode = 1; }
    }
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void Run(string output)
    {
        root = Path.Combine(Path.GetTempPath(), "ParameterTransferTests-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        var pair = new Pair();
        byte[] before = File.ReadAllBytes(pair.Source);
        pair.Stage("Speed");
        pair.Stage("Flag");
        Check(pair.Session.HasPending && File.ReadAllBytes(pair.Source).SequenceEqual(before), "确定不写文件");
        Check(XElement.Load(pair.Target).Elements().Count() == 1, "暂存不更改产品");
        pair.Session.Save(pair.Global);
        Check(!pair.Session.HasPending && XElement.Load(pair.Source).Element("Speed") == null, "保存移除全局");
        var speed = XElement.Load(pair.Target).Element("Speed");
        Check((string)speed.Element("Category") == "Product group" && (string)speed.Element("CustomMetadata") == "keep", "只改分组保留附加信息");
        Check((string)speed.Element("Value") == "42" && (string)speed.Element("DisplayName") == "显示 Speed", "值和显示名称保留");
        pair.Session.Save(pair.Global);
        Check(XElement.Load(pair.Target).Elements("Speed").Count() == 1, "再次保存不重复");
        Check(Directory.GetFiles(Path.GetDirectoryName(pair.Source)).Length == 2, "保存不生成备份或临时文件");

        pair = new Pair();
        Reject(() => pair.Session.Stage(P("Existing"), "Product group"), "同名拒绝");
        Reject(() => pair.Session.Stage(P("运行模式"), "Product group"), "运行模式拒绝");
        Reject(() => pair.Session.Stage(P("New"), "   "), "空白分组拒绝");
        pair.Stage("Speed");
        Reject(() => pair.Session.Stage(P("Speed"), "Product group"), "重复待转移拒绝");
        File.AppendAllText(pair.Target, " ");
        Reject(() => pair.Session.Save(pair.Global), "外部修改拒绝");
        Check(pair.Session.HasPending && XElement.Load(pair.Source).Element("Speed") != null, "拒绝后保留待转移和源文件");

        pair = new Pair();
        pair.Stage("Speed");
        before = File.ReadAllBytes(pair.Source);
        byte[] targetBefore = File.ReadAllBytes(pair.Target);
        using (var lockedSource = new FileStream(pair.Source, FileMode.Open, FileAccess.Read, FileShare.Read))
            Reject(() => pair.Session.Save(pair.Global), "第二份文件替换失败");
        Check(File.ReadAllBytes(pair.Source).SequenceEqual(before) && !File.ReadAllBytes(pair.Target).SequenceEqual(targetBefore), "失败不回滚已写入的目标");
        Check(pair.Session.HasPending && pair.Session.IsFaulted, "失败保留清单并锁定会话");
        Reject(() => pair.Session.Save(pair.Global), "失败会话不可重试");
        Reject(() => pair.Session.Stage(P("NewValue"), "Product group"), "失败会话不可继续暂存");
        Check(Directory.GetFiles(Path.GetDirectoryName(pair.Source)).Length == 2, "失败不生成备份和临时文件");

        pair = new Pair();
        pair.Stage("Speed");
        before = File.ReadAllBytes(pair.Source);
        targetBefore = File.ReadAllBytes(pair.Target);
        int refreshed = 0;
        pair.Session.RefreshCommitted = (g, p) => { if (++refreshed == 1) throw new Exception("刷新失败模拟"); };
        Reject(() => pair.Session.Save(pair.Global), "刷新失败不报成功");
        Check(refreshed == 1 && !File.ReadAllBytes(pair.Source).SequenceEqual(before)
            && !File.ReadAllBytes(pair.Target).SequenceEqual(targetBefore), "刷新失败不回滚已保存文件或刷新旧值");
        Check(pair.Session.IsFaulted, "刷新失败会话锁定");

        pair = new Pair();
        pair.Stage("Speed");
        pair.Session.ValidateContext = () => { throw new Exception("设备状态变化"); };
        Reject(() => pair.Session.Save(pair.Global), "提交前再次检查上下文");
        Check(XElement.Load(pair.Source).Element("Speed") != null, "上下文失败不写入");

        // COMB、自定义类型和点位采用 XML 深拷贝，不借用原 Value 引用。
        pair = new Pair();
        var combo = P("Choice", "Comb", "A");
        var nested = P("Struct", "UserDefine", "");
        nested.Element("Value").Add(P("Child", "STRING", "nested"));
        var point = new Property { Name = "Position", DisplayName = "位置", Category = "Global",
            valType = DataType.Point, Cartesian = "XYZ",
            Value = new List<Lead.CPrim.Interfaces.Ele.Pos> { new Lead.CPrim.Interfaces.Ele.Pos("P1", 1, 2, 3, 4, 5, 6) } }.PropToXElment();
        foreach (var property in new[] { combo, nested, point })
            pair.Session.Stage(property, "Product group");
        combo.SetElementValue("Value", "B");
        nested.Element("Value").Element("Child").SetElementValue("Value", "changed");
        pair.Session.Save(pair.Global);
        var target = XElement.Load(pair.Target);
        Check((string)target.Element("Choice").Element("Value") == "A", "下拉值深拷贝");
        Check((string)target.Element("Struct").Element("Value").Element("Child").Element("Value") == "nested", "嵌套值深拷贝");
        Check((string)target.Element("Position").Element("Cartesian") == "XYZ", "轴组保留");
        Check(((List<Lead.CPrim.Interfaces.Ele.Pos>)((Property)target.Element("Position")).Value).Single().X == 1, "点位坐标保留");

        pair = new Pair();
        pair.Session.Stage(pair.Global.Element("Speed"), "  New group  ");
        pair.Global.Element("Speed").Remove();
        Check(pair.Session.Groups.Contains("New group"), "新分组进入待转移会话下拉选项");
        Check(!XElement.Load(pair.Target).Elements().Any(p => (string)p.Element("Category") == "New group"), "暂存新组不写文件");
        pair.Session.Stage(pair.Global.Element("Flag"), "New group");
        pair.Global.Element("Flag").Remove();
        pair.Session.Save(pair.Global);
        Check(XElement.Load(pair.Target).Elements().Count(p => (string)p.Element("Category") == "New group") == 2, "保存创建新组且复用同组");
        pair = new Pair();
        new XElement("Para").Save(pair.Target);
        pair.Session = new ParameterTransferSession(pair.Source, pair.Target, "AudioAirPods");
        Check(pair.Session.Groups.Length == 0, "空产品无已有分组");
        pair.Session.Stage(pair.Global.Element("Speed"), "First group");
        pair.Global.Element("Speed").Remove();
        pair.Session.Save(pair.Global);
        Check((string)XElement.Load(pair.Target).Element("Speed").Element("Category") == "First group", "空产品也能新建分组");
        pair = new Pair();

        var viewPair = new Pair();
        var targetView = XElement.Load(viewPair.Target);
        targetView.Element("Existing").SetElementValue("Value", 999);
        viewPair.Session.SetViewSnapshots(viewPair.Global, targetView);
        viewPair.Stage("Speed");
        viewPair.Session.Save(viewPair.Global);
        Check((int)XElement.Load(viewPair.Target).Element("Existing").Element("Value") == 999, "转移保留目标内存模式值而非磁盘旧值");
        viewPair = new Pair();
        targetView = XElement.Load(viewPair.Target);
        targetView.Element("Existing").SetElementValue("Value", 888);
        viewPair.Session.SetViewSnapshots(viewPair.Global, targetView);
        viewPair.Stage("Speed");
        int viewRefreshes = 0;
        XElement restoredView = null;
        viewPair.Session.RefreshCommitted = (s, t) =>
        {
            if (++viewRefreshes == 1) throw new Exception("UI故障");
            restoredView = t;
        };
        Reject(() => viewPair.Session.Save(viewPair.Global), "快照会话刷新失败");
        Check(restoredView == null && viewRefreshes == 1 && viewPair.Session.IsFaulted
            && (int)XElement.Load(viewPair.Target).Element("Existing").Element("Value") == 888, "刷新失败不回滚内存快照或文件");
        var reversePair = new Pair();
        var reverse = new ParameterTransferSession(reversePair.Target, reversePair.Source, "AudioAirPods", true);
        Check(reverse.ToGlobal && reverse.Groups.Contains("Global"), "反向会话使用目标全局分组");
        Reject(() => reverse.Stage(P("Speed"), "Global"), "反向拒绝目标全局同名");
        reverse.Stage(XElement.Load(reversePair.Target).Element("Existing"), "New global group");
        var reverseSource = new XElement("Para");
        var oldGlobal = File.ReadAllBytes(reversePair.Source);
        var oldProduct = File.ReadAllBytes(reversePair.Target);
        using (var lockedProduct = new FileStream(reversePair.Target, FileMode.Open, FileAccess.Read, FileShare.Read))
            Reject(() => reverse.Save(reverseSource), "反向源替换失败");
        Check(!File.ReadAllBytes(reversePair.Source).SequenceEqual(oldGlobal)
            && File.ReadAllBytes(reversePair.Target).SequenceEqual(oldProduct), "反向失败不回滚先写入的全局文件");
        Check(reverse.IsFaulted && reverse.HasPending, "反向失败会话锁定");
        Reject(() => reverse.Save(reverseSource), "反向失败不可直接重试");
        reversePair = new Pair();
        reverse = new ParameterTransferSession(reversePair.Target, reversePair.Source, "AudioAirPods", true);
        reverse.Stage(XElement.Load(reversePair.Target).Element("Existing"), "New global group");
        bool allowed = false;
        reverse.ValidateTransferName = name => { if (!allowed) throw new InvalidOperationException("模式新增引用"); };
        Reject(() => reverse.Save(reverseSource), "反向提交复查变量引用");
        allowed = true;
        reverse.Save(reverseSource);
        Check(XElement.Load(reversePair.Target).Element("Existing") == null
            && (string)XElement.Load(reversePair.Source).Element("Existing").Element("Category") == "New global group", "反向新增全局分组并移除产品变量");
        reverse.Save(reverseSource);
        Check(XElement.Load(reversePair.Source).Elements("Existing").Count() == 1, "反向重复保存不重复");
        using (var globalDialog = new TransferPropertyForm((Property)P("Speed"), new[] { "Global" }, "AudioAirPods", true))
        {
            Check(globalDialog.Text == "转移为全局参数", "反向弹窗标题");
            Check(globalDialog.Controls.Find("lbWarning", false).Single().Text.Contains("换型参数读写改为全局参数读写"), "反向调用警告");
        }

        using (var dialog = new TransferPropertyForm((Property)P("Speed"), new[] { "Product group" }, "AudioAirPods"))
        {
            Check(dialog.Text == "转移为换型参数", "弹窗标题");
            Check(dialog.Controls.OfType<Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox>().Count(t => t.ReadOnly) == 2, "类型和索引名称只读");
            var displayBox = (Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox)dialog.Controls.Find("tbDisplay", false).Single();
            Check(!displayBox.ReadOnly, "转移显示名称可编辑");
            displayBox.Text = "转移后的显示名称";
            Check(dialog.SelectedDisplayName == "转移后的显示名称", "转移读取编辑后的显示名称");
            var groupBox = dialog.Controls.OfType<Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox>().Single();
            Check(groupBox.DropDownStyle == Sunny.UI.UIDropDownStyle.DropDown, "分组可选择和输入");
            Check(string.IsNullOrEmpty(dialog.SelectedGroup), "不自动选择目标分组");
            groupBox.SelectedIndex = 0;
            Check(dialog.SelectedGroup == "Product group", "选择已有分组");
            groupBox.Text = "  Typed group  ";
            Check(dialog.SelectedGroup == "Typed group", "输入新分组并去除首尾空白");
            using (var reference = new NewProperty())
                Check(dialog.TitleColor == reference.TitleColor && dialog.BackColor == reference.BackColor
                    && dialog.Font.Equals(reference.Font), "与修改属性窗体颜色字体一致");
            dialog.ShowInTaskbar = false;
            dialog.StartPosition = FormStartPosition.Manual;
            dialog.Location = new Point(-30000, -30000);
            dialog.Show();
            Application.DoEvents();
            using (var bitmap = new Bitmap(dialog.Width, dialog.Height))
            {
                dialog.DrawToBitmap(bitmap, dialog.ClientRectangle);
                bitmap.Save(Path.Combine(output, "parameter-transfer-dialog.png"));
            }
            dialog.Close();
        }
        using (var editor = new ParamCfg(pair.Source))
        {
            var field = typeof(ParamCfg).GetField("transferItem", BindingFlags.NonPublic | BindingFlags.Instance);
            Check(!((ToolStripMenuItem)field.GetValue(editor)).Available && editor.TransferSession == null, "普通编辑器默认不显示转移");
            editor.ShowInTaskbar = false;
            editor.StartPosition = FormStartPosition.Manual;
            editor.Location = new Point(-30000, -30000);
            editor.Show();
            Application.DoEvents();
            var grid = (PropertyGrid)typeof(ParamCfg).GetField("propertyGrid1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(editor);
            var rootItem = grid.SelectedGridItem;
            while (rootItem.Parent != null) rootItem = rootItem.Parent;
            var category = rootItem.GridItems.Cast<GridItem>().First(p => p.GridItemType == GridItemType.Category);
            var selection = typeof(ParamCfg).GetMethod("SelectedTopLevelProperty", BindingFlags.NonPublic | BindingFlags.Instance);
            grid.SelectedGridItem = category;
            Check(selection.Invoke(editor, null) == null, "分类标题不可转移");
            grid.SelectedGridItem = category.GridItems.Cast<GridItem>().First(p => p.PropertyDescriptor.Name == "Speed");
            Check(((Property)selection.Invoke(editor, null)).Name == "Speed", "顶层属性可转移");
            editor.TransferSession = new ParameterTransferSession(pair.Source, pair.Target, "AudioAirPods");
            typeof(ContextMenuStrip).GetMethod("OnOpening", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(grid.ContextMenuStrip, new object[] { new System.ComponentModel.CancelEventArgs() });
            Check(((ToolStripMenuItem)field.GetValue(editor)).Available, "全局上下文启用转移菜单");
            grid.SelectedGridItem = category.GridItems.Cast<GridItem>().First(p => p.PropertyDescriptor.Name == "运行模式");
            typeof(ContextMenuStrip).GetMethod("OnOpening", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(grid.ContextMenuStrip, new object[] { new System.ComponentModel.CancelEventArgs() });
            Check(!((ToolStripMenuItem)field.GetValue(editor)).Enabled, "保留参数菜单禁用");
            editor.Close();
        }
        Console.WriteLine("PASS " + checks + " transfer checks. Temporary data: " + root);
    }
}
