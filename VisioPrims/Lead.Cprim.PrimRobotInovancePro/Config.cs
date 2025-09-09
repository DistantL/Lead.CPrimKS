using Lead.CPrim.Interfaces;
using System;
using System.ComponentModel;

namespace Lead.CPrim.PrimRobotInovancePro
{
    public class Config
    {
        public string RobotIp { set; get; } = "192.168.250.20";
        public int Port { set; get; } = 2222;
        public int RobotId { set; get; } = 0;
        public string Password { set; get; } = "000000";
        public string Path { set; get; }
        public bool PrimSimulator { set; get; }
        public bool LogEnable { set; get; }
        public RobotVer RobotVer { get; set; }



        #region Override IPrim
        public Guid Id { set; get; }
        public string Name { set; get; }
        public bool PrimEnable { set; get; }
        public string PrimTypeName { set; get; }
        public int CurrentImageIndex { get; set; }
        #endregion
    }

    /// <summary>
    /// 机器人版本
    /// </summary>
    public enum RobotVer
    {
        S0321R20,
        V4R24,
    }
}
