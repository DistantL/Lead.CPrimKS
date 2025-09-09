using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.TaskHelper;

namespace Lead.CPrim.ShowAQCI.Controls
{
    public partial class ShowConfigControl : UserControl
    {
        #region Field
        /// <summary>AQCI管理器</summary>
        private readonly ShowAQCI _show; 
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public ShowConfigControl()
        {
            InitializeComponent();
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="showAQCI"></param>
        public ShowConfigControl(ShowAQCI showAQCI)
        {
            InitializeComponent();
            _show = showAQCI;
        } 
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void ShowConfigControl_Load(object sender, EventArgs e)
        {
            tbFilePath.Text = _show.PicFilePath;
            tbPicName.Text = _show.PicFileName;
            chkEnable.Checked = _show.Enable;
            chkShowRtData.Checked = _show.ShowRtData;
            chkShowPic.Checked = _show.ShowPic;

            tbPerRow1.Text = _show.PerRow1.ToString("F3");
            tbPerRow2.Text = _show.PerRow2.ToString("F3");
            tbPerRow3.Text = _show.PerRow3.ToString("F3");
            tbPerCol1.Text = _show.PerCol1.ToString("F3");
            tbPerCol2.Text = _show.PerCol2.ToString("F3");
            tbPerCol3.Text = _show.PerCol3.ToString("F3");

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
        /// <summary>浏览</summary>
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            string path = tbFilePath.Text;
            if (ProxyTools.FileHelper.OpenFolderDialogMethod(ref path))
            {
                tbFilePath.Text = path;
            }
        }
        /// <summary>加载</summary>
        private void btnLoadPic_Click(object sender, EventArgs e)
        {
            ((ShowOutputControl)_show.OutputUi).LoadPicture(tbFilePath.Text, tbPicName.Text);
        }
        /// <summary>应用</summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            _show.PicFilePath = tbFilePath.Text;
            _show.PicFileName = tbPicName.Text;
            _show.Enable = chkEnable.Checked;
            _show.ShowRtData = chkShowRtData.Checked;
            _show.ShowPic = chkShowPic.Checked;

            if (float.TryParse(tbPerRow1.Text, out var f1)) _show.PerRow1 = f1;

            if (float.TryParse(tbPerRow2.Text, out var f2)) _show.PerRow2 = f2;

            if (float.TryParse(tbPerRow3.Text, out var f3)) _show.PerRow3 = f3;

            if (float.TryParse(tbPerCol1.Text, out var f4)) _show.PerCol1 = f4;

            if (float.TryParse(tbPerCol2.Text, out var f5)) _show.PerCol2 = f5;

            if (float.TryParse(tbPerCol3.Text, out var f6)) _show.PerCol3 = f6;

            if (cmbStations.SelectedItem != null && cmbStations.SelectedItem.ToString() != _show.StationName)
                _show.ChangeStation(cmbStations.SelectedItem.ToString());

            var proColors = new List<string>();
            foreach (var item in cmbProColors.Items) proColors.Add(item.ToString());

            if (proColors.OrderBy(p => p) != _show.ProColors.OrderBy(q => q)) _show.UpdateProColors(proColors);

            _show.ProColors.Clear();
            foreach (var product in proColors) _show.ProColors.Add(product);

            if (cmbProColors.SelectedItem != null && !string.IsNullOrEmpty(cmbProColors.SelectedItem.ToString()))
                _show.ChangeCurrentProColor(cmbProColors.SelectedItem.ToString());

            _show.LoadTablePanel();
            _show.LoadProColors();
        }
        #endregion
    }
}