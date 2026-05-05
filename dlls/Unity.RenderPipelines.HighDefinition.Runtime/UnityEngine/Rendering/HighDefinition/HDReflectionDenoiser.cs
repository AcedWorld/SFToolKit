using System;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200017D RID: 381
	internal class HDReflectionDenoiser
	{
		// Token: 0x06000C68 RID: 3176 RVA: 0x00067774 File Offset: 0x00065974
		public void Init(HDRenderPipelineRayTracingResources rpRTResources)
		{
			this.m_ReflectionDenoiserCS = rpRTResources.reflectionDenoiserCS;
			this.m_ReflectionFilterMapping = rpRTResources.reflectionFilterMapping;
			this.s_TemporalAccumulationFullResKernel = this.m_ReflectionDenoiserCS.FindKernel("TemporalAccumulationFullRes");
			this.s_TemporalAccumulationHalfResKernel = this.m_ReflectionDenoiserCS.FindKernel("TemporalAccumulationHalfRes");
			this.s_CopyHistoryKernel = this.m_ReflectionDenoiserCS.FindKernel("CopyHistory");
			this.s_BilateralFilterH_FRKernel = this.m_ReflectionDenoiserCS.FindKernel("BilateralFilterH_FR");
			this.s_BilateralFilterV_FRKernel = this.m_ReflectionDenoiserCS.FindKernel("BilateralFilterV_FR");
			this.s_BilateralFilterH_HRKernel = this.m_ReflectionDenoiserCS.FindKernel("BilateralFilterH_HR");
			this.s_BilateralFilterV_HRKernel = this.m_ReflectionDenoiserCS.FindKernel("BilateralFilterV_HR");
		}

		// Token: 0x06000C69 RID: 3177 RVA: 0x00067833 File Offset: 0x00065A33
		public void Release()
		{
		}

		// Token: 0x06000C6A RID: 3178 RVA: 0x00067838 File Offset: 0x00065A38
		public TextureHandle DenoiseRTR(RenderGraph renderGraph, HDCamera hdCamera, float historyValidity, int maxKernelSize, bool fullResolution, bool singleReflectionBounce, bool affectSmoothSurfaces, TextureHandle depthPyramid, TextureHandle normalBuffer, TextureHandle motionVectorBuffer, TextureHandle clearCoatTexture, TextureHandle lightingTexture, RTHandle historyBuffer)
		{
			HDReflectionDenoiser.ReflectionDenoiserPassData reflectionDenoiserPassData;
			TextureHandle result;
			using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<HDReflectionDenoiser.ReflectionDenoiserPassData>("Denoise ray traced reflections", out reflectionDenoiserPassData, ProfilingSampler.Get<HDProfileId>(HDProfileId.RaytracingReflectionFilter)))
			{
				renderGraphBuilder.EnableAsyncCompute(false);
				reflectionDenoiserPassData.texWidth = (fullResolution ? hdCamera.actualWidth : (hdCamera.actualWidth / 2));
				reflectionDenoiserPassData.texHeight = (fullResolution ? hdCamera.actualHeight : (hdCamera.actualHeight / 2));
				reflectionDenoiserPassData.viewCount = hdCamera.viewCount;
				reflectionDenoiserPassData.historyValidity = historyValidity;
				reflectionDenoiserPassData.historySizeAndScale = HDRenderPipeline.EvaluateRayTracingHistorySizeAndScale(hdCamera, historyBuffer);
				reflectionDenoiserPassData.maxKernelSize = (fullResolution ? maxKernelSize : (maxKernelSize / 2));
				HDReflectionDenoiser.ReflectionDenoiserPassData reflectionDenoiserPassData2 = reflectionDenoiserPassData;
				float num = 1f;
				RTHandleProperties historyRTHandleProperties = hdCamera.historyRTHandleProperties;
				float x = num / (float)historyRTHandleProperties.currentRenderTargetSize.x;
				float num2 = 1f;
				historyRTHandleProperties = hdCamera.historyRTHandleProperties;
				reflectionDenoiserPassData2.historyBufferSize = new Vector2(x, num2 / (float)historyRTHandleProperties.currentRenderTargetSize.y);
				reflectionDenoiserPassData.currentEffectResolution = new Vector4((float)reflectionDenoiserPassData.texWidth, (float)reflectionDenoiserPassData.texHeight, 1f / (float)reflectionDenoiserPassData.texWidth, 1f / (float)reflectionDenoiserPassData.texHeight);
				reflectionDenoiserPassData.pixelSpreadTangent = HDRenderPipeline.GetPixelSpreadTangent(hdCamera.camera.fieldOfView, reflectionDenoiserPassData.texWidth, reflectionDenoiserPassData.texHeight);
				reflectionDenoiserPassData.affectSmoothSurfaces = (affectSmoothSurfaces ? 1 : 0);
				reflectionDenoiserPassData.singleReflectionBounce = (singleReflectionBounce ? 1 : 0);
				reflectionDenoiserPassData.roughnessBasedDenoising = (float)(singleReflectionBounce ? 1 : 0);
				reflectionDenoiserPassData.reflectionDenoiserCS = this.m_ReflectionDenoiserCS;
				reflectionDenoiserPassData.temporalAccumulationKernel = (fullResolution ? this.s_TemporalAccumulationFullResKernel : this.s_TemporalAccumulationHalfResKernel);
				reflectionDenoiserPassData.copyHistoryKernel = this.s_CopyHistoryKernel;
				reflectionDenoiserPassData.bilateralFilterHKernel = (fullResolution ? this.s_BilateralFilterH_FRKernel : this.s_BilateralFilterH_HRKernel);
				reflectionDenoiserPassData.bilateralFilterVKernel = (fullResolution ? this.s_BilateralFilterV_FRKernel : this.s_BilateralFilterV_HRKernel);
				reflectionDenoiserPassData.reflectionFilterMapping = this.m_ReflectionFilterMapping;
				reflectionDenoiserPassData.depthBuffer = renderGraphBuilder.ReadTexture(depthPyramid);
				reflectionDenoiserPassData.normalBuffer = renderGraphBuilder.ReadTexture(normalBuffer);
				reflectionDenoiserPassData.motionVectorBuffer = renderGraphBuilder.ReadTexture(motionVectorBuffer);
				RTHandle currentFrameRT = hdCamera.GetCurrentFrameRT(6);
				reflectionDenoiserPassData.historyDepth = ((currentFrameRT != null) ? renderGraph.ImportTexture(hdCamera.GetCurrentFrameRT(6)) : renderGraph.defaultResources.blackTextureXR);
				HDReflectionDenoiser.ReflectionDenoiserPassData reflectionDenoiserPassData3 = reflectionDenoiserPassData;
				TextureDesc textureDesc = new TextureDesc(Vector2.one, true, true);
				textureDesc.colorFormat = GraphicsFormat.R16G16B16A16_SFloat;
				textureDesc.enableRandomWrite = true;
				textureDesc.name = "IntermediateTexture0";
				reflectionDenoiserPassData3.intermediateBuffer0 = renderGraphBuilder.CreateTransientTexture(textureDesc);
				HDReflectionDenoiser.ReflectionDenoiserPassData reflectionDenoiserPassData4 = reflectionDenoiserPassData;
				textureDesc = new TextureDesc(Vector2.one, true, true);
				textureDesc.colorFormat = GraphicsFormat.R16G16B16A16_SFloat;
				textureDesc.enableRandomWrite = true;
				textureDesc.name = "IntermediateTexture1";
				reflectionDenoiserPassData4.intermediateBuffer1 = renderGraphBuilder.CreateTransientTexture(textureDesc);
				HDReflectionDenoiser.ReflectionDenoiserPassData reflectionDenoiserPassData5 = reflectionDenoiserPassData;
				result = renderGraph.ImportTexture(historyBuffer);
				reflectionDenoiserPassData5.historySignal = renderGraphBuilder.ReadWriteTexture(result);
				reflectionDenoiserPassData.noisyToOutputSignal = renderGraphBuilder.ReadWriteTexture(lightingTexture);
				renderGraphBuilder.SetRenderFunc<HDReflectionDenoiser.ReflectionDenoiserPassData>(delegate(HDReflectionDenoiser.ReflectionDenoiserPassData data, RenderGraphContext ctx)
				{
					int num3 = 8;
					int threadGroupsX = (data.texWidth + (num3 - 1)) / num3;
					int threadGroupsY = (data.texHeight + (num3 - 1)) / num3;
					ctx.cmd.SetComputeFloatParam(data.reflectionDenoiserCS, HDShaderIDs._HistoryValidity, data.historyValidity);
					ctx.cmd.SetComputeFloatParam(data.reflectionDenoiserCS, HDShaderIDs._PixelSpreadAngleTangent, data.pixelSpreadTangent);
					ctx.cmd.SetComputeVectorParam(data.reflectionDenoiserCS, HDShaderIDs._HistoryBufferSize, data.historyBufferSize);
					ctx.cmd.SetComputeVectorParam(data.reflectionDenoiserCS, HDShaderIDs._CurrentEffectResolution, data.currentEffectResolution);
					ctx.cmd.SetComputeVectorParam(data.reflectionDenoiserCS, HDShaderIDs._HistorySizeAndScale, data.historySizeAndScale);
					ctx.cmd.SetComputeIntParam(data.reflectionDenoiserCS, HDShaderIDs._AffectSmoothSurfaces, data.affectSmoothSurfaces);
					ctx.cmd.SetComputeIntParam(data.reflectionDenoiserCS, HDShaderIDs._SingleReflectionBounce, data.singleReflectionBounce);
					ctx.cmd.SetComputeTextureParam(data.reflectionDenoiserCS, data.temporalAccumulationKernel, HDShaderIDs._DenoiseInputTexture, data.noisyToOutputSignal);
					ctx.cmd.SetComputeTextureParam(data.reflectionDenoiserCS, data.temporalAccumulationKernel, HDShaderIDs._DepthTexture, data.depthBuffer);
					ctx.cmd.SetComputeTextureParam(data.reflectionDenoiserCS, data.temporalAccumulationKernel, HDShaderIDs._HistoryDepthTexture, data.historyDepth);
					ctx.cmd.SetComputeTextureParam(data.reflectionDenoiserCS, data.temporalAccumulationKernel, HDShaderIDs._NormalBufferTexture, data.normalBuffer);
					ctx.cmd.SetComputeTextureParam(data.reflectionDenoiserCS, data.temporalAccumulationKernel, HDShaderIDs._CameraMotionVectorsTexture, data.motionVectorBuffer);
					ctx.cmd.SetComputeTextureParam(data.reflectionDenoiserCS, data.temporalAccumulationKernel, HDShaderIDs._HistoryBuffer, data.historySignal);
					ctx.cmd.SetComputeTextureParam(data.reflectionDenoiserCS, data.temporalAccumulationKernel, HDShaderIDs._DenoiseOutputTextureRW, data.intermediateBuffer0);
					ctx.cmd.SetComputeTextureParam(data.reflectionDenoiserCS, data.temporalAccumulationKernel, HDShaderIDs._SampleCountTextureRW, data.intermediateBuffer1);
					ctx.cmd.DispatchCompute(data.reflectionDenoiserCS, data.temporalAccumulationKernel, threadGroupsX, threadGroupsY, data.viewCount);
					ctx.cmd.SetComputeTextureParam(data.reflectionDenoiserCS, data.copyHistoryKernel, HDShaderIDs._DenoiseInputTexture, data.intermediateBuffer0);
					ctx.cmd.SetComputeTextureParam(data.reflectionDenoiserCS, data.copyHistoryKernel, HDShaderIDs._DenoiseOutputTextureRW, data.historySignal);
					ctx.cmd.SetComputeTextureParam(data.reflectionDenoiserCS, data.copyHistoryKernel, HDShaderIDs._SampleCountTextureRW, data.intermediateBuffer1);
					ctx.cmd.DispatchCompute(data.reflectionDenoiserCS, data.copyHistoryKernel, threadGroupsX, threadGroupsY, data.viewCount);
					ctx.cmd.SetComputeIntParam(data.reflectionDenoiserCS, HDShaderIDs._DenoiserFilterRadius, data.maxKernelSize);
					ctx.cmd.SetComputeFloatParam(data.reflectionDenoiserCS, HDShaderIDs._RoughnessBasedDenoising, data.roughnessBasedDenoising);
					ctx.cmd.SetComputeTextureParam(data.reflectionDenoiserCS, data.bilateralFilterHKernel, HDShaderIDs._DenoiseInputTexture, data.intermediateBuffer0);
					ctx.cmd.SetComputeTextureParam(data.reflectionDenoiserCS, data.bilateralFilterHKernel, HDShaderIDs._DepthTexture, data.depthBuffer);
					ctx.cmd.SetComputeTextureParam(data.reflectionDenoiserCS, data.bilateralFilterHKernel, HDShaderIDs._NormalBufferTexture, data.normalBuffer);
					ctx.cmd.SetComputeTextureParam(data.reflectionDenoiserCS, data.bilateralFilterHKernel, HDShaderIDs._DenoiseOutputTextureRW, data.intermediateBuffer1);
					ctx.cmd.SetComputeTextureParam(data.reflectionDenoiserCS, data.bilateralFilterHKernel, HDShaderIDs._ReflectionFilterMapping, data.reflectionFilterMapping);
					ctx.cmd.DispatchCompute(data.reflectionDenoiserCS, data.bilateralFilterHKernel, threadGroupsX, threadGroupsY, data.viewCount);
					ctx.cmd.SetComputeIntParam(data.reflectionDenoiserCS, HDShaderIDs._DenoiserFilterRadius, data.maxKernelSize);
					ctx.cmd.SetComputeFloatParam(data.reflectionDenoiserCS, HDShaderIDs._RoughnessBasedDenoising, data.roughnessBasedDenoising);
					ctx.cmd.SetComputeTextureParam(data.reflectionDenoiserCS, data.bilateralFilterVKernel, HDShaderIDs._DenoiseInputTexture, data.intermediateBuffer1);
					ctx.cmd.SetComputeTextureParam(data.reflectionDenoiserCS, data.bilateralFilterVKernel, HDShaderIDs._DepthTexture, data.depthBuffer);
					ctx.cmd.SetComputeTextureParam(data.reflectionDenoiserCS, data.bilateralFilterVKernel, HDShaderIDs._NormalBufferTexture, data.normalBuffer);
					ctx.cmd.SetComputeTextureParam(data.reflectionDenoiserCS, data.bilateralFilterVKernel, HDShaderIDs._DenoiseOutputTextureRW, data.noisyToOutputSignal);
					ctx.cmd.SetComputeTextureParam(data.reflectionDenoiserCS, data.bilateralFilterVKernel, HDShaderIDs._ReflectionFilterMapping, data.reflectionFilterMapping);
					ctx.cmd.DispatchCompute(data.reflectionDenoiserCS, data.bilateralFilterVKernel, threadGroupsX, threadGroupsY, data.viewCount);
				});
				result = reflectionDenoiserPassData.noisyToOutputSignal;
			}
			return result;
		}

		// Token: 0x04001342 RID: 4930
		private ComputeShader m_ReflectionDenoiserCS;

		// Token: 0x04001343 RID: 4931
		private Texture2D m_ReflectionFilterMapping;

		// Token: 0x04001344 RID: 4932
		private int s_TemporalAccumulationFullResKernel;

		// Token: 0x04001345 RID: 4933
		private int s_TemporalAccumulationHalfResKernel;

		// Token: 0x04001346 RID: 4934
		private int s_CopyHistoryKernel;

		// Token: 0x04001347 RID: 4935
		private int s_BilateralFilterH_FRKernel;

		// Token: 0x04001348 RID: 4936
		private int s_BilateralFilterV_FRKernel;

		// Token: 0x04001349 RID: 4937
		private int s_BilateralFilterH_HRKernel;

		// Token: 0x0400134A RID: 4938
		private int s_BilateralFilterV_HRKernel;

		// Token: 0x020003D2 RID: 978
		private class ReflectionDenoiserPassData
		{
			// Token: 0x040027B6 RID: 10166
			public int texWidth;

			// Token: 0x040027B7 RID: 10167
			public int texHeight;

			// Token: 0x040027B8 RID: 10168
			public int viewCount;

			// Token: 0x040027B9 RID: 10169
			public int maxKernelSize;

			// Token: 0x040027BA RID: 10170
			public float historyValidity;

			// Token: 0x040027BB RID: 10171
			public Vector4 historySizeAndScale;

			// Token: 0x040027BC RID: 10172
			public Vector2 historyBufferSize;

			// Token: 0x040027BD RID: 10173
			public Vector4 currentEffectResolution;

			// Token: 0x040027BE RID: 10174
			public float pixelSpreadTangent;

			// Token: 0x040027BF RID: 10175
			public int affectSmoothSurfaces;

			// Token: 0x040027C0 RID: 10176
			public int singleReflectionBounce;

			// Token: 0x040027C1 RID: 10177
			public float roughnessBasedDenoising;

			// Token: 0x040027C2 RID: 10178
			public ComputeShader reflectionDenoiserCS;

			// Token: 0x040027C3 RID: 10179
			public int temporalAccumulationKernel;

			// Token: 0x040027C4 RID: 10180
			public int copyHistoryKernel;

			// Token: 0x040027C5 RID: 10181
			public int bilateralFilterHKernel;

			// Token: 0x040027C6 RID: 10182
			public int bilateralFilterVKernel;

			// Token: 0x040027C7 RID: 10183
			public Texture2D reflectionFilterMapping;

			// Token: 0x040027C8 RID: 10184
			public TextureHandle depthBuffer;

			// Token: 0x040027C9 RID: 10185
			public TextureHandle historyDepth;

			// Token: 0x040027CA RID: 10186
			public TextureHandle normalBuffer;

			// Token: 0x040027CB RID: 10187
			public TextureHandle motionVectorBuffer;

			// Token: 0x040027CC RID: 10188
			public TextureHandle intermediateBuffer0;

			// Token: 0x040027CD RID: 10189
			public TextureHandle intermediateBuffer1;

			// Token: 0x040027CE RID: 10190
			public TextureHandle historySignal;

			// Token: 0x040027CF RID: 10191
			public TextureHandle noisyToOutputSignal;
		}
	}
}
