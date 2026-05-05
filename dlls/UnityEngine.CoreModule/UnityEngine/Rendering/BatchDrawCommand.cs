using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200043C RID: 1084
	public struct BatchDrawCommand
	{
		// Token: 0x04000D56 RID: 3414
		public uint visibleOffset;

		// Token: 0x04000D57 RID: 3415
		public uint visibleCount;

		// Token: 0x04000D58 RID: 3416
		public BatchID batchID;

		// Token: 0x04000D59 RID: 3417
		public BatchMaterialID materialID;

		// Token: 0x04000D5A RID: 3418
		public BatchMeshID meshID;

		// Token: 0x04000D5B RID: 3419
		public ushort submeshIndex;

		// Token: 0x04000D5C RID: 3420
		public ushort splitVisibilityMask;

		// Token: 0x04000D5D RID: 3421
		public BatchDrawCommandFlags flags;

		// Token: 0x04000D5E RID: 3422
		public int sortingPosition;
	}
}
