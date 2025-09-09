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

        /// <summary>换型参数目录</summary>
        private string ProductsCfgDir;

        /// <summary>用户自定义类目录</summary>
        private string UserDefineDir;

        /// <summary>全局参数全路径</summary>
        private string CurParaPath;

        /// <summary>System.Environment.CurrentDirectory;</summary>
        public string CurSysDirPaht;

        /// <summary>全局参数显示控件对象</summary>
        private static CommonParamForm _instance = new CommonParamForm();


        /// <summary>属性表绑定对象</summary>
        private PropertyManageCls runMode_CommonParam_InPG = new PropertyManageCls();

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
            AuthorityManager.OnUpdateLevel += InstanceUpdateLevel;
            pg.MouseWheel += Pg_CommonParamBase_MouseWheel;

            NLocalizer.LanguageChanged += OnLanguageChanged;
            HiveManager.OnHiveStatusChangeToDT += HiveManager_OnHiveChange;

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
            groupBox1.Text = NLocalizer.GetString("", "模式切换时需要切换的全局参数");
            lb_RunModeList.Text = NLocalizer.GetString("", "当前模式") + ":";

            foreach (Property item in Pmcls)
            {
                item.Category = NLocalizer.GetString(item.Category, item.Category);
                item.DisplayName = NLocalizer.GetString(item.Name, item.DisplayName);
                item.CombMsg = NLocalizer.GetString(item.CombMsg, item.CombMsg);
                foreach (Property property in runMode_CommonParam_InPG)
                {
                    if (item.Name == property.Name)
                    {
                        property.Category = item.Category;
                        property.DisplayName = item.DisplayName;
                        property.CombMsg = item.CombMsg;
                        break;
                    }
                }
            }
            pg.SelectedObject = Pmcls;
            pg_RunMode_CommonParam.SelectedObject = runMode_CommonParam_InPG;
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

        private void 添加到选择的运行模式的全局参数列表中ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pg.SelectedGridItem == null || pg.SelectedGridItem.PropertyDescriptor == null)
            {
                MessageBox.Show("请选择需要添加的参数");
                return;
            }

            if (pg.SelectedGridItem.PropertyDescriptor.Name == "运行模式")
            {
                MessageBox.Show("无法选择[运行模式]参数");
                return;
            }

            if (pg.SelectedGridItem.PropertyDescriptor.DisplayName.Contains("启用工位"))
            {
                string str = pg.SelectedGridItem.PropertyDescriptor.DisplayName.Substring(pg.SelectedGridItem.PropertyDescriptor.DisplayName.IndexOf("启用工位"));
                if (str.Remove(0, 4).IsNumber())
                {
                    MessageBox.Show("无法选择[启用工位]参数");
                    return;
                }
            }

            foreach (Property p in Pmcls)
            {
                if (p.Name == pg.SelectedGridItem.PropertyDescriptor.Name)
                {
                    if (p.ReadOnly == true)
                    {
                        MessageBox.Show("选择的参数[" + pg.SelectedGridItem.Label + "]的状态为不可添加状态");
                        return;
                    }
                    p.ReadOnly = true;
                    runMode_CommonParam_InPG.Add(new Property(p));
                    break;
                }
            }
            pg.SelectedObject = Pmcls;
            pg_RunMode_CommonParam.SelectedObject = runMode_CommonParam_InPG;
        }

        private void 从选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pg_RunMode_CommonParam.SelectedGridItem == null || pg.SelectedGridItem.PropertyDescriptor == null)
            {
                MessageBox.Show("请选择需要删除的参数");
                return;
            }

            foreach (Property p in Pmcls)
            {
                if (p.Name == pg_RunMode_CommonParam.SelectedGridItem.PropertyDescriptor.Name)
                {
                    p.ReadOnly = false;

                    for (int i = 0; i < runMode_CommonParam_InPG.Count; i++)
                    {
                        if (runMode_CommonParam_InPG[i].Name == pg_RunMode_CommonParam.SelectedGridItem.PropertyDescriptor.Name)
                        {
                            runMode_CommonParam_InPG.Remove(runMode_CommonParam_InPG[i]);
                            break;
                        }
                    }
                    break;
                }
            }

            pg.SelectedObject = Pmcls;
            pg_RunMode_CommonParam.SelectedObject = runMode_CommonParam_InPG;
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
            ProductsCfgDir = dir + "\\ProductCfg";
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
                SaveMode(mode);
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
                groupBox1.Enabled = enable;
            }
        }

        /// <summary>
        /// 变更模式
        /// </summary>
        /// <param name="mode"></param>
        public int ModeChange(string mode)
        {
            ChangeMode(mode);
            return Save(mode);
        }

        public string GetRunMode()
        {
            return tbxRunMode.Text.Trim();
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

        public bool SaveMode(string mode)
        {
            XElement node = new XElement("参数", "");
            List<Property> properties = new List<Property>();
            foreach (Property p in runMode_CommonParam_InPG)
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
                node.Add(p.PropToXElment());
            }

            string runMode_ParamPath = "D:\\Config\\CPrimConfig\\DynamicParam\\CommonParam_" + mode + ".para";
            if (!File.Exists(runMode_ParamPath))
            {
                if (File.Exists(Application.StartupPath + "\\Configs\\Template.para"))
                {
                    File.Copy(Application.StartupPath + "\\Configs\\Template.para", runMode_ParamPath);
                }
                else
                {
                    File.Create(runMode_ParamPath).Close();
                }
            }

            node.Save(runMode_ParamPath);
            return true;
        }

        /// <summary>模式切换时发生</summary>
        /// <param name="mode"></param>
        void ChangeMode(string mode)
        {
            string runMode_ParamPath = "D:\\Config\\CPrimConfig\\DynamicParam\\CommonParam_" + mode + ".para";
            if (!File.Exists(runMode_ParamPath))
            {
                if (File.Exists(Application.StartupPath + "\\Configs\\Template.para"))
                {
                    File.Copy(Application.StartupPath + "\\Configs\\Template.para", runMode_ParamPath);
                }
                else
                {
                    File.Create(runMode_ParamPath).Close();
                }
            }

            try
            {
                runMode_CommonParam_InPG = new PropertyManageCls();
                XElement.Load(runMode_ParamPath).Elements().ToList().ForEach(p => runMode_CommonParam_InPG.Add((Property)p));

                foreach (Property item in Pmcls)
                {
                    if (item.Name == "运行模式")
                    {
                        item.ReadOnly = true;
                        item.Value = mode;
                        OnModeSwitchView?.Invoke(mode);
                        OnModeSwitch?.Invoke(mode);
                        continue;
                    }

                    item.ReadOnly = !item.Visible;
                    if (item.DisplayName.Contains("启用工位"))
                    {
                        string str = item.DisplayName.Substring(item.DisplayName.IndexOf("启用工位"));
                        if (str.Remove(0, 4).IsNumber())
                        {
                            item.ReadOnly = HiveManager.GetCurrentHiveStatus() != HiveStatus.DT;
                        }
                    }

                    foreach (Property property in runMode_CommonParam_InPG)
                    {
                        if (item.Name == property.Name)
                        {
                            item.ReadOnly = true;
                            item.Value = property.Value;
                            break;
                        }
                    }
                }

                //显示模式列表中
                pg.SelectedObject = Pmcls;
                pg_RunMode_CommonParam.SelectedObject = runMode_CommonParam_InPG;
                tbxRunMode.Text = mode;
                runModeLast = mode;
            }
            catch (Exception e)
            {
                MessageBox.Show("切换运行模式[" + mode + "]的全局参数加载失败:" + e.Message + e.StackTrace);
            }
        }

        void LoadAndUpdateUI(bool isInit)
        {
            try
            {
                if (!Directory.Exists(UserDefineDir))
                {
                    Directory.CreateDirectory(UserDefineDir);
                }

                if (!Directory.Exists(ProductsCfgDir))
                {
                    Directory.CreateDirectory(ProductsCfgDir);
                }

                if (!File.Exists(CurParaPath))
                {
                    if (File.Exists(Application.StartupPath + "\\Configs\\Template.para"))
                    {
                        File.Copy(Application.StartupPath + "\\Configs\\Template.para", CurParaPath);
                    }
                    else
                    {
                        File.Create(CurParaPath).Close();
                        Thread.Sleep(1);
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
        #endregion
    }
}
