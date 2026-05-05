using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000F6 RID: 246
	[GenerateHLSL(PackingRules.Exact, false, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Decal\\Decal.cs")]
	internal struct DecalData
	{
		// Token: 0x04000A6B RID: 2667
		public Matrix4x4 worldToDecal;

		// Token: 0x04000A6C RID: 2668
		public Matrix4x4 normalToWorld;

		// Token: 0x04000A6D RID: 2669
		public Vector4 diffuseScaleBias;

		// Token: 0x04000A6E RID: 2670
		public Vector4 normalScaleBias;

		// Token: 0x04000A6F RID: 2671
		public Vector4 maskScaleBias;

		// Token: 0x04000A70 RID: 2672
		public Vector4 baseColor;

		// Token: 0x04000A71 RID: 2673
		public Vector4 remappingAOS;

		// Token: 0x04000A72 RID: 2674
		public Vector4 scalingBAndRemappingM;

		// Token: 0x04000A73 RID: 2675
		public Vector3 blendParams;

		// Token: 0x04000A74 RID: 2676
		public uint decalLayerMask;
	}
}
