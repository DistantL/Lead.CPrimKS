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
using Lead.CPrim.Interfaces.StateMachine;
using Lead.CPrim.SoftwareConfig;
using Lead.CPrim.StationCommon;
using Lead.CPrim.LogHelper;
using Lead.CPrim.XmlHelper;
using Lead.CPrim.ProductInfoHelper;
using Lead.CPrim.TaskHelper;
using Lead.CPrim.MachineHelper;
using Lead.CPrim.DynamicParam;
using Lead.CPrim.CommonParam;
using Lead.CPrim.PrimCommon;
using Lead.CPrim.EleCommon;
using Lead.CPrim.ShowCommon;

public class RunState
{
	ITask _task;
	StationConfig _station;
	
	string _currentProduct;
	
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
        _station = StationManager.Instance.Stations[StationManager.Instance.CurrentStationName];
        MembersInit();
		_currentProduct = SwManager.Instance.CurrentProduct;
		//SPEED = CommonParam.Instance.Speed;	//全局速度赋值
        MessageBox.Show("RunState:Init");
        return iRet;
	}
	
	private void MembersInit()
    {
		
    }
	
	public int ResetLoop()
    {
        int iRet = 0;
        
		return iRet;
    }

    public int RunLoop()
    {
    	switch (_task.CurStep) 
    	{
    		case 0:
    			
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

