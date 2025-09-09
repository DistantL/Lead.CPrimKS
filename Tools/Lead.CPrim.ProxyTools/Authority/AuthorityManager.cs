using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools.Authority.Controls;
using Lead.CPrim.ProxyTools.Authority.Forms;
using Lead.CPrim.ProxyTools.Properties;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using MongoDB.Bson.IO;
using SoftLockDog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.Authority
{
    /// <summary>
    /// 权限管理器
    /// </summary>
    public class AuthorityManager
    {
        #region Define_Event
        /// <summary>权限等级改变时发生</summary>
        public static event Action<OpLevel> OnUpdateLevel;

        public static event Action<OpLevel> OnUpdateLevelOther;

        /// <summary>
        /// 登录时发生
        /// </summary>
        public event Action<string> OnOpLogin;

        public event Action<string, string, string, int> OnUpdateLogin;
        #endregion



        #region Field
        private const int AdminLvlAdress = 66;

        private const int DevelopmnetAdress = 108;

        private const string hRead = "FTKTHINK";

        //加密狗相关变量
        private const string lRead = "20200823";

        private const int MaintainenceLvlAdress = 30;

        private const int OpLvlAdress = 10;

        //地址
        /// <summary>加密狗地址</summary>
        private readonly string softLvlPath = Application.StartupPath + "\\Configs\\SoftLockConfig.xml";

        private List<(string, string)> _accessaryInfos = new List<(string, string)>();

        private List<string> _accessaryNames = new List<string>();

        /// <summary>管理员密码地址</summary>
        private string _adminPwPath = "";

        //UI
        /// <summary>登录显示界面</summary>
        private AuthorityLvlShowUI _authorityLvlShowUI = null;

        //配置类
        /// <summary>权限管理级别配置类</summary>
        private AuthorityConfig _config = null;

        /// <summary>当前级别</summary>
        private OpLevel _level = OpLevel.Other;

        //对象
        /// <summary>权限管理器对象</summary>
        /// <summary>加密狗</summary>
        private SoftLock _lock;
        /// <summary>加密狗配置类</summary>
        private SoftLockConfig _lockConfig = null;

        /// <summary>其它账户地址</summary>
        private string _otherPwPath = "";
        #endregion



        #region Prop
        public Dictionary<string, AccessaryChangeInfo> Dic_AccessaryInfos = new Dictionary<string, AccessaryChangeInfo>();

        /// <summary>
        /// 权限管理对象
        /// </summary>
        public static AuthorityManager Instance { get; } = new AuthorityManager();

        public List<(string, string)> AccessaryInfos
        {
            get
            {
                return _accessaryInfos;
            }
            set
            {
                _accessaryInfos.Clear();
                if (value != null)
                {
                    _accessaryInfos = new List<(string, string)>(value);
                }
            }
        }

        public List<string> AccessaryNames
        {
            get
            {
                return _accessaryNames;
            }
            set
            {
                _accessaryNames.Clear();
                if (value != null)
                {
                    _accessaryNames = new List<string>(value);
                    foreach (var item in _accessaryNames)
                    {
                        int ret = MongodbHelper.QueryOneLast("AccessaryName", item, out AccessaryChangeInfo info, "AccessaryChangeInfo");
                        if (ret == 0 && info != null)
                        {
                            Dic_AccessaryInfos.Add(item, info);
                        }
                        else
                        {
                            Dic_AccessaryInfos.Add(item, null);
                        }
                    }
                }
            }
        }

        /// <summary>加密狗最高级别</summary>
        public OpLevel AccessLvl => _lockConfig.MaxOpLvl;

        /// <summary>权限管理配置</summary>
        public AuthorityConfig Config { get => _config; set => _config = value; }
        /// <summary>加密狗注册码</summary>
        public string CurRegisterCode => _lockConfig.CurRegisterCode;

        /// <summary>当前授权人用户ID</summary>
        public string CurrentAuthorizeID { get; set; } = string.Empty;

        /// <summary>当前授权人名称</summary>
        public string CurrentAuthorizeName { get; set; } = string.Empty;

        /// <summary>当前授权人供应商</summary>
        public string CurrentAuthorizeVendor { get; set; } = string.Empty;

        /// <summary>当前操作员用户ID</summary>
        public string CurrentOperatorID { get; set; } = string.Empty;

        /// <summary>当前登录用户ID</summary>
        public string CurrentUserID { get; set; } = string.Empty;

        /// <summary>当前登录名称</summary>
        public string CurrentUserName { get; set; } = string.Empty;

        public string CurrentVendor { get; set; } = string.Empty;

        /// <summary>权限管理当前等级</summary>
        public OpLevel Level
        {
            get
            {
                return _level;
            }
            internal set
            {
                if (_level == value)
                {
                    return;
                }
                _level = value;

                //界面更新
                _authorityLvlShowUI.UpdateShow();
                if (_level == OpLevel.Other || _level == OpLevel.NoLogin)
                {
                    CurrentUserName = string.Empty;
                    OnUpdateLevelOther?.Invoke(_level);
                    AuthorityManager.Instance.LvlShowUI.EnableLogin = false;
                }
                else
                {
                    //事件调用
                    OnUpdateLevel?.Invoke(_level);
                }
            }
        }

        /// <summary>登录显示界面</summary>
        public AuthorityLvlShowUI LvlShowUI { get => _authorityLvlShowUI; set => _authorityLvlShowUI = value; }

        public bool ShowLevelLoginUI { get; set; } = false;
        public bool ShowOpLoginUI { get; set; } = false;
        public bool UseSoftLock { get; set; } = false;
        #endregion



        #region Ctor
        private AuthorityManager()
        {
            _authorityLvlShowUI = new AuthorityLvlShowUI();
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>权限管理器初始化</summary>
        /// <param name="adminPwPath"></param>
        /// <param name="otherPwPath"></param>
        /// <returns></returns>
        public int AuthorityManagerInit(string adminPwPath, string otherPwPath)
        {
            int result = 0;
            try
            {
                string text = null;
                _adminPwPath = adminPwPath;
                _otherPwPath = otherPwPath;

                #region 初始密码获取
                _config = new AuthorityConfig();
                if (!File.Exists(_adminPwPath))
                {
                    Login("administrator3", OpLevel.Level2);
                }
                else
                {
                    using (StreamReader streamReader = new StreamReader(_adminPwPath, Encoding.Default))
                    {
                        while ((text = streamReader.ReadLine()) != null)
                        {
                            if (text.Contains("Administrator:"))
                            {
                                string[] array = text.Split(':');
                                if (array.Length >= 2)
                                {
                                    _config.Administrator = array[1];
                                }
                            }
                        }
                    }
                }
                if (!File.Exists(_otherPwPath))
                {
                    Login("administrator1", OpLevel.Level1);
                    Login("administrator2", OpLevel.Level3);
                }
                else
                {
                    using (StreamReader streamReader = new StreamReader(_otherPwPath, Encoding.Default))
                    {
                        while ((text = streamReader.ReadLine()) != null)
                        {
                            if (text.Contains("Maintenance:"))
                            {
                                string[] array2 = text.Split(':');
                                if (array2.Length >= 2)
                                {
                                    _config.Maintenance = array2[1];
                                }
                            }
                            else if (text.Contains("Development:"))
                            {
                                string[] array3 = text.Split(':');
                                if (array3.Length >= 2)
                                {
                                    _config.Development = array3[1];
                                }
                            }
                        }
                    }
                }
                AuthorityManagerSavePassword();
                #endregion

                #region 加密狗判断
                try
                {
                    _lock = new SoftLock();
                    if (!File.Exists(softLvlPath))
                    {
                        string path = softLvlPath.Substring(0, softLvlPath.LastIndexOf("\\"));
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        File.Create(softLvlPath);
                        _lockConfig = new SoftLockConfig();
                        _lockConfig.MaxOpLvl = OpLevel.Other;
                        XmlSerializerHelper.WriteXML(_lockConfig, softLvlPath, typeof(SoftLockConfig));
                        return result;
                    }
                    _lockConfig = (SoftLockConfig)XmlSerializerHelper.ReadXML(softLvlPath, typeof(SoftLockConfig));
                    if (_lockConfig == null)
                    {
                        _lockConfig = new SoftLockConfig();
                        _lockConfig.MaxOpLvl = OpLevel.Other;
                    }
                }
                catch (Exception)
                {
                    if (_lockConfig == null)
                    {
                        _lockConfig = new SoftLockConfig();
                        _lockConfig.MaxOpLvl = OpLevel.Other;
                    }
                    MessageBox.Show(NLocalizer.GetString("Authority_AuthorityManager_LoadAuthorityManagerError", "Err: LoadAuthorityManager!"));
                    result = -1;
                }
                string errMsg;
                if (Instance.CheckSoftLock(out errMsg) == -1)
                {
                    Level = OpLevel.Other;
                    MessageBox.Show("获取加密狗基本信息失败");
                }
                if (string.IsNullOrEmpty(Instance.CurRegisterCode))
                {
                    Level = OpLevel.Other;
                    MessageBox.Show("请先激活软件");
                }
                if (Instance.GetMaxLvlByRegisterCode(Instance.CurRegisterCode, out errMsg) == OpLevel.Other)
                {
                    Level = OpLevel.Other;
                    MessageBox.Show("软件激活存在异常，请确认激活码，重新激活");
                }
                Task.Run(SoftDogMonitor);
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化错误" + ex.Message, "软件初始化提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        /// <summary>改变等级</summary>
        /// <param name="opLevel">级别</param>
        public void ChangeLevel(OpLevel opLevel)
        {
            Level = opLevel;
        }

        public void ChangeRemoteQualificationEnable(bool flag)
        {
            _authorityLvlShowUI.EnableRemoteQualification = flag;
        }

        /// <summary>
        /// 清除事件委托<br/>
        /// OnOpLogin
        /// </summary>
        public void ClearOnOpLogin()
        {
            if (OnOpLogin != null)
            {
                foreach (var p in OnOpLogin.GetInvocationList())
                {
                    OnOpLogin -= p as Action<string>;
                }
            }
        }

        public int GetSoftLockConfig()
        {
            int ret = -1;
            string filePath = Application.StartupPath + "\\Configs\\UseSoftLockConfig.ini";
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            try
            {
                using StreamReader sr = new StreamReader(filePath);
                string text = sr.ReadLine();
                sr.Close();

                if (string.IsNullOrWhiteSpace(text))
                {
                    throw new Exception();
                }

                if (!bool.TryParse(text.Trim(), out bool flag))
                {
                    throw new Exception();
                }

                UseSoftLock = flag;
                ret = 0;
            }
            catch
            {
                using StreamWriter sr = new StreamWriter(filePath);
                sr.WriteLine("False");
                sr.Close();
            }

            return ret;
        }

        /// <summary>是否使用加密狗</summary>
        /// <returns>true：使用加密狗；false：不使用加密狗</returns>
        public bool IsUseSoftLock()
        {
            return UseSoftLock;
        }

        /// <summary>
        /// 加密狗进行注册
        /// </summary>
        public void OpenRegisterForm()
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Init();
            registerForm.ShowDialog();
        }

        public void UpdateLoginLevel(string user, string id, string vendor, int level)
        {
            OnUpdateLogin?.Invoke(user, id, vendor, level);
        }

        public void UpdateOpLogin(string id)
        {
            OnOpLogin?.Invoke(id);
        }

        /// <summary>确认是否具有维护员权限</summary>
        /// <param name="promptFlag">true:弹窗提醒
        /// <para>false:不弹窗提醒（默认）</para></param>
        /// <returns>true:具有维护员权限
        /// <para>false:不具有维护员权限</para></returns>
        public bool VerifyLevel1Permission(bool promptFlag = false)
        {
            if (_level < OpLevel.Level1)
            {
                if (promptFlag)
                {
                    UIMessageDialog.ShowMessageDialog($"当前用户 {_level} 无权限，权限要求 >= Level1", ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
                }
                return false;
            }
            return true;
        }

        /// <summary>确认是否具有管理员权限</summary>
        /// <param name="promptFlag">true:弹窗提醒
        /// <para>false:不弹窗提醒（默认）</para></param>
        /// <returns>true:具有管理员权限
        /// <para>false:不具有管理员权限</para></returns>
        public bool VerifyLevel2Permission(bool promptFlag = false)
        {
            if (_level < OpLevel.Level2)
            {
                if (promptFlag)
                {
                    UIMessageDialog.ShowMessageDialog($"当前用户 {_level} 无权限，权限要求 >= Level2", ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
                }
                return false;
            }
            return true;
        }

        /// <summary>确认是否具有开发者权限</summary>
        /// <param name="promptFlag">true:弹窗提醒
        /// <para>false:不弹窗提醒（默认）</para></param>
        /// <returns>true:具有开发者权限
        /// <para>false:不具有开发者权限</para></returns>
        public bool VerifyLevel3Permission(bool promptFlag = false)
        {
            if (_level < OpLevel.Level3)
            {
                if (promptFlag)
                {
                    UIMessageDialog.ShowMessageDialog($"当前用户 {_level} 无权限，权限要求 >= Level3", ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
                }
                return false;
            }
            return true;
        }

        /// <summary>保存密码</summary>
        /// <returns></returns>
        internal int AuthorityManagerSavePassword()
        {
            int result = 0;
            try
            {
                using (FileStream fileStream = new FileStream(_adminPwPath, FileMode.Create))
                {
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.Write("Administrator:" + _config.Administrator);
                    streamWriter.Flush();
                    streamWriter.Close();
                    fileStream.Close();
                }
                using (FileStream fileStream2 = new FileStream(_otherPwPath, FileMode.Create))
                {
                    StreamWriter streamWriter2 = new StreamWriter(fileStream2);
                    streamWriter2.WriteLine("Maintenance:" + _config.Maintenance);
                    streamWriter2.WriteLine("Development:" + _config.Development);
                    streamWriter2.Flush();
                    streamWriter2.Close();
                    fileStream2.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(NLocalizer.GetString("Authority_AuthorityManager_SaveAuthorityManagerError", "Err: SaveAuthorityManager!"));
                result = -1;
            }
            return result;
        }

        /// <summary>检查加密狗</summary>
        /// <param name="errMsg"></param>
        /// <returns>0：成功；非0：返回错误</returns>
        internal int CheckSoftLock(out string errMsg)
        {
            if (IsUseSoftLock())
            {
                string empty = string.Empty;
                try
                {
                    if (_lock.FindSoftDog(0) == -1)
                    {
                        errMsg = "未找到加密狗";
                        return -1;
                    }
                    empty = GetSoftDogId();
                    if (string.IsNullOrEmpty(empty))
                    {
                        errMsg = "获取密钥失败";
                        return -1;
                    }
                    string text = empty;
                    for (int i = 0; i < 32 - empty.Length; i++)
                    {
                        text += "F";
                    }
                    if (_lock.CheckSoftKey(text) == -1)
                    {
                        errMsg = "校验加密狗失败";
                        return -1;
                    }
                    errMsg = string.Empty;
                    return 0;
                }
                catch (Exception ex)
                {
                    errMsg = ex.ToString();
                    return -1;
                }
            }
            else
            {
                errMsg = string.Empty;
                return 0;
            }
        }

        /// <summary>获取加密狗的最高权限</summary>
        /// <param name="code">注册码</param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        internal OpLevel GetMaxLvlByRegisterCode(string code, out string errMsg)
        {
            string empty = string.Empty;
            string empty2 = string.Empty;
            OpLevel result = OpLevel.Other;
            string text = string.Empty;
            errMsg = string.Empty;
            try
            {
                if (!IsUseSoftLock())
                {
                    return OpLevel.Level3;
                }
                else
                {
                    if (_lock.EncDataByAlgorithm1(code, ref empty2) == -1 || string.IsNullOrWhiteSpace(empty2))
                    {
                        errMsg = "计算校验值失败";
                        return result;
                    }
                    else
                    {
                        return OpLevel.Level3;
                    }

                    //if (_lock.ReadDataFromSoftDog(ref empty, lRead, hRead, DevelopmnetAdress, 16) == -1)
                    //{
                    //    text += "获取开发者权限校验值失败";
                    //}
                    //else if (empty2 == empty)
                    //{
                    //    return OpLevel.Level3;
                    //}

                    //if (_lock.ReadDataFromSoftDog(ref empty, lRead, hRead, AdminLvlAdress, 16) == -1)
                    //{
                    //    text += "获取管理员权限校验值失败";
                    //}
                    //else if (empty2 == empty)
                    //{
                    //    return OpLevel.Level2;
                    //}

                    //if (_lock.ReadDataFromSoftDog(ref empty, lRead, hRead, MaintainenceLvlAdress, 16) == -1)
                    //{
                    //    text += "获取维护管理权限校验值失败";
                    //}
                    //else if (empty2 == empty)
                    //{
                    //    return OpLevel.Level1;
                    //}

                    //if (_lock.ReadDataFromSoftDog(ref empty, lRead, hRead, OpLvlAdress, 16) == -1)
                    //{
                    //    text += "获取操作者权限校验值失败";
                    //}
                    //else if (empty2 == empty)
                    //{
                    //    return OpLevel.NoLogin;
                    //}

                    //if (!text.IsNullOrEmpty())
                    //{
                    //    errMsg = text;
                    //}
                    //return result;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.ToString();
                return result;
            }
        }

        /// <summary>获取加密狗Id</summary>
        /// <returns>Empty：获取失败；非空：成功</returns>
        internal string GetSoftDogId()
        {
            string empty = string.Empty;
            if (_lock.GetFactoryID(ref empty) == -1)
            {
                MessageBox.Show("获取密钥失败");
            }
            return empty;
        }

        /// <summary>权限注册</summary>
        /// <param name="registerCode"></param>
        /// <param name="maxLvl"></param>
        internal void SoftwareRegister(string registerCode, OpLevel maxLvl)
        {
            _lockConfig.CurRegisterCode = registerCode;
            _lockConfig.MaxOpLvl = maxLvl;
            XmlSerializerHelper.WriteXML(_lockConfig, softLvlPath, typeof(SoftLockConfig));
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>强行修改密码</summary>
        /// <param name="targetValue"></param>
        /// <param name="op"></param>
        /// <returns></returns>
        private int Login(string targetValue, OpLevel op)
        {
            try
            {
                switch (op)
                {
                    case OpLevel.Level1:
                        AuthorityManager.Instance.Config.Maintenance = DESHelper.Encrypt(targetValue, Resources.passWordKey);
                        break;
                    case OpLevel.Level2:
                        AuthorityManager.Instance.Config.Administrator = DESHelper.Encrypt(targetValue, Resources.passWordKey);
                        break;
                    case OpLevel.Level3:
                        AuthorityManager.Instance.Config.Development = DESHelper.Encrypt(targetValue, Resources.passWordKey);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return 0;
        }
        /// <summary>加密狗10s遍历的一个线程</summary>
        private void SoftDogMonitor()
        {
            while (IsUseSoftLock())
            {
                try
                {
                    string errMsg;
                    if (CheckSoftLock(out errMsg) == -1)
                    {
                        Thread.Sleep(1 * 1000);
                        Level = OpLevel.Other;
                        UIMessageDialog.ShowMessageDialog(errMsg, ULocalize.ErrorTitle, false, UIStyle.Red);
                    }
                    else if (string.IsNullOrEmpty(CurRegisterCode))
                    {
                        Level = OpLevel.Other;
                    }
                    else if (GetMaxLvlByRegisterCode(CurRegisterCode, out errMsg) == OpLevel.Other)
                    {
                        Thread.Sleep(1 * 1000);
                        Level = OpLevel.Other;
                        if (!string.IsNullOrEmpty(errMsg))
                        {
                            MessageBox.Show(errMsg);
                        }
                    }
                    else if (GetMaxLvlByRegisterCode(CurRegisterCode, out errMsg) < Level)
                    {
                        Thread.Sleep(1 * 1000);
                        Level = Instance.AccessLvl;
                        if (!string.IsNullOrEmpty(errMsg))
                        {
                            MessageBox.Show(errMsg);
                        }
                    }
                    Thread.Sleep(1 * 1000);
                }
                catch (Exception)
                {
                }
            }
        }
        #endregion
    }
}

