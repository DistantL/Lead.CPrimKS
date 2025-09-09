using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.SunnyUI.Controls
{
    partial class UIFlowLayoutPanel
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
            timer?.Stop();
            timer?.Dispose();
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel = new FlowLayoutPanel();
            this.VBar = new UIVerScrollBarEx();
            this.HBar = new UIHorScrollBarEx();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.BackColor = Color.FromArgb(235, 243, 255);
            this.flowLayoutPanel.Dock = DockStyle.Fill;
            this.flowLayoutPanel.Location = new Point(2, 2);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new Size(429, 383);
            this.flowLayoutPanel.TabIndex = 0;
            this.flowLayoutPanel.Tag = "69605093-6397-AD32-9F69-3C29F642F87E";
            // 
            // VBar
            // 
            this.VBar.BoundsHeight = 10;
            this.VBar.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.VBar.LargeChange = 10;
            this.VBar.Location = new Point(410, 5);
            this.VBar.Maximum = 100;
            this.VBar.MinimumSize = new Size(1, 1);
            this.VBar.Name = "VBar";
            this.VBar.Size = new Size(18, 377);
            this.VBar.TabIndex = 1;
            this.VBar.TagString = "63FD1249-41D3-E08A-F8F5-CC41CC30FD03";
            this.VBar.Text = "uiVerScrollBarEx1";
            this.VBar.Value = 0;
            this.VBar.Visible = false;
            // 
            // HBar
            // 
            this.HBar.BoundsWidth = 10;
            this.HBar.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.HBar.LargeChange = 10;
            this.HBar.Location = new Point(5, 364);
            this.HBar.Maximum = 100;
            this.HBar.MinimumSize = new Size(1, 1);
            this.HBar.Name = "HBar";
            this.HBar.Size = new Size(399, 18);
            this.HBar.TabIndex = 2;
            this.HBar.TagString = "79E1E7DD-3E4D-916B-C8F1-F45B579C290C";
            this.HBar.Text = "uiHorScrollBarEx1";
            this.HBar.Value = 0;
            this.HBar.Visible = false;
            // 
            // UIFlowLayoutPanel
            // 
            this.Controls.Add(this.HBar);
            this.Controls.Add(this.VBar);
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "UIFlowLayoutPanel";
            this.Padding = new Padding(2);
            this.Size = new Size(433, 387);
            this.ResumeLayout(false);

        }

        #endregion
        private readonly Timer timer;
        private UIVerScrollBarEx VBar;
        private UIHorScrollBarEx HBar;
        private FlowLayoutPanel flowLayoutPanel;
    }
}
