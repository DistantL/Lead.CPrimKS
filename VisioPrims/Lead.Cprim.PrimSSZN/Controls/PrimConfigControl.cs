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

namespace Lead.CPrim.PrimSSZN
{
    public partial class PrimConfigControl : UIUserControl
    {
        #region Field
        private Prim _prim;

        /// <summary>
        /// 名称数组
        /// </summary>
        private TextBox[] _tbNameArray;

        /// <summary>
        /// IP数组
        /// </summary>
        private TextBox[] _tbIpArray;

        /// <summary>
        /// 使能数组
        /// </summary>
        private CheckBox[] _chkEnableArray;
        #endregion



        #region Ctor
        public PrimConfigControl()
        {
            InitializeComponent();
            this.SetStyleALL(ControlStyle.Light);
            FillColor = Colors.PrimaryBackColor236;

            _tbNameArray = new TextBox[Prim.DeviceNo] { tbName0, tbName1, tbName2, tbName3, tbName4, tbName5 };
            _tbIpArray = new TextBox[Prim.DeviceNo] { tbIp0, tbIp1, tbIp2, tbIp3, tbIp4, tbIp5 };
            _chkEnableArray = new CheckBox[Prim.DeviceNo] { chkEnable0, chkEnable1, chkEnable2, chkEnable3, chkEnable4, chkEnable5 };

            cmbCallBackMethod.Items.Clear();
            cmbCallBackMethod.DataSource = new CallBackMethod[] { CallBackMethod.一次回调, CallBackMethod.高速回调 };
        }

        public PrimConfigControl(Prim prim) : this()
        {
            _prim = prim;
        }
        #endregion



        #region Event_System

        private void PrimConfigControl_Load(object sender, EventArgs e)
        {
            chkEnable.Checked = _prim.PrimEnable;
            txtDeviceCount.Text = _prim.DeviceCount.ToString();

            for (var i = 0; i < _tbNameArray.Length; i++) _tbNameArray[i].Text = _prim.DeviceName[i];

            for (var i = 0; i < _tbIpArray.Length; i++) _tbIpArray[i].Text = _prim.IpAddress[i];

            for (var i = 0; i < _chkEnableArray.Length; i++) _chkEnableArray[i].Checked = _prim.DeviceEnable[i];

            txtName.Text = _prim.Name;

            cmbDeviceSelect.SelectedIndex = 0;

            tbCallBackCount.Text = _prim.CallbackLineCount.ToString();

            DeviceChange(_prim.DeviceCount);

            cmbCallBackMethod.SelectedItem = _prim.CallBackMethod;
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
            _prim.DeviceCount = txtDeviceCount.Text.ToInt();
            if (_prim.DeviceCount < 0)
            {
                return;
            }

            DeviceChange(_prim.DeviceCount);
        }

        /// <summary>
        /// 控制器ID切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDeviceSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeviceSelect.SelectedIndex == -1)
            {
                return;
            }

            int index = cmbDeviceSelect.SelectedIndex;
            tbKeyProNO.Text = Convert.ToInt32(_prim.KeyProNO[index]).ToString();
            textBoxTrigCount.Text = _prim.BatchPointNum[index].ToString();
            tbInterValX.Text = _prim.IntervalX[index].ToString(CultureInfo.InvariantCulture);
            tbInterValY.Text = _prim.IntervalY[index].ToString(CultureInfo.InvariantCulture);
            tbRowPointNum.Text = _prim.RowPointNum[index].ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            _prim.PrimEnable = chkEnable.Checked;

            for (var i = 0; i < Prim.DeviceNo; i++)
            {
                _prim.DeviceName[i] = _tbNameArray[i].Text;
                _prim.IpAddress[i] = _tbIpArray[i].Text;
                _prim.DeviceEnable[i] = _chkEnableArray[i].Checked;
            }

            _prim.Name = txtName.Text;
            _prim.CallbackLineCount = tbCallBackCount.Text.ToInt(20);
            if(cmbCallBackMethod.SelectedItem != null)
            {
                _prim.CallBackMethod = Enum.TryParse(cmbCallBackMethod.SelectedItem.ToString(), out CallBackMethod callBack) ? callBack : CallBackMethod.一次回调;
            }
            else
            {
                _prim.CallBackMethod = CallBackMethod.一次回调;
            }

            DeviceSelectedParamSave();
        }





        //测试
        private void chkDebugMode_CheckedChanged(object sender, EventArgs e)
        {
            _prim.DebugMode = chkDebugMode.Checked;
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            //if (cmbDeviceSelect.SelectedIndex == -1) return;
            //_primKeyence.Get3dData(cmbDeviceSelect.SelectedIndex, 0);
        }
        private void btnSaveTestReal_Click(object sender, EventArgs e)
        {
            if (cmbDeviceSelect.SelectedIndex == -1) return;
            //var datas = _primSSZN.Get3dData(cmbDeviceSelect.SelectedIndex, 0);
            List<double> yPos = new List<double>();
            for (int i = 0; i < Convert.ToInt16(tbDataCount.Text); i++)
            {
                yPos.Add(i * Convert.ToDouble(tbInterValY.Text));
            }
            _prim.Write3dDataToCsv(chkLine.Checked, "F:\\Save\\2.csv", _prim.GetBatchData(yPos));
        }
        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            //if (cmbDeviceSelect.SelectedIndex != -1)
            //    for (var i = 0; i < _primKeyence.PartNum[cmbDeviceSelect.SelectedIndex]; i++)
            //        _primKeyence.Get3dData(cmbDeviceSelect.SelectedIndex, i, true, true,
            //            $@"F:\Save\{DateTime.Now:MM-dd_hh-mm}--{i}.csv");
        }
        private void btnStartMeasure_Click(object sender, EventArgs e)
        {
            if (cmbDeviceSelect.SelectedIndex == -1) return;
            Cursor = Cursors.WaitCursor;

            _prim.StartMeasure(cmbDeviceSelect.SelectedIndex);

            Cursor = Cursors.Default;
        }
        private void btnStopMeasure_Click(object sender, EventArgs e)
        {
            if (cmbDeviceSelect.SelectedIndex == -1) return;
            Cursor = Cursors.WaitCursor;
            _prim.StopMeasure(cmbDeviceSelect.SelectedIndex);
            Cursor = Cursors.Default;
        }
        private void btnOpenDemo_Click(object sender, EventArgs e)
        {
            //var form = new KeyenceLJ_Demo();
            //form.Show();
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// 获取数据个数
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="obj"></param>
        public void UpdateDataCount(int deviceId, object obj)
        {
            tbDataCount.SetText(obj.ToString());
            _prim.LogAdd($"控制器：{deviceId}获取数据个数：{obj.ToString()}", LogLevel.Trace);
        }

        public void UpdateTrigCount(int deviceId, object obj)
        {
            if (tbTrigCount.InvokeRequired)
            {
                BeginInvoke(new Action<int, object>(UpdateTrigCount), deviceId, obj);
            }
            else
            {
                if (cmbDeviceSelect.SelectedIndex == deviceId) tbTrigCount.Text = obj.ToString();
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// 控制器数量变化时UI变化
        /// </summary>
        private void DeviceChange(int no)
        {
            if (no <= 0)
            {
                return;
            }

            cmbDeviceSelect.Items.Clear();
            for (int i = 0; i < no; i++)
            {
                cmbDeviceSelect.Items.Add(i);
            }
            cmbDeviceSelect.SelectedIndex = 0;

            for (int i = 0; i < Prim.DeviceNo; i++)
            {
                if (i < no)
                {
                    _tbNameArray[i].Enabled = true;
                    _tbIpArray[i].Enabled = true;
                    _chkEnableArray[i].Enabled = true;
                }
                else
                {
                    _tbNameArray[i].Enabled = false;
                    _tbIpArray[i].Enabled = false;
                    _chkEnableArray[i].Enabled = false;
                    _chkEnableArray[i].Checked = false;
                }
            }
        }

        /// <summary>
        /// 控制器ID参数保存
        /// </summary>
        private void DeviceSelectedParamSave()
        {
            int index = cmbDeviceSelect.SelectedIndex;
            if (index < 0)
            {
                return;
            }

            _prim.KeyProNO[index] = tbKeyProNO.Text.ToByte();
            _prim.BatchPointNum[index] = textBoxTrigCount.Text.ToInt();
            _prim.IntervalX[index] = tbInterValX.Text.ToDouble();
            _prim.IntervalY[index] = tbInterValY.Text.ToDouble();
            _prim.RowPointNum[index] = tbRowPointNum.Text.ToInt();
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