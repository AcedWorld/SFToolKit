using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000229 RID: 553
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Water\\WaterSystemDef.cs", needAccessors = false, generateCBuffer = true)]
	internal struct ShaderVariablesWaterRendering
	{
		// Token: 0x04001930 RID: 6448
		public Vector2 _GridSize;

		// Token: 0x04001931 RID: 6449
		public Vector2 _WaterRotation;

		// Token: 0x04001932 RID: 6450
		public Vector4 _PatchOffset;

		// Token: 0x04001933 RID: 6451
		public uint _WaterLODCount;

		// Token: 0x04001934 RID: 6452
		public uint _NumWaterPatches;

		// Token: 0x04001935 RID: 6453
		public float _FoamIntensity;

		// Token: 0x04001936 RID: 6454
		public float _CausticsIntensity;

		// Token: 0x04001937 RID: 6455
		public Vector2 _WaterMaskScale;

		// Token: 0x04001938 RID: 6456
		public Vector2 _WaterMaskOffset;

		// Token: 0x04001939 RID: 6457
		public Vector2 _FoamMaskScale;

		// Token: 0x0400193A RID: 6458
		public Vector2 _FoamMaskOffset;

		// Token: 0x0400193B RID: 6459
		public float _CausticsPlaneBlendDistance;

		// Token: 0x0400193C RID: 6460
		public int _WaterCausticsEnabled;

		// Token: 0x0400193D RID: 6461
		public uint _WaterDecalLayer;

		// Token: 0x0400193E RID: 6462
		public int _InfiniteSurface;

		// Token: 0x0400193F RID: 6463
		public float _WaterMaxTessellationFactor;

		// Token: 0x04001940 RID: 6464
		public float _WaterTessellationFadeStart;

		// Token: 0x04001941 RID: 6465
		public float _WaterTessellationFadeRange;

		// Token: 0x04001942 RID: 6466
		public int _CameraInUnderwaterRegion;
	}
}
