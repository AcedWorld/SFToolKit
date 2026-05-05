using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001EF RID: 495
	internal struct XblLeaderboardColumn
	{
		// Token: 0x06000D97 RID: 3479 RVA: 0x00010371 File Offset: 0x0000E571
		internal XblLeaderboardColumn(XblLeaderboardColumn column, DisposableCollection disposableCollection)
		{
			this.statName = new UTF8StringPtr(column.StatName, disposableCollection);
			this.statType = column.StatType;
		}

		// Token: 0x04000689 RID: 1673
		internal readonly UTF8StringPtr statName;

		// Token: 0x0400068A RID: 1674
		internal readonly XblLeaderboardStatType statType;
	}
}
