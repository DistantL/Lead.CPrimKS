using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.Win32;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.Authority.Forms
{
    public partial class InputAccessarySN_Form : UIForm
    {
        #region Field
        Stopwatch _stopwatch = new Stopwatch();
        #endregion



        #region Prop
        public string Old_SN { get; private set; }

        public string New_SN { get; private set; }
        #endregion



        #region Ctor
        public InputAccessarySN_Form(string title, string operatorId)
        {
            InitializeComponent();
            lblState.Text = "";

            labSelect.Text = title;
            tb_Opeartor.Text = operatorId;

            if (AuthorityManager.Instance.AccessaryNames != null && AuthorityManager.Instance.AccessaryNames.Count > 0)
            {
                cb_AccessaryName.DataSource = AuthorityManager.Instance.AccessaryNames;
                cb_AccessaryName.Text = AuthorityManager.Instance.AccessaryNames[0];
            }

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;

            //不允许复制、粘贴以及右键操作；
            //txtNewSN.ShortcutsEnabled = false;
        }
        #endregion



        #region EventSystem
        private void txtNewSN_TextChanged(object sender, EventArgs e)
        {
            string txt = txtNewSN.Text;
            if (string.IsNullOrWhiteSpace(txt) || txt.Length < 5)
            {
                return;
            }

            string num = EventManager.GetLotno(txtNewSN.Text);
            if (!string.IsNullOrEmpty(num))
            {
                lblState.Text = $"可用数量：{num}";
            }
        }

        private void txtNewSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            //// 8：Backspace键；127：Del键；
            //if (e.KeyChar != (char)8 && e.KeyChar != (char)127)
            //{
            //    e.Handled = true;
            //}
        }

        private void txtNewSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (_stopwatch == null)
            {
                _stopwatch = new Stopwatch();
            }

            _stopwatch.Restart();
        }

        private void txtNewSN_KeyUp(object sender, KeyEventArgs e)
        {
            if (_stopwatch.ElapsedMilliseconds > 50)
            {
                txtNewSN.Clear();
            }
            _stopwatch?.Stop();
        }

        private void cb_AccessaryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AuthorityManager.Instance.Dic_AccessaryInfos.ContainsKey(cb_AccessaryName.Text) && AuthorityManager.Instance.Dic_AccessaryInfos[cb_AccessaryName.Text] != null)
            {
                txtOldSN.Text = AuthorityManager.Instance.Dic_AccessaryInfos[cb_AccessaryName.Text].NewSN;
            }
            else
            {
                txtOldSN.Text = string.Empty;
            }
            txtNewSN.Text = string.Empty;
        }
        #endregion



        #region EventButton

        private void bt_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cb_AccessaryName.Text))
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_InputAccessarySN_Form_Errmsg_AccessaryNameisEmpty", "辅料名称为空"));
                return;
            }
            if (string.IsNullOrWhiteSpace(tb_Opeartor.Text))
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_InputAccessarySN_Form_Errmsg_OpeartorisEmpty", "操作员卡号为空"));
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNewSN.Text))
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_InputAccessarySN_Form_Errmsg_SNisEmpty", "SN为空"));
                return;
            }
            if (txtNewSN.Text == txtOldSN.Text)
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_InputAccessarySN_Form_Errmsg_NewSNisSaveToOld", "辅料码：新码旧码相同"));
                return;
            }
            if (!txtNewSN.Text.IsNumberOrEngLishUpper())
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_InputAccessarySN_Form_Errmsg_SNisUp", "SN不全为大写"));
                return;
            }

            var accessaryInfo = AuthorityManager.Instance.AccessaryInfos.FirstOrDefault(p => p.Item1 == cb_AccessaryName.Text);
            if (accessaryInfo == default)
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_InputAccessarySN_Form_Errmsg_SNCodeLengthSetErr", "辅料码长度设置异常"));
                return;
            }

            int.TryParse(accessaryInfo.Item2, out int codeLength);
            if (txtNewSN.Text.Length < codeLength)
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_InputAccessarySN_Form_Errmsg_SNCodeLengthErr", "辅料码长度错误"));
                return;
            }

            int ret = MongodbHelper.InsertOne<AccessaryChangeInfo>(new AccessaryChangeInfo()
            {
                AccessaryName = cb_AccessaryName.Text,
                CreateTime = DateTime.Now,
                Operator = tb_Opeartor.Text,
                OldSN = txtOldSN.Text,
                NewSN = txtNewSN.Text
            }, "AccessaryChangeInfo");
            if (ret == 0)
            {
                if (AuthorityManager.Instance.Dic_AccessaryInfos.ContainsKey(cb_AccessaryName.Text))
                {
                    AuthorityManager.Instance.Dic_AccessaryInfos[cb_AccessaryName.Text] = new AccessaryChangeInfo()
                    {
                        AccessaryName = cb_AccessaryName.Text,
                        CreateTime = DateTime.Now,
                        Operator = tb_Opeartor.Text,
                        OldSN = txtOldSN.Text,
                        NewSN = txtNewSN.Text
                    };
                }
                Old_SN = txtOldSN.Text;
                New_SN = txtNewSN.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_InputAccessarySN_Form_Errmsg_SaveToDbFail", "保存数据库失败"));
            }
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion



        #region MethodInternalUsing
        void OnLanguageChanged()
        {
            bt_OK.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_InputAccessarySN_Form_btOK", "确认");
            bt_Cancel.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_InputAccessarySN_Form_btCancel", "取消");

            lb_AccessaryName.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_InputAccessarySN_Form_AccessaryName", "辅料名称 :");
            lb_Operator.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_InputAccessarySN_Form_Operator", "操作员卡号 :");
            lb_Old_SN.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_InputAccessarySN_Form_Old_SN", "旧料号 :");
            lb_New_SN.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_InputAccessarySN_Form_New_SN", "新料号 :");
        }
        #endregion
    }



    [JsonObject(/*Could not decode attribute arguments.*/)]
    public class AccessaryChangeInfo
    {
        public string Operator { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; }

        public string AccessaryName { get; set; }

        public string OldSN { get; set; }

        public string NewSN { get; set; }
    }
}
