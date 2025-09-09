using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.Controls
{
    partial class ProductInfoChart
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splMain = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISplitContainer();
            this.btnReLoad = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISymbolButton();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.Panel1.SuspendLayout();
            this.splMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // splMain
            // 
            this.splMain.BarColor = System.Drawing.SystemColors.ControlLight;
            this.splMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.splMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splMain.HandleColor = System.Drawing.SystemColors.Control;
            this.splMain.Location = new System.Drawing.Point(0, 0);
            this.splMain.MinimumSize = new System.Drawing.Size(20, 20);
            this.splMain.Name = "splMain";
            this.splMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splMain.Panel1
            // 
            this.splMain.Panel1.Controls.Add(this.btnReLoad);
            // 
            // splMain.Panel2
            // 
            this.splMain.Panel2.BackColor = System.Drawing.Color.LightGray;
            this.splMain.Size = new System.Drawing.Size(1408, 664);
            this.splMain.SplitPanelState = Lead.CPrim.ProxyTools.SunnyUI.Controls.UISplitContainer.UISplitPanelState.Expanded;
            this.splMain.SplitterDistance = 48;
            this.splMain.SplitterWidth = 11;
            this.splMain.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.splMain.TabIndex = 1;
            this.splMain.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnReLoad
            // 
            this.btnReLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReLoad.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.btnReLoad.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReLoad.Location = new System.Drawing.Point(0, 0);
            this.btnReLoad.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnReLoad.Name = "btnReLoad";
            this.btnReLoad.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.btnReLoad.Size = new System.Drawing.Size(1408, 48);
            this.btnReLoad.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnReLoad.Symbol = 61442;
            this.btnReLoad.SymbolColor = System.Drawing.Color.Black;
            this.btnReLoad.TabIndex = 2;
            this.btnReLoad.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReLoad.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnReLoad.Click += new System.EventHandler(this.btnReLoad_Click);
            // 
            // ProductInfoChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1408, 664);
            this.Controls.Add(this.splMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProductInfoChart";
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.Load += new System.EventHandler(this.HistoryQueryByMongoDb_Load);
            this.splMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private OpenFileDialog openFileDialog;
        private UISplitContainer splMain;
        private ProxyTools.SunnyUI.Controls.UISymbolButton btnReLoad;
    }
}
