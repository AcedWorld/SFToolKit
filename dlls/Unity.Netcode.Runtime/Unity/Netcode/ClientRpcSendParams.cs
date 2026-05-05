using System;
using System.Collections.Generic;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x0200008E RID: 142
	public struct ClientRpcSendParams
	{
		// Token: 0x040001C2 RID: 450
		public IReadOnlyList<ulong> TargetClientIds;

		// Token: 0x040001C3 RID: 451
		public NativeArray<ulong>? TargetClientIdsNativeArray;
	}
}
