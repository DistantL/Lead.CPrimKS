using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.EleAnalogInputPro
{
    public partial class ConfigUI : UIUserControl
    {
        #region Field
        /// <summary>
        /// 模拟量输入模块管理器
        /// </summary>
        public EleAnalogInput _ele; 
        #endregion



        #region Ctor
        public ConfigUI()
        {
            InitializeComponent();

            fillColor = Color.FromArgb(236, 236, 236);
            rectColor = Color.FromArgb(120, 120, 120);
            colAnalog.ReadOnly = true;
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void ConfigUI_Load(object sender, EventArgs e)
        {
            if (PrimsManagerTransfer.GetAllIPrim().Count > 0)
            {
                cboPrim.Items.Clear();
                PrimsManagerTransfer.GetAllIPrim().ForEach(p => cboPrim.Items.Add(p.Name));
                if (_ele.DevName != null)
                {
                    cboPrim.Text = _ele.DevName;
                }
                else
                {
                    cboPrim.Text = cboPrim.Items[1].ToString();
                }

                if (_ele.EleRunStat == EleRunState.Other)
                {
                    _ele.IEleInit();
                }
            }

            dgvAnalog.DataSource = _ele.AnalogCalculates;
            dgvAnalog.Refresh();
        }
        #endregion



        #region Override ITranslate
        #endregion



        #region Button_Event
        /// <summary>
        /// 应用
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AuthorityManager.Instance.VerifyLevel2Permission(true))
                {
                    return;
                }

                if (!AuthorityManager.Instance.VerifyLevel2Permission(true))
                {
                    return;
                }

                if (txtName.Text.IsNullOrWhiteSpace())
                {
                    throw new Exception(lblName.Text + "为空");
                }

                _ele.Enable = chkEnable.Checked;
                _ele.IsSimulateMode = chkSimulate.Checked;


                _ele.Name = txtName.Text;
                _ele.Info = txtInfo.Text;
                if (cboType.SelectedItem != null)
                {
                    if (cboType.Text == "Voltage(V)")
                    {
                        _ele.EleType = EleAnalogType.Voltage;
                    }
                    else
                    {
                        _ele.EleType = EleAnalogType.Electricity;
                    }
                }
                _ele.DevName = cboPrim.Text;
                _ele.Address = txtAddress.Text;

                _ele.LogAdd("应用成功", LogLevel.Info);
            }
            catch (Exception ex)
            {
                _ele.LogAdd("应用失败" + $"：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }

        /// <summary>
        /// 刷新当前状态
        /// </summary>
        private void LbState_Click(object sender, EventArgs e)
        {
            if (_ele.EleRunStat == EleRunState.Other) _ele.IEleInit();
            if (_ele.EleRunStat == EleRunState.Err) _ele.IEleReset();
        }

        /// <summary>
        /// 点击名称当前界面被选择
        /// </summary>
        private void panel1_Click(object sender, EventArgs e)
        {
            _ele.IsSelected = !_ele.IsSelected;
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            if (_ele.EleRunStat != EleRunState.Running)
            {
                return;
            }
            dgvAnalog.DataSource = null;

            _ele.AnalogCalculates.Add(new AnalogCalculate
            {
                RealTimeAnalog = _ele.RealTimeAnalog,
                RealTimeDigital = 0,
            });

            dgvAnalog.DataSource = _ele.AnalogCalculates;
            dgvAnalog.Refresh();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAnalog.SelectedRows.Count != 0)
                {
                    for (int i = 0; i < dgvAnalog.SelectedRows.Count; i++)
                    {
                        int index = dgvAnalog.SelectedRows[i].Index;
                        dgvAnalog.Rows.Remove(dgvAnalog.Rows[index]);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowWarningDialog("移除失败:" + ex.Message);
            }
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// 模拟量停止
        /// </summary>
        public void Stop()
        {
        }

        /// <summary>
        /// 界面更新（界面所有信息）
        /// </summary>
        /// <param name="Config"></param>
        public void UpdataEleConfig(EleAnalogInputConfig Config)
        {
            UIShow(_ele);
        }

        /// <summary>
        /// 界面更新（构造函数调用）
        /// </summary>
        /// <param name="ele"></param>
        public void SetEleConfig(EleAnalogInput ele)
        {
            _ele = ele;

            UIShow(ele);
        }

        /// <summary>
        /// 界面更新（实时模拟量/实时数字量刷新）
        /// </summary>
        public void UiRefresh()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(UiRefresh));
            }
            else
            {
                if (_ele == null)
                {
                    return;
                }

                if (_ele.EleRunStat == EleRunState.Other)
                {
                    _ele.IEleInit();
                    return;
                }

                cboPrim.BackColor = _ele.EleRunStat == EleRunState.Running ? Color.LawnGreen : SystemColors.GradientActiveCaption;
                txtRealTimeAnalog.Text = _ele.RealTimeAnalog.ToString("0.000");
                txtRealTimeDigital.Text = _ele.RealTimeDigital.ToString("0.000");
            }
        }

        /// <summary>
        /// 界面更新（输入模拟量状态刷新）
        /// </summary>
        public void SetEleRunState(EleRunState state)
        {
            if (txtState.InvokeRequired)
            {
                BeginInvoke(new Action<EleRunState>(SetEleRunState), state);
            }
            else
            {
                switch (state)
                {
                    case EleRunState.Idle:
                        txtState.BackColor = Color.Khaki;
                        txtState.Text = "Idle";
                        break;

                    case EleRunState.Running:
                        txtState.BackColor = Color.LightGreen;
                        txtState.Text = "Running";
                        break;

                    case EleRunState.Err:
                        txtState.BackColor = Color.SandyBrown;
                        txtState.Text = "Err";
                        break;

                    case EleRunState.Other:
                        txtState.BackColor = Color.Khaki;
                        txtState.Text = "Other";
                        break;
                }
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// 界面刷新
        /// </summary>
        private void UIShow(EleAnalogInput ele)
        {
            if(InvokeRequired)
            {
                BeginInvoke(new Action<EleAnalogInput>(UIShow), new object[] { ele });
            }
            else
            {
                txtName.Text = ele.Name;
                txtInfo.Text = ele.Info;
                if (ele.EleType == EleAnalogType.Voltage)
                {
                    cboType.SelectedIndex = 0;
                }
                else if (ele.EleType == EleAnalogType.Electricity)
                {
                    cboType.SelectedIndex = 1;
                }
                cboType.Text = ele.EleTypeName;
                cboPrim.Text = ele.DevName;
                txtAddress.Text = ele.Address;
                chkEnable.Checked = ele.Enable;
                chkSimulate.Checked = ele.IsSimulateMode;
            }
        }
        #endregion
    }
}