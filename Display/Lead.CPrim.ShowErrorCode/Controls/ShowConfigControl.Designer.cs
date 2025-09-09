using Lead.CPrim.ProxyTools.SunnyUI.Controls;

namespace Lead.CPrim.ShowErrorCode.Controls
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnApply = new System.Windows.Forms.Button();
            this.uiLabel1 = new UILabel();
            this.uitbStationCode = new UITextBox();
            this.uiLabel2 = new UILabel();
            this.uitbModuleCode = new UITextBox();
            this.uiLabel3 = new UILabel();
            this.uiLabel4 = new UILabel();
            this.uitbModuleNameEn = new UITextBox();
            this.uitbModuleNameCn = new UITextBox();
            this.uiLabel5 = new UILabel();
            this.dgvErrorCodeInput = new System.Windows.Forms.DataGridView();
            this.btnInsertTest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorCodeInput)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(628, 454);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(179, 34);
            this.btnApply.TabIndex = 128;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(42, 68);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(160, 33);
            this.uiLabel1.TabIndex = 129;
            this.uiLabel1.Text = "StationCode：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uitbStationCode
            // 
            this.uitbStationCode.ButtonSymbol = 61761;
            this.uitbStationCode.ButtonWidth = 100;
            this.uitbStationCode.CanEmpty = true;
            this.uitbStationCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uitbStationCode.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uitbStationCode.Location = new System.Drawing.Point(48, 102);
            this.uitbStationCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uitbStationCode.MinimumSize = new System.Drawing.Size(1, 1);
            this.uitbStationCode.Name = "uitbStationCode";
            this.uitbStationCode.Padding = new System.Windows.Forms.Padding(5);
            this.uitbStationCode.ShowText = false;
            this.uitbStationCode.Size = new System.Drawing.Size(186, 29);
            this.uitbStationCode.TabIndex = 130;
            this.uitbStationCode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uitbStationCode.Watermark = "工站编号";
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(42, 143);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(160, 33);
            this.uiLabel2.TabIndex = 129;
            this.uiLabel2.Text = "ModuleCode：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uitbModuleCode
            // 
            this.uitbModuleCode.ButtonSymbol = 61761;
            this.uitbModuleCode.ButtonWidth = 100;
            this.uitbModuleCode.CanEmpty = true;
            this.uitbModuleCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uitbModuleCode.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uitbModuleCode.Location = new System.Drawing.Point(48, 177);
            this.uitbModuleCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uitbModuleCode.MinimumSize = new System.Drawing.Size(1, 1);
            this.uitbModuleCode.Name = "uitbModuleCode";
            this.uitbModuleCode.Padding = new System.Windows.Forms.Padding(5);
            this.uitbModuleCode.ShowText = false;
            this.uitbModuleCode.Size = new System.Drawing.Size(186, 29);
            this.uitbModuleCode.TabIndex = 130;
            this.uitbModuleCode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uitbModuleCode.Watermark = "模组编号";
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(42, 293);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(160, 33);
            this.uiLabel3.TabIndex = 129;
            this.uiLabel3.Text = "ModuleNameEn：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(42, 218);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(160, 33);
            this.uiLabel4.TabIndex = 129;
            this.uiLabel4.Text = "ModuleNameCn：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uitbModuleNameEn
            // 
            this.uitbModuleNameEn.ButtonSymbol = 61761;
            this.uitbModuleNameEn.ButtonWidth = 100;
            this.uitbModuleNameEn.CanEmpty = true;
            this.uitbModuleNameEn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uitbModuleNameEn.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uitbModuleNameEn.Location = new System.Drawing.Point(48, 327);
            this.uitbModuleNameEn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uitbModuleNameEn.MinimumSize = new System.Drawing.Size(1, 1);
            this.uitbModuleNameEn.Name = "uitbModuleNameEn";
            this.uitbModuleNameEn.Padding = new System.Windows.Forms.Padding(5);
            this.uitbModuleNameEn.ShowText = false;
            this.uitbModuleNameEn.Size = new System.Drawing.Size(186, 29);
            this.uitbModuleNameEn.TabIndex = 130;
            this.uitbModuleNameEn.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uitbModuleNameEn.Watermark = "英文模组名称";
            // 
            // uitbModuleNameCn
            // 
            this.uitbModuleNameCn.ButtonSymbol = 61761;
            this.uitbModuleNameCn.ButtonWidth = 100;
            this.uitbModuleNameCn.CanEmpty = true;
            this.uitbModuleNameCn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uitbModuleNameCn.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uitbModuleNameCn.Location = new System.Drawing.Point(48, 252);
            this.uitbModuleNameCn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uitbModuleNameCn.MinimumSize = new System.Drawing.Size(1, 1);
            this.uitbModuleNameCn.Name = "uitbModuleNameCn";
            this.uitbModuleNameCn.Padding = new System.Windows.Forms.Padding(5);
            this.uitbModuleNameCn.ShowText = false;
            this.uitbModuleNameCn.Size = new System.Drawing.Size(186, 29);
            this.uitbModuleNameCn.TabIndex = 130;
            this.uitbModuleNameCn.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uitbModuleNameCn.Watermark = "中文模组名称";
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(42, 380);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(765, 71);
            this.uiLabel5.TabIndex = 129;
            this.uiLabel5.Text = "工站编号：06\r\n模组编号：01-08\r\nS1：S1接驳站/S1 Connecttion；S2：S2上料/S2 Loading；S3：S3缓存站/S3 Buffe" +
    "r；S4：BG_chin/BG_chin；\r\nS5：S5缓存站/S5 Buffer；S6：BG_UAT/BG_UAT；S7：S7夹具维护/S7 Manual；S" +
    "8：下料/S8 UNLoading";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvErrorCodeInput
            // 
            this.dgvErrorCodeInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrorCodeInput.Location = new System.Drawing.Point(275, 68);
            this.dgvErrorCodeInput.Name = "dgvErrorCodeInput";
            this.dgvErrorCodeInput.RowTemplate.Height = 23;
            this.dgvErrorCodeInput.Size = new System.Drawing.Size(532, 288);
            this.dgvErrorCodeInput.TabIndex = 131;
            // 
            // btnInsertTest
            // 
            this.btnInsertTest.BackColor = System.Drawing.Color.LightGreen;
            this.btnInsertTest.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInsertTest.Location = new System.Drawing.Point(401, 454);
            this.btnInsertTest.Name = "btnInsertTest";
            this.btnInsertTest.Size = new System.Drawing.Size(179, 34);
            this.btnInsertTest.TabIndex = 128;
            this.btnInsertTest.Text = "ErrorCode测试";
            this.btnInsertTest.UseVisualStyleBackColor = false;
            this.btnInsertTest.Click += new System.EventHandler(this.btnInsertTest_Click);
            // 
            // ShowConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvErrorCodeInput);
            this.Controls.Add(this.uitbModuleNameCn);
            this.Controls.Add(this.uitbModuleCode);
            this.Controls.Add(this.uitbModuleNameEn);
            this.Controls.Add(this.uitbStationCode);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.btnInsertTest);
            this.Controls.Add(this.btnApply);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ShowConfigControl";
            this.Size = new System.Drawing.Size(896, 516);
            this.Load += new System.EventHandler(this.ShowConfigControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorCodeInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnApply;
        private UILabel uiLabel1;
        private UITextBox uitbStationCode;
        private UILabel uiLabel2;
        private UITextBox uitbModuleCode;
        private UILabel uiLabel3;
        private UILabel uiLabel4;
        private UITextBox uitbModuleNameEn;
        private UITextBox uitbModuleNameCn;
        private UILabel uiLabel5;
        private System.Windows.Forms.DataGridView dgvErrorCodeInput;
        private System.Windows.Forms.Button btnInsertTest;
    }
}