using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.Authority.Controls
{
    partial class AuthorityLvlShowUI : UserControl
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorityLvlShowUI));
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.tlpLevel = new System.Windows.Forms.TableLayoutPanel();
            this.btnHive = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIImageButton();
            this.btnLogin = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIImageButton();
            this.btnAppleImage = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIImageButton();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tlpLevel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAppleImage)).BeginInit();
            this.uiContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpLevel
            // 
            this.tlpLevel.BackColor = System.Drawing.Color.Transparent;
            this.tlpLevel.ColumnCount = 4;
            this.tlpLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLevel.Controls.Add(this.btnHive, 0, 1);
            this.tlpLevel.Controls.Add(this.btnLogin, 0, 0);
            this.tlpLevel.Controls.Add(this.btnAppleImage, 2, 0);
            this.tlpLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLevel.Location = new System.Drawing.Point(0, 0);
            this.tlpLevel.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLevel.Name = "tlpLevel";
            this.tlpLevel.RowCount = 2;
            this.tlpLevel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLevel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLevel.Size = new System.Drawing.Size(210, 76);
            this.tlpLevel.TabIndex = 25;
            // 
            // btnHive
            // 
            this.btnHive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHive.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHive.Image = global::Lead.CPrim.ProxyTools.Properties.Resources.HIVE_Disabled;
            this.btnHive.Location = new System.Drawing.Point(2, 42);
            this.btnHive.Margin = new System.Windows.Forms.Padding(2, 4, 2, 0);
            this.btnHive.Name = "btnHive";
            this.btnHive.Size = new System.Drawing.Size(131, 34);
            this.btnHive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnHive.TabIndex = 27;
            this.btnHive.TabStop = false;
            this.btnHive.Text = null;
            this.btnHive.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnHive.Click += new System.EventHandler(this.btnHive_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.Image = global::Lead.CPrim.ProxyTools.Properties.Resources.No_login;
            this.btnLogin.Location = new System.Drawing.Point(2, 4);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 4, 2, 0);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(131, 34);
            this.btnLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnLogin.TabIndex = 25;
            this.btnLogin.TabStop = false;
            this.btnLogin.Text = null;
            this.btnLogin.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnAppleImage
            // 
            this.btnAppleImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAppleImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAppleImage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAppleImage.Image = ((System.Drawing.Image)(resources.GetObject("btnAppleImage.Image")));
            this.btnAppleImage.Location = new System.Drawing.Point(155, 0);
            this.btnAppleImage.Margin = new System.Windows.Forms.Padding(0);
            this.btnAppleImage.Name = "btnAppleImage";
            this.tlpLevel.SetRowSpan(this.btnAppleImage, 2);
            this.btnAppleImage.Size = new System.Drawing.Size(45, 76);
            this.btnAppleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAppleImage.TabIndex = 26;
            this.btnAppleImage.TabStop = false;
            this.btnAppleImage.Text = null;
            this.btnAppleImage.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnAppleImage.DoubleClick += new System.EventHandler(this.btnAppleImage_DoubleClick);
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(143, 30);
            this.uiContextMenuStrip1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AuthorityLvlShowUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tlpLevel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Name = "AuthorityLvlShowUI";
            this.Size = new System.Drawing.Size(210, 76);
            this.tlpLevel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAppleImage)).EndInit();
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        #endregion
		private ToolTip tt;
        private TableLayoutPanel tlpLevel;
        private UIImageButton btnLogin;
        private UIImageButton btnAppleImage;
        private UIImageButton btnHive;
        private Timer timer1;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private ToolStripMenuItem logOutToolStripMenuItem;
    }
}
