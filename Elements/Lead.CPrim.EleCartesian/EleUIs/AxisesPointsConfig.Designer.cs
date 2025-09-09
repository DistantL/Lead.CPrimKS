using System.ComponentModel;
using System.Windows.Forms;

namespace Lead.CPrim.EleCartesian.EleUIs
{
    partial class AxisesPointsConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabPoints = new System.Windows.Forms.TabControl();
            this.tbPointsPath = new System.Windows.Forms.TextBox();
            this.btnTableSave = new System.Windows.Forms.Button();
            this.btnTableLoad = new System.Windows.Forms.Button();
            this.btnDataApply = new System.Windows.Forms.Button();
            this.btnDelRow = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabPoints);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbPointsPath);
            this.splitContainer1.Panel2.Controls.Add(this.btnTableSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnTableLoad);
            this.splitContainer1.Panel2.Controls.Add(this.btnDataApply);
            this.splitContainer1.Panel2.Controls.Add(this.btnDelRow);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddRow);
            this.splitContainer1.Size = new System.Drawing.Size(933, 637);
            this.splitContainer1.SplitterDistance = 521;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabPoints
            // 
            this.tabPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPoints.Location = new System.Drawing.Point(0, 0);
            this.tabPoints.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPoints.Name = "tabPoints";
            this.tabPoints.SelectedIndex = 0;
            this.tabPoints.Size = new System.Drawing.Size(933, 521);
            this.tabPoints.TabIndex = 1;
            // 
            // tbPointsPath
            // 
            this.tbPointsPath.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbPointsPath.Location = new System.Drawing.Point(26, 68);
            this.tbPointsPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPointsPath.Name = "tbPointsPath";
            this.tbPointsPath.Size = new System.Drawing.Size(416, 23);
            this.tbPointsPath.TabIndex = 160;
            // 
            // btnTableSave
            // 
            this.btnTableSave.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTableSave.Location = new System.Drawing.Point(449, 65);
            this.btnTableSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTableSave.Name = "btnTableSave";
            this.btnTableSave.Size = new System.Drawing.Size(73, 37);
            this.btnTableSave.TabIndex = 157;
            this.btnTableSave.Text = "保存";
            this.btnTableSave.UseVisualStyleBackColor = true;
            this.btnTableSave.Visible = false;
            // 
            // btnTableLoad
            // 
            this.btnTableLoad.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnTableLoad.Location = new System.Drawing.Point(527, 65);
            this.btnTableLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTableLoad.Name = "btnTableLoad";
            this.btnTableLoad.Size = new System.Drawing.Size(73, 37);
            this.btnTableLoad.TabIndex = 158;
            this.btnTableLoad.Text = "载入";
            this.btnTableLoad.UseVisualStyleBackColor = true;
            this.btnTableLoad.Click += new System.EventHandler(this.BtnTableLoad_Click);
            // 
            // btnDataApply
            // 
            this.btnDataApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDataApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnDataApply.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnDataApply.Location = new System.Drawing.Point(770, 62);
            this.btnDataApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDataApply.Name = "btnDataApply";
            this.btnDataApply.Size = new System.Drawing.Size(138, 44);
            this.btnDataApply.TabIndex = 156;
            this.btnDataApply.Text = "应用";
            this.btnDataApply.UseVisualStyleBackColor = false;
            this.btnDataApply.Click += new System.EventHandler(this.BtnTableSaveAs_Click);
            // 
            // btnDelRow
            // 
            this.btnDelRow.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnDelRow.Location = new System.Drawing.Point(92, 17);
            this.btnDelRow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(59, 37);
            this.btnDelRow.TabIndex = 154;
            this.btnDelRow.Text = "-";
            this.btnDelRow.UseVisualStyleBackColor = true;
            this.btnDelRow.Click += new System.EventHandler(this.BtnDelRow_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnAddRow.Location = new System.Drawing.Point(26, 17);
            this.btnAddRow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(59, 37);
            this.btnAddRow.TabIndex = 155;
            this.btnAddRow.Text = "+";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.BtnAddRow_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "\"json File|*.json|All File|\".\"\"";
            // 
            // AxisesPointsConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 637);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AxisesPointsConfig";
            this.Text = "点位管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AxisesPointsConfig_FormClosing);
            this.Load += new System.EventHandler(this.AxisesPointsConfig_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private TabControl tabPoints;
        private TextBox tbPointsPath;
        private Button btnTableSave;
        private Button btnTableLoad;
        private Button btnDataApply;
        private Button btnDelRow;
        private Button btnAddRow;
        private OpenFileDialog openFileDialog1;
    }
}