using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000164 RID: 356
	internal class HDRenderPipelineGlobalSettings : RenderPipelineGlobalSettings, IVersionable<HDRenderPipelineGlobalSettings.Version>, IMigratableAsset, IShaderVariantSettings
	{
		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000BF1 RID: 3057 RVA: 0x000602FD File Offset: 0x0005E4FD
		public static HDRenderPipelineGlobalSettings instance
		{
			get
			{
				if (HDRenderPipelineGlobalSettings.cachedInstance == null)
				{
					HDRenderPipelineGlobalSettings.cachedInstance = (GraphicsSettings.GetSettingsForRenderPipeline<HDRenderPipeline>() as HDRenderPipelineGlobalSettings);
				}
				return HDRenderPipelineGlobalSettings.cachedInstance;
			}
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x00060320 File Offset: 0x0005E520
		internal static void UpdateGraphicsSettings(HDRenderPipelineGlobalSettings newSettings)
		{
			if (newSettings == HDRenderPipelineGlobalSettings.cachedInstance)
			{
				return;
			}
			if (newSettings != null)
			{
				GraphicsSettings.RegisterRenderPipelineSettings<HDRenderPipeline>(newSettings);
			}
			else
			{
				GraphicsSettings.UnregisterRenderPipelineSettings<HDRenderPipeline>();
			}
			HDRenderPipelineGlobalSettings.cachedInstance = newSettings;
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x0006034C File Offset: 0x0005E54C
		internal Volume GetOrCreateDefaultVolume()
		{
			if (this.s_DefaultVolume == null || this.s_DefaultVolume.Equals(null))
			{
				GameObject gameObject = new GameObject("Default Volume")
				{
					hideFlags = HideFlags.HideAndDontSave
				};
				this.s_DefaultVolume = gameObject.AddComponent<Volume>();
				this.s_DefaultVolume.isGlobal = true;
				this.s_DefaultVolume.priority = float.MinValue;
				this.s_DefaultVolume.sharedProfile = this.GetOrCreateDefaultVolumeProfile();
			}
			if (this.s_DefaultVolume.sharedProfile == null || this.s_DefaultVolume.sharedProfile.Equals(null))
			{
				this.s_DefaultVolume.sharedProfile = this.volumeProfile;
			}
			if (this.s_DefaultVolume.sharedProfile != this.volumeProfile)
			{
				this.s_DefaultVolume.sharedProfile = this.volumeProfile;
			}
			if (this.s_DefaultVolume == null)
			{
				Debug.LogError("[HDRP] Cannot Create Default Volume.");
			}
			return this.s_DefaultVolume;
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000BF4 RID: 3060 RVA: 0x0006043F File Offset: 0x0005E63F
		// (set) Token: 0x06000BF5 RID: 3061 RVA: 0x00060447 File Offset: 0x0005E647
		internal VolumeProfile volumeProfile
		{
			get
			{
				return this.m_DefaultVolumeProfile;
			}
			set
			{
				this.m_DefaultVolumeProfile = value;
			}
		}

		// Token: 0x06000BF6 RID: 3062 RVA: 0x00060450 File Offset: 0x0005E650
		internal VolumeProfile GetOrCreateDefaultVolumeProfile()
		{
			return this.volumeProfile;
		}

		// Token: 0x06000BF7 RID: 3063 RVA: 0x00060458 File Offset: 0x0005E658
		internal ref FrameSettings GetDefaultFrameSettings(FrameSettingsRenderType type)
		{
			switch (type)
			{
			case FrameSettingsRenderType.Camera:
				return ref this.m_RenderingPathDefaultCameraFrameSettings;
			case FrameSettingsRenderType.CustomOrBakedReflection:
				return ref this.m_RenderingPathDefaultBakedOrCustomReflectionFrameSettings;
			case FrameSettingsRenderType.RealtimeReflection:
				return ref this.m_RenderingPathDefaultRealtimeReflectionFrameSettings;
			default:
				throw new ArgumentException("Unknown FrameSettingsRenderType");
			}
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000BF8 RID: 3064 RVA: 0x0006048D File Offset: 0x0005E68D
		internal HDRenderPipelineRuntimeResources renderPipelineResources
		{
			get
			{
				return this.m_RenderPipelineResources;
			}
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000BF9 RID: 3065 RVA: 0x00060495 File Offset: 0x0005E695
		internal HDRenderPipelineRayTracingResources renderPipelineRayTracingResources
		{
			get
			{
				return this.m_RenderPipelineRayTracingResources;
			}
		}

		// Token: 0x06000BFA RID: 3066 RVA: 0x000604A0 File Offset: 0x0005E6A0
		public bool IsCustomPostProcessRegistered(Type customPostProcessType)
		{
			string assemblyQualifiedName = customPostProcessType.AssemblyQualifiedName;
			return this.beforeTransparentCustomPostProcesses.Contains(assemblyQualifiedName) || this.beforePostProcessCustomPostProcesses.Contains(assemblyQualifiedName) || this.afterPostProcessBlursCustomPostProcesses.Contains(assemblyQualifiedName) || this.afterPostProcessCustomPostProcesses.Contains(assemblyQualifiedName) || this.beforeTAACustomPostProcesses.Contains(assemblyQualifiedName);
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000BFB RID: 3067 RVA: 0x000604FC File Offset: 0x0005E6FC
		public string[] lightLayerNames
		{
			get
			{
				if (this.m_LightLayerNames == null)
				{
					this.m_LightLayerNames = new string[8];
				}
				this.m_LightLayerNames[0] = this.lightLayerName0;
				this.m_LightLayerNames[1] = this.lightLayerName1;
				this.m_LightLayerNames[2] = this.lightLayerName2;
				this.m_LightLayerNames[3] = this.lightLayerName3;
				this.m_LightLayerNames[4] = this.lightLayerName4;
				this.m_LightLayerNames[5] = this.lightLayerName5;
				this.m_LightLayerNames[6] = this.lightLayerName6;
				this.m_LightLayerNames[7] = this.lightLayerName7;
				return this.m_LightLayerNames;
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000BFC RID: 3068 RVA: 0x00060593 File Offset: 0x0005E793
		public string[] prefixedLightLayerNames
		{
			get
			{
				if (this.m_PrefixedLightLayerNames == null)
				{
					this.UpdateRenderingLayerNames();
				}
				return this.m_PrefixedLightLayerNames;
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000BFD RID: 3069 RVA: 0x000605AC File Offset: 0x0005E7AC
		public string[] decalLayerNames
		{
			get
			{
				if (this.m_DecalLayerNames == null)
				{
					this.m_DecalLayerNames = new string[8];
				}
				this.m_DecalLayerNames[0] = this.decalLayerName0;
				this.m_DecalLayerNames[1] = this.decalLayerName1;
				this.m_DecalLayerNames[2] = this.decalLayerName2;
				this.m_DecalLayerNames[3] = this.decalLayerName3;
				this.m_DecalLayerNames[4] = this.decalLayerName4;
				this.m_DecalLayerNames[5] = this.decalLayerName5;
				this.m_DecalLayerNames[6] = this.decalLayerName6;
				this.m_DecalLayerNames[7] = this.decalLayerName7;
				return this.m_DecalLayerNames;
			}
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000BFE RID: 3070 RVA: 0x00060643 File Offset: 0x0005E843
		public string[] prefixedDecalLayerNames
		{
			get
			{
				if (this.m_PrefixedDecalLayerNames == null)
				{
					this.UpdateRenderingLayerNames();
				}
				return this.m_PrefixedDecalLayerNames;
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000BFF RID: 3071 RVA: 0x00060659 File Offset: 0x0005E859
		private string[] renderingLayerNames
		{
			get
			{
				if (this.m_RenderingLayerNames == null)
				{
					this.UpdateRenderingLayerNames();
				}
				return this.m_RenderingLayerNames;
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000C00 RID: 3072 RVA: 0x0006066F File Offset: 0x0005E86F
		private string[] prefixedRenderingLayerNames
		{
			get
			{
				if (this.m_PrefixedRenderingLayerNames == null)
				{
					this.UpdateRenderingLayerNames();
				}
				return this.m_PrefixedRenderingLayerNames;
			}
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000C01 RID: 3073 RVA: 0x00060685 File Offset: 0x0005E885
		public string[] renderingLayerMaskNames
		{
			get
			{
				return this.renderingLayerNames;
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000C02 RID: 3074 RVA: 0x0006068D File Offset: 0x0005E88D
		public string[] prefixedRenderingLayerMaskNames
		{
			get
			{
				return this.prefixedRenderingLayerNames;
			}
		}

		// Token: 0x06000C03 RID: 3075 RVA: 0x00060698 File Offset: 0x0005E898
		internal void UpdateRenderingLayerNames()
		{
			if (this.m_RenderingLayerNames == null)
			{
				this.m_RenderingLayerNames = new string[32];
			}
			this.m_RenderingLayerNames[0] = this.lightLayerName0;
			this.m_RenderingLayerNames[1] = this.lightLayerName1;
			this.m_RenderingLayerNames[2] = this.lightLayerName2;
			this.m_RenderingLayerNames[3] = this.lightLayerName3;
			this.m_RenderingLayerNames[4] = this.lightLayerName4;
			this.m_RenderingLayerNames[5] = this.lightLayerName5;
			this.m_RenderingLayerNames[6] = this.lightLayerName6;
			this.m_RenderingLayerNames[7] = this.lightLayerName7;
			this.m_RenderingLayerNames[8] = this.decalLayerName0;
			this.m_RenderingLayerNames[9] = this.decalLayerName1;
			this.m_RenderingLayerNames[10] = this.decalLayerName2;
			this.m_RenderingLayerNames[11] = this.decalLayerName3;
			this.m_RenderingLayerNames[12] = this.decalLayerName4;
			this.m_RenderingLayerNames[13] = this.decalLayerName5;
			this.m_RenderingLayerNames[14] = this.decalLayerName6;
			this.m_RenderingLayerNames[15] = this.decalLayerName7;
			for (int i = 16; i < this.m_RenderingLayerNames.Length; i++)
			{
				this.m_RenderingLayerNames[i] = string.Format("Unused {0}", i);
			}
			if (this.m_PrefixedRenderingLayerNames == null)
			{
				this.m_PrefixedRenderingLayerNames = new string[32];
			}
			if (this.m_PrefixedLightLayerNames == null)
			{
				this.m_PrefixedLightLayerNames = new string[8];
			}
			if (this.m_PrefixedDecalLayerNames == null)
			{
				this.m_PrefixedDecalLayerNames = new string[8];
			}
			for (int j = 0; j < this.m_PrefixedRenderingLayerNames.Length; j++)
			{
				this.m_PrefixedRenderingLayerNames[j] = string.Format("{0}: {1}", j, this.m_RenderingLayerNames[j]);
				if (j < 8)
				{
					this.m_PrefixedLightLayerNames[j] = this.m_PrefixedRenderingLayerNames[j];
				}
				else if (j < 16)
				{
					this.m_PrefixedDecalLayerNames[j - 8] = string.Format("{0}: {1}", j - 8, this.m_RenderingLayerNames[j]);
				}
			}
		}

		// Token: 0x06000C04 RID: 3076 RVA: 0x0006087C File Offset: 0x0005EA7C
		internal void ResetRenderingLayerNames(bool lightLayers, bool decalLayers)
		{
			if (lightLayers)
			{
				this.lightLayerName0 = HDRenderPipelineGlobalSettings.k_DefaultLightLayerNames[0];
				this.lightLayerName1 = HDRenderPipelineGlobalSettings.k_DefaultLightLayerNames[1];
				this.lightLayerName2 = HDRenderPipelineGlobalSettings.k_DefaultLightLayerNames[2];
				this.lightLayerName3 = HDRenderPipelineGlobalSettings.k_DefaultLightLayerNames[3];
				this.lightLayerName4 = HDRenderPipelineGlobalSettings.k_DefaultLightLayerNames[4];
				this.lightLayerName5 = HDRenderPipelineGlobalSettings.k_DefaultLightLayerNames[5];
				this.lightLayerName6 = HDRenderPipelineGlobalSettings.k_DefaultLightLayerNames[6];
				this.lightLayerName7 = HDRenderPipelineGlobalSettings.k_DefaultLightLayerNames[7];
			}
			if (decalLayers)
			{
				this.decalLayerName0 = HDRenderPipelineGlobalSettings.k_DefaultDecalLayerNames[0];
				this.decalLayerName1 = HDRenderPipelineGlobalSettings.k_DefaultDecalLayerNames[1];
				this.decalLayerName2 = HDRenderPipelineGlobalSettings.k_DefaultDecalLayerNames[2];
				this.decalLayerName3 = HDRenderPipelineGlobalSettings.k_DefaultDecalLayerNames[3];
				this.decalLayerName4 = HDRenderPipelineGlobalSettings.k_DefaultDecalLayerNames[4];
				this.decalLayerName5 = HDRenderPipelineGlobalSettings.k_DefaultDecalLayerNames[5];
				this.decalLayerName6 = HDRenderPipelineGlobalSettings.k_DefaultDecalLayerNames[6];
				this.decalLayerName7 = HDRenderPipelineGlobalSettings.k_DefaultDecalLayerNames[7];
			}
			this.UpdateRenderingLayerNames();
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000C05 RID: 3077 RVA: 0x00060968 File Offset: 0x0005EB68
		// (set) Token: 0x06000C06 RID: 3078 RVA: 0x000609B4 File Offset: 0x0005EBB4
		internal DiffusionProfileSettings[] diffusionProfileSettingsList
		{
			get
			{
				DiffusionProfileList diffusionProfileList;
				if (HDRenderPipelineGlobalSettings.instance.volumeProfile != null && HDRenderPipelineGlobalSettings.instance.volumeProfile.TryGet<DiffusionProfileList>(out diffusionProfileList))
				{
					return diffusionProfileList.diffusionProfiles.value ?? HDRenderPipelineGlobalSettings.kEmptyProfiles;
				}
				return HDRenderPipelineGlobalSettings.kEmptyProfiles;
			}
			set
			{
				this.GetOrCreateDiffusionProfileList().diffusionProfiles.value = value;
			}
		}

		// Token: 0x06000C07 RID: 3079 RVA: 0x000609C8 File Offset: 0x0005EBC8
		internal DiffusionProfileList GetOrCreateDiffusionProfileList()
		{
			VolumeProfile orCreateDefaultVolumeProfile = HDRenderPipelineGlobalSettings.instance.GetOrCreateDefaultVolumeProfile();
			DiffusionProfileList diffusionProfileList;
			if (!orCreateDefaultVolumeProfile.TryGet<DiffusionProfileList>(out diffusionProfileList))
			{
				diffusionProfileList = orCreateDefaultVolumeProfile.Add<DiffusionProfileList>(true);
			}
			if (diffusionProfileList.diffusionProfiles.value == null)
			{
				diffusionProfileList.diffusionProfiles.value = new DiffusionProfileSettings[0];
			}
			return diffusionProfileList;
		}

		// Token: 0x06000C08 RID: 3080 RVA: 0x00060A11 File Offset: 0x0005EC11
		internal ProbeVolumeSceneData GetOrCreateAPVSceneData()
		{
			if (this.apvScenesData == null)
			{
				this.apvScenesData = new ProbeVolumeSceneData(this, "apvScenesData");
			}
			this.apvScenesData.SetParentObject(this, "apvScenesData");
			return this.apvScenesData;
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000C09 RID: 3081 RVA: 0x00060A43 File Offset: 0x0005EC43
		// (set) Token: 0x06000C0A RID: 3082 RVA: 0x00060A4B File Offset: 0x0005EC4B
		HDRenderPipelineGlobalSettings.Version IVersionable<HDRenderPipelineGlobalSettings.Version>.version
		{
			get
			{
				return this.m_Version;
			}
			set
			{
				this.m_Version = value;
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000C0B RID: 3083 RVA: 0x00060A54 File Offset: 0x0005EC54
		// (set) Token: 0x06000C0C RID: 3084 RVA: 0x00060A5C File Offset: 0x0005EC5C
		public ShaderVariantLogLevel shaderVariantLogLevel
		{
			get
			{
				return this.m_ShaderVariantLogLevel;
			}
			set
			{
				this.m_ShaderVariantLogLevel = value;
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000C0D RID: 3085 RVA: 0x00060A65 File Offset: 0x0005EC65
		// (set) Token: 0x06000C0E RID: 3086 RVA: 0x00060A6D File Offset: 0x0005EC6D
		public bool exportShaderVariants
		{
			get
			{
				return this.m_ExportShaderVariants;
			}
			set
			{
				this.m_ExportShaderVariants = true;
			}
		}

		// Token: 0x04000E2D RID: 3629
		private static HDRenderPipelineGlobalSettings cachedInstance = null;

		// Token: 0x04000E2E RID: 3630
		private Volume s_DefaultVolume;

		// Token: 0x04000E2F RID: 3631
		[SerializeField]
		[FormerlySerializedAs("m_VolumeProfileDefault")]
		private VolumeProfile m_DefaultVolumeProfile;

		// Token: 0x04000E30 RID: 3632
		[SerializeField]
		private FrameSettings m_RenderingPathDefaultCameraFrameSettings = FrameSettings.NewDefaultCamera();

		// Token: 0x04000E31 RID: 3633
		[SerializeField]
		private FrameSettings m_RenderingPathDefaultBakedOrCustomReflectionFrameSettings = FrameSettings.NewDefaultCustomOrBakeReflectionProbe();

		// Token: 0x04000E32 RID: 3634
		[SerializeField]
		private FrameSettings m_RenderingPathDefaultRealtimeReflectionFrameSettings = FrameSettings.NewDefaultRealtimeReflectionProbe();

		// Token: 0x04000E33 RID: 3635
		[SerializeField]
		private HDRenderPipelineRuntimeResources m_RenderPipelineResources;

		// Token: 0x04000E34 RID: 3636
		[SerializeField]
		private HDRenderPipelineRayTracingResources m_RenderPipelineRayTracingResources;

		// Token: 0x04000E35 RID: 3637
		[SerializeField]
		internal List<string> beforeTransparentCustomPostProcesses = new List<string>();

		// Token: 0x04000E36 RID: 3638
		[SerializeField]
		internal List<string> beforePostProcessCustomPostProcesses = new List<string>();

		// Token: 0x04000E37 RID: 3639
		[SerializeField]
		internal List<string> afterPostProcessBlursCustomPostProcesses = new List<string>();

		// Token: 0x04000E38 RID: 3640
		[SerializeField]
		internal List<string> afterPostProcessCustomPostProcesses = new List<string>();

		// Token: 0x04000E39 RID: 3641
		[SerializeField]
		internal List<string> beforeTAACustomPostProcesses = new List<string>();

		// Token: 0x04000E3A RID: 3642
		private static readonly string[] k_DefaultLightLayerNames = new string[]
		{
			"Light Layer default",
			"Light Layer 1",
			"Light Layer 2",
			"Light Layer 3",
			"Light Layer 4",
			"Light Layer 5",
			"Light Layer 6",
			"Light Layer 7"
		};

		// Token: 0x04000E3B RID: 3643
		public string lightLayerName0 = HDRenderPipelineGlobalSettings.k_DefaultLightLayerNames[0];

		// Token: 0x04000E3C RID: 3644
		public string lightLayerName1 = HDRenderPipelineGlobalSettings.k_DefaultLightLayerNames[1];

		// Token: 0x04000E3D RID: 3645
		public string lightLayerName2 = HDRenderPipelineGlobalSettings.k_DefaultLightLayerNames[2];

		// Token: 0x04000E3E RID: 3646
		public string lightLayerName3 = HDRenderPipelineGlobalSettings.k_DefaultLightLayerNames[3];

		// Token: 0x04000E3F RID: 3647
		public string lightLayerName4 = HDRenderPipelineGlobalSettings.k_DefaultLightLayerNames[4];

		// Token: 0x04000E40 RID: 3648
		public string lightLayerName5 = HDRenderPipelineGlobalSettings.k_DefaultLightLayerNames[5];

		// Token: 0x04000E41 RID: 3649
		public string lightLayerName6 = HDRenderPipelineGlobalSettings.k_DefaultLightLayerNames[6];

		// Token: 0x04000E42 RID: 3650
		public string lightLayerName7 = HDRenderPipelineGlobalSettings.k_DefaultLightLayerNames[7];

		// Token: 0x04000E43 RID: 3651
		[NonSerialized]
		private string[] m_LightLayerNames;

		// Token: 0x04000E44 RID: 3652
		[NonSerialized]
		private string[] m_PrefixedLightLayerNames;

		// Token: 0x04000E45 RID: 3653
		private static readonly string[] k_DefaultDecalLayerNames = new string[]
		{
			"Decal Layer default",
			"Decal Layer 1",
			"Decal Layer 2",
			"Decal Layer 3",
			"Decal Layer 4",
			"Decal Layer 5",
			"Decal Layer 6",
			"Decal Layer 7"
		};

		// Token: 0x04000E46 RID: 3654
		public string decalLayerName0 = HDRenderPipelineGlobalSettings.k_DefaultDecalLayerNames[0];

		// Token: 0x04000E47 RID: 3655
		public string decalLayerName1 = HDRenderPipelineGlobalSettings.k_DefaultDecalLayerNames[1];

		// Token: 0x04000E48 RID: 3656
		public string decalLayerName2 = HDRenderPipelineGlobalSettings.k_DefaultDecalLayerNames[2];

		// Token: 0x04000E49 RID: 3657
		public string decalLayerName3 = HDRenderPipelineGlobalSettings.k_DefaultDecalLayerNames[3];

		// Token: 0x04000E4A RID: 3658
		public string decalLayerName4 = HDRenderPipelineGlobalSettings.k_DefaultDecalLayerNames[4];

		// Token: 0x04000E4B RID: 3659
		public string decalLayerName5 = HDRenderPipelineGlobalSettings.k_DefaultDecalLayerNames[5];

		// Token: 0x04000E4C RID: 3660
		public string decalLayerName6 = HDRenderPipelineGlobalSettings.k_DefaultDecalLayerNames[6];

		// Token: 0x04000E4D RID: 3661
		public string decalLayerName7 = HDRenderPipelineGlobalSettings.k_DefaultDecalLayerNames[7];

		// Token: 0x04000E4E RID: 3662
		[NonSerialized]
		private string[] m_DecalLayerNames;

		// Token: 0x04000E4F RID: 3663
		[NonSerialized]
		private string[] m_PrefixedDecalLayerNames;

		// Token: 0x04000E50 RID: 3664
		[NonSerialized]
		private string[] m_RenderingLayerNames;

		// Token: 0x04000E51 RID: 3665
		[NonSerialized]
		private string[] m_PrefixedRenderingLayerNames;

		// Token: 0x04000E52 RID: 3666
		[SerializeField]
		internal LensAttenuationMode lensAttenuationMode;

		// Token: 0x04000E53 RID: 3667
		[SerializeField]
		internal ColorGradingSpace colorGradingSpace;

		// Token: 0x04000E54 RID: 3668
		[SerializeField]
		[FormerlySerializedAs("diffusionProfileSettingsList")]
		internal DiffusionProfileSettings[] m_ObsoleteDiffusionProfileSettingsList;

		// Token: 0x04000E55 RID: 3669
		[SerializeField]
		internal bool rendererListCulling;

		// Token: 0x04000E56 RID: 3670
		private static readonly DiffusionProfileSettings[] kEmptyProfiles = new DiffusionProfileSettings[0];

		// Token: 0x04000E57 RID: 3671
		[SerializeField]
		internal string DLSSProjectId = "000000";

		// Token: 0x04000E58 RID: 3672
		[SerializeField]
		internal bool useDLSSCustomProjectId;

		// Token: 0x04000E59 RID: 3673
		[SerializeField]
		internal bool supportProbeVolumes;

		// Token: 0x04000E5A RID: 3674
		public bool supportRuntimeDebugDisplay;

		// Token: 0x04000E5B RID: 3675
		public bool autoRegisterDiffusionProfiles = true;

		// Token: 0x04000E5C RID: 3676
		[SerializeField]
		internal ProbeVolumeSceneData apvScenesData;

		// Token: 0x04000E5D RID: 3677
		private static HDRenderPipelineGlobalSettings.Version[] skipedStepWhenCreatedFromHDRPAsset = new HDRenderPipelineGlobalSettings.Version[0];

		// Token: 0x04000E5E RID: 3678
		[SerializeField]
		private HDRenderPipelineGlobalSettings.Version m_Version = MigrationDescription.LastVersion<HDRenderPipelineGlobalSettings.Version>();

		// Token: 0x04000E5F RID: 3679
		[SerializeField]
		[FormerlySerializedAs("shaderVariantLogLevel")]
		internal ShaderVariantLogLevel m_ShaderVariantLogLevel;

		// Token: 0x04000E60 RID: 3680
		[SerializeField]
		internal bool m_ExportShaderVariants = true;

		// Token: 0x020003BF RID: 959
		private enum Version
		{
			// Token: 0x0400266F RID: 9839
			First,
			// Token: 0x04002670 RID: 9840
			UpdateMSAA,
			// Token: 0x04002671 RID: 9841
			UpdateLensFlare,
			// Token: 0x04002672 RID: 9842
			MovedSupportRuntimeDebugDisplayToGlobalSettings,
			// Token: 0x04002673 RID: 9843
			DisableAutoRegistration,
			// Token: 0x04002674 RID: 9844
			MoveDiffusionProfilesToVolume
		}
	}
}
