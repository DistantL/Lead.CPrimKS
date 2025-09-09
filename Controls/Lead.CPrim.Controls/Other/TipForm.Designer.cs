
namespace Lead.CPrim.Controls
{
    partial class TipForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cb_SelectItems_Level2 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.lb_TipLevel2 = new System.Windows.Forms.Label();
            this.lb_StartTime = new System.Windows.Forms.Label();
            this.cb_SelectItems_Level1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.rtb_Message = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIRichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfirm = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.lb_StartTimeLabel = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.cboErrDealHandle = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.uiLabel1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.cb_SelectItems_Level2, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lb_TipLevel2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lb_StartTime, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cb_SelectItems_Level1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.rtb_Message, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lb_StartTimeLabel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(581, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cb_SelectItems_Level2
            // 
            this.cb_SelectItems_Level2.DataSource = null;
            this.cb_SelectItems_Level2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_SelectItems_Level2.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cb_SelectItems_Level2.FillColor = System.Drawing.Color.White;
            this.cb_SelectItems_Level2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cb_SelectItems_Level2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_SelectItems_Level2.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.cb_SelectItems_Level2.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.cb_SelectItems_Level2.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cb_SelectItems_Level2.Location = new System.Drawing.Point(134, 355);
            this.cb_SelectItems_Level2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_SelectItems_Level2.MinimumSize = new System.Drawing.Size(63, 0);
            this.cb_SelectItems_Level2.Name = "cb_SelectItems_Level2";
            this.cb_SelectItems_Level2.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cb_SelectItems_Level2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.cb_SelectItems_Level2.Size = new System.Drawing.Size(423, 40);
            this.cb_SelectItems_Level2.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.cb_SelectItems_Level2.StyleCustomMode = true;
            this.cb_SelectItems_Level2.TabIndex = 2;
            this.cb_SelectItems_Level2.Text = "二级选项";
            this.cb_SelectItems_Level2.Visible = false;
            this.cb_SelectItems_Level2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_TipLevel2
            // 
            this.lb_TipLevel2.AutoSize = true;
            this.lb_TipLevel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_TipLevel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_TipLevel2.Location = new System.Drawing.Point(23, 350);
            this.lb_TipLevel2.Name = "lb_TipLevel2";
            this.lb_TipLevel2.Size = new System.Drawing.Size(104, 50);
            this.lb_TipLevel2.TabIndex = 2;
            this.lb_TipLevel2.Text = "子选项";
            this.lb_TipLevel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_TipLevel2.Visible = false;
            // 
            // lb_StartTime
            // 
            this.lb_StartTime.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lb_StartTime, 2);
            this.lb_StartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_StartTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_StartTime.Location = new System.Drawing.Point(133, 0);
            this.lb_StartTime.Name = "lb_StartTime";
            this.lb_StartTime.Size = new System.Drawing.Size(445, 40);
            this.lb_StartTime.TabIndex = 0;
            this.lb_StartTime.Text = "2023-10-25 12:23:23";
            this.lb_StartTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_SelectItems_Level1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cb_SelectItems_Level1, 2);
            this.cb_SelectItems_Level1.DataSource = null;
            this.cb_SelectItems_Level1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_SelectItems_Level1.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cb_SelectItems_Level1.FillColor = System.Drawing.Color.White;
            this.cb_SelectItems_Level1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cb_SelectItems_Level1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_SelectItems_Level1.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.cb_SelectItems_Level1.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.cb_SelectItems_Level1.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cb_SelectItems_Level1.Location = new System.Drawing.Point(24, 305);
            this.cb_SelectItems_Level1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_SelectItems_Level1.MinimumSize = new System.Drawing.Size(63, 0);
            this.cb_SelectItems_Level1.Name = "cb_SelectItems_Level1";
            this.cb_SelectItems_Level1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cb_SelectItems_Level1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.cb_SelectItems_Level1.Size = new System.Drawing.Size(533, 40);
            this.cb_SelectItems_Level1.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.cb_SelectItems_Level1.StyleCustomMode = true;
            this.cb_SelectItems_Level1.TabIndex = 1;
            this.cb_SelectItems_Level1.Text = "主选项";
            this.cb_SelectItems_Level1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cb_SelectItems_Level1.SelectedIndexChanged += new System.EventHandler(this.cb_SelectItems_Level1_SelectedIndexChanged);
            // 
            // rtb_Message
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.rtb_Message, 2);
            this.rtb_Message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Message.FillColor = System.Drawing.Color.White;
            this.rtb_Message.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.rtb_Message.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtb_Message.Location = new System.Drawing.Point(24, 45);
            this.rtb_Message.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtb_Message.MinimumSize = new System.Drawing.Size(1, 1);
            this.rtb_Message.Name = "rtb_Message";
            this.rtb_Message.Padding = new System.Windows.Forms.Padding(2);
            this.rtb_Message.ReadOnly = true;
            this.rtb_Message.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.rtb_Message.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.rtb_Message.ShowText = false;
            this.rtb_Message.Size = new System.Drawing.Size(533, 250);
            this.rtb_Message.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.rtb_Message.StyleCustomMode = true;
            this.rtb_Message.TabIndex = 3;
            this.rtb_Message.Text = "提示信息";
            this.rtb_Message.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.rtb_Message.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(23, 403);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 44);
            this.panel1.TabIndex = 4;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnConfirm.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnConfirm.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnConfirm.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Location = new System.Drawing.Point(4, 4);
            this.btnConfirm.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnConfirm.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnConfirm.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnConfirm.Size = new System.Drawing.Size(130, 35);
            this.btnConfirm.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnConfirm.StyleCustomMode = true;
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "确认";
            this.btnConfirm.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lb_StartTimeLabel
            // 
            this.lb_StartTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_StartTimeLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_StartTimeLabel.Location = new System.Drawing.Point(23, 0);
            this.lb_StartTimeLabel.Name = "lb_StartTimeLabel";
            this.lb_StartTimeLabel.Size = new System.Drawing.Size(104, 40);
            this.lb_StartTimeLabel.TabIndex = 5;
            this.lb_StartTimeLabel.Text = "开始时间:";
            this.lb_StartTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_StartTimeLabel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cboErrDealHandle
            // 
            this.cboErrDealHandle.DataSource = null;
            this.cboErrDealHandle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cboErrDealHandle.FillColor = System.Drawing.Color.White;
            this.cboErrDealHandle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboErrDealHandle.Location = new System.Drawing.Point(3, 73);
            this.cboErrDealHandle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboErrDealHandle.MinimumSize = new System.Drawing.Size(63, 0);
            this.cboErrDealHandle.Name = "cboErrDealHandle";
            this.cboErrDealHandle.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cboErrDealHandle.Size = new System.Drawing.Size(194, 41);
            this.cboErrDealHandle.TabIndex = 1;
            this.cboErrDealHandle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboErrDealHandle.Watermark = "";
            this.cboErrDealHandle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(206, 42);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(191, 23);
            this.uiLabel1.TabIndex = 4;
            this.uiLabel1.Text = "uiLabel1";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // TipForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(581, 450);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TipForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提示";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TipForm_FormClosing);
            this.Load += new System.EventHandler(this.TipForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ProxyTools.SunnyUI.Controls.UILabel uiLabel1;
        private ProxyTools.SunnyUI.Controls.UIComboBox cboErrDealHandle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lb_StartTime;
        private ProxyTools.SunnyUI.Controls.UIComboBox cb_SelectItems_Level1;
        private System.Windows.Forms.Label lb_TipLevel2;
        private ProxyTools.SunnyUI.Controls.UIComboBox cb_SelectItems_Level2;
        private ProxyTools.SunnyUI.Controls.UIRichTextBox rtb_Message;
        private System.Windows.Forms.Panel panel1;
        private ProxyTools.SunnyUI.Controls.UIButton btnConfirm;
        private ProxyTools.SunnyUI.Controls.UILabel lb_StartTimeLabel;
    }
}