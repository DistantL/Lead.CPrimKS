using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.CmpTrigHelper.ConfigClass;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Style;

namespace Lead.CPrim.CmpTrigHelper
{
    public partial class TriggerMain : UIUserControl
    {
        #region Field
        private TriggerManager _instance;
        #endregion



        #region Ctor
        public TriggerMain()
        {
            InitializeComponent();

            RectColor = Color.FromArgb(236, 236, 236);
            fillColor = Color.FromArgb(236, 236, 236);

            foreach (TabPage page in tabMain.TabPages)
            {
                page.BackColor = Colors.PrimaryBackColor236;
                page.Margin = new Padding(0);
                page.Padding = new Padding(0);
            }

            tlpMain.SetDoubleBuffered();
            tabMain.SetDoubleBuffered();
            flpTrigPort.SetDoubleBuffered();
            flpTrajDatas.SetDoubleBuffered();
            flpLinearTrigDatas.SetDoubleBuffered();
            flpTableTrigDatas.SetDoubleBuffered();
            flpInterpretation.SetDoubleBuffered();
            flpTrigTabManger.SetDoubleBuffered();
            flpComplexInterpolation.SetDoubleBuffered();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }

        public TriggerMain(TriggerManager instance) : this()
        {
            _instance = instance;
        }
        #endregion



        #region Event_System

        private void CmpTrigControl_Load(object sender, EventArgs e)
        {
            LoadTbCmb(_instance);
            LoadControls(_instance);
        }

        public void OnLanguageChanged()
        {
            tsl_Production.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_Production", "产品选择:");

            string str_Add = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_Add", "添加");

            tpTriggerProt.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfig", "触发端口");
            tpTrajDatas.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrajData", "轨迹表");
            tpLinearTrigDatas.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_LinearTrigConfig", "线性触发表");
            tpTableTrigDatas.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TableTrigConfig", "队列触发表");
            tpInterpretation.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_Interpolation", "插补表");
            tpTrigManger.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrigTableManger", "触发表管理器");
            tpComplexInterpolation.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_ComplexInterpolation", "复杂插补表");

            tsBtnAddTriggerConfig.Text = str_Add + tpTriggerProt.Text;
            tsBtnAddTrajData.Text = str_Add + tpTrajDatas.Text;
            tsBtnAddLinearTrigConfig.Text = str_Add + tpLinearTrigDatas.Text;
            tsBtnAddTableTrigConfig.Text = str_Add + tpTableTrigDatas.Text;
            tsBtnInterpolation.Text = str_Add + tpInterpretation.Text;
            btnTrigTableManger.Text = str_Add + tpTrigManger.Text;
            tsBtnComplexInterpolation.Text = str_Add + tpComplexInterpolation.Text;
        }
        #endregion



        #region Event_Button
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnSaveCmpConfig_Click(object sender, EventArgs e)
        {
            _instance.Save();
        }

        /// <summary>
        /// 产品切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsCmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = tsCmbProduct.SelectedItem?.ToString();
            if (name.IsNullOrEmpty())
            {
                return;
            }

            if (_instance.ChangeCurrentProduct(name) != 0)
            {
                TriggerManager.Instance.LogAdd(NLocalizer.ChangeCurrentProductError, LogLevel.Warn);
            }
        }

        /// <summary>
        /// 增加产品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnAddProduct_Click(object sender, EventArgs e)
        {
            string name = "";
            if (UIInputDialog.InputStringDialog(ref name, true, true, NLocalizer.PleaseInputProductName))
            {
                if (_instance.AddNewProdcut(name) == 0)
                {
                    LoadTbCmb(_instance);
                }
            }
        }

        /// <summary>
        /// 移除产品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDelProduct_Click(object sender, EventArgs e)
        {
            string name = tsCmbProduct.SelectedItem?.ToString();
            if (name.IsNullOrEmpty())
            {
                return;
            }

            if(this.ShowAskDialog(NLocalizer.ConfirmDeleteProduct, UIStyle.Orange))
            {
                _instance.RemoveProdcut(name);

                if (tsCmbProduct.Items.Contains(name))
                {
                    tsCmbProduct.SelectedIndex = -1;
                    tsCmbProduct.Items.Remove(name);
                }
            }
        }

        /// <summary>
        /// 复制当前产品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsCopyProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_instance.CurrentProductName))
            {
                Notification.ShowWarn(NLocalizer.CurrentProductIsEmpty);
                return;
            }

            string name = "";
            if (UIInputDialog.InputStringDialog(ref name, true, true, NLocalizer.PleaseInputProductName))
            {
                _instance.CopyProdcut(name);
                LoadTbCmb(_instance);
            }
        }

        /// <summary>
        /// 添加触发端口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnAddTriggerConfig_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_instance.CurrentProductName))
            {
                Notification.ShowWarn(NLocalizer.CurrentProductIsEmpty);
                return;
            }

            if (_instance.CurrentProduct.TriggerDatas.Count == 0)
            {
                tpTriggerProt.Parent = tabMain;
            }

            TriggerPortData triggerData = new TriggerPortData("", _instance.CurrentProduct.TriggerDatas.Count, _instance);
            triggerData.ConfigUi.Dock = DockStyle.Top;
            _instance.CurrentProduct.TriggerDatas.TryAdd(triggerData.Gid, triggerData);
            flpTrigPort.Controls.Add(triggerData.ConfigUi);

            tabMain.SelectedTab = tpTriggerProt;
        }

        /// <summary>
        /// 添加轨迹表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnAddTrajData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_instance.CurrentProductName))
            {
                Notification.ShowWarn(NLocalizer.CurrentProductIsEmpty);
                return;
            }

            if (_instance.CurrentProduct.TrajDatas.Count == 0)
            {
                tpTrajDatas.Parent = tabMain;
            }

            TriggerTrackData trajData = new TriggerTrackData("", _instance.CurrentProduct.TrajDatas.Count, _instance);
            trajData.ConfigUi.Dock = DockStyle.Top;
            _instance.CurrentProduct.TrajDatas.TryAdd(trajData.Gid, trajData);
            flpTrajDatas.Controls.Add(trajData.ConfigUi);

            tabMain.SelectedTab = tpTrajDatas;
        }

        /// <summary>
        /// 添加线性触发表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnAddLinearTrigConfig_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_instance.CurrentProductName))
            {
                Notification.ShowWarn(NLocalizer.CurrentProductIsEmpty);
                return;
            }

            if (_instance.CurrentProduct.LinearTrigDatas.Count == 0)
            {
                tpLinearTrigDatas.Parent = tabMain;
            }

            LinearTrigData linearTrigData = new LinearTrigData("", _instance.CurrentProduct.LinearTrigDatas.Count, _instance);
            linearTrigData.ConfigUi.Dock = DockStyle.Top;
            _instance.CurrentProduct.LinearTrigDatas.TryAdd(linearTrigData.Gid, linearTrigData);
            flpLinearTrigDatas.Controls.Add(linearTrigData.ConfigUi);

            tabMain.SelectedTab = tpLinearTrigDatas;
        }

        /// <summary>
        /// 添加队列触发表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnAddTableTrigConfig_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_instance.CurrentProductName))
            {
                Notification.ShowWarn(NLocalizer.CurrentProductIsEmpty);
                return;
            }

            if (_instance.CurrentProduct.TableTrigDatas.Count == 0)
            {
                tpTableTrigDatas.Parent = tabMain;
            }

            TriggerTableData tableTrigData = new TriggerTableData("", _instance.CurrentProduct.TableTrigDatas.Count, _instance);
            tableTrigData.ConfigUi.Dock = DockStyle.Top;
            _instance.CurrentProduct.TableTrigDatas.TryAdd(tableTrigData.Gid, tableTrigData);
            flpTableTrigDatas.Controls.Add(tableTrigData.ConfigUi);

            tabMain.SelectedTab = tpTableTrigDatas;
        }

        /// <summary>
        /// 添加插补表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnInterpolation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_instance.CurrentProductName))
            {
                Notification.ShowWarn(NLocalizer.CurrentProductIsEmpty);
                return;
            }

            if (_instance.CurrentProduct.InterpolationDatas.Count == 0)
            {
                tpInterpretation.Parent = tabMain;
            }

            InterPolationCfg interPolationCfg = new InterPolationCfg("", _instance.CurrentProduct.InterpolationDatas.Count, _instance);
            interPolationCfg.ConfigUi.Dock = DockStyle.Top;
            _instance.CurrentProduct.InterpolationDatas.TryAdd(interPolationCfg.Gid, interPolationCfg);
            flpInterpretation.Controls.Add(interPolationCfg.ConfigUi);

            tabMain.SelectedTab = tpInterpretation;
        }

        /// <summary>
        /// 添加触发表管理器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTrigTableManger_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_instance.CurrentProductName))
            {
                Notification.ShowWarn(NLocalizer.CurrentProductIsEmpty);
                return;
            }

            if (_instance.CurrentProduct.TrigTabMangerDatas.Count == 0)
            {
                tpTrigManger.Parent = tabMain;
            }

            TrigTabMangerData trigTabMangerData = new TrigTabMangerData("", _instance.CurrentProduct.TrigTabMangerDatas.Count, _instance);
            trigTabMangerData.ConfigUi.Dock = DockStyle.Top;
            _instance.CurrentProduct.TrigTabMangerDatas.TryAdd(trigTabMangerData.Gid, trigTabMangerData);
            flpTrigTabManger.Controls.Add(trigTabMangerData.ConfigUi);

            tabMain.SelectedTab = tpTrigManger;
        }

        /// <summary>
        /// 添加复杂插补表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnComplexInterpolation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_instance.CurrentProductName))
            {
                Notification.ShowWarn(NLocalizer.CurrentProductIsEmpty);
                return;
            }

            if (_instance.CurrentProduct.ComplexInterPolationDatas.Count == 0)
            {
                tpComplexInterpolation.Parent = tabMain;
            }

            ComplexInterPolationCfg complexInterPolationCfg = new ComplexInterPolationCfg("", _instance.CurrentProduct.ComplexInterPolationDatas.Count, _instance);
            complexInterPolationCfg.ConfigUi.Dock = DockStyle.Top;
            _instance.CurrentProduct.ComplexInterPolationDatas.TryAdd(complexInterPolationCfg.Gid, complexInterPolationCfg);
            flpComplexInterpolation.Controls.Add(complexInterPolationCfg.ConfigUi);

            tabMain.SelectedTab = tpComplexInterpolation;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDelConfig_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_instance.CurrentProductName))
            {
                Notification.ShowWarn(NLocalizer.CurrentProductIsEmpty);
                return;
            }

            if (tabMain.SelectedTab == tpTriggerProt)
            {
                foreach (KeyValuePair<Guid, TriggerPortData> triggerData in _instance.CurrentProduct.TriggerDatas)
                {
                    if (triggerData.Value.IsSelected)
                    {
                        flpTrigPort.Controls.Remove(triggerData.Value.ConfigUi);
                        _instance.CurrentProduct.TriggerDatas.TryRemove(triggerData.Key, out var _);
                    }
                }
            }
            if (tabMain.SelectedTab == tpTrajDatas)
            {
                foreach (KeyValuePair<Guid, TriggerTrackData> trajData in _instance.CurrentProduct.TrajDatas)
                {
                    if (trajData.Value.IsSelected)
                    {
                        flpTrajDatas.Controls.Remove(trajData.Value.ConfigUi);
                        _instance.CurrentProduct.TrajDatas.TryRemove(trajData.Key, out var _);
                    }
                }
            }
            if (tabMain.SelectedTab == tpLinearTrigDatas)
            {
                foreach (KeyValuePair<Guid, LinearTrigData> linearTrigData in _instance.CurrentProduct.LinearTrigDatas)
                {
                    if (linearTrigData.Value.IsSelected)
                    {
                        flpLinearTrigDatas.Controls.Remove(linearTrigData.Value.ConfigUi);
                        _instance.CurrentProduct.LinearTrigDatas.TryRemove(linearTrigData.Key, out var _);
                    }
                }
            }
            if (tabMain.SelectedTab == tpTableTrigDatas)
            {
                foreach (KeyValuePair<Guid, TriggerTableData> tableTrigData in _instance.CurrentProduct.TableTrigDatas)
                {
                    if (tableTrigData.Value.IsSelected)
                    {
                        flpTableTrigDatas.Controls.Remove(tableTrigData.Value.ConfigUi);
                        _instance.CurrentProduct.TableTrigDatas.TryRemove(tableTrigData.Key, out var _);
                    }
                }
            }
            if (tabMain.SelectedTab == tpInterpretation)
            {
                foreach (KeyValuePair<Guid, InterPolationCfg> interpolationData in _instance.CurrentProduct.InterpolationDatas)
                {
                    if (interpolationData.Value.IsSelected)
                    {
                        flpInterpretation.Controls.Remove(interpolationData.Value.ConfigUi);
                        _instance.CurrentProduct.InterpolationDatas.TryRemove(interpolationData.Key, out var _);
                    }
                }
            }
            if (tabMain.SelectedTab == tpTrigManger)
            {
                foreach (KeyValuePair<Guid, TrigTabMangerData> trigTabMangerData in _instance.CurrentProduct.TrigTabMangerDatas)
                {
                    if (trigTabMangerData.Value.IsSelected)
                    {
                        flpTrigTabManger.Controls.Remove(trigTabMangerData.Value.ConfigUi);
                        _instance.CurrentProduct.TrigTabMangerDatas.TryRemove(trigTabMangerData.Key, out var _);
                    }
                }
            }
            if (tabMain.SelectedTab == tpComplexInterpolation)
            {
                foreach (KeyValuePair<Guid, ComplexInterPolationCfg> complexInterPolationData in _instance.CurrentProduct.ComplexInterPolationDatas)
                {
                    if (complexInterPolationData.Value.IsSelected)
                    {
                        flpComplexInterpolation.Controls.Remove(complexInterPolationData.Value.ConfigUi);
                        _instance.CurrentProduct.ComplexInterPolationDatas.TryRemove(complexInterPolationData.Key, out var _);
                    }
                }
            }
            HideTabPages();
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// 加载产品<br/>
        /// Load_1
        /// </summary>
        /// <param name="instance"></param>
        private void LoadTbCmb(TriggerManager instance)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<TriggerManager>(LoadTbCmb), instance);
                return;
            }

            tsCmbProduct.Items.Clear();
            tsCmbProduct.SelectedIndex = -1;
            if (instance.Products.IsEmpty)
            {
                return;
            }

            tsCmbProduct.Items.AddRange(instance.Products.Keys.ToArray());
            if (!string.IsNullOrEmpty(instance.CurrentProductName))
            {
                if (!tsCmbProduct.Items.Contains(instance.CurrentProductName))
                {
                    tsCmbProduct.Items.Add(instance.CurrentProductName);
                }
                tsCmbProduct.SelectedItem = instance.CurrentProductName;
            }
        }

        /// <summary>
        /// 加载控件
        /// </summary>
        /// <param name="instance"></param>
        public void LoadControls(TriggerManager instance)
        {
            if (!IsHandleCreated || !Created)
            {
                return;
            }

            if (InvokeRequired)
            {
                BeginInvoke(new Action<TriggerManager>(LoadControls), instance);
                return;
            }

            flpTrigPort.Controls.Clear();
            flpTrajDatas.Controls.Clear();
            flpLinearTrigDatas.Controls.Clear();
            flpTableTrigDatas.Controls.Clear();
            flpInterpretation.Controls.Clear();
            flpTrigTabManger.Controls.Clear();
            flpComplexInterpolation.Controls.Clear();
            if (instance.CurrentProduct != null)
            {
                //触发端口
                instance.CurrentProduct.TriggerDatas.OrderBy(p => p.Value.Name).ToList().ForEach(delegate (KeyValuePair<Guid, TriggerPortData> p)
                {
                    flpTrigPort.Controls.Add(p.Value.ConfigUi);
                });

                //轨迹表
                instance.CurrentProduct.TrajDatas.OrderBy((KeyValuePair<Guid, TriggerTrackData> p) => p.Value.Id).ThenBy((KeyValuePair<Guid, TriggerTrackData> q) => q.Value.Name).ToList()
                    .ForEach(delegate (KeyValuePair<Guid, TriggerTrackData> p)
                    {
                        flpTrajDatas.Controls.Add(p.Value.ConfigUi);
                    });

                instance.CurrentProduct.LinearTrigDatas.OrderBy((KeyValuePair<Guid, LinearTrigData> p) => p.Value.Id).ThenBy((KeyValuePair<Guid, LinearTrigData> q) => q.Value.Name).ToList()
                    .ForEach(delegate (KeyValuePair<Guid, LinearTrigData> p)
                    {
                        flpLinearTrigDatas.Controls.Add(p.Value.ConfigUi);
                    });

                //队列触发表
                instance.CurrentProduct.TableTrigDatas.OrderBy((KeyValuePair<Guid, TriggerTableData> p) => p.Value.Id).ThenBy((KeyValuePair<Guid, TriggerTableData> q) => q.Value.Name).ToList()
                    .ForEach(delegate (KeyValuePair<Guid, TriggerTableData> p)
                    {
                        flpTableTrigDatas.Controls.Add(p.Value.ConfigUi);
                    });

                instance.CurrentProduct.InterpolationDatas.OrderBy((KeyValuePair<Guid, InterPolationCfg> p) => p.Value.Id).ThenBy((KeyValuePair<Guid, InterPolationCfg> q) => q.Value.Name).ToList()
                    .ForEach(delegate (KeyValuePair<Guid, InterPolationCfg> p)
                    {
                        flpInterpretation.Controls.Add(p.Value.ConfigUi);
                    });

                instance.CurrentProduct.TrigTabMangerDatas.OrderBy((KeyValuePair<Guid, TrigTabMangerData> p) => p.Value.Id).ThenBy((KeyValuePair<Guid, TrigTabMangerData> q) => q.Value.Name).ToList()
                    .ForEach(delegate (KeyValuePair<Guid, TrigTabMangerData> p)
                    {
                        flpTrigTabManger.Controls.Add(p.Value.ConfigUi);
                    });

                instance.CurrentProduct.ComplexInterPolationDatas.OrderBy((KeyValuePair<Guid, ComplexInterPolationCfg> p) => p.Value.Id).ThenBy((KeyValuePair<Guid, ComplexInterPolationCfg> q) => q.Value.Name).ToList()
                    .ForEach(delegate (KeyValuePair<Guid, ComplexInterPolationCfg> p)
                    {
                        flpComplexInterpolation.Controls.Add(p.Value.ConfigUi);
                    });

                HideTabPages();
            }
            else
            {
                tsCmbProduct.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// 隐藏TabPage
        /// </summary>
        private void HideTabPages()
        {
            if (_instance.CurrentProduct.TrajDatas.Count == 0)
            {
                tpTrajDatas.Parent = null;
            }
            if (_instance.CurrentProduct.LinearTrigDatas.Count == 0)
            {
                tpLinearTrigDatas.Parent = null;
            }
            if (_instance.CurrentProduct.TableTrigDatas.Count == 0)
            {
                tpTableTrigDatas.Parent = null;
            }
            if (_instance.CurrentProduct.InterpolationDatas.Count == 0)
            {
                tpInterpretation.Parent = null;
            }
            if (_instance.CurrentProduct.TrigTabMangerDatas.Count == 0)
            {
                tpTrigManger.Parent = null;
            }
            if (_instance.CurrentProduct.ComplexInterPolationDatas.Count == 0)
            {
                tpComplexInterpolation.Parent = null;
            }
        }
        #endregion
    }
}