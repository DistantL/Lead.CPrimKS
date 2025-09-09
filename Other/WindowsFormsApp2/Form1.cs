using Lead.CPrim.ProxyTools.SunnyUI.Fonts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            //UIFontImages uIFontImages = new UIFontImages();
            //uIFontImages.ShowDialog();
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                uiComboBox1.Items.Add(i);
                uiComboBox2.Items.Add(i);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rd = new Random();
            int index = rd.Next(0, 6);
            if(uiComboBox1.Items.Count <= 0)
            {
                return;
            }
            uiComboBox1.SelectedIndex = index;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            uiComboBox2.SelectedIndex = 2;
        }
    }
}
