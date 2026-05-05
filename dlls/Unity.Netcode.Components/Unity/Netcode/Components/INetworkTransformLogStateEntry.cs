using System;

namespace Unity.Netcode.Components
{
	// Token: 0x02000024 RID: 36
	internal interface INetworkTransformLogStateEntry
	{
		// Token: 0x06000145 RID: 325
		void AddLogEntry(NetworkTransform.NetworkTransformState networkTransformState, ulong targetClient, bool preUpdate = false);
	}
}
