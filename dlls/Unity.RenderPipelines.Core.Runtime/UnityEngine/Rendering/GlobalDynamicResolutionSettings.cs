using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000047 RID: 71
	[Serializable]
	public struct GlobalDynamicResolutionSettings
	{
		// Token: 0x06000282 RID: 642 RVA: 0x0000BE54 File Offset: 0x0000A054
		public static GlobalDynamicResolutionSettings NewDefault()
		{
			return new GlobalDynamicResolutionSettings
			{
				useMipBias = false,
				maxPercentage = 100f,
				minPercentage = 100f,
				dynResType = DynamicResolutionType.Hardware,
				upsampleFilter = DynamicResUpscaleFilter.CatmullRom,
				forcedPercentage = 100f,
				lowResTransparencyMinimumThreshold = 0f,
				lowResVolumetricCloudsMinimumThreshold = 50f,
				rayTracingHalfResThreshold = 50f,
				enableDLSS = false,
				DLSSUseOptimalSettings = true,
				DLSSPerfQualitySetting = 0U,
				DLSSSharpness = 0.5f,
				DLSSInjectionPoint = DynamicResolutionHandler.UpsamplerScheduleType.BeforePost,
				fsrOverrideSharpness = false,
				fsrSharpness = 0.92f
			};
		}

		// Token: 0x0400017E RID: 382
		public bool enabled;

		// Token: 0x0400017F RID: 383
		public bool useMipBias;

		// Token: 0x04000180 RID: 384
		public bool enableDLSS;

		// Token: 0x04000181 RID: 385
		public uint DLSSPerfQualitySetting;

		// Token: 0x04000182 RID: 386
		public DynamicResolutionHandler.UpsamplerScheduleType DLSSInjectionPoint;

		// Token: 0x04000183 RID: 387
		public bool DLSSUseOptimalSettings;

		// Token: 0x04000184 RID: 388
		[Range(0f, 1f)]
		public float DLSSSharpness;

		// Token: 0x04000185 RID: 389
		public bool fsrOverrideSharpness;

		// Token: 0x04000186 RID: 390
		[Range(0f, 1f)]
		public float fsrSharpness;

		// Token: 0x04000187 RID: 391
		public float maxPercentage;

		// Token: 0x04000188 RID: 392
		public float minPercentage;

		// Token: 0x04000189 RID: 393
		public DynamicResolutionType dynResType;

		// Token: 0x0400018A RID: 394
		public DynamicResUpscaleFilter upsampleFilter;

		// Token: 0x0400018B RID: 395
		public bool forceResolution;

		// Token: 0x0400018C RID: 396
		public float forcedPercentage;

		// Token: 0x0400018D RID: 397
		public float lowResTransparencyMinimumThreshold;

		// Token: 0x0400018E RID: 398
		public float rayTracingHalfResThreshold;

		// Token: 0x0400018F RID: 399
		public float lowResSSGIMinimumThreshold;

		// Token: 0x04000190 RID: 400
		public float lowResVolumetricCloudsMinimumThreshold;
	}
}
