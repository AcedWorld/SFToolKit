using System;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000437 RID: 1079
	internal struct HeapStatistics
	{
		// Token: 0x04000ED6 RID: 3798
		public uint numAllocs;

		// Token: 0x04000ED7 RID: 3799
		public uint totalSize;

		// Token: 0x04000ED8 RID: 3800
		public uint allocatedSize;

		// Token: 0x04000ED9 RID: 3801
		public uint freeSize;

		// Token: 0x04000EDA RID: 3802
		public uint largestAvailableBlock;

		// Token: 0x04000EDB RID: 3803
		public uint availableBlocksCount;

		// Token: 0x04000EDC RID: 3804
		public uint blockCount;

		// Token: 0x04000EDD RID: 3805
		public uint highWatermark;

		// Token: 0x04000EDE RID: 3806
		public float fragmentation;

		// Token: 0x04000EDF RID: 3807
		public HeapStatistics[] subAllocators;
	}
}
