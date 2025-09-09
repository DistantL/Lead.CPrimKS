using System;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleDO
{
    public class EleDOConfig
    {
        public EleDOConfig()
        {
            DevName = "";
            Id = Guid.NewGuid();
            Info = "";
            IsSimulateMode = false;
            Name = "";
            EleRunStat = EleRunState.Other;
            DoType = EleDOType.NO;
            EleTypeName = "DO";
            Enable = true;
            LogEnable = true;
            LogDisplay = false;
            DoAddress = 0;
            DoEnable = true;
            LineMark = "";
        }

        public string DevName { set; get; }
        public double DoAddress { set; get; }
        public bool DoEnable { set; get; }

        //Ele Cylinder Line Interface
        public EleDOType DoType { set; get; }

        public EleRunState EleRunStat { set; get; }
        public string EleTypeName { set; get; }
        public bool Enable { set; get; }
        public Guid Id { set; get; }
        public string Info { set; get; }
        public bool IsSimulateMode { set; get; }
        public bool LogDisplay { set; get; }
        public bool LogEnable { set; get; }
        public string Name { set; get; }
        public string LineMark { set; get; }
        public string CsvValue()
        {
            string valueStr = "";
            valueStr += Name + ",";
            valueStr += Info + ",";
            valueStr += Enable.ToString() + ",";
            valueStr += IsSimulateMode.ToString() + ",";
            valueStr += DevName + ",";
            valueStr += DoAddress.ToString("f2") + ",";
            valueStr += DoEnable.ToString() + ",";
            valueStr += DoType.ToString() + ",";
            valueStr += LineMark.ToString() + ",";
            valueStr += "";
            return valueStr;
        }
        public string CsvHeader()
        {
            string header = "";
            header = "名称,信息,使能,模拟,基元名称,地址,输入使能,输入类型,线号";
            return header;
        }
        public void CsvToValue(string strValue)
        {
            var valuses = strValue.Split(',');
            Name = valuses[0];
            Info = valuses[1];
            Enable = bool.TryParse(valuses[2], out bool output) ? output : true;
            IsSimulateMode = bool.TryParse(valuses[3], out bool upload) ? upload : true;
            DevName = valuses[4];
            DoAddress = double.TryParse(valuses[5], out double adr) ? adr : 0.00;
            DoEnable = bool.TryParse(valuses[6], out bool dienable) ? dienable : false;
            DoType = System.Enum.TryParse<EleDOType>(valuses[7], out EleDOType dotype) ? dotype : EleDOType.NO;
            LineMark = valuses[8];
        }
    }
}