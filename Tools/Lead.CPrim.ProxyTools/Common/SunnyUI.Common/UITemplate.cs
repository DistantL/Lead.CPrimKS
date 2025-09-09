using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace Sunny.UI
{
	public class UITemplate
	{
		private string Content { get; set; }

		public UITemplate(string content)
		{
			Content = content;
		}

		public UITemplate Set(string key, string value)
		{
			Content = Content.Replace("{{" + key + "}}", value);
			return this;
		}

		public string Render()
		{
			MatchCollection matchCollection = Regex.Matches(Content, "\\{\\{.+?\\}\\}");
			IEnumerator enumerator = matchCollection.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					Match match = (Match)enumerator.Current;
					throw new ArgumentException("模版变量" + match.Value + "未被使用");
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return Content;
		}
	}
}
