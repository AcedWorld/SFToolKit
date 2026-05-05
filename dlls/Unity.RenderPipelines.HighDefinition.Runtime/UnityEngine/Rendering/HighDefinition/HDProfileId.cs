using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200015F RID: 351
	internal enum HDProfileId
	{
		// Token: 0x04000D2F RID: 3375
		CopyDepthBuffer,
		// Token: 0x04000D30 RID: 3376
		CopyDepthInTargetTexture,
		// Token: 0x04000D31 RID: 3377
		BuildCoarseStencilAndResolveIfNeeded,
		// Token: 0x04000D32 RID: 3378
		AmbientOcclusion,
		// Token: 0x04000D33 RID: 3379
		HorizonSSAO,
		// Token: 0x04000D34 RID: 3380
		UpSampleSSAO,
		// Token: 0x04000D35 RID: 3381
		ScreenSpaceShadows,
		// Token: 0x04000D36 RID: 3382
		ScreenSpaceShadowsDebug,
		// Token: 0x04000D37 RID: 3383
		BuildLightList,
		// Token: 0x04000D38 RID: 3384
		GenerateLightAABBs,
		// Token: 0x04000D39 RID: 3385
		Distortion,
		// Token: 0x04000D3A RID: 3386
		AccumulateDistortion,
		// Token: 0x04000D3B RID: 3387
		ApplyDistortion,
		// Token: 0x04000D3C RID: 3388
		ForwardDepthPrepass,
		// Token: 0x04000D3D RID: 3389
		DeferredDepthPrepass,
		// Token: 0x04000D3E RID: 3390
		TransparentDepthPrepass,
		// Token: 0x04000D3F RID: 3391
		GBuffer,
		// Token: 0x04000D40 RID: 3392
		DBufferRender,
		// Token: 0x04000D41 RID: 3393
		DBufferPrepareDrawData,
		// Token: 0x04000D42 RID: 3394
		DBufferNormal,
		// Token: 0x04000D43 RID: 3395
		DisplayDebugDecalsAtlas,
		// Token: 0x04000D44 RID: 3396
		DisplayDebugViewMaterial,
		// Token: 0x04000D45 RID: 3397
		DebugViewMaterialGBuffer,
		// Token: 0x04000D46 RID: 3398
		SubsurfaceScattering,
		// Token: 0x04000D47 RID: 3399
		SsrTracing,
		// Token: 0x04000D48 RID: 3400
		SsrReprojection,
		// Token: 0x04000D49 RID: 3401
		SsrAccumulate,
		// Token: 0x04000D4A RID: 3402
		SSGIPass,
		// Token: 0x04000D4B RID: 3403
		SSGITrace,
		// Token: 0x04000D4C RID: 3404
		SSGIDenoise,
		// Token: 0x04000D4D RID: 3405
		SSGIUpscale,
		// Token: 0x04000D4E RID: 3406
		SSGIConvert,
		// Token: 0x04000D4F RID: 3407
		ForwardOpaque,
		// Token: 0x04000D50 RID: 3408
		ForwardOpaqueDebug,
		// Token: 0x04000D51 RID: 3409
		ForwardTransparent,
		// Token: 0x04000D52 RID: 3410
		ForwardTransparentDebug,
		// Token: 0x04000D53 RID: 3411
		ForwardPreRefraction,
		// Token: 0x04000D54 RID: 3412
		ForwardPreRefractionDebug,
		// Token: 0x04000D55 RID: 3413
		ForwardTransparentDepthPrepass,
		// Token: 0x04000D56 RID: 3414
		RenderForwardError,
		// Token: 0x04000D57 RID: 3415
		TransparentDepthPostpass,
		// Token: 0x04000D58 RID: 3416
		ObjectsMotionVector,
		// Token: 0x04000D59 RID: 3417
		CameraMotionVectors,
		// Token: 0x04000D5A RID: 3418
		ColorPyramid,
		// Token: 0x04000D5B RID: 3419
		DepthPyramid,
		// Token: 0x04000D5C RID: 3420
		PostProcessing,
		// Token: 0x04000D5D RID: 3421
		AfterPostProcessingObjects,
		// Token: 0x04000D5E RID: 3422
		RenderFullScreenDebug,
		// Token: 0x04000D5F RID: 3423
		ClearBuffers,
		// Token: 0x04000D60 RID: 3424
		ClearStencil,
		// Token: 0x04000D61 RID: 3425
		HDRenderPipelineRenderCamera,
		// Token: 0x04000D62 RID: 3426
		HDRenderPipelineRenderAOV,
		// Token: 0x04000D63 RID: 3427
		HDRenderPipelineAllRenderRequest,
		// Token: 0x04000D64 RID: 3428
		CullResultsCull,
		// Token: 0x04000D65 RID: 3429
		CustomPassCullResultsCull,
		// Token: 0x04000D66 RID: 3430
		DisplayCookieAtlas,
		// Token: 0x04000D67 RID: 3431
		RenderWireFrame,
		// Token: 0x04000D68 RID: 3432
		ConvolveReflectionProbe,
		// Token: 0x04000D69 RID: 3433
		ConvertReflectionProbe,
		// Token: 0x04000D6A RID: 3434
		ConvolvePlanarReflectionProbe,
		// Token: 0x04000D6B RID: 3435
		UpdateReflectionProbeAtlas,
		// Token: 0x04000D6C RID: 3436
		BlitTextureToReflectionProbeAtlas,
		// Token: 0x04000D6D RID: 3437
		DisplayReflectionProbeAtlas,
		// Token: 0x04000D6E RID: 3438
		PreIntegradeWardCookTorrance,
		// Token: 0x04000D6F RID: 3439
		FilterCubemapCharlie,
		// Token: 0x04000D70 RID: 3440
		FilterCubemapGGX,
		// Token: 0x04000D71 RID: 3441
		AreaLightCookieConvolution,
		// Token: 0x04000D72 RID: 3442
		UpdateSkyEnvironmentConvolution,
		// Token: 0x04000D73 RID: 3443
		BackgroundCloudsAmbientProbe,
		// Token: 0x04000D74 RID: 3444
		RenderSkyToCubemap,
		// Token: 0x04000D75 RID: 3445
		UpdateSkyAmbientProbe,
		// Token: 0x04000D76 RID: 3446
		PreRenderSky,
		// Token: 0x04000D77 RID: 3447
		RenderSky,
		// Token: 0x04000D78 RID: 3448
		RenderClouds,
		// Token: 0x04000D79 RID: 3449
		OpaqueAtmosphericScattering,
		// Token: 0x04000D7A RID: 3450
		InScatteredRadiancePrecomputation,
		// Token: 0x04000D7B RID: 3451
		VolumeVoxelization,
		// Token: 0x04000D7C RID: 3452
		VolumetricLighting,
		// Token: 0x04000D7D RID: 3453
		VolumetricLightingFiltering,
		// Token: 0x04000D7E RID: 3454
		PrepareVisibleLocalVolumetricFogList,
		// Token: 0x04000D7F RID: 3455
		UpdateLocalVolumetricFogAtlas,
		// Token: 0x04000D80 RID: 3456
		VolumetricClouds,
		// Token: 0x04000D81 RID: 3457
		VolumetricCloudsDepthDownscale,
		// Token: 0x04000D82 RID: 3458
		VolumetricCloudsTrace,
		// Token: 0x04000D83 RID: 3459
		VolumetricCloudsReproject,
		// Token: 0x04000D84 RID: 3460
		VolumetricCloudsPreUpscale,
		// Token: 0x04000D85 RID: 3461
		VolumetricCloudsUpscaleAndCombine,
		// Token: 0x04000D86 RID: 3462
		VolumetricCloudsShadow,
		// Token: 0x04000D87 RID: 3463
		VolumetricCloudMapGeneration,
		// Token: 0x04000D88 RID: 3464
		VolumetricCloudsAmbientProbe,
		// Token: 0x04000D89 RID: 3465
		WaterSurfaceSimulation,
		// Token: 0x04000D8A RID: 3466
		WaterSurfaceRenderingGBuffer,
		// Token: 0x04000D8B RID: 3467
		WaterSurfaceRenderingSSR,
		// Token: 0x04000D8C RID: 3468
		WaterSurfaceRenderingDeferred,
		// Token: 0x04000D8D RID: 3469
		WaterSurfaceRenderingUnderWater,
		// Token: 0x04000D8E RID: 3470
		RaytracingBuildCluster,
		// Token: 0x04000D8F RID: 3471
		RaytracingCullLights,
		// Token: 0x04000D90 RID: 3472
		RaytracingDebugCluster,
		// Token: 0x04000D91 RID: 3473
		RaytracingBuildAccelerationStructure,
		// Token: 0x04000D92 RID: 3474
		RaytracingBuildAccelerationStructureDebug,
		// Token: 0x04000D93 RID: 3475
		RaytracingReflectionDirectionGeneration,
		// Token: 0x04000D94 RID: 3476
		RaytracingReflectionEvaluation,
		// Token: 0x04000D95 RID: 3477
		RaytracingReflectionAdjustWeight,
		// Token: 0x04000D96 RID: 3478
		RaytracingReflectionFilter,
		// Token: 0x04000D97 RID: 3479
		RaytracingReflectionUpscale,
		// Token: 0x04000D98 RID: 3480
		RaytracingAmbientOcclusion,
		// Token: 0x04000D99 RID: 3481
		RaytracingFilterAmbientOcclusion,
		// Token: 0x04000D9A RID: 3482
		RaytracingComposeAmbientOcclusion,
		// Token: 0x04000D9B RID: 3483
		RaytracingClearHistoryAmbientOcclusion,
		// Token: 0x04000D9C RID: 3484
		RaytracingDirectionalLightShadow,
		// Token: 0x04000D9D RID: 3485
		RaytracingLightShadow,
		// Token: 0x04000D9E RID: 3486
		RaytracingAreaLightShadow,
		// Token: 0x04000D9F RID: 3487
		RaytracingIndirectDiffuseDirectionGeneration,
		// Token: 0x04000DA0 RID: 3488
		RaytracingIndirectDiffuseEvaluation,
		// Token: 0x04000DA1 RID: 3489
		RaytracingIndirectDiffuseUpscale,
		// Token: 0x04000DA2 RID: 3490
		RaytracingFilterIndirectDiffuse,
		// Token: 0x04000DA3 RID: 3491
		RaytracingIndirectDiffuseAdjustWeight,
		// Token: 0x04000DA4 RID: 3492
		RaytracingSSS,
		// Token: 0x04000DA5 RID: 3493
		RaytracingSSSTrace,
		// Token: 0x04000DA6 RID: 3494
		RaytracingSSSCompose,
		// Token: 0x04000DA7 RID: 3495
		RaytracingWriteShadow,
		// Token: 0x04000DA8 RID: 3496
		RaytracingDebugOverlay,
		// Token: 0x04000DA9 RID: 3497
		RayTracingRecursiveRendering,
		// Token: 0x04000DAA RID: 3498
		RayTracingDepthPrepass,
		// Token: 0x04000DAB RID: 3499
		RayTracingFlagMask,
		// Token: 0x04000DAC RID: 3500
		RaytracingDeferredLighting,
		// Token: 0x04000DAD RID: 3501
		HistoryValidity,
		// Token: 0x04000DAE RID: 3502
		TemporalFilter,
		// Token: 0x04000DAF RID: 3503
		DiffuseFilter,
		// Token: 0x04000DB0 RID: 3504
		UpdateGlobalConstantBuffers,
		// Token: 0x04000DB1 RID: 3505
		UpdateEnvironment,
		// Token: 0x04000DB2 RID: 3506
		ConfigureKeywords,
		// Token: 0x04000DB3 RID: 3507
		RecordRenderGraph,
		// Token: 0x04000DB4 RID: 3508
		PrepareLightsForGPU,
		// Token: 0x04000DB5 RID: 3509
		PrepareGPULightdata,
		// Token: 0x04000DB6 RID: 3510
		PrepareGPUProbeData,
		// Token: 0x04000DB7 RID: 3511
		ConvertLightsGpuFormat,
		// Token: 0x04000DB8 RID: 3512
		ProcessVisibleLights,
		// Token: 0x04000DB9 RID: 3513
		ProcessDirectionalAndCookies,
		// Token: 0x04000DBA RID: 3514
		SortVisibleLights,
		// Token: 0x04000DBB RID: 3515
		BuildVisibleLightEntities,
		// Token: 0x04000DBC RID: 3516
		ProcessShadows,
		// Token: 0x04000DBD RID: 3517
		RenderShadowMaps,
		// Token: 0x04000DBE RID: 3518
		RenderMomentShadowMaps,
		// Token: 0x04000DBF RID: 3519
		RenderEVSMShadowMaps,
		// Token: 0x04000DC0 RID: 3520
		RenderEVSMShadowMapsBlur,
		// Token: 0x04000DC1 RID: 3521
		RenderEVSMShadowMapsCopyToAtlas,
		// Token: 0x04000DC2 RID: 3522
		BlitDirectionalMixedCachedShadowMaps,
		// Token: 0x04000DC3 RID: 3523
		BlitPunctualMixedCachedShadowMaps,
		// Token: 0x04000DC4 RID: 3524
		BlitAreaMixedCachedShadowMaps,
		// Token: 0x04000DC5 RID: 3525
		TileClusterLightingDebug,
		// Token: 0x04000DC6 RID: 3526
		DisplayShadows,
		// Token: 0x04000DC7 RID: 3527
		RenderDeferredLightingCompute,
		// Token: 0x04000DC8 RID: 3528
		RenderDeferredLightingComputeAsPixel,
		// Token: 0x04000DC9 RID: 3529
		RenderDeferredLightingSinglePass,
		// Token: 0x04000DCA RID: 3530
		RenderDeferredLightingSinglePassMRT,
		// Token: 0x04000DCB RID: 3531
		VolumeUpdate,
		// Token: 0x04000DCC RID: 3532
		CustomPassVolumeUpdate,
		// Token: 0x04000DCD RID: 3533
		OffscreenUIRendering,
		// Token: 0x04000DCE RID: 3534
		XRMirrorView,
		// Token: 0x04000DCF RID: 3535
		XRCustomMirrorView,
		// Token: 0x04000DD0 RID: 3536
		XRDepthCopy,
		// Token: 0x04000DD1 RID: 3537
		DownsampleDepth,
		// Token: 0x04000DD2 RID: 3538
		LowResTransparent,
		// Token: 0x04000DD3 RID: 3539
		UpsampleLowResTransparent,
		// Token: 0x04000DD4 RID: 3540
		AlphaCopy,
		// Token: 0x04000DD5 RID: 3541
		StopNaNs,
		// Token: 0x04000DD6 RID: 3542
		FixedExposure,
		// Token: 0x04000DD7 RID: 3543
		DynamicExposure,
		// Token: 0x04000DD8 RID: 3544
		ApplyExposure,
		// Token: 0x04000DD9 RID: 3545
		TemporalAntialiasing,
		// Token: 0x04000DDA RID: 3546
		DeepLearningSuperSamplingColorMask,
		// Token: 0x04000DDB RID: 3547
		DeepLearningSuperSampling,
		// Token: 0x04000DDC RID: 3548
		DepthOfField,
		// Token: 0x04000DDD RID: 3549
		DepthOfFieldKernel,
		// Token: 0x04000DDE RID: 3550
		DepthOfFieldCoC,
		// Token: 0x04000DDF RID: 3551
		DepthOfFieldPrefilter,
		// Token: 0x04000DE0 RID: 3552
		DepthOfFieldPyramid,
		// Token: 0x04000DE1 RID: 3553
		DepthOfFieldDilate,
		// Token: 0x04000DE2 RID: 3554
		DepthOfFieldTileMax,
		// Token: 0x04000DE3 RID: 3555
		DepthOfFieldGatherFar,
		// Token: 0x04000DE4 RID: 3556
		DepthOfFieldGatherNear,
		// Token: 0x04000DE5 RID: 3557
		DepthOfFieldPreCombine,
		// Token: 0x04000DE6 RID: 3558
		DepthOfFieldCombine,
		// Token: 0x04000DE7 RID: 3559
		LensFlareDataDriven,
		// Token: 0x04000DE8 RID: 3560
		LensFlareComputeOcclusionDataDriven,
		// Token: 0x04000DE9 RID: 3561
		LensFlareMergeOcclusionDataDriven,
		// Token: 0x04000DEA RID: 3562
		MotionBlur,
		// Token: 0x04000DEB RID: 3563
		MotionBlurMotionVecPrep,
		// Token: 0x04000DEC RID: 3564
		MotionBlurTileMinMax,
		// Token: 0x04000DED RID: 3565
		MotionBlurTileNeighbourhood,
		// Token: 0x04000DEE RID: 3566
		MotionBlurTileScattering,
		// Token: 0x04000DEF RID: 3567
		MotionBlurKernel,
		// Token: 0x04000DF0 RID: 3568
		PaniniProjection,
		// Token: 0x04000DF1 RID: 3569
		Bloom,
		// Token: 0x04000DF2 RID: 3570
		ColorGradingLUTBuilder,
		// Token: 0x04000DF3 RID: 3571
		UberPost,
		// Token: 0x04000DF4 RID: 3572
		FXAA,
		// Token: 0x04000DF5 RID: 3573
		SMAA,
		// Token: 0x04000DF6 RID: 3574
		SceneUpsampling,
		// Token: 0x04000DF7 RID: 3575
		SetResolutionGroup,
		// Token: 0x04000DF8 RID: 3576
		FinalPost,
		// Token: 0x04000DF9 RID: 3577
		FinalImageHistogram,
		// Token: 0x04000DFA RID: 3578
		HDRDebugData,
		// Token: 0x04000DFB RID: 3579
		CustomPostProcessBeforeTAA,
		// Token: 0x04000DFC RID: 3580
		CustomPostProcessBeforePP,
		// Token: 0x04000DFD RID: 3581
		CustomPostProcessAfterPPBlurs,
		// Token: 0x04000DFE RID: 3582
		CustomPostProcessAfterPP,
		// Token: 0x04000DFF RID: 3583
		CustomPostProcessAfterOpaqueAndSky,
		// Token: 0x04000E00 RID: 3584
		ContrastAdaptiveSharpen,
		// Token: 0x04000E01 RID: 3585
		EdgeAdaptiveSpatialUpsampling,
		// Token: 0x04000E02 RID: 3586
		PrepareProbeVolumeList,
		// Token: 0x04000E03 RID: 3587
		ProbeVolumeDebug,
		// Token: 0x04000E04 RID: 3588
		CustomPassBufferClearDebug,
		// Token: 0x04000E05 RID: 3589
		AOVExecute,
		// Token: 0x04000E06 RID: 3590
		AOVOutput
	}
}
