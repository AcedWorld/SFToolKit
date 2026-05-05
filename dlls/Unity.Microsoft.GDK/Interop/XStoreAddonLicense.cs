using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000279 RID: 633
	internal struct XStoreAddonLicense
	{
		// Token: 0x040008A6 RID: 2214
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
		internal string skuStoreId;

		// Token: 0x040008A7 RID: 2215
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
		internal string inAppOfferToken;

		// Token: 0x040008A8 RID: 2216
		[MarshalAs(UnmanagedType.I1)]
		internal bool isActive;

		// Token: 0x040008A9 RID: 2217
		internal long expirationDate;
	}
}
