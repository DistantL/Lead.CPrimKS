namespace Sunny.UI
{
	public static class Html
	{
		public static string DealApiParam(string param, bool dealPercentSign = false)
		{
			if (dealPercentSign)
			{
				param = param.Replace("%", "%25");
			}
			param = param.Replace(" ", "%20");
			param = param.Replace("+", "%2B");
			param = param.Replace("#", "%23");
			param = param.Replace("&", "%26");
			param = param.Replace("/", "%2F");
			param = param.Replace("?", "%3F");
			param = param.Replace("=", "%3D");
			param = param.Replace("@", "%40");
			param = param.Replace("(", "%28");
			param = param.Replace(")", "%29");
			param = param.Replace(",", "%2C");
			param = param.Replace(":", "%3A");
			param = param.Replace(";", "%3B");
			param = param.Replace("<", "%3C");
			param = param.Replace(">", "%3E");
			param = param.Replace("\\", "%5C");
			param = param.Replace("|", "%7C");
			param = param.Replace("\"", "%22");
			return param;
		}
	}
}
