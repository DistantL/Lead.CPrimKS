using System.ComponentModel;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.Authority.Forms
{
    partial class OperateLoginForm
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
            this.lb_ID = new System.Windows.Forms.Label();
            this.labSelect = new System.Windows.Forms.Label();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.txtID = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.btnCancel = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnOK = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.gbLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_ID
            // 
            this.lb_ID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_ID.AutoSize = true;
            this.lb_ID.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_ID.Location = new System.Drawing.Point(31, 39);
            this.lb_ID.Name = "lb_ID";
            this.lb_ID.Size = new System.Drawing.Size(91, 20);
            this.lb_ID.TabIndex = 4;
            this.lb_ID.Text = "Operator：";
            this.lb_ID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labSelect
            // 
            this.labSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labSelect.AutoSize = true;
            this.labSelect.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labSelect.ForeColor = System.Drawing.Color.OrangeRed;
            this.labSelect.Location = new System.Drawing.Point(10, 55);
            this.labSelect.Name = "labSelect";
            this.labSelect.Size = new System.Drawing.Size(56, 19);
            this.labSelect.TabIndex = 5;
            this.labSelect.Text = "PD-01";
            this.labSelect.DoubleClick += new System.EventHandler(this.labSelect_DoubleClick);
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.txtID);
            this.gbLogin.Controls.Add(this.btnCancel);
            this.gbLogin.Controls.Add(this.btnOK);
            this.gbLogin.Controls.Add(this.lb_ID);
            this.gbLogin.Location = new System.Drawing.Point(14, 89);
            this.gbLogin.Margin = new System.Windows.Forms.Padding(0);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Padding = new System.Windows.Forms.Padding(0);
            this.gbLogin.Size = new System.Drawing.Size(390, 153);
            this.gbLogin.TabIndex = 12;
            this.gbLogin.TabStop = false;
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
            this.txtID.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtID.Location = new System.Drawing.Point(153, 38);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtID.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtID.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtID.ShortcutsEnabled = false;
            this.txtID.ShowText = false;
            this.txtID.Size = new System.Drawing.Size(206, 27);
            this.txtID.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.txtID.TabIndex = 11;
            this.txtID.Watermark = "ID卡号";
            this.txtID.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(259, 90);
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
            this.btnOK.Location = new System.Drawing.Point(44, 90);
            this.btnOK.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 38);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // OperateLoginForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(420, 260);
            this.Controls.Add(this.labSelect);
            this.Controls.Add(this.gbLogin);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(420, 260);
            this.MinimumSize = new System.Drawing.Size(420, 260);
            this.Name = "OperateLoginForm";
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.Text = "Double Confirm";
            this.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 433, 210);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OperateLoginForm_FormClosing);
            this.Load += new System.EventHandler(this.OperateLoginForm_Load);
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Label lb_ID;
        private Label labSelect;
        private GroupBox gbLogin;
        private SunnyUI.Controls.UIButton btnCancel;
        private SunnyUI.Controls.UIButton btnOK;
        private SunnyUI.Controls.UITextBox txtID;

        #endregion
    }
}