using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.StationCommon.CommonUI
{
    partial class StationsConfigControl
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tsStationsConfig = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsl_StationSelect = new System.Windows.Forms.ToolStripLabel();
            this.tsCmbStations = new System.Windows.Forms.ToolStripComboBox();
            this.tsBtnAddStation = new System.Windows.Forms.ToolStripButton();
            this.tsDelStation = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsl_SettingPath = new System.Windows.Forms.ToolStripLabel();
            this.tsTbStationsConfigFilePath = new System.Windows.Forms.ToolStripTextBox();
            this.tsBtnOpenConfigFilePath = new System.Windows.Forms.ToolStripButton();
            this.tsBtnLoadStationsConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tabStations = new System.Windows.Forms.TabControl();
            this.tlpMain.SuspendLayout();
            this.tsStationsConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tsStationsConfig, 0, 0);
            this.tlpMain.Controls.Add(this.tabStations, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.73684F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(1276, 651);
            this.tlpMain.TabIndex = 0;
            // 
            // tsStationsConfig
            // 
            this.tsStationsConfig.BackColor = System.Drawing.Color.LightGray;
            this.tsStationsConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsStationsConfig.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsStationsConfig.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsStationsConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.tsl_StationSelect,
            this.tsCmbStations,
            this.tsBtnAddStation,
            this.tsDelStation,
            this.toolStripSeparator7,
            this.tsl_SettingPath,
            this.tsTbStationsConfigFilePath,
            this.tsBtnOpenConfigFilePath,
            this.tsBtnLoadStationsConfig,
            this.toolStripSeparator8});
            this.tsStationsConfig.Location = new System.Drawing.Point(4, 4);
            this.tsStationsConfig.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.tsStationsConfig.Name = "tsStationsConfig";
            this.tsStationsConfig.Padding = new System.Windows.Forms.Padding(0);
            this.tsStationsConfig.Size = new System.Drawing.Size(1268, 30);
            this.tsStationsConfig.TabIndex = 34;
            this.tsStationsConfig.Text = "脉冲比较触发配置";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 30);
            // 
            // tsl_StationSelect
            // 
            this.tsl_StationSelect.Name = "tsl_StationSelect";
            this.tsl_StationSelect.Size = new System.Drawing.Size(89, 27);
            this.tsl_StationSelect.Text = "工站选择：";
            // 
            // tsCmbStations
            // 
            this.tsCmbStations.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsCmbStations.Name = "tsCmbStations";
            this.tsCmbStations.Size = new System.Drawing.Size(80, 30);
            // 
            // tsBtnAddStation
            // 
            this.tsBtnAddStation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnAddStation.Image = global::Lead.CPrim.StationCommon.Properties.Resources.Add_1;
            this.tsBtnAddStation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddStation.Name = "tsBtnAddStation";
            this.tsBtnAddStation.Size = new System.Drawing.Size(29, 27);
            this.tsBtnAddStation.Text = "添加工站";
            this.tsBtnAddStation.Visible = false;
            this.tsBtnAddStation.Click += new System.EventHandler(this.tsBtnAddStation_Click);
            // 
            // tsDelStation
            // 
            this.tsDelStation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDelStation.Image = global::Lead.CPrim.StationCommon.Properties.Resources.Remove_1;
            this.tsDelStation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelStation.Name = "tsDelStation";
            this.tsDelStation.Size = new System.Drawing.Size(29, 27);
            this.tsDelStation.Text = "移除当前工站";
            this.tsDelStation.Visible = false;
            this.tsDelStation.Click += new System.EventHandler(this.tsDelProduct_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 30);
            // 
            // tsl_SettingPath
            // 
            this.tsl_SettingPath.Name = "tsl_SettingPath";
            this.tsl_SettingPath.Size = new System.Drawing.Size(89, 27);
            this.tsl_SettingPath.Text = "配置路径：";
            // 
            // tsTbStationsConfigFilePath
            // 
            this.tsTbStationsConfigFilePath.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.tsTbStationsConfigFilePath.Name = "tsTbStationsConfigFilePath";
            this.tsTbStationsConfigFilePath.Size = new System.Drawing.Size(400, 30);
            // 
            // tsBtnOpenConfigFilePath
            // 
            this.tsBtnOpenConfigFilePath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnOpenConfigFilePath.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsBtnOpenConfigFilePath.Image = global::Lead.CPrim.StationCommon.Properties.Resources.Save;
            this.tsBtnOpenConfigFilePath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnOpenConfigFilePath.Name = "tsBtnOpenConfigFilePath";
            this.tsBtnOpenConfigFilePath.Size = new System.Drawing.Size(31, 27);
            this.tsBtnOpenConfigFilePath.Text = "...";
            this.tsBtnOpenConfigFilePath.ToolTipText = "选择配置文件";
            this.tsBtnOpenConfigFilePath.Click += new System.EventHandler(this.tsBtnOpenConfigFilePath_Click);
            // 
            // tsBtnLoadStationsConfig
            // 
            this.tsBtnLoadStationsConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnLoadStationsConfig.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsBtnLoadStationsConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnLoadStationsConfig.Name = "tsBtnLoadStationsConfig";
            this.tsBtnLoadStationsConfig.Size = new System.Drawing.Size(43, 27);
            this.tsBtnLoadStationsConfig.Text = "载入";
            this.tsBtnLoadStationsConfig.Click += new System.EventHandler(this.tsBtnLoadCmpTrigConfig_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 30);
            // 
            // tabStations
            // 
            this.tabStations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabStations.Location = new System.Drawing.Point(3, 37);
            this.tabStations.Name = "tabStations";
            this.tabStations.SelectedIndex = 0;
            this.tabStations.Size = new System.Drawing.Size(1270, 611);
            this.tabStations.TabIndex = 35;
            // 
            // StationsConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tlpMain);
            this.Name = "StationsConfigControl";
            this.Size = new System.Drawing.Size(1276, 651);
            this.Load += new System.EventHandler(this.StationsConfigControl_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tsStationsConfig.ResumeLayout(false);
            this.tsStationsConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tlpMain;
        private ToolStrip tsStationsConfig;
        private ToolStripButton tsDelStation;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripLabel tsl_StationSelect;
        private ToolStripComboBox tsCmbStations;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton tsBtnAddStation;
        private TabControl tabStations;
        private ToolStripTextBox tsTbStationsConfigFilePath;
        private ToolStripButton tsBtnOpenConfigFilePath;
        private ToolStripButton tsBtnLoadStationsConfig;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripLabel tsl_SettingPath;
    }
}
