using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020002A4 RID: 676
	public struct XblUserStatisticsResult
	{
		// Token: 0x040008E7 RID: 2279
		public ulong xboxUserId;

		// Token: 0x040008E8 RID: 2280
		public unsafe XblServiceConfigurationStatistic* serviceConfigStatistics;

		// Token: 0x040008E9 RID: 2281
		public uint serviceConfigStatisticsCount;
	}
}
