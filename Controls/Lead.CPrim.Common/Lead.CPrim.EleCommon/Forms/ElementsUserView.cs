/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ElementsUserView.cs
 * Author: Victor
 * Description: 用来用户元件调试
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 *
 * <3.3.33.0617><Victor><20220711>
 * 1、气缸UI可以根据设定时间间隔及触发次数对气缸多次操作
******************************************************************************/

using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.EleCommon.Forms
{
    public partial class ElementsUserView : UIPage
    {
        #region Field
        /// <summary>元件DI集合</summary>
        private ConcurrentDictionary<string, IEleDI> _eleDis = new ConcurrentDictionary<string, IEleDI>();
        /// <summary>元件DO集合</summary>
        private ConcurrentDictionary<string, IEleDO> _eleDos = new ConcurrentDictionary<string, IEleDO>();
        /// <summary>元件Cylinder集合</summary>
        private ConcurrentDictionary<string, IEleCyldLine> _eleCyls = new ConcurrentDictionary<string, IEleCyldLine>();
        /// <summary>元件Light集合</summary>
        private ConcurrentDictionary<string, IEleLight> _eleLights = new ConcurrentDictionary<string, IEleLight>();
        /// <summary>元件Cartesian集合</summary>
        private ConcurrentDictionary<string, IEleCartesian> _eleCartes = new ConcurrentDictionary<string, IEleCartesian>();
        /// <summary>true：手动；false：自动</summary>
        private bool _enableHandle { get; set; } = false;
        /// <summary>DataGridView集合</summary>
        private DataGridView[] dgvs;
        /// <summary>气缸手动操作</summary>
        private CancellationTokenSource cts;
        /// <summary>气缸手动操作Task</summary>
        private Task _task;
        #endregion



        #region Ctor
        public ElementsUserView()
        {
            InitializeComponent();

            dgvs = new DataGridView[4] { dgvDi, dgvDo, dgvCylinder, dgvLight };
            foreach (var item in dgvs)
            {
                item.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                item.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                item.AllowUserToAddRows = false;
                item.AllowUserToDeleteRows = false;
                item.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

                item.ReadOnly = true;
                item.SetDoubleBuffered();
            }

            NLocalizer.LanguageChanged += OnLanguageChanged;

            for (int j = 0; j < dgvDi.Columns.Count; j++)
            {
                dgvDi.Columns[j].MinimumWidth = j < 2 ? 240 : (j == 2 ? 70 : 50);
            }

            for (int j = 0; j < dgvDo.Columns.Count; j++)
            {
                dgvDo.Columns[j].MinimumWidth = j < 2 ? 240 : (j == 2 ? 70 : 50);
            }

            for (int j = 0; j < dgvCylinder.Columns.Count; j++)
            {
                dgvCylinder.Columns[j].MinimumWidth = j < 2 ? 240 : ((j == 2 || j == 3) ? 50 : 70);
            }

            for (int j = 0; j < dgvLight.Columns.Count; j++)
            {
                dgvLight.Columns[j].MinimumWidth = j < 2 ? 240 : 100;
            }
        }
        #endregion



        #region System_Event
        private void ElementsUserView_Load(object sender, EventArgs e)
        {
            RefreshDgv();
            if (!ElesManager.Instance.DicEles.ContainsKey("DI"))
            {
                tabEles.TabPages.Remove(tpDi);
            }
            if (!ElesManager.Instance.DicEles.ContainsKey("DO"))
            {
                tabEles.TabPages.Remove(tpDo);
            }
            if (!ElesManager.Instance.DicEles.ContainsKey("CylinderLine"))
            {
                tabEles.TabPages.Remove(tpCyl);
            }
            if (!ElesManager.Instance.DicEles.ContainsKey("Light"))
            {
                tabEles.TabPages.Remove(tpLight);
            }
            if (!ElesManager.Instance.DicEles.ContainsKey("Cartesian"))
            {
                tabEles.TabPages.Remove(tpCartesian);
            }

            OnLanguageChanged();
        }

        private void ElementsUserView_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            e.Cancel = true;
        }

        private void dgvDi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int j = 0; j < dgvDi.Columns.Count; j++)
            {
                dgvDi.Columns[j].Width = j < 2 ? 240 : (j == 2 ? 70 : 50);
            }
        }

        private void dgvDo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int j = 0; j < dgvDo.Columns.Count; j++)
            {
                dgvDo.Columns[j].Width = j < 2 ? 240 : (j == 2 ? 70 : 50);
            }
        }

        private void dgvCylinder_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int j = 0; j < dgvCylinder.Columns.Count; j++)
            {
                dgvCylinder.Columns[j].Width = j < 2 ? 240 : ((j == 2 || j == 3) ? 50 : 70);
            }
        }

        private void dgvLight_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int j = 0; j < dgvLight.Columns.Count; j++)
            {
                dgvLight.Columns[j].Width = j < 2 ? 240 : 100;
            }
        }

        private void RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = $"{e.Row.Index + 1}";
        }

        private void dgvDo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!CheckEnable())
            {
                return;
            }
            else if (e.RowIndex <= dgvDo.Rows.Count - 1 && e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                IEleDO val = _eleDos[dgvDo.Rows[e.RowIndex].Cells[0].Value.ToString()];
                if (val != null)
                {
                    val.Toggle();
                }
            }
        }

        private void dgvCylinder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!CheckEnable())
            {
                return;
            }
            else if (e.RowIndex <= dgvCylinder.Rows.Count - 1 && e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                string name = dgvCylinder.Rows[e.RowIndex].Cells[0].Value?.ToString();
                if (string.IsNullOrEmpty(name))
                {
                    return;
                }
                txtCylinderName.Text = name;
                IEleCyldLine val = _eleCyls[name];

                if (val != null)
                {
                    val.Toggle();
                }
            }
        }

        private void dgvLight_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!CheckEnable())
            {
                return;
            }
            else
            {
                if (e.RowIndex > dgvLight.Rows.Count - 1 || e.RowIndex < 0)
                {
                    return;
                }
                IEleLight val = _eleLights[dgvLight.Rows[e.RowIndex].Cells[0].Value.ToString()];
                if (val != null)
                {
                    if (e.ColumnIndex == 2)
                    {
                        val.WriteRed(val.ReadRed() != 1);
                    }
                    if (e.ColumnIndex == 3)
                    {
                        val.WriteYellow(val.ReadYellow() != 1);
                    }
                    if (e.ColumnIndex == 4)
                    {
                        val.WriteGreen(val.ReadGreen() != 1);
                    }
                    if (e.ColumnIndex == 5)
                    {
                        val.WriteBuzz(val.ReadBuzz() != 1);
                    }
                }
            }
        }

        private void ElementsUserView_VisibleChanged(object sender, EventArgs e)
        {
            ElementsUserView view = sender as ElementsUserView;
            if (view != null)
            {
                if (view.Visible)
                {
                    timer1.Start();
                }
                else
                {
                    timer1.Stop();
                }
            }
        }
        #endregion



        #region Button_Event
        /// <summary>气缸执行</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckEnable())
                {
                    return;
                }
                Stopwatch sw = new Stopwatch();
                string name = "";
                int time = 0;
                int count = 0;

                name = string.IsNullOrEmpty(txtCylinderName.Text) ? throw new Exception(NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_ErrMsg_CylinderNameIsEmpty", "气缸名称为空")) : txtCylinderName.Text;
                if (!int.TryParse(txtTime.Text, out time))
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_ErrMsg_IntervalTimeError", "时间间隔值无效"));
                }
                if (!int.TryParse(txtCount.Text, out count))
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_ErrMsg_TrigCountError", "触发次数值无效"));
                }
                if (count < 1 || count > 100)
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_ErrMsg_TrigCountOutRange", "触发次数1-100"));
                }

                tb_Stretch_Cylinder.Text = "";
                tb_Retract_Cylinder.Text = "";

                IEle ele = ElesManager.Instance.GetEleByName(name);
                if (ele == null)
                {
                    return;
                }
                IEleCyldLine val = (IEleCyldLine)ele;
                if (val == null)
                {
                    return;
                }
                if (cts == null)
                {
                    cts = new CancellationTokenSource();
                }
                _task = Task.Factory.StartNew(() =>
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    count = count * 2;
                    for (int i = 0; i < count; i++)
                    {
                        if (val != null)
                        {
                            // val.Toggle();
                            if (i % 2 == 0)
                            {
                                stopWatch.Restart();
                                val.CyldStretch(true, false);
                                stopWatch.Stop();
                                tb_Stretch_Cylinder.BeginInvoke(new Action(() => { tb_Stretch_Cylinder.Text = stopWatch.ElapsedMilliseconds.ToString(); }));
                            }
                            else
                            {
                                stopWatch.Restart();
                                val.CyldRetract(true, false);
                                stopWatch.Stop();
                                tb_Retract_Cylinder.BeginInvoke(new Action(() => { tb_Retract_Cylinder.Text = stopWatch.ElapsedMilliseconds.ToString(); }));
                            }
                        }

                        sw.Restart();
                        while (true)
                        {
                            if (cts.IsCancellationRequested)
                            {
                                return;
                            }

                            if (sw.ElapsedMilliseconds > time)
                            {
                                break;
                            }

                            Thread.Sleep(5);
                        }
                    }
                }, cts.Token);
            }
            catch (Exception ex)
            {
                ElesManager.Instance.LogAdd(NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_ErrMsg_CylinderStartFail", "气缸执行失败:") + ex.Message, LogLevel.Warn);
            }
        }

        /// <summary>停止</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckEnable())
                {
                    return;
                }
                if (cts != null)
                {
                    cts.Cancel();
                    _task.Wait();
                    cts.Dispose();
                    cts = null;
                }
            }
            catch (Exception ex)
            {
                ElesManager.Instance.LogAdd(NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_ErrMsg_CylinderStopFail", "气缸停止失败:") + ex.Message, LogLevel.Warn);
            }
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>UI刷新</summary>
        internal void RefreshDgv()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(RefreshDgv));
                return;
            }

            timer1.Stop();
            _eleDis.Clear();
            _eleDos.Clear();
            _eleCyls.Clear();
            _eleLights.Clear();
            _eleCartes.Clear();
            foreach (IEle item in ElesManager.Instance.ListEle)
            {
                switch (item.EleTypeName)
                {
                    case "DI":
                        _eleDis.TryAdd(item.Name, (IEleDI)item);
                        item.IEleInit();
                        break;
                    case "DO":
                        _eleDos.TryAdd(item.Name, (IEleDO)item);
                        item.IEleInit();
                        break;
                    case "CylinderLine":
                        _eleCyls.TryAdd(item.Name, (IEleCyldLine)item);
                        item.IEleInit();
                        break;
                    case "Cartesian":
                        _eleCartes.TryAdd(item.Name, (IEleCartesian)item);
                        break;
                    case "Light":
                        _eleLights.TryAdd(item.Name, (IEleLight)item);
                        break;
                }
            }
            dgvDi.Rows.Clear();
            dgvDo.Rows.Clear();
            dgvCylinder.Rows.Clear();
            dgvLight.Rows.Clear();
            foreach (IEleDI item2 in _eleDis.Values.OrderBy((IEleDI p) => p.DiAddress))
            {
                dgvDi.Rows.Add(((IEle)item2).Name, NLocalizer.GetString(((IEle)item2).Name, ((IEle)item2).Name), item2.DiAddress.ToString("f2"), pbGray.Image);
            }
            dgvDi.Columns[0].Visible = false;

            foreach (IEleDO item3 in _eleDos.Values.OrderBy((IEleDO p) => p.DoAddress))
            {
                dgvDo.Rows.Add(((IEle)item3).Name, NLocalizer.GetString(((IEle)item3).Name, ((IEle)item3).Name), item3.DoAddress.ToString("f2"), pbGray.Image);
            }
            dgvDo.Columns[0].Visible = false;

            foreach (IEleCyldLine item4 in _eleCyls.Values.OrderBy((IEleCyldLine p) => p.StretchDoAddress))
            {
                dgvCylinder.Rows.Add(((IEle)item4).Name, NLocalizer.GetString(((IEle)item4).Name, ((IEle)item4).Name), pbGray.Image, pbGray.Image);
            }
            dgvCylinder.Columns[0].Visible = false;

            foreach (IEleLight item5 in _eleLights.Values.OrderBy((IEleLight p) => p.GreenAddress))
            {
                dgvLight.Rows.Add(((IEle)item5).Name, NLocalizer.GetString(((IEle)item5).Name, ((IEle)item5).Name), pbGray.Image, pbGray.Image, pbGray.Image, pbGray.Image);
            }
            dgvLight.Columns[0].Visible = false;

            LoadCartersian();
            timer1.Start();
        }

        /// <summary>手自动切换</summary>
        /// <param name="enable">true：手动；false：自动</param>
        internal void EnableHandle(bool enable)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(EnableHandle), enable);
            }
            else
            {
                _enableHandle = enable;
            }
        }

        /// <summary>使能状态设置</summary>
        /// <param name="enable">true：使能状态；false：非使能状态</param>
        internal void SetEnable(bool enable)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetEnable), enable);
                return;
            }
            foreach (Control con in tpDi.Controls)
            {
                con.Enabled = enable;
            }
            foreach (Control con in tpDo.Controls)
            {
                con.Enabled = enable;
            }
            foreach (Control con in tpCyl.Controls)
            {
                con.Enabled = enable;
            }
            foreach (Control con in tpLight.Controls)
            {
                con.Enabled = enable;
            }
            foreach (Control con in tpCartesian.Controls)
            {
                con.Enabled = enable;
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>手自动检查</summary>
        /// <returns>true：检查通过；false：检查未通过</returns>
        private bool CheckEnable()
        {
            if (!_enableHandle)
            {
                UIMessageTip.ShowWarning(NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_ErrMsg_NoOperationFristChangeToManual", "禁止操作,请切换至手动!!!"));
                return false;
            }
            return true;
        }

        /// <summary>加载轴UI</summary>
        private void LoadCartersian()
        {
            tabCartesians.TabPages.Clear();
            foreach (IEleCartesian item in _eleCartes.Values.OrderBy((IEleCartesian p) => p.AxisXIndex))
            {
                tabCartesians.TabPages.Add(((IEle)item).Name, NLocalizer.GetString(((IEle)item).Name, ((IEle)item).Name));
                ((IEle)item).IEleUiRefresh();
                ((IEle)item).EleDebugUI.Dock = DockStyle.Fill;
                tabCartesians.TabPages[((IEle)item).Name].Controls.Add(((IEle)item).EleDebugUI);
            }
        }

        /// <summary>DI刷新</summary>
        private void RefreshDi()
        {
            if (dgvDi.InvokeRequired)
            {
                BeginInvoke(new Action(RefreshDi));
                return;
            }
            for (int i = 0; i < dgvDi.Rows.Count; i++)
            {
                IEleDI val = _eleDis[dgvDi.Rows[i].Cells[0].Value.ToString()];
                if (val != null)
                {
                    dgvDi.Rows[i].Cells[1].Value = NLocalizer.GetString(dgvDi.Rows[i].Cells[0].Value.ToString(), dgvDi.Rows[i].Cells[0].Value.ToString());
                    Image image = val.Read() ? pbBlue.Image : pbGray.Image;
                    if (dgvDi.Rows[i].Cells[3].Value != image)
                    {
                        dgvDi.Rows[i].Cells[3].Value = image;
                    }
                }
            }

            if (dgvDi.SelectedCells != null)
            {
                dgvDi.ClearSelection();
            }
        }

        /// <summary>DO刷新</summary>
        private void RefreshDo()
        {
            if (dgvDo.InvokeRequired)
            {
                BeginInvoke(new Action(RefreshDo));
                return;
            }
            for (int i = 0; i < dgvDo.Rows.Count; i++)
            {
                IEleDO val = _eleDos[dgvDo.Rows[i].Cells[0].Value.ToString()];
                if (val != null)
                {
                    dgvDo.Rows[i].Cells[1].Value = NLocalizer.GetString(dgvDo.Rows[i].Cells[0].Value.ToString(), dgvDo.Rows[i].Cells[0].Value.ToString());
                    Image image = val.Read() ? pbBlue.Image : pbGray.Image;
                    if (dgvDo.Rows[i].Cells[3].Value != image)
                    {
                        dgvDo.Rows[i].Cells[3].Value = image;
                    }
                }
            }

            if (dgvDo.SelectedCells != null)
            {
                dgvDo.ClearSelection();
            }
        }

        /// <summary>Cylinder刷新</summary>
        private void RefreshCyl()
        {
            if (dgvCylinder.InvokeRequired)
            {
                BeginInvoke(new Action(RefreshCyl));
                return;
            }
            for (int i = 0; i < dgvCylinder.Rows.Count; i++)
            {
                IEleCyldLine val = _eleCyls[dgvCylinder.Rows[i].Cells[0].Value.ToString()];
                if (val != null)
                {
                    dgvCylinder.Rows[i].Cells[1].Value = NLocalizer.GetString(dgvCylinder.Rows[i].Cells[0].Value.ToString(), dgvCylinder.Rows[i].Cells[0].Value.ToString());
                    int num = val.CheckCylState();
                    if (val.CyldType == EleCyldType.Cylinder)
                    {
                        dgvCylinder.Rows[i].Cells[2].Value = num == 0 ? pbBlue.Image : (num == 2 ? pbRed.Image : pbGray.Image);

                        dgvCylinder.Rows[i].Cells[3].Value = num == 1 ? pbBlue.Image : (num == 3 ? pbRed.Image : pbGray.Image);
                    }
                    else
                    {
                        dgvCylinder.Rows[i].Cells[2].Value = pbGray.Image;
                        dgvCylinder.Rows[i].Cells[3].Value = num == 1 ? pbBlue.Image : (num == 3 ? pbRed.Image : pbGray.Image);
                    }
                }
            }

            if (dgvCylinder.SelectedCells != null)
            {
                dgvCylinder.ClearSelection();
            }
        }
        /// <summary>Cartesian刷新</summary>
        private void RefreshCartesian()
        {
            if (tabCartesians.TabCount > 0 && tabCartesians.SelectedTab != null)
            {
                string name = tabCartesians.SelectedTab.Name;
                if (_eleCartes.ContainsKey(name))
                {
                    _eleCartes[name].RefreshDebugUi();
                }
            }
        }
        /// <summary>Light刷新</summary>
        private void RefreshLight()
        {
            if (dgvLight.InvokeRequired)
            {
                BeginInvoke(new Action(RefreshLight));
                return;
            }
            for (int i = 0; i < dgvLight.Rows.Count; i++)
            {
                IEleLight val = _eleLights[dgvLight.Rows[i].Cells[0].Value.ToString()];
                if (val != null)
                {
                    dgvLight.Rows[i].Cells[1].Value = NLocalizer.GetString(dgvLight.Rows[i].Cells[0].Value.ToString(), dgvLight.Rows[i].Cells[0].Value.ToString());
                    Image red = val.ReadRed() == 1 ? pbRed.Image : pbGray.Image;
                    Image yellow = val.ReadYellow() == 1 ? pbYellow.Image : pbGray.Image;
                    Image green = val.ReadGreen() == 1 ? pbGreen.Image : pbGray.Image;
                    Image buzz = val.ReadBuzz() == 1 ? pbRed.Image : pbGray.Image;

                    if (dgvLight.Rows[i].Cells[2].Value != red)
                    {
                        dgvLight.Rows[i].Cells[2].Value = red;
                    }
                    if (dgvLight.Rows[i].Cells[3].Value != yellow)
                    {
                        dgvLight.Rows[i].Cells[3].Value = yellow;
                    }
                    if (dgvLight.Rows[i].Cells[4].Value != green)
                    {
                        dgvLight.Rows[i].Cells[4].Value = green;
                    }
                    if (dgvLight.Rows[i].Cells[5].Value != buzz)
                    {
                        dgvLight.Rows[i].Cells[5].Value = buzz;
                    }
                }
            }

            if (dgvLight.SelectedCells != null)
            {
                dgvLight.ClearSelection();
            }
        }
        /// <summary>UI定时刷新</summary>
        private void RefreshUI()
        {
            if (tabEles.InvokeRequired)
            {
                BeginInvoke(new Action(RefreshUI));
                return;
            }
            if (tabEles.SelectedTab.Name == "tpDi")
            {
                RefreshDi();
            }
            if (tabEles.SelectedTab.Name == "tpDo")
            {
                RefreshDo();
            }
            if (tabEles.SelectedTab.Name == "tpCyl")
            {
                RefreshCyl();
            }
            if (tabEles.SelectedTab.Name == "tpCartesian")
            {
                RefreshCartesian();
            }
            if (tabEles.SelectedTab.Name == "tpLight")
            {
                RefreshLight();
            }
        }

        /// <summary>刷新定时器</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (!Created || !IsHandleCreated)
            {
                return;
            }

            RefreshUI();

            if (_task != null)
            {
                if (_task.Status == TaskStatus.Running)
                {
                    btnStart.BackColor = Color.LimeGreen;
                    btnStop.BackColor = SystemColors.AppWorkspace;
                }
                else
                {
                    btnStart.BackColor = SystemColors.AppWorkspace;
                    btnStop.BackColor = Color.Red;
                }
            }
        }
        #endregion

        public void OnLanguageChanged()
        {
            tpDi.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_DI", "数字量输入");
            tpDo.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_DO", "数字量输出");
            tpCyl.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_Cylinder", "气缸/真空");
            tpLight.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_Light", "三色灯/按钮灯");
            tpCartesian.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_Cartesian", "轴组");

            diName.HeaderText = doName.HeaderText = cylName.HeaderText = lb_CylinderName.Text = colLightName.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_Name", "名称");
            diAdr.HeaderText = doAdr.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_Address", "地址");
            diStatue.HeaderText = doStatue.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_State", "状态");
            colEleDiInfo.HeaderText = colEleDoInfo.HeaderText = colEleCylInfo.HeaderText = colEleLightInfo.HeaderText = NLocalizer.GetString("Info", "信息");

            cylHP.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_CylinderBasePos", "原位");
            cylWP.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_CylinderWorkPos", "伸位");
            lb_IntervalTime.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_IntervalTime", "间隔时间");
            lb_TrigCount.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_TrigCount", "触发次数");
            btnStart.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_Start", "执行");
            btnStop.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_Stop", "停止");
            colLightRed.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_Light_R", "红灯");
            colLightYellow.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_Light_Y", "黄灯");
            colLightGreen.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_Light_G", "绿灯");
            colLightBuzzer.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_ElementsUserView_Light_Buzzer", "蜂鸣器");

            foreach (TabPage item in tabCartesians.TabPages)
            {
                item.Text = NLocalizer.GetString(item.Name, item.Name);
            }
        }
    }
}
