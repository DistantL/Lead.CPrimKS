using Lead.CPrim.BaseParam;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lead.CPrim.CommonParam
{
    public partial class CommonParamForm : UIPage
    {
        #region Event_Define

        #endregion



        #region Field
        /// <summary>属性表绑定对象</summary>
        private PropertyManageCls Pmcls = new PropertyManageCls();

        /// <summary>点位集合</summary>
        public Dictionary<string, List<Pos>> DicPos = new Dictionary<string, List<Pos>>();

        /// <summary>
        /// 位置点对应的轴组 没有为null
        /// </summary>
        public Dictionary<string, string> DicCartesian = new Dictionary<string, string>();


        /// <summary>用户自定义类目录</summary>
        private string UserDefineDir;

        /// <summary>全局参数全路径</summary>
        private string CurParaPath;

        /// <summary>System.Environment.CurrentDirectory;</summary>
        public string CurSysDirPaht;

        /// <summary>全局参数显示控件对象</summary>
        private static CommonParamForm _instance = new CommonParamForm();




        #endregion



        #region Prop
        public static CommonParamForm Instance
        {
            get
            {
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
        #endregion



        #region Ctor
        private CommonParamForm()
        {
            InitializeComponent();
            // 模式参数编辑已迁至换型参数页，全局参数不再管理运行模式。
            tlpMain.Controls.Remove(groupBox1);
            groupBox1.Dispose();
            pg.ContextMenuStrip = null;
            tlpMain.SetColumnSpan(pg, 2);
            AuthorityManager.OnUpdateLevel += InstanceUpdateLevel;
            pg.MouseWheel += Pg_CommonParamBase_MouseWheel;

            NLocalizer.LanguageChanged += OnLanguageChanged;

            CommonParam.OnUpdateProperty += InstanceUpdateProperty;
            Disposed += (sender, args) => CommonParam.OnUpdateProperty -= InstanceUpdateProperty;
            parameterBinding = new ParameterUiBinding(this, pg, ((CommonParam)CommonParam.Instance).Updates,
                () => Pmcls.Cast<Property>(), RefreshAssignedPoints);
        }
        #endregion



        #region Event_System
        #endregion



        #region Event_Instance
        /// <summary> 权限等级改变时发生响应</summary>
        /// <param name="level">权限等级</param>
        private void InstanceUpdateLevel(OpLevel level)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<OpLevel>(InstanceUpdateLevel), level);
            }
            else if (AuthorityManager.Instance.VerifyLevel3Permission(false))
            {
                tsBtnEdit.Visible = true;
                tsBtnNewUdt.Visible = true;
                tsBtnEditUdt.Visible = true;
            }
            else if (AuthorityManager.Instance.VerifyLevel2Permission(false))
            {
                tsBtnEdit.Visible = false;
                tsBtnNewUdt.Visible = false;
                tsBtnEditUdt.Visible = false;
            }
            else
            {
                tsBtnEdit.Visible = false;
                tsBtnNewUdt.Visible = false;
                tsBtnEditUdt.Visible = false;
            }
        }


        private void Pg_CommonParamBase_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        public void OnLanguageChanged()
        {
            tsBtnEdit.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_CommonParamForm_EditParam", "编辑参数");
            tsBtnNewUdt.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_CommonParamForm_CreateUserdefinedType", "新建自定义类型");
            tsBtnEditUdt.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_CommonParamForm_EditUserdefinedType", "编辑自定义类型");



            foreach (Property item in Pmcls)
            {
                item.Category = NLocalizer.GetString(item.Category, item.Category);
                // 显示名称是用户配置数据，不能按索引名称翻译后覆盖，否则编辑保存后会恢复旧名称。
                item.CombMsg = NLocalizer.GetString(item.CombMsg, item.CombMsg);

            }
            pg.SelectedObject = Pmcls;
        }

        /// <summary>
        /// 更新参数时发生
        /// </summary>
        /// <param name="property"></param>
        void InstanceUpdateProperty(Property property)
        {
            parameterBinding?.RequestRefresh();
        }
        #endregion



        #region Event_Button

        /// <summary>编辑参数</summary>
        private void 修改参数类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FlushParameterAssignments();
                var session = CreateTransferSession?.Invoke(CurParaPath);
                long editorVersion = ParameterVersion;
                using (var frm = new ParamCfg(CurParaPath))
                {
                    frm.CurSysDir = CurSysDirPaht;
                    frm.TransferSession = session;
                    frm.PrepareDocument = document =>
                    {
                        var copy = new XElement(document);
                        CommonParam.RemoveLegacyRunMode(copy);
                        return copy;
                    };
                    frm.SetDocument(CurrentParameterDocument());
                    frm.SaveGuard = save =>
                    {
                        lock (((CommonParam)CommonParam.Instance).Updates.SyncRoot)
                        {
                            ValidateEditorVersion(editorVersion);
                            save();
                            RefreshTransferredParameters(XElement.Load(CurParaPath));
                            editorVersion = ParameterVersion;
                        }
                    };
                    frm.ShowDialog(this);
                }
                // 保存回调已刷新；关闭/取消不能从磁盘重载旧值。
                // 转移会话已在保存回调刷新；取消时不重载、不保存。
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message, "参数配置"); }
        }

        private void tsBtnEditUdt_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog
            {
                InitialDirectory = UserDefineDir,
                Filter = "(Udt Param)|*.udt",
                Multiselect = false
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string udtParaPath = fd.FileName.Replace(Directory.GetCurrentDirectory(), ".");
                UdtCfg frm = new UdtCfg(udtParaPath);
                frm.ShowDialog();
            }
        }

        private void tsBtnNewUdt_Click(object sender, EventArgs e)
        {
            NewUdt frm = new NewUdt();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                string newName = frm.TagString;
                Directory.CreateDirectory(UserDefineDir);
                string newUdtPath = UserDefineDir + "\\" + newName + ".udt";
                File.Create(newUdtPath).Dispose();
                UdtCfg frmConfig = new UdtCfg(newUdtPath);
                frmConfig.ShowDialog();
            }
        }

        #endregion



        #region Evnet_ExternalUsing
        /// <summary>
        /// 参数初始化
        /// </summary>
        /// <param name="dir">参数目录</param>
        /// <returns>int</returns>
        public int Init(string dir)
        {
            if (string.IsNullOrEmpty(dir))
            {
                throw new ArgumentNullException("dir");
            }

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            UserDefineDir = dir + "\\UserDefineStruct";
            CurParaPath = dir + "\\CommonParam.para";
            LoadAndUpdateUI();
            return 0;
        }

        /// <summary>
        /// 保存
        /// </summary>
        public int Save()
        {
            if (!ParameterEditingAllowed) return -1;
            var manager = (CommonParam)CommonParam.Instance;
            lock (manager.Updates.SyncRoot)
            {
                FlushParameterAssignments();
                var document = CurrentParameterDocument();
                ParameterTransferSession.ValidateDocument(document);
                ParameterFileCommit.Save(CurParaPath, document);
                manager.Load(document);
                parameterBinding.AcceptLoaded();
                CaptureTransferBaseline();
                return 0;
            }
        }

        /// <summary>属性编辑_控制</summary>
        /// <param name="enable"></param>
        public void UIShow(bool enable)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(UIShow), new object[1] { enable });
            }
            else
            {
                if (enable) FlushParameterAssignments();
                pg.Enabled = enable;
                tsTitle.Enabled = enable;
            }
        }


        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// 刷新属性表显示（参数初始化/）
        /// </summary>
        void UpdateUi()
        {
            lock (((CommonParam)CommonParam.Instance).Updates.SyncRoot)
            {
                if (pg.InvokeRequired)
                {
                    pg.BeginInvoke(new Action(UpdateUi));
                    return;
                }

                XElement xel = XElement.Load(CurParaPath);
                if (xel == null)
                {
                    return;
                }

                CommonParam.RemoveLegacyRunMode(xel);
                CommonParam.Instance.Load(xel);


                Pmcls.Clear();
                xel.Elements().ToList().ForEach(p => Pmcls.Add((Property)p));
                parameterBinding.AcceptLoaded();
                CaptureTransferBaseline();
            }
        }



        void LoadAndUpdateUI()
        {
            try
            {
                if (!File.Exists(CurParaPath)) throw new FileNotFoundException("全局参数文件不存在。", CurParaPath);

                UpdateUi();
                OnLanguageChanged();
            }
            catch (Exception ex)
            {
                CommonParam.LogAdd(NLocalizer.GetString("Lead_CPrim_CommonParam_CommonParamForm_ErrMsg_LoadFail", "全局变量界面加载失败:") + ex.Message, (LogLevel)3);
                throw;
            }
        }

        #endregion
    }
}
