using System;
using System.Collections.Concurrent;
using Lead.CPrim.Interfaces;
using Newtonsoft.Json;

namespace Lead.CPrim.StationCommon.Recipe
{
	/// <summary>
	/// 配方管理器
	/// </summary>
	[JsonObject(/*Could not decode attribute arguments.*/)]
	public class SingleRecipeCfg
	{
		#region Prop
		/// <summary>配方名称</summary>
		public string Name { get; set; }
		/// <summary>配方创建者</summary>
		public string Creator { get; set; }
		/// <summary>配方创建时间</summary>
		public DateTime CreatTime { get; set; }
		/// <summary>配方编辑</summary>
		public DateTime EditTime { get; set; }
		/// <summary>配方基元集合</summary>
		public ConcurrentDictionary<int, PrimMember> Prims { get; set; }
		/// <summary>配方元件集合</summary>
		public ConcurrentDictionary<int, EleMember> Eles { get; set; }
		/// <summary>配方任务集合</summary>
		public ConcurrentDictionary<int, TaskMember> Tasks { get; set; }
		/// <summary>当前全局变量名称</summary>
		public string VariableName { get; set; }
		/// <summary>当前主界面名称</summary>
		public string MainGuiConfigName { get; set; }
		/// <summary>当前实时变量名称</summary>
		public string OutputValsName { get; set; }
		public ConcurrentDictionary<string, ConcurrentDictionary<int, TaskMember>> RunMode_Tasks { get; set; }

		/// <summary>配方ID（未使用）</summary>
		public int ID { get; set; } 
		#endregion


		#region Ctor
		/// <summary>Ctor</summary>
		public SingleRecipeCfg()
		{
			CreatTime = DateTime.Now;
			EditTime = DateTime.Now;
			Name = "Recipe00";
			Creator = "UnKnow";
			ID = 0;
			Prims = new ConcurrentDictionary<int, PrimMember>();
			Eles = new ConcurrentDictionary<int, EleMember>();
			Tasks = new ConcurrentDictionary<int, TaskMember>();
			RunMode_Tasks = new ConcurrentDictionary<string, ConcurrentDictionary<int, TaskMember>>();
			VariableName = "";
			OutputValsName = "";
			MainGuiConfigName = "";
		} 
		#endregion


		#region 外部调用
		/// <summary>返回配方信息</summary>
		/// <returns>string</returns>
		public override string ToString()
		{
			string txt = "";
			txt = txt + "Name: " + Name + "\r\n\r\n";
			txt = txt + "TaskCount: " + Tasks.Count + "\r\n";
			txt = txt + "Variable : " + VariableName + "\r\n";
			txt = txt + "MainGuiConfig : " + MainGuiConfigName + "\r\n";
			txt = txt + "OutputVals : " + OutputValsName + "\r\n\r\n";
			txt += "CreatTime:\r\n";
			txt = txt + CreatTime.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
			txt += "EditTime:\r\n";
			return txt + EditTime.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
		}
		#endregion
	}
}
