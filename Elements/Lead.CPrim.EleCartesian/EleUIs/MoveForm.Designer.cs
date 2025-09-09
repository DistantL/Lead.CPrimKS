using System.ComponentModel;
using System.Windows.Forms;

namespace Lead.CPrim.EleCartesian
{
    partial class MoveForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbJumpHeight = new System.Windows.Forms.ComboBox();
            this.btnStopMove = new System.Windows.Forms.Button();
            this.btnStartMove = new System.Windows.Forms.Button();
            this.lbW = new System.Windows.Forms.Label();
            this.lbV = new System.Windows.Forms.Label();
            this.lbU = new System.Windows.Forms.Label();
            this.lbZ = new System.Windows.Forms.Label();
            this.lbY = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbX = new System.Windows.Forms.Label();
            this.chkCheckLimit = new System.Windows.Forms.CheckBox();
            this.chkEnableW = new System.Windows.Forms.CheckBox();
            this.chkEnableV = new System.Windows.Forms.CheckBox();
            this.chkEnableU = new System.Windows.Forms.CheckBox();
            this.chkEnableZ = new System.Windows.Forms.CheckBox();
            this.chkEnableY = new System.Windows.Forms.CheckBox();
            this.chkEnableX = new System.Windows.Forms.CheckBox();
            this.tbCurPosW = new System.Windows.Forms.TextBox();
            this.tbMovePosW = new System.Windows.Forms.TextBox();
            this.tbCurPosV = new System.Windows.Forms.TextBox();
            this.tbMovePosV = new System.Windows.Forms.TextBox();
            this.tbCurPosU = new System.Windows.Forms.TextBox();
            this.tbMovePosU = new System.Windows.Forms.TextBox();
            this.tbCurPosZ = new System.Windows.Forms.TextBox();
            this.tbMovePosZ = new System.Windows.Forms.TextBox();
            this.tbCurPosY = new System.Windows.Forms.TextBox();
            this.tbMovePosY = new System.Windows.Forms.TextBox();
            this.tbCurPosX = new System.Windows.Forms.TextBox();
            this.tbMovePosX = new System.Windows.Forms.TextBox();
            this.cmbMovePos = new System.Windows.Forms.ComboBox();
            this.tmrCycle = new System.Windows.Forms.Timer(this.components);
            this.cmbMoveMode = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbJumpHeight
            // 
            this.cmbJumpHeight.FormattingEnabled = true;
            this.cmbJumpHeight.Location = new System.Drawing.Point(635, 74);
            this.cmbJumpHeight.Name = "cmbJumpHeight";
            this.cmbJumpHeight.Size = new System.Drawing.Size(91, 20);
            this.cmbJumpHeight.TabIndex = 39;
            // 
            // btnStopMove
            // 
            this.btnStopMove.Location = new System.Drawing.Point(404, 126);
            this.btnStopMove.Name = "btnStopMove";
            this.btnStopMove.Size = new System.Drawing.Size(75, 23);
            this.btnStopMove.TabIndex = 38;
            this.btnStopMove.Text = "停止";
            this.btnStopMove.UseVisualStyleBackColor = true;
            this.btnStopMove.Click += new System.EventHandler(this.BtnMoveStop_Click);
            // 
            // btnStartMove
            // 
            this.btnStartMove.Location = new System.Drawing.Point(250, 126);
            this.btnStartMove.Name = "btnStartMove";
            this.btnStartMove.Size = new System.Drawing.Size(75, 23);
            this.btnStartMove.TabIndex = 37;
            this.btnStartMove.Text = "开始";
            this.btnStartMove.UseVisualStyleBackColor = true;
            this.btnStartMove.Click += new System.EventHandler(this.BtnMoveStart_Click);
            // 
            // lbW
            // 
            this.lbW.Location = new System.Drawing.Point(572, 10);
            this.lbW.Name = "lbW";
            this.lbW.Size = new System.Drawing.Size(50, 14);
            this.lbW.TabIndex = 26;
            this.lbW.Text = "W";
            this.lbW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbV
            // 
            this.lbV.Location = new System.Drawing.Point(491, 10);
            this.lbV.Name = "lbV";
            this.lbV.Size = new System.Drawing.Size(50, 14);
            this.lbV.TabIndex = 27;
            this.lbV.Text = "V";
            this.lbV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbU
            // 
            this.lbU.Location = new System.Drawing.Point(416, 10);
            this.lbU.Name = "lbU";
            this.lbU.Size = new System.Drawing.Size(50, 14);
            this.lbU.TabIndex = 28;
            this.lbU.Text = "U";
            this.lbU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbZ
            // 
            this.lbZ.Location = new System.Drawing.Point(339, 10);
            this.lbZ.Name = "lbZ";
            this.lbZ.Size = new System.Drawing.Size(50, 14);
            this.lbZ.TabIndex = 30;
            this.lbZ.Text = "Z";
            this.lbZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbY
            // 
            this.lbY.Location = new System.Drawing.Point(263, 10);
            this.lbY.Name = "lbY";
            this.lbY.Size = new System.Drawing.Size(50, 14);
            this.lbY.TabIndex = 29;
            this.lbY.Text = "Y";
            this.lbY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(653, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 36;
            this.label11.Text = "限位检查";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(653, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 31;
            this.label9.Text = "Z缩回高度";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(114, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 33;
            this.label8.Text = "当前位置";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 34;
            this.label7.Text = "点位";
            // 
            // lbX
            // 
            this.lbX.Location = new System.Drawing.Point(184, 10);
            this.lbX.Name = "lbX";
            this.lbX.Size = new System.Drawing.Size(50, 14);
            this.lbX.TabIndex = 35;
            this.lbX.Text = "X";
            this.lbX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkCheckLimit
            // 
            this.chkCheckLimit.AutoSize = true;
            this.chkCheckLimit.Location = new System.Drawing.Point(668, 27);
            this.chkCheckLimit.Name = "chkCheckLimit";
            this.chkCheckLimit.Size = new System.Drawing.Size(15, 14);
            this.chkCheckLimit.TabIndex = 24;
            this.chkCheckLimit.UseVisualStyleBackColor = true;
            // 
            // chkEnableW
            // 
            this.chkEnableW.AutoSize = true;
            this.chkEnableW.Location = new System.Drawing.Point(590, 27);
            this.chkEnableW.Name = "chkEnableW";
            this.chkEnableW.Size = new System.Drawing.Size(15, 14);
            this.chkEnableW.TabIndex = 25;
            this.chkEnableW.UseVisualStyleBackColor = true;
            // 
            // chkEnableV
            // 
            this.chkEnableV.AutoSize = true;
            this.chkEnableV.Location = new System.Drawing.Point(509, 27);
            this.chkEnableV.Name = "chkEnableV";
            this.chkEnableV.Size = new System.Drawing.Size(15, 14);
            this.chkEnableV.TabIndex = 23;
            this.chkEnableV.UseVisualStyleBackColor = true;
            // 
            // chkEnableU
            // 
            this.chkEnableU.AutoSize = true;
            this.chkEnableU.Location = new System.Drawing.Point(435, 27);
            this.chkEnableU.Name = "chkEnableU";
            this.chkEnableU.Size = new System.Drawing.Size(15, 14);
            this.chkEnableU.TabIndex = 19;
            this.chkEnableU.UseVisualStyleBackColor = true;
            // 
            // chkEnableZ
            // 
            this.chkEnableZ.AutoSize = true;
            this.chkEnableZ.Location = new System.Drawing.Point(358, 27);
            this.chkEnableZ.Name = "chkEnableZ";
            this.chkEnableZ.Size = new System.Drawing.Size(15, 14);
            this.chkEnableZ.TabIndex = 22;
            this.chkEnableZ.UseVisualStyleBackColor = true;
            // 
            // chkEnableY
            // 
            this.chkEnableY.AutoSize = true;
            this.chkEnableY.Location = new System.Drawing.Point(280, 27);
            this.chkEnableY.Name = "chkEnableY";
            this.chkEnableY.Size = new System.Drawing.Size(15, 14);
            this.chkEnableY.TabIndex = 21;
            this.chkEnableY.UseVisualStyleBackColor = true;
            // 
            // chkEnableX
            // 
            this.chkEnableX.AutoSize = true;
            this.chkEnableX.Location = new System.Drawing.Point(201, 27);
            this.chkEnableX.Name = "chkEnableX";
            this.chkEnableX.Size = new System.Drawing.Size(15, 14);
            this.chkEnableX.TabIndex = 20;
            this.chkEnableX.UseVisualStyleBackColor = true;
            // 
            // tbCurPosW
            // 
            this.tbCurPosW.Location = new System.Drawing.Point(558, 47);
            this.tbCurPosW.Name = "tbCurPosW";
            this.tbCurPosW.ReadOnly = true;
            this.tbCurPosW.Size = new System.Drawing.Size(71, 21);
            this.tbCurPosW.TabIndex = 7;
            // 
            // tbMovePosW
            // 
            this.tbMovePosW.Location = new System.Drawing.Point(558, 74);
            this.tbMovePosW.Name = "tbMovePosW";
            this.tbMovePosW.Size = new System.Drawing.Size(71, 21);
            this.tbMovePosW.TabIndex = 8;
            // 
            // tbCurPosV
            // 
            this.tbCurPosV.Location = new System.Drawing.Point(482, 47);
            this.tbCurPosV.Name = "tbCurPosV";
            this.tbCurPosV.ReadOnly = true;
            this.tbCurPosV.Size = new System.Drawing.Size(71, 21);
            this.tbCurPosV.TabIndex = 9;
            // 
            // tbMovePosV
            // 
            this.tbMovePosV.Location = new System.Drawing.Point(482, 74);
            this.tbMovePosV.Name = "tbMovePosV";
            this.tbMovePosV.Size = new System.Drawing.Size(71, 21);
            this.tbMovePosV.TabIndex = 12;
            // 
            // tbCurPosU
            // 
            this.tbCurPosU.Location = new System.Drawing.Point(404, 47);
            this.tbCurPosU.Name = "tbCurPosU";
            this.tbCurPosU.ReadOnly = true;
            this.tbCurPosU.Size = new System.Drawing.Size(71, 21);
            this.tbCurPosU.TabIndex = 10;
            // 
            // tbMovePosU
            // 
            this.tbMovePosU.Location = new System.Drawing.Point(404, 74);
            this.tbMovePosU.Name = "tbMovePosU";
            this.tbMovePosU.Size = new System.Drawing.Size(71, 21);
            this.tbMovePosU.TabIndex = 11;
            // 
            // tbCurPosZ
            // 
            this.tbCurPosZ.Location = new System.Drawing.Point(327, 47);
            this.tbCurPosZ.Name = "tbCurPosZ";
            this.tbCurPosZ.ReadOnly = true;
            this.tbCurPosZ.Size = new System.Drawing.Size(71, 21);
            this.tbCurPosZ.TabIndex = 17;
            // 
            // tbMovePosZ
            // 
            this.tbMovePosZ.Location = new System.Drawing.Point(327, 74);
            this.tbMovePosZ.Name = "tbMovePosZ";
            this.tbMovePosZ.Size = new System.Drawing.Size(71, 21);
            this.tbMovePosZ.TabIndex = 13;
            // 
            // tbCurPosY
            // 
            this.tbCurPosY.Location = new System.Drawing.Point(250, 47);
            this.tbCurPosY.Name = "tbCurPosY";
            this.tbCurPosY.ReadOnly = true;
            this.tbCurPosY.Size = new System.Drawing.Size(71, 21);
            this.tbCurPosY.TabIndex = 14;
            // 
            // tbMovePosY
            // 
            this.tbMovePosY.Location = new System.Drawing.Point(250, 74);
            this.tbMovePosY.Name = "tbMovePosY";
            this.tbMovePosY.Size = new System.Drawing.Size(71, 21);
            this.tbMovePosY.TabIndex = 15;
            // 
            // tbCurPosX
            // 
            this.tbCurPosX.Location = new System.Drawing.Point(173, 47);
            this.tbCurPosX.Name = "tbCurPosX";
            this.tbCurPosX.ReadOnly = true;
            this.tbCurPosX.Size = new System.Drawing.Size(71, 21);
            this.tbCurPosX.TabIndex = 16;
            // 
            // tbMovePosX
            // 
            this.tbMovePosX.Location = new System.Drawing.Point(173, 74);
            this.tbMovePosX.Name = "tbMovePosX";
            this.tbMovePosX.Size = new System.Drawing.Size(71, 21);
            this.tbMovePosX.TabIndex = 18;
            // 
            // cmbMovePos
            // 
            this.cmbMovePos.FormattingEnabled = true;
            this.cmbMovePos.Location = new System.Drawing.Point(46, 75);
            this.cmbMovePos.Name = "cmbMovePos";
            this.cmbMovePos.Size = new System.Drawing.Size(121, 20);
            this.cmbMovePos.TabIndex = 6;
            this.cmbMovePos.SelectedIndexChanged += new System.EventHandler(this.CmbPos_SelectedIndexChanged);
            // 
            // tmrCycle
            // 
            this.tmrCycle.Tick += new System.EventHandler(this.TmrCycle_Tick);
            // 
            // cmbMoveMode
            // 
            this.cmbMoveMode.FormattingEnabled = true;
            this.cmbMoveMode.Location = new System.Drawing.Point(46, 22);
            this.cmbMoveMode.Name = "cmbMoveMode";
            this.cmbMoveMode.Size = new System.Drawing.Size(121, 20);
            this.cmbMoveMode.TabIndex = 41;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 40;
            this.label10.Text = "模式";
            // 
            // MoveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 158);
            this.Controls.Add(this.cmbMoveMode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbJumpHeight);
            this.Controls.Add(this.btnStopMove);
            this.Controls.Add(this.btnStartMove);
            this.Controls.Add(this.lbW);
            this.Controls.Add(this.lbV);
            this.Controls.Add(this.lbU);
            this.Controls.Add(this.lbZ);
            this.Controls.Add(this.lbY);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbX);
            this.Controls.Add(this.chkCheckLimit);
            this.Controls.Add(this.chkEnableW);
            this.Controls.Add(this.chkEnableV);
            this.Controls.Add(this.chkEnableU);
            this.Controls.Add(this.chkEnableZ);
            this.Controls.Add(this.chkEnableY);
            this.Controls.Add(this.chkEnableX);
            this.Controls.Add(this.tbCurPosW);
            this.Controls.Add(this.tbMovePosW);
            this.Controls.Add(this.tbCurPosV);
            this.Controls.Add(this.tbMovePosV);
            this.Controls.Add(this.tbCurPosU);
            this.Controls.Add(this.tbMovePosU);
            this.Controls.Add(this.tbCurPosZ);
            this.Controls.Add(this.tbMovePosZ);
            this.Controls.Add(this.tbCurPosY);
            this.Controls.Add(this.tbMovePosY);
            this.Controls.Add(this.tbCurPosX);
            this.Controls.Add(this.tbMovePosX);
            this.Controls.Add(this.cmbMovePos);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MoveForm";
            this.Text = "移动测试";
            this.Load += new System.EventHandler(this.MoveForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComboBox cmbJumpHeight;
        private Button btnStopMove;
        private Button btnStartMove;
        private Label lbW;
        private Label lbV;
        private Label lbU;
        private Label lbZ;
        private Label lbY;
        private Label label11;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label lbX;
        private CheckBox chkCheckLimit;
        private CheckBox chkEnableW;
        private CheckBox chkEnableV;
        private CheckBox chkEnableU;
        private CheckBox chkEnableZ;
        private CheckBox chkEnableY;
        private CheckBox chkEnableX;
        private TextBox tbCurPosW;
        private TextBox tbMovePosW;
        private TextBox tbCurPosV;
        private TextBox tbMovePosV;
        private TextBox tbCurPosU;
        private TextBox tbMovePosU;
        private TextBox tbCurPosZ;
        private TextBox tbMovePosZ;
        private TextBox tbCurPosY;
        private TextBox tbMovePosY;
        private TextBox tbCurPosX;
        private TextBox tbMovePosX;
        private ComboBox cmbMovePos;
        private Timer tmrCycle;
        private ComboBox cmbMoveMode;
        private Label label10;
    }
}