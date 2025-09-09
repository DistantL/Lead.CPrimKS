using Lead.CPrim.Interfaces;
using Sunny.UI;
using System;
using System.Windows.Forms;
using System.Linq;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;

namespace Lead.CPrim.ProxyTools
{
    public partial class NewForm : UIForm
    {
        /// <summary>UIRadioButton</summary>
        private UIRadioButton[] radios = new UIRadioButton[6];
        /// <summary>任务名称</summary>
        private string _taskName = "";
        /// <summary>模式</summary>	
        private int _mode = 0;

        public NewForm(string title, string[] radioName, int defaultRadioButton)
        {
            InitializeComponent();

            Text = string.IsNullOrEmpty(title) ? "标题" : title;
            radios = new UIRadioButton[6] { rdoMode1, rdoMode2, rdoMode3, rdoMode4, rdoMode5, rdoMode6 };
            if (radioName == null || radioName.Length != 6)
            {
                foreach (var item in radios)
                {
                    item.Visible = false;
                }
            }
            else
            {
                int use = 0;
                for (int i = 0; i < radioName.Length; i++)
                {
                    if (string.IsNullOrEmpty(radioName[i]))
                    {
                        radios[i].Visible = false;
                    }
                    else
                    {
                        radios[i].Visible = true;
                        radios[i].Text = radioName[i].Trim();
                        use++;
                    }
                }

                if (defaultRadioButton >= 1 && defaultRadioButton <= use)
                {
                    radios[defaultRadioButton - 1].Checked = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if(!radios.All( r => r.Visible == false))
            {
                if(radios.All(r => r.Checked == false))
                {
                    UIMessageTip.ShowWarning("请选择模式！！！");
                    return;
                }
            }
            if (!string.IsNullOrEmpty(tbTaskName.Text))
            {
                _taskName = tbTaskName.Text;
                _mode = rdoMode1.Checked ? 1 : (rdoMode2.Checked ? 2 : (rdoMode3.Checked ? 3 : (rdoMode4.Checked ? 4 : (rdoMode5.Checked ? 5 : (rdoMode6.Checked ? 6 : -1)))));
                DialogResult = DialogResult.OK;
            }
            else
            {
                Close();
            }
        }

        public string GetTaskName()
        {
            return _taskName;
        }
        public int GetMode()
        {
            return _mode;
        }
    }
}