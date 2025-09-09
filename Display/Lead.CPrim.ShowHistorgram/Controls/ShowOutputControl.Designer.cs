namespace Lead.CPrim.ShowHistorgram.Controls
{
    partial class ShowOutputControl
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
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSaveBigPicture = new System.Windows.Forms.Button();
            this.btnDataImport = new System.Windows.Forms.Button();
            this.btnTemplateExport = new System.Windows.Forms.Button();
            this.btnSaveSmallPicture = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnClr = new System.Windows.Forms.Button();
            this.cbSort = new System.Windows.Forms.ComboBox();
            this.tlpMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.flpMain, 0, 1);
            this.tlpMain.Controls.Add(this.panel1, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1000, 500);
            this.tlpMain.TabIndex = 0;
            // 
            // flpMain
            // 
            this.flpMain.AutoScroll = true;
            this.flpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMain.Location = new System.Drawing.Point(3, 38);
            this.flpMain.Name = "flpMain";
            this.flpMain.Size = new System.Drawing.Size(994, 459);
            this.flpMain.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.btnSaveBigPicture);
            this.panel1.Controls.Add(this.btnDataImport);
            this.panel1.Controls.Add(this.btnTemplateExport);
            this.panel1.Controls.Add(this.btnSaveSmallPicture);
            this.panel1.Controls.Add(this.btnTest);
            this.panel1.Controls.Add(this.btnClr);
            this.panel1.Controls.Add(this.cbSort);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 29);
            this.panel1.TabIndex = 1;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(420, 1);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(74, 27);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "打开图片";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSaveBigPicture
            // 
            this.btnSaveBigPicture.Location = new System.Drawing.Point(340, 1);
            this.btnSaveBigPicture.Name = "btnSaveBigPicture";
            this.btnSaveBigPicture.Size = new System.Drawing.Size(74, 27);
            this.btnSaveBigPicture.TabIndex = 5;
            this.btnSaveBigPicture.Text = "保存大图";
            this.btnSaveBigPicture.UseVisualStyleBackColor = true;
            this.btnSaveBigPicture.Click += new System.EventHandler(this.btnSaveBigPicture_Click);
            // 
            // btnDataImport
            // 
            this.btnDataImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDataImport.Location = new System.Drawing.Point(836, 1);
            this.btnDataImport.Name = "btnDataImport";
            this.btnDataImport.Size = new System.Drawing.Size(74, 27);
            this.btnDataImport.TabIndex = 4;
            this.btnDataImport.Text = "数据导入";
            this.btnDataImport.UseVisualStyleBackColor = true;
            this.btnDataImport.Click += new System.EventHandler(this.btnDataImport_Click);
            // 
            // btnTemplateExport
            // 
            this.btnTemplateExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTemplateExport.Location = new System.Drawing.Point(755, 1);
            this.btnTemplateExport.Name = "btnTemplateExport";
            this.btnTemplateExport.Size = new System.Drawing.Size(74, 27);
            this.btnTemplateExport.TabIndex = 4;
            this.btnTemplateExport.Text = "模板导出";
            this.btnTemplateExport.UseVisualStyleBackColor = true;
            this.btnTemplateExport.Click += new System.EventHandler(this.btnTemplateExport_Click);
            // 
            // btnSaveSmallPicture
            // 
            this.btnSaveSmallPicture.Location = new System.Drawing.Point(260, 2);
            this.btnSaveSmallPicture.Name = "btnSaveSmallPicture";
            this.btnSaveSmallPicture.Size = new System.Drawing.Size(74, 27);
            this.btnSaveSmallPicture.TabIndex = 4;
            this.btnSaveSmallPicture.Text = "保存小图";
            this.btnSaveSmallPicture.UseVisualStyleBackColor = true;
            this.btnSaveSmallPicture.Click += new System.EventHandler(this.btnSaveSmallPicture_Click);
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Location = new System.Drawing.Point(917, 1);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(74, 27);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "随机测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnClr
            // 
            this.btnClr.Location = new System.Drawing.Point(0, 1);
            this.btnClr.Name = "btnClr";
            this.btnClr.Size = new System.Drawing.Size(74, 27);
            this.btnClr.TabIndex = 2;
            this.btnClr.Text = "Clear";
            this.btnClr.UseVisualStyleBackColor = true;
            this.btnClr.Click += new System.EventHandler(this.BtnClr_Click);
            // 
            // cbSort
            // 
            this.cbSort.FormattingEnabled = true;
            this.cbSort.Location = new System.Drawing.Point(108, 3);
            this.cbSort.Name = "cbSort";
            this.cbSort.Size = new System.Drawing.Size(121, 25);
            this.cbSort.TabIndex = 1;
            this.cbSort.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // ShowOutputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ShowOutputControl";
            this.Size = new System.Drawing.Size(1000, 500);
            this.tlpMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbSort;
        private System.Windows.Forms.Button btnClr;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnSaveSmallPicture;
        private System.Windows.Forms.Button btnSaveBigPicture;
        private System.Windows.Forms.Button btnDataImport;
        private System.Windows.Forms.Button btnTemplateExport;
        private System.Windows.Forms.Button btnOpen;
    }
}
