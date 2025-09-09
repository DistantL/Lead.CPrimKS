
namespace VT曲线
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3_v = new System.Windows.Forms.TextBox();
            this.textBox2_a = new System.Windows.Forms.TextBox();
            this.textBox1_s = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox10_s3 = new System.Windows.Forms.TextBox();
            this.textBox9_s2 = new System.Windows.Forms.TextBox();
            this.textBox8_s1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox7_t = new System.Windows.Forms.TextBox();
            this.textBox6_t3 = new System.Windows.Forms.TextBox();
            this.textBox5_t2 = new System.Windows.Forms.TextBox();
            this.textBox4_t1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "S：mm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "a：mm/s2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "v：mm/s";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "t1：s";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "t2：s";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "t3：s";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox3_v);
            this.groupBox1.Controls.Add(this.textBox2_a);
            this.groupBox1.Controls.Add(this.textBox1_s);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(365, 112);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入参数：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(263, 77);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "计算";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3_v
            // 
            this.textBox3_v.Location = new System.Drawing.Point(96, 82);
            this.textBox3_v.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3_v.Name = "textBox3_v";
            this.textBox3_v.Size = new System.Drawing.Size(85, 25);
            this.textBox3_v.TabIndex = 5;
            // 
            // textBox2_a
            // 
            this.textBox2_a.Location = new System.Drawing.Point(96, 51);
            this.textBox2_a.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2_a.Name = "textBox2_a";
            this.textBox2_a.Size = new System.Drawing.Size(85, 25);
            this.textBox2_a.TabIndex = 4;
            // 
            // textBox1_s
            // 
            this.textBox1_s.Location = new System.Drawing.Point(96, 21);
            this.textBox1_s.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1_s.Name = "textBox1_s";
            this.textBox1_s.Size = new System.Drawing.Size(85, 25);
            this.textBox1_s.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox10_s3);
            this.groupBox2.Controls.Add(this.textBox9_s2);
            this.groupBox2.Controls.Add(this.textBox8_s1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox7_t);
            this.groupBox2.Controls.Add(this.textBox6_t3);
            this.groupBox2.Controls.Add(this.textBox5_t2);
            this.groupBox2.Controls.Add(this.textBox4_t1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 132);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(365, 196);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输出参数：";
            // 
            // textBox10_s3
            // 
            this.textBox10_s3.Location = new System.Drawing.Point(263, 88);
            this.textBox10_s3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox10_s3.Name = "textBox10_s3";
            this.textBox10_s3.Size = new System.Drawing.Size(88, 25);
            this.textBox10_s3.TabIndex = 15;
            // 
            // textBox9_s2
            // 
            this.textBox9_s2.Location = new System.Drawing.Point(263, 58);
            this.textBox9_s2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox9_s2.Name = "textBox9_s2";
            this.textBox9_s2.Size = new System.Drawing.Size(88, 25);
            this.textBox9_s2.TabIndex = 14;
            // 
            // textBox8_s1
            // 
            this.textBox8_s1.Location = new System.Drawing.Point(263, 28);
            this.textBox8_s1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox8_s1.Name = "textBox8_s1";
            this.textBox8_s1.Size = new System.Drawing.Size(88, 25);
            this.textBox8_s1.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(196, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 15);
            this.label10.TabIndex = 12;
            this.label10.Text = "s3：mm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(196, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 15);
            this.label9.TabIndex = 11;
            this.label9.Text = "s2：mm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(196, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "s1：mm";
            // 
            // textBox7_t
            // 
            this.textBox7_t.Location = new System.Drawing.Point(96, 118);
            this.textBox7_t.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox7_t.Name = "textBox7_t";
            this.textBox7_t.Size = new System.Drawing.Size(85, 25);
            this.textBox7_t.TabIndex = 9;
            // 
            // textBox6_t3
            // 
            this.textBox6_t3.Location = new System.Drawing.Point(96, 88);
            this.textBox6_t3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox6_t3.Name = "textBox6_t3";
            this.textBox6_t3.Size = new System.Drawing.Size(85, 25);
            this.textBox6_t3.TabIndex = 8;
            // 
            // textBox5_t2
            // 
            this.textBox5_t2.Location = new System.Drawing.Point(96, 58);
            this.textBox5_t2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox5_t2.Name = "textBox5_t2";
            this.textBox5_t2.Size = new System.Drawing.Size(85, 25);
            this.textBox5_t2.TabIndex = 7;
            // 
            // textBox4_t1
            // 
            this.textBox4_t1.Location = new System.Drawing.Point(96, 28);
            this.textBox4_t1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox4_t1.Name = "textBox4_t1";
            this.textBox4_t1.Size = new System.Drawing.Size(85, 25);
            this.textBox4_t1.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "t ：s";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(389, 140);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(311, 189);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.btnStar);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(389, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(311, 112);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "秒表计时：";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(176, 77);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 30);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "清零";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnStar
            // 
            this.btnStar.Location = new System.Drawing.Point(69, 77);
            this.btnStar.Name = "btnStar";
            this.btnStar.Size = new System.Drawing.Size(84, 30);
            this.btnStar.TabIndex = 2;
            this.btnStar.Text = "开始";
            this.btnStar.UseVisualStyleBackColor = true;
            this.btnStar.Click += new System.EventHandler(this.btnStar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 15);
            this.label12.TabIndex = 1;
            this.label12.Text = "计时：";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(68, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 30);
            this.label11.TabIndex = 0;
            this.label11.Text = "                    ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 338);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "VT曲线";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3_v;
        private System.Windows.Forms.TextBox textBox2_a;
        private System.Windows.Forms.TextBox textBox1_s;
        private System.Windows.Forms.TextBox textBox8_s1;
        private System.Windows.Forms.TextBox textBox7_t;
        private System.Windows.Forms.TextBox textBox6_t3;
        private System.Windows.Forms.TextBox textBox5_t2;
        private System.Windows.Forms.TextBox textBox4_t1;
        private System.Windows.Forms.TextBox textBox10_s3;
        private System.Windows.Forms.TextBox textBox9_s2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
    }
}

