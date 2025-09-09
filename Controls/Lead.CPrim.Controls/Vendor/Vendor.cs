/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: DevMainForm.cs
 * Author: Victor
 * Description: 软件主界面UI
 * CreateTime: 2023-1-8
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.0617><Victor><20220617>
 * 1、事件InstanceSoftwareConfigChangeCurrentProduct优化
******************************************************************************/

using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.StationCommon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.Controls
{
    public partial class Vendor : UIPage
    {
        #region Field
        /// <summary>工站实例</summary>
        private StationConfig _station;

        /// <summary>主界面3个按钮</summary>
        private UISymbolButton[] _btnEvent;

        /// <summary>生产曲线</summary>
        private ProductInfoChart _productInfoChart = new ProductInfoChart();
        #endregion



        #region Prop
        #endregion



        #region Ctor
        public Vendor(StationConfig station)
        {
            InitializeComponent();
            _station = station;

            _btnEvent = new UISymbolButton[3] { btnStationEvent1, btnStationEvent2, btnStationEvent3 };

            _productInfoChart.TopLevel = false;
            _productInfoChart.TopMost = false;
            _productInfoChart.Dock = DockStyle.Fill;
            _productInfoChart.Show();
            tpChart.Controls.Add(_productInfoChart);

            {
                var frm = LogMain.Instance;
                frm.TopMost = false;
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.Show();
                tpLogMain.Controls.Add(frm);
            }

            {
                var frm = LogTask.Instance;
                frm.TopMost = false;
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.Show();
                tpLogTask.Controls.Add(frm);
            }

            {
                var frm = LogsQuery.Instance;
                frm.Dock = DockStyle.Fill;
                frm.Show();
                tpLogQuery.Controls.Add(frm);
            }

            {
                var control = new UIStatistics();
                control.Dock = DockStyle.Fill;
                tpStatistics.Controls.Add(control);
                _station.OnStationStatictis += control.SetValue;
                _station.OnGetStationStatictis += control.GetValue;
            }

            {
                var control = new UIAlertInfo();
                control.Dock = DockStyle.Fill;
                tpAlertInfo.Controls.Add(control);
                tabMain.Controls.Remove(tpAlertInfo);
            }

            {
                var control = new UIProductionNGReasonInfo();
                control.Dock = DockStyle.Fill;
                tpDispalyNGReason.Controls.Add(control);
            }

            {
                var control = AlarmManager.Instance.WarnInfoUI;
                control.Dock = DockStyle.Fill;
                tpWarnInfo.Controls.Add(control);
            }

            tabMain.SelectedTab = tPageMonitor;

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        //*****************************************************************************
        #region System_Event
        /// <summary>Load事件</summary>
        private void DevMainForm_Load(object sender, EventArgs e)
        {
            //界面初始化
            {
                cmbProducts.Enabled = false;
                foreach (var btn in _btnEvent)
                {
                    btn.FillColor = Color.DimGray;
                    btn.RectColor = Color.DimGray;
                }
            }
            //btnStationEvent11.Text
            //事件订阅
            {
                if (SwManager.Instance != null)
                {
                    cmbProducts.Items.Clear();
                    if (SwManager.Instance.Products != null)
                    {
                        SwManager.Instance.Products.ForEach(p => cmbProducts.Items.Add(p));
                        cmbProducts.SelectedItem = SwManager.Instance.CurrentProduct;
                    }
                    cmbProducts.SelectedIndexChanged += CmbProductsOnSelectedIndexChanged;
                }
            }

            //主界面按钮更新
            {
                UpdateButtonInfo();
                StationManager.Instance.CurrentStation.OnUpdateMainBtn += UpdateButtonInfo;
            }
        }
        /// <summary>产品切换</summary>
        private async void CmbProductsOnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                await Task.Delay(20);
                cmbProducts.Enabled = false;

                object product = cmbProducts.SelectedItem;
                if (product == null || string.IsNullOrEmpty(product.ToString()))
                {
                    return;
                }

                SwManager.Instance.ChangeCurrentProduct(product.ToString());

                //if (!SwManager.Instance.ServicePrimName.IsNullOrEmpty())
                //{
                //    if (await Global.ProxyData.Instance.ServerExchange(cmbProducts.SelectedIndex))
                //    {
                //        Notification.ShowInfo("切换成功！！！");
                //    }
                //    else
                //    {
                //        Notification.ShowError("切换失败！！！");
                //    }
                //}
            }
            catch (Exception ex)
            {
                Notification.ShowError("切换失败：" + ex.Message);
            }
            finally
            {
                cmbProducts.Enabled = true;
            }
        }

        /// <summary>页面切换</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabMain.SelectedTab != null && tabMain.SelectedTab.Name == "tpProductQuery")
            {
                tpProductQuery.Controls.Clear();
                var frm = ProductQuery.Instance;
                frm.UpdateProducts(StationManager.Instance.Stations.Keys.ToList(), SwManager.Instance.Products);
                frm.TopMost = false;
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.Show();
                tpProductQuery.Controls.Add(frm);
            }
        }
        #endregion



        //*****************************************************************************
        #region Button_Event
        /// <summary>工站3个按钮点击事件</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DevMainButtonPress_Click(object sender, EventArgs e)
        {
            UISymbolButton btn = (UISymbolButton)sender;
            if (btn == null)
            {
                return;
            }
            _station.PressButton(btn.Text);
        }
        #endregion



        //*****************************************************************************
        #region Method_Instance
        /// <summary>更新主界面按钮</summary>
        private void UpdateButtonInfo()
        {
            for (int i = 0; i < _btnEvent.Length; i++)
            {
                _btnEvent[i].Text = _station.BtnInfo[i];
                _btnEvent[i].Visible = _station.BtnEnable[i];
            }
        }
        #endregion



        //*****************************************************************************
        #region Method_ExternalUsing

        public void ChangeToPage(string pageName)
        {
            switch(pageName)
            {
                case "抛料信息":
                    tabMain.SelectedTab = tpDispalyNGReason;
                    tpDispalyNGReason.Parent = tabMain;
                    break;
                case "警告信息":
                    tabMain.SelectedTab = tpWarnInfo;
                    tpWarnInfo.Parent = tabMain;
                    break;
                case "任务日志":
                    tabMain.SelectedTab = tpLogTask;
                    tpLogTask.Parent = tabMain;
                    break;
            }
        }

        /// <summary>切换当前产品</summary>
        /// <param name="currentProduct">当前产品</param>
        public void ChangeCurrentProduct(string currentProduct, List<string> products = null)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string, List<string>>(ChangeCurrentProduct), new object[2] { currentProduct, products });
            }
            else if(products != null && products.Count > 0)
            {
                cmbProducts.SelectedIndexChanged -= CmbProductsOnSelectedIndexChanged;

                cmbProducts.Items.Clear();
                products.ForEach(p => cmbProducts.Items.Add(p));
                cmbProducts.SelectedItem = currentProduct;

                cmbProducts.SelectedIndexChanged += CmbProductsOnSelectedIndexChanged;
            }
        }

        /// <summary>机台状态设置</summary>
        /// <param name="state"></param>
        public void SetState(string state)
        {
            if(InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetState), new object[1], state);
            }
            else
            {
                tbRunningState.Text = state;
            }
        }

        /// <summary>产品换型使能设置</summary>
        /// <param name="enable"></param>
        public void SetProductsEnable(bool enable)
        {
            if(InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetProductsEnable), new object[1] { enable });
            }
            else
            {
                cmbProducts.Enabled = enable;
            }
        }

        /// <summary>状态机初始化完成</summary>
        public void StateMachineInited(bool success)
        {
            if (!success)
            {
                return;
            }

            flpTask.Controls.Clear();

            List<string> names = _station.CurrentRecipe.Tasks.Values.Select(t => t.TaskName).ToList();
            if (names.IsNullOrEmpty())
            {
                return;
            }

            foreach (var item in names)
            {
                var task = TasksManagerTransfer.GetTaskByName(item);
                if (task != null)
                {
                    flpTask.Controls.Add(task.TaskDebugUI);
                }
            }
        }

        /// <summary>实时变量窗体管理</summary>
        /// <param name="control"></param>
        public void RtDataControlManager(Control control = null)
        {
            if(InvokeRequired)
            {
                BeginInvoke(new Action<Control>(RtDataControlManager), new object[] { control });
                return;
            }

            if(control == null)
            {
                pnlRtData.Controls.Clear();
            }
            else
            {
                pnlRtData.Controls.Add(control);
            }
        }
        #endregion



        //*****************************************************************************
        #region Method_InternalUsing
        /// <summary>日志</summary>
        /// <param name="msg">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示弹窗；false：不显示弹窗；</param>
        public void LogAdd(string msg, LogLevel lv, long id = 0, bool isShowDialog = false)
        {
            msg = $"DevMainForm -> " + msg;
            string tempId = $"{(int)lv}{(int)PrimLogId.FormMain}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, PrimLogId.PrimCommon.ToString(), LogClassification.Module, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                ShowWarningDialog(msg);
            }
        }
        #endregion

        public void OnLanguageChanged()
        {
            gp_Monitor.Text = tPageMonitor.Text = NLocalizer.GetString("Lead_CPrim_Controls_Vendor_PageMonitor", "线程监控");
            tpProductQuery.Text = NLocalizer.GetString("Lead_CPrim_Controls_Vendor_PageProductQuery", "产品查询");
            tpChart.Text = NLocalizer.GetString("Lead_CPrim_Controls_Vendor_PageChart", "产品曲线");
            tpLogMain.Text = NLocalizer.GetString("Lead_CPrim_Controls_Vendor_PageLogMain", "日志主页");
            tpLogTask.Text = NLocalizer.GetString("Lead_CPrim_Controls_Vendor_PageLogTask", "任务日志");
            tpLogQuery.Text = NLocalizer.GetString("Lead_CPrim_Controls_Vendor_PageLogQuery", "日志查询");
            tpStatistics.Text = NLocalizer.GetString("Lead_CPrim_Controls_Vendor_PageStatistics", "统计");
            tpAlertInfo.Text = NLocalizer.GetString("Lead_CPrim_Controls_Vendor_PageAlertInfo", "三语报警信息");
            gp_MonitorParameter.Text = NLocalizer.GetString("Lead_CPrim_Controls_Vendor_MonitorParameter", "实时变量");
            lb_SelectProduction.Text = NLocalizer.GetString("Lead_CPrim_Controls_Vendor_lb_SelectProduction", "产品选择");
        }
    }
}
