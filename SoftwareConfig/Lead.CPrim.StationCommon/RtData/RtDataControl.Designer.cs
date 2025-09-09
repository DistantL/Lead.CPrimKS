using System.Windows.Forms;

namespace Lead.CPrim.StationCommon.RtData
{
    partial class RtDataControl
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbRtPassRate1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbInValidValueCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRtAverageCt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRtNumTotal = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbRtPassRate = new System.Windows.Forms.TextBox();
            this.tbRtNumNg = new System.Windows.Forms.TextBox();
            this.tbRtNumOk = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.groupBox5.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox5.Controls.Add(this.tbRtPassRate1);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.tbInValidValueCount);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.tbRtAverageCt);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.tbRtNumTotal);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.tbRtPassRate);
            this.groupBox5.Controls.Add(this.tbRtNumNg);
            this.groupBox5.Controls.Add(this.tbRtNumOk);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.ForeColor = System.Drawing.Color.DarkOrange;
            this.groupBox5.Location = new System.Drawing.Point(1280, 4);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(142, 622);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "统计信息";
            // 
            // tbRtPassRate1
            // 
            this.tbRtPassRate1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tbRtPassRate1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbRtPassRate1.Location = new System.Drawing.Point(21, 330);
            this.tbRtPassRate1.Margin = new System.Windows.Forms.Padding(4);
            this.tbRtPassRate1.Name = "tbRtPassRate1";
            this.tbRtPassRate1.Size = new System.Drawing.Size(100, 31);
            this.tbRtPassRate1.TabIndex = 24;
            this.tbRtPassRate1.Text = "0";
            this.tbRtPassRate1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(21, 299);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 24);
            this.label3.TabIndex = 23;
            this.label3.Text = "良率 (含无效值)";
            // 
            // tbInValidValueCount
            // 
            this.tbInValidValueCount.BackColor = System.Drawing.Color.Red;
            this.tbInValidValueCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbInValidValueCount.ForeColor = System.Drawing.Color.White;
            this.tbInValidValueCount.Location = new System.Drawing.Point(21, 200);
            this.tbInValidValueCount.Margin = new System.Windows.Forms.Padding(4);
            this.tbInValidValueCount.Name = "tbInValidValueCount";
            this.tbInValidValueCount.Size = new System.Drawing.Size(100, 31);
            this.tbInValidValueCount.TabIndex = 22;
            this.tbInValidValueCount.Text = "0";
            this.tbInValidValueCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(21, 169);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 21;
            this.label1.Text = "无效值：";
            // 
            // tbRtAverageCt
            // 
            this.tbRtAverageCt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tbRtAverageCt.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbRtAverageCt.Location = new System.Drawing.Point(21, 460);
            this.tbRtAverageCt.Margin = new System.Windows.Forms.Padding(4);
            this.tbRtAverageCt.Name = "tbRtAverageCt";
            this.tbRtAverageCt.Size = new System.Drawing.Size(100, 31);
            this.tbRtAverageCt.TabIndex = 20;
            this.tbRtAverageCt.Text = "0";
            this.tbRtAverageCt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(21, 429);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 24);
            this.label2.TabIndex = 19;
            this.label2.Text = "CT：";
            // 
            // tbRtNumTotal
            // 
            this.tbRtNumTotal.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbRtNumTotal.Location = new System.Drawing.Point(21, 395);
            this.tbRtNumTotal.Margin = new System.Windows.Forms.Padding(4);
            this.tbRtNumTotal.Name = "tbRtNumTotal";
            this.tbRtNumTotal.Size = new System.Drawing.Size(100, 31);
            this.tbRtNumTotal.TabIndex = 15;
            this.tbRtNumTotal.Text = "0";
            this.tbRtNumTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(21, 364);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 24);
            this.label12.TabIndex = 14;
            this.label12.Text = "总计：";
            // 
            // tbRtPassRate
            // 
            this.tbRtPassRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tbRtPassRate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbRtPassRate.Location = new System.Drawing.Point(21, 265);
            this.tbRtPassRate.Margin = new System.Windows.Forms.Padding(4);
            this.tbRtPassRate.Name = "tbRtPassRate";
            this.tbRtPassRate.Size = new System.Drawing.Size(100, 31);
            this.tbRtPassRate.TabIndex = 9;
            this.tbRtPassRate.Text = "0";
            this.tbRtPassRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbRtNumNg
            // 
            this.tbRtNumNg.BackColor = System.Drawing.Color.Red;
            this.tbRtNumNg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbRtNumNg.ForeColor = System.Drawing.Color.White;
            this.tbRtNumNg.Location = new System.Drawing.Point(21, 135);
            this.tbRtNumNg.Margin = new System.Windows.Forms.Padding(4);
            this.tbRtNumNg.Name = "tbRtNumNg";
            this.tbRtNumNg.Size = new System.Drawing.Size(100, 31);
            this.tbRtNumNg.TabIndex = 8;
            this.tbRtNumNg.Text = "0";
            this.tbRtNumNg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbRtNumOk
            // 
            this.tbRtNumOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tbRtNumOk.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbRtNumOk.Location = new System.Drawing.Point(21, 70);
            this.tbRtNumOk.Margin = new System.Windows.Forms.Padding(4);
            this.tbRtNumOk.Name = "tbRtNumOk";
            this.tbRtNumOk.Size = new System.Drawing.Size(100, 31);
            this.tbRtNumOk.TabIndex = 7;
            this.tbRtNumOk.Text = "0";
            this.tbRtNumOk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(21, 234);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 24);
            this.label8.TabIndex = 3;
            this.label8.Text = "良率 (不含无效值)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(21, 104);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 24);
            this.label7.TabIndex = 2;
            this.label7.Text = "NG：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(21, 39);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 24);
            this.label9.TabIndex = 1;
            this.label9.Text = "OK：";
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.Controls.Add(this.groupBox5, 1, 0);
            this.tlpMain.Controls.Add(this.pnlMain, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1426, 630);
            this.tlpMain.TabIndex = 1;
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1276, 630);
            this.pnlMain.TabIndex = 15;
            // 
            // RtDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "RtDataControl";
            this.Size = new System.Drawing.Size(1426, 630);
            this.Load += new System.EventHandler(this.MainSingleControl_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private GroupBox groupBox5;
        private TextBox tbRtAverageCt;
        private Label label2;
        private TextBox tbRtNumTotal;
        private Label label12;
        private TextBox tbRtPassRate;
        private TextBox tbRtNumNg;
        private TextBox tbRtNumOk;
        private Label label8;
        private Label label7;
        private Label label9;
        private TableLayoutPanel tlpMain;
        private TextBox tbInValidValueCount;
        private Label label1;
        private TextBox tbRtPassRate1;
        private Label label3;
        private Panel pnlMain;
    }
}
