using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.ShowErrorCode.Controls
{
    /// <summary>输出UI</summary>
    public partial class ShowOutputControl : UserControl
    {
        #region Field
        /// <summary>AQCI管理器</summary>
        private readonly ShowErrorCode _show;
        /// <summary>导出表头</summary>
        private string[] head = new string[] { "vendor_name", "first_level_code", "first_level_name_en", "first_level_name_cn", "second_level_code", "second_level_name_en", "second_level_name_cn", "vendor_code", "third_level_code", "third_level_name_en", "third_level_name_cn", "station_code", "module_code", "module_name_en", "module_name_cn", "error_code", "module_code", "trace_process_name" };
        #endregion



        #region Ctor
        /// <summary>Ctor有1个参数</summary>
        /// <param name="show">AQCI管理器</param>
        public ShowOutputControl(ShowErrorCode show)
        {
            InitializeComponent();
            _show = show;

            dgvErrorCode.SetDoubleBuffered();
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void ShowOutputControl_Load(object sender, EventArgs e)
        {
            _show.ErrorCodeOutput(false);

            foreach (var item in head)
            {
                DataGridViewColumn dataGridViewColumn = new DataGridViewTextBoxColumn();
                dataGridViewColumn.HeaderText = item;
                dataGridViewColumn.DataPropertyName = item;
                dataGridViewColumn.Name = item;
                dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvErrorCode.Columns.Add(dataGridViewColumn);
            }
            DgvShow(_show.lerrcodeInfor);
        }
        #endregion

        

        private void DgvShow(List<ErrcodeInfor> data)
        {
            #region 注释
            foreach (var item in data)
            {
                int index = dgvErrorCode.Rows.Add();

                dgvErrorCode.Rows[index].Cells[0].Value = item.vendor_name;
                dgvErrorCode.Rows[index].Cells[1].Value = item.first_level_code;
                dgvErrorCode.Rows[index].Cells[2].Value = item.first_level_name_en;
                dgvErrorCode.Rows[index].Cells[3].Value = item.first_level_name_cn;
                dgvErrorCode.Rows[index].Cells[4].Value = item.second_level_code;
                dgvErrorCode.Rows[index].Cells[5].Value = item.second_level_name_en;
                dgvErrorCode.Rows[index].Cells[6].Value = item.second_level_name_cn;
                dgvErrorCode.Rows[index].Cells[7].Value = item.vendor_code;
                dgvErrorCode.Rows[index].Cells[8].Value = item.third_level_code;
                dgvErrorCode.Rows[index].Cells[9].Value = item.third_level_name_en;
                dgvErrorCode.Rows[index].Cells[10].Value = item.third_level_name_cn;
                dgvErrorCode.Rows[index].Cells[11].Value = item.station_code;
                dgvErrorCode.Rows[index].Cells[12].Value = item.module_code;
                dgvErrorCode.Rows[index].Cells[13].Value = item.module_name_en;
                dgvErrorCode.Rows[index].Cells[14].Value = item.module_name_cn;
                dgvErrorCode.Rows[index].Cells[15].Value = item.error_codes;
                dgvErrorCode.Rows[index].Cells[16].Value = item.module_codes;
            }
            #endregion
        }

        private void 重新加载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvErrorCode.Rows.Clear();

            _show.ErrorCodeOutput(false);

            DgvShow(_show.lerrcodeInfor);
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string error = "";
            if (!ControlHelper.SaveDgvDataToCsvFile(dgvErrorCode, true, ref error))
            {
                //ProxyTools.ProxyTools.ShowUINotifier(Interfaces.UINotifierE.Error, "导出失败 => " + error, "导出");
            }
        }
    }
}