using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200015D RID: 349
	[Serializable]
	public sealed class GlobalPostProcessingQualitySettings
	{
		// Token: 0x06000BCF RID: 3023 RVA: 0x0005FC0C File Offset: 0x0005DE0C
		internal GlobalPostProcessingQualitySettings()
		{
			this.NearBlurSampleCount[0] = 3;
			this.NearBlurSampleCount[1] = 5;
			this.NearBlurSampleCount[2] = 8;
			this.NearBlurMaxRadius[0] = 2f;
			this.NearBlurMaxRadius[1] = 4f;
			this.NearBlurMaxRadius[2] = 7f;
			this.FarBlurSampleCount[0] = 4;
			this.FarBlurSampleCount[1] = 7;
			this.FarBlurSampleCount[2] = 14;
			this.FarBlurMaxRadius[0] = 5f;
			this.FarBlurMaxRadius[1] = 8f;
			this.FarBlurMaxRadius[2] = 13f;
			this.DoFResolution[0] = DepthOfFieldResolution.Quarter;
			this.DoFResolution[1] = DepthOfFieldResolution.Half;
			this.DoFResolution[2] = DepthOfFieldResolution.Full;
			this.DoFHighQualityFiltering[0] = false;
			this.DoFHighQualityFiltering[1] = true;
			this.DoFHighQualityFiltering[2] = true;
			this.LimitManualRangeNearBlur[0] = false;
			this.LimitManualRangeNearBlur[1] = false;
			this.LimitManualRangeNearBlur[2] = false;
			this.MotionBlurSampleCount[0] = 4;
			this.MotionBlurSampleCount[1] = 8;
			this.MotionBlurSampleCount[2] = 12;
			this.BloomRes[0] = BloomResolution.Quarter;
			this.BloomRes[1] = BloomResolution.Half;
			this.BloomRes[2] = BloomResolution.Half;
			this.BloomHighQualityFiltering[0] = false;
			this.BloomHighQualityFiltering[1] = true;
			this.BloomHighQualityFiltering[2] = true;
			this.BloomHighQualityPrefiltering[0] = false;
			this.BloomHighQualityPrefiltering[1] = false;
			this.BloomHighQualityPrefiltering[2] = true;
			this.ChromaticAberrationMaxSamples[0] = 3;
			this.ChromaticAberrationMaxSamples[1] = 6;
			this.ChromaticAberrationMaxSamples[2] = 12;
		}

		// Token: 0x06000BD0 RID: 3024 RVA: 0x0005FE4E File Offset: 0x0005E04E
		internal static GlobalPostProcessingQualitySettings NewDefault()
		{
			return new GlobalPostProcessingQualitySettings();
		}

		// Token: 0x04000D1F RID: 3359
		private static int s_QualitySettingCount = 3;

		// Token: 0x04000D20 RID: 3360
		[Range(3f, 8f)]
		public int[] NearBlurSampleCount = new int[GlobalPostProcessingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D21 RID: 3361
		[Range(0f, 8f)]
		public float[] NearBlurMaxRadius = new float[GlobalPostProcessingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D22 RID: 3362
		[Range(3f, 16f)]
		public int[] FarBlurSampleCount = new int[GlobalPostProcessingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D23 RID: 3363
		[Range(0f, 16f)]
		public float[] FarBlurMaxRadius = new float[GlobalPostProcessingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D24 RID: 3364
		public DepthOfFieldResolution[] DoFResolution = new DepthOfFieldResolution[GlobalPostProcessingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D25 RID: 3365
		public bool[] DoFHighQualityFiltering = new bool[GlobalPostProcessingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D26 RID: 3366
		public bool[] DoFPhysicallyBased = new bool[GlobalPostProcessingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D27 RID: 3367
		public bool[] LimitManualRangeNearBlur = new bool[GlobalPostProcessingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D28 RID: 3368
		[Min(2f)]
		public int[] MotionBlurSampleCount = new int[GlobalPostProcessingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D29 RID: 3369
		public BloomResolution[] BloomRes = new BloomResolution[GlobalPostProcessingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D2A RID: 3370
		public bool[] BloomHighQualityFiltering = new bool[GlobalPostProcessingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D2B RID: 3371
		public bool[] BloomHighQualityPrefiltering = new bool[GlobalPostProcessingQualitySettings.s_QualitySettingCount];

		// Token: 0x04000D2C RID: 3372
		[Range(3f, 24f)]
		public int[] ChromaticAberrationMaxSamples = new int[GlobalPostProcessingQualitySettings.s_QualitySettingCount];
	}
}
