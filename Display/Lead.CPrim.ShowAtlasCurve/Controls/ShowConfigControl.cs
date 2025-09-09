/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ShowOutputControl.cs
 * Author: Victor
 * Description: Atlas config界面，对参数进行配置
 * CreateTime: 2022-09-13
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.0904><Victor><20220913>
 * 1、初版1.0
 * 
 * <3.3.22.1117><Victor><20221118>
 * 1、增加Atlas曲线保存位置2
 * 
 * <3.3.22.1124><Victor><20221124>
 * 1、增加曲线Y值自动生成或者自定义生成
******************************************************************************/

using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using System;

namespace Lead.CPrim.ShowAtlasCurve.Controls
{
    public partial class ShowConfigControl : UIUserControl
    {
        #region Field
        /// <summary>压力曲线管理器</summary>
        private ShowAtlasCurve _show;
        /// <summary>名称</summary>
        UITextBox[] _name = new UITextBox[4];
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public ShowConfigControl(ShowAtlasCurve show)
        {
            InitializeComponent();
            SetStyleFlags();
            _show = show;
            _name = new UITextBox[4] { txtAtlas1Name, txtAtlas2Name, txtAtlas3Name, txtAtlas4Name };
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void ShowConfigControl_Load(object sender, EventArgs e)
        {
            txtAtlas1Name.Text = _show.Atlas1Name;
            txtAtlas2Name.Text = _show.Atlas2Name;
            txtAtlas3Name.Text = _show.Atlas3Name;
            txtAtlas4Name.Text = _show.Atlas4Name;

            cbAtlasNum.SelectedIndex = (_show.AtlasNum == 1 || _show.AtlasNum == 2 || _show.AtlasNum == 3 || _show.AtlasNum == 4) ? _show.AtlasNum - 1 : -1;
            cbChartNum.SelectedIndex = (_show.ChartNum == 1 || _show.ChartNum == 2 || _show.ChartNum == 3 || _show.ChartNum == 4 || _show.ChartNum == 5 || _show.ChartNum == 6) ? _show.ChartNum - 1 : -1;
            txtAtlasPath.Text = _show.AtlasPath;
            txtAtlasPath2.Text = _show.AtlasPath2;
            lblName.Text = _show.Name;
            txtYValue.Text = _show.ChartYMax.ToString();
            cbEnableYValue.Checked = _show.EnableChartYMax;
        }
        #endregion



        #region Method_ExternalUsing

        /// <summary>显示基元名称更新</summary>
        /// <param name="name"></param>
        public void ShowNameUpdate(string name)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ShowNameUpdate), name);
            }
            else
            {
                lblName.Text = name;
            }
        }
        #endregion



        #region Button_Event
        /// <summary>路径保存</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSavePath_Click(object sender, EventArgs e)
        {
            string path = txtAtlasPath.Text;
            if (FileHelper.OpenFolderDialogMethod(ref path))
            {
                txtAtlasPath.Text = path;
            }
        }
        private void btnSavePath2_Click(object sender, EventArgs e)
        {
            string path = txtAtlasPath2.Text;
            if(FileHelper.OpenFolderDialogMethod(ref path))
            {
                txtAtlasPath2.Text = path;
            }
        }
        /// <summary>应用</summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                double max = 0;
                if (string.IsNullOrEmpty(cbAtlasNum.SelectedItem?.ToString()))
                {
                    throw new Exception("Atlas数量为空");
                }
                if (string.IsNullOrEmpty(cbChartNum.SelectedItem?.ToString()))
                {
                    throw new Exception("显示曲线数量为空");
                }
                if (string.IsNullOrEmpty(txtYValue.Text))
                {
                    max = 0.4;
                }
                else if (!Double.TryParse(txtYValue.Text, out max))
                {
                    throw new Exception("曲线Y值限位值无效");
                }
                //bool isSame = false;
                //Dictionary<string, string> temp = new Dictionary<string, string>();
                //foreach (var item in _id)
                //{
                //    if (!temp.ContainsKey(item.Text.Trim()))
                //    {
                //        temp.Add(item.Text.Trim(), item.Text.Trim());
                //    }
                //    else
                //    {
                //        isSame = true;
                //        break;
                //    }
                //}
                //if (isSame)
                //{
                //    throw new Exception("ID不能相同");
                //}

                _show.Atlas1Name = txtAtlas1Name.Text.Trim();
                _show.Atlas2Name = txtAtlas2Name.Text.Trim();
                _show.Atlas3Name = txtAtlas3Name.Text.Trim();
                _show.Atlas4Name = txtAtlas4Name.Text.Trim();

                _show.AtlasNum = int.TryParse(cbAtlasNum.SelectedItem.ToString(), out var value) ? value : throw new Exception("Atlas数量值无效");
                _show.ChartNum = int.TryParse(cbChartNum.SelectedItem.ToString(), out var num) ? num : throw new Exception("曲线显示数量值无效");
                _show.AtlasPath = txtAtlasPath.Text.Trim();
                _show.AtlasPath2 = txtAtlasPath2.Text.Trim();
                _show.ChartYMax = max;
                _show.EnableChartYMax = cbEnableYValue.Checked;

                _show.LogAdd($"应用成功", LogLevel.Info);
            }
            catch (Exception ex)
            {
                _show.LogAdd($"应用失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        #endregion
    }
}
