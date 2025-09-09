using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.CmpTrigHelper
{
    partial class AglSelForm
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
			this.chkListAgl = new System.Windows.Forms.CheckedListBox();
			this.btnEnter = new System.Windows.Forms.Button();
			this.btnEsc = new System.Windows.Forms.Button();
			base.SuspendLayout();
			this.chkListAgl.FormattingEnabled = true;
			this.chkListAgl.Items.AddRange(new object[3] { "a", "b", "c" });
			this.chkListAgl.Location = new System.Drawing.Point(12, 12);
			this.chkListAgl.Name = "chkListAgl";
			this.chkListAgl.Size = new System.Drawing.Size(156, 228);
			this.chkListAgl.TabIndex = 0;
			this.btnEnter.Location = new System.Drawing.Point(12, 260);
			this.btnEnter.Name = "btnEnter";
			this.btnEnter.Size = new System.Drawing.Size(65, 23);
			this.btnEnter.TabIndex = 1;
			this.btnEnter.Text = "Enter";
			this.btnEnter.UseVisualStyleBackColor = true;
			this.btnEnter.Click += new System.EventHandler(btnEnter_Click);
			this.btnEsc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnEsc.Location = new System.Drawing.Point(93, 260);
			this.btnEsc.Name = "btnEsc";
			this.btnEsc.Size = new System.Drawing.Size(75, 23);
			this.btnEsc.TabIndex = 2;
			this.btnEsc.Text = "Esc";
			this.btnEsc.UseVisualStyleBackColor = true;
			this.btnEsc.Click += new System.EventHandler(btnEsc_Click);
			base.AcceptButton = this.btnEnter;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			base.CancelButton = this.btnEsc;
			base.ClientSize = new System.Drawing.Size(176, 294);
			base.Controls.Add(this.btnEsc);
			base.Controls.Add(this.btnEnter);
			base.Controls.Add(this.chkListAgl);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AglSelForm";
			this.Text = "AglChose";
			base.ResumeLayout(false);
		}

		#endregion
		private CheckedListBox chkListAgl;
        private Button btnEnter;
        private Button btnEsc;
    }
}
