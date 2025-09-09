using System.Collections.Generic;

namespace Lead.CPrim.PrimLEIS_E
{
    public class LESIDataConfig
    {
        public int Index { set; get; }
        public double X_Pos { set; get; }
        public double Y_Pos { set; get; }
        public double Z_Pos { set; get; }
        public string Annotation { set; get; }
    }

    public class LESIDataConfigs
    {
        public List<LESIDataConfig> ListDataConfig { set; get; }
    }
}