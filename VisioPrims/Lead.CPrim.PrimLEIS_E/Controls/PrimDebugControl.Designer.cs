namespace Lead.CPrim.PrimLEIS_E
{
    partial class PrimDebugControl
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label123 = new System.Windows.Forms.Label();
            this.tBoxLESIName = new System.Windows.Forms.TextBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnStop1 = new System.Windows.Forms.Button();
            this.btnRun1 = new System.Windows.Forms.Button();
            this.tBoxConnState = new System.Windows.Forms.TextBox();
            this.tBoxRunState = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbTitle = new System.Windows.Forms.Label();
            this.tmrUpdateUI = new System.Windows.Forms.Timer(this.components);
            this.groupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "param.ini";
            // 
            // label123
            // 
            this.label123.BackColor = System.Drawing.Color.SkyBlue;
            this.label123.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label123.Dock = System.Windows.Forms.DockStyle.Left;
            this.label123.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label123.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label123.Location = new System.Drawing.Point(0, 0);
            this.label123.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(134, 26);
            this.label123.TabIndex = 12;
            this.label123.Text = "LESIName";
            this.label123.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBoxLESIName
            // 
            this.tBoxLESIName.BackColor = System.Drawing.Color.OldLace;
            this.tBoxLESIName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBoxLESIName.Location = new System.Drawing.Point(135, 2);
            this.tBoxLESIName.Margin = new System.Windows.Forms.Padding(2);
            this.tBoxLESIName.Multiline = true;
            this.tBoxLESIName.Name = "tBoxLESIName";
            this.tBoxLESIName.Size = new System.Drawing.Size(142, 25);
            this.tBoxLESIName.TabIndex = 13;
            this.tBoxLESIName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.btnInit);
            this.groupBox.Controls.Add(this.btnStop1);
            this.groupBox.Controls.Add(this.btnRun1);
            this.groupBox.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox.Location = new System.Drawing.Point(597, 32);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(183, 66);
            this.groupBox.TabIndex = 131;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "EXE";
            // 
            // btnInit
            // 
            this.btnInit.BackColor = System.Drawing.Color.SkyBlue;
            this.btnInit.Location = new System.Drawing.Point(4, 28);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(50, 32);
            this.btnInit.TabIndex = 107;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = false;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnStop1
            // 
            this.btnStop1.BackColor = System.Drawing.Color.SandyBrown;
            this.btnStop1.Location = new System.Drawing.Point(116, 28);
            this.btnStop1.Name = "btnStop1";
            this.btnStop1.Size = new System.Drawing.Size(50, 32);
            this.btnStop1.TabIndex = 105;
            this.btnStop1.Text = "Stop";
            this.btnStop1.UseVisualStyleBackColor = false;
            this.btnStop1.Click += new System.EventHandler(this.btnStop1_Click);
            // 
            // btnRun1
            // 
            this.btnRun1.BackColor = System.Drawing.Color.LightGreen;
            this.btnRun1.Location = new System.Drawing.Point(61, 28);
            this.btnRun1.Name = "btnRun1";
            this.btnRun1.Size = new System.Drawing.Size(50, 32);
            this.btnRun1.TabIndex = 105;
            this.btnRun1.Text = "Run";
            this.btnRun1.UseVisualStyleBackColor = false;
            this.btnRun1.Click += new System.EventHandler(this.btnRun1_Click);
            // 
            // tBoxConnState
            // 
            this.tBoxConnState.BackColor = System.Drawing.Color.Khaki;
            this.tBoxConnState.Dock = System.Windows.Forms.DockStyle.Right;
            this.tBoxConnState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBoxConnState.Location = new System.Drawing.Point(566, 0);
            this.tBoxConnState.Margin = new System.Windows.Forms.Padding(2);
            this.tBoxConnState.Multiline = true;
            this.tBoxConnState.Name = "tBoxConnState";
            this.tBoxConnState.Size = new System.Drawing.Size(142, 26);
            this.tBoxConnState.TabIndex = 15;
            this.tBoxConnState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBoxRunState
            // 
            this.tBoxRunState.BackColor = System.Drawing.Color.Khaki;
            this.tBoxRunState.Dock = System.Windows.Forms.DockStyle.Right;
            this.tBoxRunState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBoxRunState.Location = new System.Drawing.Point(708, 0);
            this.tBoxRunState.Margin = new System.Windows.Forms.Padding(2);
            this.tBoxRunState.Multiline = true;
            this.tBoxRunState.Name = "tBoxRunState";
            this.tBoxRunState.Size = new System.Drawing.Size(142, 26);
            this.tBoxRunState.TabIndex = 14;
            this.tBoxRunState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tBoxConnState);
            this.panel1.Controls.Add(this.tBoxRunState);
            this.panel1.Controls.Add(this.label123);
            this.panel1.Controls.Add(this.tBoxLESIName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 26);
            this.panel1.TabIndex = 29;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(850, 435);
            this.splitContainer1.SplitterDistance = 100;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 5;
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lbTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(850, 27);
            this.lbTitle.TabIndex = 4;
            this.lbTitle.Text = "LESI Config";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrUpdateUI
            // 
            this.tmrUpdateUI.Interval = 50;
            // 
            // PrimDebugControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lbTitle);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PrimDebugControl";
            this.Size = new System.Drawing.Size(850, 462);
            this.Load += new System.EventHandler(this.PrimDebugControl_Load);
            this.groupBox.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label123;
        private System.Windows.Forms.TextBox tBoxLESIName;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnStop1;
        private System.Windows.Forms.Button btnRun1;
        private System.Windows.Forms.TextBox tBoxConnState;
        private System.Windows.Forms.TextBox tBoxRunState;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Timer tmrUpdateUI;
        private System.Windows.Forms.Button btnInit;
    }
}
