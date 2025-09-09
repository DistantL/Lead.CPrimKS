namespace Lead.CPrim.EleCartesian.EleUIs
{
    partial class DebugUI
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
            this.panelTitle = new System.Windows.Forms.Panel();
            this.btnDebug = new System.Windows.Forms.Button();
            this.tbState = new System.Windows.Forms.TextBox();
            this.lbState = new System.Windows.Forms.Label();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tPageManual = new System.Windows.Forms.TabPage();
            this.flpManual = new System.Windows.Forms.FlowLayoutPanel();
            this.tPagePoints = new System.Windows.Forms.TabPage();
            this.tablePointsManager = new System.Windows.Forms.TableLayoutPanel();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnDataApply = new System.Windows.Forms.Button();
            this.btnDelRow = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.tabPoints = new System.Windows.Forms.TabControl();
            this.tlpMain.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tPageManual.SuspendLayout();
            this.tPagePoints.SuspendLayout();
            this.tablePointsManager.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.panelTitle, 0, 0);
            this.tlpMain.Controls.Add(this.tabMain, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(1392, 596);
            this.tlpMain.TabIndex = 0;
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.btnDebug);
            this.panelTitle.Controls.Add(this.tbState);
            this.panelTitle.Controls.Add(this.lbState);
            this.panelTitle.Controls.Add(this.tbInfo);
            this.panelTitle.Controls.Add(this.lbInfo);
            this.panelTitle.Controls.Add(this.tbName);
            this.panelTitle.Controls.Add(this.lbName);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1392, 25);
            this.panelTitle.TabIndex = 10;
            // 
            // btnDebug
            // 
            this.btnDebug.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDebug.Location = new System.Drawing.Point(1267, 0);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(125, 25);
            this.btnDebug.TabIndex = 8;
            this.btnDebug.Text = "调试";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // tbState
            // 
            this.tbState.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbState.Location = new System.Drawing.Point(498, 0);
            this.tbState.Multiline = true;
            this.tbState.Name = "tbState";
            this.tbState.Size = new System.Drawing.Size(125, 25);
            this.tbState.TabIndex = 7;
            this.tbState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbState
            // 
            this.lbState.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbState.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbState.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbState.Location = new System.Drawing.Point(423, 0);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(75, 25);
            this.lbState.TabIndex = 6;
            this.lbState.Text = "状态";
            this.lbState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbState.DoubleClick += new System.EventHandler(this.lbState_DoubleClick);
            // 
            // tbInfo
            // 
            this.tbInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbInfo.Location = new System.Drawing.Point(298, 0);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(125, 25);
            this.tbInfo.TabIndex = 3;
            this.tbInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbInfo
            // 
            this.lbInfo.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbInfo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbInfo.Location = new System.Drawing.Point(199, 0);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(99, 25);
            this.lbInfo.TabIndex = 2;
            this.lbInfo.Text = "信息";
            this.lbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbName
            // 
            this.tbName.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbName.Location = new System.Drawing.Point(74, 0);
            this.tbName.Multiline = true;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(125, 25);
            this.tbName.TabIndex = 1;
            // 
            // lbName
            // 
            this.lbName.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbName.Location = new System.Drawing.Point(0, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(74, 25);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "名称";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tPageManual);
            this.tabMain.Controls.Add(this.tPagePoints);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 25);
            this.tabMain.Margin = new System.Windows.Forms.Padding(0);
            this.tabMain.Multiline = true;
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Drawing.Point(50, 3);
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1392, 571);
            this.tabMain.TabIndex = 1;
            // 
            // tPageManual
            // 
            this.tPageManual.Controls.Add(this.flpManual);
            this.tPageManual.Location = new System.Drawing.Point(4, 26);
            this.tPageManual.Margin = new System.Windows.Forms.Padding(0);
            this.tPageManual.Name = "tPageManual";
            this.tPageManual.Size = new System.Drawing.Size(1384, 541);
            this.tPageManual.TabIndex = 0;
            this.tPageManual.Text = "手动调试";
            this.tPageManual.UseVisualStyleBackColor = true;
            // 
            // flpManual
            // 
            this.flpManual.AutoScroll = true;
            this.flpManual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpManual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpManual.Location = new System.Drawing.Point(0, 0);
            this.flpManual.Margin = new System.Windows.Forms.Padding(0);
            this.flpManual.Name = "flpManual";
            this.flpManual.Size = new System.Drawing.Size(1384, 541);
            this.flpManual.TabIndex = 1;
            // 
            // tPagePoints
            // 
            this.tPagePoints.Controls.Add(this.tablePointsManager);
            this.tPagePoints.Location = new System.Drawing.Point(4, 26);
            this.tPagePoints.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tPagePoints.Name = "tPagePoints";
            this.tPagePoints.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tPagePoints.Size = new System.Drawing.Size(1384, 541);
            this.tPagePoints.TabIndex = 1;
            this.tPagePoints.Text = "点位管理";
            this.tPagePoints.UseVisualStyleBackColor = true;
            // 
            // tablePointsManager
            // 
            this.tablePointsManager.ColumnCount = 1;
            this.tablePointsManager.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePointsManager.Controls.Add(this.panelButton, 0, 1);
            this.tablePointsManager.Controls.Add(this.tabPoints, 0, 0);
            this.tablePointsManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePointsManager.Location = new System.Drawing.Point(3, 4);
            this.tablePointsManager.Name = "tablePointsManager";
            this.tablePointsManager.RowCount = 2;
            this.tablePointsManager.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tablePointsManager.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablePointsManager.Size = new System.Drawing.Size(1378, 533);
            this.tablePointsManager.TabIndex = 0;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btnDataApply);
            this.panelButton.Controls.Add(this.btnDelRow);
            this.panelButton.Controls.Add(this.btnAddRow);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButton.Location = new System.Drawing.Point(3, 482);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(1372, 48);
            this.panelButton.TabIndex = 161;
            // 
            // btnDataApply
            // 
            this.btnDataApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDataApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnDataApply.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnDataApply.Location = new System.Drawing.Point(1241, 8);
            this.btnDataApply.Name = "btnDataApply";
            this.btnDataApply.Size = new System.Drawing.Size(118, 31);
            this.btnDataApply.TabIndex = 166;
            this.btnDataApply.Text = "应用";
            this.btnDataApply.UseVisualStyleBackColor = false;
            this.btnDataApply.Click += new System.EventHandler(this.btnDataApply_Click);
            // 
            // btnDelRow
            // 
            this.btnDelRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelRow.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnDelRow.Location = new System.Drawing.Point(63, 10);
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(51, 26);
            this.btnDelRow.TabIndex = 164;
            this.btnDelRow.Text = "-";
            this.btnDelRow.UseVisualStyleBackColor = true;
            this.btnDelRow.Click += new System.EventHandler(this.btnDelRow_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddRow.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnAddRow.Location = new System.Drawing.Point(6, 10);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(51, 26);
            this.btnAddRow.TabIndex = 165;
            this.btnAddRow.Text = "+";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // tabPoints
            // 
            this.tabPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPoints.Location = new System.Drawing.Point(0, 0);
            this.tabPoints.Margin = new System.Windows.Forms.Padding(0);
            this.tabPoints.Name = "tabPoints";
            this.tabPoints.SelectedIndex = 0;
            this.tabPoints.Size = new System.Drawing.Size(1378, 479);
            this.tabPoints.TabIndex = 160;
            // 
            // DebugUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DebugUI";
            this.Size = new System.Drawing.Size(1392, 596);
            this.Load += new System.EventHandler(this.DebugUI_Load);
            this.tlpMain.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tPageManual.ResumeLayout(false);
            this.tPagePoints.ResumeLayout(false);
            this.tablePointsManager.ResumeLayout(false);
            this.panelButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tPageManual;
        private System.Windows.Forms.FlowLayoutPanel flpManual;
        private System.Windows.Forms.TabPage tPagePoints;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.TextBox tbState;
        private System.Windows.Forms.Label lbState;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TableLayoutPanel tablePointsManager;
        private System.Windows.Forms.TabControl tabPoints;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button btnDataApply;
        private System.Windows.Forms.Button btnDelRow;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnDebug;
    }
}
