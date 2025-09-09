using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lead.CPrim.PressureCurve.Controls
{
    public partial class ShowConfigControl : UIUserControl
    {
        #region Field
        /// <summary>压力曲线管理器</summary>
        private ShowPressureCurve _show;
        /// <summary>压力曲线配置管理器</summary>
        private ShowPressureCurveConfig _config;
        /// <summary>模拟量输入名称</summary>
        TextBox[] _text = new TextBox[4];
        /// <summary>压力曲线是否显示</summary>
        ComboBox[] _box = new ComboBox[4];
        /// <summary>ID</summary>
        TextBox[] _id = new TextBox[4];
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public ShowConfigControl(ShowPressureCurve show)
        {
            InitializeComponent();
            SetStyleFlags();
            _show = show;
            _config = show._config;
            tlpMain.SetDoubleBuffered();
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void ShowConfigControl_Load(object sender, EventArgs e)
        {
            _text = new TextBox[4] { tbPressName1, tbPressName2, tbPressName3, tbPressName4 };
            _box = new ComboBox[4] { cbPressVisible1, cbPressVisible2, cbPressVisible3, cbPressVisible4 };
            _id = new TextBox[4] { tbID1, tbID2, tbID3, tbID4 };

            cbPressVisible1.SelectedIndex = _show.PressVisible1 ? 1 : 0;
            cbPressVisible2.SelectedIndex = _show.PressVisible2 ? 1 : 0;
            cbPressVisible3.SelectedIndex = _show.PressVisible3 ? 1 : 0;
            cbPressVisible4.SelectedIndex = _show.PressVisible4 ? 1 : 0;

            tbPressName1.Text = _show.PressName1;
            tbPressName2.Text = _show.PressName2;
            tbPressName3.Text = _show.PressName3;
            tbPressName4.Text = _show.PressName4;

            tbID1.Text = _show._config.ID1.ToString();
            tbID2.Text = _show._config.ID2.ToString();
            tbID3.Text = _show._config.ID3.ToString();
            tbID4.Text = _show._config.ID4.ToString();

            txtPath.Text = _show.ImagePath;
        }
        #endregion



        #region Button_Event
        /// <summary>应用</summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (_text.Any(t => string.IsNullOrEmpty(t.Text.Trim())))
                {
                    throw new Exception("模拟量输入名称不能为空");
                }
                if (_box.Any(c => string.IsNullOrEmpty(c.SelectedItem.ToString())))
                {
                    throw new Exception("压力曲线是否显示不能为空");;
                }
                if (_id.Any(i => string.IsNullOrEmpty(i.Text.Trim())))
                {
                    throw new Exception("ID不能为空");
                }
                if (string.IsNullOrEmpty(txtPath.Text))
                {
                    throw new Exception("保存路径不能为空");
                }
                bool isSame = false;
                Dictionary<string, string> temp = new Dictionary<string, string>();
                foreach (var item in _id)
                {
                    if (!temp.ContainsKey(item.Text.Trim()))
                    {
                        temp.Add(item.Text.Trim(), item.Text.Trim());
                    }
                    else
                    {
                        isSame = true;
                        break;
                    }
                }
                if (isSame)
                {
                    MessageBox.Show("ID不能相同");
                    return;
                }

                _show.PressVisible1 = cbPressVisible1.SelectedIndex == 0 ? false : (cbPressVisible1.SelectedIndex == 1 ? true : false);
                _show.PressVisible2 = cbPressVisible2.SelectedIndex == 0 ? false : (cbPressVisible2.SelectedIndex == 1 ? true : false);
                _show.PressVisible3 = cbPressVisible3.SelectedIndex == 0 ? false : (cbPressVisible3.SelectedIndex == 1 ? true : false);
                _show.PressVisible4 = cbPressVisible4.SelectedIndex == 0 ? false : (cbPressVisible4.SelectedIndex == 1 ? true : false);

                _show.PressName1 = tbPressName1.Text.Trim();
                _show.PressName2 = tbPressName2.Text.Trim();
                _show.PressName3 = tbPressName3.Text.Trim();
                _show.PressName4 = tbPressName4.Text.Trim();

                _show._config.ID1 = int.TryParse(tbID1.Text.Trim(), out var d1) ? d1 : 1;
                _show._config.ID2 = int.TryParse(tbID2.Text.Trim(), out var d2) ? d2 : 2;
                _show._config.ID3 = int.TryParse(tbID3.Text.Trim(), out var d3) ? d3 : 3;
                _show._config.ID4 = int.TryParse(tbID4.Text.Trim(), out var d4) ? d4 : 4;

                _show.ImagePath = txtPath.Text;
            }
            catch (Exception ex)
            {
                _show.LogAdd($"应用失败：{ex.Message}", Interfaces.LogLevel.Warn, 0, true);
            }
        }
        /// <summary>选择文件</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSavePath_Click(object sender, EventArgs e)
        {
            string text = txtPath.Text;
            if(FileHelper.OpenFolderDialogMethod(ref text))
            {
                txtPath.Text = text;
            }
        }
        #endregion
    }
}
