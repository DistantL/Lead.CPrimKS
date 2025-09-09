using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.CustomControl
{
    partial class MessageFrm
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnSymbol = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISymbolButton();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(60, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(440, 50);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "这是一条测试消息";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSymbol
            // 
            this.btnSymbol.BackColor = System.Drawing.Color.Transparent;
            this.btnSymbol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSymbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSymbol.FillColor = System.Drawing.Color.Transparent;
            this.btnSymbol.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSymbol.Location = new System.Drawing.Point(0, 0);
            this.btnSymbol.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSymbol.Name = "btnSymbol";
            this.btnSymbol.RectColor = System.Drawing.Color.Transparent;
            this.btnSymbol.Size = new System.Drawing.Size(60, 50);
            this.btnSymbol.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnSymbol.Symbol = 61453;
            this.btnSymbol.TabIndex = 4;
            this.btnSymbol.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSymbol.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSymbol.Click += new System.EventHandler(this.btnSymbol_Click);
            // 
            // MessageFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Brown;
            this.ClientSize = new System.Drawing.Size(500, 50);
            this.Controls.Add(this.btnSymbol);
            this.Controls.Add(this.lblInfo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 50);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 50);
            this.Name = "MessageFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPopup_Closing);
            this.Load += new System.EventHandler(this.FormPopup_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Label lblInfo;
        private ProxyTools.SunnyUI.Controls.UISymbolButton btnSymbol;
    }
}
