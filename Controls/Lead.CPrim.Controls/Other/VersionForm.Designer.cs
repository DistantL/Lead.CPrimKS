using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.Controls
{
    partial class VersionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VersionForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInfo = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.lblPrimType = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblPrimManufacture = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label1.Location = new System.Drawing.Point(11, 456);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "C Prim.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label2.Location = new System.Drawing.Point(11, 476);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Copyright © 2018 LeadChina Inc. All Rights Reserved.";
            // 
            // txtInfo
            // 
            this.txtInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtInfo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInfo.Location = new System.Drawing.Point(0, 35);
            this.txtInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInfo.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ShowText = false;
            this.txtInfo.Size = new System.Drawing.Size(629, 416);
            this.txtInfo.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.txtInfo.TabIndex = 4;
            this.txtInfo.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.txtInfo.WordWarp = false;
            this.txtInfo.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblPrimType
            // 
            this.lblPrimType.AutoSize = true;
            this.lblPrimType.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblPrimType.Location = new System.Drawing.Point(440, 476);
            this.lblPrimType.Name = "lblPrimType";
            this.lblPrimType.Size = new System.Drawing.Size(62, 17);
            this.lblPrimType.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lblPrimType.TabIndex = 5;
            this.lblPrimType.Text = "PrimType";
            this.lblPrimType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPrimType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblPrimManufacture
            // 
            this.lblPrimManufacture.AutoSize = true;
            this.lblPrimManufacture.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblPrimManufacture.Location = new System.Drawing.Point(516, 476);
            this.lblPrimManufacture.Name = "lblPrimManufacture";
            this.lblPrimManufacture.Size = new System.Drawing.Size(107, 17);
            this.lblPrimManufacture.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lblPrimManufacture.TabIndex = 5;
            this.lblPrimManufacture.Text = "PrimManufacture";
            this.lblPrimManufacture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPrimManufacture.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // VersionForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(629, 500);
            this.Controls.Add(this.lblPrimManufacture);
            this.Controls.Add(this.lblPrimType);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "VersionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.Text = "关于 C Prim.";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 481, 209);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VersionForm_FormClosing);
            this.Load += new System.EventHandler(this.VersionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Label label2;
        private ProxyTools.SunnyUI.Controls.UITextBox txtInfo;
        private ProxyTools.SunnyUI.Controls.UILabel lblPrimType;
        private ProxyTools.SunnyUI.Controls.UILabel lblPrimManufacture;
    }
}
