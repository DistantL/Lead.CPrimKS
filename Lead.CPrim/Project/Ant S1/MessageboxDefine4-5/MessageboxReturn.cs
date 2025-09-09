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
    public partial class MessageboxReturn : Form
    {
        private StationConfig _station;

        public MessageboxReturn(string context, string title, string leftButton, string rightButton)
        {
            InitializeComponent();
            this.Text = title;
            this.textBox1.Text = context;
            this.button1.Text = leftButton;
            this.button2.Text = rightButton;
            _station = StationManager.Instance.Stations["S1"];
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((bool)_station.GetDataInfoVal("A线通知供料"))
                button1.Enabled = true;
            else
                button1.Enabled = false;

            if ((bool)_station.GetDataInfoVal("B线通知供料"))
                button2.Enabled = true;
            else
                button2.Enabled = false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            timer1.Enabled = false;
            base.OnClosing(e);
        }
    }
}
