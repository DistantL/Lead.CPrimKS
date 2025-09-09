using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;
using System.IO;
using Lead.CPrim.Interfaces.IMotionCard;
using System.Threading;
using Lead.CPrim.Controls;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.PrimPCIEM60_E
{
    public partial class PrimConfigControl : UserControl
    {
        #region Field
        private PrimPCIEM60_E _prim;
        #endregion



        #region Ctor
        public PrimConfigControl()
        {
            InitializeComponent();

            this.SetStyleALL(ControlStyle.Light);
        }

        public PrimConfigControl(PrimPCIEM60_E prim) : this()
        {
            _prim = prim;
        }
        #endregion



        #region Event_System

        private void PrimConfigControl_Load(object sender, EventArgs e)
        {
            txtId.Text = _prim.DevIndex.ToString();
            txtName.Text = _prim.Name;
            txtEniPath.Text = _prim.ConfigFilePath;
            txtEBusConfigFile.Text = _prim.EBusConfigFilegPath;
            lblVersion.Text = "20240725V1.1";
            CalcCount();

            SetPrimConnState(_prim.PrimConnStat);
            SetPrimRunState(_prim.PrimRunStat);
        }

        #endregion



        #region Event_Button

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (_prim.PrimRunStat == PrimRunState.Running)
                {
                    throw new Exception(NLocalizer.PrimIsRuning);
                }

                if (txtId.Text.IsNullOrWhiteSpace() || !txtId.Text.IsInt())
                {
                    throw new Exception($"{lblId.Text}：{NLocalizer.ValueInvalid}");
                }

                if (txtEniPath.Text.IsNullOrWhiteSpace())
                {
                    throw new Exception($"{lblEniPath.Text}：{NLocalizer.ValueInvalid}");
                }

                if (txtEBusConfigFile.Text.IsNullOrWhiteSpace())
                {
                    throw new Exception($"{lblEBusConfigFile.Text}：{NLocalizer.ValueInvalid}");
                }

                _prim.Name = txtName.Text;
                _prim.ConfigFilePath = txtEniPath.Text;
                _prim.EBusConfigFilegPath = txtEBusConfigFile.Text;
                _prim.DevIndex = txtId.Text.ToInt();
                _prim.TotalSlaveNum = txtSlaveCount.Text.ToInt();
                _prim.TotalAxisNum = txtAxisCount.Text.ToInt();
                _prim.TotalIoNum = txtIOCount.Text.ToInt();
                _prim.TotalDiModuleNum = txtDiCount.Text.ToInt();
                _prim.TotalDoModuleNum = txtDoCount.Text.ToInt();
                _prim.TotalAiModuleNum = txtAiCount.Text.ToInt();
                _prim.TotalAoModuleNum = txtAoCount.Text.ToInt();
                _prim.ExportEBusConfig();

                _prim.LogAdd($"{NLocalizer.ApplySuccess}", LogLevel.Trace);
            }
            catch (Exception ex)
            {
                _prim.LogAdd($"{NLocalizer.ApplyError}：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            string file = txtEniPath.Text;
            if (FileHelper.OpenFileDialogMethod(ref file))
            {
                txtEniPath.Text = file;
            }
        }

        private void btnEBusConfigFile_Click(object sender, EventArgs e)
        {
            string file = txtEBusConfigFile.Text;
            if (FileHelper.SaveFileDialogMethod("", FilterType.JSON, DefaultExt.JSON, true, false, true, ref file))
            {
                txtEBusConfigFile.Text = file;
            }
        }

        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// UI更新
        /// </summary>
        private void CalcCount()
        {
            if (!Created || !IsHandleCreated)
            {
                return;
            }

            if (InvokeRequired)
            {
                BeginInvoke(new Action(CalcCount));
                return;
            }

            if (_prim != null)
            {
                txtSlaveCount.Text = _prim.TotalSlaveNum.ToString();
                txtAxisCount.Text = _prim.TotalAxisNum.ToString();
                txtIOCount.Text = _prim.TotalIoNum.ToString();
                txtDiCount.Text = _prim.TotalDiModuleNum.ToString();
                txtDoCount.Text = _prim.TotalDoModuleNum.ToString();
                txtAiCount.Text = _prim.TotalAiModuleNum.ToString();
                txtAoCount.Text = _prim.TotalAoModuleNum.ToString();
            }
        }
        #endregion







        #region 框架内
        private void Timer1_Tick(object sender, System.EventArgs e)
        {
            if (_prim.PrimRunStat != PrimRunState.Running)
            {
                return;
            }

            Thread.Sleep(300);
            try
            {
                bool flag = true;
                string msg = string.Empty;
                for (short i = 1; i <= _prim.TotalAxisNum; i++)
                {
                    if ((_prim.Axises[i].MotionIoStatus & (1 << 24)) != 0) 
                    {
                        flag = false;
                        msg += $"轴号{i}伺服掉线；";
                    }
                }

                if (!flag) 
                {
                    _prim?.IPrimTaskStop();
                    _prim.LogAdd($"PrimPCIEM60_E:{msg}", LogLevel.Warn, 0, true);
                }
            }
            catch 
            {
            }
        }

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
                "20240725V1.1   \r\n1、增加从站掉线防呆 \r\n\r\n" +
                "V1.0   \r\n1、初始版本";
            VersionForm.Instance.SetInfo(_prim.Name, _prim.HSType.ToString(), "", msg);
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
