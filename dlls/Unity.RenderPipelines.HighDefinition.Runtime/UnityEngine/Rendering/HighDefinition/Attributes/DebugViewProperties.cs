using System;

namespace UnityEngine.Rendering.HighDefinition.Attributes
{
	// Token: 0x02000238 RID: 568
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Debug\\MaterialDebug.cs")]
	public enum DebugViewProperties
	{
		// Token: 0x0400195D RID: 6493
		None,
		// Token: 0x0400195E RID: 6494
		Tessellation = 16,
		// Token: 0x0400195F RID: 6495
		PixelDisplacement,
		// Token: 0x04001960 RID: 6496
		VertexDisplacement,
		// Token: 0x04001961 RID: 6497
		TessellationDisplacement,
		// Token: 0x04001962 RID: 6498
		DepthOffset,
		// Token: 0x04001963 RID: 6499
		Lightmap,
		// Token: 0x04001964 RID: 6500
		Instancing,
		// Token: 0x04001965 RID: 6501
		DeferredMaterials
	}
}
