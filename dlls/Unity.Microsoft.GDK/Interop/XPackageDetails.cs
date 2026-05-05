using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000262 RID: 610
	internal struct XPackageDetails
	{
		// Token: 0x0400083F RID: 2111
		[MarshalAs(UnmanagedType.LPStr)]
		internal string packageIdentifier;

		// Token: 0x04000840 RID: 2112
		internal XVersion version;

		// Token: 0x04000841 RID: 2113
		internal XPackageKind kind;

		// Token: 0x04000842 RID: 2114
		[MarshalAs(UnmanagedType.LPStr)]
		internal string displayName;

		// Token: 0x04000843 RID: 2115
		[MarshalAs(UnmanagedType.LPStr)]
		internal string description;

		// Token: 0x04000844 RID: 2116
		[MarshalAs(UnmanagedType.LPStr)]
		internal string publisher;

		// Token: 0x04000845 RID: 2117
		[MarshalAs(UnmanagedType.LPStr)]
		internal string storeId;

		// Token: 0x04000846 RID: 2118
		[MarshalAs(UnmanagedType.I1)]
		internal bool installing;
	}
}
