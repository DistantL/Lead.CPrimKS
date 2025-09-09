using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.CustomControl;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.CustomControl
{
    public partial class UIPointCompare : UIEditForm
    {
        #region Field
        /// <summary>
        /// 旧点位
        /// </summary>
        private UITextBox[] oldTexts;

        /// <summary>
        /// 新点位
        /// </summary>
        private UITextBox[] newTexts;
        #endregion



        #region Ctor
        public UIPointCompare()
        {
            InitializeComponent();

            Style = UIStyle.Gray;

            oldTexts = new UITextBox[] { txtoldX, txtoldY, txtoldZ, txtoldU, txtoldV, txtoldW };
            newTexts = new UITextBox[] { txtNewX, txtNewY, txtNewZ, txtNewU, txtNewV, txtNewW };
            foreach (var txt in oldTexts)
            {
                txt.SetStyle();
            }
            foreach (var txt in newTexts)
            {
                txt.SetStyle();
            }
        }
        public UIPointCompare(string text) : this()
        {
            Text = text;
        }
        #endregion



        #region Event_System
        private void txt_TextChanged(object sender, EventArgs e)
        {
            UITextBox txt = sender as UITextBox;
            if(txt == null)
            {
                return;
            }

            if(txt.Tag.Equals("1") || txt.Tag.Equals("11"))
            {
                if(txtoldX.Text != txtNewX.Text)
                {
                    txtoldX.FillColor = Color.Lime;
                    txtNewX.FillColor = Color.Lime;
                }
                else
                {
                    txtoldX.FillColor = Color.WhiteSmoke;
                    txtNewX.FillColor = Color.WhiteSmoke;
                }
            }
            else if (txt.Tag.Equals("2") || txt.Tag.Equals("12"))
            {
                if (txtoldY.Text != txtNewY.Text)
                {
                    txtoldY.FillColor = Color.Lime;
                    txtNewY.FillColor = Color.Lime;
                }
                else
                {
                    txtoldY.FillColor = Color.WhiteSmoke;
                    txtNewY.FillColor = Color.WhiteSmoke;
                }
            }
            else if (txt.Tag.Equals("3") || txt.Tag.Equals("13"))
            {
                if (txtoldZ.Text != txtNewZ.Text)
                {
                    txtoldZ.FillColor = Color.Lime;
                    txtNewZ.FillColor = Color.Lime;
                }
                else
                {
                    txtoldZ.FillColor = Color.WhiteSmoke;
                    txtNewZ.FillColor = Color.WhiteSmoke;
                }
            }
            else if (txt.Tag.Equals("4") || txt.Tag.Equals("14"))
            {
                if (txtoldU.Text != txtNewU.Text)
                {
                    txtoldU.FillColor = Color.Lime;
                    txtNewU.FillColor = Color.Lime;
                }
                else
                {
                    txtoldU.FillColor = Color.WhiteSmoke;
                    txtNewU.FillColor = Color.WhiteSmoke;
                }
            }
            else if (txt.Tag.Equals("5") || txt.Tag.Equals("15"))
            {
                if (txtoldV.Text != txtNewV.Text)
                {
                    txtoldV.FillColor = Color.Lime;
                    txtNewV.FillColor = Color.Lime;
                }
                else
                {
                    txtoldV.FillColor = Color.WhiteSmoke;
                    txtNewV.FillColor = Color.WhiteSmoke;
                }
            }
            else if (txt.Tag.Equals("6") || txt.Tag.Equals("16"))
            {
                if (txtoldW.Text != txtNewW.Text)
                {
                    txtoldW.FillColor = Color.Lime;
                    txtNewW.FillColor = Color.Lime;
                }
                else
                {
                    txtoldW.FillColor = Color.WhiteSmoke;
                    txtNewW.FillColor = Color.WhiteSmoke;
                }
            }
        }
        #endregion



        #region Event_Override
        protected override void DoEnter()
        {
            if (btnCancel.Focused || btnOK.Focused)
            {
                return;
            }

            btnOK_Click(null, null);
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// 位置设置
        /// </summary>
        /// <param name="oldPos"></param>
        /// <param name="newPos"></param>
        public void SetPos(string oldPos, string newPos)
        {
            string[] oldPosArray = oldPos.Split(",");
            string[] newPosArray = newPos.Split(",");

            for (int i = 0; i < oldTexts.Length; i++)
            {
                oldTexts[i].Text = oldPosArray[i + 1];
            }
            for (int i = 0; i < newTexts.Length; i++)
            {
                newTexts[i].Text = newPosArray[i + 1];
            }
        }
        #endregion
    }
}
