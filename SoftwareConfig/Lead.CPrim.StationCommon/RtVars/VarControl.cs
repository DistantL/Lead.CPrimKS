using Lead.CPrim.ProxyTools.Authority;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lead.CPrim.StationCommon.RtVars
{
    public partial class VarControl : UserControl
    {
        #region Field
        /// <summary>实时变量管理器</summary>
        private RtDataVar _rtDataVar;
        #endregion



        #region Ctor
        public VarControl()
        {
            InitializeComponent();
        }

        public VarControl(RtDataVar rtDataVar)
        {
            InitializeComponent();
            _rtDataVar = rtDataVar;
            lbName.Text = _rtDataVar.Name;
        }
        #endregion



        #region Button_Event
        private void lbVar_DoubleClick(object sender, EventArgs e)
        {
            if (!AuthorityManager.Instance.VerifyLevel2Permission(false))
            {
                return;
            }

            if(MessageBox.Show("确定清除" + _rtDataVar.Name + "?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
            {
                return;
            }

            _rtDataVar.ClearValue();
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>名称设置</summary>
        /// <param name="name">名称</param>
        public void SetVarName(string name)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetVarName), name);
            }
            else
            {
                lbName.Text = name;
            }
        }
        /// <summary>值设置</summary>
        /// <param name="var">值</param>
        public void SetVarValue(object var)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<object>(SetVarValue), var);
            }
            else
            {
                lbVar.Text = var.ToString();
            }
        }
        #endregion
    }
}
