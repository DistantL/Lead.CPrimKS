using System.ComponentModel;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.Authority.Forms
{
    public partial class AuthorityUpdate
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

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
            this.txtUserName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.btnOK = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnCancel = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.txtOldPassWord = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.uiLabel1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel2 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.txtNewPassWord = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.uiLabel3 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.txtConfirmNewPassWord = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.uiLabel4 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserName.Location = new System.Drawing.Point(183, 74);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ShowText = false;
            this.txtUserName.Size = new System.Drawing.Size(190, 27);
            this.txtUserName.TabIndex = 3;
            this.txtUserName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(54, 286);
            this.btnOK.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(118, 38);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Update";
            this.btnOK.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(255, 286);
            this.btnCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 38);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtOldPassWord
            // 
            this.txtOldPassWord.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOldPassWord.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOldPassWord.Location = new System.Drawing.Point(183, 121);
            this.txtOldPassWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOldPassWord.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtOldPassWord.Name = "txtOldPassWord";
            this.txtOldPassWord.PasswordChar = '*';
            this.txtOldPassWord.ShortcutsEnabled = false;
            this.txtOldPassWord.ShowText = false;
            this.txtOldPassWord.Size = new System.Drawing.Size(190, 27);
            this.txtOldPassWord.TabIndex = 3;
            this.txtOldPassWord.Watermark = "请输入旧密码";
            this.txtOldPassWord.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel1.Location = new System.Drawing.Point(54, 79);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(82, 17);
            this.uiLabel1.TabIndex = 5;
            this.uiLabel1.Text = "UserName：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel2.Location = new System.Drawing.Point(54, 126);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 17);
            this.uiLabel2.TabIndex = 5;
            this.uiLabel2.Text = "OldPassWord：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtNewPassWord
            // 
            this.txtNewPassWord.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPassWord.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNewPassWord.Location = new System.Drawing.Point(183, 168);
            this.txtNewPassWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNewPassWord.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtNewPassWord.Name = "txtNewPassWord";
            this.txtNewPassWord.PasswordChar = '*';
            this.txtNewPassWord.ShortcutsEnabled = false;
            this.txtNewPassWord.ShowText = false;
            this.txtNewPassWord.Size = new System.Drawing.Size(190, 27);
            this.txtNewPassWord.TabIndex = 3;
            this.txtNewPassWord.Watermark = "请输入新密码";
            this.txtNewPassWord.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel3.Location = new System.Drawing.Point(54, 173);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(105, 17);
            this.uiLabel3.TabIndex = 5;
            this.uiLabel3.Text = "NewPassWord：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtConfirmNewPassWord
            // 
            this.txtConfirmNewPassWord.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmNewPassWord.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConfirmNewPassWord.Location = new System.Drawing.Point(183, 215);
            this.txtConfirmNewPassWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConfirmNewPassWord.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtConfirmNewPassWord.Name = "txtConfirmNewPassWord";
            this.txtConfirmNewPassWord.PasswordChar = '*';
            this.txtConfirmNewPassWord.ShortcutsEnabled = false;
            this.txtConfirmNewPassWord.ShowText = false;
            this.txtConfirmNewPassWord.Size = new System.Drawing.Size(190, 27);
            this.txtConfirmNewPassWord.TabIndex = 3;
            this.txtConfirmNewPassWord.Watermark = "请二次输入新密码";
            this.txtConfirmNewPassWord.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.AutoSize = true;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel4.Location = new System.Drawing.Point(54, 220);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(125, 17);
            this.uiLabel4.TabIndex = 5;
            this.uiLabel4.Text = "ConfirmPassWord：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // AuthorityUpdate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(420, 345);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.txtConfirmNewPassWord);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtNewPassWord);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtOldPassWord);
            this.Controls.Add(this.txtUserName);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AuthorityUpdate";
            this.Text = "Update";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 404, 221);
            this.Load += new System.EventHandler(this.AuthorityMngForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        private SunnyUI.Controls.UITextBox txtUserName;
        private SunnyUI.Controls.UIButton btnOK;
        private SunnyUI.Controls.UIButton btnCancel;
        private SunnyUI.Controls.UITextBox txtOldPassWord;
        private SunnyUI.Controls.UILabel uiLabel1;
        private SunnyUI.Controls.UILabel uiLabel2;
        private SunnyUI.Controls.UITextBox txtNewPassWord;
        private SunnyUI.Controls.UILabel uiLabel3;
        private SunnyUI.Controls.UITextBox txtConfirmNewPassWord;
        private SunnyUI.Controls.UILabel uiLabel4;
    }
}

