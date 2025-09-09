using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.StationCommon.CommonUI
{
    partial class NewStation
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
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
			base.ClientSize = new System.Drawing.Size(530, 175);
			base.Controls.Add(tbName);
			base.Controls.Add(btnNew);
			base.Controls.Add(btnCancel);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "NewStation";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "新建工站";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private TextBox tbName;
        private Button btnNew;
        private Button btnCancel;
    }
}
