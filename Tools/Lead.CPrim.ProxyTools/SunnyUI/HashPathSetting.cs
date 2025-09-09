using Lead.CPrim.Global;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.Common;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.SunnyUI
{
    public partial class HashPathSetting : UIPage
    {
        private static readonly HashPathSetting _hashPathSetting1 = new HashPathSetting();

        private static readonly HashPathSetting _hashPathSetting2 = new HashPathSetting();

        public HashPathSetting()
        {
            InitializeComponent();
        }

        public void SetStyle(bool isVision) 
        {
            for (int i = 0; i < uiTableLayoutPanel1.ColumnCount; i++)
            {
                for (int j = 0; j < uiTableLayoutPanel1.RowCount; j++)
                {
                    switch (i) 
                    {
                        case 0:
                        case 3:
                            UILabel uILabel = new UILabel
                            {
                                Style = SunnyUI.Style.UIStyle.Gray,
                                Dock = DockStyle.Fill,
                                Margin = new Padding(0),
                                Font = new Font("微软雅黑", 8F),
                                Name = isVision ? i == 0 ? $"lbVL{j + 1}Path" : $"lbVR{j + 1}Path" : i == 0 ? j == 0 ? $"lbCDPath" : $"lbCD{j + 1}Path" : $"lbCD{uiTableLayoutPanel1.RowCount + j + 1}Path",
                                Text = isVision ? i == 0 ? $"VL{j + 1}_Path:" : $"VR{j + 1}_Path:" : i == 0 ? j == 0 ? $"CD_Path:" : $"CD{j + 1}_Path:" : $"CD{uiTableLayoutPanel1.RowCount + j + 1}_Path:",
                                TextAlign = ContentAlignment.MiddleRight
                            };
                            uiTableLayoutPanel1.Controls.Add(uILabel, i, j);
                            break;
                        case 1:
                        case 4:
                            UITextBox uITextBox = new UITextBox
                            {
                                Style = SunnyUI.Style.UIStyle.Gray,
                                Dock = DockStyle.Fill,
                                Margin = new Padding(-1),
                                Font = new Font("微软雅黑", 8F),
                                Name = isVision ? i == 1 ? $"tbVL{j + 1}Path" : $"tbVR{j + 1}Path" : i == 1 ? j == 0 ? $"tbCDPath" : $"tbCD{j + 1}Path" : $"tbCD{uiTableLayoutPanel1.RowCount + j + 1}Path",
                                ReadOnly = true,
                                Text = string.Empty,
                                TextAlignment = ContentAlignment.MiddleLeft
                            };
                            uITextBox.KeyPress += new KeyPressEventHandler(uITextBox_KeyPress);
                            uiTableLayoutPanel1.Controls.Add(uITextBox, i, j);
                            break;
                        case 2:
                        case 5:
                            UIButton uIButton = new UIButton 
                            {
                                Style = SunnyUI.Style.UIStyle.Gray,
                                Dock = DockStyle.Fill,
                                Margin = new Padding(1),
                                Font = new Font("微软雅黑", 7F),
                                Name = isVision ? i == 2 ? $"btnVL{j + 1}Path" : $"btnVR{j + 1}Path" : i == 2 ? j == 0 ? $"btnCDPath" : $"btnCD{j + 1}Path" : $"btnCD{uiTableLayoutPanel1.RowCount + j + 1}Path",
                                Text = "Setting",
                                TextAlign = ContentAlignment.MiddleCenter
                            };
                            uIButton.Click += new EventHandler(uIButton_Click);
                            uiTableLayoutPanel1.Controls.Add(uIButton, i, j);
                            break;
                    }
                }
            }
        }

        public static HashPathSetting GetInstance(int index)
        {
            return index switch
            {
                0 => _hashPathSetting1,
                1 => _hashPathSetting2,
                _ => _hashPathSetting1,
            };
        }

        public List<HashKeyInfos> GetHashKeyInfos() 
        {
            List<HashKeyInfos> hashKeyInfos = new List<HashKeyInfos>();
            foreach (Control control in uiTableLayoutPanel1.Controls)
            {
                if (control is UITextBox)
                {
                    HashKeyInfos infos = new HashKeyInfos
                    {
                        ItemName = control.Name.Replace("tb", "").Replace("Path", "").Trim(),
                        ItemPath = control.Text.Trim()
                    };
                    hashKeyInfos.Add(infos);
                }
            }
            return hashKeyInfos;
        }

        public void SetHashKeyInfos(List<HashKeyInfos> hashKeyInfos)
        {
            foreach (Control control in uiTableLayoutPanel1.Controls)
            {
                if (control is UITextBox)
                {
                    HashKeyInfos infos = hashKeyInfos.FirstOrDefault(p => control.Name.Replace("tb", "").Replace("Path", "").Trim() == p.ItemName);
                    control.Text = infos == null ? string.Empty : infos.ItemPath;
                }
            }
        }

        private void uIButton_Click(object sender, EventArgs e) 
        {
            UIButton uIButton = sender as UIButton;
            foreach (Control control in uiTableLayoutPanel1.Controls)
            {
                if (control is UITextBox && control.Name.Substring(2) == uIButton.Name.Substring(3)) 
                {
                    string path = string.Empty;
                    if (!FileHelper.OpenFileDialogMethod(ref path))
                    {
                        break;
                    }

                    control.Text = path;
                    break;
                }
            }
        }

        private void uITextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            UITextBox uITextBox = sender as UITextBox;
            if (e.KeyChar == '\b' && uITextBox.SelectionLength == uITextBox.TextLength && !string.IsNullOrWhiteSpace(uITextBox.Text))
            {
                uITextBox.Text = string.Empty;
            }
        }
    }
}
