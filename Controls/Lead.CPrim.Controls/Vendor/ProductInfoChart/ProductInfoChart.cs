/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: HistoryQueryByMongoDb.cs
 * Author: Victor
 * Description: 曲线数据
 * CreateTime: 2023-1-1
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.23.0101><Victor><20230101>
 * 1、初版1.0
******************************************************************************/

using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Display;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using System;
using System.Windows.Forms;

namespace Lead.CPrim.Controls
{
    public partial class ProductInfoChart : UIPage
    {
        #region Field
        /// <summary>压力显示基元</summary>
        IShow show;
        /// <summary>压力显示基元集合</summary>
        IShow[] shows;
        #endregion



        #region Ctor
        public ProductInfoChart()
        {
            InitializeComponent();

            ReLoadChart();
            splMain.SetDoubleBuffered();
            splMain.SplitPanelState = ProxyTools.SunnyUI.Controls.UISplitContainer.UISplitPanelState.Collapsed;
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void HistoryQueryByMongoDb_Load(object sender, EventArgs e)
        {
            
        }
        #endregion



        #region Button_Event
        /// <summary>重新加载</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReLoad_Click(object sender, EventArgs e)
        {
            ReLoadChart();
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>手自动</summary>
        /// <param name="enable">自动：false；手动：true；</param>
        public void EnableHandle(bool enable)
        {
            if (show != null)
            {
                ((IManualAuto)show).EnableHandle(enable);
            }
            if (shows != null && shows.Length > 0)
            {
                foreach (var show in shows)
                {
                    ((IManualAuto)show).EnableHandle(enable);
                }
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>加载曲线显示基元</summary>
        private void ReLoadChart()
        {
            try
            {
                splMain.Panel2.Controls.Clear();
                show = null;
                shows = null;
                string pressName = SwManager.Instance.PressPrimName;
                if (!string.IsNullOrEmpty(pressName))
                {
                    string[] re = pressName.Split(',');
                    if (re.Length <= 1)
                    {
                        show = ShowManagerTransfer.GetShowByName(re[0]);
                        if (show != null)
                        {
                            show.OutputUi.Dock = DockStyle.Fill;
                            show.OutputUi.Show();
                            splMain.Panel2.Controls.Add(show.OutputUi);
                        }
                    }
                    else
                    {
                        TabControl tab = new TabControl
                        {
                            Padding = new System.Drawing.Point(0, 0),
                            Margin = new Padding(0),
                            Dock = DockStyle.Fill,
                        };
                        shows = new IShow[re.Length];
                        for (int i = 0; i < re.Length; i++)
                        {
                            shows[i] = ShowManagerTransfer.GetShowByName(re[i]);
                            if (shows[i] == null)
                            {
                                throw new Exception(NLocalizer.GetString(" Lead_CPrim_Controls_ProductInfoChart_ErrMes_NameError", "曲线显示基元名称值无效"));
                            }
                        }
                        foreach (var item in shows)
                        {
                            tab.TabPages.Add(item.Name, item.Name);
                            item.OutputUi.Dock = DockStyle.Fill;
                            item.OutputUi.Show();
                            tab.TabPages[item.Name].Controls.Add(item.OutputUi);
                        }
                        splMain.Panel2.Controls.Add(tab);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion
    }
}
