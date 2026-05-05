using System;
using Unity.Burst;
using Unity.Jobs;

namespace Unity.Collections
{
	// Token: 0x020000AE RID: 174
	[BurstCompile]
	internal struct NativeQueueDisposeJob : IJob
	{
		// Token: 0x06000709 RID: 1801 RVA: 0x00016E71 File Offset: 0x00015071
		public void Execute()
		{
			this.Data.Dispose();
		}

		// Token: 0x0400029B RID: 667
		public NativeQueueDispose Data;
	}
}
