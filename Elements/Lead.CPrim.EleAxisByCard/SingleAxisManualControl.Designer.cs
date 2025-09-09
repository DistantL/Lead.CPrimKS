
namespace Lead.CPrim.EleAxisByCard
{
    partial class SingleAxisManualControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingleAxisManualControl));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnServoOn = new System.Windows.Forms.Button();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.labelSpeedSet = new System.Windows.Forms.Label();
            this.lb_Alarm = new System.Windows.Forms.Label();
            this.lb_N = new System.Windows.Forms.Label();
            this.lb_O = new System.Windows.Forms.Label();
            this.lb_P = new System.Windows.Forms.Label();
            this.lblALM = new System.Windows.Forms.Button();
            this.lblMEL = new System.Windows.Forms.Button();
            this.lblORG = new System.Windows.Forms.Button();
            this.lblPEL = new System.Windows.Forms.Button();
            this.labelPos = new System.Windows.Forms.Label();
            this.labelPosSet = new System.Windows.Forms.Label();
            this.btnJogMinus = new System.Windows.Forms.Button();
            this.btnJogPlus = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnMoveRel = new System.Windows.Forms.Button();
            this.btnMoveAbs = new System.Windows.Forms.Button();
            this.txtTargetPosition = new System.Windows.Forms.TextBox();
            this.lblActualPos = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.smsConfigUi = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnutConfigUiSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain.SuspendLayout();
            this.smsConfigUi.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnServoOn);
            this.pnlMain.Controls.Add(this.txtSpeed);
            this.pnlMain.Controls.Add(this.labelSpeedSet);
            this.pnlMain.Controls.Add(this.lb_Alarm);
            this.pnlMain.Controls.Add(this.lb_N);
            this.pnlMain.Controls.Add(this.lb_O);
            this.pnlMain.Controls.Add(this.lb_P);
            this.pnlMain.Controls.Add(this.lblALM);
            this.pnlMain.Controls.Add(this.lblMEL);
            this.pnlMain.Controls.Add(this.lblORG);
            this.pnlMain.Controls.Add(this.lblPEL);
            this.pnlMain.Controls.Add(this.labelPos);
            this.pnlMain.Controls.Add(this.labelPosSet);
            this.pnlMain.Controls.Add(this.btnJogMinus);
            this.pnlMain.Controls.Add(this.btnJogPlus);
            this.pnlMain.Controls.Add(this.btnHome);
            this.pnlMain.Controls.Add(this.btnStop);
            this.pnlMain.Controls.Add(this.btnMoveRel);
            this.pnlMain.Controls.Add(this.btnMoveAbs);
            this.pnlMain.Controls.Add(this.txtTargetPosition);
            this.pnlMain.Controls.Add(this.lblActualPos);
            this.pnlMain.Controls.Add(this.lblName);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(920, 50);
            this.pnlMain.TabIndex = 0;
            // 
            // btnServoOn
            // 
            this.btnServoOn.BackColor = System.Drawing.Color.Lavender;
            this.btnServoOn.Location = new System.Drawing.Point(60, 12);
            this.btnServoOn.Name = "btnServoOn";
            this.btnServoOn.Size = new System.Drawing.Size(66, 28);
            this.btnServoOn.TabIndex = 145;
            this.btnServoOn.Text = "使能";
            this.btnServoOn.UseVisualStyleBackColor = false;
            this.btnServoOn.Click += new System.EventHandler(this.btnServoOn_Click);
            // 
            // txtSpeed
            // 
            this.txtSpeed.Location = new System.Drawing.Point(323, 23);
            this.txtSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(70, 21);
            this.txtSpeed.TabIndex = 135;
            this.txtSpeed.Text = "10";
            this.txtSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelSpeedSet
            // 
            this.labelSpeedSet.AutoSize = true;
            this.labelSpeedSet.Location = new System.Drawing.Point(344, 6);
            this.labelSpeedSet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSpeedSet.Name = "labelSpeedSet";
            this.labelSpeedSet.Size = new System.Drawing.Size(29, 12);
            this.labelSpeedSet.TabIndex = 134;
            this.labelSpeedSet.Text = "速度";
            // 
            // lb_Alarm
            // 
            this.lb_Alarm.AutoSize = true;
            this.lb_Alarm.Location = new System.Drawing.Point(887, 6);
            this.lb_Alarm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Alarm.Name = "lb_Alarm";
            this.lb_Alarm.Size = new System.Drawing.Size(29, 12);
            this.lb_Alarm.TabIndex = 133;
            this.lb_Alarm.Text = "报警";
            // 
            // lb_N
            // 
            this.lb_N.AutoSize = true;
            this.lb_N.Location = new System.Drawing.Point(852, 6);
            this.lb_N.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_N.Name = "lb_N";
            this.lb_N.Size = new System.Drawing.Size(29, 12);
            this.lb_N.TabIndex = 132;
            this.lb_N.Text = "负限";
            // 
            // lb_O
            // 
            this.lb_O.AutoSize = true;
            this.lb_O.Location = new System.Drawing.Point(817, 6);
            this.lb_O.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_O.Name = "lb_O";
            this.lb_O.Size = new System.Drawing.Size(29, 12);
            this.lb_O.TabIndex = 131;
            this.lb_O.Text = "原点";
            // 
            // lb_P
            // 
            this.lb_P.AutoSize = true;
            this.lb_P.Location = new System.Drawing.Point(782, 6);
            this.lb_P.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_P.Name = "lb_P";
            this.lb_P.Size = new System.Drawing.Size(29, 12);
            this.lb_P.TabIndex = 130;
            this.lb_P.Text = "正限";
            // 
            // lblALM
            // 
            this.lblALM.Location = new System.Drawing.Point(893, 28);
            this.lblALM.Margin = new System.Windows.Forms.Padding(2);
            this.lblALM.Name = "lblALM";
            this.lblALM.Size = new System.Drawing.Size(16, 16);
            this.lblALM.TabIndex = 129;
            this.lblALM.UseVisualStyleBackColor = true;
            this.lblALM.Click += new System.EventHandler(this.lblALM_Click);
            // 
            // lblMEL
            // 
            this.lblMEL.Location = new System.Drawing.Point(858, 28);
            this.lblMEL.Margin = new System.Windows.Forms.Padding(2);
            this.lblMEL.Name = "lblMEL";
            this.lblMEL.Size = new System.Drawing.Size(16, 16);
            this.lblMEL.TabIndex = 128;
            this.lblMEL.UseVisualStyleBackColor = true;
            // 
            // lblORG
            // 
            this.lblORG.Location = new System.Drawing.Point(823, 28);
            this.lblORG.Margin = new System.Windows.Forms.Padding(2);
            this.lblORG.Name = "lblORG";
            this.lblORG.Size = new System.Drawing.Size(16, 16);
            this.lblORG.TabIndex = 127;
            this.lblORG.UseVisualStyleBackColor = true;
            // 
            // lblPEL
            // 
            this.lblPEL.Location = new System.Drawing.Point(788, 28);
            this.lblPEL.Margin = new System.Windows.Forms.Padding(2);
            this.lblPEL.Name = "lblPEL";
            this.lblPEL.Size = new System.Drawing.Size(16, 16);
            this.lblPEL.TabIndex = 126;
            this.lblPEL.UseVisualStyleBackColor = true;
            // 
            // labelPos
            // 
            this.labelPos.Location = new System.Drawing.Point(136, 6);
            this.labelPos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPos.Name = "labelPos";
            this.labelPos.Size = new System.Drawing.Size(70, 18);
            this.labelPos.TabIndex = 123;
            this.labelPos.Text = "编码器位置";
            this.labelPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPosSet
            // 
            this.labelPosSet.AutoSize = true;
            this.labelPosSet.Location = new System.Drawing.Point(409, 6);
            this.labelPosSet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPosSet.Name = "labelPosSet";
            this.labelPosSet.Size = new System.Drawing.Size(53, 12);
            this.labelPosSet.TabIndex = 122;
            this.labelPosSet.Text = "目标位置";
            // 
            // btnJogMinus
            // 
            this.btnJogMinus.Image = ((System.Drawing.Image)(resources.GetObject("btnJogMinus.Image")));
            this.btnJogMinus.Location = new System.Drawing.Point(270, 7);
            this.btnJogMinus.Margin = new System.Windows.Forms.Padding(2);
            this.btnJogMinus.Name = "btnJogMinus";
            this.btnJogMinus.Size = new System.Drawing.Size(38, 38);
            this.btnJogMinus.TabIndex = 121;
            this.btnJogMinus.UseVisualStyleBackColor = true;
            this.btnJogMinus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogMinus_MouseDown);
            this.btnJogMinus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogMinus_MouseUp);
            // 
            // btnJogPlus
            // 
            this.btnJogPlus.Image = ((System.Drawing.Image)(resources.GetObject("btnJogPlus.Image")));
            this.btnJogPlus.Location = new System.Drawing.Point(219, 7);
            this.btnJogPlus.Margin = new System.Windows.Forms.Padding(2);
            this.btnJogPlus.Name = "btnJogPlus";
            this.btnJogPlus.Size = new System.Drawing.Size(38, 38);
            this.btnJogPlus.TabIndex = 120;
            this.btnJogPlus.UseVisualStyleBackColor = true;
            this.btnJogPlus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogPlus_MouseDown);
            this.btnJogPlus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogPlus_MouseUp);
            // 
            // btnHome
            // 
            this.btnHome.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHome.Location = new System.Drawing.Point(710, 12);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(65, 28);
            this.btnHome.TabIndex = 119;
            this.btnHome.Text = "回零";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(635, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(65, 28);
            this.btnStop.TabIndex = 118;
            this.btnStop.Text = "立即停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnMoveRel
            // 
            this.btnMoveRel.Location = new System.Drawing.Point(560, 12);
            this.btnMoveRel.Margin = new System.Windows.Forms.Padding(2);
            this.btnMoveRel.Name = "btnMoveRel";
            this.btnMoveRel.Size = new System.Drawing.Size(65, 28);
            this.btnMoveRel.TabIndex = 117;
            this.btnMoveRel.Text = "相对运动";
            this.btnMoveRel.UseVisualStyleBackColor = true;
            this.btnMoveRel.Click += new System.EventHandler(this.btnMoveRel_Click);
            // 
            // btnMoveAbs
            // 
            this.btnMoveAbs.Location = new System.Drawing.Point(485, 12);
            this.btnMoveAbs.Margin = new System.Windows.Forms.Padding(2);
            this.btnMoveAbs.Name = "btnMoveAbs";
            this.btnMoveAbs.Size = new System.Drawing.Size(65, 28);
            this.btnMoveAbs.TabIndex = 116;
            this.btnMoveAbs.Text = "绝对运动";
            this.btnMoveAbs.UseVisualStyleBackColor = true;
            this.btnMoveAbs.Click += new System.EventHandler(this.btnMoveAbs_Click);
            // 
            // txtTargetPosition
            // 
            this.txtTargetPosition.Location = new System.Drawing.Point(400, 23);
            this.txtTargetPosition.Margin = new System.Windows.Forms.Padding(2);
            this.txtTargetPosition.Name = "txtTargetPosition";
            this.txtTargetPosition.Size = new System.Drawing.Size(70, 21);
            this.txtTargetPosition.TabIndex = 115;
            this.txtTargetPosition.Text = "10";
            this.txtTargetPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblActualPos
            // 
            this.lblActualPos.Location = new System.Drawing.Point(136, 26);
            this.lblActualPos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblActualPos.Name = "lblActualPos";
            this.lblActualPos.Size = new System.Drawing.Size(70, 18);
            this.lblActualPos.TabIndex = 114;
            this.lblActualPos.Text = "位置";
            this.lblActualPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 19);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 12);
            this.lblName.TabIndex = 112;
            this.lblName.Text = "Axis_X";
            // 
            // smsConfigUi
            // 
            this.smsConfigUi.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.smsConfigUi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnutConfigUiSelected});
            this.smsConfigUi.Name = "smsConfigUi";
            this.smsConfigUi.Size = new System.Drawing.Size(101, 26);
            // 
            // mnutConfigUiSelected
            // 
            this.mnutConfigUiSelected.Name = "mnutConfigUiSelected";
            this.mnutConfigUiSelected.Size = new System.Drawing.Size(100, 22);
            this.mnutConfigUiSelected.Text = "选择";
            this.mnutConfigUiSelected.Click += new System.EventHandler(this.mnutConfigUiSelected_Click);
            // 
            // SingleAxisManualControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pnlMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(1000, 50);
            this.Name = "SingleAxisManualControl";
            this.Size = new System.Drawing.Size(920, 50);
            this.Load += new System.EventHandler(this.SingleAxisStatusControl_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.smsConfigUi.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.Label labelSpeedSet;
        private System.Windows.Forms.Label lb_Alarm;
        private System.Windows.Forms.Label lb_N;
        private System.Windows.Forms.Label lb_O;
        private System.Windows.Forms.Label lb_P;
        private System.Windows.Forms.Button lblALM;
        private System.Windows.Forms.Button lblMEL;
        private System.Windows.Forms.Button lblORG;
        private System.Windows.Forms.Button lblPEL;
        private System.Windows.Forms.Label labelPos;
        private System.Windows.Forms.Label labelPosSet;
        private System.Windows.Forms.Button btnJogMinus;
        private System.Windows.Forms.Button btnJogPlus;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnMoveRel;
        private System.Windows.Forms.Button btnMoveAbs;
        private System.Windows.Forms.TextBox txtTargetPosition;
        private System.Windows.Forms.Label lblActualPos;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ContextMenuStrip smsConfigUi;
        private System.Windows.Forms.ToolStripMenuItem mnutConfigUiSelected;
        private System.Windows.Forms.Button btnServoOn;
    }
}
