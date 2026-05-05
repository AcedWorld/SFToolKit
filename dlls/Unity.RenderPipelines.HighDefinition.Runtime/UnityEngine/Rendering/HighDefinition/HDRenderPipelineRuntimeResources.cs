using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000167 RID: 359
	internal class HDRenderPipelineRuntimeResources : HDRenderPipelineResources, IVersionable<HDRenderPipelineRuntimeResources.Version>, IMigratableAsset
	{
		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000C14 RID: 3092 RVA: 0x00060CAE File Offset: 0x0005EEAE
		// (set) Token: 0x06000C15 RID: 3093 RVA: 0x00060CB6 File Offset: 0x0005EEB6
		HDRenderPipelineRuntimeResources.Version IVersionable<HDRenderPipelineRuntimeResources.Version>.version
		{
			get
			{
				return this.m_Version;
			}
			set
			{
				this.m_Version = value;
			}
		}

		// Token: 0x04000E80 RID: 3712
		public HDRenderPipelineRuntimeResources.ShaderResources shaders;

		// Token: 0x04000E81 RID: 3713
		public HDRenderPipelineRuntimeResources.MaterialResources materials;

		// Token: 0x04000E82 RID: 3714
		public HDRenderPipelineRuntimeResources.TextureResources textures;

		// Token: 0x04000E83 RID: 3715
		public HDRenderPipelineRuntimeResources.ShaderGraphResources shaderGraphs;

		// Token: 0x04000E84 RID: 3716
		public HDRenderPipelineRuntimeResources.AssetResources assets;

		// Token: 0x04000E85 RID: 3717
		[HideInInspector]
		[SerializeField]
		[FormerlySerializedAs("version")]
		private HDRenderPipelineRuntimeResources.Version m_Version = MigrationDescription.LastVersion<HDRenderPipelineRuntimeResources.Version>();

		// Token: 0x020003C0 RID: 960
		[ReloadGroup]
		[Serializable]
		public sealed class ShaderResources
		{
			// Token: 0x04002675 RID: 9845
			[Reload("Runtime/Material/Lit/Lit.shader", ReloadAttribute.Package.Root)]
			public Shader defaultPS;

			// Token: 0x04002676 RID: 9846
			[Reload("Runtime/Debug/DebugDisplayLatlong.Shader", ReloadAttribute.Package.Root)]
			public Shader debugDisplayLatlongPS;

			// Token: 0x04002677 RID: 9847
			[Reload("Runtime/Debug/DebugViewMaterialGBuffer.Shader", ReloadAttribute.Package.Root)]
			public Shader debugViewMaterialGBufferPS;

			// Token: 0x04002678 RID: 9848
			[Reload("Runtime/Debug/DebugViewTiles.Shader", ReloadAttribute.Package.Root)]
			public Shader debugViewTilesPS;

			// Token: 0x04002679 RID: 9849
			[Reload("Runtime/Debug/DebugFullScreen.Shader", ReloadAttribute.Package.Root)]
			public Shader debugFullScreenPS;

			// Token: 0x0400267A RID: 9850
			[Reload("Runtime/Debug/DebugColorPicker.Shader", ReloadAttribute.Package.Root)]
			public Shader debugColorPickerPS;

			// Token: 0x0400267B RID: 9851
			[Reload("Runtime/Debug/DebugExposure.Shader", ReloadAttribute.Package.Root)]
			public Shader debugExposurePS;

			// Token: 0x0400267C RID: 9852
			[Reload("Runtime/Debug/DebugHDR.Shader", ReloadAttribute.Package.Root)]
			public Shader debugHDRPS;

			// Token: 0x0400267D RID: 9853
			[Reload("Runtime/Debug/DebugLightVolumes.Shader", ReloadAttribute.Package.Root)]
			public Shader debugLightVolumePS;

			// Token: 0x0400267E RID: 9854
			[Reload("Runtime/Debug/DebugLightVolumes.compute", ReloadAttribute.Package.Root)]
			public ComputeShader debugLightVolumeCS;

			// Token: 0x0400267F RID: 9855
			[Reload("Runtime/Debug/DebugBlitQuad.Shader", ReloadAttribute.Package.Root)]
			public Shader debugBlitQuad;

			// Token: 0x04002680 RID: 9856
			[Reload("Runtime/Debug/DebugVTBlit.Shader", ReloadAttribute.Package.Root)]
			public Shader debugViewVirtualTexturingBlit;

			// Token: 0x04002681 RID: 9857
			[Reload("Runtime/Debug/MaterialError.Shader", ReloadAttribute.Package.Root)]
			public Shader materialError;

			// Token: 0x04002682 RID: 9858
			[Reload("Runtime/Debug/MaterialLoading.shader", ReloadAttribute.Package.Root)]
			public Shader materialLoading;

			// Token: 0x04002683 RID: 9859
			[Reload("Runtime/Debug/ClearDebugBuffer.compute", ReloadAttribute.Package.Root)]
			public ComputeShader clearDebugBufferCS;

			// Token: 0x04002684 RID: 9860
			[Reload("Runtime/Debug/ProbeVolumeDebug.shader", ReloadAttribute.Package.Root)]
			public Shader probeVolumeDebugShader;

			// Token: 0x04002685 RID: 9861
			[Reload("Runtime/Debug/ProbeVolumeOffsetDebug.shader", ReloadAttribute.Package.Root)]
			public Shader probeVolumeOffsetDebugShader;

			// Token: 0x04002686 RID: 9862
			[Reload("Runtime/Lighting/ProbeVolume/ProbeVolumeBlendStates.compute", ReloadAttribute.Package.Root)]
			public ComputeShader probeVolumeBlendStatesCS;

			// Token: 0x04002687 RID: 9863
			[Reload("Runtime/Debug/DebugWaveform.shader", ReloadAttribute.Package.Root)]
			public Shader debugWaveformPS;

			// Token: 0x04002688 RID: 9864
			[Reload("Runtime/Debug/DebugWaveform.compute", ReloadAttribute.Package.Root)]
			public ComputeShader debugWaveformCS;

			// Token: 0x04002689 RID: 9865
			[Reload("Runtime/Debug/DebugVectorscope.shader", ReloadAttribute.Package.Root)]
			public Shader debugVectorscopePS;

			// Token: 0x0400268A RID: 9866
			[Reload("Runtime/Debug/DebugVectorscope.compute", ReloadAttribute.Package.Root)]
			public ComputeShader debugVectorscopeCS;

			// Token: 0x0400268B RID: 9867
			[Reload("Runtime/Lighting/Deferred.Shader", ReloadAttribute.Package.Root)]
			public Shader deferredPS;

			// Token: 0x0400268C RID: 9868
			[Reload("Runtime/RenderPipeline/RenderPass/ColorPyramidPS.Shader", ReloadAttribute.Package.Root)]
			public Shader colorPyramidPS;

			// Token: 0x0400268D RID: 9869
			[Reload("Runtime/RenderPipeline/RenderPass/DepthPyramid.compute", ReloadAttribute.Package.Root)]
			public ComputeShader depthPyramidCS;

			// Token: 0x0400268E RID: 9870
			[Reload("Runtime/RenderPipeline/RenderPass/GenerateMaxZ.compute", ReloadAttribute.Package.Root)]
			public ComputeShader maxZCS;

			// Token: 0x0400268F RID: 9871
			[Reload("Runtime/Core/CoreResources/GPUCopy.compute", ReloadAttribute.Package.Root)]
			public ComputeShader copyChannelCS;

			// Token: 0x04002690 RID: 9872
			[Reload("Runtime/Lighting/ScreenSpaceLighting/ScreenSpaceReflections.compute", ReloadAttribute.Package.Root)]
			public ComputeShader screenSpaceReflectionsCS;

			// Token: 0x04002691 RID: 9873
			[Reload("Runtime/RenderPipeline/RenderPass/Distortion/ApplyDistortion.shader", ReloadAttribute.Package.Root)]
			public Shader applyDistortionPS;

			// Token: 0x04002692 RID: 9874
			[Reload("Runtime/Lighting/LightLoop/cleardispatchindirect.compute", ReloadAttribute.Package.Root)]
			public ComputeShader clearDispatchIndirectCS;

			// Token: 0x04002693 RID: 9875
			[Reload("Runtime/Lighting/LightLoop/ClearLightLists.compute", ReloadAttribute.Package.Root)]
			public ComputeShader clearLightListsCS;

			// Token: 0x04002694 RID: 9876
			[Reload("Runtime/Lighting/LightLoop/builddispatchindirect.compute", ReloadAttribute.Package.Root)]
			public ComputeShader buildDispatchIndirectCS;

			// Token: 0x04002695 RID: 9877
			[Reload("Runtime/Lighting/LightLoop/scrbound.compute", ReloadAttribute.Package.Root)]
			public ComputeShader buildScreenAABBCS;

			// Token: 0x04002696 RID: 9878
			[Reload("Runtime/Lighting/LightLoop/lightlistbuild.compute", ReloadAttribute.Package.Root)]
			public ComputeShader buildPerTileLightListCS;

			// Token: 0x04002697 RID: 9879
			[Reload("Runtime/Lighting/LightLoop/lightlistbuild-bigtile.compute", ReloadAttribute.Package.Root)]
			public ComputeShader buildPerBigTileLightListCS;

			// Token: 0x04002698 RID: 9880
			[Reload("Runtime/Lighting/LightLoop/lightlistbuild-clustered.compute", ReloadAttribute.Package.Root)]
			public ComputeShader buildPerVoxelLightListCS;

			// Token: 0x04002699 RID: 9881
			[Reload("Runtime/Lighting/LightLoop/lightlistbuild-clearatomic.compute", ReloadAttribute.Package.Root)]
			public ComputeShader lightListClusterClearAtomicIndexCS;

			// Token: 0x0400269A RID: 9882
			[Reload("Runtime/Lighting/LightLoop/materialflags.compute", ReloadAttribute.Package.Root)]
			public ComputeShader buildMaterialFlagsCS;

			// Token: 0x0400269B RID: 9883
			[Reload("Runtime/Lighting/LightLoop/Deferred.compute", ReloadAttribute.Package.Root)]
			public ComputeShader deferredCS;

			// Token: 0x0400269C RID: 9884
			[Reload("Runtime/Lighting/Shadow/ContactShadows.compute", ReloadAttribute.Package.Root)]
			public ComputeShader contactShadowCS;

			// Token: 0x0400269D RID: 9885
			[Reload("Runtime/Lighting/VolumetricLighting/VolumeVoxelization.compute", ReloadAttribute.Package.Root)]
			public ComputeShader volumeVoxelizationCS;

			// Token: 0x0400269E RID: 9886
			[Reload("Runtime/Lighting/VolumetricLighting/VolumetricLighting.compute", ReloadAttribute.Package.Root)]
			public ComputeShader volumetricLightingCS;

			// Token: 0x0400269F RID: 9887
			[Reload("Runtime/Lighting/VolumetricLighting/VolumetricLightingFiltering.compute", ReloadAttribute.Package.Root)]
			public ComputeShader volumetricLightingFilteringCS;

			// Token: 0x040026A0 RID: 9888
			[Reload("Runtime/Lighting/LightLoop/DeferredTile.shader", ReloadAttribute.Package.Root)]
			public Shader deferredTilePS;

			// Token: 0x040026A1 RID: 9889
			[Reload("Runtime/Lighting/Shadow/ScreenSpaceShadows.shader", ReloadAttribute.Package.Root)]
			public Shader screenSpaceShadowPS;

			// Token: 0x040026A2 RID: 9890
			[Reload("Runtime/Material/SubsurfaceScattering/SubsurfaceScattering.compute", ReloadAttribute.Package.Root)]
			public ComputeShader subsurfaceScatteringCS;

			// Token: 0x040026A3 RID: 9891
			[Reload("Runtime/Material/SubsurfaceScattering/CombineLighting.shader", ReloadAttribute.Package.Root)]
			public Shader combineLightingPS;

			// Token: 0x040026A4 RID: 9892
			[Reload("Runtime/Lighting/VolumetricLighting/DebugLocalVolumetricFogAtlas.shader", ReloadAttribute.Package.Root)]
			public Shader debugLocalVolumetricFogAtlasPS;

			// Token: 0x040026A5 RID: 9893
			[Reload("Runtime/RenderPipeline/RenderPass/MotionVectors/CameraMotionVectors.shader", ReloadAttribute.Package.Root)]
			public Shader cameraMotionVectorsPS;

			// Token: 0x040026A6 RID: 9894
			[Reload("Runtime/ShaderLibrary/ClearStencilBuffer.shader", ReloadAttribute.Package.Root)]
			public Shader clearStencilBufferPS;

			// Token: 0x040026A7 RID: 9895
			[Reload("Runtime/ShaderLibrary/CopyStencilBuffer.shader", ReloadAttribute.Package.Root)]
			public Shader copyStencilBufferPS;

			// Token: 0x040026A8 RID: 9896
			[Reload("Runtime/ShaderLibrary/CopyDepthBuffer.shader", ReloadAttribute.Package.Root)]
			public Shader copyDepthBufferPS;

			// Token: 0x040026A9 RID: 9897
			[Reload("Runtime/ShaderLibrary/Blit.shader", ReloadAttribute.Package.Root)]
			public Shader blitPS;

			// Token: 0x040026AA RID: 9898
			[Reload("Runtime/ShaderLibrary/BlitColorAndDepth.shader", ReloadAttribute.Package.Root)]
			public Shader blitColorAndDepthPS;

			// Token: 0x040026AB RID: 9899
			[Reload("Runtime/Core/CoreResources/ClearBuffer2D.compute", ReloadAttribute.Package.Root)]
			public ComputeShader clearBuffer2D;

			// Token: 0x040026AC RID: 9900
			[Reload("Runtime/ShaderLibrary/DownsampleDepth.shader", ReloadAttribute.Package.Root)]
			public Shader downsampleDepthPS;

			// Token: 0x040026AD RID: 9901
			[Reload("Runtime/ShaderLibrary/UpsampleTransparent.shader", ReloadAttribute.Package.Root)]
			public Shader upsampleTransparentPS;

			// Token: 0x040026AE RID: 9902
			[Reload("Runtime/ShaderLibrary/ResolveStencilBuffer.compute", ReloadAttribute.Package.Root)]
			public ComputeShader resolveStencilCS;

			// Token: 0x040026AF RID: 9903
			[Reload("Runtime/Sky/BlitCubemap.shader", ReloadAttribute.Package.Root)]
			public Shader blitCubemapPS;

			// Token: 0x040026B0 RID: 9904
			[Reload("Runtime/Material/GGXConvolution/BuildProbabilityTables.compute", ReloadAttribute.Package.Root)]
			public ComputeShader buildProbabilityTablesCS;

			// Token: 0x040026B1 RID: 9905
			[Reload("Runtime/Material/GGXConvolution/ComputeGgxIblSampleData.compute", ReloadAttribute.Package.Root)]
			public ComputeShader computeGgxIblSampleDataCS;

			// Token: 0x040026B2 RID: 9906
			[Reload("Runtime/Material/GGXConvolution/GGXConvolve.shader", ReloadAttribute.Package.Root)]
			public Shader GGXConvolvePS;

			// Token: 0x040026B3 RID: 9907
			[Reload("Runtime/Material/Fabric/CharlieConvolve.shader", ReloadAttribute.Package.Root)]
			public Shader charlieConvolvePS;

			// Token: 0x040026B4 RID: 9908
			[Reload("Runtime/Lighting/AtmosphericScattering/OpaqueAtmosphericScattering.shader", ReloadAttribute.Package.Root)]
			public Shader opaqueAtmosphericScatteringPS;

			// Token: 0x040026B5 RID: 9909
			[Reload("Runtime/Sky/HDRISky/HDRISky.shader", ReloadAttribute.Package.Root)]
			public Shader hdriSkyPS;

			// Token: 0x040026B6 RID: 9910
			[Reload("Runtime/Sky/HDRISky/IntegrateHDRISky.shader", ReloadAttribute.Package.Root)]
			public Shader integrateHdriSkyPS;

			// Token: 0x040026B7 RID: 9911
			[Reload("Skybox/Cubemap", ReloadAttribute.Package.Builtin)]
			public Shader skyboxCubemapPS;

			// Token: 0x040026B8 RID: 9912
			[Reload("Runtime/Sky/GradientSky/GradientSky.shader", ReloadAttribute.Package.Root)]
			public Shader gradientSkyPS;

			// Token: 0x040026B9 RID: 9913
			[Reload("Runtime/Sky/AmbientProbeConvolution.compute", ReloadAttribute.Package.Root)]
			public ComputeShader ambientProbeConvolutionCS;

			// Token: 0x040026BA RID: 9914
			[Reload("Runtime/Sky/PhysicallyBasedSky/SkyLUTGenerator.compute", ReloadAttribute.Package.Root)]
			public ComputeShader skyLUTGenerator;

			// Token: 0x040026BB RID: 9915
			[Reload("Runtime/Sky/PhysicallyBasedSky/GroundIrradiancePrecomputation.compute", ReloadAttribute.Package.Root)]
			public ComputeShader groundIrradiancePrecomputationCS;

			// Token: 0x040026BC RID: 9916
			[Reload("Runtime/Sky/PhysicallyBasedSky/InScatteredRadiancePrecomputation.compute", ReloadAttribute.Package.Root)]
			public ComputeShader inScatteredRadiancePrecomputationCS;

			// Token: 0x040026BD RID: 9917
			[Reload("Runtime/Sky/PhysicallyBasedSky/PhysicallyBasedSky.shader", ReloadAttribute.Package.Root)]
			public Shader physicallyBasedSkyPS;

			// Token: 0x040026BE RID: 9918
			[Reload("Runtime/Lighting/PlanarReflectionFiltering.compute", ReloadAttribute.Package.Root)]
			public ComputeShader planarReflectionFilteringCS;

			// Token: 0x040026BF RID: 9919
			[Reload("Runtime/Sky/CloudSystem/CloudLayer/CloudLayer.shader", ReloadAttribute.Package.Root)]
			public Shader cloudLayerPS;

			// Token: 0x040026C0 RID: 9920
			[Reload("Runtime/Sky/CloudSystem/CloudLayer/BakeCloudTexture.compute", ReloadAttribute.Package.Root)]
			public ComputeShader bakeCloudTextureCS;

			// Token: 0x040026C1 RID: 9921
			[Reload("Runtime/Sky/CloudSystem/CloudLayer/BakeCloudShadows.compute", ReloadAttribute.Package.Root)]
			public ComputeShader bakeCloudShadowsCS;

			// Token: 0x040026C2 RID: 9922
			[Reload("Runtime/Lighting/VolumetricLighting/VolumetricClouds.compute", ReloadAttribute.Package.Root)]
			public ComputeShader volumetricCloudsCS;

			// Token: 0x040026C3 RID: 9923
			[Reload("Editor/Lighting/VolumetricClouds/CloudMapGenerator.compute", ReloadAttribute.Package.Root)]
			public ComputeShader volumetricCloudMapGeneratorCS;

			// Token: 0x040026C4 RID: 9924
			[Reload("Runtime/Lighting/VolumetricLighting/VolumetricCloudsCombine.shader", ReloadAttribute.Package.Root)]
			public Shader volumetricCloudsCombinePS;

			// Token: 0x040026C5 RID: 9925
			[Reload("Runtime/Water/WaterSimulation.compute", ReloadAttribute.Package.Root)]
			public ComputeShader waterSimulationCS;

			// Token: 0x040026C6 RID: 9926
			[Reload("Runtime/Water/FourierTransform.compute", ReloadAttribute.Package.Root)]
			public ComputeShader fourierTransformCS;

			// Token: 0x040026C7 RID: 9927
			[Reload("Runtime/RenderPipelineResources/ShaderGraph/Water.shadergraph", ReloadAttribute.Package.Root)]
			public Shader waterPS;

			// Token: 0x040026C8 RID: 9928
			[Reload("Runtime/Water/WaterLighting.compute", ReloadAttribute.Package.Root)]
			public ComputeShader waterLightingCS;

			// Token: 0x040026C9 RID: 9929
			[Reload("Runtime/Water/WaterCaustics.shader", ReloadAttribute.Package.Root)]
			public Shader waterCausticsPS;

			// Token: 0x040026CA RID: 9930
			[Reload("Runtime/Material/PreIntegratedFGD/PreIntegratedFGD_GGXDisneyDiffuse.shader", ReloadAttribute.Package.Root)]
			public Shader preIntegratedFGD_GGXDisneyDiffusePS;

			// Token: 0x040026CB RID: 9931
			[Reload("Runtime/Material/PreIntegratedFGD/PreIntegratedFGD_CharlieFabricLambert.shader", ReloadAttribute.Package.Root)]
			public Shader preIntegratedFGD_CharlieFabricLambertPS;

			// Token: 0x040026CC RID: 9932
			[Reload("Runtime/Material/AxF/PreIntegratedFGD_Ward.shader", ReloadAttribute.Package.Root)]
			public Shader preIntegratedFGD_WardPS;

			// Token: 0x040026CD RID: 9933
			[Reload("Runtime/Material/AxF/PreIntegratedFGD_CookTorrance.shader", ReloadAttribute.Package.Root)]
			public Shader preIntegratedFGD_CookTorrancePS;

			// Token: 0x040026CE RID: 9934
			[Reload("Runtime/Material/PreIntegratedFGD/PreIntegratedFGD_Marschner.shader", ReloadAttribute.Package.Root)]
			public Shader preIntegratedFGD_MarschnerPS;

			// Token: 0x040026CF RID: 9935
			[Reload("Runtime/Material/Hair/MultipleScattering/HairMultipleScatteringPreIntegration.compute", ReloadAttribute.Package.Root)]
			public ComputeShader preIntegratedFiberScatteringCS;

			// Token: 0x040026D0 RID: 9936
			[Reload("Runtime/Material/VolumetricMaterial/VolumetricMaterial.compute", ReloadAttribute.Package.Root)]
			public ComputeShader volumetricMaterialCS;

			// Token: 0x040026D1 RID: 9937
			[Reload("Runtime/Core/CoreResources/EncodeBC6H.compute", ReloadAttribute.Package.Root)]
			public ComputeShader encodeBC6HCS;

			// Token: 0x040026D2 RID: 9938
			[Reload("Runtime/Core/CoreResources/CubeToPano.shader", ReloadAttribute.Package.Root)]
			public Shader cubeToPanoPS;

			// Token: 0x040026D3 RID: 9939
			[Reload("Runtime/Core/CoreResources/BlitCubeTextureFace.shader", ReloadAttribute.Package.Root)]
			public Shader blitCubeTextureFacePS;

			// Token: 0x040026D4 RID: 9940
			[Reload("Runtime/Material/LTCAreaLight/FilterAreaLightCookies.shader", ReloadAttribute.Package.Root)]
			public Shader filterAreaLightCookiesPS;

			// Token: 0x040026D5 RID: 9941
			[Reload("Runtime/Core/CoreResources/ClearUIntTextureArray.compute", ReloadAttribute.Package.Root)]
			public ComputeShader clearUIntTextureCS;

			// Token: 0x040026D6 RID: 9942
			[Reload("Runtime/RenderPipeline/RenderPass/CustomPass/CustomPassUtils.shader", ReloadAttribute.Package.Root)]
			public Shader customPassUtils;

			// Token: 0x040026D7 RID: 9943
			[Reload("Runtime/RenderPipeline/RenderPass/CustomPass/CustomPassRenderersUtils.shader", ReloadAttribute.Package.Root)]
			public Shader customPassRenderersUtils;

			// Token: 0x040026D8 RID: 9944
			[Reload("Runtime/RenderPipeline/Utility/Texture3DAtlas.compute", ReloadAttribute.Package.Root)]
			public ComputeShader texture3DAtlasCS;

			// Token: 0x040026D9 RID: 9945
			[Reload("Runtime/ShaderLibrary/XRMirrorView.shader", ReloadAttribute.Package.Root)]
			public Shader xrMirrorViewPS;

			// Token: 0x040026DA RID: 9946
			[Reload("Runtime/ShaderLibrary/XROcclusionMesh.shader", ReloadAttribute.Package.Root)]
			public Shader xrOcclusionMeshPS;

			// Token: 0x040026DB RID: 9947
			[Reload("Runtime/Lighting/Shadow/ShadowClear.shader", ReloadAttribute.Package.Root)]
			public Shader shadowClearPS;

			// Token: 0x040026DC RID: 9948
			[Reload("Runtime/Lighting/Shadow/EVSMBlur.compute", ReloadAttribute.Package.Root)]
			public ComputeShader evsmBlurCS;

			// Token: 0x040026DD RID: 9949
			[Reload("Runtime/Lighting/Shadow/DebugDisplayHDShadowMap.shader", ReloadAttribute.Package.Root)]
			public Shader debugHDShadowMapPS;

			// Token: 0x040026DE RID: 9950
			[Reload("Runtime/Lighting/Shadow/MomentShadows.compute", ReloadAttribute.Package.Root)]
			public ComputeShader momentShadowsCS;

			// Token: 0x040026DF RID: 9951
			[Reload("Runtime/Lighting/Shadow/ShadowBlit.shader", ReloadAttribute.Package.Root)]
			public Shader shadowBlitPS;

			// Token: 0x040026E0 RID: 9952
			[Reload("Runtime/Material/Decal/DecalNormalBuffer.shader", ReloadAttribute.Package.Root)]
			public Shader decalNormalBufferPS;

			// Token: 0x040026E1 RID: 9953
			[Reload("Runtime/Lighting/ScreenSpaceLighting/GTAO.compute", ReloadAttribute.Package.Root)]
			public ComputeShader GTAOCS;

			// Token: 0x040026E2 RID: 9954
			[Reload("Runtime/Lighting/ScreenSpaceLighting/GTAOSpatialDenoise.compute", ReloadAttribute.Package.Root)]
			public ComputeShader GTAOSpatialDenoiseCS;

			// Token: 0x040026E3 RID: 9955
			[Reload("Runtime/Lighting/ScreenSpaceLighting/GTAOTemporalDenoise.compute", ReloadAttribute.Package.Root)]
			public ComputeShader GTAOTemporalDenoiseCS;

			// Token: 0x040026E4 RID: 9956
			[Reload("Runtime/Lighting/ScreenSpaceLighting/GTAOCopyHistory.compute", ReloadAttribute.Package.Root)]
			public ComputeShader GTAOCopyHistoryCS;

			// Token: 0x040026E5 RID: 9957
			[Reload("Runtime/Lighting/ScreenSpaceLighting/GTAOBlurAndUpsample.compute", ReloadAttribute.Package.Root)]
			public ComputeShader GTAOBlurAndUpsample;

			// Token: 0x040026E6 RID: 9958
			[Reload("Runtime/Lighting/ScreenSpaceLighting/ScreenSpaceGlobalIllumination.compute", ReloadAttribute.Package.Root)]
			public ComputeShader screenSpaceGlobalIlluminationCS;

			// Token: 0x040026E7 RID: 9959
			[Reload("Runtime/RenderPipeline/RenderPass/MSAA/DepthValues.shader", ReloadAttribute.Package.Root)]
			public Shader depthValuesPS;

			// Token: 0x040026E8 RID: 9960
			[Reload("Runtime/RenderPipeline/RenderPass/MSAA/ColorResolve.shader", ReloadAttribute.Package.Root)]
			public Shader colorResolvePS;

			// Token: 0x040026E9 RID: 9961
			[Reload("Runtime/RenderPipeline/RenderPass/MSAA/MotionVecResolve.shader", ReloadAttribute.Package.Root)]
			public Shader resolveMotionVecPS;

			// Token: 0x040026EA RID: 9962
			[Reload("Runtime/PostProcessing/Shaders/AlphaCopy.compute", ReloadAttribute.Package.Root)]
			public ComputeShader copyAlphaCS;

			// Token: 0x040026EB RID: 9963
			[Reload("Runtime/PostProcessing/Shaders/NaNKiller.compute", ReloadAttribute.Package.Root)]
			public ComputeShader nanKillerCS;

			// Token: 0x040026EC RID: 9964
			[Reload("Runtime/PostProcessing/Shaders/Exposure.compute", ReloadAttribute.Package.Root)]
			public ComputeShader exposureCS;

			// Token: 0x040026ED RID: 9965
			[Reload("Runtime/PostProcessing/Shaders/HistogramExposure.compute", ReloadAttribute.Package.Root)]
			public ComputeShader histogramExposureCS;

			// Token: 0x040026EE RID: 9966
			[Reload("Runtime/PostProcessing/Shaders/ApplyExposure.compute", ReloadAttribute.Package.Root)]
			public ComputeShader applyExposureCS;

			// Token: 0x040026EF RID: 9967
			[Reload("Runtime/PostProcessing/Shaders/DebugHistogramImage.compute", ReloadAttribute.Package.Root)]
			public ComputeShader debugImageHistogramCS;

			// Token: 0x040026F0 RID: 9968
			[Reload("Runtime/PostProcessing/Shaders/DebugHDRxyMapping.compute", ReloadAttribute.Package.Root)]
			public ComputeShader debugHDRxyMappingCS;

			// Token: 0x040026F1 RID: 9969
			[Reload("Runtime/PostProcessing/Shaders/UberPost.compute", ReloadAttribute.Package.Root)]
			public ComputeShader uberPostCS;

			// Token: 0x040026F2 RID: 9970
			[Reload("Runtime/PostProcessing/Shaders/LutBuilder3D.compute", ReloadAttribute.Package.Root)]
			public ComputeShader lutBuilder3DCS;

			// Token: 0x040026F3 RID: 9971
			[Reload("Runtime/PostProcessing/Shaders/DepthOfFieldKernel.compute", ReloadAttribute.Package.Root)]
			public ComputeShader depthOfFieldKernelCS;

			// Token: 0x040026F4 RID: 9972
			[Reload("Runtime/PostProcessing/Shaders/DepthOfFieldCoC.compute", ReloadAttribute.Package.Root)]
			public ComputeShader depthOfFieldCoCCS;

			// Token: 0x040026F5 RID: 9973
			[Reload("Runtime/PostProcessing/Shaders/DepthOfFieldCoCReproject.compute", ReloadAttribute.Package.Root)]
			public ComputeShader depthOfFieldCoCReprojectCS;

			// Token: 0x040026F6 RID: 9974
			[Reload("Runtime/PostProcessing/Shaders/DepthOfFieldCoCDilate.compute", ReloadAttribute.Package.Root)]
			public ComputeShader depthOfFieldDilateCS;

			// Token: 0x040026F7 RID: 9975
			[Reload("Runtime/PostProcessing/Shaders/DepthOfFieldMip.compute", ReloadAttribute.Package.Root)]
			public ComputeShader depthOfFieldMipCS;

			// Token: 0x040026F8 RID: 9976
			[Reload("Runtime/PostProcessing/Shaders/DepthOfFieldMipSafe.compute", ReloadAttribute.Package.Root)]
			public ComputeShader depthOfFieldMipSafeCS;

			// Token: 0x040026F9 RID: 9977
			[Reload("Runtime/PostProcessing/Shaders/DepthOfFieldPrefilter.compute", ReloadAttribute.Package.Root)]
			public ComputeShader depthOfFieldPrefilterCS;

			// Token: 0x040026FA RID: 9978
			[Reload("Runtime/PostProcessing/Shaders/DepthOfFieldTileMax.compute", ReloadAttribute.Package.Root)]
			public ComputeShader depthOfFieldTileMaxCS;

			// Token: 0x040026FB RID: 9979
			[Reload("Runtime/PostProcessing/Shaders/DepthOfFieldGather.compute", ReloadAttribute.Package.Root)]
			public ComputeShader depthOfFieldGatherCS;

			// Token: 0x040026FC RID: 9980
			[Reload("Runtime/PostProcessing/Shaders/DepthOfFieldCombine.compute", ReloadAttribute.Package.Root)]
			public ComputeShader depthOfFieldCombineCS;

			// Token: 0x040026FD RID: 9981
			[Reload("Runtime/PostProcessing/Shaders/DepthOfFieldPreCombineFar.compute", ReloadAttribute.Package.Root)]
			public ComputeShader depthOfFieldPreCombineFarCS;

			// Token: 0x040026FE RID: 9982
			[Reload("Runtime/PostProcessing/Shaders/DepthOfFieldClearIndirectArgs.compute", ReloadAttribute.Package.Root)]
			public ComputeShader depthOfFieldClearIndirectArgsCS;

			// Token: 0x040026FF RID: 9983
			[Reload("Runtime/PostProcessing/Shaders/PaniniProjection.compute", ReloadAttribute.Package.Root)]
			public ComputeShader paniniProjectionCS;

			// Token: 0x04002700 RID: 9984
			[Reload("Runtime/PostProcessing/Shaders/MotionBlurMotionVecPrep.compute", ReloadAttribute.Package.Root)]
			public ComputeShader motionBlurMotionVecPrepCS;

			// Token: 0x04002701 RID: 9985
			[Reload("Runtime/PostProcessing/Shaders/MotionBlurGenTilePass.compute", ReloadAttribute.Package.Root)]
			public ComputeShader motionBlurGenTileCS;

			// Token: 0x04002702 RID: 9986
			[Reload("Runtime/PostProcessing/Shaders/MotionBlurMergeTilePass.compute", ReloadAttribute.Package.Root)]
			public ComputeShader motionBlurMergeTileCS;

			// Token: 0x04002703 RID: 9987
			[Reload("Runtime/PostProcessing/Shaders/MotionBlurNeighborhoodTilePass.compute", ReloadAttribute.Package.Root)]
			public ComputeShader motionBlurNeighborhoodTileCS;

			// Token: 0x04002704 RID: 9988
			[Reload("Runtime/PostProcessing/Shaders/MotionBlur.compute", ReloadAttribute.Package.Root)]
			public ComputeShader motionBlurCS;

			// Token: 0x04002705 RID: 9989
			[Reload("Runtime/PostProcessing/Shaders/BloomPrefilter.compute", ReloadAttribute.Package.Root)]
			public ComputeShader bloomPrefilterCS;

			// Token: 0x04002706 RID: 9990
			[Reload("Runtime/PostProcessing/Shaders/BloomBlur.compute", ReloadAttribute.Package.Root)]
			public ComputeShader bloomBlurCS;

			// Token: 0x04002707 RID: 9991
			[Reload("Runtime/PostProcessing/Shaders/BloomUpsample.compute", ReloadAttribute.Package.Root)]
			public ComputeShader bloomUpsampleCS;

			// Token: 0x04002708 RID: 9992
			[Reload("Runtime/PostProcessing/Shaders/FXAA.compute", ReloadAttribute.Package.Root)]
			public ComputeShader FXAACS;

			// Token: 0x04002709 RID: 9993
			[Reload("Runtime/PostProcessing/Shaders/FinalPass.shader", ReloadAttribute.Package.Root)]
			public Shader finalPassPS;

			// Token: 0x0400270A RID: 9994
			[Reload("Runtime/PostProcessing/Shaders/ClearBlack.shader", ReloadAttribute.Package.Root)]
			public Shader clearBlackPS;

			// Token: 0x0400270B RID: 9995
			[Reload("Runtime/PostProcessing/Shaders/SubpixelMorphologicalAntialiasing.shader", ReloadAttribute.Package.Root)]
			public Shader SMAAPS;

			// Token: 0x0400270C RID: 9996
			[Reload("Runtime/PostProcessing/Shaders/TemporalAntialiasing.shader", ReloadAttribute.Package.Root)]
			public Shader temporalAntialiasingPS;

			// Token: 0x0400270D RID: 9997
			[Reload("Runtime/PostProcessing/Shaders/LensFlareDataDriven.shader", ReloadAttribute.Package.Root)]
			public Shader lensFlareDataDrivenPS;

			// Token: 0x0400270E RID: 9998
			[Reload("Runtime/PostProcessing/Shaders/LensFlareMergeOcclusionDataDriven.compute", ReloadAttribute.Package.Root)]
			public ComputeShader lensFlareMergeOcclusionCS;

			// Token: 0x0400270F RID: 9999
			[Reload("Runtime/PostProcessing/Shaders/DLSSBiasColorMask.shader", ReloadAttribute.Package.Root)]
			public Shader DLSSBiasColorMaskPS;

			// Token: 0x04002710 RID: 10000
			[Reload("Runtime/PostProcessing/Shaders/CompositeWithUIAndOETF.shader", ReloadAttribute.Package.Root)]
			public Shader compositeUIAndOETFApplyPS;

			// Token: 0x04002711 RID: 10001
			[Reload("Runtime/PostProcessing/Shaders/DoFCircleOfConfusion.compute", ReloadAttribute.Package.Root)]
			public ComputeShader dofCircleOfConfusion;

			// Token: 0x04002712 RID: 10002
			[Reload("Runtime/PostProcessing/Shaders/DoFGather.compute", ReloadAttribute.Package.Root)]
			public ComputeShader dofGatherCS;

			// Token: 0x04002713 RID: 10003
			[Reload("Runtime/PostProcessing/Shaders/DoFCoCMinMax.compute", ReloadAttribute.Package.Root)]
			public ComputeShader dofCoCMinMaxCS;

			// Token: 0x04002714 RID: 10004
			[Reload("Runtime/PostProcessing/Shaders/DoFMinMaxDilate.compute", ReloadAttribute.Package.Root)]
			public ComputeShader dofMinMaxDilateCS;

			// Token: 0x04002715 RID: 10005
			[Reload("Runtime/PostProcessing/Shaders/DoFCombine.compute", ReloadAttribute.Package.Root)]
			public ComputeShader dofCombineCS;

			// Token: 0x04002716 RID: 10006
			[Reload("Runtime/PostProcessing/Shaders/ContrastAdaptiveSharpen.compute", ReloadAttribute.Package.Root)]
			public ComputeShader contrastAdaptiveSharpenCS;

			// Token: 0x04002717 RID: 10007
			[Reload("Runtime/PostProcessing/Shaders/EdgeAdaptiveSpatialUpsampling.compute", ReloadAttribute.Package.Root)]
			public ComputeShader edgeAdaptiveSpatialUpsamplingCS;

			// Token: 0x04002718 RID: 10008
			[Reload("Runtime/VirtualTexturing/Shaders/DownsampleVTFeedback.compute", ReloadAttribute.Package.Root)]
			public ComputeShader VTFeedbackDownsample;

			// Token: 0x04002719 RID: 10009
			[Reload("Runtime/RenderPipeline/Accumulation/Shaders/Accumulation.compute", ReloadAttribute.Package.Root)]
			public ComputeShader accumulationCS;

			// Token: 0x0400271A RID: 10010
			[Reload("Runtime/RenderPipeline/Accumulation/Shaders/BlitAndExpose.compute", ReloadAttribute.Package.Root)]
			public ComputeShader blitAndExposeCS;

			// Token: 0x0400271B RID: 10011
			[Reload("Runtime/Compositor/Shaders/AlphaInjection.shader", ReloadAttribute.Package.Root)]
			public Shader alphaInjectionPS;

			// Token: 0x0400271C RID: 10012
			[Reload("Runtime/Compositor/Shaders/ChromaKeying.shader", ReloadAttribute.Package.Root)]
			public Shader chromaKeyingPS;

			// Token: 0x0400271D RID: 10013
			[Reload("Runtime/Compositor/Shaders/CustomClear.shader", ReloadAttribute.Package.Root)]
			public Shader customClearPS;

			// Token: 0x0400271E RID: 10014
			[Reload("Runtime/Lighting/ScreenSpaceLighting/BilateralUpsample.compute", ReloadAttribute.Package.Root)]
			public ComputeShader bilateralUpsampleCS;

			// Token: 0x0400271F RID: 10015
			[Reload("Runtime/RenderPipeline/Raytracing/Shaders/Denoising/TemporalFilter.compute", ReloadAttribute.Package.Root)]
			public ComputeShader temporalFilterCS;

			// Token: 0x04002720 RID: 10016
			[Reload("Runtime/RenderPipeline/Raytracing/Shaders/Denoising/DiffuseDenoiser.compute", ReloadAttribute.Package.Root)]
			public ComputeShader diffuseDenoiserCS;
		}

		// Token: 0x020003C1 RID: 961
		[ReloadGroup]
		[Serializable]
		public sealed class MaterialResources
		{
			// Token: 0x04002721 RID: 10017
			[Reload("Runtime/RenderPipelineResources/Material/AreaLightCookieViewer.mat", ReloadAttribute.Package.Root)]
			public Material areaLightCookieMaterial;
		}

		// Token: 0x020003C2 RID: 962
		[ReloadGroup]
		[Serializable]
		public sealed class TextureResources
		{
			// Token: 0x04002722 RID: 10018
			[Reload("Runtime/RenderPipelineResources/Texture/DebugFont.tga", ReloadAttribute.Package.Root)]
			public Texture2D debugFontTex;

			// Token: 0x04002723 RID: 10019
			[Reload("Runtime/Debug/ColorGradient.png", ReloadAttribute.Package.Root)]
			public Texture2D colorGradient;

			// Token: 0x04002724 RID: 10020
			[Reload("Runtime/RenderPipelineResources/Texture/Matcap/DefaultMatcap.png", ReloadAttribute.Package.Root)]
			public Texture2D matcapTex;

			// Token: 0x04002725 RID: 10021
			[Reload("Runtime/RenderPipelineResources/Texture/BlueNoise16/L/LDR_LLL1_{0}.png", 0, 32, ReloadAttribute.Package.Root)]
			public Texture2D[] blueNoise16LTex;

			// Token: 0x04002726 RID: 10022
			[Reload("Runtime/RenderPipelineResources/Texture/BlueNoise16/RGB/LDR_RGB1_{0}.png", 0, 32, ReloadAttribute.Package.Root)]
			public Texture2D[] blueNoise16RGBTex;

			// Token: 0x04002727 RID: 10023
			[Reload("Runtime/RenderPipelineResources/Texture/CoherentNoise/OwenScrambledNoise4.png", ReloadAttribute.Package.Root)]
			public Texture2D owenScrambledRGBATex;

			// Token: 0x04002728 RID: 10024
			[Reload("Runtime/RenderPipelineResources/Texture/CoherentNoise/OwenScrambledNoise256.png", ReloadAttribute.Package.Root)]
			public Texture2D owenScrambled256Tex;

			// Token: 0x04002729 RID: 10025
			[Reload("Runtime/RenderPipelineResources/Texture/CoherentNoise/ScrambleNoise.png", ReloadAttribute.Package.Root)]
			public Texture2D scramblingTex;

			// Token: 0x0400272A RID: 10026
			[Reload("Runtime/RenderPipelineResources/Texture/CoherentNoise/RankingTile1SPP.png", ReloadAttribute.Package.Root)]
			public Texture2D rankingTile1SPP;

			// Token: 0x0400272B RID: 10027
			[Reload("Runtime/RenderPipelineResources/Texture/CoherentNoise/ScramblingTile1SPP.png", ReloadAttribute.Package.Root)]
			public Texture2D scramblingTile1SPP;

			// Token: 0x0400272C RID: 10028
			[Reload("Runtime/RenderPipelineResources/Texture/CoherentNoise/RankingTile8SPP.png", ReloadAttribute.Package.Root)]
			public Texture2D rankingTile8SPP;

			// Token: 0x0400272D RID: 10029
			[Reload("Runtime/RenderPipelineResources/Texture/CoherentNoise/ScramblingTile8SPP.png", ReloadAttribute.Package.Root)]
			public Texture2D scramblingTile8SPP;

			// Token: 0x0400272E RID: 10030
			[Reload("Runtime/RenderPipelineResources/Texture/CoherentNoise/RankingTile256SPP.png", ReloadAttribute.Package.Root)]
			public Texture2D rankingTile256SPP;

			// Token: 0x0400272F RID: 10031
			[Reload("Runtime/RenderPipelineResources/Texture/CoherentNoise/ScramblingTile256SPP.png", ReloadAttribute.Package.Root)]
			public Texture2D scramblingTile256SPP;

			// Token: 0x04002730 RID: 10032
			[Reload("Runtime/RenderPipelineResources/Texture/EyeCausticLUT16R.exr", ReloadAttribute.Package.Root)]
			public Texture3D eyeCausticLUT;

			// Token: 0x04002731 RID: 10033
			[Reload("Runtime/RenderPipelineResources/Texture/VolumetricClouds/CloudLutRainAO.png", ReloadAttribute.Package.Root)]
			public Texture2D cloudLutRainAO;

			// Token: 0x04002732 RID: 10034
			[Reload("Runtime/RenderPipelineResources/Texture/VolumetricClouds/WorleyNoise128RGBA.png", ReloadAttribute.Package.Root)]
			public Texture3D worleyNoise128RGBA;

			// Token: 0x04002733 RID: 10035
			[Reload("Runtime/RenderPipelineResources/Texture/VolumetricClouds/WorleyNoise32RGB.png", ReloadAttribute.Package.Root)]
			public Texture3D worleyNoise32RGB;

			// Token: 0x04002734 RID: 10036
			[Reload("Runtime/RenderPipelineResources/Texture/VolumetricClouds/PerlinNoise32RGB.png", ReloadAttribute.Package.Root)]
			public Texture3D perlinNoise32RGB;

			// Token: 0x04002735 RID: 10037
			[Reload("Runtime/RenderPipelineResources/Texture/Water/FoamSurface.png", ReloadAttribute.Package.Root)]
			public Texture2D foamSurface;

			// Token: 0x04002736 RID: 10038
			[Reload(new string[]
			{
				"Runtime/RenderPipelineResources/Texture/FilmGrain/Thin01.png",
				"Runtime/RenderPipelineResources/Texture/FilmGrain/Thin02.png",
				"Runtime/RenderPipelineResources/Texture/FilmGrain/Medium01.png",
				"Runtime/RenderPipelineResources/Texture/FilmGrain/Medium02.png",
				"Runtime/RenderPipelineResources/Texture/FilmGrain/Medium03.png",
				"Runtime/RenderPipelineResources/Texture/FilmGrain/Medium04.png",
				"Runtime/RenderPipelineResources/Texture/FilmGrain/Medium05.png",
				"Runtime/RenderPipelineResources/Texture/FilmGrain/Medium06.png",
				"Runtime/RenderPipelineResources/Texture/FilmGrain/Large01.png",
				"Runtime/RenderPipelineResources/Texture/FilmGrain/Large02.png"
			}, ReloadAttribute.Package.Root)]
			public Texture2D[] filmGrainTex;

			// Token: 0x04002737 RID: 10039
			[Reload("Runtime/RenderPipelineResources/Texture/SMAA/SearchTex.tga", ReloadAttribute.Package.Root)]
			public Texture2D SMAASearchTex;

			// Token: 0x04002738 RID: 10040
			[Reload("Runtime/RenderPipelineResources/Texture/SMAA/AreaTex.tga", ReloadAttribute.Package.Root)]
			public Texture2D SMAAAreaTex;

			// Token: 0x04002739 RID: 10041
			[Reload("Runtime/RenderPipelineResources/Texture/DefaultHDRISky.exr", ReloadAttribute.Package.Root)]
			public Cubemap defaultHDRISky;

			// Token: 0x0400273A RID: 10042
			[Reload("Runtime/RenderPipelineResources/Texture/DefaultCloudMap.png", ReloadAttribute.Package.Root)]
			public Texture2D defaultCloudMap;
		}

		// Token: 0x020003C3 RID: 963
		[ReloadGroup]
		[Serializable]
		public sealed class ShaderGraphResources
		{
			// Token: 0x0400273B RID: 10043
			[Reload("Runtime/ShaderLibrary/SolidColor.shadergraph", ReloadAttribute.Package.Root)]
			public Shader objectIDPS;

			// Token: 0x0400273C RID: 10044
			[Reload("Runtime/RenderPipelineResources/ShaderGraph/DefaultFogVolume.shadergraph", ReloadAttribute.Package.Root)]
			public Shader defaultFogVolumeShader;
		}

		// Token: 0x020003C4 RID: 964
		[ReloadGroup]
		[Serializable]
		public sealed class AssetResources
		{
			// Token: 0x0400273D RID: 10045
			[Reload("Runtime/RenderPipelineResources/defaultDiffusionProfile.asset", ReloadAttribute.Package.Root)]
			public DiffusionProfileSettings defaultDiffusionProfile;

			// Token: 0x0400273E RID: 10046
			[Reload("Runtime/RenderPipelineResources/Mesh/Cylinder.fbx", ReloadAttribute.Package.Root)]
			public Mesh emissiveCylinderMesh;

			// Token: 0x0400273F RID: 10047
			[Reload("Runtime/RenderPipelineResources/Mesh/Quad.fbx", ReloadAttribute.Package.Root)]
			public Mesh emissiveQuadMesh;

			// Token: 0x04002740 RID: 10048
			[Reload("Runtime/RenderPipelineResources/Mesh/Sphere.fbx", ReloadAttribute.Package.Root)]
			public Mesh sphereMesh;

			// Token: 0x04002741 RID: 10049
			[Reload("Runtime/RenderPipelineResources/Mesh/ProbeDebugSphere.fbx", ReloadAttribute.Package.Root)]
			public Mesh probeDebugSphere;

			// Token: 0x04002742 RID: 10050
			[Reload("Runtime/RenderPipelineResources/Mesh/ProbeDebugPyramid.fbx", ReloadAttribute.Package.Root)]
			public Mesh pyramidMesh;
		}

		// Token: 0x020003C5 RID: 965
		private enum Version
		{
			// Token: 0x04002744 RID: 10052
			None,
			// Token: 0x04002745 RID: 10053
			First,
			// Token: 0x04002746 RID: 10054
			RemovedEditorOnlyResources = 4
		}
	}
}
