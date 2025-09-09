using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafty_StreamlineControl
{
    public interface ImesFuction
    {
        string GetUserLevel_withBadgeID(string id, int tryCount = 3);

        string GetSN_withUCSN(string ucSN, int tryCount = 3);

        bool CheckSN_withSN(string sN, string lotNoSN = "", int tryCount = 3);

        bool GetSnPartType_withSN(string sN, out string sNPartType, int tryCount = 3);

        bool UpData(ProductionInfo productionInfo, List<FaiItem> fais,string lotNo = "",bool checkOK = true, int tryCount = 3);

        bool GoPass(string ucSN, string sN, string lotNoSN = "", int tryCount = 3);

        string MaintenceMesUpload(string userId, string project, string line, string headId, string item, string maxTime, string alertTime, bool isAdd);

        string HashKeyMesUpload(string id, string project,string result);

        bool HashKeyMesCheck(string result, ref string msg, int tryCount = 3);

        bool UpCollMachineState(MachineStateConfig machineStateConfig, DateTime changeTime, string hashKey, int tryCount = 3);

    }
}
