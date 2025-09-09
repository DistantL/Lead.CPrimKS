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
    public partial class MessageboxTray : Form
    {
        public delegate void Button_Click_Del(string btn_text, Button btn);
        public event Button_Click_Del Button_Click_Event;
        Button[] _buttons = new Button[24];
        private static int _selectButton = -1;
        private Button defaltButton = null;
        public MessageboxTray()
        {
            InitializeComponent();
        }

        public MessageboxTray(string context, string title, string leftButton, string rightButton)
        {
            InitializeComponent();
            this.Text = title;
            this.label1.Text = context;
            this.button1.Text = leftButton;
            this.button2.Text = rightButton;
            _selectButton = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_selectButton < 1 || _selectButton > 24)
            {
                label1.Text = "你尚未选择启动后取第几片料，请选择";
                label1.ForeColor = Color.Red;
                return;
            }
            Button_Click_Event?.Invoke(defaltButton.Text, defaltButton);
            base.DialogResult = DialogResult.Yes;
        }

        private void button_Click(object sender, EventArgs e)
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
                defaltButton = button;
            }
            else if (button.BackColor == Color.Green)
            {
                button.BackColor = SystemColors.Control;
                label1.Text = string.Format("你将第{0}行，第{1}列进行取消，请重新选择", (_selectButton - 1) / 6 + 1, (_selectButton - 1) % 6 + 1);
                label1.ForeColor = Color.Gray;
                _selectButton = -1;
                defaltButton = null;
            }
        }

        private void MessageboxTray_Load(object sender, EventArgs e)
        {
            _buttons = new Button[] { button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25, button26 };
            foreach (var item in _buttons)
            {
                item.Click += button_Click;
                item.BackColor = SystemColors.Control;
                item.ForeColor = Color.Gray;
            }
        }
    }
}
