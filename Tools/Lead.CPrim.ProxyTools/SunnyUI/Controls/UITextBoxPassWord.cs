using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.SunnyUI.Controls
{
    public sealed partial class UITextBoxPassWord : UITextBox
    {
        public UITextBoxPassWord()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg != 0x007B && m.Msg != 0x0301 && m.Msg != 0x0302)
            {
                base.WndProc(ref m);
            }
        }
    }
}
