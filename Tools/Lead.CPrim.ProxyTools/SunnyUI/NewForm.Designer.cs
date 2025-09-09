using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools
{
    partial class NewForm
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
            this.rdoMode1 = new Sunny.UI.UIRadioButton();
            this.rdoMode2 = new Sunny.UI.UIRadioButton();
            this.rdoMode3 = new Sunny.UI.UIRadioButton();
            this.tbTaskName = new UITextBox();
            this.btnNew = new UIButton();
            this.btnCancel = new UIButton();
            this.rdoMode4 = new Sunny.UI.UIRadioButton();
            this.rdoMode5 = new Sunny.UI.UIRadioButton();
            this.rdoMode6 = new Sunny.UI.UIRadioButton();
            this.SuspendLayout();
            // 
            // rdoMode1
            // 
            this.rdoMode1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoMode1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoMode1.Location = new System.Drawing.Point(67, 110);
            this.rdoMode1.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdoMode1.Name = "rdoMode1";
            this.rdoMode1.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdoMode1.Size = new System.Drawing.Size(90, 25);
            this.rdoMode1.TabIndex = 13;
            this.rdoMode1.Text = "1";
            // 
            // rdoMode2
            // 
            this.rdoMode2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoMode2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoMode2.Location = new System.Drawing.Point(180, 110);
            this.rdoMode2.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdoMode2.Name = "rdoMode2";
            this.rdoMode2.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdoMode2.Size = new System.Drawing.Size(90, 25);
            this.rdoMode2.TabIndex = 13;
            this.rdoMode2.Text = "2";
            // 
            // rdoMode3
            // 
            this.rdoMode3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoMode3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoMode3.Location = new System.Drawing.Point(294, 110);
            this.rdoMode3.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdoMode3.Name = "rdoMode3";
            this.rdoMode3.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdoMode3.Size = new System.Drawing.Size(90, 25);
            this.rdoMode3.TabIndex = 13;
            this.rdoMode3.Text = "3";
            // 
            // tbTaskName
            // 
            this.tbTaskName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbTaskName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbTaskName.Location = new System.Drawing.Point(67, 67);
            this.tbTaskName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTaskName.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbTaskName.Name = "tbTaskName";
            this.tbTaskName.ShowText = false;
            this.tbTaskName.Size = new System.Drawing.Size(317, 38);
            this.tbTaskName.TabIndex = 14;
            this.tbTaskName.Text = "title1";
            this.tbTaskName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbTaskName.Watermark = "任务名称";
            // 
            // btnNew
            // 
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNew.Location = new System.Drawing.Point(67, 168);
            this.btnNew.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(116, 35);
            this.btnNew.TabIndex = 15;
            this.btnNew.Text = "新建";
            this.btnNew.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(268, 168);
            this.btnCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 35);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消";
            this.btnCancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rdoMode4
            // 
            this.rdoMode4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoMode4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoMode4.Location = new System.Drawing.Point(67, 137);
            this.rdoMode4.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdoMode4.Name = "rdoMode4";
            this.rdoMode4.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdoMode4.Size = new System.Drawing.Size(90, 25);
            this.rdoMode4.TabIndex = 13;
            this.rdoMode4.Text = "4";
            // 
            // rdoMode5
            // 
            this.rdoMode5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoMode5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoMode5.Location = new System.Drawing.Point(180, 137);
            this.rdoMode5.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdoMode5.Name = "rdoMode5";
            this.rdoMode5.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdoMode5.Size = new System.Drawing.Size(90, 25);
            this.rdoMode5.TabIndex = 13;
            this.rdoMode5.Text = "5";
            // 
            // rdoMode6
            // 
            this.rdoMode6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoMode6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoMode6.Location = new System.Drawing.Point(294, 137);
            this.rdoMode6.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdoMode6.Name = "rdoMode6";
            this.rdoMode6.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdoMode6.Size = new System.Drawing.Size(90, 25);
            this.rdoMode6.TabIndex = 13;
            this.rdoMode6.Text = "6";
            // 
            // NewForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(450, 228);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.tbTaskName);
            this.Controls.Add(this.rdoMode6);
            this.Controls.Add(this.rdoMode3);
            this.Controls.Add(this.rdoMode5);
            this.Controls.Add(this.rdoMode2);
            this.Controls.Add(this.rdoMode4);
            this.Controls.Add(this.rdoMode1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NewForm";
            this.Text = "新建任务";
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIRadioButton rdoMode1;
        private Sunny.UI.UIRadioButton rdoMode2;
        private Sunny.UI.UIRadioButton rdoMode3;
        private UITextBox tbTaskName;
        private UIButton btnNew;
        private UIButton btnCancel;
        private Sunny.UI.UIRadioButton rdoMode4;
        private Sunny.UI.UIRadioButton rdoMode5;
        private Sunny.UI.UIRadioButton rdoMode6;
    }
}
