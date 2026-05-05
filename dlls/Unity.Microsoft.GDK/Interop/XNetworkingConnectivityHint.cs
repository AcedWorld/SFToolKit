using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000257 RID: 599
	internal struct XNetworkingConnectivityHint
	{
		// Token: 0x04000824 RID: 2084
		internal XNetworkingConnectivityLevelHint connectivityLevel;

		// Token: 0x04000825 RID: 2085
		internal XNetworkingConnectivityCostHint connectivityCost;

		// Token: 0x04000826 RID: 2086
		internal uint ianaInterfaceType;

		// Token: 0x04000827 RID: 2087
		[MarshalAs(UnmanagedType.I1)]
		internal bool networkInitialized;

		// Token: 0x04000828 RID: 2088
		[MarshalAs(UnmanagedType.I1)]
		internal bool approachingDataLimit;

		// Token: 0x04000829 RID: 2089
		[MarshalAs(UnmanagedType.I1)]
		internal bool overDataLimit;

		// Token: 0x0400082A RID: 2090
		[MarshalAs(UnmanagedType.I1)]
		internal bool roaming;
	}
}
