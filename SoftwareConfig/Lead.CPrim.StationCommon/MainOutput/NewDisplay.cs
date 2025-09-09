using Lead.CPrim.ProxyTools;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.StationCommon.MainOutput
{
	public class NewDisplay : Form
	{
		private string _productName = "";

		public NewDisplay()
		{
			InitializeComponent();
			OnLanguageChanged();
			NLocalizer.LanguageChanged += OnLanguageChanged;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnNew_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(tbName.Text))
			{
				_productName = tbName.Text;
				base.DialogResult = DialogResult.OK;
				Close();
			}
			else
			{
				Close();
			}
		}

		public string GetNewDisplayName()
		{
			return _productName;
		}





		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

		private TextBox tbName;

		private Button btnNew;

		private Button btnCancel;

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
			tbName = new System.Windows.Forms.TextBox();
			btnNew = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			tbName.Font = new System.Drawing.Font("微软雅黑", 16.2f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			tbName.Location = new System.Drawing.Point(136, 17);
			tbName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			tbName.Multiline = true;
			tbName.Name = "tbName";
			tbName.Size = new System.Drawing.Size(266, 51);
			tbName.TabIndex = 12;
			tbName.Text = "title1";
			tbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			btnNew.Font = new System.Drawing.Font("微软雅黑", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			btnNew.Location = new System.Drawing.Point(136, 105);
			btnNew.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
			btnNew.Name = "btnNew";
			btnNew.Size = new System.Drawing.Size(106, 44);
			btnNew.TabIndex = 11;
			btnNew.Text = "新建";
			btnNew.UseVisualStyleBackColor = true;
			btnNew.Click += new System.EventHandler(btnNew_Click);
			btnCancel.Font = new System.Drawing.Font("微软雅黑", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			btnCancel.Location = new System.Drawing.Point(297, 105);
			btnCancel.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(106, 44);
			btnCancel.TabIndex = 10;
			btnCancel.Text = "取消";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(534, 176);
			base.Controls.Add(tbName);
			base.Controls.Add(btnNew);
			base.Controls.Add(btnCancel);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "NewDisplay";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "新配置";
			ResumeLayout(false);
			PerformLayout();
		}

		public void OnLanguageChanged()
		{
			this.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_MainOutput_NewDisplay_Title", "新配置");
			tbName.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_MainOutput_NewDisplay_Name", "名称");
			btnNew.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_MainOutput_NewDisplay_NewCreate", "新建");
			btnCancel.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_MainOutput_NewDisplay_Cancel", "取消");
		}
	}
}
