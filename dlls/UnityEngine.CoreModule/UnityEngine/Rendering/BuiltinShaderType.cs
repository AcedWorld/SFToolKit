using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000415 RID: 1045
	public enum BuiltinShaderType
	{
		// Token: 0x04000C84 RID: 3204
		DeferredShading,
		// Token: 0x04000C85 RID: 3205
		DeferredReflections,
		// Token: 0x04000C86 RID: 3206
		[Obsolete("LegacyDeferredLighting has been removed.", false)]
		LegacyDeferredLighting,
		// Token: 0x04000C87 RID: 3207
		ScreenSpaceShadows,
		// Token: 0x04000C88 RID: 3208
		DepthNormals,
		// Token: 0x04000C89 RID: 3209
		MotionVectors,
		// Token: 0x04000C8A RID: 3210
		LightHalo,
		// Token: 0x04000C8B RID: 3211
		LensFlare
	}
}
