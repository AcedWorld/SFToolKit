using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001D0 RID: 464
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\ShaderLibrary\\ShaderVariablesGlobal.cs", needAccessors = false, generateCBuffer = true, constantRegister = 0)]
	internal struct ShaderVariablesGlobal
	{
		// Token: 0x040015E9 RID: 5609
		public const int RenderingLightLayersMask = 255;

		// Token: 0x040015EA RID: 5610
		public const int RenderingLightLayersMaskShift = 0;

		// Token: 0x040015EB RID: 5611
		public const int RenderingDecalLayersMask = 65280;

		// Token: 0x040015EC RID: 5612
		public const int RenderingDecalLayersMaskShift = 8;

		// Token: 0x040015ED RID: 5613
		public const int DefaultRenderingLayerMask = 257;

		// Token: 0x040015EE RID: 5614
		public const int DefaultDecalLayers = 255;

		// Token: 0x040015EF RID: 5615
		public Matrix4x4 _ViewMatrix;

		// Token: 0x040015F0 RID: 5616
		public Matrix4x4 _CameraViewMatrix;

		// Token: 0x040015F1 RID: 5617
		public Matrix4x4 _InvViewMatrix;

		// Token: 0x040015F2 RID: 5618
		public Matrix4x4 _ProjMatrix;

		// Token: 0x040015F3 RID: 5619
		public Matrix4x4 _InvProjMatrix;

		// Token: 0x040015F4 RID: 5620
		public Matrix4x4 _ViewProjMatrix;

		// Token: 0x040015F5 RID: 5621
		public Matrix4x4 _CameraViewProjMatrix;

		// Token: 0x040015F6 RID: 5622
		public Matrix4x4 _InvViewProjMatrix;

		// Token: 0x040015F7 RID: 5623
		public Matrix4x4 _NonJitteredViewProjMatrix;

		// Token: 0x040015F8 RID: 5624
		public Matrix4x4 _PrevViewProjMatrix;

		// Token: 0x040015F9 RID: 5625
		public Matrix4x4 _PrevInvViewProjMatrix;

		// Token: 0x040015FA RID: 5626
		public Vector4 _WorldSpaceCameraPos_Internal;

		// Token: 0x040015FB RID: 5627
		public Vector4 _PrevCamPosRWS_Internal;

		// Token: 0x040015FC RID: 5628
		public Vector4 _ScreenSize;

		// Token: 0x040015FD RID: 5629
		public Vector4 _PostProcessScreenSize;

		// Token: 0x040015FE RID: 5630
		public Vector4 _RTHandleScale;

		// Token: 0x040015FF RID: 5631
		public Vector4 _RTHandleScaleHistory;

		// Token: 0x04001600 RID: 5632
		public Vector4 _RTHandlePostProcessScale;

		// Token: 0x04001601 RID: 5633
		public Vector4 _RTHandlePostProcessScaleHistory;

		// Token: 0x04001602 RID: 5634
		public Vector4 _DynamicResolutionFullscreenScale;

		// Token: 0x04001603 RID: 5635
		public Vector4 _ZBufferParams;

		// Token: 0x04001604 RID: 5636
		public Vector4 _ProjectionParams;

		// Token: 0x04001605 RID: 5637
		public Vector4 unity_OrthoParams;

		// Token: 0x04001606 RID: 5638
		public Vector4 _ScreenParams;

		// Token: 0x04001607 RID: 5639
		[FixedBuffer(typeof(float), 24)]
		[HLSLArray(6, typeof(Vector4))]
		public ShaderVariablesGlobal.<_FrustumPlanes>e__FixedBuffer _FrustumPlanes;

		// Token: 0x04001608 RID: 5640
		[FixedBuffer(typeof(float), 24)]
		[HLSLArray(6, typeof(Vector4))]
		public ShaderVariablesGlobal.<_ShadowFrustumPlanes>e__FixedBuffer _ShadowFrustumPlanes;

		// Token: 0x04001609 RID: 5641
		public Vector4 _TaaFrameInfo;

		// Token: 0x0400160A RID: 5642
		public Vector4 _TaaJitterStrength;

		// Token: 0x0400160B RID: 5643
		public Vector4 _Time;

		// Token: 0x0400160C RID: 5644
		public Vector4 _SinTime;

		// Token: 0x0400160D RID: 5645
		public Vector4 _CosTime;

		// Token: 0x0400160E RID: 5646
		public Vector4 unity_DeltaTime;

		// Token: 0x0400160F RID: 5647
		public Vector4 _TimeParameters;

		// Token: 0x04001610 RID: 5648
		public Vector4 _LastTimeParameters;

		// Token: 0x04001611 RID: 5649
		public int _FogEnabled;

		// Token: 0x04001612 RID: 5650
		public int _PBRFogEnabled;

		// Token: 0x04001613 RID: 5651
		public int _EnableVolumetricFog;

		// Token: 0x04001614 RID: 5652
		public float _MaxFogDistance;

		// Token: 0x04001615 RID: 5653
		public Vector4 _FogColor;

		// Token: 0x04001616 RID: 5654
		public float _FogColorMode;

		// Token: 0x04001617 RID: 5655
		public float _GlobalMipBias;

		// Token: 0x04001618 RID: 5656
		public float _GlobalMipBiasPow2;

		// Token: 0x04001619 RID: 5657
		public float _Pad0;

		// Token: 0x0400161A RID: 5658
		public Vector4 _MipFogParameters;

		// Token: 0x0400161B RID: 5659
		public Vector4 _HeightFogBaseScattering;

		// Token: 0x0400161C RID: 5660
		public float _HeightFogBaseExtinction;

		// Token: 0x0400161D RID: 5661
		public float _HeightFogBaseHeight;

		// Token: 0x0400161E RID: 5662
		public float _GlobalFogAnisotropy;

		// Token: 0x0400161F RID: 5663
		public int _VolumetricFilteringEnabled;

		// Token: 0x04001620 RID: 5664
		public Vector2 _HeightFogExponents;

		// Token: 0x04001621 RID: 5665
		public int _FogDirectionalOnly;

		// Token: 0x04001622 RID: 5666
		public float _FogGIDimmer;

		// Token: 0x04001623 RID: 5667
		public Vector4 _VBufferViewportSize;

		// Token: 0x04001624 RID: 5668
		public Vector4 _VBufferLightingViewportScale;

		// Token: 0x04001625 RID: 5669
		public Vector4 _VBufferLightingViewportLimit;

		// Token: 0x04001626 RID: 5670
		public Vector4 _VBufferDistanceEncodingParams;

		// Token: 0x04001627 RID: 5671
		public Vector4 _VBufferDistanceDecodingParams;

		// Token: 0x04001628 RID: 5672
		public uint _VBufferSliceCount;

		// Token: 0x04001629 RID: 5673
		public float _VBufferRcpSliceCount;

		// Token: 0x0400162A RID: 5674
		public float _VBufferRcpInstancedViewCount;

		// Token: 0x0400162B RID: 5675
		public float _VBufferLastSliceDist;

		// Token: 0x0400162C RID: 5676
		public Vector4 _ShadowAtlasSize;

		// Token: 0x0400162D RID: 5677
		public Vector4 _CascadeShadowAtlasSize;

		// Token: 0x0400162E RID: 5678
		public Vector4 _AreaShadowAtlasSize;

		// Token: 0x0400162F RID: 5679
		public Vector4 _CachedShadowAtlasSize;

		// Token: 0x04001630 RID: 5680
		public Vector4 _CachedAreaShadowAtlasSize;

		// Token: 0x04001631 RID: 5681
		public int _ReflectionsMode;

		// Token: 0x04001632 RID: 5682
		public int _UnusedPadding0;

		// Token: 0x04001633 RID: 5683
		public int _UnusedPadding1;

		// Token: 0x04001634 RID: 5684
		public int _UnusedPadding2;

		// Token: 0x04001635 RID: 5685
		public uint _DirectionalLightCount;

		// Token: 0x04001636 RID: 5686
		public uint _PunctualLightCount;

		// Token: 0x04001637 RID: 5687
		public uint _AreaLightCount;

		// Token: 0x04001638 RID: 5688
		public uint _EnvLightCount;

		// Token: 0x04001639 RID: 5689
		public int _EnvLightSkyEnabled;

		// Token: 0x0400163A RID: 5690
		public uint _CascadeShadowCount;

		// Token: 0x0400163B RID: 5691
		public int _DirectionalShadowIndex;

		// Token: 0x0400163C RID: 5692
		public uint _EnableLightLayers;

		// Token: 0x0400163D RID: 5693
		public uint _EnableSkyReflection;

		// Token: 0x0400163E RID: 5694
		public uint _EnableSSRefraction;

		// Token: 0x0400163F RID: 5695
		public float _SSRefractionInvScreenWeightDistance;

		// Token: 0x04001640 RID: 5696
		public float _ColorPyramidLodCount;

		// Token: 0x04001641 RID: 5697
		public float _DirectionalTransmissionMultiplier;

		// Token: 0x04001642 RID: 5698
		public float _ProbeExposureScale;

		// Token: 0x04001643 RID: 5699
		public float _ContactShadowOpacity;

		// Token: 0x04001644 RID: 5700
		public float _ReplaceDiffuseForIndirect;

		// Token: 0x04001645 RID: 5701
		public Vector4 _AmbientOcclusionParam;

		// Token: 0x04001646 RID: 5702
		public float _IndirectDiffuseLightingMultiplier;

		// Token: 0x04001647 RID: 5703
		public uint _IndirectDiffuseLightingLayers;

		// Token: 0x04001648 RID: 5704
		public float _ReflectionLightingMultiplier;

		// Token: 0x04001649 RID: 5705
		public uint _ReflectionLightingLayers;

		// Token: 0x0400164A RID: 5706
		public float _MicroShadowOpacity;

		// Token: 0x0400164B RID: 5707
		public uint _EnableProbeVolumes;

		// Token: 0x0400164C RID: 5708
		public uint _ProbeVolumeCount;

		// Token: 0x0400164D RID: 5709
		public float _SlopeScaleDepthBias;

		// Token: 0x0400164E RID: 5710
		public Vector4 _CookieAtlasSize;

		// Token: 0x0400164F RID: 5711
		public Vector4 _CookieAtlasData;

		// Token: 0x04001650 RID: 5712
		public Vector4 _ReflectionAtlasCubeData;

		// Token: 0x04001651 RID: 5713
		public Vector4 _ReflectionAtlasPlanarData;

		// Token: 0x04001652 RID: 5714
		public uint _NumTileFtplX;

		// Token: 0x04001653 RID: 5715
		public uint _NumTileFtplY;

		// Token: 0x04001654 RID: 5716
		public float g_fClustScale;

		// Token: 0x04001655 RID: 5717
		public float g_fClustBase;

		// Token: 0x04001656 RID: 5718
		public float g_fNearPlane;

		// Token: 0x04001657 RID: 5719
		public float g_fFarPlane;

		// Token: 0x04001658 RID: 5720
		public int g_iLog2NumClusters;

		// Token: 0x04001659 RID: 5721
		public uint g_isLogBaseBufferEnabled;

		// Token: 0x0400165A RID: 5722
		public uint _NumTileClusteredX;

		// Token: 0x0400165B RID: 5723
		public uint _NumTileClusteredY;

		// Token: 0x0400165C RID: 5724
		public int _EnvSliceSize;

		// Token: 0x0400165D RID: 5725
		public uint _EnableDecalLayers;

		// Token: 0x0400165E RID: 5726
		[FixedBuffer(typeof(float), 64)]
		[HLSLArray(16, typeof(Vector4))]
		public ShaderVariablesGlobal.<_ShapeParamsAndMaxScatterDists>e__FixedBuffer _ShapeParamsAndMaxScatterDists;

		// Token: 0x0400165F RID: 5727
		[FixedBuffer(typeof(float), 64)]
		[HLSLArray(16, typeof(Vector4))]
		public ShaderVariablesGlobal.<_TransmissionTintsAndFresnel0>e__FixedBuffer _TransmissionTintsAndFresnel0;

		// Token: 0x04001660 RID: 5728
		[FixedBuffer(typeof(float), 64)]
		[HLSLArray(16, typeof(Vector4))]
		public ShaderVariablesGlobal.<_WorldScalesAndFilterRadiiAndThicknessRemaps>e__FixedBuffer _WorldScalesAndFilterRadiiAndThicknessRemaps;

		// Token: 0x04001661 RID: 5729
		[FixedBuffer(typeof(uint), 64)]
		[HLSLArray(16, typeof(ShaderGenUInt4))]
		public ShaderVariablesGlobal.<_DiffusionProfileHashTable>e__FixedBuffer _DiffusionProfileHashTable;

		// Token: 0x04001662 RID: 5730
		public uint _EnableSubsurfaceScattering;

		// Token: 0x04001663 RID: 5731
		public uint _TexturingModeFlags;

		// Token: 0x04001664 RID: 5732
		public uint _TransmissionFlags;

		// Token: 0x04001665 RID: 5733
		public uint _DiffusionProfileCount;

		// Token: 0x04001666 RID: 5734
		public Vector2 _DecalAtlasResolution;

		// Token: 0x04001667 RID: 5735
		public uint _EnableDecals;

		// Token: 0x04001668 RID: 5736
		public uint _DecalCount;

		// Token: 0x04001669 RID: 5737
		public float _OffScreenDownsampleFactor;

		// Token: 0x0400166A RID: 5738
		public uint _OffScreenRendering;

		// Token: 0x0400166B RID: 5739
		public uint _XRViewCount;

		// Token: 0x0400166C RID: 5740
		public int _FrameCount;

		// Token: 0x0400166D RID: 5741
		public Vector4 _CoarseStencilBufferSize;

		// Token: 0x0400166E RID: 5742
		public int _IndirectDiffuseMode;

		// Token: 0x0400166F RID: 5743
		public int _EnableRayTracedReflections;

		// Token: 0x04001670 RID: 5744
		public int _RaytracingFrameIndex;

		// Token: 0x04001671 RID: 5745
		public uint _EnableRecursiveRayTracing;

		// Token: 0x04001672 RID: 5746
		public int _TransparentCameraOnlyMotionVectors;

		// Token: 0x04001673 RID: 5747
		public float _GlobalTessellationFactorMultiplier;

		// Token: 0x04001674 RID: 5748
		public float _SpecularOcclusionBlend;

		// Token: 0x04001675 RID: 5749
		public float _DeExposureMultiplier;

		// Token: 0x04001676 RID: 5750
		public Vector4 _ScreenSizeOverride;

		// Token: 0x04001677 RID: 5751
		public Vector4 _ScreenCoordScaleBias;

		// Token: 0x04001678 RID: 5752
		public Vector4 _ColorPyramidUvScaleAndLimitPrevFrame;

		// Token: 0x02000411 RID: 1041
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 256)]
		public struct <_DiffusionProfileHashTable>e__FixedBuffer
		{
			// Token: 0x040028EB RID: 10475
			public uint FixedElementField;
		}

		// Token: 0x02000412 RID: 1042
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 96)]
		public struct <_FrustumPlanes>e__FixedBuffer
		{
			// Token: 0x040028EC RID: 10476
			public float FixedElementField;
		}

		// Token: 0x02000413 RID: 1043
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 96)]
		public struct <_ShadowFrustumPlanes>e__FixedBuffer
		{
			// Token: 0x040028ED RID: 10477
			public float FixedElementField;
		}

		// Token: 0x02000414 RID: 1044
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 256)]
		public struct <_ShapeParamsAndMaxScatterDists>e__FixedBuffer
		{
			// Token: 0x040028EE RID: 10478
			public float FixedElementField;
		}

		// Token: 0x02000415 RID: 1045
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 256)]
		public struct <_TransmissionTintsAndFresnel0>e__FixedBuffer
		{
			// Token: 0x040028EF RID: 10479
			public float FixedElementField;
		}

		// Token: 0x02000416 RID: 1046
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 256)]
		public struct <_WorldScalesAndFilterRadiiAndThicknessRemaps>e__FixedBuffer
		{
			// Token: 0x040028F0 RID: 10480
			public float FixedElementField;
		}
	}
}
