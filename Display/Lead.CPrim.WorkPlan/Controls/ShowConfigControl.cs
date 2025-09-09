using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.WorkPlan.Controls
{
    public partial class ShowConfigControl : UserControl
    {
        #region Field
        /// <summary>压力曲线管理器</summary>
        private ShowWorkPlan _show;
        /// <summary>压力曲线配置管理器</summary>
        private ShowWorkPlanConfig _config;
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public ShowConfigControl()
        {
            InitializeComponent();
        }
        /// <summary>Ctor无参</summary>
        public ShowConfigControl(ShowWorkPlan show)
        {
            InitializeComponent();
            _show = show;
            _config = show._config;
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void ShowConfigControl_Load(object sender, EventArgs e)
        {
            tbConfigPath.Text = _show.ConfigPath;
        }
        #endregion



        #region Button_Event
        /// <summary>应用</summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbConfigPath.Text.Trim()))
            {
                ProxyTools.Notification.ShowError("配置路径不允许为空！！！");
                return;
            }

            _show.ConfigPath = tbConfigPath.Text.Trim();
        }
        /// <summary>配置路径保存</summary>
        private void btnSavePath_Click(object sender, EventArgs e)
        {
            string path = tbConfigPath.Text.Trim();
            ProxyTools.FileHelper.SaveFileDialogMethod("", FilterType.XML, DefaultExt.XML, true, true, true, ref path);
            tbConfigPath.Text = path;
        }
        #endregion
    }
}
