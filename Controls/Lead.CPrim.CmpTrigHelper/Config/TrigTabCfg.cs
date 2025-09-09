using Lead.CPrim.Global;
using System.Collections.Generic;
using System.Linq;

namespace Lead.CPrim.CmpTrigHelper.ConfigClass
{
    public class TrigTabCfg
	{
		public int AglID { get; set; }

		public int OffsetType { get; set; } = 0;


		public int PointNum { get; set; }

		public string TabName { get; set; }

		public int TrigTableID { get; set; }

		public int StartIndex { get; set; }

		public TrigTabCfg(int id, string name, int pointsNum, int aglId, int offsetType)
		{
			TrigTableID = id;
			TabName = name;
			PointNum = pointsNum;
			AglID = aglId;
			OffsetType = offsetType;
		}

		public List<string> GetAglList(string productName)
		{
			return TriggerManager.Instance.Products[productName].TableTrigDatas.Values.ToList().FirstOrDefault((TriggerTableData p) => p.Name == TabName).AglList;
		}

		public SortedList<int, double> GetTrigPosList(string productName)
		{
			return TriggerManager.Instance.Products[productName].TableTrigDatas.Values.ToList().FirstOrDefault((TriggerTableData p) => p.Name == TabName).TrigPoints;
		}

		public override string ToString()
		{
			return TabName;
		}
	}
}
