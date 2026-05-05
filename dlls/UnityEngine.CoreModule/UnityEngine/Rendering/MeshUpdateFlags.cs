using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020003E9 RID: 1001
	[Flags]
	public enum MeshUpdateFlags
	{
		// Token: 0x04000B1B RID: 2843
		Default = 0,
		// Token: 0x04000B1C RID: 2844
		DontValidateIndices = 1,
		// Token: 0x04000B1D RID: 2845
		DontResetBoneBounds = 2,
		// Token: 0x04000B1E RID: 2846
		DontNotifyMeshUsers = 4,
		// Token: 0x04000B1F RID: 2847
		DontRecalculateBounds = 8
	}
}
