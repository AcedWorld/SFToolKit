using System;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200017E RID: 382
	internal class HDTemporalFilter
	{
		// Token: 0x06000C6C RID: 3180 RVA: 0x00067B4C File Offset: 0x00065D4C
		public void Init(HDRenderPipelineRuntimeResources rpResources)
		{
			this.m_TemporalFilterCS = rpResources.shaders.temporalFilterCS;
			this.m_ValidateHistoryKernel = this.m_TemporalFilterCS.FindKernel("ValidateHistory");
			this.m_TemporalAccumulationSingleKernel = this.m_TemporalFilterCS.FindKernel("TemporalAccumulationSingle");
			this.m_TemporalAccumulationColorKernel = this.m_TemporalFilterCS.FindKernel("TemporalAccumulationColor");
			this.m_CopyHistoryKernel = this.m_TemporalFilterCS.FindKernel("CopyHistory");
			this.m_TemporalAccumulationSingleArrayKernel = this.m_TemporalFilterCS.FindKernel("TemporalAccumulationSingleArray");
			this.m_TemporalAccumulationColorArrayKernel = this.m_TemporalFilterCS.FindKernel("TemporalAccumulationColorArray");
			this.m_BlendHistorySingleArrayKernel = this.m_TemporalFilterCS.FindKernel("BlendHistorySingleArray");
			this.m_BlendHistoryColorArrayKernel = this.m_TemporalFilterCS.FindKernel("BlendHistoryColorArray");
			this.m_BlendHistorySingleArrayNoValidityKernel = this.m_TemporalFilterCS.FindKernel("BlendHistorySingleArrayNoValidity");
			this.m_OutputHistoryArrayKernel = this.m_TemporalFilterCS.FindKernel("OutputHistoryArray");
		}

		// Token: 0x06000C6D RID: 3181 RVA: 0x00067C46 File Offset: 0x00065E46
		public void Release()
		{
		}

		// Token: 0x06000C6E RID: 3182 RVA: 0x00067C48 File Offset: 0x00065E48
		public TextureHandle HistoryValidity(RenderGraph renderGraph, HDCamera hdCamera, float historyValidity, TextureHandle depthBuffer, TextureHandle normalBuffer, TextureHandle motionVectorBuffer)
		{
			HDTemporalFilter.HistoryValidityPassData historyValidityPassData;
			TextureHandle result;
			using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<HDTemporalFilter.HistoryValidityPassData>("History Validity Evaluation", out historyValidityPassData, ProfilingSampler.Get<HDProfileId>(HDProfileId.HistoryValidity)))
			{
				renderGraphBuilder.EnableAsyncCompute(false);
				historyValidityPassData.texWidth = hdCamera.actualWidth;
				historyValidityPassData.texHeight = hdCamera.actualHeight;
				historyValidityPassData.viewCount = hdCamera.viewCount;
				historyValidityPassData.pixelSpreadTangent = HDRenderPipeline.GetPixelSpreadTangent(hdCamera.camera.fieldOfView, hdCamera.actualWidth, hdCamera.actualHeight);
				historyValidityPassData.historyValidity = historyValidity;
				historyValidityPassData.validateHistoryKernel = this.m_ValidateHistoryKernel;
				historyValidityPassData.temporalFilterCS = this.m_TemporalFilterCS;
				historyValidityPassData.depthStencilBuffer = renderGraphBuilder.ReadTexture(depthBuffer);
				historyValidityPassData.normalBuffer = renderGraphBuilder.ReadTexture(normalBuffer);
				if (hdCamera.frameSettings.IsEnabled(FrameSettingsField.MotionVectors))
				{
					historyValidityPassData.motionVectorBuffer = renderGraphBuilder.ReadTexture(motionVectorBuffer);
				}
				else
				{
					HDTemporalFilter.HistoryValidityPassData historyValidityPassData2 = historyValidityPassData;
					result = renderGraph.defaultResources.blackTextureXR;
					historyValidityPassData2.motionVectorBuffer = renderGraphBuilder.ReadTexture(result);
				}
				RTHandle currentFrameRT = hdCamera.GetCurrentFrameRT(6);
				RTHandle currentFrameRT2 = hdCamera.GetCurrentFrameRT(5);
				HDTemporalFilter.HistoryValidityPassData historyValidityPassData3 = historyValidityPassData;
				result = renderGraph.ImportTexture(currentFrameRT);
				historyValidityPassData3.historyDepthTexture = renderGraphBuilder.ReadTexture(result);
				HDTemporalFilter.HistoryValidityPassData historyValidityPassData4 = historyValidityPassData;
				result = renderGraph.ImportTexture(currentFrameRT2);
				historyValidityPassData4.historyNormalTexture = renderGraphBuilder.ReadTexture(result);
				historyValidityPassData.historySizeAndScale = ((currentFrameRT != null && currentFrameRT2 != null) ? HDRenderPipeline.EvaluateRayTracingHistorySizeAndScale(hdCamera, currentFrameRT) : Vector4.one);
				HDTemporalFilter.HistoryValidityPassData historyValidityPassData5 = historyValidityPassData;
				TextureDesc textureDesc = new TextureDesc(Vector2.one, true, true);
				textureDesc.colorFormat = GraphicsFormat.R8_UInt;
				textureDesc.enableRandomWrite = true;
				textureDesc.name = "ValidationTexture";
				result = renderGraph.CreateTexture(textureDesc);
				historyValidityPassData5.validationBuffer = renderGraphBuilder.WriteTexture(result);
				renderGraphBuilder.SetRenderFunc<HDTemporalFilter.HistoryValidityPassData>(delegate(HDTemporalFilter.HistoryValidityPassData data, RenderGraphContext ctx)
				{
					bool flag = data.historyDepthTexture != null;
					RTHandle rthandle = data.historyNormalTexture;
					if (!flag || rthandle == null)
					{
						CoreUtils.SetRenderTarget(ctx.cmd, data.validationBuffer, ClearFlag.Color, Color.black, 0, CubemapFace.Unknown, -1);
						return;
					}
					int num = 8;
					int threadGroupsX = (data.texWidth + (num - 1)) / num;
					int threadGroupsY = (data.texHeight + (num - 1)) / num;
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.validateHistoryKernel, HDShaderIDs._DepthTexture, data.depthStencilBuffer);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.validateHistoryKernel, HDShaderIDs._HistoryDepthTexture, data.historyDepthTexture);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.validateHistoryKernel, HDShaderIDs._NormalBufferTexture, data.normalBuffer);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.validateHistoryKernel, HDShaderIDs._HistoryNormalTexture, data.historyNormalTexture);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.validateHistoryKernel, HDShaderIDs._CameraMotionVectorsTexture, data.motionVectorBuffer);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.validateHistoryKernel, HDShaderIDs._StencilTexture, data.depthStencilBuffer, 0, RenderTextureSubElement.Stencil);
					ctx.cmd.SetComputeFloatParam(data.temporalFilterCS, HDShaderIDs._HistoryValidity, data.historyValidity);
					ctx.cmd.SetComputeFloatParam(data.temporalFilterCS, HDShaderIDs._PixelSpreadAngleTangent, data.pixelSpreadTangent);
					ctx.cmd.SetComputeIntParam(data.temporalFilterCS, HDShaderIDs._ObjectMotionStencilBit, 32);
					ctx.cmd.SetComputeVectorParam(data.temporalFilterCS, HDShaderIDs._HistorySizeAndScale, data.historySizeAndScale);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.validateHistoryKernel, HDShaderIDs._ValidationBufferRW, data.validationBuffer);
					ctx.cmd.DispatchCompute(data.temporalFilterCS, data.validateHistoryKernel, threadGroupsX, threadGroupsY, data.viewCount);
				});
				result = historyValidityPassData.validationBuffer;
			}
			return result;
		}

		// Token: 0x06000C6F RID: 3183 RVA: 0x00067E30 File Offset: 0x00066030
		internal TextureHandle Denoise(RenderGraph renderGraph, HDCamera hdCamera, HDTemporalFilter.TemporalFilterParameters filterParams, TextureHandle noisyBuffer, TextureHandle velocityBuffer, TextureHandle historyBuffer, TextureHandle depthBuffer, TextureHandle normalBuffer, TextureHandle motionVectorBuffer, TextureHandle historyValidationBuffer)
		{
			HDTemporalFilter.TemporalFilterPassData temporalFilterPassData;
			TextureHandle result;
			using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<HDTemporalFilter.TemporalFilterPassData>("TemporalDenoiser", out temporalFilterPassData, ProfilingSampler.Get<HDProfileId>(HDProfileId.TemporalFilter)))
			{
				renderGraphBuilder.EnableAsyncCompute(false);
				temporalFilterPassData.texWidth = (int)Mathf.Floor((float)hdCamera.actualWidth * filterParams.resolutionMultiplier);
				temporalFilterPassData.texHeight = (int)Mathf.Floor((float)hdCamera.actualHeight * filterParams.resolutionMultiplier);
				temporalFilterPassData.viewCount = hdCamera.viewCount;
				temporalFilterPassData.pixelSpreadTangent = HDRenderPipeline.GetPixelSpreadTangent(hdCamera.camera.fieldOfView, temporalFilterPassData.texWidth, temporalFilterPassData.texHeight);
				temporalFilterPassData.historyValidity = filterParams.historyValidity;
				temporalFilterPassData.receiverMotionRejection = filterParams.receiverMotionRejection;
				temporalFilterPassData.occluderMotionRejection = filterParams.occluderMotionRejection;
				temporalFilterPassData.exposureControl = (filterParams.exposureControl ? 1 : 0);
				temporalFilterPassData.resolutionMultiplier = filterParams.resolutionMultiplier;
				temporalFilterPassData.historyResolutionMultiplier = filterParams.historyResolutionMultiplier;
				temporalFilterPassData.temporalAccKernel = (filterParams.singleChannel ? this.m_TemporalAccumulationSingleKernel : this.m_TemporalAccumulationColorKernel);
				temporalFilterPassData.copyHistoryKernel = this.m_CopyHistoryKernel;
				temporalFilterPassData.temporalFilterCS = this.m_TemporalFilterCS;
				temporalFilterPassData.depthStencilBuffer = renderGraphBuilder.ReadTexture(depthBuffer);
				temporalFilterPassData.normalBuffer = renderGraphBuilder.ReadTexture(normalBuffer);
				temporalFilterPassData.motionVectorBuffer = renderGraphBuilder.ReadTexture(motionVectorBuffer);
				temporalFilterPassData.velocityBuffer = renderGraphBuilder.ReadTexture(velocityBuffer);
				temporalFilterPassData.noisyBuffer = renderGraphBuilder.ReadTexture(noisyBuffer);
				temporalFilterPassData.validationBuffer = renderGraphBuilder.ReadTexture(historyValidationBuffer);
				temporalFilterPassData.historyBuffer = renderGraphBuilder.ReadWriteTexture(historyBuffer);
				HDTemporalFilter.TemporalFilterPassData temporalFilterPassData2 = temporalFilterPassData;
				TextureDesc textureDesc = new TextureDesc(Vector2.one, true, true);
				textureDesc.colorFormat = GraphicsFormat.R16G16B16A16_SFloat;
				textureDesc.enableRandomWrite = true;
				textureDesc.name = "Temporal Filter Output";
				result = renderGraph.CreateTexture(textureDesc);
				temporalFilterPassData2.outputBuffer = renderGraphBuilder.ReadWriteTexture(result);
				renderGraphBuilder.SetRenderFunc<HDTemporalFilter.TemporalFilterPassData>(delegate(HDTemporalFilter.TemporalFilterPassData data, RenderGraphContext ctx)
				{
					int num = 8;
					int threadGroupsX = (data.texWidth + (num - 1)) / num;
					int threadGroupsY = (data.texHeight + (num - 1)) / num;
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccKernel, HDShaderIDs._DenoiseInputTexture, data.noisyBuffer);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccKernel, HDShaderIDs._HistoryBuffer, data.historyBuffer);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccKernel, HDShaderIDs._DepthTexture, data.depthStencilBuffer);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccKernel, HDShaderIDs._ValidationBuffer, data.validationBuffer);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccKernel, HDShaderIDs._VelocityBuffer, data.velocityBuffer);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccKernel, HDShaderIDs._CameraMotionVectorsTexture, data.motionVectorBuffer);
					ctx.cmd.SetComputeFloatParam(data.temporalFilterCS, HDShaderIDs._HistoryValidity, data.historyValidity);
					ctx.cmd.SetComputeIntParam(data.temporalFilterCS, HDShaderIDs._ReceiverMotionRejection, data.receiverMotionRejection ? 1 : 0);
					ctx.cmd.SetComputeIntParam(data.temporalFilterCS, HDShaderIDs._OccluderMotionRejection, data.occluderMotionRejection ? 1 : 0);
					ctx.cmd.SetComputeFloatParam(data.temporalFilterCS, HDShaderIDs._PixelSpreadAngleTangent, data.pixelSpreadTangent);
					ctx.cmd.SetComputeVectorParam(data.temporalFilterCS, HDShaderIDs._DenoiserResolutionMultiplierVals, new Vector4(data.resolutionMultiplier, 1f / data.resolutionMultiplier, data.historyResolutionMultiplier, 1f / data.historyResolutionMultiplier));
					ctx.cmd.SetComputeIntParam(data.temporalFilterCS, HDShaderIDs._EnableExposureControl, data.exposureControl);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccKernel, HDShaderIDs._AccumulationOutputTextureRW, data.outputBuffer);
					ctx.cmd.DispatchCompute(data.temporalFilterCS, data.temporalAccKernel, threadGroupsX, threadGroupsY, data.viewCount);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.copyHistoryKernel, HDShaderIDs._DenoiseInputTexture, data.outputBuffer);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.copyHistoryKernel, HDShaderIDs._DenoiseOutputTextureRW, data.historyBuffer);
					ctx.cmd.DispatchCompute(data.temporalFilterCS, data.copyHistoryKernel, threadGroupsX, threadGroupsY, data.viewCount);
				});
				result = temporalFilterPassData.outputBuffer;
			}
			return result;
		}

		// Token: 0x06000C70 RID: 3184 RVA: 0x00068044 File Offset: 0x00066244
		public HDTemporalFilter.TemporalDenoiserArrayOutputData DenoiseBuffer(RenderGraph renderGraph, HDCamera hdCamera, TextureHandle depthBuffer, TextureHandle normalBuffer, TextureHandle motionVectorBuffer, TextureHandle historyValidationBuffer, TextureHandle noisyBuffer, RTHandle historyBuffer, TextureHandle distanceBuffer, RTHandle distanceHistorySignal, TextureHandle velocityBuffer, RTHandle validationHistoryBuffer, int sliceIndex, Vector4 channelMask, Vector4 distanceChannelMask, bool distanceBased, bool singleChannel, float historyValidity)
		{
			HDTemporalFilter.TemporalDenoiserArrayOutputData result = default(HDTemporalFilter.TemporalDenoiserArrayOutputData);
			HDTemporalFilter.TemporalFilterArrayPassData temporalFilterArrayPassData;
			using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<HDTemporalFilter.TemporalFilterArrayPassData>("TemporalDenoiser", out temporalFilterArrayPassData, ProfilingSampler.Get<HDProfileId>(HDProfileId.TemporalFilter)))
			{
				renderGraphBuilder.EnableAsyncCompute(false);
				temporalFilterArrayPassData.texWidth = hdCamera.actualWidth;
				temporalFilterArrayPassData.texHeight = hdCamera.actualHeight;
				temporalFilterArrayPassData.viewCount = hdCamera.viewCount;
				temporalFilterArrayPassData.distanceBasedDenoiser = distanceBased;
				temporalFilterArrayPassData.historyValidity = historyValidity;
				temporalFilterArrayPassData.pixelSpreadTangent = HDRenderPipeline.GetPixelSpreadTangent(hdCamera.camera.fieldOfView, hdCamera.actualWidth, hdCamera.actualHeight);
				temporalFilterArrayPassData.sliceIndex = sliceIndex;
				temporalFilterArrayPassData.channelMask = channelMask;
				temporalFilterArrayPassData.distanceChannelMask = distanceChannelMask;
				temporalFilterArrayPassData.temporalAccKernel = (singleChannel ? this.m_TemporalAccumulationSingleArrayKernel : this.m_TemporalAccumulationColorArrayKernel);
				temporalFilterArrayPassData.blendHistoryKernel = (singleChannel ? this.m_BlendHistorySingleArrayKernel : this.m_BlendHistoryColorArrayKernel);
				temporalFilterArrayPassData.temporalAccSingleKernel = this.m_TemporalAccumulationSingleArrayKernel;
				temporalFilterArrayPassData.blendHistoryNoValidityKernel = this.m_BlendHistorySingleArrayNoValidityKernel;
				temporalFilterArrayPassData.outputHistoryKernel = this.m_OutputHistoryArrayKernel;
				temporalFilterArrayPassData.temporalFilterCS = this.m_TemporalFilterCS;
				temporalFilterArrayPassData.depthStencilBuffer = renderGraphBuilder.ReadTexture(depthBuffer);
				temporalFilterArrayPassData.normalBuffer = renderGraphBuilder.ReadTexture(normalBuffer);
				temporalFilterArrayPassData.motionVectorBuffer = renderGraphBuilder.ReadTexture(motionVectorBuffer);
				temporalFilterArrayPassData.velocityBuffer = renderGraphBuilder.ReadTexture(velocityBuffer);
				temporalFilterArrayPassData.noisyBuffer = renderGraphBuilder.ReadTexture(noisyBuffer);
				temporalFilterArrayPassData.distanceBuffer = (distanceBased ? renderGraphBuilder.ReadTexture(distanceBuffer) : renderGraph.defaultResources.blackTextureXR);
				temporalFilterArrayPassData.validationBuffer = renderGraphBuilder.ReadTexture(historyValidationBuffer);
				HDTemporalFilter.TemporalFilterArrayPassData temporalFilterArrayPassData2 = temporalFilterArrayPassData;
				TextureHandle textureHandle = renderGraph.ImportTexture(historyBuffer);
				temporalFilterArrayPassData2.outputHistoryBuffer = renderGraphBuilder.ReadWriteTexture(textureHandle);
				temporalFilterArrayPassData.inputHistoryBuffer = temporalFilterArrayPassData.outputHistoryBuffer;
				HDTemporalFilter.TemporalFilterArrayPassData temporalFilterArrayPassData3 = temporalFilterArrayPassData;
				textureHandle = renderGraph.ImportTexture(validationHistoryBuffer);
				temporalFilterArrayPassData3.validationHistoryBuffer = renderGraphBuilder.ReadWriteTexture(textureHandle);
				HDTemporalFilter.TemporalFilterArrayPassData temporalFilterArrayPassData4 = temporalFilterArrayPassData;
				TextureHandle distanceHistorySignal2;
				if (!distanceBased)
				{
					distanceHistorySignal2 = renderGraph.defaultResources.blackTextureXR;
				}
				else
				{
					textureHandle = renderGraph.ImportTexture(distanceHistorySignal);
					distanceHistorySignal2 = renderGraphBuilder.ReadWriteTexture(textureHandle);
				}
				temporalFilterArrayPassData4.distanceHistorySignal = distanceHistorySignal2;
				HDTemporalFilter.TemporalFilterArrayPassData temporalFilterArrayPassData5 = temporalFilterArrayPassData;
				TextureDesc textureDesc = new TextureDesc(Vector2.one, true, true);
				textureDesc.colorFormat = GraphicsFormat.R16G16B16A16_SFloat;
				textureDesc.enableRandomWrite = true;
				textureDesc.name = "Intermediate Filter Output";
				temporalFilterArrayPassData5.intermediateSignalOutput = renderGraphBuilder.CreateTransientTexture(textureDesc);
				HDTemporalFilter.TemporalFilterArrayPassData temporalFilterArrayPassData6 = temporalFilterArrayPassData;
				textureDesc = new TextureDesc(Vector2.one, true, true);
				textureDesc.colorFormat = GraphicsFormat.R16G16B16A16_SFloat;
				textureDesc.enableRandomWrite = true;
				textureDesc.name = "Intermediate Validity output";
				temporalFilterArrayPassData6.intermediateValidityOutput = renderGraphBuilder.CreateTransientTexture(textureDesc);
				HDTemporalFilter.TemporalFilterArrayPassData temporalFilterArrayPassData7 = temporalFilterArrayPassData;
				textureDesc = new TextureDesc(Vector2.one, true, true);
				textureDesc.colorFormat = GraphicsFormat.R16G16B16A16_SFloat;
				textureDesc.enableRandomWrite = true;
				textureDesc.name = "Temporal Filter Output";
				textureHandle = renderGraph.CreateTexture(textureDesc);
				temporalFilterArrayPassData7.outputBuffer = renderGraphBuilder.ReadWriteTexture(textureHandle);
				HDTemporalFilter.TemporalFilterArrayPassData temporalFilterArrayPassData8 = temporalFilterArrayPassData;
				TextureHandle outputDistanceSignal;
				if (!distanceBased)
				{
					textureHandle = default(TextureHandle);
					outputDistanceSignal = textureHandle;
				}
				else
				{
					textureDesc = new TextureDesc(Vector2.one, true, true);
					textureDesc.colorFormat = GraphicsFormat.R16G16B16A16_SFloat;
					textureDesc.enableRandomWrite = true;
					textureDesc.name = "Temporal Filter Distance output";
					textureHandle = renderGraph.CreateTexture(textureDesc);
					outputDistanceSignal = renderGraphBuilder.ReadWriteTexture(textureHandle);
				}
				temporalFilterArrayPassData8.outputDistanceSignal = outputDistanceSignal;
				renderGraphBuilder.SetRenderFunc<HDTemporalFilter.TemporalFilterArrayPassData>(delegate(HDTemporalFilter.TemporalFilterArrayPassData data, RenderGraphContext ctx)
				{
					int num = 8;
					int threadGroupsX = (data.texWidth + (num - 1)) / num;
					int threadGroupsY = (data.texHeight + (num - 1)) / num;
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccKernel, HDShaderIDs._DenoiseInputTexture, data.noisyBuffer);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccKernel, HDShaderIDs._HistoryBuffer, data.inputHistoryBuffer);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccKernel, HDShaderIDs._HistoryValidityBuffer, data.validationHistoryBuffer);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccKernel, HDShaderIDs._DepthTexture, data.depthStencilBuffer);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccKernel, HDShaderIDs._CameraMotionVectorsTexture, data.motionVectorBuffer);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccKernel, HDShaderIDs._ValidationBuffer, data.validationBuffer);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccKernel, HDShaderIDs._VelocityBuffer, data.velocityBuffer);
					ctx.cmd.SetComputeIntParam(data.temporalFilterCS, HDShaderIDs._DenoisingHistorySlice, data.sliceIndex);
					ctx.cmd.SetComputeVectorParam(data.temporalFilterCS, HDShaderIDs._DenoisingHistoryMask, data.channelMask);
					ctx.cmd.SetComputeFloatParam(data.temporalFilterCS, HDShaderIDs._HistoryValidity, data.historyValidity);
					ctx.cmd.SetComputeIntParam(data.temporalFilterCS, HDShaderIDs._ReceiverMotionRejection, 1);
					ctx.cmd.SetComputeIntParam(data.temporalFilterCS, HDShaderIDs._OccluderMotionRejection, 1);
					ctx.cmd.SetComputeVectorParam(data.temporalFilterCS, HDShaderIDs._DenoiserResolutionMultiplierVals, Vector4.one);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccKernel, HDShaderIDs._AccumulationOutputTextureRW, data.outputBuffer);
					ctx.cmd.DispatchCompute(data.temporalFilterCS, data.temporalAccKernel, threadGroupsX, threadGroupsY, data.viewCount);
					ctx.cmd.SetComputeIntParam(data.temporalFilterCS, HDShaderIDs._DenoisingHistorySlice, data.sliceIndex);
					ctx.cmd.SetComputeVectorParam(data.temporalFilterCS, HDShaderIDs._DenoisingHistoryMask, data.channelMask);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.blendHistoryKernel, HDShaderIDs._DenoiseInputTexture, data.outputBuffer);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.blendHistoryKernel, HDShaderIDs._DenoiseInputArrayTexture, data.inputHistoryBuffer);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.blendHistoryKernel, HDShaderIDs._ValidityInputArrayTexture, data.validationHistoryBuffer);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.blendHistoryKernel, HDShaderIDs._IntermediateDenoiseOutputTextureRW, data.intermediateSignalOutput);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.blendHistoryKernel, HDShaderIDs._IntermediateValidityOutputTextureRW, data.intermediateValidityOutput);
					ctx.cmd.DispatchCompute(data.temporalFilterCS, data.blendHistoryKernel, threadGroupsX, threadGroupsY, data.viewCount);
					ctx.cmd.SetComputeIntParam(data.temporalFilterCS, HDShaderIDs._DenoisingHistorySlice, data.sliceIndex);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.outputHistoryKernel, HDShaderIDs._IntermediateDenoiseOutputTexture, data.intermediateSignalOutput);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.outputHistoryKernel, HDShaderIDs._IntermediateValidityOutputTexture, data.intermediateValidityOutput);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.outputHistoryKernel, HDShaderIDs._DenoiseOutputArrayTextureRW, data.outputHistoryBuffer);
					ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.outputHistoryKernel, HDShaderIDs._ValidityOutputTextureRW, data.validationHistoryBuffer);
					ctx.cmd.DispatchCompute(data.temporalFilterCS, data.outputHistoryKernel, threadGroupsX, threadGroupsY, data.viewCount);
					if (data.distanceBasedDenoiser)
					{
						ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccSingleKernel, HDShaderIDs._DenoiseInputTexture, data.distanceBuffer);
						ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccSingleKernel, HDShaderIDs._HistoryBuffer, data.distanceHistorySignal);
						ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccSingleKernel, HDShaderIDs._HistoryValidityBuffer, data.validationHistoryBuffer);
						ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccSingleKernel, HDShaderIDs._DepthTexture, data.depthStencilBuffer);
						ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccSingleKernel, HDShaderIDs._ValidationBuffer, data.validationBuffer);
						ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccSingleKernel, HDShaderIDs._VelocityBuffer, data.velocityBuffer);
						ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccSingleKernel, HDShaderIDs._CameraMotionVectorsTexture, data.motionVectorBuffer);
						ctx.cmd.SetComputeIntParam(data.temporalFilterCS, HDShaderIDs._DenoisingHistorySlice, data.sliceIndex);
						ctx.cmd.SetComputeVectorParam(data.temporalFilterCS, HDShaderIDs._DenoisingHistoryMask, data.distanceChannelMask);
						ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.temporalAccSingleKernel, HDShaderIDs._AccumulationOutputTextureRW, data.outputDistanceSignal);
						ctx.cmd.DispatchCompute(data.temporalFilterCS, data.temporalAccSingleKernel, threadGroupsX, threadGroupsY, data.viewCount);
						ctx.cmd.SetComputeIntParam(data.temporalFilterCS, HDShaderIDs._DenoisingHistorySlice, data.sliceIndex);
						ctx.cmd.SetComputeVectorParam(data.temporalFilterCS, HDShaderIDs._DenoisingHistoryMask, data.distanceChannelMask);
						ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.blendHistoryNoValidityKernel, HDShaderIDs._DenoiseInputTexture, data.outputDistanceSignal);
						ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.blendHistoryNoValidityKernel, HDShaderIDs._DenoiseInputArrayTexture, data.distanceHistorySignal);
						ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.blendHistoryNoValidityKernel, HDShaderIDs._IntermediateDenoiseOutputTextureRW, data.intermediateSignalOutput);
						ctx.cmd.DispatchCompute(data.temporalFilterCS, data.blendHistoryNoValidityKernel, threadGroupsX, threadGroupsY, data.viewCount);
						ctx.cmd.SetComputeIntParam(data.temporalFilterCS, HDShaderIDs._DenoisingHistorySlice, data.sliceIndex);
						ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.outputHistoryKernel, HDShaderIDs._IntermediateDenoiseOutputTexture, data.intermediateSignalOutput);
						ctx.cmd.SetComputeTextureParam(data.temporalFilterCS, data.outputHistoryKernel, HDShaderIDs._DenoiseOutputArrayTextureRW, data.distanceHistorySignal);
						ctx.cmd.DispatchCompute(data.temporalFilterCS, data.outputHistoryKernel, threadGroupsX, threadGroupsY, data.viewCount);
					}
				});
				result.outputSignal = temporalFilterArrayPassData.outputBuffer;
				result.outputSignalDistance = temporalFilterArrayPassData.outputDistanceSignal;
			}
			return result;
		}

		// Token: 0x0400134B RID: 4939
		private ComputeShader m_TemporalFilterCS;

		// Token: 0x0400134C RID: 4940
		private int m_ValidateHistoryKernel;

		// Token: 0x0400134D RID: 4941
		private int m_TemporalAccumulationSingleKernel;

		// Token: 0x0400134E RID: 4942
		private int m_TemporalAccumulationColorKernel;

		// Token: 0x0400134F RID: 4943
		private int m_CopyHistoryKernel;

		// Token: 0x04001350 RID: 4944
		private int m_TemporalAccumulationSingleArrayKernel;

		// Token: 0x04001351 RID: 4945
		private int m_TemporalAccumulationColorArrayKernel;

		// Token: 0x04001352 RID: 4946
		private int m_BlendHistorySingleArrayKernel;

		// Token: 0x04001353 RID: 4947
		private int m_BlendHistoryColorArrayKernel;

		// Token: 0x04001354 RID: 4948
		private int m_BlendHistorySingleArrayNoValidityKernel;

		// Token: 0x04001355 RID: 4949
		private int m_OutputHistoryArrayKernel;

		// Token: 0x020003D4 RID: 980
		[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\RenderPipeline\\Raytracing\\HDTemporalFilter.cs")]
		private enum HistoryRejectionFlags
		{
			// Token: 0x040027D3 RID: 10195
			Depth = 1,
			// Token: 0x040027D4 RID: 10196
			Reprojection,
			// Token: 0x040027D5 RID: 10197
			PreviousDepth = 4,
			// Token: 0x040027D6 RID: 10198
			Position = 8,
			// Token: 0x040027D7 RID: 10199
			Normal = 16,
			// Token: 0x040027D8 RID: 10200
			Motion = 32,
			// Token: 0x040027D9 RID: 10201
			Combined = 63,
			// Token: 0x040027DA RID: 10202
			CombinedNoMotion = 31
		}

		// Token: 0x020003D5 RID: 981
		internal struct TemporalFilterParameters
		{
			// Token: 0x040027DB RID: 10203
			public bool singleChannel;

			// Token: 0x040027DC RID: 10204
			public float historyValidity;

			// Token: 0x040027DD RID: 10205
			public bool occluderMotionRejection;

			// Token: 0x040027DE RID: 10206
			public bool receiverMotionRejection;

			// Token: 0x040027DF RID: 10207
			public bool exposureControl;

			// Token: 0x040027E0 RID: 10208
			public float resolutionMultiplier;

			// Token: 0x040027E1 RID: 10209
			public float historyResolutionMultiplier;
		}

		// Token: 0x020003D6 RID: 982
		private class HistoryValidityPassData
		{
			// Token: 0x040027E2 RID: 10210
			public int texWidth;

			// Token: 0x040027E3 RID: 10211
			public int texHeight;

			// Token: 0x040027E4 RID: 10212
			public int viewCount;

			// Token: 0x040027E5 RID: 10213
			public Vector4 historySizeAndScale;

			// Token: 0x040027E6 RID: 10214
			public float historyValidity;

			// Token: 0x040027E7 RID: 10215
			public float pixelSpreadTangent;

			// Token: 0x040027E8 RID: 10216
			public int validateHistoryKernel;

			// Token: 0x040027E9 RID: 10217
			public ComputeShader temporalFilterCS;

			// Token: 0x040027EA RID: 10218
			public TextureHandle depthStencilBuffer;

			// Token: 0x040027EB RID: 10219
			public TextureHandle normalBuffer;

			// Token: 0x040027EC RID: 10220
			public TextureHandle motionVectorBuffer;

			// Token: 0x040027ED RID: 10221
			public TextureHandle historyDepthTexture;

			// Token: 0x040027EE RID: 10222
			public TextureHandle historyNormalTexture;

			// Token: 0x040027EF RID: 10223
			public TextureHandle validationBuffer;
		}

		// Token: 0x020003D7 RID: 983
		private class TemporalFilterPassData
		{
			// Token: 0x040027F0 RID: 10224
			public int texWidth;

			// Token: 0x040027F1 RID: 10225
			public int texHeight;

			// Token: 0x040027F2 RID: 10226
			public int viewCount;

			// Token: 0x040027F3 RID: 10227
			public float historyValidity;

			// Token: 0x040027F4 RID: 10228
			public float pixelSpreadTangent;

			// Token: 0x040027F5 RID: 10229
			public bool occluderMotionRejection;

			// Token: 0x040027F6 RID: 10230
			public bool receiverMotionRejection;

			// Token: 0x040027F7 RID: 10231
			public int exposureControl;

			// Token: 0x040027F8 RID: 10232
			public float resolutionMultiplier;

			// Token: 0x040027F9 RID: 10233
			public float historyResolutionMultiplier;

			// Token: 0x040027FA RID: 10234
			public int temporalAccKernel;

			// Token: 0x040027FB RID: 10235
			public int copyHistoryKernel;

			// Token: 0x040027FC RID: 10236
			public ComputeShader temporalFilterCS;

			// Token: 0x040027FD RID: 10237
			public TextureHandle depthStencilBuffer;

			// Token: 0x040027FE RID: 10238
			public TextureHandle normalBuffer;

			// Token: 0x040027FF RID: 10239
			public TextureHandle motionVectorBuffer;

			// Token: 0x04002800 RID: 10240
			public TextureHandle velocityBuffer;

			// Token: 0x04002801 RID: 10241
			public TextureHandle noisyBuffer;

			// Token: 0x04002802 RID: 10242
			public TextureHandle validationBuffer;

			// Token: 0x04002803 RID: 10243
			public TextureHandle historyBuffer;

			// Token: 0x04002804 RID: 10244
			public TextureHandle outputBuffer;
		}

		// Token: 0x020003D8 RID: 984
		internal struct TemporalDenoiserArrayOutputData
		{
			// Token: 0x04002805 RID: 10245
			public TextureHandle outputSignal;

			// Token: 0x04002806 RID: 10246
			public TextureHandle outputSignalDistance;
		}

		// Token: 0x020003D9 RID: 985
		private class TemporalFilterArrayPassData
		{
			// Token: 0x04002807 RID: 10247
			public int texWidth;

			// Token: 0x04002808 RID: 10248
			public int texHeight;

			// Token: 0x04002809 RID: 10249
			public int viewCount;

			// Token: 0x0400280A RID: 10250
			public bool distanceBasedDenoiser;

			// Token: 0x0400280B RID: 10251
			public float historyValidity;

			// Token: 0x0400280C RID: 10252
			public float pixelSpreadTangent;

			// Token: 0x0400280D RID: 10253
			public int sliceIndex;

			// Token: 0x0400280E RID: 10254
			public Vector4 channelMask;

			// Token: 0x0400280F RID: 10255
			public Vector4 distanceChannelMask;

			// Token: 0x04002810 RID: 10256
			public int temporalAccKernel;

			// Token: 0x04002811 RID: 10257
			public int blendHistoryKernel;

			// Token: 0x04002812 RID: 10258
			public int temporalAccSingleKernel;

			// Token: 0x04002813 RID: 10259
			public int blendHistoryNoValidityKernel;

			// Token: 0x04002814 RID: 10260
			public int outputHistoryKernel;

			// Token: 0x04002815 RID: 10261
			public ComputeShader temporalFilterCS;

			// Token: 0x04002816 RID: 10262
			public TextureHandle depthStencilBuffer;

			// Token: 0x04002817 RID: 10263
			public TextureHandle normalBuffer;

			// Token: 0x04002818 RID: 10264
			public TextureHandle motionVectorBuffer;

			// Token: 0x04002819 RID: 10265
			public TextureHandle noisyBuffer;

			// Token: 0x0400281A RID: 10266
			public TextureHandle distanceBuffer;

			// Token: 0x0400281B RID: 10267
			public TextureHandle validationBuffer;

			// Token: 0x0400281C RID: 10268
			public TextureHandle velocityBuffer;

			// Token: 0x0400281D RID: 10269
			public TextureHandle inputHistoryBuffer;

			// Token: 0x0400281E RID: 10270
			public TextureHandle outputHistoryBuffer;

			// Token: 0x0400281F RID: 10271
			public TextureHandle validationHistoryBuffer;

			// Token: 0x04002820 RID: 10272
			public TextureHandle distanceHistorySignal;

			// Token: 0x04002821 RID: 10273
			public TextureHandle intermediateSignalOutput;

			// Token: 0x04002822 RID: 10274
			public TextureHandle intermediateValidityOutput;

			// Token: 0x04002823 RID: 10275
			public TextureHandle outputBuffer;

			// Token: 0x04002824 RID: 10276
			public TextureHandle outputDistanceSignal;
		}
	}
}
