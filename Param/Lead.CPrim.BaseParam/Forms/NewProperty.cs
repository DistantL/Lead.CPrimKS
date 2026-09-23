using Lead.CPrim.BaseParam;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Lead.CPrim.BaseParam
{
    public partial class NewProperty : UIForm
    {
        #region Field
        private Property _property;

        /// <summary>保存标志</summary>
        public bool AddPropertApply = false;

        /// <summary>属性分组</summary>
        public List<string> groups = new List<string>();

        /// <summary>全局参数属性</summary>
        public Property newProperty;

        /// <summary>自定义类型文件夹目录</summary>
        public string UserDefinePath;
        #endregion



        #region Ctor
        public NewProperty(Property property = null)
        {
            this.InitializeComponent();

            _property = property;
            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region Event_System
        private void NewProperty_Load(object sender, EventArgs e)
        {
            Array temp = Enum.GetValues(typeof(BaseParam.DataType));
            for (int i = 0; i < temp.Length; i++)
            {
                string info = temp.GetValue(i).ToString();
                this.cmbVariableType.Items.Add(info);
            }
            foreach (string str in this.groups)
            {
                this.cmbGroup.Items.Add(str);
            }
            foreach (IEle ele in ElesManagerTransfer.GetAllIEle())
            {
                if (ele.EleTypeName == "Cartesian")
                {
                    cmb_Cartesian.Items.Add(ele.Name);
                }
            }

            if (_property != null)
            {
                cmbVariableType.SelectedItem = _property.valType.ToString();
                txbName.Text = _property.Name.ToString();
                txbDisp.Text = _property.DisplayName.ToString();
                cmbGroup.SelectedItem = _property.Category.ToString();
                txbComb.Text = _property.CombMsg.ToString();
                cmb_Cartesian.SelectedItem = _property.Cartesian.ToString();
                ComboBox1_SelectedIndexChanged(null, null);

                if (_property.Name.ToString() == "运行模式")
                {
                    txbName.Enabled = false;
                    cmbVariableType.Enabled = false;
                    txbComb.ReadOnly = true;
                }
            }
        }

        public void OnLanguageChanged()
        {
            this.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_NewProperty_Title", "添加/修改属性");
            lb_DataType.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_NewProperty_DataType", "变量类型");
            lb_IndexName.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_NewProperty_IndexName", "索引名称");
            lb_DisplayName.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_NewProperty_DisplayName", "显示名称");
            lb_GroupName.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_NewProperty_GroupName", "分组");
            labUdt.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_NewProperty_UserDefinedDataType", "用户自定义数据");
            lb_Cartesian.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_NewProperty_CartesianName", "轴组");
            labComb.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_NewProperty_Comb", "下拉框选项");
            btnAddProperty.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_NewProperty_AddProperty", "确认");
            btnCancel.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_NewProperty_Cancel", "取消");
        }
        #endregion



        #region Event_Button
        /// <summary>变量类型切换</summary>
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Enum.TryParse(cmbVariableType.SelectedItem.ToString(), out BaseParam.DataType dataType))
            {
                switch (dataType)
                {
                    case BaseParam.DataType.UserDefine:
                        {
                            string path = this.UserDefinePath;
                            FileInfo[] files = Directory.Exists(path)
                                ? new DirectoryInfo(path).GetFiles("*.udt")
                                : new FileInfo[0];
                            this.cmbUdt.Items.Clear();
                            if (files.Length != 0)
                            {
                                foreach (FileInfo a in files)
                                {
                                    this.cmbUdt.Items.Add(a.Name);
                                }
                            }
                            this.labUdt.Visible = true;
                            this.cmbUdt.Visible = true;
                            this.txbComb.Visible = false;
                            this.labComb.Visible = false;
                            this.lb_Cartesian.Visible = false;
                            this.cmb_Cartesian.Visible = false;
                        }
                        break;
                    case BaseParam.DataType.Comb:
                        {
                            this.txbComb.Visible = true;
                            this.labComb.Visible = true;
                            this.labUdt.Visible = false;
                            this.cmbUdt.Visible = false;
                            this.lb_Cartesian.Visible = false;
                            this.cmb_Cartesian.Visible = false;
                        }
                        break;
                    case BaseParam.DataType.Point:
                        {
                            this.labUdt.Visible = false;
                            this.cmbUdt.Visible = false;
                            this.txbComb.Visible = false;
                            this.labComb.Visible = false;
                            this.lb_Cartesian.Visible = true;
                            this.cmb_Cartesian.Visible = true;
                        }
                        break;
                    default:
                        {
                            this.labUdt.Visible = false;
                            this.cmbUdt.Visible = false;
                            this.txbComb.Visible = false;
                            this.labComb.Visible = false;
                            this.lb_Cartesian.Visible = false;
                            this.cmb_Cartesian.Visible = false;
                        }
                        break;
                }
            }
        }

        /// <summary>添加属性</summary>
        private void BtnAddProperty_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txbName.Text.Trim())
                || this.cmbVariableType.SelectedItem == null
                || string.IsNullOrEmpty(this.cmbVariableType.SelectedItem.ToString()))
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_CommonParam_NewProperty_ErrMsg_NameIsEmpty", "请确保名称和类型不为空!"));
            }
            else
            {
                string name = this.txbName.Text;
                string type = this.cmbVariableType.SelectedItem.ToString();
                string disp = this.txbDisp.Text;
                string Group = this.cmbGroup.Text;
                string CombTxt = this.txbComb.Text;
                string UDTPath = string.Empty;
                if (type == BaseParam.DataType.UserDefine.ToString() && cmbUdt.SelectedItem == null)
                {
                    MessageBox.Show("请先通过“新建自定义类型”创建类型文件，再选择该类型。");
                    return;
                }
                string Cartesian = (this.cmb_Cartesian.SelectedItem ?? string.Empty).ToString();
                if (cmbUdt.SelectedItem != null)
                {
                    UDTPath = Path.Combine(this.UserDefinePath, this.cmbUdt.SelectedItem.ToString());
                }

                if (_property == null)
                {
                    _property = new Property();
                    newProperty = _property.AddProperty(type, name, Group, disp, CombTxt, UDTPath, Cartesian);
                }
                else
                {
                    newProperty = _property.AddProperty(type, name, Group, disp, CombTxt, UDTPath, Cartesian, _property.Value, _property.ReadOnly, _property.Visible);
                }

                AddPropertApply = true;
                Close();
            }
        }

        /// <summary>取消</summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        } 
        #endregion
    }
}
