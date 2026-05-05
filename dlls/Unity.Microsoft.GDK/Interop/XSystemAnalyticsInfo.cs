using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000284 RID: 644
	internal struct XSystemAnalyticsInfo
	{
		// Token: 0x040008BD RID: 2237
		internal XVersion osVersion;

		// Token: 0x040008BE RID: 2238
		internal XVersion hostingOsVersion;

		// Token: 0x040008BF RID: 2239
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
		internal string family;

		// Token: 0x040008C0 RID: 2240
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
		internal string form;
	}
}
