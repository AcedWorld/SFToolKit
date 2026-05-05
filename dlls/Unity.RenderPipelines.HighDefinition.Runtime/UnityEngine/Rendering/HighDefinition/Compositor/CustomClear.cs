using System;

namespace UnityEngine.Rendering.HighDefinition.Compositor
{
	// Token: 0x02000244 RID: 580
	[HideInInspector]
	internal class CustomClear : CustomPass
	{
		// Token: 0x06001099 RID: 4249 RVA: 0x0007F844 File Offset: 0x0007DA44
		protected override void Setup(ScriptableRenderContext renderContext, CommandBuffer cmd)
		{
			if (!HDRenderPipeline.isReady)
			{
				return;
			}
			if (string.IsNullOrEmpty(base.name))
			{
				base.name = "CustomClear";
			}
			this.m_FullscreenPassMaterial = CoreUtils.CreateEngineMaterial(HDRenderPipelineGlobalSettings.instance.renderPipelineResources.shaders.customClearPS);
		}

		// Token: 0x0600109A RID: 4250 RVA: 0x0007F890 File Offset: 0x0007DA90
		protected override void Execute(CustomPassContext ctx)
		{
			AdditionalCompositorData additionalCompositorData = null;
			ctx.hdCamera.camera.gameObject.TryGetComponent<AdditionalCompositorData>(out additionalCompositorData);
			if (additionalCompositorData == null || additionalCompositorData.clearColorTexture == null)
			{
				return;
			}
			float num = (float)ctx.hdCamera.actualWidth / (float)ctx.hdCamera.actualHeight;
			float num2 = (float)additionalCompositorData.clearColorTexture.width / (float)additionalCompositorData.clearColorTexture.height;
			Vector4 vector = new Vector4(1f, 1f, 0f, 0f);
			if (additionalCompositorData.imageFitMode == BackgroundFitMode.FitHorizontally)
			{
				vector.y = num / num2;
				vector.w = (1f - vector.y) / 2f;
			}
			else if (additionalCompositorData.imageFitMode == BackgroundFitMode.FitVertically)
			{
				vector.x = num2 / num;
				vector.z = (1f - vector.x) / 2f;
			}
			if (vector.x < 1f || vector.y < 1f)
			{
				this.m_FullscreenPassMaterial.SetVector(CustomClear.ShaderIDs.k_BlitScaleBiasRt, new Vector4(1f, 1f, 0f, 0f));
				this.m_FullscreenPassMaterial.SetVector(CustomClear.ShaderIDs.k_BlitScaleBias, new Vector4(1f, 1f, 0f, 0f));
				ctx.cmd.DrawProcedural(Matrix4x4.identity, this.m_FullscreenPassMaterial, 0, MeshTopology.Quads, 4, 1);
			}
			this.m_FullscreenPassMaterial.SetTexture(CustomClear.ShaderIDs.k_BlitTexture, additionalCompositorData.clearColorTexture);
			this.m_FullscreenPassMaterial.SetVector(CustomClear.ShaderIDs.k_BlitScaleBiasRt, vector);
			this.m_FullscreenPassMaterial.SetVector(CustomClear.ShaderIDs.k_BlitScaleBias, new Vector4(1f, 1f, 0f, 0f));
			this.m_FullscreenPassMaterial.SetInt(CustomClear.ShaderIDs.k_ClearAlpha, additionalCompositorData.clearAlpha ? 1 : 0);
			ctx.cmd.DrawProcedural(Matrix4x4.identity, this.m_FullscreenPassMaterial, 1, MeshTopology.Quads, 4, 1);
		}

		// Token: 0x0600109B RID: 4251 RVA: 0x0007FA84 File Offset: 0x0007DC84
		protected override void Cleanup()
		{
			CoreUtils.Destroy(this.m_FullscreenPassMaterial);
		}

		// Token: 0x040019BE RID: 6590
		private Material m_FullscreenPassMaterial;

		// Token: 0x02000463 RID: 1123
		internal class ShaderIDs
		{
			// Token: 0x04002A01 RID: 10753
			public static readonly int k_BlitScaleBiasRt = Shader.PropertyToID("_BlitScaleBiasRt");

			// Token: 0x04002A02 RID: 10754
			public static readonly int k_BlitScaleBias = Shader.PropertyToID("_BlitScaleBias");

			// Token: 0x04002A03 RID: 10755
			public static readonly int k_BlitTexture = Shader.PropertyToID("_BlitTexture");

			// Token: 0x04002A04 RID: 10756
			public static readonly int k_ClearAlpha = Shader.PropertyToID("_ClearAlpha");
		}

		// Token: 0x02000464 RID: 1124
		private enum PassType
		{
			// Token: 0x04002A06 RID: 10758
			ClearColorAndStencil,
			// Token: 0x04002A07 RID: 10759
			DrawTextureAndClearStencil
		}
	}
}
