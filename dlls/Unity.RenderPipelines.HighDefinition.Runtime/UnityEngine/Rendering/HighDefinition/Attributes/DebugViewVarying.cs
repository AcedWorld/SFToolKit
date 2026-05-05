using System;

namespace UnityEngine.Rendering.HighDefinition.Attributes
{
	// Token: 0x02000236 RID: 566
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Debug\\MaterialDebug.cs")]
	public enum DebugViewVarying
	{
		// Token: 0x0400194A RID: 6474
		None,
		// Token: 0x0400194B RID: 6475
		Texcoord0,
		// Token: 0x0400194C RID: 6476
		Texcoord1,
		// Token: 0x0400194D RID: 6477
		Texcoord2,
		// Token: 0x0400194E RID: 6478
		Texcoord3,
		// Token: 0x0400194F RID: 6479
		VertexTangentWS,
		// Token: 0x04001950 RID: 6480
		VertexBitangentWS,
		// Token: 0x04001951 RID: 6481
		VertexNormalWS,
		// Token: 0x04001952 RID: 6482
		VertexColor,
		// Token: 0x04001953 RID: 6483
		VertexColorAlpha
	}
}
