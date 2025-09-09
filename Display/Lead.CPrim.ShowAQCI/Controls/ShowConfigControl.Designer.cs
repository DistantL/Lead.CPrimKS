namespace Lead.CPrim.ShowAQCI.Controls
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmbStations = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.chkShowRtData = new System.Windows.Forms.CheckBox();
            this.chkShowPic = new System.Windows.Forms.CheckBox();
            this.btnLoadPic = new System.Windows.Forms.Button();
            this.tbPicName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRemoveProColor = new System.Windows.Forms.Button();
            this.btnAddColor = new System.Windows.Forms.Button();
            this.cmbProColors = new System.Windows.Forms.ComboBox();
            this.kryptonLabel5 = new System.Windows.Forms.Label();
            this.tbPerRow1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPerRow3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPerRow2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbPerCol2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbPerCol3 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbPerCol1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cmbStations
            // 
            this.cmbStations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStations.FormattingEnabled = true;
            this.cmbStations.Location = new System.Drawing.Point(98, 54);
            this.cmbStations.Name = "cmbStations";
            this.cmbStations.Size = new System.Drawing.Size(121, 28);
            this.cmbStations.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "工站:";
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(684, 437);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(179, 34);
            this.btnApply.TabIndex = 128;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(41, 176);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(61, 24);
            this.chkEnable.TabIndex = 129;
            this.chkEnable.Text = "使能";
            this.chkEnable.UseVisualStyleBackColor = true;
            // 
            // chkShowRtData
            // 
            this.chkShowRtData.AutoSize = true;
            this.chkShowRtData.Location = new System.Drawing.Point(41, 203);
            this.chkShowRtData.Name = "chkShowRtData";
            this.chkShowRtData.Size = new System.Drawing.Size(121, 24);
            this.chkShowRtData.TabIndex = 130;
            this.chkShowRtData.Text = "推送实时数据";
            this.chkShowRtData.UseVisualStyleBackColor = true;
            // 
            // chkShowPic
            // 
            this.chkShowPic.AutoSize = true;
            this.chkShowPic.Location = new System.Drawing.Point(41, 230);
            this.chkShowPic.Name = "chkShowPic";
            this.chkShowPic.Size = new System.Drawing.Size(91, 24);
            this.chkShowPic.TabIndex = 131;
            this.chkShowPic.Text = "图片展示";
            this.chkShowPic.UseVisualStyleBackColor = true;
            // 
            // btnLoadPic
            // 
            this.btnLoadPic.BackColor = System.Drawing.Color.LawnGreen;
            this.btnLoadPic.Location = new System.Drawing.Point(786, 379);
            this.btnLoadPic.Name = "btnLoadPic";
            this.btnLoadPic.Size = new System.Drawing.Size(77, 23);
            this.btnLoadPic.TabIndex = 137;
            this.btnLoadPic.Text = "加载";
            this.btnLoadPic.UseVisualStyleBackColor = false;
            this.btnLoadPic.Click += new System.EventHandler(this.btnLoadPic_Click);
            // 
            // tbPicName
            // 
            this.tbPicName.Location = new System.Drawing.Point(684, 379);
            this.tbPicName.Name = "tbPicName";
            this.tbPicName.Size = new System.Drawing.Size(77, 27);
            this.tbPicName.TabIndex = 136;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(613, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 135;
            this.label2.Text = "图片名称：";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(532, 379);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnBrowser.TabIndex = 134;
            this.btnBrowser.Text = "浏览";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(115, 379);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(411, 27);
            this.tbFilePath.TabIndex = 133;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 382);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 132;
            this.label3.Text = "图片路径：";
            // 
            // btnRemoveProColor
            // 
            this.btnRemoveProColor.Location = new System.Drawing.Point(827, 54);
            this.btnRemoveProColor.Name = "btnRemoveProColor";
            this.btnRemoveProColor.Size = new System.Drawing.Size(34, 25);
            this.btnRemoveProColor.TabIndex = 235;
            this.btnRemoveProColor.Text = "-";
            this.btnRemoveProColor.Click += new System.EventHandler(this.btnRemoveProColor_Click);
            // 
            // btnAddColor
            // 
            this.btnAddColor.Location = new System.Drawing.Point(777, 54);
            this.btnAddColor.Name = "btnAddColor";
            this.btnAddColor.Size = new System.Drawing.Size(34, 25);
            this.btnAddColor.TabIndex = 234;
            this.btnAddColor.Text = "+";
            this.btnAddColor.Click += new System.EventHandler(this.btnAddColor_Click);
            // 
            // cmbProColors
            // 
            this.cmbProColors.DropDownWidth = 85;
            this.cmbProColors.Location = new System.Drawing.Point(665, 54);
            this.cmbProColors.Name = "cmbProColors";
            this.cmbProColors.Size = new System.Drawing.Size(95, 28);
            this.cmbProColors.TabIndex = 233;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(581, 56);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel5.TabIndex = 232;
            this.kryptonLabel5.Text = "颜色列表：";
            // 
            // tbPerRow1
            // 
            this.tbPerRow1.Location = new System.Drawing.Point(480, 171);
            this.tbPerRow1.Name = "tbPerRow1";
            this.tbPerRow1.Size = new System.Drawing.Size(77, 27);
            this.tbPerRow1.TabIndex = 237;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(410, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 236;
            this.label4.Text = "行1高度：";
            // 
            // tbPerRow3
            // 
            this.tbPerRow3.Location = new System.Drawing.Point(480, 230);
            this.tbPerRow3.Name = "tbPerRow3";
            this.tbPerRow3.Size = new System.Drawing.Size(77, 27);
            this.tbPerRow3.TabIndex = 240;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(410, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 239;
            this.label7.Text = "行3高度：";
            // 
            // tbPerRow2
            // 
            this.tbPerRow2.Location = new System.Drawing.Point(480, 201);
            this.tbPerRow2.Name = "tbPerRow2";
            this.tbPerRow2.Size = new System.Drawing.Size(77, 27);
            this.tbPerRow2.TabIndex = 243;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(410, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 20);
            this.label9.TabIndex = 242;
            this.label9.Text = "行2高度：";
            // 
            // tbPerCol2
            // 
            this.tbPerCol2.Location = new System.Drawing.Point(784, 201);
            this.tbPerCol2.Name = "tbPerCol2";
            this.tbPerCol2.Size = new System.Drawing.Size(77, 27);
            this.tbPerCol2.TabIndex = 252;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(665, 204);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 20);
            this.label11.TabIndex = 251;
            this.label11.Text = "列2宽度：";
            // 
            // tbPerCol3
            // 
            this.tbPerCol3.Location = new System.Drawing.Point(784, 230);
            this.tbPerCol3.Name = "tbPerCol3";
            this.tbPerCol3.Size = new System.Drawing.Size(77, 27);
            this.tbPerCol3.TabIndex = 249;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(665, 233);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 20);
            this.label13.TabIndex = 248;
            this.label13.Text = "列3宽度：";
            // 
            // tbPerCol1
            // 
            this.tbPerCol1.Location = new System.Drawing.Point(784, 171);
            this.tbPerCol1.Name = "tbPerCol1";
            this.tbPerCol1.Size = new System.Drawing.Size(77, 27);
            this.tbPerCol1.TabIndex = 246;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(665, 174);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 20);
            this.label15.TabIndex = 245;
            this.label15.Text = "列1宽度";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 311);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(312, 20);
            this.label5.TabIndex = 253;
            this.label5.Text = "备注：行1+行2+行3=1；列1+列2+列3=1。\r\n";
            // 
            // ShowConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPerCol2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbPerCol3);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbPerCol1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbPerRow2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbPerRow3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbPerRow1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRemoveProColor);
            this.Controls.Add(this.btnAddColor);
            this.Controls.Add(this.cmbProColors);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.btnLoadPic);
            this.Controls.Add(this.tbPicName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.tbFilePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkShowPic);
            this.Controls.Add(this.chkShowRtData);
            this.Controls.Add(this.chkEnable);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbStations);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ShowConfigControl";
            this.Size = new System.Drawing.Size(896, 516);
            this.Load += new System.EventHandler(this.ShowConfigControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cmbStations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.CheckBox chkShowRtData;
        private System.Windows.Forms.CheckBox chkShowPic;
        private System.Windows.Forms.Button btnLoadPic;
        private System.Windows.Forms.TextBox tbPicName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRemoveProColor;
        private System.Windows.Forms.Button btnAddColor;
        private System.Windows.Forms.ComboBox cmbProColors;
        private System.Windows.Forms.Label kryptonLabel5;
        private System.Windows.Forms.TextBox tbPerRow1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPerRow3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbPerRow2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbPerCol2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbPerCol3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbPerCol1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label5;
    }
}
