namespace Lead.CPrim.Interfaces.Robot
{
	public enum PrgState
    {
        停止_运动完成 = 0,
        运动中,
        运动中断,
        未知状态,
	}

	public class RobotPos
	{
		public double X { get; set; }
		public double Y { get; set; }
		public double Z { get; set; }
		public double A { get; set; }
		public double B { get; set; }
		public double C { get; set; }
	}

	public interface IRobotMitsubishi
	{
		int RobotId { get; set; }
		/// <summary>使能</summary>
		/// <param name="bl">true：上使能；false：下使能</param>
		/// <returns>0：成功</returns>
		int EnableRobot(bool bl);
		/// <summary>启动程序</summary>
		/// <param name="vel">速度1~100</param>
		/// <returns>0：成功</returns>
		int PrgStart(int vel);
		/// <summary>暂停当前程序</summary>
		/// <returns>0：成功</returns>
		int PrgPause();
		/// <summary>继续运行当前程序</summary>
		/// <returns>0：成功</returns>
		int PrgContinue();
		/// <summary>停止当前程序</summary>
		/// <returns>0：成功</returns>
		int PrgStop();
		/// <summary>获取当前程序运行状态</summary>
		/// <returns>Running：运行中；</returns>
		PrgState GetPrgState();
		/// <summary>获取机械手系统报警</summary>
		/// <param name="sysAlarm">报警信息</param>
		/// <returns>-1：有报警；0：查询成功</returns>
		int GetSysAlarm(out string sysAlarm);
		/// <summary>清报警</summary>
		/// <returns>0：成功</returns>
		bool ResetErr();
		/// <summary>获取机械手当前世界坐标</summary>
		/// <returns></returns>
		RobotPos GetActualPos();
		/// <summary>写FLOAT变量 变量统一定义在VR程序中</summary>
		/// <param name="address"></param>
		/// <param name="val">值</param>
		/// <returns>0：成功</returns>
		int WriteFloatVar(int address, double val);
		/// <summary>读取float数据</summary>
		/// <param name="slot">变量所在槽号</param>
		/// <param name="address">变量名称</param>
		/// <param name="val">值</param>
		/// <returns>0：成功</returns>
		int ReadFloatVar(int slot,int address, out double val);
		/// <summary>写int变量 变量统一定义在VR程序中</summary>
		/// <param name="address"></param>
		/// <param name="val">值</param>
		/// <returns>0：成功</returns>
		int WriteIntVar(int address, int val);
		/// <summary>读取int数据</summary>
		/// <param name="slot">变量所在槽号</param>
		/// <param name="address">变量名称</param>
		/// <param name="val">值</param>
		/// <returns>0：成功</returns>
		int ReadIntVar(int slot,int address, out int val);
	}
}
