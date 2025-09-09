using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.Controls
{
    partial class LogsQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsExport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClear = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbLevel = new System.Windows.Forms.ComboBox();
            this.cmbClassfication = new System.Windows.Forms.ComboBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.tbId = new System.Windows.Forms.TextBox();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.tlpTitle = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.lb_Location = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lb_Classfication = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lb_Message = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.dtPickEnd = new System.Windows.Forms.DateTimePicker();
            this.dtPickerStart = new System.Windows.Forms.DateTimePicker();
            this.lb_StartTime = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lb_EndTime = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel3 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lb_Level = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.tlpMain = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.dgvLogHistory = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDataGridView();
            this.bindLogsQueryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsExport.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindLogsQueryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsExport
            // 
            this.cmsExport.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.cmsExport.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCopy,
            this.tsmiExport,
            this.tsmiClear});
            this.cmsExport.Name = "contextMenuStrip1";
            this.cmsExport.Size = new System.Drawing.Size(125, 70);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.Size = new System.Drawing.Size(124, 22);
            this.tsmiCopy.Text = "复制";
            this.tsmiCopy.Click += new System.EventHandler(this.tsmiCopy_Click);
            // 
            // tsmiExport
            // 
            this.tsmiExport.Name = "tsmiExport";
            this.tsmiExport.Size = new System.Drawing.Size(124, 22);
            this.tsmiExport.Text = "导出数据";
            this.tsmiExport.Click += new System.EventHandler(this.tsmiExport_Click);
            // 
            // tsmiClear
            // 
            this.tsmiClear.Name = "tsmiClear";
            this.tsmiClear.Size = new System.Drawing.Size(124, 22);
            this.tsmiClear.Text = "清除数据";
            this.tsmiClear.Click += new System.EventHandler(this.tsmiClear_Click);
            // 
            // cmbLevel
            // 
            this.cmbLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLevel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbLevel.FormattingEnabled = true;
            this.cmbLevel.Location = new System.Drawing.Point(322, 38);
            this.cmbLevel.Name = "cmbLevel";
            this.cmbLevel.Size = new System.Drawing.Size(173, 25);
            this.cmbLevel.TabIndex = 48;
            // 
            // cmbClassfication
            // 
            this.cmbClassfication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbClassfication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClassfication.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbClassfication.FormattingEnabled = true;
            this.cmbClassfication.Location = new System.Drawing.Point(571, 38);
            this.cmbClassfication.Name = "cmbClassfication";
            this.cmbClassfication.Size = new System.Drawing.Size(173, 25);
            this.cmbClassfication.TabIndex = 47;
            // 
            // btnQuery
            // 
            this.btnQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQuery.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(820, 38);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(173, 29);
            this.btnQuery.TabIndex = 43;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // tbId
            // 
            this.tbId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbId.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbId.Location = new System.Drawing.Point(322, 3);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(173, 23);
            this.tbId.TabIndex = 41;
            // 
            // tbLocation
            // 
            this.tbLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLocation.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbLocation.Location = new System.Drawing.Point(820, 3);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(173, 23);
            this.tbLocation.TabIndex = 42;
            // 
            // tbMessage
            // 
            this.tbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMessage.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbMessage.Location = new System.Drawing.Point(571, 3);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(173, 23);
            this.tbMessage.TabIndex = 40;
            // 
            // tlpTitle
            // 
            this.tlpTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tlpTitle.ColumnCount = 8;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTitle.Controls.Add(this.lb_Location, 6, 0);
            this.tlpTitle.Controls.Add(this.lb_Classfication, 4, 1);
            this.tlpTitle.Controls.Add(this.lb_Message, 4, 0);
            this.tlpTitle.Controls.Add(this.dtPickEnd, 1, 1);
            this.tlpTitle.Controls.Add(this.tbId, 3, 0);
            this.tlpTitle.Controls.Add(this.cmbClassfication, 5, 1);
            this.tlpTitle.Controls.Add(this.cmbLevel, 3, 1);
            this.tlpTitle.Controls.Add(this.dtPickerStart, 1, 0);
            this.tlpTitle.Controls.Add(this.tbLocation, 7, 0);
            this.tlpTitle.Controls.Add(this.tbMessage, 5, 0);
            this.tlpTitle.Controls.Add(this.lb_StartTime, 0, 0);
            this.tlpTitle.Controls.Add(this.lb_EndTime, 0, 1);
            this.tlpTitle.Controls.Add(this.uiLabel3, 2, 0);
            this.tlpTitle.Controls.Add(this.lb_Level, 2, 1);
            this.tlpTitle.Controls.Add(this.btnQuery, 7, 1);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTitle.Location = new System.Drawing.Point(0, 0);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 2;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTitle.Size = new System.Drawing.Size(996, 70);
            this.tlpTitle.TabIndex = 0;
            this.tlpTitle.TagString = null;
            // 
            // lb_Location
            // 
            this.lb_Location.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Location.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lb_Location.Location = new System.Drawing.Point(750, 0);
            this.lb_Location.Name = "lb_Location";
            this.lb_Location.Size = new System.Drawing.Size(64, 35);
            this.lb_Location.TabIndex = 54;
            this.lb_Location.Text = "来源:";
            this.lb_Location.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lb_Location.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_Classfication
            // 
            this.lb_Classfication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Classfication.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lb_Classfication.Location = new System.Drawing.Point(501, 35);
            this.lb_Classfication.Name = "lb_Classfication";
            this.lb_Classfication.Size = new System.Drawing.Size(64, 35);
            this.lb_Classfication.TabIndex = 53;
            this.lb_Classfication.Text = "分类:";
            this.lb_Classfication.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lb_Classfication.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_Message
            // 
            this.lb_Message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Message.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lb_Message.Location = new System.Drawing.Point(501, 0);
            this.lb_Message.Name = "lb_Message";
            this.lb_Message.Size = new System.Drawing.Size(64, 35);
            this.lb_Message.TabIndex = 52;
            this.lb_Message.Text = "包含信息:";
            this.lb_Message.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lb_Message.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dtPickEnd
            // 
            this.dtPickEnd.CalendarFont = new System.Drawing.Font("微软雅黑", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtPickEnd.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtPickEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtPickEnd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtPickEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickEnd.Location = new System.Drawing.Point(73, 38);
            this.dtPickEnd.Name = "dtPickEnd";
            this.dtPickEnd.Size = new System.Drawing.Size(173, 23);
            this.dtPickEnd.TabIndex = 51;
            // 
            // dtPickerStart
            // 
            this.dtPickerStart.CalendarFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtPickerStart.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtPickerStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtPickerStart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtPickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickerStart.Location = new System.Drawing.Point(73, 3);
            this.dtPickerStart.Name = "dtPickerStart";
            this.dtPickerStart.Size = new System.Drawing.Size(173, 23);
            this.dtPickerStart.TabIndex = 50;
            // 
            // lb_StartTime
            // 
            this.lb_StartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_StartTime.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lb_StartTime.Location = new System.Drawing.Point(3, 0);
            this.lb_StartTime.Name = "lb_StartTime";
            this.lb_StartTime.Size = new System.Drawing.Size(64, 35);
            this.lb_StartTime.TabIndex = 49;
            this.lb_StartTime.Text = "起始时间:";
            this.lb_StartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lb_StartTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_EndTime
            // 
            this.lb_EndTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_EndTime.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lb_EndTime.Location = new System.Drawing.Point(3, 35);
            this.lb_EndTime.Name = "lb_EndTime";
            this.lb_EndTime.Size = new System.Drawing.Size(64, 35);
            this.lb_EndTime.TabIndex = 49;
            this.lb_EndTime.Text = "终止时间:";
            this.lb_EndTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lb_EndTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel3.Location = new System.Drawing.Point(252, 0);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(64, 35);
            this.uiLabel3.TabIndex = 49;
            this.uiLabel3.Text = "ID:";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_Level
            // 
            this.lb_Level.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Level.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lb_Level.Location = new System.Drawing.Point(252, 35);
            this.lb_Level.Name = "lb_Level";
            this.lb_Level.Size = new System.Drawing.Size(64, 35);
            this.lb_Level.TabIndex = 49;
            this.lb_Level.Text = "等级:";
            this.lb_Level.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lb_Level.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.tlpTitle, 0, 0);
            this.tlpMain.Controls.Add(this.dgvLogHistory, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(996, 700);
            this.tlpMain.TabIndex = 4;
            this.tlpMain.TagString = null;
            // 
            // dgvLogHistory
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvLogHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLogHistory.AutoGenerateColumns = false;
            this.dgvLogHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvLogHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLogHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLogHistory.ColumnHeadersHeight = 32;
            this.dgvLogHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLogHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.timeStamp,
            this.level,
            this.message,
            this.location,
            this.classification});
            this.dgvLogHistory.ContextMenuStrip = this.cmsExport;
            this.dgvLogHistory.DataSource = this.bindLogsQueryBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLogHistory.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLogHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLogHistory.EnableHeadersVisualStyles = false;
            this.dgvLogHistory.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvLogHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgvLogHistory.Location = new System.Drawing.Point(3, 73);
            this.dgvLogHistory.Name = "dgvLogHistory";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLogHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLogHistory.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvLogHistory.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLogHistory.RowTemplate.Height = 27;
            this.dgvLogHistory.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgvLogHistory.SelectedIndex = -1;
            this.dgvLogHistory.Size = new System.Drawing.Size(990, 624);
            this.dgvLogHistory.StripeEvenColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.dgvLogHistory.TabIndex = 1;
            this.dgvLogHistory.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // bindLogsQueryBindingSource
            // 
            this.bindLogsQueryBindingSource.DataSource = typeof(Lead.CPrim.Controls.BindLogsQuery);
            // 
            // timeStamp
            // 
            this.timeStamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.timeStamp.DataPropertyName = "TimeStamp";
            this.timeStamp.HeaderText = "时间";
            this.timeStamp.MinimumWidth = 6;
            this.timeStamp.Name = "timeStamp";
            this.timeStamp.Width = 150;
            // 
            // level
            // 
            this.level.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.level.DataPropertyName = "Level";
            this.level.HeaderText = "等级";
            this.level.MinimumWidth = 6;
            this.level.Name = "level";
            this.level.Width = 80;
            // 
            // message
            // 
            this.message.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.message.DataPropertyName = "Message";
            this.message.HeaderText = "信息";
            this.message.MinimumWidth = 6;
            this.message.Name = "message";
            // 
            // location
            // 
            this.location.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.location.DataPropertyName = "Location";
            this.location.HeaderText = "来源";
            this.location.MinimumWidth = 6;
            this.location.Name = "location";
            // 
            // classification
            // 
            this.classification.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.classification.DataPropertyName = "Classification";
            this.classification.HeaderText = "分类";
            this.classification.MinimumWidth = 6;
            this.classification.Name = "classification";
            // 
            // LogsQuery
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tlpMain);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "LogsQuery";
            this.Size = new System.Drawing.Size(996, 700);
            this.Load += new System.EventHandler(this.LogsHistoryQuery_Load);
            this.cmsExport.ResumeLayout(false);
            this.tlpTitle.ResumeLayout(false);
            this.tlpTitle.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindLogsQueryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ContextMenuStrip cmsExport;
        private ToolStripMenuItem tsmiExport;
        private ToolStripMenuItem tsmiClear;
        private ComboBox cmbLevel;
        private ComboBox cmbClassfication;
        private Button btnQuery;
        private TextBox tbId;
        private TextBox tbLocation;
        private TextBox tbMessage;
        private UITableLayoutPanel tlpTitle;
        private UILabel lb_StartTime;
        private UILabel lb_EndTime;
        private UILabel uiLabel3;
        private UILabel lb_Level;
        private DateTimePicker dtPickerStart;
        private DateTimePicker dtPickEnd;
        private UILabel lb_Location;
        private UILabel lb_Classfication;
        private UITableLayoutPanel tlpMain;
        private UILabel lb_Message;
        private UIDataGridView dgvLogHistory;
        private ToolStripMenuItem tsmiCopy;
        private BindingSource bindLogsQueryBindingSource;
        private DataGridViewTextBoxColumn timeStamp;
        private DataGridViewTextBoxColumn level;
        private DataGridViewTextBoxColumn message;
        private DataGridViewTextBoxColumn location;
        private DataGridViewTextBoxColumn classification;
    }
}
