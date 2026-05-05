using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000CD RID: 205
	internal class HDShadowRequest
	{
		// Token: 0x040008C4 RID: 2244
		public Matrix4x4 view;

		// Token: 0x040008C5 RID: 2245
		public Matrix4x4 deviceProjectionYFlip;

		// Token: 0x040008C6 RID: 2246
		public Matrix4x4 deviceProjection;

		// Token: 0x040008C7 RID: 2247
		public Matrix4x4 projection;

		// Token: 0x040008C8 RID: 2248
		public BatchCullingProjectionType projectionType;

		// Token: 0x040008C9 RID: 2249
		public Matrix4x4 shadowToWorld;

		// Token: 0x040008CA RID: 2250
		public Vector3 position;

		// Token: 0x040008CB RID: 2251
		public Vector4 zBufferParam;

		// Token: 0x040008CC RID: 2252
		public Rect dynamicAtlasViewport;

		// Token: 0x040008CD RID: 2253
		public Rect cachedAtlasViewport;

		// Token: 0x040008CE RID: 2254
		public bool zClip;

		// Token: 0x040008CF RID: 2255
		public Vector4[] frustumPlanes;

		// Token: 0x040008D0 RID: 2256
		public int shadowIndex;

		// Token: 0x040008D1 RID: 2257
		public ShadowMapType shadowMapType = ShadowMapType.PunctualAtlas;

		// Token: 0x040008D2 RID: 2258
		public int lightIndex;

		// Token: 0x040008D3 RID: 2259
		public ShadowSplitData splitData;

		// Token: 0x040008D4 RID: 2260
		public float normalBias;

		// Token: 0x040008D5 RID: 2261
		public float worldTexelSize;

		// Token: 0x040008D6 RID: 2262
		public float slopeBias;

		// Token: 0x040008D7 RID: 2263
		public float shadowSoftness;

		// Token: 0x040008D8 RID: 2264
		public int blockerSampleCount;

		// Token: 0x040008D9 RID: 2265
		public int filterSampleCount;

		// Token: 0x040008DA RID: 2266
		public float minFilterSize;

		// Token: 0x040008DB RID: 2267
		public float kernelSize;

		// Token: 0x040008DC RID: 2268
		public float lightAngle;

		// Token: 0x040008DD RID: 2269
		public float maxDepthBias;

		// Token: 0x040008DE RID: 2270
		public Vector4 evsmParams;

		// Token: 0x040008DF RID: 2271
		public bool shouldUseCachedShadowData;

		// Token: 0x040008E0 RID: 2272
		public bool shouldRenderCachedComponent;

		// Token: 0x040008E1 RID: 2273
		public HDShadowData cachedShadowData;

		// Token: 0x040008E2 RID: 2274
		public bool isInCachedAtlas;

		// Token: 0x040008E3 RID: 2275
		public bool isMixedCached;
	}
}
