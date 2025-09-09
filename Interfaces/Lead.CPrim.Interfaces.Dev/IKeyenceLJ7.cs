using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.Interfaces.Dev
{
    public interface IKeyenceLJ7
    {
		int ClearBatch(int deviceId);

		List<int[]> GetBatchArray(int deviceId);

		int GetBatchCount(int deviceId);

		int StartMeasure(int deviceId);

		int StartMeasure();

		int StopMeasure(int deviceId);

		int StopMeasure();
	}
}
