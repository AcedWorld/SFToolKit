using System;
using UnityEngine.Rendering;

namespace UnityEngine.Experimental.Rendering
{
	// Token: 0x020004E8 RID: 1256
	public struct RayTracingInstanceCullingConfig
	{
		// Token: 0x04001105 RID: 4357
		public RayTracingInstanceCullingFlags flags;

		// Token: 0x04001106 RID: 4358
		public Vector3 sphereCenter;

		// Token: 0x04001107 RID: 4359
		public float sphereRadius;

		// Token: 0x04001108 RID: 4360
		public Plane[] planes;

		// Token: 0x04001109 RID: 4361
		public RayTracingInstanceCullingTest[] instanceTests;

		// Token: 0x0400110A RID: 4362
		public RayTracingInstanceCullingMaterialTest materialTest;

		// Token: 0x0400110B RID: 4363
		public RayTracingInstanceMaterialConfig transparentMaterialConfig;

		// Token: 0x0400110C RID: 4364
		public RayTracingInstanceMaterialConfig alphaTestedMaterialConfig;

		// Token: 0x0400110D RID: 4365
		public RayTracingSubMeshFlagsConfig subMeshFlagsConfig;

		// Token: 0x0400110E RID: 4366
		public RayTracingInstanceTriangleCullingConfig triangleCullingConfig;

		// Token: 0x0400110F RID: 4367
		public LODParameters lodParameters;
	}
}
