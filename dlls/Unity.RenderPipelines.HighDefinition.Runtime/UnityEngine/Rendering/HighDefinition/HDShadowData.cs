using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000CB RID: 203
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\Shadow\\HDShadowManager.cs", needAccessors = false)]
	internal struct HDShadowData
	{
		// Token: 0x040008B1 RID: 2225
		public Vector3 rot0;

		// Token: 0x040008B2 RID: 2226
		public Vector3 rot1;

		// Token: 0x040008B3 RID: 2227
		public Vector3 rot2;

		// Token: 0x040008B4 RID: 2228
		public Vector3 pos;

		// Token: 0x040008B5 RID: 2229
		public Vector4 proj;

		// Token: 0x040008B6 RID: 2230
		public Vector2 atlasOffset;

		// Token: 0x040008B7 RID: 2231
		public float worldTexelSize;

		// Token: 0x040008B8 RID: 2232
		public float normalBias;

		// Token: 0x040008B9 RID: 2233
		[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
		public Vector4 zBufferParam;

		// Token: 0x040008BA RID: 2234
		public Vector4 shadowMapSize;

		// Token: 0x040008BB RID: 2235
		public Vector4 shadowFilterParams0;

		// Token: 0x040008BC RID: 2236
		public Vector3 cacheTranslationDelta;

		// Token: 0x040008BD RID: 2237
		public float isInCachedAtlas;

		// Token: 0x040008BE RID: 2238
		public Matrix4x4 shadowToWorld;
	}
}
