using System;

namespace Lead.CPrim.LogHelper
{
	public class LogEventArgs : EventArgs
	{
		public LogMessageItem LogMessage { get; set; }
	}
}
