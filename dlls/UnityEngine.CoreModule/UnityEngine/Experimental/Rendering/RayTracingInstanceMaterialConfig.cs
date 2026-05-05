using System;

namespace UnityEngine.Experimental.Rendering
{
	// Token: 0x020004E4 RID: 1252
	public struct RayTracingInstanceMaterialConfig
	{
		// Token: 0x040010F8 RID: 4344
		public int renderQueueLowerBound;

		// Token: 0x040010F9 RID: 4345
		public int renderQueueUpperBound;

		// Token: 0x040010FA RID: 4346
		public RayTracingInstanceCullingShaderTagConfig[] optionalShaderTags;

		// Token: 0x040010FB RID: 4347
		public string[] optionalShaderKeywords;
	}
}
