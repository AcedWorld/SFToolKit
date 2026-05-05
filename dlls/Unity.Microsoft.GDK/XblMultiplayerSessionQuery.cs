using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200009A RID: 154
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerSessionQuery
	{
		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000513 RID: 1299 RVA: 0x0000AA0F File Offset: 0x00008C0F
		// (set) Token: 0x06000514 RID: 1300 RVA: 0x0000AA17 File Offset: 0x00008C17
		public string Scid { get; set; }

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000515 RID: 1301 RVA: 0x0000AA20 File Offset: 0x00008C20
		// (set) Token: 0x06000516 RID: 1302 RVA: 0x0000AA28 File Offset: 0x00008C28
		public uint MaxItems { get; set; }

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000517 RID: 1303 RVA: 0x0000AA31 File Offset: 0x00008C31
		// (set) Token: 0x06000518 RID: 1304 RVA: 0x0000AA39 File Offset: 0x00008C39
		public bool IncludePrivateSessions { get; set; }

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000519 RID: 1305 RVA: 0x0000AA42 File Offset: 0x00008C42
		// (set) Token: 0x0600051A RID: 1306 RVA: 0x0000AA4A File Offset: 0x00008C4A
		public bool IncludeReservations { get; set; }

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x0600051B RID: 1307 RVA: 0x0000AA53 File Offset: 0x00008C53
		// (set) Token: 0x0600051C RID: 1308 RVA: 0x0000AA5B File Offset: 0x00008C5B
		public bool IncludeInactiveSessions { get; set; }

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600051D RID: 1309 RVA: 0x0000AA64 File Offset: 0x00008C64
		// (set) Token: 0x0600051E RID: 1310 RVA: 0x0000AA6C File Offset: 0x00008C6C
		public ulong[] XuidFilters { get; set; }

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x0600051F RID: 1311 RVA: 0x0000AA75 File Offset: 0x00008C75
		// (set) Token: 0x06000520 RID: 1312 RVA: 0x0000AA7D File Offset: 0x00008C7D
		public string KeywordFilter { get; set; }

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000521 RID: 1313 RVA: 0x0000AA86 File Offset: 0x00008C86
		// (set) Token: 0x06000522 RID: 1314 RVA: 0x0000AA8E File Offset: 0x00008C8E
		public string SessionTemplateNameFilter { get; set; }

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000523 RID: 1315 RVA: 0x0000AA97 File Offset: 0x00008C97
		// (set) Token: 0x06000524 RID: 1316 RVA: 0x0000AA9F File Offset: 0x00008C9F
		public XblMultiplayerSessionVisibility VisibilityFilter { get; set; }

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000525 RID: 1317 RVA: 0x0000AAA8 File Offset: 0x00008CA8
		// (set) Token: 0x06000526 RID: 1318 RVA: 0x0000AAB0 File Offset: 0x00008CB0
		public uint ContractVersionFilter { get; set; }
	}
}
