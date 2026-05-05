using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000133 RID: 307
	[VolumeComponentMenuForRenderPipeline("Post-processing/Film Grain", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class FilmGrain : VolumeComponent, IPostProcessComponent
	{
		// Token: 0x06000AB4 RID: 2740 RVA: 0x0005A29F File Offset: 0x0005849F
		public bool IsActive()
		{
			return this.intensity.value > 0f && (this.type.value != FilmGrainLookup.Custom || this.texture.value != null);
		}

		// Token: 0x04000BA5 RID: 2981
		[Tooltip("Specifies the type of grain to use. Select a preset or select \"Custom\" to provide your own Texture.")]
		public FilmGrainLookupParameter type = new FilmGrainLookupParameter(FilmGrainLookup.Thin1, false);

		// Token: 0x04000BA6 RID: 2982
		[Tooltip("Use the slider to set the strength of the Film Grain effect.")]
		public ClampedFloatParameter intensity = new ClampedFloatParameter(0f, 0f, 1f, false);

		// Token: 0x04000BA7 RID: 2983
		[Tooltip("Controls the noisiness response curve. The higher you set this value, the less noise there is in brighter areas.")]
		public ClampedFloatParameter response = new ClampedFloatParameter(0.8f, 0f, 1f, false);

		// Token: 0x04000BA8 RID: 2984
		[Tooltip("Specifies a tileable Texture to use for the grain. The neutral value for this Texture is 0.5 which means that HDRP does not apply grain at this value.")]
		public Texture2DParameter texture = new Texture2DParameter(null, false);
	}
}
