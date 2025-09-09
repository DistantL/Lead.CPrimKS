/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2022.
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明
 *
 * 3.3.33.0617 -> 
 * 1、任务编辑按钮功能优化，解决管道已经关闭问题；（每次打开脚本编辑器需要开启一个新的管道，否则无需开启管道）
******************************************************************************/

using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Lead.CPrim.TaskCommon.TaskEdit;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Lead.CPrim.TaskCommon
{
    public partial class TaskConfigForm : UIPage
    {
        #region Field
        /// <summary>工作目录</summary>
        private readonly string _curDominStartPath = Environment.CurrentDirectory;
        /// <summary>已选择任务</summary>
        private ITask _curTask;
        /// <summary>操作LeadDevelop类</summary>
        private PipeClient _pipeClient;
        /// <summary>文件完整目录_文件名称键值对</summary>
        private Dictionary<string, string> _scriptInfoDic;
        #endregion



        #region Prop
        /// <summary>已选择任务</summary>
        public ITask CurTask
        {
            get { return _curTask; }
            set
            {
                _curTask = value;
                _curTask.IsSelected = true;
            }
        }
        #endregion



        #region API
        /// <summary>获取窗口的句柄</summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        /// <summary>最大化窗口3，最小化窗口2，正常大小窗口1；</summary>
        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        [DllImport("user32.dll ")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        #endregion



        #region Ctor
        public TaskConfigForm()
        {
            InitializeComponent();
            //this.DockHandler.HideOnClose = true;
            flpTask.SetDoubleBuffered();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        //*****************************************************************************
        #region System_Event
        private void TaskConfigForm_Load(object sender, EventArgs e)
        {
            foreach (ITask task in TasksManager.Instance.ListTask)
            {
                if (task != null)
                {
                    task.OnTaskSelected += InstanceOnTaskSelected;
                    flpTask.Controls.Add(task.TaskConfigUI);
                }
            }
            tbTaskSpacePath.Text = TasksManager.Instance.TaskSpacePath;
        }
        #endregion



        //*****************************************************************************
        #region Method_Instanc
        /// <summary>任务【ConfigUI】被选择事件响应</summary>
        /// <param name="task"></param>
        /// <returns></returns>
        private int InstanceOnTaskSelected(ITask task)
        {
            int iRet = 0;
            TasksManager.Instance.ListTask.ForEach(t => t.IsSelected = false);
            CurTask = task;
            return iRet;
        }
        #endregion



        //*****************************************************************************
        #region Button_Event
        /// <summary>文件选择</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTaskSpacePath_Click(object sender, EventArgs e)
        {
            string text = tbTaskSpacePath.Text.Trim();
            if (FileHelper.OpenFolderDialogMethod(ref text))
            {
                tbTaskSpacePath.Text = text;
                TasksManager.Instance.TaskSpacePath = text;
            }
        }
        /// <summary>新建任务</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tStripBtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AuthorityManager.Instance.VerifyLevel3Permission(true))
                {
                    return;
                }

                DirectoryInfo spaceDir = new DirectoryInfo(TasksManager.Instance.TaskSpacePath);
                if (!spaceDir.Exists)
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_TaskCommon_TaskConfigForm_ErrMsg_TaskDirPathNoExist", "任务脚本路径不存在"));
                }

                NewTaskForm f = new NewTaskForm();
                f.ShowDialog();
                if (f.DialogResult != DialogResult.OK)
                {
                    return;
                }

                string taskName = f.GetTaskName();
                string taskFolderDst = TasksManager.Instance.TaskSpacePath + "\\" + taskName;
                if (Directory.Exists(taskFolderDst))
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_TaskCommon_TaskConfigForm_ErrMsg_TaskNameExist", "该任务名称已存在"));
                }

                Directory.CreateDirectory(taskFolderDst);
                string taskTemplatePathSrc = _curDominStartPath + "\\TaskTemplates";
                if (Directory.Exists(taskTemplatePathSrc))
                {
                    //CopyOldLabFilesToNewLab(taskTemplatePathSrc, taskFolderDst, taskName);
                    FileHelper.CopyDirectory(taskTemplatePathSrc, taskFolderDst, false);
                }

                ITask task = TasksManager.Instance.CreateTask();
                if (task != null)
                {
                    task.Name = taskName;
                    task.Enable = true;
                    task.CurStep = -1;
                    task.LastStep = -1;
                    task.Id = Guid.NewGuid();
                    task.Idx = TasksManager.Instance.ListTask.Count + 1;
                    task.Info = "Proc Task";
                    task.IsSelected = false;
                    task.Type = (TaskFileType)0;
                    task.TaskFolderPath = TasksManager.Instance.TaskSpacePath + "\\" + taskName;
                    task.OnTaskSelected += InstanceOnTaskSelected;
                    flpTask.Controls.Add(task.TaskConfigUI);
                    TasksManager.Instance.ListTask.Add(task);
                }
                tStripBtnSave_Click(null, null);
                TasksManager.Instance.LogAdd(
    string.Format(
            NLocalizer.GetString("Lead_CPrim_TaskCommon_TaskConfigForm_Tip_TaskAddSuccess", "新增任务：[{0}]成功"), taskName)
    , LogLevel.Trace);
            }
            catch (Exception ex)
            {
                TasksManager.Instance.LogAdd(NLocalizer.GetString("Lead_CPrim_TaskCommon_TaskConfigForm_ErrMsg_TaskAddFail", "新增任务失败:") + ex.Message, LogLevel.Warn, true);
            }
        }
        /// <summary>删除任务</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tStripBtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AuthorityManager.Instance.VerifyLevel3Permission(true))
                {
                    return;
                }

                DirectoryInfo spaceDir = new DirectoryInfo(TasksManager.Instance.TaskSpacePath);
                if (!spaceDir.Exists)
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_TaskCommon_TaskConfigForm_ErrMsg_TaskDirPathNoExist", "任务脚本路径不存在"));
                }

                if (!UIMessageDialog.ShowMessageDialog(
                    NLocalizer.GetString("Lead_CPrim_TaskCommon_TaskConfigForm_Tip_ConfirmToDeleteTask", "确定要删除该任务吗?")
                    , ULocalize.InfoTitle
                    , true
                    , NLocalizer.GetString("Lead_CPrim_TaskCommon_TaskConfigForm_Delete", "删除")
                    , NLocalizer.GetString("Lead_CPrim_TaskCommon_TaskConfigForm_Cancel", "取消")
                    , UIStyle.Gray, false, true))
                {
                    return;
                }

                foreach (ITask task in TasksManager.Instance.ListTask)
                {
                    if (!task.IsSelected)
                    {
                        continue;
                    }

                    flpTask.Controls.Remove(task.TaskConfigUI);
                    TasksManager.Instance.ListTask.Remove(task);

                    foreach (DirectoryInfo t in spaceDir.GetDirectories())
                    {
                        if (t.Name.Contains(task.Name))
                        {
                            string path = Path.Combine(TasksManager.Instance.TaskSpacePath, task.Name);
                            if (Directory.Exists(path))
                            {
                                FileSystem.DeleteDirectory(path, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                            }
                        }
                    }
                    tStripBtnSave_Click(null, null);
                    TasksManager.Instance.LogAdd(
                        string.Format(
                                NLocalizer.GetString("Lead_CPrim_TaskCommon_TaskConfigForm_Tip_TaskDeleteSuccess", "删除任务：[{0}]成功"), task.Name)
                        , LogLevel.Trace);
                    break;
                }
            }
            catch (Exception ex)
            {
                TasksManager.Instance.LogAdd(NLocalizer.GetString("Lead_CPrim_TaskCommon_TaskConfigForm_ErrMsg_TaskDeleteFail", "删除任务失败:") + ex.Message, LogLevel.Warn, true);
            }
        }
        private void tStripBtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AuthorityManager.Instance.VerifyLevel3Permission(true))
                {
                    return;
                }

                DirectoryInfo spaceDir = new DirectoryInfo(TasksManager.Instance.TaskSpacePath);
                if (!spaceDir.Exists)
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_TaskCommon_TaskConfigForm_ErrMsg_TaskDirPathNoExist", "任务脚本路径不存在"));
                }

                if (IsRepeat(TasksManager.Instance.ListTask))
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_TaskCommon_TaskConfigForm_ErrMsg_TaskIndexOrTaskNameRepeat", "任务列表中有重复的任务序号或任务名"));
                }

                TasksManager.Instance.Save();
            }
            catch (Exception ex)
            {
                TasksManager.Instance.LogAdd(NLocalizer.GetString("Lead_CPrim_TaskCommon_TaskConfigForm_ErrMsg_TaskSaveFail", "保存任务失败:") + ex.Message, LogLevel.Warn, true);
            }
        }
        /// <summary>任务编辑</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tStripBtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AuthorityManager.Instance.VerifyLevel3Permission(true) || _curTask == null)
                {
                    return;
                }

                bool exist = true;
                IntPtr findPtr = FindWindow(null, "LeadDevelop");
                _scriptInfoDic = getScriptDic(_curTask.TaskFolderPath);
                if (findPtr.ToInt32() == 0)
                {
                    exist = false;
                    Process.Start(_curDominStartPath + "\\Edit-4.2\\bin\\LeadDevelop.exe");
                    Stopwatch sw = new Stopwatch();
                    sw.Restart();
                    findPtr = FindWindow(null, "LeadDevelop");
                    while (findPtr.ToInt32() == 0)
                    {
                        findPtr = FindWindow(null, "LeadDevelop");
                        Thread.Sleep(1000);
                        if (sw.ElapsedMilliseconds >= 8000)
                        {
                            throw new Exception(NLocalizer.GetString("Lead_CPrim_TaskCommon_TaskConfigForm_ErrMsg_OpenTimeout", "LeadDevelop打开超时"));
                        }
                    }
                }

                if (!exist || _pipeClient == null)
                {
                    _pipeClient = new PipeClient();
                    _pipeClient.StartPipeClient();
                }
                _pipeClient.SendMessage(_scriptInfoDic);
                ShowWindow(findPtr, 3);
                SetForegroundWindow(findPtr);
            }
            catch (Exception ex)
            {
                TasksManager.Instance.LogAdd(NLocalizer.GetString("Lead_CPrim_TaskCommon_TaskConfigForm_ErrMsg_TaskEditFail", "编辑任务失败:") + ex.Message, LogLevel.Warn, true);
            }
        }
        #endregion



        //*****************************************************************************
        #region Method_InternalUsing
        /// <summary>返回文件完整目录_文件名称键值对</summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private Dictionary<string, string> getScriptDic(string path)
        {
            Dictionary<string, string> fileName = new Dictionary<string, string>();
            DirectoryInfo dir = new DirectoryInfo(path);
            try
            {
                foreach (FileInfo file in dir.GetFiles())
                {
                    if (file.Extension == ".cs")
                    {
                        fileName.Add(file.FullName, file.Name);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return fileName;
        }
        /// <summary>检查任务名称与序号是否重复</summary>
        /// <param name="tasks">任务集合</param>
        /// <returns>true：重复；false：无重复</returns>
        private bool IsRepeat(List<ITask> tasks)
        {
            Hashtable htName = new Hashtable();
            Hashtable htIdx = new Hashtable();
            foreach (ITask t in tasks)
            {
                if (htName.Contains(t.Name) || htIdx.Contains(t.Idx))
                {
                    return true;
                }
                htName.Add(t.Name, t.Name);
                htIdx.Add(t.Idx, t.Idx);
            }
            return false;
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>使能状态设置</summary>
        /// <param name="enable">true：使能状态；false：非使能状态</param>
        internal void SetEnable(bool enable)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetEnable), enable);
                return;
            }
            tsTitle.Enabled = enable;
            spcMain.Enabled = enable;
        }
        #endregion



        #region Method_Obsolete
        /// <summary>拷贝oldlab的文件到newlab下面</summary>
        /// <param name="sourcePath">lab文件所在目录(@"~\labs\oldlab")</param>
        /// <param name="savePath">保存的目标目录(@"~\labs\newlab")</param>
        /// <param name="taskName">任务名称</param>
        /// <returns>返回:true-拷贝成功;false:拷贝失败</returns>
        [Obsolete]
        private bool CopyOldLabFilesToNewLab(string sourcePath, string savePath, string taskName)
        {
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            try
            {
                string[] labDirs = Directory.GetDirectories(sourcePath);
                string[] labFiles = Directory.GetFiles(sourcePath);
                if (labFiles.Length != 0)
                {
                    for (int i = 0; i < labFiles.Length; i++)
                    {
                        if (Path.GetExtension(labFiles[i]) != ".lab")
                        {
                            File.Copy(sourcePath + "\\" + Path.GetFileName(labFiles[i]), savePath + "\\" + Path.GetFileName(labFiles[i]), true);
                        }
                    }
                }
                if (labDirs.Length != 0)
                {
                    for (int j = 0; j < labDirs.Length; j++)
                    {
                        Directory.GetDirectories(sourcePath + "\\" + Path.GetFileName(labDirs[j]));
                        CopyOldLabFilesToNewLab(sourcePath + "\\" + Path.GetFileName(labDirs[j]), savePath + "\\" + Path.GetFileName(labDirs[j]), taskName);
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

        public void OnLanguageChanged()
        {
            lb_TaskDirPath.Text = NLocalizer.GetString("Lead_CPrim_TaskCommon_TaskConfigForm_TaskDirPath", "任务路径:");
            tPageProcTask.Text = NLocalizer.GetString("Lead_CPrim_TaskCommon_TaskConfigForm_ProcTask", "任务列表");
        }
    }
}