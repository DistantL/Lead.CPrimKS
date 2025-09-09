using System.Collections;
using System.Text;

namespace Sunny.UI
{
	public class Crc32
	{
		private readonly uint _poly;

		private uint[] tab;

		public Crc32()
			: this(79764919u)
		{
		}

		public Crc32(uint poly)
		{
			_poly = poly;
		}

		private void Init()
		{
			if (tab != null)
			{
				return;
			}
			tab = new uint[256];
			for (uint num = 0u; num < 256; num++)
			{
				uint num2 = num;
				for (int i = 0; i < 8; i++)
				{
					num2 = (((num2 & (true ? 1u : 0u)) != 0) ? ((num2 >> 1) ^ _poly) : (num2 >> 1));
				}
				tab[num] = num2;
			}
		}

		public uint ComputeHash(string text)
		{
			return ComputeHash(Encoding.UTF8.GetBytes(text));
		}

		public uint ComputeHash(byte[] data)
		{
			return ComputeHash(data, 0, data.Length);
		}

		public uint ComputeHash(byte[] data, int start, int length)
		{
			return this.ComputeHash<byte[]>(data, start, length);
		}

		public uint ComputeHash<T>(T data, int start, int length) where T : IList
		{
			Init();
			uint num = uint.MaxValue;
			for (int i = 0; i < length; i++)
			{
				byte b = (byte)data[i + start];
				num = (num << 8) ^ tab[b ^ (num >> 24)];
			}
			return ~num;
		}
	}
}
