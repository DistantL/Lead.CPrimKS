using System;
using System.Threading;

namespace Lead.CPrim.LogHelper
{
	public class LogMessageItem
	{
		private static long IdNumber;

		public LogMessageDegree Degree { get; set; } = LogMessageDegree.DEBUG;


		public long Id { get; private set; }

		public string KeyWord { get; set; }

		public string Text { get; set; }

		public int ThreadId { get; set; }

		public DateTime Time { get; set; }

		public LogMessageItem()
		{
			Id = Interlocked.Increment(ref IdNumber);
		}

		public override string ToString()
		{
			if (string.IsNullOrEmpty(KeyWord))
			{
				return string.Format("[{0}] {1} Thread [{2}] {3}", Degree, Time.ToString("yyyy-MM-dd HH:mm:ss.fff"), ThreadId.ToString("D2"), Text);
			}
			return string.Format("[{0}] {1} Thread [{2}] {3} : {4}", Degree, Time.ToString("yyyy-MM-dd HH:mm:ss.fff"), ThreadId.ToString("D2"), KeyWord, Text);
		}

		public string ToStringWithoutKeyword()
		{
			return string.Format("[{0}] {1} Thread [{2}] {3}", Degree, Time.ToString("yyyy-MM-dd HH:mm:ss.fff"), ThreadId.ToString("D2"), Text);
		}
	}
}
