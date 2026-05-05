using System;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000174 RID: 372
	internal class HDDiffuseDenoiser
	{
		// Token: 0x06000C32 RID: 3122 RVA: 0x00064A2C File Offset: 0x00062C2C
		public void Init(HDRenderPipelineRuntimeResources rpResources, HDRenderPipeline renderPipeline)
		{
			this.m_DiffuseDenoiser = rpResources.shaders.diffuseDenoiserCS;
			this.m_BilateralFilterSingleKernel = this.m_DiffuseDenoiser.FindKernel("BilateralFilterSingle");
			this.m_BilateralFilterColorKernel = this.m_DiffuseDenoiser.FindKernel("BilateralFilterColor");
			this.m_GatherSingleKernel = this.m_DiffuseDenoiser.FindKernel("GatherSingle");
			this.m_GatherColorKernel = this.m_DiffuseDenoiser.FindKernel("GatherColor");
			this.m_DenoiserInitialized = false;
			this.m_OwnenScrambledTexture = rpResources.textures.owenScrambledRGBATex;
			this.m_PointDistribution = new ComputeBuffer(64, 8);
		}

		// Token: 0x06000C33 RID: 3123 RVA: 0x00064AC8 File Offset: 0x00062CC8
		public void Release()
		{
			CoreUtils.SafeRelease(this.m_PointDistribution);
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x00064AD8 File Offset: 0x00062CD8
		public TextureHandle Denoise(RenderGraph renderGraph, HDCamera hdCamera, HDDiffuseDenoiser.DiffuseDenoiserParameters denoiserParams, TextureHandle noisyBuffer, TextureHandle depthBuffer, TextureHandle normalBuffer, TextureHandle outputBuffer)
		{
			HDDiffuseDenoiser.DiffuseDenoiserPassData diffuseDenoiserPassData;
			TextureHandle outputBuffer2;
			using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<HDDiffuseDenoiser.DiffuseDenoiserPassData>("DiffuseDenoiser", out diffuseDenoiserPassData, ProfilingSampler.Get<HDProfileId>(HDProfileId.DiffuseFilter)))
			{
				renderGraphBuilder.EnableAsyncCompute(false);
				diffuseDenoiserPassData.needInit = !this.m_DenoiserInitialized;
				this.m_DenoiserInitialized = true;
				diffuseDenoiserPassData.owenScrambledTexture = this.m_OwnenScrambledTexture;
				diffuseDenoiserPassData.texWidth = (int)Mathf.Floor((float)hdCamera.actualWidth / denoiserParams.resolutionMultiplier);
				diffuseDenoiserPassData.texHeight = (int)Mathf.Floor((float)hdCamera.actualHeight / denoiserParams.resolutionMultiplier);
				diffuseDenoiserPassData.viewCount = hdCamera.viewCount;
				diffuseDenoiserPassData.pixelSpreadTangent = HDRenderPipeline.GetPixelSpreadTangent(hdCamera.camera.fieldOfView, diffuseDenoiserPassData.texWidth, diffuseDenoiserPassData.texHeight);
				diffuseDenoiserPassData.kernelSize = denoiserParams.kernelSize;
				diffuseDenoiserPassData.halfResolutionFilter = denoiserParams.halfResolutionFilter;
				diffuseDenoiserPassData.jitterFilter = denoiserParams.jitterFilter;
				diffuseDenoiserPassData.frameIndex = HDRenderPipeline.RayTracingFrameIndex(hdCamera);
				diffuseDenoiserPassData.resolutionMultiplier = denoiserParams.resolutionMultiplier;
				diffuseDenoiserPassData.bilateralFilterKernel = (denoiserParams.singleChannel ? this.m_BilateralFilterSingleKernel : this.m_BilateralFilterColorKernel);
				diffuseDenoiserPassData.gatherKernel = (denoiserParams.singleChannel ? this.m_GatherSingleKernel : this.m_GatherColorKernel);
				diffuseDenoiserPassData.diffuseDenoiserCS = this.m_DiffuseDenoiser;
				HDDiffuseDenoiser.DiffuseDenoiserPassData diffuseDenoiserPassData2 = diffuseDenoiserPassData;
				ComputeBufferHandle computeBufferHandle = renderGraph.ImportComputeBuffer(this.m_PointDistribution);
				diffuseDenoiserPassData2.pointDistribution = renderGraphBuilder.ReadComputeBuffer(computeBufferHandle);
				diffuseDenoiserPassData.depthStencilBuffer = renderGraphBuilder.ReadTexture(depthBuffer);
				diffuseDenoiserPassData.normalBuffer = renderGraphBuilder.ReadTexture(normalBuffer);
				diffuseDenoiserPassData.noisyBuffer = renderGraphBuilder.ReadTexture(noisyBuffer);
				HDDiffuseDenoiser.DiffuseDenoiserPassData diffuseDenoiserPassData3 = diffuseDenoiserPassData;
				TextureDesc textureDesc = new TextureDesc(Vector2.one, true, true);
				textureDesc.colorFormat = GraphicsFormat.B10G11R11_UFloatPack32;
				textureDesc.enableRandomWrite = true;
				textureDesc.name = "DiffuseDenoiserIntermediate";
				diffuseDenoiserPassData3.intermediateBuffer = renderGraphBuilder.CreateTransientTexture(textureDesc);
				diffuseDenoiserPassData.outputBuffer = renderGraphBuilder.WriteTexture(outputBuffer);
				renderGraphBuilder.SetRenderFunc<HDDiffuseDenoiser.DiffuseDenoiserPassData>(delegate(HDDiffuseDenoiser.DiffuseDenoiserPassData data, RenderGraphContext ctx)
				{
					if (data.needInit)
					{
						int kernelIndex = data.diffuseDenoiserCS.FindKernel("GeneratePointDistribution");
						ctx.cmd.SetComputeTextureParam(data.diffuseDenoiserCS, kernelIndex, HDShaderIDs._OwenScrambledRGTexture, data.owenScrambledTexture);
						ctx.cmd.SetComputeBufferParam(data.diffuseDenoiserCS, kernelIndex, "_PointDistributionRW", data.pointDistribution);
						ctx.cmd.DispatchCompute(data.diffuseDenoiserCS, kernelIndex, 1, 1, 1);
					}
					int num = 8;
					int threadGroupsX = (data.texWidth + (num - 1)) / num;
					int threadGroupsY = (data.texHeight + (num - 1)) / num;
					ctx.cmd.SetComputeFloatParam(data.diffuseDenoiserCS, HDShaderIDs._DenoiserFilterRadius, data.kernelSize);
					ctx.cmd.SetComputeBufferParam(data.diffuseDenoiserCS, data.bilateralFilterKernel, HDShaderIDs._PointDistribution, data.pointDistribution);
					ctx.cmd.SetComputeTextureParam(data.diffuseDenoiserCS, data.bilateralFilterKernel, HDShaderIDs._DenoiseInputTexture, data.noisyBuffer);
					ctx.cmd.SetComputeTextureParam(data.diffuseDenoiserCS, data.bilateralFilterKernel, HDShaderIDs._DepthTexture, data.depthStencilBuffer);
					ctx.cmd.SetComputeTextureParam(data.diffuseDenoiserCS, data.bilateralFilterKernel, HDShaderIDs._StencilTexture, data.depthStencilBuffer, 0, RenderTextureSubElement.Stencil);
					ctx.cmd.SetComputeTextureParam(data.diffuseDenoiserCS, data.bilateralFilterKernel, HDShaderIDs._NormalBufferTexture, data.normalBuffer);
					ctx.cmd.SetComputeTextureParam(data.diffuseDenoiserCS, data.bilateralFilterKernel, HDShaderIDs._DenoiseOutputTextureRW, data.halfResolutionFilter ? data.intermediateBuffer : data.outputBuffer);
					ctx.cmd.SetComputeIntParam(data.diffuseDenoiserCS, HDShaderIDs._HalfResolutionFilter, data.halfResolutionFilter ? 1 : 0);
					ctx.cmd.SetComputeFloatParam(data.diffuseDenoiserCS, HDShaderIDs._PixelSpreadAngleTangent, data.pixelSpreadTangent);
					ctx.cmd.SetComputeVectorParam(data.diffuseDenoiserCS, HDShaderIDs._DenoiserResolutionMultiplierVals, new Vector4(data.resolutionMultiplier, 1f / data.resolutionMultiplier, 0f, 0f));
					if (data.jitterFilter)
					{
						ctx.cmd.SetComputeIntParam(data.diffuseDenoiserCS, HDShaderIDs._JitterFramePeriod, data.frameIndex % 4);
					}
					else
					{
						ctx.cmd.SetComputeIntParam(data.diffuseDenoiserCS, HDShaderIDs._JitterFramePeriod, -1);
					}
					ctx.cmd.DispatchCompute(data.diffuseDenoiserCS, data.bilateralFilterKernel, threadGroupsX, threadGroupsY, data.viewCount);
					if (data.halfResolutionFilter)
					{
						ctx.cmd.SetComputeTextureParam(data.diffuseDenoiserCS, data.gatherKernel, HDShaderIDs._DenoiseInputTexture, data.intermediateBuffer);
						ctx.cmd.SetComputeTextureParam(data.diffuseDenoiserCS, data.gatherKernel, HDShaderIDs._DepthTexture, data.depthStencilBuffer);
						ctx.cmd.SetComputeTextureParam(data.diffuseDenoiserCS, data.gatherKernel, HDShaderIDs._DenoiseOutputTextureRW, data.outputBuffer);
						ctx.cmd.DispatchCompute(data.diffuseDenoiserCS, data.gatherKernel, threadGroupsX, threadGroupsY, data.viewCount);
					}
				});
				outputBuffer2 = diffuseDenoiserPassData.outputBuffer;
			}
			return outputBuffer2;
		}

		// Token: 0x040012CE RID: 4814
		private ComputeShader m_DiffuseDenoiser;

		// Token: 0x040012CF RID: 4815
		private bool m_DenoiserInitialized;

		// Token: 0x040012D0 RID: 4816
		private Texture2D m_OwnenScrambledTexture;

		// Token: 0x040012D1 RID: 4817
		private ComputeBuffer m_PointDistribution;

		// Token: 0x040012D2 RID: 4818
		private int m_BilateralFilterSingleKernel;

		// Token: 0x040012D3 RID: 4819
		private int m_BilateralFilterColorKernel;

		// Token: 0x040012D4 RID: 4820
		private int m_GatherSingleKernel;

		// Token: 0x040012D5 RID: 4821
		private int m_GatherColorKernel;

		// Token: 0x020003CA RID: 970
		private class DiffuseDenoiserPassData
		{
			// Token: 0x0400276F RID: 10095
			public int texWidth;

			// Token: 0x04002770 RID: 10096
			public int texHeight;

			// Token: 0x04002771 RID: 10097
			public int viewCount;

			// Token: 0x04002772 RID: 10098
			public bool needInit;

			// Token: 0x04002773 RID: 10099
			public float pixelSpreadTangent;

			// Token: 0x04002774 RID: 10100
			public float kernelSize;

			// Token: 0x04002775 RID: 10101
			public bool halfResolutionFilter;

			// Token: 0x04002776 RID: 10102
			public bool jitterFilter;

			// Token: 0x04002777 RID: 10103
			public int frameIndex;

			// Token: 0x04002778 RID: 10104
			public float resolutionMultiplier;

			// Token: 0x04002779 RID: 10105
			public int bilateralFilterKernel;

			// Token: 0x0400277A RID: 10106
			public int gatherKernel;

			// Token: 0x0400277B RID: 10107
			public ComputeBufferHandle pointDistribution;

			// Token: 0x0400277C RID: 10108
			public ComputeShader diffuseDenoiserCS;

			// Token: 0x0400277D RID: 10109
			public Texture2D owenScrambledTexture;

			// Token: 0x0400277E RID: 10110
			public TextureHandle depthStencilBuffer;

			// Token: 0x0400277F RID: 10111
			public TextureHandle normalBuffer;

			// Token: 0x04002780 RID: 10112
			public TextureHandle noisyBuffer;

			// Token: 0x04002781 RID: 10113
			public TextureHandle intermediateBuffer;

			// Token: 0x04002782 RID: 10114
			public TextureHandle outputBuffer;
		}

		// Token: 0x020003CB RID: 971
		internal struct DiffuseDenoiserParameters
		{
			// Token: 0x04002783 RID: 10115
			public bool singleChannel;

			// Token: 0x04002784 RID: 10116
			public float kernelSize;

			// Token: 0x04002785 RID: 10117
			public bool halfResolutionFilter;

			// Token: 0x04002786 RID: 10118
			public bool jitterFilter;

			// Token: 0x04002787 RID: 10119
			public float resolutionMultiplier;
		}
	}
}
