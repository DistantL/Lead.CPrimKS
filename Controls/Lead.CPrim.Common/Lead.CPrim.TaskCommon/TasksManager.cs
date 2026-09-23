using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Lead.CPrim.TaskCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.Global
{
	/// <summary>
	/// 任务管理器
	/// </summary>
	public class TasksManager
	{
		#region Field
		/// <summary>任务管理器实例</summary>
		private static readonly TasksManager _instance = new TasksManager();

		/// <summary>任务集合</summary>
		private List<ITask> _listTask = new List<ITask>();

		/// <summary>任务脚本路径</summary>
		private string _taskSpacePath = "";

		/// <summary>任务管理器配置路径</summary>
		private string _taskConfigPath = "";

		/// <summary>任务配置UI</summary>
		private TaskConfigForm _tasksConfigForm;
		#endregion



		#region Prop
		/// <summary>任务管理器实例</summary>
		public static TasksManager Instance => _instance;

		/// <summary>任务集合</summary>
		public List<ITask> ListTask => _listTask;

		/// <summary>任务配置UI</summary>
		public TaskConfigForm TasksConfigForm => _tasksConfigForm;

		/// <summary>任务脚本路径</summary>
		public string TaskSpacePath { get => _taskSpacePath;  set => _taskSpacePath = value; }

		/// <summary>运行中Task</summary>
		public List<ITask> ITasks { get; } = new List<ITask>();

		/// <summary>Lead.CPrim.DefaultTask.dll文件夹</summary>
		public string TasksFolderPath { get; set; }
		#endregion



		#region Ctor
		public TasksManager()
		{
			AuthorityManager.OnUpdateLevel += InstanceUpdateLevel;
		}
		#endregion



		#region Method_Instance
		/// <summary>响应权限等级改变</summary>
		/// <param name="level"></param>
		private void InstanceUpdateLevel(OpLevel level)
		{
			bool enable = AuthorityManager.Instance.VerifyLevel3Permission();
			SetEnable(enable);
		}
		#endregion



		#region Method_ExternalUsing
		/// <summary>根据GUID获取ITask</summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ITask GetTaskByGUID(Guid id)
		{
			if (_listTask.Count < 1)
				return null;
			return _listTask.FirstOrDefault(t => t.Id == id);
		}

		/// <summary>根据名称获取ITask</summary>
		/// <param name="taskName"></param>
		/// <returns></returns>
		public ITask GetTaskByName(string taskName)
		{
			if (_listTask.Count < 1 || string.IsNullOrEmpty(taskName))
				return null;
			return _listTask.FirstOrDefault(t => t.Name == taskName);
		}

		/// <summary>新增ITask</summary>
		/// <param name="task">任务</param>
		/// <returns></returns>
		public void AddTask(ITask task)
		{
			if(task == null)
            {
				return;
            }

			ITasks.Add(task);
		}

		/// <summary>通过GUID移除任务</summary>
		/// <param name="id"></param>
		/// <returns>-10:不存在该任务；-1：移除失败</returns>
		public int RemoveTaskByGUID(Guid id)
		{
			ITask task = _listTask.FirstOrDefault(t => t.Id == id);
			if (task == null)
				return -10;
			if (_listTask.Remove(task))
				return 0;
			else
				return -1;
		}

		/// <summary>清除运行中ITask</summary>
		/// <returns></returns>
		public void ClearRunningITask()
		{
			if(!ITasks.IsValid())
            {
				return;
            }

			ITasks.Clear();
		}

		/// <summary>通过GUID设置任务名称</summary>
		/// <param name="id"></param>
		/// <param name="name"></param>
		/// <returns>-5：参数有误；-10：不存在该任务</returns>
		public int SetTaskNameByGUID(Guid id, string name)
		{
			if (string.IsNullOrEmpty(name))
				return -5;
			ITask task = _listTask.FirstOrDefault(t => t.Id == id);
			if (task == null)
				return -10;
			task.Name = name;
			return 0;
		}

		/// <summary>任务保存</summary>
		/// <returns></returns>
		public int Save()
		{
			if(!AuthorityManager.Instance.VerifyLevel3Permission(true))
            {
				return -1;
            }
            string oldRoot = _taskSpacePath;
            var oldPaths = ListTask.Select(task => task.TaskFolderPath).ToArray();
            try
            {
                // 文本框只暂存编辑，点击保存后才同步运行路径和持久化配置。
                string root = _tasksConfigForm?.PendingTaskSpacePath ?? _taskSpacePath;
                if (string.IsNullOrWhiteSpace(root) || !Path.IsPathRooted(root))
                    throw new IOException("任务路径必须是有效的绝对路径。");
                root = Path.GetFullPath(root);
                if (!Directory.Exists(root))
                    throw new DirectoryNotFoundException("任务脚本路径不存在：" + root);
                if (ListTask.GroupBy(task => task.Name).Any(group => group.Count() > 1) ||
                    ListTask.GroupBy(task => task.Idx).Any(group => group.Count() > 1))
                    throw new InvalidOperationException("任务列表中有重复的任务序号或任务名。");

                var paths = new List<string>();
                foreach (ITask task in ListTask)
                {
                    if (string.IsNullOrWhiteSpace(task.Name) || task.Name == "." || task.Name == ".." ||
                        task.Name.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                        throw new InvalidOperationException("任务名称无效：" + task.Name);
                    string path = Path.Combine(root, task.Name);
                    if (!Directory.Exists(path))
                        throw new DirectoryNotFoundException("任务脚本目录不存在：" + path);
                    paths.Add(path);
                }

                var taskInfoSave = new TaskConfigSave
                {
                    TaskSpacePath = root,
                    Id = _tasksConfigForm?.CurTask?.Id ?? Guid.Empty,
                    ListTaskInfo = new List<XmlNode>()
                };
                for (int i = 0; i < ListTask.Count; i++)
                {
                    ITask task = ListTask[i];
                    task.TaskFolderPath = paths[i];
                    taskInfoSave.ListTaskInfo.Add(task.IEleExportConfigXml());
                    if (task.Members != null &&
                        !JsonHelper.SerializeObjectToFile(task.Members, Path.Combine(paths[i], task.Name + ".json"), null))
                        throw new IOException("任务成员配置保存失败：" + paths[i]);
                }
                if (!XmlSerializerHelper.WriteXML(taskInfoSave, _taskConfigPath, typeof(TaskConfigSave)))
                    throw new IOException("任务配置保存失败：" + _taskConfigPath);

                _taskSpacePath = root;
                return 0;
            }
            catch (Exception ex)
            {
                _taskSpacePath = oldRoot;
                for (int i = 0; i < ListTask.Count; i++)
                    ListTask[i].TaskFolderPath = oldPaths[i];
                LogAdd("保存任务失败：" + ex.Message, LogLevel.Warn, true);
                return -1;
            }
		}

		/// <summary>任务初始化</summary>
		/// <param name="taskConfigPath">任务配置地址</param>
		/// <param name="taskAsmPath">任务dll地址</param>
		/// <returns></returns>
		public int TasksManagerInit(string taskConfigPath, string taskAsmPath)
		{
			int iRet = 0;
			TasksFolderPath = taskAsmPath;
			_listTask = new List<ITask>();
			_listTask.Clear();
			_taskConfigPath = taskConfigPath;
			if (!File.Exists(_taskConfigPath))
			{
				File.Create(_taskConfigPath).Close();
				return iRet;
			}
			Guid curId;
			try
			{
				TaskConfigSave taskInfoSave = (TaskConfigSave)XmlSerializerHelper.ReadXML(_taskConfigPath, typeof(TaskConfigSave));
				if (taskInfoSave != null)
				{
					_taskSpacePath = taskInfoSave.TaskSpacePath;
					foreach (XmlNode node in taskInfoSave.ListTaskInfo)
					{
						ITask task2 = CreateTask(node);
						if (task2 != null)
						{
							_listTask.Add(task2);
						}
					}
				}
				curId = taskInfoSave.Id;
			}
			catch (Exception)
			{
				MessageBox.Show(NLocalizer.GetString("TaskCommon_TaskManager_LoadTaskConfigSaveError", "加载任务设置失败!"));
				return -3;
			}
			//初始化时New一个界面
			_tasksConfigForm = new TaskConfigForm();
			foreach (ITask task in _listTask)
			{
				if (task.Id == curId)
					_tasksConfigForm.CurTask = task;
			}
			return iRet;
		}

		/// <summary>反射Lead.CPrim.DefaultTask.dll拿到对象</summary>
		/// <returns></returns>
		public ITask CreateTask()
		{
			ITask task = null;
			if (string.IsNullOrEmpty(TasksFolderPath))
			{
				TasksManager.Instance.LogAdd(NLocalizer.GetString("Lead_CPrim_Global_TasksManager_ErrMsg_DllDirIsEmpty", "Lead.CPrim.DefaultTask.dll文件夹为空"), LogLevel.Warn);
				return null;
			}
			try
			{
				string fileName = TasksFolderPath + "\\Lead.CPrim.DefaultTask.dll";
				if (File.Exists(fileName))
				{
					task = FactoryCreator.GetFactoryClass<ITask>(fileName, "Lead.CPrim.Interfaces.ITask");
				}
				else
				{
					TasksManager.Instance.LogAdd(NLocalizer.GetString("Lead_CPrim_Global_TasksManager_ErrMsg_DllDirNoExist", "Lead.CPrim.DefaultTask.dll文件不存在"), LogLevel.Warn);
				}
			}
			catch (Exception ex)
			{
				TasksManager.Instance.LogAdd(NLocalizer.GetString("Lead_CPrim_Global_TasksManager_ErrMsg_DllReflectFail", "反射Lead.CPrim.DefaultTask.dll失败:") + ex.Message , LogLevel.Warn);
			}
			return task;
		}

		/// <summary>获取所有ITask</summary>
		/// <returns></returns>
		public List<ITask> GetAllITask()
		{
			return ListTask;
		}

		/// <summary>日志增加</summary>
		/// <param name="msg">日志</param>
		/// <param name="lv">日志等级</param>
		/// <param name="isShowDialog">true：显示弹窗；false：不显示弹窗；</param>
		/// <param name="id">id</param>
		public void LogAdd(string msg, LogLevel lv, bool isShowDialog = false, long id = 0)
        {
			msg = $"TaskCommon -> " + msg;
			string tempId = $"{(int)lv}{(int)PrimLogId.TaskCommon}0000";

			if (int.TryParse(tempId, out var intId))
			{
				id += intId;
			}

			LogHelper.LogAdd(lv, msg, PrimLogId.TaskCommon.ToString(), LogClassification.Module, id);

			if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
			{
				UIMessageDialog.ShowMessageDialog(msg, ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
			}
		}
		#endregion



		#region Method_InternalUsing
		/// <summary>使能状态设置</summary>
		/// <param name="enable">true：使能状态；false：非使能状态</param>
		private void SetEnable(bool enable)
		{
			TasksConfigForm?.SetEnable(enable);
		}

		private ITask CreateTask(XmlNode xmlNode)
		{
			ITask task = CreateTask();
			if (task == null)
			{
				return null;
			}
			task.ITaskImportConfigXml(xmlNode);
			task.ITaskImportMembersConfig();
			return task;
		}
		#endregion
	}



	/// <summary>任务配置管理器</summary>
	public class TaskConfigSave
	{
		/// <summary>已选中任务id</summary>
		public Guid Id { get; set; }
		/// <summary>任务信息</summary>
		public List<XmlNode> ListTaskInfo { get; set; }
		/// <summary>任务脚本路径</summary>
		public string TaskSpacePath { get; set; }
	}
}
