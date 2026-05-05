using System;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000447 RID: 1095
	internal struct ConvertMeshJobData
	{
		// Token: 0x04000F45 RID: 3909
		public IntPtr vertSrc;

		// Token: 0x04000F46 RID: 3910
		public IntPtr vertDst;

		// Token: 0x04000F47 RID: 3911
		public int vertCount;

		// Token: 0x04000F48 RID: 3912
		public Matrix4x4 transform;

		// Token: 0x04000F49 RID: 3913
		public int transformUVs;

		// Token: 0x04000F4A RID: 3914
		public Color32 xformClipPages;

		// Token: 0x04000F4B RID: 3915
		public Color32 ids;

		// Token: 0x04000F4C RID: 3916
		public Color32 addFlags;

		// Token: 0x04000F4D RID: 3917
		public Color32 opacityPage;

		// Token: 0x04000F4E RID: 3918
		public Color32 textCoreSettingsPage;

		// Token: 0x04000F4F RID: 3919
		public int isText;

		// Token: 0x04000F50 RID: 3920
		public float textureId;

		// Token: 0x04000F51 RID: 3921
		public IntPtr indexSrc;

		// Token: 0x04000F52 RID: 3922
		public IntPtr indexDst;

		// Token: 0x04000F53 RID: 3923
		public int indexCount;

		// Token: 0x04000F54 RID: 3924
		public int indexOffset;

		// Token: 0x04000F55 RID: 3925
		public int flipIndices;
	}
}
