#pragma warning disable CS1591
using Lead.CPrim.ProxyTools.SunnyUI.Style;

namespace Sunny.UI
{
    partial class UIHeaderMainFrame
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
            this.Header = new Sunny.UI.UINavBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Header.Location = new System.Drawing.Point(0, 35);
            this.Header.MenuHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Header.MenuSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Header.MenuStyle = UIMenuStyle.White;
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(800, 110);
            this.Header.TabIndex = 1;
            this.Header.Text = "uiNavBar1";
            this.Header.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(342, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 48);
            this.panel1.TabIndex = 2;
            // 
            // UIHeaderMainFrame
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Header);
            this.Name = "UIHeaderMainFrame";
            this.Text = "UIHeaderMainFrame";
            this.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 800, 450);
            this.Controls.SetChildIndex(this.Header, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        protected UINavBar Header;
        private System.Windows.Forms.Panel panel1;
    }
}