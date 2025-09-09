using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.StationCommon.RtVars
{
    partial class RtVarsControl
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
            fLPanelVar = new System.Windows.Forms.FlowLayoutPanel();
            SuspendLayout();
            fLPanelVar.AutoScroll = true;
            fLPanelVar.Dock = System.Windows.Forms.DockStyle.Fill;
            fLPanelVar.Location = new System.Drawing.Point(0, 0);
            fLPanelVar.Name = "fLPanelVar";
            fLPanelVar.Size = new System.Drawing.Size(844, 149);
            fLPanelVar.TabIndex = 13;
            base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            base.Controls.Add(fLPanelVar);
            Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            base.Name = "RtVarsControl";
            base.Size = new System.Drawing.Size(844, 149);
            base.Load += new System.EventHandler(RtVarsControl_Load);
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel fLPanelVar;
    }
}
