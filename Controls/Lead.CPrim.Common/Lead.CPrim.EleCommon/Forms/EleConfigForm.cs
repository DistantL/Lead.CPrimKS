using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.Win32;
using Sunny.UI;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lead.CPrim.EleCommon.Forms
{
    public partial class EleConfigForm : UIPage
    {
        #region Field
        /// <summary>元件重名检测</summary>
        private ConcurrentDictionary<string, int> _concurrentNameRepeat = new ConcurrentDictionary<string, int>();

        private Dictionary<string, FlowLayoutPanel> _dicPanel = new Dictionary<string, FlowLayoutPanel>();

        /// <summary>false：自动/true：手动</summary>
        private bool _enableHandle = false;

        /// <summary>单元格背景红色</summary>
        private DataGridViewCellStyle _resetStyle = new DataGridViewCellStyle { BackColor = Color.Red };

        /// <summary>单元格背景绿色</summary>
        private DataGridViewCellStyle _setStyle = new DataGridViewCellStyle { BackColor = Color.LawnGreen };

        /// <summary>排序中</summary>
        private bool _sorting = false;

        /// <summary>元件属性公共接口支持类型</summary>
        private Dictionary<string, IEleTypeAttributes> _supportedEleTypes;
        /// <summary>单元格背景灰色</summary>
        private DataGridViewCellStyle _unknownStyle = new DataGridViewCellStyle { BackColor = Color.LightGray };
        /// <summary>DataGridView集合</summary>
        DataGridView[] dgvs;
        #endregion



        //*****************************************************************************
        #region Ctor
        public EleConfigForm()
        {
            InitializeComponent();
            //DockHandler.HideOnClose = true;

            dgvs = new DataGridView[] { dgvEleDi, dgvEleDo, dgvEleCylinder };
            foreach (DataGridView dgv in dgvs)
            {
                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = true;
                dgv.ReadOnly = false;
                dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter };
                dgv.RowHeadersWidth = 51;
                dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                dgv.SetDoubleBuffered();
            }

            tsb_Debug_Click(null, null);

            NLocalizer.LanguageChanged += OnLanguageChanged;

            for (int j = 0; j < dgvEleCylinder.Columns.Count; j++)
            {
                if (j == 0 || j == 1)
                {
                    dgvEleCylinder.Columns[j].MinimumWidth = 200;
                }
                else if (j == 4 || j == 5 || j == 6 || j == 21)
                {
                    dgvEleCylinder.Columns[j].MinimumWidth = 100;
                }
                else
                {
                    dgvEleCylinder.Columns[j].MinimumWidth = 50;
                }
            }

            for (int j = 0; j < dgvEleDi.Columns.Count; j++)
            {
                if (j == 0 || j == 1)
                {
                    dgvEleDi.Columns[j].MinimumWidth = 200;
                }
                else if (j == 4 || j == 5 || j == 12)
                {
                    dgvEleDi.Columns[j].MinimumWidth = 100;
                }
                else
                {
                    dgvEleDi.Columns[j].MinimumWidth = 60;
                }
            }

            for (int j = 0; j < dgvEleDo.Columns.Count; j++)
            {
                if (j == 0 || j == 1)
                {
                    dgvEleDo.Columns[j].MinimumWidth = 200;
                }
                else if (j == 4 || j == 5 || j == 11)
                {
                    dgvEleDo.Columns[j].MinimumWidth = 100;
                }
                else
                {
                    dgvEleDo.Columns[j].MinimumWidth = 60;
                }
            }
        }
        #endregion



        //*****************************************************************************
        #region System_Event
        /// <summary>元件配置界面增加元件图标及事件</summary>
        public int EleToolBarFormLoad()
        {
            int result = 0;
            _supportedEleTypes = ElesManager.Instance.SupportedEleTypes;
            foreach (KeyValuePair<string, IEleTypeAttributes> supportedEleType in _supportedEleTypes)
            {
                ToolStripButton toolStripButton = new ToolStripButton
                {
                    ImageScaling = ToolStripItemImageScaling.None,
                    AutoSize = false,
                    BackgroundImageLayout = ImageLayout.Center,
                    DisplayStyle = ToolStripItemDisplayStyle.Image,
                    BackgroundImage = supportedEleType.Value.Icon,
                    Tag = supportedEleType.Key,
                    Size = new Size(56, 52),
                    Text = supportedEleType.Key
                };
                toolStripButton.Click += btnAddElement_Click;
                tsEles.Items.Add(toolStripButton);
            }
            foreach (TabPage tabPage in tabElements.TabPages)
            {
                //Regex.Split 方法 (String, String)   在由正则表达式模式定义的位置将输入字符串拆分为一个子字符串数组。
                if (!_supportedEleTypes.Keys.Contains(Regex.Split(tabPage.Name, "tp")[1]))
                {
                    tabPage.Parent = null;
                }
            }
            return result;
        }

        private void EleConfigForm_Load(object sender, EventArgs e)
        {
            if (ElesManager.Instance.DicEles == null || ElesManager.Instance.DicEles.Count == 0) return;

            #region DI
            foreach (IEle item in from p in ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName == "DI") orderby ((IEleDI)p).DiAddress select p)
            {
                AddEleDi(item, newFlag: false);
            }
            #endregion

            #region DO
            foreach (IEle item2 in from p in ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName == "DO") orderby ((IEleDO)p).DoAddress select p)
            {
                AddEleDo(item2, newFlag: false);
            }
            #endregion

            #region Cylinder
            foreach (IEle item3 in from p in ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName == "CylinderLine") orderby ((IEleCyldLine)p).StretchDoAddress select p)
            {
                AddEleCylinder(item3, newFlag: false);
            }
            #endregion

            #region Cartesian
            foreach (IEle item4 in from p in ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName == "Cartesian") orderby p.Name select p)
            {
                AddEleCartesian(item4, newFlag: false);
            }
            #endregion

            #region AD DA Light
            foreach (KeyValuePair<string, string> dicEle in ElesManager.Instance.DicEles)
            {
                if (dicEle.Key == null) continue;

                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
                {
                    Name = dicEle.Key + "Panel",
                    Dock = DockStyle.Fill,
                    AutoScroll = true
                };
                string text = "";
                List<IEle> list = null;
                switch (dicEle.Key)
                {
                    case "AD":
                        text = "AD";
                        list = ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName == "AD");
                        break;
                    case "DA":
                        text = "DA";
                        list = ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName == "DA");
                        break;
                    case "AxisLine":
                        text = "AxisLine";
                        list = ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName == "EleAxisLine");
                        break;
                    case "Light":
                        text = "Light";
                        list = ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName == "Light");
                        break;
                }
                if (string.IsNullOrEmpty(text) || list == null) continue;

                foreach (IEle item5 in list.OrderBy((IEle p) => p.Name))
                {
                    item5.EleConfigUI.Dock = DockStyle.Top;
                    flowLayoutPanel.Controls.Add(item5.EleConfigUI);
                }
                tabElements.TabPages["tp" + text].Controls.Add(flowLayoutPanel);
                _dicPanel.Add(flowLayoutPanel.Name, flowLayoutPanel);
            }
            #endregion

            #region 初始化
            foreach (IEle item6 in ElesManager.Instance.ListEle)
                item6.IEleInit();
            #endregion

            #region 界面管理
            if (!ElesManager.Instance.DicEles.ContainsKey("DI")) tabElements.TabPages.Remove(tpDI);
            if (!ElesManager.Instance.DicEles.ContainsKey("DO")) tabElements.TabPages.Remove(tpDO);
            if (!ElesManager.Instance.DicEles.ContainsKey("CylinderLine")) tabElements.TabPages.Remove(tpCylinderLine);
            if (!ElesManager.Instance.DicEles.ContainsKey("AD")) tabElements.TabPages.Remove(tpAD);
            if (!ElesManager.Instance.DicEles.ContainsKey("DA")) tabElements.TabPages.Remove(tpDA);
            if (!ElesManager.Instance.DicEles.ContainsKey("AxisLine")) tabElements.TabPages.Remove(tpAxisLine);
            if (!ElesManager.Instance.DicEles.ContainsKey("Light")) tabElements.TabPages.Remove(tpLight);
            if (!ElesManager.Instance.DicEles.ContainsKey("Cartesian")) tabElements.TabPages.Remove(tpCartesian);
            #endregion

            OnLanguageChanged();
        }

        #region CellFormatting
        private void dgvEleCylinder_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int j = 0; j < dgvEleCylinder.Columns.Count; j++)
            {
                if (j == 0 || j == 1)
                {
                    dgvEleCylinder.Columns[j].Width = 200;
                }
                else if (j == 4 || j == 5 || j == 6 || j == 21)
                {
                    dgvEleCylinder.Columns[j].Width = 100;
                }
                else
                {
                    dgvEleCylinder.Columns[j].Width = 50;
                }
            }
        }

        private void dgvEleDi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int j = 0; j < dgvEleDi.Columns.Count; j++)
            {
                if (j == 0 || j == 1)
                {
                    dgvEleDi.Columns[j].Width = 200;
                }
                else if (j == 4 || j == 5 || j == 12)
                {
                    dgvEleDi.Columns[j].Width = 100;
                }
                else
                {
                    dgvEleDi.Columns[j].Width = 60;
                }
            }
        }
        private void dgvEleDo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int j = 0; j < dgvEleDo.Columns.Count; j++)
            {
                if (j == 0 || j == 1)
                {
                    dgvEleDo.Columns[j].Width = 200;
                }
                else if (j == 4 || j == 5 || j == 11)
                {
                    dgvEleDo.Columns[j].Width = 100;
                }
                else
                {
                    dgvEleDo.Columns[j].Width = 60;
                }
            }
        }
        #endregion

        #region RowStateChanged_行进行计数
        private void dgvEleCylinder_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = $"{e.Row.Index + 1}";
        }

        private void dgvEleDi_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = $"{e.Row.Index + 1}";
        }
        private void dgvEleDo_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = $"{e.Row.Index + 1}";
        }
        #endregion

        #region CellContentClick_单击事件
        private void dgvEleCylinder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            if (columnIndex < 0 || rowIndex < 0 || dgvEleCylinder.Rows[rowIndex].Cells[0].Value == null || (columnIndex != 13 && columnIndex != 16) || !CheckManualEnable())
            {
                return;
            }
            string eleName = dgvEleCylinder.Rows[rowIndex].Cells[0].Value.ToString();
            IEle eleByName = ElesManager.Instance.GetEleByName(eleName);
            if (eleByName != null && eleByName is IEleCyldLine)
            {
                if (columnIndex == 13)
                {
                    ((IEleCyldLine)eleByName).WriteStretchDO(!((IEleCyldLine)eleByName).StretchDo_On);
                }
                if (columnIndex == 16)
                {
                    ((IEleCyldLine)eleByName).WriteRestractDO(!((IEleCyldLine)eleByName).RestractDo_On);
                }
            }
        }

        private void dgvEleDo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            if (columnIndex >= 0 && rowIndex >= 0 && dgvEleDo.Rows[rowIndex].Cells[0].Value != null && columnIndex == 9 && CheckManualEnable())
            {
                string eleName = dgvEleDo.Rows[rowIndex].Cells[0].Value.ToString();
                IEle eleByName = ElesManager.Instance.GetEleByName(eleName);
                if (eleByName != null && eleByName is IEleDO)
                {
                    ((IEleDO)eleByName).Toggle();
                }
            }
        }
        #endregion

        #region CellEnter_解决DataGridViewComboBoxColumn首次必须点击2次才可弹出
        private void dgvEleCylinder_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEleCylinder.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && e.RowIndex != -1)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void dgvEleDi_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEleDi.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && e.RowIndex != -1)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void dgvEleDo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEleDo.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && e.RowIndex != -1)
            {
                SendKeys.Send("{F4}");
            }
        }
        #endregion

        #region CurrentCellDirtyStateChanged_解决DataGridViewCheckBoxColumn必须按Enter键才生效
        private void dgvEleCylinder_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvEleCylinder.IsCurrentCellDirty)
            {
                dgvEleCylinder.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvEleDi_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvEleDi.IsCurrentCellDirty)
            {
                dgvEleDi.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void dgvEleDo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvEleDo.IsCurrentCellDirty)
            {
                dgvEleDo.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        #endregion

        #region CellValueChanged_解决元件及时更新以及格式防呆
        private void dgvEleCylinder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex > dgvEleCylinder.Rows.Count - 1)
                {
                    return;
                }

                DataGridViewRow dataGridViewRow = dgvEleCylinder.Rows[e.RowIndex];
                object cell0Value = dataGridViewRow.Cells[0].Value;
                if (cell0Value == null || string.IsNullOrEmpty(cell0Value.ToString()))
                {
                    return;
                }

                IEle eleByName = ElesManager.Instance.GetEleByName(cell0Value.ToString());
                if (eleByName == null)
                {
                    return;
                }

                switch (e.ColumnIndex)
                {
                    case 1:
                        eleByName.Info = dataGridViewRow.Cells[1].Value.ToString();
                        break;
                    case 2:
                        eleByName.Enable = Convert.ToBoolean(dataGridViewRow.Cells[2].Value);
                        break;
                    case 3:
                        eleByName.IsSimulateMode = Convert.ToBoolean(dataGridViewRow.Cells[3].Value);
                        break;
                    case 5:
                        eleByName.DevName = dataGridViewRow.Cells[5].Value?.ToString();
                        break;
                    case 6:
                        {
                            if (dataGridViewRow.Cells[6].Value != null && Enum.TryParse<EleCyldType>(dataGridViewRow.Cells[6].Value.ToString(), out EleCyldType result))
                            {
                                if ((int)result == 2)
                                {
                                    dataGridViewRow.Cells[9].ReadOnly = true;
                                    dataGridViewRow.Cells[9].Style.BackColor = Color.DarkGray;

                                    dataGridViewRow.Cells[10].Value = false;
                                    dataGridViewRow.Cells[10].ReadOnly = true;
                                    dataGridViewRow.Cells[10].Style.BackColor = Color.DarkGray;

                                    dataGridViewRow.Cells[19].ReadOnly = false;
                                    dataGridViewRow.Cells[19].Style.BackColor = Color.DarkGray;
                                }
                                else
                                {
                                    dataGridViewRow.Cells[9].ReadOnly = false;
                                    dataGridViewRow.Cells[9].Style.BackColor = Color.WhiteSmoke;

                                    dataGridViewRow.Cells[10].ReadOnly = false;
                                    dataGridViewRow.Cells[10].Style.BackColor = Color.WhiteSmoke;

                                    dataGridViewRow.Cells[19].ReadOnly = true;
                                    dataGridViewRow.Cells[19].Style.BackColor = Color.WhiteSmoke;
                                }
                            }
                            break;
                        }
                    case 7:
                        {
                            if (dataGridViewRow.Cells[7].Value != null && double.TryParse(dataGridViewRow.Cells[7].Value.ToString(), out var result))
                            {
                                ((IEleCyldLine)eleByName).StretchDiAddress = result;
                            }
                            else
                            {
                                ((IEleCyldLine)eleByName).StretchDiAddress = 0.0;
                                dataGridViewRow.Cells[7].Value = 0.0;
                            }
                            break;
                        }
                    case 8:
                        ((IEleCyldLine)eleByName).StretchDiEnable = Convert.ToBoolean(dataGridViewRow.Cells[8].Value);
                        break;
                    case 9:
                        {
                            if (dataGridViewRow.Cells[9].Value != null && double.TryParse(dataGridViewRow.Cells[9].Value.ToString(), out var result))
                            {
                                ((IEleCyldLine)eleByName).RestractDiAddress = result;
                            }
                            else
                            {
                                ((IEleCyldLine)eleByName).RestractDiAddress = 0.0;
                                dataGridViewRow.Cells[9].Value = 0.0;
                            }
                            break;
                        }
                    case 10:
                        ((IEleCyldLine)eleByName).RestractDiEnable = Convert.ToBoolean(dataGridViewRow.Cells[10].Value);
                        break;
                    case 11:
                        {
                            if (dataGridViewRow.Cells[11].Value != null && double.TryParse(dataGridViewRow.Cells[11].Value.ToString(), out var result))
                            {
                                ((IEleCyldLine)eleByName).StretchDoAddress = result;
                            }
                            else
                            {
                                ((IEleCyldLine)eleByName).StretchDoAddress = 0.0;
                                dataGridViewRow.Cells[11].Value = 0.0;
                            }
                            break;
                        }
                    case 12:
                        ((IEleCyldLine)eleByName).StretchDoEnable = Convert.ToBoolean(dataGridViewRow.Cells[12].Value);
                        break;
                    case 14:
                        {
                            if (dataGridViewRow.Cells[14].Value != null && double.TryParse(dataGridViewRow.Cells[14].Value.ToString(), out var result))
                            {
                                ((IEleCyldLine)eleByName).RestractDoAddress = result;
                            }
                            else
                            {
                                ((IEleCyldLine)eleByName).RestractDoAddress = 0.0;
                                dataGridViewRow.Cells[14].Value = 0.0;
                            }
                            break;
                        }
                    case 15:
                        ((IEleCyldLine)eleByName).RestractDoEnable = Convert.ToBoolean(dataGridViewRow.Cells[15].Value);
                        break;
                    case 17:
                        {
                            if (dataGridViewRow.Cells[17].Value != null && int.TryParse(dataGridViewRow.Cells[17].Value.ToString(), out var result))
                            {
                                ((IEleCyldLine)eleByName).StretchTimeOut = result;
                            }
                            else
                            {
                                ((IEleCyldLine)eleByName).StretchTimeOut = 4000;
                                dataGridViewRow.Cells[17].Value = 4000;
                            }
                            break;
                        }
                    case 18:
                        {
                            if (dataGridViewRow.Cells[18].Value != null && int.TryParse(dataGridViewRow.Cells[18].Value.ToString(), out var result))
                            {
                                ((IEleCyldLine)eleByName).RestractTimeOut = result;
                            }
                            else
                            {
                                ((IEleCyldLine)eleByName).RestractTimeOut = 4000;
                                dataGridViewRow.Cells[18].Value = 4000;
                            }
                            break;
                        }
                    case 19:
                        {
                            if (dataGridViewRow.Cells[19].Value != null && int.TryParse(dataGridViewRow.Cells[19].Value.ToString(), out var result))
                            {
                                ((IEleCyldLine)eleByName).BlowTime = result;
                            }
                            else
                            {
                                ((IEleCyldLine)eleByName).BlowTime = 200;
                                dataGridViewRow.Cells[19].Value = 200;
                            }
                            break;
                        }
                    case 21:
                        {
                            ((IEleCyldLine)eleByName).LineMark = dataGridViewRow.Cells[21].Value?.ToString();
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                ElesManager.Instance.LogAdd(NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ErrMsg_CylinderCellValueChanged", "气缸表格单元格报错:") + ex.Message, LogLevel.Error);
            }
        }

        private void dgvEleDi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex > dgvEleDi.Rows.Count - 1)
                {
                    return;
                }

                DataGridViewRow dataGridViewRow = dgvEleDi.Rows[e.RowIndex];
                object cell0Value = dataGridViewRow.Cells[0].Value;
                if (cell0Value == null || string.IsNullOrEmpty(cell0Value.ToString()))
                {
                    return;
                }

                IEle eleByName = ElesManager.Instance.GetEleByName(cell0Value.ToString());
                if (eleByName != null)
                {
                    switch (e.ColumnIndex)
                    {
                        case 1:
                            eleByName.Info = dataGridViewRow.Cells[1].Value.ToString();
                            break;
                        case 2:
                            eleByName.Enable = Convert.ToBoolean(dataGridViewRow.Cells[2].Value);
                            break;
                        case 3:
                            eleByName.IsSimulateMode = Convert.ToBoolean(dataGridViewRow.Cells[3].Value);
                            break;
                        case 5:
                            eleByName.DevName = dataGridViewRow.Cells[5].Value?.ToString();
                            break;
                        case 6:
                            {
                                if (dataGridViewRow.Cells[6].Value != null && double.TryParse(dataGridViewRow.Cells[6].Value.ToString(), out var result))
                                {
                                    ((IEleDI)eleByName).DiAddress = result;
                                }
                                else
                                {
                                    ((IEleDI)eleByName).DiAddress = 0.0;
                                    dataGridViewRow.Cells[6].Value = 0.0;
                                }
                                break;
                            }
                        case 7:
                            ((IEleDI)eleByName).DiEnable = Convert.ToBoolean(dataGridViewRow.Cells[7].Value);
                            break;
                        case 8:
                            if (dataGridViewRow.Cells[8].Value != null && dataGridViewRow.Cells[8].Value.ToString() == "NC")
                                ((IEleDI)eleByName).DiType = (EleDIType)2;
                            else
                                ((IEleDI)eleByName).DiType = (EleDIType)1;
                            break;
                        case 9:
                            ((IEleDI)eleByName).EnRiseEvent = Convert.ToBoolean(dataGridViewRow.Cells[9].Value);
                            break;
                        case 10:
                            ((IEleDI)eleByName).EnFallEvent = Convert.ToBoolean(dataGridViewRow.Cells[10].Value);
                            break;
                        case 12:
                            ((IEleDI)eleByName).LineMark = dataGridViewRow.Cells[12].Value?.ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ElesManager.Instance.LogAdd(NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ErrMsg_DICellValueChanged", "输入表格单元格报错:") + ex.Message, LogLevel.Error);
            }
        }
        private void dgvEleDo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex > dgvEleDo.Rows.Count - 1)
                {
                    return;
                }

                DataGridViewRow dataGridViewRow = dgvEleDo.Rows[e.RowIndex];
                object cell0Value = dataGridViewRow.Cells[0].Value;
                if (cell0Value == null || string.IsNullOrEmpty(cell0Value.ToString()))
                {
                    return;
                }
                IEle eleByName = ElesManager.Instance.GetEleByName(cell0Value.ToString());
                if (eleByName != null)
                {
                    switch (e.ColumnIndex)
                    {
                        case 1:
                            eleByName.Info = dataGridViewRow.Cells[1].Value.ToString();
                            break;
                        case 2:
                            eleByName.Enable = Convert.ToBoolean(dataGridViewRow.Cells[2].Value);
                            break;
                        case 3:
                            eleByName.IsSimulateMode = Convert.ToBoolean(dataGridViewRow.Cells[3].Value);
                            break;
                        case 5:
                            eleByName.DevName = dataGridViewRow.Cells[5].Value?.ToString();
                            break;
                        case 6:
                            {
                                if (dataGridViewRow.Cells[6].Value != null && double.TryParse(dataGridViewRow.Cells[6].Value.ToString(), out var result))
                                {
                                    ((IEleDO)eleByName).DoAddress = result;
                                }
                                else
                                {
                                    ((IEleDO)eleByName).DoAddress = 0.0;
                                    dataGridViewRow.Cells[6].Value = 0.0;
                                }
                                break;
                            }
                        case 7:
                            ((IEleDO)eleByName).DoEnable = Convert.ToBoolean(dataGridViewRow.Cells[7].Value);
                            break;
                        case 8:
                            if (dataGridViewRow.Cells[8].Value != null && dataGridViewRow.Cells[8].Value.ToString() == "NC")
                            {
                                ((IEleDO)eleByName).DoType = (EleDOType)2;
                            }
                            else
                            {
                                ((IEleDO)eleByName).DoType = (EleDOType)1;
                            }
                            break;
                        case 11:
                            ((IEleDO)eleByName).LineMark = dataGridViewRow.Cells[11].Value?.ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ElesManager.Instance.LogAdd(NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ErrMsg_DOCellValueChanged", "输出表格单元格报错:") + ex.Message, LogLevel.Error);
            }
        }
        #endregion

        #region ColumnHeaderMouseClick_排序
        private void dgvEleCylinder_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 7 || e.ColumnIndex == 9 || e.ColumnIndex == 11 || e.ColumnIndex == 14)
            {
                DgvSort(dgvEleCylinder, e.ColumnIndex);
            }
        }
        private void dgvEleDi_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 6)
            {
                DgvSort(dgvEleDi, e.ColumnIndex);
            }
        }
        private void dgvEleDo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 6)
            {
                DgvSort(dgvEleDo, e.ColumnIndex);
            }
        }
        #endregion

        #region ColumnHeaderMouseDoubleClick_基元刷新
        private void ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
            {
                return;
            }
            else if (dgv.Name == "dgvEleDi" && e.ColumnIndex == 5)
            {
                RefreshPrims(dgvEleDi, 5);
            }
            else if (dgv.Name == "dgvEleDo" && e.ColumnIndex == 5)
            {
                RefreshPrims(dgvEleDo, 5);
            }
            else if (dgv.Name == "dgvEleCylinder" && e.ColumnIndex == 5)
            {
                RefreshPrims(dgvEleCylinder, 5);
            }
        }
        #endregion

        private void EleConfigForm_VisibleChanged(object sender, EventArgs e)
        {
            EleConfigForm form = sender as EleConfigForm;
            if (form != null)
            {
                if (form.Visible)
                {
                    StartTimer();
                }
                else
                {
                    StopTimer();
                }
            }
        }
        #endregion



        //*****************************************************************************
        #region Button_Event
        /// <summary>增加元件</summary>
        private void btnAddElement_Click(object sender, EventArgs e)
        {
            if (AuthorityManager.Instance.VerifyLevel3Permission(true) && CheckManualEnable())
            {
                ToolStripButton toolStripButton = sender as ToolStripButton;
                string eleTypeName = toolStripButton.Tag.ToString();
                CreateDevice(eleTypeName);
            }
        }

        private void tsb_Config_Click(object sender, EventArgs e)
        {
            tsb_Debug.BackColor = SystemColors.Control;
            tsb_Config.BackColor = Color.Lime;

            tsbtnShowModeDI1_Click(null, null);
            tsbtnShowModeDO1_Click(null, null);
            tsbtnShowModeCylinder1_Click(null, null);
        }

        private void tsb_Debug_Click(object sender, EventArgs e)
        {
            tsb_Debug.BackColor = Color.Lime;
            tsb_Config.BackColor = SystemColors.Control;

            tsbtnShowModeDI2_Click(null, null);
            tsbtnShowModeDO2_Click(null, null);
            tsbtnShowModeCylinder2_Click(null, null);
        }

        /// <summary>气缸显示模式1</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnShowModeCylinder1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvEleCylinder.Columns.Count; i++)
            {
                if (i == 1 || i == 7 || i == 9 || i == 11 || i == 13 || i == 14 || i == 16 || i == 20 || i == 21)
                {
                    continue;
                }
                dgvEleCylinder.Columns[i].Visible = true;
            }
        }

        /// <summary>气缸显示模式2</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnShowModeCylinder2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvEleCylinder.Columns.Count; i++)
            {
                if (i == 1 || i == 7 || i == 9 || i == 11 || i == 13 || i == 14 || i == 16 || i == 20 || i == 21)
                {
                    continue;
                }
                dgvEleCylinder.Columns[i].Visible = false;
            }
        }

        /// <summary>输入显示模式1</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnShowModeDI1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvEleDi.Columns.Count; i++)
            {
                if (i == 1 || i == 6 || i == 11 || i == 12)
                {
                    continue;
                }
                dgvEleDi.Columns[i].Visible = true;
            }
        }

        /// <summary>输入显示模式2</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnShowModeDI2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvEleDi.Columns.Count; i++)
            {
                if (i == 1 || i == 6 || i == 11 || i == 12)
                {
                    continue;
                }
                dgvEleDi.Columns[i].Visible = false;
            }
        }

        /// <summary>输出显示模式1</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnShowModeDO1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvEleDo.Columns.Count; i++)
            {
                if (i == 1 || i == 6 || i == 9 || i == 10 || i == 11)
                {
                    continue;
                }
                dgvEleDo.Columns[i].Visible = true;
            }
        }

        /// <summary>输出显示模式2</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnShowModeDO2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvEleDo.Columns.Count; i++)
            {
                if (i == 1 || i == 6 || i == 9 || i == 10 || i == 11)
                {
                    continue;
                }
                dgvEleDo.Columns[i].Visible = false;
            }
        }

        /// <summary>按地址排序</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnSortByAddress_Click(object sender, EventArgs e)
        {
            if (!CheckManualEnable())
            {
                return;
            }

            TabPage page = tabElements.SelectedTab;
            foreach (object control in page.Controls)
            {
                if (!(typeof(FlowLayoutPanel) == control.GetType()))
                {
                    continue;
                }
                FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)control;
                flowLayoutPanel.Controls.Clear();
                switch (page.Name)
                {
                    case "tpAD":
                        foreach (IEle item in from p in ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName.ToLower().Contains(page.Name.ToLower()))
                                              orderby ((IEleAD)p).Address
                                              select p)
                        {
                            flowLayoutPanel.Controls.Add(item.EleConfigUI);
                        }
                        continue;
                    case "tpDA":
                        foreach (IEle item2 in from p in ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName.ToLower().Contains(page.Name.ToLower()))
                                               orderby ((IEleDA)p).Address
                                               select p)
                        {
                            flowLayoutPanel.Controls.Add(item2.EleConfigUI);
                        }
                        continue;
                    case "tpCartesian":
                        foreach (IEle item3 in from p in ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName.ToLower().Contains(page.Name.ToLower()))
                                               orderby ((IEleCartesian)p).AxisXIndex
                                               select p)
                        {
                            flowLayoutPanel.Controls.Add(item3.EleConfigUI);
                        }
                        continue;
                    case "tpLight":
                        foreach (IEle item4 in from p in ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName.ToLower().Contains(page.Name.ToLower()))
                                               orderby ((IEleLight)p).GreenAddress
                                               select p)
                        {
                            flowLayoutPanel.Controls.Add(item4.EleConfigUI);
                        }
                        continue;
                    case "tpCylinderLine":
                        dgvEleCylinder.Sort(dgvEleCylinder.Columns[0], ListSortDirection.Ascending);
                        continue;
                    case "tpDI":
                        dgvEleDi.Sort(dgvEleDi.Columns[0], ListSortDirection.Ascending);
                        continue;
                    case "tpDO":
                        dgvEleDo.Sort(dgvEleDo.Columns[0], ListSortDirection.Ascending);
                        continue;
                }
                foreach (IEle item5 in from p in ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName.ToLower().Contains(page.Name.ToLower()))
                                       orderby p.Name
                                       select p)
                {
                    flowLayoutPanel.Controls.Add(item5.EleConfigUI);
                }
            }
        }

        /// <summary>按名称排序</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnSortByName_Click(object sender, EventArgs e)
        {
            if (!CheckManualEnable())
            {
                return;
            }

            TabPage page = tabElements.SelectedTab;
            foreach (object control in page.Controls)
            {
                if (!(typeof(FlowLayoutPanel) == control.GetType()))
                {
                    continue;
                }
                FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)control;
                flowLayoutPanel.Controls.Clear();
                foreach (IEle item in from p in ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName.ToLower().Contains(page.Name.ToLower()))
                                      orderby p.Name
                                      select p)
                {
                    if (item.EleTypeName.ToLower().Contains(page.Name.ToLower()))
                    {
                        flowLayoutPanel.Controls.Add(item.EleConfigUI);
                    }
                }
            }
        }

        /// <summary>删除</summary>
        private void tStripBtnDel_Click(object sender, EventArgs e)
        {
            if (!CheckManualEnable())
            {
                return;
            }

            if (!AuthorityManager.Instance.VerifyLevel3Permission(true))
                return;
            DialogResult dialogResult = MessageBox.Show(NLocalizer.GetString("EleCommon_EleConfigForm_ConfirmDeleteElement", "确认删除该元件?")
                , NLocalizer.GetString("EleCommon_EleConfigForm_Warnning", "警告!")
                , MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
                return;
            List<IEle> list = null;
            switch (tabElements.SelectedTab.Name)
            {
                case "tpDI":
                    RemoveEles(ref dgvEleDi);
                    break;
                case "tpDO":
                    RemoveEles(ref dgvEleDo);
                    break;
                case "tpCylinderLine":
                    RemoveEles(ref dgvEleCylinder);
                    break;
                case "tpAD":
                    list = ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName == "AD");
                    break;
                case "tpDA":
                    list = ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName == "DA");
                    break;
                case "tpAxisLine":
                    list = ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName == "EleAxisLine");
                    break;
                case "tpLight":
                    list = ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName == "Light");
                    break;
                case "tpCartesian":
                    {
                        TabPage selectedTab = tabCartesians.SelectedTab;
                        if (selectedTab != null)
                        {
                            IEle eleByName = ElesManager.Instance.GetEleByName(tabCartesians.SelectedTab.Name);
                            tabCartesians.TabPages.Remove(selectedTab);
                            tabCartesians.SelectedTab = ((tabCartesians.TabPages.Count > 0) ? tabCartesians.TabPages[0] : null);
                            ElesManager.Instance.ListEle.Remove(eleByName);
                        }
                        break;
                    }
            }
            if (list == null)
                return;
            foreach (IEle item in list)
            {
                if (!item.IsSelected)
                    continue;
                foreach (object control in tabElements.SelectedTab.Controls)
                {
                    FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                    if (typeof(FlowLayoutPanel) == control.GetType())
                    {
                        flowLayoutPanel = (FlowLayoutPanel)control;
                        flowLayoutPanel.Controls.Remove(item.EleConfigUI);
                        ElesManager.Instance.ListEle.Remove(item);
                    }
                }
            }
        }
        /// <summary>保存</summary>
        private void tStripBtnSave_Click(object sender, EventArgs e)
        {
            if (CheckManualEnable())
            {
                SaveEleConfigsToFile();
            }
        }
        /// <summary>导出</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 导出CSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckManualEnable())
            {
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = "*.csv|";
            saveFileDialog.DefaultExt = ".csv";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string text = "";
            if (tabElements.SelectedTab.Name == "tpDI")
            {
                foreach (IEle item in ElesManager.Instance.ListEle)
                {
                    if (item.EleTypeName == "DI")
                    {
                        if (text == "")
                        {
                            text += item.GetCsvHeader();
                        }
                        text += "\r\n";
                        text += item.GetCsvValue();
                    }
                }
            }
            else if (tabElements.SelectedTab.Name == "tpDO")
            {
                foreach (IEle item2 in ElesManager.Instance.ListEle)
                {
                    if (item2.EleTypeName == "DO")
                    {
                        if (text == "")
                        {
                            text += item2.GetCsvHeader();
                        }
                        text += "\r\n";
                        text += item2.GetCsvValue();
                    }
                }
            }
            else if (tabElements.SelectedTab.Name == "tpCylinderLine")
            {
                foreach (IEle item3 in ElesManager.Instance.ListEle)
                {
                    if (item3.EleTypeName == "CylinderLine")
                    {
                        if (text == "")
                        {
                            text += item3.GetCsvHeader();
                        }
                        text += "\r\n";
                        text += item3.GetCsvValue();
                    }
                }
            }
            string path = saveFileDialog.FileName.ToString();
            FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream, GlobalVariables.EncodingChinese);
            streamWriter.WriteLine(text);
            streamWriter.Flush();
            streamWriter.Close();
            fileStream.Close();
            MessageBox.Show(NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ErrMsg_ExportSuccess", "导出完成!"));
        }
        /// <summary>导入</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 导入CSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckManualEnable())
            {
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "(Product Param)|*.csv",
                Multiselect = false
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            List<string> list = new List<string>();
            using (StreamReader streamReader = new StreamReader(openFileDialog.FileName, GlobalVariables.EncodingChinese))
            {
                while (true)
                {
                    string text2 = streamReader.ReadLine();
                    if (text2 != null)
                    {
                        if (text2.Split(',')[0] != "名称")
                            list.Add(text2);
                        continue;
                    }
                    break;
                }
            }
            switch (tabElements.SelectedTab.Name)
            {
                case "tpDI":
                    foreach (string item in list)
                    {
                        if (item.Length >= 10)
                        {
                            IEle ele2 = ElesManager.Instance.GetEle("DI");
                            ele2.CsvToValue(item);
                            AddEleDi(ele2, newFlag: false);
                        }
                    }
                    RefreshEleDi();
                    break;
                case "tpDO":
                    foreach (string item2 in list)
                    {
                        if (item2.Length >= 10)
                        {
                            IEle ele3 = ElesManager.Instance.GetEle("DO");
                            ele3.CsvToValue(item2);
                            AddEleDo(ele3, newFlag: false);
                        }
                    }
                    RefreshEleDo();
                    break;
                case "tpCylinderLine":
                    foreach (string item3 in list)
                    {
                        if (item3.Length >= 10)
                        {
                            IEle ele = ElesManager.Instance.GetEle("CylinderLine");
                            ele.CsvToValue(item3);
                            AddEleCylinder(ele, newFlag: false);
                        }
                    }
                    RefreshEleCylinder();
                    break;
            }
        }
        #endregion



        //*****************************************************************************
        #region Method_ExternalUsing
        public void StartTimer()
        {
            timer1.Start();
        }

        public void StopTimer()
        {
            timer1.Stop();
        }

        /// <summary>使能状态设置</summary>
        /// <param name="enable">true：使能状态；false：非使能状态</param>
        internal void SetEnable(bool enable)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetEnable), new object[] { enable });
                return;
            }
            tsEles.Enabled = enable;
            tsTitle.Enabled = enable;
            foreach (Control con in tpDI.Controls)
            {
                con.Enabled = enable;
            }
            foreach (Control con in tpDO.Controls)
            {
                con.Enabled = enable;
            }
            foreach (Control con in tpCylinderLine.Controls)
            {
                con.Enabled = enable;
            }
            foreach (Control con in tpAD.Controls)
            {
                con.Enabled = enable;
            }
            foreach (Control con in tpDA.Controls)
            {
                con.Enabled = enable;
            }
            foreach (Control con in tpLight.Controls)
            {
                con.Enabled = enable;
            }
            foreach (Control con in tpAxisLine.Controls)
            {
                con.Enabled = enable;
            }
            foreach (Control con in tpCartesian.Controls)
            {
                con.Enabled = enable;
            }
        }
        #endregion



        //*****************************************************************************
        #region Method_InternalUsing
        /// <summary>元件加载</summary>
        /// <param name="eleTypeName"></param>
        public void CreateDevice(string eleTypeName)
        {
            IEle ele = ElesManager.Instance.GetEle(eleTypeName);
            if (ele == null || string.IsNullOrEmpty(ele.EleTypeName)) return;
            switch (ele.EleTypeName)
            {
                case "DI":
                    AddEleDi(ele, newFlag: true);
                    break;
                case "DO":
                    AddEleDo(ele, newFlag: true);
                    break;
                case "CylinderLine":
                    AddEleCylinder(ele, newFlag: true);
                    break;
                case "Cartesian":
                    AddEleCartesian(ele, newFlag: true);
                    break;
                case "AD":
                case "DA":
                case "AxisLine":
                case "Light":
                    foreach (KeyValuePair<string, FlowLayoutPanel> item in _dicPanel.Where((KeyValuePair<string, FlowLayoutPanel> item) => item.Key.Replace("Panel", string.Empty) == ele.EleTypeName))
                    {
                        item.Value.Controls.Add(ele.EleConfigUI);
                        ElesManager.Instance.ListEle.Add(ele);
                    }
                    break;
            }
        }
        public void OnLanguageChanged()
        {
            tsBtnSortByName.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_SortByName", "按名称排序");
            tsBtnSortByAddress.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_SortByAddress", "按主地址排序");
            tsbtnShowModeDI1.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ModeDI1", "输入显示1");
            tsbtnShowModeDI2.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ModeDI2", "输入显示2");
            tsbtnShowModeDO1.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ModeDO1", "输出显示1");
            tsbtnShowModeDO2.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ModeDO2", "输出显示2");
            tsbtnShowModeCylinder1.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_Cylinder1", "气缸显示1");
            tsbtnShowModeCylinder2.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_Cylinder2", "气缸显示2");
            tsb_Debug.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_Debug", "调试");
            tsb_Config.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_Config", "配置");

            DI数量.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_DI_Count", "DI数量:") + dgvEleDi.Rows.Count.ToString();
            DO数量.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_DO_Count", "DO数量:") + dgvEleDo.Rows.Count.ToString();
            Cylinder数量.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_Cylinder_Count", "气缸数量:") + dgvEleCylinder.Rows.Count.ToString();

            导出CSVToolStripMenuItem.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ExportToCSV", "导出CSV");
            导入CSVToolStripMenuItem.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ImportToCSV", "导入CSV");

            tpDI.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_DI", "数字输入");
            tpDO.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_DO", "数字输出");
            tpCylinderLine.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_Cylinder", "气缸&真空");
            tpAD.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_AD", "模拟输入");
            tpDA.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_DA", "模拟输出");
            tpLight.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_Light", "系统指示灯");
            tpAxisLine.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_SingleAxis", "单轴");
            tpCartesian.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_Cartesian", "轴组");

            dataGridViewTextBoxColumn5.HeaderText = dataGridViewTextBoxColumn1.HeaderText = colEleDiName.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_Name", "名称");
            dataGridViewTextBoxColumn6.HeaderText = dataGridViewTextBoxColumn2.HeaderText = colEleDiInfo.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_Info", "信息");
            dataGridViewCheckBoxColumn4.HeaderText = dataGridViewCheckBoxColumn1.HeaderText = colEleDiEnable.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_Enable", "使能");
            dataGridViewCheckBoxColumn5.HeaderText = dataGridViewCheckBoxColumn2.HeaderText = colEleDiSimulate.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_Simulate", "模拟");
            dataGridViewComboBoxColumn3.HeaderText = dataGridViewComboBoxColumn1.HeaderText = colEleDiPrimType.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_PrimType", "基元类型");
            dataGridViewComboBoxColumn4.HeaderText = dataGridViewComboBoxColumn2.HeaderText = colEleDiPrimName.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_PrimName", "基元名称");
            colEleDiState.HeaderText = dataGridViewTextBoxColumn4.HeaderText = dataGridViewTextBoxColumn8.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_State", "状态");
            colEleDiAddress.HeaderText = dataGridViewTextBoxColumn3.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_Address", "地址");
            colEleDiDiEnable.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_DIEnable", "输入使能");
            colEleDiType.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_DIType", "输入类型");
            colEleDiEnableRise.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_DIEnableRise", "上升沿");
            colEleDiEnableFall.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_DIEnableFall", "下降沿");
            dataGridViewCheckBoxColumn3.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_DOEnable", "输出使能");
            colEleDoType.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_DOType", "输出类型");
            colEleDoTest.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_DOTest", "测试");
            colType.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_CylinderType", "类型");
            colStretchDiAddress.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ExtendPosAddress", "伸位地址");
            colStretchDiEnable.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ExtendPosEnable", "伸位使能");
            colRestractDiAddress.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_RetractPosAddress", "原位地址");
            colRestractDiEnable.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_RetractPosEnable", "原位使能");
            colStretchDoAddress.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ExtendAddress", "伸出地址");
            colStretchDoEnable.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ExtendEnable", "伸出使能");
            colStretchDoTest.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ExtendTest", "伸出测试");
            colRestractDoAddress.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_RetractAddress", "缩回地址");
            colRestractDoEnable.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_RetractEnable", "缩回使能");
            colRestractDoTest.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_RetractTest", "缩回测试");
            colStretchTime.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ExtendDelay", "伸延时");
            colRestractTime.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_RetractDelay", "缩延时");
            colBlowTime.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_BlowDelay", "吹气延时");

            foreach (TabPage item in tabCartesians.TabPages)
            {
                item.Text = NLocalizer.GetString(item.Name, item.Name);
            }
        }

        /// <summary>元件保存</summary>
        public void SaveEleConfigsToFile()
        {
            if (!Created || !IsHandleCreated) return;

            if (InvokeRequired)
            {
                BeginInvoke(new Action(SaveEleConfigsToFile));
            }
            else
            {
                try
                {
                    if (!AuthorityManager.Instance.VerifyLevel3Permission())
                    {
                        return;
                    }

                    //增加元件重名检测
                    {
                        _concurrentNameRepeat.Clear();
                        foreach (DataGridViewRow item in dgvEleDi.Rows)
                        {
                            string name = item.Cells[0].Value.ToString().Trim();
                            if (string.IsNullOrEmpty(name))
                            {
                                throw new Exception(NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ErrMsg_DI_NameIsEmpty", "元件配置保存失败:检测到有输入元件名为空"));
                            }

                            if (!_concurrentNameRepeat.ContainsKey(name))
                            {
                                _concurrentNameRepeat.TryAdd(name, 0);
                            }
                            else
                            {
                                throw new Exception(NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ErrMsg_DI_NameRepeat", "元件配置保存失败:输入元件检测到重名元件:") + name);
                            }
                        }
                        foreach (DataGridViewRow item in dgvEleDo.Rows)
                        {
                            string name = item.Cells[0].Value.ToString().Trim();
                            if (string.IsNullOrEmpty(name))
                            {
                                throw new Exception(NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ErrMsg_DO_NameIsEmpty", "元件配置保存失败:检测到有输出元件名为空"));
                            }

                            if (!_concurrentNameRepeat.ContainsKey(name))
                            {
                                _concurrentNameRepeat.TryAdd(name, 1);
                            }
                            else
                            {
                                string errorText = _concurrentNameRepeat[name] == 0
                                    ? NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ErrMsg_DO_DI_NameRepeat", "元件配置保存失败:输入元件&输出元件检测到重名元件:")
                                    : NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ErrMsg_DO_NameRepeat", "元件配置保存失败:输出元件检测到重名元件:");
                                throw new Exception(errorText + name);
                            }
                        }
                        foreach (DataGridViewRow item in dgvEleCylinder.Rows)
                        {
                            string name = item.Cells[0].Value.ToString().Trim();
                            if (string.IsNullOrEmpty(item.Cells[0].Value.ToString()))
                            {
                                throw new Exception(NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ErrMsg_CylinderNameIsEmpty", "元件配置保存失败:检测到有气缸元件名为空"));
                            }

                            if (!_concurrentNameRepeat.ContainsKey(name))
                            {
                                _concurrentNameRepeat.TryAdd(name, 2);
                            }
                            else
                            {
                                string errorText = _concurrentNameRepeat[name] == 0
                                    ? NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ErrMsg_Cylinder_DI_NameRepeat", "元件配置保存失败:输入元件&气缸元件检测到重名元件:")
                                    : (_concurrentNameRepeat[name] == 1
                                    ? NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ErrMsg_Cylinder_DO_NameRepeat", "元件配置保存失败:输出元件&气缸元件检测到重名元件:")
                                    : NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ErrMsg_CylinderNameRepeat", "元件配置保存失败:气缸元件检测到重名元件:"));
                                throw new Exception(errorText + name);
                            }
                        }
                    }

                    SaveEleDi("20211029");
                    SaveEleDo("20211029");
                    SaveEleCylinder("20211029");

                    foreach (IEle item in ElesManager.Instance.ListEle)
                    {
                        if ((int)item.EleRunStat == 100 || (int)item.EleRunStat == 3)
                        {
                            item.IEleInit();
                        }
                        if ((int)item.EleRunStat == 4)
                        {
                            item.IEleReset();
                        }
                    }
                    ElesManager.Instance.DataInfoManagerExport();
                    ElesManager.Instance.IoInfosExport();
                    ElesManager.Instance.LogAdd("元件配置保存成功", LogLevel.Trace);
                    UIMessageTip.ShowOk(NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ElementConfigSaveSuccess", "元件配置保存成功"));
                }
                catch (Exception ex)
                {
                    ElesManager.Instance.LogAdd(NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ElementConfigSaveFail", "元件配置保存失败:") + ex.Message, LogLevel.Error);
                }
            }
        }

        /// <summary>手自动切换</summary>
        /// <param name="enable">false：自动/true：手动</param>
        internal void EnableHandle(bool enable)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(EnableHandle), new object[1] { enable });
            }
            else
            {
                _enableHandle = enable;
            }
        }

        /// <summary>轴加载（Load事件/新建元件）</summary>
        private void AddEleCartesian(IEle ele, bool newFlag)
        {
            if (newFlag)
            {
                CreateNewCartesian createNewCartesian = new CreateNewCartesian(ele);
                DialogResult dialogResult = createNewCartesian.ShowDialog();
                if (dialogResult != DialogResult.OK)
                    return;

                ElesManager.Instance.ListEle.Add(ele);
            }
            ele.EleConfigUI.Dock = DockStyle.Fill;
            tabCartesians.TabPages.Add(ele.Name, NLocalizer.GetString(ele.Name, ele.Name));
            tabCartesians.TabPages[ele.Name].Controls.Add(ele.EleConfigUI);
            if (newFlag)
            {
                tabCartesians.SelectedTab = tabCartesians.TabPages[ele.Name];
            }
        }

        /// <summary>气缸加载（Load事件/导入元件/新建元件）</summary>
        private void AddEleCylinder(IEle cyl, bool newFlag)
        {
            IEle val = ElesManager.Instance.ListEle.LastOrDefault((IEle e) => e.EleTypeName.Contains("CylinderLine"));
            if (val != null && newFlag)
            {
                cyl.DevName = val.DevName;
                ((IEleCyldLine)cyl).CyldType = ((IEleCyldLine)val).CyldType;
                double value = (((IEleCyldLine)val).StretchDoEnable && ((IEleCyldLine)val).RestractDoEnable) ? 0.02 : 0.01;
                ((IEleCyldLine)cyl).StretchDiAddress = ((IEleCyldLine)val).StretchDiAddress == 0.00 ? 0.00 : ((IEleCyldLine)val).StretchDiAddress + value;
                ((IEleCyldLine)cyl).RestractDiAddress = ((IEleCyldLine)val).RestractDiAddress == 0.00 ? 0.00 : ((IEleCyldLine)val).RestractDiAddress + value;
                ((IEleCyldLine)cyl).StretchDoAddress = ((IEleCyldLine)val).StretchDoAddress == 0.00 ? 0.00 : ((IEleCyldLine)val).StretchDoAddress + value;
                ((IEleCyldLine)cyl).RestractDoAddress = ((IEleCyldLine)val).RestractDoAddress == 0.00 ? 0.00 : ((IEleCyldLine)val).RestractDoAddress + value;
                ((IEleCyldLine)cyl).StretchTimeOut = ((IEleCyldLine)val).StretchTimeOut;
                ((IEleCyldLine)cyl).RestractTimeOut = ((IEleCyldLine)val).RestractTimeOut;
                ((IEleCyldLine)cyl).BlowTime = ((IEleCyldLine)val).BlowTime;
            }
            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            dataGridViewRow.CreateCells(dgvEleCylinder);

            dataGridViewRow.Cells[0].Value = cyl.Name;
            dataGridViewRow.Cells[1].Value = NLocalizer.GetString(cyl.Name, cyl.Name);
            dataGridViewRow.Cells[2].Value = cyl.Enable;
            dataGridViewRow.Cells[3].Value = cyl.IsSimulateMode;
            dataGridViewRow.Cells[4].Value = "MotionCard";

            List<string> list = (from p in PrimsManager.Instance.GetAllIPrim().FindAll((IPrim p) => p is IIoModule) select p.Name).ToList();
            if (list.Count > 0)
                foreach (string item2 in list) ((DataGridViewComboBoxCell)dataGridViewRow.Cells[5]).Items.Add(item2);

            dataGridViewRow.Cells[5].Value = (!string.IsNullOrEmpty(cyl.DevName) && ((DataGridViewComboBoxCell)dataGridViewRow.Cells[5]).Items.Contains(cyl.DevName)) ? cyl.DevName : "";
            //dataGridViewRow.Cells[5].Value = ((string.IsNullOrEmpty(cyl.DevName) && ((DataGridViewComboBoxCell)dataGridViewRow.Cells[5]).Items.Count > 0) ? ((DataGridViewComboBoxCell)dataGridViewRow.Cells[5]).Items[0] : cyl.DevName);
            Enum.GetNames(typeof(EleCyldType)).ToList().ForEach(p => ((DataGridViewComboBoxCell)dataGridViewRow.Cells[6]).Items.Add(p));
            dataGridViewRow.Cells[6].Value = ((IEleCyldLine)cyl).CyldType.ToString();
            dataGridViewRow.Cells[7].Value = ((IEleCyldLine)cyl).StretchDiAddress.ToString("F2");
            dataGridViewRow.Cells[8].Value = ((IEleCyldLine)cyl).StretchDiEnable;
            dataGridViewRow.Cells[9].Value = ((IEleCyldLine)cyl).RestractDiAddress.ToString("F2");
            dataGridViewRow.Cells[10].Value = ((IEleCyldLine)cyl).RestractDiEnable;
            dataGridViewRow.Cells[11].Value = ((IEleCyldLine)cyl).StretchDoAddress.ToString("F2");
            dataGridViewRow.Cells[12].Value = ((IEleCyldLine)cyl).StretchDoEnable;
            dataGridViewRow.Cells[14].Value = ((IEleCyldLine)cyl).RestractDoAddress.ToString("F2");
            dataGridViewRow.Cells[15].Value = ((IEleCyldLine)cyl).RestractDoEnable;
            if (((IEleCyldLine)cyl).StretchTimeOut <= 0) ((IEleCyldLine)cyl).StretchTimeOut = 4000;
            if (((IEleCyldLine)cyl).RestractTimeOut <= 0) ((IEleCyldLine)cyl).RestractTimeOut = 4000;
            if (((IEleCyldLine)cyl).BlowTime <= 0) ((IEleCyldLine)cyl).BlowTime = 200;
            dataGridViewRow.Cells[17].Value = ((IEleCyldLine)cyl).StretchTimeOut;
            dataGridViewRow.Cells[18].Value = ((IEleCyldLine)cyl).RestractTimeOut;
            dataGridViewRow.Cells[19].Value = ((IEleCyldLine)cyl).BlowTime;
            dataGridViewRow.Cells[20].Value = cyl.EleRunStat.ToString();
            dataGridViewRow.Cells[21].Value = ((IEleCyldLine)cyl).LineMark;

            for (int j = 0; j < 21; j++)
                dataGridViewRow.Cells[j].Style.BackColor = Color.WhiteSmoke;

            if ((int)((IEleCyldLine)cyl).CyldType == 2)
            {
                dataGridViewRow.Cells[9].ReadOnly = true;
                dataGridViewRow.Cells[9].Style.BackColor = Color.DarkGray;

                dataGridViewRow.Cells[10].Value = false;

                dataGridViewRow.Cells[10].ReadOnly = true;
                dataGridViewRow.Cells[10].Style.BackColor = Color.DarkGray;

                dataGridViewRow.Cells[19].ReadOnly = false;
                dataGridViewRow.Cells[19].Style.BackColor = Color.DarkGray;
            }
            else
            {
                dataGridViewRow.Cells[9].ReadOnly = false;
                dataGridViewRow.Cells[9].Style.BackColor = Color.WhiteSmoke;

                dataGridViewRow.Cells[10].ReadOnly = false;
                dataGridViewRow.Cells[10].Style.BackColor = Color.WhiteSmoke;

                dataGridViewRow.Cells[19].ReadOnly = true;
                dataGridViewRow.Cells[19].Style.BackColor = Color.WhiteSmoke;
            }
            dgvEleCylinder.Rows.Add(dataGridViewRow);
        }

        /// <summary>输入加载（Load事件/导入元件/新建元件）</summary>
        private void AddEleDi(IEle di, bool newFlag)
        {
            IEle val = ElesManager.Instance.ListEle.LastOrDefault((IEle e) => e.EleTypeName.Contains("DI"));
            if (val != null && newFlag)
            {
                di.DevName = val.DevName;
                ((IEleDI)di).DiAddress = ((IEleDI)val).DiAddress + 0.01;
            }
            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            dataGridViewRow.CreateCells(dgvEleDi);

            dataGridViewRow.Cells[0].Value = di.Name;
            dataGridViewRow.Cells[1].Value = NLocalizer.GetString(di.Name, di.Name);
            dataGridViewRow.Cells[2].Value = di.Enable;
            dataGridViewRow.Cells[3].Value = di.IsSimulateMode;
            dataGridViewRow.Cells[4].Value = "MotionCard";

            List<string> list = (from p in PrimsManager.Instance.GetAllIPrim().FindAll((IPrim p) => p is IIoModule) select p.Name).ToList();
            if (list.Count > 0)
                foreach (string item in list) ((DataGridViewComboBoxCell)dataGridViewRow.Cells[5]).Items.Add(item);

            dataGridViewRow.Cells[5].Value = (!string.IsNullOrEmpty(di.DevName) && ((DataGridViewComboBoxCell)dataGridViewRow.Cells[5]).Items.Contains(di.DevName)) ? di.DevName : "";
            //dataGridViewRow.Cells[5].Value = ((string.IsNullOrEmpty(di.DevName) && ((DataGridViewComboBoxCell)dataGridViewRow.Cells[5]).Items.Count > 0) ? ((DataGridViewComboBoxCell)dataGridViewRow.Cells[5]).Items[0] : di.DevName);

            dataGridViewRow.Cells[6].Value = ((IEleDI)di).DiAddress.ToString("F2");
            dataGridViewRow.Cells[7].Value = ((IEleDI)di).DiEnable;
            dataGridViewRow.Cells[8].Value = ((int)((IEleDI)di).DiType == 1) ? "NO" : "NC";
            dataGridViewRow.Cells[9].Value = ((IEleDI)di).EnRiseEvent;
            dataGridViewRow.Cells[10].Value = ((IEleDI)di).EnFallEvent;
            dataGridViewRow.Cells[11].Value = di.EleRunStat.ToString();
            dataGridViewRow.Cells[12].Value = ((IEleDI)di).LineMark;

            for (int i = 0; i < 12; i++)
                dataGridViewRow.Cells[i].Style.BackColor = Color.WhiteSmoke;
            dgvEleDi.Rows.Add(dataGridViewRow);
        }
        /// <summary>输出加载（Load事件/导入元件/新建元件）</summary>
        private void AddEleDo(IEle doo, bool newFlag)
        {
            IEle val = ElesManager.Instance.ListEle.LastOrDefault((IEle e) => e.EleTypeName.Contains("DO"));
            if (val != null && newFlag)
            {
                doo.DevName = val.DevName;
                ((IEleDO)doo).DoAddress = ((IEleDO)val).DoAddress + 0.01;
            }
            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            dataGridViewRow.CreateCells(dgvEleDo);

            dataGridViewRow.Cells[0].Value = doo.Name;
            dataGridViewRow.Cells[1].Value = NLocalizer.GetString(doo.Name, doo.Name);
            dataGridViewRow.Cells[2].Value = doo.Enable;
            dataGridViewRow.Cells[3].Value = doo.IsSimulateMode;
            dataGridViewRow.Cells[4].Value = "MotionCard";

            List<string> list = (from p in PrimsManager.Instance.GetAllIPrim().FindAll((IPrim p) => p is IIoModule) select p.Name).ToList();
            if (list.Count > 0)
                foreach (string item in list) ((DataGridViewComboBoxCell)dataGridViewRow.Cells[5]).Items.Add(item);

            dataGridViewRow.Cells[5].Value = (!string.IsNullOrEmpty(doo.DevName) && ((DataGridViewComboBoxCell)dataGridViewRow.Cells[5]).Items.Contains(doo.DevName)) ? doo.DevName : string.Empty;
            //dataGridViewRow.Cells[5].Value = ((string.IsNullOrEmpty(doo.DevName) && ((DataGridViewComboBoxCell)dataGridViewRow.Cells[5]).Items.Count > 0) ? ((DataGridViewComboBoxCell)dataGridViewRow.Cells[5]).Items[0] : doo.DevName);
            dataGridViewRow.Cells[6].Value = ((IEleDO)doo).DoAddress.ToString("F2");
            dataGridViewRow.Cells[7].Value = ((IEleDO)doo).DoEnable;
            dataGridViewRow.Cells[8].Value = ((int)((IEleDO)doo).DoType == 1) ? "NO" : "NC";
            dataGridViewRow.Cells[10].Value = doo.EleRunStat.ToString();
            dataGridViewRow.Cells[11].Value = ((IEleDO)doo).LineMark;

            for (int i = 0; i < 11; i++)
                dataGridViewRow.Cells[i].Style.BackColor = Color.WhiteSmoke;

            dgvEleDo.Rows.Add(dataGridViewRow);
        }
        /// <summary>手自动检查</summary>
        /// <returns>false：自动/true：手动</returns>
        private bool CheckManualEnable()
        {
            if (!_enableHandle)
            {
                ElesManager.Instance.LogAdd(NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ErrMsg_NoOperationFristChangeToManual", "禁止操作,请先切换至手动!"), LogLevel.Warn);
                UINotifierHelper.ShowNotifier(NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ErrMsg_NoOperationFristChangeToManual", "禁止操作,请先切换至手动!"), UINotifierType.WARNING,
                    NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_AutoMode", "自动模式"), true);
            }
            return _enableHandle;
        }

        /// <summary>排序</summary>
        /// <param name="dgv"></param>
        /// <param name="sortColIndex"></param>
        private void DgvSort(DataGridView dgv, int sortColIndex)
        {
            _sorting = true;
            if (dgv.SortedColumn == dgv.Columns[sortColIndex])
            {
                if (dgv.SortOrder == SortOrder.Descending || dgv.SortOrder == SortOrder.None)
                {
                    dgv.Sort(dgv.Columns[sortColIndex], ListSortDirection.Ascending);
                }
                else
                {
                    dgv.Sort(dgv.Columns[sortColIndex], ListSortDirection.Descending);
                }
            }
            else
            {
                dgv.Sort(dgv.Columns[sortColIndex], ListSortDirection.Ascending);
            }
            dgv.ClearSelection();
            _sorting = false;
        }

        /// <summary>气缸状态刷新</summary>
        private void RefreshEleCylinder()
        {
            foreach (DataGridViewRow row in dgvEleCylinder.Rows)
            {
                if (row.Cells[0].Value != null && !string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                {
                    IEle val = ElesManager.Instance.ListEle.FirstOrDefault((IEle p) => p.Name == row.Cells[0].Value.ToString());
                    if (val != null)
                    {
                        row.Cells[1].Value = NLocalizer.GetString(row.Cells[0].Value.ToString(), row.Cells[0].Value.ToString());
                        if ((int)val.IEleCheckPrimRunState() == 1)
                        {
                            val.IEleUiRefresh();
                            row.Cells[7].Style = (((IEleCyldLine)val).StretchDi_On ? _setStyle : _resetStyle);
                            row.Cells[9].Style = (((IEleCyldLine)val).RestractDi_On ? _setStyle : _resetStyle);
                            row.Cells[11].Style = (((IEleCyldLine)val).StretchDo_On ? _setStyle : _resetStyle);
                            row.Cells[14].Style = (((IEleCyldLine)val).RestractDo_On ? _setStyle : _resetStyle);
                        }
                        else
                        {
                            row.Cells[7].Style = _unknownStyle;
                            row.Cells[9].Style = _unknownStyle;
                            row.Cells[11].Style = _unknownStyle;
                            row.Cells[14].Style = _unknownStyle;
                        }

                        //ShowPrimRunStat(val, row.Cells[5]);
                        ShowEleRunStat(val, row.Cells[20]);
                    }
                    else
                    {
                        row.Cells[7].Style = _unknownStyle;
                        row.Cells[9].Style = _unknownStyle;
                        row.Cells[11].Style = _unknownStyle;
                        row.Cells[14].Style = _unknownStyle;
                    }
                }
                else
                {
                    row.Cells[7].Style = _unknownStyle;
                    row.Cells[9].Style = _unknownStyle;
                    row.Cells[11].Style = _unknownStyle;
                    row.Cells[14].Style = _unknownStyle;
                }
            }
        }

        /// <summary>输入状态刷新</summary>
        private void RefreshEleDi()
        {
            foreach (DataGridViewRow row in (IEnumerable)dgvEleDi.Rows)
            {
                if (row.Cells[0].Value != null && !string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                {
                    IEle val = ElesManager.Instance.ListEle.FirstOrDefault((IEle p) => p.Name == row.Cells[0].Value.ToString());
                    if (val != null)
                    {
                        row.Cells[1].Value = NLocalizer.GetString(row.Cells[0].Value.ToString(), row.Cells[0].Value.ToString());
                        if ((int)val.IEleCheckPrimRunState() == 1)
                        {
                            row.Cells[6].Style = (((IEleDI)val).Read() ? _setStyle : _resetStyle);
                        }
                        else
                        {
                            row.Cells[6].Style = _unknownStyle;
                        }

                        //ShowPrimRunStat(val, row.Cells[5]);
                        ShowEleRunStat(val, row.Cells[11]);
                    }
                    else
                    {
                        row.Cells[6].Style = _unknownStyle;
                    }
                }
                else
                {
                    row.Cells[6].Style = _unknownStyle;
                }
            }
        }

        /// <summary>输出状态刷新</summary>
        private void RefreshEleDo()
        {
            foreach (DataGridViewRow row in (IEnumerable)dgvEleDo.Rows)
            {
                if (row.Cells[0].Value != null && !string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                {
                    IEle val = ElesManager.Instance.ListEle.FirstOrDefault((IEle p) => p.Name == row.Cells[0].Value.ToString());
                    if (val != null)
                    {
                        row.Cells[1].Value = NLocalizer.GetString(row.Cells[0].Value.ToString(), row.Cells[0].Value.ToString());
                        if ((int)val.IEleCheckPrimRunState() == 1)
                        {
                            row.Cells[6].Style = (((IEleDO)val).Read() ? _setStyle : _resetStyle);
                        }
                        else
                        {
                            row.Cells[6].Style = _unknownStyle;
                        }

                        //ShowPrimRunStat(val, row.Cells[5]);
                        ShowEleRunStat(val, row.Cells[10]);
                    }
                    else
                    {
                        row.Cells[6].Style = _unknownStyle;
                    }
                }
                else
                {
                    row.Cells[6].Style = _unknownStyle;
                }
            }
        }

        /// <summary>刷新IMotionCard列表</summary>
        /// <param name="dgv"></param>
        /// <param name="colIndex"></param>
        private void RefreshPrims(DataGridView dgv, int colIndex)
        {
            List<IPrim> list = PrimsManager.Instance.GetAllIPrim().FindAll((IPrim p) => p is IMotionCard);
            if (list.Count <= 0)
            {
                ElesManager.Instance.LogAdd(NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_ErrMsg_NoFindImotioncard", "基元刷新_未找到IMotionCard"), LogLevel.Trace);
                return;
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                List<string> list2;
                if (row.Cells[colIndex].Value != null && !string.IsNullOrEmpty(row.Cells[colIndex].Value.ToString()))
                {
                    list2 = (from p in list.FindAll((IPrim p) => p.Name != row.Cells[colIndex].Value.ToString())
                             select p.Name).ToList();
                }
                else
                {
                    list2 = list.Select((IPrim p) => p.Name).ToList();
                    ((DataGridViewComboBoxCell)row.Cells[colIndex]).Value = list[0].Name;
                }

                foreach (string item in list2)
                {
                    if (!((DataGridViewComboBoxCell)row.Cells[colIndex]).Items.Contains(item))
                    {
                        ((DataGridViewComboBoxCell)row.Cells[colIndex]).Items.Add(item);
                    }
                }
            }
        }

        /// <summary>元件移除</summary>
        /// <param name="dgv"></param>
        private void RemoveEles(ref DataGridView dgv)
        {
            for (int num = dgv.SelectedRows.Count; num > 0; num--)
            {
                if (dgv.Rows[dgv.SelectedRows[num - 1].Index].Cells[0].Value != null && !string.IsNullOrEmpty(dgv.Rows[dgv.SelectedRows[num - 1].Index].Cells[0].Value.ToString()))
                {
                    string eleName = dgv.Rows[dgv.SelectedRows[num - 1].Index].Cells[0].Value.ToString();
                    IEle val = null;
                    switch (dgv.Name)
                    {
                        case "dgvEleDi":
                            val = ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName == "DI").FirstOrDefault((IEle p) => p.Name == eleName);
                            break;
                        case "dgvEleDo":
                            val = ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName == "DO").FirstOrDefault((IEle p) => p.Name == eleName);
                            break;
                        case "dgvEleCylinder":
                            val = ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName == "CylinderLine").FirstOrDefault((IEle p) => p.Name == eleName);
                            break;
                    }
                    if (val != null)
                    {
                        ElesManager.Instance.ListEle.Remove(val);
                    }
                }
                dgv.Rows.RemoveAt(dgv.SelectedRows[num - 1].Index);
            }
        }

        /// <summary>气缸保存_old</summary>
        private void SaveEleCylinder()
        {
            string errorText = "";
            if (ControlHelper.CheckDgvCellRepeat(dgvEleCylinder, ref errorText)) throw new Exception(errorText);
            //if (ControlHelper.CheckDgvCellRepeat(ref dgvEleCylinder, 0))
            //{
            //    MessageBox.Show("气缸/真空元件表中有成员的名称配置重复或不合法，请检查！");
            //    return;
            //}
            ElesManager.Instance.ListEle.RemoveAll((IEle p) => p.EleTypeName == "CylinderLine");
            foreach (DataGridViewRow item in (IEnumerable)dgvEleCylinder.Rows)
            {
                string text = item.Cells[0].Value.ToString();
                IEle eleByName = ElesManager.Instance.GetEleByName(text);
                IEle val = eleByName ?? ElesManager.Instance.GetEle("CylinderLine");
                val.Name = text;
                val.Info = item.Cells[1].Value?.ToString();
                val.Enable = Convert.ToBoolean(item.Cells[2].Value);
                val.IsSimulateMode = Convert.ToBoolean(item.Cells[3].Value);
                val.DevName = item.Cells[5].Value?.ToString();
                if (Enum.TryParse<EleCyldType>(item.Cells[6].Value.ToString(), out EleCyldType result))
                {
                    ((IEleCyldLine)val).CyldType = result;
                }
                if (item.Cells[7].Value != null && double.TryParse(item.Cells[7].Value.ToString(), out var result2))
                {
                    ((IEleCyldLine)val).StretchDiAddress = result2;
                }
                else
                {
                    ((IEleCyldLine)val).StretchDiAddress = 0.0;
                }
                ((IEleCyldLine)val).StretchDiEnable = Convert.ToBoolean(item.Cells[8].Value);
                if (item.Cells[9].Value != null && double.TryParse(item.Cells[9].Value.ToString(), out var result3))
                {
                    ((IEleCyldLine)val).RestractDiAddress = result3;
                }
                else
                {
                    ((IEleCyldLine)val).RestractDiAddress = 0.0;
                }
                ((IEleCyldLine)val).RestractDiEnable = Convert.ToBoolean(item.Cells[10].Value);
                if (item.Cells[11].Value != null && double.TryParse(item.Cells[11].Value.ToString(), out var result4))
                {
                    ((IEleCyldLine)val).StretchDoAddress = result4;
                }
                else
                {
                    ((IEleCyldLine)val).StretchDoAddress = 0.0;
                }
                ((IEleCyldLine)val).StretchDoEnable = Convert.ToBoolean(item.Cells[12].Value);
                if (item.Cells[14].Value != null && double.TryParse(item.Cells[14].Value.ToString(), out var result5))
                {
                    ((IEleCyldLine)val).RestractDoAddress = result5;
                }
                else
                {
                    ((IEleCyldLine)val).RestractDoAddress = 0.0;
                }
                ((IEleCyldLine)val).RestractDoEnable = Convert.ToBoolean(item.Cells[15].Value);
                if (item.Cells[17].Value != null && int.TryParse(item.Cells[17].Value.ToString(), out var result6))
                {
                    ((IEleCyldLine)val).StretchTimeOut = result6;
                }
                else
                {
                    ((IEleCyldLine)val).StretchTimeOut = 2000;
                }
                if (item.Cells[18].Value != null && int.TryParse(item.Cells[18].Value.ToString(), out var result7))
                {
                    ((IEleCyldLine)val).RestractTimeOut = result7;
                }
                else
                {
                    ((IEleCyldLine)val).RestractTimeOut = 2000;
                }
                if (item.Cells[19].Value != null && int.TryParse(item.Cells[19].Value.ToString(), out var result8))
                {
                    ((IEleCyldLine)val).BlowTime = result8;
                }
                else
                {
                    ((IEleCyldLine)val).BlowTime = 1000;
                }
                val.EleRunStat = (EleRunState)100;
                ElesManager.Instance.ListEle.Add(val);
            }
        }

        /// <summary>气缸保存_新版本</summary>
        private void SaveEleCylinder(string ver)
        {
            string errorText = null;
            List<string> listAll = new List<string>();
            List<string> listSave = new List<string>();
            List<string> listRemove = new List<string>();
            if (ControlHelper.CheckDgvCellRepeat(dgvEleCylinder, ref errorText)) throw new Exception(errorText);
            //遍历更改
            foreach (DataGridViewRow item in dgvEleCylinder.Rows)
            {
                bool isExist = false;
                string text = item.Cells[0].Value.ToString();
                listSave.Add(text);
                IEle eleByName = ElesManager.Instance.GetEleByName(text);
                isExist = eleByName == null ? false : true;
                IEle val = eleByName ?? ElesManager.Instance.GetEle("CylinderLine");
                val.Name = text;
                val.Info = item.Cells[1].Value?.ToString();
                val.Enable = Convert.ToBoolean(item.Cells[2].Value);
                val.IsSimulateMode = Convert.ToBoolean(item.Cells[3].Value);
                val.DevName = item.Cells[5].Value?.ToString();

                if (Enum.TryParse(item.Cells[6].Value.ToString(), out EleCyldType result))
                    ((IEleCyldLine)val).CyldType = result;

                if (item.Cells[7].Value != null && double.TryParse(item.Cells[7].Value.ToString(), out var result2))
                    ((IEleCyldLine)val).StretchDiAddress = result2;
                else
                    ((IEleCyldLine)val).StretchDiAddress = 0.0;

                ((IEleCyldLine)val).StretchDiEnable = Convert.ToBoolean(item.Cells[8].Value);
                if (item.Cells[9].Value != null && double.TryParse(item.Cells[9].Value.ToString(), out var result3))
                    ((IEleCyldLine)val).RestractDiAddress = result3;
                else
                    ((IEleCyldLine)val).RestractDiAddress = 0.0;

                ((IEleCyldLine)val).RestractDiEnable = Convert.ToBoolean(item.Cells[10].Value);
                if (item.Cells[11].Value != null && double.TryParse(item.Cells[11].Value.ToString(), out var result4))
                    ((IEleCyldLine)val).StretchDoAddress = result4;
                else
                    ((IEleCyldLine)val).StretchDoAddress = 0.0;

                ((IEleCyldLine)val).StretchDoEnable = Convert.ToBoolean(item.Cells[12].Value);
                if (item.Cells[14].Value != null && double.TryParse(item.Cells[14].Value.ToString(), out var result5))
                    ((IEleCyldLine)val).RestractDoAddress = result5;
                else
                    ((IEleCyldLine)val).RestractDoAddress = 0.0;

                ((IEleCyldLine)val).RestractDoEnable = Convert.ToBoolean(item.Cells[15].Value);
                if (item.Cells[17].Value != null && int.TryParse(item.Cells[17].Value.ToString(), out var result6))
                    ((IEleCyldLine)val).StretchTimeOut = result6;
                else
                    ((IEleCyldLine)val).StretchTimeOut = 2000;

                if (item.Cells[18].Value != null && int.TryParse(item.Cells[18].Value.ToString(), out var result7))
                    ((IEleCyldLine)val).RestractTimeOut = result7;
                else
                    ((IEleCyldLine)val).RestractTimeOut = 2000;

                if (item.Cells[19].Value != null && int.TryParse(item.Cells[19].Value.ToString(), out var result8))
                    ((IEleCyldLine)val).BlowTime = result8;
                else
                    ((IEleCyldLine)val).BlowTime = 1000;
                ((IEleCyldLine)val).LineMark = item.Cells[21].Value?.ToString();
                val.EleRunStat = (EleRunState)100;
                if (!isExist) ElesManager.Instance.ListEle.Add(val);
            }

            //遍历删除
            listAll = (from p in ElesManager.Instance.ListEle.FindAll(p => p.EleTypeName == "CylinderLine") select p.Name).ToList();
            foreach (var item in listAll)
            {
                if (!listSave.Contains(item)) listRemove.Add(item);
            }
            foreach (var item in listRemove)
            {
                IEle eleRemove = ElesManager.Instance.GetEleByName(item);
                if (eleRemove != null) ElesManager.Instance.ListEle.Remove(eleRemove);
            }
        }

        /// <summary>输入保存_old</summary>
        private void SaveEleDi()
        {
            string errorText = null;
            if (ControlHelper.CheckDgvCellRepeat(dgvEleDi, ref errorText)) throw new Exception(errorText);

            ElesManager.Instance.ListEle.RemoveAll(p => p.EleTypeName == "DI");
            foreach (DataGridViewRow item in dgvEleDi.Rows)
            {
                string text = item.Cells[0].Value.ToString();
                IEle eleByName = ElesManager.Instance.GetEleByName(text);
                IEle val = eleByName ?? ElesManager.Instance.GetEle("DI");
                val.Name = text;
                val.Info = item.Cells[1].Value?.ToString();
                val.Enable = Convert.ToBoolean(item.Cells[2].Value);
                val.IsSimulateMode = Convert.ToBoolean(item.Cells[3].Value);
                val.DevName = item.Cells[5].Value?.ToString();
                if (item.Cells[6].Value != null && double.TryParse(item.Cells[6].Value.ToString(), out var result))
                    ((IEleDI)val).DiAddress = result;
                else
                    ((IEleDI)val).DiAddress = 0.0;
                ((IEleDI)val).DiEnable = Convert.ToBoolean(item.Cells[7].Value);
                if (item.Cells[8].Value != null && item.Cells[8].Value.ToString() == "NC")
                    ((IEleDI)val).DiType = (EleDIType)2;
                else
                    ((IEleDI)val).DiType = (EleDIType)1;
                ((IEleDI)val).EnRiseEvent = Convert.ToBoolean(item.Cells[9].Value);
                ((IEleDI)val).EnFallEvent = Convert.ToBoolean(item.Cells[10].Value);
                val.EleRunStat = (EleRunState)100;
                ElesManager.Instance.ListEle.Add(val);
            }
        }

        /// <summary>输入保存_新版本</summary>
        private void SaveEleDi(string ver)
        {
            string errorText = null;
            List<string> listAll = new List<string>();
            List<string> listSave = new List<string>();
            List<string> listRemove = new List<string>();

            if (ControlHelper.CheckDgvCellRepeat(dgvEleDi, ref errorText)) throw new Exception(errorText);
            //遍历更改
            foreach (DataGridViewRow item in dgvEleDi.Rows)
            {
                bool isExist = false;
                string text = item.Cells[0].Value.ToString();
                listSave.Add(text);
                IEle eleByName = ElesManager.Instance.GetEleByName(text);
                isExist = eleByName == null ? false : true;
                IEle val = eleByName ?? ElesManager.Instance.GetEle("DI");
                val.Name = text;
                val.Info = item.Cells[1].Value?.ToString();
                val.Enable = Convert.ToBoolean(item.Cells[2].Value);
                val.IsSimulateMode = Convert.ToBoolean(item.Cells[3].Value);
                val.DevName = item.Cells[5].Value?.ToString();

                if (item.Cells[6].Value != null && double.TryParse(item.Cells[6].Value.ToString(), out var result))
                    ((IEleDI)val).DiAddress = result;
                else
                    ((IEleDI)val).DiAddress = 0.0;
                ((IEleDI)val).DiEnable = Convert.ToBoolean(item.Cells[7].Value);
                if (item.Cells[8].Value != null && item.Cells[8].Value.ToString() == "NC")
                    ((IEleDI)val).DiType = (EleDIType)2;
                else
                    ((IEleDI)val).DiType = (EleDIType)1;
                ((IEleDI)val).EnRiseEvent = Convert.ToBoolean(item.Cells[9].Value);
                ((IEleDI)val).EnFallEvent = Convert.ToBoolean(item.Cells[10].Value);
                ((IEleDI)val).LineMark = item.Cells[12].Value?.ToString();
                val.EleRunStat = (EleRunState)100;
                if (!isExist) ElesManager.Instance.ListEle.Add(val);
            }

            //遍历删除
            listAll = (from p in ElesManager.Instance.ListEle.FindAll(p => p.EleTypeName == "DI") select p.Name).ToList();
            foreach (var item in listAll)
            {
                if (!listSave.Contains(item)) listRemove.Add(item);
            }
            foreach (var item in listRemove)
            {
                IEle eleRemove = ElesManager.Instance.GetEleByName(item);
                if (eleRemove != null) ElesManager.Instance.ListEle.Remove(eleRemove);
            }
        }

        /// <summary>输出保存_old</summary>
        private void SaveEleDo()
        {
            string errorText = null;
            if (ControlHelper.CheckDgvCellRepeat(dgvEleDo, ref errorText)) throw new Exception(errorText);
            //if (ControlHelper.CheckDgvCellRepeat(ref dgvEleDo, 0))
            //{
            //    MessageBox.Show("输出元件表中有成员的名称配置重复或不合法，请检查！");
            //    return;
            //}
            ElesManager.Instance.ListEle.RemoveAll((IEle p) => p.EleTypeName == "DO");
            foreach (DataGridViewRow item in (IEnumerable)dgvEleDo.Rows)
            {
                string text = item.Cells[0].Value.ToString();
                IEle eleByName = ElesManager.Instance.GetEleByName(text);
                IEle val = eleByName ?? ElesManager.Instance.GetEle("DO");
                val.Name = text;
                val.Info = item.Cells[1].Value?.ToString();
                val.Enable = Convert.ToBoolean(item.Cells[2].Value);
                val.IsSimulateMode = Convert.ToBoolean(item.Cells[3].Value);
                val.DevName = item.Cells[5].Value?.ToString();
                if (item.Cells[6].Value != null && double.TryParse(item.Cells[6].Value.ToString(), out var result))
                {
                    ((IEleDO)val).DoAddress = result;
                }
                else
                {
                    ((IEleDO)val).DoAddress = 0.0;
                }
                ((IEleDO)val).DoEnable = Convert.ToBoolean(item.Cells[7].Value);
                if (item.Cells[8].Value != null && item.Cells[8].Value.ToString() == "NC")
                {
                    ((IEleDO)val).DoType = (EleDOType)2;
                }
                else
                {
                    ((IEleDO)val).DoType = (EleDOType)1;
                }
                val.EleRunStat = (EleRunState)100;
                ElesManager.Instance.ListEle.Add(val);
            }
        }
        /// <summary>输出保存_新版本</summary>
        private void SaveEleDo(string ver)
        {
            string errorText = null;
            List<string> listAll = new List<string>();
            List<string> listSave = new List<string>();
            List<string> listRemove = new List<string>();
            if (ControlHelper.CheckDgvCellRepeat(dgvEleDo, ref errorText)) throw new Exception(errorText);
            //遍历更改
            foreach (DataGridViewRow item in dgvEleDo.Rows)
            {
                bool isExist = false;
                string text = item.Cells[0].Value.ToString();
                listSave.Add(text);
                IEle eleByName = ElesManager.Instance.GetEleByName(text);
                isExist = eleByName == null ? false : true;
                IEle val = eleByName ?? ElesManager.Instance.GetEle("DO");
                val.Name = text;
                val.Info = item.Cells[1].Value?.ToString();
                val.Enable = Convert.ToBoolean(item.Cells[2].Value);
                val.IsSimulateMode = Convert.ToBoolean(item.Cells[3].Value);
                val.DevName = item.Cells[5].Value?.ToString();
                ((IEleDO)val).LineMark = item.Cells[11].Value?.ToString();

                if (item.Cells[6].Value != null && double.TryParse(item.Cells[6].Value.ToString(), out var result))
                    ((IEleDO)val).DoAddress = result;
                else
                    ((IEleDO)val).DoAddress = 0.0;
                ((IEleDO)val).DoEnable = Convert.ToBoolean(item.Cells[7].Value);
                if (item.Cells[8].Value != null && item.Cells[8].Value.ToString() == "NC")
                    ((IEleDO)val).DoType = (EleDOType)2;
                else
                    ((IEleDO)val).DoType = (EleDOType)1;
                val.EleRunStat = (EleRunState)100;
                if (!isExist) ElesManager.Instance.ListEle.Add(val);
            }

            //遍历删除
            listAll = (from p in ElesManager.Instance.ListEle.FindAll(p => p.EleTypeName == "DO") select p.Name).ToList();
            foreach (var item in listAll)
            {
                if (!listSave.Contains(item)) listRemove.Add(item);
            }
            foreach (var item in listRemove)
            {
                IEle eleRemove = ElesManager.Instance.GetEleByName(item);
                if (eleRemove != null) ElesManager.Instance.ListEle.Remove(eleRemove);
            }
        }
        /// <summary>元件运行状态刷新</summary>
        /// <param name="ele"></param>
        /// <param name="cell"></param>
        private void ShowEleRunStat(IEle ele, DataGridViewCell cell)
        {
            EleRunState eleRunStat = ele.EleRunStat;
            if ((int)ele.IEleCheckPrimRunState() == 1)
            {
                if (eleRunStat == EleRunState.Other)
                {
                    ele.IEleInit();
                }
            }
            cell.Value = eleRunStat.ToString();
            switch ((int)eleRunStat)
            {
                case 0:
                    cell.Style = new DataGridViewCellStyle
                    {
                        BackColor = Color.LightYellow
                    };
                    return;
                case 1:
                    cell.Style = new DataGridViewCellStyle
                    {
                        BackColor = Color.Green
                    };
                    return;
                case 2:
                case 3:
                case 4:
                    cell.Style = new DataGridViewCellStyle
                    {
                        BackColor = Color.OrangeRed
                    };
                    break;
                default:
                    cell.Style = new DataGridViewCellStyle
                    {
                        BackColor = Color.DimGray
                    };
                    break;
            }
        }

        /// <summary>基元运行状态刷新</summary>
        /// <param name="ele"></param>
        /// <param name="cell"></param>
        private void ShowPrimRunStat(IEle ele, DataGridViewCell cell)
        {
            EleRunState eleRunStat = ele.EleRunStat;
            switch ((int)eleRunStat)
            {
                case 0:
                    cell.Style = new DataGridViewCellStyle
                    {
                        BackColor = Color.LightYellow
                    };
                    return;
                case 1:
                    cell.Style = new DataGridViewCellStyle
                    {
                        BackColor = Color.Green
                    };
                    return;
                case 2:
                case 3:
                case 4:
                    cell.Style = new DataGridViewCellStyle
                    {
                        BackColor = Color.OrangeRed
                    };
                    break;
                default:
                    cell.Style = new DataGridViewCellStyle
                    {
                        BackColor = Color.DimGray
                    };
                    break;
            }
        }

        /// <summary>状态刷新定时器</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1UiRefresh_Tick(object sender, EventArgs e)
        {
            if (!_sorting)
            {
                UIRefresh();
            }
            DI数量.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_DI_Count", "DI数量:") + dgvEleDi.Rows.Count.ToString();
            DO数量.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_DO_Count", "DO数量:") + dgvEleDo.Rows.Count.ToString();
            Cylinder数量.Text = NLocalizer.GetString("Lead_CPrim_EleCommon_Forms_EleConfigForm_Cylinder_Count", "气缸数量:") + dgvEleCylinder.Rows.Count.ToString();
        }

        /// <summary>状态刷新规则</summary>
        private void UIRefresh()
        {
            try
            {
                if (!Created || !IsHandleCreated) return;
                if (tabElements.InvokeRequired) return;

                List<IEle> list = null;
                switch (tabElements.SelectedTab.Name)
                {
                    case "tpDI":
                        RefreshEleDi();
                        break;
                    case "tpDO":
                        RefreshEleDo();
                        break;
                    case "tpCylinderLine":
                        RefreshEleCylinder();
                        break;
                    case "tpAD":
                        list = ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName == "AD");
                        break;
                    case "tpDA":
                        list = ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName == "DA");
                        break;
                    case "tpAxisLine":
                        list = ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName == "EleAxisLine");
                        break;
                    case "tpLight":
                        list = ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName == "Light");
                        break;
                    case "tpCartesian":
                        list = ElesManager.Instance.ListEle.FindAll((IEle p) => p.EleTypeName == "Cartesian");
                        break;
                }

                if (list == null)
                {
                    return;
                }

                foreach (IEle item in list)
                {
                    item.IEleUiRefresh();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion
    }
}
