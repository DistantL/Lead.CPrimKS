using Lead.CPrim.Interfaces.Ele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;

namespace ThreadSafty_StreamlineControl
{
    public partial class Form_SingleAxisTest : Form
    {
        private ITask _task;
        public IEleAxis CurrentAxis { get; private set; }

        private Dictionary<string, IEleCartesian> dic_Cartesian;
        public Stopwatch StopWatch { get; }

        public int CurrentTestCount { get; set; }

        /// <summary>
        /// pos1,pos2,speed,time1,time2,testMaxCount
        /// </summary>
        public event Action<double, double, double, int, int, int> StartTest;
        public event Action StopTest;
        public Form_SingleAxisTest(ITask task, Dictionary<string, IEleCartesian> dic_Cartesian)
        {
            this._task = task;
            this.dic_Cartesian = dic_Cartesian;
            InitializeComponent();

            StopWatch = new Stopwatch();

            if (dic_Cartesian != null && dic_Cartesian.Count != 0)
            {
                InitTreeView(dic_Cartesian);
            }
        }

        public void InitTreeView(Dictionary<string, IEleCartesian> dic_Cartesian)
        {
            foreach (var item in dic_Cartesian)
            {
                var node = treeView1.Nodes.Add(item.Key);

                foreach (var axis in item.Value.Axises)
                {
                    if (axis.Value.Enable)
                    {
                        node.Nodes.Add(axis.Value.Name);
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CurrentAxis != null)
            {
                lb_CurrentPosition.Text = CurrentAxis.ActualPos.ToString("f4");
                lb_CurrentSpeed.Text = CurrentAxis.ActualVel.ToString("f3");
                lb_CurrentPauseTime.Text = StopWatch.ElapsedMilliseconds.ToString() + "ms";

                if (!bt_Start.Enabled)
                {
                    if (_task.CurStep == 10)
                    {
                        bt_Start.Enabled = true;
                    }
                }

                lb_CurrentTestCount.Text = CurrentTestCount.ToString();
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 1 && dic_Cartesian.ContainsKey(e.Node.Parent.Text))
            {
                CurrentAxis = dic_Cartesian[e.Node.Parent.Text].GetAxisByName(e.Node.Text);
                if (CurrentAxis != null)
                {
                    lb_AxisName.Text = CurrentAxis.CartesianName + CurrentAxis.Name;
                    timer1.Enabled = true;
                }
            }
        }

        private void bt_Start_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentAxis != null)
                {
                    bt_Start.Enabled = false;

                    if (!double.TryParse(tb_Pos1.Text, out double pos1))
                    {
                        MessageBox.Show(lb_Pos1.Text + "异常!");
                        return;
                    }
                    if (!double.TryParse(tb_Pos2.Text, out double pos2))
                    {
                        MessageBox.Show(lb_Pos2.Text + "异常!");
                        return;
                    }
                    if (!int.TryParse(tb_Pos1PauseTime.Text, out int time1))
                    {
                        MessageBox.Show(lb_Pos1PauseTime.Text + "异常!");
                        return;
                    }
                    if (!int.TryParse(tb_Pos2PauseTime.Text, out int time2))
                    {
                        MessageBox.Show(lb_Pos2PauseTime.Text + "异常!");
                        return;
                    }
                    if (!double.TryParse(tb_Speed.Text, out double speed))
                    {
                        MessageBox.Show(lb_Speed.Text + "异常!");
                        return;
                    }
                    if (speed < 5 || speed > 400)
                    {
                        MessageBox.Show("速度不在范围[5,400]");
                        return;
                    }
                    if (!int.TryParse(tb_TestCount.Text, out int count))
                    {
                        MessageBox.Show(lb_TestCount.Text + "异常!");
                        return;
                    }

                    StartTest?.Invoke(pos1, pos2, speed, time1, time2, count);
                }
                else
                {
                    MessageBox.Show("请先选择轴");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void bt_Stop_Click(object sender, EventArgs e)
        {
            if (CurrentAxis != null)
            {
                StopTest?.Invoke();
                Thread.Sleep(1000);
                bt_Start.Enabled = true;
                StopWatch.Stop();
                StopWatch.Reset();
            }
            else
            {
                MessageBox.Show("请先选择轴");
            }
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (CurrentAxis != null && !CurrentAxis.IsStop)
            {
                StopTest?.Invoke();
                Thread.Sleep(1000);
                bt_Start.Enabled = true;
            }
        }

        public string Getcmd()
        {
            return tb_cmd.Text;
        }
    }
}
