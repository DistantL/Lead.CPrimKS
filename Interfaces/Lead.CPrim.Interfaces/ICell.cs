using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.Interfaces
{
	public interface ICell
	{
		Form CellConfigForm { get; }

		Guid CellID { get; set; }

		string CellName { get; set; }

		Form CellOutputForm { get; }

		List<IPrim> IPrimList { get; set; }

		event CellOutputUpdate OnCellOutputUpdate;

		int ICellAddPrim();

		int ICellAddPrim(string primName, Guid primId);

		int ICellAddTask();

		int ICellDelPrim(string primName, Guid primId);

		int ICellDelTask(string taskName, Guid taskId);

		XmlNode ICellExprotConfigXml();

		int ICellImportConfigXml(XmlNode xmlNode);
	}
}
