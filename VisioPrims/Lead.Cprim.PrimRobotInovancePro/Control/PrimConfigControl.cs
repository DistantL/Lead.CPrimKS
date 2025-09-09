using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMC100APIDLL;
using System.ComponentModel;
using System.Linq;
using Lead.CPrim.Interfaces.Robot;
using Lead.CPrim.Controls;
using static System.Windows.Forms.AxHost;

namespace Lead.CPrim.PrimRobotInovancePro
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

            fillColor = Color.FromArgb(236, 236, 236);
            rectColor = Color.FromArgb(236, 236, 236);
            txtName.SetStyle(Color.OldLace);

            lblIp.SetStyle();
            lblPort.SetStyle();
            lblRobotId.SetStyle();
            lblPassWord.SetStyle();

            chkType.SetStyle();
            txtAdress.SetStyle();
            txtResult.SetStyle();
            btnRead.SetStyle();
            btnWrite.SetStyle();

            lineConfig.BackColor = Color.Transparent;
            lineConfig.FillColor = Color.Transparent;
            lineDebug.BackColor = Color.Transparent;
            lineDebug.FillColor = Color.Transparent;
            chkMonitor.Style = CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            numVel.Style = CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;

            cmbVer.DataSource = new RobotVer[] { RobotVer.S0321R20, RobotVer.V4R24 };
        }

        public PrimConfigControl(Prim prim) : this()
        {
            _prim = prim;
        }
        #endregion



        #region Event_System
        private void PrimConfigControl_Load(object sender, EventArgs e)
        {
            txtName.Text = _prim.Name;
            txtIp.Text = _prim.RobotIp;
            txtPort.Text = _prim.Port.ToString();
            cmbRobotId.Text = _prim.RobotId.ToString();
            txtPassward.Text = _prim.Password;
            lblVersion.Text = "20240718V1.3";
            chkType.SelectedIndex = 0;
            cmbVer.SelectedItem = _prim.RobotVer;

            SetPrimConnState(_prim.PrimConnStat);
            SetPrimRunState(_prim.PrimRunStat);
            SetSpeed(_prim.Vel);
        }

        /// <summary>
        /// 速度设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void numVel_ValueChanged(object sender, double value)
        {
            if (_prim != null &&
                _prim.PrimRunStat == PrimRunState.Running)
            {
                int val = (int)value;
                _prim.Vel = val;
                _prim.SetVel(val);
            }
        }
        #endregion



        #region Event_Button
        /// <summary>
        /// 应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                int port;
                int no;
                if (txtIp.Text.IsNullOrWhiteSpace())
                {
                    throw new Exception($"{lblIp.Text}为空");
                }

                if (txtPort.Text.IsNullOrWhiteSpace())
                {
                    throw new Exception($"{lblPort}为空");
                }
                else if (!int.TryParse(txtPort.Text, out port))
                {
                    throw new Exception($"{lblPort}无效");
                }

                if (cmbRobotId.SelectedItem == null)
                {
                    throw new Exception($"{lblRobotId}为空");
                }
                else if (!int.TryParse(cmbRobotId.SelectedItem.ToString(), out no))
                {
                    throw new Exception($"{lblRobotId}无效");
                }

                if (txtPassward.Text.IsNullOrWhiteSpace())
                {
                    throw new Exception($"{lblPassWord}为空");
                }


                _prim.Name = txtName.Text;
                _prim.RobotIp = txtIp.Text;
                _prim.Port = port;
                _prim.RobotId = no;
                _prim.Password = txtPassward.Text;
                if (cmbVer.SelectedItem != null)
                {
                    _prim.RobotVer = Enum.TryParse(cmbVer.SelectedItem.ToString(), out RobotVer ver) ? ver : RobotVer.S0321R20;
                }
                else
                {
                    _prim.RobotVer = RobotVer.S0321R20;
                }
                _prim.LogAdd("应用成功", LogLevel.Info);
            }
            catch (Exception ex)
            {
                _prim.LogAdd("应用失败" + $"：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }

        /// <summary>
        /// 读
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRead_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
            string type = chkType.SelectedItem?.ToString();
            if (type.IsNullOrWhiteSpace())
            {
                return;
            }

            string addressStr = txtAdress.Text;
            if (addressStr.IsNullOrWhiteSpace() || !addressStr.IsInt())
            {
                return;
            }

            int address = addressStr.ToInt();
            switch (type)
            {
                case "B":
                    {
                        int value = 0;
                        _prim.ReadBVar(address, out value);
                        txtResult.Text = value.ToString();
                    }
                    break;
                case "D":
                    {
                        double value = 0;
                        _prim.ReadDVar(address, out value);
                        txtResult.Text = value.ToString();
                    }
                    break;
                case "R":
                    {
                        int value = 0;
                        _prim.ReadRVar(address, out value);
                        txtResult.Text = value.ToString();
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 写
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Write_Click(object sender, EventArgs e)
        {
            string type = chkType.SelectedItem?.ToString();
            if (type.IsNullOrWhiteSpace())
            {
                return;
            }

            string addressStr = txtAdress.Text;
            if (addressStr.IsNullOrWhiteSpace() || !addressStr.IsInt())
            {
                return;
            }

            int address = addressStr.ToInt();
            switch (type)
            {
                case "B":
                    {
                        string value = txtResult.Text;
                        if (value.IsNullOrWhiteSpace() || !value.IsInt())
                        {
                            return;
                        }

                        _prim.WriteBVar(address, value.ToInt());
                    }
                    break;
                case "D":
                    {
                        string value = txtResult.Text;
                        if (value.IsNullOrWhiteSpace() || !value.IsDouble())
                        {
                            return;
                        }

                        _prim.WriteDVar(address, value.ToDouble());
                    }
                    break;
                case "R":
                    {
                        string value = txtResult.Text;
                        if (value.IsNullOrWhiteSpace() || !value.IsInt())
                        {
                            return;
                        }

                        _prim.WriteRVar(address, value.ToInt());
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// true：初始化可点击；false：初始化不可点击；
        /// </summary>
        /// <param name="connect"></param>
        internal void SetInitEnable(bool connect)
        {
            btnInit.SetEnable(!connect);
        }

        /// <summary>
        /// 速度更新至UI
        /// </summary>
        /// <param name="value"></param>
        public void SetSpeed(int value)
        {
            if (!IsHandleCreated || !Created)
            {
                return;
            }

            if (InvokeRequired)
            {
                BeginInvoke(new Action<int>(SetSpeed), value);
            }
            else
            {
                numVel.ValueChanged -= numVel_ValueChanged;
                numVel.Value = value;
                numVel.ValueChanged += numVel_ValueChanged;
            }
        }
        #endregion



        #region Method_InternalUsing
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
                lblPosition.Text = "";
                lblState.Text = "";
            }
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            if (_prim.PrimRunStat != PrimRunState.Running)
            {
                return;
            }

            var pos = _prim.GetActualPos();
            if (pos == null)
            {
                return;
            }

            lblPosition.Text = $"X：{pos.X:F3}；Y：{pos.Y:F3}；Z：{pos.Z:F3}；A：{pos.A:F3}；B：{pos.B:F3}；C：{pos.C:F3}；";
            lblState.Text = _prim.GetPrgState().ToString();
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
                _prim?.IPrimInit();
                var result = "";
                _prim?.IPrimConnect(ref result);
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
                _prim?.IPrimStart();
                int vel = 10;
                if (_prim.GetVel(ref vel) == 0)
                {
                    numVel.Value = vel;
                }
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
                _prim.IsConnecting = false;
                _prim?.IPrimTaskStop();
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
                "20240718V1.3   \r\n增加机械手控制器版本选择，目前支持S0321R20（四轴）、V4R24（六轴）两个版本 \r\n\r\n" +
                "20240707V1.2   \r\n1、增加断线重连，点击停止按钮即可断开 \r\n\r\n" +
                "V1.1   \r\n1、增加断线重连，点击停止按钮即可断开 \r\n\r\n" +
                "V1.0   \r\n1、用于嘉善Snap汇川机械手";
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
