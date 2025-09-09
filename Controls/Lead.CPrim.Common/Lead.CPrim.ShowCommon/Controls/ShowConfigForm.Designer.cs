using System.Windows.Forms;

namespace Lead.CPrim.ShowCommon
{
    public partial class ShowConfigForm
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
            this.components = new System.ComponentModel.Container();
            this.splLeftRight = new System.Windows.Forms.SplitContainer();
            this.cmsPrimsConfig = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmSaveShowConfigs = new System.Windows.Forms.ToolStripMenuItem();
            this.splUpDown = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splLeftRight)).BeginInit();
            this.splLeftRight.Panel2.SuspendLayout();
            this.splLeftRight.SuspendLayout();
            this.cmsPrimsConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splUpDown)).BeginInit();
            this.splUpDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // splLeftRight
            // 
            this.splLeftRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splLeftRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splLeftRight.Location = new System.Drawing.Point(0, 0);
            this.splLeftRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splLeftRight.Name = "splLeftRight";
            // 
            // splLeftRight.Panel1
            // 
            this.splLeftRight.Panel1.AutoScroll = true;
            this.splLeftRight.Panel1.ContextMenuStrip = this.cmsPrimsConfig;
            // 
            // splLeftRight.Panel2
            // 
            this.splLeftRight.Panel2.Controls.Add(this.splUpDown);
            this.splLeftRight.Size = new System.Drawing.Size(1408, 664);
            this.splLeftRight.SplitterDistance = 148;
            this.splLeftRight.TabIndex = 0;
            // 
            // cmsPrimsConfig
            // 
            this.cmsPrimsConfig.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsPrimsConfig.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsPrimsConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSaveShowConfigs});
            this.cmsPrimsConfig.Name = "cmsPrimsConfig";
            this.cmsPrimsConfig.Size = new System.Drawing.Size(199, 36);
            // 
            // tsmSaveShowConfigs
            // 
            this.tsmSaveShowConfigs.Name = "tsmSaveShowConfigs";
            this.tsmSaveShowConfigs.Size = new System.Drawing.Size(198, 32);
            this.tsmSaveShowConfigs.Text = "保存显示配置";
            this.tsmSaveShowConfigs.Click += new System.EventHandler(this.tsmSaveShowConfig_Click);
            // 
            // splUpDown
            // 
            this.splUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splUpDown.Location = new System.Drawing.Point(0, 0);
            this.splUpDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splUpDown.Name = "splUpDown";
            this.splUpDown.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splUpDown.Panel2
            // 
            this.splUpDown.Panel2.AutoScroll = true;
            this.splUpDown.Size = new System.Drawing.Size(1256, 664);
            this.splUpDown.SplitterDistance = 55;
            this.splUpDown.SplitterWidth = 5;
            this.splUpDown.TabIndex = 0;
            // 
            // ShowConfigForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1408, 664);
            this.Controls.Add(this.splLeftRight);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ShowConfigForm";
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.Text = "显示基元配置";
            this.Load += new System.EventHandler(this.ShowConfigForm_Load);
            this.splLeftRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splLeftRight)).EndInit();
            this.splLeftRight.ResumeLayout(false);
            this.cmsPrimsConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splUpDown)).EndInit();
            this.splUpDown.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private SplitContainer splLeftRight;
        private SplitContainer splUpDown;
        private ContextMenuStrip cmsPrimsConfig;
        private ToolStripMenuItem tsmSaveShowConfigs;
    }
}
