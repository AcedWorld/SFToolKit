using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000102 RID: 258
	[MovedFrom("Unity.GameCore")]
	public class XblTitleManagedStatistic
	{
		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x060006C1 RID: 1729 RVA: 0x0000C445 File Offset: 0x0000A645
		// (set) Token: 0x060006C2 RID: 1730 RVA: 0x0000C44D File Offset: 0x0000A64D
		public string StatisticName { get; set; }

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x060006C3 RID: 1731 RVA: 0x0000C456 File Offset: 0x0000A656
		// (set) Token: 0x060006C4 RID: 1732 RVA: 0x0000C45E File Offset: 0x0000A65E
		public XblTitleManagedStatType StatisticType { get; set; }

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x060006C5 RID: 1733 RVA: 0x0000C467 File Offset: 0x0000A667
		// (set) Token: 0x060006C6 RID: 1734 RVA: 0x0000C46F File Offset: 0x0000A66F
		public double NumberValue { get; set; }

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x060006C7 RID: 1735 RVA: 0x0000C478 File Offset: 0x0000A678
		// (set) Token: 0x060006C8 RID: 1736 RVA: 0x0000C480 File Offset: 0x0000A680
		public string StringValue { get; set; }

		// Token: 0x060006C9 RID: 1737 RVA: 0x0000C48C File Offset: 0x0000A68C
		internal XblTitleManagedStatistic(XblTitleManagedStatistic interopStruct)
		{
			this.StatisticName = interopStruct.statisticName.GetString();
			this.StatisticType = interopStruct.statisticType;
			this.NumberValue = interopStruct.numberValue;
			this.StringValue = interopStruct.stringValue.GetString();
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x0000C4DF File Offset: 0x0000A6DF
		internal XblTitleManagedStatistic(string statisticName, XblTitleManagedStatType statType, string stringValue, double numberValue)
		{
			this.StatisticName = statisticName;
			this.StatisticType = statType;
			this.StringValue = stringValue;
			this.NumberValue = numberValue;
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x0000C504 File Offset: 0x0000A704
		public XblTitleManagedStatistic()
		{
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x0000C50C File Offset: 0x0000A70C
		public XblTitleManagedStatistic(string statisticName, string statisticValue) : this(statisticName, XblTitleManagedStatType.String, statisticValue, 0.0)
		{
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x0000C520 File Offset: 0x0000A720
		public XblTitleManagedStatistic(string statisticName, double statisticValue) : this(statisticName, XblTitleManagedStatType.Number, null, statisticValue)
		{
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x0000C52C File Offset: 0x0000A72C
		public static int Create(string statisticName, string statisticValue, out XblTitleManagedStatistic titleManagedStatistic)
		{
			titleManagedStatistic = new XblTitleManagedStatistic(statisticName, XblTitleManagedStatType.String, statisticValue, 0.0);
			return 0;
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x0000C542 File Offset: 0x0000A742
		public static int Create(string statisticName, double statisticValue, out XblTitleManagedStatistic titleManagedStatistic)
		{
			titleManagedStatistic = new XblTitleManagedStatistic(statisticName, XblTitleManagedStatType.Number, null, statisticValue);
			return 0;
		}
	}
}
