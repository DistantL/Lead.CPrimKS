using System.Collections.Generic;

namespace Lead.CPrim.PrimLEIS
{
    public class LESIDateConfig
    {
        public int Index { set; get; }
        public double X_Pos { set; get; }
        public double Y_Pos { set; get; }
        public double Z_Pos { set; get; }
        public string Annotation { set; get; }
    }

    public class LESIDateConfigs
    {
        public List<LESIDateConfig> ListDataConfig { set; get; }
    }
}