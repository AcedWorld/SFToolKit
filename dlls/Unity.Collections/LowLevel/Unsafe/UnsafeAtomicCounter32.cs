using System;
using System.Threading;
using Unity.Mathematics;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000F0 RID: 240
	[BurstCompatible]
	public struct UnsafeAtomicCounter32
	{
		// Token: 0x06000966 RID: 2406 RVA: 0x0001D82F File Offset: 0x0001BA2F
		public unsafe UnsafeAtomicCounter32(void* ptr)
		{
			this.Counter = (int*)ptr;
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x0001D838 File Offset: 0x0001BA38
		public unsafe void Reset(int value = 0)
		{
			*this.Counter = value;
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x0001D842 File Offset: 0x0001BA42
		public unsafe int Add(int value)
		{
			return Interlocked.Add(UnsafeUtility.AsRef<int>((void*)this.Counter), value) - value;
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x0001D857 File Offset: 0x0001BA57
		public int Sub(int value)
		{
			return this.Add(-value);
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x0001D864 File Offset: 0x0001BA64
		public unsafe int AddSat(int value, int max = 2147483647)
		{
			int num = *this.Counter;
			int num2;
			do
			{
				num2 = num;
				num = ((num >= max) ? max : math.min(max, num + value));
				num = Interlocked.CompareExchange(UnsafeUtility.AsRef<int>((void*)this.Counter), num, num2);
			}
			while (num2 != num && num2 != max);
			return num2;
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x0001D8A8 File Offset: 0x0001BAA8
		public unsafe int SubSat(int value, int min = -2147483648)
		{
			int num = *this.Counter;
			int num2;
			do
			{
				num2 = num;
				num = ((num <= min) ? min : math.max(min, num - value));
				num = Interlocked.CompareExchange(UnsafeUtility.AsRef<int>((void*)this.Counter), num, num2);
			}
			while (num2 != num && num2 != min);
			return num2;
		}

		// Token: 0x04000348 RID: 840
		public unsafe int* Counter;
	}
}
