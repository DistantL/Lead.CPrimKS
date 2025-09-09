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
    public partial class UISelectText : UIUserControl
    {
        private string _selectText1;
        private string _selectText2;
        private string _selectText3;

        private string _currentSelectText;

        public UISelectText()
        {
            InitializeComponent();
        }

        public void SetSelectText(string selectText1, string selectText2, string selectText3)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string,string,string>(SetSelectText), new object[] { selectText1, selectText2, selectText3 });
                return;
            }

            _currentSelectText = selectText1;

            _selectText1 = selectText1;
            _selectText2 = selectText2;
            _selectText3 = selectText3;

            uiButton1.Text = selectText1;
            uiButton2.Text = selectText2;
            uiButton3.Text = selectText3;


            if(string.IsNullOrWhiteSpace(selectText3))
            {
                tableLayoutPanel1.ColumnStyles.RemoveAt(2);
                this.Size = new Size((int)(this.Size.Width / 3.0 * 2.0), this.Size.Height);
                uiButton3.Visible = false;
            }
        }

        public int SelectTextIndex
        {
            get
            {
                if(uiButton1.Selected)
                {
                    return 0;
                }
                
                else if(uiButton2.Selected)
                {
                    return 1;
                }
                else if (uiButton3.Selected)
                {
                    return 2;
                }
                return 0;
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            _currentSelectText = _selectText1;
            uiButton1.Selected = true;
            uiButton2.Selected = false;
            uiButton3.Selected = false;

            OnClick(e);
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            _currentSelectText = _selectText2;
            uiButton1.Selected = false;
            uiButton2.Selected = true;
            uiButton3.Selected = false;

            OnClick(e);
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            _currentSelectText = _selectText3;
            uiButton1.Selected = false;
            uiButton2.Selected = false;
            uiButton3.Selected = true;

            OnClick(e);
        }
    }
}
