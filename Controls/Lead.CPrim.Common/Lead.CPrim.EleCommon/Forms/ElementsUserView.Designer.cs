using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.EleCommon.Forms
{
    partial class ElementsUserView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabEles = new System.Windows.Forms.TabControl();
            this.tpDi = new System.Windows.Forms.TabPage();
            this.pbRed = new System.Windows.Forms.PictureBox();
            this.pbGreen = new System.Windows.Forms.PictureBox();
            this.pbYellow = new System.Windows.Forms.PictureBox();
            this.pbBlue = new System.Windows.Forms.PictureBox();
            this.pbGray = new System.Windows.Forms.PictureBox();
            this.dgvDi = new System.Windows.Forms.DataGridView();
            this.diName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEleDiInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diAdr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diStatue = new System.Windows.Forms.DataGridViewImageColumn();
            this.tpDo = new System.Windows.Forms.TabPage();
            this.dgvDo = new System.Windows.Forms.DataGridView();
            this.doName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEleDoInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doAdr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doStatue = new System.Windows.Forms.DataGridViewImageColumn();
            this.tpCyl = new System.Windows.Forms.TabPage();
            this.tlpCylinder = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCylinder = new System.Windows.Forms.DataGridView();
            this.cylName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEleCylInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cylHP = new System.Windows.Forms.DataGridViewImageColumn();
            this.cylWP = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlCylinder = new System.Windows.Forms.Panel();
            this.tb_Retract_Cylinder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_Retract_Cylinder = new System.Windows.Forms.Label();
            this.tb_Stretch_Cylinder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_Stretch_Cylinder = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtCylinderName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_TrigCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_IntervalTime = new System.Windows.Forms.Label();
            this.lb_CylinderName = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tpLight = new System.Windows.Forms.TabPage();
            this.dgvLight = new System.Windows.Forms.DataGridView();
            this.colLightName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEleLightInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLightRed = new System.Windows.Forms.DataGridViewImageColumn();
            this.colLightYellow = new System.Windows.Forms.DataGridViewImageColumn();
            this.colLightGreen = new System.Windows.Forms.DataGridViewImageColumn();
            this.colLightBuzzer = new System.Windows.Forms.DataGridViewImageColumn();
            this.tpCartesian = new System.Windows.Forms.TabPage();
            this.tabCartesians = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabEles.SuspendLayout();
            this.tpDi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbYellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDi)).BeginInit();
            this.tpDo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDo)).BeginInit();
            this.tpCyl.SuspendLayout();
            this.tlpCylinder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCylinder)).BeginInit();
            this.pnlCylinder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tpLight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLight)).BeginInit();
            this.tpCartesian.SuspendLayout();
            this.tabCartesians.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabEles
            // 
            this.tabEles.Controls.Add(this.tpDi);
            this.tabEles.Controls.Add(this.tpDo);
            this.tabEles.Controls.Add(this.tpCyl);
            this.tabEles.Controls.Add(this.tpLight);
            this.tabEles.Controls.Add(this.tpCartesian);
            this.tabEles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEles.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabEles.ItemSize = new System.Drawing.Size(120, 26);
            this.tabEles.Location = new System.Drawing.Point(0, 0);
            this.tabEles.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabEles.Name = "tabEles";
            this.tabEles.SelectedIndex = 0;
            this.tabEles.Size = new System.Drawing.Size(1408, 664);
            this.tabEles.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabEles.TabIndex = 0;
            // 
            // tpDi
            // 
            this.tpDi.Controls.Add(this.pbRed);
            this.tpDi.Controls.Add(this.pbGreen);
            this.tpDi.Controls.Add(this.pbYellow);
            this.tpDi.Controls.Add(this.pbBlue);
            this.tpDi.Controls.Add(this.pbGray);
            this.tpDi.Controls.Add(this.dgvDi);
            this.tpDi.Location = new System.Drawing.Point(4, 30);
            this.tpDi.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tpDi.Name = "tpDi";
            this.tpDi.Size = new System.Drawing.Size(1400, 630);
            this.tpDi.TabIndex = 0;
            this.tpDi.Text = "数字量输入";
            this.tpDi.UseVisualStyleBackColor = true;
            // 
            // pbRed
            // 
            this.pbRed.BackColor = System.Drawing.Color.Transparent;
            this.pbRed.ErrorImage = null;
            this.pbRed.Image = global::Lead.CPrim.Common.Properties.Resources.red;
            this.pbRed.InitialImage = null;
            this.pbRed.Location = new System.Drawing.Point(768, 336);
            this.pbRed.Name = "pbRed";
            this.pbRed.Size = new System.Drawing.Size(25, 25);
            this.pbRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRed.TabIndex = 4;
            this.pbRed.TabStop = false;
            this.pbRed.Visible = false;
            // 
            // pbGreen
            // 
            this.pbGreen.BackColor = System.Drawing.Color.Transparent;
            this.pbGreen.ErrorImage = null;
            this.pbGreen.Image = global::Lead.CPrim.Common.Properties.Resources.green;
            this.pbGreen.InitialImage = null;
            this.pbGreen.Location = new System.Drawing.Point(874, 336);
            this.pbGreen.Name = "pbGreen";
            this.pbGreen.Size = new System.Drawing.Size(25, 25);
            this.pbGreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGreen.TabIndex = 4;
            this.pbGreen.TabStop = false;
            this.pbGreen.Visible = false;
            // 
            // pbYellow
            // 
            this.pbYellow.BackColor = System.Drawing.Color.Transparent;
            this.pbYellow.ErrorImage = null;
            this.pbYellow.Image = global::Lead.CPrim.Common.Properties.Resources.yellow;
            this.pbYellow.InitialImage = null;
            this.pbYellow.Location = new System.Drawing.Point(821, 336);
            this.pbYellow.Name = "pbYellow";
            this.pbYellow.Size = new System.Drawing.Size(25, 25);
            this.pbYellow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbYellow.TabIndex = 4;
            this.pbYellow.TabStop = false;
            this.pbYellow.Visible = false;
            // 
            // pbBlue
            // 
            this.pbBlue.BackColor = System.Drawing.Color.Transparent;
            this.pbBlue.ErrorImage = null;
            this.pbBlue.Image = global::Lead.CPrim.Common.Properties.Resources.blue;
            this.pbBlue.InitialImage = null;
            this.pbBlue.Location = new System.Drawing.Point(715, 336);
            this.pbBlue.Name = "pbBlue";
            this.pbBlue.Size = new System.Drawing.Size(25, 25);
            this.pbBlue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBlue.TabIndex = 4;
            this.pbBlue.TabStop = false;
            this.pbBlue.Visible = false;
            // 
            // pbGray
            // 
            this.pbGray.BackColor = System.Drawing.Color.Transparent;
            this.pbGray.ErrorImage = null;
            this.pbGray.Image = global::Lead.CPrim.Common.Properties.Resources.gray;
            this.pbGray.InitialImage = null;
            this.pbGray.Location = new System.Drawing.Point(662, 336);
            this.pbGray.Name = "pbGray";
            this.pbGray.Size = new System.Drawing.Size(25, 25);
            this.pbGray.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGray.TabIndex = 3;
            this.pbGray.TabStop = false;
            this.pbGray.Visible = false;
            // 
            // dgvDi
            // 
            this.dgvDi.AllowUserToAddRows = false;
            this.dgvDi.AllowUserToDeleteRows = false;
            this.dgvDi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.diName,
            this.colEleDiInfo,
            this.diAdr,
            this.diStatue});
            this.dgvDi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDi.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvDi.Location = new System.Drawing.Point(0, 0);
            this.dgvDi.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvDi.Name = "dgvDi";
            this.dgvDi.ReadOnly = true;
            this.dgvDi.RowHeadersWidth = 70;
            this.dgvDi.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDi.RowTemplate.Height = 27;
            this.dgvDi.Size = new System.Drawing.Size(1400, 630);
            this.dgvDi.TabIndex = 0;
            this.dgvDi.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.RowStateChanged);
            // 
            // diName
            // 
            this.diName.HeaderText = "名称";
            this.diName.MinimumWidth = 6;
            this.diName.Name = "diName";
            this.diName.ReadOnly = true;
            this.diName.Width = 240;
            // 
            // colEleDiInfo
            // 
            this.colEleDiInfo.HeaderText = "信息";
            this.colEleDiInfo.MinimumWidth = 6;
            this.colEleDiInfo.Name = "colEleDiInfo";
            this.colEleDiInfo.ReadOnly = true;
            this.colEleDiInfo.Width = 125;
            // 
            // diAdr
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.diAdr.DefaultCellStyle = dataGridViewCellStyle2;
            this.diAdr.HeaderText = "地址";
            this.diAdr.MinimumWidth = 6;
            this.diAdr.Name = "diAdr";
            this.diAdr.ReadOnly = true;
            this.diAdr.Width = 70;
            // 
            // diStatue
            // 
            this.diStatue.HeaderText = "状态";
            this.diStatue.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.diStatue.MinimumWidth = 6;
            this.diStatue.Name = "diStatue";
            this.diStatue.ReadOnly = true;
            this.diStatue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.diStatue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.diStatue.Width = 50;
            // 
            // tpDo
            // 
            this.tpDo.Controls.Add(this.dgvDo);
            this.tpDo.Location = new System.Drawing.Point(4, 30);
            this.tpDo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tpDo.Name = "tpDo";
            this.tpDo.Size = new System.Drawing.Size(1400, 630);
            this.tpDo.TabIndex = 1;
            this.tpDo.Text = "数字量输出";
            this.tpDo.UseVisualStyleBackColor = true;
            // 
            // dgvDo
            // 
            this.dgvDo.AllowUserToAddRows = false;
            this.dgvDo.AllowUserToDeleteRows = false;
            this.dgvDo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.doName,
            this.colEleDoInfo,
            this.doAdr,
            this.doStatue});
            this.dgvDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDo.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvDo.Location = new System.Drawing.Point(0, 0);
            this.dgvDo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvDo.Name = "dgvDo";
            this.dgvDo.ReadOnly = true;
            this.dgvDo.RowHeadersWidth = 70;
            this.dgvDo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDo.RowTemplate.Height = 27;
            this.dgvDo.Size = new System.Drawing.Size(1400, 630);
            this.dgvDo.TabIndex = 1;
            this.dgvDo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDo_CellClick);
            this.dgvDo.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.RowStateChanged);
            // 
            // doName
            // 
            this.doName.HeaderText = "名称";
            this.doName.MinimumWidth = 6;
            this.doName.Name = "doName";
            this.doName.ReadOnly = true;
            this.doName.Width = 240;
            // 
            // colEleDoInfo
            // 
            this.colEleDoInfo.HeaderText = "信息";
            this.colEleDoInfo.MinimumWidth = 6;
            this.colEleDoInfo.Name = "colEleDoInfo";
            this.colEleDoInfo.ReadOnly = true;
            this.colEleDoInfo.Width = 125;
            // 
            // doAdr
            // 
            this.doAdr.HeaderText = "地址";
            this.doAdr.MinimumWidth = 6;
            this.doAdr.Name = "doAdr";
            this.doAdr.ReadOnly = true;
            this.doAdr.Width = 70;
            // 
            // doStatue
            // 
            this.doStatue.HeaderText = "状态";
            this.doStatue.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.doStatue.MinimumWidth = 6;
            this.doStatue.Name = "doStatue";
            this.doStatue.ReadOnly = true;
            this.doStatue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.doStatue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.doStatue.Width = 50;
            // 
            // tpCyl
            // 
            this.tpCyl.Controls.Add(this.tlpCylinder);
            this.tpCyl.Controls.Add(this.dataGridView3);
            this.tpCyl.Location = new System.Drawing.Point(4, 30);
            this.tpCyl.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tpCyl.Name = "tpCyl";
            this.tpCyl.Size = new System.Drawing.Size(1400, 630);
            this.tpCyl.TabIndex = 2;
            this.tpCyl.Text = "气缸/真空";
            this.tpCyl.UseVisualStyleBackColor = true;
            // 
            // tlpCylinder
            // 
            this.tlpCylinder.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tlpCylinder.ColumnCount = 2;
            this.tlpCylinder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.42857F));
            this.tlpCylinder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.57143F));
            this.tlpCylinder.Controls.Add(this.dgvCylinder, 0, 0);
            this.tlpCylinder.Controls.Add(this.pnlCylinder, 1, 0);
            this.tlpCylinder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCylinder.Location = new System.Drawing.Point(0, 0);
            this.tlpCylinder.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCylinder.Name = "tlpCylinder";
            this.tlpCylinder.RowCount = 1;
            this.tlpCylinder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCylinder.Size = new System.Drawing.Size(1400, 630);
            this.tlpCylinder.TabIndex = 3;
            // 
            // dgvCylinder
            // 
            this.dgvCylinder.AllowUserToAddRows = false;
            this.dgvCylinder.AllowUserToDeleteRows = false;
            this.dgvCylinder.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCylinder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCylinder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCylinder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cylName,
            this.colEleCylInfo,
            this.cylHP,
            this.cylWP});
            this.dgvCylinder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCylinder.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvCylinder.Location = new System.Drawing.Point(0, 0);
            this.dgvCylinder.Margin = new System.Windows.Forms.Padding(0);
            this.dgvCylinder.Name = "dgvCylinder";
            this.dgvCylinder.ReadOnly = true;
            this.dgvCylinder.RowHeadersWidth = 70;
            this.dgvCylinder.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCylinder.RowTemplate.Height = 27;
            this.dgvCylinder.Size = new System.Drawing.Size(902, 630);
            this.dgvCylinder.TabIndex = 2;
            this.dgvCylinder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCylinder_CellClick);
            this.dgvCylinder.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.RowStateChanged);
            // 
            // cylName
            // 
            this.cylName.HeaderText = "名称";
            this.cylName.MinimumWidth = 6;
            this.cylName.Name = "cylName";
            this.cylName.ReadOnly = true;
            this.cylName.Width = 240;
            // 
            // colEleCylInfo
            // 
            this.colEleCylInfo.HeaderText = "信息";
            this.colEleCylInfo.MinimumWidth = 6;
            this.colEleCylInfo.Name = "colEleCylInfo";
            this.colEleCylInfo.ReadOnly = true;
            this.colEleCylInfo.Width = 125;
            // 
            // cylHP
            // 
            this.cylHP.HeaderText = "原位";
            this.cylHP.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.cylHP.MinimumWidth = 6;
            this.cylHP.Name = "cylHP";
            this.cylHP.ReadOnly = true;
            this.cylHP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cylHP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cylHP.Width = 50;
            // 
            // cylWP
            // 
            this.cylWP.HeaderText = "伸位";
            this.cylWP.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.cylWP.MinimumWidth = 6;
            this.cylWP.Name = "cylWP";
            this.cylWP.ReadOnly = true;
            this.cylWP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cylWP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cylWP.Width = 50;
            // 
            // pnlCylinder
            // 
            this.pnlCylinder.Controls.Add(this.tb_Retract_Cylinder);
            this.pnlCylinder.Controls.Add(this.label3);
            this.pnlCylinder.Controls.Add(this.lb_Retract_Cylinder);
            this.pnlCylinder.Controls.Add(this.tb_Stretch_Cylinder);
            this.pnlCylinder.Controls.Add(this.label1);
            this.pnlCylinder.Controls.Add(this.lb_Stretch_Cylinder);
            this.pnlCylinder.Controls.Add(this.btnStop);
            this.pnlCylinder.Controls.Add(this.btnStart);
            this.pnlCylinder.Controls.Add(this.txtCount);
            this.pnlCylinder.Controls.Add(this.txtTime);
            this.pnlCylinder.Controls.Add(this.txtCylinderName);
            this.pnlCylinder.Controls.Add(this.label5);
            this.pnlCylinder.Controls.Add(this.lb_TrigCount);
            this.pnlCylinder.Controls.Add(this.label4);
            this.pnlCylinder.Controls.Add(this.lb_IntervalTime);
            this.pnlCylinder.Controls.Add(this.lb_CylinderName);
            this.pnlCylinder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCylinder.Location = new System.Drawing.Point(902, 0);
            this.pnlCylinder.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCylinder.Name = "pnlCylinder";
            this.pnlCylinder.Size = new System.Drawing.Size(498, 630);
            this.pnlCylinder.TabIndex = 3;
            // 
            // tb_Retract_Cylinder
            // 
            this.tb_Retract_Cylinder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Retract_Cylinder.Location = new System.Drawing.Point(211, 471);
            this.tb_Retract_Cylinder.Name = "tb_Retract_Cylinder";
            this.tb_Retract_Cylinder.Size = new System.Drawing.Size(218, 29);
            this.tb_Retract_Cylinder.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(435, 474);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "ms";
            // 
            // lb_Retract_Cylinder
            // 
            this.lb_Retract_Cylinder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Retract_Cylinder.AutoSize = true;
            this.lb_Retract_Cylinder.Location = new System.Drawing.Point(117, 474);
            this.lb_Retract_Cylinder.Name = "lb_Retract_Cylinder";
            this.lb_Retract_Cylinder.Size = new System.Drawing.Size(74, 21);
            this.lb_Retract_Cylinder.TabIndex = 7;
            this.lb_Retract_Cylinder.Text = "缩回时间";
            // 
            // tb_Stretch_Cylinder
            // 
            this.tb_Stretch_Cylinder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Stretch_Cylinder.Location = new System.Drawing.Point(211, 417);
            this.tb_Stretch_Cylinder.Name = "tb_Stretch_Cylinder";
            this.tb_Stretch_Cylinder.Size = new System.Drawing.Size(218, 29);
            this.tb_Stretch_Cylinder.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(435, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "ms";
            // 
            // lb_Stretch_Cylinder
            // 
            this.lb_Stretch_Cylinder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Stretch_Cylinder.AutoSize = true;
            this.lb_Stretch_Cylinder.Location = new System.Drawing.Point(117, 420);
            this.lb_Stretch_Cylinder.Name = "lb_Stretch_Cylinder";
            this.lb_Stretch_Cylinder.Size = new System.Drawing.Size(74, 21);
            this.lb_Stretch_Cylinder.TabIndex = 4;
            this.lb_Stretch_Cylinder.Text = "伸出时间";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.Location = new System.Drawing.Point(293, 332);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(136, 56);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(121, 332);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(136, 56);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "执行";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtCount
            // 
            this.txtCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCount.Location = new System.Drawing.Point(211, 235);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(218, 29);
            this.txtCount.TabIndex = 1;
            // 
            // txtTime
            // 
            this.txtTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTime.Location = new System.Drawing.Point(211, 161);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(218, 29);
            this.txtTime.TabIndex = 1;
            // 
            // txtCylinderName
            // 
            this.txtCylinderName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCylinderName.Enabled = false;
            this.txtCylinderName.Location = new System.Drawing.Point(211, 83);
            this.txtCylinderName.Name = "txtCylinderName";
            this.txtCylinderName.Size = new System.Drawing.Size(218, 29);
            this.txtCylinderName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(435, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "1-100";
            // 
            // lb_TrigCount
            // 
            this.lb_TrigCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_TrigCount.AutoSize = true;
            this.lb_TrigCount.Location = new System.Drawing.Point(117, 238);
            this.lb_TrigCount.Name = "lb_TrigCount";
            this.lb_TrigCount.Size = new System.Drawing.Size(74, 21);
            this.lb_TrigCount.TabIndex = 0;
            this.lb_TrigCount.Text = "触发次数";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(435, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "ms";
            // 
            // lb_IntervalTime
            // 
            this.lb_IntervalTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_IntervalTime.AutoSize = true;
            this.lb_IntervalTime.Location = new System.Drawing.Point(117, 164);
            this.lb_IntervalTime.Name = "lb_IntervalTime";
            this.lb_IntervalTime.Size = new System.Drawing.Size(74, 21);
            this.lb_IntervalTime.TabIndex = 0;
            this.lb_IntervalTime.Text = "间隔时间";
            // 
            // lb_CylinderName
            // 
            this.lb_CylinderName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_CylinderName.AutoSize = true;
            this.lb_CylinderName.Location = new System.Drawing.Point(117, 87);
            this.lb_CylinderName.Name = "lb_CylinderName";
            this.lb_CylinderName.Size = new System.Drawing.Size(74, 21);
            this.lb_CylinderName.TabIndex = 0;
            this.lb_CylinderName.Text = "气缸名称";
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(0, 0);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 27;
            this.dataGridView3.Size = new System.Drawing.Size(1400, 630);
            this.dataGridView3.TabIndex = 1;
            // 
            // tpLight
            // 
            this.tpLight.Controls.Add(this.dgvLight);
            this.tpLight.Location = new System.Drawing.Point(4, 30);
            this.tpLight.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tpLight.Name = "tpLight";
            this.tpLight.Size = new System.Drawing.Size(1400, 630);
            this.tpLight.TabIndex = 4;
            this.tpLight.Text = "三色灯/按钮灯";
            this.tpLight.UseVisualStyleBackColor = true;
            // 
            // dgvLight
            // 
            this.dgvLight.AllowUserToAddRows = false;
            this.dgvLight.AllowUserToDeleteRows = false;
            this.dgvLight.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLight.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLight.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLightName,
            this.colEleLightInfo,
            this.colLightRed,
            this.colLightYellow,
            this.colLightGreen,
            this.colLightBuzzer});
            this.dgvLight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLight.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvLight.Location = new System.Drawing.Point(0, 0);
            this.dgvLight.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvLight.Name = "dgvLight";
            this.dgvLight.ReadOnly = true;
            this.dgvLight.RowHeadersWidth = 70;
            this.dgvLight.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvLight.RowTemplate.Height = 27;
            this.dgvLight.Size = new System.Drawing.Size(1400, 630);
            this.dgvLight.TabIndex = 3;
            this.dgvLight.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLight_CellClick);
            this.dgvLight.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.RowStateChanged);
            // 
            // colLightName
            // 
            this.colLightName.HeaderText = "名称";
            this.colLightName.MinimumWidth = 6;
            this.colLightName.Name = "colLightName";
            this.colLightName.ReadOnly = true;
            this.colLightName.Width = 75;
            // 
            // colEleLightInfo
            // 
            this.colEleLightInfo.HeaderText = "信息";
            this.colEleLightInfo.MinimumWidth = 6;
            this.colEleLightInfo.Name = "colEleLightInfo";
            this.colEleLightInfo.ReadOnly = true;
            this.colEleLightInfo.Width = 125;
            // 
            // colLightRed
            // 
            this.colLightRed.HeaderText = "红灯";
            this.colLightRed.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colLightRed.MinimumWidth = 6;
            this.colLightRed.Name = "colLightRed";
            this.colLightRed.ReadOnly = true;
            this.colLightRed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colLightRed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colLightRed.Width = 75;
            // 
            // colLightYellow
            // 
            this.colLightYellow.HeaderText = "黄灯";
            this.colLightYellow.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colLightYellow.MinimumWidth = 6;
            this.colLightYellow.Name = "colLightYellow";
            this.colLightYellow.ReadOnly = true;
            this.colLightYellow.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colLightYellow.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colLightYellow.Width = 75;
            // 
            // colLightGreen
            // 
            this.colLightGreen.HeaderText = "绿灯";
            this.colLightGreen.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colLightGreen.MinimumWidth = 8;
            this.colLightGreen.Name = "colLightGreen";
            this.colLightGreen.ReadOnly = true;
            this.colLightGreen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colLightGreen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colLightGreen.Width = 75;
            // 
            // colLightBuzzer
            // 
            this.colLightBuzzer.HeaderText = "蜂鸣器";
            this.colLightBuzzer.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colLightBuzzer.MinimumWidth = 8;
            this.colLightBuzzer.Name = "colLightBuzzer";
            this.colLightBuzzer.ReadOnly = true;
            this.colLightBuzzer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colLightBuzzer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colLightBuzzer.Width = 94;
            // 
            // tpCartesian
            // 
            this.tpCartesian.Controls.Add(this.tabCartesians);
            this.tpCartesian.Location = new System.Drawing.Point(4, 30);
            this.tpCartesian.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tpCartesian.Name = "tpCartesian";
            this.tpCartesian.Size = new System.Drawing.Size(1400, 630);
            this.tpCartesian.TabIndex = 3;
            this.tpCartesian.Text = "轴组";
            this.tpCartesian.UseVisualStyleBackColor = true;
            // 
            // tabCartesians
            // 
            this.tabCartesians.Controls.Add(this.tabPage1);
            this.tabCartesians.Controls.Add(this.tabPage2);
            this.tabCartesians.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCartesians.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabCartesians.Location = new System.Drawing.Point(0, 0);
            this.tabCartesians.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabCartesians.Name = "tabCartesians";
            this.tabCartesians.SelectedIndex = 0;
            this.tabCartesians.Size = new System.Drawing.Size(1400, 630);
            this.tabCartesians.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Size = new System.Drawing.Size(1392, 596);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Size = new System.Drawing.Size(1392, 596);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // ElementsUserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1408, 664);
            this.Controls.Add(this.tabEles);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "ElementsUserView";
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.Text = "元件调试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ElementsUserView_FormClosing);
            this.Load += new System.EventHandler(this.ElementsUserView_Load);
            this.VisibleChanged += new System.EventHandler(this.ElementsUserView_VisibleChanged);
            this.tabEles.ResumeLayout(false);
            this.tpDi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbYellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDi)).EndInit();
            this.tpDo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDo)).EndInit();
            this.tpCyl.ResumeLayout(false);
            this.tlpCylinder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCylinder)).EndInit();
            this.pnlCylinder.ResumeLayout(false);
            this.pnlCylinder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tpLight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLight)).EndInit();
            this.tpCartesian.ResumeLayout(false);
            this.tabCartesians.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl tabEles;
        private TabPage tpDi;
        private TabPage tpDo;
        private DataGridView dgvDi;
        private TabPage tpCyl;
        private TabPage tpCartesian;
        private DataGridView dataGridView3;
        private DataGridView dgvDo;
        private DataGridView dgvCylinder;
        private TabControl tabCartesians;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Timer timer1;
        private TabPage tpLight;
        private DataGridView dgvLight;
        private PictureBox pbBlue;
        private PictureBox pbGray;
        private PictureBox pbRed;
        private PictureBox pbYellow;
        private PictureBox pbGreen;
        private TableLayoutPanel tlpCylinder;
        private Panel pnlCylinder;
        private Button btnStart;
        private TextBox txtCount;
        private TextBox txtTime;
        private TextBox txtCylinderName;
        private Label lb_TrigCount;
        private Label lb_IntervalTime;
        private Label lb_CylinderName;
        private Label label4;
        private Label label5;
        private Button btnStop;
        private TextBox tb_Retract_Cylinder;
        private Label label3;
        private Label lb_Retract_Cylinder;
        private TextBox tb_Stretch_Cylinder;
        private Label label1;
        private Label lb_Stretch_Cylinder;
        private DataGridViewTextBoxColumn diName;
        private DataGridViewTextBoxColumn colEleDiInfo;
        private DataGridViewTextBoxColumn diAdr;
        private DataGridViewImageColumn diStatue;
        private DataGridViewTextBoxColumn doName;
        private DataGridViewTextBoxColumn colEleDoInfo;
        private DataGridViewTextBoxColumn doAdr;
        private DataGridViewImageColumn doStatue;
        private DataGridViewTextBoxColumn cylName;
        private DataGridViewTextBoxColumn colEleCylInfo;
        private DataGridViewImageColumn cylHP;
        private DataGridViewImageColumn cylWP;
        private DataGridViewTextBoxColumn colLightName;
        private DataGridViewTextBoxColumn colEleLightInfo;
        private DataGridViewImageColumn colLightRed;
        private DataGridViewImageColumn colLightYellow;
        private DataGridViewImageColumn colLightGreen;
        private DataGridViewImageColumn colLightBuzzer;
    }
}
