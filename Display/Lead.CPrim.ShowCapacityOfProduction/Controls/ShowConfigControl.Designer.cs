using Lead.CPrim.ProxyTools.SunnyUI.Controls;

namespace Lead.CPrim.ShowCapacityOfProduction.Controls
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
            this.cmbStations = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.btnRemoveProColor = new System.Windows.Forms.Button();
            this.btnAddColor = new System.Windows.Forms.Button();
            this.cmbProColors = new System.Windows.Forms.ComboBox();
            this.kryptonLabel5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPath = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.btnSelectPath = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISymbolButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCurrentFAIName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.SuspendLayout();
            // 
            // cmbStations
            // 
            this.cmbStations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStations.FormattingEnabled = true;
            this.cmbStations.Location = new System.Drawing.Point(98, 54);
            this.cmbStations.Name = "cmbStations";
            this.cmbStations.Size = new System.Drawing.Size(121, 25);
            this.cmbStations.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(38, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "工站:";
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(684, 437);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(179, 34);
            this.btnApply.TabIndex = 128;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.BackColor = System.Drawing.Color.Transparent;
            this.chkEnable.Location = new System.Drawing.Point(38, 260);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(51, 21);
            this.chkEnable.TabIndex = 129;
            this.chkEnable.Text = "使能";
            this.chkEnable.UseVisualStyleBackColor = false;
            // 
            // btnRemoveProColor
            // 
            this.btnRemoveProColor.Location = new System.Drawing.Point(827, 54);
            this.btnRemoveProColor.Name = "btnRemoveProColor";
            this.btnRemoveProColor.Size = new System.Drawing.Size(34, 25);
            this.btnRemoveProColor.TabIndex = 235;
            this.btnRemoveProColor.Text = "-";
            this.btnRemoveProColor.Click += new System.EventHandler(this.btnRemoveProColor_Click);
            // 
            // btnAddColor
            // 
            this.btnAddColor.Location = new System.Drawing.Point(777, 54);
            this.btnAddColor.Name = "btnAddColor";
            this.btnAddColor.Size = new System.Drawing.Size(34, 25);
            this.btnAddColor.TabIndex = 234;
            this.btnAddColor.Text = "+";
            this.btnAddColor.Click += new System.EventHandler(this.btnAddColor_Click);
            // 
            // cmbProColors
            // 
            this.cmbProColors.DropDownWidth = 85;
            this.cmbProColors.Location = new System.Drawing.Point(665, 54);
            this.cmbProColors.Name = "cmbProColors";
            this.cmbProColors.Size = new System.Drawing.Size(95, 25);
            this.cmbProColors.TabIndex = 233;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.BackColor = System.Drawing.Color.Transparent;
            this.kryptonLabel5.Location = new System.Drawing.Point(581, 56);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel5.TabIndex = 232;
            this.kryptonLabel5.Text = "颜色列表：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(38, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 17);
            this.label6.TabIndex = 236;
            this.label6.Text = "产能数据路径：";
            // 
            // txtPath
            // 
            this.txtPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPath.Location = new System.Drawing.Point(141, 312);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPath.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtPath.Name = "txtPath";
            this.txtPath.ShowText = false;
            this.txtPath.Size = new System.Drawing.Size(499, 29);
            this.txtPath.TabIndex = 256;
            this.txtPath.Watermark = "产能数据路径";
            this.txtPath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectPath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectPath.Location = new System.Drawing.Point(652, 309);
            this.btnSelectPath.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(34, 35);
            this.btnSelectPath.Symbol = 61761;
            this.btnSelectPath.TabIndex = 257;
            this.btnSelectPath.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectPath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(38, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 236;
            this.label4.Text = "FAI名称：";
            // 
            // txtCurrentFAIName
            // 
            this.txtCurrentFAIName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCurrentFAIName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCurrentFAIName.Location = new System.Drawing.Point(129, 182);
            this.txtCurrentFAIName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCurrentFAIName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtCurrentFAIName.Name = "txtCurrentFAIName";
            this.txtCurrentFAIName.ShowText = false;
            this.txtCurrentFAIName.Size = new System.Drawing.Size(150, 29);
            this.txtCurrentFAIName.TabIndex = 258;
            this.txtCurrentFAIName.Watermark = "当前FAI名称";
            this.txtCurrentFAIName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ShowConfigControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.txtCurrentFAIName);
            this.Controls.Add(this.btnSelectPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRemoveProColor);
            this.Controls.Add(this.btnAddColor);
            this.Controls.Add(this.cmbProColors);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.chkEnable);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbStations);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ShowConfigControl";
            this.Size = new System.Drawing.Size(896, 516);
            this.Load += new System.EventHandler(this.ShowConfigControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbStations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.Button btnRemoveProColor;
        private System.Windows.Forms.Button btnAddColor;
        private System.Windows.Forms.ComboBox cmbProColors;
        private System.Windows.Forms.Label kryptonLabel5;
        private System.Windows.Forms.Label label6;
        private ProxyTools.SunnyUI.Controls.UITextBox txtPath;
        private UISymbolButton btnSelectPath;
        private System.Windows.Forms.Label label4;
        private ProxyTools.SunnyUI.Controls.UITextBox txtCurrentFAIName;
    }
}
