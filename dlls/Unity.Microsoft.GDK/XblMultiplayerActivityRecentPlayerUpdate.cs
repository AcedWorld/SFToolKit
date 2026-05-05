using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000A9 RID: 169
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerActivityRecentPlayerUpdate
	{
		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000558 RID: 1368 RVA: 0x0000AE9A File Offset: 0x0000909A
		// (set) Token: 0x06000559 RID: 1369 RVA: 0x0000AEA2 File Offset: 0x000090A2
		public ulong Xuid { get; set; }

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x0600055A RID: 1370 RVA: 0x0000AEAB File Offset: 0x000090AB
		// (set) Token: 0x0600055B RID: 1371 RVA: 0x0000AEB3 File Offset: 0x000090B3
		public XblMultiplayerActivityEncounterType EncounterType { get; set; }
	}
}
