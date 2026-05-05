using System;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000F7 RID: 247
	[NativeContainer]
	[BurstCompatible]
	internal struct UnsafeHashMapDataDispose
	{
		// Token: 0x0600099C RID: 2460 RVA: 0x0001E9F9 File Offset: 0x0001CBF9
		public void Dispose()
		{
			UnsafeHashMapData.DeallocateHashMap(this.m_Buffer, this.m_AllocatorLabel);
		}

		// Token: 0x0400035D RID: 861
		[NativeDisableUnsafePtrRestriction]
		internal unsafe UnsafeHashMapData* m_Buffer;

		// Token: 0x0400035E RID: 862
		internal AllocatorManager.AllocatorHandle m_AllocatorLabel;
	}
}
