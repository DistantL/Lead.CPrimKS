using System;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleCyldLine
{
    public class EleCyldLineConfig
    {
        /// <summary>气缸配置</summary>
        public EleCyldLineConfig()
        {
            DevName = "";
            Id = Guid.NewGuid();
            Info = "";
            IsSimulateMode = false;
            Name = "";
            CyldType = EleCyldType.Cylinder;
            EleCyldState = EleCyldState.Other;
            EleTypeName = "CylinderLine";
            Enable = false;
            LogEnable = true;
            LogDisplay = false;
            StretchTimeOut = 0;
            RestractTimeOut = 0;
            BlowTime = 0;
            StretchDiAddress = 0;
            RestractDiAddress = 0;
            StretchDoAddress = 0;
            RestractDoAddress = 0;
            StretchDiEnable = true;
            RestractDiEnable = true;
            StretchDoEnable = true;
            RestractDoEnable = true;
            AutoMotion = true;
            LineMark = "";
        }

        #region Override IEle
        public Guid Id { set; get; }
        public string DevName { set; get; }
        public string Name { set; get; }
        public string Info { set; get; }
        public bool Enable { set; get; }
        public string EleTypeName { set; get; }
        public bool LogEnable { set; get; }
        public bool LogDisplay { set; get; }
        public bool IsSimulateMode { set; get; }

        #endregion

        #region Override IEleCyldLine
        public bool AutoMotion { set; get; }
        public int BlowTime { set; get; }
        public EleCyldType CyldType { set; get; }
        public EleCyldState EleCyldState { set; get; }
        public double RestractDiAddress { set; get; }
        public bool RestractDiEnable { set; get; }
        public double RestractDoAddress { set; get; }
        public bool RestractDoEnable { set; get; }
        public int RestractTimeOut { set; get; }
        public double StretchDiAddress { set; get; }
        public bool StretchDiEnable { set; get; }
        public double StretchDoAddress { set; get; }
        public bool StretchDoEnable { set; get; }
        public int StretchTimeOut { set; get; }
        public string LineMark { get; set; }

        #endregion


        public string CsvValue()
        {
            string valueStr = "";
            valueStr += Name + ",";
            valueStr += Info + ",";
            valueStr += Enable.ToString() + ",";
            valueStr += IsSimulateMode.ToString() + ",";
            valueStr += DevName + ",";
            valueStr += CyldType.ToString() + ",";
            valueStr += StretchDiAddress.ToString("f2") + ",";
            valueStr += StretchDiEnable.ToString() + ",";
            valueStr += RestractDiAddress.ToString("f2") + ",";
            valueStr += RestractDiEnable.ToString() + ",";
            valueStr += StretchDoAddress.ToString("f2") + ",";
            valueStr += StretchDoEnable.ToString() + ",";
            valueStr += RestractDoAddress.ToString("f2") + ",";
            valueStr += RestractDoEnable.ToString() + ",";
            valueStr += StretchTimeOut.ToString() + ",";
            valueStr += RestractTimeOut.ToString() + ",";
            valueStr += BlowTime.ToString() + ",";
            valueStr += LineMark.ToString() + ",";
            valueStr += "";
            return valueStr;
        }
        public string CsvHeader()
        {
            string header = "";
            header = "名称,信息,使能,模拟,基元名称,类型,申位地址,伸位使能,原位地址,原位使能,伸出地址,伸出使能,缩回地址,缩回使能,伸延时(ms),缩延时(ms),吹气延时(ms),编号";
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
            CyldType = Enum.TryParse<EleCyldType>(valuses[5], out EleCyldType cyType) ? cyType : EleCyldType.Cylinder;
            StretchDiAddress = double.TryParse(valuses[6], out double di1adr) ? di1adr : 0.00;
            StretchDiEnable = bool.TryParse(valuses[7], out bool di1En) ? di1En : false;
            RestractDiAddress = double.TryParse(valuses[8], out double di2adr) ? di2adr : 0.00;
            RestractDiEnable = bool.TryParse(valuses[9], out bool di2En) ? di2En : false;
            StretchDoAddress = double.TryParse(valuses[10], out double do1adr) ? do1adr : 0.00;
            StretchDoEnable = bool.TryParse(valuses[11], out bool do1En) ? do1En : false;
            RestractDoAddress = double.TryParse(valuses[12], out double do2adr) ? do2adr : 0.00;
            RestractDoEnable = bool.TryParse(valuses[13], out bool do2En) ? do2En : false;
            StretchTimeOut = int.TryParse(valuses[14], out int sTim) ? sTim : 500;
            RestractTimeOut = int.TryParse(valuses[15], out int rTim) ? rTim : 500;
            BlowTime = int.TryParse(valuses[16], out int blowTim) ? blowTim : 200;
            LineMark = valuses[17];
        }
    }
}