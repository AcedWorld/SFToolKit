using System;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x02000018 RID: 24
	internal static class RingBufferExtensions
	{
		// Token: 0x06000076 RID: 118 RVA: 0x00002B88 File Offset: 0x00000D88
		public static int Max(this RingBuffer<int> ring)
		{
			int num = 0;
			int length = ring.Length;
			for (int i = 0; i < length; i++)
			{
				num = Math.Max(num, ring[i]);
			}
			return num;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00002BBC File Offset: 0x00000DBC
		public static long Max(this RingBuffer<long> ring)
		{
			long num = 0L;
			int length = ring.Length;
			for (int i = 0; i < length; i++)
			{
				num = Math.Max(num, ring[i]);
			}
			return num;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00002BF0 File Offset: 0x00000DF0
		public static float Max(this RingBuffer<float> ring)
		{
			float num = 0f;
			int length = ring.Length;
			for (int i = 0; i < length; i++)
			{
				num = Math.Max(num, ring[i]);
			}
			return num;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00002C28 File Offset: 0x00000E28
		public static int Sum(this RingBuffer<int> ring)
		{
			int num = 0;
			int length = ring.Length;
			for (int i = 0; i < length; i++)
			{
				num += ring[i];
			}
			return num;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00002C58 File Offset: 0x00000E58
		public static long Sum(this RingBuffer<long> ring)
		{
			long num = 0L;
			int length = ring.Length;
			for (int i = 0; i < length; i++)
			{
				num += ring[i];
			}
			return num;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00002C88 File Offset: 0x00000E88
		public static float Sum(this RingBuffer<float> ring)
		{
			float num = 0f;
			int length = ring.Length;
			for (int i = 0; i < length; i++)
			{
				num += ring[i];
			}
			return num;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00002CBC File Offset: 0x00000EBC
		public static int SumLastN(this RingBuffer<int> ring, int n)
		{
			int num = 0;
			int length = ring.Length;
			for (int i = length - n; i < length; i++)
			{
				num += ring[i];
			}
			return num;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00002CEC File Offset: 0x00000EEC
		public static long SumLastN(this RingBuffer<long> ring, int n)
		{
			long num = 0L;
			int length = ring.Length;
			for (int i = length - n; i < length; i++)
			{
				num += ring[i];
			}
			return num;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00002D1C File Offset: 0x00000F1C
		public static float SumLastN(this RingBuffer<float> ring, int n)
		{
			float num = 0f;
			int length = ring.Length;
			for (int i = length - n; i < length; i++)
			{
				num += ring[i];
			}
			return num;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00002D4F File Offset: 0x00000F4F
		public static float Average(this RingBuffer<int> ring)
		{
			return (float)ring.Sum() / (float)ring.Length;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00002D60 File Offset: 0x00000F60
		public static float Average(this RingBuffer<long> ring)
		{
			return (float)ring.Sum() / (float)ring.Length;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00002D71 File Offset: 0x00000F71
		public static float Average(this RingBuffer<float> ring)
		{
			return ring.Sum() / (float)ring.Length;
		}
	}
}
