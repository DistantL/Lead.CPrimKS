using Lead.CPrim.FaiHelper.ComplexFais;
using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Lead.CPrim.FaiHelper
{
    /// <summary>FAI参数配置UI</summary>
	public partial class FaiConfigControl : UserControl
    {
        #region Field
        /// <summary>FAI管理器</summary>
        private FaiManager _instance;
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public FaiConfigControl()
        {
            InitializeComponent();
            tlpMain.SetDoubleBuffered();
            tsFaiConfig.SetDoubleBuffered();
            flpSimpleFaiConfigs.SetDoubleBuffered();
            flpComplexFaiConfigs.SetDoubleBuffered();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="instance">FAI管理器</param>
        public FaiConfigControl(FaiManager instance) : this()
        {
            _instance = instance;
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void FaiConfigControl_Load(object sender, EventArgs e)
        {
            Invoke(new Action(Action1));
            void Action1()
            {
                //双缓存设置
                flpComplexFaiConfigs.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(flpComplexFaiConfigs, true, null);

                tsCmbProduct.SelectedIndexChanged -= tsCmbProduct_SelectedIndexChanged;
                LoadTbCmb(_instance);
                tsCmbProduct.SelectedIndexChanged += tsCmbProduct_SelectedIndexChanged;
                LoadControls(_instance);

                if (_instance.CurrentProduct != null && _instance.CurrentProduct.ComplexConfigs.Count > 0)
                {
                    tabMain.SelectedTab = tpComplexFaiConfigs;
                }
            }
        }
        #endregion



        #region Button_Event
        /// <summary>产品切换</summary>
        private void tsCmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tsCmbProduct.SelectedItem != null && _instance.ChangeCurrentProduct(tsCmbProduct.SelectedItem.ToString()) != 0)
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_FaiHelper_FaiConfigControl_ErrMes_NoFindProductionInfo", "未找到该产品信息"));
            }
        }
        /// <summary>增加产品</summary>
        private void tsBtnAddProduct_Click(object sender, EventArgs e)
        {
            NewProduct f = new NewProduct();
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                string newName = f.GetNewProductName();
                _instance.AddNewProdcut(newName);
                LoadTbCmb(_instance);
            }
        }
        /// <summary>删除产品</summary>
        private void tsDelProduct_Click(object sender, EventArgs e)
        {
            if (tsCmbProduct.SelectedItem == null || string.IsNullOrEmpty(tsCmbProduct.SelectedItem.ToString()))
            {
                MessageBox.Show(this, NLocalizer.GetString("Lead_CPrim_FaiHelper_FaiConfigControl_ErrMes_NoSelectProduction", "未选择产品"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _instance.RemoveProdcut(tsCmbProduct.SelectedItem.ToString());
        }
        /// <summary>复制当前产品的所有数据至新产品</summary>
        private void tsBtnCopyProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_instance.CurrentProductName))
            {
                MessageBox.Show(this, NLocalizer.GetString("Lead_CPrim_FaiHelper_FaiConfigControl_ErrMes_CurrentProductionIsEmptyNoCopy", "当前产品为空，无法复制数据"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            NewProduct f = new NewProduct();
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                string newName = f.GetNewProductName();
                _instance.CopyProdcut(newName);
                LoadTbCmb(_instance);
            }
        }
        /// <summary>添加简单FAI配置</summary>
        private void tsBtnAddSimpleFaiConfigs_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_instance.CurrentProductName))
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_FaiHelper_FaiConfigControl_ErrMes_CurrentProductionIsEmptyNoAdd", "当前产品为空，不允许添加数据"));
                return;
            }

            SimpleFaiConfigs simpleFaiConfigs = new SimpleFaiConfigs("", _instance);
            simpleFaiConfigs.ConfigUi.Dock = DockStyle.Top;

            _instance.CurrentProduct.SimpleConfigs.TryAdd(simpleFaiConfigs.Gid, simpleFaiConfigs);

            flpSimpleFaiConfigs.Controls.Add(simpleFaiConfigs.ConfigUi);
        }
        /// <summary>添加复杂FAI配置</summary>
        private void tsBtnAddComplexFaiConfigs_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_instance.CurrentProductName))
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_FaiHelper_FaiConfigControl_ErrMes_CurrentProductionIsEmptyNoAdd", "当前产品为空，不允许添加数据"));
                return;
            }

            NewComplexForm newComplexForm = new NewComplexForm();
            DialogResult dialogResult = newComplexForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                ComplexFaiConfigs complexFaiConfigs = new ComplexFaiConfigs("", _instance, newComplexForm.CaveCount);
                complexFaiConfigs.ConfigUi.Dock = DockStyle.Top;

                _instance.CurrentProduct.ComplexConfigs.TryAdd(complexFaiConfigs.Gid, complexFaiConfigs);

                flpComplexFaiConfigs.Controls.Add(complexFaiConfigs.ConfigUi);
            }
        }
        /// <summary>复制选中的简单FAI配置</summary>
        private void tsBtnCopySimpleFaiConfig_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_instance.CurrentProductName))
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_FaiHelper_FaiConfigControl_ErrMes_CurrentProductionIsEmptyNoAdd", "当前产品为空，不允许添加数据"));
                return;
            }

            //简答FAI配置
            if (tabMain.SelectedTab == tpSimpleFaiConfigs)
            {
                foreach (KeyValuePair<Guid, SimpleFaiConfigs> simpleConfigs in _instance.CurrentProduct.SimpleConfigs)
                {
                    if (!simpleConfigs.Value.IsSelected)
                    {
                        continue;
                    }

                    SimpleFaiConfigs newSimpleFaiConfigs = new SimpleFaiConfigs(simpleConfigs.Value.Name + "_Copy", _instance);
                    newSimpleFaiConfigs.ConfigUi.Dock = DockStyle.Top;

                    foreach (KeyValuePair<Guid, FaiConfig> fais2 in simpleConfigs.Value.FaiConfigs)
                    {
                        newSimpleFaiConfigs.FaiConfigs.TryAdd(fais2.Key, fais2.Value);
                        if (!fais2.Value.IsParent)
                        {
                            continue;
                        }

                        foreach (KeyValuePair<Guid, ChildFaiConfig> childFais2 in fais2.Value.ChildFaiConfigs)
                        {
                            newSimpleFaiConfigs.FaiConfigs[fais2.Key].ChildFaiConfigs.TryAdd(childFais2.Key, childFais2.Value);
                        }
                    }

                    _instance.CurrentProduct.SimpleConfigs.TryAdd(newSimpleFaiConfigs.Gid, newSimpleFaiConfigs);

                    flpSimpleFaiConfigs.Controls.Add(newSimpleFaiConfigs.ConfigUi);
                }
            }

            //复杂FAI配置
            if (tabMain.SelectedTab != tpComplexFaiConfigs)
            {
                return;
            }
            foreach (KeyValuePair<Guid, ComplexFaiConfigs> complexConfig in _instance.CurrentProduct.ComplexConfigs)
            {
                if (!complexConfig.Value.IsSelected)
                {
                    continue;
                }
                ComplexFaiConfigs complexFaiConfigs = new ComplexFaiConfigs(complexConfig.Value.Name + "_Copy", _instance, complexConfig.Value.CaveCnt);
                complexFaiConfigs.ConfigUi.Dock = DockStyle.Top;
                ComplexFaiConfigs newComplexFaiConfigs = complexFaiConfigs;
                foreach (KeyValuePair<Guid, ComplexFai> fais in complexConfig.Value.FaiConfigs)
                {
                    newComplexFaiConfigs.FaiConfigs.TryAdd(fais.Key, fais.Value);
                    if (fais.Value.IsParent)
                    {
                        foreach (KeyValuePair<Guid, ComplexChildFai> childFais in fais.Value.ChildFaiConfigs)
                        {
                            newComplexFaiConfigs.FaiConfigs[fais.Key].ChildFaiConfigs.TryAdd(childFais.Key, childFais.Value);
                        }
                    }
                    newComplexFaiConfigs.FaiConfigs[fais.Key].Offsets.Clear();
                    foreach (Offset offset in fais.Value.Offsets)
                    {
                        newComplexFaiConfigs.FaiConfigs[fais.Key].Offsets.Add(offset);
                    }
                }
                _instance.CurrentProduct.ComplexConfigs.TryAdd(newComplexFaiConfigs.Gid, newComplexFaiConfigs);
                flpComplexFaiConfigs.Controls.Add(newComplexFaiConfigs.ConfigUi);
            }
        }
        /// <summary>移除已选中成员</summary>
        private void tsDelConfig_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_instance.CurrentProductName))
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_FaiHelper_FaiConfigControl_ErrMes_CurrentProductionIsEmptyNoDelete", "当前产品为空，不允许删除数据"));
                return;
            }

            if (tabMain.SelectedTab == tpSimpleFaiConfigs)
            {
                foreach (KeyValuePair<Guid, SimpleFaiConfigs> simpleConfig in _instance.CurrentProduct.SimpleConfigs)
                {
                    if (simpleConfig.Value.IsSelected)
                    {
                        flpSimpleFaiConfigs.Controls.Remove(simpleConfig.Value.ConfigUi);

                        _instance.CurrentProduct.SimpleConfigs.TryRemove(simpleConfig.Key, out var _);
                    }
                }
            }

            if (tabMain.SelectedTab != tpComplexFaiConfigs)
            {
                return;
            }
            foreach (KeyValuePair<Guid, ComplexFaiConfigs> complexConfig in _instance.CurrentProduct.ComplexConfigs)
            {
                if (complexConfig.Value.IsSelected)
                {
                    flpComplexFaiConfigs.Controls.Remove(complexConfig.Value.ConfigUi);
                    _instance.CurrentProduct.ComplexConfigs.TryRemove(complexConfig.Key, out var _);
                }
            }
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>使能状态设置</summary>
        /// <param name="enable">true：使能状态；false：非使能状态</param>
        internal void SetEnable(bool enable)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetEnable), enable);
                return;
            }
            tsFaiConfig.Enabled = enable;
            foreach (Control con in tpSimpleFaiConfigs.Controls)
            {
                con.Enabled = enable;
            }
            foreach (Control con in tpComplexFaiConfigs.Controls)
            {
                con.Enabled = enable;
            }
        }
        #endregion



        #region Others
        /// <summary>产品加载（Load事件/本身调用）</summary>
        /// <param name="instance">FAI管理器</param>
        private void LoadTbCmb(FaiManager instance)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<FaiManager>(LoadTbCmb), instance);
                return;
            }

            tsCmbProduct.Items.Clear();
            tsCmbProduct.SelectedIndex = -1;
            if (instance.Products == null)
            {
                return;
            }

            instance.Products.Keys.ToList().ForEach(p => tsCmbProduct.Items.Add(p));
            if (!string.IsNullOrEmpty(instance.CurrentProductName))
            {
                if (!tsCmbProduct.Items.Contains(instance.CurrentProductName))
                {
                    tsCmbProduct.Items.Add(instance.CurrentProductName);
                }
                tsCmbProduct.SelectedItem = instance.CurrentProductName;
            }
        }
        /// <summary>加载UI控件</summary>
        /// <param name="instance">FAI管理器</param>
        public void LoadControls(FaiManager instance)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<FaiManager>(LoadControls), instance);
                return;
            }
            flpSimpleFaiConfigs.Controls.Clear();
            flpComplexFaiConfigs.Controls.Clear();
            if (instance.CurrentProduct != null)
            {
                foreach (KeyValuePair<Guid, SimpleFaiConfigs> simpleConfig in instance.CurrentProduct.SimpleConfigs.OrderBy((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name))
                {
                    flpSimpleFaiConfigs.Controls.Add(simpleConfig.Value.ConfigUi);
                }

                foreach (KeyValuePair<Guid, ComplexFaiConfigs> complexConfig in instance.CurrentProduct.ComplexConfigs.OrderBy((KeyValuePair<Guid, ComplexFaiConfigs> p) => p.Value.Name))
                {
                    flpComplexFaiConfigs.Controls.Add(complexConfig.Value.ConfigUi);
                }
                tsCmbProduct.SelectedItem = instance.CurrentProductName;
            }
            else
            {
                tsCmbProduct.SelectedIndex = -1;
            }
        }
        #endregion


        public void OnLanguageChanged()
        {
            tsl_ProductionSelect.Text = NLocalizer.GetString("Lead_CPrim_FaiHelper_FaiConfigControl_ProductionSelect", "产品选择:");
            string str = NLocalizer.GetString("Lead_CPrim_FaiHelper_FaiConfigControl_BtnAdd", "添加");
            tpSimpleFaiConfigs.Text = NLocalizer.GetString("Lead_CPrim_FaiHelper_FaiConfigControl_SimpleFaiConfigs", "简单FAI配置");
            tpComplexFaiConfigs.Text = NLocalizer.GetString("Lead_CPrim_FaiHelper_FaiConfigControl_ComplexFaiConfigs", "复杂FAI配置");
            tsBtnAddSimpleFaiConfigs.Text = str + tpSimpleFaiConfigs.Text;
            tsBtnAddComplexFaiConfigs.Text = str + tpComplexFaiConfigs.Text;

        }
    }
}
