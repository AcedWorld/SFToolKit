using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200004E RID: 78
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Debug\\RayCountManager.cs")]
	public enum RayCountValues
	{
		// Token: 0x04000237 RID: 567
		AmbientOcclusion,
		// Token: 0x04000238 RID: 568
		ShadowDirectional,
		// Token: 0x04000239 RID: 569
		ShadowPointSpot,
		// Token: 0x0400023A RID: 570
		ShadowAreaLight,
		// Token: 0x0400023B RID: 571
		DiffuseGI_Forward,
		// Token: 0x0400023C RID: 572
		DiffuseGI_Deferred,
		// Token: 0x0400023D RID: 573
		ReflectionForward,
		// Token: 0x0400023E RID: 574
		ReflectionDeferred,
		// Token: 0x0400023F RID: 575
		Recursive,
		// Token: 0x04000240 RID: 576
		Count,
		// Token: 0x04000241 RID: 577
		Total
	}
}
