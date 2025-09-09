using Lead.CPrim.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.Cprim.PrimRobotInovance
{
    public partial class PrimConfigControl : UserControl
    {
        private PrimRobotInovance _primRobotInovance;

        public string PrimRobotInovanceName
        {
            set => tbPrimName.Text = value;
        }

        public PrimConfigControl()
        {
            InitializeComponent();
        }

        public PrimConfigControl(PrimRobotInovance prim)
        {
            InitializeComponent();
            _primRobotInovance = prim;

        }
        
        private void PrimConfigControl_Load(object sender, EventArgs e)
        {
            PrimRobotInovanceName = _primRobotInovance.Name;

            tbRobotIp.Text = _primRobotInovance.RobotIp;
            tbPort.Text = _primRobotInovance.Port.ToString();
            cmbRobotId.Text = _primRobotInovance.RobotId.ToString();
            tbPassward.Text = _primRobotInovance.Password;

            SetPrimConnState(((IPrim)_primRobotInovance).PrimConnStat);
            SetPrimRunState(((IPrim)_primRobotInovance).PrimRunStat);
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

        private void tbPort_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbPort.Text) && int.TryParse(tbPort.Text, out var port))
            {
                _primRobotInovance.Port = port;
            }
        }
        private void tbRobotIp_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbRobotIp.Text))
            {
                _primRobotInovance.RobotIp = tbRobotIp.Text;
            }
        }
        private void cmbRobotId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbRobotId.Text) && int.TryParse(cmbRobotId.Text, out var robotId))
            {
                _primRobotInovance.RobotId = robotId;
            }
        }
        private void tbPassward_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbPassward.Text))
            {
                _primRobotInovance.Password = tbPassward.Text;
            }
        }
        private void btnInit_Click(object sender, EventArgs e)
        {
            _primRobotInovance.IPrimInit();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var result = "";
            _primRobotInovance.IPrimConnect(ref result);
            _primRobotInovance.IPrimStart();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _primRobotInovance.IPrimStop();
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbRobotIp.Text))
            {
                _primRobotInovance.RobotIp = tbRobotIp.Text;
            }

            if (!string.IsNullOrEmpty(tbPort.Text) && int.TryParse(tbPort.Text, out var port))
            {
                _primRobotInovance.Port = port;
            }

            if (!string.IsNullOrEmpty(cmbRobotId.Text) && int.TryParse(cmbRobotId.Text, out var no))
            {
                _primRobotInovance.RobotId = no;
            }

            if (!string.IsNullOrEmpty(tbPassward.Text))
            {
                _primRobotInovance.Password = tbPassward.Text;
            }

            _primRobotInovance.Name = tbPrimName.Text;
        }

    }
}
