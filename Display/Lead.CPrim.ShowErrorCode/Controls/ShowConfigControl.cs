using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lead.CPrim.ShowErrorCode.Controls
{
    public partial class ShowConfigControl : UserControl
    {
        #region Field
        /// <summary>AQCI管理器</summary>
        private readonly ShowErrorCode _show;
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public ShowConfigControl()
        {
            InitializeComponent();
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="showAQCI"></param>
        public ShowConfigControl(ShowErrorCode showAQCI)
        {
            InitializeComponent();
            _show = showAQCI;
            dgvErrorCodeInput.DataSource = _show.LErrorCodeInput;
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void ShowConfigControl_Load(object sender, EventArgs e)
        {
            uitbStationCode.Text = _show.StationCode;
            uitbModuleCode.Text = _show.ModuleCode;
            uitbModuleNameCn.Text = _show.ModuleNameCn;
            uitbModuleNameEn.Text = _show.ModuleNameEn;
        }
        #endregion



        #region Button_Event
        /// <summary>应用</summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            _show.StationCode = string.IsNullOrEmpty(uitbStationCode.Text) ? "" : uitbStationCode.Text;
            _show.ModuleCode = string.IsNullOrEmpty(uitbModuleCode.Text) ? "" : uitbModuleCode.Text;
            _show.ModuleNameCn = string.IsNullOrEmpty(uitbModuleNameCn.Text) ? "" : uitbModuleNameCn.Text;
            _show.ModuleNameEn = string.IsNullOrEmpty(uitbModuleNameEn.Text) ? "" : uitbModuleNameEn.Text;

            //_show.ErrotcodeOutput(false);
        }
        /// <summary>ErrorCode插入测试</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertTest_Click(object sender, EventArgs e)
        {
            //_show.InsertMongoDB();
        }
        #endregion
    }
}