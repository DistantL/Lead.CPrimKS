using System;

namespace Sunny.UI
{
	public struct DateTimeInt64 : IComparable, IEquatable<DateTimeInt64>, IEquatable<long>, IEquatable<DateTime>
	{
		public const long Jan1st1970Ticks = 621355968000000000L;

		public const long Dec31th9999Ticks = 3155378975999990000L;

		public const string DefaultFormatString = "yyyy-MM-dd HH:mm:ss.fff";

		public const double MillisecondsPerDay = 86400000.0;

		public long Value { get; set; }

		public double DoubleValue
		{
			get
			{
				return (double)Value * 1.0 / 86400000.0;
			}
			set
			{
				Value = (long)(value * 86400000.0);
			}
		}

		public bool IsValidDate => Value >= 0 && Value <= 2534023007999990000L;

		public DateTime DateTime
		{
			get
			{
				return TicksToDateTime(Value);
			}
			set
			{
				Value = DateTimeToTicks(value);
			}
		}

		public string DateTimeString => DateTime.DateTimeString();

		public string DateString => DateTime.DateString();

		public string TimeString => DateTime.TimeString();

		public string HourMinuteString => DateTime.ToString("HH:mm");

		public int Year => DateTime.Year;

		public int Month => DateTime.Month;

		public int Day => DateTime.Day;

		public int Hour => DateTime.Hour;

		public int Minute => DateTime.Minute;

		public int Second => DateTime.Second;

		public int Millisecond => DateTime.Millisecond;

		public static long CurrentDateTimeToTicks()
		{
			return (DateTime.UtcNow.Ticks - 621355968000000000L) / 10000;
		}

		public static long DateTimeToTicks(DateTime datetime)
		{
			return (datetime.ToUniversalTime().Ticks - 621355968000000000L) / 10000;
		}

		public static DateTime TicksToDateTime(long ticks)
		{
			return TimeZone.CurrentTimeZone.ToLocalTime(TicksToUTCDateTime(ticks));
		}

		public static DateTime TicksToUTCDateTime(long ticks)
		{
			return new DateTime(ticks * 10000 + 621355968000000000L);
		}

		public DateTimeInt64(long ticks)
		{
			ticks = MakeValidDate(ticks);
			Value = ticks;
		}

		public DateTimeInt64(double doubleTicks)
		{
			doubleTicks = MakeValidDate((long)(doubleTicks * 86400000.0));
			Value = (long)doubleTicks;
		}

		public DateTimeInt64(DateTime dateTime)
		{
			Value = DateTimeToTicks(dateTime);
		}

		public DateTimeInt64(int year, int month, int day)
		{
			Value = DateTimeToTicks(new DateTime(year, month, day));
		}

		public DateTimeInt64(int year, int month, int day, int hour, int minute, int second)
		{
			Value = DateTimeToTicks(new DateTime(year, month, day, hour, minute, second));
		}

		public DateTimeInt64(int year, int month, int day, int hour, int minute, int second, int millisecond)
		{
			Value = DateTimeToTicks(new DateTime(year, month, day, hour, minute, second, millisecond));
		}

		public DateTimeInt64(DateTimeInt64 dtValue)
		{
			Value = dtValue.Value;
		}

		public static bool CheckValidDate(long ticks)
		{
			return ticks >= 0 && ticks <= 2534023007999990000L;
		}

		public static long MakeValidDate(long ticks)
		{
			if (ticks < 0)
			{
				ticks = 0L;
			}
			if (ticks > 2534023007999990000L)
			{
				ticks = 2534023007999990000L;
			}
			return ticks;
		}

		public void AddMilliseconds(double milliseconds)
		{
			Value = DateTimeToTicks(DateTime.AddMilliseconds(milliseconds));
		}

		public void AddSeconds(double seconds)
		{
			Value = DateTimeToTicks(DateTime.AddSeconds(seconds));
		}

		public void AddMinutes(double minutes)
		{
			Value = DateTimeToTicks(DateTime.AddMinutes(minutes));
		}

		public void AddHours(double hours)
		{
			Value = DateTimeToTicks(DateTime.AddHours(hours));
		}

		public void AddDays(double days)
		{
			Value = DateTimeToTicks(DateTime.AddDays(days));
		}

		public void AddMonths(int months)
		{
			Value = DateTimeToTicks(DateTime.AddMonths(months));
		}

		public void AddYears(int years)
		{
			Value = DateTimeToTicks(DateTime.AddYears(years));
		}

		public static long operator -(DateTimeInt64 dtValue1, DateTimeInt64 dtValue2)
		{
			return dtValue1.Value - dtValue2.Value;
		}

		public static long operator +(DateTimeInt64 dtValue1, DateTimeInt64 dtValue2)
		{
			return dtValue1.Value + dtValue2.Value;
		}

		public static DateTimeInt64 operator -(DateTimeInt64 dtValue1, long dtValue2)
		{
			dtValue1.Value -= dtValue2;
			return dtValue1;
		}

		public static DateTimeInt64 operator +(DateTimeInt64 dtValue1, long dtValue2)
		{
			dtValue1.Value += dtValue2;
			return dtValue1;
		}

		public static DateTimeInt64 operator ++(DateTimeInt64 dtValue)
		{
			dtValue.AddDays(1.0);
			return dtValue;
		}

		public static DateTimeInt64 operator --(DateTimeInt64 dtValue)
		{
			dtValue.AddDays(-1.0);
			return dtValue;
		}

		public static implicit operator long(DateTimeInt64 dtValue)
		{
			return dtValue.Value;
		}

		public static implicit operator DateTimeInt64(long ticks)
		{
			return new DateTimeInt64(ticks);
		}

		public static implicit operator DateTimeInt64(DateTime dt)
		{
			return new DateTimeInt64(dt);
		}

		public static implicit operator DateTime(DateTimeInt64 dt)
		{
			return dt.DateTime;
		}

		public static implicit operator double(DateTimeInt64 dtValue)
		{
			return dtValue.DoubleValue;
		}

		public static implicit operator DateTimeInt64(double ticks)
		{
			return new DateTimeInt64(ticks);
		}

		public static bool operator ==(DateTimeInt64 dtValue1, DateTimeInt64 dtValue2)
		{
			return dtValue1.Value == dtValue2.Value;
		}

		public static bool operator !=(DateTimeInt64 dtValue1, DateTimeInt64 dtValue2)
		{
			return dtValue1.Value != dtValue2.Value;
		}

		public static bool operator ==(DateTimeInt64 dtValue, long ticks)
		{
			return dtValue.Value == ticks;
		}

		public static bool operator !=(DateTimeInt64 dtValue, long ticks)
		{
			return dtValue.Value != ticks;
		}

		public static bool operator <(DateTimeInt64 dtValue1, DateTimeInt64 dtValue2)
		{
			return dtValue1.Value < dtValue2.Value;
		}

		public static bool operator >(DateTimeInt64 dtValue1, DateTimeInt64 dtValue2)
		{
			return dtValue1.Value > dtValue2.Value;
		}

		public static bool operator <=(DateTimeInt64 dtValue1, DateTimeInt64 dtValue2)
		{
			return dtValue1.Value <= dtValue2.Value;
		}

		public static bool operator >=(DateTimeInt64 dtValue1, DateTimeInt64 dtValue2)
		{
			return dtValue1.Value >= dtValue2.Value;
		}

		public static bool operator <(DateTimeInt64 dtValue, long ticks)
		{
			return dtValue.Value < ticks;
		}

		public static bool operator >(DateTimeInt64 dtValue, long ticks)
		{
			return dtValue.Value > ticks;
		}

		public static bool operator <=(DateTimeInt64 dtValue, long ticks)
		{
			return dtValue.Value <= ticks;
		}

		public static bool operator >=(DateTimeInt64 dtValue, long ticks)
		{
			return dtValue.Value >= ticks;
		}

		public override bool Equals(object obj)
		{
			DateTimeInt64 dateTimeInt = default(DateTimeInt64);
			int num;
			if (obj is DateTimeInt64)
			{
				dateTimeInt = (DateTimeInt64)obj;
				num = 1;
			}
			else
			{
				num = 0;
			}
			if (num != 0)
			{
				return dateTimeInt.Value == Value;
			}
			long num2 = default(long);
			int num3;
			if (obj is long)
			{
				num2 = (long)obj;
				num3 = 1;
			}
			else
			{
				num3 = 0;
			}
			if (num3 != 0)
			{
				return num2 == Value;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		int IComparable.CompareTo(object obj)
		{
			if (!(obj is DateTimeInt64))
			{
				throw new ArgumentException();
			}
			return Value.CompareTo(((DateTimeInt64)obj).Value);
		}

		public string ToString(long ticks)
		{
			return ToString(ticks, "yyyy-MM-dd HH:mm:ss.fff");
		}

		public override string ToString()
		{
			return ToString(Value, "yyyy-MM-dd HH:mm:ss.fff");
		}

		public string ToString(string fmtStr)
		{
			return ToString(Value, fmtStr);
		}

		public static string ToString(long dtValue, string fmtStr)
		{
			return TicksToDateTime(dtValue).ToString(fmtStr);
		}

		public bool Equals(DateTimeInt64 dtValue)
		{
			return Value == dtValue.Value;
		}

		public bool Equals(long ticks)
		{
			return Value == ticks;
		}

		public bool Equals(DateTime datetime)
		{
			return Value == new DateTimeInt64(datetime).Value;
		}
	}
}
