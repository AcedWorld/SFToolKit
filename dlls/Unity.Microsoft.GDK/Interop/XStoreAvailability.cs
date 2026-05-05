using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000272 RID: 626
	internal struct XStoreAvailability
	{
		// Token: 0x0400086B RID: 2155
		[MarshalAs(UnmanagedType.LPStr)]
		internal string availabilityId;

		// Token: 0x0400086C RID: 2156
		internal XStorePrice price;

		// Token: 0x0400086D RID: 2157
		internal long endDate;
	}
}
