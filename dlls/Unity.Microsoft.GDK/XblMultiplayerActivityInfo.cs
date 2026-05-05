using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000A6 RID: 166
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerActivityInfo
	{
		// Token: 0x06000547 RID: 1351 RVA: 0x0000AD89 File Offset: 0x00008F89
		public XblMultiplayerActivityInfo()
		{
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x0000AD94 File Offset: 0x00008F94
		internal XblMultiplayerActivityInfo(XblMultiplayerActivityInfo interopStruct)
		{
			this.Xuid = interopStruct.xuid;
			this.ConnectionString = interopStruct.connectionString.GetString();
			this.JoinRestriction = interopStruct.joinRestriction;
			this.MaxPlayers = interopStruct.maxPlayers.ToUInt32();
			this.CurrentPlayers = interopStruct.currentPlayers.ToUInt32();
			this.GroupId = interopStruct.groupId.GetString();
			this.Platform = interopStruct.platform;
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000549 RID: 1353 RVA: 0x0000AE1B File Offset: 0x0000901B
		// (set) Token: 0x0600054A RID: 1354 RVA: 0x0000AE23 File Offset: 0x00009023
		public ulong Xuid { get; set; }

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x0600054B RID: 1355 RVA: 0x0000AE2C File Offset: 0x0000902C
		// (set) Token: 0x0600054C RID: 1356 RVA: 0x0000AE34 File Offset: 0x00009034
		public string ConnectionString { get; set; }

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x0600054D RID: 1357 RVA: 0x0000AE3D File Offset: 0x0000903D
		// (set) Token: 0x0600054E RID: 1358 RVA: 0x0000AE45 File Offset: 0x00009045
		public XblMultiplayerActivityJoinRestriction JoinRestriction { get; set; }

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x0600054F RID: 1359 RVA: 0x0000AE4E File Offset: 0x0000904E
		// (set) Token: 0x06000550 RID: 1360 RVA: 0x0000AE56 File Offset: 0x00009056
		public uint MaxPlayers { get; set; }

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000551 RID: 1361 RVA: 0x0000AE5F File Offset: 0x0000905F
		// (set) Token: 0x06000552 RID: 1362 RVA: 0x0000AE67 File Offset: 0x00009067
		public uint CurrentPlayers { get; set; }

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000553 RID: 1363 RVA: 0x0000AE70 File Offset: 0x00009070
		// (set) Token: 0x06000554 RID: 1364 RVA: 0x0000AE78 File Offset: 0x00009078
		public string GroupId { get; set; }

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000555 RID: 1365 RVA: 0x0000AE81 File Offset: 0x00009081
		// (set) Token: 0x06000556 RID: 1366 RVA: 0x0000AE89 File Offset: 0x00009089
		public XblMultiplayerActivityPlatform Platform { get; set; }
	}
}
