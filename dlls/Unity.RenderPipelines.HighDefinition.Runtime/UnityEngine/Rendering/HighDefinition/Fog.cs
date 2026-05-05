using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200005C RID: 92
	[VolumeComponentMenuForRenderPipeline("Fog", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public class Fog : VolumeComponentWithQuality
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600025D RID: 605 RVA: 0x0000DE35 File Offset: 0x0000C035
		// (set) Token: 0x0600025E RID: 606 RVA: 0x0000DE61 File Offset: 0x0000C061
		public FogControl fogControlMode
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_FogControlMode.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().Fog_ControlMode[this.quality.value];
			}
			set
			{
				this.m_FogControlMode.value = value;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600025F RID: 607 RVA: 0x0000DE6F File Offset: 0x0000C06F
		// (set) Token: 0x06000260 RID: 608 RVA: 0x0000DE9B File Offset: 0x0000C09B
		public float volumetricFogBudget
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_VolumetricFogBudget.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().Fog_Budget[this.quality.value];
			}
			set
			{
				this.m_VolumetricFogBudget.value = value;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000261 RID: 609 RVA: 0x0000DEA9 File Offset: 0x0000C0A9
		// (set) Token: 0x06000262 RID: 610 RVA: 0x0000DED5 File Offset: 0x0000C0D5
		public float resolutionDepthRatio
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_ResolutionDepthRatio.value;
				}
				return VolumeComponentWithQuality.GetLightingQualitySettings().Fog_DepthRatio[this.quality.value];
			}
			set
			{
				this.m_ResolutionDepthRatio.value = value;
			}
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000DEE4 File Offset: 0x0000C0E4
		internal static bool IsFogEnabled(HDCamera hdCamera)
		{
			return hdCamera.frameSettings.IsEnabled(FrameSettingsField.AtmosphericScattering) && hdCamera.volumeStack.GetComponent<Fog>().enabled.value;
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000DF1C File Offset: 0x0000C11C
		internal static bool IsVolumetricFogEnabled(HDCamera hdCamera)
		{
			Fog component = hdCamera.volumeStack.GetComponent<Fog>();
			bool value = component.enableVolumetricFog.value;
			bool flag = hdCamera.frameSettings.IsEnabled(FrameSettingsField.Volumetrics);
			bool flag2 = CoreUtils.IsSceneViewFogEnabled(hdCamera.camera);
			bool value2 = component.enabled.value;
			return value && flag && flag2 && value2;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000DF70 File Offset: 0x0000C170
		internal static bool IsPBRFogEnabled(HDCamera hdCamera)
		{
			hdCamera.volumeStack.GetComponent<VisualEnvironment>();
			return false;
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0000DF7F File Offset: 0x0000C17F
		private static float ScaleHeightFromLayerDepth(float d)
		{
			return d * 0.144765f;
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0000DF88 File Offset: 0x0000C188
		private static void UpdateShaderVariablesGlobalCBNeutralParameters(ref ShaderVariablesGlobal cb)
		{
			cb._FogEnabled = 0;
			cb._EnableVolumetricFog = 0;
			cb._HeightFogBaseScattering = Vector3.zero;
			cb._HeightFogBaseExtinction = 0f;
			cb._HeightFogExponents = Vector2.one;
			cb._HeightFogBaseHeight = 0f;
			cb._GlobalFogAnisotropy = 0f;
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0000DFE0 File Offset: 0x0000C1E0
		internal static void UpdateShaderVariablesGlobalCB(ref ShaderVariablesGlobal cb, HDCamera hdCamera)
		{
			Fog component = hdCamera.volumeStack.GetComponent<Fog>();
			if (!hdCamera.frameSettings.IsEnabled(FrameSettingsField.AtmosphericScattering) || !component.enabled.value)
			{
				Fog.UpdateShaderVariablesGlobalCBNeutralParameters(ref cb);
				return;
			}
			component.UpdateShaderVariablesGlobalCBFogParameters(ref cb, hdCamera);
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000E028 File Offset: 0x0000C228
		private void UpdateShaderVariablesGlobalCBFogParameters(ref ShaderVariablesGlobal cb, HDCamera hdCamera)
		{
			bool flag = this.enableVolumetricFog.value && hdCamera.frameSettings.IsEnabled(FrameSettingsField.Volumetrics);
			cb._FogEnabled = 1;
			cb._PBRFogEnabled = (Fog.IsPBRFogEnabled(hdCamera) ? 1 : 0);
			cb._EnableVolumetricFog = (flag ? 1 : 0);
			cb._MaxFogDistance = this.maxFogDistance.value;
			Color color = (this.colorMode.value == FogColorMode.ConstantColor) ? this.color.value : this.tint.value;
			cb._FogColorMode = (float)this.colorMode.value;
			cb._FogColor = new Color(color.r, color.g, color.b, 0f);
			cb._MipFogParameters = new Vector4(this.mipFogNear.value, this.mipFogFar.value, this.mipFogMaxMip.value, 0f);
			LocalVolumetricFogArtistParameters localVolumetricFogArtistParameters = new LocalVolumetricFogArtistParameters(this.albedo.value, this.meanFreePath.value, this.anisotropy.value);
			LocalVolumetricFogEngineData localVolumetricFogEngineData = localVolumetricFogArtistParameters.ConvertToEngineData();
			cb._HeightFogBaseScattering = (flag ? localVolumetricFogEngineData.scattering : (Vector4.one * localVolumetricFogEngineData.extinction));
			cb._HeightFogBaseExtinction = localVolumetricFogEngineData.extinction;
			float num = this.baseHeight.value;
			if (ShaderConfig.s_CameraRelativeRendering != 0)
			{
				num -= hdCamera.camera.transform.position.y;
			}
			float num2 = Fog.ScaleHeightFromLayerDepth(Mathf.Max(0.01f, this.maximumHeight.value - this.baseHeight.value));
			cb._HeightFogExponents = new Vector2(1f / num2, num2);
			cb._HeightFogBaseHeight = num;
			cb._GlobalFogAnisotropy = this.anisotropy.value;
			cb._VolumetricFilteringEnabled = (((this.denoisingMode.value & FogDenoisingMode.Gaussian) != FogDenoisingMode.None) ? 1 : 0);
			cb._FogDirectionalOnly = (this.directionalLightsOnly.value ? 1 : 0);
		}

		// Token: 0x04000271 RID: 625
		[Tooltip("Enables the fog.")]
		public BoolParameter enabled = new BoolParameter(false, BoolParameter.DisplayType.EnumPopup, false);

		// Token: 0x04000272 RID: 626
		public FogColorParameter colorMode = new FogColorParameter(FogColorMode.SkyColor, false);

		// Token: 0x04000273 RID: 627
		[Tooltip("Specifies the constant color of the fog.")]
		public ColorParameter color = new ColorParameter(Color.grey, true, false, true, false);

		// Token: 0x04000274 RID: 628
		[Tooltip("Specifies the tint of the fog.")]
		public ColorParameter tint = new ColorParameter(Color.white, true, false, true, false);

		// Token: 0x04000275 RID: 629
		[Tooltip("Sets the maximum fog distance HDRP uses when it shades the skybox or the Far Clipping Plane of the Camera.")]
		public MinFloatParameter maxFogDistance = new MinFloatParameter(5000f, 0f, false);

		// Token: 0x04000276 RID: 630
		[AdditionalProperty]
		[Tooltip("Controls the maximum mip map HDRP uses for mip fog (0 is the lowest mip and 1 is the highest mip).")]
		public ClampedFloatParameter mipFogMaxMip = new ClampedFloatParameter(0.5f, 0f, 1f, false);

		// Token: 0x04000277 RID: 631
		[AdditionalProperty]
		[Tooltip("Sets the distance at which HDRP uses the minimum mip image of the blurred sky texture as the fog color.")]
		public MinFloatParameter mipFogNear = new MinFloatParameter(0f, 0f, false);

		// Token: 0x04000278 RID: 632
		[AdditionalProperty]
		[Tooltip("Sets the distance at which HDRP uses the maximum mip image of the blurred sky texture as the fog color.")]
		public MinFloatParameter mipFogFar = new MinFloatParameter(1000f, 0f, false);

		// Token: 0x04000279 RID: 633
		public FloatParameter baseHeight = new FloatParameter(0f, false);

		// Token: 0x0400027A RID: 634
		public FloatParameter maximumHeight = new FloatParameter(50f, false);

		// Token: 0x0400027B RID: 635
		[DisplayInfo(name = "Fog Attenuation Distance")]
		public MinFloatParameter meanFreePath = new MinFloatParameter(400f, 1f, false);

		// Token: 0x0400027C RID: 636
		[DisplayInfo(name = "Volumetric Fog")]
		public BoolParameter enableVolumetricFog = new BoolParameter(false, false);

		// Token: 0x0400027D RID: 637
		public ColorParameter albedo = new ColorParameter(Color.white, false);

		// Token: 0x0400027E RID: 638
		[DisplayInfo(name = "GI Dimmer")]
		public ClampedFloatParameter globalLightProbeDimmer = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x0400027F RID: 639
		public MinFloatParameter depthExtent = new MinFloatParameter(64f, 0.1f, false);

		// Token: 0x04000280 RID: 640
		[Tooltip("Specifies the denoising technique to use for the volumetric effect.")]
		public FogDenoisingModeParameter denoisingMode = new FogDenoisingModeParameter(FogDenoisingMode.Gaussian, false);

		// Token: 0x04000281 RID: 641
		[AdditionalProperty]
		public ClampedFloatParameter anisotropy = new ClampedFloatParameter(0f, -1f, 1f, false);

		// Token: 0x04000282 RID: 642
		[AdditionalProperty]
		[Tooltip("Controls the distribution of slices along the Camera's focal axis. 0 is exponential distribution and 1 is linear distribution.")]
		public ClampedFloatParameter sliceDistributionUniformity = new ClampedFloatParameter(0.75f, 0f, 1f, false);

		// Token: 0x04000283 RID: 643
		internal const float minFogScreenResolutionPercentage = 6.25f;

		// Token: 0x04000284 RID: 644
		internal const float optimalFogScreenResolutionPercentage = 12.5f;

		// Token: 0x04000285 RID: 645
		internal const float maxFogScreenResolutionPercentage = 50f;

		// Token: 0x04000286 RID: 646
		internal const int maxFogSliceCount = 512;

		// Token: 0x04000287 RID: 647
		[AdditionalProperty]
		[SerializeField]
		[FormerlySerializedAs("fogControlMode")]
		[Tooltip("Specifies which method to use to control the performance and quality of the volumetric fog.")]
		private FogControlParameter m_FogControlMode = new FogControlParameter(FogControl.Balance, false);

		// Token: 0x04000288 RID: 648
		[AdditionalProperty]
		[Tooltip("Controls the resolution of the volumetric buffer (3D texture) along the x-axis and y-axis relative to the resolution of the screen.")]
		public ClampedFloatParameter screenResolutionPercentage = new ClampedFloatParameter(12.5f, 6.25f, 50f, false);

		// Token: 0x04000289 RID: 649
		[AdditionalProperty]
		[Tooltip("Controls the number of slices to use the volumetric buffer (3D texture) along the camera's focal axis.")]
		public ClampedIntParameter volumeSliceCount = new ClampedIntParameter(64, 1, 512, false);

		// Token: 0x0400028A RID: 650
		[AdditionalProperty]
		[SerializeField]
		[FormerlySerializedAs("volumetricFogBudget")]
		[Tooltip("Controls the performance to quality ratio of the volumetric fog. A value of 0 being the least resource-intensive and a value of 1 being the highest quality.")]
		private ClampedFloatParameter m_VolumetricFogBudget = new ClampedFloatParameter(0.25f, 0f, 1f, false);

		// Token: 0x0400028B RID: 651
		[AdditionalProperty]
		[SerializeField]
		[FormerlySerializedAs("resolutionDepthRatio")]
		[Tooltip("Controls how Unity shares resources between Screen (x-axis and y-axis) and Depth (z-axis) resolutions.")]
		public ClampedFloatParameter m_ResolutionDepthRatio = new ClampedFloatParameter(0.5f, 0f, 1f, false);

		// Token: 0x0400028C RID: 652
		[AdditionalProperty]
		[Tooltip("When enabled, HDRP only includes directional Lights when it evaluates volumetric fog.")]
		public BoolParameter directionalLightsOnly = new BoolParameter(false, false);
	}
}
