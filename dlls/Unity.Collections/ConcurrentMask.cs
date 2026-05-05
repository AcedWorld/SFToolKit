using System;
using System.Threading;
using Unity.Mathematics;

namespace Unity.Collections
{
	// Token: 0x0200002D RID: 45
	internal class ConcurrentMask
	{
		// Token: 0x060000DF RID: 223 RVA: 0x00003E28 File Offset: 0x00002028
		internal static void longestConsecutiveOnes(long value, out int offset, out int count)
		{
			count = 0;
			long num = value;
			while (num != 0L)
			{
				value = num;
				num = (value & (long)((ulong)value >> 1));
				count++;
			}
			offset = math.tzcnt(value);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00003E56 File Offset: 0x00002056
		internal static bool foundAtLeastThisManyConsecutiveOnes(long value, int minimum, out int offset, out int count)
		{
			if (minimum == 1)
			{
				offset = math.tzcnt(value);
				count = 1;
				return offset != 64;
			}
			ConcurrentMask.longestConsecutiveOnes(value, out offset, out count);
			return count >= minimum;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00003E81 File Offset: 0x00002081
		internal static bool foundAtLeastThisManyConsecutiveZeroes(long value, int minimum, out int offset, out int count)
		{
			return ConcurrentMask.foundAtLeastThisManyConsecutiveOnes(~value, minimum, out offset, out count);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00003E8D File Offset: 0x0000208D
		internal static bool Succeeded(int error)
		{
			return error >= 0;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00003E96 File Offset: 0x00002096
		internal static long MakeMask(int offset, int bits)
		{
			return (long)((long)(ulong.MaxValue >> 64 - bits) << offset);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00003EA8 File Offset: 0x000020A8
		internal static int TryAllocate(ref long l, int offset, int bits)
		{
			long num = ConcurrentMask.MakeMask(offset, bits);
			long num2 = Interlocked.Read(ref l);
			while ((num2 & num) == 0L)
			{
				long value = num2 | num;
				long num3 = num2;
				num2 = Interlocked.CompareExchange(ref l, value, num3);
				if (num2 == num3)
				{
					return math.countbits(num2);
				}
			}
			return -2;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00003EE8 File Offset: 0x000020E8
		internal static int TryFree(ref long l, int offset, int bits)
		{
			long num = ConcurrentMask.MakeMask(offset, bits);
			long num2 = Interlocked.Read(ref l);
			while ((num2 & num) == num)
			{
				long num3 = num2 & ~num;
				long num4 = num2;
				num2 = Interlocked.CompareExchange(ref l, num3, num4);
				if (num2 == num4)
				{
					return math.countbits(num3);
				}
			}
			return -1;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00003F28 File Offset: 0x00002128
		internal static int TryAllocate(ref long l, out int offset, int bits)
		{
			long num = Interlocked.Read(ref l);
			int num2;
			while (ConcurrentMask.foundAtLeastThisManyConsecutiveZeroes(num, bits, out offset, out num2))
			{
				long num3 = ConcurrentMask.MakeMask(offset, bits);
				long value = num | num3;
				long num4 = num;
				num = Interlocked.CompareExchange(ref l, value, num4);
				if (num == num4)
				{
					return math.countbits(num);
				}
			}
			return -2;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00003F70 File Offset: 0x00002170
		internal static int TryAllocate<T>(ref T t, int offset, int bits) where T : IIndexable<long>
		{
			int index = offset >> 6;
			int offset2 = offset & 63;
			return ConcurrentMask.TryAllocate(t.ElementAt(index), offset2, bits);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00003F9C File Offset: 0x0000219C
		internal static int TryFree<T>(ref T t, int offset, int bits) where T : IIndexable<long>
		{
			int index = offset >> 6;
			int offset2 = offset & 63;
			return ConcurrentMask.TryFree(t.ElementAt(index), offset2, bits);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00003FC8 File Offset: 0x000021C8
		internal static int TryAllocate<T>(ref T t, out int offset, int begin, int end, int bits) where T : IIndexable<long>
		{
			for (int i = begin; i < end; i++)
			{
				int num2;
				int num = ConcurrentMask.TryAllocate(t.ElementAt(i), out num2, bits);
				if (ConcurrentMask.Succeeded(num))
				{
					offset = i * 64 + num2;
					return num;
				}
			}
			offset = -1;
			return -2;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000400F File Offset: 0x0000220F
		internal static int TryAllocate<T>(ref T t, out int offset, int bits) where T : IIndexable<long>
		{
			return ConcurrentMask.TryAllocate<T>(ref t, out offset, 0, t.Length, bits);
		}

		// Token: 0x04000091 RID: 145
		internal const int ErrorFailedToFree = -1;

		// Token: 0x04000092 RID: 146
		internal const int ErrorFailedToAllocate = -2;

		// Token: 0x04000093 RID: 147
		internal const int EmptyBeforeAllocation = 0;

		// Token: 0x04000094 RID: 148
		internal const int EmptyAfterFree = 0;
	}
}
