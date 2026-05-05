using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000274 RID: 628
	internal struct XStoreSubscriptionInfo
	{
		// Token: 0x04000876 RID: 2166
		[MarshalAs(UnmanagedType.I1)]
		internal bool hasTrialPeriod;

		// Token: 0x04000877 RID: 2167
		internal XStoreDurationUnit trialPeriodUnit;

		// Token: 0x04000878 RID: 2168
		internal uint trialPeriod;

		// Token: 0x04000879 RID: 2169
		internal XStoreDurationUnit billingPeriodUnit;

		// Token: 0x0400087A RID: 2170
		internal uint billingPeriod;
	}
}
