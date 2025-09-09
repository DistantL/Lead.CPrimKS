using Lead.CPrim.Interfaces.StateMachine;
using Lead.CPrim.MachineHelper;

namespace Lead.CPrim.TaskHelper
{
    public class SysStationSM : SystemStateMachine
    {
    	public static SysStationSM Instance = new SysStationSM();

    	public override void Initialize(object obj)
    	{
            taskSms = TaskSmManger.Instance.TaskSMs;
            AutoSm = (IStateMachine)(object)AutoManualStationSM.Instance;
            base.Initialize(obj);
    	}
    }
}
