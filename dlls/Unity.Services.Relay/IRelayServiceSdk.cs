using System;
using Unity.Services.Authentication.Internal;
using Unity.Services.Qos.Internal;
using Unity.Services.Relay.Apis.RelayAllocations;

namespace Unity.Services.Relay
{
	// Token: 0x0200000B RID: 11
	internal interface IRelayServiceSdk
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001D RID: 29
		// (set) Token: 0x0600001E RID: 30
		IRelayAllocationsApiClient AllocationsApi { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001F RID: 31
		// (set) Token: 0x06000020 RID: 32
		Configuration Configuration { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000021 RID: 33
		// (set) Token: 0x06000022 RID: 34
		IAccessToken AccessToken { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000023 RID: 35
		// (set) Token: 0x06000024 RID: 36
		IQosResults QosResults { get; set; }
	}
}
