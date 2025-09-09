using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Lead.CPrim.CmpTrigHelper.CmpTrigUIs;

namespace Lead.CPrim.CmpTrigHelper
{
    public partial class TriggerTable : UserControl
    {
        #region Field
        private TriggerTableData _tableTrigData;
        #endregion



        #region Ctor
        public TriggerTable()
        {
            InitializeComponent();

            tlpMain.SetDoubleBuffered();
            pnlTitle.SetDoubleBuffered();
            dgvPos.SetDoubleBuffered();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        public TriggerTable(TriggerTableData tableTrigData) : this()
        {
            _tableTrigData = tableTrigData;
        }
        #endregion



        #region Event_System

        private void TrigTableControl_Load(object sender, EventArgs e)
        {
            DgvTableTrigInit();
            TbCmbInit(_tableTrigData);
        }

        private void tbTrigTrigId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void dgTableTrig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                dgvPos.Copy();
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                //ControlHelper.DgvPaste(ref dgvTrig);
            }
        }

        public void OnLanguageChanged()
        {
            lblName.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TableTrigConfigControl_TrigName", "名称:");
            lblNum.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TableTrigConfigControl_Count", "数量:");
            lblStart.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TableTrigConfigControl_StartPos", "起点:");
            lblInterval.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TableTrigConfigControl_Interval", "间隔:");
            lblEnd.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TableTrigConfigControl_EndPos", "终点:");
            lblDelayTime.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TableTrigConfigControl_DelayTime", "延迟时间:");
            lblDelayVelocity.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TableTrigConfigControl_DelayVelocity", "延迟速度:");
            lblAgl.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TableTrigConfigControl_AglSel", "算法");
            lblProduct.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TableTrigConfigControl_Production", "产品:");
            btnClr.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TableTrigConfigControl_Clear", "清空");
            btnCreate.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TableTrigConfigControl_Create", "生成");
            btnApply.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TableTrigConfigControl_Apply", "应用");
        }
        #endregion



        #region Event_Button
        /// <summary>
        /// 选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblName_DoubleClick(object sender, EventArgs e)
        {
            _tableTrigData.IsSelected = !_tableTrigData.IsSelected;
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            dgvPos.Rows.Add();
            RefreshUi();
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            for (int num = dgvPos.SelectedRows.Count; num > 0; num--)
            {
                if (!dgvPos.SelectedRows[0].IsNewRow)
                {
                    dgvPos.Rows.RemoveAt(dgvPos.SelectedRows[0].Index);
                }
            }
            RefreshUi();
        }

        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClr_Click(object sender, EventArgs e)
        {
            dgvPos.Rows.Clear();
        }

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreat_Click(object sender, EventArgs e)
        {
            double start = Convert.ToDouble(txtStart.Text);
            double end = Convert.ToDouble(txtEnd.Text);
            double interval = Convert.ToDouble(txtInterval.Text);

            //判断间隔正负
            if (start > end)
            {
                interval = 0.0 - Math.Abs(interval);
            }

            if (_tableTrigData.TrigPoints == null)
            {
                _tableTrigData.TrigPoints = new SortedList<int, double>();
            }

            _tableTrigData.TrigPoints.Clear();
            int i = 0;
            if (interval > 0.0)
            {
                while (true)
                {
                    double p = start + interval * i;
                    if (p > end)
                    {
                        break;
                    }

                    _tableTrigData.TrigPoints.Add(++i, p);
                }
            }
            else
            {
                while (true)
                {
                    double p = start + interval * i;
                    if (p < end)
                    {
                        break;
                    }

                    _tableTrigData.TrigPoints.Add(++i, p);
                }
            }

            dgFill();
            RefreshUi();
        }

        /// <summary>
        /// 应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.IsNullOrWhiteSpace())
                {
                    throw new Exception(lblName.Text + NLocalizer.ValueInvalid);
                }

                if (txtId.Text.IsNullOrWhiteSpace())
                {
                    throw new Exception(lblId.Text + NLocalizer.ValueInvalid);
                }

                _tableTrigData.Name = txtName.Text;
                _tableTrigData.Id = txtId.Text.ToInt(-1);
                _tableTrigData.StartPos = txtStart.Text.ToDouble();
                _tableTrigData.Gap = txtInterval.Text.ToDouble();
                _tableTrigData.EndPos = txtEnd.Text.ToDouble();
                _tableTrigData.productID = cmbProduct.Text.ToInt(-1);
                _tableTrigData.DelayTime = txtDelayTime.Text.ToDouble();
                _tableTrigData.DelayVelocity = txtDelayVelocity.Text.ToDouble();
                DgvTransData(ref _tableTrigData);

                TriggerManager.Instance.LogAdd(NLocalizer.ApplySuccess, LogLevel.Trace);
            }
            catch (Exception ex)
            {
                TriggerManager.Instance.LogAdd($"{NLocalizer.ApplyError}：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }

        /// <summary>
        /// 加载算法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labAglSel_DoubleClick(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            List<string> agls = new List<string>();
            var prims = PrimsManagerTransfer.GetAllIPrim();
            if (prims.IsNullOrEmpty())
            {
                return;
            }

            prims.ForEach(delegate (IPrim prim)
            {
                if (prim is I3DAgl)
                {
                    agls.Add(prim.Name);
                }
            });

            if (_tableTrigData.AglList == null)
            {
                _tableTrigData.AglList = new List<string>();
            }

            list = _tableTrigData.AglList;
            if (agls.Count > 0)
            {
                AglSelForm aglSelForm = new AglSelForm(agls, ref list);
                aglSelForm.ShowDialog();
            }

            RefreshUi();
        }
        #endregion



        #region Method_ExternalUsing
        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// 初始化
        /// </summary>
        private void DgvTableTrigInit()
        {
            if (_tableTrigData != null && _tableTrigData.TrigPoints.Count > 0)
            {
                DgvFillData(_tableTrigData);
            }
        }

        /// <summary>
        /// DGV填充
        /// </summary>
        /// <param name="tableTrigData"></param>
        private void DgvFillData(TriggerTableData tableTrigData)
        {
            dgvPos.Rows.Clear();
            dgvPos.Rows.Add(tableTrigData.TrigPoints.Count);
            int num = 0;
            foreach (KeyValuePair<int, double> trigPoint in tableTrigData.TrigPoints)
            {
                dgvPos.Rows[num].Cells[0].Value = trigPoint.Key;
                dgvPos.Rows[num].Cells[1].Value = trigPoint.Value;
                num++;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="tableTrigData"></param>
        private void TbCmbInit(TriggerTableData tableTrigData)
        {
            txtName.Text = _tableTrigData.Name;
            txtId.Text = _tableTrigData.Id.ToString();
            txtNum.Text = _tableTrigData.TrigPoints.Count.ToString();
            txtStart.Text = _tableTrigData.StartPos.ToString();
            txtInterval.Text = _tableTrigData.Gap.ToString();
            txtEnd.Text = _tableTrigData.EndPos.ToString();
            txtDelayTime.Text = _tableTrigData.DelayTime.ToString();
            txtDelayVelocity.Text = _tableTrigData.DelayVelocity.ToString();
            RefreshUi();
        }

        /// <summary>
        /// UI刷新
        /// </summary>
        private void RefreshUi()
        {
            for (int i = 0; i < dgvPos.Rows.Count; i++)
            {
                dgvPos.Rows[i].Cells[0].Value = i + 1;
            }

            //总数
            txtNum.Text = dgvPos.Rows.Count.ToString();

            //算法
            string aglsStr = "";
            _tableTrigData.AglList.ForEach(delegate (string p)
            {
                aglsStr = aglsStr + p + "; ";
            });
            txtAgl.Text = aglsStr;

            //ID
            cmbProduct.SelectedIndex = ((_tableTrigData.productID != -1) ? _tableTrigData.productID : 0);
        }

        /// <summary>
        /// 表格填充
        /// </summary>
        private void dgFill()
        {
            if (_tableTrigData.TrigPoints.Count > 0)
            {
                dgvPos.Rows.Clear();
                for (int i = 0; i < _tableTrigData.TrigPoints.Count; i++)
                {
                    dgvPos.Rows.Insert(i);
                    dgvPos.Rows[i].Cells[0].Value = i + 1;
                    dgvPos.Rows[i].Cells[1].Value = _tableTrigData.TrigPoints[i + 1];
                }
            }
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="tableTrigData"></param>
        private void DgvTransData(ref TriggerTableData tableTrigData)
        {
            tableTrigData.TrigPoints.Clear();
            for (int i = 0; i < dgvPos.Rows.Count; i++)
            {
                int key = int.Parse(dgvPos.Rows[i].Cells[0].Value?.ToString() ?? "-1");
                tableTrigData.TrigPoints[key] = Convert.ToDouble(dgvPos.Rows[i].Cells[1].Value?.ToString() ?? "-1");
            }
        }
        #endregion
    }
}