using System;
using Unity.Burst;
using Unity.Jobs;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000F8 RID: 248
	[BurstCompile]
	internal struct UnsafeHashMapDataDisposeJob : IJob
	{
		// Token: 0x0600099D RID: 2461 RVA: 0x0001EA0C File Offset: 0x0001CC0C
		public void Execute()
		{
			this.Data.Dispose();
		}

		// Token: 0x0400035F RID: 863
		internal UnsafeHashMapDataDispose Data;
	}
}
