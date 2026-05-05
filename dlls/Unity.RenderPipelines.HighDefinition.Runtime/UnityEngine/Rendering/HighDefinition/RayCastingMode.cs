using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000180 RID: 384
	public enum RayCastingMode
	{
		// Token: 0x04001358 RID: 4952
		[InspectorName("Ray Marching")]
		RayMarching = 1,
		// Token: 0x04001359 RID: 4953
		[InspectorName("Ray Tracing (Preview)")]
		RayTracing,
		// Token: 0x0400135A RID: 4954
		[InspectorName("Mixed (Preview)")]
		Mixed = 4
	}
}
