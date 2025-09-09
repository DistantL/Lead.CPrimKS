

using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.DropItem;
using Sunny.UI;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Lead.CPrim.ProxyTools.CustomControl
{
    [DefaultEvent("NodeSelected")]
    [DefaultProperty("Nodes")]
    [ToolboxItem(true)]
    public class UIComboTreeView : UIDropControl, IToolTip
    {
        public delegate void OnNodeSelected(object sender, TreeNode node);
        public delegate void OnNodesSelected(object sender, TreeNodeCollection nodes);

        public event OnNodeSelected NodeSelected;
        public event OnNodesSelected NodesSelected;



        #region Field

        private readonly UIComboTreeViewItem item = new UIComboTreeViewItem();
        #endregion



        #region Prop
        [Browsable(false)]
        public UITreeView TreeView => item.TreeView;

        /// <summary>
        /// 显示节点集合
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        [MergableProperty(false)]
        [Description("显示节点集合"), Category("CustomControl")]
        public TreeNodeCollection Nodes => item.TreeView.Nodes;

        /// <summary>
        /// 是否显示单选框,该属性与CanSelectRootNode互斥
        /// </summary>
        [DefaultValue(false), Description("是否显示单选框,该属性与CanSelectRootNode互斥"), Category("CustomControl")]
        public bool CheckBoxes
        {
            get => item.CheckBoxes;
            set
            {
                item.CheckBoxes = value;
                if (value)
                {
                    CanSelectRootNode = false;
                }
            }
        }

        /// <summary>
        /// 单选时是否可选择父节点,该属性与CheckBoxes互斥
        /// </summary>
        [DefaultValue(false), Description("单选时是否可选择父节点,该属性与CheckBoxes互斥"), Category("CustomControl")]
        public bool CanSelectRootNode
        {
            get => item.CanSelectRootNode;
            set
            {
                item.CanSelectRootNode = value;
                if (value)
                {
                    CheckBoxes = false;
                }
            }
        }

        /// <summary>
        /// 是否显示连线
        /// </summary>
        [DefaultValue(false), Description("是否显示连线"), Category("CustomControl")]
        public bool ShowLines
        {
            get => item.TreeView.ShowLines;
            set => item.TreeView.ShowLines = value;
        }

        [Browsable(false), DefaultValue(null)]
        public TreeNode SelectedNode
        {
            get => item.TreeView.SelectedNode;
            set
            {
                item.TreeView.SelectedNode = value;
                Text = value?.Text;
            }
        }

        /// <summary>
        /// 下拉弹框界面大小
        /// </summary>
        [DefaultValue(typeof(Size), "250, 220"), Description("下拉弹框界面大小"), Category("CustomControl")]
        public Size ItemSize { get; set; } = new Size(250, 220);
        #endregion



        #region Ctor
        public UIComboTreeView()
        {
            InitializeComponent();
            fullControlSelect = true;
        }
        #endregion



        #region Event_System
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            if (item != null) item.TreeView.Font = Font;
        }
        protected override void CreateInstance()
        {
            ItemForm = new UIDropDown(item);
        }
        protected override void ItemForm_ValueChanged(object sender, object value)
        {
            if (!CheckBoxes)
            {
                TreeNode node = (TreeNode)value;
                Text = node.Text;
                NodeSelected?.Invoke(this, node);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (TreeNode node in Nodes)
                {
                    if (node.Checked) sb.Append(node.Text + "; ");
                    AddChildNodeText(node, sb);
                }

                Text = sb.ToString();
                NodesSelected?.Invoke(this, Nodes);
            }

            Invalidate();
        }
        #endregion



        #region Method_ExternalUsing
        public Control ExToolTipControl()
        {
            return edit;
        }
        #endregion



        #region Method_InternalUsing
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // UIComboTreeView
            // 
            DropDownStyle = UIDropDownStyle.DropDownList;
            Name = "UIComboTreeView";
            Padding = new Padding(0, 0, 30, 0);
            ButtonClick += UIComboTreeView_ButtonClick;
            ResumeLayout(false);
            PerformLayout();

        }

        private void AddChildNodeText(TreeNode node, StringBuilder sb)
        {
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    if (child.Checked)
                        sb.Append(child.Text + "; ");

                    if (child.Nodes.Count > 0)
                        AddChildNodeText(child, sb);
                }
            }
        }

        private void UIComboTreeView_ButtonClick(object sender, EventArgs e)
        {
            ItemForm.Size = ItemSize;
            //item.TreeView.ExpandAll();
            item.CanSelectRootNode = CanSelectRootNode;
            item.Translate();
            item.SetDPIScale();
            ItemForm.Show(this);
        }
        #endregion
    }
}
