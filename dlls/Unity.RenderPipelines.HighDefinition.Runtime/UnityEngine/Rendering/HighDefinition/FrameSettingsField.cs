using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001AE RID: 430
	public enum FrameSettingsField
	{
		// Token: 0x0400147A RID: 5242
		None = -1,
		// Token: 0x0400147B RID: 5243
		[FrameSettingsField(0, FrameSettingsField.LitShaderMode, null, "Specifies the Lit Shader Mode for Cameras using these Frame Settings use to render the Scene (Depends on \"Lit Shader Mode\" in current HDRP Asset).", FrameSettingsFieldAttribute.DisplayType.BoolAsEnumPopup, typeof(LitShaderMode), null, null, 0)]
		LitShaderMode,
		// Token: 0x0400147C RID: 5244
		[FrameSettingsField(0, FrameSettingsField.None, "Full Depth Prepass within Deferred", "When enabled, HDRP processes a full depth prepass (All meshes are sent) for Cameras using these Frame Settings. Set Lit Shader Mode to Deferred to access this option.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.LitShaderMode
		}, null, -1)]
		DepthPrepassWithDeferredRendering,
		// Token: 0x0400147D RID: 5245
		[FrameSettingsField(0, FrameSettingsField.None, "Clear GBuffers", "When enabled, HDRP clear GBuffers for Cameras using these Frame Settings. Set Lit Shader Mode to Deferred to access this option.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.LitShaderMode
		}, null, 2)]
		ClearGBuffers = 5,
		// Token: 0x0400147E RID: 5246
		[Obsolete]
		MSAA = 31,
		// Token: 0x0400147F RID: 5247
		[FrameSettingsField(0, FrameSettingsField.None, "MSAA Within Forward", "Specifies the MSAA mode for Cameras using these Frame Settings. Set Lit Shader Mode to Forward to access this option. Note that MSAA is disabled when using ray tracing.", FrameSettingsFieldAttribute.DisplayType.Others, typeof(MSAAMode), null, null, 3)]
		MSAAMode = 4,
		// Token: 0x04001480 RID: 5248
		[Obsolete]
		[FrameSettingsField(0, FrameSettingsField.None, "Alpha To Mask", "When enabled, Cameras using these Frame Settings use Alpha To Mask. Activate MSAA to access this option.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 3)]
		AlphaToMask = 56,
		// Token: 0x04001481 RID: 5249
		[FrameSettingsField(0, FrameSettingsField.OpaqueObjects, null, "When enabled, Cameras using these Frame Settings render opaque GameObjects.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 4)]
		OpaqueObjects = 2,
		// Token: 0x04001482 RID: 5250
		[FrameSettingsField(0, FrameSettingsField.TransparentObjects, null, "When enabled, Cameras using these Frame Settings render Transparent GameObjects.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 5)]
		TransparentObjects,
		// Token: 0x04001483 RID: 5251
		[FrameSettingsField(0, FrameSettingsField.Decals, null, "When enabled, HDRP processes a decal render pass for Cameras using these Frame Settings.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 6)]
		Decals = 12,
		// Token: 0x04001484 RID: 5252
		[FrameSettingsField(0, FrameSettingsField.DecalLayers, null, "When enabled, Cameras that use these Frame Settings make use of DecalLayers (Depends on \"Decal Layers\" in current HDRP Asset).", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.Decals
		}, null, 6)]
		DecalLayers = 96,
		// Token: 0x04001485 RID: 5253
		[FrameSettingsField(0, FrameSettingsField.TransparentPrepass, null, "When enabled, HDRP processes a transparent prepass for Cameras using these Frame Settings.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 7)]
		TransparentPrepass = 8,
		// Token: 0x04001486 RID: 5254
		[FrameSettingsField(0, FrameSettingsField.TransparentPostpass, null, "When enabled, HDRP processes a transparent postpass for Cameras using these Frame Settings.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 8)]
		TransparentPostpass,
		// Token: 0x04001487 RID: 5255
		[FrameSettingsField(0, FrameSettingsField.None, "Low Resolution Transparent", "When enabled, HDRP processes a transparent pass in a lower resolution for Cameras using these Frame Settings.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 9)]
		LowResTransparent = 18,
		// Token: 0x04001488 RID: 5256
		[FrameSettingsField(0, FrameSettingsField.None, "Ray Tracing", "When enabled, HDRP updates ray tracing for Cameras using these Frame Settings (Depends on \"Realtime RayTracing\" in current HDRP Asset).", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 10)]
		RayTracing = 92,
		// Token: 0x04001489 RID: 5257
		[FrameSettingsField(0, FrameSettingsField.CustomPass, null, "When enabled, HDRP renders custom passes contained in CustomPassVolume components.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 11)]
		CustomPass = 6,
		// Token: 0x0400148A RID: 5258
		[FrameSettingsField(0, FrameSettingsField.VirtualTexturing, null, "Virtual Texturing needs to be enabled first in Project Settings > Player > Other Settings > Virtual Texturing.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 105)]
		VirtualTexturing = 68,
		// Token: 0x0400148B RID: 5259
		[FrameSettingsField(0, FrameSettingsField.Water, null, "When enabled, Cameras using these Frame Settings render water surfaces.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 106)]
		Water = 99,
		// Token: 0x0400148C RID: 5260
		[FrameSettingsField(0, FrameSettingsField.None, "Asymmetric Projection", "When enabled HDRP will account for asymmetric projection when evaluating the view direction based on pixel coordinates.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 107)]
		AsymmetricProjection = 78,
		// Token: 0x0400148D RID: 5261
		[FrameSettingsField(0, FrameSettingsField.None, "Screen Coordinates Override", "When enabled HDRP will use Screen Coordinates Override for post processing and custom passes. This allows post effects to be compatible with Cluster Display for example.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 108)]
		ScreenCoordOverride = 77,
		// Token: 0x0400148E RID: 5262
		[FrameSettingsField(0, FrameSettingsField.MotionVectors, null, "When enabled, HDRP processes a motion vector pass for Cameras using these Frame Settings (Depends on \"Motion Vectors\" in current HDRP Asset).", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 12)]
		MotionVectors = 10,
		// Token: 0x0400148F RID: 5263
		[FrameSettingsField(0, FrameSettingsField.None, "Opaque Object Motion", "When enabled, HDRP processes an object motion vector pass for Cameras using these Frame Settings.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.MotionVectors
		}, null, 13)]
		ObjectMotionVectors,
		// Token: 0x04001490 RID: 5264
		[FrameSettingsField(0, FrameSettingsField.None, "Transparent Object Motion", "When enabled, transparent GameObjects use Motion Vectors. You must also enable TransparentWritesVelocity for Materials that you want to use motion vectors with.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.MotionVectors
		}, null, 14)]
		TransparentsWriteMotionVector = 16,
		// Token: 0x04001491 RID: 5265
		[FrameSettingsField(0, FrameSettingsField.Refraction, null, "When enabled, HDRP processes a refraction render pass for Cameras using these Frame Settings. This add a resolve of ColorBuffer after the drawing of opaque materials to be use for Refraction effect during transparent pass.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 15)]
		Refraction = 13,
		// Token: 0x04001492 RID: 5266
		[Obsolete]
		RoughRefraction = 13,
		// Token: 0x04001493 RID: 5267
		[FrameSettingsField(0, FrameSettingsField.Distortion, null, "When enabled, HDRP processes a distortion render pass for Cameras using these Frame Settings (Depends on \"Distortion\" in current HDRP Asset).", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 16)]
		Distortion,
		// Token: 0x04001494 RID: 5268
		[FrameSettingsField(0, FrameSettingsField.RoughDistortion, null, "When enabled, HDRP processes a distortion render pass for Cameras using these Frame Settings (Depends on \"Distortion\" in current HDRP Asset).", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.Distortion
		}, null, 17)]
		RoughDistortion = 67,
		// Token: 0x04001495 RID: 5269
		[FrameSettingsField(0, FrameSettingsField.None, "Post-process", "When enabled, HDRP processes a post-processing render pass for Cameras using these Frame Settings.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 18)]
		Postprocess = 15,
		// Token: 0x04001496 RID: 5270
		[FrameSettingsField(0, FrameSettingsField.None, "Custom Post-process", "When enabled on a Camera, HDRP renders user-written post processes.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.Postprocess
		}, null, 19)]
		CustomPostProcess = 39,
		// Token: 0x04001497 RID: 5271
		[FrameSettingsField(0, FrameSettingsField.None, "Stop NaN", "When enabled, HDRP replace NaN values with black pixels for Cameras using these Frame Settings.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.Postprocess
		}, null, 19)]
		StopNaN = 80,
		// Token: 0x04001498 RID: 5272
		[FrameSettingsField(0, FrameSettingsField.DepthOfField, null, "When enabled, HDRP adds depth of field to Cameras affected by a Volume containing the Depth Of Field override.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.Postprocess
		}, null, 19)]
		DepthOfField,
		// Token: 0x04001499 RID: 5273
		[FrameSettingsField(0, FrameSettingsField.MotionBlur, null, "When enabled, HDRP adds motion blur to Cameras affected by a Volume containing the Blur override.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.Postprocess
		}, null, 19)]
		MotionBlur,
		// Token: 0x0400149A RID: 5274
		[FrameSettingsField(0, FrameSettingsField.PaniniProjection, null, "When enabled, HDRP adds panini projection to Cameras affected by a Volume containing the Panini Projection override.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.Postprocess
		}, null, 19)]
		PaniniProjection,
		// Token: 0x0400149B RID: 5275
		[FrameSettingsField(0, FrameSettingsField.Bloom, null, "When enabled, HDRP adds bloom to Cameras affected by a Volume containing the Bloom override.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.Postprocess
		}, null, 19)]
		Bloom,
		// Token: 0x0400149C RID: 5276
		[FrameSettingsField(0, FrameSettingsField.LensFlareDataDriven, null, "When enabled, HDRP adds lens flare to Cameras.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.Postprocess
		}, null, 19)]
		LensFlareDataDriven = 97,
		// Token: 0x0400149D RID: 5277
		[FrameSettingsField(0, FrameSettingsField.LensDistortion, null, "When enabled, HDRP adds lens distortion to Cameras affected by a Volume containing the Lens Distortion override.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.Postprocess
		}, null, 19)]
		LensDistortion = 85,
		// Token: 0x0400149E RID: 5278
		[FrameSettingsField(0, FrameSettingsField.ChromaticAberration, null, "When enabled, HDRP adds chromatic aberration to Cameras affected by a Volume containing the Chromatic Aberration override.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.Postprocess
		}, null, 19)]
		ChromaticAberration,
		// Token: 0x0400149F RID: 5279
		[FrameSettingsField(0, FrameSettingsField.Vignette, null, "When enabled, HDRP adds vignette to Cameras affected by a Volume containing the Vignette override.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.Postprocess
		}, null, 19)]
		Vignette,
		// Token: 0x040014A0 RID: 5280
		[FrameSettingsField(0, FrameSettingsField.ColorGrading, null, "When enabled, HDRP processes color grading for Cameras using these Frame Settings.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.Postprocess
		}, null, 19)]
		ColorGrading,
		// Token: 0x040014A1 RID: 5281
		[FrameSettingsField(0, FrameSettingsField.Tonemapping, null, "When enabled, HDRP processes tonemapping for Cameras using these Frame Settings.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.Postprocess
		}, null, 19)]
		Tonemapping = 93,
		// Token: 0x040014A2 RID: 5282
		[FrameSettingsField(0, FrameSettingsField.FilmGrain, null, "When enabled, HDRP adds film grain to Cameras affected by a Volume containing the Film Grain override.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.Postprocess
		}, null, 19)]
		FilmGrain = 89,
		// Token: 0x040014A3 RID: 5283
		[FrameSettingsField(0, FrameSettingsField.Dithering, null, "When enabled, HDRP processes dithering for Cameras using these Frame Settings.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.Postprocess
		}, null, 19)]
		Dithering,
		// Token: 0x040014A4 RID: 5284
		[FrameSettingsField(0, FrameSettingsField.None, "Anti-aliasing", "When enabled, HDRP processes anti-aliasing for camera using these Frame Settings.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.Postprocess
		}, null, 19)]
		Antialiasing,
		// Token: 0x040014A5 RID: 5285
		[FrameSettingsField(0, FrameSettingsField.None, "After Post-process", "When enabled, HDRP processes a post-processing render pass for Cameras using these Frame Settings.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 20)]
		AfterPostprocess = 17,
		// Token: 0x040014A6 RID: 5286
		[FrameSettingsField(0, FrameSettingsField.None, "Depth Test", "When enabled, Cameras that don't use TAA process a depth test for Materials in the AfterPostProcess rendering pass.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.AfterPostprocess
		}, null, 20)]
		ZTestAfterPostProcessTAA = 19,
		// Token: 0x040014A7 RID: 5287
		[FrameSettingsField(0, FrameSettingsField.LODBiasMode, null, "Specifies the Level Of Detail Mode for Cameras using these Frame Settings use to render the Scene. Scale will allow to add a scale factor while Override will allow to set a specific value.", FrameSettingsFieldAttribute.DisplayType.Others, typeof(LODBiasMode), null, null, 100)]
		LODBiasMode = 60,
		// Token: 0x040014A8 RID: 5288
		[FrameSettingsField(0, FrameSettingsField.LODBias, null, "Sets the Level Of Detail Bias or the Scale on it.", FrameSettingsFieldAttribute.DisplayType.Others, null, new FrameSettingsField[]
		{
			FrameSettingsField.LODBiasMode
		}, null, -1)]
		LODBias,
		// Token: 0x040014A9 RID: 5289
		[FrameSettingsField(0, FrameSettingsField.None, "Quality Level", "The quality level to use when fetching the value from the quality settings.", FrameSettingsFieldAttribute.DisplayType.Others, null, new FrameSettingsField[]
		{
			FrameSettingsField.LODBiasMode
		}, null, 100)]
		LODBiasQualityLevel = 64,
		// Token: 0x040014AA RID: 5290
		[FrameSettingsField(0, FrameSettingsField.MaximumLODLevelMode, null, "Specifies the Maximum Level Of Detail Mode for Cameras using these Frame Settings to use to render the Scene. Offset allows you to add an offset factor while Override allows you to set a specific value.", FrameSettingsFieldAttribute.DisplayType.Others, typeof(MaximumLODLevelMode), null, null, -1)]
		MaximumLODLevelMode = 62,
		// Token: 0x040014AB RID: 5291
		[FrameSettingsField(0, FrameSettingsField.MaximumLODLevel, null, "Sets the Maximum Level Of Detail Level or the Offset on it.", FrameSettingsFieldAttribute.DisplayType.Others, null, new FrameSettingsField[]
		{
			FrameSettingsField.MaximumLODLevelMode
		}, null, -1)]
		MaximumLODLevel,
		// Token: 0x040014AC RID: 5292
		[FrameSettingsField(0, FrameSettingsField.None, "Quality Level", "The quality level to use when fetching the value from the quality settings.", FrameSettingsFieldAttribute.DisplayType.Others, null, new FrameSettingsField[]
		{
			FrameSettingsField.MaximumLODLevelMode
		}, null, 102)]
		MaximumLODLevelQualityLevel = 65,
		// Token: 0x040014AD RID: 5293
		[FrameSettingsField(0, FrameSettingsField.MaterialQualityLevel, null, "The material quality level to use.", FrameSettingsFieldAttribute.DisplayType.Others, null, null, null, -1)]
		MaterialQualityLevel,
		// Token: 0x040014AE RID: 5294
		[FrameSettingsField(1, FrameSettingsField.ShadowMaps, null, "When enabled, Cameras using these Frame Settings render shadows.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 1)]
		ShadowMaps = 20,
		// Token: 0x040014AF RID: 5295
		[FrameSettingsField(1, FrameSettingsField.ContactShadows, null, "When enabled, Cameras using these Frame Settings render Contact Shadows", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, -1)]
		ContactShadows,
		// Token: 0x040014B0 RID: 5296
		[FrameSettingsField(1, FrameSettingsField.ScreenSpaceShadows, null, "When enabled, Cameras using these Frame Settings render Screen Space Shadows (Depends on \"Screen Space Shadows\" in current HDRP Asset). Note that Screen Space Shadows are disabled when MSAA is enabled.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 23)]
		ScreenSpaceShadows = 34,
		// Token: 0x040014B1 RID: 5297
		[FrameSettingsField(1, FrameSettingsField.Shadowmask, null, "When enabled, Cameras using these Frame Settings render shadows from Shadow Masks (Depends on \"Shadowmask\" in current HDRP Asset).", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 24)]
		Shadowmask = 22,
		// Token: 0x040014B2 RID: 5298
		[FrameSettingsField(1, FrameSettingsField.None, "Screen Space Reflection", "When enabled, Cameras using these Frame Settings calculate Screen Space Reflections (Depends on \"Screen Space Reflection\" in current HDRP Asset). Note that Screen Space Reflections are disabled when MSAA is enabled.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, -1)]
		SSR,
		// Token: 0x040014B3 RID: 5299
		[FrameSettingsField(1, FrameSettingsField.None, "Transparents", "When enabled, Cameras using these Frame Settings calculate Screen Space Reflections on transparent objects.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.SSR
		}, null, 25)]
		TransparentSSR = 94,
		// Token: 0x040014B4 RID: 5300
		[FrameSettingsField(1, FrameSettingsField.None, "Screen Space Ambient Occlusion", "When enabled, Cameras using these Frame Settings calculate Screen Space Ambient Occlusion (Depends on \"Screen Space Ambient Occlusion\" in current HDRP Asset).", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, -1)]
		SSAO = 24,
		// Token: 0x040014B5 RID: 5301
		[FrameSettingsField(1, FrameSettingsField.None, "Screen Space Global Illumination", "When enabled, Cameras using these Frame Settings calculate Screen Space Global Illumination (Depends on \"Screen Space Global Illumination\" in current HDRP Asset).", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 25)]
		SSGI = 95,
		// Token: 0x040014B6 RID: 5302
		[FrameSettingsField(1, FrameSettingsField.SubsurfaceScattering, null, "When enabled, Cameras using these Frame Settings render subsurface scattering (SSS) effects for GameObjects that use a SSS Material (Depends on \"Subsurface Scattering\" in current HDRP Asset).", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 46)]
		SubsurfaceScattering = 46,
		// Token: 0x040014B7 RID: 5303
		[FrameSettingsField(1, FrameSettingsField.None, "Quality Mode", "Configures the way the sample budget of the Subsurface Scattering algorithm is determined. You can either pick from one of the existing values in the Quality Settings, or request a custom number of samples.", FrameSettingsFieldAttribute.DisplayType.Others, typeof(SssQualityMode), new FrameSettingsField[]
		{
			FrameSettingsField.SubsurfaceScattering
		}, null, 47)]
		SssQualityMode,
		// Token: 0x040014B8 RID: 5304
		[FrameSettingsField(1, FrameSettingsField.None, "Quality Level", "Sets the Quality Level of the Subsurface Scattering algorithm.", FrameSettingsFieldAttribute.DisplayType.Others, null, new FrameSettingsField[]
		{
			FrameSettingsField.SubsurfaceScattering
		}, null, 48)]
		SssQualityLevel,
		// Token: 0x040014B9 RID: 5305
		[FrameSettingsField(1, FrameSettingsField.None, "Custom Sample Budget", "Sets the custom sample budget of the Subsurface Scattering algorithm.", FrameSettingsFieldAttribute.DisplayType.Others, null, new FrameSettingsField[]
		{
			FrameSettingsField.SubsurfaceScattering
		}, null, 49)]
		SssCustomSampleBudget,
		// Token: 0x040014BA RID: 5306
		[FrameSettingsField(1, FrameSettingsField.VolumetricClouds, null, "When enabled, Cameras using these Frame Settings calculate Volumetric Clouds.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 50)]
		VolumetricClouds = 79,
		// Token: 0x040014BB RID: 5307
		[FrameSettingsField(1, FrameSettingsField.FullResolutionCloudsForSky, null, "When enabled, Cameras using these Frame Settings calculate Volumetric Clouds at full resolution when evaluating the sky texture.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.VolumetricClouds
		}, null, 51)]
		FullResolutionCloudsForSky = 98,
		// Token: 0x040014BC RID: 5308
		[FrameSettingsField(1, FrameSettingsField.Transmission, null, "When enabled, Cameras using these Frame Settings render subsurface scattering (SSS) Materials with an added transmission effect (only if you enable Transmission on the SSS Material in the Material's Inspector).", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, -1)]
		Transmission = 26,
		// Token: 0x040014BD RID: 5309
		[FrameSettingsField(1, FrameSettingsField.None, "Fog", "When enabled, Cameras using these Frame Settings render fog effects.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, -1)]
		AtmosphericScattering,
		// Token: 0x040014BE RID: 5310
		[FrameSettingsField(1, FrameSettingsField.Volumetrics, null, "When enabled, Cameras using these Frame Settings render volumetric effects such as volumetric fog and lighting (Depends on \"Volumetrics\" in current HDRP Asset).", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.AtmosphericScattering
		}, null, -1)]
		Volumetrics,
		// Token: 0x040014BF RID: 5311
		[FrameSettingsField(1, FrameSettingsField.None, "Reprojection", "When enabled, Cameras using these Frame Settings use several previous frames to calculate volumetric effects which increases their overall quality at run time.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.AtmosphericScattering,
			FrameSettingsField.Volumetrics
		}, null, -1)]
		ReprojectionForVolumetrics,
		// Token: 0x040014C0 RID: 5312
		[FrameSettingsField(1, FrameSettingsField.LightLayers, null, "When enabled, Cameras that use these Frame Settings make use of LightLayers (Depends on \"Light Layers\" in current HDRP Asset).", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, -1)]
		LightLayers,
		// Token: 0x040014C1 RID: 5313
		[FrameSettingsField(1, FrameSettingsField.ExposureControl, null, "When enabled, Cameras that use these Frame Settings use exposure values defined in relevant components.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 33)]
		ExposureControl = 32,
		// Token: 0x040014C2 RID: 5314
		[FrameSettingsField(1, FrameSettingsField.ReflectionProbe, null, "When enabled, Cameras that use these Frame Settings calculate reflection from Reflection Probes.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, -1)]
		ReflectionProbe,
		// Token: 0x040014C3 RID: 5315
		[FrameSettingsField(1, FrameSettingsField.None, "Planar Reflection Probe", "When enabled, Cameras that use these Frame Settings calculate reflection from Planar Reflection Probes.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 36)]
		PlanarProbe = 35,
		// Token: 0x040014C4 RID: 5316
		[FrameSettingsField(1, FrameSettingsField.None, "Metallic Indirect Fallback", "When enabled, Cameras that use these Frame Settings render Materials with base color as diffuse. This is a useful Frame Setting to use for real-time Reflection Probes because it renders metals as diffuse Materials to stop them appearing black when Unity can't calculate several bounces of specular lighting.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, -1)]
		ReplaceDiffuseForIndirect,
		// Token: 0x040014C5 RID: 5317
		[FrameSettingsField(1, FrameSettingsField.SkyReflection, null, "When enabled, the Sky affects specular lighting for Cameras that use these Frame Settings.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, -1)]
		SkyReflection,
		// Token: 0x040014C6 RID: 5318
		[FrameSettingsField(1, FrameSettingsField.DirectSpecularLighting, null, "When enabled, Cameras that use these Frame Settings render Direct Specular lighting. This is a useful Frame Setting to use for baked Reflection Probes to remove view dependent lighting.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, -1)]
		DirectSpecularLighting,
		// Token: 0x040014C7 RID: 5319
		[FrameSettingsField(1, FrameSettingsField.ProbeVolume, null, "Enable to debug and make HDRP process Probe Volumes. Enabling this feature causes HDRP to process Probe Volumes for this Camera/Reflection Probe.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, 3)]
		ProbeVolume = 127,
		// Token: 0x040014C8 RID: 5320
		[FrameSettingsField(1, FrameSettingsField.None, "Normalize Reflection Probes", null, FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.ProbeVolume
		}, null, 4)]
		NormalizeReflectionProbeWithProbeVolume = 126,
		// Token: 0x040014C9 RID: 5321
		[FrameSettingsField(2, FrameSettingsField.None, "Asynchronous Execution", "When enabled, HDRP executes certain Compute Shader commands in parallel. This is only supported on DX12 and Vulkan. If Asynchronous execution is disabled or not supported the effects will fallback on a synchronous version.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, -1)]
		AsyncCompute = 40,
		// Token: 0x040014CA RID: 5322
		[FrameSettingsField(2, FrameSettingsField.None, "Light List", "When enabled, HDRP builds the Light List asynchronously.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.AsyncCompute
		}, null, -1)]
		LightListAsync,
		// Token: 0x040014CB RID: 5323
		[FrameSettingsField(2, FrameSettingsField.None, "SS Reflection", "When enabled, HDRP calculates screen space reflection asynchronously.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.AsyncCompute
		}, null, -1)]
		SSRAsync,
		// Token: 0x040014CC RID: 5324
		[FrameSettingsField(2, FrameSettingsField.None, "SS Ambient Occlusion", "When enabled, HDRP calculates screen space ambient occlusion asynchronously.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.AsyncCompute
		}, null, -1)]
		SSAOAsync,
		// Token: 0x040014CD RID: 5325
		[FrameSettingsField(2, FrameSettingsField.None, "Contact Shadows", "When enabled, HDRP calculates Contact Shadows asynchronously.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.AsyncCompute
		}, null, -1)]
		ContactShadowsAsync,
		// Token: 0x040014CE RID: 5326
		[FrameSettingsField(2, FrameSettingsField.None, "Volume Voxelizations", "When enabled, HDRP calculates volumetric voxelization asynchronously.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.AsyncCompute
		}, null, -1)]
		VolumeVoxelizationsAsync,
		// Token: 0x040014CF RID: 5327
		[FrameSettingsField(3, FrameSettingsField.FPTLForForwardOpaque, null, "When enabled, HDRP uses FPTL for forward opaque.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, -1)]
		FPTLForForwardOpaque = 120,
		// Token: 0x040014D0 RID: 5328
		[FrameSettingsField(3, FrameSettingsField.BigTilePrepass, null, "When enabled, HDRP uses a big tile prepass for light visibility.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, -1)]
		BigTilePrepass,
		// Token: 0x040014D1 RID: 5329
		[FrameSettingsField(3, FrameSettingsField.DeferredTile, null, "When enabled, HDRP uses tiles to compute deferred lighting.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, null, null, -1)]
		DeferredTile,
		// Token: 0x040014D2 RID: 5330
		[FrameSettingsField(3, FrameSettingsField.ComputeLightEvaluation, null, "When enabled, HDRP uses a compute shader to compute deferred lighting.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.DeferredTile
		}, null, -1)]
		ComputeLightEvaluation,
		// Token: 0x040014D3 RID: 5331
		[FrameSettingsField(3, FrameSettingsField.ComputeLightVariants, null, "When enabled, HDRP uses light variant classification to compute lighting.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.DeferredTile
		}, null, -1)]
		ComputeLightVariants,
		// Token: 0x040014D4 RID: 5332
		[FrameSettingsField(3, FrameSettingsField.ComputeMaterialVariants, null, "When enabled, HDRP uses material variant classification to compute lighting.", FrameSettingsFieldAttribute.DisplayType.BoolAsCheckbox, null, new FrameSettingsField[]
		{
			FrameSettingsField.DeferredTile
		}, null, -1)]
		ComputeMaterialVariants
	}
}
