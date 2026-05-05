using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000238 RID: 568
	internal struct XblStatisticChangeEventArgsInternal
	{
		// Token: 0x040007EB RID: 2027
		internal readonly ulong xboxUserId;

		// Token: 0x040007EC RID: 2028
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
		internal readonly byte[] serviceConfigurationId;

		// Token: 0x040007ED RID: 2029
		internal readonly XblStatisticInternal latestStatistic;
	}
}
