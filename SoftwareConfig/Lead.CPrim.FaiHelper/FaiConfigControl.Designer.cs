using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.FaiHelper
{
    partial class FaiConfigControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaiConfigControl));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tsFaiConfig = new System.Windows.Forms.ToolStrip();
            this.tsl_ProductionSelect = new System.Windows.Forms.ToolStripLabel();
            this.tsCmbProduct = new System.Windows.Forms.ToolStripComboBox();
            this.tsBtnAddProduct = new System.Windows.Forms.ToolStripButton();
            this.tsDelProduct = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCopyProduct = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnAddSimpleFaiConfigs = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAddComplexFaiConfigs = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCopySimpleFaiConfig = new System.Windows.Forms.ToolStripButton();
            this.tsDelConfig = new System.Windows.Forms.ToolStripButton();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tpSimpleFaiConfigs = new System.Windows.Forms.TabPage();
            this.flpSimpleFaiConfigs = new System.Windows.Forms.FlowLayoutPanel();
            this.tpComplexFaiConfigs = new System.Windows.Forms.TabPage();
            this.flpComplexFaiConfigs = new System.Windows.Forms.FlowLayoutPanel();
            this.tlpMain.SuspendLayout();
            this.tsFaiConfig.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tpSimpleFaiConfigs.SuspendLayout();
            this.tpComplexFaiConfigs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tsFaiConfig, 0, 0);
            this.tlpMain.Controls.Add(this.tabMain, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1595, 814);
            this.tlpMain.TabIndex = 0;
            // 
            // tsFaiConfig
            // 
            this.tsFaiConfig.BackColor = System.Drawing.Color.LightGray;
            this.tsFaiConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsFaiConfig.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsFaiConfig.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsFaiConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsl_ProductionSelect,
            this.tsCmbProduct,
            this.tsBtnAddProduct,
            this.tsDelProduct,
            this.tsBtnCopyProduct,
            this.toolStripSeparator7,
            this.tsBtnAddSimpleFaiConfigs,
            this.tsBtnAddComplexFaiConfigs,
            this.tsBtnCopySimpleFaiConfig,
            this.tsDelConfig});
            this.tsFaiConfig.Location = new System.Drawing.Point(5, 5);
            this.tsFaiConfig.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.tsFaiConfig.Name = "tsFaiConfig";
            this.tsFaiConfig.Padding = new System.Windows.Forms.Padding(0);
            this.tsFaiConfig.Size = new System.Drawing.Size(1585, 33);
            this.tsFaiConfig.TabIndex = 34;
            this.tsFaiConfig.Text = "脉冲比较触发配置";
            // 
            // tsl_ProductionSelect
            // 
            this.tsl_ProductionSelect.Name = "tsl_ProductionSelect";
            this.tsl_ProductionSelect.Size = new System.Drawing.Size(89, 30);
            this.tsl_ProductionSelect.Text = "产品选择：";
            // 
            // tsCmbProduct
            // 
            this.tsCmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsCmbProduct.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsCmbProduct.Name = "tsCmbProduct";
            this.tsCmbProduct.Size = new System.Drawing.Size(99, 33);
            this.tsCmbProduct.SelectedIndexChanged += new System.EventHandler(this.tsCmbProduct_SelectedIndexChanged);
            // 
            // tsBtnAddProduct
            // 
            this.tsBtnAddProduct.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnAddProduct.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAddProduct.Image")));
            this.tsBtnAddProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddProduct.Name = "tsBtnAddProduct";
            this.tsBtnAddProduct.Size = new System.Drawing.Size(29, 30);
            this.tsBtnAddProduct.Text = "添加产品";
            this.tsBtnAddProduct.Click += new System.EventHandler(this.tsBtnAddProduct_Click);
            // 
            // tsDelProduct
            // 
            this.tsDelProduct.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDelProduct.Image = ((System.Drawing.Image)(resources.GetObject("tsDelProduct.Image")));
            this.tsDelProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelProduct.Name = "tsDelProduct";
            this.tsDelProduct.Size = new System.Drawing.Size(29, 30);
            this.tsDelProduct.Text = "移除当前产品";
            this.tsDelProduct.Click += new System.EventHandler(this.tsDelProduct_Click);
            // 
            // tsBtnCopyProduct
            // 
            this.tsBtnCopyProduct.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnCopyProduct.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCopyProduct.Image")));
            this.tsBtnCopyProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCopyProduct.Name = "tsBtnCopyProduct";
            this.tsBtnCopyProduct.Size = new System.Drawing.Size(29, 30);
            this.tsBtnCopyProduct.Text = "toolStripButton1";
            this.tsBtnCopyProduct.ToolTipText = "复制当前产品的所有数据至新产品";
            this.tsBtnCopyProduct.Click += new System.EventHandler(this.tsBtnCopyProduct_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 33);
            // 
            // tsBtnAddSimpleFaiConfigs
            // 
            this.tsBtnAddSimpleFaiConfigs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnAddSimpleFaiConfigs.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAddSimpleFaiConfigs.Image")));
            this.tsBtnAddSimpleFaiConfigs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddSimpleFaiConfigs.Name = "tsBtnAddSimpleFaiConfigs";
            this.tsBtnAddSimpleFaiConfigs.Size = new System.Drawing.Size(129, 30);
            this.tsBtnAddSimpleFaiConfigs.Text = "添加简单FAI配置";
            this.tsBtnAddSimpleFaiConfigs.Click += new System.EventHandler(this.tsBtnAddSimpleFaiConfigs_Click);
            // 
            // tsBtnAddComplexFaiConfigs
            // 
            this.tsBtnAddComplexFaiConfigs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnAddComplexFaiConfigs.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAddComplexFaiConfigs.Image")));
            this.tsBtnAddComplexFaiConfigs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddComplexFaiConfigs.Name = "tsBtnAddComplexFaiConfigs";
            this.tsBtnAddComplexFaiConfigs.Size = new System.Drawing.Size(129, 30);
            this.tsBtnAddComplexFaiConfigs.Text = "添加复杂FAI配置";
            this.tsBtnAddComplexFaiConfigs.Click += new System.EventHandler(this.tsBtnAddComplexFaiConfigs_Click);
            // 
            // tsBtnCopySimpleFaiConfig
            // 
            this.tsBtnCopySimpleFaiConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnCopySimpleFaiConfig.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCopySimpleFaiConfig.Image")));
            this.tsBtnCopySimpleFaiConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCopySimpleFaiConfig.Name = "tsBtnCopySimpleFaiConfig";
            this.tsBtnCopySimpleFaiConfig.Size = new System.Drawing.Size(29, 30);
            this.tsBtnCopySimpleFaiConfig.Text = "toolStripButton1";
            this.tsBtnCopySimpleFaiConfig.ToolTipText = "复制选中的简单FAI配置";
            this.tsBtnCopySimpleFaiConfig.Click += new System.EventHandler(this.tsBtnCopySimpleFaiConfig_Click);
            // 
            // tsDelConfig
            // 
            this.tsDelConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDelConfig.Image = ((System.Drawing.Image)(resources.GetObject("tsDelConfig.Image")));
            this.tsDelConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelConfig.Name = "tsDelConfig";
            this.tsDelConfig.Size = new System.Drawing.Size(29, 30);
            this.tsDelConfig.Text = "移除已选中成员";
            this.tsDelConfig.Click += new System.EventHandler(this.tsDelConfig_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tpSimpleFaiConfigs);
            this.tabMain.Controls.Add(this.tpComplexFaiConfigs);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(4, 42);
            this.tabMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1587, 768);
            this.tabMain.TabIndex = 35;
            // 
            // tpSimpleFaiConfigs
            // 
            this.tpSimpleFaiConfigs.Controls.Add(this.flpSimpleFaiConfigs);
            this.tpSimpleFaiConfigs.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tpSimpleFaiConfigs.Location = new System.Drawing.Point(4, 29);
            this.tpSimpleFaiConfigs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpSimpleFaiConfigs.Name = "tpSimpleFaiConfigs";
            this.tpSimpleFaiConfigs.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpSimpleFaiConfigs.Size = new System.Drawing.Size(1579, 735);
            this.tpSimpleFaiConfigs.TabIndex = 0;
            this.tpSimpleFaiConfigs.Text = "简单FAI配置";
            this.tpSimpleFaiConfigs.UseVisualStyleBackColor = true;
            // 
            // flpSimpleFaiConfigs
            // 
            this.flpSimpleFaiConfigs.AutoScroll = true;
            this.flpSimpleFaiConfigs.AutoSize = true;
            this.flpSimpleFaiConfigs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpSimpleFaiConfigs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSimpleFaiConfigs.Location = new System.Drawing.Point(4, 4);
            this.flpSimpleFaiConfigs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpSimpleFaiConfigs.Name = "flpSimpleFaiConfigs";
            this.flpSimpleFaiConfigs.Size = new System.Drawing.Size(1571, 727);
            this.flpSimpleFaiConfigs.TabIndex = 0;
            // 
            // tpComplexFaiConfigs
            // 
            this.tpComplexFaiConfigs.Controls.Add(this.flpComplexFaiConfigs);
            this.tpComplexFaiConfigs.Location = new System.Drawing.Point(4, 29);
            this.tpComplexFaiConfigs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpComplexFaiConfigs.Name = "tpComplexFaiConfigs";
            this.tpComplexFaiConfigs.Size = new System.Drawing.Size(1580, 736);
            this.tpComplexFaiConfigs.TabIndex = 1;
            this.tpComplexFaiConfigs.Text = "复杂FAI配置";
            this.tpComplexFaiConfigs.UseVisualStyleBackColor = true;
            // 
            // flpComplexFaiConfigs
            // 
            this.flpComplexFaiConfigs.AutoScroll = true;
            this.flpComplexFaiConfigs.AutoSize = true;
            this.flpComplexFaiConfigs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpComplexFaiConfigs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpComplexFaiConfigs.Location = new System.Drawing.Point(0, 0);
            this.flpComplexFaiConfigs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpComplexFaiConfigs.Name = "flpComplexFaiConfigs";
            this.flpComplexFaiConfigs.Size = new System.Drawing.Size(1580, 736);
            this.flpComplexFaiConfigs.TabIndex = 1;
            // 
            // FaiConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FaiConfigControl";
            this.Size = new System.Drawing.Size(1595, 814);
            this.Load += new System.EventHandler(this.FaiConfigControl_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tsFaiConfig.ResumeLayout(false);
            this.tsFaiConfig.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tpSimpleFaiConfigs.ResumeLayout(false);
            this.tpSimpleFaiConfigs.PerformLayout();
            this.tpComplexFaiConfigs.ResumeLayout(false);
            this.tpComplexFaiConfigs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tlpMain;
        private ToolStrip tsFaiConfig;
        private ToolStripButton tsDelProduct;
        private ToolStripButton tsBtnAddSimpleFaiConfigs;
        private ToolStripLabel tsl_ProductionSelect;
        private ToolStripComboBox tsCmbProduct;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton tsBtnAddProduct;
        private TabControl tabMain;
        private TabPage tpSimpleFaiConfigs;
        private ToolStripButton tsDelConfig;
        private FlowLayoutPanel flpSimpleFaiConfigs;
        private ToolStripButton tsBtnCopyProduct;
        private ToolStripButton tsBtnCopySimpleFaiConfig;
        private ToolStripButton tsBtnAddComplexFaiConfigs;
        private TabPage tpComplexFaiConfigs;
        private FlowLayoutPanel flpComplexFaiConfigs;
    }
}
