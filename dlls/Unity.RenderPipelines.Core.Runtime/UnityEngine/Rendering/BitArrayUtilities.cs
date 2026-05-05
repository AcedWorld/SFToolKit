using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000CE RID: 206
	public static class BitArrayUtilities
	{
		// Token: 0x060006A5 RID: 1701 RVA: 0x00020246 File Offset: 0x0001E446
		public static bool Get8(uint index, byte data)
		{
			return ((int)data & 1 << (int)index) != 0;
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x00020253 File Offset: 0x0001E453
		public static bool Get16(uint index, ushort data)
		{
			return ((int)data & 1 << (int)index) != 0;
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x00020260 File Offset: 0x0001E460
		public static bool Get32(uint index, uint data)
		{
			return (data & 1U << (int)index) > 0U;
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x0002026D File Offset: 0x0001E46D
		public static bool Get64(uint index, ulong data)
		{
			return (data & 1UL << (int)index) > 0UL;
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x0002027C File Offset: 0x0001E47C
		public static bool Get128(uint index, ulong data1, ulong data2)
		{
			if (index >= 64U)
			{
				return (data2 & 1UL << (int)(index - 64U)) > 0UL;
			}
			return (data1 & 1UL << (int)index) > 0UL;
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x000202A4 File Offset: 0x0001E4A4
		public static bool Get256(uint index, ulong data1, ulong data2, ulong data3, ulong data4)
		{
			if (index >= 128U)
			{
				if (index >= 192U)
				{
					return (data4 & 1UL << (int)(index - 192U)) > 0UL;
				}
				return (data3 & 1UL << (int)(index - 128U)) > 0UL;
			}
			else
			{
				if (index >= 64U)
				{
					return (data2 & 1UL << (int)(index - 64U)) > 0UL;
				}
				return (data1 & 1UL << (int)index) > 0UL;
			}
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x0002030D File Offset: 0x0001E50D
		public static void Set8(uint index, ref byte data, bool value)
		{
			data = (byte)(value ? ((int)data | 1 << (int)index) : ((int)data & ~(1 << (int)index)));
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x0002032A File Offset: 0x0001E52A
		public static void Set16(uint index, ref ushort data, bool value)
		{
			data = (ushort)(value ? ((int)data | 1 << (int)index) : ((int)data & ~(1 << (int)index)));
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x00020347 File Offset: 0x0001E547
		public static void Set32(uint index, ref uint data, bool value)
		{
			data = (value ? (data | 1U << (int)index) : (data & ~(1U << (int)index)));
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x00020363 File Offset: 0x0001E563
		public static void Set64(uint index, ref ulong data, bool value)
		{
			data = (value ? (data | 1UL << (int)index) : (data & ~(1UL << (int)index)));
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x00020384 File Offset: 0x0001E584
		public static void Set128(uint index, ref ulong data1, ref ulong data2, bool value)
		{
			if (index < 64U)
			{
				data1 = (value ? (data1 | 1UL << (int)index) : (data1 & ~(1UL << (int)index)));
				return;
			}
			data2 = (value ? (data2 | 1UL << (int)(index - 64U)) : (data2 & ~(1UL << (int)(index - 64U))));
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x000203D8 File Offset: 0x0001E5D8
		public static void Set256(uint index, ref ulong data1, ref ulong data2, ref ulong data3, ref ulong data4, bool value)
		{
			if (index < 64U)
			{
				data1 = (value ? (data1 | 1UL << (int)index) : (data1 & ~(1UL << (int)index)));
				return;
			}
			if (index < 128U)
			{
				data2 = (value ? (data2 | 1UL << (int)(index - 64U)) : (data2 & ~(1UL << (int)(index - 64U))));
				return;
			}
			if (index < 192U)
			{
				data3 = (value ? (data3 | 1UL << (int)(index - 64U)) : (data3 & ~(1UL << (int)(index - 128U))));
				return;
			}
			data4 = (value ? (data4 | 1UL << (int)(index - 64U)) : (data4 & ~(1UL << (int)(index - 192U))));
		}
	}
}
