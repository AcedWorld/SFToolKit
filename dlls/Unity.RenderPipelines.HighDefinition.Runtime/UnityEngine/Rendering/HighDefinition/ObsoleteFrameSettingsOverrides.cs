using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001B3 RID: 435
	[Flags]
	[Obsolete("For data migration")]
	internal enum ObsoleteFrameSettingsOverrides
	{
		// Token: 0x040014EE RID: 5358
		Shadow = 1,
		// Token: 0x040014EF RID: 5359
		ContactShadow = 2,
		// Token: 0x040014F0 RID: 5360
		ShadowMask = 4,
		// Token: 0x040014F1 RID: 5361
		SSR = 8,
		// Token: 0x040014F2 RID: 5362
		SSAO = 16,
		// Token: 0x040014F3 RID: 5363
		SubsurfaceScattering = 32,
		// Token: 0x040014F4 RID: 5364
		Transmission = 64,
		// Token: 0x040014F5 RID: 5365
		AtmosphericScaterring = 128,
		// Token: 0x040014F6 RID: 5366
		Volumetrics = 256,
		// Token: 0x040014F7 RID: 5367
		ReprojectionForVolumetrics = 512,
		// Token: 0x040014F8 RID: 5368
		LightLayers = 1024,
		// Token: 0x040014F9 RID: 5369
		MSAA = 2048,
		// Token: 0x040014FA RID: 5370
		ExposureControl = 4096,
		// Token: 0x040014FB RID: 5371
		TransparentPrepass = 8192,
		// Token: 0x040014FC RID: 5372
		TransparentPostpass = 16384,
		// Token: 0x040014FD RID: 5373
		MotionVectors = 32768,
		// Token: 0x040014FE RID: 5374
		ObjectMotionVectors = 65536,
		// Token: 0x040014FF RID: 5375
		Decals = 131072,
		// Token: 0x04001500 RID: 5376
		RoughRefraction = 262144,
		// Token: 0x04001501 RID: 5377
		Distortion = 524288,
		// Token: 0x04001502 RID: 5378
		Postprocess = 1048576,
		// Token: 0x04001503 RID: 5379
		ShaderLitMode = 2097152,
		// Token: 0x04001504 RID: 5380
		DepthPrepassWithDeferredRendering = 4194304,
		// Token: 0x04001505 RID: 5381
		OpaqueObjects = 16777216,
		// Token: 0x04001506 RID: 5382
		TransparentObjects = 33554432,
		// Token: 0x04001507 RID: 5383
		AsyncCompute = 8388608,
		// Token: 0x04001508 RID: 5384
		LightListAsync = 134217728,
		// Token: 0x04001509 RID: 5385
		SSRAsync = 268435456,
		// Token: 0x0400150A RID: 5386
		SSAOAsync = 536870912,
		// Token: 0x0400150B RID: 5387
		ContactShadowsAsync = 1073741824,
		// Token: 0x0400150C RID: 5388
		VolumeVoxelizationsAsync = -2147483648
	}
}
