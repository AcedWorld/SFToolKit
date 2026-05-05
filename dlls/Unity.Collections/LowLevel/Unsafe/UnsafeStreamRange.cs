using System;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x0200011F RID: 287
	[BurstCompatible]
	internal struct UnsafeStreamRange
	{
		// Token: 0x040003AE RID: 942
		internal unsafe UnsafeStreamBlock* Block;

		// Token: 0x040003AF RID: 943
		internal int OffsetInFirstBlock;

		// Token: 0x040003B0 RID: 944
		internal int ElementCount;

		// Token: 0x040003B1 RID: 945
		internal int LastOffset;

		// Token: 0x040003B2 RID: 946
		internal int NumberOfBlocks;
	}
}
