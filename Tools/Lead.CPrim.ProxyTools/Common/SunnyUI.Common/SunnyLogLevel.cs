namespace Sunny.UI
{
	public enum SunnyLogLevel
	{
		[DisplayText("ALL")]
		ALL = int.MinValue,
		[DisplayText("DEBUG")]
		DEBUG = 30000,
		[DisplayText("INFO")]
		INFO = 40000,
		[DisplayText("WARN")]
		WARN = 60000,
		[DisplayText("ERROR")]
		ERROR = 70000,
		[DisplayText("FATAL")]
		FATAL = 110000,
		[DisplayText("OFF")]
		OFF = int.MaxValue
	}
}
