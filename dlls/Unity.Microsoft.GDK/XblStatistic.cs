using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000112 RID: 274
	[MovedFrom("Unity.GameCore")]
	public class XblStatistic
	{
		// Token: 0x0600070E RID: 1806 RVA: 0x0000C784 File Offset: 0x0000A984
		internal XblStatistic(XblStatisticInternal interopStatistic)
		{
			this.StatisticName = interopStatistic.statisticName.GetString();
			this.StatisticType = interopStatistic.statisticType.GetString();
			this.Value = interopStatistic.value.GetString();
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x0000C7D3 File Offset: 0x0000A9D3
		internal unsafe XblStatistic(XblStatistic interopStatistic)
		{
			this.StatisticName = Converters.NullTerminatedBytePointerToString((byte*)interopStatistic.statisticName);
			this.StatisticType = Converters.NullTerminatedBytePointerToString((byte*)interopStatistic.statisticType);
			this.Value = Converters.NullTerminatedBytePointerToString((byte*)interopStatistic.value);
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000710 RID: 1808 RVA: 0x0000C80E File Offset: 0x0000AA0E
		// (set) Token: 0x06000711 RID: 1809 RVA: 0x0000C816 File Offset: 0x0000AA16
		public string StatisticName { get; private set; }

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000712 RID: 1810 RVA: 0x0000C81F File Offset: 0x0000AA1F
		// (set) Token: 0x06000713 RID: 1811 RVA: 0x0000C827 File Offset: 0x0000AA27
		public string StatisticType { get; private set; }

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000714 RID: 1812 RVA: 0x0000C830 File Offset: 0x0000AA30
		// (set) Token: 0x06000715 RID: 1813 RVA: 0x0000C838 File Offset: 0x0000AA38
		public string Value { get; private set; }
	}
}
