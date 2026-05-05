using System;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x02000012 RID: 18
	public struct ConnectionEventData
	{
		// Token: 0x04000042 RID: 66
		public ConnectionEvent EventType;

		// Token: 0x04000043 RID: 67
		public ulong ClientId;

		// Token: 0x04000044 RID: 68
		public NativeArray<ulong> PeerClientIds;
	}
}
