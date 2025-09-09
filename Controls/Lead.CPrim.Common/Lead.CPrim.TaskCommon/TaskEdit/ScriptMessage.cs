using System;
using System.Collections.Generic;

namespace Lead.CPrim.TaskCommon.TaskEdit
{
	public delegate void SendMessageHandler(Dictionary<string, string> messge);

	public class ScriptMessage : MarshalByRefObject
	{
		public static event SendMessageHandler SendMessageEvent;

		public void SendMessage(Dictionary<string, string> scriptMessage)
		{
			SendMessageEvent?.Invoke(scriptMessage);
		}
	}

	internal class Swap : MarshalByRefObject
	{
		public event SendMessageHandler SwapSubscribeAtClient;

		public void TriggerAtServerSwapEvent(Dictionary<string, string> scriptMessage)
		{
			this.SwapSubscribeAtClient?.Invoke(scriptMessage);
		}
	}
}
