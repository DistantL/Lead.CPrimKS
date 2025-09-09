using Lead.CPrim.StationCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageboxDefine
{
    public partial class Debug : Form
    {
        public delegate void Tray_Click_Del(string btn_text, Button btn);
        public event Tray_Click_Del Tray_Click_Event;
        Button[] _buttons = new Button[24];
        private static int _selectButton = -1;
        public static Debug Instance = new Debug();
        StationConfig station;
        private Debug()
        {
            InitializeComponent();
        }

        private void tray_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (_selectButton >= 1 && _selectButton <= 24 && _selectButton != int.Parse(button.Text))
            {
                label1.Text = string.Format("你已经选择的是第{0}行，第{1}列，请取消后重新选择", (_selectButton - 1) / 6 + 1, (_selectButton - 1) % 6 + 1);
                label1.ForeColor = Color.Orange;
                return;
            }
            if (button.BackColor == SystemColors.Control)
            {
                button.BackColor = Color.Green;
                _selectButton = int.Parse(button.Text.Trim());
                label1.Text = string.Format("你选择的是第{0}行，第{1}列", (_selectButton - 1) / 6 + 1, (_selectButton - 1) % 6 + 1);
                label1.ForeColor = Color.DarkBlue;
                Tray_Click_Event?.Invoke(button.Text, button);
            }
            else if (button.BackColor == Color.Green)
            {
                button.BackColor = SystemColors.Control;
                label1.Text = string.Format("你将第{0}行，第{1}列进行取消，请重新选择", (_selectButton - 1) / 6 + 1, (_selectButton - 1) % 6 + 1);
                label1.ForeColor = Color.Gray;
                _selectButton = -1;
            }
        }

        private void Debug_Load(object sender, EventArgs e)
        {
            _buttons = new Button[] { button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22 };
            foreach (var item in _buttons)
            {
                item.Click += tray_Click;
                item.BackColor = SystemColors.Control;
                item.ForeColor = Color.Gray;
            }
            station = StationManager.Instance.Stations[StationManager.Instance.CurrentStationName];
            timer1.Start();
        }

        private void Debug_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void Debug_Shown(object sender, EventArgs e)
        {
            if (_selectButton >= 1 && _selectButton <= 24)
            {
                label1.Text = string.Format("你选择的是第{0}行，第{1}列", (_selectButton - 1) / 6 + 1, (_selectButton - 1) % 6 + 1);
                label1.ForeColor = Color.DarkBlue;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == SystemColors.Control)
            {
                station.SetDataInfoVal("机台清料", true);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if ((bool)station.GetDataInfoVal("机台清料"))
                {
                    button1.BackColor = Color.Green;
                }
                else
                {
                    button1.BackColor = SystemColors.Control;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
