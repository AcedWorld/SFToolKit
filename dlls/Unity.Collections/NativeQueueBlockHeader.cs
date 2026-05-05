using System;

namespace Unity.Collections
{
	// Token: 0x020000A7 RID: 167
	internal struct NativeQueueBlockHeader
	{
		// Token: 0x04000285 RID: 645
		public unsafe NativeQueueBlockHeader* m_NextBlock;

		// Token: 0x04000286 RID: 646
		public int m_NumItems;
	}
}
