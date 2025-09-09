using Lead.CPrim.CmpTrigHelper.ConfigClass;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces.StateMachine;
using Lead.CPrim.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.CmpTrigHelper.CmpTrigUIs;
using System.Collections.Concurrent;
using System.Drawing;

namespace Lead.CPrim.CmpTrigHelper
{
    public partial class TriggerTrack : UserControl
    {
        #region Field

        private IEleAxis _axis;

        private IEle _ele;

        private TriggerTrackData _trajData;
        #endregion



        #region Ctor

        public TriggerTrack()
        {
            InitializeComponent();

            BackColor = Colors.PrimaryBackColor236;
            pnlTitle.BackColor = Color.Transparent;

            tlpMain.SetDoubleBuffered();
            pnlTitle.SetDoubleBuffered();
            dgvTrack.SetDoubleBuffered();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }

        public TriggerTrack(TriggerTrackData trajData) : this()
        {
            _trajData = trajData;
        }
        #endregion



        #region Event_System

        private void TrajConfigControl_Load(object sender, EventArgs e)
        {
            TbCmbInit(_trajData);
            FindEleAndAxis(_trajData.EleName, _trajData.TrigAxisName);
            DgvTrajInit();
        }

        private void tbTrajId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void dgTraj_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            int eRow = e.RowIndex;
            if (columnIndex == 7 && _ele != null && (int)_ele.EleRunStat == 1)
            {
                Action action = delegate
                {
                    MessageBox.Show((((IEleCartesian)_ele).GroupMoveAbs(_trajData.Poses[eRow].Pos, _trajData.Poses[eRow].Vel, 100, -1, false, true, (ITask)null
                        , (EleAlarmLevel)2) == 0)
                        ? (_ele.Name + NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrajConfigControl_MoveTo", " 移动至 ") + ((object)_trajData.Poses[eRow].Pos).ToString()
                        + NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrajConfigControl_Success", " 成功。"))
                        : (_ele.Name + NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrajConfigControl_MoveTo", " 移动至 ") + ((object)_trajData.Poses[eRow].Pos).ToString()
                        + NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrajConfigControl_Failure", " 失败。")));
                };
                action.BeginInvoke(null, null);
            }
        }

        public void OnLanguageChanged()
        {
            lblTrigName.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrajConfigControl_TrigName", "轨迹名称:");
            lblElement.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrajConfigControl_Element", "元件关联:");
            lblAxisName.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrajConfigControl_AxisIndex", "轴名称:");
            btnTeach.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrajConfigControl_Teach", "示教");
            btnApply.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrajConfigControl_Apply", "应用");
            dgvTrack.Columns["colPosType"].HeaderText = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrajConfigControl_colPosType", "点位类型");
            dgvTrack.Columns["colTest"].HeaderText = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrajConfigControl_colTest", "测试移动");
        }
        #endregion



        #region Event_Button
        /// <summary>
        /// 双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblTrigName_DoubleClick(object sender, EventArgs e)
        {
            _trajData.IsSelected = !_trajData.IsSelected;
        }

        /// <summary>
        /// 元件关联
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbElement_Click(object sender, EventArgs e)
        {
            UpdateEles();
        }

        /// <summary>
        /// 元件关联
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbElementName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = cmbElementName.SelectedItem?.ToString();
            if (name.IsNullOrEmpty())
            {
                return;
            }

            _ele = ElesManagerTransfer.GetEleByName(name);
            UpdateAxises();
        }

        /// <summary>
        /// 轴名称获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbAxisName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = cmbAxisName.SelectedItem?.ToString();
            if (name.IsNullOrEmpty())
            {
                return;
            }

            _trajData.TrigAxisName = name;
            _axis = ((IEleCartesian)_ele).Axises.FirstOrDefault((KeyValuePair<int, IEleAxis> p) => p.Value.Name == name).Value;
        }

        /// <summary>
        /// 示教
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTeach_Click(object sender, EventArgs e)
        {
            if (_ele == null)
            {
                return;
            }

            if (_axis == null)
            {
                return;
            }

            List<Pos> list = new List<Pos>();
            for (int i = 0; i < _trajData.Poses.Count; i++)
            {
                list.Add(_trajData.Poses[i].Pos);
            }

            ManualDebug manual = new ManualDebug((IEleCartesian)_ele, list);
            manual.StartPosition = FormStartPosition.CenterParent;
            if (manual.ShowDialog() == DialogResult.OK)
            {
                var poss = manual.GetPoss();

                if (poss.IsNullOrEmpty())
                {
                    return;
                }

                foreach (DataGridViewRow row in dgvTrack.Rows)
                {
                    string name = row.Cells[0].Value?.ToString();
                    if (name.IsNullOrWhiteSpace())
                    {
                        continue;
                    }

                    var pos1 = poss.FirstOrDefault(p => p.Name == name);
                    if (pos1 == null)
                    {
                        continue;
                    }

                    row.Cells[1].Value = pos1.X;
                    row.Cells[2].Value = pos1.Y;
                    row.Cells[3].Value = pos1.Z;
                    row.Cells[4].Value = pos1.U;
                    row.Cells[5].Value = pos1.V;
                    row.Cells[6].Value = pos1.W;
                }
            }
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
                if (txtTrackName.Text.IsNullOrWhiteSpace())
                {
                    throw new Exception($"{lblTrigName.Text}：{NLocalizer.ValueInvalid}");
                }

                if (txtId.Text.IsNullOrWhiteSpace())
                {
                    throw new Exception($"{lblId.Text}：{NLocalizer.ValueInvalid}");
                }

                _trajData.Name = txtTrackName.Text;
                _trajData.Id = int.Parse(txtId.Text);
                _trajData.EleName = cmbElementName.SelectedItem?.ToString();
                _trajData.TrigAxisName = cmbAxisName.SelectedItem?.ToString();
                cmbAxisName_SelectedIndexChanged(null, null);
                DgvTransData(ref _trajData);

                TriggerManager.Instance.LogAdd(NLocalizer.ApplySuccess, LogLevel.Trace);
            }
            catch (Exception ex)
            {
                TriggerManager.Instance.LogAdd($"{NLocalizer.ApplyError}：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// Load_1<br/>
        /// 
        /// </summary>
        /// <param name="trajData"></param>
        private void TbCmbInit(TriggerTrackData trajData)
        {
            UpdateEles();
            txtTrackName.Text = trajData.Name;
            txtId.Text = trajData.Id.ToString();
        }

        /// <summary>
        /// Load_2<br/>
        /// 获取元件、轴
        /// </summary>
        /// <param name="eleName"></param>
        /// <param name="axisName"></param>
        private void FindEleAndAxis(string eleName, string axisName)
        {
            if (string.IsNullOrEmpty(eleName))
            {
                return;
            }

            if (!cmbElementName.Items.Contains(eleName))
            {
                cmbElementName.Items.Add(eleName);
            }
            cmbElementName.SelectedItem = eleName;

            _ele = ElesManagerTransfer.GetEleByName(_trajData.EleName);
            if (_ele == null)
            {
                return;
            }

            UpdateAxises();
            if (!string.IsNullOrEmpty(axisName))
            {
                if (!cmbAxisName.Items.Contains(axisName))
                {
                    cmbAxisName.Items.Add(axisName);
                }
                cmbAxisName.SelectedItem = axisName;
                _axis = ((IEleCartesian)_ele).GetAxisByName(axisName);
            }
        }

        /// <summary>
        /// Load_3<br/>
        /// 初始化表格
        /// </summary>
        private void DgvTrajInit()
        {
            dgvTrack.Rows.Add(4);
            dgvTrack.Rows[0].Cells[0].Value = NLocalizer.TraceStartPosition;
            dgvTrack.Rows[1].Cells[0].Value = NLocalizer.TriggerStartPosition;
            dgvTrack.Rows[2].Cells[0].Value = NLocalizer.TriggerEndPosition;
            dgvTrack.Rows[3].Cells[0].Value = NLocalizer.TraceEndPosition;

            if (_trajData != null && _trajData.Poses != null && _trajData.Poses.Count > 0)
            {
                DgvFillData(_trajData);
            }
            else
            {
                if (_trajData == null)
                {
                    _trajData = new TriggerTrackData();
                }

                if (_trajData.Poses == null)
                {
                    _trajData.Poses = new ConcurrentDictionary<int, CmpPos>();
                }

                if (_trajData.Poses.Count < 4)
                {
                    _trajData.Poses.Clear();
                    _trajData.Poses.TryAdd(0, new CmpPos(dgvTrack.Rows[0].Cells[0].Value.ToString()));
                    _trajData.Poses.TryAdd(1, new CmpPos(dgvTrack.Rows[1].Cells[0].Value.ToString()));
                    _trajData.Poses.TryAdd(2, new CmpPos(dgvTrack.Rows[2].Cells[0].Value.ToString()));
                    _trajData.Poses.TryAdd(3, new CmpPos(dgvTrack.Rows[3].Cells[0].Value.ToString()));

                    for (int i = 0; i < dgvTrack.Rows.Count; i++)
                    {
                        for (int j = 1; j < dgvTrack.Columns.Count - 1; j++)
                        {
                            dgvTrack.Rows[i].Cells[j].Value = 0;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取轴组元件
        /// </summary>
        private void UpdateEles()
        {
            var eles = ElesManagerTransfer.GetAllIEle();
            if (eles.IsNullOrEmpty())
            {
                return;
            }

            cmbElementName.SelectedIndex = -1;
            cmbElementName.Items.Clear();
            eles.ForEach(delegate (IEle ele)
            {
                if (ele is IEleCartesian)
                {
                    cmbElementName.Items.Add(ele.Name);
                }
            });
        }

        /// <summary>
        /// 获取元件所有轴名称
        /// </summary>
        private void UpdateAxises()
        {
            if (_ele != null)
            {
                cmbAxisName.SelectedIndex = -1;
                cmbAxisName.Items.Clear();
                ((IEleCartesian)_ele).Axises.ToList().ForEach(delegate (KeyValuePair<int, IEleAxis> axis)
                {
                    cmbAxisName.Items.Add(axis.Value.Name);
                });
            }
        }

        /// <summary>
        /// 表格值更新
        /// </summary>
        /// <param name="trajData"></param>
        private void DgvFillData(TriggerTrackData trajData)
        {
            for (int i = 0; i < dgvTrack.Rows.Count; i++)
            {
                dgvTrack.Rows[i].Cells[1].Value = trajData.Poses[i].Pos.X;
                dgvTrack.Rows[i].Cells[2].Value = trajData.Poses[i].Pos.Y;
                dgvTrack.Rows[i].Cells[3].Value = trajData.Poses[i].Pos.Z;
                dgvTrack.Rows[i].Cells[4].Value = trajData.Poses[i].Pos.U;
                dgvTrack.Rows[i].Cells[5].Value = trajData.Poses[i].Pos.V;
                dgvTrack.Rows[i].Cells[6].Value = trajData.Poses[i].Pos.W;
                dgvTrack.Rows[i].Cells[8].Value = trajData.Poses[i].Vel.X;
                dgvTrack.Rows[i].Cells[9].Value = trajData.Poses[i].Vel.Y;
                dgvTrack.Rows[i].Cells[10].Value = trajData.Poses[i].Vel.Z;
                dgvTrack.Rows[i].Cells[11].Value = trajData.Poses[i].Vel.U;
                dgvTrack.Rows[i].Cells[12].Value = trajData.Poses[i].Vel.V;
                dgvTrack.Rows[i].Cells[13].Value = trajData.Poses[i].Vel.W;
            }
        }

        /// <summary>
        /// 值保存
        /// </summary>
        /// <param name="trajData"></param>
        private void DgvTransData(ref TriggerTrackData trajData)
        {
            for (int i = 0; i < dgvTrack.Rows.Count; i++)
            {
                trajData.Poses[i].Pos.X = Convert.ToDouble(dgvTrack.Rows[i].Cells[1].Value);
                trajData.Poses[i].Pos.Y = Convert.ToDouble(dgvTrack.Rows[i].Cells[2].Value);
                trajData.Poses[i].Pos.Z = Convert.ToDouble(dgvTrack.Rows[i].Cells[3].Value);
                trajData.Poses[i].Pos.U = Convert.ToDouble(dgvTrack.Rows[i].Cells[4].Value);
                trajData.Poses[i].Pos.V = Convert.ToDouble(dgvTrack.Rows[i].Cells[5].Value);
                trajData.Poses[i].Pos.W = Convert.ToDouble(dgvTrack.Rows[i].Cells[6].Value);
                trajData.Poses[i].Vel.X = Convert.ToDouble(dgvTrack.Rows[i].Cells[8].Value);
                trajData.Poses[i].Vel.Y = Convert.ToDouble(dgvTrack.Rows[i].Cells[9].Value);
                trajData.Poses[i].Vel.Z = Convert.ToDouble(dgvTrack.Rows[i].Cells[10].Value);
                trajData.Poses[i].Vel.U = Convert.ToDouble(dgvTrack.Rows[i].Cells[11].Value);
                trajData.Poses[i].Vel.V = Convert.ToDouble(dgvTrack.Rows[i].Cells[12].Value);
                trajData.Poses[i].Vel.W = Convert.ToDouble(dgvTrack.Rows[i].Cells[13].Value);
            }
        }
        #endregion
    }
}
