using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Properties;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.ProxyTools.Authority.Forms
{
    public partial class AuthorityManagerUI : UIPage
    {
        #region Field
        /// <summary>标签集合</summary>
        UILabel[] lbls = new UILabel[] { };

        /// <summary>表格数据绑定源</summary>
        public List<AuthorityDb> listAuthorityDbs;

        /// <summary>管理员</summary>
        AuthorityDb _authorityAdministrator;
        #endregion



        #region Ctor
        public AuthorityManagerUI()
        {
            InitializeComponent();

            {
                this.SetStyle();

                tlpMain.SetStyle();

                pnlInfo.SetStyle();
                pnlMain.SetStyle();

                btnAdd.SetStyle();
                btnDel.SetStyle();

                txtUserName.SetStyle();
                txtUserId.SetStyle();
                txtID.SetStyle();
                txtPassWord.SetStyle();

                cboLevel.SetStyle(12.0f, FontStyle.Regular);

                lbls = new UILabel[] { lblLevel1, lblLevel1Count, lblLevel2, lblLevel2Count, lblLevel3, lblLevel3Count, lb_UserName, lb_Password, lb_Level };
                foreach (var lbl in lbls)
                {
                    lbl.SetStyle(12.0f, FontStyle.Regular);
                }
            }

            dgvData.SetStyle();
            dgvData.ReadOnly = true;

            _authorityAdministrator = new AuthorityDb { UserName = "Administrator", Level = OpLevel.Level3, PassWord = "0D11E45ECAC0F038F6423C52FE22718C" };

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region System_Event
        private void Form1_Load(object sender, EventArgs e)
        {
            cboLevel.DataSource = new string[] { "Level1", "Level2", "Level3" };

            ClearData();

            DataRefresh();
        }

        private void dgv_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int colum = e.ColumnIndex;
            if (row < 0 || colum < 0)
            {
                return;
            }

            ClearData();

            string name = dgvData[0, row].Value?.ToString();
            if (name.IsNullOrWhiteSpace() || name == "Administrator")
            {
                return;
            }
            txtUserName.Text = dgvData[0, row].Value?.ToString();
            txtUserId.Text = dgvData[1, row].Value?.ToString();
            txtID.Text = dgvData[2, row].Value?.ToString();
            txtPassWord.Text = DESHelper.Decrypt(dgvData[3, row].Value.ToString(), Resources.passWordKey);
            cboLevel.SelectedItem = dgvData[4, row].Value?.ToString();
        }

        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            if (dgvData.Rows[e.RowIndex].Cells[4].Value?.ToString() == "Level3")
            {
                if (dgvData.Rows[e.RowIndex].Cells[0].Value?.ToString() == "Administrator")
                {
                    dgvData.Rows[e.RowIndex].DefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = Color.IndianRed,
                    };
                }
                else
                {
                    dgvData.Rows[e.RowIndex].DefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = Color.LightBlue,
                    };
                }
            }
            if (dgvData.Rows[e.RowIndex].Cells[4].Value?.ToString() == "Level2")
            {
                dgvData.Rows[e.RowIndex].DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.LightGreen,
                };
            }
        }
        #endregion



        #region Button_Event
        /// <summary>新增</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Judge();

                string name;
                int ret = -1;
                {
                    name = txtUserName.Text;
                    MongodbHelper.QueryOneFirst<AuthorityDb>("UserName", name, out var author, UIGlobal.AuthorityDb, null);
                    if (author != null)
                    {
                        throw new Exception(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ErrMsg_UserNameAlreadyExist", "用户名已存在"));
                    }
                }

                {
                    name = txtUserId.Text;
                    MongodbHelper.QueryOneFirst<AuthorityDb>("UserId", name, out var author, UIGlobal.AuthorityDb, null);
                    if (author != null)
                    {
                        throw new Exception(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ErrMsg_UserIDAlreadyExist", "用户ID已存在"));
                    }
                }

                {
                    name = txtID.Text;
                    MongodbHelper.QueryOneFirst<AuthorityDb>("ID", name, out var author, UIGlobal.AuthorityDb, null);
                    if (author != null)
                    {
                        throw new Exception(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ErrMsg_IDAlreadyExist", "卡号已存在"));
                    }
                }

                ret = MongodbHelper.InsertOne(new AuthorityDb
                {
                    Level = (OpLevel)Enum.Parse(typeof(OpLevel), cboLevel.SelectedItem.ToString()),
                    UserName = txtUserName.Text,
                    UserId = txtUserId.Text,
                    ID = txtID.Text,
                    PassWord = DESHelper.Encrypt(txtPassWord.Text.Trim(), Resources.passWordKey),
                }, UIGlobal.AuthorityDb);

                if (ret == 0)
                {
                    ShowSuccessTip(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_Tip_AddSuccess", "用户增加成功"));
                    DataRefresh();
                }
                else
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ErrMsg_FuncBack", "函数反馈:") + ret);
                }
            }
            catch (Exception ex)
            {
                ShowErrorDialog(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ErrMsg_AddFail", "新增失败:") + ex.Message);
            }
        }

        /// <summary>变更</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Judge();

                string name = txtUserName.Text;
                AuthorityDb author = null;
                int ret = -1;
                MongodbHelper.QueryOneFirst<AuthorityDb>("UserName", name, out author, UIGlobal.AuthorityDb, null);
                if (author == null)
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ErrMsg_UserNameNoExist", "该用户名不存在"));
                }

                string newPwd = DESHelper.Encrypt(txtPassWord.Text.Trim(), Resources.passWordKey);
                if (author.PassWord != newPwd || author.Level != (OpLevel)Enum.Parse(typeof(OpLevel), cboLevel.SelectedItem.ToString()))
                {
                    ret = MongodbHelper.ReplaceOne("UserName", author.UserName, new AuthorityDb
                    {
                        Level = (OpLevel)Enum.Parse(typeof(OpLevel), cboLevel.SelectedItem.ToString()),
                        UserName = name,
                        PassWord = DESHelper.Encrypt(txtPassWord.Text.Trim(), Resources.passWordKey),
                    }, UIGlobal.AuthorityDb);
                    if (ret == 0)
                    {
                        ShowSuccessTip(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_Tip_UpDateSuccess", "用户更新成功"));
                        DataRefresh();
                    }
                    else
                    {
                        throw new Exception(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ErrMsg_FuncBack", "函数反馈:") + ret);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorDialog(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ErrMsg_UpDateFail", "更新失败:")  + ex.Message);
            }
        }

        /// <summary>删除</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                int ret = -1;
                string name = txtUserName.Text;
                if (name == "Administrator")
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ErrMsg_ConnotDeleteAdminLevel", "无法删除高级权限"));
                }
                AuthorityDb author = null;
                MongodbHelper.QueryOneFirst("UserName", name, out author, UIGlobal.AuthorityDb, null);
                if (author == null)
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ErrMsg_UserNameNoExist", "该用户名不存在"));
                }

                ret = MongodbHelper.DeleteOne<AuthorityDb>("UserName", author.UserName, UIGlobal.AuthorityDb);

                if (ret == 0)
                {
                    ShowSuccessTip(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_Tip_DeleteSuccess", "删除成功"));
                }
                else
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ErrMsg_FuncBack", "函数反馈:") + ret);
                }
                DataRefresh();
            }
            catch (Exception ex)
            {
                ShowErrorDialog(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ErrMsg_DeleteFail", "删除失败:") + ex.Message);
            }
        }
        #endregion



        #region Method_InternalUsing

        /// <summary>UI刷新</summary>
        private void DataRefresh()
        {
            MongodbHelper.QueryAll(out listAuthorityDbs, UIGlobal.AuthorityDb);
            if (listAuthorityDbs == null)
            {
                listAuthorityDbs = new List<AuthorityDb>();
            }
            listAuthorityDbs.Insert(0, _authorityAdministrator);
            dgvData.DataSource = listAuthorityDbs;
            dgvData.Refresh();

            int i1 = 0;
            int i2 = 0;
            int i3 = 0;
            foreach (var item in listAuthorityDbs)
            {
                if (item.Level == OpLevel.Level1)
                {
                    i1++;
                }
                else if (item.Level == OpLevel.Level2)
                {
                    i2++;
                }
                else if (item.Level == OpLevel.Level3)
                {
                    i3++;
                }
            }
            lblLevel1Count.Text = i1.ToString();
            lblLevel2Count.Text = i2.ToString();
            lblLevel3Count.Text = i3.ToString();
        }

        /// <summary>防呆</summary>
        private void Judge()
        {
            if (txtUserName.Text.IsNullOrWhiteSpace())
            {
                throw new Exception(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ErrMsg_UserNameIsEmpty", "用户名为空"));
            }
            if (txtUserId.Text.IsNullOrWhiteSpace())
            {
                throw new Exception(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ErrMsg_UserIDIsEmpty", "用户Id为空"));
            }
            if (txtID.Text.IsNullOrWhiteSpace())
            {
                throw new Exception(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ErrMsg_IDIsEmpty", "卡号为空"));
            }
            if (txtPassWord.Text.IsNullOrWhiteSpace())
            {
                throw new Exception(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ErrMsg_PasswordIsEmpty", "密码为空"));
            }
            if (string.IsNullOrEmpty(cboLevel.SelectedItem?.ToString()))
            {
                throw new Exception(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ErrMsg_LevelIsEmpty", "权限为空"));
            }
        }

        /// <summary>数据清空</summary>
        private void ClearData()
        {
            txtUserName.Clear();
            txtUserId.Clear();
            txtID.Clear();
            txtPassWord.Clear();
            cboLevel.SelectedItem = null;
        }
        #endregion

        public void OnLanguageChanged()
        {
            lb_UserName.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_UserName", "用户名:");
            lb_UserId.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_UserId", "用户ID:");
            lb_ID.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_Id", "卡号:");
            lb_Password.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_Password", "密码:");

            string str_Level = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_Level", "权限");
            lb_Level.Text = str_Level + ":";
            lblLevel1.Text = str_Level + "1:";
            lblLevel2.Text = str_Level + "2:";
            lblLevel3.Text = str_Level + "3:";
            btnAdd.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_Add", "新建");
            btnDel.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_Delete", "删除");

            userNameDataGridViewTextBoxColumn.HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ColUserName", "用户名");
            UserId.HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ColUserID", "用户ID");
            ID.HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ColID", "卡号");
            passWordDataGridViewTextBoxColumn.HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ColPassword", "密码");
            levelDataGridViewTextBoxColumn.HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AuthorityManagerUI_ColLevel", "权限等级");
        }
    }
}
