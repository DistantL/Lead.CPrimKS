using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.Interfaces.Ele;

namespace Lead.CPrim.EleCartesian
{
    public partial class MoveForm : Form
    {
        private readonly IEleAxis[] _axis = new IEleAxis[6];
        private readonly int[] _axisIndex = new int[6];
        private readonly CheckBox[] _chkEnable;
        private readonly double[] _curPos;
        private readonly Label[] _lbAxis;
        private readonly TextBox[] _tbCurPos;
        private readonly TextBox[] _tbMovePos;
        private string[] _axisName;

        public MoveForm()
        {
            InitializeComponent();
            InitializeUI();

            _chkEnable = new[] {chkEnableX, chkEnableY, chkEnableZ, chkEnableU, chkEnableV, chkEnableW};
            _chkEnable.ToList().ForEach(p => p.CheckedChanged += ChkEnable_CheckedChanged);

            _tbCurPos = new[] {tbCurPosX, tbCurPosY, tbCurPosZ, tbCurPosU, tbCurPosV, tbCurPosW};
            _tbMovePos = new[] {tbMovePosX, tbMovePosY, tbMovePosZ, tbMovePosU, tbMovePosV, tbMovePosW};
            _axisName = new[] {"AxisX", "AxisY", "AxisZ", "AxisU", "AxisV", "AxisW"};
            _lbAxis = new[] {lbX, lbY, lbZ, lbU, lbV, lbW};
            _curPos = new double[6];
        }

        public MoveForm(List<Pos> posList, Pos movePos)
        {
            InitializeComponent();
            InitializeUI();

            _chkEnable = new[] {chkEnableX, chkEnableY, chkEnableZ, chkEnableU, chkEnableV, chkEnableW};
            _chkEnable.ToList().ForEach(p => p.CheckedChanged += ChkEnable_CheckedChanged);

            _tbCurPos = new[] {tbCurPosX, tbCurPosY, tbCurPosZ, tbCurPosU, tbCurPosV, tbCurPosW};
            _tbMovePos = new[] {tbMovePosX, tbMovePosY, tbMovePosZ, tbMovePosU, tbMovePosV, tbMovePosW};
            _axisName = new[] {"AxisX", "AxisY", "AxisZ", "AxisU", "AxisV", "AxisW"};
            _lbAxis = new[] {lbX, lbY, lbZ, lbU, lbV, lbW};
            _curPos = new double[6];
        }

        public EleCartesian Ele { set; get; }
        public double JumpHeight { set; get; }
        public string MoveMode { set; get; }
        public PosCartesian ObjPos { set; get; }

        private void BtnMoveStart_Click(object sender, EventArgs e)
        {
            btnStartMove.Enabled = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                var pos = Ele.Points.MotionPoints.FirstOrDefault(p => p.Name == cmbMovePos.Text);
                if (pos != null)
                {
                    var curpos = _curPos;
                    var objpos = _tbMovePos.Select(t => double.Parse(t.Text)).Take(curpos.Length).ToArray();
                    var moveEnable = _chkEnable.Select(c => c.Checked).ToArray();

                    for (var i = 0; i < curpos.Length; i++)
                        if (!_chkEnable[i].Checked)
                            objpos[i] = curpos[i];
                    if (cmbMoveMode.Text == "Jump")
                    {
                        if (MessageBox.Show(
                            ProxyTools.NLocalizer.GetString("EleCartesian_MotionForm_StartJump", "Start Jump") +
                            $@" {string.Join(", ", curpos.Select(p => p.ToString("F3")))} --> {string.Join(", ", objpos.Select(p => p.ToString("F3")))} ?",
                            "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                            return;

                        var ret = Ele.GroupJumpAbs(pos.Index, -1000, false, 50, 50);
                        if (ret != 0)
                            MessageBox.Show(ProxyTools.NLocalizer.GetString("EleCartesian_MotionForm_MoveFail", "Move Fail"));
                    }

                    if (cmbMoveMode.Text == "MoveP")
                    {
                        if (MessageBox.Show(
                            ProxyTools.NLocalizer.GetString("EleCartesian_MotionForm_StartMoveP", "Start Move ") +
                            $@"{string.Join(", ", curpos.Select(p => p.ToString("F3")))} To {string.Join(", ", objpos.Select(p => p.ToString("F3")))} ?",
                            "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                            return;

                        var ret = Ele.GroupMoveAbs(pos.Index, 50, 50);
                        if (ret != 0)
                            MessageBox.Show(ProxyTools.NLocalizer.GetString("EleCartesian_MotionForm_MoveFail", "Move Fail"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            finally
            {
                btnStartMove.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void BtnMoveStop_Click(object sender, EventArgs e)
        {
            Ele.GroupStop();
        }

        private void ChkEnable_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb != null)
            {
                var i = Array.IndexOf(_chkEnable, cb);
                if (i >= 0)
                {
                    _tbMovePos[i].Enabled = cb.Checked;
                    _tbMovePos[i].Enabled = cb.Checked;
                }
            }
        }

        private void CmbPos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pos = Ele.Points.MotionPoints.FirstOrDefault(p => p.Name == cmbMovePos.Text);
            if (pos != null)
            {
                _tbMovePos[0].Text = pos.X.ToString("F3");
                _tbMovePos[1].Text = pos.Y.ToString("F3");
                _tbMovePos[2].Text = pos.Z.ToString("F3");
                _tbMovePos[3].Text = pos.U.ToString("F3");
                _tbMovePos[4].Text = pos.V.ToString("F3");
                _tbMovePos[5].Text = pos.W.ToString("F3");
            }
            else
            {
                for (var i = 0; i < _tbMovePos.Length; i++) _tbMovePos[i].Text = "0";
            }
        }

        private void InitializeUI()
        {
            label10.Text = ProxyTools.NLocalizer.GetString("EleMotion_MotionForm_Mode", "Mode");
            label8.Text = ProxyTools.NLocalizer.GetString("EleMotion_MotionForm_CurrentPosition", "Current Position");
            label7.Text = ProxyTools.NLocalizer.GetString("EleMotion_MotionForm_Position", "Position");
            label11.Text = ProxyTools.NLocalizer.GetString("EleMotion_MotionForm_LimitCheck", "Limit Check");
            label9.Text = ProxyTools.NLocalizer.GetString("EleMotion_MotionForm_ZRetractedHeight", "Z retraction height");
            btnStartMove.Text = ProxyTools.NLocalizer.GetString("EleMotion_MotionForm_Start", "Start");
            btnStopMove.Text = ProxyTools.NLocalizer.GetString("EleMotion_MotionForm_Stop", "Stop");
        }

        private void LoadAxises()
        {
            try
            {
                var axisX = Ele.Axises.First(p => p.Value.Name.ToLower().Contains("_x"));
                _axis[0] = axisX.Value;
                _axisIndex[0] = axisX.Key;
            }
            catch
            {
                _axis[0] = null;
                _axisIndex[0] = -1;
            }

            try
            {
                var axisY = Ele.Axises.First(p => p.Value.Name.ToLower().Contains("_y"));
                _axis[1] = axisY.Value;
                _axisIndex[1] = axisY.Key;
            }
            catch
            {
                _axis[1] = null;
                _axisIndex[1] = -1;
            }

            try
            {
                var axisZ = Ele.Axises.First(p => p.Value.Name.ToLower().Contains("_z"));
                _axis[2] = axisZ.Value;
                _axisIndex[2] = axisZ.Key;
            }
            catch
            {
                _axis[2] = null;
                _axisIndex[2] = -1;
            }

            try
            {
                var axisU = Ele.Axises.First(p => p.Value.Name.ToLower().Contains("_u"));
                _axis[3] = axisU.Value;
                _axisIndex[3] = axisU.Key;
            }
            catch
            {
                _axis[3] = null;
                _axisIndex[3] = -1;
            }

            try
            {
                var axisV = Ele.Axises.First(p => p.Value.Name.ToLower().Contains("_v"));
                _axis[4] = axisV.Value;
                _axisIndex[4] = axisV.Key;
            }
            catch
            {
                _axis[4] = null;
                _axisIndex[4] = -1;
            }

            try
            {
                var axisW = Ele.Axises.First(p => p.Value.Name.ToLower().Contains("_w"));
                _axis[5] = axisW.Value;
                _axisIndex[5] = axisW.Key;
            }
            catch
            {
                _axis[5] = null;
                _axisIndex[5] = -1;
            }
        }

        private void MoveForm_Load(object sender, EventArgs e)
        {
            chkCheckLimit.Checked = true;
            cmbMoveMode.Items.AddRange(new[] {"MoveP", "Jump"});
            cmbJumpHeight.Items.AddRange(new object[] {0, -10, -20, -30, -50});

            for (var i = 0; i < _chkEnable.Length; i++)
            {
                _chkEnable[i].Checked = true;
                _chkEnable[i].Enabled = true;
                _tbCurPos[i].Enabled = true;
                _tbMovePos[i].Enabled = true;
            }

            if (Ele.Points.MotionPoints != null)
                cmbMovePos.Items.AddRange(Ele.Points.MotionPoints.Select(p => $"{p.Name}").ToArray());
            cmbMovePos.SelectedItem = $"{ObjPos.Name}";

            cmbMoveMode.SelectedItem = MoveMode;
            if (!cmbJumpHeight.Items.Contains(JumpHeight)) cmbJumpHeight.Items.Add(JumpHeight);
            cmbJumpHeight.SelectedItem = JumpHeight;

            LoadAxises();

            tmrCycle.Interval = 100;
            tmrCycle.Enabled = true;
        }

        private void TmrCycle_Tick(object sender, EventArgs e)
        {
            for (var i = 0; i < _axis.Length; i++)
                if (_axisIndex[i] != -1)
                {
                    _curPos[i] = Ele.Axises[_axisIndex[i]].ActualPos;
                    _lbAxis[i].BackColor = Ele.Axises[_axisIndex[i]].Enable ? Color.Lime : Color.White;
                    _tbCurPos[i].Text = _curPos[i].ToString("F3");
                    _tbCurPos[i].BackColor =
                        Ele.Axises[_axisIndex[i]].InPel || Ele.Axises[_axisIndex[i]].InMel ||
                        Ele.Axises[_axisIndex[i]].InSPel || Ele.Axises[_axisIndex[i]].InSMel
                            ? Color.Red
                            : Color.White;
                }
        }
    }
}