using System.ComponentModel;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.Authority.Forms
{
    partial class PassWordForm
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
            this.lb_Password = new System.Windows.Forms.Label();
            this.lb_Username = new System.Windows.Forms.Label();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.txtPassWord = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.btnCancel = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnOK = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.gbLogout = new System.Windows.Forms.GroupBox();
            this.btnLogoutCancel = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnUpdate = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnLogout = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.txtUserName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.gbLogin.SuspendLayout();
            this.gbLogout.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_Password
            // 
            this.lb_Password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_Password.AutoSize = true;
            this.lb_Password.Location = new System.Drawing.Point(40, 24);
            this.lb_Password.Name = "lb_Password";
            this.lb_Password.Size = new System.Drawing.Size(93, 20);
            this.lb_Password.TabIndex = 4;
            this.lb_Password.Text = "Password：";
            // 
            // lb_Username
            // 
            this.lb_Username.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_Username.AutoSize = true;
            this.lb_Username.Location = new System.Drawing.Point(54, 77);
            this.lb_Username.Name = "lb_Username";
            this.lb_Username.Size = new System.Drawing.Size(97, 20);
            this.lb_Username.TabIndex = 5;
            this.lb_Username.Text = "Username：";
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.txtPassWord);
            this.gbLogin.Controls.Add(this.btnCancel);
            this.gbLogin.Controls.Add(this.btnOK);
            this.gbLogin.Controls.Add(this.lb_Password);
            this.gbLogin.Location = new System.Drawing.Point(14, 116);
            this.gbLogin.Margin = new System.Windows.Forms.Padding(0);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Padding = new System.Windows.Forms.Padding(0);
            this.gbLogin.Size = new System.Drawing.Size(390, 135);
            this.gbLogin.TabIndex = 12;
            this.gbLogin.TabStop = false;
            this.gbLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.gbLogin_Paint);
            // 
            // txtPassWord
            // 
            this.txtPassWord.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtPassWord.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.txtPassWord.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtPassWord.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtPassWord.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.txtPassWord.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtPassWord.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassWord.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtPassWord.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPassWord.Location = new System.Drawing.Point(153, 21);
            this.txtPassWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassWord.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtPassWord.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtPassWord.ShortcutsEnabled = false;
            this.txtPassWord.ShowText = false;
            this.txtPassWord.Size = new System.Drawing.Size(206, 27);
            this.txtPassWord.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.txtPassWord.TabIndex = 11;
            this.txtPassWord.Watermark = "请输入密码";
            this.txtPassWord.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(259, 75);
            this.btnCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 38);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(40, 75);
            this.btnOK.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 38);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "Login";
            this.btnOK.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gbLogout
            // 
            this.gbLogout.Controls.Add(this.btnLogoutCancel);
            this.gbLogout.Controls.Add(this.btnUpdate);
            this.gbLogout.Controls.Add(this.btnLogout);
            this.gbLogout.Location = new System.Drawing.Point(14, 116);
            this.gbLogout.Margin = new System.Windows.Forms.Padding(0);
            this.gbLogout.Name = "gbLogout";
            this.gbLogout.Padding = new System.Windows.Forms.Padding(0);
            this.gbLogout.Size = new System.Drawing.Size(390, 135);
            this.gbLogout.TabIndex = 11;
            this.gbLogout.TabStop = false;
            this.gbLogout.Paint += new System.Windows.Forms.PaintEventHandler(this.gbLogout_Paint);
            // 
            // btnLogoutCancel
            // 
            this.btnLogoutCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogoutCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogoutCancel.Location = new System.Drawing.Point(259, 75);
            this.btnLogoutCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLogoutCancel.Name = "btnLogoutCancel";
            this.btnLogoutCancel.Size = new System.Drawing.Size(100, 38);
            this.btnLogoutCancel.TabIndex = 13;
            this.btnLogoutCancel.Text = "Cancel";
            this.btnLogoutCancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogoutCancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnLogoutCancel.Click += new System.EventHandler(this.btnLogoutCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdate.Location = new System.Drawing.Point(40, 24);
            this.btnUpdate.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 38);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdate.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogout.Location = new System.Drawing.Point(40, 75);
            this.btnLogout.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 38);
            this.btnLogout.TabIndex = 13;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogout.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtUserName.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.txtUserName.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtUserName.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtUserName.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.txtUserName.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtUserName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtUserName.Location = new System.Drawing.Point(167, 74);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtUserName.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtUserName.ShowText = false;
            this.txtUserName.Size = new System.Drawing.Size(206, 27);
            this.txtUserName.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.txtUserName.TabIndex = 10;
            this.txtUserName.Watermark = "请输入账号";
            this.txtUserName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // PassWordForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(420, 260);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lb_Username);
            this.Controls.Add(this.gbLogin);
            this.Controls.Add(this.gbLogout);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(420, 260);
            this.MinimumSize = new System.Drawing.Size(420, 260);
            this.Name = "PassWordForm";
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.Text = "";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 433, 210);
            this.Load += new System.EventHandler(this.PassWordForm_Load);
            this.Shown += new System.EventHandler(this.PassWordForm_Shown);
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.gbLogout.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Label lb_Password;
        private Label lb_Username;
        private GroupBox gbLogin;
        private GroupBox gbLogout;
        private SunnyUI.Controls.UIButton btnCancel;
        private SunnyUI.Controls.UIButton btnOK;
        private SunnyUI.Controls.UIButton btnLogoutCancel;
        private SunnyUI.Controls.UIButton btnLogout;
        private SunnyUI.Controls.UITextBox txtPassWord;
        private SunnyUI.Controls.UITextBox txtUserName;
        private SunnyUI.Controls.UIButton btnUpdate;
    }
}

