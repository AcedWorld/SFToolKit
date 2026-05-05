using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000119 RID: 281
	[MovedFrom("Unity.GameCore")]
	public class XblUserStatisticsResult
	{
		// Token: 0x0600072B RID: 1835 RVA: 0x0000C878 File Offset: 0x0000AA78
		internal XblUserStatisticsResult(XblUserStatisticsResultInternal interopResult)
		{
			this.XboxUserId = interopResult.xboxUserId;
			this.ServiceConfigStatistics = interopResult.GetServiceConfigStatistics<XblServiceConfigurationStatistic>((XblServiceConfigurationStatisticInternal scs) => new XblServiceConfigurationStatistic(scs));
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x0600072C RID: 1836 RVA: 0x0000C8B8 File Offset: 0x0000AAB8
		// (set) Token: 0x0600072D RID: 1837 RVA: 0x0000C8C0 File Offset: 0x0000AAC0
		public ulong XboxUserId { get; private set; }

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x0600072E RID: 1838 RVA: 0x0000C8C9 File Offset: 0x0000AAC9
		// (set) Token: 0x0600072F RID: 1839 RVA: 0x0000C8D1 File Offset: 0x0000AAD1
		public XblServiceConfigurationStatistic[] ServiceConfigStatistics { get; private set; }
	}
}
