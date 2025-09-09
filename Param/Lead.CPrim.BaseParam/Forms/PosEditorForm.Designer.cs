using Lead.CPrim.ProxyTools.SunnyUI.Controls;

namespace Lead.CPrim.BaseParam
{
	public partial class PosEditorForm 
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.tlpMain = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.pnlTitle = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.btnApply = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnEnterPlatForm = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.lb_CartesianSelect = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.combPlatForm = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.pnlControl = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.tlpMain.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pnlTitle, 0, 0);
            this.tlpMain.Controls.Add(this.pnlControl, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 35);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1000, 605);
            this.tlpMain.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tlpMain.TabIndex = 0;
            this.tlpMain.TagString = null;
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.btnApply);
            this.pnlTitle.Controls.Add(this.btnEnterPlatForm);
            this.pnlTitle.Controls.Add(this.lb_CartesianSelect);
            this.pnlTitle.Controls.Add(this.combPlatForm);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTitle.FillColor = System.Drawing.SystemColors.Control;
            this.pnlTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlTitle.Location = new System.Drawing.Point(2, 2);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTitle.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.RectColor = System.Drawing.Color.Transparent;
            this.pnlTitle.Size = new System.Drawing.Size(996, 36);
            this.pnlTitle.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.pnlTitle.StyleCustomMode = true;
            this.pnlTitle.TabIndex = 0;
            this.pnlTitle.Text = null;
            this.pnlTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnApply
            // 
            this.btnApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnApply.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnApply.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnApply.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnApply.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnApply.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(856, 0);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApply.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnApply.Name = "btnApply";
            this.btnApply.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnApply.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnApply.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnApply.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnApply.Size = new System.Drawing.Size(140, 36);
            this.btnApply.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.btnApply.StyleCustomMode = true;
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "应用";
            this.btnApply.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // btnEnterPlatForm
            // 
            this.btnEnterPlatForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnterPlatForm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnEnterPlatForm.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnEnterPlatForm.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnEnterPlatForm.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnEnterPlatForm.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnEnterPlatForm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEnterPlatForm.Location = new System.Drawing.Point(340, 0);
            this.btnEnterPlatForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEnterPlatForm.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnEnterPlatForm.Name = "btnEnterPlatForm";
            this.btnEnterPlatForm.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnEnterPlatForm.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnEnterPlatForm.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnEnterPlatForm.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnEnterPlatForm.Size = new System.Drawing.Size(140, 36);
            this.btnEnterPlatForm.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.btnEnterPlatForm.StyleCustomMode = true;
            this.btnEnterPlatForm.TabIndex = 2;
            this.btnEnterPlatForm.Text = "确认轴组";
            this.btnEnterPlatForm.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEnterPlatForm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnEnterPlatForm.Click += new System.EventHandler(this.BtnEnterPlatForm_Click);
            // 
            // lb_CartesianSelect
            // 
            this.lb_CartesianSelect.AutoSize = true;
            this.lb_CartesianSelect.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lb_CartesianSelect.Location = new System.Drawing.Point(10, 10);
            this.lb_CartesianSelect.Name = "lb_CartesianSelect";
            this.lb_CartesianSelect.Size = new System.Drawing.Size(56, 17);
            this.lb_CartesianSelect.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lb_CartesianSelect.TabIndex = 1;
            this.lb_CartesianSelect.Text = "轴组选择";
            this.lb_CartesianSelect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_CartesianSelect.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // combPlatForm
            // 
            this.combPlatForm.DataSource = null;
            this.combPlatForm.FillColor = System.Drawing.Color.White;
            this.combPlatForm.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.combPlatForm.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.combPlatForm.FormattingEnabled = true;
            this.combPlatForm.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.combPlatForm.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.combPlatForm.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.combPlatForm.Location = new System.Drawing.Point(130, 2);
            this.combPlatForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.combPlatForm.MinimumSize = new System.Drawing.Size(63, 0);
            this.combPlatForm.Name = "combPlatForm";
            this.combPlatForm.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.combPlatForm.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.combPlatForm.Size = new System.Drawing.Size(200, 32);
            this.combPlatForm.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.combPlatForm.StyleCustomMode = true;
            this.combPlatForm.TabIndex = 0;
            this.combPlatForm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pnlControl
            // 
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControl.FillColor = System.Drawing.SystemColors.Control;
            this.pnlControl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlControl.Location = new System.Drawing.Point(0, 40);
            this.pnlControl.Margin = new System.Windows.Forms.Padding(0);
            this.pnlControl.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.RectColor = System.Drawing.Color.Transparent;
            this.pnlControl.Size = new System.Drawing.Size(1000, 565);
            this.pnlControl.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.pnlControl.StyleCustomMode = true;
            this.pnlControl.TabIndex = 1;
            this.pnlControl.Text = null;
            this.pnlControl.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlControl.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // PosEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(1000, 640);
            this.Name = "PosEditorForm";
            this.RectColor = System.Drawing.Color.Gray;
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "点位编辑";
            this.TitleColor = System.Drawing.Color.Gray;
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 1092, 646);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PosEditorForm_FormClosing);
            this.Load += new System.EventHandler(this.PosEditorForm_Load);
            this.tlpMain.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.ResumeLayout(false);

		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private global::System.ComponentModel.IContainer components = null;

		private UITableLayoutPanel tlpMain;

		private UIPanel pnlTitle;

		private UILabel lb_CartesianSelect;

		private UIComboBox combPlatForm;

		private UIButton btnEnterPlatForm;

		private UIButton btnApply;

		private UIPanel pnlControl;
	}
}
