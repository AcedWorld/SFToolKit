using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000273 RID: 627
	internal struct XStoreCollectionData
	{
		// Token: 0x0400086E RID: 2158
		internal long acquiredDate;

		// Token: 0x0400086F RID: 2159
		internal long startDate;

		// Token: 0x04000870 RID: 2160
		internal long endDate;

		// Token: 0x04000871 RID: 2161
		[MarshalAs(UnmanagedType.I1)]
		internal bool isTrial;

		// Token: 0x04000872 RID: 2162
		internal uint trialTimeRemainingInSeconds;

		// Token: 0x04000873 RID: 2163
		internal uint quantity;

		// Token: 0x04000874 RID: 2164
		[MarshalAs(UnmanagedType.LPStr)]
		internal string campaignId;

		// Token: 0x04000875 RID: 2165
		[MarshalAs(UnmanagedType.LPStr)]
		internal string developerOfferId;
	}
}
