namespace Lead.CPrim.ShowHistorgram.Controls
{
    partial class ShowConfigControl
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
            this.chkEnableBarcode = new System.Windows.Forms.CheckBox();
            this.txbPicturePath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbNormalParts = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.chkLogEnable = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbFloorParts = new System.Windows.Forms.ComboBox();
            this.cbUpParts = new System.Windows.Forms.ComboBox();
            this.btnSavePath = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbDisplayMode = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkEnableBarcode
            // 
            this.chkEnableBarcode.AutoSize = true;
            this.chkEnableBarcode.Location = new System.Drawing.Point(199, 287);
            this.chkEnableBarcode.Name = "chkEnableBarcode";
            this.chkEnableBarcode.Size = new System.Drawing.Size(99, 21);
            this.chkEnableBarcode.TabIndex = 18;
            this.chkEnableBarcode.Text = "良率显示使能";
            this.chkEnableBarcode.UseVisualStyleBackColor = true;
            // 
            // txbPicturePath
            // 
            this.txbPicturePath.Location = new System.Drawing.Point(199, 233);
            this.txbPicturePath.Name = "txbPicturePath";
            this.txbPicturePath.Size = new System.Drawing.Size(264, 23);
            this.txbPicturePath.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "图片保存文件夹";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "正常区域分组数";
            // 
            // txbNormalParts
            // 
            this.txbNormalParts.Location = new System.Drawing.Point(199, 98);
            this.txbNormalParts.Name = "txbNormalParts";
            this.txbNormalParts.Size = new System.Drawing.Size(70, 23);
            this.txbNormalParts.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "超上限分组数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "超下限分组数";
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(608, 352);
            this.btnApply.Margin = new System.Windows.Forms.Padding(2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(168, 54);
            this.btnApply.TabIndex = 127;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 35);
            this.panel1.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SkyBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(810, 35);
            this.label1.TabIndex = 12;
            this.label1.Text = "Fai直方图配置";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkLogEnable
            // 
            this.chkLogEnable.AutoSize = true;
            this.chkLogEnable.Location = new System.Drawing.Point(364, 287);
            this.chkLogEnable.Name = "chkLogEnable";
            this.chkLogEnable.Size = new System.Drawing.Size(75, 21);
            this.chkLogEnable.TabIndex = 18;
            this.chkLogEnable.Text = "日志使能";
            this.chkLogEnable.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 389);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(439, 17);
            this.label6.TabIndex = 128;
            this.label6.Text = "参数建议1：正常区域分组数建议值：20；超下限分组数：5；超上限分组数：5；";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(86, 357);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(411, 17);
            this.label7.TabIndex = 128;
            this.label7.Text = "参数规则1：正常区域分组>=10；超下限分组数3、5；超上限分组数3、5；";
            // 
            // cbFloorParts
            // 
            this.cbFloorParts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFloorParts.FormattingEnabled = true;
            this.cbFloorParts.Items.AddRange(new object[] {
            "3",
            "5"});
            this.cbFloorParts.Location = new System.Drawing.Point(199, 142);
            this.cbFloorParts.Name = "cbFloorParts";
            this.cbFloorParts.Size = new System.Drawing.Size(70, 25);
            this.cbFloorParts.TabIndex = 129;
            // 
            // cbUpParts
            // 
            this.cbUpParts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUpParts.FormattingEnabled = true;
            this.cbUpParts.Items.AddRange(new object[] {
            "3",
            "5"});
            this.cbUpParts.Location = new System.Drawing.Point(199, 187);
            this.cbUpParts.Name = "cbUpParts";
            this.cbUpParts.Size = new System.Drawing.Size(70, 25);
            this.cbUpParts.TabIndex = 129;
            // 
            // btnSavePath
            // 
            this.btnSavePath.Location = new System.Drawing.Point(470, 233);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(37, 23);
            this.btnSavePath.TabIndex = 130;
            this.btnSavePath.Text = "...";
            this.btnSavePath.UseVisualStyleBackColor = true;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(457, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "柱状图显示样式";
            // 
            // cbDisplayMode
            // 
            this.cbDisplayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDisplayMode.FormattingEnabled = true;
            this.cbDisplayMode.Items.AddRange(new object[] {
            "Chart",
            "Draw"});
            this.cbDisplayMode.Location = new System.Drawing.Point(570, 97);
            this.cbDisplayMode.Name = "cbDisplayMode";
            this.cbDisplayMode.Size = new System.Drawing.Size(118, 25);
            this.cbDisplayMode.TabIndex = 129;
            // 
            // ShowConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSavePath);
            this.Controls.Add(this.cbUpParts);
            this.Controls.Add(this.cbDisplayMode);
            this.Controls.Add(this.cbFloorParts);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkLogEnable);
            this.Controls.Add(this.chkEnableBarcode);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbPicturePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbNormalParts);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ShowConfigControl";
            this.Size = new System.Drawing.Size(810, 425);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbPicturePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbNormalParts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkEnableBarcode;
        private System.Windows.Forms.CheckBox chkLogEnable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbFloorParts;
        private System.Windows.Forms.ComboBox cbUpParts;
        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbDisplayMode;
    }
}
