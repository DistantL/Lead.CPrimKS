
namespace Lead.CPrim.ProxyTools.Authority.Forms
{
    partial class Frm_LAD_ModeSelect
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
            this.rq_ModeSelect = new Sunny.UI.UIRadioButtonGroup();
            this.btnCancel = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnOK = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.SuspendLayout();
            // 
            // rq_ModeSelect
            // 
            this.rq_ModeSelect.BackColor = System.Drawing.Color.Transparent;
            this.rq_ModeSelect.ColumnCount = 3;
            this.rq_ModeSelect.FillColor = System.Drawing.Color.Transparent;
            this.rq_ModeSelect.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.rq_ModeSelect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rq_ModeSelect.Items.AddRange(new object[] {
            "GRR",
            "CPK",
            "SCS"});
            this.rq_ModeSelect.Location = new System.Drawing.Point(48, 40);
            this.rq_ModeSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rq_ModeSelect.MinimumSize = new System.Drawing.Size(1, 1);
            this.rq_ModeSelect.Name = "rq_ModeSelect";
            this.rq_ModeSelect.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.rq_ModeSelect.RectColor = System.Drawing.Color.Transparent;
            this.rq_ModeSelect.Size = new System.Drawing.Size(416, 75);
            this.rq_ModeSelect.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.rq_ModeSelect.StyleCustomMode = true;
            this.rq_ModeSelect.TabIndex = 0;
            this.rq_ModeSelect.Text = null;
            this.rq_ModeSelect.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.rq_ModeSelect.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FillColor = System.Drawing.Color.Silver;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(364, 123);
            this.btnCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RectColor = System.Drawing.Color.Silver;
            this.btnCancel.Size = new System.Drawing.Size(100, 38);
            this.btnCancel.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnCancel.StyleCustomMode = true;
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.FillColor = System.Drawing.Color.Silver;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(239, 123);
            this.btnOK.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnOK.Name = "btnOK";
            this.btnOK.RectColor = System.Drawing.Color.Silver;
            this.btnOK.Size = new System.Drawing.Size(100, 38);
            this.btnOK.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnOK.StyleCustomMode = true;
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "OK";
            this.btnOK.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // Frm_LAD_ModeSelect
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(525, 179);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rq_ModeSelect);
            this.Name = "Frm_LAD_ModeSelect";
            this.RectColor = System.Drawing.Color.Transparent;
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "LAD_ModeSelect";
            this.TitleColor = System.Drawing.Color.Gray;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 525, 156);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIRadioButtonGroup rq_ModeSelect;
        private SunnyUI.Controls.UIButton btnCancel;
        private SunnyUI.Controls.UIButton btnOK;
    }
}