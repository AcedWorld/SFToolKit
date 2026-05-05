using System;

namespace Unity.Netcode
{
	// Token: 0x02000096 RID: 150
	internal interface IGroupRpcTarget
	{
		// Token: 0x0600031E RID: 798
		void Add(ulong clientId);

		// Token: 0x0600031F RID: 799
		void Clear();

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000320 RID: 800
		BaseRpcTarget Target { get; }
	}
}
