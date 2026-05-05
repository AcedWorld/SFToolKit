using System;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x02000441 RID: 1089
	[UsedByNativeCode]
	[NativeHeader("Runtime/Camera/BatchRendererGroup.h")]
	public struct CullingSplit
	{
		// Token: 0x04000D74 RID: 3444
		public Vector3 sphereCenter;

		// Token: 0x04000D75 RID: 3445
		public float sphereRadius;

		// Token: 0x04000D76 RID: 3446
		public int cullingPlaneOffset;

		// Token: 0x04000D77 RID: 3447
		public int cullingPlaneCount;

		// Token: 0x04000D78 RID: 3448
		public float cascadeBlendCullingFactor;

		// Token: 0x04000D79 RID: 3449
		public float nearPlane;

		// Token: 0x04000D7A RID: 3450
		public Matrix4x4 cullingMatrix;
	}
}
