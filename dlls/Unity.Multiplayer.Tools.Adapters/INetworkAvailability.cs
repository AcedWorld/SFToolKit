using System;

namespace Unity.Multiplayer.Tools.Adapters
{
	// Token: 0x02000014 RID: 20
	internal interface INetworkAvailability : IAdapterComponent
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001B RID: 27
		bool IsConnected { get; }
	}
}
