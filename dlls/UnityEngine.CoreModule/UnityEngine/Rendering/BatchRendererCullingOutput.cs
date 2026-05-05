using System;
using Unity.Jobs;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x02000444 RID: 1092
	[NativeHeader("Runtime/Camera/BatchRendererGroup.h")]
	[UsedByNativeCode]
	internal struct BatchRendererCullingOutput
	{
		// Token: 0x04000D89 RID: 3465
		public JobHandle cullingJobsFence;

		// Token: 0x04000D8A RID: 3466
		public Matrix4x4 localToWorldMatrix;

		// Token: 0x04000D8B RID: 3467
		public unsafe Plane* cullingPlanes;

		// Token: 0x04000D8C RID: 3468
		public int cullingPlaneCount;

		// Token: 0x04000D8D RID: 3469
		public int receiverPlaneOffset;

		// Token: 0x04000D8E RID: 3470
		public int receiverPlaneCount;

		// Token: 0x04000D8F RID: 3471
		public unsafe CullingSplit* cullingSplits;

		// Token: 0x04000D90 RID: 3472
		public int cullingSplitCount;

		// Token: 0x04000D91 RID: 3473
		public BatchCullingViewType viewType;

		// Token: 0x04000D92 RID: 3474
		public BatchCullingProjectionType projectionType;

		// Token: 0x04000D93 RID: 3475
		public BatchCullingFlags cullingFlags;

		// Token: 0x04000D94 RID: 3476
		public ulong viewID;

		// Token: 0x04000D95 RID: 3477
		public uint cullingLayerMask;

		// Token: 0x04000D96 RID: 3478
		public ulong sceneCullingMask;

		// Token: 0x04000D97 RID: 3479
		public unsafe BatchCullingOutputDrawCommands* drawCommands;
	}
}
