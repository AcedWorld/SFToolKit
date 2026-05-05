using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200026F RID: 623
	internal struct XStoreCanAcquireLicenseResult
	{
		// Token: 0x0400085B RID: 2139
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
		internal string licensableSku;

		// Token: 0x0400085C RID: 2140
		internal XStoreCanLicenseStatus status;
	}
}
