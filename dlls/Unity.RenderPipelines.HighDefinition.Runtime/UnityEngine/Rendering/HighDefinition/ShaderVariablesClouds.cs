using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000E8 RID: 232
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\VolumetricLighting\\VolumetricCloudsDef.cs", needAccessors = false, generateCBuffer = true)]
	internal struct ShaderVariablesClouds
	{
		// Token: 0x040009D8 RID: 2520
		public float _MaxRayMarchingDistance;

		// Token: 0x040009D9 RID: 2521
		public float _HighestCloudAltitude;

		// Token: 0x040009DA RID: 2522
		public float _LowestCloudAltitude;

		// Token: 0x040009DB RID: 2523
		public float _EarthRadius;

		// Token: 0x040009DC RID: 2524
		public Vector2 _CloudRangeSquared;

		// Token: 0x040009DD RID: 2525
		public int _NumPrimarySteps;

		// Token: 0x040009DE RID: 2526
		public int _NumLightSteps;

		// Token: 0x040009DF RID: 2527
		public Vector4 _CloudMapTiling;

		// Token: 0x040009E0 RID: 2528
		public Vector2 _WindDirection;

		// Token: 0x040009E1 RID: 2529
		public Vector2 _WindVector;

		// Token: 0x040009E2 RID: 2530
		public Vector2 _ShapeNoiseOffset;

		// Token: 0x040009E3 RID: 2531
		public float _VerticalShapeWindDisplacement;

		// Token: 0x040009E4 RID: 2532
		public float _VerticalErosionWindDisplacement;

		// Token: 0x040009E5 RID: 2533
		public float _VerticalShapeNoiseOffset;

		// Token: 0x040009E6 RID: 2534
		public float _LargeWindSpeed;

		// Token: 0x040009E7 RID: 2535
		public float _MediumWindSpeed;

		// Token: 0x040009E8 RID: 2536
		public float _SmallWindSpeed;

		// Token: 0x040009E9 RID: 2537
		public Vector4 _SunLightColor;

		// Token: 0x040009EA RID: 2538
		public Vector4 _SunDirection;

		// Token: 0x040009EB RID: 2539
		public int _PhysicallyBasedSun;

		// Token: 0x040009EC RID: 2540
		public float _MultiScattering;

		// Token: 0x040009ED RID: 2541
		public float _ErosionOcclusion;

		// Token: 0x040009EE RID: 2542
		public float _PowderEffectIntensity;

		// Token: 0x040009EF RID: 2543
		public float _NormalizationFactor;

		// Token: 0x040009F0 RID: 2544
		public float _MaxCloudDistance;

		// Token: 0x040009F1 RID: 2545
		public float _DensityMultiplier;

		// Token: 0x040009F2 RID: 2546
		public float _ShapeFactor;

		// Token: 0x040009F3 RID: 2547
		public float _ErosionFactor;

		// Token: 0x040009F4 RID: 2548
		public float _ShapeScale;

		// Token: 0x040009F5 RID: 2549
		public float _ErosionScale;

		// Token: 0x040009F6 RID: 2550
		public float _TemporalAccumulationFactor;

		// Token: 0x040009F7 RID: 2551
		public Vector4 _ScatteringTint;

		// Token: 0x040009F8 RID: 2552
		public Vector4 _FinalScreenSize;

		// Token: 0x040009F9 RID: 2553
		public Vector4 _IntermediateScreenSize;

		// Token: 0x040009FA RID: 2554
		public Vector4 _TraceScreenSize;

		// Token: 0x040009FB RID: 2555
		public Vector2 _HistoryViewportSize;

		// Token: 0x040009FC RID: 2556
		public Vector2 _HistoryBufferSize;

		// Token: 0x040009FD RID: 2557
		public int _ExposureSunColor;

		// Token: 0x040009FE RID: 2558
		public int _AccumulationFrameIndex;

		// Token: 0x040009FF RID: 2559
		public int _SubPixelIndex;

		// Token: 0x04000A00 RID: 2560
		public int _RenderForSky;

		// Token: 0x04000A01 RID: 2561
		public float _FadeInStart;

		// Token: 0x04000A02 RID: 2562
		public float _FadeInDistance;

		// Token: 0x04000A03 RID: 2563
		public int _LowResolutionEvaluation;

		// Token: 0x04000A04 RID: 2564
		public int _EnableIntegration;

		// Token: 0x04000A05 RID: 2565
		public Vector4 _SunRight;

		// Token: 0x04000A06 RID: 2566
		public Vector4 _SunUp;

		// Token: 0x04000A07 RID: 2567
		public float _ShadowIntensity;

		// Token: 0x04000A08 RID: 2568
		public float _ShadowFallbackValue;

		// Token: 0x04000A09 RID: 2569
		public int _ShadowCookieResolution;

		// Token: 0x04000A0A RID: 2570
		public float _ShadowPlaneOffset;

		// Token: 0x04000A0B RID: 2571
		public Vector2 _ShadowRegionSize;

		// Token: 0x04000A0C RID: 2572
		public float _CloudHistoryInvalidation;

		// Token: 0x04000A0D RID: 2573
		public uint _IntermediateResolutionScale;

		// Token: 0x04000A0E RID: 2574
		public Vector4 _WorldSpaceShadowCenter;

		// Token: 0x04000A0F RID: 2575
		public Matrix4x4 _CameraViewProjection_NO;

		// Token: 0x04000A10 RID: 2576
		public Matrix4x4 _CameraInverseViewProjection_NO;

		// Token: 0x04000A11 RID: 2577
		public Matrix4x4 _CameraPrevViewProjection_NO;

		// Token: 0x04000A12 RID: 2578
		public Matrix4x4 _CloudsPixelCoordToViewDirWS;

		// Token: 0x04000A13 RID: 2579
		public float _AltitudeDistortion;

		// Token: 0x04000A14 RID: 2580
		public float _ErosionFactorCompensation;

		// Token: 0x04000A15 RID: 2581
		public int _EnableFastToneMapping;

		// Token: 0x04000A16 RID: 2582
		public int _IsPlanarReflection;

		// Token: 0x04000A17 RID: 2583
		public int _ValidMaxZMask;

		// Token: 0x04000A18 RID: 2584
		public float _ImprovedTransmittanceBlend;

		// Token: 0x04000A19 RID: 2585
		public float _CubicTransmittance;

		// Token: 0x04000A1A RID: 2586
		public int _Padding1;

		// Token: 0x04000A1B RID: 2587
		[FixedBuffer(typeof(float), 48)]
		[HLSLArray(12, typeof(Vector4))]
		public ShaderVariablesClouds.<_DistanceBasedWeights>e__FixedBuffer _DistanceBasedWeights;

		// Token: 0x02000370 RID: 880
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 192)]
		public struct <_DistanceBasedWeights>e__FixedBuffer
		{
			// Token: 0x040023BE RID: 9150
			public float FixedElementField;
		}
	}
}
