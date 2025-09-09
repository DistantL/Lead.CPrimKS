using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Lead.CPrim.ShowAQCI.Controls
{
    /// <summary>输出UI</summary>
    public partial class ShowOutputControl : UserControl
    {
        #region Field
        /// <summary>AQCI管理器</summary>
        private readonly ShowAQCI _show;

        private readonly Dictionary<Guid, Label> _dicLabelsAtPanel = new Dictionary<Guid, Label>();

        private double _sumCt;

        private Dictionary<int, int> dicOK = new Dictionary<int, int>();
        private Dictionary<int, int> dicNG = new Dictionary<int, int>();
        #endregion



        #region Ctor
        /// <summary>Ctor有1个参数</summary>
        /// <param name="show">AQCI管理器</param>
        public ShowOutputControl(ShowAQCI show)
        {
            InitializeComponent();
            _show = show;

            dgvRtData.SetDoubleBuffered();
            List<ChartData> l = new List<ChartData>()
            {
                new ChartData
                {
                    Name = "OK", color = Color.Green
                },
                new ChartData
                {
                    Name = "NG", color = Color.Red
                }
            };

            CustomChart.InitChart(chart1, l, "产能BY Hour");

            for (int i = 0; i < 24; i++)
            {
                if (!dicOK.ContainsKey(i))
                {
                    dicOK.Add(i, 0);
                }
                else
                {
                    dicOK[i] = 0;
                }
                if (!dicNG.ContainsKey(i))
                {
                    dicNG.Add(i, 0);
                }
                else
                {
                    dicNG[i] = 0;
                }
            }
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void ShowOutputControl_Load(object sender, EventArgs e)
        {
            LoadTablePanel();
            LoadProColors();
            LoadPicture(_show.PicFilePath, _show.PicFileName);

            UpdateProductResult(-1);
        }
        #endregion



        #region Button_Event
        /// <summary>清零</summary>
        private void btnClearStatistics_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"你确定要清除当前产能吗?", @"提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                _show.NumOk = 0;
                _show.NumNg = 0;
                _show.NumCount = 0;
                _show.Ct = 0;
                _show.PassRate = 0;
                _sumCt = 0;
                UpdateProductResult(-1);
                ListControlClear();
            }
        }
        /// <summary>颜色切换</summary>
        private void cmbProColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProColor.SelectedItem != null)
            {
                _show.ChangeCurrentProColor(cmbProColor.SelectedItem.ToString());
            }
        }
        /// <summary>清除所有数据</summary>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"确认删除所有数据吗？", @"删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                ListControlClear();
        }
        /// <summary>导出数据</summary>
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "";
            if (!ControlHelper.SaveDgvDataToCsvFile(dgvRtData, true, ref text))
            {
                ProxyTools.Notification.ShowError(text);
                return;
            }

            Notification.ShowInfo("导出成功！！！");
        }
        #endregion



        #region Others
        /// <summary>[ShowConfigControl]调用（界面设计）</summary>
        internal void LoadTablePanel()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(LoadTablePanel));
            }
            else
            {
                tlpMain.ColumnStyles[0].Width = _show.PerCol1;
                tlpMain.ColumnStyles[1].Width = _show.PerCol2;
                tlpMain.ColumnStyles[2].Width = _show.PerCol3;
                tlpMain.RowStyles[0].Height = _show.PerRow1;
                tlpMain.RowStyles[1].Height = _show.PerRow2;
                tlpMain.RowStyles[2].Height = _show.PerRow3;

                if (_show.ShowPic && _show.ShowRtData)
                {
                    tlpMain.Controls.Remove(tbDatas);
                    tlpMain.Controls.Remove(panelProShow);
                    if (!tlpMain.Controls.Contains(tbDatas))
                    {
                        tlpMain.Controls.Add(tbDatas, 0, 1);
                        tlpMain.SetRowSpan(tbDatas, 1);
                    }
                    if (!tlpMain.Controls.Contains(panelProShow))
                    {
                        tlpMain.Controls.Add(panelProShow, 0, 2);
                        tlpMain.SetRowSpan(panelProShow, 1);
                    }
                }
                else if (_show.ShowPic && !_show.ShowRtData)
                {
                    tlpMain.Controls.Remove(tbDatas);
                    tlpMain.Controls.Remove(panelProShow);
                    if (!tlpMain.Controls.Contains(panelProShow))
                    {
                        tlpMain.Controls.Add(panelProShow, 0, 1);
                        tlpMain.SetRowSpan(panelProShow, 2);
                    }
                }
                else if (!_show.ShowPic && _show.ShowRtData)
                {
                    tlpMain.Controls.Remove(tbDatas);
                    tlpMain.Controls.Remove(panelProShow);
                    if (!tlpMain.Controls.Contains(tbDatas))
                    {
                        tlpMain.Controls.Add(tbDatas, 0, 1);
                        tlpMain.SetRowSpan(tbDatas, 2);
                    }
                }
                else if (!_show.ShowPic && !_show.ShowRtData)
                {
                    tlpMain.Controls.Remove(tbDatas);
                    tlpMain.Controls.Remove(panelProShow);
                }
                tlpMain.Refresh();
            }
        }
        /// <summary>[ShowConfigControl]调用（颜色更新）</summary>
        internal void LoadProColors()
        {
            if (cmbProColor.InvokeRequired)
            {
                BeginInvoke(new Action(LoadProColors));
            }
            else
            {
                cmbProColor.Items.Clear();
                if (_show.ProColors != null)
                    foreach (var proColor in _show.ProColors)
                        cmbProColor.Items.Add(proColor);

                if (_show.CurProColor != null)
                {
                    if (!cmbProColor.Items.Contains(_show.CurProColor))
                        cmbProColor.Items.Add(_show.CurProColor);

                    cmbProColor.SelectedItem = _show.CurProColor;
                }
            }
        }
        /// <summary>[ShowConfigControl]调用（加载图片）</summary>
        internal void LoadPicture(string filePath, string fileName)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string, string>(LoadPicture), filePath, fileName);
            }
            else
            {
                if (!_show.ShowPic)
                {
                    return;
                }

                if (!string.IsNullOrEmpty(filePath) && !string.IsNullOrEmpty(fileName) &&
                    File.Exists($@"{filePath}\{fileName}"))
                {
                    panelProShow.BackgroundImage = Image.FromFile($@"{filePath}\{fileName}");
                }
            }
        }
        /// <summary>更新产品结果</summary>
        /// <param name="result">1：OK
        /// <para>0：NG</para>
        /// <para>other：不显示</para></param>
        internal void UpdateProductResult(int result)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<int>(UpdateProductResult), result);
            }
            else
            {
                if (result == 1)
                {
                    lbResult.Text = @"OK";
                    lbResult.ForeColor = Color.Lime;
                }
                else if (result == 0)
                {
                    lbResult.Text = @"NG";
                    lbResult.ForeColor = Color.Red;
                }
                else
                {
                    lbResult.ForeColor = SystemColors.ControlLight;
                    lbResult.Text = @"-";
                }
            }
        }
        /// <summary>更新OK数量</summary>
        /// <param name="value">数量</param>
        internal void UpdateNumOk(double value)
        {
            ControlHelper.SetText(lbOkNum, value.ToString());
        }
        /// <summary>更新NG数量</summary>
        /// <param name="value">数量</param>
        internal void UpdateNumNg(double value)
        {
            ControlHelper.SetText(lbNgNum, value.ToString());
        }
        /// <summary>更新总数量</summary>
        /// <param name="value">数量</param>
        internal void UpdateNumCount(double value)
        {
            ControlHelper.SetText(lbTotalNum, value.ToString());
        }
        /// <summary>更新CT</summary>
        /// <param name="value">CT</param>
        internal void UpdateCt(double value)
        {
            ControlHelper.SetText(lbCt, value.ToString("F2"));
        }
        /// <summary>更新良率</summary>
        /// <param name="value">良率</param>
        internal void UpdatePassRate(double value)
        {
            ControlHelper.SetText(lbPassRate, $@"{value * 100.0:F1}%");
        }
        /// <summary>清除表格数据</summary>
        private void ListControlClear()
        {
            dgvRtData.Rows.Clear();
            dgvRtData.Refresh();
        }
        /// <summary>UI[OperateInstruction]运行状态栏更新</summary>
        /// <param name="sta">内容</param>
        /// <param name="color">颜色</param>
        internal void ChangeUIState(string sta, Color color)
        {
            if (smShow.InvokeRequired)
            {
                BeginInvoke(new Action<string, Color>(ChangeUIState), sta, color);
            }
            else
            {
                smShow.ChangeState(sta, color);
            }
        }
        /// <summary>UI[OperateInstruction]运行提示栏更新</summary>
        /// <param name="msg">内容</param>
        /// <param name="isTwinkle">是否闪烁</param>
        internal void RefreshOperaInfo(string msg, bool isTwinkle)
        {
            if (smShow.InvokeRequired)
            {
                BeginInvoke(new Action<string, bool>(RefreshOperaInfo), msg, isTwinkle);
            }
            else
            {
                smShow.ShowOperaInfo(msg, isTwinkle);
            }
        }
        /// <summary>UI[OperateInstruction]运行模式更新</summary>
        /// <param name="mode">模式</param>
        internal void RefreshOperaMode(string mode)
        {
            if (smShow.InvokeRequired)
                BeginInvoke(new Action<string>(RefreshOperaMode), mode);
            else
                smShow.ShowOperaMode(mode);
        }

        internal void AddFaiByLocation(string faiName, double faiValue, int xPos, int yPos, Font font, Color color)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string, double, int, int, Font, Color>(AddFaiByLocation), faiName, faiValue,
                    xPos, yPos, font, color);
            }
            else
            {
                var findedLabel = false;
                Label lblFaiName = null;
                if (_dicLabelsAtPanel.Count > 0)
                    foreach (var label in _dicLabelsAtPanel)
                        if (label.Value.Location.X == xPos && label.Value.Location.Y == yPos)
                        {
                            findedLabel = true;
                            if (!Equals(label.Value.Font, font)) label.Value.Font = font;

                            if (!Equals(label.Value.ForeColor, color)) label.Value.ForeColor = Color.Black;

                            lblFaiName = label.Value;
                            break;
                        }

                if (_dicLabelsAtPanel.Count == 0 || !findedLabel)
                {
                    var pos = new Point(xPos, yPos);
                    var newLabel = new Label
                    {
                        Text = faiName,
                        Font = font,
                        ForeColor = Color.Black,
                        BackColor = Color.Azure,
                        AutoSize = true,
                        Anchor = AnchorStyles.None,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Location = pos
                    };

                    newLabel.BringToFront();

                    panelProShow.Controls.Add(newLabel);
                    _dicLabelsAtPanel.Add(Guid.NewGuid(), newLabel);

                    lblFaiName = newLabel;
                }

                var findedLabelValue = false;
                foreach (var labelValue in _dicLabelsAtPanel)
                    if (labelValue.Value.Location.X == xPos && labelValue.Value.Location.Y == yPos + lblFaiName.Height)
                    {
                        findedLabelValue = true;
                        if (!Equals(labelValue.Value.Font, font)) labelValue.Value.Font = font;

                        if (!Equals(labelValue.Value.ForeColor, color)) labelValue.Value.ForeColor = color;

                        labelValue.Value.Text = faiValue.ToString("F3");
                        break;
                    }

                if (!findedLabelValue)
                {
                    var pos = new Point(xPos, yPos + lblFaiName.Height);
                    var newLabel = new Label
                    {
                        Text = faiValue.ToString("F3"),
                        Font = font,
                        ForeColor = color,
                        BackColor = Color.Azure,
                        AutoSize = true,
                        Anchor = AnchorStyles.None,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Location = pos
                    };

                    newLabel.BringToFront();

                    panelProShow.Controls.Add(newLabel);
                    _dicLabelsAtPanel.Add(Guid.NewGuid(), newLabel);
                }
            }
        }

        internal void AddMultiPartInfo<T>(List<T> listEntiy, bool saveDataBase, string productName, bool updateStatistic = false, Dictionary<string, bool> results = null) where T : class
        {
            if (dgvRtData.InvokeRequired)
            {
                BeginInvoke(new Action<List<T>, bool, string, bool, Dictionary<string, bool>>(AddMultiPartInfo),
                    listEntiy, saveDataBase, productName, updateStatistic, results);
            }
            else
            {
                if (listEntiy.Count == 0) return;

                if (_show.StationName != null)
                {
                    if (string.IsNullOrEmpty(productName))
                    {
                        productName = "parts";
                    }

                    productName = $@"{_show.StationName}_{productName}";
                }

                var originalRowNum = dgvRtData.RowCount;

                //写入数据库
                if (saveDataBase)
                {
                    if (listEntiy.Count > 1)
                        _ = MongodbHelper.InsertManyAsync(listEntiy, productName);
                    else
                        _ = MongodbHelper.InsertOneAsync(listEntiy[0], productName);
                }

                var propInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var propertyResult = typeof(T).GetProperty("Result");
                var propertyCt = typeof(T).GetProperty("CT");
                var propertyCreateTime = typeof(T).GetProperty("CreateTime");


                var dicColName = new Dictionary<int, string>();
                var columnIndex = 0;

                foreach (var item in propInfo)
                {
                    if (item.PropertyType.Name.Contains("List"))
                    {
                        var listVal = item.GetValue(listEntiy[0], null) as IEnumerable<object>;
                        var i = 1;
                        if (listVal != null)
                        {
                            foreach (var listItem in listVal)
                            {
                                dicColName.Add(columnIndex++, item.Name + i);
                                i++;
                            }
                        }
                    }
                    else if (item.PropertyType.Name.Contains("Dictionary"))
                    {
                        if (item.GetValue(listEntiy[0], null) is IDictionary<object, object> dicVal)
                        {
                            foreach (var dicItem in dicVal)
                            {
                                dicColName.Add(columnIndex++, item.Name + "." + dicItem.Key);
                            }
                        }
                    }
                    else
                    {
                        dicColName.Add(columnIndex++, item.Name);
                    }
                }

                if (dgvRtData.Columns.Count == 0)
                {
                    foreach (var colName in dicColName)
                    {
                        dgvRtData.Columns.Add(colName.Value, colName.Value);
                    }
                }

                foreach (var item in listEntiy)
                {
                    var values = new object[dicColName.Count];
                    foreach (var t in propInfo)
                    {
                        if (t.PropertyType.Name.Contains("List"))
                        {
                            var listVal = t.GetValue(item, null) as IEnumerable<object>;
                            var j = 1;
                            if (listVal == null) continue;
                            foreach (var listItem in listVal)
                            {
                                var colIndex = dicColName.FirstOrDefault(x => x.Value == t.Name + j).Key;
                                values[colIndex] = listItem;
                                j++;
                            }
                        }
                        else if (t.PropertyType.Name.Contains("Dictionary"))
                        {
                            if (!(t.GetValue(item, null) is IDictionary<object, object> dicVal)) continue;
                            foreach (var dicItem in dicVal)
                            {
                                var colIndex = dicColName.FirstOrDefault(x => x.Value == t.Name + "." + dicItem.Key)
                                    .Key;
                                values[colIndex] = dicItem.Value;
                            }
                        }
                        else
                        {
                            var colIndex = dicColName.FirstOrDefault(x => x.Value == t.Name).Key;
                            values[colIndex] = t.GetValue(item, null);
                        }
                    }

                    dgvRtData.Rows.Insert(0, values);

                    if (results != null)
                    {
                        foreach (var fai in results.Keys)
                        {
                            foreach (var col in dicColName)
                            {
                                if (col.Value.Contains("."))
                                {
                                    var colNames = col.Value.Split('.');
                                    if (colNames[1] == fai)
                                    {
                                        dgvRtData.Rows[0].Cells[col.Key].Style.ForeColor = results[fai] ? Color.DarkGreen : Color.Red;
                                    }
                                }
                            }
                        }
                    }
                }


                if (updateStatistic)
                {
                    foreach (var entiy in listEntiy)
                    {
                        if (propertyResult != null)
                        {
                            if (propertyResult.GetValue(entiy).ToString().ToLower() == "ok" || propertyResult.GetValue(entiy).ToString() == "1")
                            {
                                _show.UpdateProduct(1);
                            }
                            else
                            {
                                _show.UpdateProduct(0);
                            }
                        }

                        if (propertyCt != null)
                        {
                            if (double.TryParse(propertyCt.GetValue(entiy).ToString(), out var retCt))
                            {
                                _sumCt += retCt;
                            }
                        }
                    }

                    _show.UpdateCt(_sumCt / _show.NumCount);
                }


                if (propertyResult != null)
                {
                    var resultIndex = -1;
                    foreach (DataGridViewColumn column in dgvRtData.Columns)
                    {
                        if (column.HeaderText == @"Result" || column.HeaderText == @"结果")
                        {
                            resultIndex = column.Index;
                        }
                    }

                    if (resultIndex != -1)
                    {
                        for (var i = 0; i < dgvRtData.Rows.Count; i++)
                        {
                            dgvRtData.Rows[i].Cells[resultIndex].Style.BackColor = dgvRtData.Rows[i].Cells[resultIndex].Value.ToString().ToLower() == "ok" || dgvRtData.Rows[i].Cells[resultIndex].Value.ToString() == "1" ? Color.LawnGreen : Color.Red;
                        }
                    }
                }


                //BY Hour统计
                if (propertyCreateTime != null && propertyResult != null)
                {
                    foreach (var entiy in listEntiy)
                    {
                        DateTime dateTime;
                        if (DateTime.TryParse(propertyCreateTime.GetValue(entiy).ToString(), out dateTime) &&
                            (propertyResult.GetValue(entiy).ToString().ToLower() == "ok" || propertyResult.GetValue(entiy).ToString() == "1"))
                        {
                            dicOK[dateTime.Hour]++;
                        }
                        else
                        {
                            dicNG[dateTime.Hour]++;
                        }
                    }
                    ChartRefresh();
                }
            }
        }

        internal void AddLabelByLocation(string labelName, int xPos, int yPos, Font font, Color color)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string, int, int, Font, Color>(AddLabelByLocation), labelName, xPos, yPos, font,
                    color);
            }
            else
            {
                var finded = false;
                if (_dicLabelsAtPanel.Count > 0)
                    foreach (var label in _dicLabelsAtPanel)
                        if (label.Value.Location.X == xPos && label.Value.Location.Y == yPos)
                        {
                            finded = true;
                            if (!Equals(label.Value.Font, font)) label.Value.Font = font;

                            if (!Equals(label.Value.ForeColor, color)) label.Value.ForeColor = color;
                        }

                if (_dicLabelsAtPanel.Count == 0 || !finded)
                {
                    var pos = new Point(xPos, yPos);
                    var newLabel = new Label
                    {
                        Text = labelName,
                        Font = font,
                        ForeColor = color,
                        AutoSize = true,
                        Anchor = AnchorStyles.None,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Location = pos
                    };

                    newLabel.BringToFront();

                    panelProShow.Controls.Add(newLabel);
                    _dicLabelsAtPanel.Add(Guid.NewGuid(), newLabel);
                }
            }
        }



        internal void ClearPicture()
        {
            if (InvokeRequired)
                BeginInvoke(new Action(ClearPicture));
            else
                panelProShow.BackgroundImage = null;
        }

        private void panelProShow_MouseDown(object sender, MouseEventArgs e)
        {
            if (panelProShow.Controls["Location"] == null)
            {
                var lbl = new Label { Name = "Location", Text = $"X:{e.X},Y:{e.Y}" };
                lbl.Location = new Point { X = 10, Y = panelProShow.Height - lbl.Height };
                panelProShow.Controls.Add(lbl);
            }
            else
            {
                panelProShow.Controls["Location"].Text = $"X:{e.X},Y:{e.Y}";
            }
        }

        internal void ClearLabels()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(ClearLabels));
            }
            else
            {
                foreach (var dicLabel in _dicLabelsAtPanel) panelProShow.Controls.Remove(dicLabel.Value);
                _dicLabelsAtPanel.Clear();
            }
        }

        internal void UpdateProductType(string value)
        {
            ControlHelper.SetText(lbProType, value);
        }

        internal void UpdateBarCode(string value)
        {
            ControlHelper.SetText(tbBarCode, value);
        }
        /// <summary>BY Hour统计刷新</summary>
        private void ChartRefresh()
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            for (int i = 0; i < 24; i++)
            {
                chart1.Series[0].Points.AddXY(i, dicOK[i]);
                chart1.Series[0].Points.AddXY(i, dicNG[i]);
            }
        }
        #endregion
    }
}