using System;
using System.Drawing;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleAnalogOutput
{
    public partial class DebugUI : UserControl
    {
        public DebugUI()
        {
            InitializeComponent();
        }

        public void SetEleRunState(EleRunState state)
        {
            if (tBoxState.InvokeRequired) //指示调用方在对控件进行方法调用时是否必须调用 Invoke 方法，因为调用方位于创建控件所在的线程以外的线程中
            {
                var update = new UpdateEleRunState(SetEleRunState);
                Invoke(update, state);
            }
            else
            {
                switch (state)
                {
                    case EleRunState.Idle:
                        tBoxState.BackColor = Color.Khaki;
                        tBoxState.Text = "Idle";
                        break;
                    case EleRunState.Running:
                        tBoxState.BackColor = Color.LightGreen;
                        tBoxState.Text = "Running";
                        break;
                    case EleRunState.Err:
                        tBoxState.BackColor = Color.SandyBrown;
                        tBoxState.Text = "Err";
                        break;
                    case EleRunState.Other:
                        tBoxState.BackColor = Color.Khaki;
                        tBoxState.Text = "Other";
                        break;
                }
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
        }

        private delegate void UpdateEleRunState(EleRunState state);

        private delegate void UpdateControl();
    }
}