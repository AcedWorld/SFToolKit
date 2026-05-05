using System;
using System.Runtime.CompilerServices;

namespace Unity.Netcode
{
	// Token: 0x020000F7 RID: 247
	public static class BitCounter
	{
		// Token: 0x06000626 RID: 1574 RVA: 0x0001BC68 File Offset: 0x00019E68
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetUsedByteCount(uint value)
		{
			value |= value >> 1;
			value |= value >> 2;
			value |= value >> 4;
			value |= value >> 8;
			value |= value >> 16;
			value &= ~(value >> 1);
			return BitCounter.k_DeBruijnTableBytes32[(int)(value * 116069625U >> 27)];
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x0001BCA8 File Offset: 0x00019EA8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetUsedByteCount(ulong value)
		{
			value |= value >> 1;
			value |= value >> 2;
			value |= value >> 4;
			value |= value >> 8;
			value |= value >> 16;
			value |= value >> 32;
			value &= ~(value >> 1);
			return BitCounter.k_DeBruijnTableBytes64[(int)(checked((IntPtr)(unchecked(value * 251784493209109903UL) >> 58)))];
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x0001BCFE File Offset: 0x00019EFE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetUsedBitCount(uint value)
		{
			value |= value >> 1;
			value |= value >> 2;
			value |= value >> 4;
			value |= value >> 8;
			value |= value >> 16;
			value &= ~(value >> 1);
			return BitCounter.k_DeBruijnTableBits32[(int)(value * 116069625U >> 27)];
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x0001BD3C File Offset: 0x00019F3C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetUsedBitCount(ulong value)
		{
			value |= value >> 1;
			value |= value >> 2;
			value |= value >> 4;
			value |= value >> 8;
			value |= value >> 16;
			value |= value >> 32;
			value &= ~(value >> 1);
			return BitCounter.k_DeBruijnTableBits64[(int)(checked((IntPtr)(unchecked(value * 251784493209109903UL) >> 58)))];
		}

		// Token: 0x040002FD RID: 765
		private const ulong k_DeBruijnMagic64 = 251784493209109903UL;

		// Token: 0x040002FE RID: 766
		private const uint k_DeBruijnMagic32 = 116069625U;

		// Token: 0x040002FF RID: 767
		private static readonly int[] k_DeBruijnTableBytes64 = new int[]
		{
			1,
			1,
			3,
			1,
			3,
			7,
			1,
			8,
			6,
			3,
			3,
			7,
			4,
			1,
			5,
			8,
			2,
			7,
			3,
			4,
			4,
			3,
			7,
			6,
			7,
			4,
			5,
			1,
			6,
			5,
			8,
			2,
			8,
			3,
			7,
			8,
			6,
			3,
			4,
			5,
			2,
			4,
			4,
			6,
			7,
			5,
			6,
			1,
			8,
			7,
			6,
			4,
			2,
			5,
			5,
			1,
			8,
			6,
			2,
			5,
			8,
			2,
			2,
			2
		};

		// Token: 0x04000300 RID: 768
		private static readonly int[] k_DeBruijnTableBytes32 = new int[]
		{
			1,
			1,
			3,
			1,
			4,
			3,
			1,
			3,
			4,
			3,
			3,
			2,
			2,
			1,
			1,
			3,
			4,
			2,
			4,
			3,
			3,
			2,
			2,
			1,
			2,
			4,
			2,
			1,
			4,
			2,
			4,
			4
		};

		// Token: 0x04000301 RID: 769
		private static readonly int[] k_DeBruijnTableBits64 = new int[]
		{
			1,
			2,
			18,
			3,
			19,
			51,
			4,
			58,
			48,
			20,
			23,
			52,
			30,
			5,
			34,
			59,
			16,
			49,
			21,
			28,
			26,
			24,
			53,
			42,
			55,
			31,
			39,
			6,
			44,
			35,
			60,
			9,
			64,
			17,
			50,
			57,
			47,
			22,
			29,
			33,
			15,
			27,
			25,
			41,
			54,
			38,
			43,
			8,
			63,
			56,
			46,
			32,
			14,
			40,
			37,
			7,
			62,
			45,
			13,
			36,
			61,
			12,
			11,
			10
		};

		// Token: 0x04000302 RID: 770
		private static readonly int[] k_DeBruijnTableBits32 = new int[]
		{
			1,
			2,
			17,
			3,
			30,
			18,
			4,
			23,
			31,
			21,
			19,
			12,
			14,
			5,
			8,
			24,
			32,
			16,
			29,
			22,
			20,
			11,
			13,
			7,
			15,
			28,
			10,
			6,
			27,
			9,
			26,
			25
		};
	}
}
