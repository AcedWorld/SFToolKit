using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000111 RID: 273
	[MovedFrom("Unity.GameCore")]
	public class XblServiceConfigurationStatistic
	{
		// Token: 0x06000709 RID: 1801 RVA: 0x0000C710 File Offset: 0x0000A910
		internal XblServiceConfigurationStatistic(XblServiceConfigurationStatisticInternal interopStatistic)
		{
			this.ServiceConfigurationId = Converters.ByteArrayToString(interopStatistic.serviceConfigurationId);
			this.Statistics = interopStatistic.GetStatistics<XblStatistic>((XblStatisticInternal s) => new XblStatistic(s));
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x0600070A RID: 1802 RVA: 0x0000C760 File Offset: 0x0000A960
		// (set) Token: 0x0600070B RID: 1803 RVA: 0x0000C768 File Offset: 0x0000A968
		public string ServiceConfigurationId { get; private set; }

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x0600070C RID: 1804 RVA: 0x0000C771 File Offset: 0x0000A971
		// (set) Token: 0x0600070D RID: 1805 RVA: 0x0000C779 File Offset: 0x0000A979
		public XblStatistic[] Statistics { get; private set; }
	}
}
