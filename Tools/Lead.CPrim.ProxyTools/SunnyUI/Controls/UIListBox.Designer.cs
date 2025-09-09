using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.SunnyUI.Controls
{
    partial class UIListBox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            timer?.Stop();
            timer?.Dispose();
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            listbox = new ListBoxEx();
            bar = new UIScrollBar();
            this.SuspendLayout();
            // 
            // UIListBox
            // 
            this.Name = "UIListBox";

            listbox.Parent = this;
            listbox.Dock = DockStyle.Fill;
            listbox.Show();
            listbox.Bar = bar;

            listbox.SelectedIndexChanged += Listbox_SelectedIndexChanged;
            listbox.SelectedValueChanged += Listbox_SelectedValueChanged;
            listbox.Click += Listbox_Click;
            listbox.MouseClick += Listbox_MouseClick;
            listbox.DoubleClick += Listbox_DoubleClick;
            listbox.BeforeDrawItem += Listbox_BeforeDrawItem;
            listbox.MouseDown += Listbox_MouseDown;
            listbox.MouseUp += Listbox_MouseUp;
            listbox.MouseMove += Listbox_MouseMove;
            listbox.DataSourceChanged += Listbox_DataSourceChanged;
            listbox.DisplayMemberChanged += Listbox_DisplayMemberChanged;
            listbox.ValueMemberChanged += Listbox_ValueMemberChanged;
            listbox.ItemsClear += Listbox_ItemsClear;
            listbox.ItemsAdd += Listbox_ItemsAdd;
            listbox.ItemsRemove += Listbox_ItemsRemove;
            listbox.ItemsInsert += Listbox_ItemsInsert;
            listbox.KeyPress += Listbox_KeyPress;
            listbox.KeyDown += Listbox_KeyDown;
            listbox.KeyUp += Listbox_KeyUp;
            listbox.MouseEnter += Listbox_MouseEnter;
            listbox.MouseLeave += Listbox_MouseLeave;
            listbox.DrawItem += Listbox_DrawItem;

            bar.ValueChanged += Bar_ValueChanged;
            bar.Width = SystemInformation.VerticalScrollBarWidth + 2;
            bar.Parent = this;
            bar.Dock = DockStyle.None;
            bar.Style = UIStyle.Custom;
            bar.Visible = false;
            this.ResumeLayout(false);
        }

        #endregion
        private UIScrollBar bar;
        private ListBoxEx listbox;
    }
}
