using System;

namespace Unity.Multiplayer.Tools.NetStatsMonitor
{
	// Token: 0x02000012 RID: 18
	internal static class SampleRateExtensions
	{
		// Token: 0x06000058 RID: 88 RVA: 0x00002AF3 File Offset: 0x00000CF3
		public static SampleRate Next(this SampleRate rate)
		{
			return rate + 1;
		}
	}
}
