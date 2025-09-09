using System.ComponentModel;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.Authority.Forms
{
    partial class AudioPassWord2StepForm
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
            this.labID = new System.Windows.Forms.Label();
            this.labUser = new System.Windows.Forms.Label();
            this.txtID = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.txtUserName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.labFun = new System.Windows.Forms.Label();
            this.txtFun = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.uiLine2 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILine();
            this.btnOK = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnCancel = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.labTip = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.labLevel = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.lb_Tips = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.gbLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // labID
            // 
            this.labID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labID.AutoSize = true;
            this.labID.Location = new System.Drawing.Point(54, 135);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(75, 17);
            this.labID.TabIndex = 4;
            this.labID.Text = "Badge ID：";
            // 
            // labUser
            // 
            this.labUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labUser.AutoSize = true;
            this.labUser.Location = new System.Drawing.Point(54, 79);
            this.labUser.Name = "labUser";
            this.labUser.Size = new System.Drawing.Size(86, 17);
            this.labUser.TabIndex = 5;
            this.labUser.Text = "User Name：";
            // 
            // txtID
            // 
            this.txtID.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtID.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.txtID.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtID.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtID.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.txtID.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtID.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtID.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtID.Location = new System.Drawing.Point(167, 132);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtID.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtID.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtID.ShortcutsEnabled = false;
            this.txtID.ShowText = false;
            this.txtID.Size = new System.Drawing.Size(206, 27);
            this.txtID.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.txtID.TabIndex = 11;
            this.txtID.Watermark = "ID卡号";
            this.txtID.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.txtUserName.ReadOnly = true;
            this.txtUserName.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtUserName.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtUserName.ShowText = false;
            this.txtUserName.Size = new System.Drawing.Size(206, 27);
            this.txtUserName.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.txtUserName.TabIndex = 10;
            this.txtUserName.Watermark = "用户名";
            this.txtUserName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // labFun
            // 
            this.labFun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labFun.AutoSize = true;
            this.labFun.Location = new System.Drawing.Point(54, 195);
            this.labFun.Name = "labFun";
            this.labFun.Size = new System.Drawing.Size(68, 17);
            this.labFun.TabIndex = 12;
            this.labFun.Text = "Function：";
            // 
            // txtFun
            // 
            this.txtFun.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtFun.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.txtFun.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtFun.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtFun.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.txtFun.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtFun.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFun.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtFun.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtFun.Location = new System.Drawing.Point(167, 190);
            this.txtFun.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFun.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtFun.Name = "txtFun";
            this.txtFun.ReadOnly = true;
            this.txtFun.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtFun.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtFun.ShowText = false;
            this.txtFun.Size = new System.Drawing.Size(206, 27);
            this.txtFun.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.txtFun.TabIndex = 13;
            this.txtFun.Watermark = "供应商";
            this.txtFun.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLine2
            // 
            this.uiLine2.BackColor = System.Drawing.Color.Transparent;
            this.uiLine2.FillColor = System.Drawing.Color.Transparent;
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine2.LineColor = System.Drawing.Color.Silver;
            this.uiLine2.Location = new System.Drawing.Point(17, 232);
            this.uiLine2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(388, 10);
            this.uiLine2.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiLine2.TabIndex = 14;
            this.uiLine2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Enabled = false;
            this.btnOK.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnOK.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnOK.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnOK.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnOK.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(26, 143);
            this.btnOK.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnOK.Name = "btnOK";
            this.btnOK.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnOK.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnOK.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnOK.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnOK.Size = new System.Drawing.Size(100, 38);
            this.btnOK.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.btnOK.StyleCustomMode = true;
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "Login";
            this.btnOK.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnCancel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnCancel.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnCancel.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnCancel.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(258, 143);
            this.btnCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnCancel.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnCancel.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnCancel.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnCancel.Size = new System.Drawing.Size(100, 38);
            this.btnCancel.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.btnCancel.StyleCustomMode = true;
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labTip
            // 
            this.labTip.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTip.Location = new System.Drawing.Point(25, 16);
            this.labTip.Name = "labTip";
            this.labTip.Size = new System.Drawing.Size(333, 23);
            this.labTip.TabIndex = 14;
            this.labTip.Text = "Your  access  level  is";
            this.labTip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labTip.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // labLevel
            // 
            this.labLevel.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labLevel.Location = new System.Drawing.Point(29, 59);
            this.labLevel.Name = "labLevel";
            this.labLevel.Size = new System.Drawing.Size(329, 38);
            this.labLevel.TabIndex = 15;
            this.labLevel.Text = "NoLogin";
            this.labLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labLevel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.lb_Tips);
            this.gbLogin.Controls.Add(this.labLevel);
            this.gbLogin.Controls.Add(this.labTip);
            this.gbLogin.Controls.Add(this.btnCancel);
            this.gbLogin.Controls.Add(this.btnOK);
            this.gbLogin.Location = new System.Drawing.Point(15, 237);
            this.gbLogin.Margin = new System.Windows.Forms.Padding(0);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Padding = new System.Windows.Forms.Padding(0);
            this.gbLogin.Size = new System.Drawing.Size(390, 196);
            this.gbLogin.TabIndex = 12;
            this.gbLogin.TabStop = false;
            // 
            // lb_Tips
            // 
            this.lb_Tips.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Tips.Location = new System.Drawing.Point(31, 107);
            this.lb_Tips.Name = "lb_Tips";
            this.lb_Tips.Size = new System.Drawing.Size(333, 23);
            this.lb_Tips.TabIndex = 16;
            this.lb_Tips.Text = "Your  access  level  is";
            this.lb_Tips.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_Tips.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // AudioPassWord2StepForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(420, 450);
            this.Controls.Add(this.uiLine2);
            this.Controls.Add(this.txtFun);
            this.Controls.Add(this.labFun);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.labUser);
            this.Controls.Add(this.gbLogin);
            this.Controls.Add(this.labID);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(420, 450);
            this.MinimumSize = new System.Drawing.Size(420, 450);
            this.Name = "AudioPassWord2StepForm";
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "2-Step-Verification";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 433, 210);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AudioPassWordForm_FormClosed);
            this.gbLogin.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Label labID;
        private Label labUser;
        private SunnyUI.Controls.UITextBox txtUserName;
        private Label labFun;
        public SunnyUI.Controls.UITextBox txtID;
        private SunnyUI.Controls.UITextBox txtFun;
        private SunnyUI.Controls.UILine uiLine2;
        private SunnyUI.Controls.UIButton btnOK;
        private SunnyUI.Controls.UIButton btnCancel;
        private SunnyUI.Controls.UILabel labTip;
        private SunnyUI.Controls.UILabel labLevel;
        private GroupBox gbLogin;
        private SunnyUI.Controls.UILabel lb_Tips;
    }
}

