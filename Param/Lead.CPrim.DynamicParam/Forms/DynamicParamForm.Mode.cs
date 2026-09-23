using Lead.CPrim.BaseParam;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lead.CPrim.DynamicParam
{
    public partial class DynamicParamForm
    {
        public string GetRunMode() { return _currentMode; }
        public XElement PrepareParameterDocument(XElement document) { return DynamicParam.WithRunMode(document, _currentMode); }
        private string _currentMode = 运行模式.正常生产.ToString();
        private string _activeProduct;
        private XElement savedModeValues = new XElement("Para");
        private PropertyManageCls _modeProperties = new PropertyManageCls();
        private readonly GroupBox _modeGroup = new GroupBox { Dock = DockStyle.Fill };
        private readonly PropertyGrid _modeGrid = new PropertyGrid { Dock = DockStyle.Fill };
        private readonly Label _modeLabel = new Label { Dock = DockStyle.Top, Height = 28 };
        private readonly ToolStripMenuItem _addModeItem = new ToolStripMenuItem();
        private readonly ToolStripMenuItem _removeModeItem = new ToolStripMenuItem();

        private void InitializeModeEditor()
        {
            if (components == null) components = new System.ComponentModel.Container();
            _modeGroup.Controls.Add(_modeGrid);
            _modeGroup.Controls.Add(_modeLabel);
            tlpMain.Controls.Add(_modeGroup, 1, 2);
            var addMenu = new ContextMenuStrip(components);
            addMenu.Items.Add(_addModeItem);
            pg.ContextMenuStrip = addMenu;
            var removeMenu = new ContextMenuStrip(components);
            removeMenu.Items.Add(_removeModeItem);
            _modeGrid.ContextMenuStrip = removeMenu;
            _addModeItem.Click += (sender, args) =>
            {
                var name = pg.SelectedGridItem?.PropertyDescriptor?.Name;
                var item = Pmcls.Cast<Property>().FirstOrDefault(p => p.Name == name);
                if (!pg.Enabled || item == null || item.ReadOnly || _modeProperties.Cast<Property>().Any(p => p.Name == name))
                    return;
                var copy = (Property)new XElement(item.PropToXElment());
                copy.ReadOnly = false;
                _modeProperties.Add(copy);
                item.ReadOnly = true;
                RefreshModeEditor();
            };
            _removeModeItem.Click += (sender, args) =>
            {
                var name = _modeGrid.SelectedGridItem?.PropertyDescriptor?.Name;
                var item = _modeProperties.Cast<Property>().FirstOrDefault(p => p.Name == name);
                if (!_modeGrid.Enabled || item == null) return;
                _modeProperties.Remove(item);
                var baseItem = Pmcls.Cast<Property>().FirstOrDefault(p => p.Name == name);
                if (baseItem != null) baseItem.ReadOnly = !baseItem.Visible;
                RefreshModeEditor();
            };
        }

        private void RefreshModeEditor()
        {
            foreach (Property item in _modeProperties)
            {
                item.Category = NLocalizer.GetString(item.Category, item.Category);
                // 模式参数同样保留用户配置的显示名称。
            }
            _modeGroup.Text = NLocalizer.GetString("Param_ProductMode", "模式换型参数");
            _modeLabel.Text = (_activeProduct ?? "") + " / " + _currentMode;
            _addModeItem.Text = NLocalizer.GetString("Param_AddMode", "加入当前模式参数");
            _removeModeItem.Text = NLocalizer.GetString("Param_RemoveMode", "从当前模式参数移除");
            _modeGrid.SelectedObject = _modeProperties;
            _modeGrid.Refresh();
            pg.Refresh();
        }

        private XElement CurrentModeValues()
        {
            return new XElement("Para", _modeProperties.Cast<Property>()
                .OrderBy(p => p.Category + p.DisplayName).Select(p => p.PropToXElment()));
        }

        private void LoadProductMode(string product, string mode, bool useCurrent = false)
        {
            lock (((DynamicParam)DynamicParam.Instance).Updates.SyncRoot)
            {
                string path = ProductModeFiles.ProductPath(_productsCfgDir, product);
                FlushParameterAssignments();
                var productNode = useCurrent && product == _activeProduct ? CurrentParameterDocument() : XElement.Load(path);
                var modeNode = ProductModeFiles.ReadMode(_productsCfgDir, product, mode);
                var merged = DynamicParam.WithRunMode(ProductModeFiles.Apply(productNode, modeNode), mode);
                // 只更新运行缓存；在切换前完成类型解析，不写参数文件。
                var parsed = merged.Elements().Select(p => (Property)p).ToList();
                var modeProperties = new PropertyManageCls();
                foreach (var element in modeNode.Elements())
                {
                    var property = (Property)element;
                    property.ReadOnly = false;
                    modeProperties.Add(property);
                }
                DynamicParam.Instance.LoadSnapshot(merged, path);
                _curParaPath = path;
                _activeProduct = product;
                _currentMode = mode;
                _modeProperties = modeProperties;
                UpdateUi(merged);
                BtnRefresh_Click(null, null);
                RefreshModeEditor();
                savedModeValues = CurrentModeValues();
                parameterBinding.AcceptLoaded();
                CaptureTransferBaseline();
            }
        }

        public int ModeChange(string mode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_activeProduct)) return -1;
                LoadProductMode(_activeProduct, mode, true);
                DynamicParam.NotifyModeChanged(mode);
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("换型模式参数加载失败：" + ex.Message);
                return -1;
            }
        }
    }
}
