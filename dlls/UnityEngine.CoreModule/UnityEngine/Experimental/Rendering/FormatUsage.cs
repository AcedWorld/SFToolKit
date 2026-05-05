using System;

namespace UnityEngine.Experimental.Rendering
{
	// Token: 0x020004DB RID: 1243
	public enum FormatUsage
	{
		// Token: 0x04001034 RID: 4148
		Sample,
		// Token: 0x04001035 RID: 4149
		Linear,
		// Token: 0x04001036 RID: 4150
		Sparse,
		// Token: 0x04001037 RID: 4151
		Render = 4,
		// Token: 0x04001038 RID: 4152
		Blend,
		// Token: 0x04001039 RID: 4153
		GetPixels,
		// Token: 0x0400103A RID: 4154
		SetPixels,
		// Token: 0x0400103B RID: 4155
		SetPixels32,
		// Token: 0x0400103C RID: 4156
		ReadPixels,
		// Token: 0x0400103D RID: 4157
		LoadStore,
		// Token: 0x0400103E RID: 4158
		MSAA2x,
		// Token: 0x0400103F RID: 4159
		MSAA4x,
		// Token: 0x04001040 RID: 4160
		MSAA8x,
		// Token: 0x04001041 RID: 4161
		StencilSampling = 16
	}
}
