using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.CmpTrigHelper
{
	public partial class AglSelForm : Form
	{
        #region Field
        private readonly List<string> _agls = new List<string>(); 
        #endregion



        #region Ctor
        public AglSelForm()
        {
            InitializeComponent();
        }

        public AglSelForm(List<string> allAgls, ref List<string> selAgls) : this()
        {
            _agls = selAgls;

            chkListAgl.Items.Clear();
            allAgls.ForEach(delegate (string p)
            {
                chkListAgl.Items.Add(p, isChecked: false);
            });

            if (selAgls.IsNullOrEmpty())
            {
                return;
            }

            foreach (string selAgl in selAgls)
            {
                if (allAgls.Contains(selAgl))
                {
                    for (int i = 0; i < chkListAgl.Items.Count; i++)
                    {
                        if (selAgl == chkListAgl.Items[i].ToString())
                        {
                            chkListAgl.SetItemChecked(i, value: true);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("算法基元:" + selAgl + " 已经不存在！");
                }
            }
        }
        #endregion



        #region Event_Button
        private void btnEnter_Click(object sender, EventArgs e)
        {
            _agls.Clear();
            for (int i = 0; i < chkListAgl.Items.Count; i++)
            {
                if (chkListAgl.GetItemChecked(i))
                {
                    _agls.Add(chkListAgl.Items[i].ToString());
                }
            }
            Close();
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            Close();
        } 
        #endregion
    }
}
