
namespace Lead.CPrim.ProxyTools.Authority.Forms
{
    partial class FrmLogOutConfirm
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
            this.lb_Tip = new System.Windows.Forms.Label();
            this.btnCancel = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnOK = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.SuspendLayout();
            // 
            // lb_Tip
            // 
            this.lb_Tip.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_Tip.AutoSize = true;
            this.lb_Tip.Location = new System.Drawing.Point(60, 62);
            this.lb_Tip.Name = "lb_Tip";
            this.lb_Tip.Size = new System.Drawing.Size(166, 21);
            this.lb_Tip.TabIndex = 14;
            this.lb_Tip.Text = "Confirm to log out ?";
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FillColor = System.Drawing.SystemColors.ControlDark;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(378, 115);
            this.btnCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RectColor = System.Drawing.SystemColors.ControlDark;
            this.btnCancel.Size = new System.Drawing.Size(100, 38);
            this.btnCancel.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.FillColor = System.Drawing.SystemColors.ControlDark;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(253, 115);
            this.btnOK.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnOK.Name = "btnOK";
            this.btnOK.RectColor = System.Drawing.SystemColors.ControlDark;
            this.btnOK.Size = new System.Drawing.Size(100, 38);
            this.btnOK.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "Yes";
            this.btnOK.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmLogOutConfirm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(531, 178);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lb_Tip);
            this.Name = "FrmLogOutConfirm";
            this.RectColor = System.Drawing.Color.Gray;
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.Text = "Log Out";
            this.TextAlignment = System.Drawing.StringAlignment.Center;
            this.TitleColor = System.Drawing.SystemColors.Control;
            this.TitleForeColor = System.Drawing.Color.Black;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 531, 178);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_Tip;
        private SunnyUI.Controls.UIButton btnCancel;
        private SunnyUI.Controls.UIButton btnOK;
    }
}