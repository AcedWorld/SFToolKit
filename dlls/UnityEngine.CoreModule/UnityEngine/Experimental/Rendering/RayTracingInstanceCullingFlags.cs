using System;

namespace UnityEngine.Experimental.Rendering
{
	// Token: 0x020004E1 RID: 1249
	[Flags]
	public enum RayTracingInstanceCullingFlags
	{
		// Token: 0x040010EA RID: 4330
		None = 0,
		// Token: 0x040010EB RID: 4331
		EnableSphereCulling = 1,
		// Token: 0x040010EC RID: 4332
		EnablePlaneCulling = 2,
		// Token: 0x040010ED RID: 4333
		EnableLODCulling = 4,
		// Token: 0x040010EE RID: 4334
		ComputeMaterialsCRC = 8,
		// Token: 0x040010EF RID: 4335
		IgnoreReflectionProbes = 16
	}
}
