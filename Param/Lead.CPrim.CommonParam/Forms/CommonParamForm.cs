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
        /// <summary>模式切换时发生</summary>
        public event Action<string> OnModeSwitch;

        public event Action<string> OnModeSwitchView;
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



        /// <summary>
        /// 上次运行模式
        /// </summary>
        string runModeLast = 运行模式.正常生产.ToString();
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
            // 模式参数编辑已迁至换型参数页，全局参数仅保留模式状态通知。
            tlpMain.Controls.Remove(groupBox1);
            groupBox1.Dispose();
            pg.ContextMenuStrip = null;
            tlpMain.SetColumnSpan(pg, 2);
            AuthorityManager.OnUpdateLevel += InstanceUpdateLevel;
            pg.MouseWheel += Pg_CommonParamBase_MouseWheel;

            NLocalizer.LanguageChanged += OnLanguageChanged;
            HiveManagerV3.Instance.HiveStateChanged += (info, trigger) => HiveManager_OnHiveChange(info.ChangeToStatus == HiveStatus.DT);

            CommonParam.OnUpdateProperty += InstanceUpdateProperty;
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

        private void HiveManager_OnHiveChange(bool flag)
        {
            OnHiveChangeToDT(flag);
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
                item.DisplayName = NLocalizer.GetString(item.Name, item.DisplayName);
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
            if (pg.InvokeRequired)
            {
                BeginInvoke(new Action<Property>(InstanceUpdateProperty), property);
            }
            else
            {
                foreach (Property p in Pmcls)
                {
                    if (p.Name == property.Name)
                    {
                        p.Value = property.Value;
                        break;
                    }
                }
                pg.SelectedObject = Pmcls;
            }
        }
        #endregion



        #region Event_Button

        /// <summary>编辑参数</summary>
        private void 修改参数类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParamCfg frm = new ParamCfg(CurParaPath)
            {
                CurSysDir = CurSysDirPaht
            };
            frm.ShowDialog();
            LoadAndUpdateUI(false);
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
            LoadAndUpdateUI(true);
            return 0;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="mode"></param>
        public int Save(string mode)
        {
            if (string.IsNullOrWhiteSpace(mode))
            {
                return -1;
            }

            lock (CommonParam.LockPara)
            {
                XElement xel = new XElement("参数", "");
                List<Property> properties = new List<Property>();
                foreach (Property p in Pmcls)
                {
                    properties.Add(p);
                }
                properties.Sort(
                    (x, y) =>
                    {
                        string x_str = x.Category + x.DisplayName;
                        string y_str = y.Category + y.DisplayName;
                        return x_str.CompareTo(y_str);
                    });
                foreach (Property p in properties)
                {
                    xel.Add(p.PropToXElment());
                }
                CommonParam.Instance.Load(xel);
                CommonParam.Instance.Save(CurParaPath);

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
                pg.Enabled = enable;
                tsTitle.Enabled = enable;
            }
        }

        /// <summary>
        /// 变更模式
        /// </summary>
        /// <param name="mode"></param>
        public int ModeChange(string mode)
        {
            try
            {
                ChangeMode(mode);
                return string.IsNullOrEmpty(CurParaPath) ? 0 : Save(mode);
            }
            catch (Exception ex)
            {
                LogHelper.Warn(ex.ToString());
                return -1;
            }
        }

        public string GetRunMode()
        {
            return runModeLast;
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// 刷新属性表显示（参数初始化/）
        /// </summary>
        void UpdateUi(string mode, bool isInit)
        {
            if (pg.InvokeRequired)
            {
                pg.BeginInvoke(new Action<string, bool>(UpdateUi), mode, isInit);
                return;
            }

            CommonParam.Instance.Load(CurParaPath);
            XElement xel = CommonParam.Instance.Node;
            if (xel == null)
            {
                return;
            }

            string[] modes = Enum.GetNames(typeof(运行模式));
            Property temp = null;
            XElement element = xel.Elements().ToList().FirstOrDefault(p => p.Name == nameof(运行模式));
            if (element != null)
            {
                temp = (Property)element;
                element.Remove();
            }

            Property prop = new Property()
            {
                Category = "00 设备",
                Name = nameof(运行模式),
                Value = isInit || element == null ? 运行模式.正常生产.ToString() : temp.Value.ToString(),
                valType = BaseParam.DataType.Comb,
                DisplayName = nameof(运行模式),
                CombMsg = string.Join(",", modes),
                ReadOnly = true,
                Visible = true
            };

            xel.Add(prop.PropToXElment());
            CommonParam.Instance.Load(xel);
            CommonParam.Instance.Save(CurParaPath);

            Pmcls.Clear();
            xel.Elements().ToList().ForEach(p => Pmcls.Add((Property)p));
            ChangeMode(mode);
        }

        /// <summary>只更新运行模式状态，不加载或覆盖任何全局模式参数。</summary>
        void ChangeMode(string mode)
        {
            foreach (Property item in Pmcls)
            {
                if (item.Name == "运行模式")
                {
                    item.ReadOnly = true;
                    item.Value = mode;
                }
            }
            OnHiveChangeToDT(HiveManagerV3.Instance.GetCurrentHiveStatus() == HiveStatus.DT);
            pg.SelectedObject = Pmcls;
            runModeLast = mode;
            OnModeSwitchView?.Invoke(mode);
            OnModeSwitch?.Invoke(mode);
        }

        void LoadAndUpdateUI(bool isInit)
        {
            try
            {
                if (!Directory.Exists(UserDefineDir))
                {
                    Directory.CreateDirectory(UserDefineDir);
                }


                if (!File.Exists(CurParaPath))
                {
                    if (File.Exists(Application.StartupPath + "\\Configs\\Template.para"))
                    {
                        File.Copy(Application.StartupPath + "\\Configs\\Template.para", CurParaPath);
                    }
                    else
                    {
                        new XElement("参数").Save(CurParaPath);
                    }
                }

                UpdateUi(runModeLast, isInit);
                OnLanguageChanged();
            }
            catch (Exception ex)
            {
                CommonParam.Instance.LogAdd(NLocalizer.GetString("Lead_CPrim_CommonParam_CommonParamForm_ErrMsg_LoadFail", "全局变量界面加载失败:") + ex.Message, (LogLevel)3);
            }
        }

        private void OnHiveChangeToDT(bool flag)
        {
            try
            {
                if (pg.InvokeRequired)
                {
                    pg.BeginInvoke(new Action<bool>(OnHiveChangeToDT), flag);
                    return;
                }

                foreach (Property p in Pmcls)
                {
                    if (p.DisplayName.Contains("启用工位"))
                    {
                        string str = p.DisplayName.Substring(p.DisplayName.IndexOf("启用工位"));
                        if (str.Remove(0, 4).IsNumber())
                        {
                            if (flag)
                            {
                                p.ReadOnly = false;
                            }
                            else
                            {
                                p.ReadOnly = true;
                            }
                        }
                    }
                }

                pg.SelectedObject = Pmcls;
            }
            catch (Exception ex)
            {
                LogHelper.Warn(ex.ToString());
            }
        }
        #endregion
    }
}
