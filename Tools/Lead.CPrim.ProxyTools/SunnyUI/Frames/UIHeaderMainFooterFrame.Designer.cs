#pragma warning disable CS1591
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;

namespace Sunny.UI
{
    partial class UIHeaderMainFooterFrame
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
            this.Footer = new UIPanel();
            this.SuspendLayout();
            // 
            // Footer
            // 
            this.Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Footer.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Footer.Location = new System.Drawing.Point(0, 394);
            this.Footer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Footer.MinimumSize = new System.Drawing.Size(1, 1);
            this.Footer.Name = "Footer";
            this.Footer.RadiusSides = UICornerRadiusSides.None;
            this.Footer.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.Footer.Size = new System.Drawing.Size(800, 56);
            this.Footer.TabIndex = 2;
            this.Footer.Text = null;
            this.Footer.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Footer.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // UIHeaderMainFooterFrame
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Footer);
            this.Name = "UIHeaderMainFooterFrame";
            this.Text = "UIHeaderMainFooterFrame";
            this.Controls.SetChildIndex(this.Footer, 0);
            this.Controls.SetChildIndex(this.Header, 0);
            this.ResumeLayout(false);

        }

        #endregion

        protected UIPanel Footer;
    }
}