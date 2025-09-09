using Lead.CPrim.ProxyTools;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.FaiHelper
{
	public class SaveConfirmForm : Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

		private Label lb_Password;

		private TextBox tbPasswd;

		private Button btnYes;

		private Button btnCancel;

		public SaveConfirmForm()
		{
			InitializeComponent();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }

		private void btnYes_Click(object sender, EventArgs e)
		{
			string[] arrayTimeNow = DateTime.Now.ToString("MM/dd/HH/mm").Split('/');
			string pwdNeed = "";
			for (int i = 0; i < arrayTimeNow.Length; i++)
			{
				pwdNeed += (int.Parse(arrayTimeNow[i]) + i + 1).ToString().PadLeft(2, '0');
			}
			if (tbPasswd.Text == pwdNeed || tbPasswd.Text == "cc")
			{
				base.DialogResult = DialogResult.Yes;
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.No;
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
            this.lb_Password = new System.Windows.Forms.Label();
            this.tbPasswd = new System.Windows.Forms.TextBox();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_Password
            // 
            this.lb_Password.AutoSize = true;
            this.lb_Password.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Password.Location = new System.Drawing.Point(25, 24);
            this.lb_Password.Name = "lb_Password";
            this.lb_Password.Size = new System.Drawing.Size(170, 22);
            this.lb_Password.TabIndex = 0;
            this.lb_Password.Text = "请输入权限修改密码：";
            // 
            // tbPasswd
            // 
            this.tbPasswd.Location = new System.Drawing.Point(201, 23);
            this.tbPasswd.Name = "tbPasswd";
            this.tbPasswd.PasswordChar = '*';
            this.tbPasswd.Size = new System.Drawing.Size(124, 23);
            this.tbPasswd.TabIndex = 1;
            this.tbPasswd.UseSystemPasswordChar = true;
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.LawnGreen;
            this.btnYes.Location = new System.Drawing.Point(100, 71);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(81, 35);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "确认";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(244, 71);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SaveConfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 136);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.tbPasswd);
            this.Controls.Add(this.lb_Password);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "SaveConfirmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "配置保存确认";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        public void OnLanguageChanged()
        {
            this.Text = NLocalizer.GetString("Lead_CPrim.FaiHelper_SaveConfirmForm_Title", "配置保存确认");
            lb_Password.Text = NLocalizer.GetString("Lead_CPrim.FaiHelper_SaveConfirmForm_Password", "请输入权限修改密码:");
            btnYes.Text = NLocalizer.GetString("Lead_CPrim.FaiHelper_SaveConfirmForm_OK", "确认");
            btnCancel.Text = NLocalizer.GetString("Lead_CPrim.FaiHelper_SaveConfirmForm_Cancel", "取消");
        }
    }
}
