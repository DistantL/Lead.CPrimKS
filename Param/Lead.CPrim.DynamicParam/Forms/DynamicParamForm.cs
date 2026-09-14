using Lead.CPrim.BaseParam;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lead.CPrim.DynamicParam
{
    /// <summary>
    /// 换型参数
    /// </summary>
    public partial class DynamicParamForm : UIPage
    {
        /// <summary>
        /// 位置点对应的轴组 没有为null
        /// </summary>
        public Dictionary<string, string> DicCartesian = new Dictionary<string, string>();

        public Dictionary<string, List<Pos>> DicPos = new Dictionary<string, List<Pos>>();

        private bool _copyFlag;

        /// <summary>
        /// 已复制到的产品名
        /// </summary>
        private string _copyProduct;

        /// <summary>当前产品参数文件名</summary>
        private string _curParaPath;

        /// <summary>System.Environment.CurrentDirectory;</summary>
        private string _curSysDirPaht;


        /// <summary>多产品参数文件存储目录路径</summary>
        private string _productsCfgDir;

        /// <summary>用户自定义类保存路径</summary>
        private string _userDefineDir;


        /// <summary>属性表绑定对象</summary>
        private PropertyManageCls Pmcls = new PropertyManageCls();
        /// <summary>换型参数切换当前产品时发生</summary>
        public event Action<string, List<string>> OnDynamicParamChangeCurrentProduct;

        /// <summary>
        /// 参数复制标志位
        /// </summary>
        private bool CopyFlag
        {
            get
            {
                return _copyFlag;
            }
            set
            {
                _copyFlag = value;
                tsbtnCopy.Text = ((!value)
                    ? NLocalizer.GetString("Lead_CPrim_DynamicParam_DynamicParamForm_CopyParam", "复制参数")
                    : NLocalizer.GetString("Lead_CPrim_DynamicParam_DynamicParamForm_PasteParam", "粘贴参数"));
                tsbtnCopy.BackColor = ((!value) ? Color.LawnGreen : Color.DarkSlateGray);
            }
        }
        #region Ctor
        public DynamicParamForm()
        {
            InitializeComponent();
            InitializeModeEditor();
            cmbTreePos.Style = UIStyle.Gray;
            cmbTreePos.TreeView.Style = UIStyle.Gray;
            cmbTreePos.TreeView.RectColor = Color.Gray;

            _curSysDirPaht = Application.StartupPath;
            AuthorityManager.OnUpdateLevel += InstanceUpdateLevel;
            pg.MouseWheel += PropertyGrid1_MouseWheel;

            NLocalizer.LanguageChanged += OnLanguageChanged;

            DynamicParam.OnUpdateProperty += InstanceUpdateProperty;
        }
        #endregion



        #region Event_System
        private void DynamicParamForm_Load(object sender, EventArgs e)
        {
            //BtnRefresh_Click(null, null);
        }

        private void PropertyGrid1_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        #endregion



        #region Method_Instance
        /// <summary>
        /// 更新参数时发生
        /// </summary>
        /// <param name="property"></param>
        void InstanceUpdateProperty(Property property)
        {
            if (pg.InvokeRequired)
            {
                BeginInvoke(new Action<Property>(InstanceUpdateProperty), property);
            }
            else
            {
                foreach (Property p in Pmcls)
                {
                    if (p.Name == property.Name)
                    {
                        p.Value = property.Value;
                        break;
                    }
                }
                pg.SelectedObject = Pmcls;
            }
        }

        private void pnlMain_ControlRemoved(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(tlpMain);
            pnlMain.ControlRemoved -= pnlMain_ControlRemoved;
        }

        /// <summary>响应权限等级改变</summary>
        /// <param name="level">登录级别</param>
        private void InstanceUpdateLevel(OpLevel level)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<OpLevel>(InstanceUpdateLevel), level);
            }
            else if (AuthorityManager.Instance.VerifyLevel3Permission(false))
            {
                tsbtnEdit.Visible = true;
                tsbtnNewUdt.Visible = true;
                tsbtnEditUdt.Visible = true;
            }
            else if (AuthorityManager.Instance.VerifyLevel2Permission(false))
            {
                tsbtnEdit.Visible = false;
                tsbtnNewUdt.Visible = false;
                tsbtnEditUdt.Visible = false;
            }
            else
            {
                tsbtnEdit.Visible = false;
                tsbtnNewUdt.Visible = false;
                tsbtnEditUdt.Visible = false;
            }
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// 根据参数名称更新点位信息
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="poss"></param>
        internal void UpdatePos(string propertyName, List<Pos> poss)
        {
            if (propertyName.IsNullOrWhiteSpace())
            {
                DynamicParam.Instance.LogAdd(NLocalizer.GetString("ParameterNameIsNull", "参数名称为空"), LogLevel.Warn, 0, false);
                return;
            }

            foreach (Property p in Pmcls)
            {
                if (p.Name == propertyName)
                {
                    p.Value = poss;
                    break;
                }
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// 换型参数初始化
        /// </summary>
        /// <param name="productParamDir">直接包含产品参数文件的目录</param>
        /// <param name="mode">当前运行模式</param>
        /// <returns></returns>
        public int Init(string productParamDir, string mode)
        {
            tscboProducts.SelectedIndexChanged -= tscboProducts_SelectedIndexChanged;
            try
            {
                if (string.IsNullOrWhiteSpace(productParamDir)) return -1;
                _productsCfgDir = productParamDir;
                _userDefineDir = Path.Combine(productParamDir, "UserDefineStruct");
                Directory.CreateDirectory(_productsCfgDir);
                Directory.CreateDirectory(_userDefineDir);
                if (SwManager.Instance.Products == null || SwManager.Instance.Products.Count == 0) return -10;
                tscboProducts.Items.Clear();
                foreach (string product in SwManager.Instance.Products)
                {
                    string path = ProductModeFiles.ProductPath(_productsCfgDir, product);
                    if (!File.Exists(path))
                    {
                        string template = Path.Combine(Application.StartupPath, "Configs", "Template.para");
                        if (File.Exists(template)) File.Copy(template, path);
                        else new XElement("Para").Save(path);
                    }
                    tscboProducts.Items.Add(product);
                }
                string current = SwManager.Instance.CurrentProduct;
                if (!tscboProducts.Items.Contains(current)) return -10;
                LoadProductMode(current, mode ?? _currentMode);
                tscboProducts.SelectedItem = current;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("换型参数加载失败：" + ex.Message);
                return -1;
            }
            finally
            {
                if (tscboProducts.SelectedItem == null && _activeProduct != null && tscboProducts.Items.Contains(_activeProduct))
                    tscboProducts.SelectedItem = _activeProduct;
                tscboProducts.SelectedIndexChanged += tscboProducts_SelectedIndexChanged;
            }
        }

        public int Init(string productParamDir)
        {
            return Init(productParamDir, _currentMode);
        }

        [Obsolete]
        public new int Init()
        {
            return Init(_productsCfgDir, _currentMode);
        }

        public void OnLanguageChanged()
        {
            tsLblProducts.Text = NLocalizer.GetString("Lead_CPrim_DynamicParam_DynamicParamForm_ListProduction", "产品列表:");
            tsbtnEdit.Text = NLocalizer.GetString("Lead_CPrim_DynamicParam_DynamicParamForm_EditProductionParam", "编辑产品参数");
            tsbtnCopy.Text = NLocalizer.GetString("Lead_CPrim_DynamicParam_DynamicParamForm_CopyParam", "复制参数");
            tsbtnNewUdt.Text = NLocalizer.GetString("Lead_CPrim_DynamicParam_DynamicParamForm_CreateUserdefinedType", "新建自定义类型");
            tsbtnEditUdt.Text = NLocalizer.GetString("Lead_CPrim_DynamicParam_DynamicParamForm_EditUserdefinedType", "编辑自定义类型");
            gbPos.Text = NLocalizer.GetString("Lead_CPrim_DynamicParam_DynamicParamForm_gbPos", "轴组点位编辑");
            lb_PosList.Text = NLocalizer.GetString("Lead_CPrim_DynamicParam_DynamicParamForm_PosList", "点位列表:");
            buttonRefresh.Text = NLocalizer.GetString("Lead_CPrim_DynamicParam_DynamicParamForm_Refresh", "刷新");
            buttonEditPositions.Text = NLocalizer.GetString("Lead_CPrim_DynamicParam_DynamicParamForm_EditPos", "编辑");

            foreach (Property p in Pmcls)
            {
                p.Category = NLocalizer.GetString(p.Category, p.Category);
                p.DisplayName = NLocalizer.GetString(p.Name, p.DisplayName);
            }
            pg.SelectedObject = Pmcls;
            RefreshModeEditor();
        }

        /// <summary>保存</summary>
        /// <param name="path"></param>
        public int Save(string path = null, bool isManual = true)
        {
            if (!tsTitle.Enabled)
            {
                //	((UIPage)this).ShowWarningDialog("不允许进行参数保存", false);
                return -1;
            }

            if (string.IsNullOrEmpty(_activeProduct)) return -1;
            if (StringEx.IsNullOrEmpty(path)) path = _curParaPath;
            var values = new XElement("Para", Pmcls.Cast<Property>().Select(p => p.PropToXElment()));
            var modeValues = CurrentModeValues();
            var merged = ProductModeFiles.Apply(values, modeValues);
            // 与原全局模式保存方式一致：覆盖值写回产品文件。
            merged.Elements().Select(p => (Property)p).ToList();
            modeValues.Save(ProductModeFiles.ModePath(_productsCfgDir, _activeProduct, _currentMode));
            merged.Save(path);
            DynamicParam.Instance.Load(merged);
            UpdateUi(merged);
            CaptureTransferBaseline();

            BtnRefresh_Click(null, null);
            if (isManual)
            {
                UIMessageTip.ShowOk(NLocalizer.GetString("Lead_CPrim_DynamicParam_DynamicParamForm_DynamicParamSaveSuccess", "换型参数保存成功"));
            }

            return 0;
        }

        /// <summary>属性编辑_控制</summary>
        /// <param name="enable"></param>
        public void UIShow(bool enable)
        {
            if (((Control)this).InvokeRequired)
            {
                ((Control)this).BeginInvoke((Delegate)new Action<bool>(UIShow), new object[1] { enable });
            }
            else
            {
                pg.Enabled = enable;
                tsTitle.Enabled = enable;
                gbPos.Enabled = enable;
                _modeGroup.Enabled = enable;
            }
        }

        /// <summary>刷新</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            DicPos.Clear();
            DicCartesian.Clear();
            cmbTreePos.Nodes.Clear();
            Dictionary<string, List<string>> dicGroups = new Dictionary<string, List<string>>();
            foreach (object item2 in DynamicParam.Instance._xElementPropList)
            {
                Property item = (Property)item2;
                if (item.Value is List<Pos> list)
                {
                    DicPos.Add(item.DisplayName, list);
                    DicCartesian.Add(item.DisplayName, item.Cartesian);
                    if (!dicGroups.ContainsKey(item.Cartesian))
                    {
                        dicGroups.Add(item.Cartesian, new List<string> { item.DisplayName });
                    }
                    else
                    {
                        dicGroups[item.Cartesian].Add(item.DisplayName);
                    }
                }
            }

            if (dicGroups.Count > 0)
            {
                foreach (var group in dicGroups)
                {
                    TreeNode tree = new TreeNode(group.Key);
                    if (group.Value == null || group.Value.Count <= 0)
                    {
                        continue;
                    }

                    foreach (var item in group.Value)
                    {
                        tree.Nodes.Add(item);
                    }

                    cmbTreePos.Nodes.Add(tree);
                }
            }

            cmbTreePos.TreeView.ExpandAll();
            cmbTreePos.SelectedNode = null;
        }

        /// <summary>编辑</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEditPositions_Click(object sender, EventArgs e)
        {
            TreeNode tree = cmbTreePos.SelectedNode;
            if (tree == null || tree.Text.IsNullOrEmpty())
            {
                return;
            }

            PosEditorForm frm = new PosEditorForm
            {
                Pos = DicPos[tree.Text],
                Pos_Cartesian = DicCartesian[tree.Text]
            };
            frm.ShowDialog();
            if (!frm.IsSave)
            {
                return;
            }

            foreach (Property p in Pmcls)
            {
                if (p.DisplayName == tree.Text)
                {
                    p.Value = frm.Pos;
                    break;
                }
            }
        }

        /// <summary>复制参数</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnCopy_Click(object sender, EventArgs e)
        {
            if (tscboProducts.SelectedItem == null)
            {
                return;
            }
            CopyFlag = !CopyFlag;
            if (CopyFlag)
            {
                _copyProduct = tscboProducts.SelectedItem.ToString();
                return;
            }
            string curProduct = tscboProducts.SelectedItem.ToString();
            if (curProduct == _copyProduct) return;
            if (File.Exists(_productsCfgDir + "\\" + _copyProduct + ".para"))
            {
                if (File.Exists(_productsCfgDir + "\\" + curProduct + ".para"))
                {
                    File.Delete(_productsCfgDir + "\\" + curProduct + ".para");
                }
                File.Copy(_productsCfgDir + "\\" + _copyProduct + ".para", _productsCfgDir + "\\" + curProduct + ".para");
            }
            foreach (string mode in Enum.GetNames(typeof(运行模式)))
            {
                string source = ProductModeFiles.ModePath(_productsCfgDir, _copyProduct, mode);
                string target = ProductModeFiles.ModePath(_productsCfgDir, curProduct, mode);
                if (File.Exists(source)) File.Copy(source, target, true);
                else new XElement("Para").Save(target);
            }
            tscboProducts_SelectedIndexChanged(null, null);
        }

        /// <summary>编辑产品参数</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var session = CreateTransferSession?.Invoke(_curParaPath);
                using (var frm = new ParamCfg(_curParaPath))
                {
                    frm.CurSysDir = _curSysDirPaht;
                    frm.TransferSession = session;
                    frm.ShowDialog(this);
                }
                if (session == null) LoadProductMode(_activeProduct, _currentMode);
            }
            catch (Exception ex)
            {
                MessageBox.Show("编辑换型参数失败：" + ex.Message);
            }
        }

        /// <summary>编辑自定义类型</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnEditUdt_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog
            {
                InitialDirectory = _userDefineDir,
                Filter = "(Udt Param)|*.udt",
                Multiselect = false
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string udtParaPath = fd.FileName.Replace(Directory.GetCurrentDirectory(), ".");
                UdtCfg frm = new UdtCfg(udtParaPath);
                frm.ShowDialog();
            }
        }

        /// <summary>新建自定义类型</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnNewUdt_Click(object sender, EventArgs e)
        {
            NewUdt f = new NewUdt();
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                string newName = f.TagString;
                string newUdtPath = _userDefineDir + "\\" + newName + ".udt";
                File.Create(newUdtPath).Dispose();
                UdtCfg frmConfig = new UdtCfg(newUdtPath);
                frmConfig.ShowDialog();
            }
        }

        /// <summary>产品切换事件</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tscboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            tsbtnCopy.Enabled = false;
            try
            {
                if (tscboProducts.SelectedItem == null) return;
                string product = tscboProducts.SelectedItem.ToString();
                LoadProductMode(product, _currentMode);
                SwManager.Instance.ChangeCurrentProduct(product, false);
                OnDynamicParamChangeCurrentProduct?.Invoke(product, null);
            }
            catch (Exception ex)
            {
                tscboProducts.SelectedIndexChanged -= tscboProducts_SelectedIndexChanged;
                tscboProducts.SelectedItem = _activeProduct;
                tscboProducts.SelectedIndexChanged += tscboProducts_SelectedIndexChanged;
                MessageBox.Show("切换产品失败：" + ex.Message);
            }
            finally
            {
                tsbtnCopy.Enabled = true;
            }
        }

        /// <summary>产品列表双击</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsLblProducts_DoubleClick(object sender, EventArgs e)
        {
            if (SwManager.Instance.Products == null || SwManager.Instance.Products.Count <= 0)
            {
                return;
            }
            foreach (string product in SwManager.Instance.Products)
            {
                if (File.Exists(_productsCfgDir + "\\" + product + ".para") && !tscboProducts.Items.Contains(product))
                {
                    tscboProducts.Items.Add(product);
                }
            }
        }
        /// <summary>根据指定XElement刷新UI</summary>
        /// <param name="xel"></param>
        private void UpdateUi(XElement xel)
        {
            if (xel == null)
            {
                return;
            }
            List<XElement> xmlist = xel.Elements().ToList();
            Pmcls.Clear();
            foreach (XElement a in xmlist)
            {
                Pmcls.Add((Property)a);
            }
            pg.SelectedObject = Pmcls;
            OnLanguageChanged();
        } 
        #endregion
    }
}
