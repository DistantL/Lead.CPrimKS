using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.TaskHelper;
using Sunny.UI;

namespace Lead.CPrim.ShowAudio.Controls
{
    public partial class ShowConfigControl : UIUserControl
    {
        #region Field
        /// <summary>AQCI管理器</summary>
        private readonly ShowAudio _show;
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public ShowConfigControl()
        {
            InitializeComponent();
            SetStyleFlags();
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="showAQCI"></param>
        public ShowConfigControl(ShowAudio showAQCI) : this()
        {
            _show = showAQCI;
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void ShowConfigControl_Load(object sender, EventArgs e)
        {
            chkEnable.Checked = _show.Enable;
            cmbStations.Items.Clear();
            foreach (var taskSM in TaskSmManger.Instance.TaskSMs) cmbStations.Items.Add(taskSM.Key);

            if (_show.StationName != null)
            {
                if (!string.IsNullOrEmpty(_show.StationName) && !cmbStations.Items.Contains(_show.StationName))
                    cmbStations.Items.Add(_show.StationName);

                if (cmbStations.Items.Contains(_show.StationName)) cmbStations.SelectedItem = _show.StationName;
            }


            cmbProColors.Items.Clear();
            foreach (var proColor in _show.ProColors) cmbProColors.Items.Add(proColor);

            if (_show.CurProColor != null)
            {
                if (!string.IsNullOrEmpty(_show.CurProColor) && !cmbProColors.Items.Contains(_show.CurProColor))
                    cmbProColors.Items.Add(_show.CurProColor);

                if (cmbProColors.Items.Contains(_show.CurProColor)) cmbProColors.SelectedItem = _show.CurProColor;
            }

            txtCurrentFAIName.Text = _show.CurrentFAIName;
        }
        #endregion



        #region Button_Event
        /// <summary>增加颜色</summary>
        private void btnAddColor_Click(object sender, EventArgs e)
        {
            var added = cmbProColors.Text.Trim();
            if (string.IsNullOrEmpty(added)) return;

            if (!cmbProColors.Items.Contains(added)) cmbProColors.Items.Add(added);
        }

        /// <summary>移除颜色</summary>
        private void btnRemoveProColor_Click(object sender, EventArgs e)
        {
            var removed = cmbProColors.Text.Trim();
            if (string.IsNullOrEmpty(removed)) return;

            if (cmbProColors.Items.Contains(removed))
            {
                cmbProColors.Items.Remove(removed);
                cmbProColors.SelectedIndex = -1;
            }
        }

        /// <summary>应用</summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                _show.Enable = chkEnable.Checked;

                if (cmbStations.SelectedItem != null && cmbStations.SelectedItem.ToString() != _show.StationName)
                {
                    _show.StationName = cmbStations.SelectedItem.ToString();
                }

                var proColors = new List<string>();
                foreach (var item in cmbProColors.Items)
                {
                    proColors.Add(item.ToString());
                }
                if (proColors.OrderBy(p => p) != _show.ProColors.OrderBy(q => q))
                {
                    //_show.UpdateProColors(proColors);
                }

                _show.ProColors.Clear();
                foreach (var product in proColors)
                {
                    _show.ProColors.Add(product);
                }

                if (cmbProColors.SelectedItem != null && !string.IsNullOrEmpty(cmbProColors.SelectedItem.ToString()))
                {
                    _show.CurProColor = cmbProColors.SelectedItem.ToString();
                }

                _show.CurrentFAIName = txtCurrentFAIName.Text.Trim();
            }
            catch (Exception ex)
            {
                _show.LogAdd($"保存失败：{ex.Message}", Interfaces.LogLevel.Warn, 0, true);
            }
        }
        #endregion
    }
}