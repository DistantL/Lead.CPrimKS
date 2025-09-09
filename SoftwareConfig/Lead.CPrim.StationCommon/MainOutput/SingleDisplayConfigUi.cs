using Lead.CPrim.Global;
using Lead.CPrim.ProxyTools;
using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Lead.CPrim.StationCommon.MainOutput
{
    public class SingleDisplayConfigUi : UserControl
	{
		#region 主界面参数
		private TabDisplayConfig _tabDisplayConfig; 
		#endregion


		#region Ctor
		/// <summary>
		/// Ctor无参
		/// </summary>
		public SingleDisplayConfigUi()
		{
			InitializeComponent();
            UpdateCmbPrimsName();
        }
		/// <summary>
		/// Ctor有一个参数
		/// </summary>
		/// <param name="tabDisplayConfig"></param>
		public SingleDisplayConfigUi(TabDisplayConfig tabDisplayConfig)
		{
			InitializeComponent();
			_tabDisplayConfig = tabDisplayConfig;
            UpdateCmbPrimsName();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion


        #region System_Event_Son
        /// <summary>
        /// 主界面界面表格基元名称更新_基元名称除外_2
        /// </summary>
        /// <param name="prim"></param>
        private void AddOnePrimOutputConfigToRow(PrimOutputConfig prim)
		{
			int index = dgvDisplayConfig.Rows.Add();
			dgvDisplayConfig.Rows[index].Cells[0].Value = prim.Name;
			dgvDisplayConfig.Rows[index].Cells[1].Value = prim.Enable;
			dgvDisplayConfig.Rows[index].Cells[2].Value = prim.RowNum.ToString();
			dgvDisplayConfig.Rows[index].Cells[3].Value = prim.ColNum.ToString();
			dgvDisplayConfig.Rows[index].Cells[4].Value = prim.RowSpan.ToString();
			dgvDisplayConfig.Rows[index].Cells[5].Value = prim.ColSpan.ToString();
		}
        /// <summary>
        /// 主界面界面表格基元名称更新_基元名称除外_1
        /// </summary>
        /// <param name="tabDisplayConfig"></param>
		private void AddConfigsToTable(TabDisplayConfig tabDisplayConfig)
		{
			foreach (var item in tabDisplayConfig.Prims.OrderBy(p => p.RowNum))
			{
				AddOnePrimOutputConfigToRow(item);
			}
		}
        /// <summary>
        /// 主界面界面表格基元名称更新
        /// </summary>
        private void UpdateCmbPrimsName()
        {
            string[] arrayPrimsName = new string[PrimsManagerTransfer.GetAllIPrim().Count + ShowManagerTransfer.GetAllIShow().Count];
            for (int i = 0; i < PrimsManagerTransfer.GetAllIPrim().Count; i++)
            {
                arrayPrimsName[i] = PrimsManagerTransfer.GetAllIPrim()[i].Name;
                if (!colPrimName.Items.Contains(arrayPrimsName[i]))
                {
                    colPrimName.Items.Add(arrayPrimsName[i]);
                }
            }
            for (int j = PrimsManagerTransfer.GetAllIPrim().Count; j < arrayPrimsName.Length; j++)
            {
                arrayPrimsName[j] = ShowManagerTransfer.GetAllIShow()[j - PrimsManagerTransfer.GetAllIPrim().Count].Name;
                if (!colPrimName.Items.Contains(arrayPrimsName[j]))
                {
                    colPrimName.Items.Add(arrayPrimsName[j]);
                }
            }
            foreach (PrimOutputConfig prim2 in from prim in _tabDisplayConfig.Prims
                                               where !string.IsNullOrEmpty(prim.Name)
                                               where !arrayPrimsName.Contains(prim.Name)
                                               select prim)
            {
                colPrimName.Items.Add(prim2.Name);
            }
        }
        #endregion


        #region System_Event
        /// <summary>
        /// Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayConfigUi_Load(object sender, EventArgs e)
		{
			tbName.Text = _tabDisplayConfig.Name;
			tbIndex.Text = _tabDisplayConfig.TabIndex.ToString();
			chkEnable.Checked = _tabDisplayConfig.Enable;
			tbRowCount.Text = _tabDisplayConfig.RowCount.ToString();
			tbColCount.Text = _tabDisplayConfig.ColCount.ToString();
			AddConfigsToTable(_tabDisplayConfig);
			UpdateCmbPrimsName();
		}
        #endregion


        #region Button_Event
        /// <summary>
        /// 增加显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            PrimOutputConfig newPrimOutput = new PrimOutputConfig();
            AddOnePrimOutputConfigToRow(newPrimOutput);
        }
        /// <summary>
        /// 移除显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            if (dgvDisplayConfig.Rows.Count > 0)
            {
                int curSelectedIdx = dgvDisplayConfig.CurrentCell.RowIndex;
                dgvDisplayConfig.Rows.RemoveAt(curSelectedIdx);
            }
        }
        /// <summary>
        /// 显示应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            _tabDisplayConfig.Name = tbName.Text;
            _tabDisplayConfig.TabIndex = int.Parse(tbIndex.Text);
            _tabDisplayConfig.Enable = chkEnable.Checked;
            _tabDisplayConfig.RowCount = int.Parse(tbRowCount.Text);
            _tabDisplayConfig.ColCount = int.Parse(tbColCount.Text);
            _tabDisplayConfig.Prims.Clear();
            foreach (DataGridViewRow row in (IEnumerable)dgvDisplayConfig.Rows)
            {
                PrimOutputConfig newPrimOutput = new PrimOutputConfig();
                if (row.Cells[0].Value != null)
                {
                    newPrimOutput.Name = row.Cells[0].Value.ToString();
                }
                if (row.Cells[1].Value != null && bool.TryParse(row.Cells[1].Value.ToString(), out var outEnable))
                {
                    newPrimOutput.Enable = outEnable;
                }
                if (row.Cells[2].Value != null && int.TryParse(row.Cells[2].Value.ToString(), out var outRowNum))
                {
                    newPrimOutput.RowNum = outRowNum;
                }
                if (row.Cells[3].Value != null && int.TryParse(row.Cells[3].Value.ToString(), out var outColNum))
                {
                    newPrimOutput.ColNum = outColNum;
                }
                if (row.Cells[4].Value != null && int.TryParse(row.Cells[4].Value.ToString(), out var outRowSpanNum))
                {
                    newPrimOutput.RowSpan = outRowSpanNum;
                }
                if (row.Cells[5].Value != null && int.TryParse(row.Cells[5].Value.ToString(), out var outColSpanNum))
                {
                    newPrimOutput.ColSpan = outColSpanNum;
                }
                _tabDisplayConfig.Prims.Add(newPrimOutput);
            }
            foreach (PrimOutputConfig item in _tabDisplayConfig.Prims)
            {
                if (item.RowSpan <= 0 || item.ColSpan <= 0)
                {
                    MessageBox.Show(item.Name + NLocalizer.GetString("Lead_CPrim_StationCommon_MainOutput_SingleDisplayConfigUi_NoSet0", "的跨行与跨列设置不能为0，请检查并重新配置"));
                }
            }
        }
        /// <summary>
        /// 显示刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshPrims_Click(object sender, EventArgs e)
        {
            UpdateCmbPrimsName();
        }
        /// <summary>
        /// 名称双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbName_DoubleClick(object sender, EventArgs e)
        {
            _tabDisplayConfig.IsSelected = !_tabDisplayConfig.IsSelected;
        }
        #endregion

        public void OnLanguageChanged()
        {
            lbName.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_MainOutput_SingleDisplayConfigUi_lbName", "名称:");
            lb_Index.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_MainOutput_SingleDisplayConfigUi_lbIndex", "序号:");
            chkEnable.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_MainOutput_SingleDisplayConfigUi_chkEnable", "使能");

            btnRefreshPrims.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_MainOutput_SingleDisplayConfigUi_RefreshPrims", "基元刷新");
            lb_RowNum.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_MainOutput_SingleDisplayConfigUi_RowNum", "行数:");
            lb_ColumnNum.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_MainOutput_SingleDisplayConfigUi_ColumnNum", "列数:");
            btnApply.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_MainOutput_SingleDisplayConfigUi_Apply", "应用");

            dgvDisplayConfig.Columns["colPrimName"].HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_MainOutput_SingleDisplayConfigUi_colPrimName", "名称");
            dgvDisplayConfig.Columns["colEnable"].HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_MainOutput_SingleDisplayConfigUi_colEnable", "使能");
            dgvDisplayConfig.Columns["colRowNum"].HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_MainOutput_SingleDisplayConfigUi_colRowNum", "行号");
            dgvDisplayConfig.Columns["colColumnNum"].HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_MainOutput_SingleDisplayConfigUi_colColumnNum", "列号");
            dgvDisplayConfig.Columns["colRowSpanNum"].HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_MainOutput_SingleDisplayConfigUi_colRowSpanNum", "跨行");
            dgvDisplayConfig.Columns["colColumnSpanNum"].HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_MainOutput_SingleDisplayConfigUi_colColumnSpanNum", "跨列");
        }







        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private IContainer components = null;

		private TableLayoutPanel tableLayoutPanel1;

		private Panel panel1;

		private TextBox tbColCount;

		private Label lb_ColumnNum;

		private TextBox tbRowCount;

		private Label lb_RowNum;

		private CheckBox chkEnable;

		private TextBox tbName;

		private Label lbName;

		private Button btnRemoveRow;

		private Button btnAddRow;

		private Button btnApply;

		private Button btnRefreshPrims;

		private TextBox tbIndex;

		private Label lb_Index;

		private DataGridView dgvDisplayConfig;

		private DataGridViewComboBoxColumn colPrimName;

		private DataGridViewCheckBoxColumn colEnable;

		private DataGridViewTextBoxColumn colRowNum;

		private DataGridViewTextBoxColumn colColumnNum;

		private DataGridViewTextBoxColumn colRowSpanNum;

		private DataGridViewTextBoxColumn colColumnSpanNum;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbIndex = new System.Windows.Forms.TextBox();
            this.lb_Index = new System.Windows.Forms.Label();
            this.btnRefreshPrims = new System.Windows.Forms.Button();
            this.tbColCount = new System.Windows.Forms.TextBox();
            this.lb_ColumnNum = new System.Windows.Forms.Label();
            this.tbRowCount = new System.Windows.Forms.TextBox();
            this.lb_RowNum = new System.Windows.Forms.Label();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.dgvDisplayConfig = new System.Windows.Forms.DataGridView();
            this.colPrimName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRowNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColumnNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRowSpanNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColumnSpanNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplayConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvDisplayConfig, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.75817F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.24183F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(680, 382);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbIndex);
            this.panel1.Controls.Add(this.lb_Index);
            this.panel1.Controls.Add(this.btnRefreshPrims);
            this.panel1.Controls.Add(this.tbColCount);
            this.panel1.Controls.Add(this.lb_ColumnNum);
            this.panel1.Controls.Add(this.tbRowCount);
            this.panel1.Controls.Add(this.lb_RowNum);
            this.panel1.Controls.Add(this.chkEnable);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Controls.Add(this.btnRemoveRow);
            this.panel1.Controls.Add(this.btnAddRow);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(672, 101);
            this.panel1.TabIndex = 2;
            // 
            // tbIndex
            // 
            this.tbIndex.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.tbIndex.Location = new System.Drawing.Point(291, 9);
            this.tbIndex.Margin = new System.Windows.Forms.Padding(4);
            this.tbIndex.Name = "tbIndex";
            this.tbIndex.Size = new System.Drawing.Size(101, 24);
            this.tbIndex.TabIndex = 77;
            // 
            // lb_Index
            // 
            this.lb_Index.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Index.Location = new System.Drawing.Point(203, 9);
            this.lb_Index.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Index.Name = "lb_Index";
            this.lb_Index.Size = new System.Drawing.Size(80, 25);
            this.lb_Index.TabIndex = 76;
            this.lb_Index.Text = "序号：";
            // 
            // btnRefreshPrims
            // 
            this.btnRefreshPrims.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshPrims.BackColor = System.Drawing.Color.Khaki;
            this.btnRefreshPrims.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefreshPrims.Location = new System.Drawing.Point(536, 3);
            this.btnRefreshPrims.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefreshPrims.Name = "btnRefreshPrims";
            this.btnRefreshPrims.Size = new System.Drawing.Size(132, 36);
            this.btnRefreshPrims.TabIndex = 75;
            this.btnRefreshPrims.Text = "基元刷新";
            this.btnRefreshPrims.UseVisualStyleBackColor = false;
            this.btnRefreshPrims.Click += new System.EventHandler(this.btnRefreshPrims_Click);
            // 
            // tbColCount
            // 
            this.tbColCount.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.tbColCount.Location = new System.Drawing.Point(255, 51);
            this.tbColCount.Margin = new System.Windows.Forms.Padding(4);
            this.tbColCount.Name = "tbColCount";
            this.tbColCount.Size = new System.Drawing.Size(48, 24);
            this.tbColCount.TabIndex = 74;
            // 
            // lb_ColumnNum
            // 
            this.lb_ColumnNum.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_ColumnNum.Location = new System.Drawing.Point(167, 51);
            this.lb_ColumnNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ColumnNum.Name = "lb_ColumnNum";
            this.lb_ColumnNum.Size = new System.Drawing.Size(80, 25);
            this.lb_ColumnNum.TabIndex = 73;
            this.lb_ColumnNum.Text = "列数：";
            // 
            // tbRowCount
            // 
            this.tbRowCount.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.tbRowCount.Location = new System.Drawing.Point(92, 51);
            this.tbRowCount.Margin = new System.Windows.Forms.Padding(4);
            this.tbRowCount.Name = "tbRowCount";
            this.tbRowCount.Size = new System.Drawing.Size(48, 24);
            this.tbRowCount.TabIndex = 72;
            // 
            // lb_RowNum
            // 
            this.lb_RowNum.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_RowNum.Location = new System.Drawing.Point(4, 51);
            this.lb_RowNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_RowNum.Name = "lb_RowNum";
            this.lb_RowNum.Size = new System.Drawing.Size(80, 25);
            this.lb_RowNum.TabIndex = 71;
            this.lb_RowNum.Text = "行数：";
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkEnable.Location = new System.Drawing.Point(416, 9);
            this.chkEnable.Margin = new System.Windows.Forms.Padding(4);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(61, 24);
            this.chkEnable.TabIndex = 70;
            this.chkEnable.Text = "使能";
            this.chkEnable.UseVisualStyleBackColor = true;
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.tbName.Location = new System.Drawing.Point(92, 9);
            this.tbName.Margin = new System.Windows.Forms.Padding(4);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(101, 24);
            this.tbName.TabIndex = 69;
            // 
            // lbName
            // 
            this.lbName.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbName.Location = new System.Drawing.Point(4, 9);
            this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(80, 25);
            this.lbName.TabIndex = 68;
            this.lbName.Text = "名称：";
            this.lbName.DoubleClick += new System.EventHandler(this.lbName_DoubleClick);
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveRow.BackColor = System.Drawing.Color.Red;
            this.btnRemoveRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRemoveRow.Location = new System.Drawing.Point(459, 45);
            this.btnRemoveRow.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(63, 36);
            this.btnRemoveRow.TabIndex = 67;
            this.btnRemoveRow.Text = "-";
            this.btnRemoveRow.UseVisualStyleBackColor = false;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRow.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAddRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddRow.Location = new System.Drawing.Point(376, 45);
            this.btnAddRow.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(63, 36);
            this.btnAddRow.TabIndex = 66;
            this.btnAddRow.Text = "+";
            this.btnAddRow.UseVisualStyleBackColor = false;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BackColor = System.Drawing.Color.LimeGreen;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(536, 45);
            this.btnApply.Margin = new System.Windows.Forms.Padding(4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(132, 36);
            this.btnApply.TabIndex = 65;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // dgvDisplayConfig
            // 
            this.dgvDisplayConfig.AllowUserToAddRows = false;
            this.dgvDisplayConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisplayConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPrimName,
            this.colEnable,
            this.colRowNum,
            this.colColumnNum,
            this.colRowSpanNum,
            this.colColumnSpanNum});
            this.dgvDisplayConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDisplayConfig.Location = new System.Drawing.Point(4, 113);
            this.dgvDisplayConfig.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDisplayConfig.Name = "dgvDisplayConfig";
            this.dgvDisplayConfig.RowHeadersWidth = 51;
            this.dgvDisplayConfig.RowTemplate.Height = 23;
            this.dgvDisplayConfig.Size = new System.Drawing.Size(672, 265);
            this.dgvDisplayConfig.TabIndex = 3;
            // 
            // colPrimName
            // 
            this.colPrimName.HeaderText = "名称";
            this.colPrimName.MinimumWidth = 6;
            this.colPrimName.Name = "colPrimName";
            this.colPrimName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPrimName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colPrimName.Width = 125;
            // 
            // colEnable
            // 
            this.colEnable.HeaderText = "使能";
            this.colEnable.MinimumWidth = 6;
            this.colEnable.Name = "colEnable";
            this.colEnable.Width = 50;
            // 
            // colRowNum
            // 
            this.colRowNum.HeaderText = "行号";
            this.colRowNum.MinimumWidth = 6;
            this.colRowNum.Name = "colRowNum";
            this.colRowNum.Width = 60;
            // 
            // colColumnNum
            // 
            this.colColumnNum.HeaderText = "列号";
            this.colColumnNum.MinimumWidth = 6;
            this.colColumnNum.Name = "colColumnNum";
            this.colColumnNum.Width = 60;
            // 
            // colRowSpanNum
            // 
            this.colRowSpanNum.HeaderText = "跨行";
            this.colRowSpanNum.MinimumWidth = 6;
            this.colRowSpanNum.Name = "colRowSpanNum";
            this.colRowSpanNum.Width = 60;
            // 
            // colColumnSpanNum
            // 
            this.colColumnSpanNum.HeaderText = "跨列";
            this.colColumnSpanNum.MinimumWidth = 6;
            this.colColumnSpanNum.Name = "colColumnSpanNum";
            this.colColumnSpanNum.Width = 60;
            // 
            // SingleDisplayConfigUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SingleDisplayConfigUi";
            this.Size = new System.Drawing.Size(680, 382);
            this.Load += new System.EventHandler(this.DisplayConfigUi_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplayConfig)).EndInit();
            this.ResumeLayout(false);

		}
	}
}
