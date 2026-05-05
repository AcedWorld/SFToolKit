using System;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001D8 RID: 472
	internal class CloudLayerRenderer : CloudRenderer
	{
		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000E57 RID: 3671 RVA: 0x000720FE File Offset: 0x000702FE
		public RTHandle cloudTexture
		{
			get
			{
				return this.m_PrecomputedData.cloudTextureRT;
			}
		}

		// Token: 0x06000E59 RID: 3673 RVA: 0x0007212C File Offset: 0x0007032C
		public override void Build()
		{
			HDRenderPipelineGlobalSettings instance = HDRenderPipelineGlobalSettings.instance;
			this.m_CloudLayerMaterial = CoreUtils.CreateEngineMaterial(instance.renderPipelineResources.shaders.cloudLayerPS);
			CloudLayerRenderer.s_BakeCloudTextureCS = instance.renderPipelineResources.shaders.bakeCloudTextureCS;
			CloudLayerRenderer.s_BakeCloudTextureKernel = CloudLayerRenderer.s_BakeCloudTextureCS.FindKernel("BakeCloudTexture");
			CloudLayerRenderer.s_BakeCloudShadowsCS = instance.renderPipelineResources.shaders.bakeCloudShadowsCS;
			CloudLayerRenderer.s_BakeCloudShadowsKernel = CloudLayerRenderer.s_BakeCloudShadowsCS.FindKernel("BakeCloudShadows");
		}

		// Token: 0x06000E5A RID: 3674 RVA: 0x000721AC File Offset: 0x000703AC
		public override void Cleanup()
		{
			CoreUtils.Destroy(this.m_CloudLayerMaterial);
			if (this.m_PrecomputedData != null)
			{
				CloudLayerRenderer.s_PrecomputationCache.Release(this.m_LastPrecomputationParamHash);
				this.m_LastPrecomputationParamHash = 0;
				this.m_PrecomputedData = null;
			}
		}

		// Token: 0x06000E5B RID: 3675 RVA: 0x000721E0 File Offset: 0x000703E0
		private bool UpdateCache(CloudLayer cloudLayer, Light sunLight)
		{
			int bakingHashCode = cloudLayer.GetBakingHashCode(sunLight);
			if (bakingHashCode != this.m_LastPrecomputationParamHash)
			{
				CloudLayerRenderer.s_PrecomputationCache.Release(this.m_LastPrecomputationParamHash);
				this.m_PrecomputedData = CloudLayerRenderer.s_PrecomputationCache.Get(cloudLayer, bakingHashCode);
				this.m_LastPrecomputationParamHash = bakingHashCode;
				return true;
			}
			return false;
		}

		// Token: 0x06000E5C RID: 3676 RVA: 0x0007222A File Offset: 0x0007042A
		protected override bool Update(BuiltinSkyParameters builtinParams)
		{
			return this.UpdateCache(builtinParams.cloudSettings as CloudLayer, builtinParams.sunLight);
		}

		// Token: 0x06000E5D RID: 3677 RVA: 0x00072244 File Offset: 0x00070444
		public override bool GetSunLightCookieParameters(CloudSettings settings, ref CookieParameters cookieParams)
		{
			CloudLayer cloudLayer = (CloudLayer)settings;
			if (cloudLayer.CastShadows)
			{
				if (this.m_PrecomputedData == null || this.m_PrecomputedData.cloudShadowsRT == null)
				{
					this.UpdateCache(cloudLayer, HDRenderPipeline.currentPipeline.GetMainLight());
				}
				cookieParams.texture = this.m_PrecomputedData.cloudShadowsRT;
				cookieParams.size = new Vector2(cloudLayer.shadowSize.value, cloudLayer.shadowSize.value);
				return true;
			}
			return false;
		}

		// Token: 0x06000E5E RID: 3678 RVA: 0x000722C1 File Offset: 0x000704C1
		public override void RenderSunLightCookie(BuiltinSunCookieParameters builtinParams)
		{
			this.m_PrecomputedData.BakeCloudShadows((CloudLayer)builtinParams.cloudSettings, builtinParams.sunLight, builtinParams.hdCamera, builtinParams.commandBuffer);
		}

		// Token: 0x06000E5F RID: 3679 RVA: 0x000722EC File Offset: 0x000704EC
		public override void RenderClouds(BuiltinSkyParameters builtinParams, bool renderForCubemap)
		{
			HDCamera hdCamera = builtinParams.hdCamera;
			CommandBuffer commandBuffer = builtinParams.commandBuffer;
			CloudLayer cloudLayer = builtinParams.cloudSettings as CloudLayer;
			if (cloudLayer.opacity.value == 0f)
			{
				return;
			}
			float num = hdCamera.animateMaterials ? (hdCamera.time - this.lastTime) : 0f;
			this.lastTime = hdCamera.time;
			if (!hdCamera.animateMaterials)
			{
				cloudLayer.layerA.scrollFactor = (cloudLayer.layerB.scrollFactor = 0f);
			}
			this.m_PrecomputedData.InitIfNeeded(cloudLayer, builtinParams.sunLight, builtinParams.commandBuffer);
			this.m_CloudLayerMaterial.SetTexture(CloudLayerRenderer._CloudTexture, this.m_PrecomputedData.cloudTextureRT);
			Vector4 renderingParameters = cloudLayer.layerA.GetRenderingParameters(hdCamera);
			Vector4 renderingParameters2 = cloudLayer.layerB.GetRenderingParameters(hdCamera);
			renderingParameters.w = (float)(cloudLayer.upperHemisphereOnly.value ? 1 : 0);
			renderingParameters2.w = cloudLayer.opacity.value;
			CloudLayerRenderer.s_VectorArray[0] = renderingParameters;
			CloudLayerRenderer.s_VectorArray[1] = renderingParameters2;
			this.m_CloudLayerMaterial.SetVectorArray(HDShaderIDs._FlowmapParam, CloudLayerRenderer.s_VectorArray);
			if (cloudLayer.layerA.distortionMode.value != CloudDistortionMode.None)
			{
				cloudLayer.layerA.scrollFactor += cloudLayer.layerA.scrollSpeed.GetValue(hdCamera) * num * 0.277778f;
				if (cloudLayer.layerA.distortionMode.value == CloudDistortionMode.Flowmap)
				{
					this.m_CloudLayerMaterial.SetTexture(CloudLayerRenderer._FlowmapA, cloudLayer.layerA.flowmap.value);
				}
			}
			if (cloudLayer.layerB.distortionMode.value != CloudDistortionMode.None && cloudLayer.layers.value == CloudMapMode.Double)
			{
				cloudLayer.layerB.scrollFactor += cloudLayer.layerB.scrollSpeed.GetValue(hdCamera) * num * 0.277778f;
				if (cloudLayer.layerB.distortionMode.value == CloudDistortionMode.Flowmap)
				{
					this.m_CloudLayerMaterial.SetTexture(CloudLayerRenderer._FlowmapB, cloudLayer.layerB.flowmap.value);
				}
			}
			Color color = Color.black;
			if (builtinParams.sunLight != null)
			{
				this.m_CloudLayerMaterial.SetVector(HDShaderIDs._SunDirection, -builtinParams.sunLight.transform.forward);
				Light component = builtinParams.sunLight.GetComponent<Light>();
				HDAdditionalLightData component2 = builtinParams.sunLight.GetComponent<HDAdditionalLightData>();
				color = component.color.linear * component.intensity;
				if (component2.useColorTemperature)
				{
					color *= Mathf.CorrelatedColorTemperatureToRGB(component.colorTemperature);
				}
			}
			CloudLayerRenderer.s_VectorArray[0] = cloudLayer.layerA.Color * color;
			CloudLayerRenderer.s_VectorArray[1] = cloudLayer.layerB.Color * color;
			CloudLayerRenderer.s_VectorArray[0].w = cloudLayer.layerA.altitude.value;
			CloudLayerRenderer.s_VectorArray[1].w = cloudLayer.layerB.altitude.value;
			this.m_CloudLayerMaterial.SetVectorArray(HDShaderIDs._Params1, CloudLayerRenderer.s_VectorArray);
			Vector4 value = new Vector4(cloudLayer.layerA.ambientProbeDimmer.value, cloudLayer.layerB.ambientProbeDimmer.value, 0f, 0f);
			this.m_CloudLayerMaterial.SetVector(HDShaderIDs._Params2, value);
			this.m_CloudLayerMaterial.SetBuffer(CloudLayerRenderer._AmbientProbeBuffer, builtinParams.cloudAmbientProbe);
			CloudDistortionMode value2 = cloudLayer.layerA.distortionMode.value;
			CoreUtils.SetKeyword(this.m_CloudLayerMaterial, "LAYER1_STATIC", value2 == CloudDistortionMode.None);
			CoreUtils.SetKeyword(this.m_CloudLayerMaterial, "LAYER1_PROCEDURAL", value2 == CloudDistortionMode.Procedural);
			CoreUtils.SetKeyword(this.m_CloudLayerMaterial, "LAYER1_FLOWMAP", value2 == CloudDistortionMode.Flowmap);
			bool flag = cloudLayer.layers.value == CloudMapMode.Double;
			CloudDistortionMode value3 = cloudLayer.layerB.distortionMode.value;
			CoreUtils.SetKeyword(this.m_CloudLayerMaterial, "LAYER2_OFF", !flag);
			CoreUtils.SetKeyword(this.m_CloudLayerMaterial, "LAYER2_STATIC", flag && value3 == CloudDistortionMode.None);
			CoreUtils.SetKeyword(this.m_CloudLayerMaterial, "LAYER2_PROCEDURAL", flag && value3 == CloudDistortionMode.Procedural);
			CoreUtils.SetKeyword(this.m_CloudLayerMaterial, "LAYER2_FLOWMAP", flag && value3 == CloudDistortionMode.Flowmap);
			VisualEnvironment component3 = hdCamera.volumeStack.GetComponent<VisualEnvironment>();
			CoreUtils.SetKeyword(this.m_CloudLayerMaterial, "PHYSICALLY_BASED_SUN", component3.skyType.value == 4);
			this.m_PropertyBlock.SetMatrix(HDShaderIDs._PixelCoordToViewDirWS, builtinParams.pixelCoordToViewDirMatrix);
			if (renderForCubemap)
			{
				CoreUtils.SetRenderTarget(commandBuffer, builtinParams.colorBuffer, ClearFlag.None, 0, builtinParams.cubemapFace, -1);
				CoreUtils.DrawFullScreen(commandBuffer, this.m_CloudLayerMaterial, this.m_PropertyBlock, 0);
				return;
			}
			CoreUtils.SetKeyword(this.m_CloudLayerMaterial, "CLOUD_RENDER_OPACITY_MRT", builtinParams.cloudOpacity != null);
			if (builtinParams.depthBuffer == BuiltinSkyParameters.nullRT)
			{
				if (builtinParams.cloudOpacity == null)
				{
					CoreUtils.SetRenderTarget(commandBuffer, builtinParams.colorBuffer, ClearFlag.None, 0, CubemapFace.Unknown, -1);
				}
				else
				{
					RenderTargetIdentifier[] colorBuffers = new RenderTargetIdentifier[]
					{
						builtinParams.colorBuffer,
						builtinParams.cloudOpacity
					};
					CoreUtils.SetRenderTarget(commandBuffer, colorBuffers, null);
				}
			}
			else if (builtinParams.cloudOpacity == null)
			{
				CoreUtils.SetRenderTarget(commandBuffer, builtinParams.colorBuffer, builtinParams.depthBuffer, 0, CubemapFace.Unknown, -1);
			}
			else
			{
				this.mrtToRenderCloudOcclusion[0] = builtinParams.colorBuffer;
				this.mrtToRenderCloudOcclusion[1] = builtinParams.cloudOpacity;
				CoreUtils.SetRenderTarget(commandBuffer, this.mrtToRenderCloudOcclusion, builtinParams.depthBuffer);
			}
			CoreUtils.DrawFullScreen(commandBuffer, this.m_CloudLayerMaterial, this.m_PropertyBlock, 1);
		}

		// Token: 0x040016A5 RID: 5797
		private Material m_CloudLayerMaterial;

		// Token: 0x040016A6 RID: 5798
		private MaterialPropertyBlock m_PropertyBlock = new MaterialPropertyBlock();

		// Token: 0x040016A7 RID: 5799
		private float lastTime;

		// Token: 0x040016A8 RID: 5800
		private int m_LastPrecomputationParamHash;

		// Token: 0x040016A9 RID: 5801
		private static readonly int _CloudTexture = Shader.PropertyToID("_CloudTexture");

		// Token: 0x040016AA RID: 5802
		private static readonly int _CloudShadows = Shader.PropertyToID("_CloudShadows");

		// Token: 0x040016AB RID: 5803
		private static readonly int _FlowmapA = Shader.PropertyToID("_FlowmapA");

		// Token: 0x040016AC RID: 5804
		private static readonly int _FlowmapB = Shader.PropertyToID("_FlowmapB");

		// Token: 0x040016AD RID: 5805
		private static readonly int _CloudMapA = Shader.PropertyToID("_CloudMapA");

		// Token: 0x040016AE RID: 5806
		private static readonly int _CloudMapB = Shader.PropertyToID("_CloudMapB");

		// Token: 0x040016AF RID: 5807
		private static readonly int _AmbientProbeBuffer = Shader.PropertyToID("_AmbientProbeBuffer");

		// Token: 0x040016B0 RID: 5808
		private static ComputeShader s_BakeCloudTextureCS;

		// Token: 0x040016B1 RID: 5809
		private static ComputeShader s_BakeCloudShadowsCS;

		// Token: 0x040016B2 RID: 5810
		private static int s_BakeCloudTextureKernel;

		// Token: 0x040016B3 RID: 5811
		private static int s_BakeCloudShadowsKernel;

		// Token: 0x040016B4 RID: 5812
		private static readonly Vector4[] s_VectorArray = new Vector4[2];

		// Token: 0x040016B5 RID: 5813
		public RTHandle fullscreenOpacity;

		// Token: 0x040016B6 RID: 5814
		public RenderTargetIdentifier[] mrtToRenderCloudOcclusion = new RenderTargetIdentifier[2];

		// Token: 0x040016B7 RID: 5815
		private static CloudLayerRenderer.PrecomputationCache s_PrecomputationCache = new CloudLayerRenderer.PrecomputationCache();

		// Token: 0x040016B8 RID: 5816
		private CloudLayerRenderer.PrecomputationData m_PrecomputedData;

		// Token: 0x02000427 RID: 1063
		private class PrecomputationCache
		{
			// Token: 0x0600140E RID: 5134 RVA: 0x00097E08 File Offset: 0x00096008
			public CloudLayerRenderer.PrecomputationData Get(CloudLayer cloudLayer, int currentHash)
			{
				CloudLayerRenderer.PrecomputationCache.RefCountedData refCountedData;
				if (this.m_CachedData.TryGetValue(currentHash, out refCountedData))
				{
					refCountedData.refCount++;
					return refCountedData.data;
				}
				refCountedData = this.m_DataPool.Get();
				refCountedData.refCount = 1;
				refCountedData.data.Allocate(cloudLayer);
				this.m_CachedData.Add(currentHash, refCountedData);
				return refCountedData.data;
			}

			// Token: 0x0600140F RID: 5135 RVA: 0x00097E6C File Offset: 0x0009606C
			public void Release(int hash)
			{
				CloudLayerRenderer.PrecomputationCache.RefCountedData refCountedData;
				if (this.m_CachedData.TryGetValue(hash, out refCountedData))
				{
					refCountedData.refCount--;
					if (refCountedData.refCount == 0)
					{
						refCountedData.data.Release();
						this.m_CachedData.Remove(hash);
						this.m_DataPool.Release(refCountedData);
					}
				}
			}

			// Token: 0x04002914 RID: 10516
			private ObjectPool<CloudLayerRenderer.PrecomputationCache.RefCountedData> m_DataPool = new ObjectPool<CloudLayerRenderer.PrecomputationCache.RefCountedData>(null, null, true);

			// Token: 0x04002915 RID: 10517
			private Dictionary<int, CloudLayerRenderer.PrecomputationCache.RefCountedData> m_CachedData = new Dictionary<int, CloudLayerRenderer.PrecomputationCache.RefCountedData>();

			// Token: 0x0200047B RID: 1147
			private class RefCountedData
			{
				// Token: 0x04002A17 RID: 10775
				public int refCount;

				// Token: 0x04002A18 RID: 10776
				public CloudLayerRenderer.PrecomputationData data = new CloudLayerRenderer.PrecomputationData();
			}
		}

		// Token: 0x02000428 RID: 1064
		private class PrecomputationData
		{
			// Token: 0x06001411 RID: 5137 RVA: 0x00097EE4 File Offset: 0x000960E4
			public void Allocate(CloudLayer cloudLayer)
			{
				this.initialized = false;
				this.cloudTextureWidth = (int)cloudLayer.resolution.value;
				this.cloudTextureHeight = (cloudLayer.upperHemisphereOnly.value ? (this.cloudTextureWidth / 2) : this.cloudTextureWidth);
				if (!CloudLayerRenderer.PrecomputationData.cloudTextureCache.TryGet(this.cloudTextureWidth, this.cloudTextureHeight, ref this.cloudTextureRT))
				{
					this.cloudTextureRT = RTHandles.Alloc(this.cloudTextureWidth, this.cloudTextureHeight, TextureWrapMode.Repeat, TextureWrapMode.Clamp, TextureWrapMode.Repeat, cloudLayer.NumLayers, DepthBits.None, GraphicsFormat.R16G16_SFloat, FilterMode.Bilinear, TextureDimension.Tex2DArray, true, false, true, false, 1, 0f, MSAASamples.None, false, false, RenderTextureMemoryless.None, VRTextureUsage.None, "Cloud Texture");
				}
				this.cloudShadowsRT = null;
				this.cloudShadowsResolution = (int)cloudLayer.shadowResolution.value;
				if (cloudLayer.CastShadows && !CloudLayerRenderer.PrecomputationData.cloudShadowsCache.TryGet(this.cloudShadowsResolution, this.cloudShadowsResolution, ref this.cloudShadowsRT))
				{
					this.cloudShadowsRT = RTHandles.Alloc(this.cloudShadowsResolution, this.cloudShadowsResolution, 1, DepthBits.None, GraphicsFormat.B10G11R11_UFloatPack32, FilterMode.Bilinear, TextureWrapMode.Repeat, TextureDimension.Tex2D, true, false, true, false, 1, 0f, MSAASamples.None, false, false, RenderTextureMemoryless.None, VRTextureUsage.None, "Cloud Shadows");
				}
			}

			// Token: 0x06001412 RID: 5138 RVA: 0x00097FF3 File Offset: 0x000961F3
			public void Release()
			{
				CloudLayerRenderer.PrecomputationData.cloudTextureCache.Cache(this.cloudTextureHeight, this.cloudTextureHeight, this.cloudTextureRT);
				CloudLayerRenderer.PrecomputationData.cloudShadowsCache.Cache(this.cloudShadowsResolution, this.cloudShadowsResolution, this.cloudShadowsRT);
			}

			// Token: 0x06001413 RID: 5139 RVA: 0x00098030 File Offset: 0x00096230
			public bool InitIfNeeded(CloudLayer cloudLayer, Light sunLight, CommandBuffer cmd)
			{
				if (this.initialized)
				{
					return false;
				}
				Vector4 val = (sunLight == null) ? Vector3.zero : (-sunLight.transform.forward);
				val.w = (cloudLayer.upperHemisphereOnly.value ? 1f : 0f);
				cmd.SetComputeVectorParam(CloudLayerRenderer.s_BakeCloudTextureCS, HDShaderIDs._Params, val);
				cmd.SetComputeTextureParam(CloudLayerRenderer.s_BakeCloudTextureCS, CloudLayerRenderer.s_BakeCloudTextureKernel, CloudLayerRenderer._CloudTexture, this.cloudTextureRT);
				cmd.SetComputeTextureParam(CloudLayerRenderer.s_BakeCloudTextureCS, CloudLayerRenderer.s_BakeCloudTextureKernel, CloudLayerRenderer._CloudMapA, cloudLayer.layerA.cloudMap.value);
				ValueTuple<Vector4, Vector4> bakingParameters = cloudLayer.layerA.GetBakingParameters();
				if (cloudLayer.NumLayers == 1)
				{
					CloudLayerRenderer.s_BakeCloudTextureCS.DisableKeyword("USE_SECOND_CLOUD_LAYER");
					cmd.SetComputeVectorParam(CloudLayerRenderer.s_BakeCloudTextureCS, HDShaderIDs._Params1, bakingParameters.Item1);
					cmd.SetComputeVectorParam(CloudLayerRenderer.s_BakeCloudTextureCS, HDShaderIDs._Params2, bakingParameters.Item2);
				}
				else
				{
					cmd.SetComputeTextureParam(CloudLayerRenderer.s_BakeCloudTextureCS, CloudLayerRenderer.s_BakeCloudTextureKernel, CloudLayerRenderer._CloudMapB, cloudLayer.layerB.cloudMap.value);
					ValueTuple<Vector4, Vector4> bakingParameters2 = cloudLayer.layerB.GetBakingParameters();
					CloudLayerRenderer.s_BakeCloudTextureCS.EnableKeyword("USE_SECOND_CLOUD_LAYER");
					CloudLayerRenderer.s_VectorArray[0] = bakingParameters.Item1;
					CloudLayerRenderer.s_VectorArray[1] = bakingParameters2.Item1;
					cmd.SetComputeVectorArrayParam(CloudLayerRenderer.s_BakeCloudTextureCS, HDShaderIDs._Params1, CloudLayerRenderer.s_VectorArray);
					CloudLayerRenderer.s_VectorArray[0] = bakingParameters.Item2;
					CloudLayerRenderer.s_VectorArray[1] = bakingParameters2.Item2;
					cmd.SetComputeVectorArrayParam(CloudLayerRenderer.s_BakeCloudTextureCS, HDShaderIDs._Params2, CloudLayerRenderer.s_VectorArray);
				}
				cmd.SetComputeFloatParam(CloudLayerRenderer.s_BakeCloudTextureCS, HDShaderIDs._Resolution, 1f / (float)this.cloudTextureWidth);
				int threadGroupsX = (this.cloudTextureWidth + 7) / 8;
				int threadGroupsY = (this.cloudTextureHeight + 7) / 8;
				cmd.DispatchCompute(CloudLayerRenderer.s_BakeCloudTextureCS, CloudLayerRenderer.s_BakeCloudTextureKernel, threadGroupsX, threadGroupsY, 1);
				this.initialized = true;
				return true;
			}

			// Token: 0x06001414 RID: 5140 RVA: 0x00098244 File Offset: 0x00096444
			public void BakeCloudShadows(CloudLayer cloudLayer, Light sunLight, HDCamera hdCamera, CommandBuffer cmd)
			{
				this.InitIfNeeded(cloudLayer, sunLight, cmd);
				Vector4 val = cloudLayer.shadowTint.value;
				val.w = cloudLayer.shadowMultiplier.value * 8f;
				cmd.SetComputeFloatParam(CloudLayerRenderer.s_BakeCloudShadowsCS, HDShaderIDs._Resolution, 1f / (float)this.cloudShadowsResolution);
				cmd.SetComputeVectorParam(CloudLayerRenderer.s_BakeCloudShadowsCS, HDShaderIDs._Params, val);
				cmd.SetComputeTextureParam(CloudLayerRenderer.s_BakeCloudShadowsCS, CloudLayerRenderer.s_BakeCloudShadowsKernel, CloudLayerRenderer._CloudTexture, this.cloudTextureRT);
				cmd.SetComputeTextureParam(CloudLayerRenderer.s_BakeCloudShadowsCS, CloudLayerRenderer.s_BakeCloudShadowsKernel, CloudLayerRenderer._CloudShadows, this.cloudShadowsRT);
				Vector4 renderingParameters = cloudLayer.layerA.GetRenderingParameters(hdCamera);
				Vector4 renderingParameters2 = cloudLayer.layerB.GetRenderingParameters(hdCamera);
				renderingParameters.w = (float)(cloudLayer.upperHemisphereOnly.value ? 1 : 0);
				renderingParameters2.w = cloudLayer.opacity.value;
				CloudLayerRenderer.s_VectorArray[0] = renderingParameters;
				CloudLayerRenderer.s_VectorArray[1] = renderingParameters2;
				cmd.SetComputeVectorArrayParam(CloudLayerRenderer.s_BakeCloudShadowsCS, HDShaderIDs._FlowmapParam, CloudLayerRenderer.s_VectorArray);
				CloudLayerRenderer.s_VectorArray[0] = sunLight.transform.right;
				CloudLayerRenderer.s_VectorArray[1] = sunLight.transform.up;
				CloudLayerRenderer.s_VectorArray[0].w = cloudLayer.layerA.altitude.value;
				CloudLayerRenderer.s_VectorArray[1].w = cloudLayer.layerB.altitude.value;
				cmd.SetComputeVectorArrayParam(CloudLayerRenderer.s_BakeCloudShadowsCS, HDShaderIDs._Params1, CloudLayerRenderer.s_VectorArray);
				cmd.SetComputeVectorParam(CloudLayerRenderer.s_BakeCloudShadowsCS, HDShaderIDs._SunDirection, -sunLight.transform.forward);
				cmd.SetComputeTextureParam(CloudLayerRenderer.s_BakeCloudShadowsCS, CloudLayerRenderer.s_BakeCloudShadowsKernel, CloudLayerRenderer._FlowmapA, cloudLayer.layerA.flowmap.value);
				cmd.SetComputeTextureParam(CloudLayerRenderer.s_BakeCloudShadowsCS, CloudLayerRenderer.s_BakeCloudShadowsKernel, CloudLayerRenderer._FlowmapB, cloudLayer.layerB.flowmap.value);
				bool value = cloudLayer.layerA.castShadows.value;
				CloudDistortionMode value2 = cloudLayer.layerA.distortionMode.value;
				CoreUtils.SetKeyword(CloudLayerRenderer.s_BakeCloudShadowsCS, "LAYER1_OFF", !value);
				CoreUtils.SetKeyword(CloudLayerRenderer.s_BakeCloudShadowsCS, "LAYER1_STATIC", value && value2 == CloudDistortionMode.None);
				CoreUtils.SetKeyword(CloudLayerRenderer.s_BakeCloudShadowsCS, "LAYER1_PROCEDURAL", value && value2 == CloudDistortionMode.Procedural);
				CoreUtils.SetKeyword(CloudLayerRenderer.s_BakeCloudShadowsCS, "LAYER1_FLOWMAP", value && value2 == CloudDistortionMode.Flowmap);
				bool flag = cloudLayer.layers.value == CloudMapMode.Double && cloudLayer.layerB.castShadows.value;
				CloudDistortionMode value3 = cloudLayer.layerB.distortionMode.value;
				CoreUtils.SetKeyword(CloudLayerRenderer.s_BakeCloudShadowsCS, "LAYER2_OFF", !flag);
				CoreUtils.SetKeyword(CloudLayerRenderer.s_BakeCloudShadowsCS, "LAYER2_STATIC", flag && value3 == CloudDistortionMode.None);
				CoreUtils.SetKeyword(CloudLayerRenderer.s_BakeCloudShadowsCS, "LAYER2_PROCEDURAL", flag && value3 == CloudDistortionMode.Procedural);
				CoreUtils.SetKeyword(CloudLayerRenderer.s_BakeCloudShadowsCS, "LAYER2_FLOWMAP", flag && value3 == CloudDistortionMode.Flowmap);
				int threadGroupsX = (this.cloudShadowsResolution + 7) / 8;
				int threadGroupsY = (this.cloudShadowsResolution + 7) / 8;
				cmd.DispatchCompute(CloudLayerRenderer.s_BakeCloudShadowsCS, CloudLayerRenderer.s_BakeCloudShadowsKernel, threadGroupsX, threadGroupsY, 1);
				this.cloudShadowsRT.rt.IncrementUpdateCount();
			}

			// Token: 0x04002916 RID: 10518
			private static CloudLayerRenderer.PrecomputationData.TextureCache cloudTextureCache;

			// Token: 0x04002917 RID: 10519
			private static CloudLayerRenderer.PrecomputationData.TextureCache cloudShadowsCache;

			// Token: 0x04002918 RID: 10520
			private bool initialized;

			// Token: 0x04002919 RID: 10521
			private int cloudTextureWidth;

			// Token: 0x0400291A RID: 10522
			private int cloudTextureHeight;

			// Token: 0x0400291B RID: 10523
			private int cloudShadowsResolution;

			// Token: 0x0400291C RID: 10524
			public RTHandle cloudTextureRT;

			// Token: 0x0400291D RID: 10525
			public RTHandle cloudShadowsRT;

			// Token: 0x0200047C RID: 1148
			private struct TextureCache
			{
				// Token: 0x06001488 RID: 5256 RVA: 0x0009A28B File Offset: 0x0009848B
				public bool TryGet(int textureWidth, int textureHeight, ref RTHandle texture)
				{
					if (this.rt == null || textureWidth != this.width || textureHeight != this.height)
					{
						return false;
					}
					texture = this.rt;
					this.rt = null;
					return true;
				}

				// Token: 0x06001489 RID: 5257 RVA: 0x0009A2B9 File Offset: 0x000984B9
				public void Cache(int textureWidth, int textureHeight, RTHandle texture)
				{
					if (texture == null)
					{
						return;
					}
					if (this.rt != null)
					{
						RTHandles.Release(this.rt);
					}
					this.width = textureWidth;
					this.height = textureHeight;
					this.rt = texture;
				}

				// Token: 0x04002A19 RID: 10777
				private int width;

				// Token: 0x04002A1A RID: 10778
				private int height;

				// Token: 0x04002A1B RID: 10779
				private RTHandle rt;
			}
		}
	}
}
