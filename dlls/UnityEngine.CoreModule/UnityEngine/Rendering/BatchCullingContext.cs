using System;
using Unity.Collections;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x02000442 RID: 1090
	[NativeHeader("Runtime/Camera/BatchRendererGroup.h")]
	[UsedByNativeCode]
	public struct BatchCullingContext
	{
		// Token: 0x06002463 RID: 9315 RVA: 0x0003D25C File Offset: 0x0003B45C
		internal BatchCullingContext(NativeArray<Plane> inCullingPlanes, NativeArray<CullingSplit> inCullingSplits, LODParameters inLodParameters, Matrix4x4 inLocalToWorldMatrix, BatchCullingViewType inViewType, BatchCullingProjectionType inProjectionType, BatchCullingFlags inBatchCullingFlags, ulong inViewID, uint inCullingLayerMask, ulong inSceneCullingMask, int inReceiverPlaneOffset, int inReceiverPlaneCount)
		{
			this.cullingPlanes = inCullingPlanes;
			this.cullingSplits = inCullingSplits;
			this.lodParameters = inLodParameters;
			this.localToWorldMatrix = inLocalToWorldMatrix;
			this.viewType = inViewType;
			this.projectionType = inProjectionType;
			this.cullingFlags = inBatchCullingFlags;
			this.viewID = new BatchPackedCullingViewID
			{
				handle = inViewID
			};
			this.cullingLayerMask = inCullingLayerMask;
			this.sceneCullingMask = inSceneCullingMask;
			this.receiverPlaneOffset = inReceiverPlaneOffset;
			this.receiverPlaneCount = inReceiverPlaneCount;
			this.isOrthographic = 0;
		}

		// Token: 0x04000D7B RID: 3451
		public readonly NativeArray<Plane> cullingPlanes;

		// Token: 0x04000D7C RID: 3452
		public readonly NativeArray<CullingSplit> cullingSplits;

		// Token: 0x04000D7D RID: 3453
		public readonly LODParameters lodParameters;

		// Token: 0x04000D7E RID: 3454
		public readonly Matrix4x4 localToWorldMatrix;

		// Token: 0x04000D7F RID: 3455
		public readonly BatchCullingViewType viewType;

		// Token: 0x04000D80 RID: 3456
		public readonly BatchCullingProjectionType projectionType;

		// Token: 0x04000D81 RID: 3457
		public readonly BatchCullingFlags cullingFlags;

		// Token: 0x04000D82 RID: 3458
		public readonly BatchPackedCullingViewID viewID;

		// Token: 0x04000D83 RID: 3459
		public readonly uint cullingLayerMask;

		// Token: 0x04000D84 RID: 3460
		public readonly ulong sceneCullingMask;

		// Token: 0x04000D85 RID: 3461
		[Obsolete("BatchCullingContext.isOrthographic is deprecated. Use BatchCullingContext.projectionType instead.")]
		public readonly byte isOrthographic;

		// Token: 0x04000D86 RID: 3462
		public readonly int receiverPlaneOffset;

		// Token: 0x04000D87 RID: 3463
		public readonly int receiverPlaneCount;
	}
}
