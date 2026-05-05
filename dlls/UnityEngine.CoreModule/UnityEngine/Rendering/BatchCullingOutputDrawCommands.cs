using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200043F RID: 1087
	public struct BatchCullingOutputDrawCommands
	{
		// Token: 0x04000D69 RID: 3433
		public unsafe BatchDrawCommand* drawCommands;

		// Token: 0x04000D6A RID: 3434
		public unsafe int* visibleInstances;

		// Token: 0x04000D6B RID: 3435
		public unsafe BatchDrawRange* drawRanges;

		// Token: 0x04000D6C RID: 3436
		public unsafe float* instanceSortingPositions;

		// Token: 0x04000D6D RID: 3437
		public unsafe int* drawCommandPickingInstanceIDs;

		// Token: 0x04000D6E RID: 3438
		public int drawCommandCount;

		// Token: 0x04000D6F RID: 3439
		public int visibleInstanceCount;

		// Token: 0x04000D70 RID: 3440
		public int drawRangeCount;

		// Token: 0x04000D71 RID: 3441
		public int instanceSortingPositionFloatCount;
	}
}
