using System;
using Unity.Mathematics;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x02000119 RID: 281
	[BurstCompatible]
	internal struct RingControl
	{
		// Token: 0x06000AB8 RID: 2744 RVA: 0x00021CEC File Offset: 0x0001FEEC
		internal RingControl(int capacity)
		{
			this.Capacity = capacity;
			this.Current = 0;
			this.Write = 0;
			this.Read = 0;
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x00021D0A File Offset: 0x0001FF0A
		internal void Reset()
		{
			this.Current = 0;
			this.Write = 0;
			this.Read = 0;
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x00021D24 File Offset: 0x0001FF24
		internal int Distance(int from, int to)
		{
			int num = to - from;
			if (num >= 0)
			{
				return num;
			}
			return this.Capacity - math.abs(num);
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x00021D48 File Offset: 0x0001FF48
		internal int Available()
		{
			return this.Distance(this.Read, this.Current);
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x00021D5C File Offset: 0x0001FF5C
		internal int Reserve(int count)
		{
			int num = this.Distance(this.Write, this.Read) - 1;
			int num2 = (num < 0) ? (this.Capacity - 1) : num;
			count = ((math.abs(count) - num2 < 0) ? count : num2);
			this.Write = (this.Write + count) % this.Capacity;
			return count;
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x00021DB8 File Offset: 0x0001FFB8
		internal int Commit(int count)
		{
			int num = this.Distance(this.Current, this.Write);
			count = ((math.abs(count) - num < 0) ? count : num);
			this.Current = (this.Current + count) % this.Capacity;
			return count;
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x00021E00 File Offset: 0x00020000
		internal int Consume(int count)
		{
			int num = this.Distance(this.Read, this.Current);
			count = ((math.abs(count) - num < 0) ? count : num);
			this.Read = (this.Read + count) % this.Capacity;
			return count;
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000ABF RID: 2751 RVA: 0x00021E47 File Offset: 0x00020047
		internal int Length
		{
			get
			{
				return this.Distance(this.Read, this.Write);
			}
		}

		// Token: 0x040003A0 RID: 928
		internal readonly int Capacity;

		// Token: 0x040003A1 RID: 929
		internal int Current;

		// Token: 0x040003A2 RID: 930
		internal int Write;

		// Token: 0x040003A3 RID: 931
		internal int Read;
	}
}
