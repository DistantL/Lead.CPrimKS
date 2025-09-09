using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lead.CPrim.WorkPlan.Controls
{
    public partial class ShowOutputControl : UserControl
    {
        #region Field
        /// <summary>压力曲线配置管理器</summary>
        public ShowWorkPlan _show;
        /// <summary>工单记录表管理器</summary>
        public WorkPlanDatas _datas;
        /// <summary>DataGridView行风格</summary>
        DataGridViewCellStyle styleGreen = new DataGridViewCellStyle { BackColor = Color.Green };
        #endregion



        #region Ctor
        /// <summary>Ctro无参</summary>
        public ShowOutputControl()
        {
            InitializeComponent();

            if(_datas == null)
            {
                _datas = new WorkPlanDatas();
                _datas.ListWorkPlan = new List<ShowWorkPlanConfig>();
            }

            dgvWorkSheet.SetDoubleBuffered();
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="show"></param>
        public ShowOutputControl(ShowWorkPlan show)
        {
            InitializeComponent();
            _show = show;

            if(!string.IsNullOrEmpty(_show.ConfigPath))
            {
                _datas = ProxyTools.XmlSerializerHelper.ReadXML(_show.ConfigPath, typeof(WorkPlanDatas)) as WorkPlanDatas;
            }
            if (_datas == null)
            {
                _datas = new WorkPlanDatas();
                _datas.ListWorkPlan = new List<ShowWorkPlanConfig>();
            }
            else
            {
                _show.WorkSheetId = _datas.WorkSheetId;
                _show.WorkSheetPSASN = _datas.WorkSheetPSASN;
                _show.WorkSheetCount = _datas.WorkSheetCount;
            }

            dgvWorkSheet.SetDoubleBuffered();
        }

        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void ShowOutputControl_Load(object sender, EventArgs e)
        {
            tbWorkSheetId.Text = _show.WorkSheetId;
            tbWorkSheetPSASN.Text = _show.WorkSheetPSASN;
            tbWorkSheetCount.Text = _show.WorkSheetCount.ToString();

            foreach (var item in _datas.ListWorkPlan.OrderByDescending(w => w.CreateTime))
            {
                DatasToDgv(item);
            }
        }
        #endregion



        #region Button_Event
        /// <summary>单击单元格内容时发生</summary>
        private void dgvWorkSheet_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

        }
        /// <summary>启用工单</summary>
        private void btnStartWorkSheet_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox[] _box = new TextBox[] { tbWorkSheetId, tbWorkSheetPSASN, tbWorkSheetCount };
                if (_box.Any(t => string.IsNullOrEmpty(t.Text.Trim())))
                {
                    throw new Exception("工单号/PSASN/当前工单数量不可以为空，请检查");
                }

                int tempCount = 0;
                if(!int.TryParse(tbWorkSheetCount.Text.Trim(), out tempCount))
                {
                    throw new Exception("当前工单数量输入格式有误，请重新输入");
                }
                if(tempCount <= 0)
                {
                    throw new Exception("当前工单数量 <= 0，请重新输入");
                }

                _show.WorkSheetId = tbWorkSheetId.Text.Trim();
                _show.WorkSheetPSASN = tbWorkSheetPSASN.Text.Trim();
                _show.WorkSheetCount = tempCount;

                if (dgvWorkSheet.Rows.Count >= 0)
                {
                    for (int i = 0; i < dgvWorkSheet.Rows.Count; i++)
                    {
                        if (dgvWorkSheet.Rows[i].Cells[1].Value.ToString() == _show.WorkSheetId)
                        {
                            throw new Exception("工单号不允许重复");
                        }
                    }
                }

                _datas.WorkSheetId = _show.WorkSheetId;
                _datas.WorkSheetPSASN = _show.WorkSheetPSASN;
                _datas.WorkSheetCount = _show.WorkSheetCount;

                ShowWorkPlanConfig temp = new ShowWorkPlanConfig();
                temp.CreateTime = DateTime.Now;
                temp.WorkSheetId = _show.WorkSheetId;
                temp.WorkSheetPSASN = _show.WorkSheetPSASN;
                temp.WorkSheetCount = _show.WorkSheetCount;
                temp.CountOK = 0;
                temp.CountNG = 0;
                temp.ReMark = "进行中";
                _datas.ListWorkPlan.Add(temp);
                SaveWorkPlan();

                DgvInsertData(temp);
            }
            catch (Exception ex)
            {
                Notification.ShowError("启用工单失败：" + ex.ToString());
            }
        }
        /// <summary>导出</summary>
        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string errorText = "";
            if(!ControlHelper.SaveDgvDataToCsvFile(dgvWorkSheet, true, ref errorText))
            {
                Notification.ShowError("导出失败：" + errorText);
            }
        }
        /// <summary>删除选中行</summary>
        private void 删除选中行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rows = dgvWorkSheet.SelectedRows;
            if(rows.Count == 0)
            {
                return;
            }
            foreach (DataGridViewRow item in rows)
            {
                _datas.ListWorkPlan.RemoveAll((ShowWorkPlanConfig w) => w.WorkSheetId == item.Cells[1].Value.ToString());
                dgvWorkSheet.Rows.Remove(item);
            }
            SaveWorkPlan();
        }
        /// <summary>删除所有</summary>
        private void 删除所有ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvWorkSheet.Rows.Clear();
            dgvWorkSheet.DataSource = null;

            _datas.ListWorkPlan.Clear();
            SaveWorkPlan();
        }
        #endregion



        #region Others
        /// <summary>工单记录表插入数据</summary>
        private void DgvInsertData(ShowWorkPlanConfig config)
        {
            dgvWorkSheet.Rows.Insert(0, config.CreateTime, config.WorkSheetId, config.WorkSheetPSASN, config.WorkSheetCount, config.CountOK, config.CountNG, config.ReMark);
        }
        /// <summary>工单记录表保存到本地</summary>
        private void SaveWorkPlan()
        {
            ProxyTools.XmlSerializerHelper.WriteXML(_datas, _show.ConfigPath, typeof(WorkPlanDatas));
        }
        /// <summary>数据插入到工单记录表</summary>
        /// <param name="config">工单记录表配置</param>
        private void DatasToDgv(ShowWorkPlanConfig config)
        {
            int index = dgvWorkSheet.Rows.Add();
            dgvWorkSheet.Rows[index].Cells[0].Value = config.CreateTime;
            dgvWorkSheet.Rows[index].Cells[1].Value = config.WorkSheetId;
            dgvWorkSheet.Rows[index].Cells[2].Value = config.WorkSheetPSASN;
            dgvWorkSheet.Rows[index].Cells[3].Value = config.WorkSheetCount;
            dgvWorkSheet.Rows[index].Cells[4].Value = config.CountOK;
            dgvWorkSheet.Rows[index].Cells[5].Value = config.CountNG;
            dgvWorkSheet.Rows[index].Cells[6].Value = config.ReMark;

            if(config.ReMark == "已完成")
            {
                dgvWorkSheet.Rows[index].DefaultCellStyle = styleGreen;
            }
        }
        /// <summary>OK加一</summary>
        public void OKIncrease()
        {
            try
            {
                if (string.IsNullOrEmpty(_show.WorkSheetId))
                {
                    return;
                }

                var l = _datas.ListWorkPlan.FirstOrDefault(w => w.WorkSheetId == _show.WorkSheetId);
                if (l == null)
                {
                    return;
                }
                l.CountOK++;

                foreach (DataGridViewRow item in dgvWorkSheet.Rows)
                {
                    if (item.Cells[1].Value.ToString() == _show.WorkSheetId)
                    {
                        int tempInt = int.Parse(item.Cells[4].Value.ToString());
                        item.Cells[4].Value = ++tempInt;



                        if (int.Parse(item.Cells[4].Value.ToString()) + int.Parse(item.Cells[5].Value.ToString()) >= _show.WorkSheetCount)
                        {
                            item.Cells[6].Value = "已完成";
                            l.ReMark = "已完成";
                            _show.WorkSheetId = "";
                            _show.WorkSheetPSASN = "";
                            _show.WorkSheetCount = 0;
                            _datas.WorkSheetId = "";
                            _datas.WorkSheetPSASN = "";
                            _datas.WorkSheetCount = 0;
                            item.DefaultCellStyle = styleGreen;
                        }
                    }
                }

                dgvWorkSheet.Refresh();
                SaveWorkPlan();
            }
            catch
            {

            }
        }
        /// <summary>NG加一</summary>
        public void NGIncrease()
        {
            try
            {
                if (string.IsNullOrEmpty(_show.WorkSheetId))
                {
                    return;
                }

                var l = _datas.ListWorkPlan.FirstOrDefault(w => w.WorkSheetId == _show.WorkSheetId);
                if (l == null)
                {
                    return;
                }
                l.CountNG++;

                foreach (DataGridViewRow item in dgvWorkSheet.Rows)
                {
                    if (item.Cells[1].Value.ToString() == _show.WorkSheetId)
                    {
                        int tempInt = int.Parse(item.Cells[5].Value.ToString());
                        item.Cells[5].Value = ++tempInt;


                        if (int.Parse(item.Cells[4].Value.ToString()) + int.Parse(item.Cells[5].Value.ToString()) >= _show.WorkSheetCount)
                        {
                            item.Cells[6].Value = "已完成";
                            l.ReMark = "已完成";
                            _show.WorkSheetId = "";
                            _show.WorkSheetPSASN = "";
                            _show.WorkSheetCount = 0;
                            _datas.WorkSheetId = "";
                            _datas.WorkSheetPSASN = "";
                            _datas.WorkSheetCount = 0;
                            item.DefaultCellStyle = styleGreen;
                        }
                    }
                }

                dgvWorkSheet.Refresh();
                SaveWorkPlan();
            }
            catch
            {

            }
        }
        #endregion
    }
}
