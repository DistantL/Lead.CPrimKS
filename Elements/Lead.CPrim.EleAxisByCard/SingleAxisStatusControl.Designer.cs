using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.EleAxisByCard
{
    partial class SingleAxisStatusControl
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
            this.gBoxAxisName = new System.Windows.Forms.GroupBox();
            this.smsConfigUi = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnutConfigUiSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gBoxMonitor = new System.Windows.Forms.GroupBox();
            this.lbSInp = new System.Windows.Forms.Label();
            this.lbelActualVel = new System.Windows.Forms.Label();
            this.labelPEL = new System.Windows.Forms.Label();
            this.lb_ActiveSpeed = new System.Windows.Forms.Label();
            this.labelSPEL = new System.Windows.Forms.Label();
            this.lbelActualPos = new System.Windows.Forms.Label();
            this.labelORG = new System.Windows.Forms.Label();
            this.lb_ActivePos = new System.Windows.Forms.Label();
            this.labelSMEL = new System.Windows.Forms.Label();
            this.lbelCmdVel = new System.Windows.Forms.Label();
            this.labelMEL = new System.Windows.Forms.Label();
            this.lb_CommandSpeed = new System.Windows.Forms.Label();
            this.labelCSTP = new System.Windows.Forms.Label();
            this.lbelCmdPos = new System.Windows.Forms.Label();
            this.labelEMG = new System.Windows.Forms.Label();
            this.lb_CommandPos = new System.Windows.Forms.Label();
            this.labelINP = new System.Windows.Forms.Label();
            this.labelALM = new System.Windows.Forms.Label();
            this.gBoxDebug = new System.Windows.Forms.GroupBox();
            this.btnVelAdd = new System.Windows.Forms.Button();
            this.btnVelDec = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnSetPos = new System.Windows.Forms.Button();
            this.tBoxSetPos = new System.Windows.Forms.TextBox();
            this.lbSetPos = new System.Windows.Forms.Label();
            this.btnGoPos = new System.Windows.Forms.Button();
            this.tBoxGoPos = new System.Windows.Forms.TextBox();
            this.lb_GoPos = new System.Windows.Forms.Label();
            this.btnJogAdd = new System.Windows.Forms.Button();
            this.btnJogDec = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnServoOn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabJogStep = new System.Windows.Forms.TabPage();
            this.tBoxJogVel = new System.Windows.Forms.TextBox();
            this.lb_SpeedValue = new System.Windows.Forms.Label();
            this.comboBoxJogStep = new System.Windows.Forms.ComboBox();
            this.lb_JogStepValue = new System.Windows.Forms.Label();
            this.rBtnStepShort = new System.Windows.Forms.RadioButton();
            this.rBtnStepMedium = new System.Windows.Forms.RadioButton();
            this.rBtnStepLong = new System.Windows.Forms.RadioButton();
            this.tabJogVel = new System.Windows.Forms.TabPage();
            this.tBoxJogDec = new System.Windows.Forms.TextBox();
            this.lbelDefaultDec = new System.Windows.Forms.Label();
            this.tBoxJogAcc = new System.Windows.Forms.TextBox();
            this.lbelDefaultAcc = new System.Windows.Forms.Label();
            this.tipGoPos = new System.Windows.Forms.ToolTip(this.components);
            this.gBoxAxisName.SuspendLayout();
            this.smsConfigUi.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gBoxMonitor.SuspendLayout();
            this.gBoxDebug.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabJogStep.SuspendLayout();
            this.tabJogVel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxAxisName
            // 
            this.gBoxAxisName.ContextMenuStrip = this.smsConfigUi;
            this.gBoxAxisName.Controls.Add(this.tableLayoutPanel1);
            this.gBoxAxisName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxAxisName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxAxisName.Location = new System.Drawing.Point(0, 0);
            this.gBoxAxisName.Margin = new System.Windows.Forms.Padding(0);
            this.gBoxAxisName.Name = "gBoxAxisName";
            this.gBoxAxisName.Size = new System.Drawing.Size(239, 534);
            this.gBoxAxisName.TabIndex = 1;
            this.gBoxAxisName.TabStop = false;
            this.gBoxAxisName.Text = "AxisName";
            // 
            // smsConfigUi
            // 
            this.smsConfigUi.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.smsConfigUi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnutConfigUiSelected});
            this.smsConfigUi.Name = "smsStatusUi";
            this.smsConfigUi.Size = new System.Drawing.Size(101, 26);
            // 
            // mnutConfigUiSelected
            // 
            this.mnutConfigUiSelected.Name = "mnutConfigUiSelected";
            this.mnutConfigUiSelected.Size = new System.Drawing.Size(100, 22);
            this.mnutConfigUiSelected.Text = "选择";
            this.mnutConfigUiSelected.Click += new System.EventHandler(this.mnutConfigUiSelected_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gBoxMonitor, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gBoxDebug, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.3822F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.6178F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(233, 513);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gBoxMonitor
            // 
            this.gBoxMonitor.Controls.Add(this.lbSInp);
            this.gBoxMonitor.Controls.Add(this.lbelActualVel);
            this.gBoxMonitor.Controls.Add(this.labelPEL);
            this.gBoxMonitor.Controls.Add(this.lb_ActiveSpeed);
            this.gBoxMonitor.Controls.Add(this.labelSPEL);
            this.gBoxMonitor.Controls.Add(this.lbelActualPos);
            this.gBoxMonitor.Controls.Add(this.labelORG);
            this.gBoxMonitor.Controls.Add(this.lb_ActivePos);
            this.gBoxMonitor.Controls.Add(this.labelSMEL);
            this.gBoxMonitor.Controls.Add(this.lbelCmdVel);
            this.gBoxMonitor.Controls.Add(this.labelMEL);
            this.gBoxMonitor.Controls.Add(this.lb_CommandSpeed);
            this.gBoxMonitor.Controls.Add(this.labelCSTP);
            this.gBoxMonitor.Controls.Add(this.lbelCmdPos);
            this.gBoxMonitor.Controls.Add(this.labelEMG);
            this.gBoxMonitor.Controls.Add(this.lb_CommandPos);
            this.gBoxMonitor.Controls.Add(this.labelINP);
            this.gBoxMonitor.Controls.Add(this.labelALM);
            this.gBoxMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxMonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxMonitor.Location = new System.Drawing.Point(3, 3);
            this.gBoxMonitor.Name = "gBoxMonitor";
            this.gBoxMonitor.Size = new System.Drawing.Size(227, 175);
            this.gBoxMonitor.TabIndex = 0;
            this.gBoxMonitor.TabStop = false;
            this.gBoxMonitor.Text = "状态";
            // 
            // lbSInp
            // 
            this.lbSInp.AutoSize = true;
            this.lbSInp.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbSInp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSInp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSInp.Location = new System.Drawing.Point(79, 16);
            this.lbSInp.Name = "lbSInp";
            this.lbSInp.Size = new System.Drawing.Size(41, 17);
            this.lbSInp.TabIndex = 19;
            this.lbSInp.Tag = "0";
            this.lbSInp.Text = "SINP";
            this.tipGoPos.SetToolTip(this.lbSInp, "报警");
            this.lbSInp.Visible = false;
            // 
            // lbelActualVel
            // 
            this.lbelActualVel.AutoSize = true;
            this.lbelActualVel.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lbelActualVel.Location = new System.Drawing.Point(129, 96);
            this.lbelActualVel.Name = "lbelActualVel";
            this.lbelActualVel.Size = new System.Drawing.Size(66, 20);
            this.lbelActualVel.TabIndex = 18;
            this.lbelActualVel.Text = "-999.999";
            // 
            // labelPEL
            // 
            this.labelPEL.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelPEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPEL.Location = new System.Drawing.Point(181, 152);
            this.labelPEL.Name = "labelPEL";
            this.labelPEL.Size = new System.Drawing.Size(40, 17);
            this.labelPEL.TabIndex = 10;
            this.labelPEL.Tag = "0";
            this.labelPEL.Text = "PEL";
            this.labelPEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tipGoPos.SetToolTip(this.labelPEL, "正限位");
            // 
            // lb_ActiveSpeed
            // 
            this.lb_ActiveSpeed.AutoSize = true;
            this.lb_ActiveSpeed.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.lb_ActiveSpeed.Location = new System.Drawing.Point(3, 97);
            this.lb_ActiveSpeed.Name = "lb_ActiveSpeed";
            this.lb_ActiveSpeed.Size = new System.Drawing.Size(79, 19);
            this.lb_ActiveSpeed.TabIndex = 16;
            this.lb_ActiveSpeed.Text = "实际速度：";
            // 
            // labelSPEL
            // 
            this.labelSPEL.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelSPEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSPEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSPEL.Location = new System.Drawing.Point(135, 152);
            this.labelSPEL.Name = "labelSPEL";
            this.labelSPEL.Size = new System.Drawing.Size(40, 17);
            this.labelSPEL.TabIndex = 9;
            this.labelSPEL.Tag = "0";
            this.labelSPEL.Text = "SPEL";
            this.labelSPEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tipGoPos.SetToolTip(this.labelSPEL, "软正限位");
            // 
            // lbelActualPos
            // 
            this.lbelActualPos.AutoSize = true;
            this.lbelActualPos.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lbelActualPos.Location = new System.Drawing.Point(129, 69);
            this.lbelActualPos.Name = "lbelActualPos";
            this.lbelActualPos.Size = new System.Drawing.Size(66, 20);
            this.lbelActualPos.TabIndex = 17;
            this.lbelActualPos.Text = "-999.999";
            // 
            // labelORG
            // 
            this.labelORG.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelORG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelORG.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelORG.Location = new System.Drawing.Point(91, 152);
            this.labelORG.Name = "labelORG";
            this.labelORG.Size = new System.Drawing.Size(40, 17);
            this.labelORG.TabIndex = 8;
            this.labelORG.Tag = "0";
            this.labelORG.Text = "ORG";
            this.labelORG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tipGoPos.SetToolTip(this.labelORG, "原点信号");
            // 
            // lb_ActivePos
            // 
            this.lb_ActivePos.AutoSize = true;
            this.lb_ActivePos.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.lb_ActivePos.Location = new System.Drawing.Point(3, 70);
            this.lb_ActivePos.Name = "lb_ActivePos";
            this.lb_ActivePos.Size = new System.Drawing.Size(79, 19);
            this.lb_ActivePos.TabIndex = 15;
            this.lb_ActivePos.Text = "实际位置：";
            // 
            // labelSMEL
            // 
            this.labelSMEL.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelSMEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSMEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSMEL.Location = new System.Drawing.Point(47, 152);
            this.labelSMEL.Name = "labelSMEL";
            this.labelSMEL.Size = new System.Drawing.Size(40, 17);
            this.labelSMEL.TabIndex = 7;
            this.labelSMEL.Tag = "0";
            this.labelSMEL.Text = "SMEL";
            this.labelSMEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tipGoPos.SetToolTip(this.labelSMEL, "软负限位");
            // 
            // lbelCmdVel
            // 
            this.lbelCmdVel.AutoSize = true;
            this.lbelCmdVel.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lbelCmdVel.Location = new System.Drawing.Point(129, 42);
            this.lbelCmdVel.Name = "lbelCmdVel";
            this.lbelCmdVel.Size = new System.Drawing.Size(66, 20);
            this.lbelCmdVel.TabIndex = 14;
            this.lbelCmdVel.Text = "-999.999";
            // 
            // labelMEL
            // 
            this.labelMEL.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelMEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMEL.Location = new System.Drawing.Point(3, 152);
            this.labelMEL.Name = "labelMEL";
            this.labelMEL.Size = new System.Drawing.Size(40, 17);
            this.labelMEL.TabIndex = 6;
            this.labelMEL.Tag = "0";
            this.labelMEL.Text = "MEL";
            this.labelMEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tipGoPos.SetToolTip(this.labelMEL, "负限位");
            // 
            // lb_CommandSpeed
            // 
            this.lb_CommandSpeed.AutoSize = true;
            this.lb_CommandSpeed.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.lb_CommandSpeed.Location = new System.Drawing.Point(3, 43);
            this.lb_CommandSpeed.Name = "lb_CommandSpeed";
            this.lb_CommandSpeed.Size = new System.Drawing.Size(79, 19);
            this.lb_CommandSpeed.TabIndex = 12;
            this.lb_CommandSpeed.Text = "命令速度：";
            // 
            // labelCSTP
            // 
            this.labelCSTP.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelCSTP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCSTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCSTP.Location = new System.Drawing.Point(121, 125);
            this.labelCSTP.Name = "labelCSTP";
            this.labelCSTP.Size = new System.Drawing.Size(40, 17);
            this.labelCSTP.TabIndex = 5;
            this.labelCSTP.Tag = "0";
            this.labelCSTP.Text = "CSTP";
            this.labelCSTP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tipGoPos.SetToolTip(this.labelCSTP, "停止");
            // 
            // lbelCmdPos
            // 
            this.lbelCmdPos.AutoSize = true;
            this.lbelCmdPos.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lbelCmdPos.Location = new System.Drawing.Point(129, 16);
            this.lbelCmdPos.Name = "lbelCmdPos";
            this.lbelCmdPos.Size = new System.Drawing.Size(66, 20);
            this.lbelCmdPos.TabIndex = 13;
            this.lbelCmdPos.Text = "-999.999";
            // 
            // labelEMG
            // 
            this.labelEMG.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelEMG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelEMG.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEMG.Location = new System.Drawing.Point(181, 125);
            this.labelEMG.Name = "labelEMG";
            this.labelEMG.Size = new System.Drawing.Size(40, 17);
            this.labelEMG.TabIndex = 4;
            this.labelEMG.Tag = "0";
            this.labelEMG.Text = "EMG";
            this.labelEMG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tipGoPos.SetToolTip(this.labelEMG, "急停");
            // 
            // lb_CommandPos
            // 
            this.lb_CommandPos.AutoSize = true;
            this.lb_CommandPos.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.lb_CommandPos.Location = new System.Drawing.Point(3, 17);
            this.lb_CommandPos.Name = "lb_CommandPos";
            this.lb_CommandPos.Size = new System.Drawing.Size(79, 19);
            this.lb_CommandPos.TabIndex = 11;
            this.lb_CommandPos.Text = "命令位置：";
            // 
            // labelINP
            // 
            this.labelINP.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelINP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelINP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelINP.Location = new System.Drawing.Point(62, 125);
            this.labelINP.Name = "labelINP";
            this.labelINP.Size = new System.Drawing.Size(40, 17);
            this.labelINP.TabIndex = 3;
            this.labelINP.Tag = "0";
            this.labelINP.Text = "INP";
            this.labelINP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tipGoPos.SetToolTip(this.labelINP, "定位完成");
            // 
            // labelALM
            // 
            this.labelALM.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelALM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelALM.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelALM.Location = new System.Drawing.Point(3, 125);
            this.labelALM.Name = "labelALM";
            this.labelALM.Size = new System.Drawing.Size(40, 17);
            this.labelALM.TabIndex = 1;
            this.labelALM.Tag = "0";
            this.labelALM.Text = "ALM";
            this.labelALM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tipGoPos.SetToolTip(this.labelALM, "报警");
            // 
            // gBoxDebug
            // 
            this.gBoxDebug.Controls.Add(this.btnVelAdd);
            this.gBoxDebug.Controls.Add(this.btnVelDec);
            this.gBoxDebug.Controls.Add(this.btnStop);
            this.gBoxDebug.Controls.Add(this.btnHome);
            this.gBoxDebug.Controls.Add(this.btnSetPos);
            this.gBoxDebug.Controls.Add(this.tBoxSetPos);
            this.gBoxDebug.Controls.Add(this.lbSetPos);
            this.gBoxDebug.Controls.Add(this.btnGoPos);
            this.gBoxDebug.Controls.Add(this.tBoxGoPos);
            this.gBoxDebug.Controls.Add(this.lb_GoPos);
            this.gBoxDebug.Controls.Add(this.btnJogAdd);
            this.gBoxDebug.Controls.Add(this.btnJogDec);
            this.gBoxDebug.Controls.Add(this.btnReset);
            this.gBoxDebug.Controls.Add(this.btnServoOn);
            this.gBoxDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxDebug.Location = new System.Drawing.Point(3, 184);
            this.gBoxDebug.Name = "gBoxDebug";
            this.gBoxDebug.Size = new System.Drawing.Size(227, 195);
            this.gBoxDebug.TabIndex = 1;
            this.gBoxDebug.TabStop = false;
            this.gBoxDebug.Text = "调试";
            // 
            // btnVelAdd
            // 
            this.btnVelAdd.BackColor = System.Drawing.Color.Lavender;
            this.btnVelAdd.Location = new System.Drawing.Point(155, 95);
            this.btnVelAdd.Name = "btnVelAdd";
            this.btnVelAdd.Size = new System.Drawing.Size(66, 32);
            this.btnVelAdd.TabIndex = 171;
            this.btnVelAdd.Text = "VEL+";
            this.tipGoPos.SetToolTip(this.btnVelAdd, "正向速度移动");
            this.btnVelAdd.UseVisualStyleBackColor = false;
            this.btnVelAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnVelAdd_MouseDown);
            this.btnVelAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnVelAdd_MouseUp);
            // 
            // btnVelDec
            // 
            this.btnVelDec.BackColor = System.Drawing.Color.Lavender;
            this.btnVelDec.Location = new System.Drawing.Point(3, 95);
            this.btnVelDec.Name = "btnVelDec";
            this.btnVelDec.Size = new System.Drawing.Size(66, 32);
            this.btnVelDec.TabIndex = 170;
            this.btnVelDec.Text = "VEL-";
            this.tipGoPos.SetToolTip(this.btnVelDec, "负向速度移动");
            this.btnVelDec.UseVisualStyleBackColor = false;
            this.btnVelDec.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnVelDec_MouseDown);
            this.btnVelDec.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnVelDec_MouseUp);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.Location = new System.Drawing.Point(79, 57);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(69, 70);
            this.btnStop.TabIndex = 169;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Lavender;
            this.btnHome.Location = new System.Drawing.Point(155, 19);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(66, 32);
            this.btnHome.TabIndex = 168;
            this.btnHome.Text = "回零";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.BtnHome_Click);
            // 
            // btnSetPos
            // 
            this.btnSetPos.BackColor = System.Drawing.Color.Lavender;
            this.btnSetPos.Location = new System.Drawing.Point(166, 165);
            this.btnSetPos.Name = "btnSetPos";
            this.btnSetPos.Size = new System.Drawing.Size(55, 23);
            this.btnSetPos.TabIndex = 167;
            this.btnSetPos.Text = "设置";
            this.tipGoPos.SetToolTip(this.btnSetPos, "将左侧位置设定到轴参中");
            this.btnSetPos.UseVisualStyleBackColor = false;
            this.btnSetPos.Click += new System.EventHandler(this.btnSetPos_Click);
            // 
            // tBoxSetPos
            // 
            this.tBoxSetPos.Location = new System.Drawing.Point(61, 166);
            this.tBoxSetPos.Name = "tBoxSetPos";
            this.tBoxSetPos.Size = new System.Drawing.Size(101, 21);
            this.tBoxSetPos.TabIndex = 166;
            // 
            // lbSetPos
            // 
            this.lbSetPos.AutoSize = true;
            this.lbSetPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSetPos.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.lbSetPos.Location = new System.Drawing.Point(3, 166);
            this.lbSetPos.Name = "lbSetPos";
            this.lbSetPos.Size = new System.Drawing.Size(53, 21);
            this.lbSetPos.TabIndex = 165;
            this.lbSetPos.Text = "位置：";
            this.tipGoPos.SetToolTip(this.lbSetPos, "双击该标签会将轴的位置设置为0");
            this.lbSetPos.DoubleClick += new System.EventHandler(this.lbSetPos_DoubleClick);
            // 
            // btnGoPos
            // 
            this.btnGoPos.BackColor = System.Drawing.Color.Lavender;
            this.btnGoPos.Location = new System.Drawing.Point(166, 134);
            this.btnGoPos.Name = "btnGoPos";
            this.btnGoPos.Size = new System.Drawing.Size(55, 23);
            this.btnGoPos.TabIndex = 164;
            this.btnGoPos.Text = "移至";
            this.tipGoPos.SetToolTip(this.btnGoPos, "以+/--起始为相对移动，否则为绝对移动");
            this.btnGoPos.UseVisualStyleBackColor = false;
            this.btnGoPos.Click += new System.EventHandler(this.btnGoPos_Click);
            // 
            // tBoxGoPos
            // 
            this.tBoxGoPos.Location = new System.Drawing.Point(61, 135);
            this.tBoxGoPos.Name = "tBoxGoPos";
            this.tBoxGoPos.Size = new System.Drawing.Size(101, 21);
            this.tBoxGoPos.TabIndex = 163;
            // 
            // lb_GoPos
            // 
            this.lb_GoPos.AutoSize = true;
            this.lb_GoPos.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.lb_GoPos.Location = new System.Drawing.Point(3, 136);
            this.lb_GoPos.Name = "lb_GoPos";
            this.lb_GoPos.Size = new System.Drawing.Size(51, 19);
            this.lb_GoPos.TabIndex = 162;
            this.lb_GoPos.Text = "位置：";
            // 
            // btnJogAdd
            // 
            this.btnJogAdd.BackColor = System.Drawing.Color.Lavender;
            this.btnJogAdd.Location = new System.Drawing.Point(155, 57);
            this.btnJogAdd.Name = "btnJogAdd";
            this.btnJogAdd.Size = new System.Drawing.Size(66, 32);
            this.btnJogAdd.TabIndex = 147;
            this.btnJogAdd.Text = "JOG+";
            this.tipGoPos.SetToolTip(this.btnJogAdd, "正向Jog移动");
            this.btnJogAdd.UseVisualStyleBackColor = false;
            // 
            // btnJogDec
            // 
            this.btnJogDec.BackColor = System.Drawing.Color.Lavender;
            this.btnJogDec.Location = new System.Drawing.Point(3, 57);
            this.btnJogDec.Name = "btnJogDec";
            this.btnJogDec.Size = new System.Drawing.Size(66, 32);
            this.btnJogDec.TabIndex = 146;
            this.btnJogDec.Text = "JOG-";
            this.tipGoPos.SetToolTip(this.btnJogDec, "负向Jog移动");
            this.btnJogDec.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Yellow;
            this.btnReset.Location = new System.Drawing.Point(79, 19);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(69, 32);
            this.btnReset.TabIndex = 145;
            this.btnReset.Text = "清报警";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnServoOn
            // 
            this.btnServoOn.BackColor = System.Drawing.Color.Lavender;
            this.btnServoOn.Location = new System.Drawing.Point(3, 19);
            this.btnServoOn.Name = "btnServoOn";
            this.btnServoOn.Size = new System.Drawing.Size(66, 32);
            this.btnServoOn.TabIndex = 144;
            this.btnServoOn.Text = "使能";
            this.btnServoOn.UseVisualStyleBackColor = false;
            this.btnServoOn.Click += new System.EventHandler(this.btnServoOn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabJogStep);
            this.tabControl1.Controls.Add(this.tabJogVel);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(3, 385);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(227, 125);
            this.tabControl1.TabIndex = 2;
            // 
            // tabJogStep
            // 
            this.tabJogStep.Controls.Add(this.tBoxJogVel);
            this.tabJogStep.Controls.Add(this.lb_SpeedValue);
            this.tabJogStep.Controls.Add(this.comboBoxJogStep);
            this.tabJogStep.Controls.Add(this.lb_JogStepValue);
            this.tabJogStep.Controls.Add(this.rBtnStepShort);
            this.tabJogStep.Controls.Add(this.rBtnStepMedium);
            this.tabJogStep.Controls.Add(this.rBtnStepLong);
            this.tabJogStep.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabJogStep.Location = new System.Drawing.Point(4, 24);
            this.tabJogStep.Name = "tabJogStep";
            this.tabJogStep.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabJogStep.Size = new System.Drawing.Size(219, 97);
            this.tabJogStep.TabIndex = 0;
            this.tabJogStep.Text = "Jog距离";
            this.tabJogStep.UseVisualStyleBackColor = true;
            // 
            // tBoxJogVel
            // 
            this.tBoxJogVel.Location = new System.Drawing.Point(134, 64);
            this.tBoxJogVel.Multiline = true;
            this.tBoxJogVel.Name = "tBoxJogVel";
            this.tBoxJogVel.Size = new System.Drawing.Size(80, 21);
            this.tBoxJogVel.TabIndex = 178;
            this.tBoxJogVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBoxJogVel.TextChanged += new System.EventHandler(this.TBoxJogVel_TextChanged);
            // 
            // lb_SpeedValue
            // 
            this.lb_SpeedValue.AutoSize = true;
            this.lb_SpeedValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lb_SpeedValue.Location = new System.Drawing.Point(158, 46);
            this.lb_SpeedValue.Name = "lb_SpeedValue";
            this.lb_SpeedValue.Size = new System.Drawing.Size(33, 15);
            this.lb_SpeedValue.TabIndex = 177;
            this.lb_SpeedValue.Text = "速度";
            // 
            // comboBoxJogStep
            // 
            this.comboBoxJogStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxJogStep.FormattingEnabled = true;
            this.comboBoxJogStep.Items.AddRange(new object[] {
            "10",
            "1",
            "0.1"});
            this.comboBoxJogStep.Location = new System.Drawing.Point(134, 20);
            this.comboBoxJogStep.Name = "comboBoxJogStep";
            this.comboBoxJogStep.Size = new System.Drawing.Size(80, 22);
            this.comboBoxJogStep.TabIndex = 149;
            // 
            // lb_JogStepValue
            // 
            this.lb_JogStepValue.AutoSize = true;
            this.lb_JogStepValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_JogStepValue.Location = new System.Drawing.Point(151, 0);
            this.lb_JogStepValue.Name = "lb_JogStepValue";
            this.lb_JogStepValue.Size = new System.Drawing.Size(46, 15);
            this.lb_JogStepValue.TabIndex = 7;
            this.lb_JogStepValue.Text = "步进值";
            // 
            // rBtnStepShort
            // 
            this.rBtnStepShort.AutoSize = true;
            this.rBtnStepShort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnStepShort.Location = new System.Drawing.Point(4, 66);
            this.rBtnStepShort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rBtnStepShort.Name = "rBtnStepShort";
            this.rBtnStepShort.Size = new System.Drawing.Size(61, 19);
            this.rBtnStepShort.TabIndex = 5;
            this.rBtnStepShort.Text = "短距离";
            this.rBtnStepShort.UseVisualStyleBackColor = true;
            // 
            // rBtnStepMedium
            // 
            this.rBtnStepMedium.AutoSize = true;
            this.rBtnStepMedium.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnStepMedium.Location = new System.Drawing.Point(4, 44);
            this.rBtnStepMedium.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rBtnStepMedium.Name = "rBtnStepMedium";
            this.rBtnStepMedium.Size = new System.Drawing.Size(73, 19);
            this.rBtnStepMedium.TabIndex = 4;
            this.rBtnStepMedium.Text = "中等距离";
            this.rBtnStepMedium.UseVisualStyleBackColor = true;
            // 
            // rBtnStepLong
            // 
            this.rBtnStepLong.AutoSize = true;
            this.rBtnStepLong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnStepLong.Location = new System.Drawing.Point(4, 22);
            this.rBtnStepLong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rBtnStepLong.Name = "rBtnStepLong";
            this.rBtnStepLong.Size = new System.Drawing.Size(61, 19);
            this.rBtnStepLong.TabIndex = 3;
            this.rBtnStepLong.Text = "长距离";
            this.rBtnStepLong.UseVisualStyleBackColor = true;
            // 
            // tabJogVel
            // 
            this.tabJogVel.Controls.Add(this.tBoxJogDec);
            this.tabJogVel.Controls.Add(this.lbelDefaultDec);
            this.tabJogVel.Controls.Add(this.tBoxJogAcc);
            this.tabJogVel.Controls.Add(this.lbelDefaultAcc);
            this.tabJogVel.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tabJogVel.Location = new System.Drawing.Point(4, 24);
            this.tabJogVel.Name = "tabJogVel";
            this.tabJogVel.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabJogVel.Size = new System.Drawing.Size(218, 96);
            this.tabJogVel.TabIndex = 1;
            this.tabJogVel.Text = "Jog加减速";
            this.tabJogVel.UseVisualStyleBackColor = true;
            // 
            // tBoxJogDec
            // 
            this.tBoxJogDec.Location = new System.Drawing.Point(116, 66);
            this.tBoxJogDec.Multiline = true;
            this.tBoxJogDec.Name = "tBoxJogDec";
            this.tBoxJogDec.Size = new System.Drawing.Size(93, 21);
            this.tBoxJogDec.TabIndex = 175;
            this.tBoxJogDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBoxJogDec.TextChanged += new System.EventHandler(this.TBoxJogDec_TextChanged);
            // 
            // lbelDefaultDec
            // 
            this.lbelDefaultDec.AutoSize = true;
            this.lbelDefaultDec.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbelDefaultDec.Location = new System.Drawing.Point(2, 64);
            this.lbelDefaultDec.Name = "lbelDefaultDec";
            this.lbelDefaultDec.Size = new System.Drawing.Size(54, 20);
            this.lbelDefaultDec.TabIndex = 174;
            this.lbelDefaultDec.Text = "减速：";
            // 
            // tBoxJogAcc
            // 
            this.tBoxJogAcc.Location = new System.Drawing.Point(116, 31);
            this.tBoxJogAcc.Multiline = true;
            this.tBoxJogAcc.Name = "tBoxJogAcc";
            this.tBoxJogAcc.Size = new System.Drawing.Size(93, 21);
            this.tBoxJogAcc.TabIndex = 173;
            this.tBoxJogAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBoxJogAcc.TextChanged += new System.EventHandler(this.TBoxJogAcc_TextChanged);
            // 
            // lbelDefaultAcc
            // 
            this.lbelDefaultAcc.AutoSize = true;
            this.lbelDefaultAcc.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbelDefaultAcc.Location = new System.Drawing.Point(2, 29);
            this.lbelDefaultAcc.Name = "lbelDefaultAcc";
            this.lbelDefaultAcc.Size = new System.Drawing.Size(54, 20);
            this.lbelDefaultAcc.TabIndex = 172;
            this.lbelDefaultAcc.Text = "加速：";
            // 
            // tipGoPos
            // 
            this.tipGoPos.IsBalloon = true;
            this.tipGoPos.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tipGoPos.ToolTipTitle = "操作指示";
            // 
            // SingleAxisStatusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gBoxAxisName);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SingleAxisStatusControl";
            this.Size = new System.Drawing.Size(239, 534);
            this.Load += new System.EventHandler(this.SingleAxisStatusControl_Load);
            this.gBoxAxisName.ResumeLayout(false);
            this.smsConfigUi.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gBoxMonitor.ResumeLayout(false);
            this.gBoxMonitor.PerformLayout();
            this.gBoxDebug.ResumeLayout(false);
            this.gBoxDebug.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabJogStep.ResumeLayout(false);
            this.tabJogStep.PerformLayout();
            this.tabJogVel.ResumeLayout(false);
            this.tabJogVel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox gBoxAxisName;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox gBoxMonitor;
        private Label labelPEL;
        private Label labelSPEL;
        private Label labelORG;
        private Label labelSMEL;
        private Label labelMEL;
        private Label labelCSTP;
        private Label labelEMG;
        private Label labelINP;
        private Label labelALM;
        private Label lbelCmdVel;
        private Label lb_CommandSpeed;
        private Label lbelCmdPos;
        private Label lb_CommandPos;
        private Label lbelActualVel;
        private Label lb_ActiveSpeed;
        private Label lbelActualPos;
        private Label lb_ActivePos;
        private GroupBox gBoxDebug;
        private Button btnJogAdd;
        private Button btnJogDec;
        private Button btnReset;
        private Button btnServoOn;
        private Button btnSetPos;
        private TextBox tBoxSetPos;
        private Label lbSetPos;
        private Button btnGoPos;
        private TextBox tBoxGoPos;
        private Label lb_GoPos;
        private Button btnHome;
        private TabControl tabControl1;
        private TabPage tabJogStep;
        private TabPage tabJogVel;
        private RadioButton rBtnStepLong;
        private RadioButton rBtnStepMedium;
        private RadioButton rBtnStepShort;
        private Label lb_JogStepValue;
        private TextBox tBoxJogDec;
        private Label lbelDefaultDec;
        private TextBox tBoxJogAcc;
        private Label lbelDefaultAcc;
        private ComboBox comboBoxJogStep;
        private Button btnStop;
        private Button btnVelAdd;
        private Button btnVelDec;
        private ToolTip tipGoPos;
        private ContextMenuStrip smsConfigUi;
        private ToolStripMenuItem mnutConfigUiSelected;
        private TextBox tBoxJogVel;
        private Label lb_SpeedValue;
        private Label lbSInp;
    }
}
