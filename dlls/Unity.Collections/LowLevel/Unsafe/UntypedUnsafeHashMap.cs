using System;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x02000101 RID: 257
	public struct UntypedUnsafeHashMap
	{
		// Token: 0x0400036F RID: 879
		[NativeDisableUnsafePtrRestriction]
		private unsafe UnsafeHashMapData* m_Buffer;

		// Token: 0x04000370 RID: 880
		private AllocatorManager.AllocatorHandle m_AllocatorLabel;
	}
}
