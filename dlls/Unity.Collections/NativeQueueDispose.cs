using System;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Collections
{
	// Token: 0x020000AD RID: 173
	[NativeContainer]
	[BurstCompatible]
	internal struct NativeQueueDispose
	{
		// Token: 0x06000708 RID: 1800 RVA: 0x00016E58 File Offset: 0x00015058
		public void Dispose()
		{
			NativeQueueData.DeallocateQueue(this.m_Buffer, this.m_QueuePool, this.m_AllocatorLabel);
		}

		// Token: 0x04000298 RID: 664
		[NativeDisableUnsafePtrRestriction]
		internal unsafe NativeQueueData* m_Buffer;

		// Token: 0x04000299 RID: 665
		[NativeDisableUnsafePtrRestriction]
		internal unsafe NativeQueueBlockPoolData* m_QueuePool;

		// Token: 0x0400029A RID: 666
		internal AllocatorManager.AllocatorHandle m_AllocatorLabel;
	}
}
