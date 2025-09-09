using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Lead.CPrim.Interfaces.Dev;


namespace Lead.CPrim.PrimKeyencePLC
{
    public delegate void UpdateRevMag(string msg);

    public partial class PrimConfigControl : UIUserControl
    {
        #region Field
        /// <summary></summary>
        private readonly PrimKeyencePLC _PrimKeyencePLC;
        #endregion



        #region Prop
        /// <summary>基元名称</summary>
        public string PrimKeyencePLCName
        {
            set => txtName.Text = value;
        }
        #endregion



        #region Ctor
        public PrimConfigControl()
        {
            InitializeComponent();
            InitializeUI();
            string[] dataType = Enum.GetNames(typeof(ProtocolDataType));
            dataType.ToList().ForEach(type => colType.Items.Add(type));
            string[] dataPermission = Enum.GetNames(typeof(DataPermission));
            dataPermission.ToList().ForEach(permission => colPermission.Items.Add(permission));
            string[] dataReadMode = Enum.GetNames(typeof(DataReadMode));
            dataReadMode.ToList().ForEach(mode => colReadMode.Items.Add(mode));

            string[] dataPLCByteSoftType = Enum.GetNames(typeof(PLCByteSoftType));
            dataPLCByteSoftType.ToList().ForEach(mode => dgvColAddressType.Items.Add(mode));

            dgvDataConfig.SetDoubleBuffered();
            tlpTitle.SetDoubleBuffered();
            dgvDataConfig.RowHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Font = new Font("微软雅黑", 7.5f, FontStyle.Regular),
            };
            SetStyleFlags();

            pnl1.SetStyle(default, Color.FromArgb(211, 211, 211));
            pnl4.SetStyle(default, Color.FromArgb(211, 211, 211));
            FillColor = SystemColors.Control;
            txtName.SetStyle(Color.OldLace, default);
            txtConnState.SetStyle(Color.Khaki, default);
            txtRunState.SetStyle(Color.Khaki, default);

        }
        public PrimConfigControl(PrimKeyencePLC prim) : this()
        {
            _PrimKeyencePLC = prim;
        }
        #endregion



        #region Button_Event
        /// <summary>增加一行</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            var index = dgvDataConfig.Rows.Add();
            dgvDataConfig.Rows[index].Cells[1].Value = ProtocolDataType.STRING.ToString();
            dgvDataConfig.Rows[index].Cells[5].Value = DataPermission.RW.ToString();
            dgvDataConfig.Rows[index].Cells[8].Value = DataReadMode.Cycle.ToString();
            dgvDataConfig.Rows[index].Cells[9].Value = true;
            dgvDataConfig.Refresh();
        }
        /// <summary>删除一行</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelRow_Click(object sender, EventArgs e)
        {
            if (dgvDataConfig.Rows.Count <= 0) return;

            var _curSelectedIdx = dgvDataConfig.CurrentCell.RowIndex;
            dgvDataConfig.Rows.RemoveAt(_curSelectedIdx);
        }
        /// <summary>打开数据</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTableBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                if (_PrimKeyencePLC.PrimRunStat == PrimRunState.Running)
                {
                    throw new Exception("请停止运行后操作");
                }
                string path = tBoxTableDataPath.Text;
                if (FileHelper.OpenFileDialogMethod(ref path))
                {
                    tBoxTableDataPath.Text = path;
                }
                _PrimKeyencePLC.ImportDataTable(path);
                DataTableUpdate();
                dgvDataConfig.Refresh();
                _PrimKeyencePLC.LogAdd($"打开文件成功", LogLevel.Info);
            }
            catch (Exception ex)
            {
                _PrimKeyencePLC.LogAdd($"打开文件失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        /// <summary>数据保存</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTableSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                if (_PrimKeyencePLC.PrimRunStat == PrimRunState.Running)
                {
                    throw new Exception("请停止运行后操作");
                }
                string path = tBoxTableDataPath.Text;
                if (!FileHelper.SaveFileDialogMethod("", FilterType.XML, DefaultExt.XML, true, false, true, ref path))
                {
                    return;
                }
                if (SaveData(path))
                {
                    tBoxTableDataPath.Text = path;
                    _PrimKeyencePLC.LogAdd($"保存文件成功", LogLevel.Info);
                }
                else
                {
                    _PrimKeyencePLC.LogAdd($"保存文件失败：写入本地失败", LogLevel.Warn, 0, true);
                }
            }
            catch (Exception ex)
            {
                _PrimKeyencePLC.LogAdd($"保存文件失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        /// <summary>数据保存</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfigApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (_PrimKeyencePLC.PrimRunStat == PrimRunState.Running)
                {
                    throw new Exception("请停止运行后操作");
                }
                if (!AuthorityManager.Instance.VerifyLevel3Permission(true))
                {
                    return;
                }
                string errorText = "";
                if (ControlHelper.CheckDgvCellRepeat(dgvDataConfig, ref errorText, 0))
                {
                    errorText = "第1列重复 -> " + errorText;
                    throw new Exception(errorText);
                }
                if (ControlHelper.CheckDgvCellRepeat(dgvDataConfig, ref errorText, 3))
                {
                    errorText = "第4列重复 -> " + errorText;
                    throw new Exception(errorText);
                }
                string path = tBoxTableDataPath.Text;
                if (string.IsNullOrEmpty(path))
                {
                    throw new Exception("保存路径为空");
                }

                if (SaveData(path))
                {
                    _PrimKeyencePLC.LogAdd($"数据保存成功", LogLevel.Info);
                }
                else
                {
                    _PrimKeyencePLC.LogAdd($"数据保存失败：写入本地失败", LogLevel.Warn, 0, true);
                }
            }
            catch (Exception ex)
            {
                _PrimKeyencePLC.LogAdd($"应用失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }

        /// <summary>初始化</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInit_Click(object sender, EventArgs e)
        {
            try
            {
                _PrimKeyencePLC.IPrimInit();
                string result = "";
                _PrimKeyencePLC.IPrimConnect(ref result);
            }
            catch (Exception ex)
            {
                _PrimKeyencePLC.LogAdd($"连接失败：{ex.Message}", LogLevel.Warn);
            }
        }
        /// <summary>运行</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                _PrimKeyencePLC.IPrimStart();
            }
            catch (Exception ex)
            {
                _PrimKeyencePLC.LogAdd($"运行失败：{ex.Message}", LogLevel.Warn);
            }
        }
        /// <summary>停止</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                _PrimKeyencePLC.IPrimStop();
            }
            catch (Exception ex)
            {
                _PrimKeyencePLC.LogAdd($"停止失败：{ex.Message}", LogLevel.Warn);
            }
        }
        /// <summary>应用</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
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
                        throw new Exception("重连次数1-3");
                    }
                }
                else
                {
                    throw new Exception("重连次数无效");
                }
                if (int.TryParse(tBoxCycleTime.Text, out cycleTime))
                {
                    if (!(cycleTime >= 5 && cycleTime <= 10))
                    {
                        throw new Exception("循环时间5-10");
                    }
                }
                else
                {
                    throw new Exception("循环时间无效");
                }
                _PrimKeyencePLC.ReconnectCnt = reconnect;
                _PrimKeyencePLC.CycleTime = cycleTime;

                if (!string.IsNullOrEmpty(tBoxPort.Text)) _PrimKeyencePLC.Port = tBoxPort.Text;
                if (!string.IsNullOrEmpty(tBoxIP.Text)) _PrimKeyencePLC.IP = tBoxIP.Text;
                _PrimKeyencePLC.Name = txtName.Text;
                _PrimKeyencePLC.LogEnable = cbLogEnable.Checked;
                _PrimKeyencePLC.DataTablePath = tBoxTableDataPath.Text;
                _PrimKeyencePLC.LogAdd($"应用成功", LogLevel.Info, 0);
            }
            catch (Exception ex)
            {
                _PrimKeyencePLC.LogAdd($"应用失败：{ex.Message}", LogLevel.Warn, 0, true);
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
        private void 导出CSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string errorText = "";
            if (!ControlHelper.SaveDgvDataToCsvFile(dgvDataConfig, true, ref errorText))
            {
                _PrimKeyencePLC.LogAdd($"CSV导出失败:{errorText}", LogLevel.Warn);
            }
        }
        /// <summary>导入CSV</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 导入CSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PlcDataConfigs finsConfigs = new PlcDataConfigs();
                string path = "";
                if (!FileHelper.OpenFileDialogMethod("", FilterType.CSV, false, ref path))
                {
                    return;
                }
                List<string> ls = new List<string>();
                if (CsvHelper.ReadCsvToListString(path, Encoding.Default, true, out ls))
                {
                    foreach (var item in ls)
                    {
                        string[] re = item.Split(',');
                        if (re.Length < 10)
                        {
                            throw new Exception("CSV格式有误");
                        }
                        PlcDataConfig finsConfig = new PlcDataConfig();
                        finsConfig.DtName = re[0];
                        finsConfig.DtType = DataHelper.StringToProtocolDataType(re[1]);
                        finsConfig.DtLength = ushort.TryParse(re[2], out var length) ? length : throw new Exception("数据长度无效");
                        finsConfig.DtAddress = re[3];
                        finsConfig.DtPermission = DataHelper.StringToPermission(re[4]);
                        finsConfig.DtRdMode = DataHelper.StringToDataReadMode(re[7]);
                        finsConfig.DtIsNotify = bool.TryParse(re[8], out var notify) ? notify : throw new Exception("事件通知无效");
                        finsConfigs.ListDataConfig.Add(finsConfig);
                    }

                    _PrimKeyencePLC.DataConfigs.ListDataConfig.Clear();
                    _PrimKeyencePLC.DataConfigs = finsConfigs.CopyClass();
                    DataTableUpdate();
                }
                else
                {
                    throw new Exception("CSV读取失败");
                }
            }
            catch (Exception ex)
            {
                _PrimKeyencePLC.LogAdd($"导入CSV失败：{ex.Message}", LogLevel.Warn);
            }
        }
        /// <summary>导出代码</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 导出代码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "";
                if (!FileHelper.SaveFileDialogMethod("", FilterType.CS, DefaultExt.CS, true, false, true, ref path))
                {
                    return;
                }

                //接收事件
                {
                    StringBuilder text = new StringBuilder();
                    text.Append("private void ReceivedFromPlc(string valName, string valAddr, string valType, object valLast, object valCur)\n");
                    text.Append("{\n");
                    text.Append("\tswitch (valName)\n");
                    text.Append("\t{\n");
                    foreach (var item in _PrimKeyencePLC.DataConfigs.ListDataConfig)
                    {
                        if (item.DtPermission != DataPermission.R)
                        {
                            continue;
                        }
                        text.Append("\t\tcase \"");
                        text.Append(item.DtName);
                        text.Append("\":\n");
                        text.Append("\t\t\t_receivedFromPlc.");
                        text.Append(item.DtName);
                        text.Append(" = ");
                        if (item.DtType != ProtocolDataType.STRING)
                        {
                            switch (item.DtType)
                            {
                                case ProtocolDataType.SHORT:
                                    text.Append("short");
                                    break;
                                case ProtocolDataType.INT:
                                    text.Append("int");
                                    break;
                                case ProtocolDataType.LONG:
                                    text.Append("long");
                                    break;
                                case ProtocolDataType.FLOAT:
                                    text.Append("float");
                                    break;
                                case ProtocolDataType.USHORT:
                                    text.Append("ushort");
                                    break;
                                case ProtocolDataType.UINT:
                                    text.Append("uint");
                                    break;
                                case ProtocolDataType.ULONG:
                                    text.Append("ulong");
                                    break;
                                case ProtocolDataType.DOUBLE:
                                    text.Append("double");
                                    break;
                                case ProtocolDataType.BOOL:
                                    text.Append("bool");
                                    break;
                                case ProtocolDataType.STRING:
                                    text.Append("string");
                                    break;
                                case ProtocolDataType.OTHER:
                                    text.Append("other");
                                    break;
                                default:
                                    break;
                            }
                            text.Append(".Parse(valCur.ToString());\n\n");
                        }
                        else
                        {
                            text.Append("valCur.ToString();\n\n");
                        }
                        text.Append("\t\t\tbreak;\n\n");
                    }
                    text.Append("\t\tdefault:\n");
                    text.Append("\t\t\tbreak;\n");
                    text.Append("\t}\n");
                    text.Append("}");
                    DataHelper.WriteFile(path, text.ToString());
                }

                //变量读取
                {
                    StringBuilder text = new StringBuilder();
                    text.Append("private void ReadFromPlc(string valName)\n{\n");
                    text.Append("\tobject valCur = _iPlc.ReadVariableFromName(valName);\n");
                    text.Append("\tswitch (valName)\n\t{\n");
                    foreach (var item in _PrimKeyencePLC.DataConfigs.ListDataConfig)
                    {
                        text.Append($"\t\tcase \"{item.DtName}\":\n");
                        if (item.DtPermission == DataPermission.R)
                        {
                            text.Append($"\t\t\t_receivedFromPlc.{item.DtName} = ");
                        }
                        else
                        {
                            text.Append($"\t\t\t_sendToPlc.{item.DtName} = ");
                        }
                        if (item.DtType != ProtocolDataType.STRING)
                        {
                            switch (item.DtType)
                            {
                                case ProtocolDataType.SHORT:
                                    text.Append("short");
                                    break;
                                case ProtocolDataType.INT:
                                    text.Append("int");
                                    break;
                                case ProtocolDataType.LONG:
                                    text.Append("long");
                                    break;
                                case ProtocolDataType.FLOAT:
                                    text.Append("float");
                                    break;
                                case ProtocolDataType.USHORT:
                                    text.Append("ushort");
                                    break;
                                case ProtocolDataType.UINT:
                                    text.Append("uint");
                                    break;
                                case ProtocolDataType.ULONG:
                                    text.Append("ulong");
                                    break;
                                case ProtocolDataType.DOUBLE:
                                    text.Append("double");
                                    break;
                                case ProtocolDataType.BOOL:
                                    text.Append("bool");
                                    break;
                                case ProtocolDataType.STRING:
                                    text.Append("string");
                                    break;
                                case ProtocolDataType.OTHER:
                                    text.Append("other");
                                    break;
                                default:
                                    break;
                            }
                            text.Append(".Parse(valCur.ToString());\n\n");
                        }
                        else
                        {
                            text.Append("valCur.ToString();\n\n");
                        }
                        text.Append("\t\t\tbreak;\n\n");
                    }
                    text.Append("\t\tdefault:\n");
                    text.Append("\t\t\tbreak;\n");
                    text.Append("\t}\n");
                    text.Append("}\n");
                    DataHelper.WriteFile(path, text.ToString());
                }

                //数据结构
                {
                    StringBuilder builderType = new StringBuilder();
                    StringBuilder textRead = new StringBuilder();
                    StringBuilder textWrite = new StringBuilder();
                    //string
                    textRead.Append("private PlcToPc _receivedFromPlc = new PlcToPc();\n");
                    textRead.Append("private PcToPlc _sendToPlc = new PcToPlc();\n");
                    textRead.Append("public class PlcToPc\n");
                    textRead.Append("{\n");
                    textWrite.Append("public class PcToPlc\n");
                    textWrite.Append("{\n");
                    foreach (var item in _PrimKeyencePLC.DataConfigs.ListDataConfig)
                    {
                        builderType.Clear();
                        if (item.DtPermission == DataPermission.R)
                        {
                            textRead.Append("\t");
                            textRead.Append("public ");
                        }
                        else
                        {
                            textWrite.Append("\t");
                            textWrite.Append("public ");
                        }
                        switch (item.DtType)
                        {
                            case ProtocolDataType.SHORT:
                                builderType.Append("short");
                                break;
                            case ProtocolDataType.INT:
                                builderType.Append("int");
                                break;
                            case ProtocolDataType.LONG:
                                builderType.Append("long");
                                break;
                            case ProtocolDataType.FLOAT:
                                builderType.Append("float");
                                break;
                            case ProtocolDataType.USHORT:
                                builderType.Append("ushort");
                                break;
                            case ProtocolDataType.UINT:
                                builderType.Append("uint");
                                break;
                            case ProtocolDataType.ULONG:
                                builderType.Append("ulong");
                                break;
                            case ProtocolDataType.DOUBLE:
                                builderType.Append("double");
                                break;
                            case ProtocolDataType.BOOL:
                                builderType.Append("bool");
                                break;
                            case ProtocolDataType.STRING:
                                builderType.Append("string");
                                break;
                            case ProtocolDataType.OTHER:
                                builderType.Append("other");
                                break;
                            default:
                                break;
                        }
                        if (item.DtPermission == DataPermission.R)
                        {
                            textRead.Append(builderType.ToString());
                            textRead.Append($" {item.DtName}");
                            textRead.Append(" { get; set; }\n");
                        }
                        else
                        {
                            textWrite.Append(builderType.ToString());
                            textWrite.Append($" {item.DtName}");
                            textWrite.Append(" { get; set; }\n");
                        }
                    }
                    textRead.Append("}");
                    textWrite.Append("}");
                    DataHelper.WriteFile(path, textRead.ToString());
                    DataHelper.WriteFile(path, textWrite.ToString());
                }

                //枚举结构
                {
                    StringBuilder textRead = new StringBuilder();
                    StringBuilder textWrite = new StringBuilder();
                    textRead.Append("public enum PlcToPcEnum\n{\n");
                    textWrite.Append("public enum PcToPlcEnum\n{\n");
                    foreach (var item in _PrimKeyencePLC.DataConfigs.ListDataConfig)
                    {
                        if (item.DtPermission == DataPermission.R)
                        {
                            textRead.Append($"\t{item.DtName},\n");
                        }
                        else
                        {
                            textWrite.Append($"\t{item.DtName},\n");
                        }
                    }
                    textRead.Append("}");
                    textWrite.Append("}\n");
                    DataHelper.WriteFile(path, textRead.ToString());
                    DataHelper.WriteFile(path, textWrite.ToString());
                }

                _PrimKeyencePLC.LogAdd($"导出代码成功", LogLevel.Info);
            }
            catch (Exception ex)
            {
                _PrimKeyencePLC.LogAdd($"导出代码失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        /// <summary>清空</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvDataConfig.Rows.Clear();
            dgvDataConfig.Refresh();
            _PrimKeyencePLC.DataConfigs = new PlcDataConfigs();
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrimConfigControl_Load(object sender, EventArgs e)
        {
            PrimKeyencePLCName = _PrimKeyencePLC.Name;
            tBoxIP.Text = _PrimKeyencePLC.IP;
            tBoxPort.Text = _PrimKeyencePLC.Port;
            tBoxCycleTime.Text = _PrimKeyencePLC.CycleTime.ToString();
            tBoxReConnCnt.Text = _PrimKeyencePLC.ReconnectCnt.ToString();
            tBoxTableDataPath.Text = _PrimKeyencePLC.DataTablePath;
            tBoxTableDataPath.Text = _PrimKeyencePLC.DataTablePath;
            cbLogEnable.Checked = _PrimKeyencePLC.LogEnable;
            DataTableUpdate();
            SetPrimConnState(_PrimKeyencePLC.PrimConnStat);
            SetPrimRunState(_PrimKeyencePLC.PrimRunStat);
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
            if (dgvDataConfig.Rows[rowIndex].Cells[1].Value.ToString() == "STRING")
            {
                dgvDataConfig.Rows[rowIndex].Cells[2].ReadOnly = false;
                dgvDataConfig.Rows[rowIndex].Cells[2].Style.BackColor = Color.White;
            }
            else
            {
                dgvDataConfig.Rows[rowIndex].Cells[2].Value = 0;
                dgvDataConfig.Rows[rowIndex].Cells[2].ReadOnly = true;
                dgvDataConfig.Rows[rowIndex].Cells[2].Style.BackColor = Color.DarkGray;
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
                _PrimKeyencePLC.LogAdd($"数据表报错：{ex.Message}", LogLevel.Warn);
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
            if (_PrimKeyencePLC.PrimRunStat != PrimRunState.Running)
            {
                return;
            }
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            if (columnIndex >= 0 && rowIndex >= 0 && !string.IsNullOrEmpty(dgvDataConfig.Rows[rowIndex].Cells[0].Value?.ToString()) && columnIndex == 10)
            {
                if (string.IsNullOrEmpty(dgvDataConfig.Rows[rowIndex].Cells[6].Value?.ToString()))
                {
                    return;
                }
                string name = dgvDataConfig.Rows[rowIndex].Cells[0].Value.ToString();
                string value = dgvDataConfig.Rows[rowIndex].Cells[6].Value.ToString();
                _PrimKeyencePLC.WriteVariableFromName(name, value);
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



        #region Method_ExternalUsing

        /// <summary>
        /// 设置CycleTime
        /// </summary>
        /// <param name="value"></param>
        internal void SetCycleTime(double value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<double>(SetCycleTime), new object[1] { value });
            }
            else
            {
                lblCycleTime.Text = value.ToString();
            }
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
                _PrimKeyencePLC.DataConfigs = new PlcDataConfigs();
            }
            else
            {
                if (_PrimKeyencePLC.DataConfigs?.ListDataConfig == null)
                {
                    _PrimKeyencePLC.DataConfigs = new PlcDataConfigs();
                }
                _PrimKeyencePLC.DataConfigs.ListDataConfig.Clear();
                for (var i = 0; i < rowCount; i++)
                {
                    var dtConfig = new PlcDataConfig();

                    dtConfig.DtName = string.IsNullOrEmpty(dgvDataConfig.Rows[i].Cells[0].Value?.ToString()) ? throw new Exception("名称为空") : dgvDataConfig.Rows[i].Cells[0].Value.ToString();
                    dtConfig.DtType = string.IsNullOrEmpty(dgvDataConfig.Rows[i].Cells[1].Value?.ToString()) ? throw new Exception("数据类型为空") : DataHelper.StringToProtocolDataType(dgvDataConfig.Rows[i].Cells[1].Value.ToString());
                    dtConfig.DtLength = ushort.TryParse(dgvDataConfig.Rows[i].Cells[2].Value?.ToString(), out var length) ? length : throw new Exception("数据长度格式无效");
                    dtConfig.DtAddressType = Enum.TryParse(dgvDataConfig.Rows[i].Cells[3].Value.ToString(), out PLCByteSoftType type) ? type : throw new Exception("数据类型为空");
                    dtConfig.DtAddress = string.IsNullOrEmpty(dgvDataConfig.Rows[i].Cells[4].Value?.ToString()) ? throw new Exception("地址为空") : dgvDataConfig.Rows[i].Cells[4].Value.ToString();
                    dtConfig.DtPermission = string.IsNullOrEmpty(dgvDataConfig.Rows[i].Cells[5].Value?.ToString()) ? throw new Exception("读写权限为空") :
                            DataHelper.StringToPermission(dgvDataConfig.Rows[i].Cells[5].Value.ToString());
                    dtConfig.DtRdMode = string.IsNullOrEmpty(dgvDataConfig.Rows[i].Cells[8].Value?.ToString()) ? throw new Exception("数据读取模式为空") : DataHelper.StringToDataReadMode(dgvDataConfig.Rows[i].Cells[8].Value.ToString());
                    dtConfig.DtIsNotify = string.IsNullOrEmpty(dgvDataConfig.Rows[i].Cells[9].Value?.ToString()) ? throw new Exception("事件通知为空") : (bool)dgvDataConfig.Rows[i].Cells[9].Value;

                    _PrimKeyencePLC.DataConfigs.ListDataConfig.Add(dtConfig);
                }
            }
            return _PrimKeyencePLC.ExportDataTable(path) == 0;
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
                if (string.IsNullOrEmpty(dgvDataConfig.Rows[i].Cells[0].Value?.ToString()))
                {
                    continue;
                }
                string name = dgvDataConfig.Rows[i].Cells[0].Value.ToString();
                PlcDataConfig con = _PrimKeyencePLC.DataConfigs.ListDataConfig.FirstOrDefault(config => config.DtName == name);
                if (con == null)
                {
                    continue;
                }
                string result = con.DtCurrentValue.ToString();
                dgvDataConfig.Rows[i].Cells[7].Value = result;
            }
        }
        /// <summary>将集合加载到DGV</summary>
        private void DataTableUpdate()
        {
            if (_PrimKeyencePLC?.DataConfigs?.ListDataConfig == null || _PrimKeyencePLC.DataConfigs.ListDataConfig.Count <= 0)
            {
                _PrimKeyencePLC.DataConfigs = new PlcDataConfigs();
            }
            dgvDataConfig.Rows.Clear();
            foreach (var config in _PrimKeyencePLC.DataConfigs.ListDataConfig)
            {
                var index = dgvDataConfig.Rows.Add();
                dgvDataConfig.Rows[index].Cells[0].Value = config.DtName;
                dgvDataConfig.Rows[index].Cells[1].Value = config.DtType.ToString();
                dgvDataConfig.Rows[index].Cells[2].Value = config.DtLength.ToString();
                dgvDataConfig.Rows[index].Cells[3].Value = config.DtAddressType.ToString();
                dgvDataConfig.Rows[index].Cells[4].Value = config.DtAddress;
                dgvDataConfig.Rows[index].Cells[5].Value = config.DtPermission.ToString();
                dgvDataConfig.Rows[index].Cells[8].Value = config.DtRdMode.ToString();
                dgvDataConfig.Rows[index].Cells[9].Value = config.DtIsNotify;
            }
        }
        /// <summary>中英转换</summary>
        private void InitializeUI()
        {
            lbTitle.Text = NLocalizer.GetString("PrimKeyencePLC_PrimConfigControl_FinsNetConfig", "PrimKeyencePLC Config");
            lblTaskBoxName.Text = NLocalizer.GetString("PrimKeyencePLC_PrimConfigControl_KeyencePLCName", "PrimKeyencePLC Name");
            tabPage1.Text = NLocalizer.GetString("PrimKeyencePLC_PrimConfigControl_Config", "Config");
            tabPage2.Text = NLocalizer.GetString("PrimKeyencePLC_PrimConfigControl_Data", "Data");

            label2.Text = NLocalizer.GetString("PrimKeyencePLC_PrimConfigControl_IPAddress", "IP:");
            label3.Text = NLocalizer.GetString("PrimKeyencePLC_PrimConfigControl_PortNumber", "Port:");
        }
        #endregion

        #region 框架内
        /// <summary>连接状态设置</summary>
        /// <param name="state">连接状态</param>
        public void SetPrimConnState(PrimConnState state)
        {
            if (!Created || !IsHandleCreated)
            {
                return;
            }
            if (InvokeRequired)
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
                        txtConnState.Text = "UnConnected";
                        btnInit.BackColor = Color.SkyBlue;
                        btnInit.Enabled = true;
                        btnRun.BackColor = Color.Gray;
                        btnRun.Enabled = false;
                        break;
                    case PrimConnState.Connected:
                        txtConnState.FillColor = Color.LightGreen;
                        txtConnState.Text = "Connected";
                        btnInit.BackColor = Color.Gray;
                        btnInit.Enabled = false;
                        btnRun.BackColor = Color.SkyBlue;
                        btnRun.Enabled = true;
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

            if (InvokeRequired)
            {
                BeginInvoke(new Action<PrimRunState>(SetPrimRunState), state);
            }
            else
            {
                switch (state)
                {
                    case PrimRunState.Idle:
                        txtRunState.FillColor = Color.Khaki;
                        txtRunState.Text = "Idle";
                        break;
                    case PrimRunState.Running:
                        txtRunState.FillColor = Color.LightGreen;
                        txtRunState.Text = "Running";

                        btnRun.BackColor = Color.Gray;
                        btnRun.Enabled = false;
                        btnInit.BackColor = Color.Gray;
                        btnInit.Enabled = false;
                        btnStop.Enabled = true;
                        btnStop.BackColor = Color.SandyBrown;
                        break;
                    case PrimRunState.Stop:
                        txtRunState.FillColor = Color.Brown;
                        txtRunState.Text = "Stop";

                        btnInit.BackColor = Color.LightGreen;
                        btnInit.Enabled = true;
                        btnRun.BackColor = Color.Gray;
                        btnRun.Enabled = false;
                        btnStop.Enabled = false;
                        btnStop.BackColor = Color.Gray;
                        break;
                    case PrimRunState.Err:
                        txtRunState.FillColor = Color.SandyBrown;
                        txtRunState.Text = "Err";

                        btnStop.Enabled = true;
                        btnStop.BackColor = Color.SandyBrown;
                        break;
                    case PrimRunState.Other:
                        txtRunState.FillColor = Color.Khaki;
                        txtRunState.Text = "Idle";

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