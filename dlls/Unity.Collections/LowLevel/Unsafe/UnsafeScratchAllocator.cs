using System;
using System.Diagnostics;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x0200011C RID: 284
	[BurstCompatible]
	public struct UnsafeScratchAllocator
	{
		// Token: 0x06000AD0 RID: 2768 RVA: 0x000220DC File Offset: 0x000202DC
		public unsafe UnsafeScratchAllocator(void* ptr, int capacityInBytes)
		{
			this.m_Pointer = ptr;
			this.m_LengthInBytes = 0;
			this.m_CapacityInBytes = capacityInBytes;
		}

		// Token: 0x06000AD1 RID: 2769 RVA: 0x000220F3 File Offset: 0x000202F3
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckAllocationDoesNotExceedCapacity(ulong requestedSize)
		{
			if (requestedSize > (ulong)((long)this.m_CapacityInBytes))
			{
				throw new ArgumentException(string.Format("Cannot allocate more than provided size in UnsafeScratchAllocator. Requested: {0} Size: {1} Capacity: {2}", requestedSize, this.m_LengthInBytes, this.m_CapacityInBytes));
			}
		}

		// Token: 0x06000AD2 RID: 2770 RVA: 0x0002212C File Offset: 0x0002032C
		public unsafe void* Allocate(int sizeInBytes, int alignmentInBytes)
		{
			if (sizeInBytes == 0)
			{
				return null;
			}
			ulong num = (ulong)((long)(alignmentInBytes - 1));
			long value = (long)((IntPtr)this.m_Pointer) + (long)this.m_LengthInBytes + (long)num & (long)(~(long)num);
			long num2 = (long)((byte*)((void*)((IntPtr)value)) - (byte*)this.m_Pointer);
			num2 += (long)sizeInBytes;
			this.m_LengthInBytes = (int)num2;
			return (void*)((IntPtr)value);
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x0002218E File Offset: 0x0002038E
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe void* Allocate<T>(int count = 1) where T : struct
		{
			return this.Allocate(UnsafeUtility.SizeOf<T>() * count, UnsafeUtility.AlignOf<T>());
		}

		// Token: 0x040003A8 RID: 936
		private unsafe void* m_Pointer;

		// Token: 0x040003A9 RID: 937
		private int m_LengthInBytes;

		// Token: 0x040003AA RID: 938
		private readonly int m_CapacityInBytes;
	}
}
