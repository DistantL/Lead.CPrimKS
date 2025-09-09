using System.Collections.Generic;

namespace Lead.CPrim.EleAxisLine
{
    public class AxisDataConfig
    {
        public double Acceleration { set; get; }
        public double AccTime { set; get; }
        public double Deceleration { set; get; }
        public double DecTime { set; get; }
        public int Index { set; get; }
        public double MinVelocity { set; get; }
        public string Name { set; get; }
        public double Position { set; get; }
        public double Velocity { set; get; }
    }

    public class AxisDataConfigs
    {
        public List<AxisDataConfig> ListAxisDataConfigs { set; get; }
    }
}