using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.BaseParam
{
    public partial class ParamCfg
    {
        private ToolStripMenuItem transferItem;
        public ParameterTransferSession TransferSession { get; set; }
        public Action<Action> SaveGuard { get; set; }
        public Func<XElement, XElement> PrepareDocument { get; set; }
        public void SetDocument(XElement document)
        {
            xel = new XElement(document);
            UpdateUi();
        }

        private void InitializeTransferMenu()
        {
            transferItem = new ToolStripMenuItem();
            transferItem.Text = NLocalizer.GetString("Param_TransferMenu", "转移变量");
            transferItem.Visible = false;
            transferItem.Click += TransferItem_Click;
            propertyGrid1.ContextMenuStrip.Items.Add(transferItem);
            propertyGrid1.ContextMenuStrip.Opening += (sender, args) =>
            {
                transferItem.Text = NLocalizer.GetString("Param_TransferMenu", "转移变量");
                transferItem.Visible = TransferSession != null;
                var selected = SelectedTopLevelProperty();
                transferItem.Enabled = selected != null && selected.Name != "运行模式";
            };
        }

        private Property SelectedTopLevelProperty()
        {
            var selected = propertyGrid1.SelectedGridItem;
            if (selected == null || selected.GridItemType != GridItemType.Property
                || selected.PropertyDescriptor == null || selected.Parent == null
                || (selected.Parent.GridItemType != GridItemType.Root
                    && (selected.Parent.GridItemType != GridItemType.Category || selected.Parent.Parent == null
                        || selected.Parent.Parent.GridItemType != GridItemType.Root)))
                return null;
            return Pmc_St.Cast<Property>().FirstOrDefault(p => p.Name == selected.PropertyDescriptor.Name);
        }

        // 保留原 XML 的附加信息，并覆盖编辑器中的当前属性值。
        private XElement GetEditedNode(Property property)
        {
            var edited = property.PropToXElment();
            var original = xel.Elements().FirstOrDefault(p => (string)p.Element("Name") == property.Name);
            var result = original == null ? new XElement(edited) : new XElement(original);
            foreach (var child in edited.Elements())
            {
                var old = result.Element(child.Name);
                if (old == null) result.Add(new XElement(child));
                else old.ReplaceWith(new XElement(child));
            }
            return result;
        }

        private void TransferItem_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = SelectedTopLevelProperty();
                if (TransferSession == null || selected == null) return;
                TransferSession.CheckName(selected.Name);
                using (var dialog = new TransferPropertyForm(selected, TransferSession.Groups, TransferSession.Product, TransferSession.ToGlobal))
                {
                    if (dialog.ShowDialog(this) != DialogResult.OK) return;
                    var transferred = GetEditedNode(selected);
                    transferred.SetElementValue("DisplayName", dialog.SelectedDisplayName);
                    TransferSession.Stage(transferred, dialog.SelectedGroup);
                    Pmc_St.Remove(selected.Name);
                    propertyGrid1.SelectedObject = null;
                    propertyGrid1.SelectedObject = Pmc_St;
                }
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message, Text); }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (TransferSession != null && TransferSession.HasPending
                && MessageBox.Show(this, NLocalizer.GetString("Param_TransferDiscard", "放弃未保存的修改？待转移参数不会写入文件。"),
                    Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                e.Cancel = true;
            base.OnFormClosing(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            NLocalizer.LanguageChanged -= OnLanguageChanged;
            base.OnFormClosed(e);
        }
    }
}
