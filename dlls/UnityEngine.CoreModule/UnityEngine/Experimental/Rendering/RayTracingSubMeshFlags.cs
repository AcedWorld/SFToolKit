using System;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Experimental.Rendering
{
	// Token: 0x020004E0 RID: 1248
	[Flags]
	[NativeHeader("Runtime/Export/Graphics/RayTracingAccelerationStructure.bindings.h")]
	[NativeHeader("Runtime/Shaders/RayTracingAccelerationStructure.h")]
	[UsedByNativeCode]
	public enum RayTracingSubMeshFlags
	{
		// Token: 0x040010E5 RID: 4325
		Disabled = 0,
		// Token: 0x040010E6 RID: 4326
		Enabled = 1,
		// Token: 0x040010E7 RID: 4327
		ClosestHitOnly = 2,
		// Token: 0x040010E8 RID: 4328
		UniqueAnyHitCalls = 4
	}
}
