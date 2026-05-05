using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200007E RID: 126
	[MovedFrom("Unity.GameCore")]
	public class XblLeaderboardColumn
	{
		// Token: 0x0600046F RID: 1135 RVA: 0x00009D7C File Offset: 0x00007F7C
		internal XblLeaderboardColumn(XblLeaderboardColumn interopColumn)
		{
			this.StatName = interopColumn.statName.GetString();
			this.StatType = interopColumn.statType;
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000470 RID: 1136 RVA: 0x00009DAF File Offset: 0x00007FAF
		// (set) Token: 0x06000471 RID: 1137 RVA: 0x00009DB7 File Offset: 0x00007FB7
		public string StatName { get; private set; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000472 RID: 1138 RVA: 0x00009DC0 File Offset: 0x00007FC0
		// (set) Token: 0x06000473 RID: 1139 RVA: 0x00009DC8 File Offset: 0x00007FC8
		public XblLeaderboardStatType StatType { get; private set; }
	}
}
