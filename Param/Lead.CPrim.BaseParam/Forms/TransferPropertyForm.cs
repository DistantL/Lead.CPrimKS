using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;

namespace Lead.CPrim.BaseParam
{
    public partial class TransferPropertyForm : UIForm
    {
        private bool toGlobal;
        public string SelectedGroup { get { return cbGroup.Text.Trim(); } }
        public string SelectedDisplayName { get { return tbDisplay.Text; } }
        public TransferPropertyForm()
        {
            InitializeComponent();
            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        public TransferPropertyForm(Property property, IEnumerable<string> groups, string product) : this()
        {
            tbType.Text = property.valType.ToString();
            tbName.Text = property.Name;
            tbDisplay.Text = property.DisplayName;
            cbGroup.Items.AddRange(groups.Distinct().Cast<object>().ToArray());
            lbProduct.Text = product;
        }
        public TransferPropertyForm(Property property, IEnumerable<string> groups, string product, bool transferToGlobal)
            : this(property, groups, product)
        {
            toGlobal = transferToGlobal;
            OnLanguageChanged();
        }
        private void OnLanguageChanged()
        {
            Text = NLocalizer.GetString("Param_TransferTitle", "转移为换型参数");
            if (toGlobal) Text = NLocalizer.GetString("Param_TransferGlobalTitle", "转移为全局参数");
            lbType.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_NewProperty_DataType", "变量类型");
            lbName.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_NewProperty_IndexName", "索引名称");
            lbDisplay.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_NewProperty_DisplayName", "显示名称");
            lbGroup.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_NewProperty_GroupName", "分组");
            lbWarning.Text = NLocalizer.GetString("Param_TransferWarning", "仅转移到当前产品。确定仅暂存，顶部保存后生效。保存后必须手动将相关全局参数读写改为换型参数读写，完成前请勿运行设备。");
            if (toGlobal) lbWarning.Text = NLocalizer.GetString("Param_TransferGlobalWarning", "从当前产品转移到全局参数。确定仅暂存，顶部保存后生效。保存后必须手动将相关换型参数读写改为全局参数读写，完成前请勿运行设备。");
            btnOK.Text = NLocalizer.GetString("Param_TransferOK", "确定");
            btnCancel.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_NewProperty_Cancel", "取消");
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SelectedGroup))
            {
                MessageBox.Show(NLocalizer.GetString("Param_TransferSelectGroup", "请选择已有分组或输入新分组名。"));
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            NLocalizer.LanguageChanged -= OnLanguageChanged;
            base.OnFormClosed(e);
        }
    }
}
