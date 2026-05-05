using System;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000EB RID: 235
	[BurstCompatible]
	public static class NativeBitArrayUnsafeUtility
	{
		// Token: 0x06000942 RID: 2370 RVA: 0x0001D330 File Offset: 0x0001B530
		public unsafe static NativeBitArray ConvertExistingDataToNativeBitArray(void* ptr, int sizeInBytes, AllocatorManager.AllocatorHandle allocator)
		{
			return new NativeBitArray
			{
				m_BitArray = new UnsafeBitArray(ptr, sizeInBytes, allocator)
			};
		}
	}
}
