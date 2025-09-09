using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;

namespace Lead.CPrim.TaskCommon.TaskEdit
{
	public class IpcClientNew
	{
		public void SendScriptMessage(Dictionary<string, string> scriptInfoDic)
		{
			try
			{
				ScriptMessage currentScriptMessage = new ScriptMessage();
				currentScriptMessage.SendMessage(scriptInfoDic);
			}
			catch (Exception)
			{
			}
		}

		public void StartIpcClient()
		{
			IpcChannel channel = new IpcChannel();
			ChannelServices.RegisterChannel(channel, true);
			RemotingConfiguration.RegisterWellKnownClientType(typeof(ScriptMessage), "ipc://ServerChannel/ScriptMessage");
		}
	}
}
