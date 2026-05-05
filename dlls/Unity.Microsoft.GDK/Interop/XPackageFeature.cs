using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000263 RID: 611
	internal struct XPackageFeature
	{
		// Token: 0x04000847 RID: 2119
		[MarshalAs(UnmanagedType.LPStr)]
		internal string id;

		// Token: 0x04000848 RID: 2120
		[MarshalAs(UnmanagedType.LPStr)]
		internal string displayName;

		// Token: 0x04000849 RID: 2121
		[MarshalAs(UnmanagedType.LPStr)]
		internal string tags;

		// Token: 0x0400084A RID: 2122
		[MarshalAs(UnmanagedType.I1)]
		internal bool hidden;

		// Token: 0x0400084B RID: 2123
		internal uint storeIdCount;

		// Token: 0x0400084C RID: 2124
		internal IntPtr storeIds;
	}
}
