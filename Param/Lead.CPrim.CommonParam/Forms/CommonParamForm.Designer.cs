
using System.Windows.Forms;

namespace Lead.CPrim.CommonParam
{
    partial class CommonParamForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pg = new System.Windows.Forms.PropertyGrid();
            this.cms_AddCommonParamToRunMode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加到选择的运行模式的全局参数列表中ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pg_RunMode_CommonParam = new System.Windows.Forms.PropertyGrid();
            this.cms_DeleteCommonParamFromRunMode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.从选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxRunMode = new System.Windows.Forms.TextBox();
            this.lb_RunModeList = new System.Windows.Forms.Label();
            this.tsTitle = new System.Windows.Forms.ToolStrip();
            this.tsBtnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnNewUdt = new System.Windows.Forms.ToolStripButton();
            this.tsBtnEditUdt = new System.Windows.Forms.ToolStripButton();
            this.cms_AddCommonParamToRunMode.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.cms_DeleteCommonParamFromRunMode.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tsTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pg
            // 
            this.pg.ContextMenuStrip = this.cms_AddCommonParamToRunMode;
            this.pg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg.Location = new System.Drawing.Point(3, 44);
            this.pg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pg.Name = "pg";
            this.tlpMain.SetRowSpan(this.pg, 4);
            this.pg.Size = new System.Drawing.Size(524, 452);
            this.pg.TabIndex = 6;
            // 
            // cms_AddCommonParamToRunMode
            // 
            this.cms_AddCommonParamToRunMode.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_AddCommonParamToRunMode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加到选择的运行模式的全局参数列表中ToolStripMenuItem});
            this.cms_AddCommonParamToRunMode.Name = "cms_AddCommonParamToRunMode";
            this.cms_AddCommonParamToRunMode.Size = new System.Drawing.Size(349, 28);
            // 
            // 添加到选择的运行模式的全局参数列表中ToolStripMenuItem
            // 
            this.添加到选择的运行模式的全局参数列表中ToolStripMenuItem.Name = "添加到选择的运行模式的全局参数列表中ToolStripMenuItem";
            this.添加到选择的运行模式的全局参数列表中ToolStripMenuItem.Size = new System.Drawing.Size(348, 24);
            this.添加到选择的运行模式的全局参数列表中ToolStripMenuItem.Text = "添加到选择的运行模式的全局参数列表中";
            this.添加到选择的运行模式的全局参数列表中ToolStripMenuItem.Click += new System.EventHandler(this.添加到选择的运行模式的全局参数列表中ToolStripMenuItem_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 470F));
            this.tlpMain.Controls.Add(this.groupBox1, 1, 1);
            this.tlpMain.Controls.Add(this.pg, 0, 1);
            this.tlpMain.Controls.Add(this.tsTitle, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 295F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(1000, 500);
            this.tlpMain.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(533, 44);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlpMain.SetRowSpan(this.groupBox1, 4);
            this.groupBox1.Size = new System.Drawing.Size(464, 452);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "模式切换时需要切换的全局参数";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.pg_RunMode_CommonParam, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 27);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(458, 421);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // pg_RunMode_CommonParam
            // 
            this.pg_RunMode_CommonParam.ContextMenuStrip = this.cms_DeleteCommonParamFromRunMode;
            this.pg_RunMode_CommonParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg_RunMode_CommonParam.Location = new System.Drawing.Point(3, 59);
            this.pg_RunMode_CommonParam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pg_RunMode_CommonParam.Name = "pg_RunMode_CommonParam";
            this.pg_RunMode_CommonParam.Size = new System.Drawing.Size(452, 358);
            this.pg_RunMode_CommonParam.TabIndex = 7;
            // 
            // cms_DeleteCommonParamFromRunMode
            // 
            this.cms_DeleteCommonParamFromRunMode.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_DeleteCommonParamFromRunMode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.从选择ToolStripMenuItem});
            this.cms_DeleteCommonParamFromRunMode.Name = "cms_DeleteCommonParamFromRunMode";
            this.cms_DeleteCommonParamFromRunMode.Size = new System.Drawing.Size(349, 28);
            // 
            // 从选择ToolStripMenuItem
            // 
            this.从选择ToolStripMenuItem.Name = "从选择ToolStripMenuItem";
            this.从选择ToolStripMenuItem.Size = new System.Drawing.Size(348, 24);
            this.从选择ToolStripMenuItem.Text = "从选择的运行模式的全局参数列表中删除";
            this.从选择ToolStripMenuItem.Click += new System.EventHandler(this.从选择ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbxRunMode);
            this.panel1.Controls.Add(this.lb_RunModeList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 49);
            this.panel1.TabIndex = 0;
            // 
            // tbxRunMode
            // 
            this.tbxRunMode.Location = new System.Drawing.Point(149, 10);
            this.tbxRunMode.Name = "tbxRunMode";
            this.tbxRunMode.ReadOnly = true;
            this.tbxRunMode.Size = new System.Drawing.Size(277, 30);
            this.tbxRunMode.TabIndex = 9;
            // 
            // lb_RunModeList
            // 
            this.lb_RunModeList.Location = new System.Drawing.Point(15, 10);
            this.lb_RunModeList.Name = "lb_RunModeList";
            this.lb_RunModeList.Size = new System.Drawing.Size(128, 31);
            this.lb_RunModeList.TabIndex = 8;
            this.lb_RunModeList.Text = "当前模式：";
            this.lb_RunModeList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tsTitle
            // 
            this.tlpMain.SetColumnSpan(this.tsTitle, 2);
            this.tsTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.tsTitle.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsTitle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnEdit,
            this.toolStripSeparator2,
            this.tsBtnNewUdt,
            this.tsBtnEditUdt});
            this.tsTitle.Location = new System.Drawing.Point(0, 0);
            this.tsTitle.Name = "tsTitle";
            this.tsTitle.Size = new System.Drawing.Size(1000, 40);
            this.tsTitle.TabIndex = 3;
            this.tsTitle.Text = "toolStrip1";
            // 
            // tsBtnEdit
            // 
            this.tsBtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnEdit.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.tsBtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEdit.Name = "tsBtnEdit";
            this.tsBtnEdit.Size = new System.Drawing.Size(86, 37);
            this.tsBtnEdit.Text = "编辑参数";
            this.tsBtnEdit.Click += new System.EventHandler(this.修改参数类型ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // tsBtnNewUdt
            // 
            this.tsBtnNewUdt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnNewUdt.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.tsBtnNewUdt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNewUdt.Name = "tsBtnNewUdt";
            this.tsBtnNewUdt.Size = new System.Drawing.Size(140, 37);
            this.tsBtnNewUdt.Text = "新建自定义类型";
            this.tsBtnNewUdt.Click += new System.EventHandler(this.tsBtnNewUdt_Click);
            // 
            // tsBtnEditUdt
            // 
            this.tsBtnEditUdt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnEditUdt.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.tsBtnEditUdt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEditUdt.Name = "tsBtnEditUdt";
            this.tsBtnEditUdt.Size = new System.Drawing.Size(140, 37);
            this.tsBtnEditUdt.Text = "编辑自定义类型";
            this.tsBtnEditUdt.Click += new System.EventHandler(this.tsBtnEditUdt_Click);
            // 
            // CommonParamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(119F, 119F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "CommonParamForm";
            this.RectColor = System.Drawing.Color.Transparent;
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "全局参数";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 1008, 664);
            this.cms_AddCommonParamToRunMode.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.cms_DeleteCommonParamFromRunMode.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tsTitle.ResumeLayout(false);
            this.tsTitle.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_RunModeList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PropertyGrid pg_RunMode_CommonParam;
        private System.Windows.Forms.ContextMenuStrip cms_AddCommonParamToRunMode;
        private System.Windows.Forms.ContextMenuStrip cms_DeleteCommonParamFromRunMode;
        private System.Windows.Forms.ToolStripMenuItem 添加到选择的运行模式的全局参数列表中ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 从选择ToolStripMenuItem;
        private System.Windows.Forms.PropertyGrid pg;
        private ToolStrip tsTitle;
        private ToolStripButton tsBtnEdit;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsBtnNewUdt;
        private ToolStripButton tsBtnEditUdt;
        private TextBox tbxRunMode;
    }
}