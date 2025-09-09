using System.Windows.Forms;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.PrimLEIS_E
{
    public partial class PrimOutputControl : UserControl
    {
        public PrimOutputControl()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            label1.Text = NLocalizer.GetString("PrimLEIS_PrimOutControl_OutputUI", "OutputUI");
        }

        public void SetPrimConnState(PrimConnState conn)
        {
            //throw new System.NotImplementedException();
        }

        public void SetPrimRunState(PrimRunState run)
        {
            //throw new System.NotImplementedException();
        }
    }
}