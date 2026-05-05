using System;

namespace UnityEngine
{
	// Token: 0x0200017B RID: 379
	public enum RenderingPath
	{
		// Token: 0x040004A0 RID: 1184
		UsePlayerSettings = -1,
		// Token: 0x040004A1 RID: 1185
		VertexLit,
		// Token: 0x040004A2 RID: 1186
		Forward,
		// Token: 0x040004A3 RID: 1187
		[Obsolete("DeferredLighting has been removed. Use DeferredShading, Forward or HDRP/URP instead.", false)]
		DeferredLighting,
		// Token: 0x040004A4 RID: 1188
		DeferredShading
	}
}
