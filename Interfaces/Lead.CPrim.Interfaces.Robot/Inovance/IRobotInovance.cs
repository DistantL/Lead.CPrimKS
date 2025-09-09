using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.Interfaces.Robot
{
	public interface IRobotInovance
	{
		int RobotId { get; set; }
		/// <summary>
		/// 当前程序运行状态
		/// </summary>
		PrgState ProgramState { get; }

		/// <summary>
		/// 启动程序
		/// </summary>
		/// <param name="vel">速度1~100</param>
		/// <returns>0-启动成功</returns>
		int PrgStart(int vel);

		/// <summary>
		/// 暂停当前程序
		/// </summary>
		/// <returns>0-暂停成功</returns>
		int PrgPause();

		/// <summary>
		/// 继续运行当前程序
		/// </summary>
		/// <returns>0-继续运行成功</returns>
		int PrgContinue();

		/// <summary>
		/// 停止当前程序
		/// </summary>
		/// <returns>0-停止成功</returns>
		int PrgStop();

		/// <summary>
		/// 获取当前程序运行状态
		/// </summary>
		/// <returns></returns>
		PrgState GetPrgState();

		/// <summary>
		/// 获取机械手当前运动状态
		/// </summary>
		/// <returns>小于0，获取失败，0-停止/运动完成，1-运动中，2-运动中断</returns>
		int GetMotionState();

		/// <summary>
		/// 获取机械手系统报警
		/// </summary>
		/// <param name="sysAlarm">报警信息</param>
		/// <returns>-1-查询失败，0-查询成功，1-有报警,2-急停被按下</returns>
		int GetSysAlarm(out string sysAlarm);

		/// <summary>
		/// 清报警
		/// </summary>
		/// <returns>0-清报警成功</returns>
		int ResetErr();

		/// <summary>
		/// 获取机械手当前世界坐标
		/// </summary>
		/// <returns></returns>
		RobotPos GetActualPos();

        /// <summary>
		/// 获取机械手当前世界坐标
		/// </summary>
		/// <param name="toolNum">工具号</param>
		/// <param name="wobjNum">工件号</param>
		/// <param name="loadNum">负载号</param>
		/// <returns></returns>
        RobotPos GetActualPos(int toolNum, int wobjNum, int loadNum);

        /// <summary>
        /// 写B变量
        /// </summary>
        /// <param name="address">地址0~255</param>
        /// <param name="val">0~255</param>
        /// <returns>0-写入成功</returns>
        int WriteBVar(int address, int val);

		/// <summary>
		/// 读B变量
		/// </summary>
		/// <param name="address">地址0~255</param>
		/// <param name="val"></param>
		/// <returns>0-读成功</returns>
		int ReadBVar(int address, out int val);

		/// <summary>
		/// 写R变量
		/// </summary>
		/// <param name="address">地址0~255</param>
		/// <param name="val">-65535~65535</param>
		/// <returns>0-写入成功</returns>
		int WriteRVar(int address, int val);

		/// <summary>
		/// 读R变量
		/// </summary>
		/// <param name="address">地址0~255</param>
		/// <param name="val"></param>
		/// <returns>0-读成功</returns>
		int ReadRVar(int address, out int val);

		/// <summary>
		/// 写D变量
		/// </summary>
		/// <param name="address">地址0~255</param>
		/// <param name="val">-9999999.999~9999999.999</param>
		/// <returns>0-写入成功</returns>
		int WriteDVar(int address, double val);

		/// <summary>
		/// 读D变量
		/// </summary>
		/// <param name="address">地址0~255</param>
		/// <param name="val"></param>
		/// <returns>0-读成功</returns>
		int ReadDVar(int address, out double val);

		int SetVel(int vel);
	}
}
