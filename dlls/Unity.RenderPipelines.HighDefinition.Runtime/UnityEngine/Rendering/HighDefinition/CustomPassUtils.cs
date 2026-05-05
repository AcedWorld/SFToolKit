using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering.RendererUtils;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200019F RID: 415
	public static class CustomPassUtils
	{
		// Token: 0x06000CDD RID: 3293 RVA: 0x00069650 File Offset: 0x00067850
		internal static void Initialize()
		{
			CustomPassUtils.customPassUtilsMaterial = CoreUtils.CreateEngineMaterial(HDRenderPipelineGlobalSettings.instance.renderPipelineResources.shaders.customPassUtils);
			CustomPassUtils.downSamplePassIndex = CustomPassUtils.customPassUtilsMaterial.FindPass("Downsample");
			CustomPassUtils.verticalBlurPassIndex = CustomPassUtils.customPassUtilsMaterial.FindPass("VerticalBlur");
			CustomPassUtils.horizontalBlurPassIndex = CustomPassUtils.customPassUtilsMaterial.FindPass("HorizontalBlur");
			CustomPassUtils.copyPassIndex = CustomPassUtils.customPassUtilsMaterial.FindPass("Copy");
			CustomPassUtils.copyDepthPassIndex = CustomPassUtils.customPassUtilsMaterial.FindPass("CopyDepth");
			CustomPassUtils.customPassRenderersUtilsMaterial = CoreUtils.CreateEngineMaterial(HDRenderPipelineGlobalSettings.instance.renderPipelineResources.shaders.customPassRenderersUtils);
			CustomPassUtils.depthToColorPassIndex = CustomPassUtils.customPassRenderersUtilsMaterial.FindPass("DepthToColorPass");
			CustomPassUtils.depthPassIndex = CustomPassUtils.customPassRenderersUtilsMaterial.FindPass("DepthPass");
			CustomPassUtils.normalToColorPassIndex = CustomPassUtils.customPassRenderersUtilsMaterial.FindPass("NormalToColorPass");
			CustomPassUtils.tangentToColorPassIndex = CustomPassUtils.customPassRenderersUtilsMaterial.FindPass("TangentToColorPass");
		}

		// Token: 0x06000CDE RID: 3294 RVA: 0x0006974D File Offset: 0x0006794D
		public static void DownSample(in CustomPassContext ctx, RTHandle source, RTHandle destination, int sourceMip = 0, int destMip = 0)
		{
			CustomPassUtils.DownSample(ctx, source, destination, CustomPassUtils.fullScreenScaleBias, CustomPassUtils.fullScreenScaleBias, sourceMip, destMip);
		}

		// Token: 0x06000CDF RID: 3295 RVA: 0x00069764 File Offset: 0x00067964
		public static void DownSample(in CustomPassContext ctx, RTHandle source, RTHandle destination, Vector4 sourceScaleBias, Vector4 destScaleBias, int sourceMip = 0, int destMip = 0)
		{
			if (destination.rt.width < source.rt.width / 2 || destination.rt.height < source.rt.height / 2)
			{
				Debug.LogError("Destination for DownSample is too small, it needs to be at least half as big as source.");
			}
			if (source.rt.antiAliasing > 1 || destination.rt.antiAliasing > 1)
			{
				Debug.LogError("DownSample is not supported with MSAA buffers");
			}
			using (new ProfilingScope(ctx.cmd, CustomPassUtils.downSampleSampler))
			{
				using (new CustomPassUtils.OverrideRTHandleScale(ref ctx))
				{
					CustomPassUtils.SetRenderTargetWithScaleBias(ctx, CustomPassUtils.propertyBlock, destination, destScaleBias, ClearFlag.None, destMip);
					CustomPassUtils.propertyBlock.SetTexture(HDShaderIDs._Source, source);
					CustomPassUtils.propertyBlock.SetVector(HDShaderIDs._SourceScaleBias, sourceScaleBias);
					CustomPassUtils.SetSourceSize(CustomPassUtils.propertyBlock, source);
					ctx.cmd.DrawProcedural(Matrix4x4.identity, CustomPassUtils.customPassUtilsMaterial, CustomPassUtils.downSamplePassIndex, MeshTopology.Triangles, 3, 1, CustomPassUtils.propertyBlock);
				}
			}
		}

		// Token: 0x06000CE0 RID: 3296 RVA: 0x0006988C File Offset: 0x00067A8C
		public static void Copy(in CustomPassContext ctx, RTHandle source, RTHandle destination, int sourceMip = 0, int destMip = 0)
		{
			CustomPassUtils.Copy(ctx, source, destination, CustomPassUtils.fullScreenScaleBias, CustomPassUtils.fullScreenScaleBias, sourceMip, destMip);
		}

		// Token: 0x06000CE1 RID: 3297 RVA: 0x000698A4 File Offset: 0x00067AA4
		public static void Copy(in CustomPassContext ctx, RTHandle source, RTHandle destination, Vector4 sourceScaleBias, Vector4 destScaleBias, int sourceMip = 0, int destMip = 0)
		{
			if (source == destination)
			{
				Debug.LogError("Can't copy the buffer. Source has to be different from the destination.");
			}
			if (source.rt.antiAliasing > 1 || destination.rt.antiAliasing > 1)
			{
				Debug.LogError("Copy is not supported with MSAA buffers");
			}
			using (new ProfilingScope(ctx.cmd, CustomPassUtils.copySampler))
			{
				using (new CustomPassUtils.OverrideRTHandleScale(ref ctx))
				{
					CustomPassUtils.SetRenderTargetWithScaleBias(ctx, CustomPassUtils.propertyBlock, destination, destScaleBias, ClearFlag.None, destMip);
					CustomPassUtils.propertyBlock.SetTexture(HDShaderIDs._Source, source);
					CustomPassUtils.propertyBlock.SetVector(HDShaderIDs._SourceScaleBias, sourceScaleBias);
					CustomPassUtils.SetSourceSize(CustomPassUtils.propertyBlock, source);
					if (source.rt.graphicsFormat != GraphicsFormat.None && destination.rt.graphicsFormat != GraphicsFormat.None)
					{
						ctx.cmd.DrawProcedural(Matrix4x4.identity, CustomPassUtils.customPassUtilsMaterial, CustomPassUtils.copyPassIndex, MeshTopology.Triangles, 3, 1, CustomPassUtils.propertyBlock);
					}
					if (source.rt.depthStencilFormat != GraphicsFormat.None && destination.rt.depthStencilFormat != GraphicsFormat.None)
					{
						ctx.cmd.DrawProcedural(Matrix4x4.identity, CustomPassUtils.customPassUtilsMaterial, CustomPassUtils.copyDepthPassIndex, MeshTopology.Triangles, 3, 1, CustomPassUtils.propertyBlock);
					}
				}
			}
		}

		// Token: 0x06000CE2 RID: 3298 RVA: 0x000699F4 File Offset: 0x00067BF4
		public static void VerticalGaussianBlur(in CustomPassContext ctx, RTHandle source, RTHandle destination, int sampleCount = 8, float radius = 5f, int sourceMip = 0, int destMip = 0)
		{
			CustomPassUtils.VerticalGaussianBlur(ctx, source, destination, CustomPassUtils.fullScreenScaleBias, CustomPassUtils.fullScreenScaleBias, sampleCount, radius, sourceMip, destMip);
		}

		// Token: 0x06000CE3 RID: 3299 RVA: 0x00069A1C File Offset: 0x00067C1C
		public static void VerticalGaussianBlur(in CustomPassContext ctx, RTHandle source, RTHandle destination, Vector4 sourceScaleBias, Vector4 destScaleBias, int sampleCount = 8, float radius = 5f, int sourceMip = 0, int destMip = 0)
		{
			if (source == destination)
			{
				Debug.LogError("Can't blur the buffer. Source has to be different from the destination.");
			}
			if (source.rt.antiAliasing > 1 || destination.rt.antiAliasing > 1)
			{
				Debug.LogError("GaussianBlur is not supported with MSAA buffers");
			}
			using (new ProfilingScope(ctx.cmd, CustomPassUtils.verticalBlurSampler))
			{
				using (new CustomPassUtils.OverrideRTHandleScale(ref ctx))
				{
					CustomPassUtils.SetRenderTargetWithScaleBias(ctx, CustomPassUtils.propertyBlock, destination, destScaleBias, ClearFlag.None, destMip);
					CustomPassUtils.propertyBlock.SetTexture(HDShaderIDs._Source, source);
					CustomPassUtils.propertyBlock.SetVector(HDShaderIDs._SourceScaleBias, sourceScaleBias);
					CustomPassUtils.propertyBlock.SetBuffer(HDShaderIDs._GaussianWeights, CustomPassUtils.GetGaussianWeights(sampleCount));
					CustomPassUtils.propertyBlock.SetFloat(HDShaderIDs._SampleCount, (float)sampleCount);
					CustomPassUtils.propertyBlock.SetFloat(HDShaderIDs._Radius, radius);
					CustomPassUtils.SetSourceSize(CustomPassUtils.propertyBlock, source);
					ctx.cmd.DrawProcedural(Matrix4x4.identity, CustomPassUtils.customPassUtilsMaterial, CustomPassUtils.verticalBlurPassIndex, MeshTopology.Triangles, 3, 1, CustomPassUtils.propertyBlock);
				}
			}
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x00069B4C File Offset: 0x00067D4C
		public static void HorizontalGaussianBlur(in CustomPassContext ctx, RTHandle source, RTHandle destination, int sampleCount = 8, float radius = 5f, int sourceMip = 0, int destMip = 0)
		{
			CustomPassUtils.HorizontalGaussianBlur(ctx, source, destination, CustomPassUtils.fullScreenScaleBias, CustomPassUtils.fullScreenScaleBias, sampleCount, radius, sourceMip, destMip);
		}

		// Token: 0x06000CE5 RID: 3301 RVA: 0x00069B74 File Offset: 0x00067D74
		public static void HorizontalGaussianBlur(in CustomPassContext ctx, RTHandle source, RTHandle destination, Vector4 sourceScaleBias, Vector4 destScaleBias, int sampleCount = 8, float radius = 5f, int sourceMip = 0, int destMip = 0)
		{
			if (source == destination)
			{
				Debug.LogError("Can't blur the buffer. Source has to be different from the destination.");
			}
			if (source.rt.antiAliasing > 1 || destination.rt.antiAliasing > 1)
			{
				Debug.LogError("GaussianBlur is not supported with MSAA buffers");
			}
			using (new ProfilingScope(ctx.cmd, CustomPassUtils.horizontalBlurSampler))
			{
				using (new CustomPassUtils.OverrideRTHandleScale(ref ctx))
				{
					CustomPassUtils.SetRenderTargetWithScaleBias(ctx, CustomPassUtils.propertyBlock, destination, destScaleBias, ClearFlag.None, destMip);
					CustomPassUtils.propertyBlock.SetTexture(HDShaderIDs._Source, source);
					CustomPassUtils.propertyBlock.SetVector(HDShaderIDs._SourceScaleBias, sourceScaleBias);
					CustomPassUtils.propertyBlock.SetBuffer(HDShaderIDs._GaussianWeights, CustomPassUtils.GetGaussianWeights(sampleCount));
					CustomPassUtils.propertyBlock.SetFloat(HDShaderIDs._SampleCount, (float)sampleCount);
					CustomPassUtils.propertyBlock.SetFloat(HDShaderIDs._Radius, radius);
					CustomPassUtils.SetSourceSize(CustomPassUtils.propertyBlock, source);
					ctx.cmd.DrawProcedural(Matrix4x4.identity, CustomPassUtils.customPassUtilsMaterial, CustomPassUtils.horizontalBlurPassIndex, MeshTopology.Triangles, 3, 1, CustomPassUtils.propertyBlock);
				}
			}
		}

		// Token: 0x06000CE6 RID: 3302 RVA: 0x00069CA4 File Offset: 0x00067EA4
		public static void GaussianBlur(in CustomPassContext ctx, RTHandle source, RTHandle destination, RTHandle tempTarget, int sampleCount = 9, float radius = 5f, int sourceMip = 0, int destMip = 0, bool downSample = true)
		{
			CustomPassUtils.GaussianBlur(ctx, source, destination, tempTarget, CustomPassUtils.fullScreenScaleBias, CustomPassUtils.fullScreenScaleBias, sampleCount, radius, sourceMip, destMip, downSample);
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x00069CD0 File Offset: 0x00067ED0
		public static void GaussianBlur(in CustomPassContext ctx, RTHandle source, RTHandle destination, RTHandle tempTarget, Vector4 sourceScaleBias, Vector4 destScaleBias, int sampleCount = 9, float radius = 5f, int sourceMip = 0, int destMip = 0, bool downSample = true)
		{
			if (source == tempTarget || destination == tempTarget)
			{
				Debug.LogError("Can't blur the buffer. tempTarget has to be different from both source or destination.");
			}
			if (tempTarget.scaleFactor.x != tempTarget.scaleFactor.y || (tempTarget.scaleFactor.x != 0.5f && tempTarget.scaleFactor.x != 1f))
			{
				Debug.LogError(string.Format("Can't blur the buffer. Only a scaleFactor of 0.5 or 1.0 is supported on tempTarget. Current scaleFactor: {0}", tempTarget.scaleFactor));
			}
			if (source.rt.antiAliasing > 1 || destination.rt.antiAliasing > 1 || tempTarget.rt.antiAliasing > 1)
			{
				Debug.LogError("GaussianBlur is not supported with MSAA buffers");
			}
			if (sampleCount % 2 == 0)
			{
				sampleCount++;
			}
			using (new ProfilingScope(ctx.cmd, CustomPassUtils.gaussianblurSampler))
			{
				if (downSample)
				{
					using (new CustomPassUtils.OverrideRTHandleScale(ref ctx))
					{
						CustomPassUtils.DownSample(ctx, source, tempTarget, sourceScaleBias, sourceScaleBias, sourceMip, 0);
						CustomPassUtils.VerticalGaussianBlur(ctx, tempTarget, destination, sourceScaleBias, sourceScaleBias, sampleCount, radius, 0, destMip);
						CustomPassUtils.Copy(ctx, destination, tempTarget, sourceScaleBias, sourceScaleBias, 0, destMip);
						CustomPassUtils.HorizontalGaussianBlur(ctx, tempTarget, destination, sourceScaleBias, destScaleBias, sampleCount, radius, sourceMip, destMip);
						return;
					}
				}
				using (new CustomPassUtils.OverrideRTHandleScale(ref ctx))
				{
					CustomPassUtils.VerticalGaussianBlur(ctx, source, tempTarget, sourceScaleBias, sourceScaleBias, sampleCount, radius, sourceMip, destMip);
					CustomPassUtils.HorizontalGaussianBlur(ctx, tempTarget, destination, sourceScaleBias, destScaleBias, sampleCount, radius, sourceMip, destMip);
				}
			}
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x00069E6C File Offset: 0x0006806C
		public static void DrawRenderers(in CustomPassContext ctx, LayerMask layerMask, CustomPass.RenderQueueType renderQueueFilter = CustomPass.RenderQueueType.All, Material overrideMaterial = null, int overrideMaterialIndex = 0, RenderStateBlock overrideRenderState = default(RenderStateBlock), SortingCriteria sorting = SortingCriteria.SortingLayer | SortingCriteria.RenderQueue | SortingCriteria.OptimizeStateChanges | SortingCriteria.CanvasOrder)
		{
			CustomPassUtils.DrawRenderers(ctx, CustomPassUtils.litForwardTags, layerMask, renderQueueFilter, overrideMaterial, overrideMaterialIndex, overrideRenderState, sorting);
		}

		// Token: 0x06000CE9 RID: 3305 RVA: 0x00069E84 File Offset: 0x00068084
		public static void DrawRenderers(in CustomPassContext ctx, ShaderTagId[] shaderTags, LayerMask layerMask, CustomPass.RenderQueueType renderQueueFilter = CustomPass.RenderQueueType.All, Material overrideMaterial = null, int overrideMaterialIndex = 0, RenderStateBlock overrideRenderState = default(RenderStateBlock), SortingCriteria sorting = SortingCriteria.SortingLayer | SortingCriteria.RenderQueue | SortingCriteria.OptimizeStateChanges | SortingCriteria.CanvasOrder)
		{
			PerObjectData rendererConfiguration = HDUtils.GetRendererConfiguration(ctx.hdCamera.frameSettings.IsEnabled(FrameSettingsField.ProbeVolume), ctx.hdCamera.frameSettings.IsEnabled(FrameSettingsField.Shadowmask));
			RendererListDesc desc = new RendererListDesc(shaderTags, ctx.cullingResults, ctx.hdCamera.camera)
			{
				rendererConfiguration = rendererConfiguration,
				renderQueueRange = CustomPassUtils.GetRenderQueueRangeFromRenderQueueType(renderQueueFilter),
				sortingCriteria = sorting,
				overrideMaterial = overrideMaterial,
				overrideMaterialPassIndex = overrideMaterialIndex,
				excludeObjectMotionVectors = false,
				layerMask = layerMask,
				stateBlock = new RenderStateBlock?(overrideRenderState)
			};
			ScriptableRenderContext renderContext = ctx.renderContext;
			CoreUtils.DrawRendererList(ctx.renderContext, ctx.cmd, renderContext.CreateRendererList(desc));
		}

		// Token: 0x06000CEA RID: 3306 RVA: 0x00069F50 File Offset: 0x00068150
		internal static ComputeBuffer GetGaussianWeights(int weightCount)
		{
			ComputeBuffer computeBuffer;
			if (CustomPassUtils.gaussianWeightsCache.TryGetValue(weightCount, out computeBuffer))
			{
				return computeBuffer;
			}
			float[] array = new float[weightCount];
			float num = 3f;
			float num2 = -num;
			float num3 = 0f;
			float num4 = 1f / (float)weightCount * num * 2f;
			for (int i = 0; i < weightCount; i++)
			{
				float num5 = CustomPassUtils.<GetGaussianWeights>g__Gaussian|39_0(num2, 1f) / (float)weightCount * num * 2f;
				array[i] = num5;
				num2 += num4;
				num3 += num5;
			}
			computeBuffer = new ComputeBuffer(array.Length, 4);
			computeBuffer.SetData(array);
			CustomPassUtils.gaussianWeightsCache[weightCount] = computeBuffer;
			return computeBuffer;
		}

		// Token: 0x06000CEB RID: 3307 RVA: 0x00069FF0 File Offset: 0x000681F0
		public static RenderQueueRange GetRenderQueueRangeFromRenderQueueType(CustomPass.RenderQueueType type)
		{
			switch (type)
			{
			case CustomPass.RenderQueueType.OpaqueNoAlphaTest:
				return HDRenderQueue.k_RenderQueue_OpaqueNoAlphaTest;
			case CustomPass.RenderQueueType.OpaqueAlphaTest:
				return HDRenderQueue.k_RenderQueue_OpaqueAlphaTest;
			case CustomPass.RenderQueueType.AllOpaque:
				return HDRenderQueue.k_RenderQueue_AllOpaque;
			case CustomPass.RenderQueueType.AfterPostProcessOpaque:
				return HDRenderQueue.k_RenderQueue_AfterPostProcessOpaque;
			case CustomPass.RenderQueueType.PreRefraction:
				return HDRenderQueue.k_RenderQueue_PreRefraction;
			case CustomPass.RenderQueueType.Transparent:
				return HDRenderQueue.k_RenderQueue_Transparent;
			case CustomPass.RenderQueueType.LowTransparent:
				return HDRenderQueue.k_RenderQueue_LowTransparent;
			case CustomPass.RenderQueueType.AllTransparent:
				return HDRenderQueue.k_RenderQueue_AllTransparent;
			case CustomPass.RenderQueueType.AllTransparentWithLowRes:
				return HDRenderQueue.k_RenderQueue_AllTransparentWithLowRes;
			case CustomPass.RenderQueueType.AfterPostProcessTransparent:
				return HDRenderQueue.k_RenderQueue_AfterPostProcessTransparent;
			case CustomPass.RenderQueueType.Overlay:
				return HDRenderQueue.k_RenderQueue_Overlay;
			}
			return HDRenderQueue.k_RenderQueue_All;
		}

		// Token: 0x06000CEC RID: 3308 RVA: 0x0006A07C File Offset: 0x0006827C
		public static void RenderFromCamera(in CustomPassContext ctx, Camera view, LayerMask layerMask, CustomPass.RenderQueueType renderQueueFilter = CustomPass.RenderQueueType.All, Material overrideMaterial = null, int overrideMaterialIndex = 0, RenderStateBlock overrideRenderState = default(RenderStateBlock))
		{
			CustomPassUtils.RenderFromCamera(ctx, view, null, null, ClearFlag.None, layerMask, renderQueueFilter, overrideMaterial, overrideMaterialIndex, overrideRenderState);
		}

		// Token: 0x06000CED RID: 3309 RVA: 0x0006A09C File Offset: 0x0006829C
		public static void RenderFromCamera(in CustomPassContext ctx, Camera view, RenderTexture targetRenderTexture, ClearFlag clearFlag, LayerMask layerMask, CustomPass.RenderQueueType renderQueueFilter = CustomPass.RenderQueueType.All, Material overrideMaterial = null, int overrideMaterialIndex = 0, RenderStateBlock overrideRenderState = default(RenderStateBlock))
		{
			CoreUtils.SetRenderTarget(ctx.cmd, targetRenderTexture.colorBuffer, targetRenderTexture.depthBuffer, clearFlag, 0, CubemapFace.Unknown, -1);
			float overrideAspectRatio = (float)targetRenderTexture.width / (float)targetRenderTexture.height;
			using (new CustomPassUtils.DisableSinglePassRendering(ref ctx))
			{
				using (new CustomPassUtils.OverrideCameraRendering(ctx, view, overrideAspectRatio))
				{
					using (new ProfilingScope(ctx.cmd, CustomPassUtils.renderFromCameraSampler))
					{
						CustomPassUtils.DrawRenderers(ctx, layerMask, renderQueueFilter, overrideMaterial, overrideMaterialIndex, overrideRenderState, SortingCriteria.SortingLayer | SortingCriteria.RenderQueue | SortingCriteria.OptimizeStateChanges | SortingCriteria.CanvasOrder);
					}
				}
			}
		}

		// Token: 0x06000CEE RID: 3310 RVA: 0x0006A16C File Offset: 0x0006836C
		public static void RenderFromCamera(in CustomPassContext ctx, Camera view, RTHandle targetColor, RTHandle targetDepth, ClearFlag clearFlag, LayerMask layerMask, CustomPass.RenderQueueType renderQueueFilter = CustomPass.RenderQueueType.All, Material overrideMaterial = null, int overrideMaterialIndex = 0, RenderStateBlock overrideRenderState = default(RenderStateBlock))
		{
			if (targetColor != null && targetDepth != null)
			{
				CoreUtils.SetRenderTarget(ctx.cmd, targetColor, targetDepth, clearFlag, 0, CubemapFace.Unknown, -1);
			}
			else if (targetColor != null)
			{
				CoreUtils.SetRenderTarget(ctx.cmd, targetColor, clearFlag, 0, CubemapFace.Unknown, -1);
			}
			else if (targetDepth != null)
			{
				CoreUtils.SetRenderTarget(ctx.cmd, targetDepth, clearFlag, 0, CubemapFace.Unknown, -1);
			}
			using (new CustomPassUtils.DisableSinglePassRendering(ref ctx))
			{
				using (new CustomPassUtils.OverrideCameraRendering(ctx, view))
				{
					using (new ProfilingScope(ctx.cmd, CustomPassUtils.renderFromCameraSampler))
					{
						CustomPassUtils.DrawRenderers(ctx, layerMask, renderQueueFilter, overrideMaterial, overrideMaterialIndex, overrideRenderState, SortingCriteria.SortingLayer | SortingCriteria.RenderQueue | SortingCriteria.OptimizeStateChanges | SortingCriteria.CanvasOrder);
					}
				}
			}
		}

		// Token: 0x06000CEF RID: 3311 RVA: 0x0006A248 File Offset: 0x00068448
		public static void RenderDepthFromCamera(in CustomPassContext ctx, Camera view, LayerMask layerMask, CustomPass.RenderQueueType renderQueueFilter = CustomPass.RenderQueueType.All, RenderStateBlock overrideRenderState = default(RenderStateBlock))
		{
			CustomPassUtils.RenderDepthFromCamera(ctx, view, null, null, ClearFlag.None, layerMask, renderQueueFilter, overrideRenderState);
		}

		// Token: 0x06000CF0 RID: 3312 RVA: 0x0006A258 File Offset: 0x00068458
		public static void RenderDepthFromCamera(in CustomPassContext ctx, Camera view, RTHandle targetColor, RTHandle targetDepth, ClearFlag clearFlag, LayerMask layerMask, CustomPass.RenderQueueType renderQueueFilter = CustomPass.RenderQueueType.All, RenderStateBlock overrideRenderState = default(RenderStateBlock))
		{
			using (new ProfilingScope(ctx.cmd, CustomPassUtils.renderDepthFromCameraSampler))
			{
				if (targetColor == null && targetDepth != null)
				{
					CustomPassUtils.RenderFromCamera(ctx, view, targetColor, targetDepth, clearFlag, layerMask, renderQueueFilter, CustomPassUtils.customPassRenderersUtilsMaterial, CustomPassUtils.depthPassIndex, overrideRenderState);
				}
				else
				{
					CustomPassUtils.RenderFromCamera(ctx, view, targetColor, targetDepth, clearFlag, layerMask, renderQueueFilter, CustomPassUtils.customPassRenderersUtilsMaterial, CustomPassUtils.depthToColorPassIndex, overrideRenderState);
				}
			}
		}

		// Token: 0x06000CF1 RID: 3313 RVA: 0x0006A2D8 File Offset: 0x000684D8
		public static void RenderDepthFromCamera(in CustomPassContext ctx, Camera view, RenderTexture targetRenderTexture, ClearFlag clearFlag, LayerMask layerMask, CustomPass.RenderQueueType renderQueueFilter = CustomPass.RenderQueueType.All, RenderStateBlock overrideRenderState = default(RenderStateBlock))
		{
			using (new ProfilingScope(ctx.cmd, CustomPassUtils.renderDepthFromCameraSampler))
			{
				if (targetRenderTexture.format == RenderTextureFormat.Depth)
				{
					CustomPassUtils.RenderFromCamera(ctx, view, targetRenderTexture, clearFlag, layerMask, renderQueueFilter, CustomPassUtils.customPassRenderersUtilsMaterial, CustomPassUtils.depthPassIndex, overrideRenderState);
				}
				else
				{
					CustomPassUtils.RenderFromCamera(ctx, view, targetRenderTexture, clearFlag, layerMask, renderQueueFilter, CustomPassUtils.customPassRenderersUtilsMaterial, CustomPassUtils.depthToColorPassIndex, overrideRenderState);
				}
			}
		}

		// Token: 0x06000CF2 RID: 3314 RVA: 0x0006A354 File Offset: 0x00068554
		public static void RenderNormalFromCamera(in CustomPassContext ctx, Camera view, LayerMask layerMask, CustomPass.RenderQueueType renderQueueFilter = CustomPass.RenderQueueType.All, RenderStateBlock overrideRenderState = default(RenderStateBlock))
		{
			CustomPassUtils.RenderNormalFromCamera(ctx, view, null, null, ClearFlag.None, layerMask, renderQueueFilter, overrideRenderState);
		}

		// Token: 0x06000CF3 RID: 3315 RVA: 0x0006A364 File Offset: 0x00068564
		public static void RenderNormalFromCamera(in CustomPassContext ctx, Camera view, RTHandle targetColor, RTHandle targetDepth, ClearFlag clearFlag, LayerMask layerMask, CustomPass.RenderQueueType renderQueueFilter = CustomPass.RenderQueueType.All, RenderStateBlock overrideRenderState = default(RenderStateBlock))
		{
			using (new ProfilingScope(ctx.cmd, CustomPassUtils.renderNormalFromCameraSampler))
			{
				CustomPassUtils.RenderFromCamera(ctx, view, targetColor, targetDepth, clearFlag, layerMask, renderQueueFilter, CustomPassUtils.customPassRenderersUtilsMaterial, CustomPassUtils.normalToColorPassIndex, overrideRenderState);
			}
		}

		// Token: 0x06000CF4 RID: 3316 RVA: 0x0006A3C0 File Offset: 0x000685C0
		public static void RenderNormalFromCamera(in CustomPassContext ctx, Camera view, RenderTexture targetRenderTexture, ClearFlag clearFlag, LayerMask layerMask, CustomPass.RenderQueueType renderQueueFilter = CustomPass.RenderQueueType.All, RenderStateBlock overrideRenderState = default(RenderStateBlock))
		{
			using (new ProfilingScope(ctx.cmd, CustomPassUtils.renderNormalFromCameraSampler))
			{
				CustomPassUtils.RenderFromCamera(ctx, view, targetRenderTexture, clearFlag, layerMask, renderQueueFilter, CustomPassUtils.customPassRenderersUtilsMaterial, CustomPassUtils.normalToColorPassIndex, overrideRenderState);
			}
		}

		// Token: 0x06000CF5 RID: 3317 RVA: 0x0006A418 File Offset: 0x00068618
		public static void RenderTangentFromCamera(in CustomPassContext ctx, Camera view, LayerMask layerMask, CustomPass.RenderQueueType renderQueueFilter = CustomPass.RenderQueueType.All, RenderStateBlock overrideRenderState = default(RenderStateBlock))
		{
			CustomPassUtils.RenderTangentFromCamera(ctx, view, null, null, ClearFlag.None, layerMask, renderQueueFilter, overrideRenderState);
		}

		// Token: 0x06000CF6 RID: 3318 RVA: 0x0006A428 File Offset: 0x00068628
		public static void RenderTangentFromCamera(in CustomPassContext ctx, Camera view, RTHandle targetColor, RTHandle targetDepth, ClearFlag clearFlag, LayerMask layerMask, CustomPass.RenderQueueType renderQueueFilter = CustomPass.RenderQueueType.All, RenderStateBlock overrideRenderState = default(RenderStateBlock))
		{
			using (new ProfilingScope(ctx.cmd, CustomPassUtils.renderTangentFromCameraSampler))
			{
				CustomPassUtils.RenderFromCamera(ctx, view, targetColor, targetDepth, clearFlag, layerMask, renderQueueFilter, CustomPassUtils.customPassRenderersUtilsMaterial, CustomPassUtils.tangentToColorPassIndex, overrideRenderState);
			}
		}

		// Token: 0x06000CF7 RID: 3319 RVA: 0x0006A484 File Offset: 0x00068684
		public static void RenderTangentFromCamera(in CustomPassContext ctx, Camera view, RenderTexture targetRenderTexture, ClearFlag clearFlag, LayerMask layerMask, CustomPass.RenderQueueType renderQueueFilter = CustomPass.RenderQueueType.All, RenderStateBlock overrideRenderState = default(RenderStateBlock))
		{
			using (new ProfilingScope(ctx.cmd, CustomPassUtils.renderTangentFromCameraSampler))
			{
				CustomPassUtils.RenderFromCamera(ctx, view, targetRenderTexture, clearFlag, layerMask, renderQueueFilter, CustomPassUtils.customPassRenderersUtilsMaterial, CustomPassUtils.tangentToColorPassIndex, overrideRenderState);
			}
		}

		// Token: 0x06000CF8 RID: 3320 RVA: 0x0006A4DC File Offset: 0x000686DC
		internal static void Cleanup()
		{
			foreach (KeyValuePair<int, ComputeBuffer> keyValuePair in CustomPassUtils.gaussianWeightsCache)
			{
				keyValuePair.Value.Release();
			}
			CustomPassUtils.gaussianWeightsCache.Clear();
		}

		// Token: 0x06000CF9 RID: 3321 RVA: 0x0006A540 File Offset: 0x00068740
		internal static void SetRenderTargetWithScaleBias(in CustomPassContext ctx, MaterialPropertyBlock block, RTHandle destination, Vector4 destScaleBias, ClearFlag clearFlag, int miplevel)
		{
			Rect viewport = default(Rect);
			if (destination.useScaling)
			{
				viewport.size = destination.GetScaledSize(destination.rtHandleProperties.currentViewportSize);
			}
			else
			{
				viewport.size = new Vector2Int(destination.rt.width, destination.rt.height);
			}
			Vector2 size = viewport.size;
			viewport.position = new Vector2(viewport.size.x * destScaleBias.z, viewport.size.y * destScaleBias.w);
			viewport.size *= new Vector2(destScaleBias.x, destScaleBias.y);
			CoreUtils.SetRenderTarget(ctx.cmd, destination, clearFlag, Color.black, miplevel, CubemapFace.Unknown, -1);
			ctx.cmd.SetViewport(viewport);
			block.SetVector(HDShaderIDs._ViewPortSize, new Vector4(size.x, size.y, 1f / size.x, 1f / size.y));
			block.SetVector(HDShaderIDs._ViewportScaleBias, new Vector4(1f / destScaleBias.x, 1f / destScaleBias.y, destScaleBias.z, destScaleBias.w));
		}

		// Token: 0x06000CFA RID: 3322 RVA: 0x0006A68C File Offset: 0x0006888C
		private static void SetSourceSize(MaterialPropertyBlock block, RTHandle source)
		{
			Vector2 vector = source.GetScaledSize(source.rtHandleProperties.currentViewportSize);
			block.SetVector(HDShaderIDs._SourceSize, new Vector4(vector.x, vector.y, 1f / vector.x, 1f / vector.y));
			block.SetVector(HDShaderIDs._SourceScaleFactor, new Vector4(source.scaleFactor.x, source.scaleFactor.y, 1f / source.scaleFactor.x, 1f / source.scaleFactor.y));
		}

		// Token: 0x06000CFC RID: 3324 RVA: 0x0006A844 File Offset: 0x00068A44
		[CompilerGenerated]
		internal static float <GetGaussianWeights>g__Gaussian|39_0(float x, float sigma = 1f)
		{
			float num = 1f / Mathf.Sqrt(6.2831855f * sigma * sigma);
			float num2 = Mathf.Exp(-(x * x) / (2f * sigma * sigma));
			return num * num2;
		}

		// Token: 0x040013EB RID: 5099
		public static Vector4 fullScreenScaleBias = new Vector4(1f, 1f, 0f, 0f);

		// Token: 0x040013EC RID: 5100
		private static ShaderTagId[] litForwardTags = new ShaderTagId[]
		{
			HDShaderPassNames.s_ForwardOnlyName,
			HDShaderPassNames.s_ForwardName,
			HDShaderPassNames.s_SRPDefaultUnlitName
		};

		// Token: 0x040013ED RID: 5101
		private static ShaderTagId[] depthTags = new ShaderTagId[]
		{
			HDShaderPassNames.s_DepthForwardOnlyName,
			HDShaderPassNames.s_DepthOnlyName
		};

		// Token: 0x040013EE RID: 5102
		private static ProfilingSampler downSampleSampler = new ProfilingSampler("DownSample");

		// Token: 0x040013EF RID: 5103
		private static ProfilingSampler verticalBlurSampler = new ProfilingSampler("Vertical Blur");

		// Token: 0x040013F0 RID: 5104
		private static ProfilingSampler horizontalBlurSampler = new ProfilingSampler("Horizontal Blur");

		// Token: 0x040013F1 RID: 5105
		private static ProfilingSampler gaussianblurSampler = new ProfilingSampler("Gaussian Blur");

		// Token: 0x040013F2 RID: 5106
		private static ProfilingSampler copySampler = new ProfilingSampler("Copy");

		// Token: 0x040013F3 RID: 5107
		private static ProfilingSampler renderFromCameraSampler = new ProfilingSampler("Render From Camera");

		// Token: 0x040013F4 RID: 5108
		private static ProfilingSampler renderDepthFromCameraSampler = new ProfilingSampler("Render Depth");

		// Token: 0x040013F5 RID: 5109
		private static ProfilingSampler renderNormalFromCameraSampler = new ProfilingSampler("Render Normal");

		// Token: 0x040013F6 RID: 5110
		private static ProfilingSampler renderTangentFromCameraSampler = new ProfilingSampler("Render Tangent");

		// Token: 0x040013F7 RID: 5111
		private static MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();

		// Token: 0x040013F8 RID: 5112
		private static Material customPassUtilsMaterial;

		// Token: 0x040013F9 RID: 5113
		private static Material customPassRenderersUtilsMaterial;

		// Token: 0x040013FA RID: 5114
		private static Dictionary<int, ComputeBuffer> gaussianWeightsCache = new Dictionary<int, ComputeBuffer>();

		// Token: 0x040013FB RID: 5115
		private static int downSamplePassIndex;

		// Token: 0x040013FC RID: 5116
		private static int verticalBlurPassIndex;

		// Token: 0x040013FD RID: 5117
		private static int horizontalBlurPassIndex;

		// Token: 0x040013FE RID: 5118
		private static int copyPassIndex;

		// Token: 0x040013FF RID: 5119
		private static int copyDepthPassIndex;

		// Token: 0x04001400 RID: 5120
		private static int depthToColorPassIndex;

		// Token: 0x04001401 RID: 5121
		private static int depthPassIndex;

		// Token: 0x04001402 RID: 5122
		private static int normalToColorPassIndex;

		// Token: 0x04001403 RID: 5123
		private static int tangentToColorPassIndex;

		// Token: 0x020003E6 RID: 998
		private struct OverrideRTHandleScale : IDisposable
		{
			// Token: 0x06001391 RID: 5009 RVA: 0x00095658 File Offset: 0x00093858
			public OverrideRTHandleScale(in CustomPassContext ctx)
			{
				this.injectionPoint = ctx.injectionPoint;
				if (this.injectionPoint == CustomPassInjectionPoint.AfterPostProcess)
				{
					if (CustomPassUtils.OverrideRTHandleScale.overrideCounter == 0)
					{
						CustomPassUtils.propertyBlock.SetVector(HDShaderIDs._OverrideRTHandleScale, RTHandles.rtHandleProperties.rtHandleScale);
					}
					CustomPassUtils.OverrideRTHandleScale.overrideCounter++;
				}
			}

			// Token: 0x06001392 RID: 5010 RVA: 0x000956A6 File Offset: 0x000938A6
			public void Dispose()
			{
				if (this.injectionPoint == CustomPassInjectionPoint.AfterPostProcess)
				{
					if (CustomPassUtils.OverrideRTHandleScale.overrideCounter == 1)
					{
						CustomPassUtils.propertyBlock.SetVector(HDShaderIDs._OverrideRTHandleScale, Vector4.zero);
					}
					CustomPassUtils.OverrideRTHandleScale.overrideCounter--;
				}
			}

			// Token: 0x04002858 RID: 10328
			private static int overrideCounter;

			// Token: 0x04002859 RID: 10329
			private CustomPassInjectionPoint injectionPoint;
		}

		// Token: 0x020003E7 RID: 999
		public struct DisableSinglePassRendering : IDisposable
		{
			// Token: 0x06001393 RID: 5011 RVA: 0x000956D9 File Offset: 0x000938D9
			public DisableSinglePassRendering(in CustomPassContext ctx)
			{
				this.m_Context = ctx;
				if (ctx.hdCamera.xr.enabled)
				{
					this.m_Context.hdCamera.xr.StopSinglePass(ctx.cmd);
				}
			}

			// Token: 0x06001394 RID: 5012 RVA: 0x00095714 File Offset: 0x00093914
			void IDisposable.Dispose()
			{
				if (this.m_Context.hdCamera.xr.enabled)
				{
					this.m_Context.hdCamera.xr.StartSinglePass(this.m_Context.cmd);
				}
			}

			// Token: 0x0400285A RID: 10330
			private CustomPassContext m_Context;
		}

		// Token: 0x020003E8 RID: 1000
		public struct OverrideCameraRendering : IDisposable
		{
			// Token: 0x06001395 RID: 5013 RVA: 0x00095750 File Offset: 0x00093950
			public OverrideCameraRendering(CustomPassContext ctx, Camera overrideCamera)
			{
				this.ctx = ctx;
				this.overrideCamera = overrideCamera;
				this.overrideHDCamera = HDCamera.GetOrCreate(overrideCamera, 0);
				this.originalAspect = overrideCamera.aspect;
				float overrideAspectRatio = overrideCamera.aspect;
				if (overrideCamera.targetTexture == null)
				{
					overrideAspectRatio = ctx.hdCamera.camera.pixelRect.width / ctx.hdCamera.camera.pixelRect.height;
				}
				else
				{
					overrideAspectRatio = (float)overrideCamera.pixelWidth / (float)overrideCamera.pixelHeight;
				}
				this.Init(ctx, overrideCamera, overrideAspectRatio);
			}

			// Token: 0x06001396 RID: 5014 RVA: 0x000957E8 File Offset: 0x000939E8
			public OverrideCameraRendering(CustomPassContext ctx, Camera overrideCamera, float overrideAspectRatio)
			{
				this.ctx = ctx;
				this.overrideCamera = overrideCamera;
				this.overrideHDCamera = HDCamera.GetOrCreate(overrideCamera, 0);
				this.originalAspect = overrideCamera.aspect;
				this.Init(ctx, overrideCamera, overrideAspectRatio);
			}

			// Token: 0x06001397 RID: 5015 RVA: 0x0009581C File Offset: 0x00093A1C
			private void Init(CustomPassContext ctx, Camera overrideCamera, float overrideAspectRatio)
			{
				if (!CustomPassUtils.OverrideCameraRendering.IsContextValid(ctx, overrideCamera))
				{
					return;
				}
				this.overrideHDCamera.isPersistent = true;
				overrideCamera.aspect = overrideAspectRatio;
				if (overrideCamera.targetTexture == null)
				{
					this.overrideHDCamera.OverridePixelRect(ctx.hdCamera.camera.pixelRect);
				}
				HDRenderPipeline currentPipeline = HDRenderPipeline.currentPipeline;
				this.overrideHDCamera.Update(this.overrideHDCamera.frameSettings, currentPipeline, XRSystem.emptyPass, false);
				ctx.hdCamera.SetReferenceSize();
				ShaderVariablesGlobal currentGlobalState = ctx.currentGlobalState;
				this.overrideHDCamera.UpdateShaderVariablesGlobalCB(ref currentGlobalState);
				ConstantBuffer.PushGlobal<ShaderVariablesGlobal>(ctx.cmd, currentGlobalState, HDShaderIDs._ShaderVariablesGlobal);
				CustomPassUtils.OverrideCameraRendering.overrideCameraStack.Push(this.overrideHDCamera);
				CustomPassUtils.OverrideCameraRendering.overrideGlobalVariablesStack.Push(currentGlobalState);
			}

			// Token: 0x06001398 RID: 5016 RVA: 0x000958DE File Offset: 0x00093ADE
			private static bool IsContextValid(CustomPassContext ctx, Camera overrideCamera)
			{
				return !(overrideCamera == ctx.hdCamera.camera);
			}

			// Token: 0x06001399 RID: 5017 RVA: 0x000958F8 File Offset: 0x00093AF8
			void IDisposable.Dispose()
			{
				if (!CustomPassUtils.OverrideCameraRendering.IsContextValid(this.ctx, this.overrideCamera))
				{
					return;
				}
				if (this.overrideCamera.targetTexture == null)
				{
					this.overrideHDCamera.ResetPixelRect();
				}
				this.overrideCamera.aspect = this.originalAspect;
				CustomPassUtils.OverrideCameraRendering.overrideCameraStack.Pop();
				if (CustomPassUtils.OverrideCameraRendering.overrideCameraStack.Count > 0)
				{
					CustomPassUtils.OverrideCameraRendering.overrideCameraStack.Peek().SetReferenceSize();
				}
				else
				{
					this.ctx.hdCamera.SetReferenceSize();
				}
				CustomPassUtils.OverrideCameraRendering.overrideGlobalVariablesStack.Pop();
				if (CustomPassUtils.OverrideCameraRendering.overrideGlobalVariablesStack.Count > 0)
				{
					CommandBuffer cmd = this.ctx.cmd;
					ShaderVariablesGlobal shaderVariablesGlobal = CustomPassUtils.OverrideCameraRendering.overrideGlobalVariablesStack.Peek();
					ConstantBuffer.PushGlobal<ShaderVariablesGlobal>(cmd, shaderVariablesGlobal, HDShaderIDs._ShaderVariablesGlobal);
					return;
				}
				ConstantBuffer.PushGlobal<ShaderVariablesGlobal>(this.ctx.cmd, this.ctx.currentGlobalState, HDShaderIDs._ShaderVariablesGlobal);
			}

			// Token: 0x0400285B RID: 10331
			private CustomPassContext ctx;

			// Token: 0x0400285C RID: 10332
			private Camera overrideCamera;

			// Token: 0x0400285D RID: 10333
			private HDCamera overrideHDCamera;

			// Token: 0x0400285E RID: 10334
			private float originalAspect;

			// Token: 0x0400285F RID: 10335
			private static Stack<HDCamera> overrideCameraStack = new Stack<HDCamera>();

			// Token: 0x04002860 RID: 10336
			private static Stack<ShaderVariablesGlobal> overrideGlobalVariablesStack = new Stack<ShaderVariablesGlobal>();
		}
	}
}
