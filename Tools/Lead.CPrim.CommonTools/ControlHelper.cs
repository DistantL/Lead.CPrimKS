/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ControlHelper.cs
 * Author: Victor
 * Description: 控件帮助类
 * CreateTime: 2023-1-9
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.23.0101><Victor><20230109>
 * 1、Convert.ToDateTime(val).ToString("yyyy/MM/dd HH:mm:ss.fff"))不会造成毫秒丢失，DateTime.TryParse(val.ToString(), out var time)和val.ToString("yyyy/MM/dd HH:mm:ss.fff")会造成毫秒丢失
******************************************************************************/

using Lead.CPrim.Interfaces;
using Microsoft.VisualBasic;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lead.CPrim.CommonTools
{
    /// <summary>ControlHelper（支持各种控件处理）
    /// <para>Label标签Text更新 => ChangeLabelText</para>
    /// <para>Button按钮Text更新 => ChangeButtonText</para>
    /// <para>TextBox文本框Text更新 => ChangeTextBoxText</para>
    /// <para>Form标题Text更新 => ChangeFormText</para>
    /// <para></para>
    /// <para></para>
    /// <para></para>
    /// <para>Button按钮Enable更新 => ChangeButtonEnableStatus</para>
    /// <para></para>
    /// <para>Button按钮BackColor更新 => ChangeButtonBackColor</para>
    /// <para>Label标签BackColor更新 => ChangeLabelBackColor</para>
    /// <para></para>
    /// <para>DataGridView表格保存至本地CSV => SaveDgvDataToCsvFile</para>
    /// <para>检查DataGridView指定列是否有重复值 => CheckDgvCellRepeat</para>
    /// <para>单行上移一行 => DgvUpRow</para>
    /// <para>单行下移一行 => DgvDownRow</para>
    /// <para>多行上移一行 => DgvUpRows</para>
    /// <para>多行下移一行 => DgvDownRows</para>
    /// <para></para>
    /// <para>FlowLayoutPanel移除指定控件 || 所有控件 => RemoveControl</para>
    /// <para>FlowLayoutPanel增加指定控件 => AddControl</para>
    /// </summary>
    public class ControlHelper
    {
        //Text更新
        [Obsolete]
        private delegate bool ChangeLabelTextDelegate(ref Label targetLabel, string targetText);
        [Obsolete]
        public static bool ChangeLabelText(ref Label targetLabel, string targetText)
        {
            try
            {
                if (targetLabel == null)
                {
                    return false;
                }
                if (targetLabel.InvokeRequired)
                {
                    ChangeLabelTextDelegate method = ChangeLabelText;
                    targetLabel.Invoke(method, targetLabel, targetText);
                    return true;
                }
                targetLabel.Text = targetText;
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>Label标签Text更新</summary>
        /// <param name="targetLabel">Label</param>
        /// <param name="targetText">更新内容</param>
        /// <param name="ver">版本</param>
        /// <returns>bool</returns>
        public static bool ChangeLabelText(Label targetLabel, string targetText, string ver = "1.0")
        {
            try
            {
                if (targetLabel == null) return false;

                if (targetLabel.InvokeRequired)
                {
                    targetLabel.Invoke(new Func<Label, string, string, bool>(ChangeLabelText), targetLabel, targetText, ver);
                    return true;
                }
                targetLabel.Text = targetText;
                return true;
            }
            catch
            {
                return false;
            }
        }


        [Obsolete]
        private delegate bool ChangeButtonTextDelegate(ref Button targetControl, string targetText);
        [Obsolete]
        public static bool ChangeButtonText(ref Button targetControl, string text)
        {
            try
            {
                if (targetControl == null)
                {
                    return false;
                }
                if (targetControl.InvokeRequired)
                {
                    ChangeButtonTextDelegate method = ChangeButtonText;
                    targetControl.Invoke(method, targetControl, text);
                    return true;
                }
                targetControl.Text = text;
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>Button按钮Text更新</summary>
        /// <param name="targetControl">Button</param>
        /// <param name="text">更新内容</param>
        /// <param name="ver">版本</param>
        /// <returns>bool</returns>
        public static bool ChangeButtonText(Button targetControl, string text, string ver = "1.0")
        {
            try
            {
                if (targetControl == null)
                {
                    return false;
                }

                if (targetControl.InvokeRequired)
                {
                    targetControl.Invoke(new Func<Button, string, string, bool>(ChangeButtonText), targetControl, text, ver);
                }
                else
                {
                    targetControl.Text = text;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }


        [Obsolete]
        private delegate bool ChangeTextBoxTextDelegate(ref TextBox targetTextBox, string targetText);
        [Obsolete]
        public static bool ChangeTextBoxText(ref TextBox targetTextBox, string targetText)
        {
            try
            {
                if (targetTextBox == null)
                {
                    return false;
                }
                if (targetTextBox.InvokeRequired)
                {
                    ChangeTextBoxTextDelegate method = ChangeTextBoxText;
                    targetTextBox.Invoke(method, targetTextBox, targetText);
                    return true;
                }
                targetTextBox.Text = targetText;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>Form标题Text更新</summary>
        /// <param name="form">Form</param>
        /// <param name="targetText">更新内容</param>
        /// <returns>bool</returns>
        public static bool ChangeFormText(Form form, string targetText)
        {
            try
            {
                if (form.InvokeRequired)
                {
                    form.Invoke(new Func<Form, string, bool>(ChangeFormText), form, targetText);
                }
                else
                {
                    form.Text = targetText;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }




        //Enable更新
        [Obsolete]
        private delegate bool ChangeButtonEnableStatusDelegate(ref Button targetControl, bool targetEnabledStatus);
        [Obsolete]
        public static bool ChangeButtonEnableStatus(ref Button targetControl, bool targetEnabledStatus)
        {
            try
            {
                if (targetControl == null)
                {
                    return false;
                }
                if (targetControl.InvokeRequired)
                {
                    ChangeButtonEnableStatusDelegate method = ChangeButtonEnableStatus;
                    targetControl.Invoke(method, targetControl, targetEnabledStatus);
                    return true;
                }
                targetControl.Enabled = targetEnabledStatus;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>Button按钮Enable更新</summary>
        /// <param name="targetControl">Button</param>
        /// <param name="targetEnabledStatus">bool</param>
        /// <param name="ver">版本</param>
        /// <returns>bool</returns>
        public static bool ChangeButtonEnableStatus(Button targetControl, bool targetEnabledStatus, string ver = "1.0")
        {
            try
            {
                if (targetControl == null)
                {
                    return false;
                }

                if (targetControl.InvokeRequired)
                {
                    targetControl.Invoke(new Func<Button, bool, string, bool>(ChangeButtonEnableStatus), targetControl, targetEnabledStatus, ver);
                }
                else
                {
                    targetControl.Enabled = targetEnabledStatus;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }




        //BackColor更新
        [Obsolete]
        private delegate bool ChangeButtonBackColorDelegate(ref Button targetControl, Color targetColor);
        [Obsolete]
        public static bool ChangeButtonBackColor(ref Button targetControl, Color targetColor)
        {
            try
            {
                if (targetControl == null)
                {
                    return false;
                }
                if (targetControl.InvokeRequired)
                {
                    ChangeButtonBackColorDelegate method = ChangeButtonBackColor;
                    targetControl.Invoke(method, targetControl, targetColor);
                    return true;
                }
                targetControl.BackColor = targetColor;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>Button按钮BackColor更新</summary>
        /// <param name="targetControl">Button</param>
        /// <param name="targetColor">Color</param>
        /// <param name="ver">版本</param>
        /// <returns>bool（true：成功；false：失败；）</returns>
        public static bool ChangeButtonBackColor(Button targetControl, Color targetColor, string ver = "1.0")
        {
            try
            {
                if (targetControl == null)
                {
                    return false;
                }

                if (targetControl.InvokeRequired)
                {
                    targetControl.Invoke(new Func<Button, Color, string, bool>(ChangeButtonBackColor), targetControl, targetColor, ver);
                }
                else
                {
                    targetControl.BackColor = targetColor;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        [Obsolete]
        private delegate bool ChangeLabelBackColorDelegate(ref Label targetLabel, Color newColor);
        [Obsolete]
        public static bool ChangeLabelBackColor(ref Label targetLabel, Color newColor)
        {
            try
            {
                if (targetLabel == null)
                {
                    return false;
                }
                if (targetLabel.InvokeRequired)
                {
                    ChangeLabelBackColorDelegate method = ChangeLabelBackColor;
                    targetLabel.Invoke(method, targetLabel, newColor);
                    return true;
                }
                targetLabel.BackColor = newColor;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>Label标签BackColor更新</summary>
        /// <param name="targetLabel">Label</param>
        /// <param name="newColor">Color</param>
        /// <param name="ver">版本</param>
        /// <returns>bool（true：成功；false：失败；）</returns>
        public static bool ChangeLabelBackColor(Label targetLabel, Color newColor, string ver = "1.0")
        {
            try
            {
                if (targetLabel == null)
                {
                    return false;
                }
                if (targetLabel.InvokeRequired)
                {
                    targetLabel.Invoke(new Func<Label, Color, string, bool>(ChangeLabelBackColor), targetLabel, newColor, ver);
                }
                else
                {
                    targetLabel.BackColor = newColor;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }




        //DataGridView相关
        [Obsolete]
        public static bool SaveDgvDataToCsvFile(ref DataGridView dgv)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("无数据供导出", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FilterIndex = 0,
                RestoreDirectory = true,
                CreatePrompt = true,
                FileName = null,
                Title = "数据保存"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream = saveFileDialog.OpenFile();
                StreamWriter streamWriter = new StreamWriter(stream, Encoding.GetEncoding("GB2312"));
                string text = "";
                try
                {
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        if (i > 0)
                        {
                            text += ",";
                        }
                        text += dgv.Columns[i].HeaderText;
                    }
                    text.Remove(text.Length - 1);
                    streamWriter.WriteLine(text);
                    text = "";
                    for (int j = 0; j < dgv.Rows.Count; j++)
                    {
                        text = "";
                        int count = dgv.Columns.Count;
                        for (int k = 0; k < count; k++)
                        {
                            if (k > 0 && k < count)
                            {
                                text += ",";
                            }
                            if (dgv.Rows[j].Cells[k].Value == null)
                            {
                                text = text ?? "";
                                continue;
                            }
                            string text2 = dgv.Rows[j].Cells[k].Value.ToString().Trim();
                            text += text2;
                        }
                        streamWriter.WriteLine(text);
                    }
                    streamWriter.Close();
                    stream.Close();
                    MessageBox.Show("数据已保存至" + saveFileDialog.FileName, "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据保存异常：" + ex.Message, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
            }
            return true;
        }
        /// <summary>DataGridView表格保存至本地CSV</summary>
        /// <param name="dgv">DataGridView表格</param>
        /// <param name="errorText">错误记录</param>
        /// <param name="ver">版本</param>
        /// <returns>bool</returns>
        [Obsolete]
        public static bool SaveDgvDataToCsvFile(DataGridView dgv, ref string errorText, string ver = "1.0")
        {
            try
            {
                if (dgv.Rows == null || dgv.Rows.Count == 0)
                    throw new ArgumentException("表格数据为空");

                string path = null;
                //FileHelper.SaveFileDialogMethod("", FilterType.CSV, DefaultExt.CSV, true, true, true, ref path);
                if (string.IsNullOrEmpty(path))
                {
                    return true;
                }

                StringBuilder text = new StringBuilder();
                using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                using (StreamWriter streamWriter = new StreamWriter(stream, Encoding.GetEncoding("GB2312")))
                {
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        if (i > 0)
                            text.Append(",");
                        text.Append(dgv.Columns[i].HeaderText);
                    }
                    streamWriter.WriteLine(text);

                    for (int j = 0; j < dgv.Rows.Count; j++)
                    {
                        text.Clear();
                        for (int k = 0; k < dgv.Columns.Count; k++)
                        {
                            if (k > 0)
                                text.Append(",");
                            text.Append(dgv.Rows[j].Cells[k].Value == null ? "" : dgv.Rows[j].Cells[k].Value.ToString().Trim());
                        }
                        streamWriter.WriteLine(text);
                    }
                }
            }
            catch (Exception ex)
            {
                errorText = "数据保存失败：" + ex.Message;
                return false;
            }
            return true;
        }
        /// <summary>获取DataGridView数据</summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="isContainTitle">true：获取标题；false：不获取标题</param>
        /// <param name="listString">返回数据listString</param>
        /// <param name="timeColumn">小于等于0：不包含时间列；否则包含时间列</param>
        /// <param name="strSplit"></param>
        /// <returns>bool</returns>
        public static bool GetDgvData(DataGridView dgv, bool isContainTitle, ref List<string> listString, int timeColumn = 0, string strSplit = ",")
        {
            try
            {
                if (dgv == null || dgv.Rows.Count == 0)
                {
                    listString = new List<string>();
                    return true;
                }

                List<string> temp = new List<string>();
                StringBuilder text = new StringBuilder();

                if (isContainTitle)
                {
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        text.Append(dgv.Columns[i].HeaderText);
                        if (i < dgv.ColumnCount - 1)
                        {
                            text.Append(strSplit);
                        }
                    }
                    listString.Add(text.ToString());
                }
                
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    text.Clear();
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        object val = dgv.Rows[i].Cells[j].Value;
                        if (j == timeColumn - 1)
                        {
                            text.Append("\'");
                            text.Append(val == null ? "" : Convert.ToDateTime(val).ToString("yyyy/MM/dd HH:mm:ss.fff"));
                        }
                        else
                        {
                            text.Append(val == null ? "" : val.ToString());
                        }

                        if (j < dgv.Columns.Count - 1)
                        {
                            text.Append(strSplit);
                        }
                    }
                    listString.Add(text.ToString());
                }

                return true;
            }
            catch
            {
                listString = new List<string>();
                return false;
            }
        }


        [Obsolete]
        public static bool CheckDgvCellRepeat(ref DataGridView dgv, int columnIndex = 0)
        {
            if (dgv.Rows.Count <= 1) return false;
            dgv.ClearSelection();
            bool flag = true;
            DataGridViewCellStyle style = new DataGridViewCellStyle { BackColor = Color.Red };
            DataGridViewCellStyle style2 = new DataGridViewCellStyle { BackColor = Color.White };
            bool[] array = new bool[dgv.Rows.Count];
            for (int i = 0; i < array.Length; i++)
                array[i] = false;
            for (int j = 0; j < dgv.Rows.Count - 1; j++)
            {
                for (int k = j + 1; k < dgv.Rows.Count; k++)
                {
                    if (dgv.Rows[j].Cells[columnIndex].Value != null && dgv.Rows[k].Cells[columnIndex].Value != null)
                    {
                        if (dgv.Rows[j].Cells[columnIndex].Value.ToString().Trim() == dgv.Rows[k].Cells[columnIndex].Value.ToString().Trim())
                        {
                            flag = false;
                            dgv.Rows[j].Cells[columnIndex].Style = style;
                            array[j] = true;
                            dgv.Rows[k].Cells[columnIndex].Style = style;
                            array[k] = true;
                        }
                        else
                        {
                            if (!array[j])
                            {
                                dgv.Rows[j].Cells[columnIndex].Style = style2;
                            }
                            if (!array[k])
                            {
                                dgv.Rows[k].Cells[columnIndex].Style = style2;
                            }
                        }
                    }
                    if (dgv.Rows[k].Cells[columnIndex].Value == null || string.IsNullOrEmpty(dgv.Rows[k].Cells[columnIndex].Value.ToString()))
                    {
                        flag = false;
                        dgv.Rows[k].Cells[columnIndex].Style = style;
                        array[k] = true;
                    }
                }
                if (dgv.Rows[j].Cells[columnIndex].Value == null || string.IsNullOrEmpty(dgv.Rows[j].Cells[columnIndex].Value.ToString()))
                {
                    flag = false;
                    dgv.Rows[j].Cells[columnIndex].Style = style;
                    array[j] = true;
                }
            }
            return !flag;
        }
        /// <summary>检查DataGridView指定列是否有重复值</summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="errorText"></param>
        /// <param name="columnIndex">指定列（默认第一列 = 0）</param>
        /// <returns>bool（true：存在重复值或空值；false：不存在）</returns>
        public static bool CheckDgvCellRepeat(DataGridView dgv, ref string errorText, int columnIndex = 0)
        {
            if (dgv.Rows.Count <= 0)
            {
                return false;
            }

            ConcurrentDictionary<string, int> tempDic = new ConcurrentDictionary<string, int>();
            DataGridViewCellStyle styleRed = new DataGridViewCellStyle { BackColor = Color.Red };
            DataGridViewCellStyle styleWhite = new DataGridViewCellStyle { BackColor = Color.White };
            dgv.ClearSelection();
            bool flag = false;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells[columnIndex].Value == null || string.IsNullOrEmpty(dgv.Rows[i].Cells[columnIndex].Value.ToString()))
                {
                    dgv.Rows[i].Cells[columnIndex].Style = styleRed;
                    errorText = $"第{i + 1}行，第{columnIndex + 1}列为空";
                    return true;
                }
                string tempValue = dgv.Rows[i].Cells[columnIndex].Value.ToString();
                if (!tempDic.ContainsKey(tempValue))
                {
                    if (!tempDic.TryAdd(tempValue, i + 1))
                    {
                        dgv.Rows[i].Cells[columnIndex].Style = styleRed;
                        errorText = $"安全队列在添加{tempValue}时发生错误";
                        return true;
                    }
                    else
                    {
                        dgv.Rows[i].Cells[columnIndex].Style = styleWhite;
                    }
                }
                else
                {
                    dgv.Rows[i].Cells[columnIndex].Style = styleRed;
                    dgv.Rows[tempDic[tempValue] - 1].Cells[columnIndex].Style = styleRed;
                    errorText = $"第{tempDic[tempValue]}行与第{i + 1}行重复，名称={tempValue}";
                    return true;
                }
            }
            return flag;
        }


        /// <summary>单行上移一行</summary>
        /// <param name="dgv">DataGridView</param>
        public static bool DgvUpRow(ref DataGridView dgv)
        {
            try
            {
                int selectedRowIndex = GetSelectedRowIndex(ref dgv);

                if (selectedRowIndex >= 1)
                {
                    DataGridViewRow dataGridViewRow = dgv.Rows[selectedRowIndex];

                    dgv.Rows.Remove(dgv.Rows[selectedRowIndex]);
                    dgv.Rows.Insert(selectedRowIndex - 1, dataGridViewRow);

                    dgv.ClearSelection();
                    dgv.Rows[selectedRowIndex - 1].Selected = true;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>单行下移一行</summary>
        /// <param name="dgv">DataGridView</param>
        public static bool DgvDownRow(ref DataGridView dgv)
        {
            try
            {
                int selectedRowIndex = GetSelectedRowIndex(ref dgv);

                if (selectedRowIndex < dgv.Rows.Count - 1)
                {
                    DataGridViewRow dataGridViewRow = dgv.Rows[selectedRowIndex];

                    dgv.Rows.Remove(dgv.Rows[selectedRowIndex]);
                    dgv.Rows.Insert(selectedRowIndex + 1, dataGridViewRow);

                    dgv.ClearSelection();
                    dgv.Rows[selectedRowIndex + 1].Selected = true;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>多行上移一行</summary>
        /// <param name="dgv">DataGridView</param>
        public static bool DgvUpRows(ref DataGridView dgv)
        {
            try
            {
                DataGridViewSelectedRowCollection selectedRows = dgv.SelectedRows;

                if (dgv.Rows.Count <= 0 || selectedRows.Count <= 0 || selectedRows[0].Index <= 0 || dgv.Rows.Count == selectedRows.Count)
                {
                    return true;
                }

                if (selectedRows.Count == 1)
                {
                    return DgvUpRow(ref dgv);
                }

                if (selectedRows[0].Index > selectedRows[1].Index)
                {
                    //选择不连续直接返回
                    for (int i = 0; i < selectedRows.Count - 1; i++)
                    {
                        if (selectedRows[i].Index - selectedRows[i + 1].Index != 1)
                        {
                            return true;
                        }
                    }

                    int index = selectedRows[0].Index;
                    if ((index - selectedRows.Count) < 0)
                    {
                        return true;
                    }

                    DataGridViewRow dataGridViewRow = dgv.Rows[index - selectedRows.Count];

                    dgv.Rows.RemoveAt(index - selectedRows.Count);
                    dgv.Rows.Insert(index, dataGridViewRow);

                    for (int i = 0; i < selectedRows.Count; i++)
                    {
                        dgv.Rows[index - i - 1].Selected = true;
                    }
                }
                else
                {
                    //选择不连续直接返回
                    for (int i = selectedRows.Count - 1; i >= 1; i--)
                    {
                        if (selectedRows[i].Index - selectedRows[i - 1].Index != 1)
                        {
                            return true;
                        }
                    }

                    int index = selectedRows[0].Index;
                    if (index <= 0)
                    {
                        return true;
                    }

                    DataGridViewRow dataGridViewRow = dgv.Rows[index - 1];

                    dgv.Rows.RemoveAt(index - 1);
                    dgv.Rows.Insert(index + selectedRows.Count - 1, dataGridViewRow);

                    for (int i = 0; i < selectedRows.Count; i++)
                    {
                        dgv.Rows[index + i - 1].Selected = true;
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>多行下移一行</summary>
        /// <param name="dgv"></param>
        public static bool DgvDownRows(ref DataGridView dgv)
        {
            try
            {
                DataGridViewSelectedRowCollection selectedRows = dgv.SelectedRows;

                if (dgv.Rows.Count <= 0 || selectedRows.Count <= 0 || selectedRows[0].Index >= dgv.Rows.Count - 1 || dgv.Rows.Count == selectedRows.Count)
                {
                    return true;
                }

                if (selectedRows.Count == 1)
                {
                    return DgvDownRow(ref dgv);
                }

                if (selectedRows[0].Index > selectedRows[1].Index)
                {
                    //选择不连续直接返回
                    for (int i = 0; i < selectedRows.Count - 1; i++)
                    {
                        if (selectedRows[i].Index - selectedRows[i + 1].Index != 1)
                        {
                            return true;
                        }
                    }

                    int index = selectedRows[0].Index;
                    if (index >= dgv.Rows.Count - 1)
                    {
                        return true;
                    }

                    DataGridViewRow dataGridViewRow = dgv.Rows[index + 1];

                    dgv.Rows.RemoveAt(index + 1);
                    dgv.Rows.Insert(index + 1 - selectedRows.Count, dataGridViewRow);

                    for (int i = 0; i < selectedRows.Count; i++)
                    {
                        dgv.Rows[index + 1 - i].Selected = true;
                    }
                }
                else
                {

                    //选择不连续直接返回
                    for (int i = selectedRows.Count - 1; i >= 1; i--)
                    {
                        if (selectedRows[i].Index - selectedRows[i - 1].Index != 1)
                        {
                            return true;
                        }
                    }

                    int index = selectedRows[0].Index;
                    if (index + selectedRows.Count >= dgv.Rows.Count)
                    {
                        return true;
                    }

                    DataGridViewRow dataGridViewRow = dgv.Rows[index + selectedRows.Count];

                    dgv.Rows.RemoveAt(index + selectedRows.Count);
                    dgv.Rows.Insert(index, dataGridViewRow);

                    for (int i = 0; i < selectedRows.Count; i++)
                    {
                        dgv.Rows[index + 1 + i].Selected = true;
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }


        [Obsolete]
        private delegate bool ChangeFlowControlDelegate(ref FlowLayoutPanel flow, Control control);
        [Obsolete]
        public static bool RemoveControl(ref FlowLayoutPanel flow, Control removedControl)
        {
            try
            {
                if (flow == null || removedControl == null)
                {
                    return false;
                }
                if (flow.InvokeRequired)
                {
                    ChangeFlowControlDelegate method = RemoveControl;
                    flow.Invoke(method, flow, removedControl);
                }
                else
                {
                    flow.Controls.Remove(removedControl);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>FlowLayoutPanel移除指定控件 || 所有控件</summary>
        /// <param name="flow">FlowLayoutPanel</param>
        /// <param name="removedControl">指定控件</param>
        /// <param name="ver">版本</param>
        /// <returns>bool</returns>
        public static bool RemoveControl(FlowLayoutPanel flow, Control removedControl, string ver = "1.0")
        {
            try
            {
                if (flow == null)
                {
                    return false;
                }

                if (flow.InvokeRequired)
                {
                    flow.Invoke(new Func<FlowLayoutPanel, Control, string, bool>(RemoveControl), flow, removedControl, ver);
                }
                else
                {
                    if(removedControl == null)
                    {
                        flow.Controls.Clear();
                    }
                    else
                    {
                        flow.Controls.Remove(removedControl);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        [Obsolete]
        public static bool AddControl(ref FlowLayoutPanel flow, Control newControl)
        {
            try
            {
                if (flow == null || newControl == null)
                {
                    return false;
                }
                if (flow.InvokeRequired)
                {
                    ChangeFlowControlDelegate method = AddControl;
                    flow.Invoke(method, flow, newControl);
                }
                else
                {
                    flow.Controls.Add(newControl);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>FlowLayoutPanel增加指定控件</summary>
        /// <param name="flow">FlowLayoutPanel</param>
        /// <param name="newControl">指定控件</param>
        /// <param name="ver">版本</param>
        /// <returns>bool</returns>
        public static bool AddControl(FlowLayoutPanel flow, Control newControl, string ver = "1.0")
        {
            try
            {
                if (flow == null || newControl == null)
                {
                    return false;
                }

                if (flow.InvokeRequired)
                {
                    flow.Invoke(new Func<FlowLayoutPanel, Control, string, bool>(AddControl), flow, newControl, ver);
                }
                else
                {
                    flow.Controls.Add(newControl);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DgvCopy(ref DataGridView dgv)
        {
            try
            {
                DataObject clipboardContent = dgv.GetClipboardContent();
                Clipboard.SetDataObject(clipboardContent);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DgvPaste(ref DataGridView dgv)
        {
            string text = Clipboard.GetText();
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            string[] array = text.Split('\n');
            if (array.Length == 0)
            {
                return false;
            }
            List<string> list = array.ToList();
            for (int num = list.Count - 1; num >= 0; num--)
            {
                if (string.IsNullOrEmpty(list[num]) || list[num] == "\r")
                {
                    list.Remove(list[num]);
                }
                else if (list[num].EndsWith("\r"))
                {
                    list[num] = list[num].Remove(list[num].Length - 1, 1);
                }
            }
            if (list.Count == 0)
            {
                return false;
            }
            int num2 = 0;
            int num3 = 0;
            if (dgv.CurrentCell != null)
            {
                num2 = dgv.CurrentCell.RowIndex;
                num3 = dgv.CurrentCell.ColumnIndex;
            }
            if (dgv.Rows.Count - num2 < list.Count)
            {
                dgv.Rows.Add(list.Count - (dgv.Rows.Count - num2));
            }
            foreach (string item in list)
            {
                if (item.Length > 0 && num2 < dgv.RowCount)
                {
                    string[] array2 = item.Split('\t');
                    for (int i = 0; i < array2.GetLength(0) && num3 + i < dgv.ColumnCount; i++)
                    {
                        dgv[num3 + i, num2].Value = Convert.ChangeType(array2[i], dgv[num3 + i, num2].ValueType);
                    }
                    num2++;
                }
                else if (num2 == dgv.RowCount && item.Length > 0)
                {
                    break;
                }
            }
            return true;
        }


        #region Others
        /// <summary>返回选中行的行号</summary>
        /// <param name="dgv">DataGridViewRow</param>
        /// <returns>int</returns>
        private static int GetSelectedRowIndex(ref DataGridView dgv)
        {
            if (dgv.Rows.Count == 0)
            {
                return 0;
            }

            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (item.Selected)
                {
                    return item.Index;
                }
            }
            return 0;
        }
        #endregion









        private delegate bool AddMessageToRichTextBox(ref RichTextBox targetRichTextBox, string targetText);

        private delegate bool AddMessageToTextBox(ref TextBox targetTextBox, string targetText);

        private delegate bool AddTextDelegate(string targetText);

        private delegate bool ChangeBackColorDelegate(ref Control targetControl, Color targetBackColor);

        private delegate bool ChangeBackColorOfPictureDelegate(ref PictureBox targetPictureBox, Color newColor);

        private delegate bool ChangeBackgroundImageDelegate(ref Control targetControl, Image targetBackgroundImage);


        private delegate bool ChangeButtonTagDelegate(ref Button targetControl, object tagValue);

        private delegate bool ChangeEnableDelegate(ref Control targetControl, bool targetEnableStatus);


        private delegate bool ChangeForeColorDelegate(ref Control targetControl, Color targetForeColor);

        private delegate bool ChangeImageOfPictureDelegate(ref PictureBox targetPictureBox, Image newImage);

        private delegate bool ChangeLabelPositionDelegate(ref Label targetLabel, int left, int top);

        private delegate bool ChangeListViewRowBackColorDelegate(ref ListView targetListView, int targetRow, Color newColor);

        private delegate bool ChangeMenuBackColorDelegate(ref Button invokeButton, ref ToolStripMenuItem targetControl, Color targetColor);

        private delegate bool ChangeMenuEnableStatusDelegate(ref Button invokeButton, ref ToolStripMenuItem targetControl, bool targetEnabledStatus);

        private delegate bool ChangeMenuImageDelegate(ref Button invokeButton, ref ToolStripMenuItem targetControl, Image targetImage);

        private delegate bool ChangePositionDelegate(ref Control targetControl, int left, int top);

        private delegate bool ChangeSizeDelegate(ref Control targetControl, int width, int height);

        private delegate bool ChangeStatusLabelBackColorDelegate(ref StatusStrip invokeControl, ref ToolStripStatusLabel targetControl, Color targetColor);

        private delegate bool ChangeStatusLabelEnableStatusDelegate(ref Button invokeButton, ref ToolStripStatusLabel targetControl, bool targetEnabledStatus);

        private delegate bool ChangeStatusLabelTextDelegate(ref StatusStrip invokeControl, ref ToolStripStatusLabel targetControl, string targetText);

        private delegate bool ChangeTextBoxBackColorDelegate(ref TextBox targetLabel, Color newColor);

        private delegate bool ChangeTextBoxReadOnlyDelegate(ref TextBox targetLabel, bool enable);

        private delegate bool ChangeTextDelegate(ref Control targetControl, string targetText);

        private delegate bool ClearRichTextBoxDelegate(ref RichTextBox targetRichTextBox);

        private delegate bool ClearTextBoxDelegate(ref TextBox targetTextBox);

        private delegate bool GetComboBoxSelectedIndexDelegate(ref ComboBox targetControl, ref int index);

        private delegate bool UpdateRichTextBoxDelegate(ref RichTextBox targetRichTextBox, string targetText);

        private delegate bool UpdateTextBoxDelegate(ref TextBox targetTextBox, string targetText);

        private static string _tempErrorMessage;

        public static bool UpdatingSameMessage { get; set; } = true;

        public static bool AddRichText(ref RichTextBox targetRichTextBox, string targetText)
        {
            try
            {
                if (targetRichTextBox == null)
                {
                    return false;
                }
                if (targetText == "")
                {
                    return false;
                }
                string text = "";
                text = ((targetText.Length == 1) ? targetText : ((text.Length == 2) ? ((!((Strings.Asc(Strings.Mid(targetText, targetText.Length, 1)) == 13) | (Strings.Asc(Strings.Mid(targetText, targetText.Length, 1)) == 10))) ? targetText : Strings.Mid(targetText, 1, targetText.Length - 1)) : ((!((Strings.Asc(Strings.Mid(targetText, targetText.Length - 1, 1)) == 13) & (Strings.Asc(Strings.Mid(targetText, targetText.Length, 1)) == 10))) ? targetText : Strings.Mid(targetText, 1, targetText.Length - 2))));
                if (targetRichTextBox.InvokeRequired)
                {
                    AddMessageToRichTextBox method = AddRichText;
                    targetRichTextBox.Invoke(method, targetRichTextBox, text);
                }
                else if (UpdatingSameMessage)
                {
                    _tempErrorMessage = text;
                    targetRichTextBox.AppendText(DateTime.Now.ToString() + "  " + DateTime.Now.Millisecond + "   " + text + "\r\n");
                    text = "";
                }
                else
                {
                    if (_tempErrorMessage == text)
                    {
                        return false;
                    }
                    _tempErrorMessage = text;
                    targetRichTextBox.AppendText(DateTime.Now.ToString() + "  " + DateTime.Now.Millisecond + "   " + text + "\r\n");
                    text = "";
                }
                targetText = "";
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool AddRichTextWithoutTimeMark(ref RichTextBox targetRichTextBox, string targetText)
        {
            try
            {
                if (targetRichTextBox == null)
                {
                    return false;
                }
                if (targetText == "")
                {
                    return false;
                }
                string text = "";
                text = ((targetText.Length == 1) ? targetText : ((text.Length == 2) ? ((!((Strings.Asc(Strings.Mid(targetText, targetText.Length, 1)) == 13) | (Strings.Asc(Strings.Mid(targetText, targetText.Length, 1)) == 10))) ? targetText : Strings.Mid(targetText, 1, targetText.Length - 1)) : ((!((Strings.Asc(Strings.Mid(targetText, targetText.Length - 1, 1)) == 13) & (Strings.Asc(Strings.Mid(targetText, targetText.Length, 1)) == 10))) ? targetText : Strings.Mid(targetText, 1, targetText.Length - 2))));
                targetText = "";
                if (targetRichTextBox.InvokeRequired)
                {
                    AddMessageToRichTextBox method = AddRichTextWithoutTimeMark;
                    targetRichTextBox.Invoke(method, targetRichTextBox, text);
                }
                else if (UpdatingSameMessage)
                {
                    _tempErrorMessage = text;
                    targetRichTextBox.AppendText(text + "\r\n");
                    text = "";
                }
                else
                {
                    if (_tempErrorMessage == text)
                    {
                        return false;
                    }
                    _tempErrorMessage = text;
                    targetRichTextBox.AppendText(text + "\r\n");
                    text = "";
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool AddTextBox(ref TextBox targetTextBox, string targetText)
        {
            try
            {
                if (targetTextBox == null)
                {
                    return false;
                }
                if (targetText == "")
                {
                    return false;
                }
                string text = "";
                text = ((targetText.Length == 1) ? targetText : ((text.Length == 2) ? ((!((Strings.Asc(Strings.Mid(targetText, targetText.Length, 1)) == 13) | (Strings.Asc(Strings.Mid(targetText, targetText.Length, 1)) == 10))) ? targetText : Strings.Mid(targetText, 1, targetText.Length - 1)) : ((!((Strings.Asc(Strings.Mid(targetText, targetText.Length - 1, 1)) == 13) & (Strings.Asc(Strings.Mid(targetText, targetText.Length, 1)) == 10))) ? targetText : Strings.Mid(targetText, 1, targetText.Length - 2))));
                targetText = "";
                if (targetTextBox.InvokeRequired)
                {
                    AddMessageToTextBox method = AddTextBox;
                    targetTextBox.Invoke(method, targetTextBox, text);
                }
                else if (UpdatingSameMessage)
                {
                    _tempErrorMessage = text;
                    targetTextBox.AppendText(DateTime.Now.ToString() + "  " + DateTime.Now.Millisecond + "   " + text + "\r\n");
                    text = "";
                }
                else
                {
                    if (_tempErrorMessage == text)
                    {
                        return false;
                    }
                    _tempErrorMessage = text;
                    targetTextBox.AppendText(DateTime.Now.ToString() + "  " + DateTime.Now.Millisecond + "   " + text + "\r\n");
                    text = "";
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool AddTextWithoutTimeMark(ref TextBox targetTextBox, string targetText)
        {
            try
            {
                if (targetTextBox == null)
                {
                    return false;
                }
                if (targetText == "")
                {
                    return false;
                }
                string text = "";
                text = ((targetText.Length == 1) ? targetText : ((text.Length == 2) ? ((!((Strings.Asc(Strings.Mid(targetText, targetText.Length, 1)) == 13) | (Strings.Asc(Strings.Mid(targetText, targetText.Length, 1)) == 10))) ? targetText : Strings.Mid(targetText, 1, targetText.Length - 1)) : ((!((Strings.Asc(Strings.Mid(targetText, targetText.Length - 1, 1)) == 13) & (Strings.Asc(Strings.Mid(targetText, targetText.Length, 1)) == 10))) ? targetText : Strings.Mid(targetText, 1, targetText.Length - 2))));
                targetText = "";
                if (targetTextBox.InvokeRequired)
                {
                    AddMessageToTextBox method = AddTextWithoutTimeMark;
                    targetTextBox.Invoke(method, targetTextBox, text);
                }
                else if (UpdatingSameMessage)
                {
                    _tempErrorMessage = text;
                    targetTextBox.AppendText(text + "\r\n");
                }
                else
                {
                    if (_tempErrorMessage == text)
                    {
                        return false;
                    }
                    _tempErrorMessage = text;
                    targetTextBox.AppendText(text + "\r\n");
                    text = "";
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ChangeBackColorOfPicture(ref PictureBox targetPictreBox, Color newColor)
        {
            try
            {
                if (targetPictreBox.InvokeRequired)
                {
                    ChangeBackColorOfPictureDelegate method = ChangeBackColorOfPicture;
                    targetPictreBox.Invoke(method, targetPictreBox, newColor);
                    return true;
                }
                targetPictreBox.BackColor = newColor;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        public static bool ChangeButtonTag(ref Button targetControl, object tag)
        {
            try
            {
                if (targetControl == null)
                {
                    return false;
                }
                if (targetControl.InvokeRequired)
                {
                    ChangeButtonTagDelegate method = ChangeButtonTag;
                    targetControl.Invoke(method, targetControl, tag);
                    return true;
                }
                targetControl.Tag = tag;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        public static bool ChangeButtonText(Button targetControl, string text)
        {
            try
            {
                if (targetControl == null)
                {
                    return false;
                }
                if (targetControl.InvokeRequired)
                {
                    targetControl.Invoke(new Action(() => targetControl.Text = text));
                    return true;
                }
                targetControl.Text = text;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ChangeControlBackColor(ref Control targetControl, Color targetBackColor)
        {
            try
            {
                if (targetControl == null)
                {
                    return false;
                }
                if (targetControl.InvokeRequired)
                {
                    ChangeBackColorDelegate method = ChangeControlBackColor;
                    targetControl.Invoke(method, targetControl, targetBackColor);
                    return true;
                }
                targetControl.BackColor = targetBackColor;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ChangeControlBackgroundImage(ref Control targetControl, Image targetBackgroundImage)
        {
            try
            {
                if (targetControl == null || targetBackgroundImage == null)
                {
                    return false;
                }
                if (targetControl.InvokeRequired)
                {
                    ChangeBackgroundImageDelegate method = ChangeControlBackgroundImage;
                    targetControl.Invoke(method, targetControl, targetBackgroundImage);
                    return true;
                }
                targetControl.BackgroundImage = targetBackgroundImage;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ChangeControlEnableStatus(ref Control targetControl, bool targetEnableStatus)
        {
            try
            {
                if (targetControl == null)
                {
                    return false;
                }
                if (targetControl.InvokeRequired)
                {
                    ChangeEnableDelegate method = ChangeControlEnableStatus;
                    targetControl.Invoke(method, targetControl, targetEnableStatus);
                    return true;
                }
                targetControl.Enabled = targetEnableStatus;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ChangeControlForeColor(ref Control targetControl, Color targetForeColor)
        {
            try
            {
                if (targetControl == null)
                {
                    return false;
                }
                if (targetControl.InvokeRequired)
                {
                    ChangeForeColorDelegate method = ChangeControlForeColor;
                    targetControl.Invoke(method, targetControl, targetForeColor);
                    return true;
                }
                targetControl.ForeColor = targetForeColor;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ChangeControlPosition(ref Control targetControl, int left = 0, int top = 0)
        {
            try
            {
                if (targetControl == null)
                {
                    return false;
                }
                if (targetControl.InvokeRequired)
                {
                    ChangePositionDelegate method = ChangeControlPosition;
                    targetControl.Invoke(method, targetControl, left, top);
                    return true;
                }
                targetControl.Left = left;
                targetControl.Top = top;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ChangeControlSize(ref Control targetControl, int width = 20, int height = 20)
        {
            try
            {
                if (targetControl == null)
                {
                    return false;
                }
                if (targetControl.InvokeRequired)
                {
                    ChangeSizeDelegate method = ChangeControlSize;
                    targetControl.Invoke(method, targetControl, width, height);
                    return true;
                }
                targetControl.Width = width;
                targetControl.Height = height;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ChangeControlText(ref Control targetControl, string targetText)
        {
            try
            {
                if (targetControl == null)
                {
                    return false;
                }
                if (targetControl.InvokeRequired)
                {
                    ChangeTextDelegate method = ChangeControlText;
                    targetControl.Invoke(method, targetControl, targetText);
                    return true;
                }
                targetControl.Text = targetText;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ChangeImageOfPicture(ref PictureBox targetPictreBox, Image targetImage)
        {
            try
            {
                if (targetPictreBox.InvokeRequired)
                {
                    ChangeImageOfPictureDelegate method = ChangeImageOfPicture;
                    targetPictreBox.Invoke(method, targetPictreBox, targetImage);
                    return true;
                }
                targetPictreBox.Image = targetImage;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static bool ChangeLabelPosition(ref Label targetLabel, int left = 0, int top = 0)
        {
            try
            {
                if (targetLabel == null)
                {
                    return false;
                }
                if (targetLabel.InvokeRequired)
                {
                    ChangeLabelPositionDelegate method = ChangeLabelPosition;
                    targetLabel.Invoke(method, targetLabel, left, top);
                    return true;
                }
                targetLabel.Left = left;
                targetLabel.Top = top;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ChangeListViewRowBackColor(ref ListView targetListView, int targetRow, Color newRowColor)
        {
            try
            {
                if (targetRow <= 0)
                {
                    return false;
                }
                if (targetListView == null)
                {
                    return false;
                }
                if (targetListView.Items.Count < 1 || targetListView.Items.Count < targetRow)
                {
                    return false;
                }
                if (targetListView.InvokeRequired)
                {
                    ChangeListViewRowBackColorDelegate method = ChangeListViewRowBackColor;
                    targetListView.Invoke(method, targetListView, targetRow, newRowColor);
                }
                else
                {
                    targetListView.BeginUpdate();
                    targetListView.Items[targetRow - 1].BackColor = newRowColor;
                    targetListView.EndUpdate();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool ChangeMenuBackColor(ref Button invokeButton, ref ToolStripMenuItem targetControl, Color targetColor)
        {
            try
            {
                if (invokeButton == null)
                {
                    return false;
                }
                if (invokeButton.InvokeRequired)
                {
                    ChangeMenuBackColorDelegate method = ChangeMenuBackColor;
                    invokeButton.Invoke(method, invokeButton, targetControl, targetColor);
                    return true;
                }
                targetControl.BackColor = targetColor;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ChangeMenuEnableStatus(ref Button invokeButton, ref ToolStripMenuItem targetControl, bool targetEnabledStatus)
        {
            try
            {
                if (invokeButton == null)
                {
                    return false;
                }
                if (invokeButton.InvokeRequired)
                {
                    ChangeMenuEnableStatusDelegate method = ChangeMenuEnableStatus;
                    invokeButton.Invoke(method, invokeButton, targetControl, targetEnabledStatus);
                    return true;
                }
                targetControl.Enabled = targetEnabledStatus;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ChangeMenuImage(ref Button invokeButton, ref ToolStripMenuItem targetControl, Image targetImage)
        {
            try
            {
                if (invokeButton == null)
                {
                    return false;
                }
                if (invokeButton.InvokeRequired)
                {
                    ChangeMenuImageDelegate method = ChangeMenuImage;
                    invokeButton.Invoke(method, invokeButton, targetControl, targetImage);
                    return true;
                }
                targetControl.Image = targetImage;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ChangeStatusLabelBackColor(ref StatusStrip invokeControl, ref ToolStripStatusLabel targetControl, Color targetColor)
        {
            try
            {
                if (invokeControl == null)
                {
                    return false;
                }
                if (invokeControl.InvokeRequired)
                {
                    ChangeStatusLabelBackColorDelegate method = ChangeStatusLabelBackColor;
                    invokeControl.Invoke(method, invokeControl, targetControl, targetColor);
                    return true;
                }
                targetControl.BackColor = targetColor;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ChangeStatusLabelEnableStatus(ref Button invokeButton, ref ToolStripStatusLabel targetControl, bool targetEnabledStatus)
        {
            try
            {
                if (invokeButton == null)
                {
                    return false;
                }
                if (invokeButton.InvokeRequired)
                {
                    ChangeStatusLabelEnableStatusDelegate method = ChangeStatusLabelEnableStatus;
                    invokeButton.Invoke(method, invokeButton, targetControl, targetEnabledStatus);
                    return true;
                }
                targetControl.Enabled = targetEnabledStatus;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ChangeStatusLabelText(ref StatusStrip invokeControl, ref ToolStripStatusLabel targetLabel, string targetText)
        {
            try
            {
                if (invokeControl == null)
                {
                    return false;
                }
                if (invokeControl.InvokeRequired)
                {
                    ChangeStatusLabelTextDelegate method = ChangeStatusLabelText;
                    invokeControl.Invoke(method, invokeControl, targetLabel, targetText);
                    return true;
                }
                targetLabel.Text = targetText;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ChangeTextBoxBackColor(ref TextBox targetTextBox, Color newColor)
        {
            try
            {
                if (targetTextBox == null)
                {
                    return false;
                }
                if (targetTextBox.InvokeRequired)
                {
                    ChangeTextBoxBackColorDelegate method = ChangeTextBoxBackColor;
                    targetTextBox.Invoke(method, targetTextBox, newColor);
                    return true;
                }
                targetTextBox.BackColor = newColor;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ChangeTextBoxForeColor(ref TextBox targetTextBox, Color newColor)
        {
            try
            {
                if (targetTextBox == null)
                {
                    return false;
                }
                if (targetTextBox.InvokeRequired)
                {
                    ChangeTextBoxBackColorDelegate method = ChangeTextBoxForeColor;
                    targetTextBox.Invoke(method, targetTextBox, newColor);
                    return true;
                }
                targetTextBox.ForeColor = newColor;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ChangeTextBoxReadOnly(ref TextBox targetTextBox, bool enable)
        {
            try
            {
                if (targetTextBox == null)
                {
                    return false;
                }
                if (targetTextBox.InvokeRequired)
                {
                    ChangeTextBoxReadOnlyDelegate method = ChangeTextBoxReadOnly;
                    targetTextBox.Invoke(method, targetTextBox, enable);
                    return true;
                }
                targetTextBox.ReadOnly = enable;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ClearRichTextBoxContents(ref RichTextBox targetRichTextBox)
        {
            try
            {
                if (targetRichTextBox == null)
                {
                    return false;
                }
                if (targetRichTextBox.InvokeRequired)
                {
                    ClearRichTextBoxDelegate method = ClearRichTextBoxContents;
                    targetRichTextBox.Invoke(method, targetRichTextBox);
                    return true;
                }
                targetRichTextBox.Text = "";
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ClearTextBoxContents(ref TextBox targetTextBox)
        {
            if (targetTextBox == null)
            {
                return false;
            }
            if (targetTextBox.InvokeRequired)
            {
                ClearTextBoxDelegate method = ClearTextBoxContents;
                targetTextBox.Invoke(method, targetTextBox);
                return true;
            }
            targetTextBox.Text = "";
            return true;
        }

        public static bool GetComboBoxSelectedIndex(ref ComboBox targetControl, ref int value)
        {
            try
            {
                if (targetControl == null)
                {
                    value = -1;
                    return false;
                }
                if (targetControl.InvokeRequired)
                {
                    GetComboBoxSelectedIndexDelegate method = GetComboBoxSelectedIndex;
                    targetControl.Invoke(method, targetControl, value);
                    return true;
                }
                value = targetControl.SelectedIndex;
                return true;
            }
            catch (Exception)
            {
                value = -1;
                return false;
            }
        }


        public static bool UpdateRichTextBox(ref RichTextBox targetRichTextBox, string targetText)
        {
            try
            {
                if (targetRichTextBox == null)
                {
                    return false;
                }
                if (targetRichTextBox.InvokeRequired)
                {
                    UpdateRichTextBoxDelegate method = UpdateRichTextBox;
                    targetRichTextBox.Invoke(method, targetRichTextBox, targetText);
                    return true;
                }
                targetRichTextBox.Text = targetText;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UpdateTextBox(ref TextBox targetTextBox, string targetText)
        {
            try
            {
                if (targetTextBox == null)
                {
                    return false;
                }
                if (targetTextBox.InvokeRequired)
                {
                    UpdateTextBoxDelegate method = UpdateTextBox;
                    targetTextBox.Invoke(method, targetTextBox, targetText);
                    return true;
                }
                targetTextBox.Text = targetText;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void DgvBottomRows(ref DataGridView dgv)
        {
            DataGridViewSelectedRowCollection selectedRows = dgv.SelectedRows;
            if (dgv.Rows.Count > 0 && selectedRows.Count > 0 && selectedRows[0].Index < dgv.Rows.Count - 1)
            {
                int index = selectedRows[0].Index;
                DataGridViewRow dataGridViewRow = dgv.Rows[index];
                dgv.Rows.RemoveAt(index);
                int count = dgv.Rows.Count;
                dgv.Rows.Insert(count, dataGridViewRow);
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    dgv.Rows[i].Selected = i == dgv.Rows.Count - 1;
                }
            }
        }



        public static void DgvTopRows(ref DataGridView dgv)
        {
            DataGridViewSelectedRowCollection selectedRows = dgv.SelectedRows;
            if (dgv.Rows.Count > 0 && selectedRows.Count > 0 && selectedRows[0].Index > 0)
            {
                int index = selectedRows[0].Index;
                DataGridViewRow dataGridViewRow = dgv.Rows[index];
                dgv.Rows.RemoveAt(index);
                dgv.Rows.Insert(0, dataGridViewRow);
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    dgv.Rows[i].Selected = i == 0;
                }
            }
        }
    }
}
