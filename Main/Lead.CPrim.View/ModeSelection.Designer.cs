namespace Lead.CPrim.View
{
    partial class ModeSelection
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
            this.pnlMain = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnSingle = new System.Windows.Forms.Button();
            this.btnNormal = new System.Windows.Forms.Button();
            this.btnRunWithFixture = new System.Windows.Forms.Button();
            this.btnRunWithoutFixture = new System.Windows.Forms.Button();
            this.btnDynamic = new System.Windows.Forms.Button();
            this.btnAxis = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnDirect = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tlpMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(3);
            this.pnlMain.Size = new System.Drawing.Size(470, 160);
            this.pnlMain.TabIndex = 1;
            this.pnlMain.Text = "uiPanel1";
            this.pnlMain.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlMain.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.Controls.Add(this.btnSingle, 0, 2);
            this.tlpMain.Controls.Add(this.btnNormal, 0, 0);
            this.tlpMain.Controls.Add(this.btnRunWithFixture, 1, 0);
            this.tlpMain.Controls.Add(this.btnRunWithoutFixture, 2, 0);
            this.tlpMain.Controls.Add(this.btnDynamic, 1, 1);
            this.tlpMain.Controls.Add(this.btnAxis, 0, 1);
            this.tlpMain.Controls.Add(this.btnTest, 2, 1);
            this.tlpMain.Controls.Add(this.btnDirect, 1, 2);
            this.tlpMain.Controls.Add(this.btnCheck, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(3, 3);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(464, 154);
            this.tlpMain.TabIndex = 0;
            // 
            // btnSingle
            // 
            this.btnSingle.BackColor = System.Drawing.Color.Silver;
            this.btnSingle.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSingle.Location = new System.Drawing.Point(159, 107);
            this.btnSingle.Margin = new System.Windows.Forms.Padding(5);
            this.btnSingle.Name = "btnSingle";
            this.btnSingle.Size = new System.Drawing.Size(144, 40);
            this.btnSingle.TabIndex = 3;
            this.btnSingle.Tag = "7";
            this.btnSingle.Text = "单流程模式";
            this.btnSingle.UseVisualStyleBackColor = false;
            this.btnSingle.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.BackColor = System.Drawing.Color.Silver;
            this.btnNormal.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnNormal.Location = new System.Drawing.Point(5, 5);
            this.btnNormal.Margin = new System.Windows.Forms.Padding(5);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(144, 40);
            this.btnNormal.TabIndex = 0;
            this.btnNormal.Tag = "0";
            this.btnNormal.Text = "正常生产";
            this.btnNormal.UseVisualStyleBackColor = false;
            this.btnNormal.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnRunWithFixture
            // 
            this.btnRunWithFixture.BackColor = System.Drawing.Color.Silver;
            this.btnRunWithFixture.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnRunWithFixture.Location = new System.Drawing.Point(159, 5);
            this.btnRunWithFixture.Margin = new System.Windows.Forms.Padding(5);
            this.btnRunWithFixture.Name = "btnRunWithFixture";
            this.btnRunWithFixture.Size = new System.Drawing.Size(144, 40);
            this.btnRunWithFixture.TabIndex = 1;
            this.btnRunWithFixture.Tag = "1";
            this.btnRunWithFixture.Text = "空运行模式带载具";
            this.btnRunWithFixture.UseVisualStyleBackColor = false;
            this.btnRunWithFixture.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnRunWithoutFixture
            // 
            this.btnRunWithoutFixture.BackColor = System.Drawing.Color.Silver;
            this.btnRunWithoutFixture.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnRunWithoutFixture.Location = new System.Drawing.Point(313, 5);
            this.btnRunWithoutFixture.Margin = new System.Windows.Forms.Padding(5);
            this.btnRunWithoutFixture.Name = "btnRunWithoutFixture";
            this.btnRunWithoutFixture.Size = new System.Drawing.Size(146, 40);
            this.btnRunWithoutFixture.TabIndex = 0;
            this.btnRunWithoutFixture.Tag = "2";
            this.btnRunWithoutFixture.Text = "空运行模式不带载具";
            this.btnRunWithoutFixture.UseVisualStyleBackColor = false;
            this.btnRunWithoutFixture.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnDynamic
            // 
            this.btnDynamic.BackColor = System.Drawing.Color.Silver;
            this.btnDynamic.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnDynamic.Location = new System.Drawing.Point(159, 56);
            this.btnDynamic.Margin = new System.Windows.Forms.Padding(5);
            this.btnDynamic.Name = "btnDynamic";
            this.btnDynamic.Size = new System.Drawing.Size(144, 40);
            this.btnDynamic.TabIndex = 2;
            this.btnDynamic.Tag = "5";
            this.btnDynamic.Text = "CCD动静态模式";
            this.btnDynamic.UseVisualStyleBackColor = false;
            this.btnDynamic.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnAxis
            // 
            this.btnAxis.BackColor = System.Drawing.Color.Silver;
            this.btnAxis.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnAxis.Location = new System.Drawing.Point(5, 56);
            this.btnAxis.Margin = new System.Windows.Forms.Padding(5);
            this.btnAxis.Name = "btnAxis";
            this.btnAxis.Size = new System.Drawing.Size(144, 40);
            this.btnAxis.TabIndex = 2;
            this.btnAxis.Tag = "4";
            this.btnAxis.Text = "轴精度模式";
            this.btnAxis.UseVisualStyleBackColor = false;
            this.btnAxis.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.Silver;
            this.btnTest.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnTest.Location = new System.Drawing.Point(313, 56);
            this.btnTest.Margin = new System.Windows.Forms.Padding(5);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(146, 40);
            this.btnTest.TabIndex = 2;
            this.btnTest.Tag = "6";
            this.btnTest.Text = "标定模式";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnDirect
            // 
            this.btnDirect.BackColor = System.Drawing.Color.Silver;
            this.btnDirect.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnDirect.Location = new System.Drawing.Point(313, 107);
            this.btnDirect.Margin = new System.Windows.Forms.Padding(5);
            this.btnDirect.Name = "btnDirect";
            this.btnDirect.Size = new System.Drawing.Size(146, 40);
            this.btnDirect.TabIndex = 2;
            this.btnDirect.Tag = "8";
            this.btnDirect.Text = "直通模式";
            this.btnDirect.UseVisualStyleBackColor = false;
            this.btnDirect.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.Silver;
            this.btnCheck.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCheck.Location = new System.Drawing.Point(5, 107);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(5);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(144, 40);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Tag = "3";
            this.btnCheck.Text = "点检模式";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btn_Click);
            // 
            // ModeSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(470, 160);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(470, 160);
            this.Name = "ModeSelection";
            this.Text = "ModeSelection";
            this.Load += new System.EventHandler(this.ModeSelection_Load);
            this.pnlMain.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Button btnRunWithFixture;
        private System.Windows.Forms.Button btnRunWithoutFixture;
        private System.Windows.Forms.Button btnCheck;
        private ProxyTools.SunnyUI.Controls.UIPanel pnlMain;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnDirect;
        private System.Windows.Forms.Button btnDynamic;
        private System.Windows.Forms.Button btnAxis;
        private System.Windows.Forms.Button btnSingle;
    }
}