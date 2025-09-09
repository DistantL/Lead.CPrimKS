using Lead.CPrim.Interfaces.StateMachine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.TaskHelper
{
    public partial class TaskSmUI : UserControl
    {
        private TaskStationMachine _taskSm;

        public TaskSmUI(TaskStationMachine taskSm)
        {
            InitializeComponent();
            richTextBox1.Text = string.Empty;
            TextBox textBox = txbCurSta;
            textBox.Text = _taskSm.State.ToString();
            TextBox textBox2 = txbLastSta;
            textBox2.Text = _taskSm.State.ToString();

            _taskSm = taskSm;
            _taskSm.MQRefreshEvent += new MQRefresh(OnMqRcved);
            _taskSm.StateChangeEvent += new StateChange(OnStateChanged);
            _taskSm.OnInitedSuccess += new Inited(OnInit);
        }

        private void btnDispose_Click(object sender, EventArgs e)
        {
            _taskSm.Stop();
            Thread.Sleep(50);
            _taskSm.Terminate();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            if (_taskSm._station.CurrentRecipe.Tasks.Count < 1)
            {
                MessageBox.Show("Recipe Is Null!");
            }
            else
            {
                _taskSm.Initialize(_taskSm._station);
            }
        }

        private void btnClrErr_Click(object sender, EventArgs e)
        {
            _taskSm.ClrErr();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _taskSm.Reset();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _taskSm.Start();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            _taskSm.Pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _taskSm.Stop();
        }

        private void easyButton2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void OnInit(bool success, IStateMachine sender)
        {
            if (btnInit.InvokeRequired)
            {
                BeginInvoke(new Action<bool, IStateMachine>(OnInit), success, sender);
            }
            else if (success)
            {
                btnInit.Enabled = false;
                btnDispose.Enabled = true;
            }
            else
            {
                btnInit.Enabled = true;
                btnDispose.Enabled = false;
            }
        }

        private void OnMqRcved(UserEvent msg, IStateMachine sender)
        {
            //IL_0068: Unknown result type (might be due to invalid IL or missing references)
            if (richTextBox1.InvokeRequired)
            {
                if (base.IsHandleCreated)
                {
                    BeginInvoke(new Action<UserEvent, IStateMachine>(OnMqRcved), msg, sender);
                }
            }
            else
            {
                string text = DateTime.Now.ToString("HH:mm:ss.fff") + "  Event  ==>" + ((object)msg.EventType).ToString() + " ," + msg.EventSender.Name + "\r\n";
                richTextBox1.AppendText(text);
                richTextBox1.ScrollToCaret();
            }
        }

        private void OnStateChanged(SmStates curState, IStateMachine sender)
        {
            if (richTextBox1.InvokeRequired)
            {
                if (IsHandleCreated)
                {
                    BeginInvoke(new Action<SmStates, IStateMachine>(OnStateChanged), curState, sender);
                }
                return;
            }
            switch (curState)
            {
                case SmStates.WaitReset:
                    btnReset.Enabled = true;
                    btnStart.Enabled = false;
                    btnPause.Enabled = false;
                    btnStop.Enabled = false;
                    break;

                case SmStates.Resetting:
                    btnReset.Enabled = true;
                    btnStart.Enabled = false;
                    btnPause.Enabled = false;
                    btnStop.Enabled = true;
                    break;

                case SmStates.WaitRun:
                    btnReset.Enabled = false;
                    btnStart.Enabled = true;
                    btnPause.Enabled = false;
                    btnStop.Enabled = true;
                    break;

                case SmStates.Running:
                    btnReset.Enabled = false;
                    btnStart.Enabled = false;
                    btnPause.Enabled = true;
                    btnStop.Enabled = true;
                    break;

                case SmStates.Pause:
                    btnReset.Enabled = false;
                    btnStart.Enabled = true;
                    btnPause.Enabled = false;
                    btnStop.Enabled = true;
                    break;

                case SmStates.WaitEStopClr:
                    btnReset.Enabled = false;
                    btnStart.Enabled = false;
                    btnPause.Enabled = false;
                    btnStop.Enabled = false;
                    break;

                case SmStates.WaitClrPrimErr:
                    btnReset.Enabled = false;
                    btnStart.Enabled = false;
                    btnPause.Enabled = false;
                    btnStop.Enabled = false;
                    break;

                case SmStates.WaitClrErr:
                    btnReset.Enabled = false;
                    btnStart.Enabled = false;
                    btnPause.Enabled = false;
                    btnStop.Enabled = true;
                    break;

                default:
                    break;
            }

            string text = DateTime.Now.ToString("HH:mm:ss.fff") + "  State  ==>" + curState.ToString() + "\r\n";
            txbCurSta.Text = curState.ToString();
            TextBox textBox = txbLastSta;
            textBox.Text = _taskSm.LastState.ToString();
            richTextBox1.AppendText(text);
            richTextBox1.ScrollToCaret();
        }

        private void TaskSmUI_Load(object sender, EventArgs e)
        {
            labSmName.Text = _taskSm.Name;
        }
    }
}
