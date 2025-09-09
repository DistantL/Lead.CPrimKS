
namespace Lead.CPrim.ProxyTools.Authority.Forms
{
    partial class AuthorityManagerUI
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvData = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDataGridView();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passWordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorityDbBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblLevel1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblLevel1Count = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblLevel2 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblLevel2Count = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblLevel3 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblLevel3Count = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.btnAdd = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.lb_UserName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.txtUserName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.lb_Password = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.txtPassWord = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.lb_Level = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.cboLevel = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.btnDel = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.pnlMain = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.lb_UserId = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lb_ID = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.txtUserId = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.txtID = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.tlpMain = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.pnlInfo = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorityDbBindingSource)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(83)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(22, 0, 15, 0);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(83)))));
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvData.ColumnHeadersHeight = 32;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn,
            this.UserId,
            this.ID,
            this.passWordDataGridViewTextBoxColumn,
            this.levelDataGridViewTextBoxColumn});
            this.dgvData.DataSource = this.authorityDbBindingSource;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.dgvData.Location = new System.Drawing.Point(3, 3);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.dgvData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 51;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvData.RowTemplate.Height = 27;
            this.dgvData.ScrollBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvData.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.dgvData.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.dgvData.SelectedIndex = -1;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(534, 346);
            this.dgvData.StripeEvenColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.dgvData.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvData.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.dgvData.StyleCustomMode = true;
            this.dgvData.TabIndex = 0;
            this.dgvData.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_data_CellClick);
            this.dgvData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvData_CellFormatting);
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.FillWeight = 253.8071F;
            this.userNameDataGridViewTextBoxColumn.HeaderText = "用户名";
            this.userNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.userNameDataGridViewTextBoxColumn.Width = 120;
            // 
            // UserId
            // 
            this.UserId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UserId.DataPropertyName = "UserId";
            this.UserId.FillWeight = 128.1328F;
            this.UserId.HeaderText = "用户ID卡号";
            this.UserId.MinimumWidth = 6;
            this.UserId.Name = "UserId";
            this.UserId.ReadOnly = true;
            this.UserId.Width = 120;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 69.36443F;
            this.ID.HeaderText = "工号";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 120;
            // 
            // passWordDataGridViewTextBoxColumn
            // 
            this.passWordDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.passWordDataGridViewTextBoxColumn.DataPropertyName = "PassWord";
            this.passWordDataGridViewTextBoxColumn.FillWeight = 2.079268F;
            this.passWordDataGridViewTextBoxColumn.HeaderText = "密码";
            this.passWordDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.passWordDataGridViewTextBoxColumn.Name = "passWordDataGridViewTextBoxColumn";
            this.passWordDataGridViewTextBoxColumn.ReadOnly = true;
            this.passWordDataGridViewTextBoxColumn.Width = 300;
            // 
            // levelDataGridViewTextBoxColumn
            // 
            this.levelDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.levelDataGridViewTextBoxColumn.DataPropertyName = "Level";
            this.levelDataGridViewTextBoxColumn.FillWeight = 46.61642F;
            this.levelDataGridViewTextBoxColumn.HeaderText = "权限等级";
            this.levelDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.levelDataGridViewTextBoxColumn.Name = "levelDataGridViewTextBoxColumn";
            this.levelDataGridViewTextBoxColumn.ReadOnly = true;
            this.levelDataGridViewTextBoxColumn.Width = 125;
            // 
            // authorityDbBindingSource
            // 
            this.authorityDbBindingSource.DataSource = typeof(Lead.CPrim.ProxyTools.Authority.AuthorityDb);
            // 
            // lblLevel1
            // 
            this.lblLevel1.AutoSize = true;
            this.lblLevel1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblLevel1.Location = new System.Drawing.Point(23, 17);
            this.lblLevel1.Name = "lblLevel1";
            this.lblLevel1.Size = new System.Drawing.Size(80, 23);
            this.lblLevel1.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.lblLevel1.TabIndex = 1;
            this.lblLevel1.Text = "Level1：";
            this.lblLevel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLevel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblLevel1Count
            // 
            this.lblLevel1Count.AutoSize = true;
            this.lblLevel1Count.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblLevel1Count.Location = new System.Drawing.Point(110, 17);
            this.lblLevel1Count.Name = "lblLevel1Count";
            this.lblLevel1Count.Size = new System.Drawing.Size(20, 23);
            this.lblLevel1Count.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.lblLevel1Count.TabIndex = 1;
            this.lblLevel1Count.Text = "0";
            this.lblLevel1Count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLevel1Count.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblLevel2
            // 
            this.lblLevel2.AutoSize = true;
            this.lblLevel2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblLevel2.Location = new System.Drawing.Point(177, 17);
            this.lblLevel2.Name = "lblLevel2";
            this.lblLevel2.Size = new System.Drawing.Size(80, 23);
            this.lblLevel2.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.lblLevel2.TabIndex = 1;
            this.lblLevel2.Text = "Level2：";
            this.lblLevel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLevel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblLevel2Count
            // 
            this.lblLevel2Count.AutoSize = true;
            this.lblLevel2Count.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblLevel2Count.Location = new System.Drawing.Point(264, 17);
            this.lblLevel2Count.Name = "lblLevel2Count";
            this.lblLevel2Count.Size = new System.Drawing.Size(20, 23);
            this.lblLevel2Count.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.lblLevel2Count.TabIndex = 1;
            this.lblLevel2Count.Text = "0";
            this.lblLevel2Count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLevel2Count.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblLevel3
            // 
            this.lblLevel3.AutoSize = true;
            this.lblLevel3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblLevel3.Location = new System.Drawing.Point(331, 17);
            this.lblLevel3.Name = "lblLevel3";
            this.lblLevel3.Size = new System.Drawing.Size(80, 23);
            this.lblLevel3.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.lblLevel3.TabIndex = 1;
            this.lblLevel3.Text = "Level3：";
            this.lblLevel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLevel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblLevel3Count
            // 
            this.lblLevel3Count.AutoSize = true;
            this.lblLevel3Count.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblLevel3Count.Location = new System.Drawing.Point(418, 17);
            this.lblLevel3Count.Name = "lblLevel3Count";
            this.lblLevel3Count.Size = new System.Drawing.Size(20, 23);
            this.lblLevel3Count.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.lblLevel3Count.TabIndex = 1;
            this.lblLevel3Count.Text = "0";
            this.lblLevel3Count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLevel3Count.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnAdd.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnAdd.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnAdd.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnAdd.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(18, 348);
            this.btnAdd.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Radius = 15;
            this.btnAdd.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnAdd.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnAdd.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnAdd.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnAdd.Size = new System.Drawing.Size(100, 35);
            this.btnAdd.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "新增";
            this.btnAdd.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lb_UserName
            // 
            this.lb_UserName.AutoSize = true;
            this.lb_UserName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_UserName.Location = new System.Drawing.Point(18, 11);
            this.lb_UserName.Name = "lb_UserName";
            this.lb_UserName.Size = new System.Drawing.Size(132, 27);
            this.lb_UserName.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.lb_UserName.TabIndex = 1;
            this.lb_UserName.Text = "UserName：";
            this.lb_UserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_UserName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtUserName
            // 
            this.txtUserName.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtUserName.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.txtUserName.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtUserName.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtUserName.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.txtUserName.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtUserName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserName.Location = new System.Drawing.Point(154, 6);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtUserName.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtUserName.ShowText = false;
            this.txtUserName.Size = new System.Drawing.Size(180, 31);
            this.txtUserName.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.txtUserName.TabIndex = 3;
            this.txtUserName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_Password
            // 
            this.lb_Password.AutoSize = true;
            this.lb_Password.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Password.Location = new System.Drawing.Point(18, 206);
            this.lb_Password.Name = "lb_Password";
            this.lb_Password.Size = new System.Drawing.Size(123, 27);
            this.lb_Password.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.lb_Password.TabIndex = 1;
            this.lb_Password.Text = "Password：";
            this.lb_Password.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_Password.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtPassWord
            // 
            this.txtPassWord.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtPassWord.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.txtPassWord.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtPassWord.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtPassWord.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.txtPassWord.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtPassWord.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassWord.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtPassWord.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPassWord.Location = new System.Drawing.Point(154, 201);
            this.txtPassWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassWord.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtPassWord.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtPassWord.ShowText = false;
            this.txtPassWord.Size = new System.Drawing.Size(180, 31);
            this.txtPassWord.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.txtPassWord.TabIndex = 3;
            this.txtPassWord.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_Level
            // 
            this.lb_Level.AutoSize = true;
            this.lb_Level.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Level.Location = new System.Drawing.Point(18, 271);
            this.lb_Level.Name = "lb_Level";
            this.lb_Level.Size = new System.Drawing.Size(80, 27);
            this.lb_Level.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.lb_Level.TabIndex = 1;
            this.lb_Level.Text = "Level：";
            this.lb_Level.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_Level.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cboLevel
            // 
            this.cboLevel.DataSource = null;
            this.cboLevel.FillColor = System.Drawing.Color.White;
            this.cboLevel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cboLevel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboLevel.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.cboLevel.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.cboLevel.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cboLevel.Location = new System.Drawing.Point(154, 266);
            this.cboLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboLevel.MinimumSize = new System.Drawing.Size(63, 0);
            this.cboLevel.Name = "cboLevel";
            this.cboLevel.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cboLevel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.cboLevel.Size = new System.Drawing.Size(180, 31);
            this.cboLevel.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.cboLevel.TabIndex = 4;
            this.cboLevel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnDel
            // 
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnDel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnDel.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnDel.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnDel.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnDel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.Location = new System.Drawing.Point(234, 348);
            this.btnDel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDel.Name = "btnDel";
            this.btnDel.Radius = 15;
            this.btnDel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnDel.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnDel.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnDel.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnDel.Size = new System.Drawing.Size(100, 35);
            this.btnDel.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "删除";
            this.btnDel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lb_UserName);
            this.pnlMain.Controls.Add(this.lb_UserId);
            this.pnlMain.Controls.Add(this.lb_ID);
            this.pnlMain.Controls.Add(this.lb_Password);
            this.pnlMain.Controls.Add(this.txtUserId);
            this.pnlMain.Controls.Add(this.cboLevel);
            this.pnlMain.Controls.Add(this.txtID);
            this.pnlMain.Controls.Add(this.lb_Level);
            this.pnlMain.Controls.Add(this.txtPassWord);
            this.pnlMain.Controls.Add(this.btnAdd);
            this.pnlMain.Controls.Add(this.txtUserName);
            this.pnlMain.Controls.Add(this.btnDel);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlMain.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlMain.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlMain.Location = new System.Drawing.Point(540, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.tlpMain.SetRowSpan(this.pnlMain, 2);
            this.pnlMain.Size = new System.Drawing.Size(350, 402);
            this.pnlMain.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.pnlMain.TabIndex = 5;
            this.pnlMain.Text = null;
            this.pnlMain.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlMain.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_UserId
            // 
            this.lb_UserId.AutoSize = true;
            this.lb_UserId.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_UserId.Location = new System.Drawing.Point(18, 76);
            this.lb_UserId.Name = "lb_UserId";
            this.lb_UserId.Size = new System.Drawing.Size(94, 27);
            this.lb_UserId.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.lb_UserId.TabIndex = 1;
            this.lb_UserId.Text = "UserId：";
            this.lb_UserId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_UserId.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_ID
            // 
            this.lb_ID.AutoSize = true;
            this.lb_ID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_ID.Location = new System.Drawing.Point(18, 141);
            this.lb_ID.Name = "lb_ID";
            this.lb_ID.Size = new System.Drawing.Size(53, 27);
            this.lb_ID.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.lb_ID.TabIndex = 1;
            this.lb_ID.Text = "ID：";
            this.lb_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_ID.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtUserId
            // 
            this.txtUserId.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtUserId.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.txtUserId.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtUserId.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtUserId.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.txtUserId.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtUserId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserId.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtUserId.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserId.Location = new System.Drawing.Point(154, 71);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserId.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtUserId.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtUserId.ShowText = false;
            this.txtUserId.Size = new System.Drawing.Size(180, 31);
            this.txtUserId.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.txtUserId.TabIndex = 3;
            this.txtUserId.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtID
            // 
            this.txtID.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtID.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.txtID.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtID.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtID.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.txtID.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtID.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtID.Location = new System.Drawing.Point(154, 136);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtID.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtID.Name = "txtID";
            this.txtID.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtID.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtID.ShowText = false;
            this.txtID.Size = new System.Drawing.Size(180, 31);
            this.txtID.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.txtID.TabIndex = 3;
            this.txtID.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tlpMain.Controls.Add(this.dgvData, 0, 0);
            this.tlpMain.Controls.Add(this.pnlMain, 1, 0);
            this.tlpMain.Controls.Add(this.pnlInfo, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.Size = new System.Drawing.Size(890, 402);
            this.tlpMain.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.tlpMain.TabIndex = 6;
            this.tlpMain.TagString = null;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.lblLevel1);
            this.pnlInfo.Controls.Add(this.lblLevel3Count);
            this.pnlInfo.Controls.Add(this.lblLevel2);
            this.pnlInfo.Controls.Add(this.lblLevel2Count);
            this.pnlInfo.Controls.Add(this.lblLevel3);
            this.pnlInfo.Controls.Add(this.lblLevel1Count);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInfo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlInfo.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlInfo.Location = new System.Drawing.Point(0, 352);
            this.pnlInfo.Margin = new System.Windows.Forms.Padding(0);
            this.pnlInfo.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.pnlInfo.Size = new System.Drawing.Size(540, 50);
            this.pnlInfo.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.pnlInfo.TabIndex = 6;
            this.pnlInfo.Text = null;
            this.pnlInfo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlInfo.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // AuthorityManagerUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(890, 402);
            this.Controls.Add(this.tlpMain);
            this.Name = "AuthorityManagerUI";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.Text = "用户信息系统";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorityDbBindingSource)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDataGridView dgvData;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel lblLevel1;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel lblLevel1Count;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel lblLevel2;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel lblLevel2Count;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel lblLevel3;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel lblLevel3Count;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton btnAdd;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel lb_UserName;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox txtUserName;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel lb_Password;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox txtPassWord;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel lb_Level;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox cboLevel;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton btnDel;
        private SunnyUI.Controls.UIPanel pnlMain;
        private System.Windows.Forms.BindingSource authorityDbBindingSource;
        private SunnyUI.Controls.UITableLayoutPanel tlpMain;
        private SunnyUI.Controls.UIPanel pnlInfo;
        private SunnyUI.Controls.UILabel lb_UserId;
        private SunnyUI.Controls.UILabel lb_ID;
        private SunnyUI.Controls.UITextBox txtUserId;
        private SunnyUI.Controls.UITextBox txtID;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn passWordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelDataGridViewTextBoxColumn;
    }
}

