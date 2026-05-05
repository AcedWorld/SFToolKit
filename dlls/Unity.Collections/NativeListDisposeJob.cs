using System;
using Unity.Burst;
using Unity.Jobs;

namespace Unity.Collections
{
	// Token: 0x0200009E RID: 158
	[BurstCompile]
	[BurstCompatible]
	internal struct NativeListDisposeJob : IJob
	{
		// Token: 0x060006B5 RID: 1717 RVA: 0x00016192 File Offset: 0x00014392
		public void Execute()
		{
			this.Data.Dispose();
		}

		// Token: 0x04000277 RID: 631
		internal NativeListDispose Data;
	}
}
