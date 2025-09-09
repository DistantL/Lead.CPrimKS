using System;
using System.Threading;
using System.Messaging;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Dev;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces.Communicate;
using Lead.CPrim.Interfaces.AShow;
using Lead.CPrim.Interfaces.StateMachine;
using Lead.CPrim.SoftwareConfig;
using Lead.CPrim.StationCommon;
using Lead.CPrim.LogHelper;
using Lead.CPrim.CsvHelper;
using Lead.CPrim.XmlHelper;
using Lead.CPrim.ProductInfoHelper;
using Lead.CPrim.TaskHelper;
using Lead.CPrim.MachineHelper;
using Lead.CPrim.DynamicParam;
using Lead.CPrim.CommonParam;
using Lead.CPrim.PrimCommon;
using Lead.CPrim.EleCommon;
using Lead.CPrim.ShowCommon;
using Lead.CPrim.MongodbHelper;
using Lead.CPrim.MsgForm;

public class RunState
{
	ITask _task;
	StationConfig _station;
	string _currentProduct;
	
	IMotionCard _card;
	IEleCartesian _cart1;
	IEleDI _di1;
	IEleDO _do1;
	IEleCyldLine _cyld1;
	IEleAxisLine _line1;
	
	ProductInfo _pro;
	
	ushort SPEED = 50;
	
	public int Exec(ITask task)
	{
		int iRet = 0;
		MessageBox.Show("RunState:Exec");
		
		return iRet;
	}
	 
	public int Init(ITask task)
	{
		int iRet = 0;
        _task = task;
        _station = StationManager.Instance.Stations["Station1"];
        MembersInit();
		_currentProduct = SwManager.Instance.CurrentProduct;
		//SPEED = CommonParam.Instance.Speed;	//全局速度赋值
		//MessageFrm.Show("测试信息", Color.Red, 5000);
		//_task.Push("测试推送信息", false);
		//_task.Push("测试推送状态", true);
        MessageBox.Show("RunState:Init");
        return iRet;
	}
	
	private void MembersInit()
    {
		//基元及元件的定位
		//_card = (IMotionCard)PrimsManager.Instance.GetPrimByName("PrimADlink_E0");
		//_cart1 = (IEleCartesian)ElesManager.Instance.GetEleByName("Cartesian01");
		//_di1 = (IEleDI)ElesManager.Instance.GetEleByName("Di01");
		//_do1 = (IEleDO)ElesManager.Instance.GetEleByName("Do01");
		//_cyld1 = (IEleCyldLine)ElesManager.Instance.GetEleByName("Cyld01");
		//_line1 = (IEleAxisLine)ElesManager.Instance.GetEleByName("Line01");
		
		//显示基元
		//_aShow = (IAShowCommon)ShowManager.Instance.GetShowByName("AQCI0");
		
		//产品信息初始化
		//_pro = new ProductInfo();
		//_pro.CreateTime = DateTime.Now;
		
    }
	
	public int ResetLoop()
    {
        int iRet = 0;
        
        /*********轴组相关*********/
        /*
        _cart1.GroupSetEnable(true, _task);	//轴组使能
        _cart1.GroupHome(60, _task);	//轴组回原点
        _cart1.GroupMoveAbs("P01", SPEED, 50, false, true, _task);	//轴组以同步方式移动至P01，超时时间50s
        _cart1.GroupMoveAbs(DynamicParam.Instanse.P01, SPEED, 50, false, true, _task); 	//轴组以同步方式移动至P01，P01存储于换型参数中
        _cart1.GroupStop();	//轴组停止
		*/
		
		/*********气缸相关********/
		/*
		_cyld1.CyldStretch(true, false, (StationTask)_task, EleAlarmLevel.Warn);	//气缸伸出动作，阻塞型，如伸出失败，则状态机报警
		_cyld1.CyldRetract(true, true);	//气缸缩回动作，非阻塞型
		_cyld1.CyldStretch(false);	//气缸伸出动作，不判断伸位信号
		var cyldRet = _cyld1.CheckCylState();	//0-原位，1-伸位，2-未知
		var cyldStretchRet = _cyld1.ReadStretchDI();	//1-伸位信号有
		*/
		
		/********输入输出相关*******/
		/*
		if (_di1.Read())
		{
			//输入信号有
		}
		_do1.Write(true);	//输出信号置位
		_do1.Write(false);	//输出信号复归
		*/
		
		/******单轴相关*********/
		/*
		_line1.MC_Power(true);	//轴使能
		_line1.MC_Home(0, 50);	//轴以模式0（参考板卡说明）回零，超时时间50s
		_line1.MC_MoveJog(true, 200);	//轴以200的速度正方向Jog移动
		_line1.MC_MoveAbsolute(20.0);	//轴移动至20.0的位置
		_line1.MC_ChangeVel(100);	//轴移动过程中更改速度为100
		*/
		return iRet;
    }

    public int RunLoop()
    {
    	switch (_task.CurStep) 
    	{
    		case 0:
    			Thread.Sleep(500);
    			//动态全局参数
    			//var aa = CommonParam.Instance.测试;
    			
    			_task.SetStep(1);
    			break;
    		case 1:
    			Thread.Sleep(1000);
    			//换型参数
    			//var bb = DynamicParam.Instanse.测试换型;
    			_task.SetStep(2, "Test");
    			break;
    		case 2:
    			Thread.Sleep(2000);
    			//变量写入
    			//_station.SetDataInfoVal<bool>("test", true);
    			//变量读取
    			//var c = Convert.ToDouble(_station.GetDataInfoVal("C1"));
    			
    			//刷新实时数据并存储至数据库
    			//_station.AddRtData(newPro, true, _currentProduct);
    			
    			//刷新主界面上的实时变量
    			//_station.UpdateRtVar("CC", true);
    			
    			_task.SetStep(0, "重新开始流程");
    			break;
    		default:
    			break;
    	}
        return 0;
    }
    
    public void StopLoop()
    {
    }
    public void RunToPause()
    {
    }
    public void PauseToRun()
    {
    }
    public void FirstRun()
    {

    }
    public void ResetDone()
    {
    	_task.SetStep(0);
        _task.Log("Reset Done", LogLevel.Info, 000);
    }

}

