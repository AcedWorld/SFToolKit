using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200027B RID: 635
	internal struct XStorePackageUpdate
	{
		// Token: 0x040008AB RID: 2219
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
		internal string packageIdentifier;

		// Token: 0x040008AC RID: 2220
		[MarshalAs(UnmanagedType.I1)]
		internal bool isMandatory;
	}
}
