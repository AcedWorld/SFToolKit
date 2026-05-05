using System;
using Unity.Burst;
using Unity.Jobs;

namespace Unity.Collections
{
	// Token: 0x020000B2 RID: 178
	[BurstCompile]
	internal struct NativeReferenceDisposeJob : IJob
	{
		// Token: 0x0600071F RID: 1823 RVA: 0x000170B2 File Offset: 0x000152B2
		public void Execute()
		{
			this.Data.Dispose();
		}

		// Token: 0x040002A1 RID: 673
		internal NativeReferenceDispose Data;
	}
}
