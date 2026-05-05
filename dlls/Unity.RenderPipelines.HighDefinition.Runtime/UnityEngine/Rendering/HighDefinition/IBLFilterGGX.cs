using System;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000106 RID: 262
	internal class IBLFilterGGX : IBLFilterBSDF
	{
		// Token: 0x06000A22 RID: 2594 RVA: 0x00056138 File Offset: 0x00054338
		public IBLFilterGGX(HDRenderPipelineRuntimeResources renderPipelineResources, MipGenerator mipGenerator)
		{
			this.m_RenderPipelineResources = renderPipelineResources;
			this.m_MipGenerator = mipGenerator;
		}

		// Token: 0x06000A23 RID: 2595 RVA: 0x000561C0 File Offset: 0x000543C0
		public override bool IsInitialized()
		{
			return this.m_GgxIblSampleData != null;
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x000561D0 File Offset: 0x000543D0
		public override void Initialize(CommandBuffer cmd)
		{
			if (!this.m_ComputeGgxIblSampleDataCS)
			{
				this.m_ComputeGgxIblSampleDataCS = this.m_RenderPipelineResources.shaders.computeGgxIblSampleDataCS;
				this.m_ComputeGgxIblSampleDataKernel = this.m_ComputeGgxIblSampleDataCS.FindKernel("ComputeGgxIblSampleData");
			}
			if (!this.m_BuildProbabilityTablesCS)
			{
				this.m_BuildProbabilityTablesCS = this.m_RenderPipelineResources.shaders.buildProbabilityTablesCS;
				this.m_ConditionalDensitiesKernel = this.m_BuildProbabilityTablesCS.FindKernel("ComputeConditionalDensities");
				this.m_MarginalRowDensitiesKernel = this.m_BuildProbabilityTablesCS.FindKernel("ComputeMarginalRowDensities");
			}
			if (!this.m_convolveMaterial)
			{
				this.m_convolveMaterial = CoreUtils.CreateEngineMaterial(this.m_RenderPipelineResources.shaders.GGXConvolvePS);
			}
			if (!this.m_GgxIblSampleData)
			{
				this.m_GgxIblSampleData = new RenderTexture(this.m_GgxIblMaxSampleCount, 6, 0, GraphicsFormat.R16G16B16A16_SFloat);
				this.m_GgxIblSampleData.useMipMap = false;
				this.m_GgxIblSampleData.autoGenerateMips = false;
				this.m_GgxIblSampleData.enableRandomWrite = true;
				this.m_GgxIblSampleData.filterMode = FilterMode.Point;
				this.m_GgxIblSampleData.name = CoreUtils.GetRenderTargetAutoName(this.m_GgxIblMaxSampleCount, 6, 1, GraphicsFormat.R16G16B16A16_SFloat, "GGXIblSampleData", false, false, MSAASamples.None);
				this.m_GgxIblSampleData.hideFlags = HideFlags.HideAndDontSave;
				this.m_GgxIblSampleData.Create();
				this.InitializeGgxIblSampleData(cmd);
			}
			if (!this.m_PlanarReflectionFilteringCS)
			{
				this.m_PlanarReflectionFilteringCS = this.m_RenderPipelineResources.shaders.planarReflectionFilteringCS;
				this.m_PlanarReflectionDepthConversionKernel = this.m_PlanarReflectionFilteringCS.FindKernel("DepthConversion");
				this.m_PlanarReflectionDownScaleKernel = this.m_PlanarReflectionFilteringCS.FindKernel("DownScale");
				this.m_PlanarReflectionFilteringKernel = this.m_PlanarReflectionFilteringCS.FindKernel("FilterPlanarReflection");
			}
			for (int i = 0; i < 6; i++)
			{
				Matrix4x4 lhs = Matrix4x4.LookAt(Vector3.zero, CoreUtils.lookAtList[i], CoreUtils.upVectorList[i]);
				this.m_faceWorldToViewMatrixMatrices[i] = lhs * Matrix4x4.Scale(new Vector3(1f, 1f, -1f));
			}
		}

		// Token: 0x06000A25 RID: 2597 RVA: 0x000563E1 File Offset: 0x000545E1
		private void InitializeGgxIblSampleData(CommandBuffer cmd)
		{
			this.m_ComputeGgxIblSampleDataCS.SetTexture(this.m_ComputeGgxIblSampleDataKernel, "outputResult", this.m_GgxIblSampleData);
			cmd.DispatchCompute(this.m_ComputeGgxIblSampleDataCS, this.m_ComputeGgxIblSampleDataKernel, 1, 1, 1);
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x00056414 File Offset: 0x00054614
		private static RenderTextureDescriptor MakeRenderTextureDescriptor(int texWidth, int texHeight, GraphicsFormat format, bool useMipMap)
		{
			return new RenderTextureDescriptor
			{
				dimension = TextureDimension.Tex2D,
				width = texWidth,
				height = texHeight,
				volumeDepth = TextureXR.slices,
				graphicsFormat = format,
				enableRandomWrite = true,
				useDynamicScale = false,
				useMipMap = useMipMap,
				msaaSamples = 1
			};
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x00056478 File Offset: 0x00054678
		private static void CreateIntermediateTextures(CommandBuffer cmd, int texWidth, int texHeight)
		{
			GraphicsFormat reflectionProbeFormat = (GraphicsFormat)((HDRenderPipeline)RenderPipelineManager.currentPipeline).currentPlatformRenderPipelineSettings.lightLoopSettings.reflectionProbeFormat;
			cmd.GetTemporaryRT(IBLFilterGGX.k_PlanarReflectionFilterTex0ID, IBLFilterGGX.MakeRenderTextureDescriptor(texWidth, texHeight, reflectionProbeFormat, true));
			cmd.GetTemporaryRT(IBLFilterGGX.k_PlanarReflectionFilterTex1ID, IBLFilterGGX.MakeRenderTextureDescriptor(texWidth, texHeight, reflectionProbeFormat, false));
			cmd.GetTemporaryRT(IBLFilterGGX.k_PlanarReflectionFilterDepthTex0ID, IBLFilterGGX.MakeRenderTextureDescriptor(texWidth, texHeight, GraphicsFormat.R32_SFloat, true));
			cmd.GetTemporaryRT(IBLFilterGGX.k_PlanarReflectionFilterDepthTex1ID, IBLFilterGGX.MakeRenderTextureDescriptor(texWidth, texHeight, GraphicsFormat.R32_SFloat, false));
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x000564F1 File Offset: 0x000546F1
		private static void ReleaseItrermediateTextures(CommandBuffer cmd)
		{
			cmd.ReleaseTemporaryRT(IBLFilterGGX.k_PlanarReflectionFilterTex0ID);
			cmd.ReleaseTemporaryRT(IBLFilterGGX.k_PlanarReflectionFilterTex1ID);
			cmd.ReleaseTemporaryRT(IBLFilterGGX.k_PlanarReflectionFilterDepthTex0ID);
			cmd.ReleaseTemporaryRT(IBLFilterGGX.k_PlanarReflectionFilterDepthTex1ID);
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x0005651F File Offset: 0x0005471F
		public override void Cleanup()
		{
			CoreUtils.Destroy(this.m_convolveMaterial);
			CoreUtils.Destroy(this.m_GgxIblSampleData);
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x00056538 File Offset: 0x00054738
		private void FilterCubemapCommon(CommandBuffer cmd, Texture source, RenderTexture target, Matrix4x4[] worldToViewMatrices)
		{
			using (new ProfilingScope(cmd, ProfilingSampler.Get<HDProfileId>(HDProfileId.FilterCubemapGGX)))
			{
				if (1 + (int)Mathf.Log((float)source.width, 2f) < 7)
				{
					Debug.LogWarning("RenderCubemapGGXConvolution: Cubemap size is too small for GGX convolution, needs at least " + 7.ToString() + " mip levels");
				}
				else
				{
					for (int i = 0; i < 6; i++)
					{
						cmd.CopyTexture(source, i, 0, target, i, 0);
					}
					float value = 6f * (float)source.width * (float)source.width / 12.566371f;
					if (!this.m_GgxIblSampleData.IsCreated())
					{
						this.m_GgxIblSampleData.Create();
						this.InitializeGgxIblSampleData(cmd);
					}
					this.m_convolveMaterial.SetTexture("_GgxIblSamples", this.m_GgxIblSampleData);
					this.m_MaterialPropertyBlock.SetTexture("_MainTex", source);
					this.m_MaterialPropertyBlock.SetFloat("_InvOmegaP", value);
					for (int j = 1; j < 7; j++)
					{
						this.m_MaterialPropertyBlock.SetFloat("_Level", (float)j);
						for (int k = 0; k < 6; k++)
						{
							Vector4 screenSize = new Vector4((float)(source.width >> j), (float)(source.height >> j), 1f / (float)(source.width >> j), 1f / (float)(source.height >> j));
							Matrix4x4 value2 = HDUtils.ComputePixelCoordToWorldSpaceViewDirectionMatrix(1.5707964f, Vector2.zero, screenSize, worldToViewMatrices[k], true, -1f, false);
							this.m_MaterialPropertyBlock.SetMatrix(HDShaderIDs._PixelCoordToViewDirWS, value2);
							CoreUtils.SetRenderTarget(cmd, target, ClearFlag.None, j, (CubemapFace)k, -1);
							CoreUtils.DrawFullScreen(cmd, this.m_convolveMaterial, this.m_MaterialPropertyBlock, 0);
						}
					}
				}
			}
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x00056730 File Offset: 0x00054930
		public override void FilterCubemapMIS(CommandBuffer cmd, Texture source, RenderTexture target, RenderTexture conditionalCdf, RenderTexture marginalRowCdf)
		{
			this.m_BuildProbabilityTablesCS.SetTexture(this.m_ConditionalDensitiesKernel, "envMap", source);
			this.m_BuildProbabilityTablesCS.SetTexture(this.m_ConditionalDensitiesKernel, "conditionalDensities", conditionalCdf);
			this.m_BuildProbabilityTablesCS.SetTexture(this.m_ConditionalDensitiesKernel, "marginalRowDensities", marginalRowCdf);
			this.m_BuildProbabilityTablesCS.SetTexture(this.m_MarginalRowDensitiesKernel, "marginalRowDensities", marginalRowCdf);
			int height = conditionalCdf.height;
			cmd.DispatchCompute(this.m_BuildProbabilityTablesCS, this.m_ConditionalDensitiesKernel, height, 1, 1);
			cmd.DispatchCompute(this.m_BuildProbabilityTablesCS, this.m_MarginalRowDensitiesKernel, 1, 1, 1);
			this.m_convolveMaterial.EnableKeyword("USE_MIS");
			this.m_convolveMaterial.SetTexture("_ConditionalDensities", conditionalCdf);
			this.m_convolveMaterial.SetTexture("_MarginalRowDensities", marginalRowCdf);
			this.FilterCubemapCommon(cmd, source, target, this.m_faceWorldToViewMatrixMatrices);
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x00056811 File Offset: 0x00054A11
		public override void FilterCubemap(CommandBuffer cmd, Texture source, RenderTexture target)
		{
			this.FilterCubemapCommon(cmd, source, target, this.m_faceWorldToViewMatrixMatrices);
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x00056824 File Offset: 0x00054A24
		private void BuildColorAndDepthMipChain(CommandBuffer cmd, RenderTexture sourceColor, RenderTexture sourceDepth, ref IBLFilterBSDF.PlanarTextureFilteringParameters planarTextureFilteringParameters)
		{
			int num = sourceColor.width;
			int num2 = sourceColor.height;
			cmd.CopyTexture(sourceColor, 0, 0, 0, 0, sourceColor.width, sourceColor.height, IBLFilterGGX.k_PlanarReflectionFilterTex0ID, 0, 0, 0, 0);
			cmd.SetComputeVectorParam(this.m_PlanarReflectionFilteringCS, HDShaderIDs._CaptureCameraPositon, planarTextureFilteringParameters.captureCameraPosition);
			cmd.SetComputeMatrixParam(this.m_PlanarReflectionFilteringCS, HDShaderIDs._CaptureCameraVP_NO, planarTextureFilteringParameters.captureCameraVP_NonOblique);
			cmd.SetComputeMatrixParam(this.m_PlanarReflectionFilteringCS, HDShaderIDs._CaptureCameraIVP, planarTextureFilteringParameters.captureCameraIVP);
			this.currentScreenSize.Set((float)num, (float)num2, 1f / (float)num, 1f / (float)num2);
			cmd.SetComputeVectorParam(this.m_PlanarReflectionFilteringCS, HDShaderIDs._CaptureCurrentScreenSize, this.currentScreenSize);
			cmd.SetComputeFloatParam(this.m_PlanarReflectionFilteringCS, HDShaderIDs._CaptureCameraFarPlane, planarTextureFilteringParameters.captureFarPlane);
			cmd.SetComputeTextureParam(this.m_PlanarReflectionFilteringCS, this.m_PlanarReflectionDepthConversionKernel, HDShaderIDs._DepthTextureOblique, sourceDepth);
			cmd.SetComputeTextureParam(this.m_PlanarReflectionFilteringCS, this.m_PlanarReflectionDepthConversionKernel, HDShaderIDs._DepthTextureNonOblique, IBLFilterGGX.k_PlanarReflectionFilterDepthTex0ID);
			int num3 = 8;
			int threadGroupsX = (num + (num3 - 1)) / num3;
			int threadGroupsY = (num2 + (num3 - 1)) / num3;
			cmd.DispatchCompute(this.m_PlanarReflectionFilteringCS, this.m_PlanarReflectionDepthConversionKernel, threadGroupsX, threadGroupsY, 1);
			int num4 = 0;
			int num5 = sourceColor.width >> 1;
			int num6 = sourceColor.height >> 1;
			while (num5 >= 2 && num6 >= 2)
			{
				cmd.SetComputeIntParam(this.m_PlanarReflectionFilteringCS, HDShaderIDs._SourceMipIndex, num4);
				cmd.SetComputeTextureParam(this.m_PlanarReflectionFilteringCS, this.m_PlanarReflectionDownScaleKernel, HDShaderIDs._ReflectionColorMipChain, IBLFilterGGX.k_PlanarReflectionFilterTex0ID);
				cmd.SetComputeTextureParam(this.m_PlanarReflectionFilteringCS, this.m_PlanarReflectionDownScaleKernel, HDShaderIDs._HalfResReflectionBuffer, IBLFilterGGX.k_PlanarReflectionFilterTex1ID);
				cmd.SetComputeTextureParam(this.m_PlanarReflectionFilteringCS, this.m_PlanarReflectionDownScaleKernel, HDShaderIDs._DepthTextureMipChain, IBLFilterGGX.k_PlanarReflectionFilterDepthTex0ID);
				cmd.SetComputeTextureParam(this.m_PlanarReflectionFilteringCS, this.m_PlanarReflectionDownScaleKernel, HDShaderIDs._HalfResDepthBuffer, IBLFilterGGX.k_PlanarReflectionFilterDepthTex1ID);
				this.currentScreenSize.Set((float)num, (float)num2, 1f / (float)num, 1f / (float)num2);
				cmd.SetComputeVectorParam(this.m_PlanarReflectionFilteringCS, HDShaderIDs._CaptureCurrentScreenSize, this.currentScreenSize);
				int threadGroupsX2 = (num5 + (num3 - 1)) / num3;
				int threadGroupsY2 = (num6 + (num3 - 1)) / num3;
				cmd.DispatchCompute(this.m_PlanarReflectionFilteringCS, this.m_PlanarReflectionDownScaleKernel, threadGroupsX2, threadGroupsY2, 1);
				cmd.CopyTexture(IBLFilterGGX.k_PlanarReflectionFilterTex1ID, 0, 0, 0, 0, num5, num6, IBLFilterGGX.k_PlanarReflectionFilterTex0ID, 0, num4 + 1, 0, 0);
				cmd.CopyTexture(IBLFilterGGX.k_PlanarReflectionFilterDepthTex1ID, 0, 0, 0, 0, num5, num6, IBLFilterGGX.k_PlanarReflectionFilterDepthTex0ID, 0, num4 + 1, 0, 0);
				num >>= 1;
				num2 >>= 1;
				num5 >>= 1;
				num6 >>= 1;
				num4++;
			}
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x00056AF8 File Offset: 0x00054CF8
		public override void FilterPlanarTexture(CommandBuffer cmd, RenderTexture source, ref IBLFilterBSDF.PlanarTextureFilteringParameters planarTextureFilteringParameters, RenderTexture target)
		{
			int num = source.width;
			int num2 = source.height;
			cmd.CopyTexture(source, 0, 0, 0, 0, num, num2, target, 0, 0, 0, 0);
			if (planarTextureFilteringParameters.smoothPlanarReflection)
			{
				return;
			}
			IBLFilterGGX.CreateIntermediateTextures(cmd, num, num2);
			this.BuildColorAndDepthMipChain(cmd, source, planarTextureFilteringParameters.captureCameraDepthBuffer, ref planarTextureFilteringParameters);
			int i = 1;
			int num3 = 8;
			int val = (int)(Mathf.Log((float)num, 2f) - 1f);
			num >>= 1;
			num2 >>= 1;
			while (i < 7)
			{
				int threadGroupsX = (num + (num3 - 1)) / num3;
				int threadGroupsY = (num2 + (num3 - 1)) / num3;
				cmd.SetComputeTextureParam(this.m_PlanarReflectionFilteringCS, this.m_PlanarReflectionFilteringKernel, HDShaderIDs._DepthTextureMipChain, IBLFilterGGX.k_PlanarReflectionFilterDepthTex0ID);
				cmd.SetComputeTextureParam(this.m_PlanarReflectionFilteringCS, this.m_PlanarReflectionFilteringKernel, HDShaderIDs._ReflectionColorMipChain, IBLFilterGGX.k_PlanarReflectionFilterTex0ID);
				cmd.SetComputeVectorParam(this.m_PlanarReflectionFilteringCS, HDShaderIDs._CaptureBaseScreenSize, planarTextureFilteringParameters.captureCameraScreenSize);
				this.currentScreenSize.Set((float)num, (float)num2, 1f / (float)num, 1f / (float)num2);
				cmd.SetComputeVectorParam(this.m_PlanarReflectionFilteringCS, HDShaderIDs._CaptureCurrentScreenSize, this.currentScreenSize);
				cmd.SetComputeIntParam(this.m_PlanarReflectionFilteringCS, HDShaderIDs._SourceMipIndex, i);
				cmd.SetComputeIntParam(this.m_PlanarReflectionFilteringCS, HDShaderIDs._MaxMipLevels, val);
				cmd.SetComputeFloatParam(this.m_PlanarReflectionFilteringCS, HDShaderIDs._RTScaleFactor, 1f);
				cmd.SetComputeVectorParam(this.m_PlanarReflectionFilteringCS, HDShaderIDs._ReflectionPlaneNormal, planarTextureFilteringParameters.probeNormal);
				cmd.SetComputeVectorParam(this.m_PlanarReflectionFilteringCS, HDShaderIDs._ReflectionPlanePosition, planarTextureFilteringParameters.probePosition);
				cmd.SetComputeVectorParam(this.m_PlanarReflectionFilteringCS, HDShaderIDs._CaptureCameraPositon, planarTextureFilteringParameters.captureCameraPosition);
				cmd.SetComputeMatrixParam(this.m_PlanarReflectionFilteringCS, HDShaderIDs._CaptureCameraIVP_NO, planarTextureFilteringParameters.captureCameraIVP_NonOblique);
				cmd.SetComputeFloatParam(this.m_PlanarReflectionFilteringCS, HDShaderIDs._CaptureCameraFOV, planarTextureFilteringParameters.captureFOV * 3.1415927f / 180f);
				cmd.SetComputeTextureParam(this.m_PlanarReflectionFilteringCS, this.m_PlanarReflectionFilteringKernel, HDShaderIDs._FilteredPlanarReflectionBuffer, IBLFilterGGX.k_PlanarReflectionFilterTex1ID);
				cmd.DispatchCompute(this.m_PlanarReflectionFilteringCS, this.m_PlanarReflectionFilteringKernel, threadGroupsX, threadGroupsY, 1);
				cmd.CopyTexture(IBLFilterGGX.k_PlanarReflectionFilterTex1ID, 0, 0, 0, 0, num, num2, target, 0, i, 0, 0);
				num >>= 1;
				num2 >>= 1;
				i++;
			}
			IBLFilterGGX.ReleaseItrermediateTextures(cmd);
		}

		// Token: 0x04000AE3 RID: 2787
		private static readonly int k_PlanarReflectionFilterTex0ID = Shader.PropertyToID("PlanarReflectionFilterTex0");

		// Token: 0x04000AE4 RID: 2788
		private static readonly int k_PlanarReflectionFilterTex1ID = Shader.PropertyToID("PlanarReflectionFilterTex1");

		// Token: 0x04000AE5 RID: 2789
		private static readonly int k_PlanarReflectionFilterDepthTex0ID = Shader.PropertyToID("PlanarReflectionFilterDepthTex0");

		// Token: 0x04000AE6 RID: 2790
		private static readonly int k_PlanarReflectionFilterDepthTex1ID = Shader.PropertyToID("PlanarReflectionFilterDepthTex1");

		// Token: 0x04000AE7 RID: 2791
		private RenderTexture m_GgxIblSampleData;

		// Token: 0x04000AE8 RID: 2792
		private int m_GgxIblMaxSampleCount = TextureCache.isMobileBuildTarget ? 34 : 89;

		// Token: 0x04000AE9 RID: 2793
		private const int k_GgxIblMipCountMinusOne = 6;

		// Token: 0x04000AEA RID: 2794
		private ComputeShader m_ComputeGgxIblSampleDataCS;

		// Token: 0x04000AEB RID: 2795
		private int m_ComputeGgxIblSampleDataKernel = -1;

		// Token: 0x04000AEC RID: 2796
		private ComputeShader m_BuildProbabilityTablesCS;

		// Token: 0x04000AED RID: 2797
		private int m_ConditionalDensitiesKernel = -1;

		// Token: 0x04000AEE RID: 2798
		private int m_MarginalRowDensitiesKernel = -1;

		// Token: 0x04000AEF RID: 2799
		private ComputeShader m_PlanarReflectionFilteringCS;

		// Token: 0x04000AF0 RID: 2800
		private int m_PlanarReflectionDepthConversionKernel = -1;

		// Token: 0x04000AF1 RID: 2801
		private int m_PlanarReflectionDownScaleKernel = -1;

		// Token: 0x04000AF2 RID: 2802
		private int m_PlanarReflectionFilteringKernel = -1;

		// Token: 0x04000AF3 RID: 2803
		private const int k_DefaultPlanarResolution = 512;

		// Token: 0x04000AF4 RID: 2804
		private Vector4 currentScreenSize = new Vector4(1f, 1f, 1f, 1f);

		// Token: 0x04000AF5 RID: 2805
		private MaterialPropertyBlock m_MaterialPropertyBlock = new MaterialPropertyBlock();
	}
}
