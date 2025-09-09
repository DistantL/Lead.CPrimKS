using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;

namespace Lead.CPrim.BaseParam
{
	public partial class PosEditorForm : UIForm
    {
        #region Field
        /// <summary>当前轴组名称</summary>
        private string _cartName;

        /// <summary>当前轴组Id</summary>
        private Guid _controlId;

        /// <summary>轴组元件集合[轴组名称,轴组接口]</summary>
        private Dictionary<string, IEleCartesian> _eleCartes = new Dictionary<string, IEleCartesian>();

        private Control _platformControl;

        /// <summary>
        /// 点位列表（用来对比点位变更）
        /// </summary>
        private List<Pos> _posCompare = new List<Pos>();
        #endregion



        #region Prop
        public bool IsSave { get; set; } = false;

        /// <summary>
        /// 点位列表
        /// </summary>
        public List<Pos> Pos { get; set; } = new List<Pos>();

        /// <summary>
        /// 轴组名称
        /// </summary>
        public string Pos_Cartesian { get; set; }
        #endregion



        #region Ctor
        public PosEditorForm()
        {
            InitializeComponent();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region Event_System
        private void PosEditorForm_Load(object sender, EventArgs e)
        {
            _eleCartes.Clear();
            combPlatForm.Items.Clear();
            foreach (IEle ele in ElesManagerTransfer.GetAllIEle())
            {
                bool flag = ele.EleTypeName == "Cartesian";
                if (flag)
                {
                    _eleCartes.Add(NLocalizer.GetString(ele.Name, ele.Name), (IEleCartesian)ele);
                    combPlatForm.Items.Add(NLocalizer.GetString(ele.Name, ele.Name));
                }
            }

			combPlatForm.Text = Pos_Cartesian;
			if (!string.IsNullOrWhiteSpace(Pos_Cartesian) && combPlatForm.Items.Contains(Pos_Cartesian))
            {
				combPlatForm.Enabled = false;
				btnEnterPlatForm.Enabled = false;
				BtnEnterPlatForm_Click(null, null);
            }

            OnLanguageChanged();
        }

        private void PosEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_platformControl != null)
            {
                _posCompare = _eleCartes[_cartName].CartDebugUi_GetPosList(_controlId);
                if(!PosCompare(Pos, _posCompare))
                {
                    string info = NLocalizer.GetString("Lead_CPrim_DynamicParam_PosEditorForm_Tip_CoonfirmToCloseWithoutSave", "点位未保存，确认关闭?");
                    if(!this.ShowAskDialog(info, false))
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    IsSave = true;
                }
            }
        }
        #endregion



        #region Event_Button
        /// <summary>
        /// 确认轴组
        /// </summary>
        private void BtnEnterPlatForm_Click(object sender, EventArgs e)
        {
            try
            {
                pnlControl.Controls.Clear();
                if (!string.IsNullOrWhiteSpace(combPlatForm.Text))
                {
                    string cartesName = combPlatForm.Text;
                    if (string.IsNullOrEmpty(cartesName))
                    {
                        throw new Exception(NLocalizer.GetString("Lead_CPrim_DynamicParam_PosEditorForm_ErrMsg_CartesianNameIsEmpty", "请先选择轴组!"));
                    }
                    _cartName = cartesName;
                    if (!_eleCartes.ContainsKey(_cartName))
                    {
                        throw new Exception(NLocalizer.GetString("Lead_CPrim_DynamicParam_PosEditorForm_ErrMsg_CartesianNameNoFind", "未找到轴组名称:") + _cartName);
                    }
                    IEleCartesian p = _eleCartes[_cartName];
                    _controlId = Guid.NewGuid();
                    _platformControl = p.NewCartDebugUi(_controlId, p, Pos, true);
                    _platformControl.Dock = DockStyle.Fill;
                    pnlControl.Controls.Add(_platformControl);
                }
            }
            catch (Exception ex)
            {
                Notification.ShowError(NLocalizer.GetString("Lead_CPrim_DynamicParam_PosEditorForm_ErrMsg_ComfirmCartesianFail", "确认轴组失败:") + ex.Message, 0);
            }
        }

        /// <summary>
        /// 应用
        /// </summary>
        private void BtnApply_Click(object sender, EventArgs e)
        {
            Pos.Clear();
            foreach (Pos a in _eleCartes[_cartName].CartDebugUi_GetPosList(_controlId))
            {
                Pos.Add(a);
            }
        }
        #endregion



        #region Method_InternalUsing
        public void OnLanguageChanged()
        {
            Text = NLocalizer.GetString("Lead_CPrim_DynamicParam_PosEditorForm_Title", "点位编辑");
            lb_CartesianSelect.Text = NLocalizer.GetString("Lead_CPrim_DynamicParam_PosEditorForm_CartesianSelect", "轴组选择");
            btnEnterPlatForm.Text = NLocalizer.GetString("Lead_CPrim_DynamicParam_PosEditorForm_ConfirmSelect", "确认轴组");
            btnApply.Text = NLocalizer.GetString("Lead_CPrim_DynamicParam_PosEditorForm_Apply", "应用");
        } 

        /// <summary>
        /// 点位集合对比
        /// </summary>
        /// <param name="comparePos1"></param>
        /// <param name="comparePos2"></param>
        /// <returns></returns>
        private bool PosCompare(List<Pos> comparePos1, List<Pos> comparePos2)
        {
            if(comparePos1 == null && comparePos2 == null)
            {
                return true;
            }

            if(comparePos1 == null && comparePos2 != null)
            {
                return false;
            }

            if(comparePos1 != null && comparePos2 == null)
            {
                return false;
            }

            if(comparePos1.Count != comparePos2.Count)
            {
                return false;
            }

            foreach (var pos1 in comparePos1)
            {
                bool isFind = false;
                foreach (var pos2 in comparePos2)
                {
                    if(
                        pos1.Name == pos2.Name &&
                        pos1.X == pos2.X &&
                        pos1.Y == pos2.Y &&
                        pos1.Z == pos2.Z &&
                        pos1.U == pos2.U &&
                        pos1.V == pos2.V &&
                        pos1.W == pos2.W)
                    {
                        isFind = true;
                        break;
                    }
                }

                if(!isFind)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion
    }
}
