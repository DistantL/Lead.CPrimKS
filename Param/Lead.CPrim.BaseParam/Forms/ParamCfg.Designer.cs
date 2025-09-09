using System.Windows.Forms;

namespace Lead.CPrim.BaseParam
{
	public partial class ParamCfg 
    {
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存为UDTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.修改属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.BackColor = System.Drawing.SystemColors.Control;
            this.propertyGrid1.ContextMenuStrip = this.contextMenuStrip1;
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(2, 54);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(596, 407);
            this.propertyGrid1.TabIndex = 75;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加属性ToolStripMenuItem,
            this.删除属性ToolStripMenuItem,
            this.修改属性ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 104);
            // 
            // 添加属性ToolStripMenuItem
            // 
            this.添加属性ToolStripMenuItem.Name = "添加属性ToolStripMenuItem";
            this.添加属性ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.添加属性ToolStripMenuItem.Text = "添加属性";
            this.添加属性ToolStripMenuItem.Click += new System.EventHandler(this.添加属性ToolStripMenuItem_Click);
            // 
            // 删除属性ToolStripMenuItem
            // 
            this.删除属性ToolStripMenuItem.Name = "删除属性ToolStripMenuItem";
            this.删除属性ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.删除属性ToolStripMenuItem.Text = "删除属性";
            this.删除属性ToolStripMenuItem.Click += new System.EventHandler(this.删除属性ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.清空ToolStripMenuItem,
            this.保存为UDTToolStripMenuItem,
            this.导出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(600, 50);
            this.menuStrip1.TabIndex = 80;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加载参数ToolStripMenuItem});
            this.文件ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(66, 42);
            this.文件ToolStripMenuItem.Text = "保存";
            this.文件ToolStripMenuItem.ToolTipText = "保存当前参数";
            this.文件ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 加载参数ToolStripMenuItem
            // 
            this.加载参数ToolStripMenuItem.Name = "加载参数ToolStripMenuItem";
            this.加载参数ToolStripMenuItem.Size = new System.Drawing.Size(178, 32);
            this.加载参数ToolStripMenuItem.Text = "加载参数";
            this.加载参数ToolStripMenuItem.Visible = false;
            this.加载参数ToolStripMenuItem.Click += new System.EventHandler(this.加载参数ToolStripMenuItem_Click);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(66, 42);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // 保存为UDTToolStripMenuItem
            // 
            this.保存为UDTToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.保存为UDTToolStripMenuItem.Name = "保存为UDTToolStripMenuItem";
            this.保存为UDTToolStripMenuItem.Size = new System.Drawing.Size(127, 42);
            this.保存为UDTToolStripMenuItem.Text = "保存为UDT";
            this.保存为UDTToolStripMenuItem.Visible = false;
            this.保存为UDTToolStripMenuItem.Click += new System.EventHandler(this.保存为UDTToolStripMenuItem_Click);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(66, 42);
            this.导出ToolStripMenuItem.Text = "导出";
            this.导出ToolStripMenuItem.Click += new System.EventHandler(this.导出ToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.propertyGrid1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 465);
            this.tableLayoutPanel1.TabIndex = 81;
            // 
            // 修改属性ToolStripMenuItem
            // 
            this.修改属性ToolStripMenuItem.Name = "修改属性ToolStripMenuItem";
            this.修改属性ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.修改属性ToolStripMenuItem.Text = "修改属性";
            this.修改属性ToolStripMenuItem.Click += new System.EventHandler(this.修改属性ToolStripMenuItem_Click);
            // 
            // ParamCfg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "ParamCfg";
            this.RectColor = System.Drawing.Color.Gray;
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "参数配置";
            this.TitleColor = System.Drawing.Color.Gray;
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 546, 760);
            this.Load += new System.EventHandler(this.ParamCfg_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private global::System.ComponentModel.IContainer components = null;

		private global::System.Windows.Forms.PropertyGrid propertyGrid1;

		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem 删除属性ToolStripMenuItem;

		private ToolStripMenuItem 添加属性ToolStripMenuItem;

		private global::System.Windows.Forms.MenuStrip menuStrip1;

		private global::System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem 加载参数ToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem 保存为UDTToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ToolStripMenuItem 导出ToolStripMenuItem;
        private ToolStripMenuItem 修改属性ToolStripMenuItem;
    }
}
