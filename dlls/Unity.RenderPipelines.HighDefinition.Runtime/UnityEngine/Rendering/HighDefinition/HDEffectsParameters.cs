using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200017A RID: 378
	public struct HDEffectsParameters
	{
		// Token: 0x04001320 RID: 4896
		public bool shadows;

		// Token: 0x04001321 RID: 4897
		public bool ambientOcclusion;

		// Token: 0x04001322 RID: 4898
		public int aoLayerMask;

		// Token: 0x04001323 RID: 4899
		public bool reflections;

		// Token: 0x04001324 RID: 4900
		public int reflLayerMask;

		// Token: 0x04001325 RID: 4901
		public bool globalIllumination;

		// Token: 0x04001326 RID: 4902
		public int giLayerMask;

		// Token: 0x04001327 RID: 4903
		public bool recursiveRendering;

		// Token: 0x04001328 RID: 4904
		public int recursiveLayerMask;

		// Token: 0x04001329 RID: 4905
		public bool subSurface;

		// Token: 0x0400132A RID: 4906
		public bool pathTracing;

		// Token: 0x0400132B RID: 4907
		public int ptLayerMask;

		// Token: 0x0400132C RID: 4908
		public bool rayTracingRequired;
	}
}
