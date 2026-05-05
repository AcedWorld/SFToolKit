using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000113 RID: 275
	public struct XblStatisticChangeEventArgs
	{
		// Token: 0x06000716 RID: 1814 RVA: 0x0000C841 File Offset: 0x0000AA41
		internal unsafe XblStatisticChangeEventArgs(XblStatisticChangeEventArgs interopStruct)
		{
			this.xboxUserId = interopStruct.xboxUserId;
			this.serviceConfigurationId = new string(&interopStruct.serviceConfigurationId.FixedElementField);
			this.latestStatistic = new XblStatistic(interopStruct.latestStatistic);
		}

		// Token: 0x04000427 RID: 1063
		public ulong xboxUserId;

		// Token: 0x04000428 RID: 1064
		public string serviceConfigurationId;

		// Token: 0x04000429 RID: 1065
		public XblStatistic latestStatistic;
	}
}
