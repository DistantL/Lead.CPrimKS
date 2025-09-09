using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpcConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnChangeIPCState_Click(object sender, EventArgs e)
        {
            if(BtnChangeIPCState.Text == "连接")
            {
                LblIPCInfo.Text = LblIPCInfo.Tag + "IPC已连接";
                BtnChangeIPCState.Text = "断开";
            }
            else if(BtnChangeIPCState.Text == "断开")
            {
                LblIPCInfo.Text = LblIPCInfo.Tag + "IPC已断开";
                BtnChangeIPCState.Text = "连接";
            }
        }
    }
}
