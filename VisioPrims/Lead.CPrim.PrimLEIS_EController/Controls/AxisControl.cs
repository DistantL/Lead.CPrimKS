using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Lead.CPrim.PrimLESI_EController.Controls
{
    public partial class AxisControl : Form
    {
        private double _actualPos = -1.0;

        private double _actualVel = -1.0;

        private EAxis _axis;

        private double _cmdPos = -1.0;

        private double _cmdVel = -1.0;

        private double _errPos = -1.0;

        private PrimLESI_EController _prim;

        private double _targetPos = -1.0;
        private System.Timers.Timer _tmrCycle;

        public AxisControl()
        {
            InitializeComponent();
        }

        public AxisControl(PrimLESI_EController prim, EAxis selectAxis)
        {
            InitializeComponent();
            _prim = prim;
            _axis = selectAxis;
            tBoxAxisId.Text = _axis.Id.ToString();
            UpdateParams();
        }

        private delegate void TmrStatusChange();

        private delegate void UpdateControls();

        public int Id
        {
            get => _axis.Id;
        }

        private void AxisControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            _tmrCycle.Stop();
            //Hide();
            //e.Cancel = true;
        }

        private void AxisControl_Load(object sender, EventArgs e)
        {
            _tmrCycle = new System.Timers.Timer(100);//实例化Timer类，设置间隔时间为1000毫秒；
            _tmrCycle.Elapsed += new System.Timers.ElapsedEventHandler(TmrCycle_Tick);//到时间的时候执行事件；
            _tmrCycle.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            _tmrCycle.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
        }

        private void BtnAbsolute_Click(object sender, EventArgs e)
        {
            if (!_prim.AxisIsEnble(_axis.Id))
            {
                MessageBox.Show(ProxyTools.NLocalizer.GetString("PrimADLinkE_AxisControl_EnableAxisFirst", "Please enable the axis first."));
                return;
            }

            _prim.AxisSetAccDec(_axis.Id, double.Parse(tbPraVs.Text), double.Parse(tbPraVm.Text), double.Parse(tbPraAcc.Text), double.Parse(tbPraDec.Text), double.Parse(tbPraVe.Text));
            _prim.AxisAbsMove(_axis.Id, int.Parse(numAbsolutePos.Text), (int)_axis.DefaultParam.Vm);
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            double result = -1;
            if (double.TryParse(tbPraCurve.Text, out result))
            {
                _axis.DefaultParam.Curve = result;
            }

            if (double.TryParse(tbPraAcc.Text, out result))
            {
                _axis.DefaultParam.Acc = result;
            }

            if (double.TryParse(tbPraDec.Text, out result))
            {
                _axis.DefaultParam.Dec = result;
            }

            if (double.TryParse(tbPraVs.Text, out result))
            {
                _axis.DefaultParam.Vs = result;
            }

            if (double.TryParse(tbPraVm.Text, out result))
            {
                _axis.DefaultParam.Vm = result;
            }

            if (double.TryParse(tbPraVe.Text, out result))
            {
                _axis.DefaultParam.Ve = result;
            }

            if (double.TryParse(tbEquiv.Text, out result))
            {
                _axis.DefaultParam.Equiv = result;
            }
            else
            {
                _axis.DefaultParam.Equiv = 1;
            }

            if (cmbHomeBy.SelectedIndex != -1)
            {
                _axis.HomeParam.HomeBy = cmbHomeBy.SelectedIndex;
            }

            if (cmbHomeMode.SelectedIndex != -1)
            {
                _axis.HomeParam.Mode = cmbHomeMode.SelectedIndex;
            }

            if (cmbHomeDir.SelectedIndex != -1)
            {
                _axis.HomeParam.Dir = cmbHomeDir.SelectedIndex;
            }

            if (double.TryParse(tbHomeCurve.Text, out result))
            {
                _axis.HomeParam.Curve = result;
            }

            if (double.TryParse(tbHomeAcc.Text, out result))
            {
                _axis.HomeParam.Acc = result;
            }

            if (double.TryParse(tbHomeVs.Text, out result))
            {
                _axis.HomeParam.Vs = result;
            }

            if (double.TryParse(tbHomeVm.Text, out result))
            {
                _axis.HomeParam.Vm = result;
            }

            if (double.TryParse(tbHomeShift.Text, out result))
            {
                _axis.HomeParam.Shift = result;
            }

            if (double.TryParse(tbHomeVo.Text, out result))
            {
                _axis.HomeParam.Vo = result;
            }

            if (double.TryParse(tBoxHomePos.Text, out result))
            {
                _axis.HomeParam.Pos = result;
            }

            _axis.HomeParam.Eza = cmbHomeEza.Checked;

            if (cmbHomeEzDir.SelectedIndex != -1)
            {
                _axis.HomeParam.Ez_Dir = cmbHomeEzDir.SelectedIndex;
            }

            _axis.SInpEnable = chkSInpEnable.Checked;

            if (double.TryParse(tbSInpError.Text, out result))
            {
                _axis.SInpError = result;
            }

            if (double.TryParse(tbSInpTime.Text, out result))
            {
                _axis.SInpTimes = result;
            }

            foreach (var axis in _prim.Axises)
            {
                if (axis.Key == _axis.Id)
                {
                    axis.Value.HomeParam = _axis.HomeParam;
                    axis.Value.DefaultParam = _axis.DefaultParam;
                    axis.Value.SInpEnable = _axis.SInpEnable;
                    axis.Value.SInpError = _axis.SInpError;
                    axis.Value.SInpTimes = _axis.SInpTimes;
                    _prim.SetAxisParam(axis.Value);
                }
            }
        }

        private void BtnJogNegtive_Click(object sender, EventArgs e)
        {
            if (!_prim.AxisIsEnble(_axis.Id))
            {
                MessageBox.Show(ProxyTools.NLocalizer.GetString("PrimADLinkE_AxisControl_EnableAxisFirst", "Please enable the axis first."));
                return;
            }

            _prim.AxisJogStart(_axis.Id, _prim.AxisIsStop(_axis.Id) ? 1 : 0, 1);
        }

        private void BtnJogPositive_Click(object sender, EventArgs e)
        {
            if (!_prim.AxisIsEnble(_axis.Id))
            {
                MessageBox.Show(ProxyTools.NLocalizer.GetString("PrimADLinkE_AxisControl_EnableAxisFirst", "Please enable the axis first."));
                return;
            }
            _prim.AxisJogStart(_axis.Id, _prim.AxisIsStop(_axis.Id) ? 1 : 0, 0);
        }

        private void BtnRelative_Click(object sender, EventArgs e)
        {
            if (!_prim.AxisIsEnble(_axis.Id))
            {
                MessageBox.Show(ProxyTools.NLocalizer.GetString("PrimADLinkE_AxisControl_EnableAxisFirst", "Please enable the axis first."));
                return;
            }

            _prim.AxisSetAccDec(_axis.Id, double.Parse(tbPraVs.Text), double.Parse(tbPraVm.Text), double.Parse(tbPraAcc.Text), double.Parse(tbPraDec.Text), double.Parse(tbPraVe.Text));
            _prim.AxisRelMove(_axis.Id, double.Parse(numRelativePos.Text), _axis.DefaultParam.Vm);
        }

        #region Button_Event
        /// <summary>
        /// 使能按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnServoOn_Click(object sender, EventArgs e)
        {
            _prim.AxisSetEnable(_axis.Id, !_prim.AxisIsEnble(_axis.Id));
        } 
        #endregion

        private void BtnSetPos_Click(object sender, EventArgs e)
        {
            if (_prim.AxisIsEnble(_axis.Id))
            {
                MessageBox.Show(ProxyTools.NLocalizer.GetString("PrimADLinkE_AxisControl_DisableAxisFirst", "Please disable the axis first."));
                return;
            }

            _prim.SetAxisPositionAndFeedbackPulse(_axis.Id, int.Parse(tBoxSetPos.Text));
        }

        private void BtnStartHome_Click(object sender, EventArgs e)
        {
            if (!_prim.AxisIsEnble(_axis.Id))
            {
                MessageBox.Show(ProxyTools.NLocalizer.GetString("PrimADLinkE_AxisControl_EnableAxisFirst", "Please enable the axis first."));
                return;
            }

            BtnApply_Click(null, null);
            _prim.AxisHomeMove(_axis.Id);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _prim.AxisStopMove(_axis.Id);
        }

        private void BtnStopHome_Click(object sender, EventArgs e)
        {
            _prim.AxisStopMove(_axis.Id);
        }

        private void CmbHomeBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHomeBy.SelectedIndex == 0)
            {
                cmbHomeMode.Items.Clear();
                cmbHomeMode.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35 });
            }

            if (cmbHomeBy.SelectedIndex == 1)
            {
                cmbHomeMode.Items.Clear();
                cmbHomeMode.Items.AddRange(new object[] { 0, 1, 2 });
            }

            cmbHomeMode.SelectedIndex = -1;
        }
        private void TmrCycle_Tick(object sender, EventArgs e)
        {
            if (_prim?.Axises == null || !_prim.Axises.ContainsKey(_axis.Id) || IsDisposed)
            {
                Thread.Sleep(200);
                return;
            }
            
            _prim.GetAxisCommand(_axis.Id, ref _cmdPos);
            _prim.GetAxisPosition(_axis.Id, ref _actualPos);
            _prim.GetAxisTargetPosition(_axis.Id, ref _targetPos);
            _prim.GetAxisErrPosition(_axis.Id, ref _errPos);
            _prim.GetAxisCommandVelocity(_axis.Id, ref _cmdVel);
            _prim.GetAxisActualVelocity(_axis.Id, ref _actualVel);
            
            this.BeginInvoke(new MethodInvoker(delegate
            {
                try
                {
                    tBoxCmdPos.Text = _cmdPos.ToString("F0");
                    tBoxFeedbackPos.Text = _actualPos.ToString("F0");
                    tBoxTargetPos.Text = _targetPos.ToString("F0");
                    tBoxErrPos.Text = _errPos.ToString("F0");
                    tBoxCmdVel.Text = _cmdVel.ToString("F0");
                    tBoxFeedbackVel.Text = _actualVel.ToString("F0");

                    lbelAlm.BackColor = _prim.AxisIsAlarm(_axis.Id) ? Color.Red : Color.Gray;
                    lbelPel.BackColor = _prim.AxisInPel(_axis.Id) ? Color.Red : Color.Gray;
                    lbelMel.BackColor = _prim.AxisInMel(_axis.Id) ? Color.Red : Color.Gray;
                    lbelOrg.BackColor = _prim.AxisInOrigin(_axis.Id) ? Color.Green : Color.Gray;
                    lbelEmg.BackColor = _prim.AxisSignalEmg(_axis.Id) ? Color.Red : Color.Gray;
                    lbelInp.BackColor = _prim.AxisSignalInp(_axis.Id) ? Color.Green : Color.Gray;
                    lbelSvon.BackColor = _prim.AxisIsEnble(_axis.Id) ? Color.Green : Color.Red;
                    lbelScl.BackColor = _prim.AxisSignalScl(_axis.Id) ? Color.Red : Color.Gray;
                    lbelSpel.BackColor = _prim.AxisInSPel(_axis.Id) ? Color.Red : Color.Gray;
                    lbelSmel.BackColor = _prim.AxisInSMel(_axis.Id) ? Color.Red : Color.Gray;
                    lbelOp.BackColor = _prim.AxisSignalOp(_axis.Id) ? Color.Green : Color.Red;
                    btnServoOn.BackColor = _prim.AxisIsEnble(_axis.Id) ? Color.Green : Color.Red;

                    foreach (var label in groupMotion_status.Controls.OfType<Label>())
                    {
                        if (label.BorderStyle == BorderStyle.FixedSingle)
                        {
                            label.BackColor = ((_axis.MotionStatus & (1 << Convert.ToInt32(label.Tag))) != 0)
                                ? Color.GreenYellow
                                : Color.LightGray;
                        }
                    }
                }
                catch
                {
                }
                finally
                {
                    if (IsDisposed)
                    {
                        _tmrCycle.Stop();
                    }
                }
               
            }));
        }

        private void UpdateParams()
        {
            if (InvokeRequired)
            {
                var update = new UpdateControls(UpdateParams);
                BeginInvoke(update, null);
            }
            else
            {
                tbPraCurve.Text = _axis.DefaultParam.Curve.ToString(CultureInfo.InvariantCulture);
                tbPraAcc.Text = _axis.DefaultParam.Acc.ToString(CultureInfo.InvariantCulture);
                tbPraDec.Text = _axis.DefaultParam.Dec.ToString(CultureInfo.InvariantCulture);
                tbPraVs.Text = _axis.DefaultParam.Vs.ToString(CultureInfo.InvariantCulture);
                tbPraVm.Text = _axis.DefaultParam.Vm.ToString(CultureInfo.InvariantCulture);
                tbPraVe.Text = _axis.DefaultParam.Ve.ToString(CultureInfo.InvariantCulture);

                cmbHomeBy.SelectedIndex = _axis.HomeParam.HomeBy;
                cmbHomeMode.Text = _axis.HomeParam.Mode.ToString();
                cmbHomeDir.SelectedIndex = _axis.HomeParam.Dir;
                tbHomeCurve.Text = _axis.HomeParam.Curve.ToString(CultureInfo.InvariantCulture);
                tbHomeAcc.Text = _axis.HomeParam.Acc.ToString(CultureInfo.InvariantCulture);
                tbHomeVs.Text = _axis.HomeParam.Vs.ToString(CultureInfo.InvariantCulture);
                tbHomeVm.Text = _axis.HomeParam.Vm.ToString(CultureInfo.InvariantCulture);
                tbHomeShift.Text = _axis.HomeParam.Shift.ToString(CultureInfo.InvariantCulture);
                tbHomeVo.Text = _axis.HomeParam.Vo.ToString(CultureInfo.InvariantCulture);
                cmbHomeEza.Checked = _axis.HomeParam.Eza ? true : false;
                cmbHomeEzDir.SelectedIndex = _axis.HomeParam.Ez_Dir;

                chkSInpEnable.Checked = _axis.SInpEnable;
                tbSInpError.Text = _axis.SInpError.ToString(CultureInfo.InvariantCulture);
                tbSInpTime.Text = _axis.SInpTimes.ToString(CultureInfo.InvariantCulture);

                tbEquiv.Text = _axis.DefaultParam.Equiv.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}