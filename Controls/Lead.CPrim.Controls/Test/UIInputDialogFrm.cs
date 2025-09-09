using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;

namespace Lead.CPrim.Controls
{
    public partial class UIInputDialogFrm : UIPage
    {
        public UIInputDialogFrm()
        {
            InitializeComponent();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            string str = "";
            if(this.InputStringDialog(ref str))
            {
                this.ShowInfoDialog(str);
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            string str = "";
            if(this.InputPasswordDialog(ref str))
            {
                this.ShowInfoDialog(str);
            }
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            int str = 0;
            if (this.InputIntegerDialog(ref str))
            {
                this.ShowInfoDialog(str.ToString());
            }
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            double str = 0.0;
            if (this.InputDoubleDialog(ref str))
            {
                this.ShowInfoDialog(str.ToString());
            }
        }
    }
}
