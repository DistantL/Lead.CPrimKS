
namespace Lead.CPrim.ProxyTools
{
    partial class LanguageCfgUi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiTableLayoutPanel1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.uiTextBox1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.toolStripMenuItem_ImportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.timerQuery = new System.Windows.Forms.Timer(this.components);
            this.languageBindBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chinese = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.English = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.uiContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.languageBindBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // uiTableLayoutPanel1
            // 
            this.uiTableLayoutPanel1.ColumnCount = 1;
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel1.Controls.Add(this.uiTextBox1, 0, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.uiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            this.uiTableLayoutPanel1.RowCount = 2;
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.45933F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.54067F));
            this.uiTableLayoutPanel1.Size = new System.Drawing.Size(1267, 871);
            this.uiTableLayoutPanel1.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.uiTableLayoutPanel1.TabIndex = 0;
            this.uiTableLayoutPanel1.TagString = null;
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.uiTextBox1.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.uiTextBox1.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.uiTextBox1.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.uiTextBox1.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.uiTextBox1.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTextBox1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiTextBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox1.Location = new System.Drawing.Point(4, 5);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.Radius = 20;
            this.uiTextBox1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.uiTextBox1.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.uiTextBox1.ShowText = false;
            this.uiTextBox1.Size = new System.Drawing.Size(1259, 46);
            this.uiTextBox1.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.uiTextBox1.TabIndex = 0;
            this.uiTextBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiTextBox1.TextChanged += new System.EventHandler(this.uiTextBox1_Changed);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.Chinese,
            this.English,
            this.Vn});
            this.dataGridView1.ContextMenuStrip = this.uiContextMenuStrip1;
            this.dataGridView1.DataSource = this.languageBindBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1261, 809);
            this.dataGridView1.TabIndex = 1;
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ImportCSV,
            this.toolStripMenuItem_ExportCSV,
            this.toolStripMenuItem_Delete});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(190, 100);
            this.uiContextMenuStrip1.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.uiContextMenuStrip1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // toolStripMenuItem_ImportCSV
            // 
            this.toolStripMenuItem_ImportCSV.Name = "toolStripMenuItem_ImportCSV";
            this.toolStripMenuItem_ImportCSV.Size = new System.Drawing.Size(189, 32);
            this.toolStripMenuItem_ImportCSV.Text = "ImportCSV";
            this.toolStripMenuItem_ImportCSV.Click += new System.EventHandler(this.toolStripMenuItem_ImportCSV_Click);
            // 
            // toolStripMenuItem_ExportCSV
            // 
            this.toolStripMenuItem_ExportCSV.Name = "toolStripMenuItem_ExportCSV";
            this.toolStripMenuItem_ExportCSV.Size = new System.Drawing.Size(189, 32);
            this.toolStripMenuItem_ExportCSV.Text = "ExportCSV";
            this.toolStripMenuItem_ExportCSV.Click += new System.EventHandler(this.toolStripMenuItem_ExportCSV_Click);
            // 
            // toolStripMenuItem_Delete
            // 
            this.toolStripMenuItem_Delete.Name = "toolStripMenuItem_Delete";
            this.toolStripMenuItem_Delete.Size = new System.Drawing.Size(189, 32);
            this.toolStripMenuItem_Delete.Text = "Delete";
            this.toolStripMenuItem_Delete.Click += new System.EventHandler(this.toolStripMenuItem_Delete_Click);
            // 
            // timerQuery
            // 
            this.timerQuery.Interval = 200;
            this.timerQuery.Tick += new System.EventHandler(this.timerQuery_Tick);
            // 
            // languageBindBindingSource
            // 
            this.languageBindBindingSource.DataSource = typeof( Lead.CPrim.ProxyTools.LanguageInfo);
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ItemName.DataPropertyName = "Name";
            this.ItemName.FillWeight = 3.894838F;
            this.ItemName.HeaderText = "名称";
            this.ItemName.MinimumWidth = 20;
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 300;
            // 
            // Chinese
            // 
            this.Chinese.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Chinese.DataPropertyName = "Chinese";
            this.Chinese.FillWeight = 20.20519F;
            this.Chinese.HeaderText = "中文简体";
            this.Chinese.MinimumWidth = 20;
            this.Chinese.Name = "Chinese";
            this.Chinese.Width = 300;
            // 
            // English
            // 
            this.English.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.English.DataPropertyName = "English";
            this.English.FillWeight = 74.29569F;
            this.English.HeaderText = "English";
            this.English.MinimumWidth = 20;
            this.English.Name = "English";
            this.English.Width = 300;
            // 
            // Vn
            // 
            this.Vn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Vn.DataPropertyName = "Vn";
            this.Vn.FillWeight = 301.6043F;
            this.Vn.HeaderText = "Tiếng Việt";
            this.Vn.MinimumWidth = 20;
            this.Vn.Name = "Vn";
            this.Vn.Width = 300;
            // 
            // LanguageCfgUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.uiTableLayoutPanel1);
            this.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.Name = "LanguageCfgUi";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.Size = new System.Drawing.Size(1267, 871);
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.Load += new System.EventHandler(this.LanguageCfgUi_Load);
            this.uiTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.uiContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.languageBindBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ProxyTools.SunnyUI.Controls.UITableLayoutPanel uiTableLayoutPanel1;
        private ProxyTools.SunnyUI.Controls.UITextBox uiTextBox1;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ImportCSV;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ExportCSV;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Delete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timerQuery;
        private System.Windows.Forms.BindingSource languageBindBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chinese;
        private System.Windows.Forms.DataGridViewTextBoxColumn English;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vn;
    }
}
