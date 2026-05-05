using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000D3 RID: 211
	internal class HDShadowManager
	{
		// Token: 0x1700014D RID: 333
		// (get) Token: 0x060008F4 RID: 2292 RVA: 0x0004ECF3 File Offset: 0x0004CEF3
		public static HDCachedShadowManager cachedShadowManager
		{
			get
			{
				return HDCachedShadowManager.instance;
			}
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x0004ECFC File Offset: 0x0004CEFC
		public void InitShadowManager(HDRenderPipelineRuntimeResources renderPipelineResources, HDShadowInitParameters initParams, RenderGraph renderGraph, Shader clearShader)
		{
			this.m_ShadowDataBuffer = new ComputeBuffer(Mathf.Max(initParams.maxShadowRequests, 1), Marshal.SizeOf(typeof(HDShadowData)));
			this.m_DirectionalShadowDataBuffer = new ComputeBuffer(1, Marshal.SizeOf(typeof(HDDirectionalShadowData)));
			this.m_MaxShadowRequests = initParams.maxShadowRequests;
			this.m_ShadowRequestCount = 0;
			if (initParams.maxShadowRequests == 0)
			{
				return;
			}
			this.m_ClearShadowMaterial = CoreUtils.CreateEngineMaterial(clearShader);
			this.m_BlitShadowMaterial = CoreUtils.CreateEngineMaterial(renderPipelineResources.shaders.shadowBlitPS);
			this.m_ShadowDatas.Capacity = Math.Max(initParams.maxShadowRequests, this.m_ShadowDatas.Capacity);
			this.m_ShadowResolutionRequests = new HDShadowResolutionRequest[initParams.maxShadowRequests];
			this.m_ShadowRequests = new HDShadowRequest[initParams.maxShadowRequests];
			this.m_CachedDirectionalShadowData = new HDDirectionalShadowData[1];
			this.m_GlobalShaderVariables = new ConstantBuffer<ShaderVariablesGlobal>();
			for (int i = 0; i < initParams.maxShadowRequests; i++)
			{
				this.m_ShadowResolutionRequests[i] = new HDShadowResolutionRequest();
			}
			HDShadowAtlas.HDShadowAtlasInitParameters hdshadowAtlasInitParameters = new HDShadowAtlas.HDShadowAtlasInitParameters(renderPipelineResources, renderGraph, false, initParams.punctualLightShadowAtlas.shadowAtlasResolution, initParams.punctualLightShadowAtlas.shadowAtlasResolution, HDShaderIDs._ShadowmapAtlas, this.m_ClearShadowMaterial, initParams.maxShadowRequests, initParams, this.m_GlobalShaderVariables)
			{
				name = "Shadow Map Atlas"
			};
			this.m_Atlas = new HDDynamicShadowAtlas(hdshadowAtlasInitParameters);
			HDShadowAtlas.BlurAlgorithm blurAlgorithm = (HDShadowManager.GetDirectionalShadowAlgorithm() == DirectionalShadowAlgorithm.IMS) ? HDShadowAtlas.BlurAlgorithm.IM : HDShadowAtlas.BlurAlgorithm.None;
			HDShadowAtlas.HDShadowAtlasInitParameters hdshadowAtlasInitParameters2 = hdshadowAtlasInitParameters;
			hdshadowAtlasInitParameters2.useSharedTexture = true;
			hdshadowAtlasInitParameters2.width = 1;
			hdshadowAtlasInitParameters2.height = 1;
			hdshadowAtlasInitParameters2.atlasShaderID = HDShaderIDs._ShadowmapCascadeAtlas;
			hdshadowAtlasInitParameters2.blurAlgorithm = blurAlgorithm;
			hdshadowAtlasInitParameters2.depthBufferBits = initParams.directionalShadowsDepthBits;
			hdshadowAtlasInitParameters2.name = "Cascade Shadow Map Atlas";
			this.m_CascadeAtlas = new HDDynamicShadowAtlas(hdshadowAtlasInitParameters2);
			HDShadowAtlas.HDShadowAtlasInitParameters hdshadowAtlasInitParameters3 = hdshadowAtlasInitParameters;
			if (ShaderConfig.s_AreaLights == 1)
			{
				hdshadowAtlasInitParameters3.useSharedTexture = false;
				hdshadowAtlasInitParameters3.width = initParams.areaLightShadowAtlas.shadowAtlasResolution;
				hdshadowAtlasInitParameters3.height = initParams.areaLightShadowAtlas.shadowAtlasResolution;
				hdshadowAtlasInitParameters3.atlasShaderID = HDShaderIDs._ShadowmapAreaAtlas;
				hdshadowAtlasInitParameters3.blurAlgorithm = HDShadowManager.GetAreaLightShadowBlurAlgorithm();
				hdshadowAtlasInitParameters3.depthBufferBits = initParams.areaLightShadowAtlas.shadowAtlasDepthBits;
				hdshadowAtlasInitParameters3.name = "Area Light Shadow Map Atlas";
				this.m_AreaLightShadowAtlas = new HDDynamicShadowAtlas(hdshadowAtlasInitParameters3);
			}
			HDShadowAtlas.HDShadowAtlasInitParameters atlasInitParams = hdshadowAtlasInitParameters;
			atlasInitParams.useSharedTexture = true;
			atlasInitParams.width = initParams.cachedPunctualLightShadowAtlas;
			atlasInitParams.height = initParams.cachedPunctualLightShadowAtlas;
			atlasInitParams.atlasShaderID = HDShaderIDs._CachedShadowmapAtlas;
			atlasInitParams.name = "Cached Shadow Map Atlas";
			atlasInitParams.isShadowCache = true;
			HDShadowManager.cachedShadowManager.InitPunctualShadowAtlas(atlasInitParams);
			if (ShaderConfig.s_AreaLights == 1)
			{
				HDShadowAtlas.HDShadowAtlasInitParameters atlasInitParams2 = hdshadowAtlasInitParameters3;
				atlasInitParams2.useSharedTexture = true;
				atlasInitParams2.width = initParams.cachedAreaLightShadowAtlas;
				atlasInitParams2.height = initParams.cachedAreaLightShadowAtlas;
				atlasInitParams2.atlasShaderID = HDShaderIDs._CachedAreaLightShadowmapAtlas;
				atlasInitParams2.name = "Cached Area Light Shadow Map Atlas";
				atlasInitParams2.isShadowCache = true;
				HDShadowManager.cachedShadowManager.InitAreaLightShadowAtlas(atlasInitParams2);
			}
			HDShadowManager.cachedShadowManager.InitDirectionalState(hdshadowAtlasInitParameters2, initParams.allowDirectionalMixedCachedShadows);
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x0004EFEC File Offset: 0x0004D1EC
		public void Cleanup(RenderGraph renderGraph)
		{
			this.m_ShadowDataBuffer.Dispose();
			this.m_DirectionalShadowDataBuffer.Dispose();
			if (this.m_MaxShadowRequests == 0)
			{
				return;
			}
			this.m_Atlas.Release(renderGraph);
			if (ShaderConfig.s_AreaLights == 1)
			{
				this.m_AreaLightShadowAtlas.Release(renderGraph);
			}
			this.m_CascadeAtlas.Release(renderGraph);
			CoreUtils.Destroy(this.m_ClearShadowMaterial);
			HDShadowManager.cachedShadowManager.Cleanup(renderGraph);
			this.m_GlobalShaderVariables.Release();
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x0004F068 File Offset: 0x0004D268
		public static DirectionalShadowAlgorithm GetDirectionalShadowAlgorithm()
		{
			switch (HDRenderPipeline.currentAsset.currentPlatformRenderPipelineSettings.hdShadowInitParams.shadowFilteringQuality)
			{
			case HDShadowFilteringQuality.Low:
				return DirectionalShadowAlgorithm.PCF5x5;
			case HDShadowFilteringQuality.Medium:
				return DirectionalShadowAlgorithm.PCF7x7;
			case HDShadowFilteringQuality.High:
				return DirectionalShadowAlgorithm.PCSS;
			default:
				return DirectionalShadowAlgorithm.PCF5x5;
			}
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x0004F0A5 File Offset: 0x0004D2A5
		public static HDShadowAtlas.BlurAlgorithm GetAreaLightShadowBlurAlgorithm()
		{
			if (HDRenderPipeline.currentAsset.currentPlatformRenderPipelineSettings.hdShadowInitParams.areaShadowFilteringQuality != HDAreaShadowFilteringQuality.High)
			{
				return HDShadowAtlas.BlurAlgorithm.EVSM;
			}
			return HDShadowAtlas.BlurAlgorithm.None;
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x0004F0C4 File Offset: 0x0004D2C4
		public void UpdateShaderVariablesGlobalCB(ref ShaderVariablesGlobal cb)
		{
			if (this.m_MaxShadowRequests == 0)
			{
				return;
			}
			cb._CascadeShadowCount = (uint)(this.m_CascadeCount + 1);
			cb._ShadowAtlasSize = new Vector4((float)this.m_Atlas.width, (float)this.m_Atlas.height, 1f / (float)this.m_Atlas.width, 1f / (float)this.m_Atlas.height);
			cb._CascadeShadowAtlasSize = new Vector4((float)this.m_CascadeAtlas.width, (float)this.m_CascadeAtlas.height, 1f / (float)this.m_CascadeAtlas.width, 1f / (float)this.m_CascadeAtlas.height);
			cb._CachedShadowAtlasSize = new Vector4((float)HDShadowManager.cachedShadowManager.punctualShadowAtlas.width, (float)HDShadowManager.cachedShadowManager.punctualShadowAtlas.height, 1f / (float)HDShadowManager.cachedShadowManager.punctualShadowAtlas.width, 1f / (float)HDShadowManager.cachedShadowManager.punctualShadowAtlas.height);
			if (ShaderConfig.s_AreaLights == 1)
			{
				cb._AreaShadowAtlasSize = new Vector4((float)this.m_AreaLightShadowAtlas.width, (float)this.m_AreaLightShadowAtlas.height, 1f / (float)this.m_AreaLightShadowAtlas.width, 1f / (float)this.m_AreaLightShadowAtlas.height);
				cb._CachedAreaShadowAtlasSize = new Vector4((float)HDShadowManager.cachedShadowManager.areaShadowAtlas.width, (float)HDShadowManager.cachedShadowManager.areaShadowAtlas.height, 1f / (float)HDShadowManager.cachedShadowManager.areaShadowAtlas.width, 1f / (float)HDShadowManager.cachedShadowManager.areaShadowAtlas.height);
			}
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x0004F278 File Offset: 0x0004D478
		public void UpdateDirectionalShadowResolution(int resolution, int cascadeCount)
		{
			Vector2Int size = new Vector2Int(resolution, resolution);
			if (cascadeCount > 1)
			{
				size.x *= 2;
			}
			if (cascadeCount > 2)
			{
				size.y *= 2;
			}
			this.m_CascadeAtlas.UpdateSize(size);
			if (HDShadowManager.cachedShadowManager.DirectionalHasCachedAtlas())
			{
				HDShadowManager.cachedShadowManager.directionalLightAtlas.UpdateSize(size);
			}
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x0004F2DC File Offset: 0x0004D4DC
		internal int ReserveShadowResolutions(Vector2 resolution, ShadowMapType shadowMapType, int lightID, int index, ShadowMapUpdateType updateType)
		{
			if (this.m_ShadowRequestCount >= this.m_MaxShadowRequests)
			{
				return -1;
			}
			this.m_ShadowResolutionRequests[this.m_ShadowResolutionRequestCounter].shadowMapType = shadowMapType;
			if (updateType != ShadowMapUpdateType.Cached || shadowMapType == ShadowMapType.CascadedDirectional)
			{
				this.m_ShadowResolutionRequests[this.m_ShadowResolutionRequestCounter].resolution = resolution;
				this.m_ShadowResolutionRequests[this.m_ShadowResolutionRequestCounter].dynamicAtlasViewport.width = resolution.x;
				this.m_ShadowResolutionRequests[this.m_ShadowResolutionRequestCounter].dynamicAtlasViewport.height = resolution.y;
				switch (shadowMapType)
				{
				case ShadowMapType.CascadedDirectional:
					this.m_CascadeAtlas.ReserveResolution(this.m_ShadowResolutionRequests[this.m_ShadowResolutionRequestCounter]);
					break;
				case ShadowMapType.PunctualAtlas:
					this.m_Atlas.ReserveResolution(this.m_ShadowResolutionRequests[this.m_ShadowResolutionRequestCounter]);
					break;
				case ShadowMapType.AreaLightAtlas:
					this.m_AreaLightShadowAtlas.ReserveResolution(this.m_ShadowResolutionRequests[this.m_ShadowResolutionRequestCounter]);
					break;
				}
			}
			this.m_ShadowResolutionRequestCounter++;
			this.m_ShadowRequestCount = this.m_ShadowResolutionRequestCounter;
			return this.m_ShadowResolutionRequestCounter - 1;
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x0004F3E6 File Offset: 0x0004D5E6
		internal HDShadowResolutionRequest GetResolutionRequest(int index)
		{
			if (index < 0 || index >= this.m_ShadowRequestCount)
			{
				return null;
			}
			return this.m_ShadowResolutionRequests[index];
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x0004F3FF File Offset: 0x0004D5FF
		public Vector2 GetReservedResolution(int index)
		{
			if (index < 0 || index >= this.m_ShadowRequestCount)
			{
				return Vector2.zero;
			}
			return this.m_ShadowResolutionRequests[index].resolution;
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x0004F424 File Offset: 0x0004D624
		internal void UpdateShadowRequest(int index, HDShadowRequest shadowRequest, ShadowMapUpdateType updateType)
		{
			if (index >= this.m_ShadowRequestCount)
			{
				return;
			}
			this.m_ShadowRequests[index] = shadowRequest;
			bool flag = updateType == ShadowMapUpdateType.Cached || updateType == ShadowMapUpdateType.Mixed;
			bool flag2 = updateType == ShadowMapUpdateType.Dynamic || updateType == ShadowMapUpdateType.Mixed;
			switch (shadowRequest.shadowMapType)
			{
			case ShadowMapType.CascadedDirectional:
				if (updateType == ShadowMapUpdateType.Mixed && HDShadowManager.cachedShadowManager.DirectionalHasCachedAtlas())
				{
					HDShadowManager.cachedShadowManager.directionalLightAtlas.AddShadowRequest(shadowRequest);
					this.m_CascadeAtlas.AddRequestToPendingBlitFromCache(shadowRequest);
				}
				this.m_CascadeAtlas.AddShadowRequest(shadowRequest);
				return;
			case ShadowMapType.PunctualAtlas:
				if (flag)
				{
					HDShadowManager.cachedShadowManager.punctualShadowAtlas.AddShadowRequest(shadowRequest);
				}
				if (flag2)
				{
					this.m_Atlas.AddShadowRequest(shadowRequest);
					if (updateType == ShadowMapUpdateType.Mixed)
					{
						this.m_Atlas.AddRequestToPendingBlitFromCache(shadowRequest);
						return;
					}
				}
				break;
			case ShadowMapType.AreaLightAtlas:
				if (flag)
				{
					HDShadowManager.cachedShadowManager.areaShadowAtlas.AddShadowRequest(shadowRequest);
				}
				if (flag2)
				{
					this.m_AreaLightShadowAtlas.AddShadowRequest(shadowRequest);
					if (updateType == ShadowMapUpdateType.Mixed)
					{
						this.m_AreaLightShadowAtlas.AddRequestToPendingBlitFromCache(shadowRequest);
					}
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x0004F518 File Offset: 0x0004D718
		public unsafe void UpdateCascade(int cascadeIndex, Vector4 cullingSphere, float border)
		{
			if (cullingSphere.w != float.NegativeInfinity)
			{
				cullingSphere.w *= cullingSphere.w;
			}
			this.m_CascadeCount = Mathf.Max(this.m_CascadeCount, cascadeIndex);
			fixed (float* ptr = &this.m_DirectionalShadowData.sphereCascades.FixedElementField)
			{
				((Vector4*)ptr)[cascadeIndex] = cullingSphere;
			}
			fixed (float* ptr = &this.m_DirectionalShadowData.cascadeBorders.FixedElementField)
			{
				ptr[cascadeIndex] = border;
			}
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x0004F598 File Offset: 0x0004D798
		private HDShadowData CreateShadowData(HDShadowRequest shadowRequest, HDShadowAtlas atlas)
		{
			HDShadowData result = default(HDShadowData);
			Matrix4x4 deviceProjection = shadowRequest.deviceProjection;
			Matrix4x4 view = shadowRequest.view;
			result.proj = new Vector4(deviceProjection.m00, deviceProjection.m11, deviceProjection.m22, deviceProjection.m23);
			result.pos = shadowRequest.position;
			result.rot0 = new Vector3(view.m00, view.m01, view.m02);
			result.rot1 = new Vector3(view.m10, view.m11, view.m12);
			result.rot2 = new Vector3(view.m20, view.m21, view.m22);
			result.shadowToWorld = shadowRequest.shadowToWorld;
			result.cacheTranslationDelta = new Vector3(0f, 0f, 0f);
			Rect rect = shadowRequest.isInCachedAtlas ? shadowRequest.cachedAtlasViewport : shadowRequest.dynamicAtlasViewport;
			float x = 1f / (float)atlas.width;
			float y = 1f / (float)atlas.height;
			result.atlasOffset = Vector2.Scale(new Vector2(x, y), new Vector2(rect.x, rect.y));
			result.shadowMapSize = new Vector4(rect.width, rect.height, 1f / rect.width, 1f / rect.height);
			result.normalBias = shadowRequest.normalBias;
			result.worldTexelSize = shadowRequest.worldTexelSize;
			result.shadowFilterParams0.x = shadowRequest.shadowSoftness;
			result.shadowFilterParams0.y = HDShadowUtils.Asfloat(shadowRequest.blockerSampleCount);
			result.shadowFilterParams0.z = HDShadowUtils.Asfloat(shadowRequest.filterSampleCount);
			result.shadowFilterParams0.w = shadowRequest.minFilterSize;
			result.zBufferParam = shadowRequest.zBufferParam;
			if (atlas.HasBlurredEVSM())
			{
				result.shadowFilterParams0 = shadowRequest.evsmParams;
			}
			result.isInCachedAtlas = (shadowRequest.isInCachedAtlas ? 1f : 0f);
			return result;
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x0004F7AC File Offset: 0x0004D9AC
		private unsafe Vector4 GetCascadeSphereAtIndex(int index)
		{
			fixed (float* ptr = &this.m_DirectionalShadowData.sphereCascades.FixedElementField)
			{
				return ((Vector4*)ptr)[index];
			}
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x0004F7DB File Offset: 0x0004D9DB
		public void UpdateCullingParameters(ref ScriptableCullingParameters cullingParams, float maxShadowDistance)
		{
			cullingParams.shadowDistance = Mathf.Min(maxShadowDistance, cullingParams.shadowDistance);
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x0004F7F0 File Offset: 0x0004D9F0
		public void LayoutShadowMaps(LightingDebugSettings lightingDebugSettings)
		{
			if (this.m_MaxShadowRequests == 0)
			{
				return;
			}
			HDShadowManager.cachedShadowManager.UpdateDebugSettings(lightingDebugSettings);
			this.m_Atlas.UpdateDebugSettings(lightingDebugSettings);
			if (this.m_CascadeAtlas != null)
			{
				this.m_CascadeAtlas.UpdateDebugSettings(lightingDebugSettings);
			}
			if (ShaderConfig.s_AreaLights == 1)
			{
				this.m_AreaLightShadowAtlas.UpdateDebugSettings(lightingDebugSettings);
			}
			if (lightingDebugSettings.shadowResolutionScaleFactor != 1f)
			{
				foreach (HDShadowResolutionRequest hdshadowResolutionRequest in this.m_ShadowResolutionRequests)
				{
					if (hdshadowResolutionRequest.shadowMapType != ShadowMapType.CascadedDirectional)
					{
						hdshadowResolutionRequest.resolution *= lightingDebugSettings.shadowResolutionScaleFactor;
					}
				}
			}
			if (this.m_CascadeAtlas != null && !this.m_CascadeAtlas.Layout(false))
			{
				Debug.LogError("Cascade Shadow atlasing has failed, only one directional light can cast shadows at a time");
			}
			this.m_Atlas.Layout(true);
			if (ShaderConfig.s_AreaLights == 1)
			{
				this.m_AreaLightShadowAtlas.Layout(true);
			}
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x0004F8CC File Offset: 0x0004DACC
		public unsafe void PrepareGPUShadowDatas(CullingResults cullResults, HDCamera camera)
		{
			if (this.m_MaxShadowRequests == 0)
			{
				return;
			}
			int num = 0;
			this.m_ShadowDatas.Clear();
			for (int i = 0; i < this.m_ShadowRequestCount; i++)
			{
				HDShadowAtlas atlas = this.m_Atlas;
				if (this.m_ShadowRequests[i].isInCachedAtlas)
				{
					atlas = HDShadowManager.cachedShadowManager.punctualShadowAtlas;
				}
				if (this.m_ShadowRequests[i].shadowMapType == ShadowMapType.CascadedDirectional)
				{
					atlas = this.m_CascadeAtlas;
				}
				else if (this.m_ShadowRequests[i].shadowMapType == ShadowMapType.AreaLightAtlas)
				{
					atlas = this.m_AreaLightShadowAtlas;
					if (this.m_ShadowRequests[i].isInCachedAtlas)
					{
						atlas = HDShadowManager.cachedShadowManager.areaShadowAtlas;
					}
				}
				HDShadowData hdshadowData;
				if (this.m_ShadowRequests[i].shouldUseCachedShadowData)
				{
					hdshadowData = this.m_ShadowRequests[i].cachedShadowData;
				}
				else
				{
					hdshadowData = this.CreateShadowData(this.m_ShadowRequests[i], atlas);
					this.m_ShadowRequests[i].cachedShadowData = hdshadowData;
				}
				this.m_ShadowDatas.Add(hdshadowData);
				this.m_ShadowRequests[i].shadowIndex = num++;
			}
			int num2 = 4;
			int num3 = 4;
			fixed (float* ptr = &this.m_DirectionalShadowData.sphereCascades.FixedElementField)
			{
				Vector4* ptr2 = (Vector4*)ptr;
				for (int j = 0; j < 4; j++)
				{
					num2 = ((num2 == 4 && ptr2[j].w > 0f) ? j : num2);
					num3 = (((num3 == 4 || num3 == num2) && ptr2[j].w > 0f) ? j : num3);
				}
			}
			if (num3 != 4)
			{
				this.m_DirectionalShadowData.cascadeDirection = (this.GetCascadeSphereAtIndex(num3) - this.GetCascadeSphereAtIndex(num2)).normalized;
			}
			else
			{
				this.m_DirectionalShadowData.cascadeDirection = Vector4.zero;
			}
			HDShadowSettings component = camera.volumeStack.GetComponent<HDShadowSettings>();
			this.m_DirectionalShadowData.cascadeDirection.w = (float)component.cascadeShadowSplitCount.value;
			this.GetShadowFadeScaleAndBias(component, out this.m_DirectionalShadowData.fadeScale, out this.m_DirectionalShadowData.fadeBias);
			if (this.m_ShadowRequestCount > 0)
			{
				this.m_ShadowDataBuffer.SetData<HDShadowData>(this.m_ShadowDatas);
				this.m_CachedDirectionalShadowData[0] = this.m_DirectionalShadowData;
				this.m_DirectionalShadowDataBuffer.SetData(this.m_CachedDirectionalShadowData);
			}
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x0004FB1C File Offset: 0x0004DD1C
		private void GetShadowFadeScaleAndBias(HDShadowSettings shadowSettings, out float scale, out float bias)
		{
			float value = shadowSettings.maxShadowDistance.value;
			float fadeDistance = value * value;
			int value2 = shadowSettings.cascadeShadowSplitCount.value;
			float value3;
			if (value2 == 4)
			{
				value3 = shadowSettings.cascadeShadowBorder3.value;
			}
			else if (value2 == 3)
			{
				value3 = shadowSettings.cascadeShadowBorder2.value;
			}
			else if (value2 == 2)
			{
				value3 = shadowSettings.cascadeShadowBorder1.value;
			}
			else
			{
				value3 = shadowSettings.cascadeShadowBorder0.value;
			}
			this.GetScaleAndBiasForLinearDistanceFade(fadeDistance, value3, out scale, out bias);
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x0004FB90 File Offset: 0x0004DD90
		private void GetScaleAndBiasForLinearDistanceFade(float fadeDistance, float border, out float scale, out float bias)
		{
			if (border < 0.0001f)
			{
				float num = 1000f;
				scale = num;
				bias = -fadeDistance * num;
				return;
			}
			border = 1f - border;
			border *= border;
			float num2 = border * fadeDistance;
			scale = 1f / (fadeDistance - num2);
			bias = -num2 / (fadeDistance - num2);
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x0004FBDC File Offset: 0x0004DDDC
		public void PushGlobalParameters(CommandBuffer cmd)
		{
			cmd.SetGlobalBuffer(HDShaderIDs._HDShadowDatas, this.m_ShadowDataBuffer);
			cmd.SetGlobalBuffer(HDShaderIDs._HDDirectionalShadowData, this.m_DirectionalShadowDataBuffer);
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x0004FC00 File Offset: 0x0004DE00
		public int GetShadowRequestCount()
		{
			return this.m_ShadowRequestCount;
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x0004FC08 File Offset: 0x0004DE08
		public void Clear()
		{
			if (this.m_MaxShadowRequests == 0)
			{
				return;
			}
			this.m_Atlas.Clear();
			this.m_CascadeAtlas.Clear();
			if (ShaderConfig.s_AreaLights == 1)
			{
				this.m_AreaLightShadowAtlas.Clear();
			}
			HDShadowManager.cachedShadowManager.ClearShadowRequests();
			this.m_ShadowResolutionRequestCounter = 0;
			this.m_ShadowRequestCount = 0;
			this.m_CascadeCount = 0;
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x0004FC68 File Offset: 0x0004DE68
		public void DisplayShadowAtlas(RTHandle atlasTexture, CommandBuffer cmd, Material debugMaterial, float screenX, float screenY, float screenSizeX, float screenSizeY, float minValue, float maxValue, MaterialPropertyBlock mpb)
		{
			this.m_Atlas.DisplayAtlas(atlasTexture, cmd, debugMaterial, new Rect(0f, 0f, (float)this.m_Atlas.width, (float)this.m_Atlas.height), screenX, screenY, screenSizeX, screenSizeY, minValue, maxValue, mpb);
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x0004FCB8 File Offset: 0x0004DEB8
		public void DisplayShadowCascadeAtlas(RTHandle atlasTexture, CommandBuffer cmd, Material debugMaterial, float screenX, float screenY, float screenSizeX, float screenSizeY, float minValue, float maxValue, MaterialPropertyBlock mpb)
		{
			this.m_CascadeAtlas.DisplayAtlas(atlasTexture, cmd, debugMaterial, new Rect(0f, 0f, (float)this.m_CascadeAtlas.width, (float)this.m_CascadeAtlas.height), screenX, screenY, screenSizeX, screenSizeY, minValue, maxValue, mpb);
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x0004FD08 File Offset: 0x0004DF08
		public void DisplayAreaLightShadowAtlas(RTHandle atlasTexture, CommandBuffer cmd, Material debugMaterial, float screenX, float screenY, float screenSizeX, float screenSizeY, float minValue, float maxValue, MaterialPropertyBlock mpb)
		{
			if (ShaderConfig.s_AreaLights == 1)
			{
				this.m_AreaLightShadowAtlas.DisplayAtlas(atlasTexture, cmd, debugMaterial, new Rect(0f, 0f, (float)this.m_AreaLightShadowAtlas.width, (float)this.m_AreaLightShadowAtlas.height), screenX, screenY, screenSizeX, screenSizeY, minValue, maxValue, mpb);
			}
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x0004FD60 File Offset: 0x0004DF60
		public void DisplayCachedPunctualShadowAtlas(RTHandle atlasTexture, CommandBuffer cmd, Material debugMaterial, float screenX, float screenY, float screenSizeX, float screenSizeY, float minValue, float maxValue, MaterialPropertyBlock mpb)
		{
			HDShadowManager.cachedShadowManager.punctualShadowAtlas.DisplayAtlas(atlasTexture, cmd, debugMaterial, new Rect(0f, 0f, (float)HDShadowManager.cachedShadowManager.punctualShadowAtlas.width, (float)HDShadowManager.cachedShadowManager.punctualShadowAtlas.height), screenX, screenY, screenSizeX, screenSizeY, minValue, maxValue, mpb, 1f);
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x0004FDC4 File Offset: 0x0004DFC4
		public void DisplayCachedAreaShadowAtlas(RTHandle atlasTexture, CommandBuffer cmd, Material debugMaterial, float screenX, float screenY, float screenSizeX, float screenSizeY, float minValue, float maxValue, MaterialPropertyBlock mpb)
		{
			if (ShaderConfig.s_AreaLights == 1)
			{
				HDShadowManager.cachedShadowManager.areaShadowAtlas.DisplayAtlas(atlasTexture, cmd, debugMaterial, new Rect(0f, 0f, (float)HDShadowManager.cachedShadowManager.areaShadowAtlas.width, (float)HDShadowManager.cachedShadowManager.areaShadowAtlas.height), screenX, screenY, screenSizeX, screenSizeY, minValue, maxValue, mpb, 1f);
			}
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x0004FE30 File Offset: 0x0004E030
		public void DisplayShadowMap(in ShadowResult atlasTextures, int shadowIndex, CommandBuffer cmd, Material debugMaterial, float screenX, float screenY, float screenSizeX, float screenSizeY, float minValue, float maxValue, MaterialPropertyBlock mpb)
		{
			if (shadowIndex >= this.m_ShadowRequestCount)
			{
				return;
			}
			HDShadowRequest hdshadowRequest = this.m_ShadowRequests[shadowIndex];
			switch (hdshadowRequest.shadowMapType)
			{
			case ShadowMapType.CascadedDirectional:
				this.m_CascadeAtlas.DisplayAtlas(atlasTextures.directionalShadowResult, cmd, debugMaterial, hdshadowRequest.dynamicAtlasViewport, screenX, screenY, screenSizeX, screenSizeY, minValue, maxValue, mpb);
				return;
			case ShadowMapType.PunctualAtlas:
				if (hdshadowRequest.isInCachedAtlas)
				{
					HDShadowManager.cachedShadowManager.punctualShadowAtlas.DisplayAtlas(atlasTextures.cachedPunctualShadowResult, cmd, debugMaterial, hdshadowRequest.cachedAtlasViewport, screenX, screenY, screenSizeX, screenSizeY, minValue, maxValue, mpb, 1f);
					return;
				}
				this.m_Atlas.DisplayAtlas(atlasTextures.punctualShadowResult, cmd, debugMaterial, hdshadowRequest.dynamicAtlasViewport, screenX, screenY, screenSizeX, screenSizeY, minValue, maxValue, mpb);
				return;
			case ShadowMapType.AreaLightAtlas:
				if (ShaderConfig.s_AreaLights == 1)
				{
					if (hdshadowRequest.isInCachedAtlas)
					{
						HDShadowManager.cachedShadowManager.areaShadowAtlas.DisplayAtlas(atlasTextures.cachedAreaShadowResult, cmd, debugMaterial, hdshadowRequest.cachedAtlasViewport, screenX, screenY, screenSizeX, screenSizeY, minValue, maxValue, mpb, 1f);
						return;
					}
					this.m_AreaLightShadowAtlas.DisplayAtlas(atlasTextures.areaShadowResult, cmd, debugMaterial, hdshadowRequest.dynamicAtlasViewport, screenX, screenY, screenSizeX, screenSizeY, minValue, maxValue, mpb);
				}
				return;
			default:
				return;
			}
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x0004FF7C File Offset: 0x0004E17C
		internal static ShadowResult ReadShadowResult(in ShadowResult shadowResult, RenderGraphBuilder builder)
		{
			ShadowResult result = default(ShadowResult);
			TextureHandle textureHandle = shadowResult.punctualShadowResult;
			if (textureHandle.IsValid())
			{
				result.punctualShadowResult = builder.ReadTexture(shadowResult.punctualShadowResult);
			}
			textureHandle = shadowResult.directionalShadowResult;
			if (textureHandle.IsValid())
			{
				result.directionalShadowResult = builder.ReadTexture(shadowResult.directionalShadowResult);
			}
			textureHandle = shadowResult.areaShadowResult;
			if (textureHandle.IsValid())
			{
				result.areaShadowResult = builder.ReadTexture(shadowResult.areaShadowResult);
			}
			textureHandle = shadowResult.cachedPunctualShadowResult;
			if (textureHandle.IsValid())
			{
				result.cachedPunctualShadowResult = builder.ReadTexture(shadowResult.cachedPunctualShadowResult);
			}
			textureHandle = shadowResult.cachedAreaShadowResult;
			if (textureHandle.IsValid())
			{
				result.cachedAreaShadowResult = builder.ReadTexture(shadowResult.cachedAreaShadowResult);
			}
			return result;
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x00050048 File Offset: 0x0004E248
		internal void RenderShadows(RenderGraph renderGraph, in ShaderVariablesGlobal globalCB, HDCamera hdCamera, CullingResults cullResults, ref ShadowResult result)
		{
			this.InvalidateAtlasOutputsIfNeeded();
			if (this.m_ShadowRequestCount != 0 && (hdCamera.frameSettings.IsEnabled(FrameSettingsField.OpaqueObjects) || hdCamera.frameSettings.IsEnabled(FrameSettingsField.TransparentObjects)))
			{
				result.cachedPunctualShadowResult = HDShadowManager.cachedShadowManager.punctualShadowAtlas.RenderShadows(renderGraph, cullResults, globalCB, hdCamera.frameSettings, "Cached Punctual Lights Shadows rendering");
				this.BlitCachedShadows(renderGraph, ShadowMapType.PunctualAtlas);
				result.punctualShadowResult = this.m_Atlas.RenderShadows(renderGraph, cullResults, globalCB, hdCamera.frameSettings, "Punctual Lights Shadows rendering");
				if (ShaderConfig.s_AreaLights == 1)
				{
					HDShadowManager.cachedShadowManager.areaShadowAtlas.RenderShadowMaps(renderGraph, cullResults, globalCB, hdCamera.frameSettings, "Cached Area Lights Shadows rendering");
					this.BlitCachedShadows(renderGraph, ShadowMapType.AreaLightAtlas);
					this.m_AreaLightShadowAtlas.RenderShadowMaps(renderGraph, cullResults, globalCB, hdCamera.frameSettings, "Area Light Shadows rendering");
					result.areaShadowResult = this.m_AreaLightShadowAtlas.BlurShadows(renderGraph);
					result.cachedAreaShadowResult = HDShadowManager.cachedShadowManager.areaShadowAtlas.BlurShadows(renderGraph);
				}
				if (HDShadowManager.cachedShadowManager.DirectionalHasCachedAtlas())
				{
					if (HDShadowManager.cachedShadowManager.directionalLightAtlas.HasShadowRequests())
					{
						HDShadowManager.cachedShadowManager.UpdateDirectionalCacheTexture(renderGraph);
						HDShadowManager.cachedShadowManager.directionalLightAtlas.RenderShadows(renderGraph, cullResults, globalCB, hdCamera.frameSettings, "Cached Directional Lights Shadows rendering");
					}
					this.BlitCachedShadows(renderGraph, ShadowMapType.CascadedDirectional);
				}
				result.directionalShadowResult = this.m_CascadeAtlas.RenderShadows(renderGraph, cullResults, globalCB, hdCamera.frameSettings, "Directional Light Shadows rendering");
			}
			this.BindShadowGlobalResources(renderGraph, result);
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x000501C8 File Offset: 0x0004E3C8
		internal void ReleaseSharedShadowAtlases(RenderGraph renderGraph)
		{
			if (HDShadowManager.cachedShadowManager.DirectionalHasCachedAtlas())
			{
				HDShadowManager.cachedShadowManager.directionalLightAtlas.CleanupRenderGraphOutput(renderGraph);
			}
			HDShadowManager.cachedShadowManager.punctualShadowAtlas.CleanupRenderGraphOutput(renderGraph);
			if (ShaderConfig.s_AreaLights == 1)
			{
				HDShadowManager.cachedShadowManager.areaShadowAtlas.CleanupRenderGraphOutput(renderGraph);
			}
			HDShadowManager.cachedShadowManager.DefragAtlas(HDLightType.Point);
			HDShadowManager.cachedShadowManager.DefragAtlas(HDLightType.Spot);
			if (ShaderConfig.s_AreaLights == 1)
			{
				HDShadowManager.cachedShadowManager.DefragAtlas(HDLightType.Area);
			}
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x00050244 File Offset: 0x0004E444
		private void InvalidateAtlasOutputsIfNeeded()
		{
			HDShadowManager.cachedShadowManager.punctualShadowAtlas.InvalidateOutputIfNeeded();
			this.m_Atlas.InvalidateOutputIfNeeded();
			this.m_CascadeAtlas.InvalidateOutputIfNeeded();
			if (HDShadowManager.cachedShadowManager.DirectionalHasCachedAtlas())
			{
				HDShadowManager.cachedShadowManager.directionalLightAtlas.InvalidateOutputIfNeeded();
			}
			if (ShaderConfig.s_AreaLights == 1)
			{
				HDShadowManager.cachedShadowManager.areaShadowAtlas.InvalidateOutputIfNeeded();
				this.m_AreaLightShadowAtlas.InvalidateOutputIfNeeded();
			}
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x000502B3 File Offset: 0x0004E4B3
		private static void BindAtlasTexture(RenderGraphContext ctx, TextureHandle texture, int shaderId)
		{
			if (texture.IsValid())
			{
				ctx.cmd.SetGlobalTexture(shaderId, texture);
				return;
			}
			ctx.cmd.SetGlobalTexture(shaderId, ctx.defaultResources.defaultShadowTexture);
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x000502F0 File Offset: 0x0004E4F0
		private void BindShadowGlobalResources(RenderGraph renderGraph, in ShadowResult shadowResult)
		{
			HDShadowManager.BindShadowGlobalResourcesPassData bindShadowGlobalResourcesPassData;
			using (RenderGraphBuilder builder = renderGraph.AddRenderPass<HDShadowManager.BindShadowGlobalResourcesPassData>("BindShadowGlobalResources", out bindShadowGlobalResourcesPassData))
			{
				bindShadowGlobalResourcesPassData.shadowResult = HDShadowManager.ReadShadowResult(shadowResult, builder);
				builder.AllowPassCulling(false);
				builder.SetRenderFunc<HDShadowManager.BindShadowGlobalResourcesPassData>(delegate(HDShadowManager.BindShadowGlobalResourcesPassData data, RenderGraphContext ctx)
				{
					HDShadowManager.BindAtlasTexture(ctx, data.shadowResult.punctualShadowResult, HDShaderIDs._ShadowmapAtlas);
					HDShadowManager.BindAtlasTexture(ctx, data.shadowResult.directionalShadowResult, HDShaderIDs._ShadowmapCascadeAtlas);
					HDShadowManager.BindAtlasTexture(ctx, data.shadowResult.areaShadowResult, HDShaderIDs._ShadowmapAreaAtlas);
					HDShadowManager.BindAtlasTexture(ctx, data.shadowResult.cachedPunctualShadowResult, HDShaderIDs._CachedShadowmapAtlas);
					HDShadowManager.BindAtlasTexture(ctx, data.shadowResult.cachedAreaShadowResult, HDShaderIDs._CachedAreaLightShadowmapAtlas);
				});
			}
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x00050368 File Offset: 0x0004E568
		internal static void BindDefaultShadowGlobalResources(RenderGraph renderGraph)
		{
			HDShadowManager.BindShadowGlobalResourcesPassData bindShadowGlobalResourcesPassData;
			using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<HDShadowManager.BindShadowGlobalResourcesPassData>("BindDefaultShadowGlobalResources", out bindShadowGlobalResourcesPassData))
			{
				renderGraphBuilder.AllowPassCulling(false);
				renderGraphBuilder.SetRenderFunc<HDShadowManager.BindShadowGlobalResourcesPassData>(delegate(HDShadowManager.BindShadowGlobalResourcesPassData data, RenderGraphContext ctx)
				{
					HDShadowManager.BindAtlasTexture(ctx, ctx.defaultResources.defaultShadowTexture, HDShaderIDs._ShadowmapAtlas);
					HDShadowManager.BindAtlasTexture(ctx, ctx.defaultResources.defaultShadowTexture, HDShaderIDs._ShadowmapCascadeAtlas);
					HDShadowManager.BindAtlasTexture(ctx, ctx.defaultResources.defaultShadowTexture, HDShaderIDs._ShadowmapAreaAtlas);
					HDShadowManager.BindAtlasTexture(ctx, ctx.defaultResources.defaultShadowTexture, HDShaderIDs._CachedShadowmapAtlas);
					HDShadowManager.BindAtlasTexture(ctx, ctx.defaultResources.defaultShadowTexture, HDShaderIDs._CachedAreaLightShadowmapAtlas);
				});
			}
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x000503D4 File Offset: 0x0004E5D4
		private void BlitCachedShadows(RenderGraph renderGraph)
		{
			this.m_Atlas.BlitCachedIntoAtlas(renderGraph, HDShadowManager.cachedShadowManager.punctualShadowAtlas.GetOutputTexture(renderGraph), new Vector2Int(HDShadowManager.cachedShadowManager.punctualShadowAtlas.width, HDShadowManager.cachedShadowManager.punctualShadowAtlas.height), this.m_BlitShadowMaterial, "Blit Punctual Mixed Cached Shadows", HDProfileId.BlitPunctualMixedCachedShadowMaps);
			if (HDShadowManager.cachedShadowManager.DirectionalHasCachedAtlas())
			{
				this.m_CascadeAtlas.BlitCachedIntoAtlas(renderGraph, HDShadowManager.cachedShadowManager.directionalLightAtlas.GetOutputTexture(renderGraph), new Vector2Int(HDShadowManager.cachedShadowManager.directionalLightAtlas.width, HDShadowManager.cachedShadowManager.directionalLightAtlas.height), this.m_BlitShadowMaterial, "Blit Directional Mixed Cached Shadows", HDProfileId.BlitDirectionalMixedCachedShadowMaps);
			}
			if (ShaderConfig.s_AreaLights == 1)
			{
				this.m_AreaLightShadowAtlas.BlitCachedIntoAtlas(renderGraph, HDShadowManager.cachedShadowManager.areaShadowAtlas.GetOutputTexture(renderGraph), new Vector2Int(HDShadowManager.cachedShadowManager.areaShadowAtlas.width, HDShadowManager.cachedShadowManager.areaShadowAtlas.height), this.m_BlitShadowMaterial, "Blit Area Mixed Cached Shadows", HDProfileId.BlitAreaMixedCachedShadowMaps);
			}
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x000504E4 File Offset: 0x0004E6E4
		private void BlitCachedShadows(RenderGraph renderGraph, ShadowMapType shadowAtlas)
		{
			if (shadowAtlas == ShadowMapType.PunctualAtlas)
			{
				this.m_Atlas.BlitCachedIntoAtlas(renderGraph, HDShadowManager.cachedShadowManager.punctualShadowAtlas.GetOutputTexture(renderGraph), new Vector2Int(HDShadowManager.cachedShadowManager.punctualShadowAtlas.width, HDShadowManager.cachedShadowManager.punctualShadowAtlas.height), this.m_BlitShadowMaterial, "Blit Punctual Mixed Cached Shadows", HDProfileId.BlitPunctualMixedCachedShadowMaps);
			}
			if (shadowAtlas == ShadowMapType.CascadedDirectional && HDShadowManager.cachedShadowManager.DirectionalHasCachedAtlas())
			{
				this.m_CascadeAtlas.BlitCachedIntoAtlas(renderGraph, HDShadowManager.cachedShadowManager.directionalLightAtlas.GetOutputTexture(renderGraph), new Vector2Int(HDShadowManager.cachedShadowManager.directionalLightAtlas.width, HDShadowManager.cachedShadowManager.directionalLightAtlas.height), this.m_BlitShadowMaterial, "Blit Directional Mixed Cached Shadows", HDProfileId.BlitDirectionalMixedCachedShadowMaps);
			}
			if (shadowAtlas == ShadowMapType.AreaLightAtlas && ShaderConfig.s_AreaLights == 1)
			{
				this.m_AreaLightShadowAtlas.BlitCachedIntoAtlas(renderGraph, HDShadowManager.cachedShadowManager.areaShadowAtlas.GetShadowMapDepthTexture(renderGraph), new Vector2Int(HDShadowManager.cachedShadowManager.areaShadowAtlas.width, HDShadowManager.cachedShadowManager.areaShadowAtlas.height), this.m_BlitShadowMaterial, "Blit Area Mixed Cached Shadows", HDProfileId.BlitAreaMixedCachedShadowMaps);
			}
		}

		// Token: 0x0400090A RID: 2314
		public const int k_DirectionalShadowCascadeCount = 4;

		// Token: 0x0400090B RID: 2315
		public const int k_MinShadowMapResolution = 16;

		// Token: 0x0400090C RID: 2316
		public const int k_MaxShadowMapResolution = 16384;

		// Token: 0x0400090D RID: 2317
		private List<HDShadowData> m_ShadowDatas = new List<HDShadowData>();

		// Token: 0x0400090E RID: 2318
		private HDShadowRequest[] m_ShadowRequests;

		// Token: 0x0400090F RID: 2319
		private HDShadowResolutionRequest[] m_ShadowResolutionRequests;

		// Token: 0x04000910 RID: 2320
		private HDDirectionalShadowData[] m_CachedDirectionalShadowData;

		// Token: 0x04000911 RID: 2321
		private HDDirectionalShadowData m_DirectionalShadowData;

		// Token: 0x04000912 RID: 2322
		private ComputeBuffer m_ShadowDataBuffer;

		// Token: 0x04000913 RID: 2323
		private ComputeBuffer m_DirectionalShadowDataBuffer;

		// Token: 0x04000914 RID: 2324
		private HDDynamicShadowAtlas m_CascadeAtlas;

		// Token: 0x04000915 RID: 2325
		private HDDynamicShadowAtlas m_Atlas;

		// Token: 0x04000916 RID: 2326
		private HDDynamicShadowAtlas m_AreaLightShadowAtlas;

		// Token: 0x04000917 RID: 2327
		private int m_MaxShadowRequests;

		// Token: 0x04000918 RID: 2328
		private int m_ShadowRequestCount;

		// Token: 0x04000919 RID: 2329
		private int m_CascadeCount;

		// Token: 0x0400091A RID: 2330
		private int m_ShadowResolutionRequestCounter;

		// Token: 0x0400091B RID: 2331
		private Material m_ClearShadowMaterial;

		// Token: 0x0400091C RID: 2332
		private Material m_BlitShadowMaterial;

		// Token: 0x0400091D RID: 2333
		private ConstantBuffer<ShaderVariablesGlobal> m_GlobalShaderVariables;

		// Token: 0x0200035C RID: 860
		private class BindShadowGlobalResourcesPassData
		{
			// Token: 0x04002392 RID: 9106
			public ShadowResult shadowResult;
		}
	}
}
