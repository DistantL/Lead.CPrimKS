using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Security.Principal;
using System.Web.Script.Serialization;

namespace Lead.CPrim.TaskCommon.TaskEdit
{
    public class PipeClient
    {
        #region Field
        private readonly NamedPipeClientStream _clientPipe;
        private StreamWriter _sw;
        #endregion



        #region Ctor
        public PipeClient()
        {
            _clientPipe = new NamedPipeClientStream(".", "LeadPipe", PipeDirection.InOut, PipeOptions.Asynchronous, TokenImpersonationLevel.None);
        }
        #endregion



        //*****************************************************************************
        #region Method_ExternalUsing
        /// <summary>向管道发送消息</summary>
        /// <param name="scriptInfoDic"></param>
        public void SendMessage(Dictionary<string, string> scriptInfoDic)
        {
            if (_sw != null)
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string jsonStr = jss.Serialize(scriptInfoDic);
                _sw.WriteLine(jsonStr);
            }
        }
        /// <summary>启动管道</summary>
        public void StartPipeClient()
        {
            if (_clientPipe != null)
            {
                _clientPipe.Connect(10*1000);
                StreamWriter streamWriter = new StreamWriter(_clientPipe);
                streamWriter.AutoFlush = true;
                _sw = streamWriter;
            }
        }
        #endregion
    }
}
