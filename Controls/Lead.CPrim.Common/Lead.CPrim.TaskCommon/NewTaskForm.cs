using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lead.CPrim.TaskCommon
{
	public class NewTaskForm : Form
	{
		private string _taskName = "";

		public NewTaskForm()
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
			if (AuthorityManager.Instance.VerifyLevel3Permission(true))
			{
				if (!string.IsNullOrEmpty(tbTaskName.Text))
				{
					_taskName = tbTaskName.Text;
					base.DialogResult = DialogResult.OK;
					Close();
				}
				else
				{
					Close();
				}
			}
		}

		public string GetTaskName()
		{
			return _taskName;
		}


		#region System
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

		private TextBox tbTaskName;

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
			tbTaskName = new System.Windows.Forms.TextBox();
			btnNew = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			tbTaskName.Font = new System.Drawing.Font("微软雅黑", 16.2f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			tbTaskName.Location = new System.Drawing.Point(136, 17);
			tbTaskName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			tbTaskName.Multiline = true;
			tbTaskName.Name = "tbTaskName";
			tbTaskName.Size = new System.Drawing.Size(266, 51);
			tbTaskName.TabIndex = 12;
			tbTaskName.Text = "title1";
			tbTaskName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
			base.ClientSize = new System.Drawing.Size(530, 175);
			base.Controls.Add(tbTaskName);
			base.Controls.Add(btnNew);
			base.Controls.Add(btnCancel);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "NewTaskForm";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "新建任务";
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion


		public void OnLanguageChanged()
		{
			this.Text = NLocalizer.GetString("Lead_CPrim.TaskCommon_NewTaskForm_Title", "新建任务");
			btnNew.Text = NLocalizer.GetString("Lead_CPrim.TaskCommon_NewTaskForm_Create", "新建");
			btnCancel.Text = NLocalizer.GetString("Lead_CPrim.TaskCommon_NewTaskForm_Cancel", "取消");
		}
	}
}
