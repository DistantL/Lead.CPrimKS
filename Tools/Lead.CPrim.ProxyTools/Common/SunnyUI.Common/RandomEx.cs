using System;
using System.Text;
using Lead.CPrim.ProxyTools;

public static class RandomEx
{
	public static long RandomLong()
	{
		byte[] value = Guid.NewGuid().ToByteArray();
		return BitConverter.ToInt64(value, 0);
	}

	public static string RandomPureChar(int length = 10)
	{
		return RandomBase("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(), length);
	}

	public static string RandomChars(int length = 10)
	{
		return RandomBase("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray(), length);
	}

	public static string RandomNumber(int length = 18, bool firstcanbezero = true)
	{
		string text = RandomBase("0123456789".ToCharArray(), length);
		if (firstcanbezero)
		{
			return text;
		}
		while (text.Left(1) == "0")
		{
			text = RandomBase("0123456789".ToCharArray(), length);
		}
		return text;
	}

	private static string RandomBase(char[] pattern, int length)
	{
		if (pattern.IsNullOrEmpty())
		{
			throw new ArgumentNullException();
		}
		string text = "";
		for (int i = 0; i < length; i++)
		{
			Random random = new Random(RandomSeed());
			text += pattern[random.Next(0, pattern.Length)];
		}
		return text;
	}

	public static int RandomSeed()
	{
		return Guid.NewGuid().GetHashCode();
	}

	public static bool NextBool()
	{
		Random random = new Random(RandomSeed());
		return random.NextDouble() > 0.5;
	}

	public static T NextEnum<T>() where T : struct
	{
		Random random = new Random(RandomSeed());
		Type typeFromHandle = typeof(T);
		if (!typeFromHandle.IsEnum)
		{
			throw new InvalidOperationException();
		}
		Array values = Enum.GetValues(typeFromHandle);
		int index = random.Next(values.GetLowerBound(0), values.GetUpperBound(0) + 1);
		return (T)values.GetValue(index);
	}

	public static byte[] NextBytes(int length)
	{
		Random random = new Random(RandomSeed());
		byte[] array = new byte[length];
		random.NextBytes(array);
		return array;
	}

	public static int Next(int maxValue = int.MaxValue)
	{
		Random random = new Random(RandomSeed());
		return random.Next(maxValue);
	}

	public static string RandomChinese(int length = 6)
	{
		Encoding encoding = GlobalVariables.EncodingChinese;
		object[] array = CreateRegionCode(length);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < length; i++)
		{
			string @string = encoding.GetString((byte[])Convert.ChangeType(array[i], typeof(byte[])));
			stringBuilder.Append(@string);
		}
		return stringBuilder.ToString();
	}

	private static object[] CreateRegionCode(int length)
	{
		string[] array = new string[16]
		{
			"0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
			"a", "b", "c", "d", "e", "f"
		};
		object[] array2 = new object[length];
		for (int i = 0; i < length; i++)
		{
			Random random = new Random(RandomSeed());
			int num = random.Next(11, 14);
			string text = array[num].Trim();
			random = new Random(RandomSeed());
			int num2 = random.Next(0, (num == 13) ? 7 : 16);
			string text2 = array[num2].Trim();
			random = new Random(RandomSeed());
			int num3 = random.Next(10, 16);
			string text3 = array[num3].Trim();
			random = new Random(RandomSeed());
			int num4;
			switch (num3)
			{
				case 10:
					num4 = random.Next(1, 16);
					break;
				case 15:
					num4 = random.Next(0, 15);
					break;
				default:
					num4 = random.Next(0, 16);
					break;
			}
			string text4 = array[num4].Trim();
			byte b = Convert.ToByte(text + text2, 16);
			byte b2 = Convert.ToByte(text3 + text4, 16);
			byte[] value = new byte[2] { b, b2 };
			array2.SetValue(value, i);
		}
		return array2;
	}

	public static string RandomChineseEx(int length = 6)
	{
		string[] array = new string[length];
		Random random = new Random();
		for (int i = 0; i < length; i++)
		{
			int num = random.Next(16, 88);
			int num2 = random.Next(1, (num == 55) ? 90 : 94);
			array[i] = GlobalVariables.EncodingChinese.GetString(new byte[2]
			{
				Convert.ToByte(num + 160),
				Convert.ToByte(num2 + 160)
			});
		}
		StringBuilder stringBuilder = new StringBuilder();
		string[] array2 = array;
		foreach (string value in array2)
		{
			stringBuilder.Append(value);
		}
		return stringBuilder.ToString();
	}
}
