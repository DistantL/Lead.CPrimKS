using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System.Windows.Forms;

namespace Lead.CPrim.StationCommon.Alert
{
    partial class AlertFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpAlert = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.btnSave = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnQuery = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.lblEndTime = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblStartTime = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.dtpStartTime = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDatetimePicker();
            this.dtpEndTime = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDatetimePicker();
            this.pnlAlertTop10 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.pnlAlertTimeStatic = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.pnlAlertData = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.dgvAlertData = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeInState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alertInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tlpAlert.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.pnlAlertData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlertData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpAlert
            // 
            this.tlpAlert.ColumnCount = 2;
            this.tlpAlert.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAlert.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAlert.Controls.Add(this.pnlTitle, 0, 0);
            this.tlpAlert.Controls.Add(this.pnlAlertTop10, 0, 1);
            this.tlpAlert.Controls.Add(this.pnlAlertTimeStatic, 1, 1);
            this.tlpAlert.Controls.Add(this.pnlAlertData, 0, 2);
            this.tlpAlert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAlert.Location = new System.Drawing.Point(0, 0);
            this.tlpAlert.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAlert.Name = "tlpAlert";
            this.tlpAlert.RowCount = 3;
            this.tlpAlert.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpAlert.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAlert.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAlert.Size = new System.Drawing.Size(1285, 830);
            this.tlpAlert.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tlpAlert.TabIndex = 12;
            this.tlpAlert.TagString = null;
            // 
            // pnlTitle
            // 
            this.tlpAlert.SetColumnSpan(this.pnlTitle, 2);
            this.pnlTitle.Controls.Add(this.btnSave);
            this.pnlTitle.Controls.Add(this.btnQuery);
            this.pnlTitle.Controls.Add(this.lblEndTime);
            this.pnlTitle.Controls.Add(this.lblStartTime);
            this.pnlTitle.Controls.Add(this.dtpStartTime);
            this.pnlTitle.Controls.Add(this.dtpEndTime);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTitle.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1285, 45);
            this.pnlTitle.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(745, 7);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Radius = 10;
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.Transparent;
            this.btnQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuery.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(639, 7);
            this.btnQuery.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Radius = 10;
            this.btnQuery.Size = new System.Drawing.Size(100, 35);
            this.btnQuery.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnQuery.TabIndex = 13;
            this.btnQuery.Text = "Query";
            this.btnQuery.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblEndTime
            // 
            this.lblEndTime.BackColor = System.Drawing.Color.Transparent;
            this.lblEndTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblEndTime.Location = new System.Drawing.Point(330, 11);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(112, 27);
            this.lblEndTime.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lblEndTime.TabIndex = 12;
            this.lblEndTime.Text = "End Time:";
            this.lblEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblEndTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblStartTime
            // 
            this.lblStartTime.BackColor = System.Drawing.Color.Transparent;
            this.lblStartTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblStartTime.Location = new System.Drawing.Point(3, 11);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(123, 27);
            this.lblStartTime.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lblStartTime.TabIndex = 12;
            this.lblStartTime.Text = "Start Time:";
            this.lblStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblStartTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.FillColor = System.Drawing.Color.White;
            this.dtpStartTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpStartTime.Location = new System.Drawing.Point(133, 10);
            this.dtpStartTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpStartTime.MaxLength = 19;
            this.dtpStartTime.MinimumSize = new System.Drawing.Size(63, 0);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.dtpStartTime.Size = new System.Drawing.Size(180, 29);
            this.dtpStartTime.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.dtpStartTime.SymbolDropDown = 61555;
            this.dtpStartTime.SymbolNormal = 61555;
            this.dtpStartTime.TabIndex = 10;
            this.dtpStartTime.Text = "2023-01-09 01:43:42";
            this.dtpStartTime.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.dtpStartTime.Value = new System.DateTime(2023, 1, 9, 1, 43, 42, 702);
            this.dtpStartTime.Watermark = "";
            this.dtpStartTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.FillColor = System.Drawing.Color.White;
            this.dtpEndTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEndTime.Location = new System.Drawing.Point(452, 10);
            this.dtpEndTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpEndTime.MaxLength = 19;
            this.dtpEndTime.MinimumSize = new System.Drawing.Size(63, 0);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.dtpEndTime.Size = new System.Drawing.Size(180, 29);
            this.dtpEndTime.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.dtpEndTime.SymbolDropDown = 61555;
            this.dtpEndTime.SymbolNormal = 61555;
            this.dtpEndTime.TabIndex = 11;
            this.dtpEndTime.Text = "2023-01-09 01:48:56";
            this.dtpEndTime.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.dtpEndTime.Value = new System.DateTime(2023, 1, 9, 1, 48, 56, 775);
            this.dtpEndTime.Watermark = "";
            this.dtpEndTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pnlAlertTop10
            // 
            this.pnlAlertTop10.BackColor = System.Drawing.Color.Transparent;
            this.pnlAlertTop10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAlertTop10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlAlertTop10.Location = new System.Drawing.Point(5, 50);
            this.pnlAlertTop10.Margin = new System.Windows.Forms.Padding(5);
            this.pnlAlertTop10.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlAlertTop10.Name = "pnlAlertTop10";
            this.pnlAlertTop10.Padding = new System.Windows.Forms.Padding(5);
            this.pnlAlertTop10.RadiusSides = Lead.CPrim.ProxyTools.UICornerRadiusSides.None;
            this.pnlAlertTop10.Size = new System.Drawing.Size(632, 382);
            this.pnlAlertTop10.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.pnlAlertTop10.TabIndex = 11;
            this.pnlAlertTop10.Text = null;
            this.pnlAlertTop10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlAlertTop10.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pnlAlertTimeStatic
            // 
            this.pnlAlertTimeStatic.BackColor = System.Drawing.Color.Transparent;
            this.pnlAlertTimeStatic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAlertTimeStatic.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlAlertTimeStatic.Location = new System.Drawing.Point(647, 50);
            this.pnlAlertTimeStatic.Margin = new System.Windows.Forms.Padding(5);
            this.pnlAlertTimeStatic.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlAlertTimeStatic.Name = "pnlAlertTimeStatic";
            this.pnlAlertTimeStatic.Padding = new System.Windows.Forms.Padding(5);
            this.pnlAlertTimeStatic.RadiusSides = Lead.CPrim.ProxyTools.UICornerRadiusSides.None;
            this.pnlAlertTimeStatic.Size = new System.Drawing.Size(633, 382);
            this.pnlAlertTimeStatic.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.pnlAlertTimeStatic.TabIndex = 11;
            this.pnlAlertTimeStatic.Text = null;
            this.pnlAlertTimeStatic.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlAlertTimeStatic.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pnlAlertData
            // 
            this.pnlAlertData.BackColor = System.Drawing.Color.Transparent;
            this.tlpAlert.SetColumnSpan(this.pnlAlertData, 2);
            this.pnlAlertData.Controls.Add(this.dgvAlertData);
            this.pnlAlertData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAlertData.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlAlertData.Location = new System.Drawing.Point(5, 442);
            this.pnlAlertData.Margin = new System.Windows.Forms.Padding(5);
            this.pnlAlertData.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlAlertData.Name = "pnlAlertData";
            this.pnlAlertData.Padding = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.pnlAlertData.RadiusSides = Lead.CPrim.ProxyTools.UICornerRadiusSides.None;
            this.pnlAlertData.Size = new System.Drawing.Size(1275, 383);
            this.pnlAlertData.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.pnlAlertData.TabIndex = 11;
            this.pnlAlertData.Text = null;
            this.pnlAlertData.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlAlertData.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dgvAlertData
            // 
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvAlertData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvAlertData.AutoGenerateColumns = false;
            this.dgvAlertData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvAlertData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlertData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvAlertData.ColumnHeadersHeight = 45;
            this.dgvAlertData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAlertData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.startTime,
            this.endTime,
            this.timeInState,
            this.errorCode,
            this.errorMessage,
            this.errorDetail});
            this.dgvAlertData.DataSource = this.alertInfoBindingSource;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle28.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAlertData.DefaultCellStyle = dataGridViewCellStyle28;
            this.dgvAlertData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlertData.EnableHeadersVisualStyles = false;
            this.dgvAlertData.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvAlertData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgvAlertData.Location = new System.Drawing.Point(10, 10);
            this.dgvAlertData.Name = "dgvAlertData";
            this.dgvAlertData.ReadOnly = true;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle29.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlertData.RowHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.dgvAlertData.RowHeadersWidth = 51;
            dataGridViewCellStyle30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle30.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvAlertData.RowsDefaultCellStyle = dataGridViewCellStyle30;
            this.dgvAlertData.RowTemplate.Height = 27;
            this.dgvAlertData.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgvAlertData.SelectedIndex = -1;
            this.dgvAlertData.Size = new System.Drawing.Size(1255, 368);
            this.dgvAlertData.StripeEvenColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.dgvAlertData.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.dgvAlertData.TabIndex = 0;
            this.dgvAlertData.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dgvAlertData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAlertData_CellFormatting);
            // 
            // date
            // 
            this.date.DataPropertyName = "Date";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.Format = "yyyy-MM-dd";
            this.date.DefaultCellStyle = dataGridViewCellStyle23;
            this.date.HeaderText = "Date";
            this.date.MinimumWidth = 8;
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 120;
            // 
            // startTime
            // 
            this.startTime.DataPropertyName = "CreateTime";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.Format = "yyyy-MM-dd HH:mm:ss.fff";
            this.startTime.DefaultCellStyle = dataGridViewCellStyle24;
            this.startTime.HeaderText = "Start Time";
            this.startTime.MinimumWidth = 6;
            this.startTime.Name = "startTime";
            this.startTime.ReadOnly = true;
            this.startTime.Width = 180;
            // 
            // endTime
            // 
            this.endTime.DataPropertyName = "EndTime";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.endTime.DefaultCellStyle = dataGridViewCellStyle25;
            this.endTime.HeaderText = "End Time";
            this.endTime.MinimumWidth = 8;
            this.endTime.Name = "endTime";
            this.endTime.ReadOnly = true;
            this.endTime.Width = 180;
            // 
            // timeInState
            // 
            this.timeInState.DataPropertyName = "TimeInState";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.timeInState.DefaultCellStyle = dataGridViewCellStyle26;
            this.timeInState.HeaderText = "Time In State（Min）";
            this.timeInState.MinimumWidth = 8;
            this.timeInState.Name = "timeInState";
            this.timeInState.ReadOnly = true;
            this.timeInState.Width = 130;
            // 
            // errorCode
            // 
            this.errorCode.DataPropertyName = "ErrorCode";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.errorCode.DefaultCellStyle = dataGridViewCellStyle27;
            this.errorCode.HeaderText = "Error Code";
            this.errorCode.MinimumWidth = 8;
            this.errorCode.Name = "errorCode";
            this.errorCode.ReadOnly = true;
            this.errorCode.Width = 120;
            // 
            // errorMessage
            // 
            this.errorMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.errorMessage.DataPropertyName = "ErrorMessage";
            this.errorMessage.HeaderText = "Error Message";
            this.errorMessage.MinimumWidth = 8;
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.ReadOnly = true;
            // 
            // errorDetail
            // 
            this.errorDetail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.errorDetail.DataPropertyName = "ErrorDetail";
            this.errorDetail.HeaderText = "Error Detail";
            this.errorDetail.MinimumWidth = 8;
            this.errorDetail.Name = "errorDetail";
            this.errorDetail.ReadOnly = true;
            // 
            // alertInfoBindingSource
            // 
            this.alertInfoBindingSource.DataSource = typeof(Lead.CPrim.Interfaces.AlertInfo);
            // 
            // AlertFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1285, 830);
            this.Controls.Add(this.tlpAlert);
            this.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "AlertFrm";
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.Text = "日志";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlertFrm_FormClosing);
            this.Load += new System.EventHandler(this.AlertFrm_Load);
            this.tlpAlert.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlAlertData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlertData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private UITableLayoutPanel tlpAlert;
        private UIPanel pnlAlertTop10;
        private UIPanel pnlAlertTimeStatic;
        private UIPanel pnlAlertData;
        private UIDataGridView dgvAlertData;
        private BindingSource alertInfoBindingSource;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn startTime;
        private DataGridViewTextBoxColumn endTime;
        private DataGridViewTextBoxColumn timeInState;
        private DataGridViewTextBoxColumn errorCode;
        private DataGridViewTextBoxColumn errorMessage;
        private DataGridViewTextBoxColumn errorDetail;
        private Panel pnlTitle;
        private UIButton btnSave;
        private UIButton btnQuery;
        private UILabel lblEndTime;
        private UILabel lblStartTime;
        private UIDatetimePicker dtpStartTime;
        private UIDatetimePicker dtpEndTime;
    }
}
