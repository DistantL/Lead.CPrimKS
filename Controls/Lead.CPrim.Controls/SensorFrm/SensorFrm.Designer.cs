
namespace Lead.CPrim.Controls
{
    partial class SensorFrm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pl_workPanel = new System.Windows.Forms.Panel();
            this.lb_Title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pl_workPanel
            // 
            this.pl_workPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_workPanel.Location = new System.Drawing.Point(0, 45);
            this.pl_workPanel.Margin = new System.Windows.Forms.Padding(2);
            this.pl_workPanel.Name = "pl_workPanel";
            this.pl_workPanel.Size = new System.Drawing.Size(1216, 708);
            this.pl_workPanel.TabIndex = 4;
            // 
            // lb_Title
            // 
            this.lb_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_Title.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Title.Location = new System.Drawing.Point(0, 0);
            this.lb_Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Title.Name = "lb_Title";
            this.lb_Title.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lb_Title.Size = new System.Drawing.Size(1216, 45);
            this.lb_Title.TabIndex = 3;
            this.lb_Title.Text = "◀ Sensor Connection Dashboard";
            this.lb_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_Title.Click += new System.EventHandler(this.lb_Title_Click);
            // 
            // SensorFrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1216, 753);
            this.Controls.Add(this.pl_workPanel);
            this.Controls.Add(this.lb_Title);
            this.Name = "SensorFrm";
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pl_workPanel;
        private System.Windows.Forms.Label lb_Title;
    }
}

