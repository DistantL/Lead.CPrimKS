namespace Lead.CPrim.EleDI
{
    partial class ConfigUI
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
            this.tmrUpdateSensor = new System.Windows.Forms.Timer(this.components);
            this.tBoxDiAddress = new System.Windows.Forms.TextBox();
            this.tBoxDevName = new System.Windows.Forms.TextBox();
            this.lbDevName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tBoxState = new System.Windows.Forms.TextBox();
            this.lbState = new System.Windows.Forms.Label();
            this.tBoxInfo = new System.Windows.Forms.TextBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.tBoxName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbDI = new System.Windows.Forms.Label();
            this.comBoxType = new System.Windows.Forms.ComboBox();
            this.lbType = new System.Windows.Forms.Label();
            this.cBoxDIEnable = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cBoxSimulate = new System.Windows.Forms.CheckBox();
            this.cBoxEnable = new System.Windows.Forms.CheckBox();
            this.btnConfigApply = new System.Windows.Forms.Button();
            this.chbRise = new System.Windows.Forms.CheckBox();
            this.chbFall = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrUpdateSensor
            // 
            this.tmrUpdateSensor.Interval = 50;
            this.tmrUpdateSensor.Tick += new System.EventHandler(this.tmrSensorUpdate_Tick);
            // 
            // tBoxDiAddress
            // 
            this.tBoxDiAddress.Location = new System.Drawing.Point(321, 69);
            this.tBoxDiAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxDiAddress.Multiline = true;
            this.tBoxDiAddress.Name = "tBoxDiAddress";
            this.tBoxDiAddress.Size = new System.Drawing.Size(100, 30);
            this.tBoxDiAddress.TabIndex = 27;
            this.tBoxDiAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBoxDevName
            // 
            this.tBoxDevName.Location = new System.Drawing.Point(99, 113);
            this.tBoxDevName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxDevName.Multiline = true;
            this.tBoxDevName.Name = "tBoxDevName";
            this.tBoxDevName.Size = new System.Drawing.Size(100, 30);
            this.tBoxDevName.TabIndex = 25;
            this.tBoxDevName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbDevName
            // 
            this.lbDevName.BackColor = System.Drawing.SystemColors.Info;
            this.lbDevName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDevName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDevName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbDevName.Location = new System.Drawing.Point(3, 113);
            this.lbDevName.Name = "lbDevName";
            this.lbDevName.Size = new System.Drawing.Size(96, 30);
            this.lbDevName.TabIndex = 16;
            this.lbDevName.Text = "DevName";
            this.lbDevName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tBoxState);
            this.panel1.Controls.Add(this.lbState);
            this.panel1.Controls.Add(this.tBoxInfo);
            this.panel1.Controls.Add(this.lbInfo);
            this.panel1.Controls.Add(this.tBoxName);
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 28);
            this.panel1.TabIndex = 12;
            // 
            // tBoxState
            // 
            this.tBoxState.Dock = System.Windows.Forms.DockStyle.Left;
            this.tBoxState.Location = new System.Drawing.Point(520, 0);
            this.tBoxState.Multiline = true;
            this.tBoxState.Name = "tBoxState";
            this.tBoxState.Size = new System.Drawing.Size(100, 28);
            this.tBoxState.TabIndex = 15;
            this.tBoxState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbState
            // 
            this.lbState.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbState.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbState.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbState.Location = new System.Drawing.Point(421, 0);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(99, 28);
            this.lbState.TabIndex = 14;
            this.lbState.Text = "State";
            this.lbState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbState.Click += new System.EventHandler(this.lbState_Click);
            // 
            // tBoxInfo
            // 
            this.tBoxInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.tBoxInfo.Location = new System.Drawing.Point(321, 0);
            this.tBoxInfo.Multiline = true;
            this.tBoxInfo.Name = "tBoxInfo";
            this.tBoxInfo.Size = new System.Drawing.Size(100, 28);
            this.tBoxInfo.TabIndex = 13;
            this.tBoxInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbInfo
            // 
            this.lbInfo.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbInfo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbInfo.Location = new System.Drawing.Point(226, 0);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(95, 28);
            this.lbInfo.TabIndex = 12;
            this.lbInfo.Text = "Info";
            this.lbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBoxName
            // 
            this.tBoxName.Dock = System.Windows.Forms.DockStyle.Left;
            this.tBoxName.Location = new System.Drawing.Point(99, 0);
            this.tBoxName.Multiline = true;
            this.tBoxName.Name = "tBoxName";
            this.tBoxName.Size = new System.Drawing.Size(127, 28);
            this.tBoxName.TabIndex = 11;
            this.tBoxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.lbName.Size = new System.Drawing.Size(99, 28);
            this.lbName.TabIndex = 10;
            this.lbName.Text = "Name";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbName.DoubleClick += new System.EventHandler(this.ConfigUI_Click);
            // 
            // lbDI
            // 
            this.lbDI.BackColor = System.Drawing.SystemColors.Info;
            this.lbDI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDI.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDI.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbDI.Location = new System.Drawing.Point(225, 69);
            this.lbDI.Name = "lbDI";
            this.lbDI.Size = new System.Drawing.Size(96, 30);
            this.lbDI.TabIndex = 14;
            this.lbDI.Text = "DI";
            this.lbDI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comBoxType
            // 
            this.comBoxType.FormattingEnabled = true;
            this.comBoxType.Items.AddRange(new object[] {
            "NO",
            "NC"});
            this.comBoxType.Location = new System.Drawing.Point(99, 69);
            this.comBoxType.Name = "comBoxType";
            this.comBoxType.Size = new System.Drawing.Size(100, 25);
            this.comBoxType.TabIndex = 35;
            // 
            // lbType
            // 
            this.lbType.BackColor = System.Drawing.SystemColors.Info;
            this.lbType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbType.Location = new System.Drawing.Point(3, 69);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(96, 28);
            this.lbType.TabIndex = 34;
            this.lbType.Text = "Type";
            this.lbType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cBoxDIEnable
            // 
            this.cBoxDIEnable.Location = new System.Drawing.Point(437, 71);
            this.cBoxDIEnable.Name = "cBoxDIEnable";
            this.cBoxDIEnable.Size = new System.Drawing.Size(99, 28);
            this.cBoxDIEnable.TabIndex = 36;
            this.cBoxDIEnable.Text = "Enable";
            this.cBoxDIEnable.UseVisualStyleBackColor = true;
            this.cBoxDIEnable.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cBoxSimulate);
            this.panel2.Controls.Add(this.cBoxEnable);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 30);
            this.panel2.TabIndex = 39;
            // 
            // cBoxSimulate
            // 
            this.cBoxSimulate.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBoxSimulate.Location = new System.Drawing.Point(99, 0);
            this.cBoxSimulate.Name = "cBoxSimulate";
            this.cBoxSimulate.Size = new System.Drawing.Size(99, 28);
            this.cBoxSimulate.TabIndex = 1;
            this.cBoxSimulate.Text = "Simulate";
            this.cBoxSimulate.UseVisualStyleBackColor = true;
            this.cBoxSimulate.CheckedChanged += new System.EventHandler(this.cBoxSimulate_CheckedChanged);
            // 
            // cBoxEnable
            // 
            this.cBoxEnable.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBoxEnable.Location = new System.Drawing.Point(0, 0);
            this.cBoxEnable.Name = "cBoxEnable";
            this.cBoxEnable.Size = new System.Drawing.Size(99, 28);
            this.cBoxEnable.TabIndex = 2;
            this.cBoxEnable.Text = "Enable";
            this.cBoxEnable.UseVisualStyleBackColor = true;
            this.cBoxEnable.CheckedChanged += new System.EventHandler(this.cBoxEnable_CheckedChanged_1);
            // 
            // btnConfigApply
            // 
            this.btnConfigApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfigApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnConfigApply.Location = new System.Drawing.Point(514, 111);
            this.btnConfigApply.Name = "btnConfigApply";
            this.btnConfigApply.Size = new System.Drawing.Size(76, 31);
            this.btnConfigApply.TabIndex = 146;
            this.btnConfigApply.Text = "Apply";
            this.btnConfigApply.UseVisualStyleBackColor = false;
            this.btnConfigApply.Click += new System.EventHandler(this.btnConfigApply_Click);
            // 
            // chbRise
            // 
            this.chbRise.Location = new System.Drawing.Point(226, 115);
            this.chbRise.Name = "chbRise";
            this.chbRise.Size = new System.Drawing.Size(99, 28);
            this.chbRise.TabIndex = 147;
            this.chbRise.Text = "EnableRise";
            this.chbRise.UseVisualStyleBackColor = true;
            // 
            // chbFall
            // 
            this.chbFall.Location = new System.Drawing.Point(352, 114);
            this.chbFall.Name = "chbFall";
            this.chbFall.Size = new System.Drawing.Size(99, 28);
            this.chbFall.TabIndex = 148;
            this.chbFall.Text = "EnableFall";
            this.chbFall.UseVisualStyleBackColor = true;
            // 
            // ConfigUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.chbFall);
            this.Controls.Add(this.chbRise);
            this.Controls.Add(this.btnConfigApply);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cBoxDIEnable);
            this.Controls.Add(this.comBoxType);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.tBoxDiAddress);
            this.Controls.Add(this.lbDI);
            this.Controls.Add(this.tBoxDevName);
            this.Controls.Add(this.lbDevName);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ConfigUI";
            this.Size = new System.Drawing.Size(600, 150);
            this.Load += new System.EventHandler(this.ConfigUI_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer tmrUpdateSensor;
        private System.Windows.Forms.TextBox tBoxDiAddress;
        private System.Windows.Forms.TextBox tBoxDevName;
        private System.Windows.Forms.Label lbDevName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbDI;
        private System.Windows.Forms.ComboBox comBoxType;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.CheckBox cBoxDIEnable;
        private System.Windows.Forms.TextBox tBoxState;
        private System.Windows.Forms.Label lbState;
        private System.Windows.Forms.TextBox tBoxInfo;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.TextBox tBoxName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cBoxSimulate;
        private System.Windows.Forms.CheckBox cBoxEnable;
        private System.Windows.Forms.Button btnConfigApply;
        private System.Windows.Forms.CheckBox chbRise;
        private System.Windows.Forms.CheckBox chbFall;
    }
}
