/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ShowConfigControl.cs
 * Author: Victor
 * Description: 用来直方图参数配置
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 *
 * 3.3.33.0617 -> 
 * <Author>     <Time>
 *  Victor     20220709
 * 1、代码风格重新布局以及增加备注
 * 2、日志使能可以在UI配置
 * 3、应用按钮功能增加参数条件限制（参数规则1：正常区域分组>=10；超下限分组数3、5；超上限分组数3、5；）以及日志提示
 * 4、增加参数建议值（参数建议1：正常区域分组数建议值：20；超下限分组数：5；超上限分组数：5；）
******************************************************************************/

using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using System;
using System.Windows.Forms;

namespace Lead.CPrim.ShowHistorgram.Controls
{
    public partial class ShowConfigControl : UserControl
    {
        #region Field
        private readonly ShowHistorgram _show;
        #endregion



        #region Ctor
        public ShowConfigControl(ShowHistorgram show)
        {
            InitializeComponent();
            _show = show;
            RefreshUi();
        }
        #endregion



        #region Button_Event
        /// <summary>应用按钮</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnApply_Click(object sender, EventArgs e)
        {
            try
            {
                _show.NormalParts = int.TryParse(txbNormalParts.Text, out var value) && value >= 10 ? value : throw new Exception("正常区域分组数值无效");
                _show.LowerParts = int.TryParse(cbFloorParts.SelectedItem?.ToString(), out var value1) && value1 >= 3 ? value1 : throw new Exception("超下限分组数值无效");
                _show.UperParts = int.TryParse(cbUpParts.SelectedItem?.ToString(), out var value2) && value2 >= 3 ? value2 : throw new Exception("超上限分组数值无效");
                _show.SavePicPath = string.IsNullOrEmpty(txbPicturePath.Text) ? string.Empty : txbPicturePath.Text.Trim();
                _show.EnableBarcode = chkEnableBarcode.Checked;
                _show.LogEnable = chkLogEnable.Checked;
                _show.LogAdd($"显示基元{_show.Name}保存成功", LogLevel.Trace);
            }
            catch(Exception ex)
            {
                _show.LogAdd($"显示基元{_show.Name}保存失败：{ex.Message}", LogLevel.Warn);
            }
        }
        private void btnSavePath_Click(object sender, EventArgs e)
        {
            string text = txbPicturePath.Text;
            if(FileHelper.OpenFolderDialogMethod(ref text))
            {
                txbPicturePath.Text = text;
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>UI更新</summary>
        private void RefreshUi()
        {
            txbNormalParts.Text = _show.NormalParts.ToString();
            cbFloorParts.SelectedIndex = _show.LowerParts == 3 ? 0 : (_show.LowerParts == 5 ? 1 : 1);
            cbUpParts.SelectedIndex = _show.UperParts == 3 ? 0 : (_show.UperParts == 5 ? 1 : 1);
            txbPicturePath.Text = _show.SavePicPath;
            chkEnableBarcode.Checked = _show.EnableBarcode;
            chkLogEnable.Checked = _show.LogEnable;
        }
        #endregion
    }
}