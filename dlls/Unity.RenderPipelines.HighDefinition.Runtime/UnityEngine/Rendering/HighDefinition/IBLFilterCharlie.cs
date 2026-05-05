using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000103 RID: 259
	internal class IBLFilterCharlie : IBLFilterBSDF
	{
		// Token: 0x06000A15 RID: 2581 RVA: 0x00055D00 File Offset: 0x00053F00
		public IBLFilterCharlie(HDRenderPipelineRuntimeResources renderPipelineResources, MipGenerator mipGenerator)
		{
			this.m_RenderPipelineResources = renderPipelineResources;
			this.m_MipGenerator = mipGenerator;
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x00055D16 File Offset: 0x00053F16
		public override bool IsInitialized()
		{
			return this.m_convolveMaterial != null;
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x00055D24 File Offset: 0x00053F24
		public override void Initialize(CommandBuffer cmd)
		{
			if (!this.m_convolveMaterial)
			{
				this.m_convolveMaterial = CoreUtils.CreateEngineMaterial(this.m_RenderPipelineResources.shaders.charlieConvolvePS);
			}
			for (int i = 0; i < 6; i++)
			{
				Matrix4x4 lhs = Matrix4x4.LookAt(Vector3.zero, CoreUtils.lookAtList[i], CoreUtils.upVectorList[i]);
				this.m_faceWorldToViewMatrixMatrices[i] = lhs * Matrix4x4.Scale(new Vector3(1f, 1f, -1f));
			}
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x00055DB1 File Offset: 0x00053FB1
		public override void Cleanup()
		{
			CoreUtils.Destroy(this.m_convolveMaterial);
			this.m_convolveMaterial = null;
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x00055DC8 File Offset: 0x00053FC8
		private void FilterCubemapCommon(CommandBuffer cmd, Texture source, RenderTexture target, Matrix4x4[] worldToViewMatrices)
		{
			using (new ProfilingScope(cmd, ProfilingSampler.Get<HDProfileId>(HDProfileId.FilterCubemapCharlie)))
			{
				if (1 + (int)Mathf.Log((float)source.width, 2f) < 7)
				{
					Debug.LogWarning("RenderCubemapCharlieConvolution: Cubemap size is too small for Charlie convolution, needs at least " + 7.ToString() + " mip levels");
				}
				else
				{
					float value = 6f * (float)source.width * (float)source.width / 12.566371f;
					MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
					materialPropertyBlock.SetTexture("_MainTex", source);
					materialPropertyBlock.SetFloat("_InvOmegaP", value);
					float value2 = 1f / (8.377581f / (3.1734369f * (float)source.width * (float)source.width));
					materialPropertyBlock.SetFloat("_InvFaceCenterTexelSolidAngle", value2);
					for (int i = 0; i < 7; i++)
					{
						materialPropertyBlock.SetFloat("_Level", (float)i);
						for (int j = 0; j < 6; j++)
						{
							Vector4 screenSize = new Vector4((float)(source.width >> i), (float)(source.height >> i), 1f / (float)(source.width >> i), 1f / (float)(source.height >> i));
							Matrix4x4 value3 = HDUtils.ComputePixelCoordToWorldSpaceViewDirectionMatrix(1.5707964f, Vector2.zero, screenSize, worldToViewMatrices[j], true, -1f, false);
							materialPropertyBlock.SetMatrix(HDShaderIDs._PixelCoordToViewDirWS, value3);
							CoreUtils.SetRenderTarget(cmd, target, ClearFlag.None, i, (CubemapFace)j, -1);
							CoreUtils.DrawFullScreen(cmd, this.m_convolveMaterial, materialPropertyBlock, 0);
						}
					}
				}
			}
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x00055F84 File Offset: 0x00054184
		public override void FilterCubemap(CommandBuffer cmd, Texture source, RenderTexture target)
		{
			this.FilterCubemapCommon(cmd, source, target, this.m_faceWorldToViewMatrixMatrices);
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x00055F95 File Offset: 0x00054195
		public override void FilterCubemapMIS(CommandBuffer cmd, Texture source, RenderTexture target, RenderTexture conditionalCdf, RenderTexture marginalRowCdf)
		{
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x00055F97 File Offset: 0x00054197
		public override void FilterPlanarTexture(CommandBuffer cmd, RenderTexture source, ref IBLFilterBSDF.PlanarTextureFilteringParameters planarTextureFilteringParameters, RenderTexture target)
		{
			this.m_MipGenerator.RenderColorGaussianPyramid(cmd, new Vector2Int(source.width, source.height), source, target);
		}
	}
}
