using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.FaiHelper.ComplexFais
{
	public class NewComplexForm : Form
	{
		public int CaveCount { get; set; } = 1;



		public NewComplexForm()
		{
			InitializeComponent();
		}



		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
			{
				e.Handled = true;
			}
		}
		private void btnEnter_Click(object sender, EventArgs e)
		{
			int count = 0;
			if (!int.TryParse(textBox1.Text, out count) || count < 1)
			{
				MessageBox.Show("请输入正确格式");
				base.DialogResult = DialogResult.Cancel;
			}
			else
			{
				CaveCount = count;
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}







        #region System
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        private TextBox textBox1;

        private Button btnEnter;

        private Label label1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new System.Windows.Forms.TextBox();
            btnEnter = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            textBox1.Location = new System.Drawing.Point(17, 85);
            textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(128, 23);
            textBox1.TabIndex = 0;
            textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
            btnEnter.Location = new System.Drawing.Point(162, 71);
            btnEnter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new System.Drawing.Size(93, 55);
            btnEnter.TabIndex = 1;
            btnEnter.Text = "确认";
            btnEnter.UseVisualStyleBackColor = true;
            btnEnter.Click += new System.EventHandler(btnEnter_Click);
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("宋体", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            label1.Location = new System.Drawing.Point(14, 42);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(110, 16);
            label1.TabIndex = 2;
            label1.Text = "输入穴位数量";
            base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            base.ClientSize = new System.Drawing.Size(281, 157);
            base.Controls.Add(label1);
            base.Controls.Add(btnEnter);
            base.Controls.Add(textBox1);
            Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            base.Name = "NewComplexForm";
            Text = "新建复杂FAI配置";
            ResumeLayout(false);
            PerformLayout();
        } 
        #endregion
    }
}
