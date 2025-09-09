/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ArrayEx.cs
 * Author: Victor
 * Description: 支持Array和byte操作
 * 1、支持结构体与byte数组进行转换
 * 2、支持字符串与byte数组转换
 * CreateTime: 2023-1-2
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.23.0101><Victor><20230116>
 * 1、初版1.0
******************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Lead.CPrim.ProxyTools
{
	public static class ArrayEx
	{
		/// <summary>获取结构体的大小</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static int Size<T>(this T obj) where T : struct
		{
			return Marshal.SizeOf(typeof(T));
		}

		/// <summary>结构体转化为Byte数组</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static byte[] StructToBytes<T>(this T obj) where T : struct
		{
			int num = obj.Size();
			byte[] array = new byte[num];
			IntPtr intPtr = Marshal.AllocHGlobal(num);
			Marshal.StructureToPtr((object)obj, intPtr, fDeleteOld: false);
			Marshal.Copy(intPtr, array, 0, num);
			Marshal.FreeHGlobal(intPtr);
			return array;
		}

		/// <summary>Byte数组转化为结构体</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="bytes"></param>
		/// <returns></returns>
		public static T ToStruct<T>(this byte[] bytes) where T : struct
		{
			if (bytes == null)
			{
				throw new NullReferenceException();
			}
			int num;
			try
			{
				num = Marshal.SizeOf(typeof(T));
			}
			catch (Exception)
			{
				throw new NullReferenceException();
			}
			if (num > bytes.Length)
			{
				throw new NullReferenceException();
			}
			IntPtr intPtr = Marshal.AllocHGlobal(num);
			Marshal.Copy(bytes, 0, intPtr, num);
			object obj = Marshal.PtrToStructure(intPtr, typeof(T));
			Marshal.FreeHGlobal(intPtr);
			return (T)obj;
		}

		/// <summary>byte数组转化为16进制字符串</summary>
		/// <param name="bytes"></param>
		/// <param name="span">分割符</param>
		/// <returns></returns>
		public static string ToHexString(this IEnumerable<byte> bytes, string span = "")
		{
			StringBuilder text = new StringBuilder();
			foreach (byte @byte in bytes)
			{
				text.Append(@byte.ToHex());
				text.Append(span);
			}
			return text.ToString();
		}

		/// <summary>byte转化为十六进制字符串</summary>
		/// <param name="b"></param>
		/// <returns></returns>
		public static string ToHex(this byte b)
		{
			return b.ToString("X2");
		}

		/// <summary>字符串转化为十六进制Byte数组</summary>
		/// <param name="str">字符串</param>
		/// <param name="span">待删除字符串</param>
		/// <returns></returns>
		public static byte[] ToHexBytes(this string str, string span = "")
		{
			if (!span.IsNullOrEmpty())
			{
				str = str.Replace(span, "");
			}

			if (str.IsNullOrEmpty())
			{
				return new byte[0];
			}

			if(str.Length % 2 != 0)
			{
				str += " ";
			}

			byte[] array = new byte[str.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Convert.ToByte(str.Substring(i * 2, 2), 16); ;
			}
			return array;
		}

		/// <summary>
		/// 非泛型集合判断（true：集合为null；false：集合不为null；）
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static bool IsNullOrEmpty(this IList source)
		{
			return source == null || source.Count == 0;
		}

		/// <summary>
		/// 集合索引判断（true：索引在集合内；false：索引不在集合内）
		/// </summary>
		/// <param name="source"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static bool WithinIndex(this IList source, int index)
		{
			return source.IsValid() && index >= 0 && index < source.Count;
		}

		/// <summary>集合有效性判断（true：有效；false：无效；）</summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static bool IsValid(this IList source)
		{
			return !source.IsNullOrEmpty();
		}

		/// <summary>
		/// 二进制数组转化为int
		/// </summary>
		/// <param name="binaryBits"></param>
		/// <returns></returns>
		public static int ToInt(this byte[] binaryBits)
		{
			if (binaryBits.Any((byte i) => i != 0 && i != 1))
			{
				throw new ArgumentException("若要使用该方法，byte数组必须只包含0或1。");
			}

			Array.Reverse(binaryBits);
			return Convert.ToInt32(string.Join("", binaryBits), 2);
		}

		/// <summary>
		/// 待验证
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		public static int[] ToIntegers(this byte[] b)
		{
			int[] array = new int[b.Length / 4];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = BitConverter.ToInt32(b, i * 4);
			}
			return array;
		}

		/// <summary>
		/// 布尔数组转化为int
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static int ToInt(this bool[] value)
		{
			byte[] array = new byte[value.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(value[i] ? 1 : 0);
			}
			Array.Reverse(array);
			return Convert.ToInt32(string.Join("", array), 2);
		}

		/// <summary>
		/// 转化为二进制byte数组
		/// </summary>
		/// <param name="value">int</param>
		/// <param name="length">显示长度（如果显示长度小于实际长度，以实际长度显示）</param>
		/// <returns></returns>
		public static byte[] ToBinArray(this int value, int length = 32)
		{
			string text = value.ToBin(length);
			if(!text.IsValid())
            {
				return null;
            }

			char[] array = text.ToArray();
			byte[] bytes = new byte[array.Length];
			Array.Reverse(array);
            for (int i = 0; i < array.Length; i++)
            {
				bytes[i] = array[i] == '1' ? (byte)1 : (byte)0;
				if (array[i] == '1')
                {
					bytes[i] = 1;
                }
				else
                {
					bytes[i] = 0;
				}
            }
			return bytes;
		}

		/// <summary>
		/// 转化为布尔数组
		/// </summary>
		/// <param name="value">int</param>
		/// <param name="length">显示长度（如果显示长度小于实际长度，以实际长度显示）</param>
		/// <returns></returns>
		public static bool[] ToBoolArray(this int value, int length = 32)
		{
			string text = value.ToBin(length);
			if (!text.IsValid())
			{
				return null;
			}

			char[] array = text.ToArray();
			bool[] bytes = new bool[array.Length];
			Array.Reverse(array);
			for (int i = 0; i < array.Length; i++)
			{
				bytes[i] = array[i] == '1' ? true : false;
			}
			return bytes;
		}




		public static byte[] SevenZipCompress(this byte[] inputBytes)
		{
			return SevenZipEx.Zip(inputBytes);
		}

		public static IntPtr Handle(this byte[] buffer)
		{
			return Marshal.UnsafeAddrOfPinnedArrayElement((Array)buffer, 0);
		}

		public static void Disorder<T>(this T[] data)
		{
			if (data != null && data.Length != 0)
			{
				int num = 1;
				int num2 = data.Length;
				int num3 = 0;
				Random random = new Random();
				while (num != num2)
				{
					int num4 = random.Next(num++, num2);
					T val = data[num3];
					data[num3] = data[num4];
					data[num4] = val;
					num3++;
				}
			}
		}

		public static byte[] SevenZipDecompress(this byte[] inputBytes)
		{
			return SevenZipEx.Unzip(inputBytes);
		}

		public static byte[] BCDData(int value, int length)
		{
			return value.ToString("D" + length * 2).ToHexBytes();
		}

		public static byte[] BCDData(long value, int length)
		{
			return value.ToString("D" + length * 2).ToHexBytes();
		}

		public static byte[] ReadBytes(this Stream stream, long length = -1L)
		{
			if (stream == null)
			{
				return null;
			}
			if (length == 0)
			{
				return new byte[0];
			}
			if (stream.CanSeek && stream.Length - stream.Position < length)
			{
				throw new Exception($"无法从长度只有{stream.Length - stream.Position}的数据流里面读取{length}字节的数据");
			}
			byte[] array = new byte[length];
			stream.Read(array, 0, array.Length);
			return array;
		}

		public static byte[] ReadBytes(this byte[] src, int offset = 0, int count = -1)
		{
			if (count == 0)
			{
				return new byte[0];
			}
			if (count < 0)
			{
				count = src.Length - offset;
			}
			byte[] array = new byte[count];
			Buffer.BlockCopy(src, offset, array, 0, array.Length);
			return array;
		}

		public static bool[] ToBooleans(this string str)
		{
			bool[] array = new bool[str.Length];
			for (int i = 0; i < str.Length; i++)
			{
				array[i] = str.Substring(i, 1) == "1";
			}
			return array;
		}

		public static string ToBooleansString(this bool[] b)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (bool flag in b)
			{
				stringBuilder.Append(flag ? "1" : "0");
			}
			return stringBuilder.ToString();
		}

		public static byte[] ToBytes(this bool[] b, bool needCompress = false)
		{
			if (b.IsNullOrEmpty())
			{
				return null;
			}
			if (!needCompress)
			{
				byte[] array = new byte[b.Length];
				for (int i = 0; i < b.Length; i++)
				{
					array[i] = b[i].ToByte();
				}
				return array;
			}
			int num = b.Length / 8;
			if (b.Length % 8 != 0)
			{
				num++;
			}
			byte[] array2 = b.ToBytes();
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array3 = array2;
			foreach (byte b2 in array3)
			{
				stringBuilder.Append(b2.ToString());
			}
			string text = stringBuilder.ToString().PadRight(num * 8, '0');
			byte[] array4 = new byte[num];
			for (int k = 0; k < num; k++)
			{
				array4[k] = (byte)text.Left(8).ToNumberLong(MathEx.Characters.BINARY);
				text = text.RemoveLeft(8);
			}
			return array4;
		}

		public static bool[] ToBooleans(this byte[] b, bool compressed = false)
		{
			if (b.IsNullOrEmpty())
			{
				return null;
			}
			if (!compressed)
			{
				bool[] array = new bool[b.Length];
				for (int i = 0; i < b.Length; i++)
				{
					array[i] = b[i].ToBool();
				}
				return array;
			}
			int num = b.Length * 8;
			bool[] array2 = new bool[num];
			for (int j = 0; j < b.Length; j++)
			{
				string text = b[j].ToNumberString(MathEx.Characters.BINARY).PadLeft(8, '0');
				for (int k = 0; k < 8; k++)
				{
					array2[j * 8 + k] = text[k] == '1';
				}
			}
			return array2;
		}

		public static byte[] ToBytes(this float[] f)
		{
			byte[] array = new byte[f.Length * 4];
			for (int i = 0; i < f.Length; i++)
			{
				Array.Copy(BitConverter.GetBytes(f[i]), 0, array, i * 4, 4);
			}
			return array;
		}

		public static float[] ToFloats(this byte[] b)
		{
			float[] array = new float[b.Length / 4];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = BitConverter.ToSingle(b, i * 4);
			}
			return array;
		}

		public static double[] ToDoubles(this byte[] b)
		{
			double[] array = new double[b.Length / 8];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = BitConverter.ToSingle(b, i * 8);
			}
			return array;
		}

		public static byte[] ToBytes(this int[] f)
		{
			byte[] array = new byte[f.Length * 4];
			for (int i = 0; i < f.Length; i++)
			{
				Array.Copy(BitConverter.GetBytes(f[i]), 0, array, i * 4, 4);
			}
			return array;
		}

		public static string ToBase64String(this byte[] b)
		{
			return b.IsNullOrEmpty() ? string.Empty : Convert.ToBase64String(b);
		}

		public static byte[] ToBase64Bytes(this string b)
		{
			return b.IsNullOrEmpty() ? null : Convert.FromBase64String(b);
		}

		public static byte[] One(this byte[,] two, int index)
		{
			if (index < 0 || index >= two.GetLength(0))
			{
				return null;
			}
			int length = two.GetLength(1);
			byte[] array = new byte[length];
			IntPtr source = Marshal.UnsafeAddrOfPinnedArrayElement(two, index * length);
			Marshal.Copy(source, array, 0, length);
			return array;
		}

		public static float[] One(this float[,] two, int index)
		{
			if (index < 0 || index >= two.GetLength(0))
			{
				return null;
			}
			int length = two.GetLength(1);
			float[] array = new float[length];
			IntPtr source = Marshal.UnsafeAddrOfPinnedArrayElement(two, index * length);
			Marshal.Copy(source, array, 0, length);
			return array;
		}

		public static int[] One(this int[,] two, int index)
		{
			if (index < 0 || index >= two.GetLength(0))
			{
				return null;
			}
			int length = two.GetLength(1);
			int[] array = new int[length];
			IntPtr source = Marshal.UnsafeAddrOfPinnedArrayElement(two, index * length);
			Marshal.Copy(source, array, 0, length);
			return array;
		}

		public static double[] One(this double[,] two, int index)
		{
			if (index < 0 || index >= two.GetLength(0))
			{
				return null;
			}
			int length = two.GetLength(1);
			double[] array = new double[length];
			IntPtr source = Marshal.UnsafeAddrOfPinnedArrayElement(two, index * length);
			Marshal.Copy(source, array, 0, length);
			return array;
		}

		public static char[] One(this char[,] two, int index)
		{
			if (index < 0 || index >= two.GetLength(0))
			{
				return null;
			}
			int length = two.GetLength(1);
			char[] array = new char[length];
			IntPtr source = Marshal.UnsafeAddrOfPinnedArrayElement(two, index * length);
			Marshal.Copy(source, array, 0, length);
			return array;
		}

		public static long[] One(this long[,] two, int index)
		{
			if (index < 0 || index >= two.GetLength(0))
			{
				return null;
			}
			int length = two.GetLength(1);
			long[] array = new long[length];
			IntPtr source = Marshal.UnsafeAddrOfPinnedArrayElement(two, index * length);
			Marshal.Copy(source, array, 0, length);
			return array;
		}

		public static short[] One(this short[,] two, int index)
		{
			if (index < 0 || index >= two.GetLength(0))
			{
				return null;
			}
			int length = two.GetLength(1);
			short[] array = new short[length];
			IntPtr source = Marshal.UnsafeAddrOfPinnedArrayElement(two, index * length);
			Marshal.Copy(source, array, 0, length);
			return array;
		}

		public static double MedianNum(this double[] a, bool avg = false)
		{
			if (a.IsNullOrEmpty())
			{
				throw new NullReferenceException();
			}
			Array.Sort(a);
			return (a.Length & 1) > 0 ? a[a.Length / 2] : avg ? a[a.Length / 2 - 1] : a[a.Length / 2];
		}

		public static int MedianNum(this int[] a, bool avg = false)
		{
			if (a.IsNullOrEmpty())
			{
				throw new NullReferenceException();
			}
			Array.Sort(a);
			return (a.Length & 1) > 0 ? a[a.Length / 2] : avg ? a[a.Length / 2 - 1] : a[a.Length / 2];
		}

		public static byte MedianNum(this byte[] a, bool avg = false)
		{
			if (a.IsNullOrEmpty())
			{
				throw new NullReferenceException();
			}
			Array.Sort(a);
			return (a.Length & 1) > 0 ? a[a.Length / 2] : avg ? a[a.Length / 2 - 1] : a[a.Length / 2];
		}

		public static float MedianNum(this float[] a, bool avg = false)
		{
			if (a.IsNullOrEmpty())
			{
				throw new NullReferenceException();
			}
			Array.Sort(a);
			return (a.Length & 1) > 0 ? a[a.Length / 2] : avg ? a[a.Length / 2 - 1] : a[a.Length / 2];
		}

		public static short MedianNum(this short[] a, bool avg = false)
		{
			if (a.IsNullOrEmpty())
			{
				throw new NullReferenceException();
			}
			Array.Sort(a);
			return (a.Length & 1) > 0 ? a[a.Length / 2] : avg ? a[a.Length / 2 - 1] : a[a.Length / 2];
		}

		public static T[] CombineArray<T>(this T[] combineWith, T[] arrayToCombine)
		{
			if (combineWith == null || arrayToCombine == null)
			{
				return combineWith;
			}
			int num = combineWith.Length;
			Array.Resize(ref combineWith, num + arrayToCombine.Length);
			Array.Copy(arrayToCombine, arrayToCombine.GetLowerBound(0), combineWith, num, arrayToCombine.Length);
			return combineWith;
		}

		public static T[] BlockCopy<T>(this T[] array, int index, int length, bool padToLength = false)
		{
			if (array == null)
			{
				throw new NullReferenceException();
			}
			int num = length;
			T[] array2 = null;
			if (array.Length < index + length)
			{
				num = array.Length - index;
				if (padToLength)
				{
					array2 = new T[length];
				}
			}
			if (array2 == null)
			{
				array2 = new T[num];
			}
			Array.Copy(array, index, array2, 0, num);
			return array2;
		}

		public static int FindArrayInArray(this byte[] buf1, byte[] buf2)
		{
			if (buf2 == null || buf1 == null)
			{
				return -1;
			}
			if (buf2.Length == 0)
			{
				return 0;
			}
			int num = -1;
			int num2 = buf1.Length - buf2.Length;
			while ((num = Array.IndexOf(buf1, buf2[0], num + 1)) <= num2 && num != -1)
			{
				int num3 = 1;
				while (buf1[num + num3] == buf2[num3])
				{
					if (++num3 == buf2.Length)
					{
						return num;
					}
				}
			}
			return -1;
		}

		public static byte[] GZipCompress(this byte[] inputBytes)
		{
			if (inputBytes.IsNullOrEmpty())
			{
				return null;
			}
			using (MemoryStream memoryStream = new MemoryStream())
			using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, leaveOpen: true))
			{
				gZipStream.Write(inputBytes, 0, inputBytes.Length);
				return memoryStream.ToArray();
			};
		}

		public static byte[] GZipDecompress(this byte[] inputBytes)
		{
			if (inputBytes.IsNullOrEmpty())
			{
				return null;
			}
			using (MemoryStream stream = new MemoryStream(inputBytes))
			using (MemoryStream memoryStream = new MemoryStream())
			using (GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress))
			{
				gZipStream.CopyTo(memoryStream);
				return memoryStream.ToArray();
			}
		}

		public static byte[] DeflateCompress(this byte[] inputBytes)
		{
			if (inputBytes.IsNullOrEmpty())
			{
				return null;
			}
			using (MemoryStream memoryStream = new MemoryStream())
			using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Compress, leaveOpen: true))
			{
				deflateStream.Write(inputBytes, 0, inputBytes.Length);
				return memoryStream.ToArray();
			}
		}

		public static byte[] DeflateDecompress(this byte[] inputBytes)
		{
			if (inputBytes.IsNullOrEmpty())
			{
				return null;
			}
			using (MemoryStream stream = new MemoryStream(inputBytes))
			using (MemoryStream memoryStream = new MemoryStream())
			using (DeflateStream deflateStream = new DeflateStream(stream, CompressionMode.Decompress))
			{
				deflateStream.CopyTo(memoryStream);
				return memoryStream.ToArray();
			}
		}

		public static void BubbleSort(this int[] list)
		{
			for (int i = 0; i < list.Length; i++)
			{
				for (int j = i; j < list.Length; j++)
				{
					if (list[i] < list[j])
					{
						int num = list[i];
						list[i] = list[j];
						list[j] = num;
					}
				}
			}
		}

		public static void InsertionSort(int[] list)
		{
			for (int i = 1; i < list.Length; i++)
			{
				int num = list[i];
				int num2 = i;
				while (num2 > 0 && list[num2 - 1] > num)
				{
					list[num2] = list[num2 - 1];
					num2--;
				}
				list[num2] = num;
			}
		}

		public static void SelectionSort(int[] list)
		{
			for (int i = 0; i < list.Length - 1; i++)
			{
				int num = i;
				for (int j = i + 1; j < list.Length; j++)
				{
					if (list[j] < list[num])
					{
						num = j;
					}
				}
				int num2 = list[num];
				list[num] = list[i];
				list[i] = num2;
			}
		}

		public static void ShellSort(int[] list)
		{
			for (int num = 1; num <= list.Length / 9; num = 3 * num + 1)
			{
				while (num > 0)
				{
					for (int i = num + 1; i <= list.Length; i += num)
					{
						int num2 = list[i - 1];
						int num3 = i;
						while (num3 > num && list[num3 - num - 1] > num2)
						{
							list[num3 - 1] = list[num3 - num - 1];
							num3 -= num;
						}
						list[num3 - 1] = num2;
					}
					num /= 3;
				}
			}
		}

		public static void Swap<T>(ref T l, ref T r) where T : struct
		{
			T val = l;
			l = r;
			r = val;
		}

		public static void QuickSort(int[] list, int low, int high)
		{
			if (high <= low)
			{
				return;
			}
			if (high == low + 1)
			{
				if (list[low] > list[high])
				{
					Swap(ref list[low], ref list[high]);
				}
				return;
			}
			int num = low + high >> 1;
			int num2 = list[num];
			Swap(ref list[low], ref list[num]);
			int num3 = low + 1;
			int num4 = high;
			while (true)
			{
				if (num3 <= num4 && list[num3] < num2)
				{
					num3++;
					continue;
				}
				while (list[num4] >= num2)
				{
					num4--;
				}
				if (num3 < num4)
				{
					Swap(ref list[num3], ref list[num4]);
				}
				if (num3 >= num4)
				{
					break;
				}
			}
			list[low] = list[num4];
			list[num4] = num2;
			if (low + 1 < num4)
			{
				QuickSort(list, low, num4 - 1);
			}
			if (num4 + 1 < high)
			{
				QuickSort(list, num4 + 1, high);
			}
		}

		public static T ReadType<T>(this BinaryReader reader)
		{
			byte[] value = reader.ReadBytes(Marshal.SizeOf(typeof(T)));
			GCHandle gCHandle = GCHandle.Alloc(value, GCHandleType.Pinned);
			T result = (T)Marshal.PtrToStructure(gCHandle.AddrOfPinnedObject(), typeof(T));
			gCHandle.Free();
			return result;
		}

		public static string ReadSZString(this BinaryReader reader)
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (true)
			{
				byte b = reader.ReadByte();
				if (b == 0)
				{
					break;
				}
				stringBuilder.Append((char)b);
			}
			return stringBuilder.ToString();
		}

		public static string ReadFixedString(this BinaryReader reader, int count)
		{
			return Encoding.ASCII.GetString(reader.ReadBytes(count));
		}

		public static bool IsEqual(this Stream stream, Stream otherStream)
		{
			if (stream == null)
			{
				return false;
			}
			if (otherStream == null)
			{
				return false;
			}
			if (stream.Length != otherStream.Length)
			{
				return false;
			}
			if (stream == otherStream)
			{
				return true;
			}
			int num = 2048;
			byte[] array = new byte[num];
			byte[] array2 = new byte[num];
			while (stream.Read(array, 0, array.Length) > 0)
			{
				otherStream.Read(array2, 0, array2.Length);
				if (!array2.SequenceEqual(array))
				{
					stream.Seek(0L, SeekOrigin.Begin);
					otherStream.Seek(0L, SeekOrigin.Begin);
					return false;
				}
			}
			stream.Seek(0L, SeekOrigin.Begin);
			otherStream.Seek(0L, SeekOrigin.Begin);
			return true;
		}

		public static MemoryStream ToMemoryStream(this byte[] data)
		{
			return new MemoryStream(data);
		}
	}
}
