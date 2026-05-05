using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000401 RID: 1025
	public enum PassType
	{
		// Token: 0x04000C04 RID: 3076
		Normal,
		// Token: 0x04000C05 RID: 3077
		Vertex,
		// Token: 0x04000C06 RID: 3078
		VertexLM,
		// Token: 0x04000C07 RID: 3079
		[Obsolete("VertexLMRGBM PassType is obsolete. Please use VertexLM PassType together with DecodeLightmap shader function.")]
		VertexLMRGBM,
		// Token: 0x04000C08 RID: 3080
		ForwardBase,
		// Token: 0x04000C09 RID: 3081
		ForwardAdd,
		// Token: 0x04000C0A RID: 3082
		[Obsolete("Deferred Lighting was removed, so LightPrePassBase pass type is never used anymore.")]
		LightPrePassBase,
		// Token: 0x04000C0B RID: 3083
		[Obsolete("Deferred Lighting was removed, so LightPrePassFinal pass type is never used anymore.")]
		LightPrePassFinal,
		// Token: 0x04000C0C RID: 3084
		ShadowCaster,
		// Token: 0x04000C0D RID: 3085
		Deferred = 10,
		// Token: 0x04000C0E RID: 3086
		Meta,
		// Token: 0x04000C0F RID: 3087
		MotionVectors,
		// Token: 0x04000C10 RID: 3088
		ScriptableRenderPipeline,
		// Token: 0x04000C11 RID: 3089
		ScriptableRenderPipelineDefaultUnlit,
		// Token: 0x04000C12 RID: 3090
		GrabPass
	}
}
