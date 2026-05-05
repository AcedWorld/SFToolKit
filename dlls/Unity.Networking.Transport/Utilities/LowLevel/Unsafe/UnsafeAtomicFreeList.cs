using System;
using System.Threading;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Networking.Transport.Utilities.LowLevel.Unsafe
{
	// Token: 0x020000CA RID: 202
	internal struct UnsafeAtomicFreeList : IDisposable
	{
		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060002FF RID: 767 RVA: 0x0001114E File Offset: 0x0000F34E
		public int Capacity
		{
			get
			{
				return this.m_Length;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000300 RID: 768 RVA: 0x00011156 File Offset: 0x0000F356
		public unsafe int InUse
		{
			get
			{
				return *this.m_Buffer - this.m_Buffer[1];
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000301 RID: 769 RVA: 0x00011169 File Offset: 0x0000F369
		public bool IsCreated
		{
			get
			{
				return this.m_Buffer != null;
			}
		}

		// Token: 0x06000302 RID: 770 RVA: 0x00011178 File Offset: 0x0000F378
		public unsafe UnsafeAtomicFreeList(int capacity, Allocator allocator)
		{
			this.m_Allocator = allocator;
			this.m_Length = capacity;
			int num = UnsafeUtility.SizeOf<int>() * (capacity + 2);
			this.m_Buffer = (int*)UnsafeUtility.Malloc((long)num, UnsafeUtility.AlignOf<int>(), allocator);
			UnsafeUtility.MemClear((void*)this.m_Buffer, (long)num);
		}

		// Token: 0x06000303 RID: 771 RVA: 0x000111BD File Offset: 0x0000F3BD
		public unsafe void Dispose()
		{
			if (this.IsCreated)
			{
				UnsafeUtility.Free((void*)this.m_Buffer, this.m_Allocator);
			}
		}

		// Token: 0x06000304 RID: 772 RVA: 0x000111D8 File Offset: 0x0000F3D8
		public unsafe void Push(int item)
		{
			int* buffer = this.m_Buffer;
			int num = Interlocked.Increment(ref buffer[1]) - 1;
			while (Interlocked.CompareExchange(ref buffer[num + 2], item + 1, 0) != 0)
			{
			}
		}

		// Token: 0x06000305 RID: 773 RVA: 0x0001120C File Offset: 0x0000F40C
		public unsafe int Pop()
		{
			int* buffer = this.m_Buffer;
			int num = buffer[1] - 1;
			while (num >= 0 && Interlocked.CompareExchange(ref buffer[1], num, num + 1) != num + 1)
			{
				num = buffer[1] - 1;
			}
			if (num >= 0)
			{
				int num2;
				for (num2 = 0; num2 == 0; num2 = Interlocked.Exchange(ref buffer[2 + num], 0))
				{
				}
				return num2 - 1;
			}
			num = Interlocked.Increment(ref *buffer) - 1;
			if (num >= this.Capacity)
			{
				Interlocked.Decrement(ref *buffer);
				return -1;
			}
			return num;
		}

		// Token: 0x040002BA RID: 698
		[NativeDisableUnsafePtrRestriction]
		private unsafe int* m_Buffer;

		// Token: 0x040002BB RID: 699
		private int m_Length;

		// Token: 0x040002BC RID: 700
		private Allocator m_Allocator;
	}
}
