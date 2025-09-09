namespace Lead.CPrim.EleAnalogInputPro
{
    partial class ConfigUI
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
            this.components = new System.ComponentModel.Container();
            this.lblPrimName = new System.Windows.Forms.Label();
            this.cboPrim = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblRealTimeAnalog = new System.Windows.Forms.Label();
            this.lblRealTimeDigital = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.txtRealTimeAnalog = new System.Windows.Forms.TextBox();
            this.txtRealTimeDigital = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtState = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.chkSimulate = new System.Windows.Forms.CheckBox();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.analogCalculateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblAddress = new System.Windows.Forms.Label();
            this.dgvAnalog = new System.Windows.Forms.DataGridView();
            this.colAnalog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDigital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.analogCalculateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalog)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPrimName
            // 
            this.lblPrimName.AutoSize = true;
            this.lblPrimName.BackColor = System.Drawing.Color.Transparent;
            this.lblPrimName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblPrimName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPrimName.Location = new System.Drawing.Point(172, 66);
            this.lblPrimName.Name = "lblPrimName";
            this.lblPrimName.Size = new System.Drawing.Size(80, 20);
            this.lblPrimName.TabIndex = 197;
            this.lblPrimName.Text = "PrimName";
            this.lblPrimName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPrim
            // 
            this.cboPrim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrim.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cboPrim.FormattingEnabled = true;
            this.cboPrim.Location = new System.Drawing.Point(172, 91);
            this.cboPrim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboPrim.Name = "cboPrim";
            this.cboPrim.Size = new System.Drawing.Size(120, 27);
            this.cboPrim.TabIndex = 218;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(334, 93);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(120, 23);
            this.txtAddress.TabIndex = 213;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblType.Location = new System.Drawing.Point(10, 66);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(41, 20);
            this.lblType.TabIndex = 215;
            this.lblType.Text = "Type";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRealTimeAnalog
            // 
            this.lblRealTimeAnalog.BackColor = System.Drawing.SystemColors.Info;
            this.lblRealTimeAnalog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRealTimeAnalog.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRealTimeAnalog.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRealTimeAnalog.Location = new System.Drawing.Point(10, 311);
            this.lblRealTimeAnalog.Name = "lblRealTimeAnalog";
            this.lblRealTimeAnalog.Size = new System.Drawing.Size(120, 28);
            this.lblRealTimeAnalog.TabIndex = 201;
            this.lblRealTimeAnalog.Text = "RealTimeAnalog";
            this.lblRealTimeAnalog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRealTimeDigital
            // 
            this.lblRealTimeDigital.BackColor = System.Drawing.SystemColors.Info;
            this.lblRealTimeDigital.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRealTimeDigital.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRealTimeDigital.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRealTimeDigital.Location = new System.Drawing.Point(239, 311);
            this.lblRealTimeDigital.Name = "lblRealTimeDigital";
            this.lblRealTimeDigital.Size = new System.Drawing.Size(120, 28);
            this.lblRealTimeDigital.TabIndex = 200;
            this.lblRealTimeDigital.Text = "RealTimeDigital";
            this.lblRealTimeDigital.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "Voltage(V)",
            "Electricity(mA)"});
            this.cboType.Location = new System.Drawing.Point(10, 91);
            this.cboType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(120, 27);
            this.cboType.TabIndex = 216;
            // 
            // txtRealTimeAnalog
            // 
            this.txtRealTimeAnalog.Location = new System.Drawing.Point(139, 314);
            this.txtRealTimeAnalog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRealTimeAnalog.Name = "txtRealTimeAnalog";
            this.txtRealTimeAnalog.ReadOnly = true;
            this.txtRealTimeAnalog.Size = new System.Drawing.Size(90, 23);
            this.txtRealTimeAnalog.TabIndex = 208;
            // 
            // txtRealTimeDigital
            // 
            this.txtRealTimeDigital.Location = new System.Drawing.Point(364, 314);
            this.txtRealTimeDigital.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRealTimeDigital.Name = "txtRealTimeDigital";
            this.txtRealTimeDigital.ReadOnly = true;
            this.txtRealTimeDigital.Size = new System.Drawing.Size(90, 23);
            this.txtRealTimeDigital.TabIndex = 206;
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnApply.Location = new System.Drawing.Point(239, 345);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(215, 35);
            this.btnApply.TabIndex = 217;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtState
            // 
            this.txtState.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtState.Location = new System.Drawing.Point(334, 31);
            this.txtState.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(120, 25);
            this.txtState.TabIndex = 9;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.BackColor = System.Drawing.Color.Transparent;
            this.lblState.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblState.ForeColor = System.Drawing.Color.Black;
            this.lblState.Location = new System.Drawing.Point(334, 6);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(43, 20);
            this.lblState.TabIndex = 8;
            this.lblState.Text = "State";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblState.Click += new System.EventHandler(this.LbState_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtInfo.Location = new System.Drawing.Point(172, 31);
            this.txtInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(120, 25);
            this.txtInfo.TabIndex = 3;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblInfo.ForeColor = System.Drawing.Color.Black;
            this.lblInfo.Location = new System.Drawing.Point(172, 6);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(36, 20);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "Info";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtName.Location = new System.Drawing.Point(10, 31);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(120, 25);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(10, 6);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblName.DoubleClick += new System.EventHandler(this.panel1_Click);
            // 
            // chkSimulate
            // 
            this.chkSimulate.AutoSize = true;
            this.chkSimulate.Location = new System.Drawing.Point(129, 352);
            this.chkSimulate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkSimulate.Name = "chkSimulate";
            this.chkSimulate.Size = new System.Drawing.Size(76, 21);
            this.chkSimulate.TabIndex = 1;
            this.chkSimulate.Text = "Simulate";
            this.chkSimulate.UseVisualStyleBackColor = true;
            this.chkSimulate.Visible = false;
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(10, 352);
            this.chkEnable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(66, 21);
            this.chkEnable.TabIndex = 2;
            this.chkEnable.Text = "Enable";
            this.chkEnable.UseVisualStyleBackColor = true;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdd,
            this.tsmiDelete});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(101, 48);
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.Size = new System.Drawing.Size(100, 22);
            this.tsmiAdd.Text = "增加";
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(100, 22);
            this.tsmiDelete.Text = "删除";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // analogCalculateBindingSource
            // 
            this.analogCalculateBindingSource.DataSource = typeof(Lead.CPrim.EleAnalogInputPro.AnalogCalculate);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblAddress.ForeColor = System.Drawing.Color.Black;
            this.lblAddress.Location = new System.Drawing.Point(334, 66);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(62, 20);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Address";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAddress.DoubleClick += new System.EventHandler(this.panel1_Click);
            // 
            // dgvAnalog
            // 
            this.dgvAnalog.AllowUserToAddRows = false;
            this.dgvAnalog.AllowUserToDeleteRows = false;
            this.dgvAnalog.AutoGenerateColumns = false;
            this.dgvAnalog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnalog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAnalog,
            this.colDigital});
            this.dgvAnalog.ContextMenuStrip = this.cms;
            this.dgvAnalog.DataSource = this.analogCalculateBindingSource;
            this.dgvAnalog.Location = new System.Drawing.Point(10, 127);
            this.dgvAnalog.Name = "dgvAnalog";
            this.dgvAnalog.RowTemplate.Height = 23;
            this.dgvAnalog.Size = new System.Drawing.Size(444, 180);
            this.dgvAnalog.TabIndex = 219;
            // 
            // colAnalog
            // 
            this.colAnalog.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAnalog.DataPropertyName = "RealTimeAnalog";
            this.colAnalog.HeaderText = "RealTimeAnalog";
            this.colAnalog.Name = "colAnalog";
            // 
            // colDigital
            // 
            this.colDigital.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDigital.DataPropertyName = "RealTimeDigital";
            this.colDigital.HeaderText = "RealTimeDigital";
            this.colDigital.Name = "colDigital";
            // 
            // ConfigUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dgvAnalog);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.chkSimulate);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblPrimName);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.chkEnable);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.cboPrim);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.txtRealTimeDigital);
            this.Controls.Add(this.txtRealTimeAnalog);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblRealTimeDigital);
            this.Controls.Add(this.lblRealTimeAnalog);
            this.Controls.Add(this.btnApply);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ConfigUI";
            this.Radius = 10;
            this.Size = new System.Drawing.Size(460, 390);
            this.Load += new System.EventHandler(this.ConfigUI_Load);
            this.cms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.analogCalculateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkSimulate;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrimName;
        private System.Windows.Forms.ComboBox cboPrim;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblRealTimeAnalog;
        private System.Windows.Forms.Label lblRealTimeDigital;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.TextBox txtRealTimeAnalog;
        private System.Windows.Forms.TextBox txtRealTimeDigital;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.BindingSource analogCalculateBindingSource;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.DataGridView dgvAnalog;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnalog;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDigital;
    }
}
