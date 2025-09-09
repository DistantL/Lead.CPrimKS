/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ShowOutputControl.cs
 * Author: Victor
 * Description: config界面，对参数进行配置
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
 * 1、增加PLC曲线保存位置2
 * ******************************************************************************/

using Lead.CPrim.Controls;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.ShowPlcCurve.Controls
{
    public partial class ShowConfigControl : UIUserControl
    {
        #region Field
        /// <summary>压力曲线管理器</summary>
        private Show _show;
        #endregion



        #region Ctor
        public ShowConfigControl()
        {
            InitializeComponent();
            SetStyleFlags();

            fillColor = Color.FromArgb(236, 236, 236);
            rectColor = Color.FromArgb(236, 236, 236);
            txtName.SetStyle(Color.OldLace);

            lblCurveQuantity.SetStyle();
            txtXInterval.SetStyle();
            txtXFormat.SetStyle();
            chkXMin.SetStyle();
            chkXMax.SetStyle();
            chkYMin.SetStyle();
            chkYMax.SetStyle();
            lblPosition1.SetStyle();
            lblPosition2.SetStyle();
            chkSourceDataSave.SetStyle();

            cbChartNum.SetStyle();
            txtXMin.SetStyle();
            txtXMax.SetStyle();
            txtYMin.SetStyle();
            txtYMax.SetStyle();
            txtPlcPath.SetStyle();
            txtPlcPath2.SetStyle();
            txtSourceData.SetStyle();
            btnSavePath.SetStyle();
            btnSavePath2.SetStyle();
            btnSourceData.SetStyle();
            chkPathAddDate.SetStyle();
        }
        public ShowConfigControl(Show show) : this()
        {
            _show = show;
        }
        #endregion



        #region System_Event
        private void ShowConfigControl_Load(object sender, EventArgs e)
        {
            cbChartNum.SelectedIndex = (_show.ChartNum == 1 || _show.ChartNum == 2 || _show.ChartNum == 3 || _show.ChartNum == 4 || _show.ChartNum == 5 || _show.ChartNum == 6) ? _show.ChartNum - 1 : -1;
            txtXInterval.Text = _show.XInterval.ToString();
            txtXFormat.Text = _show.XFormat;
            chkXMin.Checked = _show.XMinEnable;
            chkXMax.Checked = _show.XMaxEnable;
            chkYMin.Checked = _show.YMinEnable;
            chkYMax.Checked = _show.YMaxEnable;
            chkSourceDataSave.Checked = _show.SourceDataSaveEnable;
            txtXMin.Text = _show.XMin.ToString();
            txtXMax.Text = _show.XMax.ToString();
            txtYMin.Text = _show.YMin.ToString();
            txtYMax.Text = _show.YMax.ToString();
            txtPlcPath.Text = _show.PlcPath;
            txtPlcPath2.Text = _show.PlcPath2;
            txtName.Text = _show.Name;
            txtSourceData.Text = _show.SourceDataSave;
            chkPathAddDate.Checked = _show.PathAddDate;
            lblVersion.Text = _show.Version;
        }
        #endregion



        #region Override ITranslate
        public void Translate()
        {
            //lblCurveQuantity.Text = ULocalize.CurveQuantity;
            //lblXInterval.Text = ULocalize.XInterval;
            //lblXFormat.Text = ULocalize.XFormat;
            //chkPathAddDate.Text = ULocalize.PathAddDate;
            //lblPosition1.Text = ULocalize.Position1;
            //lblPosition2.Text = ULocalize.Position2;
            //chkSourceDataSave.Text = ULocalize.SourceDataSave;
            //btnApply.Text = ULocalize.Apply;
        }
        #endregion



        #region Button_Event
        /// <summary>
        /// 路径保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSavePath_Click(object sender, EventArgs e)
        {
            string path = txtPlcPath.Text;
            if (FileHelper.OpenFolderDialogMethod(ref path))
            {
                txtPlcPath.Text = path;
            }
        }

        private void btnSavePath2_Click(object sender, EventArgs e)
        {
            string path = txtPlcPath2.Text;
            if (FileHelper.OpenFolderDialogMethod(ref path))
            {
                txtPlcPath2.Text = path;
            }
        }

        private void btnSourceData_Click(object sender, EventArgs e)
        {
            string path = txtSourceData.Text;
            if(FileHelper.OpenFolderDialogMethod(ref path))
            {
                txtSourceData.Text = path;
            }
        }

        /// <summary>
        /// 应用
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AuthorityManager.Instance.VerifyLevel3Permission(true))
                {
                    return;
                }

                _show.Name = txtName.Text;
                if (string.IsNullOrEmpty(cbChartNum.SelectedItem?.ToString()))
                {
                    throw new Exception("ChartNum Is Null");
                }
                _show.ChartNum = int.TryParse(cbChartNum.SelectedItem.ToString(), out var num) ? num : throw new Exception("ChartNum Is Invalid");

                string xInterval = txtXInterval.Text;
                if(xInterval.IsNullOrWhiteSpace() || !xInterval.IsDouble())
                {
                    throw new Exception($"{lblXInterval.Text} is Invalid");
                }
                _show.XInterval = xInterval.ToDouble();
                _show.XFormat = txtXFormat.Text;

                _show.XMinEnable = chkXMin.Checked;
                _show.XMaxEnable = chkXMax.Checked;
                _show.YMinEnable = chkYMin.Checked;
                _show.YMaxEnable = chkYMax.Checked;
                _show.SourceDataSaveEnable = chkSourceDataSave.Checked;
                double xmin = 0;
                double xmax = 0;
                double ymin = 0;
                double ymax = 0;
                if (_show.XMinEnable && (txtXMin.Text.IsNullOrWhiteSpace() || !double.TryParse(txtXMin.Text, out xmin)))
                {
                    throw new Exception("XMin is Invalid");
                }
                if (_show.XMaxEnable && (txtXMax.Text.IsNullOrWhiteSpace() || !double.TryParse(txtXMax.Text, out xmax)))
                {
                    throw new Exception("XMax is Invalid");
                }
                if (_show.YMinEnable && (txtYMin.Text.IsNullOrWhiteSpace() || !double.TryParse(txtYMin.Text, out ymin)))
                {
                    throw new Exception("YMin is Invalid");
                }
                if (_show.YMaxEnable && (txtYMax.Text.IsNullOrWhiteSpace() || !double.TryParse(txtYMax.Text, out ymax)))
                {
                    throw new Exception("YMax is Invalid");
                }
                _show.XMin = xmin;
                _show.XMax = xmax;
                _show.YMin = ymin;
                _show.YMax = ymax;
                _show.PlcPath = txtPlcPath.Text;
                _show.PlcPath2 = txtPlcPath2.Text;
                _show.SourceDataSave = txtSourceData.Text;
                _show.PathAddDate = chkPathAddDate.Checked;

                _show.LogAdd(NLocalizer.ApplySuccess, LogLevel.Info);
            }
            catch (Exception ex)
            {
                _show.LogAdd(NLocalizer.ApplyError + $"：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        #endregion




        #region 框架内
        /// <summary>
        /// 版本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblVersion_DoubleClick(object sender, EventArgs e)
        {
            string msg =
            "V1.5_20240112   \r\n1、接口增加附属值，作用于图例以及图片名称，测试UI已同步更新  \r\n2、时间压力曲线X轴主要刻度线强制显示" + "\r\n\r\n" +
            "V1.4   \r\n1、时间压力曲线增加X轴日期格式，请参照yyyy-MM-dd HH:mm:ss fff" + "\r\n\r\n" +
            "V1.3   \r\n1、增加属性路径增加日志；增加属性X轴间隔，此属性仅适用于时间压力曲线 \r\n2、增加三语" + "\r\n\r\n" +
            "V1.2   \r\n1、图标优化" + "\r\n\r\n" +
            "V1.1   \r\n1、增加XY最小值最大值限制  \r\n2、增加源数据csv格式保存  \r\n\r\n" +
            "V1.0   \r\n接收PLC数据，保存图片及原始数据，目前支持Dictionary<double, double>、List<PointF>、Dictionary<DateTime, double>";
            VersionForm.Instance.SetInfo(_show.Name, "", "", msg);
            VersionForm frm = VersionForm.Instance;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        /// <summary>基元名称设置</summary>
        /// <param name="name">名称</param>
        internal void SetShowName(string name)
        {
            txtName.SetText(name);
        }
        #endregion
    }
}
