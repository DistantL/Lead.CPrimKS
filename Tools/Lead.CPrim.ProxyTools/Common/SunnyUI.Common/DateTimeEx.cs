using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sunny.UI
{
    public static class DateTimeEx
	{
		public const string DateLink = "-";

		public const string DateLinkEx = "/";

		public const string TimeLink = ":";

		public const string DateTimeFormatEx = "yyyy-MM-dd HH:mm:ss.fff";

		public const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

		public const string DateFormat = "yyyy-MM-dd";

		public const string TimeFormat = "HH:mm:ss";

		public static DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		private static string TrimLink(string format)
		{
			return format.Replace("-", "").Replace(":", "").Replace(".", "")
				.Replace(" ", "")
				.Trim();
		}

		public static string String(this DateTime dt)
		{
			return dt.ToString("yyyy-MM-dd HH:mm:ss");
		}

		public static string DateTimeString(this DateTime dt, bool withLink = true)
		{
			return dt.ToString(withLink ? "yyyy-MM-dd HH:mm:ss" : TrimLink("yyyy-MM-dd HH:mm:ss"));
		}

		public static string DateTimeExString(this DateTime dt, bool withLink = true)
		{
			return dt.ToString(withLink ? "yyyy-MM-dd HH:mm:ss.fff" : TrimLink("yyyy-MM-dd HH:mm:ss.fff"));
		}

		public static string DateString(this DateTime dt, bool withLink = true)
		{
			return dt.ToString(withLink ? "yyyy-MM-dd" : TrimLink("yyyy-MM-dd"));
		}

		public static string TimeString(this DateTime dt, bool withLink = true)
		{
			return dt.ToString(withLink ? "HH:mm:ss" : TrimLink("HH:mm:ss"));
		}

		public static string YearMonthString(this DateTime dt, bool withLink = true)
		{
			return dt.ToString(withLink ? "yyyy-MM" : "yyyyMM");
		}

		public static string YearString(this DateTime dt)
		{
			return dt.ToString("yyyy");
		}

		public static int TenMinuteIndex(this DateTime dt)
		{
			return dt.Hour * 6 + dt.Minute / 10;
		}

		public static List<DateTime> MonthDays(this DateTime dt)
		{
			List<DateTime> list = new List<DateTime>();
			int num = dt.DaysInMonth();
			for (int i = 1; i <= num; i++)
			{
				list.Add(new DateTime(dt.Year, dt.Month, i));
			}
			return list;
		}

		public static List<string> MonthDayStrings(this DateTime dt)
		{
			List<DateTime> list = dt.MonthDays();
			List<string> list2 = new List<string>();
			foreach (DateTime item in list)
			{
				list2.Add(item.ToString("yyyy-MM-dd"));
			}
			return list2;
		}

		public static double ToDouble(this DateTime datetime)
		{
			return datetime.Subtract(Jan1st1970).TotalDays;
		}

		public static DateTime ToDateTime(this double iDays)
		{
			return TimeZoneInfo.ConvertTime(Jan1st1970.AddDays(iDays), TimeZoneInfo.Local);
		}

		public static int DaysInMonth(this DateTime date)
		{
			return DateTime.DaysInMonth(date.Year, date.Month);
		}

		public static DateTime FirstDayOfMonth(this DateTime date)
		{
			return new DateTime(date.Year, date.Month, 1);
		}

		public static DateTime FirstDayOfMonth(this DateTime date, DayOfWeek dayOfWeek)
		{
			DateTime result = date.FirstDayOfMonth();
			while (result.DayOfWeek != dayOfWeek)
			{
				result = result.AddDays(1.0);
			}
			return result;
		}

		public static DateTime LastDayOfMonth(this DateTime date)
		{
			return new DateTime(date.Year, date.Month, date.DaysInMonth());
		}

		public static DateTime LastDayOfMonth(this DateTime date, DayOfWeek dayOfWeek)
		{
			DateTime result = date.LastDayOfMonth();
			while (result.DayOfWeek != dayOfWeek)
			{
				result = result.AddDays(-1.0);
			}
			return result;
		}

		public static bool IsToday(this DateTime dt)
		{
			return dt.Date == DateTime.Today.Date;
		}

		public static DateTime SetTime(this DateTime date, int hours, int minutes, int seconds)
		{
			return date.SetTime(new TimeSpan(hours, minutes, seconds));
		}

		public static DateTime SetTime(this DateTime date, int hours, int minutes, int seconds, int milliseconds)
		{
			return date.SetTime(new TimeSpan(0, hours, minutes, seconds, milliseconds));
		}

		public static DateTime ZeroSecond(this DateTime datetime)
		{
			return datetime.SetTime(new TimeSpan(0, datetime.Hour, datetime.Minute, 0, 0));
		}

		public static DateTime ZeroMillisecond(this DateTime datetime)
		{
			return datetime.SetTime(new TimeSpan(0, datetime.Hour, datetime.Minute, datetime.Second, 0));
		}

		public static DateTime SetTime(this DateTime date, TimeSpan time)
		{
			return date.Date.Add(time);
		}

		public static bool IsDateEqual(this DateTime date, DateTime dateToCompare)
		{
			return date.Date == dateToCompare.Date;
		}

		public static bool IsTimeEqual(this DateTime time, DateTime timeToCompare)
		{
			return time.TimeOfDay == timeToCompare.TimeOfDay;
		}

		public static long SecondsSince1970(this DateTime datetime)
		{
			return (long)datetime.ToUniversalTime().Subtract(Jan1st1970).TotalSeconds;
		}

		public static bool IsBefore(this DateTime source, DateTime other)
		{
			return source.CompareTo(other) < 0;
		}

		public static bool IsAfter(this DateTime source, DateTime other)
		{
			return source.CompareTo(other) > 0;
		}

		public static DateTime Tomorrow(this DateTime date)
		{
			return date.AddDays(1.0);
		}

		public static DateTime Yesterday(this DateTime date)
		{
			return date.AddDays(-1.0);
		}

		public static DateTime EndOfDay(this DateTime date)
		{
			return date.SetTime(23, 59, 59, 999);
		}

		public static DateTime EndOfMonth(this DateTime date)
		{
			return new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1.0).EndOfDay();
		}

		public static DateTime BeginOfMonth(this DateTime date)
		{
			return new DateTime(date.Year, date.Month, 1).Midnight();
		}

		public static DateTime Noon(this DateTime time)
		{
			return time.SetTime(12, 0, 0);
		}

		public static DateTime Midnight(this DateTime time)
		{
			return time.SetTime(0, 0, 0, 0);
		}

		public static DateTime January(this int year, int day)
		{
			return new DateTime(year, 1, day);
		}

		public static DateTime February(this int year, int day)
		{
			return new DateTime(year, 2, day);
		}

		public static DateTime March(this int year, int day)
		{
			return new DateTime(year, 3, day);
		}

		public static DateTime April(this int year, int day)
		{
			return new DateTime(year, 4, day);
		}

		public static DateTime May(this int year, int day)
		{
			return new DateTime(year, 5, day);
		}

		public static DateTime June(this int year, int day)
		{
			return new DateTime(year, 6, day);
		}

		public static DateTime July(this int year, int day)
		{
			return new DateTime(year, 7, day);
		}

		public static DateTime August(this int year, int day)
		{
			return new DateTime(year, 8, day);
		}

		public static DateTime September(this int year, int day)
		{
			return new DateTime(year, 9, day);
		}

		public static DateTime October(this int year, int day)
		{
			return new DateTime(year, 10, day);
		}

		public static DateTime November(this int year, int day)
		{
			return new DateTime(year, 11, day);
		}

		public static DateTime December(this int year, int day)
		{
			return new DateTime(year, 12, day);
		}

		public static List<DateTime> AllDaysTo(this DateTime thisDateTime, DateTime toDateTime)
		{
			List<DateTime> list = new List<DateTime>();
			DateTime time = (toDateTime.IsAfter(thisDateTime) ? thisDateTime : toDateTime);
			DateTime date = (toDateTime.IsAfter(thisDateTime) ? toDateTime : thisDateTime);
			time = time.Midnight();
			date = date.EndOfDay();
			while (time < date)
			{
				list.Add(time);
				time = time.AddDays(1.0);
			}
			return list;
		}

		public static List<DateTime> AllTenMinutes(this DateTime date)
		{
			List<DateTime> list = new List<DateTime>();
			date = date.Midnight();
			for (int i = 0; i < 144; i++)
			{
				list.Add(date);
				date = date.AddMinutes(10.0);
			}
			return list;
		}

		public static DateTime TrimSeconds(this DateTime dateTime)
		{
			return dateTime.SetTime(dateTime.Hour, dateTime.Minute, 0, 0);
		}

		public static DateTime TrimMilliseconds(this DateTime dateTime)
		{
			return dateTime.SetTime(dateTime.Hour, dateTime.Minute, dateTime.Second, 0);
		}

		public static DateTime TicksToDateTime(this long timeTicks)
		{
			return DateTime.MinValue.AddTicks(timeTicks);
		}

		public static bool IsMonthBeginOneHour(this DateTime value)
		{
			return value.Day == 1 && value.Hour == 0;
		}

		public static bool IsMultiSix(this DateTime value)
		{
			return value.Minute.Mod(6) == 0;
		}

		public static void SetLocalDate(int year, int month, int day)
		{
			Process process = new Process();
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.Arguments = $"/c date {year}-{month}-{day}";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.CreateNoWindow = true;
			process.Start();
			process.StandardOutput.ReadToEnd();
		}

		public static void SetLocalTime(int hour, int min, int sec)
		{
			Process process = new Process();
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.Arguments = $"/c time {hour}:{min}:{sec}";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.CreateNoWindow = true;
			process.Start();
			process.StandardOutput.ReadToEnd();
		}

		public static void SetLocalDateTime(DateTime time)
		{
			SetLocalDate(time.Year, time.Month, time.Day);
			SetLocalTime(time.Hour, time.Minute, time.Second);
		}
	}
}
