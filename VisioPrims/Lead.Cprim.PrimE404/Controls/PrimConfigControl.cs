using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lead.CPrim.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools;
using System.ComponentModel;
using System.Linq;

namespace Lead.CPrim.PrimE404
{
    public partial class PrimConfigControl : UIUserControl
    {
        #region Field
        private Prim _prim;
        #endregion



        #region Ctor
        public PrimConfigControl()
        {
            InitializeComponent();
            this.SetStyleALL(ControlStyle.Light);
            FillColor = Colors.PrimaryBackColor236;

            this.SetStyleALL(ControlStyle.Light);
            dgvData.SetStyle(false, false, false, DataGridViewAutoSizeColumnsMode.None, DataGridViewContentAlignment.MiddleLeft);

            SetDataGridViewComboBoxCell();
            for (int i = 0; i < dgvData.Columns.Count; i++)
            {
                dgvData.Columns[i].Width = 150;
            }
        }

        public PrimConfigControl(Prim prim) : this()
        {
            _prim = prim;
            dgvData.DataSource = _prim.TriggerDatas;
        }
        #endregion



        #region Event_System

        private void PrimConfigControl_Load(object sender, EventArgs e)
        {
            txtName.Text = _prim.Name;
            txtSlaveId.Text = _prim.SlaveId.ToString();
            chkOpenOtherName.Checked = _prim.OpenOtherName;

            lblVersion.Text = "20240719_V1.0";
            SetPrimConnState(_prim.PrimConnStat);
            SetPrimRunState(_prim.PrimRunStat);
            DgvShow();
        }

        private void dgvEle_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
            {
                return;
            }

            if (dgv.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && e.RowIndex != -1)
            {
                SendKeys.Send("{F4}");
            }
        }

        private void dgvEle_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
            {
                return;
            }

            if (dgv.IsCurrentCellDirty)
            {
                dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        #endregion



        #region Event_Button
        /// <summary>
        /// 控制器的个数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbDeviceCount_TextChanged(object sender, EventArgs e)
        {

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
                string error = "";
                if (ControlHelper.CheckDgvCellRepeat(dgvData, ref error, 0))
                {
                    throw new Exception(error);
                }
                if (ControlHelper.CheckDgvCellRepeat(dgvData, ref error, 1))
                {
                    throw new Exception(error);
                }
                if (ControlHelper.CheckDgvCellRepeat(dgvData, ref error, 2))
                {
                    throw new Exception(error);
                }
                if (ControlHelper.CheckDgvCellRepeat(dgvData, ref error, 3))
                {
                    throw new Exception(error);
                }

                _prim.Name = txtName.Text;
                _prim.SlaveId = (txtSlaveId.Text.IsNullOrWhiteSpace() || !txtSlaveId.Text.IsInt()) ? throw new Exception($"{lblSlaveId.Text}：{NLocalizer.InValid}") : txtSlaveId.Text.ToInt();
                _prim.OpenOtherName = chkOpenOtherName.Checked;
            }
            catch (Exception ex)
            {
                _prim.LogAdd(ex.Message, LogLevel.Warn, 0, true);
            }
        }

        /// <summary>
        /// 监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkMonitor_CheckedChanged(object sender, EventArgs e)
        {
            if (_prim != null &&
                _prim.PrimRunStat == PrimRunState.Running)
            {
                tmr.Enabled = chkMonitor.Checked;
            }
            else
            {
                tmr.Enabled = false;
            }

            if (!tmr.Enabled)
            {
                lblState.Text = "";
            }
        }

        /// <summary>
        /// 右键新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            if (_prim.TriggerDatas == null)
            {
                _prim.TriggerDatas = new BindingList<TriggerData>();
            }

            TriggerData data = new TriggerData();
            _prim.TriggerDatas.Add(data);
            DgvShow();
        }

        private void btnOpenDemo_Click(object sender, EventArgs e)
        {
            //var form = new KeyenceLJ_Demo();
            //form.Show();
        }
        #endregion



        #region Method_ExternalUsing
        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// 触发参数刷新
        /// </summary>
        private void DgvShow()
        {
            dgvData.Refresh();
        }

        /// <summary>
        /// DataGridViewComboBoxCell绑定数据源
        /// </summary>
        private void SetDataGridViewComboBoxCell()
        {
            colTriggerId.DataSource = new int[] { 0, 1, 2, 3 };
            colTriggerId.ValueType = typeof(int);

            colEncoderId.DataSource = new int[] { 0, 1, 2, 3 };
            colEncoderId.ValueType = typeof(int);

            colLineCompareMask.DataSource = new LineCompareMask[] { LineCompareMask.bit0, LineCompareMask.bit1, LineCompareMask.bit2, LineCompareMask.bit3, LineCompareMask.bit4, LineCompareMask.bit5, LineCompareMask.bit6, LineCompareMask.bit7, LineCompareMask.bit8, LineCompareMask.bit9 };
            colLineCompareMask.ValueType = typeof(LineCompareMask);

            colPreCompareMask.DataSource = new PreCompareMask[] { PreCompareMask.bit0, PreCompareMask.bit1, PreCompareMask.bit2, PreCompareMask.bit3 };
            colPreCompareMask.ValueType = typeof(PreCompareMask);

            colTrigMode.DataSource = new TrigMode[] { TrigMode.脉冲, TrigMode.电平翻转 };
            colTrigMode.ValueType = typeof(TrigMode);

            colOutMode.DataSource = new OutMode[] { OutMode.GPIO, OutMode.脉冲, OutMode.PWM };
            colOutMode.ValueType = typeof(OutMode);

            colPulsePolarity.DataSource = new PulsePolarity[] { PulsePolarity.不取反, PulsePolarity.取反 };
            colPulsePolarity.ValueType = typeof(PulsePolarity);

            colEncoderMode.DataSource = new EncoderMode[] { EncoderMode.One倍频, EncoderMode.Two倍频, EncoderMode.Four倍频 };
            colEncoderMode.ValueType = typeof(EncoderMode);

            colEncoderDir.DataSource = new EncoderDir[] { EncoderDir.正向, EncoderDir.反向, EncoderDir.双向 };
            colEncoderDir.ValueType = typeof(EncoderDir);
        }

        /// <summary>
        /// 循环线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmr_Tick(object sender, EventArgs e)
        {
            //_prim.GetEncoderPos()
        }
        #endregion





        #region 框架内
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInit_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                UIWaitFormService.ShowWaitForm(NLocalizer.Loading);
                _prim?.IPrimInit();
                var result = "";
                _prim?.IPrimConnect(ref result);
                UIWaitFormService.HideWaitForm();
            });
        }

        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                UIWaitFormService.ShowWaitForm(NLocalizer.Loading);
                _prim?.IPrimStart();
                UIWaitFormService.HideWaitForm();
            });
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                UIWaitFormService.ShowWaitForm(NLocalizer.Loading);
                _prim?.IPrimTaskStop();
                UIWaitFormService.HideWaitForm();
            });
        }

        /// <summary>
        /// 版本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblVersion_DoubleClick(object sender, EventArgs e)
        {
            string msg =
                //"V1.1   \r\n1、增加断线重连，点击停止按钮即可断开 \r\n\r\n" +
                "20240719_V1.0   \r\n1、初始版本，用于昆山R1200";
            VersionForm.Instance.SetInfo(_prim.Name, _prim.HSType.ToString(), _prim.Manu.ToString(), msg);
            VersionForm frm = VersionForm.Instance;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        /// <summary>基元名称设置</summary>
        /// <param name="name">名称</param>
        internal void SetPrimName(string name)
        {
            if (!Created || !IsHandleCreated)
            {
                return;
            }
            if (txtConnState.InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetPrimName), name);
            }
            else
            {
                txtName.Text = name;
            }
        }

        /// <summary>连接状态设置</summary>
        /// <param name="state">连接状态</param>
        public void SetPrimConnState(PrimConnState state)
        {
            if (!Created || !IsHandleCreated)
            {
                return;
            }
            if (txtConnState.InvokeRequired)
            {
                BeginInvoke(new Action<PrimConnState>(SetPrimConnState), state);
            }
            else
            {
                switch (state)
                {
                    case PrimConnState.UnConnected:
                    case PrimConnState.Other:
                        txtConnState.FillColor = Color.Khaki;
                        txtConnState.Text = PrimConnState.UnConnected.ToString();

                        btnInit.BackColor = Color.SkyBlue;
                        btnInit.Enabled = true;
                        break;
                    case PrimConnState.Connected:
                        txtConnState.FillColor = Color.LightGreen;
                        txtConnState.Text = PrimConnState.Connected.ToString();

                        btnInit.BackColor = Color.Gray;
                        btnInit.Enabled = false;
                        break;
                }
            }
        }

        /// <summary>运行状态设置</summary>
        /// <param name="state">运行状态</param>
        public void SetPrimRunState(PrimRunState state)
        {
            if (!Created || !IsHandleCreated)
            {
                return;
            }

            if (txtRunState.InvokeRequired)
            {
                BeginInvoke(new Action<PrimRunState>(SetPrimRunState), state);
            }
            else
            {
                switch (state)
                {
                    case PrimRunState.Running:
                        txtRunState.FillColor = Color.LightGreen;
                        txtRunState.Text = PrimRunState.Running.ToString();

                        btnRun.Enabled = false;
                        btnRun.BackColor = Color.Gray;

                        //btnStop.Enabled = true;
                        //btnStop.BackColor = Color.SandyBrown;
                        break;

                    case PrimRunState.Stop:
                        txtRunState.FillColor = Color.Brown;
                        txtRunState.Text = PrimRunState.Stop.ToString();

                        btnRun.Enabled = true;
                        btnRun.BackColor = Color.SkyBlue;

                        //btnStop.Enabled = true;
                        //btnStop.BackColor = Color.SandyBrown;
                        break;

                    case PrimRunState.Err:
                        txtRunState.FillColor = Color.SandyBrown;
                        txtRunState.Text = PrimRunState.Err.ToString();

                        btnRun.Enabled = false;
                        btnRun.BackColor = Color.Gray;

                        //btnStop.Enabled = false;
                        //btnStop.BackColor = Color.Gray;
                        break;

                    case PrimRunState.Idle:
                        txtRunState.FillColor = Color.Khaki;
                        txtRunState.Text = PrimRunState.Idle.ToString();

                        btnRun.Enabled = true;
                        btnRun.BackColor = Color.SkyBlue;

                        //btnStop.Enabled = true;
                        //btnStop.BackColor = Color.SandyBrown;
                        break;

                    case PrimRunState.Other:
                        txtRunState.FillColor = Color.Khaki;
                        txtRunState.Text = PrimRunState.Other.ToString();

                        btnRun.Enabled = false;
                        btnRun.BackColor = Color.Gray;

                        //btnStop.Enabled = false;
                        //btnStop.BackColor = Color.Gray;
                        break;
                }
            }
        }
        #endregion
    }
}