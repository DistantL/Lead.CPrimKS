using Lead.CPrim.Interfaces;
using Lead.CPrim.XmlHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.PrimRobotMitsubishi
{
    public partial class PrimConfigControl : UserControl
    {
        private PrimRobotMitsubishi _primRobot;
        
        public string PrimRobotInovanceName
        {
            set => tbPrimName.Text = value;
        }

        public AxMELFARXMLib.AxMelfaRxM AxMelfaRxM
        {
            get => axMelfaRxM1;
            set => axMelfaRxM1 = value;
        }

        public PrimConfigControl()
        {
            InitializeComponent();
            
        }

        public PrimConfigControl(PrimRobotMitsubishi prim)
        {
            InitializeComponent();
            _primRobot = prim;
        }
        
        private void PrimConfigControl_Load(object sender, EventArgs e)
        {
            PrimRobotInovanceName = _primRobot.Name;
            cmbRobotId.Text = _primRobot.RobotId.ToString();
            textBMain.Text = _primRobot.MainFunc;
            textBoxVR.Text = _primRobot.VRName;
            SetPrimConnState(((IPrim)_primRobot).PrimConnStat);
            SetPrimRunState(((IPrim)_primRobot).PrimRunStat);
        }
      
        public void SetPrimConnState(PrimConnState state)
        {
            if (!Created || !IsHandleCreated)
                return;

            if (tbConnState.InvokeRequired)
            {
                BeginInvoke(new Action<PrimConnState>(SetPrimConnState), state);
            }
            else
            {
                switch (state)
                {
                    case PrimConnState.UnConnected:
                        tbConnState.BackColor = Color.Khaki;
                        tbConnState.Text = "UnConnected";
                        break;
                    case PrimConnState.Connected:
                        tbConnState.BackColor = Color.LightGreen;
                        tbConnState.Text = "Connected";
                        break;
                    case PrimConnState.Other:
                        tbConnState.BackColor = Color.Khaki;
                        tbConnState.Text = "UnConnected";
                        break;
                }
            }
        }

        public void SetPrimRunState(PrimRunState state)
        {
            if (!Created || !IsHandleCreated)
                return;

            if (tbRunState.InvokeRequired)
            {
                BeginInvoke(new Action<PrimRunState>(SetPrimRunState), state);
            }
            else
            {
                switch (state)
                {
                    case PrimRunState.Idle:
                        tbRunState.BackColor = Color.Khaki;
                        tbRunState.Text = "Idle";
                        break;
                    case PrimRunState.Running:
                        tbRunState.BackColor = Color.LightGreen;
                        tbRunState.Text = "Running";
                        break;
                    case PrimRunState.Err:
                        tbRunState.BackColor = Color.SandyBrown;
                        tbRunState.Text = "Err";
                        break;
                    case PrimRunState.Other:
                        tbRunState.BackColor = Color.Khaki;
                        tbRunState.Text = "Idle";
                        break;
                    case PrimRunState.Stop:
                        tbRunState.BackColor = Color.Khaki;
                        tbRunState.Text = "Idle";
                        break;
                }
            }
        }
        private void cmbRobotId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbRobotId.Text) && int.TryParse(cmbRobotId.Text, out var robotId))
            {
                _primRobot.RobotId = robotId;
            }
        }
        private void btnInit_Click(object sender, EventArgs e)
        {
            _primRobot.IPrimInit();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var result = "";
            _primRobot.IPrimConnect(ref result);
            _primRobot.IPrimStart();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _primRobot.IPrimStop();
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbRobotId.Text) && int.TryParse(cmbRobotId.Text, out var no))
            {
                _primRobot.RobotId = no;
            }
            if (!string.IsNullOrEmpty(textBMain.Text))
            {
                _primRobot.MainFunc = textBMain.Text;
            }
            if (!string.IsNullOrEmpty(textBoxVR.Text))
            {
                _primRobot.VRName = textBoxVR.Text;
            }
            _primRobot.Name = tbPrimName.Text;
        }



        #region 调试
        private void btnEnable_Click(object sender, EventArgs e)
        {
            try
            {
                if (_primRobot == null)
                {
                    throw new Exception("未获取机械手实例");
                }

                int ret = _primRobot.EnableRobot(true);
                if (ret == 0)
                {
                    ProxyTools.ProxyTools.Show("使能成功", Color.Green, 3000, 3);
                }
                else
                {
                    throw new Exception($"使能失败 => 返回值 = {ret}");
                }
            }
            catch (Exception ex)
            {
                ProxyTools.ProxyTools.Show("失败 =》" + ex.Message, Color.Red, 0, 3);
            }
        }

        private void btnDisEnable_Click(object sender, EventArgs e)
        {
            try
            {
                if (_primRobot == null)
                {
                    throw new Exception("未获取机械手实例");
                }

                int ret = _primRobot.EnableRobot(false);
                if (ret == 0)
                {
                    ProxyTools.ProxyTools.Show("下使能成功", Color.Green, 3000, 3);
                }
                else
                {
                    throw new Exception($"下使能失败 => 返回值 = {ret}");
                }
            }
            catch (Exception ex)
            {
                ProxyTools.ProxyTools.Show("失败 =》" + ex.Message, Color.Red, 0, 3);
            }
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (_primRobot == null)
                {
                    throw new Exception("未获取机械手实例");
                }

                int ret = _primRobot.PrgStart(20);
                if (ret == 0)
                {
                    ProxyTools.ProxyTools.Show("启动成功", Color.Green, 3000, 3);
                }
                else
                {
                    throw new Exception($"启动失败 => 返回值 = {ret}");
                }
            }
            catch (Exception ex)
            {
                ProxyTools.ProxyTools.Show("失败 =》" + ex.Message, Color.Red, 0, 3);
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            try
            {
                if (_primRobot == null)
                {
                    throw new Exception("未获取机械手实例");
                }

                int ret = _primRobot.PrgPause();
                if (ret == 0)
                {
                    ProxyTools.ProxyTools.Show("暂停成功", Color.Green, 3000, 3);
                }
                else
                {
                    throw new Exception($"暂停失败 => 返回值 = {ret}");
                }
            }
            catch (Exception ex)
            {
                ProxyTools.ProxyTools.Show("失败 =》" + ex.Message, Color.Red, 0, 3);
            }
        }

        private void btnReadIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (_primRobot == null)
                {
                    throw new Exception("未获取机械手实例");
                }

                double index = double.TryParse(tbIndex1.Text, out var value) ? value : throw new Exception("读取点位为空");
                bool val;
                int ret = _primRobot.ReadSingleDInput(index, out val);
                if (ret == 0)
                {
                    ProxyTools.ProxyTools.Show("读输入信号成功", Color.Green, 3000, 3);
                }
                else
                {
                    throw new Exception($"读输入信号失败 => 返回值 = {ret}");
                }

                tbValue1.Text = val.ToString();
            }
            catch (Exception ex)
            {
                ProxyTools.ProxyTools.Show("失败 =》" + ex.Message, Color.Red, 0, 3);
            }
        }

        private void btnWriteOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (_primRobot == null)
                {
                    throw new Exception("未获取机械手实例");
                }

                double index = double.TryParse(tbIndex1.Text, out var value) ? value : throw new Exception("写入点位为空");
                bool val;
                if(tbValue1.Text.Trim() == "0" || tbValue1.Text.Trim().ToUpper() == "FALSE")
                {
                    val = false;
                }
                else if(tbValue1.Text.Trim() == "1" || tbValue1.Text.Trim().ToUpper() == "TRUE")
                {
                    val = true;
                }
                else
                {
                    throw new Exception("写入值不为 0 | 1 | true | false");
                }
                int ret = _primRobot.WriteSingleDOutput(index, val);
                if (ret == 0)
                {
                    ProxyTools.ProxyTools.Show("写输出信号成功", Color.Green, 3000, 3);
                }
                else
                {
                    throw new Exception($"写输出信号失败 => 返回值 = {ret}");
                }

                tbValue1.Text = val.ToString();
            }
            catch (Exception ex)
            {
                ProxyTools.ProxyTools.Show("失败 =》" + ex.Message, Color.Red, 0, 3);
            }
        }

        private void btnReadFloat_Click(object sender, EventArgs e)
        {
            try
            {
                if (_primRobot == null)
                {
                    throw new Exception("未获取机械手实例");
                }

                int index = int.TryParse(tbIndex2.Text, out var value) ? value : throw new Exception("读取Float变量地址为空");
                double val = 0;

                int ret = _primRobot.ReadFloatVar(1, index, out val);
                if (ret == 0)
                {
                    ProxyTools.ProxyTools.Show("读Float变量成功", Color.Green, 3000, 3);
                }
                else
                {
                    throw new Exception($"读Float变量失败 => 返回值 = {ret}");
                }

                tbValue2.Text = val.ToString();
            }
            catch (Exception ex)
            {
                ProxyTools.ProxyTools.Show("失败 =》" + ex.Message, Color.Red, 0, 3);
            }
        }

        private void btnWriteFloat_Click(object sender, EventArgs e)
        {
            try
            {
                if (_primRobot == null)
                {
                    throw new Exception("未获取机械手实例");
                }

                int index = int.TryParse(tbIndex2.Text, out var value1) ? value1 : throw new Exception("写入Float变量地址为空");
                double val = double.TryParse(tbValue2.Text, out var value2) ? value2 : throw new Exception("写入Float变量地址的值为空");

                int ret = _primRobot.WriteFloatVar(index, val);
                if (ret == 0)
                {
                    ProxyTools.ProxyTools.Show("写入Float变量成功", Color.Green, 3000, 3);
                }
                else
                {
                    throw new Exception($"写入Float变量失败 => 返回值 = {ret}");
                }
            }
            catch (Exception ex)
            {
                ProxyTools.ProxyTools.Show("失败 =》" + ex.Message, Color.Red, 0, 3);
            }
        }

        private void btnReadInt_Click(object sender, EventArgs e)
        {
            try
            {
                if (_primRobot == null)
                {
                    throw new Exception("未获取机械手实例");
                }

                int index = int.TryParse(tbIndex2.Text, out var value) ? value : throw new Exception("读取Int变量地址为空");
                int val = 0;
                int ret = _primRobot.ReadIntVar(1, index, out val);
                if (ret == 0)
                {
                    ProxyTools.ProxyTools.Show("读Int变量成功", Color.Green, 3000, 3);
                }
                else
                {
                    throw new Exception($"读Int变量失败 => 返回值 = {ret}");
                }

                tbValue2.Text = val.ToString();
            }
            catch (Exception ex)
            {
                ProxyTools.ProxyTools.Show("失败 =》" + ex.Message, Color.Red, 0, 3);
            }
        }

        private void btnWriteInt_Click(object sender, EventArgs e)
        {
            try
            {
                if (_primRobot == null)
                {
                    throw new Exception("未获取机械手实例");
                }

                int index = int.TryParse(tbIndex2.Text, out var value1) ? value1 : throw new Exception("写入Int变量地址为空");
                int val = int.TryParse(tbValue2.Text, out var value2) ? value2 : throw new Exception("写入Int变量地址的值为空");

                int ret = _primRobot.WriteIntVar(index, val);
                if (ret == 0)
                {
                    ProxyTools.ProxyTools.Show("写入Int变量成功", Color.Green, 3000, 3);
                }
                else
                {
                    throw new Exception($"写入Int变量失败 => 返回值 = {ret}");
                }
            }
            catch (Exception ex)
            {
                ProxyTools.ProxyTools.Show("失败 =》" + ex.Message, Color.Red, 0, 3);
            }
        }

        private void btnReadPos_Click(object sender, EventArgs e)
        {
            try
            {
                if (_primRobot == null)
                {
                    throw new Exception("未获取机械手实例");
                }

                var pos = _primRobot.GetActualPos();
                if (pos != null)
                {
                    ProxyTools.ProxyTools.Show("读取实时位置成功", Color.Green, 3000, 3);
                }
                else
                {
                    throw new Exception($"读取实时位置失败");
                }

                tbPos.Text = pos.X + "," + pos.Y + "," + pos.Z + "," + pos.A + "," + pos.B + "," + pos.C;
            }
            catch (Exception ex)
            {
                ProxyTools.ProxyTools.Show("失败 =》" + ex.Message, Color.Red, 0, 3);
            }
        }
        #endregion
    }
}
