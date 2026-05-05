using System;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x0200001B RID: 27
	internal interface INetworkConfiguration
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000083 RID: 131
		int Retries { get; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000084 RID: 132
		int Timeout { get; }
	}
}
