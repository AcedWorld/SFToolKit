using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000110 RID: 272
	[MovedFrom("Unity.GameCore")]
	public class XblRequestedStatistics
	{
		// Token: 0x06000703 RID: 1795 RVA: 0x0000C6BB File Offset: 0x0000A8BB
		private XblRequestedStatistics(string serviceConfigurationId, string[] statistics)
		{
			this.ServiceConfigurationId = serviceConfigurationId;
			this.Statistics = statistics;
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x0000C6D1 File Offset: 0x0000A8D1
		public static int Create(string serviceConfigurationId, string[] statistics, out XblRequestedStatistics requestedStatistics)
		{
			if (!XblRequestedStatisticsInternal.ValidateFields(serviceConfigurationId))
			{
				requestedStatistics = null;
				return -2147024809;
			}
			requestedStatistics = new XblRequestedStatistics(serviceConfigurationId, statistics);
			return 0;
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000705 RID: 1797 RVA: 0x0000C6EE File Offset: 0x0000A8EE
		// (set) Token: 0x06000706 RID: 1798 RVA: 0x0000C6F6 File Offset: 0x0000A8F6
		public string ServiceConfigurationId { get; private set; }

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06000707 RID: 1799 RVA: 0x0000C6FF File Offset: 0x0000A8FF
		// (set) Token: 0x06000708 RID: 1800 RVA: 0x0000C707 File Offset: 0x0000A907
		public string[] Statistics { get; private set; }
	}
}
