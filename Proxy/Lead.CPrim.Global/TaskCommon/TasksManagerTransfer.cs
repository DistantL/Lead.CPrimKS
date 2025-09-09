using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lead.CPrim.Global
{
    public class TasksManagerTransfer
	{
		#region Prop
		/// <summary>任务配置UI</summary>
		public static Form TasksConfigForm => TasksManager.Instance.TasksConfigForm;
		#endregion



		#region Method_ExternalUsing
		/// <summary>根据GUID获取ITask</summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public static ITask GetTaskByGUID(Guid id)
		{
			return TasksManager.Instance.GetTaskByGUID(id);
		}

		/// <summary>根据名称获取ITask</summary>
		/// <param name="taskName"></param>
		/// <returns></returns>
		public static ITask GetTaskByName(string taskName)
		{
			return TasksManager.Instance.GetTaskByName(taskName);
		}

		/// <summary>新增ITask</summary>
		/// <param name="task">任务</param>
		public static void AddTask(ITask task)
		{
			TasksManager.Instance.AddTask(task);
		}

		/// <summary>通过GUID移除任务</summary>
		/// <param name="id"></param>
		/// <returns>-10:不存在该任务；-1：移除失败</returns>
		public static int RemoveTaskByGUID(Guid id)
		{
			return TasksManager.Instance.RemoveTaskByGUID(id);
		}

		/// <summary>通过GUID设置任务名称</summary>
		/// <param name="id"></param>
		/// <param name="name"></param>
		/// <returns>-5：参数有误；-10：不存在该任务</returns>
		public static int SetTaskNameByGUID(Guid id, string name)
		{
			return TasksManager.Instance.SetTaskNameByGUID(id, name);
		}

		/// <summary>任务保存</summary>
		/// <returns></returns>
		public static int Save()
		{
			int result = TasksManager.Instance.Save();
			if (result == 0)
			{
				UIMessageTip.ShowOk(NLocalizer.GetString("Lead_CPrim_FaiHelper_TasksManagerTransfer_TasksConfigSaveSuccess", "任务设置保存成功"));
			}
			return result;
		}

		/// <summary>任务初始化</summary>
		/// <param name="taskConfigPath">任务配置地址</param>
		/// <param name="taskAsmPath">任务dll地址</param>
		/// <returns></returns>
		public static int TasksManagerInit(string taskConfigPath, string taskAsmPath)
		{
			return TasksManager.Instance.TasksManagerInit(taskConfigPath, taskAsmPath);
		}

		/// <summary>反射Lead.CPrim.DefaultTask.dll拿到对象</summary>
		/// <returns></returns>
		public static ITask CreateTask()
		{
			return TasksManager.Instance.CreateTask();
		}

		/// <summary>获取所有ITask</summary>
		/// <returns></returns>
		public static List<ITask> GetAllITask()
		{
			return TasksManager.Instance.GetAllITask();
		}

		/// <summary>清除运行中ITask</summary>
		/// <returns></returns>
		public static void ClearRunningITask()
		{
			TasksManager.Instance.ClearRunningITask();
		}
		#endregion
	}
}
