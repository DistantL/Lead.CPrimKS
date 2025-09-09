/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ControlHelper.cs
 * Author: Victor
 * Description: 控件帮助类
 * CreateTime: 2023-1-2
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.23.0101><Victor><20230109>
 * 1、DataGridView保存CSV时如果包含时间列，对时间进行格式处理再保存
******************************************************************************/

using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>控件帮助类</summary>
    public static class ControlHelper
    {
        //BackColor属性设置
        /// <summary>
        /// Control.BackColo设置（适用于所有子类）<br/>
        /// TextBox<br>
        /// UILabel</br>
        /// </summary>
        /// <param name="target">target</param>
        /// <param name="newColor">Color</param>
        public static void SetBackColor(this Control target, Color newColor)
        {
            if (target == null || !target.Created || !target.IsHandleCreated)
            {
                return;
            }

            if (target.InvokeRequired)
            {
                target.Invoke(new Action<Control, Color>(SetBackColor), target, newColor);
            }
            else
            {
                target.BackColor = newColor;
            }
        }

        //ForeColor属性设置
        /// <summary>
        /// Control.ForeColor设置（适用于所有子类）<br/>
        /// TextBox<br/>
        /// UILabel<br/>
        /// Label<br/>
        /// </summary>
        /// <param name="target">target</param>
        /// <param name="newColor">Color</param>
        public static void SetForeColor(this Control target, Color newColor)
        {
            if (target == null || !target.Created || !target.IsHandleCreated)
            {
                return;
            }

            if (target.InvokeRequired)
            {
                target.Invoke(new Action<Control, Color>(SetForeColor), target, newColor);
            }
            else
            {
                target.ForeColor = newColor;
            }
        }

        //Enabled属性设置
        /// <summary>
        /// TableLayoutPanel.Enable设置
        /// </summary>
        /// <param name="target"></param>
        /// <param name="enable"></param>
        public static void SetEnable(this TableLayoutPanel target, bool enable)
        {
            if (target == null || !target.Created || !target.IsHandleCreated)
            {
                return;
            }

            if (target.InvokeRequired)
            {
                target.BeginInvoke(new Action<TableLayoutPanel, bool>(SetEnable), new object[2] { target, enable });
            }
            else
            {
                target.Enabled = enable;
            }
        }

        /// <summary>
        /// GroupBox.Enable设置
        /// </summary>
        /// <param name="target"></param>
        /// <param name="enable"></param>
        public static void SetEnable(this GroupBox target, bool enable)
        {
            if (target == null || !target.Created || !target.IsHandleCreated)
            {
                return;
            }

            if (target.InvokeRequired)
            {
                target.BeginInvoke(new Action<GroupBox, bool>(SetEnable), new object[2] { target, enable });
            }
            else
            {
                target.Enabled = enable;
            }
        }

        /// <summary>
        /// Control.Enabled设置（适用于所有子类）<br/>
        /// TextBox<br/>
        /// UILabel<br/>
        /// Button<br/>
        /// </summary>
        /// <param name="target">Control</param>
        /// <param name="enable">值</param>
        public static void SetEnable(this Control target, bool enable)
        {
            if (target == null || !target.Created || !target.IsHandleCreated)
            {
                return;
            }

            if (target.InvokeRequired)
            {
                target.Invoke(new Action<Control, bool>(SetEnable), new object[2] { target, enable });
            }
            else
            {
                target.Enabled = enable;
            }
        }

        //Text属性设置
        /// <summary>
        /// TextBox.AppendText设置
        /// </summary>
        /// <param name="target"></param>
        /// <param name="text"></param>
        /// <param name="isAppendNewLine">true：自动追加换行符；false：不追加换行符</param>
        public static void AppendTextBox(this TextBox target, string text, bool isAppendNewLine = true)
        {
            if (target == null || !target.Created || !target.IsHandleCreated)
            {
                return;
            }

            if (target.InvokeRequired)
            {
                target.BeginInvoke(new Action<TextBox, string, bool>(AppendTextBox), new object[3] { target, text, isAppendNewLine });
            }
            else
            {
                if (isAppendNewLine)
                {
                    text = text + Environment.NewLine;
                }
                target.AppendText(text);
            }
        }

        /// <summary>
        /// Form.Text设置（适用于所有子类）<br/>
        /// 适用于以下控件<br/>
        /// </summary>
        /// <param name="target"></param>
        /// <param name="text"></param>
        public static void SetText(this Form target, string text)
        {
            if (target == null || !target.Created || !target.IsHandleCreated)
            {
                return;
            }

            if (target.InvokeRequired)
            {
                target.BeginInvoke(new Action<Form, string>(SetText), new object[] { target, text });
            }
            else
            {
                target.Text = text;
            }
        }

        /// <summary>
        /// Form标题Text更新
        /// </summary>
        /// <param name="target">Form</param>
        /// <param name="text">更新内容</param>
        /// <returns>bool</returns>
        [Obsolete("替代方法SetText")]
        public static bool ChangeFormText(Form target, string text)
        {
            if (target == null || !target.Created || !target.IsHandleCreated)
            {
                return true;
            }

            if (target.InvokeRequired)
            {
                target.Invoke(new Func<Form, string, bool>(ChangeFormText), target, text);
            }
            else
            {
                target.Text = text;
            }

            return true;
        }

        /// <summary>
        /// Control.Text设置（适用于所有子类）<br/>
        /// 适用于以下控件<br/>
        /// TextBox<br/>
        /// UILabel<br/>
        /// Label<br/>
        /// </summary>
        /// <param name="target">Control</param>
        /// <param name="text">值</param>
        public static void SetText(this Control target, string text)
        {
            if (target == null || !target.Created || !target.IsHandleCreated)
            {
                return;
            }

            if (target.InvokeRequired)
            {
                target.Invoke(new Action<Control, string>(SetText), new object[2] { target, text });
            }
            else
            {
                target.Text = text;
            }
        }

        /// <summary>
        /// UserControl.Text设置（适用于所有子类）<br/>
        /// 适用于以下控件<br/>
        /// UITextBox<br/>
        /// </summary>
        /// <param name="target">UserControl</param>
        /// <param name="text">值</param>
        public static void SetText(this UserControl target, string text)
        {
            if (target == null || !target.Created || !target.IsHandleCreated)
            {
                return;
            }

            if (target.InvokeRequired)
            {
                target.BeginInvoke(new Action<UserControl, string>(SetText), new object[2] { target, text });
            }
            else
            {
                target.Text = text;
            }
        }

        //ReadOnly属性设置
        /// <summary>
        /// DataGridView.ReadOnly设置
        /// </summary>
        /// <param name="target"></param>
        /// <param name="readOnly"></param>
        public static void SetReadOnly(this DataGridView target, bool readOnly)
        {
            if (target == null || !target.Created || !target.IsHandleCreated)
            {
                return;
            }

            if (target.InvokeRequired)
            {
                target.BeginInvoke(new Action<DataGridView, bool>(SetReadOnly), new object[] { target, readOnly });
            }
            else
            {
                target.ReadOnly = readOnly;
            }
        }

        //SelectedItem属性设置
        /// <summary>
        /// ComboBox.SelectedItem设置
        /// </summary>
        /// <param name="target"></param>
        /// <param name="text"></param>
        public static void SetSelectedItem(this ComboBox target, string text)
        {
            if (target == null || !target.Created || !target.IsHandleCreated)
            {
                return;
            }

            if (target.InvokeRequired)
            {
                target.BeginInvoke(new Action<ComboBox, string>(SetSelectedItem), new object[] { target, text });
            }
            else
            {
                target.SelectedItem = text;
            }
        }

        /// <summary>Button按钮Text更新</summary>
        /// <param name="targetControl">Button</param>
        /// <param name="text">Text</param>
        /// <param name="ver">版本</param>
        /// <returns>bool</returns>
        public static bool ChangeButtonText(Button targetControl, string text, string ver = "1.0")
        {
            return CommonTools.ControlHelper.ChangeButtonText(targetControl, text, ver);
        }

        /// <summary>Button按钮Enable更新</summary>
        /// <param name="targetControl">Button</param>
        /// <param name="targetEnabledStatus">bool</param>
        /// <param name="ver">版本</param>
        /// <returns>bool</returns>
        public static bool ChangeButtonEnableStatus(Button targetControl, bool targetEnabledStatus, string ver = "1.0")
        {
            return CommonTools.ControlHelper.ChangeButtonEnableStatus(targetControl, targetEnabledStatus, ver);
        }

        /// <summary>Button按钮BackColor更新</summary>
        /// <param name="targetControl">Button</param>
        /// <param name="targetColor">Color</param>
        /// <param name="ver">版本</param>
        /// <returns>bool（true：成功；false：失败；）</returns>
        public static bool ChangeButtonBackColor(Button targetControl, Color targetColor, string ver = "1.0")
        {
            return CommonTools.ControlHelper.ChangeButtonBackColor(targetControl, targetColor, ver);
        }



        /// <summary>DataGridView表格保存至本地CSV</summary>
        /// <param name="dgv">DataGridView表格</param>
        /// <param name="isContainTitle">true：获取标题；false：不获取标题</param>
        /// <param name="errorText">错误记录</param>
        /// <param name="timeColumn">小于等于0：不包含时间列；否则包含时间列</param>
        /// <param name="ver">版本</param>
        /// <returns>bool（true：保存OK；false：保存出错；）</returns>
        public static bool SaveDgvDataToCsvFile(DataGridView dgv, bool isContainTitle, ref string errorText, int timeColumn = 0, string ver = "1.0")
        {
            try
            {
                List<string> l = new List<string>();
                string path = null;

                if (!FileHelper.SaveFileDialogMethod("", FilterType.CSV, DefaultExt.CSV, true, false, true, ref path))
                {
                    return true;
                }

                if (string.IsNullOrEmpty(path))
                {
                    return true;
                }

                if (!GetDgvData(dgv, isContainTitle, ref l, timeColumn))
                {
                    throw new Exception("获取DataGridView数据出错");
                }

                if (l == null || l.Count == 0)
                {
                    throw new Exception("DataGridView数据为空");
                }

                if (!CsvHelper.WriteListStringToCsv(path, l, false))
                {
                    throw new Exception("将集合ListString写入到Csv文件出错");
                }

                return true;
            }
            catch (Exception ex)
            {
                errorText = "DataGridView表格保存至本地CSV出错：" + ex.Message;
                return false;
            }
        }
        /// <summary>DataGridView表格保存至本地CSV</summary>
        /// <param name="list">DataGridView表格</param>
        /// <param name="isContainTitle">true：包括标题；false：不包括标题；</param>
        /// <param name="errorText">错误记录</param>
        /// <param name="encoding"></param>
        /// <param name="ver">版本</param>
        /// <returns>bool</returns>
        public static bool SaveListTToCsvFile<T>(List<T> list, bool isContainTitle, ref string errorText, Encoding encoding = null, string ver = "1.0") where T : class
        {
            try
            {
                if (list == null || list.Count <= 0)
                {
                    return true;
                }

                if (encoding == null)
                {
                    encoding = Encoding.Unicode;
                }

                string path = null;
                if (!FileHelper.SaveFileDialogMethod("", FilterType.CSV, DefaultExt.CSV, true, true, true, ref path))
                {
                    errorText = "用户保存文件出错";
                    return false;
                }

                if (string.IsNullOrEmpty(path))
                {
                    return true;
                }

                DataTable dt = list.ListToDataTable();
                if (dt == null)
                {
                    errorText = "List转化为DataTable失败";
                    return false;
                }

                if (!CsvHelper.DataTableToCsvFile(dt, path, isContainTitle, encoding))
                {
                    errorText = "将DataTable写入到Csv文件失败";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                errorText = "DataGridView表格保存至本地CSV：" + ex.Message;
                return false;
            }
        }
        /// <summary>
        /// 获取DataGridView数据
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="isContainTitle">true：获取标题；false：不获取标题</param>
        /// <param name="listString">返回数据listString</param>
        /// <param name="timeColumn">小于等于0：不包含时间列；否则包含时间列</param>
        /// <param name="strSplit"></param>
        /// <returns>bool</returns>
        public static bool GetDgvData(DataGridView dgv, bool isContainTitle, ref List<string> listString, int timeColumn = 0, string strSplit = ",")
        {
            return CommonTools.ControlHelper.GetDgvData(dgv, isContainTitle, ref listString, timeColumn, strSplit);
        }

        /// <summary>
        /// 检查DataGridView指定列是否有重复值
        /// </summary>
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
        public static bool DgvRowUp(this UIDataGridView dgv)
        {
            bool ret = true;
            try
            {
                int index = dgv.CurrentCell.RowIndex;
                int col = dgv.CurrentCell.ColumnIndex;
                DataGridViewRow row = dgv.Rows[index];

                if (row == null)
                {
                    return ret;
                }

                if (index >= 1)
                {
                    dgv.Rows.Remove(dgv.Rows[index]);
                    dgv.Rows.Insert(index - 1, row);

                    dgv.ClearSelection();
                    dgv.CurrentCell = dgv.Rows[index - 1].Cells[col];
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
        /// <summary>单行下移一行</summary>
        /// <param name="dgv">DataGridView</param>
        public static bool DgvRowDown(this UIDataGridView dgv)
        {
            bool ret = true;
            try
            {
                int index = dgv.CurrentCell.RowIndex;
                int col = dgv.CurrentCell.ColumnIndex;
                DataGridViewRow row = dgv.Rows[index];

                if (row == null)
                {
                    return ret;
                }

                if (index < dgv.Rows.Count - 1)
                {
                    dgv.Rows.Remove(dgv.Rows[index]);
                    dgv.Rows.Insert(index + 1, row);

                    dgv.ClearSelection();
                    dgv.CurrentCell = dgv.Rows[index + 1].Cells[col];
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
        /// <summary>单行上移一行</summary>
        /// <param name="dgv">DataGridView</param>
        public static bool DgvUpRow(ref DataGridView dgv)
        {
            return CommonTools.ControlHelper.DgvUpRow(ref dgv);
        }
        /// <summary>单行下移一行</summary>
        /// <param name="dgv">DataGridView</param>
        public static bool DgvDownRow(ref DataGridView dgv)
        {
            return CommonTools.ControlHelper.DgvDownRow(ref dgv);
        }
        /// <summary>多行上移一行</summary>
        /// <param name="dgv">DataGridView</param>
        public static bool DgvUpRows(ref DataGridView dgv)
        {
            return CommonTools.ControlHelper.DgvUpRows(ref dgv);
        }
        /// <summary>多行下移一行</summary>
        /// <param name="dgv"></param>
        public static bool DgvDownRows(ref DataGridView dgv)
        {
            return CommonTools.ControlHelper.DgvDownRows(ref dgv);
        }
        /// <summary>FlowLayoutPanel移除指定控件 || 所有控件</summary>
        /// <param name="flow">FlowLayoutPanel</param>
        /// <param name="removedControl">指定控件</param>
        /// <param name="ver">版本</param>
        /// <returns>bool</returns>
        public static bool RemoveControl(FlowLayoutPanel flow, Control removedControl, string ver = "1.0")
        {
            return CommonTools.ControlHelper.RemoveControl(flow, removedControl, ver);
        }
        /// <summary>FlowLayoutPanel增加指定控件</summary>
        /// <param name="flow">FlowLayoutPanel</param>
        /// <param name="newControl">指定控件</param>
        /// <param name="ver">版本</param>
        /// <returns>bool</returns>
        public static bool AddControl(FlowLayoutPanel flow, Control newControl, string ver = "1.0")
        {
            return CommonTools.ControlHelper.AddControl(flow, newControl, ver);
        }

        /// <summary>DataGridView选定单元格复制</summary>
        /// <param name="dgv"></param>
        public static void Copy(this DataGridView dgv)
        {
            Clipboard.SetDataObject(dgv.GetClipboardContent());
        }

        /// <summary>DataGridView粘贴</summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public static bool DgvPaste(ref DataGridView dgv)
        {
            return CommonTools.ControlHelper.DgvPaste(ref dgv);
        }
    }
}
