using System;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleLight
{
    public class EleLightConfig
    {
        public EleLightConfig()
        {
            DevName = "";
            Id = Guid.NewGuid();
            Info = "";
            IsSimulateMode = false;
            Name = "";
            EleRunStat = EleRunState.Other;
            LightType = EleLightType.Tricolour_Light;
            EleTypeName = "Tricolour_Light";
            Enable = false;
            LogEnable = true;
            LogDisplay = false;
            RedAddress = 0;
            GreenAddress = 0;
            YellowAddress = 0;
            BuzzAddress = 0;
            RedEnable = false;
            GreenEnable = false;
            YellowEnable = false;
            BuzzEnable = false;
        }

        public double BuzzAddress { set; get; }
        public bool BuzzEnable { set; get; }
        public string DevName { set; get; }
        public EleRunState EleRunStat { set; get; }
        public string EleTypeName { set; get; }
        public bool Enable { set; get; }
        public double GreenAddress { set; get; }
        public bool GreenEnable { set; get; }
        public Guid Id { set; get; }
        public string Info { set; get; }
        public bool IsSimulateMode { set; get; }

        //Ele Cylinder Line Interface
        public EleLightType LightType { set; get; }

        public bool LogDisplay { set; get; }
        public bool LogEnable { set; get; }
        public string Name { set; get; }
        public double RedAddress { set; get; }
        public bool RedEnable { set; get; }
        public double YellowAddress { set; get; }
        public bool YellowEnable { set; get; }
    }
}