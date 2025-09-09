using System;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;

namespace Lead.CPrim.EleAxisLine
{
    public class EleAxisLineConfig
    {
        public EleAxisLineConfig()
        {
            Name = "";
            Info = "";
            Id = Guid.NewGuid();
            EleTypeName = "AxisLine";
            Enable = false;
            IsSimulateMode = false;
            DriveType = AxisType.Other;
            ControlType = ControlType.Other;
            EncoderType = FeedBackType.Other;
            DevName = "";
            CardNum = -1;
            AxisNum = -1;
            HomeMode = -1;
            SwLimitEnable = false;
            SwPot = -1;
            SwNot = -1;
            LimVelP = -1;
            LimVelN = -1;
            AxisLead = -1;
            PlsPerRoll = -1;
            HomeVelocity = -1;
            AccDecType = AccDecType.Other;
            StopMode = StopMode.Other;
            ErrChkRange = -1;
            JogVelocity = -1;
            StandByIndex = -1;
            DataTablePath = "";
            DefaultParams = new DefaultParams();
            LogEnable = true;
            LogDisplay = false;
            CheckLimitEnable = true;
        }

        public string EleTypeName { set; get; }

        public bool Enable { set; get; }

        public Guid Id { set; get; }

        public string Info { set; get; }

        public bool IsSimulateMode { set; get; }

        //Ele Interface
        public string Name { set; get; }

        #region Other

        public string DataTablePath { set; get; }

        #endregion Other

        //Ele Cylinder Line Interface

        #region Config

        public AccDecType AccDecType { set; get; }
        public double AxisLead { set; get; }
        public int AxisNum { set; get; }
        public int CardNum { set; get; }
        public bool CheckLimitEnable { set; get; }
        public ControlType ControlType { set; get; }
        public DefaultParams DefaultParams { set; get; }
        public string DevName { set; get; }
        public AxisType DriveType { set; get; }
        public FeedBackType EncoderType { set; get; }
        public int ErrChkRange { set; get; }
        public int HomeMode { set; get; }
        public double HomeVelocity { set; get; }
        public double JogDistance { set; get; }
        public double JogVelocity { set; get; }
        public double LimVelN { set; get; }
        public double LimVelP { set; get; }
        public bool LogDisplay { set; get; }
        public bool LogEnable { set; get; }
        public double PlsPerRoll { set; get; }
        public int StandByIndex { set; get; }
        public StopMode StopMode { set; get; }
        public bool SwLimitEnable { set; get; }
        public double SwNot { set; get; }
        public double SwPot { set; get; }

        #endregion Config
    }
}