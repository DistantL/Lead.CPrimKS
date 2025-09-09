
namespace ThreadSafty_StreamlineControl
{
    partial class Form_PdcaTest
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
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pg_config = new System.Windows.Forms.PropertyGrid();
            this.pg_SendObj = new System.Windows.Forms.PropertyGrid();
            this.dgv_fai = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cb_cmd = new System.Windows.Forms.ComboBox();
            this.bt_UpData = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_fai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtb_log
            // 
            this.rtb_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_log.Location = new System.Drawing.Point(463, 143);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.Size = new System.Drawing.Size(334, 304);
            this.rtb_log.TabIndex = 4;
            this.rtb_log.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pg_config, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pg_SendObj, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgv_fai, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.rtb_log, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pg_config
            // 
            this.pg_config.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg_config.Location = new System.Drawing.Point(3, 43);
            this.pg_config.Name = "pg_config";
            this.tableLayoutPanel1.SetRowSpan(this.pg_config, 2);
            this.pg_config.Size = new System.Drawing.Size(224, 404);
            this.pg_config.TabIndex = 0;
            // 
            // pg_SendObj
            // 
            this.pg_SendObj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg_SendObj.Location = new System.Drawing.Point(233, 143);
            this.pg_SendObj.Name = "pg_SendObj";
            this.pg_SendObj.Size = new System.Drawing.Size(224, 304);
            this.pg_SendObj.TabIndex = 1;
            // 
            // dgv_fai
            // 
            this.dgv_fai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgv_fai, 2);
            this.dgv_fai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_fai.Location = new System.Drawing.Point(233, 43);
            this.dgv_fai.Name = "dgv_fai";
            this.dgv_fai.RowTemplate.Height = 23;
            this.dgv_fai.Size = new System.Drawing.Size(564, 94);
            this.dgv_fai.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.splitContainer1, 2);
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(233, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cb_cmd);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10, 5, 10, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.bt_UpData);
            this.splitContainer1.Size = new System.Drawing.Size(564, 34);
            this.splitContainer1.SplitterDistance = 456;
            this.splitContainer1.TabIndex = 5;
            // 
            // cb_cmd
            // 
            this.cb_cmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_cmd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_cmd.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_cmd.FormattingEnabled = true;
            this.cb_cmd.Location = new System.Drawing.Point(10, 5);
            this.cb_cmd.Margin = new System.Windows.Forms.Padding(0);
            this.cb_cmd.Name = "cb_cmd";
            this.cb_cmd.Size = new System.Drawing.Size(436, 27);
            this.cb_cmd.TabIndex = 0;
            // 
            // bt_UpData
            // 
            this.bt_UpData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_UpData.Location = new System.Drawing.Point(0, 0);
            this.bt_UpData.Margin = new System.Windows.Forms.Padding(10);
            this.bt_UpData.Name = "bt_UpData";
            this.bt_UpData.Size = new System.Drawing.Size(104, 34);
            this.bt_UpData.TabIndex = 0;
            this.bt_UpData.Text = "上传";
            this.bt_UpData.UseVisualStyleBackColor = true;
            this.bt_UpData.Click += new System.EventHandler(this.bt_UpData_Click);
            // 
            // Form_PdcaTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form_PdcaTest";
            this.Text = "Form_PdcaTest";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_fai)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_log;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PropertyGrid pg_config;
        private System.Windows.Forms.PropertyGrid pg_SendObj;
        private System.Windows.Forms.DataGridView dgv_fai;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cb_cmd;
        private System.Windows.Forms.Button bt_UpData;
    }
}