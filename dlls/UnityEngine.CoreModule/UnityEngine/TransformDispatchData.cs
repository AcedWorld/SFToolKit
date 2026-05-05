using System;
using Unity.Collections;

namespace UnityEngine
{
	// Token: 0x020001FA RID: 506
	internal struct TransformDispatchData : IDisposable
	{
		// Token: 0x06001719 RID: 5913 RVA: 0x00026690 File Offset: 0x00024890
		public void Dispose()
		{
			this.transformedID.Dispose();
			this.parentID.Dispose();
			this.localToWorldMatrices.Dispose();
			this.positions.Dispose();
			this.rotations.Dispose();
			this.scales.Dispose();
		}

		// Token: 0x04000844 RID: 2116
		public NativeArray<int> transformedID;

		// Token: 0x04000845 RID: 2117
		public NativeArray<int> parentID;

		// Token: 0x04000846 RID: 2118
		public NativeArray<Matrix4x4> localToWorldMatrices;

		// Token: 0x04000847 RID: 2119
		public NativeArray<Vector3> positions;

		// Token: 0x04000848 RID: 2120
		public NativeArray<Quaternion> rotations;

		// Token: 0x04000849 RID: 2121
		public NativeArray<Vector3> scales;
	}
}
