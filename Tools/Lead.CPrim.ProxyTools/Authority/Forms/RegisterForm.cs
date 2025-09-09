using Lead.CPrim.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.Authority.Forms
{
	public class RegisterForm : Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

		private GroupBox groupBox1;

		private Label label2;

		private Label label1;

		private TextBox tBLvl;

		private TextBox tBRegisterCode;

		private Button btnRegister;

		public RegisterForm()
		{
			InitializeComponent();
		}

		public void Init()
		{
			string errMsg;
			if (AuthorityManager.Instance.CheckSoftLock(out errMsg) == -1)
			{
				MessageBox.Show(errMsg);
				btnRegister.Enabled = false;
			}
			if (!string.IsNullOrEmpty(AuthorityManager.Instance.CurRegisterCode))
			{
				tBRegisterCode.Text = AuthorityManager.Instance.CurRegisterCode;
				OpLevel maxLvlByRegisterCode = AuthorityManager.Instance.GetMaxLvlByRegisterCode(tBRegisterCode.Text, out errMsg);
				if (!string.IsNullOrEmpty(errMsg))
				{
					MessageBox.Show(errMsg);
				}
				if (maxLvlByRegisterCode != AuthorityManager.Instance.AccessLvl)
				{
					MessageBox.Show("当前激活码权限和加密狗允许权限不一致，请重新激活");
				}
				else
				{
					tBLvl.Text = maxLvlByRegisterCode.ToString();
				}
			}
			else
			{
				tBLvl.Text = "Other";
			}
		}

		private void btnRegister_Click(object sender, EventArgs e)
		{
			string errMsg;
			OpLevel maxLvlByRegisterCode = AuthorityManager.Instance.GetMaxLvlByRegisterCode(tBRegisterCode.Text.Trim(), out errMsg);
			if (!string.IsNullOrEmpty(errMsg))
			{
				MessageBox.Show(errMsg);
			}
			if (maxLvlByRegisterCode == OpLevel.Other)
			{
				MessageBox.Show("当前激活码未获取到软件任何权限，请确认激活码是否正确");
				tBLvl.Text = OpLevel.Other.ToString();
				return;
			}
			AuthorityManager.Instance.SoftwareRegister(tBRegisterCode.Text.Trim(), maxLvlByRegisterCode);
			tBLvl.Text = maxLvlByRegisterCode.ToString();
			if (AuthorityManager.Instance.Level == OpLevel.Other)
			{
				AuthorityManager.Instance.Level = OpLevel.NoLogin;
			}
			if (AuthorityManager.Instance.Level > maxLvlByRegisterCode)
			{
				AuthorityManager.Instance.Level = maxLvlByRegisterCode;
			}
		}

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tBLvl = new System.Windows.Forms.TextBox();
            this.tBRegisterCode = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRegister);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tBLvl);
            this.groupBox1.Controls.Add(this.tBRegisterCode);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(520, 237);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "注册";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(375, 68);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(63, 31);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "激活";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(33, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "权  限";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(33, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "注册码";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBLvl
            // 
            this.tBLvl.Enabled = false;
            this.tBLvl.Location = new System.Drawing.Point(122, 119);
            this.tBLvl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tBLvl.Name = "tBLvl";
            this.tBLvl.Size = new System.Drawing.Size(214, 24);
            this.tBLvl.TabIndex = 1;
            // 
            // tBRegisterCode
            // 
            this.tBRegisterCode.Location = new System.Drawing.Point(122, 72);
            this.tBRegisterCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tBRegisterCode.Name = "tBRegisterCode";
            this.tBRegisterCode.Size = new System.Drawing.Size(214, 24);
            this.tBRegisterCode.TabIndex = 0;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 237);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
	}
}

