using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001DE RID: 478
	internal class GradientSkyRenderer : SkyRenderer
	{
		// Token: 0x06000E76 RID: 3702 RVA: 0x00072B10 File Offset: 0x00070D10
		public GradientSkyRenderer()
		{
			this.SupportDynamicSunLight = false;
		}

		// Token: 0x06000E77 RID: 3703 RVA: 0x00072B75 File Offset: 0x00070D75
		public override void Build()
		{
			this.m_GradientSkyMaterial = CoreUtils.CreateEngineMaterial(HDRenderPipelineGlobalSettings.instance.renderPipelineResources.shaders.gradientSkyPS);
		}

		// Token: 0x06000E78 RID: 3704 RVA: 0x00072B96 File Offset: 0x00070D96
		public override void Cleanup()
		{
			CoreUtils.Destroy(this.m_GradientSkyMaterial);
		}

		// Token: 0x06000E79 RID: 3705 RVA: 0x00072BA4 File Offset: 0x00070DA4
		public override void RenderSky(BuiltinSkyParameters builtinParams, bool renderForCubemap, bool renderSunDisk)
		{
			GradientSky gradientSky = builtinParams.skySettings as GradientSky;
			this.m_GradientSkyMaterial.SetColor(this._GradientBottom, gradientSky.bottom.value);
			this.m_GradientSkyMaterial.SetColor(this._GradientMiddle, gradientSky.middle.value);
			this.m_GradientSkyMaterial.SetColor(this._GradientTop, gradientSky.top.value);
			this.m_GradientSkyMaterial.SetFloat(this._GradientDiffusion, gradientSky.gradientDiffusion.value);
			this.m_GradientSkyMaterial.SetFloat(HDShaderIDs._SkyIntensity, SkyRenderer.GetSkyIntensity(gradientSky, builtinParams.debugSettings));
			this.m_PropertyBlock.SetMatrix(HDShaderIDs._PixelCoordToViewDirWS, builtinParams.pixelCoordToViewDirMatrix);
			CoreUtils.DrawFullScreen(builtinParams.commandBuffer, this.m_GradientSkyMaterial, this.m_PropertyBlock, renderForCubemap ? 0 : 1);
		}

		// Token: 0x040016C4 RID: 5828
		private Material m_GradientSkyMaterial;

		// Token: 0x040016C5 RID: 5829
		private MaterialPropertyBlock m_PropertyBlock = new MaterialPropertyBlock();

		// Token: 0x040016C6 RID: 5830
		private readonly int _GradientBottom = Shader.PropertyToID("_GradientBottom");

		// Token: 0x040016C7 RID: 5831
		private readonly int _GradientMiddle = Shader.PropertyToID("_GradientMiddle");

		// Token: 0x040016C8 RID: 5832
		private readonly int _GradientTop = Shader.PropertyToID("_GradientTop");

		// Token: 0x040016C9 RID: 5833
		private readonly int _GradientDiffusion = Shader.PropertyToID("_GradientDiffusion");
	}
}
