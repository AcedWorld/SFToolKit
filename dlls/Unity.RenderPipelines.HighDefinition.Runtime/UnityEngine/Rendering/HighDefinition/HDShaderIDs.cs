using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200016C RID: 364
	internal static class HDShaderIDs
	{
		// Token: 0x04000EE2 RID: 3810
		public static readonly int _ZClip = Shader.PropertyToID("_ZClip");

		// Token: 0x04000EE3 RID: 3811
		public static readonly int _HDShadowDatas = Shader.PropertyToID("_HDShadowDatas");

		// Token: 0x04000EE4 RID: 3812
		public static readonly int _HDDirectionalShadowData = Shader.PropertyToID("_HDDirectionalShadowData");

		// Token: 0x04000EE5 RID: 3813
		public static readonly int _ShadowmapAtlas = Shader.PropertyToID("_ShadowmapAtlas");

		// Token: 0x04000EE6 RID: 3814
		public static readonly int _ShadowmapAreaAtlas = Shader.PropertyToID("_ShadowmapAreaAtlas");

		// Token: 0x04000EE7 RID: 3815
		public static readonly int _ShadowmapCascadeAtlas = Shader.PropertyToID("_ShadowmapCascadeAtlas");

		// Token: 0x04000EE8 RID: 3816
		public static readonly int _CachedShadowmapAtlas = Shader.PropertyToID("_CachedShadowmapAtlas");

		// Token: 0x04000EE9 RID: 3817
		public static readonly int _CachedAreaLightShadowmapAtlas = Shader.PropertyToID("_CachedAreaLightShadowmapAtlas");

		// Token: 0x04000EEA RID: 3818
		public static readonly int _CachedShadowAtlasSize = Shader.PropertyToID("_CachedShadowAtlasSize");

		// Token: 0x04000EEB RID: 3819
		public static readonly int _CachedAreaShadowAtlasSize = Shader.PropertyToID("_CachedAreaShadowAtlasSize");

		// Token: 0x04000EEC RID: 3820
		public static readonly int _ClearValue = Shader.PropertyToID("_ClearValue");

		// Token: 0x04000EED RID: 3821
		public static readonly int _Buffer2D = Shader.PropertyToID("_Buffer2D");

		// Token: 0x04000EEE RID: 3822
		public static readonly int _MomentShadowAtlas = Shader.PropertyToID("_MomentShadowAtlas");

		// Token: 0x04000EEF RID: 3823
		public static readonly int _MomentShadowmapSlotST = Shader.PropertyToID("_MomentShadowmapSlotST");

		// Token: 0x04000EF0 RID: 3824
		public static readonly int _MomentShadowmapSize = Shader.PropertyToID("_MomentShadowmapSize");

		// Token: 0x04000EF1 RID: 3825
		public static readonly int _SummedAreaTableInputInt = Shader.PropertyToID("_SummedAreaTableInputInt");

		// Token: 0x04000EF2 RID: 3826
		public static readonly int _SummedAreaTableOutputInt = Shader.PropertyToID("_SummedAreaTableOutputInt");

		// Token: 0x04000EF3 RID: 3827
		public static readonly int _SummedAreaTableInputFloat = Shader.PropertyToID("_SummedAreaTableInputFloat");

		// Token: 0x04000EF4 RID: 3828
		public static readonly int _IMSKernelSize = Shader.PropertyToID("_IMSKernelSize");

		// Token: 0x04000EF5 RID: 3829
		public static readonly int _SrcRect = Shader.PropertyToID("_SrcRect");

		// Token: 0x04000EF6 RID: 3830
		public static readonly int _DstRect = Shader.PropertyToID("_DstRect");

		// Token: 0x04000EF7 RID: 3831
		public static readonly int _EVSMExponent = Shader.PropertyToID("_EVSMExponent");

		// Token: 0x04000EF8 RID: 3832
		public static readonly int _BlurWeightsStorage = Shader.PropertyToID("_BlurWeightsStorage");

		// Token: 0x04000EF9 RID: 3833
		public static readonly int g_LayeredSingleIdxBuffer = Shader.PropertyToID("g_LayeredSingleIdxBuffer");

		// Token: 0x04000EFA RID: 3834
		public static readonly int g_depth_tex = Shader.PropertyToID("g_depth_tex");

		// Token: 0x04000EFB RID: 3835
		public static readonly int g_vLayeredLightList = Shader.PropertyToID("g_vLayeredLightList");

		// Token: 0x04000EFC RID: 3836
		public static readonly int g_LayeredOffset = Shader.PropertyToID("g_LayeredOffset");

		// Token: 0x04000EFD RID: 3837
		public static readonly int g_vBigTileLightList = Shader.PropertyToID("g_vBigTileLightList");

		// Token: 0x04000EFE RID: 3838
		public static readonly int g_vLightListGlobal = Shader.PropertyToID("g_vLightListGlobal");

		// Token: 0x04000EFF RID: 3839
		public static readonly int g_vLightListTile = Shader.PropertyToID("g_vLightListTile");

		// Token: 0x04000F00 RID: 3840
		public static readonly int g_vLightListCluster = Shader.PropertyToID("g_vLightListCluster");

		// Token: 0x04000F01 RID: 3841
		public static readonly int g_logBaseBuffer = Shader.PropertyToID("g_logBaseBuffer");

		// Token: 0x04000F02 RID: 3842
		public static readonly int g_vBoundsBuffer = Shader.PropertyToID("g_vBoundsBuffer");

		// Token: 0x04000F03 RID: 3843
		public static readonly int _LightVolumeData = Shader.PropertyToID("_LightVolumeData");

		// Token: 0x04000F04 RID: 3844
		public static readonly int g_data = Shader.PropertyToID("g_data");

		// Token: 0x04000F05 RID: 3845
		public static readonly int g_vLightList = Shader.PropertyToID("g_vLightList");

		// Token: 0x04000F06 RID: 3846
		public static readonly int g_TileFeatureFlags = Shader.PropertyToID("g_TileFeatureFlags");

		// Token: 0x04000F07 RID: 3847
		public static readonly int g_DispatchIndirectBuffer = Shader.PropertyToID("g_DispatchIndirectBuffer");

		// Token: 0x04000F08 RID: 3848
		public static readonly int g_TileList = Shader.PropertyToID("g_TileList");

		// Token: 0x04000F09 RID: 3849
		public static readonly int g_NumTiles = Shader.PropertyToID("g_NumTiles");

		// Token: 0x04000F0A RID: 3850
		public static readonly int g_NumTilesX = Shader.PropertyToID("g_NumTilesX");

		// Token: 0x04000F0B RID: 3851
		public static readonly int g_VertexPerTile = Shader.PropertyToID("g_VertexPerTile");

		// Token: 0x04000F0C RID: 3852
		public static readonly int _NumTiles = Shader.PropertyToID("_NumTiles");

		// Token: 0x04000F0D RID: 3853
		public static readonly int _CookieAtlas = Shader.PropertyToID("_CookieAtlas");

		// Token: 0x04000F0E RID: 3854
		public static readonly int _ReflectionAtlas = Shader.PropertyToID("_ReflectionAtlas");

		// Token: 0x04000F0F RID: 3855
		public static readonly int _DirectionalLightDatas = Shader.PropertyToID("_DirectionalLightDatas");

		// Token: 0x04000F10 RID: 3856
		public static readonly int _LightDatas = Shader.PropertyToID("_LightDatas");

		// Token: 0x04000F11 RID: 3857
		public static readonly int _EnvLightDatas = Shader.PropertyToID("_EnvLightDatas");

		// Token: 0x04000F12 RID: 3858
		public static readonly int _AmbientProbeData = Shader.PropertyToID("_AmbientProbeData");

		// Token: 0x04000F13 RID: 3859
		public static readonly int _EnvLightReflectionData = Shader.PropertyToID("EnvLightReflectionData");

		// Token: 0x04000F14 RID: 3860
		public static readonly int _EnvLightReflectionDataRT = Shader.PropertyToID("EnvLightReflectionDataRT");

		// Token: 0x04000F15 RID: 3861
		public static readonly int _ProbeVolumeBounds = Shader.PropertyToID("_ProbeVolumeBounds");

		// Token: 0x04000F16 RID: 3862
		public static readonly int _ProbeVolumeDatas = Shader.PropertyToID("_ProbeVolumeDatas");

		// Token: 0x04000F17 RID: 3863
		public static readonly int g_vLayeredOffsetsBuffer = Shader.PropertyToID("g_vLayeredOffsetsBuffer");

		// Token: 0x04000F18 RID: 3864
		public static readonly int _LightListToClear = Shader.PropertyToID("_LightListToClear");

		// Token: 0x04000F19 RID: 3865
		public static readonly int _LightListEntriesAndOffset = Shader.PropertyToID("_LightListEntriesAndOffset");

		// Token: 0x04000F1A RID: 3866
		public static readonly int _ViewTilesFlags = Shader.PropertyToID("_ViewTilesFlags");

		// Token: 0x04000F1B RID: 3867
		public static readonly int _ClusterDebugMode = Shader.PropertyToID("_ClusterDebugMode");

		// Token: 0x04000F1C RID: 3868
		public static readonly int _ClusterDebugDistance = Shader.PropertyToID("_ClusterDebugDistance");

		// Token: 0x04000F1D RID: 3869
		public static readonly int _ClusterDebugLightViewportSize = Shader.PropertyToID("_ClusterDebugLightViewportSize");

		// Token: 0x04000F1E RID: 3870
		public static readonly int _MousePixelCoord = Shader.PropertyToID("_MousePixelCoord");

		// Token: 0x04000F1F RID: 3871
		public static readonly int _MouseClickPixelCoord = Shader.PropertyToID("_MouseClickPixelCoord");

		// Token: 0x04000F20 RID: 3872
		public static readonly int _DebugFont = Shader.PropertyToID("_DebugFont");

		// Token: 0x04000F21 RID: 3873
		public static readonly int _SliceIndex = Shader.PropertyToID("_SliceIndex");

		// Token: 0x04000F22 RID: 3874
		public static readonly int _DebugContactShadowLightIndex = Shader.PropertyToID("_DebugContactShadowLightIndex");

		// Token: 0x04000F23 RID: 3875
		public static readonly int _AmbientOcclusionTexture = Shader.PropertyToID("_AmbientOcclusionTexture");

		// Token: 0x04000F24 RID: 3876
		public static readonly int _AmbientOcclusionTextureRW = Shader.PropertyToID("_AmbientOcclusionTextureRW");

		// Token: 0x04000F25 RID: 3877
		public static readonly int _MultiAmbientOcclusionTexture = Shader.PropertyToID("_MultiAmbientOcclusionTexture");

		// Token: 0x04000F26 RID: 3878
		public static readonly int _DebugDepthPyramidMip = Shader.PropertyToID("_DebugDepthPyramidMip");

		// Token: 0x04000F27 RID: 3879
		public static readonly int _DebugDepthPyramidOffsets = Shader.PropertyToID("_DebugDepthPyramidOffsets");

		// Token: 0x04000F28 RID: 3880
		public static readonly int _UseTileLightList = Shader.PropertyToID("_UseTileLightList");

		// Token: 0x04000F29 RID: 3881
		public static readonly int _SkyTexture = Shader.PropertyToID("_SkyTexture");

		// Token: 0x04000F2A RID: 3882
		public static readonly int specularLightingUAV = Shader.PropertyToID("specularLightingUAV");

		// Token: 0x04000F2B RID: 3883
		public static readonly int diffuseLightingUAV = Shader.PropertyToID("diffuseLightingUAV");

		// Token: 0x04000F2C RID: 3884
		public static readonly int _SssSampleBudget = Shader.PropertyToID("_SssSampleBudget");

		// Token: 0x04000F2D RID: 3885
		public static readonly int _MaterialID = Shader.PropertyToID("_MaterialID");

		// Token: 0x04000F2E RID: 3886
		public static readonly int g_TileListOffset = Shader.PropertyToID("g_TileListOffset");

		// Token: 0x04000F2F RID: 3887
		public static readonly int _LtcData = Shader.PropertyToID("_LtcData");

		// Token: 0x04000F30 RID: 3888
		public static readonly int _LtcGGXMatrix = Shader.PropertyToID("_LtcGGXMatrix");

		// Token: 0x04000F31 RID: 3889
		public static readonly int _LtcDisneyDiffuseMatrix = Shader.PropertyToID("_LtcDisneyDiffuseMatrix");

		// Token: 0x04000F32 RID: 3890
		public static readonly int _LtcMultiGGXFresnelDisneyDiffuse = Shader.PropertyToID("_LtcMultiGGXFresnelDisneyDiffuse");

		// Token: 0x04000F33 RID: 3891
		public static readonly int _ScreenSpaceShadowsTexture = Shader.PropertyToID("_ScreenSpaceShadowsTexture");

		// Token: 0x04000F34 RID: 3892
		public static readonly int _ContactShadowTexture = Shader.PropertyToID("_ContactShadowTexture");

		// Token: 0x04000F35 RID: 3893
		public static readonly int _ContactShadowTextureUAV = Shader.PropertyToID("_ContactShadowTextureUAV");

		// Token: 0x04000F36 RID: 3894
		public static readonly int _ContactShadowParamsParameters = Shader.PropertyToID("_ContactShadowParamsParameters");

		// Token: 0x04000F37 RID: 3895
		public static readonly int _ContactShadowParamsParameters2 = Shader.PropertyToID("_ContactShadowParamsParameters2");

		// Token: 0x04000F38 RID: 3896
		public static readonly int _ContactShadowParamsParameters3 = Shader.PropertyToID("_ContactShadowParamsParameters3");

		// Token: 0x04000F39 RID: 3897
		public static readonly int _DirectionalContactShadowSampleCount = Shader.PropertyToID("_SampleCount");

		// Token: 0x04000F3A RID: 3898
		public static readonly int _ShadowFrustumPlanes = Shader.PropertyToID("_ShadowFrustumPlanes");

		// Token: 0x04000F3B RID: 3899
		public static readonly int _StencilMask = Shader.PropertyToID("_StencilMask");

		// Token: 0x04000F3C RID: 3900
		public static readonly int _StencilRef = Shader.PropertyToID("_StencilRef");

		// Token: 0x04000F3D RID: 3901
		public static readonly int _StencilCmp = Shader.PropertyToID("_StencilCmp");

		// Token: 0x04000F3E RID: 3902
		public static readonly int _LightLayersMaskBuffer4 = Shader.PropertyToID("_LightLayersMaskBuffer4");

		// Token: 0x04000F3F RID: 3903
		public static readonly int _LightLayersMaskBuffer5 = Shader.PropertyToID("_LightLayersMaskBuffer5");

		// Token: 0x04000F40 RID: 3904
		public static readonly int _InputDepth = Shader.PropertyToID("_InputDepthTexture");

		// Token: 0x04000F41 RID: 3905
		public static readonly int _ClearColor = Shader.PropertyToID("_ClearColor");

		// Token: 0x04000F42 RID: 3906
		public static readonly int _SrcBlend = Shader.PropertyToID("_SrcBlend");

		// Token: 0x04000F43 RID: 3907
		public static readonly int _DstBlend = Shader.PropertyToID("_DstBlend");

		// Token: 0x04000F44 RID: 3908
		public static readonly int _ColorMaskTransparentVelOne = Shader.PropertyToID("_ColorMaskTransparentVelOne");

		// Token: 0x04000F45 RID: 3909
		public static readonly int _ColorMaskTransparentVelTwo = Shader.PropertyToID("_ColorMaskTransparentVelTwo");

		// Token: 0x04000F46 RID: 3910
		public static readonly int _DecalColorMask0 = Shader.PropertyToID("_DecalColorMask0");

		// Token: 0x04000F47 RID: 3911
		public static readonly int _DecalColorMask1 = Shader.PropertyToID("_DecalColorMask1");

		// Token: 0x04000F48 RID: 3912
		public static readonly int _DecalColorMask2 = Shader.PropertyToID("_DecalColorMask2");

		// Token: 0x04000F49 RID: 3913
		public static readonly int _DecalColorMask3 = Shader.PropertyToID("_DecalColorMask3");

		// Token: 0x04000F4A RID: 3914
		public static readonly int _StencilTexture = Shader.PropertyToID("_StencilTexture");

		// Token: 0x04000F4B RID: 3915
		public static readonly int _OutputStencilBuffer = Shader.PropertyToID("_OutputStencilBuffer");

		// Token: 0x04000F4C RID: 3916
		public static readonly int _CoarseStencilBuffer = Shader.PropertyToID("_CoarseStencilBuffer");

		// Token: 0x04000F4D RID: 3917
		public static readonly int _CoarseStencilBufferSize = Shader.PropertyToID("_CoarseStencilBufferSize");

		// Token: 0x04000F4E RID: 3918
		public static readonly int _NormalToWorldID = Shader.PropertyToID("_NormalToWorld");

		// Token: 0x04000F4F RID: 3919
		public static readonly int _DecalAtlas2DID = Shader.PropertyToID("_DecalAtlas2D");

		// Token: 0x04000F50 RID: 3920
		public static readonly int _DecalHTileTexture = Shader.PropertyToID("_DecalHTileTexture");

		// Token: 0x04000F51 RID: 3921
		public static readonly int _DecalDatas = Shader.PropertyToID("_DecalDatas");

		// Token: 0x04000F52 RID: 3922
		public static readonly int _DecalNormalBufferStencilReadMask = Shader.PropertyToID("_DecalNormalBufferStencilReadMask");

		// Token: 0x04000F53 RID: 3923
		public static readonly int _DecalNormalBufferStencilRef = Shader.PropertyToID("_DecalNormalBufferStencilRef");

		// Token: 0x04000F54 RID: 3924
		public static readonly int _DecalPrepassTexture = Shader.PropertyToID("_DecalPrepassTexture");

		// Token: 0x04000F55 RID: 3925
		public static readonly int _DecalPrepassTextureMS = Shader.PropertyToID("_DecalPrepassTextureMS");

		// Token: 0x04000F56 RID: 3926
		public static readonly int _DrawOrder = Shader.PropertyToID("_DrawOrder");

		// Token: 0x04000F57 RID: 3927
		public static readonly int _AffectAlbedo = Shader.PropertyToID("_AffectAlbedo");

		// Token: 0x04000F58 RID: 3928
		public static readonly int _AffectNormal = Shader.PropertyToID("_AffectNormal");

		// Token: 0x04000F59 RID: 3929
		public static readonly int _AffectAO = Shader.PropertyToID("_AffectAO");

		// Token: 0x04000F5A RID: 3930
		public static readonly int _AffectMetal = Shader.PropertyToID("_AffectMetal");

		// Token: 0x04000F5B RID: 3931
		public static readonly int _AffectSmoothness = Shader.PropertyToID("_AffectSmoothness");

		// Token: 0x04000F5C RID: 3932
		public static readonly int _AffectEmission = Shader.PropertyToID("_AffectEmission");

		// Token: 0x04000F5D RID: 3933
		public static readonly int _WorldSpaceCameraPos = Shader.PropertyToID("_WorldSpaceCameraPos");

		// Token: 0x04000F5E RID: 3934
		public static readonly int _PrevCamPosRWS = Shader.PropertyToID("_PrevCamPosRWS");

		// Token: 0x04000F5F RID: 3935
		public static readonly int _ViewMatrix = Shader.PropertyToID("_ViewMatrix");

		// Token: 0x04000F60 RID: 3936
		public static readonly int _CameraViewMatrix = Shader.PropertyToID("_CameraViewMatrix");

		// Token: 0x04000F61 RID: 3937
		public static readonly int _InvViewMatrix = Shader.PropertyToID("_InvViewMatrix");

		// Token: 0x04000F62 RID: 3938
		public static readonly int _ProjMatrix = Shader.PropertyToID("_ProjMatrix");

		// Token: 0x04000F63 RID: 3939
		public static readonly int _InvProjMatrix = Shader.PropertyToID("_InvProjMatrix");

		// Token: 0x04000F64 RID: 3940
		public static readonly int _NonJitteredViewProjMatrix = Shader.PropertyToID("_NonJitteredViewProjMatrix");

		// Token: 0x04000F65 RID: 3941
		public static readonly int _ViewProjMatrix = Shader.PropertyToID("_ViewProjMatrix");

		// Token: 0x04000F66 RID: 3942
		public static readonly int _CameraViewProjMatrix = Shader.PropertyToID("_CameraViewProjMatrix");

		// Token: 0x04000F67 RID: 3943
		public static readonly int _InvViewProjMatrix = Shader.PropertyToID("_InvViewProjMatrix");

		// Token: 0x04000F68 RID: 3944
		public static readonly int _ZBufferParams = Shader.PropertyToID("_ZBufferParams");

		// Token: 0x04000F69 RID: 3945
		public static readonly int _ProjectionParams = Shader.PropertyToID("_ProjectionParams");

		// Token: 0x04000F6A RID: 3946
		public static readonly int unity_OrthoParams = Shader.PropertyToID("unity_OrthoParams");

		// Token: 0x04000F6B RID: 3947
		public static readonly int _InvProjParam = Shader.PropertyToID("_InvProjParam");

		// Token: 0x04000F6C RID: 3948
		public static readonly int _ScreenSize = Shader.PropertyToID("_ScreenSize");

		// Token: 0x04000F6D RID: 3949
		public static readonly int _HalfScreenSize = Shader.PropertyToID("_HalfScreenSize");

		// Token: 0x04000F6E RID: 3950
		public static readonly int _ScreenParams = Shader.PropertyToID("_ScreenParams");

		// Token: 0x04000F6F RID: 3951
		public static readonly int _RTHandleScale = Shader.PropertyToID("_RTHandleScale");

		// Token: 0x04000F70 RID: 3952
		public static readonly int _RTHandleScaleHistory = Shader.PropertyToID("_RTHandleScaleHistory");

		// Token: 0x04000F71 RID: 3953
		public static readonly int _PrevViewProjMatrix = Shader.PropertyToID("_PrevViewProjMatrix");

		// Token: 0x04000F72 RID: 3954
		public static readonly int _PrevInvViewProjMatrix = Shader.PropertyToID("_PrevInvViewProjMatrix");

		// Token: 0x04000F73 RID: 3955
		public static readonly int _FrustumPlanes = Shader.PropertyToID("_FrustumPlanes");

		// Token: 0x04000F74 RID: 3956
		public static readonly int _TaaFrameInfo = Shader.PropertyToID("_TaaFrameInfo");

		// Token: 0x04000F75 RID: 3957
		public static readonly int _TaaJitterStrength = Shader.PropertyToID("_TaaJitterStrength");

		// Token: 0x04000F76 RID: 3958
		public static readonly int _TaaPostParameters = Shader.PropertyToID("_TaaPostParameters");

		// Token: 0x04000F77 RID: 3959
		public static readonly int _TaaPostParameters1 = Shader.PropertyToID("_TaaPostParameters1");

		// Token: 0x04000F78 RID: 3960
		public static readonly int _TaaHistorySize = Shader.PropertyToID("_TaaHistorySize");

		// Token: 0x04000F79 RID: 3961
		public static readonly int _TaaFilterWeights = Shader.PropertyToID("_TaaFilterWeights");

		// Token: 0x04000F7A RID: 3962
		public static readonly int _NeighbourOffsets = Shader.PropertyToID("_NeighbourOffsets");

		// Token: 0x04000F7B RID: 3963
		public static readonly int _TaauParameters = Shader.PropertyToID("_TaauParameters");

		// Token: 0x04000F7C RID: 3964
		public static readonly int _TaaScales = Shader.PropertyToID("_TaaScales");

		// Token: 0x04000F7D RID: 3965
		public static readonly int _WorldSpaceCameraPos1 = Shader.PropertyToID("_WorldSpaceCameraPos1");

		// Token: 0x04000F7E RID: 3966
		public static readonly int _ViewMatrix1 = Shader.PropertyToID("_ViewMatrix1");

		// Token: 0x04000F7F RID: 3967
		public static readonly int _ColorTexture = Shader.PropertyToID("_ColorTexture");

		// Token: 0x04000F80 RID: 3968
		public static readonly int _DepthTexture = Shader.PropertyToID("_DepthTexture");

		// Token: 0x04000F81 RID: 3969
		public static readonly int _DepthValuesTexture = Shader.PropertyToID("_DepthValuesTexture");

		// Token: 0x04000F82 RID: 3970
		public static readonly int _CameraColorTexture = Shader.PropertyToID("_CameraColorTexture");

		// Token: 0x04000F83 RID: 3971
		public static readonly int _CameraColorTextureRW = Shader.PropertyToID("_CameraColorTextureRW");

		// Token: 0x04000F84 RID: 3972
		public static readonly int _CameraSssDiffuseLightingBuffer = Shader.PropertyToID("_CameraSssDiffuseLightingTexture");

		// Token: 0x04000F85 RID: 3973
		public static readonly int _CameraFilteringBuffer = Shader.PropertyToID("_CameraFilteringTexture");

		// Token: 0x04000F86 RID: 3974
		public static readonly int _IrradianceSource = Shader.PropertyToID("_IrradianceSource");

		// Token: 0x04000F87 RID: 3975
		public static readonly int _InputDepthTexture = Shader.PropertyToID("_InputDepthTexture");

		// Token: 0x04000F88 RID: 3976
		public static readonly int _ReflectionColorMipChain = Shader.PropertyToID("_ReflectionColorMipChain");

		// Token: 0x04000F89 RID: 3977
		public static readonly int _DepthTextureMipChain = Shader.PropertyToID("_DepthTextureMipChain");

		// Token: 0x04000F8A RID: 3978
		public static readonly int _ReflectionPlaneNormal = Shader.PropertyToID("_ReflectionPlaneNormal");

		// Token: 0x04000F8B RID: 3979
		public static readonly int _ReflectionPlanePosition = Shader.PropertyToID("_ReflectionPlanePosition");

		// Token: 0x04000F8C RID: 3980
		public static readonly int _FilteredPlanarReflectionBuffer = Shader.PropertyToID("_FilteredPlanarReflectionBuffer");

		// Token: 0x04000F8D RID: 3981
		public static readonly int _HalfResReflectionBuffer = Shader.PropertyToID("_HalfResReflectionBuffer");

		// Token: 0x04000F8E RID: 3982
		public static readonly int _HalfResDepthBuffer = Shader.PropertyToID("_HalfResDepthBuffer");

		// Token: 0x04000F8F RID: 3983
		public static readonly int _CaptureBaseScreenSize = Shader.PropertyToID("_CaptureBaseScreenSize");

		// Token: 0x04000F90 RID: 3984
		public static readonly int _CaptureCurrentScreenSize = Shader.PropertyToID("_CaptureCurrentScreenSize");

		// Token: 0x04000F91 RID: 3985
		public static readonly int _CaptureCameraIVP = Shader.PropertyToID("_CaptureCameraIVP");

		// Token: 0x04000F92 RID: 3986
		public static readonly int _CaptureCameraPositon = Shader.PropertyToID("_CaptureCameraPositon");

		// Token: 0x04000F93 RID: 3987
		public static readonly int _SourceMipIndex = Shader.PropertyToID("_SourceMipIndex");

		// Token: 0x04000F94 RID: 3988
		public static readonly int _MaxMipLevels = Shader.PropertyToID("_MaxMipLevels");

		// Token: 0x04000F95 RID: 3989
		public static readonly int _ThetaValuesTexture = Shader.PropertyToID("_ThetaValuesTexture");

		// Token: 0x04000F96 RID: 3990
		public static readonly int _CaptureCameraFOV = Shader.PropertyToID("_CaptureCameraFOV");

		// Token: 0x04000F97 RID: 3991
		public static readonly int _RTScaleFactor = Shader.PropertyToID("_RTScaleFactor");

		// Token: 0x04000F98 RID: 3992
		public static readonly int _CaptureCameraVP_NO = Shader.PropertyToID("_CaptureCameraVP_NO");

		// Token: 0x04000F99 RID: 3993
		public static readonly int _CaptureCameraFarPlane = Shader.PropertyToID("_CaptureCameraFarPlane");

		// Token: 0x04000F9A RID: 3994
		public static readonly int _DepthTextureOblique = Shader.PropertyToID("_DepthTextureOblique");

		// Token: 0x04000F9B RID: 3995
		public static readonly int _DepthTextureNonOblique = Shader.PropertyToID("_DepthTextureNonOblique");

		// Token: 0x04000F9C RID: 3996
		public static readonly int _CaptureCameraIVP_NO = Shader.PropertyToID("_CaptureCameraIVP_NO");

		// Token: 0x04000F9D RID: 3997
		public static readonly int _Output = Shader.PropertyToID("_Output");

		// Token: 0x04000F9E RID: 3998
		public static readonly int _Input = Shader.PropertyToID("_Input");

		// Token: 0x04000F9F RID: 3999
		public static readonly int _InputVal = Shader.PropertyToID("_InputVal");

		// Token: 0x04000FA0 RID: 4000
		public static readonly int _Sizes = Shader.PropertyToID("_Sizes");

		// Token: 0x04000FA1 RID: 4001
		public static readonly int _ScaleBias = Shader.PropertyToID("_ScaleBias");

		// Token: 0x04000FA2 RID: 4002
		public static readonly int _ColorTextureMS = Shader.PropertyToID("_ColorTextureMS");

		// Token: 0x04000FA3 RID: 4003
		public static readonly int _DepthTextureMS = Shader.PropertyToID("_DepthTextureMS");

		// Token: 0x04000FA4 RID: 4004
		public static readonly int _NormalTextureMS = Shader.PropertyToID("_NormalTextureMS");

		// Token: 0x04000FA5 RID: 4005
		public static readonly int _RaytracePrepassBufferMS = Shader.PropertyToID("_RaytracePrepassBufferMS");

		// Token: 0x04000FA6 RID: 4006
		public static readonly int _MotionVectorTextureMS = Shader.PropertyToID("_MotionVectorTextureMS");

		// Token: 0x04000FA7 RID: 4007
		public static readonly int _CameraDepthValuesTexture = Shader.PropertyToID("_CameraDepthValues");

		// Token: 0x04000FA8 RID: 4008
		public static readonly int[] _GBufferTexture = new int[]
		{
			Shader.PropertyToID("_GBufferTexture0"),
			Shader.PropertyToID("_GBufferTexture1"),
			Shader.PropertyToID("_GBufferTexture2"),
			Shader.PropertyToID("_GBufferTexture3"),
			Shader.PropertyToID("_GBufferTexture4"),
			Shader.PropertyToID("_GBufferTexture5"),
			Shader.PropertyToID("_GBufferTexture6"),
			Shader.PropertyToID("_GBufferTexture7")
		};

		// Token: 0x04000FA9 RID: 4009
		public static readonly int[] _GBufferTextureRW = new int[]
		{
			Shader.PropertyToID("_GBufferTexture0RW"),
			Shader.PropertyToID("_GBufferTexture1RW"),
			Shader.PropertyToID("_GBufferTexture2RW"),
			Shader.PropertyToID("_GBufferTexture3RW"),
			Shader.PropertyToID("_GBufferTexture4RW"),
			Shader.PropertyToID("_GBufferTexture5RW"),
			Shader.PropertyToID("_GBufferTexture6RW"),
			Shader.PropertyToID("_GBufferTexture7RW")
		};

		// Token: 0x04000FAA RID: 4010
		public static readonly int[] _DBufferTexture = new int[]
		{
			Shader.PropertyToID("_DBufferTexture0"),
			Shader.PropertyToID("_DBufferTexture1"),
			Shader.PropertyToID("_DBufferTexture2"),
			Shader.PropertyToID("_DBufferTexture3")
		};

		// Token: 0x04000FAB RID: 4011
		public static readonly int _ShaderVariablesGlobal = Shader.PropertyToID("ShaderVariablesGlobal");

		// Token: 0x04000FAC RID: 4012
		public static readonly int _ShaderVariablesXR = Shader.PropertyToID("ShaderVariablesXR");

		// Token: 0x04000FAD RID: 4013
		public static readonly int _ShaderVariablesVolumetric = Shader.PropertyToID("ShaderVariablesVolumetric");

		// Token: 0x04000FAE RID: 4014
		public static readonly int _ShaderVariablesLightList = Shader.PropertyToID("ShaderVariablesLightList");

		// Token: 0x04000FAF RID: 4015
		public static readonly int _ShaderVariablesRaytracing = Shader.PropertyToID("ShaderVariablesRaytracing");

		// Token: 0x04000FB0 RID: 4016
		public static readonly int _ShaderVariablesBilateralUpsample = Shader.PropertyToID("ShaderVariablesBilateralUpsample");

		// Token: 0x04000FB1 RID: 4017
		public static readonly int _ShaderVariablesRaytracingLightLoop = Shader.PropertyToID("ShaderVariablesRaytracingLightLoop");

		// Token: 0x04000FB2 RID: 4018
		public static readonly int _ShaderVariablesDebugDisplay = Shader.PropertyToID("ShaderVariablesDebugDisplay");

		// Token: 0x04000FB3 RID: 4019
		public static readonly int _ShaderVariablesClouds = Shader.PropertyToID("ShaderVariablesClouds");

		// Token: 0x04000FB4 RID: 4020
		public static readonly int _ShaderVariablesWater = Shader.PropertyToID("ShaderVariablesWater");

		// Token: 0x04000FB5 RID: 4021
		public static readonly int _ShaderVariablesUnderWater = Shader.PropertyToID("ShaderVariablesUnderWater");

		// Token: 0x04000FB6 RID: 4022
		public static readonly int _ShaderVariablesWaterRendering = Shader.PropertyToID("ShaderVariablesWaterRendering");

		// Token: 0x04000FB7 RID: 4023
		public static readonly int _SSSBufferTexture = Shader.PropertyToID("_SSSBufferTexture");

		// Token: 0x04000FB8 RID: 4024
		public static readonly int _NormalBufferTexture = Shader.PropertyToID("_NormalBufferTexture");

		// Token: 0x04000FB9 RID: 4025
		public static readonly int _NormalBufferRW = Shader.PropertyToID("_NormalBufferRW");

		// Token: 0x04000FBA RID: 4026
		public static readonly int _RaytracePrepassBufferTexture = Shader.PropertyToID("_RaytracePrepassBufferTexture");

		// Token: 0x04000FBB RID: 4027
		public static readonly int _ShaderVariablesScreenSpaceReflection = Shader.PropertyToID("ShaderVariablesScreenSpaceReflection");

		// Token: 0x04000FBC RID: 4028
		public static readonly int _SsrFrameIndex = Shader.PropertyToID("_SsrFrameIndex");

		// Token: 0x04000FBD RID: 4029
		public static readonly int _SsrLightingTexture = Shader.PropertyToID("_SsrLightingTexture");

		// Token: 0x04000FBE RID: 4030
		public static readonly int _SsrAccumPrev = Shader.PropertyToID("_SsrAccumPrev");

		// Token: 0x04000FBF RID: 4031
		public static readonly int _SsrLightingTextureRW = Shader.PropertyToID("_SsrLightingTextureRW");

		// Token: 0x04000FC0 RID: 4032
		public static readonly int _DirectionPDFTexture = Shader.PropertyToID("_DirectionPDFTexture");

		// Token: 0x04000FC1 RID: 4033
		public static readonly int _SSRAccumTexture = Shader.PropertyToID("_SSRAccumTexture");

		// Token: 0x04000FC2 RID: 4034
		public static readonly int _SsrHitPointTexture = Shader.PropertyToID("_SsrHitPointTexture");

		// Token: 0x04000FC3 RID: 4035
		public static readonly int _SsrPBRBias = Shader.PropertyToID("_SsrPBRBias");

		// Token: 0x04000FC4 RID: 4036
		public static readonly int _SsrPBRSpeedRejection = Shader.PropertyToID("_SsrPBRSpeedRejection");

		// Token: 0x04000FC5 RID: 4037
		public static readonly int _SsrPRBSpeedRejectionScalerFactor = Shader.PropertyToID("_SsrPRBSpeedRejectionScalerFactor");

		// Token: 0x04000FC6 RID: 4038
		public static readonly int _SsrClearCoatMaskTexture = Shader.PropertyToID("_SsrClearCoatMaskTexture");

		// Token: 0x04000FC7 RID: 4039
		public static readonly int _DepthPyramidMipLevelOffsets = Shader.PropertyToID("_DepthPyramidMipLevelOffsets");

		// Token: 0x04000FC8 RID: 4040
		public static readonly int _DepthPyramidFirstMipLevelOffset = Shader.PropertyToID("_DepthPyramidFirstMipLevelOffset");

		// Token: 0x04000FC9 RID: 4041
		public static readonly int _SsrStencilBit = Shader.PropertyToID("_SsrStencilBit");

		// Token: 0x04000FCA RID: 4042
		public static readonly int _DeferredStencilBit = Shader.PropertyToID("_DeferredStencilBit");

		// Token: 0x04000FCB RID: 4043
		public static readonly int _ShadowMaskTexture = Shader.PropertyToID("_ShadowMaskTexture");

		// Token: 0x04000FCC RID: 4044
		public static readonly int _LightLayersTexture = Shader.PropertyToID("_LightLayersTexture");

		// Token: 0x04000FCD RID: 4045
		public static readonly int _DistortionTexture = Shader.PropertyToID("_DistortionTexture");

		// Token: 0x04000FCE RID: 4046
		public static readonly int _ColorPyramidTexture = Shader.PropertyToID("_ColorPyramidTexture");

		// Token: 0x04000FCF RID: 4047
		public static readonly int _ColorPyramidUvScaleAndLimitPrevFrame = Shader.PropertyToID("_ColorPyramidUvScaleAndLimitPrevFrame");

		// Token: 0x04000FD0 RID: 4048
		public static readonly int _RoughDistortion = Shader.PropertyToID("_RoughDistortion");

		// Token: 0x04000FD1 RID: 4049
		public static readonly int _DebugColorPickerTexture = Shader.PropertyToID("_DebugColorPickerTexture");

		// Token: 0x04000FD2 RID: 4050
		public static readonly int _ColorPickerMode = Shader.PropertyToID("_ColorPickerMode");

		// Token: 0x04000FD3 RID: 4051
		public static readonly int _ApplyLinearToSRGB = Shader.PropertyToID("_ApplyLinearToSRGB");

		// Token: 0x04000FD4 RID: 4052
		public static readonly int _ColorPickerFontColor = Shader.PropertyToID("_ColorPickerFontColor");

		// Token: 0x04000FD5 RID: 4053
		public static readonly int _FalseColorEnabled = Shader.PropertyToID("_FalseColor");

		// Token: 0x04000FD6 RID: 4054
		public static readonly int _FalseColorThresholds = Shader.PropertyToID("_FalseColorThresholds");

		// Token: 0x04000FD7 RID: 4055
		public static readonly int _DebugMatCapTexture = Shader.PropertyToID("_DebugMatCapTexture");

		// Token: 0x04000FD8 RID: 4056
		public static readonly int _MatcapViewScale = Shader.PropertyToID("_MatcapViewScale");

		// Token: 0x04000FD9 RID: 4057
		public static readonly int _MatcapMixAlbedo = Shader.PropertyToID("_MatcapMixAlbedo");

		// Token: 0x04000FDA RID: 4058
		public static readonly int _DebugFullScreenTexture = Shader.PropertyToID("_DebugFullScreenTexture");

		// Token: 0x04000FDB RID: 4059
		public static readonly int _BlitTexture = Shader.PropertyToID("_BlitTexture");

		// Token: 0x04000FDC RID: 4060
		public static readonly int _BlitTextureMSAA = Shader.PropertyToID("_BlitTextureMSAA");

		// Token: 0x04000FDD RID: 4061
		public static readonly int _BlitScaleBias = Shader.PropertyToID("_BlitScaleBias");

		// Token: 0x04000FDE RID: 4062
		public static readonly int _BlitMipLevel = Shader.PropertyToID("_BlitMipLevel");

		// Token: 0x04000FDF RID: 4063
		public static readonly int _BlitScaleBiasRt = Shader.PropertyToID("_BlitScaleBiasRt");

		// Token: 0x04000FE0 RID: 4064
		public static readonly int _BlitTextureSize = Shader.PropertyToID("_BlitTextureSize");

		// Token: 0x04000FE1 RID: 4065
		public static readonly int _BlitPaddingSize = Shader.PropertyToID("_BlitPaddingSize");

		// Token: 0x04000FE2 RID: 4066
		public static readonly int _BlitTexArraySlice = Shader.PropertyToID("_BlitTexArraySlice");

		// Token: 0x04000FE3 RID: 4067
		public static readonly int _CameraDepthTexture = Shader.PropertyToID("_CameraDepthTexture");

		// Token: 0x04000FE4 RID: 4068
		public static readonly int _CameraMotionVectorsTexture = Shader.PropertyToID("_CameraMotionVectorsTexture");

		// Token: 0x04000FE5 RID: 4069
		public static readonly int _FullScreenDebugMode = Shader.PropertyToID("_FullScreenDebugMode");

		// Token: 0x04000FE6 RID: 4070
		public static readonly int _FullScreenDebugDepthRemap = Shader.PropertyToID("_FullScreenDebugDepthRemap");

		// Token: 0x04000FE7 RID: 4071
		public static readonly int _FullScreenDebugBuffer = Shader.PropertyToID("_FullScreenDebugBuffer");

		// Token: 0x04000FE8 RID: 4072
		public static readonly int _TransparencyOverdrawMaxPixelCost = Shader.PropertyToID("_TransparencyOverdrawMaxPixelCost");

		// Token: 0x04000FE9 RID: 4073
		public static readonly int _FogVolumeOverdrawMaxValue = Shader.PropertyToID("_FogVolumeOverdrawMaxValue");

		// Token: 0x04000FEA RID: 4074
		public static readonly int _QuadOverdrawClearBuffParams = Shader.PropertyToID("_QuadOverdrawClearBuffParams");

		// Token: 0x04000FEB RID: 4075
		public static readonly int _QuadOverdrawMaxQuadCost = Shader.PropertyToID("_QuadOverdrawMaxQuadCost");

		// Token: 0x04000FEC RID: 4076
		public static readonly int _VertexDensityMaxPixelCost = Shader.PropertyToID("_VertexDensityMaxPixelCost");

		// Token: 0x04000FED RID: 4077
		public static readonly int _MinMotionVector = Shader.PropertyToID("_MinMotionVector");

		// Token: 0x04000FEE RID: 4078
		public static readonly int _CustomDepthTexture = Shader.PropertyToID("_CustomDepthTexture");

		// Token: 0x04000FEF RID: 4079
		public static readonly int _CustomColorTexture = Shader.PropertyToID("_CustomColorTexture");

		// Token: 0x04000FF0 RID: 4080
		public static readonly int _CustomPassInjectionPoint = Shader.PropertyToID("_CustomPassInjectionPoint");

		// Token: 0x04000FF1 RID: 4081
		public static readonly int _AfterPostProcessColorBuffer = Shader.PropertyToID("_AfterPostProcessColorBuffer");

		// Token: 0x04000FF2 RID: 4082
		public static readonly int _CustomPostProcessInput = Shader.PropertyToID("_CustomPostProcessInput");

		// Token: 0x04000FF3 RID: 4083
		public static readonly int _SourceDownsampleDepth = Shader.PropertyToID("_SourceDownsampleDepth");

		// Token: 0x04000FF4 RID: 4084
		public static readonly int _InputCubemap = Shader.PropertyToID("_InputCubemap");

		// Token: 0x04000FF5 RID: 4085
		public static readonly int _Mipmap = Shader.PropertyToID("_Mipmap");

		// Token: 0x04000FF6 RID: 4086
		public static readonly int _ApplyExposure = Shader.PropertyToID("_ApplyExposure");

		// Token: 0x04000FF7 RID: 4087
		public static readonly int _ArrayIndex = Shader.PropertyToID("_ArrayIndex");

		// Token: 0x04000FF8 RID: 4088
		public static readonly int _DiffusionProfileHash = Shader.PropertyToID("_DiffusionProfileHash");

		// Token: 0x04000FF9 RID: 4089
		public static readonly int _DiffusionProfileAsset = Shader.PropertyToID("_DiffusionProfileAsset");

		// Token: 0x04000FFA RID: 4090
		public static readonly int _MaxRadius = Shader.PropertyToID("_MaxRadius");

		// Token: 0x04000FFB RID: 4091
		public static readonly int _ShapeParam = Shader.PropertyToID("_ShapeParam");

		// Token: 0x04000FFC RID: 4092
		public static readonly int _StdDev1 = Shader.PropertyToID("_StdDev1");

		// Token: 0x04000FFD RID: 4093
		public static readonly int _StdDev2 = Shader.PropertyToID("_StdDev2");

		// Token: 0x04000FFE RID: 4094
		public static readonly int _LerpWeight = Shader.PropertyToID("_LerpWeight");

		// Token: 0x04000FFF RID: 4095
		public static readonly int _HalfRcpVarianceAndWeight1 = Shader.PropertyToID("_HalfRcpVarianceAndWeight1");

		// Token: 0x04001000 RID: 4096
		public static readonly int _HalfRcpVarianceAndWeight2 = Shader.PropertyToID("_HalfRcpVarianceAndWeight2");

		// Token: 0x04001001 RID: 4097
		public static readonly int _TransmissionTint = Shader.PropertyToID("_TransmissionTint");

		// Token: 0x04001002 RID: 4098
		public static readonly int _ThicknessRemap = Shader.PropertyToID("_ThicknessRemap");

		// Token: 0x04001003 RID: 4099
		public static readonly int _Cubemap = Shader.PropertyToID("_Cubemap");

		// Token: 0x04001004 RID: 4100
		public static readonly int _InvOmegaP = Shader.PropertyToID("_InvOmegaP");

		// Token: 0x04001005 RID: 4101
		public static readonly int _DistortionParam = Shader.PropertyToID("_DistortionParam");

		// Token: 0x04001006 RID: 4102
		public static readonly int _SkyParam = Shader.PropertyToID("_SkyParam");

		// Token: 0x04001007 RID: 4103
		public static readonly int _BackplateParameters0 = Shader.PropertyToID("_BackplateParameters0");

		// Token: 0x04001008 RID: 4104
		public static readonly int _BackplateParameters1 = Shader.PropertyToID("_BackplateParameters1");

		// Token: 0x04001009 RID: 4105
		public static readonly int _BackplateParameters2 = Shader.PropertyToID("_BackplateParameters2");

		// Token: 0x0400100A RID: 4106
		public static readonly int _BackplateShadowTint = Shader.PropertyToID("_BackplateShadowTint");

		// Token: 0x0400100B RID: 4107
		public static readonly int _BackplateShadowFilter = Shader.PropertyToID("_BackplateShadowFilter");

		// Token: 0x0400100C RID: 4108
		public static readonly int _SkyIntensity = Shader.PropertyToID("_SkyIntensity");

		// Token: 0x0400100D RID: 4109
		public static readonly int _PixelCoordToViewDirWS = Shader.PropertyToID("_PixelCoordToViewDirWS");

		// Token: 0x0400100E RID: 4110
		public static readonly int _VolumetricCloudsSourceDepth = Shader.PropertyToID("_VolumetricCloudsSourceDepth");

		// Token: 0x0400100F RID: 4111
		public static readonly int _CloudsLightingTexture = Shader.PropertyToID("_CloudsLightingTexture");

		// Token: 0x04001010 RID: 4112
		public static readonly int _CloudsLightingTextureRW = Shader.PropertyToID("_CloudsLightingTextureRW");

		// Token: 0x04001011 RID: 4113
		public static readonly int _HalfResDepthBufferRW = Shader.PropertyToID("_HalfResDepthBufferRW");

		// Token: 0x04001012 RID: 4114
		public static readonly int _DepthBufferRW = Shader.PropertyToID("_DepthBufferRW");

		// Token: 0x04001013 RID: 4115
		public static readonly int _CloudsDepthTexture = Shader.PropertyToID("_CloudsDepthTexture");

		// Token: 0x04001014 RID: 4116
		public static readonly int _DepthStatusTexture = Shader.PropertyToID("_DepthStatusTexture");

		// Token: 0x04001015 RID: 4117
		public static readonly int _CloudsDepthTextureRW = Shader.PropertyToID("_CloudsDepthTextureRW");

		// Token: 0x04001016 RID: 4118
		public static readonly int _CloudsAdditionalTextureRW = Shader.PropertyToID("_CloudsAdditionalTextureRW");

		// Token: 0x04001017 RID: 4119
		public static readonly int _VolumetricCloudsTexture = Shader.PropertyToID("_VolumetricCloudsTexture");

		// Token: 0x04001018 RID: 4120
		public static readonly int _VolumetricCloudsTextureRW = Shader.PropertyToID("_VolumetricCloudsTextureRW");

		// Token: 0x04001019 RID: 4121
		public static readonly int _VolumetricCloudsShadow = Shader.PropertyToID("_VolumetricCloudsShadow");

		// Token: 0x0400101A RID: 4122
		public static readonly int _VolumetricCloudsShadowRW = Shader.PropertyToID("_VolumetricCloudsShadowRW");

		// Token: 0x0400101B RID: 4123
		public static readonly int _VolumetricCloudsUpscaleTextureRW = Shader.PropertyToID("_VolumetricCloudsUpscaleTextureRW");

		// Token: 0x0400101C RID: 4124
		public static readonly int _HistoryVolumetricClouds0Texture = Shader.PropertyToID("_HistoryVolumetricClouds0Texture");

		// Token: 0x0400101D RID: 4125
		public static readonly int _HistoryVolumetricClouds1Texture = Shader.PropertyToID("_HistoryVolumetricClouds1Texture");

		// Token: 0x0400101E RID: 4126
		public static readonly int _Worley128RGBA = Shader.PropertyToID("_Worley128RGBA");

		// Token: 0x0400101F RID: 4127
		public static readonly int _ErosionNoise = Shader.PropertyToID("_ErosionNoise");

		// Token: 0x04001020 RID: 4128
		public static readonly int _CloudMapTexture = Shader.PropertyToID("_CloudMapTexture");

		// Token: 0x04001021 RID: 4129
		public static readonly int _CloudMapTextureRW = Shader.PropertyToID("_CloudMapTextureRW");

		// Token: 0x04001022 RID: 4130
		public static readonly int _CloudLutTexture = Shader.PropertyToID("_CloudLutTexture");

		// Token: 0x04001023 RID: 4131
		public static readonly int _CumulusMap = Shader.PropertyToID("_CumulusMap");

		// Token: 0x04001024 RID: 4132
		public static readonly int _CumulusMapMultiplier = Shader.PropertyToID("_CumulusMapMultiplier");

		// Token: 0x04001025 RID: 4133
		public static readonly int _AltostratusMap = Shader.PropertyToID("_AltostratusMap");

		// Token: 0x04001026 RID: 4134
		public static readonly int _AltostratusMapMultiplier = Shader.PropertyToID("_AltostratusMapMultiplier");

		// Token: 0x04001027 RID: 4135
		public static readonly int _CumulonimbusMap = Shader.PropertyToID("_CumulonimbusMap");

		// Token: 0x04001028 RID: 4136
		public static readonly int _CumulonimbusMapMultiplier = Shader.PropertyToID("_CumulonimbusMapMultiplier");

		// Token: 0x04001029 RID: 4137
		public static readonly int _RainMap = Shader.PropertyToID("_RainMap");

		// Token: 0x0400102A RID: 4138
		public static readonly int _CloudMapResolution = Shader.PropertyToID("_CloudMapResolution");

		// Token: 0x0400102B RID: 4139
		public static readonly int _CloudsPixelCoordToViewDirWS = Shader.PropertyToID("_CloudsPixelCoordToViewDirWS");

		// Token: 0x0400102C RID: 4140
		public static readonly int _VolumetricCloudsAmbientProbeBuffer = Shader.PropertyToID("_VolumetricCloudsAmbientProbeBuffer");

		// Token: 0x0400102D RID: 4141
		public static readonly int _H0Buffer = Shader.PropertyToID("_H0Buffer");

		// Token: 0x0400102E RID: 4142
		public static readonly int _H0BufferRW = Shader.PropertyToID("_H0BufferRW");

		// Token: 0x0400102F RID: 4143
		public static readonly int _HtRealBufferRW = Shader.PropertyToID("_HtRealBufferRW");

		// Token: 0x04001030 RID: 4144
		public static readonly int _HtImaginaryBufferRW = Shader.PropertyToID("_HtImaginaryBufferRW");

		// Token: 0x04001031 RID: 4145
		public static readonly int _FFTRealBuffer = Shader.PropertyToID("_FFTRealBuffer");

		// Token: 0x04001032 RID: 4146
		public static readonly int _FFTImaginaryBuffer = Shader.PropertyToID("_FFTImaginaryBuffer");

		// Token: 0x04001033 RID: 4147
		public static readonly int _FFTRealBufferRW = Shader.PropertyToID("_FFTRealBufferRW");

		// Token: 0x04001034 RID: 4148
		public static readonly int _FFTImaginaryBufferRW = Shader.PropertyToID("_FFTImaginaryBufferRW");

		// Token: 0x04001035 RID: 4149
		public static readonly int _WaterDisplacementBuffer = Shader.PropertyToID("_WaterDisplacementBuffer");

		// Token: 0x04001036 RID: 4150
		public static readonly int _WaterAdditionalDataBuffer = Shader.PropertyToID("_WaterAdditionalDataBuffer");

		// Token: 0x04001037 RID: 4151
		public static readonly int _WaterAdditionalDataBufferRW = Shader.PropertyToID("_WaterAdditionalDataBufferRW");

		// Token: 0x04001038 RID: 4152
		public static readonly int _PreviousWaterAdditionalDataBuffer = Shader.PropertyToID("_PreviousWaterAdditionalDataBuffer");

		// Token: 0x04001039 RID: 4153
		public static readonly int _WaterMask = Shader.PropertyToID("_WaterMask");

		// Token: 0x0400103A RID: 4154
		public static readonly int _FoamMask = Shader.PropertyToID("_FoamMask");

		// Token: 0x0400103B RID: 4155
		public static readonly int _FoamTexture = Shader.PropertyToID("_FoamTexture");

		// Token: 0x0400103C RID: 4156
		public static readonly int _WaterGBufferTexture0 = Shader.PropertyToID("_WaterGBufferTexture0");

		// Token: 0x0400103D RID: 4157
		public static readonly int _WaterGBufferTexture1 = Shader.PropertyToID("_WaterGBufferTexture1");

		// Token: 0x0400103E RID: 4158
		public static readonly int _WaterGBufferTexture2 = Shader.PropertyToID("_WaterGBufferTexture2");

		// Token: 0x0400103F RID: 4159
		public static readonly int _WaterGBufferTexture3 = Shader.PropertyToID("_WaterGBufferTexture3");

		// Token: 0x04001040 RID: 4160
		public static readonly int _WaterSurfaceProfiles = Shader.PropertyToID("_WaterSurfaceProfiles");

		// Token: 0x04001041 RID: 4161
		public static readonly int _WaterGBufferTexture0RW = Shader.PropertyToID("_WaterGBufferTexture0RW");

		// Token: 0x04001042 RID: 4162
		public static readonly int _WaterInitialFrame = Shader.PropertyToID("_WaterInitialFrame");

		// Token: 0x04001043 RID: 4163
		public static readonly int _WaterPatchData = Shader.PropertyToID("_WaterPatchData");

		// Token: 0x04001044 RID: 4164
		public static readonly int _WaterPatchDataRW = Shader.PropertyToID("_WaterPatchDataRW");

		// Token: 0x04001045 RID: 4165
		public static readonly int _WaterInstanceDataRW = Shader.PropertyToID("_WaterInstanceDataRW");

		// Token: 0x04001046 RID: 4166
		public static readonly int _FrustumGPUBuffer = Shader.PropertyToID("_FrustumGPUBuffer");

		// Token: 0x04001047 RID: 4167
		public static readonly int _WaterCameraHeightBuffer = Shader.PropertyToID("_WaterCameraHeightBuffer");

		// Token: 0x04001048 RID: 4168
		public static readonly int _WaterCameraHeightBufferRW = Shader.PropertyToID("_WaterCameraHeightBufferRW");

		// Token: 0x04001049 RID: 4169
		public static readonly int _WaterCausticsDataBuffer = Shader.PropertyToID("_WaterCausticsDataBuffer");

		// Token: 0x0400104A RID: 4170
		public static readonly int _CausticsNormalsMipOffset = Shader.PropertyToID("_CausticsNormalsMipOffset");

		// Token: 0x0400104B RID: 4171
		public static readonly int _CausticGeometryResolution = Shader.PropertyToID("_CausticGeometryResolution");

		// Token: 0x0400104C RID: 4172
		public static readonly int _CausticsVirtualPlane = Shader.PropertyToID("_CausticsVirtualPlane");

		// Token: 0x0400104D RID: 4173
		public static readonly int _CausticsBandIndex = Shader.PropertyToID("_CausticsBandIndex");

		// Token: 0x0400104E RID: 4174
		public static readonly int _Flowmap = Shader.PropertyToID("_Flowmap");

		// Token: 0x0400104F RID: 4175
		public static readonly int _FlowmapParam = Shader.PropertyToID("_FlowmapParam");

		// Token: 0x04001050 RID: 4176
		public static readonly int _SunDirection = Shader.PropertyToID("_SunDirection");

		// Token: 0x04001051 RID: 4177
		public static readonly int _Resolution = Shader.PropertyToID("_Resolution");

		// Token: 0x04001052 RID: 4178
		public static readonly int _Size = Shader.PropertyToID("_Size");

		// Token: 0x04001053 RID: 4179
		public static readonly int _Source = Shader.PropertyToID("_Source");

		// Token: 0x04001054 RID: 4180
		public static readonly int _Destination = Shader.PropertyToID("_Destination");

		// Token: 0x04001055 RID: 4181
		public static readonly int _Mip0 = Shader.PropertyToID("_Mip0");

		// Token: 0x04001056 RID: 4182
		public static readonly int _SourceMip = Shader.PropertyToID("_SourceMip");

		// Token: 0x04001057 RID: 4183
		public static readonly int _SrcOffsetAndLimit = Shader.PropertyToID("_SrcOffsetAndLimit");

		// Token: 0x04001058 RID: 4184
		public static readonly int _SrcScaleBias = Shader.PropertyToID("_SrcScaleBias");

		// Token: 0x04001059 RID: 4185
		public static readonly int _SrcUvLimits = Shader.PropertyToID("_SrcUvLimits");

		// Token: 0x0400105A RID: 4186
		public static readonly int _DstOffset = Shader.PropertyToID("_DstOffset");

		// Token: 0x0400105B RID: 4187
		public static readonly int _DepthMipChain = Shader.PropertyToID("_DepthMipChain");

		// Token: 0x0400105C RID: 4188
		public static readonly int _VBufferDensity = Shader.PropertyToID("_VBufferDensity");

		// Token: 0x0400105D RID: 4189
		public static readonly int _VBufferLighting = Shader.PropertyToID("_VBufferLighting");

		// Token: 0x0400105E RID: 4190
		public static readonly int _VBufferLightingFiltered = Shader.PropertyToID("_VBufferLightingFiltered");

		// Token: 0x0400105F RID: 4191
		public static readonly int _VBufferHistory = Shader.PropertyToID("_VBufferHistory");

		// Token: 0x04001060 RID: 4192
		public static readonly int _VBufferFeedback = Shader.PropertyToID("_VBufferFeedback");

		// Token: 0x04001061 RID: 4193
		public static readonly int _VolumeBounds = Shader.PropertyToID("_VolumeBounds");

		// Token: 0x04001062 RID: 4194
		public static readonly int _VolumeData = Shader.PropertyToID("_VolumeData");

		// Token: 0x04001063 RID: 4195
		public static readonly int _VolumeAmbientProbeBuffer = Shader.PropertyToID("_VolumetricAmbientProbeBuffer");

		// Token: 0x04001064 RID: 4196
		public static readonly int _MaxZMaskTexture = Shader.PropertyToID("_MaxZMaskTexture");

		// Token: 0x04001065 RID: 4197
		public static readonly int _DilationWidth = Shader.PropertyToID("_DilationWidth");

		// Token: 0x04001066 RID: 4198
		public static readonly int _MultiScatteringLUT_RW = Shader.PropertyToID("_MultiScatteringLUT_RW");

		// Token: 0x04001067 RID: 4199
		public static readonly int _MultiScatteringLUT = Shader.PropertyToID("_MultiScatteringLUT");

		// Token: 0x04001068 RID: 4200
		public static readonly int _GroundIrradianceTexture = Shader.PropertyToID("_GroundIrradianceTexture");

		// Token: 0x04001069 RID: 4201
		public static readonly int _GroundIrradianceTable = Shader.PropertyToID("_GroundIrradianceTable");

		// Token: 0x0400106A RID: 4202
		public static readonly int _GroundIrradianceTableOrder = Shader.PropertyToID("_GroundIrradianceTableOrder");

		// Token: 0x0400106B RID: 4203
		public static readonly int _AirSingleScatteringTexture = Shader.PropertyToID("_AirSingleScatteringTexture");

		// Token: 0x0400106C RID: 4204
		public static readonly int _AirSingleScatteringTable = Shader.PropertyToID("_AirSingleScatteringTable");

		// Token: 0x0400106D RID: 4205
		public static readonly int _AerosolSingleScatteringTexture = Shader.PropertyToID("_AerosolSingleScatteringTexture");

		// Token: 0x0400106E RID: 4206
		public static readonly int _AerosolSingleScatteringTable = Shader.PropertyToID("_AerosolSingleScatteringTable");

		// Token: 0x0400106F RID: 4207
		public static readonly int _MultipleScatteringTexture = Shader.PropertyToID("_MultipleScatteringTexture");

		// Token: 0x04001070 RID: 4208
		public static readonly int _MultipleScatteringTable = Shader.PropertyToID("_MultipleScatteringTable");

		// Token: 0x04001071 RID: 4209
		public static readonly int _PlanetaryRadius = Shader.PropertyToID("_PlanetaryRadius");

		// Token: 0x04001072 RID: 4210
		public static readonly int _RcpPlanetaryRadius = Shader.PropertyToID("_RcpPlanetaryRadius");

		// Token: 0x04001073 RID: 4211
		public static readonly int _AtmosphericDepth = Shader.PropertyToID("_AtmosphericDepth");

		// Token: 0x04001074 RID: 4212
		public static readonly int _RcpAtmosphericDepth = Shader.PropertyToID("_RcpAtmosphericDepth");

		// Token: 0x04001075 RID: 4213
		public static readonly int _AtmosphericRadius = Shader.PropertyToID("_AtmosphericRadius");

		// Token: 0x04001076 RID: 4214
		public static readonly int _AerosolAnisotropy = Shader.PropertyToID("_AerosolAnisotropy");

		// Token: 0x04001077 RID: 4215
		public static readonly int _AerosolPhasePartConstant = Shader.PropertyToID("_AerosolPhasePartConstant");

		// Token: 0x04001078 RID: 4216
		public static readonly int _AirDensityFalloff = Shader.PropertyToID("_AirDensityFalloff");

		// Token: 0x04001079 RID: 4217
		public static readonly int _AirScaleHeight = Shader.PropertyToID("_AirScaleHeight");

		// Token: 0x0400107A RID: 4218
		public static readonly int _AerosolDensityFalloff = Shader.PropertyToID("_AerosolDensityFalloff");

		// Token: 0x0400107B RID: 4219
		public static readonly int _AerosolScaleHeight = Shader.PropertyToID("_AerosolScaleHeight");

		// Token: 0x0400107C RID: 4220
		public static readonly int _AirSeaLevelExtinction = Shader.PropertyToID("_AirSeaLevelExtinction");

		// Token: 0x0400107D RID: 4221
		public static readonly int _AerosolSeaLevelExtinction = Shader.PropertyToID("_AerosolSeaLevelExtinction");

		// Token: 0x0400107E RID: 4222
		public static readonly int _AirSeaLevelScattering = Shader.PropertyToID("_AirSeaLevelScattering");

		// Token: 0x0400107F RID: 4223
		public static readonly int _AerosolSeaLevelScattering = Shader.PropertyToID("_AerosolSeaLevelScattering");

		// Token: 0x04001080 RID: 4224
		public static readonly int _GroundAlbedo = Shader.PropertyToID("_GroundAlbedo");

		// Token: 0x04001081 RID: 4225
		public static readonly int _IntensityMultiplier = Shader.PropertyToID("_IntensityMultiplier");

		// Token: 0x04001082 RID: 4226
		public static readonly int _PlanetCenterPosition = Shader.PropertyToID("_PlanetCenterPosition");

		// Token: 0x04001083 RID: 4227
		public static readonly int _PlanetRotation = Shader.PropertyToID("_PlanetRotation");

		// Token: 0x04001084 RID: 4228
		public static readonly int _SpaceRotation = Shader.PropertyToID("_SpaceRotation");

		// Token: 0x04001085 RID: 4229
		public static readonly int _HasGroundAlbedoTexture = Shader.PropertyToID("_HasGroundAlbedoTexture");

		// Token: 0x04001086 RID: 4230
		public static readonly int _GroundAlbedoTexture = Shader.PropertyToID("_GroundAlbedoTexture");

		// Token: 0x04001087 RID: 4231
		public static readonly int _HasGroundEmissionTexture = Shader.PropertyToID("_HasGroundEmissionTexture");

		// Token: 0x04001088 RID: 4232
		public static readonly int _GroundEmissionTexture = Shader.PropertyToID("_GroundEmissionTexture");

		// Token: 0x04001089 RID: 4233
		public static readonly int _GroundEmissionMultiplier = Shader.PropertyToID("_GroundEmissionMultiplier");

		// Token: 0x0400108A RID: 4234
		public static readonly int _HasSpaceEmissionTexture = Shader.PropertyToID("_HasSpaceEmissionTexture");

		// Token: 0x0400108B RID: 4235
		public static readonly int _SpaceEmissionTexture = Shader.PropertyToID("_SpaceEmissionTexture");

		// Token: 0x0400108C RID: 4236
		public static readonly int _SpaceEmissionMultiplier = Shader.PropertyToID("_SpaceEmissionMultiplier");

		// Token: 0x0400108D RID: 4237
		public static readonly int _RenderSunDisk = Shader.PropertyToID("_RenderSunDisk");

		// Token: 0x0400108E RID: 4238
		public static readonly int _ColorSaturation = Shader.PropertyToID("_ColorSaturation");

		// Token: 0x0400108F RID: 4239
		public static readonly int _AlphaSaturation = Shader.PropertyToID("_AlphaSaturation");

		// Token: 0x04001090 RID: 4240
		public static readonly int _AlphaMultiplier = Shader.PropertyToID("_AlphaMultiplier");

		// Token: 0x04001091 RID: 4241
		public static readonly int _HorizonTint = Shader.PropertyToID("_HorizonTint");

		// Token: 0x04001092 RID: 4242
		public static readonly int _ZenithTint = Shader.PropertyToID("_ZenithTint");

		// Token: 0x04001093 RID: 4243
		public static readonly int _HorizonZenithShiftPower = Shader.PropertyToID("_HorizonZenithShiftPower");

		// Token: 0x04001094 RID: 4244
		public static readonly int _HorizonZenithShiftScale = Shader.PropertyToID("_HorizonZenithShiftScale");

		// Token: 0x04001095 RID: 4245
		public static readonly int _RayTracingLayerMask = Shader.PropertyToID("_RayTracingLayerMask");

		// Token: 0x04001096 RID: 4246
		public static readonly int _PixelSpreadAngleTangent = Shader.PropertyToID("_PixelSpreadAngleTangent");

		// Token: 0x04001097 RID: 4247
		public static readonly string _RaytracingAccelerationStructureName = "_RaytracingAccelerationStructure";

		// Token: 0x04001098 RID: 4248
		public static readonly int _InvViewportScaleBias = Shader.PropertyToID("_InvViewportScaleBias");

		// Token: 0x04001099 RID: 4249
		public static readonly int _PathTracingDoFParameters = Shader.PropertyToID("_PathTracingDoFParameters");

		// Token: 0x0400109A RID: 4250
		public static readonly int _PathTracingTilingParameters = Shader.PropertyToID("_PathTracingTilingParameters");

		// Token: 0x0400109B RID: 4251
		public static readonly int _PathTracingCameraSkyEnabled = Shader.PropertyToID("_PathTracingCameraSkyEnabled");

		// Token: 0x0400109C RID: 4252
		public static readonly int _PathTracingCameraClearColor = Shader.PropertyToID("_PathTracingCameraClearColor");

		// Token: 0x0400109D RID: 4253
		public static readonly int _PathTracingSkyTextureWidth = Shader.PropertyToID("_PathTracingSkyTextureWidth");

		// Token: 0x0400109E RID: 4254
		public static readonly int _PathTracingSkyTextureHeight = Shader.PropertyToID("_PathTracingSkyTextureHeight");

		// Token: 0x0400109F RID: 4255
		public static readonly int _PathTracingSkyCDFTexture = Shader.PropertyToID("_PathTracingSkyCDFTexture");

		// Token: 0x040010A0 RID: 4256
		public static readonly int _PathTracingSkyMarginalTexture = Shader.PropertyToID("_PathTracingSkyMarginalTexture");

		// Token: 0x040010A1 RID: 4257
		public static readonly int _AlbedoAOV = Shader.PropertyToID("_AlbedoAOV");

		// Token: 0x040010A2 RID: 4258
		public static readonly int _NormalAOV = Shader.PropertyToID("_NormalAOV");

		// Token: 0x040010A3 RID: 4259
		public static readonly int _MotionVectorAOV = Shader.PropertyToID("_MotionVectorAOV");

		// Token: 0x040010A4 RID: 4260
		public static readonly int _LightDatasRT = Shader.PropertyToID("_LightDatasRT");

		// Token: 0x040010A5 RID: 4261
		public static readonly int _EnvLightDatasRT = Shader.PropertyToID("_EnvLightDatasRT");

		// Token: 0x040010A6 RID: 4262
		public static readonly int _RaytracingLightCluster = Shader.PropertyToID("_RaytracingLightCluster");

		// Token: 0x040010A7 RID: 4263
		public static readonly int _RaytracingLightClusterRW = Shader.PropertyToID("_RaytracingLightClusterRW");

		// Token: 0x040010A8 RID: 4264
		public static readonly int _EnableExposureControl = Shader.PropertyToID("_EnableExposureControl");

		// Token: 0x040010A9 RID: 4265
		public static readonly int _HistorySizeAndScale = Shader.PropertyToID("_HistorySizeAndScale");

		// Token: 0x040010AA RID: 4266
		public static readonly int _HistoryBuffer = Shader.PropertyToID("_HistoryBuffer");

		// Token: 0x040010AB RID: 4267
		public static readonly int _HistoryBuffer0 = Shader.PropertyToID("_HistoryBuffer0");

		// Token: 0x040010AC RID: 4268
		public static readonly int _HistoryBuffer1 = Shader.PropertyToID("_HistoryBuffer1");

		// Token: 0x040010AD RID: 4269
		public static readonly int _ValidationBuffer = Shader.PropertyToID("_ValidationBuffer");

		// Token: 0x040010AE RID: 4270
		public static readonly int _ValidationBufferRW = Shader.PropertyToID("_ValidationBufferRW");

		// Token: 0x040010AF RID: 4271
		public static readonly int _HistoryDepthTexture = Shader.PropertyToID("_HistoryDepthTexture");

		// Token: 0x040010B0 RID: 4272
		public static readonly int _HistoryNormalTexture = Shader.PropertyToID("_HistoryNormalTexture");

		// Token: 0x040010B1 RID: 4273
		public static readonly int _RaytracingDenoiseRadius = Shader.PropertyToID("_RaytracingDenoiseRadius");

		// Token: 0x040010B2 RID: 4274
		public static readonly int _DenoiserFilterRadius = Shader.PropertyToID("_DenoiserFilterRadius");

		// Token: 0x040010B3 RID: 4275
		public static readonly int _NormalHistoryCriterion = Shader.PropertyToID("_NormalHistoryCriterion");

		// Token: 0x040010B4 RID: 4276
		public static readonly int _DenoiseInputTexture = Shader.PropertyToID("_DenoiseInputTexture");

		// Token: 0x040010B5 RID: 4277
		public static readonly int _DenoiseOutputTextureRW = Shader.PropertyToID("_DenoiseOutputTextureRW");

		// Token: 0x040010B6 RID: 4278
		public static readonly int _DenoiseOutputArrayTextureRW = Shader.PropertyToID("_DenoiseOutputArrayTextureRW");

		// Token: 0x040010B7 RID: 4279
		public static readonly int _AccumulationOutputTextureRW = Shader.PropertyToID("_AccumulationOutputTextureRW");

		// Token: 0x040010B8 RID: 4280
		public static readonly int _HalfResolutionFilter = Shader.PropertyToID("_HalfResolutionFilter");

		// Token: 0x040010B9 RID: 4281
		public static readonly int _DenoisingHistorySlot = Shader.PropertyToID("_DenoisingHistorySlot");

		// Token: 0x040010BA RID: 4282
		public static readonly int _HistoryValidity = Shader.PropertyToID("_HistoryValidity");

		// Token: 0x040010BB RID: 4283
		public static readonly int _ReceiverMotionRejection = Shader.PropertyToID("_ReceiverMotionRejection");

		// Token: 0x040010BC RID: 4284
		public static readonly int _OccluderMotionRejection = Shader.PropertyToID("_OccluderMotionRejection");

		// Token: 0x040010BD RID: 4285
		public static readonly int _ReflectionFilterMapping = Shader.PropertyToID("_ReflectionFilterMapping");

		// Token: 0x040010BE RID: 4286
		public static readonly int _DenoisingHistorySlice = Shader.PropertyToID("_DenoisingHistorySlice");

		// Token: 0x040010BF RID: 4287
		public static readonly int _DenoisingHistoryMask = Shader.PropertyToID("_DenoisingHistoryMask");

		// Token: 0x040010C0 RID: 4288
		public static readonly int _DenoisingHistoryMaskSn = Shader.PropertyToID("_DenoisingHistoryMaskSn");

		// Token: 0x040010C1 RID: 4289
		public static readonly int _DenoisingHistoryMaskUn = Shader.PropertyToID("_DenoisingHistoryMaskUn");

		// Token: 0x040010C2 RID: 4290
		public static readonly int _HistoryValidityBuffer = Shader.PropertyToID("_HistoryValidityBuffer");

		// Token: 0x040010C3 RID: 4291
		public static readonly int _ValidityOutputTextureRW = Shader.PropertyToID("_ValidityOutputTextureRW");

		// Token: 0x040010C4 RID: 4292
		public static readonly int _VelocityBuffer = Shader.PropertyToID("_VelocityBuffer");

		// Token: 0x040010C5 RID: 4293
		public static readonly int _ShadowFilterMapping = Shader.PropertyToID("_ShadowFilterMapping");

		// Token: 0x040010C6 RID: 4294
		public static readonly int _DistanceTexture = Shader.PropertyToID("_DistanceTexture");

		// Token: 0x040010C7 RID: 4295
		public static readonly int _JitterFramePeriod = Shader.PropertyToID("_JitterFramePeriod");

		// Token: 0x040010C8 RID: 4296
		public static readonly int _SingleReflectionBounce = Shader.PropertyToID("_SingleReflectionBounce");

		// Token: 0x040010C9 RID: 4297
		public static readonly int _RoughnessBasedDenoising = Shader.PropertyToID("_RoughnessBasedDenoising");

		// Token: 0x040010CA RID: 4298
		public static readonly int _HistoryBufferSize = Shader.PropertyToID("_HistoryBufferSize");

		// Token: 0x040010CB RID: 4299
		public static readonly int _CurrentEffectResolution = Shader.PropertyToID("_CurrentEffectResolution");

		// Token: 0x040010CC RID: 4300
		public static readonly int _SampleCountTextureRW = Shader.PropertyToID("_SampleCountTextureRW");

		// Token: 0x040010CD RID: 4301
		public static readonly int _AffectSmoothSurfaces = Shader.PropertyToID("_AffectSmoothSurfaces");

		// Token: 0x040010CE RID: 4302
		public static readonly int _ObjectMotionStencilBit = Shader.PropertyToID("_ObjectMotionStencilBit");

		// Token: 0x040010CF RID: 4303
		public static readonly int _PointDistribution = Shader.PropertyToID("_PointDistribution");

		// Token: 0x040010D0 RID: 4304
		public static readonly int _DenoiserResolutionMultiplierVals = Shader.PropertyToID("_DenoiserResolutionMultiplierVals");

		// Token: 0x040010D1 RID: 4305
		public static readonly int _DenoiseInputArrayTexture = Shader.PropertyToID("_DenoiseInputArrayTexture");

		// Token: 0x040010D2 RID: 4306
		public static readonly int _ValidityInputArrayTexture = Shader.PropertyToID("_ValidityInputArrayTexture");

		// Token: 0x040010D3 RID: 4307
		public static readonly int _IntermediateDenoiseOutputTexture = Shader.PropertyToID("_IntermediateDenoiseOutputTexture");

		// Token: 0x040010D4 RID: 4308
		public static readonly int _IntermediateValidityOutputTexture = Shader.PropertyToID("_IntermediateValidityOutputTexture");

		// Token: 0x040010D5 RID: 4309
		public static readonly int _IntermediateDenoiseOutputTextureRW = Shader.PropertyToID("_IntermediateDenoiseOutputTextureRW");

		// Token: 0x040010D6 RID: 4310
		public static readonly int _IntermediateValidityOutputTextureRW = Shader.PropertyToID("_IntermediateValidityOutputTextureRW");

		// Token: 0x040010D7 RID: 4311
		public static readonly int _ReflectionHistorybufferRW = Shader.PropertyToID("_ReflectionHistorybufferRW");

		// Token: 0x040010D8 RID: 4312
		public static readonly int _CurrentFrameTexture = Shader.PropertyToID("_CurrentFrameTexture");

		// Token: 0x040010D9 RID: 4313
		public static readonly int _AccumulatedFrameTexture = Shader.PropertyToID("_AccumulatedFrameTexture");

		// Token: 0x040010DA RID: 4314
		public static readonly int _TemporalAccumuationWeight = Shader.PropertyToID("_TemporalAccumuationWeight");

		// Token: 0x040010DB RID: 4315
		public static readonly int _SpatialFilterRadius = Shader.PropertyToID("_SpatialFilterRadius");

		// Token: 0x040010DC RID: 4316
		public static readonly int _RaytracingHitDistanceTexture = Shader.PropertyToID("_RaytracingHitDistanceTexture");

		// Token: 0x040010DD RID: 4317
		public static readonly int _RaytracingVSNormalTexture = Shader.PropertyToID("_RaytracingVSNormalTexture");

		// Token: 0x040010DE RID: 4318
		public static readonly int _RaytracingReflectionTexture = Shader.PropertyToID("_RaytracingReflectionTexture");

		// Token: 0x040010DF RID: 4319
		public static readonly int _RaytracingTargetLight = Shader.PropertyToID("_RaytracingTargetLight");

		// Token: 0x040010E0 RID: 4320
		public static readonly int _RaytracingShadowSlot = Shader.PropertyToID("_RaytracingShadowSlot");

		// Token: 0x040010E1 RID: 4321
		public static readonly int _RaytracingChannelMask = Shader.PropertyToID("_RaytracingChannelMask");

		// Token: 0x040010E2 RID: 4322
		public static readonly int _RaytracingChannelMask0 = Shader.PropertyToID("_RaytracingChannelMask0");

		// Token: 0x040010E3 RID: 4323
		public static readonly int _RaytracingChannelMask1 = Shader.PropertyToID("_RaytracingChannelMask1");

		// Token: 0x040010E4 RID: 4324
		public static readonly int _RaytracingAreaWorldToLocal = Shader.PropertyToID("_RaytracingAreaWorldToLocal");

		// Token: 0x040010E5 RID: 4325
		public static readonly int _RaytracedAreaShadowSample = Shader.PropertyToID("_RaytracedAreaShadowSample");

		// Token: 0x040010E6 RID: 4326
		public static readonly int _RaytracedAreaShadowIntegration = Shader.PropertyToID("_RaytracedAreaShadowIntegration");

		// Token: 0x040010E7 RID: 4327
		public static readonly int _RaytracingDirectionBuffer = Shader.PropertyToID("_RaytracingDirectionBuffer");

		// Token: 0x040010E8 RID: 4328
		public static readonly int _RayTracingLengthBuffer = Shader.PropertyToID("_RayTracingLengthBuffer");

		// Token: 0x040010E9 RID: 4329
		public static readonly int _RaytracingDistanceBufferRW = Shader.PropertyToID("_RaytracingDistanceBufferRW");

		// Token: 0x040010EA RID: 4330
		public static readonly int _RaytracingDistanceBuffer = Shader.PropertyToID("_RaytracingDistanceBuffer");

		// Token: 0x040010EB RID: 4331
		public static readonly int _AreaShadowTexture = Shader.PropertyToID("_AreaShadowTexture");

		// Token: 0x040010EC RID: 4332
		public static readonly int _AreaShadowTextureRW = Shader.PropertyToID("_AreaShadowTextureRW");

		// Token: 0x040010ED RID: 4333
		public static readonly int _ScreenSpaceShadowsTextureRW = Shader.PropertyToID("_ScreenSpaceShadowsTextureRW");

		// Token: 0x040010EE RID: 4334
		public static readonly int _AreaShadowHistory = Shader.PropertyToID("_AreaShadowHistory");

		// Token: 0x040010EF RID: 4335
		public static readonly int _AreaShadowHistoryRW = Shader.PropertyToID("_AreaShadowHistoryRW");

		// Token: 0x040010F0 RID: 4336
		public static readonly int _AnalyticProbBuffer = Shader.PropertyToID("_AnalyticProbBuffer");

		// Token: 0x040010F1 RID: 4337
		public static readonly int _AnalyticHistoryBuffer = Shader.PropertyToID("_AnalyticHistoryBuffer");

		// Token: 0x040010F2 RID: 4338
		public static readonly int _AnalyticHistoryBufferRW = Shader.PropertyToID("_AnalyticHistoryBufferRW");

		// Token: 0x040010F3 RID: 4339
		public static readonly int _RaytracingLightRadius = Shader.PropertyToID("_RaytracingLightRadius");

		// Token: 0x040010F4 RID: 4340
		public static readonly int _RaytracingLightAngle = Shader.PropertyToID("_RaytracingLightAngle");

		// Token: 0x040010F5 RID: 4341
		public static readonly int _RaytracedShadowIntegration = Shader.PropertyToID("_RaytracedShadowIntegration");

		// Token: 0x040010F6 RID: 4342
		public static readonly int _RaytracedColorShadowIntegration = Shader.PropertyToID("_RaytracedColorShadowIntegration");

		// Token: 0x040010F7 RID: 4343
		public static readonly int _DirectionalMaxRayLength = Shader.PropertyToID("_DirectionalMaxRayLength");

		// Token: 0x040010F8 RID: 4344
		public static readonly int _DirectionalLightDirection = Shader.PropertyToID("_DirectionalLightDirection");

		// Token: 0x040010F9 RID: 4345
		public static readonly int _SphereLightPosition = Shader.PropertyToID("_SphereLightPosition");

		// Token: 0x040010FA RID: 4346
		public static readonly int _SphereLightRadius = Shader.PropertyToID("_SphereLightRadius");

		// Token: 0x040010FB RID: 4347
		public static readonly int _CameraFOV = Shader.PropertyToID("_CameraFOV");

		// Token: 0x040010FC RID: 4348
		public static readonly int _RaytracingAOIntensity = Shader.PropertyToID("_RaytracingAOIntensity");

		// Token: 0x040010FD RID: 4349
		public static readonly int _RayCountTexture = Shader.PropertyToID("_RayCountTexture");

		// Token: 0x040010FE RID: 4350
		public static readonly int _RayCountType = Shader.PropertyToID("_RayCountType");

		// Token: 0x040010FF RID: 4351
		public static readonly int _InputRayCountTexture = Shader.PropertyToID("_InputRayCountTexture");

		// Token: 0x04001100 RID: 4352
		public static readonly int _InputRayCountBuffer = Shader.PropertyToID("_InputRayCountBuffer");

		// Token: 0x04001101 RID: 4353
		public static readonly int _OutputRayCountBuffer = Shader.PropertyToID("_OutputRayCountBuffer");

		// Token: 0x04001102 RID: 4354
		public static readonly int _InputBufferDimension = Shader.PropertyToID("_InputBufferDimension");

		// Token: 0x04001103 RID: 4355
		public static readonly int _OutputBufferDimension = Shader.PropertyToID("_OutputBufferDimension");

		// Token: 0x04001104 RID: 4356
		public static readonly int _RaytracingFlagMask = Shader.PropertyToID("_RaytracingFlagMask");

		// Token: 0x04001105 RID: 4357
		public static readonly int _RaytracingPrimaryDebug = Shader.PropertyToID("_RaytracingPrimaryDebug");

		// Token: 0x04001106 RID: 4358
		public static readonly int _IndirectDiffuseTexture = Shader.PropertyToID("_IndirectDiffuseTexture");

		// Token: 0x04001107 RID: 4359
		public static readonly int _IndirectDiffuseTextureRW = Shader.PropertyToID("_IndirectDiffuseTextureRW");

		// Token: 0x04001108 RID: 4360
		public static readonly int _IndirectDiffuseTexture0RW = Shader.PropertyToID("_IndirectDiffuseTexture0RW");

		// Token: 0x04001109 RID: 4361
		public static readonly int _IndirectDiffuseTexture1RW = Shader.PropertyToID("_IndirectDiffuseTexture1RW");

		// Token: 0x0400110A RID: 4362
		public static readonly int _IndirectDiffuseTexture0 = Shader.PropertyToID("_IndirectDiffuseTexture0");

		// Token: 0x0400110B RID: 4363
		public static readonly int _IndirectDiffuseTexture1 = Shader.PropertyToID("_IndirectDiffuseTexture1");

		// Token: 0x0400110C RID: 4364
		public static readonly int _UpscaledIndirectDiffuseTextureRW = Shader.PropertyToID("_UpscaledIndirectDiffuseTextureRW");

		// Token: 0x0400110D RID: 4365
		public static readonly int _IndirectDiffuseHitPointTexture = Shader.PropertyToID("_IndirectDiffuseHitPointTexture");

		// Token: 0x0400110E RID: 4366
		public static readonly int _IndirectDiffuseHitPointTextureRW = Shader.PropertyToID("_IndirectDiffuseHitPointTextureRW");

		// Token: 0x0400110F RID: 4367
		public static readonly int _IndirectDiffuseFrameIndex = Shader.PropertyToID("_IndirectDiffuseFrameIndex");

		// Token: 0x04001110 RID: 4368
		public static readonly int _InputNoisyBuffer = Shader.PropertyToID("_InputNoisyBuffer");

		// Token: 0x04001111 RID: 4369
		public static readonly int _InputNoisyBuffer0 = Shader.PropertyToID("_InputNoisyBuffer0");

		// Token: 0x04001112 RID: 4370
		public static readonly int _InputNoisyBuffer1 = Shader.PropertyToID("_InputNoisyBuffer1");

		// Token: 0x04001113 RID: 4371
		public static readonly int _OutputFilteredBuffer = Shader.PropertyToID("_OutputFilteredBuffer");

		// Token: 0x04001114 RID: 4372
		public static readonly int _OutputFilteredBuffer0 = Shader.PropertyToID("_OutputFilteredBuffer0");

		// Token: 0x04001115 RID: 4373
		public static readonly int _OutputFilteredBuffer1 = Shader.PropertyToID("_OutputFilteredBuffer1");

		// Token: 0x04001116 RID: 4374
		public static readonly int _LowResolutionTexture = Shader.PropertyToID("_LowResolutionTexture");

		// Token: 0x04001117 RID: 4375
		public static readonly int _OutputUpscaledTexture = Shader.PropertyToID("_OutputUpscaledTexture");

		// Token: 0x04001118 RID: 4376
		public static readonly int _IndirectDiffuseSpatialFilter = Shader.PropertyToID("_IndirectDiffuseSpatialFilter");

		// Token: 0x04001119 RID: 4377
		public static readonly int _SpatialFilterDirection = Shader.PropertyToID("_SpatialFilterDirection");

		// Token: 0x0400111A RID: 4378
		public static readonly int _RaytracingLitBufferRW = Shader.PropertyToID("_RaytracingLitBufferRW");

		// Token: 0x0400111B RID: 4379
		public static readonly int _RayTracingDiffuseLightingOnly = Shader.PropertyToID("_RayTracingDiffuseLightingOnly");

		// Token: 0x0400111C RID: 4380
		public static readonly int _RaytracingHalfResolution = Shader.PropertyToID("_RaytracingHalfResolution");

		// Token: 0x0400111D RID: 4381
		public static readonly int _RayMarchingThicknessScale = Shader.PropertyToID("_RayMarchingThicknessScale");

		// Token: 0x0400111E RID: 4382
		public static readonly int _RayMarchingThicknessBias = Shader.PropertyToID("_RayMarchingThicknessBias");

		// Token: 0x0400111F RID: 4383
		public static readonly int _RayMarchingSteps = Shader.PropertyToID("_RayMarchingSteps");

		// Token: 0x04001120 RID: 4384
		public static readonly int _RayMarchingReflectSky = Shader.PropertyToID("_RayMarchingReflectSky");

		// Token: 0x04001121 RID: 4385
		public static readonly int _RayMarchingFallbackHierarchy = Shader.PropertyToID("_RayMarchingFallbackHierarchy");

		// Token: 0x04001122 RID: 4386
		public static readonly int _RayMarchingLowResPercentageInv = Shader.PropertyToID("_RayMarchingLowResPercentageInv");

		// Token: 0x04001123 RID: 4387
		public static readonly int _RayMarchingLowResPercentage = Shader.PropertyToID("_RayMarchingLowResPercentage");

		// Token: 0x04001124 RID: 4388
		public static readonly int _RayBinResult = Shader.PropertyToID("_RayBinResult");

		// Token: 0x04001125 RID: 4389
		public static readonly int _RayBinSizeResult = Shader.PropertyToID("_RayBinSizeResult");

		// Token: 0x04001126 RID: 4390
		public static readonly int _RayBinTileCountX = Shader.PropertyToID("_RayBinTileCountX");

		// Token: 0x04001127 RID: 4391
		public static readonly int _BufferSizeX = Shader.PropertyToID("_BufferSizeX");

		// Token: 0x04001128 RID: 4392
		public static readonly int _RayBinViewOffset = Shader.PropertyToID("_RayBinViewOffset");

		// Token: 0x04001129 RID: 4393
		public static readonly int _RayBinTileViewOffset = Shader.PropertyToID("_RayBinTileViewOffset");

		// Token: 0x0400112A RID: 4394
		public static readonly int _ThroughputTextureRW = Shader.PropertyToID("_ThroughputTextureRW");

		// Token: 0x0400112B RID: 4395
		public static readonly int _NormalTextureRW = Shader.PropertyToID("_NormalTextureRW");

		// Token: 0x0400112C RID: 4396
		public static readonly int _DirectionTextureRW = Shader.PropertyToID("_DirectionTextureRW");

		// Token: 0x0400112D RID: 4397
		public static readonly int _PositionTextureRW = Shader.PropertyToID("_PositionTextureRW");

		// Token: 0x0400112E RID: 4398
		public static readonly int _DiffuseLightingTextureRW = Shader.PropertyToID("_DiffuseLightingTextureRW");

		// Token: 0x0400112F RID: 4399
		public static readonly int _SubSurfaceLightingBuffer = Shader.PropertyToID("_SubSurfaceLightingBuffer");

		// Token: 0x04001130 RID: 4400
		public static readonly int _IndirectDiffuseLightingBuffer = Shader.PropertyToID("_IndirectDiffuseLightingBuffer");

		// Token: 0x04001131 RID: 4401
		public static readonly int _AccumulationFrameIndex = Shader.PropertyToID("_AccumulationFrameIndex");

		// Token: 0x04001132 RID: 4402
		public static readonly int _AccumulationNumSamples = Shader.PropertyToID("_AccumulationNumSamples");

		// Token: 0x04001133 RID: 4403
		public static readonly int _AccumulationWeights = Shader.PropertyToID("_AccumulationWeights");

		// Token: 0x04001134 RID: 4404
		public static readonly int _AccumulationNeedsExposure = Shader.PropertyToID("_AccumulationNeedsExposure");

		// Token: 0x04001135 RID: 4405
		public static readonly int _FrameTexture = Shader.PropertyToID("_FrameTexture");

		// Token: 0x04001136 RID: 4406
		public static readonly int _SkyCameraTexture = Shader.PropertyToID("_SkyCameraTexture");

		// Token: 0x04001137 RID: 4407
		public static readonly int _PreIntegratedFGD_GGXDisneyDiffuse = Shader.PropertyToID("_PreIntegratedFGD_GGXDisneyDiffuse");

		// Token: 0x04001138 RID: 4408
		public static readonly int _PreIntegratedFGD_CharlieAndFabric = Shader.PropertyToID("_PreIntegratedFGD_CharlieAndFabric");

		// Token: 0x04001139 RID: 4409
		public static readonly int _PreIntegratedFGD_Marschner = Shader.PropertyToID("_PreIntegratedFGD_Marschner");

		// Token: 0x0400113A RID: 4410
		public static readonly int _PreIntegratedAzimuthalScattering = Shader.PropertyToID("_PreIntegratedAzimuthalScattering");

		// Token: 0x0400113B RID: 4411
		public static readonly int _ExposureTexture = Shader.PropertyToID("_ExposureTexture");

		// Token: 0x0400113C RID: 4412
		public static readonly int _PrevExposureTexture = Shader.PropertyToID("_PrevExposureTexture");

		// Token: 0x0400113D RID: 4413
		public static readonly int _PreviousExposureTexture = Shader.PropertyToID("_PreviousExposureTexture");

		// Token: 0x0400113E RID: 4414
		public static readonly int _ExposureDebugTexture = Shader.PropertyToID("_ExposureDebugTexture");

		// Token: 0x0400113F RID: 4415
		public static readonly int _ExposureParams = Shader.PropertyToID("_ExposureParams");

		// Token: 0x04001140 RID: 4416
		public static readonly int _ExposureParams2 = Shader.PropertyToID("_ExposureParams2");

		// Token: 0x04001141 RID: 4417
		public static readonly int _ExposureDebugParams = Shader.PropertyToID("_ExposureDebugParams");

		// Token: 0x04001142 RID: 4418
		public static readonly int _HistogramExposureParams = Shader.PropertyToID("_HistogramExposureParams");

		// Token: 0x04001143 RID: 4419
		public static readonly int _HistogramBuffer = Shader.PropertyToID("_HistogramBuffer");

		// Token: 0x04001144 RID: 4420
		public static readonly int _FullImageHistogram = Shader.PropertyToID("_FullImageHistogram");

		// Token: 0x04001145 RID: 4421
		public static readonly int _xyBuffer = Shader.PropertyToID("_xyBuffer");

		// Token: 0x04001146 RID: 4422
		public static readonly int _HDRxyBufferDebugParams = Shader.PropertyToID("_HDRxyBufferDebugParams");

		// Token: 0x04001147 RID: 4423
		public static readonly int _HDRDebugParams = Shader.PropertyToID("_HDRDebugParams");

		// Token: 0x04001148 RID: 4424
		public static readonly int _AdaptationParams = Shader.PropertyToID("_AdaptationParams");

		// Token: 0x04001149 RID: 4425
		public static readonly int _ExposureCurveTexture = Shader.PropertyToID("_ExposureCurveTexture");

		// Token: 0x0400114A RID: 4426
		public static readonly int _ExposureWeightMask = Shader.PropertyToID("_ExposureWeightMask");

		// Token: 0x0400114B RID: 4427
		public static readonly int _ProceduralMaskParams = Shader.PropertyToID("_ProceduralMaskParams");

		// Token: 0x0400114C RID: 4428
		public static readonly int _ProceduralMaskParams2 = Shader.PropertyToID("_ProceduralMaskParams2");

		// Token: 0x0400114D RID: 4429
		public static readonly int _Variants = Shader.PropertyToID("_Variants");

		// Token: 0x0400114E RID: 4430
		public static readonly int _InputTexture = Shader.PropertyToID("_InputTexture");

		// Token: 0x0400114F RID: 4431
		public static readonly int _InputTextureArray = Shader.PropertyToID("_InputTextureArray");

		// Token: 0x04001150 RID: 4432
		public static readonly int _InputTextureMSAA = Shader.PropertyToID("_InputTextureMSAA");

		// Token: 0x04001151 RID: 4433
		public static readonly int _OutputTexture = Shader.PropertyToID("_OutputTexture");

		// Token: 0x04001152 RID: 4434
		public static readonly int _SourceTexture = Shader.PropertyToID("_SourceTexture");

		// Token: 0x04001153 RID: 4435
		public static readonly int _InputHistoryTexture = Shader.PropertyToID("_InputHistoryTexture");

		// Token: 0x04001154 RID: 4436
		public static readonly int _OutputHistoryTexture = Shader.PropertyToID("_OutputHistoryTexture");

		// Token: 0x04001155 RID: 4437
		public static readonly int _InputVelocityMagnitudeHistory = Shader.PropertyToID("_InputVelocityMagnitudeHistory");

		// Token: 0x04001156 RID: 4438
		public static readonly int _OutputVelocityMagnitudeHistory = Shader.PropertyToID("_OutputVelocityMagnitudeHistory");

		// Token: 0x04001157 RID: 4439
		public static readonly int _OutputDepthTexture = Shader.PropertyToID("_OutputDepthTexture");

		// Token: 0x04001158 RID: 4440
		public static readonly int _OutputMotionVectorTexture = Shader.PropertyToID("_OutputMotionVectorTexture");

		// Token: 0x04001159 RID: 4441
		public static readonly int _TargetScale = Shader.PropertyToID("_TargetScale");

		// Token: 0x0400115A RID: 4442
		public static readonly int _Params = Shader.PropertyToID("_Params");

		// Token: 0x0400115B RID: 4443
		public static readonly int _Params1 = Shader.PropertyToID("_Params1");

		// Token: 0x0400115C RID: 4444
		public static readonly int _Params2 = Shader.PropertyToID("_Params2");

		// Token: 0x0400115D RID: 4445
		public static readonly int _Params3 = Shader.PropertyToID("_Params3");

		// Token: 0x0400115E RID: 4446
		public static readonly int _BokehKernel = Shader.PropertyToID("_BokehKernel");

		// Token: 0x0400115F RID: 4447
		public static readonly int _InputCoCTexture = Shader.PropertyToID("_InputCoCTexture");

		// Token: 0x04001160 RID: 4448
		public static readonly int _InputHistoryCoCTexture = Shader.PropertyToID("_InputHistoryCoCTexture");

		// Token: 0x04001161 RID: 4449
		public static readonly int _OutputCoCTexture = Shader.PropertyToID("_OutputCoCTexture");

		// Token: 0x04001162 RID: 4450
		public static readonly int _OutputNearCoCTexture = Shader.PropertyToID("_OutputNearCoCTexture");

		// Token: 0x04001163 RID: 4451
		public static readonly int _OutputNearTexture = Shader.PropertyToID("_OutputNearTexture");

		// Token: 0x04001164 RID: 4452
		public static readonly int _OutputFarCoCTexture = Shader.PropertyToID("_OutputFarCoCTexture");

		// Token: 0x04001165 RID: 4453
		public static readonly int _OutputFarTexture = Shader.PropertyToID("_OutputFarTexture");

		// Token: 0x04001166 RID: 4454
		public static readonly int _OutputMip1 = Shader.PropertyToID("_OutputMip1");

		// Token: 0x04001167 RID: 4455
		public static readonly int _OutputMip2 = Shader.PropertyToID("_OutputMip2");

		// Token: 0x04001168 RID: 4456
		public static readonly int _OutputMip3 = Shader.PropertyToID("_OutputMip3");

		// Token: 0x04001169 RID: 4457
		public static readonly int _OutputMip4 = Shader.PropertyToID("_OutputMip4");

		// Token: 0x0400116A RID: 4458
		public static readonly int _OutputMip5 = Shader.PropertyToID("_OutputMip5");

		// Token: 0x0400116B RID: 4459
		public static readonly int _OutputMip6 = Shader.PropertyToID("_OutputMip6");

		// Token: 0x0400116C RID: 4460
		public static readonly int _IndirectBuffer = Shader.PropertyToID("_IndirectBuffer");

		// Token: 0x0400116D RID: 4461
		public static readonly int _InputNearCoCTexture = Shader.PropertyToID("_InputNearCoCTexture");

		// Token: 0x0400116E RID: 4462
		public static readonly int _NearTileList = Shader.PropertyToID("_NearTileList");

		// Token: 0x0400116F RID: 4463
		public static readonly int _InputFarTexture = Shader.PropertyToID("_InputFarTexture");

		// Token: 0x04001170 RID: 4464
		public static readonly int _InputNearTexture = Shader.PropertyToID("_InputNearTexture");

		// Token: 0x04001171 RID: 4465
		public static readonly int _InputFarCoCTexture = Shader.PropertyToID("_InputFarCoCTexture");

		// Token: 0x04001172 RID: 4466
		public static readonly int _FarTileList = Shader.PropertyToID("_FarTileList");

		// Token: 0x04001173 RID: 4467
		public static readonly int _TileList = Shader.PropertyToID("_TileList");

		// Token: 0x04001174 RID: 4468
		public static readonly int _TexelSize = Shader.PropertyToID("_TexelSize");

		// Token: 0x04001175 RID: 4469
		public static readonly int _InputDilatedCoCTexture = Shader.PropertyToID("_InputDilatedCoCTexture");

		// Token: 0x04001176 RID: 4470
		public static readonly int _OutputAlphaTexture = Shader.PropertyToID("_OutputAlphaTexture");

		// Token: 0x04001177 RID: 4471
		public static readonly int _InputNearAlphaTexture = Shader.PropertyToID("_InputNearAlphaTexture");

		// Token: 0x04001178 RID: 4472
		public static readonly int _CoCTargetScale = Shader.PropertyToID("_CoCTargetScale");

		// Token: 0x04001179 RID: 4473
		public static readonly int _DepthMinMaxAvg = Shader.PropertyToID("_DepthMinMaxAvg");

		// Token: 0x0400117A RID: 4474
		public static readonly int _FlareOcclusionTex = Shader.PropertyToID("_FlareOcclusionTex");

		// Token: 0x0400117B RID: 4475
		public static readonly int _FlareCloudOpacity = Shader.PropertyToID("_FlareCloudOpacity");

		// Token: 0x0400117C RID: 4476
		public static readonly int _FlareSunOcclusionTex = Shader.PropertyToID("_FlareSunOcclusionTex");

		// Token: 0x0400117D RID: 4477
		public static readonly int _FlareOcclusionRemapTex = Shader.PropertyToID("_FlareOcclusionRemapTex");

		// Token: 0x0400117E RID: 4478
		public static readonly int _LensFlareOcclusion = Shader.PropertyToID("_LensFlareOcclusion");

		// Token: 0x0400117F RID: 4479
		public static readonly int _FlareTex = Shader.PropertyToID("_FlareTex");

		// Token: 0x04001180 RID: 4480
		public static readonly int _FlareColorValue = Shader.PropertyToID("_FlareColorValue");

		// Token: 0x04001181 RID: 4481
		public static readonly int _FlareData0 = Shader.PropertyToID("_FlareData0");

		// Token: 0x04001182 RID: 4482
		public static readonly int _FlareData1 = Shader.PropertyToID("_FlareData1");

		// Token: 0x04001183 RID: 4483
		public static readonly int _FlareData2 = Shader.PropertyToID("_FlareData2");

		// Token: 0x04001184 RID: 4484
		public static readonly int _FlareData3 = Shader.PropertyToID("_FlareData3");

		// Token: 0x04001185 RID: 4485
		public static readonly int _FlareData4 = Shader.PropertyToID("_FlareData4");

		// Token: 0x04001186 RID: 4486
		public static readonly int _FlareData5 = Shader.PropertyToID("_FlareData5");

		// Token: 0x04001187 RID: 4487
		public static readonly int _FlareOcclusionIndex = Shader.PropertyToID("_FlareOcclusionIndex");

		// Token: 0x04001188 RID: 4488
		public static readonly int _BloomParams = Shader.PropertyToID("_BloomParams");

		// Token: 0x04001189 RID: 4489
		public static readonly int _BloomTint = Shader.PropertyToID("_BloomTint");

		// Token: 0x0400118A RID: 4490
		public static readonly int _BloomTexture = Shader.PropertyToID("_BloomTexture");

		// Token: 0x0400118B RID: 4491
		public static readonly int _BloomDirtTexture = Shader.PropertyToID("_BloomDirtTexture");

		// Token: 0x0400118C RID: 4492
		public static readonly int _BloomDirtScaleOffset = Shader.PropertyToID("_BloomDirtScaleOffset");

		// Token: 0x0400118D RID: 4493
		public static readonly int _InputLowTexture = Shader.PropertyToID("_InputLowTexture");

		// Token: 0x0400118E RID: 4494
		public static readonly int _InputHighTexture = Shader.PropertyToID("_InputHighTexture");

		// Token: 0x0400118F RID: 4495
		public static readonly int _BloomBicubicParams = Shader.PropertyToID("_BloomBicubicParams");

		// Token: 0x04001190 RID: 4496
		public static readonly int _BloomThreshold = Shader.PropertyToID("_BloomThreshold");

		// Token: 0x04001191 RID: 4497
		public static readonly int _ChromaSpectralLut = Shader.PropertyToID("_ChromaSpectralLut");

		// Token: 0x04001192 RID: 4498
		public static readonly int _ChromaParams = Shader.PropertyToID("_ChromaParams");

		// Token: 0x04001193 RID: 4499
		public static readonly int _AlphaScaleBias = Shader.PropertyToID("_AlphaScaleBias");

		// Token: 0x04001194 RID: 4500
		public static readonly int _VignetteParams1 = Shader.PropertyToID("_VignetteParams1");

		// Token: 0x04001195 RID: 4501
		public static readonly int _VignetteParams2 = Shader.PropertyToID("_VignetteParams2");

		// Token: 0x04001196 RID: 4502
		public static readonly int _VignetteColor = Shader.PropertyToID("_VignetteColor");

		// Token: 0x04001197 RID: 4503
		public static readonly int _VignetteMask = Shader.PropertyToID("_VignetteMask");

		// Token: 0x04001198 RID: 4504
		public static readonly int _DistortionParams1 = Shader.PropertyToID("_DistortionParams1");

		// Token: 0x04001199 RID: 4505
		public static readonly int _DistortionParams2 = Shader.PropertyToID("_DistortionParams2");

		// Token: 0x0400119A RID: 4506
		public static readonly int _LogLut3D = Shader.PropertyToID("_LogLut3D");

		// Token: 0x0400119B RID: 4507
		public static readonly int _LogLut3D_Params = Shader.PropertyToID("_LogLut3D_Params");

		// Token: 0x0400119C RID: 4508
		public static readonly int _ColorBalance = Shader.PropertyToID("_ColorBalance");

		// Token: 0x0400119D RID: 4509
		public static readonly int _ColorFilter = Shader.PropertyToID("_ColorFilter");

		// Token: 0x0400119E RID: 4510
		public static readonly int _ChannelMixerRed = Shader.PropertyToID("_ChannelMixerRed");

		// Token: 0x0400119F RID: 4511
		public static readonly int _ChannelMixerGreen = Shader.PropertyToID("_ChannelMixerGreen");

		// Token: 0x040011A0 RID: 4512
		public static readonly int _ChannelMixerBlue = Shader.PropertyToID("_ChannelMixerBlue");

		// Token: 0x040011A1 RID: 4513
		public static readonly int _HueSatCon = Shader.PropertyToID("_HueSatCon");

		// Token: 0x040011A2 RID: 4514
		public static readonly int _Lift = Shader.PropertyToID("_Lift");

		// Token: 0x040011A3 RID: 4515
		public static readonly int _Gamma = Shader.PropertyToID("_Gamma");

		// Token: 0x040011A4 RID: 4516
		public static readonly int _Gain = Shader.PropertyToID("_Gain");

		// Token: 0x040011A5 RID: 4517
		public static readonly int _Shadows = Shader.PropertyToID("_Shadows");

		// Token: 0x040011A6 RID: 4518
		public static readonly int _Midtones = Shader.PropertyToID("_Midtones");

		// Token: 0x040011A7 RID: 4519
		public static readonly int _Highlights = Shader.PropertyToID("_Highlights");

		// Token: 0x040011A8 RID: 4520
		public static readonly int _ShaHiLimits = Shader.PropertyToID("_ShaHiLimits");

		// Token: 0x040011A9 RID: 4521
		public static readonly int _SplitShadows = Shader.PropertyToID("_SplitShadows");

		// Token: 0x040011AA RID: 4522
		public static readonly int _SplitHighlights = Shader.PropertyToID("_SplitHighlights");

		// Token: 0x040011AB RID: 4523
		public static readonly int _CurveMaster = Shader.PropertyToID("_CurveMaster");

		// Token: 0x040011AC RID: 4524
		public static readonly int _CurveRed = Shader.PropertyToID("_CurveRed");

		// Token: 0x040011AD RID: 4525
		public static readonly int _CurveGreen = Shader.PropertyToID("_CurveGreen");

		// Token: 0x040011AE RID: 4526
		public static readonly int _CurveBlue = Shader.PropertyToID("_CurveBlue");

		// Token: 0x040011AF RID: 4527
		public static readonly int _CurveHueVsHue = Shader.PropertyToID("_CurveHueVsHue");

		// Token: 0x040011B0 RID: 4528
		public static readonly int _CurveHueVsSat = Shader.PropertyToID("_CurveHueVsSat");

		// Token: 0x040011B1 RID: 4529
		public static readonly int _CurveSatVsSat = Shader.PropertyToID("_CurveSatVsSat");

		// Token: 0x040011B2 RID: 4530
		public static readonly int _CurveLumVsSat = Shader.PropertyToID("_CurveLumVsSat");

		// Token: 0x040011B3 RID: 4531
		public static readonly int _CustomToneCurve = Shader.PropertyToID("_CustomToneCurve");

		// Token: 0x040011B4 RID: 4532
		public static readonly int _ToeSegmentA = Shader.PropertyToID("_ToeSegmentA");

		// Token: 0x040011B5 RID: 4533
		public static readonly int _ToeSegmentB = Shader.PropertyToID("_ToeSegmentB");

		// Token: 0x040011B6 RID: 4534
		public static readonly int _MidSegmentA = Shader.PropertyToID("_MidSegmentA");

		// Token: 0x040011B7 RID: 4535
		public static readonly int _MidSegmentB = Shader.PropertyToID("_MidSegmentB");

		// Token: 0x040011B8 RID: 4536
		public static readonly int _ShoSegmentA = Shader.PropertyToID("_ShoSegmentA");

		// Token: 0x040011B9 RID: 4537
		public static readonly int _ShoSegmentB = Shader.PropertyToID("_ShoSegmentB");

		// Token: 0x040011BA RID: 4538
		public static readonly int _Depth = Shader.PropertyToID("_Depth");

		// Token: 0x040011BB RID: 4539
		public static readonly int _LinearZ = Shader.PropertyToID("_LinearZ");

		// Token: 0x040011BC RID: 4540
		public static readonly int _DS2x = Shader.PropertyToID("_DS2x");

		// Token: 0x040011BD RID: 4541
		public static readonly int _DS4x = Shader.PropertyToID("_DS4x");

		// Token: 0x040011BE RID: 4542
		public static readonly int _DS8x = Shader.PropertyToID("_DS8x");

		// Token: 0x040011BF RID: 4543
		public static readonly int _DS16x = Shader.PropertyToID("_DS16x");

		// Token: 0x040011C0 RID: 4544
		public static readonly int _DS2xAtlas = Shader.PropertyToID("_DS2xAtlas");

		// Token: 0x040011C1 RID: 4545
		public static readonly int _DS4xAtlas = Shader.PropertyToID("_DS4xAtlas");

		// Token: 0x040011C2 RID: 4546
		public static readonly int _DS8xAtlas = Shader.PropertyToID("_DS8xAtlas");

		// Token: 0x040011C3 RID: 4547
		public static readonly int _DS16xAtlas = Shader.PropertyToID("_DS16xAtlas");

		// Token: 0x040011C4 RID: 4548
		public static readonly int _InvThicknessTable = Shader.PropertyToID("_InvThicknessTable");

		// Token: 0x040011C5 RID: 4549
		public static readonly int _SampleWeightTable = Shader.PropertyToID("_SampleWeightTable");

		// Token: 0x040011C6 RID: 4550
		public static readonly int _InvSliceDimension = Shader.PropertyToID("_InvSliceDimension");

		// Token: 0x040011C7 RID: 4551
		public static readonly int _AdditionalParams = Shader.PropertyToID("_AdditionalParams");

		// Token: 0x040011C8 RID: 4552
		public static readonly int _Occlusion = Shader.PropertyToID("_Occlusion");

		// Token: 0x040011C9 RID: 4553
		public static readonly int _InvLowResolution = Shader.PropertyToID("_InvLowResolution");

		// Token: 0x040011CA RID: 4554
		public static readonly int _InvHighResolution = Shader.PropertyToID("_InvHighResolution");

		// Token: 0x040011CB RID: 4555
		public static readonly int _LoResDB = Shader.PropertyToID("_LoResDB");

		// Token: 0x040011CC RID: 4556
		public static readonly int _HiResDB = Shader.PropertyToID("_HiResDB");

		// Token: 0x040011CD RID: 4557
		public static readonly int _LoResAO1 = Shader.PropertyToID("_LoResAO1");

		// Token: 0x040011CE RID: 4558
		public static readonly int _HiResAO = Shader.PropertyToID("_HiResAO");

		// Token: 0x040011CF RID: 4559
		public static readonly int _AoResult = Shader.PropertyToID("_AoResult");

		// Token: 0x040011D0 RID: 4560
		public static readonly int _GrainTexture = Shader.PropertyToID("_GrainTexture");

		// Token: 0x040011D1 RID: 4561
		public static readonly int _GrainParams = Shader.PropertyToID("_GrainParams");

		// Token: 0x040011D2 RID: 4562
		public static readonly int _GrainTextureParams = Shader.PropertyToID("_GrainTextureParams");

		// Token: 0x040011D3 RID: 4563
		public static readonly int _BlueNoiseTexture = Shader.PropertyToID("_BlueNoiseTexture");

		// Token: 0x040011D4 RID: 4564
		public static readonly int _AlphaTexture = Shader.PropertyToID("_AlphaTexture");

		// Token: 0x040011D5 RID: 4565
		public static readonly int _OwenScrambledRGTexture = Shader.PropertyToID("_OwenScrambledRGTexture");

		// Token: 0x040011D6 RID: 4566
		public static readonly int _OwenScrambledTexture = Shader.PropertyToID("_OwenScrambledTexture");

		// Token: 0x040011D7 RID: 4567
		public static readonly int _ScramblingTileXSPP = Shader.PropertyToID("_ScramblingTileXSPP");

		// Token: 0x040011D8 RID: 4568
		public static readonly int _RankingTileXSPP = Shader.PropertyToID("_RankingTileXSPP");

		// Token: 0x040011D9 RID: 4569
		public static readonly int _ScramblingTexture = Shader.PropertyToID("_ScramblingTexture");

		// Token: 0x040011DA RID: 4570
		public static readonly int _AfterPostProcessTexture = Shader.PropertyToID("_AfterPostProcessTexture");

		// Token: 0x040011DB RID: 4571
		public static readonly int _DitherParams = Shader.PropertyToID("_DitherParams");

		// Token: 0x040011DC RID: 4572
		public static readonly int _KeepAlpha = Shader.PropertyToID("_KeepAlpha");

		// Token: 0x040011DD RID: 4573
		public static readonly int _UVTransform = Shader.PropertyToID("_UVTransform");

		// Token: 0x040011DE RID: 4574
		public static readonly int _UITexture = Shader.PropertyToID("_UITexture");

		// Token: 0x040011DF RID: 4575
		public static readonly int _HDROutputParams = Shader.PropertyToID("_HDROutputParams");

		// Token: 0x040011E0 RID: 4576
		public static readonly int _HDROutputParams2 = Shader.PropertyToID("_HDROutputParams2");

		// Token: 0x040011E1 RID: 4577
		public static readonly int _NeedsFlip = Shader.PropertyToID("_NeedsFlip");

		// Token: 0x040011E2 RID: 4578
		public static readonly int _MotionVecAndDepth = Shader.PropertyToID("_MotionVecAndDepth");

		// Token: 0x040011E3 RID: 4579
		public static readonly int _TileMinMaxMotionVec = Shader.PropertyToID("_TileMinMaxMotionVec");

		// Token: 0x040011E4 RID: 4580
		public static readonly int _TileMaxNeighbourhood = Shader.PropertyToID("_TileMaxNeighbourhood");

		// Token: 0x040011E5 RID: 4581
		public static readonly int _TileToScatterMax = Shader.PropertyToID("_TileToScatterMax");

		// Token: 0x040011E6 RID: 4582
		public static readonly int _TileToScatterMin = Shader.PropertyToID("_TileToScatterMin");

		// Token: 0x040011E7 RID: 4583
		public static readonly int _TileTargetSize = Shader.PropertyToID("_TileTargetSize");

		// Token: 0x040011E8 RID: 4584
		public static readonly int _MotionBlurParams = Shader.PropertyToID("_MotionBlurParams0");

		// Token: 0x040011E9 RID: 4585
		public static readonly int _MotionBlurParams1 = Shader.PropertyToID("_MotionBlurParams1");

		// Token: 0x040011EA RID: 4586
		public static readonly int _MotionBlurParams2 = Shader.PropertyToID("_MotionBlurParams2");

		// Token: 0x040011EB RID: 4587
		public static readonly int _MotionBlurParams3 = Shader.PropertyToID("_MotionBlurParams3");

		// Token: 0x040011EC RID: 4588
		public static readonly int _PrevVPMatrixNoTranslation = Shader.PropertyToID("_PrevVPMatrixNoTranslation");

		// Token: 0x040011ED RID: 4589
		public static readonly int _CurrVPMatrixNoTranslation = Shader.PropertyToID("_CurrVPMatrixNoTranslation");

		// Token: 0x040011EE RID: 4590
		public static readonly int _SMAAAreaTex = Shader.PropertyToID("_AreaTex");

		// Token: 0x040011EF RID: 4591
		public static readonly int _SMAASearchTex = Shader.PropertyToID("_SearchTex");

		// Token: 0x040011F0 RID: 4592
		public static readonly int _SMAABlendTex = Shader.PropertyToID("_BlendTex");

		// Token: 0x040011F1 RID: 4593
		public static readonly int _SMAARTMetrics = Shader.PropertyToID("_SMAARTMetrics");

		// Token: 0x040011F2 RID: 4594
		public static readonly int _LowResDepthTexture = Shader.PropertyToID("_LowResDepthTexture");

		// Token: 0x040011F3 RID: 4595
		public static readonly int _LowResTransparent = Shader.PropertyToID("_LowResTransparent");

		// Token: 0x040011F4 RID: 4596
		public static readonly int _ShaderVariablesAmbientOcclusion = Shader.PropertyToID("ShaderVariablesAmbientOcclusion");

		// Token: 0x040011F5 RID: 4597
		public static readonly int _OcclusionTexture = Shader.PropertyToID("_OcclusionTexture");

		// Token: 0x040011F6 RID: 4598
		public static readonly int _BentNormalsTexture = Shader.PropertyToID("_BentNormalsTexture");

		// Token: 0x040011F7 RID: 4599
		public static readonly int _AOPackedData = Shader.PropertyToID("_AOPackedData");

		// Token: 0x040011F8 RID: 4600
		public static readonly int _AOPackedHistory = Shader.PropertyToID("_AOPackedHistory");

		// Token: 0x040011F9 RID: 4601
		public static readonly int _AOPackedBlurred = Shader.PropertyToID("_AOPackedBlurred");

		// Token: 0x040011FA RID: 4602
		public static readonly int _AOOutputHistory = Shader.PropertyToID("_AOOutputHistory");

		// Token: 0x040011FB RID: 4603
		public static readonly int _Sharpness = Shader.PropertyToID("Sharpness");

		// Token: 0x040011FC RID: 4604
		public static readonly int _InputTextureDimensions = Shader.PropertyToID("InputTextureDimensions");

		// Token: 0x040011FD RID: 4605
		public static readonly int _OutputTextureDimensions = Shader.PropertyToID("OutputTextureDimensions");

		// Token: 0x040011FE RID: 4606
		public static readonly int _EASUOutputSize = Shader.PropertyToID("_EASUOutputSize");

		// Token: 0x040011FF RID: 4607
		public static readonly int _InputTex = Shader.PropertyToID("_InputTex");

		// Token: 0x04001200 RID: 4608
		public static readonly int _LoD = Shader.PropertyToID("_LoD");

		// Token: 0x04001201 RID: 4609
		public static readonly int _FaceIndex = Shader.PropertyToID("_FaceIndex");

		// Token: 0x04001202 RID: 4610
		public static readonly int _APVResIndex = Shader.PropertyToID("_APVResIndex");

		// Token: 0x04001203 RID: 4611
		public static readonly int _APVResCellIndices = Shader.PropertyToID("_APVResCellIndices");

		// Token: 0x04001204 RID: 4612
		public static readonly int _APVResL0_L1Rx = Shader.PropertyToID("_APVResL0_L1Rx");

		// Token: 0x04001205 RID: 4613
		public static readonly int _APVResL1G_L1Ry = Shader.PropertyToID("_APVResL1G_L1Ry");

		// Token: 0x04001206 RID: 4614
		public static readonly int _APVResL1B_L1Rz = Shader.PropertyToID("_APVResL1B_L1Rz");

		// Token: 0x04001207 RID: 4615
		public static readonly int _APVResL2_0 = Shader.PropertyToID("_APVResL2_0");

		// Token: 0x04001208 RID: 4616
		public static readonly int _APVResL2_1 = Shader.PropertyToID("_APVResL2_1");

		// Token: 0x04001209 RID: 4617
		public static readonly int _APVResL2_2 = Shader.PropertyToID("_APVResL2_2");

		// Token: 0x0400120A RID: 4618
		public static readonly int _APVResL2_3 = Shader.PropertyToID("_APVResL2_3");

		// Token: 0x0400120B RID: 4619
		public static readonly int _APVResValidity = Shader.PropertyToID("_APVResValidity");

		// Token: 0x0400120C RID: 4620
		public static readonly int _SourceScaleBias = Shader.PropertyToID("_SourceScaleBias");

		// Token: 0x0400120D RID: 4621
		public static readonly int _GaussianWeights = Shader.PropertyToID("_GaussianWeights");

		// Token: 0x0400120E RID: 4622
		public static readonly int _SampleCount = Shader.PropertyToID("_SampleCount");

		// Token: 0x0400120F RID: 4623
		public static readonly int _Radius = Shader.PropertyToID("_Radius");

		// Token: 0x04001210 RID: 4624
		public static readonly int _ViewPortSize = Shader.PropertyToID("_ViewPortSize");

		// Token: 0x04001211 RID: 4625
		public static readonly int _ViewportScaleBias = Shader.PropertyToID("_ViewportScaleBias");

		// Token: 0x04001212 RID: 4626
		public static readonly int _SourceSize = Shader.PropertyToID("_SourceSize");

		// Token: 0x04001213 RID: 4627
		public static readonly int _SourceScaleFactor = Shader.PropertyToID("_SourceScaleFactor");

		// Token: 0x04001214 RID: 4628
		public static readonly int _OverrideRTHandleScale = Shader.PropertyToID("_OverrideRTHandleScale");

		// Token: 0x04001215 RID: 4629
		public static readonly int _Dst3DTexture = Shader.PropertyToID("_Dst3DTexture");

		// Token: 0x04001216 RID: 4630
		public static readonly int _Src3DTexture = Shader.PropertyToID("_Src3DTexture");

		// Token: 0x04001217 RID: 4631
		public static readonly int _AlphaOnlyTexture = Shader.PropertyToID("_AlphaOnlyTexture");

		// Token: 0x04001218 RID: 4632
		public static readonly int _SrcSize = Shader.PropertyToID("_SrcSize");

		// Token: 0x04001219 RID: 4633
		public static readonly int _SrcMip = Shader.PropertyToID("_SrcMip");

		// Token: 0x0400121A RID: 4634
		public static readonly int _SrcScale = Shader.PropertyToID("_SrcScale");

		// Token: 0x0400121B RID: 4635
		public static readonly int _SrcOffset = Shader.PropertyToID("_SrcOffset");

		// Token: 0x0400121C RID: 4636
		public static readonly int _VectorscopeParameters = Shader.PropertyToID("_VectorscopeParameters");

		// Token: 0x0400121D RID: 4637
		public static readonly int _VectorscopeBuffer = Shader.PropertyToID("_VectorscopeBuffer");

		// Token: 0x0400121E RID: 4638
		public static readonly int _WaveformParameters = Shader.PropertyToID("_WaveformParameters");

		// Token: 0x0400121F RID: 4639
		public static readonly int _WaveformBuffer = Shader.PropertyToID("_WaveformBuffer");

		// Token: 0x04001220 RID: 4640
		public static readonly int _BufferSize = Shader.PropertyToID("_BufferSize");

		// Token: 0x04001221 RID: 4641
		public static readonly int _VolumeCount = Shader.PropertyToID("_VolumeCount");

		// Token: 0x04001222 RID: 4642
		public static readonly int _VolumeMaterialDataIndex = Shader.PropertyToID("_VolumeMaterialDataIndex");

		// Token: 0x04001223 RID: 4643
		public static readonly int _CameraRight = Shader.PropertyToID("_CameraRight");

		// Token: 0x04001224 RID: 4644
		public static readonly int _MaxSliceCount = Shader.PropertyToID("_MaxSliceCount");

		// Token: 0x04001225 RID: 4645
		public static readonly int _VolumetricIndirectBufferArguments = Shader.PropertyToID("_IndirectBufferArguments");

		// Token: 0x04001226 RID: 4646
		public static readonly int _VolumetricMaterialData = Shader.PropertyToID("_VolumetricMaterialData");

		// Token: 0x04001227 RID: 4647
		public static readonly int _VolumetricMask = Shader.PropertyToID("_Mask");

		// Token: 0x04001228 RID: 4648
		public static readonly int _VolumetricScrollSpeed = Shader.PropertyToID("_ScrollSpeed");

		// Token: 0x04001229 RID: 4649
		public static readonly int _VolumetricTiling = Shader.PropertyToID("_Tiling");

		// Token: 0x0400122A RID: 4650
		public static readonly int _VolumetricViewIndex = Shader.PropertyToID("_ViewIndex");

		// Token: 0x0400122B RID: 4651
		public static readonly int _VolumetricViewCount = Shader.PropertyToID("_ViewCount");

		// Token: 0x0400122C RID: 4652
		public static readonly int _CameraInverseViewProjection_NO = Shader.PropertyToID("_CameraInverseViewProjection_NO");

		// Token: 0x0400122D RID: 4653
		public static readonly int _IsObliqueProjectionMatrix = Shader.PropertyToID("_IsObliqueProjectionMatrix");

		// Token: 0x0400122E RID: 4654
		public static readonly int _VolumetricMaterialDataCBuffer = Shader.PropertyToID("VolumetricMaterialDataCBuffer");
	}
}
