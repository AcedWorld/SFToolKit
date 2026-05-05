using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000246 RID: 582
	internal struct XGameSaveContainerInfo
	{
		// Token: 0x040007FD RID: 2045
		[MarshalAs(UnmanagedType.LPStr)]
		internal string name;

		// Token: 0x040007FE RID: 2046
		[MarshalAs(UnmanagedType.LPStr)]
		internal string displayName;

		// Token: 0x040007FF RID: 2047
		internal uint blobCount;

		// Token: 0x04000800 RID: 2048
		internal ulong totalSize;

		// Token: 0x04000801 RID: 2049
		internal long lastModifiedTime;

		// Token: 0x04000802 RID: 2050
		[MarshalAs(UnmanagedType.I1)]
		internal bool needsSync;
	}
}
