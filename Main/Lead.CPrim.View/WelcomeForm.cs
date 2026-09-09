using Lead.CPrim.CmpTrigHelper;
using Lead.CPrim.FaiHelper;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.Properties;
using Lead.CPrim.ProxyTools.Register;
using Lead.CPrim.Tracking.Connection;
using Lead.CPrims.Framework.Common;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Win32;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Lead.CPrim.View
{
    public partial class WelcomeForm : Form
    {
        #region Field
        /// <summary>应用程序地址</summary>
        private static string _curDominStartPath = Application.StartupPath;
        /// <summary>管理员密码地址</summary>
        private readonly string _adminPwConfigPath = _curDominStartPath + "\\Configs\\AuxiliaryConfigs\\A.t";
        /// <summary>其它权限密码地址</summary>
        private readonly string _otherPwConfigPath = _curDominStartPath + "\\Configs\\AuxiliaryConfigs\\U.t";
        /// <summary>元件dll地址</summary>
        private readonly string _elesAssemblyPath = _curDominStartPath + "\\InnerLibs\\Elements";
        /// <summary>任务dll文件夹地址</summary>
        private readonly string _tasksAssemblyPath = _curDominStartPath + "\\InnerLibs\\Tasks";
        /// <summary>第3方库地址</summary>
        private readonly string _thirdLibsPath = _curDominStartPath + "\\ExtLibs\\Third";
        /// <summary>显示配置管理器</summary>
        private ShowConfigs _showConfigs = new ShowConfigs();

        private readonly string _trackingAssemblyPath = _curDominStartPath + "\\TrackingLibs";

        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public WelcomeForm()
        {
            InitializeComponent();
        }
        #endregion



        #region Event-子程序
        private string ReadSetting(string key, string value = null)
        {
            if (value == null)
            {
                value = "-1";
            }
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Lead\\cc");
            if (registryKey != null)
            {
                object value2 = registryKey.GetValue(key, value);
                registryKey.Close();
                if (value2 != null)
                {
                    if (!(value2 is string))
                    {
                        return "-1";
                    }
                    return value2.ToString();
                }
                return "-1";
            }
            return value;
        }
        #endregion



        #region Event
        /// <summary>Load事件</summary>
        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            if (!AuthorityManager.Instance.IsUseSoftLock())
            {
                string text = ReadSetting("cc");
                string text2 = "";
                if (text == "-1" || text.Length != 16)
                {
                    text2 = "软件未注册或注册失效，请注册：";
                }
                else
                {
                    string str = text.Substring(0, 4);
                    string str2 = text.Substring(4, 4);
                    string str3 = text.Substring(8, 4);
                    string str4 = text.Substring(12, 4);
                    string pToDecrypt = str + str3 + str2 + str4;
                    string desResult = null;
                    string error = null;
                    string key = Settings1.Default.SpecialRegistration ? Register.GetDiskVolumeSerialNumber() : Resources.RegisterKey;
                    string iv = Settings1.Default.SpecialRegistration ? Register.getCpu().Substring(0, 8) : Resources.RegisterIV;
                    if (DESHelper.DecryptString(pToDecrypt, key, iv, ref desResult, ref error) != 0)
                    {
                        text2 = "密钥解析出现错误：" + error;
                    }
                    IFormatProvider provider = new CultureInfo("zh-CN", useUserOverride: true);
                    if (!DateTime.TryParseExact("20" + desResult, "yyyyMMdd", provider, DateTimeStyles.None, out DateTime result))
                    {
                        text2 = "软件注册失效，请注册：";
                    }
                    else if (DateTime.Compare(result, DateTime.Now) < 0)
                    {
                        text2 = "软件注册已过期，请重新注册：";
                    }
                }
                if (!string.IsNullOrEmpty(text2))
                {
                    DialogResult dialogResult;
                    if (Settings1.Default.SpecialRegistration)
                    {
                        FormRegisteSpecial formRegisteSpecial = new FormRegisteSpecial(text2);
                        dialogResult = formRegisteSpecial.ShowDialog();
                    }
                    else
                    {
                        FormRegister formRegister = new FormRegister(text2);
                        dialogResult = formRegister.ShowDialog();
                    }
                    if (dialogResult != DialogResult.Yes)
                    {
                        Process.GetCurrentProcess().Kill();
                        return;
                    }
                }
            }
            try
            {
                bgwInitialize.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>FormClosing事件</summary>
        private void WelcomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bgwInitialize.CancelAsync();
        }
        #endregion



        #region 三部曲
        private void bgwInitialize_DoWork(object sender, DoWorkEventArgs e)
        {
            StartupDiagnostics.Mark("欢迎页后台任务开始");
            int num = 0;
            //软件配置
            bgwInitialize.ReportProgress(0, "载入软件配置");
            //权限
            bgwInitialize.ReportProgress(5, "加载权限管理器");
            Stopwatch stageStopwatch = StartupDiagnostics.StartStage("权限管理器初始化");
            Thread.Sleep(100);
            try
            {
                num = AuthorityManager.Instance.AuthorityManagerInit(_adminPwConfigPath, _otherPwConfigPath);
                if (num < 0)
                {
                    MessageBox.Show("权限管理器加载失败");
                }
            }
            catch (Exception ex)
            {
                StartupDiagnostics.Mark("权限管理器初始化异常", $"exception={ex.GetType().Name}");
                AuthorityManager.Instance.ChangeLevel(OpLevel.Other);
                MessageBox.Show("加载权限管理器出错，异常信息：" + ex.ToString());
            }
            finally
            {
                StartupDiagnostics.CompleteStage("权限管理器初始化", stageStopwatch);
            }

            //工站
            bgwInitialize.ReportProgress(10, "加载工站管理器");
            

            //初始化状态机
            bgwInitialize.ReportProgress(15, "初始化状态机");

            //基元
            bgwInitialize.ReportProgress(20, "加载基元库");

            //显示
            bgwInitialize.ReportProgress(30, "加载显示类库");
            //if (ShowFactory.Instance.LoadShowTypeAttributes(_showAssemblyPath) != 0)
            //{
            //    MessageBox.Show("显示类库加载失败！");
            //}
            //Thread.Sleep(100);
            //try
            //{
            //    if (SwManager.Instance.DisplayConfigEnable && File.Exists(SwManager.Instance.DisplayFile))
            //    {
            //        bgwInitialize.ReportProgress(35, "初始化所有显示基元");
            //        _showConfigs = ProxyTools.XmlSerializerHelper.ReadXML(SwManager.Instance.DisplayFile, typeof(ShowConfigs)) as ShowConfigs;
            //        int num5 = SystemCreateShow(SwManager.Instance.DisplayFile);
            //        int num6 = ShowManager.Instance.ShowConfigFormInit(_showAssemblyPath, showAssemblyLoaded: false);
            //        if (_showConfigs == null || num5 != 0 || num6 != 0)
            //        {
            //            MessageBox.Show("显示基元配置加载失败！");
            //        }
            //    }
            //}
            //catch (Exception ex3)
            //{
            //    MessageBox.Show("显示基元加载失败，异常信息：" + ex3.Message);
            //}

            //元件
            stageStopwatch = StartupDiagnostics.StartStage("元件管理器初始化");
            Thread.Sleep(100);
            try
            {
                if (SwManager.Instance.ElesConfigEnable && File.Exists(SwManager.Instance.ElesFile))
                {
                    bgwInitialize.ReportProgress(40, "加载元件管理器");

                    num = ElesManagerTransfer.ElesManagerInit(SwManager.Instance.ElesFile, _elesAssemblyPath);
                    if (num < 0)
                        MessageBox.Show("元件管理器加载失败");
                }
                else
                {
                    ElesManagerTransfer.ElesConfigFormInit();
                }
            }
            catch (Exception ex4)
            {
                StartupDiagnostics.Mark("元件管理器初始化异常", $"exception={ex4.GetType().Name}");
                MessageBox.Show("元件管理器加载失败：" + ex4.ToString());
            }
            finally
            {
                StartupDiagnostics.CompleteStage("元件管理器初始化", stageStopwatch);
            }

            //任务
            stageStopwatch = StartupDiagnostics.StartStage("任务管理器初始化");
            Thread.Sleep(100);
            try
            {
                if (SwManager.Instance.TasksConfigEnable && File.Exists(SwManager.Instance.TasksFile))
                {
                    bgwInitialize.ReportProgress(50, "加载任务管理器");
                    num = TasksManagerTransfer.TasksManagerInit(SwManager.Instance.TasksFile, _tasksAssemblyPath);
                    if (num < 0)
                    {
                        MessageBox.Show("任务管理器加载失败");
                    }
                }
            }
            catch (Exception ex5)
            {
                StartupDiagnostics.Mark("任务管理器初始化异常", $"exception={ex5.GetType().Name}");
                MessageBox.Show("任务管理器加载失败：" + ex5.ToString());
            }
            finally
            {
                StartupDiagnostics.CompleteStage("任务管理器初始化", stageStopwatch);
            }

            stageStopwatch = StartupDiagnostics.StartStage("语言配置初始化");
            Thread.Sleep(100);
            try
            {
                LanguageManager.Instance.Init();
                bgwInitialize.ReportProgress(60, "加载语言配置");
            }
            catch (Exception ep) 
            {
                StartupDiagnostics.Mark("语言配置初始化异常", $"exception={ep.GetType().Name}");
                MessageBox.Show("语言配置加载失败：" + ep.ToString());
            }
            finally
            {
                StartupDiagnostics.CompleteStage("语言配置初始化", stageStopwatch);
            }

            //脉冲比较触发
            stageStopwatch = StartupDiagnostics.StartStage("脉冲比较触发初始化");
            Thread.Sleep(100);
            try
            {
                if (SwManager.Instance.CmpTrigConfigEnable && File.Exists(SwManager.Instance.CmpTrigFilePath))
                {
                    bgwInitialize.ReportProgress(90, "载入脉冲比较触发功能模块");
                    if (TriggerManager.Instance.Init(SwManager.Instance.CmpTrigFilePath) != 0)
                    {
                        MessageBox.Show("比较触发配置文件载入不成功");
                    }
                }
            }
            catch (Exception ex6)
            {
                StartupDiagnostics.Mark("脉冲比较触发初始化异常", $"exception={ex6.GetType().Name}");
                MessageBox.Show("脉冲比较触发功能载入失败：" + ex6.ToString());
            }
            finally
            {
                StartupDiagnostics.CompleteStage("脉冲比较触发初始化", stageStopwatch, $"enabled={SwManager.Instance.CmpTrigConfigEnable}");
            }

            //FAI
            stageStopwatch = StartupDiagnostics.StartStage("FAI配置初始化");
            Thread.Sleep(100);
            try
            {
                if (SwManager.Instance.FaiConfigEnable && File.Exists(SwManager.Instance.FaiConfigFilePath))
                {
                    bgwInitialize.ReportProgress(95, "载入FAI功能配置");
                    if (FaiManager.Instance.Init(SwManager.Instance.FaiConfigFilePath) != 0)
                    {
                        MessageBox.Show("FAI配置文件载入不成功");
                    }
                }
            }
            catch (Exception ex7)
            {
                StartupDiagnostics.Mark("FAI配置初始化异常", $"exception={ex7.GetType().Name}");
                MessageBox.Show("FAI配置载入失败：" + ex7.ToString());
            }
            finally
            {
                StartupDiagnostics.CompleteStage("FAI配置初始化", stageStopwatch, $"enabled={SwManager.Instance.FaiConfigEnable}");
            }

            //点胶
            //Thread.Sleep(100);
            //try
            //{
            //    if (SwManager.Instance.DispenserConfigEnable && File.Exists(SwManager.Instance.DispenserFilePath))
            //    {
            //        bgwInitialize.ReportProgress(95, "载入点胶功能配置");
            //        if (DispenserManager.Instance.Init(SwManager.Instance.DispenserFilePath) != 0)
            //        {
            //            MessageBox.Show("点胶配置载入不成功");
            //        }
            //    }
            //}
            //catch (Exception ex8)
            //{
            //    MessageBox.Show("点胶配置载入：" + ex8.ToString());
            //}

            //加载Tracking程序集
            bgwInitialize.ReportProgress(96, "加载Tracking程序集");
            stageStopwatch = StartupDiagnostics.StartStage("Tracking程序集加载");
            Thread.Sleep(100);
            try
            {
                LoadAssemblies(_trackingAssemblyPath, "Tracking程序集反射加载");
                Assembly.LoadFrom("ExtLibs\\Sys\\MongoDB\\MongoDB.Bson.dll");
            }
            catch (Exception ex)
            {
                StartupDiagnostics.Mark("Tracking程序集加载异常", $"exception={ex.GetType().Name}");
            }
            finally
            {
                StartupDiagnostics.CompleteStage("Tracking程序集加载", stageStopwatch, $"enabled={SwManager.Instance.TrackingEnable}");
            }

            //初始化Spring和Wcf模块
            if (SwManager.Instance.TrackingEnable)
            {
                bgwInitialize.ReportProgress(98, "初始化Spring和Wcf模块");
                stageStopwatch = StartupDiagnostics.StartStage("Spring和Wcf初始化");
                Thread.Sleep(100);
                try
                {
                    InitSpringAndWcf();
                }
                catch (Exception ex10)
                {
                    StartupDiagnostics.Mark("Spring和Wcf初始化异常", $"exception={ex10.GetType().Name}");
                    MessageBox.Show("Spring和Wcf模块载入失败：" + ex10.ToString());
                }
                finally
                {
                    StartupDiagnostics.CompleteStage("Spring和Wcf初始化", stageStopwatch);
                }
            }
            else
            {
                StartupDiagnostics.Mark("Spring和Wcf初始化跳过", "enabled=False");
            }

            //第三方库
            bgwInitialize.ReportProgress(99, "加载其他程序集");
            Thread.Sleep(100);
            LoadAssemblies(_thirdLibsPath, "第三方程序集加载");
            bgwInitialize.ReportProgress(100, "软件初始化完成！");
            StartupDiagnostics.Mark("欢迎页后台任务完成");
        }

        private void bgwInitialize_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbarStatus.Value = e.ProgressPercentage;
            lblStatus.Text += $"\r\n{NLocalizer.GetString("",e.UserState.ToString())}";
        }

        private void bgwInitialize_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString());
            }
            StartupDiagnostics.Mark("欢迎页后台任务回调完成");
            Close();
        }
        #endregion



        #region Others
        /// <summary>加载程序使用显示集合</summary>
        private int SystemCreateShow(string configPath)
        {
            int result = 0;
            if (_showConfigs == null) return -5;

            foreach (SingleShowConfig listShowConfig in _showConfigs.ListShowConfigs)
            {
                IShow show = ShowManagerTransfer.GetShow(listShowConfig.ShowType, listShowConfig.ShowXmlNode, configPath);
                if (show == null)
                {
                    MessageBox.Show(listShowConfig.ShowType + " 不能加载", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    ShowManagerTransfer.AddShow(show);
                }
            }
            return result;
        }
        private void InitSpringAndWcf()
        {
            try
            {
                IApplicationContext springContext = ContextRegistry.GetContext();
                ServiceLocator.SetLocatorProvider((ServiceLocatorProvider)(object)(ServiceLocatorProvider)(() => (IServiceLocator)(object)new SpringServiceLocatorAdapter(springContext)));
                HeartBeatServiceManager.Instance.InitClient();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void LoadAssemblies(string dirPath, string stageName)
        {
            Stopwatch stageStopwatch = StartupDiagnostics.StartStage(stageName, $"directory={dirPath}");
            int dllCount = 0;
            int successCount = 0;
            int failureCount = 0;
            DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
            try
            {
                FileInfo[] files = directoryInfo.GetFiles("*.dll");
                dllCount = files.Length;
                foreach (FileInfo fileInfo in files)
                {
                    try
                    {
                        Assembly.LoadFrom(fileInfo.FullName);
                        successCount++;
                    }
                    catch (Exception ex)
                    {
                        failureCount++;
                        Debug.WriteLine(ex.ToString());
                    }
                }
            }
            finally
            {
                StartupDiagnostics.CompleteStage(stageName, stageStopwatch, $"directory={dirPath}; dllCount={dllCount}; success={successCount}; failed={failureCount}");
            }
        }
        #endregion
    }
}
