namespace Lead.CPrim.EleLight
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
            this.btnConfigApply = new System.Windows.Forms.Button();
            this.tbRed = new System.Windows.Forms.TextBox();
            this.chkSimulate = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.chkRedEnable = new System.Windows.Forms.CheckBox();
            this.btnSetRed = new System.Windows.Forms.Button();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lbType = new System.Windows.Forms.Label();
            this.lbRed = new System.Windows.Forms.Label();
            this.tbState = new System.Windows.Forms.TextBox();
            this.lbState = new System.Windows.Forms.Label();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.tbDevName = new System.Windows.Forms.TextBox();
            this.lbDevName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tmrUpdateLight = new System.Windows.Forms.Timer(this.components);
            this.lb_Green = new System.Windows.Forms.Label();
            this.lb_Yellow = new System.Windows.Forms.Label();
            this.lb_Buzzer = new System.Windows.Forms.Label();
            this.tbGreen = new System.Windows.Forms.TextBox();
            this.tbYellow = new System.Windows.Forms.TextBox();
            this.tbBuzz = new System.Windows.Forms.TextBox();
            this.chkGreenEnable = new System.Windows.Forms.CheckBox();
            this.chkYellowEnable = new System.Windows.Forms.CheckBox();
            this.chkBuzzEnable = new System.Windows.Forms.CheckBox();
            this.btnSetGreen = new System.Windows.Forms.Button();
            this.btnSetYellow = new System.Windows.Forms.Button();
            this.btnSetBuzz = new System.Windows.Forms.Button();
            this.tmrBuzz = new System.Windows.Forms.Timer(this.components);
            this.tmrYellow = new System.Windows.Forms.Timer(this.components);
            this.tmrBtnYellow = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConfigApply
            // 
            this.btnConfigApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfigApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnConfigApply.Location = new System.Drawing.Point(452, 240);
            this.btnConfigApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConfigApply.Name = "btnConfigApply";
            this.btnConfigApply.Size = new System.Drawing.Size(112, 28);
            this.btnConfigApply.TabIndex = 161;
            this.btnConfigApply.Text = "应用";
            this.btnConfigApply.UseVisualStyleBackColor = false;
            this.btnConfigApply.Click += new System.EventHandler(this.btnConfigApply_Click);
            // 
            // tbRed
            // 
            this.tbRed.Location = new System.Drawing.Point(112, 144);
            this.tbRed.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbRed.Multiline = true;
            this.tbRed.Name = "tbRed";
            this.tbRed.Size = new System.Drawing.Size(112, 28);
            this.tbRed.TabIndex = 152;
            this.tbRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkSimulate
            // 
            this.chkSimulate.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkSimulate.Location = new System.Drawing.Point(111, 0);
            this.chkSimulate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkSimulate.Name = "chkSimulate";
            this.chkSimulate.Size = new System.Drawing.Size(111, 37);
            this.chkSimulate.TabIndex = 1;
            this.chkSimulate.Text = "虚拟";
            this.chkSimulate.UseVisualStyleBackColor = true;
            this.chkSimulate.Visible = false;
            this.chkSimulate.CheckedChanged += new System.EventHandler(this.chkSimulate_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkSimulate);
            this.panel2.Controls.Add(this.chkEnable);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(670, 39);
            this.panel2.TabIndex = 160;
            // 
            // chkEnable
            // 
            this.chkEnable.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkEnable.Location = new System.Drawing.Point(0, 0);
            this.chkEnable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(111, 37);
            this.chkEnable.TabIndex = 2;
            this.chkEnable.Text = "使能";
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            // 
            // chkRedEnable
            // 
            this.chkRedEnable.Location = new System.Drawing.Point(241, 144);
            this.chkRedEnable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkRedEnable.Name = "chkRedEnable";
            this.chkRedEnable.Size = new System.Drawing.Size(88, 28);
            this.chkRedEnable.TabIndex = 157;
            this.chkRedEnable.Text = "使能";
            this.chkRedEnable.UseVisualStyleBackColor = true;
            // 
            // btnSetRed
            // 
            this.btnSetRed.Location = new System.Drawing.Point(335, 144);
            this.btnSetRed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSetRed.Name = "btnSetRed";
            this.btnSetRed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSetRed.Size = new System.Drawing.Size(73, 28);
            this.btnSetRed.TabIndex = 156;
            this.btnSetRed.Text = "置位";
            this.btnSetRed.UseVisualStyleBackColor = true;
            this.btnSetRed.Click += new System.EventHandler(this.btnSetRed_Click);
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Tricolour_Light",
            "Button_Light"});
            this.cmbType.Location = new System.Drawing.Point(112, 80);
            this.cmbType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(112, 28);
            this.cmbType.TabIndex = 154;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // lbType
            // 
            this.lbType.BackColor = System.Drawing.SystemColors.Info;
            this.lbType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbType.Location = new System.Drawing.Point(4, 80);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(108, 28);
            this.lbType.TabIndex = 153;
            this.lbType.Text = "指示灯类型";
            this.lbType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbRed
            // 
            this.lbRed.BackColor = System.Drawing.SystemColors.Info;
            this.lbRed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbRed.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRed.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbRed.Location = new System.Drawing.Point(4, 144);
            this.lbRed.Name = "lbRed";
            this.lbRed.Size = new System.Drawing.Size(108, 28);
            this.lbRed.TabIndex = 149;
            this.lbRed.Text = "红灯";
            this.lbRed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbState
            // 
            this.tbState.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbState.Location = new System.Drawing.Point(557, 0);
            this.tbState.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbState.Multiline = true;
            this.tbState.Name = "tbState";
            this.tbState.Size = new System.Drawing.Size(112, 35);
            this.tbState.TabIndex = 21;
            this.tbState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbState
            // 
            this.lbState.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbState.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbState.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbState.Location = new System.Drawing.Point(446, 0);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(111, 35);
            this.lbState.TabIndex = 20;
            this.lbState.Text = "状态";
            this.lbState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbState.Click += new System.EventHandler(this.lbState_Click);
            // 
            // tbInfo
            // 
            this.tbInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbInfo.Location = new System.Drawing.Point(334, 0);
            this.tbInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(112, 35);
            this.tbInfo.TabIndex = 19;
            this.tbInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbInfo
            // 
            this.lbInfo.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbInfo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbInfo.Location = new System.Drawing.Point(223, 0);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(111, 35);
            this.lbInfo.TabIndex = 18;
            this.lbInfo.Text = "信息";
            this.lbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbName
            // 
            this.tbName.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbName.Location = new System.Drawing.Point(111, 0);
            this.tbName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbName.Multiline = true;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(112, 35);
            this.tbName.TabIndex = 17;
            this.tbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.lbName.Size = new System.Drawing.Size(111, 35);
            this.lbName.TabIndex = 16;
            this.lbName.Text = "名称";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbName.DoubleClick += new System.EventHandler(this.ConfigUI_Click);
            // 
            // tbDevName
            // 
            this.tbDevName.Location = new System.Drawing.Point(112, 111);
            this.tbDevName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbDevName.Multiline = true;
            this.tbDevName.Name = "tbDevName";
            this.tbDevName.Size = new System.Drawing.Size(112, 28);
            this.tbDevName.TabIndex = 151;
            this.tbDevName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbDevName
            // 
            this.lbDevName.BackColor = System.Drawing.SystemColors.Info;
            this.lbDevName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDevName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDevName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbDevName.Location = new System.Drawing.Point(4, 111);
            this.lbDevName.Name = "lbDevName";
            this.lbDevName.Size = new System.Drawing.Size(108, 28);
            this.lbDevName.TabIndex = 150;
            this.lbDevName.Text = "设备名称";
            this.lbDevName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbState);
            this.panel1.Controls.Add(this.lbState);
            this.panel1.Controls.Add(this.tbInfo);
            this.panel1.Controls.Add(this.lbInfo);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 35);
            this.panel1.TabIndex = 148;
            // 
            // tmrUpdateLight
            // 
            this.tmrUpdateLight.Interval = 50;
            this.tmrUpdateLight.Tick += new System.EventHandler(this.tmrLightUpdate_Tick);
            // 
            // lb_Green
            // 
            this.lb_Green.BackColor = System.Drawing.SystemColors.Info;
            this.lb_Green.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Green.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Green.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_Green.Location = new System.Drawing.Point(4, 176);
            this.lb_Green.Name = "lb_Green";
            this.lb_Green.Size = new System.Drawing.Size(108, 28);
            this.lb_Green.TabIndex = 162;
            this.lb_Green.Text = "绿灯";
            this.lb_Green.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Yellow
            // 
            this.lb_Yellow.BackColor = System.Drawing.SystemColors.Info;
            this.lb_Yellow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Yellow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Yellow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_Yellow.Location = new System.Drawing.Point(4, 208);
            this.lb_Yellow.Name = "lb_Yellow";
            this.lb_Yellow.Size = new System.Drawing.Size(108, 28);
            this.lb_Yellow.TabIndex = 163;
            this.lb_Yellow.Text = "黄灯";
            this.lb_Yellow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Buzzer
            // 
            this.lb_Buzzer.BackColor = System.Drawing.SystemColors.Info;
            this.lb_Buzzer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Buzzer.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Buzzer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_Buzzer.Location = new System.Drawing.Point(4, 240);
            this.lb_Buzzer.Name = "lb_Buzzer";
            this.lb_Buzzer.Size = new System.Drawing.Size(108, 28);
            this.lb_Buzzer.TabIndex = 163;
            this.lb_Buzzer.Text = "蜂鸣器";
            this.lb_Buzzer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbGreen
            // 
            this.tbGreen.Location = new System.Drawing.Point(112, 176);
            this.tbGreen.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbGreen.Multiline = true;
            this.tbGreen.Name = "tbGreen";
            this.tbGreen.Size = new System.Drawing.Size(112, 28);
            this.tbGreen.TabIndex = 152;
            this.tbGreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbYellow
            // 
            this.tbYellow.Location = new System.Drawing.Point(112, 208);
            this.tbYellow.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbYellow.Multiline = true;
            this.tbYellow.Name = "tbYellow";
            this.tbYellow.Size = new System.Drawing.Size(112, 28);
            this.tbYellow.TabIndex = 152;
            this.tbYellow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbBuzz
            // 
            this.tbBuzz.Location = new System.Drawing.Point(112, 240);
            this.tbBuzz.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbBuzz.Multiline = true;
            this.tbBuzz.Name = "tbBuzz";
            this.tbBuzz.Size = new System.Drawing.Size(112, 28);
            this.tbBuzz.TabIndex = 152;
            this.tbBuzz.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkGreenEnable
            // 
            this.chkGreenEnable.Location = new System.Drawing.Point(241, 180);
            this.chkGreenEnable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkGreenEnable.Name = "chkGreenEnable";
            this.chkGreenEnable.Size = new System.Drawing.Size(88, 24);
            this.chkGreenEnable.TabIndex = 157;
            this.chkGreenEnable.Text = "使能";
            this.chkGreenEnable.UseVisualStyleBackColor = true;
            // 
            // chkYellowEnable
            // 
            this.chkYellowEnable.Location = new System.Drawing.Point(241, 208);
            this.chkYellowEnable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkYellowEnable.Name = "chkYellowEnable";
            this.chkYellowEnable.Size = new System.Drawing.Size(88, 29);
            this.chkYellowEnable.TabIndex = 157;
            this.chkYellowEnable.Text = "使能";
            this.chkYellowEnable.UseVisualStyleBackColor = true;
            // 
            // chkBuzzEnable
            // 
            this.chkBuzzEnable.Location = new System.Drawing.Point(241, 240);
            this.chkBuzzEnable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkBuzzEnable.Name = "chkBuzzEnable";
            this.chkBuzzEnable.Size = new System.Drawing.Size(88, 28);
            this.chkBuzzEnable.TabIndex = 157;
            this.chkBuzzEnable.Text = "使能";
            this.chkBuzzEnable.UseVisualStyleBackColor = true;
            // 
            // btnSetGreen
            // 
            this.btnSetGreen.Location = new System.Drawing.Point(335, 176);
            this.btnSetGreen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSetGreen.Name = "btnSetGreen";
            this.btnSetGreen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSetGreen.Size = new System.Drawing.Size(73, 28);
            this.btnSetGreen.TabIndex = 156;
            this.btnSetGreen.Text = "置位";
            this.btnSetGreen.UseVisualStyleBackColor = true;
            this.btnSetGreen.Click += new System.EventHandler(this.btnSetGreen_Click);
            // 
            // btnSetYellow
            // 
            this.btnSetYellow.Location = new System.Drawing.Point(335, 208);
            this.btnSetYellow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSetYellow.Name = "btnSetYellow";
            this.btnSetYellow.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSetYellow.Size = new System.Drawing.Size(73, 28);
            this.btnSetYellow.TabIndex = 156;
            this.btnSetYellow.Text = "置位";
            this.btnSetYellow.UseVisualStyleBackColor = true;
            this.btnSetYellow.Click += new System.EventHandler(this.btnSetYellow_Click);
            // 
            // btnSetBuzz
            // 
            this.btnSetBuzz.Location = new System.Drawing.Point(335, 240);
            this.btnSetBuzz.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSetBuzz.Name = "btnSetBuzz";
            this.btnSetBuzz.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSetBuzz.Size = new System.Drawing.Size(73, 28);
            this.btnSetBuzz.TabIndex = 156;
            this.btnSetBuzz.Text = "置位";
            this.btnSetBuzz.UseVisualStyleBackColor = true;
            this.btnSetBuzz.Click += new System.EventHandler(this.btnSetBuzz_Click);
            // 
            // tmrBuzz
            // 
            this.tmrBuzz.Tick += new System.EventHandler(this.tmrBuzz_Tick);
            // 
            // tmrYellow
            // 
            this.tmrYellow.Interval = 500;
            this.tmrYellow.Tick += new System.EventHandler(this.tmrYellow_Tick);
            // 
            // tmrBtnYellow
            // 
            this.tmrBtnYellow.Interval = 1000;
            this.tmrBtnYellow.Tick += new System.EventHandler(this.tmrBtnYellow_Tick);
            // 
            // ConfigUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lb_Buzzer);
            this.Controls.Add(this.lb_Yellow);
            this.Controls.Add(this.lb_Green);
            this.Controls.Add(this.btnConfigApply);
            this.Controls.Add(this.tbBuzz);
            this.Controls.Add(this.tbYellow);
            this.Controls.Add(this.tbGreen);
            this.Controls.Add(this.tbRed);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.chkBuzzEnable);
            this.Controls.Add(this.chkYellowEnable);
            this.Controls.Add(this.chkGreenEnable);
            this.Controls.Add(this.chkRedEnable);
            this.Controls.Add(this.btnSetBuzz);
            this.Controls.Add(this.btnSetYellow);
            this.Controls.Add(this.btnSetGreen);
            this.Controls.Add(this.btnSetRed);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.lbRed);
            this.Controls.Add(this.tbDevName);
            this.Controls.Add(this.lbDevName);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ConfigUI";
            this.Size = new System.Drawing.Size(670, 276);
            this.Load += new System.EventHandler(this.ConfigUI_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfigApply;
        private System.Windows.Forms.TextBox tbRed;
        private System.Windows.Forms.CheckBox chkSimulate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.CheckBox chkRedEnable;
        private System.Windows.Forms.Button btnSetRed;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Label lbRed;
        private System.Windows.Forms.TextBox tbState;
        private System.Windows.Forms.Label lbState;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbDevName;
        private System.Windows.Forms.Label lbDevName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer tmrUpdateLight;
        private System.Windows.Forms.Label lb_Green;
        private System.Windows.Forms.Label lb_Yellow;
        private System.Windows.Forms.Label lb_Buzzer;
        private System.Windows.Forms.TextBox tbGreen;
        private System.Windows.Forms.TextBox tbYellow;
        private System.Windows.Forms.TextBox tbBuzz;
        private System.Windows.Forms.CheckBox chkGreenEnable;
        private System.Windows.Forms.CheckBox chkYellowEnable;
        private System.Windows.Forms.CheckBox chkBuzzEnable;
        private System.Windows.Forms.Button btnSetGreen;
        private System.Windows.Forms.Button btnSetYellow;
        private System.Windows.Forms.Button btnSetBuzz;
        public System.Windows.Forms.Timer tmrBuzz;
        public System.Windows.Forms.Timer tmrYellow;
        public System.Windows.Forms.Timer tmrBtnYellow;
    }
}
