using System;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Collections
{
	// Token: 0x0200009D RID: 157
	[NativeContainer]
	[BurstCompatible]
	internal struct NativeListDispose
	{
		// Token: 0x060006B4 RID: 1716 RVA: 0x00016178 File Offset: 0x00014378
		public unsafe void Dispose()
		{
			UnsafeList<int>* listData = (UnsafeList<int>*)this.m_ListData;
			UnsafeList<int>.Destroy(listData);
		}

		// Token: 0x04000276 RID: 630
		[NativeDisableUnsafePtrRestriction]
		public unsafe UntypedUnsafeList* m_ListData;
	}
}
