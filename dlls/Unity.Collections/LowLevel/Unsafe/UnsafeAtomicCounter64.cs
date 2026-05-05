using System;
using System.Threading;
using Unity.Mathematics;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000F1 RID: 241
	[BurstCompatible]
	public struct UnsafeAtomicCounter64
	{
		// Token: 0x0600096C RID: 2412 RVA: 0x0001D8EC File Offset: 0x0001BAEC
		public unsafe UnsafeAtomicCounter64(void* ptr)
		{
			this.Counter = (long*)ptr;
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x0001D8F5 File Offset: 0x0001BAF5
		public unsafe void Reset(long value = 0L)
		{
			*this.Counter = value;
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x0001D8FF File Offset: 0x0001BAFF
		public unsafe long Add(long value)
		{
			return Interlocked.Add(UnsafeUtility.AsRef<long>((void*)this.Counter), value) - value;
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x0001D914 File Offset: 0x0001BB14
		public long Sub(long value)
		{
			return this.Add(-value);
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x0001D920 File Offset: 0x0001BB20
		public unsafe long AddSat(long value, long max = 9223372036854775807L)
		{
			long num = *this.Counter;
			long num2;
			do
			{
				num2 = num;
				num = ((num >= max) ? max : math.min(max, num + value));
				num = Interlocked.CompareExchange(UnsafeUtility.AsRef<long>((void*)this.Counter), num, num2);
			}
			while (num2 != num && num2 != max);
			return num2;
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x0001D964 File Offset: 0x0001BB64
		public unsafe long SubSat(long value, long min = -9223372036854775808L)
		{
			long num = *this.Counter;
			long num2;
			do
			{
				num2 = num;
				num = ((num <= min) ? min : math.max(min, num - value));
				num = Interlocked.CompareExchange(UnsafeUtility.AsRef<long>((void*)this.Counter), num, num2);
			}
			while (num2 != num && num2 != min);
			return num2;
		}

		// Token: 0x04000349 RID: 841
		public unsafe long* Counter;
	}
}
