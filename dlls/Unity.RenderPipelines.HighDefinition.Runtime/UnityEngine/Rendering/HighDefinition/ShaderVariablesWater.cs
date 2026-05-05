using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000228 RID: 552
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Water\\WaterSystemDef.cs", needAccessors = false, generateCBuffer = true)]
	internal struct ShaderVariablesWater
	{
		// Token: 0x04001903 RID: 6403
		public uint _BandResolution;

		// Token: 0x04001904 RID: 6404
		public float _MaxWaveHeight;

		// Token: 0x04001905 RID: 6405
		public float _SimulationTime;

		// Token: 0x04001906 RID: 6406
		public float _ScatteringWaveHeight;

		// Token: 0x04001907 RID: 6407
		public Vector4 _PatchSize;

		// Token: 0x04001908 RID: 6408
		public Vector4 _PatchAmplitudeMultiplier;

		// Token: 0x04001909 RID: 6409
		public Vector4 _PatchDirectionDampener;

		// Token: 0x0400190A RID: 6410
		public Vector4 _PatchWindSpeed;

		// Token: 0x0400190B RID: 6411
		public Vector4 _PatchWindOrientation;

		// Token: 0x0400190C RID: 6412
		public Vector4 _PatchCurrentSpeed;

		// Token: 0x0400190D RID: 6413
		public Vector4 _PatchCurrentOrientation;

		// Token: 0x0400190E RID: 6414
		public Vector4 _PatchFadeStart;

		// Token: 0x0400190F RID: 6415
		public Vector4 _PatchFadeDistance;

		// Token: 0x04001910 RID: 6416
		public Vector4 _PatchFadeValue;

		// Token: 0x04001911 RID: 6417
		public float _SimulationFoamSmoothness;

		// Token: 0x04001912 RID: 6418
		public float _JacobianDrag;

		// Token: 0x04001913 RID: 6419
		public float _SimulationFoamAmount;

		// Token: 0x04001914 RID: 6420
		public float _SSSMaskCoefficient;

		// Token: 0x04001915 RID: 6421
		public float _Choppiness;

		// Token: 0x04001916 RID: 6422
		public float _DeltaTime;

		// Token: 0x04001917 RID: 6423
		public float _MaxWaveDisplacement;

		// Token: 0x04001918 RID: 6424
		public float _MaxRefractionDistance;

		// Token: 0x04001919 RID: 6425
		public Vector2 _FoamOffsets;

		// Token: 0x0400191A RID: 6426
		public float _FoamTilling;

		// Token: 0x0400191B RID: 6427
		public float _WindFoamAttenuation;

		// Token: 0x0400191C RID: 6428
		public Vector4 _TransparencyColor;

		// Token: 0x0400191D RID: 6429
		public Vector4 _ScatteringColorTips;

		// Token: 0x0400191E RID: 6430
		public float _DisplacementScattering;

		// Token: 0x0400191F RID: 6431
		public int _WaterInitialFrame;

		// Token: 0x04001920 RID: 6432
		public int _SurfaceIndex;

		// Token: 0x04001921 RID: 6433
		public float _CausticsRegionSize;

		// Token: 0x04001922 RID: 6434
		public Vector4 _ScatteringLambertLighting;

		// Token: 0x04001923 RID: 6435
		public Vector4 _DeepFoamColor;

		// Token: 0x04001924 RID: 6436
		public float _OutScatteringCoefficient;

		// Token: 0x04001925 RID: 6437
		public float _FoamSmoothness;

		// Token: 0x04001926 RID: 6438
		public float _HeightBasedScattering;

		// Token: 0x04001927 RID: 6439
		public float _WaterSmoothness;

		// Token: 0x04001928 RID: 6440
		public Vector4 _FoamJacobianLambda;

		// Token: 0x04001929 RID: 6441
		public int _WaterRefSimRes;

		// Token: 0x0400192A RID: 6442
		public float _WaterSpectrumOffset;

		// Token: 0x0400192B RID: 6443
		public int _WaterSampleOffset;

		// Token: 0x0400192C RID: 6444
		public int _WaterBandCount;

		// Token: 0x0400192D RID: 6445
		public Vector2 _PaddingW0;

		// Token: 0x0400192E RID: 6446
		public float _AmbientScattering;

		// Token: 0x0400192F RID: 6447
		public int _CausticsBandIndex;
	}
}
