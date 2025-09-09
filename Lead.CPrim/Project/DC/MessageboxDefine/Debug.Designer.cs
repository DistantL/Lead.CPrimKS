namespace MessageboxDefine
{
    partial class Debug
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.PDCA = new System.Windows.Forms.TabPage();
            this.tbDT = new System.Windows.Forms.TextBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.tbX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rtbPDCAMes = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnManyPDCA = new System.Windows.Forms.Button();
            this.btnPDCA = new System.Windows.Forms.Button();
            this.tbPDCACode = new System.Windows.Forms.TextBox();
            this.动静态 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCameraDownStatic = new System.Windows.Forms.Button();
            this.btnCameraDownDynamic = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCameraUpStatic = new System.Windows.Forms.Button();
            this.btnCameraUpDynamic = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbState = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSFL = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.PDCA.SuspendLayout();
            this.动静态.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.PDCA);
            this.tabControl1.Controls.Add(this.动静态);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 360);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // PDCA
            // 
            this.PDCA.Controls.Add(this.btnSFL);
            this.PDCA.Controls.Add(this.tbDT);
            this.PDCA.Controls.Add(this.tbY);
            this.PDCA.Controls.Add(this.tbX);
            this.PDCA.Controls.Add(this.label6);
            this.PDCA.Controls.Add(this.label5);
            this.PDCA.Controls.Add(this.label4);
            this.PDCA.Controls.Add(this.rtbPDCAMes);
            this.PDCA.Controls.Add(this.label3);
            this.PDCA.Controls.Add(this.btnManyPDCA);
            this.PDCA.Controls.Add(this.btnPDCA);
            this.PDCA.Controls.Add(this.tbPDCACode);
            this.PDCA.Location = new System.Drawing.Point(4, 30);
            this.PDCA.Name = "PDCA";
            this.PDCA.Padding = new System.Windows.Forms.Padding(3);
            this.PDCA.Size = new System.Drawing.Size(592, 326);
            this.PDCA.TabIndex = 2;
            this.PDCA.Text = "上传";
            this.PDCA.UseVisualStyleBackColor = true;
            // 
            // tbDT
            // 
            this.tbDT.Location = new System.Drawing.Point(468, 50);
            this.tbDT.Name = "tbDT";
            this.tbDT.Size = new System.Drawing.Size(100, 29);
            this.tbDT.TabIndex = 7;
            this.tbDT.Text = "0";
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(255, 50);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(100, 29);
            this.tbY.TabIndex = 7;
            this.tbY.Text = "1.16";
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(53, 50);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(100, 29);
            this.tbX.TabIndex = 7;
            this.tbX.Text = "0.89";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(428, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "DT:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "Y:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "X:";
            // 
            // rtbPDCAMes
            // 
            this.rtbPDCAMes.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbPDCAMes.Location = new System.Drawing.Point(24, 85);
            this.rtbPDCAMes.Name = "rtbPDCAMes";
            this.rtbPDCAMes.Size = new System.Drawing.Size(544, 174);
            this.rtbPDCAMes.TabIndex = 5;
            this.rtbPDCAMes.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "SN：";
            // 
            // btnManyPDCA
            // 
            this.btnManyPDCA.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnManyPDCA.Location = new System.Drawing.Point(408, 265);
            this.btnManyPDCA.Name = "btnManyPDCA";
            this.btnManyPDCA.Size = new System.Drawing.Size(160, 50);
            this.btnManyPDCA.TabIndex = 3;
            this.btnManyPDCA.Text = "PDCA批量过站";
            this.btnManyPDCA.UseVisualStyleBackColor = true;
            this.btnManyPDCA.Click += new System.EventHandler(this.btnManyPDCA_Click);
            // 
            // btnPDCA
            // 
            this.btnPDCA.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPDCA.Location = new System.Drawing.Point(216, 265);
            this.btnPDCA.Name = "btnPDCA";
            this.btnPDCA.Size = new System.Drawing.Size(160, 50);
            this.btnPDCA.TabIndex = 3;
            this.btnPDCA.Text = "PDCA手动过站";
            this.btnPDCA.UseVisualStyleBackColor = true;
            this.btnPDCA.Click += new System.EventHandler(this.btnPDCA_Click);
            // 
            // tbPDCACode
            // 
            this.tbPDCACode.Location = new System.Drawing.Point(92, 15);
            this.tbPDCACode.Name = "tbPDCACode";
            this.tbPDCACode.Size = new System.Drawing.Size(476, 29);
            this.tbPDCACode.TabIndex = 2;
            // 
            // 动静态
            // 
            this.动静态.Controls.Add(this.tableLayoutPanel1);
            this.动静态.Controls.Add(this.panel1);
            this.动静态.Location = new System.Drawing.Point(4, 30);
            this.动静态.Name = "动静态";
            this.动静态.Padding = new System.Windows.Forms.Padding(3);
            this.动静态.Size = new System.Drawing.Size(592, 326);
            this.动静态.TabIndex = 3;
            this.动静态.Text = "动静态";
            this.动静态.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 68);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(586, 255);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCameraDownStatic);
            this.groupBox3.Controls.Add(this.btnCameraDownDynamic);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(293, 60);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox3.Size = new System.Drawing.Size(293, 195);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "下相机";
            // 
            // btnCameraDownStatic
            // 
            this.btnCameraDownStatic.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCameraDownStatic.Location = new System.Drawing.Point(32, 122);
            this.btnCameraDownStatic.Name = "btnCameraDownStatic";
            this.btnCameraDownStatic.Size = new System.Drawing.Size(235, 44);
            this.btnCameraDownStatic.TabIndex = 0;
            this.btnCameraDownStatic.Text = "静态测试";
            this.btnCameraDownStatic.UseVisualStyleBackColor = true;
            this.btnCameraDownStatic.Click += new System.EventHandler(this.btnCameraDownStatic_Click);
            // 
            // btnCameraDownDynamic
            // 
            this.btnCameraDownDynamic.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCameraDownDynamic.Location = new System.Drawing.Point(32, 56);
            this.btnCameraDownDynamic.Name = "btnCameraDownDynamic";
            this.btnCameraDownDynamic.Size = new System.Drawing.Size(235, 44);
            this.btnCameraDownDynamic.TabIndex = 0;
            this.btnCameraDownDynamic.Text = "动态测试";
            this.btnCameraDownDynamic.UseVisualStyleBackColor = true;
            this.btnCameraDownDynamic.Click += new System.EventHandler(this.btnCameraDownDynamic_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCameraUpStatic);
            this.groupBox2.Controls.Add(this.btnCameraUpDynamic);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 60);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox2.Size = new System.Drawing.Size(293, 195);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "上相机";
            // 
            // btnCameraUpStatic
            // 
            this.btnCameraUpStatic.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCameraUpStatic.Location = new System.Drawing.Point(21, 122);
            this.btnCameraUpStatic.Name = "btnCameraUpStatic";
            this.btnCameraUpStatic.Size = new System.Drawing.Size(235, 44);
            this.btnCameraUpStatic.TabIndex = 0;
            this.btnCameraUpStatic.Text = "静态测试";
            this.btnCameraUpStatic.UseVisualStyleBackColor = true;
            this.btnCameraUpStatic.Click += new System.EventHandler(this.btnCameraUpStatic_Click);
            // 
            // btnCameraUpDynamic
            // 
            this.btnCameraUpDynamic.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCameraUpDynamic.Location = new System.Drawing.Point(21, 56);
            this.btnCameraUpDynamic.Name = "btnCameraUpDynamic";
            this.btnCameraUpDynamic.Size = new System.Drawing.Size(235, 44);
            this.btnCameraUpDynamic.TabIndex = 0;
            this.btnCameraUpDynamic.Text = "动态测试";
            this.btnCameraUpDynamic.UseVisualStyleBackColor = true;
            this.btnCameraUpDynamic.Click += new System.EventHandler(this.btnCameraUpDynamic_Click);
            // 
            // groupBox4
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox4, 2);
            this.groupBox4.Controls.Add(this.numericUpDown1);
            this.groupBox4.Controls.Add(this.tbCount);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.lbCount);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox4.Size = new System.Drawing.Size(586, 60);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(407, 21);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(130, 29);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // tbCount
            // 
            this.tbCount.Location = new System.Drawing.Point(135, 21);
            this.tbCount.Name = "tbCount";
            this.tbCount.Size = new System.Drawing.Size(130, 29);
            this.tbCount.TabIndex = 1;
            this.tbCount.Text = "100";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(312, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "拍照前延时";
            this.label7.DoubleClick += new System.EventHandler(this.lbCount_DoubleClick);
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(57, 25);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(74, 21);
            this.lbCount.TabIndex = 0;
            this.lbCount.Text = "测试次数";
            this.lbCount.DoubleClick += new System.EventHandler(this.lbCount_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbState);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(586, 65);
            this.panel1.TabIndex = 1;
            // 
            // lbState
            // 
            this.lbState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbState.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbState.ForeColor = System.Drawing.Color.Blue;
            this.lbState.Location = new System.Drawing.Point(0, 0);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(586, 65);
            this.lbState.TabIndex = 0;
            this.lbState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSFL
            // 
            this.btnSFL.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSFL.Location = new System.Drawing.Point(24, 265);
            this.btnSFL.Name = "btnSFL";
            this.btnSFL.Size = new System.Drawing.Size(160, 50);
            this.btnSFL.TabIndex = 8;
            this.btnSFL.Text = "SFL手动过站";
            this.btnSFL.UseVisualStyleBackColor = true;
            this.btnSFL.Click += new System.EventHandler(this.btnSFL_Click);
            // 
            // Debug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Debug";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "手动测试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Debug_FormClosing);
            this.Load += new System.EventHandler(this.Debug_Load);
            this.tabControl1.ResumeLayout(false);
            this.PDCA.ResumeLayout(false);
            this.PDCA.PerformLayout();
            this.动静态.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage PDCA;
        private System.Windows.Forms.Button btnPDCA;
        private System.Windows.Forms.TextBox tbPDCACode;
        private System.Windows.Forms.RichTextBox rtbPDCAMes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDT;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage 动静态;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCameraDownStatic;
        private System.Windows.Forms.Button btnCameraDownDynamic;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCameraUpStatic;
        private System.Windows.Forms.Button btnCameraUpDynamic;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbCount;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbState;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnManyPDCA;
        private System.Windows.Forms.Button btnSFL;
    }
}