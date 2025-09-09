using System;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleDI
{
    public class EleDIConfig
    {
        public EleDIConfig()
        {
            DevName = "";
            Id = Guid.NewGuid();
            Info = "";
            IsSimulateMode = false;
            Name = "";
            DiType = EleDIType.NO;
            EleTypeName = "DI";
            Enable = true;
            LogEnable = true;
            LogDisplay = false;
            DiAddress = 0;
            DiEnable = true;
            LineMark = "";
        }

        public string DevName { set; get; }
        public double DiAddress { set; get; }
        public bool DiEnable { set; get; }

        //Ele Cylinder Line Interface
        public EleDIType DiType { set; get; }

        public string EleTypeName { set; get; }
        public bool Enable { set; get; }
        public bool EnFallEvent { get; set; }
        public bool EnRiseEvent { get; set; }
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
            valueStr += DiAddress.ToString("f2") + ",";
            valueStr += DiEnable.ToString() + ",";
            valueStr += DiType.ToString() + ",";
            valueStr += EnRiseEvent.ToString() + ",";
            valueStr += EnFallEvent.ToString() + ",";
            valueStr += LineMark.ToString() + ",";
            valueStr += "";
            return valueStr;
        }
        public string CsvHeader()
        {
            string header = "";
            header = "名称,信息,使能,模拟,基元名称,地址,输入使能,输入类型,上升沿使能,下降沿使能,线号";
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
            DiAddress = double.TryParse(valuses[5], out double adr) ? adr : 0.00;
            DiEnable = bool.TryParse(valuses[6], out bool dienable) ? dienable : false;
            DiType = System.Enum.TryParse<EleDIType>(valuses[7], out EleDIType ditype) ? ditype : EleDIType.NO;
            EnRiseEvent = bool.TryParse(valuses[8], out bool rise) ? rise : false;
            EnFallEvent = bool.TryParse(valuses[9], out bool fall) ? fall : false;
            LineMark = valuses[10];
        }
    }
}