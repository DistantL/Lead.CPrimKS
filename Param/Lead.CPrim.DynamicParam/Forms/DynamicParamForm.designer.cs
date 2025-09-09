
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.DynamicParam
{
    partial class DynamicParamForm
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
            this.tsTitle = new System.Windows.Forms.ToolStrip();
            this.tsLblProducts = new System.Windows.Forms.ToolStripLabel();
            this.tscboProducts = new System.Windows.Forms.ToolStripComboBox();
            this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnNewUdt = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEditUdt = new System.Windows.Forms.ToolStripButton();
            this.pg = new System.Windows.Forms.PropertyGrid();
            this.gbPos = new System.Windows.Forms.GroupBox();
            this.cmbTreePos = new Lead.CPrim.ProxyTools.CustomControl.UIComboTreeView();
            this.lb_PosList = new System.Windows.Forms.Label();
            this.buttonEditPositions = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tsTitle.SuspendLayout();
            this.gbPos.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsTitle
            // 
            this.tlpMain.SetColumnSpan(this.tsTitle, 2);
            this.tsTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.tsTitle.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsTitle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLblProducts,
            this.tscboProducts,
            this.tsbtnEdit,
            this.toolStripSeparator2,
            this.tsbtnCopy,
            this.toolStripSeparator3,
            this.tsbtnNewUdt,
            this.tsbtnEditUdt});
            this.tsTitle.Location = new System.Drawing.Point(0, 0);
            this.tsTitle.Name = "tsTitle";
            this.tsTitle.Size = new System.Drawing.Size(1000, 40);
            this.tsTitle.TabIndex = 3;
            this.tsTitle.Text = "toolStrip1";
            // 
            // tsLblProducts
            // 
            this.tsLblProducts.DoubleClickEnabled = true;
            this.tsLblProducts.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.tsLblProducts.Name = "tsLblProducts";
            this.tsLblProducts.Size = new System.Drawing.Size(79, 37);
            this.tsLblProducts.Text = "产品列表：";
            this.tsLblProducts.ToolTipText = "双击刷新产品列表";
            this.tsLblProducts.DoubleClick += new System.EventHandler(this.tsLblProducts_DoubleClick);
            // 
            // tscboProducts
            // 
            this.tscboProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscboProducts.Enabled = false;
            this.tscboProducts.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.tscboProducts.Name = "tscboProducts";
            this.tscboProducts.Size = new System.Drawing.Size(121, 40);
            this.tscboProducts.ToolTipText = "产品列表";
            this.tscboProducts.Click += new System.EventHandler(this.tscboProducts_SelectedIndexChanged);
            // 
            // tsbtnEdit
            // 
            this.tsbtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnEdit.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEdit.Name = "tsbtnEdit";
            this.tsbtnEdit.Size = new System.Drawing.Size(97, 37);
            this.tsbtnEdit.Text = "编辑产品参数";
            this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbtnCopy
            // 
            this.tsbtnCopy.BackColor = System.Drawing.Color.LawnGreen;
            this.tsbtnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnCopy.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.tsbtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCopy.Name = "tsbtnCopy";
            this.tsbtnCopy.Size = new System.Drawing.Size(69, 37);
            this.tsbtnCopy.Text = "复制参数";
            this.tsbtnCopy.Click += new System.EventHandler(this.tsbtnCopy_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbtnNewUdt
            // 
            this.tsbtnNewUdt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnNewUdt.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.tsbtnNewUdt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNewUdt.Name = "tsbtnNewUdt";
            this.tsbtnNewUdt.Size = new System.Drawing.Size(111, 37);
            this.tsbtnNewUdt.Text = "新建自定义类型";
            this.tsbtnNewUdt.Click += new System.EventHandler(this.tsbtnNewUdt_Click);
            // 
            // tsbtnEditUdt
            // 
            this.tsbtnEditUdt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnEditUdt.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.tsbtnEditUdt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEditUdt.Name = "tsbtnEditUdt";
            this.tsbtnEditUdt.Size = new System.Drawing.Size(111, 37);
            this.tsbtnEditUdt.Text = "编辑自定义类型";
            this.tsbtnEditUdt.Click += new System.EventHandler(this.tsbtnEditUdt_Click);
            // 
            // pg
            // 
            this.pg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg.Location = new System.Drawing.Point(3, 44);
            this.pg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pg.Name = "pg";
            this.tlpMain.SetRowSpan(this.pg, 2);
            this.pg.Size = new System.Drawing.Size(524, 452);
            this.pg.TabIndex = 6;
            // 
            // gbPos
            // 
            this.gbPos.Controls.Add(this.cmbTreePos);
            this.gbPos.Controls.Add(this.lb_PosList);
            this.gbPos.Controls.Add(this.buttonEditPositions);
            this.gbPos.Controls.Add(this.buttonRefresh);
            this.gbPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPos.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbPos.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbPos.Location = new System.Drawing.Point(533, 44);
            this.gbPos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbPos.Name = "gbPos";
            this.gbPos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbPos.Size = new System.Drawing.Size(464, 122);
            this.gbPos.TabIndex = 11;
            this.gbPos.TabStop = false;
            this.gbPos.Text = "轴组点位编辑";
            // 
            // cmbTreePos
            // 
            this.cmbTreePos.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cmbTreePos.FillColor = System.Drawing.Color.White;
            this.cmbTreePos.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbTreePos.Location = new System.Drawing.Point(174, 28);
            this.cmbTreePos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTreePos.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmbTreePos.Name = "cmbTreePos";
            this.cmbTreePos.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmbTreePos.Size = new System.Drawing.Size(223, 29);
            this.cmbTreePos.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.cmbTreePos.TabIndex = 15;
            this.cmbTreePos.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_PosList
            // 
            this.lb_PosList.AutoSize = true;
            this.lb_PosList.Location = new System.Drawing.Point(68, 32);
            this.lb_PosList.Name = "lb_PosList";
            this.lb_PosList.Size = new System.Drawing.Size(79, 20);
            this.lb_PosList.TabIndex = 12;
            this.lb_PosList.Text = "点位列表：";
            // 
            // buttonEditPositions
            // 
            this.buttonEditPositions.Location = new System.Drawing.Point(275, 70);
            this.buttonEditPositions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonEditPositions.Name = "buttonEditPositions";
            this.buttonEditPositions.Size = new System.Drawing.Size(122, 41);
            this.buttonEditPositions.TabIndex = 14;
            this.buttonEditPositions.Text = "编辑";
            this.buttonEditPositions.UseVisualStyleBackColor = true;
            this.buttonEditPositions.Click += new System.EventHandler(this.ButtonEditPositions_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(72, 70);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(122, 40);
            this.buttonRefresh.TabIndex = 13;
            this.buttonRefresh.Text = "刷新";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 470F));
            this.tlpMain.Controls.Add(this.tsTitle, 0, 0);
            this.tlpMain.Controls.Add(this.gbPos, 1, 1);
            this.tlpMain.Controls.Add(this.pg, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1000, 500);
            this.tlpMain.TabIndex = 12;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tlpMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1000, 500);
            this.pnlMain.TabIndex = 13;
            // 
            // DynamicParamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "DynamicParamForm";
            this.RectColor = System.Drawing.Color.Gray;
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "换型参数";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 1000, 670);
            this.Load += new System.EventHandler(this.DynamicParamForm_Load);
            this.tsTitle.ResumeLayout(false);
            this.tsTitle.PerformLayout();
            this.gbPos.ResumeLayout(false);
            this.gbPos.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        #endregion

        private TableLayoutPanel tlpMain;
        private Label lb_PosList;
        private Button buttonEditPositions;
        private Button buttonRefresh;
        private ProxyTools.CustomControl.UIComboTreeView cmbTreePos;
        private ToolStrip tsTitle;
        private ToolStripButton tsbtnEdit;
        private PropertyGrid pg;
        private ToolStripLabel tsLblProducts;
        private ToolStripComboBox tscboProducts;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbtnNewUdt;
        private ToolStripButton tsbtnEditUdt;
        private GroupBox gbPos;
        private ToolStripButton tsbtnCopy;
        private ToolStripSeparator toolStripSeparator3;
        private Panel pnlMain;
    }
}