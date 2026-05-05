using System;

namespace Unity.Netcode
{
	// Token: 0x020000F6 RID: 246
	public static class Arithmetic
	{
		// Token: 0x0600061A RID: 1562 RVA: 0x0001BB73 File Offset: 0x00019D73
		internal static ulong CeilingExact(ulong u1, ulong u2)
		{
			return (u1 + u2 - 1UL) / u2;
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x0001BB7D File Offset: 0x00019D7D
		internal static long CeilingExact(long u1, long u2)
		{
			return (u1 + u2 - 1L) / u2;
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x0001BB87 File Offset: 0x00019D87
		internal static uint CeilingExact(uint u1, uint u2)
		{
			return (u1 + u2 - 1U) / u2;
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x0001BB90 File Offset: 0x00019D90
		internal static int CeilingExact(int u1, int u2)
		{
			return (u1 + u2 - 1) / u2;
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x0001BB99 File Offset: 0x00019D99
		internal static ushort CeilingExact(ushort u1, ushort u2)
		{
			return (u1 + u2 - 1) / u2;
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x0001BBA3 File Offset: 0x00019DA3
		internal static short CeilingExact(short u1, short u2)
		{
			return (u1 + u2 - 1) / u2;
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x0001BBAD File Offset: 0x00019DAD
		internal static byte CeilingExact(byte u1, byte u2)
		{
			return (u1 + u2 - 1) / u2;
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x0001BBB7 File Offset: 0x00019DB7
		internal static sbyte CeilingExact(sbyte u1, sbyte u2)
		{
			return (u1 + u2 - 1) / u2;
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x0001BBC1 File Offset: 0x00019DC1
		public static ulong ZigZagEncode(long value)
		{
			return (ulong)(value >> 63 ^ value << 1);
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x0001BBCB File Offset: 0x00019DCB
		public static long ZigZagDecode(ulong value)
		{
			return (long)((value >> 1 & 9223372036854775807UL) ^ value << 63 >> 63);
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x0001BBE4 File Offset: 0x00019DE4
		public static int VarIntSize(ulong value)
		{
			if (value <= 240UL)
			{
				return 1;
			}
			if (value <= 2287UL)
			{
				return 2;
			}
			if (value <= 67823UL)
			{
				return 3;
			}
			if (value <= 16777215UL)
			{
				return 4;
			}
			if (value <= (ulong)-1)
			{
				return 5;
			}
			if (value <= 1099511627775UL)
			{
				return 6;
			}
			if (value <= 281474976710655UL)
			{
				return 7;
			}
			if (value > 72057594037927935UL)
			{
				return 9;
			}
			return 8;
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x0001BC50 File Offset: 0x00019E50
		internal static long Div8Ceil(ulong value)
		{
			return (long)((value >> 3) + ((value & 1UL) | (value >> 1 & 1UL) | (value >> 2 & 1UL)));
		}

		// Token: 0x040002F9 RID: 761
		internal const long SIGN_BIT_64 = -9223372036854775808L;

		// Token: 0x040002FA RID: 762
		internal const int SIGN_BIT_32 = -2147483648;

		// Token: 0x040002FB RID: 763
		internal const short SIGN_BIT_16 = -32768;

		// Token: 0x040002FC RID: 764
		internal const sbyte SIGN_BIT_8 = -128;
	}
}
