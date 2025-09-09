using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.EleAxisByCard
{
    partial class SingleAxisConfigControl
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
            this.grpAxisName = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.smsConfigUi = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnutConfigUiSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbHomeVo = new System.Windows.Forms.TextBox();
            this.lb_HomeVo = new System.Windows.Forms.Label();
            this.lb_HomeMode = new System.Windows.Forms.Label();
            this.lb_HomeIndex = new System.Windows.Forms.Label();
            this.tbHomeMode = new System.Windows.Forms.TextBox();
            this.tbHomeIndex = new System.Windows.Forms.TextBox();
            this.lb_SafePos = new System.Windows.Forms.Label();
            this.tbHomeVel = new System.Windows.Forms.TextBox();
            this.tbSafePos = new System.Windows.Forms.TextBox();
            this.lb_HomeVel = new System.Windows.Forms.Label();
            this.lb_SafeIndex = new System.Windows.Forms.Label();
            this.tbHomeAcc = new System.Windows.Forms.TextBox();
            this.tbSafeIndex = new System.Windows.Forms.TextBox();
            this.lb_HomeAcc = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkErrChkEnable = new System.Windows.Forms.CheckBox();
            this.lb_DefaultStartVel = new System.Windows.Forms.Label();
            this.tbDefaultStartVel = new System.Windows.Forms.TextBox();
            this.lb_DefaultMaxVel = new System.Windows.Forms.Label();
            this.tbDefaultMaxVel = new System.Windows.Forms.TextBox();
            this.lb_DefaultStopVel = new System.Windows.Forms.Label();
            this.tbDefaultStopVel = new System.Windows.Forms.TextBox();
            this.lbDefaultAcc = new System.Windows.Forms.Label();
            this.tbErrChkRange = new System.Windows.Forms.TextBox();
            this.tbDefaultAcc = new System.Windows.Forms.TextBox();
            this.lbDefaultDec = new System.Windows.Forms.Label();
            this.tbDefaultDec = new System.Windows.Forms.TextBox();
            this.chkSimulate = new System.Windows.Forms.CheckBox();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grpLimit = new System.Windows.Forms.GroupBox();
            this.tbLimitPosN = new System.Windows.Forms.TextBox();
            this.lb_LimitVelP = new System.Windows.Forms.Label();
            this.tbLimitVelP = new System.Windows.Forms.TextBox();
            this.lb_LimitVelN = new System.Windows.Forms.Label();
            this.tbLimitVelN = new System.Windows.Forms.TextBox();
            this.lb_LimitPosP = new System.Windows.Forms.Label();
            this.lb_LimitPosN = new System.Windows.Forms.Label();
            this.tbLimitPosP = new System.Windows.Forms.TextBox();
            this.grpDrive = new System.Windows.Forms.GroupBox();
            this.tbLead = new System.Windows.Forms.TextBox();
            this.lb_PlsPerRoll = new System.Windows.Forms.Label();
            this.tbPlsPerRoll = new System.Windows.Forms.TextBox();
            this.lb_Lead = new System.Windows.Forms.Label();
            this.lb_DriveType = new System.Windows.Forms.Label();
            this.cmbDriveType = new System.Windows.Forms.ComboBox();
            this.lb_ControlType = new System.Windows.Forms.Label();
            this.cmbControlType = new System.Windows.Forms.ComboBox();
            this.lb_FeedBackType = new System.Windows.Forms.Label();
            this.cmbFeedBackType = new System.Windows.Forms.ComboBox();
            this.grpPrim = new System.Windows.Forms.GroupBox();
            this.lb_VelMode = new System.Windows.Forms.Label();
            this.cmbVelMode = new System.Windows.Forms.ComboBox();
            this.cmbDevName = new System.Windows.Forms.ComboBox();
            this.cmbByType = new System.Windows.Forms.ComboBox();
            this.lb_AxisId = new System.Windows.Forms.Label();
            this.lb_ByType = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.lbDevName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lb_Name = new System.Windows.Forms.Label();
            this.grpAxisName.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.smsConfigUi.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grpLimit.SuspendLayout();
            this.grpDrive.SuspendLayout();
            this.grpPrim.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAxisName
            // 
            this.grpAxisName.Controls.Add(this.tabControl1);
            this.grpAxisName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAxisName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAxisName.Location = new System.Drawing.Point(0, 0);
            this.grpAxisName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpAxisName.Name = "grpAxisName";
            this.grpAxisName.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpAxisName.Size = new System.Drawing.Size(299, 683);
            this.grpAxisName.TabIndex = 0;
            this.grpAxisName.TabStop = false;
            this.grpAxisName.Text = "AxisName";
            // 
            // tabControl1
            // 
            this.tabControl1.ContextMenuStrip = this.smsConfigUi;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(4, 23);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(291, 656);
            this.tabControl1.TabIndex = 144;
            this.tabControl1.DoubleClick += new System.EventHandler(this.mnutConfigUiSelected_DoubleClick);
            // 
            // smsConfigUi
            // 
            this.smsConfigUi.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.smsConfigUi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnutConfigUiSelected});
            this.smsConfigUi.Name = "smsStatusUi";
            this.smsConfigUi.Size = new System.Drawing.Size(109, 28);
            // 
            // mnutConfigUiSelected
            // 
            this.mnutConfigUiSelected.Name = "mnutConfigUiSelected";
            this.mnutConfigUiSelected.Size = new System.Drawing.Size(108, 24);
            this.mnutConfigUiSelected.Text = "选择";
            this.mnutConfigUiSelected.Click += new System.EventHandler(this.mnutConfigUiSelected_DoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.ContextMenuStrip = this.smsConfigUi;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.chkSimulate);
            this.tabPage1.Controls.Add(this.chkEnable);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(283, 623);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "常用";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.ContextMenuStrip = this.smsConfigUi;
            this.groupBox2.Controls.Add(this.tbHomeVo);
            this.groupBox2.Controls.Add(this.lb_HomeVo);
            this.groupBox2.Controls.Add(this.lb_HomeMode);
            this.groupBox2.Controls.Add(this.lb_HomeIndex);
            this.groupBox2.Controls.Add(this.tbHomeMode);
            this.groupBox2.Controls.Add(this.tbHomeIndex);
            this.groupBox2.Controls.Add(this.lb_SafePos);
            this.groupBox2.Controls.Add(this.tbHomeVel);
            this.groupBox2.Controls.Add(this.tbSafePos);
            this.groupBox2.Controls.Add(this.lb_HomeVel);
            this.groupBox2.Controls.Add(this.lb_SafeIndex);
            this.groupBox2.Controls.Add(this.tbHomeAcc);
            this.groupBox2.Controls.Add(this.tbSafeIndex);
            this.groupBox2.Controls.Add(this.lb_HomeAcc);
            this.groupBox2.Location = new System.Drawing.Point(4, 255);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(270, 279);
            this.groupBox2.TabIndex = 258;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "回零参数";
            // 
            // tbHomeVo
            // 
            this.tbHomeVo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.tbHomeVo.Location = new System.Drawing.Point(162, 135);
            this.tbHomeVo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbHomeVo.Multiline = true;
            this.tbHomeVo.Name = "tbHomeVo";
            this.tbHomeVo.Size = new System.Drawing.Size(99, 24);
            this.tbHomeVo.TabIndex = 258;
            this.tbHomeVo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_HomeVo
            // 
            this.lb_HomeVo.AutoSize = true;
            this.lb_HomeVo.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_HomeVo.Location = new System.Drawing.Point(8, 136);
            this.lb_HomeVo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_HomeVo.Name = "lb_HomeVo";
            this.lb_HomeVo.Size = new System.Drawing.Size(107, 25);
            this.lb_HomeVo.TabIndex = 257;
            this.lb_HomeVo.Text = "回零低速：";
            // 
            // lb_HomeMode
            // 
            this.lb_HomeMode.AutoSize = true;
            this.lb_HomeMode.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_HomeMode.Location = new System.Drawing.Point(8, 35);
            this.lb_HomeMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_HomeMode.Name = "lb_HomeMode";
            this.lb_HomeMode.Size = new System.Drawing.Size(107, 25);
            this.lb_HomeMode.TabIndex = 255;
            this.lb_HomeMode.Text = "回零模式：";
            // 
            // lb_HomeIndex
            // 
            this.lb_HomeIndex.AutoSize = true;
            this.lb_HomeIndex.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_HomeIndex.Location = new System.Drawing.Point(8, 170);
            this.lb_HomeIndex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_HomeIndex.Name = "lb_HomeIndex";
            this.lb_HomeIndex.Size = new System.Drawing.Size(107, 25);
            this.lb_HomeIndex.TabIndex = 233;
            this.lb_HomeIndex.Text = "回零顺序：";
            // 
            // tbHomeMode
            // 
            this.tbHomeMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.tbHomeMode.Location = new System.Drawing.Point(162, 34);
            this.tbHomeMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbHomeMode.Multiline = true;
            this.tbHomeMode.Name = "tbHomeMode";
            this.tbHomeMode.Size = new System.Drawing.Size(99, 24);
            this.tbHomeMode.TabIndex = 256;
            this.tbHomeMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbHomeIndex
            // 
            this.tbHomeIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.tbHomeIndex.Location = new System.Drawing.Point(162, 169);
            this.tbHomeIndex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbHomeIndex.Multiline = true;
            this.tbHomeIndex.Name = "tbHomeIndex";
            this.tbHomeIndex.Size = new System.Drawing.Size(99, 24);
            this.tbHomeIndex.TabIndex = 234;
            this.tbHomeIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_SafePos
            // 
            this.lb_SafePos.AutoSize = true;
            this.lb_SafePos.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_SafePos.Location = new System.Drawing.Point(8, 204);
            this.lb_SafePos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_SafePos.Name = "lb_SafePos";
            this.lb_SafePos.Size = new System.Drawing.Size(145, 25);
            this.lb_SafePos.TabIndex = 235;
            this.lb_SafePos.Text = "回零后安全位：";
            // 
            // tbHomeVel
            // 
            this.tbHomeVel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.tbHomeVel.Location = new System.Drawing.Point(162, 101);
            this.tbHomeVel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbHomeVel.Multiline = true;
            this.tbHomeVel.Name = "tbHomeVel";
            this.tbHomeVel.Size = new System.Drawing.Size(99, 24);
            this.tbHomeVel.TabIndex = 254;
            this.tbHomeVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbSafePos
            // 
            this.tbSafePos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.tbSafePos.Location = new System.Drawing.Point(162, 202);
            this.tbSafePos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbSafePos.Multiline = true;
            this.tbSafePos.Name = "tbSafePos";
            this.tbSafePos.Size = new System.Drawing.Size(99, 24);
            this.tbSafePos.TabIndex = 236;
            this.tbSafePos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_HomeVel
            // 
            this.lb_HomeVel.AutoSize = true;
            this.lb_HomeVel.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_HomeVel.Location = new System.Drawing.Point(8, 102);
            this.lb_HomeVel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_HomeVel.Name = "lb_HomeVel";
            this.lb_HomeVel.Size = new System.Drawing.Size(107, 25);
            this.lb_HomeVel.TabIndex = 253;
            this.lb_HomeVel.Text = "回零高速：";
            // 
            // lb_SafeIndex
            // 
            this.lb_SafeIndex.AutoSize = true;
            this.lb_SafeIndex.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_SafeIndex.Location = new System.Drawing.Point(8, 238);
            this.lb_SafeIndex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_SafeIndex.Name = "lb_SafeIndex";
            this.lb_SafeIndex.Size = new System.Drawing.Size(145, 25);
            this.lb_SafeIndex.TabIndex = 237;
            this.lb_SafeIndex.Text = "回安全位顺序：";
            // 
            // tbHomeAcc
            // 
            this.tbHomeAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.tbHomeAcc.Location = new System.Drawing.Point(162, 68);
            this.tbHomeAcc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbHomeAcc.Multiline = true;
            this.tbHomeAcc.Name = "tbHomeAcc";
            this.tbHomeAcc.Size = new System.Drawing.Size(99, 24);
            this.tbHomeAcc.TabIndex = 252;
            this.tbHomeAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbSafeIndex
            // 
            this.tbSafeIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.tbSafeIndex.Location = new System.Drawing.Point(162, 236);
            this.tbSafeIndex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbSafeIndex.Multiline = true;
            this.tbSafeIndex.Name = "tbSafeIndex";
            this.tbSafeIndex.Size = new System.Drawing.Size(99, 24);
            this.tbSafeIndex.TabIndex = 238;
            this.tbSafeIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_HomeAcc
            // 
            this.lb_HomeAcc.AutoSize = true;
            this.lb_HomeAcc.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_HomeAcc.Location = new System.Drawing.Point(8, 69);
            this.lb_HomeAcc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_HomeAcc.Name = "lb_HomeAcc";
            this.lb_HomeAcc.Size = new System.Drawing.Size(126, 25);
            this.lb_HomeAcc.TabIndex = 251;
            this.lb_HomeAcc.Text = "回零加减速：";
            // 
            // groupBox1
            // 
            this.groupBox1.ContextMenuStrip = this.smsConfigUi;
            this.groupBox1.Controls.Add(this.chkErrChkEnable);
            this.groupBox1.Controls.Add(this.lb_DefaultStartVel);
            this.groupBox1.Controls.Add(this.tbDefaultStartVel);
            this.groupBox1.Controls.Add(this.lb_DefaultMaxVel);
            this.groupBox1.Controls.Add(this.tbDefaultMaxVel);
            this.groupBox1.Controls.Add(this.lb_DefaultStopVel);
            this.groupBox1.Controls.Add(this.tbDefaultStopVel);
            this.groupBox1.Controls.Add(this.lbDefaultAcc);
            this.groupBox1.Controls.Add(this.tbErrChkRange);
            this.groupBox1.Controls.Add(this.tbDefaultAcc);
            this.groupBox1.Controls.Add(this.lbDefaultDec);
            this.groupBox1.Controls.Add(this.tbDefaultDec);
            this.groupBox1.Location = new System.Drawing.Point(4, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(270, 240);
            this.groupBox1.TabIndex = 257;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "默认速度参数";
            // 
            // chkErrChkEnable
            // 
            this.chkErrChkEnable.AutoSize = true;
            this.chkErrChkEnable.Font = new System.Drawing.Font("微软雅黑", 10.8F);
            this.chkErrChkEnable.Location = new System.Drawing.Point(11, 198);
            this.chkErrChkEnable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkErrChkEnable.Name = "chkErrChkEnable";
            this.chkErrChkEnable.Size = new System.Drawing.Size(148, 29);
            this.chkErrChkEnable.TabIndex = 251;
            this.chkErrChkEnable.Text = "偏差检测使能";
            this.chkErrChkEnable.UseVisualStyleBackColor = true;
            // 
            // lb_DefaultStartVel
            // 
            this.lb_DefaultStartVel.AutoSize = true;
            this.lb_DefaultStartVel.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_DefaultStartVel.Location = new System.Drawing.Point(8, 22);
            this.lb_DefaultStartVel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_DefaultStartVel.Name = "lb_DefaultStartVel";
            this.lb_DefaultStartVel.Size = new System.Drawing.Size(107, 25);
            this.lb_DefaultStartVel.TabIndex = 239;
            this.lb_DefaultStartVel.Text = "起始速度：";
            // 
            // tbDefaultStartVel
            // 
            this.tbDefaultStartVel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDefaultStartVel.Location = new System.Drawing.Point(162, 21);
            this.tbDefaultStartVel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbDefaultStartVel.Multiline = true;
            this.tbDefaultStartVel.Name = "tbDefaultStartVel";
            this.tbDefaultStartVel.Size = new System.Drawing.Size(99, 24);
            this.tbDefaultStartVel.TabIndex = 240;
            this.tbDefaultStartVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_DefaultMaxVel
            // 
            this.lb_DefaultMaxVel.AutoSize = true;
            this.lb_DefaultMaxVel.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_DefaultMaxVel.Location = new System.Drawing.Point(8, 59);
            this.lb_DefaultMaxVel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_DefaultMaxVel.Name = "lb_DefaultMaxVel";
            this.lb_DefaultMaxVel.Size = new System.Drawing.Size(107, 25);
            this.lb_DefaultMaxVel.TabIndex = 241;
            this.lb_DefaultMaxVel.Text = "最大速度：";
            // 
            // tbDefaultMaxVel
            // 
            this.tbDefaultMaxVel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDefaultMaxVel.Location = new System.Drawing.Point(162, 58);
            this.tbDefaultMaxVel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbDefaultMaxVel.Multiline = true;
            this.tbDefaultMaxVel.Name = "tbDefaultMaxVel";
            this.tbDefaultMaxVel.Size = new System.Drawing.Size(99, 24);
            this.tbDefaultMaxVel.TabIndex = 242;
            this.tbDefaultMaxVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_DefaultStopVel
            // 
            this.lb_DefaultStopVel.AutoSize = true;
            this.lb_DefaultStopVel.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_DefaultStopVel.Location = new System.Drawing.Point(8, 94);
            this.lb_DefaultStopVel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_DefaultStopVel.Name = "lb_DefaultStopVel";
            this.lb_DefaultStopVel.Size = new System.Drawing.Size(107, 25);
            this.lb_DefaultStopVel.TabIndex = 243;
            this.lb_DefaultStopVel.Text = "停止速度：";
            // 
            // tbDefaultStopVel
            // 
            this.tbDefaultStopVel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDefaultStopVel.Location = new System.Drawing.Point(162, 92);
            this.tbDefaultStopVel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbDefaultStopVel.Multiline = true;
            this.tbDefaultStopVel.Name = "tbDefaultStopVel";
            this.tbDefaultStopVel.Size = new System.Drawing.Size(99, 24);
            this.tbDefaultStopVel.TabIndex = 244;
            this.tbDefaultStopVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbDefaultAcc
            // 
            this.lbDefaultAcc.AutoSize = true;
            this.lbDefaultAcc.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDefaultAcc.Location = new System.Drawing.Point(8, 130);
            this.lbDefaultAcc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDefaultAcc.Name = "lbDefaultAcc";
            this.lbDefaultAcc.Size = new System.Drawing.Size(88, 25);
            this.lbDefaultAcc.TabIndex = 245;
            this.lbDefaultAcc.Text = "加速度：";
            // 
            // tbErrChkRange
            // 
            this.tbErrChkRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbErrChkRange.Location = new System.Drawing.Point(162, 200);
            this.tbErrChkRange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbErrChkRange.Multiline = true;
            this.tbErrChkRange.Name = "tbErrChkRange";
            this.tbErrChkRange.Size = new System.Drawing.Size(99, 24);
            this.tbErrChkRange.TabIndex = 250;
            this.tbErrChkRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbDefaultAcc
            // 
            this.tbDefaultAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDefaultAcc.Location = new System.Drawing.Point(162, 129);
            this.tbDefaultAcc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbDefaultAcc.Multiline = true;
            this.tbDefaultAcc.Name = "tbDefaultAcc";
            this.tbDefaultAcc.Size = new System.Drawing.Size(99, 24);
            this.tbDefaultAcc.TabIndex = 246;
            this.tbDefaultAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbDefaultDec
            // 
            this.lbDefaultDec.AutoSize = true;
            this.lbDefaultDec.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDefaultDec.Location = new System.Drawing.Point(8, 165);
            this.lbDefaultDec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDefaultDec.Name = "lbDefaultDec";
            this.lbDefaultDec.Size = new System.Drawing.Size(88, 25);
            this.lbDefaultDec.TabIndex = 247;
            this.lbDefaultDec.Text = "减速度：";
            // 
            // tbDefaultDec
            // 
            this.tbDefaultDec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDefaultDec.Location = new System.Drawing.Point(162, 164);
            this.tbDefaultDec.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbDefaultDec.Multiline = true;
            this.tbDefaultDec.Name = "tbDefaultDec";
            this.tbDefaultDec.Size = new System.Drawing.Size(99, 24);
            this.tbDefaultDec.TabIndex = 248;
            this.tbDefaultDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkSimulate
            // 
            this.chkSimulate.Location = new System.Drawing.Point(162, 542);
            this.chkSimulate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSimulate.Name = "chkSimulate";
            this.chkSimulate.Size = new System.Drawing.Size(112, 32);
            this.chkSimulate.TabIndex = 232;
            this.chkSimulate.Text = "模拟";
            this.chkSimulate.UseVisualStyleBackColor = true;
            this.chkSimulate.Visible = false;
            // 
            // chkEnable
            // 
            this.chkEnable.Location = new System.Drawing.Point(4, 542);
            this.chkEnable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(96, 32);
            this.chkEnable.TabIndex = 231;
            this.chkEnable.Text = "使能";
            this.chkEnable.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.ContextMenuStrip = this.smsConfigUi;
            this.tabPage2.Controls.Add(this.grpLimit);
            this.tabPage2.Controls.Add(this.grpDrive);
            this.tabPage2.Controls.Add(this.grpPrim);
            this.tabPage2.Controls.Add(this.tbName);
            this.tabPage2.Controls.Add(this.lb_Name);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(283, 623);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "轴配置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grpLimit
            // 
            this.grpLimit.ContextMenuStrip = this.smsConfigUi;
            this.grpLimit.Controls.Add(this.tbLimitPosN);
            this.grpLimit.Controls.Add(this.lb_LimitVelP);
            this.grpLimit.Controls.Add(this.tbLimitVelP);
            this.grpLimit.Controls.Add(this.lb_LimitVelN);
            this.grpLimit.Controls.Add(this.tbLimitVelN);
            this.grpLimit.Controls.Add(this.lb_LimitPosP);
            this.grpLimit.Controls.Add(this.lb_LimitPosN);
            this.grpLimit.Controls.Add(this.tbLimitPosP);
            this.grpLimit.Location = new System.Drawing.Point(4, 446);
            this.grpLimit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpLimit.Name = "grpLimit";
            this.grpLimit.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpLimit.Size = new System.Drawing.Size(274, 171);
            this.grpLimit.TabIndex = 252;
            this.grpLimit.TabStop = false;
            this.grpLimit.Text = "限定";
            this.grpLimit.Visible = false;
            // 
            // tbLimitPosN
            // 
            this.tbLimitPosN.Location = new System.Drawing.Point(164, 134);
            this.tbLimitPosN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbLimitPosN.Multiline = true;
            this.tbLimitPosN.Name = "tbLimitPosN";
            this.tbLimitPosN.Size = new System.Drawing.Size(99, 24);
            this.tbLimitPosN.TabIndex = 243;
            this.tbLimitPosN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_LimitVelP
            // 
            this.lb_LimitVelP.AutoSize = true;
            this.lb_LimitVelP.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_LimitVelP.Location = new System.Drawing.Point(9, 29);
            this.lb_LimitVelP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_LimitVelP.Name = "lb_LimitVelP";
            this.lb_LimitVelP.Size = new System.Drawing.Size(145, 25);
            this.lb_LimitVelP.TabIndex = 236;
            this.lb_LimitVelP.Text = "正向速度限定：";
            // 
            // tbLimitVelP
            // 
            this.tbLimitVelP.Location = new System.Drawing.Point(164, 28);
            this.tbLimitVelP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbLimitVelP.Multiline = true;
            this.tbLimitVelP.Name = "tbLimitVelP";
            this.tbLimitVelP.Size = new System.Drawing.Size(99, 24);
            this.tbLimitVelP.TabIndex = 237;
            this.tbLimitVelP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_LimitVelN
            // 
            this.lb_LimitVelN.AutoSize = true;
            this.lb_LimitVelN.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_LimitVelN.Location = new System.Drawing.Point(9, 64);
            this.lb_LimitVelN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_LimitVelN.Name = "lb_LimitVelN";
            this.lb_LimitVelN.Size = new System.Drawing.Size(145, 25);
            this.lb_LimitVelN.TabIndex = 238;
            this.lb_LimitVelN.Text = "负向速度限定：";
            // 
            // tbLimitVelN
            // 
            this.tbLimitVelN.Location = new System.Drawing.Point(164, 62);
            this.tbLimitVelN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbLimitVelN.Multiline = true;
            this.tbLimitVelN.Name = "tbLimitVelN";
            this.tbLimitVelN.Size = new System.Drawing.Size(99, 24);
            this.tbLimitVelN.TabIndex = 239;
            this.tbLimitVelN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_LimitPosP
            // 
            this.lb_LimitPosP.AutoSize = true;
            this.lb_LimitPosP.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_LimitPosP.Location = new System.Drawing.Point(9, 100);
            this.lb_LimitPosP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_LimitPosP.Name = "lb_LimitPosP";
            this.lb_LimitPosP.Size = new System.Drawing.Size(145, 25);
            this.lb_LimitPosP.TabIndex = 240;
            this.lb_LimitPosP.Text = "正向位置限定：";
            // 
            // lb_LimitPosN
            // 
            this.lb_LimitPosN.AutoSize = true;
            this.lb_LimitPosN.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_LimitPosN.Location = new System.Drawing.Point(9, 135);
            this.lb_LimitPosN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_LimitPosN.Name = "lb_LimitPosN";
            this.lb_LimitPosN.Size = new System.Drawing.Size(145, 25);
            this.lb_LimitPosN.TabIndex = 242;
            this.lb_LimitPosN.Text = "负向位置限定：";
            // 
            // tbLimitPosP
            // 
            this.tbLimitPosP.Location = new System.Drawing.Point(164, 99);
            this.tbLimitPosP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbLimitPosP.Multiline = true;
            this.tbLimitPosP.Name = "tbLimitPosP";
            this.tbLimitPosP.Size = new System.Drawing.Size(99, 24);
            this.tbLimitPosP.TabIndex = 241;
            this.tbLimitPosP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpDrive
            // 
            this.grpDrive.ContextMenuStrip = this.smsConfigUi;
            this.grpDrive.Controls.Add(this.tbLead);
            this.grpDrive.Controls.Add(this.lb_PlsPerRoll);
            this.grpDrive.Controls.Add(this.tbPlsPerRoll);
            this.grpDrive.Controls.Add(this.lb_Lead);
            this.grpDrive.Controls.Add(this.lb_DriveType);
            this.grpDrive.Controls.Add(this.cmbDriveType);
            this.grpDrive.Controls.Add(this.lb_ControlType);
            this.grpDrive.Controls.Add(this.cmbControlType);
            this.grpDrive.Controls.Add(this.lb_FeedBackType);
            this.grpDrive.Controls.Add(this.cmbFeedBackType);
            this.grpDrive.Location = new System.Drawing.Point(4, 226);
            this.grpDrive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDrive.Name = "grpDrive";
            this.grpDrive.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDrive.Size = new System.Drawing.Size(274, 216);
            this.grpDrive.TabIndex = 251;
            this.grpDrive.TabStop = false;
            this.grpDrive.Text = "驱动";
            // 
            // tbLead
            // 
            this.tbLead.Location = new System.Drawing.Point(164, 142);
            this.tbLead.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbLead.Multiline = true;
            this.tbLead.Name = "tbLead";
            this.tbLead.Size = new System.Drawing.Size(99, 24);
            this.tbLead.TabIndex = 229;
            this.tbLead.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_PlsPerRoll
            // 
            this.lb_PlsPerRoll.AutoSize = true;
            this.lb_PlsPerRoll.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_PlsPerRoll.Location = new System.Drawing.Point(9, 180);
            this.lb_PlsPerRoll.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_PlsPerRoll.Name = "lb_PlsPerRoll";
            this.lb_PlsPerRoll.Size = new System.Drawing.Size(126, 25);
            this.lb_PlsPerRoll.TabIndex = 226;
            this.lb_PlsPerRoll.Text = "每转脉冲数：";
            // 
            // tbPlsPerRoll
            // 
            this.tbPlsPerRoll.Location = new System.Drawing.Point(164, 180);
            this.tbPlsPerRoll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPlsPerRoll.Multiline = true;
            this.tbPlsPerRoll.Name = "tbPlsPerRoll";
            this.tbPlsPerRoll.Size = new System.Drawing.Size(99, 24);
            this.tbPlsPerRoll.TabIndex = 227;
            this.tbPlsPerRoll.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_Lead
            // 
            this.lb_Lead.AutoSize = true;
            this.lb_Lead.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Lead.Location = new System.Drawing.Point(9, 141);
            this.lb_Lead.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Lead.Name = "lb_Lead";
            this.lb_Lead.Size = new System.Drawing.Size(69, 25);
            this.lb_Lead.TabIndex = 228;
            this.lb_Lead.Text = "导程：";
            // 
            // lb_DriveType
            // 
            this.lb_DriveType.AutoSize = true;
            this.lb_DriveType.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_DriveType.Location = new System.Drawing.Point(9, 22);
            this.lb_DriveType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_DriveType.Name = "lb_DriveType";
            this.lb_DriveType.Size = new System.Drawing.Size(107, 25);
            this.lb_DriveType.TabIndex = 230;
            this.lb_DriveType.Text = "驱动类型：";
            // 
            // cmbDriveType
            // 
            this.cmbDriveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDriveType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDriveType.FormattingEnabled = true;
            this.cmbDriveType.Items.AddRange(new object[] {
            "Servo",
            "Step",
            "Other"});
            this.cmbDriveType.Location = new System.Drawing.Point(164, 20);
            this.cmbDriveType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbDriveType.Name = "cmbDriveType";
            this.cmbDriveType.Size = new System.Drawing.Size(99, 25);
            this.cmbDriveType.TabIndex = 231;
            // 
            // lb_ControlType
            // 
            this.lb_ControlType.AutoSize = true;
            this.lb_ControlType.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_ControlType.Location = new System.Drawing.Point(9, 60);
            this.lb_ControlType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ControlType.Name = "lb_ControlType";
            this.lb_ControlType.Size = new System.Drawing.Size(107, 25);
            this.lb_ControlType.TabIndex = 232;
            this.lb_ControlType.Text = "控制类型：";
            // 
            // cmbControlType
            // 
            this.cmbControlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbControlType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbControlType.FormattingEnabled = true;
            this.cmbControlType.Items.AddRange(new object[] {
            "OpendLoop",
            "ClosedLoop",
            "Other"});
            this.cmbControlType.Location = new System.Drawing.Point(164, 59);
            this.cmbControlType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbControlType.Name = "cmbControlType";
            this.cmbControlType.Size = new System.Drawing.Size(99, 25);
            this.cmbControlType.TabIndex = 233;
            // 
            // lb_FeedBackType
            // 
            this.lb_FeedBackType.AutoSize = true;
            this.lb_FeedBackType.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_FeedBackType.Location = new System.Drawing.Point(9, 99);
            this.lb_FeedBackType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_FeedBackType.Name = "lb_FeedBackType";
            this.lb_FeedBackType.Size = new System.Drawing.Size(107, 25);
            this.lb_FeedBackType.TabIndex = 234;
            this.lb_FeedBackType.Text = "反馈类型：";
            // 
            // cmbFeedBackType
            // 
            this.cmbFeedBackType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFeedBackType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFeedBackType.FormattingEnabled = true;
            this.cmbFeedBackType.Items.AddRange(new object[] {
            "Incremental",
            "Absolute",
            "Other"});
            this.cmbFeedBackType.Location = new System.Drawing.Point(164, 99);
            this.cmbFeedBackType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbFeedBackType.Name = "cmbFeedBackType";
            this.cmbFeedBackType.Size = new System.Drawing.Size(99, 25);
            this.cmbFeedBackType.TabIndex = 235;
            // 
            // grpPrim
            // 
            this.grpPrim.ContextMenuStrip = this.smsConfigUi;
            this.grpPrim.Controls.Add(this.lb_VelMode);
            this.grpPrim.Controls.Add(this.cmbVelMode);
            this.grpPrim.Controls.Add(this.cmbDevName);
            this.grpPrim.Controls.Add(this.cmbByType);
            this.grpPrim.Controls.Add(this.lb_AxisId);
            this.grpPrim.Controls.Add(this.lb_ByType);
            this.grpPrim.Controls.Add(this.tbId);
            this.grpPrim.Controls.Add(this.lbDevName);
            this.grpPrim.Location = new System.Drawing.Point(4, 40);
            this.grpPrim.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpPrim.Name = "grpPrim";
            this.grpPrim.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpPrim.Size = new System.Drawing.Size(274, 179);
            this.grpPrim.TabIndex = 250;
            this.grpPrim.TabStop = false;
            this.grpPrim.Text = "基元";
            // 
            // lb_VelMode
            // 
            this.lb_VelMode.AutoSize = true;
            this.lb_VelMode.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_VelMode.Location = new System.Drawing.Point(9, 140);
            this.lb_VelMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_VelMode.Name = "lb_VelMode";
            this.lb_VelMode.Size = new System.Drawing.Size(107, 25);
            this.lb_VelMode.TabIndex = 251;
            this.lb_VelMode.Text = "速度模式：";
            // 
            // cmbVelMode
            // 
            this.cmbVelMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVelMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVelMode.FormattingEnabled = true;
            this.cmbVelMode.Items.AddRange(new object[] {
            "Velocity",
            "Time"});
            this.cmbVelMode.Location = new System.Drawing.Point(164, 140);
            this.cmbVelMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbVelMode.Name = "cmbVelMode";
            this.cmbVelMode.Size = new System.Drawing.Size(99, 25);
            this.cmbVelMode.TabIndex = 252;
            // 
            // cmbDevName
            // 
            this.cmbDevName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbDevName.FormattingEnabled = true;
            this.cmbDevName.Location = new System.Drawing.Point(139, 66);
            this.cmbDevName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbDevName.Name = "cmbDevName";
            this.cmbDevName.Size = new System.Drawing.Size(124, 25);
            this.cmbDevName.TabIndex = 250;
            this.cmbDevName.SelectedIndexChanged += new System.EventHandler(this.cbDevName_SelectedIndexChanged);
            // 
            // cmbByType
            // 
            this.cmbByType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbByType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbByType.FormattingEnabled = true;
            this.cmbByType.Items.AddRange(new object[] {
            "MotionCard"});
            this.cmbByType.Location = new System.Drawing.Point(164, 29);
            this.cmbByType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbByType.Name = "cmbByType";
            this.cmbByType.Size = new System.Drawing.Size(99, 25);
            this.cmbByType.TabIndex = 249;
            this.cmbByType.SelectedIndexChanged += new System.EventHandler(this.cmbByType_SelectedIndexChanged);
            // 
            // lb_AxisId
            // 
            this.lb_AxisId.AutoSize = true;
            this.lb_AxisId.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_AxisId.Location = new System.Drawing.Point(9, 104);
            this.lb_AxisId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_AxisId.Name = "lb_AxisId";
            this.lb_AxisId.Size = new System.Drawing.Size(54, 25);
            this.lb_AxisId.TabIndex = 224;
            this.lb_AxisId.Text = "轴Id:";
            // 
            // lb_ByType
            // 
            this.lb_ByType.AutoSize = true;
            this.lb_ByType.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_ByType.Location = new System.Drawing.Point(9, 29);
            this.lb_ByType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ByType.Name = "lb_ByType";
            this.lb_ByType.Size = new System.Drawing.Size(69, 25);
            this.lb_ByType.TabIndex = 248;
            this.lb_ByType.Text = "类型：";
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(164, 104);
            this.tbId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbId.Multiline = true;
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(99, 24);
            this.tbId.TabIndex = 225;
            this.tbId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbDevName
            // 
            this.lbDevName.AutoSize = true;
            this.lbDevName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDevName.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDevName.Location = new System.Drawing.Point(9, 65);
            this.lbDevName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDevName.Name = "lbDevName";
            this.lbDevName.Size = new System.Drawing.Size(90, 27);
            this.lbDevName.TabIndex = 244;
            this.lbDevName.Text = "基元名：";
            this.lbDevName.Click += new System.EventHandler(this.lbDevName_Click);
            this.lbDevName.DoubleClick += new System.EventHandler(this.LbDevName_DoubleClick);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(168, 8);
            this.tbName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbName.Multiline = true;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(99, 24);
            this.tbName.TabIndex = 247;
            this.tbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbName.TextChanged += new System.EventHandler(this.tBoxName_TextChanged);
            // 
            // lb_Name
            // 
            this.lb_Name.AutoSize = true;
            this.lb_Name.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Name.Location = new System.Drawing.Point(12, 8);
            this.lb_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(69, 25);
            this.lb_Name.TabIndex = 246;
            this.lb_Name.Text = "名称：";
            // 
            // SingleAxisConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grpAxisName);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SingleAxisConfigControl";
            this.Size = new System.Drawing.Size(299, 683);
            this.grpAxisName.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.smsConfigUi.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.grpLimit.ResumeLayout(false);
            this.grpLimit.PerformLayout();
            this.grpDrive.ResumeLayout(false);
            this.grpDrive.PerformLayout();
            this.grpPrim.ResumeLayout(false);
            this.grpPrim.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox grpAxisName;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox groupBox1;
        private Label lb_DefaultStartVel;
        private TextBox tbDefaultStartVel;
        private Label lb_DefaultMaxVel;
        private TextBox tbDefaultMaxVel;
        private Label lb_DefaultStopVel;
        private TextBox tbDefaultStopVel;
        private Label lbDefaultAcc;
        private TextBox tbErrChkRange;
        private TextBox tbDefaultAcc;
        private Label lbDefaultDec;
        private TextBox tbDefaultDec;
        private TextBox tbHomeMode;
        private Label lb_HomeMode;
        private TextBox tbHomeVel;
        private Label lb_HomeVel;
        private TextBox tbHomeAcc;
        private Label lb_HomeAcc;
        private TextBox tbSafeIndex;
        private Label lb_SafeIndex;
        private TextBox tbSafePos;
        private Label lb_SafePos;
        private TextBox tbHomeIndex;
        private Label lb_HomeIndex;
        private CheckBox chkSimulate;
        private CheckBox chkEnable;
        private TabPage tabPage2;
        private TextBox tbName;
        private Label lb_Name;
        private Label lbDevName;
        private TextBox tbLimitPosN;
        private Label lb_LimitPosN;
        private TextBox tbLimitPosP;
        private Label lb_LimitPosP;
        private TextBox tbLimitVelN;
        private Label lb_LimitVelN;
        private TextBox tbLimitVelP;
        private Label lb_LimitVelP;
        private ComboBox cmbFeedBackType;
        private Label lb_FeedBackType;
        private ComboBox cmbControlType;
        private Label lb_ControlType;
        private ComboBox cmbDriveType;
        private Label lb_DriveType;
        private TextBox tbLead;
        private Label lb_Lead;
        private TextBox tbPlsPerRoll;
        private Label lb_PlsPerRoll;
        private TextBox tbId;
        private Label lb_AxisId;
        private GroupBox groupBox2;
        private GroupBox grpLimit;
        private GroupBox grpDrive;
        private GroupBox grpPrim;
        private ComboBox cmbByType;
        private Label lb_ByType;
        private ContextMenuStrip smsConfigUi;
        private ToolStripMenuItem mnutConfigUiSelected;
        private ComboBox cmbDevName;
        private Label lb_VelMode;
        private ComboBox cmbVelMode;
        private CheckBox chkErrChkEnable;
        private TextBox tbHomeVo;
        private Label lb_HomeVo;
    }
}
