using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lead.CPrim.StationCommon.DataArea
{
    /// <summary>
    /// 全局变量自定义类表单
    /// </summary>
    public partial class GlobalVariableClassFrm : UIForm
    {
        #region EventHander && Event
        public delegate void PropertiesValueSet(GlobalVariableClass varObj, List<Property> properties);

        /// <summary>类型CLASS全局变量保存时发生</summary>
        public event PropertiesValueSet OnPropertiesValueSet;
        #endregion



        #region Field
        /// <summary></summary>
        private GlobalVariableClass curGlobalVariable;
        #endregion



        #region Ctor
        /// <summary>
        /// Ctor无参
        /// </summary>
        public GlobalVariableClassFrm()
        {
            InitializeComponent();

            Style = UIStyle.Gray;
            Array array = Enum.GetValues(typeof(DataType));
            for (int i = 0; i < array.Length; i++)
            {
                string str = array.GetValue(i).ToString();
                if (!str.IsNullOrEmpty())
                {
                    PropertyType.Items.Add(str);
                }
            }
        }
        #endregion



        #region Event_System
        /// <summary>
        /// 当单元格收到焦点时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvProperties_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProperties.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && e.RowIndex != -1)
            {
                SendKeys.Send("{F4}");
            }
        }

        /// <summary>
        /// 单元格状态因其内容更改而更改时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvProperties_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvProperties.IsCurrentCellDirty)
            {
                dgvProperties.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        #endregion



        #region Button_Event
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            dgvProperties.Rows.Add();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonRemove_Click(object sender, EventArgs e)
        {
            if (dgvProperties.Rows.Count < 1)
            {
                return;
            }

            dgvProperties.Rows.RemoveAt(dgvProperties.CurrentRow.Index);
        }
        /// <summary>
        /// 应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonApply_Click(object sender, EventArgs e)
        {
            List<Property> tempProperties = new List<Property>();
            foreach (DataGridViewRow row in dgvProperties.Rows)
            {
                Property property = new Property(row.Cells[1].Value.ToString(),
                    row.Cells[0].Value.ToString(),
                    curGlobalVariable.ClassName);

                if (row.Cells[2].Value != null)
                {
                    property.Value = DataHelper.StringToObjectByDataType(row.Cells[2].Value.ToString(), DataHelper.StringToDataType(row.Cells[1].Value.ToString()));
                }

                tempProperties.Add(property);
            }
            OnPropertiesValueSet?.Invoke(curGlobalVariable, tempProperties);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProperties.Rows.Count > 0)
                {
                    string err = "";
                    if (ControlHelper.CheckDgvCellRepeat(dgvProperties, ref err))
                    {
                        throw new Exception(err);
                    }

                    curGlobalVariable.Properties.Clear();
                    foreach (DataGridViewRow row in dgvProperties.Rows)
                    {
                        Property newProperty = new Property(row.Cells[1].Value.ToString(),
                            row.Cells[0].Value.ToString(),
                            curGlobalVariable.ClassName);

                        curGlobalVariable.Properties.Add(newProperty);
                    }
                }
                else
                {
                    curGlobalVariable.Properties.Clear();
                }

                OnPropertiesValueSet?.Invoke(curGlobalVariable, curGlobalVariable.Properties);
            }
            catch (Exception ex)
            {
                Notification.ShowError("全局变量自定义类型保存失败：" + ex.Message);
            }
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// 初始化表单
        /// </summary>
        /// <param name="operationMode"></param>
        /// <param name="globalVariable"></param>
        public void IntiForm(OperationMode operationMode, GlobalVariableClass globalVariable)
        {
            SetOperateMode(operationMode);

            curGlobalVariable = globalVariable;
            if (curGlobalVariable.Properties == null)
            {
                curGlobalVariable = new GlobalVariableClass(curGlobalVariable.ClassName);
            }

            LoadGlobalVariable();
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// 打开模式
        /// </summary>
        /// <param name="operationMode"></param>
        private void SetOperateMode(OperationMode operationMode)
        {
            switch (operationMode)
            {
                case OperationMode.ConfigProperty:
                    toolStripButtonApply.Visible = false;
                    PropertyValue.ReadOnly = true;
                    break;

                case OperationMode.SetPropertyValue:
                    toolStripButtonSave.Visible = false;
                    toolStripButtonAdd.Visible = false;
                    toolStripButtonRemove.Visible = false;
                    PropertyType.ReadOnly = true;
                    PropertyName.ReadOnly = true;
                    break;

                case OperationMode.ReadProperty:
                    toolStripButtonSave.Visible = false;
                    toolStripButtonAdd.Visible = false;
                    toolStripButtonRemove.Visible = false;
                    PropertyType.ReadOnly = true;
                    PropertyName.ReadOnly = true;
                    toolStripButtonApply.Visible = false;
                    PropertyValue.ReadOnly = true;
                    break;
            }
        }

        /// <summary>
        /// 加载内容
        /// </summary>
        private void LoadGlobalVariable()
        {
            label1.Text = label1.Tag.ToString() + curGlobalVariable.ClassName;
            if (curGlobalVariable.Properties == null || curGlobalVariable.Properties.Count <= 0)
            {
                return;
            }

            foreach (Property property in curGlobalVariable.Properties)
            {
                int index = dgvProperties.Rows.Add();
                dgvProperties.Rows[index].Cells[0].Value = property.Name;
                dgvProperties.Rows[index].Cells[1].Value = property.ValType.ToString();
                dgvProperties.Rows[index].Cells[2].Value = property.Value?.ToString();
            }
        }
        #endregion
    }
}
