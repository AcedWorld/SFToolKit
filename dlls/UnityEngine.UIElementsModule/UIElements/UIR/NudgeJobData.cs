using System;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000446 RID: 1094
	internal struct NudgeJobData
	{
		// Token: 0x04000F3C RID: 3900
		public IntPtr src;

		// Token: 0x04000F3D RID: 3901
		public IntPtr dst;

		// Token: 0x04000F3E RID: 3902
		public int count;

		// Token: 0x04000F3F RID: 3903
		public IntPtr closingSrc;

		// Token: 0x04000F40 RID: 3904
		public IntPtr closingDst;

		// Token: 0x04000F41 RID: 3905
		public int closingCount;

		// Token: 0x04000F42 RID: 3906
		public Matrix4x4 transform;

		// Token: 0x04000F43 RID: 3907
		public int vertsBeforeUVDisplacement;

		// Token: 0x04000F44 RID: 3908
		public int vertsAfterUVDisplacement;
	}
}
