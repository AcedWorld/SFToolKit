using System;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x0200042C RID: 1068
	internal class MeshHandle : LinkedPoolItem<MeshHandle>
	{
		// Token: 0x04000E7C RID: 3708
		internal Alloc allocVerts;

		// Token: 0x04000E7D RID: 3709
		internal Alloc allocIndices;

		// Token: 0x04000E7E RID: 3710
		internal uint triangleCount;

		// Token: 0x04000E7F RID: 3711
		internal Page allocPage;

		// Token: 0x04000E80 RID: 3712
		internal uint allocTime;

		// Token: 0x04000E81 RID: 3713
		internal uint updateAllocID;
	}
}
