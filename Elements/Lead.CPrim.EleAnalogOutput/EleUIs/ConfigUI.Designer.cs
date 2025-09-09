namespace Lead.CPrim.EleAnalogOutput
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
            this.chkSimulate = new System.Windows.Forms.CheckBox();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbState = new System.Windows.Forms.TextBox();
            this.lbState = new System.Windows.Forms.Label();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_Address = new System.Windows.Forms.Label();
            this.lb_ActMin = new System.Windows.Forms.Label();
            this.lb_ActMax = new System.Windows.Forms.Label();
            this.lb_LimitMin = new System.Windows.Forms.Label();
            this.lb_LimitMax = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbActMin = new System.Windows.Forms.TextBox();
            this.tbActMax = new System.Windows.Forms.TextBox();
            this.tbLimitMin = new System.Windows.Forms.TextBox();
            this.tbLimitMax = new System.Windows.Forms.TextBox();
            this.lbType = new System.Windows.Forms.Label();
            this.lb_FeedBackMin = new System.Windows.Forms.Label();
            this.lb_FeedBackMax = new System.Windows.Forms.Label();
            this.lb_SetValue = new System.Windows.Forms.Label();
            this.tbFeedBackMin = new System.Windows.Forms.TextBox();
            this.tbFeedBackMax = new System.Windows.Forms.TextBox();
            this.btnConfigApply = new System.Windows.Forms.Button();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.tBoxSetValue = new System.Windows.Forms.TextBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.lbDevName = new System.Windows.Forms.Label();
            this.cmbPrim = new System.Windows.Forms.ComboBox();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkSimulate
            // 
            this.chkSimulate.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkSimulate.Location = new System.Drawing.Point(125, 0);
            this.chkSimulate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.chkSimulate.Name = "chkSimulate";
            this.chkSimulate.Size = new System.Drawing.Size(125, 42);
            this.chkSimulate.TabIndex = 1;
            this.chkSimulate.Text = "模拟";
            this.chkSimulate.UseVisualStyleBackColor = true;
            this.chkSimulate.Visible = false;
            // 
            // chkEnable
            // 
            this.chkEnable.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkEnable.Location = new System.Drawing.Point(0, 0);
            this.chkEnable.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(125, 42);
            this.chkEnable.TabIndex = 2;
            this.chkEnable.Text = "使能";
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.cBoxEnable_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.chkSimulate);
            this.panel4.Controls.Add(this.chkEnable);
            this.panel4.Location = new System.Drawing.Point(2, 46);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(717, 44);
            this.panel4.TabIndex = 152;
            // 
            // tbState
            // 
            this.tbState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbState.Location = new System.Drawing.Point(585, 0);
            this.tbState.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbState.Multiline = true;
            this.tbState.Name = "tbState";
            this.tbState.Size = new System.Drawing.Size(133, 39);
            this.tbState.TabIndex = 9;
            this.tbState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbState
            // 
            this.lbState.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbState.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbState.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbState.Location = new System.Drawing.Point(460, 0);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(125, 39);
            this.lbState.TabIndex = 8;
            this.lbState.Text = "状态";
            this.lbState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbState.Click += new System.EventHandler(this.LbState_Click);
            // 
            // tbInfo
            // 
            this.tbInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbInfo.Location = new System.Drawing.Point(354, 0);
            this.tbInfo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(106, 39);
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
            this.lbInfo.Location = new System.Drawing.Point(237, 0);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(117, 39);
            this.lbInfo.TabIndex = 2;
            this.lbInfo.Text = "信息";
            this.lbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbName
            // 
            this.tbName.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbName.Location = new System.Drawing.Point(125, 0);
            this.tbName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbName.Multiline = true;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(112, 39);
            this.tbName.TabIndex = 1;
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
            this.lbName.Size = new System.Drawing.Size(125, 39);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "名称";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbName.DoubleClick += new System.EventHandler(this.panel1_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.tbState);
            this.panel2.Controls.Add(this.lbState);
            this.panel2.Controls.Add(this.tbInfo);
            this.panel2.Controls.Add(this.lbInfo);
            this.panel2.Controls.Add(this.tbName);
            this.panel2.Controls.Add(this.lbName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(722, 43);
            this.panel2.TabIndex = 154;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lb_Address);
            this.panel1.Controls.Add(this.lb_ActMin);
            this.panel1.Controls.Add(this.lb_ActMax);
            this.panel1.Controls.Add(this.lb_LimitMin);
            this.panel1.Controls.Add(this.lb_LimitMax);
            this.panel1.Controls.Add(this.tbAddress);
            this.panel1.Controls.Add(this.tbActMin);
            this.panel1.Controls.Add(this.tbActMax);
            this.panel1.Controls.Add(this.tbLimitMin);
            this.panel1.Controls.Add(this.tbLimitMax);
            this.panel1.Controls.Add(this.lbType);
            this.panel1.Controls.Add(this.lb_FeedBackMin);
            this.panel1.Controls.Add(this.lb_FeedBackMax);
            this.panel1.Controls.Add(this.lb_SetValue);
            this.panel1.Controls.Add(this.tbFeedBackMin);
            this.panel1.Controls.Add(this.tbFeedBackMax);
            this.panel1.Controls.Add(this.btnConfigApply);
            this.panel1.Controls.Add(this.cmbType);
            this.panel1.Controls.Add(this.tBoxSetValue);
            this.panel1.Controls.Add(this.btnSet);
            this.panel1.Controls.Add(this.lbDevName);
            this.panel1.Controls.Add(this.cmbPrim);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(726, 383);
            this.panel1.TabIndex = 1;
            // 
            // lb_Address
            // 
            this.lb_Address.BackColor = System.Drawing.SystemColors.Info;
            this.lb_Address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Address.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Address.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_Address.Location = new System.Drawing.Point(7, 146);
            this.lb_Address.Name = "lb_Address";
            this.lb_Address.Size = new System.Drawing.Size(114, 32);
            this.lb_Address.TabIndex = 199;
            this.lb_Address.Text = "通道地址";
            this.lb_Address.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_ActMin
            // 
            this.lb_ActMin.BackColor = System.Drawing.SystemColors.Info;
            this.lb_ActMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_ActMin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_ActMin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_ActMin.Location = new System.Drawing.Point(7, 188);
            this.lb_ActMin.Name = "lb_ActMin";
            this.lb_ActMin.Size = new System.Drawing.Size(114, 32);
            this.lb_ActMin.TabIndex = 203;
            this.lb_ActMin.Text = "数字量最小值";
            this.lb_ActMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_ActMax
            // 
            this.lb_ActMax.BackColor = System.Drawing.SystemColors.Info;
            this.lb_ActMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_ActMax.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_ActMax.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_ActMax.Location = new System.Drawing.Point(7, 237);
            this.lb_ActMax.Name = "lb_ActMax";
            this.lb_ActMax.Size = new System.Drawing.Size(114, 32);
            this.lb_ActMax.TabIndex = 202;
            this.lb_ActMax.Text = "数字量最大值";
            this.lb_ActMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_LimitMin
            // 
            this.lb_LimitMin.BackColor = System.Drawing.SystemColors.Info;
            this.lb_LimitMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_LimitMin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_LimitMin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_LimitMin.Location = new System.Drawing.Point(7, 279);
            this.lb_LimitMin.Name = "lb_LimitMin";
            this.lb_LimitMin.Size = new System.Drawing.Size(114, 32);
            this.lb_LimitMin.TabIndex = 204;
            this.lb_LimitMin.Text = "数字量下限";
            this.lb_LimitMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_LimitMax
            // 
            this.lb_LimitMax.BackColor = System.Drawing.SystemColors.Info;
            this.lb_LimitMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_LimitMax.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_LimitMax.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_LimitMax.Location = new System.Drawing.Point(7, 321);
            this.lb_LimitMax.Name = "lb_LimitMax";
            this.lb_LimitMax.Size = new System.Drawing.Size(114, 32);
            this.lb_LimitMax.TabIndex = 205;
            this.lb_LimitMax.Text = "数字量上限";
            this.lb_LimitMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(127, 146);
            this.tbAddress.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbAddress.Multiline = true;
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(168, 32);
            this.tbAddress.TabIndex = 212;
            this.tbAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbActMin
            // 
            this.tbActMin.Location = new System.Drawing.Point(127, 188);
            this.tbActMin.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbActMin.Multiline = true;
            this.tbActMin.Name = "tbActMin";
            this.tbActMin.Size = new System.Drawing.Size(168, 32);
            this.tbActMin.TabIndex = 211;
            this.tbActMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbActMax
            // 
            this.tbActMax.Location = new System.Drawing.Point(127, 237);
            this.tbActMax.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbActMax.Multiline = true;
            this.tbActMax.Name = "tbActMax";
            this.tbActMax.Size = new System.Drawing.Size(168, 32);
            this.tbActMax.TabIndex = 206;
            this.tbActMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbLimitMin
            // 
            this.tbLimitMin.Location = new System.Drawing.Point(127, 279);
            this.tbLimitMin.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbLimitMin.Multiline = true;
            this.tbLimitMin.Name = "tbLimitMin";
            this.tbLimitMin.Size = new System.Drawing.Size(168, 32);
            this.tbLimitMin.TabIndex = 208;
            this.tbLimitMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbLimitMax
            // 
            this.tbLimitMax.Location = new System.Drawing.Point(127, 321);
            this.tbLimitMax.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbLimitMax.Multiline = true;
            this.tbLimitMax.Name = "tbLimitMax";
            this.tbLimitMax.Size = new System.Drawing.Size(168, 32);
            this.tbLimitMax.TabIndex = 210;
            this.tbLimitMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbType
            // 
            this.lbType.BackColor = System.Drawing.SystemColors.Info;
            this.lbType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbType.Location = new System.Drawing.Point(314, 104);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(114, 32);
            this.lbType.TabIndex = 214;
            this.lbType.Text = "类型";
            this.lbType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_FeedBackMin
            // 
            this.lb_FeedBackMin.BackColor = System.Drawing.SystemColors.Info;
            this.lb_FeedBackMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_FeedBackMin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_FeedBackMin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_FeedBackMin.Location = new System.Drawing.Point(314, 188);
            this.lb_FeedBackMin.Name = "lb_FeedBackMin";
            this.lb_FeedBackMin.Size = new System.Drawing.Size(114, 32);
            this.lb_FeedBackMin.TabIndex = 200;
            this.lb_FeedBackMin.Text = "模拟量最小值";
            this.lb_FeedBackMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_FeedBackMax
            // 
            this.lb_FeedBackMax.BackColor = System.Drawing.SystemColors.Info;
            this.lb_FeedBackMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_FeedBackMax.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_FeedBackMax.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_FeedBackMax.Location = new System.Drawing.Point(314, 237);
            this.lb_FeedBackMax.Name = "lb_FeedBackMax";
            this.lb_FeedBackMax.Size = new System.Drawing.Size(114, 32);
            this.lb_FeedBackMax.TabIndex = 197;
            this.lb_FeedBackMax.Text = "模拟量最大值";
            this.lb_FeedBackMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_SetValue
            // 
            this.lb_SetValue.BackColor = System.Drawing.SystemColors.Info;
            this.lb_SetValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_SetValue.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_SetValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_SetValue.Location = new System.Drawing.Point(314, 279);
            this.lb_SetValue.Name = "lb_SetValue";
            this.lb_SetValue.Size = new System.Drawing.Size(114, 32);
            this.lb_SetValue.TabIndex = 201;
            this.lb_SetValue.Text = "设定值";
            this.lb_SetValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbFeedBackMin
            // 
            this.tbFeedBackMin.Location = new System.Drawing.Point(443, 188);
            this.tbFeedBackMin.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbFeedBackMin.Multiline = true;
            this.tbFeedBackMin.Name = "tbFeedBackMin";
            this.tbFeedBackMin.Size = new System.Drawing.Size(165, 32);
            this.tbFeedBackMin.TabIndex = 209;
            this.tbFeedBackMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbFeedBackMax
            // 
            this.tbFeedBackMax.Location = new System.Drawing.Point(443, 237);
            this.tbFeedBackMax.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbFeedBackMax.Multiline = true;
            this.tbFeedBackMax.Name = "tbFeedBackMax";
            this.tbFeedBackMax.Size = new System.Drawing.Size(165, 32);
            this.tbFeedBackMax.TabIndex = 213;
            this.tbFeedBackMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnConfigApply
            // 
            this.btnConfigApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnConfigApply.Location = new System.Drawing.Point(443, 321);
            this.btnConfigApply.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnConfigApply.Name = "btnConfigApply";
            this.btnConfigApply.Size = new System.Drawing.Size(165, 44);
            this.btnConfigApply.TabIndex = 216;
            this.btnConfigApply.Text = "应用";
            this.btnConfigApply.UseVisualStyleBackColor = false;
            this.btnConfigApply.Click += new System.EventHandler(this.btnConfigApply_Click);
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Voltage(V)",
            "Electricity(mA)"});
            this.cmbType.Location = new System.Drawing.Point(443, 104);
            this.cmbType.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(165, 32);
            this.cmbType.TabIndex = 215;
            // 
            // tBoxSetValue
            // 
            this.tBoxSetValue.Location = new System.Drawing.Point(443, 279);
            this.tBoxSetValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tBoxSetValue.Multiline = true;
            this.tBoxSetValue.Name = "tBoxSetValue";
            this.tBoxSetValue.Size = new System.Drawing.Size(165, 32);
            this.tBoxSetValue.TabIndex = 207;
            this.tBoxSetValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(614, 279);
            this.btnSet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(98, 32);
            this.btnSet.TabIndex = 218;
            this.btnSet.Text = "写入";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click_1);
            // 
            // lbDevName
            // 
            this.lbDevName.BackColor = System.Drawing.SystemColors.Info;
            this.lbDevName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDevName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDevName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbDevName.Location = new System.Drawing.Point(7, 104);
            this.lbDevName.Name = "lbDevName";
            this.lbDevName.Size = new System.Drawing.Size(114, 32);
            this.lbDevName.TabIndex = 198;
            this.lbDevName.Text = "设备名称";
            this.lbDevName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbPrim
            // 
            this.cmbPrim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrim.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPrim.FormattingEnabled = true;
            this.cmbPrim.Location = new System.Drawing.Point(127, 104);
            this.cmbPrim.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbPrim.Name = "cmbPrim";
            this.cmbPrim.Size = new System.Drawing.Size(168, 32);
            this.cmbPrim.TabIndex = 217;
            // 
            // ConfigUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ConfigUI";
            this.Size = new System.Drawing.Size(726, 383);
            this.Load += new System.EventHandler(this.ConfigUI_Load);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox chkSimulate;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbState;
        private System.Windows.Forms.Label lbState;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_Address;
        private System.Windows.Forms.Label lb_ActMin;
        private System.Windows.Forms.Label lb_ActMax;
        private System.Windows.Forms.Label lb_LimitMin;
        private System.Windows.Forms.Label lb_LimitMax;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.TextBox tbActMin;
        private System.Windows.Forms.TextBox tbActMax;
        private System.Windows.Forms.TextBox tbLimitMin;
        private System.Windows.Forms.TextBox tbLimitMax;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Label lb_FeedBackMin;
        private System.Windows.Forms.Label lb_FeedBackMax;
        private System.Windows.Forms.Label lb_SetValue;
        private System.Windows.Forms.TextBox tbFeedBackMin;
        private System.Windows.Forms.TextBox tbFeedBackMax;
        private System.Windows.Forms.Button btnConfigApply;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox tBoxSetValue;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Label lbDevName;
        private System.Windows.Forms.ComboBox cmbPrim;
    }
}
