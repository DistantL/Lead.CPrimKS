using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Lead.CPrim.EleCommon.Forms
{
	public class CreateNewCartesian : Form
	{
		#region Field
		/// <summary>元件公共接口</summary>
		private IEle _ele;
		#endregion


		#region Ctor
		/// <summary>Ctor无参</summary>
		public CreateNewCartesian()
		{
			InitializeComponent();
		}
		/// <summary>Ctor有一个参数</summary>
		public CreateNewCartesian(IEle ele)
		{
			InitializeComponent();
			_ele = ele;

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
		#endregion


		#region Button_Event
		/// <summary>新建</summary>
		private void btnNew_Click(object sender, EventArgs e)
		{
			string text = tbName.Text;
			if (string.IsNullOrEmpty(text))
			{
				MessageBox.Show("名称不允许为空，请重新输入!");
				return;
			}
			List<string> list = new List<string>();
				list = (from item in ElesManager.Instance.ListEle.FindAll(p => p.EleTypeName == "Cartesian") select item.Name).ToList();

			if (list.Count > 0 && list.Contains(text))
			{
				MessageBox.Show("已配置的轴组中已包含该名称，名称不允许重复，请重新输入!");
				return;
			}
			_ele.Name = text;
			base.DialogResult = DialogResult.OK;
			Close();
		}
		/// <summary>取消</summary>
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
		}
        #endregion

        #region System
        private IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.lb_Name = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_Name
            // 
            this.lb_Name.AutoSize = true;
            this.lb_Name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Name.Location = new System.Drawing.Point(56, 64);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(72, 27);
            this.lb_Name.TabIndex = 0;
            this.lb_Name.Text = "名称：";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbName.Location = new System.Drawing.Point(120, 62);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(166, 34);
            this.tbName.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Lime;
            this.btnNew.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNew.Location = new System.Drawing.Point(59, 152);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(85, 38);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Tomato;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(192, 152);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 38);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CreateNewCartesian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 225);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lb_Name);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "CreateNewCartesian";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建轴组";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private Label lb_Name;

		private TextBox tbName;

		private Button btnNew;

		private Button btnCancel;
        #endregion

        public void OnLanguageChanged()
        {
            this.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_CreateNewCartesian_Title", "新建轴组");
            lb_Name.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_CreateNewCartesian_Name", "名称:");
            btnNew.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_CreateNewCartesian_Create", "新建");
            btnCancel.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_CreateNewCartesian_Cancel", "取消");
        }
    }
}
