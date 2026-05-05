using System;

namespace UnityEngine.Experimental.Rendering
{
	// Token: 0x020004E2 RID: 1250
	public struct RayTracingInstanceCullingTest
	{
		// Token: 0x040010F0 RID: 4336
		public uint instanceMask;

		// Token: 0x040010F1 RID: 4337
		public int layerMask;

		// Token: 0x040010F2 RID: 4338
		public int shadowCastingModeMask;

		// Token: 0x040010F3 RID: 4339
		public bool allowOpaqueMaterials;

		// Token: 0x040010F4 RID: 4340
		public bool allowTransparentMaterials;

		// Token: 0x040010F5 RID: 4341
		public bool allowAlphaTestedMaterials;
	}
}
