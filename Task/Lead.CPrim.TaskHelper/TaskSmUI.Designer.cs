using System.ComponentModel;
using System.Windows.Forms;

namespace Lead.CPrim.TaskHelper
{
    partial class TaskSmUI
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
            this.LastState = new System.Windows.Forms.GroupBox();
            this.txbLastSta = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbCurSta = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.labSmName = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnDispose = new System.Windows.Forms.Button();
            this.btnClrErr = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.LastState.SuspendLayout();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.LastState.Controls.Add(this.txbLastSta);
            this.LastState.Location = new System.Drawing.Point(3, 39);
            this.LastState.Name = "LastState";
            this.LastState.Size = new System.Drawing.Size(96, 48);
            this.LastState.TabIndex = 0;
            this.LastState.TabStop = false;
            this.LastState.Text = "LastState";
            this.txbLastSta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbLastSta.Location = new System.Drawing.Point(3, 17);
            this.txbLastSta.Name = "txbLastSta";
            this.txbLastSta.Size = new System.Drawing.Size(90, 21);
            this.txbLastSta.TabIndex = 0;
            this.groupBox1.Controls.Add(this.txbCurSta);
            this.groupBox1.Location = new System.Drawing.Point(105, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(89, 48);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CurState";
            this.txbCurSta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbCurSta.Location = new System.Drawing.Point(3, 17);
            this.txbCurSta.Name = "txbCurSta";
            this.txbCurSta.Size = new System.Drawing.Size(83, 21);
            this.txbCurSta.TabIndex = 0;
            this.richTextBox1.Location = new System.Drawing.Point(6, 93);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(282, 342);
            this.richTextBox1.TabIndex = 21;
            this.richTextBox1.Text = "HH:mm:ss.fff  State  ==> WaitRest\nHH:mm:ss.fff  Event  ==> Stop , Sender: S2";
            this.labSmName.AutoSize = true;
            this.labSmName.Font = new System.Drawing.Font("宋体", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            this.labSmName.ForeColor = System.Drawing.Color.Black;
            this.labSmName.Location = new System.Drawing.Point(9, 12);
            this.labSmName.Name = "labSmName";
            this.labSmName.Size = new System.Drawing.Size(185, 19);
            this.labSmName.TabIndex = 24;
            this.labSmName.Text = "StateMachineName";
            this.btnStart.BackColor = System.Drawing.Color.Gray;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.Enabled = false;
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(254, 153, 3);
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(254, 153, 3);
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Image = Lead.CPrim.TaskHelper.Properties.Resource.btnStart_Image;
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.Location = new System.Drawing.Point(295, 204);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(108, 48);
            this.btnStart.TabIndex = 14;
            this.btnStart.Text = "   运行";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(btnStart_Click);
            this.btnPause.BackColor = System.Drawing.Color.Gray;
            this.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPause.Enabled = false;
            this.btnPause.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPause.FlatAppearance.BorderSize = 0;
            this.btnPause.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(254, 153, 3);
            this.btnPause.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(254, 153, 3);
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            this.btnPause.ForeColor = System.Drawing.Color.White;
            this.btnPause.Image = Lead.CPrim.TaskHelper.Properties.Resource.btnPause_Image;
            this.btnPause.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPause.Location = new System.Drawing.Point(295, 372);
            this.btnPause.Margin = new System.Windows.Forms.Padding(4);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(108, 48);
            this.btnPause.TabIndex = 17;
            this.btnPause.Text = "    暂停";
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(btnPause_Click);
            this.btnReset.BackColor = System.Drawing.Color.Gray;
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(254, 153, 3);
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(254, 153, 3);
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Image = Lead.CPrim.TaskHelper.Properties.Resource.btnReset_Image;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(295, 260);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(108, 48);
            this.btnReset.TabIndex = 18;
            this.btnReset.Text = "    复位";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(btnReset_Click);
            this.btnStop.AutoEllipsis = true;
            this.btnStop.BackColor = System.Drawing.Color.Gray;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStop.Enabled = false;
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(254, 153, 3);
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(254, 153, 3);
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Image = Lead.CPrim.TaskHelper.Properties.Resource.btnStop_Image;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop.Location = new System.Drawing.Point(295, 316);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(108, 48);
            this.btnStop.TabIndex = 19;
            this.btnStop.Text = "   停止";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(btnStop_Click);
            this.btnDispose.AutoEllipsis = true;
            this.btnDispose.BackColor = System.Drawing.Color.FromArgb(234, 127, 54);
            this.btnDispose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDispose.Enabled = false;
            this.btnDispose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDispose.FlatAppearance.BorderSize = 0;
            this.btnDispose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(254, 153, 3);
            this.btnDispose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(254, 153, 3);
            this.btnDispose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDispose.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            this.btnDispose.ForeColor = System.Drawing.Color.White;
            this.btnDispose.Image = Lead.CPrim.TaskHelper.Properties.Resource.btnDispose_Image;
            this.btnDispose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDispose.Location = new System.Drawing.Point(295, 70);
            this.btnDispose.Margin = new System.Windows.Forms.Padding(4);
            this.btnDispose.Name = "btnDispose";
            this.btnDispose.Size = new System.Drawing.Size(108, 48);
            this.btnDispose.TabIndex = 27;
            this.btnDispose.Text = "   终止";
            this.btnDispose.UseVisualStyleBackColor = false;
            this.btnDispose.Click += new System.EventHandler(btnDispose_Click);
            this.btnClrErr.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClrErr.Location = new System.Drawing.Point(295, 138);
            this.btnClrErr.Name = "btnClrErr";
            this.btnClrErr.Size = new System.Drawing.Size(108, 41);
            this.btnClrErr.TabIndex = 28;
            this.btnClrErr.Text = "ClrErr";
            this.btnClrErr.UseVisualStyleBackColor = true;
            this.btnClrErr.Click += new System.EventHandler(btnClrErr_Click);
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(213, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 30);
            this.button1.TabIndex = 29;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(easyButton2_Click);
            this.btnInit.BackColor = System.Drawing.Color.FromArgb(171, 171, 171);
            this.btnInit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnInit.FlatAppearance.BorderSize = 0;
            this.btnInit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(254, 153, 3);
            this.btnInit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(254, 153, 3);
            this.btnInit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInit.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            this.btnInit.ForeColor = System.Drawing.Color.White;
            this.btnInit.Image = Lead.CPrim.TaskHelper.Properties.Resource.btnInit_Image;
            this.btnInit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInit.Location = new System.Drawing.Point(295, 12);
            this.btnInit.Margin = new System.Windows.Forms.Padding(4);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(108, 50);
            this.btnInit.TabIndex = 26;
            this.btnInit.Text = "     初始化";
            this.btnInit.UseVisualStyleBackColor = false;
            this.btnInit.Click += new System.EventHandler(btnInit_Click);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoSize = true;
            base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            base.Controls.Add(this.button1);
            base.Controls.Add(this.btnClrErr);
            base.Controls.Add(this.btnDispose);
            base.Controls.Add(this.btnInit);
            base.Controls.Add(this.labSmName);
            base.Controls.Add(this.richTextBox1);
            base.Controls.Add(this.btnStop);
            base.Controls.Add(this.btnReset);
            base.Controls.Add(this.btnPause);
            base.Controls.Add(this.btnStart);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.LastState);
            this.ForeColor = System.Drawing.SystemColors.Control;
            base.Name = "TaskSmUI";
            base.Size = new System.Drawing.Size(407, 438);
            base.Load += new System.EventHandler(TaskSmUI_Load);
            this.LastState.ResumeLayout(false);
            this.LastState.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private GroupBox LastState;
        private TextBox txbLastSta;
        private GroupBox groupBox1;
        private TextBox txbCurSta;
        private RichTextBox richTextBox1;
        private Label labSmName;
        private Button btnStart;
        private Button btnPause;
        private Button btnReset;
        private Button btnStop;
        private Button btnInit;
        private Button btnDispose;
        private Button btnClrErr;
        private Button button1;
        #endregion
    }
}
