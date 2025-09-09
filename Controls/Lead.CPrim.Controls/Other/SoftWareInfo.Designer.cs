
using Lead.CPrim.ProxyTools.SunnyUI.Controls;

namespace Lead.CPrim.Controls
{
    partial class SoftWareInfo
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
            this.tlpInfoAll = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.tlpInfoUp = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.lblStation = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.pnlHash = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.lblHashValue = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblHash = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.pnlMainSW = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.lblMainSWPathValue = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblMainSWPath = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.pnlSWVersion = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.lblSWVersionValue = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblSWVersion = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.pnlSite = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.lblSiteValue = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblSite = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.pnlVendor = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.lblVendorValue = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblVendor = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblHiveState = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblMesState = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblPDCAState = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.btnMachineLog = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnHiveLog = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.pnlMain = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.tlpInfoAll.SuspendLayout();
            this.tlpInfoUp.SuspendLayout();
            this.pnlHash.SuspendLayout();
            this.pnlMainSW.SuspendLayout();
            this.pnlSWVersion.SuspendLayout();
            this.pnlSite.SuspendLayout();
            this.pnlVendor.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpInfoAll
            // 
            this.tlpInfoAll.BackColor = System.Drawing.Color.LightGray;
            this.tlpInfoAll.ColumnCount = 7;
            this.tlpInfoAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tlpInfoAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpInfoAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpInfoAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpInfoAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpInfoAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpInfoAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpInfoAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpInfoAll.Controls.Add(this.tlpInfoUp, 1, 0);
            this.tlpInfoAll.Controls.Add(this.lblHiveState, 1, 1);
            this.tlpInfoAll.Controls.Add(this.lblMesState, 3, 1);
            this.tlpInfoAll.Controls.Add(this.lblPDCAState, 5, 1);
            this.tlpInfoAll.Controls.Add(this.btnMachineLog, 1, 2);
            this.tlpInfoAll.Controls.Add(this.btnHiveLog, 4, 2);
            this.tlpInfoAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInfoAll.Location = new System.Drawing.Point(5, 5);
            this.tlpInfoAll.Name = "tlpInfoAll";
            this.tlpInfoAll.RowCount = 3;
            this.tlpInfoAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.103F));
            this.tlpInfoAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.9485F));
            this.tlpInfoAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.73391F));
            this.tlpInfoAll.Size = new System.Drawing.Size(572, 335);
            this.tlpInfoAll.TabIndex = 1;
            this.tlpInfoAll.TagString = null;
            // 
            // tlpInfoUp
            // 
            this.tlpInfoUp.ColumnCount = 3;
            this.tlpInfoAll.SetColumnSpan(this.tlpInfoUp, 6);
            this.tlpInfoUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpInfoUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpInfoUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpInfoUp.Controls.Add(this.lblStation, 0, 0);
            this.tlpInfoUp.Controls.Add(this.pnlHash, 0, 4);
            this.tlpInfoUp.Controls.Add(this.pnlMainSW, 0, 3);
            this.tlpInfoUp.Controls.Add(this.pnlSWVersion, 0, 2);
            this.tlpInfoUp.Controls.Add(this.pnlSite, 0, 1);
            this.tlpInfoUp.Controls.Add(this.pnlVendor, 1, 1);
            this.tlpInfoUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInfoUp.Location = new System.Drawing.Point(6, 0);
            this.tlpInfoUp.Margin = new System.Windows.Forms.Padding(0);
            this.tlpInfoUp.Name = "tlpInfoUp";
            this.tlpInfoUp.RowCount = 5;
            this.tlpInfoUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tlpInfoUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tlpInfoUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tlpInfoUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tlpInfoUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tlpInfoUp.Size = new System.Drawing.Size(566, 242);
            this.tlpInfoUp.TabIndex = 0;
            this.tlpInfoUp.TagString = null;
            // 
            // lblStation
            // 
            this.tlpInfoUp.SetColumnSpan(this.lblStation, 3);
            this.lblStation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStation.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblStation.Location = new System.Drawing.Point(3, 0);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(560, 67);
            this.lblStation.TabIndex = 0;
            this.lblStation.Text = "BTN01 #1";
            this.lblStation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStation.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pnlHash
            // 
            this.tlpInfoUp.SetColumnSpan(this.pnlHash, 3);
            this.pnlHash.Controls.Add(this.lblHashValue);
            this.pnlHash.Controls.Add(this.lblHash);
            this.pnlHash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHash.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlHash.Location = new System.Drawing.Point(0, 196);
            this.pnlHash.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHash.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlHash.Name = "pnlHash";
            this.pnlHash.Size = new System.Drawing.Size(566, 46);
            this.pnlHash.TabIndex = 4;
            this.pnlHash.Text = null;
            this.pnlHash.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlHash.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblHashValue
            // 
            this.lblHashValue.AutoSize = true;
            this.lblHashValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblHashValue.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblHashValue.Location = new System.Drawing.Point(77, 0);
            this.lblHashValue.Margin = new System.Windows.Forms.Padding(1, 0, 3, 0);
            this.lblHashValue.Name = "lblHashValue";
            this.lblHashValue.Size = new System.Drawing.Size(61, 17);
            this.lblHashValue.TabIndex = 1;
            this.lblHashValue.Text = "MS_Hash";
            this.lblHashValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHashValue.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblHash
            // 
            this.lblHash.AutoSize = true;
            this.lblHash.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblHash.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHash.Location = new System.Drawing.Point(0, 0);
            this.lblHash.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblHash.Name = "lblHash";
            this.lblHash.Size = new System.Drawing.Size(77, 19);
            this.lblHash.TabIndex = 1;
            this.lblHash.Text = "MS_Hash:";
            this.lblHash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHash.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pnlMainSW
            // 
            this.tlpInfoUp.SetColumnSpan(this.pnlMainSW, 3);
            this.pnlMainSW.Controls.Add(this.lblMainSWPathValue);
            this.pnlMainSW.Controls.Add(this.lblMainSWPath);
            this.pnlMainSW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainSW.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlMainSW.Location = new System.Drawing.Point(0, 153);
            this.pnlMainSW.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMainSW.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlMainSW.Name = "pnlMainSW";
            this.pnlMainSW.Size = new System.Drawing.Size(566, 43);
            this.pnlMainSW.TabIndex = 5;
            this.pnlMainSW.Text = null;
            this.pnlMainSW.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlMainSW.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblMainSWPathValue
            // 
            this.lblMainSWPathValue.AutoSize = true;
            this.lblMainSWPathValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMainSWPathValue.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Italic);
            this.lblMainSWPathValue.Location = new System.Drawing.Point(111, 0);
            this.lblMainSWPathValue.Margin = new System.Windows.Forms.Padding(1, 0, 3, 0);
            this.lblMainSWPathValue.Name = "lblMainSWPathValue";
            this.lblMainSWPathValue.Size = new System.Drawing.Size(89, 17);
            this.lblMainSWPathValue.TabIndex = 1;
            this.lblMainSWPathValue.Text = "Main SW Path";
            this.lblMainSWPathValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMainSWPathValue.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.lblMainSWPathValue.Click += new System.EventHandler(this.lblMainSWPathValue_Click);
            // 
            // lblMainSWPath
            // 
            this.lblMainSWPath.AutoSize = true;
            this.lblMainSWPath.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMainSWPath.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMainSWPath.Location = new System.Drawing.Point(0, 0);
            this.lblMainSWPath.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblMainSWPath.Name = "lblMainSWPath";
            this.lblMainSWPath.Size = new System.Drawing.Size(111, 19);
            this.lblMainSWPath.TabIndex = 1;
            this.lblMainSWPath.Text = "Main SW Path:";
            this.lblMainSWPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMainSWPath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pnlSWVersion
            // 
            this.tlpInfoUp.SetColumnSpan(this.pnlSWVersion, 3);
            this.pnlSWVersion.Controls.Add(this.lblSWVersionValue);
            this.pnlSWVersion.Controls.Add(this.lblSWVersion);
            this.pnlSWVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSWVersion.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlSWVersion.Location = new System.Drawing.Point(0, 110);
            this.pnlSWVersion.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSWVersion.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlSWVersion.Name = "pnlSWVersion";
            this.pnlSWVersion.Size = new System.Drawing.Size(566, 43);
            this.pnlSWVersion.TabIndex = 6;
            this.pnlSWVersion.Text = null;
            this.pnlSWVersion.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlSWVersion.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblSWVersionValue
            // 
            this.lblSWVersionValue.AutoSize = true;
            this.lblSWVersionValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSWVersionValue.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSWVersionValue.Location = new System.Drawing.Point(93, 0);
            this.lblSWVersionValue.Margin = new System.Windows.Forms.Padding(1, 0, 3, 0);
            this.lblSWVersionValue.Name = "lblSWVersionValue";
            this.lblSWVersionValue.Size = new System.Drawing.Size(85, 20);
            this.lblSWVersionValue.TabIndex = 1;
            this.lblSWVersionValue.Text = "SW Version";
            this.lblSWVersionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSWVersionValue.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblSWVersion
            // 
            this.lblSWVersion.AutoSize = true;
            this.lblSWVersion.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSWVersion.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSWVersion.Location = new System.Drawing.Point(0, 0);
            this.lblSWVersion.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblSWVersion.Name = "lblSWVersion";
            this.lblSWVersion.Size = new System.Drawing.Size(93, 19);
            this.lblSWVersion.TabIndex = 1;
            this.lblSWVersion.Text = "SW Version:";
            this.lblSWVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSWVersion.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pnlSite
            // 
            this.pnlSite.Controls.Add(this.lblSiteValue);
            this.pnlSite.Controls.Add(this.lblSite);
            this.pnlSite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSite.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlSite.Location = new System.Drawing.Point(0, 67);
            this.pnlSite.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSite.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlSite.Name = "pnlSite";
            this.pnlSite.Size = new System.Drawing.Size(226, 43);
            this.pnlSite.TabIndex = 7;
            this.pnlSite.Text = null;
            this.pnlSite.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlSite.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblSiteValue
            // 
            this.lblSiteValue.AutoSize = true;
            this.lblSiteValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSiteValue.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSiteValue.Location = new System.Drawing.Point(49, 0);
            this.lblSiteValue.Name = "lblSiteValue";
            this.lblSiteValue.Size = new System.Drawing.Size(34, 20);
            this.lblSiteValue.TabIndex = 3;
            this.lblSiteValue.Text = "Site";
            this.lblSiteValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSiteValue.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSite.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSite.Location = new System.Drawing.Point(0, 0);
            this.lblSite.Margin = new System.Windows.Forms.Padding(1, 0, 3, 0);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(49, 19);
            this.lblSite.TabIndex = 3;
            this.lblSite.Text = "Site：";
            this.lblSite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSite.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pnlVendor
            // 
            this.pnlVendor.Controls.Add(this.lblVendorValue);
            this.pnlVendor.Controls.Add(this.lblVendor);
            this.pnlVendor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVendor.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlVendor.Location = new System.Drawing.Point(226, 67);
            this.pnlVendor.Margin = new System.Windows.Forms.Padding(0);
            this.pnlVendor.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlVendor.Name = "pnlVendor";
            this.pnlVendor.Size = new System.Drawing.Size(226, 43);
            this.pnlVendor.TabIndex = 8;
            this.pnlVendor.Text = null;
            this.pnlVendor.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlVendor.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblVendorValue
            // 
            this.lblVendorValue.AutoSize = true;
            this.lblVendorValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblVendorValue.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVendorValue.Location = new System.Drawing.Point(74, 0);
            this.lblVendorValue.Name = "lblVendorValue";
            this.lblVendorValue.Size = new System.Drawing.Size(45, 20);
            this.lblVendorValue.TabIndex = 3;
            this.lblVendorValue.Text = "LEAD";
            this.lblVendorValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVendorValue.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblVendor.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVendor.Location = new System.Drawing.Point(0, 0);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(74, 19);
            this.lblVendor.TabIndex = 3;
            this.lblVendor.Text = "Vendor：";
            this.lblVendor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVendor.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblHiveState
            // 
            this.tlpInfoAll.SetColumnSpan(this.lblHiveState, 2);
            this.lblHiveState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHiveState.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.lblHiveState.Location = new System.Drawing.Point(9, 242);
            this.lblHiveState.Name = "lblHiveState";
            this.lblHiveState.Size = new System.Drawing.Size(182, 46);
            this.lblHiveState.TabIndex = 1;
            this.lblHiveState.Text = "HIVE_DISCONNECT";
            this.lblHiveState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHiveState.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblMesState
            // 
            this.tlpInfoAll.SetColumnSpan(this.lblMesState, 2);
            this.lblMesState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMesState.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.lblMesState.Location = new System.Drawing.Point(197, 242);
            this.lblMesState.Name = "lblMesState";
            this.lblMesState.Size = new System.Drawing.Size(182, 46);
            this.lblMesState.TabIndex = 1;
            this.lblMesState.Text = "MES_DISCONNECT";
            this.lblMesState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMesState.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblPDCAState
            // 
            this.tlpInfoAll.SetColumnSpan(this.lblPDCAState, 2);
            this.lblPDCAState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPDCAState.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.lblPDCAState.Location = new System.Drawing.Point(385, 242);
            this.lblPDCAState.Name = "lblPDCAState";
            this.lblPDCAState.Size = new System.Drawing.Size(184, 46);
            this.lblPDCAState.TabIndex = 1;
            this.lblPDCAState.Text = "PDCA_DISCONNECT";
            this.lblPDCAState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPDCAState.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnMachineLog
            // 
            this.tlpInfoAll.SetColumnSpan(this.btnMachineLog, 3);
            this.btnMachineLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMachineLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMachineLog.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMachineLog.Location = new System.Drawing.Point(26, 290);
            this.btnMachineLog.Margin = new System.Windows.Forms.Padding(20, 2, 30, 2);
            this.btnMachineLog.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnMachineLog.Name = "btnMachineLog";
            this.btnMachineLog.Radius = 1;
            this.btnMachineLog.Size = new System.Drawing.Size(232, 43);
            this.btnMachineLog.TabIndex = 2;
            this.btnMachineLog.Text = "Machine Log";
            this.btnMachineLog.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMachineLog.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnMachineLog.Click += new System.EventHandler(this.btnMachineLog_Click);
            // 
            // btnHiveLog
            // 
            this.tlpInfoAll.SetColumnSpan(this.btnHiveLog, 3);
            this.btnHiveLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHiveLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHiveLog.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnHiveLog.Location = new System.Drawing.Point(308, 290);
            this.btnHiveLog.Margin = new System.Windows.Forms.Padding(20, 2, 30, 2);
            this.btnHiveLog.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnHiveLog.Name = "btnHiveLog";
            this.btnHiveLog.Radius = 1;
            this.btnHiveLog.Size = new System.Drawing.Size(234, 43);
            this.btnHiveLog.TabIndex = 2;
            this.btnHiveLog.Text = "HIVE Log";
            this.btnHiveLog.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHiveLog.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnHiveLog.Click += new System.EventHandler(this.btnHiveLog_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tlpInfoAll);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlMain.Location = new System.Drawing.Point(5, 5);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(5);
            this.pnlMain.Radius = 20;
            this.pnlMain.Size = new System.Drawing.Size(582, 345);
            this.pnlMain.TabIndex = 2;
            this.pnlMain.Text = null;
            this.pnlMain.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlMain.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // SoftWareInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(592, 355);
            this.Controls.Add(this.pnlMain);
            this.Name = "SoftWareInfo";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "SoftWareInfo";
            this.tlpInfoAll.ResumeLayout(false);
            this.tlpInfoUp.ResumeLayout(false);
            this.pnlHash.ResumeLayout(false);
            this.pnlHash.PerformLayout();
            this.pnlMainSW.ResumeLayout(false);
            this.pnlMainSW.PerformLayout();
            this.pnlSWVersion.ResumeLayout(false);
            this.pnlSWVersion.PerformLayout();
            this.pnlSite.ResumeLayout(false);
            this.pnlSite.PerformLayout();
            this.pnlVendor.ResumeLayout(false);
            this.pnlVendor.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private UITableLayoutPanel tlpInfoAll;
        private UITableLayoutPanel tlpInfoUp;
        private UILabel lblStation;
        private UILabel lblMainSWPath;
        private UILabel lblHash;
        private UILabel lblHiveState;
        private UIButton btnMachineLog;
        private UIButton btnHiveLog;
        private UIPanel pnlMain;
        private UILabel lblSite;
        private UILabel lblVendor;
        private UIPanel pnlHash;
        private UILabel lblHashValue;
        private UIPanel pnlMainSW;
        private UILabel lblMainSWPathValue;
        private UIPanel pnlSWVersion;
        private UILabel lblSWVersionValue;
        private UILabel lblSWVersion;
        private UIPanel pnlSite;
        private UILabel lblSiteValue;
        private UIPanel pnlVendor;
        private UILabel lblVendorValue;
        private UILabel lblPDCAState;
        private UILabel lblMesState;
    }
}