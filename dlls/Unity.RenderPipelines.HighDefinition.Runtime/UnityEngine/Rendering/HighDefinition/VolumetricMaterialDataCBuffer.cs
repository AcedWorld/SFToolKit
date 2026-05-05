using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000E0 RID: 224
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\VolumetricLighting\\HDRenderPipeline.VolumetricLighting.cs", needAccessors = false, generateCBuffer = true)]
	internal struct VolumetricMaterialDataCBuffer
	{
		// Token: 0x04000978 RID: 2424
		public Vector4 _VolumetricMaterialObbRight;

		// Token: 0x04000979 RID: 2425
		public Vector4 _VolumetricMaterialObbUp;

		// Token: 0x0400097A RID: 2426
		public Vector4 _VolumetricMaterialObbExtents;

		// Token: 0x0400097B RID: 2427
		public Vector4 _VolumetricMaterialObbCenter;

		// Token: 0x0400097C RID: 2428
		public Vector4 _VolumetricMaterialAlbedo;

		// Token: 0x0400097D RID: 2429
		public Vector4 _VolumetricMaterialRcpPosFaceFade;

		// Token: 0x0400097E RID: 2430
		public Vector4 _VolumetricMaterialRcpNegFaceFade;

		// Token: 0x0400097F RID: 2431
		public float _VolumetricMaterialInvertFade;

		// Token: 0x04000980 RID: 2432
		public float _VolumetricMaterialExtinction;

		// Token: 0x04000981 RID: 2433
		public float _VolumetricMaterialRcpDistFadeLen;

		// Token: 0x04000982 RID: 2434
		public float _VolumetricMaterialEndTimesRcpDistFadeLen;

		// Token: 0x04000983 RID: 2435
		public float _VolumetricMaterialFalloffMode;

		// Token: 0x04000984 RID: 2436
		public float padding0;

		// Token: 0x04000985 RID: 2437
		public float padding1;

		// Token: 0x04000986 RID: 2438
		public float padding2;
	}
}
