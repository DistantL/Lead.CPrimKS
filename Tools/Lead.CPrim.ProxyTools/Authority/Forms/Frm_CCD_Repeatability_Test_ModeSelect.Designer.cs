
using System;

namespace Lead.CPrim.ProxyTools.Authority.Forms
{
    partial class Frm_CCD_Repeatability_Test_ModeSelect
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
            this.btnCancel = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnOK = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.uiGroupBox1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIGroupBox();
            this.rb_Test3 = new Sunny.UI.UIRadioButton();
            this.rb_Test2 = new Sunny.UI.UIRadioButton();
            this.rb_Test1 = new Sunny.UI.UIRadioButton();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FillColor = System.Drawing.Color.Silver;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(530, 161);
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
            this.btnOK.Location = new System.Drawing.Point(401, 161);
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
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.rb_Test3);
            this.uiGroupBox1.Controls.Add(this.rb_Test2);
            this.uiGroupBox1.Controls.Add(this.rb_Test1);
            this.uiGroupBox1.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(15, 45);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 10, 4, 10);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.uiGroupBox1.RectColor = System.Drawing.Color.Transparent;
            this.uiGroupBox1.Size = new System.Drawing.Size(706, 113);
            this.uiGroupBox1.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiGroupBox1.StyleCustomMode = true;
            this.uiGroupBox1.TabIndex = 19;
            this.uiGroupBox1.Text = null;
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // rb_Test3
            // 
            this.rb_Test3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_Test3.Dock = System.Windows.Forms.DockStyle.Top;
            this.rb_Test3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rb_Test3.Location = new System.Drawing.Point(0, 68);
            this.rb_Test3.MinimumSize = new System.Drawing.Size(1, 1);
            this.rb_Test3.Name = "rb_Test3";
            this.rb_Test3.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rb_Test3.Size = new System.Drawing.Size(706, 29);
            this.rb_Test3.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.rb_Test3.TabIndex = 2;
            this.rb_Test3.TagString = "Test3";
            this.rb_Test3.Text = "Test3:CCD Dynamic repeatability_test2,(UC is held static ,CCD moves.Tested 100x t" +
    "imes)";
            this.rb_Test3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // rb_Test2
            // 
            this.rb_Test2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_Test2.Dock = System.Windows.Forms.DockStyle.Top;
            this.rb_Test2.Enabled = false;
            this.rb_Test2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rb_Test2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rb_Test2.Location = new System.Drawing.Point(0, 39);
            this.rb_Test2.Margin = new System.Windows.Forms.Padding(10);
            this.rb_Test2.MinimumSize = new System.Drawing.Size(1, 1);
            this.rb_Test2.Name = "rb_Test2";
            this.rb_Test2.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rb_Test2.RadioButtonColor = System.Drawing.Color.Silver;
            this.rb_Test2.Size = new System.Drawing.Size(706, 29);
            this.rb_Test2.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.rb_Test2.StyleCustomMode = true;
            this.rb_Test2.TabIndex = 1;
            this.rb_Test2.TagString = "Test2";
            this.rb_Test2.Text = "Test2:CCD Dynamic repeatability_test1,(CCD is held static ,UC moves.Tested 100x t" +
    "imes)";
            this.rb_Test2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // rb_Test1
            // 
            this.rb_Test1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_Test1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rb_Test1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rb_Test1.Location = new System.Drawing.Point(0, 10);
            this.rb_Test1.Margin = new System.Windows.Forms.Padding(10);
            this.rb_Test1.MinimumSize = new System.Drawing.Size(1, 1);
            this.rb_Test1.Name = "rb_Test1";
            this.rb_Test1.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rb_Test1.Size = new System.Drawing.Size(706, 29);
            this.rb_Test1.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.rb_Test1.TabIndex = 0;
            this.rb_Test1.TagString = "Test1";
            this.rb_Test1.Text = "Test1:CCD Static repeatability,(UC and CCD are held static. Tested 100x times)";
            this.rb_Test1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Frm_CCD_Repeatability_Test_ModeSelect
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(740, 217);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "Frm_CCD_Repeatability_Test_ModeSelect";
            this.RectColor = System.Drawing.Color.Transparent;
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "CCD_Repeatability_Test_ModeSelect";
            this.TitleColor = System.Drawing.Color.Gray;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 525, 156);
            this.uiGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }





        #endregion
        private SunnyUI.Controls.UIButton btnCancel;
        private SunnyUI.Controls.UIButton btnOK;
        private SunnyUI.Controls.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIRadioButton rb_Test3;
        private Sunny.UI.UIRadioButton rb_Test2;
        private Sunny.UI.UIRadioButton rb_Test1;
    }
}