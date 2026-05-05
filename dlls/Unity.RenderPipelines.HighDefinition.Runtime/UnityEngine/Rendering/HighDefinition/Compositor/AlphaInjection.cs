using System;

namespace UnityEngine.Rendering.HighDefinition.Compositor
{
	// Token: 0x0200023D RID: 573
	[HideInInspector]
	[Serializable]
	internal sealed class AlphaInjection : CustomPostProcessVolumeComponent, IPostProcessComponent
	{
		// Token: 0x0600101B RID: 4123 RVA: 0x0007CA2B File Offset: 0x0007AC2B
		public bool IsActive()
		{
			return this.m_Material != null;
		}

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x0600101C RID: 4124 RVA: 0x0007CA39 File Offset: 0x0007AC39
		public override CustomPostProcessInjectionPoint injectionPoint
		{
			get
			{
				return CustomPostProcessInjectionPoint.BeforePostProcess;
			}
		}

		// Token: 0x0600101D RID: 4125 RVA: 0x0007CA3C File Offset: 0x0007AC3C
		public override void Setup()
		{
			if (!HDRenderPipeline.isReady)
			{
				return;
			}
			this.m_Material = CoreUtils.CreateEngineMaterial(HDRenderPipelineGlobalSettings.instance.renderPipelineResources.shaders.alphaInjectionPS);
		}

		// Token: 0x0600101E RID: 4126 RVA: 0x0007CA68 File Offset: 0x0007AC68
		public override void Render(CommandBuffer cmd, HDCamera camera, RTHandle source, RTHandle destination)
		{
			AdditionalCompositorData additionalCompositorData = null;
			camera.camera.gameObject.TryGetComponent<AdditionalCompositorData>(out additionalCompositorData);
			if (additionalCompositorData == null || additionalCompositorData.layerFilters == null)
			{
				HDUtils.BlitCameraTexture(cmd, source, destination, 0f, false);
				return;
			}
			int num = additionalCompositorData.layerFilters.FindIndex((CompositionFilter x) => x.filterType == CompositionFilter.FilterType.ALPHA_MASK);
			if (num < 0)
			{
				HDUtils.BlitCameraTexture(cmd, source, destination, 0f, false);
				return;
			}
			CompositionFilter compositionFilter = additionalCompositorData.layerFilters[num];
			this.m_Material.SetTexture(AlphaInjection.ShaderIDs.k_InputTexture, source);
			this.m_Material.SetTexture(AlphaInjection.ShaderIDs.k_AlphaTexture, compositionFilter.alphaMask);
			HDUtils.DrawFullScreen(cmd, this.m_Material, destination, null, 0);
		}

		// Token: 0x0600101F RID: 4127 RVA: 0x0007CB33 File Offset: 0x0007AD33
		public override void Cleanup()
		{
			CoreUtils.Destroy(this.m_Material);
		}

		// Token: 0x0400197B RID: 6523
		private Material m_Material;

		// Token: 0x02000451 RID: 1105
		internal class ShaderIDs
		{
			// Token: 0x040029CC RID: 10700
			public static readonly int k_AlphaTexture = Shader.PropertyToID("_AlphaTexture");

			// Token: 0x040029CD RID: 10701
			public static readonly int k_InputTexture = Shader.PropertyToID("_InputTexture");
		}
	}
}
