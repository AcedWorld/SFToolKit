using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000259 RID: 601
	internal struct XNetworkingSecurityInformation
	{
		// Token: 0x0400082E RID: 2094
		internal uint enabledHttpSecurityProtocolFlags;

		// Token: 0x0400082F RID: 2095
		internal ulong thumbprintCount;

		// Token: 0x04000830 RID: 2096
		internal IntPtr thumbprints;
	}
}
