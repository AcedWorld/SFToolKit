using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000214 RID: 532
	public abstract class VolumeComponentWithQuality : VolumeComponent
	{
		// Token: 0x06000FB5 RID: 4021 RVA: 0x0007A024 File Offset: 0x00078224
		internal static GlobalPostProcessingQualitySettings GetPostProcessingQualitySettings()
		{
			HDRenderPipeline hdrenderPipeline = (HDRenderPipeline)RenderPipelineManager.currentPipeline;
			if (hdrenderPipeline != null)
			{
				return hdrenderPipeline.currentPlatformRenderPipelineSettings.postProcessQualitySettings;
			}
			return null;
		}

		// Token: 0x06000FB6 RID: 4022 RVA: 0x0007A04C File Offset: 0x0007824C
		internal static GlobalLightingQualitySettings GetLightingQualitySettings()
		{
			HDRenderPipeline hdrenderPipeline = (HDRenderPipeline)RenderPipelineManager.currentPipeline;
			if (hdrenderPipeline != null)
			{
				return hdrenderPipeline.currentPlatformRenderPipelineSettings.lightingQualitySettings;
			}
			return null;
		}

		// Token: 0x06000FB7 RID: 4023 RVA: 0x0007A074 File Offset: 0x00078274
		protected bool UsesQualitySettings()
		{
			return !this.quality.levelAndOverride.Item2 && (HDRenderPipeline)RenderPipelineManager.currentPipeline != null;
		}

		// Token: 0x0400183F RID: 6207
		[Tooltip("Specifies the quality level to be used for performance relevant parameters.")]
		public ScalableSettingLevelParameter quality = new ScalableSettingLevelParameter(1, false, false);
	}
}
