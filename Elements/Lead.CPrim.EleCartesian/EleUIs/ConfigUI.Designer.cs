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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tabCartesianConfig = new System.Windows.Forms.TabControl();
            this.tabPageAxisStatus = new System.Windows.Forms.TabPage();
            this.flowPanelStatus = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageAxisConfig = new System.Windows.Forms.TabPage();
            this.flowPanelConfig = new System.Windows.Forms.FlowLayoutPanel();
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnOpenPoints = new System.Windows.Forms.Button();
            this.btnConfigApply = new System.Windows.Forms.Button();
            this.cBoxLogDisplay = new System.Windows.Forms.CheckBox();
            this.cBoxLogEnable = new System.Windows.Forms.CheckBox();
            this.cBoxSimulate = new System.Windows.Forms.CheckBox();
            this.cBoxEnable = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbAxisesConfigPath = new System.Windows.Forms.TextBox();
            this.btnAxisesSave = new System.Windows.Forms.Button();
            this.btnAxisesLoad = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tlpRow2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddAxis = new System.Windows.Forms.Button();
            this.btnRemoveAxis = new System.Windows.Forms.Button();
            this.tbAxisNum = new System.Windows.Forms.TextBox();
            this.lbFeedBackType = new System.Windows.Forms.Label();
            this.cBoxVelMode = new System.Windows.Forms.ComboBox();
            this.lbVelMode = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tlpRow1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbState = new System.Windows.Forms.TextBox();
            this.lbState = new System.Windows.Forms.Label();
            this.tbType = new System.Windows.Forms.TextBox();
            this.lbType = new System.Windows.Forms.Label();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.tabCartesianConfig.SuspendLayout();
            this.tabPageAxisStatus.SuspendLayout();
            this.tabPageAxisConfig.SuspendLayout();
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
            this.groupBoxStatus.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tlpRow2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tlpRow1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.AutoScroll = true;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tabCartesianConfig, 0, 2);
            this.tlpMain.Controls.Add(this.panel3, 0, 4);
            this.tlpMain.Controls.Add(this.panel4, 0, 3);
            this.tlpMain.Controls.Add(this.panel2, 0, 1);
            this.tlpMain.Controls.Add(this.panel1, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(1);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.5F));
            this.tlpMain.Size = new System.Drawing.Size(1700, 732);
            this.tlpMain.TabIndex = 0;
            // 
            // tabCartesianConfig
            // 
            this.tabCartesianConfig.Controls.Add(this.tabPageAxisStatus);
            this.tabCartesianConfig.Controls.Add(this.tabPageAxisConfig);
            this.tabCartesianConfig.Controls.Add(this.tabPageManual);
            this.tabCartesianConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCartesianConfig.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabCartesianConfig.Location = new System.Drawing.Point(0, 64);
            this.tabCartesianConfig.Margin = new System.Windows.Forms.Padding(0);
            this.tabCartesianConfig.Name = "tabCartesianConfig";
            this.tabCartesianConfig.SelectedIndex = 0;
            this.tabCartesianConfig.Size = new System.Drawing.Size(1700, 600);
            this.tabCartesianConfig.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabCartesianConfig.TabIndex = 15;
            // 
            // tabPageAxisStatus
            // 
            this.tabPageAxisStatus.Controls.Add(this.flowPanelStatus);
            this.tabPageAxisStatus.Location = new System.Drawing.Point(4, 36);
            this.tabPageAxisStatus.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageAxisStatus.Name = "tabPageAxisStatus";
            this.tabPageAxisStatus.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageAxisStatus.Size = new System.Drawing.Size(1692, 560);
            this.tabPageAxisStatus.TabIndex = 1;
            this.tabPageAxisStatus.Text = "状态";
            this.tabPageAxisStatus.UseVisualStyleBackColor = true;
            // 
            // flowPanelStatus
            // 
            this.flowPanelStatus.AutoScroll = true;
            this.flowPanelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowPanelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelStatus.Location = new System.Drawing.Point(4, 4);
            this.flowPanelStatus.Margin = new System.Windows.Forms.Padding(4);
            this.flowPanelStatus.Name = "flowPanelStatus";
            this.flowPanelStatus.Size = new System.Drawing.Size(1684, 552);
            this.flowPanelStatus.TabIndex = 1;
            // 
            // tabPageAxisConfig
            // 
            this.tabPageAxisConfig.Controls.Add(this.flowPanelConfig);
            this.tabPageAxisConfig.Location = new System.Drawing.Point(4, 36);
            this.tabPageAxisConfig.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageAxisConfig.Name = "tabPageAxisConfig";
            this.tabPageAxisConfig.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageAxisConfig.Size = new System.Drawing.Size(1692, 560);
            this.tabPageAxisConfig.TabIndex = 0;
            this.tabPageAxisConfig.Text = "配置";
            this.tabPageAxisConfig.UseVisualStyleBackColor = true;
            // 
            // flowPanelConfig
            // 
            this.flowPanelConfig.AutoScroll = true;
            this.flowPanelConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowPanelConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelConfig.Location = new System.Drawing.Point(4, 4);
            this.flowPanelConfig.Margin = new System.Windows.Forms.Padding(4);
            this.flowPanelConfig.Name = "flowPanelConfig";
            this.flowPanelConfig.Size = new System.Drawing.Size(1684, 552);
            this.flowPanelConfig.TabIndex = 0;
            // 
            // tabPageManual
            // 
            this.tabPageManual.Controls.Add(this.tableLayoutPanel2);
            this.tabPageManual.Location = new System.Drawing.Point(4, 36);
            this.tabPageManual.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageManual.Name = "tabPageManual";
            this.tabPageManual.Size = new System.Drawing.Size(1692, 560);
            this.tabPageManual.TabIndex = 3;
            this.tabPageManual.Text = "手动调试";
            this.tabPageManual.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.dgPoints, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxStatus, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1692, 560);
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
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(851, 425);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(836, 130);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "测试";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label31.Location = new System.Drawing.Point(759, 66);
            this.label31.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(18, 18);
            this.label31.TabIndex = 8;
            this.label31.Text = "Z";
            // 
            // cmbJumpHeightZ
            // 
            this.cmbJumpHeightZ.FormattingEnabled = true;
            this.cmbJumpHeightZ.Location = new System.Drawing.Point(718, 90);
            this.cmbJumpHeightZ.Margin = new System.Windows.Forms.Padding(5);
            this.cmbJumpHeightZ.Name = "cmbJumpHeightZ";
            this.cmbJumpHeightZ.Size = new System.Drawing.Size(99, 26);
            this.cmbJumpHeightZ.TabIndex = 7;
            // 
            // btnPosJump
            // 
            this.btnPosJump.Location = new System.Drawing.Point(574, 86);
            this.btnPosJump.Margin = new System.Windows.Forms.Padding(5);
            this.btnPosJump.Name = "btnPosJump";
            this.btnPosJump.Size = new System.Drawing.Size(105, 36);
            this.btnPosJump.TabIndex = 5;
            this.btnPosJump.Text = "Jump";
            this.btnPosJump.UseVisualStyleBackColor = true;
            this.btnPosJump.Click += new System.EventHandler(this.BtnPosJump_Click);
            // 
            // btnPosMoveP
            // 
            this.btnPosMoveP.Location = new System.Drawing.Point(435, 86);
            this.btnPosMoveP.Margin = new System.Windows.Forms.Padding(5);
            this.btnPosMoveP.Name = "btnPosMoveP";
            this.btnPosMoveP.Size = new System.Drawing.Size(105, 36);
            this.btnPosMoveP.TabIndex = 6;
            this.btnPosMoveP.Text = "MoveP";
            this.btnPosMoveP.UseVisualStyleBackColor = true;
            this.btnPosMoveP.Click += new System.EventHandler(this.BtnPosMoveP_Click);
            // 
            // btnPosDelete
            // 
            this.btnPosDelete.Location = new System.Drawing.Point(574, 34);
            this.btnPosDelete.Margin = new System.Windows.Forms.Padding(5);
            this.btnPosDelete.Name = "btnPosDelete";
            this.btnPosDelete.Size = new System.Drawing.Size(105, 36);
            this.btnPosDelete.TabIndex = 3;
            this.btnPosDelete.Text = "删除";
            this.btnPosDelete.UseVisualStyleBackColor = true;
            this.btnPosDelete.Click += new System.EventHandler(this.BtnPosDelete_Click);
            // 
            // btnPosTeach
            // 
            this.btnPosTeach.Location = new System.Drawing.Point(435, 34);
            this.btnPosTeach.Margin = new System.Windows.Forms.Padding(5);
            this.btnPosTeach.Name = "btnPosTeach";
            this.btnPosTeach.Size = new System.Drawing.Size(105, 36);
            this.btnPosTeach.TabIndex = 4;
            this.btnPosTeach.Text = "示教";
            this.btnPosTeach.UseVisualStyleBackColor = true;
            this.btnPosTeach.Click += new System.EventHandler(this.BtnPosTeach_Click);
            // 
            // cmbPointMove
            // 
            this.cmbPointMove.FormattingEnabled = true;
            this.cmbPointMove.Location = new System.Drawing.Point(16, 90);
            this.cmbPointMove.Margin = new System.Windows.Forms.Padding(5);
            this.cmbPointMove.Name = "cmbPointMove";
            this.cmbPointMove.Size = new System.Drawing.Size(379, 26);
            this.cmbPointMove.TabIndex = 2;
            // 
            // cmbPointTeach
            // 
            this.cmbPointTeach.FormattingEnabled = true;
            this.cmbPointTeach.Location = new System.Drawing.Point(16, 38);
            this.cmbPointTeach.Margin = new System.Windows.Forms.Padding(5);
            this.cmbPointTeach.Name = "cmbPointTeach";
            this.cmbPointTeach.Size = new System.Drawing.Size(379, 26);
            this.cmbPointTeach.TabIndex = 1;
            // 
            // dgPoints
            // 
            this.dgPoints.AllowUserToAddRows = false;
            this.dgPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PName,
            this.X});
            this.dgPoints.ContextMenuStrip = this.mnuPoints;
            this.dgPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPoints.Location = new System.Drawing.Point(850, 4);
            this.dgPoints.Margin = new System.Windows.Forms.Padding(4);
            this.dgPoints.Name = "dgPoints";
            this.dgPoints.RowHeadersWidth = 51;
            this.dgPoints.RowTemplate.Height = 27;
            this.dgPoints.Size = new System.Drawing.Size(838, 244);
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
            this.mnuPoints.Size = new System.Drawing.Size(139, 100);
            this.mnuPoints.Text = "Points";
            // 
            // tsmSave
            // 
            this.tsmSave.Name = "tsmSave";
            this.tsmSave.Size = new System.Drawing.Size(138, 24);
            this.tsmSave.Text = "保存";
            this.tsmSave.Click += new System.EventHandler(this.TsmSave_Click);
            // 
            // tsmReLoad
            // 
            this.tsmReLoad.Name = "tsmReLoad";
            this.tsmReLoad.Size = new System.Drawing.Size(138, 24);
            this.tsmReLoad.Text = "重新载入";
            this.tsmReLoad.Click += new System.EventHandler(this.TsmReLoad_Click);
            // 
            // tsmUpdate
            // 
            this.tsmUpdate.Name = "tsmUpdate";
            this.tsmUpdate.Size = new System.Drawing.Size(138, 24);
            this.tsmUpdate.Text = "更新";
            this.tsmUpdate.Click += new System.EventHandler(this.TsmUpdate_Click);
            // 
            // tsmToPoint
            // 
            this.tsmToPoint.Name = "tsmToPoint";
            this.tsmToPoint.Size = new System.Drawing.Size(138, 24);
            this.tsmToPoint.Text = "移动至";
            this.tsmToPoint.Click += new System.EventHandler(this.TsmToPoint_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tabControl2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox3.Location = new System.Drawing.Point(4, 4);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.SetRowSpan(this.groupBox3, 2);
            this.groupBox3.Size = new System.Drawing.Size(838, 328);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "调试";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.ItemSize = new System.Drawing.Size(80, 25);
            this.tabControl2.Location = new System.Drawing.Point(4, 21);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(830, 303);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl2.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
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
            this.tabPage3.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(822, 270);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "移动";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnMinusZ
            // 
            this.btnMinusZ.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMinusZ.Location = new System.Drawing.Point(674, 94);
            this.btnMinusZ.Margin = new System.Windows.Forms.Padding(5);
            this.btnMinusZ.Name = "btnMinusZ";
            this.btnMinusZ.Size = new System.Drawing.Size(125, 44);
            this.btnMinusZ.TabIndex = 0;
            this.btnMinusZ.Text = "Z-";
            this.btnMinusZ.UseVisualStyleBackColor = true;
            // 
            // btnMinusX
            // 
            this.btnMinusX.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMinusX.Location = new System.Drawing.Point(18, 56);
            this.btnMinusX.Margin = new System.Windows.Forms.Padding(5);
            this.btnMinusX.Name = "btnMinusX";
            this.btnMinusX.Size = new System.Drawing.Size(125, 44);
            this.btnMinusX.TabIndex = 0;
            this.btnMinusX.Text = "X-";
            this.btnMinusX.UseVisualStyleBackColor = true;
            // 
            // btnPlusY
            // 
            this.btnPlusY.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPlusY.Location = new System.Drawing.Point(236, 16);
            this.btnPlusY.Margin = new System.Windows.Forms.Padding(5);
            this.btnPlusY.Name = "btnPlusY";
            this.btnPlusY.Size = new System.Drawing.Size(125, 44);
            this.btnPlusY.TabIndex = 0;
            this.btnPlusY.Text = "Y+";
            this.btnPlusY.UseVisualStyleBackColor = true;
            // 
            // btnMinusW
            // 
            this.btnMinusW.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMinusW.Location = new System.Drawing.Point(455, 205);
            this.btnMinusW.Margin = new System.Windows.Forms.Padding(5);
            this.btnMinusW.Name = "btnMinusW";
            this.btnMinusW.Size = new System.Drawing.Size(125, 44);
            this.btnMinusW.TabIndex = 0;
            this.btnMinusW.Text = "W-";
            this.btnMinusW.UseVisualStyleBackColor = true;
            // 
            // btnMinusV
            // 
            this.btnMinusV.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMinusV.Location = new System.Drawing.Point(236, 205);
            this.btnMinusV.Margin = new System.Windows.Forms.Padding(5);
            this.btnMinusV.Name = "btnMinusV";
            this.btnMinusV.Size = new System.Drawing.Size(125, 44);
            this.btnMinusV.TabIndex = 0;
            this.btnMinusV.Text = "V-";
            this.btnMinusV.UseVisualStyleBackColor = true;
            // 
            // btnMinusU
            // 
            this.btnMinusU.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMinusU.Location = new System.Drawing.Point(18, 205);
            this.btnMinusU.Margin = new System.Windows.Forms.Padding(5);
            this.btnMinusU.Name = "btnMinusU";
            this.btnMinusU.Size = new System.Drawing.Size(125, 44);
            this.btnMinusU.TabIndex = 0;
            this.btnMinusU.Text = "U-";
            this.btnMinusU.UseVisualStyleBackColor = true;
            // 
            // btnMinusY
            // 
            this.btnMinusY.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMinusY.Location = new System.Drawing.Point(236, 94);
            this.btnMinusY.Margin = new System.Windows.Forms.Padding(5);
            this.btnMinusY.Name = "btnMinusY";
            this.btnMinusY.Size = new System.Drawing.Size(125, 44);
            this.btnMinusY.TabIndex = 0;
            this.btnMinusY.Text = "Y-";
            this.btnMinusY.UseVisualStyleBackColor = true;
            // 
            // btnPlusZ
            // 
            this.btnPlusZ.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPlusZ.Location = new System.Drawing.Point(674, 16);
            this.btnPlusZ.Margin = new System.Windows.Forms.Padding(5);
            this.btnPlusZ.Name = "btnPlusZ";
            this.btnPlusZ.Size = new System.Drawing.Size(125, 44);
            this.btnPlusZ.TabIndex = 0;
            this.btnPlusZ.Text = "Z+";
            this.btnPlusZ.UseVisualStyleBackColor = true;
            // 
            // btnAllStop
            // 
            this.btnAllStop.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAllStop.ForeColor = System.Drawing.Color.Red;
            this.btnAllStop.Location = new System.Drawing.Point(674, 151);
            this.btnAllStop.Margin = new System.Windows.Forms.Padding(5);
            this.btnAllStop.Name = "btnAllStop";
            this.btnAllStop.Size = new System.Drawing.Size(125, 98);
            this.btnAllStop.TabIndex = 0;
            this.btnAllStop.Text = "停止";
            this.btnAllStop.UseVisualStyleBackColor = true;
            this.btnAllStop.Click += new System.EventHandler(this.BtnAllStop_Click);
            // 
            // btnPlusX
            // 
            this.btnPlusX.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPlusX.Location = new System.Drawing.Point(455, 56);
            this.btnPlusX.Margin = new System.Windows.Forms.Padding(5);
            this.btnPlusX.Name = "btnPlusX";
            this.btnPlusX.Size = new System.Drawing.Size(125, 44);
            this.btnPlusX.TabIndex = 0;
            this.btnPlusX.Text = "X+";
            this.btnPlusX.UseVisualStyleBackColor = true;
            // 
            // btnPlusW
            // 
            this.btnPlusW.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPlusW.Location = new System.Drawing.Point(455, 151);
            this.btnPlusW.Margin = new System.Windows.Forms.Padding(5);
            this.btnPlusW.Name = "btnPlusW";
            this.btnPlusW.Size = new System.Drawing.Size(125, 44);
            this.btnPlusW.TabIndex = 0;
            this.btnPlusW.Text = "W+";
            this.btnPlusW.UseVisualStyleBackColor = true;
            // 
            // btnPlusV
            // 
            this.btnPlusV.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPlusV.Location = new System.Drawing.Point(236, 151);
            this.btnPlusV.Margin = new System.Windows.Forms.Padding(5);
            this.btnPlusV.Name = "btnPlusV";
            this.btnPlusV.Size = new System.Drawing.Size(125, 44);
            this.btnPlusV.TabIndex = 0;
            this.btnPlusV.Text = "V+";
            this.btnPlusV.UseVisualStyleBackColor = true;
            // 
            // btnPlusU
            // 
            this.btnPlusU.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPlusU.Location = new System.Drawing.Point(18, 151);
            this.btnPlusU.Margin = new System.Windows.Forms.Padding(5);
            this.btnPlusU.Name = "btnPlusU";
            this.btnPlusU.Size = new System.Drawing.Size(125, 44);
            this.btnPlusU.TabIndex = 0;
            this.btnPlusU.Text = "U+";
            this.btnPlusU.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.AutoScroll = true;
            this.tabPage4.Controls.Add(this.btnServoOffAll);
            this.tabPage4.Controls.Add(this.btnHomeStop);
            this.tabPage4.Controls.Add(this.btnHomeAll);
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
            this.tabPage4.Margin = new System.Windows.Forms.Padding(5);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(822, 270);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "回零";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnServoOffAll
            // 
            this.btnServoOffAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnServoOffAll.Location = new System.Drawing.Point(226, 280);
            this.btnServoOffAll.Margin = new System.Windows.Forms.Padding(5);
            this.btnServoOffAll.Name = "btnServoOffAll";
            this.btnServoOffAll.Size = new System.Drawing.Size(146, 56);
            this.btnServoOffAll.TabIndex = 4;
            this.btnServoOffAll.Text = "所有轴下使能";
            this.btnServoOffAll.UseVisualStyleBackColor = true;
            this.btnServoOffAll.Click += new System.EventHandler(this.BtnServoOffAll_Click);
            // 
            // btnHomeStop
            // 
            this.btnHomeStop.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomeStop.ForeColor = System.Drawing.Color.Red;
            this.btnHomeStop.Location = new System.Drawing.Point(668, 5);
            this.btnHomeStop.Margin = new System.Windows.Forms.Padding(5);
            this.btnHomeStop.Name = "btnHomeStop";
            this.btnHomeStop.Size = new System.Drawing.Size(110, 331);
            this.btnHomeStop.TabIndex = 3;
            this.btnHomeStop.Text = "停止";
            this.btnHomeStop.UseVisualStyleBackColor = true;
            this.btnHomeStop.Click += new System.EventHandler(this.BtnAllStop_Click);
            // 
            // btnHomeAll
            // 
            this.btnHomeAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHomeAll.Location = new System.Drawing.Point(458, 272);
            this.btnHomeAll.Margin = new System.Windows.Forms.Padding(5);
            this.btnHomeAll.Name = "btnHomeAll";
            this.btnHomeAll.Size = new System.Drawing.Size(125, 64);
            this.btnHomeAll.TabIndex = 2;
            this.btnHomeAll.Text = "轴组回零";
            this.btnHomeAll.UseVisualStyleBackColor = true;
            this.btnHomeAll.Click += new System.EventHandler(this.BtnHomeAll_Click);
            // 
            // btnServoOnAll
            // 
            this.btnServoOnAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnServoOnAll.Location = new System.Drawing.Point(16, 280);
            this.btnServoOnAll.Margin = new System.Windows.Forms.Padding(5);
            this.btnServoOnAll.Name = "btnServoOnAll";
            this.btnServoOnAll.Size = new System.Drawing.Size(125, 56);
            this.btnServoOnAll.TabIndex = 2;
            this.btnServoOnAll.Text = "所有轴上使能";
            this.btnServoOnAll.UseVisualStyleBackColor = true;
            this.btnServoOnAll.Click += new System.EventHandler(this.BtnServoOnAll_Click);
            // 
            // cmbHomeOrderW
            // 
            this.cmbHomeOrderW.FormattingEnabled = true;
            this.cmbHomeOrderW.Location = new System.Drawing.Point(226, 236);
            this.cmbHomeOrderW.Margin = new System.Windows.Forms.Padding(5);
            this.cmbHomeOrderW.Name = "cmbHomeOrderW";
            this.cmbHomeOrderW.Size = new System.Drawing.Size(145, 26);
            this.cmbHomeOrderW.TabIndex = 0;
            // 
            // cmbHomeOrderV
            // 
            this.cmbHomeOrderV.FormattingEnabled = true;
            this.cmbHomeOrderV.Location = new System.Drawing.Point(226, 191);
            this.cmbHomeOrderV.Margin = new System.Windows.Forms.Padding(5);
            this.cmbHomeOrderV.Name = "cmbHomeOrderV";
            this.cmbHomeOrderV.Size = new System.Drawing.Size(145, 26);
            this.cmbHomeOrderV.TabIndex = 0;
            // 
            // cmbHomeOrderZ
            // 
            this.cmbHomeOrderZ.FormattingEnabled = true;
            this.cmbHomeOrderZ.Location = new System.Drawing.Point(226, 100);
            this.cmbHomeOrderZ.Margin = new System.Windows.Forms.Padding(5);
            this.cmbHomeOrderZ.Name = "cmbHomeOrderZ";
            this.cmbHomeOrderZ.Size = new System.Drawing.Size(145, 26);
            this.cmbHomeOrderZ.TabIndex = 0;
            // 
            // cmbHomeOrderY
            // 
            this.cmbHomeOrderY.FormattingEnabled = true;
            this.cmbHomeOrderY.Location = new System.Drawing.Point(226, 55);
            this.cmbHomeOrderY.Margin = new System.Windows.Forms.Padding(5);
            this.cmbHomeOrderY.Name = "cmbHomeOrderY";
            this.cmbHomeOrderY.Size = new System.Drawing.Size(145, 26);
            this.cmbHomeOrderY.TabIndex = 0;
            // 
            // cmbHomeOrderX
            // 
            this.cmbHomeOrderX.FormattingEnabled = true;
            this.cmbHomeOrderX.Location = new System.Drawing.Point(226, 9);
            this.cmbHomeOrderX.Margin = new System.Windows.Forms.Padding(5);
            this.cmbHomeOrderX.Name = "cmbHomeOrderX";
            this.cmbHomeOrderX.Size = new System.Drawing.Size(145, 26);
            this.cmbHomeOrderX.TabIndex = 0;
            // 
            // btnServoW
            // 
            this.btnServoW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnServoW.Location = new System.Drawing.Point(16, 232);
            this.btnServoW.Margin = new System.Windows.Forms.Padding(5);
            this.btnServoW.Name = "btnServoW";
            this.btnServoW.Size = new System.Drawing.Size(125, 36);
            this.btnServoW.TabIndex = 1;
            this.btnServoW.Text = "W -使能";
            this.btnServoW.UseVisualStyleBackColor = true;
            // 
            // btnHomeW
            // 
            this.btnHomeW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHomeW.Location = new System.Drawing.Point(458, 232);
            this.btnHomeW.Margin = new System.Windows.Forms.Padding(5);
            this.btnHomeW.Name = "btnHomeW";
            this.btnHomeW.Size = new System.Drawing.Size(125, 36);
            this.btnHomeW.TabIndex = 1;
            this.btnHomeW.Text = "W -回零";
            this.btnHomeW.UseVisualStyleBackColor = true;
            // 
            // btnServoV
            // 
            this.btnServoV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnServoV.Location = new System.Drawing.Point(16, 188);
            this.btnServoV.Margin = new System.Windows.Forms.Padding(5);
            this.btnServoV.Name = "btnServoV";
            this.btnServoV.Size = new System.Drawing.Size(125, 36);
            this.btnServoV.TabIndex = 1;
            this.btnServoV.Text = "V -使能";
            this.btnServoV.UseVisualStyleBackColor = true;
            // 
            // btnHomeV
            // 
            this.btnHomeV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHomeV.Location = new System.Drawing.Point(458, 188);
            this.btnHomeV.Margin = new System.Windows.Forms.Padding(5);
            this.btnHomeV.Name = "btnHomeV";
            this.btnHomeV.Size = new System.Drawing.Size(125, 36);
            this.btnHomeV.TabIndex = 1;
            this.btnHomeV.Text = "V -回零";
            this.btnHomeV.UseVisualStyleBackColor = true;
            // 
            // btnServoU
            // 
            this.btnServoU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnServoU.Location = new System.Drawing.Point(16, 141);
            this.btnServoU.Margin = new System.Windows.Forms.Padding(5);
            this.btnServoU.Name = "btnServoU";
            this.btnServoU.Size = new System.Drawing.Size(125, 36);
            this.btnServoU.TabIndex = 1;
            this.btnServoU.Text = "U -使能";
            this.btnServoU.UseVisualStyleBackColor = true;
            // 
            // btnHomeU
            // 
            this.btnHomeU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHomeU.Location = new System.Drawing.Point(458, 141);
            this.btnHomeU.Margin = new System.Windows.Forms.Padding(5);
            this.btnHomeU.Name = "btnHomeU";
            this.btnHomeU.Size = new System.Drawing.Size(125, 36);
            this.btnHomeU.TabIndex = 1;
            this.btnHomeU.Text = "U -回零";
            this.btnHomeU.UseVisualStyleBackColor = true;
            // 
            // btnServoZ
            // 
            this.btnServoZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnServoZ.Location = new System.Drawing.Point(16, 96);
            this.btnServoZ.Margin = new System.Windows.Forms.Padding(5);
            this.btnServoZ.Name = "btnServoZ";
            this.btnServoZ.Size = new System.Drawing.Size(125, 36);
            this.btnServoZ.TabIndex = 1;
            this.btnServoZ.Text = "Z -使能";
            this.btnServoZ.UseVisualStyleBackColor = true;
            // 
            // btnHomeZ
            // 
            this.btnHomeZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHomeZ.Location = new System.Drawing.Point(458, 96);
            this.btnHomeZ.Margin = new System.Windows.Forms.Padding(5);
            this.btnHomeZ.Name = "btnHomeZ";
            this.btnHomeZ.Size = new System.Drawing.Size(125, 36);
            this.btnHomeZ.TabIndex = 1;
            this.btnHomeZ.Text = "Z -回零";
            this.btnHomeZ.UseVisualStyleBackColor = true;
            // 
            // btnServoY
            // 
            this.btnServoY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnServoY.Location = new System.Drawing.Point(16, 51);
            this.btnServoY.Margin = new System.Windows.Forms.Padding(5);
            this.btnServoY.Name = "btnServoY";
            this.btnServoY.Size = new System.Drawing.Size(125, 36);
            this.btnServoY.TabIndex = 1;
            this.btnServoY.Text = "Y -使能";
            this.btnServoY.UseVisualStyleBackColor = true;
            // 
            // btnHomeY
            // 
            this.btnHomeY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHomeY.Location = new System.Drawing.Point(458, 51);
            this.btnHomeY.Margin = new System.Windows.Forms.Padding(5);
            this.btnHomeY.Name = "btnHomeY";
            this.btnHomeY.Size = new System.Drawing.Size(125, 36);
            this.btnHomeY.TabIndex = 1;
            this.btnHomeY.Text = "Y -回零";
            this.btnHomeY.UseVisualStyleBackColor = true;
            // 
            // btnServoX
            // 
            this.btnServoX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnServoX.Location = new System.Drawing.Point(16, 5);
            this.btnServoX.Margin = new System.Windows.Forms.Padding(5);
            this.btnServoX.Name = "btnServoX";
            this.btnServoX.Size = new System.Drawing.Size(125, 36);
            this.btnServoX.TabIndex = 1;
            this.btnServoX.Text = "X -使能";
            this.btnServoX.UseVisualStyleBackColor = true;
            // 
            // btnHomeX
            // 
            this.btnHomeX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHomeX.Location = new System.Drawing.Point(458, 5);
            this.btnHomeX.Margin = new System.Windows.Forms.Padding(5);
            this.btnHomeX.Name = "btnHomeX";
            this.btnHomeX.Size = new System.Drawing.Size(125, 36);
            this.btnHomeX.TabIndex = 1;
            this.btnHomeX.Text = "X -回零";
            this.btnHomeX.UseVisualStyleBackColor = true;
            // 
            // cmbHomeOrderU
            // 
            this.cmbHomeOrderU.FormattingEnabled = true;
            this.cmbHomeOrderU.Location = new System.Drawing.Point(226, 145);
            this.cmbHomeOrderU.Margin = new System.Windows.Forms.Padding(5);
            this.cmbHomeOrderU.Name = "cmbHomeOrderU";
            this.cmbHomeOrderU.Size = new System.Drawing.Size(145, 26);
            this.cmbHomeOrderU.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radMedium);
            this.groupBox5.Controls.Add(this.radShort);
            this.groupBox5.Controls.Add(this.radLong);
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
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(0, 336);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox5.Size = new System.Drawing.Size(846, 84);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "移动距离";
            // 
            // radMedium
            // 
            this.radMedium.AutoSize = true;
            this.radMedium.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMedium.Location = new System.Drawing.Point(81, 45);
            this.radMedium.Margin = new System.Windows.Forms.Padding(5);
            this.radMedium.Name = "radMedium";
            this.radMedium.Size = new System.Drawing.Size(44, 22);
            this.radMedium.TabIndex = 6;
            this.radMedium.TabStop = true;
            this.radMedium.Text = "中";
            this.radMedium.UseVisualStyleBackColor = true;
            // 
            // radShort
            // 
            this.radShort.AutoSize = true;
            this.radShort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radShort.Location = new System.Drawing.Point(134, 45);
            this.radShort.Margin = new System.Windows.Forms.Padding(5);
            this.radShort.Name = "radShort";
            this.radShort.Size = new System.Drawing.Size(44, 22);
            this.radShort.TabIndex = 5;
            this.radShort.TabStop = true;
            this.radShort.Text = "短";
            this.radShort.UseVisualStyleBackColor = true;
            // 
            // radLong
            // 
            this.radLong.AutoSize = true;
            this.radLong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLong.Location = new System.Drawing.Point(29, 45);
            this.radLong.Margin = new System.Windows.Forms.Padding(5);
            this.radLong.Name = "radLong";
            this.radLong.Size = new System.Drawing.Size(44, 22);
            this.radLong.TabIndex = 4;
            this.radLong.TabStop = true;
            this.radLong.Text = "长";
            this.radLong.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label30.Location = new System.Drawing.Point(545, 18);
            this.label30.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(20, 18);
            this.label30.TabIndex = 1;
            this.label30.Text = "U";
            // 
            // cmbStepX
            // 
            this.cmbStepX.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStepX.FormattingEnabled = true;
            this.cmbStepX.Location = new System.Drawing.Point(186, 41);
            this.cmbStepX.Margin = new System.Windows.Forms.Padding(5);
            this.cmbStepX.Name = "cmbStepX";
            this.cmbStepX.Size = new System.Drawing.Size(99, 28);
            this.cmbStepX.TabIndex = 1;
            this.cmbStepX.Text = "10";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label29.Location = new System.Drawing.Point(652, 18);
            this.label29.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(18, 18);
            this.label29.TabIndex = 1;
            this.label29.Text = "V";
            // 
            // cmbStepU
            // 
            this.cmbStepU.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStepU.FormattingEnabled = true;
            this.cmbStepU.Location = new System.Drawing.Point(505, 41);
            this.cmbStepU.Margin = new System.Windows.Forms.Padding(5);
            this.cmbStepU.Name = "cmbStepU";
            this.cmbStepU.Size = new System.Drawing.Size(99, 28);
            this.cmbStepU.TabIndex = 1;
            this.cmbStepU.Text = "10";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label28.Location = new System.Drawing.Point(755, 18);
            this.label28.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(24, 18);
            this.label28.TabIndex = 1;
            this.label28.Text = "W";
            // 
            // cmbStepW
            // 
            this.cmbStepW.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStepW.FormattingEnabled = true;
            this.cmbStepW.Location = new System.Drawing.Point(716, 41);
            this.cmbStepW.Margin = new System.Windows.Forms.Padding(5);
            this.cmbStepW.Name = "cmbStepW";
            this.cmbStepW.Size = new System.Drawing.Size(99, 28);
            this.cmbStepW.TabIndex = 1;
            this.cmbStepW.Text = "10";
            // 
            // cmbStepY
            // 
            this.cmbStepY.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStepY.FormattingEnabled = true;
            this.cmbStepY.Location = new System.Drawing.Point(292, 41);
            this.cmbStepY.Margin = new System.Windows.Forms.Padding(5);
            this.cmbStepY.Name = "cmbStepY";
            this.cmbStepY.Size = new System.Drawing.Size(99, 28);
            this.cmbStepY.TabIndex = 1;
            this.cmbStepY.Text = "10";
            // 
            // cmbStepZ
            // 
            this.cmbStepZ.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStepZ.FormattingEnabled = true;
            this.cmbStepZ.Location = new System.Drawing.Point(399, 41);
            this.cmbStepZ.Margin = new System.Windows.Forms.Padding(5);
            this.cmbStepZ.Name = "cmbStepZ";
            this.cmbStepZ.Size = new System.Drawing.Size(99, 28);
            this.cmbStepZ.TabIndex = 1;
            this.cmbStepZ.Text = "10";
            // 
            // cmbStepV
            // 
            this.cmbStepV.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStepV.FormattingEnabled = true;
            this.cmbStepV.Location = new System.Drawing.Point(611, 41);
            this.cmbStepV.Margin = new System.Windows.Forms.Padding(5);
            this.cmbStepV.Name = "cmbStepV";
            this.cmbStepV.Size = new System.Drawing.Size(99, 28);
            this.cmbStepV.TabIndex = 1;
            this.cmbStepV.Text = "10";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label27.Location = new System.Drawing.Point(440, 18);
            this.label27.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(18, 18);
            this.label27.TabIndex = 1;
            this.label27.Text = "Z";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label25.Location = new System.Drawing.Point(226, 18);
            this.label25.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(19, 18);
            this.label25.TabIndex = 1;
            this.label25.Text = "X";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label26.Location = new System.Drawing.Point(334, 18);
            this.label26.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(18, 18);
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
            this.groupBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxStatus.Location = new System.Drawing.Point(0, 420);
            this.groupBoxStatus.Margin = new System.Windows.Forms.Padding(0);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Padding = new System.Windows.Forms.Padding(0);
            this.groupBoxStatus.Size = new System.Drawing.Size(846, 140);
            this.groupBoxStatus.TabIndex = 24;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "状态";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label22.Location = new System.Drawing.Point(479, 14);
            this.label22.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(20, 18);
            this.label22.TabIndex = 1;
            this.label22.Text = "U";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label23.Location = new System.Drawing.Point(619, 14);
            this.label23.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(18, 18);
            this.label23.TabIndex = 1;
            this.label23.Text = "V";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label24.Location = new System.Drawing.Point(755, 14);
            this.label24.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(24, 18);
            this.label24.TabIndex = 1;
            this.label24.Text = "W";
            // 
            // tbOrgW
            // 
            this.tbOrgW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbOrgW.Location = new System.Drawing.Point(716, 72);
            this.tbOrgW.Margin = new System.Windows.Forms.Padding(5);
            this.tbOrgW.Name = "tbOrgW";
            this.tbOrgW.ReadOnly = true;
            this.tbOrgW.Size = new System.Drawing.Size(99, 24);
            this.tbOrgW.TabIndex = 0;
            this.tbOrgW.Text = "ORG";
            this.tbOrgW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMelW
            // 
            this.tbMelW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMelW.Location = new System.Drawing.Point(716, 108);
            this.tbMelW.Margin = new System.Windows.Forms.Padding(5);
            this.tbMelW.Name = "tbMelW";
            this.tbMelW.ReadOnly = true;
            this.tbMelW.Size = new System.Drawing.Size(99, 24);
            this.tbMelW.TabIndex = 0;
            this.tbMelW.Text = "MEL";
            this.tbMelW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbOrgZ
            // 
            this.tbOrgZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbOrgZ.Location = new System.Drawing.Point(300, 72);
            this.tbOrgZ.Margin = new System.Windows.Forms.Padding(5);
            this.tbOrgZ.Name = "tbOrgZ";
            this.tbOrgZ.ReadOnly = true;
            this.tbOrgZ.Size = new System.Drawing.Size(99, 24);
            this.tbOrgZ.TabIndex = 0;
            this.tbOrgZ.Text = "ORG";
            this.tbOrgZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMelZ
            // 
            this.tbMelZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMelZ.Location = new System.Drawing.Point(300, 108);
            this.tbMelZ.Margin = new System.Windows.Forms.Padding(5);
            this.tbMelZ.Name = "tbMelZ";
            this.tbMelZ.ReadOnly = true;
            this.tbMelZ.Size = new System.Drawing.Size(99, 24);
            this.tbMelZ.TabIndex = 0;
            this.tbMelZ.Text = "MEL";
            this.tbMelZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbOrgV
            // 
            this.tbOrgV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbOrgV.Location = new System.Drawing.Point(578, 72);
            this.tbOrgV.Margin = new System.Windows.Forms.Padding(5);
            this.tbOrgV.Name = "tbOrgV";
            this.tbOrgV.ReadOnly = true;
            this.tbOrgV.Size = new System.Drawing.Size(99, 24);
            this.tbOrgV.TabIndex = 0;
            this.tbOrgV.Text = "ORG";
            this.tbOrgV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMelV
            // 
            this.tbMelV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMelV.Location = new System.Drawing.Point(578, 108);
            this.tbMelV.Margin = new System.Windows.Forms.Padding(5);
            this.tbMelV.Name = "tbMelV";
            this.tbMelV.ReadOnly = true;
            this.tbMelV.Size = new System.Drawing.Size(99, 24);
            this.tbMelV.TabIndex = 0;
            this.tbMelV.Text = "MEL";
            this.tbMelV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbOrgY
            // 
            this.tbOrgY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbOrgY.Location = new System.Drawing.Point(161, 72);
            this.tbOrgY.Margin = new System.Windows.Forms.Padding(5);
            this.tbOrgY.Name = "tbOrgY";
            this.tbOrgY.ReadOnly = true;
            this.tbOrgY.Size = new System.Drawing.Size(99, 24);
            this.tbOrgY.TabIndex = 0;
            this.tbOrgY.Text = "ORG";
            this.tbOrgY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMelY
            // 
            this.tbMelY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMelY.Location = new System.Drawing.Point(161, 108);
            this.tbMelY.Margin = new System.Windows.Forms.Padding(5);
            this.tbMelY.Name = "tbMelY";
            this.tbMelY.ReadOnly = true;
            this.tbMelY.Size = new System.Drawing.Size(99, 24);
            this.tbMelY.TabIndex = 0;
            this.tbMelY.Text = "MEL";
            this.tbMelY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label21.Location = new System.Drawing.Point(341, 14);
            this.label21.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(18, 18);
            this.label21.TabIndex = 1;
            this.label21.Text = "Z";
            // 
            // tbPelW
            // 
            this.tbPelW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPelW.Location = new System.Drawing.Point(716, 38);
            this.tbPelW.Margin = new System.Windows.Forms.Padding(5);
            this.tbPelW.Name = "tbPelW";
            this.tbPelW.ReadOnly = true;
            this.tbPelW.Size = new System.Drawing.Size(99, 24);
            this.tbPelW.TabIndex = 0;
            this.tbPelW.Text = "PEL";
            this.tbPelW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPelZ
            // 
            this.tbPelZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPelZ.Location = new System.Drawing.Point(300, 38);
            this.tbPelZ.Margin = new System.Windows.Forms.Padding(5);
            this.tbPelZ.Name = "tbPelZ";
            this.tbPelZ.ReadOnly = true;
            this.tbPelZ.Size = new System.Drawing.Size(99, 24);
            this.tbPelZ.TabIndex = 0;
            this.tbPelZ.Text = "PEL";
            this.tbPelZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbOrgU
            // 
            this.tbOrgU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbOrgU.Location = new System.Drawing.Point(439, 72);
            this.tbOrgU.Margin = new System.Windows.Forms.Padding(5);
            this.tbOrgU.Name = "tbOrgU";
            this.tbOrgU.ReadOnly = true;
            this.tbOrgU.Size = new System.Drawing.Size(99, 24);
            this.tbOrgU.TabIndex = 0;
            this.tbOrgU.Text = "ORG";
            this.tbOrgU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMelU
            // 
            this.tbMelU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMelU.Location = new System.Drawing.Point(439, 108);
            this.tbMelU.Margin = new System.Windows.Forms.Padding(5);
            this.tbMelU.Name = "tbMelU";
            this.tbMelU.ReadOnly = true;
            this.tbMelU.Size = new System.Drawing.Size(99, 24);
            this.tbMelU.TabIndex = 0;
            this.tbMelU.Text = "MEL";
            this.tbMelU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(202, 14);
            this.label20.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(18, 18);
            this.label20.TabIndex = 1;
            this.label20.Text = "Y";
            // 
            // tbOrgX
            // 
            this.tbOrgX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbOrgX.Location = new System.Drawing.Point(22, 72);
            this.tbOrgX.Margin = new System.Windows.Forms.Padding(5);
            this.tbOrgX.Name = "tbOrgX";
            this.tbOrgX.ReadOnly = true;
            this.tbOrgX.Size = new System.Drawing.Size(99, 24);
            this.tbOrgX.TabIndex = 0;
            this.tbOrgX.Text = "ORG";
            this.tbOrgX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMelX
            // 
            this.tbMelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMelX.Location = new System.Drawing.Point(22, 108);
            this.tbMelX.Margin = new System.Windows.Forms.Padding(5);
            this.tbMelX.Name = "tbMelX";
            this.tbMelX.ReadOnly = true;
            this.tbMelX.Size = new System.Drawing.Size(99, 24);
            this.tbMelX.TabIndex = 0;
            this.tbMelX.Text = "MEL";
            this.tbMelX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label19.Location = new System.Drawing.Point(62, 14);
            this.label19.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(19, 18);
            this.label19.TabIndex = 1;
            this.label19.Text = "X";
            // 
            // tbPelV
            // 
            this.tbPelV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPelV.Location = new System.Drawing.Point(578, 38);
            this.tbPelV.Margin = new System.Windows.Forms.Padding(5);
            this.tbPelV.Name = "tbPelV";
            this.tbPelV.ReadOnly = true;
            this.tbPelV.Size = new System.Drawing.Size(99, 24);
            this.tbPelV.TabIndex = 0;
            this.tbPelV.Text = "PEL";
            this.tbPelV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPelY
            // 
            this.tbPelY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPelY.Location = new System.Drawing.Point(161, 38);
            this.tbPelY.Margin = new System.Windows.Forms.Padding(5);
            this.tbPelY.Name = "tbPelY";
            this.tbPelY.ReadOnly = true;
            this.tbPelY.Size = new System.Drawing.Size(99, 24);
            this.tbPelY.TabIndex = 0;
            this.tbPelY.Text = "PEL";
            this.tbPelY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPelU
            // 
            this.tbPelU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPelU.Location = new System.Drawing.Point(439, 38);
            this.tbPelU.Margin = new System.Windows.Forms.Padding(5);
            this.tbPelU.Name = "tbPelU";
            this.tbPelU.ReadOnly = true;
            this.tbPelU.Size = new System.Drawing.Size(99, 24);
            this.tbPelU.TabIndex = 0;
            this.tbPelU.Text = "PEL";
            this.tbPelU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPelX
            // 
            this.tbPelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPelX.Location = new System.Drawing.Point(22, 38);
            this.tbPelX.Margin = new System.Windows.Forms.Padding(5);
            this.tbPelX.Name = "tbPelX";
            this.tbPelX.ReadOnly = true;
            this.tbPelX.Size = new System.Drawing.Size(99, 24);
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
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(846, 252);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox4.Size = new System.Drawing.Size(846, 84);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "实时位置";
            // 
            // tbPosW
            // 
            this.tbPosW.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPosW.Location = new System.Drawing.Point(718, 44);
            this.tbPosW.Margin = new System.Windows.Forms.Padding(5);
            this.tbPosW.Name = "tbPosW";
            this.tbPosW.ReadOnly = true;
            this.tbPosW.Size = new System.Drawing.Size(99, 25);
            this.tbPosW.TabIndex = 5;
            this.tbPosW.Text = "0.000";
            this.tbPosW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(756, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "W";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(342, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Z";
            // 
            // tbPosZ
            // 
            this.tbPosZ.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPosZ.Location = new System.Drawing.Point(301, 44);
            this.tbPosZ.Margin = new System.Windows.Forms.Padding(5);
            this.tbPosZ.Name = "tbPosZ";
            this.tbPosZ.ReadOnly = true;
            this.tbPosZ.Size = new System.Drawing.Size(99, 25);
            this.tbPosZ.TabIndex = 2;
            this.tbPosZ.Text = "0.000";
            this.tbPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbPosX
            // 
            this.tbPosX.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPosX.Location = new System.Drawing.Point(24, 44);
            this.tbPosX.Margin = new System.Windows.Forms.Padding(5);
            this.tbPosX.Name = "tbPosX";
            this.tbPosX.ReadOnly = true;
            this.tbPosX.Size = new System.Drawing.Size(99, 25);
            this.tbPosX.TabIndex = 0;
            this.tbPosX.Text = "0.000";
            this.tbPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(480, 19);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 18);
            this.label6.TabIndex = 1;
            this.label6.Text = "U";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(620, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "V";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(204, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "X";
            // 
            // tbPosY
            // 
            this.tbPosY.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPosY.Location = new System.Drawing.Point(162, 44);
            this.tbPosY.Margin = new System.Windows.Forms.Padding(5);
            this.tbPosY.Name = "tbPosY";
            this.tbPosY.ReadOnly = true;
            this.tbPosY.Size = new System.Drawing.Size(99, 25);
            this.tbPosY.TabIndex = 0;
            this.tbPosY.Text = "0.000";
            this.tbPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbPosU
            // 
            this.tbPosU.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPosU.Location = new System.Drawing.Point(440, 44);
            this.tbPosU.Margin = new System.Windows.Forms.Padding(5);
            this.tbPosU.Name = "tbPosU";
            this.tbPosU.ReadOnly = true;
            this.tbPosU.Size = new System.Drawing.Size(99, 25);
            this.tbPosU.TabIndex = 0;
            this.tbPosU.Text = "0.000";
            this.tbPosU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbPosV
            // 
            this.tbPosV.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPosV.Location = new System.Drawing.Point(579, 44);
            this.tbPosV.Margin = new System.Windows.Forms.Padding(5);
            this.tbPosV.Name = "tbPosV";
            this.tbPosV.ReadOnly = true;
            this.tbPosV.Size = new System.Drawing.Size(99, 25);
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
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(846, 336);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(846, 84);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "实时速度";
            // 
            // tbVelW
            // 
            this.tbVelW.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVelW.Location = new System.Drawing.Point(718, 44);
            this.tbVelW.Margin = new System.Windows.Forms.Padding(5);
            this.tbVelW.Name = "tbVelW";
            this.tbVelW.ReadOnly = true;
            this.tbVelW.Size = new System.Drawing.Size(99, 25);
            this.tbVelW.TabIndex = 5;
            this.tbVelW.Text = "0.000";
            this.tbVelW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(756, 18);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 18);
            this.label7.TabIndex = 4;
            this.label7.Text = "W";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(342, 18);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 18);
            this.label8.TabIndex = 3;
            this.label8.Text = "Z";
            // 
            // tbVelZ
            // 
            this.tbVelZ.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVelZ.Location = new System.Drawing.Point(301, 44);
            this.tbVelZ.Margin = new System.Windows.Forms.Padding(5);
            this.tbVelZ.Name = "tbVelZ";
            this.tbVelZ.ReadOnly = true;
            this.tbVelZ.Size = new System.Drawing.Size(99, 25);
            this.tbVelZ.TabIndex = 2;
            this.tbVelZ.Text = "0.000";
            this.tbVelZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbVelX
            // 
            this.tbVelX.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVelX.Location = new System.Drawing.Point(24, 44);
            this.tbVelX.Margin = new System.Windows.Forms.Padding(5);
            this.tbVelX.Name = "tbVelX";
            this.tbVelX.ReadOnly = true;
            this.tbVelX.Size = new System.Drawing.Size(99, 25);
            this.tbVelX.TabIndex = 0;
            this.tbVelX.Text = "0.000";
            this.tbVelX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(480, 18);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 18);
            this.label9.TabIndex = 1;
            this.label9.Text = "U";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(620, 18);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 18);
            this.label10.TabIndex = 1;
            this.label10.Text = "V";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(204, 18);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 18);
            this.label11.TabIndex = 1;
            this.label11.Text = "Y";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(64, 18);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 18);
            this.label12.TabIndex = 1;
            this.label12.Text = "X";
            // 
            // tbVelY
            // 
            this.tbVelY.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVelY.Location = new System.Drawing.Point(162, 44);
            this.tbVelY.Margin = new System.Windows.Forms.Padding(5);
            this.tbVelY.Name = "tbVelY";
            this.tbVelY.ReadOnly = true;
            this.tbVelY.Size = new System.Drawing.Size(99, 25);
            this.tbVelY.TabIndex = 0;
            this.tbVelY.Text = "0.000";
            this.tbVelY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbVelU
            // 
            this.tbVelU.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVelU.Location = new System.Drawing.Point(440, 44);
            this.tbVelU.Margin = new System.Windows.Forms.Padding(5);
            this.tbVelU.Name = "tbVelU";
            this.tbVelU.ReadOnly = true;
            this.tbVelU.Size = new System.Drawing.Size(99, 25);
            this.tbVelU.TabIndex = 0;
            this.tbVelU.Text = "0.000";
            this.tbVelU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbVelV
            // 
            this.tbVelV.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVelV.Location = new System.Drawing.Point(579, 44);
            this.tbVelV.Margin = new System.Windows.Forms.Padding(5);
            this.tbVelV.Name = "tbVelV";
            this.tbVelV.ReadOnly = true;
            this.tbVelV.Size = new System.Drawing.Size(99, 25);
            this.tbVelV.TabIndex = 0;
            this.tbVelV.Text = "0.000";
            this.tbVelV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.panel3.Location = new System.Drawing.Point(0, 696);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1700, 36);
            this.panel3.TabIndex = 14;
            // 
            // btnOpenPoints
            // 
            this.btnOpenPoints.BackColor = System.Drawing.Color.Cyan;
            this.btnOpenPoints.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOpenPoints.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenPoints.Location = new System.Drawing.Point(1398, 0);
            this.btnOpenPoints.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenPoints.Name = "btnOpenPoints";
            this.btnOpenPoints.Size = new System.Drawing.Size(150, 34);
            this.btnOpenPoints.TabIndex = 146;
            this.btnOpenPoints.Text = "点位管理";
            this.btnOpenPoints.UseVisualStyleBackColor = false;
            this.btnOpenPoints.Click += new System.EventHandler(this.BtnOpenPoints_Click);
            // 
            // btnConfigApply
            // 
            this.btnConfigApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnConfigApply.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnConfigApply.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfigApply.Location = new System.Drawing.Point(1548, 0);
            this.btnConfigApply.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfigApply.Name = "btnConfigApply";
            this.btnConfigApply.Size = new System.Drawing.Size(150, 34);
            this.btnConfigApply.TabIndex = 145;
            this.btnConfigApply.Text = "应用";
            this.btnConfigApply.UseVisualStyleBackColor = false;
            this.btnConfigApply.Click += new System.EventHandler(this.BtnAxisesSaveAs_Click);
            // 
            // cBoxLogDisplay
            // 
            this.cBoxLogDisplay.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBoxLogDisplay.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBoxLogDisplay.Location = new System.Drawing.Point(372, 0);
            this.cBoxLogDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.cBoxLogDisplay.Name = "cBoxLogDisplay";
            this.cBoxLogDisplay.Size = new System.Drawing.Size(124, 34);
            this.cBoxLogDisplay.TabIndex = 2;
            this.cBoxLogDisplay.Text = "Log显示";
            this.cBoxLogDisplay.UseVisualStyleBackColor = true;
            this.cBoxLogDisplay.Visible = false;
            // 
            // cBoxLogEnable
            // 
            this.cBoxLogEnable.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBoxLogEnable.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBoxLogEnable.Location = new System.Drawing.Point(248, 0);
            this.cBoxLogEnable.Margin = new System.Windows.Forms.Padding(4);
            this.cBoxLogEnable.Name = "cBoxLogEnable";
            this.cBoxLogEnable.Size = new System.Drawing.Size(124, 34);
            this.cBoxLogEnable.TabIndex = 1;
            this.cBoxLogEnable.Text = "Log使能";
            this.cBoxLogEnable.UseVisualStyleBackColor = true;
            this.cBoxLogEnable.Visible = false;
            // 
            // cBoxSimulate
            // 
            this.cBoxSimulate.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBoxSimulate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBoxSimulate.Location = new System.Drawing.Point(124, 0);
            this.cBoxSimulate.Margin = new System.Windows.Forms.Padding(4);
            this.cBoxSimulate.Name = "cBoxSimulate";
            this.cBoxSimulate.Size = new System.Drawing.Size(124, 34);
            this.cBoxSimulate.TabIndex = 0;
            this.cBoxSimulate.Text = "模拟";
            this.cBoxSimulate.UseVisualStyleBackColor = true;
            this.cBoxSimulate.Visible = false;
            // 
            // cBoxEnable
            // 
            this.cBoxEnable.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBoxEnable.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBoxEnable.Location = new System.Drawing.Point(0, 0);
            this.cBoxEnable.Margin = new System.Windows.Forms.Padding(4);
            this.cBoxEnable.Name = "cBoxEnable";
            this.cBoxEnable.Size = new System.Drawing.Size(124, 34);
            this.cBoxEnable.TabIndex = 0;
            this.cBoxEnable.Text = "使能";
            this.cBoxEnable.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.tbAxisesConfigPath);
            this.panel4.Controls.Add(this.btnAxisesSave);
            this.panel4.Controls.Add(this.btnAxisesLoad);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 664);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1700, 32);
            this.panel4.TabIndex = 13;
            // 
            // tbAxisesConfigPath
            // 
            this.tbAxisesConfigPath.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbAxisesConfigPath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbAxisesConfigPath.Location = new System.Drawing.Point(0, 0);
            this.tbAxisesConfigPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbAxisesConfigPath.Name = "tbAxisesConfigPath";
            this.tbAxisesConfigPath.Size = new System.Drawing.Size(596, 34);
            this.tbAxisesConfigPath.TabIndex = 164;
            // 
            // btnAxisesSave
            // 
            this.btnAxisesSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAxisesSave.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAxisesSave.Location = new System.Drawing.Point(1398, 0);
            this.btnAxisesSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnAxisesSave.Name = "btnAxisesSave";
            this.btnAxisesSave.Size = new System.Drawing.Size(150, 30);
            this.btnAxisesSave.TabIndex = 161;
            this.btnAxisesSave.Text = "保存";
            this.btnAxisesSave.UseVisualStyleBackColor = true;
            this.btnAxisesSave.Visible = false;
            // 
            // btnAxisesLoad
            // 
            this.btnAxisesLoad.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAxisesLoad.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAxisesLoad.Location = new System.Drawing.Point(1548, 0);
            this.btnAxisesLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnAxisesLoad.Name = "btnAxisesLoad";
            this.btnAxisesLoad.Size = new System.Drawing.Size(150, 30);
            this.btnAxisesLoad.TabIndex = 162;
            this.btnAxisesLoad.Text = "载入";
            this.btnAxisesLoad.UseVisualStyleBackColor = true;
            this.btnAxisesLoad.Click += new System.EventHandler(this.BtnAxisesLoad_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tlpRow2);
            this.panel2.Controls.Add(this.tbAxisNum);
            this.panel2.Controls.Add(this.lbFeedBackType);
            this.panel2.Controls.Add(this.cBoxVelMode);
            this.panel2.Controls.Add(this.lbVelMode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1700, 32);
            this.panel2.TabIndex = 10;
            // 
            // tlpRow2
            // 
            this.tlpRow2.ColumnCount = 3;
            this.tlpRow2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRow2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpRow2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpRow2.Controls.Add(this.btnAddAxis, 1, 0);
            this.tlpRow2.Controls.Add(this.btnRemoveAxis, 2, 0);
            this.tlpRow2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRow2.Location = new System.Drawing.Point(736, 0);
            this.tlpRow2.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRow2.Name = "tlpRow2";
            this.tlpRow2.RowCount = 1;
            this.tlpRow2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRow2.Size = new System.Drawing.Size(962, 30);
            this.tlpRow2.TabIndex = 12;
            // 
            // btnAddAxis
            // 
            this.btnAddAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddAxis.Image = global::Lead.CPrim.EleCartesian.Properties.Resources.Add;
            this.btnAddAxis.Location = new System.Drawing.Point(662, 0);
            this.btnAddAxis.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddAxis.Name = "btnAddAxis";
            this.btnAddAxis.Size = new System.Drawing.Size(150, 30);
            this.btnAddAxis.TabIndex = 12;
            this.btnAddAxis.UseVisualStyleBackColor = true;
            this.btnAddAxis.Click += new System.EventHandler(this.btnAddAxis_Click);
            // 
            // btnRemoveAxis
            // 
            this.btnRemoveAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoveAxis.Image = global::Lead.CPrim.EleCartesian.Properties.Resources.Remove;
            this.btnRemoveAxis.Location = new System.Drawing.Point(812, 0);
            this.btnRemoveAxis.Margin = new System.Windows.Forms.Padding(0);
            this.btnRemoveAxis.Name = "btnRemoveAxis";
            this.btnRemoveAxis.Size = new System.Drawing.Size(150, 30);
            this.btnRemoveAxis.TabIndex = 10;
            this.btnRemoveAxis.UseVisualStyleBackColor = true;
            this.btnRemoveAxis.Click += new System.EventHandler(this.btnRemoveAxis_Click);
            // 
            // tbAxisNum
            // 
            this.tbAxisNum.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbAxisNum.Enabled = false;
            this.tbAxisNum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbAxisNum.Location = new System.Drawing.Point(518, 0);
            this.tbAxisNum.Margin = new System.Windows.Forms.Padding(4);
            this.tbAxisNum.Multiline = true;
            this.tbAxisNum.Name = "tbAxisNum";
            this.tbAxisNum.Size = new System.Drawing.Size(218, 30);
            this.tbAxisNum.TabIndex = 11;
            this.tbAxisNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbFeedBackType
            // 
            this.lbFeedBackType.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbFeedBackType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbFeedBackType.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbFeedBackType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbFeedBackType.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbFeedBackType.Location = new System.Drawing.Point(368, 0);
            this.lbFeedBackType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFeedBackType.Name = "lbFeedBackType";
            this.lbFeedBackType.Size = new System.Drawing.Size(150, 30);
            this.lbFeedBackType.TabIndex = 7;
            this.lbFeedBackType.Text = "轴数";
            this.lbFeedBackType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cBoxVelMode
            // 
            this.cBoxVelMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBoxVelMode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBoxVelMode.FormattingEnabled = true;
            this.cBoxVelMode.Items.AddRange(new object[] {
            "Velocity",
            "Time"});
            this.cBoxVelMode.Location = new System.Drawing.Point(150, 0);
            this.cBoxVelMode.Margin = new System.Windows.Forms.Padding(4);
            this.cBoxVelMode.Name = "cBoxVelMode";
            this.cBoxVelMode.Size = new System.Drawing.Size(218, 35);
            this.cBoxVelMode.TabIndex = 6;
            // 
            // lbVelMode
            // 
            this.lbVelMode.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbVelMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbVelMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbVelMode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbVelMode.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbVelMode.Location = new System.Drawing.Point(0, 0);
            this.lbVelMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbVelMode.Name = "lbVelMode";
            this.lbVelMode.Size = new System.Drawing.Size(150, 30);
            this.lbVelMode.TabIndex = 5;
            this.lbVelMode.Text = "速度模式";
            this.lbVelMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tlpRow1);
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
            this.panel1.Size = new System.Drawing.Size(1700, 32);
            this.panel1.TabIndex = 9;
            // 
            // tlpRow1
            // 
            this.tlpRow1.ColumnCount = 3;
            this.tlpRow1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRow1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpRow1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpRow1.Controls.Add(this.tbState, 2, 0);
            this.tlpRow1.Controls.Add(this.lbState, 1, 0);
            this.tlpRow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRow1.Location = new System.Drawing.Point(1104, 0);
            this.tlpRow1.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRow1.Name = "tlpRow1";
            this.tlpRow1.RowCount = 1;
            this.tlpRow1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRow1.Size = new System.Drawing.Size(596, 32);
            this.tlpRow1.TabIndex = 0;
            // 
            // tbState
            // 
            this.tbState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbState.Enabled = false;
            this.tbState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbState.Location = new System.Drawing.Point(446, 0);
            this.tbState.Margin = new System.Windows.Forms.Padding(0);
            this.tbState.Multiline = true;
            this.tbState.Name = "tbState";
            this.tbState.Size = new System.Drawing.Size(150, 32);
            this.tbState.TabIndex = 7;
            this.tbState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbState
            // 
            this.lbState.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbState.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbState.Location = new System.Drawing.Point(296, 0);
            this.lbState.Margin = new System.Windows.Forms.Padding(0);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(150, 32);
            this.lbState.TabIndex = 6;
            this.lbState.Text = "状态";
            this.lbState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbState.DoubleClick += new System.EventHandler(this.lbState_DoubleClick);
            // 
            // tbType
            // 
            this.tbType.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbType.Enabled = false;
            this.tbType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbType.Location = new System.Drawing.Point(886, 0);
            this.tbType.Margin = new System.Windows.Forms.Padding(4);
            this.tbType.Multiline = true;
            this.tbType.Name = "tbType";
            this.tbType.ReadOnly = true;
            this.tbType.Size = new System.Drawing.Size(218, 32);
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
            this.lbType.Location = new System.Drawing.Point(736, 0);
            this.lbType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(150, 32);
            this.lbType.TabIndex = 4;
            this.lbType.Text = "类型";
            this.lbType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbInfo
            // 
            this.tbInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbInfo.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbInfo.Location = new System.Drawing.Point(518, 0);
            this.tbInfo.Margin = new System.Windows.Forms.Padding(4);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(218, 32);
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
            this.lbInfo.Location = new System.Drawing.Point(368, 0);
            this.lbInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(150, 32);
            this.lbInfo.TabIndex = 2;
            this.lbInfo.Text = "信息";
            this.lbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbName
            // 
            this.tbName.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbName.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbName.Location = new System.Drawing.Point(150, 0);
            this.tbName.Margin = new System.Windows.Forms.Padding(4);
            this.tbName.Multiline = true;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(218, 32);
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
            this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(150, 32);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "名称";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbName.DoubleClick += new System.EventHandler(this.ConfigUI_Click);
            // 
            // ConfigUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfigUI";
            this.Size = new System.Drawing.Size(1700, 732);
            this.Load += new System.EventHandler(this.ConfigUI_Load);
            this.tlpMain.ResumeLayout(false);
            this.tabCartesianConfig.ResumeLayout(false);
            this.tabPageAxisStatus.ResumeLayout(false);
            this.tabPageAxisConfig.ResumeLayout(false);
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
            this.panel2.PerformLayout();
            this.tlpRow2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tlpRow1.ResumeLayout(false);
            this.tlpRow1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tlpMain;
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
        private Label lbFeedBackType;
        private ComboBox cBoxVelMode;
        private Label lbVelMode;
        private Panel panel4;
        private TextBox tbAxisesConfigPath;
        private Button btnAxisesSave;
        private Button btnAxisesLoad;
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
        private Button btnServoOffAll;
        private ContextMenuStrip mnuPoints;
        private ToolStripMenuItem tsmSave;
        private ToolStripMenuItem tsmReLoad;
        private ToolStripMenuItem tsmUpdate;
        private ToolStripMenuItem tsmToPoint;
        private TextBox tbAxisNum;
        private Button btnRemoveAxis;
        private Button btnAddAxis;
        private RadioButton radMedium;
        private RadioButton radShort;
        private RadioButton radLong;
        private TableLayoutPanel tlpRow2;
        private TableLayoutPanel tlpRow1;
        private FlowLayoutPanel flowPanelStatus;
    }
}
