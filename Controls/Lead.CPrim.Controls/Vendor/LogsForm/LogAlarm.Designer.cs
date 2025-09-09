using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System.Windows.Forms;

namespace Lead.CPrim.Controls
{
    partial class LogAlarm
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
            this.components = new System.ComponentModel.Container();
            this.tlpAlarm = new System.Windows.Forms.TableLayoutPanel();
            this.rtbAlarm = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnConfirmAlarm = new System.Windows.Forms.Button();
            this.btnClearAlarm = new System.Windows.Forms.Button();
            this.alertInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tlpAlarm.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpAlarm
            // 
            this.tlpAlarm.ColumnCount = 1;
            this.tlpAlarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAlarm.Controls.Add(this.rtbAlarm, 0, 1);
            this.tlpAlarm.Controls.Add(this.panel1, 0, 0);
            this.tlpAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAlarm.Location = new System.Drawing.Point(0, 0);
            this.tlpAlarm.Name = "tlpAlarm";
            this.tlpAlarm.RowCount = 2;
            this.tlpAlarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpAlarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAlarm.Size = new System.Drawing.Size(1285, 830);
            this.tlpAlarm.TabIndex = 2;
            // 
            // rtbAlarm
            // 
            this.rtbAlarm.BackColor = System.Drawing.SystemColors.ControlLight;
            this.rtbAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbAlarm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbAlarm.Location = new System.Drawing.Point(4, 45);
            this.rtbAlarm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtbAlarm.Name = "rtbAlarm";
            this.rtbAlarm.ReadOnly = true;
            this.rtbAlarm.Size = new System.Drawing.Size(1277, 780);
            this.rtbAlarm.TabIndex = 0;
            this.rtbAlarm.Text = "";
            this.rtbAlarm.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1279, 34);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.btnConfirmAlarm, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnClearAlarm, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1279, 34);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnConfirmAlarm
            // 
            this.btnConfirmAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConfirmAlarm.Location = new System.Drawing.Point(3, 3);
            this.btnConfirmAlarm.Name = "btnConfirmAlarm";
            this.btnConfirmAlarm.Size = new System.Drawing.Size(313, 28);
            this.btnConfirmAlarm.TabIndex = 0;
            this.btnConfirmAlarm.Text = "报警确认";
            this.btnConfirmAlarm.UseVisualStyleBackColor = true;
            this.btnConfirmAlarm.Click += new System.EventHandler(this.btnConfirmAlarm_Click);
            // 
            // btnClearAlarm
            // 
            this.btnClearAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearAlarm.Location = new System.Drawing.Point(322, 3);
            this.btnClearAlarm.Name = "btnClearAlarm";
            this.btnClearAlarm.Size = new System.Drawing.Size(313, 28);
            this.btnClearAlarm.TabIndex = 1;
            this.btnClearAlarm.Text = "报警清除";
            this.btnClearAlarm.UseVisualStyleBackColor = true;
            this.btnClearAlarm.Click += new System.EventHandler(this.btnClearAlarm_Click);
            // 
            // alertInfoBindingSource
            // 
            this.alertInfoBindingSource.DataSource = typeof(Lead.CPrim.Interfaces.AlertInfo);
            // 
            // DevLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1285, 830);
            this.Controls.Add(this.tlpAlarm);
            this.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "DevLogForm";
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.Text = "日志";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DevLogForm_FormClosing);
            this.Load += new System.EventHandler(this.DevLogForm_Load);
            this.tlpAlarm.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.alertInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tlpAlarm;
        private RichTextBox rtbAlarm;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnConfirmAlarm;
        private Button btnClearAlarm;
        private BindingSource alertInfoBindingSource;
    }
}
