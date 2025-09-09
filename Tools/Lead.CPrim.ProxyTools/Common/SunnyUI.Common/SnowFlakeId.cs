using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Sunny.UI
{
	public class SnowFlakeId
	{
		public class SnowId
		{
			public long Id { get; set; }

			public long Timestamp { get; set; }

			public long UnixTimestamp => Timestamp + StartTimestamp;

			public DateTime UtcDateTime => Jan1st1970.AddMilliseconds(UnixTimestamp);

			public long Sequence { get; set; }

			public long DataCenterId { get; set; }

			public long WorkerId { get; set; }

			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(UtcDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
				stringBuilder.Append(", ");
				stringBuilder.Append(DataCenterId);
				stringBuilder.Append(", ");
				stringBuilder.Append(WorkerId);
				stringBuilder.Append(", ");
				stringBuilder.Append(Sequence);
				return stringBuilder.ToString();
			}
		}

		private static SnowFlakeId instance;

		private static readonly DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		private static readonly long StartTimestamp = (long)(new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc) - Jan1st1970).TotalMilliseconds;

		private int DataCenterIdBitLength { get; set; }

		private int WorkerIdBitLength { get; set; }

		private int SequenceBitLength { get; set; }

		private int TimestampBitLength { get; set; }

		private long MaxDataCenterId { get; set; }

		private long MaxWorkerId { get; set; }

		private long MaxSequence { get; set; }

		private long MaxTimestamp { get; set; }

		private DateTime MaxUtcTime => Jan1st1970.AddMilliseconds(MaxTimestamp + StartTimestamp);

		public SnowId LastSnowId { get; private set; }

		public long DataCenterId { get; private set; }

		public long WorkerId { get; private set; }

		public static SnowFlakeId Instance()
		{
			if (instance == null)
			{
				instance = new SnowFlakeId();
			}
			return instance;
		}

		public SnowFlakeId()
			: this(16, 0, 0, 0L, 0L)
		{
		}

		public SnowFlakeId(long dataCenterId, long workerId)
			: this(12, 5, 5, dataCenterId, workerId)
		{
		}

		public SnowFlakeId(int sequenceBitLength, int datacenterIdBitLength, int workerIdBitLength, long dataCenterId, long workerId)
		{
			SequenceBitLength = sequenceBitLength;
			DataCenterIdBitLength = datacenterIdBitLength;
			WorkerIdBitLength = workerIdBitLength;
			TimestampBitLength = Marshal.SizeOf(typeof(long)) - (SequenceBitLength + DataCenterIdBitLength + WorkerIdBitLength);
			MaxSequence = GetBitLengthMaxValue(SequenceBitLength);
			MaxDataCenterId = GetBitLengthMaxValue(DataCenterIdBitLength);
			MaxWorkerId = GetBitLengthMaxValue(WorkerIdBitLength);
			MaxTimestamp = GetBitLengthMaxValue(TimestampBitLength);
			if (dataCenterId > MaxDataCenterId)
			{
				throw new OverflowException("dataCenterId");
			}
			if (workerId > MaxWorkerId)
			{
				throw new OverflowException("workerId");
			}
			DataCenterId = dataCenterId;
			WorkerId = workerId;
			LastSnowId = new SnowId
			{
				Timestamp = 0L,
				Sequence = 0L,
				DataCenterId = DataCenterId,
				WorkerId = WorkerId
			};
		}

		public long Next()
		{
			lock (LastSnowId)
			{
				long num = GetCurrentTimestamp();
				if (num > LastSnowId.Timestamp)
				{
					LastSnowId.Sequence = 0L;
				}
				else if (num == LastSnowId.Timestamp)
				{
					LastSnowId.Sequence++;
					if (LastSnowId.Sequence > MaxSequence)
					{
						LastSnowId.Sequence = 0L;
						num = GetNextTimestamp(LastSnowId.Timestamp);
					}
				}
				else
				{
					LastSnowId.Sequence++;
					num = LastSnowId.Timestamp;
					if (LastSnowId.Sequence > MaxSequence)
					{
						LastSnowId.Sequence = 0L;
						num = LastSnowId.Timestamp + 1;
					}
				}
				LastSnowId.Timestamp = num;
				LastSnowId.Id = Next(LastSnowId);
				return LastSnowId.Id;
			}
		}

		public long Next(SnowId snowId)
		{
			return (snowId.Timestamp << SequenceBitLength + DataCenterIdBitLength + WorkerIdBitLength) | (snowId.Sequence << DataCenterIdBitLength + WorkerIdBitLength) | (snowId.DataCenterId << WorkerIdBitLength) | snowId.WorkerId;
		}

		public SnowId AnalyzeId(long Id)
		{
			return new SnowId
			{
				Id = Id,
				Timestamp = Id >> SequenceBitLength + DataCenterIdBitLength + WorkerIdBitLength,
				Sequence = ((Id >> DataCenterIdBitLength + WorkerIdBitLength) & MaxSequence),
				DataCenterId = ((Id >> WorkerIdBitLength) & MaxDataCenterId),
				WorkerId = (Id & MaxWorkerId)
			};
		}

		private static long GetNextTimestamp(long lastTimestamp)
		{
			long currentTimestamp;
			for (currentTimestamp = GetCurrentTimestamp(); currentTimestamp <= lastTimestamp; currentTimestamp = GetCurrentTimestamp())
			{
			}
			return currentTimestamp;
		}

		private static long GetCurrentTimestamp()
		{
			return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds - StartTimestamp;
		}

		private static long GetBitLengthMaxValue(int length)
		{
			return -1 ^ (-1L << length);
		}
	}
}
