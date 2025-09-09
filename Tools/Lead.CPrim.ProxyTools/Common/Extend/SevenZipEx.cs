using System;
using System.IO;
using SevenZip;
using SevenZip.Compression.LZMA;

namespace Lead.CPrim.ProxyTools
{
	public static class SevenZipEx
	{
		public static void Zip(Stream inStream, Stream outStream)
		{
			int num = 8388608;
			int num2 = 2;
			int num3 = 3;
			int num4 = 0;
			int num5 = 2;
			int num6 = 128;
			string text = "bt4";
			CoderPropID[] propIDs = new CoderPropID[8]
			{
				CoderPropID.DictionarySize,
				CoderPropID.PosStateBits,
				CoderPropID.LitContextBits,
				CoderPropID.LitPosBits,
				CoderPropID.Algorithm,
				CoderPropID.NumFastBytes,
				CoderPropID.MatchFinder,
				CoderPropID.EndMarker
			};
			object[] properties = new object[8] { num, num2, num3, num4, num5, num6, text, false };
			Encoder encoder = new Encoder();
			encoder.SetCoderProperties(propIDs, properties);
			encoder.WriteCoderProperties(outStream);
			long length = inStream.Length;
			for (int i = 0; i < 8; i++)
			{
				outStream.WriteByte((byte)(length >> 8 * i));
			}
			encoder.Code(inStream, outStream, -1L, -1L, null);
		}

		public static void Unzip(Stream inStream, Stream outStream)
		{
			byte[] array = new byte[5];
			if (inStream.Read(array, 0, 5) != 5)
			{
				throw new Exception("input .lzma is too short");
			}
			Decoder decoder = new Decoder();
			decoder.SetDecoderProperties(array);
			long num = 0L;
			for (int i = 0; i < 8; i++)
			{
				int num2 = inStream.ReadByte();
				if (num2 < 0)
				{
					throw new Exception("Can't Read 1");
				}
				num |= (long)((ulong)(byte)num2 << 8 * i);
			}
			long inSize = inStream.Length - inStream.Position;
			decoder.Code(inStream, outStream, inSize, num, null);
		}

		public static void Zip(string OriPath, string destPath)
		{
			FileStream fileStream = new FileStream(OriPath, FileMode.Open, FileAccess.Read, FileShare.Read);
			FileStream fileStream2 = new FileStream(destPath, FileMode.Create, FileAccess.Write, FileShare.Write);
			Zip(fileStream, fileStream2);
			fileStream.Close();
			fileStream2.Close();
		}

		public static void Unzip(string OriPath, string destPath)
		{
			FileStream fileStream = new FileStream(OriPath, FileMode.Open);
			FileStream fileStream2 = new FileStream(destPath, FileMode.Create);
			Unzip(fileStream, fileStream2);
			fileStream.Close();
			fileStream2.Close();
		}

		public static byte[] Zip(byte[] bytes)
		{
			MemoryStream memoryStream = new MemoryStream(bytes);
			MemoryStream memoryStream2 = new MemoryStream();
			Zip(memoryStream, memoryStream2);
			byte[] result = memoryStream2.ToArray();
			memoryStream.Close();
			memoryStream2.Close();
			return result;
		}

		public static byte[] Unzip(byte[] bytes)
		{
			MemoryStream memoryStream = new MemoryStream(bytes);
			MemoryStream memoryStream2 = new MemoryStream();
			Unzip(memoryStream, memoryStream2);
			byte[] result = memoryStream2.ToArray();
			memoryStream.Close();
			memoryStream2.Close();
			return result;
		}
	}
}
