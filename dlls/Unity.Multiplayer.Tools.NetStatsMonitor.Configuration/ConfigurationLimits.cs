using System;

namespace Unity.Multiplayer.Tools.NetStatsMonitor
{
	// Token: 0x02000003 RID: 3
	internal static class ConfigurationLimits
	{
		// Token: 0x04000001 RID: 1
		internal const int k_GraphSampleMin = 8;

		// Token: 0x04000002 RID: 2
		internal const int k_GraphSampleMax = 4096;

		// Token: 0x04000003 RID: 3
		internal const int k_CounterSampleMin = 8;

		// Token: 0x04000004 RID: 4
		internal const int k_CounterSampleMax = 4096;

		// Token: 0x04000005 RID: 5
		internal const int k_CounterSignificantDigitsMin = 1;

		// Token: 0x04000006 RID: 6
		internal const int k_CounterSignificantDigitsMax = 7;

		// Token: 0x04000007 RID: 7
		internal const double k_ExponentialMovingAverageHalfLifeMin = 0.0;

		// Token: 0x04000008 RID: 8
		internal const double k_RefreshRateMin = 1.0;

		// Token: 0x04000009 RID: 9
		internal const float k_PositionMin = 0f;

		// Token: 0x0400000A RID: 10
		internal const float k_PositionMax = 1f;

		// Token: 0x0400000B RID: 11
		internal const float k_GraphLineThicknessMin = 1f;

		// Token: 0x0400000C RID: 12
		internal const float k_GraphLineThicknessMax = 5f;
	}
}
