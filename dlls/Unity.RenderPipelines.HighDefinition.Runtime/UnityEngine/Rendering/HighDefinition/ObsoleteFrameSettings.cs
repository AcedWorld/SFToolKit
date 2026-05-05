using System;
using System.Diagnostics;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001B5 RID: 437
	[DebuggerDisplay("FrameSettings overriding {overrides.ToString(\"X\")}")]
	[Obsolete("For data migration")]
	[Serializable]
	internal class ObsoleteFrameSettings
	{
		// Token: 0x04001515 RID: 5397
		public ObsoleteFrameSettingsOverrides overrides;

		// Token: 0x04001516 RID: 5398
		public bool enableShadow;

		// Token: 0x04001517 RID: 5399
		public bool enableContactShadows;

		// Token: 0x04001518 RID: 5400
		public bool enableShadowMask;

		// Token: 0x04001519 RID: 5401
		public bool enableSSR;

		// Token: 0x0400151A RID: 5402
		public bool enableSSAO;

		// Token: 0x0400151B RID: 5403
		public bool enableSubsurfaceScattering;

		// Token: 0x0400151C RID: 5404
		public bool enableTransmission;

		// Token: 0x0400151D RID: 5405
		public bool enableAtmosphericScattering;

		// Token: 0x0400151E RID: 5406
		public bool enableVolumetrics;

		// Token: 0x0400151F RID: 5407
		public bool enableReprojectionForVolumetrics;

		// Token: 0x04001520 RID: 5408
		public bool enableLightLayers;

		// Token: 0x04001521 RID: 5409
		public bool enableExposureControl = true;

		// Token: 0x04001522 RID: 5410
		public float diffuseGlobalDimmer;

		// Token: 0x04001523 RID: 5411
		public float specularGlobalDimmer;

		// Token: 0x04001524 RID: 5412
		public ObsoleteLitShaderMode shaderLitMode;

		// Token: 0x04001525 RID: 5413
		public bool enableDepthPrepassWithDeferredRendering;

		// Token: 0x04001526 RID: 5414
		public bool enableTransparentPrepass;

		// Token: 0x04001527 RID: 5415
		public bool enableMotionVectors;

		// Token: 0x04001528 RID: 5416
		public bool enableObjectMotionVectors;

		// Token: 0x04001529 RID: 5417
		[FormerlySerializedAs("enableDBuffer")]
		public bool enableDecals;

		// Token: 0x0400152A RID: 5418
		public bool enableRoughRefraction;

		// Token: 0x0400152B RID: 5419
		public bool enableTransparentPostpass;

		// Token: 0x0400152C RID: 5420
		public bool enableDistortion;

		// Token: 0x0400152D RID: 5421
		public bool enablePostprocess;

		// Token: 0x0400152E RID: 5422
		public bool enableOpaqueObjects;

		// Token: 0x0400152F RID: 5423
		public bool enableTransparentObjects;

		// Token: 0x04001530 RID: 5424
		public bool enableRealtimePlanarReflection;

		// Token: 0x04001531 RID: 5425
		public bool enableMSAA;

		// Token: 0x04001532 RID: 5426
		public bool enableAsyncCompute;

		// Token: 0x04001533 RID: 5427
		public bool runLightListAsync;

		// Token: 0x04001534 RID: 5428
		public bool runSSRAsync;

		// Token: 0x04001535 RID: 5429
		public bool runSSAOAsync;

		// Token: 0x04001536 RID: 5430
		public bool runContactShadowsAsync;

		// Token: 0x04001537 RID: 5431
		public bool runVolumeVoxelizationAsync;

		// Token: 0x04001538 RID: 5432
		public ObsoleteLightLoopSettings lightLoopSettings;
	}
}
