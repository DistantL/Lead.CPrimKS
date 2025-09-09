
namespace Lead.CPrim.Controls
{
    partial class ScanningSN_Form
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
            this.lb_Scanning = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.tb_SN = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.bt_Cancel = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.bt_OK = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.SuspendLayout();
            // 
            // lb_Scanning
            // 
            this.lb_Scanning.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Scanning.Location = new System.Drawing.Point(34, 65);
            this.lb_Scanning.Name = "lb_Scanning";
            this.lb_Scanning.Size = new System.Drawing.Size(121, 35);
            this.lb_Scanning.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lb_Scanning.TabIndex = 0;
            this.lb_Scanning.Text = "Scanning SN :";
            this.lb_Scanning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_Scanning.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tb_SN
            // 
            this.tb_SN.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.tb_SN.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.tb_SN.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.tb_SN.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.tb_SN.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.tb_SN.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.tb_SN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_SN.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.tb_SN.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_SN.Location = new System.Drawing.Point(152, 68);
            this.tb_SN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_SN.MinimumSize = new System.Drawing.Size(1, 16);
            this.tb_SN.Name = "tb_SN";
            this.tb_SN.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.tb_SN.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.tb_SN.ShowText = false;
            this.tb_SN.Size = new System.Drawing.Size(307, 29);
            this.tb_SN.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.tb_SN.StyleCustomMode = true;
            this.tb_SN.TabIndex = 1;
            this.tb_SN.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tb_SN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_SN_KeyDown);
            this.tb_SN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_SN_KeyUp);
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Cancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.bt_Cancel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.bt_Cancel.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.bt_Cancel.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bt_Cancel.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bt_Cancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Cancel.Location = new System.Drawing.Point(359, 109);
            this.bt_Cancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.bt_Cancel.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.bt_Cancel.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bt_Cancel.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bt_Cancel.Size = new System.Drawing.Size(100, 35);
            this.bt_Cancel.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.bt_Cancel.StyleCustomMode = true;
            this.bt_Cancel.TabIndex = 2;
            this.bt_Cancel.Text = "Cancel";
            this.bt_Cancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Cancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // bt_OK
            // 
            this.bt_OK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_OK.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.bt_OK.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.bt_OK.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.bt_OK.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bt_OK.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bt_OK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_OK.Location = new System.Drawing.Point(241, 109);
            this.bt_OK.MinimumSize = new System.Drawing.Size(1, 1);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.bt_OK.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.bt_OK.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bt_OK.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bt_OK.Size = new System.Drawing.Size(100, 35);
            this.bt_OK.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.bt_OK.StyleCustomMode = true;
            this.bt_OK.TabIndex = 3;
            this.bt_OK.Text = "OK";
            this.bt_OK.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_OK.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);
            // 
            // ScanningSN_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(494, 168);
            this.ControlBoxFillHoverColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.bt_OK);
            this.Controls.Add(this.bt_Cancel);
            this.Controls.Add(this.tb_SN);
            this.Controls.Add(this.lb_Scanning);
            this.Name = "ScanningSN_Form";
            this.RectColor = System.Drawing.Color.Gray;
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "";
            this.TitleColor = System.Drawing.Color.Gray;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 494, 139);
            this.ResumeLayout(false);

        }

        #endregion

        private ProxyTools.SunnyUI.Controls.UILabel lb_Scanning;
        private ProxyTools.SunnyUI.Controls.UITextBox tb_SN;
        private ProxyTools.SunnyUI.Controls.UIButton bt_Cancel;
        private ProxyTools.SunnyUI.Controls.UIButton bt_OK;
    }
}