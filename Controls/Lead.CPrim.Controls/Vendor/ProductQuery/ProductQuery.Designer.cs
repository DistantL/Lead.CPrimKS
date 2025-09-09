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
    partial class ProductQuery
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
            this.tlpTitle = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.lb_EndTime = new System.Windows.Forms.Label();
            this.lb_StartTime = new System.Windows.Forms.Label();
            this.btnComplexQuery = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbStations = new System.Windows.Forms.ComboBox();
            this.lb_ProductionName = new System.Windows.Forms.Label();
            this.lb_StationName = new System.Windows.Forms.Label();
            this.cmbProducts = new System.Windows.Forms.ComboBox();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lb_ID = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lbUph = new System.Windows.Forms.Label();
            this.gb_StatisticsInfo = new System.Windows.Forms.GroupBox();
            this.tlpStatic = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.tbCt = new System.Windows.Forms.TextBox();
            this.cbNoIncludeOk = new System.Windows.Forms.CheckBox();
            this.cbNoIncludeNg = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbOk = new System.Windows.Forms.TextBox();
            this.lb_CT = new System.Windows.Forms.Label();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.tbNg = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbRate = new System.Windows.Forms.TextBox();
            this.lb_Total = new System.Windows.Forms.Label();
            this.lb_Yield = new System.Windows.Forms.Label();
            this.dgvResult = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDataGridView();
            this.cmsExport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsiExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpMain = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.tlpTitle.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.gb_StatisticsInfo.SuspendLayout();
            this.tlpStatic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.cmsExport.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpTitle
            // 
            this.tlpTitle.ColumnCount = 9;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.tlpTitle.Controls.Add(this.lb_EndTime, 0, 1);
            this.tlpTitle.Controls.Add(this.lb_StartTime, 0, 0);
            this.tlpTitle.Controls.Add(this.btnComplexQuery, 8, 0);
            this.tlpTitle.Controls.Add(this.btnDelete, 7, 0);
            this.tlpTitle.Controls.Add(this.btnSearch, 6, 0);
            this.tlpTitle.Controls.Add(this.cmbStations, 3, 0);
            this.tlpTitle.Controls.Add(this.lb_ProductionName, 2, 1);
            this.tlpTitle.Controls.Add(this.lb_StationName, 2, 0);
            this.tlpTitle.Controls.Add(this.cmbProducts, 3, 1);
            this.tlpTitle.Controls.Add(this.dtpStartTime, 1, 0);
            this.tlpTitle.Controls.Add(this.dtpEndTime, 1, 1);
            this.tlpTitle.Controls.Add(this.lb_ID, 4, 1);
            this.tlpTitle.Controls.Add(this.tbId, 5, 1);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tlpTitle.Location = new System.Drawing.Point(0, 0);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 2;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTitle.Size = new System.Drawing.Size(1176, 70);
            this.tlpTitle.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tlpTitle.TabIndex = 34;
            this.tlpTitle.TagString = null;
            // 
            // lb_EndTime
            // 
            this.lb_EndTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_EndTime.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lb_EndTime.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_EndTime.Location = new System.Drawing.Point(3, 38);
            this.lb_EndTime.Margin = new System.Windows.Forms.Padding(3);
            this.lb_EndTime.Name = "lb_EndTime";
            this.lb_EndTime.Size = new System.Drawing.Size(99, 29);
            this.lb_EndTime.TabIndex = 36;
            this.lb_EndTime.Text = "结束时间：";
            this.lb_EndTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_StartTime
            // 
            this.lb_StartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_StartTime.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lb_StartTime.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_StartTime.Location = new System.Drawing.Point(3, 3);
            this.lb_StartTime.Margin = new System.Windows.Forms.Padding(3);
            this.lb_StartTime.Name = "lb_StartTime";
            this.lb_StartTime.Size = new System.Drawing.Size(99, 29);
            this.lb_StartTime.TabIndex = 35;
            this.lb_StartTime.Text = "起始时间：";
            this.lb_StartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnComplexQuery
            // 
            this.btnComplexQuery.BackColor = System.Drawing.Color.Yellow;
            this.btnComplexQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnComplexQuery.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.btnComplexQuery.Location = new System.Drawing.Point(1047, 3);
            this.btnComplexQuery.Name = "btnComplexQuery";
            this.tlpTitle.SetRowSpan(this.btnComplexQuery, 2);
            this.btnComplexQuery.Size = new System.Drawing.Size(126, 64);
            this.btnComplexQuery.TabIndex = 34;
            this.btnComplexQuery.Text = "复杂查询";
            this.btnComplexQuery.UseVisualStyleBackColor = false;
            this.btnComplexQuery.Click += new System.EventHandler(this.btnComplexQuery_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Brown;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.btnDelete.ForeColor = System.Drawing.Color.Transparent;
            this.btnDelete.Location = new System.Drawing.Point(953, 3);
            this.btnDelete.Name = "btnDelete";
            this.tlpTitle.SetRowSpan(this.btnDelete, 2);
            this.btnDelete.Size = new System.Drawing.Size(88, 64);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.GreenYellow;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.btnSearch.Location = new System.Drawing.Point(859, 3);
            this.btnSearch.Name = "btnSearch";
            this.tlpTitle.SetRowSpan(this.btnSearch, 2);
            this.btnSearch.Size = new System.Drawing.Size(88, 64);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // cmbStations
            // 
            this.cmbStations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbStations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStations.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cmbStations.FormattingEnabled = true;
            this.cmbStations.Location = new System.Drawing.Point(425, 3);
            this.cmbStations.Name = "cmbStations";
            this.cmbStations.Size = new System.Drawing.Size(111, 27);
            this.cmbStations.TabIndex = 33;
            // 
            // lb_ProductionName
            // 
            this.lb_ProductionName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_ProductionName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lb_ProductionName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_ProductionName.Location = new System.Drawing.Point(343, 38);
            this.lb_ProductionName.Margin = new System.Windows.Forms.Padding(3);
            this.lb_ProductionName.Name = "lb_ProductionName";
            this.lb_ProductionName.Size = new System.Drawing.Size(76, 29);
            this.lb_ProductionName.TabIndex = 29;
            this.lb_ProductionName.Text = "产品：";
            this.lb_ProductionName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_StationName
            // 
            this.lb_StationName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_StationName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lb_StationName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_StationName.Location = new System.Drawing.Point(343, 3);
            this.lb_StationName.Margin = new System.Windows.Forms.Padding(3);
            this.lb_StationName.Name = "lb_StationName";
            this.lb_StationName.Size = new System.Drawing.Size(76, 29);
            this.lb_StationName.TabIndex = 32;
            this.lb_StationName.Text = "工站：";
            this.lb_StationName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbProducts
            // 
            this.cmbProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducts.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cmbProducts.FormattingEnabled = true;
            this.cmbProducts.Location = new System.Drawing.Point(425, 38);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new System.Drawing.Size(111, 27);
            this.cmbProducts.TabIndex = 30;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtpStartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpStartTime.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(108, 3);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(229, 25);
            this.dtpStartTime.TabIndex = 22;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtpEndTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpEndTime.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(108, 38);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(229, 25);
            this.dtpEndTime.TabIndex = 24;
            // 
            // lb_ID
            // 
            this.lb_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_ID.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lb_ID.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_ID.Location = new System.Drawing.Point(542, 38);
            this.lb_ID.Margin = new System.Windows.Forms.Padding(3);
            this.lb_ID.Name = "lb_ID";
            this.lb_ID.Size = new System.Drawing.Size(76, 29);
            this.lb_ID.TabIndex = 25;
            this.lb_ID.Text = "ID：";
            this.lb_ID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbId
            // 
            this.tbId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbId.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tbId.Location = new System.Drawing.Point(624, 38);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(229, 25);
            this.tbId.TabIndex = 26;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox6.Controls.Add(this.lbUph);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.ForeColor = System.Drawing.Color.DarkOrange;
            this.groupBox6.Location = new System.Drawing.Point(1180, 5);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Size = new System.Drawing.Size(202, 60);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "UPH";
            // 
            // lbUph
            // 
            this.lbUph.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbUph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUph.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUph.ForeColor = System.Drawing.Color.Lime;
            this.lbUph.Location = new System.Drawing.Point(4, 21);
            this.lbUph.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUph.Name = "lbUph";
            this.lbUph.Size = new System.Drawing.Size(194, 34);
            this.lbUph.TabIndex = 2;
            this.lbUph.Text = "192K/h";
            this.lbUph.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gb_StatisticsInfo
            // 
            this.gb_StatisticsInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gb_StatisticsInfo.Controls.Add(this.tlpStatic);
            this.gb_StatisticsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_StatisticsInfo.ForeColor = System.Drawing.Color.DarkOrange;
            this.gb_StatisticsInfo.Location = new System.Drawing.Point(1180, 74);
            this.gb_StatisticsInfo.Margin = new System.Windows.Forms.Padding(4);
            this.gb_StatisticsInfo.Name = "gb_StatisticsInfo";
            this.gb_StatisticsInfo.Padding = new System.Windows.Forms.Padding(4);
            this.gb_StatisticsInfo.Size = new System.Drawing.Size(202, 586);
            this.gb_StatisticsInfo.TabIndex = 5;
            this.gb_StatisticsInfo.TabStop = false;
            this.gb_StatisticsInfo.Text = "统计信息";
            // 
            // tlpStatic
            // 
            this.tlpStatic.ColumnCount = 1;
            this.tlpStatic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatic.Controls.Add(this.tbCt, 0, 11);
            this.tlpStatic.Controls.Add(this.cbNoIncludeOk, 0, 0);
            this.tlpStatic.Controls.Add(this.cbNoIncludeNg, 0, 3);
            this.tlpStatic.Controls.Add(this.label9, 0, 1);
            this.tlpStatic.Controls.Add(this.tbOk, 0, 2);
            this.tlpStatic.Controls.Add(this.lb_CT, 0, 10);
            this.tlpStatic.Controls.Add(this.tbTotal, 0, 9);
            this.tlpStatic.Controls.Add(this.tbNg, 0, 5);
            this.tlpStatic.Controls.Add(this.label7, 0, 4);
            this.tlpStatic.Controls.Add(this.tbRate, 0, 7);
            this.tlpStatic.Controls.Add(this.lb_Total, 0, 8);
            this.tlpStatic.Controls.Add(this.lb_Yield, 0, 6);
            this.tlpStatic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStatic.Location = new System.Drawing.Point(4, 20);
            this.tlpStatic.Name = "tlpStatic";
            this.tlpStatic.RowCount = 12;
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpStatic.Size = new System.Drawing.Size(194, 562);
            this.tlpStatic.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tlpStatic.TabIndex = 29;
            this.tlpStatic.TagString = null;
            // 
            // tbCt
            // 
            this.tbCt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tbCt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCt.Location = new System.Drawing.Point(3, 503);
            this.tbCt.Name = "tbCt";
            this.tbCt.Size = new System.Drawing.Size(188, 23);
            this.tbCt.TabIndex = 20;
            this.tbCt.Text = "0";
            this.tbCt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbNoIncludeOk
            // 
            this.cbNoIncludeOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbNoIncludeOk.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cbNoIncludeOk.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cbNoIncludeOk.Location = new System.Drawing.Point(3, 3);
            this.cbNoIncludeOk.Name = "cbNoIncludeOk";
            this.cbNoIncludeOk.Size = new System.Drawing.Size(188, 27);
            this.cbNoIncludeOk.TabIndex = 27;
            this.cbNoIncludeOk.Text = "筛除OK结果";
            this.cbNoIncludeOk.UseVisualStyleBackColor = true;
            // 
            // cbNoIncludeNg
            // 
            this.cbNoIncludeNg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbNoIncludeNg.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cbNoIncludeNg.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cbNoIncludeNg.Location = new System.Drawing.Point(3, 125);
            this.cbNoIncludeNg.Name = "cbNoIncludeNg";
            this.cbNoIncludeNg.Size = new System.Drawing.Size(188, 27);
            this.cbNoIncludeNg.TabIndex = 28;
            this.cbNoIncludeNg.Text = "筛除NG结果";
            this.cbNoIncludeNg.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label9.ForeColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(3, 36);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(188, 27);
            this.label9.TabIndex = 1;
            this.label9.Text = "OK：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbOk
            // 
            this.tbOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tbOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOk.Location = new System.Drawing.Point(3, 69);
            this.tbOk.Name = "tbOk";
            this.tbOk.Size = new System.Drawing.Size(188, 23);
            this.tbOk.TabIndex = 7;
            this.tbOk.Text = "0";
            this.tbOk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_CT
            // 
            this.lb_CT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CT.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lb_CT.ForeColor = System.Drawing.Color.Transparent;
            this.lb_CT.Location = new System.Drawing.Point(3, 459);
            this.lb_CT.Margin = new System.Windows.Forms.Padding(3);
            this.lb_CT.Name = "lb_CT";
            this.lb_CT.Size = new System.Drawing.Size(188, 38);
            this.lb_CT.TabIndex = 19;
            this.lb_CT.Text = "平均CT：";
            this.lb_CT.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbTotal
            // 
            this.tbTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTotal.Location = new System.Drawing.Point(3, 403);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(188, 23);
            this.tbTotal.TabIndex = 15;
            this.tbTotal.Text = "0";
            this.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbNg
            // 
            this.tbNg.BackColor = System.Drawing.Color.Red;
            this.tbNg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNg.ForeColor = System.Drawing.Color.White;
            this.tbNg.Location = new System.Drawing.Point(3, 191);
            this.tbNg.Name = "tbNg";
            this.tbNg.Size = new System.Drawing.Size(188, 23);
            this.tbNg.TabIndex = 8;
            this.tbNg.Text = "0";
            this.tbNg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label7.ForeColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(3, 158);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 27);
            this.label7.TabIndex = 2;
            this.label7.Text = "NG：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbRate
            // 
            this.tbRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tbRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRate.Location = new System.Drawing.Point(3, 297);
            this.tbRate.Name = "tbRate";
            this.tbRate.Size = new System.Drawing.Size(188, 23);
            this.tbRate.TabIndex = 9;
            this.tbRate.Text = "0";
            this.tbRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_Total
            // 
            this.lb_Total.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Total.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lb_Total.ForeColor = System.Drawing.Color.Transparent;
            this.lb_Total.Location = new System.Drawing.Point(3, 353);
            this.lb_Total.Margin = new System.Windows.Forms.Padding(3);
            this.lb_Total.Name = "lb_Total";
            this.lb_Total.Size = new System.Drawing.Size(188, 44);
            this.lb_Total.TabIndex = 14;
            this.lb_Total.Text = "总计：";
            this.lb_Total.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lb_Yield
            // 
            this.lb_Yield.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Yield.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lb_Yield.ForeColor = System.Drawing.Color.Transparent;
            this.lb_Yield.Location = new System.Drawing.Point(3, 247);
            this.lb_Yield.Margin = new System.Windows.Forms.Padding(3);
            this.lb_Yield.Name = "lb_Yield";
            this.lb_Yield.Size = new System.Drawing.Size(188, 44);
            this.lb_Yield.TabIndex = 3;
            this.lb_Yield.Text = "良率：";
            this.lb_Yield.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResult.ColumnHeadersHeight = 32;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvResult.ContextMenuStrip = this.cmsExport;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResult.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.EnableHeadersVisualStyles = false;
            this.dgvResult.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvResult.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgvResult.Location = new System.Drawing.Point(3, 73);
            this.dgvResult.Name = "dgvResult";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvResult.RowHeadersWidth = 62;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvResult.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgvResult.SelectedIndex = -1;
            this.dgvResult.Size = new System.Drawing.Size(1170, 588);
            this.dgvResult.StripeEvenColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.dgvResult.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.dgvResult.TabIndex = 4;
            this.dgvResult.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cmsExport
            // 
            this.cmsExport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsExport.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCopy,
            this.tmsiExport,
            this.tsmiClear});
            this.cmsExport.Name = "contextMenuStrip1";
            this.cmsExport.Size = new System.Drawing.Size(127, 70);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.Size = new System.Drawing.Size(126, 22);
            this.tsmiCopy.Text = "复制";
            this.tsmiCopy.Click += new System.EventHandler(this.tsmiCopy_Click);
            // 
            // tmsiExport
            // 
            this.tmsiExport.Name = "tmsiExport";
            this.tmsiExport.Size = new System.Drawing.Size(126, 22);
            this.tmsiExport.Text = "导出数据";
            this.tmsiExport.Click += new System.EventHandler(this.tmsiExport_Click);
            // 
            // tsmiClear
            // 
            this.tsmiClear.Name = "tsmiClear";
            this.tsmiClear.Size = new System.Drawing.Size(126, 22);
            this.tsmiClear.Text = "清除数据";
            this.tsmiClear.Click += new System.EventHandler(this.tsmiClear_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tlpMain.Controls.Add(this.gb_StatisticsInfo, 1, 1);
            this.tlpMain.Controls.Add(this.groupBox6, 1, 0);
            this.tlpMain.Controls.Add(this.dgvResult, 0, 1);
            this.tlpMain.Controls.Add(this.tlpTitle, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1386, 664);
            this.tlpMain.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tlpMain.TabIndex = 2;
            this.tlpMain.TagString = null;
            // 
            // ProductQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1386, 664);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProductQuery";
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.Load += new System.EventHandler(this.HistoryQueryByMongoDb_Load);
            this.tlpTitle.ResumeLayout(false);
            this.tlpTitle.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.gb_StatisticsInfo.ResumeLayout(false);
            this.tlpStatic.ResumeLayout(false);
            this.tlpStatic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.cmsExport.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private GroupBox groupBox6;
        public Label lbUph;
        private Button btnSearch;
        private ContextMenuStrip cmsExport;
        private ToolStripMenuItem tmsiExport;
        private ToolStripMenuItem tsmiClear;
        private GroupBox gb_StatisticsInfo;
        private CheckBox cbNoIncludeNg;
        private CheckBox cbNoIncludeOk;
        private Label lb_ID;
        private TextBox tbId;
        private DateTimePicker dtpEndTime;
        private DateTimePicker dtpStartTime;
        private TextBox tbTotal;
        private Label lb_Total;
        private TextBox tbRate;
        private TextBox tbNg;
        private TextBox tbOk;
        private Label lb_Yield;
        private Label label7;
        private Label label9;
        private TextBox tbCt;
        private Label lb_CT;
        private ComboBox cmbProducts;
        private Label lb_ProductionName;
        private Button btnDelete;
        private ComboBox cmbStations;
        private Label lb_StationName;
        private Button btnComplexQuery;
        private ProxyTools.SunnyUI.Controls.UITableLayoutPanel tlpTitle;
        private Label lb_EndTime;
        private Label lb_StartTime;
        private UIDataGridView dgvResult;
        private ProxyTools.SunnyUI.Controls.UITableLayoutPanel tlpStatic;
        private ProxyTools.SunnyUI.Controls.UITableLayoutPanel tlpMain;
        private ToolStripMenuItem tsmiCopy;
    }
}
