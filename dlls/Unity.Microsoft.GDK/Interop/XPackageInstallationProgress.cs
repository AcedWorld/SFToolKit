using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000261 RID: 609
	internal struct XPackageInstallationProgress
	{
		// Token: 0x0400083A RID: 2106
		internal ulong totalBytes;

		// Token: 0x0400083B RID: 2107
		internal ulong installedBytes;

		// Token: 0x0400083C RID: 2108
		internal ulong launchBytes;

		// Token: 0x0400083D RID: 2109
		[MarshalAs(UnmanagedType.I1)]
		internal bool launchable;

		// Token: 0x0400083E RID: 2110
		[MarshalAs(UnmanagedType.I1)]
		internal bool completed;
	}
}
