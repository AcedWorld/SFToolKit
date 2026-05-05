using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001EC RID: 492
	internal class SkyManager
	{
		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000EBE RID: 3774 RVA: 0x00074CB2 File Offset: 0x00072EB2
		// (set) Token: 0x06000EBF RID: 3775 RVA: 0x00074CBA File Offset: 0x00072EBA
		public VolumeStack lightingOverrideVolumeStack { get; private set; }

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000EC0 RID: 3776 RVA: 0x00074CC3 File Offset: 0x00072EC3
		// (set) Token: 0x06000EC1 RID: 3777 RVA: 0x00074CCB File Offset: 0x00072ECB
		public LayerMask lightingOverrideLayerMask { get; private set; } = -1;

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000EC2 RID: 3778 RVA: 0x00074CD4 File Offset: 0x00072ED4
		public static Dictionary<int, Type> skyTypesDict
		{
			get
			{
				if (SkyManager.m_SkyTypesDict == null)
				{
					SkyManager.UpdateSkyTypes();
				}
				return SkyManager.m_SkyTypesDict;
			}
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000EC3 RID: 3779 RVA: 0x00074CE7 File Offset: 0x00072EE7
		public static Dictionary<int, Type> cloudTypesDict
		{
			get
			{
				if (SkyManager.m_CloudTypesDict == null)
				{
					SkyManager.UpdateCloudTypes();
				}
				return SkyManager.m_CloudTypesDict;
			}
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000EC4 RID: 3780 RVA: 0x00074CFA File Offset: 0x00072EFA
		public TextureHandle cloudOpacity
		{
			get
			{
				return this.m_CloudOpacity;
			}
		}

		// Token: 0x06000EC6 RID: 3782 RVA: 0x00074D6C File Offset: 0x00072F6C
		~SkyManager()
		{
		}

		// Token: 0x06000EC7 RID: 3783 RVA: 0x00074D94 File Offset: 0x00072F94
		internal static SkySettings GetSkySetting(VolumeStack stack)
		{
			int value = stack.GetComponent<VisualEnvironment>().skyType.value;
			Type type;
			if (SkyManager.skyTypesDict.TryGetValue(value, out type))
			{
				return (SkySettings)stack.GetComponent(type);
			}
			if (value == 2 && SkyManager.logOnce)
			{
				Debug.LogError("You are using the deprecated Procedural Sky in your Scene. You can still use it but, to do so, you must install it separately. To do this, open the Package Manager window and import the 'Procedural Sky' sample from the HDRP package page, then close and re-open your project without saving.");
				SkyManager.logOnce = false;
			}
			return null;
		}

		// Token: 0x06000EC8 RID: 3784 RVA: 0x00074DEC File Offset: 0x00072FEC
		internal static CloudSettings GetCloudSetting(VolumeStack stack)
		{
			int value = stack.GetComponent<VisualEnvironment>().cloudType.value;
			Type type;
			if (SkyManager.cloudTypesDict.TryGetValue(value, out type))
			{
				return (CloudSettings)stack.GetComponent(type);
			}
			return null;
		}

		// Token: 0x06000EC9 RID: 3785 RVA: 0x00074E27 File Offset: 0x00073027
		internal static VolumetricClouds GetVolumetricClouds(VolumeStack stack)
		{
			return stack.GetComponent<VolumetricClouds>();
		}

		// Token: 0x06000ECA RID: 3786 RVA: 0x00074E30 File Offset: 0x00073030
		private static void UpdateSkyTypes()
		{
			if (SkyManager.m_SkyTypesDict == null)
			{
				SkyManager.m_SkyTypesDict = new Dictionary<int, Type>();
				foreach (Type type in from t in CoreUtils.GetAllTypesDerivedFrom<SkySettings>()
				where !t.IsAbstract
				select t)
				{
					object[] customAttributes = type.GetCustomAttributes(typeof(SkyUniqueID), false);
					if (customAttributes.Length == 0)
					{
						Debug.LogWarningFormat("Missing attribute SkyUniqueID on class {0}. Class won't be registered as an available sky.", new object[]
						{
							type
						});
					}
					else
					{
						int uniqueID = ((SkyUniqueID)customAttributes[0]).uniqueID;
						Type type2;
						if (uniqueID == 0)
						{
							Debug.LogWarningFormat("0 is a reserved SkyUniqueID and is used in class {0}. Class won't be registered as an available sky.", new object[]
							{
								type
							});
						}
						else if (SkyManager.m_SkyTypesDict.TryGetValue(uniqueID, out type2))
						{
							Debug.LogWarningFormat("SkyUniqueID {0} used in class {1} is already used in class {2}. Class won't be registered as an available sky.", new object[]
							{
								uniqueID,
								type,
								type2
							});
						}
						else
						{
							SkyManager.m_SkyTypesDict.Add(uniqueID, type);
						}
					}
				}
			}
		}

		// Token: 0x06000ECB RID: 3787 RVA: 0x00074F48 File Offset: 0x00073148
		private static void UpdateCloudTypes()
		{
			if (SkyManager.m_CloudTypesDict == null)
			{
				SkyManager.m_CloudTypesDict = new Dictionary<int, Type>();
				foreach (Type type in from t in CoreUtils.GetAllTypesDerivedFrom<CloudSettings>()
				where !t.IsAbstract
				select t)
				{
					object[] customAttributes = type.GetCustomAttributes(typeof(CloudUniqueID), false);
					if (customAttributes.Length == 0)
					{
						Debug.LogWarningFormat("Missing attribute CloudUniqueID on class {0}. Class won't be registered as an available cloud type.", new object[]
						{
							type
						});
					}
					else
					{
						int uniqueID = ((CloudUniqueID)customAttributes[0]).uniqueID;
						Type type2;
						if (uniqueID == 0)
						{
							Debug.LogWarningFormat("0 is a reserved CloudUniqueID and is used in class {0}. Class won't be registered as an available cloud type.", new object[]
							{
								type
							});
						}
						else if (SkyManager.m_CloudTypesDict.TryGetValue(uniqueID, out type2))
						{
							Debug.LogWarningFormat("CloudUniqueID {0} used in class {1} is already used in class {2}. Class won't be registered as an available cloud type.", new object[]
							{
								uniqueID,
								type,
								type2
							});
						}
						else
						{
							SkyManager.m_CloudTypesDict.Add(uniqueID, type);
						}
					}
				}
			}
		}

		// Token: 0x06000ECC RID: 3788 RVA: 0x00075060 File Offset: 0x00073260
		public void UpdateCurrentSkySettings(HDCamera hdCamera)
		{
			hdCamera.UpdateCurrentSky(this);
		}

		// Token: 0x06000ECD RID: 3789 RVA: 0x0007506C File Offset: 0x0007326C
		private void SetGlobalSkyData(RenderGraph renderGraph, SkyUpdateContext skyContext, BuiltinSkyParameters builtinParameters)
		{
			if (this.IsCachedContextValid(skyContext) && skyContext.skyRenderer != null)
			{
				SkyManager.SetGlobalSkyDataPassData setGlobalSkyDataPassData;
				using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<SkyManager.SetGlobalSkyDataPassData>("SetGlobalSkyData", out setGlobalSkyDataPassData))
				{
					renderGraphBuilder.AllowPassCulling(false);
					builtinParameters.CopyTo(setGlobalSkyDataPassData.builtinParameters);
					setGlobalSkyDataPassData.builtinParameters.skySettings = skyContext.skySettings;
					setGlobalSkyDataPassData.builtinParameters.cloudSettings = skyContext.cloudSettings;
					setGlobalSkyDataPassData.builtinParameters.volumetricClouds = skyContext.volumetricClouds;
					setGlobalSkyDataPassData.skyRenderer = skyContext.skyRenderer;
					renderGraphBuilder.SetRenderFunc<SkyManager.SetGlobalSkyDataPassData>(delegate(SkyManager.SetGlobalSkyDataPassData data, RenderGraphContext ctx)
					{
						data.builtinParameters.commandBuffer = ctx.cmd;
						data.skyRenderer.SetGlobalSkyData(ctx.cmd, data.builtinParameters);
					});
				}
			}
		}

		// Token: 0x06000ECE RID: 3790 RVA: 0x00075138 File Offset: 0x00073338
		public void Build(HDRenderPipelineAsset hdAsset, HDRenderPipelineRuntimeResources defaultResources, IBLFilterBSDF[] iblFilterBSDFArray)
		{
			this.m_LowResolution = 16;
			this.m_Resolution = (int)hdAsset.currentPlatformRenderPipelineSettings.lightLoopSettings.skyReflectionSize;
			this.m_IBLFilterArray = iblFilterBSDFArray;
			this.m_StandardSkyboxMaterial = CoreUtils.CreateEngineMaterial(defaultResources.shaders.skyboxCubemapPS);
			this.m_BlitCubemapMaterial = CoreUtils.CreateEngineMaterial(defaultResources.shaders.blitCubemapPS);
			this.m_OpaqueAtmScatteringMaterial = CoreUtils.CreateEngineMaterial(defaultResources.shaders.opaqueAtmosphericScatteringPS);
			this.m_ComputeAmbientProbeCS = HDRenderPipelineGlobalSettings.instance.renderPipelineResources.shaders.ambientProbeConvolutionCS;
			this.m_ComputeAmbientProbeKernel = this.m_ComputeAmbientProbeCS.FindKernel("AmbientProbeConvolutionDiffuse");
			this.m_ComputeAmbientProbeVolumetricKernel = this.m_ComputeAmbientProbeCS.FindKernel("AmbientProbeConvolutionDiffuseVolumetric");
			this.m_ComputeAmbientProbeCloudsKernel = this.m_ComputeAmbientProbeCS.FindKernel("AmbientProbeConvolutionClouds");
			this.lightingOverrideVolumeStack = VolumeManager.instance.CreateStack();
			this.lightingOverrideLayerMask = hdAsset.currentPlatformRenderPipelineSettings.lightLoopSettings.skyLightingOverrideLayerMask;
			this.m_CubemapScreenSize = new Vector4((float)this.m_Resolution, (float)this.m_Resolution, 1f / (float)this.m_Resolution, 1f / (float)this.m_Resolution);
			this.m_LowResCubemapScreenSize = new Vector4((float)this.m_LowResolution, (float)this.m_LowResolution, 1f / (float)this.m_LowResolution, 1f / (float)this.m_LowResolution);
			for (int i = 0; i < 6; i++)
			{
				Matrix4x4 matrix4x = Matrix4x4.LookAt(Vector3.zero, CoreUtils.lookAtList[i], CoreUtils.upVectorList[i]) * Matrix4x4.Scale(new Vector3(1f, 1f, -1f));
				this.m_FacePixelCoordToViewDirMatrices[i] = HDUtils.ComputePixelCoordToWorldSpaceViewDirectionMatrix(1.5707964f, Vector2.zero, this.m_CubemapScreenSize, matrix4x, true, -1f, false);
				this.m_FacePixelCoordToViewDirMatricesLowRes[i] = HDUtils.ComputePixelCoordToWorldSpaceViewDirectionMatrix(1.5707964f, Vector2.zero, this.m_LowResCubemapScreenSize, matrix4x, true, -1f, false);
				this.m_CameraRelativeViewMatrices[i] = matrix4x;
			}
			this.InitializeBlackCubemapArray();
			if (this.m_BlackAmbientProbeBuffer == null)
			{
				this.m_BlackAmbientProbeBuffer = new ComputeBuffer(7, 16);
				float[] array = new float[28];
				for (int j = 0; j < 28; j++)
				{
					array[j] = 0f;
				}
				this.m_BlackAmbientProbeBuffer.SetData(array);
			}
		}

		// Token: 0x06000ECF RID: 3791 RVA: 0x0007538C File Offset: 0x0007358C
		private void InitializeBlackCubemapArray()
		{
			if (this.m_BlackCubemapArray == null)
			{
				this.m_BlackCubemapArray = new CubemapArray(1, this.m_IBLFilterArray.Length, GraphicsFormat.R8G8B8A8_SRGB, TextureCreationFlags.None)
				{
					hideFlags = HideFlags.HideAndDontSave,
					wrapMode = TextureWrapMode.Repeat,
					wrapModeV = TextureWrapMode.Clamp,
					filterMode = FilterMode.Trilinear,
					anisoLevel = 0,
					name = "BlackCubemapArray"
				};
				Color32[] colors = new Color32[]
				{
					new Color32(0, 0, 0, 0)
				};
				for (int i = 0; i < this.m_IBLFilterArray.Length; i++)
				{
					for (int j = 0; j < 6; j++)
					{
						this.m_BlackCubemapArray.SetPixels32(colors, (CubemapFace)j, i);
					}
				}
				this.m_BlackCubemapArray.Apply();
			}
		}

		// Token: 0x06000ED0 RID: 3792 RVA: 0x00075440 File Offset: 0x00073640
		public void Cleanup()
		{
			CoreUtils.Destroy(this.m_StandardSkyboxMaterial);
			CoreUtils.Destroy(this.m_BlitCubemapMaterial);
			CoreUtils.Destroy(this.m_OpaqueAtmScatteringMaterial);
			CoreUtils.Destroy(this.m_BlackCubemapArray);
			this.m_BlackAmbientProbeBuffer.Release();
			for (int i = 0; i < this.m_CachedSkyContexts.size; i++)
			{
				this.m_CachedSkyContexts[i].Cleanup();
			}
			this.m_StaticLightingSky.Cleanup();
			this.lightingOverrideVolumeStack.Dispose();
		}

		// Token: 0x06000ED1 RID: 3793 RVA: 0x000754C1 File Offset: 0x000736C1
		public bool IsLightingSkyValid(HDCamera hdCamera)
		{
			return hdCamera.lightingSky.IsValid();
		}

		// Token: 0x06000ED2 RID: 3794 RVA: 0x000754CE File Offset: 0x000736CE
		public bool IsVisualSkyValid(HDCamera hdCamera)
		{
			return hdCamera.visualSky.IsValid();
		}

		// Token: 0x06000ED3 RID: 3795 RVA: 0x000754DB File Offset: 0x000736DB
		private SphericalHarmonicsL2 GetAmbientProbe(SkyUpdateContext skyContext)
		{
			if (skyContext.IsValid() && this.IsCachedContextValid(skyContext))
			{
				return this.m_CachedSkyContexts[skyContext.cachedSkyRenderingContextId].renderingContext.ambientProbe;
			}
			return this.m_BlackAmbientProbe;
		}

		// Token: 0x06000ED4 RID: 3796 RVA: 0x00075510 File Offset: 0x00073710
		private ComputeBuffer GetDiffuseAmbientProbeBuffer(SkyUpdateContext skyContext)
		{
			if (skyContext.IsValid() && this.IsCachedContextValid(skyContext))
			{
				return this.m_CachedSkyContexts[skyContext.cachedSkyRenderingContextId].renderingContext.diffuseAmbientProbeBuffer;
			}
			return this.m_BlackAmbientProbeBuffer;
		}

		// Token: 0x06000ED5 RID: 3797 RVA: 0x00075545 File Offset: 0x00073745
		private ComputeBuffer GetVolumetricAmbientProbeBuffer(SkyUpdateContext skyContext)
		{
			if (skyContext.IsValid() && this.IsCachedContextValid(skyContext))
			{
				return this.m_CachedSkyContexts[skyContext.cachedSkyRenderingContextId].renderingContext.volumetricAmbientProbeBuffer;
			}
			return this.m_BlackAmbientProbeBuffer;
		}

		// Token: 0x06000ED6 RID: 3798 RVA: 0x0007557A File Offset: 0x0007377A
		private Texture GetSkyCubemap(SkyUpdateContext skyContext)
		{
			if (skyContext.IsValid() && this.IsCachedContextValid(skyContext))
			{
				return this.m_CachedSkyContexts[skyContext.cachedSkyRenderingContextId].renderingContext.skyboxCubemapRT;
			}
			return CoreUtils.blackCubeTexture;
		}

		// Token: 0x06000ED7 RID: 3799 RVA: 0x000755B3 File Offset: 0x000737B3
		private Texture GetReflectionTexture(SkyUpdateContext skyContext)
		{
			if (skyContext.IsValid() && this.IsCachedContextValid(skyContext))
			{
				return this.m_CachedSkyContexts[skyContext.cachedSkyRenderingContextId].renderingContext.skyboxBSDFCubemapArray;
			}
			return this.m_BlackCubemapArray;
		}

		// Token: 0x06000ED8 RID: 3800 RVA: 0x000755E8 File Offset: 0x000737E8
		public Texture GetSkyReflection(HDCamera hdCamera)
		{
			return this.GetReflectionTexture(hdCamera.lightingSky);
		}

		// Token: 0x06000ED9 RID: 3801 RVA: 0x000755F6 File Offset: 0x000737F6
		private SkyUpdateContext GetLightingSky(HDCamera hdCamera)
		{
			if (hdCamera.skyAmbientMode == SkyAmbientMode.Static || (hdCamera.camera.cameraType == CameraType.Reflection && HDRenderPipeline.currentPipeline.reflectionProbeBaking))
			{
				return this.m_StaticLightingSky;
			}
			return hdCamera.lightingSky;
		}

		// Token: 0x06000EDA RID: 3802 RVA: 0x00075628 File Offset: 0x00073828
		internal SphericalHarmonicsL2 GetAmbientProbe(HDCamera hdCamera)
		{
			if (hdCamera.lightingSky == null && hdCamera.skyAmbientMode == SkyAmbientMode.Dynamic)
			{
				return this.m_BlackAmbientProbe;
			}
			return this.GetAmbientProbe(this.GetLightingSky(hdCamera));
		}

		// Token: 0x06000EDB RID: 3803 RVA: 0x0007564F File Offset: 0x0007384F
		internal ComputeBuffer GetDiffuseAmbientProbeBuffer(HDCamera hdCamera)
		{
			if (hdCamera.lightingSky == null && hdCamera.skyAmbientMode == SkyAmbientMode.Dynamic)
			{
				return this.m_BlackAmbientProbeBuffer;
			}
			if (hdCamera.camera.cameraType == CameraType.Preview)
			{
				return this.m_BlackAmbientProbeBuffer;
			}
			return this.GetDiffuseAmbientProbeBuffer(this.GetLightingSky(hdCamera));
		}

		// Token: 0x06000EDC RID: 3804 RVA: 0x0007568B File Offset: 0x0007388B
		internal ComputeBuffer GetVolumetricAmbientProbeBuffer(HDCamera hdCamera)
		{
			if (hdCamera.lightingSky == null && hdCamera.skyAmbientMode == SkyAmbientMode.Dynamic)
			{
				return this.m_BlackAmbientProbeBuffer;
			}
			return this.GetVolumetricAmbientProbeBuffer(this.GetLightingSky(hdCamera));
		}

		// Token: 0x06000EDD RID: 3805 RVA: 0x000756B4 File Offset: 0x000738B4
		internal bool HasSetValidAmbientProbe(HDCamera hdCamera)
		{
			VisualEnvironment component = hdCamera.volumeStack.GetComponent<VisualEnvironment>();
			return component.skyAmbientMode.value == SkyAmbientMode.Static || component.skyType.value == 0 || (hdCamera.skyAmbientMode == SkyAmbientMode.Dynamic && hdCamera.lightingSky != null && hdCamera.lightingSky.IsValid() && this.IsCachedContextValid(hdCamera.lightingSky) && this.m_CachedSkyContexts[hdCamera.lightingSky.cachedSkyRenderingContextId].renderingContext.ambientProbeIsReady);
		}

		// Token: 0x06000EDE RID: 3806 RVA: 0x0007573C File Offset: 0x0007393C
		internal void SetupAmbientProbe(HDCamera hdCamera)
		{
			RenderSettings.ambientMode = AmbientMode.Custom;
			RenderSettings.ambientProbe = this.GetAmbientProbe(hdCamera);
			if (hdCamera.lightingSky == null && hdCamera.skyAmbientMode == SkyAmbientMode.Dynamic)
			{
				return;
			}
			if (hdCamera.camera.cameraType == CameraType.Preview)
			{
				return;
			}
			bool flag = true;
			this.m_StandardSkyboxMaterial.SetTexture("_Tex", this.GetSkyCubemap((hdCamera.skyAmbientMode > SkyAmbientMode.Static && flag) ? hdCamera.lightingSky : this.m_StaticLightingSky));
			RenderSettings.skybox = this.m_StandardSkyboxMaterial;
			RenderSettings.ambientIntensity = 1f;
			RenderSettings.ambientMode = AmbientMode.Skybox;
			RenderSettings.reflectionIntensity = 1f;
			RenderSettings.customReflectionTexture = null;
		}

		// Token: 0x06000EDF RID: 3807 RVA: 0x000757DC File Offset: 0x000739DC
		private void BlitCubemap(CommandBuffer cmd, Cubemap source, RenderTexture dest)
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			for (int i = 0; i < 6; i++)
			{
				CoreUtils.SetRenderTarget(cmd, dest, ClearFlag.None, 0, (CubemapFace)i, -1);
				materialPropertyBlock.SetTexture("_MainTex", source);
				materialPropertyBlock.SetFloat("_faceIndex", (float)i);
				cmd.DrawProcedural(Matrix4x4.identity, this.m_BlitCubemapMaterial, 0, MeshTopology.Triangles, 3, 1, materialPropertyBlock);
			}
			cmd.GenerateMips(dest);
		}

		// Token: 0x06000EE0 RID: 3808 RVA: 0x00075844 File Offset: 0x00073A44
		private void RenderSkyToCubemap(RenderGraph renderGraph, SkyUpdateContext skyContext, HDCamera hdCamera, TextureHandle cubemap, Matrix4x4[] pixelCoordToViewDir, bool renderBackgroundClouds, HDProfileId profileId)
		{
			SkyManager.RenderSkyToCubemapPassData renderSkyToCubemapPassData;
			using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<SkyManager.RenderSkyToCubemapPassData>("RenderSkyToCubemap", out renderSkyToCubemapPassData, ProfilingSampler.Get<HDProfileId>(profileId)))
			{
				SkyManager.UpdateBuiltinParameters(ref renderSkyToCubemapPassData.builtinParameters, skyContext, hdCamera, this.m_CurrentSunLight, this.m_CurrentDebugDisplaySettings);
				ref CachedSkyContext ptr = ref this.m_CachedSkyContexts[skyContext.cachedSkyRenderingContextId];
				renderSkyToCubemapPassData.builtinParameters.cloudAmbientProbe = ptr.renderingContext.cloudAmbientProbeBuffer;
				renderSkyToCubemapPassData.skyRenderer = skyContext.skyRenderer;
				renderSkyToCubemapPassData.cloudRenderer = (renderBackgroundClouds ? skyContext.cloudRenderer : null);
				renderSkyToCubemapPassData.cameraViewMatrices = this.m_CameraRelativeViewMatrices;
				renderSkyToCubemapPassData.facePixelCoordToViewDirMatrices = pixelCoordToViewDir;
				renderSkyToCubemapPassData.includeSunInBaking = skyContext.skySettings.includeSunInBaking.value;
				renderSkyToCubemapPassData.output = renderGraphBuilder.WriteTexture(cubemap);
				renderGraphBuilder.SetRenderFunc<SkyManager.RenderSkyToCubemapPassData>(delegate(SkyManager.RenderSkyToCubemapPassData data, RenderGraphContext ctx)
				{
					data.builtinParameters.commandBuffer = ctx.cmd;
					for (int i = 0; i < 6; i++)
					{
						data.builtinParameters.pixelCoordToViewDirMatrix = data.facePixelCoordToViewDirMatrices[i];
						data.builtinParameters.viewMatrix = data.cameraViewMatrices[i];
						data.builtinParameters.colorBuffer = data.output;
						data.builtinParameters.depthBuffer = null;
						data.builtinParameters.cubemapFace = (CubemapFace)i;
						CoreUtils.SetRenderTarget(ctx.cmd, data.output, ClearFlag.None, 0, (CubemapFace)i, -1);
						data.skyRenderer.RenderSky(data.builtinParameters, true, data.includeSunInBaking);
						if (data.cloudRenderer != null)
						{
							data.cloudRenderer.RenderClouds(data.builtinParameters, true);
						}
					}
				});
			}
		}

		// Token: 0x06000EE1 RID: 3809 RVA: 0x00075948 File Offset: 0x00073B48
		internal void RenderSkyAmbientProbe(RenderGraph renderGraph, SkyUpdateContext skyContext, HDCamera hdCamera, ComputeBuffer probeBuffer, bool renderBackgroundClouds, HDProfileId profileId, float dimmer = 1f, float anisotropy = 0.7f)
		{
			TextureDesc textureDesc = new TextureDesc(this.m_LowResolution, this.m_LowResolution, false, false);
			textureDesc.slices = TextureXR.slices;
			textureDesc.dimension = TextureDimension.Cube;
			textureDesc.colorFormat = GraphicsFormat.R16G16B16A16_SFloat;
			textureDesc.enableRandomWrite = true;
			TextureHandle textureHandle = renderGraph.CreateTexture(textureDesc);
			this.RenderSkyToCubemap(renderGraph, skyContext, hdCamera, textureHandle, this.m_FacePixelCoordToViewDirMatricesLowRes, renderBackgroundClouds, profileId);
			this.UpdateAmbientProbe(renderGraph, textureHandle, true, null, null, probeBuffer, new Vector4(dimmer, anisotropy, 0f, 0f), null);
		}

		// Token: 0x06000EE2 RID: 3810 RVA: 0x000759D0 File Offset: 0x00073BD0
		internal void UpdateAmbientProbe(RenderGraph renderGraph, TextureHandle skyCubemap, bool outputForClouds, ComputeBuffer ambientProbeResult, ComputeBuffer diffuseAmbientProbeResult, ComputeBuffer volumetricAmbientProbeResult, Vector4 fogParameters, Action<AsyncGPUReadbackRequest> callback)
		{
			SkyManager.UpdateAmbientProbePassData updateAmbientProbePassData;
			using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<SkyManager.UpdateAmbientProbePassData>("UpdateAmbientProbe", out updateAmbientProbePassData, ProfilingSampler.Get<HDProfileId>(HDProfileId.UpdateSkyAmbientProbe)))
			{
				updateAmbientProbePassData.computeAmbientProbeCS = this.m_ComputeAmbientProbeCS;
				if (outputForClouds)
				{
					updateAmbientProbePassData.computeAmbientProbeKernel = this.m_ComputeAmbientProbeCloudsKernel;
				}
				else
				{
					updateAmbientProbePassData.computeAmbientProbeKernel = ((volumetricAmbientProbeResult != null) ? this.m_ComputeAmbientProbeVolumetricKernel : this.m_ComputeAmbientProbeKernel);
				}
				updateAmbientProbePassData.skyCubemap = renderGraphBuilder.ReadTexture(skyCubemap);
				updateAmbientProbePassData.ambientProbeResult = ambientProbeResult;
				updateAmbientProbePassData.diffuseAmbientProbeResult = diffuseAmbientProbeResult;
				SkyManager.UpdateAmbientProbePassData updateAmbientProbePassData2 = updateAmbientProbePassData;
				ComputeBufferDesc computeBufferDesc = new ComputeBufferDesc(27, 4);
				updateAmbientProbePassData2.scratchBuffer = renderGraphBuilder.CreateTransientComputeBuffer(computeBufferDesc);
				updateAmbientProbePassData.volumetricAmbientProbeResult = volumetricAmbientProbeResult;
				updateAmbientProbePassData.fogParameters = fogParameters;
				updateAmbientProbePassData.callback = callback;
				renderGraphBuilder.SetRenderFunc<SkyManager.UpdateAmbientProbePassData>(delegate(SkyManager.UpdateAmbientProbePassData data, RenderGraphContext ctx)
				{
					if (data.ambientProbeResult != null)
					{
						ctx.cmd.SetComputeBufferParam(data.computeAmbientProbeCS, data.computeAmbientProbeKernel, SkyManager.s_AmbientProbeOutputBufferParam, data.ambientProbeResult);
					}
					ctx.cmd.SetComputeBufferParam(data.computeAmbientProbeCS, data.computeAmbientProbeKernel, SkyManager.s_ScratchBufferParam, data.scratchBuffer);
					ctx.cmd.SetComputeTextureParam(data.computeAmbientProbeCS, data.computeAmbientProbeKernel, SkyManager.s_AmbientProbeInputCubemap, data.skyCubemap);
					if (data.diffuseAmbientProbeResult != null)
					{
						ctx.cmd.SetComputeBufferParam(data.computeAmbientProbeCS, data.computeAmbientProbeKernel, SkyManager.s_DiffuseAmbientProbeOutputBufferParam, data.diffuseAmbientProbeResult);
					}
					if (data.volumetricAmbientProbeResult != null)
					{
						ctx.cmd.SetComputeBufferParam(data.computeAmbientProbeCS, data.computeAmbientProbeKernel, SkyManager.s_VolumetricAmbientProbeOutputBufferParam, data.volumetricAmbientProbeResult);
						ctx.cmd.SetComputeVectorParam(data.computeAmbientProbeCS, SkyManager.s_FogParameters, data.fogParameters);
					}
					Hammersley.BindConstants(ctx.cmd, data.computeAmbientProbeCS);
					ctx.cmd.DispatchCompute(data.computeAmbientProbeCS, data.computeAmbientProbeKernel, 1, 1, 1);
					if (data.ambientProbeResult != null)
					{
						ctx.cmd.RequestAsyncReadback(data.ambientProbeResult, data.callback);
					}
				});
			}
		}

		// Token: 0x06000EE3 RID: 3811 RVA: 0x00075ABC File Offset: 0x00073CBC
		private TextureHandle GenerateSkyCubemap(RenderGraph renderGraph, HDCamera hdCamera, SkyUpdateContext skyContext, ComputeBuffer cloudsProbeBuffer)
		{
			SkyRenderingContext renderingContext = this.m_CachedSkyContexts[skyContext.cachedSkyRenderingContextId].renderingContext;
			TextureHandle textureHandle = renderGraph.ImportTexture(renderingContext.skyboxCubemapRT);
			this.RenderSkyToCubemap(renderGraph, skyContext, hdCamera, textureHandle, this.m_FacePixelCoordToViewDirMatrices, true, HDProfileId.RenderSkyToCubemap);
			if (skyContext.volumetricClouds != null)
			{
				this.SetGlobalSkyData(renderGraph, skyContext, this.m_BuiltinParameters);
				textureHandle = HDRenderPipeline.currentPipeline.RenderVolumetricClouds_Sky(renderGraph, hdCamera, this.m_FacePixelCoordToViewDirMatrices, skyContext.volumetricClouds, (int)this.m_BuiltinParameters.screenSize.x, (int)this.m_BuiltinParameters.screenSize.y, cloudsProbeBuffer, textureHandle);
			}
			HDRenderPipeline.GenerateMipmaps(renderGraph, textureHandle);
			return textureHandle;
		}

		// Token: 0x06000EE4 RID: 3812 RVA: 0x00075B64 File Offset: 0x00073D64
		private void RenderCubemapGGXConvolution(RenderGraph renderGraph, TextureHandle input, CubemapArray output)
		{
			SkyManager.SkyEnvironmentConvolutionPassData skyEnvironmentConvolutionPassData;
			using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<SkyManager.SkyEnvironmentConvolutionPassData>("UpdateSkyEnvironmentConvolution", out skyEnvironmentConvolutionPassData, ProfilingSampler.Get<HDProfileId>(HDProfileId.UpdateSkyEnvironmentConvolution)))
			{
				skyEnvironmentConvolutionPassData.bsdfs = this.m_IBLFilterArray;
				skyEnvironmentConvolutionPassData.input = renderGraphBuilder.ReadTexture(input);
				skyEnvironmentConvolutionPassData.output = output;
				SkyManager.SkyEnvironmentConvolutionPassData skyEnvironmentConvolutionPassData2 = skyEnvironmentConvolutionPassData;
				TextureDesc textureDesc = new TextureDesc(this.m_Resolution, this.m_Resolution, false, false);
				textureDesc.colorFormat = GraphicsFormat.R16G16B16A16_SFloat;
				textureDesc.dimension = TextureDimension.Cube;
				textureDesc.useMipMap = true;
				textureDesc.autoGenerateMips = false;
				textureDesc.filterMode = FilterMode.Trilinear;
				textureDesc.name = "SkyboxBSDFIntermediate";
				skyEnvironmentConvolutionPassData2.intermediateTexture = renderGraphBuilder.CreateTransientTexture(textureDesc);
				renderGraphBuilder.SetRenderFunc<SkyManager.SkyEnvironmentConvolutionPassData>(delegate(SkyManager.SkyEnvironmentConvolutionPassData data, RenderGraphContext ctx)
				{
					for (int i = 0; i < data.bsdfs.Length; i++)
					{
						data.bsdfs[i].FilterCubemap(ctx.cmd, data.input, data.intermediateTexture);
						for (int j = 0; j < 6; j++)
						{
							ctx.cmd.CopyTexture(data.intermediateTexture, j, data.output, 6 * i + j);
						}
					}
				});
			}
		}

		// Token: 0x06000EE5 RID: 3813 RVA: 0x00075C48 File Offset: 0x00073E48
		private int GetSunLightHashCode(Light light)
		{
			HDAdditionalLightData component = light.GetComponent<HDAdditionalLightData>();
			int num = 13;
			num = num * 23 + light.transform.position.GetHashCode();
			num = num * 23 + light.transform.rotation.GetHashCode();
			num = num * 23 + light.color.GetHashCode();
			num = num * 23 + light.colorTemperature.GetHashCode();
			num = num * 23 + light.intensity.GetHashCode();
			if (component != null)
			{
				num = num * 23 + component.lightDimmer.GetHashCode();
			}
			return num;
		}

		// Token: 0x06000EE6 RID: 3814 RVA: 0x00075D04 File Offset: 0x00073F04
		private void AllocateNewRenderingContext(SkyUpdateContext skyContext, int slot, int newHash, bool supportConvolution, in SphericalHarmonicsL2 previousAmbientProbe, string name)
		{
			ref CachedSkyContext ptr = ref this.m_CachedSkyContexts[slot];
			ptr.hash = newHash;
			ptr.refCount = 1;
			ptr.type = skyContext.skySettings.GetSkyRendererType();
			if (ptr.renderingContext != null && ptr.renderingContext.supportsConvolution != supportConvolution)
			{
				ptr.renderingContext.Cleanup();
				ptr.renderingContext = null;
			}
			if (ptr.renderingContext == null)
			{
				ptr.renderingContext = new SkyRenderingContext(this.m_Resolution, this.m_IBLFilterArray.Length, supportConvolution, previousAmbientProbe, name);
			}
			if (skyContext.settingsHadBigDifferenceWithPrev)
			{
				ptr.renderingContext.ClearAmbientProbe();
			}
			skyContext.cachedSkyRenderingContextId = slot;
		}

		// Token: 0x06000EE7 RID: 3815 RVA: 0x00075DAC File Offset: 0x00073FAC
		private bool AcquireSkyRenderingContext(SkyUpdateContext updateContext, int newHash, string name = "", bool supportConvolution = true)
		{
			SphericalHarmonicsL2 sphericalHarmonicsL = default(SphericalHarmonicsL2);
			if (this.CachedContextNeedsCleanup(updateContext))
			{
				ref CachedSkyContext ptr = ref this.m_CachedSkyContexts[updateContext.cachedSkyRenderingContextId];
				if (newHash == ptr.hash && !(updateContext.skySettings.GetSkyRendererType() != ptr.type))
				{
					return false;
				}
				if (updateContext.skySettings.GetSkyRendererType() == ptr.type)
				{
					sphericalHarmonicsL = ptr.renderingContext.ambientProbe;
				}
				this.ReleaseCachedContext(updateContext.cachedSkyRenderingContextId);
			}
			int num = -1;
			for (int i = 0; i < this.m_CachedSkyContexts.size; i++)
			{
				if (this.m_CachedSkyContexts[i].hash == newHash)
				{
					this.m_CachedSkyContexts[i].refCount++;
					updateContext.cachedSkyRenderingContextId = i;
					updateContext.skyParametersHash = newHash;
					return false;
				}
				if (num == -1 && this.m_CachedSkyContexts[i].hash == 0)
				{
					num = i;
				}
			}
			if (name == "")
			{
				name = "SkyboxCubemap";
			}
			if (num != -1)
			{
				this.AllocateNewRenderingContext(updateContext, num, newHash, supportConvolution, sphericalHarmonicsL, name);
			}
			else
			{
				DynamicArray<CachedSkyContext> cachedSkyContexts = this.m_CachedSkyContexts;
				CachedSkyContext cachedSkyContext = default(CachedSkyContext);
				int slot = cachedSkyContexts.Add(cachedSkyContext);
				this.AllocateNewRenderingContext(updateContext, slot, newHash, supportConvolution, sphericalHarmonicsL, name);
			}
			return true;
		}

		// Token: 0x06000EE8 RID: 3816 RVA: 0x00075EEC File Offset: 0x000740EC
		internal void ReleaseCachedContext(int id)
		{
			if (id == -1)
			{
				return;
			}
			ref CachedSkyContext ptr = ref this.m_CachedSkyContexts[id];
			if (ptr.refCount == 0)
			{
				return;
			}
			ptr.refCount--;
			if (ptr.refCount == 0)
			{
				ptr.Reset();
			}
		}

		// Token: 0x06000EE9 RID: 3817 RVA: 0x00075F30 File Offset: 0x00074130
		private bool IsCachedContextValid(SkyUpdateContext skyContext)
		{
			if (skyContext.skySettings == null)
			{
				return false;
			}
			int cachedSkyRenderingContextId = skyContext.cachedSkyRenderingContextId;
			return cachedSkyRenderingContextId != -1 && skyContext.skySettings.GetSkyRendererType() == this.m_CachedSkyContexts[cachedSkyRenderingContextId].type && this.m_CachedSkyContexts[cachedSkyRenderingContextId].hash != 0;
		}

		// Token: 0x06000EEA RID: 3818 RVA: 0x00075F94 File Offset: 0x00074194
		private bool CachedContextNeedsCleanup(SkyUpdateContext skyContext)
		{
			if (skyContext.skySettings == null)
			{
				return false;
			}
			int cachedSkyRenderingContextId = skyContext.cachedSkyRenderingContextId;
			return cachedSkyRenderingContextId != -1 && this.m_CachedSkyContexts[cachedSkyRenderingContextId].hash != 0;
		}

		// Token: 0x06000EEB RID: 3819 RVA: 0x00075FD4 File Offset: 0x000741D4
		private int ComputeSkyHash(HDCamera camera, SkyUpdateContext skyContext, Light sunLight, SkyAmbientMode ambientMode, bool staticSky = false)
		{
			int num = 0;
			if (sunLight != null && skyContext.skyRenderer.SupportDynamicSunLight)
			{
				num = this.GetSunLightHashCode(sunLight);
			}
			Camera camera2 = camera.camera;
			if (camera.camera.cameraType == CameraType.Reflection && camera.parentCamera != null)
			{
				camera2 = camera.parentCamera;
			}
			int num2 = num * 23 + skyContext.skySettings.GetHashCode(camera2);
			if (skyContext.HasClouds())
			{
				num2 = num2 * 23 + skyContext.cloudSettings.GetHashCode(camera2);
			}
			if (skyContext.HasVolumetricClouds())
			{
				num2 = num2 * 23 + skyContext.volumetricClouds.GetHashCode();
				num2 = num2 * 23 + camera.frameSettings.IsEnabled(FrameSettingsField.FullResolutionCloudsForSky).GetHashCode();
			}
			num2 = num2 * 23 + (staticSky ? 1 : 0);
			num2 = num2 * 23 + ((ambientMode == SkyAmbientMode.Static) ? 1 : 0);
			if (camera.frameSettings.IsEnabled(FrameSettingsField.Volumetrics))
			{
				Fog component = camera.volumeStack.GetComponent<Fog>();
				num2 = num2 * 23 + component.globalLightProbeDimmer.GetHashCode();
				num2 = num2 * 23 + component.anisotropy.GetHashCode();
			}
			return num2;
		}

		// Token: 0x06000EEC RID: 3820 RVA: 0x000760F0 File Offset: 0x000742F0
		public void RequestEnvironmentUpdate()
		{
			this.m_UpdateRequired = true;
		}

		// Token: 0x06000EED RID: 3821 RVA: 0x000760F9 File Offset: 0x000742F9
		internal void RequestStaticEnvironmentUpdate()
		{
			this.m_StaticSkyUpdateRequired = true;
		}

		// Token: 0x06000EEE RID: 3822 RVA: 0x00076104 File Offset: 0x00074304
		private void UpdateEnvironment(RenderGraph renderGraph, HDCamera hdCamera, SkyUpdateContext skyContext, Light sunLight, bool updateRequired, bool updateAmbientProbe, bool staticSky, SkyAmbientMode ambientMode)
		{
			if (skyContext.IsValid())
			{
				using (new RenderGraphProfilingScope(renderGraph, ProfilingSampler.Get<HDProfileId>(HDProfileId.UpdateEnvironment)))
				{
					skyContext.currentUpdateTime += hdCamera.deltaTime;
					SkyManager.UpdateBuiltinParameters(ref this.m_BuiltinParameters, skyContext, hdCamera, this.m_CurrentSunLight, null);
					if (hdCamera.camera.cameraType == CameraType.Reflection && hdCamera.parentCamera != null)
					{
						this.m_BuiltinParameters.worldSpaceCameraPos = hdCamera.parentCamera.transform.position;
					}
					this.m_BuiltinParameters.screenSize = this.m_CubemapScreenSize;
					if (this.IsCachedContextValid(skyContext) && !updateRequired)
					{
						if (skyContext.skySettings.updateMode.value == EnvironmentUpdateMode.OnDemand)
						{
							return;
						}
						if (skyContext.skySettings.updateMode.value == EnvironmentUpdateMode.Realtime && skyContext.currentUpdateTime < skyContext.skySettings.updatePeriod.value)
						{
							return;
						}
					}
					int num = this.ComputeSkyHash(hdCamera, skyContext, sunLight, ambientMode, staticSky);
					bool flag = updateRequired | this.AcquireSkyRenderingContext(skyContext, num, staticSky ? "SkyboxCubemap_Static" : "SkyboxCubemap", !staticSky);
					SkyRenderingContext renderingContext = this.m_CachedSkyContexts[skyContext.cachedSkyRenderingContextId].renderingContext;
					if (this.IsCachedContextValid(skyContext))
					{
						flag |= skyContext.skyRenderer.DoUpdate(this.m_BuiltinParameters);
						flag |= (skyContext.HasClouds() && skyContext.cloudRenderer.DoUpdate(this.m_BuiltinParameters));
					}
					flag |= (skyContext.skySettings.updateMode.value == EnvironmentUpdateMode.OnChanged && num != skyContext.skyParametersHash);
					flag |= (skyContext.skySettings.updateMode.value == EnvironmentUpdateMode.Realtime && skyContext.currentUpdateTime > skyContext.skySettings.updatePeriod.value);
					if (flag && skyContext.cloudRenderer != null)
					{
						this.RenderSkyAmbientProbe(renderGraph, skyContext, hdCamera, renderingContext.cloudAmbientProbeBuffer, false, HDProfileId.BackgroundCloudsAmbientProbe, 1f, 0.7f);
					}
					ComputeBuffer cloudsProbeBuffer = HDRenderPipeline.currentPipeline.RenderVolumetricCloudsAmbientProbe(renderGraph, hdCamera, skyContext, staticSky);
					if (flag)
					{
						TextureHandle textureHandle = this.GenerateSkyCubemap(renderGraph, hdCamera, skyContext, cloudsProbeBuffer);
						if (updateAmbientProbe)
						{
							Fog component = hdCamera.volumeStack.GetComponent<Fog>();
							this.UpdateAmbientProbe(renderGraph, textureHandle, false, renderingContext.ambientProbeResult, renderingContext.diffuseAmbientProbeBuffer, renderingContext.volumetricAmbientProbeBuffer, new Vector4(component.globalLightProbeDimmer.value, component.anisotropy.value, 0f, 0f), new Action<AsyncGPUReadbackRequest>(renderingContext.OnComputeAmbientProbeDone));
						}
						if (renderingContext.supportsConvolution)
						{
							this.RenderCubemapGGXConvolution(renderGraph, textureHandle, renderingContext.skyboxBSDFCubemapArray);
						}
						skyContext.skyParametersHash = num;
						skyContext.currentUpdateTime = 0f;
					}
					return;
				}
			}
			if (skyContext.cachedSkyRenderingContextId != -1)
			{
				this.ReleaseCachedContext(skyContext.cachedSkyRenderingContextId);
				skyContext.cachedSkyRenderingContextId = -1;
			}
		}

		// Token: 0x06000EEF RID: 3823 RVA: 0x000763EC File Offset: 0x000745EC
		public void UpdateEnvironment(RenderGraph renderGraph, HDCamera hdCamera, Light sunLight, DebugDisplaySettings debugSettings)
		{
			this.m_CurrentDebugDisplaySettings = debugSettings;
			this.m_CurrentSunLight = sunLight;
			SkyAmbientMode value = hdCamera.volumeStack.GetComponent<VisualEnvironment>().skyAmbientMode.value;
			this.UpdateEnvironment(renderGraph, hdCamera, hdCamera.lightingSky, sunLight, this.m_UpdateRequired, value == SkyAmbientMode.Dynamic, false, value);
			bool flag = false;
			StaticLightingSky staticLightingSky = SkyManager.GetStaticLightingSky();
			if ((value == SkyAmbientMode.Static || flag) && hdCamera.camera.cameraType != CameraType.Preview)
			{
				this.m_StaticLightingSky.skySettings = ((staticLightingSky != null) ? staticLightingSky.skySettings : null);
				this.m_StaticLightingSky.cloudSettings = ((staticLightingSky != null) ? staticLightingSky.cloudSettings : null);
				this.m_StaticLightingSky.volumetricClouds = ((staticLightingSky != null) ? staticLightingSky.volumetricClouds : null);
				this.UpdateEnvironment(renderGraph, hdCamera, this.m_StaticLightingSky, sunLight, this.m_StaticSkyUpdateRequired || this.m_UpdateRequired, true, true, SkyAmbientMode.Static);
				this.m_StaticSkyUpdateRequired = false;
			}
			this.m_UpdateRequired = false;
			this.SetGlobalSkyData(renderGraph, hdCamera.lightingSky, this.m_BuiltinParameters);
			HDRenderPipeline.SetGlobalTexture(renderGraph, HDShaderIDs._SkyTexture, this.GetReflectionTexture(hdCamera.lightingSky));
			HDRenderPipeline.SetGlobalBuffer(renderGraph, HDShaderIDs._AmbientProbeData, this.GetDiffuseAmbientProbeBuffer(hdCamera));
		}

		// Token: 0x06000EF0 RID: 3824 RVA: 0x00076524 File Offset: 0x00074724
		private static void UpdateBuiltinParameters(ref BuiltinSkyParameters builtinParameters, SkyUpdateContext skyContext, HDCamera hdCamera, Light sunLight, DebugDisplaySettings debugSettings)
		{
			builtinParameters.hdCamera = hdCamera;
			builtinParameters.sunLight = sunLight;
			builtinParameters.pixelCoordToViewDirMatrix = hdCamera.mainViewConstants.pixelCoordToViewDirWS;
			builtinParameters.worldSpaceCameraPos = hdCamera.mainViewConstants.worldSpaceCameraPos;
			builtinParameters.viewMatrix = hdCamera.mainViewConstants.viewMatrix;
			builtinParameters.screenSize = hdCamera.screenSize;
			builtinParameters.debugSettings = debugSettings;
			builtinParameters.frameIndex = (int)hdCamera.GetCameraFrameCount();
			builtinParameters.skySettings = skyContext.skySettings;
			builtinParameters.cloudSettings = skyContext.cloudSettings;
			builtinParameters.volumetricClouds = skyContext.volumetricClouds;
			builtinParameters.commandBuffer = null;
			builtinParameters.colorBuffer = null;
			builtinParameters.depthBuffer = null;
		}

		// Token: 0x06000EF1 RID: 3825 RVA: 0x000765DC File Offset: 0x000747DC
		public bool TryGetCloudSettings(HDCamera hdCamera, out CloudSettings cloudSettings, out CloudRenderer cloudRenderer)
		{
			SkyUpdateContext visualSky = hdCamera.visualSky;
			cloudSettings = visualSky.cloudSettings;
			cloudRenderer = visualSky.cloudRenderer;
			return visualSky.HasClouds();
		}

		// Token: 0x06000EF2 RID: 3826 RVA: 0x00076608 File Offset: 0x00074808
		private bool RequiresPreRenderSky(HDCamera hdCamera)
		{
			SkyUpdateContext visualSky = hdCamera.visualSky;
			return visualSky.IsValid() && (visualSky.skyRenderer.RequiresPreRender(visualSky.skySettings) || (visualSky.HasClouds() && visualSky.cloudRenderer.RequiresPreRenderClouds(this.m_BuiltinParameters)));
		}

		// Token: 0x06000EF3 RID: 3827 RVA: 0x00076658 File Offset: 0x00074858
		public void PreRenderSky(RenderGraph renderGraph, HDCamera hdCamera, TextureHandle normalBuffer, TextureHandle depthBuffer)
		{
			SkyUpdateContext visualSky = hdCamera.visualSky;
			if (visualSky.IsValid() && this.RequiresPreRenderSky(hdCamera))
			{
				SkyManager.RenderSkyPassData renderSkyPassData;
				using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<SkyManager.RenderSkyPassData>("Pre Render Sky", out renderSkyPassData, ProfilingSampler.Get<HDProfileId>(HDProfileId.PreRenderSky)))
				{
					renderSkyPassData.colorBuffer = renderGraphBuilder.WriteTexture(normalBuffer);
					renderSkyPassData.depthBuffer = renderGraphBuilder.WriteTexture(depthBuffer);
					renderSkyPassData.skyContext = visualSky;
					renderSkyPassData.renderSunDisk = (hdCamera.camera.cameraType != CameraType.Reflection || visualSky.skySettings.includeSunInBaking.value);
					SkyManager.UpdateBuiltinParameters(ref renderSkyPassData.builtinParameters, visualSky, hdCamera, this.m_CurrentSunLight, this.m_CurrentDebugDisplaySettings);
					renderGraphBuilder.SetRenderFunc<SkyManager.RenderSkyPassData>(delegate(SkyManager.RenderSkyPassData data, RenderGraphContext ctx)
					{
						data.builtinParameters.colorBuffer = data.colorBuffer;
						data.builtinParameters.depthBuffer = data.depthBuffer;
						data.builtinParameters.commandBuffer = ctx.cmd;
						CoreUtils.SetRenderTarget(ctx.cmd, data.colorBuffer, data.depthBuffer, 0, CubemapFace.Unknown, -1);
						if (data.skyContext.skyRenderer.RequiresPreRender(data.skyContext.skySettings))
						{
							data.skyContext.skyRenderer.DoUpdate(data.builtinParameters);
							data.skyContext.skyRenderer.PreRenderSky(data.builtinParameters);
						}
						if (data.skyContext.HasClouds() && data.skyContext.cloudRenderer.RequiresPreRenderClouds(data.builtinParameters))
						{
							data.skyContext.cloudRenderer.DoUpdate(data.builtinParameters);
							data.skyContext.cloudRenderer.PreRenderClouds(data.builtinParameters, false);
						}
					});
				}
			}
		}

		// Token: 0x06000EF4 RID: 3828 RVA: 0x00076744 File Offset: 0x00074944
		public void RenderSky(RenderGraph renderGraph, HDCamera hdCamera, TextureHandle colorBuffer, TextureHandle depthBuffer, string passName, ProfilingSampler sampler = null)
		{
			if (hdCamera.clearColorMode != HDAdditionalCameraData.ClearColorMode.Sky || this.m_CurrentDebugDisplaySettings.data.lightingDebugSettings.debugLightingMode == DebugLightingMode.LuxMeter)
			{
				return;
			}
			SkyUpdateContext visualSky = hdCamera.visualSky;
			if (visualSky.IsValid())
			{
				SkyManager.RenderSkyPassData renderSkyPassData;
				using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<SkyManager.RenderSkyPassData>("Render Sky", out renderSkyPassData, sampler))
				{
					renderSkyPassData.colorBuffer = renderGraphBuilder.WriteTexture(colorBuffer);
					renderSkyPassData.depthBuffer = renderGraphBuilder.WriteTexture(depthBuffer);
					if (LensFlareCommonSRP.IsCloudLayerOpacityNeeded(hdCamera.camera))
					{
						TextureDesc textureDesc = new TextureDesc(Vector2.one, true, true);
						textureDesc.colorFormat = GraphicsFormat.R8_UNorm;
						textureDesc.clearBuffer = true;
						textureDesc.clearColor = Color.black;
						textureDesc.name = "Cloud Occlusion";
						TextureHandle textureHandle = renderGraph.CreateTexture(textureDesc);
						this.m_CloudOpacity = renderGraphBuilder.WriteTexture(textureHandle);
					}
					else
					{
						this.m_CloudOpacity = TextureHandle.nullHandle;
					}
					renderSkyPassData.skyContext = visualSky;
					bool flag = false;
					if (renderSkyPassData.skyContext.HasClouds())
					{
						CloudLayer cloudLayer = renderSkyPassData.skyContext.cloudSettings as CloudLayer;
						if (cloudLayer)
						{
							flag = (cloudLayer.active && cloudLayer.opacity.value > 0f);
						}
					}
					if (flag && LensFlareCommonSRP.IsCloudLayerOpacityNeeded(hdCamera.camera))
					{
						TextureDesc textureDesc = new TextureDesc(Vector2.one, true, true);
						textureDesc.colorFormat = GraphicsFormat.R8_UNorm;
						textureDesc.clearBuffer = true;
						textureDesc.clearColor = Color.black;
						textureDesc.name = "Cloud Occlusion";
						TextureHandle textureHandle2 = renderGraph.CreateTexture(textureDesc);
						this.m_CloudOpacity = renderGraphBuilder.WriteTexture(textureHandle2);
					}
					else
					{
						this.m_CloudOpacity = TextureHandle.nullHandle;
					}
					renderSkyPassData.renderSunDisk = (hdCamera.camera.cameraType != CameraType.Reflection || visualSky.skySettings.includeSunInBaking.value);
					SkyManager.UpdateBuiltinParameters(ref renderSkyPassData.builtinParameters, visualSky, hdCamera, this.m_CurrentSunLight, this.m_CurrentDebugDisplaySettings);
					renderSkyPassData.cloudOpacityBuffer = this.m_CloudOpacity;
					if (visualSky.HasClouds())
					{
						ref CachedSkyContext ptr = ref this.m_CachedSkyContexts[visualSky.cachedSkyRenderingContextId];
						renderSkyPassData.builtinParameters.cloudAmbientProbe = ptr.renderingContext.cloudAmbientProbeBuffer;
					}
					renderGraphBuilder.SetRenderFunc<SkyManager.RenderSkyPassData>(delegate(SkyManager.RenderSkyPassData data, RenderGraphContext ctx)
					{
						data.builtinParameters.colorBuffer = data.colorBuffer;
						data.builtinParameters.depthBuffer = data.depthBuffer;
						data.builtinParameters.cloudOpacity = data.cloudOpacityBuffer;
						data.builtinParameters.commandBuffer = ctx.cmd;
						CoreUtils.SetRenderTarget(ctx.cmd, data.colorBuffer, data.depthBuffer, 0, CubemapFace.Unknown, -1);
						data.skyContext.skyRenderer.DoUpdate(data.builtinParameters);
						data.skyContext.skyRenderer.RenderSky(data.builtinParameters, false, data.renderSunDisk);
						if (data.skyContext.HasClouds())
						{
							using (new ProfilingScope(ctx.cmd, ProfilingSampler.Get<HDProfileId>(HDProfileId.RenderClouds)))
							{
								data.skyContext.cloudRenderer.DoUpdate(data.builtinParameters);
								data.skyContext.cloudRenderer.RenderClouds(data.builtinParameters, false);
							}
						}
					});
				}
			}
		}

		// Token: 0x06000EF5 RID: 3829 RVA: 0x000769AC File Offset: 0x00074BAC
		public void RenderOpaqueAtmosphericScattering(RenderGraph renderGraph, HDCamera hdCamera, TextureHandle colorBuffer, TextureHandle depthTexture, TextureHandle volumetricLighting, TextureHandle depthBuffer)
		{
			if (!Fog.IsFogEnabled(hdCamera) && !Fog.IsPBRFogEnabled(hdCamera))
			{
				return;
			}
			SkyManager.OpaqueAtmosphericScatteringPassData opaqueAtmosphericScatteringPassData;
			using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<SkyManager.OpaqueAtmosphericScatteringPassData>("Opaque Atmospheric Scattering", out opaqueAtmosphericScatteringPassData, ProfilingSampler.Get<HDProfileId>(HDProfileId.OpaqueAtmosphericScattering)))
			{
				opaqueAtmosphericScatteringPassData.opaqueAtmosphericalScatteringMaterial = this.m_OpaqueAtmScatteringMaterial;
				opaqueAtmosphericScatteringPassData.msaa = hdCamera.msaaEnabled;
				opaqueAtmosphericScatteringPassData.pbrFog = Fog.IsPBRFogEnabled(hdCamera);
				opaqueAtmosphericScatteringPassData.pixelCoordToViewDirWS = hdCamera.mainViewConstants.pixelCoordToViewDirWS;
				if (volumetricLighting.IsValid())
				{
					opaqueAtmosphericScatteringPassData.volumetricLighting = renderGraphBuilder.ReadTexture(volumetricLighting);
				}
				else
				{
					opaqueAtmosphericScatteringPassData.volumetricLighting = TextureHandle.nullHandle;
				}
				opaqueAtmosphericScatteringPassData.colorBuffer = renderGraphBuilder.WriteTexture(colorBuffer);
				opaqueAtmosphericScatteringPassData.depthTexture = renderGraphBuilder.ReadTexture(depthTexture);
				opaqueAtmosphericScatteringPassData.depthBuffer = renderGraphBuilder.ReadTexture(depthBuffer);
				if (Fog.IsPBRFogEnabled(hdCamera))
				{
					opaqueAtmosphericScatteringPassData.intermediateTexture = renderGraphBuilder.CreateTransientTexture(colorBuffer);
				}
				renderGraphBuilder.SetRenderFunc<SkyManager.OpaqueAtmosphericScatteringPassData>(delegate(SkyManager.OpaqueAtmosphericScatteringPassData data, RenderGraphContext ctx)
				{
					MaterialPropertyBlock tempMaterialPropertyBlock = ctx.renderGraphPool.GetTempMaterialPropertyBlock();
					tempMaterialPropertyBlock.SetMatrix(HDShaderIDs._PixelCoordToViewDirWS, data.pixelCoordToViewDirWS);
					tempMaterialPropertyBlock.SetTexture(data.msaa ? HDShaderIDs._DepthTextureMS : HDShaderIDs._CameraDepthTexture, data.depthTexture);
					if (data.volumetricLighting.IsValid())
					{
						tempMaterialPropertyBlock.SetTexture(HDShaderIDs._VBufferLighting, data.volumetricLighting);
					}
					if (data.pbrFog)
					{
						tempMaterialPropertyBlock.SetTexture(data.msaa ? HDShaderIDs._ColorTextureMS : HDShaderIDs._ColorTexture, data.colorBuffer);
						HDUtils.DrawFullScreen(ctx.cmd, data.opaqueAtmosphericalScatteringMaterial, data.intermediateTexture, data.depthBuffer, tempMaterialPropertyBlock, data.msaa ? 3 : 2);
						ctx.cmd.CopyTexture(data.intermediateTexture, data.colorBuffer);
						return;
					}
					HDUtils.DrawFullScreen(ctx.cmd, data.opaqueAtmosphericalScatteringMaterial, data.colorBuffer, data.depthBuffer, tempMaterialPropertyBlock, data.msaa ? 1 : 0);
				});
			}
		}

		// Token: 0x06000EF6 RID: 3830 RVA: 0x00076AC4 File Offset: 0x00074CC4
		public static StaticLightingSky GetStaticLightingSky()
		{
			if (SkyManager.m_StaticLightingSkies.Count == 0)
			{
				return null;
			}
			return SkyManager.m_StaticLightingSkies[SkyManager.m_StaticLightingSkies.Count - 1];
		}

		// Token: 0x06000EF7 RID: 3831 RVA: 0x00076AEC File Offset: 0x00074CEC
		public static void RegisterStaticLightingSky(StaticLightingSky staticLightingSky)
		{
			if (!SkyManager.m_StaticLightingSkies.Contains(staticLightingSky))
			{
				if (SkyManager.m_StaticLightingSkies.Count != 0)
				{
					Debug.LogWarning("One Static Lighting Sky component was already set for baking, only the latest one will be used.");
				}
				Type type;
				if (staticLightingSky.staticLightingSkyUniqueID == 2 && !SkyManager.skyTypesDict.TryGetValue(2, out type))
				{
					Debug.LogError("You are using the deprecated Procedural Sky for static lighting in your Scene. You can still use it but, to do so, you must install it separately. To do this, open the Package Manager window and import the 'Procedural Sky' sample from the HDRP package page, then close and re-open your project without saving.");
					return;
				}
				SkyManager.m_StaticLightingSkies.Add(staticLightingSky);
			}
		}

		// Token: 0x06000EF8 RID: 3832 RVA: 0x00076B4A File Offset: 0x00074D4A
		public static void UnRegisterStaticLightingSky(StaticLightingSky staticLightingSky)
		{
			SkyManager.m_StaticLightingSkies.Remove(staticLightingSky);
		}

		// Token: 0x06000EF9 RID: 3833 RVA: 0x00076B58 File Offset: 0x00074D58
		public Texture2D ExportSkyToTexture(Camera camera)
		{
			HDCamera orCreate = HDCamera.GetOrCreate(camera, 0);
			if (!orCreate.visualSky.IsValid() || !this.IsCachedContextValid(orCreate.visualSky))
			{
				Debug.LogError("Cannot export sky to a texture, no valid Sky is setup (Also make sure the game view has been rendered at least once).");
				return null;
			}
			RenderTexture renderTexture = this.m_CachedSkyContexts[orCreate.visualSky.cachedSkyRenderingContextId].renderingContext.skyboxCubemapRT;
			int width = renderTexture.width;
			RenderTexture renderTexture2 = new RenderTexture(width * 6, width, 0, GraphicsFormat.R16G16B16A16_SFloat)
			{
				dimension = TextureDimension.Tex2D,
				useMipMap = false,
				autoGenerateMips = false,
				filterMode = FilterMode.Trilinear
			};
			renderTexture2.Create();
			Texture2D texture2D = new Texture2D(width * 6, width, GraphicsFormat.R32G32B32A32_SFloat, TextureCreationFlags.None);
			Texture2D texture2D2 = new Texture2D(width * 6, width, GraphicsFormat.R32G32B32A32_SFloat, TextureCreationFlags.None);
			int num = 0;
			for (int i = 0; i < 6; i++)
			{
				Graphics.SetRenderTarget(renderTexture, 0, (CubemapFace)i);
				texture2D.ReadPixels(new Rect(0f, 0f, (float)width, (float)width), num, 0);
				texture2D.Apply();
				num += width;
			}
			Graphics.Blit(texture2D, renderTexture2, new Vector2(1f, -1f), new Vector2(0f, 0f));
			texture2D2.ReadPixels(new Rect(0f, 0f, (float)(width * 6), (float)width), 0, 0);
			texture2D2.Apply();
			Graphics.SetRenderTarget(null);
			CoreUtils.Destroy(texture2D);
			CoreUtils.Destroy(renderTexture2);
			return texture2D2;
		}

		// Token: 0x0400176D RID: 5997
		private Material m_StandardSkyboxMaterial;

		// Token: 0x0400176E RID: 5998
		private Material m_BlitCubemapMaterial;

		// Token: 0x0400176F RID: 5999
		private Material m_OpaqueAtmScatteringMaterial;

		// Token: 0x04001770 RID: 6000
		private SphericalHarmonicsL2 m_BlackAmbientProbe;

		// Token: 0x04001771 RID: 6001
		private bool m_UpdateRequired;

		// Token: 0x04001772 RID: 6002
		private bool m_StaticSkyUpdateRequired;

		// Token: 0x04001773 RID: 6003
		private int m_Resolution;

		// Token: 0x04001774 RID: 6004
		private int m_LowResolution;

		// Token: 0x04001775 RID: 6005
		private SkyUpdateContext m_StaticLightingSky = new SkyUpdateContext();

		// Token: 0x04001778 RID: 6008
		private static Dictionary<int, Type> m_SkyTypesDict = null;

		// Token: 0x04001779 RID: 6009
		private static Dictionary<int, Type> m_CloudTypesDict = null;

		// Token: 0x0400177A RID: 6010
		private static List<StaticLightingSky> m_StaticLightingSkies = new List<StaticLightingSky>();

		// Token: 0x0400177B RID: 6011
		private static bool logOnce = true;

		// Token: 0x0400177C RID: 6012
		private IBLFilterBSDF[] m_IBLFilterArray;

		// Token: 0x0400177D RID: 6013
		private Vector4 m_CubemapScreenSize;

		// Token: 0x0400177E RID: 6014
		private Vector4 m_LowResCubemapScreenSize;

		// Token: 0x0400177F RID: 6015
		private Matrix4x4[] m_FacePixelCoordToViewDirMatrices = new Matrix4x4[6];

		// Token: 0x04001780 RID: 6016
		private Matrix4x4[] m_FacePixelCoordToViewDirMatricesLowRes = new Matrix4x4[6];

		// Token: 0x04001781 RID: 6017
		private Matrix4x4[] m_CameraRelativeViewMatrices = new Matrix4x4[6];

		// Token: 0x04001782 RID: 6018
		private BuiltinSkyParameters m_BuiltinParameters = new BuiltinSkyParameters();

		// Token: 0x04001783 RID: 6019
		private ComputeShader m_ComputeAmbientProbeCS;

		// Token: 0x04001784 RID: 6020
		private static readonly int s_AmbientProbeOutputBufferParam = Shader.PropertyToID("_AmbientProbeOutputBuffer");

		// Token: 0x04001785 RID: 6021
		private static readonly int s_VolumetricAmbientProbeOutputBufferParam = Shader.PropertyToID("_VolumetricAmbientProbeOutputBuffer");

		// Token: 0x04001786 RID: 6022
		private static readonly int s_DiffuseAmbientProbeOutputBufferParam = Shader.PropertyToID("_DiffuseAmbientProbeOutputBuffer");

		// Token: 0x04001787 RID: 6023
		private static readonly int s_ScratchBufferParam = Shader.PropertyToID("_ScratchBuffer");

		// Token: 0x04001788 RID: 6024
		private static readonly int s_AmbientProbeInputCubemap = Shader.PropertyToID("_AmbientProbeInputCubemap");

		// Token: 0x04001789 RID: 6025
		private static readonly int s_FogParameters = Shader.PropertyToID("_FogParameters");

		// Token: 0x0400178A RID: 6026
		private int m_ComputeAmbientProbeKernel;

		// Token: 0x0400178B RID: 6027
		private int m_ComputeAmbientProbeVolumetricKernel;

		// Token: 0x0400178C RID: 6028
		private int m_ComputeAmbientProbeCloudsKernel;

		// Token: 0x0400178D RID: 6029
		private CubemapArray m_BlackCubemapArray;

		// Token: 0x0400178E RID: 6030
		private ComputeBuffer m_BlackAmbientProbeBuffer;

		// Token: 0x0400178F RID: 6031
		private DynamicArray<CachedSkyContext> m_CachedSkyContexts = new DynamicArray<CachedSkyContext>(2);

		// Token: 0x04001790 RID: 6032
		private DebugDisplaySettings m_CurrentDebugDisplaySettings;

		// Token: 0x04001791 RID: 6033
		private Light m_CurrentSunLight;

		// Token: 0x04001792 RID: 6034
		private TextureHandle m_CloudOpacity;

		// Token: 0x02000430 RID: 1072
		private class SetGlobalSkyDataPassData
		{
			// Token: 0x0400292F RID: 10543
			public BuiltinSkyParameters builtinParameters = new BuiltinSkyParameters();

			// Token: 0x04002930 RID: 10544
			public SkyRenderer skyRenderer;
		}

		// Token: 0x02000431 RID: 1073
		private class RenderSkyToCubemapPassData
		{
			// Token: 0x04002931 RID: 10545
			public BuiltinSkyParameters builtinParameters = new BuiltinSkyParameters();

			// Token: 0x04002932 RID: 10546
			public SkyRenderer skyRenderer;

			// Token: 0x04002933 RID: 10547
			public CloudRenderer cloudRenderer;

			// Token: 0x04002934 RID: 10548
			public Matrix4x4[] cameraViewMatrices;

			// Token: 0x04002935 RID: 10549
			public Matrix4x4[] facePixelCoordToViewDirMatrices;

			// Token: 0x04002936 RID: 10550
			public bool includeSunInBaking;

			// Token: 0x04002937 RID: 10551
			public TextureHandle output;
		}

		// Token: 0x02000432 RID: 1074
		private class UpdateAmbientProbePassData
		{
			// Token: 0x04002938 RID: 10552
			public ComputeShader computeAmbientProbeCS;

			// Token: 0x04002939 RID: 10553
			public int computeAmbientProbeKernel;

			// Token: 0x0400293A RID: 10554
			public TextureHandle skyCubemap;

			// Token: 0x0400293B RID: 10555
			public ComputeBuffer ambientProbeResult;

			// Token: 0x0400293C RID: 10556
			public ComputeBuffer diffuseAmbientProbeResult;

			// Token: 0x0400293D RID: 10557
			public ComputeBuffer volumetricAmbientProbeResult;

			// Token: 0x0400293E RID: 10558
			public ComputeBufferHandle scratchBuffer;

			// Token: 0x0400293F RID: 10559
			public Vector4 fogParameters;

			// Token: 0x04002940 RID: 10560
			public Action<AsyncGPUReadbackRequest> callback;
		}

		// Token: 0x02000433 RID: 1075
		private class SkyEnvironmentConvolutionPassData
		{
			// Token: 0x04002941 RID: 10561
			public TextureHandle input;

			// Token: 0x04002942 RID: 10562
			public TextureHandle intermediateTexture;

			// Token: 0x04002943 RID: 10563
			public CubemapArray output;

			// Token: 0x04002944 RID: 10564
			public IBLFilterBSDF[] bsdfs;
		}

		// Token: 0x02000434 RID: 1076
		private class RenderSkyPassData
		{
			// Token: 0x04002945 RID: 10565
			public BuiltinSkyParameters builtinParameters = new BuiltinSkyParameters();

			// Token: 0x04002946 RID: 10566
			public TextureHandle colorBuffer;

			// Token: 0x04002947 RID: 10567
			public TextureHandle cloudOpacityBuffer;

			// Token: 0x04002948 RID: 10568
			public TextureHandle depthBuffer;

			// Token: 0x04002949 RID: 10569
			public SkyUpdateContext skyContext;

			// Token: 0x0400294A RID: 10570
			public bool renderSunDisk;
		}

		// Token: 0x02000435 RID: 1077
		private class OpaqueAtmosphericScatteringPassData
		{
			// Token: 0x0400294B RID: 10571
			public TextureHandle colorBuffer;

			// Token: 0x0400294C RID: 10572
			public TextureHandle depthTexture;

			// Token: 0x0400294D RID: 10573
			public TextureHandle volumetricLighting;

			// Token: 0x0400294E RID: 10574
			public TextureHandle depthBuffer;

			// Token: 0x0400294F RID: 10575
			public TextureHandle intermediateTexture;

			// Token: 0x04002950 RID: 10576
			public Matrix4x4 pixelCoordToViewDirWS;

			// Token: 0x04002951 RID: 10577
			public Material opaqueAtmosphericalScatteringMaterial;

			// Token: 0x04002952 RID: 10578
			public bool pbrFog;

			// Token: 0x04002953 RID: 10579
			public bool msaa;
		}
	}
}
