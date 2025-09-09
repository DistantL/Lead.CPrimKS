using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.EleCartesian.EleUIs
{
    partial class ConfigUI
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private IContainer components = null;

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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabCartesianConfig = new System.Windows.Forms.TabControl();
            this.tabPageAxisConfig = new System.Windows.Forms.TabPage();
            this.flowPanelConfig = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageAxisStatus = new System.Windows.Forms.TabPage();
            this.flowPanelStatus = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageManual = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.cmbJumpHeightZ = new System.Windows.Forms.ComboBox();
            this.btnPosJump = new System.Windows.Forms.Button();
            this.btnPosMoveP = new System.Windows.Forms.Button();
            this.btnPosDelete = new System.Windows.Forms.Button();
            this.btnPosTeach = new System.Windows.Forms.Button();
            this.cmbPointMove = new System.Windows.Forms.ComboBox();
            this.cmbPointTeach = new System.Windows.Forms.ComboBox();
            this.dgPoints = new System.Windows.Forms.DataGridView();
            this.PName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnuPoints = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmToPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnMinusZ = new System.Windows.Forms.Button();
            this.btnMinusX = new System.Windows.Forms.Button();
            this.btnPlusY = new System.Windows.Forms.Button();
            this.btnMinusW = new System.Windows.Forms.Button();
            this.btnMinusV = new System.Windows.Forms.Button();
            this.btnMinusU = new System.Windows.Forms.Button();
            this.btnMinusY = new System.Windows.Forms.Button();
            this.btnPlusZ = new System.Windows.Forms.Button();
            this.btnAllStop = new System.Windows.Forms.Button();
            this.btnPlusX = new System.Windows.Forms.Button();
            this.btnPlusW = new System.Windows.Forms.Button();
            this.btnPlusV = new System.Windows.Forms.Button();
            this.btnPlusU = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnServoOffAll = new System.Windows.Forms.Button();
            this.btnHomeStop = new System.Windows.Forms.Button();
            this.btnHomeAll = new System.Windows.Forms.Button();
            this.buttonAxisServoOff = new System.Windows.Forms.Button();
            this.btnServoOnAll = new System.Windows.Forms.Button();
            this.cmbHomeOrderW = new System.Windows.Forms.ComboBox();
            this.cmbHomeOrderV = new System.Windows.Forms.ComboBox();
            this.cmbHomeOrderZ = new System.Windows.Forms.ComboBox();
            this.cmbHomeOrderY = new System.Windows.Forms.ComboBox();
            this.cmbHomeOrderX = new System.Windows.Forms.ComboBox();
            this.btnServoW = new System.Windows.Forms.Button();
            this.btnHomeW = new System.Windows.Forms.Button();
            this.btnServoV = new System.Windows.Forms.Button();
            this.btnHomeV = new System.Windows.Forms.Button();
            this.btnServoU = new System.Windows.Forms.Button();
            this.btnHomeU = new System.Windows.Forms.Button();
            this.btnServoZ = new System.Windows.Forms.Button();
            this.btnHomeZ = new System.Windows.Forms.Button();
            this.btnServoY = new System.Windows.Forms.Button();
            this.btnHomeY = new System.Windows.Forms.Button();
            this.btnServoX = new System.Windows.Forms.Button();
            this.btnHomeX = new System.Windows.Forms.Button();
            this.cmbHomeOrderU = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.radMedium = new System.Windows.Forms.RadioButton();
            this.radShort = new System.Windows.Forms.RadioButton();
            this.radLong = new System.Windows.Forms.RadioButton();
            this.label30 = new System.Windows.Forms.Label();
            this.cmbStepX = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cmbStepU = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.cmbStepW = new System.Windows.Forms.ComboBox();
            this.cmbStepY = new System.Windows.Forms.ComboBox();
            this.cmbStepZ = new System.Windows.Forms.ComboBox();
            this.cmbStepV = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.tbOrgW = new System.Windows.Forms.TextBox();
            this.tbMelW = new System.Windows.Forms.TextBox();
            this.tbOrgZ = new System.Windows.Forms.TextBox();
            this.tbMelZ = new System.Windows.Forms.TextBox();
            this.tbOrgV = new System.Windows.Forms.TextBox();
            this.tbMelV = new System.Windows.Forms.TextBox();
            this.tbOrgY = new System.Windows.Forms.TextBox();
            this.tbMelY = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbPelW = new System.Windows.Forms.TextBox();
            this.tbPelZ = new System.Windows.Forms.TextBox();
            this.tbOrgU = new System.Windows.Forms.TextBox();
            this.tbMelU = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbOrgX = new System.Windows.Forms.TextBox();
            this.tbMelX = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbPelV = new System.Windows.Forms.TextBox();
            this.tbPelY = new System.Windows.Forms.TextBox();
            this.tbPelU = new System.Windows.Forms.TextBox();
            this.tbPelX = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbPosW = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPosZ = new System.Windows.Forms.TextBox();
            this.tbPosX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPosY = new System.Windows.Forms.TextBox();
            this.tbPosU = new System.Windows.Forms.TextBox();
            this.tbPosV = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbVelW = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbVelZ = new System.Windows.Forms.TextBox();
            this.tbVelX = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbVelY = new System.Windows.Forms.TextBox();
            this.tbVelU = new System.Windows.Forms.TextBox();
            this.tbVelV = new System.Windows.Forms.TextBox();
            this.tabPageInterpolation = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnOpenPoints = new System.Windows.Forms.Button();
            this.btnConfigApply = new System.Windows.Forms.Button();
            this.cBoxLogDisplay = new System.Windows.Forms.CheckBox();
            this.cBoxLogEnable = new System.Windows.Forms.CheckBox();
            this.cBoxSimulate = new System.Windows.Forms.CheckBox();
            this.cBoxEnable = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbAxisesConfigPath = new System.Windows.Forms.TextBox();
            this.btnAxisesSaveAs = new System.Windows.Forms.Button();
            this.btnAxisesLoad = new System.Windows.Forms.Button();
            this.btnAxisesBrowse = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cBoxAxisNum = new System.Windows.Forms.ComboBox();
            this.lbFeedBackType = new System.Windows.Forms.Label();
            this.cBoxVelMode = new System.Windows.Forms.ComboBox();
            this.lbVelMode = new System.Windows.Forms.Label();
            this.cBoxDevName = new System.Windows.Forms.ComboBox();
            this.lbDevName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbState = new System.Windows.Forms.TextBox();
            this.lbState = new System.Windows.Forms.Label();
            this.tbType = new System.Windows.Forms.TextBox();
            this.lbType = new System.Windows.Forms.Label();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabCartesianConfig.SuspendLayout();
            this.tabPageAxisConfig.SuspendLayout();
            this.tabPageAxisStatus.SuspendLayout();
            this.tabPageManual.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPoints)).BeginInit();
            this.mnuPoints.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabCartesianConfig, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 715);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabCartesianConfig
            // 
            this.tabCartesianConfig.Controls.Add(this.tabPageAxisConfig);
            this.tabCartesianConfig.Controls.Add(this.tabPageAxisStatus);
            this.tabCartesianConfig.Controls.Add(this.tabPageManual);
            this.tabCartesianConfig.Controls.Add(this.tabPageInterpolation);
            this.tabCartesianConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCartesianConfig.Location = new System.Drawing.Point(0, 56);
            this.tabCartesianConfig.Margin = new System.Windows.Forms.Padding(0);
            this.tabCartesianConfig.Name = "tabCartesianConfig";
            this.tabCartesianConfig.SelectedIndex = 0;
            this.tabCartesianConfig.Size = new System.Drawing.Size(800, 604);
            this.tabCartesianConfig.TabIndex = 15;
            // 
            // tabPageAxisConfig
            // 
            this.tabPageAxisConfig.Controls.Add(this.flowPanelConfig);
            this.tabPageAxisConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPageAxisConfig.Name = "tabPageAxisConfig";
            this.tabPageAxisConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAxisConfig.Size = new System.Drawing.Size(792, 578);
            this.tabPageAxisConfig.TabIndex = 0;
            this.tabPageAxisConfig.Text = "AxisConfig";
            this.tabPageAxisConfig.UseVisualStyleBackColor = true;
            // 
            // flowPanelConfig
            // 
            this.flowPanelConfig.AutoScroll = true;
            this.flowPanelConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowPanelConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelConfig.Location = new System.Drawing.Point(3, 3);
            this.flowPanelConfig.Name = "flowPanelConfig";
            this.flowPanelConfig.Size = new System.Drawing.Size(786, 572);
            this.flowPanelConfig.TabIndex = 0;
            // 
            // tabPageAxisStatus
            // 
            this.tabPageAxisStatus.Controls.Add(this.flowPanelStatus);
            this.tabPageAxisStatus.Location = new System.Drawing.Point(4, 22);
            this.tabPageAxisStatus.Name = "tabPageAxisStatus";
            this.tabPageAxisStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAxisStatus.Size = new System.Drawing.Size(792, 578);
            this.tabPageAxisStatus.TabIndex = 1;
            this.tabPageAxisStatus.Text = "AxisStatus";
            this.tabPageAxisStatus.UseVisualStyleBackColor = true;
            // 
            // flowPanelStatus
            // 
            this.flowPanelStatus.AutoScroll = true;
            this.flowPanelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowPanelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelStatus.Location = new System.Drawing.Point(3, 3);
            this.flowPanelStatus.Name = "flowPanelStatus";
            this.flowPanelStatus.Size = new System.Drawing.Size(786, 572);
            this.flowPanelStatus.TabIndex = 1;
            // 
            // tabPageManual
            // 
            this.tabPageManual.Controls.Add(this.tableLayoutPanel2);
            this.tabPageManual.Location = new System.Drawing.Point(4, 22);
            this.tabPageManual.Name = "tabPageManual";
            this.tabPageManual.Size = new System.Drawing.Size(792, 578);
            this.tabPageManual.TabIndex = 3;
            this.tabPageManual.Text = "Manual";
            this.tabPageManual.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.09091F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.90909F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.dgPoints, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxStatus, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.5802F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0701F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.06931F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.28039F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(792, 578);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.cmbJumpHeightZ);
            this.groupBox2.Controls.Add(this.btnPosJump);
            this.groupBox2.Controls.Add(this.btnPosMoveP);
            this.groupBox2.Controls.Add(this.btnPosDelete);
            this.groupBox2.Controls.Add(this.btnPosTeach);
            this.groupBox2.Controls.Add(this.cmbPointMove);
            this.groupBox2.Controls.Add(this.cmbPointTeach);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(472, 458);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(316, 116);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(269, 50);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(15, 16);
            this.label31.TabIndex = 8;
            this.label31.Text = "Z";
            // 
            // cmbJumpHeightZ
            // 
            this.cmbJumpHeightZ.FormattingEnabled = true;
            this.cmbJumpHeightZ.Location = new System.Drawing.Point(250, 70);
            this.cmbJumpHeightZ.Margin = new System.Windows.Forms.Padding(4);
            this.cmbJumpHeightZ.Name = "cmbJumpHeightZ";
            this.cmbJumpHeightZ.Size = new System.Drawing.Size(61, 24);
            this.cmbJumpHeightZ.TabIndex = 7;
            // 
            // btnPosJump
            // 
            this.btnPosJump.Location = new System.Drawing.Point(185, 68);
            this.btnPosJump.Margin = new System.Windows.Forms.Padding(4);
            this.btnPosJump.Name = "btnPosJump";
            this.btnPosJump.Size = new System.Drawing.Size(62, 29);
            this.btnPosJump.TabIndex = 5;
            this.btnPosJump.Text = "Jump";
            this.btnPosJump.UseVisualStyleBackColor = true;
            this.btnPosJump.Click += new System.EventHandler(this.BtnPosJump_Click);
            // 
            // btnPosMoveP
            // 
            this.btnPosMoveP.Location = new System.Drawing.Point(118, 68);
            this.btnPosMoveP.Margin = new System.Windows.Forms.Padding(4);
            this.btnPosMoveP.Name = "btnPosMoveP";
            this.btnPosMoveP.Size = new System.Drawing.Size(59, 29);
            this.btnPosMoveP.TabIndex = 6;
            this.btnPosMoveP.Text = "MoveP";
            this.btnPosMoveP.UseVisualStyleBackColor = true;
            this.btnPosMoveP.Click += new System.EventHandler(this.BtnPosMoveP_Click);
            // 
            // btnPosDelete
            // 
            this.btnPosDelete.Location = new System.Drawing.Point(185, 20);
            this.btnPosDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnPosDelete.Name = "btnPosDelete";
            this.btnPosDelete.Size = new System.Drawing.Size(62, 29);
            this.btnPosDelete.TabIndex = 3;
            this.btnPosDelete.Text = "Delete";
            this.btnPosDelete.UseVisualStyleBackColor = true;
            this.btnPosDelete.Click += new System.EventHandler(this.BtnPosDelete_Click);
            // 
            // btnPosTeach
            // 
            this.btnPosTeach.Location = new System.Drawing.Point(118, 20);
            this.btnPosTeach.Margin = new System.Windows.Forms.Padding(4);
            this.btnPosTeach.Name = "btnPosTeach";
            this.btnPosTeach.Size = new System.Drawing.Size(59, 29);
            this.btnPosTeach.TabIndex = 4;
            this.btnPosTeach.Text = "Teach";
            this.btnPosTeach.UseVisualStyleBackColor = true;
            this.btnPosTeach.Click += new System.EventHandler(this.BtnPosTeach_Click);
            // 
            // cmbPointMove
            // 
            this.cmbPointMove.FormattingEnabled = true;
            this.cmbPointMove.Location = new System.Drawing.Point(8, 70);
            this.cmbPointMove.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPointMove.Name = "cmbPointMove";
            this.cmbPointMove.Size = new System.Drawing.Size(102, 24);
            this.cmbPointMove.TabIndex = 2;
            // 
            // cmbPointTeach
            // 
            this.cmbPointTeach.FormattingEnabled = true;
            this.cmbPointTeach.Location = new System.Drawing.Point(8, 25);
            this.cmbPointTeach.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPointTeach.Name = "cmbPointTeach";
            this.cmbPointTeach.Size = new System.Drawing.Size(102, 24);
            this.cmbPointTeach.TabIndex = 1;
            // 
            // dgPoints
            // 
            this.dgPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PName,
            this.X});
            this.dgPoints.ContextMenuStrip = this.mnuPoints;
            this.dgPoints.Location = new System.Drawing.Point(471, 3);
            this.dgPoints.Name = "dgPoints";
            this.dgPoints.RowHeadersWidth = 51;
            this.dgPoints.RowTemplate.Height = 27;
            this.dgPoints.Size = new System.Drawing.Size(318, 215);
            this.dgPoints.TabIndex = 27;
            // 
            // PName
            // 
            this.PName.HeaderText = "Name";
            this.PName.MinimumWidth = 6;
            this.PName.Name = "PName";
            this.PName.Width = 80;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.MinimumWidth = 6;
            this.X.Name = "X";
            this.X.Width = 80;
            // 
            // mnuPoints
            // 
            this.mnuPoints.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuPoints.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSave,
            this.tsmReLoad,
            this.tsmUpdate,
            this.tsmToPoint});
            this.mnuPoints.Name = "contextMenuStrip1";
            this.mnuPoints.Size = new System.Drawing.Size(121, 92);
            this.mnuPoints.Text = "Points";
            // 
            // tsmSave
            // 
            this.tsmSave.Name = "tsmSave";
            this.tsmSave.Size = new System.Drawing.Size(120, 22);
            this.tsmSave.Text = "Save";
            this.tsmSave.Click += new System.EventHandler(this.TsmSave_Click);
            // 
            // tsmReLoad
            // 
            this.tsmReLoad.Name = "tsmReLoad";
            this.tsmReLoad.Size = new System.Drawing.Size(120, 22);
            this.tsmReLoad.Text = "ReLoad";
            this.tsmReLoad.Click += new System.EventHandler(this.TsmReLoad_Click);
            // 
            // tsmUpdate
            // 
            this.tsmUpdate.Name = "tsmUpdate";
            this.tsmUpdate.Size = new System.Drawing.Size(120, 22);
            this.tsmUpdate.Text = "Update";
            this.tsmUpdate.Click += new System.EventHandler(this.TsmUpdate_Click);
            // 
            // tsmToPoint
            // 
            this.tsmToPoint.Name = "tsmToPoint";
            this.tsmToPoint.Size = new System.Drawing.Size(120, 22);
            this.tsmToPoint.Text = "ToPoint";
            this.tsmToPoint.Click += new System.EventHandler(this.TsmToPoint_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tabControl2);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.tableLayoutPanel2.SetRowSpan(this.groupBox3, 2);
            this.groupBox3.Size = new System.Drawing.Size(461, 330);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Manual";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.ItemSize = new System.Drawing.Size(80, 25);
            this.tabControl2.Location = new System.Drawing.Point(3, 17);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(455, 310);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl2.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnMinusZ);
            this.tabPage3.Controls.Add(this.btnMinusX);
            this.tabPage3.Controls.Add(this.btnPlusY);
            this.tabPage3.Controls.Add(this.btnMinusW);
            this.tabPage3.Controls.Add(this.btnMinusV);
            this.tabPage3.Controls.Add(this.btnMinusU);
            this.tabPage3.Controls.Add(this.btnMinusY);
            this.tabPage3.Controls.Add(this.btnPlusZ);
            this.tabPage3.Controls.Add(this.btnAllStop);
            this.tabPage3.Controls.Add(this.btnPlusX);
            this.tabPage3.Controls.Add(this.btnPlusW);
            this.tabPage3.Controls.Add(this.btnPlusV);
            this.tabPage3.Controls.Add(this.btnPlusU);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(447, 277);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Move";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnMinusZ
            // 
            this.btnMinusZ.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMinusZ.Location = new System.Drawing.Point(339, 106);
            this.btnMinusZ.Margin = new System.Windows.Forms.Padding(4);
            this.btnMinusZ.Name = "btnMinusZ";
            this.btnMinusZ.Size = new System.Drawing.Size(100, 50);
            this.btnMinusZ.TabIndex = 0;
            this.btnMinusZ.Text = "Z-";
            this.btnMinusZ.UseVisualStyleBackColor = true;
            // 
            // btnMinusX
            // 
            this.btnMinusX.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMinusX.Location = new System.Drawing.Point(8, 58);
            this.btnMinusX.Margin = new System.Windows.Forms.Padding(4);
            this.btnMinusX.Name = "btnMinusX";
            this.btnMinusX.Size = new System.Drawing.Size(100, 50);
            this.btnMinusX.TabIndex = 0;
            this.btnMinusX.Text = "X-";
            this.btnMinusX.UseVisualStyleBackColor = true;
            // 
            // btnPlusY
            // 
            this.btnPlusY.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPlusY.Location = new System.Drawing.Point(118, 8);
            this.btnPlusY.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlusY.Name = "btnPlusY";
            this.btnPlusY.Size = new System.Drawing.Size(100, 50);
            this.btnPlusY.TabIndex = 0;
            this.btnPlusY.Text = "Y+";
            this.btnPlusY.UseVisualStyleBackColor = true;
            // 
            // btnMinusW
            // 
            this.btnMinusW.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMinusW.Location = new System.Drawing.Point(228, 226);
            this.btnMinusW.Margin = new System.Windows.Forms.Padding(4);
            this.btnMinusW.Name = "btnMinusW";
            this.btnMinusW.Size = new System.Drawing.Size(100, 50);
            this.btnMinusW.TabIndex = 0;
            this.btnMinusW.Text = "W-";
            this.btnMinusW.UseVisualStyleBackColor = true;
            // 
            // btnMinusV
            // 
            this.btnMinusV.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMinusV.Location = new System.Drawing.Point(119, 226);
            this.btnMinusV.Margin = new System.Windows.Forms.Padding(4);
            this.btnMinusV.Name = "btnMinusV";
            this.btnMinusV.Size = new System.Drawing.Size(100, 50);
            this.btnMinusV.TabIndex = 0;
            this.btnMinusV.Text = "V-";
            this.btnMinusV.UseVisualStyleBackColor = true;
            // 
            // btnMinusU
            // 
            this.btnMinusU.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMinusU.Location = new System.Drawing.Point(8, 226);
            this.btnMinusU.Margin = new System.Windows.Forms.Padding(4);
            this.btnMinusU.Name = "btnMinusU";
            this.btnMinusU.Size = new System.Drawing.Size(100, 50);
            this.btnMinusU.TabIndex = 0;
            this.btnMinusU.Text = "U-";
            this.btnMinusU.UseVisualStyleBackColor = true;
            // 
            // btnMinusY
            // 
            this.btnMinusY.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMinusY.Location = new System.Drawing.Point(119, 106);
            this.btnMinusY.Margin = new System.Windows.Forms.Padding(4);
            this.btnMinusY.Name = "btnMinusY";
            this.btnMinusY.Size = new System.Drawing.Size(100, 50);
            this.btnMinusY.TabIndex = 0;
            this.btnMinusY.Text = "Y-";
            this.btnMinusY.UseVisualStyleBackColor = true;
            // 
            // btnPlusZ
            // 
            this.btnPlusZ.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPlusZ.Location = new System.Drawing.Point(339, 8);
            this.btnPlusZ.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlusZ.Name = "btnPlusZ";
            this.btnPlusZ.Size = new System.Drawing.Size(100, 50);
            this.btnPlusZ.TabIndex = 0;
            this.btnPlusZ.Text = "Z+";
            this.btnPlusZ.UseVisualStyleBackColor = true;
            // 
            // btnAllStop
            // 
            this.btnAllStop.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAllStop.Location = new System.Drawing.Point(339, 163);
            this.btnAllStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnAllStop.Name = "btnAllStop";
            this.btnAllStop.Size = new System.Drawing.Size(100, 113);
            this.btnAllStop.TabIndex = 0;
            this.btnAllStop.Text = "Stop";
            this.btnAllStop.UseVisualStyleBackColor = true;
            this.btnAllStop.Click += new System.EventHandler(this.BtnAllStop_Click);
            // 
            // btnPlusX
            // 
            this.btnPlusX.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPlusX.Location = new System.Drawing.Point(228, 58);
            this.btnPlusX.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlusX.Name = "btnPlusX";
            this.btnPlusX.Size = new System.Drawing.Size(100, 50);
            this.btnPlusX.TabIndex = 0;
            this.btnPlusX.Text = "X+";
            this.btnPlusX.UseVisualStyleBackColor = true;
            // 
            // btnPlusW
            // 
            this.btnPlusW.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPlusW.Location = new System.Drawing.Point(228, 163);
            this.btnPlusW.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlusW.Name = "btnPlusW";
            this.btnPlusW.Size = new System.Drawing.Size(100, 50);
            this.btnPlusW.TabIndex = 0;
            this.btnPlusW.Text = "W+";
            this.btnPlusW.UseVisualStyleBackColor = true;
            // 
            // btnPlusV
            // 
            this.btnPlusV.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPlusV.Location = new System.Drawing.Point(118, 163);
            this.btnPlusV.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlusV.Name = "btnPlusV";
            this.btnPlusV.Size = new System.Drawing.Size(100, 50);
            this.btnPlusV.TabIndex = 0;
            this.btnPlusV.Text = "V+";
            this.btnPlusV.UseVisualStyleBackColor = true;
            // 
            // btnPlusU
            // 
            this.btnPlusU.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPlusU.Location = new System.Drawing.Point(8, 163);
            this.btnPlusU.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlusU.Name = "btnPlusU";
            this.btnPlusU.Size = new System.Drawing.Size(100, 50);
            this.btnPlusU.TabIndex = 0;
            this.btnPlusU.Text = "U+";
            this.btnPlusU.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnServoOffAll);
            this.tabPage4.Controls.Add(this.btnHomeStop);
            this.tabPage4.Controls.Add(this.btnHomeAll);
            this.tabPage4.Controls.Add(this.buttonAxisServoOff);
            this.tabPage4.Controls.Add(this.btnServoOnAll);
            this.tabPage4.Controls.Add(this.cmbHomeOrderW);
            this.tabPage4.Controls.Add(this.cmbHomeOrderV);
            this.tabPage4.Controls.Add(this.cmbHomeOrderZ);
            this.tabPage4.Controls.Add(this.cmbHomeOrderY);
            this.tabPage4.Controls.Add(this.cmbHomeOrderX);
            this.tabPage4.Controls.Add(this.btnServoW);
            this.tabPage4.Controls.Add(this.btnHomeW);
            this.tabPage4.Controls.Add(this.btnServoV);
            this.tabPage4.Controls.Add(this.btnHomeV);
            this.tabPage4.Controls.Add(this.btnServoU);
            this.tabPage4.Controls.Add(this.btnHomeU);
            this.tabPage4.Controls.Add(this.btnServoZ);
            this.tabPage4.Controls.Add(this.btnHomeZ);
            this.tabPage4.Controls.Add(this.btnServoY);
            this.tabPage4.Controls.Add(this.btnHomeY);
            this.tabPage4.Controls.Add(this.btnServoX);
            this.tabPage4.Controls.Add(this.btnHomeX);
            this.tabPage4.Controls.Add(this.cmbHomeOrderU);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage4.Size = new System.Drawing.Size(447, 277);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Origin";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnServoOffAll
            // 
            this.btnServoOffAll.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnServoOffAll.Location = new System.Drawing.Point(121, 223);
            this.btnServoOffAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnServoOffAll.Name = "btnServoOffAll";
            this.btnServoOffAll.Size = new System.Drawing.Size(100, 45);
            this.btnServoOffAll.TabIndex = 4;
            this.btnServoOffAll.Text = "All Axis Servo-OFF";
            this.btnServoOffAll.UseVisualStyleBackColor = true;
            this.btnServoOffAll.Click += new System.EventHandler(this.BtnServoOffAll_Click);
            // 
            // btnHomeStop
            // 
            this.btnHomeStop.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHomeStop.Location = new System.Drawing.Point(349, 7);
            this.btnHomeStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnHomeStop.Name = "btnHomeStop";
            this.btnHomeStop.Size = new System.Drawing.Size(88, 262);
            this.btnHomeStop.TabIndex = 3;
            this.btnHomeStop.Text = "Stop";
            this.btnHomeStop.UseVisualStyleBackColor = true;
            this.btnHomeStop.Click += new System.EventHandler(this.BtnAllStop_Click);
            // 
            // btnHomeAll
            // 
            this.btnHomeAll.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHomeAll.Location = new System.Drawing.Point(243, 220);
            this.btnHomeAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnHomeAll.Name = "btnHomeAll";
            this.btnHomeAll.Size = new System.Drawing.Size(100, 51);
            this.btnHomeAll.TabIndex = 2;
            this.btnHomeAll.Text = "All Axis Zero";
            this.btnHomeAll.UseVisualStyleBackColor = true;
            this.btnHomeAll.Click += new System.EventHandler(this.BtnHomeAll_Click);
            // 
            // buttonAxisServoOff
            // 
            this.buttonAxisServoOff.Location = new System.Drawing.Point(8, 277);
            this.buttonAxisServoOff.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAxisServoOff.Name = "buttonAxisServoOff";
            this.buttonAxisServoOff.Size = new System.Drawing.Size(100, 45);
            this.buttonAxisServoOff.TabIndex = 2;
            this.buttonAxisServoOff.Text = "All Axis Servo-OFF";
            this.buttonAxisServoOff.UseVisualStyleBackColor = true;
            // 
            // btnServoOnAll
            // 
            this.btnServoOnAll.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnServoOnAll.Location = new System.Drawing.Point(8, 224);
            this.btnServoOnAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnServoOnAll.Name = "btnServoOnAll";
            this.btnServoOnAll.Size = new System.Drawing.Size(100, 45);
            this.btnServoOnAll.TabIndex = 2;
            this.btnServoOnAll.Text = "All Axis Servo-ON";
            this.btnServoOnAll.UseVisualStyleBackColor = true;
            this.btnServoOnAll.Click += new System.EventHandler(this.BtnServoOnAll_Click);
            // 
            // cmbHomeOrderW
            // 
            this.cmbHomeOrderW.FormattingEnabled = true;
            this.cmbHomeOrderW.Location = new System.Drawing.Point(116, 188);
            this.cmbHomeOrderW.Margin = new System.Windows.Forms.Padding(4);
            this.cmbHomeOrderW.Name = "cmbHomeOrderW";
            this.cmbHomeOrderW.Size = new System.Drawing.Size(117, 24);
            this.cmbHomeOrderW.TabIndex = 0;
            // 
            // cmbHomeOrderV
            // 
            this.cmbHomeOrderV.FormattingEnabled = true;
            this.cmbHomeOrderV.Location = new System.Drawing.Point(116, 152);
            this.cmbHomeOrderV.Margin = new System.Windows.Forms.Padding(4);
            this.cmbHomeOrderV.Name = "cmbHomeOrderV";
            this.cmbHomeOrderV.Size = new System.Drawing.Size(117, 24);
            this.cmbHomeOrderV.TabIndex = 0;
            // 
            // cmbHomeOrderZ
            // 
            this.cmbHomeOrderZ.FormattingEnabled = true;
            this.cmbHomeOrderZ.Location = new System.Drawing.Point(116, 80);
            this.cmbHomeOrderZ.Margin = new System.Windows.Forms.Padding(4);
            this.cmbHomeOrderZ.Name = "cmbHomeOrderZ";
            this.cmbHomeOrderZ.Size = new System.Drawing.Size(117, 24);
            this.cmbHomeOrderZ.TabIndex = 0;
            // 
            // cmbHomeOrderY
            // 
            this.cmbHomeOrderY.FormattingEnabled = true;
            this.cmbHomeOrderY.Location = new System.Drawing.Point(116, 43);
            this.cmbHomeOrderY.Margin = new System.Windows.Forms.Padding(4);
            this.cmbHomeOrderY.Name = "cmbHomeOrderY";
            this.cmbHomeOrderY.Size = new System.Drawing.Size(117, 24);
            this.cmbHomeOrderY.TabIndex = 0;
            // 
            // cmbHomeOrderX
            // 
            this.cmbHomeOrderX.FormattingEnabled = true;
            this.cmbHomeOrderX.Location = new System.Drawing.Point(116, 7);
            this.cmbHomeOrderX.Margin = new System.Windows.Forms.Padding(4);
            this.cmbHomeOrderX.Name = "cmbHomeOrderX";
            this.cmbHomeOrderX.Size = new System.Drawing.Size(117, 24);
            this.cmbHomeOrderX.TabIndex = 0;
            // 
            // btnServoW
            // 
            this.btnServoW.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnServoW.Location = new System.Drawing.Point(8, 186);
            this.btnServoW.Margin = new System.Windows.Forms.Padding(4);
            this.btnServoW.Name = "btnServoW";
            this.btnServoW.Size = new System.Drawing.Size(100, 29);
            this.btnServoW.TabIndex = 1;
            this.btnServoW.Text = "W -Servo";
            this.btnServoW.UseVisualStyleBackColor = true;
            // 
            // btnHomeW
            // 
            this.btnHomeW.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHomeW.Location = new System.Drawing.Point(243, 188);
            this.btnHomeW.Margin = new System.Windows.Forms.Padding(4);
            this.btnHomeW.Name = "btnHomeW";
            this.btnHomeW.Size = new System.Drawing.Size(100, 29);
            this.btnHomeW.TabIndex = 1;
            this.btnHomeW.Text = "W -Zero";
            this.btnHomeW.UseVisualStyleBackColor = true;
            // 
            // btnServoV
            // 
            this.btnServoV.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnServoV.Location = new System.Drawing.Point(8, 150);
            this.btnServoV.Margin = new System.Windows.Forms.Padding(4);
            this.btnServoV.Name = "btnServoV";
            this.btnServoV.Size = new System.Drawing.Size(100, 29);
            this.btnServoV.TabIndex = 1;
            this.btnServoV.Text = "V -Servo";
            this.btnServoV.UseVisualStyleBackColor = true;
            // 
            // btnHomeV
            // 
            this.btnHomeV.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHomeV.Location = new System.Drawing.Point(243, 152);
            this.btnHomeV.Margin = new System.Windows.Forms.Padding(4);
            this.btnHomeV.Name = "btnHomeV";
            this.btnHomeV.Size = new System.Drawing.Size(100, 29);
            this.btnHomeV.TabIndex = 1;
            this.btnHomeV.Text = "V -Zero";
            this.btnHomeV.UseVisualStyleBackColor = true;
            // 
            // btnServoU
            // 
            this.btnServoU.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnServoU.Location = new System.Drawing.Point(8, 113);
            this.btnServoU.Margin = new System.Windows.Forms.Padding(4);
            this.btnServoU.Name = "btnServoU";
            this.btnServoU.Size = new System.Drawing.Size(100, 29);
            this.btnServoU.TabIndex = 1;
            this.btnServoU.Text = "U -Servo";
            this.btnServoU.UseVisualStyleBackColor = true;
            // 
            // btnHomeU
            // 
            this.btnHomeU.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHomeU.Location = new System.Drawing.Point(243, 116);
            this.btnHomeU.Margin = new System.Windows.Forms.Padding(4);
            this.btnHomeU.Name = "btnHomeU";
            this.btnHomeU.Size = new System.Drawing.Size(100, 29);
            this.btnHomeU.TabIndex = 1;
            this.btnHomeU.Text = "U -Zero";
            this.btnHomeU.UseVisualStyleBackColor = true;
            // 
            // btnServoZ
            // 
            this.btnServoZ.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnServoZ.Location = new System.Drawing.Point(8, 77);
            this.btnServoZ.Margin = new System.Windows.Forms.Padding(4);
            this.btnServoZ.Name = "btnServoZ";
            this.btnServoZ.Size = new System.Drawing.Size(100, 29);
            this.btnServoZ.TabIndex = 1;
            this.btnServoZ.Text = "Z -Servo";
            this.btnServoZ.UseVisualStyleBackColor = true;
            // 
            // btnHomeZ
            // 
            this.btnHomeZ.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHomeZ.Location = new System.Drawing.Point(243, 80);
            this.btnHomeZ.Margin = new System.Windows.Forms.Padding(4);
            this.btnHomeZ.Name = "btnHomeZ";
            this.btnHomeZ.Size = new System.Drawing.Size(100, 29);
            this.btnHomeZ.TabIndex = 1;
            this.btnHomeZ.Text = "Z -Zero";
            this.btnHomeZ.UseVisualStyleBackColor = true;
            // 
            // btnServoY
            // 
            this.btnServoY.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnServoY.Location = new System.Drawing.Point(8, 41);
            this.btnServoY.Margin = new System.Windows.Forms.Padding(4);
            this.btnServoY.Name = "btnServoY";
            this.btnServoY.Size = new System.Drawing.Size(100, 29);
            this.btnServoY.TabIndex = 1;
            this.btnServoY.Text = "Y -Servo";
            this.btnServoY.UseVisualStyleBackColor = true;
            // 
            // btnHomeY
            // 
            this.btnHomeY.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHomeY.Location = new System.Drawing.Point(243, 43);
            this.btnHomeY.Margin = new System.Windows.Forms.Padding(4);
            this.btnHomeY.Name = "btnHomeY";
            this.btnHomeY.Size = new System.Drawing.Size(100, 29);
            this.btnHomeY.TabIndex = 1;
            this.btnHomeY.Text = "Y -Zero";
            this.btnHomeY.UseVisualStyleBackColor = true;
            // 
            // btnServoX
            // 
            this.btnServoX.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnServoX.Location = new System.Drawing.Point(8, 4);
            this.btnServoX.Margin = new System.Windows.Forms.Padding(4);
            this.btnServoX.Name = "btnServoX";
            this.btnServoX.Size = new System.Drawing.Size(100, 29);
            this.btnServoX.TabIndex = 1;
            this.btnServoX.Text = "X -Servo";
            this.btnServoX.UseVisualStyleBackColor = true;
            // 
            // btnHomeX
            // 
            this.btnHomeX.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHomeX.Location = new System.Drawing.Point(243, 7);
            this.btnHomeX.Margin = new System.Windows.Forms.Padding(4);
            this.btnHomeX.Name = "btnHomeX";
            this.btnHomeX.Size = new System.Drawing.Size(100, 29);
            this.btnHomeX.TabIndex = 1;
            this.btnHomeX.Text = "X -Zero";
            this.btnHomeX.UseVisualStyleBackColor = true;
            // 
            // cmbHomeOrderU
            // 
            this.cmbHomeOrderU.FormattingEnabled = true;
            this.cmbHomeOrderU.Location = new System.Drawing.Point(116, 116);
            this.cmbHomeOrderU.Margin = new System.Windows.Forms.Padding(4);
            this.cmbHomeOrderU.Name = "cmbHomeOrderU";
            this.cmbHomeOrderU.Size = new System.Drawing.Size(117, 24);
            this.cmbHomeOrderU.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Controls.Add(this.label30);
            this.groupBox5.Controls.Add(this.cmbStepX);
            this.groupBox5.Controls.Add(this.label29);
            this.groupBox5.Controls.Add(this.cmbStepU);
            this.groupBox5.Controls.Add(this.label28);
            this.groupBox5.Controls.Add(this.cmbStepW);
            this.groupBox5.Controls.Add(this.cmbStepY);
            this.groupBox5.Controls.Add(this.cmbStepZ);
            this.groupBox5.Controls.Add(this.cmbStepV);
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(4, 342);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(460, 108);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Step Length";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.radMedium);
            this.groupBox7.Controls.Add(this.radShort);
            this.groupBox7.Controls.Add(this.radLong);
            this.groupBox7.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox7.Location = new System.Drawing.Point(9, 18);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox7.Size = new System.Drawing.Size(151, 86);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Distance";
            // 
            // radMedium
            // 
            this.radMedium.AutoSize = true;
            this.radMedium.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMedium.Location = new System.Drawing.Point(13, 42);
            this.radMedium.Margin = new System.Windows.Forms.Padding(4);
            this.radMedium.Name = "radMedium";
            this.radMedium.Size = new System.Drawing.Size(122, 20);
            this.radMedium.TabIndex = 3;
            this.radMedium.TabStop = true;
            this.radMedium.Text = "Medium Distance";
            this.radMedium.UseVisualStyleBackColor = true;
            // 
            // radShort
            // 
            this.radShort.AutoSize = true;
            this.radShort.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radShort.Location = new System.Drawing.Point(13, 67);
            this.radShort.Margin = new System.Windows.Forms.Padding(4);
            this.radShort.Name = "radShort";
            this.radShort.Size = new System.Drawing.Size(106, 20);
            this.radShort.TabIndex = 3;
            this.radShort.TabStop = true;
            this.radShort.Text = "Short Distance";
            this.radShort.UseVisualStyleBackColor = true;
            // 
            // radLong
            // 
            this.radLong.AutoSize = true;
            this.radLong.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLong.Location = new System.Drawing.Point(13, 17);
            this.radLong.Margin = new System.Windows.Forms.Padding(4);
            this.radLong.Name = "radLong";
            this.radLong.Size = new System.Drawing.Size(105, 20);
            this.radLong.TabIndex = 2;
            this.radLong.TabStop = true;
            this.radLong.Text = "Long Distance";
            this.radLong.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(201, 61);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(16, 14);
            this.label30.TabIndex = 1;
            this.label30.Text = "U";
            // 
            // cmbStepX
            // 
            this.cmbStepX.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStepX.FormattingEnabled = true;
            this.cmbStepX.Location = new System.Drawing.Point(166, 37);
            this.cmbStepX.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStepX.Name = "cmbStepX";
            this.cmbStepX.Size = new System.Drawing.Size(81, 24);
            this.cmbStepX.TabIndex = 1;
            this.cmbStepX.Text = "10";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(297, 61);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(15, 14);
            this.label29.TabIndex = 1;
            this.label29.Text = "V";
            // 
            // cmbStepU
            // 
            this.cmbStepU.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStepU.FormattingEnabled = true;
            this.cmbStepU.Location = new System.Drawing.Point(166, 81);
            this.cmbStepU.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStepU.Name = "cmbStepU";
            this.cmbStepU.Size = new System.Drawing.Size(81, 24);
            this.cmbStepU.TabIndex = 1;
            this.cmbStepU.Text = "10";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(393, 61);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(18, 14);
            this.label28.TabIndex = 1;
            this.label28.Text = "W";
            // 
            // cmbStepW
            // 
            this.cmbStepW.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStepW.FormattingEnabled = true;
            this.cmbStepW.Location = new System.Drawing.Point(358, 81);
            this.cmbStepW.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStepW.Name = "cmbStepW";
            this.cmbStepW.Size = new System.Drawing.Size(81, 24);
            this.cmbStepW.TabIndex = 1;
            this.cmbStepW.Text = "10";
            // 
            // cmbStepY
            // 
            this.cmbStepY.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStepY.FormattingEnabled = true;
            this.cmbStepY.Location = new System.Drawing.Point(262, 37);
            this.cmbStepY.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStepY.Name = "cmbStepY";
            this.cmbStepY.Size = new System.Drawing.Size(81, 24);
            this.cmbStepY.TabIndex = 1;
            this.cmbStepY.Text = "10";
            // 
            // cmbStepZ
            // 
            this.cmbStepZ.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStepZ.FormattingEnabled = true;
            this.cmbStepZ.Location = new System.Drawing.Point(358, 37);
            this.cmbStepZ.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStepZ.Name = "cmbStepZ";
            this.cmbStepZ.Size = new System.Drawing.Size(81, 24);
            this.cmbStepZ.TabIndex = 1;
            this.cmbStepZ.Text = "10";
            // 
            // cmbStepV
            // 
            this.cmbStepV.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStepV.FormattingEnabled = true;
            this.cmbStepV.Location = new System.Drawing.Point(262, 81);
            this.cmbStepV.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStepV.Name = "cmbStepV";
            this.cmbStepV.Size = new System.Drawing.Size(81, 24);
            this.cmbStepV.TabIndex = 1;
            this.cmbStepV.Text = "10";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(393, 18);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(15, 14);
            this.label27.TabIndex = 1;
            this.label27.Text = "Z";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(201, 18);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(14, 14);
            this.label25.TabIndex = 1;
            this.label25.Text = "X";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(297, 18);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(15, 14);
            this.label26.TabIndex = 1;
            this.label26.Text = "Y";
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.label22);
            this.groupBoxStatus.Controls.Add(this.label23);
            this.groupBoxStatus.Controls.Add(this.label24);
            this.groupBoxStatus.Controls.Add(this.tbOrgW);
            this.groupBoxStatus.Controls.Add(this.tbMelW);
            this.groupBoxStatus.Controls.Add(this.tbOrgZ);
            this.groupBoxStatus.Controls.Add(this.tbMelZ);
            this.groupBoxStatus.Controls.Add(this.tbOrgV);
            this.groupBoxStatus.Controls.Add(this.tbMelV);
            this.groupBoxStatus.Controls.Add(this.tbOrgY);
            this.groupBoxStatus.Controls.Add(this.tbMelY);
            this.groupBoxStatus.Controls.Add(this.label21);
            this.groupBoxStatus.Controls.Add(this.tbPelW);
            this.groupBoxStatus.Controls.Add(this.tbPelZ);
            this.groupBoxStatus.Controls.Add(this.tbOrgU);
            this.groupBoxStatus.Controls.Add(this.tbMelU);
            this.groupBoxStatus.Controls.Add(this.label20);
            this.groupBoxStatus.Controls.Add(this.tbOrgX);
            this.groupBoxStatus.Controls.Add(this.tbMelX);
            this.groupBoxStatus.Controls.Add(this.label19);
            this.groupBoxStatus.Controls.Add(this.tbPelV);
            this.groupBoxStatus.Controls.Add(this.tbPelY);
            this.groupBoxStatus.Controls.Add(this.tbPelU);
            this.groupBoxStatus.Controls.Add(this.tbPelX);
            this.groupBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStatus.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxStatus.Location = new System.Drawing.Point(4, 458);
            this.groupBoxStatus.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxStatus.Size = new System.Drawing.Size(460, 116);
            this.groupBoxStatus.TabIndex = 24;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "State";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(261, 12);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(16, 14);
            this.label22.TabIndex = 1;
            this.label22.Text = "U";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(333, 12);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(15, 14);
            this.label23.TabIndex = 1;
            this.label23.Text = "V";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(405, 12);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(18, 14);
            this.label24.TabIndex = 1;
            this.label24.Text = "W";
            // 
            // tbOrgW
            // 
            this.tbOrgW.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbOrgW.Location = new System.Drawing.Point(378, 58);
            this.tbOrgW.Margin = new System.Windows.Forms.Padding(4);
            this.tbOrgW.Name = "tbOrgW";
            this.tbOrgW.ReadOnly = true;
            this.tbOrgW.Size = new System.Drawing.Size(65, 24);
            this.tbOrgW.TabIndex = 0;
            this.tbOrgW.Text = "ORG";
            this.tbOrgW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMelW
            // 
            this.tbMelW.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMelW.Location = new System.Drawing.Point(378, 87);
            this.tbMelW.Margin = new System.Windows.Forms.Padding(4);
            this.tbMelW.Name = "tbMelW";
            this.tbMelW.ReadOnly = true;
            this.tbMelW.Size = new System.Drawing.Size(65, 24);
            this.tbMelW.TabIndex = 0;
            this.tbMelW.Text = "MEL";
            this.tbMelW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbOrgZ
            // 
            this.tbOrgZ.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbOrgZ.Location = new System.Drawing.Point(162, 58);
            this.tbOrgZ.Margin = new System.Windows.Forms.Padding(4);
            this.tbOrgZ.Name = "tbOrgZ";
            this.tbOrgZ.ReadOnly = true;
            this.tbOrgZ.Size = new System.Drawing.Size(65, 24);
            this.tbOrgZ.TabIndex = 0;
            this.tbOrgZ.Text = "ORG";
            this.tbOrgZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMelZ
            // 
            this.tbMelZ.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMelZ.Location = new System.Drawing.Point(162, 87);
            this.tbMelZ.Margin = new System.Windows.Forms.Padding(4);
            this.tbMelZ.Name = "tbMelZ";
            this.tbMelZ.ReadOnly = true;
            this.tbMelZ.Size = new System.Drawing.Size(65, 24);
            this.tbMelZ.TabIndex = 0;
            this.tbMelZ.Text = "MEL";
            this.tbMelZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbOrgV
            // 
            this.tbOrgV.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbOrgV.Location = new System.Drawing.Point(306, 58);
            this.tbOrgV.Margin = new System.Windows.Forms.Padding(4);
            this.tbOrgV.Name = "tbOrgV";
            this.tbOrgV.ReadOnly = true;
            this.tbOrgV.Size = new System.Drawing.Size(65, 24);
            this.tbOrgV.TabIndex = 0;
            this.tbOrgV.Text = "ORG";
            this.tbOrgV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMelV
            // 
            this.tbMelV.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMelV.Location = new System.Drawing.Point(306, 87);
            this.tbMelV.Margin = new System.Windows.Forms.Padding(4);
            this.tbMelV.Name = "tbMelV";
            this.tbMelV.ReadOnly = true;
            this.tbMelV.Size = new System.Drawing.Size(65, 24);
            this.tbMelV.TabIndex = 0;
            this.tbMelV.Text = "MEL";
            this.tbMelV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbOrgY
            // 
            this.tbOrgY.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbOrgY.Location = new System.Drawing.Point(90, 58);
            this.tbOrgY.Margin = new System.Windows.Forms.Padding(4);
            this.tbOrgY.Name = "tbOrgY";
            this.tbOrgY.ReadOnly = true;
            this.tbOrgY.Size = new System.Drawing.Size(65, 24);
            this.tbOrgY.TabIndex = 0;
            this.tbOrgY.Text = "ORG";
            this.tbOrgY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMelY
            // 
            this.tbMelY.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMelY.Location = new System.Drawing.Point(90, 87);
            this.tbMelY.Margin = new System.Windows.Forms.Padding(4);
            this.tbMelY.Name = "tbMelY";
            this.tbMelY.ReadOnly = true;
            this.tbMelY.Size = new System.Drawing.Size(65, 24);
            this.tbMelY.TabIndex = 0;
            this.tbMelY.Text = "MEL";
            this.tbMelY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(189, 12);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(15, 14);
            this.label21.TabIndex = 1;
            this.label21.Text = "Z";
            // 
            // tbPelW
            // 
            this.tbPelW.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPelW.Location = new System.Drawing.Point(378, 32);
            this.tbPelW.Margin = new System.Windows.Forms.Padding(4);
            this.tbPelW.Name = "tbPelW";
            this.tbPelW.ReadOnly = true;
            this.tbPelW.Size = new System.Drawing.Size(65, 24);
            this.tbPelW.TabIndex = 0;
            this.tbPelW.Text = "PEL";
            this.tbPelW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPelZ
            // 
            this.tbPelZ.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPelZ.Location = new System.Drawing.Point(162, 31);
            this.tbPelZ.Margin = new System.Windows.Forms.Padding(4);
            this.tbPelZ.Name = "tbPelZ";
            this.tbPelZ.ReadOnly = true;
            this.tbPelZ.Size = new System.Drawing.Size(65, 24);
            this.tbPelZ.TabIndex = 0;
            this.tbPelZ.Text = "PEL";
            this.tbPelZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbOrgU
            // 
            this.tbOrgU.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbOrgU.Location = new System.Drawing.Point(234, 58);
            this.tbOrgU.Margin = new System.Windows.Forms.Padding(4);
            this.tbOrgU.Name = "tbOrgU";
            this.tbOrgU.ReadOnly = true;
            this.tbOrgU.Size = new System.Drawing.Size(65, 24);
            this.tbOrgU.TabIndex = 0;
            this.tbOrgU.Text = "ORG";
            this.tbOrgU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMelU
            // 
            this.tbMelU.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMelU.Location = new System.Drawing.Point(234, 87);
            this.tbMelU.Margin = new System.Windows.Forms.Padding(4);
            this.tbMelU.Name = "tbMelU";
            this.tbMelU.ReadOnly = true;
            this.tbMelU.Size = new System.Drawing.Size(65, 24);
            this.tbMelU.TabIndex = 0;
            this.tbMelU.Text = "MEL";
            this.tbMelU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(117, 12);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(15, 14);
            this.label20.TabIndex = 1;
            this.label20.Text = "Y";
            // 
            // tbOrgX
            // 
            this.tbOrgX.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbOrgX.Location = new System.Drawing.Point(17, 58);
            this.tbOrgX.Margin = new System.Windows.Forms.Padding(4);
            this.tbOrgX.Name = "tbOrgX";
            this.tbOrgX.ReadOnly = true;
            this.tbOrgX.Size = new System.Drawing.Size(65, 24);
            this.tbOrgX.TabIndex = 0;
            this.tbOrgX.Text = "ORG";
            this.tbOrgX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMelX
            // 
            this.tbMelX.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMelX.Location = new System.Drawing.Point(17, 87);
            this.tbMelX.Margin = new System.Windows.Forms.Padding(4);
            this.tbMelX.Name = "tbMelX";
            this.tbMelX.ReadOnly = true;
            this.tbMelX.Size = new System.Drawing.Size(65, 24);
            this.tbMelX.TabIndex = 0;
            this.tbMelX.Text = "MEL";
            this.tbMelX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(44, 12);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(14, 14);
            this.label19.TabIndex = 1;
            this.label19.Text = "X";
            // 
            // tbPelV
            // 
            this.tbPelV.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPelV.Location = new System.Drawing.Point(306, 32);
            this.tbPelV.Margin = new System.Windows.Forms.Padding(4);
            this.tbPelV.Name = "tbPelV";
            this.tbPelV.ReadOnly = true;
            this.tbPelV.Size = new System.Drawing.Size(65, 24);
            this.tbPelV.TabIndex = 0;
            this.tbPelV.Text = "PEL";
            this.tbPelV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPelY
            // 
            this.tbPelY.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPelY.Location = new System.Drawing.Point(90, 32);
            this.tbPelY.Margin = new System.Windows.Forms.Padding(4);
            this.tbPelY.Name = "tbPelY";
            this.tbPelY.ReadOnly = true;
            this.tbPelY.Size = new System.Drawing.Size(65, 24);
            this.tbPelY.TabIndex = 0;
            this.tbPelY.Text = "PEL";
            this.tbPelY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPelU
            // 
            this.tbPelU.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPelU.Location = new System.Drawing.Point(234, 31);
            this.tbPelU.Margin = new System.Windows.Forms.Padding(4);
            this.tbPelU.Name = "tbPelU";
            this.tbPelU.ReadOnly = true;
            this.tbPelU.Size = new System.Drawing.Size(65, 24);
            this.tbPelU.TabIndex = 0;
            this.tbPelU.Text = "PEL";
            this.tbPelU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPelX
            // 
            this.tbPelX.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPelX.Location = new System.Drawing.Point(17, 31);
            this.tbPelX.Margin = new System.Windows.Forms.Padding(4);
            this.tbPelX.Name = "tbPelX";
            this.tbPelX.ReadOnly = true;
            this.tbPelX.Size = new System.Drawing.Size(65, 24);
            this.tbPelX.TabIndex = 0;
            this.tbPelX.Text = "PEL";
            this.tbPelX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbPosW);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.tbPosZ);
            this.groupBox4.Controls.Add(this.tbPosX);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.tbPosY);
            this.groupBox4.Controls.Add(this.tbPosU);
            this.groupBox4.Controls.Add(this.tbPosV);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(472, 226);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(316, 108);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Position";
            // 
            // tbPosW
            // 
            this.tbPosW.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPosW.Location = new System.Drawing.Point(211, 78);
            this.tbPosW.Margin = new System.Windows.Forms.Padding(4);
            this.tbPosW.Name = "tbPosW";
            this.tbPosW.ReadOnly = true;
            this.tbPosW.Size = new System.Drawing.Size(80, 21);
            this.tbPosW.TabIndex = 5;
            this.tbPosW.Text = "0.000";
            this.tbPosW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(247, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "W";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(247, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Z";
            // 
            // tbPosZ
            // 
            this.tbPosZ.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPosZ.Location = new System.Drawing.Point(211, 36);
            this.tbPosZ.Margin = new System.Windows.Forms.Padding(4);
            this.tbPosZ.Name = "tbPosZ";
            this.tbPosZ.ReadOnly = true;
            this.tbPosZ.Size = new System.Drawing.Size(80, 21);
            this.tbPosZ.TabIndex = 2;
            this.tbPosZ.Text = "0.000";
            this.tbPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbPosX
            // 
            this.tbPosX.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPosX.Location = new System.Drawing.Point(17, 36);
            this.tbPosX.Margin = new System.Windows.Forms.Padding(4);
            this.tbPosX.Name = "tbPosX";
            this.tbPosX.ReadOnly = true;
            this.tbPosX.Size = new System.Drawing.Size(80, 21);
            this.tbPosX.TabIndex = 0;
            this.tbPosX.Text = "0.000";
            this.tbPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(52, 62);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 14);
            this.label6.TabIndex = 1;
            this.label6.Text = "U";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(150, 62);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 14);
            this.label5.TabIndex = 1;
            this.label5.Text = "V";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(149, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "X";
            // 
            // tbPosY
            // 
            this.tbPosY.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPosY.Location = new System.Drawing.Point(114, 36);
            this.tbPosY.Margin = new System.Windows.Forms.Padding(4);
            this.tbPosY.Name = "tbPosY";
            this.tbPosY.ReadOnly = true;
            this.tbPosY.Size = new System.Drawing.Size(80, 21);
            this.tbPosY.TabIndex = 0;
            this.tbPosY.Text = "0.000";
            this.tbPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbPosU
            // 
            this.tbPosU.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPosU.Location = new System.Drawing.Point(17, 78);
            this.tbPosU.Margin = new System.Windows.Forms.Padding(4);
            this.tbPosU.Name = "tbPosU";
            this.tbPosU.ReadOnly = true;
            this.tbPosU.Size = new System.Drawing.Size(80, 21);
            this.tbPosU.TabIndex = 0;
            this.tbPosU.Text = "0.000";
            this.tbPosU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbPosV
            // 
            this.tbPosV.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPosV.Location = new System.Drawing.Point(114, 78);
            this.tbPosV.Margin = new System.Windows.Forms.Padding(4);
            this.tbPosV.Name = "tbPosV";
            this.tbPosV.ReadOnly = true;
            this.tbPosV.Size = new System.Drawing.Size(80, 21);
            this.tbPosV.TabIndex = 0;
            this.tbPosV.Text = "0.000";
            this.tbPosV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbVelW);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbVelZ);
            this.groupBox1.Controls.Add(this.tbVelX);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.tbVelY);
            this.groupBox1.Controls.Add(this.tbVelU);
            this.groupBox1.Controls.Add(this.tbVelV);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(472, 342);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(316, 108);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Velocity";
            // 
            // tbVelW
            // 
            this.tbVelW.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVelW.Location = new System.Drawing.Point(211, 78);
            this.tbVelW.Margin = new System.Windows.Forms.Padding(4);
            this.tbVelW.Name = "tbVelW";
            this.tbVelW.ReadOnly = true;
            this.tbVelW.Size = new System.Drawing.Size(80, 21);
            this.tbVelW.TabIndex = 5;
            this.tbVelW.Text = "0.000";
            this.tbVelW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(247, 62);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 14);
            this.label7.TabIndex = 4;
            this.label7.Text = "W";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(247, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 14);
            this.label8.TabIndex = 3;
            this.label8.Text = "Z";
            // 
            // tbVelZ
            // 
            this.tbVelZ.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVelZ.Location = new System.Drawing.Point(211, 36);
            this.tbVelZ.Margin = new System.Windows.Forms.Padding(4);
            this.tbVelZ.Name = "tbVelZ";
            this.tbVelZ.ReadOnly = true;
            this.tbVelZ.Size = new System.Drawing.Size(80, 21);
            this.tbVelZ.TabIndex = 2;
            this.tbVelZ.Text = "0.000";
            this.tbVelZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbVelX
            // 
            this.tbVelX.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVelX.Location = new System.Drawing.Point(17, 36);
            this.tbVelX.Margin = new System.Windows.Forms.Padding(4);
            this.tbVelX.Name = "tbVelX";
            this.tbVelX.ReadOnly = true;
            this.tbVelX.Size = new System.Drawing.Size(80, 21);
            this.tbVelX.TabIndex = 0;
            this.tbVelX.Text = "0.000";
            this.tbVelX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(52, 62);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 14);
            this.label9.TabIndex = 1;
            this.label9.Text = "U";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(150, 62);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 14);
            this.label10.TabIndex = 1;
            this.label10.Text = "V";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(149, 20);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 14);
            this.label11.TabIndex = 1;
            this.label11.Text = "Y";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(52, 20);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 14);
            this.label12.TabIndex = 1;
            this.label12.Text = "X";
            // 
            // tbVelY
            // 
            this.tbVelY.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVelY.Location = new System.Drawing.Point(114, 36);
            this.tbVelY.Margin = new System.Windows.Forms.Padding(4);
            this.tbVelY.Name = "tbVelY";
            this.tbVelY.ReadOnly = true;
            this.tbVelY.Size = new System.Drawing.Size(80, 21);
            this.tbVelY.TabIndex = 0;
            this.tbVelY.Text = "0.000";
            this.tbVelY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbVelU
            // 
            this.tbVelU.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVelU.Location = new System.Drawing.Point(17, 78);
            this.tbVelU.Margin = new System.Windows.Forms.Padding(4);
            this.tbVelU.Name = "tbVelU";
            this.tbVelU.ReadOnly = true;
            this.tbVelU.Size = new System.Drawing.Size(80, 21);
            this.tbVelU.TabIndex = 0;
            this.tbVelU.Text = "0.000";
            this.tbVelU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbVelV
            // 
            this.tbVelV.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVelV.Location = new System.Drawing.Point(114, 78);
            this.tbVelV.Margin = new System.Windows.Forms.Padding(4);
            this.tbVelV.Name = "tbVelV";
            this.tbVelV.ReadOnly = true;
            this.tbVelV.Size = new System.Drawing.Size(80, 21);
            this.tbVelV.TabIndex = 0;
            this.tbVelV.Text = "0.000";
            this.tbVelV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabPageInterpolation
            // 
            this.tabPageInterpolation.Location = new System.Drawing.Point(4, 22);
            this.tabPageInterpolation.Name = "tabPageInterpolation";
            this.tabPageInterpolation.Size = new System.Drawing.Size(792, 578);
            this.tabPageInterpolation.TabIndex = 2;
            this.tabPageInterpolation.Text = "Interpolation";
            this.tabPageInterpolation.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnOpenPoints);
            this.panel3.Controls.Add(this.btnConfigApply);
            this.panel3.Controls.Add(this.cBoxLogDisplay);
            this.panel3.Controls.Add(this.cBoxLogEnable);
            this.panel3.Controls.Add(this.cBoxSimulate);
            this.panel3.Controls.Add(this.cBoxEnable);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 685);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 30);
            this.panel3.TabIndex = 14;
            // 
            // btnOpenPoints
            // 
            this.btnOpenPoints.BackColor = System.Drawing.Color.Cyan;
            this.btnOpenPoints.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOpenPoints.Location = new System.Drawing.Point(562, 0);
            this.btnOpenPoints.Name = "btnOpenPoints";
            this.btnOpenPoints.Size = new System.Drawing.Size(118, 28);
            this.btnOpenPoints.TabIndex = 146;
            this.btnOpenPoints.Text = "Points";
            this.btnOpenPoints.UseVisualStyleBackColor = false;
            this.btnOpenPoints.Click += new System.EventHandler(this.BtnOpenPoints_Click);
            // 
            // btnConfigApply
            // 
            this.btnConfigApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnConfigApply.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnConfigApply.Location = new System.Drawing.Point(680, 0);
            this.btnConfigApply.Name = "btnConfigApply";
            this.btnConfigApply.Size = new System.Drawing.Size(118, 28);
            this.btnConfigApply.TabIndex = 145;
            this.btnConfigApply.Text = "Apply";
            this.btnConfigApply.UseVisualStyleBackColor = false;
            this.btnConfigApply.Click += new System.EventHandler(this.btnConfigApply_Click);
            // 
            // cBoxLogDisplay
            // 
            this.cBoxLogDisplay.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBoxLogDisplay.Location = new System.Drawing.Point(297, 0);
            this.cBoxLogDisplay.Name = "cBoxLogDisplay";
            this.cBoxLogDisplay.Size = new System.Drawing.Size(99, 28);
            this.cBoxLogDisplay.TabIndex = 2;
            this.cBoxLogDisplay.Text = "LogDisplay";
            this.cBoxLogDisplay.UseVisualStyleBackColor = true;
            // 
            // cBoxLogEnable
            // 
            this.cBoxLogEnable.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBoxLogEnable.Location = new System.Drawing.Point(198, 0);
            this.cBoxLogEnable.Name = "cBoxLogEnable";
            this.cBoxLogEnable.Size = new System.Drawing.Size(99, 28);
            this.cBoxLogEnable.TabIndex = 1;
            this.cBoxLogEnable.Text = "LogEnable";
            this.cBoxLogEnable.UseVisualStyleBackColor = true;
            // 
            // cBoxSimulate
            // 
            this.cBoxSimulate.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBoxSimulate.Location = new System.Drawing.Point(99, 0);
            this.cBoxSimulate.Name = "cBoxSimulate";
            this.cBoxSimulate.Size = new System.Drawing.Size(99, 28);
            this.cBoxSimulate.TabIndex = 0;
            this.cBoxSimulate.Text = "Simulate";
            this.cBoxSimulate.UseVisualStyleBackColor = true;
            // 
            // cBoxEnable
            // 
            this.cBoxEnable.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBoxEnable.Location = new System.Drawing.Point(0, 0);
            this.cBoxEnable.Name = "cBoxEnable";
            this.cBoxEnable.Size = new System.Drawing.Size(99, 28);
            this.cBoxEnable.TabIndex = 0;
            this.cBoxEnable.Text = "Enable";
            this.cBoxEnable.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.tbAxisesConfigPath);
            this.panel4.Controls.Add(this.btnAxisesSaveAs);
            this.panel4.Controls.Add(this.btnAxisesLoad);
            this.panel4.Controls.Add(this.btnAxisesBrowse);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 660);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(800, 25);
            this.panel4.TabIndex = 13;
            // 
            // tbAxisesConfigPath
            // 
            this.tbAxisesConfigPath.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbAxisesConfigPath.Location = new System.Drawing.Point(0, 0);
            this.tbAxisesConfigPath.Name = "tbAxisesConfigPath";
            this.tbAxisesConfigPath.Size = new System.Drawing.Size(478, 21);
            this.tbAxisesConfigPath.TabIndex = 164;
            // 
            // btnAxisesSaveAs
            // 
            this.btnAxisesSaveAs.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAxisesSaveAs.Location = new System.Drawing.Point(633, 0);
            this.btnAxisesSaveAs.Name = "btnAxisesSaveAs";
            this.btnAxisesSaveAs.Size = new System.Drawing.Size(63, 23);
            this.btnAxisesSaveAs.TabIndex = 161;
            this.btnAxisesSaveAs.Text = "Save As";
            this.btnAxisesSaveAs.UseVisualStyleBackColor = true;
            this.btnAxisesSaveAs.Click += new System.EventHandler(this.BtnAxisesSaveAs_Click);
            // 
            // btnAxisesLoad
            // 
            this.btnAxisesLoad.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAxisesLoad.Location = new System.Drawing.Point(696, 0);
            this.btnAxisesLoad.Name = "btnAxisesLoad";
            this.btnAxisesLoad.Size = new System.Drawing.Size(51, 23);
            this.btnAxisesLoad.TabIndex = 162;
            this.btnAxisesLoad.Text = "Load";
            this.btnAxisesLoad.UseVisualStyleBackColor = true;
            this.btnAxisesLoad.Click += new System.EventHandler(this.BtnAxisesLoad_Click);
            // 
            // btnAxisesBrowse
            // 
            this.btnAxisesBrowse.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAxisesBrowse.Location = new System.Drawing.Point(747, 0);
            this.btnAxisesBrowse.Name = "btnAxisesBrowse";
            this.btnAxisesBrowse.Size = new System.Drawing.Size(51, 23);
            this.btnAxisesBrowse.TabIndex = 163;
            this.btnAxisesBrowse.Text = "...";
            this.btnAxisesBrowse.UseVisualStyleBackColor = true;
            this.btnAxisesBrowse.Click += new System.EventHandler(this.BtnAxisesBrowse_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cBoxAxisNum);
            this.panel2.Controls.Add(this.lbFeedBackType);
            this.panel2.Controls.Add(this.cBoxVelMode);
            this.panel2.Controls.Add(this.lbVelMode);
            this.panel2.Controls.Add(this.cBoxDevName);
            this.panel2.Controls.Add(this.lbDevName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 28);
            this.panel2.TabIndex = 10;
            // 
            // cBoxAxisNum
            // 
            this.cBoxAxisNum.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBoxAxisNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxAxisNum.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cBoxAxisNum.FormattingEnabled = true;
            this.cBoxAxisNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cBoxAxisNum.Location = new System.Drawing.Point(521, 0);
            this.cBoxAxisNum.Name = "cBoxAxisNum";
            this.cBoxAxisNum.Size = new System.Drawing.Size(100, 27);
            this.cBoxAxisNum.TabIndex = 8;
            this.cBoxAxisNum.SelectedIndexChanged += new System.EventHandler(this.cBoxAxisNum_SelectedIndexChanged);
            // 
            // lbFeedBackType
            // 
            this.lbFeedBackType.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbFeedBackType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbFeedBackType.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbFeedBackType.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lbFeedBackType.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbFeedBackType.Location = new System.Drawing.Point(422, 0);
            this.lbFeedBackType.Name = "lbFeedBackType";
            this.lbFeedBackType.Size = new System.Drawing.Size(99, 26);
            this.lbFeedBackType.TabIndex = 7;
            this.lbFeedBackType.Text = "AxisNum";
            this.lbFeedBackType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cBoxVelMode
            // 
            this.cBoxVelMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBoxVelMode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cBoxVelMode.FormattingEnabled = true;
            this.cBoxVelMode.Items.AddRange(new object[] {
            "Velocity",
            "Time"});
            this.cBoxVelMode.Location = new System.Drawing.Point(297, 0);
            this.cBoxVelMode.Name = "cBoxVelMode";
            this.cBoxVelMode.Size = new System.Drawing.Size(125, 27);
            this.cBoxVelMode.TabIndex = 6;
            // 
            // lbVelMode
            // 
            this.lbVelMode.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbVelMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbVelMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbVelMode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lbVelMode.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbVelMode.Location = new System.Drawing.Point(198, 0);
            this.lbVelMode.Name = "lbVelMode";
            this.lbVelMode.Size = new System.Drawing.Size(99, 26);
            this.lbVelMode.TabIndex = 5;
            this.lbVelMode.Text = "VelMode";
            this.lbVelMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cBoxDevName
            // 
            this.cBoxDevName.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBoxDevName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cBoxDevName.FormattingEnabled = true;
            this.cBoxDevName.Location = new System.Drawing.Point(73, 0);
            this.cBoxDevName.Name = "cBoxDevName";
            this.cBoxDevName.Size = new System.Drawing.Size(125, 27);
            this.cBoxDevName.TabIndex = 4;
            this.cBoxDevName.SelectedIndexChanged += new System.EventHandler(this.CBoxDevName_SelectedIndexChanged);
            // 
            // lbDevName
            // 
            this.lbDevName.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbDevName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDevName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbDevName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDevName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbDevName.Location = new System.Drawing.Point(0, 0);
            this.lbDevName.Name = "lbDevName";
            this.lbDevName.Size = new System.Drawing.Size(73, 26);
            this.lbDevName.TabIndex = 3;
            this.lbDevName.Text = "DevName";
            this.lbDevName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbDevName.Click += new System.EventHandler(this.lbDevName_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbState);
            this.panel1.Controls.Add(this.lbState);
            this.panel1.Controls.Add(this.tbType);
            this.panel1.Controls.Add(this.lbType);
            this.panel1.Controls.Add(this.tbInfo);
            this.panel1.Controls.Add(this.lbInfo);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 28);
            this.panel1.TabIndex = 9;
            // 
            // tbState
            // 
            this.tbState.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbState.Location = new System.Drawing.Point(697, 0);
            this.tbState.Multiline = true;
            this.tbState.Name = "tbState";
            this.tbState.Size = new System.Drawing.Size(100, 28);
            this.tbState.TabIndex = 7;
            this.tbState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbState
            // 
            this.lbState.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbState.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbState.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbState.Location = new System.Drawing.Point(622, 0);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(75, 28);
            this.lbState.TabIndex = 6;
            this.lbState.Text = "State";
            this.lbState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbType
            // 
            this.tbType.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbType.Location = new System.Drawing.Point(522, 0);
            this.tbType.Multiline = true;
            this.tbType.Name = "tbType";
            this.tbType.ReadOnly = true;
            this.tbType.Size = new System.Drawing.Size(100, 28);
            this.tbType.TabIndex = 5;
            this.tbType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbType
            // 
            this.lbType.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbType.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbType.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbType.Location = new System.Drawing.Point(423, 0);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(99, 28);
            this.lbType.TabIndex = 4;
            this.lbType.Text = "Type";
            this.lbType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbInfo
            // 
            this.tbInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbInfo.Location = new System.Drawing.Point(298, 0);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(125, 28);
            this.tbInfo.TabIndex = 3;
            this.tbInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbInfo
            // 
            this.lbInfo.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbInfo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbInfo.Location = new System.Drawing.Point(199, 0);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(99, 28);
            this.lbInfo.TabIndex = 2;
            this.lbInfo.Text = "Info";
            this.lbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbName
            // 
            this.tbName.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbName.Location = new System.Drawing.Point(74, 0);
            this.tbName.Multiline = true;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(125, 28);
            this.tbName.TabIndex = 1;
            // 
            // lbName
            // 
            this.lbName.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbName.Location = new System.Drawing.Point(0, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(74, 28);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "\"json File|*.json|All File|\".\"\"";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "\"json File|*.json|All File|\".\"\"";
            // 
            // ConfigUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ConfigUI";
            this.Size = new System.Drawing.Size(800, 715);
            this.Load += new System.EventHandler(this.ConfigUI_Load);
            this.Click += new System.EventHandler(this.ConfigUI_Click);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabCartesianConfig.ResumeLayout(false);
            this.tabPageAxisConfig.ResumeLayout(false);
            this.tabPageAxisStatus.ResumeLayout(false);
            this.tabPageManual.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPoints)).EndInit();
            this.mnuPoints.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBoxStatus.ResumeLayout(false);
            this.groupBoxStatus.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private TextBox tbState;
        private Label lbState;
        private TextBox tbType;
        private Label lbType;
        private TextBox tbInfo;
        private Label lbInfo;
        private TextBox tbName;
        private Label lbName;
        private Panel panel2;
        private ComboBox cBoxAxisNum;
        private Label lbFeedBackType;
        private ComboBox cBoxVelMode;
        private Label lbVelMode;
        private ComboBox cBoxDevName;
        private Label lbDevName;
        private Panel panel4;
        private TextBox tbAxisesConfigPath;
        private Button btnAxisesSaveAs;
        private Button btnAxisesLoad;
        private Button btnAxisesBrowse;
        private Panel panel3;
        private Button btnOpenPoints;
        private Button btnConfigApply;
        private CheckBox cBoxLogDisplay;
        private CheckBox cBoxLogEnable;
        private CheckBox cBoxSimulate;
        private CheckBox cBoxEnable;
        private TabControl tabCartesianConfig;
        private TabPage tabPageAxisConfig;
        private FlowLayoutPanel flowPanelConfig;
        private TabPage tabPageAxisStatus;
        private FlowLayoutPanel flowPanelStatus;
        private TabPage tabPageInterpolation;
        private TabPage tabPageManual;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox groupBox3;
        private TabControl tabControl2;
        private TabPage tabPage3;
        private Button btnMinusZ;
        private Button btnMinusX;
        private Button btnPlusY;
        private Button btnMinusW;
        private Button btnMinusV;
        private Button btnMinusU;
        private Button btnMinusY;
        private Button btnPlusZ;
        private Button btnAllStop;
        private Button btnPlusX;
        private Button btnPlusW;
        private Button btnPlusV;
        private Button btnPlusU;
        private TabPage tabPage4;
        private Button btnHomeStop;
        private Button btnHomeAll;
        private Button buttonAxisServoOff;
        private Button btnServoOnAll;
        private ComboBox cmbHomeOrderW;
        private ComboBox cmbHomeOrderV;
        private ComboBox cmbHomeOrderZ;
        private ComboBox cmbHomeOrderY;
        private ComboBox cmbHomeOrderX;
        private Button btnServoW;
        private Button btnHomeW;
        private Button btnServoV;
        private Button btnHomeV;
        private Button btnServoU;
        private Button btnHomeU;
        private Button btnServoZ;
        private Button btnHomeZ;
        private Button btnServoY;
        private Button btnHomeY;
        private Button btnServoX;
        private Button btnHomeX;
        private ComboBox cmbHomeOrderU;
        private GroupBox groupBox5;
        private GroupBox groupBox7;
        private RadioButton radMedium;
        private RadioButton radShort;
        private RadioButton radLong;
        private Label label30;
        private ComboBox cmbStepX;
        private Label label29;
        private ComboBox cmbStepU;
        private Label label28;
        private ComboBox cmbStepW;
        private ComboBox cmbStepY;
        private ComboBox cmbStepZ;
        private ComboBox cmbStepV;
        private Label label27;
        private Label label25;
        private Label label26;
        private GroupBox groupBoxStatus;
        private Label label22;
        private Label label23;
        private Label label24;
        private TextBox tbOrgW;
        private TextBox tbMelW;
        private TextBox tbOrgZ;
        private TextBox tbMelZ;
        private TextBox tbOrgV;
        private TextBox tbMelV;
        private TextBox tbOrgY;
        private TextBox tbMelY;
        private Label label21;
        private TextBox tbPelW;
        private TextBox tbPelZ;
        private TextBox tbOrgU;
        private TextBox tbMelU;
        private Label label20;
        private TextBox tbOrgX;
        private TextBox tbMelX;
        private Label label19;
        private TextBox tbPelV;
        private TextBox tbPelY;
        private TextBox tbPelU;
        private TextBox tbPelX;
        private GroupBox groupBox4;
        private TextBox tbPosW;
        private Label label4;
        private Label label3;
        private TextBox tbPosZ;
        private TextBox tbPosX;
        private Label label6;
        private Label label5;
        private Label label2;
        private Label label1;
        private TextBox tbPosY;
        private TextBox tbPosU;
        private TextBox tbPosV;
        private GroupBox groupBox1;
        private TextBox tbVelW;
        private Label label7;
        private Label label8;
        private TextBox tbVelZ;
        private TextBox tbVelX;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox tbVelY;
        private TextBox tbVelU;
        private TextBox tbVelV;
        private DataGridView dgPoints;
        private DataGridViewTextBoxColumn PName;
        private DataGridViewTextBoxColumn X;
        private GroupBox groupBox2;
        private ComboBox cmbPointTeach;
        private ComboBox cmbPointMove;
        private Button btnPosDelete;
        private Button btnPosTeach;
        private Button btnPosJump;
        private Button btnPosMoveP;
        private ComboBox cmbJumpHeightZ;
        private Label label31;
        private Timer tmrRefresh;
        private Button btnServoOffAll;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private ContextMenuStrip mnuPoints;
        private ToolStripMenuItem tsmSave;
        private ToolStripMenuItem tsmReLoad;
        private ToolStripMenuItem tsmUpdate;
        private ToolStripMenuItem tsmToPoint;
    }
}
