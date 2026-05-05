using System;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000078 RID: 120
	internal class HDGpuLightsBuilder
	{
		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060006B1 RID: 1713 RVA: 0x000449D9 File Offset: 0x00042BD9
		public NativeArray<LightData> lights
		{
			get
			{
				return this.m_Lights;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060006B2 RID: 1714 RVA: 0x000449E1 File Offset: 0x00042BE1
		public int lightsCount
		{
			get
			{
				return this.m_LightCount;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060006B3 RID: 1715 RVA: 0x000449E9 File Offset: 0x00042BE9
		public NativeArray<DirectionalLightData> directionalLights
		{
			get
			{
				return this.m_DirectionalLights;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060006B4 RID: 1716 RVA: 0x000449F1 File Offset: 0x00042BF1
		public int directionalLightCount
		{
			get
			{
				if (!this.m_LightTypeCounters.IsCreated)
				{
					return 0;
				}
				return this.m_LightTypeCounters[0];
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060006B5 RID: 1717 RVA: 0x00044A0E File Offset: 0x00042C0E
		public int punctualLightCount
		{
			get
			{
				if (!this.m_LightTypeCounters.IsCreated)
				{
					return 0;
				}
				return this.m_LightTypeCounters[1];
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060006B6 RID: 1718 RVA: 0x00044A2B File Offset: 0x00042C2B
		public int areaLightCount
		{
			get
			{
				if (!this.m_LightTypeCounters.IsCreated)
				{
					return 0;
				}
				return this.m_LightTypeCounters[2];
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060006B7 RID: 1719 RVA: 0x00044A48 File Offset: 0x00042C48
		public NativeArray<HDGpuLightsBuilder.LightsPerView> lightsPerView
		{
			get
			{
				return this.m_LightsPerView;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060006B8 RID: 1720 RVA: 0x00044A50 File Offset: 0x00042C50
		public NativeArray<SFiniteLightBound> lightBounds
		{
			get
			{
				return this.m_LightBounds;
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060006B9 RID: 1721 RVA: 0x00044A58 File Offset: 0x00042C58
		public NativeArray<LightVolumeData> lightVolumes
		{
			get
			{
				return this.m_LightVolumes;
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060006BA RID: 1722 RVA: 0x00044A60 File Offset: 0x00042C60
		public int lightsPerViewCount
		{
			get
			{
				return this.m_LightsPerViewCount;
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060006BB RID: 1723 RVA: 0x00044A68 File Offset: 0x00042C68
		public int lightBoundsCount
		{
			get
			{
				return this.m_LightBoundsCount;
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060006BC RID: 1724 RVA: 0x00044A70 File Offset: 0x00042C70
		public int boundsEyeDataOffset
		{
			get
			{
				return this.m_BoundsEyeDataOffset;
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060006BD RID: 1725 RVA: 0x00044A78 File Offset: 0x00042C78
		public int allLightBoundsCount
		{
			get
			{
				return this.m_BoundsEyeDataOffset * this.lightsPerViewCount;
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060006BE RID: 1726 RVA: 0x00044A87 File Offset: 0x00042C87
		public int currentShadowSortedSunLightIndex
		{
			get
			{
				return this.m_CurrentShadowSortedSunLightIndex;
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060006BF RID: 1727 RVA: 0x00044A8F File Offset: 0x00042C8F
		public HDProcessedVisibleLightsBuilder.ShadowMapFlags currentSunShadowMapFlags
		{
			get
			{
				return this.m_CurrentSunShadowMapFlags;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060006C0 RID: 1728 RVA: 0x00044A97 File Offset: 0x00042C97
		public DirectionalLightData currentSunLightDirectionalLightData
		{
			get
			{
				return this.m_CurrentSunLightDirectionalLightData;
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060006C1 RID: 1729 RVA: 0x00044A9F File Offset: 0x00042C9F
		public int contactShadowIndex
		{
			get
			{
				return this.m_ContactShadowIndex;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060006C2 RID: 1730 RVA: 0x00044AA7 File Offset: 0x00042CA7
		public int screenSpaceShadowIndex
		{
			get
			{
				return this.m_ScreenSpaceShadowIndex;
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060006C3 RID: 1731 RVA: 0x00044AAF File Offset: 0x00042CAF
		public int screenSpaceShadowChannelSlot
		{
			get
			{
				return this.m_ScreenSpaceShadowChannelSlot;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060006C4 RID: 1732 RVA: 0x00044AB7 File Offset: 0x00042CB7
		public int debugSelectedLightShadowIndex
		{
			get
			{
				return this.m_DebugSelectedLightShadowIndex;
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060006C5 RID: 1733 RVA: 0x00044ABF File Offset: 0x00042CBF
		public int debugSelectedLightShadowCount
		{
			get
			{
				return this.m_DebugSelectedLightShadowCount;
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060006C6 RID: 1734 RVA: 0x00044AC7 File Offset: 0x00042CC7
		public HDRenderPipeline.ScreenSpaceShadowData[] currentScreenSpaceShadowData
		{
			get
			{
				return this.m_CurrentScreenSpaceShadowData;
			}
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x00044ACF File Offset: 0x00042CCF
		public static uint PackLightSortKey(LightCategory lightCategory, GPULightType gpuLightType, LightVolumeType lightVolumeType, int lightIndex)
		{
			return (uint)(((gpuLightType == GPULightType.Directional) ? 0 : 1) << 31 | (int)((int)lightCategory << 27) | (int)((int)gpuLightType << 22) | (int)((int)lightVolumeType << 17) | lightIndex);
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x00044AEC File Offset: 0x00042CEC
		public static void UnpackLightSortKey(uint sortKey, out LightCategory lightCategory, out GPULightType gpuLightType, out LightVolumeType lightVolumeType, out int lightIndex)
		{
			lightCategory = (LightCategory)(sortKey >> 27 & 15U);
			gpuLightType = (GPULightType)(sortKey >> 22 & 31U);
			lightVolumeType = (LightVolumeType)(sortKey >> 17 & 31U);
			lightIndex = (int)(sortKey & 65535U);
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x00044B14 File Offset: 0x00042D14
		public void Initialize(HDRenderPipelineAsset asset, HDShadowManager shadowManager, HDRenderPipeline.LightLoopTextureCaches textureCaches)
		{
			this.m_Asset = asset;
			this.m_TextureCaches = textureCaches;
			this.m_ShadowManager = shadowManager;
			int num = Math.Max(this.m_Asset.currentPlatformRenderPipelineSettings.hdShadowInitParams.maxScreenSpaceShadowSlots, 1);
			this.m_CurrentScreenSpaceShadowData = new HDRenderPipeline.ScreenSpaceShadowData[num];
			this.AllocateLightData(0, 0);
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x00044B68 File Offset: 0x00042D68
		public void AddLightBounds(int viewId, in SFiniteLightBound lightBound, in LightVolumeData volumeData)
		{
			HDGpuLightsBuilder.LightsPerView lightsPerView = this.m_LightsPerView[viewId];
			this.m_LightBounds[lightsPerView.boundsOffset + lightsPerView.boundsCount] = lightBound;
			this.m_LightVolumes[lightsPerView.boundsOffset + lightsPerView.boundsCount] = volumeData;
			lightsPerView.boundsCount++;
			this.m_LightsPerView[viewId] = lightsPerView;
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x00044BD8 File Offset: 0x00042DD8
		public void Cleanup()
		{
			if (this.m_Lights.IsCreated)
			{
				this.m_Lights.Dispose();
			}
			if (this.m_DirectionalLights.IsCreated)
			{
				this.m_DirectionalLights.Dispose();
			}
			if (this.m_LightsPerView.IsCreated)
			{
				this.m_LightsPerView.Dispose();
			}
			if (this.m_LightBounds.IsCreated)
			{
				this.m_LightBounds.Dispose();
			}
			if (this.m_LightVolumes.IsCreated)
			{
				this.m_LightVolumes.Dispose();
			}
			if (this.m_LightTypeCounters.IsCreated)
			{
				this.m_LightTypeCounters.Dispose();
			}
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x00044C78 File Offset: 0x00042E78
		private void AllocateLightData(int lightCount, int directionalLightCount)
		{
			int num = Math.Max(1, lightCount);
			if (num > this.m_LightCapacity)
			{
				this.m_LightCapacity = Math.Max(Math.Max(this.m_LightCapacity * 2, num), 100);
				ref this.m_Lights.ResizeArray(this.m_LightCapacity);
			}
			this.m_LightCount = lightCount;
			int num2 = Math.Max(1, directionalLightCount);
			if (num2 > this.m_DirectionalLightCapacity)
			{
				this.m_DirectionalLightCapacity = Math.Max(Math.Max(this.m_DirectionalLightCapacity * 2, num2), 100);
				ref this.m_DirectionalLights.ResizeArray(this.m_DirectionalLightCapacity);
			}
			this.m_DirectionalLightCount = directionalLightCount;
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x00044D10 File Offset: 0x00042F10
		public void StartCreateGpuLightDataJob(HDCamera hdCamera, in CullingResults cullingResult, HDShadowSettings hdShadowSettings, HDProcessedVisibleLightsBuilder visibleLights, HDLightRenderDatabase lightEntities)
		{
			VisualEnvironment component = hdCamera.volumeStack.GetComponent<VisualEnvironment>();
			PhysicallyBasedSky component2 = hdCamera.volumeStack.GetComponent<PhysicallyBasedSky>();
			HDShadowSettings component3 = hdCamera.volumeStack.GetComponent<HDShadowSettings>();
			bool isPbrSkyActive = component.skyType.value == 4;
			HDGpuLightsBuilder.CreateGpuLightDataJob createGpuLightDataJob = default(HDGpuLightsBuilder.CreateGpuLightDataJob);
			createGpuLightDataJob.totalLightCounts = lightEntities.lightCount;
			createGpuLightDataJob.outputLightCounts = this.m_LightCount;
			createGpuLightDataJob.outputDirectionalLightCounts = this.m_DirectionalLightCount;
			createGpuLightDataJob.outputLightBoundsCount = this.m_LightBoundsCount;
			createGpuLightDataJob.globalConfig = HDGpuLightsBuilder.CreateGpuLightDataJobGlobalConfig.Create(hdCamera, hdShadowSettings);
			createGpuLightDataJob.cameraPos = hdCamera.mainViewConstants.worldSpaceCameraPos;
			createGpuLightDataJob.directionalSortedLightCounts = visibleLights.sortedDirectionalLightCounts;
			createGpuLightDataJob.isPbrSkyActive = isPbrSkyActive;
			createGpuLightDataJob.precomputedAtmosphericAttenuation = ShaderConfig.s_PrecomputedAtmosphericAttenuation;
			createGpuLightDataJob.defaultDataIndex = lightEntities.GetEntityDataIndex(lightEntities.GetDefaultLightEntity());
			createGpuLightDataJob.viewCounts = hdCamera.viewCount;
			createGpuLightDataJob.useCameraRelativePosition = (ShaderConfig.s_CameraRelativeRendering != 0);
			createGpuLightDataJob.planetCenterPosition = component2.GetPlanetCenterPosition(hdCamera.camera.transform.position);
			createGpuLightDataJob.planetaryRadius = component2.GetPlanetaryRadius();
			createGpuLightDataJob.airScaleHeight = component2.GetAirScaleHeight();
			createGpuLightDataJob.aerosolScaleHeight = component2.GetAerosolScaleHeight();
			createGpuLightDataJob.airExtinctionCoefficient = component2.GetAirExtinctionCoefficient();
			createGpuLightDataJob.aerosolExtinctionCoefficient = component2.GetAerosolExtinctionCoefficient();
			createGpuLightDataJob.maxShadowDistance = component3.maxShadowDistance.value;
			createGpuLightDataJob.lightRenderDataArray = lightEntities.lightData;
			createGpuLightDataJob.sortKeys = visibleLights.sortKeys;
			createGpuLightDataJob.processedEntities = visibleLights.processedEntities;
			CullingResults cullingResults = cullingResult;
			createGpuLightDataJob.visibleLights = cullingResults.visibleLights;
			createGpuLightDataJob.visibleLightBakingOutput = visibleLights.visibleLightBakingOutput;
			createGpuLightDataJob.visibleLightShadowCasterMode = visibleLights.visibleLightShadowCasterMode;
			createGpuLightDataJob.gpuLightCounters = this.m_LightTypeCounters;
			createGpuLightDataJob.lights = this.m_Lights;
			createGpuLightDataJob.directionalLights = this.m_DirectionalLights;
			createGpuLightDataJob.lightsPerView = this.m_LightsPerView;
			createGpuLightDataJob.lightBounds = this.m_LightBounds;
			createGpuLightDataJob.lightVolumes = this.m_LightVolumes;
			HDGpuLightsBuilder.CreateGpuLightDataJob jobData = createGpuLightDataJob;
			this.m_CreateGpuLightDataJobHandle = jobData.Schedule(visibleLights.sortedLightCounts, 32, default(JobHandle));
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x00044F3A File Offset: 0x0004313A
		public void CompleteGpuLightDataJob()
		{
			this.m_CreateGpuLightDataJobHandle.Complete();
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x00044F48 File Offset: 0x00043148
		public void NewFrame(HDCamera hdCamera, int maxLightCount)
		{
			int viewCount = hdCamera.viewCount;
			if (viewCount > this.m_LighsPerViewCapacity)
			{
				this.m_LighsPerViewCapacity = viewCount;
				ref this.m_LightsPerView.ResizeArray(this.m_LighsPerViewCapacity);
			}
			this.m_LightsPerViewCount = viewCount;
			int num = maxLightCount * viewCount;
			int num2 = Math.Max(num, 1);
			if (num2 > this.m_LightBoundsCapacity)
			{
				this.m_LightBoundsCapacity = Math.Max(Math.Max(this.m_LightBoundsCapacity * 2, num2), 100);
				ref this.m_LightBounds.ResizeArray(this.m_LightBoundsCapacity);
				ref this.m_LightVolumes.ResizeArray(this.m_LightBoundsCapacity);
			}
			this.m_LightBoundsCount = num;
			this.m_BoundsEyeDataOffset = maxLightCount;
			for (int i = 0; i < viewCount; i++)
			{
				this.m_LightsPerView[i] = new HDGpuLightsBuilder.LightsPerView
				{
					worldToView = HDRenderPipeline.GetWorldToViewMatrix(hdCamera, i),
					boundsOffset = i * this.m_BoundsEyeDataOffset,
					boundsCount = 0
				};
			}
			if (!this.m_LightTypeCounters.IsCreated)
			{
				ref this.m_LightTypeCounters.ResizeArray(Enum.GetValues(typeof(HDGpuLightsBuilder.GPULightTypeCountSlots)).Length);
			}
			this.m_LightCount = 0;
			this.m_ContactShadowIndex = 0;
			this.m_ScreenSpaceShadowIndex = 0;
			this.m_ScreenSpaceShadowChannelSlot = 0;
			this.m_ScreenSpaceShadowsUnion.Clear();
			this.m_CurrentShadowSortedSunLightIndex = -1;
			this.m_CurrentSunShadowMapFlags = HDProcessedVisibleLightsBuilder.ShadowMapFlags.None;
			this.m_DebugSelectedLightShadowIndex = -1;
			this.m_DebugSelectedLightShadowCount = 0;
			for (int j = 0; j < this.m_Asset.currentPlatformRenderPipelineSettings.hdShadowInitParams.maxScreenSpaceShadowSlots; j++)
			{
				this.m_CurrentScreenSpaceShadowData[j].additionalLightData = null;
				this.m_CurrentScreenSpaceShadowData[j].lightDataIndex = -1;
				this.m_CurrentScreenSpaceShadowData[j].valid = false;
			}
			for (int k = 0; k < this.m_LightTypeCounters.Length; k++)
			{
				this.m_LightTypeCounters[k] = 0;
			}
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x00045120 File Offset: 0x00043320
		public void Build(CommandBuffer cmd, HDCamera hdCamera, in CullingResults cullingResult, HDProcessedVisibleLightsBuilder visibleLights, HDLightRenderDatabase lightEntities, in HDShadowInitParameters shadowInitParams, DebugDisplaySettings debugDisplaySettings)
		{
			this.m_ShadowManager.LayoutShadowMaps(debugDisplaySettings.data.lightingDebugSettings);
			this.m_TextureCaches.lightCookieManager.LayoutIfNeeded();
			int sortedLightCounts = visibleLights.sortedLightCounts;
			int sortedNonDirectionalLightCounts = visibleLights.sortedNonDirectionalLightCounts;
			int sortedDirectionalLightCounts = visibleLights.sortedDirectionalLightCounts;
			this.AllocateLightData(sortedNonDirectionalLightCounts, sortedDirectionalLightCounts);
			if (sortedLightCounts > 0)
			{
				for (int i = 0; i < hdCamera.viewCount; i++)
				{
					HDGpuLightsBuilder.LightsPerView value = this.m_LightsPerView[i];
					value.boundsCount += sortedNonDirectionalLightCounts;
					this.m_LightsPerView[i] = value;
				}
				HDShadowSettings component = hdCamera.volumeStack.GetComponent<HDShadowSettings>();
				this.StartCreateGpuLightDataJob(hdCamera, cullingResult, component, visibleLights, lightEntities);
				this.CompleteGpuLightDataJob();
				this.CalculateAllLightDataTextureInfo(cmd, hdCamera, cullingResult, visibleLights, lightEntities, component, shadowInitParams, debugDisplaySettings);
			}
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x000451E0 File Offset: 0x000433E0
		public void ProcessLightDataShadowIndex(CommandBuffer cmd, in HDShadowInitParameters shadowInitParams, HDLightType lightType, Light lightComponent, HDAdditionalLightData additionalLightData, int shadowIndex, ref LightData lightData)
		{
			if (lightData.lightType == GPULightType.ProjectorBox && shadowIndex >= 0)
			{
				float num = (float)additionalLightData.shadowResolution.Value(shadowInitParams.shadowResolutionPunctual);
				num = Mathf.Clamp(num, 128f, 2048f);
				float num2 = Mathf.Lerp(0.05f, 0.01f, Mathf.Max(num / 2048f, 0f));
				lightData.boxLightSafeExtent = 1f - num2;
			}
			if (lightComponent != null && ((lightType == HDLightType.Spot && (lightComponent.cookie != null || additionalLightData.IESPoint != null)) || (lightType == HDLightType.Area && lightData.lightType == GPULightType.Rectangle && (lightComponent.cookie != null || additionalLightData.IESSpot != null)) || (lightType == HDLightType.Point && (lightComponent.cookie != null || additionalLightData.IESPoint != null))))
			{
				switch (lightType)
				{
				case HDLightType.Spot:
				{
					Texture cookie = lightComponent.cookie;
					lightData.cookieMode = ((cookie != null && cookie.wrapMode == TextureWrapMode.Repeat) ? CookieMode.Repeat : CookieMode.Clamp);
					if (additionalLightData.IESSpot != null && lightComponent.cookie != null && additionalLightData.IESSpot != lightComponent.cookie)
					{
						lightData.cookieScaleOffset = this.m_TextureCaches.lightCookieManager.Fetch2DCookie(cmd, lightComponent.cookie, additionalLightData.IESSpot);
					}
					else if (lightComponent.cookie != null)
					{
						lightData.cookieScaleOffset = this.m_TextureCaches.lightCookieManager.Fetch2DCookie(cmd, lightComponent.cookie);
					}
					else if (additionalLightData.IESSpot != null)
					{
						lightData.cookieScaleOffset = this.m_TextureCaches.lightCookieManager.Fetch2DCookie(cmd, additionalLightData.IESSpot);
					}
					else
					{
						lightData.cookieScaleOffset = this.m_TextureCaches.lightCookieManager.Fetch2DCookie(cmd, Texture2D.whiteTexture);
					}
					break;
				}
				case HDLightType.Point:
					lightData.cookieMode = CookieMode.Repeat;
					if (additionalLightData.IESPoint != null && lightComponent.cookie != null && additionalLightData.IESPoint != lightComponent.cookie)
					{
						lightData.cookieScaleOffset = this.m_TextureCaches.lightCookieManager.FetchCubeCookie(cmd, lightComponent.cookie, additionalLightData.IESPoint);
					}
					else if (lightComponent.cookie != null)
					{
						lightData.cookieScaleOffset = this.m_TextureCaches.lightCookieManager.FetchCubeCookie(cmd, lightComponent.cookie);
					}
					else if (additionalLightData.IESPoint != null)
					{
						lightData.cookieScaleOffset = this.m_TextureCaches.lightCookieManager.FetchCubeCookie(cmd, additionalLightData.IESPoint);
					}
					break;
				case HDLightType.Area:
					lightData.cookieMode = CookieMode.Clamp;
					if (additionalLightData.areaLightCookie != null && additionalLightData.IESSpot != null && additionalLightData.areaLightCookie != additionalLightData.IESSpot)
					{
						lightData.cookieScaleOffset = this.m_TextureCaches.lightCookieManager.FetchAreaCookie(cmd, additionalLightData.areaLightCookie, additionalLightData.IESSpot);
					}
					else if (additionalLightData.IESSpot != null)
					{
						lightData.cookieScaleOffset = this.m_TextureCaches.lightCookieManager.FetchAreaCookie(cmd, additionalLightData.IESSpot);
					}
					else if (additionalLightData.areaLightCookie != null)
					{
						lightData.cookieScaleOffset = this.m_TextureCaches.lightCookieManager.FetchAreaCookie(cmd, additionalLightData.areaLightCookie);
					}
					break;
				}
			}
			else if (lightType == HDLightType.Spot && additionalLightData.spotLightShape != SpotLightShape.Cone)
			{
				lightData.cookieMode = CookieMode.Clamp;
				lightData.cookieScaleOffset = this.m_TextureCaches.lightCookieManager.Fetch2DCookie(cmd, Texture2D.whiteTexture);
			}
			else if (lightData.lightType == GPULightType.Rectangle && (additionalLightData.areaLightCookie != null || additionalLightData.IESPoint != null))
			{
				lightData.cookieMode = CookieMode.Clamp;
				if (additionalLightData.areaLightCookie != null && additionalLightData.IESSpot != null && additionalLightData.areaLightCookie != additionalLightData.IESSpot)
				{
					lightData.cookieScaleOffset = this.m_TextureCaches.lightCookieManager.FetchAreaCookie(cmd, additionalLightData.areaLightCookie, additionalLightData.IESSpot);
				}
				else if (additionalLightData.IESSpot != null)
				{
					lightData.cookieScaleOffset = this.m_TextureCaches.lightCookieManager.FetchAreaCookie(cmd, additionalLightData.IESSpot);
				}
				else if (additionalLightData.areaLightCookie != null)
				{
					lightData.cookieScaleOffset = this.m_TextureCaches.lightCookieManager.FetchAreaCookie(cmd, additionalLightData.areaLightCookie);
				}
			}
			lightData.shadowIndex = shadowIndex;
			additionalLightData.shadowIndex = shadowIndex;
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x000456CC File Offset: 0x000438CC
		private void GetContactShadowMask(HDAdditionalLightData hdAdditionalLightData, BoolScalableSetting contactShadowEnabled, HDCamera hdCamera, ref int contactShadowMask, ref float rayTracingShadowFlag)
		{
			contactShadowMask = 0;
			rayTracingShadowFlag = 0f;
			if (!hdAdditionalLightData.useContactShadow.Value(contactShadowEnabled) || this.m_ContactShadowIndex >= LightDefinitions.s_ContactShadowMaskMask)
			{
				return;
			}
			contactShadowMask = 1 << this.m_ContactShadowIndex;
			this.m_ContactShadowIndex++;
			if (hdCamera.frameSettings.IsEnabled(FrameSettingsField.RayTracing) && hdAdditionalLightData.rayTraceContactShadow)
			{
				rayTracingShadowFlag = 1f;
			}
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x0004573F File Offset: 0x0004393F
		private bool EnoughScreenSpaceShadowSlots(GPULightType gpuLightType, int screenSpaceChannelSlot)
		{
			if (gpuLightType == GPULightType.Rectangle)
			{
				return screenSpaceChannelSlot + 1 < this.m_Asset.currentPlatformRenderPipelineSettings.hdShadowInitParams.maxScreenSpaceShadowSlots;
			}
			return screenSpaceChannelSlot < this.m_Asset.currentPlatformRenderPipelineSettings.hdShadowInitParams.maxScreenSpaceShadowSlots;
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x00045778 File Offset: 0x00043978
		private void CalculateDirectionalLightDataTextureInfo(ref DirectionalLightData lightData, CommandBuffer cmd, in VisibleLight light, in Light lightComponent, in HDAdditionalLightData additionalLightData, HDCamera hdCamera, HDProcessedVisibleLightsBuilder.ShadowMapFlags shadowFlags, int lightDataIndex, int shadowIndex)
		{
			if (shadowIndex != -1)
			{
				if ((shadowFlags & HDProcessedVisibleLightsBuilder.ShadowMapFlags.WillRenderScreenSpaceShadow) != HDProcessedVisibleLightsBuilder.ShadowMapFlags.None)
				{
					lightData.screenSpaceShadowIndex = this.m_ScreenSpaceShadowChannelSlot;
					bool flag = (shadowFlags & HDProcessedVisibleLightsBuilder.ShadowMapFlags.WillRenderRayTracedShadow) > HDProcessedVisibleLightsBuilder.ShadowMapFlags.None;
					if (additionalLightData.colorShadow && flag)
					{
						this.m_ScreenSpaceShadowChannelSlot += 3;
						lightData.screenSpaceShadowIndex |= (int)LightDefinitions.s_ScreenSpaceColorShadowFlag;
					}
					else
					{
						this.m_ScreenSpaceShadowChannelSlot++;
					}
					if (flag)
					{
						lightData.screenSpaceShadowIndex |= (int)LightDefinitions.s_RayTracedScreenSpaceShadowFlag;
					}
					this.m_ScreenSpaceShadowIndex++;
					this.m_ScreenSpaceShadowsUnion.Add(additionalLightData);
				}
				this.m_CurrentSunLightDirectionalLightData = lightData;
				this.m_CurrentShadowSortedSunLightIndex = lightDataIndex;
				this.m_CurrentSunShadowMapFlags = shadowFlags;
			}
			CookieParameters cookieParameters = default(CookieParameters);
			Light light2 = lightComponent;
			cookieParameters.texture = ((light2 != null) ? light2.cookie : null);
			cookieParameters.size = new Vector2(additionalLightData.shapeWidth, additionalLightData.shapeHeight);
			cookieParameters.position = light.GetPosition();
			CookieParameters cookieParameters2 = cookieParameters;
			if (lightComponent == HDRenderPipeline.currentPipeline.GetMainLight())
			{
				CloudSettings cloudSettings;
				CloudRenderer cloudRenderer;
				if (HDRenderPipeline.currentPipeline.HasVolumetricCloudsShadows_IgnoreSun(hdCamera))
				{
					cookieParameters2 = HDRenderPipeline.currentPipeline.RenderVolumetricCloudsShadows(cmd, hdCamera);
					lightData.positionRWS = cookieParameters2.position;
					if (ShaderConfig.s_CameraRelativeRendering != 0)
					{
						lightData.positionRWS -= hdCamera.mainViewConstants.worldSpaceCameraPos;
					}
				}
				else if (HDRenderPipeline.currentPipeline.skyManager.TryGetCloudSettings(hdCamera, out cloudSettings, out cloudRenderer) && cloudRenderer.GetSunLightCookieParameters(cloudSettings, ref cookieParameters2))
				{
					BuiltinSunCookieParameters builtinParams = new BuiltinSunCookieParameters
					{
						cloudSettings = cloudSettings,
						sunLight = lightComponent,
						hdCamera = hdCamera,
						commandBuffer = cmd
					};
					cloudRenderer.RenderSunLightCookie(builtinParams);
				}
			}
			if (cookieParameters2.texture)
			{
				lightData.cookieMode = ((cookieParameters2.texture.wrapMode == TextureWrapMode.Repeat) ? CookieMode.Repeat : CookieMode.Clamp);
				lightData.cookieScaleOffset = this.m_TextureCaches.lightCookieManager.Fetch2DCookie(cmd, cookieParameters2.texture);
			}
			else
			{
				lightData.cookieMode = CookieMode.None;
			}
			lightData.right = light.GetRight() * 2f / Mathf.Max(cookieParameters2.size.x, 0.001f);
			lightData.up = light.GetUp() * 2f / Mathf.Max(cookieParameters2.size.y, 0.001f);
			if (additionalLightData.surfaceTexture == null)
			{
				lightData.surfaceTextureScaleOffset = Vector4.zero;
			}
			else
			{
				lightData.surfaceTextureScaleOffset = this.m_TextureCaches.lightCookieManager.Fetch2DCookie(cmd, additionalLightData.surfaceTexture);
			}
			this.GetContactShadowMask(additionalLightData, HDAdditionalLightData.ScalableSettings.UseContactShadow(this.m_Asset), hdCamera, ref lightData.contactShadowMask, ref lightData.isRayTracedContactShadow);
			lightData.shadowIndex = shadowIndex;
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x00045A58 File Offset: 0x00043C58
		private void CalculateLightDataTextureInfo(ref LightData lightData, CommandBuffer cmd, in Light lightComponent, HDAdditionalLightData additionalLightData, in HDShadowInitParameters shadowInitParams, in HDCamera hdCamera, BoolScalableSetting contactShadowScalableSetting, HDLightType lightType, HDProcessedVisibleLightsBuilder.ShadowMapFlags shadowFlags, bool rayTracingEnabled, int lightDataIndex, int shadowIndex)
		{
			this.ProcessLightDataShadowIndex(cmd, shadowInitParams, lightType, lightComponent, additionalLightData, shadowIndex, ref lightData);
			this.GetContactShadowMask(additionalLightData, contactShadowScalableSetting, hdCamera, ref lightData.contactShadowMask, ref lightData.isRayTracedContactShadow);
			if (rayTracingEnabled && this.EnoughScreenSpaceShadowSlots(lightData.lightType, this.m_ScreenSpaceShadowChannelSlot) && (shadowFlags & HDProcessedVisibleLightsBuilder.ShadowMapFlags.WillRenderScreenSpaceShadow) != HDProcessedVisibleLightsBuilder.ShadowMapFlags.None)
			{
				if (lightData.lightType == GPULightType.Rectangle && this.m_ScreenSpaceShadowChannelSlot % 4 == 3)
				{
					this.m_ScreenSpaceShadowChannelSlot++;
				}
				lightData.screenSpaceShadowIndex = this.m_ScreenSpaceShadowChannelSlot;
				this.m_CurrentScreenSpaceShadowData[this.m_ScreenSpaceShadowIndex].additionalLightData = additionalLightData;
				this.m_CurrentScreenSpaceShadowData[this.m_ScreenSpaceShadowIndex].lightDataIndex = lightDataIndex;
				this.m_CurrentScreenSpaceShadowData[this.m_ScreenSpaceShadowIndex].valid = true;
				this.m_ScreenSpaceShadowsUnion.Add(additionalLightData);
				this.m_ScreenSpaceShadowIndex++;
				if (lightData.lightType == GPULightType.Rectangle)
				{
					this.m_ScreenSpaceShadowChannelSlot += 2;
					return;
				}
				this.m_ScreenSpaceShadowChannelSlot++;
			}
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x00045B70 File Offset: 0x00043D70
		private unsafe void CalculateAllLightDataTextureInfo(CommandBuffer cmd, HDCamera hdCamera, in CullingResults cullResults, HDProcessedVisibleLightsBuilder visibleLights, HDLightRenderDatabase lightEntities, HDShadowSettings hdShadowSettings, in HDShadowInitParameters shadowInitParams, DebugDisplaySettings debugDisplaySettings)
		{
			BoolScalableSetting contactShadowScalableSetting = HDAdditionalLightData.ScalableSettings.UseContactShadow(this.m_Asset);
			bool rayTracingEnabled = hdCamera.frameSettings.IsEnabled(FrameSettingsField.RayTracing);
			HDProcessedVisibleLight* unsafePtr = (HDProcessedVisibleLight*)visibleLights.processedEntities.GetUnsafePtr<HDProcessedVisibleLight>();
			LightData* unsafePtr2 = (LightData*)this.m_Lights.GetUnsafePtr<LightData>();
			DirectionalLightData* unsafePtr3 = (DirectionalLightData*)this.m_DirectionalLights.GetUnsafePtr<DirectionalLightData>();
			CullingResults cullingResults = cullResults;
			VisibleLight* unsafePtr4 = (VisibleLight*)cullingResults.visibleLights.GetUnsafePtr<VisibleLight>();
			HDShadowFilteringQuality shadowFilteringQuality = this.m_Asset.currentPlatformRenderPipelineSettings.hdShadowInitParams.shadowFilteringQuality;
			HDAreaShadowFilteringQuality areaShadowFilteringQuality = this.m_Asset.currentPlatformRenderPipelineSettings.hdShadowInitParams.areaShadowFilteringQuality;
			int sortedDirectionalLightCounts = visibleLights.sortedDirectionalLightCounts;
			int sortedLightCounts = visibleLights.sortedLightCounts;
			for (int i = 0; i < sortedLightCounts; i++)
			{
				uint num = visibleLights.sortKeys[i];
				uint num2 = num >> 27 & 31U;
				GPULightType gpulightType = (GPULightType)(num >> 22 & 31U);
				uint num3 = num >> 17 & 31U;
				int num4 = (int)(num & 65535U);
				int num5 = visibleLights.visibleLightEntityDataIndices[num4];
				if (num5 != HDLightRenderDatabase.InvalidDataIndex)
				{
					HDAdditionalLightData hdadditionalLightData = *lightEntities.hdAdditionalLightData[num5];
					if (!(hdadditionalLightData == null))
					{
						ref HDProcessedVisibleLight ptr = ref UnsafeUtility.AsRef<HDProcessedVisibleLight>((void*)(unsafePtr + num4));
						HDLightType lightType = ptr.lightType;
						Light legacyLight = hdadditionalLightData.legacyLight;
						int shadowIndex = -1;
						if (legacyLight != null && (ptr.shadowMapFlags & HDProcessedVisibleLightsBuilder.ShadowMapFlags.WillRenderShadowMap) != HDProcessedVisibleLightsBuilder.ShadowMapFlags.None)
						{
							ref VisibleLight ptr2 = ref UnsafeUtility.AsRef<VisibleLight>((void*)(unsafePtr4 + num4));
							int num6;
							shadowIndex = hdadditionalLightData.UpdateShadowRequest(hdCamera, this.m_ShadowManager, hdShadowSettings, ptr2, cullResults, num4, debugDisplaySettings.data.lightingDebugSettings, shadowFilteringQuality, areaShadowFilteringQuality, out num6);
						}
						if (gpulightType == GPULightType.Directional)
						{
							ref VisibleLight light = ref UnsafeUtility.AsRef<VisibleLight>((void*)(unsafePtr4 + num4));
							int num7 = i;
							ref DirectionalLightData lightData = ref UnsafeUtility.AsRef<DirectionalLightData>((void*)(unsafePtr3 + num7));
							this.CalculateDirectionalLightDataTextureInfo(ref lightData, cmd, light, legacyLight, hdadditionalLightData, hdCamera, ptr.shadowMapFlags, num7, shadowIndex);
						}
						else
						{
							int num8 = i - sortedDirectionalLightCounts;
							ref LightData lightData2 = ref UnsafeUtility.AsRef<LightData>((void*)(unsafePtr2 + num8));
							this.CalculateLightDataTextureInfo(ref lightData2, cmd, legacyLight, hdadditionalLightData, shadowInitParams, hdCamera, contactShadowScalableSetting, lightType, ptr.shadowMapFlags, rayTracingEnabled, num8, shadowIndex);
						}
					}
				}
			}
		}

		// Token: 0x0400059E RID: 1438
		public const int ArrayCapacity = 100;

		// Token: 0x0400059F RID: 1439
		private NativeArray<HDGpuLightsBuilder.LightsPerView> m_LightsPerView;

		// Token: 0x040005A0 RID: 1440
		private int m_LighsPerViewCapacity;

		// Token: 0x040005A1 RID: 1441
		private int m_LightsPerViewCount;

		// Token: 0x040005A2 RID: 1442
		private NativeArray<SFiniteLightBound> m_LightBounds;

		// Token: 0x040005A3 RID: 1443
		private NativeArray<LightVolumeData> m_LightVolumes;

		// Token: 0x040005A4 RID: 1444
		private int m_LightBoundsCapacity;

		// Token: 0x040005A5 RID: 1445
		private int m_LightBoundsCount;

		// Token: 0x040005A6 RID: 1446
		private NativeArray<LightData> m_Lights;

		// Token: 0x040005A7 RID: 1447
		private int m_LightCapacity;

		// Token: 0x040005A8 RID: 1448
		private int m_LightCount;

		// Token: 0x040005A9 RID: 1449
		private NativeArray<DirectionalLightData> m_DirectionalLights;

		// Token: 0x040005AA RID: 1450
		private int m_DirectionalLightCapacity;

		// Token: 0x040005AB RID: 1451
		private int m_DirectionalLightCount;

		// Token: 0x040005AC RID: 1452
		private NativeArray<int> m_LightTypeCounters;

		// Token: 0x040005AD RID: 1453
		private HDRenderPipelineAsset m_Asset;

		// Token: 0x040005AE RID: 1454
		private HDShadowManager m_ShadowManager;

		// Token: 0x040005AF RID: 1455
		private HDRenderPipeline.LightLoopTextureCaches m_TextureCaches;

		// Token: 0x040005B0 RID: 1456
		private HashSet<HDAdditionalLightData> m_ScreenSpaceShadowsUnion = new HashSet<HDAdditionalLightData>();

		// Token: 0x040005B1 RID: 1457
		private int m_CurrentShadowSortedSunLightIndex = -1;

		// Token: 0x040005B2 RID: 1458
		private HDProcessedVisibleLightsBuilder.ShadowMapFlags m_CurrentSunShadowMapFlags;

		// Token: 0x040005B3 RID: 1459
		private DirectionalLightData m_CurrentSunLightDirectionalLightData;

		// Token: 0x040005B4 RID: 1460
		private int m_ContactShadowIndex;

		// Token: 0x040005B5 RID: 1461
		private int m_ScreenSpaceShadowIndex;

		// Token: 0x040005B6 RID: 1462
		private int m_ScreenSpaceShadowChannelSlot;

		// Token: 0x040005B7 RID: 1463
		private int m_DebugSelectedLightShadowIndex;

		// Token: 0x040005B8 RID: 1464
		private int m_DebugSelectedLightShadowCount;

		// Token: 0x040005B9 RID: 1465
		private HDRenderPipeline.ScreenSpaceShadowData[] m_CurrentScreenSpaceShadowData;

		// Token: 0x040005BA RID: 1466
		private int m_BoundsEyeDataOffset;

		// Token: 0x040005BB RID: 1467
		private JobHandle m_CreateGpuLightDataJobHandle;

		// Token: 0x02000328 RID: 808
		public struct LightsPerView
		{
			// Token: 0x040022B1 RID: 8881
			public Matrix4x4 worldToView;

			// Token: 0x040022B2 RID: 8882
			public int boundsOffset;

			// Token: 0x040022B3 RID: 8883
			public int boundsCount;
		}

		// Token: 0x02000329 RID: 809
		internal enum GPULightTypeCountSlots
		{
			// Token: 0x040022B5 RID: 8885
			Directional,
			// Token: 0x040022B6 RID: 8886
			Punctual,
			// Token: 0x040022B7 RID: 8887
			Area
		}

		// Token: 0x0200032A RID: 810
		internal struct CreateGpuLightDataJobGlobalConfig
		{
			// Token: 0x06001280 RID: 4736 RVA: 0x0008D5B4 File Offset: 0x0008B7B4
			public static HDGpuLightsBuilder.CreateGpuLightDataJobGlobalConfig Create(HDCamera hdCamera, HDShadowSettings hdShadowSettings)
			{
				return new HDGpuLightsBuilder.CreateGpuLightDataJobGlobalConfig
				{
					lightLayersEnabled = hdCamera.frameSettings.IsEnabled(FrameSettingsField.LightLayers),
					specularGlobalDimmer = hdCamera.frameSettings.specularGlobalDimmer,
					maxShadowFadeDistance = hdShadowSettings.maxShadowDistance.value,
					invalidScreenSpaceShadowIndex = (int)LightDefinitions.s_InvalidScreenSpaceShadow
				};
			}

			// Token: 0x040022B8 RID: 8888
			public bool lightLayersEnabled;

			// Token: 0x040022B9 RID: 8889
			public float specularGlobalDimmer;

			// Token: 0x040022BA RID: 8890
			public int invalidScreenSpaceShadowIndex;

			// Token: 0x040022BB RID: 8891
			public float maxShadowFadeDistance;
		}

		// Token: 0x0200032B RID: 811
		[BurstCompile]
		internal struct CreateGpuLightDataJob : IJobParallelFor
		{
			// Token: 0x06001281 RID: 4737 RVA: 0x0008D614 File Offset: 0x0008B814
			private unsafe ref HDLightRenderData GetLightData(int dataIndex)
			{
				return UnsafeUtility.AsRef<HDLightRenderData>((void*)((byte*)this.lightRenderDataArray.GetUnsafePtr<HDLightRenderData>() + (IntPtr)dataIndex * (IntPtr)sizeof(HDLightRenderData)));
			}

			// Token: 0x06001282 RID: 4738 RVA: 0x0008D630 File Offset: 0x0008B830
			private static uint GetLightLayer(bool lightLayersEnabled, in HDLightRenderData lightRenderData)
			{
				int lightLayer = (int)lightRenderData.lightLayer;
				uint result = (uint)((lightLayer < 0) ? 255 : lightLayer);
				if (!lightLayersEnabled)
				{
					return uint.MaxValue;
				}
				return result;
			}

			// Token: 0x06001283 RID: 4739 RVA: 0x0008D658 File Offset: 0x0008B858
			private static Vector3 GetLightColor(in VisibleLight light)
			{
				VisibleLight visibleLight = light;
				float r = visibleLight.finalColor.r;
				visibleLight = light;
				float g = visibleLight.finalColor.g;
				visibleLight = light;
				return new Vector3(r, g, visibleLight.finalColor.b);
			}

			// Token: 0x06001284 RID: 4740 RVA: 0x0008D6A3 File Offset: 0x0008B8A3
			private unsafe void IncrementCounter(HDGpuLightsBuilder.GPULightTypeCountSlots counterSlot)
			{
				Interlocked.Increment(UnsafeUtility.AsRef<int>((void*)((byte*)this.gpuLightCounters.GetUnsafePtr<int>() + (IntPtr)counterSlot * 4)));
			}

			// Token: 0x06001285 RID: 4741 RVA: 0x0008D6C0 File Offset: 0x0008B8C0
			public static void ConvertLightToGPUFormat(LightCategory lightCategory, GPULightType gpuLightType, in HDGpuLightsBuilder.CreateGpuLightDataJobGlobalConfig globalConfig, LightShadowCasterMode visibleLightShadowCasterMode, in LightBakingOutput visibleLightBakingOutput, in VisibleLight light, in HDProcessedVisibleLight processedEntity, in HDLightRenderData lightRenderData, out Vector3 lightDimensions, ref LightData lightData)
			{
				lightData.lightLayers = HDGpuLightsBuilder.CreateGpuLightDataJob.GetLightLayer(globalConfig.lightLayersEnabled, lightRenderData);
				lightData.lightType = gpuLightType;
				VisibleLightExtensionMethods.VisibleLightAxisAndPosition axisAndPosition = light.GetAxisAndPosition();
				lightData.positionRWS = axisAndPosition.Position;
				VisibleLight visibleLight = light;
				lightData.range = visibleLight.range;
				if (lightRenderData.applyRangeAttenuation)
				{
					float num = 1f;
					visibleLight = light;
					float range = visibleLight.range;
					visibleLight = light;
					lightData.rangeAttenuationScale = num / (range * visibleLight.range);
					lightData.rangeAttenuationBias = 1f;
					if (lightData.lightType == GPULightType.Rectangle)
					{
						lightData.rangeAttenuationScale = 1f;
					}
				}
				else
				{
					float num2 = 4096f;
					visibleLight = light;
					float range2 = visibleLight.range;
					visibleLight = light;
					lightData.rangeAttenuationScale = num2 / (range2 * visibleLight.range);
					lightData.rangeAttenuationBias = 16777216f;
					if (lightData.lightType == GPULightType.Rectangle)
					{
						lightData.rangeAttenuationScale = 4096f;
					}
				}
				float shapeWidth = lightRenderData.shapeWidth;
				float shapeHeight = lightRenderData.shapeHeight;
				lightData.color = HDGpuLightsBuilder.CreateGpuLightDataJob.GetLightColor(light);
				lightData.forward = axisAndPosition.Forward;
				lightData.up = axisAndPosition.Up;
				lightData.right = axisAndPosition.Right;
				lightDimensions.x = shapeWidth;
				lightDimensions.y = shapeHeight;
				visibleLight = light;
				lightDimensions.z = visibleLight.range;
				lightData.boxLightSafeExtent = 1f;
				if (lightData.lightType == GPULightType.ProjectorBox)
				{
					lightData.right *= 2f / Mathf.Max(shapeWidth, 0.001f);
					lightData.up *= 2f / Mathf.Max(shapeHeight, 0.001f);
				}
				else if (lightData.lightType == GPULightType.ProjectorPyramid)
				{
					visibleLight = light;
					float spotAngle = visibleLight.spotAngle;
					float aspectRatio = lightRenderData.aspectRatio;
					float num3;
					float num4;
					if (aspectRatio >= 1f)
					{
						num3 = 2f * Mathf.Tan(spotAngle * 0.5f * 0.017453292f);
						num4 = num3 * aspectRatio;
					}
					else
					{
						num4 = 2f * Mathf.Tan(spotAngle * 0.5f * 0.017453292f);
						num3 = num4 / aspectRatio;
					}
					lightDimensions.x = num4;
					lightDimensions.y = num3;
					lightData.right *= 2f / num4;
					lightData.up *= 2f / num3;
				}
				if (lightData.lightType == GPULightType.Spot)
				{
					visibleLight = light;
					float spotAngle2 = visibleLight.spotAngle;
					float num5 = lightRenderData.innerSpotPercent / 100f;
					float num6 = Mathf.Clamp(Mathf.Cos(spotAngle2 * 0.5f * 0.017453292f), 0f, 1f);
					float num7 = Mathf.Sqrt(1f - num6 * num6);
					float num8 = Mathf.Clamp(Mathf.Cos(spotAngle2 * 0.5f * num5 * 0.017453292f), 0f, 1f);
					float num9 = Mathf.Max(0.0001f, num8 - num6);
					lightData.angleScale = 1f / num9;
					lightData.angleOffset = -num6 * lightData.angleScale;
					lightData.iesCut = lightRenderData.spotIESCutoffPercent / 100f;
					float d = num6 / num7;
					lightData.up *= d;
					lightData.right *= d;
				}
				else
				{
					lightData.angleScale = 0f;
					lightData.angleOffset = 1f;
					lightData.iesCut = 1f;
				}
				float shapeRadius = lightRenderData.shapeRadius;
				if (lightData.lightType != GPULightType.Directional && lightData.lightType != GPULightType.ProjectorBox)
				{
					lightData.size = new Vector4(shapeRadius * shapeRadius, 0f, 0f, 0f);
				}
				if (lightData.lightType == GPULightType.Rectangle || lightData.lightType == GPULightType.Tube)
				{
					lightData.size = new Vector4(shapeWidth, shapeHeight, Mathf.Cos(lightRenderData.barnDoorAngle * 3.1415927f / 180f), lightRenderData.barnDoorLength);
				}
				float lightDimmer = lightRenderData.lightDimmer;
				lightData.lightDimmer = processedEntity.lightDistanceFade * lightDimmer;
				lightData.diffuseDimmer = processedEntity.lightDistanceFade * (lightRenderData.affectDiffuse ? lightDimmer : 0f);
				lightData.specularDimmer = processedEntity.lightDistanceFade * (lightRenderData.affectSpecular ? (lightDimmer * globalConfig.specularGlobalDimmer) : 0f);
				lightData.volumetricLightDimmer = Mathf.Min(processedEntity.lightVolumetricDistanceFade, processedEntity.lightDistanceFade) * (lightRenderData.affectVolumetric ? lightRenderData.volumetricDimmer : 0f);
				lightData.cookieMode = CookieMode.None;
				lightData.shadowIndex = -1;
				lightData.screenSpaceShadowIndex = globalConfig.invalidScreenSpaceShadowIndex;
				lightData.isRayTracedContactShadow = 0f;
				float distanceToCamera = processedEntity.distanceToCamera;
				float shadowFadeDistance = lightRenderData.shadowFadeDistance;
				float shadowDimmer = lightRenderData.shadowDimmer;
				float num10 = lightRenderData.affectVolumetric ? lightRenderData.volumetricShadowDimmer : 0f;
				float num11 = HDUtils.ComputeLinearDistanceFade(distanceToCamera, Mathf.Min(globalConfig.maxShadowFadeDistance, shadowFadeDistance));
				lightData.shadowDimmer = num11 * shadowDimmer;
				lightData.volumetricShadowDimmer = num11 * num10;
				Color shadowTint = lightRenderData.shadowTint;
				bool flag = lightRenderData.penumbraTint && (shadowTint.r != shadowTint.g || shadowTint.g != shadowTint.b);
				lightData.penumbraTint = (flag ? 1f : 0f);
				if (flag)
				{
					lightData.shadowTint = new Vector3(Mathf.Pow(shadowTint.r, 2.2f), Mathf.Pow(shadowTint.g, 2.2f), Mathf.Pow(shadowTint.b, 2.2f));
				}
				else
				{
					lightData.shadowTint = new Vector3(shadowTint.r, shadowTint.g, shadowTint.b);
				}
				float num12 = Mathf.Clamp01(1.1725f / (1.01f + Mathf.Pow(1f * (shapeRadius + 0.1f), 2f)) - 0.15f);
				lightData.minRoughness = (1f - num12) * (1f - num12);
				lightData.shadowMaskSelector = Vector4.zero;
				if (processedEntity.isBakedShadowMask)
				{
					lightData.shadowMaskSelector[visibleLightBakingOutput.occlusionMaskChannel] = 1f;
					lightData.nonLightMappedOnly = ((visibleLightShadowCasterMode == LightShadowCasterMode.NonLightmappedOnly) ? 1 : 0);
					return;
				}
				lightData.shadowMaskSelector.x = -1f;
				lightData.nonLightMappedOnly = 0;
			}

			// Token: 0x06001286 RID: 4742 RVA: 0x0008DD7C File Offset: 0x0008BF7C
			private void StoreAndConvertLightToGPUFormat(int outputIndex, int lightIndex, LightCategory lightCategory, GPULightType gpuLightType, LightVolumeType lightVolumeType)
			{
				VisibleLight visibleLight = this.visibleLights[lightIndex];
				HDProcessedVisibleLight hdprocessedVisibleLight = this.processedEntities[lightIndex];
				LightData value = default(LightData);
				ref HDLightRenderData lightData = ref this.GetLightData(hdprocessedVisibleLight.dataIndex);
				LightShadowCasterMode lightShadowCasterMode = this.visibleLightShadowCasterMode[lightIndex];
				LightBakingOutput lightBakingOutput = this.visibleLightBakingOutput[lightIndex];
				Vector3 vector;
				HDGpuLightsBuilder.CreateGpuLightDataJob.ConvertLightToGPUFormat(lightCategory, gpuLightType, this.globalConfig, lightShadowCasterMode, lightBakingOutput, visibleLight, hdprocessedVisibleLight, lightData, out vector, ref value);
				for (int i = 0; i < this.viewCounts; i++)
				{
					HDGpuLightsBuilder.LightsPerView lightsPerView = this.lightsPerView[i];
					this.ComputeLightVolumeDataAndBound(lightCategory, gpuLightType, lightVolumeType, visibleLight, value, vector, lightsPerView.worldToView, outputIndex + lightsPerView.boundsOffset);
				}
				if (this.useCameraRelativePosition)
				{
					value.positionRWS -= this.cameraPos;
				}
				if (lightCategory != LightCategory.Punctual)
				{
					if (lightCategory == LightCategory.Area)
					{
						this.IncrementCounter(HDGpuLightsBuilder.GPULightTypeCountSlots.Area);
					}
				}
				else
				{
					this.IncrementCounter(HDGpuLightsBuilder.GPULightTypeCountSlots.Punctual);
				}
				this.lights[outputIndex] = value;
			}

			// Token: 0x06001287 RID: 4743 RVA: 0x0008DE7C File Offset: 0x0008C07C
			private void ComputeLightVolumeDataAndBound(LightCategory lightCategory, GPULightType gpuLightType, LightVolumeType lightVolumeType, in VisibleLight light, in LightData lightData, in Vector3 lightDimensions, in Matrix4x4 worldToView, int outputIndex)
			{
				float z = lightDimensions.z;
				VisibleLight visibleLight = light;
				Matrix4x4 localToWorldMatrix = visibleLight.localToWorldMatrix;
				Vector3 positionRWS = lightData.positionRWS;
				Matrix4x4 matrix4x = worldToView;
				Vector3 vector = matrix4x.MultiplyPoint(positionRWS);
				matrix4x = worldToView;
				Vector3 vector2 = matrix4x.MultiplyVector(localToWorldMatrix.GetColumn(0));
				matrix4x = worldToView;
				Vector3 vector3 = matrix4x.MultiplyVector(localToWorldMatrix.GetColumn(1));
				matrix4x = worldToView;
				Vector3 vector4 = matrix4x.MultiplyVector(localToWorldMatrix.GetColumn(2));
				SFiniteLightBound sfiniteLightBound = default(SFiniteLightBound);
				LightVolumeData value = default(LightVolumeData);
				value.lightCategory = (uint)lightCategory;
				value.lightVolume = (uint)lightVolumeType;
				if (gpuLightType == GPULightType.Spot || gpuLightType == GPULightType.ProjectorPyramid)
				{
					Vector3 a = localToWorldMatrix.GetColumn(2);
					Vector3 vector5 = vector2;
					Vector3 vector6 = vector3;
					Vector3 vector7 = vector4;
					visibleLight = light;
					float spotAngle = visibleLight.spotAngle;
					float num = Mathf.Cos(0.5f * spotAngle * 0.017453292f);
					float num2 = Mathf.Sin(0.5f * spotAngle * 0.017453292f);
					if (gpuLightType == GPULightType.ProjectorPyramid)
					{
						Vector3 value2 = 0.5f * lightDimensions.x * vector5 + 0.5f * lightDimensions.y * vector6 + 1f * vector7;
						num = Vector3.Dot(vector7, Vector3.Normalize(value2));
						num2 = Mathf.Sqrt(1f - num * num);
					}
					float num3 = (num > 0f) ? (num2 / num) : float.MaxValue;
					float cotan = (num2 > 0f) ? (num / num2) : float.MaxValue;
					bool flag = true;
					float num4 = flag ? num3 : num2;
					matrix4x = worldToView;
					sfiniteLightBound.center = matrix4x.MultiplyPoint(positionRWS + 0.5f * z * a);
					sfiniteLightBound.boxAxisX = num4 * z * vector5;
					sfiniteLightBound.boxAxisY = num4 * z * vector6;
					sfiniteLightBound.boxAxisZ = 0.5f * z * vector7;
					float num5 = num2;
					float num6 = num - 0.5f;
					num5 *= z;
					float num7 = num6 * z;
					float num8 = Mathf.Sqrt(num7 * num7 + 1f * num5 * num5);
					sfiniteLightBound.radius = ((num8 > 0.5f * z) ? num8 : (0.5f * z));
					sfiniteLightBound.scaleXY = (flag ? 0.01f : 1f);
					value.lightAxisX = vector5;
					value.lightAxisY = vector6;
					value.lightAxisZ = vector7;
					value.lightPos = vector;
					value.radiusSq = z * z;
					value.cotan = cotan;
					value.featureFlags = 4096U;
				}
				else if (gpuLightType == GPULightType.Point)
				{
					Vector3 vector8 = new Vector3(1f, 0f, 0f);
					Vector3 vector9 = new Vector3(0f, 1f, 0f);
					Vector3 vector10 = new Vector3(0f, 0f, 1f);
					sfiniteLightBound.center = vector;
					sfiniteLightBound.boxAxisX = vector8 * z;
					sfiniteLightBound.boxAxisY = vector9 * z;
					sfiniteLightBound.boxAxisZ = vector10 * z;
					sfiniteLightBound.scaleXY = 1f;
					sfiniteLightBound.radius = z;
					value.lightAxisX = vector8;
					value.lightAxisY = vector9;
					value.lightAxisZ = vector10;
					value.lightPos = sfiniteLightBound.center;
					value.radiusSq = z * z;
					value.featureFlags = 4096U;
				}
				else if (gpuLightType == GPULightType.Tube)
				{
					Vector3 a2 = new Vector3(lightDimensions.x + 2f * z, 2f * z, 2f * z);
					Vector3 vector11 = 0.5f * a2;
					Vector3 vector12 = vector;
					sfiniteLightBound.center = vector12;
					sfiniteLightBound.boxAxisX = vector11.x * vector2;
					sfiniteLightBound.boxAxisY = vector11.y * vector3;
					sfiniteLightBound.boxAxisZ = vector11.z * vector4;
					sfiniteLightBound.radius = vector11.x;
					sfiniteLightBound.scaleXY = 1f;
					value.lightPos = vector12;
					value.lightAxisX = vector2;
					value.lightAxisY = vector3;
					value.lightAxisZ = vector4;
					value.boxInvRange.Set(1f / vector11.x, 1f / vector11.y, 1f / vector11.z);
					value.featureFlags = 8192U;
				}
				else if (gpuLightType == GPULightType.Rectangle)
				{
					Vector3 a3 = new Vector3(lightDimensions.x + 2f * z, lightDimensions.y + 2f * z, z);
					Vector3 vector13 = 0.5f * a3;
					Vector3 vector14 = vector + vector13.z * vector4;
					float num9 = z + 0.5f * Mathf.Sqrt(lightDimensions.x * lightDimensions.x + lightDimensions.y * lightDimensions.y);
					sfiniteLightBound.center = vector14;
					sfiniteLightBound.boxAxisX = vector13.x * vector2;
					sfiniteLightBound.boxAxisY = vector13.y * vector3;
					sfiniteLightBound.boxAxisZ = vector13.z * vector4;
					sfiniteLightBound.radius = Mathf.Sqrt(num9 * num9 + 0.5f * z * (0.5f * z));
					sfiniteLightBound.scaleXY = 1f;
					value.lightPos = vector14;
					value.lightAxisX = vector2;
					value.lightAxisY = vector3;
					value.lightAxisZ = vector4;
					value.boxInvRange.Set(1f / vector13.x, 1f / vector13.y, 1f / vector13.z);
					value.featureFlags = 8192U;
				}
				else if (gpuLightType == GPULightType.ProjectorBox)
				{
					Vector3 a4 = new Vector3(lightDimensions.x, lightDimensions.y, z);
					Vector3 vector15 = 0.5f * a4;
					Vector3 vector16 = vector + vector15.z * vector4;
					sfiniteLightBound.center = vector16;
					sfiniteLightBound.boxAxisX = vector15.x * vector2;
					sfiniteLightBound.boxAxisY = vector15.y * vector3;
					sfiniteLightBound.boxAxisZ = vector15.z * vector4;
					sfiniteLightBound.radius = vector15.magnitude;
					sfiniteLightBound.scaleXY = 1f;
					value.lightPos = vector16;
					value.lightAxisX = vector2;
					value.lightAxisY = vector3;
					value.lightAxisZ = vector4;
					value.boxInvRange.Set(1f / vector15.x, 1f / vector15.y, 1f / vector15.z);
					value.featureFlags = 4096U;
				}
				this.lightBounds[outputIndex] = sfiniteLightBound;
				this.lightVolumes[outputIndex] = value;
			}

			// Token: 0x06001288 RID: 4744 RVA: 0x0008E5A8 File Offset: 0x0008C7A8
			private void ConvertDirectionalLightToGPUFormat(int outputIndex, int lightIndex, LightCategory lightCategory, GPULightType gpuLightType, LightVolumeType lightVolumeType)
			{
				VisibleLight value = this.visibleLights[lightIndex];
				HDProcessedVisibleLight hdprocessedVisibleLight = this.processedEntities[lightIndex];
				int dataIndex = hdprocessedVisibleLight.dataIndex;
				DirectionalLightData directionalLightData = default(DirectionalLightData);
				ref HDLightRenderData lightData = ref this.GetLightData(dataIndex);
				directionalLightData.lightLayers = HDGpuLightsBuilder.CreateGpuLightDataJob.GetLightLayer(this.globalConfig.lightLayersEnabled, lightData);
				directionalLightData.forward = value.GetForward();
				directionalLightData.color = HDGpuLightsBuilder.CreateGpuLightDataJob.GetLightColor(value);
				directionalLightData.color *= ((this.defaultDataIndex == dataIndex) ? 3.1415927f : 1f);
				directionalLightData.lightDimmer = lightData.lightDimmer;
				directionalLightData.diffuseDimmer = (lightData.affectDiffuse ? directionalLightData.lightDimmer : 0f);
				directionalLightData.specularDimmer = (lightData.affectSpecular ? (directionalLightData.lightDimmer * this.globalConfig.specularGlobalDimmer) : 0f);
				directionalLightData.volumetricLightDimmer = (lightData.affectVolumetric ? lightData.volumetricDimmer : 0f);
				directionalLightData.shadowIndex = -1;
				directionalLightData.screenSpaceShadowIndex = this.globalConfig.invalidScreenSpaceShadowIndex;
				directionalLightData.isRayTracedContactShadow = 0f;
				directionalLightData.right = value.GetRight() * 2f / Mathf.Max(lightData.shapeWidth, 0.001f);
				directionalLightData.up = value.GetUp() * 2f / Mathf.Max(lightData.shapeHeight, 0.001f);
				directionalLightData.positionRWS = value.GetPosition();
				directionalLightData.shadowDimmer = lightData.shadowDimmer;
				float volumetricShadowDimmer = lightData.affectVolumetric ? lightData.volumetricShadowDimmer : 0f;
				directionalLightData.volumetricShadowDimmer = volumetricShadowDimmer;
				Color shadowTint = lightData.shadowTint;
				bool flag = lightData.penumbraTint && (shadowTint.r != shadowTint.g || shadowTint.g != shadowTint.b);
				directionalLightData.penumbraTint = (flag ? 1f : 0f);
				if (flag)
				{
					directionalLightData.shadowTint = new Vector3(shadowTint.r * shadowTint.r, shadowTint.g * shadowTint.g, shadowTint.b * shadowTint.b);
				}
				else
				{
					directionalLightData.shadowTint = new Vector3(shadowTint.r, shadowTint.g, shadowTint.b);
				}
				float num = Mathf.Clamp01(1.35f / (1f + Mathf.Pow(1.15f * (0.0315f * lightData.angularDiameter + 0.4f), 2f)) - 0.11f);
				directionalLightData.minRoughness = (1f - num) * (1f - num);
				directionalLightData.shadowMaskSelector = Vector4.zero;
				if (hdprocessedVisibleLight.isBakedShadowMask)
				{
					LightBakingOutput lightBakingOutput = this.visibleLightBakingOutput[lightIndex];
					directionalLightData.shadowMaskSelector[lightBakingOutput.occlusionMaskChannel] = 1f;
					directionalLightData.nonLightMappedOnly = ((this.visibleLightShadowCasterMode[lightIndex] == LightShadowCasterMode.NonLightmappedOnly) ? 1 : 0);
				}
				else
				{
					directionalLightData.shadowMaskSelector.x = -1f;
					directionalLightData.nonLightMappedOnly = 0;
				}
				bool flag2 = this.isPbrSkyActive && lightData.interactsWithSky;
				directionalLightData.distanceFromCamera = -1f;
				if (flag2)
				{
					directionalLightData.distanceFromCamera = lightData.distance;
					if (this.precomputedAtmosphericAttenuation != 0)
					{
						float num2 = this.airScaleHeight;
						float num3 = this.aerosolScaleHeight;
						float num4 = this.aerosolExtinctionCoefficient;
						float r = this.planetaryRadius;
						Vector3 vector = -directionalLightData.forward;
						Vector3 vector2 = PhysicallyBasedSky.EvaluateAtmosphericAttenuation(num2, num3, this.airExtinctionCoefficient, num4, this.planetCenterPosition, r, vector, this.cameraPos);
						directionalLightData.color.x = directionalLightData.color.x * vector2.x;
						directionalLightData.color.y = directionalLightData.color.y * vector2.y;
						directionalLightData.color.z = directionalLightData.color.z * vector2.z;
					}
				}
				directionalLightData.angularDiameter = lightData.angularDiameter * 0.017453292f;
				directionalLightData.flareSize = Mathf.Max(lightData.flareSize * 0.017453292f, 5.9604645E-08f);
				directionalLightData.flareFalloff = lightData.flareFalloff;
				float num5 = 0.5f * directionalLightData.angularDiameter;
				directionalLightData.flareCosInner = Mathf.Cos(num5);
				directionalLightData.flareCosOuter = Mathf.Cos(num5 + directionalLightData.flareSize);
				directionalLightData.flareTint = lightData.flareTint;
				directionalLightData.surfaceTint = lightData.surfaceTint;
				if (this.useCameraRelativePosition)
				{
					directionalLightData.positionRWS -= this.cameraPos;
				}
				this.IncrementCounter(HDGpuLightsBuilder.GPULightTypeCountSlots.Directional);
				this.directionalLights[outputIndex] = directionalLightData;
			}

			// Token: 0x06001289 RID: 4745 RVA: 0x0008EA70 File Offset: 0x0008CC70
			public void Execute(int index)
			{
				LightCategory lightCategory;
				GPULightType gpulightType;
				LightVolumeType lightVolumeType;
				int lightIndex;
				HDGpuLightsBuilder.UnpackLightSortKey(this.sortKeys[index], out lightCategory, out gpulightType, out lightVolumeType, out lightIndex);
				if (gpulightType == GPULightType.Directional)
				{
					this.ConvertDirectionalLightToGPUFormat(index, lightIndex, lightCategory, gpulightType, lightVolumeType);
					return;
				}
				int outputIndex = index - this.directionalSortedLightCounts;
				this.StoreAndConvertLightToGPUFormat(outputIndex, lightIndex, lightCategory, gpulightType, lightVolumeType);
			}

			// Token: 0x040022BC RID: 8892
			[ReadOnly]
			public int totalLightCounts;

			// Token: 0x040022BD RID: 8893
			[ReadOnly]
			public int outputLightCounts;

			// Token: 0x040022BE RID: 8894
			[ReadOnly]
			public int outputDirectionalLightCounts;

			// Token: 0x040022BF RID: 8895
			[ReadOnly]
			public int outputLightBoundsCount;

			// Token: 0x040022C0 RID: 8896
			[ReadOnly]
			public HDGpuLightsBuilder.CreateGpuLightDataJobGlobalConfig globalConfig;

			// Token: 0x040022C1 RID: 8897
			[ReadOnly]
			public Vector3 cameraPos;

			// Token: 0x040022C2 RID: 8898
			[ReadOnly]
			public int directionalSortedLightCounts;

			// Token: 0x040022C3 RID: 8899
			[ReadOnly]
			public bool isPbrSkyActive;

			// Token: 0x040022C4 RID: 8900
			[ReadOnly]
			public int precomputedAtmosphericAttenuation;

			// Token: 0x040022C5 RID: 8901
			[ReadOnly]
			public int defaultDataIndex;

			// Token: 0x040022C6 RID: 8902
			[ReadOnly]
			public int viewCounts;

			// Token: 0x040022C7 RID: 8903
			[ReadOnly]
			public bool useCameraRelativePosition;

			// Token: 0x040022C8 RID: 8904
			[ReadOnly]
			public Vector3 planetCenterPosition;

			// Token: 0x040022C9 RID: 8905
			[ReadOnly]
			public float planetaryRadius;

			// Token: 0x040022CA RID: 8906
			[ReadOnly]
			public float airScaleHeight;

			// Token: 0x040022CB RID: 8907
			[ReadOnly]
			public float aerosolScaleHeight;

			// Token: 0x040022CC RID: 8908
			[ReadOnly]
			public Vector3 airExtinctionCoefficient;

			// Token: 0x040022CD RID: 8909
			[ReadOnly]
			public float aerosolExtinctionCoefficient;

			// Token: 0x040022CE RID: 8910
			[ReadOnly]
			public float maxShadowDistance;

			// Token: 0x040022CF RID: 8911
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<HDLightRenderData> lightRenderDataArray;

			// Token: 0x040022D0 RID: 8912
			[ReadOnly]
			public NativeArray<uint> sortKeys;

			// Token: 0x040022D1 RID: 8913
			[ReadOnly]
			public NativeArray<HDProcessedVisibleLight> processedEntities;

			// Token: 0x040022D2 RID: 8914
			[ReadOnly]
			public NativeArray<VisibleLight> visibleLights;

			// Token: 0x040022D3 RID: 8915
			[ReadOnly]
			public NativeArray<LightBakingOutput> visibleLightBakingOutput;

			// Token: 0x040022D4 RID: 8916
			[ReadOnly]
			public NativeArray<LightShadowCasterMode> visibleLightShadowCasterMode;

			// Token: 0x040022D5 RID: 8917
			[WriteOnly]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<LightData> lights;

			// Token: 0x040022D6 RID: 8918
			[WriteOnly]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<DirectionalLightData> directionalLights;

			// Token: 0x040022D7 RID: 8919
			[WriteOnly]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<HDGpuLightsBuilder.LightsPerView> lightsPerView;

			// Token: 0x040022D8 RID: 8920
			[WriteOnly]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<SFiniteLightBound> lightBounds;

			// Token: 0x040022D9 RID: 8921
			[WriteOnly]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<LightVolumeData> lightVolumes;

			// Token: 0x040022DA RID: 8922
			[WriteOnly]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<int> gpuLightCounters;
		}
	}
}
