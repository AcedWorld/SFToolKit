using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000127 RID: 295
	[VolumeComponentMenuForRenderPipeline("Exposure", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class Exposure : VolumeComponent, IPostProcessComponent
	{
		// Token: 0x06000AAD RID: 2733 RVA: 0x0005A07C File Offset: 0x0005827C
		public bool IsActive()
		{
			return true;
		}

		// Token: 0x04000B6C RID: 2924
		[Tooltip("Specifies the method that HDRP uses to process exposure.")]
		public ExposureModeParameter mode = new ExposureModeParameter(ExposureMode.Fixed, false);

		// Token: 0x04000B6D RID: 2925
		[Tooltip("Specifies the metering method that HDRP uses the filter the luminance source.")]
		public MeteringModeParameter meteringMode = new MeteringModeParameter(MeteringMode.CenterWeighted, false);

		// Token: 0x04000B6E RID: 2926
		[Tooltip("Specifies the luminance source that HDRP uses to calculate the current Scene exposure.")]
		public LuminanceSourceParameter luminanceSource = new LuminanceSourceParameter(LuminanceSource.ColorBuffer, false);

		// Token: 0x04000B6F RID: 2927
		[Tooltip("Sets a static exposure value for Cameras in this Volume.")]
		public FloatParameter fixedExposure = new FloatParameter(0f, false);

		// Token: 0x04000B70 RID: 2928
		[Tooltip("Sets the compensation that the Camera applies to the calculated exposure value.")]
		public FloatParameter compensation = new FloatParameter(0f, false);

		// Token: 0x04000B71 RID: 2929
		[Tooltip("Sets the minimum value that the Scene exposure can be set to.")]
		public FloatParameter limitMin = new FloatParameter(-1f, false);

		// Token: 0x04000B72 RID: 2930
		[Tooltip("Sets the maximum value that the Scene exposure can be set to.")]
		public FloatParameter limitMax = new FloatParameter(14f, false);

		// Token: 0x04000B73 RID: 2931
		[Tooltip("Specifies a curve that remaps the Scene exposure on the x-axis to the exposure you want on the y-axis.")]
		public AnimationCurveParameter curveMap = new AnimationCurveParameter(AnimationCurve.Linear(-10f, -10f, 20f, 20f), false);

		// Token: 0x04000B74 RID: 2932
		[Tooltip("Specifies a curve that determines for each current exposure value (x-value) what minimum value is allowed to auto-adaptation (y-axis).")]
		public AnimationCurveParameter limitMinCurveMap = new AnimationCurveParameter(AnimationCurve.Linear(-10f, -12f, 20f, 18f), false);

		// Token: 0x04000B75 RID: 2933
		[Tooltip("Specifies a curve that determines for each current exposure value (x-value) what maximum value is allowed to auto-adaptation (y-axis).")]
		public AnimationCurveParameter limitMaxCurveMap = new AnimationCurveParameter(AnimationCurve.Linear(-10f, -8f, 20f, 22f), false);

		// Token: 0x04000B76 RID: 2934
		[Header("Adaptation")]
		[Tooltip("Specifies the method that HDRP uses to change the exposure when the Camera moves from dark to light and vice versa.")]
		public AdaptationModeParameter adaptationMode = new AdaptationModeParameter(AdaptationMode.Progressive, false);

		// Token: 0x04000B77 RID: 2935
		[Tooltip("Sets the speed at which the exposure changes when the Camera moves from a dark area to a bright area.")]
		public MinFloatParameter adaptationSpeedDarkToLight = new MinFloatParameter(3f, 0.001f, false);

		// Token: 0x04000B78 RID: 2936
		[Tooltip("Sets the speed at which the exposure changes when the Camera moves from a bright area to a dark area.")]
		public MinFloatParameter adaptationSpeedLightToDark = new MinFloatParameter(1f, 0.001f, false);

		// Token: 0x04000B79 RID: 2937
		[Tooltip("Sets the texture mask to be used to weight the pixels in the buffer for the sake of computing exposure.")]
		public Texture2DParameter weightTextureMask = new Texture2DParameter(null, false);

		// Token: 0x04000B7A RID: 2938
		[Header("Histogram")]
		[Tooltip("Sets the range of values (in terms of percentages) of the histogram that are accepted while finding a stable average exposure. Anything outside the value is discarded.")]
		public FloatRangeParameter histogramPercentages = new FloatRangeParameter(new Vector2(40f, 90f), 0f, 100f, false);

		// Token: 0x04000B7B RID: 2939
		[Tooltip("Sets whether histogram exposure mode will remap the computed exposure with a curve remapping (akin to Curve Remapping mode).")]
		public BoolParameter histogramUseCurveRemapping = new BoolParameter(false, false);

		// Token: 0x04000B7C RID: 2940
		[AdditionalProperty]
		[Tooltip("Sets the desired Mid gray level used by the auto exposure (i.e. to what grey value the auto exposure system maps the average scene luminance).")]
		public TargetMidGrayParameter targetMidGray = new TargetMidGrayParameter(TargetMidGray.Grey125, false);

		// Token: 0x04000B7D RID: 2941
		[Header("Procedural Mask")]
		[Tooltip("Sets whether histogram exposure mode will remap the computed exposure with a curve remapping (akin to Curve Remapping mode).")]
		public BoolParameter centerAroundExposureTarget = new BoolParameter(false, false);

		// Token: 0x04000B7E RID: 2942
		public NoInterpVector2Parameter proceduralCenter = new NoInterpVector2Parameter(new Vector2(0.5f, 0.5f), false);

		// Token: 0x04000B7F RID: 2943
		public NoInterpVector2Parameter proceduralRadii = new NoInterpVector2Parameter(new Vector2(0.3f, 0.3f), false);

		// Token: 0x04000B80 RID: 2944
		[AdditionalProperty]
		[Tooltip("All pixels below this threshold (in EV100 units) will be assigned a weight of 0 in the metering mask.")]
		public FloatParameter maskMinIntensity = new FloatParameter(-30f, false);

		// Token: 0x04000B81 RID: 2945
		[AdditionalProperty]
		[Tooltip("All pixels above this threshold (in EV100 units) will be assigned a weight of 0 in the metering mask.")]
		public FloatParameter maskMaxIntensity = new FloatParameter(30f, false);

		// Token: 0x04000B82 RID: 2946
		public NoInterpMinFloatParameter proceduralSoftness = new NoInterpMinFloatParameter(0.5f, 0f, false);
	}
}
