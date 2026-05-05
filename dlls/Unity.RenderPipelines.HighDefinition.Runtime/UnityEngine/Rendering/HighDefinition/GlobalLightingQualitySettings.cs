using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000159 RID: 345
	[Serializable]
	public sealed class GlobalLightingQualitySettings
	{
		// Token: 0x06000BC7 RID: 3015 RVA: 0x0005F494 File Offset: 0x0005D694
		internal GlobalLightingQualitySettings()
		{
			this.AOStepCount[0] = 4;
			this.AOStepCount[1] = 6;
			this.AOStepCount[2] = 16;
			this.AOFullRes[0] = false;
			this.AOFullRes[1] = false;
			this.AOFullRes[2] = true;
			this.AOBilateralUpsample[0] = false;
			this.AOBilateralUpsample[1] = true;
			this.AOBilateralUpsample[2] = true;
			this.AODirectionCount[0] = 1;
			this.AODirectionCount[1] = 2;
			this.AODirectionCount[2] = 4;
			this.AOMaximumRadiusPixels[0] = 32;
			this.AOMaximumRadiusPixels[1] = 40;
			this.AOMaximumRadiusPixels[2] = 80;
			this.ContactShadowSampleCount[0] = 6;
			this.ContactShadowSampleCount[1] = 10;
			this.ContactShadowSampleCount[2] = 16;
			this.SSRMaxRaySteps[0] = 16;
			this.SSRMaxRaySteps[1] = 32;
			this.SSRMaxRaySteps[2] = 64;
			this.SSGIRaySteps[0] = 32;
			this.SSGIRaySteps[1] = 64;
			this.SSGIRaySteps[2] = 128;
			this.SSGIDenoise[0] = true;
			this.SSGIDenoise[1] = true;
			this.SSGIDenoise[2] = true;
			this.SSGIHalfResDenoise[0] = true;
			this.SSGIHalfResDenoise[1] = false;
			this.SSGIHalfResDenoise[2] = false;
			this.SSGIDenoiserRadius[0] = 0.75f;
			this.SSGIDenoiserRadius[1] = 0.5f;
			this.SSGIDenoiserRadius[2] = 0.5f;
			this.SSGISecondDenoise[0] = true;
			this.SSGISecondDenoise[1] = true;
			this.SSGISecondDenoise[2] = true;
			this.RTAORayLength[0] = 0.5f;
			this.RTAORayLength[1] = 3f;
			this.RTAORayLength[2] = 20f;
			this.RTAOSampleCount[0] = 1;
			this.RTAOSampleCount[1] = 2;
			this.RTAOSampleCount[2] = 8;
			this.RTAODenoise[0] = true;
			this.RTAODenoise[1] = true;
			this.RTAODenoise[2] = true;
			this.RTAODenoiserRadius[0] = 0.25f;
			this.RTAODenoiserRadius[1] = 0.5f;
			this.RTAODenoiserRadius[2] = 0.65f;
			this.RTGIRayLength[0] = 50f;
			this.RTGIRayLength[1] = 50f;
			this.RTGIRayLength[2] = 50f;
			this.RTGIFullResolution[0] = false;
			this.RTGIFullResolution[1] = false;
			this.RTGIFullResolution[2] = true;
			this.RTGIClampValue[0] = 2f;
			this.RTGIClampValue[1] = 3f;
			this.RTGIClampValue[2] = 5f;
			this.RTGIRaySteps[0] = 32;
			this.RTGIRaySteps[1] = 48;
			this.RTGIRaySteps[2] = 64;
			this.RTGIDenoise[0] = true;
			this.RTGIDenoise[1] = true;
			this.RTGIDenoise[2] = true;
			this.RTGIHalfResDenoise[0] = true;
			this.RTGIHalfResDenoise[1] = false;
			this.RTGIHalfResDenoise[2] = false;
			this.RTGIDenoiserRadius[0] = 1f;
			this.RTGIDenoiserRadius[1] = 1f;
			this.RTGIDenoiserRadius[2] = 1f;
			this.RTGISecondDenoise[0] = true;
			this.RTGISecondDenoise[1] = true;
			this.RTGISecondDenoise[2] = true;
			this.RTRMinSmoothness[0] = 0.6f;
			this.RTRMinSmoothness[1] = 0.4f;
			this.RTRMinSmoothness[2] = 0f;
			this.RTRSmoothnessFadeStart[0] = 0.7f;
			this.RTRSmoothnessFadeStart[1] = 0.5f;
			this.RTRSmoothnessFadeStart[2] = 0f;
			this.RTRRayLength[0] = 50f;
			this.RTRRayLength[1] = 50f;
			this.RTRRayLength[2] = 50f;
			this.RTRClampValue[0] = 0.8f;
			this.RTRClampValue[1] = 1f;
			this.RTRClampValue[2] = 1.2f;
			this.RTRFullResolution[0] = false;
			this.RTRFullResolution[1] = false;
			this.RTRFullResolution[2] = true;
			this.RTRRayMaxIterations[0] = 32;
			this.RTRRayMaxIterations[1] = 48;
			this.RTRRayMaxIterations[2] = 64;
			this.RTRDenoise[0] = true;
			this.RTRDenoise[1] = true;
			this.RTRDenoise[2] = true;
			this.RTRDenoiserRadius[0] = 8;
			this.RTRDenoiserRadius[1] = 12;
			this.RTRDenoiserRadius[2] = 16;
			this.RTRSmoothDenoising[0] = true;
			this.RTRSmoothDenoising[1] = false;
			this.RTRSmoothDenoising[2] = false;
			this.Fog_ControlMode[0] = FogControl.Balance;
			this.Fog_ControlMode[1] = FogControl.Balance;
			this.Fog_ControlMode[2] = FogControl.Balance;
			this.Fog_Budget[0] = 0.166f;
			this.Fog_Budget[1] = 0.33f;
			this.Fog_Budget[2] = 0.666f;
			this.Fog_DepthRatio[0] = 0.666f;
			this.Fog_DepthRatio[1] = 0.666f;
			this.Fog_DepthRatio[2] = 0.5f;
		}

		// Token: 0x06000BC8 RID: 3016 RVA: 0x0005FB5A File Offset: 0x0005DD5A
		internal static GlobalLightingQualitySettings NewDefault()
		{
			return new GlobalLightingQualitySettings();
		}

		// Token: 0x04000CF3 RID: 3315
		private static int s_QualitySettingCount = Enum.GetNames(typeof(ScalableSettingLevelParameter.Level)).Length;

		// Token: 0x04000CF4 RID: 3316
		[Range(2f, 32f)]
		public int[] AOStepCount = new int[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000CF5 RID: 3317
		public bool[] AOFullRes = new bool[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000CF6 RID: 3318
		[Range(16f, 256f)]
		public int[] AOMaximumRadiusPixels = new int[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000CF7 RID: 3319
		public bool[] AOBilateralUpsample = new bool[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000CF8 RID: 3320
		[Range(1f, 6f)]
		public int[] AODirectionCount = new int[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000CF9 RID: 3321
		[Range(4f, 64f)]
		public int[] ContactShadowSampleCount = new int[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000CFA RID: 3322
		[Min(0f)]
		public int[] SSRMaxRaySteps = new int[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000CFB RID: 3323
		[Min(0f)]
		public int[] SSGIRaySteps = new int[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000CFC RID: 3324
		public bool[] SSGIDenoise = new bool[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000CFD RID: 3325
		public bool[] SSGIHalfResDenoise = new bool[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000CFE RID: 3326
		public float[] SSGIDenoiserRadius = new float[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000CFF RID: 3327
		public bool[] SSGISecondDenoise = new bool[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D00 RID: 3328
		[Min(0.01f)]
		public float[] RTAORayLength = new float[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D01 RID: 3329
		[Range(1f, 64f)]
		public int[] RTAOSampleCount = new int[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D02 RID: 3330
		public bool[] RTAODenoise = new bool[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D03 RID: 3331
		[Range(0.001f, 1f)]
		public float[] RTAODenoiserRadius = new float[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D04 RID: 3332
		[Min(0.01f)]
		public float[] RTGIRayLength = new float[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D05 RID: 3333
		public bool[] RTGIFullResolution = new bool[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D06 RID: 3334
		[Min(0.001f)]
		public float[] RTGIClampValue = new float[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D07 RID: 3335
		[Min(0f)]
		public int[] RTGIRaySteps = new int[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D08 RID: 3336
		public bool[] RTGIDenoise = new bool[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D09 RID: 3337
		public bool[] RTGIHalfResDenoise = new bool[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D0A RID: 3338
		[Range(0.001f, 1f)]
		public float[] RTGIDenoiserRadius = new float[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D0B RID: 3339
		public bool[] RTGISecondDenoise = new bool[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D0C RID: 3340
		[Range(0f, 1f)]
		public float[] RTRMinSmoothness = new float[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D0D RID: 3341
		[Range(0f, 1f)]
		public float[] RTRSmoothnessFadeStart = new float[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D0E RID: 3342
		[Min(0.01f)]
		public float[] RTRRayLength = new float[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D0F RID: 3343
		[Min(0.001f)]
		public float[] RTRClampValue = new float[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D10 RID: 3344
		public bool[] RTRFullResolution = new bool[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D11 RID: 3345
		[Min(0f)]
		public int[] RTRRayMaxIterations = new int[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D12 RID: 3346
		public bool[] RTRDenoise = new bool[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D13 RID: 3347
		[Range(1f, 32f)]
		public int[] RTRDenoiserRadius = new int[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D14 RID: 3348
		public bool[] RTRSmoothDenoising = new bool[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D15 RID: 3349
		public FogControl[] Fog_ControlMode = new FogControl[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D16 RID: 3350
		[Range(0f, 1f)]
		public float[] Fog_Budget = new float[GlobalLightingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D17 RID: 3351
		[Range(0f, 1f)]
		public float[] Fog_DepthRatio = new float[GlobalLightingQualitySettings.s_QualitySettingCount];
	}
}
