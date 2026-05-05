using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000400 RID: 1024
	public enum BuiltinRenderTextureType
	{
		// Token: 0x04000BEC RID: 3052
		PropertyName = -4,
		// Token: 0x04000BED RID: 3053
		BufferPtr,
		// Token: 0x04000BEE RID: 3054
		RenderTexture,
		// Token: 0x04000BEF RID: 3055
		BindableTexture,
		// Token: 0x04000BF0 RID: 3056
		None,
		// Token: 0x04000BF1 RID: 3057
		CurrentActive,
		// Token: 0x04000BF2 RID: 3058
		CameraTarget,
		// Token: 0x04000BF3 RID: 3059
		Depth,
		// Token: 0x04000BF4 RID: 3060
		DepthNormals,
		// Token: 0x04000BF5 RID: 3061
		ResolvedDepth,
		// Token: 0x04000BF6 RID: 3062
		[Obsolete("Deferred Lighting has been removed, so PrepassNormalsSpec built-in render texture type is never used now.", false)]
		PrepassNormalsSpec = 7,
		// Token: 0x04000BF7 RID: 3063
		[Obsolete("Deferred Lighting has been removed, so PrepassLight built-in render texture type is never used now.", false)]
		PrepassLight,
		// Token: 0x04000BF8 RID: 3064
		[Obsolete("Deferred Lighting has been removed, so PrepassLightSpec built-in render texture type is never used now.", false)]
		PrepassLightSpec,
		// Token: 0x04000BF9 RID: 3065
		GBuffer0,
		// Token: 0x04000BFA RID: 3066
		GBuffer1,
		// Token: 0x04000BFB RID: 3067
		GBuffer2,
		// Token: 0x04000BFC RID: 3068
		GBuffer3,
		// Token: 0x04000BFD RID: 3069
		Reflections,
		// Token: 0x04000BFE RID: 3070
		MotionVectors,
		// Token: 0x04000BFF RID: 3071
		GBuffer4,
		// Token: 0x04000C00 RID: 3072
		GBuffer5,
		// Token: 0x04000C01 RID: 3073
		GBuffer6,
		// Token: 0x04000C02 RID: 3074
		GBuffer7
	}
}
