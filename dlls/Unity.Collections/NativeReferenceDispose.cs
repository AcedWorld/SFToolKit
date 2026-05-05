using System;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Collections
{
	// Token: 0x020000B1 RID: 177
	[NativeContainer]
	internal struct NativeReferenceDispose
	{
		// Token: 0x0600071E RID: 1822 RVA: 0x0001709F File Offset: 0x0001529F
		public void Dispose()
		{
			Memory.Unmanaged.Free(this.m_Data, this.m_AllocatorLabel);
		}

		// Token: 0x0400029F RID: 671
		[NativeDisableUnsafePtrRestriction]
		internal unsafe void* m_Data;

		// Token: 0x040002A0 RID: 672
		internal AllocatorManager.AllocatorHandle m_AllocatorLabel;
	}
}
