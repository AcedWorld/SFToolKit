using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000144 RID: 324
	[VolumeComponentMenuForRenderPipeline("Post-processing/Tonemapping", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class Tonemapping : VolumeComponent, IPostProcessComponent
	{
		// Token: 0x06000AC9 RID: 2761 RVA: 0x0005A898 File Offset: 0x00058A98
		public bool IsActive()
		{
			if (this.mode.value == TonemappingMode.External)
			{
				return this.ValidateLUT() && this.lutContribution.value > 0f;
			}
			return this.mode.value > TonemappingMode.None;
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x0005A8D4 File Offset: 0x00058AD4
		internal TonemappingMode GetHDRTonemappingMode()
		{
			if (this.mode.value == TonemappingMode.Custom || this.mode.value == TonemappingMode.External)
			{
				if (this.fallbackMode.value == FallbackHDRTonemap.None)
				{
					return TonemappingMode.None;
				}
				if (this.fallbackMode.value == FallbackHDRTonemap.Neutral)
				{
					return TonemappingMode.Neutral;
				}
				if (this.fallbackMode.value == FallbackHDRTonemap.ACES)
				{
					return TonemappingMode.ACES;
				}
			}
			return this.mode.value;
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x0005A938 File Offset: 0x00058B38
		public bool ValidateLUT()
		{
			HDRenderPipelineAsset currentAsset = HDRenderPipeline.currentAsset;
			if (currentAsset == null || this.lutTexture.value == null)
			{
				return false;
			}
			if (this.lutTexture.value.width != currentAsset.currentPlatformRenderPipelineSettings.postProcessSettings.lutSize)
			{
				return false;
			}
			bool flag = false;
			Texture value = this.lutTexture.value;
			Texture3D texture3D = value as Texture3D;
			if (texture3D == null)
			{
				RenderTexture renderTexture = value as RenderTexture;
				if (renderTexture != null)
				{
					flag |= (renderTexture.dimension == TextureDimension.Tex3D && renderTexture.width == renderTexture.height && renderTexture.height == renderTexture.volumeDepth);
				}
			}
			else
			{
				flag |= (texture3D.width == texture3D.height && texture3D.height == texture3D.depth);
			}
			return flag;
		}

		// Token: 0x04000BDE RID: 3038
		[Tooltip("Specifies the tonemapping algorithm to use for the color grading process.")]
		public TonemappingModeParameter mode = new TonemappingModeParameter(TonemappingMode.None, false);

		// Token: 0x04000BDF RID: 3039
		[AdditionalProperty]
		[Tooltip("Whether to use full ACES tonemap instead of an approximation. When outputting to an HDR display, full ACES is always used regardless of this checkbox.")]
		public BoolParameter useFullACES = new BoolParameter(false, false);

		// Token: 0x04000BE0 RID: 3040
		[Tooltip("Controls the transition between the toe and the mid section of the curve. A value of 0 results in no transition and a value of 1 results in a very hard transition.")]
		public ClampedFloatParameter toeStrength = new ClampedFloatParameter(0f, 0f, 1f, false);

		// Token: 0x04000BE1 RID: 3041
		[Tooltip("Controls how much of the dynamic range is in the toe. Higher values result in longer toes and therefore contain more of the dynamic range.")]
		public ClampedFloatParameter toeLength = new ClampedFloatParameter(0.5f, 0f, 1f, false);

		// Token: 0x04000BE2 RID: 3042
		[Tooltip("Controls the transition between the midsection and the shoulder of the curve. A value of 0 results in no transition and a value of 1 results in a very hard transition.")]
		public ClampedFloatParameter shoulderStrength = new ClampedFloatParameter(0f, 0f, 1f, false);

		// Token: 0x04000BE3 RID: 3043
		[Tooltip("Sets how many F-stops (EV) to add to the dynamic range of the curve.")]
		public MinFloatParameter shoulderLength = new MinFloatParameter(0.5f, 0f, false);

		// Token: 0x04000BE4 RID: 3044
		[Tooltip("Controls how much overshoot to add to the shoulder.")]
		public ClampedFloatParameter shoulderAngle = new ClampedFloatParameter(0f, 0f, 1f, false);

		// Token: 0x04000BE5 RID: 3045
		[Tooltip("Sets a gamma correction value that HDRP applies to the whole curve.")]
		public MinFloatParameter gamma = new MinFloatParameter(1f, 0.001f, false);

		// Token: 0x04000BE6 RID: 3046
		[Tooltip("A custom 3D texture lookup table to apply.")]
		public Texture3DParameter lutTexture = new Texture3DParameter(null, false);

		// Token: 0x04000BE7 RID: 3047
		[Tooltip("How much of the lookup texture will contribute to the color grading effect.")]
		public ClampedFloatParameter lutContribution = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x04000BE8 RID: 3048
		[AdditionalProperty]
		[Tooltip("Specifies the range reduction mode used when HDR output is enabled and Neutral tonemapping is enabled.")]
		public NeutralRangeReductionModeParameter neutralHDRRangeReductionMode = new NeutralRangeReductionModeParameter(NeutralRangeReductionMode.BT2390, false);

		// Token: 0x04000BE9 RID: 3049
		[Tooltip("Specifies the ACES preset to be used for HDR displays.")]
		public HDRACESPresetParameter acesPreset = new HDRACESPresetParameter(HDRACESPreset.ACES1000Nits, false);

		// Token: 0x04000BEA RID: 3050
		[Tooltip("Specifies the fallback tonemapping algorithm to use when outputting to an HDR device, when the main mode is not supported.")]
		public FallbackHDRTonemapParameter fallbackMode = new FallbackHDRTonemapParameter(FallbackHDRTonemap.Neutral, false);

		// Token: 0x04000BEB RID: 3051
		[Tooltip("How much hue we want to preserve. Values closer to 0 try to preserve hue, while as values get closer to 1 hue shifts are reintroduced.")]
		public ClampedFloatParameter hueShiftAmount = new ClampedFloatParameter(0f, 0f, 1f, false);

		// Token: 0x04000BEC RID: 3052
		[Tooltip("Whether to use values detected from the output device as paperwhite. This value will often not lead to equivalent images between SDR and HDR. It is suggested to manually set this value.")]
		public BoolParameter detectPaperWhite = new BoolParameter(false, false);

		// Token: 0x04000BED RID: 3053
		[Tooltip("It controls how bright a paper white surface should be, it also determines the maximum brightness of UI. The scene is also scaled relative to this value. Value in nits.")]
		public ClampedFloatParameter paperWhite = new ClampedFloatParameter(300f, 0f, 400f, false);

		// Token: 0x04000BEE RID: 3054
		[Tooltip("Whether to use the minimum and maximum brightness values detected from the output device. It might be worth considering calibrating this values manually if the results are not the desired ones.")]
		public BoolParameter detectBrightnessLimits = new BoolParameter(true, false);

		// Token: 0x04000BEF RID: 3055
		[Tooltip("The minimum brightness (in nits) of the screen. Note that this is assumed to be 0.005 with ACES Tonemap.")]
		public ClampedFloatParameter minNits = new ClampedFloatParameter(0.005f, 0f, 50f, false);

		// Token: 0x04000BF0 RID: 3056
		[Tooltip("The maximum brightness (in nits) of the screen. Note that this is assumed to be defined by the preset when ACES Tonemap is used.")]
		public ClampedFloatParameter maxNits = new ClampedFloatParameter(1000f, 0f, 5000f, false);
	}
}
