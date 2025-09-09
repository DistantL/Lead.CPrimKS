using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lead.CPrim.StationCommon;

namespace MessageboxDefine
{
    public partial class MessageboxDefine : Form
    {
        public MessageboxDefine()
        {
            InitializeComponent();
        }

        public MessageboxDefine(string context, string title, string leftButton, string rightButton)
        {
            InitializeComponent();
            this.Text = title;
            this.textBox1.Text = context;
            this.button1.Text = leftButton;
            this.button2.Text = rightButton;
        }
    }
}
