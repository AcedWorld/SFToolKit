using System;
using Unity.Burst;
using Unity.Jobs;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x02000107 RID: 263
	[BurstCompile]
	internal struct UnsafeDisposeJob : IJob
	{
		// Token: 0x06000A16 RID: 2582 RVA: 0x00020888 File Offset: 0x0001EA88
		public void Execute()
		{
			AllocatorManager.Free(this.Allocator, this.Ptr);
		}

		// Token: 0x04000375 RID: 885
		[NativeDisableUnsafePtrRestriction]
		public unsafe void* Ptr;

		// Token: 0x04000376 RID: 886
		public AllocatorManager.AllocatorHandle Allocator;
	}
}
