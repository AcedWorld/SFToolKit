using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200013B RID: 315
	[VolumeComponentMenuForRenderPipeline("Post-processing/Shadows, Midtones, Highlights", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class ShadowsMidtonesHighlights : VolumeComponent, IPostProcessComponent
	{
		// Token: 0x06000AC2 RID: 2754 RVA: 0x0005A6C4 File Offset: 0x000588C4
		public bool IsActive()
		{
			Vector4 rhs = new Vector4(1f, 1f, 1f, 0f);
			return this.shadows != rhs || this.midtones != rhs || this.highlights != rhs;
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x0005A718 File Offset: 0x00058918
		private ShadowsMidtonesHighlights()
		{
			base.displayName = "Shadows, Midtones, Highlights";
		}

		// Token: 0x04000BC3 RID: 3011
		[Tooltip("Use this to control and apply a hue to the shadows.")]
		public Vector4Parameter shadows = new Vector4Parameter(new Vector4(1f, 1f, 1f, 0f), false);

		// Token: 0x04000BC4 RID: 3012
		[Tooltip("Use this to control and apply a hue to the midtones.")]
		public Vector4Parameter midtones = new Vector4Parameter(new Vector4(1f, 1f, 1f, 0f), false);

		// Token: 0x04000BC5 RID: 3013
		[Tooltip("Use this to control and apply a hue to the highlights.")]
		public Vector4Parameter highlights = new Vector4Parameter(new Vector4(1f, 1f, 1f, 0f), false);

		// Token: 0x04000BC6 RID: 3014
		[Header("Shadow Limits")]
		[Tooltip("Sets the start point of the transition between shadows and midtones.")]
		public MinFloatParameter shadowsStart = new MinFloatParameter(0f, 0f, false);

		// Token: 0x04000BC7 RID: 3015
		[Tooltip("Sets the end point of the transition between shadows and midtones.")]
		public MinFloatParameter shadowsEnd = new MinFloatParameter(0.3f, 0f, false);

		// Token: 0x04000BC8 RID: 3016
		[Header("Highlight Limits")]
		[Tooltip("Sets the start point of the transition between midtones and highlights.")]
		public MinFloatParameter highlightsStart = new MinFloatParameter(0.55f, 0f, false);

		// Token: 0x04000BC9 RID: 3017
		[Tooltip("Sets the end point of the transition between midtones and highlights.")]
		public MinFloatParameter highlightsEnd = new MinFloatParameter(1f, 0f, false);
	}
}
