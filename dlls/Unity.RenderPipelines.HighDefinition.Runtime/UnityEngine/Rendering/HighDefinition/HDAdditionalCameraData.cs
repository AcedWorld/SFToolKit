using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000155 RID: 341
	[AddComponentMenu("")]
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[RequireComponent(typeof(Camera))]
	public class HDAdditionalCameraData : MonoBehaviour, IFrameSettingsHistoryContainer, IDebugData, IAdditionalData, IVersionable<HDAdditionalCameraData.Version>
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000B0C RID: 2828 RVA: 0x0005B570 File Offset: 0x00059770
		// (remove) Token: 0x06000B0D RID: 2829 RVA: 0x0005B5A8 File Offset: 0x000597A8
		public event Action<ScriptableRenderContext, HDCamera> customRender;

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000B0E RID: 2830 RVA: 0x0005B5DD File Offset: 0x000597DD
		public bool hasCustomRender
		{
			get
			{
				return this.customRender != null;
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000B0F RID: 2831 RVA: 0x0005B5E8 File Offset: 0x000597E8
		// (remove) Token: 0x06000B10 RID: 2832 RVA: 0x0005B620 File Offset: 0x00059820
		public event HDAdditionalCameraData.RequestAccessDelegate requestGraphicsBuffer;

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000B11 RID: 2833 RVA: 0x0005B655 File Offset: 0x00059855
		public ref FrameSettings renderingPathCustomFrameSettings
		{
			get
			{
				return ref this.m_RenderingPathCustomFrameSettings;
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000B12 RID: 2834 RVA: 0x0005B65D File Offset: 0x0005985D
		bool IFrameSettingsHistoryContainer.hasCustomFrameSettings
		{
			get
			{
				return this.customRenderingSettings;
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000B13 RID: 2835 RVA: 0x0005B665 File Offset: 0x00059865
		FrameSettingsOverrideMask IFrameSettingsHistoryContainer.frameSettingsMask
		{
			get
			{
				return this.renderingPathCustomFrameSettingsOverrideMask;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000B14 RID: 2836 RVA: 0x0005B66D File Offset: 0x0005986D
		FrameSettings IFrameSettingsHistoryContainer.frameSettings
		{
			get
			{
				return this.m_RenderingPathCustomFrameSettings;
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000B15 RID: 2837 RVA: 0x0005B675 File Offset: 0x00059875
		// (set) Token: 0x06000B16 RID: 2838 RVA: 0x0005B67D File Offset: 0x0005987D
		FrameSettingsHistory IFrameSettingsHistoryContainer.frameSettingsHistory
		{
			get
			{
				return this.m_RenderingPathHistory;
			}
			set
			{
				this.m_RenderingPathHistory = value;
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000B17 RID: 2839 RVA: 0x0005B686 File Offset: 0x00059886
		string IFrameSettingsHistoryContainer.panelName
		{
			get
			{
				return this.m_CameraRegisterName;
			}
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x0005B68E File Offset: 0x0005988E
		Action IDebugData.GetReset()
		{
			return delegate()
			{
				this.m_RenderingPathHistory.TriggerReset();
			};
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x0005B69C File Offset: 0x0005989C
		public void SetAOVRequests(AOVRequestDataCollection aovRequests)
		{
			this.m_AOVRequestDataCollection = aovRequests;
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000B1A RID: 2842 RVA: 0x0005B6A8 File Offset: 0x000598A8
		public IEnumerable<AOVRequestData> aovRequests
		{
			get
			{
				AOVRequestDataCollection result;
				if ((result = this.m_AOVRequestDataCollection) == null)
				{
					result = (this.m_AOVRequestDataCollection = new AOVRequestDataCollection(null));
				}
				return result;
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06000B1B RID: 2843 RVA: 0x0005B6CE File Offset: 0x000598CE
		// (set) Token: 0x06000B1C RID: 2844 RVA: 0x0005B6D6 File Offset: 0x000598D6
		public bool isEditorCameraPreview { get; internal set; }

		// Token: 0x06000B1D RID: 2845 RVA: 0x0005B6E0 File Offset: 0x000598E0
		public unsafe void CopyTo(HDAdditionalCameraData data)
		{
			data.clearColorMode = this.clearColorMode;
			data.backgroundColorHDR = this.backgroundColorHDR;
			data.clearDepth = this.clearDepth;
			data.customRenderingSettings = this.customRenderingSettings;
			data.volumeLayerMask = this.volumeLayerMask;
			data.volumeAnchorOverride = this.volumeAnchorOverride;
			data.antialiasing = this.antialiasing;
			data.dithering = this.dithering;
			data.xrRendering = this.xrRendering;
			data.SMAAQuality = this.SMAAQuality;
			data.stopNaNs = this.stopNaNs;
			data.taaSharpenStrength = this.taaSharpenStrength;
			data.TAAQuality = this.TAAQuality;
			data.taaHistorySharpening = this.taaHistorySharpening;
			data.taaAntiFlicker = this.taaAntiFlicker;
			data.taaMotionVectorRejection = this.taaMotionVectorRejection;
			data.taaAntiHistoryRinging = this.taaAntiHistoryRinging;
			data.taaBaseBlendFactor = this.taaBaseBlendFactor;
			data.taaJitterScale = this.taaJitterScale;
			data.flipYMode = this.flipYMode;
			data.fullscreenPassthrough = this.fullscreenPassthrough;
			data.allowDynamicResolution = this.allowDynamicResolution;
			data.invertFaceCulling = this.invertFaceCulling;
			data.probeLayerMask = this.probeLayerMask;
			data.hasPersistentHistory = this.hasPersistentHistory;
			data.exposureTarget = this.exposureTarget;
			data.physicalParameters = this.physicalParameters;
			*data.renderingPathCustomFrameSettings = *this.renderingPathCustomFrameSettings;
			data.renderingPathCustomFrameSettingsOverrideMask = this.renderingPathCustomFrameSettingsOverrideMask;
			data.defaultFrameSettings = this.defaultFrameSettings;
			data.probeCustomFixedExposure = this.probeCustomFixedExposure;
			data.allowDeepLearningSuperSampling = this.allowDeepLearningSuperSampling;
			data.deepLearningSuperSamplingUseCustomQualitySettings = this.deepLearningSuperSamplingUseCustomQualitySettings;
			data.deepLearningSuperSamplingQuality = this.deepLearningSuperSamplingQuality;
			data.deepLearningSuperSamplingUseCustomAttributes = this.deepLearningSuperSamplingUseCustomAttributes;
			data.deepLearningSuperSamplingUseOptimalSettings = this.deepLearningSuperSamplingUseOptimalSettings;
			data.deepLearningSuperSamplingSharpening = this.deepLearningSuperSamplingSharpening;
			data.fsrOverrideSharpness = this.fsrOverrideSharpness;
			data.fsrSharpness = this.fsrSharpness;
			data.materialMipBias = this.materialMipBias;
			data.screenSizeOverride = this.screenSizeOverride;
			data.screenCoordScaleBias = this.screenCoordScaleBias;
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x0005B8EF File Offset: 0x00059AEF
		public Matrix4x4 GetNonObliqueProjection(Camera camera)
		{
			return this.nonObliqueProjectionGetter(camera);
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x0005B8FD File Offset: 0x00059AFD
		private void RegisterDebug()
		{
			if (!this.m_IsDebugRegistered)
			{
				this.m_CameraRegisterName = base.name;
				if (this.m_Camera.cameraType != CameraType.Preview && this.m_Camera.cameraType != CameraType.Reflection)
				{
					DebugDisplaySettings.RegisterCamera(this);
				}
				this.m_IsDebugRegistered = true;
			}
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x0005B93D File Offset: 0x00059B3D
		private void UnRegisterDebug()
		{
			if (this.m_IsDebugRegistered)
			{
				if (this.m_Camera.cameraType != CameraType.Preview)
				{
					Camera camera = this.m_Camera;
					if (camera == null || camera.cameraType != CameraType.Reflection)
					{
						DebugDisplaySettings.UnRegisterCamera(this);
					}
				}
				this.m_IsDebugRegistered = false;
			}
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x0005B980 File Offset: 0x00059B80
		private void OnEnable()
		{
			this.m_Camera = base.GetComponent<Camera>();
			if (this.m_Camera == null)
			{
				return;
			}
			this.m_Camera.allowMSAA = false;
			this.m_Camera.allowHDR = false;
			FrameSettings frameSettings = default(FrameSettings);
			FrameSettingsHistory.AggregateFrameSettings(ref frameSettings, this.m_Camera, this, HDRenderPipeline.currentAsset, null);
			this.RegisterDebug();
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x0005B9E2 File Offset: 0x00059BE2
		private void UpdateDebugCameraName()
		{
			this.profilingSampler = new ProfilingSampler(HDUtils.ComputeCameraName(base.name));
			if (base.name != this.m_CameraRegisterName)
			{
				this.UnRegisterDebug();
				this.RegisterDebug();
			}
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x0005BA19 File Offset: 0x00059C19
		private void OnDisable()
		{
			this.UnRegisterDebug();
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x0005BA24 File Offset: 0x00059C24
		internal static void InitDefaultHDAdditionalCameraData(HDAdditionalCameraData cameraData)
		{
			Camera component = cameraData.gameObject.GetComponent<Camera>();
			cameraData.clearDepth = (component.clearFlags != CameraClearFlags.Nothing);
			if (component.clearFlags == CameraClearFlags.Skybox)
			{
				cameraData.clearColorMode = HDAdditionalCameraData.ClearColorMode.Sky;
				return;
			}
			if (component.clearFlags == CameraClearFlags.Color)
			{
				cameraData.clearColorMode = HDAdditionalCameraData.ClearColorMode.Color;
				return;
			}
			cameraData.clearColorMode = HDAdditionalCameraData.ClearColorMode.None;
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x0005BA78 File Offset: 0x00059C78
		internal void ExecuteCustomRender(ScriptableRenderContext renderContext, HDCamera hdCamera)
		{
			if (this.customRender != null)
			{
				this.customRender(renderContext, hdCamera);
			}
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x0005BA90 File Offset: 0x00059C90
		internal HDAdditionalCameraData.BufferAccessType GetBufferAccess()
		{
			HDAdditionalCameraData.BufferAccess bufferAccess = default(HDAdditionalCameraData.BufferAccess);
			HDAdditionalCameraData.RequestAccessDelegate requestAccessDelegate = this.requestGraphicsBuffer;
			if (requestAccessDelegate != null)
			{
				requestAccessDelegate(ref bufferAccess);
			}
			return bufferAccess.bufferAccess;
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x0005BAC0 File Offset: 0x00059CC0
		public RTHandle GetGraphicsBuffer(HDAdditionalCameraData.BufferAccessType type)
		{
			HDCamera orCreate = HDCamera.GetOrCreate(this.m_Camera, 0);
			if ((type & HDAdditionalCameraData.BufferAccessType.Color) != (HDAdditionalCameraData.BufferAccessType)0)
			{
				return orCreate.GetCurrentFrameRT(0);
			}
			if ((type & HDAdditionalCameraData.BufferAccessType.Depth) != (HDAdditionalCameraData.BufferAccessType)0)
			{
				return orCreate.GetCurrentFrameRT(6);
			}
			if ((type & HDAdditionalCameraData.BufferAccessType.Normal) != (HDAdditionalCameraData.BufferAccessType)0)
			{
				return orCreate.GetCurrentFrameRT(5);
			}
			return null;
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06000B28 RID: 2856 RVA: 0x0005BB02 File Offset: 0x00059D02
		// (set) Token: 0x06000B29 RID: 2857 RVA: 0x0005BB0A File Offset: 0x00059D0A
		HDAdditionalCameraData.Version IVersionable<HDAdditionalCameraData.Version>.version
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

		// Token: 0x06000B2A RID: 2858 RVA: 0x0005BB14 File Offset: 0x00059D14
		private void Awake()
		{
			HDAdditionalCameraData.k_Migration.Migrate(this);
		}

		// Token: 0x04000C3A RID: 3130
		[ExcludeCopy]
		private Camera m_Camera;

		// Token: 0x04000C3B RID: 3131
		public HDAdditionalCameraData.ClearColorMode clearColorMode;

		// Token: 0x04000C3C RID: 3132
		[ColorUsage(true, true)]
		public Color backgroundColorHDR = new Color(0.025f, 0.07f, 0.19f, 0f);

		// Token: 0x04000C3D RID: 3133
		public bool clearDepth = true;

		// Token: 0x04000C3E RID: 3134
		[Tooltip("LayerMask HDRP uses for Volume interpolation for this Camera.")]
		public LayerMask volumeLayerMask = 1;

		// Token: 0x04000C3F RID: 3135
		public Transform volumeAnchorOverride;

		// Token: 0x04000C40 RID: 3136
		public HDAdditionalCameraData.AntialiasingMode antialiasing;

		// Token: 0x04000C41 RID: 3137
		public HDAdditionalCameraData.SMAAQualityLevel SMAAQuality = HDAdditionalCameraData.SMAAQualityLevel.High;

		// Token: 0x04000C42 RID: 3138
		public bool dithering;

		// Token: 0x04000C43 RID: 3139
		public bool stopNaNs;

		// Token: 0x04000C44 RID: 3140
		[Range(0f, 2f)]
		public float taaSharpenStrength = 0.5f;

		// Token: 0x04000C45 RID: 3141
		public HDAdditionalCameraData.TAAQualityLevel TAAQuality = HDAdditionalCameraData.TAAQualityLevel.Medium;

		// Token: 0x04000C46 RID: 3142
		[Range(0f, 1f)]
		public float taaHistorySharpening = 0.35f;

		// Token: 0x04000C47 RID: 3143
		[Range(0f, 1f)]
		public float taaAntiFlicker = 0.5f;

		// Token: 0x04000C48 RID: 3144
		[Range(0f, 1f)]
		public float taaMotionVectorRejection;

		// Token: 0x04000C49 RID: 3145
		public bool taaAntiHistoryRinging;

		// Token: 0x04000C4A RID: 3146
		[Range(0.6f, 0.95f)]
		public float taaBaseBlendFactor = 0.875f;

		// Token: 0x04000C4B RID: 3147
		[Range(0.1f, 1f)]
		public float taaJitterScale = 1f;

		// Token: 0x04000C4C RID: 3148
		[ValueCopy]
		[Obsolete("Physical camera properties have been migrated to Camera.", false)]
		public HDPhysicalCamera physicalParameters = HDPhysicalCamera.GetDefaults();

		// Token: 0x04000C4D RID: 3149
		public HDAdditionalCameraData.FlipYMode flipYMode;

		// Token: 0x04000C4E RID: 3150
		public bool xrRendering = true;

		// Token: 0x04000C4F RID: 3151
		[Tooltip("Skips rendering settings to directly render in fullscreen (Useful for video).")]
		public bool fullscreenPassthrough;

		// Token: 0x04000C50 RID: 3152
		[Tooltip("Allows dynamic resolution on buffers linked to this camera.")]
		public bool allowDynamicResolution;

		// Token: 0x04000C51 RID: 3153
		[Tooltip("Allows you to override the default settings for this camera.")]
		public bool customRenderingSettings;

		// Token: 0x04000C52 RID: 3154
		public bool invertFaceCulling;

		// Token: 0x04000C53 RID: 3155
		public LayerMask probeLayerMask = -1;

		// Token: 0x04000C54 RID: 3156
		public bool hasPersistentHistory;

		// Token: 0x04000C55 RID: 3157
		public Vector4 screenSizeOverride;

		// Token: 0x04000C56 RID: 3158
		public Vector4 screenCoordScaleBias;

		// Token: 0x04000C57 RID: 3159
		[Tooltip("Allow NVIDIA Deep Learning Super Sampling (DLSS) on this camera")]
		public bool allowDeepLearningSuperSampling = true;

		// Token: 0x04000C58 RID: 3160
		[Tooltip("If set to true, NVIDIA Deep Learning Super Sampling (DLSS) will utilize the Quality setting set on this camera instead of the one specified in the quality asset.")]
		public bool deepLearningSuperSamplingUseCustomQualitySettings;

		// Token: 0x04000C59 RID: 3161
		[Tooltip("Selects a performance quality setting for NVIDIA Deep Learning Super Sampling (DLSS) for this camera of this project.")]
		public uint deepLearningSuperSamplingQuality;

		// Token: 0x04000C5A RID: 3162
		[Tooltip("If set to true, NVIDIA Deep Learning Super Sampling (DLSS) will utilize the attributes (Optimal Settings and Sharpness) specified on this camera, instead of the ones specified in the quality asset of this project.")]
		public bool deepLearningSuperSamplingUseCustomAttributes;

		// Token: 0x04000C5B RID: 3163
		[Tooltip("Sets the sharpness and scale automatically for NVIDIA Deep Learning Super Sampling (DLSS) for this camera, depending on the values of quality settings.")]
		public bool deepLearningSuperSamplingUseOptimalSettings = true;

		// Token: 0x04000C5C RID: 3164
		[Tooltip("Sets the Sharpening value for NVIDIA Deep Learning Super Sampling (DLSS) for this camera.")]
		[Range(0f, 1f)]
		public float deepLearningSuperSamplingSharpening;

		// Token: 0x04000C5D RID: 3165
		[ExcludeCopy]
		internal bool cameraCanRenderDLSS;

		// Token: 0x04000C5E RID: 3166
		[Tooltip("If set to true, AMD FidelityFX Super Resolution (FSR) will utilize the sharpness setting set on this camera instead of the one specified in the quality asset.")]
		public bool fsrOverrideSharpness;

		// Token: 0x04000C5F RID: 3167
		[Tooltip("Sets this camera's sharpness value for AMD FidelityFX Super Resolution 1.0 (FSR).")]
		[Range(0f, 1f)]
		public float fsrSharpness = 0.92f;

		// Token: 0x04000C62 RID: 3170
		public GameObject exposureTarget;

		// Token: 0x04000C63 RID: 3171
		public float materialMipBias;

		// Token: 0x04000C64 RID: 3172
		internal float probeCustomFixedExposure = 1f;

		// Token: 0x04000C65 RID: 3173
		[ExcludeCopy]
		internal float deExposureMultiplier = 1f;

		// Token: 0x04000C66 RID: 3174
		[SerializeField]
		[FormerlySerializedAs("renderingPathCustomFrameSettings")]
		private FrameSettings m_RenderingPathCustomFrameSettings = FrameSettings.NewDefaultCamera();

		// Token: 0x04000C67 RID: 3175
		public FrameSettingsOverrideMask renderingPathCustomFrameSettingsOverrideMask;

		// Token: 0x04000C68 RID: 3176
		public FrameSettingsRenderType defaultFrameSettings;

		// Token: 0x04000C69 RID: 3177
		[ExcludeCopy]
		private FrameSettingsHistory m_RenderingPathHistory = new FrameSettingsHistory
		{
			defaultType = FrameSettingsRenderType.Camera
		};

		// Token: 0x04000C6A RID: 3178
		[ExcludeCopy]
		internal ProfilingSampler profilingSampler;

		// Token: 0x04000C6B RID: 3179
		[ExcludeCopy]
		private AOVRequestDataCollection m_AOVRequestDataCollection = new AOVRequestDataCollection(null);

		// Token: 0x04000C6C RID: 3180
		[ExcludeCopy]
		private bool m_IsDebugRegistered;

		// Token: 0x04000C6D RID: 3181
		[ExcludeCopy]
		private string m_CameraRegisterName;

		// Token: 0x04000C6F RID: 3183
		[ExcludeCopy]
		public HDAdditionalCameraData.NonObliqueProjectionGetter nonObliqueProjectionGetter = new HDAdditionalCameraData.NonObliqueProjectionGetter(GeometryUtils.CalculateProjectionMatrix);

		// Token: 0x04000C70 RID: 3184
		[SerializeField]
		[FormerlySerializedAs("version")]
		[ExcludeCopy]
		private HDAdditionalCameraData.Version m_Version = MigrationDescription.LastVersion<HDAdditionalCameraData.Version>();

		// Token: 0x04000C71 RID: 3185
		private static readonly MigrationDescription<HDAdditionalCameraData.Version, HDAdditionalCameraData> k_Migration = MigrationDescription.New<HDAdditionalCameraData.Version, HDAdditionalCameraData>(new MigrationStep<HDAdditionalCameraData.Version, HDAdditionalCameraData>[]
		{
			MigrationStep.New<HDAdditionalCameraData.Version, HDAdditionalCameraData>(HDAdditionalCameraData.Version.SeparatePassThrough, delegate(HDAdditionalCameraData data)
			{
				switch (data.m_ObsoleteRenderingPath)
				{
				case 0:
					data.fullscreenPassthrough = false;
					data.customRenderingSettings = false;
					return;
				case 1:
					data.fullscreenPassthrough = false;
					data.customRenderingSettings = true;
					return;
				case 2:
					data.fullscreenPassthrough = true;
					data.customRenderingSettings = false;
					return;
				default:
					return;
				}
			}),
			MigrationStep.New<HDAdditionalCameraData.Version, HDAdditionalCameraData>(HDAdditionalCameraData.Version.UpgradingFrameSettingsToStruct, delegate(HDAdditionalCameraData data)
			{
				if (data.m_ObsoleteFrameSettings != null)
				{
					FrameSettings.MigrateFromClassVersion(ref data.m_ObsoleteFrameSettings, data.renderingPathCustomFrameSettings, ref data.renderingPathCustomFrameSettingsOverrideMask);
				}
			}),
			MigrationStep.New<HDAdditionalCameraData.Version, HDAdditionalCameraData>(HDAdditionalCameraData.Version.AddAfterPostProcessFrameSetting, delegate(HDAdditionalCameraData data)
			{
				FrameSettings.MigrateToAfterPostprocess(data.renderingPathCustomFrameSettings);
			}),
			MigrationStep.New<HDAdditionalCameraData.Version, HDAdditionalCameraData>(HDAdditionalCameraData.Version.AddReflectionSettings, delegate(HDAdditionalCameraData data)
			{
				FrameSettings.MigrateToDefaultReflectionSettings(data.renderingPathCustomFrameSettings);
			}),
			MigrationStep.New<HDAdditionalCameraData.Version, HDAdditionalCameraData>(HDAdditionalCameraData.Version.AddCustomPostprocessAndCustomPass, delegate(HDAdditionalCameraData data)
			{
				FrameSettings.MigrateToCustomPostprocessAndCustomPass(data.renderingPathCustomFrameSettings);
			}),
			MigrationStep.New<HDAdditionalCameraData.Version, HDAdditionalCameraData>(HDAdditionalCameraData.Version.UpdateMSAA, delegate(HDAdditionalCameraData data)
			{
				FrameSettings.MigrateMSAA(data.renderingPathCustomFrameSettings, ref data.renderingPathCustomFrameSettingsOverrideMask);
			}),
			MigrationStep.New<HDAdditionalCameraData.Version, HDAdditionalCameraData>(HDAdditionalCameraData.Version.UpdatePhysicalCameraPropertiesToCore, delegate(HDAdditionalCameraData data)
			{
				Camera component = data.GetComponent<Camera>();
				HDPhysicalCamera hdphysicalCamera = data.physicalParameters;
				if (component != null)
				{
					component.iso = hdphysicalCamera.iso;
					component.shutterSpeed = hdphysicalCamera.shutterSpeed;
					component.aperture = hdphysicalCamera.aperture;
					component.focusDistance = hdphysicalCamera.focusDistance;
					component.bladeCount = hdphysicalCamera.bladeCount;
					component.curvature = hdphysicalCamera.curvature;
					component.barrelClipping = hdphysicalCamera.barrelClipping;
					component.anamorphism = hdphysicalCamera.anamorphism;
				}
			})
		});

		// Token: 0x04000C72 RID: 3186
		[SerializeField]
		[FormerlySerializedAs("renderingPath")]
		[Obsolete("For Data Migration")]
		[ExcludeCopy]
		private int m_ObsoleteRenderingPath;

		// Token: 0x04000C73 RID: 3187
		[SerializeField]
		[FormerlySerializedAs("serializedFrameSettings")]
		[FormerlySerializedAs("m_FrameSettings")]
		[ExcludeCopy]
		private ObsoleteFrameSettings m_ObsoleteFrameSettings;

		// Token: 0x020003A4 RID: 932
		public enum FlipYMode
		{
			// Token: 0x040025E7 RID: 9703
			Automatic,
			// Token: 0x040025E8 RID: 9704
			ForceFlipY
		}

		// Token: 0x020003A5 RID: 933
		[Flags]
		public enum BufferAccessType
		{
			// Token: 0x040025EA RID: 9706
			Depth = 1,
			// Token: 0x040025EB RID: 9707
			Normal = 2,
			// Token: 0x040025EC RID: 9708
			Color = 4
		}

		// Token: 0x020003A6 RID: 934
		public struct BufferAccess
		{
			// Token: 0x0600132E RID: 4910 RVA: 0x00092E21 File Offset: 0x00091021
			internal void Reset()
			{
				this.bufferAccess = (HDAdditionalCameraData.BufferAccessType)0;
			}

			// Token: 0x0600132F RID: 4911 RVA: 0x00092E2A File Offset: 0x0009102A
			public void RequestAccess(HDAdditionalCameraData.BufferAccessType flags)
			{
				this.bufferAccess |= flags;
			}

			// Token: 0x040025ED RID: 9709
			internal HDAdditionalCameraData.BufferAccessType bufferAccess;
		}

		// Token: 0x020003A7 RID: 935
		// (Invoke) Token: 0x06001331 RID: 4913
		public delegate Matrix4x4 NonObliqueProjectionGetter(Camera camera);

		// Token: 0x020003A8 RID: 936
		public enum ClearColorMode
		{
			// Token: 0x040025EF RID: 9711
			Sky,
			// Token: 0x040025F0 RID: 9712
			Color,
			// Token: 0x040025F1 RID: 9713
			None
		}

		// Token: 0x020003A9 RID: 937
		public enum AntialiasingMode
		{
			// Token: 0x040025F3 RID: 9715
			[InspectorName("No Anti-aliasing")]
			None,
			// Token: 0x040025F4 RID: 9716
			[InspectorName("Fast Approximate Anti-aliasing (FXAA)")]
			FastApproximateAntialiasing,
			// Token: 0x040025F5 RID: 9717
			[InspectorName("Temporal Anti-aliasing (TAA)")]
			TemporalAntialiasing,
			// Token: 0x040025F6 RID: 9718
			[InspectorName("Subpixel Morphological Anti-aliasing (SMAA)")]
			SubpixelMorphologicalAntiAliasing
		}

		// Token: 0x020003AA RID: 938
		public enum SMAAQualityLevel
		{
			// Token: 0x040025F8 RID: 9720
			Low,
			// Token: 0x040025F9 RID: 9721
			Medium,
			// Token: 0x040025FA RID: 9722
			High
		}

		// Token: 0x020003AB RID: 939
		public enum TAAQualityLevel
		{
			// Token: 0x040025FC RID: 9724
			Low,
			// Token: 0x040025FD RID: 9725
			Medium,
			// Token: 0x040025FE RID: 9726
			High
		}

		// Token: 0x020003AC RID: 940
		// (Invoke) Token: 0x06001335 RID: 4917
		public delegate void RequestAccessDelegate(ref HDAdditionalCameraData.BufferAccess bufferAccess);

		// Token: 0x020003AD RID: 941
		protected enum Version
		{
			// Token: 0x04002600 RID: 9728
			None,
			// Token: 0x04002601 RID: 9729
			First,
			// Token: 0x04002602 RID: 9730
			SeparatePassThrough,
			// Token: 0x04002603 RID: 9731
			UpgradingFrameSettingsToStruct,
			// Token: 0x04002604 RID: 9732
			AddAfterPostProcessFrameSetting,
			// Token: 0x04002605 RID: 9733
			AddFrameSettingSpecularLighting,
			// Token: 0x04002606 RID: 9734
			AddReflectionSettings,
			// Token: 0x04002607 RID: 9735
			AddCustomPostprocessAndCustomPass,
			// Token: 0x04002608 RID: 9736
			UpdateMSAA,
			// Token: 0x04002609 RID: 9737
			UpdatePhysicalCameraPropertiesToCore
		}
	}
}
