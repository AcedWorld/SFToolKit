using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000454 RID: 1108
	internal struct CullingAllocationInfo
	{
		// Token: 0x04000E01 RID: 3585
		public unsafe VisibleLight* visibleLightsPtr;

		// Token: 0x04000E02 RID: 3586
		public unsafe VisibleLight* visibleOffscreenVertexLightsPtr;

		// Token: 0x04000E03 RID: 3587
		public unsafe VisibleReflectionProbe* visibleReflectionProbesPtr;

		// Token: 0x04000E04 RID: 3588
		public int visibleLightCount;

		// Token: 0x04000E05 RID: 3589
		public int visibleOffscreenVertexLightCount;

		// Token: 0x04000E06 RID: 3590
		public int visibleReflectionProbeCount;
	}
}
