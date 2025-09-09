using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Sunny.UI;
using System.Windows.Forms;

namespace Lead.CPrim.PrimFinsNet
{
    public partial class PrimOutputControl : UIUserControl
    {
        public PrimOutputControl()
        {
            InitializeComponent();
            InitializeUI();
            SetStyleFlags();
        }

        private void InitializeUI()
        {
            label1.Text = NLocalizer.GetString("PrimFinsNet_PrimOutputControl_OutputUI", "OutputUI");
        }
    }
}