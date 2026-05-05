using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000232 RID: 562
	internal struct XblTitleManagedStatistic
	{
		// Token: 0x06000DE8 RID: 3560 RVA: 0x000113D1 File Offset: 0x0000F5D1
		internal XblTitleManagedStatistic(XblTitleManagedStatistic publicObject, DisposableCollection disposableCollection)
		{
			this.statisticName = new UTF8StringPtr(publicObject.StatisticName, disposableCollection);
			this.statisticType = publicObject.StatisticType;
			this.numberValue = publicObject.NumberValue;
			this.stringValue = new UTF8StringPtr(publicObject.StringValue, disposableCollection);
		}

		// Token: 0x040007D4 RID: 2004
		internal readonly UTF8StringPtr statisticName;

		// Token: 0x040007D5 RID: 2005
		internal readonly XblTitleManagedStatType statisticType;

		// Token: 0x040007D6 RID: 2006
		internal readonly double numberValue;

		// Token: 0x040007D7 RID: 2007
		internal readonly UTF8StringPtr stringValue;
	}
}
