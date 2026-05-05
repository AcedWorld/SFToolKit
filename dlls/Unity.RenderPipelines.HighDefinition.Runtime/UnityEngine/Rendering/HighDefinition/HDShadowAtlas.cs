using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000C6 RID: 198
	internal class HDShadowAtlas
	{
		// Token: 0x060008CF RID: 2255 RVA: 0x0004E162 File Offset: 0x0004C362
		internal bool HasShadowRequests()
		{
			return this.m_ShadowRequests.Count > 0;
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060008D0 RID: 2256 RVA: 0x0004E172 File Offset: 0x0004C372
		// (set) Token: 0x060008D1 RID: 2257 RVA: 0x0004E17A File Offset: 0x0004C37A
		public int width { get; private set; }

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060008D2 RID: 2258 RVA: 0x0004E183 File Offset: 0x0004C383
		// (set) Token: 0x060008D3 RID: 2259 RVA: 0x0004E18B File Offset: 0x0004C38B
		public int height { get; private set; }

		// Token: 0x060008D4 RID: 2260 RVA: 0x0004E194 File Offset: 0x0004C394
		public TextureDesc GetShadowMapTextureDesc()
		{
			return new TextureDesc(this.width, this.height, false, false)
			{
				filterMode = this.m_FilterMode,
				depthBufferBits = this.m_DepthBufferBits,
				isShadowMap = true,
				name = this.m_Name
			};
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x0004E1E6 File Offset: 0x0004C3E6
		public HDShadowAtlas()
		{
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x0004E1FC File Offset: 0x0004C3FC
		public virtual void InitAtlas(HDShadowAtlas.HDShadowAtlasInitParameters initParams)
		{
			this.width = initParams.width;
			this.height = initParams.height;
			this.m_FilterMode = initParams.filterMode;
			this.m_DepthBufferBits = initParams.depthBufferBits;
			this.m_Format = initParams.format;
			this.m_Name = initParams.name;
			this.m_MomentName = this.m_Name + "Moment";
			this.m_MomentCopyName = this.m_Name + "MomentCopy";
			this.m_IntermediateSummedAreaName = this.m_Name + "IntermediateSummedArea";
			this.m_SummedAreaName = this.m_Name + "SummedAreaFinal";
			this.m_AtlasShaderID = initParams.atlasShaderID;
			this.m_ClearMaterial = initParams.clearMaterial;
			this.m_BlurAlgorithm = initParams.blurAlgorithm;
			this.m_RenderPipelineResources = initParams.renderPipelineResources;
			this.m_IsACacheForShadows = initParams.isShadowCache;
			this.m_GlobalConstantBuffer = initParams.cb;
			this.InitializeRenderGraphOutput(initParams.renderGraph, initParams.useSharedTexture);
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x0004E303 File Offset: 0x0004C503
		public HDShadowAtlas(HDShadowAtlas.HDShadowAtlasInitParameters initParams)
		{
			this.InitAtlas(initParams);
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x0004E320 File Offset: 0x0004C520
		private TextureDesc GetMomentAtlasDesc(string name)
		{
			return new TextureDesc(this.width / 2, this.height / 2, false, false)
			{
				colorFormat = GraphicsFormat.R32G32_SFloat,
				useMipMap = true,
				autoGenerateMips = false,
				name = name,
				enableRandomWrite = true
			};
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x0004E370 File Offset: 0x0004C570
		private TextureDesc GetImprovedMomentAtlasDesc()
		{
			return new TextureDesc(this.width, this.height, false, false)
			{
				colorFormat = GraphicsFormat.R32G32B32A32_SFloat,
				name = this.m_MomentName,
				enableRandomWrite = true,
				clearColor = Color.black
			};
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x0004E3C0 File Offset: 0x0004C5C0
		internal TextureDesc GetAtlasDesc()
		{
			switch (this.m_BlurAlgorithm)
			{
			case HDShadowAtlas.BlurAlgorithm.None:
				return this.GetShadowMapTextureDesc();
			case HDShadowAtlas.BlurAlgorithm.EVSM:
				return this.GetMomentAtlasDesc(this.m_MomentName);
			case HDShadowAtlas.BlurAlgorithm.IM:
				return this.GetImprovedMomentAtlasDesc();
			default:
				return default(TextureDesc);
			}
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x0004E40C File Offset: 0x0004C60C
		public void UpdateSize(Vector2Int size)
		{
			this.width = size.x;
			this.height = size.y;
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x0004E428 File Offset: 0x0004C628
		internal void AddShadowRequest(HDShadowRequest shadowRequest)
		{
			this.m_ShadowRequests.Add(shadowRequest);
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x0004E436 File Offset: 0x0004C636
		public void UpdateDebugSettings(LightingDebugSettings lightingDebugSettings)
		{
			this.m_LightingDebugSettings = lightingDebugSettings;
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x0004E43F File Offset: 0x0004C63F
		public void InvalidateOutputIfNeeded()
		{
			if (!this.m_UseSharedTexture)
			{
				this.m_Output = TextureHandle.nullHandle;
			}
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x0004E454 File Offset: 0x0004C654
		public TextureHandle GetOutputTexture(RenderGraph renderGraph)
		{
			if (this.m_UseSharedTexture)
			{
				TextureDesc atlasDesc = this.GetAtlasDesc();
				TextureDesc textureDesc = renderGraph.GetTextureDesc(this.m_Output);
				if (textureDesc.width != atlasDesc.width || textureDesc.height != atlasDesc.height)
				{
					renderGraph.RefreshSharedTextureDesc(this.m_Output, atlasDesc);
				}
				return this.m_Output;
			}
			TextureDesc atlasDesc2 = this.GetAtlasDesc();
			renderGraph.CreateTextureIfInvalid(atlasDesc2, ref this.m_Output);
			return this.m_Output;
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x0004E4CC File Offset: 0x0004C6CC
		public TextureHandle GetShadowMapDepthTexture(RenderGraph renderGraph)
		{
			if (this.m_BlurAlgorithm == HDShadowAtlas.BlurAlgorithm.None)
			{
				return this.GetOutputTexture(renderGraph);
			}
			TextureDesc shadowMapTextureDesc = this.GetShadowMapTextureDesc();
			renderGraph.CreateTextureIfInvalid(shadowMapTextureDesc, ref this.m_ShadowMapOutput);
			return this.m_ShadowMapOutput;
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x0004E504 File Offset: 0x0004C704
		protected void InitializeRenderGraphOutput(RenderGraph renderGraph, bool useSharedTexture)
		{
			bool useSharedTexture2 = this.m_UseSharedTexture;
			this.m_UseSharedTexture = useSharedTexture;
			if (this.m_UseSharedTexture)
			{
				TextureDesc atlasDesc = this.GetAtlasDesc();
				this.m_Output = renderGraph.CreateSharedTexture(atlasDesc, true);
			}
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x0004E53D File Offset: 0x0004C73D
		internal void CleanupRenderGraphOutput(RenderGraph renderGraph)
		{
			if (this.m_UseSharedTexture && renderGraph != null && this.m_Output.IsValid())
			{
				renderGraph.ReleaseSharedTexture(this.m_Output);
				this.m_UseSharedTexture = false;
				this.m_Output = TextureHandle.nullHandle;
			}
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x0004E575 File Offset: 0x0004C775
		public bool HasBlurredEVSM()
		{
			return this.m_BlurAlgorithm == HDShadowAtlas.BlurAlgorithm.EVSM;
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x0004E580 File Offset: 0x0004C780
		internal TextureHandle RenderShadowMaps(RenderGraph renderGraph, CullingResults cullResults, in ShaderVariablesGlobal globalCBData, FrameSettings frameSettings, string shadowPassName)
		{
			HDShadowAtlas.RenderShadowMapsPassData renderShadowMapsPassData;
			TextureHandle result;
			using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<HDShadowAtlas.RenderShadowMapsPassData>("Render Shadow Maps", out renderShadowMapsPassData, ProfilingSampler.Get<HDProfileId>(HDProfileId.RenderShadowMaps)))
			{
				renderShadowMapsPassData.globalCBData = globalCBData;
				renderShadowMapsPassData.globalCB = this.m_GlobalConstantBuffer;
				renderShadowMapsPassData.shadowRequests = this.m_ShadowRequests;
				renderShadowMapsPassData.clearMaterial = this.m_ClearMaterial;
				renderShadowMapsPassData.debugClearAtlas = this.m_LightingDebugSettings.clearShadowAtlas;
				renderShadowMapsPassData.shadowDrawSettings = new ShadowDrawingSettings(cullResults, 0, BatchCullingProjectionType.Perspective);
				renderShadowMapsPassData.shadowDrawSettings.useRenderingLayerMaskTest = frameSettings.IsEnabled(FrameSettingsField.LightLayers);
				renderShadowMapsPassData.isRenderingOnACache = this.m_IsACacheForShadows;
				if (this.m_BlurAlgorithm == HDShadowAtlas.BlurAlgorithm.EVSM || this.m_BlurAlgorithm == HDShadowAtlas.BlurAlgorithm.IM)
				{
					HDShadowAtlas.RenderShadowMapsPassData renderShadowMapsPassData2 = renderShadowMapsPassData;
					result = this.GetShadowMapDepthTexture(renderGraph);
					renderShadowMapsPassData2.atlasTexture = renderGraphBuilder.WriteTexture(result);
				}
				else
				{
					HDShadowAtlas.RenderShadowMapsPassData renderShadowMapsPassData3 = renderShadowMapsPassData;
					result = this.GetOutputTexture(renderGraph);
					renderShadowMapsPassData3.atlasTexture = renderGraphBuilder.WriteTexture(result);
				}
				renderGraphBuilder.SetRenderFunc<HDShadowAtlas.RenderShadowMapsPassData>(delegate(HDShadowAtlas.RenderShadowMapsPassData data, RenderGraphContext ctx)
				{
					ctx.cmd.SetRenderTarget(data.atlasTexture, RenderBufferLoadAction.DontCare, RenderBufferStoreAction.Store);
					if (data.debugClearAtlas)
					{
						CoreUtils.DrawFullScreen(ctx.cmd, data.clearMaterial, null, 0);
					}
					foreach (HDShadowRequest hdshadowRequest in data.shadowRequests)
					{
						bool flag = (hdshadowRequest.shadowMapType != ShadowMapType.CascadedDirectional) ? (!hdshadowRequest.shouldRenderCachedComponent && data.isRenderingOnACache) : (!hdshadowRequest.shouldRenderCachedComponent && hdshadowRequest.shouldUseCachedShadowData);
						if (hdshadowRequest.shadowMapType == ShadowMapType.CascadedDirectional && hdshadowRequest.isMixedCached)
						{
							flag = (!hdshadowRequest.shouldRenderCachedComponent && data.isRenderingOnACache);
						}
						if (!flag)
						{
							bool flag2 = false;
							if (hdshadowRequest.isMixedCached)
							{
								flag2 = !data.isRenderingOnACache;
								data.shadowDrawSettings.objectsFilter = (flag2 ? ShadowObjectsFilter.DynamicOnly : ShadowObjectsFilter.StaticOnly);
							}
							else
							{
								data.shadowDrawSettings.objectsFilter = ShadowObjectsFilter.AllObjects;
							}
							ctx.cmd.SetGlobalDepthBias(1f, hdshadowRequest.slopeBias);
							ctx.cmd.SetViewport(data.isRenderingOnACache ? hdshadowRequest.cachedAtlasViewport : hdshadowRequest.dynamicAtlasViewport);
							ctx.cmd.SetGlobalFloat(HDShaderIDs._ZClip, hdshadowRequest.zClip ? 1f : 0f);
							if (!flag2)
							{
								CoreUtils.DrawFullScreen(ctx.cmd, data.clearMaterial, null, 0);
							}
							data.shadowDrawSettings.lightIndex = hdshadowRequest.lightIndex;
							data.shadowDrawSettings.splitData = hdshadowRequest.splitData;
							data.shadowDrawSettings.projectionType = hdshadowRequest.projectionType;
							Matrix4x4 matrix4x = hdshadowRequest.view;
							if (flag2 && hdshadowRequest.shadowMapType == ShadowMapType.CascadedDirectional)
							{
								matrix4x *= Matrix4x4.Translate(hdshadowRequest.cachedShadowData.cacheTranslationDelta);
							}
							Matrix4x4 viewProjMatrix = hdshadowRequest.deviceProjectionYFlip * matrix4x;
							data.globalCBData._ViewMatrix = matrix4x;
							data.globalCBData._InvViewMatrix = matrix4x.inverse;
							data.globalCBData._ProjMatrix = hdshadowRequest.deviceProjectionYFlip;
							data.globalCBData._InvProjMatrix = hdshadowRequest.deviceProjectionYFlip.inverse;
							data.globalCBData._ViewProjMatrix = viewProjMatrix;
							data.globalCBData._InvViewProjMatrix = viewProjMatrix.inverse;
							data.globalCBData._SlopeScaleDepthBias = -hdshadowRequest.slopeBias;
							data.globalCBData._GlobalMipBias = 0f;
							data.globalCBData._GlobalMipBiasPow2 = 1f;
							data.globalCB.PushGlobal(ctx.cmd, data.globalCBData, HDShaderIDs._ShaderVariablesGlobal);
							ctx.cmd.SetGlobalVectorArray(HDShaderIDs._ShadowFrustumPlanes, hdshadowRequest.frustumPlanes);
							ctx.renderContext.ExecuteCommandBuffer(ctx.cmd);
							ctx.cmd.Clear();
							ctx.renderContext.DrawShadows(ref data.shadowDrawSettings);
						}
					}
					ctx.cmd.SetGlobalFloat(HDShaderIDs._ZClip, 1f);
					ctx.cmd.SetGlobalDepthBias(0f, 0f);
				});
				this.m_ShadowMapOutput = renderShadowMapsPassData.atlasTexture;
				result = renderShadowMapsPassData.atlasTexture;
			}
			return result;
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x0004E6B0 File Offset: 0x0004C8B0
		private unsafe TextureHandle EVSMBlurMoments(RenderGraph renderGraph, TextureHandle inputAtlas)
		{
			HDShadowAtlas.EVSMBlurMomentsPassData evsmblurMomentsPassData;
			TextureHandle result;
			using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<HDShadowAtlas.EVSMBlurMomentsPassData>("EVSM Blur Moments", out evsmblurMomentsPassData, ProfilingSampler.Get<HDProfileId>(HDProfileId.RenderEVSMShadowMaps)))
			{
				evsmblurMomentsPassData.evsmShadowBlurMomentsCS = this.m_RenderPipelineResources.shaders.evsmBlurCS;
				evsmblurMomentsPassData.shadowRequests = this.m_ShadowRequests;
				evsmblurMomentsPassData.isRenderingOnACache = this.m_IsACacheForShadows;
				evsmblurMomentsPassData.atlasTexture = renderGraphBuilder.ReadTexture(inputAtlas);
				HDShadowAtlas.EVSMBlurMomentsPassData evsmblurMomentsPassData2 = evsmblurMomentsPassData;
				result = this.GetOutputTexture(renderGraph);
				evsmblurMomentsPassData2.momentAtlasTexture1 = renderGraphBuilder.WriteTexture(result);
				HDShadowAtlas.EVSMBlurMomentsPassData evsmblurMomentsPassData3 = evsmblurMomentsPassData;
				TextureDesc momentAtlasDesc = this.GetMomentAtlasDesc(this.m_MomentCopyName);
				result = renderGraph.CreateTexture(momentAtlasDesc);
				evsmblurMomentsPassData3.momentAtlasTexture2 = renderGraphBuilder.WriteTexture(result);
				renderGraphBuilder.SetRenderFunc<HDShadowAtlas.EVSMBlurMomentsPassData>(delegate(HDShadowAtlas.EVSMBlurMomentsPassData data, RenderGraphContext ctx)
				{
					ComputeShader evsmShadowBlurMomentsCS = data.evsmShadowBlurMomentsCS;
					HDShadowAtlas.<>c__DisplayClass50_0 CS$<>8__locals1;
					CS$<>8__locals1.momentAtlasRenderTextures = ctx.renderGraphPool.GetTempArray<RTHandle>(2);
					CS$<>8__locals1.momentAtlasRenderTextures[0] = data.momentAtlasTexture1;
					CS$<>8__locals1.momentAtlasRenderTextures[1] = data.momentAtlasTexture2;
					int kernelIndex = evsmShadowBlurMomentsCS.FindKernel("ConvertAndBlur");
					int kernelIndex2 = evsmShadowBlurMomentsCS.FindKernel("Blur");
					int kernelIndex3 = evsmShadowBlurMomentsCS.FindKernel("CopyMoments");
					RTHandle rthandle = data.atlasTexture;
					ctx.cmd.SetComputeTextureParam(evsmShadowBlurMomentsCS, kernelIndex, HDShaderIDs._DepthTexture, rthandle);
					ctx.cmd.SetComputeVectorArrayParam(evsmShadowBlurMomentsCS, HDShaderIDs._BlurWeightsStorage, HDShadowAtlas.evsmBlurWeights);
					int* ptr = stackalloc int[checked(unchecked((UIntPtr)data.shadowRequests.Count) * 4)];
					int num = 0;
					foreach (HDShadowRequest hdshadowRequest in data.shadowRequests)
					{
						if (!((hdshadowRequest.shadowMapType != ShadowMapType.CascadedDirectional) ? (!hdshadowRequest.shouldRenderCachedComponent && data.isRenderingOnACache) : (!hdshadowRequest.shouldRenderCachedComponent && hdshadowRequest.shouldUseCachedShadowData)))
						{
							Rect rect = data.isRenderingOnACache ? hdshadowRequest.cachedAtlasViewport : hdshadowRequest.dynamicAtlasViewport;
							using (new ProfilingScope(ctx.cmd, ProfilingSampler.Get<HDProfileId>(HDProfileId.RenderEVSMShadowMapsBlur)))
							{
								int num2 = Mathf.CeilToInt(rect.width * 0.5f);
								int num3 = Mathf.CeilToInt(rect.height * 0.5f);
								Vector2 vector = new Vector2(rect.min.x * 0.5f, rect.min.y * 0.5f);
								ctx.cmd.SetComputeTextureParam(evsmShadowBlurMomentsCS, kernelIndex, HDShaderIDs._OutputTexture, CS$<>8__locals1.momentAtlasRenderTextures[0]);
								ctx.cmd.SetComputeVectorParam(evsmShadowBlurMomentsCS, HDShaderIDs._SrcRect, new Vector4(rect.min.x, rect.min.y, rect.width, rect.height));
								ctx.cmd.SetComputeVectorParam(evsmShadowBlurMomentsCS, HDShaderIDs._DstRect, new Vector4(vector.x, vector.y, 1f / (float)rthandle.rt.width, 1f / (float)rthandle.rt.height));
								ctx.cmd.SetComputeFloatParam(evsmShadowBlurMomentsCS, HDShaderIDs._EVSMExponent, hdshadowRequest.evsmParams.x);
								int threadGroupsX = (num2 + 7) / 8;
								int threadGroupsY = (num3 + 7) / 8;
								ctx.cmd.DispatchCompute(evsmShadowBlurMomentsCS, kernelIndex, threadGroupsX, threadGroupsY, 1);
								HDShadowAtlas.<>c__DisplayClass50_1 CS$<>8__locals2;
								CS$<>8__locals2.currentAtlasMomentSurface = 0;
								ctx.cmd.SetComputeVectorParam(evsmShadowBlurMomentsCS, HDShaderIDs._SrcRect, new Vector4(vector.x, vector.y, (float)num2, (float)num3));
								int num4 = 0;
								while ((float)num4 < hdshadowRequest.evsmParams.w)
								{
									CS$<>8__locals2.currentAtlasMomentSurface = (CS$<>8__locals2.currentAtlasMomentSurface + 1 & 1);
									ctx.cmd.SetComputeTextureParam(evsmShadowBlurMomentsCS, kernelIndex2, HDShaderIDs._InputTexture, HDShadowAtlas.<EVSMBlurMoments>g__GetMomentRTCopy|50_2(ref CS$<>8__locals1, ref CS$<>8__locals2));
									ctx.cmd.SetComputeTextureParam(evsmShadowBlurMomentsCS, kernelIndex2, HDShaderIDs._OutputTexture, HDShadowAtlas.<EVSMBlurMoments>g__GetMomentRT|50_1(ref CS$<>8__locals1, ref CS$<>8__locals2));
									ctx.cmd.DispatchCompute(evsmShadowBlurMomentsCS, kernelIndex2, threadGroupsX, threadGroupsY, 1);
									num4++;
								}
								ptr[(IntPtr)(num++) * 4] = CS$<>8__locals2.currentAtlasMomentSurface;
							}
						}
					}
					for (int i = 0; i < data.shadowRequests.Count; i++)
					{
						if (ptr[i] != 0)
						{
							using (new ProfilingScope(ctx.cmd, ProfilingSampler.Get<HDProfileId>(HDProfileId.RenderEVSMShadowMapsCopyToAtlas)))
							{
								HDShadowRequest hdshadowRequest2 = data.shadowRequests[i];
								Rect rect2 = data.isRenderingOnACache ? hdshadowRequest2.cachedAtlasViewport : hdshadowRequest2.dynamicAtlasViewport;
								int num5 = Mathf.CeilToInt(rect2.width * 0.5f);
								int num6 = Mathf.CeilToInt(rect2.height * 0.5f);
								ctx.cmd.SetComputeVectorParam(evsmShadowBlurMomentsCS, HDShaderIDs._SrcRect, new Vector4(rect2.min.x * 0.5f, rect2.min.y * 0.5f, (float)num5, (float)num6));
								ctx.cmd.SetComputeTextureParam(evsmShadowBlurMomentsCS, kernelIndex3, HDShaderIDs._InputTexture, CS$<>8__locals1.momentAtlasRenderTextures[1]);
								ctx.cmd.SetComputeTextureParam(evsmShadowBlurMomentsCS, kernelIndex3, HDShaderIDs._OutputTexture, CS$<>8__locals1.momentAtlasRenderTextures[0]);
								int threadGroupsX2 = (num5 + 7) / 8;
								int threadGroupsY2 = (num6 + 7) / 8;
								ctx.cmd.DispatchCompute(evsmShadowBlurMomentsCS, kernelIndex3, threadGroupsX2, threadGroupsY2, 1);
							}
						}
					}
				});
				result = evsmblurMomentsPassData.momentAtlasTexture1;
			}
			return result;
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x0004E79C File Offset: 0x0004C99C
		private TextureHandle IMBlurMoment(RenderGraph renderGraph, TextureHandle atlasTexture)
		{
			HDShadowAtlas.IMBlurMomentPassData imblurMomentPassData;
			TextureHandle result;
			using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<HDShadowAtlas.IMBlurMomentPassData>("EVSM Blur Moments", out imblurMomentPassData, ProfilingSampler.Get<HDProfileId>(HDProfileId.RenderMomentShadowMaps)))
			{
				imblurMomentPassData.shadowRequests = this.m_ShadowRequests;
				imblurMomentPassData.isRenderingOnACache = this.m_IsACacheForShadows;
				imblurMomentPassData.imShadowBlurMomentsCS = this.m_RenderPipelineResources.shaders.momentShadowsCS;
				imblurMomentPassData.atlasTexture = renderGraphBuilder.ReadTexture(atlasTexture);
				HDShadowAtlas.IMBlurMomentPassData imblurMomentPassData2 = imblurMomentPassData;
				result = this.GetOutputTexture(renderGraph);
				imblurMomentPassData2.momentAtlasTexture = renderGraphBuilder.WriteTexture(result);
				HDShadowAtlas.IMBlurMomentPassData imblurMomentPassData3 = imblurMomentPassData;
				TextureDesc textureDesc = new TextureDesc(this.width, this.height, false, false);
				textureDesc.colorFormat = GraphicsFormat.R32G32B32A32_SInt;
				textureDesc.name = this.m_IntermediateSummedAreaName;
				textureDesc.enableRandomWrite = true;
				textureDesc.clearBuffer = true;
				textureDesc.clearColor = Color.black;
				result = renderGraph.CreateTexture(textureDesc);
				imblurMomentPassData3.intermediateSummedAreaTexture = renderGraphBuilder.WriteTexture(result);
				HDShadowAtlas.IMBlurMomentPassData imblurMomentPassData4 = imblurMomentPassData;
				textureDesc = new TextureDesc(this.width, this.height, false, false);
				textureDesc.colorFormat = GraphicsFormat.R32G32B32A32_SInt;
				textureDesc.name = this.m_SummedAreaName;
				textureDesc.enableRandomWrite = true;
				textureDesc.clearColor = Color.black;
				result = renderGraph.CreateTexture(textureDesc);
				imblurMomentPassData4.summedAreaTexture = renderGraphBuilder.WriteTexture(result);
				renderGraphBuilder.SetRenderFunc<HDShadowAtlas.IMBlurMomentPassData>(delegate(HDShadowAtlas.IMBlurMomentPassData data, RenderGraphContext ctx)
				{
					ComputeShader imShadowBlurMomentsCS = data.imShadowBlurMomentsCS;
					if (imShadowBlurMomentsCS == null)
					{
						return;
					}
					int kernelIndex = imShadowBlurMomentsCS.FindKernel("ComputeMomentShadows");
					int kernelIndex2 = imShadowBlurMomentsCS.FindKernel("MomentSummedAreaTableHorizontal");
					int kernelIndex3 = imShadowBlurMomentsCS.FindKernel("MomentSummedAreaTableVertical");
					RTHandle handle = data.atlasTexture;
					RTHandle rthandle = data.momentAtlasTexture;
					RTHandle handle2 = data.intermediateSummedAreaTexture;
					RTHandle handle3 = data.summedAreaTexture;
					foreach (HDShadowRequest hdshadowRequest in data.shadowRequests)
					{
						ctx.cmd.SetComputeTextureParam(imShadowBlurMomentsCS, kernelIndex, HDShaderIDs._ShadowmapAtlas, handle);
						ctx.cmd.SetComputeTextureParam(imShadowBlurMomentsCS, kernelIndex, HDShaderIDs._MomentShadowAtlas, rthandle);
						ctx.cmd.SetComputeVectorParam(imShadowBlurMomentsCS, HDShaderIDs._MomentShadowmapSlotST, new Vector4(hdshadowRequest.dynamicAtlasViewport.width, hdshadowRequest.dynamicAtlasViewport.height, hdshadowRequest.dynamicAtlasViewport.min.x, hdshadowRequest.dynamicAtlasViewport.min.y));
						int threadGroupsX = Math.Max((int)hdshadowRequest.dynamicAtlasViewport.width / 8, 1);
						int threadGroupsY = Math.Max((int)hdshadowRequest.dynamicAtlasViewport.height / 8, 1);
						ctx.cmd.DispatchCompute(imShadowBlurMomentsCS, kernelIndex, threadGroupsX, threadGroupsY, 1);
						ctx.cmd.SetComputeTextureParam(imShadowBlurMomentsCS, kernelIndex2, HDShaderIDs._SummedAreaTableInputFloat, rthandle);
						ctx.cmd.SetComputeTextureParam(imShadowBlurMomentsCS, kernelIndex2, HDShaderIDs._SummedAreaTableOutputInt, handle2);
						ctx.cmd.SetComputeFloatParam(imShadowBlurMomentsCS, HDShaderIDs._IMSKernelSize, hdshadowRequest.kernelSize);
						ctx.cmd.SetComputeVectorParam(imShadowBlurMomentsCS, HDShaderIDs._MomentShadowmapSize, new Vector2((float)rthandle.referenceSize.x, (float)rthandle.referenceSize.y));
						int threadGroupsX2 = Math.Max((int)hdshadowRequest.dynamicAtlasViewport.width / 64, 1);
						ctx.cmd.DispatchCompute(imShadowBlurMomentsCS, kernelIndex2, threadGroupsX2, 1, 1);
						ctx.cmd.SetComputeTextureParam(imShadowBlurMomentsCS, kernelIndex3, HDShaderIDs._SummedAreaTableInputInt, handle2);
						ctx.cmd.SetComputeTextureParam(imShadowBlurMomentsCS, kernelIndex3, HDShaderIDs._SummedAreaTableOutputInt, handle3);
						ctx.cmd.SetComputeVectorParam(imShadowBlurMomentsCS, HDShaderIDs._MomentShadowmapSize, new Vector2((float)rthandle.referenceSize.x, (float)rthandle.referenceSize.y));
						ctx.cmd.SetComputeFloatParam(imShadowBlurMomentsCS, HDShaderIDs._IMSKernelSize, hdshadowRequest.kernelSize);
						int threadGroupsX3 = Math.Max((int)hdshadowRequest.dynamicAtlasViewport.height / 64, 1);
						ctx.cmd.DispatchCompute(imShadowBlurMomentsCS, kernelIndex3, threadGroupsX3, 1, 1);
						ctx.cmd.SetGlobalTexture(HDShaderIDs._SummedAreaTableInputInt, handle3);
					}
				});
				result = imblurMomentPassData.momentAtlasTexture;
			}
			return result;
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x0004E924 File Offset: 0x0004CB24
		internal TextureHandle BlurShadows(RenderGraph renderGraph)
		{
			if (this.m_ShadowRequests.Count == 0)
			{
				return renderGraph.defaultResources.defaultShadowTexture;
			}
			if (this.m_BlurAlgorithm == HDShadowAtlas.BlurAlgorithm.EVSM)
			{
				return this.EVSMBlurMoments(renderGraph, this.m_ShadowMapOutput);
			}
			if (this.m_BlurAlgorithm == HDShadowAtlas.BlurAlgorithm.IM)
			{
				return this.IMBlurMoment(renderGraph, this.m_ShadowMapOutput);
			}
			return this.m_ShadowMapOutput;
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x0004E980 File Offset: 0x0004CB80
		internal TextureHandle RenderShadows(RenderGraph renderGraph, CullingResults cullResults, in ShaderVariablesGlobal globalCB, FrameSettings frameSettings, string shadowPassName)
		{
			if (this.m_ShadowRequests.Count == 0)
			{
				return renderGraph.defaultResources.defaultShadowTexture;
			}
			this.RenderShadowMaps(renderGraph, cullResults, globalCB, frameSettings, shadowPassName);
			if (this.m_BlurAlgorithm == HDShadowAtlas.BlurAlgorithm.EVSM)
			{
				return this.EVSMBlurMoments(renderGraph, this.m_ShadowMapOutput);
			}
			if (this.m_BlurAlgorithm == HDShadowAtlas.BlurAlgorithm.IM)
			{
				return this.IMBlurMoment(renderGraph, this.m_ShadowMapOutput);
			}
			return this.m_ShadowMapOutput;
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x0004E9E8 File Offset: 0x0004CBE8
		public void AddBlitRequestsForUpdatedShadows(HDDynamicShadowAtlas dynamicAtlas)
		{
			if (this.m_IsACacheForShadows)
			{
				foreach (HDShadowRequest hdshadowRequest in this.m_ShadowRequests)
				{
					if (hdshadowRequest.shouldRenderCachedComponent)
					{
						dynamicAtlas.AddRequestToPendingBlitFromCache(hdshadowRequest);
					}
				}
			}
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x0004EA4C File Offset: 0x0004CC4C
		public virtual void DisplayAtlas(RTHandle atlasTexture, CommandBuffer cmd, Material debugMaterial, Rect atlasViewport, float screenX, float screenY, float screenSizeX, float screenSizeY, float minValue, float maxValue, MaterialPropertyBlock mpb, float scaleFactor = 1f)
		{
			if (atlasTexture == null)
			{
				return;
			}
			Vector4 value = new Vector4(minValue, 1f / (maxValue - minValue));
			float num = 1f / (float)this.width;
			float num2 = 1f / (float)this.height;
			Vector4 value2 = Vector4.Scale(new Vector4(num, num2, num, num2), new Vector4(atlasViewport.width, atlasViewport.height, atlasViewport.x, atlasViewport.y));
			mpb.SetTexture("_AtlasTexture", atlasTexture);
			mpb.SetVector("_TextureScaleBias", value2);
			mpb.SetVector("_ValidRange", value);
			mpb.SetFloat("_RcpGlobalScaleFactor", scaleFactor);
			cmd.SetViewport(new Rect(screenX, screenY, screenSizeX, screenSizeY));
			cmd.DrawProcedural(Matrix4x4.identity, debugMaterial, debugMaterial.FindPass("RegularShadow"), MeshTopology.Triangles, 3, 1, mpb);
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x0004EB26 File Offset: 0x0004CD26
		public virtual void Clear()
		{
			this.m_ShadowRequests.Clear();
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x0004EB33 File Offset: 0x0004CD33
		public void Release(RenderGraph renderGraph)
		{
			this.CleanupRenderGraphOutput(renderGraph);
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x0004EB94 File Offset: 0x0004CD94
		[CompilerGenerated]
		internal static RTHandle <EVSMBlurMoments>g__GetMomentRT|50_1(ref HDShadowAtlas.<>c__DisplayClass50_0 A_0, ref HDShadowAtlas.<>c__DisplayClass50_1 A_1)
		{
			return A_0.momentAtlasRenderTextures[A_1.currentAtlasMomentSurface];
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x0004EBA3 File Offset: 0x0004CDA3
		[CompilerGenerated]
		internal static RTHandle <EVSMBlurMoments>g__GetMomentRTCopy|50_2(ref HDShadowAtlas.<>c__DisplayClass50_0 A_0, ref HDShadowAtlas.<>c__DisplayClass50_1 A_1)
		{
			return A_0.momentAtlasRenderTextures[A_1.currentAtlasMomentSurface + 1 & 1];
		}

		// Token: 0x0400088C RID: 2188
		protected List<HDShadowRequest> m_ShadowRequests = new List<HDShadowRequest>();

		// Token: 0x0400088F RID: 2191
		private Material m_ClearMaterial;

		// Token: 0x04000890 RID: 2192
		private LightingDebugSettings m_LightingDebugSettings;

		// Token: 0x04000891 RID: 2193
		private FilterMode m_FilterMode;

		// Token: 0x04000892 RID: 2194
		private DepthBits m_DepthBufferBits;

		// Token: 0x04000893 RID: 2195
		private RenderTextureFormat m_Format;

		// Token: 0x04000894 RID: 2196
		private string m_Name;

		// Token: 0x04000895 RID: 2197
		private string m_MomentName;

		// Token: 0x04000896 RID: 2198
		private string m_MomentCopyName;

		// Token: 0x04000897 RID: 2199
		private string m_IntermediateSummedAreaName;

		// Token: 0x04000898 RID: 2200
		private string m_SummedAreaName;

		// Token: 0x04000899 RID: 2201
		private int m_AtlasShaderID;

		// Token: 0x0400089A RID: 2202
		private HDRenderPipelineRuntimeResources m_RenderPipelineResources;

		// Token: 0x0400089B RID: 2203
		private HDShadowAtlas.BlurAlgorithm m_BlurAlgorithm;

		// Token: 0x0400089C RID: 2204
		private ConstantBuffer<ShaderVariablesGlobal> m_GlobalConstantBuffer;

		// Token: 0x0400089D RID: 2205
		protected bool m_IsACacheForShadows;

		// Token: 0x0400089E RID: 2206
		private bool m_UseSharedTexture;

		// Token: 0x0400089F RID: 2207
		protected TextureHandle m_Output;

		// Token: 0x040008A0 RID: 2208
		protected TextureHandle m_ShadowMapOutput;

		// Token: 0x040008A1 RID: 2209
		private static readonly Vector4[] evsmBlurWeights = new Vector4[]
		{
			new Vector4(0.1531703f, 0.1448929f, 0.1226492f, 0.0929025f),
			new Vector4(0.06297021f, 0f, 0f, 0f)
		};

		// Token: 0x02000351 RID: 849
		internal struct HDShadowAtlasInitParameters
		{
			// Token: 0x060012C7 RID: 4807 RVA: 0x0008FA78 File Offset: 0x0008DC78
			internal HDShadowAtlasInitParameters(HDRenderPipelineRuntimeResources renderPipelineResources, RenderGraph renderGraph, bool useSharedTexture, int width, int height, int atlasShaderID, Material clearMaterial, int maxShadowRequests, HDShadowInitParameters initParams, ConstantBuffer<ShaderVariablesGlobal> cb)
			{
				this.renderPipelineResources = renderPipelineResources;
				this.renderGraph = renderGraph;
				this.useSharedTexture = useSharedTexture;
				this.width = width;
				this.height = height;
				this.atlasShaderID = atlasShaderID;
				this.clearMaterial = clearMaterial;
				this.maxShadowRequests = maxShadowRequests;
				this.initParams = initParams;
				this.blurAlgorithm = HDShadowAtlas.BlurAlgorithm.None;
				this.filterMode = FilterMode.Bilinear;
				this.depthBufferBits = DepthBits.Depth16;
				this.format = RenderTextureFormat.Shadowmap;
				this.name = "";
				this.isShadowCache = false;
				this.cb = cb;
			}

			// Token: 0x0400235E RID: 9054
			internal HDRenderPipelineRuntimeResources renderPipelineResources;

			// Token: 0x0400235F RID: 9055
			internal RenderGraph renderGraph;

			// Token: 0x04002360 RID: 9056
			internal bool useSharedTexture;

			// Token: 0x04002361 RID: 9057
			internal int width;

			// Token: 0x04002362 RID: 9058
			internal int height;

			// Token: 0x04002363 RID: 9059
			internal int atlasShaderID;

			// Token: 0x04002364 RID: 9060
			internal int maxShadowRequests;

			// Token: 0x04002365 RID: 9061
			internal string name;

			// Token: 0x04002366 RID: 9062
			internal bool isShadowCache;

			// Token: 0x04002367 RID: 9063
			internal Material clearMaterial;

			// Token: 0x04002368 RID: 9064
			internal HDShadowInitParameters initParams;

			// Token: 0x04002369 RID: 9065
			internal HDShadowAtlas.BlurAlgorithm blurAlgorithm;

			// Token: 0x0400236A RID: 9066
			internal FilterMode filterMode;

			// Token: 0x0400236B RID: 9067
			internal DepthBits depthBufferBits;

			// Token: 0x0400236C RID: 9068
			internal RenderTextureFormat format;

			// Token: 0x0400236D RID: 9069
			internal ConstantBuffer<ShaderVariablesGlobal> cb;
		}

		// Token: 0x02000352 RID: 850
		public enum BlurAlgorithm
		{
			// Token: 0x0400236F RID: 9071
			None,
			// Token: 0x04002370 RID: 9072
			EVSM,
			// Token: 0x04002371 RID: 9073
			IM
		}

		// Token: 0x02000353 RID: 851
		private class RenderShadowMapsPassData
		{
			// Token: 0x04002372 RID: 9074
			public TextureHandle atlasTexture;

			// Token: 0x04002373 RID: 9075
			public ShaderVariablesGlobal globalCBData;

			// Token: 0x04002374 RID: 9076
			public ConstantBuffer<ShaderVariablesGlobal> globalCB;

			// Token: 0x04002375 RID: 9077
			public ShadowDrawingSettings shadowDrawSettings;

			// Token: 0x04002376 RID: 9078
			public List<HDShadowRequest> shadowRequests;

			// Token: 0x04002377 RID: 9079
			public Material clearMaterial;

			// Token: 0x04002378 RID: 9080
			public bool debugClearAtlas;

			// Token: 0x04002379 RID: 9081
			public bool isRenderingOnACache;
		}

		// Token: 0x02000354 RID: 852
		private class EVSMBlurMomentsPassData
		{
			// Token: 0x0400237A RID: 9082
			public TextureHandle atlasTexture;

			// Token: 0x0400237B RID: 9083
			public TextureHandle momentAtlasTexture1;

			// Token: 0x0400237C RID: 9084
			public TextureHandle momentAtlasTexture2;

			// Token: 0x0400237D RID: 9085
			public ComputeShader evsmShadowBlurMomentsCS;

			// Token: 0x0400237E RID: 9086
			public List<HDShadowRequest> shadowRequests;

			// Token: 0x0400237F RID: 9087
			public bool isRenderingOnACache;
		}

		// Token: 0x02000355 RID: 853
		private class IMBlurMomentPassData
		{
			// Token: 0x04002380 RID: 9088
			public TextureHandle atlasTexture;

			// Token: 0x04002381 RID: 9089
			public TextureHandle momentAtlasTexture;

			// Token: 0x04002382 RID: 9090
			public TextureHandle intermediateSummedAreaTexture;

			// Token: 0x04002383 RID: 9091
			public TextureHandle summedAreaTexture;

			// Token: 0x04002384 RID: 9092
			public List<HDShadowRequest> shadowRequests;

			// Token: 0x04002385 RID: 9093
			public ComputeShader imShadowBlurMomentsCS;

			// Token: 0x04002386 RID: 9094
			public bool isRenderingOnACache;
		}
	}
}
