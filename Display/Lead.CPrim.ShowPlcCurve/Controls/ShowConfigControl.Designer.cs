using Lead.CPrim.ProxyTools.SunnyUI.Controls;

namespace Lead.CPrim.ShowPlcCurve.Controls
{
    partial class ShowConfigControl
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
            this.btnApply = new System.Windows.Forms.Button();
            this.txtPlcPath = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.btnSavePath = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISymbolButton();
            this.txtPlcPath2 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.btnSavePath2 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISymbolButton();
            this.tlpTitle = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.txtName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.cbChartNum = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.chkSourceDataSave = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UICheckBox();
            this.chkXMin = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UICheckBox();
            this.txtXMin = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.txtXMax = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.chkXMax = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UICheckBox();
            this.txtYMin = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.chkYMin = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UICheckBox();
            this.txtYMax = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.chkYMax = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UICheckBox();
            this.lblCurveQuantity = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblPosition1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblPosition2 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.txtSourceData = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.btnSourceData = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISymbolButton();
            this.txtXInterval = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.lblXInterval = new System.Windows.Forms.Label();
            this.chkPathAddDate = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UICheckBox();
            this.uiLabel1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblXFormat = new System.Windows.Forms.Label();
            this.txtXFormat = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.tlpTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnApply.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(0, 456);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(800, 44);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtPlcPath
            // 
            this.txtPlcPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPlcPath.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtPlcPath.Location = new System.Drawing.Point(150, 256);
            this.txtPlcPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPlcPath.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtPlcPath.Name = "txtPlcPath";
            this.txtPlcPath.ShowText = false;
            this.txtPlcPath.Size = new System.Drawing.Size(435, 29);
            this.txtPlcPath.TabIndex = 16;
            this.txtPlcPath.Watermark = "PLC曲线保存位置1";
            this.txtPlcPath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnSavePath
            // 
            this.btnSavePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSavePath.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSavePath.Location = new System.Drawing.Point(591, 255);
            this.btnSavePath.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(38, 30);
            this.btnSavePath.Symbol = 61761;
            this.btnSavePath.TabIndex = 17;
            this.btnSavePath.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSavePath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // txtPlcPath2
            // 
            this.txtPlcPath2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPlcPath2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtPlcPath2.Location = new System.Drawing.Point(150, 296);
            this.txtPlcPath2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPlcPath2.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtPlcPath2.Name = "txtPlcPath2";
            this.txtPlcPath2.ShowText = false;
            this.txtPlcPath2.Size = new System.Drawing.Size(435, 29);
            this.txtPlcPath2.TabIndex = 16;
            this.txtPlcPath2.Watermark = "PLC曲线保存位置2";
            this.txtPlcPath2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnSavePath2
            // 
            this.btnSavePath2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSavePath2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSavePath2.Location = new System.Drawing.Point(591, 295);
            this.btnSavePath2.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSavePath2.Name = "btnSavePath2";
            this.btnSavePath2.Size = new System.Drawing.Size(38, 30);
            this.btnSavePath2.Symbol = 61761;
            this.btnSavePath2.TabIndex = 17;
            this.btnSavePath2.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSavePath2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSavePath2.Click += new System.EventHandler(this.btnSavePath2_Click);
            // 
            // tlpTitle
            // 
            this.tlpTitle.ColumnCount = 2;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Controls.Add(this.txtName, 1, 0);
            this.tlpTitle.Controls.Add(this.label1, 0, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tlpTitle.Location = new System.Drawing.Point(0, 0);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Size = new System.Drawing.Size(800, 44);
            this.tlpTitle.TabIndex = 260;
            this.tlpTitle.TagString = null;
            // 
            // txtName
            // 
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtName.Location = new System.Drawing.Point(202, 2);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtName.Name = "txtName";
            this.txtName.ShowText = false;
            this.txtName.Size = new System.Drawing.Size(596, 40);
            this.txtName.TabIndex = 135;
            this.txtName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SkyBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 40);
            this.label1.TabIndex = 12;
            this.label1.Text = "PlcCurve Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblVersion.Location = new System.Drawing.Point(670, 60);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(107, 20);
            this.lblVersion.TabIndex = 261;
            this.lblVersion.Text = "V1.0_20230418";
            this.lblVersion.DoubleClick += new System.EventHandler(this.lblVersion_DoubleClick);
            // 
            // cbChartNum
            // 
            this.cbChartNum.DataSource = null;
            this.cbChartNum.FillColor = System.Drawing.Color.White;
            this.cbChartNum.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cbChartNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cbChartNum.Location = new System.Drawing.Point(10, 90);
            this.cbChartNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbChartNum.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbChartNum.Name = "cbChartNum";
            this.cbChartNum.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbChartNum.Size = new System.Drawing.Size(150, 29);
            this.cbChartNum.TabIndex = 262;
            this.cbChartNum.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // chkSourceDataSave
            // 
            this.chkSourceDataSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkSourceDataSave.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.chkSourceDataSave.Location = new System.Drawing.Point(10, 340);
            this.chkSourceDataSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.chkSourceDataSave.Name = "chkSourceDataSave";
            this.chkSourceDataSave.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.chkSourceDataSave.Size = new System.Drawing.Size(129, 21);
            this.chkSourceDataSave.TabIndex = 263;
            this.chkSourceDataSave.Text = "SourceDataSave";
            this.chkSourceDataSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // chkXMin
            // 
            this.chkXMin.BackColor = System.Drawing.Color.Transparent;
            this.chkXMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkXMin.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.chkXMin.Location = new System.Drawing.Point(10, 140);
            this.chkXMin.MinimumSize = new System.Drawing.Size(1, 1);
            this.chkXMin.Name = "chkXMin";
            this.chkXMin.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.chkXMin.Size = new System.Drawing.Size(57, 21);
            this.chkXMin.TabIndex = 263;
            this.chkXMin.Text = "XMin";
            this.chkXMin.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtXMin
            // 
            this.txtXMin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtXMin.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtXMin.Location = new System.Drawing.Point(100, 136);
            this.txtXMin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtXMin.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtXMin.Name = "txtXMin";
            this.txtXMin.ShowText = false;
            this.txtXMin.Size = new System.Drawing.Size(150, 29);
            this.txtXMin.TabIndex = 16;
            this.txtXMin.Watermark = "XMin";
            this.txtXMin.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtXMax
            // 
            this.txtXMax.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtXMax.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtXMax.Location = new System.Drawing.Point(100, 176);
            this.txtXMax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtXMax.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtXMax.Name = "txtXMax";
            this.txtXMax.ShowText = false;
            this.txtXMax.Size = new System.Drawing.Size(150, 29);
            this.txtXMax.TabIndex = 16;
            this.txtXMax.Watermark = "XMax";
            this.txtXMax.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // chkXMax
            // 
            this.chkXMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkXMax.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.chkXMax.Location = new System.Drawing.Point(10, 180);
            this.chkXMax.MinimumSize = new System.Drawing.Size(1, 1);
            this.chkXMax.Name = "chkXMax";
            this.chkXMax.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.chkXMax.Size = new System.Drawing.Size(60, 21);
            this.chkXMax.TabIndex = 263;
            this.chkXMax.Text = "XMax";
            this.chkXMax.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtYMin
            // 
            this.txtYMin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtYMin.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtYMin.Location = new System.Drawing.Point(390, 136);
            this.txtYMin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtYMin.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtYMin.Name = "txtYMin";
            this.txtYMin.ShowText = false;
            this.txtYMin.Size = new System.Drawing.Size(150, 29);
            this.txtYMin.TabIndex = 16;
            this.txtYMin.Watermark = "YMin";
            this.txtYMin.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // chkYMin
            // 
            this.chkYMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkYMin.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.chkYMin.Location = new System.Drawing.Point(300, 140);
            this.chkYMin.MinimumSize = new System.Drawing.Size(1, 1);
            this.chkYMin.Name = "chkYMin";
            this.chkYMin.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.chkYMin.Size = new System.Drawing.Size(57, 21);
            this.chkYMin.TabIndex = 263;
            this.chkYMin.Text = "YMin";
            this.chkYMin.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtYMax
            // 
            this.txtYMax.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtYMax.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtYMax.Location = new System.Drawing.Point(390, 176);
            this.txtYMax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtYMax.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtYMax.Name = "txtYMax";
            this.txtYMax.ShowText = false;
            this.txtYMax.Size = new System.Drawing.Size(150, 29);
            this.txtYMax.TabIndex = 16;
            this.txtYMax.Watermark = "YMax";
            this.txtYMax.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // chkYMax
            // 
            this.chkYMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkYMax.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.chkYMax.Location = new System.Drawing.Point(300, 180);
            this.chkYMax.MinimumSize = new System.Drawing.Size(1, 1);
            this.chkYMax.Name = "chkYMax";
            this.chkYMax.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.chkYMax.Size = new System.Drawing.Size(59, 21);
            this.chkYMax.TabIndex = 263;
            this.chkYMax.Text = "YMax";
            this.chkYMax.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblCurveQuantity
            // 
            this.lblCurveQuantity.AutoSize = true;
            this.lblCurveQuantity.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblCurveQuantity.Location = new System.Drawing.Point(10, 60);
            this.lblCurveQuantity.Name = "lblCurveQuantity";
            this.lblCurveQuantity.Size = new System.Drawing.Size(109, 20);
            this.lblCurveQuantity.TabIndex = 264;
            this.lblCurveQuantity.Text = "Curve Quantity";
            this.lblCurveQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCurveQuantity.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblPosition1
            // 
            this.lblPosition1.AutoSize = true;
            this.lblPosition1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblPosition1.Location = new System.Drawing.Point(10, 260);
            this.lblPosition1.Name = "lblPosition1";
            this.lblPosition1.Size = new System.Drawing.Size(72, 20);
            this.lblPosition1.TabIndex = 264;
            this.lblPosition1.Text = "Position1";
            this.lblPosition1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPosition1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblPosition2
            // 
            this.lblPosition2.AutoSize = true;
            this.lblPosition2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblPosition2.Location = new System.Drawing.Point(10, 300);
            this.lblPosition2.Name = "lblPosition2";
            this.lblPosition2.Size = new System.Drawing.Size(72, 20);
            this.lblPosition2.TabIndex = 264;
            this.lblPosition2.Text = "Position2";
            this.lblPosition2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPosition2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtSourceData
            // 
            this.txtSourceData.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSourceData.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSourceData.Location = new System.Drawing.Point(150, 336);
            this.txtSourceData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSourceData.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtSourceData.Name = "txtSourceData";
            this.txtSourceData.ShowText = false;
            this.txtSourceData.Size = new System.Drawing.Size(435, 29);
            this.txtSourceData.TabIndex = 16;
            this.txtSourceData.Watermark = "源数据保存位置";
            this.txtSourceData.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnSourceData
            // 
            this.btnSourceData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSourceData.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSourceData.Location = new System.Drawing.Point(591, 335);
            this.btnSourceData.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSourceData.Name = "btnSourceData";
            this.btnSourceData.Size = new System.Drawing.Size(38, 30);
            this.btnSourceData.Symbol = 61761;
            this.btnSourceData.TabIndex = 17;
            this.btnSourceData.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSourceData.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSourceData.Click += new System.EventHandler(this.btnSourceData_Click);
            // 
            // txtXInterval
            // 
            this.txtXInterval.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtXInterval.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtXInterval.Location = new System.Drawing.Point(180, 90);
            this.txtXInterval.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtXInterval.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtXInterval.Name = "txtXInterval";
            this.txtXInterval.ShowText = false;
            this.txtXInterval.Size = new System.Drawing.Size(150, 29);
            this.txtXInterval.TabIndex = 266;
            this.txtXInterval.Watermark = "单位：s";
            this.txtXInterval.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblXInterval
            // 
            this.lblXInterval.AutoSize = true;
            this.lblXInterval.BackColor = System.Drawing.Color.Transparent;
            this.lblXInterval.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblXInterval.Location = new System.Drawing.Point(180, 60);
            this.lblXInterval.Name = "lblXInterval";
            this.lblXInterval.Size = new System.Drawing.Size(68, 20);
            this.lblXInterval.TabIndex = 265;
            this.lblXInterval.Text = "XInterval";
            // 
            // chkPathAddDate
            // 
            this.chkPathAddDate.BackColor = System.Drawing.Color.Transparent;
            this.chkPathAddDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkPathAddDate.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.chkPathAddDate.Location = new System.Drawing.Point(10, 220);
            this.chkPathAddDate.MinimumSize = new System.Drawing.Size(1, 1);
            this.chkPathAddDate.Name = "chkPathAddDate";
            this.chkPathAddDate.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.chkPathAddDate.Size = new System.Drawing.Size(127, 25);
            this.chkPathAddDate.TabIndex = 267;
            this.chkPathAddDate.Text = "PathAddDate";
            this.chkPathAddDate.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.uiLabel1.Location = new System.Drawing.Point(535, 96);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(196, 16);
            this.uiLabel1.TabIndex = 264;
            this.uiLabel1.Text = "Applies to time pressure curves only";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblXFormat
            // 
            this.lblXFormat.AutoSize = true;
            this.lblXFormat.BackColor = System.Drawing.Color.Transparent;
            this.lblXFormat.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblXFormat.Location = new System.Drawing.Point(350, 60);
            this.lblXFormat.Name = "lblXFormat";
            this.lblXFormat.Size = new System.Drawing.Size(65, 20);
            this.lblXFormat.TabIndex = 265;
            this.lblXFormat.Text = "XFormat";
            // 
            // txtXFormat
            // 
            this.txtXFormat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtXFormat.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtXFormat.Location = new System.Drawing.Point(350, 90);
            this.txtXFormat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtXFormat.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtXFormat.Name = "txtXFormat";
            this.txtXFormat.ShowText = false;
            this.txtXFormat.Size = new System.Drawing.Size(180, 29);
            this.txtXFormat.TabIndex = 266;
            this.txtXFormat.Watermark = "yyyy-MM-dd HH:mm:ss fff";
            this.txtXFormat.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ShowConfigControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.chkPathAddDate);
            this.Controls.Add(this.txtXFormat);
            this.Controls.Add(this.txtXInterval);
            this.Controls.Add(this.lblXFormat);
            this.Controls.Add(this.lblXInterval);
            this.Controls.Add(this.lblPosition2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.lblPosition1);
            this.Controls.Add(this.lblCurveQuantity);
            this.Controls.Add(this.chkYMax);
            this.Controls.Add(this.chkYMin);
            this.Controls.Add(this.chkXMax);
            this.Controls.Add(this.chkXMin);
            this.Controls.Add(this.chkSourceDataSave);
            this.Controls.Add(this.cbChartNum);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.tlpTitle);
            this.Controls.Add(this.txtYMax);
            this.Controls.Add(this.btnSourceData);
            this.Controls.Add(this.btnSavePath2);
            this.Controls.Add(this.txtYMin);
            this.Controls.Add(this.btnSavePath);
            this.Controls.Add(this.txtXMax);
            this.Controls.Add(this.txtSourceData);
            this.Controls.Add(this.txtPlcPath2);
            this.Controls.Add(this.txtXMin);
            this.Controls.Add(this.txtPlcPath);
            this.Controls.Add(this.btnApply);
            this.Name = "ShowConfigControl";
            this.Size = new System.Drawing.Size(800, 500);
            this.Load += new System.EventHandler(this.ShowConfigControl_Load);
            this.tlpTitle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private UITextBox txtPlcPath;
        private UISymbolButton btnSavePath;
        private UITextBox txtPlcPath2;
        private UISymbolButton btnSavePath2;
        private UITableLayoutPanel tlpTitle;
        private UITextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVersion;
        private UIComboBox cbChartNum;
        private UICheckBox chkSourceDataSave;
        private UICheckBox chkXMin;
        private UITextBox txtXMin;
        private UITextBox txtXMax;
        private UICheckBox chkXMax;
        private UITextBox txtYMin;
        private UICheckBox chkYMin;
        private UITextBox txtYMax;
        private UICheckBox chkYMax;
        private UILabel lblCurveQuantity;
        private UILabel lblPosition1;
        private UILabel lblPosition2;
        private UITextBox txtSourceData;
        private UISymbolButton btnSourceData;
        private UITextBox txtXInterval;
        private System.Windows.Forms.Label lblXInterval;
        private UICheckBox chkPathAddDate;
        private UILabel uiLabel1;
        private System.Windows.Forms.Label lblXFormat;
        private UITextBox txtXFormat;
    }
}
