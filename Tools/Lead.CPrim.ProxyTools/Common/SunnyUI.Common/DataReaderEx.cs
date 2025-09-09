using Lead.CPrim.ProxyTools;
using System;
using System.Data;

namespace Sunny.UI
{
    public static class DataReaderEx
	{
		public static bool IsInState(this IDbConnection connection, ConnectionState state)
		{
			return connection != null && (connection.State & state) == state;
		}

		public static void OpenIfNot(this IDbConnection connection)
		{
			if (!connection.IsInState(ConnectionState.Open))
			{
				connection.Open();
			}
		}

		public static T Get<T>(this IDataReader reader, string field)
		{
			return reader.Get(field, default(T));
		}

		public static T Get<T>(this IDataReader reader, string field, T defaultValue)
		{
			object obj = reader[field];
			if (obj == DBNull.Value)
			{
				return defaultValue;
			}
			T result;
			if (obj is T)
			{
				T val = (T)obj;
				result = val;
			}
			else
			{
				result = defaultValue;
			}
			return result;
		}

		public static byte[] GetBytes(this IDataReader reader, string field)
		{
			return reader[field] as byte[];
		}

		public static string GetString(this IDataReader reader, string field)
		{
			return reader.GetString(field, null);
		}

		public static string GetString(this IDataReader reader, string field, string defaultValue)
		{
			object obj = reader[field];
			string text = obj as string;
			return (text != null) ? text : defaultValue;
		}

		public static Guid GetGuid(this IDataReader reader, string field)
		{
			object obj = reader[field];
			Guid result;
			if (obj is Guid)
			{
				Guid guid = (Guid)obj;
				result = guid;
			}
			else
			{
				result = Guid.Empty;
			}
			return result;
		}

		public static Guid? GetNullableGuid(this IDataReader reader, string field)
		{
			object obj = reader[field];
			return (obj is Guid) ? ((Guid?)obj) : null;
		}

		public static DateTime GetDateTime(this IDataReader reader, string field)
		{
			return reader.GetDateTime(field, DateTime.MinValue);
		}

		public static DateTime GetDateTime(this IDataReader reader, string field, DateTime defaultValue)
		{
			object obj = reader[field];
			DateTime result;
			if (obj is DateTime)
			{
				DateTime dateTime = (DateTime)obj;
				result = dateTime;
			}
			else
			{
				result = defaultValue;
			}
			return result;
		}

		public static DateTime? GetNullableDateTime(this IDataReader reader, string field)
		{
			object obj = reader[field];
			return (obj is DateTime) ? ((DateTime?)obj) : null;
		}

		public static DateTimeOffset GetDateTimeOffset(this IDataReader reader, string field)
		{
			return new DateTimeOffset(reader.GetDateTime(field), TimeSpan.Zero);
		}

		public static DateTimeOffset GetDateTimeOffset(this IDataReader reader, string field, DateTimeOffset defaultValue)
		{
			DateTime dateTime = reader.GetDateTime(field);
			return (dateTime != DateTime.MinValue) ? new DateTimeOffset(dateTime, TimeSpan.Zero) : defaultValue;
		}

		public static DateTimeOffset? GetNullableDateTimeOffset(this IDataReader reader, string field)
		{
			DateTime? nullableDateTime = reader.GetNullableDateTime(field);
			return nullableDateTime.HasValue ? new DateTimeOffset?(new DateTimeOffset(nullableDateTime.Value, TimeSpan.Zero)) : null;
		}

		public static int GetInt32(this IDataReader reader, string field)
		{
			return reader.GetInt32(field, 0);
		}

		public static int GetInt32(this IDataReader reader, string field, int defaultValue)
		{
			object obj = reader[field];
			int result;
			if (obj is int)
			{
				int num = (int)obj;
				result = num;
			}
			else
			{
				result = defaultValue;
			}
			return result;
		}

		public static int? GetNullableInt32(this IDataReader reader, string field)
		{
			object obj = reader[field];
			return (obj is int) ? ((int?)obj) : null;
		}

		public static long GetInt64(this IDataReader reader, string field)
		{
			return reader.GetInt64(field, 0);
		}

		public static long GetInt64(this IDataReader reader, string field, int defaultValue)
		{
			object obj = reader[field];
			long result;
			if (obj is long)
			{
				long num = (long)obj;
				result = num;
			}
			else
			{
				result = defaultValue;
			}
			return result;
		}

		public static long? GetNullableInt64(this IDataReader reader, string field)
		{
			object obj = reader[field];
			return (obj is long) ? ((long?)obj) : null;
		}

		public static decimal GetDecimal(this IDataReader reader, string field)
		{
			return reader.GetDecimal(field, 0L);
		}

		public static decimal GetDecimal(this IDataReader reader, string field, long defaultValue)
		{
			object obj = reader[field];
			decimal result;
			if (obj is decimal)
			{
				decimal num = (decimal)obj;
				result = num;
			}
			else
			{
				result = defaultValue;
			}
			return result;
		}

		public static decimal? GetNullableDecimal(this IDataReader reader, string field)
		{
			object obj = reader[field];
			return (obj is decimal) ? ((decimal?)obj) : null;
		}

		public static bool GetBoolean(this IDataReader reader, string field)
		{
			return reader.GetBoolean(field, defaultValue: false);
		}

		public static bool GetBoolean(this IDataReader reader, string field, bool defaultValue)
		{
			object obj = reader[field];
			bool result;
			if (obj is bool)
			{
				bool flag = (bool)obj;
				result = flag;
			}
			else
			{
				result = defaultValue;
			}
			return result;
		}

		public static bool? GetNullableBoolean(this IDataReader reader, string field)
		{
			object obj = reader[field];
			return (obj is bool) ? ((bool?)obj) : null;
		}

		public static Type GetType(this IDataReader reader, string field)
		{
			return reader.GetType(field, null);
		}

		public static Type GetType(this IDataReader reader, string field, Type defaultValue)
		{
			string @string = reader.GetString(field);
			if (@string.IsNullOrEmpty())
			{
				return defaultValue;
			}
			Type type = Type.GetType(@string);
			return type ?? defaultValue;
		}

		public static object GetTypeInstance(this IDataReader reader, string field)
		{
			return reader.GetTypeInstance(field, null);
		}

		public static object GetTypeInstance(this IDataReader reader, string field, Type defaultValue)
		{
			Type type = reader.GetType(field, defaultValue);
			return (type != null) ? Activator.CreateInstance(type) : null;
		}

		public static T GetTypeInstance<T>(this IDataReader reader, string field) where T : class
		{
			return reader.GetTypeInstance(field, null) as T;
		}

		public static T GetTypeInstanceSafe<T>(this IDataReader reader, string field, Type type) where T : class
		{
			T val = reader.GetTypeInstance(field, null) as T;
			return val ?? (Activator.CreateInstance(type) as T);
		}

		public static T GetTypeInstanceSafe<T>(this IDataReader reader, string field) where T : class, new()
		{
			T val = reader.GetTypeInstance(field, null) as T;
			return val ?? new T();
		}

		public static bool IsDBNull(this IDataReader reader, string field)
		{
			object obj = reader[field];
			return obj == DBNull.Value;
		}

		public static int ReadAll(this IDataReader reader, Action<IDataReader> action)
		{
			int num = 0;
			while (reader.Read())
			{
				action(reader);
				num++;
			}
			return num;
		}

		public static int IndexOf(this IDataRecord record, string name)
		{
			for (int i = 0; i < record.FieldCount; i++)
			{
				if (string.Compare(record.GetName(i), name, StringComparison.OrdinalIgnoreCase) == 0)
				{
					return i;
				}
			}
			return -1;
		}
	}
}
