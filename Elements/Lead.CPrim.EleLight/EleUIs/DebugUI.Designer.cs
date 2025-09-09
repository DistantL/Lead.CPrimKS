namespace Lead.CPrim.EleLight
{
    partial class DebugUI
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
            this.tmrUpdateLight = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BuzzDO = new System.Windows.Forms.Label();
            this.YellowDO = new System.Windows.Forms.Label();
            this.GreenDO = new System.Windows.Forms.Label();
            this.RedDO = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tBoxName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrUpdateLight
            // 
            this.tmrUpdateLight.Tick += new System.EventHandler(this.tmrLightUpdate_Tick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.BuzzDO);
            this.panel1.Controls.Add(this.YellowDO);
            this.panel1.Controls.Add(this.GreenDO);
            this.panel1.Controls.Add(this.RedDO);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 149);
            this.panel1.TabIndex = 50;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Stopping",
            "Running",
            "Error",
            "Warn",
            "Fatal"});
            this.comboBox1.Location = new System.Drawing.Point(151, 42);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(124, 28);
            this.comboBox1.TabIndex = 63;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // BuzzDO
            // 
            this.BuzzDO.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BuzzDO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BuzzDO.Location = new System.Drawing.Point(80, 112);
            this.BuzzDO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BuzzDO.Name = "BuzzDO";
            this.BuzzDO.Size = new System.Drawing.Size(44, 18);
            this.BuzzDO.TabIndex = 48;
            this.BuzzDO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // YellowDO
            // 
            this.YellowDO.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.YellowDO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.YellowDO.Location = new System.Drawing.Point(80, 75);
            this.YellowDO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.YellowDO.Name = "YellowDO";
            this.YellowDO.Size = new System.Drawing.Size(44, 20);
            this.YellowDO.TabIndex = 49;
            this.YellowDO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GreenDO
            // 
            this.GreenDO.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GreenDO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GreenDO.Location = new System.Drawing.Point(80, 42);
            this.GreenDO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GreenDO.Name = "GreenDO";
            this.GreenDO.Size = new System.Drawing.Size(44, 20);
            this.GreenDO.TabIndex = 50;
            this.GreenDO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RedDO
            // 
            this.RedDO.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RedDO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RedDO.Location = new System.Drawing.Point(80, 8);
            this.RedDO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RedDO.Name = "RedDO";
            this.RedDO.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RedDO.Size = new System.Drawing.Size(44, 20);
            this.RedDO.TabIndex = 47;
            this.RedDO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 62;
            this.label3.Text = "Yellow";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 58;
            this.label1.Text = "Red";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 59;
            this.label2.Text = "Green";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 61;
            this.label4.Text = "Buzz";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tBoxName);
            this.panel3.Controls.Add(this.lbName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(281, 35);
            this.panel3.TabIndex = 51;
            // 
            // tBoxName
            // 
            this.tBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxName.Location = new System.Drawing.Point(80, 3);
            this.tBoxName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tBoxName.Multiline = true;
            this.tBoxName.Name = "tBoxName";
            this.tBoxName.ReadOnly = true;
            this.tBoxName.Size = new System.Drawing.Size(83, 21);
            this.tBoxName.TabIndex = 23;
            this.tBoxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbName
            // 
            this.lbName.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbName.Location = new System.Drawing.Point(4, 3);
            this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(57, 21);
            this.lbName.TabIndex = 22;
            this.lbName.Text = "Name";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DebugUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DebugUI";
            this.Size = new System.Drawing.Size(281, 180);
            this.Load += new System.EventHandler(this.DebugUI_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmrUpdateLight;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label BuzzDO;
        private System.Windows.Forms.Label YellowDO;
        private System.Windows.Forms.Label GreenDO;
        private System.Windows.Forms.Label RedDO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.TextBox tBoxName;
        private System.Windows.Forms.Label lbName;
    }
}
