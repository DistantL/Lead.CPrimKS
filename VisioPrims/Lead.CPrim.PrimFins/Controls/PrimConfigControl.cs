/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: PrimConfigControl.cs
 * Author: Victor
 * Description: 欧姆龙Fins通讯ConfigUI
 * CreateTime: 2022-09-21
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 
 * 【连接状态&运行状态】设置纳入框架内，基元开发时保持不变
 * 
 * <3.3.22.0904><Victor><20220921>
 * 1、初版1.0
******************************************************************************/

using Lead.CPrim.Controls;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Dev;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.PrimFinsNet
{
    public partial class PrimConfigControl : UIUserControl
    {
        #region Field
        Prim _prim;
        #endregion



        #region Prop
        #endregion



        #region Ctor
        public PrimConfigControl()
        {
            InitializeComponent();
            Translate();
            SetStyleFlags();

            colType.Items.AddRange(ProtocolDataType.FLOAT.ToString(), ProtocolDataType.FLOATARRAY.ToString(), ProtocolDataType.STRING.ToString(), ProtocolDataType.USHORT.ToString());

            string[] dataPermission = Enum.GetNames(typeof(DataPermission));
            dataPermission.ToList().ForEach(permission => colPermission.Items.Add(permission));

            string[] dataReadMode = Enum.GetNames(typeof(DataReadMode));
            dataReadMode.ToList().ForEach(mode => colReadMode.Items.Add(mode));

            dgvDataConfig.SetDoubleBuffered();
            dgvDataConfig.RowHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Font = new Font("微软雅黑", 7.5f, FontStyle.Regular),
            };

            pnl1.SetStyle(Color.FromArgb(236, 236, 236), Color.FromArgb(211, 211, 211));
            pnl2.SetStyle(Color.FromArgb(236, 236, 236), Color.FromArgb(211, 211, 211));
            pnl3.SetStyle(Color.FromArgb(236, 236, 236), Color.FromArgb(211, 211, 211));
            lblCycleTimeShow.BackColor = Color.Transparent;

            fillColor = Color.FromArgb(236, 236, 236);
            rectColor = Color.FromArgb(236, 236, 236);
            txtName.SetStyle(Color.OldLace);
        }

        public PrimConfigControl(Prim prim) : this()
        {
            _prim = prim;
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrimConfigControl_Load(object sender, EventArgs e)
        {
            txtName.Text = _prim.Name;
            tBoxIP.Text = _prim.IP;
            tBoxPort.Text = _prim.Port;
            tBoxSA1.Text = _prim.SA1;
            tBoxDA1.Text = _prim.DA1;
            tBoxDA2.Text = _prim.DA2;
            tBoxCycleTime.Text = _prim.CycleTime.ToString();
            tBoxReConnCnt.Text = _prim.ReconnectCnt.ToString();
            if (_prim.NotifyMode == SktNotifyMode.DataEvent)
            {
                cBoxNotifyMode.SelectedIndex = 0;
            }
            else if (_prim.NotifyMode == SktNotifyMode.DataQueue)
            {
                cBoxNotifyMode.SelectedIndex = 1;
            }
            tBoxTableDataPath.Text = _prim.DataTablePath;
            if (_prim.FinsTypeSelect == FinsType.FinsUdp)
            {
                cbFinsType.SelectedIndex = 0;
            }
            else if (_prim.FinsTypeSelect == FinsType.FinsNet)
            {
                cbFinsType.SelectedIndex = 1;
            }
            tBoxTableDataPath.Text = _prim.DataTablePath;
            cbLogEnable.Checked = _prim.LogEnable;
            txtReadStartAddress.Text = _prim.ReadStartAddress;
            txtReadLength.Text = _prim.ReadLength.ToString();
            txtWriteStartAddress.Text = _prim.WriteStartAddress;
            txtWriteLength.Text = _prim.WriteLength.ToString();
            DataTableUpdate();
            tBoxTableDataPath_TextChanged(null, null);
            lblVersion.Text = "20240305_V1.7";

            SetPrimConnState(_prim.PrimConnStat);
            SetPrimRunState(_prim.PrimRunStat);
        }

        private void dgvDataConfig_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDataConfig.Rows.Count <= 0)
            {
                return;
            }

            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            if (columnIndex != 1)
            {
                return;
            }
            if (dgvDataConfig.Rows[rowIndex].Cells[1].Value.ToString() == ProtocolDataType.STRING.ToString() || dgvDataConfig.Rows[rowIndex].Cells[1].Value.ToString().Contains("ARRAY"))
            {
                dgvDataConfig.Rows[rowIndex].Cells[2].ReadOnly = false;
                dgvDataConfig.Rows[rowIndex].Cells[2].Style.BackColor = Color.White;
            }
            else
            {
                string type = dgvDataConfig.Rows[rowIndex].Cells[1].Value?.ToString();
                DataGridViewCell cell = dgvDataConfig.Rows[rowIndex].Cells[2];
                cell.Value = type.IsNullOrEmpty() ? 0 : GetLength(type);
                cell.ReadOnly = true;
                cell.Style.BackColor = Color.DarkGray;
            }
        }

        /// <summary>发生错误数据</summary>
        /// <param name="sender"></param>
        /// <param name="anError"></param>
        private void dgvDataConfig_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            try
            {
                if (anError.Context == DataGridViewDataErrorContexts.Commit)
                {
                    throw new Exception("Commit error");
                }
                if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
                {
                    throw new Exception("Cell change");
                }
                if (anError.Context == DataGridViewDataErrorContexts.Parsing)
                {
                    throw new Exception("parsing error");
                }
                if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
                {
                    throw new Exception("leave control error");
                }

                if (anError.Exception is ConstraintException)
                {
                    var view = (DataGridView)sender;
                    view.Rows[anError.RowIndex].ErrorText = "an error";
                    view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";
                    anError.ThrowException = false;
                }
            }
            catch (Exception ex)
            {
                _prim.LogAdd($"数据表报错：{ex.Message}", LogLevel.Warn);
            }
        }

        /// <summary>行增加</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDataConfig_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (var i = 0; i < dgvDataConfig.Rows.Count; i++)
            {
                dgvDataConfig.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        /// <summary>点击事件</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDataConfig_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_prim.PrimRunStat != PrimRunState.Running)
            {
                return;
            }
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            if (columnIndex >= 0 && rowIndex >= 0 && !string.IsNullOrEmpty(dgvDataConfig.Rows[rowIndex].Cells[0].Value?.ToString()) && columnIndex == 9)
            {
                if (string.IsNullOrEmpty(dgvDataConfig.Rows[rowIndex].Cells[5].Value?.ToString()))
                {
                    return;
                }
                string name = dgvDataConfig.Rows[rowIndex].Cells[0].Value.ToString();
                string value = dgvDataConfig.Rows[rowIndex].Cells[5].Value.ToString();
                _prim.Write(name, value);
            }
        }

        private void dgvDataConfig_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDataConfig.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && e.RowIndex != -1)
            {
                SendKeys.Send("{F4}");
            }
        }

        private void dgvDataConfig_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDataConfig.IsCurrentCellDirty)
            {
                dgvDataConfig.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        #endregion



        #region Override ITranslate
        public void Translate()
        {
            //tabPage1.Text = ULocalize.Config;
            //tabPage2.Text = ULocalize.Debug;
            //lblIP.Text = ULocalize.IP;
            //lblPort.Text = ULocalize.Port;
            //lblSA1.Text = NLocalizer.GetLanguageSystem("SA1", false);
            //lblDA1.Text = NLocalizer.GetLanguageSystem("DA1", false);
            //lblDA2.Text = NLocalizer.GetLanguageSystem("DA2", false);
            //cbLogEnable.Text = ULocalize.LogEnable;


            //lblFinsType.Text = NLocalizer.GetLanguageSystem("FinsType", false);
            //lblCycleTime.Text = NLocalizer.GetLanguageSystem("CycleTime", false);
            //lblReConnectCnt.Text = NLocalizer.GetLanguageSystem("ReConnectCnt", false);
            //lblNotifyMode.Text = NLocalizer.GetLanguageSystem("NotifyMode", false);


            //lblReadStartAddress.Text = NLocalizer.GetLanguageSystem("ReadStartAddress", false);
            //lblReadLength.Text = NLocalizer.GetLanguageSystem("ReadLength", false);
            //lblWriteStartAddress.Text = NLocalizer.GetLanguageSystem("WriteStartAddress", false);
            //lblWriteLength.Text = NLocalizer.GetLanguageSystem("WriteLength", false);

            //btnInit.Text = ULocalize.Init;
            //btnRun.Text = ULocalize.Run;
            //btnStop.Text = ULocalize.Stop;
            //btnApply.Text = ULocalize.Apply;

            //tsmiExportCsv.Text = ULocalize.ExportCsv;
            //tsmiImportCsv.Text = ULocalize.ImportCsv;
            //tsmiExportDll.Text = NLocalizer.GetLanguageSystem("ExportDll", false);
            //tsmiRefresh.Text = NLocalizer.GetLanguageSystem("Refresh", false);
            //tsmiSave.Text = NLocalizer.GetLanguageSystem("Save", false);
            //tsmiAdd.Text = ULocalize.Add;
            //tsmiDelete.Text = ULocalize.Delete;
            //tsmiClear.Text = NLocalizer.GetLanguageSystem("Clear", false);

            //colName.HeaderText = ULocalize.Name;
            //colType.HeaderText = ULocalize.Type;
            //colLength.HeaderText = NLocalizer.GetLanguageSystem("Length", false);
            //colAddress.HeaderText = NLocalizer.GetLanguageSystem("Address", false);
            //colPermission.HeaderText = NLocalizer.GetLanguageSystem("Permission", false);
            //colModifyValue.HeaderText = NLocalizer.GetLanguageSystem("ModifyValue", false);
            //colCurrentValue.HeaderText = NLocalizer.GetLanguageSystem("CurrentValue", false);
            //colReadMode.HeaderText = NLocalizer.GetLanguageSystem("ReadMode", false);
            //colEventNotify.HeaderText = NLocalizer.GetLanguageSystem("EventNotify", false);
            //colWriteValue.HeaderText = NLocalizer.GetLanguageSystem("Update", false);

            //cBoxMonitor.Text = ULocalize.Monitor;
        }
        #endregion



        #region Button_Event
        /// <summary>打开数据</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTableBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                if (_prim.PrimRunStat == PrimRunState.Running)
                {
                    throw new Exception("PrimIsRunning");
                }

                string path = tBoxTableDataPath.Text;
                if (btnTableBrowse.Text == NLocalizer.GetString("Save", "保存"))
                {
                    if (!FileHelper.SaveFileDialogMethod("", FilterType.XML, DefaultExt.XML, true, false, true, ref path))
                    {
                        return;
                    }

                    tBoxTableDataPath.Text = path;
                    _prim.LogAdd($"{btnTableBrowse.Text}{NLocalizer.GetString("Success", "成功")}", LogLevel.Info);
                }
                else
                {
                    if (!FileHelper.OpenFileDialogMethod(ref path))
                    {
                        return;
                    }
                    tBoxTableDataPath.Text = path;
                    _prim.ImportDataTable(path);
                    DataTableUpdate();
                    dgvDataConfig.Refresh();
                    btnApply_Click(null, null);
                    _prim.LogAdd($"{btnTableBrowse.Text}{NLocalizer.GetString("Success", "成功")}", LogLevel.Info);
                }
            }
            catch (Exception ex)
            {
                _prim.LogAdd($"{btnTableBrowse.Text}{NLocalizer.GetString("Error", "失败")}：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }

        /// <summary>应用</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (_prim.PrimRunStat == PrimRunState.Running)
                {
                    _prim.LogAdd("PrimIsRunning", LogLevel.Warn, 0, true);
                    return;
                }

                if (!AuthorityManager.Instance.VerifyLevel3Permission(true))
                {
                    return;
                }
                int reconnect = 0;
                int cycleTime = 0;
                if (int.TryParse(tBoxReConnCnt.Text, out reconnect))
                {
                    if (!(reconnect >= 0 && reconnect <= 3))
                    {
                        reconnect = 3;
                        tBoxReConnCnt.Text = reconnect.ToString();
                    }
                }
                else
                {
                    throw new Exception("ReConnCnt：" + NLocalizer.GetString("ValueInvalid", "值无效"));
                }
                if (int.TryParse(tBoxCycleTime.Text, out cycleTime))
                {
                    if (!(cycleTime >= 5 && cycleTime <= 10))
                    {
                        cycleTime = 10;
                        tBoxCycleTime.Text = cycleTime.ToString();
                    }
                }
                else
                {
                    throw new Exception("CycleTime：" + NLocalizer.GetString("ValueInvalid", "值无效"));
                }
                _prim.ReconnectCnt = reconnect;
                _prim.CycleTime = cycleTime;

                if (cBoxNotifyMode.SelectedIndex == 0)
                {
                    _prim.NotifyMode = SktNotifyMode.DataEvent;
                }
                else if (cBoxNotifyMode.SelectedIndex == 1)
                {
                    _prim.NotifyMode = SktNotifyMode.DataQueue;
                }
                if (cbFinsType.SelectedIndex == 0)
                {
                    _prim.FinsTypeSelect = FinsType.FinsUdp;
                }
                else if (cbFinsType.SelectedIndex == 1)
                {
                    _prim.FinsTypeSelect = FinsType.FinsNet;
                }

                if (!string.IsNullOrEmpty(tBoxPort.Text)) _prim.Port = tBoxPort.Text;
                if (!string.IsNullOrEmpty(tBoxIP.Text)) _prim.IP = tBoxIP.Text;
                if (!string.IsNullOrEmpty(tBoxSA1.Text)) _prim.SA1 = tBoxSA1.Text;
                if (!string.IsNullOrEmpty(tBoxDA1.Text)) _prim.DA1 = tBoxDA1.Text;
                if (!string.IsNullOrEmpty(tBoxDA2.Text)) _prim.DA2 = tBoxDA2.Text;
                _prim.Name = txtName.Text;
                _prim.LogEnable = cbLogEnable.Checked;
                _prim.DataTablePath = tBoxTableDataPath.Text;
                _prim.ReadStartAddress = txtReadStartAddress.Text;
                _prim.ReadLength = ushort.TryParse(txtReadLength.Text, out var readVal) ? readVal : (ushort)0;
                _prim.WriteStartAddress = txtWriteStartAddress.Text;
                _prim.WriteLength = ushort.TryParse(txtWriteLength.Text, out var writeVal) ? writeVal : (ushort)0;

                _prim.LogAdd(NLocalizer.GetString("ApplySuccess", "应用成功"), LogLevel.Info);
            }
            catch (Exception ex)
            {
                _prim.LogAdd(NLocalizer.GetString("ApplyError", "应用失败") + $"：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }

        /// <summary>监控</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cBoxMonitor_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxMonitor.Checked)
            {
                tmrUpdate.Start();
            }
            else
            {
                tmrUpdate.Stop();
            }
        }

        /// <summary>导出CSV</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiExportCsv_Click(object sender, EventArgs e)
        {
            string errorText = "";
            if (!ControlHelper.SaveDgvDataToCsvFile(dgvDataConfig, true, ref errorText))
            {
                _prim.LogAdd($"{NLocalizer.GetString("ExportCsvError", "导出CSV失败")}：{errorText}", LogLevel.Warn);
            }
        }

        /// <summary>导入CSV</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiImportCsv_Click(object sender, EventArgs e)
        {
            try
            {
                if (_prim.PrimRunStat == PrimRunState.Running)
                {
                    _prim.LogAdd("PrimIsRunning", LogLevel.Warn, 0, true);
                    return;
                }

                FinsDataConfigs finsConfigs = new FinsDataConfigs();
                string path = "";
                if (!FileHelper.OpenFileDialogMethod("", FilterType.CSV, false, ref path))
                {
                    return;
                }
                List<string> ls = new List<string>();
                if (CsvHelper.ReadCsvToListString(path, Encoding.Default, true, out ls))
                {
                    for (int i = 0; i < ls.Count; i++)
                    {
                        string[] re = ls[i].Split(',');
                        if (re.Length < 10)
                        {
                            throw new Exception($"CSV{NLocalizer.GetString("FormatError", "格式错误")}");
                        }
                        FinsDataConfig finsConfig = new FinsDataConfig();
                        finsConfig.DtName = re[0];
                        finsConfig.DtType = DataHelper.StringToProtocolDataType(re[1]);
                        if (finsConfig.DtType == ProtocolDataType.OTHER)
                        {
                            throw new Exception($"Rows {i} Type：{NLocalizer.GetString("ValueInvalid", "值无效")}");
                        }
                        finsConfig.DtLength = finsConfig.DtType == ProtocolDataType.STRING ? (ushort.TryParse(re[2], out var length) ? length : throw new Exception($"Rows {i} Length：" + NLocalizer.GetString("ValueInvalid", "值无效"))) : GetLength(re[1]);
                        finsConfig.DtAddress = re[3];
                        finsConfig.DtPermission = DataHelper.StringToPermission(re[4]);
                        finsConfig.DtRdMode = DataHelper.StringToDataReadMode(re[7]);
                        finsConfig.DtIsNotify = bool.TryParse(re[8], out var notify) ? notify : throw new Exception($"Rows {i} IsNotify：" + NLocalizer.GetString("ValueInvalid", "值无效"));                    }

                    _prim.DataConfigs.ListDataConfig.Clear();
                    _prim.DataConfigs = finsConfigs.CopyClass();
                    DataTableUpdate();
                }
                else
                {
                    throw new Exception("Data Is Null");
                }
            }
            catch (Exception ex)
            {
                _prim.LogAdd($"{NLocalizer.GetString("ImportCsvError", "导入CSV错误")}：{ex.Message}", LogLevel.Warn);
            }
        }

        /// <summary>
        /// 导出Dll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiExportDll_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "";
                if (!FileHelper.SaveFileDialogMethod("", FilterType.CS, DefaultExt.CS, true, false, true, ref path))
                {
                    return;
                }

                ExportDll(Path.Combine(UIGlobal.DefinePath, $"{_prim.Name}.dll"), path, true);
            }
            catch (Exception ex)
            {
                _prim.LogAdd($"{ex.Message}", LogLevel.Warn, 0, true);
            }
        }

        /// <summary>
        /// 增加一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            if (_prim.PrimRunStat == PrimRunState.Running)
            {
                _prim.LogAdd("PrimIsRunning", LogLevel.Warn, 0, true);
                return;
            }

            var index = dgvDataConfig.Rows.Add();
            dgvDataConfig.Rows[index].Cells[1].Value = ProtocolDataType.STRING.ToString();
            dgvDataConfig.Rows[index].Cells[4].Value = DataPermission.RW.ToString();
            dgvDataConfig.Rows[index].Cells[7].Value = DataReadMode.Cycle.ToString();
            dgvDataConfig.Rows[index].Cells[8].Value = true;
            dgvDataConfig.Refresh();
        }

        /// <summary>
        /// 删除一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (_prim.PrimRunStat == PrimRunState.Running)
            {
                _prim.LogAdd("PrimIsRunning", LogLevel.Warn, 0, true);
                return;
            }

            if (dgvDataConfig.Rows.Count <= 0)
            {
                return;
            }

            var index = dgvDataConfig.CurrentCell.RowIndex;
            dgvDataConfig.Rows.RemoveAt(index);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (_prim.PrimRunStat == PrimRunState.Running)
                {
                    _prim.LogAdd("PrimIsRunning", LogLevel.Warn, 0, true);
                    return;
                }

                var rowCount = dgvDataConfig.Rows.Count;

                if (rowCount <= 0)
                {
                    return;
                }

                string adress;
                int firstR = -1;
                int endR = -1;
                int firstW = -1;
                int endW = -1;
                int firstRW = -1;
                int endRW = -1;
                int readStart = -1;
                int writeStart = -1;
                string prefix = "";
                string p = "";
                string length;

                for (var i = 0; i < rowCount; i++)
                {
                    string name = dgvDataConfig.Rows[i].Cells[0].Value?.ToString();
                    if (name.IsNullOrWhiteSpace())
                    {
                        throw new Exception($"Rows {i + 1} name is null");
                    }

                    string permission = dgvDataConfig.Rows[i].Cells[4].Value?.ToString();
                    if (permission.IsNullOrWhiteSpace())
                    {
                        throw new Exception($"Rows {i + 1} permission is null");
                    }

                    if (permission == "R" && firstR == -1)
                    {
                        firstR = i;
                    }

                    if (permission == "W" && firstW == -1)
                    {
                        firstW = i;
                    }

                    if (permission == "RW" && firstRW == -1)
                    {
                        firstRW = i;
                    }

                    if (permission == "R")
                    {
                        endR = i;
                    }

                    if (permission == "W")
                    {
                        endW = i;
                    }

                    if (permission == "RW")
                    {
                        endRW = i;
                    }
                }

                if (firstR != -1 && endR != -1 && firstR != endR)
                {
                    for (int i = firstR; i <= endR; i++)
                    {
                        string permission = dgvDataConfig.Rows[i].Cells[4].Value?.ToString();
                        if (permission != "R")
                        {
                            throw new Exception($"R variable not continuous：Rows {i}");
                        }
                    }
                }
                else
                {
                    _prim.ReadStartAddress = "";
                    _prim.ReadLength = 0;
                }

                if (firstW != -1 && endW != -1 && firstW != endW)
                {
                    for (int i = firstW; i <= endW; i++)
                    {
                        string permission = dgvDataConfig.Rows[i].Cells[4].Value?.ToString();
                        if (permission != "W")
                        {
                            throw new Exception($"W variable not continuous：Rows {i}");
                        }
                    }
                }

                if (firstRW != -1 && endRW != -1 && firstRW != endRW)
                {
                    for (int i = firstRW; i <= endRW; i++)
                    {
                        string permission = dgvDataConfig.Rows[i].Cells[4].Value?.ToString();
                        if (permission != "RW")
                        {
                            throw new Exception($"RW variable not continuous：Rows {i}");
                        }
                    }
                }
                else
                {
                    _prim.WriteStartAddress = "";
                    _prim.WriteLength = 0;
                }

                for (var i = 0; i < rowCount; i++)
                {
                    adress = dgvDataConfig.Rows[i].Cells[3].Value?.ToString();
                    length = dgvDataConfig.Rows[i].Cells[2].Value?.ToString();
                    if (length.IsNullOrEmpty() || int.Parse(length) == 0)
                    {
                        throw new Exception("Length is null or 0");
                    }

                    if (i == firstR)
                    {
                        if (adress.IsNullOrEmpty())
                        {
                            throw new Exception("R variable head address cannot be empty");
                        }
                        _prim.ReadStartAddress = adress;
                        prefix = adress.Left(1);
                        readStart = int.Parse(adress.Substring(1));
                        p = prefix + (readStart + int.Parse(length));
                        continue;
                    }

                    if (i == firstW)
                    {
                        length = dgvDataConfig.Rows[i].Cells[2].Value?.ToString();
                        if (adress.IsNullOrEmpty())
                        {
                            throw new Exception("R variable head address cannot be empty");
                        }
                        prefix = adress.Left(1);
                        p = prefix + (int.Parse(adress.Substring(1)) + int.Parse(length));
                        continue;
                    }

                    if (i == firstRW)
                    {
                        length = dgvDataConfig.Rows[i].Cells[2].Value?.ToString();
                        if (adress.IsNullOrEmpty())
                        {
                            throw new Exception("R variable head address cannot be empty");
                        }
                        _prim.WriteStartAddress = adress;
                        prefix = adress.Left(1);
                        writeStart = int.Parse(adress.Substring(1));
                        p = prefix + (writeStart + int.Parse(length));
                        continue;
                    }

                    {
                        dgvDataConfig.Rows[i].Cells[3].Value = p;
                        adress = dgvDataConfig.Rows[i].Cells[3].Value?.ToString();
                        p = prefix + (int.Parse(adress.Substring(1)) + int.Parse(length));
                    }

                    if (i == endR)
                    {
                        _prim.ReadLength = (ushort)(int.Parse(adress.Substring(1)) + int.Parse(length) - readStart);
                    }

                    if (i == endRW)
                    {
                        _prim.WriteLength = (ushort)(int.Parse(adress.Substring(1)) + int.Parse(length) - writeStart);
                    }
                }
                tsmiSave_Click(null, null);
            }
            catch (Exception ex)
            {
                _prim.LogAdd($"{NLocalizer.GetString("RefreshError", "刷新失败")}：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }

        /// <summary>
        /// 数据保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_prim.PrimRunStat == PrimRunState.Running)
                {
                    _prim.LogAdd("PrimIsRunning", LogLevel.Warn, 0, true);
                    return;
                }

                if (!AuthorityManager.Instance.VerifyLevel3Permission(true))
                {
                    return;
                }

                string errorText = "";
                if (ControlHelper.CheckDgvCellRepeat(dgvDataConfig, ref errorText, 0))
                {
                    errorText = $"{NLocalizer.GetString("Column1Repeat", "列1重复")} -> " + errorText;
                    throw new Exception(errorText);
                }
                if (ControlHelper.CheckDgvCellRepeat(dgvDataConfig, ref errorText, 3))
                {
                    errorText = $"{NLocalizer.GetString("Column4Repeat", "列4重复")} -> " + errorText;
                    throw new Exception(errorText);
                }
                string path = tBoxTableDataPath.Text;
                if (string.IsNullOrEmpty(path))
                {
                    throw new Exception("Path Is Null");
                }

                if (SaveData(path))
                {
                    _prim.LogAdd(NLocalizer.GetString("SaveSuccess", "保存成功"), LogLevel.Info);
                }
            }
            catch (Exception ex)
            {
                _prim.LogAdd($"{NLocalizer.GetString("SaveError", "保存失败")}：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }

        /// <summary>清空</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiClear_Click(object sender, EventArgs e)
        {
            if (!this.ShowAskDialog($"{NLocalizer.GetString("DeleteAll", "删除所有？")}"))
            {
                return;
            }
            dgvDataConfig.Rows.Clear();
            dgvDataConfig.Refresh();
            _prim.DataConfigs = new FinsDataConfigs();
        }

        /// <summary>
        /// 文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBoxTableDataPath_TextChanged(object sender, EventArgs e)
        {
            string path = tBoxTableDataPath.Text;
            if (path.IsNullOrWhiteSpace())
            {
                btnTableBrowse.Text = NLocalizer.GetString("Save", "保存");
            }
            else
            {
                btnTableBrowse.Text = NLocalizer.GetString("Open", "打开");
            }
        }

        /// <summary>
        /// 获取测试数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblCycleTimeShow_DoubleClick(object sender, EventArgs e)
        {
            if (!_prim.Testing)
            {
                _prim.LogAdd($"{NLocalizer.GetString("Start", "开始")}", LogLevel.Trace);
                _prim.Testing = true;
            }
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>从Fins地址读取数据</summary>
        /// <param name="valAddr"></param>
        /// <param name="valType"></param>
        /// <returns></returns>
        public object ReadVariableFromAddr(string valAddr, DataType valType)
        {
            object val = null;
            if (string.IsNullOrEmpty(valAddr)) return null;

            switch (valType)
            {
                case DataType.BOOL:
                    val = _prim._omronPlc.ReadBool(valAddr).Content;
                    break;

                case DataType.INT:
                    val = _prim._omronPlc.ReadInt32(valAddr).Content;
                    break;

                case DataType.DOUBLE:
                    val = _prim._omronPlc.ReadDouble(valAddr).Content;
                    break;

                case DataType.STRING:
                    val = _prim._omronPlc.ReadString(valAddr, 256).Content;
                    break;
            }

            return val;
        }

        /// <summary>
        /// 设置CycleTime
        /// </summary>
        /// <param name="value"></param>
        internal void SetCycleTime(double value)
        {
            lblCycleTimeShow.SetText(value.ToString());
        }

        /// <summary>
        /// 设置读起始地址
        /// </summary>
        /// <param name="value"></param>
        internal void SetReadStartAddress(string value)
        {
            txtReadStartAddress.SetText(value);
        }

        /// <summary>
        /// 设置读长度
        /// </summary>
        /// <param name="value"></param>
        internal void SetReadLength(string value)
        {
            txtReadLength.SetText(value);
        }

        /// <summary>
        /// 设置写起始地址
        /// </summary>
        /// <param name="value"></param>
        internal void SetWriteStartAddress(string value)
        {
            txtWriteStartAddress.SetText(value);
        }

        /// <summary>
        /// 设置写长度
        /// </summary>
        /// <param name="value"></param>
        internal void SetWriteLength(string value)
        {
            txtWriteLength.SetText(value);
        }

        /// <summary>
        /// 错误设置
        /// </summary>
        /// <param name="error"></param>
        internal void SetError(string error)
        {
            lblError.SetText(error);
        }

        /// <summary>
        /// 导出dll
        /// </summary>
        /// <param name="pathDll"></param>
        /// <param name="pathCode"></param>
        /// <param name="manual">true：手动；false：自动；</param>
        public string ExportDll(string pathDll, string pathCode, bool manual = true)
        {
            //判断源码文件是否存在，存在则删除
            FileInfo info = new FileInfo(pathCode);
            if (File.Exists(info.FullName))
            {
                File.Delete(info.FullName);
            }

            //判断dll文件是否存在，存在则删除
            if (File.Exists(pathDll))
            {
                File.Delete(pathDll);
            }

            //源码文件写入本地
            string code = GenerateCode();
            FileHelper.CreateNewFolder(pathCode);
            DataHelper.WriteFile(pathCode, code);

            //编译并生成dll
            string dll1 = Path.Combine(Application.StartupPath, @"InnerLibs\Interfaces\Lead.CPrim.Interfaces.Dev.dll");
            string dll2 = Path.Combine(Application.StartupPath, @"InnerLibs\Interfaces\Lead.CPrim.Interfaces.dll");
            CompilerResults cr = code.CreateDll(pathDll, new string[] { dll1, dll2 });
            List<string> strs = new List<string>();
            if (cr.Errors.HasErrors)
            {
                foreach (CompilerError err in cr.Errors)
                {
                    strs.Add(err.ErrorText);
                }
                throw new Exception(string.Join("/n", strs.ToArray()));
            }
            else
            {
                _prim.LogAdd($"Export Code Success", LogLevel.Info);
                if (manual)
                {
                    Notification.ShowInfo(NLocalizer.ChangesWillTakeEffectWhenYouRestartTheApplication);
                }
            }

            return code;
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>保存文件</summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool SaveData(string path)
        {
            FileHelper.CreateNewFolder(path);
            var rowCount = dgvDataConfig.Rows.Count;
            if (rowCount < 1)
            {
                _prim.DataConfigs = new FinsDataConfigs();
            }
            else
            {
                if (_prim.DataConfigs?.ListDataConfig == null)
                {
                    _prim.DataConfigs = new FinsDataConfigs();
                }

                _prim.DataConfigs.ListDataConfig.Clear();
                for (var i = 0; i < rowCount; i++)
                {
                    var dtConfig = new FinsDataConfig();

                    dtConfig.DtName = string.IsNullOrEmpty(dgvDataConfig.Rows[i].Cells[0].Value?.ToString()) ? throw new Exception("Name Is Null") : dgvDataConfig.Rows[i].Cells[0].Value.ToString();
                    dtConfig.DtType = string.IsNullOrEmpty(dgvDataConfig.Rows[i].Cells[1].Value?.ToString()) ? throw new Exception("Type Is Null") : DataHelper.StringToProtocolDataType(dgvDataConfig.Rows[i].Cells[1].Value.ToString());
                    dtConfig.DtLength = ushort.TryParse(dgvDataConfig.Rows[i].Cells[2].Value?.ToString(), out var length) ? length : throw new Exception("Length Is Null");
                    dtConfig.DtAddress = string.IsNullOrEmpty(dgvDataConfig.Rows[i].Cells[3].Value?.ToString()) ? throw new Exception("Address Is Null") : dgvDataConfig.Rows[i].Cells[3].Value.ToString();
                    dtConfig.DtPermission = string.IsNullOrEmpty(dgvDataConfig.Rows[i].Cells[4].Value?.ToString()) ? throw new Exception("Permission Is Null") :
                            DataHelper.StringToPermission(dgvDataConfig.Rows[i].Cells[4].Value.ToString());
                    dtConfig.DtRdMode = string.IsNullOrEmpty(dgvDataConfig.Rows[i].Cells[7].Value?.ToString()) ? throw new Exception("RdMode Is Null") : DataHelper.StringToDataReadMode(dgvDataConfig.Rows[i].Cells[7].Value.ToString());
                    dtConfig.DtIsNotify = string.IsNullOrEmpty(dgvDataConfig.Rows[i].Cells[8].Value?.ToString()) ? throw new Exception("IsNotify Is Null") : (bool)dgvDataConfig.Rows[i].Cells[8].Value;

                    _prim.DataConfigs.ListDataConfig.Add(dtConfig);
                }
            }
            return _prim.ExportDataTable(path) == 0;
        }

        /// <summary>时间线程</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            var rowCount = dgvDataConfig.Rows.Count;

            if (rowCount <= 0)
            {
                return;
            }

            for (var i = 0; i < rowCount; i++)
            {
                string name = dgvDataConfig.Rows[i].Cells[0].Value?.ToString();
                if (name.IsNullOrWhiteSpace())
                {
                    continue;
                }

                FinsDataConfig con = _prim.DataConfigs.ListDataConfig.FirstOrDefault(config => config.DtName == name);
                if (con == null)
                {
                    continue;
                }

                dgvDataConfig.Rows[i].Cells[6].Value = con.DtCurrentValue.ToString();
            }
        }

        /// <summary>将集合加载到DGV</summary>
        private void DataTableUpdate()
        {
            if (_prim?.DataConfigs?.ListDataConfig.IsValid() != true)
            {
                _prim.DataConfigs = new FinsDataConfigs();
            }

            dgvDataConfig.Rows.Clear();
            foreach (var config in _prim.DataConfigs.ListDataConfig)
            {
                var index = dgvDataConfig.Rows.Add();
                dgvDataConfig.Rows[index].Cells[0].Value = config.DtName;
                dgvDataConfig.Rows[index].Cells[1].Value = config.DtType.ToString();
                dgvDataConfig.Rows[index].Cells[2].Value = config.DtLength.ToString();
                dgvDataConfig.Rows[index].Cells[3].Value = config.DtAddress;
                dgvDataConfig.Rows[index].Cells[4].Value = config.DtPermission.ToString();
                dgvDataConfig.Rows[index].Cells[7].Value = config.DtRdMode.ToString();
                dgvDataConfig.Rows[index].Cells[8].Value = config.DtIsNotify;
            }
        }

        /// <summary>
        /// 代码生成
        /// </summary>
        /// <returns></returns>
        private string GenerateCode()
        {
            StringBuilder text = new StringBuilder();
            text.Append("using System;\n");
            text.Append("using Lead.CPrim.Interfaces;\n");
            text.Append("namespace Lead.CPrim.Global\n");
            text.Append("{\n");
            text.Append($"\tpublic class {_prim.Name}\n");
            text.Append("\t{\n");

            //变量管理用户接口
            text.Append("\t\tIPlc _manager;\n");
            //字段
            foreach (var item in _prim.DataConfigs.ListDataConfig)
            {
                switch (item.DtType)
                {
                    case ProtocolDataType.SHORT:
                        text.Append($"\t\tprivate short _{item.DtName};\n");
                        break;

                    case ProtocolDataType.INT:
                        text.Append($"\t\tprivate int _{item.DtName};\n");
                        break;

                    case ProtocolDataType.LONG:
                        text.Append($"\t\tprivate long _{item.DtName};\n");
                        break;

                    case ProtocolDataType.FLOAT:
                        text.Append($"\t\tprivate float _{item.DtName};\n");
                        break;

                    case ProtocolDataType.FLOATARRAY:
                        text.Append($"\t\tprivate string _{item.DtName};\n");
                        break;

                    case ProtocolDataType.USHORT:
                        text.Append($"\t\tprivate ushort _{item.DtName};\n");
                        break;

                    case ProtocolDataType.UINT:
                        text.Append($"\t\tprivate uint _{item.DtName};\n");
                        break;

                    case ProtocolDataType.ULONG:
                        text.Append($"\t\tprivate ulong _{item.DtName};\n");
                        break;

                    case ProtocolDataType.DOUBLE:
                        text.Append($"\t\tprivate double _{item.DtName};\n");
                        break;

                    case ProtocolDataType.BOOL:
                        text.Append($"\t\tprivate bool _{item.DtName};\n");
                        break;

                    case ProtocolDataType.STRING:
                        text.Append($"\t\tprivate string _{item.DtName};\n");
                        break;

                    case ProtocolDataType.OTHER:
                    default:
                        continue;
                }
            }

            //属性
            foreach (var item in _prim.DataConfigs.ListDataConfig)
            {
                switch (item.DtType)
                {
                    case ProtocolDataType.SHORT:
                        text.Append($"\t\tpublic short {item.DtName}");
                        break;

                    case ProtocolDataType.INT:
                        text.Append($"\t\tpublic int {item.DtName}");
                        break;

                    case ProtocolDataType.LONG:
                        text.Append($"\t\tpublic long {item.DtName}");
                        break;

                    case ProtocolDataType.FLOAT:
                        text.Append($"\t\tpublic float {item.DtName}");
                        break;

                    case ProtocolDataType.FLOATARRAY:
                        text.Append($"\t\tpublic string {item.DtName}");
                        break;

                    case ProtocolDataType.USHORT:
                        text.Append($"\t\tpublic ushort {item.DtName}");
                        break;

                    case ProtocolDataType.UINT:
                        text.Append($"\t\tpublic uint {item.DtName}");
                        break;

                    case ProtocolDataType.ULONG:
                        text.Append($"\t\tpublic ulong {item.DtName}");
                        break;

                    case ProtocolDataType.DOUBLE:
                        text.Append($"\t\tpublic double {item.DtName}");
                        break;

                    case ProtocolDataType.BOOL:
                        text.Append($"\t\tpublic bool {item.DtName}");
                        break;

                    case ProtocolDataType.STRING:
                        text.Append($"\t\tpublic string {item.DtName}");
                        break;

                    case ProtocolDataType.OTHER:
                    default:
                        continue;
                }
                text.Append("\n\t\t{\n");

                text.Append("\t\t\tget\n");
                text.Append("\t\t\t{\n");
                text.Append($"\t\t\t\treturn _{item.DtName};\n");
                text.Append("\t\t\t}\n");

                switch (item.DtType)
                {
                    case ProtocolDataType.FLOATARRAY:
                        break;

                    default:
                        text.Append("\t\t\tset\n");
                        text.Append("\t\t\t{\n");

                        text.Append($"\t\t\t\tif(_{item.DtName} != value && _manager.Write(\"{item.DtName}\", value) == 0)\n");
                        text.Append("\t\t\t\t{\n");
                        text.Append($"\t\t\t\t\t_{item.DtName} = value;\n");
                        text.Append("\t\t\t\t}\n");

                        text.Append("\t\t\t}\n");
                        break;
                }
                text.Append("\t\t}\n");
            }

            //Ctor
            text.Append($"\t\tpublic {_prim.Name}(IPlc manager)\n");
            text.Append("\t\t{\n");
            text.Append("\t\t\t_manager = manager;\n");
            text.Append("\t\t}\n");

            //Method
            text.Append("\t\tpublic void InstancePlcVariableChanged(string valName, string valAddr, string valType, object valLast, object currentValue)\n");
            text.Append("\t\t{\n");
            text.Append("\t\t\tswitch (valName)\n");
            text.Append("\t\t\t{\n");
            foreach (var item in _prim.DataConfigs.ListDataConfig)
            {
                text.Append($"\t\t\t\tcase \"{item.DtName}\":\n");
                text.Append("\t\t\t\t\t{\n");

                switch (item.DtType)
                {
                    case ProtocolDataType.SHORT:
                        text.Append($"\t\t\t\t\t\tshort val = 0;\n");
                        text.Append($"\t\t\t\t\t\t_{item.DtName} = short.TryParse(currentValue.ToString(), out val) ? val : (short)0;");
                        break;

                    case ProtocolDataType.INT:
                        text.Append($"\t\t\t\t\t\tint val = 0;\n");
                        text.Append($"\t\t\t\t\t\t_{item.DtName} = int.TryParse(currentValue.ToString(), out val) ? val : 0;");
                        break;

                    case ProtocolDataType.LONG:
                        text.Append($"\t\t\t\t\t\tlong val = 0l;\n");
                        text.Append($"\t\t\t\t\t\t_{item.DtName} = long.TryParse(currentValue.ToString(), out val) ? val : 0l;");
                        break;

                    case ProtocolDataType.FLOAT:
                        text.Append($"\t\t\t\t\t\tfloat val = 0.0f;\n");
                        text.Append($"\t\t\t\t\t\t_{item.DtName} = float.TryParse(currentValue.ToString(), out val) ? val : 0.0f;");
                        break;

                    case ProtocolDataType.FLOATARRAY:
                        text.Append($"\t\t\t\t\t\t_{item.DtName} = currentValue.ToString();");
                        break;

                    case ProtocolDataType.USHORT:
                        text.Append($"\t\t\t\t\t\tushort val = 0;\n");
                        text.Append($"\t\t\t\t\t\t_{item.DtName} = ushort.TryParse(currentValue.ToString(), out val) ? val : (ushort)0;");
                        break;

                    case ProtocolDataType.UINT:
                        text.Append($"\t\t\t\t\t\tuint val = 0;\n");
                        text.Append($"\t\t\t\t\t\t_{item.DtName} = uint.TryParse(currentValue.ToString(), out val) ? val : (uint)0;");
                        break;

                    case ProtocolDataType.ULONG:
                        text.Append($"\t\t\t\t\t\tulong val = 0;\n");
                        text.Append($"\t\t\t\t\t\t_{item.DtName} = ulong.TryParse(currentValue.ToString(), out val) ? val : (ulong)0;");
                        break;

                    case ProtocolDataType.DOUBLE:
                        text.Append($"\t\t\t\t\t\tdouble val = 0.0;\n");
                        text.Append($"\t\t\t\t\t\t_{item.DtName} = double.TryParse(currentValue.ToString(), out val) ? val : 0.0;");
                        break;

                    case ProtocolDataType.BOOL:
                        text.Append($"\t\t\t\t\t\tbool val = false;\n");
                        text.Append($"\t\t\t\t\t\t_{item.DtName} = bool.TryParse(currentValue.ToString(), out val) ? val : false;");
                        break;

                    case ProtocolDataType.STRING:
                        text.Append($"\t\t\t\t\t\t_{item.DtName} = currentValue.ToString();");
                        break;

                    case ProtocolDataType.OTHER:
                    default:
                        continue;
                }

                text.Append("\n");
                text.Append("\t\t\t\t\t}\n");
                text.Append("\t\t\t\t\tbreak;\n");
            }
            text.Append($"\t\t\t\tdefault:\n");
            text.Append($"\t\t\t\t\tbreak;\n");

            text.Append("\t\t\t}\n");
            text.Append("\t\t}\n");
            text.Append("\t}\n");
            text.Append("}");

            return text.ToString();
        }

        /// <summary>
        /// 获取类型的长度
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private ushort GetLength(string type)
        {
            ushort len = 0;
            switch (type)
            {
                case "SHORT":
                    break;

                case "INT":
                    break;

                case "LONG":
                    break;

                case "FLOAT":
                    len = 2;
                    break;

                case "USHORT":
                    len = 1;
                    break;

                case "UINT":
                    break;

                case "ULONG":
                    break;

                case "DOUBLE":
                    break;

                case "BOOL":
                    break;

                default:
                    break;
            }
            return len;
        }
        #endregion



        #region Method_NoUsing

        private string GetValueOfVariables(object val)
        {
            var valStr = string.Empty;
            if (val.GetType().IsArray)
            {
                var valArray = val as Array;
                if (valArray.Rank == 1)
                {
                    valStr += "[";
                    foreach (var a in valArray) valStr += GetValueString(a) + ",";
                    valStr = valStr.TrimEnd(',');
                    valStr += "]";
                }
                else if (valArray.Rank == 2)
                {
                    for (var i = 0; i <= valArray.GetUpperBound(0); i++)
                    {
                        valStr += "[";
                        for (var j = 0; j <= valArray.GetUpperBound(1); j++)
                            valStr += GetValueString(valArray.GetValue(i, j)) + ",";
                        valStr = valStr.TrimEnd(',');
                        valStr += "]";
                    }
                }
                else if (valArray.Rank == 3)
                {
                    for (var i = 0; i <= valArray.GetUpperBound(0); i++)
                        for (var j = 0; j <= valArray.GetUpperBound(1); j++)
                        {
                            valStr += "[";
                            for (var z = 0; z <= valArray.GetUpperBound(2); z++)
                                valStr += GetValueString(valArray.GetValue(i, j, z)) + ",";
                            valStr = valStr.TrimEnd(',');
                            valStr += "]";
                        }
                }
            }
            else
            {
                valStr = GetValueString(val);
            }

            return valStr;
        }

        private string GetValueString(object val)
        {
            if (val is float || val is double)
                return string.Format("{0:R}", val);
            return val.ToString();
        }
        #endregion





        #region 框架内
        /// <summary>
        /// 基元初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInit_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                lblError.Text = "";
                _prim?.IPrimInit();
                var result = "";
                _prim?.IPrimConnect(ref result);
            });
        }

        /// <summary>
        /// 基元运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                _prim?.IPrimStart();
            });
        }

        /// <summary>
        /// 基元停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                _prim?.IPrimTaskStop();
            });
        }

        /// <summary>
        /// 版本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblVersion_DoubleClick(object sender, EventArgs e)
        {
            string msg =
                "20240305_V1.7   \r\n1、增加事件通知2个，合计3个，1个基元可以在3个脚本中使用   \r\n\r\n" +
                "V1.6   \r\n1、读写异步变更为读同步，写同步，读写同步   \r\n\r\n" +
                "V1.5   \r\n1、增加对FLOATARRAY（float[]）的支持 ，合计四种类型 \r\n2、导出代码功能取消，导出DLL时同时导出代码   \r\n\r\n" +
                "V1.4   \r\n字符串写入补位符由\" \"变更位\\0，解决PLC不能转换问题    \r\n\r\n" +
                "V1.3   \r\n增加刷新功能（地址一键分配+保存）   \r\n注意一：R\\W\\RW地址连续 \r\n注意二：R\\W\\RW首地址不能为空    \r\n\r\n" +
                "V1.2   \r\n增加导出DLL功能   \r\n用法一：ExtLibs\\Third\\Define下源代码复制到Task \r\n用法二：导出的DLL放到ExtLibs\\Third\\Define下，重启软件可直接使用    \r\n\r\n" +
                "V1.1   \r\n优化FinsUdp 支持FLOAT,USHORT,STRING三种类型\r\n\r\n" +
                "V1.0   \r\nFins通讯，嘉善立讯SPK Auto Sub线使用  \r\n支持FinsNet FLOAT,USHORT,STRING三种类型";
            VersionForm.Instance.SetInfo(_prim.Name, _prim.HSType.ToString(), _prim.Manu.ToString(), msg);
            VersionForm frm = VersionForm.Instance;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        /// <summary>基元名称设置</summary>
        /// <param name="name">名称</param>
        internal void SetPrimName(string name)
        {
            if (!Created || !IsHandleCreated)
            {
                return;
            }

            txtName.SetText(name);
        }

        /// <summary>连接状态设置</summary>
        /// <param name="state">连接状态</param>
        public void SetPrimConnState(PrimConnState state)
        {
            if (!Created || !IsHandleCreated)
            {
                return;
            }
            if (txtConnState.InvokeRequired)
            {
                BeginInvoke(new Action<PrimConnState>(SetPrimConnState), state);
            }
            else
            {
                switch (state)
                {
                    case PrimConnState.UnConnected:
                    case PrimConnState.Other:
                        txtConnState.FillColor = Color.Khaki;
                        txtConnState.Text = PrimConnState.UnConnected.ToString();

                        btnInit.BackColor = Color.SkyBlue;
                        btnInit.Enabled = true;
                        break;
                    case PrimConnState.Connected:
                        txtConnState.FillColor = Color.LightGreen;
                        txtConnState.Text = PrimConnState.Connected.ToString();

                        btnInit.BackColor = Color.Gray;
                        btnInit.Enabled = false;
                        break;
                }
            }
        }

        /// <summary>运行状态设置</summary>
        /// <param name="state">运行状态</param>
        public void SetPrimRunState(PrimRunState state)
        {
            if (!Created || !IsHandleCreated)
            {
                return;
            }

            if (txtRunState.InvokeRequired)
            {
                BeginInvoke(new Action<PrimRunState>(SetPrimRunState), state);
            }
            else
            {
                switch (state)
                {
                    case PrimRunState.Running:
                        txtRunState.FillColor = Color.LightGreen;
                        txtRunState.Text = PrimRunState.Running.ToString();

                        btnRun.Enabled = false;
                        btnRun.BackColor = Color.Gray;

                        btnStop.Enabled = true;
                        btnStop.BackColor = Color.SandyBrown;
                        break;

                    case PrimRunState.Stop:
                        txtRunState.FillColor = Color.Brown;
                        txtRunState.Text = PrimRunState.Stop.ToString();

                        btnRun.Enabled = true;
                        btnRun.BackColor = Color.SkyBlue;

                        btnStop.Enabled = true;
                        btnStop.BackColor = Color.SandyBrown;
                        break;

                    case PrimRunState.Err:
                        txtRunState.FillColor = Color.SandyBrown;
                        txtRunState.Text = PrimRunState.Err.ToString();

                        btnRun.Enabled = false;
                        btnRun.BackColor = Color.Gray;

                        btnStop.Enabled = false;
                        btnStop.BackColor = Color.Gray;
                        break;

                    case PrimRunState.Idle:
                        txtRunState.FillColor = Color.Khaki;
                        txtRunState.Text = PrimRunState.Idle.ToString();

                        btnRun.Enabled = true;
                        btnRun.BackColor = Color.SkyBlue;

                        btnStop.Enabled = true;
                        btnStop.BackColor = Color.SandyBrown;
                        break;

                    case PrimRunState.Other:
                        txtRunState.FillColor = Color.Khaki;
                        txtRunState.Text = PrimRunState.Other.ToString();

                        btnRun.Enabled = false;
                        btnRun.BackColor = Color.Gray;

                        btnStop.Enabled = false;
                        btnStop.BackColor = Color.Gray;
                        break;
                }
            }
        }
        #endregion
    }
}