using System.Collections.Generic;
using System.Linq;
using Lead.CPrim.Interfaces.StateMachine;
using Lead.CPrim.MachineHelper;

namespace Lead.CPrim.TaskHelper
{
    public class AutoManualStationSM : AutoManualSM
    {
    	public static AutoManualStationSM Instance = new AutoManualStationSM();

    	private AutoManualStationSM()
    	{
    	}

    	public override bool CheckSwitchButton()
    	{
    		Dictionary<string, IStateMachine>.ValueCollection values = SysStationSM.Instance.taskSms.Values;
    		if (values.All((IStateMachine p) => ((TaskStationMachine)(object)p).CheckManualSignal() == 0))
    		{
    			return base.CheckSwitchButton();
    		}
    		if (values.All((IStateMachine p) => ((TaskStationMachine)(object)p).CheckManualSignal() == 1))
    		{
    			return true;
    		}
    		if (values.Any((IStateMachine p) => ((TaskStationMachine)(object)p).CheckManualSignal() == 2))
    		{
    			return false;
    		}
    		return base.CheckSwitchButton();
    	}
    }
}
