using System;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000C3 RID: 195
	public class HDCachedShadowManager
	{
		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060008A5 RID: 2213 RVA: 0x0004D29B File Offset: 0x0004B49B
		public static HDCachedShadowManager instance
		{
			get
			{
				return HDCachedShadowManager.s_Instance;
			}
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x0004D2A4 File Offset: 0x0004B4A4
		public bool WouldFitInAtlas(int shadowResolution, HDLightType lightType)
		{
			bool flag = true;
			int item = 0;
			int item2 = 0;
			if (lightType == HDLightType.Point)
			{
				int num = 0;
				for (int i = 0; i < 6; i++)
				{
					flag = (flag && HDShadowManager.cachedShadowManager.punctualShadowAtlas.FindSlotInAtlas(shadowResolution, true, out item, out item2));
					if (!flag)
					{
						for (int j = 0; j < num; j++)
						{
							HDShadowManager.cachedShadowManager.punctualShadowAtlas.FreeTempFilled(this.m_TempFilled[j].Item1, this.m_TempFilled[j].Item2, shadowResolution);
						}
						return false;
					}
					this.m_TempFilled[num++] = new ValueTuple<int, int>(item, item2);
				}
				for (int k = 0; k < num; k++)
				{
					HDShadowManager.cachedShadowManager.punctualShadowAtlas.FreeTempFilled(this.m_TempFilled[k].Item1, this.m_TempFilled[k].Item2, shadowResolution);
				}
			}
			if (lightType == HDLightType.Spot)
			{
				flag = (flag && HDShadowManager.cachedShadowManager.punctualShadowAtlas.FindSlotInAtlas(shadowResolution, out item, out item2));
			}
			if (lightType == HDLightType.Area)
			{
				flag = (flag && HDShadowManager.cachedShadowManager.areaShadowAtlas.FindSlotInAtlas(shadowResolution, out item, out item2));
			}
			return flag;
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x0004D3D8 File Offset: 0x0004B5D8
		public bool WouldFitInAtlas(HDAdditionalLightData lightData)
		{
			if (lightData.legacyLight.shadows != LightShadows.None)
			{
				HDLightType type = lightData.type;
				int resolutionFromSettings = lightData.GetResolutionFromSettings(lightData.GetShadowMapType(type), this.m_InitParams);
				return this.WouldFitInAtlas(resolutionFromSettings, type);
			}
			return false;
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x0004D417 File Offset: 0x0004B617
		public void DefragAtlas(HDLightType lightType)
		{
			if (lightType == HDLightType.Area)
			{
				HDCachedShadowManager.instance.areaShadowAtlas.DefragmentAtlasAndReRender(HDCachedShadowManager.instance.m_InitParams);
			}
			if (lightType == HDLightType.Point || lightType == HDLightType.Spot)
			{
				HDCachedShadowManager.instance.punctualShadowAtlas.DefragmentAtlasAndReRender(HDCachedShadowManager.instance.m_InitParams);
			}
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x0004D456 File Offset: 0x0004B656
		public void ForceEvictLight(HDAdditionalLightData lightData)
		{
			this.EvictLight(lightData);
			lightData.lightIdxForCachedShadows = -1;
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x0004D466 File Offset: 0x0004B666
		public void ForceRegisterLight(HDAdditionalLightData lightData)
		{
			this.RegisterLight(lightData);
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x0004D470 File Offset: 0x0004B670
		public bool LightHasBeenPlacedInAtlas(HDAdditionalLightData lightData)
		{
			HDLightType type = lightData.type;
			if (type == HDLightType.Area)
			{
				return HDCachedShadowManager.instance.areaShadowAtlas.LightIsPlaced(lightData);
			}
			if (type == HDLightType.Point || type == HDLightType.Spot)
			{
				return HDCachedShadowManager.instance.punctualShadowAtlas.LightIsPlaced(lightData);
			}
			return type == HDLightType.Directional && !lightData.ShadowIsUpdatedEveryFrame();
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x0004D4C0 File Offset: 0x0004B6C0
		public bool LightHasBeenPlaceAndRenderedAtLeastOnce(HDAdditionalLightData lightData, int numberOfCascades = 0)
		{
			HDLightType type = lightData.type;
			if (type == HDLightType.Area)
			{
				return HDCachedShadowManager.instance.areaShadowAtlas.LightIsPlaced(lightData) && HDCachedShadowManager.instance.areaShadowAtlas.FullLightShadowHasRenderedAtLeastOnce(lightData);
			}
			if (type == HDLightType.Point || type == HDLightType.Spot)
			{
				return HDCachedShadowManager.instance.punctualShadowAtlas.LightIsPlaced(lightData) && HDCachedShadowManager.instance.punctualShadowAtlas.FullLightShadowHasRenderedAtLeastOnce(lightData);
			}
			if (type == HDLightType.Directional)
			{
				bool flag = true;
				for (int i = 0; i < numberOfCascades; i++)
				{
					flag = (flag && this.m_DirectionalShadowHasRendered[i]);
				}
				return !lightData.ShadowIsUpdatedEveryFrame() && flag;
			}
			return false;
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x0004D558 File Offset: 0x0004B758
		public bool ShadowHasBeenPlaceAndRenderedAtLeastOnce(HDAdditionalLightData lightData, int shadowIndex)
		{
			HDLightType type = lightData.type;
			if (type == HDLightType.Area)
			{
				return HDCachedShadowManager.instance.areaShadowAtlas.LightIsPlaced(lightData) && HDCachedShadowManager.instance.areaShadowAtlas.ShadowHasRenderedAtLeastOnce(lightData.lightIdxForCachedShadows);
			}
			if (type == HDLightType.Spot)
			{
				return HDCachedShadowManager.instance.punctualShadowAtlas.LightIsPlaced(lightData) && HDCachedShadowManager.instance.punctualShadowAtlas.ShadowHasRenderedAtLeastOnce(lightData.lightIdxForCachedShadows);
			}
			if (type == HDLightType.Point || type == HDLightType.Spot)
			{
				return HDCachedShadowManager.instance.punctualShadowAtlas.LightIsPlaced(lightData) && HDCachedShadowManager.instance.punctualShadowAtlas.ShadowHasRenderedAtLeastOnce(lightData.lightIdxForCachedShadows + shadowIndex);
			}
			return type == HDLightType.Directional && !lightData.ShadowIsUpdatedEveryFrame() && this.m_DirectionalShadowHasRendered[shadowIndex];
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x0004D618 File Offset: 0x0004B818
		private void MarkAllDirectionalShadowsForUpdate()
		{
			for (int i = 0; i < 4; i++)
			{
				this.m_DirectionalShadowPendingUpdate[i] = true;
				this.m_DirectionalShadowHasRendered[i] = false;
			}
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x0004D644 File Offset: 0x0004B844
		private HDCachedShadowManager()
		{
			this.punctualShadowAtlas = new HDCachedShadowAtlas(ShadowMapType.PunctualAtlas);
			if (ShaderConfig.s_AreaLights == 1)
			{
				this.areaShadowAtlas = new HDCachedShadowAtlas(ShadowMapType.AreaLightAtlas);
			}
			this.directionalLightAtlas = new HDShadowAtlas();
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x0004D6AD File Offset: 0x0004B8AD
		internal void InitDirectionalState(HDShadowAtlas.HDShadowAtlasInitParameters atlasInitParams, bool allowMixedCachedShadows)
		{
			this.m_AllowDirectionalMixedCached = allowMixedCachedShadows;
			if (this.m_AllowDirectionalMixedCached)
			{
				this.m_DirectionalLightCacheSize = atlasInitParams.width;
				atlasInitParams.isShadowCache = true;
				atlasInitParams.useSharedTexture = true;
				this.directionalLightAtlas.InitAtlas(atlasInitParams);
			}
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x0004D6E6 File Offset: 0x0004B8E6
		internal void InitPunctualShadowAtlas(HDShadowAtlas.HDShadowAtlasInitParameters atlasInitParams)
		{
			this.m_InitParams = atlasInitParams.initParams;
			atlasInitParams.isShadowCache = true;
			this.punctualShadowAtlas.InitAtlas(atlasInitParams);
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x0004D708 File Offset: 0x0004B908
		internal void InitAreaLightShadowAtlas(HDShadowAtlas.HDShadowAtlasInitParameters atlasInitParams)
		{
			this.m_InitParams = atlasInitParams.initParams;
			atlasInitParams.isShadowCache = true;
			this.areaShadowAtlas.InitAtlas(atlasInitParams);
		}

		// Token: 0x060008B3 RID: 2227 RVA: 0x0004D72A File Offset: 0x0004B92A
		internal bool DirectionalHasCachedAtlas()
		{
			return this.m_AllowDirectionalMixedCached;
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x0004D734 File Offset: 0x0004B934
		internal void UpdateDirectionalCacheTexture(RenderGraph renderGraph)
		{
			TextureHandle outputTexture = this.directionalLightAtlas.GetOutputTexture(renderGraph);
			TextureDesc atlasDesc = this.directionalLightAtlas.GetAtlasDesc();
			if (this.m_DirectionalLightCacheSize != atlasDesc.width)
			{
				renderGraph.RefreshSharedTextureDesc(outputTexture, atlasDesc);
				this.m_DirectionalLightCacheSize = atlasDesc.width;
			}
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x0004D780 File Offset: 0x0004B980
		internal void RegisterLight(HDAdditionalLightData lightData)
		{
			if (lightData.legacyLight.bakingOutput.lightmapBakeType == LightmapBakeType.Baked)
			{
				return;
			}
			HDLightType type = lightData.type;
			if (type == HDLightType.Directional)
			{
				lightData.lightIdxForCachedShadows = 0;
				this.MarkAllDirectionalShadowsForUpdate();
			}
			if (type == HDLightType.Spot || type == HDLightType.Point)
			{
				this.punctualShadowAtlas.RegisterLight(lightData);
			}
			if (ShaderConfig.s_AreaLights == 1 && type == HDLightType.Area && lightData.areaLightShape == AreaLightShape.Rectangle)
			{
				this.areaShadowAtlas.RegisterLight(lightData);
			}
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x0004D7EC File Offset: 0x0004B9EC
		internal void EvictLight(HDAdditionalLightData lightData)
		{
			HDLightType type = lightData.type;
			if (type == HDLightType.Directional)
			{
				lightData.lightIdxForCachedShadows = -1;
				this.MarkAllDirectionalShadowsForUpdate();
			}
			if (type == HDLightType.Spot || type == HDLightType.Point)
			{
				this.punctualShadowAtlas.EvictLight(lightData);
			}
			if (ShaderConfig.s_AreaLights == 1 && type == HDLightType.Area)
			{
				this.areaShadowAtlas.EvictLight(lightData);
			}
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x0004D83C File Offset: 0x0004BA3C
		internal void RegisterTransformToCache(HDAdditionalLightData lightData)
		{
			HDLightType type = lightData.type;
			if (type == HDLightType.Spot || type == HDLightType.Point)
			{
				this.punctualShadowAtlas.RegisterTransformCacheSlot(lightData);
			}
			if (ShaderConfig.s_AreaLights == 1 && type == HDLightType.Area)
			{
				this.areaShadowAtlas.RegisterTransformCacheSlot(lightData);
			}
			if (type == HDLightType.Directional)
			{
				this.m_CachedDirectionalAngles = lightData.transform.eulerAngles;
			}
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x0004D890 File Offset: 0x0004BA90
		internal void RemoveTransformFromCache(HDAdditionalLightData lightData)
		{
			HDLightType type = lightData.type;
			if (type == HDLightType.Spot || type == HDLightType.Point)
			{
				this.punctualShadowAtlas.RemoveTransformFromCache(lightData);
			}
			if (ShaderConfig.s_AreaLights == 1 && type == HDLightType.Area)
			{
				this.areaShadowAtlas.RemoveTransformFromCache(lightData);
			}
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x0004D8CF File Offset: 0x0004BACF
		internal void AssignSlotsInAtlases()
		{
			this.punctualShadowAtlas.AssignOffsetsInAtlas(this.m_InitParams);
			if (ShaderConfig.s_AreaLights == 1)
			{
				this.areaShadowAtlas.AssignOffsetsInAtlas(this.m_InitParams);
			}
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x0004D8FC File Offset: 0x0004BAFC
		internal bool NeedRenderingDueToTransformChange(HDAdditionalLightData lightData, HDLightType lightType)
		{
			if (!lightData.updateUponLightMovement)
			{
				return false;
			}
			if (lightType == HDLightType.Directional)
			{
				float cachedShadowAngleUpdateThreshold = lightData.cachedShadowAngleUpdateThreshold;
				Vector3 vector = this.m_CachedDirectionalAngles - lightData.transform.eulerAngles;
				bool flag = Mathf.Abs(vector.x) > cachedShadowAngleUpdateThreshold || Mathf.Abs(vector.y) > cachedShadowAngleUpdateThreshold || Mathf.Abs(vector.z) > cachedShadowAngleUpdateThreshold;
				if (flag)
				{
					this.m_CachedDirectionalAngles = lightData.transform.eulerAngles;
				}
				return flag;
			}
			if (lightType == HDLightType.Area)
			{
				return this.areaShadowAtlas.NeedRenderingDueToTransformChange(lightData, lightType);
			}
			return this.punctualShadowAtlas.NeedRenderingDueToTransformChange(lightData, lightType);
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x0004D999 File Offset: 0x0004BB99
		internal bool ShadowIsPendingUpdate(int shadowIdx, ShadowMapType shadowMapType)
		{
			if (shadowMapType == ShadowMapType.PunctualAtlas)
			{
				return this.punctualShadowAtlas.ShadowIsPendingRendering(shadowIdx);
			}
			if (shadowMapType == ShadowMapType.AreaLightAtlas)
			{
				return this.areaShadowAtlas.ShadowIsPendingRendering(shadowIdx);
			}
			return shadowMapType == ShadowMapType.CascadedDirectional && this.m_DirectionalShadowPendingUpdate[shadowIdx];
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x0004D9CA File Offset: 0x0004BBCA
		internal void MarkShadowAsRendered(int shadowIdx, ShadowMapType shadowMapType)
		{
			if (shadowMapType == ShadowMapType.PunctualAtlas)
			{
				this.punctualShadowAtlas.MarkAsRendered(shadowIdx);
			}
			if (shadowMapType == ShadowMapType.AreaLightAtlas)
			{
				this.areaShadowAtlas.MarkAsRendered(shadowIdx);
			}
			if (shadowMapType == ShadowMapType.CascadedDirectional)
			{
				this.m_DirectionalShadowPendingUpdate[shadowIdx] = false;
				this.m_DirectionalShadowHasRendered[shadowIdx] = true;
			}
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x0004DA01 File Offset: 0x0004BC01
		internal void UpdateResolutionRequest(ref HDShadowResolutionRequest request, int shadowIdx, ShadowMapType shadowMapType)
		{
			if (shadowMapType == ShadowMapType.PunctualAtlas)
			{
				this.punctualShadowAtlas.UpdateResolutionRequest(ref request, shadowIdx);
				return;
			}
			if (shadowMapType == ShadowMapType.AreaLightAtlas)
			{
				this.areaShadowAtlas.UpdateResolutionRequest(ref request, shadowIdx);
				return;
			}
			if (shadowMapType == ShadowMapType.CascadedDirectional)
			{
				request.cachedAtlasViewport = request.dynamicAtlasViewport;
			}
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x0004DA38 File Offset: 0x0004BC38
		internal void UpdateDebugSettings(LightingDebugSettings lightingDebugSettings)
		{
			this.punctualShadowAtlas.UpdateDebugSettings(lightingDebugSettings);
			if (ShaderConfig.s_AreaLights == 1)
			{
				this.areaShadowAtlas.UpdateDebugSettings(lightingDebugSettings);
			}
			if (this.m_AllowDirectionalMixedCached)
			{
				this.directionalLightAtlas.UpdateDebugSettings(lightingDebugSettings);
			}
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x0004DA70 File Offset: 0x0004BC70
		internal void ScheduleShadowUpdate(HDAdditionalLightData light)
		{
			HDLightType type = light.type;
			if (type == HDLightType.Point || type == HDLightType.Spot)
			{
				this.punctualShadowAtlas.ScheduleShadowUpdate(light);
				return;
			}
			if (type == HDLightType.Area)
			{
				this.areaShadowAtlas.ScheduleShadowUpdate(light);
				return;
			}
			if (type == HDLightType.Directional)
			{
				this.MarkAllDirectionalShadowsForUpdate();
			}
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x0004DAB4 File Offset: 0x0004BCB4
		internal void ScheduleShadowUpdate(HDAdditionalLightData light, int subShadowIndex)
		{
			HDLightType type = light.type;
			if (type == HDLightType.Spot)
			{
				this.punctualShadowAtlas.ScheduleShadowUpdate(light);
			}
			if (type == HDLightType.Area)
			{
				this.areaShadowAtlas.ScheduleShadowUpdate(light);
			}
			if (type == HDLightType.Point)
			{
				this.punctualShadowAtlas.ScheduleShadowUpdate(light.lightIdxForCachedShadows + subShadowIndex);
			}
			if (type == HDLightType.Directional)
			{
				this.m_DirectionalShadowPendingUpdate[subShadowIndex] = true;
			}
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x0004DB09 File Offset: 0x0004BD09
		internal bool LightIsPendingPlacement(HDAdditionalLightData light, ShadowMapType shadowMapType)
		{
			if (shadowMapType == ShadowMapType.PunctualAtlas)
			{
				return this.punctualShadowAtlas.LightIsPendingPlacement(light);
			}
			return shadowMapType == ShadowMapType.AreaLightAtlas && this.areaShadowAtlas.LightIsPendingPlacement(light);
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x0004DB2E File Offset: 0x0004BD2E
		internal void ClearShadowRequests()
		{
			this.punctualShadowAtlas.Clear();
			if (ShaderConfig.s_AreaLights == 1)
			{
				this.areaShadowAtlas.Clear();
			}
			if (this.m_AllowDirectionalMixedCached)
			{
				this.directionalLightAtlas.Clear();
			}
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x0004DB61 File Offset: 0x0004BD61
		internal void Cleanup(RenderGraph renderGraph)
		{
			if (this.m_AllowDirectionalMixedCached)
			{
				this.directionalLightAtlas.Release(renderGraph);
			}
			this.punctualShadowAtlas.Release(renderGraph);
			if (ShaderConfig.s_AreaLights == 1)
			{
				this.areaShadowAtlas.Release(renderGraph);
			}
		}

		// Token: 0x04000872 RID: 2162
		private static HDCachedShadowManager s_Instance = new HDCachedShadowManager();

		// Token: 0x04000873 RID: 2163
		private const int m_MaxShadowCascades = 4;

		// Token: 0x04000874 RID: 2164
		private bool[] m_DirectionalShadowPendingUpdate = new bool[4];

		// Token: 0x04000875 RID: 2165
		private bool[] m_DirectionalShadowHasRendered = new bool[4];

		// Token: 0x04000876 RID: 2166
		private Vector3 m_CachedDirectionalForward;

		// Token: 0x04000877 RID: 2167
		private Vector3 m_CachedDirectionalAngles;

		// Token: 0x04000878 RID: 2168
		private bool m_AllowDirectionalMixedCached;

		// Token: 0x04000879 RID: 2169
		internal const int k_MinSlotSize = 64;

		// Token: 0x0400087A RID: 2170
		private ValueTuple<int, int>[] m_TempFilled = new ValueTuple<int, int>[6];

		// Token: 0x0400087B RID: 2171
		internal HDCachedShadowAtlas punctualShadowAtlas;

		// Token: 0x0400087C RID: 2172
		internal HDCachedShadowAtlas areaShadowAtlas;

		// Token: 0x0400087D RID: 2173
		internal HDShadowAtlas directionalLightAtlas;

		// Token: 0x0400087E RID: 2174
		private int m_DirectionalLightCacheSize = 1;

		// Token: 0x0400087F RID: 2175
		private HDShadowInitParameters m_InitParams;
	}
}
