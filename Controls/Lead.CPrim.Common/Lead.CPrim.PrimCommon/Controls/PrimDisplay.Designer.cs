using System.Windows.Forms;

namespace Lead.CPrim.PrimCommon
{
    partial class PrimDisplay
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
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayOutputUIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.displayDebugUIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiChangeIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyUp);
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
            this.displayDebugUIToolStripMenuItem,
            this.toolStripSeparator1,
            this.tsmiChangeIcon,
            this.toolStripSeparator2,
            this.removeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 166);
            // 
            // dispalyConfigUIToolStripMenuItem
            // 
            this.dispalyConfigUIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.hideToolStripMenuItem});
            this.dispalyConfigUIToolStripMenuItem.Name = "dispalyConfigUIToolStripMenuItem";
            this.dispalyConfigUIToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.dispalyConfigUIToolStripMenuItem.Text = "配置界面";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(146, 34);
            this.showToolStripMenuItem.Text = "显示";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(146, 34);
            this.hideToolStripMenuItem.Text = "隐藏";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // displayOutputUIToolStripMenuItem
            // 
            this.displayOutputUIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem1,
            this.hideToolStripMenuItem1});
            this.displayOutputUIToolStripMenuItem.Name = "displayOutputUIToolStripMenuItem";
            this.displayOutputUIToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.displayOutputUIToolStripMenuItem.Text = "输出界面";
            // 
            // showToolStripMenuItem1
            // 
            this.showToolStripMenuItem1.Name = "showToolStripMenuItem1";
            this.showToolStripMenuItem1.Size = new System.Drawing.Size(146, 34);
            this.showToolStripMenuItem1.Text = "显示";
            this.showToolStripMenuItem1.Click += new System.EventHandler(this.showToolStripMenuItem1_Click);
            // 
            // hideToolStripMenuItem1
            // 
            this.hideToolStripMenuItem1.Name = "hideToolStripMenuItem1";
            this.hideToolStripMenuItem1.Size = new System.Drawing.Size(146, 34);
            this.hideToolStripMenuItem1.Text = "隐藏";
            this.hideToolStripMenuItem1.Click += new System.EventHandler(this.hideToolStripMenuItem1_Click);
            // 
            // displayDebugUIToolStripMenuItem
            // 
            this.displayDebugUIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem2,
            this.hideToolStripMenuItem2});
            this.displayDebugUIToolStripMenuItem.Name = "displayDebugUIToolStripMenuItem";
            this.displayDebugUIToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.displayDebugUIToolStripMenuItem.Text = "调试界面";
            // 
            // showToolStripMenuItem2
            // 
            this.showToolStripMenuItem2.Name = "showToolStripMenuItem2";
            this.showToolStripMenuItem2.Size = new System.Drawing.Size(146, 34);
            this.showToolStripMenuItem2.Text = "显示";
            this.showToolStripMenuItem2.Click += new System.EventHandler(this.showToolStripMenuItem2_Click);
            // 
            // hideToolStripMenuItem2
            // 
            this.hideToolStripMenuItem2.Name = "hideToolStripMenuItem2";
            this.hideToolStripMenuItem2.Size = new System.Drawing.Size(146, 34);
            this.hideToolStripMenuItem2.Text = "隐藏";
            this.hideToolStripMenuItem2.Click += new System.EventHandler(this.hideToolStripMenuItem2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiChangeIcon
            // 
            this.tsmiChangeIcon.Name = "tsmiChangeIcon";
            this.tsmiChangeIcon.Size = new System.Drawing.Size(152, 30);
            this.tsmiChangeIcon.Text = "切换图标";
            this.tsmiChangeIcon.Click += new System.EventHandler(this.tsmiChangeIcon_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.removeToolStripMenuItem.Text = "移除";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // PrimDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PrimDisplay";
            this.Size = new System.Drawing.Size(56, 86);
            this.Load += new System.EventHandler(this.PrimDisplay_Load);
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
        private ToolStripMenuItem displayDebugUIToolStripMenuItem;
        private ToolStripMenuItem removeToolStripMenuItem;
        private ToolStripMenuItem showToolStripMenuItem;
        private ToolStripMenuItem hideToolStripMenuItem;
        private ToolStripMenuItem showToolStripMenuItem1;
        private ToolStripMenuItem hideToolStripMenuItem1;
        private ToolStripMenuItem showToolStripMenuItem2;
        private ToolStripMenuItem hideToolStripMenuItem2;
        private ToolTip toolTip1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmiChangeIcon;
        private ToolStripSeparator toolStripSeparator2;
    }
}
