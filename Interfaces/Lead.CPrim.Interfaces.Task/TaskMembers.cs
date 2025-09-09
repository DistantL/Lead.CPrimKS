using System.Collections.Concurrent;
using Newtonsoft.Json;

namespace Lead.CPrim.Interfaces
{
	[JsonObject(/*Could not decode attribute arguments.*/)]
	public class TaskMembers
	{
		public ConcurrentDictionary<int, EleMember> Eles { get; set; }

		public ConcurrentDictionary<int, PrimMember> Prims { get; set; }

		public int TaskId { get; set; }

		public string TaskName { get; set; }

		public TaskMembers()
		{
			TaskName = "Unkonwn";
			TaskId = 0;
			Prims = new ConcurrentDictionary<int, PrimMember>();
			Eles = new ConcurrentDictionary<int, EleMember>();
		}
	}
}
