using System;
using Unity.Burst;
using Unity.Jobs;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000FF RID: 255
	[BurstCompile]
	internal struct UnsafeHashMapDisposeJob : IJob
	{
		// Token: 0x060009D5 RID: 2517 RVA: 0x0001F7D2 File Offset: 0x0001D9D2
		public void Execute()
		{
			UnsafeHashMapData.DeallocateHashMap(this.Data, this.Allocator);
		}

		// Token: 0x0400036C RID: 876
		[NativeDisableUnsafePtrRestriction]
		public unsafe UnsafeHashMapData* Data;

		// Token: 0x0400036D RID: 877
		public AllocatorManager.AllocatorHandle Allocator;
	}
}
