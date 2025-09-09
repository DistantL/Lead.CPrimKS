using System.Windows.Forms;

namespace Lead.CPrim.ShowCommon
{
    partial class ShowDisplay
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
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.pBoxIcon = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dispalyConfigUIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowConfigUi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHideConfigUi = new System.Windows.Forms.ToolStripMenuItem();
            this.displayOutputUIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowOutputUi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHideOutputUi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemoveShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIcon)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.pBoxIcon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(56, 86);
            this.panel1.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtName.Location = new System.Drawing.Point(0, 60);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(56, 31);
            this.txtName.TabIndex = 1;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtName, "点击Enter键保存名称");
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbName_KeyUp);
            // 
            // pBoxIcon
            // 
            this.pBoxIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pBoxIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pBoxIcon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pBoxIcon.Location = new System.Drawing.Point(0, 0);
            this.pBoxIcon.Name = "pBoxIcon";
            this.pBoxIcon.Size = new System.Drawing.Size(56, 60);
            this.pBoxIcon.TabIndex = 0;
            this.pBoxIcon.TabStop = false;
            this.toolTip1.SetToolTip(this.pBoxIcon, "点击Enter键保存名称");
            this.pBoxIcon.DoubleClick += new System.EventHandler(this.pBoxIcon_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dispalyConfigUIToolStripMenuItem,
            this.displayOutputUIToolStripMenuItem,
            this.tsmRemoveShow});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(241, 127);
            // 
            // dispalyConfigUIToolStripMenuItem
            // 
            this.dispalyConfigUIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowConfigUi,
            this.tsmHideConfigUi});
            this.dispalyConfigUIToolStripMenuItem.Name = "dispalyConfigUIToolStripMenuItem";
            this.dispalyConfigUIToolStripMenuItem.Size = new System.Drawing.Size(240, 30);
            this.dispalyConfigUIToolStripMenuItem.Text = "配置界面";
            // 
            // tsmShowConfigUi
            // 
            this.tsmShowConfigUi.Name = "tsmShowConfigUi";
            this.tsmShowConfigUi.Size = new System.Drawing.Size(146, 34);
            this.tsmShowConfigUi.Text = "显示";
            this.tsmShowConfigUi.Click += new System.EventHandler(this.tsmShowConfigUi_Click);
            // 
            // tsmHideConfigUi
            // 
            this.tsmHideConfigUi.Name = "tsmHideConfigUi";
            this.tsmHideConfigUi.Size = new System.Drawing.Size(146, 34);
            this.tsmHideConfigUi.Text = "隐藏";
            this.tsmHideConfigUi.Click += new System.EventHandler(this.tsmHideConfigUi_Click);
            // 
            // displayOutputUIToolStripMenuItem
            // 
            this.displayOutputUIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowOutputUi,
            this.tsmHideOutputUi});
            this.displayOutputUIToolStripMenuItem.Name = "displayOutputUIToolStripMenuItem";
            this.displayOutputUIToolStripMenuItem.Size = new System.Drawing.Size(240, 30);
            this.displayOutputUIToolStripMenuItem.Text = "输出界面";
            // 
            // tsmShowOutputUi
            // 
            this.tsmShowOutputUi.Name = "tsmShowOutputUi";
            this.tsmShowOutputUi.Size = new System.Drawing.Size(146, 34);
            this.tsmShowOutputUi.Text = "显示";
            this.tsmShowOutputUi.Click += new System.EventHandler(this.tsmShowOutputUi_Click);
            // 
            // tsmHideOutputUi
            // 
            this.tsmHideOutputUi.Name = "tsmHideOutputUi";
            this.tsmHideOutputUi.Size = new System.Drawing.Size(146, 34);
            this.tsmHideOutputUi.Text = "隐藏";
            this.tsmHideOutputUi.Click += new System.EventHandler(this.tsmHideOutputUi_Click);
            // 
            // tsmRemoveShow
            // 
            this.tsmRemoveShow.Name = "tsmRemoveShow";
            this.tsmRemoveShow.Size = new System.Drawing.Size(240, 30);
            this.tsmRemoveShow.Text = "移除";
            this.tsmRemoveShow.Click += new System.EventHandler(this.tsmRemoveShow_Click);
            // 
            // ShowDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ShowDisplay";
            this.Size = new System.Drawing.Size(56, 86);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIcon)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public Panel panel1;
        public TextBox txtName;
        public PictureBox pBoxIcon;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem dispalyConfigUIToolStripMenuItem;
        private ToolStripMenuItem displayOutputUIToolStripMenuItem;
        private ToolStripMenuItem tsmRemoveShow;
        private ToolStripMenuItem tsmShowConfigUi;
        private ToolStripMenuItem tsmHideConfigUi;
        private ToolStripMenuItem tsmShowOutputUi;
        private ToolStripMenuItem tsmHideOutputUi;
        private ToolTip toolTip1;
    }
}
