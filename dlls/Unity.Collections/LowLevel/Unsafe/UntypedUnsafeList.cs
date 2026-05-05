using System;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x02000108 RID: 264
	internal struct UntypedUnsafeList
	{
		// Token: 0x04000377 RID: 887
		[NativeDisableUnsafePtrRestriction]
		public unsafe void* Ptr;

		// Token: 0x04000378 RID: 888
		public int m_length;

		// Token: 0x04000379 RID: 889
		public int m_capacity;

		// Token: 0x0400037A RID: 890
		public AllocatorManager.AllocatorHandle Allocator;

		// Token: 0x0400037B RID: 891
		internal int obsolete_length;

		// Token: 0x0400037C RID: 892
		internal int obsolete_capacity;
	}
}
