using System;

namespace Unity.Services.Authentication
{
	// Token: 0x02000041 RID: 65
	internal interface INetworkConfiguration
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000196 RID: 406
		int Retries { get; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000197 RID: 407
		int Timeout { get; }
	}
}
