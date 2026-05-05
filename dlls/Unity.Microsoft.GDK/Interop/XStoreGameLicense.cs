using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200027C RID: 636
	internal struct XStoreGameLicense
	{
		// Token: 0x040008AD RID: 2221
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
		internal string skuStoreId;

		// Token: 0x040008AE RID: 2222
		[MarshalAs(UnmanagedType.I1)]
		internal bool isActive;

		// Token: 0x040008AF RID: 2223
		[MarshalAs(UnmanagedType.I1)]
		internal bool isTrialOwnedByThisUser;

		// Token: 0x040008B0 RID: 2224
		[MarshalAs(UnmanagedType.I1)]
		internal bool isDiscLicense;

		// Token: 0x040008B1 RID: 2225
		[MarshalAs(UnmanagedType.I1)]
		internal bool isTrial;

		// Token: 0x040008B2 RID: 2226
		internal uint trialTimeRemainingInSeconds;

		// Token: 0x040008B3 RID: 2227
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
		internal string trialUniqueId;

		// Token: 0x040008B4 RID: 2228
		internal long expirationDate;
	}
}
