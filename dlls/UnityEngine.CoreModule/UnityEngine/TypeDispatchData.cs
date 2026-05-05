using System;
using Unity.Collections;

namespace UnityEngine
{
	// Token: 0x020001F9 RID: 505
	internal struct TypeDispatchData : IDisposable
	{
		// Token: 0x06001718 RID: 5912 RVA: 0x0002666D File Offset: 0x0002486D
		public void Dispose()
		{
			this.changed = null;
			this.changedID.Dispose();
			this.destroyedID.Dispose();
		}

		// Token: 0x04000841 RID: 2113
		public Object[] changed;

		// Token: 0x04000842 RID: 2114
		public NativeArray<int> changedID;

		// Token: 0x04000843 RID: 2115
		public NativeArray<int> destroyedID;
	}
}
