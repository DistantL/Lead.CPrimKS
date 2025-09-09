using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.CmpTrigHelper
{
    partial class TriggerMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TriggerMain));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tsTriggerConfig = new System.Windows.Forms.ToolStrip();
            this.tsBtnSaveCmpConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsl_Production = new System.Windows.Forms.ToolStripLabel();
            this.tsCmbProduct = new System.Windows.Forms.ToolStripComboBox();
            this.tsBtnAddProduct = new System.Windows.Forms.ToolStripButton();
            this.tsDelProduct = new System.Windows.Forms.ToolStripButton();
            this.tsCopyProduct = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnAddTriggerConfig = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAddTrajData = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAddLinearTrigConfig = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAddTableTrigConfig = new System.Windows.Forms.ToolStripButton();
            this.tsBtnInterpolation = new System.Windows.Forms.ToolStripButton();
            this.btnTrigTableManger = new System.Windows.Forms.ToolStripButton();
            this.tsBtnComplexInterpolation = new System.Windows.Forms.ToolStripButton();
            this.tsDelConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tpTriggerProt = new System.Windows.Forms.TabPage();
            this.flpTrigPort = new System.Windows.Forms.FlowLayoutPanel();
            this.tpTrajDatas = new System.Windows.Forms.TabPage();
            this.flpTrajDatas = new System.Windows.Forms.FlowLayoutPanel();
            this.tpLinearTrigDatas = new System.Windows.Forms.TabPage();
            this.flpLinearTrigDatas = new System.Windows.Forms.FlowLayoutPanel();
            this.tpTableTrigDatas = new System.Windows.Forms.TabPage();
            this.flpTableTrigDatas = new System.Windows.Forms.FlowLayoutPanel();
            this.tpInterpretation = new System.Windows.Forms.TabPage();
            this.flpInterpretation = new System.Windows.Forms.FlowLayoutPanel();
            this.tpTrigManger = new System.Windows.Forms.TabPage();
            this.flpTrigTabManger = new System.Windows.Forms.FlowLayoutPanel();
            this.tpComplexInterpolation = new System.Windows.Forms.TabPage();
            this.flpComplexInterpolation = new System.Windows.Forms.FlowLayoutPanel();
            this.tlpMain.SuspendLayout();
            this.tsTriggerConfig.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tpTriggerProt.SuspendLayout();
            this.tpTrajDatas.SuspendLayout();
            this.tpLinearTrigDatas.SuspendLayout();
            this.tpTableTrigDatas.SuspendLayout();
            this.tpInterpretation.SuspendLayout();
            this.tpTrigManger.SuspendLayout();
            this.tpComplexInterpolation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tsTriggerConfig, 0, 0);
            this.tlpMain.Controls.Add(this.tabMain, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(1221, 863);
            this.tlpMain.TabIndex = 0;
            // 
            // tsTriggerConfig
            // 
            this.tsTriggerConfig.BackColor = System.Drawing.Color.LightGray;
            this.tsTriggerConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsTriggerConfig.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.tsTriggerConfig.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsTriggerConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSaveCmpConfig,
            this.toolStripSeparator5,
            this.tsl_Production,
            this.tsCmbProduct,
            this.tsBtnAddProduct,
            this.tsDelProduct,
            this.tsCopyProduct,
            this.toolStripSeparator7,
            this.tsBtnAddTriggerConfig,
            this.tsBtnAddTrajData,
            this.tsBtnAddLinearTrigConfig,
            this.tsBtnAddTableTrigConfig,
            this.tsBtnInterpolation,
            this.btnTrigTableManger,
            this.tsBtnComplexInterpolation,
            this.tsDelConfig,
            this.toolStripSeparator1});
            this.tsTriggerConfig.Location = new System.Drawing.Point(4, 4);
            this.tsTriggerConfig.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.tsTriggerConfig.Name = "tsTriggerConfig";
            this.tsTriggerConfig.Size = new System.Drawing.Size(1213, 26);
            this.tsTriggerConfig.TabIndex = 34;
            this.tsTriggerConfig.Text = "脉冲比较触发配置";
            // 
            // tsBtnSaveCmpConfig
            // 
            this.tsBtnSaveCmpConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnSaveCmpConfig.Image = global::Lead.CPrim.CmpTrigHelper.Properties.Resources.Save;
            this.tsBtnSaveCmpConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSaveCmpConfig.Name = "tsBtnSaveCmpConfig";
            this.tsBtnSaveCmpConfig.Size = new System.Drawing.Size(24, 23);
            this.tsBtnSaveCmpConfig.Text = "保存配置文件";
            this.tsBtnSaveCmpConfig.Visible = false;
            this.tsBtnSaveCmpConfig.Click += new System.EventHandler(this.tsBtnSaveCmpConfig_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 26);
            // 
            // tsl_Production
            // 
            this.tsl_Production.Name = "tsl_Production";
            this.tsl_Production.Size = new System.Drawing.Size(68, 23);
            this.tsl_Production.Text = "产品选择：";
            // 
            // tsCmbProduct
            // 
            this.tsCmbProduct.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsCmbProduct.Name = "tsCmbProduct";
            this.tsCmbProduct.Size = new System.Drawing.Size(93, 26);
            this.tsCmbProduct.ToolTipText = "选择产品";
            this.tsCmbProduct.SelectedIndexChanged += new System.EventHandler(this.tsCmbProduct_SelectedIndexChanged);
            // 
            // tsBtnAddProduct
            // 
            this.tsBtnAddProduct.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnAddProduct.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAddProduct.Image")));
            this.tsBtnAddProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddProduct.Name = "tsBtnAddProduct";
            this.tsBtnAddProduct.Size = new System.Drawing.Size(24, 23);
            this.tsBtnAddProduct.Text = "添加产品";
            this.tsBtnAddProduct.Click += new System.EventHandler(this.tsBtnAddProduct_Click);
            // 
            // tsDelProduct
            // 
            this.tsDelProduct.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDelProduct.Image = ((System.Drawing.Image)(resources.GetObject("tsDelProduct.Image")));
            this.tsDelProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelProduct.Name = "tsDelProduct";
            this.tsDelProduct.Size = new System.Drawing.Size(24, 23);
            this.tsDelProduct.Text = "移除当前产品";
            this.tsDelProduct.Click += new System.EventHandler(this.tsDelProduct_Click);
            // 
            // tsCopyProduct
            // 
            this.tsCopyProduct.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsCopyProduct.Image = global::Lead.CPrim.CmpTrigHelper.Properties.Resources.Copy;
            this.tsCopyProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCopyProduct.Name = "tsCopyProduct";
            this.tsCopyProduct.Size = new System.Drawing.Size(24, 23);
            this.tsCopyProduct.Text = "复制当前产品的所有数据至新产品";
            this.tsCopyProduct.ToolTipText = "复制当前产品的所有数据至新产品";
            this.tsCopyProduct.Click += new System.EventHandler(this.tsCopyProduct_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 26);
            // 
            // tsBtnAddTriggerConfig
            // 
            this.tsBtnAddTriggerConfig.AutoSize = false;
            this.tsBtnAddTriggerConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnAddTriggerConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddTriggerConfig.Name = "tsBtnAddTriggerConfig";
            this.tsBtnAddTriggerConfig.Size = new System.Drawing.Size(110, 23);
            this.tsBtnAddTriggerConfig.Text = "添加触发端口";
            this.tsBtnAddTriggerConfig.Click += new System.EventHandler(this.tsBtnAddTriggerConfig_Click);
            // 
            // tsBtnAddTrajData
            // 
            this.tsBtnAddTrajData.AutoSize = false;
            this.tsBtnAddTrajData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnAddTrajData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddTrajData.Name = "tsBtnAddTrajData";
            this.tsBtnAddTrajData.Size = new System.Drawing.Size(110, 23);
            this.tsBtnAddTrajData.Text = "添加轨迹表";
            this.tsBtnAddTrajData.Click += new System.EventHandler(this.tsBtnAddTrajData_Click);
            // 
            // tsBtnAddLinearTrigConfig
            // 
            this.tsBtnAddLinearTrigConfig.AutoSize = false;
            this.tsBtnAddLinearTrigConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnAddLinearTrigConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddLinearTrigConfig.Name = "tsBtnAddLinearTrigConfig";
            this.tsBtnAddLinearTrigConfig.Size = new System.Drawing.Size(110, 23);
            this.tsBtnAddLinearTrigConfig.Text = "添加线性触发表";
            this.tsBtnAddLinearTrigConfig.Click += new System.EventHandler(this.tsBtnAddLinearTrigConfig_Click);
            // 
            // tsBtnAddTableTrigConfig
            // 
            this.tsBtnAddTableTrigConfig.AutoSize = false;
            this.tsBtnAddTableTrigConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnAddTableTrigConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddTableTrigConfig.Name = "tsBtnAddTableTrigConfig";
            this.tsBtnAddTableTrigConfig.Size = new System.Drawing.Size(110, 23);
            this.tsBtnAddTableTrigConfig.Text = "添加队列触发表";
            this.tsBtnAddTableTrigConfig.Click += new System.EventHandler(this.tsBtnAddTableTrigConfig_Click);
            // 
            // tsBtnInterpolation
            // 
            this.tsBtnInterpolation.AutoSize = false;
            this.tsBtnInterpolation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnInterpolation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnInterpolation.Name = "tsBtnInterpolation";
            this.tsBtnInterpolation.Size = new System.Drawing.Size(110, 23);
            this.tsBtnInterpolation.Text = "添加插补表";
            this.tsBtnInterpolation.Click += new System.EventHandler(this.tsBtnInterpolation_Click);
            // 
            // btnTrigTableManger
            // 
            this.btnTrigTableManger.AutoSize = false;
            this.btnTrigTableManger.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTrigTableManger.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTrigTableManger.Name = "btnTrigTableManger";
            this.btnTrigTableManger.Size = new System.Drawing.Size(110, 23);
            this.btnTrigTableManger.Text = "添加触发表管理器";
            this.btnTrigTableManger.Click += new System.EventHandler(this.BtnTrigTableManger_Click);
            // 
            // tsBtnComplexInterpolation
            // 
            this.tsBtnComplexInterpolation.AutoSize = false;
            this.tsBtnComplexInterpolation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnComplexInterpolation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnComplexInterpolation.Name = "tsBtnComplexInterpolation";
            this.tsBtnComplexInterpolation.Size = new System.Drawing.Size(110, 23);
            this.tsBtnComplexInterpolation.Text = "添加复杂插补表";
            this.tsBtnComplexInterpolation.Click += new System.EventHandler(this.tsBtnComplexInterpolation_Click);
            // 
            // tsDelConfig
            // 
            this.tsDelConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDelConfig.Image = ((System.Drawing.Image)(resources.GetObject("tsDelConfig.Image")));
            this.tsDelConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelConfig.Name = "tsDelConfig";
            this.tsDelConfig.Size = new System.Drawing.Size(24, 23);
            this.tsDelConfig.Text = "移除已选中成员";
            this.tsDelConfig.Click += new System.EventHandler(this.tsDelConfig_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tpTriggerProt);
            this.tabMain.Controls.Add(this.tpTrajDatas);
            this.tabMain.Controls.Add(this.tpLinearTrigDatas);
            this.tabMain.Controls.Add(this.tpTableTrigDatas);
            this.tabMain.Controls.Add(this.tpInterpretation);
            this.tabMain.Controls.Add(this.tpTrigManger);
            this.tabMain.Controls.Add(this.tpComplexInterpolation);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.ItemSize = new System.Drawing.Size(110, 22);
            this.tabMain.Location = new System.Drawing.Point(0, 30);
            this.tabMain.Margin = new System.Windows.Forms.Padding(0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1221, 833);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 35;
            // 
            // tpTriggerProt
            // 
            this.tpTriggerProt.Controls.Add(this.flpTrigPort);
            this.tpTriggerProt.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tpTriggerProt.Location = new System.Drawing.Point(4, 26);
            this.tpTriggerProt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpTriggerProt.Name = "tpTriggerProt";
            this.tpTriggerProt.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpTriggerProt.Size = new System.Drawing.Size(1213, 803);
            this.tpTriggerProt.TabIndex = 0;
            this.tpTriggerProt.Text = "触发端口";
            this.tpTriggerProt.UseVisualStyleBackColor = true;
            // 
            // flpTrigPort
            // 
            this.flpTrigPort.AutoScroll = true;
            this.flpTrigPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTrigPort.Location = new System.Drawing.Point(3, 4);
            this.flpTrigPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flpTrigPort.Name = "flpTrigPort";
            this.flpTrigPort.Size = new System.Drawing.Size(1207, 795);
            this.flpTrigPort.TabIndex = 0;
            // 
            // tpTrajDatas
            // 
            this.tpTrajDatas.Controls.Add(this.flpTrajDatas);
            this.tpTrajDatas.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tpTrajDatas.Location = new System.Drawing.Point(4, 26);
            this.tpTrajDatas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpTrajDatas.Name = "tpTrajDatas";
            this.tpTrajDatas.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpTrajDatas.Size = new System.Drawing.Size(1213, 803);
            this.tpTrajDatas.TabIndex = 1;
            this.tpTrajDatas.Text = "轨迹表";
            this.tpTrajDatas.UseVisualStyleBackColor = true;
            // 
            // flpTrajDatas
            // 
            this.flpTrajDatas.AutoScroll = true;
            this.flpTrajDatas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTrajDatas.Location = new System.Drawing.Point(3, 4);
            this.flpTrajDatas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flpTrajDatas.Name = "flpTrajDatas";
            this.flpTrajDatas.Size = new System.Drawing.Size(1207, 795);
            this.flpTrajDatas.TabIndex = 1;
            // 
            // tpLinearTrigDatas
            // 
            this.tpLinearTrigDatas.Controls.Add(this.flpLinearTrigDatas);
            this.tpLinearTrigDatas.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tpLinearTrigDatas.Location = new System.Drawing.Point(4, 26);
            this.tpLinearTrigDatas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpLinearTrigDatas.Name = "tpLinearTrigDatas";
            this.tpLinearTrigDatas.Size = new System.Drawing.Size(1213, 803);
            this.tpLinearTrigDatas.TabIndex = 2;
            this.tpLinearTrigDatas.Text = "线性触发表";
            this.tpLinearTrigDatas.UseVisualStyleBackColor = true;
            // 
            // flpLinearTrigDatas
            // 
            this.flpLinearTrigDatas.AutoScroll = true;
            this.flpLinearTrigDatas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpLinearTrigDatas.Location = new System.Drawing.Point(0, 0);
            this.flpLinearTrigDatas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flpLinearTrigDatas.Name = "flpLinearTrigDatas";
            this.flpLinearTrigDatas.Size = new System.Drawing.Size(1213, 803);
            this.flpLinearTrigDatas.TabIndex = 2;
            // 
            // tpTableTrigDatas
            // 
            this.tpTableTrigDatas.Controls.Add(this.flpTableTrigDatas);
            this.tpTableTrigDatas.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tpTableTrigDatas.Location = new System.Drawing.Point(4, 26);
            this.tpTableTrigDatas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpTableTrigDatas.Name = "tpTableTrigDatas";
            this.tpTableTrigDatas.Size = new System.Drawing.Size(1213, 803);
            this.tpTableTrigDatas.TabIndex = 3;
            this.tpTableTrigDatas.Text = "队列触发表";
            this.tpTableTrigDatas.UseVisualStyleBackColor = true;
            // 
            // flpTableTrigDatas
            // 
            this.flpTableTrigDatas.AutoScroll = true;
            this.flpTableTrigDatas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTableTrigDatas.Location = new System.Drawing.Point(0, 0);
            this.flpTableTrigDatas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flpTableTrigDatas.Name = "flpTableTrigDatas";
            this.flpTableTrigDatas.Size = new System.Drawing.Size(1213, 803);
            this.flpTableTrigDatas.TabIndex = 1;
            // 
            // tpInterpretation
            // 
            this.tpInterpretation.Controls.Add(this.flpInterpretation);
            this.tpInterpretation.Location = new System.Drawing.Point(4, 26);
            this.tpInterpretation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpInterpretation.Name = "tpInterpretation";
            this.tpInterpretation.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpInterpretation.Size = new System.Drawing.Size(1213, 803);
            this.tpInterpretation.TabIndex = 4;
            this.tpInterpretation.Text = "插补表";
            this.tpInterpretation.UseVisualStyleBackColor = true;
            // 
            // flpInterpretation
            // 
            this.flpInterpretation.AutoScroll = true;
            this.flpInterpretation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpInterpretation.Location = new System.Drawing.Point(3, 4);
            this.flpInterpretation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flpInterpretation.Name = "flpInterpretation";
            this.flpInterpretation.Size = new System.Drawing.Size(1207, 795);
            this.flpInterpretation.TabIndex = 2;
            // 
            // tpTrigManger
            // 
            this.tpTrigManger.Controls.Add(this.flpTrigTabManger);
            this.tpTrigManger.Location = new System.Drawing.Point(4, 26);
            this.tpTrigManger.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpTrigManger.Name = "tpTrigManger";
            this.tpTrigManger.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpTrigManger.Size = new System.Drawing.Size(1213, 803);
            this.tpTrigManger.TabIndex = 5;
            this.tpTrigManger.Text = "触发表管理器";
            this.tpTrigManger.UseVisualStyleBackColor = true;
            // 
            // flpTrigTabManger
            // 
            this.flpTrigTabManger.AutoScroll = true;
            this.flpTrigTabManger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTrigTabManger.Location = new System.Drawing.Point(3, 4);
            this.flpTrigTabManger.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flpTrigTabManger.Name = "flpTrigTabManger";
            this.flpTrigTabManger.Size = new System.Drawing.Size(1207, 795);
            this.flpTrigTabManger.TabIndex = 3;
            // 
            // tpComplexInterpolation
            // 
            this.tpComplexInterpolation.Controls.Add(this.flpComplexInterpolation);
            this.tpComplexInterpolation.Location = new System.Drawing.Point(4, 26);
            this.tpComplexInterpolation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpComplexInterpolation.Name = "tpComplexInterpolation";
            this.tpComplexInterpolation.Size = new System.Drawing.Size(1213, 803);
            this.tpComplexInterpolation.TabIndex = 6;
            this.tpComplexInterpolation.Text = "复杂插补表";
            this.tpComplexInterpolation.UseVisualStyleBackColor = true;
            // 
            // flpComplexInterpolation
            // 
            this.flpComplexInterpolation.AutoScroll = true;
            this.flpComplexInterpolation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpComplexInterpolation.Location = new System.Drawing.Point(0, 0);
            this.flpComplexInterpolation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flpComplexInterpolation.Name = "flpComplexInterpolation";
            this.flpComplexInterpolation.Size = new System.Drawing.Size(1213, 803);
            this.flpComplexInterpolation.TabIndex = 4;
            // 
            // TriggerMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TriggerMain";
            this.Size = new System.Drawing.Size(1221, 863);
            this.Load += new System.EventHandler(this.CmpTrigControl_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tsTriggerConfig.ResumeLayout(false);
            this.tsTriggerConfig.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tpTriggerProt.ResumeLayout(false);
            this.tpTrajDatas.ResumeLayout(false);
            this.tpLinearTrigDatas.ResumeLayout(false);
            this.tpTableTrigDatas.ResumeLayout(false);
            this.tpInterpretation.ResumeLayout(false);
            this.tpTrigManger.ResumeLayout(false);
            this.tpComplexInterpolation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tlpMain;
        private ToolStrip tsTriggerConfig;
        private ToolStripButton tsBtnSaveCmpConfig;
        private ToolStripButton tsDelProduct;
        private ToolStripButton tsBtnAddTriggerConfig;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripLabel tsl_Production;
        private ToolStripComboBox tsCmbProduct;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton tsBtnAddTrajData;
        private ToolStripButton tsBtnAddLinearTrigConfig;
        private ToolStripButton tsBtnAddTableTrigConfig;
        private ToolStripButton tsBtnAddProduct;
        private TabControl tabMain;
        private TabPage tpTriggerProt;
        private TabPage tpTrajDatas;
        private ToolStripButton tsDelConfig;
        private TabPage tpLinearTrigDatas;
        private TabPage tpTableTrigDatas;
        private ToolStripSeparator toolStripSeparator1;
        private FlowLayoutPanel flpTrigPort;
        private FlowLayoutPanel flpTrajDatas;
        private FlowLayoutPanel flpTableTrigDatas;
        private FlowLayoutPanel flpLinearTrigDatas;
        private ToolStripButton tsBtnInterpolation;
        private TabPage tpInterpretation;
        private FlowLayoutPanel flpInterpretation;
        private ToolStripButton btnTrigTableManger;
        private TabPage tpTrigManger;
        private FlowLayoutPanel flpTrigTabManger;
        private ToolStripButton tsCopyProduct;
        private ToolStripButton tsBtnComplexInterpolation;
        private TabPage tpComplexInterpolation;
        private FlowLayoutPanel flpComplexInterpolation;
    }
}
