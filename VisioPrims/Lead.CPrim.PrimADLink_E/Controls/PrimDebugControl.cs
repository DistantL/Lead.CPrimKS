using System.Windows.Forms;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimADLink_E
{
    public partial class PrimDebugControl : UserControl
    {
        private IPrim _prim;

        public PrimDebugControl()
        {
            InitializeComponent();
        }

        public PrimDebugControl(PrimADLink_E prim)
        {
            InitializeComponent();
            _prim = prim;
        }

        private delegate void UpdatePrimConnState(PrimConnState state);

        private delegate void UpdatePrimRunState(PrimRunState state);

        public void SetPrimConnState(PrimConnState state)
        {
            //if (tBoxConnState.InvokeRequired)
            //{
            //    UpdatePrimConnState update = new UpdatePrimConnState(SetPrimConnState);
            //    this.Invoke(update, new object[1] { state });
            //}
            //else
            //{
            //    switch (state)
            //    {
            //        case PrimConnState.UnConnected:
            //            tBoxConnState.BackColor = Color.Khaki;
            //            tBoxConnState.Text = "UnConnected";
            //            btnInit.BackColor = Color.SkyBlue;
            //            btnRun1.BackColor = Color.LightGreen;
            //            btnInit.Enabled = true;
            //            btnRun1.Enabled = true;
            //            break;
            //        case PrimConnState.Connected:
            //            tBoxConnState.BackColor = Color.LightGreen;
            //            tBoxConnState.Text = "Connected";
            //            btnInit.BackColor = Color.Gray;
            //            btnInit.Enabled = false;
            //            break;
            //        case PrimConnState.Other:
            //            tBoxConnState.BackColor = Color.Khaki;
            //            tBoxConnState.Text = "UnConnected";
            //            btnInit.BackColor = Color.SkyBlue;
            //            btnRun1.BackColor = Color.LightGreen;
            //            btnInit.Enabled = true;
            //            btnRun1.Enabled = true;
            //            break;
            //    }
            //}
        }

        public void SetPrimRunState(PrimRunState state)
        {
            //if (tBoxRunState.InvokeRequired) //指示调用方在对控件进行方法调用时是否必须调用 Invoke 方法，因为调用方位于创建控件所在的线程以外的线程中
            //{
            //    UpdatePrimRunState update = new UpdatePrimRunState(SetPrimRunState);
            //    this.Invoke(update, new object[1] { state });
            //}
            //else
            //{
            //    switch (state)
            //    {
            //        case PrimRunState.Idle:
            //            tBoxRunState.BackColor = Color.Khaki;
            //            tBoxRunState.Text = "Idle";
            //            break;
            //        case PrimRunState.Running:
            //            tBoxRunState.BackColor = Color.LightGreen;
            //            tBoxRunState.Text = "Running";
            //            btnRun1.BackColor = Color.Gray;
            //            btnRun1.Enabled = false;
            //            btnInit.BackColor = Color.Gray;
            //            btnInit.Enabled = false;
            //            btnStop1.Enabled = true;
            //            btnStop1.BackColor = Color.SandyBrown;
            //            break;
            //        case PrimRunState.Stop:
            //            tBoxRunState.BackColor = Color.Brown;
            //            tBoxRunState.Text = "Stop";
            //            btnRun1.BackColor = Color.LightGreen;
            //            btnRun1.Enabled = true;
            //            btnInit.BackColor = Color.LightGreen;
            //            btnInit.Enabled = true;
            //            btnStop1.Enabled = false;
            //            btnStop1.BackColor = Color.Gray;
            //            break;
            //        case PrimRunState.Err:
            //            tBoxRunState.BackColor = Color.SandyBrown;
            //            tBoxRunState.Text = "Err";
            //            break;
            //        case PrimRunState.Other:
            //            tBoxRunState.BackColor = Color.Khaki;
            //            tBoxRunState.Text = "Idle";
            //            btnRun1.Enabled = false;
            //            btnRun1.BackColor = Color.Gray;
            //            btnStop1.Enabled = false;
            //            btnStop1.BackColor = Color.Gray;
            //            break;
            //    }
            //}
        }
    }
}