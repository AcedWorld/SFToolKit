using System;

namespace UnityEngine.Rendering.HighDefinition.Compositor
{
	// Token: 0x0200023E RID: 574
	[HideInInspector]
	[Serializable]
	internal sealed class ChromaKeying : CustomPostProcessVolumeComponent, IPostProcessComponent
	{
		// Token: 0x06001021 RID: 4129 RVA: 0x0007CB48 File Offset: 0x0007AD48
		public bool IsActive()
		{
			return this.m_Material != null;
		}

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06001022 RID: 4130 RVA: 0x0007CB56 File Offset: 0x0007AD56
		public override CustomPostProcessInjectionPoint injectionPoint
		{
			get
			{
				return CustomPostProcessInjectionPoint.BeforePostProcess;
			}
		}

		// Token: 0x06001023 RID: 4131 RVA: 0x0007CB59 File Offset: 0x0007AD59
		public override void Setup()
		{
			if (!HDRenderPipeline.isReady)
			{
				return;
			}
			this.m_Material = CoreUtils.CreateEngineMaterial(HDRenderPipelineGlobalSettings.instance.renderPipelineResources.shaders.chromaKeyingPS);
		}

		// Token: 0x06001024 RID: 4132 RVA: 0x0007CB84 File Offset: 0x0007AD84
		public override void Render(CommandBuffer cmd, HDCamera camera, RTHandle source, RTHandle destination)
		{
			AdditionalCompositorData additionalCompositorData = null;
			camera.camera.gameObject.TryGetComponent<AdditionalCompositorData>(out additionalCompositorData);
			if (!this.activate.value || additionalCompositorData == null || additionalCompositorData.layerFilters == null)
			{
				HDUtils.BlitCameraTexture(cmd, source, destination, 0f, false);
				return;
			}
			int num = additionalCompositorData.layerFilters.FindIndex((CompositionFilter x) => x.filterType == CompositionFilter.FilterType.CHROMA_KEYING);
			if (num < 0)
			{
				HDUtils.BlitCameraTexture(cmd, source, destination, 0f, false);
				return;
			}
			CompositionFilter compositionFilter = additionalCompositorData.layerFilters[num];
			Vector4 value;
			value.x = compositionFilter.keyThreshold;
			value.y = compositionFilter.keyTolerance;
			value.z = compositionFilter.spillRemoval;
			value.w = 1f;
			this.m_Material.SetVector(ChromaKeying.ShaderIDs.k_KeyColor, compositionFilter.maskColor);
			this.m_Material.SetVector(ChromaKeying.ShaderIDs.k_KeyParams, value);
			this.m_Material.SetTexture(ChromaKeying.ShaderIDs.k_InputTexture, source);
			HDUtils.DrawFullScreen(cmd, this.m_Material, destination, null, 0);
		}

		// Token: 0x06001025 RID: 4133 RVA: 0x0007CCA5 File Offset: 0x0007AEA5
		public override void Cleanup()
		{
			CoreUtils.Destroy(this.m_Material);
		}

		// Token: 0x0400197C RID: 6524
		public BoolParameter activate = new BoolParameter(false, false);

		// Token: 0x0400197D RID: 6525
		private Material m_Material;

		// Token: 0x02000453 RID: 1107
		internal class ShaderIDs
		{
			// Token: 0x040029D0 RID: 10704
			public static readonly int k_KeyColor = Shader.PropertyToID("_KeyColor");

			// Token: 0x040029D1 RID: 10705
			public static readonly int k_KeyParams = Shader.PropertyToID("_KeyParams");

			// Token: 0x040029D2 RID: 10706
			public static readonly int k_InputTexture = Shader.PropertyToID("_InputTexture");
		}
	}
}
